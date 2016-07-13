Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_frmRptConsolidadoDistribucion0
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Dim lId As Int64
    Dim lDependencia As String
    Dim lCompra As String
    Dim lestablecimiento As String

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptConsolidadoDistribucionSolicitud.rpt")
        lId = Request.QueryString("id")
        Reporte.Load(reportPath)

        lDependencia = Session.Item("RptDependencia")
        lestablecimiento = Session.Item("RptEstablecimiento")
        lCompra = Session.Item("RptCompra")


        Dim mComponente As New cSOLICITUDES
        Dim mEntidad As New SOLICITUDES

        Dim Dependencia As String
        Dim Compra As String
        Dim Establecimiento As String

        Dependencia = lDependencia
        Establecimiento = lestablecimiento
        Compra = "Compra de " & lCompra

        Dim dsConsolidadoDistribucionSolicitud As DataSet
        dsConsolidadoDistribucionSolicitud = mComponente.ObtenerDataSetDistribucionSolicitud(Session.Item("IdEstablecimiento"), lId)

        Reporte.SetDataSource(dsConsolidadoDistribucionSolicitud.Tables(0))

        Reporte.DataDefinition.FormulaFields("TituloEstablecimiento").Text = "'" & Establecimiento & "'"
        Reporte.DataDefinition.FormulaFields("TituloDependencia").Text = "'" & Dependencia & "'"
        Reporte.DataDefinition.FormulaFields("TituloCompra").Text = "'" & Compra & "'"

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
