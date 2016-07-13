Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptExistenciaHistoricaPorTipoProductoAlmacen
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String
        reportPath = Server.MapPath("~/Reportes/RptExistenciasActualesPorTipoProductoAlmacenEspecificosGasto.rpt")

        Reporte.Load(reportPath)

        Dim IDALMACEN As Integer
        Dim IDSUMINISTRO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDGRUPOFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, fos As Integer
        Dim FECHAHASTA As Date
        Dim IDESPECIFICOGASTO As Integer

        IDALMACEN = Request.QueryString("idA")
        IDSUMINISTRO = Request.QueryString("idS")
        IDGRUPO = Request.QueryString("idG")
        IDGRUPOFUENTEFINANCIAMIENTO = Request.QueryString("idGF")
        IDFUENTEFINANCIAMIENTO = Request.QueryString("idFF")
        IDRESPONSABLEDISTRIBUCION = Request.QueryString("idRD")
        FECHAHASTA = Date.Parse(Request.QueryString("fh"))
        fos = Request.QueryString("fos")
        IDESPECIFICOGASTO = Request.QueryString("idEG")

        Dim EspecificoGasto As String

        If IDESPECIFICOGASTO = 0 Then
            EspecificoGasto = "Todos"
        Else
            Dim cEG As New cESPECIFICOSGASTO
            Dim eEG As New ESPECIFICOSGASTO
            eEG = cEG.ObtenerESPECIFICOGASTO(IDESPECIFICOGASTO)
            EspecificoGasto = eEG.CODIGO.ToString + " - " + eEG.NOMBRE.ToUpper
        End If

        Dim pFields As New ParameterFields()

        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "Titulo"
        pDiscreteValue1.Value = "Existencias Históricas al " + Request.QueryString("fh")
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "ESPECIFICOGASTO"
        pDiscreteValue2.Value = EspecificoGasto
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim cL As New cLOTES

        Dim ds As Data.DataSet
        If Not Page.IsPostBack Then
            '    If Session("vHistoricaContable") Is Nothing Then
            ds = cL.ExistenciaHistoricaPorTipoProducto(IDALMACEN, IDSUMINISTRO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, FECHAHASTA, IDGRUPOFUENTEFINANCIAMIENTO, fos, IDESPECIFICOGASTO)
            Session("vHistoricaContable") = ds
            'End If
        End If
        ds = Session("vHistoricaContable")

        '  ds = cL.ExistenciaHistoricaPorTipoProducto(IDALMACEN, IDSUMINISTRO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, FECHAHASTA, IDGRUPOFUENTEFINANCIAMIENTO, fos, IDESPECIFICOGASTO)

        Reporte.SetDataSource(ds.Tables(0))

        Me.crvPrincipal.ParameterFieldInfo = pFields
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
