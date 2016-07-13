
Partial Class FrmIniciarConsultaContrato
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UcVistaDetalleProcesoCompra1.ESTADO = 17
        Me.UcVistaDetalleProcesoCompra1.EVAL_FEC_REC = False
        Me.UcVistaDetalleProcesoCompra1.EVAL_FEC_RET = False
        Me.UcVistaDetalleProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        'me.UcVistaDetalleProcesoCompra1._IDPROCESO  
        Me.UcVistaDetalleProcesoCompra1.PaginaRedirect = "frmConsultarContratos.aspx"
        Me.UcVistaDetalleProcesoCompra1.Consultar()
    End Sub

End Class
