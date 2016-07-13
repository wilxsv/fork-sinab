
Imports CrystalDecisions.CrystalReports.Engine
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.ApplicationBlocks.Data
Imports SINAB_Entidades.Helpers.UACIHelpers

Partial Class Reportes_temporal
    Inherits System.Web.UI.Page


    Private Reporte As ReportDocument

    Private Sub ConfiguracionReporte()
        Dim idestablecimiento, idprocesocompra As Decimal

        idestablecimiento = CType(Request.QueryString("idE"), Decimal)
        idprocesocompra = CType(Request.QueryString("idPC"), Decimal)




        Reporte = New ReportDocument
        Dim reportPath = Server.MapPath("rpt/SubRptResolucionAdjudicacion.rpt")
        Reporte.Load(reportPath)

        Dim ds = DetalleProcesoCompras.ObtenerSubReporte(idestablecimiento, idprocesocompra)

        Reporte.SetDataSource(ds)
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
