Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptValeSalidaDependencia
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument

    Dim lIdMovimiento As Int64
    Dim lIdAlmacen As Int64
    Dim lAnio As Integer

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String

        lIdMovimiento = Request.QueryString("IdMovimiento")
        lIdAlmacen = Request.QueryString("IdAlmacen")
        lAnio = Request.QueryString("IdAnio")

        reportPath = Server.MapPath("RptValeSalidaDependencia.rpt")

        Reporte.Load(reportPath)

        Dim mCompMovimientos As New cMOVIMIENTOS

        Dim dsValeSalida As DataSet
        dsValeSalida = mCompMovimientos.ObtenerValeSalidaDS(lIdMovimiento, lIdAlmacen, lAnio)

        Reporte.SetDataSource(dsValeSalida.Tables(0))

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
