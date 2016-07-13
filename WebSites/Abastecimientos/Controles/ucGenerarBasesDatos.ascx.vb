
Partial Class Controles_ucGenerarBasesDatos
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.pnlPaso1.Visible = True
    End Sub

    Protected Sub lbSiguiente1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSiguiente1.Click
        Me.pnlPaso1.Visible = False
        Me.pnlPaso2.Visible = True
    End Sub

    Protected Sub lbBack1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbBack1.Click
        Me.pnlPaso1.Visible = True
        Me.pnlPaso2.Visible = False
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.pnlPaso2.Visible = False
        Me.pnlPaso3.Visible = True
    End Sub

    Protected Sub LinkButton9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton9.Click
        Me.pnlPaso2.Visible = True
        Me.pnlPaso3.Visible = False
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Me.pnlPaso3.Visible = False
        Me.pnlPaso4.Visible = True
    End Sub

    Protected Sub LinkButton10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton10.Click
        Me.pnlPaso3.Visible = True
        Me.pnlPaso4.Visible = False
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Me.pnlPaso4.Visible = False
        Me.pnlPaso5.Visible = True
    End Sub

    Protected Sub LinkButton11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton11.Click
        Me.pnlPaso4.Visible = True
        Me.pnlPaso5.Visible = False
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        Me.pnlPaso5.Visible = False
        Me.pnlPaso6.Visible = True
    End Sub

    Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton12.Click
        Me.pnlPaso5.Visible = True
        Me.pnlPaso6.Visible = False
    End Sub

    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        Me.pnlPaso6.Visible = False
        Me.pnlPaso7.Visible = True
    End Sub

    Protected Sub LinkButton13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton13.Click
        Me.pnlPaso6.Visible = True
        Me.pnlPaso7.Visible = False
    End Sub

    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
        Me.pnlPaso7.Visible = False
        Me.pnlPaso8.Visible = True
    End Sub
End Class
