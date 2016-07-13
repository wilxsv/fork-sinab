'Notificar incumplimientos de documentacion
'CU-UACI011
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte con la documentacion no presentada por el renglon

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Reportes_FrmRptDocumentacionFaltanteRenglon
    Inherits System.Web.UI.Page
    'inicializar y declaraciones
    Private Reporte As ReportDocument
    Dim lId As Int64
    Dim lIdProv As Int32
    Private Sub ConfigureCrystalReports()
        'al cargar reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptNotificacionDocumentacionFaltanteRenglon.rpt") 'nombre reporte
        Dim idrectec As Integer
        idrectec = Request.QueryString("IDRECTEC")

        lId = Session.Item("id") 'identificador de proceso
        lIdProv = Session.Item("idProv") 'identificador de proveedor

        Reporte.Load(reportPath) 'carga


        Dim mComponente As New cNOTASINCUMPLIMIENTO
        Dim mEntidad As New NOTASINCUMPLIMIENTO
        Dim DstrptDocumentacionFaltanteRenglon As DataSet

        'llena dataset
        DstrptDocumentacionFaltanteRenglon = mComponente.DataSetDocumentacionFaltanteRenglon(Session.Item("IdEstablecimiento"), lId, lIdProv, idrectec)
        Reporte.SetDataSource(DstrptDocumentacionFaltanteRenglon.Tables(0))
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
