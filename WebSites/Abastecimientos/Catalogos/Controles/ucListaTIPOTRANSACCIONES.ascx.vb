Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaTIPOtrANSACCIONES
    Inherits System.Web.UI.UserControl

    Private mComponente As New cTIPOTRANSACCIONES

    Public Function CargarDatos() As Integer

        Dim lista As listaTIPOTRANSACCIONES

        lista = Me.mComponente.ObtenerLista()

        Me.gvLista.DataSource = lista

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

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        Try

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lbl As Label
                lbl = e.Row.FindControl("lblAFECTAINVENTARIO")

                Dim AFECTAINVENTARIO As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Values.Item("AFECTAINVENTARIO")

                Select Case AFECTAINVENTARIO
                    Case Is > 0
                        lbl.Text = "Aumenta (+)"
                    Case 0
                        lbl.Text = "No afecta"
                    Case Is < 0
                        lbl.Text = "Disminuye (-)"
                End Select
            End If
        Catch ex As Exception
            Dim s As String = ex.Message
        End Try

    End Sub

End Class
