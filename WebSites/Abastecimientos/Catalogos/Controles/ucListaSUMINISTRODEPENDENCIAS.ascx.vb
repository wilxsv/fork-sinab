Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaSUMINISTRODEPENDENCIAS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cSUMINISTRODEPENDENCIAS

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerDataSetListaSuministrosDependencias()

        Me.gvLista.DataSource = ds
        Me.gvLista.DataBind()

        Return 1

    End Function

    Private Sub gvLista_RowDeleting(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim XIDDEPEPNDECIA As Integer
        Dim XIDSUMINISTRO As Integer

        Dim row As GridViewRow = Me.gvLista.Rows(e.RowIndex)
        XIDDEPEPNDECIA = row.Cells(2).Text
        XIDSUMINISTRO = row.Cells(4).Text

        Dim result As Integer = Me.mComponente.EliminarConSqlException(XIDSUMINISTRO, XIDDEPEPNDECIA)

        Select Case result
            Case Is = 1
            Case Is = 547
                Me.MsgBox1.ShowAlert("El Registro no puede ser eliminado porque el Dato es usado en otro Proceso ", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                e.Cancel = True
            Case Else
                Me.MsgBox1.ShowAlert("Error al Eliminar Registro", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                e.Cancel = True
        End Select

        If Me.CargarDatos() <> 1 Then
            MsgBox1.ShowAlert("Error al Recuperar Lista", "Alerta", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

End Class
