Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class frmDetAdendas
    Inherits System.Web.UI.Page

    Private _IDADENDA As Int32
    Private _sError As String
    Private _nuevo As Boolean = True
    Private mComponente As New cADENDAS
    Private mEntidad As ADENDAS
    Public Event ErrorEvent(ByVal errorMessage As String)
    Private _PaginaRedirect As String

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property PaginaRedirect() As String
        Get
            Return _PaginaRedirect
        End Get
        Set(ByVal Value As String)
            _PaginaRedirect = Value
            If Not Me.ViewState("PaginaRedirect") Is Nothing Then Me.ViewState.Remove("PaginaRedirect")
            Me.ViewState.Add("PaginaRedirect", Value)
        End Set
    End Property

    Public Property IDADENDA() As Integer
        Get
            'If Me.TxtADENDA.Text = "" Then
            '    Me.TxtADENDA.Text = "0"
            'End If
            Return CInt(Me.TxtADENDA.Text)

        End Get
        Set(ByVal Value As Integer)
            Me._IDADENDA = Value
            Me.TxtADENDA.Text = CStr(Value)
            'Me.RecuperarDDLs()
            If Me._IDADENDA > 0 Then
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
            If Not Me.ViewState("IDADENDA") Is Nothing Then Me._IDADENDA = Me.ViewState("IDADENDA")
        End If

        Me.ucBarraNavegacion1.PermitirEditar = True
        Me.ucBarraNavegacion1.PermitirImprimir = False
        Me.ucBarraNavegacion1.PermitirConsultar = False
        Me.ucBarraNavegacion1.Navegacion = False
        Me.ucBarraNavegacion1.PermitirAgregar = False

        Dim ds As New Data.DataSet
        Dim cPC As New cPROCESOCOMPRAS
        cPC.ObtenerCodigoyTipoLicitacion(Session("idestablecimiento"), Session("IdProcesoCompra"), ds)
        Me.Label3.Text = ds.Tables(0).Rows(0).Item(1)
    End Sub

    Private Sub CargarDatos()
        mEntidad = New ADENDAS
        mEntidad.IDADENDA = IDADENDA
        Me.Label3.Text = Session("IdProcesoCompra")
        Me.TxtADENDA.Text = mEntidad.IDADENDA
        Me.TxtNumeroAdenda.Text = mEntidad.NUMEROADENDA
        Me.Texdetalle.Text = mEntidad.DETALLEADENDA
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

        mEntidad = New ADENDAS
        Dim a, b As Integer
        a = Session("idestablecimiento")
        b = Session("IdProcesoCompra")
        If Me._nuevo Then
            mEntidad.IDADENDA = 0
            mEntidad.IDESTABLECIMIENTO = Session("idestablecimiento")
            mEntidad.IDPROCESOCOMPRA = Session("IdProcesoCompra")
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.FECHAADENDA = Now()
            mEntidad.DETALLEADENDA = Me.Texdetalle.Text
            mEntidad.NUMEROADENDA = Me.TxtNumeroAdenda.Text

        Else
            'mEntidad.IDEMPLEADO = CInt(Me.txtIDEMPLEADO.Text)
            'mEntidad.NOMBRECORTO = Me.lblNOMBRECORTO1.Text
            'mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            'mEntidad.AUFECHAMODIFICACION = Now()
        End If

        'validar si el nombre corto existe
        If mComponente.Actualizar(mEntidad) <> 1 Then
            Return "Error al Guardar registro."
        End If

        Return ""
    End Function

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        Response.Redirect("~/UACI/frmGenerarAdendas.aspx")
    End Sub

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        Dim sError As String
        If Me.TxtNumeroAdenda.Text = "" Then
            Me.MsgBox1.ShowAlert("El registro no se guardo, falta el Número de Adenda", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            sError = Me.Actualizar()
            If sError <> "" Then
                MsgBox1.ShowAlert(sError, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Return
            End If
            Me.Button1.Visible = True
        End If

        Me.ucBarraNavegacion1.PermitirGuardar = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim idProcesoCompra As String
        Session("Taden") = 1
        Session("IDMODALIDADCOMPRA") = obtenerModalidad()
        idProcesoCompra = Session("IdProcesoCompra")
        Dim a As String = obtenerModalidad()
        Dim idTipoCompra As String = 1
        Dim mComTipoCompra As New cTIPOCOMPRAS
        Dim lEntTipoCompra As New TIPOCOMPRAS
        PaginaRedirect = "frmGeneraBaseLicitacion.aspx?idProc=" & idProcesoCompra
        PaginaRedirect += "&idTC=" + idTipoCompra
        PaginaRedirect += "&pf=" + "LP"
        PaginaRedirect += "&mod=EDIT"
        Response.Redirect(PaginaRedirect, False)

    End Sub

    Private Function obtenerModalidad() As Integer
        Dim mComponente As New cMODALIDADESCOMPRA
        Dim ds As Data.DataSet
        ds = mComponente.obtenerModalidadCompra(Session("IdProcesoCompra"), Session("IdEstablecimiento"))
        Session("IDMODALIDADCOMPRA") = ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
        Return ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
    End Function

End Class
