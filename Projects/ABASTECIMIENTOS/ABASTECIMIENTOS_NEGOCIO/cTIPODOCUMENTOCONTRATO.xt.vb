Partial Public Class cTIPODOCUMENTOCONTRATO

    'JOSE CHAVEZ
    Public Function ObtenerTipoDocumentoFiltrado(ByVal CLASIFICACION As Int16) As DataSet
        Try
            Return mDb.ObtenerTipoDocumentoFiltrado(CLASIFICACION)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    'JOSE CHAVEZ
    Public Function ObtenerTipoDocumentoPorID(ByVal IDTIPODOCUMENTO As Int16) As DataSet
        Try
            Return mDb.ObtenerTipoDocumentoPorID(IDTIPODOCUMENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarOrdenada() As DataSet
        Try
            Return mDb.RecuperarOrdenada
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
