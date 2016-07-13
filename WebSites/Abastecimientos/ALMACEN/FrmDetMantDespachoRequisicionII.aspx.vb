Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class FrmDetMantDespachoRequisicionII
    Inherits System.Web.UI.Page

    Private mCompMovimientos As New cMOVIMIENTOS
    Private mEntMovimientos As New MOVIMIENTOS
    Private mCompDetalleMovimiento As New cDETALLEMOVIMIENTOS
    Private mEntDetalleMovimiento As New DETALLEMOVIMIENTOS
    Private mCompCatalogoProductos As New cCATALOGOPRODUCTOS
    Private mCompProgramaDistribucion As New cPROGRAMADISTRIBUCION
    Private mCompLote As New cLOTES
    Private mEntLote As New LOTES
    Private mCompVale As New cVALESSALIDA
    Private mEntVale As New VALESSALIDA
    Private mCompUtilerias As New cUTILERIAS
    Private mCompExistenciasAlmacenes As New cEXISTENCIASALMACENES
    Private mEntExistenciasAlmacenes As New EXISTENCIASALMACENES
    Friend Shared _Operacion As String
    Friend Shared _DOCUMENTOENLACE As Int64
    Friend Shared lIdMovimiento As Int64
    Friend Shared _EstablecimientoSolicita As Int64
    Friend Shared _AlmacenSolicita As Int64

    Public Property EstablecimientoSolicita() As Int64
        Get
            Return _EstablecimientoSolicita
        End Get
        Set(ByVal value As Int64)
            _EstablecimientoSolicita = value
        End Set
    End Property

    Public Property AlmacenSolicita() As Int64
        Get
            Return _AlmacenSolicita
        End Get
        Set(ByVal value As Int64)
            _AlmacenSolicita = value
        End Set
    End Property

    Public Property DOCUMENTOENLACE() As Int64
        Get
            Return _DOCUMENTOENLACE
        End Get
        Set(ByVal value As Int64)
            _DOCUMENTOENLACE = value
        End Set
    End Property

    Public Property Operacion() As String
        Get
            Return _Operacion
        End Get
        Set(ByVal Value As String)
            _Operacion = Value
            If Value = "Edicion" Then
                Me.BtDefinirDetalle.Visible = False
            Else
                Me.BtDefinirDetalle.Visible = True
            End If
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False

        If Not Page.IsPostBack Then
            lIdMovimiento = Request.QueryString("IdMov")
            Me.DOCUMENTOENLACE = Request.QueryString("IdReq")
            Me.EstablecimientoSolicita = Request.QueryString("IdEst")
            Me.AlmacenSolicita = Request.QueryString("IdAlm")

            Me.DdlTIPOTRANSACCIONES1.Recuperar()
            Me.DdlTIPOTRANSACCIONES1.SelectedValue = 2
            Me.DdlTIPOTRANSACCIONES1.Enabled = False
            Me.DdlEMPLEADOS1.RecuperarNombreCompletoXEstablecimiento(Session.Item("IdEstablecimiento"))
            Me.DdlRESPONSABLEDISTRIBUCION1.Recuperar()
            Me.DdlFUENTEFINANCIAMIENTOS1.Recuperar()
            Me.DdlUNIDADMEDIDAS2.Recuperar()
            Me.DdlESTABLECIMIENTOS1.RecuperarCodigoEstablecimiento()

            'Evalua si el documento es uno nuevo o es la edición de uno existente.
            If lIdMovimiento = 0 Then
                Operacion = "Nuevo"
                Me.ImgbCerrar.Visible = False
            Else
                Operacion = "Edicion"
                Me.TxtIddocumento.Text = lIdMovimiento
                Me.PnlDetalle.Visible = True
                Me.PnlEncabezado.Visible = True

            End If

            'Evalua si el despacho se va elaborar a partir de una requisición.
            If Me.DOCUMENTOENLACE = 0 Then
                CargarDatos()
            Else
                CargarDatosRequisicion()
            End If
        End If
    End Sub

    Private Function CargarDatosRequisicion() As Int16
        If Operacion = "Nuevo" Then

            'Recuperando la información de la requisicion a ser despachada.
            mEntMovimientos.IDESTABLECIMIENTO = Me.EstablecimientoSolicita
            mEntMovimientos.IDTIPOTRANSACCION = 1
            mEntMovimientos.IDMOVIMIENTO = Me.DOCUMENTOENLACE
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            Me.DdlTIPOTRANSACCIONES1.SelectedValue = 2
            Me.txtDocumento.Text = 0
            'Me.CalendarFechaDocumento.SelectedDate = mEntMovimientos.AUFECHACREACION
            'Me.CalendarFechaDespacho.SelectedDate = mEntMovimientos.FECHAMOVIMIENTO
            Me.TxtDocumentoEnlazado.Text = Me.DOCUMENTOENLACE
            Me.TxtNombreAlmacen.Text = Session.Item("NombreAlmacen")
            Me.TxtIdAlmacen.Text = mEntMovimientos.IDALMACEN
            Me.DdlEMPLEADOS1.SelectedValue = mEntMovimientos.IDEMPLEADOSOLICITA
            Me.DdlESTABLECIMIENTOS1.SelectedValue = Me.EstablecimientoSolicita

            'Carga de la información del vale de salida asociado
            'mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
            'mEntVale.IDVALE = mEntMovimientos.IDDOCUMENTO
            'mCompVale.ObtenerVALESSALIDA(mEntVale)
            'Me.TxtObservacion.Text = mEntVale.OBSERVACION

            'Carga del detalle del vale de salida
            'Me.gvLista.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntMovimientos.IDESTABLECIMIENTO, mEntMovimientos.IDTIPOTRANSACCION, mEntMovimientos.IDMOVIMIENTO)
            'Me.gvLista.DataBind()

            'Carga de la información del vale de salida asociado
            'mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
            'mEntVale.IDVALE = mEntMovimientos.IDDOCUMENTO
            'mCompVale.ObtenerVALESSALIDA(mEntVale)
            'Me.TxtObservacion.Text = mEntVale.OBSERVACION

            'Carga del detalle del movimiento en el datagrid
            Me.gvProductosRequisicion.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntMovimientos.IDESTABLECIMIENTO, mEntMovimientos.IDTIPOTRANSACCION, mEntMovimientos.IDMOVIMIENTO)
            Me.gvProductosRequisicion.DataBind()

            Me.TxtIddocumento.Text = 0
            Me.DdlEMPLEADOS1.SelectedValue = Session.Item("IdEmpleado")
            Me.TxtNombreAlmacen.Text = Session.Item("NombreAlmacen")
            Me.TxtIdAlmacen.Text = Session.Item("IdAlmacen")

        End If

    End Function

    Private Function CargarDatos() As Int16
        If Operacion = "Edicion" Then
            'Recuperando la información del movimiento a editar
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = 2
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            Me.DOCUMENTOENLACE = mEntMovimientos.NUMERODOCREF
            Me.TxtDocumentoEnlazado.Text = Me.DOCUMENTOENLACE
            Me.DdlTIPOTRANSACCIONES1.SelectedValue = mEntMovimientos.IDTIPOTRANSACCION
            Me.txtDocumento.Text = mEntMovimientos.IDDOCUMENTO
            Me.TxtNumeroValeReal.Text = Trim(Str(mEntMovimientos.IDDOCUMENTO)) + "/" + Trim(Str(mEntMovimientos.ANIO))
            Me.CalendarFechaDocumento.SelectedDate = mEntMovimientos.AUFECHACREACION
            Me.CalendarFechaDespacho.SelectedDate = mEntMovimientos.FECHAMOVIMIENTO
            Me.TxtNombreAlmacen.Text = Session.Item("NombreAlmacen")
            Me.TxtIdAlmacen.Text = mEntMovimientos.IDALMACEN
            Me.DdlEMPLEADOS1.SelectedValue = mEntMovimientos.IDEMPLEADOSOLICITA
            Me.DdlESTABLECIMIENTOS1.SelectedValue = mEntMovimientos.IDESTABLECIMIENTODESTINO

            'Carga de la información del vale de salida asociado
            mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntVale.ANIO = mEntMovimientos.ANIO
            mEntVale.IDVALE = mEntMovimientos.IDDOCUMENTO
            mCompVale.ObtenerVALESSALIDA(mEntVale)
            Me.TxtObservacion.Text = mEntVale.OBSERVACION
            'Carga del detalle del movimiento en el datagrid
            'Me.gvProductosRequisicion.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntMovimientos.IDESTABLECIMIENTO, mEntMovimientos.IDTIPOTRANSACCION, mEntMovimientos.IDMOVIMIENTO)
            'Me.gvProductosRequisicion.DataBind()

            Me.dgLista.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntMovimientos.IDESTABLECIMIENTO, 2, mEntMovimientos.IDMOVIMIENTO)
            Me.dgLista.DataBind()

            Me.gvProductosRequisicion.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntMovimientos.IDESTABLECIMIENTO, 1, mEntMovimientos.NUMERODOCREF)
            Me.gvProductosRequisicion.DataBind()

            Me.PnlDetalle.Visible = True

        ElseIf Operacion = "Nuevo" Then
            Me.TxtIddocumento.Text = 0
            Me.DdlEMPLEADOS1.SelectedValue = Session.Item("IdEmpleado")
            Me.TxtNombreAlmacen.Text = Session.Item("NombreAlmacen")
            Me.TxtIdAlmacen.Text = Session.Item("IdAlmacen")

            Me.gvProductosRequisicion.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntMovimientos.IDESTABLECIMIENTO, 1, mEntMovimientos.NUMERODOCREF)
            Me.gvProductosRequisicion.DataBind()



        End If

    End Function

    Protected Sub ImgbCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCerrar.Click
        MsgBox1.ShowConfirm("El documento sera enviado a la Dependencia solicitante y ya no lo podra modificar. ¿Esta serguro que desea realizar el despacho?", "Q2", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "Buscar" Then
            Response.Redirect("~/ALMACEN/FrmMantDespacharProductos.aspx")
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "Q1" Then 'Verifica si el usuario desea crear el documento

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = 2 ' Vale de salida
            mEntMovimientos.IDMOVIMIENTO = 0
            Me.TxtIddocumento.Text = mCompMovimientos.ObtenerID(mEntMovimientos)
            Me.txtDocumento.Text = mCompVale.RecuperarID(Me.TxtIdAlmacen.Text)
            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDespacho.SelectedDate 'Fecha en la que se despacho
            mEntMovimientos.ANIO = Me.CalendarFechaDespacho.SelectedDate.Year
            mEntMovimientos.IDALMACEN = Me.TxtIdAlmacen.Text
            'mEntMovimientos.IDUNIDADSOLICITA = Me.DdlDEPENDENCIAS1.SelectedValue
            mEntMovimientos.IDEMPLEADOALMACEN = Me.DdlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.IDTIPODOCREF = 1
            mEntMovimientos.NUMERODOCREF = Me.DOCUMENTOENLACE
            mEntMovimientos.CLASIFICACIONMOVIMIENTO = 10 'Valor fijo que indica que este despacho es del tipo interno para dependencias.
            mEntMovimientos.IDALMACENDESTINO = Me.AlmacenSolicita
            mEntMovimientos.IDESTABLECIMIENTODESTINO = Me.DdlESTABLECIMIENTOS1.SelectedValue
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

            'Creación del vale de salida
            mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntVale.ANIO = mEntMovimientos.ANIO
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

            Me.TxtNumeroValeReal.Text = Trim(Str(mEntMovimientos.IDDOCUMENTO)) + "/" + Trim(Str(mEntMovimientos.ANIO))

            'Actualizar el estado de la requisición enlazada al estado de DESPACHADA VALOR 5
            mEntMovimientos.IDTIPOTRANSACCION = 1
            mEntMovimientos.IDMOVIMIENTO = Me.DOCUMENTOENLACE
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            mEntMovimientos.IDESTADO = 5    'Estado que indica que la requisición se encuentra en proceso de despacho
            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

            lIdMovimiento = Me.TxtIddocumento.Text
            Operacion = "Edicion"

            Me.ImgbCerrar.Visible = True
            Me.PnlDetalle.Visible = True


        End If

        If e.Key = "Q2" Then 'Verifica si el usuario desea cerrar el documento

            'Validando datos requeridos para el proceso de cierre

            'Recuperando la información del documento a ser cerrado
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = 2
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            Me.DOCUMENTOENLACE = mEntMovimientos.NUMERODOCREF
            mEntMovimientos.IDESTADO = 4 'Cambio del estado del documento de grabado a cerrado
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

            'Actualización del vale de salida
            mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntVale.ANIO = mEntMovimientos.ANIO
            mEntVale.IDVALE = mEntMovimientos.IDDOCUMENTO
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

            'Actualizar el estado de la requisición enlazada al estado de DESPACHADA VALOR 5
            mEntMovimientos.IDTIPOTRANSACCION = 1
            mEntMovimientos.IDMOVIMIENTO = Me.DOCUMENTOENLACE
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            mEntMovimientos.IDESTADO = 6 'Indica que la requisición fue despacho por el almacén
            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

            Response.Redirect("~/ALMACEN/FrmMantDespacharProductos.aspx")
        End If

    End Sub

    Protected Sub ImgbGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar.Click
        If Operacion = "Edicion" Then

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = 2
            mEntMovimientos.IDMOVIMIENTO = Me.TxtIddocumento.Text
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDespacho.SelectedDate
            mEntMovimientos.ANIO = Me.CalendarFechaDespacho.SelectedDate.Year
            mEntMovimientos.IDALMACEN = Me.TxtIdAlmacen.Text
            'mEntMovimientos.IDUNIDADSOLICITA = Me.DdlDEPENDENCIAS1.SelectedValue
            mEntMovimientos.IDEMPLEADOSOLICITA = Me.DdlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.IDALMACENDESTINO = Me.TxtIdAlmacen.Text
            mEntMovimientos.IDESTABLECIMIENTODESTINO = Me.DdlESTABLECIMIENTOS1.SelectedValue

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
            mEntVale.ANIO = mEntMovimientos.ANIO
            mEntVale.IDVALE = mEntMovimientos.IDDOCUMENTO
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

            Me.TxtNumeroValeReal.Text = Trim(Str(mEntMovimientos.IDDOCUMENTO)) + "/" + Trim(Str(mEntMovimientos.ANIO))

            'Actualizar el estado de la requisición enlazada al estado de DESPACHADA VALOR 5
            mEntMovimientos.IDTIPOTRANSACCION = 1
            mEntMovimientos.IDMOVIMIENTO = Me.DOCUMENTOENLACE
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            mEntMovimientos.IDESTADO = 5
            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

        Else

            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = 2 ' Vale de salida
            mEntMovimientos.IDMOVIMIENTO = 0
            Me.TxtIddocumento.Text = mCompMovimientos.ObtenerID(mEntMovimientos)
            Me.txtDocumento.Text = mCompVale.RecuperarID(Me.TxtIdAlmacen.Text)
            mEntMovimientos.IDDOCUMENTO = Me.txtDocumento.Text
            mEntMovimientos.FECHAMOVIMIENTO = Me.CalendarFechaDespacho.SelectedDate 'Fecha en la que se despacho
            mEntMovimientos.ANIO = Me.CalendarFechaDespacho.SelectedDate.Year
            mEntMovimientos.IDALMACEN = Me.TxtIdAlmacen.Text
            'mEntMovimientos.IDUNIDADSOLICITA = Me.DdlDEPENDENCIAS1.SelectedValue
            mEntMovimientos.IDEMPLEADOALMACEN = Me.DdlEMPLEADOS1.SelectedValue
            mEntMovimientos.IDESTADO = 1
            mEntMovimientos.IDTIPODOCREF = 1
            mEntMovimientos.NUMERODOCREF = Me.DOCUMENTOENLACE
            mEntMovimientos.CLASIFICACIONMOVIMIENTO = 10 'Valor fijo que indica que este despacho es del tipo interno para dependencias.
            mEntMovimientos.IDALMACENDESTINO = Me.TxtIdAlmacen.Text
            mEntMovimientos.IDESTABLECIMIENTODESTINO = Me.DdlESTABLECIMIENTOS1.SelectedValue
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

            'Creación del vale de salida
            mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
            mEntVale.ANIO = mEntMovimientos.ANIO
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

            'Actualizar el estado de la requisición enlazada al estado de DESPACHADA VALOR 5
            mEntMovimientos.IDTIPOTRANSACCION = 1
            mEntMovimientos.IDMOVIMIENTO = Me.DOCUMENTOENLACE
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)
            mEntMovimientos.IDESTADO = 5    'Estado que indica que la requisición se encuentra en proceso de despacho
            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

            lIdMovimiento = Me.TxtIddocumento.Text
            Operacion = "Edicion"


            Me.ImgbCerrar.Visible = True
            Me.PnlDetalle.Visible = True
        End If
    End Sub

    Public Sub EliminarRenglon(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As New LinkButton
        b = sender

        'Recuperamos el renglon para su eliminacion
        mEntDetalleMovimiento.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntDetalleMovimiento.IDTIPOTRANSACCION = 2
        mEntDetalleMovimiento.IDMOVIMIENTO = Me.TxtIddocumento.Text
        mEntDetalleMovimiento.IDDETALLEMOVIMIENTO = b.CommandName
        mCompDetalleMovimiento.ObtenerDETALLEMOVIMIENTOS(mEntDetalleMovimiento)

        'Actualizacion de existencias
        mCompUtilerias.ActualizarCantidadDisponible(Session.Item("IdAlmacen"), mEntDetalleMovimiento.IDLOTE, 0, mEntDetalleMovimiento.CANTIDAD)

        'Eliminamos la fila
        mCompDetalleMovimiento.EliminarDETALLEMOVIMIENTOS(Session.Item("IdEstablecimiento"), 2, Me.TxtIddocumento.Text, b.CommandName)

        CargarDatos()

    End Sub

    Protected Sub ImgbImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbImprimir.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValeSalidaDependencia.aspx?IdMovimiento=" + Me.TxtIddocumento.Text + "&IdAlmacen=" + Me.TxtIdAlmacen.Text + "&IdAnio=" + Me.CalendarFechaDespacho.SelectedDate.Year.ToString + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub gvProductosRequisicion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProductosRequisicion.RowDataBound
        Try

            If e.Row.RowType = DataControlRowType.DataRow Then
                mEntExistenciasAlmacenes.IDALMACEN = Session.Item("IdAlmacen")
                mEntExistenciasAlmacenes.IDPRODUCTO = Val(e.Row.Cells(0).Text)
                mCompExistenciasAlmacenes.ObtenerEXISTENCIASALMACENES(mEntExistenciasAlmacenes)


                If mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = 0 Then
                    e.Row.Cells(4).Controls(3).Visible = True
                    e.Row.Cells(4).Controls(1).Visible = False
                Else
                    e.Row.Cells(4).Controls(3).Visible = False
                    e.Row.Cells(4).Controls(1).Visible = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvProductosRequisicion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProductosRequisicion.SelectedIndexChanged
        Dim dsLoteBusqueda As Data.DataSet
        Me.DdlLOTES2.RecuperarListaPorProductoFiltrado(Session.Item("IdAlmacen"), Me.gvProductosRequisicion.SelectedRow.Cells(0).Text, 1)
        dsLoteBusqueda = mCompLote.SeleccionarLoteDs(Session.Item("IdAlmacen"), Me.gvProductosRequisicion.SelectedRow.Cells(0).Text, 1)
        If dsLoteBusqueda.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("Este producto no puede ser despachado por carecer de existencias, seleccione otro producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.PnlAgregarProductoDistribucion.Visible = False
        Else
            Me.PnlAgregarProductoDistribucion.Visible = True
            Me.TxtCanDisponibleDistribucion.Text = dsLoteBusqueda.Tables(0).Rows(0).Item("CANTIDADDISPONIBLE")
            Me.TxtFechaVencimientoDistribucion.Text = dsLoteBusqueda.Tables(0).Rows(0).Item("FECHAVENCIMIENTO")
            Me.DdlFUENTEFINANCIAMIENTOS1.SelectedValue = dsLoteBusqueda.Tables(0).Rows(0).Item("IDFUENTEFINANCIAMIENTO")
            Me.DdlRESPONSABLEDISTRIBUCION1.SelectedValue = dsLoteBusqueda.Tables(0).Rows(0).Item("IDRESPONSABLEDISTRIBUCION")
            Me.DdlUNIDADMEDIDAS2.SelectedValue = dsLoteBusqueda.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
            Me.TxtPrecioUnitarioDistribucion.Text = dsLoteBusqueda.Tables(0).Rows(0).Item("PRECIOLOTE")
            Me.TxtCantidadDistribucion.Text = Me.gvProductosRequisicion.SelectedRow.Cells(3).Text

        End If

    End Sub

    Protected Sub BtnCancelarDistribucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelarDistribucion.Click
        Me.PnlAgregarProductoDistribucion.Visible = False
        Me.gvProductosRequisicion.SelectedIndex = -1
    End Sub

    Protected Sub BtnGuardarDistribucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardarDistribucion.Click
        If Me.TxtCantidadDistribucion.Text = "" Or Val(Me.TxtCantidadDistribucion.Text) = 0 Then
            MsgBox1.ShowAlert("Especifique una cantidad valida para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtCantidadDistribucion.Focus()
            Exit Sub
        End If
        If Me.TxtPrecioUnitarioDistribucion.Text = "" Then
            MsgBox1.ShowAlert("El precio debe ser mayor a cero", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtPrecioUnitarioDistribucion.Focus()
            Exit Sub
        End If
        If Val(Me.TxtCantidadDistribucion.Text) > Val(Me.TxtCanDisponibleDistribucion.Text) Then
            MsgBox1.ShowAlert("La cantidad a despachar no puede ser mayor a la cantidad disponible", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtCantidadDistribucion.Focus()
            Exit Sub
        End If

        If Val(Me.TxtCantidadDistribucion.Text) > Val(Me.gvProductosRequisicion.SelectedRow.Cells(3).Text) Then
            MsgBox1.ShowAlert("La cantidad a despachar no puede ser mayor a la cantidad solicitada por la dependecia", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtCantidadDistribucion.Focus()
            Exit Sub
        End If

        'Funcion de verificacion
        mEntDetalleMovimiento.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntDetalleMovimiento.IDTIPOTRANSACCION = 2
        mEntDetalleMovimiento.IDMOVIMIENTO = Me.TxtIddocumento.Text
        mEntDetalleMovimiento.IDDETALLEMOVIMIENTO = 0
        mEntDetalleMovimiento.IDALMACEN = Me.TxtIdAlmacen.Text
        mEntDetalleMovimiento.IDLOTE = Me.DdlLOTES2.SelectedValue
        mEntDetalleMovimiento.IDPRODUCTO = Me.gvProductosRequisicion.SelectedRow.Cells(0).Text
        mEntDetalleMovimiento.CANTIDAD = Me.TxtCantidadDistribucion.Text
        Me.TxtPrecioUnitarioDistribucion.AutoFormatCurrency = False
        mEntDetalleMovimiento.MONTO = Me.TxtPrecioUnitarioDistribucion.Text
        Me.TxtPrecioUnitarioDistribucion.AutoFormatCurrency = True
        If mEntDetalleMovimiento.AUUSUARIOCREACION = Nothing Then
            mEntDetalleMovimiento.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntDetalleMovimiento.AUFECHACREACION = Nothing Then
            mEntDetalleMovimiento.AUFECHACREACION = Now()
        End If
        mEntDetalleMovimiento.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntDetalleMovimiento.AUFECHAMODIFICACION = Now()

        mCompDetalleMovimiento.ActualizarDETALLEMOVIMIENTOS(mEntDetalleMovimiento)

        'Actualización de la cantidad disponible del lote seleccionado
        mCompUtilerias.ActualizarCantidadDisponible(mEntDetalleMovimiento.IDALMACEN, mEntDetalleMovimiento.IDLOTE, 1, mEntDetalleMovimiento.CANTIDAD)

        Me.dgLista.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntDetalleMovimiento.IDESTABLECIMIENTO, mEntDetalleMovimiento.IDTIPOTRANSACCION, mEntDetalleMovimiento.IDMOVIMIENTO)
        Me.dgLista.DataBind()

        Me.PnlAgregarProductoDistribucion.Visible = False

    End Sub

    Protected Sub BtDefinirDetalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtDefinirDetalle.Click
        MsgBox1.ShowConfirm("Para continuar con el detalle del despacho el documento debera ser creado, desea continuar", "Q1", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
    End Sub

    Protected Sub BtVerValeSalida_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtVerValeSalida.Click
        Me.PnlDetalleValeSalida.Visible = True
    End Sub

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Response.Redirect("~/ALMACEN/FrmMantDespachoDependencias.aspx")
    End Sub

    Protected Sub DdlLOTES2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlLOTES2.SelectedIndexChanged
        mEntLote.IDALMACEN = Session.Item("IdAlmacen")
        mEntLote.IDLOTE = Me.DdlLOTES2.SelectedValue
        mCompLote.ObtenerLOTES(mEntLote)

        Me.TxtCanDisponibleDistribucion.Text = mEntLote.CANTIDADDISPONIBLE  'dsLoteBusqueda.Tables(0).Rows(0).Item("CANTIDADDISPONIBLE")
        Me.TxtFechaVencimientoDistribucion.Text = mEntLote.FECHAVENCIMIENTO 'dsLoteBusqueda.Tables(0).Rows(0).Item("FECHAVENCIMIENTO")
        Me.DdlFUENTEFINANCIAMIENTOS1.SelectedValue = mEntLote.IDFUENTEFINANCIAMIENTO 'dsLoteBusqueda.Tables(0).Rows(0).Item("IDFUENTEFINANCIAMIENTO")
        Me.DdlRESPONSABLEDISTRIBUCION1.SelectedValue = mEntLote.IDRESPONSABLEDISTRIBUCION 'dsLoteBusqueda.Tables(0).Rows(0).Item("IDRESPONSABLEDISTRIBUCION")
        Me.DdlUNIDADMEDIDAS2.SelectedValue = mEntLote.IDUNIDADMEDIDA 'dsLoteBusqueda.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
        Me.TxtPrecioUnitarioDistribucion.Text = mEntLote.PRECIOLOTE 'dsLoteBusqueda.Tables(0).Rows(0).Item("PRECIOLOTE")

    End Sub
End Class