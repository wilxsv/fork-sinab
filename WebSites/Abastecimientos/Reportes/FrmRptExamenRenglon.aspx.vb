Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptExamenRenglon
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptExamenRenglonEP.rpt")
        Reporte.Load(reportPath)

        Dim lId, lPr, lIdd, idrectec As Integer
        Dim IDPRODUCTO As String
        lId = Request.QueryString("id")
        lPr = Request.QueryString("Pr")
        idrectec = Request.QueryString("IDRECTEC")
        IDPRODUCTO = Request.QueryString("idp")
        If Request.QueryString("Idd") = "" Then
            lIdd = 1
        Else
            lIdd = CInt(Request.QueryString("Idd"))
        End If


        Dim cF As New cFUENTEFINANCIAMIENTOS
        Dim x As String
        x = cF.DevolverFFPC(lId, Session.Item("IdEstablecimiento"))
        Reporte.DataDefinition.FormulaFields(0).Text = "'" & x & "'"

        Dim mComponente As New cPROCESOCOMPRAS
        Dim ds As Data.DataSet
        ds = mComponente.obtenerExamenRenglonEP(Session.Item("IdEstablecimiento"), lId, lPr, lIdd, idrectec, IDPRODUCTO)


        Dim pFields As New ParameterFields()

        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "CORRPRODUCTO"
        pDiscreteValue1.Value = ds.Tables(0).Rows(0)("CORRPRODUCTO")
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "DESCLARGO"
        pDiscreteValue2.Value = ds.Tables(0).Rows(0)("DESCLARGO")
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)



        Reporte.SetDataSource(ds.Tables(0))
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
