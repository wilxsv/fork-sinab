'Mantenimiento de usuarios
'CUA0004 seguridad
'Ing. Yessenia Pennelope Henriquez Duran
'control de usuario para la creacion y mantenimiento de usuarios del sistema

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SladeHome.SimpleCrypto

Partial Class ucVistaDetalleUsuarios
    Inherits System.Web.UI.UserControl

    'declarar variables y eventos
    Private _IDUSUARIO As Integer
    Private _IDEMPLEADO As Integer
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _CambioClave As Boolean = False
    Private _sError As String
    Private _nuevo As Boolean = False
    Private mComponente As New cUSUARIOS
    Private mEntidad As USUARIOS

    Public Event ErrorEvent(ByVal errorMessage As String)
    Public Event InhabilitarGuardar()

    'declarar propiedades
#Region " Propiedades "

    Public ReadOnly Property sError() As String 'manejo de error
        Get
            Return _sError
        End Get
    End Property

    Public Property IDUSUARIO() As Integer 'identificador de usuario
        Get
            Return Me._IDUSUARIO
        End Get
        Set(ByVal Value As Integer)
            Me._IDUSUARIO = Value
            If Me._IDUSUARIO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDUSUARIO") Is Nothing Then Me.ViewState.Remove("IDUSUARIO")
            Me.ViewState.Add("IDUSUARIO", Value)
        End Set
    End Property

    Public Property IDEMPLEADO() As Integer 'identificador de empleado
        Get
            Return Me._IDEMPLEADO
        End Get
        Set(ByVal Value As Integer)
            Me._IDEMPLEADO = Value
            If Not Me.ViewState("IDEMPLEADO") Is Nothing Then Me.ViewState.Remove("IDEMPLEADO")
            Me.ViewState.Add("IDEMPLEADO", Value)
        End Set
    End Property

    Public Property AUUSUARIOCREACION() As String 'usuario creación
        Get
            Return Me._AUUSUARIOCREACION
        End Get
        Set(ByVal Value As String)
            Me._AUUSUARIOCREACION = Value
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me.ViewState.Remove("AUUSUARIOCREACION")
            Me.ViewState.Add("AUUSUARIOCREACION", Value)
        End Set
    End Property

    Public Property AUFECHACREACION() As DateTime 'fecha creación
        Get
            Return Me._AUFECHACREACION
        End Get
        Set(ByVal Value As DateTime)
            Me._AUFECHACREACION = Value
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me.ViewState.Remove("AUFECHACREACION")
            Me.ViewState.Add("AUFECHACREACION", Value)
        End Set
    End Property

    Public Property CambioClave() As Boolean 'camio de clave
        Get
            Return Me._CambioClave
        End Get
        Set(ByVal Value As Boolean)
            Me._CambioClave = Value
            If Not Me.ViewState("CambioClave") Is Nothing Then Me.ViewState.Remove("CambioClave")
            Me.ViewState.Add("CambioClave", Value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'al momento de cargar pagina 
        If IsPostBack Then 'la primera vez
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("CambioClave") Is Nothing Then Me._CambioClave = Me.ViewState("CambioClave")
            If Not Me.ViewState("IDUSUARIO") Is Nothing Then Me._IDUSUARIO = Me.ViewState("IDUSUARIO")
            If Not Me.ViewState("IDEMPLEADO") Is Nothing Then Me._IDEMPLEADO = Me.ViewState("IDEMPLEADO")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        Else
            If Not _nuevo Then 'nuevo registro
                Me.CambioClave = False
                Me.lnkEstablecerClave.Visible = True
                Me.lblClave.Visible = False
                Me.lblConfirmaClave.Visible = False
                Me.txtClave.Visible = False
                Me.txtConfirmaClave.Visible = False
                Me.rfvClave.Visible = False
                Me.rfvConfirmaClave.Visible = False
                Me.cvClaveConfirmaClave.Visible = False
            Else
                If Me.ddlEMPLEADOS1.Items.Count > 0 Then
                    Me.CambioClave = True
                    Me.lnkEstablecerClave.Visible = False
                    Me.lblClave.Visible = True
                    Me.lblConfirmaClave.Visible = True
                    Me.txtClave.Visible = True
                    Me.txtConfirmaClave.Visible = True
                    Me.rfvClave.Visible = True
                    Me.rfvConfirmaClave.Visible = True
                    Me.cvClaveConfirmaClave.Visible = True
                Else
                    Me.lblEMPLEADO.Visible = False
                End If
            End If
        End If

        Me.txtUSUARIO.Focus()

    End Sub

    Private Sub CargarDatos()
        ' carga los datos si el usrio existe
        mEntidad = New USUARIOS
        mEntidad.IDUSUARIO = Me.IDUSUARIO

        If mComponente.ObtenerUsuarioConNombreEmpleado(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            Return
        End If

        Me.IDEMPLEADO = mEntidad.IDEMPLEADO
        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

        Me.txtUSUARIO.Text = mEntidad.USUARIO

        If mEntidad.IDEMPLEADO = 0 Then
            Me.txtEMPLEADO.Text = "El usuario no se encuentra asignado a ningún empleado."
        Else
            Me.txtEMPLEADO.Text = mEntidad.NOMBRE
        End If

        Me.cbxESTADO.Checked = IIf(mEntidad.ESTAHABILITADO = 1, True, False)

    End Sub

    Private Sub Nuevo()
        ' si es nuevo
        Me._nuevo = True

        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

        Me.cbxESTADO.Checked = False

        RecuperarEmpleadosSinUsuario()
    End Sub

    Public Function Actualizar() As String
        'al momento de guardar el usuario

        Dim hashed As String
        Dim encrypted As String

        If Not ValidarUsuario() Then
            Return "El usuario ingresado no es correcto."
        End If

        mEntidad = New USUARIOS

        If Me._nuevo Then

            If Me.ddlEMPLEADOS1.Items.Count = 0 Then
                Return "A todos los empleados se les ha asignado usuario."
            Else
                mEntidad.IDUSUARIO = 0
                mEntidad.IDEMPLEADO = CInt(Me.ddlEMPLEADOS1.SelectedValue)
            End If

            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
            mEntidad.AUUSUARIOMODIFICACION = Nothing
            mEntidad.AUFECHAMODIFICACION = Nothing
        Else
            mEntidad.IDUSUARIO = Me.IDUSUARIO
            mEntidad.IDEMPLEADO = Me.IDEMPLEADO

            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.USUARIO = Me.txtUSUARIO.Text

        If Me.CambioClave Then 'encriptado de llave
            encrypted = Crypto.EncryptTripleDES(Me.txtClave.Text, "ABAS")
            hashed = Crypto.GetMD5Hash(encrypted)
            mEntidad.CLAVE = hashed
        End If

        mEntidad.ESTAHABILITADO = IIf(Me.cbxESTADO.Checked, 1, 0)

        mEntidad.ESTASINCRONIZADA = 0

        Dim result As Integer

        If Me.CambioClave Then
            result = mComponente.ActualizarUSUARIOS(mEntidad)
        Else
            result = mComponente.ActualizarUSUARIOSSinClave(mEntidad)
        End If

        If result = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro.  Verifique que el usuario ingresado no exista."
        End If

    End Function

    Protected Sub lnkEstablecerClave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEstablecerClave.Click
        'evento cambiar clave
        Me.CambioClave = Not Me.CambioClave

        If Me.CambioClave Then
            Me.lnkEstablecerClave.Text = "Cancelar establecer clave"
            Me.lblClave.Visible = True
            Me.lblConfirmaClave.Visible = True
            Me.txtClave.Visible = True
            Me.txtConfirmaClave.Visible = True
            Me.rfvClave.Visible = True
            Me.rfvConfirmaClave.Visible = True
            Me.cvClaveConfirmaClave.Visible = True
        Else
            Me.lnkEstablecerClave.Text = "Establecer clave"
            Me.lblClave.Visible = False
            Me.lblConfirmaClave.Visible = False
            Me.txtClave.Visible = False
            Me.txtConfirmaClave.Visible = False
            Me.rfvClave.Visible = False
            Me.rfvConfirmaClave.Visible = False
            Me.cvClaveConfirmaClave.Visible = False
        End If

    End Sub

    Private Sub RecuperarEmpleadosSinUsuario()
        'funcion para recuperar aquello empleados que no se les asignado un usuario

        Me.ddlEMPLEADOS1.RecuperarNombreCompletoEmpleadosSinUsuario()

        If Me.ddlEMPLEADOS1.Items.Count = 0 Then

            Me.lblUSUARIO.Visible = False
            Me.txtUSUARIO.Visible = False
            Me.rfvUSUARIO.Visible = False

            Me.lblEMPLEADO.Visible = False
            Me.ddlEMPLEADOS1.Visible = False
            Me.txtEMPLEADO.Visible = False

            Me.lblESTAHABILITADO.Visible = False
            Me.cbxESTADO.Visible = False

            Me.lnkEstablecerClave.Visible = False

            Me.lblClave.Visible = False
            Me.txtClave.Visible = False
            Me.rfvClave.Visible = False

            Me.lblConfirmaClave.Visible = False
            Me.txtConfirmaClave.Visible = False
            Me.rfvConfirmaClave.Visible = False

            Me.cvClaveConfirmaClave.Visible = False

            Me.lblNoEmpleados.Visible = True

            RaiseEvent InhabilitarGuardar()
        Else
            Me.ddlEMPLEADOS1.Visible = True
            Me.txtEMPLEADO.Visible = False
            Me.lblNoEmpleados.Visible = False
        End If

    End Sub

    Public Function ValidarUsuario() As Boolean
        'validacion de caracteres permitidos en el nombre de usuario
        If Me.txtUSUARIO.Visible And Me.txtUSUARIO.Text.Length > 0 Then
            If Regex.IsMatch(Me.txtUSUARIO.Text, "[u,U][s,S][r,R][c,C][o,O][m,M][e,E][0-9]+[p,P][0-9]+") Then
                Return False
            Else
                Return True
            End If
        End If

        Return False

    End Function

End Class
