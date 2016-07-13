'Notificar incumplimientos de documentacion
'CU-UACI011
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte con la documentacion no presentada por el ofertante

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Reportes_FrmRptDocumentacionFaltanteOfertante
    Inherits System.Web.UI.Page
    'declaracion e inicializacion
    Private Reporte As ReportDocument
    Dim lId As Int64
    Dim lIdProv As Int32

    Private Sub ConfigureCrystalReports()
        'carga de reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptNotificacionDocumentacionFaltanteOfertante.rpt") 'nombre reporte
        lId = Session.Item("id") 'identificador proceso de compra
        lIdProv = Session.Item("idProv") 'identificador de proveedor


        Reporte.Load(reportPath) 'carga reporte


        Dim mComponente As New cNOTASINCUMPLIMIENTO
        Dim mEntidad As New NOTASINCUMPLIMIENTO
        Dim DstrptDocumentacionFaltanteOfertante As DataSet

        'carga dataset
        DstrptDocumentacionFaltanteOfertante = mComponente.DataSetDocumentacionFaltanteOfertante(Session.Item("IdEstablecimiento"), lId, lIdProv)
        Reporte.SetDataSource(DstrptDocumentacionFaltanteOfertante.Tables(0))
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
        'al inicalizar
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
