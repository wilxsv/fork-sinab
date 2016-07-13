Partial Public Class cMENSAJES

#Region " METODOS AGREGADOS "

    Public Function FiltroMensajePorId(ByVal BID As String) As DataSet
        Try
            Return mDb.FiltroMensajePorId(BID)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarMensajeConSqlException(ByVal IDmensaje As Int32) As Integer
        Try
            mEntidad.IDMENSAJE = IDmensaje
            Return mDb.Eliminar(mEntidad)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerListaOrden(Optional ByVal Tipo As Integer = 0) As listaMENSAJES
        Try
            Return mDb.ObtenerListaOrden(Tipo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarOrdenada() As DataSet
        Try
            Return mDb.RecuperarOrdenada()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetListaMensajes() As DataSet
        Try
            Return mDb.ObtenerDataSetListaMensajes()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetListaMensajesInicio() As DataSet
        Try
            Return mDb.ObtenerDataSetListaMensajesInicio()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
