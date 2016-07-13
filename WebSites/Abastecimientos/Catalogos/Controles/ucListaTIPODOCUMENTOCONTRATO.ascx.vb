Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaTIPODOCUMENTOCONTRATO
    Inherits System.Web.UI.UserControl

    Private mComponente As New cTIPODOCUMENTOCONTRATO

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Me.gvLista.DataSource = Me.mComponente.ObtenerLista()

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Return 1

    End Function

    Private Sub gvLista_RowDeleting(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDTIPODOCUMENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)

        Dim result As Integer = Me.mComponente.EliminarTIPODOCUMENTOCONTRATO(IDTIPODOCUMENTO)

        Select Case result
            Case Is = 1
            Case Is = 547
                Me.MsgBox1.ShowAlert("El registro no puede ser borrado porque el dato es usado en otro proceso", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                e.Cancel = True
            Case Else
                Me.MsgBox1.ShowAlert("Error al Eliminar Registro", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                e.Cancel = True
        End Select

        If Me.CargarDatos() <> 1 Then
            MsgBox1.ShowAlert("Error al Recuperar Lista", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

End Class
