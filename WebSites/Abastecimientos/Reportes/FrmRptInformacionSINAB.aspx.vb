Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptInformacionSINAB
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath("RptInformacionSINAB.rpt")
        Reporte.Load(reportPath)

        Dim IdProducto, mSc, mPC, mPE, mD, vSC, vPC, vE As Integer

        IdProducto = Request.QueryString("idProducto")
        mSc = Request.QueryString("mSc")
        mPC = Request.QueryString("mPC")
        mPE = Request.QueryString("mPE")
        mD = Request.QueryString("mD")
        vSC = Request.QueryString("vSC")
        vPC = Request.QueryString("vPC")
        vE = Request.QueryString("vE")

        Dim ds As Data.DataSet
        Dim cc As New cCATALOGOPRODUCTOS
        ds = cc.ObtenerInformacionSINAB(IdProducto, mSc, mPC, mPE, mD, vSC, vPC, vE)
        Reporte.SetDataSource(ds.Tables(0))


        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "CODIGO"
        pDiscreteValue1.Value = cc.DevolverCodigoProducto(IdProducto)
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "DESCRIPCION"
        pDiscreteValue2.Value = cc.DevolverNombreProducto(IdProducto)
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim pField3 As New ParameterField()
        Dim pDiscreteValue3 As New ParameterDiscreteValue()
        pField3.ParameterFieldName = "UM"
        pDiscreteValue3.Value = cc.DevolverUMProducto(IdProducto)
        pField3.CurrentValues.Add(pDiscreteValue3)
        pFields.Add(pField3)


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

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub
End Class
