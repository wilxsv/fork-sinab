Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaCLAUSULAS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cCLAUSULAS

    Private _IDMODALIDADCOMPRA As Integer
    Public Property IDMODALIDADCOMPRA() As Integer
        Get
            Return _IDMODALIDADCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDMODALIDADCOMPRA = value
            If Not Me.ViewState("IDMODALIDADCOMPRA") Is Nothing Then Me.ViewState.Remove("IDMODALIDADCOMPRA")
            Me.ViewState.Add("IDMODALIDADCOMPRA", value)
        End Set
    End Property

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerDataSetPorModalidad(IDMODALIDADCOMPRA)

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

        Dim IDCLAUSULA As Integer = Me.gvLista.Rows(e.RowIndex).Cells(1).Text

        If Me.mComponente.EliminarCLAUSULAS(IDCLAUSULA) <> 1 Then
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.ViewState("IDMODALIDADCOMPRA") Is Nothing Then Me._IDMODALIDADCOMPRA = Me.ViewState("IDMODALIDADCOMPRA")
    End Sub

End Class
