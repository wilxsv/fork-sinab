Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class FrmGeneraActaRecepcion
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
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False

        If Not Page.IsPostBack Then
            lIdMovimiento = Request.QueryString("IdMov")
            lIdTipoTran = 8
            Operacion = Request.QueryString("Oper")

            If lIdMovimiento = 0 Then
                Me.DdlPROVEEDORES1.Recuperar()
                Me.DdlPROVEEDORES1.Enabled = False
                Me.DdlEMPLEADOSALMACEN1.RecuperarListaGuardaalmacen(Session.Item("IdAlmacen"))
            Else
                CargarDocumentoEdicion()
            End If

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

        'Carga de modificativas para el contrato seleccionado
        Dim dsListaModificativas As Data.DataSet

        dsListaModificativas = mCompModificativas.ObtenerDataSetPorId(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        If dsListaModificativas.Tables(0).Rows.Count > 0 Then
            Me.DgListaModificativas.DataSource = dsListaModificativas
            Me.DgListaModificativas.DataBind()
            Me.PnlModificativas.Visible = True
        Else
            Me.PnlModificativas.Visible = False
        End If

        mEntContratos.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        mEntContratos.IDPROVEEDOR = IDPROVEEDOR
        mEntContratos.IDCONTRATO = IDCONTRATO
        mCompContratos.ObtenerCONTRATOS(mEntContratos)

        Me.LblNoActa.Text = mEntRecibo.NUMEROACTA
        Me.txtDocumento.Text = mEntRecibo.IDRECIBO
        Me.TxtIdAlmacen.Text = mEntMovimientos.IDALMACEN
        Me.TxtNombreAlmacen.Text = Session.Item("NombreAlmacen")
        Me.CalendarFechaDespacho.SelectedDate = mEntMovimientos.FECHAMOVIMIENTO
        Me.tmHora.SelectedTime = mEntMovimientos.FECHAMOVIMIENTO
        Me.TxtTipoDocumentoRespalda.Text = "Contrato"
        Me.TxtNumeroDocumentoRespalda.Text = mEntContratos.NUMEROCONTRATO
        Me.TxtNumeroModalidadCompra.Text = mEntContratos.NUMEROMODALIDADCOMPRA
        Me.DdlFUENTEFINANCIAMIENTOSCONTRATOS1.RecuperarListaPorContrato(Session.Item("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR)
        Me.DdlRESPONSABLEDISTRIBUCIONCONTRATO1.RecuperarListaPorContrato(Session.Item("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO)
        Me.DdlPROVEEDORES1.Recuperar()
        Me.DdlPROVEEDORES1.SelectedValue = mEntRecibo.IDPROVEEDOR

        Me.DdlEMPLEADOSALMACEN1.RecuperarListaGuardaalmacen(Session.Item("IdAlmacen"))
        Me.DdlEMPLEADOSALMACEN1.SelectedValue = mEntMovimientos.IDEMPLEADOALMACEN

        Me.TxtObservaciones.Text = mEntRecibo.OBSERVACION
        Me.TxtEnviadoProveedor.Text = mEntRecibo.RESPONSABLEPROVEEDOR

        CargarDetalleRecepcion()

    End Function

    Private Function CargarDetalleRecepcion() As Integer
        'Me.gvLista.DataSource = mCompMovimientos.ObtenerReciboRecepcionDS2(Me.TxtIddocumento.Text, Session.Item("IdAlmacen"), Me.CalendarFechaDespacho.SelectedDate.Year)
        'Me.gvLista.DataBind()
    End Function

    Protected Sub ImgbImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbImprimir.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'>window.open('" + Request.ApplicationPath + "/Reportes/FrmRptActaRecepcion.aspx?IdMov=" + Me.TxtIddocumento.Text + "&IdAnio=" + Me.CalendarFechaDespacho.SelectedDate.Year.ToString + "&Establecimiento=" + Me.IDESTABLECIMIENTO.ToString + "&Proveedor=" + Me.IDPROVEEDOR.ToString + "&Contrato=" + Me.IDCONTRATO.ToString + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); </script>")
    End Sub

    Protected Sub ImgbGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar.Click
        'Asignamos toda la información a la entidad para invocar el método recuperación
        'registro existente
        mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntMovimientos.IDTIPOTRANSACCION = lIdTipoTran
        mEntMovimientos.IDMOVIMIENTO = lIdMovimiento

        'Invocamos el método de recuperación del registro.
        mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

        'Actualizamos la nueva información en la entidad de datos.
        mEntMovimientos.AUUSUARIOMODIFICACION = User.Identity.Name
        mEntMovimientos.AUFECHAMODIFICACION = Now()
        mEntMovimientos.ESTASINCRONIZADA = 0

        'Invocamos el metodo de actualización del movimiento.
        mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos)

        'Asignamos la información necesaria para poder obtener la información del recibo de recepción.
        mEntRecibo.IDALMACEN = mEntMovimientos.IDALMACEN
        mEntRecibo.ANIO = mEntMovimientos.ANIO
        mEntRecibo.IDRECIBO = mEntMovimientos.IDDOCUMENTO

        'Invocamos el método de recuperación del registro existente.
        mCompRecibo.ObtenerRECIBOSRECEPCION(mEntRecibo)

        'Actualizamos la nueva información a la entidad de datos.
        mEntRecibo.RESPONSABLEPROVEEDOR = Me.TxtEnviadoProveedor.Text
        mEntRecibo.AUUSUARIOMODIFICACION = User.Identity.Name
        mEntRecibo.AUFECHAMODIFICACION = Now()
        mEntRecibo.ESTASINCRONIZADA = 0

        'Invocamos el método de actualización de datos.
        mCompRecibo.ActualizarRECIBOSRECEPCION(mEntRecibo)
    End Sub

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Select Case Operacion
            Case Is = "1"
                Response.Redirect("~/ALMACEN/FrmMantRecibirProductos.aspx")
            Case Else
                Response.Redirect("~/ALMACEN/FrmImprimirActaRecepcion.aspx")
        End Select
    End Sub

End Class
