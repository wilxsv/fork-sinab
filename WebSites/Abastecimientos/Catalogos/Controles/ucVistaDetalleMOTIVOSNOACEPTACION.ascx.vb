Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleMOTIVOSNOACEPTACION
    Inherits System.Web.UI.UserControl

    Private _IDMOTIVONOACEPTACION As Int16
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cMOTIVOSNOACEPTACION
    Private mEntidad As MOTIVOSNOACEPTACION

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

    Public Property IDMOTIVONOACEPTACION() As Int16
        Get
            Return Me._IDMOTIVONOACEPTACION
        End Get
        Set(ByVal value As Int16)
            Me._IDMOTIVONOACEPTACION = value
            If Me._IDMOTIVONOACEPTACION > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDMOTIVONOACEPTACION") Is Nothing Then Me.ViewState.Remove("IDMOTIVONOACEPTACION")
            Me.ViewState.Add("IDMOTIVONOACEPTACION", value)
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
            If Not Me.ViewState("IDMOTIVONOACEPTACION") Is Nothing Then Me._IDMOTIVONOACEPTACION = Me.ViewState("IDMOTIVONOACEPTACION")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New MOTIVOSNOACEPTACION

        mEntidad.IDMOTIVONOACEPTACION = IDMOTIVONOACEPTACION

        If mComponente.ObtenerMOTIVOSNOACEPTACION(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener registro.")
            Return
        End If

        Me.txtDESCRIPCION.Text = mEntidad.DESCRIPCION

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
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

        If mComponente.BuscarDescripcion(Me.txtDESCRIPCION.Text, Me.IDMOTIVONOACEPTACION) Then
            Return "Este motivo ya se ha agregado."
        End If

        mEntidad = New MOTIVOSNOACEPTACION

        If Me._nuevo Then
            mEntidad.IDMOTIVONOACEPTACION = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDMOTIVONOACEPTACION = Me.IDMOTIVONOACEPTACION
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.DESCRIPCION = Me.txtDESCRIPCION.Text
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarMOTIVOSNOACEPTACION(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

End Class
