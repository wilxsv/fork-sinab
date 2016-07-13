Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptProgramacionFuente
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("idGrupo") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        If Request.QueryString("idGrupo") = "" Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        If Not IsNumeric(Request.QueryString("idGrupo")) Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        'If Session.Item("idEstablecimiento") <> Request.QueryString("idEstablecimiento") Then
        '    Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
        'End If
        Dim cEntidad As New cPROGRAMACION

        Dim idGrupo As Integer = Request.QueryString("idGrupo")

        Dim arr As ArrayList = cEntidad.obtenerProgramacionesGrupos2(idGrupo)

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptProgramacionFuentes.rpt")

        Reporte.Load(reportPath)

        Dim ds As Data.DataSet
        ds = cEntidad.reporteFuentesProgramacion(idGrupo, arr)
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

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
