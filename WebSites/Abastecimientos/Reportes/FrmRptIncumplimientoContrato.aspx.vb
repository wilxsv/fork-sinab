'Comunicar incumplimientos de contrato
'CU-UACI023
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de incumplimiento de contrato

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Reportes_RptIncumplimientoContrato
    Inherits System.Web.UI.Page
    'declaracion e inicializacion
    Private Reporte As ReportDocument
    Dim lId As Int64
    Dim lIdProv As Int32
    Dim lidProc As Int32
    Dim lopc As String
    Dim ldst As DataSet
    Dim lEntidad As New INCUMPLIMIENTOCONTRATO

    Private Sub ConfigureCrystalReports()
        'carga de reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptIncumplimientoContrato.rpt") 'nombre reporte

        lId = Session.Item("idContRep") 'identificador de contrato
        lIdProv = Session.Item("idProvRep") 'identificador de proveedor
        lidProc = Session.Item("idProceso") 'identificador de proceso de compra
        lopc = Session.Item("opc") 'Opcion cantidades : 1-no entregadas, 2-conatraso
        ldst = Session.Item("DataSetRep")

        Reporte.Load(reportPath) 'carga

        Dim mComponente As New cNOTASINCUMPLIMIENTOCONTRATO
        Dim mEntidad As New NOTASINCUMPLIMIENTOCONTRATO
        Dim DstrptIncumplimientoContrato As New DataSet
        'llena dataset

        DstrptIncumplimientoContrato = ldst
        Reporte.SetDataSource(DstrptIncumplimientoContrato.Tables(0))
        Reporte.DataDefinition.FormulaFields("Opcion").Text = "'" & lopc & "'"
        'muestra reprote
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
