Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaSERVICIOSHOSPITALARIOS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cSERVICIOSHOSPITALARIOS

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerDataSetListaServiciosHospitalarios()

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

        Dim IDESTABLECIMIENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDSERVICIOHOSPITALARIO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)

        If Me.mComponente.EliminarSERVICIOSHOSPITALARIOS(IDESTABLECIMIENTO, IDSERVICIOHOSPITALARIO) <> 1 Then
            'Si se cometio un error
            MsgBox1.ShowAlert("El registro no´puede ser eliminado porque existen recetas asociadas", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
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

End Class
