Partial Public Class cREPRESENTANTEAPERTURAPROCESOS

    Public Function ObtenerRepresentantes(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Return mDb.ObtenerRepresentantes(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

    End Function

    Public Function EliminarTodos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer
        Try
            Return mDb.EliminarTodos(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

End Class
