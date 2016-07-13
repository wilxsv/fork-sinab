Partial Public Class cDEPENDENCIAS

#Region "Metodos adicionales"

    Public Function ObtenerListaOrden(ByVal Tipo As Integer) As listaDEPENDENCIAS
        Try
            Return mDb.ObtenerListaOrden(Tipo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ValidarNombre(ByVal NOMBRE As String, ByVal IDDEPENDENCIA As Int32) As Int16
        Try
            Return mDb.ValidarNombre(NOMBRE, IDDEPENDENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarDependenciasSQLException(ByVal IDDEPENDENCIA As Int32) As Integer
        Try
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

    Public Function ObtenerNOMDependencia(ByVal IDDEPENDENCIA As Integer) As String
        Try
            Return mDb.ObtenerNOMDEPENDENCIA(IDDEPENDENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerCodDependencia(ByVal IDDEPENDENCIA As Integer) As String
        Try
            Return mDb.ObtenerNOMDEPENDENCIA(IDDEPENDENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerdsDependencia() As DataSet
        Try
            Return mDb.ObtenerdsDependencia()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerdsAreaTecnica() As DataSet
        Try
            Return mDb.ObtenerdsAreaTecnica()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class
