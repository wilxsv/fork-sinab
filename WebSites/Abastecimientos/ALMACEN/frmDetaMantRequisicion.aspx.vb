Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class frmDetaMantRequisicion
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
                Me.BtnAgregarProducto.Enabled = True
                Me.BtnDefinirProductos.Visible = False
                Me.ImgbCerrar.Visible = True
                Me.ImgbImprimir.Visible = True
            Else
                Me.BtnAgregarProducto.Enabled = False
                Me.ImgbCerrar.Visible = False
                Me.ImgbImprimir.Visible = False
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
            Me.DdlEMPLEADOS1.RecuperarCodigoNombreXEstablecimiento(Session.Item("IdEstablecimiento"))
            Me.DdlEMPLEADOS2.RecuperarCodigoNombreXEstablecimiento(Session.Item("IdEstablecimiento"))
            Me.DdlALMACENESESTABLECIMIENTOS1.RecuperarAlmacenPrincipal(Session.Item("IdEstablecimiento"))
            If Me.DdlALMACENESESTABLECIMIENTOS1.Items.Count = 1 Then
                Me.DdlALMACENESESTABLECIMIENTOS1.Enabled = False
            Else
                Me.DdlALMACENESESTABLECIMIENTOS1.Enabled = True 
            End If

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
            If Session.Item("NombreAlmacen") = "" Then
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

    Private Function CargarDatos() As Int16
        If Operacion = "Edicion" Then
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            Me.DdlTIPOTRANSACCIONES1.SelectedValue = mEntMovimientos.IDTIPOTRANSACCION
            Me.txtDocumento.Text = mEntMovimientos.IDDOCUMENTO
            Me.CalendarFechaDocumento.Text = mEntMovimientos.FECHAMOVIMIENTO
            Me.DdlALMACENESESTABLECIMIENTOS1.SelectedValue = mEntMovimientos.IDALMACENDESTINO
            Me.TxtResponsableDis.Text = mEntMovimientos.RESPONSABLEDISTRIBUCION
            Me.TxtNombreDependencia.Text = Session.Item("UsuarioDependencia")
            Me.TxtIdDependencia.Text = mEntMovimientos.IDUNIDADSOLICITA
            Me.DdlEMPLEADOS1.SelectedValue = mEntMovimientos.IDEMPLEADOSOLICITA
            Me.DdlEMPLEADOS2.SelectedValue = mEntMovimientos.IDEMPLEADOAUTORIZA


            Me.dgLista.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntMovimientos.IDESTABLECIMIENTO, mEntMovimientos.IDTIPOTRANSACCION, mEntMovimientos.IDMOVIMIENTO)
            Me.dgLista.DataBind()

        ElseIf Operacion = "Nuevo" Then
            Me.TxtIddocumento.Text = 0
            Me.DdlEMPLEADOS1.SelectedValue = Session.Item("IdEmpleado")
            Me.TxtNombreDependencia.Text = Session.Item("UsuarioDependencia")
            Me.TxtIdDependencia.Text = Session.Item("IdDependencia")

        End If

    End Function

    Protected Sub ImgbCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCerrar.Click
        MsgBox1.ShowConfirm("Si cierra el documento este será enviado al almacén para su despacho y ya no lo podrá modificar. ¿Esta seguro que lo desea cerrar?", "Q2", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)

    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "Q1" Then
            Me.BtnDefinirProductos.Visible = False

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = 0
            Me.TxtIddocumento.Text = mCompMovimientos.ObtenerID(mEntMovimientos)
            Me.txtDocumento.Text = Me.TxtIddocumento.Text

            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDocumento.SelectedDate
            mEntMovimientos.IDALMACEN = Session.Item("Idalmacen")
            mEntMovimientos.IDALMACENDESTINO = Me.DdlALMACENESESTABLECIMIENTOS1.SelectedValue
            mEntMovimientos.RESPONSABLEDISTRIBUCION = Me.TxtResponsableDis.Text
            mEntMovimientos.IDUNIDADSOLICITA = Me.TxtIdDependencia.Text
            mEntMovimientos.IDEMPLEADOSOLICITA = Me.DdlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDEMPLEADOAUTORIZA = Me.DdlEMPLEADOS2.SelectedValue

            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.CLASIFICACIONMOVIMIENTO = 10

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

            Me.ImgbCerrar.Visible = True
            Me.PnlDetalle.Visible = True
            Me.BtnAgregarProducto.Enabled = True

            lIdMovimiento = Me.TxtIddocumento.Text
            Operacion = "Edicion"

            Me.ImgbImprimir.Visible = True
            Me.ImgbCerrar.Visible = True

        End If

        If e.Key = "Q2" Then
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

            mEntMovimientos.IDESTADO = 4
            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntMovimientos.AUFECHAMODIFICACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0
            mEntMovimientos.CLASIFICACIONMOVIMIENTO = 10
            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

            Response.Redirect("~/ALMACEN/frmMantRequesicion.aspx")
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
            mEntMovimientos.IDALMACEN = Session.Item("IdAlmacen")
            mEntMovimientos.IDALMACENDESTINO = Me.DdlALMACENESESTABLECIMIENTOS1.SelectedValue
            mEntMovimientos.RESPONSABLEDISTRIBUCION = Me.TxtResponsableDis.Text
            mEntMovimientos.IDUNIDADSOLICITA = Me.TxtIdDependencia.Text
            mEntMovimientos.IDEMPLEADOSOLICITA = Me.DdlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDEMPLEADOAUTORIZA = Me.DdlEMPLEADOS2.SelectedValue

            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.CLASIFICACIONMOVIMIENTO = 10

            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.ESTASINCRONIZADA = 0

            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)
        Else
            Me.BtnDefinirProductos.Visible = False

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = 0
            Me.TxtIddocumento.Text = mCompMovimientos.ObtenerID(mEntMovimientos)
            Me.txtDocumento.Text = Me.TxtIddocumento.Text

            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDocumento.SelectedDate
            mEntMovimientos.IDALMACEN = Session.Item("IdAlmacen")
            mEntMovimientos.IDALMACENDESTINO = Me.DdlALMACENESESTABLECIMIENTOS1.SelectedValue
            mEntMovimientos.RESPONSABLEDISTRIBUCION = Me.TxtResponsableDis.Text
            mEntMovimientos.IDUNIDADSOLICITA = Me.TxtIdDependencia.Text
            mEntMovimientos.IDEMPLEADOSOLICITA = Me.DdlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDEMPLEADOAUTORIZA = Me.DdlEMPLEADOS2.SelectedValue

            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.CLASIFICACIONMOVIMIENTO = 10

            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.ESTASINCRONIZADA = 0

            mCompMovimientos.AgregarMOVIMIENTOS(mEntMovimientos)

            Me.ImgbCerrar.Visible = True
            Me.PnlDetalle.Visible = True
            Me.BtnAgregarProducto.Enabled = True
        End If
    End Sub

    Protected Sub BtnAgregarProducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAgregarProducto.Click
        Me.PnlAgregarProducto.Visible = True
        Me.rdblCriterio.SelectedIndex = 0
        Me.DdlCATALOGOPRODUCTOS1.Visible = False
        Me.TxtProducto.Visible = True
        Me.TxtProducto.Text = Nothing
        Me.BtnBuscar.Visible = True
        Me.TxtPrecioUnitario.Text = 0
        Me.txtCantidad.Text = 0
        Me.LblDescripcionCompleta.Text = Nothing
    End Sub

    Protected Sub BtnDefinirProductos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDefinirProductos.Click
        MsgBox1.ShowConfirm("Para continuar con el detalle de la requisición el documento debe ser creado, con lo cual algunos datos no podran ser editados. ¿Desea continuar con el proceso?", "Q1", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
    End Sub

    Public Sub EliminarProducto(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As New LinkButton
        b = sender

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
                'SeleccionarLote()
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

    Private Function BuscarProductoLista() As Int16
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
        End If
    End Function

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

        mEntDetalleMovimiento.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntDetalleMovimiento.IDTIPOTRANSACCION = Me.DdlTIPOTRANSACCIONES1.SelectedValue
        mEntDetalleMovimiento.IDMOVIMIENTO = Me.TxtIddocumento.Text
        mEntDetalleMovimiento.IDALMACEN = Session.Item("IdAlmacen")
        mEntDetalleMovimiento.IDPRODUCTO = Me.DdlCATALOGOPRODUCTOS1.SelectedValue
        mEntDetalleMovimiento.CANTIDAD = Me.txtCantidad.Text
        mEntDetalleMovimiento.MONTO = Me.TxtPrecioUnitario.Text
        If mEntDetalleMovimiento.AUUSUARIOCREACION = Nothing Then
            mEntDetalleMovimiento.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntDetalleMovimiento.AUFECHACREACION = Nothing Then
            mEntDetalleMovimiento.AUFECHACREACION = Now()
        End If
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

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Response.Redirect("~/ALMACEN/frmMantRequesicion.aspx")
    End Sub
End Class