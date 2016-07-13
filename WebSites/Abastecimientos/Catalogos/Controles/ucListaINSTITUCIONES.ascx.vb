Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaINSTITUCIONES
    Inherits System.Web.UI.UserControl

    Private mComponente As New cINSTITUCIONES

    Public Function CargarDatos() As Integer

        Dim lINSTITUCIONES As listaINSTITUCIONES

        lINSTITUCIONES = Me.mComponente.ObtenerLista()

        Me.gvLista.DataSource = lINSTITUCIONES

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

End Class
