
Partial Class FrmGenerarValorizacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False
        Dim cad = "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc")
        Me.btnInformeEvaluacionPorOferta.Attributes.Add("onclick", SINAB_Utils.Utils.ReferirVentana(cad))

        cad = "/Reportes/FrmRptValorizacionPorRenglon.aspx?id=" + Request.QueryString("idProc")
        Me.btnInformeEvaluacionPorRenglon.Attributes.Add("onclick", SINAB_Utils.Utils.ReferirVentana(cad))

        'Me.btnInformeEvaluacionPorOferta.Attributes.Add("onclick", "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');")
        'Me.btnInformeEvaluacionPorRenglon.Attributes.Add("onclick", "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValorizacionPorRenglon.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');")

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
