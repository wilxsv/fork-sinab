'REPORTES DEL MODULO UFI
'CU-UFI003
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de distribucion presupuestaria
'--------------------------------------------------------------------------
'Este formulario hace uso de la conexion con el SAFI para su funcionamiento
'------------------------------------------------------------------------------
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptUfiDistribucionPresupuestaria
    Inherits System.Web.UI.Page

    'Declaracion e incializacion
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptUfiDistribucionPresupuestaria.rpt") 'nombre reporte

        Reporte.Load(reportPath) 'cargar¿
        '-------------------------------------------------------------
        'REEMPLAZAR UNA VEZ CONEXION SAFI-------------
        Dim mComponente As New cINVENTARIO
        Dim mEntidad As New INVENTARIO
        '-------------
        'llena dataset
        Dim dstrptDistribucionPresupuestaria As DataSet

        Dim idZona As Int32 = CInt(Session.Item("RptZona")) 'identificadro de zona
        Dim idEstablecimiento As Int32 = CInt(Session.Item("RptEstab")) 'identificador de establecimiento
        Dim Año As Integer = CInt(Session.Item("RptAño")) 'ejercicio
        Dim idProveedor As Int32 = CInt(Session.Item("RptProveedor")) 'identificador proveedor


        Dim establecimientoGenerador As String = Session.Item("RptEstabGenerador") 'establecimiento generador
        Dim regionGenerador As String = Session.Item("RptRegionGenerador") 'region generador

        'llena datset
        '--------------------------------------------------------------
        'REEMPLAZAR DATASET UNA VEZ CONEXION SAFI-------------
        dstrptDistribucionPresupuestaria = mComponente.DataSetReportesGerencialesEstablecimiento(idEstablecimiento)
        '-------------
        Reporte.SetDataSource(dstrptDistribucionPresupuestaria.Tables(0))
        'parametros como campo formula
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
        'al inicializar
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
