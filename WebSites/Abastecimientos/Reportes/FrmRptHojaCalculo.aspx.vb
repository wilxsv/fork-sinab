Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptHojaCalculo
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = ""

        Dim IDINFORME, IDESTABLECIMIENTO As Integer
        Dim proveedor, contrato, pc, establecimiento As String
        IDINFORME = Request.QueryString("IdI")
        IDESTABLECIMIENTO = Request.QueryString("IdE")
        proveedor = Request.QueryString("Prov")
        contrato = Request.QueryString("Contrato")
        pc = Request.QueryString("PC")
        establecimiento = Request.QueryString("E")

        reportPath = Server.MapPath("RptHojaCalculo.rpt")

        Reporte.Load(reportPath)

        Dim cIM As New cINFORMEMUESTRAS

        Dim DS As Data.DataSet
        DS = cIM.ObtenerHojaCalculo(Session("IdEstablecimiento"), IDINFORME)

        Dim pFields As New ParameterFields()

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "ESTABLECIMIENTO"
        pDiscreteValue2.Value = establecimiento
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim pField3 As New ParameterField()
        Dim pDiscreteValue3 As New ParameterDiscreteValue()
        pField3.ParameterFieldName = "PC"
        pDiscreteValue3.Value = pc
        pField3.CurrentValues.Add(pDiscreteValue3)
        pFields.Add(pField3)

        Dim pField4 As New ParameterField()
        Dim pDiscreteValue4 As New ParameterDiscreteValue()
        pField4.ParameterFieldName = "PROVEEDOR"
        pDiscreteValue4.Value = proveedor
        pField4.CurrentValues.Add(pDiscreteValue4)
        pFields.Add(pField4)

        Dim pField5 As New ParameterField()
        Dim pDiscreteValue5 As New ParameterDiscreteValue()
        pField5.ParameterFieldName = "CONTRATO"
        pDiscreteValue5.Value = contrato
        pField5.CurrentValues.Add(pDiscreteValue5)
        pFields.Add(pField5)

        Reporte.SetDataSource(DS.Tables(0))


        Me.crvPrincipal.ParameterFieldInfo = pFields
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

        Me.crvPrincipal.EnableDatabaseLogonPrompt = False
        Me.crvPrincipal.EnableParameterPrompt = False

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
