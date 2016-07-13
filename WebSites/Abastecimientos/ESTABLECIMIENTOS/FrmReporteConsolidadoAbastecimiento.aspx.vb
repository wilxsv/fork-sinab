Imports System.Collections.Generic
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Linq
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades.Tipos
Imports SINAB_Utils

Partial Class Reportes_FrmReporteConsolidadoAbastecimiento
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Dim currentYear = DateTime.Now.Year
            Dim currentWeek = Semana.ObtenerNumero()
            CargarSemanasActuales(currentWeek)


            For y As Integer = 2011 To currentYear
                ddlAnio.Items.Add(New ListItem(y.ToString(), y.ToString()))
            Next
            ddlAnio.SelectedValue = currentYear.ToString()

            gvtest.DataSource = Almacen.ObtenerTodosConCuandroBasico() 'ProductoAlmacen.ObtenerReporteDetallado(), ProductoSinExistencia.ObtenerReporte(25, 2015, False), ProductoSinExistencia.ObtenerReporte(25, 2015, True)
            gvtest.DataBind()

            CargarBotones(currentWeek, currentYear)

        End If
    End Sub

    Protected Sub ddlAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAnio.SelectedIndexChanged

        If ddlAnio.SelectedValue < DateTime.Today.Year Then
            With ddlSemana
                .DataSource = Semana.ObtenerTodasAnteriores(CType(ddlAnio.SelectedValue, Integer))
                .DataTextField = "Value"
                .DataValueField = "Key"
                .DataBind()
            End With
        Else
            CargarSemanasActuales(Semana.ObtenerNumero())
        End If
        CargarDatos()
    End Sub

    Protected Sub ddlSemana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSemana.SelectedIndexChanged
        CargarDatos()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub CargarDatos()

        Dim currentWeek = CType(ddlSemana.SelectedValue, Integer)
        Dim currentYear = CType(ddlAnio.SelectedValue, Integer)
        gvtest.DataSource = Almacen.ObtenerTodosConCuandroBasico() 'ProductoAlmacen.ObtenerReporteDetallado(), ProductoSinExistencia.ObtenerReporte(25, 2015, False), ProductoSinExistencia.ObtenerReporte(25, 2015, True)
        gvtest.DataBind()

        CargarBotones(currentWeek, currentYear)
    End Sub
    Protected Sub gvtest_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvtest.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim currentWeek = CType(ddlSemana.SelectedValue, Integer)
            Dim currentYear = CType(ddlAnio.SelectedValue, Integer)
            Dim des = CType(e.Row.FindControl("ltDes"), Literal)
            Dim abas = CType(e.Row.FindControl("ltAbas"), Literal)
            Dim cuba = CType(e.Row.FindControl("ltCuba"), Literal)

            Dim idalmacen = gvtest.DataKeys(e.Row.RowIndex).Values(0)
            Dim res = ProductoAlmacen.ObtenerDetalleAbastecimiento(CType(idalmacen, Integer), currentWeek, currentYear)
            If res.Any() Then
                Dim info = res.FirstOrDefault()
                With info
                    cuba.Text = info.CuadroBasico.ToString()
                    abas.Text = info.Abastecido.ToString()
                    des.Text = info.Desabastecido.ToString()
                End With
            Else
                cuba.Text = "-"
                abas.Text = "-"
                des.Text = "-"
            End If
        End If
    End Sub
    Private Sub CargarBotones(ByVal currentWeek As Integer, ByVal currentYear As Integer)

        Dim cadConsolidado = String.Format("/Reportes/FrmRptAbastecimientoProductosConsolidados.aspx?w={0}&y={1}", currentWeek, currentYear)
        lbReporteConsolidado.Attributes.Add("onClick", Utils.ReferirVentana(cadConsolidado))

        Dim cadAbastecidos = String.Format("/Reportes/FrmRptAbastecimientoProductosExistencias.aspx?w={0}&y={1}&e={2}", currentWeek, currentYear, True)
        lbReporteAbastecidos.Attributes.Add("onClick", Utils.ReferirVentana(cadAbastecidos))

        Dim cadDesabastecidos = String.Format("/Reportes/FrmRptAbastecimientoProductosExistencias.aspx?w={0}&y={1}&e={2}", currentWeek, currentYear, False)
        lbReporteDesabastecidos.Attributes.Add("onClick", Utils.ReferirVentana(cadDesabastecidos))

        lbReporteConsolidadoDetallado.Attributes.Add("onClick", Utils.ReferirVentana("/Reportes/FrmRptAbastecimientoCuadroBasico.aspx"))

    End Sub

    Private Sub CargarSemanasActuales(semana As Integer)
        Dim currentweek = semana
        With ddlSemana
            .DataSource = SINAB_Utils.Semana.ObtenerTodasHastaHoy() 'Semanas.ObtenerHastaHoy()
            .DataTextField = "Value"
            .DataValueField = "Key"
            .DataBind()
        End With
        ddlSemana.SelectedValue = currentweek.ToString()
    End Sub



End Class
