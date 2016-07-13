'INGRESO AL SISTEMA
'CU SEGURIDAD
'Ing. Yessenia Pennelope Henriquez Duran
'solicita usuario y clave para ingreso al sistema de abastecimiento
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Security.Cryptography
Imports System.Security.Authentication
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports SladeHome.SimpleCrypto  'libreria utilizada para encriptar clave

Partial Class ucLogin
    Inherits System.Web.UI.UserControl

    'inicializar variables
    Private miLogin As New cLogin


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'evento cargar pagina
        '  Me.txtUSUARIO.Focus()

        'If Not Page.IsPostBack Then ' la primera vez que la carga
        '    If Not Request.Cookies("Me.txtUsuario") Is Nothing Then
        '        Dim useridwrk As HttpCookie = Request.Cookies("Me.txtUsuario")
        '        Me.txtUSUARIO.Text = Server.HtmlEncode(useridwrk.Value)
        '    End If
        'End If

        If Not IsPostBack Then
            Me.txtUSUARIO.Focus()
        End If

    End Sub

    Protected Sub btnIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        ' evento al presionar ingresar

        Dim clave As String
        Dim encrypted As String
        encrypted = Crypto.EncryptTripleDES(Me.txtCLAVE.Text, "ABAS") 'encripta la clave ingresada en formato MD5
        clave = Crypto.GetMD5Hash(encrypted)

        Dim EsComisionAltoNivel As Boolean = False

        Try
            If Membresia.ValidarUsuario(txtUSUARIO.Text.ToLower, clave, EsComisionAltoNivel) Then ' valida nombre y clave de usuario
                If Request.QueryString("ReturnUrl") <> Nothing Then
                    FormsAuthentication.RedirectFromLoginPage(Me.txtUSUARIO.Text.ToLower, False)
                Else
                    FormsAuthentication.RedirectFromLoginPage(Me.txtUSUARIO.Text.ToLower, False)
                End If
                Dim redirect As String = "~/FrmPrincipal.aspx"
                If Me.txtCLAVE.Text.ToLower = "inicio" Then
                    Session("_popup_newpsw") = True
                    redirect = "~/seguridad/FrmChangePassword.aspx"

                End If
                Response.Redirect(redirect, False)
            Else
                MostrarError("Verifique usuario y/o clave. Acceso denegado.") ' fallo autenticacion
            End If
        Catch ex As AuthenticationException
            MostrarError(ex.Message) 'no tiene un Establecimiento asociado
        Catch ex As Exception
            MostrarError("Error: " + ex.Message + " Contacte al servicio de soporte") ' error de base de datos
        End Try

    End Sub

    Public Sub MostrarError(ByVal mensaje As String)
        FailureText.Text = mensaje ' error de base de datos
        divError.Visible = True
        txtCLAVE.Text = String.Empty
        txtCLAVE.Focus()
    End Sub

    'Public Function Amd5(ByVal cadena As String) As String
    '    Dim md5 = New MD5CryptoServiceProvider()

    '    Dim bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(cadena & "ABAS"))
    '    Dim sBuilder As New StringBuilder()
    '    'Return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(bytes).ToLower(), "-", "")     'devuelve el hash continuo y en minuscula. (igual que en php)
    '    For i As Integer = 0 To bytes.Length - 1
    '        sBuilder.Append(bytes(i).ToString("x2"))
    '    Next
    '    Return sBuilder.ToString()
    'End Function


End Class
