'Mantenimiento de usuarios
'CUA0004 seguridad
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de usuarios del sistema
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmMantUsuarios
    Inherits System.Web.UI.Page

    Private _VerEliminados As Boolean = False

    'inicializacion de variables
    Private mComponente As New cUSUARIOS

#Region " Propiedades "

    Public Property VerEliminados() As Boolean
        Get
            Return Me._VerEliminados
        End Get
        Set(ByVal Value As Boolean)
            Me._VerEliminados = Value
            If Not Me.ViewState("VerEliminados") Is Nothing Then Me.ViewState.Remove("VerEliminados")
            Me.ViewState.Add("VerEliminados", Value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'al cargar pagina

        If Not IsPostBack Then 'al cargar por primera vez la página
            'ocultar menu
            Me.Master.ControlMenu.Visible = False

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = True

            CargarDatos()
        Else
            If Not Me.ViewState("VerEliminados") Is Nothing Then Me._VerEliminados = Me.ViewState("VerEliminados")
        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Columnas(VerEliminados)

        'carga de datos en el grid
        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerDsUsuariosEmpleados(IIf(VerEliminados, 1, 0))

        Dim dsVista As New Data.DataView(ds.Tables(0))

        If ucFiltrarDatos1.CampoFiltro <> "" And ucFiltrarDatos1.ValorFiltro <> "" Then
            Select Case dsVista.Table.Columns(ucFiltrarDatos1.CampoFiltro).DataType.Name
                Case "String"
                    dsVista.RowFilter = ucFiltrarDatos1.CampoFiltro & " LIKE '%" & ucFiltrarDatos1.ValorFiltro & "%'"
            End Select
        End If

        Me.ucBarraNavegacion1.ibtnImprimirOnClientClick = ReporteUsuarios(ucFiltrarDatos1.CampoFiltro, ucFiltrarDatos1.ValorFiltro)

        Me.gvLista.DataSource = dsVista

        'carga grid view
        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        If Not Page.IsPostBack Then
            ucFiltrarDatos1.AddColumnasExcluidas(gvLista.Columns(3).HeaderText)
            ucFiltrarDatos1.AddColumnasExcluidas(gvLista.Columns(4).HeaderText)
            ucFiltrarDatos1.AddColumnasExcluidas(gvLista.Columns(5).HeaderText)
            ucFiltrarDatos1.AddColumnasExcluidas(gvLista.Columns(6).HeaderText)
            ucFiltrarDatos1.ValorColumnas = gvLista.Columns
        End If

    End Sub

    Private Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        'evento agregar un usuario
        Response.Redirect("~/SEGURIDAD/FrmDetaMantUsuarios.aspx?id=0", False) 'redirecciona a formulario conteniendo detalle
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        'al cambiar el indice de pagina en el gridview
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        'al cargar cada registro en el gridview
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim a As ImageButton = CType(e.Row.FindControl("ImageButton1"), ImageButton)
            Dim s As String
            s = "if("
            s += a.CommandArgument
            s += ">0){alert('El usuario seleccionado se encuentra asignado a un rol, por lo que no puede ser eliminado.  Elimine primero la asignación al rol.');return false;}else{if (!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}}"
            a.Attributes.Add("onclick", s)
        End If
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting
        'al eliminar un registro del gridview
        Dim IDUSUARIO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim AUUSUARIOELIMINACION As String = HttpContext.Current.User.Identity.Name
        Dim AUFECHAELIMINACION As DateTime = Now

        If Me.mComponente.EliminarUSUARIOS(IDUSUARIO, AUUSUARIOELIMINACION, AUFECHAELIMINACION) = 0 Then
            'Si se cometio un error
        Else
            Me.CargarDatos()
        End If
    End Sub

    Protected Sub lnkPrimero_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.gvLista.PageIndex = 0
        Me.CargarDatos()
    End Sub

    Protected Sub lnkUltimo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.gvLista.PageIndex = Me.gvLista.PageCount
        Me.CargarDatos()
    End Sub

    Protected Sub lnkAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.gvLista.PageIndex > 0 Then
            Me.gvLista.PageIndex = Me.gvLista.PageIndex - 1
            Me.CargarDatos()
        End If
    End Sub

    Protected Sub lnkSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.gvLista.PageIndex < Me.gvLista.PageCount Then
            Me.gvLista.PageIndex = Me.gvLista.PageIndex + 1
            Me.CargarDatos()
        End If
    End Sub

    Protected Sub ucFiltrarDatos1_Buscar() Handles ucFiltrarDatos1.Buscar
        CargarDatos()
    End Sub

    Private Function ReporteUsuarios(Optional ByVal CampoFiltro As String = "", Optional ByVal ValorFiltro As String = "") As String
        Dim cad As String

        ''Dim s As Ne StringBuilder
        ''s.Append("windwow.open('")
        ''s.Append(Request.ApplicationPath)

        If VerEliminados Then
            cad = String.Format("/Reportes/FrmRptUsuariosEliminados.aspx?cf={0}&vf={1}", Server.HtmlEncode(CampoFiltro), Server.HtmlEncode(ValorFiltro))
        Else
            cad = String.Format("/Reportes/FrmRptUsuariosSistema.aspx?cf={0}&vf={1}", Server.HtmlEncode(CampoFiltro), Server.HtmlEncode(ValorFiltro))
          
        End If

        'If Not String.IsNullOrEmpty(CampoFiltro) Then
        '    s.Append("?cf=")
        '    s.Append(Server.HtmlEncode(CampoFiltro))
        '    s.Append("&vf=")
        '    s.Append(Server.HtmlEncode(ValorFiltro))
        'End If

        's.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")

        Return SINAB_Utils.Utils.ReferirVentana(cad)
        's.ToString()
    End Function

    Protected Sub lbVerEliminados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbVerEliminados.Click

        VerEliminados = Not VerEliminados

        If VerEliminados Then
            Me.lbVerEliminados.Text = "<< Regresar"
            Me.ucBarraNavegacion1.PermitirAgregar = False
        Else
            Me.lbVerEliminados.Text = "Ver usuarios eliminados"
            Me.ucBarraNavegacion1.PermitirAgregar = True
        End If

        CargarDatos()

    End Sub

    Private Sub Columnas(ByVal value As Boolean)
        Me.gvLista.Columns(0).Visible = Not value
        Me.gvLista.Columns(3).Visible = Not value
        Me.gvLista.Columns(3).Visible = Not value
        Me.gvLista.Columns(5).Visible = value
        Me.gvLista.Columns(6).Visible = value
        Me.gvLista.Columns(7).Visible = Not value
    End Sub

End Class
