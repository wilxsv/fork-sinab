Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.EnumHelpers

Partial Class FrmCorreccionExistencias
    Inherits System.Web.UI.Page

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        If Trim(Me.txtProducto.Text) = "" Then
            MsgBox1.ShowAlert("Ingrese el código del producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Limpiar()
        CargarDatos(0, Me.txtProducto.Text)

    End Sub

    Dim _CANTIDAD As Decimal
    Public Property CANTIDAD() As Decimal
        Get
            Return _CANTIDAD
        End Get
        Set(ByVal value As Decimal)
            _CANTIDAD = value
            If Not Me.ViewState("CANTIDAD") Is Nothing Then Me.ViewState.Remove("CANTIDAD")
            Me.ViewState.Add("CANTIDAD", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.btnGuardar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnGuardar, Nothing) + ";"

            Me.ddlFUENTEFINANCIAMIENTOS1.Recuperar()
            Me.ddlRESPONSABLEDISTRIBUCION1.Recuperar()

            Me.ddlLOTES1.RecuperarProductosAlmacen(Session.Item("IdAlmacen"))

            If ddlLOTES1.Items.Count > 0 Then
                CargarDatos(Me.ddlLOTES1.SelectedValue)

                Me.plDatosProducto.Visible = False
                Me.ddlLOTES1.Visible = False
                Me.txtProducto.Visible = True
                Me.txtProducto.Focus()
            Else
                Me.plBusqueda.Visible = False
                Me.lblNoProductos.Visible = True
            End If
        Else
            If Not Me.ViewState("CANTIDAD") Is Nothing Then Me.CANTIDAD = Me.ViewState("CANTIDAD")
        End If

    End Sub

    Private Sub CargarDatos(ByVal IDPRODUCTO As Integer, Optional ByVal CODIGO As String = "0")

        Dim cL As New cLOTES
        Me.gvLotes.DataSource = cL.SeleccionarLotes(Session.Item("IdAlmacen"), IDPRODUCTO, CODIGO)
        Me.gvLotes.DataBind()

        If Me.gvLotes.Rows.Count = 0 Then
            Me.lblNoProductos.Visible = True
            Me.plDatosProducto.Visible = False
            Me.txtProducto.Focus()
        Else
            Me.lblNoProductos.Visible = False
            Me.plDatosProducto.Visible = True
            Me.txtCodigoProducto.Text = Me.gvLotes.DataKeys(0).Values.Item("CORRPRODUCTO")
            Me.txtDescripcion.Text = Me.gvLotes.DataKeys(0).Values.Item("DESCLARGO")
            Me.txtUnidadMedida.Text = Me.gvLotes.DataKeys(0).Values.Item("UNIDADMEDIDA")
        End If

    End Sub

    Protected Sub gvLotes_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvLotes.SelectedIndexChanging

        Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("IDFUENTEFINANCIAMIENTO")
        Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("IDRESPONSABLEDISTRIBUCION")

        If IsDBNull(Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("CODIGO")) Then
            Me.txtLote.Enabled = False
            Me.cbFechaVtoNA.Checked = True
        Else
            Me.txtLote.Text = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("CODIGO").ToString
        End If

        Me.txtDetalle.Text = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("DETALLE").ToString

        If IsDBNull(Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("FECHAVENCIMIENTO")) Then
            Me.cpFechaVencimiento.Enabled = False
            Me.cbFechaVtoNA.Checked = True
        Else
            Me.cpFechaVencimiento.SelectedDate = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("FECHAVENCIMIENTO")
        End If

        Me.txtPrecioUnitario.Text = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("PRECIOLOTE").ToString

        Me.nbNuevaCantidad.DecimalPlaces = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("CANTIDADDECIMAL")
        Me.nbNuevaCantidad.Text = String.Format("{0:f" + Me.nbNuevaCantidad.DecimalPlaces.ToString + "}", Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("CANTIDADDISPONIBLE"))

        CANTIDAD = Me.nbNuevaCantidad.Text

        Me.txtMotivo.Text = String.Empty
        Me.txtObservaciones.Text = String.Empty

        Me.plExistencias.Visible = True

        If Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("CANTIDADRESERVADA") > 0 Then
            Me.nbNuevaCantidad.Enabled = False
            Me.lblCReserv.Visible = True
        Else
            Me.nbNuevaCantidad.Enabled = True
            Me.lblCReserv.Visible = False
        End If

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGuardar.Click
        If Me.nbNuevaCantidad.Text = "" Then 'Or Me.nbNuevaCantidad.Text = 0 Then
            Me.Label1.Visible = True
            Exit Sub
        End If
        If Me.nbNuevaCantidad.Text = CANTIDAD And Me.nbNuevaCantidad.Text = 0 Then
            MsgBox1.ShowConfirm("¿Confirma que desea actualizar los datos ingresados?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.AlertType.Exclamation)

        ElseIf Me.nbNuevaCantidad.Text <> 0 Then
            MsgBox1.ShowConfirm("¿Confirma que desea actualizar los datos ingresados?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        Else
            Me.Label1.Visible = True
            Exit Sub
        End If

    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        Select Case e.Key
            Case "A"
                Actualizar()
        End Select
    End Sub

    Private Sub Actualizar()

        Dim cM As New cMOVIMIENTOS
        Dim eM As New MOVIMIENTOS
        Dim eDM As New DETALLEMOVIMIENTOS
        Dim eL As New LOTES

        Dim lDM As New listaDETALLEMOVIMIENTOS
        Dim lL As New listaLOTES

        'Movimiento
        eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

        Dim Cantidad As Decimal = CDec(Me.nbNuevaCantidad.Text) - Me.gvLotes.DataKeys(Me.gvLotes.SelectedIndex).Values.Item("CANTIDADDISPONIBLE")

        Select Case Cantidad
            Case Is = 0
                eM.IDTIPOTRANSACCION = TiposTransaccion.ActualizacionLote
                Cantidad = Me.gvLotes.DataKeys(Me.gvLotes.SelectedIndex).Values.Item("CANTIDADDISPONIBLE")
            Case Is > 0
                eM.IDTIPOTRANSACCION = TiposTransaccion.ActualizacionExistenciaMas
            Case Is < 0
                eM.IDTIPOTRANSACCION = TiposTransaccion.ActualizacionExistenciaMenos
                Cantidad = Decimal.Negate(Cantidad)
        End Select

        eM.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado
        eM.FECHAMOVIMIENTO = Now.Date
        eM.TOTALMOVIMIENTO = 0
        eM.IDEMPLEADOALMACEN = Session.Item("IdEmpleado")
        eM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eM.AUFECHACREACION = Now
        eM.ESTASINCRONIZADA = 0

        'Detalle del movimiento
        eDM.IDESTABLECIMIENTO = eM.IDESTABLECIMIENTO
        eDM.IDTIPOTRANSACCION = eM.IDTIPOTRANSACCION
        eDM.IDMOVIMIENTO = eM.IDMOVIMIENTO
        eDM.IDDETALLEMOVIMIENTO = 0
        eDM.IDALMACEN = Session.Item("IdAlmacen")
        eDM.IDLOTE = Me.gvLotes.DataKeys(Me.gvLotes.SelectedIndex).Values.Item("IDLOTE")
        eDM.IDPRODUCTO = Me.gvLotes.DataKeys(Me.gvLotes.SelectedIndex).Values.Item("IDPRODUCTO")
        eDM.CANTIDAD = Cantidad
        eDM.CANTIDADANTERIOR = Me.gvLotes.DataKeys(Me.gvLotes.SelectedIndex).Values.Item("CANTIDADDISPONIBLE")
        eDM.MONTO = 0
        eDM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eDM.AUFECHACREACION = Now()
        eDM.ESTASINCRONIZADA = 0
        lDM.Add(eDM)

        'Lote
        eL.IDALMACEN = eDM.IDALMACEN
        eL.IDLOTE = eDM.IDLOTE

        Dim cL As New cLOTES
        cL.ObtenerLOTES(eL)

        eL.CODIGO = Me.txtLote.Text
        eL.DETALLE = Me.txtDetalle.Text
        eL.FECHAVENCIMIENTO = Me.cpFechaVencimiento.SelectedDate
        eL.IDRESPONSABLEDISTRIBUCION = Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue
        eL.IDFUENTEFINANCIAMIENTO = Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue
        eL.CANTIDADDISPONIBLE = Me.nbNuevaCantidad.Text
        eL.PRECIOLOTE = Me.txtPrecioUnitario.Text
        eL.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eL.AUFECHAMODIFICACION = Now
        eL.ESTASINCRONIZADA = 0

        lL.Add(eL)

        'Documento
        Dim eCA As New CORRECCIONESALMACENES

        eCA.IDALMACEN = Session.Item("IdAlmacen")
        eCA.ANIO = Now.Year
        eCA.IDCORRECCION = 0
        eCA.IDJEFEALMACEN = Nothing
        eCA.MOTIVO = Me.txtMotivo.Text
        eCA.OBSERVACION = Me.txtObservaciones.Text
        eCA.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eCA.AUFECHACREACION = Now
        eCA.ESTASINCRONIZADA = 0

        If cM.ActualizarDocumentoMovimientoDetalleLote(eM, lDM, lL, eCA) = 1 Then
            ClientScript.RegisterStartupScript(Me.GetType, "rpt", "<script language='jscript'>window.open('" + Request.ApplicationPath + "/Reportes/FrmRptCorreccionExistencias.aspx?IdA=" & eCA.IDALMACEN.ToString & "&A=" & eCA.ANIO.ToString & "&IdC=" & eCA.IDCORRECCION.ToString & "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); </script>")
        Else
            MsgBox1.ShowAlert("La operación no pudo ser completada.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        End If

        Limpiar()
        CargarDatos(eDM.IDPRODUCTO)

    End Sub

    Protected Sub ddlLOTES1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLOTES1.SelectedIndexChanged
        Limpiar()
        CargarDatos(Me.ddlLOTES1.SelectedValue)
    End Sub

    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged

        Me.txtProducto.Text = String.Empty

        Limpiar()

        If Me.rdblCriterio.SelectedValue = 0 Then
            Me.txtProducto.Visible = True
            Me.rfvProducto.Visible = True
            Me.btnBuscar.Visible = True
            Me.ddlLOTES1.Visible = False
        Else
            Me.txtProducto.Visible = False
            Me.rfvProducto.Visible = False
            Me.btnBuscar.Visible = False
            Me.ddlLOTES1.Visible = True

            CargarDatos(Me.ddlLOTES1.SelectedValue)
        End If

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub MsgBox1_NoChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.NoChosen
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub Limpiar()

        Me.lblNoProductos.Visible = False

        Me.txtCodigoProducto.Text = String.Empty
        Me.txtDescripcion.Text = String.Empty
        Me.txtUnidadMedida.Text = String.Empty

        Me.gvLotes.SelectedIndex = -1
        Me.gvLotes.DataSource = Nothing
        Me.gvLotes.DataBind()

        Me.txtLote.Text = String.Empty
        Me.txtDetalle.Text = String.Empty
        Me.txtPrecioUnitario.Text = String.Empty

        Me.nbNuevaCantidad.Text = 0

        Me.txtMotivo.Text = String.Empty
        Me.txtObservaciones.Text = String.Empty

        Me.plDatosProducto.Visible = False
        Me.plExistencias.Visible = False

    End Sub

    Protected Sub cbLoteNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbLoteNA.CheckedChanged
        Me.txtLote.Enabled = Not Me.cbLoteNA.Checked
        Me.txtLote.Text = String.Empty
        Me.rfvLote.Visible = Not Me.cbLoteNA.Checked
    End Sub

    Protected Sub cbFechaVtoNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFechaVtoNA.CheckedChanged
        Me.cpFechaVencimiento.Enabled = Not Me.cbFechaVtoNA.Checked
        Me.rfvFechaVencimiento.Visible = Not Me.cbFechaVtoNA.Checked
    End Sub

End Class
