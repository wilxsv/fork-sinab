
Partial Class FrmRecepcionProductos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucSeleccionContratoRecepcion1_SeleccionarContrato() Handles ucSeleccionContratoRecepcion1.SeleccionarContrato

        Me.ucInformacionRecepcionContrato1.IDESTABLECIMIENTO = Me.ucSeleccionContratoRecepcion1.IDESTABLECIMIENTO
        Me.ucInformacionRecepcionContrato1.IDPROVEEDOR = Me.ucSeleccionContratoRecepcion1.IDPROVEEDOR
        Me.ucInformacionRecepcionContrato1.IDCONTRATO = Me.ucSeleccionContratoRecepcion1.IDCONTRATO
        Me.ucInformacionRecepcionContrato1.IDALMACEN = Me.ucSeleccionContratoRecepcion1.IDALMACEN
        Me.ucInformacionRecepcionContrato1.CargarDatos()

        Me.ucSeleccionContratoRecepcion1.Visible = False
        Me.ucInformacionRecepcionContrato1.Visible = True
        Me.ucInformacionRecepcionRenglon1.Visible = False
        Me.LinkButton1.Visible = True

    End Sub

    Protected Sub ucInformacionRecepcionContrato1_SeleccionarRenglon() Handles ucInformacionRecepcionContrato1.SeleccionarRenglon

        Me.ucInformacionRecepcionRenglon1.IDESTABLECIMIENTO = Me.ucSeleccionContratoRecepcion1.IDESTABLECIMIENTO
        Me.ucInformacionRecepcionRenglon1.IDPROVEEDOR = Me.ucSeleccionContratoRecepcion1.IDPROVEEDOR
        Me.ucInformacionRecepcionRenglon1.IDCONTRATO = Me.ucSeleccionContratoRecepcion1.IDCONTRATO
        Me.ucInformacionRecepcionRenglon1.IDALMACEN = Me.ucSeleccionContratoRecepcion1.IDALMACEN
        Me.ucInformacionRecepcionRenglon1.RENGLON = Me.ucInformacionRecepcionContrato1.RENGLON
        Me.ucInformacionRecepcionRenglon1.IDPRODUCTO = Me.ucInformacionRecepcionContrato1.IDPRODUCTO
        Me.ucInformacionRecepcionRenglon1.IDUNIDADMEDIDA = Me.ucInformacionRecepcionContrato1.IDUNIDADMEDIDA
        Me.ucInformacionRecepcionRenglon1.CANTIDADARECIBIR = Me.ucInformacionRecepcionContrato1.CANTIDADARECIBIR
        Me.ucInformacionRecepcionRenglon1.PRECIO = Me.ucInformacionRecepcionContrato1.PRECIO
        Me.ucInformacionRecepcionRenglon1.CANTIDADDECIMAL = Me.ucInformacionRecepcionContrato1.CANTIDADDECIMAL

        Me.ucInformacionRecepcionRenglon1.CargarDatos()
        Me.ucInformacionRecepcionRenglon1.Visible = True
        Me.ucInformacionRecepcionRenglon1.SetFocus()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.ucSeleccionContratoRecepcion1.Visible = True

        Me.ucInformacionRecepcionContrato1.Visible = False
        Me.ucInformacionRecepcionContrato1.Limpiar()

        Me.ucInformacionRecepcionRenglon1.Visible = False
        Me.ucInformacionRecepcionRenglon1.Limpiar()

        Me.LinkButton1.Visible = False
        Me.ucSeleccionContratoRecepcion1.Limpiar()
        Me.ucSeleccionContratoRecepcion1.CargarProveedores()
    End Sub

End Class
