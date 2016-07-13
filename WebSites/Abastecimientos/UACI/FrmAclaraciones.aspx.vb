
Imports System.Collections.Generic

Partial Class frmAclaraciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me.UcVistaDetalleProcesoCompra1
            Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.BASEGENERADA, eESTADOPROCESOSCOMPRAS.BASEPUBLICADA}
            .ESTADOS = estados
            .EVAL_FEC_REC = False
            .EVAL_FEC_RET = False
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .PaginaRedirect = "frmGenerarACLARACIONES.aspx"
            .IDENCARGADO = Session.Item("IdEmpleado")
            .MUESTRAFECHAPUBLICA = False
            .MUESTRALUGARRETIRO = False
            .Consultar()
        End With
        Me.Master.ControlMenu.Visible = False
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
