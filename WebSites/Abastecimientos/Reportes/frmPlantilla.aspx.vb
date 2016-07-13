Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Reportes_frmPlantilla
    Inherits System.Web.UI.Page

    Private Reporte As New ReportDocument

    'VARIABLES DEL PARAMETRO        
    Dim paramField As New ParameterField()
    Dim paramFields As New ParameterFields()
    Dim discreteVal As New ParameterDiscreteValue()

    Private Sub ConfiguracionReporte()
        Dim ParamValue As New ParameterDiscreteValue
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptPlantilla.rpt")
        Reporte.Load(reportPath)

        Dim ParamColec As New ParameterValues

        Dim textoPlantilla As String
        textoPlantilla = Session("textoPlantilla")

        paramField.ParameterFieldName = "textoPlantilla"
        discreteVal.Value = textoPlantilla
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Me.crvPrincipal.ParameterFieldInfo = paramFields
        Me.crvPrincipal.ReportSource = Reporte
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfiguracionReporte()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
