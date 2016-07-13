﻿'Mantenimiento de opciones del sistema
'CUA0002 seguridad
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de opciones del sistema
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmMantOpcionesSistema
    Inherits System.Web.UI.Page

    'inicializacion de variables
    Private mComponente As New cOPCIONESSISTEMA

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'al cargar pagina

        If Not IsPostBack Then 'al cargar por primera vez la pagina
            'ocultar menu
            Me.Master.ControlMenu.Visible = False

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = True

            CargarDatos()
        End If

    End Sub

    Private Sub CargarDatos()

        'carga de datos en el grid
        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerListaOpciones()

        Dim dsVista As New Data.DataView(ds.Tables(0))

        If UcFiltrarDatos1.CampoFiltro <> "" And UcFiltrarDatos1.ValorFiltro <> "" Then
            Select Case dsVista.Table.Columns(UcFiltrarDatos1.CampoFiltro).DataType.Name
                Case "String"
                    dsVista.RowFilter = UcFiltrarDatos1.CampoFiltro & " LIKE '%" & UcFiltrarDatos1.ValorFiltro & "%'"
            End Select
        End If

        Me.ucBarraNavegacion1.ibtnImprimirOnClientClick = ReporteOpciones(UcFiltrarDatos1.CampoFiltro, UcFiltrarDatos1.ValorFiltro)

        Me.gvLista.DataSource = dsVista

        'carga grid view
        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        If Not Page.IsPostBack Then
            UcFiltrarDatos1.AddColumnasExcluidas(gvLista.Columns(2).HeaderText)
            UcFiltrarDatos1.AddColumnasExcluidas(gvLista.Columns(3).HeaderText)
            UcFiltrarDatos1.ValorColumnas = gvLista.Columns
        End If

    End Sub

    Private Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        'evento agregar una opción
        Response.Redirect("~/SEGURIDAD/FrmDetaMantOpcionesSistema.aspx?id=0", False)
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
            s += ">0){alert('Existen opciones del sistema que dependen de la seleccionada, por lo que no puede ser eliminada.  Elimine primero las opciones relacionadas.');return false;}else{if (!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}}"
            a.Attributes.Add("onclick", s)
        End If
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting
        'al eliminar un registro del gridview
        Dim IDOPCIONSISTEMA As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)

        If Me.mComponente.EliminarOPCIONESSISTEMA(IDOPCIONSISTEMA) = 0 Then
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

    Protected Sub ucFiltrarDatos1_Buscar() Handles UcFiltrarDatos1.Buscar
        CargarDatos()
    End Sub

    Private Function ReporteOpciones(Optional ByVal CampoFiltro As String = "", Optional ByVal ValorFiltro As String = "") As String
        Dim cad = String.Format("/Reportes/FrmRptOpcionesSistema.aspx?cf={0}&vf={1}", Server.HtmlEncode(CampoFiltro), Server.HtmlEncode(ValorFiltro))
        ' Dim s As New StringBuilder
        ' s.Append("window.open('")
        ' s.Append(Request.ApplicationPath)
        's.Append("/Reportes/FrmRptOpcionesSistema.aspx")

        'If Not String.IsNullOrEmpty(CampoFiltro) Then
        '            s.Append("?cf=")
        ' s.Append(Server.HtmlEncode(CampoFiltro))
        's.Append("&vf=")
        ' s.Append(Server.HtmlEncode(ValorFiltro))
        'End If

        's.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")

        Return SINAB_Utils.Utils.ReferirVentana(cad)
        's.ToString()
    End Function

End Class
