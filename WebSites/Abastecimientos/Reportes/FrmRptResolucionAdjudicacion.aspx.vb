Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptResolucionAdjudicacion
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptResolucionAdjudicacion.rpt")
        Reporte.Load(reportPath)

        Dim IDPROCESOCOMPRA, idalmacen As Int64
        IDPROCESOCOMPRA = Request.QueryString("id")
        idalmacen = Request.QueryString("idA")

        Dim mComponente As New cPROCESOCOMPRAS

        Dim ds As Data.DataSet
        ds = mComponente.ObtenerResolucionAdjudicacion(Session.Item("IdEstablecimiento"), IDPROCESOCOMPRA, idalmacen)

        Dim cFF As New cFUENTEFINANCIAMIENTOS

        Reporte.DataDefinition.FormulaFields(6).Text = "'" & cFF.DevolverFFPC(IDPROCESOCOMPRA, Session.Item("IdEstablecimiento")) & "'"

        Dim paramField As New ParameterField()
        Dim paramFields As New ParameterFields()
        Dim discreteVal As New ParameterDiscreteValue()

        paramField = New ParameterField()
        paramField.ParameterFieldName = "E"
        discreteVal = New ParameterDiscreteValue()

        Select Case idalmacen
            Case Is = 0
                discreteVal.Value = ""
            Case Is = 1
                discreteVal.Value = "MSPAS"
            Case Is = 114
                discreteVal.Value = "FOSALUD"
            Case Is = 499
                discreteVal.Value = "ISSS"
        End Select
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
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
