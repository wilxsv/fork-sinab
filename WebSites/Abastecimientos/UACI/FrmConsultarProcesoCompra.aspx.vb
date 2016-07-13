
Partial Class FrmConsultarProcesoCompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.UcConsultarProcesoCompra1.CargarAnalistas(Session("idestablecimiento"), Session("iddependencia"))
            Me.UcConsultarProcesoCompra1.CargarEstados()
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
