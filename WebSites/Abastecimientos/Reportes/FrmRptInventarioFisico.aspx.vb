'INVENTARIO FISICO
'CU-ALMACEN012
'Ing. Yessenia Pennelope Henriquez Duran
'REPORTE PARA EL INVENTARIO FISICO DEL ESTABLECIMIENTO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptInventarioFisico
    Inherits System.Web.UI.Page

    'declaraciones e importaciones
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath("~/Reportes/RptInventarioFisico.rpt") 'nombre del reporte
        Reporte.Load(reportPath)

        Reporte.PrintOptions.PaperOrientation = PaperOrientation.Landscape

        Dim IDALMACEN, IDINVENTARIO As Int32
        IDALMACEN = Session.Item("IdAlmacen") 'identificador del almacen
        IDINVENTARIO = Request.QueryString.Item("IdI") 'identificador del inventario

        Dim cI As New cINVENTARIO
        Dim ds As Data.DataSet
        ds = cI.ObtenerDsReporteInventarioFisico(IDALMACEN, IDINVENTARIO)

        Reporte.SetDataSource(ds.Tables(0))
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
        'al iniciar
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
