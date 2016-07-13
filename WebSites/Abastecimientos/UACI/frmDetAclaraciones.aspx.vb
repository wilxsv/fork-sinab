Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils

Partial Class frmDetACLARACIONES
    Inherits System.Web.UI.Page

    Private _IDACLARACION As Int32
    Private _sError As String
    Private _nuevo As Boolean = True
    Private mComponente As New cACLARACIONES
    Private mEntidad As ACLARACIONES
    Public Event ErrorEvent(ByVal errorMessage As String)

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDACLARACION() As Integer
        Get
            'If Me.TxtACLARACION.Text = "" Then
            '    Me.TxtACLARACION.Text = "0"
            'End If
            Return CInt(Me.TxtACLARACION.Text)
        End Get
        Set(ByVal Value As Integer)
            Me._IDACLARACION = Value
            Me.TxtACLARACION.Text = CStr(Value)
            'Me.RecuperarDDLs()
            If Me._IDACLARACION > 0 Then
                Me.ViewState("edicion") = 1
                Me.CargarDatos()
            Else
                Me.ViewState("edicion") = 0
                Me.Nuevo()
            End If
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
        Else
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDACLARACION") Is Nothing Then Me._IDACLARACION = Me.ViewState("IDACLARACION")
        End If

        'Me.ucBarraNavegacion1.PermitirEditar = True
        'Me.ucBarraNavegacion1.PermitirImprimir = False
        'Me.ucBarraNavegacion1.PermitirConsultar = False
        'Me.ucBarraNavegacion1.Navegacion = False
        'Me.ucBarraNavegacion1.PermitirAgregar = False

        Dim ds As New Data.DataSet
        Dim cPC As New cPROCESOCOMPRAS
        cPC.ObtenerCodigoyTipoLicitacion(Session("idestablecimiento"), Session("IdProcesoCompra"), ds)
        Me.Label3.Text = ds.Tables(0).Rows(0).Item(1)
    End Sub

    Private Sub CargarDatos()
        mEntidad = New ACLARACIONES
        mEntidad.IDACLARACION = IDACLARACION

        Me.Label3.Text = Session("IdProcesoCompra")
        Me.TxtACLARACION.Text = mEntidad.IDACLARACION
        Me.TxtNumeroAclaracion.Text = mEntidad.NUMEROACLARACION
        Me.Texdetalle.Text = mEntidad.DETALLEACLARACION
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

        mEntidad = New ACLARACIONES
        Dim a, b As Integer
        a = Session("idestablecimiento")
        b = Session("IdProcesoCompra")
        If Me._nuevo Then
            mEntidad.IDACLARACION = 0
            mEntidad.IDESTABLECIMIENTO = Session("idestablecimiento")
            mEntidad.IDPROCESOCOMPRA = Session("IdProcesoCompra")
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.FECHAACLARACION = Now()
            mEntidad.DETALLEACLARACION = Me.Texdetalle.Text
            mEntidad.NUMEROACLARACION = Me.TxtNumeroAclaracion.Text

        Else
            'mEntidad.IDEMPLEADO = CInt(Me.txtIDEMPLEADO.Text)
            'mEntidad.NOMBRECORTO = Me.lblNOMBRECORTO1.Text
            'mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            'mEntidad.AUFECHAMODIFICACION = Now()
        End If

        If mComponente.Actualizar(mEntidad) <> 1 Then
            Return "Error al Guardar registro."
        End If

        Return ""
    End Function


    Protected Sub btGuardar_Click(sender As Object, e As System.EventArgs) Handles btGuardar.Click
        Dim sError As String
        If Me.TxtNumeroAclaracion.Text = "" Then
            MessageBox.Alert("El registro no se guardo, falta el Número de ACLARACION", "Alerta")
        Else
            sError = Me.Actualizar()
            If sError <> "" Then
                MessageBox.Alert(sError, "Alerta")
                Return
            End If
        End If

        btGuardar.Enabled = False
    End Sub

    Protected Sub btCancelar_Click(sender As Object, e As System.EventArgs) Handles btCancelar.Click
        Response.Redirect("~/UACI/frmGenerarACLARACIONES.aspx")
    End Sub




    Private Function obtenerModalidad() As Integer
        Dim mComponente As New cMODALIDADESCOMPRA
        Dim ds As Data.DataSet
        ds = mComponente.obtenerModalidadCompra(Session("IdProcesoCompra"), Session("IdEstablecimiento"))
        Session("IDMODALIDADCOMPRA") = ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
        Return ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
    End Function


End Class