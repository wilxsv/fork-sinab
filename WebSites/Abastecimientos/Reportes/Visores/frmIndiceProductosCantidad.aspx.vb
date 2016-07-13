Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_VisorReporte
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument
    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("~/Reportes/rpt/rptProveedoresEstablecimientoEntregaProductos.rpt")
        Reporte.Load(reportPath)

        Dim IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDALMACEN, IDCONTRATO As Integer
        Dim suprimirSeccion As Boolean = True
        IDPROVEEDOR = Request.QueryString("IDP")
        IDPROCESOCOMPRA = Request.QueryString("IDPC")
        IDESTABLECIMIENTO = Request.QueryString("IDE")
        IDALMACEN = Request.QueryString("IDA")
        IDCONTRATO = Request.QueryString("IDC")
        'Response.Write("<BR>PROVEEDOR: " & IDPROVEEDOR)
        'Response.Write("<BR>IdProcesoCompra: " & IdProcesoCompra)
        'Response.Write("<BR>IDESTABLECIMIENTO: " & IDESTABLECIMIENTO)
        'Response.Write("<BR>IDALMACEN: " & IDALMACEN)

        Try
            suprimirSeccion = CBool(Request.QueryString("MUT"))
        Catch ex As Exception
            suprimirSeccion = False
        End Try
        Dim cDM As New cIndices
        Dim id As String = 619 ' Session("idEstablecimiento")
        Dim ds As Data.DataSet
        'ds = cDM.ObtenerDataSetPorProducto(IDESTABLECIMIENTO, IdProcesoCompra, IDPROVEEDOR, IDALMACEN, IDCONTRATO)
        ' ds = cDM.ObtenerDataSetPorProducto(619, 27, -1, 0, 1)
        '' ROBINSON RUIZ

        'Dim logo As New cLogo
        'Dim dtlogo As New Data.DataTable
        'dtlogo = logo.ObtenerDataSetPorId(id).Tables(0).Copy
        'ds.Tables.Add(dtlogo)

        '' ROBINSON RUIZ
        'Reporte.SetDataSource(ds.Tables("GetLogo"))
        'Reporte.Subreports(0).SetDataSource(ds.Tables(0))

        '' FIN CAMBIO DE REPORTE
        ' For i As Integer = 5 To Reporte.Subreports(0).ReportDefinition.Sections.Count - 1
        'Response.Write("Suprimir seccion: " & suprimirSeccion)
        'Response.End()
        'Reporte.Subreports(0).ReportDefinition.Sections("Titulos").SectionFormat.EnableSuppress = suprimirSeccion
        'Reporte.Subreports(0).ReportDefinition.Sections("Detalle").SectionFormat.EnableSuppress = suprimirSeccion
        'If Not IDPROVEEDOR = -1 Then
        '    Reporte.Subreports(0).ReportDefinition.Sections("INFOPRV").SectionFormat.EnableSuppress = True
        'Else
        '    Reporte.Subreports(0).ReportDefinition.Sections("INFOPRV").SectionFormat.EnableSuppress = False
        'End If
        'Next
        'For i As Integer = 0 To Reporte.Subreports(0).ReportDefinition.Sections.Count - 1
        '    Response.Write(Reporte.Subreports(0).ReportDefinition.Sections(i).Name & "</br>")
        'Next
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
