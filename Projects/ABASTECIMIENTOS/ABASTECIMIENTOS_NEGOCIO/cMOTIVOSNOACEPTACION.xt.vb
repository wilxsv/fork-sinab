Partial Public Class cMOTIVOSNOACEPTACION

#Region " Metodos Agregados "

    Public Function BuscarDescripcion(ByVal DESCRIPCION As String, ByVal IDMOTIVONOACEPTACION As Byte) As Boolean
        Try
            Return mDb.BuscarDescripcion(DESCRIPCION, IDMOTIVONOACEPTACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    Public Function EliminarMOTIVOSNOACEPTACIONSQLException(ByVal IDMOTIVONOACEPTACION As Int16) As Integer
        Try
            mEntidad.IDMOTIVONOACEPTACION = IDMOTIVONOACEPTACION
            Return mDb.Eliminar(mEntidad)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
