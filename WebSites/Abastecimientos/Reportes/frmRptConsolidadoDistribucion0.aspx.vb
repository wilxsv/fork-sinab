Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_frmRptConsolidadoDistribucion0
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument
    Dim lId As Integer
    Dim lIde As Integer

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptConsolidadoDistribucionB2.rpt")
        lId = Request.QueryString("id")
        lIde = Request.QueryString("ide")
        Reporte.Load(reportPath)


        Dim mComponente As New cNECESIDADESSOLICITUD
        Dim mEntidad As New NECESIDADESSOLICITUD
        'todo: verificar si ya existe en UACI un proceso de compra y si no llamar la funcion no consolidada del helper

        'Dim dsConsolidadoDistribucion = SINAB_Entidades.Helpers.EstablecimientoHelpers.SolicitudesProcesoCompras.ObtenerTodos(lid) 'As DataSet
        Dim dsConsolidadoDistribucion As DataSet = mComponente.ObtenerDataSetDistribucion(lIde, lId)

        Reporte.SetDataSource(dsConsolidadoDistribucion.Tables(0))
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
