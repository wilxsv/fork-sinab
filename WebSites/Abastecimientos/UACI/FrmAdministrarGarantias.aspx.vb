Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmAdministrarGarantias
    Inherits System.Web.UI.Page

    Private mComponenteProcesoCompra As New cPROCESOCOMPRAS
    Private mComponenteTipoGarantia As New cTIPOGARANTIAS
    Private mComponenteGarantiasContratos As New cGARANTIASCONTRATOS
    Private mEntidadGarantiasContratos As GARANTIASCONTRATOS
    'Private mEntidadProcesoCompra As PROCESOCOMPRAS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            cargardatos()
            Me.UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
            Me.UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False
            Me.UcVistaDetalleSolicProcesCompra1.Visible = False
            Me.Label15.Visible = False
            Me.Panel1.Visible = False
            mComponenteGarantiasContratos.ActualizarEstadosGarantias()
        End If
    End Sub

    Private Sub cargardatos()
        Me.ddlProcesosCompra.DataSource = mComponenteGarantiasContratos.ObtenerDataSetProcesoCompra(Session("IdEstablecimiento"))
        Me.ddlProcesosCompra.DataTextField = "CODIGOLICITACION"
        Me.ddlProcesosCompra.DataValueField = "IdProcesoCompra"
        Me.ddlProcesosCompra.DataBind()
        Me.ddlProveedores.DataSource = mComponenteGarantiasContratos.ObtenerDataSetProveedor()
        Me.ddlProveedores.DataTextField = "NOMBRE"
        Me.ddlProveedores.DataValueField = "IDPROVEEDOR"
        Me.ddlProveedores.DataBind()
        Me.CPFechaRecepcion.SelectedDate = Today
        Me.cpFechaVenc.SelectedDate = Today
        Me.ddlTipoGarantia.DataSource = mComponenteTipoGarantia.ObtenerDataSetPorId
        Me.ddlTipoGarantia.DataValueField = "IDTIPOGARANTIA"
        Me.ddlTipoGarantia.DataTextField = "NOMBRE"
        Me.ddlTipoGarantia.DataBind()
        Me.ddlTipoG.DataSource = mComponenteTipoGarantia.ObtenerDataSetPorId
        Me.ddlTipoG.DataValueField = "IDTIPOGARANTIA"
        Me.ddlTipoG.DataTextField = "NOMBRE"
        Me.ddlTipoG.DataBind()

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub btnBuscarContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarContrato.Click
        Me.gvGarantias.DataSource = Nothing
        Me.gvContratos.DataSource = Nothing
        Me.gvContratos2.DataSource = Nothing
        Me.gvRenglones.DataSource = Nothing

        Try
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try
        Try

            Me.gvContratos2.DataBind()
        Catch ex As Exception
            Me.gvContratos2.PageIndex = 0
            Me.gvContratos2.DataBind()
        End Try

        Try
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            Me.gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try

        Try
            Me.gvContratos.DataSource = mComponenteGarantiasContratos.ObtenerDataSetBusquedaContrato(Me.Session("idEstablecimiento"), Trim(Me.txtContrato.Text))
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try

        Me.UcVistaDetalleSolicProcesCompra1.Visible = False
        Me.Label15.Visible = False
        Me.Panel1.Visible = False
    End Sub

    Protected Sub btnBuscarPC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPC.Click
        Me.gvGarantias.DataSource = Nothing
        Me.gvContratos.DataSource = Nothing
        Me.gvContratos2.DataSource = Nothing
        Me.gvRenglones.DataSource = Nothing
        Me.gvGarantias.DataBind()
        Try
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try
        Try

            Me.gvContratos2.DataBind()
        Catch ex As Exception
            Me.gvContratos2.PageIndex = 0
            Me.gvContratos2.DataBind()
        End Try

        Try
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            Me.gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try

        Try
            Me.gvContratos.DataSource = mComponenteGarantiasContratos.ObtenerDataSetBusquedaProcesoCompra(Session("IdEstablecimiento"), Me.ddlProcesosCompra.SelectedValue)
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try

        Me.UcVistaDetalleSolicProcesCompra1.Visible = False
        Me.Label15.Visible = False
        Me.Panel1.Visible = False
    End Sub

    Protected Sub btnBuscarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Me.gvGarantias.DataSource = Nothing
        Me.gvContratos.DataSource = Nothing
        Me.gvContratos2.DataSource = Nothing
        Me.gvRenglones.DataSource = Nothing
        Me.gvGarantias.DataBind()
        Try
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try
        Try

            Me.gvContratos2.DataBind()
        Catch ex As Exception
            Me.gvContratos2.PageIndex = 0
            Me.gvContratos2.DataBind()
        End Try

        Try
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            Me.gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try
        Try

            Me.gvContratos.DataSource = mComponenteGarantiasContratos.ObtenerDataSetBusquedaProveedor(Session("IdEstablecimiento"), Me.ddlProveedores.SelectedValue)
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try

        Me.UcVistaDetalleSolicProcesCompra1.Visible = False
        Me.Label15.Visible = False
        Me.Panel1.Visible = False
    End Sub

    Protected Sub rbFiltros_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbFiltros.SelectedIndexChanged
        Select Case Me.rbFiltros.SelectedValue

            Case 0 ' contrato
                Me.txtContrato.Text = ""
                Me.pnFiltroContrato.Visible = True
                Me.pnFiltroFechaVenc.Visible = False
                Me.pnFiltroNumeroGarantia.Visible = False
                Me.pnFiltroProceso.Visible = False
                Me.pnFiltroProveedor.Visible = False
                Me.pnFiltroTipoGarantia.Visible = False
            Case 1 ' proceso compra
                Me.ddlProcesosCompra.SelectedIndex = 0
                Me.pnFiltroContrato.Visible = False
                Me.pnFiltroFechaVenc.Visible = False
                Me.pnFiltroNumeroGarantia.Visible = False
                Me.pnFiltroProceso.Visible = True
                Me.pnFiltroProveedor.Visible = False
                Me.pnFiltroTipoGarantia.Visible = False
            Case 2 'proveedor
                Me.ddlProveedores.SelectedIndex = 0
                Me.pnFiltroContrato.Visible = False
                Me.pnFiltroFechaVenc.Visible = False
                Me.pnFiltroNumeroGarantia.Visible = False
                Me.pnFiltroProceso.Visible = False
                Me.pnFiltroProveedor.Visible = True
                Me.pnFiltroTipoGarantia.Visible = False
            Case 3 'fecha vencimiento
                Me.cpFechaVenc.SelectedDate = Today
                Me.pnFiltroContrato.Visible = False
                Me.pnFiltroFechaVenc.Visible = True
                Me.pnFiltroNumeroGarantia.Visible = False
                Me.pnFiltroProceso.Visible = False
                Me.pnFiltroProveedor.Visible = False
                Me.pnFiltroTipoGarantia.Visible = False
            Case 4 'tipo garantia
                Me.ddlTipoGarantia.SelectedIndex = 0
                Me.pnFiltroContrato.Visible = False
                Me.pnFiltroFechaVenc.Visible = False
                Me.pnFiltroNumeroGarantia.Visible = False
                Me.pnFiltroProceso.Visible = False
                Me.pnFiltroProveedor.Visible = False
                Me.pnFiltroTipoGarantia.Visible = True
            Case 5 ' numero garantia
                Me.txtNumeroGarantia.Text = ""
                Me.pnFiltroContrato.Visible = False
                Me.pnFiltroFechaVenc.Visible = False
                Me.pnFiltroNumeroGarantia.Visible = True
                Me.pnFiltroProceso.Visible = False
                Me.pnFiltroProveedor.Visible = False
                Me.pnFiltroTipoGarantia.Visible = False
        End Select
        Me.gvGarantias.DataSource = Nothing
        Me.gvContratos.DataSource = Nothing
        Me.gvContratos2.DataSource = Nothing
        Me.gvRenglones.DataSource = Nothing
        Me.gvGarantias.DataBind()
        Me.gvContratos.DataBind()
        Me.gvContratos2.DataBind()
        Me.gvRenglones.DataBind()
        Me.UcVistaDetalleSolicProcesCompra1.Visible = False
        Me.Label15.Visible = False
        Me.Panel1.Visible = False
    End Sub

    Protected Sub gvRenglones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRenglones.PageIndexChanging
        Me.gvRenglones.PageIndex = e.NewPageIndex
        Me.gvRenglones.DataSource = mComponenteGarantiasContratos.ObtenerDataSetRenglones(Session("IdEstablecimiento"), Me.Session("IdProveedor"), Me.Session("IdProcesoCompra"))
        Me.gvRenglones.DataBind()
    End Sub

    Protected Sub gvGarantias_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvGarantias.SelectedIndexChanged

        Me.Session("IdTipoGarantia") = Me.gvGarantias.DataKeys(Me.gvGarantias.SelectedIndex).Values.Item("IDTIPOGARANTIA").ToString
        Me.Session("IdGarantiaContrato") = Me.gvGarantias.DataKeys(Me.gvGarantias.SelectedIndex).Values.Item("IDGARANTIACONTRATO").ToString
        CargarDatosGarantia(Me.Session("idEstablecimiento"), Me.Session("IdContrato"), Me.Session("IdProveedor"), Me.Session("IdTipoGarantia"), Me.Session("IdGarantiaContrato"))
        Me.RadioButtonList1.SelectedValue = 0
    End Sub

    Private Sub CargarDatosGarantia(ByVal idestablecimiento As Integer, ByVal idcontrato As Integer, ByVal idproveedor As Integer, ByVal idtipogarantia As Integer, ByVal idgarantiacontrato As Integer)
        mEntidadGarantiasContratos = New GARANTIASCONTRATOS
        mEntidadGarantiasContratos.IDCONTRATO = idcontrato
        mEntidadGarantiasContratos.IDTIPOGARANTIA = idtipogarantia
        mEntidadGarantiasContratos.IDPROVEEDOR = idproveedor
        mEntidadGarantiasContratos.IDESTABLECIMIENTO = idestablecimiento
        mEntidadGarantiasContratos.IDGARANTIACONTRATO = idgarantiacontrato

        '
        Dim ds As Data.DataSet
        ds = mComponenteGarantiasContratos.obtenerEncabezadoGarantia(idestablecimiento, idproveedor, idcontrato, idtipogarantia, idgarantiacontrato)
        Me.lblContrato.Text = ds.Tables(0).Rows(0).Item("numerocontrato").ToString
        Me.lblProveedor.Text = ds.Tables(0).Rows(0).Item("proveedor").ToString
        Me.lblProcesoCompra.Text = ds.Tables(0).Rows(0).Item("procesocompra").ToString
        Me.lblMonto.Text = ds.Tables(0).Rows(0).Item("montocontrato").ToString
        Me.lblResolucion.Text = ds.Tables(0).Rows(0).Item("numeroresolucion").ToString
        Me.lblEstado.Text = ds.Tables(0).Rows(0).Item("estado").ToString
        Me.lblPersona.Text = ds.Tables(0).Rows(0).Item("persona").ToString
        mComponenteGarantiasContratos.ObtenerGARANTIASCONTRATOS(mEntidadGarantiasContratos)
        Me.rqdevolucion.Visible = False
        Me.rqefectiva.Visible = False
        Me.cpFechadevolucion.Enabled = False
        Me.cpFechaEfectiva.Enabled = False
        Me.txtEfectiva.Enabled = False
        Me.txtDevolucion.Enabled = False
        Me.cpFechaEntrega.Enabled = False
        Me.cpFechadevolucion.SelectedDate = Today
        Me.cpFechaEfectiva.SelectedDate = Today
        Me.CPFechaRecepcion.SelectedDate = Today
        Me.cpFechavencimiento.SelectedDate = Today

        'Mostrar u ocultar los campos necesarios dependiendo del estado de la garantia seleccionada
        Select Case mEntidadGarantiasContratos.IDESTADOGARANTIA
            Case 1 ' En espera
                Me.btnRecibir.Visible = True
                Me.btnDevolver.Visible = False
                Me.btnEfectiva.Visible = False
                Me.btnCancelar.Visible = True
                Me.txtNumGarantia.Enabled = True
                Me.CPFechaRecepcion.Enabled = True
                Me.txtVigencia.Enabled = True
                Me.cpFechavencimiento.Enabled = True
                Me.txtAseguradora.Enabled = True
                Me.nbMontoGarantia.Enabled = True
                Me.txtEfectiva.Visible = False
                Me.lblEfectiva.Visible = False
                Me.txtEfectiva.CausesValidation = False
                Me.lblDevolucion.Visible = False
                Me.txtDevolucion.Visible = False
                Me.txtDevolucion.CausesValidation = False
                Me.RadioButtonList1.Visible = False
                Me.cpFechaEfectiva.Visible = False
                Me.lblfefectiva.Visible = False
                Me.lblfdevolucion.Visible = False
                Me.cpFechadevolucion.Visible = False
                Me.cpFechaEntrega.Enabled = True


            Case 2 'Vigente o Recibida
                Me.btnRecibir.Visible = True
                Me.btnDevolver.Visible = False
                Me.btnEfectiva.Visible = False
                Me.btnCancelar.Visible = True
                Me.txtNumGarantia.Enabled = True
                Me.CPFechaRecepcion.Enabled = True
                Me.txtVigencia.Enabled = True
                Me.cpFechavencimiento.Enabled = True
                Me.txtAseguradora.Enabled = True
                Me.nbMontoGarantia.Enabled = True
                Me.txtEfectiva.Visible = False
                Me.lblEfectiva.Visible = False
                Me.txtEfectiva.CausesValidation = False
                Me.lblDevolucion.Visible = False
                Me.txtDevolucion.Visible = False
                Me.txtDevolucion.CausesValidation = False
                Me.RadioButtonList1.Visible = False
                Me.txtDevolucion.Enabled = False
                Me.txtEfectiva.Enabled = False
                Me.cpFechaEfectiva.Visible = False
                Me.lblfefectiva.Visible = False
                Me.lblfdevolucion.Visible = False
                Me.cpFechadevolucion.Visible = False
            Case 3 ' Vencida
                Me.btnRecibir.Visible = False
                Me.btnDevolver.Visible = False
                Me.btnEfectiva.Visible = True
                Me.btnCancelar.Visible = True
                Me.txtEfectiva.Visible = True
                Me.lblEfectiva.Visible = True
                Me.txtEfectiva.CausesValidation = True
                Me.lblDevolucion.Visible = False
                Me.txtDevolucion.Visible = False
                Me.txtDevolucion.CausesValidation = False
                Me.txtNumGarantia.Enabled = False
                Me.CPFechaRecepcion.Enabled = False
                Me.txtVigencia.Enabled = False
                Me.cpFechavencimiento.Enabled = False
                Me.txtAseguradora.Enabled = False
                Me.nbMontoGarantia.Enabled = False
                Me.RadioButtonList1.Visible = True
                Me.txtDevolucion.Enabled = True
                Me.txtEfectiva.Enabled = True
                Me.cpFechaEfectiva.Visible = False
                Me.lblfefectiva.Visible = False
                Me.lblfdevolucion.Visible = False
                Me.cpFechadevolucion.Visible = False
                Me.lblfefectiva.Visible = True
                Me.cpFechaEfectiva.Visible = True
                Me.cpFechaEfectiva.Enabled = True
            Case 4 ' Efectiva
                Me.btnRecibir.Visible = False
                Me.btnDevolver.Visible = False
                Me.btnEfectiva.Visible = False
                Me.btnCancelar.Visible = False
                Me.txtEfectiva.Visible = True
                Me.lblEfectiva.Visible = True
                Me.txtEfectiva.CausesValidation = False
                Me.lblDevolucion.Visible = False
                Me.txtDevolucion.Visible = False
                Me.txtDevolucion.CausesValidation = False
                Me.txtNumGarantia.Enabled = False
                Me.CPFechaRecepcion.Enabled = False
                Me.txtVigencia.Enabled = False
                Me.cpFechavencimiento.Enabled = False
                Me.txtAseguradora.Enabled = False
                Me.nbMontoGarantia.Enabled = False
                Me.RadioButtonList1.Visible = False
                Me.txtDevolucion.Enabled = False
                Me.txtEfectiva.Enabled = False
                Me.cpFechaEfectiva.Visible = True
                Me.cpFechaEfectiva.Enabled = False
                Me.lblfefectiva.Visible = True
                Me.lblfdevolucion.Visible = False
                Me.cpFechadevolucion.Visible = False
            Case 5 ' Expirada
                Me.btnRecibir.Visible = False
                Me.btnDevolver.Visible = False
                Me.btnEfectiva.Visible = False
                Me.btnCancelar.Visible = False
                Me.txtEfectiva.Visible = True
                Me.lblEfectiva.Visible = True
                Me.txtEfectiva.CausesValidation = False
                Me.lblDevolucion.Visible = True
                Me.txtDevolucion.Visible = True
                Me.txtDevolucion.Enabled = False
                Me.txtEfectiva.Enabled = False
                Me.txtDevolucion.CausesValidation = False
                Me.txtNumGarantia.Enabled = False
                Me.CPFechaRecepcion.Enabled = False
                Me.txtVigencia.Enabled = False
                Me.cpFechavencimiento.Enabled = False
                Me.txtAseguradora.Enabled = False
                Me.nbMontoGarantia.Enabled = False
                Me.RadioButtonList1.Visible = False

                Me.cpFechaEfectiva.Visible = True
                Me.lblfefectiva.Visible = True
                Me.lblfdevolucion.Visible = True
                Me.cpFechadevolucion.Visible = True
            Case 6 ' Devuelta
                Me.btnRecibir.Visible = False
                Me.btnDevolver.Visible = False
                Me.btnEfectiva.Visible = False
                Me.btnCancelar.Visible = False
                Me.txtEfectiva.Visible = False
                Me.lblEfectiva.Visible = False

                Me.txtEfectiva.CausesValidation = False
                Me.cpFechaEfectiva.Visible = False
                Me.lblfefectiva.Visible = False
                Me.lblfdevolucion.Visible = True
                Me.cpFechadevolucion.Visible = True
                Me.lblDevolucion.Visible = True
                Me.txtDevolucion.Visible = True
                Me.txtDevolucion.CausesValidation = False
                Me.txtNumGarantia.Enabled = False
                Me.CPFechaRecepcion.Enabled = False
                Me.txtVigencia.Enabled = False
                Me.cpFechavencimiento.Enabled = False
                Me.txtAseguradora.Enabled = False
                Me.nbMontoGarantia.Enabled = False
                Me.RadioButtonList1.Visible = False

                Me.txtDevolucion.Enabled = False
                Me.txtEfectiva.Enabled = False
                Me.cpFechaEfectiva.Visible = False
                Me.lblfefectiva.Visible = False
                Me.lblfdevolucion.Visible = True
                Me.cpFechadevolucion.Visible = True
        End Select

        If mEntidadGarantiasContratos.IDESTADOGARANTIA = 1 Or mEntidadGarantiasContratos.IDESTADOGARANTIA = 2 Then
        ElseIf mEntidadGarantiasContratos.IDESTADOGARANTIA = 3 Then

        End If

        Me.ddlTipoG.SelectedValue = mEntidadGarantiasContratos.IDTIPOGARANTIA
        Me.txtNumGarantia.Text = mEntidadGarantiasContratos.NUMEROGARANTIA
        If mEntidadGarantiasContratos.FECHARECEPCION.Year > 1901 Then
            Me.CPFechaRecepcion.SelectedDate = mEntidadGarantiasContratos.FECHARECEPCION
        Else
            Me.CPFechaRecepcion.SelectedDate = Today
        End If
        Me.txtVigencia.Text = mEntidadGarantiasContratos.VIGENCIA

        If mEntidadGarantiasContratos.FECHAVENCIMIENTO.Year > 1901 Then
            Me.cpFechavencimiento.SelectedDate = mEntidadGarantiasContratos.FECHAVENCIMIENTO
        Else
            ' Me.cpFechavencimiento.SelectedDate = Today
            Try
                Me.cpFechavencimiento.SelectedDate = DateAdd(DateInterval.Day, CDbl(Me.txtVigencia.Text), Me.CPFechaRecepcion.SelectedDate)
            Catch ex As Exception
                MsgBox("Debe llenar el campo de vigencia", MsgBoxStyle.Information, ".::Sistema de Abastecimiento::.")
            End Try
        End If

        If mEntidadGarantiasContratos.FECHAEFECTIVA.Year > 1901 Then
            Me.cpFechaEfectiva.SelectedDate = mEntidadGarantiasContratos.FECHAEFECTIVA
        Else
            Me.cpFechaEfectiva.SelectedDate = Today
        End If
        If mEntidadGarantiasContratos.FECHAENTREGA.Year > 1901 Then
            Me.cpFechaEntrega.SelectedDate = mEntidadGarantiasContratos.FECHAENTREGA
        Else
            Me.cpFechaEntrega.SelectedDate = Today
        End If

        Me.txtAseguradora.Text = mEntidadGarantiasContratos.ASEGURADORA
        Me.nbMontoGarantia.Text = mEntidadGarantiasContratos.MONTO
        Me.txtDevolucion.Text = mEntidadGarantiasContratos.JUSTIFICACIONDEVOLUCION
        Me.txtEfectiva.Text = mEntidadGarantiasContratos.JUSTIFICACIONEFECTIVA

        ds.Clear()
        Me.Panel1.Visible = True
        Me.lblMensaje.Text = ""
    End Sub

    Private Sub GuardarDatosGarantia(ByVal idestablecimiento As Integer, ByVal idcontrato As Integer, ByVal idproveedor As Integer, ByVal idtipogarantia As Integer, ByVal estado As Integer, ByVal idgarantiacontrato As Integer)
        mEntidadGarantiasContratos = New GARANTIASCONTRATOS
        mEntidadGarantiasContratos.IDCONTRATO = idcontrato
        mEntidadGarantiasContratos.IDTIPOGARANTIA = idtipogarantia
        mEntidadGarantiasContratos.IDPROVEEDOR = idproveedor
        mEntidadGarantiasContratos.IDESTABLECIMIENTO = idestablecimiento
        mEntidadGarantiasContratos.IDGARANTIACONTRATO = idgarantiacontrato

        mComponenteGarantiasContratos.ObtenerGARANTIASCONTRATOS(mEntidadGarantiasContratos)
        mEntidadGarantiasContratos.FECHAENTREGA = Me.cpFechaEntrega.SelectedDate
        mEntidadGarantiasContratos.IDESTADOGARANTIA = estado
        mEntidadGarantiasContratos.IDTIPOGARANTIA = Me.ddlTipoG.SelectedValue
        mEntidadGarantiasContratos.NUMEROGARANTIA = Me.txtNumGarantia.Text
        mEntidadGarantiasContratos.FECHARECEPCION = Me.CPFechaRecepcion.SelectedDate
        mEntidadGarantiasContratos.VIGENCIA = Me.txtVigencia.Text
        mEntidadGarantiasContratos.FECHAVENCIMIENTO = Me.cpFechavencimiento.SelectedDate
        mEntidadGarantiasContratos.ASEGURADORA = Me.txtAseguradora.Text
        mEntidadGarantiasContratos.MONTO = Me.nbMontoGarantia.Text
        mEntidadGarantiasContratos.JUSTIFICACIONDEVOLUCION = Me.txtDevolucion.Text
        mEntidadGarantiasContratos.JUSTIFICACIONEFECTIVA = Me.txtEfectiva.Text
        If estado = 4 Then
            mEntidadGarantiasContratos.FECHAEFECTIVA = Me.cpFechaEfectiva.SelectedDate
        ElseIf estado = 6 Then
            mEntidadGarantiasContratos.FECHADEVOLUCION = Me.cpFechadevolucion.SelectedDate
        End If

        mComponenteGarantiasContratos.ActualizarGARANTIASCONTRATOS(mEntidadGarantiasContratos)
    End Sub

    Protected Sub btnRecibir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecibir.Click
        Me.GuardarDatosGarantia(Me.Session("idEstablecimiento"), Me.Session("IdContrato"), Me.Session("IdProveedor"), Me.Session("IdTipoGarantia"), 2, Me.Session("IdGarantiaContrato"))
        Me.gvGarantias.DataSource = mComponenteGarantiasContratos.obtenerDatasetGarantiasXContrato(Session("IdEstablecimiento"), Me.Session("IdContrato"), Me.Session("IdProveedor"))
        Me.gvGarantias.DataBind()
        Me.Panel1.Visible = False
        Me.lblMensaje.Text = "Datos guardados satisfactoriamente"
    End Sub

    Protected Sub btnEfectiva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEfectiva.Click
        Me.GuardarDatosGarantia(Me.Session("idEstablecimiento"), Me.Session("IdContrato"), Me.Session("IdProveedor"), Me.Session("IdTipoGarantia"), 4, Me.Session("IdGarantiaContrato"))
        Me.gvGarantias.DataSource = mComponenteGarantiasContratos.obtenerDatasetGarantiasXContrato(Session("IdEstablecimiento"), Me.Session("IdContrato"), Me.Session("IdProveedor"))
        Me.gvGarantias.DataBind()
        Me.Panel1.Visible = False
        Me.lblMensaje.Text = "Datos guardados satisfactoriamente"
    End Sub

    Protected Sub btnDevolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDevolver.Click
        Me.GuardarDatosGarantia(Me.Session("idEstablecimiento"), Me.Session("IdContrato"), Me.Session("IdProveedor"), Me.Session("IdTipoGarantia"), 6, Me.Session("IdGarantiaContrato"))
        Me.gvGarantias.DataSource = mComponenteGarantiasContratos.obtenerDatasetGarantiasXContrato(Session("IdEstablecimiento"), Me.Session("IdContrato"), Me.Session("IdProveedor"))
        Me.gvGarantias.DataBind()
        Me.Panel1.Visible = False
        Me.lblMensaje.Text = "Datos guardados satisfactoriamente"
    End Sub

    Protected Sub gvContratos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvContratos.SelectedIndexChanged

        Me.Session("IdContrato") = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values.Item("IDCONTRATO").ToString
        Me.Session("IdProveedor") = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values.Item("IDPROVEEDOR").ToString
        Me.Session("IdProcesoCompra") = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values.Item("IdProcesoCompra").ToString
        Me.UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = Me.Session("IdEstablecimiento")
        Me.UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = Me.Session("IdProcesoCompra")
        Me.UcVistaDetalleSolicProcesCompra1.Consultar()
        Me.UcVistaDetalleSolicProcesCompra1.Visible = True
        Me.Label15.Visible = True

        'CargarGarantiasXContrato(Me.Session("IdContrato"), Me.Session("IdProveedor"), Me.Session("IdProcesoCompra"))
        Me.gvGarantias.DataSource = mComponenteGarantiasContratos.obtenerDatasetGarantiasXContrato(Session("IdEstablecimiento"), Me.Session("IdContrato"), Me.Session("IdProveedor"))
        Me.gvGarantias.DataBind()
        Me.gvRenglones.DataSource = mComponenteGarantiasContratos.ObtenerDataSetRenglones(Session("IdEstablecimiento"), Me.Session("IdProveedor"), Me.Session("IdProcesoCompra"))
        Me.gvRenglones.DataBind()
        Me.Panel1.Visible = False

    End Sub

    Protected Sub gvContratos2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvContratos2.SelectedIndexChanged
        Me.Session("IdContrato") = Me.gvContratos2.DataKeys(Me.gvContratos2.SelectedIndex).Values.Item("IDCONTRATO").ToString
        Me.Session("IdProveedor") = Me.gvContratos2.DataKeys(Me.gvContratos2.SelectedIndex).Values.Item("IDPROVEEDOR").ToString
        Me.Session("IdProcesoCompra") = Me.gvContratos2.DataKeys(Me.gvContratos2.SelectedIndex).Values.Item("IdProcesoCompra").ToString
        Me.UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = Me.Session("IdEstablecimiento")
        Me.UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = Me.Session("IdProcesoCompra")
        Me.UcVistaDetalleSolicProcesCompra1.Consultar()
        Me.UcVistaDetalleSolicProcesCompra1.Visible = True
        Me.Label15.Visible = True
        'CargarGarantiasXContrato(Me.Session("IdContrato"), Me.Session("IdProveedor"), Me.Session("IdProcesoCompra"))
        Me.gvGarantias.DataSource = mComponenteGarantiasContratos.obtenerDatasetGarantiasXContrato(Session("IdEstablecimiento"), Me.Session("IdContrato"), Me.Session("IdProveedor"))
        Me.gvGarantias.DataBind()
        Try
            Me.gvRenglones.DataSource = mComponenteGarantiasContratos.ObtenerDataSetRenglones(Session("IdEstablecimiento"), Me.Session("IdProveedor"), Me.Session("IdProcesoCompra"))
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            Me.gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try

        Me.Panel1.Visible = False
    End Sub

    Protected Sub btnBuscarFecha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarFecha.Click
        Me.gvGarantias.DataSource = Nothing
        Me.gvContratos.DataSource = Nothing
        Me.gvContratos2.DataSource = Nothing
        Me.gvRenglones.DataSource = Nothing
        Me.gvGarantias.DataBind()
        Try
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try
        Try

            Me.gvContratos2.DataBind()
        Catch ex As Exception
            Me.gvContratos2.PageIndex = 0
            Me.gvContratos2.DataBind()
        End Try

        Try
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            Me.gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try
        Try
            Me.gvContratos2.DataSource = mComponenteGarantiasContratos.ObtenerDataSetBusquedaFechaVencimiento(Session("IdEstablecimiento"), Me.cpFechaVenc.SelectedDate)
            Me.gvContratos2.DataBind()
        Catch ex As Exception
            Me.gvContratos2.PageIndex = 0
            Me.gvContratos2.DataBind()
        End Try

        Me.UcVistaDetalleSolicProcesCompra1.Visible = False
        Me.Label15.Visible = False
        Me.Panel1.Visible = False
        Me.lblMensaje.Text = ""
    End Sub

    Protected Sub btnTipoGarantia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTipoGarantia.Click
        Me.gvGarantias.DataSource = Nothing
        Me.gvContratos.DataSource = Nothing
        Me.gvContratos2.DataSource = Nothing
        Me.gvRenglones.DataSource = Nothing
        Me.gvGarantias.DataBind()
        Try
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try
        Try

            Me.gvContratos2.DataBind()
        Catch ex As Exception
            Me.gvContratos2.PageIndex = 0
            Me.gvContratos2.DataBind()
        End Try

        Try
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            Me.gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try
        Try
            Me.gvContratos2.DataSource = mComponenteGarantiasContratos.ObtenerDataSetBusquedaTipoGarantia(Session("IdEstablecimiento"), Me.ddlTipoGarantia.SelectedValue)
            Me.gvContratos2.DataBind()
        Catch ex As Exception
            Me.gvContratos2.PageIndex = 0
            Me.gvContratos2.DataBind()
        End Try

        Me.UcVistaDetalleSolicProcesCompra1.Visible = False
        Me.Label15.Visible = False
        Me.Panel1.Visible = False
        Me.lblMensaje.Text = ""
    End Sub

    Protected Sub btnNumGarantia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNumGarantia.Click
        Me.gvGarantias.DataSource = Nothing
        Me.gvContratos.DataSource = Nothing
        Me.gvContratos2.DataSource = Nothing
        Me.gvRenglones.DataSource = Nothing
        Me.gvGarantias.DataBind()
        Try
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try
        Try

            Me.gvContratos2.DataBind()
        Catch ex As Exception
            Me.gvContratos2.PageIndex = 0
            Me.gvContratos2.DataBind()
        End Try

        Try
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            Me.gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try

        Try
            Me.gvContratos2.DataSource = mComponenteGarantiasContratos.ObtenerDataSetBusquedaNumeroGarantia(Session("IdEstablecimiento"), Me.txtNumeroGarantia.Text)
            Me.gvContratos2.DataBind()
        Catch ex As Exception
            Me.gvContratos2.PageIndex = 0
            Me.gvContratos2.DataBind()
        End Try

        Me.UcVistaDetalleSolicProcesCompra1.Visible = False
        Me.Label15.Visible = False
        Me.Panel1.Visible = False
        Me.lblMensaje.Text = ""
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Me.cpFechaEfectiva.SelectedDate = Today
        Me.cpFechadevolucion.SelectedDate = Today
        Me.txtEfectiva.Text = ""
        Me.txtDevolucion.Text = ""
        Me.lblMensaje.Text = ""
        If Me.RadioButtonList1.SelectedValue = 0 Then
            Me.btnRecibir.Visible = False
            Me.btnDevolver.Visible = False
            Me.btnEfectiva.Visible = True
            Me.btnCancelar.Visible = True
            Me.txtEfectiva.Visible = True
            Me.lblEfectiva.Visible = True
            Me.btnEfectiva.CausesValidation = True
            Me.lblDevolucion.Visible = False
            Me.txtDevolucion.Visible = False
            Me.btnDevolver.CausesValidation = False
            Me.cpFechaEfectiva.Visible = True
            Me.cpFechadevolucion.Visible = False
            Me.cpFechaEfectiva.Enabled = True
            Me.cpFechadevolucion.Enabled = False
            Me.rqdevolucion.Visible = False
            Me.rqefectiva.Visible = True
            Me.lblfefectiva.Visible = True
            Me.lblfdevolucion.Visible = False

        Else
            Me.btnRecibir.Visible = False
            Me.btnDevolver.Visible = True
            Me.btnEfectiva.Visible = False
            Me.btnCancelar.Visible = True
            Me.txtEfectiva.Visible = False
            Me.lblEfectiva.Visible = False
            Me.btnEfectiva.CausesValidation = False
            Me.lblDevolucion.Visible = True
            Me.txtDevolucion.Visible = True
            Me.btnDevolver.CausesValidation = True
            Me.cpFechaEfectiva.Visible = False
            Me.cpFechadevolucion.Visible = True
            Me.cpFechaEfectiva.Enabled = False
            Me.cpFechadevolucion.Enabled = True
            Me.rqdevolucion.Visible = True
            Me.rqefectiva.Visible = False
            Me.lblfefectiva.Visible = False
            Me.lblfdevolucion.Visible = True
        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Panel1.Visible = False
        Me.lblMensaje.Text = "Accion cancelada"
    End Sub

    Protected Sub UcVistaDetalleSolicProcesCompra1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcVistaDetalleSolicProcesCompra1.Load

    End Sub

    Protected Sub btnrptProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrptProveedor.Click
        Me.Session("Idprov") = Me.ddlProveedores.SelectedValue
        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptGarantias.aspx?tipo=1', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub btnrptFecha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrptFecha.Click
        Me.Session("FechaV") = Me.cpFechaVenc.SelectedDate
        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptGarantias.aspx?tipo=2', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub btnrptTipo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrptTipo.Click
        Me.Session("TipoG") = Me.ddlTipoGarantia.SelectedValue
        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptGarantias.aspx?tipo=3', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.cpFechavencimiento.SelectedDate = DateAdd(DateInterval.Day, CDbl(Me.txtVigencia.Text), Me.CPFechaRecepcion.SelectedDate)
        Catch ex As Exception
            MsgBox("Debe llenar el campo de vigencia", MsgBoxStyle.Information, ".::Sistema de Abastecimiento::.")
        End Try


    End Sub
End Class
