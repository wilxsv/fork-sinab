
Partial Class Controles_WebUserControl
    Inherits System.Web.UI.UserControl

    Protected Sub btnSubirBase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubirBase.Click

        Dim contrato, directorio As String
        contrato = "B" & Me.ViewState("codigoLicita")

        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & Session("IdProcesoCompra")

        If fuSubirBase.HasFile Then
            Try
                fuSubirBase.SaveAs(Server.MapPath(directorio & "\BASES\" & fuSubirBase.FileName))
                Label1.Text = "File name: " & _
                   fuSubirBase.PostedFile.FileName & "<br>" & _
                   "File Size: " & _
                   fuSubirBase.PostedFile.ContentLength & " kb<br>" & _
                   "Content type: " & _
                   fuSubirBase.PostedFile.ContentType
                'btnLiberaContrato.Visible = True
                Me.MsgBox1.ShowAlert("El archivo se cargó satisfactoriamente", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                'Me.lblCargaArchivo.Text = "El archivo se cargó satisfactoriamente"
                'lblCargaArchivo.ForeColor = Drawing.Color.Red
                'Me.Label1.Visible = True
                'Me.Label1.Text = "El contrato fue liberado satisfactoriamente, desde este momento solo podrá realizar consultas al contrato generado."
            Catch ex As Exception
                Me.MsgBox1.ShowAlert("ERROR: El Archivo no se cargo Satisfactoriamente", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                'Me.lblCargaArchivo.Text = "ERROR: " & ex.Message.ToString()
            End Try
        Else
            'lblCargaArchivo.ForeColor = Drawing.Color.Black
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim codigoLicita As String
        'codigoLicita = "1234"
        'Session("codigoLicita") = codigoLicita
        'Session("IdEstablecimiento") = "619"
    End Sub

End Class
