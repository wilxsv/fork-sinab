Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleSUMINISTROS
    Inherits System.Web.UI.UserControl

    Private _IDSUMINISTRO As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cSUMINISTROS
    Private mEntidad As SUMINISTROS

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
            If Me._IDSUMINISTRO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDSUMINISTRO") Is Nothing Then Me.ViewState.Remove("IDSUMINISTRO")
            Me.ViewState.Add("IDSUMINISTRO", value)
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
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New SUMINISTROS

        mEntidad.IDSUMINISTRO = IDSUMINISTRO

        If mComponente.ObtenerSUMINISTROS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlTIPOSUMINISTROS1.SelectedValue = mEntidad.IDTIPOSUMINISTRO
        Me.txtCORRELATIVO.Text = mEntidad.CORRELATIVO
        Me.txtCORRELATIVO.ReadOnly = True
        Me.txtDESCRIPCION.Text = mEntidad.DESCRIPCION
        Me.txtMONTODISPONIBLE.Text = mEntidad.MONTODISPONIBLE
        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlTIPOSUMINISTROS1.Enabled = edicion
        Me.txtCORRELATIVO.Enabled = edicion
        Me.txtDESCRIPCION.Enabled = edicion
        Me.txtMONTODISPONIBLE.Enabled = edicion
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

        If mComponente.BuscarTSuministrosCorrelativo(Me.ddlTIPOSUMINISTROS1.SelectedValue, Me.txtCORRELATIVO.Text) = 0 Then
            Return "El Correlativo para este suministro ya existe."
        End If

        mEntidad = New SUMINISTROS

        If Me._nuevo Then
            mEntidad.IDSUMINISTRO = 0
            mEntidad.MONTODISPONIBLE = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDSUMINISTRO = Me.IDSUMINISTRO
            mEntidad.MONTODISPONIBLE = Val(Me.txtMONTODISPONIBLE.Text)
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.IDTIPOSUMINISTRO = Me.ddlTIPOSUMINISTROS1.SelectedValue
        mEntidad.CORRELATIVO = Me.txtCORRELATIVO.Text
        mEntidad.DESCRIPCION = Me.txtDESCRIPCION.Text
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarSUMINISTROS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarDDLs()
        Me.ddlTIPOSUMINISTROS1.Recuperar()
    End Sub

End Class
