
Partial Class frmCapturarDetalleOfertas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucIngresoDetalleOferta1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            Me.ucIngresoDetalleOferta1.IDPROCESOCOMPRA = Request.QueryString("IdProc")
            Me.ucIngresoDetalleOferta1.cargarDatos()

        End If

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
