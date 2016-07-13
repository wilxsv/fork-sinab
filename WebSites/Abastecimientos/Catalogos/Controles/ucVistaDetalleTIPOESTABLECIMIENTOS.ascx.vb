Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleTIPOESTABLECIMIENTOS
    Inherits System.Web.UI.UserControl

    Private _IDTIPOESTABLECIMIENTO As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cTIPOESTABLECIMIENTOS
    Private mEntidad As TIPOESTABLECIMIENTOS

    Public Event ErrorEvent(ByVal errorMessage As String)

#Region " Propiedades "

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal value As Boolean)
            Me.HabilitarEdicion(value)
        End Set
    End Property

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDTIPOESTABLECIMIENTO() As Int32
        Get
            Return _IDTIPOESTABLECIMIENTO
        End Get
        Set(ByVal value As Int32)
            Me._IDTIPOESTABLECIMIENTO = value
            If Me._IDTIPOESTABLECIMIENTO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDTIPOESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDTIPOESTABLECIMIENTO")
            Me.ViewState.Add("IDTIPOESTABLECIMIENTO", value)
        End Set
    End Property

    Public Property AUUSUARIOCREACION() As String
        Get
            Return Me._AUUSUARIOCREACION
        End Get
        Set(ByVal value As String)
            Me._AUUSUARIOCREACION = value
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me.ViewState.Remove("AUUSUARIOCREACION")
            Me.ViewState.Add("AUUSUARIOCREACION", value)
        End Set
    End Property

    Public Property AUFECHACREACION() As DateTime
        Get
            Return Me._AUFECHACREACION
        End Get
        Set(ByVal value As DateTime)
            Me._AUFECHACREACION = value
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me.ViewState.Remove("AUFECHACREACION")
            Me.ViewState.Add("AUFECHACREACION", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDTIPOESTABLECIMIENTO") Is Nothing Then Me._IDTIPOESTABLECIMIENTO = Me.ViewState("IDTIPOESTABLECIMIENTO")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New TIPOESTABLECIMIENTOS

        mEntidad.IDTIPOESTABLECIMIENTO = IDTIPOESTABLECIMIENTO

        If mComponente.ObtenerTIPOESTABLECIMIENTOS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtNOMBRECORTO.Text = mEntidad.NOMBRECORTO
        Me.txtDESCRIPCION.Text = mEntidad.DESCRIPCION

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtNOMBRECORTO.Enabled = edicion
        Me.txtDESCRIPCION.Enabled = edicion
    End Sub

    Private Sub Nuevo()

        Me._nuevo = True

        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

    End Sub

    Public Function Actualizar() As String

        If Me.mComponente.VALIDARDESCRIPCION(Me.txtDESCRIPCION.Text, Me.IDTIPOESTABLECIMIENTO) = 0 Then
            Return "Descripción ya existe."
        End If

        mEntidad = New TIPOESTABLECIMIENTOS

        If Me._nuevo Then
            mEntidad.IDTIPOESTABLECIMIENTO = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDTIPOESTABLECIMIENTO = Me.IDTIPOESTABLECIMIENTO
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.NOMBRECORTO = Me.txtNOMBRECORTO.Text
        mEntidad.DESCRIPCION = Me.txtDESCRIPCION.Text
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarTIPOESTABLECIMIENTOS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

End Class
