'CALCULO DE NECESIDADES ESTABLECIMIENTO
'CU-ESTA0003
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario detalle de programas de compra

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Partial Class Controles_ucDesgloceNecesidadesEstablecimientos
    Inherits System.Web.UI.UserControl
    'declarar e incializar variables y eventos
    Public Event Eliminado(ByVal CODIGOENZABEZADODOCUMENTO As Int32)
    Private _Enabled As Boolean
    Private _Estado As Int32
    Private _PermitirEliminar As Boolean = True
    Private _PermitirGuardar As Boolean = True
    Private _PermitirAgregar As Boolean = True
    Private _PermitirObservaciones As Boolean = False
    Private _PemitirNecesidadFianl As Boolean = False
    Private _PemitirNecesidadAjustada As Boolean = False

    Public Event GuardoDetalle()
    Private _ESESPECIAL As Boolean = False
    Private mEntProducto As New CATALOGOPRODUCTOS
    Private mCompProducto As New cCATALOGOPRODUCTOS
    Private mCompDetalleNecesidad As New cDETALLENECESIDADESTABLECIMIENTOS
    Private mCompObservaciones As New cOBSERVACIONDETALLENECESIDAD
    Public Event AgregoDetalle(ByVal MONTOREAL As Double, ByVal MONTOAJUSTADO As Double)
    Public Sub ObtenerDetalleDocumento(ByVal CODIGOENCABEZADODOCUMENTO As Int32)
        'cargar el grid con detalle de productos
        Me.Label_CODIGOENZABEZADODOCUMENTO.Text = CODIGOENCABEZADODOCUMENTO.ToString
        Dim mComponente As New cDETALLENECESIDADESTABLECIMIENTOS
        Me.dgLista.DataSource = mComponente.ObtenerDataSetDetalleNecesidad(Session.Item("IdEstablecimiento"), CODIGOENCABEZADODOCUMENTO)
        'carga grid
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.CurrentPageIndex = 0 'error pagineo
            Me.dgLista.DataBind()
        End Try
      
    End Sub
    Public Sub ObtenerSuministro(ByVal idSUMINISTRO As Int32)
        'obtien el suministro del encabezado y verifico el tipo de suministro al que pertenece
        Me.idSuministro.Text = idSUMINISTRO
        Me.UcAgregarProductoNecesidad1.ObtenerSuministro(idSUMINISTRO)
    End Sub

    Public Sub ObtenerDetalleDocumentoFiltrado(ByVal CODIGOENCABEZADODOCUMENTO As Int32, ByVal IDPRODUCTO As Int32)
        'obtener detalle filtrados
        Me.Label_CODIGOENZABEZADODOCUMENTO.Text = CODIGOENCABEZADODOCUMENTO.ToString
        Dim mComponente As New cDETALLENECESIDADESTABLECIMIENTOS
        Me.dgLista.DataSource = mComponente.ObtenerDataSetDetalleNecesidadPorProducto(Session.Item("IdEstablecimiento"), CODIGOENCABEZADODOCUMENTO, IDPRODUCTO)

        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.CurrentPageIndex = 0
            Me.dgLista.DataBind()
        End Try

    End Sub
    Public Property Enabled() As Boolean
        'habilitar
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property
    Public Property Estado() As Integer 'identificador de estado
        Get
            Return Me._Estado
        End Get
        Set(ByVal Value As Integer)
            Me._Estado = Value
            Me.lblidestado.Text = Me._Estado
        End Set
    End Property
    Public Property ESESPECIAL() As Boolean 'es establecimiento especial
        Get
            Return Me._ESESPECIAL
        End Get
        Set(ByVal Value As Boolean)
            Me._ESESPECIAL = Value
            Me.lblEsespecial.Text = Me._ESESPECIAL
            Me.UcAgregarProductoNecesidad1.ESESPECIAL = Me._ESESPECIAL
            If Me.lblEsespecial.Text = True Then
                HabilitarEdicionGrid(True)
                habilitarfiltro(False)
            Else
                HabilitarEdicionGrid(False)

            End If
        End Set
    End Property
    Public Sub habilitarfiltro(ByVal edicion As Boolean) 'habilita campos de filtro
        Me.rdblCriterio.Visible = edicion
        Me.lblIDPRODUCTO.Visible = edicion
        Me.TxtProducto.Visible = edicion
        Me.BtnBuscar.Visible = edicion
        Me.BtnBuscar.Visible = edicion
        Me.bttRecuperar.Visible = edicion
    End Sub
    Protected Sub dgLista_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.EditCommand
        'al momento de imprimir observaciones del producto
        Dim lblnecesidad As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("Label_IdNecesidad"), Label)
        Dim lblproducto As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("Label_IdProducto"), Label)

        Session.Item("idDocRep") = lblnecesidad.Text 'identificador de programa de compras
        Session.Item("idProdRep") = lblproducto.Text 'identificador de producto

        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptObservacionesNecesidadesProducto.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")

    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        'al momento de cargar registros en el grid
        If e.Item.ItemType = ListItemType.AlternatingItem Or _
           e.Item.ItemType = ListItemType.Item Then
            Dim a As LinkButton = CType(e.Item.FindControl("LinkButton1"), LinkButton)
            a.Attributes.Add("onclick", "if(!window.confirm('¿Esta seguro de Eliminar el Registro?')){return false;}")
            Dim b As LinkButton = CType(e.Item.FindControl("LinkButton2"), LinkButton)
            b.Attributes.Add("onclick", "if(!window.confirm('¿Esta a punto de guardar el Registro?')){return false;}")
            Dim c As ImageButton = CType(e.Item.FindControl("LinkButton3"), ImageButton)
            If mCompObservaciones.ExistenObservacionesProductos(Session.Item("IdEstablecimiento"), Val(CType(e.Item.FindControl("Label_IdNecesidad"), Label).Text), Val(CType(e.Item.FindControl("Label_IdProducto"), Label).Text)) Then
                c.ToolTip = "Observaciones"
                c.ImageUrl = "~/Imagenes/consulta.gif"
                c.Visible = True
                a.Visible = False
            Else
                c.Visible = False
                a.Visible = True
            End If
        End If
    End Sub
    Private Sub dgLista_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        'al momento de elimianr registros en el grid
        Dim mComponente As New cDETALLENECESIDADESTABLECIMIENTOS

        If mComponente.EliminarDETALLENECESIDADESTABLECIMIENTOS(Session.Item("IdEstablecimiento"), CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton).ToolTip), CLng(CType(e.Item.FindControl("Label_IdProducto"), Label).Text)) = 0 Then
            'Si se cometio un error
        Else
            Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
            RaiseEvent Eliminado(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
            Me.dgLista.CurrentPageIndex = 0
            Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))

            Me.LblMontoReal.Text = mCompDetalleNecesidad.CalcularMontoRealNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            If Me.lblidestado.Text = "3" Then 'Estado revisado
                Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoFinalNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            Else
                Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoAjustadoNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            End If
            Me.txtMonoNecesidadAjustada.Text = CDbl(Me.LblMontoAjustada.Text)
            Me.TxtMontoNecesidadReal.Text = CDbl(Me.LblMontoReal.Text)
            RaiseEvent AgregoDetalle(Me.LblMontoReal.Text, Me.LblMontoAjustada.Text)
        End If
    End Sub
    Protected Sub ImgbAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbAgregar.Click
        'al momento de presionar agregar
        Session.Item("estado") = "nuevo"
        Session.Item("IdEncabezado") = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.UcAgregarProductoNecesidad1.Visible = True
    End Sub
    Public Function Agregar() As String
        'funcion aregar productos
        Me.Label_CODIGOENZABEZADODOCUMENTO.Text = Session.Item("idDoc")
        Session.Item("estado") = "nuevo"
        Session.Item("IdEncabezado") = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.UcAgregarProductoNecesidad1.Visible = True
        Me.dgLista.Visible = False
        Me.ImgbAgregar.Visible = False
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al momento de cargar control
        If Not Page.IsPostBack Then 'la primera vez
            Me.UcAgregarProductoNecesidad1.Visible = False
            Me.LblMontoReal.Text = mCompDetalleNecesidad.CalcularMontoRealNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))

            If Me.lblidestado.Text = "3" Then 'Estado revisado
                Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoFinalNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            Else
                Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoAjustadoNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            End If

            Me.txtMonoNecesidadAjustada.Text = CDbl(Me.LblMontoAjustada.Text)
            Me.TxtMontoNecesidadReal.Text = CDbl(Me.LblMontoReal.Text)
            Me.DdlCATALOGOPRODUCTOS1.RecuperarHabilitados(Session.Item("IdEstablecimiento"))
            Me.DdlGRUPOS1.RecuperarListaFiltrada(1)
            HabilitarGrid(True)

        End If
    End Sub
    Public Function Actualizar() As String
        'proceso
    End Function

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'habilita campos de edicion
        Me.HabilitarGrid(edicion)
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
        'perimite agregar
        Get
            Return _PermitirAgregar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirAgregar = Value
            Me.ImgbAgregar.Visible = Value
            If _PermitirAgregar Then
                Me.dgLista.Visible = True
            End If
        End Set
    End Property
    Public Property PermitirGuardar() As Boolean
        'permite guardar
        Get
            Return _PermitirGuardar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirGuardar = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 2).Visible = Value
        End Set
    End Property

    Public Property PermitirObservaciones() As Boolean
        'permite ver observaciones
        Get
            Return _PermitirObservaciones
        End Get
        Set(ByVal Value As Boolean)
            _PermitirObservaciones = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 3).Visible = Value
        End Set
    End Property

    Public Property PermitirNecesidadFinal() As Boolean
        'permite ver observaciones
        Get
            Return _PemitirNecesidadFianl
        End Get
        Set(ByVal Value As Boolean)
            _PemitirNecesidadFianl = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 4).Visible = Value
        End Set
    End Property

    Public Property PermitirNecesidadAjustada() As Boolean
        'permite ver observaciones
        Get
            Return _PemitirNecesidadAjustada
        End Get
        Set(ByVal Value As Boolean)
            _PemitirNecesidadAjustada = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 5).Visible = Value
        End Set
    End Property
    Private Sub HabilitarGrid(ByVal edicion As Boolean)
        'permite habilitar los campos de edicion en el grid para establecimientos especiales
        Dim j As Integer
        For j = 0 To dgLista.Items.Count - 1
            CType(dgLista.Items(j).FindControl("LblConsumoAnual"), Label).Visible = edicion
            CType(dgLista.Items(j).FindControl("LblDemandaInsatisfecha"), Label).Visible = edicion
            CType(dgLista.Items(j).FindControl("LblReservaEstablecimiento"), Label).Visible = edicion
            CType(dgLista.Items(j).FindControl("LblReservaTotal"), Label).Visible = edicion
            CType(dgLista.Items(j).FindControl("LblExistenciaEstimada"), Label).Visible = edicion
            CType(dgLista.Items(j).FindControl("LblCompraTransito"), Label).Visible = edicion

            If Session.Item("idTipoEstablecimiento") = "9" Then 'ESTABLECIMIENTO ESPECIAL (9)
                CType(dgLista.Items(j).FindControl("TxtConsumoAnual"), TextBox).Visible = Not edicion
                CType(dgLista.Items(j).FindControl("TxtDemandaInsatisfecha"), TextBox).Visible = Not edicion
                CType(dgLista.Items(j).FindControl("TxtReservaEstablecimiento"), TextBox).Visible = Not edicion
                CType(dgLista.Items(j).FindControl("TxtReservaTotal"), TextBox).Visible = Not edicion
                CType(dgLista.Items(j).FindControl("TxtExistenciaEstimada"), TextBox).Visible = Not edicion
                CType(dgLista.Items(j).FindControl("TxtComprasTransito"), TextBox).Visible = Not edicion

            End If

            If Me.lblidestado.Text = 1 Or Me.lblidestado.Text = 3 Then
                CType(dgLista.Items(j).FindControl("TxtNecesidadAjustada"), TextBox).Enabled = edicion
                CType(dgLista.Items(j).FindControl("TxtNecesidadFinal"), TextBox).Enabled = edicion
            Else
                CType(dgLista.Items(j).FindControl("TxtNecesidadAjustada"), TextBox).Enabled = Not edicion
                CType(dgLista.Items(j).FindControl("TxtNecesidadFinal"), TextBox).Enabled = Not edicion
            End If
        Next
    End Sub
    Private Sub HabilitarEdicionGrid(ByVal edicion As Boolean)
        'habilitar la edicion de los campos en el grid
        Dim j As Integer
        For j = 0 To dgLista.Items.Count - 1
            CType(dgLista.Items(j).FindControl("TxtConsumoAnual"), TextBox).Visible = edicion
            CType(dgLista.Items(j).FindControl("TxtDemandaInsatisfecha"), TextBox).Visible = edicion
            CType(dgLista.Items(j).FindControl("TxtReservaEstablecimiento"), TextBox).Visible = edicion
            CType(dgLista.Items(j).FindControl("TxtReservaTotal"), TextBox).Visible = edicion
            CType(dgLista.Items(j).FindControl("TxtExistenciaEstimada"), TextBox).Visible = edicion
            CType(dgLista.Items(j).FindControl("TxtComprasTransito"), TextBox).Visible = edicion

            CType(dgLista.Items(j).FindControl("LblConsumoAnual"), Label).Visible = Not edicion
            CType(dgLista.Items(j).FindControl("LblDemandaInsatisfecha"), Label).Visible = Not edicion
            CType(dgLista.Items(j).FindControl("LblReservaEstablecimiento"), Label).Visible = Not edicion
            CType(dgLista.Items(j).FindControl("LblReservaTotal"), Label).Visible = Not edicion
            CType(dgLista.Items(j).FindControl("LblExistenciaEstimada"), Label).Visible = Not edicion
            CType(dgLista.Items(j).FindControl("LblCompraTransito"), Label).Visible = Not edicion
        Next
    End Sub

    Protected Sub dgLista_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.UpdateCommand
        'al  momento de actualizar grid
        Dim McompDetalle As New cDETALLENECESIDADESTABLECIMIENTOS
        Dim MentDetalle As New DETALLENECESIDADESTABLECIMIENTOS

        MentDetalle.IDNECESIDAD = CLng(CType(dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton).ToolTip)
        MentDetalle.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        MentDetalle.IDPRODUCTO = CInt(CType(dgLista.Items(e.Item.ItemIndex).FindControl("Label_IdProducto"), Label).Text)
        McompDetalle.ObtenerDETALLENECESIDADESTABLECIMIENTOS(MentDetalle)

        Dim ConsumoAnual As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtConsumoAnual"), TextBox)
        If ConsumoAnual.Text = "" Then ConsumoAnual.Text = 0
        MentDetalle.CONSUMOANUAL = ConsumoAnual.Text

        Dim DemandaInsatisfecha As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtDemandaInsatisfecha"), TextBox)
        If DemandaInsatisfecha.Text = "" Then DemandaInsatisfecha.Text = 0
        MentDetalle.DEMANDAINSATISFECHA = DemandaInsatisfecha.Text

        Dim ReservaEstablecimiento As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtReservaEstablecimiento"), TextBox)
        If ReservaEstablecimiento.Text = "" Then ReservaEstablecimiento.Text = 0
        MentDetalle.RESERVAESTABLECIMIENTO = ReservaEstablecimiento.Text

        Dim ReservaTotal As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtReservaTotal"), TextBox)
        If ReservaTotal.Text = "" Then ReservaTotal.Text = 0
        MentDetalle.RESERVATOTAL = ReservaTotal.Text

        Dim ExixtenciaEstimada As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtExistenciaEstimada"), TextBox)
        If ExixtenciaEstimada.Text = "" Then ExixtenciaEstimada.Text = 0
        MentDetalle.EXISTENCIAESTIMADA = ExixtenciaEstimada.Text

        Dim compraTransito As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtComprasTransito"), TextBox)
        If compraTransito.Text = "" Then compraTransito.Text = 0
        MentDetalle.COMPRASENTRANSITO = compraTransito.Text

        Dim NecesidadAjustada As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtNecesidadAjustada"), TextBox)
        If NecesidadAjustada.Text = "" Then NecesidadAjustada.Text = 0

        Dim precio As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("LblPrecio"), Label)

        Dim NecesidadFinal As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtNecesidadFinal"), TextBox)
        If NecesidadFinal.Text = "" Then NecesidadFinal.Text = 0

        If Me.lblidestado.Text = "3" Then 'Estado revisado
            MentDetalle.COSTOTOTALAJUSTADO = CInt(NecesidadFinal.Text) * (precio.Text)
            MentDetalle.NECESIDADFINAL = CInt(NecesidadFinal.Text)
            CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtTotalB"), Label).Text = CDbl((NecesidadFinal.Text) * (precio.Text))
        Else
            MentDetalle.COSTOTOTALAJUSTADO = CInt(NecesidadAjustada.Text) * (precio.Text)
            MentDetalle.NECESIDADAJUSTADA = CInt(NecesidadAjustada.Text)
            MentDetalle.NECESIDADFINAL = CInt(NecesidadAjustada.Text)
            CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtTotalA"), Label).Text = CDbl((NecesidadAjustada.Text) * (precio.Text))
        End If

        MentDetalle.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        MentDetalle.AUFECHAMODIFICACION = Now()
        MentDetalle.ESTASINCRONIZADA = 0
        MentDetalle.IDUNIDADMEDIDA = CLng(CType(dgLista.Items(e.Item.ItemIndex).FindControl("Label_IdUnidadMedida"), Label).Text)
        MentDetalle.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        MentDetalle.AUFECHACREACION = Now()
        MentDetalle.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        MentDetalle.AUFECHAMODIFICACION = Now()
        MentDetalle.ESTASINCRONIZADA = 0

        If McompDetalle.ActualizarDETALLENECESIDADESTABLECIMIENTOS(MentDetalle) Then
            Me.LblMontoReal.Text = mCompDetalleNecesidad.CalcularMontoRealNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            If Me.lblidestado.Text = "3" Then 'Estado revisado
                Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoFinalNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            Else
                Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoAjustadoNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            End If
            Me.txtMonoNecesidadAjustada.Text = CDbl(Me.LblMontoAjustada.Text)
            Me.TxtMontoNecesidadReal.Text = CDbl(Me.LblMontoReal.Text)

            RaiseEvent AgregoDetalle(Me.LblMontoReal.Text, Me.LblMontoAjustada.Text)
            RaiseEvent GuardoDetalle()
            habilitarfiltro(True)
        Else
            MsgBox1.ShowAlert(" Errores al momento de guardar las modificaciones de la solitud", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        End If
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))

    End Sub


    Protected Sub UcAgregarProductoNecesidad1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcAgregarProductoNecesidad1.Agregar
        'al momento de aguregar un producto
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        Me.UcAgregarProductoNecesidad1.Visible = False
        Me.dgLista.Visible = True
        Me.ImgbAgregar.Visible = True

        Me.LblMontoReal.Text = mCompDetalleNecesidad.CalcularMontoRealNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))

        If Me.lblidestado.Text = "3" Then 'Estado revisado
            Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoFinalNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        Else
            Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoAjustadoNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        End If

        Me.txtMonoNecesidadAjustada.Text = CDbl(Me.LblMontoAjustada.Text)
        Me.TxtMontoNecesidadReal.Text = CDbl(Me.LblMontoReal.Text)

        If Me.lblEsespecial.Text = True Then
            HabilitarEdicionGrid(True)
        Else
            HabilitarEdicionGrid(False)
        End If

        RaiseEvent AgregoDetalle(Me.LblMontoReal.Text, Me.LblMontoAjustada.Text)
    End Sub

    Protected Sub UcAgregarProductoNecesidad1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcAgregarProductoNecesidad1.Cancelar
        'al momento de cancelar
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        Me.LblMontoReal.Text = mCompDetalleNecesidad.CalcularMontoRealNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))

        If Me.lblidestado.Text = "3" Then 'Estado revisado
            Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoFinalNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        Else
            Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoAjustadoNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        End If

        Me.txtMonoNecesidadAjustada.Text = CDbl(Me.LblMontoAjustada.Text)
        Me.TxtMontoNecesidadReal.Text = CDbl(Me.LblMontoReal.Text)

        RaiseEvent AgregoDetalle(Me.LblMontoReal.Text, Me.LblMontoAjustada.Text)

        Me.UcAgregarProductoNecesidad1.Visible = False
        Me.dgLista.Visible = True
        Me.ImgbAgregar.Visible = True

        If Me.lblEsespecial.Text = True Then
            HabilitarEdicionGrid(True)
        Else
            HabilitarEdicionGrid(False)
        End If
    End Sub

    Public Sub calcular_monto()
        'al momento de clacular monto
        Me.LblMontoReal.Text = mCompDetalleNecesidad.CalcularMontoRealNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))

        If Me.lblidestado.Text = "3" Then 'Estado revisado
            Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoFinalNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        Else
            Me.LblMontoAjustada.Text = mCompDetalleNecesidad.CalcularMontoAjustadoNecesidad(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        End If

        Me.txtMonoNecesidadAjustada.Text = CDbl(Me.LblMontoAjustada.Text)
        Me.TxtMontoNecesidadReal.Text = CDbl(Me.LblMontoReal.Text)

        RaiseEvent AgregoDetalle(Me.LblMontoReal.Text, Me.LblMontoAjustada.Text)
    End Sub

    Private Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged
        'al cambiar indice de pagina del grid
        Me.dgLista.CurrentPageIndex = e.NewPageIndex
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
    End Sub

    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
        ' al seleciionar criterio de busqueda de producto
        If Me.rdblCriterio.SelectedValue = 0 Then
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.BtnBuscar.Visible = True
            Me.DdlGRUPOS1.Visible = False
            Me.bttgenerar.Visible = False
            Me.BtnBuscar.Text = "Buscar"
        End If
        If Me.rdblCriterio.SelectedValue = 1 Then
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.DdlCATALOGOPRODUCTOS1.RecuperarHabilitadosxCodigoXSuministro(Me.idSuministro.Text, Session.Item("IdEstablecimiento"))
            Me.DdlCATALOGOPRODUCTOS1.Visible = True
            Me.LblDescripcionCompleta.Visible = False
            Me.DdlGRUPOS1.Visible = False
            Me.bttgenerar.Visible = True
            Me.bttgenerar.Text = "Buscar"

        End If
        If Me.rdblCriterio.SelectedValue = 2 Then
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.DdlGRUPOS1.RecuperarListaFiltrada(1)
            Me.DdlGRUPOS1.Visible = True
            Me.bttgenerar.Visible = True
            Me.bttgenerar.Text = "Filtrar"
            Me.LblDescripcionCompleta.Visible = False
        End If
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'al presionar buscar
        If Me.BtnBuscar.Text = "Buscar" Then
            Dim dsCatalogoProductos As DataSet
            dsCatalogoProductos = mCompDetalleNecesidad.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Me.TxtProducto.Text)

            If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
                MsgBox1.ShowAlert("El código del producto no está habilitado, es incorrecto o no existe", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.TxtProducto.Text = ""
                Me.TxtProducto.Focus()
            Else
                ObtenerDetalleDocumentoFiltrado(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO"))
                Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                Me.LblDescripcionCompleta.Visible = False

            End If
        End If
    End Sub

    Protected Sub bttgenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttgenerar.Click
        'al momento de filtrar
        If Me.bttgenerar.Text = "Filtrar" Then
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaHabilitadosXgrupo(CInt(Me.DdlGRUPOS1.SelectedValue), Session.Item("IdEstablecimiento"))
            Me.DdlCATALOGOPRODUCTOS1.Visible = True
            Me.LblDescripcionCompleta.Visible = False
            Me.DdlGRUPOS1.Visible = False
            Me.bttgenerar.Text = "Buscar"
            Me.bttgenerar.Visible = True
        Else
            If Me.bttgenerar.Text = "Buscar" Then
                ObtenerDetalleDocumentoFiltrado(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), CInt(Me.DdlCATALOGOPRODUCTOS1.SelectedValue))
            End If
        End If
    End Sub

    Protected Sub bttRecuperar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttRecuperar.Click
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        Me.bttgenerar.Visible = False
        Me.BtnBuscar.Visible = True
        Me.DdlCATALOGOPRODUCTOS1.Visible = False
        Me.TxtProducto.Visible = True
        Me.TxtProducto.Text = ""
        Me.rdblCriterio.SelectedValue = 0
    End Sub


End Class
