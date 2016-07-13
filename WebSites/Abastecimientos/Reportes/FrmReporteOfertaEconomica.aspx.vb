Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmReporteOfertaEconomica
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            CargarDatos()
        End If

    End Sub

    Private Sub CargarDatos()

        Dim mComponente As New cRECEPCIONOFERTAS
        Me.gvProveedores.DataSource = mComponente.ObtenerDataSet_OfertasRecibidas2(Me.Session("idProc"), Me.Session("idEstablecimiento"))
        Me.gvProveedores.DataBind()

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvProveedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProveedores.SelectedIndexChanged
        Me.Session("idProveedor") = Me.gvProveedores.DataKeys(Me.gvProveedores.SelectedIndex).Values("IDPROVEEDOR")
        'Dim popup As New StringBuilder
        'popup.Append("<script language='javascript'>")
        'popup.Append("window.open('" & Request.ApplicationPath & "/")
        'popup.Append("Reportes/FrmRptOfertaEconomica.aspx', 'popup', ")
        'popup.Append("'scrollbars=1, resizable=1, width=800, height=600')")
        'popup.Append("</script>")

        'Page.ClientScript.RegisterStartupScript(Me.GetType, "PopupScript", popup.ToString)

        SINAB_Utils.Utils.MostrarVentana("Reportes/FrmRptOfertaEconomica.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Session("idProveedor") = 0
        'Dim popup As New StringBuilder
        'popup.Append("<script language='javascript'>")
        'popup.Append("window.open('" & Request.ApplicationPath & "/")
        'popup.Append("Reportes/FrmRptOfertaEconomica.aspx', 'popup', ")
        'popup.Append("'scrollbars=1, resizable=1, width=800, height=600')")
        'popup.Append("</script>")

        'Page.ClientScript.RegisterStartupScript(Me.GetType, "PopupScript", popup.ToString)
        SINAB_Utils.Utils.MostrarVentana("Reportes/FrmRptOfertaEconomica.aspx")
    End Sub

End Class
