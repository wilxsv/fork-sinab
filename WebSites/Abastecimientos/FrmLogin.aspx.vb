'INGRESO AL SISTEMA
'CUA0001 SEGURIDAD
'Ing. Yessenia Pennelope Henriquez Duran
'solicita usuario y clave para ingreso al sistema de abstedimiento
Partial Class FrmLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.IsNewSession Then

            Session.Abandon()
        End If
    End Sub

End Class
