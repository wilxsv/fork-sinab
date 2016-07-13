
Imports System.Collections.Generic

Partial Class FrmMantAperturaOferta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim estados As List(Of Integer) = New List(Of Integer)() From {eESTADOPROCESOSCOMPRAS.BASEPUBLICADA, eESTADOPROCESOSCOMPRAS.APERTURADEOFERTA}
        Me.UcVistaDetalleProcesoCompra1.ESTADOS = estados

        Me.UcVistaDetalleProcesoCompra1.EVAL_FEC_REC = False
        Me.UcVistaDetalleProcesoCompra1.EVAL_FEC_RET = False
        Me.UcVistaDetalleProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcVistaDetalleProcesoCompra1.PaginaRedirect = "FrmDetMantAperturaOferta.aspx"
        Me.UcVistaDetalleProcesoCompra1.Consultar()

        Me.Master.ControlMenu.Visible = False
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
