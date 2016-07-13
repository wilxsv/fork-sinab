Partial Public Class cNIVELESUSOESTABLECIMIENTOS

#Region "metodos agregados"

    Public Function DevolverEstablecimientos(ByVal IDNIVELUSO As Integer) As DataSet
        Try
            Return mDb.DevolverEstablecimientos(IDNIVELUSO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetListaNivelesUsoEstablecimiento() As DataSet
        Try
            Return mDb.ObtenerDataSetListaNivelesUsoEstablecimiento()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarConSqlException(ByVal IDNIVELUSO As Int32, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            mEntidad.IDNIVELUSO = IDNIVELUSO
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function BuscarNivelUsoEstablecimiento(ByVal IDEstablecimiento As Int32, ByVal IDNiveUso As Int32) As Boolean
        Try
            Return mDb.BuscarNivelUsoEstablecimiento(IDEstablecimiento, IDNiveUso)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
