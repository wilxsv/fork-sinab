Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleESTABLECIMIENTOS
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cESTABLECIMIENTOS
    Private mEntidad As ESTABLECIMIENTOS

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

    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int32)
            Me._IDESTABLECIMIENTO = value
            CargarDDLs()
            If Me._IDESTABLECIMIENTO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
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
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New ESTABLECIMIENTOS

        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO

        If mComponente.ObtenerESTABLECIMIENTOS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtCODIGOESTABLECIMIENTO.Text = mEntidad.CODIGOESTABLECIMIENTO
        Me.ddlMUNICIPIOS1.SelectedValue = mEntidad.IDMUNICIPIO
        Me.ddlTIPOESTABLECIMIENTOS1.SelectedValue = mEntidad.IDTIPOESTABLECIMIENTO
        Me.ddlZONAS1.SelectedValue = mEntidad.IDZONA
        Me.ddlINSTITUCIONES1.SelectedValue = mEntidad.IDINSTITUCION
        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.txtDIRECCION.Text = mEntidad.DIRECCION
        If mEntidad.TELEFONO = Nothing Then Me.nbTELEFONO.Text = "" Else Me.nbTELEFONO.Text = mEntidad.TELEFONO
        If mEntidad.FAX = Nothing Then Me.nbFAX.Text = "" Else Me.nbFAX.Text = mEntidad.FAX
        Me.ddlESTABLECIMIENTOS1.SelectedValue = mEntidad.IDPADRE
        Me.ddlNIVEL.SelectedValue = mEntidad.NIVEL
        Me.ddlTIPOCONSUMO.SelectedValue = mEntidad.TIPOCONSUMO

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtCODIGOESTABLECIMIENTO.Enabled = edicion
        Me.ddlMUNICIPIOS1.Enabled = edicion
        Me.ddlTIPOESTABLECIMIENTOS1.Enabled = edicion
        Me.ddlZONAS1.Enabled = edicion
        Me.ddlINSTITUCIONES1.Enabled = edicion
        Me.txtNOMBRE.Enabled = edicion
        Me.txtDIRECCION.Enabled = edicion
        Me.nbTELEFONO.Enabled = edicion
        Me.nbFAX.Enabled = edicion
        Me.ddlESTABLECIMIENTOS1.Enabled = edicion
        Me.ddlNIVEL.Enabled = edicion
        Me.ddlTIPOCONSUMO.Enabled = edicion
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

        mEntidad = New ESTABLECIMIENTOS

        If Me._nuevo Then
            mEntidad.IDESTABLECIMIENTO = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.CODIGOESTABLECIMIENTO = Me.txtCODIGOESTABLECIMIENTO.Text
        mEntidad.IDMUNICIPIO = Me.ddlMUNICIPIOS1.SelectedValue
        mEntidad.IDTIPOESTABLECIMIENTO = Me.ddlTIPOESTABLECIMIENTOS1.SelectedValue
        mEntidad.IDZONA = Me.ddlZONAS1.SelectedValue
        mEntidad.IDINSTITUCION = Me.ddlINSTITUCIONES1.SelectedValue
        mEntidad.NOMBRE = Me.txtNOMBRE.Text
        mEntidad.DIRECCION = Me.txtDIRECCION.Text
        mEntidad.TELEFONO = Me.nbTELEFONO.Text
        mEntidad.FAX = Me.nbFAX.Text
        mEntidad.IDPADRE = Me.ddlESTABLECIMIENTOS1.SelectedValue
        mEntidad.NIVEL = Me.ddlNIVEL.SelectedValue
        mEntidad.TIPOCONSUMO = Me.ddlTIPOCONSUMO.SelectedValue
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarESTABLECIMIENTOS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Protected Sub ddlNIVEL_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNIVEL.SelectedIndexChanged

        Select Case ddlNIVEL.SelectedValue
            Case 1
                Me.ddlTIPOCONSUMO.SelectedValue = "M"
            Case 2, 3
                Me.ddlTIPOCONSUMO.SelectedValue = "D"
        End Select

    End Sub

    Private Sub CargarDDLs()
        Me.ddlMUNICIPIOS1.RecuperarNombreMunicipio()
        Me.ddlTIPOESTABLECIMIENTOS1.Recuperar()
        Me.ddlZONAS1.Recuperar()
        Me.ddlINSTITUCIONES1.Recuperar()
        Me.ddlESTABLECIMIENTOS1.Recuperar()
    End Sub

End Class
