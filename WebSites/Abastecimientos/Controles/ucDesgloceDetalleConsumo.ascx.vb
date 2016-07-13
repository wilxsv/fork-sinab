
'INGRESO DE CONSUMO, DEMANDA INSATISFECHA Y CONSUMO
'CU-ESTA0002
'Ing. Yessenia Pennelope Henriquez Duran
'control de usuario para detalle de consumos

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Controles_ucDesgloceDetalleConsumo
    Inherits System.Web.UI.UserControl

    'declaracion e inicializacion de variables y eventos
    Public Event Eliminado(ByVal CODIGOENZABEZADODOCUMENTO As Int32)
    Private _Enabled As Boolean
    Private _PermitirEliminar As Boolean = True
    Private _PermitirGuardar As Boolean = True
    Private _PermitirAgregar As Boolean = True
    Private _MostrarExixtenciaActual As Boolean = True
    Private mEntProducto As New CATALOGOPRODUCTOS
    Private mCompProducto As New cCATALOGOPRODUCTOS
    Public Event GuardoDetalle()
    Public Sub ObtenerDetalleDocumento(ByVal CODIGOENCABEZADODOCUMENTO As Int32)
        'carga el grid con detalle de productos
        Me.Label_CODIGOENZABEZADODOCUMENTO.Text = CODIGOENCABEZADODOCUMENTO.ToString
        Dim mComponente As New cDETALLECONSUMOS
        Me.dgLista.DataSource = mComponente.ObtenerDataSetDetalleConsumo(Session.Item("IdEstablecimiento"), CODIGOENCABEZADODOCUMENTO)
        'cargar lista
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.CurrentPageIndex = 0 'error de pagineo
            Me.dgLista.DataBind()
        End Try
        Me.dgLista.DataBind()
    End Sub
    Public Property Enabled() As Boolean 'habilita
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property
    Private Sub dgLista_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound

        'al momento de cargar registros en el grid

        If e.Item.ItemType = ListItemType.AlternatingItem Or _
           e.Item.ItemType = ListItemType.Item Then
            Dim a As LinkButton = CType(e.Item.FindControl("LinkButton1"), LinkButton) 'eliminar
            a.Attributes.Add("onclick", "if(!window.confirm('¿Esta seguro de Eliminar el Registro?')){return false;}")

            Dim b As LinkButton = CType(e.Item.FindControl("LinkButton2"), LinkButton) 'guardar
            b.Attributes.Add("onclick", "if(!window.confirm('¿Esta a punto de guardar el Registro?')){return false;}")

        End If
    End Sub

    Private Sub dgLista_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        'al momento de eliminar registro
        Dim mComponente As New cDETALLECONSUMOS

        If mComponente.EliminarDETALLECONSUMOS(Session.Item("IdEstablecimiento"), CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton).ToolTip)) = 0 Then
            'Si se cometio un error
        Else
            Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
            RaiseEvent Eliminado(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
            Me.dgLista.CurrentPageIndex = 0
            Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        End If
    End Sub

    Protected Sub ImgbAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbAgregar.Click
        'al momento de agregar producto
        Session.Item("estado") = "nuevo"
        Session.Item("IdEncabezado") = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.UcAgregarConsumo1.Visible = True
    End Sub
    Public Function Agregar() As String
        'funcion agregar
        Me.Label_CODIGOENZABEZADODOCUMENTO.Text = Session.Item("idDoc")
        Session.Item("estado") = "nuevo"
        Session.Item("IdEncabezado") = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.UcAgregarConsumo1.Visible = True
        Me.dgLista.Visible = False
        Me.ImgbAgregar.Visible = True
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al momento de cargar control
        If Not Page.IsPostBack Then
            Me.UcAgregarConsumo1.Visible = False
        End If
        If Session.Item("Nivel") > 1 Then
            MostrarExistenciaActual = False

        Else
            MostrarExistenciaActual = True 'es de nivel 1
        End If
    End Sub
    Public Function Actualizar() As String
        'proceso
    End Function
    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'habilitar campos de edicion
        Me.HabilitarGrid(edicion)
        Me.PermitirAgregar = edicion
        Me.PermitirEliminar = edicion
        Me.PermitirGuardar = edicion
    End Sub

    Public Property PermitirEliminar() As Boolean
        'permite eliminar
        Get
            Return _PermitirEliminar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirEliminar = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 1).Visible = Value
        End Set
    End Property

    Public Property PermitirAgregar() As Boolean
        'permite agregar
        Get
            Return _PermitirAgregar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirAgregar = Value
            Me.ImgbAgregar.Visible = _PermitirAgregar
        End Set
    End Property
    Public Property PermitirGuardar() As Boolean
        'permite guardar
        Get
            Return _PermitirGuardar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirGuardar = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 2).Visible = _PermitirGuardar
        End Set
    End Property
    Public Property MostrarExistenciaActual() As Boolean
        'mostrar existencias
        Get
            Return _MostrarExixtenciaActual
        End Get
        Set(ByVal Value As Boolean)
            _MostrarExixtenciaActual = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 3).Visible = Value
        End Set
    End Property

    Private Sub HabilitarGrid(ByVal edicion As Boolean)
        'habilitar campos del grid para editar
        Dim j As Integer
        For j = 0 To dgLista.Items.Count - 1
            CType(dgLista.Items(j).FindControl("TxtCant"), TextBox).Enabled = edicion
            CType(dgLista.Items(j).FindControl("TxtDemandaInsatisfecha"), TextBox).Enabled = edicion
            CType(dgLista.Items(j).FindControl("TxtExistenciaActual"), TextBox).Enabled = edicion
        Next
    End Sub
    Protected Sub dgLista_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.UpdateCommand
        'al momento de guardar el registro
        Dim McompDetalleConsumo As New cDETALLECONSUMOS
        Dim MentDetalleConsumo As New DETALLECONSUMOS

        MentDetalleConsumo.IDDETALLE = CLng(CType(dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton).ToolTip)
        MentDetalleConsumo.IDCONSUMO = (CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        MentDetalleConsumo.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

        McompDetalleConsumo.ObtenerDETALLECONSUMOS(MentDetalleConsumo)
        MentDetalleConsumo.IDPRODUCTO = CType(dgLista.Items(e.Item.ItemIndex).FindControl("Label_IdProducto"), Label).Text
        MentDetalleConsumo.IDUNIDADMEDIDA = CLng(CType(dgLista.Items(e.Item.ItemIndex).FindControl("Label_IdUnidadMedida"), Label).Text)

        Dim cantidadTexto As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtCant"), TextBox)
        If cantidadTexto.Text = "" Then cantidadTexto.Text = 0
        MentDetalleConsumo.CANTIDADCONSUMIDA = cantidadTexto.Text

        Dim DemandaInsatisfecha As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtDemandaInsatisfecha"), TextBox)
        If DemandaInsatisfecha.Text = "" Then DemandaInsatisfecha.Text = 0
        MentDetalleConsumo.DEMANDAINSATISFECHA = DemandaInsatisfecha.Text

        Dim ExistenciaActual As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtExistenciaActual"), TextBox)
        If ExistenciaActual.Text = "" Then ExistenciaActual.Text = 0
        MentDetalleConsumo.EXISTENCIAACTUAL = ExistenciaActual.Text

        MentDetalleConsumo.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        MentDetalleConsumo.AUFECHAMODIFICACION = Now()
        MentDetalleConsumo.ESTASINCRONIZADA = 0

        If McompDetalleConsumo.ActualizarDETALLECONSUMOS(MentDetalleConsumo) Then
            RaiseEvent GuardoDetalle()
        Else
            MsgBox1.ShowAlert(" Errores al momento de guardar las modificaciones del consumo", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        End If
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))

    End Sub

    Protected Sub UcAgregarConsumo1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcAgregarConsumo1.Agregar
        'al momentod e agregar
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        Me.UcAgregarConsumo1.Visible = False
        Me.dgLista.Visible = True
        Me.ImgbAgregar.Visible = True
    End Sub


    Protected Sub UcAgregarConsumo1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcAgregarConsumo1.Cancelar
        'al momento de cancelar
        Me.UcAgregarConsumo1.Visible = False
        Me.dgLista.Visible = True
        Me.ImgbAgregar.Visible = True
    End Sub

    Private Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged
        'al momento de cambiar indice de numero de pagina
        Me.dgLista.CurrentPageIndex = e.NewPageIndex
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
    End Sub
End Class
