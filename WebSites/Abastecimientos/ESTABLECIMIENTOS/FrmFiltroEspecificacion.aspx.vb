
Partial Class ESTABLECIMIENTOS_FrmFiltroEspecificacion
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.RadioButtonList1.SelectedValue = 1 Then
            If Request.QueryString("t") = "Individual" Or Request.QueryString("t") = "uaci" Then
                Response.Redirect("~/Reportes/FrmRptSolicitudCompra.aspx?id=" & Request.QueryString("id") & "ide")
            Else
                Response.Redirect("~/Reportes/FrmRptSolicitudCompraxDependencia.aspx?id=" & Request.QueryString("id"))
            End If
        Else
            If Request.QueryString("t") = "Individual" Or Request.QueryString("t") = "uaci" Then
                Response.Redirect("~/Reportes/FrmRptSolicitudCompra.aspx?id=" & Request.QueryString("id") & "&esp=1")
            Else
                Response.Redirect("~/Reportes/FrmRptSolicitudCompraxDependencia.aspx?id=" & Request.QueryString("id") & "&esp=1")
            End If
        End If

        
    End Sub
End Class
