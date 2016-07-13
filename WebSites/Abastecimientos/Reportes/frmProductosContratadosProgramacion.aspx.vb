
Partial Class Reportes_frmProductosContratadosProgramacion
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False
            SINAB_Entidades.Helpers.URMIMHelpers.Programacion.CargarProgramacionesALista(ddlprogramacion)
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Response.Redirect(String.Format("~/Reportes/FrmReporteProductosContratadosProgramacion.aspx?p={0}&c={1}&n={2}", ddlprogramacion.SelectedValue, chkajustada.Checked, HttpUtility.UrlEncode(ddlprogramacion.SelectedItem.Text)))
    End Sub
End Class
