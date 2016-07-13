Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptCuadroAsignacionInspectores
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = ""

        Dim IDPROCESOCOMPRA, IDESTABLECIMIENTO As Integer
        IDPROCESOCOMPRA = Request.QueryString("IdPC")
        IDESTABLECIMIENTO = Request.QueryString("IdE")

        reportPath = Server.MapPath("RptCuadroAsignacionInspectores.rpt")

        Reporte.Load(reportPath)

        Dim cIM As New cINFORMEMUESTRAS

        Dim DS As Data.DataSet
        DS = cIM.ObtenerRptCuadroAsignacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        Dim CPC As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS
        Dim ds1 As New Data.DataSet
        CPC.ObtenerCodigoyTipoLicitacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds1)

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "TIPOCOMPRA"
        pDiscreteValue1.Value = ds1.Tables(0).Rows(0).Item(0)
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "CODIGOLICITACION"
        pDiscreteValue2.Value = ds1.Tables(0).Rows(0).Item(1)
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim pField3 As New ParameterField()
        Dim pDiscreteValue3 As New ParameterDiscreteValue()
        pField3.ParameterFieldName = "DESCRIPCIONLICITACION"
        pDiscreteValue3.Value = ds1.Tables(0).Rows(0).Item(4)
        pField3.CurrentValues.Add(pDiscreteValue3)
        pFields.Add(pField3)

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
