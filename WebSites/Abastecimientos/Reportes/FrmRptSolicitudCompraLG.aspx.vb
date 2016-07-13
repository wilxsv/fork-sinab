'INGRESO DE SOLICITUD DE COMPRAS
'CU-ESTA0001
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de solicitudes de compra

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmSolicitudCompraLG
    Inherits System.Web.UI.Page

    'declaracion e incializacion
    Private Reporte As ReportDocument

    Dim lId As Int64
    Dim McompFuenteFinanSolic As New cFUENTEFINANCIAMIENTOSOLICITUDES
    Dim ds As DataSet

    Private Sub ConfigureCrystalReports()
        'cargar reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptSolicitudCompraLG.rpt") 'nombre reporte
        Dim FuenteSolicitud As String = ""
        lId = Request.QueryString("IdSol")
        Dim sumi As String = Request.QueryString("Sumi")

        'determinacion de fuentes de financiamiento asociadas a la solicitud de compra
        ds = McompFuenteFinanSolic.ObtenerNombresFuenteFinanciamientoSolicitud(Session.Item("IdEstablecimiento"), lId)

        Dim r As DataRow

        For Each r In ds.Tables(0).Rows
            If ds.Tables(0).Rows.Count > 1 Then FuenteSolicitud = FuenteSolicitud & "/" & r("NOMBRE")
            If ds.Tables(0).Rows.Count = 1 Then FuenteSolicitud = FuenteSolicitud & r("NOMBRE")
        Next r

        Reporte.Load(reportPath) 'carga

        Dim mComponente As New cSOLICITUDES
        Dim mEntidad As New SOLICITUDES
        Dim DstrptSolicitudCompra As DataSet
        Dim mCompEntregas As New cENTREGASOLICITUDES
        Dim entregas As Integer

        'obtiene numero de entregas
        entregas = mCompEntregas.ObtenerNumeroEntregas(lId, Session.Item("IdEstablecimiento"))
        'llena dataset
        DstrptSolicitudCompra = mComponente.ObtenerDsSolicitud2(lId, Session.Item("IdEstablecimiento"))

        Reporte.SetDataSource(DstrptSolicitudCompra.Tables(0))
        'parametros como campos formula
        Reporte.DataDefinition.FormulaFields("Fuente").Text = "'" & FuenteSolicitud & "'"
        Reporte.DataDefinition.FormulaFields("EntregasSolicitud").Text = "'" & entregas & "'"
        Reporte.DataDefinition.FormulaFields("Sumi").Text = "'" & sumi & "'"

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
        'al incializar
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
