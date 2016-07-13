Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptHojaAnalisisXRenglon
    Inherits System.Web.UI.Page

    Private Reporte As New ReportDocument

    Dim TConsolidarOfertas As New Data.DataTable

    Private Sub ConfiguracionReporte()

        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath("RptHojaAnalisisXRenglon.rpt")
        Reporte.Load(reportPath)

        Dim IDESTABLECIMIENTO, IDPROCESOCOMPRA As Integer
        IDESTABLECIMIENTO = Request.QueryString("idE")
        IDPROCESOCOMPRA = Request.QueryString("idP")

        Dim paramField As New ParameterField()
        Dim paramFields As New ParameterFields()
        Dim discreteVal As New ParameterDiscreteValue()

        'Parametros de provedor al reporte
        paramField.ParameterFieldName = "renglon"
        discreteVal.Value = Request.QueryString("renglon")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Dim mcomponente As New cDETALLEPROCESOCOMPRA
        Dim ds As New Data.DataSet
        mcomponente.ObtenerDataSetEncabezado(IDPROCESOCOMPRA, IDESTABLECIMIENTO, ds)

        Dim dr As Data.DataRow = ds.Tables(0).NewRow

        CrearTablaConsolidarOfertas()

        For Each dr In ds.Tables(0).Rows
            Dim RF As Data.DataRow = TConsolidarOfertas.NewRow

            RF(0) = dr(0)
            RF(1) = dr(1)
            RF(2) = dr(2)
            RF(4) = dr(3)
            RF(5) = dr(4)
            RF(6) = dr(5)
            RF(7) = dr(6)

            Dim dsRenglon As New Data.DataSet
            mcomponente.ObtenerDataSetEncabezadoPorRenglon(IDPROCESOCOMPRA, IDESTABLECIMIENTO, Request.QueryString("renglon"), dsRenglon)
            Dim RR As Data.DataRow = dsRenglon.Tables(0).NewRow

            For Each RR In dsRenglon.Tables(0).Rows

                RF(3) += CStr(RR(4)) + "% a " + CStr(RR(3)) + " dias - "
            Next
            TConsolidarOfertas.Rows.Add(RF)

        Next

        Dim dsR As New Data.DataSet
        mcomponente.ObtenerDataSetEncabezadoPorRenglon(IDPROCESOCOMPRA, IDESTABLECIMIENTO, Request.QueryString("renglon"), dsR)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "cantidad"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsR.Tables(0).Rows(0).Item("cantidad") 'Session("cantidad")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "numeroEntregas"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsR.Tables(0).Rows(0).Item("numeroentregas") 'Session("numeroEntregas")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "entregas"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = CStr(dsR.Tables(0).Rows(0).Item("porcentaje")) + " % a " + CStr(dsR.Tables(0).Rows(0).Item("dias")) + " dias - " 'Session("entregas")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "producto"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsR.Tables(0).Rows(0).Item("producto") 'Session("producto")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "um"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = TConsolidarOfertas.Rows(0).Item("um") 'Session("um")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Dim cEst As New cESTABLECIMIENTOS

        paramField = New ParameterField()
        paramField.ParameterFieldName = "ESTA"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = cEst.ObtenerNomEstablecimiento(Session("IdEstablecimiento"))
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)


        Dim mcomponente2 As New cDETALLEOFERTA
        Dim dsD As New Data.DataSet

        mcomponente2.ObtenerDetalleConsolidacionOferta(IDPROCESOCOMPRA, IDESTABLECIMIENTO, Request.QueryString("renglon"), dsD)
        Dim dv As New Data.DataView
        dv.Table = dsD.Tables(0)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "observacion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsR.Tables(0).Rows(0).Item("observacion")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Dim mProcesoCompra As New cPROCESOCOMPRAS
        Dim dsL As New Data.DataSet
        mProcesoCompra.ObtenerCodigoyTipoLicitacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsL)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "TipoLicitacion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsL.Tables(0).Rows(0).Item(0)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "NumLicitacion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsL.Tables(0).Rows(0).Item(1)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "DescPC"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsL.Tables(0).Rows(0).Item(4)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Reporte.SetDataSource(dv.Table)

        Me.crvPrincipal.ParameterFieldInfo = paramFields
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

    Private Sub CrearTablaConsolidarOfertas()

        Dim ColumRENGLON As New Data.DataColumn("RENGLON", System.Type.GetType("System.Int32"))
        Dim ColumCANTIDAD As New Data.DataColumn("CANTIDAD", System.Type.GetType("System.Int32")) ''OJO SE DEBERA CAMBIAR SI QUIEREN DECIMALES////
        Dim ColumNUMEROENTREGAS As New Data.DataColumn("NUMEROENTREGAS", System.Type.GetType("System.Int32"))
        Dim ColumENTREGAS As New Data.DataColumn("ENTREGAS", System.Type.GetType("System.String"))
        Dim ColumPRODUCTO As New Data.DataColumn("PRODUCTO", System.Type.GetType("System.String"))
        Dim ColumUM As New Data.DataColumn("UM", System.Type.GetType("System.String"))
        Dim Columidproducto As New Data.DataColumn("idproducto", System.Type.GetType("System.Int32"))
        Dim Columiddetalle As New Data.DataColumn("iddetalle", System.Type.GetType("System.Int32"))

        TConsolidarOfertas.Columns.Add(ColumRENGLON)
        TConsolidarOfertas.Columns.Add(ColumCANTIDAD)
        TConsolidarOfertas.Columns.Add(ColumNUMEROENTREGAS)
        TConsolidarOfertas.Columns.Add(ColumENTREGAS)
        TConsolidarOfertas.Columns.Add(ColumPRODUCTO)
        TConsolidarOfertas.Columns.Add(ColumUM)
        TConsolidarOfertas.Columns.Add(Columidproducto)
        TConsolidarOfertas.Columns.Add(Columiddetalle)

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfiguracionReporte()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
