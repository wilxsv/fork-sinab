Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptAvisoResolucionFirme
    Inherits System.Web.UI.Page

    Private Reporte As New ReportDocument

    Private Sub ConfiguracionReporte()

        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath("RptAvisoResolucionFirme.rpt")
        Reporte.Load(reportPath)

        Dim IDESTABLECIMIENTO, IDPROCESOCOMPRA As Integer
        IDESTABLECIMIENTO = Session("IdEstablecimiento")
        IDPROCESOCOMPRA = Request.QueryString("id")

        Dim cA As New cADJUDICACION
        Dim cPC As New cPROCESOCOMPRAS
        Dim dsproceso As Data.DataSet
        Dim dsProveedor As Data.DataSet

        Dim aviso As String

        dsproceso = cPC.ObtenerDatosAvisoAdjudicacionFirme(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        dsProveedor = cA.obtenerDatasetProveedoresAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        aviso = dsproceso.Tables(0).Rows(0).Item("MODALIDAD") & " " & dsproceso.Tables(0).Rows(0).Item("CODIGOLICITACION") & ", " & dsproceso.Tables(0).Rows(0).Item("DESCRIPCIONLICITACION") & ", "

        'For i As Integer = 0 To dsproceso.Tables(0).Rows.Count - 1
        '    If i > 0 Then aviso += ", "
        '    aviso += dsproceso.Tables(0).Rows(i).Item("FUENTEFINANCIAMIENTO").ToString
        'Next

        aviso += ". "

        aviso += "Adjudicado a la(s) empresa(s): "

        For i As Integer = 0 To dsProveedor.Tables(0).Rows.Count - 1
            If i > 0 Then aviso += "; "
            aviso += dsProveedor.Tables(0).Rows(i).Item("NOMBRE").ToString
        Next

        aviso += " en Resolución de Adjudicación No. " & dsproceso.Tables(0).Rows(0).Item("NUMERORESOLUCION").ToString & "."

        'Parametros de provedor al reporte
        Dim paramFields As New ParameterFields()
        Dim paramField As New ParameterField()
        Dim discreteVal As New ParameterDiscreteValue()
        paramField.ParameterFieldName = "aviso"
        discreteVal.Value = aviso
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Me.crvPrincipal.ParameterFieldInfo = paramFields
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
        ConfiguracionReporte()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
