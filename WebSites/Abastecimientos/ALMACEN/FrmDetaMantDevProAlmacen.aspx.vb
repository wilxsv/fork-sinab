Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class FrmDetaMantDevProAlmacen
    Inherits System.Web.UI.Page
    Private mCompMovimientos As New cMOVIMIENTOS
    Private mEntMovimientos As New MOVIMIENTOS
    Private mCompDetalleMovimiento As New cDETALLEMOVIMIENTOS
    Private mEntDetalleMovimiento As New DETALLEMOVIMIENTOS
    Private mCompCatalogoProductos As New cCATALOGOPRODUCTOS
    Private mCompUtilerias As New cUTILERIAS
    Private mCompLote As New cLOTES
    Private mCompVale As New cVALESSALIDA
    Private mEntVale As New VALESSALIDA
    Friend Shared _Operacion As String
    Friend Shared lIdMovimiento As Int64
    Friend Shared lIdTipoTran As Int64

    Public Property Operacion() As String
        Get
            Return _Operacion
        End Get
        Set(ByVal Value As String)
            _Operacion = Value
            If Value = "Edicion" Then
                Me.BtnAgregarProducto.Enabled = True
                Me.BtnDefinirProductos.Visible = False
            Else
                Me.BtnAgregarProducto.Enabled = False
            End If
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False

        If Not Page.IsPostBack Then
            lIdMovimiento = Request.QueryString("IdMov")
            lIdTipoTran = Request.QueryString("IdTipTran")

            Me.DdlTIPOTRANSACCIONES1.Recuperar()
            Me.DdlTIPOTRANSACCIONES1.SelectedValue = lIdTipoTran
            Me.DdlTIPOTRANSACCIONES1.Enabled = False
            Me.DdlCATALOGOPRODUCTOS1.RecuperarHabilitados(Session.Item("IdEstablecimiento"))
            Me.DdlUNIDADMEDIDAS1.Recuperar()
            Me.DdlEMPLEADOS1.RecuperarNombreCompletoXEstablecimiento(Session.Item("IdEstablecimiento"))
            Me.DdlEMPLEADOS2.RecuperarNombreCompletoXEstablecimiento(Session.Item("IdEstablecimiento"))

            If lIdMovimiento = 0 Then
                Operacion = "Nuevo"
                Me.ImgbCerrar.Visible = False
            Else
                Operacion = "Edicion"
                Me.TxtIddocumento.Text = lIdMovimiento
                Me.PnlDetalle.Visible = True

            End If
            CargarDatos()
        End If
    End Sub

    Private Function CargarDatos() As Int16
        If Operacion = "Edicion" Then
            'Recuperando la información del movimiento a editar
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            Me.DdlTIPOTRANSACCIONES1.SelectedValue = mEntMovimientos.IDTIPOTRANSACCION
            Me.txtDocumento.Text = mEntMovimientos.IDDOCUMENTO
            Me.CalendarFechaDocumento.SelectedDate = mEntMovimientos.FECHAMOVIMIENTO
            Me.TxtNombreAlmacen.Text = Session.Item("NombreAlmacen")
            Me.TxtIdAlmacen.Text = mEntMovimientos.IDALMACEN
            Me.TxtNombreDependencia.Text = Session.Item("UsuarioDependencia")
            Me.TxtIdDependencia.Text = mEntMovimientos.IDUNIDADSOLICITA
            Me.DdlEMPLEADOS1.SelectedValue = mEntMovimientos.IDEMPLEADOSOLICITA
            Me.DdlEMPLEADOS2.SelectedValue = mEntMovimientos.IDEMPLEADOAUTORIZA

            'Carga de la información del vale de salida asociado
            mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntVale.IDVALE = mEntMovimientos.IDDOCUMENTO
            mEntVale.ANIO = mEntMovimientos.ANIO
            mCompVale.ObtenerVALESSALIDA(mEntVale)
            Me.TxtObservacion.Text = mEntVale.OBSERVACION

            'Carga del detalle del movimiento en el datagrid
            Me.dgLista.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntMovimientos.IDESTABLECIMIENTO, mEntMovimientos.IDTIPOTRANSACCION, mEntMovimientos.IDMOVIMIENTO)
            Me.dgLista.DataBind()

        ElseIf Operacion = "Nuevo" Then
            Me.TxtIddocumento.Text = 0
            Me.DdlEMPLEADOS1.SelectedValue = Session.Item("IdEmpleado")
            Me.TxtNombreAlmacen.Text = Session.Item("NombreAlmacen")
            Me.TxtIdAlmacen.Text = Session.Item("IdAlmacen")
            Me.TxtNombreDependencia.Text = Session.Item("UsuarioDependencia")
            Me.TxtIdDependencia.Text = Session.Item("IdDependencia")

        End If

    End Function

    Protected Sub ImgbCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCerrar.Click
        MsgBox1.ShowConfirm("Si cierra el documento, este ya no podrá ser modificado, ¿desea continuar?", "Q2", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "Q1" Then 'Verifica si el usuario desea crear el documento
            Me.BtnDefinirProductos.Visible = False

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = 0
            Me.TxtIddocumento.Text = mCompMovimientos.ObtenerID(mEntMovimientos)
            Me.txtDocumento.Text = mCompVale.RecuperarID(Me.TxtIdAlmacen.Text)
            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mEntMovimientos.ANIO = Me.CalendarFechaDocumento.SelectedDate.Year
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDocumento.SelectedDate
            mEntMovimientos.IDALMACEN = Me.TxtIdAlmacen.Text
            mEntMovimientos.IDALMACENDESTINO = Me.TxtIdAlmacen.Text
            mEntMovimientos.IDUNIDADSOLICITA = Me.TxtIdDependencia.Text
            mEntMovimientos.IDEMPLEADOSOLICITA = Me.DdlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDEMPLEADOAUTORIZA = Me.DdlEMPLEADOS2.SelectedValue
            mEntMovimientos.IDESTADO = 1
            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntMovimientos.AUFECHAMODIFICACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0

            mCompMovimientos.AgregarMOVIMIENTOS(mEntMovimientos)

            'Creación del vale de salida
            mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntVale.ANIO = Me.CalendarFechaDocumento.SelectedDate.Year
            mEntVale.IDVALE = 0
            mEntVale.OBSERVACION = Me.TxtObservacion.Text
            If mEntVale.AUUSUARIOCREACION = Nothing Then
                mEntVale.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntVale.AUFECHACREACION = Nothing Then
                mEntVale.AUFECHACREACION = Now()
            End If
            mEntVale.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntVale.AUFECHAMODIFICACION = Now()
            mEntVale.ESTASINCRONIZADA = 0

            mCompVale.ActualizarVALESSALIDA(mEntVale)

            Me.ImgbCerrar.Visible = True
            Me.PnlDetalle.Visible = True
            Me.BtnAgregarProducto.Enabled = True
            lIdMovimiento = Me.TxtIddocumento.Text
            Operacion = "Edicion"


        End If

        If e.Key = "Q2" Then 'Verifica si el usuario desea cerrar el documento
            'Recuperando la información del documento a ser cerrado
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

            mEntMovimientos.IDESTADO = 4 'Cambio del estado del documento
            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntMovimientos.AUFECHAMODIFICACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0
            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos) 'Invoca el metodo de actualización de datos

            Response.Redirect("~/ALMACEN/frmMantDevolverProductosAlmacen.aspx")
        End If

    End Sub

    Protected Sub ImgbGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar.Click
        If Operacion = "Edicion" Then

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDocumento.SelectedDate
            mEntMovimientos.IDALMACEN = Me.TxtIdAlmacen.Text
            mEntMovimientos.IDALMACENDESTINO = Me.TxtIdAlmacen.Text
            mEntMovimientos.ANIO = Me.CalendarFechaDocumento.SelectedDate.Year
            mEntMovimientos.IDUNIDADSOLICITA = Me.TxtIdDependencia.Text
            mEntMovimientos.IDEMPLEADOSOLICITA = Me.DdlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDEMPLEADOAUTORIZA = Me.DdlEMPLEADOS2.SelectedValue
            mEntMovimientos.IDESTADO = 1

            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.ESTASINCRONIZADA = 0

            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

            'Actualización del vale de salida
            mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntVale.IDVALE = mEntMovimientos.IDDOCUMENTO
            mEntVale.ANIO = mEntMovimientos.ANIO
            mCompVale.ObtenerVALESSALIDA(mEntVale)
            mEntVale.OBSERVACION = Me.TxtObservacion.Text
            If mEntVale.AUUSUARIOCREACION = Nothing Then
                mEntVale.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntVale.AUFECHACREACION = Nothing Then
                mEntVale.AUFECHACREACION = Now()
            End If
            mEntVale.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntVale.AUFECHAMODIFICACION = Now()
            mEntVale.ESTASINCRONIZADA = 0

            mCompVale.ActualizarVALESSALIDA(mEntVale)

        Else
            Me.BtnDefinirProductos.Visible = False

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = 0
            Me.TxtIddocumento.Text = mCompMovimientos.ObtenerID(mEntMovimientos)
            Me.txtDocumento.Text = mCompVale.RecuperarID(Me.TxtIdAlmacen.Text)

            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDocumento.SelectedDate
            mEntMovimientos.ANIO = Me.CalendarFechaDocumento.SelectedDate.Year
            mEntMovimientos.IDALMACEN = Me.TxtIdAlmacen.Text
            mEntMovimientos.IDALMACENDESTINO = Me.TxtIdAlmacen.Text
            mEntMovimientos.IDUNIDADSOLICITA = Me.TxtIdDependencia.Text
            mEntMovimientos.IDEMPLEADOSOLICITA = Me.DdlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDEMPLEADOAUTORIZA = Me.DdlEMPLEADOS2.SelectedValue
            mEntMovimientos.IDESTADO = 1
            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.ESTASINCRONIZADA = 0

            mCompMovimientos.AgregarMOVIMIENTOS(mEntMovimientos)

            'Creacion del vale de salida
            mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntVale.IDVALE = 0
            mEntVale.ANIO = mEntMovimientos.ANIO
            mEntVale.OBSERVACION = Me.TxtObservacion.Text
            If mEntVale.AUUSUARIOCREACION = Nothing Then
                mEntVale.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntVale.AUFECHACREACION = Nothing Then
                mEntVale.AUFECHACREACION = Now()
            End If
            mEntVale.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntVale.AUFECHAMODIFICACION = Now()
            mEntVale.ESTASINCRONIZADA = 0

            mCompVale.ActualizarVALESSALIDA(mEntVale)

            Me.ImgbCerrar.Visible = True
            Me.PnlDetalle.Visible = True
            Me.BtnAgregarProducto.Enabled = True
        End If
    End Sub

    Protected Sub BtnAgregarProducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAgregarProducto.Click
        Me.PnlAgregarProducto.Visible = True
        Me.TxtCanDisponible.Text = 0
        Me.rdblCriterio.SelectedValue = 0
        Me.DdlCATALOGOPRODUCTOS1.Visible = False
        Me.TxtProducto.Visible = True
        Me.TxtProducto.Text = ""
        Me.BtnBuscar.Visible = True
        Me.TxtPrecioUnitario.Text = 0
        Me.LblDescripcionCompleta.Text = ""
        Me.LblDescripcionCompleta.Visible = False
    End Sub

    Protected Sub BtnDefinirProductos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDefinirProductos.Click
        MsgBox1.ShowConfirm("Para continuar con el detalle de la requisición el documento debera ser creado, desea continuar", "Q1", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
    End Sub

    Public Sub EliminarProducto(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As New LinkButton
        b = sender

        If Session.Item("Farmacia") = 1 Then
            mCompUtilerias.ActualizarCantidadDisponible(Session.Item("IdAlmacen"), b.CommandArgument, 0, b.ToolTip)
        End If
        mCompDetalleMovimiento.EliminarDETALLEMOVIMIENTOS(Session.Item("IdEstablecimiento"), lIdTipoTran, Me.TxtIddocumento.Text, b.CommandName)
        CargarDatos()

    End Sub

    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
        If Me.rdblCriterio.SelectedValue = 0 Then
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.BtnBuscar.Visible = True
        Else
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.DdlCATALOGOPRODUCTOS1.Visible = True
            Me.LblDescripcionCompleta.Visible = False
            BuscarProductoLista()
        End If

    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim dsCatalogoProductos As Data.DataSet
        dsCatalogoProductos = mCompCatalogoProductos.FiltrarProductoDS(Me.TxtProducto.Text, 2)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado o no esta disponible para este almacén", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Text = ""
            Me.TxtProducto.Focus()
        Else
            Try
                Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                SeleccionarLote()
                Me.TxtPrecioUnitario.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("PRECIOACTUAL")
                Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")

                Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                Me.LblDescripcionCompleta.Visible = True
            Catch ex As Exception
                MsgBox1.ShowAlert("El código de producto no fue encontrado o no esta disponible para este almacén", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                Me.TxtProducto.Text = ""
                Me.TxtProducto.Focus()
            End Try

        End If
    End Sub

    Private Sub BuscarProductoLista() 
        Dim dsCatalogoProductos As Data.DataSet
        dsCatalogoProductos = mCompCatalogoProductos.FiltrarProductoDS(Me.DdlCATALOGOPRODUCTOS1.SelectedValue, 1)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Text = ""
            Me.TxtProducto.Focus()

        Else
            'SeleccionarLote()
            Me.TxtPrecioUnitario.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("PRECIOACTUAL")
            Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")

            Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
            Me.LblDescripcionCompleta.Visible = True
            SeleccionarLote()
        End If
    End Sub

    Private Sub SeleccionarLote()
        Dim dsProductoLote As Data.DataSet
        dsProductoLote = mCompLote.ObtenerDsLoteFiltrado(Me.DdlCATALOGOPRODUCTOS1.SelectedValue, Me.TxtIdAlmacen.Text, 1)
        If dsProductoLote.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("No se encontro ningun lote disponible para este producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            Me.DdlLOTES1.RecuperarListaPorProductoFiltrado(Me.TxtIdAlmacen.Text, Me.DdlCATALOGOPRODUCTOS1.SelectedValue, 1)
            Me.DdlUNIDADMEDIDAS1.SelectedValue = dsProductoLote.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
            Me.TxtPrecioUnitario.Text = dsProductoLote.Tables(0).Rows(0).Item("PRECIOLOTE")
            Me.TxtCanDisponible.Text = dsProductoLote.Tables(0).Rows(0).Item("CANTIDADDISPONIBLE")
        End If

    End Sub

    Protected Sub DdlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCATALOGOPRODUCTOS1.SelectedIndexChanged
        BuscarProductoLista()
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.PnlAgregarProducto.Visible = False
        Me.rdblCriterio.SelectedIndex = 1
        Me.DdlCATALOGOPRODUCTOS1.Visible = False
        Me.TxtProducto.Visible = True
        Me.TxtProducto.Text = Nothing
        Me.BtnBuscar.Visible = True
        Me.TxtPrecioUnitario.Text = 0
        Me.LblDescripcionCompleta.Text = Nothing
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Me.LblDescripcionCompleta.Text = "" Then
            MsgBox1.ShowAlert("La operación no puede ser realizada por que no se ha especificado ningun producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Focus()
            Exit Sub
        End If
        If Me.txtCantidad.Text = "" Or Val(Me.txtCantidad.Text) = 0 Then
            MsgBox1.ShowAlert("Especifique una cantidad valida para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.txtCantidad.Focus()
            Exit Sub
        End If
        If Me.TxtPrecioUnitario.Text = "" Then
            MsgBox1.ShowAlert("El precio debe ser mayor a cero", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtPrecioUnitario.Focus()
            Exit Sub
        End If
        If Val(Me.txtCantidad.Text) > Val(Me.TxtCanDisponible.Text) Then
            MsgBox1.ShowAlert("La cantidad solicitada no puede ser mayor a la cantidad disponible", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.txtCantidad.Focus()
            Exit Sub
        End If

        mEntDetalleMovimiento.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntDetalleMovimiento.IDTIPOTRANSACCION = Me.DdlTIPOTRANSACCIONES1.SelectedValue
        mEntDetalleMovimiento.IDMOVIMIENTO = Me.TxtIddocumento.Text
        mEntDetalleMovimiento.IDDETALLEMOVIMIENTO = 0
        mEntDetalleMovimiento.IDALMACEN = Me.TxtIdAlmacen.Text
        mEntDetalleMovimiento.IDLOTE = Me.DdlLOTES1.SelectedValue
        mEntDetalleMovimiento.IDPRODUCTO = Me.DdlCATALOGOPRODUCTOS1.SelectedValue
        mEntDetalleMovimiento.CANTIDAD = Me.txtCantidad.Text
        Me.TxtPrecioUnitario.AutoFormatCurrency = False
        mEntDetalleMovimiento.MONTO = Me.TxtPrecioUnitario.Text
        Me.TxtPrecioUnitario.AutoFormatCurrency = True
        If mEntDetalleMovimiento.AUUSUARIOCREACION = Nothing Then
            mEntDetalleMovimiento.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntDetalleMovimiento.AUFECHACREACION = Nothing Then
            mEntDetalleMovimiento.AUFECHACREACION = Now()
        End If
        mEntDetalleMovimiento.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntDetalleMovimiento.AUFECHAMODIFICACION = Now()

        If mCompDetalleMovimiento.ActualizarDETALLEMOVIMIENTOS(mEntDetalleMovimiento) > 0 Then
            If Session.Item("Farmacia") = 1 Then
                mCompUtilerias.ActualizarCantidadDisponible(Session.Item("IdAlmacen"), mEntDetalleMovimiento.IDLOTE, 1, mEntDetalleMovimiento.CANTIDAD)
            End If
        End If

        Me.dgLista.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntDetalleMovimiento.IDESTABLECIMIENTO, mEntDetalleMovimiento.IDTIPOTRANSACCION, mEntDetalleMovimiento.IDMOVIMIENTO)
        Me.dgLista.DataBind()

        Me.PnlAgregarProducto.Visible = False
    End Sub

    Protected Sub DdlLOTES1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlLOTES1.SelectedIndexChanged
        Dim dsLotes As Data.DataSet
        dsLotes = mCompLote.ObtenerLotePorIdloteDS(Me.TxtIdAlmacen.Text, Me.DdlLOTES1.SelectedValue)

        Me.TxtPrecioUnitario.Text = dsLotes.Tables(0).Rows(0).Item("PRECIOLOTE")
        Me.DdlUNIDADMEDIDAS1.SelectedValue = dsLotes.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
        Me.TxtCanDisponible.Text = dsLotes.Tables(0).Rows(0).Item("CANTIDADDISPONIBLE")

    End Sub

    Protected Sub ImgbImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbImprimir.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptDevolucionProductos.aspx?IdMovimiento=" + Me.TxtIddocumento.Text + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Response.Redirect("~/ALMACEN/FrmMantDevolverProductosAlmacen.aspx")
    End Sub
End Class
