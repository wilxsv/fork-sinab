'REPORTES DEL MODULO ESTABLECIMIENTOS
'CU-ESTA006
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de medicamentos consumidos por servicio hospitalario

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptProductosConsumidosSHosp
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        'carga de reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptProductosConsumidosSHosp.rpt") 'nombre de reporte
        Reporte.Load(reportPath) 'carga


        Dim mComponente As New cRECETAS
        Dim mEntidad As New RECETAS
        Dim DstrptProductosConsumidosSHosp As DataSet

        Dim idEstablecimiento As Int32 = CInt(Session.Item("RptEstab")) 'identificador de establecimiento
        Dim idServicio As Int32 = CInt(Session.Item("RptServicio")) 'identificador de servicio hospitalario
        Dim FechaInicio As Date = CDate(Session.Item("RptFechaInicio")).ToString("D") 'fecha de inicio
        Dim FechaFin As Date = CDate(Session.Item("RptFechaFin")).ToString("D") 'fecha fin

        Dim establecimientoGenerador As String = Session.Item("RptEstabGenerador") 'establecimietno generador
        Dim regionGenerador As String = Session.Item("RptRegionGenerador") 'region generadora

        'llena dataset
        DstrptProductosConsumidosSHosp = mComponente.DDataSetRecetaXServicioHosp(idEstablecimiento, idServicio, FechaInicio, FechaFin)
        Reporte.SetDataSource(DstrptProductosConsumidosSHosp.Tables(0))

        'parametros como campos de formula
        Reporte.DataDefinition.FormulaFields("PFechaInicio").Text = "'" & FechaInicio.ToString("dd MMMM yyyy") & "'"
        Reporte.DataDefinition.FormulaFields("PFechaFin").Text = "'" & FechaFin.ToString("dd MMMM yyyy") & "'"

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
