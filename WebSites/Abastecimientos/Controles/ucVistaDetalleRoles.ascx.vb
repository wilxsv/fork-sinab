'Mantenimiento de roles
'CUA0003 seguridad
'Ing. Yessenia Pennelope Henriquez Duran
'control de usuario para la creacion y mantenimiento de roles del sistema
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleRoles
    Inherits System.Web.UI.UserControl

    'declarar e inicializar variables
    Private _IDROL As Integer
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime
    Private _sError As String
    Private _nuevo As Boolean = False
    Private mComponente As New cROLES
    Private mEntidad As ROLES

    Public Event ErrorEvent(ByVal errorMessage As String)

    'declarar propiedades
#Region " Propiedades "

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDROL() As Integer
        Get
            Return Me._IDROL
        End Get
        Set(ByVal Value As Integer)
            Me._IDROL = Value
            If Me._IDROL > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDROL") Is Nothing Then Me.ViewState.Remove("IDROL")
            Me.ViewState.Add("IDROL", Value)
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

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina
        If Page.IsPostBack Then 'la primera vez
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDROL") Is Nothing Then Me._IDROL = Me.ViewState("IDROL")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

        Me.txtNOMBRE.Focus()
    End Sub

    Private Sub CargarDatos()
        'carga datos existentes
        mEntidad = New ROLES
        mEntidad.IDROL = Me.IDROL

        If mComponente.ObtenerROLES(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            Return
        End If

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.txtDESCRIPCION.Text = mEntidad.DESCRIPCION

        Me.cbxESTADO.Checked = IIf(mEntidad.ESTAHABILITADO = 1, True, False)

    End Sub

    Private Sub Nuevo() 'nevo
        Me._nuevo = True
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

        Me.cbxESTADO.Checked = False
    End Sub

    Public Function Actualizar() As String
        'actualiza los datos del registro
        mEntidad = New ROLES

        If Me._nuevo Then 'nuevo
            mEntidad.IDROL = 0

            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
            mEntidad.AUUSUARIOMODIFICACION = Nothing
            mEntidad.AUFECHAMODIFICACION = Nothing
        Else 'existe
            mEntidad.IDROL = Me.IDROL

            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.NOMBRE = Me.txtNOMBRE.Text
        mEntidad.DESCRIPCION = Me.txtDESCRIPCION.Text
        mEntidad.ESTAHABILITADO = IIf(Me.cbxESTADO.Checked, 1, 0)

        mEntidad.ESTASINCRONIZADA = 0
        'actualiza
        If mComponente.ActualizarROLES(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

End Class
