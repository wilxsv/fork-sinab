Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleESPECIFICOSGASTO
    Inherits System.Web.UI.UserControl

    Private _IDESPECIFICOGASTO As Int16

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cESPECIFICOSGASTO
    Private mEntidad As ESPECIFICOSGASTO

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

    Public Property IDESPECIFICOGASTO() As Int16
        Get
            Return Me._IDESPECIFICOGASTO
        End Get
        Set(ByVal value As Int16)
            Me._IDESPECIFICOGASTO = value
            If Me._IDESPECIFICOGASTO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDESPECIFICOGASTO") Is Nothing Then Me.ViewState.Remove("IDESPECIFICOGASTO")
            Me.ViewState.Add("IDESPECIFICOGASTO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDESPECIFICOGASTO") Is Nothing Then Me._IDESPECIFICOGASTO = Me.ViewState("IDESPECIFICOGASTO")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New ESPECIFICOSGASTO

        mEntidad.IDESPECIFICOGASTO = IDESPECIFICOGASTO

        If mComponente.ObtenerESPECIFICOGASTO(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtCODIGO.Text = mEntidad.CODIGO
        Me.txtNOMBRE.Text = mEntidad.NOMBRE

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtCODIGO.Enabled = edicion
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

        If mComponente.BuscarCodigo(Me.txtCODIGO.Text, Me.IDESPECIFICOGASTO) = 0 Then
            Return "El código ya existe."
        End If

        mEntidad = New ESPECIFICOSGASTO

        If Me._nuevo Then
            mEntidad.IDESPECIFICOGASTO = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now
        Else
            mEntidad.IDESPECIFICOGASTO = Me.IDESPECIFICOGASTO
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now
        End If

        mEntidad.CODIGO = Me.txtCODIGO.Text
        mEntidad.NOMBRE = Me.txtNOMBRE.Text
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarESPECIFICOGASTO(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

End Class
