
Imports SINAB_Entidades.Helpers

Partial Class FrmReportesAlmacenes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            If Session.Item("IdTipoEstablecimiento") = 3 Or Session.Item("IdTipoEstablecimiento") = 8 Then
                Me.LinkButton6.Visible = True
            End If


            If Membresia.EsUsuarioRol("Consulta Almacen I") Or Membresia.EsUsuarioRol("AlmacenFosalud") Then
                LinkButton24.Visible = True
            Else
                LinkButton24.Visible = False
            End If

        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


End Class
