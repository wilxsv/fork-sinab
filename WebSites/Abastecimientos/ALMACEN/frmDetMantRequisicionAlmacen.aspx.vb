Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class frmDetMantRequisicionAlmacen
    Inherits System.Web.UI.Page

    Private mCompMovimientos As New cMOVIMIENTOS
    Private mEntMovimientos As New MOVIMIENTOS
    Private mCompDetalleMovimiento As New cDETALLEMOVIMIENTOS
    Private mEntDetalleMovimiento As New DETALLEMOVIMIENTOS
    Private mCompCatalogoProductos As New cCATALOGOPRODUCTOS
    Private mCompLote As New cLOTES

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
                Me.btnAgregarProducto.Enabled = True
                Me.btnDefinirProductos.Visible = False

            Else
                Me.btnAgregarProducto.Enabled = False
            End If
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            lIdMovimiento = Request.QueryString("IdMov")
            lIdTipoTran = Request.QueryString("IdTipTran")

            Me.ddlTIPOTRANSACCIONES1.Recuperar()
            Me.ddlTIPOTRANSACCIONES1.SelectedValue = lIdTipoTran
            Me.ddlTIPOTRANSACCIONES1.Enabled = False

            Me.ddlTIPOSUMINISTROS1.Recuperar()
            Me.ddlGRUPOS1.RecuperarListaFiltrada2(Me.ddlTIPOSUMINISTROS1.SelectedValue)
            Me.ddlSUBGRUPOS1.RecuperarListaFiltrada2(Me.ddlGRUPOS1.SelectedValue)

            Me.ddlCATALOGOPRODUCTOS1.RecuperarListaDescripcionLargaTodos()
            Me.ddlUNIDADMEDIDAS1.Recuperar()
            Me.ddlEMPLEADOS1.RecuperarCodigoNombreXEstablecimiento(Session.Item("IdEstablecimiento"))
            Me.ddlEMPLEADOS2.RecuperarCodigoNombreXEstablecimiento(Session.Item("IdEstablecimiento"))
            Me.ddlALMACENES1.Recuperar()

            If lIdMovimiento = 0 Then
                Operacion = "Nuevo"
                Me.ImgbCerrar.Visible = False
            Else
                Operacion = "Edicion"
                Me.TxtIddocumento.Text = lIdMovimiento
                Me.PnlDetalle.Visible = True
            End If

            CargarDatos()

            'Validacion de datos
            If Me.TxtNombreAlmacen.Text = "" Then
                MsgBox1.ShowAlert("La configuración del usuario esta incompleta, no se puede continuar con este proceso hasta que se resuelva el problema. Favor reporte este suceso al departamento de informática. ", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                Me.PnlEncabezado.Visible = False
                Me.PnlDetalle.Visible = False
                Me.PnlAgregarProducto.Visible = False
                Me.ImgbCerrar.Visible = False
                Me.ImgbGuardar.Visible = False
                Me.ImgbImprimir.Visible = False
            End If
        End If
    End Sub

    Private Sub CargarDatos()

        If Operacion = "Edicion" Then
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            Me.ddlTIPOTRANSACCIONES1.SelectedValue = mEntMovimientos.IDTIPOTRANSACCION
            Me.txtDocumento.Text = mEntMovimientos.IDDOCUMENTO
            Me.CalendarFechaDocumento.Text = mEntMovimientos.FECHAMOVIMIENTO
            Me.TxtNombreAlmacen.Text = Session.Item("NombreAlmacen")
            Me.TxtIdAlmacen.Text = mEntMovimientos.IDALMACEN
            Me.TxtNombreDependencia.Text = Session.Item("UsuarioDependencia")
            Me.TxtResponsableDis.Text = mEntMovimientos.RESPONSABLEDISTRIBUCION
            Me.TxtIdDependencia.Text = mEntMovimientos.IDUNIDADSOLICITA
            Me.ddlALMACENES1.SelectedValue = mEntMovimientos.IDALMACENDESTINO
            Me.ddlEMPLEADOS1.SelectedValue = mEntMovimientos.IDEMPLEADOSOLICITA
            Me.ddlEMPLEADOS2.SelectedValue = mEntMovimientos.IDEMPLEADOAUTORIZA

            Me.dgLista.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntMovimientos.IDESTABLECIMIENTO, mEntMovimientos.IDTIPOTRANSACCION, mEntMovimientos.IDMOVIMIENTO)
            Me.dgLista.DataBind()

        ElseIf Operacion = "Nuevo" Then
            Me.TxtIddocumento.Text = 0
            Me.ddlEMPLEADOS1.SelectedValue = Session.Item("IdEmpleado")
            Me.TxtNombreAlmacen.Text = Session.Item("NombreAlmacen")
            Me.TxtIdAlmacen.Text = Session.Item("IdAlmacen")
            Me.TxtNombreDependencia.Text = Session.Item("UsuarioDependencia")
            Me.TxtIdDependencia.Text = Session.Item("IdDependencia")

        End If

    End Sub

    Protected Sub ImgbCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCerrar.Click
        MsgBox1.ShowConfirm("Si cierra el documento este será enviado al almacén para su despacho y ya no lo podrá modificar. ¿Esta seguro que lo desea cerrar?", "Q2", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)

    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "Q1" Then
            Me.btnDefinirProductos.Visible = False

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = 0
            Me.TxtIddocumento.Text = mCompMovimientos.ObtenerID(mEntMovimientos)
            Me.txtDocumento.Text = Me.TxtIddocumento.Text

            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDocumento.SelectedDate
            mEntMovimientos.IDALMACEN = Me.TxtIdAlmacen.Text
            mEntMovimientos.IDALMACENDESTINO = Me.ddlALMACENES1.SelectedValue
            mEntMovimientos.RESPONSABLEDISTRIBUCION = Me.TxtResponsableDis.Text
            mEntMovimientos.IDUNIDADSOLICITA = Me.TxtIdDependencia.Text
            mEntMovimientos.IDEMPLEADOSOLICITA = Me.ddlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDEMPLEADOAUTORIZA = Me.ddlEMPLEADOS2.SelectedValue
            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.CLASIFICACIONMOVIMIENTO = 0

            mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntMovimientos.AUFECHACREACION = Now()

            mEntMovimientos.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntMovimientos.AUFECHAMODIFICACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0

            mCompMovimientos.AgregarMOVIMIENTOS(mEntMovimientos)

            Me.ImgbCerrar.Visible = True
            Me.PnlDetalle.Visible = True
            Me.btnAgregarProducto.Enabled = True

            lIdMovimiento = Me.TxtIddocumento.Text
            Operacion = "Edicion"

        End If

        If e.Key = "Q2" Then
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

            mEntMovimientos.IDESTADO = 4
            mEntMovimientos.CLASIFICACIONMOVIMIENTO = 0
            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntMovimientos.AUFECHAMODIFICACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0
            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

            Response.Redirect("~/ALMACEN/FrmMantRequisicionAlmacen.aspx")
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
            mEntMovimientos.IDALMACENDESTINO = Me.ddlALMACENES1.SelectedValue
            mEntMovimientos.RESPONSABLEDISTRIBUCION = Me.TxtResponsableDis.Text
            mEntMovimientos.IDUNIDADSOLICITA = Me.TxtIdDependencia.Text
            mEntMovimientos.IDEMPLEADOSOLICITA = Me.ddlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDEMPLEADOAUTORIZA = Me.ddlEMPLEADOS2.SelectedValue
            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.CLASIFICACIONMOVIMIENTO = 0

            mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntMovimientos.AUFECHACREACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0

            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)
        Else
            Me.btnDefinirProductos.Visible = False

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = 0
            Me.TxtIddocumento.Text = mCompMovimientos.ObtenerID(mEntMovimientos)
            Me.txtDocumento.Text = Me.TxtIddocumento.Text

            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDocumento.SelectedDate
            mEntMovimientos.IDALMACEN = Me.TxtIdAlmacen.Text
            mEntMovimientos.IDALMACENDESTINO = Me.ddlALMACENES1.SelectedValue
            mEntMovimientos.RESPONSABLEDISTRIBUCION = Me.TxtResponsableDis.Text
            mEntMovimientos.IDUNIDADSOLICITA = Me.TxtIdDependencia.Text
            mEntMovimientos.IDEMPLEADOSOLICITA = Me.ddlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDEMPLEADOAUTORIZA = Me.ddlEMPLEADOS2.SelectedValue
            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.CLASIFICACIONMOVIMIENTO = 0

            mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntMovimientos.AUFECHACREACION = Now()

            mEntMovimientos.ESTASINCRONIZADA = 0

            mCompMovimientos.AgregarMOVIMIENTOS(mEntMovimientos)

            Me.ImgbCerrar.Visible = True
            Me.PnlDetalle.Visible = True
            Me.btnAgregarProducto.Enabled = True
        End If
    End Sub

    Protected Sub btnAgregarProducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarProducto.Click
        Me.PnlAgregarProducto.Visible = True
        Me.rdblCriterio.SelectedIndex = 0
        Me.ddlCATALOGOPRODUCTOS1.Visible = False
        Me.TxtProducto.Visible = True
        Me.TxtProducto.Text = Nothing
        Me.btnBuscar.Visible = True
        Me.TxtPrecioUnitario.Text = 0
        Me.txtCantidad.Text = 0
        Me.LblDescripcionCompleta.Text = Nothing
    End Sub

    Protected Sub btnDefinirProductos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDefinirProductos.Click
        MsgBox1.ShowConfirm("Para continuar con el detalle de la requisición el documento deberá ser creado, desea continuar", "Q1", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
    End Sub

    Public Sub EliminarProducto(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As New LinkButton
        b = sender

        mCompDetalleMovimiento.EliminarDETALLEMOVIMIENTOS(Session.Item("IdEstablecimiento"), lIdTipoTran, Me.TxtIddocumento.Text, b.CommandName)
        CargarDatos()

    End Sub

    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
        If Me.rdblCriterio.SelectedValue = 0 Then
            Me.ddlCATALOGOPRODUCTOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.btnBuscar.Visible = True
            Me.btnActivarFiltro.Visible = False
            Me.PnlFiltroSeleccion.Visible = False
        Else
            Me.TxtProducto.Visible = False
            Me.btnBuscar.Visible = False
            Me.ddlCATALOGOPRODUCTOS1.Visible = True
            Me.LblDescripcionCompleta.Visible = False
            Me.btnActivarFiltro.Visible = True
            BuscarProductosLista()
        End If

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim dsCatalogoProductos As Data.DataSet
        dsCatalogoProductos = mCompCatalogoProductos.FiltrarProductoDS(Me.TxtProducto.Text, 2)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Text = ""
            Me.TxtProducto.Focus()
        Else
            Me.ddlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
            'SeleccionarLote()
            Me.TxtPrecioUnitario.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("PRECIOACTUAL")
            Me.ddlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")

            Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
            Me.LblDescripcionCompleta.Visible = True
        End If
    End Sub

    Private Function BuscarProductosLista() As Int16
        Dim dsCatalogoProductos As Data.DataSet
        dsCatalogoProductos = mCompCatalogoProductos.FiltrarProductoDS(Me.ddlCATALOGOPRODUCTOS1.SelectedValue, 1)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Text = ""
            Me.TxtProducto.Focus()
        Else

            Me.TxtPrecioUnitario.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("PRECIOACTUAL")
            Me.ddlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")

            Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
            Me.LblDescripcionCompleta.Visible = True
        End If

    End Function

    Protected Sub ddlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCATALOGOPRODUCTOS1.SelectedIndexChanged
        BuscarProductosLista()
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.PnlAgregarProducto.Visible = False
        Me.rdblCriterio.SelectedIndex = 1
        Me.ddlCATALOGOPRODUCTOS1.Visible = False
        Me.TxtProducto.Visible = True
        Me.TxtProducto.Text = Nothing
        Me.btnBuscar.Visible = True
        Me.TxtPrecioUnitario.Text = 0
        Me.LblDescripcionCompleta.Text = Nothing
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
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

        mEntDetalleMovimiento.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntDetalleMovimiento.IDTIPOTRANSACCION = Me.ddlTIPOTRANSACCIONES1.SelectedValue
        mEntDetalleMovimiento.IDMOVIMIENTO = Me.TxtIddocumento.Text
        mEntDetalleMovimiento.IDDETALLEMOVIMIENTO = 0
        mEntDetalleMovimiento.IDALMACEN = Me.TxtIdAlmacen.Text
        mEntDetalleMovimiento.IDPRODUCTO = Me.ddlCATALOGOPRODUCTOS1.SelectedValue
        mEntDetalleMovimiento.CANTIDAD = Me.txtCantidad.Text
        mEntDetalleMovimiento.MONTO = Me.TxtPrecioUnitario.Text

        mEntDetalleMovimiento.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntDetalleMovimiento.AUFECHACREACION = Now()

        mEntDetalleMovimiento.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntDetalleMovimiento.AUFECHAMODIFICACION = Now()
        mEntDetalleMovimiento.ESTASINCRONIZADA = 0

        mEntDetalleMovimiento.IDDETALLEMOVIMIENTO = mCompDetalleMovimiento.BuscarProductoDetalle(mEntDetalleMovimiento.IDESTABLECIMIENTO, mEntDetalleMovimiento.IDTIPOTRANSACCION, mEntDetalleMovimiento.IDMOVIMIENTO, mEntDetalleMovimiento.IDPRODUCTO)

        If mEntDetalleMovimiento.IDDETALLEMOVIMIENTO > 0 Then
            mCompDetalleMovimiento.ObtenerDETALLEMOVIMIENTOS(mEntDetalleMovimiento)
            mEntDetalleMovimiento.CANTIDAD = mEntDetalleMovimiento.CANTIDAD + Val(Me.txtCantidad.Text)
        End If

        mCompDetalleMovimiento.ActualizarDETALLEMOVIMIENTOS(mEntDetalleMovimiento)

        Me.dgLista.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntDetalleMovimiento.IDESTABLECIMIENTO, mEntDetalleMovimiento.IDTIPOTRANSACCION, mEntDetalleMovimiento.IDMOVIMIENTO)
        Me.dgLista.DataBind()

        Me.PnlAgregarProducto.Visible = False
    End Sub

    Protected Sub ImgbImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbImprimir.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRequisicion.aspx?IdMovimiento=" + Me.TxtIddocumento.Text + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub btnActivarFiltro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActivarFiltro.Click
        Me.PnlFiltroSeleccion.Visible = True
        Me.ddlTIPOSUMINISTROS1.Recuperar()
        Me.ddlGRUPOS1.RecuperarListaFiltrada2(Me.ddlTIPOSUMINISTROS1.SelectedValue)
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada2(Me.ddlGRUPOS1.SelectedValue)
        Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo(Me.ddlSUBGRUPOS1.SelectedValue)
    End Sub

    Protected Sub ddlTIPOSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTIPOSUMINISTROS1.SelectedIndexChanged
        Me.ddlGRUPOS1.RecuperarListaFiltrada2(Me.ddlTIPOSUMINISTROS1.SelectedValue)
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada2(Me.ddlGRUPOS1.SelectedValue)
        Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo(Me.ddlSUBGRUPOS1.SelectedValue)
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada2(Me.ddlGRUPOS1.SelectedValue)
        Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo(Me.ddlSUBGRUPOS1.SelectedValue)
    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo(Me.ddlSUBGRUPOS1.SelectedValue)
    End Sub

End Class
