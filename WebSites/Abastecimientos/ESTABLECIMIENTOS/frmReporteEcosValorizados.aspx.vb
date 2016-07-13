
Partial Class ESTABLECIMIENTOS_frmReporteEcosValorizados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim currentYear = DateTime.Now.Year

            For y As Integer = initYear To currentYear
                ddlYears.Items.Add(New ListItem(y.ToString(), y.ToString()))
            Next
            ddlYears.DataBind()
        End If
    End Sub
    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'redirecciona a la pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        SINAB_Utils.Utils.MostrarVentana(String.Format("/Reportes/FrmRptReporteEcosValorizados.aspx?R={0}&M={1}&A={2}", DropDownList1.SelectedValue, DropDownList2.SelectedValue, ddlYears.SelectedValue))
    End Sub

    Const InitYear As Integer = 2010
End Class
