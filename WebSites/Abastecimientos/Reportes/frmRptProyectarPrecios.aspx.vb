Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptProyectarPrecios
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfiguraReporte()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptProyectarPrecios.rpt")
        Dim IDPRODUCTO As Int64
        IDPRODUCTO = Request.QueryString("IdPro")
        Reporte.Load(reportPath)

        Dim mComponente As New cHISTORICOPRECIOS
        Dim dsProyectarPrecios As DataSet

        dsProyectarPrecios = mComponente.ObtenerHistorialProducto(IDPRODUCTO)

        Reporte.SetDataSource(dsProyectarPrecios.Tables(0))
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
        ConfiguraReporte()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
