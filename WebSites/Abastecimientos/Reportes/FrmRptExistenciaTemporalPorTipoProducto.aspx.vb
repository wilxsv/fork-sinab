Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptExistenciaTemporalPorTipoProducto
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath("RptExistenciaTemporalPorTipoProducto.rpt")
        Reporte.Load(reportPath)

        Dim IDALMACEN As Integer
        Dim IDSUMINISTRO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION As Integer

        IDALMACEN = Request.QueryString("idA")
        IDSUMINISTRO = Request.QueryString("idS")
        IDFUENTEFINANCIAMIENTO = Request.QueryString("idFF")
        IDRESPONSABLEDISTRIBUCION = Request.QueryString("idRD")

        Dim cL As New cLOTES
        Dim ds As Data.DataSet

        ds = cL.ExistenciaTemporalPorTipoProducto(IDALMACEN, IDSUMINISTRO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION)

        Reporte.SetDataSource(ds.Tables(0))
        Me.crvPrincipal.ReportSource = Reporte

        Me.crvPrincipal.DisplayGroupTree = False
        Me.crvPrincipal.DisplayToolbar = True
        Me.crvPrincipal.EnableDrillDown = False
        Me.crvPrincipal.HasCrystalLogo = False
        Me.crvPrincipal.HasDrillUpButton = False
        Me.crvPrincipal.HasGotoPageButton = True
        Me.crvPrincipal.HasPageNavigationButtons = True
        Me.crvPrincipal.HasPrintButton = True
        Me.crvPrincipal.HasRefreshButton = False
        Me.crvPrincipal.HasSearchButton = False
        Me.crvPrincipal.HasToggleGroupTreeButton = False
        Me.crvPrincipal.HasViewList = False
        Me.crvPrincipal.HasZoomFactorList = False

        Me.crvPrincipal.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
