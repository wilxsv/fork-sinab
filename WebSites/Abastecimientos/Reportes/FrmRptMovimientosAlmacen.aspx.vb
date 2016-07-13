Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptMovimientosAlmacen
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath("RptMovimientosKardex3.rpt")
        Reporte.Load(reportPath)

        Dim IDALMACEN, IDFUENTEFINANCIAMIENTO, IDGRUPOFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDPRODUCTO, IDGRUPO As Integer
        Dim CODIGO As String
        Dim FECHADESDE, FECHAHASTA As Date

        IDALMACEN = Request.QueryString("idA")
        FECHADESDE = Date.Parse(Request.QueryString("fd"))
        FECHAHASTA = Date.Parse(Request.QueryString("fh"))
        IDFUENTEFINANCIAMIENTO = Request.QueryString("idFF")
        IDGRUPOFUENTEFINANCIAMIENTO = Request.QueryString("idGF")
        IDRESPONSABLEDISTRIBUCION = Request.QueryString("idRD")
        IDPRODUCTO = Request.QueryString("idP")
        CODIGO = Request.QueryString("C")
        IDGRUPO = Request.QueryString("idG")

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "Titulo"
        pDiscreteValue1.Value = "Movimientos y saldos del " + String.Format("{0:d}", FECHADESDE) + " a " + String.Format("{0:d}", FECHAHASTA) + " por producto"
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim x As New cALMACENES
        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "Nombrealmacen"
        Dim xe As New ABASTECIMIENTOS.ENTIDADES.ALMACENES
        xe = x.ObtenerALMACENES(IDALMACEN)
        pDiscreteValue2.Value = xe.NOMBRE
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim cDM As New cDETALLEMOVIMIENTOS

        Dim ds As Data.DataSet
        ds = cDM.MovimientosPorProducto(IDALMACEN, FECHADESDE, FECHAHASTA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDPRODUCTO, CODIGO, IDGRUPO, IDGRUPOFUENTEFINANCIAMIENTO)

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
