Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleEMPLEADOSALMACEN
    Inherits System.Web.UI.UserControl

    Private _IDALMACEN As Int32
    Private _IDEMPLEADO As Int32

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cEMPLEADOSALMACEN
    Private mEntidad As EMPLEADOSALMACEN

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

    Public Property IDALMACEN() As Int32
        Get
            Return Me._IDALMACEN
        End Get
        Set(ByVal value As Int32)
            Me._IDALMACEN = value
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.ViewState.Remove("IDALMACEN")
            Me.ViewState.Add("IDALMACEN", value)
        End Set
    End Property

    Public Property IDEMPLEADO() As Int32
        Get
            Return _IDEMPLEADO
        End Get
        Set(ByVal value As Int32)
            Me._IDEMPLEADO = value
            CargarDDLs()
            If Me._IDEMPLEADO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDEMPLEADO") Is Nothing Then Me.ViewState.Remove("IDEMPLEADO")
            Me.ViewState.Add("IDEMPLEADO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me._IDALMACEN = Me.ViewState("IDALMACEN")
            If Not Me.ViewState("IDEMPLEADO") Is Nothing Then Me._IDEMPLEADO = Me.ViewState("IDEMPLEADO")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New EMPLEADOSALMACEN

        mEntidad.IDALMACEN = Me.IDALMACEN
        mEntidad.IDEMPLEADO = Me.IDEMPLEADO

        If mComponente.ObtenerEMPLEADOSALMACEN(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlALMACENES1.SelectedValue = mEntidad.IDALMACEN
        Me.ddlALMACENES1.Enabled = False
        Me.ddlEMPLEADOS1.SelectedValue = mEntidad.IDEMPLEADO
        Me.ddlEMPLEADOS1.Enabled = False
        Me.cbxESGUARDAALMACEN.Checked = IIf(mEntidad.ESGUARDAALMACEN = 1, True, False)
        Me.ddlSUMINISTROS1.SelectedValue = mEntidad.IDSUMINISTRO

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlALMACENES1.Enabled = edicion
        Me.ddlEMPLEADOS1.Enabled = edicion
        Me.cbxESGUARDAALMACEN.Enabled = edicion
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

        mEntidad = New EMPLEADOSALMACEN

        mEntidad.IDALMACEN = Me.ddlALMACENES1.SelectedValue
        mEntidad.IDEMPLEADO = Me.ddlEMPLEADOS1.SelectedValue

        If Me._nuevo Then

            If mComponente.BuscarEmpleadosAlmacen(mEntidad.IDEMPLEADO, mEntidad.IDALMACEN) = 0 Then
                Return "El empleado para este almacén ya existe"
            End If

            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now
        Else
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now
        End If

        mEntidad.ESGUARDAALMACEN = IIf(Me.cbxESGUARDAALMACEN.Checked, 1, 0)
        mEntidad.ESTASINCRONIZADA = 0
        mEntidad.IDSUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue

        If Me._nuevo Then
            If mComponente.AgregarEMPLEADOSALMACEN(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If
        Else
            If mComponente.ActualizarEMPLEADOSALMACEN(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If
        End If

        Return ""

    End Function

    Private Sub CargarDDLs()
        Me.ddlALMACENES1.RecuperarListaOrdenada(1)
        Me.ddlEMPLEADOS1.RecuperarNombreCompleto()
        Me.ddlSUMINISTROS1.RecuperarOrdenadaPorCorrelativo()
    End Sub

End Class
