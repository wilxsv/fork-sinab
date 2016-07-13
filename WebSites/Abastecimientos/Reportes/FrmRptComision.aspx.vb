Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptComision
    Inherits System.Web.UI.Page

    Private Reporte As New ReportDocument

    Private Sub ConfiguracionReporte()

        Reporte = New ReportDocument

        'Dim reportPath As String = Server.MapPath("RptComision.rpt")
        'Reporte.Load(reportPath)
        Dim reportPath As String
        If Session.Item("idestablecimiento") = 661 Then
            reportPath = Server.MapPath("RptComisionf.rpt")
        Else
            reportPath = Server.MapPath("RptComision.rpt")
        End If
        Reporte.Load(reportPath)
        Dim mcomponente As New cCOMISIONPROCESOCOMPRA

        Dim ds As Data.DataSet
        ds = mcomponente.ObtenerDsComision(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        Dim cEs As New cESTABLECIMIENTOS

        Reporte.DataDefinition.FormulaFields(0).Text = "'" & Session.Item("NomComision") & "'"
        Reporte.DataDefinition.FormulaFields(1).Text = "'" & Session.Item("TipoLicitacion") & "'"
        Reporte.DataDefinition.FormulaFields(2).Text = "'" & Session.Item("NumLicitacion") & "'"
        Reporte.DataDefinition.FormulaFields(3).Text = "'" & Session.Item("TituloLicitacion") & "'"
        Reporte.DataDefinition.FormulaFields(6).Text = "'" & cEs.ObtenerNomEstablecimiento(Session("IdEstablecimiento")) & "'"
        Reporte.DataDefinition.FormulaFields(7).Text = "'" & Session("FechaCreacion") & "'"

        Dim paramField As New ParameterField()
        Dim paramFields As New ParameterFields()
        Dim discreteVal As New ParameterDiscreteValue()

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Descripcion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session.Item("DescPC")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Reporte.SetDataSource(ds.Tables(0))

        Me.crvPrincipal.ReportSource = Reporte
        Me.crvPrincipal.ParameterFieldInfo = paramFields

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
        ConfiguracionReporte()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
