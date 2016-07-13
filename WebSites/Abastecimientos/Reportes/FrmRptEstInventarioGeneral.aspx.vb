'REPORTES GERENCIALES DEL MODULO ESTABLECIMIENTOS
'CU-ESTA007
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de inventario general
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmEstReporteGeneralInventario
    Inherits System.Web.UI.Page

    'declaraciones e inicializaciones
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        'al cargar reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptEstInventarioGeneral.rpt") 'nombre reporte

        Reporte.Load(reportPath) 'carga


        Dim mComponente As New cINVENTARIO
        Dim mEntidad As New INVENTARIO
        Dim dstrptInventarioGeneral As DataSet

        Dim idZona As Int32 = CInt(Session.Item("RptZona")) 'identificador zona
        Dim idEstablecimiento As Int32 = CInt(Session.Item("RptEstab")) 'identificador de establecimiento
        Dim idProducto As Int32 = CInt(Session.Item("RptProducto")) 'identificador de producto
        Dim establecimientoGenerador As String = Session.Item("RptEstabGenerador") 'establecimiento generador
        Dim regionGenerador As String = Session.Item("RptRegionGenerador") 'region generador


        'llena dataset
        dstrptInventarioGeneral = mComponente.DataSetReptsGerencialesEstablecimientoInventario(idZona, idEstablecimiento, idProducto)
        Reporte.SetDataSource(dstrptInventarioGeneral.Tables(0))
        'parametros de reporte como campos formula
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
        'al cerra pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
