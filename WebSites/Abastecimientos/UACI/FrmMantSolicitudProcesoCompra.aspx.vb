
Partial Class FrmMantSolicitudProcesoCompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcVistaDetalleSolicProcesCompra1.PermiteSeleccionar = False
        Me.UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False
        Me.UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
        Me.UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
        Me.UcVistaDetalleSolicProcesCompra1.Consultar()
        Me.Master.ControlMenu.Visible = False
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
