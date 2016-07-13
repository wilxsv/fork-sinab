
Imports CrystalDecisions.Shared
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports CrystalDecisions.CrystalReports.Engine

Partial Class Reportes_FrmRptAbastecimientoProductosExistencias
    Inherits System.Web.UI.Page

    Private _reporte As ReportDocument

    Dim _semana As Integer
    Dim _anio As Integer
    Dim _existencias As Boolean

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        _reporte.Close()
        _reporte.Dispose()
    End Sub

    Private Sub ConfigureCrystalReports()
        _reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("~/Reportes/rpt/AbastecimientoProductosExistencias.rpt")
        _reporte.Load(reportPath)

        _semana = CType(Request.QueryString("w"), Integer)
        _anio = CType(Request.QueryString("y"), Integer)
        _existencias = CType(Request.QueryString("e"), Boolean)
        Dim ds = ProductoSinExistencia.ObtenerTodos(_semana, _anio, _existencias)

        _reporte.SetDataSource(ds)

        'paramField.CurrentValues.Add(discreteVal)
        Dim param1 = New ParameterDiscreteValue()
        Dim param2 = New ParameterDiscreteValue()
        Dim param3 = New ParameterDiscreteValue()
        param1.Value = _semana
        param2.Value = _anio
        param3.Value = _existencias

        _reporte.SetParameterValue(0, param1)
        _reporte.SetParameterValue(1, param2)
        _reporte.SetParameterValue(2, param3)

        With crvPrincipal
            .ReportSource = _reporte
            .DisplayGroupTree = False
            .DisplayToolbar = True
            .EnableDrillDown = False
            .HasCrystalLogo = False
            .HasDrillUpButton = False
            .HasGotoPageButton = True
            .HasPageNavigationButtons = True
            .HasPrintButton = True
            .HasRefreshButton = False
            .HasSearchButton = False
            .HasToggleGroupTreeButton = False
            .HasViewList = False
            .HasZoomFactorList = False

            .PrintMode = CrystalDecisions.Web.PrintMode.ActiveX
        End With

    End Sub
End Class
