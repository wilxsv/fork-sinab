Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaDEPENDENCIAESTABLECIMIENTOS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cDEPENDENCIAESTABLECIMIENTOS

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerDataSetListaDependenciaEstablecimiento()

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

        Dim XIDESTABLECIMIENTO As Integer
        Dim XIDDEPENDENCIA As Integer

        Dim row As GridViewRow = Me.gvLista.Rows(e.RowIndex)
        XIDESTABLECIMIENTO = row.Cells(1).Text
        XIDDEPENDENCIA = row.Cells(3).Text

        If Me.mComponente.EliminarDEPENDENCIAESTABLECIMIENTOS(XIDESTABLECIMIENTO, XIDDEPENDENCIA) <> 1 Then
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

    Protected Sub ucFiltrarDatos1_Buscar() Handles ucFiltrarDatos1.Buscar
        CargarDatos()
    End Sub

End Class
