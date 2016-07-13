Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptRevisionNecesidades
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Dim lEstablecimiento As Int64
    Dim lIdNecesidad As Int64
    Dim lPropuesta As Int16
    Dim lAnio As String
    Dim lTipo As Int16
    Dim lSuministro As Int16

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument
        Dim reportPath As String
        lPropuesta = Request.QueryString("idPropuesta")
        lAnio = Request.QueryString("idAnio")
        lTipo = Request.QueryString("idTipo")
        lEstablecimiento = Request.QueryString("idEsta")
        lIdNecesidad = Request.QueryString("idNecesidad")
        If lTipo = 1 Then
            reportPath = Server.MapPath("RptRevisionNecesidadesSibasi.rpt")
        ElseIf lTipo = 2 Then
            reportPath = Server.MapPath("RptRevisionNecesidadesEstablecimiento.rpt")
        Else
            reportPath = Server.MapPath("RptRevisionNecesidadesNacional.rpt")
        End If
        Reporte.Load(reportPath)


        Dim mComponente As New cDETALLENECESIDADESTABLECIMIENTOS
        Dim mComponente2 As New cNECESIDADESTABLECIMIENTOS
        Dim dsConsolidadoDeficit As DataSet

        Select Case lTipo
            Case Is = 1
                'Reporte deficit consolidado por SIBASI
                dsConsolidadoDeficit = mComponente2.ObtenerDsDetalleEstimacionNecesidadesPorSibasi(lAnio, lPropuesta, lEstablecimiento, 0, "")
                Select Case lPropuesta
                    Case Is = 1
                        Reporte.DataDefinition.FormulaFields(1).Text = "'A'"
                    Case Is = 2
                        Reporte.DataDefinition.FormulaFields(1).Text = "'B'"
                    Case Is = 3
                        Reporte.DataDefinition.FormulaFields(1).Text = "'C'"
                End Select
                Reporte.DataDefinition.FormulaFields(7).Text = "'" & Session.Item("NombreEsta") & "'"
                Reporte.DataDefinition.FormulaFields(2).Text = "'" & lAnio & "'"
            Case Is = 2
                'Reporte deficit por Establecimiento
                dsConsolidadoDeficit = mComponente.ObtenerDsDetalleNecesidadPorId(lEstablecimiento, lIdNecesidad, Session.Item("Suministro"))
                Select Case lPropuesta
                    Case Is = 1
                        Reporte.DataDefinition.FormulaFields(1).Text = "'A'"
                    Case Is = 2
                        Reporte.DataDefinition.FormulaFields(1).Text = "'B'"
                    Case Is = 3
                        Reporte.DataDefinition.FormulaFields(1).Text = "'C'"
                End Select
                Reporte.DataDefinition.FormulaFields(7).Text = "'" & Session.Item("NombreEsta") & "'"
                Reporte.DataDefinition.FormulaFields(2).Text = "'" & lAnio & "'"

            Case Is = 3
                'Reporte deficit consolidado a nivel nacional
                dsConsolidadoDeficit = mComponente.ObtenerDsDetalleNecesidadPorPropuesta(lAnio, lPropuesta)
                Select Case lPropuesta
                    Case Is = 1
                        Reporte.DataDefinition.FormulaFields(1).Text = "'A'"
                    Case Is = 2
                        Reporte.DataDefinition.FormulaFields(1).Text = "'B'"
                    Case Is = 3
                        Reporte.DataDefinition.FormulaFields(1).Text = "'C'"
                End Select
                Reporte.DataDefinition.FormulaFields(2).Text = "'" & lAnio & "'"
        End Select

        Reporte.SetDataSource(dsConsolidadoDeficit.Tables(0))

        Reporte.DataDefinition.FormulaFields(3).Text = Session.Item("Asignado")
        Reporte.DataDefinition.FormulaFields(4).Text = Session.Item("Real")
        Reporte.DataDefinition.FormulaFields(5).Text = Session.Item("Ajustado")
        Reporte.DataDefinition.FormulaFields(6).Text = Session.Item("Final")
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
