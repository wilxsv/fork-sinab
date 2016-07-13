Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class Reportes_FrmRptDistroLotesMonte
    Inherits System.Web.UI.Page
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub
    Private Sub ConfigureCrystalReports()
        'If Request.QueryString("idDistro") Is Nothing Or Request.QueryString("Code") Is Nothing Or Request.QueryString("est") Is Nothing Or Request.QueryString("prod") Is Nothing Then

        'If Request.QueryString("Distribucion") Is Nothing Or Request.QueryString("Code") Is Nothing Or Request.QueryString("est") Is Nothing Then
        '    Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
        'End If

        Dim fi As String = Request.QueryString("fi")
        Dim ff As String = Request.QueryString("ff")

        If Not String.IsNullOrEmpty(fi) And Not String.IsNullOrEmpty(ff) Then
            If DateTime.Compare(fi, ff) > 0 Then
                Dim ft As String = fi
                fi = ff
                ff = ft
            End If
        End If

        Dim tipo As Integer = Request.QueryString("t")
        Dim idDistribucion As Integer = Request.QueryString("d")
        Dim idEstablecimiento As Integer = Request.QueryString("ee")
        Dim idProducto As Integer = Request.QueryString("p")
        Dim detalle As Boolean = Convert.ToBoolean(Request.QueryString("i"))
        Dim source As Boolean = Convert.ToBoolean(Request.QueryString("source"))

        'Dim idProd As Integer = Request.QueryString("prod")
        Dim reportPath As String = String.Empty
        Reporte = New ReportDocument

        Select Case tipo
            Case 1
                If detalle Then
                    reportPath = Server.MapPath("RptDistribucionCantidadMontoDetalle.rpt")
                Else
                    reportPath = Server.MapPath("RptDistribucionCantidadMonto.rpt")
                End If
            Case 2
                If source Then
                    reportPath = Server.MapPath("RptDistroEstablecimientosCantidadMontoDistribuidor.rpt")
                Else
                    reportPath = Server.MapPath("RptDistroEstablecimientosCantidadMonto.rpt")
                End If

            Case 3 : reportPath = Server.MapPath("RptDistroProductoCantidadMonto.rpt")
            Case Else : Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End Select

        Reporte.Load(reportPath)

        Dim x As New ABASTECIMIENTOS.NEGOCIO.cDistribucion

        'Obtenemos el detalle del proceso de compras

        Dim ds As Data.DataSet

        ds = x.obtenerRptDistribucionLotesMonto(fi, ff, idDistribucion, idEstablecimiento, idProducto, source)

        Dim pField As New ParameterField()
        Dim disVal As New ParameterDiscreteValue()
        disVal.Value = Session.Item("UsuarioEstablecimiento").ToString
        pField.ParameterFieldName = "TituloEstablecimiento"
        pField.CurrentValues.Add(disVal)
        crvPrincipal.ParameterFieldInfo.Add(pField)

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

        Me.crvPrincipal.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

    End Sub

    Private Reporte As ReportDocument
End Class
