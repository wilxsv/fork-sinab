Partial Public Class cNIVELESUSO

    Public Function ObtenerDescripcionNU(ByVal idniveluso As Integer) As DataSet
        Try
            Return mDb.ObtenerDescripcionNU(idniveluso)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Validar si un nombre corto ya existe
    '04/01/07 Responsable SONIA MARIBEL VIANA
    Public Function BuscarNOMBRE(ByVal NOMBRECORTO As String, ByVal IDNIVELUSO As Byte) As Int16
        Try
            Return mDb.BuscarNOMBRE(NOMBRECORTO, IDNIVELUSO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Funcion que toma el numero de error para verificar si es error de Integridad Referencial

    Public Function EliminarConSqlException(ByVal IDNIVELUSO As Int32) As Integer
        Try
            mEntidad.IDNIVELUSO = IDNIVELUSO
            Return mDb.Eliminar(mEntidad)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

End Class
