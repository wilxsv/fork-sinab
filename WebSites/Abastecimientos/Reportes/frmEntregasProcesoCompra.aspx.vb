
Imports SINAB_Entidades

Partial Class Reportes_frmEntregasProcesoCompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False
            Helpers.UACIHelpers.ProcesoCompras.CargarProcesosCompraALista(619, CType(EnumHelpers.EstadosProcesoCompra.GenerarContratos, Int32), ddlproceso)
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Response.Redirect(String.Format("~/Reportes/FrmReporteEntregasProcesoCompra.aspx?p={0}&c={1}", ddlproceso.SelectedValue, HttpUtility.UrlEncode(ddlproceso.SelectedItem.Text)))
    End Sub
End Class
