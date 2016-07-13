Partial Class dsExistenciasAlmacenes
    Partial Class ExistenciasAlmacenesDataTable

        Private Sub ExistenciasAlmacenesDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.CODIGOColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
