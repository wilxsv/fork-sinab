Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports eWorld.UI

Partial Class FrmDetMantRecepcionDependencias
    Inherits System.Web.UI.Page
    Private mCompMovimientos As New cMOVIMIENTOS
    Private mEntMovimientos As New MOVIMIENTOS
    Private mCompDetalleMovimiento As New cDETALLEMOVIMIENTOS
    Private mEntDetalleMovimiento As New DETALLEMOVIMIENTOS
    Private mCompContratos As New cCONTRATOS
    Private mEntContratos As New CONTRATOS
    Private mCompModificativas As New cMODIFICATIVASCONTRATO
    Private mCompLote As New cLOTES
    Private mEntLote As New LOTES
    Private mCompRecibo As New cRECIBOSRECEPCION
    Private mEntRecibo As New RECIBOSRECEPCION
    Private mCompInformeCalidad As New cINFORMEMUESTRAS
    Private mEntInformeCalidad As New INFORMEMUESTRAS
    Private mCompUtilerias As New cUTILERIAS
    Private mCompAlmacenesEntregasContratos As New cALMACENESENTREGACONTRATOS
    Private mEntAlmacenesEntregasContratos As New ALMACENESENTREGACONTRATOS
    Private mCompDetalleAlmacenesEntregasContratos As New cDETALLEALMACENESENTREGACONTRATOS
    Private mEntDetalleAlmacenesEntregasContratos As DETALLEALMACENESENTREGACONTRATOS
    Private mCompProgramaDistribucion As New cPROGRAMADISTRIBUCION
    Private mEntProgramaDistribucion As New PROGRAMADISTRIBUCION
    Friend Shared _Operacion As String
    Friend Shared lIdMovimiento As Int64
    Friend Shared lIdTipoTran As Int64
    Friend Shared _IDPROVEEDOR As Int64
    Friend Shared _IDCONTRATO As Int64
    Friend Shared _IDESTABLECIMIENTO As Int64

    Public Property IDESTABLECIMIENTO() As Int64
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int64)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int64
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Int64)
            _IDPROVEEDOR = value
        End Set
    End Property

    Public Property IDCONTRATO() As Int64
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Int64)
            _IDCONTRATO = value
        End Set
    End Property

    Public Property Operacion() As String
        Get
            Return _Operacion
        End Get
        Set(ByVal Value As String)
            _Operacion = Value
            If Value = "Edicion" Then
                Me.PnlPrincipal.Visible = False
                Me.PnlDetalleRecepcion.Visible = True
                Me.PnlEncabezado.Visible = True
                Me.PnlRenglonesRecepcion.Visible = True
            Else
                Me.PnlPrincipal.Visible = True
                Me.PnlDetalleRecepcion.Visible = False
                Me.PnlEncabezado.Visible = False
                Me.PnlRenglonesRecepcion.Visible = False
                Me.ImgbCerrar.Visible = False
            End If
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False

        If Not Page.IsPostBack Then
            lIdMovimiento = Request.QueryString("IdMov")
            lIdTipoTran = 12
            If lIdMovimiento = 0 Then
                Operacion = "Nuevo"
                CargarValesPendientesRecepcion()
            Else
                Operacion = "Edicion"
                CargarDocumentoEdicion()
            End If
            'Me.DdlEMPLEADOS1.RecuperarNombreCompletoXEstablecimiento(Session.Item("IdEstablecimiento"))

            Me.DdlTIPOTRANSACCIONES1.Recuperar()
            Me.DdlTIPOTRANSACCIONES1.Enabled = False
            Me.DdlDEPENDENCIAS1.Recuperar()
            Me.DdlDEPENDENCIAS1.Enabled = False
            Me.DdlALMACENES1.RecuperarAlmacenEstablecimiento(Session.Item("IdEstablecimiento"))
            Me.DdlALMACENES1.Enabled = False
            Me.DdlALMACENES2.RecuperarAlmacenEstablecimiento(Session.Item("IdEstablecimiento"))
            Me.DdlALMACENES2.Enabled = False

        End If
    End Sub

    Private Sub CargarValesPendientesRecepcion()
        Dim dsMovimientos As Data.DataSet

        dsMovimientos = mCompMovimientos.ObtenerDsMovimientosFiltrado(Session.Item("IdEstablecimiento"), 2, 0, 0, Session.Item("IdDependencia"), 4, 10)
        If dsMovimientos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("No se encontro ningún vale de salida pendiente de recepción.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.dgLista.DataSource = dsMovimientos
            Me.dgLista.DataBind()
            Me.PnlPrincipal.Visible = False
        Else
            Me.dgLista.DataSource = dsMovimientos
            Me.dgLista.DataBind()
            Me.PnlPrincipal.Visible = True
        End If

    End Sub

    Private Function CargarDocumentoEdicion() As Int16
        'Asignamos el identificador del establecimiento a la propiedad global.
        IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntMovimientos.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
        mEntMovimientos.IDMOVIMIENTO = lIdMovimiento
        mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
        Me.TxtIddocumento.Text = lIdMovimiento

        mEntRecibo.IDALMACEN = mEntMovimientos.IDALMACEN
        mEntRecibo.IDRECIBO = mEntMovimientos.IDDOCUMENTO
        mEntRecibo.ANIO = mEntMovimientos.ANIO
        mCompRecibo.ObtenerRECIBOSRECEPCION(mEntRecibo)

        'Asignamos el identificador del proveedor y contrato a las propiedades globales.
        IDPROVEEDOR = mEntRecibo.IDPROVEEDOR
        IDCONTRATO = mEntRecibo.IDCONTRATO

        Me.txtDocumento.Text = mEntRecibo.IDRECIBO
        Me.DdlTIPOTRANSACCIONES1.SelectedValue = mEntMovimientos.IDTIPOTRANSACCION
        Me.DdlALMACENES1.SelectedValue = mEntMovimientos.IDALMACEN '******* Duda sobre el almacen
        'Me.TxtNombreAlmacen.Text = Session.Item("NombreAlmacen")
        Me.CalendarFechaDespacho.SelectedDate = mEntMovimientos.FECHAMOVIMIENTO
        Me.tmHora.SelectedTime = mEntMovimientos.FECHAMOVIMIENTO
        Me.TxtNumeroDocumentoRespalda.Text = 0 'Verificar el numero de documento que respalda
        Me.DdlEMPLEADOS1.RecuperarCodigoNombreXEstablecimiento(Session.Item("IdEstablecimiento"))
        Me.DdlEMPLEADOS1.SelectedValue = mEntMovimientos.IDEMPLEADORECIBE
        Me.TxtObservaciones.Text = mEntRecibo.OBSERVACION

        Me.PnlEncabezado.Visible = True
        Me.BtnDefRenglones.Visible = False
        Me.PnlDetalleRecepcion.Visible = True
        Me.PnlRenglonesRecepcion.Visible = True
        CargarDetalleRecepcion()

    End Function

    Private Function CargarDocumento() As Int16


        Me.DdlTIPOTRANSACCIONES1.SelectedValue = lIdTipoTran
        Me.DdlALMACENES1.SelectedValue = Session.Item("IdAlmacen")
        Me.TxtNumeroDocumentoRespalda.Text = mEntMovimientos.IDDOCUMENTO

        Me.PnlEncabezado.Visible = True
        CargarDetalleRecepcion()

    End Function

    Private Function CargarDetalleRecepcion() As Integer
        If Me.Operacion = "Edicion" Then
            Me.gvLista.DataSource = mCompMovimientos.ObtenerReciboRecepcionDS(Me.TxtIddocumento.Text, Session.Item("IdAlmacen"), Me.CalendarFechaDespacho.SelectedDate.Year)
            Me.gvLista.DataBind()

        End If
    End Function

    Private Function CrearDetalleRecepcion() As Integer
        Dim iRegistro As Int16 = 0

        For iRegistro = 0 To Me.gvLista.Rows.Count - 1
            mEntDetalleMovimiento.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntDetalleMovimiento.IDTIPOTRANSACCION = 12
            mEntDetalleMovimiento.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mEntDetalleMovimiento.IDDETALLEMOVIMIENTO = 0
            mEntDetalleMovimiento.IDALMACEN = Me.DdlALMACENES2.SelectedValue
            mEntDetalleMovimiento.IDLOTE = Me.gvLista.DataKeys(iRegistro).Values.Item("IDLOTE").ToString()
            mEntDetalleMovimiento.IDPRODUCTO = Me.gvLista.DataKeys(iRegistro).Values.Item("IDPRODUCTO").ToString()
            mEntDetalleMovimiento.RENGLON = iRegistro
            mEntDetalleMovimiento.CANTIDAD = CType(Me.gvLista.Rows(iRegistro).FindControl("TxtCantidadRecibida"), NumericBox).Text
            mEntDetalleMovimiento.CANTIDADRECHAZADA = Val(Me.gvLista.Rows(iRegistro).Cells(5).Text) - CType(Me.gvLista.Rows(iRegistro).FindControl("TxtCantidadRecibida"), NumericBox).Text
            mEntDetalleMovimiento.MONTO = Me.gvLista.DataKeys(iRegistro).Values.Item("PRECIOLOTE").ToString()
            mEntDetalleMovimiento.AUUSUARIOCREACION = User.Identity.Name
            mEntDetalleMovimiento.AUFECHACREACION = Now()
            mEntDetalleMovimiento.AUUSUARIOMODIFICACION = User.Identity.Name
            mEntDetalleMovimiento.AUFECHAMODIFICACION = Now()
            mEntDetalleMovimiento.ESTASINCRONIZADA = 0
            mCompDetalleMovimiento.ActualizarDETALLEMOVIMIENTOS(mEntDetalleMovimiento)

            'Ingreso de la información en lotes

            mEntLote.IDLOTE = mEntDetalleMovimiento.IDLOTE
            mEntLote.IDALMACEN = mEntDetalleMovimiento.IDALMACEN
            mEntLote.IDALMACENORIGEN = Me.DdlALMACENES1.SelectedValue
            mEntLote.IDPRODUCTO = mEntDetalleMovimiento.IDPRODUCTO
            mEntLote.IDUNIDADMEDIDA = Me.gvLista.DataKeys(iRegistro).Values.Item("IDUNIDADMEDIDA").ToString()
            mEntLote.CODIGO = Me.gvLista.Rows(iRegistro).Cells(2).Text
            mEntLote.PRECIOLOTE = mEntDetalleMovimiento.MONTO
            mEntLote.FECHAVENCIMIENTO = Me.gvLista.Rows(iRegistro).Cells(3).Text
            mEntLote.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntLote.IDRESPONSABLEDISTRIBUCION = Me.gvLista.DataKeys(iRegistro).Values.Item("IDRESPONSABLEDISTRIBUCION").ToString()
            mEntLote.IDFUENTEFINANCIAMIENTO = Me.gvLista.DataKeys(iRegistro).Values.Item("IDFUENTEFINANCIAMIENTO").ToString()
            mEntLote.CANTIDADDISPONIBLE = 0
            mEntLote.ESTADISPONIBLE = 0
            If mEntLote.AUUSUARIOCREACION = Nothing Then
                mEntLote.AUUSUARIOCREACION = User.Identity.Name
            End If
            If mEntLote.AUFECHACREACION = Nothing Then
                mEntLote.AUFECHACREACION = Now()
            End If
            mEntLote.AUUSUARIOMODIFICACION = User.Identity.Name
            mEntLote.AUFECHAMODIFICACION = Now()
            mEntLote.ESTASINCRONIZADA = 0

            mCompLote.Agregar(mEntLote)

        Next

    End Function

    Protected Sub BtnDefRenglones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDefRenglones.Click
        MsgBox1.ShowConfirm("Para continuar con el detalle de la recepción debe guardarse la información del recibo, desea continuar", "Q1", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "Q1" Then
            'Asignamos toda la información a la entidad para invocar el método de actualización de datos
            'para crear el encabezado del recibo de recepción.
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = 0
            lIdMovimiento = mCompMovimientos.ObtenerID(mEntMovimientos)
            Me.TxtIddocumento.Text = lIdMovimiento
            mEntMovimientos.IDTIPODOCREF = 2
            mEntMovimientos.NUMERODOCREF = Me.TxtNumeroDocumentoRespalda.Text
            mEntMovimientos.IDALMACEN = Session.Item("IdAlmacen")
            mEntMovimientos.ANIO = Me.CalendarFechaDespacho.SelectedDate.Year

            'Asignamos los datos necesarios para poder invocar el método para obtener el Número del recibo
            'de recepción.
            mEntRecibo.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntRecibo.ANIO = mEntMovimientos.ANIO
            Me.txtDocumento.Text = mCompRecibo.ObtenerID(mEntRecibo)

            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDespacho.SelectedDate & " " & Me.tmHora.SelectedTime.TimeOfDay.ToString
            mEntMovimientos.IDESTABLECIMIENTODESTINO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDALMACENDESTINO = Session.Item("IdAlmacen")
            mEntMovimientos.IDUNIDADSOLICITA = Session.Item("IdDependencia")
            mEntMovimientos.TOTALMOVIMIENTO = 0
            mEntMovimientos.IDEMPLEADOSOLICITA = Session.Item("IdEmpleado")
            mEntMovimientos.IDEMPLEADOALMACEN = Me.DdlEMPLEADOS1.SelectedValue
            mEntMovimientos.SUBCLASIFICACIONMOVIMIENTO = 1
            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.AUUSUARIOMODIFICACION = User.Identity.Name
            mEntMovimientos.AUFECHAMODIFICACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0

            If mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos) > 0 Then
                mEntRecibo.IDRECIBO = mEntMovimientos.IDDOCUMENTO
                mEntRecibo.IDESTABLECIMIENTO = mEntMovimientos.IDESTABLECIMIENTO
                mEntRecibo.NUMEROACTA = mEntMovimientos.IDDOCUMENTO
                mEntRecibo.OBSERVACION = Me.TxtObservaciones.Text
                If mEntRecibo.AUUSUARIOCREACION = Nothing Then
                    mEntRecibo.AUUSUARIOCREACION = User.Identity.Name
                End If
                If mEntRecibo.AUFECHACREACION = Nothing Then
                    mEntRecibo.AUFECHACREACION = Now()
                End If
                mEntRecibo.AUUSUARIOMODIFICACION = User.Identity.Name
                mEntRecibo.AUFECHAMODIFICACION = Now()
                mEntRecibo.ESTASINCRONIZADA = 0

                mCompRecibo.AgregarRECIBOSRECEPCION(mEntRecibo)

                'Función que crea el detalle de la recepción a partir del vale de salida.
                CrearDetalleRecepcion()
                Me.PnlDetalleRecepcion.Visible = True
                Me.PnlRenglonesRecepcion.Visible = True
                Me.BtnDefRenglones.Visible = False
                Me.ImgbCerrar.Visible = True

                Me.Operacion = "Edicion"

            Else
                'Mensaje que indica el error cometido
                MsgBox1.ShowAlert("La recepción no puede ser procesado, debido a que las tablas de requerimientos han sido modificadas de forma incorrecta, favor reportarlo al departamento de informatica.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                Me.PnlEncabezado.Visible = False
                Me.PnlDetalleRecepcion.Visible = False
                Me.PnlRenglonesRecepcion.Visible = False
                Me.PnlPrincipal.Visible = False
                Me.ImgbImprimir.Visible = False
                Me.ImgbGuardar.Visible = False
                Me.ImgbCerrar.Visible = False

            End If

        End If

        If e.Key = "Cerrar" Then
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = 12
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            mEntMovimientos.IDESTADO = 2
            mEntMovimientos.AUUSUARIOMODIFICACION = User.Identity.Name
            mEntMovimientos.AUFECHAMODIFICACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0
            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

            If Session.Item("FARMACIA") = 1 Then
                Dim dsDetalleLotes As Data.DataSet
                Dim iFila As Int32 = 0

                dsDetalleLotes = mCompDetalleMovimiento.ObtenerDataSetPorId(mEntMovimientos.IDESTABLECIMIENTO, mEntMovimientos.IDTIPOTRANSACCION, mEntMovimientos.IDMOVIMIENTO)

                For iFila = 0 To dsDetalleLotes.Tables(0).Rows.Count - 1
                    mCompUtilerias.ActualizarCantidadDisponible(mEntMovimientos.IDALMACEN, dsDetalleLotes.Tables(0).Rows(iFila).Item("IDLOTE"), 0, dsDetalleLotes.Tables(0).Rows(iFila).Item("CANTIDAD"))

                Next
            End If

            'Actualizar el estado de la requisición enlazada al estado de DESPACHADA VALOR 5
            mEntMovimientos.IDTIPOTRANSACCION = 1
            mEntMovimientos.IDMOVIMIENTO = mEntMovimientos.NUMERODOCREF
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            mEntMovimientos.IDESTADO = 8 'Indica que la requisición fue despacho por el almacén
            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)


            Response.Redirect("~/ALMACEN/FrmGeneraActaRecepcion.aspx?Idmov=" + Me.TxtIddocumento.Text + "&Oper=1")
        End If
    End Sub

    Protected Sub ImgbGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar.Click
        'Asignamos toda la información a la entidad para invocar el método de actualización de datos
        'para crear el encabezado del recibo de recepción.
        If Operacion = "Edicion" Then
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = lIdMovimiento
            Me.TxtIddocumento.Text = lIdMovimiento
            mEntMovimientos.IDTIPODOCREF = 2
            mEntMovimientos.NUMERODOCREF = Me.TxtNumeroDocumentoRespalda.Text
            mEntMovimientos.IDALMACEN = Session.Item("IdAlmacen")
            mEntMovimientos.ANIO = Me.CalendarFechaDespacho.SelectedDate.Year
            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.FECHAMOVIMIENTO = Format(Me.CalendarFechaDespacho.SelectedDate, "d") & " " & Me.tmHora.SelectedTime.TimeOfDay.ToString

            mEntMovimientos.IDESTABLECIMIENTODESTINO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDALMACENDESTINO = Session.Item("IdAlmacen")
            mEntMovimientos.IDUNIDADSOLICITA = Session.Item("IdDependencia")
            mEntMovimientos.TOTALMOVIMIENTO = 0
            'mEntMovimientos.IDEMPLEADORECIBE = Me.DdlEMPLEADOS1.SelectedValue
            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.AUUSUARIOMODIFICACION = User.Identity.Name
            mEntMovimientos.AUFECHAMODIFICACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0

            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

            mEntRecibo.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntRecibo.ANIO = mEntMovimientos.ANIO
            mEntRecibo.IDRECIBO = Me.txtDocumento.Text
            mEntRecibo.NUMEROACTA = mEntMovimientos.IDDOCUMENTO
            mEntRecibo.OBSERVACION = Me.TxtObservaciones.Text
            If mEntRecibo.AUUSUARIOCREACION = Nothing Then
                mEntRecibo.AUUSUARIOCREACION = User.Identity.Name
            End If
            If mEntRecibo.AUFECHACREACION = Nothing Then
                mEntRecibo.AUFECHACREACION = Now()
            End If
            mEntRecibo.AUUSUARIOMODIFICACION = User.Identity.Name
            mEntRecibo.AUFECHAMODIFICACION = Now()
            mEntRecibo.ESTASINCRONIZADA = 0

            mCompRecibo.ActualizarRECIBOSRECEPCION(mEntRecibo)

        Else

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
            mEntMovimientos.IDMOVIMIENTO = 0
            Me.TxtIddocumento.Text = mCompMovimientos.ObtenerID(mEntMovimientos)
            Me.txtDocumento.Text = Me.TxtIddocumento.Text
            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.IDTIPODOCREF = 2
            mEntMovimientos.NUMERODOCREF = Me.TxtNumeroDocumentoRespalda.Text
            mEntMovimientos.IDALMACEN = Session.Item("IdAlmacen")
            mEntMovimientos.ANIO = Me.CalendarFechaDespacho.SelectedDate.Year
            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.FECHAMOVIMIENTO = Format(Me.CalendarFechaDespacho.SelectedDate, "d") & " " & Me.tmHora.SelectedTime.TimeOfDay.ToString

            'mEntMovimientos.IDESTABLECIMIENTODESTINO = Session.Item("IdEstablecimiento") Por si acaso
            mEntMovimientos.IDESTABLECIMIENTODESTINO = Nothing
            mEntMovimientos.IDALMACENDESTINO = Session.Item("IdAlmacen")
            mEntMovimientos.IDUNIDADSOLICITA = Session.Item("IdDependencia")
            mEntMovimientos.TOTALMOVIMIENTO = 0
            mEntMovimientos.IDEMPLEADORECIBE = Me.DdlEMPLEADOS1.SelectedValue
            If mEntMovimientos.AUUSUARIOCREACION = Nothing Then
                mEntMovimientos.AUUSUARIOCREACION = User.Identity.Name
            End If
            If mEntMovimientos.AUFECHACREACION = Nothing Then
                mEntMovimientos.AUFECHACREACION = Now()
            End If
            mEntMovimientos.AUUSUARIOMODIFICACION = User.Identity.Name
            mEntMovimientos.AUFECHAMODIFICACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0

            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

            mEntRecibo.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntRecibo.ANIO = mEntMovimientos.ANIO
            mEntRecibo.IDRECIBO = Me.txtDocumento.Text
            mEntRecibo.NUMEROACTA = mEntMovimientos.IDDOCUMENTO
            mEntRecibo.OBSERVACION = Me.TxtObservaciones.Text
            If mEntRecibo.AUUSUARIOCREACION = Nothing Then
                mEntRecibo.AUUSUARIOCREACION = User.Identity.Name
            End If
            If mEntRecibo.AUFECHACREACION = Nothing Then
                mEntRecibo.AUFECHACREACION = Now()
            End If
            mEntRecibo.AUUSUARIOMODIFICACION = User.Identity.Name
            mEntRecibo.AUFECHAMODIFICACION = Now()
            mEntRecibo.ESTASINCRONIZADA = 0

            mCompRecibo.ActualizarRECIBOSRECEPCION(mEntRecibo)

        End If


    End Sub

    Protected Sub ImgbImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbImprimir.Click
        Session.Item("Contrato") = Me.IDCONTRATO
        Session.Item("Proveedor") = Me.IDPROVEEDOR
        Session.Item("Establecimiento") = Me.IDESTABLECIMIENTO

        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptReciboRecepcion.aspx?IdMov=" + Me.TxtIddocumento.Text + "&IdAnio=" + Me.CalendarFechaDespacho.SelectedDate.Year.ToString + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub ImgbCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCerrar.Click
        If Me.gvLista.Rows.Count = 0 Then
            MsgBox1.ShowAlert("Para realizar esta operación el documento debe poseer al menos un renglón definido", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        Else
            MsgBox1.ShowConfirm("Si cierra el documento, este ya no podrá ser modificado, ¿desea continuar?", "Cerrar", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
        End If
    End Sub

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Response.Redirect("~/ALMACEN/frmMantRecepcionProductos.aspx")
    End Sub

    Public Sub SeleccionarVale(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As New LinkButton
        b = sender

        'mCompResponsableContrato.EliminarRESPONSABLEDISTRIBUCIONCONTRATO(Session.Item("IdEstablecimiento"), PROVEEDOR, CONTRATO, b.CommandName)
        'RecuperarFuentes(Session.Item("IdEstablecimiento"), CONTRATO, PROVEEDOR)

        'Procedimiento de carga del vale de salida
        mEntMovimientos.IDESTABLECIMIENTO = b.CommandArgument
        mEntMovimientos.IDTIPOTRANSACCION = 2
        mEntMovimientos.IDMOVIMIENTO = b.CommandName

        mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

        Me.DdlTIPOTRANSACCIONES1.SelectedValue = 12
        Me.DdlDEPENDENCIAS1.SelectedValue = mEntMovimientos.IDUNIDADSOLICITA
        Me.DdlALMACENES2.SelectedValue = Session.Item("IdAlmacen")
        Me.TxtNumeroDocumentoRespalda.Text = mEntMovimientos.IDMOVIMIENTO
        Me.DdlALMACENES1.SelectedValue = mEntMovimientos.IDALMACEN
        Me.DdlEMPLEADOS1.RecuperarCodigoNombreXEstablecimiento(Session.Item("IdEstablecimiento"))
        Me.DdlEMPLEADOS1.SelectedValue = Session.Item("IdEmpleado")

        'Cargar el detalle de la recepción.
        Me.gvLista.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(b.CommandArgument, 2, b.CommandName)
        Me.gvLista.DataBind()

        Me.PnlPrincipal.Visible = False
        Me.PnlEncabezado.Visible = True
        Me.PnlDetalleRecepcion.Visible = True

    End Sub

    Protected Sub dgLista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged

    End Sub
End Class
