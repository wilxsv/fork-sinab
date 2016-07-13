Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Reportes_frmrptProductos
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptProductos.rpt")
        Reporte.Load(reportPath)

        'Dim lId, lPr, lIdd As Integer
        'lId = Request.QueryString("id")
        'lPr = Request.QueryString("Pr")
        'lIdd = Request.QueryString("Idd")

        'Dim cF As New cFUENTEFINANCIAMIENTOS
        'Dim x As String
        'x = cF.DevolverFFPC(lId, Session.Item("IdEstablecimiento"))
        Dim y As Integer = 123
        Reporte.DataDefinition.FormulaFields(0).Text = "'" & y & "'"

        'Dim mComponente As New cPROCESOCOMPRAS
        'Dim ds As Data.DataSet
        'ds = mComponente.obtenerExamenRenglonEP(Session.Item("IdEstablecimiento"), lId, lPr, lIdd)

        Dim x As New cCATALOGOPRODUCTOS

        Dim ds As Data.DataSet
        ds = x.ObtenerCatalogoProductosCompleto()

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
