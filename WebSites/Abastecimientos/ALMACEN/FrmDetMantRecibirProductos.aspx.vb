Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils
Imports SINAB_Utils.MessageBox
Partial Class FrmDetMantRecibirProductos
    Inherits System.Web.UI.Page

    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _RENGLON As Integer
    Private _IDPRODUCTO As Integer
    Private _IDALMACEN As Integer
    Private _IDUNIDADMEDIDA As Integer
    Private _PRECIO As Decimal
    Private _IDESTABLECIMIENTOCC As Integer
    Private _IDINFORMECC As Integer
    Private _ANIO As Integer
    Private _IDRECIBO As Integer
    Private _IDMOVIMIENTO As Integer
    Private _IDFUENTEFINANCIAMIENTO As Integer  ' SE ADICIONA FUENTE DE FINANCIAMIENTO


#Region "Propiedades"

    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property

    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDCONTRATO = value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", value)
        End Set
    End Property

    Public Property RENGLON() As Integer
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Integer)
            _RENGLON = value
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
            Me.ViewState.Add("RENGLON", value)
        End Set
    End Property

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

    Public Property IDUNIDADMEDIDA() As Integer
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal VALUE As Integer)
            _IDUNIDADMEDIDA = VALUE
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me.ViewState.Remove("IDUNIDADMEDIDA")
            Me.ViewState.Add("IDUNIDADMEDIDA", VALUE)
        End Set
    End Property

    Public Property PRECIO() As Decimal
        Get
            Return _PRECIO
        End Get
        Set(ByVal value As Decimal)
            _PRECIO = value
            If Not Me.ViewState("PRECIO") Is Nothing Then Me.ViewState.Remove("PRECIO")
            Me.ViewState.Add("PRECIO", value)
        End Set
    End Property

    Public Property IDINFORMECC() As Integer
        Get
            Return _IDINFORMECC
        End Get
        Set(ByVal value As Integer)
            _IDINFORMECC = value
            If Not Me.ViewState("IDINFORMECC") Is Nothing Then Me.ViewState.Remove("IDINFORMECC")
            Me.ViewState.Add("IDINFORMECC", value)
        End Set
    End Property

    Public Property IDESTABLECIMIENTOCC() As Integer
        Get
            Return _IDESTABLECIMIENTOCC
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTOCC = value
            If Not Me.ViewState("IDESTABLECIMIENTOCC") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTOCC")
            Me.ViewState.Add("IDESTABLECIMIENTOCC", value)
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
            Return CType(Session("IDMOVIMIENTO"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("IDMOVIMIENTO") = value
            'btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptReciboRecepcion.aspx?IdEMov=" + Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO.ToString + "&IdTT=" + eTIPOTRANSACCION.RecepcionProductos.ToString("d") + "&IdMov=" + Me.IDMOVIMIENTO.ToString + "&IdE=" + Me.IDESTABLECIMIENTO.ToString + "&IdP=" & Me.IDPROVEEDOR.ToString + "&IdC=" + Me.IDCONTRATO.ToString + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); return;"

            Dim cadena = "/Reportes/FrmRptReciboRecepcion.aspx?IdEMov=" + Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO.ToString + "&IdTT=" + eTIPOTRANSACCION.RecepcionProductos.ToString("d") + "&IdMov=" + Me.IDMOVIMIENTO.ToString + "&IdE=" + Me.IDESTABLECIMIENTO.ToString + "&IdP=" & Me.IDPROVEEDOR.ToString + "&IdC=" + Me.IDCONTRATO.ToString

            btnImprimir.OnClientClick = Utils.ReferirVentana(cadena)
        End Set
    End Property

    Public Property IDFUENTEFINANCIAMIENTO() As Integer
        Get
            Return Me.ViewState("IDFUENTEFINANCIAMIENTO")
        End Get
        Set(ByVal value As Integer)
            _IDFUENTEFINANCIAMIENTO = value
            If Not Me.ViewState("IDFUENTEFINANCIAMIENTO") Is Nothing Then Me.ViewState.Remove("IDFUENTEFINANCIAMIENTO")
            Me.ViewState.Add("IDFUENTEFINANCIAMIENTO", value)
        End Set
    End Property



#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.IDESTABLECIMIENTO = Request.QueryString("IdE")
            Me.IDPROVEEDOR = Request.QueryString("IdP")
            Me.IDCONTRATO = Request.QueryString("IdC")

            Me.IDALMACEN = Request.QueryString("IdA")
            Me.IDMOVIMIENTO = Request.QueryString("IdM")

            Me.cpFechaDocumento.UpperBoundDate = Now.Date
            Me.cvFechaDocumento.ValueToCompare = Now.Date
            Me.cpFechaRecepcion.UpperBoundDate = Now.Date
            Me.cvFechaRecepcion.ValueToCompare = Now.Date
            Me.cpFechaInformeCC.UpperBoundDate = Now.Date
            Me.cvFechaInformeCC.ValueToCompare = Now.Date

            DeshabilitarDobleClickBotones()

            Me.ddlSUMINISTROS1.RecuperarOrdenadaPorCorrelativo()
            Me.ddlSUMINISTROS1.SelectedValue = Session.Item("IdSuministro")

            Me.ddlTIPODOCUMENTORECEPCION1.Recuperar()
            If Not IsNothing(Me.ddlTIPODOCUMENTORECEPCION1.Items.FindByText("Nota de remisión")) Then Me.ddlTIPODOCUMENTORECEPCION1.Items.FindByText("Nota de remisión").Selected = True

            CargarDatosContratos()

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

                Me.txtDocumento.Focus()

            End If

        Else

            'IS POSTBACK
            If ConfirmTarget = "Nuevo" Then
                Response.Redirect("~/ALMACEN/FrmDetMantRecibirProductos.aspx?IdM=0" + "&IdA=" + Me.IDALMACEN.ToString, False)
            ElseIf ConfirmTarget = "Cerrar" Then
                Cerrar()
            End If

            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.IDALMACEN = Me.ViewState("IDALMACEN")
            If Not Me.ViewState("ANIO") Is Nothing Then Me.ANIO = Me.ViewState("ANIO")
            If Not Me.ViewState("IDRECIBO") Is Nothing Then Me.IDRECIBO = Me.ViewState("IDRECIBO")
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("IDESTABLECIMIENTOCC") Is Nothing Then Me.IDESTABLECIMIENTOCC = Me.ViewState("IDESTABLECIMIENTOCC")
            If Not Me.ViewState("IDINFORMECC") Is Nothing Then Me.IDINFORMECC = Me.ViewState("IDINFORMECC")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me.IDMOVIMIENTO = Me.ViewState("IDMOVIMIENTO")
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me.IDUNIDADMEDIDA = Me.ViewState("IDUNIDADMEDIDA")
            If Not Me.ViewState("PRECIO") Is Nothing Then Me.PRECIO = Me.ViewState("PRECIO")
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.RENGLON = Me.ViewState("RENGLON")
        End If

    End Sub

    Protected Sub gvRenglones_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvRenglones.SelectedIndexChanging
        SeleccionarRenglon(e.NewSelectedIndex)
    End Sub

    Private Sub SeleccionarRenglon(ByVal index As Integer)

        Me.RENGLON = Me.gvRenglones.DataKeys(index).Item("RENGLON")
        Me.IDPRODUCTO = Me.gvRenglones.DataKeys(index).Item("IDPRODUCTO")
        Me.IDUNIDADMEDIDA = Me.gvRenglones.DataKeys(index).Item("IDUNIDADMEDIDA")
        Me.cvCantidad.ValueToCompare = Me.gvRenglones.DataKeys(index).Item("CANTIDADPENDIENTE")
        Me.PRECIO = CDec(Me.gvRenglones.DataKeys(index).Item("PRECIOUNITARIO"))
        Me.nbCantidad.DecimalPlaces = CDec(Me.gvRenglones.DataKeys(index).Item("CANTIDADDECIMAL"))

        Me.IDFUENTEFINANCIAMIENTO = Me.gvRenglones.DataKeys(index).Item("IDFUENTEFINANCIAMIENTO")
        ddlFUENTEFINANCIAMIENTOSCONTRATOS1.SelectedValue = Me.IDFUENTEFINANCIAMIENTO

        Me.txtDescProv.Text = Me.gvRenglones.DataKeys(index).Item("DESCRIPCIONPROVEEDOR")
        Me.txtCantidadRecibir.Text = Me.gvRenglones.DataKeys(index).Item("CANTIDADPENDIENTE")
        Me.txtUM.Text = Me.gvRenglones.DataKeys(index).Item("UNIDADMEDIDA")
        Me.txtPrecioUnitario.Text = String.Format("{0:c}", Me.gvRenglones.DataKeys(index).Item("PRECIOUNITARIO").ToString)

        CargarDatosInformesMuestras()

        Resetear()

        Me.plRecepcion.Visible = True

        Me.txtDocumento.Focus()

    End Sub

    Public Sub CargarDatosInformesMuestras()

        'buscar lotes muestreados para el renglón
        Dim cIM As New cINFORMEMUESTRAS

        Dim ds As Data.DataSet
        ds = cIM.ObtenerInformacionLotesRenglon(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO, Me.RENGLON)

        Me.gvLotesMuestreados.DataSource = ds
        Me.gvLotesMuestreados.DataBind()

        Me.gvLotesMuestreados.SelectedIndex = -1

    End Sub

    Private Sub CargarDatos()

        Dim eM As New MOVIMIENTOS
        Dim cM As New cMOVIMIENTOS

        eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eM.IDTIPOTRANSACCION = eTIPOTRANSACCION.RecepcionProductos
        eM.IDMOVIMIENTO = Me.IDMOVIMIENTO

        cM.ObtenerMOVIMIENTOS(eM)

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

        Me.txtDelegadoProveedor.Text = eRR.RESPONSABLEPROVEEDOR
        Me.txtObservaciones.Text = eRR.OBSERVACION
        Me.txtAmdContrato.Text = eRR.ADMCONTRATO

        'cRR.ObtenerRECIBOSRECEPCION(eRR)
        CargarDetalleRecepcion()

        If eM.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado Then
            Me.btnGuardar.Visible = False
            Me.btnCerrar.Visible = False
            Me.btnImprimir.Text = "Ver Acta"
        End If

        Me.btnImprimir.Enabled = True

    End Sub

    Private Sub CargarDetalleRecepcion()

        Dim cRR As New cRECIBOSRECEPCION

        Dim ds As Data.DataSet
        ds = cRR.RecuperarDetalleRecepcion(Me.IDALMACEN, Me.ANIO, Me.IDRECIBO, eTIPOTRANSACCION.RecepcionProductos)

        Me.gvLista.DataSource = ds
        Me.gvLista.DataBind()

    End Sub

    Private Sub CargarDatosContratos()

        Dim eC As New CONTRATOS
        Dim cC As New cCONTRATOS

        eC = cC.obtenerDatosContrato2(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO)

        If Not eC Is Nothing Then

            Me.txtModalidadCompra.Text = eC.DESCRIPCIONMODALIDADCOMPRA
            Me.txtNoModalidadCompra.Text = eC.NUMEROMODALIDADCOMPRA
            Me.txtFuenteFinanciamiento.Text = eC.FUENTESFINANCIAMIENTO
            Me.txtResponsableDistribucion.Text = eC.RESPONSABLEDISTRIBUCION
            Me.txtResolucionAdjudicacion.Text = eC.RESOLUCIONADJUDICACION
            Me.txtNoContratoOrdenCompra.Text = eC.NUMEROCONTRATO
            Me.txtProveedor.Text = eC.NOMBREPROVEEDOR
            Me.txtFechaDistribucion.Text = Format(eC.FECHADISTRIBUCION, "dd/MM/yyyy")

            Me.ddlFUENTEFINANCIAMIENTOSCONTRATOS1.RecuperarListaPorContrato(Me.IDESTABLECIMIENTO, Me.IDCONTRATO, Me.IDPROVEEDOR)
            Me.ddlRESPONSABLEDISTRIBUCIONCONTRATO1.RecuperarListaPorContrato(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO)

            CargarDatosRenglones()

        End If

    End Sub

    Private Sub CargarDatosRenglones()

        Dim IDSUMINISTRO As Integer
        IDSUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue

        Dim cC As New cCONTRATOS
        Me.gvRenglones.DataSource = cC.ObtenerRenglonesPendientesTotales2(Me.IDESTABLECIMIENTO, Me.IDALMACEN, Me.IDPROVEEDOR, Me.IDCONTRATO, 0, IDSUMINISTRO)
        Me.gvRenglones.DataBind()

        Select Case Me.gvRenglones.Rows.Count
            Case 0
                LimpiarRenglon()
            Case 1
                Me.gvRenglones.SelectedIndex = 0
                SeleccionarRenglon(Me.gvRenglones.SelectedIndex)
            Case Else
                If Me.gvRenglones.SelectedIndex = -1 Then
                    LimpiarRenglon()
                    Dim lb As LinkButton = CType(gvRenglones.Rows(0).FindControl("LinkButton1"), LinkButton)
                    lb.Focus()
                Else
                    If Me.gvRenglones.SelectedIndex < Me.gvRenglones.Rows.Count AndAlso Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Values.Item("RENGLON") = Me.RENGLON AndAlso Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Values.Item("FUENTEFINANCIAMIENTO") = Me.IDFUENTEFINANCIAMIENTO Then
                        SeleccionarRenglon(Me.gvRenglones.SelectedIndex)
                    Else
                        Me.gvRenglones.SelectedIndex = -1
                        LimpiarRenglon()
                        Dim lb As LinkButton = CType(gvRenglones.Rows(0).FindControl("LinkButton1"), LinkButton)
                        lb.Focus()
                    End If
                End If
        End Select

        If Me.plRecepcion.Visible Then Me.txtDocumento.Focus()

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

    Protected Sub cbNumeroInformeCCNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNumeroInformeCCNA.CheckedChanged
        Me.txtNumeroInformeCC.Text = String.Empty
        Me.txtNumeroInformeCC.Enabled = Not Me.cbNumeroInformeCCNA.Checked
        Me.rfvNumeroInformeCC.Visible = Not Me.cbNumeroInformeCCNA.Checked

        Me.cpFechaInformeCC.Enabled = Not Me.cbNumeroInformeCCNA.Checked
        Me.rfvFechaInformeCC.Visible = Not Me.cbNumeroInformeCCNA.Checked
        Me.cvFechaInformeCC.Visible = Not Me.cbNumeroInformeCCNA.Checked
    End Sub

    Protected Sub btnAgregarLote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarLote.Click

        Dim FechaVto As Date

        If Not Me.cbFechaVtoNA.Checked Then

            If Me.txtFechaVto.Text.Trim = String.Empty Then
                Alert("Debe ingresar la fecha de vencimiento", "Fecha Obligatoria")
                ' Me.MsgBox1.ShowAlert("Debe ingresar la fecha de vencimiento", "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
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

            'Es necesario que el sistema permita ingresar mismo lote, misma factura, misma fecha de vencimiento por eso se elimina esta validacion 20022014
            'Dim encontrado As Boolean = False

            'For Each item As DataKey In gvLista.DataKeys
            '    If item("LOTE") = Me.txtLote.Text And _
            '    item("DOCUMENTO") = Me.txtDocumento.Text And _
            '    item("FECHADOCUMENTO") = Me.cpFechaDocumento.SelectedDate And _
            '    item("IDFUENTEFINANCIAMIENTO") = Me.ddlFUENTEFINANCIAMIENTOSCONTRATOS1.SelectedValue Then
            '        encontrado = True
            '        Exit For
            '    End If
            'Next

            'If encontrado Then
            '    Me.MsgBox1.ShowAlert("Lote " + Me.txtLote.Text + " ya ingresado.", "w", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
            '    Me.txtDocumento.Focus()
            '    Exit Sub
            'End If

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
            eL.IDUNIDADMEDIDA = Me.IDUNIDADMEDIDA
            eL.CODIGO = IIf(Me.cbLoteNA.Checked, String.Empty, Me.txtLote.Text)
            eL.DETALLE = Me.txtDETALLE.Text
            eL.PRECIOLOTE = Me.PRECIO
            eL.FECHAVENCIMIENTO = IIf(Me.cbFechaVtoNA.Checked, Nothing, FechaVto)
            eL.IDRESPONSABLEDISTRIBUCION = Me.ddlRESPONSABLEDISTRIBUCIONCONTRATO1.SelectedValue
            eL.IDFUENTEFINANCIAMIENTO = Me.ddlFUENTEFINANCIAMIENTOSCONTRATOS1.SelectedValue
            eL.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTOCC
            eL.IDINFORMECONTROLCALIDAD = Me.IDINFORMECC
            eL.NUMEROINFORMECONTROLCALIDAD = IIf(Me.cbNumeroInformeCCNA.Checked, Nothing, Me.txtNumeroInformeCC.Text)
            eL.FECHAINFORMECONTROLCALIDAD = IIf(Me.cbNumeroInformeCCNA.Checked, Nothing, Me.cpFechaInformeCC.SelectedDate)
            eL.CANTIDADDISPONIBLE = CDec(Me.nbCantidad.Text)
            eL.ESTADISPONIBLE = 0
            eL.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eL.AUFECHACREACION = Now


            'DETALLEMOVIMIENTOS
            eDM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            eDM.IDTIPOTRANSACCION = eTIPOTRANSACCION.RecepcionProductos
            eDM.IDMOVIMIENTO = Me.IDMOVIMIENTO
            eDM.IDDETALLEMOVIMIENTO = 0

            eDM.IDALMACEN = eL.IDALMACEN
            eDM.IDLOTE = eL.IDLOTE
            eDM.IDPRODUCTO = eL.IDPRODUCTO
            eDM.RENGLON = Me.RENGLON
            eDM.CANTIDAD = eL.CANTIDADDISPONIBLE

            eDM.IDTIPODOCUMENTO = Me.ddlTIPODOCUMENTORECEPCION1.SelectedValue
            eDM.NUMEROFACTURA = Me.txtDocumento.Text
            eDM.FECHAFACTURA = Me.cpFechaDocumento.SelectedDate

            eDM.MONTO = 0

            eDM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eDM.AUFECHACREACION = Now

            'UBICACIONESPRODUCTOS
            eUP.IDALMACEN = eL.IDALMACEN
            eUP.IDPRODUCTO = eL.IDPRODUCTO
            eUP.IDUBICACION = 0
            eUP.UBICACION = Me.txtUbicacion.Text
            eUP.IDLOTE = eL.IDLOTE
            eUP.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eUP.AUFECHACREACION = Now()

            'TODO: agregar insert en detalle almacen entrega contrato

            'ACTUALIZAR LAS CANTIDADES EN CADA ENTREGA
            Dim cAEC As New cALMACENESENTREGACONTRATOS

            Dim ds As Data.DataSet
            ds = cAEC.ObtenerDsEntregas(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO, eDM.RENGLON, Me.IDALMACEN, Me.IDFUENTEFINANCIAMIENTO)

            Dim dr As Data.DataRow
            Dim i As Integer = 0
            Dim cantidad As Decimal = eDM.CANTIDAD

            Dim lAEC As New listaALMACENESENTREGACONTRATOS

            While cantidad > 0 And i < ds.Tables(0).Rows.Count

                Dim eAEC As New ALMACENESENTREGACONTRATOS

                eAEC.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
                eAEC.IDPROVEEDOR = Me.IDPROVEEDOR
                eAEC.IDCONTRATO = Me.IDCONTRATO
                eAEC.RENGLON = eDM.RENGLON
                eAEC.IDALMACENENTREGA = Me.IDALMACEN
                eAEC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                eAEC.AUFECHAMODIFICACION = Now
                eAEC.IDFUENTEFINANCIAMIENTO = Me.IDFUENTEFINANCIAMIENTO ' se adiciona fuente de financiamiento


                dr = ds.Tables(0).Rows(i)
                eAEC.IDDETALLE = dr("IDDETALLE")

                If dr("CANTIDADENTREGADA") + cantidad <= dr("CANTIDAD") Then
                    'no completa entrega
                    eAEC.CANTIDADENTREGADA = dr("CANTIDADENTREGADA") + cantidad
                    cantidad = 0
                Else
                    'completo entrega
                    eAEC.CANTIDADENTREGADA = dr("CANTIDAD")
                    cantidad -= (dr("CANTIDAD") - dr("CANTIDADENTREGADA"))
                End If

                If eAEC.CANTIDADENTREGADA <> dr("CANTIDADENTREGADA") Then
                    lAEC.Add(eAEC)
                End If

                i = i + 1

            End While

            cDM.AgregarLoteRecepcion(eL, eDM, eUP, lAEC)

            CargarDetalleRecepcion()

            CargarDatosRenglones()

            If continuar = 1 Then Alert("Se ha generado el recibo " + Me.txtNroRecibo.Text + " satisfactoriamente.  Puede continuar ingresando productos.", "Recibo Generado") 'Me.MsgBox1.ShowAlert("Se ha generado el recibo " + Me.txtNroRecibo.Text + " satisfactoriamente.  Puede continuar ingresando productos.", "i", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)

        End If

    End Sub

    Public Sub Resetear()

        'Me.txtDocumento.Text = String.Empty
        'Me.cpFechaDocumento.SelectedDate = Now

        Me.nbCantidad.Text = String.Empty
        Me.txtUbicacion.Text = String.Empty

        Me.txtLote.Text = String.Empty
        Me.txtLote.Enabled = True
        Me.rfvLote.Visible = True

        Me.txtDETALLE.Text = String.Empty
        Me.txtDETALLE.Enabled = True
        Me.cbLoteNA.Checked = False

        Me.txtFechaVto.Text = String.Empty
        Me.txtFechaVto.Enabled = True
        Me.rfvFechaVto.Visible = True
        Me.cbFechaVtoNA.Checked = False

        Me.txtNumeroInformeCC.Text = String.Empty
        Me.txtNumeroInformeCC.Enabled = True
        Me.rfvNumeroInformeCC.Visible = True

        Me.cpFechaInformeCC.SelectedDate = Now
        Me.cpFechaInformeCC.Enabled = True
        Me.cbNumeroInformeCCNA.Checked = False

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If GuardarMovimiento() = 1 Then

            CargarDatos()
            Confirm("El recibo " + Me.txtNroRecibo.Text + " se ha guardado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", OptionPostBack.YesPostBack)
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
            Dim aec As New ALMACENESENTREGACONTRATOS

            If Me.IDMOVIMIENTO = 0 Then

                'RECIBOSRECEPCION
                eRR.IDALMACEN = Me.IDALMACEN
                eRR.ANIO = Me.cpFechaRecepcion.SelectedDate.Year
                eRR.IDRECIBO = Me.IDRECIBO
                eRR.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
                eRR.IDPROVEEDOR = Me.IDPROVEEDOR
                eRR.IDCONTRATO = Me.IDCONTRATO
                eRR.RESPONSABLEPROVEEDOR = Me.txtDelegadoProveedor.Text
                eRR.NUMEROACTA = 0
                eRR.OBSERVACION = Me.txtObservaciones.Text
                eRR.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                eRR.AUFECHACREACION = Now()
                eRR.ADMCONTRATO = Me.txtAmdContrato.Text
                ' aec.IDFUENTEFINANCIAMIENTO=
                cRR.ActualizarRECIBOSRECEPCION(eRR)
                'cAEC.ActualizarALMACENESENTREGACONTRATOS(aec)

                Me.ANIO = eRR.ANIO
                Me.ddlSUMINISTROS1.Enabled = False
                Me.IDRECIBO = eRR.IDRECIBO

                Me.txtNroRecibo.Text = eRR.IDRECIBO.ToString + "/" + eRR.ANIO.ToString
                Me.lblNroRecibo.Visible = True
                Me.txtNroRecibo.Visible = True

                'MOVIMIENTOS
                eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                eM.IDTIPOTRANSACCION = eTIPOTRANSACCION.RecepcionProductos
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
                eRR.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                eRR.AUFECHAMODIFICACION = Now()
                eRR.ADMCONTRATO = Me.txtAmdContrato.Text

                cRR.ActualizarRECIBOSRECEPCION(eRR)

                eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                eM.IDTIPOTRANSACCION = eTIPOTRANSACCION.RecepcionProductos
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
            ' Me.MsgBox1.ShowAlert("Error:" & ex.Message, "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        End Try

        Return resultado

    End Function

    Dim Total As Decimal = 0

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(10).Text = "Total:"
            e.Row.Cells(10).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(11).Text = Total.ToString("c4")
            e.Row.Cells(11).HorizontalAlign = HorizontalAlign.Right
        End If

    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim cDM As New cDETALLEMOVIMIENTOS
        Dim cAEC As New cALMACENESENTREGACONTRATOS
        Dim eDM As New DETALLEMOVIMIENTOS

        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDPRODUCTO")
        Dim IDDETALLEMOVIMIENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDDETALLEMOVIMIENTO")
        Dim IDLOTE As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDLOTE")
        Dim RENGLON As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("RENGLON")
        Dim CANTIDAD As Decimal = Me.gvLista.DataKeys(e.RowIndex).Values.Item("CANTIDAD")
        Dim IDFUENTEFINANCIAMIENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDFUENTEFINANCIAMIENTO")
        Me.IDFUENTEFINANCIAMIENTO = IDFUENTEFINANCIAMIENTO



        eDM.IDALMACEN = Me.IDALMACEN
        eDM.IDPRODUCTO = IDPRODUCTO

        eDM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eDM.IDTIPOTRANSACCION = eTIPOTRANSACCION.RecepcionProductos
        eDM.IDMOVIMIENTO = Me.IDMOVIMIENTO
        eDM.IDDETALLEMOVIMIENTO = IDDETALLEMOVIMIENTO

        eDM.IDLOTE = IDLOTE

        Dim ds As Data.DataSet
        ds = cAEC.ObtenerDsEntregas(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO, RENGLON, Me.IDALMACEN, Me.IDFUENTEFINANCIAMIENTO, 1)

        Dim dr As Data.DataRow
        Dim i As Integer = 0

        Dim lAEC As New listaALMACENESENTREGACONTRATOS

        While CANTIDAD > 0 And i < ds.Tables(0).Rows.Count

            Dim eAEC As New ALMACENESENTREGACONTRATOS

            eAEC.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
            eAEC.IDPROVEEDOR = Me.IDPROVEEDOR
            eAEC.IDCONTRATO = Me.IDCONTRATO
            eAEC.RENGLON = RENGLON
            eAEC.IDALMACENENTREGA = Me.IDALMACEN
            eAEC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eAEC.AUFECHAMODIFICACION = Now
            eAEC.IDFUENTEFINANCIAMIENTO = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDFUENTEFINANCIAMIENTO")


            dr = ds.Tables(0).Rows(i)
            eAEC.IDDETALLE = dr("IDDETALLE")

            If CANTIDAD > dr("CANTIDADENTREGADA") Then
                eAEC.CANTIDADENTREGADA = 0
                CANTIDAD -= dr("CANTIDADENTREGADA")
            Else
                eAEC.CANTIDADENTREGADA = dr("CANTIDADENTREGADA") - CANTIDAD
                CANTIDAD = 0
            End If

            lAEC.Add(eAEC)

            i = i + 1

        End While

        cDM.EliminarLoteRecepcion(eDM, lAEC)

        CargarDatosRenglones()

        CargarDetalleRecepcion()

    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Confirm("Si cierra el documento, este ya no podrá ser modificado, ¿desea continuar?", "Cerrar", OptionPostBack.YesPostBack)
        '  MsgBox1.ShowConfirm("Si cierra el documento, este ya no podrá ser modificado, ¿desea continuar?", "Cerrar", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
    End Sub

    Private Sub Cerrar()

        Dim eM As New MOVIMIENTOS
        Dim cM As New cMOVIMIENTOS

        eM.IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        eM.IDTIPOTRANSACCION = eTIPOTRANSACCION.RecepcionProductos
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
        eRR.ADMCONTRATO = Me.txtAmdContrato.Text

        cRR.ActualizarRECIBOSRECEPCION(eRR)

        Dim cDM As New cDETALLEMOVIMIENTOS
        Dim cU As New cUTILERIAS

        Dim lista As listaDETALLEMOVIMIENTOS
        lista = cDM.ObtenerLista(eM.IDESTABLECIMIENTO, eM.IDTIPOTRANSACCION, eM.IDMOVIMIENTO)

        Dim cPD As New cPROGRAMADISTRIBUCION
        Dim cCPC As New cCONTRATOSPROCESOCOMPRA
        Dim cAE As New cALMACENESESTABLECIMIENTOS

        Dim IDPROCESOCOMPRA As Integer = cCPC.ObtenerPCporContrato(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO)
        Dim IDESTABLECIMIENTOSOLICITA As Integer = Session.Item("IdEstablecimiento")

        For Each eDM As DETALLEMOVIMIENTOS In lista
            cU.ActualizarCantidadDisponible(eM.IDALMACEN, eDM.IDLOTE, 0, 0)

            'Programa de distribución 
            Dim ePD As New PROGRAMADISTRIBUCION
            ePD.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
            ePD.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            ePD.RENGLON = eDM.RENGLON
            ePD.IDESTABLECIMIENTOSOLICITA = IDESTABLECIMIENTOSOLICITA
            ePD.IDALMACEN = eDM.IDALMACEN

            cPD.ObtenerPROGRAMADISTRIBUCION2(ePD)

            ePD.CANTIDADENTREGADA = ePD.CANTIDADENTREGADA + eDM.CANTIDAD
            ePD.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            ePD.AUFECHAMODIFICACION = Now

            cPD.ActualizarCantidadEntregada(ePD)
        Next

        Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = False
        Me.plRecepcion.Visible = False
        Me.gvRenglones.Visible = False

        Me.btnGuardar.Visible = False
        Me.btnCerrar.Visible = False
        Me.btnImprimir.Text = "Ver Acta"
        Me.btnImprimir.Enabled = True

    End Sub

    Public Sub Limpiar()

        Me.cvCantidad.ValueToCompare = 0
        Me.nbCantidad.DecimalPlaces = 0
        Me.IDALMACEN = 0
        Me.IDCONTRATO = 0
        Me.IDESTABLECIMIENTO = 0
        Me.IDPRODUCTO = 0
        Me.IDPROVEEDOR = 0
        Me.IDUNIDADMEDIDA = 0
        Me.PRECIO = 0
        Me.RENGLON = 0

        Me.btnCerrar.Enabled = False
        Me.btnImprimir.Enabled = False

        Me.gvRenglones.DataSource = Nothing
        Me.gvRenglones.DataBind()
        Me.gvRenglones.SelectedIndex = -1

        Me.gvLotesMuestreados.DataSource = Nothing
        Me.gvLotesMuestreados.DataBind()
        Me.gvLotesMuestreados.SelectedIndex = -1

        Me.gvLista.DataSource = Nothing
        Me.gvLista.DataBind()
        Me.gvLista.SelectedIndex = -1
        Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = False

        Me.txtDescProv.Text = String.Empty
        Me.txtCantidadRecibir.Text = String.Empty
        Me.txtUM.Text = String.Empty
        Me.txtPrecioUnitario.Text = String.Empty

    End Sub

    Public Sub LimpiarRenglon()

        Me.cvCantidad.ValueToCompare = 0
        Me.nbCantidad.DecimalPlaces = 0
        Me.IDPRODUCTO = 0
        Me.IDUNIDADMEDIDA = 0
        Me.PRECIO = 0
        Me.RENGLON = 0

        Me.gvRenglones.SelectedIndex = -1

        Me.IDESTABLECIMIENTOCC = 0
        Me.IDINFORMECC = 0

        Me.gvLotesMuestreados.DataSource = Nothing
        Me.gvLotesMuestreados.DataBind()
        Me.gvLotesMuestreados.SelectedIndex = -1

        Me.txtDescProv.Text = String.Empty
        Me.txtCantidadRecibir.Text = String.Empty
        Me.txtUM.Text = String.Empty
        Me.txtPrecioUnitario.Text = String.Empty

        Resetear()

        Me.plRecepcion.Visible = False

    End Sub

    Protected Sub gvLotesMuestreados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvLotesMuestreados.SelectedIndexChanged

        Me.txtLote.Text = Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("LOTE")
        Me.txtFechaVto.Text = Format(Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("FECHAVENCIMIENTO").ToString, "MM/yyyy")

        Me.txtNumeroInformeCC.Text = Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("NUMEROINFORME")
        Me.cpFechaInformeCC.SelectedDate = Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("FECHAELABORACIONINFORME")

        Me.IDESTABLECIMIENTOCC = Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("IDESTABLECIMIENTOCC")
        Me.IDINFORMECC = Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("IDINFORMECC")

    End Sub

    Protected Sub DeshabilitarDobleClickBotones()
        Me.btnAgregarLote.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnAgregarLote.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.btnAgregarLote, Nothing) + ";"
        Me.btnGuardar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnGuardar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.btnGuardar, Nothing) + ";"
        Me.btnCerrar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnCerrar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.btnCerrar, Nothing) + ";"
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    'Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

    '    Select Case e.Key
    '        Case "Cerrar"
    '            Cerrar()
    '        Case "Nuevo"
    '            Response.Redirect("~/ALMACEN/FrmDetMantRecibirProductos.aspx?IdM=0" + "&IdA=" + Me.IDALMACEN.ToString, False)
    '    End Select

    'End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        CargarDatosRenglones()
    End Sub

    Protected Sub cbAdmContrato_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdmContrato.CheckedChanged
        Me.txtAmdContrato.Enabled = Not Me.cbAdmContrato.Checked
        Me.txtAmdContrato.Text = String.Empty
        ' Me.rfvLote.Visible = Not Me.cbLoteNA.Checked
    End Sub


End Class
