Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptExistenciasPorProductoAlmacentodos
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String
        reportPath = Server.MapPath("RptExistenciasActualesPorTipoProductoTodosAlmacen.rpt")

        Reporte.Load(reportPath)

        Dim IDALMACEN, IDPRODUCTO, IDFUENTEFINANCIAMIENTO, IDGRUPOFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION As Integer
        Dim CODIGO As String

        IDALMACEN = Request.QueryString("idA")
        IDPRODUCTO = Request.QueryString("idP")
        CODIGO = Request.QueryString("C")
        IDFUENTEFINANCIAMIENTO = Request.QueryString("idFF")
        IDGRUPOFUENTEFINANCIAMIENTO = Request.QueryString("idGF")
        IDRESPONSABLEDISTRIBUCION = Request.QueryString("idRD")

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "Titulo"
        pDiscreteValue1.Value = "Existencias al " + Now.Date.ToShortDateString
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim cL As New cLOTES
        Dim ds As Data.DataSet
        ds = cL.ExistenciaPorProductosActual(IDALMACEN, IDPRODUCTO, CODIGO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDGRUPOFUENTEFINANCIAMIENTO)

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
