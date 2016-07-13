
Imports CrystalDecisions.Shared
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports CrystalDecisions.CrystalReports.Engine

Partial Class Reportes_FrmRptAbastecimientoDetalleProductosConsolidados
    Inherits System.Web.UI.Page

    Private _reporte As ReportDocument

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        _reporte.Close()
        _reporte.Dispose()
    End Sub

    Private Sub ConfigureCrystalReports()
        _reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("~/Reportes/rpt/AbastecimientoCuadroBasico.rpt")
        _reporte.Load(reportPath)

        Dim ds = ProductoAlmacen.ObtenerReporteDetallado()
        _reporte.SetDataSource(ds)

        With crvPrincipal
            .ReportSource = _reporte

            ' Reporte.SetParameterValue("LogoSrc", Server.MapPath(Config.LogoUrl))
            .DisplayGroupTree = False
            .DisplayToolbar = True

            .EnableDrillDown = False

            .HasCrystalLogo = False
            .HasDrillUpButton = False
            .HasGotoPageButton = True
            .HasPageNavigationButtons = True
            .HasPrintButton = True
            .HasRefreshButton = False
            .HasSearchButton = False
            .HasToggleGroupTreeButton = False
            .HasViewList = False
            .HasZoomFactorList = False

            .PrintMode = CrystalDecisions.Web.PrintMode.ActiveX
        End With

    End Sub
End Class
