Imports System.Linq
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports SINAB_Entidades.Helpers.FarmaciaHelpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports SINAB_Entidades
Imports SINAB_Utils.MessageBox
Imports SINAB_Entidades.EnumHelpers
Imports SINAB_Entidades.Tipos

Partial Class FrmDetMantDespacharPreOrden
    Inherits System.Web.UI.Page

#Region "Propiedades Públicas"
    Public Property Suministro As SAB_CAT_SUMINISTROS
        Get
            Return Me.ViewState("SUMINISTRO")
        End Get
        Set(value As SAB_CAT_SUMINISTROS)
            Me.ViewState("SUMINISTRO") = value
        End Set
    End Property

    Public Property Req As Requisicion
        Get
            Return Me.ViewState("REQUISICION")
        End Get
        Set(value As Requisicion)
            Me.ViewState("REQUISICION") = value
        End Set
    End Property

    Public Property Procesando As Boolean
        Get
            Return CType(ViewState("PROCESANDO"), Boolean)
        End Get
        Set(value As Boolean)
            ViewState("PROCESANDO") = value
        End Set
    End Property
#End Region

#Region "Métodos Protegidos"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cpFechaDespacho.Text = Now.Date.ToShortDateString
            cvFechaDespacho.ValueToCompare = Now.Date

            If Not String.IsNullOrEmpty(Request.QueryString("cr")) Then
                buscador.Visible = False
                Dim codreq = Request.QueryString("cr")
                CargarFormulario(codreq)
            End If
        Else
            If ConfirmTarget = "Nuevo" Then SalirONuevoConfirmacion(ConfirmArgument)
            If ConfirmTarget = "Guardar" Then GuardarOSalirConfirmacion(ConfirmArgument)
        End If
    End Sub

    Protected Sub Buscar_Click(sender As Object, e As System.EventArgs) Handles Buscar.Click
        CargarFormulario(tbBuscador.Text)
    End Sub

    Protected Sub lnkMenu_Click(sender As Object, e As System.EventArgs) Handles lnkMenu.Click
        Try

        
        If gvLista.Rows.Count > 0 And Req.Movimiento IsNot Nothing Then
            Confirm("El vale no ha sido guardado. ¿Confirma que desea salir sin guardar?", "Guardar", OptionPostBack.YesPostBack)
        Else
            Response.Redirect("~/FrmPrincipal.aspx", False)
            End If
        Catch ex As Exception
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End Try
    End Sub

#Region "Confirmaciones"
    Protected Sub SalirONuevoConfirmacion(ByVal eventArgument As Object)
        If Convert.ToBoolean(ConfirmArgument) Then
            If Req.Almacen IsNot Nothing Then
                Response.Redirect("~/ALMACEN/FrmDetMantDespacharProductos.aspx?IdMov=0" + "&IdAlm=" + Req.Almacen.IDALMACEN.ToString, False)
            Else
                Response.Redirect("~/ALMACEN/FrmDetMantDespacharProductos.aspx?IdMov=0" + "&IdAlm=" + Membresia.ObtenerUsuario().Almacen.IDALMACEN.ToString, False)
            End If
        Else
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub

    Protected Sub GuardarOSalirConfirmacion(ByVal argumento As Object)
        If Convert.ToBoolean(argumento) Then
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub
#End Region

    Protected Sub Procesar(sender As Object, e As CommandEventArgs)

        Dim args = e.CommandArgument.ToString.Split(",")
        Dim idmov As Long
        If Req.Movimiento IsNot Nothing Then idmov = Req.Movimiento.IDMOVIMIENTO Else idmov = 0

        With ProductosLotes
            .IdMovimiento = CType(idmov, Integer)
            .IdProducto = CType(args(0), Integer)
            .CodigoProducto = args(1)
            .CantidadProducto = CType(args(2), Double)
            .IdAlmacen = Req.Almacen.IDALMACEN
            .IdSuministro = Suministro.IDSUMINISTRO
            .FiltroLote = LotesPorCantidad.Disponible
        End With

        Try
            ProductosLotes.Ejecutar()
            ModalPup.Show()
        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting
        Dim obj2 = gvLista.Rows(e.RowIndex)
        Dim itm = obj2.DataItem

        Dim obj = gvLista.DataKeys(e.RowIndex).Values
        Dim operacionlote As New OperacionesLotes
        Dim usr = Membresia.ObtenerUsuario()
        Dim detalleMovimiento = New SAB_ALM_DETALLEMOVIMIENTOS

        With detalleMovimiento
            .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDTIPOTRANSACCION = TiposTransaccion.Salida
            .IDMOVIMIENTO = Req.Movimiento.IDMOVIMIENTO
            .IDDETALLEMOVIMIENTO = CType(obj.Item("IDDETALLEMOVIMIENTO"), Long)
            .IDALMACEN = usr.Almacen.IDALMACEN
            .IDLOTE = CType(obj.Item("IDLOTE"), Long?)
            .CANTIDAD = CType(obj.Item("CANTIDAD"), Decimal)
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            .AUFECHAMODIFICACION = Now
        End With

        Dim corrproducto = obj.Item("CORRPRODUCTO").ToString()

        With operacionlote
            Select Case ddlMovimientos.SelectedValue
                Case 3 'Buscar solamente lotes con cantidad vencidas.
                    .CantidadVencida = 1
                Case 4 'Buscar solamante lotes con cantidad no disponible.
                    .CantidadNoDisponible = 1
                Case 5 'Buscar solamente lotes con cantidad en almacenamiento temporal.
                    .CantidadTemporal = 1
                Case Else 'Buscar solamente lotes con cantidad disponible.
                    .CantidadDisponible = 1
            End Select
            .CantidadReservada = 2
        End With

        'Elimina el detalle de detallesmovimiento y actualiza las cantidades, luego guarda en la db
        Try
            Using db As New SinabEntities
               
                DetallesMovimiento.Eliminar(db, detalleMovimiento)
                Lotes.Actualizar(db, detalleMovimiento, operacionlote)

                'guarda los resultados en la based de datos
                db.SaveChanges()

                'refresca las grid y muestra|oculta los paneles respectivos
                Req.RestarDetalle(corrproducto, detalleMovimiento.CANTIDAD)
                Dim reqs As New Requisiciones
                Req = reqs.Obtener(db, Req.CodigoRequisicion)
                panelPendientes.Visible = ObtenerDetallePreOrden()
                productosPanel.Visible = CargarListaProductos()
            End Using
        Catch ex As Exception
            Alert("Error: " + ex.Message)
        End Try
    End Sub

    Protected Sub btnAgregarLote_Click(sender As Object, e As System.EventArgs) Handles btnAgregarLote.Click
        Try
            If Req.Movimiento Is Nothing And Req.ValeSalida Is Nothing Then
                Procesando = False
                'se crea el movimiento y el vale...
                GuardarValeMovimiento()
                Dim requisiciones = New Requisiciones
                requisiciones.AsignarValeyProcesar(Req)
                Alert("Se ha generado el vale " + Me.txtNroVale.Text + " satisfactoriamente.  Puede continuar ingresando productos.")
            End If

            ProcesarDetalles()
            ModalPup.Hide()
        Catch ex As Exception
            Alert(ex.Message)
        End Try

        'recupera resultados, muestra|oculta los paneles de producto detalle
        Dim reqs As New Requisiciones
        Using db As New SinabEntities
            Req = reqs.Obtener(db, Req.CodigoRequisicion)
            panelPendientes.Visible = ObtenerDetallePreOrden()
        End Using
        productosPanel.Visible = CargarListaProductos()
    End Sub

    Protected Sub btnProcesar_Click(sender As Object, e As System.EventArgs) Handles btnProcesar.Click
        Try
            'TODO: VERIFICAR QUE YA TODOS LOS PRODUCTOS ESTEN PROCESADOS

            If Req.Movimiento Is Nothing And Req.ValeSalida Is Nothing Then
                Throw New Exception("No existe Documento asociado, Guarde el documento antes de procesarlo")
            End If

            ActualizarDatosVale()
            Req.Movimiento.IDESTADO = eESTADOSMOVIMIENTOS.En_proceso
            ActualizarDatosMovimiento()


            TransaccionesSiap.AgregarTransaccion(Req.Movimiento, True)

            Confirm("El vale " + txtNroVale.Text + " se ha guardado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", SINAB_Utils.MessageBox.OptionPostBack.YesNotPostBack)
        Catch ex As Exception
            Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click

        'TODO: VERIFICAR QUE YA TODOS LOS PRODUCTOS ESTEN PROCESADOS

        If Req.Movimiento Is Nothing And Req.ValeSalida Is Nothing Then
            Throw New Exception("No existe Documento asociado, Guarde el documento antes de procesarlo")
        End If

        ActualizarDatosVale()
        Req.Movimiento.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado
        ActualizarDatosMovimiento()

        Confirm("El vale ha sido cerrado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", OptionPostBack.YesNotPostBack)
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Req.Movimiento Is Nothing And Req.ValeSalida Is Nothing Then
                Procesando = False
                'se crea el movimiento y el vale...
                GuardarValeMovimiento()
                Dim requisiciones = New Requisiciones
                requisiciones.AsignarVale(Req)
                Alert("Se ha generado el vale " + txtNroVale.Text + " satisfactoriamente.  Puede continuar ingresando productos.")
            Else
                ActualizarDatosVale()
                ActualizarDatosMovimiento()
                Confirm("El vale " + txtNroVale.Text + " se ha guardado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", OptionPostBack.YesNotPostBack)
            End If

            Procesando = True
        Catch ex As Exception
            Alert(ex.Message)
        End Try
    End Sub
#End Region

#Region "Métodos Privados"
    Private Sub CargarFormulario(ByVal codigo As String)
        Dim preOrden As New List(Of RequisicionItem)
        Dim detallependiete As Boolean
        Dim hayproductos As Boolean
        Using db As New SinabEntities
            Try
                Dim reqs = New Requisiciones()
                'obtiene requisicion
                Req = reqs.Obtener(db, codigo)

                'carga detales de requisicion
                detallependiete = ObtenerDetallePreOrden()
                'si existen detalles muesta el grupo
                panelPendientes.Visible = detallependiete

                'recupera los valores para elementos del formulario
                Suministro = db.SAB_CAT_SUMINISTROS.FirstOrDefault(Function(m) m.IDSUMINISTRO = 1)
                Dim dsmovimientos = db.SAB_CAT_TIPOMOVIMIENTOS.Where(Function(x) x.IDTIPOTRANSACCION = TiposTransaccion.Salida)

                With ddlMovimientos
                    .DataSource = dsmovimientos
                    .DataTextField = "DESCRIPCION"
                    .DataValueField = "IDTIPOMOVIMIENTO"
                    .DataBind()
                End With

                With ddlTIPOIDENTIFICACION1
                    .DataSource = db.SAB_CAT_TIPOIDENTIFICACION
                    .DataTextField = "DESCRIPCION"
                    .DataValueField = "IDTIPOIDENTIFICACION"
                    .DataBind()
                End With

                lblSuministro.Text = Suministro.DESCRIPCION
                lbEstablecimiento.Text = Req.LugarEntrega.NOMBRE_LUGAR_ENTREGA_HOSPITAL
                lblAlmacenAsociado.Text = "--"

                If Not String.IsNullOrEmpty(Req.CodigoVale) Then 'si ya existe el vale y el movimiento...
                    Procesando = True 'flag

                    lblNroVale.Text = defaulttitle
                    txtNroVale.Text = Req.CodigoVale
                    txtRecibe.Text = Req.ValeSalida.PERSONARECIBE
                    txtEmpleadoAlmacen.Text = Req.Movimiento.EMPLEADOALMACEN
                    txtNumeroDocumento.Text = Req.ValeSalida.NUMEROIDENTIFICACION
                    txtObservacion.Text = Req.ValeSalida.OBSERVACION
                    txtTransportista.Text = Req.ValeSalida.TRANSPORTISTA
                    txtMatricula.Text = Req.ValeSalida.MATRICULAVEHICULO
                    txtEMPLEADOPREPARA.Text = Req.Movimiento.EMPLEADOPREPARA
                    ddlTIPOIDENTIFICACION1.SelectedValue = Req.ValeSalida.IDTIPOIDENTIFICACION.ToString()

                    hayproductos = CargarListaProductos()
                Else
                    Dim guarda = New GuardaAlmacen().Obtener(Req.Almacen.IDALMACEN)
                    txtEmpleadoAlmacen.Text = guarda.Nombre
                    lblNroVale.Text = newtitle
                End If

                EvaluarEstados(detallependiete)
                productosPanel.Visible = hayproductos
                mvRequisicion.ActiveViewIndex = 0

            Catch ex As NullReferenceException
                mvRequisicion.ActiveViewIndex = 1
                errorMsj.Text = "No se han encontrado requisiciones que concuerden con el parámetro de búsquedas"

            Catch ex As Exception
                mvRequisicion.ActiveViewIndex = 1
                errorMsj.Text = ex.Message
            End Try
        End Using
    End Sub

    Private Function ObtenerDetallePreOrden() As Boolean
        Dim ds = Req.ObtenerDetalle()
        If ds.Any() Then
            'si existe detalle
            rPreorden.DataSource = ds
            rPreorden.DataBind()
            Return True
        End If

        rPreorden.DataSource = Nothing
        rPreorden.DataBind()
        Return False
    End Function

    Private Function CargarListaProductos() As Boolean

        Dim documentos As New Documentos
        Dim ds = documentos.ObtenerDetalleProductos(Req.Establecimiento.IDESTABLECIMIENTO, CType(Req.Movimiento.IDMOVIMIENTO, Integer), TiposTransaccion.Salida)


        If ds.Any() Then
            gvLista.DataSource = ds
            gvLista.DataBind()
            Return True
        End If

        gvLista.DataSource = Nothing
        gvLista.DataBind()
        Return False
    End Function



    ''' <summary>
    ''' Genera el Vale de salida y el movimiento para la requisicion en curso
    ''' </summary>
    ''' <returns>??</returns>
    ''' <remarks>SINAB DEV 12/04/2013</remarks>
    Private Sub GuardarValeMovimiento()

        Try
            'asigna nuevo vale de salida
            CrearValeSalida()

            'movimiento
            CrearMovimiento()
            ProductosLotes.IdMovimiento = Req.Movimiento.IDMOVIMIENTO
        Catch ex As Exception
            Throw New Exception("Error al generar Vale de salida:" & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' crea un nuevo vale de salida y lo guarda en la db
    ''' </summary>
    ''' <remarks>SINAB DEV 12/04/2013</remarks>
    Private Sub CrearValeSalida()
        'Creacion del vale de salida
        Req.ValeSalida = New SAB_ALM_VALESSALIDA
        With Req.ValeSalida
            .IDALMACEN = Req.Almacen.IDALMACEN
            .ANIO = DateTime.Parse(Me.cpFechaDespacho.Text).Year
            .IDVALE = 0
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUFECHACREACION = Now()
            .ESTASINCRONIZADA = 0
        End With

        ActualizarDatosVale()

    End Sub

    Private Sub ActualizarDatosVale()


        With Req.ValeSalida
            .IDTIPOIDENTIFICACION = CType(ddlTIPOIDENTIFICACION1.SelectedValue, Short?)
            .NUMEROIDENTIFICACION = txtNumeroDocumento.Text
            .OBSERVACION = txtObservacion.Text
            .TRANSPORTISTA = txtTransportista.Text
            .MATRICULAVEHICULO = txtMatricula.Text
            .PERSONARECIBE = txtRecibe.Text
        End With

        ValesSalida.Actualizar(Req.ValeSalida)
    End Sub

    ''' <summary>
    ''' crea un nuevo movimiento y lo guarda en la db
    ''' </summary>
    ''' <remarks>SINAB DEV 12/04/2013</remarks>
    Private Sub CrearMovimiento()
        Dim usr = Membresia.ObtenerUsuario()
        'crea el movimiento
        Req.Movimiento = New SAB_ALM_MOVIMIENTOS
        With Req.Movimiento
            .IDMOVIMIENTO = 0
            .IDALMACEN = usr.Almacen.IDALMACEN
            .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
            .ANIO = Req.ValeSalida.ANIO
            .IDDOCUMENTO = Req.ValeSalida.IDVALE
            .IDUNIDADSOLICITA = usr.Dependencia.IDDEPENDENCIA
            .CLASIFICACIONMOVIMIENTO = 3 'Despachar productos a partir de una requisición proveniente de otro almacén            
            .IDESTADO = eESTADOSMOVIMIENTOS.Grabado
            .ID_LUGAR_ENTREGA_HOSPITAL = Req.LugarEntrega.ID_LUGAR_ENTREGA_HOSPITAL
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUFECHACREACION = Now()
            .ESTASINCRONIZADA = 0
            .IDTIPOTRANSACCION = TiposTransaccion.Salida
        End With

        ActualizarDatosMovimiento()

    End Sub

    Private Sub ActualizarDatosMovimiento()
        With Req.Movimiento
            .FECHAMOVIMIENTO = DateTime.Parse(cpFechaDespacho.Text)
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            .EMPLEADOALMACEN = txtEmpleadoAlmacen.Text
            .EMPLEADOPREPARA = txtEMPLEADOPREPARA.Text
        End With
        'actualizar movimiento en db
        Dim mov As New Movimientos
        Movimientos.Actualizar(Req.Movimiento)
    End Sub

    Private Sub ProcesarDetalles()
        Dim detallesLotes = ProductosLotes.ObtenerDetalleLotes()
        Dim reqs As New Requisiciones
        For Each dm As SAB_ALM_DETALLEMOVIMIENTOS In detallesLotes
            dm.IDALMACEN = Req.Almacen.IDALMACEN
            dm.IDMOVIMIENTO = Req.Movimiento.IDMOVIMIENTO
            VerificarDuplicados(dm)

            Dim operacionLote As New OperacionesLotes

            Dim requisiciones As New Requisiciones

            With operacionLote
                .CantidadReservada = 1
                Select Case ProductosLotes.TipoMovimiento
                    Case 3 'vencida
                        .CantidadVencida = 2
                    Case 4 'no disponible
                        .CantidadNoDisponible = 2
                        dm.CANTIDADNODISPONIBLE = 1
                    Case 5 'temporal
                        .CantidadTemporal = 2
                    Case Else 'disponible
                        .CantidadDisponible = 2
                End Select
            End With
            Try
                Using db As New SinabEntities
                    requisiciones.AgregarDetalle(db, Req, dm)
                    Lotes.Actualizar(db, dm, operacionLote)
                    DetallesMovimiento.Agregar(dm, db)
                    db.SaveChanges()
                End Using
            Catch ex As Exception
                Throw ex
            End Try
        Next
        'verificar si todos los detalles se han procesado
        reqs.AsignarValeyProcesar(Req)

    End Sub

    Private Sub VerificarDuplicados(ByVal dl As SAB_ALM_DETALLEMOVIMIENTOS)
        Dim encontrado As Boolean

        encontrado = gvLista.DataKeys.Cast(Of DataKey)().Any(Function(item) item("IDLOTE") = DirectCast(dl.IDLOTE, Object))

        If encontrado Then
            Throw New Exception("Lote " + dl.IDLOTE.ToString + " ya ingresado.")
        End If
    End Sub

    Private Sub EvaluarEstados(ByVal detallependiente As Boolean)
        If Not Procesando Then
            btnCerrar.Visible = False
            btnImprimir.Visible = True
            btnProcesar.Visible = True
            btnGuardar.Visible = True
            If detallependiente Then btnProcesar.Enabled = False
        Else
            Select Case Req.Movimiento.IDESTADO
                Case EstadosMovimiento.Cerrado
                    cpFechaDespacho.Enabled = False
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
                Case EstadosMovimiento.Grabado
                    btnCerrar.Visible = False
                    btnGuardar.Visible = True
                    btnImprimir.Visible = True
                    btnProcesar.Visible = True
                    If detallependiente Then btnProcesar.Enabled = False
                Case EstadosMovimiento.EnProceso
                    btnGuardar.Visible = False
                    btnProcesar.Visible = False
                    btnImprimir.Visible = True
                    btnCerrar.Visible = True
                    btnCerrar.Enabled = True
                Case EstadosMovimiento.AceptadoPorDependecia
                    btnCerrar.Visible = True
                    btnImprimir.Visible = True
                    btnGuardar.Visible = False
                    btnProcesar.Visible = False
            End Select
        End If

    End Sub


#End Region

#Region "Variables Privadas"

    Private Const defaulttitle As String = "Nro. de documento: "
    Private Const newtitle As String = "Nuevo Documento"

#End Region


End Class
