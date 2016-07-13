Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleUNIDADMEDIDAS
    Inherits System.Web.UI.UserControl

    Private _IDUNIDADMEDIDA As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cUNIDADMEDIDAS
    Private mEntidad As UNIDADMEDIDAS

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

    Public Property IDUNIDADMEDIDA() As Int32
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal value As Int32)
            Me._IDUNIDADMEDIDA = value
            If Me._IDUNIDADMEDIDA > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me.ViewState.Remove("IDUNIDADMEDIDA")
            Me.ViewState.Add("IDUNIDADMEDIDA", value)
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
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me._IDUNIDADMEDIDA = Me.ViewState("IDUNIDADMEDIDA")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New UNIDADMEDIDAS

        mEntidad.IDUNIDADMEDIDA = IDUNIDADMEDIDA

        If mComponente.ObtenerUNIDADMEDIDAS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtDESCRIPCION.Text = mEntidad.DESCRIPCION
        Me.txtDESCRIPCIONLARGA.Text = mEntidad.DESCRIPCIONLARGA
        Me.txtUNIDADESCONTENIDAS.Text = mEntidad.UNIDADESCONTENIDAS
        If mEntidad.UNIDADESCONTENIDAS = Nothing Then Me.txtUNIDADESCONTENIDAS.Text = "" Else Me.txtUNIDADESCONTENIDAS.Text = mEntidad.UNIDADESCONTENIDAS
        Me.txtCANTIDADDECIMAL.Text = mEntidad.CANTIDADDECIMAL
        If mEntidad.CANTIDADDECIMAL = Nothing Then Me.txtCANTIDADDECIMAL.Text = "" Else Me.txtCANTIDADDECIMAL.Text = mEntidad.CANTIDADDECIMAL

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtDESCRIPCION.Enabled = edicion
        Me.txtDESCRIPCIONLARGA.Enabled = edicion
        Me.txtUNIDADESCONTENIDAS.Enabled = edicion
        Me.txtCANTIDADDECIMAL.Enabled = edicion
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

        'validar nombre corto
        If Me.mComponente.VALIDARDESCRIPCION(txtDESCRIPCION.Text, Me.IDUNIDADMEDIDA) = 0 Then
            Return "El nombre corto ya existe."
        End If

        'validar descripcion larga
        If Me.mComponente.VALIDARDESCRIPCIONLARGA(txtDESCRIPCIONLARGA.Text, Me.IDUNIDADMEDIDA) = 0 Then
            Return "La descripción ya existe."
        End If

        mEntidad = New UNIDADMEDIDAS

        If Me._nuevo Then
            mEntidad.IDUNIDADMEDIDA = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDUNIDADMEDIDA = Me.IDUNIDADMEDIDA
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.DESCRIPCION = Me.txtDESCRIPCION.Text
        mEntidad.DESCRIPCIONLARGA = Me.txtDESCRIPCIONLARGA.Text
        mEntidad.UNIDADESCONTENIDAS = Val(Me.txtUNIDADESCONTENIDAS.Text)
        mEntidad.CANTIDADDECIMAL = Me.txtCANTIDADDECIMAL.Text
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarUNIDADMEDIDAS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

End Class
