Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports eWorld.UI
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils


Partial Class FrmDetMantRecibirProductosValeSalida
    Inherits System.Web.UI.Page

    Private cM As New cMOVIMIENTOS
    Private eM As New MOVIMIENTOS
    Private cDM As New cDETALLEMOVIMIENTOS
    Private eDM As New DETALLEMOVIMIENTOS

    Private cL As New cLOTES
    Private eL As New LOTES
    Private cRR As New cRECIBOSRECEPCION
    Private eRR As New RECIBOSRECEPCION

    Private cU As New cUTILERIAS

    Private _IDDOCUMENTO As Integer
    Private _IDMOVIMIENTO As Integer

#Region "Propiedades"

    Public Property IDDOCUMENTO() As Decimal
        Get
            Return _IDDOCUMENTO
        End Get
        Set(ByVal value As Decimal)
            _IDDOCUMENTO = value
            If Not Me.ViewState("IDDOCUMENTO") Is Nothing Then Me.ViewState.Remove("IDDOCUMENTO")
            Me.ViewState.Add("IDDOCUMENTO", value)
        End Set
    End Property

    Public Property IDMOVIMIENTO() As Integer
        Get
            Return _IDMOVIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDMOVIMIENTO = value
            If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me.ViewState.Remove("IDMOVIMIENTO")
            Me.ViewState.Add("IDMOVIMIENTO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.cvFechaRecepcion.ValueToCompare = Now.Date

            CargarVales()
        End If

    End Sub

    Private Sub CargarVales()

        Dim ds As Data.DataSet
        ds = cM.ObtenerValesPendientesAlmacen(Session.Item("IdAlmacen"), 0)

        Me.gvVales.DataSource = ds
        Me.gvVales.DataBind()

    End Sub

    Protected Sub gvVales_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvVales.SelectedIndexChanging

        'Procedimiento de carga del vale de salida
        Dim IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO As Integer
        IDESTABLECIMIENTO = Me.gvVales.DataKeys(e.NewSelectedIndex).Values.Item("IDESTABLECIMIENTO")
        IDTIPOTRANSACCION = Me.gvVales.DataKeys(e.NewSelectedIndex).Values.Item("IDTIPOTRANSACCION")
        IDMOVIMIENTO = Me.gvVales.DataKeys(e.NewSelectedIndex).Values.Item("IDMOVIMIENTO")

        'Cargar el detalle de la recepción.
        Me.gvLista.DataSource = cDM.ObtenerDetalleMovimientoSalida(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
        Me.gvLista.DataBind()

        If gvLista.Rows.Count > 0 Then Me.btnGuardar.Enabled = True

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Try
            Dim cRR As New cRECIBOSRECEPCION
            Dim cM As New cMOVIMIENTOS
            Dim cDM As New cDETALLEMOVIMIENTOS
            Dim cL As New cLOTES
            Dim cU As New cUBICACIONESPRODUCTOS
            Dim cAEC As New cALMACENESENTREGACONTRATOS

            'RECIBO
            Dim eRR As New RECIBOSRECEPCION
            eRR.IDALMACEN = Session.Item("IdAlmacen")
            eRR.ANIO = Me.cpFechaRecepcion.SelectedDate.Year
            eRR.IDRECIBO = 0
            eRR.IDESTABLECIMIENTO = Nothing
            eRR.IDPROVEEDOR = Nothing
            eRR.IDCONTRATO = Nothing
            eRR.RESPONSABLEPROVEEDOR = Me.txtTransportista.Text
            eRR.NUMEROACTA = 0
            eRR.OBSERVACION = Me.txtObservaciones.Text
            eRR.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eRR.AUFECHACREACION = Now()
            eRR.AUUSUARIOMODIFICACION = Nothing
            eRR.AUFECHAMODIFICACION = Nothing
            eRR.ESTASINCRONIZADA = 0

            eRR.IDALMACENVALE = Me.gvVales.DataKeys(gvVales.SelectedIndex).Values.Item("IDALMACEN")
            eRR.ANIOVALE = Me.gvVales.DataKeys(gvVales.SelectedIndex).Values.Item("ANIO")
            eRR.IDVALE = Me.gvVales.DataKeys(gvVales.SelectedIndex).Values.Item("IDVALE")

            cRR.ActualizarRECIBOSRECEPCION(eRR)

            Me.IDDOCUMENTO = eRR.IDRECIBO

            'MOVIMIENTO
            Dim eM As New MOVIMIENTOS

            eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            eM.IDTIPOTRANSACCION = EnumHelpers.TiposTransaccion.RecepcionProductos
            eM.IDMOVIMIENTO = 0

            eM.IDTIPODOCREF = Nothing
            eM.NUMERODOCREF = Nothing

            eM.IDALMACEN = eRR.IDALMACEN
            eM.ANIO = eRR.ANIO
            eM.IDDOCUMENTO = eRR.IDRECIBO

            eM.IDESTADO = eESTADOSMOVIMIENTOS.Grabado

            eM.FECHAMOVIMIENTO = Me.cpFechaRecepcion.SelectedDate
            eM.IDESTABLECIMIENTODESTINO = Nothing

            eM.IDALMACENDESTINO = Nothing
            eM.IDUNIDADSOLICITA = Session.Item("IdDependencia")
            eM.TOTALMOVIMIENTO = 0

            eM.IDEMPLEADOSOLICITA = Nothing

            eM.IDEMPLEADOALMACEN = Nothing
            eM.EMPLEADOALMACEN = Me.txtGuardalmacen.Text

            eM.CLASIFICACIONMOVIMIENTO = 1
            eM.SUBCLASIFICACIONMOVIMIENTO = 1

            eM.RESPONSABLEDISTRIBUCION = Nothing

            eM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eM.AUFECHACREACION = Now()
            eM.AUUSUARIOMODIFICACION = Nothing
            eM.AUFECHAMODIFICACION = Nothing
            eM.ESTASINCRONIZADA = 0

            cM.ActualizarMOVIMIENTOS(eM)

            Me.IDMOVIMIENTO = eM.IDMOVIMIENTO

            For Each row As GridViewRow In gvLista.Rows

                Dim eL As New LOTES
                Dim eDM As New DETALLEMOVIMIENTOS
                Dim eU As New UBICACIONESPRODUCTOS

                'LOTES
                eL.IDALMACEN = eM.IDALMACEN
                eL.IDLOTE = IIf(Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDLOTEVALE") Is DBNull.Value, 0, Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDLOTEVALE"))

                eL.IDPRODUCTO = Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDPRODUCTO")
                eL.IDUNIDADMEDIDA = Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDUNIDADMEDIDA")
                eL.CODIGO = Server.HtmlDecode(row.Cells.Item(0).Text)
                eL.DETALLE = Nothing
                eL.PRECIOLOTE = Server.HtmlDecode(row.Cells.Item(4).Text)
                eL.FECHAVENCIMIENTO = Me.gvLista.DataKeys(row.RowIndex).Values.Item("FECHAVENCIMIENTO")
                eL.IDFUENTEFINANCIAMIENTO = Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDFUENTEFINANCIAMIENTO")
                eL.IDRESPONSABLEDISTRIBUCION = Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDRESPONSABLEDISTRIBUCION")

                eL.IDESTABLECIMIENTO = IIf(Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDESTABLECIMIENTOCONTROLCALIDAD") Is DBNull.Value, Nothing, Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDESTABLECIMIENTOCONTROLCALIDAD"))
                eL.IDINFORMECONTROLCALIDAD = IIf(Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDINFORMECONTROLCALIDAD") Is DBNull.Value, Nothing, Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDINFORMECONTROLCALIDAD"))
                eL.NUMEROINFORMECONTROLCALIDAD = IIf(Me.gvLista.DataKeys(row.RowIndex).Values.Item("NUMEROINFORMECONTROLCALIDAD") Is DBNull.Value, Nothing, Me.gvLista.DataKeys(row.RowIndex).Values.Item("NUMEROINFORMECONTROLCALIDAD"))
                eL.FECHAINFORMECONTROLCALIDAD = IIf(Me.gvLista.DataKeys(row.RowIndex).Values.Item("FECHAINFORMECONTROLCALIDAD") Is DBNull.Value, Nothing, Me.gvLista.DataKeys(row.RowIndex).Values.Item("FECHAINFORMECONTROLCALIDAD"))

                eL.CANTIDADDISPONIBLE = CType(row.FindControl("nbCantidad"), eWorld.UI.NumericBox).Text
                eL.ESTADISPONIBLE = 0

                eL.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                eL.AUFECHACREACION = Now()
                eL.AUUSUARIOMODIFICACION = Nothing
                eL.AUFECHAMODIFICACION = Nothing
                eL.ESTASINCRONIZADA = 0

                cL.ActualizarLOTES(eL)

                'DETALLEMOVIMIENTOS
                eDM.IDESTABLECIMIENTO = eM.IDESTABLECIMIENTO
                eDM.IDTIPOTRANSACCION = eM.IDTIPOTRANSACCION
                eDM.IDMOVIMIENTO = eM.IDMOVIMIENTO
                eDM.IDDETALLEMOVIMIENTO = IIf(Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDDETALLEMOVIMIENTOVALE") Is DBNull.Value, 0, Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDDETALLEMOVIMIENTOVALE"))

                eDM.IDALMACEN = eM.IDALMACEN
                eDM.IDLOTE = eL.IDLOTE
                eDM.IDPRODUCTO = eL.IDPRODUCTO
                eDM.RENGLON = Nothing
                eDM.CANTIDAD = eL.CANTIDADDISPONIBLE

                eDM.IDTIPODOCUMENTO = Nothing
                eDM.NUMEROFACTURA = Nothing
                eDM.FECHAFACTURA = Nothing

                eDM.MONTO = 0

                eDM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                eDM.AUFECHACREACION = Now()
                eDM.AUUSUARIOMODIFICACION = Nothing
                eDM.AUFECHAMODIFICACION = Nothing
                eDM.ESTASINCRONIZADA = 0

                cDM.ActualizarDETALLEMOVIMIENTOS(eDM)

                'UBICACIONESPRODUCTOS
                eU.IDALMACEN = eM.IDALMACEN
                eU.IDPRODUCTO = eDM.IDPRODUCTO
                eU.IDUBICACION = IIf(Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDUBICACION") Is DBNull.Value, 0, Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDUBICACION"))
                eU.UBICACION = String.Empty
                eU.IDLOTE = eL.IDLOTE
                eU.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                eU.AUFECHACREACION = Now()
                eU.AUUSUARIOMODIFICACION = Nothing
                eU.AUFECHAMODIFICACION = Nothing
                eU.ESTASINCRONIZADA = 0

                cU.ActualizarUBICACIONESPRODUCTOS(eU)

                'TODO: agregar insert en detalle almacen entrega contrato

            Next

            Me.btnGuardar.Enabled = False
            Me.btnCerrar.Enabled = True
            Me.btnImprimir.Enabled = True

            MessageBox.Alert("La recepción de los productos se ha guardado satisfactoriamente. Puede imprimir el recibo de recepción.", "Recibo Guardado")
            ' Me.MsgBox1.ShowAlert("La recepción de los productos se ha guardado satisfactoriamente. Puede imprimir el recibo de recepción.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)

        Catch ex As Exception
            MessageBox.Alert("Error:" & ex.Message, "Error")
            ' Me.MsgBox1.ShowAlert("Error:" & ex.Message, "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        End Try

    End Sub

End Class
