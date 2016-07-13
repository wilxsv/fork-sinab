Partial Public Class cTIPOCRITERIO

    Public Function ObtenerDataSetPorIdxTIPO(ByVal IDTIPOCRITERIO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorIDxTIPO(IDTIPOCRITERIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
