
Partial Class wfMantCLAUSULAS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            If Request.QueryString.HasKeys Then
                Me.ucMantCLAUSULAS1.IDMODALIDADCOMPRA = Request.QueryString.Item("IdMod")
            End If
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
