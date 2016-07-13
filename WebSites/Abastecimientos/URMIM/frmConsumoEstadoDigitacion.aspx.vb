Imports ABASTECIMIENTOS.NEGOCIO

Partial Class URMIM_frmConsumoEstadoDigitacion
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

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.btnAceptar.Enabled = True
        Me.btnCancelar.Enabled = False

        Me.cboMes.Enabled = True
        Me.cboAnio.Enabled = True

        Me.tdDatos.InnerHtml = ""

    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Me.cboAnio.SelectedIndex = 0 Or Me.cboMes.SelectedIndex = 0 Then Exit Sub

        Dim fecha As Date = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedItem.Value, 1)

        If fecha > New Date(Now.Year, Now.Month, 1) Then Exit Sub

        Dim idEstablecimiento As Integer = 0

        Me.btnAceptar.Enabled = False
        Me.btnCancelar.Enabled = True

        Me.cboMes.Enabled = False
        Me.cboAnio.Enabled = False

        Dim cEntidad As New cCONSUMOS

        Dim txtHTML As New StringBuilder

        Dim arrFilas As New ArrayList

        Dim arr As Array = cEntidad.obtenerCodigosCapturadosConsumo(fecha, arrFilas)

        txtHTML.Append("<table width=" & Chr(34) & "100%" & Chr(34) & " style=" & Chr(34) & "border: solid 1px #CCCCCC;" & Chr(34) & " cellspacing=" & Chr(34) & "0" & Chr(34) & ">" & vbNewLine)

        txtHTML.Append("<tr>" & vbNewLine)
        txtHTML.Append("<td align=" & Chr(34) & "center" & Chr(34) & " colspan=" & Chr(34) & "4" & Chr(34) & " style=" & Chr(34) & "background-color:#0066CC; color:#FFFFFF;border: solid 1px #CCCCCC;" & Chr(34) & "><b>Códigos Capturados - " & Me.cboMes.SelectedItem.Text & "/" & Me.cboAnio.SelectedItem.Text & "</b></td>")
        txtHTML.Append("</tr>" & vbNewLine)

        txtHTML.Append("<tr>" & vbNewLine)
        txtHTML.Append("<td width=" & Chr(34) & "70%" & Chr(34) & " align=" & Chr(34) & "left" & Chr(34) & " style=" & Chr(34) & "border: solid 1px #CCCCCC; background-color:#CCCCCC;" & Chr(34) & "><b>Hospital</b></td>")
        txtHTML.Append("<td width=" & Chr(34) & "10%" & Chr(34) & " align=" & Chr(34) & "right" & Chr(34) & " style=" & Chr(34) & "border: solid 1px #CCCCCC; background-color:#CCCCCC;" & Chr(34) & "><b>Almacén</b></td>")
        txtHTML.Append("<td width=" & Chr(34) & "10%" & Chr(34) & " align=" & Chr(34) & "right" & Chr(34) & " style=" & Chr(34) & "border: solid 1px #CCCCCC; background-color:#CCCCCC;" & Chr(34) & "><b>Farmacia</b></td>")
        txtHTML.Append("<td width=" & Chr(34) & "10%" & Chr(34) & " align=" & Chr(34) & "right" & Chr(34) & " style=" & Chr(34) & "border: solid 1px #CCCCCC; background-color:#CCCCCC;" & Chr(34) & "><b>Diferencia</b></td>")
        txtHTML.Append("</tr>" & vbNewLine)

        For i As Integer = 0 To arrFilas.Count - 1

            Dim color1 As String = "#FFFFFF"
            Dim color2 As String = "#FFFFFF"
            Dim color3 As String = "#FFFFFF"

            If arr(i, 0) = 0 Then color1 = "#FFFF00"
            If arr(i, 1) = 0 Then color2 = "#FFFF00"

            If (Math.Abs(arr(i, 1) - arr(i, 0)) > 7) Or ((arr(i, 0) + arr(i, 1)) = 0) Then color3 = "#FFFF00"

            txtHTML.Append("<tr>" & vbNewLine)
            txtHTML.Append("<td align=" & Chr(34) & "left" & Chr(34) & " style=" & Chr(34) & "border: solid 1px #CCCCCC;" & Chr(34) & ">" & arrFilas(i) & "</td>")
            txtHTML.Append("<td align=" & Chr(34) & "right" & Chr(34) & " style=" & Chr(34) & "border: solid 1px #CCCCCC; background-color:" & color1 & ";" & Chr(34) & ">" & arr(i, 0) & "</td>")
            txtHTML.Append("<td align=" & Chr(34) & "right" & Chr(34) & " style=" & Chr(34) & "border: solid 1px #CCCCCC; background-color:" & color2 & ";" & Chr(34) & ">" & arr(i, 1) & "</td>")
            txtHTML.Append("<td align=" & Chr(34) & "right" & Chr(34) & " style=" & Chr(34) & "border: solid 1px #CCCCCC; background-color:" & color3 & ";" & Chr(34) & ">" & Math.Abs(arr(i, 1) - arr(i, 0)) & "</td>")
            txtHTML.Append("</tr>" & vbNewLine)

        Next

        txtHTML.Append("</table>")

        Me.tdDatos.InnerHtml = txtHTML.ToString

    End Sub

End Class
