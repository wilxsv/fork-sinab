Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaDEPARTAMENTOS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cDEPARTAMENTOS

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Dim lDEPARTAMENTOS As listaDEPARTAMENTOS

        lDEPARTAMENTOS = Me.mComponente.ObtenerLista()

        Me.gvLista.DataSource = lDEPARTAMENTOS

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Return 1

    End Function

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub LnkbPrimero_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.gvLista.PageIndex = 0
        Me.CargarDatos()
    End Sub

    Protected Sub LnkbUltimo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.gvLista.PageIndex = Me.gvLista.PageCount
        Me.CargarDatos()
    End Sub

    Protected Sub LnkbAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.gvLista.PageIndex > 0 Then
            Me.gvLista.PageIndex = Me.gvLista.PageIndex - 1
            Me.CargarDatos()
        End If
    End Sub

    Protected Sub LnkbSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.gvLista.PageIndex < Me.gvLista.PageCount Then
            Me.gvLista.PageIndex = Me.gvLista.PageIndex + 1
            Me.CargarDatos()
        End If
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDDEPARTAMENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)

        If Me.mComponente.EliminarDEPARTAMENTOS(IDDEPARTAMENTO) <> 1 Then
            'Si se cometio un error
            MsgBox1.ShowAlert("Error al Eliminar Registro", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            e.Cancel = True
        Else
            If Me.CargarDatos() <> 1 Then
                MsgBox1.ShowAlert("Error al Recuperar Lista", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If
        End If

    End Sub

End Class
