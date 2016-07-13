Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers

Partial Class Reportes_frmRptConsolidadoDistribucion02
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument

    'Dim paramField As New ParameterField()
    'Dim paramFields As New ParameterFields()
    'Dim discreteVal As New ParameterDiscreteValue()

    Dim lId As Int64



    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("~/Reportes/rpt/ConsolidadoDistribucionProducto.rpt")
        lId = CType(Request.QueryString("id"), Long)
        Reporte.Load(reportPath)

        Dim res = EstablecimientoHelpers.AlmacenesEntregaSolicitud.ObtenerReporteConsolidado(lId, Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO)
        Reporte.SetDataSource(res)

        Dim dv2 = New ParameterDiscreteValue()
        Dim usr = Membresia.ObtenerUsuario()
        dv2.Value = usr.Establecimiento.NOMBRE + " - " + usr.Dependencia.NOMBRE
        Reporte.SetParameterValue(0, dv2)

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
