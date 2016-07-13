'REPORTES GERENCIALES DEL MODULO ESTABLECIMIENTOS
'CU-ESTA007
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de compras en transito
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptComprasTransito
    Inherits System.Web.UI.Page

    'inicializar y declarar
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptEstComprasTransito.rpt") 'nombre de reporte

        Reporte.Load(reportPath) 'carga


        Dim mComponente As New cINVENTARIO
        Dim mEntidad As New INVENTARIO
        Dim dstrptComprasTransito As DataSet

        Dim idZona As Int32 = CInt(Session.Item("RptZona")) 'identificador de zona o region
        Dim idEstablecimiento As Int32 = CInt(Session.Item("RptEstab")) 'identificador de establecimiento
        Dim idProducto As Int32 = CInt(Session.Item("RptProducto")) 'identificador de producto
        Dim idProveedor As Int32 = CInt(Session.Item("RptProveedor")) 'identificador de proveedor
        Dim establecimientoGenerador As String = Session.Item("RptEstabGenerador") 'establecimiento que genero el reporte
        Dim regionGenerador As String = Session.Item("RptRegionGenerador") 'region que genero reporte
        Dim TipoEstablecimientoGenerador As String = Session.Item("RptTipoEstabGenerador") 'tipo de establecimiento generador

        'llena dataset
        dstrptComprasTransito = mComponente.RptGerencialesEstablecimientoComprasTransito(idZona, idEstablecimiento, idProveedor, idProducto)
        Reporte.SetDataSource(dstrptComprasTransito.Tables(0))
        Reporte.DataDefinition.FormulaFields("EstablecimientoGenerador").Text = "'" & establecimientoGenerador & "'"
        Reporte.DataDefinition.FormulaFields("RegionGenerador").Text = "'" & regionGenerador & "'"
        Reporte.DataDefinition.FormulaFields("TipoEstablecimientoGenerador").Text = "'" & TipoEstablecimientoGenerador & "'"

        'muestra repoprte
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
        'al cerrar la pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
