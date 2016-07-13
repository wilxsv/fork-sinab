
Partial Class ImpresionContrato
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Label2.Text = Request.QueryString("C")
        Label4.Text = Request.QueryString("PROV")

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect(Request.QueryString("path"))
    End Sub
End Class
