
Partial Class frmGenerarOficiosAdjudicacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            With Me.UcVistaDetalleListaProcesoCompra1
                ._ESTADO = 14      'Debe ser para Generar Contratos
                ._EVAL_FEC_REC = False
                ._EVAL_FEC_RET = False
                ._IDESTABLECIMIENTO = Session("IdEstablecimiento")
                ._PAGINA_CONSULTA = ""
                ._PAGINA_REDIREC = "frmGenerarOficiosAdjudicacionPlantilla.aspx"
                .cargarDatos(0)
            End With

        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
