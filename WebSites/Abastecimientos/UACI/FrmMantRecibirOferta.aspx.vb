
Imports SINAB_Entidades.Helpers

Partial Class FrmMantRecibirOferta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UcVistaDetalleRecibirOferta1._ESTADO = 3 'TODO: Cambiar estado por  estado de "Base Publicada"
        Me.UcVistaDetalleRecibirOferta1._EVAL_FEC_REC = False
        Me.UcVistaDetalleRecibirOferta1._EVAL_FEC_RET = False

        Me.UcVistaDetalleRecibirOferta1._IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO

        Me.UcVistaDetalleRecibirOferta1._PAGINA_REDIREC = "FrmDetMantRecibirOferta.aspx"
        Me.UcVistaDetalleRecibirOferta1.consultar()
        Me.Master.ControlMenu.Visible = False



    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
End Class
