
Imports SINAB_Entidades.Helpers

Partial Class FrmDetMantRecibirOferta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UcVistaDetRecibirOferta1.IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        Me.UcVistaDetRecibirOferta1.IDPROCESOCOMPRA = CType(Request.QueryString("IdProc"), Long)
        Me.UcVistaDetRecibirOferta1.CargarDatos()
        Me.Master.ControlMenu.Visible = False
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
