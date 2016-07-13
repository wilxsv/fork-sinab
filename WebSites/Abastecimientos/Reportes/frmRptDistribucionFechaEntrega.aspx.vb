Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptDistribucionFechaEntrega
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        If Request.QueryString("id") Is Nothing Then 'Or Request.QueryString("tipo") Is Nothing Or Request.QueryString("est") Is Nothing Or Request.QueryString("prod") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        Dim idDistribucion As Integer = Request.QueryString("id")


        Reporte = New ReportDocument
        Dim reportPath As String
        reportPath = Server.MapPath("rptDistribucionFechaEntrega.rpt")
        Reporte.Load(reportPath)

        Dim x As New cDistribucion

        'Obtenemos el detalle del proceso de compras

        Dim ds As Data.DataSet

        ds = x.obtenerRptDistribucionFechaEntrega(idDistribucion, Session("IdEstablecimiento"))

        Reporte.SetDataSource(ds.Tables(0))

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
