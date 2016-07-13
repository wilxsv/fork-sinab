Partial Public Class cCLAUSULAS

    Public Function ObtenerDataSetPorId(ByVal IDCLAUSULA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDCLAUSULA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorTipoModificativa(ByVal IDTIPOCOMPRA As Integer, ByVal MODIFICATIVA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorTipoModificativa(IDTIPOCOMPRA, MODIFICATIVA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorModalidad(ByVal IDMODALIDADCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorModalidad(IDMODALIDADCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
