Partial Public Class cCRITERIOSPLANTILLAS

#Region "  Metodos Agregados  "

    Public Function ObtenerDataSetCriteroPlanilla(ByVal IDPLANTILLA As Int32, ByVal IDTIPOCRITERIO As Int16, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetCriteroPlanilla(IDPLANTILLA, IDTIPOCRITERIO, IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetporCriteroPlanilla(ByVal IDPLANTILLA As Int32, ByVal IDTIPOCRITERIO As Int64, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCRITERIOEVALUACION As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetporCriteroPlanilla(IDPLANTILLA, IDTIPOCRITERIO, IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCRITERIOEVALUACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function eliminaPorPlantilla(ByVal IDPLANTILLA As Int32) As Integer
        Try
            mEntidad.IDPLANTILLA = IDPLANTILLA
            Return mDb.EliminarPorPlantilla(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
