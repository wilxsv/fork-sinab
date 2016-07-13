'CALCULO DE NECESIDADES ESTABLECIMIENTO
'CU-ESTA0003
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de programa de compras
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Reportes_FrmRptNecesidades
    Inherits System.Web.UI.Page
    'declaracion e incializacion
    Private Reporte As ReportDocument
    Dim lId As Int64

    Private Sub ConfigureCrystalReports()
        'carga de reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptNecesidad.rpt") 'nombre de rerporte
        lId = Session.Item("idDocRep") 'identificador de programa de compras
        Reporte.Load(reportPath) 'carga


        Dim mComponente As New cNECESIDADESTABLECIMIENTOS
        Dim mEntidad As New NECESIDADESTABLECIMIENTOS
        Dim DstrptNecesidades As DataSet

        'llena dataset
        DstrptNecesidades = mComponente.ObtenerDsNecesidad(Session.Item("IdEstablecimiento"), lId)

        Reporte.SetDataSource(DstrptNecesidades.Tables(0))
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
