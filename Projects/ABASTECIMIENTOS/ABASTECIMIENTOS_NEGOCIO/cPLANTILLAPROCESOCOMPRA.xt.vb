Partial Class cPLANTILLAPROCESOCOMPRA

    Public Function obtenerPlantillaProcesoCompra(ByVal IDTIPOCOMPRA As Int32) As DataSet
        Try
            Return mDb.obtenerPlantillaProcesoCompra(IDTIPOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerPlantillaProcesoCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerPlantillaProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
