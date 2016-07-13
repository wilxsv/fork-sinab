Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetallePRODUCTOSPROGRAMAS
    Inherits System.Web.UI.UserControl

    Private _IDPRODUCTO As Int64
    Private _IDPROGRAMA As Int16
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cPRODUCTOSPROGRAMAS
    Private mEntidad As PRODUCTOSPROGRAMAS

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

    Public Property IDPRODUCTO() As Int64
        Get
            Return Me._IDPRODUCTO
        End Get
        Set(ByVal value As Int64)
            Me._IDPRODUCTO = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property

    Public Property IDPROGRAMA() As Int16
        Get
            Return _IDPROGRAMA
        End Get
        Set(ByVal value As Int16)
            Me._IDPROGRAMA = value
            CargarDDLs()
            If Me._IDPROGRAMA > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDPROGRAMA") Is Nothing Then Me.ViewState.Remove("IDPROGRAMA")
            Me.ViewState.Add("IDPROGRAMA", value)
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
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("IDPROGRAMA") Is Nothing Then Me._IDPROGRAMA = Me.ViewState("IDPROGRAMA")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New PRODUCTOSPROGRAMAS

        mEntidad.IDPRODUCTO = IDPRODUCTO
        mEntidad.IDPROGRAMA = IDPROGRAMA

        If mComponente.ObtenerPRODUCTOSPROGRAMAS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlCATALOGOPRODUCTOS1.SelectedValue = mEntidad.IDPRODUCTO
        Me.ddlCATALOGOPRODUCTOS1.Enabled = True
        Me.ddlPROGRAMAS1.SelectedValue = mEntidad.IDPROGRAMA
        Me.ddlPROGRAMAS1.Enabled = True

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlCATALOGOPRODUCTOS1.Enabled = True
        Me.ddlPROGRAMAS1.Enabled = True
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

        mEntidad = New PRODUCTOSPROGRAMAS

        mEntidad.IDPRODUCTO = Me.ddlCATALOGOPRODUCTOS1.SelectedValue
        mEntidad.IDPROGRAMA = Me.ddlPROGRAMAS1.SelectedValue

        If Me._nuevo Then
            If mComponente.BuscarProductosProgramas(mEntidad.IDPRODUCTO, mEntidad.IDPROGRAMA) = 0 Then
                Return "El producto ya se encuentra asociado al programa."
            End If

            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.ESTASINCRONIZADA = 0

        If Me._nuevo Then
            If mComponente.AgregarPRODUCTOSPROGRAMAS(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If
        Else
            If mComponente.ActualizarPRODUCTOSPROGRAMAS(mEntidad) <> 1 Then
                Return "Error al guardar el registro."
            End If
        End If

        Return ""

    End Function

    Private Sub CargarDDLs()
        Dim IDSUMINISTRO As Integer = 1

        Me.ddlCATALOGOPRODUCTOS1.RecuperarDescripcionLargo(IDSUMINISTRO)
        Me.ddlPROGRAMAS1.Recuperar()
    End Sub

End Class
