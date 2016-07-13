Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptDistribucion22
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("id") Is Nothing Or Request.QueryString("tipo") Is Nothing Or Request.QueryString("est") Is Nothing Or Request.QueryString("prod") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        Dim idDistribucion As Integer = Request.QueryString("id")
        Dim tipo As Integer = Request.QueryString("tipo")
        Dim idEst As Integer = Request.QueryString("est")
        Dim idProd As Integer = Request.QueryString("prod")
        Dim idguarda As Integer = Request.QueryString("guarda")

        Reporte = New ReportDocument
        Dim reportPath As String

        Select Case tipo
            Case 11
                reportPath = Server.MapPath("rptDistribucionEstablecimientos22.rpt")
            Case 1
                'reportPath = Server.MapPath("rptDistribucionProductos.rpt")
                reportPath = Server.MapPath("rptDistribucionEstablecimientos2.rpt")
            Case Else
                reportPath = Server.MapPath("rptDistribucionEstablecimientos2.rpt")

        End Select

        If idguarda <> 0 Then
            reportPath = Server.MapPath("rptDistribucionEstablecimientos2.rpt")
        End If

        Reporte.Load(reportPath)

        Dim x As New cDistribucion

        'Obtenemos el detalle del proceso de compras

        Dim ds As New Data.DataSet



        If idguarda <> 0 Then
            x.obtenerRptDistribucion22(idDistribucion, 620, tipo, ds, idProd, idEst)
            Dim pField As New ParameterField()
            Dim disVal As New ParameterDiscreteValue()
            disVal.Value = x.ObtenerFechaEntregaDistribucion(idDistribucion, 620, idEst)
            pField.ParameterFieldName = "FechaEntrega"
            pField.CurrentValues.Add(disVal)
            crvPrincipal.ParameterFieldInfo.Add(pField)
        Else
            x.obtenerRptDistribucion22(idDistribucion, 620, tipo, ds, idProd, idEst)
        End If

        Reporte.SetDataSource(ds.Tables(0))
        Reporte.Subreports(0).SetDataSource(ds.Tables("table2"))
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
