
Partial Class frmConsultarBases
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me.UcVistaDetalleProcesoCompra1
            .ESTADO = 2
            .EVAL_FEC_REC = False
            .EVAL_FEC_RET = False
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .PaginaRedirect = "frmGenerarBasesPlantilla.aspx?mod=cons"
            .Consultar()
        End With
    End Sub

    Protected Sub UcVistaDetalleProcesoCompra1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcVistaDetalleProcesoCompra1.Load

    End Sub
End Class
