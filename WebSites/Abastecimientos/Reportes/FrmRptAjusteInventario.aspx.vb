'INVENTARIO FISICO
'CU-ALMACEN012
'Ing. Yessenia Pennelope Henriquez Duran
'REPORTE PARA EL INVENTARIO FISICO DEL ESTABLECIMIENTO

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Reportes_FrmRptAjusteInventario
    Inherits System.Web.UI.Page
    'DECLARAR E INICIALIZAR
    Private Reporte As ReportDocument


    Private Sub ConfigureCrystalReports()
        'configuracion inicial de cristal report
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptAjusteInventario.rpt") 'nombre reporte

        Dim idAlmacen As Int32 = CInt(Session.Item("RptAlmacen")) 'identificador de almacen
        Dim idInventario As Int32 = CInt(Session.Item("RptInventario")) 'identificador de inventario
        Dim idDetalle As Int32 = CInt(Session.Item("RptDetalle")) 'identificador del renglon de inventario a ajustar

        Dim Vencidos As Boolean = Session.Item("RptVencidos") 'mostrar vencidos
        Dim NoDisponibles As Boolean = Session.Item("RptNoDisponibles") 'mostrar no disponibles

        Reporte.Load(reportPath) 'carga reporte

        Dim mComponente As New cINVENTARIO
        Dim mEntidad As New INVENTARIO
        Dim DstrptAjusteInventario As DataSet
        'carga dataset con informacion del reporte
        DstrptAjusteInventario = mComponente.obtenerDsReporteAjusteInventario(idAlmacen, idInventario, idDetalle)
        Reporte.SetDataSource(DstrptAjusteInventario.Tables(0))
        'parametros de reporte como campos formula
        Reporte.DataDefinition.FormulaFields("MostrarVencidos").Text = "'" & Vencidos & "'"
        Reporte.DataDefinition.FormulaFields("MostrarNoDisponibles").Text = "'" & NoDisponibles & "'"
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
        'al iniciar
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar la pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
