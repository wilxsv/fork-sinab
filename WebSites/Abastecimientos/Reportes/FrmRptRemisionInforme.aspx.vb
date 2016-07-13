Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptAclaraciones
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptFechasRemision.rpt")
        Reporte.Load(reportPath)

        Dim ds As Data.DataSet
        Dim cIM As New cINFORMEMUESTRAS

        Select Case Request.QueryString("campo")
            Case Is = 0
                ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), "", 0, 0)
            Case Is = 1
                ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), Request.QueryString("Valor"), 0, 0)
            Case Is = 2
                Dim str As String = CStr(Request.QueryString("Valor")).ToUpper
                Select Case str
                    Case Is = "A"
                        ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), "", 1, 0)
                    Case Is = "R"
                        ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), "", 2, 0)
                    Case Is = "N" 'Or "n" Or "i" Or "I"
                        ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), "", 3, 0)
                    Case Is = "I"
                        ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), "", 3, 0)
                    Case Else
                        ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), "", 0, 0)
                End Select
            Case Is = 3
                Dim str As String = CStr(Request.QueryString("Valor")).ToUpper
                Select Case str
                    Case Is = "A"
                        ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), "", 0, 1)
                    Case Is = "R"
                        ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), "", 0, 2)
                    Case Else
                        ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), "", 0, 0)
                End Select
        End Select

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
        ' Me.CRVPRINCIPAL.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
