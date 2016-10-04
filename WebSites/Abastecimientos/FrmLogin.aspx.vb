Imports SladeHome.SimpleCrypto
'INGRESO AL SISTEMA
'CUA0001 SEGURIDAD
'Ing. Yessenia Pennelope Henriquez Duran
'solicita usuario y clave para ingreso al sistema de abstedimiento
Partial Class FrmLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clave As String
        Dim encrypted As String
        encrypted = Crypto.EncryptTripleDES("passwd", "ABAS") 'encripta la clave ingresada en formato MD5
        clave = Crypto.GetMD5Hash(encrypted)


        'Me.Label1.Text = User.Identity.Name.ToLower 'Request.QueryString("U")
        If Not Session.IsNewSession Then

            Session.Abandon()
        End If
    End Sub

End Class
