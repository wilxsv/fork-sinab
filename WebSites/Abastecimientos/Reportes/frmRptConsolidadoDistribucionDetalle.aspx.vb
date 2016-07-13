
Imports CrystalDecisions.CrystalReports.Engine
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Imports System.Linq
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers

Partial Class Reportes_frmRptConsolidadoDistribucionDetalle
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rpt/rptConsolidadoDistribucionDetalle.rpt")
        Dim lId As Integer = CType(Request.QueryString("id"), Integer)
        Reporte.Load(reportPath)


        ' mComponente.ObtenerDataSetDistribucion(Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, lId)
        Dim dsConsolidadoDistribucion = UACIHelpers.DetalleProcesoCompras.Obtener(Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, lId)
        Reporte.SetDataSource(dsConsolidadoDistribucion)

        'Dim dsCifrados = CifradoProductoSolicitud.ObtenerTodosConsolidados(Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, lId)
        'Reporte.Subreports("CifradosConsolidados.rpt").SetDataSource(dsCifrados)

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
