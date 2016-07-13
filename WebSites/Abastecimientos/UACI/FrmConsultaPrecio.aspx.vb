
Partial Class UACI_FrmConsultaPrecio
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim x As New ABASTECIMIENTOS.NEGOCIO.cCATALOGOPRODUCTOS
        If Me.TextBox1.Text <> "" Then
            Dim i As Integer = 0
            i = x.DevolverIDProducto(Me.TextBox1.Text)
            If i = 0 Then
                Me.Label5.Text = "No existe este producto en el catálogo de productos."
                Exit Sub
            Else
                Me.Label7.Visible = True
                Me.Label8.Visible = True
                Me.Label9.Visible = True

                Me.Label5.Text = ""
                Me.Label1.Text = TextBox1.Text
                Me.Label2.Text = x.DevolverNombreProducto(i)
                Me.Label3.Text = x.DevolverUMProducto(i)

                'cargar grid



                Me.GridView1.DataSource = x.ObtenerPreciosHistoricosUACI(Me.TextBox1.Text)
                Me.GridView1.DataBind()
                Me.Label4.Visible = False
                Me.Label6.Visible = False
                Me.TextBox1.Text = ""
            End If
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Me.Label4.Text = Me.GridView1.DataKeys(e.NewSelectedIndex).Values.Item("DESCRIPCION_PROVEEDOR")
        Me.Label4.Visible = True
        Me.Label6.Visible = True

    End Sub
End Class
