
Partial Class frmAnticiposAlmacen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Me.UcSeleccionContratoRecepcion2_1.IdEstablecimiento = Session.Item("IdEstablecimiento")
        End If
    End Sub
    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
End Class
