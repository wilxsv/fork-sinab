Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleDEPENDENCIAESTABLECIMIENTOS
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Int32
    Private _IDDEPENDENCIA As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cDEPENDENCIAESTABLECIMIENTOS
    Private mEntidad As DEPENDENCIAESTABLECIMIENTOS

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

    Public Property IDDEPENDENCIA() As Int32
        Get
            Return _IDDEPENDENCIA
        End Get
        Set(ByVal value As Int32)
            Me._IDDEPENDENCIA = value
            CargarDDLs()
            If Me._IDDEPENDENCIA > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDDEPENDENCIA") Is Nothing Then Me.ViewState.Remove("IDDEPENDENCIA")
            Me.ViewState.Add("IDDEPENDENCIA", value)
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
            If Not Me.ViewState("IDDEPENDENCIA") Is Nothing Then Me._IDDEPENDENCIA = Me.ViewState("IDDEPENDENCIA")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New DEPENDENCIAESTABLECIMIENTOS

        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        mEntidad.IDDEPENDENCIA = IDDEPENDENCIA

        If mComponente.ObtenerDEPENDENCIAESTABLECIMIENTOS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlESTABLECIMIENTOS1.SelectedValue = mEntidad.IDESTABLECIMIENTO
        Me.ddlESTABLECIMIENTOS1.Enabled = False
        Me.ddlDEPENDENCIAS1.SelectedValue = mEntidad.IDDEPENDENCIA
        Me.ddlDEPENDENCIAS1.Enabled = False

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlESTABLECIMIENTOS1.Enabled = edicion
        Me.ddlDEPENDENCIAS1.Enabled = edicion
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

        mEntidad = New DEPENDENCIAESTABLECIMIENTOS

        mEntidad.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
        mEntidad.IDDEPENDENCIA = Me.ddlDEPENDENCIAS1.SelectedValue

        If Me._nuevo Then
            If mComponente.BuscarEstablecimientoDependencia(mEntidad.IDESTABLECIMIENTO, mEntidad.IDDEPENDENCIA) = 0 Then
                Return "La dependencia para este establecimiento ya existe."
            End If

            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHAMODIFICACION = Me.AUFECHACREACION
        End If

        mEntidad.ESTASINCRONIZADA = 0

        If Me._nuevo Then
            If mComponente.AgregarDEPENDENCIAESTABLECIMIENTOS(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If
        Else
            If mComponente.ActualizarDEPENDENCIAESTABLECIMIENTOS(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If
        End If

        Return ""

    End Function

    Private Sub CargarDDLs()
        Me.ddlDEPENDENCIAS1.RecuperarOrdenada(1)
        Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
    End Sub

End Class
