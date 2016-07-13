Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Imports CrystalDecisions.Web

Partial Class FrmRptNivelAbastecimientoMensual
    Inherits Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptNivelEstablecimientoMensual.rpt")
        Reporte.Load(reportPath)

        Dim IDSUMINISTRO, anio, idprograma As Integer
        Dim idsemana As String

        idsemana = Request.QueryString("idSe")
        IDSUMINISTRO = Request.QueryString("idS")
        anio = Request.QueryString("idA")
        idprograma = Request.QueryString("idP")

        Dim CS As New cSUMINISTROS
        Dim cA As New cALMACENES

        Dim pFields As New ParameterFields()

        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "SUMINISTRO"
        pDiscreteValue1.Value = CS.DevolverDescSuministro(IDSUMINISTRO)
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "SEMANA"
        pDiscreteValue2.Value = "Mes: " & ObtenerSemana(idsemana)
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)


        Dim ds As DataSet
        ds = cA.ObtenerNivelAbastecimientoProductosMensual(idsemana, IDSUMINISTRO, anio, idprograma)

        Me.crvPrincipal.ParameterFieldInfo = pFields

        Reporte.SetDataSource(ds.Tables(0))

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

        Me.crvPrincipal.PrintMode = PrintMode.ActiveX

    End Sub
    Public Function ObtenerSemana(mes As String) As String
        Select Case mes
            Case Is = "01"
                Return "Enero"
            Case Is = "02"
                Return "Febrero"
            Case Is = "03"
                Return "Marzo"
            Case Is = "04"
                Return "Abril"
            Case Is = "05"
                Return "Mayo"
            Case Is = "06"
                Return "Junio"
            Case Is = "07"
                Return "Julio"
            Case Is = "08"
                Return "Agosto"
            Case Is = "09"
                Return "Septiembre"
            Case Is = "10"
                Return "Octubre"
            Case Is = "11"
                Return "Noviembre"
            Case Is = "12"
                Return "Diciembre"
        End Select
    End Function
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
