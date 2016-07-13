
Partial Class FrmReporteProveedoresRetiroBases
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Master.ControlMenu.Visible = False

        'If Not IsPostBack Then
        CargarDatos()
        'End If
    End Sub


    Private Sub CargarDatos()

        With Me.UcVistaDetalleProcesoCompra1

            ._IDESTABLECIMIENTO = Session("IdEstablecimiento")

            .PaginaReporte = "Reportes/FrmRptProveedoresRetiroBases.aspx"

            .Consultar()

        End With
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
