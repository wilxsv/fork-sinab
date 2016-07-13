
Imports System.Collections.Generic

Partial Class frmCapturaofertas
    Inherits System.Web.UI.Page

    Protected Sub UcVistaDetalleProcesoCompra1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcVistaDetalleProcesoCompra1.Load


        With Me.UcVistaDetalleProcesoCompra1
            Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.APERTURADEOFERTA, eESTADOPROCESOSCOMPRAS.RECEPCIONOFERTAS, eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS}
            .ESTADOS = estados
            '._ESTADO = 2
            'Session("IdProcesoCompra") = ._IDPROCESO
            .EVAL_FEC_REC = False
            .EVAL_FEC_RET = False
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .PaginaRedirect = "frmCapturarDetalleOfertas.aspx"
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
