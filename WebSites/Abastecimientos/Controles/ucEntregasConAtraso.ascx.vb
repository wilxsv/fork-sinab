'Comunicar incumplimientos de contrato
'CU-UACI023
'Ing. Yessenia Pennelope Henriquez Duran
'entregas con atraso
Imports System.Data
Partial Class Controles_ucEntregasConAtraso
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property ESTADOENTREGA() As Label
        Get
            Return Me.estado
        End Get
    End Property
    Public Sub LlenarGridEntregaConAtraso(ByVal dsentrega As DataSet)
        'carga el grid de entregas con atraso
        Me.lblTitulo.Visible = True

        If dsentrega.Container Is Nothing Then
            Me.lblTitulo.Visible = True
            Me.estado.Text = True
        Else
            Me.dgLista1.DataSource = dsentrega

            Try
                Me.dgLista1.DataBind()
            Catch ex As Exception
                Me.dgLista1.CurrentPageIndex = 0 'error pagineo
                Me.dgLista1.DataBind()
            End Try
            Me.lblTitulo.Visible = False
            Me.estado.Text = False
        End If
    End Sub

    Protected Sub dgLista1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista1.ItemDataBound
        'al cargar registros del grid
        Dim precio As Label = CType(e.Item.FindControl("lblprecio"), Label)
        Dim cantidad As Label = CType(e.Item.FindControl("lblcant"), Label)
        Dim monto As Double
        monto = cantidad.Text * precio.Text
        CType(e.Item.FindControl("LblMonto"), Label).Text = monto
    End Sub
End Class
