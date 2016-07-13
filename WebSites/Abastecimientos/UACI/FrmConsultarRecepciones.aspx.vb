Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.data

Partial Class FrmConsultarRecepciones
    Inherits System.Web.UI.Page

    Private mComponenteCatProductos As New cCATALOGOPRODUCTOS
    Private mComponenteContratos As New cCONTRATOS
    Private mComponenteAlmacenes As New cALMACENES
    Private mComponenteProveedores As New cPROVEEDORES
    Private mComponenteProcesoCompras As New cPROCESOCOMPRAS
    Private mComponenteGC As New cGARANTIASCONTRATOS
    Private dsProcesos As DataSet
    Private dsReporte As DataSet
    Private dv As New DataView
    Private cRec As New ConsultarRecepciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Me.ddlProcesoCompra.DataSource = mComponenteGC.ObtenerDataSetProcesoCompra(Me.Session("IdEstablecimiento"))
            Me.ddlProcesoCompra.DataValueField = "IdProcesoCompra"
            Me.ddlProcesoCompra.DataTextField = "CODIGOLICITACION"
            Me.ddlProcesoCompra.DataBind()
            Me.pnBusquedas.Visible = False
        End If
        Me.lblDetalle.Visible = False
        Me.btnImprimir.Visible = False
    End Sub

    Private Sub CargarFiltrosProceso()

        Me.ddProducto.DataSource = mComponenteCatProductos.ObtenerDataSetPorContratoProcesoCompra(Me.ddlProcesoCompra.SelectedValue, Session("IdEstablecimiento"))
        Me.ddProducto.DataTextField = "DESCLARGO"
        Me.ddProducto.DataValueField = "IDPRODUCTO"
        Me.ddProducto.DataBind()
        Me.btnConsultarPeriodo.Visible = False
        If ddProducto.Items.Count > 0 Then
            Me.ddProducto.Visible = True
            Me.lblProducto.Visible = False
            Me.btnConsultar.Visible = True
        Else
            Me.ddProducto.Visible = False
            Me.lblProducto.Visible = True
            Me.btnConsultar.Visible = False
        End If

        Me.gvContratos.DataSource = mComponenteContratos.ObtenerDsContratosProcesoCompra(Me.ddlProcesoCompra.SelectedValue, Session("IdEstablecimiento"))
        Me.gvContratos.DataBind()



        Me.ddAlmacen.DataSource = mComponenteAlmacenes.ObtenerAlmacenesDSProcesoCompraContrato(Me.ddlProcesoCompra.SelectedValue, Session("IdEstablecimiento"))
        Me.ddAlmacen.DataTextField = "NOMBRE"
        Me.ddAlmacen.DataValueField = "IDALMACEN"
        Me.ddAlmacen.DataBind()



        Me.ddProveedor.DataSource = mComponenteProveedores.ObtenerDsProveedorProcesoCompraContrato(Me.ddlProcesoCompra.SelectedValue, Session("IdEstablecimiento"))
        Me.ddProveedor.DataTextField = "NOMBRE"
        Me.ddProveedor.DataValueField = "idPROVEEDOR"
        Me.ddProveedor.DataBind()



        Me.pnProducto.Visible = True
        Me.pnContrato.Visible = False
        Me.pnAlmacen.Visible = False
        Me.pnProveedor.Visible = False
    End Sub

    Private Sub CargarFiltrosPeriodo()
        Me.btnConsultar.Visible = False
        Me.ddlProductoPeriodo.DataSource = mComponenteCatProductos.ObtenerDataSetPorPeriodoProcesoCompra(Me.cpInicio.SelectedDate, Me.cpFin.SelectedDate, Session("IdEstablecimiento"))
        Me.ddlProductoPeriodo.DataTextField = "DESCLARGO"
        Me.ddlProductoPeriodo.DataValueField = "IDPRODUCTO"
        Me.ddlProductoPeriodo.DataBind()

        If ddlProductoPeriodo.Items.Count > 0 Then
            Me.ddlProductoPeriodo.Visible = True
            Me.lblPProducto.Visible = False
            Me.btnConsultarPeriodo.Visible = True
        Else
            Me.ddlProductoPeriodo.Visible = False
            Me.lblPProducto.Visible = True
            Me.btnConsultarPeriodo.Visible = False
        End If

        Me.gvContratosPeriodo.DataSource = mComponenteContratos.ObtenerDatasetContratosPorPeriodo(Me.cpInicio.SelectedDate, Me.cpFin.SelectedDate, Session("IdEstablecimiento"))
        Me.gvContratosPeriodo.DataBind()

        Me.ddlalmacenPeriodo.DataSource = mComponenteAlmacenes.ObtenerAlmacenesDatasetPorPeriodo(Me.cpInicio.SelectedDate, Me.cpFin.SelectedDate, Session("IdEstablecimiento"))
        Me.ddlalmacenPeriodo.DataTextField = "NOMBRE"
        Me.ddlalmacenPeriodo.DataValueField = "IDALMACEN"
        Me.ddlalmacenPeriodo.DataBind()

        Me.ddlProveedorPeriodo.DataSource = mComponenteProveedores.ObtenerDatasetProveedorPorPeriodo(Me.cpInicio.SelectedDate, Me.cpFin.SelectedDate, Session("IdEstablecimiento"))
        Me.ddlProveedorPeriodo.DataTextField = "NOMBRE"
        Me.ddlProveedorPeriodo.DataValueField = "CODIGOPROVEEDOR"
        Me.ddlProveedorPeriodo.DataBind()

        Me.pnProductoPeriodo.Visible = True
        Me.pnContratoPeriodo.Visible = False
        Me.pnalmacenperiodo.Visible = False
        Me.pnProveedorPeriodo.Visible = False


    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        If Me.DropDownList1.SelectedValue = 1 Then
            Select Case Me.RadioButtonList1.SelectedValue

                Case Is = 0
                    Me.pnProducto.Visible = True
                    Me.pnContrato.Visible = False
                    Me.pnAlmacen.Visible = False
                    Me.pnProveedor.Visible = False

                    If ddProducto.Items.Count > 0 Then
                        Me.ddProducto.Visible = True
                        Me.lblProducto.Visible = False
                        Me.btnConsultar.Visible = True
                    Else
                        Me.ddProducto.Visible = False
                        Me.lblProducto.Visible = True
                        Me.btnConsultar.Visible = False
                    End If

                Case Is = 1
                    Me.pnProducto.Visible = False
                    Me.pnContrato.Visible = True
                    Me.pnAlmacen.Visible = False
                    Me.pnProveedor.Visible = False

                    If gvContratos.Rows.Count > 0 Then
                        Me.gvContratos.Visible = True
                        Me.lblcontrato.Visible = False
                        Me.btnConsultar.Visible = True
                    Else
                        Me.gvContratos.Visible = False
                        Me.lblcontrato.Visible = True
                        Me.btnConsultar.Visible = False
                    End If


                Case Is = 2
                    Me.pnProducto.Visible = False
                    Me.pnContrato.Visible = False
                    Me.pnAlmacen.Visible = True
                    Me.pnProveedor.Visible = False

                    If ddAlmacen.Items.Count > 0 Then
                        Me.ddAlmacen.Visible = True
                        Me.lblAlmacen.Visible = False
                        Me.btnConsultar.Visible = True
                    Else
                        Me.ddAlmacen.Visible = False
                        Me.lblAlmacen.Visible = True
                        Me.btnConsultar.Visible = False
                    End If

                Case Is = 3
                    Me.pnProducto.Visible = False
                    Me.pnContrato.Visible = False
                    Me.pnAlmacen.Visible = False
                    Me.pnProveedor.Visible = True

                    If ddProveedor.Items.Count > 0 Then
                        Me.ddProveedor.Visible = True
                        Me.lblProveedor.Visible = False
                        Me.btnConsultar.Visible = True
                    Else
                        Me.ddProveedor.Visible = False
                        Me.lblProveedor.Visible = True
                        Me.btnConsultar.Visible = False
                    End If
            End Select
        Else
            Select Case Me.RadioButtonList1.SelectedValue

                Case Is = 0
                    Me.pnProductoPeriodo.Visible = True
                    Me.pnContratoPeriodo.Visible = False
                    Me.pnalmacenperiodo.Visible = False
                    Me.pnProveedorPeriodo.Visible = False

                    If ddlProductoPeriodo.Items.Count > 0 Then
                        Me.ddlProductoPeriodo.Visible = True
                        Me.lblPProducto.Visible = False
                        Me.btnConsultarPeriodo.Visible = True
                    Else
                        Me.ddlProductoPeriodo.Visible = False
                        Me.lblPProducto.Visible = True
                        Me.btnConsultarPeriodo.Visible = False
                    End If

                Case Is = 1
                    Me.pnProductoPeriodo.Visible = False
                    Me.pnContratoPeriodo.Visible = True
                    Me.pnalmacenperiodo.Visible = False
                    Me.pnProveedorPeriodo.Visible = False

                    If gvContratosPeriodo.Rows.Count > 0 Then
                        Me.gvContratosPeriodo.Visible = True
                        Me.lblPContrato.Visible = False
                        Me.btnConsultarPeriodo.Visible = True
                    Else
                        Me.gvContratosPeriodo.Visible = False
                        Me.lblPContrato.Visible = True
                        Me.btnConsultarPeriodo.Visible = False
                    End If
                Case Is = 2
                    Me.pnProductoPeriodo.Visible = False
                    Me.pnContratoPeriodo.Visible = False
                    Me.pnalmacenperiodo.Visible = True
                    Me.pnProveedorPeriodo.Visible = False

                    If ddlalmacenPeriodo.Items.Count > 0 Then
                        Me.ddlalmacenPeriodo.Visible = True
                        Me.lblPAlmacen.Visible = False
                        Me.btnConsultarPeriodo.Visible = True
                    Else
                        Me.ddlalmacenPeriodo.Visible = False
                        Me.lblPAlmacen.Visible = True
                        Me.btnConsultarPeriodo.Visible = False
                    End If

                Case Is = 3
                    Me.pnProductoPeriodo.Visible = False
                    Me.pnContratoPeriodo.Visible = False
                    Me.pnalmacenperiodo.Visible = False
                    Me.pnProveedorPeriodo.Visible = True

                    If ddlProveedorPeriodo.Items.Count > 0 Then
                        Me.ddlProveedorPeriodo.Visible = True
                        Me.lblPProveedor.Visible = False
                        Me.btnConsultarPeriodo.Visible = True
                    Else
                        Me.ddlProveedorPeriodo.Visible = False
                        Me.lblPProveedor.Visible = True
                        Me.btnConsultarPeriodo.Visible = False
                    End If

            End Select

        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Me.pniProducto.Visible = True

        Dim ci As New cINCUMPLIMIENTO
        Dim pc As New ArrayList
        pc.Add(Me.ddlProcesoCompra.SelectedValue)
        ci.idProcesoCompra = pc.ToArray
        ci.idEstablecimiento = Me.Session("idestablecimiento")

        Dim ds As Data.DataSet = ci.obtenerDatasetIncumplimientos
        dv.Table = ds.Tables("Global")

        Me.Session("TipoConsulta") = RadioButtonList1.SelectedValue
        Select Case Me.RadioButtonList1.SelectedValue
            Case Is = 0
                Me.gvEncabezado.DataSource = Nothing

                Me.gvEncabezado.DataSource = mComponenteCatProductos.DevolverProducto(Session("IdEstablecimiento"), Me.Session("IDPROC"), Me.ddProducto.SelectedValue)
                Me.gvEncabezado.Columns(0).Visible = True
                Me.gvEncabezado.Columns(1).Visible = True
                Me.gvEncabezado.Columns(2).Visible = True
                Me.gvEncabezado.Columns(3).Visible = True
                Me.gvEncabezado.Columns(4).Visible = False
                Me.gvEncabezado.Columns(5).Visible = False
                Me.gvEncabezado.Columns(6).Visible = False
                Me.gvEncabezado.Columns(7).Visible = False
                Me.gvEncabezado.Columns(8).Visible = False
                Me.gvEncabezado.DataBind()

                dv.RowFilter = "idproducto = " & Me.ddProducto.SelectedValue
                gvDetalle1.DataSource = dv

                Me.Session("dsRecepciones") = dv

                Me.gvDetalle1.Columns(0).Visible = False
                Me.gvDetalle1.Columns(1).Visible = False
                Me.gvDetalle1.Columns(2).Visible = False
                Me.gvDetalle1.Columns(3).Visible = False
                Me.gvDetalle1.Columns(4).Visible = True
                Me.gvDetalle1.Columns(5).Visible = True
                Me.gvDetalle1.Columns(6).Visible = True
                Me.gvDetalle1.Columns(7).Visible = True
                Me.gvDetalle1.Columns(8).Visible = True
                Me.gvDetalle1.DataBind()

            Case Is = 1
                Me.gvEncabezado.DataSource = Nothing
                Dim cCo As New cCONTRATOS
                If Me.gvContratos.SelectedIndex = -1 Then
                    Me.gvContratos.SelectedIndex = 1
                End If
                Me.gvEncabezado.DataSource = mComponenteContratos.DevolverContrato(Session("IdEstablecimiento"), Me.Session("IDPROC"), Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values("IDCONTRATO").ToString, _
                Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values("IDPROVEEDOR").ToString)

                Me.gvEncabezado.Columns(0).Visible = False
                Me.gvEncabezado.Columns(1).Visible = False
                Me.gvEncabezado.Columns(2).Visible = False
                Me.gvEncabezado.Columns(3).Visible = False
                Me.gvEncabezado.Columns(4).Visible = True
                Me.gvEncabezado.Columns(5).Visible = True
                Me.gvEncabezado.Columns(6).Visible = False
                Me.gvEncabezado.Columns(7).Visible = False
                Me.gvEncabezado.Columns(8).Visible = False
                Me.gvEncabezado.DataBind()


                dv.RowFilter = "contrato = " & Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values("IDCONTRATO").ToString & _
                " and idproveedor = " & Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values("IDPROVEEDOR").ToString
                gvDetalle1.DataSource = dv
                Me.Session("dsRecepciones") = dv
                Me.gvDetalle1.Columns(0).Visible = True
                Me.gvDetalle1.Columns(1).Visible = True
                Me.gvDetalle1.Columns(2).Visible = True
                Me.gvDetalle1.Columns(3).Visible = True
                Me.gvDetalle1.Columns(4).Visible = False
                Me.gvDetalle1.Columns(5).Visible = False
                Me.gvDetalle1.Columns(6).Visible = True
                Me.gvDetalle1.Columns(7).Visible = True
                Me.gvDetalle1.Columns(8).Visible = True
                Me.gvDetalle1.DataBind()

            Case Is = 2
                Me.gvEncabezado.DataSource = Nothing

                Me.gvEncabezado.DataSource = mComponenteAlmacenes.DevolverAlmacen(Session("IdEstablecimiento"), Me.Session("IDPROC"), Me.ddAlmacen.SelectedValue)
                Me.gvEncabezado.Columns(0).Visible = False
                Me.gvEncabezado.Columns(1).Visible = False
                Me.gvEncabezado.Columns(2).Visible = False
                Me.gvEncabezado.Columns(3).Visible = False
                Me.gvEncabezado.Columns(4).Visible = False
                Me.gvEncabezado.Columns(5).Visible = False
                Me.gvEncabezado.Columns(6).Visible = True
                Me.gvEncabezado.Columns(7).Visible = False
                Me.gvEncabezado.Columns(8).Visible = False
                Me.gvEncabezado.DataBind()


                dv.RowFilter = "idalmacen = " & Me.ddAlmacen.SelectedValue
                gvDetalle1.DataSource = dv

                Me.Session("dsRecepciones") = dv

                Me.gvDetalle1.Columns(0).Visible = True
                Me.gvDetalle1.Columns(1).Visible = True
                Me.gvDetalle1.Columns(2).Visible = True
                Me.gvDetalle1.Columns(3).Visible = True
                Me.gvDetalle1.Columns(4).Visible = True
                Me.gvDetalle1.Columns(5).Visible = True
                Me.gvDetalle1.Columns(6).Visible = False
                Me.gvDetalle1.Columns(7).Visible = True
                Me.gvDetalle1.Columns(8).Visible = True
                Me.gvDetalle1.DataBind()

            Case Is = 3

                Me.gvEncabezado.DataSource = mComponenteProveedores.DevolverProveedor(Session("IdEstablecimiento"), Me.Session("IDPROC"), Me.ddProveedor.SelectedValue)
                Me.gvEncabezado.Columns(0).Visible = False
                Me.gvEncabezado.Columns(1).Visible = False
                Me.gvEncabezado.Columns(2).Visible = False
                Me.gvEncabezado.Columns(3).Visible = False
                Me.gvEncabezado.Columns(4).Visible = False
                Me.gvEncabezado.Columns(5).Visible = False
                Me.gvEncabezado.Columns(6).Visible = False
                Me.gvEncabezado.Columns(7).Visible = True
                Me.gvEncabezado.DataBind()

                dv.RowFilter = "idproveedor = " & Me.ddProveedor.SelectedValue
                gvDetalle1.DataSource = dv

                Me.Session("dsRecepciones") = dv

                Me.gvDetalle1.Columns(0).Visible = True
                Me.gvDetalle1.Columns(1).Visible = True
                Me.gvDetalle1.Columns(2).Visible = True
                Me.gvDetalle1.Columns(3).Visible = True
                Me.gvDetalle1.Columns(4).Visible = True
                Me.gvDetalle1.Columns(5).Visible = False
                Me.gvDetalle1.Columns(6).Visible = True
                Me.gvDetalle1.Columns(7).Visible = True
                Me.gvDetalle1.Columns(8).Visible = True
                Me.gvDetalle1.DataBind()

        End Select
        Try


            If dv.Table.Rows.Count > 0 Then
                Me.lblDetalle.Visible = False
                Me.btnImprimir.Visible = False
            Else
                Me.lblDetalle.Visible = True
                Me.btnImprimir.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If Me.DropDownList1.SelectedValue = 0 Then
            Me.lblfin.Visible = True
            Me.lblini.Visible = True
            Me.cpInicio.Visible = True
            Me.cpFin.Visible = True
            Me.lblproceso.Visible = False
            Me.ddlProcesoCompra.Visible = False
        Else
            Me.lblfin.Visible = False
            Me.lblini.Visible = False
            Me.cpInicio.Visible = False
            Me.cpFin.Visible = False
            Me.lblproceso.Visible = True
            Me.ddlProcesoCompra.Visible = True
        End If
        Me.pnBusquedas.Visible = False
    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Me.pnBusquedas.Visible = True
        Me.RadioButtonList1.SelectedIndex = 0
        If Me.DropDownList1.SelectedValue = 0 Then
            Me.pnPeriodo.Visible = True
            Me.pnProceso.Visible = False
            CargarFiltrosPeriodo()
        Else
            Me.Session("IDPROC") = Me.ddlProcesoCompra.SelectedValue
            Me.pnPeriodo.Visible = False
            Me.pnProceso.Visible = True
            CargarFiltrosProceso()
        End If
    End Sub

    Protected Sub btnConsultarPeriodo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarPeriodo.Click
        Me.pniProducto.Visible = True

        Dim dv As New Data.DataView
        Dim ci As New ABASTECIMIENTOS.NEGOCIO.cINCUMPLIMIENTO

        Dim i As Integer

        Dim dsp As DataSet
        dsp = mComponenteProcesoCompras.ObtenerDataSetProcesoCompraPorPeriodo(Me.cpInicio.SelectedDate, Me.cpFin.SelectedDate, Session("IdEstablecimiento"))

        Dim pc As New ArrayList

        For i = 0 To dsp.Tables(0).Rows.Count - 1
            pc.Add(CInt(dsp.Tables(0).Rows(i).Item(0).ToString))
        Next

        ci.idProcesoCompra = pc.ToArray
        ci.idEstablecimiento = Me.Session("idestablecimiento")

        Dim ds As Data.DataSet = ci.obtenerDatasetIncumplimientos

        dv.Table = ds.Tables("Global")

        Select Case Me.RadioButtonList1.SelectedValue
            Case Is = 0
                Me.gvEncabezado.DataSource = Nothing

                Me.gvEncabezado.DataSource = mComponenteCatProductos.DevolverProductoPeriodo(Session("IdEstablecimiento"), Me.ddlProductoPeriodo.SelectedValue, dsProcesos)
                Me.gvEncabezado.Columns(0).Visible = True
                Me.gvEncabezado.Columns(1).Visible = True
                Me.gvEncabezado.Columns(2).Visible = True
                Me.gvEncabezado.Columns(3).Visible = True
                Me.gvEncabezado.Columns(4).Visible = False
                Me.gvEncabezado.Columns(5).Visible = False
                Me.gvEncabezado.Columns(6).Visible = False
                Me.gvEncabezado.Columns(7).Visible = False
                Me.gvEncabezado.Columns(8).Visible = False
                Me.gvEncabezado.DataBind()


                dv.RowFilter = "idproducto = " & Me.ddlProductoPeriodo.SelectedValue
                gvDetalle1.DataSource = dv

                Me.Session("dsRecepciones") = dv

                Me.gvDetalle1.Columns(0).Visible = False
                Me.gvDetalle1.Columns(1).Visible = False
                Me.gvDetalle1.Columns(2).Visible = False
                Me.gvDetalle1.Columns(3).Visible = False
                Me.gvDetalle1.Columns(4).Visible = True
                Me.gvDetalle1.Columns(5).Visible = True
                Me.gvDetalle1.Columns(6).Visible = True
                Me.gvDetalle1.Columns(7).Visible = True
                Me.gvDetalle1.Columns(8).Visible = True
                Me.gvDetalle1.DataBind()


            Case Is = 1
                Me.gvEncabezado.DataSource = Nothing
                Dim cCo As New cCONTRATOS
                Me.gvEncabezado.DataSource = mComponenteContratos.DevolverContratoPeriodo(Session("IdEstablecimiento"), Me.gvContratosPeriodo.DataKeys(Me.gvContratosPeriodo.SelectedIndex).Values("IDCONTRATO").ToString, _
                Me.gvContratosPeriodo.DataKeys(Me.gvContratosPeriodo.SelectedIndex).Values("IDPROVEEDOR").ToString, dsProcesos)

                Me.gvEncabezado.Columns(0).Visible = False
                Me.gvEncabezado.Columns(1).Visible = False
                Me.gvEncabezado.Columns(2).Visible = False
                Me.gvEncabezado.Columns(3).Visible = False
                Me.gvEncabezado.Columns(4).Visible = True
                Me.gvEncabezado.Columns(5).Visible = True
                Me.gvEncabezado.Columns(6).Visible = False
                Me.gvEncabezado.Columns(7).Visible = False
                Me.gvEncabezado.Columns(8).Visible = False
                Me.gvEncabezado.DataBind()


                dv.RowFilter = "contrato = " & Me.gvContratosPeriodo.DataKeys(Me.gvContratosPeriodo.SelectedIndex).Values("IDCONTRATO").ToString & _
                "and idproveedor = " & Me.gvContratosPeriodo.DataKeys(Me.gvContratosPeriodo.SelectedIndex).Values("IDPROVEEDOR").ToString
                gvDetalle1.DataSource = dv
                Me.Session("dsRecepciones") = dv
                Me.gvDetalle1.Columns(0).Visible = True
                Me.gvDetalle1.Columns(1).Visible = True
                Me.gvDetalle1.Columns(2).Visible = True
                Me.gvDetalle1.Columns(3).Visible = True
                Me.gvDetalle1.Columns(4).Visible = False
                Me.gvDetalle1.Columns(5).Visible = False
                Me.gvDetalle1.Columns(6).Visible = True
                Me.gvDetalle1.Columns(7).Visible = True
                Me.gvDetalle1.Columns(8).Visible = True
                Me.gvDetalle1.DataBind()
            Case Is = 2
                Me.gvEncabezado.DataSource = Nothing

                Me.gvEncabezado.DataSource = mComponenteAlmacenes.DevolverAlmacenPeriodo(Session("IdEstablecimiento"), Me.ddlalmacenPeriodo.SelectedValue, dsProcesos)
                Me.gvEncabezado.Columns(0).Visible = False
                Me.gvEncabezado.Columns(1).Visible = False
                Me.gvEncabezado.Columns(2).Visible = False
                Me.gvEncabezado.Columns(3).Visible = False
                Me.gvEncabezado.Columns(4).Visible = False
                Me.gvEncabezado.Columns(5).Visible = False
                Me.gvEncabezado.Columns(6).Visible = True
                Me.gvEncabezado.Columns(7).Visible = False
                Me.gvEncabezado.Columns(8).Visible = False
                Me.gvEncabezado.DataBind()

                dv.RowFilter = "idalmacen = " & Me.ddlalmacenPeriodo.SelectedValue
                gvDetalle1.DataSource = dv

                Me.Session("dsRecepciones") = dv

                Me.gvDetalle1.Columns(0).Visible = True
                Me.gvDetalle1.Columns(1).Visible = True
                Me.gvDetalle1.Columns(2).Visible = True
                Me.gvDetalle1.Columns(3).Visible = True
                Me.gvDetalle1.Columns(4).Visible = True
                Me.gvDetalle1.Columns(5).Visible = True
                Me.gvDetalle1.Columns(6).Visible = False
                Me.gvDetalle1.Columns(7).Visible = True
                Me.gvDetalle1.Columns(8).Visible = True
                Me.gvDetalle1.DataBind()
            Case Is = 3

                Me.gvEncabezado.DataSource = mComponenteProveedores.DevolverProveedorPeriodo(Session("IdEstablecimiento"), Me.ddlProveedorPeriodo.SelectedValue, dsProcesos)
                Me.gvEncabezado.Columns(0).Visible = False
                Me.gvEncabezado.Columns(1).Visible = False
                Me.gvEncabezado.Columns(2).Visible = False
                Me.gvEncabezado.Columns(3).Visible = False
                Me.gvEncabezado.Columns(4).Visible = False
                Me.gvEncabezado.Columns(5).Visible = False
                Me.gvEncabezado.Columns(6).Visible = False
                Me.gvEncabezado.Columns(7).Visible = True
                Me.gvEncabezado.DataBind()

                dv.RowFilter = "idproveedor = " & Me.ddlProveedorPeriodo.SelectedValue
                gvDetalle1.DataSource = dv

                Me.Session("dsRecepciones") = dv

                Me.gvDetalle1.Columns(0).Visible = True
                Me.gvDetalle1.Columns(1).Visible = True
                Me.gvDetalle1.Columns(2).Visible = True
                Me.gvDetalle1.Columns(3).Visible = True
                Me.gvDetalle1.Columns(4).Visible = True
                Me.gvDetalle1.Columns(5).Visible = False
                Me.gvDetalle1.Columns(6).Visible = True
                Me.gvDetalle1.Columns(7).Visible = True
                Me.gvDetalle1.Columns(8).Visible = True
                Me.gvDetalle1.DataBind()

        End Select
        If dv.Table.Rows.Count > 0 Then
            Me.lblDetalle.Visible = False
            Me.btnImprimir.Visible = False
        Else
            Me.lblDetalle.Visible = True
            Me.btnImprimir.Visible = False
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'Response.Write("<script language=javascript>")
        'Response.Write("window.open('" + Request.ApplicationPath + "/Reportes/frmRptConsultarRecepciones.aspx');")
        'Response.Write("</script>")
        SINAB_Utils.Utils.MostrarVentana("/Reportes/frmRptConsultarRecepciones.aspx")
    End Sub

End Class
