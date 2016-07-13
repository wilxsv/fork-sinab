Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptReporteECOSValorizados
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptECOSValorizado.rpt")
        Reporte.Load(reportPath)

        Dim idRegion, mes, anio As Integer

        idRegion = Request.QueryString("R")
        mes = Request.QueryString("M")
        anio = Request.QueryString("A")


        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "mes"
        Select Case mes
            Case Is = 1
                pDiscreteValue1.Value = "Enero"
            Case Is = 2
                pDiscreteValue1.Value = "Febrero"
            Case Is = 3
                pDiscreteValue1.Value = "Marzo"
            Case Is = 4
                pDiscreteValue1.Value = "Abril"
            Case Is = 5
                pDiscreteValue1.Value = "Mayo"
            Case Is = 6
                pDiscreteValue1.Value = "Junio"
            Case Is = 7
                pDiscreteValue1.Value = "Julio"
            Case Is = 8
                pDiscreteValue1.Value = "Agosto"
            Case Is = 9
                pDiscreteValue1.Value = "Septiembre"
            Case Is = 10
                pDiscreteValue1.Value = "Octubre"
            Case Is = 11
                pDiscreteValue1.Value = "Noviembre"
            Case Is = 12
                pDiscreteValue1.Value = "Diciembre"
        End Select

        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)



        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "anio"
        pDiscreteValue2.Value = anio
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim pField3 As New ParameterField()
        Dim pDiscreteValue3 As New ParameterDiscreteValue()
        pField3.ParameterFieldName = "region"
        Select Case idRegion
            Case Is = 1
                pDiscreteValue3.Value = "Occidental"
            Case Is = 2
                pDiscreteValue3.Value = "Central"
            Case Is = 3
                pDiscreteValue3.Value = "Paracentral"
            Case Is = 4
                pDiscreteValue3.Value = "Oriental"
            Case Is = 5
                pDiscreteValue3.Value = "Metropolitana"
        End Select

        pField3.CurrentValues.Add(pDiscreteValue3)
        pFields.Add(pField3)


        
        Dim ds = SINAB_Entidades.Helpers.ConsumoHelpers.Consumo.ObtenerEcosValorizados(idRegion, mes, anio)

       

        Me.crvPrincipal.ParameterFieldInfo = pFields

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
