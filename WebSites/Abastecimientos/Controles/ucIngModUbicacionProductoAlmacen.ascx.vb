Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucIngModUbicacionProductoAlmacen
    Inherits System.Web.UI.UserControl

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

            'Me.btnGuardar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnGuardar, Nothing) + ";"

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

        Me.txtUbicacionPrincipal.Text = Me.gvLotes.DataKeys(e.NewSelectedIndex).Values.Item("UBICACION")

        Me.plUbicaciones.Visible = True
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGuardar.Click

        Dim mComponente As New cUBICACIONESPRODUCTOS
        Dim eUP As New UBICACIONESPRODUCTOS

        eUP.IDALMACEN = Session.Item("IdAlmacen")
        eUP.IDPRODUCTO = Me.gvLotes.DataKeys(Me.gvLotes.SelectedIndex).Values.Item("IDPRODUCTO")
        eUP.IDUBICACION = Me.gvLotes.DataKeys(Me.gvLotes.SelectedIndex).Values.Item("IDUBICACION")

        If mComponente.ObtenerUBICACIONESPRODUCTOS(eUP) = 0 Then
            eUP.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eUP.AUFECHACREACION = Now
        Else
            eUP.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eUP.AUFECHAMODIFICACION = Now
        End If

        eUP.UBICACION = Me.txtUbicacionPrincipal.Text

        mComponente.ActualizarUBICACIONESPRODUCTOS(eUP)

        Limpiar()
        CargarDatos(eUP.IDPRODUCTO)

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

    Private Sub Limpiar()
        Me.lblNoProductos.Visible = False

        Me.txtCodigoProducto.Text = String.Empty
        Me.txtDescripcion.Text = String.Empty
        Me.txtUnidadMedida.Text = String.Empty

        Me.gvLotes.SelectedIndex = -1
        Me.gvLotes.DataSource = Nothing
        Me.gvLotes.DataBind()

        Me.txtUbicacionPrincipal.Text = String.Empty

        Me.plDatosProducto.Visible = False
        Me.plUbicaciones.Visible = False

    End Sub

End Class
