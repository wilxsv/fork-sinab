Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO


Partial Class Reportes_FrmRptListaProductos
    Inherits System.Web.UI.Page
    Private Reporte As New ReportDocument
    Dim paramField As New ParameterField()
    Dim paramFields As New ParameterFields()
    Dim discreteVal As New ParameterDiscreteValue()

    Private Sub ConfiguracionReporte()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptListaProductos.rpt")
        Reporte.Load(reportPath)

        Dim dv As New DataView
        If Session("estahabilitado") = "HABILITADOS" Then
            dv = Session("dsImprimirH")
        ElseIf Session("estahabilitado") = "DESHABILITADOS" Then
            dv = Session("dsImprimirD")
        End If

        'Parametros de provedor al reporte
        paramField.ParameterFieldName = "suministro"
        discreteVal.Value = Session("suministro")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "region"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("region")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "establecimiento"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("establecimiento")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "filtro"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("filtro")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "nombrefiltro"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("nombrefiltro")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "estahabilitado"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("estahabilitado")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Reporte.SetDataSource(dv.Table)
        Me.CrystalReportViewer1.ParameterFieldInfo = paramFields
        Me.CrystalReportViewer1.ReportSource = Reporte
        'Me.CrystalReportViewer1.DataBind()
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.DisplayToolbar = True

        Me.CrystalReportViewer1.EnableDrillDown = False

        Me.CrystalReportViewer1.HasCrystalLogo = False
        Me.CrystalReportViewer1.HasDrillUpButton = False
        Me.CrystalReportViewer1.HasGotoPageButton = True
        Me.CrystalReportViewer1.HasPageNavigationButtons = True
        Me.CrystalReportViewer1.HasPrintButton = True
        Me.CrystalReportViewer1.HasRefreshButton = False
        Me.CrystalReportViewer1.HasSearchButton = False
        Me.CrystalReportViewer1.HasToggleGroupTreeButton = False
        Me.CrystalReportViewer1.HasViewList = False
        Me.CrystalReportViewer1.HasZoomFactorList = False

        Me.CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfiguracionReporte()
        If Session("estahabilitado") = "habilitados" Then
            'Session("suministro") = Nothing
            'Session("region") = Nothing
            'Session("establecimiento") = Nothing
            'Session("filtro") = Nothing
            'Session("nombrefiltro") = Nothing
            'Session("estahabilitado") = Nothing
            ' Session("dsImprimirH") = Nothing
        ElseIf Session("estahabilitado") = "deshabilitados" Then
            'Session("suministro") = Nothing
            'Session("region") = Nothing
            'Session("establecimiento") = Nothing
            'Session("filtro") = Nothing
            'Session("nombrefiltro") = Nothing
            'Session("estahabilitado") = Nothing
            'Session("dsImprimirD") = Nothing
        End If


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
