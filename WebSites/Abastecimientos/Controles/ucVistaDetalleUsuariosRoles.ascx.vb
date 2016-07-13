Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleUsuariosRoles
    Inherits System.Web.UI.UserControl

    Private _IDROL As Int32
    Private _ROL As String

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cROLESUSUARIOS
    Private mEntidad As ROLESUSUARIOS

    Public Event ErrorEvent(ByVal errorMessage As String)

    Public Event InhabilitarGuardar()

#Region " Propiedades "

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDROL() As Int32
        Get
            Return Me._IDROL
        End Get
        Set(ByVal Value As Int32)
            Me._IDROL = Value
            Me.CargarDatos()
            Me.Nuevo()
            If Not Me.ViewState("IDROL") Is Nothing Then Me.ViewState.Remove("IDROL")
            Me.ViewState.Add("IDROL", Value)
        End Set
    End Property

    Public Property ROL() As String
        Get
            Return Me._ROL
        End Get
        Set(ByVal Value As String)
            Me._ROL = Value
            If Not Me.ViewState("ROL") Is Nothing Then Me.ViewState.Remove("ROL")
            Me.ViewState.Add("ROL", Value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDROL") Is Nothing Then Me._IDROL = Me.ViewState("IDROL")
            If Not Me.ViewState("ROL") Is Nothing Then Me._ROL = Me.ViewState("ROL")
        End If

        Me.txtROL.Text = Me.ROL

    End Sub

    Private Sub CargarDatos()

        Me.ddlUSUARIOS1.RecuperarUsuariosSinRol()

        If Me.ddlUSUARIOS1.Items.Count = 0 Then
            Me.ddlUSUARIOS1.Visible = False
            Me.txtUSUARIO.Visible = True
            Me.txtUSUARIO.Text = "A todos los usuarios se les ha asignado un rol."

            RaiseEvent InhabilitarGuardar()
        Else
            Me.ddlUSUARIOS1.SelectedIndex = 0
        End If

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

        If Me.ddlUSUARIOS1.Items.Count = 0 Then
            Return "A todos los usuarios se les ha asignado un rol."
        Else

            mEntidad = New ROLESUSUARIOS

            mEntidad.IDROL = Me.IDROL
            mEntidad.IDUSUARIO = Me.ddlUSUARIOS1.SelectedValue

            If Me._nuevo Then
                mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                mEntidad.AUFECHACREACION = Now()
                mEntidad.AUUSUARIOMODIFICACION = Nothing
                mEntidad.AUFECHAMODIFICACION = Nothing
            Else
                mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                mEntidad.AUFECHAMODIFICACION = Now()
            End If

            mEntidad.ESTASINCRONIZADA = 0

            If mComponente.AgregarROLESUSUARIOS(mEntidad) = 1 Then
                Return ""
            Else
                Return "Error al guardar el registro."
            End If

        End If

    End Function

End Class
