Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaPRODUCTOSPROGRAMAS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cPRODUCTOSPROGRAMAS

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerDataSetListaProductosProgramas()

        If ucFiltrarDatos1.CampoFiltro <> "" And ucFiltrarDatos1.ValorFiltro <> "" Then
            Try
                Select Case ds.Tables(0).Columns(ucFiltrarDatos1.CampoFiltro).DataType.Name
                    Case "String"
                        ds.Tables(0).DefaultView.RowFilter = ucFiltrarDatos1.CampoFiltro & " LIKE '%" & ucFiltrarDatos1.ValorFiltro & "%'"
                    Case "DateTime"
                        ds.Tables(0).DefaultView.RowFilter = ucFiltrarDatos1.CampoFiltro & " = '" & ucFiltrarDatos1.ValorFiltro & "'"
                    Case Else
                        ds.Tables(0).DefaultView.RowFilter = ucFiltrarDatos1.CampoFiltro & " = " & ucFiltrarDatos1.ValorFiltro
                End Select
            Catch ex As Exception
            End Try
        End If

        Me.gvLista.DataSource = ds.Tables(0).DefaultView

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        If Not Page.IsPostBack Then ucFiltrarDatos1.ValorColumnas = gvLista.Columns

        Return 1

    End Function

    Private Sub gvLista_RowDeleting(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDPRODUCTO, IDPROGRAMA As Integer

        IDPRODUCTO = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        IDPROGRAMA = Me.gvLista.DataKeys(e.RowIndex).Values(1)

        Dim result As Integer = Me.mComponente.EliminarConSqlException(IDPRODUCTO, IDPROGRAMA)

        Select Case result
            Case Is = 1
                If Me.CargarDatos() <> 1 Then
                    MsgBox1.ShowAlert("Error al recuperar lista", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                End If
            Case Is = 547
                Me.MsgBox1.ShowAlert("El registro no puede ser eliminado porque es utilizado en otro proceso.", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                e.Cancel = True
            Case Else
                Me.MsgBox1.ShowAlert("Error al eliminar el registro", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                e.Cancel = True
        End Select

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub ucFiltrarDatos1_Buscar() Handles ucFiltrarDatos1.Buscar
        CargarDatos()
    End Sub

End Class
