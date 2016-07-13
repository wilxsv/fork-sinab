
Partial Class FrmDetMantAperturaOferta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            UcVistaDetalleAperturaOfertas1._IDESTABLECIMIENTO = Session("IdEstablecimiento")
            UcVistaDetalleAperturaOfertas1._IDPROCEDIMIENTO = Request.QueryString("idProc")
            UcVistaDetalleAperturaOfertas1._PAGINA_REDIRECT = "FrmMantAperturaOferta.aspx"
            UcVistaDetalleAperturaOfertas1.consultar()
        End If
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
