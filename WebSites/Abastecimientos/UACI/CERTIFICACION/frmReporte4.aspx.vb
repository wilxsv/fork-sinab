Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class UACI_CERTIFICACION_frmReporte4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            rFiltros.CargarDatos()
            rFiltros.MostarEstado = False
            rFiltros.MostrarProducto = False
            rFiltros.MostarFechaLimite = True
        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

  

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        SINAB_Utils.Utils.MostrarVentana(String.Format("/UACI/CERTIFICACION/Reportes/FrmProximosVencer.aspx?idpc={0}&idtp={1}&nit={2}&fecha={3}", rFiltros.IdProceso, rFiltros.IdTipoProducto, rFiltros.Nit, rFiltros.FechaLimite))
        ' ds = c.ObtenerReporteCP4(Me.DropDownList2.SelectedValue, Me.DropDownList1.SelectedValue, 0, IIf(Me.RadioButtonList1.SelectedValue = 1, Me.TextBox1.Text, "nohay"), Me.TextBox2.Text)
    End Sub
End Class
