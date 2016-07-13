Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmMantRecibirProductos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = True
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False

            Me.ucSeleccionContratoRecepcion1.Visible = False

            Me.ucSeleccionDocumentoRecepcion1.CargarDatos()
            Me.ucSeleccionDocumentoRecepcion1.Visible = True

        End If

    End Sub

    Protected Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        Me.ucSeleccionContratoRecepcion1.Visible = True
        Me.ucSeleccionDocumentoRecepcion1.Visible = False
    End Sub

    Protected Sub ucSeleccionContratoRecepcion1_SeleccionarContrato() Handles ucSeleccionContratoRecepcion1.SeleccionarContrato
        Response.Redirect("~/ALMACEN/FrmDetMantRecibirProductos.aspx?IdE=" + Me.ucSeleccionContratoRecepcion1.IDESTABLECIMIENTO.ToString + "&IdP=" + Me.ucSeleccionContratoRecepcion1.IDPROVEEDOR.ToString + "&IdC=" + Me.ucSeleccionContratoRecepcion1.IDCONTRATO.ToString + "&IdA=" + Me.ucSeleccionContratoRecepcion1.IDALMACEN.ToString + "&IdM=0", False)
    End Sub

    Protected Sub ucSeleccionDocumentoRecepcion1_SeleccionarDocumento() Handles ucSeleccionDocumentoRecepcion1.SeleccionarDocumento
        Response.Redirect("~/ALMACEN/FrmDetMantRecibirProductos.aspx?IdE=" + Me.ucSeleccionDocumentoRecepcion1.IDESTABLECIMIENTO.ToString + "&IdP=" + Me.ucSeleccionDocumentoRecepcion1.IDPROVEEDOR.ToString + "&IdC=" + Me.ucSeleccionDocumentoRecepcion1.IDCONTRATO.ToString + "&IdA=" + Me.ucSeleccionDocumentoRecepcion1.IDALMACEN.ToString + "&IdM=" + Me.ucSeleccionDocumentoRecepcion1.IDMOVIMIENTO.ToString, False)
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
