
Partial Class FrmMantClausula
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False
        Me.UcStaClausula1.cargarDatos()
    End Sub
End Class
