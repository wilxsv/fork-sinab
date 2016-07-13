Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleSUMINISTROSHOMOGENEOS
    Inherits System.Web.UI.UserControl

    Private _IDSUMINISTRO As Int32
    Private _IDSUMINISTROHOMOGENEO As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cSUMINISTROSHOMOGENEOS
    Private mEntidad As SUMINISTROSHOMOGENEOS

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

    Public Property IDSUMINISTRO() As Int32
        Get
            Return _IDSUMINISTRO
        End Get
        Set(ByVal value As Int32)
            Me._IDSUMINISTRO = value
        End Set
    End Property

    Public Property IDSUMINISTROHOMOGENEO() As Int32
        Get
            Return Me._IDSUMINISTROHOMOGENEO
        End Get
        Set(ByVal value As Int32)
            Me._IDSUMINISTROHOMOGENEO = value
            CargarDDLs()
            If Me._IDSUMINISTROHOMOGENEO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
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
            If Not Me.ViewState("IDSUMINISTRO") Is Nothing Then Me._IDSUMINISTRO = Me.ViewState("IDSUMINISTRO")
            If Not Me.ViewState("IDSUMINISTROHOMOGENEO") Is Nothing Then Me._IDSUMINISTROHOMOGENEO = Me.ViewState("IDSUMINISTROHOMOGENEO")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New SUMINISTROSHOMOGENEOS

        mEntidad.IDSUMINISTRO = IDSUMINISTRO
        mEntidad.IDSUMINISTROHOMOGENEO = IDSUMINISTROHOMOGENEO

        If mComponente.ObtenerSuministrosHomogeneos(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlSUMINISTROS.SelectedValue = mEntidad.IDSUMINISTRO
        Me.ddlSUMINISTROS1.SelectedValue = mEntidad.IDSUMINISTROHOMOGENEO

        Me.ddlSUMINISTROS.Enabled = False
        Me.ddlSUMINISTROS1.Enabled = False

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlSUMINISTROS.Enabled = edicion
        Me.ddlSUMINISTROS1.Enabled = edicion
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

        mEntidad = New SUMINISTROSHOMOGENEOS

        mEntidad.IDSUMINISTROHOMOGENEO = Me.ddlSUMINISTROS.SelectedValue
        mEntidad.IDSUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue
        mEntidad.ESTASINCRONIZADA = 0

        If Me._nuevo Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()

            If mComponente.AgregarSUMINISTROSHOMOGENEOS(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If

        Else
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()

            If mComponente.ActualizarSUMINISTROSHOMOGENEOS(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If

        End If

        Return ""

    End Function

    Private Sub CargarDDLs()
        Me.ddlSUMINISTROS.Recuperar()
        Me.ddlSUMINISTROS1.Recuperar()
    End Sub

End Class
