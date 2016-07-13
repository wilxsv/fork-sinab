Partial Public Class cTIPODOCUMENTOREFERENCIAS

    Public Function BuscarDescripcion(ByVal DESCRIPCION As String) As Int16
        Try
            Return mDb.BuscarDescripcion(DESCRIPCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
