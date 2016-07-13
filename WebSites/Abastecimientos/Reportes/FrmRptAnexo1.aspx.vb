Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptAnexo1
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfiguracionReporte()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptAnexo1.rpt")

        Dim IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDCONTRATO As Int64
        IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        IDPROCESOCOMPRA = Request.QueryString("id")
        IDPROVEEDOR = Request.QueryString("Pr")
        IDCONTRATO = Request.QueryString("CON")

        Reporte.Load(reportPath)

        Dim cPC As New cPROCESOCOMPRAS
        Dim ds As Data.DataSet
        ds = cPC.ObtenerAnexo1(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDCONTRATO)

        Dim CC As New cCONTRATOS
        Dim ds2 As New Data.DataSet
        ds2 = CC.DevolverContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCONTRATO, IDPROVEEDOR)

        Reporte.DataDefinition.FormulaFields(2).Text = "'" & ds2.Tables(0).Rows(0).Item("NUMEROCONTRATO") & "'"

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
