Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleTIPOTRANSACCIONES
    Inherits System.Web.UI.UserControl

    Private _IDTIPOTRANSACCION As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cTIPOTRANSACCIONES
    Private mEntidad As TIPOTRANSACCIONES

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

    Public Property IDTIPOTRANSACCION() As Int32
        Get
            Return _IDTIPOTRANSACCION
        End Get
        Set(ByVal value As Int32)
            Me._IDTIPOTRANSACCION = value
            If Me._IDTIPOTRANSACCION > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDTIPOTRANSACCION") Is Nothing Then Me.ViewState.Remove("IDTIPOTRANSACCION")
            Me.ViewState.Add("IDTIPOTRANSACCION", value)
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
            If Not Me.ViewState("IDTIPOTRANSACCION") Is Nothing Then Me._IDTIPOTRANSACCION = Me.ViewState("IDTIPOTRANSACCION")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New TIPOTRANSACCIONES

        mEntidad.IDTIPOTRANSACCION = IDTIPOTRANSACCION

        If mComponente.ObtenerTIPOTRANSACCIONES(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtIDTIPOTRANSACCION.Text = IDTIPOTRANSACCION
        Me.txtDESCRIPCION.Text = mEntidad.DESCRIPCION
        Me.ddlAFECTAINVENTARIO.SelectedValue = mEntidad.AFECTAINVENTARIO

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

        Me.lblIDTIPOTRANSACCION.Visible = False
        Me.txtIDTIPOTRANSACCION.Visible = False
        Me.ddlAFECTAINVENTARIO.Enabled = True

    End Sub

    Public Function Actualizar() As String

        mEntidad = New TIPOTRANSACCIONES

        If Me._nuevo Then
            mEntidad.IDTIPOTRANSACCION = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDTIPOTRANSACCION = Me.IDTIPOTRANSACCION
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.DESCRIPCION = Me.txtDESCRIPCION.Text
        mEntidad.AFECTAINVENTARIO = Me.ddlAFECTAINVENTARIO.SelectedValue
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarTIPOTRANSACCIONES(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

End Class
