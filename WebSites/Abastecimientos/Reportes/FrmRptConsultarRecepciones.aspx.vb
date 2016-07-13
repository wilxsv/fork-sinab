'REPORTES DEL MODULO ESTABLECIMIENTOS
'CU-ESTA002
'Javier Mejia
'Reporte de datos generales de contrato junto con sus renglones asociados

Imports CrystalDecisions.CrystalReports.Engine

Partial Class Reportes_FrmRptConsultarRecepciones
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String = String.Empty

        Select Case Me.Session("TipoConsulta").ToString
            Case 0
                reportPath = Server.MapPath("RptRecepcionesRenglon.rpt")
            Case 1
                reportPath = Server.MapPath("RptRecepcionesContrato.rpt")
            Case 2
                reportPath = Server.MapPath("RptRecepcionesAlmacen.rpt")
            Case 3
                reportPath = Server.MapPath("RptRecepcionesProveedor.rpt")
        End Select

        Reporte.Load(reportPath)
        Reporte.SetDataSource(Me.Session("dsRecepciones"))

        'muestra reporte
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
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
