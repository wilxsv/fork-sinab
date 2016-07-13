Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaGRUPOS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cGRUPOS

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Me.gvLista.DataSource = Me.mComponente.ObtenerListaConSuministro()

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Return 1

    End Function

    Private Sub gvLista_RowDeleting(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDGRUPO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values("IDGRUPO").ToString

        If Me.mComponente.EliminarGRUPOS(IDGRUPO) <> 1 Then
            'Si se cometio un error
            MsgBox1.ShowAlert("Error al Eliminar Registro", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            e.Cancel = True
        Else
            If Me.CargarDatos() <> 1 Then
                MsgBox1.ShowAlert("Error al Recuperar Lista", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If
        End If

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        Me.ddlSUMINISTROS1.RecuperarListaFiltrada(1)


        'Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
        'Dim IDGRUPO As Integer
        'If Me.ddlGRUPOS1.Items.Count = 0 Then
        '    Me.ddlGRUPOS1.Visible = False
        'Else
        '    IDGRUPO = Me.ddlGRUPOS1.SelectedValue
        '    Me.ddlGRUPOS1.Visible = True
        'End If
        'Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(IDGRUPO)
        'If Me.ddlSUBGRUPOS1.Items.Count = 0 Then
        '    Me.ddlSUBGRUPOS1.Visible = False
        'Else
        '    Me.ddlSUBGRUPOS1.Visible = True
        'End If
        'CargarProductos()
    End Sub
End Class
