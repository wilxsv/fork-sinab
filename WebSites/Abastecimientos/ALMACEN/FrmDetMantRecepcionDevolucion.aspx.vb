Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.EnumHelpers
Imports SINAB_Utils
'Imports System.Activities.Statements
Imports SINAB_Utils.MessageBox

Partial Class FrmDetMantRecepcionDevolucion
    Inherits System.Web.UI.Page

    Private _IDPRODUCTO As Integer
    Private _IDALMACEN As Integer
    Private _ANIO As Integer
    Private _IDRECIBO As Integer
    Private _IDMOVIMIENTO As Integer

#Region "Propiedades"

    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _IDPRODUCTO = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property

    Public Property IDALMACEN() As Integer
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Integer)
            _IDALMACEN = value
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.ViewState.Remove("IDALMACEN")
            Me.ViewState.Add("IDALMACEN", value)
        End Set
    End Property

    Public Property ANIO() As Integer
        Get
            Return _ANIO
        End Get
        Set(ByVal value As Integer)
            _ANIO = value
            If Not Me.ViewState("ANIO") Is Nothing Then Me.ViewState.Remove("ANIO")
            Me.ViewState.Add("ANIO", value)
        End Set
    End Property

    Public Property IDRECIBO() As Integer
        Get
            Return _IDRECIBO
        End Get
        Set(ByVal value As Integer)
            _IDRECIBO = value
            If Not Me.ViewState("IDRECIBO") Is Nothing Then Me.ViewState.Remove("IDRECIBO")
            Me.ViewState.Add("IDRECIBO", value)
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
            Dim cad = String.Format("/Reportes/FrmRptReciboRecepcion.aspx?IdEMov={0}&IdTT={1}&IdMov={2}", Session.Item("IdEstablecimiento"), TiposTransaccion.RecepcionPorDevolucion.ToString("d"), Me.IDMOVIMIENTO)
            Me.btnImprimir.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptReciboRecepcion.aspx?IdEMov=" + Session.Item("IdEstablecimiento").ToString + "&IdTT=" + TiposTransaccion.RecepcionPorDevolucion.ToString("d") + "&IdMov=" + Me.IDMOVIMIENTO.ToString + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); return;"
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.IDALMACEN = Request.QueryString("IdA")
            Me.IDMOVIMIENTO = Request.QueryString("IdM")

            Me.cpFechaRecepcion.UpperBoundDate = Now.Date
            Me.cvFechaRecepcion.ValueToCompare = Now.Date
            DeshabilitarDobleClickBotones()

            'If Session.Item("IdTipoEstablecimiento") = 3 Or Session.Item("IdTipoEstablecimiento") = 8 Then
            '    Me.ddlALMACENES1.RecuperarListaOrdenada2()
            'Else
            '    Me.ddlALMACENES1.RecuperarListaOrdenada()
            'End If


            Me.ddlESTABLECIMIENTOS1.RecuperarEstablecimientosPorZonaAlmancen(Me.IDALMACEN, IIf(Me.cbVerTodos.Checked, 1, 0))

            Me.ddlSUMINISTROS1.RecuperarOrdenadaPorCorrelativo()
            Me.ddlSUMINISTROS1.SelectedValue = Session.Item("IdSuministro")

            Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.RadioButtonList1.SelectedValue)
            Me.ddlRESPONSABLEDISTRIBUCION1.Recuperar()

            Me.ddlUNIDADMEDIDAS1.Recuperar()

            If Me.IDMOVIMIENTO = 0 Then

                Me.btnCerrar.Enabled = False

                If Session.Item("GuardaAlmacen") = 1 Then
                    Me.txtGuardalmacen.Text = Session.Item("NombreUsuario").ToString
                Else
                    Dim cE As New cEMPLEADOSALMACEN
                    Me.txtGuardalmacen.Text = cE.ObtenerGuardalmacen(Me.IDALMACEN)
                End If

                Me.cpFechaRecepcion.Focus()

            Else

                CargarDatos()

                Me.btnCerrar.Enabled = True
                Me.btnImprimir.Enabled = True

                If Me.txtProducto.Visible Then Me.txtProducto.Focus()

            End If

        Else


            '    If ConfirmTarget = "Nuevo" Then
            '        Response.Redirect("~/ALMACEN/Partial Class FrmDetMantRecepcionDevolucion.aspx?IdM=0" + "&IdA=" + Me.IDALMACEN.ToString, False)
            '    ElseIf ConfirmTarget = "Cerrar" Then
            '        Cerrar()
            '    End If


            '    If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.IDALMACEN = Me.ViewState("IDALMACEN")
            '    If Not Me.ViewState("ANIO") Is Nothing Then Me.ANIO = Me.ViewState("ANIO")
            '    If Not Me.ViewState("IDRECIBO") Is Nothing Then Me.IDRECIBO = Me.ViewState("IDRECIBO")
            '    If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            '    If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me.IDMOVIMIENTO = Me.ViewState("IDMOVIMIENTO")
            'End If



            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.IDALMACEN = Me.ViewState("IDALMACEN")
            If Not Me.ViewState("ANIO") Is Nothing Then Me.ANIO = Me.ViewState("ANIO")
            If Not Me.ViewState("IDRECIBO") Is Nothing Then Me.IDRECIBO = Me.ViewState("IDRECIBO")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me.IDMOVIMIENTO = Me.ViewState("IDMOVIMIENTO")

            If MessageBox.ConfirmTarget = "Nuevo" Then
                Response.Redirect("~/ALMACEN/FrmDetMantRecepcionDevolucion.aspx?IdM=0" + "&IdA=" + Me.IDALMACEN.ToString, False)
            End If

            If MessageBox.ConfirmTarget = "Cerrar Documento" Then
                Cerrar()
            End If
        End If

        End Sub

    Private Sub CargarDatos()

        Dim eM As New MOVIMIENTOS
        Dim cM As New cMOVIMIENTOS

        Dim cDM As New cDETALLEMOVIMIENTOS

        eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eM.IDTIPOTRANSACCION = TiposTransaccion.RecepcionPorDevolucion
        eM.IDMOVIMIENTO = Me.IDMOVIMIENTO

        cM.ObtenerMOVIMIENTOS(eM)

        Dim ds As Data.DataSet
        ds = cDM.ObtenerSuministrosMovimiento(eM.IDESTABLECIMIENTO, eM.IDTIPOTRANSACCION, eM.IDMOVIMIENTO)

        If ds Is Nothing Or ds.Tables(0).Rows.Count = 0 Then
            Me.ddlSUMINISTROS1.SelectedValue = Session.Item("IdSuministro")
        Else
            Me.ddlSUMINISTROS1.SelectedValue = ds.Tables(0).Rows(0).Item("IDSUMINISTRO")
            Me.ddlSUMINISTROS1.Enabled = False
        End If

        Me.cpFechaRecepcion.SelectedDate = eM.FECHAMOVIMIENTO
        Me.txtGuardalmacen.Text = eM.EMPLEADOALMACEN

        Me.ANIO = eM.ANIO
        Me.IDRECIBO = eM.IDDOCUMENTO

        Dim cRR As New cRECIBOSRECEPCION
        Dim eRR As New RECIBOSRECEPCION

        eRR.IDALMACEN = Me.IDALMACEN
        eRR.ANIO = Me.ANIO
        eRR.IDRECIBO = Me.IDRECIBO

        cRR.ObtenerRECIBOSRECEPCION(eRR)

        Me.txtNroRecibo.Text = eRR.IDRECIBO.ToString + "/" + eRR.ANIO.ToString
        Me.lblNroRecibo.Visible = True
        Me.txtNroRecibo.Visible = True

        If Me.ddlESTABLECIMIENTOS1.Items.FindByValue(eRR.IDESTABLECIMIENTODEVOLUCION) Is Nothing Then
            Me.cbVerTodos.Checked = True
            Me.ddlESTABLECIMIENTOS1.RecuperarEstablecimientosPorZonaAlmancen(Me.IDALMACEN, IIf(Me.cbVerTodos.Checked, 1, 0))
        End If

        Me.ddlESTABLECIMIENTOS1.SelectedValue = eRR.IDESTABLECIMIENTODEVOLUCION

        Me.txtVale.Text = eRR.NUMEROVALE

        Me.txtDelegadoProveedor.Text = eRR.RESPONSABLEPROVEEDOR
        Me.txtObservaciones.Text = eRR.OBSERVACION

        CargarDetalleRecepcion()

        If eM.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado Then

            Me.btnGuardar.Visible = False
            Me.btnCerrar.Visible = False
            Me.btnImprimir.Text = "Ver Acta"

            Me.plBusquedaSeleccion.Visible = False
            Me.plDetalle.Visible = False

        End If

        Me.btnImprimir.Enabled = True

    End Sub

    Private Sub CargarDetalleRecepcion()

        Dim cRR As New cRECIBOSRECEPCION

        Dim ds As Data.DataSet
        ds = cRR.RecuperarDetalleRecepcion(Me.IDALMACEN, Me.ANIO, Me.IDRECIBO, TiposTransaccion.RecepcionPorDevolucion)

        Me.gvLista.DataSource = ds
        Me.gvLista.DataBind()

        If Me.gvLista.Rows.Count = 0 Then
            Me.ddlSUMINISTROS1.Enabled = True
        End If

    End Sub

    Protected Sub cbLoteNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbLoteNA.CheckedChanged
        Me.txtLote.Enabled = Not Me.cbLoteNA.Checked
        Me.txtLote.Text = String.Empty
        Me.rfvLote.Visible = Not Me.cbLoteNA.Checked
    End Sub

    Protected Sub cbFechaVtoNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFechaVtoNA.CheckedChanged
        Me.txtFechaVto.Enabled = Not Me.cbFechaVtoNA.Checked
        Me.rfvFechaVto.Visible = Not Me.cbFechaVtoNA.Checked
    End Sub

    Protected Sub btnAgregarLote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarLote.Click

        If Me.lblDescripcionCompleta.Text = "" Then
            'MsgBox1.ShowAlert("La operación no puede ser realizada por que no se ha especificado ningun producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Alert("La operación no puede ser realizada por que no se ha especificado ningun producto", "PRODUCTO OBLIGATORIO")
            Me.txtProducto.Focus()
            Exit Sub
        End If

        Dim FechaVto As Date

        If Not Me.cbFechaVtoNA.Checked Then

            If Me.txtFechaVto.Text.Trim = String.Empty Then
                Alert("Debe ingresar la fecha de vencimiento", "Fecha Obligatoria")
                'Me.MsgBox1.ShowAlert("Debe ingresar la fecha de vencimiento", "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                Return
            End If

            FechaVto = New Date(Year(Me.txtFechaVto.Text), Month(Me.txtFechaVto.Text), 1)
            FechaVto = DateAdd(DateInterval.Month, 1, FechaVto)
            FechaVto = DateAdd(DateInterval.Day, -1, FechaVto)

            If FechaVto < Now.Date Then
                Alert("La fecha de vencimiento debe ser mayor a la fecha actual", "Fecha Erronea")
                ' Me.MsgBox1.ShowAlert("La fecha de vencimiento debe ser mayor a la fecha actual", "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                Return
            End If
        End If

        Dim continuar As Integer = 0

        If Me.IDMOVIMIENTO = 0 Then
            If GuardarMovimiento() = 1 Then
                continuar = 1
            End If
        Else
            continuar = 2
        End If

        If continuar > 0 Then

            Dim encontrado As Boolean = False

            For Each item As DataKey In gvLista.DataKeys
                If item("LOTE") = Me.txtLote.Text And _
                item("IDFUENTEFINANCIAMIENTO") = Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue Then
                    encontrado = True
                    Exit For
                End If
            Next

            If encontrado Then
                Alert("Lote " + Me.txtLote.Text + " ya ingresado.", "Lote ya ingresado")
                'Me.MsgBox1.ShowAlert("Lote " + Me.txtLote.Text + " ya ingresado.", "w", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                Limpiar()
                Exit Sub
            End If

            Dim eL As New LOTES
            Dim cL As New cLOTES
            Dim eUP As New UBICACIONESPRODUCTOS
            Dim cUP As New cUBICACIONESPRODUCTOS
            Dim eDM As New DETALLEMOVIMIENTOS
            Dim cDM As New cDETALLEMOVIMIENTOS

            eL.IDALMACEN = Me.IDALMACEN
            eL.IDLOTE = 0

            'LOTES
            eL.IDPRODUCTO = Me.IDPRODUCTO
            eL.IDUNIDADMEDIDA = Me.ddlUNIDADMEDIDAS1.SelectedValue
            eL.CODIGO = IIf(Me.cbLoteNA.Checked, String.Empty, Me.txtLote.Text)
            eL.DETALLE = Me.txtDETALLE.Text
            eL.PRECIOLOTE = Me.nbPrecioUnitario.Text
            eL.FECHAVENCIMIENTO = IIf(Me.cbFechaVtoNA.Checked, Nothing, FechaVto)
            eL.IDRESPONSABLEDISTRIBUCION = Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue
            eL.IDFUENTEFINANCIAMIENTO = Me.ddlFUENTEFINANCIAMIENTOS1.Text
            eL.CANTIDADDISPONIBLE = CDec(Me.nbCantidad.Text)
            eL.ESTADISPONIBLE = 0
            eL.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eL.AUFECHACREACION = Now

            cL.ActualizarLOTES(eL)

            'DETALLEMOVIMIENTOS
            eDM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            eDM.IDTIPOTRANSACCION = TiposTransaccion.RecepcionPorDevolucion
            eDM.IDMOVIMIENTO = Me.IDMOVIMIENTO
            eDM.IDDETALLEMOVIMIENTO = 0

            eDM.IDALMACEN = eL.IDALMACEN
            eDM.IDLOTE = eL.IDLOTE
            eDM.IDPRODUCTO = eL.IDPRODUCTO
            eDM.CANTIDAD = eL.CANTIDADDISPONIBLE
            eDM.MONTO = 0

            eDM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eDM.AUFECHACREACION = Now

            cDM.ActualizarDETALLEMOVIMIENTOS(eDM)

            'UBICACIONESPRODUCTOS
            eUP.IDALMACEN = eL.IDALMACEN
            eUP.IDPRODUCTO = eL.IDPRODUCTO
            eUP.IDUBICACION = 0
            eUP.UBICACION = Me.txtUbicacion.Text
            eUP.IDLOTE = eL.IDLOTE
            eUP.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eUP.AUFECHACREACION = Now()

            cUP.ActualizarUBICACIONESPRODUCTOS(eUP)

            CargarDetalleRecepcion()

            If continuar = 1 Then Alert("Se ha generado el recibo " + Me.txtNroRecibo.Text + " satisfactoriamente.  Puede continuar ingresando productos.", "Recibo Generado")
            'If continuar = 1 Then Me.MsgBox1.ShowAlert("Se ha generado el recibo " + Me.txtNroRecibo.Text + " satisfactoriamente.  Puede continuar ingresando productos.", "i", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)

        End If

        Limpiar()

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar(Me.txtProducto.Text, 2)
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If GuardarMovimiento() = 1 Then

            CargarDatos()

            MessageBox.Confirm("El recibo " + Me.txtNroRecibo.Text + " se ha guardado satisfactoriamente. ¿Desea crear uno nuevo?", "Crear Nuevo", OptionPostBack.YesPostBack)
            'Me.MsgBox1.ShowConfirm("El recibo " + Me.txtNroRecibo.Text + " se ha guardado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.No)

        End If
    End Sub

    Private Function GuardarMovimiento() As Integer

        Dim resultado As Integer

        Try

            Dim eRR As New RECIBOSRECEPCION
            Dim cRR As New cRECIBOSRECEPCION
            Dim eM As New MOVIMIENTOS
            Dim cM As New cMOVIMIENTOS
            Dim cDM As New cDETALLEMOVIMIENTOS
            Dim cL As New cLOTES
            Dim cU As New cUBICACIONESPRODUCTOS
            Dim cAEC As New cALMACENESENTREGACONTRATOS

            If Me.IDMOVIMIENTO = 0 Then

                'RECIBOSRECEPCION
                eRR.IDALMACEN = Me.IDALMACEN
                eRR.ANIO = Me.cpFechaRecepcion.SelectedDate.Year
                eRR.IDRECIBO = Me.IDRECIBO
                eRR.RESPONSABLEPROVEEDOR = Me.txtDelegadoProveedor.Text
                eRR.NUMEROACTA = 0
                eRR.OBSERVACION = Me.txtObservaciones.Text
                eRR.IDESTABLECIMIENTODEVOLUCION = Me.ddlESTABLECIMIENTOS1.SelectedValue
                eRR.NUMEROVALE = Me.txtVale.Text
                eRR.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                eRR.AUFECHACREACION = Now()

                cRR.ActualizarRECIBOSRECEPCION(eRR)

                Me.ANIO = eRR.ANIO
                Me.ddlSUMINISTROS1.Enabled = False
                Me.IDRECIBO = eRR.IDRECIBO

                Me.txtNroRecibo.Text = eRR.IDRECIBO.ToString + "/" + eRR.ANIO.ToString
                Me.lblNroRecibo.Visible = True
                Me.txtNroRecibo.Visible = True

                'MOVIMIENTOS
                eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                eM.IDTIPOTRANSACCION = TiposTransaccion.RecepcionPorDevolucion
                eM.IDMOVIMIENTO = Me.IDMOVIMIENTO

                eM.IDALMACEN = eRR.IDALMACEN
                eM.ANIO = eRR.ANIO
                eM.IDDOCUMENTO = eRR.IDRECIBO

                eM.IDESTADO = eESTADOSMOVIMIENTOS.Grabado

                eM.FECHAMOVIMIENTO = Me.cpFechaRecepcion.SelectedDate

                eM.CLASIFICACIONMOVIMIENTO = 1
                eM.SUBCLASIFICACIONMOVIMIENTO = 1

                eM.EMPLEADOALMACEN = Me.txtGuardalmacen.Text

                eM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                eM.AUFECHACREACION = Now()

                cM.ActualizarMOVIMIENTOS(eM)

                Me.IDMOVIMIENTO = eM.IDMOVIMIENTO

            Else
                eRR.IDALMACEN = Me.IDALMACEN
                eRR.ANIO = Me.ANIO
                eRR.IDRECIBO = Me.IDRECIBO

                cRR.ObtenerRECIBOSRECEPCION(eRR)

                eRR.RESPONSABLEPROVEEDOR = Me.txtDelegadoProveedor.Text
                eRR.OBSERVACION = Me.txtObservaciones.Text
                eRR.IDESTABLECIMIENTODEVOLUCION = Me.ddlESTABLECIMIENTOS1.SelectedValue
                eRR.NUMEROVALE = Me.txtVale.Text
                eRR.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                eRR.AUFECHAMODIFICACION = Now()

                cRR.ActualizarRECIBOSRECEPCION(eRR)

                eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                eM.IDTIPOTRANSACCION = TiposTransaccion.RecepcionPorDevolucion
                eM.IDMOVIMIENTO = Me.IDMOVIMIENTO

                cM.ObtenerMOVIMIENTOS(eM)

                eM.FECHAMOVIMIENTO = Me.cpFechaRecepcion.SelectedDate
                eM.EMPLEADOALMACEN = Me.txtGuardalmacen.Text
                eM.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                eM.AUFECHAMODIFICACION = Now()

                cM.ActualizarMOVIMIENTOS(eM)

            End If

            Me.btnCerrar.Enabled = True
            Me.btnImprimir.Enabled = True

            resultado = 1

        Catch ex As Exception
            Alert("Error:" & ex.Message, "Error")
            'Me.MsgBox1.ShowAlert("Error:" & ex.Message, "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        End Try

        Return resultado

    End Function

    Dim Total As Decimal = 0

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(8).Text = "Total:"
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(9).Text = Total.ToString("c4")
            e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
        End If

    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim cUP As New cUBICACIONESPRODUCTOS
        Dim cDM As New cDETALLEMOVIMIENTOS
        Dim cL As New cLOTES

        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDPRODUCTO")
        Dim IDUBICACION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDUBICACION")
        Dim IDDETALLEMOVIMIENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDDETALLEMOVIMIENTO")
        Dim IDLOTE As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDLOTE")

        cUP.EliminarUBICACIONESPRODUCTOS(Me.IDALMACEN, IDPRODUCTO, IDUBICACION)
        cDM.EliminarDETALLEMOVIMIENTOS(Session.Item("IdEstablecimiento"), TiposTransaccion.RecepcionPorDevolucion, Me.IDMOVIMIENTO, IDDETALLEMOVIMIENTO)
        cL.EliminarLOTES(Me.IDALMACEN, IDLOTE)

        CargarDetalleRecepcion()

    End Sub

    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
        RestablecerCriterio()
    End Sub

    Private Sub RestablecerCriterio()

        Limpiar()

        If Me.rdblCriterio.SelectedValue = 0 Then
            Me.Panel1.Visible = False
            Me.lblCodigo.Visible = True
            Me.txtProducto.Visible = True
            Me.btnBuscar.Visible = True
        Else
            Me.Panel1.Visible = True
            Me.lblCodigo.Visible = False
            Me.txtProducto.Visible = False
            Me.btnBuscar.Visible = False

            Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
            Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
            Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo2(Me.ddlSUBGRUPOS1.SelectedValue)

            Buscar(Me.ddlCATALOGOPRODUCTOS1.SelectedValue, 1)
        End If

    End Sub

    Protected Sub ddlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCATALOGOPRODUCTOS1.SelectedIndexChanged
        Buscar(Me.ddlCATALOGOPRODUCTOS1.SelectedValue, 1)
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        RestablecerCriterio()
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
        Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo2(Me.ddlSUBGRUPOS1.SelectedValue)

        Buscar(Me.ddlCATALOGOPRODUCTOS1.SelectedValue, 1)
    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo2(Me.ddlSUBGRUPOS1.SelectedValue)

        Buscar(Me.ddlCATALOGOPRODUCTOS1.SelectedValue, 1)
    End Sub

    Private Sub Limpiar()

        Me.plDetalle.Visible = False

        Me.txtProducto.Text = String.Empty

        Me.lblCodigoProducto.Text = String.Empty
        Me.lblDescripcionCompleta.Text = String.Empty

        Me.txtLote.Text = String.Empty
        Me.txtDETALLE.Text = String.Empty
        Me.txtFechaVto.Text = String.Empty
        Me.ddlFUENTEFINANCIAMIENTOS1.SelectedIndex = 0
        Me.ddlRESPONSABLEDISTRIBUCION1.SelectedIndex = 0
        Me.nbPrecioUnitario.Text = String.Empty
        Me.nbCantidad.Text = String.Empty
        Me.txtUbicacion.Text = String.Empty

        Me.txtProducto.Focus()
    End Sub

    Private Sub Buscar(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Short)

        Dim IDSUMINISTRO As Integer
        IDSUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue

        Dim cCP As New cCATALOGOPRODUCTOS
        Dim ds As Data.DataSet
        ds = cCP.FiltrarProductoDSAlmacen(CRITERIO, IDTIPOCONSULTA, IDSUMINISTRO)

        If ds.Tables(0).Rows.Count = 0 Then
            Me.IDPRODUCTO = 0
            Me.lblDescripcionCompleta.Text = "El código del producto no fue encontrado."
            If Me.txtProducto.Visible Then
                Me.txtProducto.Text = String.Empty
                Me.txtProducto.Focus()
            End If

            Me.plDetalle.Visible = False
        Else
            Me.IDPRODUCTO = ds.Tables(0).Rows(0).Item("IDPRODUCTO")
            'Me.nbPrecioUnitario.Text = ds.Tables(0).Rows(0).Item("PRECIOACTUAL")
            Me.ddlUNIDADMEDIDAS1.SelectedValue = ds.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
            Me.nbCantidad.DecimalPlaces = ds.Tables(0).Rows(0).Item("CANTIDADDECIMAL")
            Me.lblCodigoProducto.Text = ds.Tables(0).Rows(0).Item("CORRPRODUCTO").ToString
            Me.lblDescripcionCompleta.Text = ds.Tables(0).Rows(0).Item("DESCLARGO").ToString

            Me.plDetalle.Visible = True

            Me.txtLote.Focus()
        End If

    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        'MsgBox1.ShowConfirm("Si cierra el documento, este ya no podrá ser modificado, ¿desea continuar?", "Cerrar", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
        MessageBox.Confirm("Si cierra el documento, este ya no podrá ser modificado, ¿desea continuar?", "Cerrar Documento", MessageBox.OptionPostBack.YesPostBack)
    End Sub

    Private Sub Cerrar()

        Dim eM As New MOVIMIENTOS
        Dim cM As New cMOVIMIENTOS

        'eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        'eM.IDTIPOTRANSACCION = TiposTransaccion.RecepcionPorDevolucion
        eM.IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        eM.IDTIPOTRANSACCION = eTIPOTRANSACCION.RecepcionPorDevolucion
        eM.IDMOVIMIENTO = Me.IDMOVIMIENTO

        cM.ObtenerMOVIMIENTOS(eM)

        eM.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado
        eM.FECHAMOVIMIENTO = cpFechaRecepcion.SelectedDate

        eM.EMPLEADOALMACEN = Me.txtGuardalmacen.Text

        eM.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eM.AUFECHAMODIFICACION = Now
        eM.ESTASINCRONIZADA = 0

        cM.ActualizarMOVIMIENTOS(eM)

        Dim eRR As New RECIBOSRECEPCION
        Dim cRR As New cRECIBOSRECEPCION

        eRR.ANIO = eM.ANIO
        eRR.IDRECIBO = eM.IDDOCUMENTO
        eRR.IDALMACEN = eM.IDALMACEN

        cRR.ObtenerRECIBOSRECEPCION(eRR)

        eRR.RESPONSABLEPROVEEDOR = Me.txtDelegadoProveedor.Text
        eRR.NUMEROACTA = eRR.IDRECIBO 'cRR.ObtenerNumeroACTA(eRR.IDALMACEN, eRR.ANIO)
        eRR.OBSERVACION = Me.txtObservaciones.Text
        eRR.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eRR.AUFECHAMODIFICACION = Now
        eRR.ESTASINCRONIZADA = 0

        cRR.ActualizarRECIBOSRECEPCION(eRR)

        Dim cDM As New cDETALLEMOVIMIENTOS
        Dim cU As New cUTILERIAS

        Dim lista As listaDETALLEMOVIMIENTOS
        lista = cDM.ObtenerLista(eM.IDESTABLECIMIENTO, eM.IDTIPOTRANSACCION, eM.IDMOVIMIENTO)

        For Each eDM As DETALLEMOVIMIENTOS In lista
            cU.ActualizarCantidadDisponible(eM.IDALMACEN, eDM.IDLOTE, 0, 0)
        Next

        CargarDatos()

        'Me.MsgBox1.ShowConfirm("El recibo ha sido cerrado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.No)
        MessageBox.Confirm("El recibo ha sido cerrado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", MessageBox.OptionPostBack.YesNotPostBack)
    End Sub

    Protected Sub DeshabilitarDobleClickBotones()
        Me.btnAgregarLote.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnAgregarLote.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.btnAgregarLote, Nothing) + ";"
        Me.btnGuardar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnGuardar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.btnGuardar, Nothing) + ";"
        Me.btnCerrar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnCerrar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.btnCerrar, Nothing) + ";"
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

        Select Case e.Key
            Case "Cerrar"
                Cerrar()
            Case "Nuevo"
                Response.Redirect("~/ALMACEN/FrmDetMantRecepcionDevolucion.aspx?IdM=0" + "&IdA=" + Me.IDALMACEN.ToString, False)
            Case "s"
                Response.Redirect("~/FrmPrincipal.aspx", False)
        End Select

    End Sub

    Protected Sub cbVerTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodos.CheckedChanged
        Me.ddlESTABLECIMIENTOS1.RecuperarEstablecimientosPorZonaAlmancen(Me.IDALMACEN, IIf(Me.cbVerTodos.Checked, 1, 0))
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.RadioButtonList1.SelectedValue)
    End Sub

End Class
