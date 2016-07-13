Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleEMPLEADOS
    Inherits System.Web.UI.UserControl

    Private _IDEMPLEADO As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cEMPLEADOS
    Private mEntidad As EMPLEADOS

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

    Public Property IDEMPLEADO() As Int32
        Get
            Return _IDEMPLEADO
        End Get
        Set(ByVal value As Int32)
            Me._IDEMPLEADO = value
            Me.RecuperarDDLs()
            If Me._IDEMPLEADO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDEMPLEADO") Is Nothing Then Me.ViewState.Remove("IDEMPLEADO")
            Me.ViewState.Add("IDEMPLEADO", value)
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
            If Not Me.ViewState("IDEMPLEADO") Is Nothing Then Me._IDEMPLEADO = Me.ViewState("IDEMPLEADO")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New EMPLEADOS

        mEntidad.IDEMPLEADO = IDEMPLEADO

        If mComponente.ObtenerEMPLEADOS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtNOMBRECORTO.Text = mEntidad.NOMBRECORTO
        Me.txtNOMBRECORTO.ReadOnly = True
        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.txtAPELLIDO.Text = mEntidad.APELLIDO
        Me.cbxTITULAR.Checked = IIf(mEntidad.TITULAR = 1, True, False)
        Me.ddlCARGOS1.SelectedValue = mEntidad.IDCARGO
        Me.ddlESTABLECIMIENTOS1.SelectedValue = mEntidad.IDESTABLECIMIENTO
        Me.ddlDEPENDENCIAS1.SelectedValue = mEntidad.IDDEPENDENCIA

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtNOMBRECORTO.Enabled = edicion
        Me.txtNOMBRE.Enabled = edicion
        Me.txtAPELLIDO.Enabled = edicion
        Me.cbxTITULAR.Enabled = edicion
        Me.ddlCARGOS1.Enabled = edicion
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

        Me.cbxTITULAR.Checked = False

        Me.txtNOMBRECORTO.ReadOnly = False

    End Sub

    Public Function Actualizar() As String

        If mComponente.BuscarNombreCorto(Me.txtNOMBRECORTO.Text, Me.IDEMPLEADO) = 0 Then
            Return "El código MSPAS ya existe."
        End If

        mEntidad = New EMPLEADOS

        If Me._nuevo Then
            mEntidad.IDEMPLEADO = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDEMPLEADO = Me.IDEMPLEADO
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.NOMBRECORTO = Me.txtNOMBRECORTO.Text
        mEntidad.NOMBRE = Me.txtNOMBRE.Text
        mEntidad.APELLIDO = Me.txtAPELLIDO.Text
        mEntidad.IDCARGO = Me.ddlCARGOS1.SelectedValue
        mEntidad.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
        mEntidad.IDDEPENDENCIA = Me.ddlDEPENDENCIAS1.SelectedValue
        mEntidad.TITULAR = IIf(Me.cbxTITULAR.Checked, 1, 0)
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarEMPLEADOS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Public Sub RecuperarDDLs()
        Me.ddlCARGOS1.RecuperarOrdenada(1)
        Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1) '1 ASC, 0 DESC
        Me.ddlDEPENDENCIAS1.RecuperarOrdenada(1)
    End Sub

End Class
