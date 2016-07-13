Partial Public Class cRECEPCIONOFERTAS

#Region "  Metodos Agregados  "

    Public Function ObtenerDataSet_OfertasRecibidas(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSet_OfertasRecibidas(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProveedoresNoAsignados(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerProveedoresNoAsignados(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerIDProveedor(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64, ByVal ORDENLLEGADA As Integer) As Integer
        Try
            Return mDb.ObtenerIDProveedor(IDPROCESOCOMPRA, IDESTABLECIMIENTO, ORDENLLEGADA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDescripcionRazon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obtenerDescripcionRazon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSet_OfertasRecibidasRpt(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSet_OfertasRecibidasRpt(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSet_OfertasRecibidas2(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSet_OfertasRecibidas2(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
