Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptUbicacionProductos
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptUbicacionProductos.rpt")
        Reporte.Load(reportPath)
        'Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, "")
        'Dim exportOpts As ExportOptions = New ExportOptions()
        'Dim pdfOpts As PdfRtfWordFormatOptions = ExportOptions.CreatePdfRtfWordFormatOptions()
        'exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
        'exportOpts.ExportFormatOptions = pdfOpts
        'Reporte.ExportToHttpResponse(exportOpts, Response, False, "")

        Dim IdProducto As String

        IdProducto = Request.QueryString("Codigo")
        

        'Dim pFields As New ParameterFields()
        'Dim pField1 As New ParameterField()
        'Dim pDiscreteValue1 As New ParameterDiscreteValue()
        'pField1.ParameterFieldName = "producto"
        'Dim cp As New cCATALOGOPRODUCTOS
        'pDiscreteValue1.Value = IdProducto & " - " & cp.DevolverNombreProducto(cp.DevolverIDProducto(IdProducto))
        'pField1.CurrentValues.Add(pDiscreteValue1)
        'pFields.Add(pField1)


        'Dim discretevalue As ParameterDiscreteValue
        'Dim values As ParameterValues
        'discretevalue = New ParameterDiscreteValue
        'Dim cp As New cCATALOGOPRODUCTOS
        'discretevalue.Value = IdProducto & " - " & cp.DevolverNombreProducto(cp.DevolverIDProducto(IdProducto))
        'values = New ParameterValues
        'values.Add(discretevalue)
        'Reporte.DataDefinition.ParameterFields("producto").ApplyCurrentValues(values)

        Dim cp As New cCATALOGOPRODUCTOS
        Reporte.SetParameterValue(0, IdProducto & " - " & cp.DevolverNombreProducto(cp.DevolverIDProducto(IdProducto)))
        Reporte.SetParameterValue(1, Session.Item("NombreAlmacen"))

        'Dim discretevalue2 As ParameterDiscreteValue
        'Dim values2 As ParameterValues
        'discretevalue2 = New ParameterDiscreteValue
        'discretevalue2.Value = Session.Item("NombreAlmacen")
        'values2 = New ParameterValues
        'values2.Add(discretevalue2)
        'Reporte.DataDefinition.ParameterFields("almacen").ApplyCurrentValues(values2)


        'Dim pField2 As New ParameterField()
        'Dim pDiscreteValue2 As New ParameterDiscreteValue()
        'pField2.ParameterFieldName = "almacen"
        'pDiscreteValue2.Value = Session.Item("NombreAlmacen")
        'pField2.CurrentValues.Add(pDiscreteValue2)
        'pFields.Add(pField2)


        Dim cL As New cUBICACIONESPRODUCTOS
        Dim ds As Data.DataSet
        ds = cL.ObtenerUbicacionesProductosAlmacen(Session("IdAlmacen"), cp.DevolverIDProducto(IdProducto))

        'Me.crvPrincipal.ParameterFieldInfo = pFields

        Reporte.SetDataSource(ds.Tables(0))


      

        'Me.crvPrincipal.ReportSource = Reporte
        'Me.crvPrincipal.DataBind()
        'Me.crvPrincipal.DisplayGroupTree = False
        'Me.crvPrincipal.DisplayToolbar = True
        'Me.crvPrincipal.EnableDrillDown = False
        'Me.crvPrincipal.HasCrystalLogo = False
        'Me.crvPrincipal.HasDrillUpButton = False
        'Me.crvPrincipal.HasGotoPageButton = True
        'Me.crvPrincipal.HasPageNavigationButtons = True
        'Me.crvPrincipal.HasPrintButton = True
        'Me.crvPrincipal.HasRefreshButton = False
        'Me.crvPrincipal.HasSearchButton = False
        'Me.crvPrincipal.HasToggleGroupTreeButton = False
        'Me.crvPrincipal.HasViewList = False
        'Me.crvPrincipal.HasZoomFactorList = False

        'Me.crvPrincipal.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

        Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Ubicacion")
        'Dim oStream As New IO.MemoryStream
        'oStream = Reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        'Response.Clear()
        'Response.Buffer = True
        'Response.ContentType = "application/pdf"
        'Response.BinaryWrite(oStream.ToArray())
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()

    End Sub

End Class
