
Partial Class FrmDetaMantEntregaBases
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            UcVistaDetalleEntregaBases1.IDPROCESOCOMPRA = Request.QueryString("idProc")
            UcVistaDetalleEntregaBases1.PAGINA = "FrmDetaEntregaBases.aspx"
            UcVistaDetalleEntregaBases1.Consultar()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
