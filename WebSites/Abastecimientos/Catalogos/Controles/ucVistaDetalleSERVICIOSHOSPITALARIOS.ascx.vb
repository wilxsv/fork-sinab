Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleSERVICIOSHOSPITALARIOS
    Inherits System.Web.UI.UserControl

    Private _IDSERVICIOHOSPITALARIO As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cSERVICIOSHOSPITALARIOS
    Private mEntidad As SERVICIOSHOSPITALARIOS

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

    Public Property IDSERVICIOHOSPITALARIO() As Int32
        Get
            Return _IDSERVICIOHOSPITALARIO
        End Get
        Set(ByVal value As Int32)
            Me._IDSERVICIOHOSPITALARIO = value
            If Me._IDSERVICIOHOSPITALARIO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDSERVICIOHOSPITALARIO") Is Nothing Then Me.ViewState.Remove("IDSERVICIOHOSPITALARIO")
            Me.ViewState.Add("IDSERVICIOHOSPITALARIO", value)
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
            If Not Me.ViewState("IDSERVICIOHOSPITALARIO") Is Nothing Then Me._IDSERVICIOHOSPITALARIO = Me.ViewState("IDSERVICIOHOSPITALARIO")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New SERVICIOSHOSPITALARIOS

        mEntidad.IDSERVICIOHOSPITALARIO = IDSERVICIOHOSPITALARIO

        If mComponente.ObtenerSERVICIOSHOSPITALARIOS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlESTABLECIMIENTOS1.SelectedValue = mEntidad.IDESTABLECIMIENTO
        Me.txtCODIGOSERVICIO.Text = mEntidad.CODIGOSERVICIO
        Me.txtNOMBRESERVICIO.Text = mEntidad.NOMBRESERVICIO

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlESTABLECIMIENTOS1.Enabled = edicion
        Me.txtCODIGOSERVICIO.Enabled = edicion
        Me.txtNOMBRESERVICIO.Enabled = edicion
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

        If mComponente.BuscarEstablecimientocodigo(Me.ddlESTABLECIMIENTOS1.SelectedValue, Me.txtCODIGOSERVICIO.Text) = 0 Then
            Return "El código para este establecimiento ya existe"
        End If

        mEntidad = New SERVICIOSHOSPITALARIOS

        If Me._nuevo Then
            mEntidad.IDSERVICIOHOSPITALARIO = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDSERVICIOHOSPITALARIO = Me.IDSERVICIOHOSPITALARIO
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
        mEntidad.CODIGOSERVICIO = Me.txtCODIGOSERVICIO.Text
        mEntidad.NOMBRESERVICIO = Me.txtNOMBRESERVICIO.Text
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarSERVICIOSHOSPITALARIOS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarDDLs()
        Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
    End Sub

End Class
