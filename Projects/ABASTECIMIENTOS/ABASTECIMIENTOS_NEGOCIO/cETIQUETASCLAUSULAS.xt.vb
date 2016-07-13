Partial Public Class cETIQUETASCLAUSULAS

    Public Function ObtenerDataSetPorTipo(ByVal tipo As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorTipo(tipo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
