Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_VisorReporte
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument
    Private Function ValStr(ByVal valor As String, ByVal busqueda As String)
        Dim tempArr As Array
        Dim ret As String = String.Empty
        Dim arrKey As Array
        arrKey = valor.Split(";")
        For i As Integer = 0 To arrKey.Length - 1
            tempArr = arrKey(i).Split("=")
            If tempArr(0) = busqueda Then
                Return tempArr(1)
            End If
        Next
        
        Return ret
    End Function

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("~/Reportes/rpt/rptIndicador1-2ContratosAnioMes.rpt")
        Reporte.Load(reportPath)

        Dim IDESTABLECIMIENTO As Integer
        Dim suprimirSeccion As Boolean = True
        ' IDPROVEEDOR = Request.QueryString("IDP")
        'IdProcesoCompra = Request.QueryString("IDPC")
        IDESTABLECIMIENTO = Session("idEstablecimiento") 'Request.QueryString("IDE")
        'IDALMACEN = Request.QueryString("IDA")
        'IDCONTRATO = Request.QueryString("IDC")
        'Response.Write("<BR>PROVEEDOR: " & IDPROVEEDOR)
        'Response.Write("<BR>IdProcesoCompra: " & IdProcesoCompra)
        'Response.Write("<BR>IDESTABLECIMIENTO: " & IDESTABLECIMIENTO)
        'Response.Write("<BR>IDALMACEN: " & IDALMACEN)

        Dim paramField As New ParameterField()
        Dim paramFields As New ParameterFields()
        Dim discreteVal As New ParameterDiscreteValue()

        paramField = New ParameterField()
        paramField.ParameterFieldName = "idEsablecimiento"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = IDESTABLECIMIENTO
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)


        Dim oTblLogOnInfos As TableLogOnInfos = New TableLogOnInfos()
        Dim oTblLogOnInfo As TableLogOnInfo = New TableLogOnInfo()
        Dim oConInfo As ConnectionInfo = New ConnectionInfo()
        Dim conStr As String = ConfigurationManager.AppSettings("cnnString")

        oConInfo.ServerName = ValStr(conStr, "server") '"10.10.20.24" 'ConfigurationManager.AppSettings(sReportDataSource)
        Response.Write(" Servidor: " & oConInfo.ServerName)
        If Not ValStr(conStr, "integrated security") = "" Then
            oConInfo.IntegratedSecurity = True
        Else
            oConInfo.IntegratedSecurity = False
            oConInfo.UserID = ValStr(conStr, "user id") '"sa" 'ConfigurationManager.AppSettings(sReportUserId)
            oConInfo.Password = ValStr(conStr, "password") ' "rasengan2" 'ConfigurationManager.AppSettings(sReportPwd)
            oTblLogOnInfo.ConnectionInfo = oConInfo
            oTblLogOnInfos.Add(oTblLogOnInfo)
        End If
        


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
        Me.crvPrincipal.LogOnInfo = oTblLogOnInfos
        Me.crvPrincipal.ParameterFieldInfo = paramFields
        Me.crvPrincipal.ReportSource = Reporte
        Response.Write(" Servidor: " & Me.crvPrincipal.LogOnInfo(0).ConnectionInfo.ServerName)
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
