Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptProximosAVencerAlmacen
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptExistenciasActualesPorTipoProductoAlmacen.rpt")
        Reporte.Load(reportPath)

        Dim IDALMACEN, IDSUMINISTRO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDGRUPOFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDPROGRAMA As Integer
        Dim FechaHasta As Date

        IDALMACEN = Request.QueryString("idA")
        IDSUMINISTRO = Request.QueryString("idS")
        IDGRUPO = Request.QueryString("idG")
        IDFUENTEFINANCIAMIENTO = Request.QueryString("idFF")
        IDGRUPOFUENTEFINANCIAMIENTO = Request.QueryString("idGF")
        IDRESPONSABLEDISTRIBUCION = Request.QueryString("idRD")
        FechaHasta = Request.QueryString("FH")
        IDPROGRAMA = Request.QueryString("idPR")

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "Titulo"
        pDiscreteValue1.Value = "Próximos a vencer (hasta el " + FechaHasta.ToShortDateString + ")"
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim cL As New cLOTES
        Dim ds As Data.DataSet
        ds = cL.RptProximosAVencerAlmacen(IDALMACEN, IDSUMINISTRO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, FechaHasta, IDGRUPOFUENTEFINANCIAMIENTO, IDPROGRAMA)

        Me.crvPrincipal.ParameterFieldInfo = pFields

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
