Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaZONAS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cZONAS

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Dim lZONAS As listaZONAS

        lZONAS = Me.mComponente.ObtenerLista()
        Me.gvLista.DataSource = lZONAS

        Me.gvLista.DataBind()
        Return 1

    End Function

    Private Sub gvLista_RowDeleting(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDZONA As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)

        If Me.mComponente.EliminarZONAS(IDZONA) <> 1 Then
            'Si se cometio un error
            MsgBox1.ShowAlert("Error al Eliminar Registro", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
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

End Class
