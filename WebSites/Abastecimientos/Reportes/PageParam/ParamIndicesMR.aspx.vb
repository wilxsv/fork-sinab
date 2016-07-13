Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Partial Class Reportes_PageParam_ParamIndicesMR
    Inherits System.Web.UI.Page

    Protected Sub btnInforme_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInforme.Click
        Response.Redirect("~/Reportes/Visores/frmIndicesMR.aspx?IDP=" & ddlProveedor.SelectedValue & "&IDA=" & ddlAlmacen.SelectedValue & "&IDE=" & 619 & "&IDPC=" & ddlProcesoCompra.SelectedValue & "&IDC=" & ddlContrato.SelectedValue & "&MUT=" & rbtnResumen.Checked)
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack Then
            EsconderBotonInforme()
        End If
    End Sub

    Protected Sub ddlAlmacen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAlmacen.SelectedIndexChanged
        EsconderBotonInforme()
    End Sub
    Private Sub EsconderBotonInforme()
        If Not ddlAlmacen.SelectedValue = "" Then
            btnInforme.Visible = True
        Else
            btnInforme.Visible = False
        End If
    End Sub
End Class
