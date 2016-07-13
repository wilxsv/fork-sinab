
Imports System.Security.Policy

Partial Class Reportes_FrmActasRecepcionAlmacenes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False
            With filtros

                .VerFechaDesde = True
                .VerFechaHasta = True
                .FechasRequeridas = True
                .VerAlmacen = True
                .VerEstablecimientoTodos = True
                .IniciarDatos()
            End With

        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub FiltrosConsultar() Handles filtros.Consultar

        Response.Redirect(String.Format("~/Reportes/FrmReporteActasRecepcionAlmacenes.aspx?e={0}&a={1}&di={2}&df={3}", filtros.IDESTABLECIMIENTO2, filtros.IDALMACEN, HttpUtility.UrlEncode(filtros.FECHADESDE), HttpUtility.UrlEncode(filtros.FECHAHASTA)))

    End Sub

End Class
