'INGRESO DE CONSUMO, DEMANDA INSATISFECHA Y CONSUMO
'CU-ESTA0002
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de consumos
'Establecimientos del nivel 1 ingresan consumo, demanda insatifecha y existencia mensual
'establecimientos del nivel 2 y 3 consumo es diario y se realiza por medio de interfaz SIM
'la existencia no es ingresada para estos establecimientos
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Data
Partial Class FrmMantConsumos
    Inherits System.Web.UI.Page
    ''Declaracion e inicializacion de variables

    'Private mComponente As New cCONSUMOS
    'Private mCompDetalleConsumo As New cDETALLECONSUMOS
    'Private mEntDetalleConsumo As New DETALLECONSUMOS
    'Private mEntidad As New CONSUMOS
    'Dim mEntLote As New LOTES
    'Dim mCompLote As New cLOTES
    'Dim mEntMovimiento As New MOVIMIENTOS
    'Dim mCompMovimiento As New cMOVIMIENTOS
    'Dim mEntDetalleMovimiento As New DETALLEMOVIMIENTOS
    'Dim mCompDetalleMovimiento As New cDETALLEMOVIMIENTOS
    'Dim idMovimiento As New TextBox
    'Dim idlote As New TextBox
    'Dim existencia As New TextBox

    'Dim idconsumo As String

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'al cargar la pagina
    '    Me.Master.ControlMenu.Visible = False 'oculta menu

    '    If Not Page.IsPostBack Then 'al cargar por primera vez
    '        Me.ucBarraNavegacion1.Navegacion = False
    '        Me.ucBarraNavegacion1.PermitirEditar = False
    '        Me.ucBarraNavegacion1.PermitirGuardar = False
    '        Me.ucBarraNavegacion1.PermitirImprimir = False
    '        Me.ucBarraNavegacion1.PermitirConsultar = False

    '        If Session.Item("Nivel") > 1 Then 'cerifica si el nivel del establecimiento es 1

    '            If Session.Item("IdAlmacen") > 0 Then
    '                Me.BttConsumoAnterior.Visible = False
    '                Me.BttImportarConsumos.Visible = True
    '                Me.ucBarraNavegacion1.PermitirAgregar = False
    '                CargarDatos() 'carga de datos

    '            Else
    '                Me.ucBarraNavegacion1.PermitirAgregar = False
    '                Me.BttConsumoAnterior.Visible = False
    '                Me.BttImportarConsumos.Visible = False
    '                MsgBox1.ShowAlert("El usuario debe estar asignado a un almacen o farmacia del establecimiento para continuar con el proceso", "x", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '            End If

    '        Else ' es de nivel 1 
    '            Me.BttConsumoAnterior.Visible = True
    '            Me.BttImportarConsumos.Visible = False
    '            Me.ucBarraNavegacion1.PermitirAgregar = True
    '            CargarDatos() 'carga de datos
    '        End If
    '        HabilitarConsumoAnterior(False)
    '    End If
    'End Sub

    'Private Sub CargarDatos()
    '    'carga de datos del grid
    '    Dim lCONSUMOS As listaCONSUMOS

    '    lCONSUMOS = Me.mComponente.ObtenerLista(Session.Item("IdEstablecimiento"))
    '    Me.dgLista.DataSource = lCONSUMOS
    '    Me.dgLista.DataBind()
    'End Sub

    'Protected Sub dgLista_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.EditCommand
    '    ' al momento de enviar un consumo 
    '    'cambia a estado de enviado

    '    If CLng(CType(e.Item.FindControl("Label_IdEstado"), Label).Text) = 1 Then 'grabado

    '        If Session.Item("Nivel") > 1 Then ExistenciasLoteSIM(CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton2"), LinkButton).ToolTip))

    '        mEntidad.IDCONSUMO = CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton2"), LinkButton).ToolTip)
    '        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '        Me.mComponente.ObtenerCONSUMOS(mEntidad)
    '        mEntidad.IDESTADO = 2 'enviado
    '        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '        mEntidad.AUFECHAMODIFICACION = Now()
    '        mComponente.ActualizarCONSUMOS(mEntidad)
    '        Me.CargarDatos()

    '        MsgBox1.ShowAlert("Su consumo fue enviado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '    Else
    '        Response.Write("<script language='JavaScript'>alert('No se puede enviar nuevamente una solicitud')</script>")
    '    End If
    'End Sub

    'Private Sub dgLista_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
    '    'al momento de cargar los registros del grid

    '    If e.Item.ItemType = ListItemType.AlternatingItem Or _
    '       e.Item.ItemType = ListItemType.Item Then

    '        Dim a As LinkButton = CType(e.Item.FindControl("LinkButton1"), LinkButton) 'elimianr
    '        a.Attributes.Add("onclick", "if(!window.confirm('¿Esta seguro de Eliminar el Registro?')){return false;}")

    '        Dim b As LinkButton = CType(e.Item.FindControl("LinkButton2"), LinkButton) 'enviar
    '        b.Attributes.Add("onclick", "if(!window.confirm('¿Esta seguro de Enviar el ingreso de consumo')){return false;}")

    '        'Mostra envio y eliminacion
    '        If mCompDetalleConsumo.ExisteProductosAsociadosConsumo(CType(e.Item.FindControl("ID"), Label).Text, Session.Item("IdEstablecimiento")) Then
    '            CType(e.Item.FindControl("lblObservacion"), Label).Text = "COMPLETA"
    '        Else
    '            CType(e.Item.FindControl("lblObservacion"), Label).Text = "INCOMPLETA"
    '        End If

    '        'verifica estado grabado y completo

    '        If CType(e.Item.FindControl("Label_IdEstado"), Label).Text = 1 And CType(e.Item.FindControl("lblObservacion"), Label).Text = "COMPLETA" Then
    '            idconsumo = Me.mComponente.PrimerConsumoSinEnviar(Session.Item("IdEstablecimiento"))
    '            CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = False 'elimianr

    '            If CType(e.Item.FindControl("ID"), Label).Text = idconsumo Then
    '                CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = True 'enviar
    '            Else
    '                CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = False 'enviar
    '            End If
    '            CType(e.Item.FindControl("lblObservacion"), Label).Visible = False
    '        End If

    '        'verifica estado grabado e incompleto

    '        If CType(e.Item.FindControl("Label_IdEstado"), Label).Text = 1 And CType(e.Item.FindControl("lblObservacion"), Label).Text = "INCOMPLETA" Then
    '            idconsumo = Me.mComponente.PrimerConsumoSinEnviar(Session.Item("IdEstablecimiento"))
    '            CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = True 'eliminar
    '            CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = False 'enviar
    '            CType(e.Item.FindControl("lblObservacion"), Label).Visible = True 'observacioens
    '        End If
    '        'verifica estado diferente de grabado y completa

    '        If CType(e.Item.FindControl("Label_IdEstado"), Label).Text > 1 And CType(e.Item.FindControl("lblObservacion"), Label).Text = "COMPLETA" Then
    '            CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = False 'elimianr
    '            CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = False 'enviar
    '            CType(e.Item.FindControl("lblObservacion"), Label).Visible = False
    '        End If

    '        'verifica estado diferente de grabado e incompleta
    '        If CType(e.Item.FindControl("Label_IdEstado"), Label).Text > 1 And CType(e.Item.FindControl("lblObservacion"), Label).Text = "INCOMPLETA" Then
    '            CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = False 'elimianr
    '            CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = False 'enviar
    '            CType(e.Item.FindControl("lblObservacion"), Label).Visible = True
    '        End If

    '        '-----

    '        'carga estados de consumo
    '        Dim mDdlESTADOSCONSUMOS As ABASTECIMIENTOS.WUC.ddlESTADOSCONSUMOS
    '        mDdlESTADOSCONSUMOS = e.Item.FindControl("DdlESTADOSCONSUMOS1")
    '        mDdlESTADOSCONSUMOS.Recuperar()
    '        Dim mESTADOSCONSUMOS As String
    '        mESTADOSCONSUMOS = CType(e.Item.FindControl("Label_IdEstado"), Label).Text
    '        If mESTADOSCONSUMOS <> "" Then
    '            mDdlESTADOSCONSUMOS.SelectedValue = mESTADOSCONSUMOS
    '        End If
    '        CType(e.Item.FindControl("TxtEstado"), TextBox).Text = CType(e.Item.FindControl("DdlESTADOSCONSUMOS1"), DropDownList).SelectedItem.Text
    '        'carga de establecimientos

    '        Dim mDdlESTABLECIMIENTOS As ABASTECIMIENTOS.WUC.ddlESTABLECIMIENTOS
    '        mDdlESTABLECIMIENTOS = e.Item.FindControl("DdlESTABLECIMIENTOS1")
    '        mDdlESTABLECIMIENTOS.Recuperar()
    '        Dim mESTABLECIMIENTOS As String
    '        mESTABLECIMIENTOS = CType(e.Item.FindControl("Label_IdEstablecimiento"), Label).Text
    '        If mESTABLECIMIENTOS <> "" Then
    '            mDdlESTABLECIMIENTOS.SelectedValue = mESTABLECIMIENTOS
    '        End If
    '        CType(e.Item.FindControl("TxtEstablecimiento"), TextBox).Text = CType(e.Item.FindControl("DdlESTABLECIMIENTOS1"), DropDownList).SelectedItem.Text

    '        Dim mDdlEMPLEADOS As ABASTECIMIENTOS.WUC.ddlEMPLEADOS
    '        mDdlEMPLEADOS = e.Item.FindControl("DdlEMPLEADOS1")
    '        mDdlEMPLEADOS.RecuperarCodigo()
    '        Dim mEMPLEADO As String
    '        mEMPLEADO = CType(e.Item.FindControl("lblidemp"), Label).Text
    '        If mEMPLEADO <> "" Then
    '            mDdlEMPLEADOS.SelectedValue = mEMPLEADO
    '        End If
    '        CType(e.Item.FindControl("LblEmpleado"), Label).Text = CType(e.Item.FindControl("DdlEMPLEADOS1"), DropDownList).SelectedItem.Text


    '        'carga mes de consumo
    '        CType(e.Item.FindControl("DdlMes"), DropDownList).SelectedValue = CLng(CType(e.Item.FindControl("Label_IdMesConsumo"), Label).Text)
    '        CType(e.Item.FindControl("TxtMesConsumo"), TextBox).Text = CType(e.Item.FindControl("DdlMes"), DropDownList).SelectedItem.Text

    '    End If
    'End Sub

    'Private Sub dgLista_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
    '    'al momento de eliminar registro de grid
    '    If CLng(CType(e.Item.FindControl("Label_IdEstado"), Label).Text) = 1 Then 'grabado
    '        Me.mCompDetalleConsumo.EliminarDetalles(CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton).ToolTip), Session.Item("IdEstablecimiento"))
    '        Me.mComponente.EliminarCONSUMOS(Session.Item("IdEstablecimiento"), CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton).ToolTip))
    '        Me.dgLista.CurrentPageIndex = 0
    '        Me.CargarDatos()
    '        MsgBox1.ShowAlert("Su consumo fue eliminado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '    Else
    '        'Mayra aqui cambie
    '        Response.Write("<script language='JavaScript'>alert('No se puede eliminar porque ya fue enviado')</script>")
    '    End If
    'End Sub

    'Private Sub BarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
    '    'evento agregar de barra de navegacion
    '    Response.Redirect("~/ESTABLECIMIENTOS/FrmDetaMantConsumos.aspx?id=0")
    'End Sub

    'Private Sub HabilitarConsumoAnterior(ByVal edicion As Boolean)
    '    'habilita controles para crear consumo en base a uno anterior
    '    Me.BttRecuperar.Visible = edicion
    '    Me.LblMes.Visible = edicion
    '    Me.Lblanio.Visible = edicion
    '    Me.DdlMes.Visible = edicion
    '    Me.DdlAño.Visible = edicion
    '    Me.LblMensaje1.Visible = edicion
    '    Me.lblmensaje2.Visible = edicion
    'End Sub

    'Protected Sub BttRecuperar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttRecuperar.Click
    '    'evento recuperar de crear un consumo en base a uno anterior
    '    Me.dgLista.DataSource = Me.mComponente.Filtrar(Me.DdlAño.SelectedValue, Me.DdlMes.SelectedValue, Session.Item("IdEstablecimiento"))
    '    'recupera lista
    '    Try
    '        Me.dgLista.DataBind()
    '    Catch ex As Exception
    '        Me.dgLista.CurrentPageIndex = 0
    '        Me.dgLista.DataBind()
    '    End Try
    '    Me.lblmensaje2.Visible = True
    'End Sub

    'Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
    '    'direciiona a pagina principal
    '    Response.Redirect("~/FrmPrincipal.aspx", False)
    'End Sub

    'Protected Sub BttConsumoAnterior_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttConsumoAnterior.Click
    '    'evento crear consumo en base a uno anterior
    '    'solo para estabelcimientos del nivel 1
    '    HabilitarConsumoAnterior(True)
    '    Me.lblmensaje2.Visible = False
    '    MsgBox1.ShowAlert("Se le recuerda que este proceso aplica para consumos que ya fueron enviados", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    'End Sub

    'Protected Sub BttImportarConsumos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttImportarConsumos.Click
    '    'al presionar evento importar consumos 
    '    'solo para establecimientos del nivel 2 y 3
    '    Response.Redirect("~/ESTABLECIMIENTOS/FrmImportar.aspx")
    'End Sub

    'Private Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged
    '    'al cambiar de numero de indice de pagina del grid
    '    Me.dgLista.CurrentPageIndex = e.NewPageIndex
    '    Me.CargarDatos()
    'End Sub

    'Private Sub ExistenciasLoteSIM(ByVal idconsumo As Int32)
    '    Dim dsc As DataSet
    '    Dim r As DataRow
    '    dsc = mCompDetalleConsumo.ObtenerDataSetDetalleConsumo(Session.Item("IdEstablecimiento"), idconsumo)
    '    For Each r In dsc.Tables(0).Rows
    '        'validar si existe lote

    '        If mCompLote.ExisteLoteSIMProducto(Session.Item("IdAlmacen"), r("IDPRODUCTO")) Then
    '            'si existe
    '            existencia.Text = mCompLote.ExistenciaLoteSIMProducto(Session.Item("IdAlmacen"), r("IDPRODUCTO"))
    '            idlote.Text = mCompLote.ObteneridLoteSIMProducto(Session.Item("IdAlmacen"), r("IDPRODUCTO"))
    '            CrearMovimiento(idconsumo, r("CANTIDADCONSUMIDA"), r("IDPRODUCTO"), existencia.Text)
    '        Else
    '            'si no existe
    '            mEntLote.IDALMACEN = Session.Item("IdAlmacen")
    '            idlote.Text = mCompLote.ObtenerID(mEntLote)
    '            CrearLote(r("IDUNIDADMEDIDA"), r("IDPRODUCTO"))
    '            CrearMovimiento(idconsumo, r("CANTIDADCONSUMIDA"), r("IDPRODUCTO"), 0)
    '        End If
    '    Next r
    'End Sub

    'Private Sub CrearLote(ByVal idunidadmedida As Int32, ByVal idproducto As Int32)

    '    mEntLote.IDLOTE = idlote.Text
    '    mEntLote.IDPRODUCTO = idproducto
    '    mEntLote.IDUNIDADMEDIDA = idunidadmedida
    '    mEntLote.CODIGO = "SIM"
    '    mEntLote.PRECIOLOTE = 0 'es por slaida de receta no tiene precio
    '    mEntLote.IDRESPONSABLEDISTRIBUCION = 1 'UTMIM
    '    mEntLote.IDFUENTEFINANCIAMIENTO = 3 'MSPAS
    '    mEntLote.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '    mEntLote.CANTIDADDISPONIBLE = 0
    '    mEntLote.ESTADISPONIBLE = 1
    '    If mEntLote.AUUSUARIOCREACION = Nothing Then
    '        mEntLote.AUUSUARIOCREACION = User.Identity.Name
    '    End If
    '    If mEntLote.AUFECHACREACION = Nothing Then
    '        mEntLote.AUFECHACREACION = Now()
    '    End If
    '    mEntLote.AUUSUARIOMODIFICACION = User.Identity.Name
    '    mEntLote.AUFECHAMODIFICACION = Now()
    '    mEntLote.ESTASINCRONIZADA = 0
    '    mCompLote.Agregar(mEntLote)
    'End Sub

    'Private Sub CrearMovimiento(ByVal idConsumo As Int32, ByVal cantidad As Double, ByVal idproducto As Int32, ByVal existencia As Double)
    '    'cracion del documento de ajuste

    '    'encabezado de documento
    '    mEntMovimiento.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '    mEntMovimiento.IDTIPOTRANSACCION = 13 'Consumo SIM 
    '    idMovimiento.Text = mCompMovimiento.ObtenerID(mEntMovimiento)
    '    mEntMovimiento.IDMOVIMIENTO = idMovimiento.Text
    '    mEntMovimiento.IDALMACEN = Session.Item("IdAlmacen")
    '    mEntMovimiento.IDTIPODOCREF = 6 'Consumo SIM
    '    mEntMovimiento.NUMERODOCREF = idConsumo
    '    mEntMovimiento.ANIO = Now.Year
    '    mEntMovimiento.TOTALMOVIMIENTO = 0
    '    mEntMovimiento.IDESTADO = 1 'grabado
    '    mEntMovimiento.IDEMPLEADOALMACEN = Session.Item("IdEmpleado")
    '    mEntMovimiento.FECHAMOVIMIENTO = Now.Date
    '    mEntMovimiento.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '    mEntMovimiento.AUFECHACREACION = Now()
    '    mEntMovimiento.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '    mEntMovimiento.AUFECHAMODIFICACION = Now()
    '    mEntMovimiento.ESTASINCRONIZADA = 0
    '    mCompMovimiento.AgregarMOVIMIENTOS(mEntMovimiento)

    '    'detalle movimiento
    '    mEntDetalleMovimiento.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '    mEntDetalleMovimiento.IDTIPOTRANSACCION = 13 'Consumo SIM 
    '    mEntDetalleMovimiento.IDMOVIMIENTO = idMovimiento.Text
    '    mEntDetalleMovimiento.IDDETALLEMOVIMIENTO = 0 'nuevo
    '    mEntDetalleMovimiento.IDALMACEN = Session.Item("IdAlmacen")
    '    mEntDetalleMovimiento.IDPRODUCTO = idproducto
    '    mEntDetalleMovimiento.CANTIDAD = cantidad * -1
    '    mEntDetalleMovimiento.MONTO = 0
    '    mEntDetalleMovimiento.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '    mEntDetalleMovimiento.AUFECHACREACION = Now()
    '    mEntDetalleMovimiento.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '    mEntDetalleMovimiento.AUFECHAMODIFICACION = Now()
    '    mEntDetalleMovimiento.ESTASINCRONIZADA = 0
    '    mCompDetalleMovimiento.ActualizarDETALLEMOVIMIENTOS(mEntDetalleMovimiento)

    '    'actualizacion de lotes en almacen 
    '    ActualizarLoteAlmacen(cantidad, existencia)

    'End Sub

    'Private Sub ActualizarLoteAlmacen(ByVal cantidad As Double, ByVal existencia As Double)
    '    'cracion del documento de ajuste
    '    'LblCantidadTemporal
    '    'encabezado de documento

    '    mEntLote.IDALMACEN = Session.Item("IdAlmacen")
    '    mEntLote.IDLOTE = idlote.Text
    '    mCompLote.ObtenerLOTES(mEntLote)
    '    mEntLote.CANTIDADDISPONIBLE = existencia + (cantidad * -1)
    '    mEntLote.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '    mEntLote.AUFECHAMODIFICACION = Now()
    '    mCompLote.ActualizarLOTES(mEntLote)


    'End Sub

End Class
