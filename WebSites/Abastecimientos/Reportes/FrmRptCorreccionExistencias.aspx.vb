Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptCorreccionExistencias
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfiguracionReporte()

        Dim reportPath As String = Server.MapPath("RptCorreccionExistencias.rpt")

        If reportPath = String.Empty Then Return

        Reporte = New ReportDocument
        Reporte.Load(reportPath)

        Dim IDALMACEN, ANIO, IDCORRECCION As Integer
        IDALMACEN = Request.QueryString("IdA")
        ANIO = Request.QueryString("A")
        IDCORRECCION = Request.QueryString("IdC")

        Dim cCA As New cCORRECCIONESALMACENES
        Dim ds As Data.DataSet
        ds = cCA.RptCorreccionesAlmacen(IDALMACEN, ANIO, IDCORRECCION)

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
        ConfiguracionReporte()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
