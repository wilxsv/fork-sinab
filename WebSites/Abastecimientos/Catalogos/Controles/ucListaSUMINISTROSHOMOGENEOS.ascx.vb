Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaSUMINISTROSHOMOGENEOS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cSUMINISTROSHOMOGENEOS

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Sub CargarDatos()

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerSuministrosHomogeneos()

        Me.gvLista.DataSource = ds

        Me.gvLista.DataBind()
    End Sub

    Private Sub gvLista_RowDeleting(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDSUMINISTRO, IDSUMINISTROHOMOGENEO As Integer
        IDSUMINISTRO = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDSUMINISTRO")
        IDSUMINISTROHOMOGENEO = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDSUMINISTROHOMOGENEO")

        If Me.mComponente.EliminarSUMINISTROSHOMOGENEOS(IDSUMINISTRO, IDSUMINISTROHOMOGENEO) <> 1 Then
            'Si se cometio un error
            MsgBox1.ShowAlert("Error al Eliminar Registro", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            e.Cancel = True
        End If

        Me.CargarDatos()

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

End Class
