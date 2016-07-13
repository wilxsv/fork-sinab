Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmReporteValesSalida
    Inherits System.Web.UI.Page

    Private cVS As New cVALESSALIDA

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = "Número de vale de salida"

            Me.ucFiltrosReportesAlmacen1.VerFechaDesde = True
            Me.ucFiltrosReportesAlmacen1.VerFechaHasta = True
            Me.ucFiltrosReportesAlmacen1.FechasRequeridas = True
            Me.ucFiltrosReportesAlmacen1.VerFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerGrupoFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerResponsableDistribucion = True
            Me.ucFiltrosReportesAlmacen1.VerEstablecimiento = True
            Me.ucFiltrosReportesAlmacen1.b = 0
            Me.ucFiltrosReportesAlmacen1.VerTipoSuministro = True
            Me.ucFiltrosReportesAlmacen1.TipoSuministroTodos = True
            Me.ucFiltrosReportesAlmacen1.IniciarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosDocumentosAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Dim ds As Data.DataSet
        ds = cVS.ObtenerListaValesSalida(Session("IdAlmacen"), ucFiltrosReportesAlmacen1.IDESTABLECIMIENTO, ucFiltrosReportesAlmacen1.FECHADESDE, ucFiltrosReportesAlmacen1.FECHAHASTA, ucFiltrosReportesAlmacen1.IDFUENTEFINANCIAMIENTO, ucFiltrosReportesAlmacen1.IDRESPONSABLEDISTRIBUCION, ucFiltrosReportesAlmacen1.IDESTADO, ucFiltrosReportesAlmacen1.Documento, ucFiltrosReportesAlmacen1.IDGRUPOFUENTEFINANCIAMIENTO, ucFiltrosReportesAlmacen1.IDSUMINISTRO)

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Me.gvLista.Visible = True

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lb As LinkButton = CType(e.Row.FindControl("lbVer"), LinkButton)
            Dim cad = String.Format("/Reportes/FrmRptValeSalida.aspx?IdEMov={0}&IdMov={1}", Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDESTABLECIMIENTOMOVIMIENTO"), Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDMOVIMIENTO"))

            'Dim s As New StringBuilder

            's.Append("window.open('")
            '.Append(Request.ApplicationPath)
            '.Append("/Reportes/FrmRptValeSalida.aspx?")
            's.Append("IdEMov=")
            's.Append(Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDESTABLECIMIENTOMOVIMIENTO").ToString())
            's.Append("&IdMov=")
            's.Append(Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDMOVIMIENTO").ToString())
            's.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")
            lb.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
            'lb.Attributes.Add("onclick", s.ToString)

            Dim IDALMACEN As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDALMACEN")
            Dim ANIO As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Item("ANIO")
            Dim IDVALE As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDVALE")

            Dim ds As Data.DataSet
            Dim gv As GridView

            ds = cVS.ObtenerFuentesValesSalida(IDALMACEN, ANIO, IDVALE)

            gv = CType(e.Row.FindControl("gvDetalleFuentes"), GridView)
            gv.DataSource = ds
            gv.DataBind()

            Select Case e.Row.RowState
                Case DataControlRowState.Normal
                    gv.RowStyle.CssClass = sender.RowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.RowStyle.CssClass
                Case DataControlRowState.Alternate
                    gv.RowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                Case DataControlRowState.Selected
                    gv.RowStyle.CssClass = sender.SelectedRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.SelectedRowStyle.CssClass
            End Select

            ds = cVS.ObtenerResponsablesDistribucionValesSalida(IDALMACEN, ANIO, IDVALE)

            gv = CType(e.Row.FindControl("gvDetalleResponsables"), GridView)
            gv.DataSource = ds
            gv.DataBind()

            Select Case e.Row.RowState
                Case DataControlRowState.Normal
                    gv.RowStyle.CssClass = sender.RowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.RowStyle.CssClass
                Case DataControlRowState.Alternate
                    gv.RowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                Case DataControlRowState.Selected
                    gv.RowStyle.CssClass = sender.SelectedRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.SelectedRowStyle.CssClass
            End Select

        End If

    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_SelectedIndexChanged() Handles ucFiltrosReportesAlmacen1.SelectedIndexChanged
        Me.gvLista.Visible = False
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("~/Almacen/FrmReportesAlmacenes.aspx")
    End Sub

End Class
