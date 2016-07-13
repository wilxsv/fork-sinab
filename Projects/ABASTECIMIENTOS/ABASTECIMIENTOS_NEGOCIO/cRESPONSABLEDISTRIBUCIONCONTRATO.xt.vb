Partial Public Class cRESPONSABLEDISTRIBUCIONCONTRATO

    Public Function ObtenerResponsablesPorContratoDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int64, ByVal IDCONTRATO As Int64) As DataSet
        Try
            Return mDb.ObtenerResponsablesPorContratoDS(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'JOSE CHAVEZ
    Public Function EliminarAsociados(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As Integer
        Try
            Return mDb.EliminarAsociados(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerResponsablesDistribucion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerResponsablesDistribucion(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerResponsablesIngresados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer) As DataSet
        Try
            Return mDb.obtenerResponsablesIngresados(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDRESPONSABLEDISTRIBUCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerResponsablesDistribucion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As String
        Try
            Return mDb.obtenerResponsablesDistribucion(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
