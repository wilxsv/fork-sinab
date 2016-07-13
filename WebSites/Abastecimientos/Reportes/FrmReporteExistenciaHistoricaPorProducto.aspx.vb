
Partial Class FrmReporteExistenciaHistoricaPorProducto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""
            Me.ucFiltrosReportesAlmacen1.VerFechaHasta = True
            Me.ucFiltrosReportesAlmacen1.FechasRequeridas = True
            Me.ucFiltrosReportesAlmacen1.VerGrupoFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerResponsableDistribucion = True
            Me.ucFiltrosReportesAlmacen1.VerEstablecimiento = True
            Me.ucFiltrosReportesAlmacen1.VerProducto = True
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        With ucFiltrosReportesAlmacen1
            Dim cad = String.Format("/Reportes/FrmRptExistenciaHistoricaPorProducto.aspx?idA={0}&idFF={1}&idRD={2}&idP={3}&fh={4}", Session("IdAlmacen"), .IDFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION, .PRODUCTO, .FECHAHASTA)
            SINAB_Utils.Utils.MostrarVentana(cad)
        End With

    End Sub

End Class
