
Imports CrystalDecisions.Shared
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports CrystalDecisions.CrystalReports.Engine
Imports SINAB_Utils
Imports System.Linq
Imports System.Collections.Generic
Imports SINAB_Entidades.Tipos

Partial Class Reportes_FrmRptAbastecimientoProductosConsolidados
    Inherits System.Web.UI.Page


    Private _reporte As ReportDocument

    Dim _semana As Integer
    Dim _anio As Integer

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        _reporte.Close()
        _reporte.Dispose()
    End Sub

    Private Sub ConfigureCrystalReports()
        _reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("~/Reportes/rpt/AbastecimientoConsolidadoProductos.rpt")
        _reporte.Load(reportPath)

        _semana = CType(Request.QueryString("w"), Integer)
        _anio = CType(Request.QueryString("y"), Integer)
        Dim inicioSemana = Semana.FechaInicio(_anio, _semana)
        Dim ds = New List(Of BaseProductoAlmacen)
        Dim res = Almacen.ObtenerTodosConCuandroBasico()
        For Each alm In res
            ds.Add(ProductoAlmacen.ObtenerDetalleAbastecimiento(alm.IdAlmacen, _semana, _anio).FirstOrDefault())
        Next
        ' Dim ds = ProductoAlmacen.ObtenerReporte(_semana, _anio)

        _reporte.SetDataSource(ds)

        'paramField.CurrentValues.Add(discreteVal)
        Dim param1 = New ParameterDiscreteValue()
        Dim param2 = New ParameterDiscreteValue()
        param1.Value = _semana
        param2.Value = _anio
        _reporte.SetParameterValue(0, param1)
        _reporte.SetParameterValue(1, param2)


        With crvPrincipal
            .ReportSource = _reporte

            ' Reporte.SetParameterValue("LogoSrc", Server.MapPath(Config.LogoUrl))
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
