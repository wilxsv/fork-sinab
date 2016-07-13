Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleTIPOCOMPRAS
    Inherits System.Web.UI.UserControl

    Private _IDTIPOCOMPRA As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cTIPOCOMPRAS
    Private mEntidad As TIPOCOMPRAS

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

    Public Property IDTIPOCOMPRA() As Int32
        Get
            Return _IDTIPOCOMPRA
        End Get
        Set(ByVal value As Int32)
            Me._IDTIPOCOMPRA = value
            CargarDLLS()
            If Me._IDTIPOCOMPRA > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDTIPOCOMPRA") Is Nothing Then Me.ViewState.Remove("IDTIPOCOMPRA")
            Me.ViewState.Add("IDTIPOCOMPRA", value)
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
            If Not Me.ViewState("IDTIPOCOMPRA") Is Nothing Then Me._IDTIPOCOMPRA = Me.ViewState("IDTIPOCOMPRA")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New TIPOCOMPRAS

        mEntidad.IDTIPOCOMPRA = IDTIPOCOMPRA

        If mComponente.ObtenerTIPOCOMPRAS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlMODALIDADESCOMPRA1.SelectedValue = mEntidad.IDMODALIDADCOMPRA
        Me.ddlMODALIDADESCOMPRA1.Enabled = False
        Me.txtDESCRIPCION.Text = mEntidad.DESCRIPCION
        Me.txtMIN.Text = mEntidad.MIN
        Me.txtMAX.Text = mEntidad.MAX
        Me.cbREQUIERECALIFICACION.Checked = IIf(mEntidad.REQUIERECALIFICACION = 1, True, False)
        Me.txtPREFIJOBASE.Text = mEntidad.PREFIJOBASE

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlMODALIDADESCOMPRA1.Enabled = edicion
        Me.txtDESCRIPCION.Enabled = edicion
        Me.txtMIN.Enabled = edicion
        Me.txtMAX.Enabled = edicion
        Me.cbREQUIERECALIFICACION.Enabled = edicion
        Me.txtPREFIJOBASE.Enabled = edicion
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

        If Val(Me.txtMIN.Text) >= Val(Me.txtMAX.Text) Then
            Return "El valor MÍNIMO no puede ser mayor o igual al MÁXIMO."
        End If

        mEntidad = New TIPOCOMPRAS

        If Me._nuevo Then
            mEntidad.IDTIPOCOMPRA = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDTIPOCOMPRA = IDTIPOCOMPRA
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.IDMODALIDADCOMPRA = Me.ddlMODALIDADESCOMPRA1.SelectedValue
        mEntidad.DESCRIPCION = Me.txtDESCRIPCION.Text
        mEntidad.MIN = Val(Me.txtMIN.Text)
        mEntidad.MAX = Val(Me.txtMAX.Text)
        mEntidad.REQUIERECALIFICACION = IIf(Me.cbREQUIERECALIFICACION.Checked, 1, 0)
        mEntidad.PREFIJOBASE = Me.txtPREFIJOBASE.Text
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarTIPOCOMPRAS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarDLLS()
        Me.ddlMODALIDADESCOMPRA1.Recuperar()
    End Sub

End Class
