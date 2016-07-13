Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptExistencias
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptExistencias.rpt")
        Reporte.Load(reportPath)

        Dim IDSUMINISTRO, IDGRUPO, IDSUBGRUPO, IDPRODUCTO As Integer
        Dim IDREGION, IDESTABLECIMIENTO As Integer
        Dim TipoInsumo, FGeo As String

        IDSUMINISTRO = Request.QueryString("idS")
        IDGRUPO = Request.QueryString("idG")
        IDSUBGRUPO = Request.QueryString("idSG")
        IDPRODUCTO = Request.QueryString("idP")
        IDREGION = Request.QueryString("idR")
        IDESTABLECIMIENTO = Request.QueryString("idE")
        TipoInsumo = Request.QueryString("TI")
        FGeo = Request.QueryString("FG")

        Dim cL As New cLOTES

        Dim ds As Data.DataSet
        ds = cL.RptExistencias(IDESTABLECIMIENTO, IDREGION, IDSUMINISTRO, IDGRUPO, IDSUBGRUPO, IDPRODUCTO)

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
