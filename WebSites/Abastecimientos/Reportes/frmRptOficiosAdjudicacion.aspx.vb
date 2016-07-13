Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_frmRptOficiosAdjudicacion
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Dim paramField As New ParameterField()
    Dim paramFields As New ParameterFields()
    Dim discreteVal As New ParameterDiscreteValue()

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptOficiosAdjudicacion.rpt")
        Reporte.Load(reportPath)

    
        Dim IdEstablecimiento, idproveedor, idproceso As Integer
        IdEstablecimiento = Request.QueryString("IdEstablecimiento")
        idproveedor = Request.QueryString("Pr")
        idproceso = Request.QueryString("id")
        
        Dim mComAdjudicacion As New cADJUDICACION
        Dim dsAdjudicacion As Data.DataSet
        dsAdjudicacion = mComAdjudicacion.ObtenerRenglonesAdjudicadosOfiAdj(Session("IdEstablecimiento"), idproceso, idproveedor)

        Reporte.SetDataSource(dsAdjudicacion.Tables(0))

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

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
