
Partial Class FrmMantDesiertosNoAdjudicados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estados As Integer() = {5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17}
        Me.UcDesiertosNoAdjudicados1.ESTADOS = estados
        Me.UcDesiertosNoAdjudicados1.EVAL_FEC_REC = False
        Me.UcDesiertosNoAdjudicados1.EVAL_FEC_RET = False
        Me.UcDesiertosNoAdjudicados1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcDesiertosNoAdjudicados1.PaginaRedirect = "~/Reportes/FrmRptDesiertosNoAdjudicados.aspx"
        Me.UcDesiertosNoAdjudicados1.Consultar()

        Me.Master.ControlMenu.Visible = False
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
