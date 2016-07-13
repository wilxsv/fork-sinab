Partial Class cDEPENDENCIAESTABLECIMIENTOS

    Public Function ObtenerDependenciaEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.obtenerDependenciaEstablecimiento(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetListaDependenciaEstablecimiento() As DataSet
        Try
            Return mDb.ObtenerDataSetListaDependenciaEstablecimiento()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarEstablecimientoDependencia(ByVal IDESTABLECIMIENTO As Int32, ByVal IDDEPENDENCIA As Int32) As Boolean
        Try
            Return mDb.BuscarEstablecimientoDependencia(IDESTABLECIMIENTO, IDDEPENDENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
