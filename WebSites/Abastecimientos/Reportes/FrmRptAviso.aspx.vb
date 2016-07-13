Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptAviso
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument

        Dim IDESTABLECIMIENTO, IDPROCESOCOMPRA As Integer
        'IDESTABLECIMIENTO = Request.QueryString("idE")
        'IdProcesoCompra = Request.QueryString("idPC")
        IDESTABLECIMIENTO = Session("IdEstablecimiento")
        IDPROCESOCOMPRA = Session("IdProcesoCompra")

        Dim cPC As New cPROCESOCOMPRAS
        Dim ds As Data.DataSet
        ds = cPC.ObtenerProcesoCompraAviso(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        Dim TIPOPROCESO As Integer
        TIPOPROCESO = ds.Tables(0).Rows(0).Item("IDTIPOCOMPRA")

        Dim reportPath As String
        Select Case TIPOPROCESO
            Case 1
                reportPath = Server.MapPath("RptAviso.rpt")
            Case 2
                reportPath = Server.MapPath("RptAvisoLPI.rpt")
            Case 5
                reportPath = Server.MapPath("RptAviso.rpt")
            Case Else
                reportPath = Server.MapPath("RptAvisoLPI.rpt")
        End Select

        Reporte.Load(reportPath)

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
