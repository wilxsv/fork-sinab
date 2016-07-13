
Imports System
Imports System.Linq
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.EnumHelpers
Imports SINAB_Utils
Imports SINAB_Utils.MessageBox
Imports SINAB_Entidades.Tipos
Imports System.Transactions

Partial Class ALMACEN_FrmDetMantDespacharProductos
    Inherits System.Web.UI.Page


#Region "Propiedades"

    Public Property Movimiento() As SAB_ALM_MOVIMIENTOS
        Get
            Return CType(ViewState("MOVIMIENTO"), SAB_ALM_MOVIMIENTOS)
        End Get
        Set(ByVal value As SAB_ALM_MOVIMIENTOS)
            ViewState("MOVIMIENTO") = value
            Try
                Dim url As String = ResolveUrl("~/Reportes/FrmRptValeSalida.aspx?IdEMov=" + Session.Item("IdEstablecimiento").ToString + "&IdMov=" + Movimiento.IDMOVIMIENTO.ToString)
                btnImprimir.OnClientClick = "window.open('" + url + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return;"
            Catch ex As Exception
                Response.Redirect("~/FrmPrincipal.aspx", False)
            End Try
        End Set
    End Property

    Public Property Vale() As SAB_ALM_VALESSALIDA
        Get
            Return CType(ViewState("VALE"), SAB_ALM_VALESSALIDA)
        End Get
        Set(ByVal value As SAB_ALM_VALESSALIDA)
            ViewState("VALE") = value
        End Set
    End Property

    Public Property ListaDm() As ListaProceso
        Get
            Return CType(ViewState("ldm"), ListaProceso)
        End Get
        Set(value As ListaProceso)
            ViewState("ldm") = value
        End Set
    End Property


    Public Property ProcesoId() As String
        Get
            Return CType(ViewState("pid"), String)
        End Get
        Set(value As String)
            ViewState("pid") = value
        End Set
    End Property

    Public Property Idalmacen() As Integer
        Get
            Return CType(ViewState("IDALMACEN"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IDALMACEN") = value
        End Set
    End Property

    Public Property Anio() As Integer
        Get
            Return CType(ViewState("ANIO"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("ANIO") = value
        End Set
    End Property

    Public Property TokenLugar() As Integer
        Get
            Return CType(ViewState("joker"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("joker") = value
        End Set
    End Property

    Public Property EsFarmacia() As Boolean
        Get
            Return CType(ViewState("EsFarmacia"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            ViewState("EsFarmacia") = value
        End Set
    End Property

#End Region

#Region "Eventos"

    'Protected Sub Page_Unload(ByVal Sender as Object, ByVal E as EventArgs)
    '    lblNroVale.Text="algo"
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BancoProcesos.Init()
            Dim usr = Membresia.ObtenerUsuario()
            Master.ControlMenu.Visible = False
            Dim idmov = CType(Request.QueryString("IdMov"), Integer)
            Idalmacen = CType(Request.QueryString("IdAlm"), Integer)
            cvFechaDespacho.ValueToCompare = Now.Date.ToShortDateString()
            CargarListas()
            If idmov = 0 Then

                ProcesoId = String.Format("NVS" + Now.ToString())
                ListaDm = New ListaProceso(ProcesoId)

                BancoProcesos.Procesos.Add(ListaDm)

                cpFechaDespacho.Enabled = True
                cpFechaDespacho.Text = Now.Date.ToShortDateString()

                ddlSUMINISTROS1.SelectedValue = CType(usr.Suministro.IDSUMINISTRO, String)
                btnCerrar.Enabled = False

                If usr.EmpleadoAlmacenes.FirstOrDefault().ESGUARDAALMACEN Then
                    txtEmpleadoAlmacen.Text = String.Format("{0} {1}", usr.Empleado.NOMBRE, usr.Empleado.APELLIDO)
                Else
                    Dim guarda = New GuardaAlmacen().Obtener(usr.Almacen.IDALMACEN)
                    txtEmpleadoAlmacen.Text = guarda.Nombre
                End If

                'seleccionar la primera opción
                lblTipoDespachoIndividual.Visible = True
                ddlTIPOMOVIMIENTOS1.Visible = True

                plBuscarDistribucion.Visible = False
                plEncabezado.Visible = True
                gvLista.Visible = True
                plGenerales.Visible = True

                plAgregarProducto.Visible = True
                Limpiar()

                ddlESTABLECIMIENTOS1.Focus()

            Else
                ProcesoId = String.Format("OVS" + Now.ToString())
                ListaDm = New ListaProceso(ProcesoId)
                BancoProcesos.Procesos.Add(ListaDm)
                CargarDatos(idmov)
            End If
            RestablecerCriterio()

        Else

            If ConfirmTarget = "Nuevo" Then AfterUserConfirmationHandler(ConfirmArgument)
            If ConfirmTarget = "Guardar" Then GuardarOSalirConfirmacion(ConfirmArgument)
            If ConfirmTarget = "Buscar" Then PonerFoco(ConfirmArgument)
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        If IsNothing(Vale) Or ListaDm.Listado.Any(Function(itm) itm.INSERTAR = True) Then
            Confirm("El vale no ha sido guardado. ¿Desea Guardar el Vale?", "Guardar", OptionPostBack.YesNotPostBack)
            'MsgBox1.ShowConfirm("", "s", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.No)
        Else
            Response.Redirect("~/ALMACEN/FrmMantDespacharproductos.aspx?d=1", False)
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        CerrarVale()
    End Sub


    'Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged

    '    RestablecerCriterio()
    'End Sub

    'Protected Sub ddlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCATALOGOPRODUCTOS1.SelectedIndexChanged
    '    Limpiar()
    '    Buscar(ddlCATALOGOPRODUCTOS1.SelectedValue)
    'End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        '  Limpiar(True)
        Buscar(CType(BuscarProducto.ProductId, Integer))
    End Sub


    Protected Sub btnAgregarLote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarLote.Click
        If gvLotes.Rows.Count = 0 Then
            Alert("No se ha especificado lote")
            Limpiar()
            Exit Sub
        End If

        Try
            'si existe algun dublicado se sale de la funcion
            If VerificarDuplicado() Then Exit Sub

            GuardarValeMovimientoTemporal()

            'Carga del detalle del movimiento en el datagrid
            gvLista.Visible = CargarListaProductos(ListaDm)
            btnCerrar.Enabled = gvLista.Visible
            btnImprimir.Enabled = gvLista.Visible

            Limpiar(True)
            plDatosProducto.Visible = False


        Catch ex As Exception
            Limpiar(True)
            Alert(" Error al actualizar: " + ex.Message)
        End Try


        ModalPup.Hide()
        BuscarProducto.SetFocus = True
    End Sub

    Private Sub GuardarValeMovimientoTemporal()
        ListaDm = BancoProcesos.Get(ProcesoId)
        If IsNothing(ListaDm) Then

            'ddlSUMINISTROS1.Enabled = False
            'txtNroVale.Text = Vale.IDVALE.ToString + "/" + Vale.ANIO.ToString
            lblNroVale.Visible = True
            txtNroVale.Visible = True
            boton.Visible = False
        End If
        '-----------------------
        Dim usr = Membresia.ObtenerUsuario()
        For Each row As GridViewRow In From row1 As GridViewRow In gvLotes.Rows Where CType(Me.gvLotes.Rows(row1.RowIndex).FindControl("nbCantidad"), TextBox).Text.Trim <> String.Empty
            Dim detalleMov As New SAB_ALM_DETALLEMOVIMIENTOS
            With detalleMov
                .IDESTABLECIMIENTO = usr.Establecimiento.IDESTABLECIMIENTO
                .IDTIPOTRANSACCION = TiposTransaccion.Salida
                .IDPRODUCTO = CType(gvLotes.DataKeys(row.RowIndex).Item("IDPRODUCTO"), Long)
                .IDALMACEN = Idalmacen
                .IDLOTE = CType(gvLotes.DataKeys(row.RowIndex).Item("IDLOTE"), Long?)
                .CANTIDAD = CType(CType(gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), TextBox).Text, Decimal)
                .MONTO = 0
                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                .AUFECHACREACION = Now
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .AUFECHAMODIFICACION = Now
                .INSERTAR = True
            End With

            Dim operacionLote As New SAB_ALM_DETALLEMOVIMIENTOLOTES
            With operacionLote
                '.IDMOVIMIENTO = detalleMov.IDMOVIMIENTO
                .IDESTABLECIMIENTO = detalleMov.IDESTABLECIMIENTO
                .IDTIPOTRANSACCION = detalleMov.IDTIPOTRANSACCION
                .IDALMACEN = detalleMov.IDALMACEN
                .IDLOTE = CType(detalleMov.IDLOTE, Long)
                .PRECIOLOTE = CType(gvLotes.DataKeys(row.RowIndex).Item("PRECIOLOTE"), Decimal)

                .RESERVADA = 1
                Select Case ddlTIPOMOVIMIENTOS1.SelectedValue
                    Case 3 'vencida
                        .VENCIDA = 2
                    Case 4 'no disponible
                        .NODISPONIBLE = 2
                        detalleMov.CANTIDADNODISPONIBLE = 1
                    Case 5 'temporal
                        .TEMPORAL = 2
                    Case Else 'disponible
                        .DISPONIBLE = 2
                End Select
            End With

            If Not IsNothing(Movimiento) Then
                operacionLote.IDMOVIMIENTO = Movimiento.IDMOVIMIENTO
            End If
            'Si existe un error hace un rollback y envía el error
            Try
                'Lotes.Actualizar(db, detalleMov, operacionLote)
                detalleMov.SAB_ALM_DETALLEMOVIMIENTOLOTES.Add(operacionLote)
                '  BancoProcesos.Proceso.Remove(ListaDm)
                BancoProcesos.InsertItem(ProcesoId, detalleMov)
                '   BancoProcesos.Proceso.Add(ListaDm)
            Catch ex As Exception
                Throw New Exception("Error al actualizar Lotes y guardar el Detalle:" + ex.Message)
            End Try
        Next
        '-----------------------
        'Vale.SAB_ALM_MOVIMIENTOS.Clear()
        'Vale.SAB_ALM_MOVIMIENTOS.Add(Movimiento)
        cpFechaDespacho.Enabled = False
        ddlTIPOMOVIMIENTOS1.Enabled = False
    End Sub

    Private Function GenerarMovimiento(ByVal db As SinabEntities) As SAB_ALM_MOVIMIENTOS
        Dim usr = Membresia.ObtenerUsuario()
        Dim mv As New SAB_ALM_MOVIMIENTOS
        With mv
            .IDESTABLECIMIENTO = usr.Establecimiento.IDESTABLECIMIENTO
            .IDTIPOTRANSACCION = TiposTransaccion.Salida
            'hasta aqui el encabezado
            .IDALMACEN = Vale.IDALMACEN
            .ANIO = Vale.ANIO
            .IDDOCUMENTO = Vale.IDVALE
            .CLASIFICACIONMOVIMIENTO = CType(rbTipoDespacho.SelectedValue, Byte)
            .SUBCLASIFICACIONMOVIMIENTO = CType(ddlTIPOMOVIMIENTOS1.SelectedValue, Byte)
            .AUFECHACREACION = Now()
            .ESTASINCRONIZADA = 0
            .IDESTADO = EstadosMovimiento.Grabado
            .IDUNIDADSOLICITA = usr.Dependencia.IDDEPENDENCIA
            .FECHAMOVIMIENTO = Date.Parse(cpFechaDespacho.Text)
            .EMPLEADOALMACEN = txtEmpleadoAlmacen.Text
            .EMPLEADOPREPARA = txtEMPLEADOPREPARA.Text
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End With
        'condicionantes para guardar el id de destino depeniendo si es hospital o lugar dentro del hospital.
        If Session.Item("idTipoEstablecimiento") = 3 Or Session.Item("idTipoEstablecimiento") = 8 Then
            If TokenLugar = 1 Then
                mv.ID_LUGAR_ENTREGA_HOSPITAL = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)
                mv.IDESTABLECIMIENTODESTINO = Nothing
            Else
                mv.ID_LUGAR_ENTREGA_HOSPITAL = Nothing
                mv.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)

                If ddlALMACENES1.Visible Then
                    mv.IDALMACENDESTINO = CType(ddlALMACENES1.SelectedValue, Integer?)
                Else
                    mv.IDALMACENDESTINO = Nothing
                End If
            End If
        Else
            mv.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)

            If ddlALMACENES1.Visible Then
                mv.IDALMACENDESTINO = CType(ddlALMACENES1.SelectedValue, Integer?)
            Else
                mv.IDALMACENDESTINO = Nothing
            End If
        End If

        'actualizar movimiento en db
        mv.IDMOVIMIENTO = Movimientos.ObtenerUltimoId(db, mv) + 1
        Return mv

    End Function

    Private Function GenerarVale(ByVal db As SinabEntities) As SAB_ALM_VALESSALIDA
        Dim vl = New SAB_ALM_VALESSALIDA
        With vl
            .IDALMACEN = Idalmacen
            .ANIO = CType(DateTime.Parse(cpFechaDespacho.Text).Year, Short)
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUFECHACREACION = Now()
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            .AUFECHAMODIFICACION = Now
            .ESTASINCRONIZADA = 0
            .IDTIPOIDENTIFICACION = CType(ddlTIPOIDENTIFICACION1.SelectedValue, Short?)
            .OBSERVACION = txtObservacion.Text
            .TRANSPORTISTA = txtTransportista.Text
            .MATRICULAVEHICULO = txtMatricula.Text
            .IDTIPOIDENTIFICACION = CType(ddlTIPOIDENTIFICACION1.SelectedValue, Short)
            .NUMEROIDENTIFICACION = txtNumeroDocumento.Text
            .PERSONARECIBE = txtRecibe.Text
        End With
        vl.IDVALE = ValesSalida.ObtenerUltimoId(db, vl) + 1
        Return vl
    End Function

    Private Function CargarListaProductos() As Boolean
        Dim usr = Membresia.ObtenerUsuario()

        Dim ds = Documentos.ObtenerDetalleProductos(usr.Establecimiento.IDESTABLECIMIENTO, CType(Movimiento.IDMOVIMIENTO, Integer), TiposTransaccion.Salida)
        If ds.Any() Then
            gvLista.DataSource = ds
            gvLista.DataBind()
            Return True
        End If
        gvLista.DataSource = Nothing
        gvLista.DataBind()
        Return False
    End Function

    Private Function CargarListaProductos(list As ListaProceso) As Boolean
        Dim ds = Documentos.ObtenerDetalleProductos(list.Listado)
        If ds.Any() Then
            gvLista.DataSource = ds
            gvLista.DataBind()
            Return True
        End If

        gvLista.DataSource = Nothing
        gvLista.DataBind()
        Return False
    End Function

    Private Function VerificarDuplicado() As Boolean
        Dim encontrado = False
        For Each row As GridViewRow In gvLotes.Rows
            If CType(gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), TextBox).Text.Trim <> String.Empty Then
                encontrado = gvLista.DataKeys.Cast(Of DataKey)().Any(Function(item) item("IDLOTE") = gvLotes.DataKeys(row.RowIndex).Item("IDLOTE"))
            End If

            If encontrado Then
                Alert("Lote " + gvLotes.DataKeys(row.RowIndex).Item("CODIGO").ToString + " ya ingresado.")
                gvLotes.Rows(0).Focus()
                Exit For
            End If
        Next
        Return encontrado
    End Function

    Protected Sub rbTipoDespacho_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbTipoDespacho.SelectedIndexChanged

        Select Case rbTipoDespacho.SelectedValue
            Case 1
                lblTipoDespachoIndividual.Visible = True
                ddlTIPOMOVIMIENTOS1.Visible = True

                plBuscarDistribucion.Visible = False
                plEncabezado.Visible = True
                gvLista.Visible = True
                plGenerales.Visible = True

                plAgregarProducto.Visible = True
                Limpiar()

            Case 2
                lblTipoDespachoIndividual.Visible = False
                ddlTIPOMOVIMIENTOS1.Visible = False

                plBuscarDistribucion.Visible = True

                ddlFUENTEFINANCIAMIENTOS1.Recuperar()
                ddlESTABLECIMIENTOS2.RecuperarOrdenada(1)

            Case 3
                lblTipoDespachoIndividual.Visible = False
                ddlTIPOMOVIMIENTOS1.Visible = False
                plBuscarDistribucion.Visible = False
                Response.Redirect("~/ALMACEN/FrmDetMantDespachoRequisicionI.aspx")
        End Select

        rbTipoDespacho.Visible = False

    End Sub

    Protected Sub btnBuscarDistribucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarDistribucion.Click

        Dim cPD As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMADISTRIBUCION

        Dim ds As Data.DataSet
        ds = cPD.BuscarProgramaParaDespacho(ddlESTABLECIMIENTOS2.SelectedValue, ddlFUENTEFINANCIAMIENTOS1.SelectedValue, ddlSUMINISTROS1.SelectedValue)

        If ds.Tables(0).Rows.Count = 0 Then
            Alert("No se encontró ningún programa de distribución pendiente para el criterio de búsqueda seleccionado.")
            'MsgBox1.ShowAlert("No se encontró ningún programa de distribución pendiente para el criterio de búsqueda seleccionado.", "w", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            plBuscarDistribucion.Visible = False
            plEncabezado.Visible = True
            plGenerales.Visible = True
            gvProgramaDistribucion.DataSource = ds
            gvProgramaDistribucion.DataBind()
            gvProgramaDistribucion.Columns(0).Visible = False
        End If
    End Sub

    Protected Sub ddlESTABLECIMIENTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlESTABLECIMIENTOS1.SelectedIndexChanged
        RecuperarAlmacenEstablecimiento(ddlESTABLECIMIENTOS1.SelectedValue)
        'si es farmacia
        If ddlESTABLECIMIENTOS1.SelectedItem.Text.ToLower.Contains("farmacia") Then
            EsFarmacia = True
        Else
            EsFarmacia = False
        End If

    End Sub


    Protected Sub gvLotes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLotes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("id", e.Row.ClientID)

            Dim nb As TextBox = CType(e.Row.FindControl("nbCantidad"), TextBox)

            nb.Attributes.Add("onFocus", e.Row.ClientID + ".className = 'GridListHighLight'")

            Select Case e.Row.RowState
                Case DataControlRowState.Normal
                    nb.Attributes.Add("onBlur", e.Row.ClientID + ".className = '" + sender.RowStyle.CssClass + "'")
                Case DataControlRowState.Alternate
                    nb.Attributes.Add("onBlur", e.Row.ClientID + ".className = '" + sender.AlternatingRowStyle.CssClass + "'")
                Case DataControlRowState.Selected
            End Select
        End If
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            _total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(8).Text = "Total:"
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(9).Text = _total.ToString("c4")
            e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
        End If

    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting
        ListaDm = BancoProcesos.Get(ProcesoId)
        Dim obj = gvLista.DataKeys(e.RowIndex).Values
        Dim lote As Integer = CType(obj.Item("IDLOTE"), Integer)
        Dim producto As Integer = CType(obj.Item("IDPRODUCTO"), Integer)


        Try
            Dim aborrar = ListaDm.Listado.FirstOrDefault(Function(it) it.IDLOTE = lote And it.IDPRODUCTO = producto)
            Dim aborrarorig = aborrar
            
            With aborrar
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .AUFECHAMODIFICACION = Now
            End With
            Dim op = aborrar.SAB_ALM_DETALLEMOVIMIENTOLOTES.FirstOrDefault()
            With op
                Select Case ddlTIPOMOVIMIENTOS1.SelectedValue
                    Case 3 'Buscar solamente lotes con cantidad vencidas.
                        .VENCIDA = 1
                    Case 4 'Buscar solamante lotes con cantidad no disponible.
                        .NODISPONIBLE = 1
                    Case 5 'Buscar solamente lotes con cantidad en almacenamiento temporal.
                        .TEMPORAL = 1
                    Case Else 'Buscar solamente lotes con cantidad disponible.
                        .DISPONIBLE = 1
                End Select
                .RESERVADA = 2
            End With
            aborrar.SAB_ALM_DETALLEMOVIMIENTOLOTES.Clear()
            aborrar.SAB_ALM_DETALLEMOVIMIENTOLOTES.Add(op)

            'si el detalle existe en la base de datos entonces se borra
            If aborrar.INSERTAR = False Then
                Using db As New SinabEntities
                    DetallesMovimiento.Eliminar(db, aborrar)
                    Lotes.Actualizar(db, aborrar)
                    'guarda los resultados en la based de datos
                    db.SaveChanges()
                End Using
            End If
            BancoProcesos.DeleteItem(ProcesoId, aborrarorig)
        Catch ex As Exception
            Alert("Error: " + "No ha sido posible borrar este registro. Error: " + ex.Message)
        End Try

        Try
            'Carga del detalle del movimiento en el datagrid
            ListaDm = BancoProcesos.Get(ProcesoId)
            gvLista.Visible = CargarListaProductos(ListaDm)
            btnCerrar.Enabled = gvLista.Visible
            If Not gvLista.Visible Then
                ddlSUMINISTROS1.Enabled = True
            End If
            Limpiar(False)
        Catch ex As Exception
            Alert("Error: " + ex.Message)
        End Try
    End Sub
    
    Protected Sub cbVerTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodos.CheckedChanged
        RecuperarLugares()
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        RestablecerCriterio()
    End Sub




#End Region

#Region "Metodos protegidos"
    Protected Sub PonerFoco(ByVal argumento As Object)
        BuscarProducto.SetFocus = True
    End Sub

    Protected Sub GuardarOSalirConfirmacion(ByVal argumento As Object)
        If Convert.ToBoolean(argumento) Then
            GuardarActualizar()
            Response.Redirect("~/ALMACEN/FrmMantDespacharproductos.aspx?d=1")
        Else
            Response.Redirect("~/ALMACEN/FrmMantDespacharproductos.aspx?d=1")
        End If

    End Sub

    Protected Sub AfterUserConfirmationHandler(ByVal eventArgument As Object)
        If Convert.ToBoolean(ConfirmArgument) Then
            Response.Redirect("~/ALMACEN/FrmDetMantDespacharProductos.aspx?IdMov=0" + "&IdAlm=" + Idalmacen.ToString, False)
        Else
            Response.Redirect(string.format("~/ALMACEN/FrmDetMantDespacharProductos.aspx?IdMov={0}&IdAlm={1}",Movimiento.IDMOVIMIENTO, Movimiento.IDALMACEN) , False)
        End If
    End Sub


    'Protected Sub ActualizarDatosVale()


    '    With Vale
    '        .IDTIPOIDENTIFICACION = CType(ddlTIPOIDENTIFICACION1.SelectedValue, Short?)
    '        .NUMEROIDENTIFICACION = txtNumeroDocumento.Text
    '        .OBSERVACION = txtObservacion.Text
    '        .TRANSPORTISTA = txtTransportista.Text
    '        .MATRICULAVEHICULO = txtMatricula.Text
    '        .PERSONARECIBE = txtRecibe.Text
    '    End With

    '    ValesSalida.Actualizar(Vale)
    'End Sub

    'Protected Sub ActualizarDatosMovimiento()
    '    Dim usr = Membresia.ObtenerUsuario()

    '    With Movimiento
    '        .IDESTABLECIMIENTO = usr.Establecimiento.IDESTABLECIMIENTO
    '        .IDUNIDADSOLICITA = usr.Dependencia.IDDEPENDENCIA
    '        .FECHAMOVIMIENTO = Date.Parse(cpFechaDespacho.Text)
    '        .IDTIPOTRANSACCION = TiposTransaccion.Salida
    '        .EMPLEADOALMACEN = txtEmpleadoAlmacen.Text
    '        .EMPLEADOPREPARA = txtEMPLEADOPREPARA.Text
    '        .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '    End With

    '    If Session.Item("idTipoEstablecimiento") = 3 Or Session.Item("idTipoEstablecimiento") = 8 Then
    '        If Joker = 1 Then
    '            Movimiento.ID_LUGAR_ENTREGA_HOSPITAL = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)
    '            Movimiento.IDESTABLECIMIENTODESTINO = Nothing
    '        Else
    '            Movimiento.ID_LUGAR_ENTREGA_HOSPITAL = Nothing
    '            Movimiento.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)
    '            'todo: observacion de cambio para guardar idalmacendestino cuando sea de H a H
    '            If ddlALMACENES1.Visible Then
    '                Movimiento.IDALMACENDESTINO = CType(ddlALMACENES1.SelectedValue, Integer?)
    '            Else
    '                Movimiento.IDALMACENDESTINO = Nothing
    '            End If

    '        End If

    '    Else
    '        Movimiento.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)

    '        If ddlALMACENES1.Visible Then
    '            Movimiento.IDALMACENDESTINO = CType(ddlALMACENES1.SelectedValue, Integer?)
    '        Else
    '            Movimiento.IDALMACENDESTINO = Nothing
    '        End If
    '    End If

    '    'actualizar movimiento en db
    '    Movimientos.Actualizar(Movimiento)
    'End Sub



    Protected Sub DeshabilitarDobleClickBotones()
        btnAgregarLote.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnAgregarLote.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnAgregarLote, Nothing) + ";"
        btnGuardar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnGuardar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnGuardar, Nothing) + ";"
        btnCerrar.OnClientClick = "if(!confirm('Si cierra el documento, este ya no podrá ser modificado, ¿desea continuar?')) return false; if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnCerrar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnCerrar, Nothing) + ";"
        'btnImprimir.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnCerrarConteo, Nothing) + ";"
    End Sub
#End Region

#Region "Metodos Privados"



    Private Sub DDLAlamcenesVisible()
        ddlALMACENES1.Visible = cbVerTodos.Checked
        lblNoAlmacenAsociado.Visible = Not cbVerTodos.Checked
    End Sub

    Private Sub CargarDatos(ByVal idmov As Integer)
        Try
            Dim usr = Membresia.ObtenerUsuario()
            Using db As New SinabEntities()
                Movimiento = Movimientos.Obtener(db, idmov, usr.Establecimiento.IDESTABLECIMIENTO, TiposTransaccion.Salida) 'CType(Session.Item("IdEstablecimiento"), Integer))
                Vale = Movimiento.SAB_ALM_VALESSALIDA
                ListaDm.Listado = Movimiento.SAB_ALM_DETALLEMOVIMIENTOS.ToList()
            End Using

            Dim suministros As New Suministros

            Dim dss = suministros.ObtenerPorMovimiento(Movimiento.IDESTABLECIMIENTO, Movimiento.IDTIPOTRANSACCION, CType(Movimiento.IDMOVIMIENTO, Integer))

            If dss > 0 Then
                ddlSUMINISTROS1.SelectedValue = CType(dss, String)
                ddlSUMINISTROS1.Enabled = False
            Else
                ddlSUMINISTROS1.SelectedValue = CType(usr.Suministro.IDSUMINISTRO, String)
            End If
            If rbTipoDespacho.Visible Then
                rbTipoDespacho.SelectedValue = CType(Movimiento.CLASIFICACIONMOVIMIENTO, String)
            End If
            ddlTIPOMOVIMIENTOS1.SelectedValue = CType(Movimiento.SUBCLASIFICACIONMOVIMIENTO, String)
            lblTipoDespachoIndividual.Visible = True
            ddlTIPOMOVIMIENTOS1.Enabled = False
            ddlTIPOMOVIMIENTOS1.Visible = True
            cpFechaDespacho.Text = CType(Movimiento.FECHAMOVIMIENTO, String)
            cpFechaDespacho.Enabled = False
            Dim lugar = Movimiento.ID_LUGAR_ENTREGA_HOSPITAL
            If Movimiento.IDESTABLECIMIENTODESTINO Is Nothing Then Movimiento.IDESTABLECIMIENTODESTINO = 0
            If Movimiento.IDALMACENDESTINO Is Nothing Then Movimiento.IDALMACENDESTINO = 0
            Using db As New SinabEntities
                If Not usr.TipoEstablecimiento.IDTIPOESTABLECIMIENTO = 3 Or usr.TipoEstablecimiento.IDTIPOESTABLECIMIENTO = 8 Then
                    If ddlESTABLECIMIENTOS1.Items.FindByValue(CType(Movimiento.IDESTABLECIMIENTODESTINO, String)) Is Nothing Then
                        cbVerTodos.Checked = True
                        Establecimientos.CargarPorZonaAlmacenALista(db, Idalmacen, cbVerTodos.Checked, ddlESTABLECIMIENTOS1)
                    End If
                    ddlESTABLECIMIENTOS1.SelectedValue = CType(Movimiento.IDESTABLECIMIENTODESTINO, String)
                    RecuperarAlmacenEstablecimiento(CType(Movimiento.IDESTABLECIMIENTODESTINO, Integer))
                    ddlALMACENES1.SelectedValue = CType(Movimiento.IDALMACENDESTINO, String)
                Else

                    If ddlESTABLECIMIENTOS1.Items.FindByValue(lugar.ToString()) Is Nothing Then
                        cbVerTodos.Checked = True
                        Establecimientos.CargarPorZonaAlmacenALista(db, Idalmacen, cbVerTodos.Checked, ddlESTABLECIMIENTOS1)
                        ddlESTABLECIMIENTOS1.SelectedValue = CType(Movimiento.IDESTABLECIMIENTODESTINO, String)
                        RecuperarAlmacenEstablecimiento(CType(Movimiento.IDESTABLECIMIENTODESTINO, Integer))
                        ddlALMACENES1.SelectedValue = CType(Movimiento.IDALMACENDESTINO, String)
                        TokenLugar = 0
                    Else
                        TokenLugar = 1
                        cbVerTodos.Checked = False
                        LugaresEntrega.CargarLugaresEntregaHospitalALista(db, Idalmacen, ddlESTABLECIMIENTOS1)
                        ddlESTABLECIMIENTOS1.SelectedValue = CType(lugar, String)
                        RecuperarAlmacenEstablecimiento(0)
                    End If

                End If
            End Using

            txtEmpleadoAlmacen.Text = Movimiento.EMPLEADOALMACEN
            txtEMPLEADOPREPARA.Text = Movimiento.EMPLEADOPREPARA

            'Carga la información del vale de salida asociado
            txtNroVale.Text = Vale.IDVALE.ToString + "/" + Vale.ANIO.ToString
            lblNroVale.Visible = True
            txtNroVale.Visible = True
            boton.Visible = False
            txtObservacion.Text = Vale.OBSERVACION
            txtTransportista.Text = Vale.TRANSPORTISTA
            txtMatricula.Text = Vale.MATRICULAVEHICULO
            ddlTIPOIDENTIFICACION1.SelectedValue = CType(Vale.IDTIPOIDENTIFICACION, String)
            txtNumeroDocumento.Text = Vale.NUMEROIDENTIFICACION
            txtRecibe.Text = Vale.PERSONARECIBE

            If ddlESTABLECIMIENTOS1.SelectedItem.Text.ToLower.Contains("farmacia") Then
                EsFarmacia = True
                'btnCerrar.Visible = False
                If Movimiento.IDESTADO = EstadosMovimiento.EnProceso Then
                    btnGuardar.Enabled = False
                    ddlESTABLECIMIENTOS1.Enabled = False
                    cbVerTodos.Enabled = False
                    btnCerrar.Visible = False
                ElseIf Movimiento.IDESTADO = EstadosMovimiento.AceptadoPorDependecia Then
                    btnCerrar.Visible = True
                    ddlESTABLECIMIENTOS1.Enabled = False
                    btnGuardar.Enabled = False
                    cbVerTodos.Enabled = False
                    btnCerrar.Visible = False
                End If
            End If

            If Movimiento.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado Then
                ddlESTABLECIMIENTOS1.Enabled = False
                ddlALMACENES1.Enabled = False
                cbVerTodos.Enabled = False
                cpFechaDespacho.Enabled = False
                plAgregarProducto.Visible = False
                plDatosProducto.Visible = False
                txtEMPLEADOPREPARA.Enabled = False
                txtTransportista.Enabled = False
                txtMatricula.Enabled = False
                txtRecibe.Enabled = False
                ddlTIPOIDENTIFICACION1.Enabled = False
                txtNumeroDocumento.Enabled = False
                txtEmpleadoAlmacen.Enabled = False
                txtObservacion.Enabled = False
                btnGuardar.Visible = False
                btnCerrar.Visible = False
                btnImprimir.Enabled = True
                'Carga del detalle del movimiento en el datagrid
                gvLista.Visible = CargarListaProductos(ListaDm)
            ElseIf Movimiento.IDESTADO = eESTADOSMOVIMIENTOS.Grabado Or Movimiento.IDESTADO = eESTADOSMOVIMIENTOS.En_proceso Then
                plAgregarProducto.Visible = True
                btnCerrar.Visible = True
                btnImprimir.Enabled = True
                'Carga del detalle del movimiento en el datagrid
                gvLista.Visible = CargarListaProductos(ListaDm)
                btnCerrar.Enabled = gvLista.Visible
            End If

            plEncabezado.Visible = True
            plGenerales.Visible = True
        Catch ex As Exception
            Alert(ex.Message)
        End Try
    End Sub

    'Private Sub GuardarDetalleMovimiento(ByVal db As SinabEntities)

    '    Dim usr = Membresia.ObtenerUsuario()

    '    For Each row As GridViewRow In From row1 As GridViewRow In gvLotes.Rows Where CType(Me.gvLotes.Rows(row1.RowIndex).FindControl("nbCantidad"), TextBox).Text.Trim <> String.Empty
    '        Dim detalleMov As New SAB_ALM_DETALLEMOVIMIENTOS
    '        With detalleMov
    '            .IDESTABLECIMIENTO = usr.Establecimiento.IDESTABLECIMIENTO
    '            .IDTIPOTRANSACCION = TiposTransaccion.Salida
    '            .IDMOVIMIENTO = Movimiento.IDMOVIMIENTO
    '            .IDPRODUCTO = CType(gvLotes.DataKeys(row.RowIndex).Item("IDPRODUCTO"), Long)
    '            .IDALMACEN = Idalmacen
    '            .IDLOTE = CType(gvLotes.DataKeys(row.RowIndex).Item("IDLOTE"), Long?)
    '            .CANTIDAD = CType(CType(gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), TextBox).Text, Decimal)
    '            .MONTO = 0
    '            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '            .AUFECHACREACION = Now
    '            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '            .AUFECHAMODIFICACION = Now
    '        End With

    '        Dim operacionLote As New SAB_ALM_DETALLEMOVIMIENTOLOTES

    '        With operacionLote
    '            .IDMOVIMIENTO = detalleMov.IDMOVIMIENTO
    '            .IDESTABLECIMIENTO = detalleMov.IDESTABLECIMIENTO
    '            .IDTIPOTRANSACCION = detalleMov.IDTIPOTRANSACCION
    '            .IDALMACEN =detalleMov.IDALMACEN
    '            .IDLOTE = detalleMov.IDLOTE
    '            .RESERVADA = true
    '            Select Case ddlTIPOMOVIMIENTOS1.SelectedValue
    '                Case 3 'vencida
    '                    .VENCIDA = false
    '                Case 4 'no disponible
    '                    .NODISPONIBLE = false
    '                    detalleMov.CANTIDADNODISPONIBLE = 1
    '                Case 5 'temporal
    '                    .TEMPORAL = false
    '                Case Else 'disponible
    '                    .DISPONIBLE = false
    '            End Select
    '        End With
    '        'Si existe un error hace un rollback y envía el error
    '        Try

    '            'Lotes.Actualizar(db, detalleMov, operacionLote)
    '            detalleMov.SAB_ALM_DETALLEMOVIMIENTOLOTES.Add(operacionLote)
    '            ListaDM.Add(detalleMov)

    '        Catch ex As Exception
    '            Throw New Exception("Error al actualizar Lotes y guardar el Detalle:" + ex.Message)
    '        End Try
    '    Next
    'End Sub

    Private Sub GuardarMovimiento(ByVal db As SinabEntities)
        Dim usr = Membresia.ObtenerUsuario()
        'movimiento
        With Movimiento
            .IDESTABLECIMIENTO = usr.Establecimiento.IDESTABLECIMIENTO
            .IDTIPOTRANSACCION = TiposTransaccion.Salida
            .IDMOVIMIENTO = 0 'se cambia al guardar
            'hasta aqui el encabezado
            .IDALMACEN = Vale.IDALMACEN
            .ANIO = Vale.ANIO
            .IDDOCUMENTO = Vale.IDVALE
            .CLASIFICACIONMOVIMIENTO = CType(rbTipoDespacho.SelectedValue, Byte)
            .SUBCLASIFICACIONMOVIMIENTO = CType(ddlTIPOMOVIMIENTOS1.SelectedValue, Byte)
            .AUFECHACREACION = Now()
            .ESTASINCRONIZADA = 0
            .IDESTADO = EstadosMovimiento.Grabado
            .IDUNIDADSOLICITA = usr.Dependencia.IDDEPENDENCIA
            .FECHAMOVIMIENTO = Date.Parse(cpFechaDespacho.Text)
            .EMPLEADOALMACEN = txtEmpleadoAlmacen.Text
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        End With

        'condicionantes para guardar el id de destino depeniendo si es hospital o lugar dentro del hospital.
        If Session.Item("idTipoEstablecimiento") = 3 Or Session.Item("idTipoEstablecimiento") = 8 Then
            If TokenLugar = 1 Then
                Movimiento.ID_LUGAR_ENTREGA_HOSPITAL = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)
                Movimiento.IDESTABLECIMIENTODESTINO = Nothing
            Else
                Movimiento.ID_LUGAR_ENTREGA_HOSPITAL = Nothing
                Movimiento.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)
                'todo: observacion de cambio para guardar idalmacendestino cuando sea de H a H
                If ddlALMACENES1.Visible Then
                    Movimiento.IDALMACENDESTINO = CType(ddlALMACENES1.SelectedValue, Integer?)
                Else
                    Movimiento.IDALMACENDESTINO = Nothing
                End If
            End If
        Else
            Movimiento.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)

            If ddlALMACENES1.Visible Then
                Movimiento.IDALMACENDESTINO = CType(ddlALMACENES1.SelectedValue, Integer?)
            Else
                Movimiento.IDALMACENDESTINO = Nothing
            End If
        End If

        'actualizar movimiento en db
        Movimientos.Guardar(db, Movimiento)
    End Sub

    Protected Sub ActualizarMovimiento(ByVal db As SinabEntities)
        Dim usr = Membresia.ObtenerUsuario()

        With Movimiento
            .IDESTABLECIMIENTO = usr.Establecimiento.IDESTABLECIMIENTO
            .IDTIPOTRANSACCION = TiposTransaccion.Salida
        End With

        Movimiento = Movimientos.Obtener(db, Movimiento.IDMOVIMIENTO, Movimiento.IDESTABLECIMIENTO, Movimiento.IDTIPOTRANSACCION)

        With Movimiento
            .AUFECHAMODIFICACION = Now
            .IDESTADO = EstadosMovimiento.Grabado
            .IDUNIDADSOLICITA = usr.Dependencia.IDDEPENDENCIA
            .FECHAMOVIMIENTO = Date.Parse(cpFechaDespacho.Text)
            .EMPLEADOALMACEN = txtEmpleadoAlmacen.Text
            .EMPLEADOPREPARA = txtEMPLEADOPREPARA.Text
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        End With

        If Session.Item("idTipoEstablecimiento") = 3 Or Session.Item("idTipoEstablecimiento") = 8 Then
            If TokenLugar = 1 Then
                Movimiento.ID_LUGAR_ENTREGA_HOSPITAL = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)
                Movimiento.IDESTABLECIMIENTODESTINO = Nothing
            Else
                Movimiento.ID_LUGAR_ENTREGA_HOSPITAL = Nothing
                Movimiento.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)
                'todo: observacion de cambio para guardar idalmacendestino cuando sea de H a H
                If ddlALMACENES1.Visible Then
                    Movimiento.IDALMACENDESTINO = CType(ddlALMACENES1.SelectedValue, Integer?)
                Else
                    Movimiento.IDALMACENDESTINO = Nothing
                End If
            End If
        Else
            Movimiento.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)

            If ddlALMACENES1.Visible Then
                Movimiento.IDALMACENDESTINO = CType(ddlALMACENES1.SelectedValue, Integer?)
            Else
                Movimiento.IDALMACENDESTINO = Nothing
            End If
        End If

        'actualizar movimiento en db
        db.SaveChanges()
    End Sub

    'Private Sub GuardarVale(ByVal db As SinabEntities)
    '    Try

    '        If Movimiento.IDMOVIMIENTO = 0 Then
    '            'Creacion del vale de salida
    '            With Vale
    '                .IDALMACEN = Idalmacen
    '                .ANIO = CType(DateTime.Parse(cpFechaDespacho.Text).Year, Short)
    '                .IDVALE = 0 'se cambia al guardar
    '                'hasta aqui el encabezado del vale
    '                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '                .AUFECHACREACION = Now()
    '                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '                .AUFECHAMODIFICACION = Now
    '                .ESTASINCRONIZADA = 0
    '                .IDTIPOIDENTIFICACION = CType(ddlTIPOIDENTIFICACION1.SelectedValue, Short?)
    '            End With
    '            ValesSalida.Guardar(db, Vale)

    '            GuardarMovimiento(db)

    '            ddlSUMINISTROS1.Enabled = False
    '            txtNroVale.Text = Vale.IDVALE.ToString + "/" + Vale.ANIO.ToString
    '            lblNroVale.Visible = True
    '            txtNroVale.Visible = True
    '            boton.Visible = False

    '        Else
    '            'actualizar el movimiento
    '            ActualizarMovimiento(db)
    '        End If

    '        cpFechaDespacho.Enabled = False
    '        ddlTIPOMOVIMIENTOS1.Enabled = False
    '    Catch ex As Exception
    '        Throw New Exception("Error al generar Vale de salida:" & ex.Message)
    '    End Try
    'End Sub

    Private Sub ActualizarVale(ByVal db As SinabEntities)
        Try
            Vale = ValesSalida.Obtener(db, Vale.IDVALE, Vale.IDALMACEN, Vale.ANIO)

            With Vale
                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                .AUFECHACREACION = Now()
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .AUFECHAMODIFICACION = Now
                .ESTASINCRONIZADA = 0
                .IDTIPOIDENTIFICACION = CType(ddlTIPOIDENTIFICACION1.SelectedValue, Short?)
                .NUMEROIDENTIFICACION = txtNumeroDocumento.Text
                .OBSERVACION = txtObservacion.Text
                .TRANSPORTISTA = txtTransportista.Text
                .MATRICULAVEHICULO = txtMatricula.Text
                .PERSONARECIBE = txtRecibe.Text
            End With
            db.SaveChanges()

            ActualizarMovimiento(db)

            ddlSUMINISTROS1.Enabled = False
            txtNroVale.Text = Vale.IDVALE.ToString + "/" + Vale.ANIO.ToString
            lblNroVale.Visible = True
            txtNroVale.Visible = True
            boton.Visible = False

            cpFechaDespacho.Enabled = False
            ddlTIPOMOVIMIENTOS1.Enabled = False
        Catch ex As Exception
            Throw New Exception("Error al generar Vale de salida:" & ex.Message)
        End Try
    End Sub

    'Private Sub GuardarValeMovimiento()
    '    Try
    '        If Movimiento.IDMOVIMIENTO = 0 Then
    '            'Creacion del vale de salida
    '            With Vale
    '                .IDALMACEN = Idalmacen
    '                .ANIO = CType(DateTime.Parse(cpFechaDespacho.Text).Year, Short)
    '                .IDVALE = 0
    '                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '                .AUFECHACREACION = Now()
    '                .ESTASINCRONIZADA = 0

    '            End With
    '            ActualizarDatosVale()

    '            'movimiento
    '            With Movimiento
    '                .IDMOVIMIENTO = 0
    '                .IDALMACEN = Vale.IDALMACEN
    '                .ANIO = Vale.ANIO
    '                .IDDOCUMENTO = Vale.IDVALE
    '                .CLASIFICACIONMOVIMIENTO = CType(rbTipoDespacho.SelectedValue, Byte)
    '                .SUBCLASIFICACIONMOVIMIENTO = CType(ddlTIPOMOVIMIENTOS1.SelectedValue, Byte)
    '                .AUFECHACREACION = Now()
    '                .ESTASINCRONIZADA = 0

    '            End With

    '            Movimiento.IDESTADO = EstadosMovimiento.Grabado

    '            ActualizarDatosMovimiento()

    '            ddlSUMINISTROS1.Enabled = False
    '            txtNroVale.Text = Vale.IDVALE.ToString + "/" + Vale.ANIO.ToString
    '            lblNroVale.Visible = True
    '            txtNroVale.Visible = True
    '            boton.Visible = False

    '        Else
    '            'actualizar el movimiento
    '            Movimiento.AUFECHAMODIFICACION = Now
    '            Movimiento.IDESTADO = EstadosMovimiento.Grabado


    '            ActualizarDatosMovimiento()

    '            'actualizar el vale de salida
    '            With Vale
    '                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '                .AUFECHAMODIFICACION = Now
    '                .IDVALE = CType(Movimiento.IDDOCUMENTO, Integer)
    '            End With
    '            ActualizarDatosVale()
    '        End If
    '        cpFechaDespacho.Enabled = False
    '        ddlTIPOMOVIMIENTOS1.Enabled = False
    '    Catch ex As Exception
    '        Throw New Exception("Error al generar Vale de salida:" & ex.Message)
    '    End Try
    'End Sub

    Private Sub RestablecerCriterio()
        Limpiar()
        BuscarProducto.Almacen = Idalmacen
        BuscarProducto.Suministro = CType(ddlSUMINISTROS1.SelectedValue, Integer)
    End Sub

    Private Sub Limpiar(Optional ByVal limpiarProducto As Boolean = True)

        If limpiarProducto Then BuscarProducto.SearchingText = String.Empty

        lblCORRPRODUCTO.Text = String.Empty
        lblDESCLARGO.Text = String.Empty

        gvLotes.DataSource = Nothing
        gvLotes.DataBind()

        plDatosProducto.Visible = False

    End Sub

    ''' <summary>
    ''' Carga los distintos combos de listas con los parametros por defecto
    ''' </summary>
    ''' <remarks>Fecha de Modificación: 27/06/2016</remarks>
    Private Sub CargarListas()
        Dim usr = Membresia.ObtenerUsuario()
        Try
            Using db As New SinabEntities

                Suministros.CargarALista(db, ddlSUMINISTROS1)
                TiposMovimiento.CargarPorTipoTransaccionALista(db, TiposTransaccion.Salida, ddlTIPOMOVIMIENTOS1)
                TiposIdentificacion.CargarALista(db, ddlTIPOIDENTIFICACION1)

                If usr.Establecimiento.IDTIPOESTABLECIMIENTO = 3 Or usr.Establecimiento.IDTIPOESTABLECIMIENTO = 8 Then
                    LugaresEntrega.CargarLugaresEntregaHospitalALista(db, Idalmacen, ddlESTABLECIMIENTOS1)

                    RecuperarAlmacenEstablecimiento(0)
                    TokenLugar = 1
                Else
                    Establecimientos.CargarPorZonaAlmacenALista(db, Idalmacen, cbVerTodos.Checked, ddlESTABLECIMIENTOS1)
                    RecuperarAlmacenEstablecimiento(CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer))
                End If
                For Each itm As ListItem In ddlESTABLECIMIENTOS1.Items
                    itm.Attributes.Add("title", itm.Text)
                Next
            End Using
        Catch ex As Exception
            Alert("Error en cargar listas de Lugares o Almacenes: " + ex.Message)
        End Try
    End Sub

    Private Sub RecuperarAlmacenEstablecimiento(ByVal idestablecimiento As Integer)
        Dim usr = Membresia.ObtenerUsuario()
        ddlALMACENES1.Items.Clear()
        'TODO: REVISAR ....SE CAMBIO EL ESTABLECIMIENTO POR IDTIPOESTABLECIMIENTO... Mayra Martinez 18/05/2016
        '        If usr.Establecimiento.IDESTABLECIMIENTO <> 3 And usr.Establecimiento.IDESTABLECIMIENTO <> 8 And idestablecimiento > 0 And cbVerTodos.Checked Then
        If usr.Establecimiento.IDTIPOESTABLECIMIENTO <> 3 And usr.Establecimiento.IDTIPOESTABLECIMIENTO <> 8 And cbVerTodos.Checked Then

            Almacenes.CargarAlmacenesEstablecimientosALista(idestablecimiento, ddlALMACENES1)
        End If

        If ddlALMACENES1.Items.Count = 0 Then
            ddlALMACENES1.Visible = False
            lblNoAlmacenAsociado.Visible = True
            cpFechaDespacho.Focus()
        Else
            ddlALMACENES1.Visible = True
            lblNoAlmacenAsociado.Visible = False
            ddlALMACENES1.Focus()
        End If

    End Sub

    Private Sub Buscar(ByVal idproducto As Integer)
        Try


            Dim iTipo As Int16 = 0
            Select Case ddlTIPOMOVIMIENTOS1.SelectedValue
                Case 1 'Buscar solamente lotes con cantidad disponible.
                    iTipo = 1
                Case 2 'Buscar lotes con cantidad disponible o vencida
                    iTipo = 6
                Case 3 'Buscar solamente lotes con cantidad vencidas.
                    iTipo = 3
                Case 4 'Buscar solamante lotes con cantidad no disponible.
                    iTipo = 2
                Case 5 'Buscar solamente lotes con cantidad en almacenamiento temporal.
                    iTipo = 5
            End Select
            'Dim cL As New cLOTES

            'Dim ds As Data.DataSet
            'ds = cL.ObtenerDsLoteFiltrado2(Me.IDALMACEN, IDSUMINISTRO, idproducto, CODIGO, iTipo)


            Dim ds = Lotes.ObtenerLotesFiltrados(Idalmacen, CType(ddlSUMINISTROS1.SelectedValue, Integer), idproducto, CType(cpFechaDespacho.Text, Date), iTipo)

            If ds.Any() Then
                gvLotes.DataSource = ds
                gvLotes.DataBind()
                plDatosProducto.Visible = True
                lblCORRPRODUCTO.Text = CType(gvLotes.DataKeys(0).Values.Item("CORRPRODUCTO"), String)
                lblCORRPRODUCTO.Visible = True
                lblDESCLARGO.Text = CType(gvLotes.DataKeys(0).Values.Item("DESCLARGO"), String)
                lblDESCLARGO.Visible = True
                gvLotes.Rows(0).Focus()
                ModalPup.Show()
            Else
                AlertSubmit("No se encontró ningún lote disponible para este producto.", "Buscar")
                ' Alert("")
                'If txtProducto.Visible Then txtProducto.Focus()
            End If

        Catch ex As Exception
            AlertSubmit("Error: El código de producto esta incompleto, favor verificar. " + ex.Message, "Buscar")
        End Try

    End Sub
#End Region


    Private _total As Decimal = 0



    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        GuardarActualizar()
    End Sub

    Private Sub CerrarVale()
        Try
            Dim options As New TransactionOptions
            options.IsolationLevel = IsolationLevel.ReadCommitted
            options.Timeout = TimeSpan.MaxValue
            Using t As New Transactions.TransactionScope(TransactionScopeOption.Required, options)
                Try
                    GuardarVale(t)
                Catch ex As Exception
                    Throw New Exception("No se pudo guardar Documento: " + ex.Message)
                End Try
            End Using

            Dim cDM As New cDETALLEMOVIMIENTOS
            Dim eM As New ABASTECIMIENTOS.ENTIDADES.MOVIMIENTOS
            Dim eVS As New ABASTECIMIENTOS.ENTIDADES.VALESSALIDA

            eM.IDESTABLECIMIENTO = CType(Session.Item("IdEstablecimiento"), Integer)
            eM.IDTIPOTRANSACCION = TiposTransaccion.Salida
            eM.IDMOVIMIENTO = Movimiento.IDMOVIMIENTO()

            eM.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado
            eM.FECHAMOVIMIENTO = DateTime.Parse(cpFechaDespacho.Text)
            eM.EMPLEADOALMACEN = txtEmpleadoAlmacen.Text
            eM.EMPLEADOPREPARA = txtEMPLEADOPREPARA.Text
            If Session.Item("idTipoEstablecimiento") = 3 Or Session.Item("idTipoEstablecimiento") = 8 Then
                If TokenLugar = 1 Then
                    eM.ID_LUGAR_ENTREGA_HOSPITAL = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer) -
                    eM.IDESTABLECIMIENTODESTINO = Nothing
                Else
                    eM.ID_LUGAR_ENTREGA_HOSPITAL = Nothing
                    eM.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer)
                End If
                eM.IDALMACENDESTINO = CType(IIf(ddlALMACENES1.Visible, ddlALMACENES1.SelectedValue, Nothing), Integer)
            Else
                eM.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer)
                eM.IDALMACENDESTINO = CType(IIf(ddlALMACENES1.Visible, ddlALMACENES1.SelectedValue, Nothing), Integer)
            End If
            eM.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eM.AUFECHAMODIFICACION = Now

            eVS.OBSERVACION = txtObservacion.Text
            eVS.TRANSPORTISTA = txtTransportista.Text
            eVS.MATRICULAVEHICULO = txtMatricula.Text
            eVS.IDTIPOIDENTIFICACION = CType(ddlTIPOIDENTIFICACION1.SelectedValue, Short)
            eVS.NUMEROIDENTIFICACION = txtNumeroDocumento.Text
            eVS.PERSONARECIBE = txtRecibe.Text
            eVS.AUUSUARIOMODIFICACION = eM.AUUSUARIOMODIFICACION
            eVS.AUFECHAMODIFICACION = eM.AUFECHAMODIFICACION

            cDM.CerrarDespacho(eM, eVS, EsFarmacia)

            Confirm("El vale ha sido cerrado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", OptionPostBack.YesNotPostBack)
        Catch ex As Exception
            MessageBox.Alert("Error al cerrar vale: " + ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Evento de Guardado, crea una transacción que bloquea las entidades de vales, movimientos y detalles.
    ''' Genera los objetos tipo para estas tres entidades si no existen, si ya existen solo actualiza el detalle y los datos del movimiento.
    ''' Si la transacción finaliza correctamente entonces desbloquea las entidades.
    ''' Si existe algún error en la transacción hace rollback automático.
    ''' </summary>
    ''' <remarks>Creado por: Ing. Farid Antonio Pérez, Fecha: 03/06/2016</remarks>
    Private Sub GuardarActualizar()
        Dim options As New TransactionOptions
        options.IsolationLevel = IsolationLevel.ReadCommitted
        options.Timeout = TimeSpan.MaxValue
        Using t As New Transactions.TransactionScope(TransactionScopeOption.Required, options)
            Try
                GuardarVale(t)
                Limpiar()
                btnCerrar.Enabled = True
                btnImprimir.Enabled = True

                Confirm("El vale " + txtNroVale.Text + " se ha guardado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", OptionPostBack.YesNotPostBack)
            Catch ex As Exception
                Alert("Error al guardar Documento: " + ex.Message)
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Operaciones dentro de la transacción para guardar el vale de salida, si ya existe se actualizan sus registros
    ''' </summary>
    ''' <param name="t">transacción que encapsula la operación</param>
    ''' <remarks>Creado por: Farid Antonio Pérez Aldana. Fecha Creación: 15/06/2016</remarks>
    Private Sub GuardarVale(ByVal t As Transactions.TransactionScope)
        If IsNothing(Vale) Then
            Using db As New SinabEntities
                Vale = GenerarVale(db)
                Movimiento = GenerarMovimiento(db)
                Vale.SAB_ALM_MOVIMIENTOS.Add(Movimiento)
                ValesSalida.Guardar(db, Vale, True)
                ModLotesAddDetalles(db)
                t.Complete()
            End Using
        Else
            Using db As New SinabEntities
                ModLotesAddDetalles(db)
                ActualizarVale(db)
                t.Complete()
            End Using
        End If
    End Sub

    ''' <summary>
    ''' Por cada detalle del movimiento creado actualiza los lotes y agrega los detalles en la base de datos.
    ''' Esto solo se cumplirá para los detalles que tengan que ser insertados : INSERTAR = True
    ''' </summary>
    ''' <param name="db">Contexto de la base de datos</param>
    ''' <remarks>Creado por: Ing. Farid Antonio Pérez, Fecha: 03/06/2016</remarks>
    Private Sub ModLotesAddDetalles(ByVal db As SinabEntities)
        Try
            ListaDm = BancoProcesos.Get(ProcesoId)
            If ListaDm.Listado.Any() Then
                For Each itm As SAB_ALM_DETALLEMOVIMIENTOS In From obj In ListaDm.Listado Where obj.INSERTAR = True
                    itm.IDMOVIMIENTO = Movimiento.IDMOVIMIENTO
                    Lotes.Actualizar(db, itm)
                    DetallesMovimiento.Agregar(itm, db)
                    db.SaveChanges()
                    itm.INSERTAR = False
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Recupera los lugares de entrega dependiendo si los quiere seleccionar del propio establecimiento o todos los lugares de entrega disponible.
    ''' TokenLugar almacena si el movimiento será guardado localmente o no
    ''' </summary>
    ''' <remarks>Modificado por: Ing. Farid Antonio Pérez Aldana, Modificación: 04/06/2016</remarks>
    Private Sub RecuperarLugares()
        Dim usr = Membresia.ObtenerUsuario()
        Using db As New SinabEntities
            If cbVerTodos.Checked Then
                Establecimientos.CargarPorZonaAlmacenALista(db, Idalmacen, cbVerTodos.Checked, ddlESTABLECIMIENTOS1)
                RecuperarAlmacenEstablecimiento(CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer))
                TokenLugar = 0
            Else
                If usr.TipoEstablecimiento.IDTIPOESTABLECIMIENTO = 3 Or usr.TipoEstablecimiento.IDTIPOESTABLECIMIENTO = 8 Then
                    LugaresEntrega.CargarLugaresEntregaHospitalALista(db, Idalmacen, ddlESTABLECIMIENTOS1)
                    RecuperarAlmacenEstablecimiento(0)
                    TokenLugar = 1
                Else
                    Establecimientos.CargarPorZonaAlmacenALista(db, Idalmacen, cbVerTodos.Checked, ddlESTABLECIMIENTOS1)
                    RecuperarAlmacenEstablecimiento(CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer))
                    TokenLugar = 0
                End If

            End If
        End Using
        For Each itm As ListItem In ddlESTABLECIMIENTOS1.Items
            itm.Attributes.Add("title", itm.Text)
        Next
    End Sub
End Class
