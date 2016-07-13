
Partial Class FrmMantProcesoCompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.UcVistaDetalleProcesoCompra1._ESTADO = 2
        Me.UcVistaDetalleProcesoCompra1.EVAL_FEC_REC = False
        Me.UcVistaDetalleProcesoCompra1.EVAL_FEC_RET = False
        Me.UcVistaDetalleProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcVistaDetalleProcesoCompra1.PaginaRedirect = "FrmMantSolicitudProcesoCompra.aspx"
        Me.UcVistaDetalleProcesoCompra1.Consultar()
        Me.Master.ControlMenu.Visible = False
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
