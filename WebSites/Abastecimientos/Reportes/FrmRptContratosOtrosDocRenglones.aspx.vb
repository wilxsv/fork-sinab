'REPORTES DEL MODULO ESTABLECIMIENTOS
'CU-ESTA002
'Javier Mejia
'Reporte de datos generales de contrato junto con sus renglones asociados
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptContratosOtrosDocRenglones
    Inherits System.Web.UI.Page

    'declaracion e inicializacion
    Private Reporte As ReportDocument
    Dim Renglones As New Data.DataTable

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptContratosOtrosDoc.rpt")
        Reporte.Load(reportPath)

        Dim mComponente As New cCONTRATOS
        Dim ds As New Data.DataSet
        mComponente.ObtenerDatasetRptContratosOtrosDoc(Session("rptEstablecimiento"), Me.Session("rptProveedor"), Me.Session("rptContrato"), Me.Session("rptALMACENENTREGA"), ds)

        'llena de dataset
        LlenarDetalleContrato()
        ds.Tables.Add(Renglones)
        ds.Tables(2).TableName = "Renglones"
        Reporte.SetDataSource(ds)
        'parametros de reporte como campos de formula

        'muestra reporte
        Me.crvPrincipal.ReportSource = Reporte

        Me.crvPrincipal.DisplayGroupTree = False
        Me.crvPrincipal.DisplayToolbar = True

        Me.crvPrincipal.HasCrystalLogo = False
        Me.crvPrincipal.HasGotoPageButton = True
        Me.crvPrincipal.HasPageNavigationButtons = True
        Me.crvPrincipal.HasPrintButton = True
        Me.crvPrincipal.HasRefreshButton = False
        Me.crvPrincipal.HasToggleGroupTreeButton = False
        Me.crvPrincipal.HasViewList = False
        Me.crvPrincipal.HasZoomFactorList = False

        Me.crvPrincipal.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'al inicializar
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

    Private Sub LlenarDetalleContrato()
        Dim mcomponente As New cCONTRATOS
        Dim ds As Data.DataSet
        ds = mcomponente.ObtenerDatasetRptRenglonesContratoOtrosDoc(Me.Session("rptEstablecimiento"), Me.Session("rptCONTRATO"), Me.Session("rptPROVEEDOR"), Me.Session("rptALMACENENTREGA"))

        Dim dr As Data.DataRow = ds.Tables(0).NewRow
        CrearTablaRenglones()

        For Each dr In ds.Tables(0).Rows
            Dim RF As Data.DataRow = Me.Renglones.NewRow

            RF(0) = dr(0)
            RF(1) = dr(1)
            RF(2) = dr(2)
            RF(3) = dr(3)
            RF(4) = dr(4)
            RF(5) = dr(5)
            RF(6) = dr(6)
            RF(7) = dr(7)
            RF(8) = dr(8)
            RF(9) = dr(9)
            RF(10) = dr(10)
            RF(11) = dr(11)

            Dim dsRenglon As Data.DataSet
            dsRenglon = mcomponente.ObtenerDatasetPlazosEntregaRenglonContrato(dr(0), dr(2), dr(1), dr(4))

            Dim RR As Data.DataRow = dsRenglon.Tables(0).NewRow

            For Each RR In dsRenglon.Tables(0).Rows

                RF(12) += CStr(RR(0)) + " dias " + CStr(RR(1)) + "% - "
            Next
            Renglones.Rows.Add(RF)

        Next

    End Sub

    Private Sub CrearTablaRenglones()
        Dim ColumIDESTABLECIMIENTO As New Data.DataColumn("IDESTABLECIMIENTO", System.Type.GetType("System.Int32"))
        Dim ColumIDPROVEEDOR As New Data.DataColumn("IDPROVEEDOR", System.Type.GetType("System.Int32"))
        Dim ColumIDCONTRATO As New Data.DataColumn("IDCONTRATO", System.Type.GetType("System.Int32"))
        Dim ColumIDALMACENENTREGA As New Data.DataColumn("IDALMACENENTREGA", System.Type.GetType("System.Int32"))
        Dim ColumRENGLON As New Data.DataColumn("RENGLON", System.Type.GetType("System.Int32"))
        Dim ColumCODIGO As New Data.DataColumn("CODIGO", System.Type.GetType("System.String"))
        Dim ColumPRODUCTO As New Data.DataColumn("DESCRIPCION", System.Type.GetType("System.String"))
        Dim ColumUM As New Data.DataColumn("UM", System.Type.GetType("System.String"))
        Dim ColumCANTIDAD As New Data.DataColumn("CANTIDAD", System.Type.GetType("System.Double"))
        Dim ColumPRECIOUNITARIO As New Data.DataColumn("PRECIOUNITARIO", System.Type.GetType("System.Double"))
        Dim ColumENTREGAS As New Data.DataColumn("ENTREGAS", System.Type.GetType("System.Int32"))
        Dim ColumTotal As New Data.DataColumn("TOTAL", System.Type.GetType("System.Double"))
        Dim ColumPLAZOS As New Data.DataColumn("PLAZOS", System.Type.GetType("System.String"))

        Renglones.Columns.Add(ColumIDESTABLECIMIENTO)
        Renglones.Columns.Add(ColumIDPROVEEDOR)
        Renglones.Columns.Add(ColumIDCONTRATO)
        Renglones.Columns.Add(ColumIDALMACENENTREGA)
        Renglones.Columns.Add(ColumRENGLON)
        Renglones.Columns.Add(ColumCODIGO)
        Renglones.Columns.Add(ColumPRODUCTO)
        Renglones.Columns.Add(ColumUM)
        Renglones.Columns.Add(ColumCANTIDAD)
        Renglones.Columns.Add(ColumPRECIOUNITARIO)
        Renglones.Columns.Add(ColumENTREGAS)
        Renglones.Columns.Add(ColumTotal)
        Renglones.Columns.Add(ColumPLAZOS)

    End Sub

End Class
