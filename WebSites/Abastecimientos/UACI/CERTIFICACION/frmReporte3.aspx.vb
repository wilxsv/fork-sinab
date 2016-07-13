Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class UACI_CERTIFICACION_frmReporte3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            
            rFiltros.CargarDatos()
            rFiltros.MostarEstado = False
        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

   

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        SINAB_Utils.Utils.MostrarVentana(String.Format("/UACI/CERTIFICACION/Reportes/FrmConstanciaProductoNoCertificado.aspx?idpc={0}&idtp={1}&nit={2}&codigo={3}", rFiltros.IdProceso, rFiltros.IdTipoProducto, rFiltros.Nit, rFiltros.Producto))
    End Sub

   
End Class
