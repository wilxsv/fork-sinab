Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleNIVELESUSOESTABLECIMIENTOS
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Int32
    Private _IDNIVELUSO As Byte
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cNIVELESUSOESTABLECIMIENTOS
    Private mEntidad As NIVELESUSOESTABLECIMIENTOS

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

    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int32)
            Me._IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property

    Public Property IDNIVELUSO() As Byte
        Get
            Return _IDNIVELUSO
        End Get
        Set(ByVal value As Byte)
            Me._IDNIVELUSO = value
            CargarDDLs()
            If Me._IDNIVELUSO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDNIVELUSO") Is Nothing Then Me.ViewState.Remove("IDNIVELUSO")
            Me.ViewState.Add("IDNIVELUSO", value)
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
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDNIVELUSO") Is Nothing Then Me._IDNIVELUSO = Me.ViewState("IDNIVELUSO")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New NIVELESUSOESTABLECIMIENTOS

        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        mEntidad.IDNIVELUSO = IDNIVELUSO

        If mComponente.ObtenerNIVELESUSOESTABLECIMIENTOS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlESTABLECIMIENTOS1.SelectedValue = mEntidad.IDESTABLECIMIENTO
        Me.ddlESTABLECIMIENTOS1.Enabled = False

        Me.ddlNIVELESUSO1.SelectedValue = mEntidad.IDNIVELUSO
        Me.ddlNIVELESUSO1.Enabled = False

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub Nuevo()

        Me._nuevo = True

        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlESTABLECIMIENTOS1.Enabled = edicion
        Me.ddlNIVELESUSO1.Enabled = edicion
    End Sub

    Public Function Actualizar() As String

        mEntidad = New NIVELESUSOESTABLECIMIENTOS

        mEntidad.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
        mEntidad.IDNIVELUSO = Me.ddlNIVELESUSO1.SelectedValue

        If Me._nuevo Then
            If mComponente.BuscarNivelUsoEstablecimiento(mEntidad.IDESTABLECIMIENTO, mEntidad.IDNIVELUSO) = True Then
                Return "El Suministro para este Establecimiento ya existe"
            End If

            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.ESTASINCRONIZADA = 0

        If Me._nuevo Then
            If mComponente.AgregarNIVELESUSOESTABLECIMIENTOS(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If
        Else
            If mComponente.ActualizarNIVELESUSOESTABLECIMIENTOS(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If
        End If

        Return ""

    End Function

    Private Sub CargarDDLs()
        Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
        Me.ddlNIVELESUSO1.Recuperar()
    End Sub

End Class
