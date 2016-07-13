Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptProveedoresContratados
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Dim paramField As New ParameterField()
    Dim paramFields As New ParameterFields()
    Dim discreteVal As New ParameterDiscreteValue()

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptProveedoresContratados.rpt")
        Reporte.Load(reportPath)

        Dim IDCONTRATO, IDPROVEEDOR As Integer
        IDCONTRATO = Request.QueryString("idC")
        IDPROVEEDOR = Request.QueryString("idP")

        Dim cI As New cINFORMEMUESTRAS
        Dim ds As Data.DataSet
        ds = cI.ReporteProveedoresContratados(Session.Item("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO)

        Reporte.SetDataSource(ds.Tables(0))
        Reporte.DataDefinition.FormulaFields(0).Text = "'" & Session("NoContrato") & "'"
        Reporte.DataDefinition.FormulaFields(1).Text = "'" & Session("CodProveedor") & "'"
        Reporte.DataDefinition.FormulaFields(2).Text = "'" & Session("Proveedor") & "'"
        Reporte.DataDefinition.FormulaFields(3).Text = "'" & Session("MontoContratado") & "'"
        Reporte.DataDefinition.FormulaFields(4).Text = "'" & Session("Fecha") & "'"

        Me.crvPrincipal.ReportSource = Reporte

        Me.crvPrincipal.DisplayGroupTree = False
        Me.crvPrincipal.DisplayToolbar = True
        Me.crvPrincipal.HasCrystalLogo = False
        Me.crvPrincipal.HasGotoPageButton = True
        Me.crvPrincipal.HasPageNavigationButtons = True
        Me.crvPrincipal.HasPrintButton = True
        Me.crvPrincipal.HasRefreshButton = False
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
