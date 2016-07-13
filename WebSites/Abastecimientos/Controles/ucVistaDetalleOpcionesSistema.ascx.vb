'Mantenimiento de opciones del sistema
'CUA0002 seguridad
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario para la creacion y mantenimiento de opciones del sistema

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleOpcionesSistema
    Inherits System.Web.UI.UserControl

    'declarar e inicalizar variables
    Private _IDOPCIONSISTEMA As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime
    Private _sError As String
    Private _nuevo As Boolean = False
    Private mComponente As New cOPCIONESSISTEMA
    Private mEntidad As OPCIONESSISTEMA

    Public Event ErrorEvent(ByVal errorMessage As String)

    'declarar propiedades
#Region " Propiedades "

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDOPCIONSISTEMA() As Int32
        Get
            Return Me._IDOPCIONSISTEMA
        End Get
        Set(ByVal Value As Int32)
            Me._IDOPCIONSISTEMA = Value
            CargarDDLs()
            If Me._IDOPCIONSISTEMA > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDOPCIONSISTEMA") Is Nothing Then Me.ViewState.Remove("IDOPCIONSISTEMA")
            Me.ViewState.Add("IDOPCIONSISTEMA", Value)
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

        If Page.IsPostBack Then
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDOPCIONSISTEMA") Is Nothing Then Me._IDOPCIONSISTEMA = Me.ViewState("IDOPCIONSISTEMA")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos() 'a la cargar datos cuando ya existe

        mEntidad = New OPCIONESSISTEMA
        mEntidad.IDOPCIONSISTEMA = Me.IDOPCIONSISTEMA

        If mComponente.ObtenerOPCIONESSISTEMA(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            Return
        End If

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

        Me.txtDESCRIPCION.Text = mEntidad.DESCRIPCION
        Me.txtURL.Text = mEntidad.URL

        Me.ddlOPCIONESSISTEMA1.SelectedValue = mEntidad.IDPADRE

        Me.cbxESTADO.Checked = IIf(mEntidad.ESTAHABILITADO = 1, True, False)

    End Sub

    Private Sub Nuevo() 'nuevo registro
        Me._nuevo = True
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

        Me.cbxESTADO.Checked = False
    End Sub

    Public Function Actualizar() As String
        'al momento de actualizar registro
        mEntidad = New OPCIONESSISTEMA

        If Me._nuevo Then 'nuevo
            mEntidad.IDOPCIONSISTEMA = 0

            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
            mEntidad.AUUSUARIOMODIFICACION = Nothing
            mEntidad.AUFECHAMODIFICACION = Nothing
        Else 'existe
            mEntidad.IDOPCIONSISTEMA = Me.IDOPCIONSISTEMA

            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.DESCRIPCION = Me.txtDESCRIPCION.Text
        mEntidad.URL = Me.txtURL.Text
        mEntidad.ESTAHABILITADO = IIf(Me.cbxESTADO.Checked, 1, 0)
        mEntidad.IDPADRE = Me.ddlOPCIONESSISTEMA1.SelectedValue

        mEntidad.ESTASINCRONIZADA = 0
        'actualiza
        If mComponente.ActualizarOPCIONESSISTEMA(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarDDLs()
        If Not IsPostBack Then
            ddlOPCIONESSISTEMA1.RecuperarPadres()
        End If
    End Sub

End Class
