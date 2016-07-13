
Partial Class FrmCalificaProveedor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UcCalificaProveedor1.consultarProveedores()
    End Sub
End Class
