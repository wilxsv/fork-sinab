Partial Public Class cCRITERIOSEVALUACION

#Region "  Metodos Agregados  "

    Public Function ObtenerDataSetPorTipoCriterio(ByVal IDTIPOCRITERIO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorTipoCriterio(IDTIPOCRITERIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetxTipoCriterio(ByVal IDTIPOCRITERIO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetXTipoCriterio(IDTIPOCRITERIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetListaCriteriosEvaluacion(Optional ByVal EsLG As Boolean = False) As DataSet
        Try
            Return mDb.ObtenerDataSetListaCriteriosEvaluacion(EsLG)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarConSqlException(ByVal IDCRITERIOEVALUACION As Int32) As Integer
        Try
            mEntidad.IDCRITERIOEVALUACION = IDCRITERIOEVALUACION
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
