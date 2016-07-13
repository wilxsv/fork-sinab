Partial Public Class cTIPOINFORMES

#Region " Metodos Agregados "

    'Funcion que toma el numero de error para verificar si es error de Integridad Referencial
    Public Function EliminarConSqlException(ByVal IDTIPOINFORME As Int32) As Integer
        Try
            mEntidad.IDTIPOINFORME = IDTIPOINFORME
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
