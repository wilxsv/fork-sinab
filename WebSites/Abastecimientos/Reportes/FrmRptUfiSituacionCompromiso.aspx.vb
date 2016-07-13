Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptUfiSituacionCompromiso
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptUfiSituacionCompromiso.rpt")

        Reporte.Load(reportPath)

        'REEMPLAZAR UNA VEZ CONEXION SAFI-------------
        Dim mComponente As New cINVENTARIO
        Dim mEntidad As New INVENTARIO
        '-------------

        Dim dstrptSituacionCompromisos As DataSet

        Dim idZona As Int32 = CInt(Session.Item("RptZona"))
        Dim idEstablecimiento As Int32 = CInt(Session.Item("RptEstab"))
        Dim FechaReferencia As Date = CDate(Session.Item("RptFechaReferencia")).ToString("D")
        Dim establecimientoGenerador As String = Session.Item("RptEstabGenerador")
        Dim regionGenerador As String = Session.Item("RptRegionGenerador")

        'REEMPLAZAR DATASET UNA VEZ CONEXION SAFI-------------
        dstrptSituacionCompromisos = mComponente.DataSetReportesGerencialesEstablecimiento(idEstablecimiento)
        '-------------

        Reporte.SetDataSource(dstrptSituacionCompromisos.Tables(0))

        Reporte.DataDefinition.FormulaFields("FechaReferencia").Text = "'" & FechaReferencia.ToString("dd MMMM yyyy") & "'"
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
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
