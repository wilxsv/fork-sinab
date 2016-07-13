Imports ABASTECIMIENTOS.NEGOCIO

Partial Class URMIM_frmMantProgramacionAlmacenesConsolidado
    Inherits System.Web.UI.Page

    Private _IDGRUPO As Integer

    Public Property IDGRUPOX() As Integer 'identificador de programacion
        Get
            Return Me._IDGRUPO
        End Get
        Set(ByVal Value As Integer)
            Me._IDGRUPO = Value

            If Not Me.ViewState("IDGRUPO") Is Nothing Then Me.ViewState.Remove("IDGRUPO")
            Me.ViewState.Add("IDGRUPO", Value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            If Request.QueryString("id") Is Nothing Then Response.Redirect("~/URMIM/frmMantProgramacionConsolidado.aspx", False)
            If Not IsNumeric(Request.QueryString("id")) Then Response.Redirect("~/URMIM/frmMantProgramacionConsolidado.aspx", False)

            IDGRUPOX = Request.QueryString("id")

            Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMACION
            Dim estado As Integer = cEntidad.obtenerEstadoGrupo(IDGRUPOX)

            If estado >= 2 Then
                Me.gvLista.Enabled = False
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False

            CargarDatosDisponibles()

        End If

    End Sub

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/URMIM/frmMantProgramacionConsolidado.aspx", False)
    End Sub

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar

        Dim cEntidad As New cPROGRAMACION
        Dim arr As New ArrayList

        For Each row As GridViewRow In gvLista.Rows


            Dim dd As DropDownList

            dd = row.FindControl("dd1")

            Dim s(2) As Integer

            s(0) = Me.gvLista.DataKeys(row.RowIndex).Values(0)
            s(1) = Me.gvLista.DataKeys(row.RowIndex).Values(1)
            s(2) = -1

            If dd.SelectedIndex > 0 Then
                s(2) = dd.SelectedItem.Value
            End If

            arr.Add(s)

        Next

        If cEntidad.actualizarAlmacenProgramacion(arr, HttpContext.Current.User.Identity.Name) = 1 Then
            Me.MsgBox1.ShowAlert("Datos almacenados", "Mensaje", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            CargarDatosDisponibles()
        Else
            Me.MsgBox1.ShowAlert("Error al almacenar los lugares de entrega", "Mensaje", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Private Sub CargarDatosDisponibles() 'carga los datos y los muestra en el gridview

        Dim mComponente As New cPROGRAMACION

        Me.gvLista.DataSource = mComponente.obtenerGrupoEstablecimientos(Me.ViewState("IDGRUPO"))

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        Dim cEntidad As New cALMACENESESTABLECIMIENTOS

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim dd1 As DropDownList
            Dim establecimiento As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Values(1)
            Dim almacen As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Values(2)

            dd1 = e.Row.FindControl("dd1")

            dd1.Items.Clear()
            dd1.Items.Add("[Seleccione un Almacén de Entrega]")

            dd1.DataSource = cEntidad.ObtenerTodosAlmacenEstablecimiento(establecimiento, 0)
            dd1.DataTextField = "nombre"
            dd1.DataValueField = "idAlmacen"

            dd1.DataBind()

            'Cuando existe fuente, llenamos el segundo combo para asignarle la fuente
            If almacen > -1 Then

                For i As Integer = 1 To dd1.Items.Count - 1
                    If dd1.Items(i).Value = almacen Then
                        dd1.SelectedIndex = i
                        Exit For
                    End If
                Next

            End If

        End If

    End Sub

    'Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Dim row As GridViewRow = sender.parent.parent

    '    Dim dd2 As DropDownList
    '    Dim dd1 As DropDownList

    '    Dim grupo As Integer = -1

    '    dd1 = row.FindControl("dd1")
    '    dd2 = row.FindControl("dd2")

    '    dd2.Items.Clear()
    '    dd2.Items.Add("[Seleccione una Fuente]")

    '    If dd1.SelectedIndex > 0 Then
    '        grupo = dd1.SelectedItem.Value
    '    End If

    '    llenarFuentes(grupo, dd2)

    'End Sub

    'Private Sub llenarFuentes(ByVal idGrupo As Integer, ByRef dd As DropDownList)

    '    Dim cEntidad As New cFUENTEFINANCIAMIENTOS

    '    dd.DataSource = cEntidad.RecuperarPorGrupo(idGrupo)
    '    dd.DataTextField = "nombre"
    '    dd.DataValueField = "idFuenteFinanciamiento"
    '    dd.DataBind()

    'End Sub

End Class
