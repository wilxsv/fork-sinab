Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaNIVELESUSOESTABLECIMIENTOS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cNIVELESUSOESTABLECIMIENTOS

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerDataSetListaNivelesUsoEstablecimiento()

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Return 1

    End Function

    Private Sub gvLista_RowDeleting(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDESTABLECIMIENTO, IDNIVELUSO As Integer

        Dim row As GridViewRow = Me.gvLista.Rows(e.RowIndex)
        IDESTABLECIMIENTO = row.Cells(2).Text
        IDNIVELUSO = row.Cells(4).Text

        Dim result As Integer = Me.mComponente.EliminarConSqlException(IDESTABLECIMIENTO, IDNIVELUSO)

        Select Case result
            Case Is = 1
            Case Is = 547
                Me.MsgBox1.ShowAlert("El registro no puede ser eliminado porque es utilizado en otro proceso.", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                e.Cancel = True
            Case Else
                Me.MsgBox1.ShowAlert("Error al eliminar el registro", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                e.Cancel = True
        End Select

        If Me.CargarDatos() <> 1 Then
            MsgBox1.ShowAlert("Error al recuperar lista", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

End Class
