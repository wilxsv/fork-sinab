'REPORTES GERENCIALES DEL MODULO ESTABLECIMIENTOS
'CU-ESTA007
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de productos movimiento lento
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptEstProductosMovimientoLento
    Inherits System.Web.UI.Page

    'declaracion e inicializacion
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        'cargar reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptEstMovimientoLento.rpt") 'nombre reporte

        Reporte.Load(reportPath) 'cargar


        Dim mComponente As New cINVENTARIO
        Dim mEntidad As New INVENTARIO
        Dim dstrptMovimientoLento As DataSet

        Dim idZona As Int32 = CInt(Session.Item("RptZona")) 'identificador zona
        Dim idEstablecimiento As Int32 = CInt(Session.Item("RptEstab")) 'identificadro establecimiento
        Dim idProducto As Int32 = CInt(Session.Item("RptProducto")) 'identificador de producto
        Dim FechaReferencia As Date = CDate(Session.Item("RptFechaReferencia")).ToString("D") 'fecha de referencia
        Dim establecimientoGenerador As String = Session.Item("RptEstabGenerador") 'establecimineot generador
        Dim regionGenerador As String = Session.Item("RptRegionGenerador") 'region generadora
        Dim TipoEstablecimientoGenerador As String = Session.Item("RptTipoEstabGenerador") 'tipo establecimiento generador

        'llena dataset
        dstrptMovimientoLento = mComponente.DatasetProductosSinmovimientoSalida(idZona, idEstablecimiento, idProducto, FechaReferencia)
        Reporte.SetDataSource(dstrptMovimientoLento.Tables(0))
        'parametros del reporte como campo formula
        Reporte.DataDefinition.FormulaFields("FechaReferencia").Text = "'" & FechaReferencia.ToString("dd MMMM yyyy") & "'"
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
