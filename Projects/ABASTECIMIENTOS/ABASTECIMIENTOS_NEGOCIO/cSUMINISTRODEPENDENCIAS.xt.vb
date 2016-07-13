Partial Public Class cSUMINISTRODEPENDENCIAS

#Region " Métodos Agregados"

    Public Function ObtenerDataSetListaSuministrosDependencias() As DataSet
        Try
            Return mDb.ObtenerDataSetListaSuministrosDependencias()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarConSqlException(ByVal IDSUMINISTRO As Int32, ByVal IDDEPENDENCIA As Int32) As Integer
        Try
            mEntidad.IDSUMINISTRO = IDSUMINISTRO
            mEntidad.IDDEPENDENCIA = IDDEPENDENCIA
            Return mDb.Eliminar(mEntidad)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function BuscarSuministrosDependencias(ByVal IDSUMINISTRO As Int32, ByVal IDDEPENDENCIA As Int32) As Boolean
        Try
            Return mDb.BuscarSuministrosDependencias(IDSUMINISTRO, IDDEPENDENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
