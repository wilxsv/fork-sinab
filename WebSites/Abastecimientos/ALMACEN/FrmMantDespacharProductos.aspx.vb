
Partial Class FrmMantDespacharProductos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Session("VALE") = Nothing
            Session("ldm") = Nothing
            Me.Master.ControlMenu.Visible = False

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = True
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False

        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        If Request.QueryString("d") = 2 Then
            Response.Redirect("~/ALMACEN/FrmDetMantDespacharProductosDistribucion.aspx?IdMov=0" + "&IdAlm=" + ucSeleccionDocumentoSalida1.IDALMACEN.ToString, False)
        Else
            Response.Redirect("~/ALMACEN/FrmDetMantDespacharProductos.aspx?IdMov=0" + "&IdAlm=" + ucSeleccionDocumentoSalida1.IDALMACEN.ToString, False)
        End If

    End Sub

End Class
