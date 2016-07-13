'CONSULTAR PROGRAMAS DE EJECUCUION PRESUPUESTARIA
'CU-UFI002
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte consulta PEP
'------------------------------------------
'es encesario conexion con SAFI
'-------------------------------------------
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptUfiConsultaPEP
    Inherits System.Web.UI.Page

    'declaracion e inicializacion
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        'cargar reporte

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptUfiDistribucionPresupuestaria.rpt") 'nombre de reporte

        Reporte.Load(reportPath)
        '------------------------------------------------------------------
        'REEMPLAZAR UNA VEZ CONEXION SAFI-------------
        Dim mComponente As New cINVENTARIO
        Dim mEntidad As New INVENTARIO
        '-------------
        Dim dstrptConsultPEP As DataSet

        Dim idZona As Int32 = CInt(Session.Item("RptZona")) 'identificador de zona
        Dim idEstablecimiento As Int32 = CInt(Session.Item("RptEstab")) 'identificador de establecimiento
        Dim Año As Integer = CInt(Session.Item("RptAño")) 'ejercicio

        Dim establecimientoGenerador As String = Session.Item("RptEstabGenerador") 'estabelcimiento generador
        Dim regionGenerador As String = Session.Item("RptRegionGenerador") 'region generador
        '-----------------------------------------------------------
        'REEMPLAZAR DATASET UNA VEZ CONEXION SAFI-------------
        dstrptConsultPEP = mComponente.DataSetReportesGerencialesEstablecimiento(idEstablecimiento)
        '-------------
        Reporte.SetDataSource(dstrptConsultPEP.Tables(0))
        'parametros como campos formula
        Reporte.DataDefinition.FormulaFields("EstablecimientoGenerador").Text = "'" & establecimientoGenerador & "'"
        Reporte.DataDefinition.FormulaFields("RegionGenerador").Text = "'" & regionGenerador & "'"
        'muestra reporte
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
        'al inicializar
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
