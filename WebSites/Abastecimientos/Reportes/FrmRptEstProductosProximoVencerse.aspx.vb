'REPORTES GERENCIALES DEL MODULO ESTABLECIMIENTOS
'CU-ESTA007
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de productos proximos a vencerse
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmEstProductosProximoVencerse
    Inherits System.Web.UI.Page

    'inicilaizar y declarar
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        'carga de reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptEstProductosProximosVencerse.rpt") 'nombre de reporte

        Reporte.Load(reportPath) 'carga


        Dim mComponente As New cINVENTARIO
        Dim mEntidad As New INVENTARIO
        Dim dstrptMovimientoLento As DataSet

        Dim idZona As Int32 = CInt(Session.Item("RptZona")) 'identificador de zona
        Dim idEstablecimiento As Int32 = CInt(Session.Item("RptEstab")) 'identificador de establecimiento
        Dim FechaReferencia As Date = CDate(Session.Item("RptFechaReferencia")).ToString("D") 'fecha de referencia
        Dim operador As String = (Session.Item("RptOperador")) ' operador
        Dim establecimientoGenerador As String = Session.Item("RptEstabGenerador") 'establecimiento generador
        Dim regionGenerador As String = Session.Item("RptRegionGenerador") 'region generador
        Dim TipoEstablecimientoGenerador As String = Session.Item("RptTipoEstabGenerador") 'tipo establecimiento generador

        'llenar dataset
        dstrptMovimientoLento = mComponente.DataSetReportesGerencialesEstablecimiento(idZona, idEstablecimiento, 0, FechaReferencia, operador)
        Reporte.SetDataSource(dstrptMovimientoLento.Tables(0))
        'parametros como campos formula
        Reporte.DataDefinition.FormulaFields("FechaReferencia").Text = "'" & FechaReferencia.ToString("dd MMMM yyyy") & "'"
        Reporte.DataDefinition.FormulaFields("OperadorVencimiento").Text = "'" & operador & "'"
        Reporte.DataDefinition.FormulaFields("EstablecimientoGenerador").Text = "'" & establecimientoGenerador & "'"
        Reporte.DataDefinition.FormulaFields("RegionGenerador").Text = "'" & regionGenerador & "'"
        Reporte.DataDefinition.FormulaFields("TipoEstablecimientoGenerador").Text = "'" & TipoEstablecimientoGenerador & "'"
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
