Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils

Partial Class Reportes_frmRptConsolidadoDistribucion1
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument
    Dim lId As Integer


    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("~/Reportes/rpt/ConsolidadoDistribucion.rpt")
        lId = CType(Request.QueryString("id"), Integer)
        Reporte.Load(reportPath)



        'Dim mComponente As New cNECESIDADESSOLICITUD
        'Dim mEntidad As New NECESIDADESSOLICITUD

        ' Dim dsConsolidadoDistribucion As DataSet
        ' dsConsolidadoDistribucion = mComponente.ObtenerDataSetDistribucion(Session.Item("IdEstablecimiento"), lId)
        Dim res = EstablecimientoHelpers.AlmacenesEntregaSolicitud.ObtenerReporteNoConsolidado(lId, Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO)
        Reporte.SetDataSource(res)

        
        'paramField.CurrentValues.Add(discreteVal)
        Dim dv2 = New ParameterDiscreteValue()
        Dim usr = Membresia.ObtenerUsuario()
        dv2.Value = usr.Establecimiento.NOMBRE + " - " + usr.Dependencia.NOMBRE
        Reporte.SetParameterValue(0, dv2)
        '  Reporte.SetParameterValue(1, dv2)
        Me.crvPrincipal.ReportSource = Reporte

        ' Reporte.SetParameterValue("LogoSrc", Server.MapPath(Config.LogoUrl))
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
