Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.UACIHelpers
Imports SINAB_Utils

Partial Class Reportes_frmrptDatosVariablesPC
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptDatosVariablesBase.rpt")

        Reporte.Load(reportPath)

        Dim IDPROCESOCOMPRA As Integer
        Dim usr = Membresia.ObtenerUsuario()

        IDPROCESOCOMPRA = Session("IdProcesoCompra")

        'Dim mComponente As New cPROCESOCOMPRAS
        'Dim ds As Data.DataSet
        'ds = mComponente.ObtenerProcesoCompraDV(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        'Reporte.SetDataSource(ds.Tables(0))
        'Me.crvPrincipal.ReportSource = Reporte

        Dim ds = ProcesoCompras.ObtenerTodosFrm(usr.ESTABLECIMIENTO.IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Reporte.SetDataSource(ds)
        Me.crvPrincipal.ReportSource = Reporte

        Me.crvPrincipal.DisplayGroupTree = False
        Me.crvPrincipal.DisplayToolbar = True
        Me.crvPrincipal.EnableDrillDown = False
        Me.crvPrincipal.EnableDatabaseLogonPrompt = False
        Me.crvPrincipal.EnableParameterPrompt = False
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
