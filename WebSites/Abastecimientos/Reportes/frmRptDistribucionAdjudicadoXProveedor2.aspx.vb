Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_frmRptDistribucionAdjudicadoXProveedor2
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Dim lId As Int64
    Dim lPr As Int64

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptDistribucionAdjudicadoXProveedor2.rpt")
        lId = Request.QueryString("id")
        lPr = Request.QueryString("Pr")
        Reporte.Load(reportPath)

        Dim tbl As New DataTable
        Dim col As New DataColumn

        '1
        col = New DataColumn("descripcion", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '2
        col = New DataColumn("CodigoLicitacion", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '3
        col = New DataColumn("TituloLicitacion", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '4
        col = New DataColumn("DescripcionLicitacion", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '5
        col = New DataColumn("IDDETALLE", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '6
        col = New DataColumn("Renglon", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '7
        col = New DataColumn("Nombre", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '8
        col = New DataColumn("CantidadFirme", System.Type.GetType("System.Int64"))
        tbl.Columns.Add(col)
        '9
        col = New DataColumn("IdAlmacen", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '10
        col = New DataColumn("Almacen", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '11
        col = New DataColumn("IdEntrega", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '12
        col = New DataColumn("Cantidad", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '13
        col = New DataColumn("Dias", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '14
        col = New DataColumn("Porcentaje", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)

        '15
        col = New DataColumn("IdFuenteFinanciamiento", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)

        '16
        col = New DataColumn("nombrefuentefinanciamiento", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)

        Dim m1 As New cPROCESOCOMPRAS
        Dim ds1 As New Data.DataSet

        m1.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), lId, ds1)

        Dim m2 As New cENTREGAADJUDICACION
        Dim m3 As New cALMACENESENTREGAADJUDICACION
        Dim ds2 As Data.DataSet
        Dim ds3 As Data.DataSet
        Dim ds4 As Data.DataSet

        ds2 = m2.obtenerRenglosAdjudicados(Session("IdEstablecimiento"), lId, lPr)

        Dim V1, V2, V5 As Integer
        Dim v4 As Decimal
        Dim v3, v6 As String
        For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1

            V1 = ds2.Tables(0).Rows(i).Item("IDDETALLE")
            V2 = ds2.Tables(0).Rows(i).Item("RENGLON")
            v3 = ds2.Tables(0).Rows(i).Item("NOMBRE")
            v4 = ds2.Tables(0).Rows(i).Item("CANTIDADFIRME")

            ds3 = m3.obtenerAlmacenesAdjudicacion(Session("IdEstablecimiento"), lId, lPr, ds2.Tables(0).Rows(i).Item("IDDETALLE"))

            For j As Integer = 0 To ds3.Tables(0).Rows.Count - 1
                V5 = ds3.Tables(0).Rows(j).Item("IDALMACEN")
                v6 = ds3.Tables(0).Rows(j).Item("ALMACEN")

                ds4 = m3.obtenerDistribucionProducto(Session("IdEstablecimiento"), lId, lPr, ds3.Tables(0).Rows(j).Item("IDALMACEN"), ds2.Tables(0).Rows(i).Item("RENGLON"))

                For k As Integer = 0 To ds4.Tables(0).Rows.Count - 1
                    Dim dr As DataRow
                    dr = tbl.NewRow

                    dr(0) = ds1.Tables(0).Rows(0).Item(0)
                    dr(1) = ds1.Tables(0).Rows(0).Item(1)
                    dr(2) = ds1.Tables(0).Rows(0).Item(3)
                    dr(3) = ds1.Tables(0).Rows(0).Item(4)
                    dr(4) = V1
                    dr(5) = V2
                    dr(6) = v3
                    dr(7) = v4
                    dr(8) = V5
                    dr(9) = v6
                    dr(10) = ds4.Tables(0).Rows(k).Item("IDENTREGA")
                    dr(11) = ds4.Tables(0).Rows(k).Item("CANTIDAD")
                    dr(12) = ds4.Tables(0).Rows(k).Item("DIAS")
                    dr(13) = ds4.Tables(0).Rows(k).Item("PORCENTAJE")
                    dr(14) = ds4.Tables(0).Rows(k).Item("IdFuenteFinanciamiento")
                    dr(15) = ds4.Tables(0).Rows(k).Item("nombrefuentefinanciamiento")

                    tbl.Rows.Add(dr)

                Next
            Next
        Next

        Reporte.SetDataSource(tbl)
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
