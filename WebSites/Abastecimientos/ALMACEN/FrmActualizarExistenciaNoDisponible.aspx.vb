Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.EnumHelpers

Partial Class FrmActualizarExistenciaNoDisponible
    Inherits System.Web.UI.Page

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        If Trim(Me.txtProducto.Text) = "" Then
            MsgBox1.ShowAlert("Ingrese el código del producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Limpiar()
        CargarDatos(0, Me.txtProducto.Text)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.btnGuardar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnGuardar, Nothing) + ";"

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

        Me.txtFuenteFinanciamiento.Text = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("FUENTEFINANCIAMIENTO")
        Me.txtResponsableDistribucion.Text = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("RESPONSABLEDISTRIBUCION")
        Me.txtCantidadDisponible.Text = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("CANTIDADDISPONIBLE")
        Me.nbNuevaCantidad.Text = 0
        Me.cvNuevaCantidad1.ValueToCompare = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("CANTIDADDISPONIBLE")

        Me.plExistencias.Visible = True

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGuardar.Click
        MsgBox1.ShowConfirm("¿Confirma que desea actualizar los datos ingresados?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        Select Case e.Key
            Case "A"
                Actualizar()
        End Select
    End Sub

    Private Sub Actualizar()

        'Validación de la nueva cantidad no disponible
        Select Case Val(Me.nbNuevaCantidad.Text)
            Case Is = 0
                MsgBox1.ShowAlert("El valor para la nueva cantidad no disponible no puede ser cero", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.nbNuevaCantidad.Focus()
                Exit Sub
            Case Is > Val(Me.txtCantidadDisponible.Text)
                MsgBox1.ShowAlert("El valor para la nueva cantidad no disponible no puede ser mayor a la cantidad disponible", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.nbNuevaCantidad.Focus()
                Exit Sub
        End Select

        'Creación del encabezado del movimiento
        Dim cM As New cMOVIMIENTOS
        Dim cDM As New cDETALLEMOVIMIENTOS
        Dim eM As New MOVIMIENTOS

        eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eM.IDTIPOTRANSACCION = TiposTransaccion.ActualizarExistenciaNoDisponible
        eM.IDMOVIMIENTO = 0

        eM.IDALMACEN = Session.Item("IdAlmacen")
        eM.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado
        eM.FECHAMOVIMIENTO = Now.Date
        eM.TOTALMOVIMIENTO = 0
        eM.IDEMPLEADOALMACEN = Session.Item("IdEmpleado")
        eM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eM.AUFECHACREACION = Now()
        eM.ESTASINCRONIZADA = 0

        cM.ActualizarMOVIMIENTOS(eM)

        'Creación del detalle del movimiento
        Dim eDM As New DETALLEMOVIMIENTOS
        eDM.IDESTABLECIMIENTO = eM.IDESTABLECIMIENTO
        eDM.IDTIPOTRANSACCION = eM.IDTIPOTRANSACCION
        eDM.IDMOVIMIENTO = eM.IDMOVIMIENTO
        eDM.IDDETALLEMOVIMIENTO = 0
        eDM.IDALMACEN = eM.IDALMACEN
        eDM.IDLOTE = Me.gvLotes.DataKeys(Me.gvLotes.SelectedIndex).Values.Item("IDLOTE")
        eDM.IDPRODUCTO = Me.gvLotes.DataKeys(Me.gvLotes.SelectedIndex).Values.Item("IDPRODUCTO")
        eDM.CANTIDAD = Me.nbNuevaCantidad.Text
        eDM.MONTO = 0
        eDM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eDM.AUFECHACREACION = Now()
        eDM.ESTASINCRONIZADA = 0
        eDM.CANTIDADNODISPONIBLE = 1

        cDM.ActualizarDETALLEMOVIMIENTOS(eDM)

        'Llamada a las funciones de actualización de las cantidades del lote
        Dim cU As New cUTILERIAS
        Dim eL As New LOTES
        eL.IDALMACEN = Session("IdAlmacen")
        eL.IDLOTE = eDM.IDLOTE
        eL.CANTIDADDISPONIBLE = Me.nbNuevaCantidad.Text
        eL.CANTIDADNODISPONIBLE = Me.nbNuevaCantidad.Text

        cU.ActualizarCantidades(eL, 2, 1) ' resta disponible y suma no disponible

        'MsgBox1.ShowConfirm("La existencia ha sido actualizada, desea realizar otro movimiento?", "Q1", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_PostBackOnNo, Cooperator.Framework.Web.Controls.AlertType.Exclamation)

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

        Me.txtCantidadDisponible.Text = String.Empty
        Me.nbNuevaCantidad.Text = 0
        Me.txtFuenteFinanciamiento.Text = String.Empty
        Me.txtResponsableDistribucion.Text = String.Empty

        Me.txtMotivoBaja.Text = String.Empty
        Me.txtObservaciones.Text = String.Empty

        Me.plDatosProducto.Visible = False
        Me.plExistencias.Visible = False

    End Sub

End Class
