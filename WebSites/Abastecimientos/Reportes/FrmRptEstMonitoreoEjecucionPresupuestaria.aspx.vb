'REPORTES GERENCIALES DEL MODULO ESTABLECIMIENTOS
'CU-ESTA007
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de monitoreo presupuestario
'------------------------------------------
'es necesario conexion con SAFI
'--------------------------------------------
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptEstMonitoreoEjecucionPresupuestaria
    Inherits System.Web.UI.Page
    'declarar e inicializar
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        'carga de reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptEstMonitoreoEjecucionPresupuestaria.rpt") 'nombre reporte

        Reporte.Load(reportPath) 'carga


        Dim mComponente As New cINVENTARIO
        Dim mEntidad As New INVENTARIO
        Dim dstrptMonitoreoEjecucion As DataSet

        Dim idZona As Int32 = CInt(Session.Item("RptZona")) 'identificador zona
        Dim idEstablecimiento As Int32 = CInt(Session.Item("RptEstab")) 'identificador establecimiento
        Dim Año As Integer = CInt(Session.Item("RptAño")) 'año de ejecucion
        Dim establecimientoGenerador As String = Session.Item("RptEstabGenerador") 'establecimiento generador
        Dim regionGenerador As String = Session.Item("RptRegionGenerador") 'region generador

        'REEMPLAZAR DATASET UNA VEZ CONEXION SAFI---------------
        dstrptMonitoreoEjecucion = mComponente.DataSetReportesGerencialesEstablecimiento(idEstablecimiento)
        '------------------------------------

        Reporte.SetDataSource(dstrptMonitoreoEjecucion.Tables(0))

        Reporte.DataDefinition.FormulaFields("EstablecimientoGenerador").Text = "'" & establecimientoGenerador & "'"
        Reporte.DataDefinition.FormulaFields("RegionGenerador").Text = "'" & regionGenerador & "'"

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
        'al inicalizar
        ConfigureCrystalReports()

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
