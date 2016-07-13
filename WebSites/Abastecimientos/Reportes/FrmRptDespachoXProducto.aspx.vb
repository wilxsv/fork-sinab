Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptDespachoXProducto
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptDespachoXProducto.rpt")
        Reporte.Load(reportPath)

        Dim IDALMACEN, ANIO, IDESTABLECIMIENTODESTINO, IDP As Integer
        Dim PRODUCTO As String

        IDALMACEN = Request.QueryString("idA")
        ANIO = Request.QueryString("A")
        PRODUCTO = Request.QueryString("P")
        IDP = Request.QueryString("IDP")
        IDESTABLECIMIENTODESTINO = Request.QueryString("idED")

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "ANIO"
        pDiscreteValue1.Value = ANIO.ToString
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim cDM As New cDETALLEMOVIMIENTOS

        Dim ds As Data.DataSet
        ds = cDM.RptDespachosMensualesXProducto(IDALMACEN, ANIO, PRODUCTO, IDESTABLECIMIENTODESTINO, IDP)

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
