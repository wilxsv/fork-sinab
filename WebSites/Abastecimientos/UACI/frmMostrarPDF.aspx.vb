
Partial Class frmAnticiposAlmacen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
        End If
    End Sub
    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub LnkPdf1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkPdf1.Click
        Response.Redirect("~/INFORME DE MEDICAMENTOS 2008.pdf", False)
    End Sub
End Class
