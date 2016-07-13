﻿Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptRolesUsuarios
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath("RptRolesUsuarios.rpt") 'nombre de reporte
        Reporte.Load(reportPath)

        Dim mComponente As New cROLES
        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDsRolesUsuarios

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