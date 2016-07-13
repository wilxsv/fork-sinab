'Notificar incumplimientos de documentacion
'CU-UACI011
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte con la documentacion no presentada por el ofertante
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptDocumentacionFaltanteOfertanteTodas
    Inherits System.Web.UI.Page

    'declaracion e inicializacion
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        'carga de reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptNotificacionDocumentacionFaltanteOfertanteTodas.rpt") 'nombre reporte
        Reporte.Load(reportPath) 'carga reporte

        Dim IDPROCESOCOMPRA As Integer
        IDPROCESOCOMPRA = Request.QueryString("id") 'identificador proceso de compra

        Dim mComponente As New cNOTASINCUMPLIMIENTO

        Dim ds As DataSet
        'carga dataset
        ds = mComponente.DataSetDocumentacionFaltanteOfertante(Session.Item("IdEstablecimiento"), IDPROCESOCOMPRA)

        Reporte.SetDataSource(ds.Tables(0))

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
