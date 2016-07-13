
Partial Class FrmReporteVencidosHistoricosPorTipoProducto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""

            Me.ucFiltrosReportesAlmacen1.VerFechaHasta = True
            Me.ucFiltrosReportesAlmacen1.VerFechaDesde = True
            Me.ucFiltrosReportesAlmacen1.FechasRequeridas = True
            Me.ucFiltrosReportesAlmacen1.VerTipoSuministro = True
            Me.ucFiltrosReportesAlmacen1.VerGrupo = False
            Me.ucFiltrosReportesAlmacen1.VerGrupoFuenteFinanciamiento = False
            Me.ucFiltrosReportesAlmacen1.VerFuenteFinanciamiento = False
            Me.ucFiltrosReportesAlmacen1.b = 1
            Me.ucFiltrosReportesAlmacen1.IniciarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        With ucFiltrosReportesAlmacen1
            Dim cad = String.Format("/Reportes/FrmRptVencidosHistoricosPorTipoProductoAlmacen.aspx?idA={0}&idS={1}&fh={2}&fd={3}", Session("IdAlmacen"), .IDSUMINISTRO, .FECHAHASTA, .FECHADESDE)
            SINAB_Utils.Utils.MostrarVentana(cad)
        End With
        

    End Sub

End Class
