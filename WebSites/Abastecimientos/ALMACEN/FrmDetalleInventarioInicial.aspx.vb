Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports eWorld.UI
Imports SINAB_Utils

Partial Class FrmDetalleInventarioInicial
    Inherits System.Web.UI.Page

#Region "Propiedades"

    Private _IDALMACEN As Int32
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

    Private _IDINVENTARIO As Int32
    Private Property IDINVENTARIO() As Int32
        Get
            Return _IDINVENTARIO
        End Get
        Set(ByVal value As Int32)
            _IDINVENTARIO = value
            If Not Me.ViewState("IDINVENTARIO") Is Nothing Then Me.ViewState.Remove("IDINVENTARIO")
            Me.ViewState.Add("IDINVENTARIO", value)
            Dim cad = String.Format("/Reportes/FrmRptDetalleInventarioInicial.aspx?idA={0}&idI={1}", IDALMACEN, IDINVENTARIO)
            ibImprimir.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
            '   ibImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptDetalleInventarioInicial.aspx?idA=" + Me.IDALMACEN.ToString + "&idI=" + Me.IDINVENTARIO.ToString + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return;"
        End Set
    End Property

    Private _IDPRODUCTO As Int32
    Private Property IDPRODUCTO() As Int32
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Int32)
            _IDPRODUCTO = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property

    Private _IDUNIDADMEDIDA As Int32
    Private Property IDUNIDADMEDIDA() As Int32
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal value As Int32)
            _IDUNIDADMEDIDA = value
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me.ViewState.Remove("IDUNIDADMEDIDA")
            Me.ViewState.Add("IDUNIDADMEDIDA", value)
        End Set
    End Property

    Private _IDLOTE As Int32
    Private Property IDLOTE() As Int32
        Get
            Return _IDLOTE
        End Get
        Set(ByVal value As Int32)
            _IDLOTE = value
            If Not Me.ViewState("IDLOTE") Is Nothing Then Me.ViewState.Remove("IDLOTE")
            Me.ViewState.Add("IDLOTE", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Page.ClientScript.RegisterStartupScript(Me.GetType(), "Global", "")

        If Not Page.IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.txtNombreAlmacen.Text = Session.Item("NombreAlmacen").ToString

            Me.cpFechaInventario.UpperBoundDate = Now.Date
            Me.cvFechaInventario.ValueToCompare = Now.Date

            DeshabilitarDobleClickBotones()

            Me.IDALMACEN = Session.Item("IDALMACEN")
            Me.IDINVENTARIO = Request.QueryString("id")

            CargarDDLs()

            If Me.ddlSUMINISTROS1.Items.Count > 0 Then

                If Me.IDINVENTARIO = 0 Then
                    Nuevo()
                Else
                    CargarDatos()
                End If

            Else
                Me.cpFechaInventario.Enabled = False
                Me.btnGuardarInventario.Enabled = False

                Me.plProductos.Visible = False
                Me.plDetalle.Visible = False
                



            End If

        Else

            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me._IDALMACEN = Me.ViewState("IDALMACEN")
            If Not Me.ViewState("IDINVENTARIO") Is Nothing Then Me._IDINVENTARIO = Me.ViewState("IDINVENTARIO")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me._IDUNIDADMEDIDA = Me.ViewState("IDUNIDADMEDIDA")
            If Not Me.ViewState("IDLOTE") Is Nothing Then Me._IDLOTE = Me.ViewState("IDLOTE")

            If MessageBox.ConfirmTarget = "Cerrar" Then
                CerrarInventarioInicial()
            End If
        End If

    End Sub

    Private Sub CargarDDLs()

        If Me.IDINVENTARIO = 0 Then
            Me.ddlSUMINISTROS1.RecuperarParaCargaInicial(Me.IDALMACEN)
        Else
            Me.ddlSUMINISTROS1.RecuperarOrdenadaPorCorrelativo()
        End If

        Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Recuperar()
        Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue)
        Me.ddlRESPONSABLEDISTRIBUCION1.RecuperarNombreCorto()

    End Sub

    Private Sub Nuevo()
        Me.btnGuardarInventario.Visible = True
        Me.plProductos.Visible = False
        Me.plDetalle.Visible = False
    End Sub

    Private Sub CargarDatos()

        Dim eII As INVENTARIOINICIAL
        Dim cII As New cINVENTARIOINICIAL

        eII = New INVENTARIOINICIAL
        eII.IDALMACEN = Me.IDALMACEN
        eII.IDINVENTARIO = Me.IDINVENTARIO

        cII.ObtenerINVENTARIOINICIAL(eII)

        Me.ddlSUMINISTROS1.SelectedValue = eII.IDSUMINISTRO
        Me.ddlSUMINISTROS1.Enabled = False

        Me.cpFechaInventario.SelectedDate = eII.FECHAINVENTARIO

        ObtenerDetalleInventario()

        Me.plProductos.Visible = True
        Me.plBusquedaProducto.Visible = True
        Me.plSeleccionProducto.Visible = True
        Me.plSeleccionProducto.Attributes.Add("style", "height: auto;")

        Me.plDetalle.Visible = False

        Me.txtProducto.Focus()

    End Sub

    Private Sub ObtenerDetalleInventario()

        Dim cDII As New cDETALLEINVENTARIOINICIAL
        Me.gvDetalleInventario.DataSource = cDII.ObtenerInventarioInicial(Me.IDALMACEN, Me.IDINVENTARIO)

        Try
            Me.gvDetalleInventario.DataBind()
        Catch ex As Exception
            Me.gvDetalleInventario.PageIndex = 0
            Me.gvDetalleInventario.DataBind()
        End Try

        Me.gvDetalleInventario.SelectedIndex = -1

    End Sub

    Dim Total As Decimal = 0

    Protected Sub gvDetalleInventario_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDetalleInventario.PageIndexChanging
        Me.gvDetalleInventario.PageIndex = e.NewPageIndex
        ObtenerDetalleInventario()
    End Sub

    Protected Sub gvDetalleInventario_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDetalleInventario.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(10).Text = "Total:"
            e.Row.Cells(10).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(11).Text = Total.ToString("c4")
            e.Row.Cells(11).HorizontalAlign = HorizontalAlign.Right
        End If

    End Sub

    Protected Sub DeshabilitarDobleClickBotones()
        Me.btnBuscar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + Me.btnBuscar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.btnBuscar, Nothing) + ";"
        Me.btnCancelar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + Me.btnCancelar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.btnCancelar, Nothing) + ";"
        Me.btnGuardar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + Me.btnGuardar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.btnGuardar, Nothing) + ";"
        Me.btnGuardarInventario.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + Me.btnGuardarInventario.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.btnGuardarInventario, Nothing) + ";"

        Me.ibConvertirInventario.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + Me.ibConvertirInventario.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.ibConvertirInventario, Nothing) + ";"
        Me.ibImprimir.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + Me.ibImprimir.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Me.ibImprimir, Nothing) + ";"
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        'verificar lote ya ingresado
        Dim encontrado As Boolean = False

        For Each item As DataKey In gvDetalleInventario.DataKeys

            Dim kIDPRODUCTO As Integer = item("IDPRODUCTO")
            Dim kCODIGO As String = IIf(IsDBNull(item("CODIGO")), String.Empty, item("CODIGO"))
            Dim kFECHAVENCIMIENTOMMAAAA As String = item("FECHAVENCIMIENTOMMAAAA")
            Dim kPRECIOLOTE As Decimal = item("PRECIOLOTE")
            Dim kIDFUENTEFINANCIAMIENTO As Integer = item("IDFUENTEFINANCIAMIENTO")

            If kIDPRODUCTO = Me.IDPRODUCTO And _
            (kCODIGO = Me.txtLote.Text And Me.txtLote.Text <> String.Empty) And _
            kFECHAVENCIMIENTOMMAAAA = Me.txtFechaVto.Text And _
            kPRECIOLOTE = Me.nbPrecioUnitario.Text And _
            kIDFUENTEFINANCIAMIENTO = Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue Then
                encontrado = True
                Exit For
            End If
        Next

        If encontrado Then
            Me.MsgBox1.ShowAlert("Lote " + Me.txtLote.Text + " ya ingresado.", "w", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
            Me.txtLote.Focus()
            Exit Sub
        End If

        'Fecha vencimiento
        Dim FechaVto As Date

        If Not Me.cbFechaVtoNA.Checked Then

            If Me.txtFechaVto.Text.Trim = String.Empty Then
                Me.MsgBox1.ShowAlert("Debe ingresar la fecha de vencimiento", "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                Return
            End If

            FechaVto = New Date(Year(Me.txtFechaVto.Text), Month(Me.txtFechaVto.Text), 1)
            FechaVto = DateAdd(DateInterval.Month, 1, FechaVto)
            FechaVto = DateAdd(DateInterval.Day, -1, FechaVto)
        End If

        'Cantidad disponible o vencida
        Dim CantidadDisponible As Decimal
        Dim CantidadVencida As Decimal

        If Me.cbFechaVtoNA.Checked Then
            CantidadDisponible = Me.nbCantidad.Text
            CantidadVencida = 0
        Else
            If FechaVto < Now.Date Then
                CantidadDisponible = 0
                CantidadVencida = Me.nbCantidad.Text
            Else
                CantidadDisponible = Me.nbCantidad.Text
                CantidadVencida = 0
            End If
        End If

        Dim cDII As New cDETALLEINVENTARIOINICIAL
        Dim eDII As New DETALLEINVENTARIOINICIAL

        eDII.IDALMACEN = Me.IDALMACEN
        eDII.IDINVENTARIO = Me.IDINVENTARIO
        eDII.IDLOTE = Me.IDLOTE
        eDII.IDPRODUCTO = Me.IDPRODUCTO
        eDII.IDUNIDADMEDIDA = Me.IDUNIDADMEDIDA
        eDII.CODIGO = Me.txtLote.Text
        eDII.DETALLE = Me.txtDetalle.Text
        eDII.PRECIOLOTE = Me.nbPrecioUnitario.Text
        eDII.FECHAVENCIMIENTO = IIf(Me.cbFechaVtoNA.Checked, Nothing, FechaVto)
        eDII.IDFUENTEFINANCIAMIENTO = Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue
        eDII.IDRESPONSABLEDISTRIBUCION = Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue
        eDII.CANTIDADDISPONIBLE = CantidadDisponible
        eDII.CANTIDADNODISPONIBLE = Me.nbCantidad1.Text
        eDII.CANTIDADVENCIDA = CantidadVencida
        eDII.UBICACION = Me.txtUbicacion.Text

        If Me.IDLOTE = 0 Then
            eDII.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eDII.AUFECHACREACION = Now
        Else
            eDII.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eDII.AUFECHAMODIFICACION = Now
        End If

        eDII.ESTASINCRONIZADA = 0

        cDII.ActualizarDETALLEINVENTARIOINICIAL(eDII)

        ObtenerDetalleInventario()

        RestablecerSeleccionProducto()

        RestablecerDetalle()

        Me.plProductos.Visible = True
        Me.plBusquedaProducto.Visible = True
        Me.plSeleccionProducto.Visible = True
        Me.plSeleccionProducto.Attributes.Add("style", "height: auto;")

        Me.plDetalle.Visible = False

        Me.txtProducto.Focus()

    End Sub

    'Protected Sub gvProductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProductos.SelectedIndexChanged
    '    gvProductos.SelectedRow.Focus()
    'End Sub

    Protected Sub gvProductos_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvProductos.SelectedIndexChanging

        Me.IDPRODUCTO = Me.gvProductos.DataKeys(e.NewSelectedIndex).Values.Item("IDPRODUCTO")
        Me.IDUNIDADMEDIDA = Me.gvProductos.DataKeys(e.NewSelectedIndex).Values.Item("IDUNIDADMEDIDA")

        Me.nbCantidad.DecimalPlaces = Me.gvProductos.DataKeys(e.NewSelectedIndex).Values.Item("CANTIDADDECIMAL")
        Me.nbCantidad1.DecimalPlaces = Me.gvProductos.DataKeys(e.NewSelectedIndex).Values.Item("CANTIDADDECIMAL")

        Me.plDetalle.Visible = True
        Me.txtLote.Focus()

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        Dim cCP As New cCATALOGOPRODUCTOS

        RestablecerDetalle()

        Dim ds As Data.DataSet
        ds = cCP.ObtenerCatalogoProductosCompletoPorSuministro(Me.ddlSUMINISTROS1.SelectedValue, Me.txtProducto.Text)

        Me.gvProductos.DataSource = ds
        Me.gvProductos.DataBind()

        Me.gvProductos.SelectedIndex = -1

        Me.plSeleccionProducto.Visible = True
        Me.plSeleccionProducto.Attributes.Add("style", "height: auto;")

        Me.gvProductos.Visible = True

        Select Case Me.gvProductos.Rows.Count

            Case 0
                Me.plDetalle.Visible = False

            Case 1
                Me.IDPRODUCTO = Me.gvProductos.DataKeys(0).Values.Item("IDPRODUCTO")
                Me.IDUNIDADMEDIDA = Me.gvProductos.DataKeys(0).Values.Item("IDUNIDADMEDIDA")

                Me.nbCantidad.DecimalPlaces = Me.gvProductos.DataKeys(0).Values.Item("CANTIDADDECIMAL")
                Me.nbCantidad1.DecimalPlaces = Me.gvProductos.DataKeys(0).Values.Item("CANTIDADDECIMAL")

                Me.plDetalle.Visible = True

                Me.gvProductos.SelectedIndex = 0

                Me.txtLote.Focus()

            Case Else

                If Me.gvProductos.Rows.Count > 10 Then
                    Me.plSeleccionProducto.Attributes.Add("style", "height: 200px;")
                End If

                Me.plDetalle.Visible = False

        End Select

    End Sub

    Protected Sub btnGuardarInventario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarInventario.Click

        Dim cII As New cINVENTARIOINICIAL
        Dim eII As New INVENTARIOINICIAL

        eII.IDALMACEN = Session.Item("IDALMACEN")
        eII.IDINVENTARIO = Me.IDINVENTARIO
        eII.IDSUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue
        eII.FECHAINVENTARIO = Me.cpFechaInventario.SelectedDate
        eII.ESTACERRADO = 0

        If Me.IDINVENTARIO = 0 Then
            eII.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eII.AUFECHACREACION = Now
        Else
            eII.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eII.AUFECHAMODIFICACION = Now
        End If

        eII.ESTASINCRONIZADA = 0

        If cII.ActualizarINVENTARIOINICIAL(eII) = 1 Then
            Me.IDINVENTARIO = eII.IDINVENTARIO
            Me.ddlSUMINISTROS1.Enabled = False

            Me.plProductos.Visible = True
            Me.plBusquedaProducto.Visible = True
            Me.plSeleccionProducto.Visible = False
            Me.plDetalle.Visible = False
        End If

    End Sub

    Protected Sub gvDetalleInventario_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvDetalleInventario.RowDeleting

        Dim IDALMACEN, IDINVENTARIO, IDLOTE As Integer
        IDALMACEN = Me.gvDetalleInventario.DataKeys(e.RowIndex).Values.Item("IDALMACEN")
        IDINVENTARIO = Me.gvDetalleInventario.DataKeys(e.RowIndex).Values.Item("IDINVENTARIO")
        IDLOTE = Me.gvDetalleInventario.DataKeys(e.RowIndex).Values.Item("IDLOTE")

        Dim cDII As New cDETALLEINVENTARIOINICIAL
        cDII.EliminarDETALLEINVENTARIOINICIAL(IDALMACEN, IDINVENTARIO, IDLOTE)

        ObtenerDetalleInventario()

        RestablecerSeleccionProducto()

        RestablecerDetalle()

        Me.plProductos.Visible = True
        Me.plBusquedaProducto.Visible = True
        Me.plSeleccionProducto.Visible = True

        Me.plDetalle.Visible = False

        Me.txtProducto.Focus()

    End Sub

    Protected Sub gvDetalleInventario_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvDetalleInventario.SelectedIndexChanging

        Me.IDPRODUCTO = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("IDPRODUCTO")
        Me.IDUNIDADMEDIDA = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("IDUNIDADMEDIDA")

        Me.IDLOTE = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("IDLOTE")

        If IsDBNull(Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("CODIGO")) Then
            Me.txtLote.Text = String.Empty
            Me.txtLote.Enabled = False
            Me.cbLoteNA.Checked = True
            Me.rfvLote.Visible = False
        Else
            Me.txtLote.Text = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("CODIGO").ToString
        End If

        Me.txtDetalle.Text = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("DETALLE").ToString

        If IsDBNull(Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("FECHAVENCIMIENTO")) Then
            Me.txtFechaVto.Text = String.Empty
            Me.txtFechaVto.Enabled = False
            Me.cbFechaVtoNA.Checked = True
            Me.rfvFechaVto.Visible = False
        Else
            Me.txtFechaVto.Text = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("FECHAVENCIMIENTOMMAAAA").ToString
        End If

        Me.nbCantidad.DecimalPlaces = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("CANTIDADDECIMAL")
        Me.nbCantidad1.DecimalPlaces = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("CANTIDADDECIMAL")

        Dim CANTIDADDISPONIBLE, CANTIDADNODISPONIBLE, CANTIDADVENCIDA As Decimal
        CANTIDADDISPONIBLE = CDec(Server.HtmlDecode(Me.gvDetalleInventario.Rows(e.NewSelectedIndex).Cells(4).Text))
        CANTIDADNODISPONIBLE = CDec(Server.HtmlDecode(Me.gvDetalleInventario.Rows(e.NewSelectedIndex).Cells(5).Text))
        CANTIDADVENCIDA = CDec(Server.HtmlDecode(Me.gvDetalleInventario.Rows(e.NewSelectedIndex).Cells(6).Text))

        If CANTIDADVENCIDA = 0 Then
            Me.nbCantidad.Text = String.Format("{0:f" + Me.nbCantidad.DecimalPlaces.ToString + "}", CANTIDADDISPONIBLE)
        Else
            Me.nbCantidad.Text = String.Format("{0:f" + Me.nbCantidad.DecimalPlaces.ToString + "}", CANTIDADVENCIDA)
        End If

        Me.nbCantidad1.Text = String.Format("{0:f" + Me.nbCantidad1.DecimalPlaces.ToString + "}", CANTIDADNODISPONIBLE)

        Me.nbPrecioUnitario.Text = Server.HtmlDecode(Me.gvDetalleInventario.Rows(e.NewSelectedIndex).Cells(7).Text)

        Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("IDGRUPOFUENTEFINANCIAMIENTO")

        Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue)
        Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("IDFUENTEFINANCIAMIENTO")

        Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue = Me.gvDetalleInventario.DataKeys(e.NewSelectedIndex).Values.Item("IDRESPONSABLEDISTRIBUCION")

        Me.txtUbicacion.Text = Server.HtmlDecode(Me.gvDetalleInventario.Rows(e.NewSelectedIndex).Cells(10).Text)

        Me.plProductos.Visible = False
        Me.plDetalle.Visible = True

    End Sub

    Private Sub RestablecerSeleccionProducto()

        Me.txtProducto.Text = String.Empty

        Me.gvProductos.SelectedIndex = -1
        Me.gvProductos.DataSource = Nothing
        Me.gvProductos.DataBind()

        Me.gvProductos.Visible = False

    End Sub

    Private Sub RestablecerDetalle()

        Me.IDLOTE = 0
        Me.IDPRODUCTO = 0
        Me.IDUNIDADMEDIDA = 0

        Me.txtLote.Enabled = True
        Me.txtLote.Text = String.Empty
        Me.cbLoteNA.Checked = False

        Me.txtDetalle.Text = String.Empty

        Me.txtFechaVto.Enabled = True
        Me.txtFechaVto.Text = String.Empty
        Me.cbFechaVtoNA.Checked = False

        Me.nbCantidad.Text = String.Empty
        Me.nbCantidad1.Text = String.Empty

        Me.nbPrecioUnitario.Text = String.Empty

        Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.ClearSelection()
        Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue)

        Me.ddlRESPONSABLEDISTRIBUCION1.ClearSelection()

        Me.txtUbicacion.Text = String.Empty

    End Sub

    Protected Sub cbLoteNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbLoteNA.CheckedChanged
        Me.txtLote.Enabled = Not Me.cbLoteNA.Checked
        Me.txtLote.Text = String.Empty
        Me.rfvLote.Visible = Not Me.cbLoteNA.Checked
    End Sub

    Protected Sub cbFechaVtoNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFechaVtoNA.CheckedChanged
        Me.txtFechaVto.Enabled = Not Me.cbFechaVtoNA.Checked
        Me.txtFechaVto.Text = String.Empty
        Me.rfvFechaVto.Visible = Not Me.cbFechaVtoNA.Checked
    End Sub

    Protected Sub ddlGRUPOSFUENTEFINANCIAMIENTO1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedIndexChanged
        Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue)
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ibConvertirInventario_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibConvertirInventario.Click

        If Me.gvDetalleInventario.Rows.Count > 0 Then
            'MsgBox1.ShowConfirm("Los datos ingresados se trasladarán al Inventario definitivo, luego de lo cual ya no podrán ser modificados. ¿Confirma que desea continuar?", "Cerrar", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
            SINAB_Utils.MessageBox.Confirm("Los datos ingresados se trasladarán al Inventario definitivo, luego de lo cual ya no podrán ser modificados. ¿Confirma que desea continuar?", "Cerrar", MessageBox.OptionPostBack.YesPostBack)
        Else
            SINAB_Utils.MessageBox.Alert("Debe haber al menos un producto ingresado para poder convertir el inventario inicial.", "Error")
            ' MsgBox1.ShowAlert("Debe haber al menos un producto ingresado para poder convertir el inventario inicial.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Private Sub CerrarInventarioInicial()

        Dim cDII As New cDETALLEINVENTARIOINICIAL

        Dim resultado As Integer
        resultado = cDII.CerrarInventarioInicial(Me.IDALMACEN, Me.IDINVENTARIO, Session.Item("IdEstablecimiento"), HttpContext.Current.User.Identity.Name, Now)

        If resultado = 0 Then
            'ok
            Response.Redirect("~/ALMACEN/FrmInventarioInicial.aspx", False)
        Else
            MsgBox1.ShowAlert("Error al intentar cerrar el inventario inicial.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

        Select Case e.Key
            Case "Cerrar"
                CerrarInventarioInicial()
        End Select

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        RestablecerSeleccionProducto()

        RestablecerDetalle()

        Me.plProductos.Visible = True
        Me.plBusquedaProducto.Visible = True
        Me.plSeleccionProducto.Visible = True
        Me.plSeleccionProducto.Attributes.Add("style", "height: auto;")

        Me.plDetalle.Visible = False

        Me.txtProducto.Focus()

    End Sub

End Class
