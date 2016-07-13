Imports ABASTECIMIENTOS.NEGOCIO

Partial Class GERENCIA_frmConsumoEstadoDigitacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.ucBarraNavegacion1.Visible = False
            Me.Master.ControlMenu.Visible = False 'ocultar menu
            Me.lnkSalir.NavigateUrl = "~/FrmPrincipal.aspx"

            For i As Integer = 2009 To Now.Year
                Me.cboAnio.items.add(i)
            Next

        End If

    End Sub


    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Me.cboAnio.SelectedIndex = 0 Or Me.cboMes.SelectedIndex = 0 Then Exit Sub

        Dim fecha As Date = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedItem.Value, 1)

        If fecha > New Date(Now.Year, Now.Month, 1) Then Exit Sub

        Dim alerta As String = "/Reportes/frmRptCapturaCEHospital.aspx?fecha=" & Me.cboMes.SelectedItem.Value & "/" & Me.cboAnio.SelectedItem.Text
        SINAB_Utils.Utils.MostrarVentana(alerta)

    End Sub

End Class
