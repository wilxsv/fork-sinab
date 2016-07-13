﻿Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptNotificacionAdjudicacion
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptNotificacionAdjudicacion.rpt")
        Reporte.Load(reportPath)

        Dim IDPROCESOCOMPRA As Integer
        IDPROCESOCOMPRA = Request.QueryString("id") 'identificador proceso de compra

        Dim mComponente As New cADJUDICACION
        Dim ds As Data.DataSet
        ds = mComponente.RptNotificacionAdjudicacion(Session.Item("IdEstablecimiento"), IDPROCESOCOMPRA)

        Dim cE As New cEMPLEADOS
        Dim JefeUACI As String = cE.ObtenerNombreJefeUACI(Session.Item("IdEstablecimiento"))

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "JefeUACI"
        pDiscreteValue1.Value = JefeUACI
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Reporte.SetDataSource(ds)

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
