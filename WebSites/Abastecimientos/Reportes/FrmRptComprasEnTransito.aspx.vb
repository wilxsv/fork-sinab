Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class frmRptComprasEnTransito
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument

    Dim paramField As New ParameterField()
    Dim paramFields As New ParameterFields()
    Dim discreteVal As New ParameterDiscreteValue()

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptComprasEnTransito.rpt")
        Reporte.Load(reportPath)

        Dim IdSuministro As Integer
        Dim idGrupo As Integer
        Dim idSubGrupo As Integer
        Dim idProducto As Integer
        Dim idRegion As Integer
        Dim IdEstablecimiento As Integer
        Dim TipoInsumo, FGeo As String

        IdSuministro = Request.QueryString("IdSuministro")
        idGrupo = Request.QueryString("idGrupo")
        idSubGrupo = Request.QueryString("idSubGrupo")
        idProducto = Request.QueryString("idProducto")
        idRegion = Request.QueryString("idRegion")
        IdEstablecimiento = Request.QueryString("IdEstablecimiento")
        TipoInsumo = Request.QueryString("TipoInsumo")
        FGeo = Request.QueryString("FGeo")

        Dim cDC As New cALMACENESENTREGACONTRATOS

        Dim ds As Data.DataSet
        ds = cDC.RptComprasEnTransito(IdEstablecimiento, idRegion, IdSuministro, idGrupo, idSubGrupo, idProducto)

        Reporte.SetDataSource(ds.Tables(0))

        Reporte.DataDefinition.FormulaFields(0).Text = "'" & TipoInsumo & "'"
        Reporte.DataDefinition.FormulaFields(1).Text = "'" & FGeo & "'"


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
