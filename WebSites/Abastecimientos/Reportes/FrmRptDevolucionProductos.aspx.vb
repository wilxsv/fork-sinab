Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_frmRptDevolucionProductos
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument
    Dim lEstablecimiento As Int32
    Dim lTipoMovimiento As Int16
    Dim lMovimiento As Int64

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptDevolucionProductos.rpt")
        lEstablecimiento = Session.Item("IdEstablecimiento")
        lTipoMovimiento = 3
        lMovimiento = Request.QueryString("IdMovimiento")
        Reporte.Load(reportPath)

        Dim mComponente As New cMOVIMIENTOS

        Dim dsPrincipal As DataSet
        dsPrincipal = mComponente.ObtenerMovimientosDetalleLoteDS(lEstablecimiento, lTipoMovimiento, lMovimiento, 0, 0, 0, 2)

        Reporte.SetDataSource(dsPrincipal.Tables(0))

        Dim mCompValeSalida As New cVALESSALIDA
        Dim dsVale As Data.DataSet

        If dsPrincipal.Tables(0).Rows.Count > 0 Then
            dsVale = mCompValeSalida.ObtenerDataSetPorId(dsPrincipal.Tables(0).Rows(0).Item("IDALMACEN"), dsPrincipal.Tables(0).Rows(0).Item("IDDOCUMENTO"), dsPrincipal.Tables(0).Rows(0).Item("ANIO"))
            If dsVale.Tables(0).Rows.Count > 0 Then
                Reporte.DataDefinition.FormulaFields(0).Text = dsVale.Tables(0).Rows(0).Item("OBSERVACION")
            End If
        End If

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
