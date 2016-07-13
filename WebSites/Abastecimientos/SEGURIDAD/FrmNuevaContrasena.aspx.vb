Imports ABASTECIMIENTOS.NEGOCIO
Imports SladeHome.SimpleCrypto

Partial Class FrmNuevaContrasena
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim clave As String
        Dim encrypted As String
        encrypted = Crypto.EncryptTripleDES(Me.TextBox2.Text, "ABAS") 'encripta la clave ingresada en formato MD5
        clave = Crypto.GetMD5Hash(encrypted)

        Dim c As New cUSUARIOS

        Try
            Dim idUsuario As String = c.DatosUsuarios(Me.Label1.Text)

            If Not idUsuario = 0 Then
                c.ActualizarClave(idUsuario, clave)
                Me.Label2.Text = "La contraseña ha sido actualizada. Intente ingresar nuevamente con su nueva contraseña."
                Me.Panel1.Visible = False
            Else
                Me.Label2.Text = "Usuario no existe."
            End If

        Catch ex As Exception
            Me.Label2.Text = "Ocurrio un error. Intente nuevamente"
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label1.Text = User.Identity.Name.ToLower 'Request.QueryString("U")
    End Sub

End Class
