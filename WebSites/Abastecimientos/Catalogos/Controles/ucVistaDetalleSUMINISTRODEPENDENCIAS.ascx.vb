Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleSUMINISTRODEPENDENCIAS
    Inherits System.Web.UI.UserControl

    Private _IDSUMINISTRO As Int32
    Private _IDDEPENDENCIA As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cSUMINISTRODEPENDENCIAS
    Private mEntidad As SUMINISTRODEPENDENCIAS

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

    Public Property IDDEPENDENCIA() As Int32
        Get
            Return Me._IDDEPENDENCIA
        End Get
        Set(ByVal value As Int32)
            Me._IDDEPENDENCIA = value
            If Me._IDDEPENDENCIA > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDDEPENDENCIA") Is Nothing Then Me.ViewState.Remove("IDDEPENDENCIA")
            Me.ViewState.Add("IDDEPENDENCIA", value)
        End Set
    End Property

    Public Property IDSUMINISTRO() As Int32
        Get
            Return _IDSUMINISTRO
        End Get
        Set(ByVal value As Int32)
            Me._IDSUMINISTRO = value
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
            If Not Me.ViewState("IDDEPENDENCIA") Is Nothing Then Me._IDDEPENDENCIA = Me.ViewState("IDDEPENDENCIA")
            If Not Me.ViewState("IDSUMINISTRO") Is Nothing Then Me._IDSUMINISTRO = Me.ViewState("IDSUMINISTRO")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New SUMINISTRODEPENDENCIAS

        mEntidad.IDDEPENDENCIA = IDDEPENDENCIA
        mEntidad.IDSUMINISTRO = IDSUMINISTRO

        If mComponente.ObtenerSUMINISTRODEPENDENCIAS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlDEPENDENCIAS1.SelectedValue = mEntidad.IDDEPENDENCIA
        Me.ddlSUMINISTROS1.SelectedValue = mEntidad.IDSUMINISTRO

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlDEPENDENCIAS1.Enabled = edicion
    End Sub

    Private Sub Nuevo()

        Me._nuevo = True

        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

        Me.ddlSUMINISTROS1.SelectedValue = Me.IDSUMINISTRO.ToString()

    End Sub

    Public Function Actualizar() As String

        If mComponente.BuscarSuministrosDependencias(Me.ddlSUMINISTROS1.SelectedValue, Me.ddlDEPENDENCIAS1.SelectedValue) = 0 Then
            Return "El Producto para este Programa ya existe"
        End If

        mEntidad = New SUMINISTRODEPENDENCIAS

        mEntidad.IDDEPENDENCIA = Me.ddlDEPENDENCIAS1.SelectedValue
        mEntidad.IDSUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue

        If Me._nuevo Then
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
            If mComponente.AgregarSUMINISTRODEPENDENCIAS(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If
        Else
            If mComponente.ActualizarSUMINISTRODEPENDENCIAS(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If
        End If

        Return ""

    End Function

    Private Sub CargarDDLs()
        Me.ddlDEPENDENCIAS1.Recuperar()
        Me.ddlSUMINISTROS1.Recuperar()
    End Sub

End Class
