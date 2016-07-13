Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptProgramacionEntregasalaFecha
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath("~/Reportes/RptProgramacionEntregaalaFecha.rpt")
        Reporte.Load(reportPath)

        Dim IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDALMACENENTREGA As Integer

        IDESTABLECIMIENTO = Request.QueryString("IdE")
        IDPROVEEDOR = Request.QueryString("IdP")
        IDCONTRATO = Request.QueryString("IdC")
        IDALMACENENTREGA = Request.QueryString("IdA")

        Dim cC As New cCONTRATOS

        Dim ds As Data.DataSet
        Dim dt1, dt2, dt3 As Data.DataTable

        ds = cC.ObtenerDatasetRptEncabezadoContratosOtrosDoc(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

        dt1 = cC.ObtenerDatasetRenglonesContratoOtrosDoc3(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDALMACENENTREGA).Tables(0).Copy
        dt1.TableName = "Renglones"
        ds.Tables.Add(dt1)

        Dim dsr As Data.DataSet
        dsr = cC.ObtenerEntregasProgramadas(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, , IDALMACENENTREGA)

        dt2 = dsr.Tables(0).Copy
        dt2.TableName = "EntregasProgramadas"
        ds.Tables.Add(dt2)

        dt3 = cC.ObtenerDetalleEntregasContratoRenglon2(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDALMACENENTREGA, dsr).Tables(0).Copy
        dt3.TableName = "Recepciones"
        ds.Tables.Add(dt3)

        ds.Tables(0).TableName = "EncabezadoDocumento"
        ds.Tables(1).TableName = "Renglones"
        ds.Tables(2).TableName = "EntregasProgramadas"
        ds.Tables(3).TableName = "Recepciones"
        Reporte.SetDataSource(ds)

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
