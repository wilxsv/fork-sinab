Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class UACI_CERTIFICACION_frmReporte5
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            With rFiltros
                .CargarDatos()
                .MostrarProducto = False
                .MostarEstado = False
                .FijarProveedor = true
            End With
        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim c As New cProcesoCP
        SINAB_Utils.Utils.MostrarVentana(String.Format("/UACI/CERTIFICACION/Reportes/FrmConstanciaRegistrados.aspx?idpc={0}&idtp={1}&nit={2}", rFiltros.IdProceso, rFiltros.IdTipoProducto, rFiltros.Nit))
        '  ds = c.ObtenerReporteCP5(Me.DropDownList2.SelectedValue, Me.DropDownList1.SelectedValue, IIf(Me.RadioButtonList1.SelectedValue = 0, 0, 1), IIf(Me.RadioButtonList2.SelectedValue = 0, 0, 1), IIf(Me.RadioButtonList1.SelectedValue = 1, Me.TextBox1.Text, "nohay"), IIf(Me.RadioButtonList2.SelectedValue = 1, Me.TextBox2.Text, "nohay"))

    End Sub
End Class
