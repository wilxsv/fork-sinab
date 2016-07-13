Partial Class cMODALIDADESCOMPRA

    Public Function obtenerModalidadCompra(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.obtenerModalidadCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerModalidadPorID(ByVal IDMODALIDADCOMPRA As Int32) As DataSet
        'JOSE CHAVEZ
        Return mDb.ObtenerModalidadPorID(IDMODALIDADCOMPRA)
    End Function

End Class
