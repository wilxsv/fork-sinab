Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptContratoNoUaci
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptContratoNoUaci.rpt")
        Reporte.Load(reportPath)

        Dim lEstablecimiento, lContrato, lProveedor As Integer
        lEstablecimiento = Session.Item("IdEstablecimiento")
        lContrato = Request.QueryString("IdContrato")
        lProveedor = Request.QueryString("IdProveedor")

        Dim mCompResponsables As New cRESPONSABLEDISTRIBUCION
        Dim mCompFuentes As New cFUENTEFINANCIAMIENTOS

        Dim mComponente As New cCONTRATOS
        Dim ds As Data.DataSet
        ds = mComponente.ObtenerContratoNoUACI2(lEstablecimiento, lProveedor, lContrato)

        Reporte.SetDataSource(ds.Tables(0))

        Reporte.DataDefinition.FormulaFields("Nombrealmacen").Text = "'" & Session.Item("NombreAlmacen") & "'"
        Reporte.DataDefinition.FormulaFields("Observacion").Text = "'Documento Provisorio Para Revisión'"
        Reporte.DataDefinition.FormulaFields("Fuentes").Text = "'" & mCompFuentes.DevolverFFContratos(lEstablecimiento, lProveedor, lContrato) & "'"
        Reporte.DataDefinition.FormulaFields("Responsable").Text = "'" & mCompResponsables.DevolverRDContratos(lEstablecimiento, lProveedor, lContrato) & "'"

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
