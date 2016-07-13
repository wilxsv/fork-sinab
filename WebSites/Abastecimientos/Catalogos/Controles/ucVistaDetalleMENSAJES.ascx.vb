Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleMENSAJES
    Inherits System.Web.UI.UserControl

    Private _IDMENSAJE As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cMENSAJES
    Private mEntidad As MENSAJES

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

    Public Property IDMENSAJE() As Int32
        Get
            Return _IDMENSAJE
        End Get
        Set(ByVal value As Int32)
            Me._IDMENSAJE = value
            If Me._IDMENSAJE > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDMENSAJE") Is Nothing Then Me.ViewState.Remove("IDMENSAJE")
            Me.ViewState.Add("IDMENSAJE", value)
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
            If Not Me.ViewState("IDMENSAJE") Is Nothing Then Me._IDMENSAJE = Me.ViewState("IDMENSAJE")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New MENSAJES

        mEntidad.IDMENSAJE = IDMENSAJE

        If mComponente.ObtenerMENSAJES(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtMENSAJE.Text = mEntidad.MENSAJE
        Me.txtFECHAINICIO.Text = mEntidad.FECHAINICIO
        'Me.txtFECHAFIN = mEntidad.FECHAFIN

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtMENSAJE.Enabled = edicion
        Me.txtFECHAINICIO.Enabled = edicion
        Me.txtFECHAFIN.Enabled = edicion
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

        mEntidad = New MENSAJES

        If Me._nuevo Then
            mEntidad.IDMENSAJE = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDMENSAJE = Me.IDMENSAJE
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.MENSAJE = Me.txtMENSAJE.Text
        mEntidad.FECHAINICIO = Format(Me.txtFECHAINICIO.SelectedDate, "dd/MM/yyyy")
        mEntidad.FECHAFIN = Format(Me.txtFECHAFIN.SelectedDate, "dd/MM/yyyy")

        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarMENSAJE(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

End Class
