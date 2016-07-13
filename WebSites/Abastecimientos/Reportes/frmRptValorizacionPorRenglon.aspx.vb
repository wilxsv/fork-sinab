Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptValorizacionPorRenglon
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Dim paramField As New ParameterField()
    Dim paramFields As New ParameterFields()
    Dim discreteVal As New ParameterDiscreteValue()

    Private Sub ConfiguracionReporte()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptValorizacionesPorRenglon.rpt")
        Reporte.Load(reportPath)

        Dim IDPROCESOCOMPRA As Int64
        IDPROCESOCOMPRA = Request.QueryString("id")

        Dim cDO As New cDETALLEOFERTA
        Dim dsDO As New Data.DataSet
        cDO.ObtenerValorizacionPorRenglon(Session("IdEstablecimiento"), IDPROCESOCOMPRA, dsDO)

        Dim cPC As New cPROCESOCOMPRAS
        Dim dsPC As New Data.DataSet
        cPC.ObtenerInfoLicitacion(Session("IdEstablecimiento"), IDPROCESOCOMPRA, dsPC)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "TipoLicitacion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsPC.Tables(0).Rows(0).Item(0)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "NumLicitacion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsPC.Tables(0).Rows(0).Item(1)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "TituloLicitacion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsPC.Tables(0).Rows(0).Item(2)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Descripcion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsPC.Tables(0).Rows(0).Item(3)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Reporte.SetDataSource(dsDO.Tables(0))
        Me.crvPrincipal.ParameterFieldInfo = paramFields
        Me.crvPrincipal.ReportSource = Reporte

        Me.crvPrincipal.DisplayGroupTree = False
        Me.crvPrincipal.DisplayToolbar = True

        Me.crvPrincipal.HasCrystalLogo = False
        Me.crvPrincipal.HasGotoPageButton = True
        Me.crvPrincipal.HasPageNavigationButtons = True
        Me.crvPrincipal.HasPrintButton = True
        Me.crvPrincipal.HasRefreshButton = False
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
