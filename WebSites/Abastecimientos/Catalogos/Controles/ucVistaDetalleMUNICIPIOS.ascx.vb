Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleMUNICIPIOS
    Inherits System.Web.UI.UserControl

    Private _IDMUNICIPIO As Int16
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cMUNICIPIOS
    Private mEntidad As MUNICIPIOS

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

    Public Property IDMUNICIPIO() As Int16
        Get
            Return _IDMUNICIPIO
        End Get
        Set(ByVal value As Int16)
            Me._IDMUNICIPIO = value
            Me.CargarDDLs()
            If Me._IDMUNICIPIO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDMUNICIPIO") Is Nothing Then Me.ViewState.Remove("IDMUNICIPIO")
            Me.ViewState.Add("IDMUNICIPIO", value)
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
            If Not Me.ViewState("IDMUNICIPIO") Is Nothing Then Me._IDMUNICIPIO = Me.ViewState("IDMUNICIPIO")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New MUNICIPIOS

        mEntidad.IDMUNICIPIO = IDMUNICIPIO

        If mComponente.ObtenerMUNICIPIOS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtCODIGOMUNICIPIO.Text = mEntidad.CODIGOMUNICIPIO
        Me.ddlDEPARTAMENTOS1.SelectedValue = mEntidad.IDDEPARTAMENTO
        Me.txtNOMBRE.Text = mEntidad.NOMBRE

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtCODIGOMUNICIPIO.Enabled = edicion
        Me.ddlDEPARTAMENTOS1.Enabled = edicion
        Me.txtNOMBRE.Enabled = edicion
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

        If Me.mComponente.VALIDARNOMBRE(Me.txtNOMBRE.Text, Me.IDMUNICIPIO) = 1 Then
            Return "El nombre del municipio ya existe."
        End If

        mEntidad = New MUNICIPIOS

        If Me._nuevo Then
            mEntidad.IDMUNICIPIO = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDMUNICIPIO = Me.IDMUNICIPIO
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.CODIGOMUNICIPIO = Me.txtCODIGOMUNICIPIO.Text
        mEntidad.IDDEPARTAMENTO = Me.ddlDEPARTAMENTOS1.SelectedValue
        mEntidad.NOMBRE = Me.txtNOMBRE.Text
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarMUNICIPIOS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarDDLs()
        Me.ddlDEPARTAMENTOS1.Recuperar()
    End Sub

End Class
