Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleCLAUSULAS
    Inherits System.Web.UI.UserControl

    Private _IDCLAUSULA As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime
    Private _IDMODALIDADCOMPRA As Int16

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cCLAUSULAS
    Private mEntidad As CLAUSULAS

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

    Public Property IDCLAUSULA() As Int32
        Get
            Return _IDCLAUSULA
        End Get
        Set(ByVal value As Int32)
            Me._IDCLAUSULA = value
            If Me._IDCLAUSULA > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            CargarEtiquetas()
            If Not Me.ViewState("IDCLAUSULA") Is Nothing Then Me.ViewState.Remove("IDCLAUSULA")
            Me.ViewState.Add("IDCLAUSULA", value)
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

    Public Property IDMODALIDADCOMPRA() As Int32
        Get
            Return _IDMODALIDADCOMPRA
        End Get
        Set(ByVal value As Int32)
            Me._IDMODALIDADCOMPRA = value
            If Not Me.ViewState("IDMODALIDADCOMPRA") Is Nothing Then Me.ViewState.Remove("IDMODALIDADCOMPRA")
            Me.ViewState.Add("IDMODALIDADCOMPRA", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDCLAUSULA") Is Nothing Then Me._IDCLAUSULA = Me.ViewState("IDCLAUSULA")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
            If Not Me.ViewState("IDMODALIDADCOMPRA") Is Nothing Then Me._IDMODALIDADCOMPRA = Me.ViewState("IDMODALIDADCOMPRA")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New CLAUSULAS

        mEntidad.IDCLAUSULA = IDCLAUSULA

        If mComponente.ObtenerCLAUSULAS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.rteCONTENIDO.Text = mEntidad.CONTENIDO
        Me.cbESREQUERIDA.Checked = IIf(mEntidad.ESREQUERIDA = 1, True, False)
        Me.cbMODIFICATIVA.Checked = IIf(mEntidad.MODIFICATIVA = 1, True, False)

        Me.IDMODALIDADCOMPRA = mEntidad.IDMODALIDADCOMPRA

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtNOMBRE.Enabled = edicion
        Me.rteCONTENIDO.ReadOnly = Not edicion
        Me.rteCONTENIDO.HideToolBars = Not edicion
        Me.cbESREQUERIDA.Enabled = edicion
        Me.cbMODIFICATIVA.Enabled = edicion
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

        mEntidad = New CLAUSULAS

        If Me._nuevo Then
            mEntidad.IDCLAUSULA = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDCLAUSULA = Me.IDCLAUSULA
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.NOMBRE = Me.txtNOMBRE.Text
        mEntidad.CONTENIDO = Me.rteCONTENIDO.Text
        mEntidad.ESREQUERIDA = IIf(Me.cbESREQUERIDA.Checked, 1, 0)
        mEntidad.MODIFICATIVA = IIf(Me.cbMODIFICATIVA.Checked, 1, 0)
        mEntidad.IDMODALIDADCOMPRA = Me.IDMODALIDADCOMPRA
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarCLAUSULAS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarEtiquetas()
        Dim cEC As New cETIQUETASCLAUSULAS
        Me.gvEtiqueta.DataSource = cEC.ObtenerLista()
        Me.gvEtiqueta.DataBind()
    End Sub

End Class
