
Partial Class FrmMantIniciaProcesoCompraUACI

    Inherits System.Web.UI.Page

    Private _IDESTABLECIMIENTO As Int32
    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int32)
            Me._IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Master.ControlMenu.Visible = False

        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        With Me.UcVistaListadoSolicitudCompra1
            ._CRITERIO = "IDESTADO"
            ._PAGINA_REDIRECT = "FrmDetMantIniciaProcesoCompra.aspx"
            ._FILTRO = "7"
            ._OPERADOR = "="
            ._IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .consultar()
        End With

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
