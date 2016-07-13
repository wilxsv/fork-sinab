
Partial Class FrmMantIniciaProcesoCompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
        End If

        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        With Me.UcVistaListadoSolicitudCompra1
            '._CRITERIO = "IDESTADO"
            '._PAGINA_REDIRECT = "FrmDetMantIniciaProcesoCompra.aspx"
            '._FILTRO = "2"  'TODO: el Estado debe modificarse a 5 = ENVIADA A UFI
            '._OPERADOR = "="
            '._IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .consultar()
        End With
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
