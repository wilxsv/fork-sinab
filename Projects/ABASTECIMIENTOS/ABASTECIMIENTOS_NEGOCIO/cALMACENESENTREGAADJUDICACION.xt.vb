Partial Public Class cALMACENESENTREGAADJUDICACION

    Public Function obtenerAlmacenesAdjudicacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obtenerAlmacenesAdjudicacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDistribucionProducto(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDALMACEN As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obtenerDistribucionProducto(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDALMACEN, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarCantidadxAlmacenxProveedorxRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal IDENTREGA As Integer, ByVal IDALMACEN As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal CANTIDAD As Integer) As Integer
        Try
            Return mDb.ActualizarCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, IDENTREGA, IDALMACEN, IDFUENTEFINANCIAMIENTO, CANTIDAD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerSumatoriaxProveedorxRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As Integer
        Try
            Return mDb.obtenerSumatoriaxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerCantidadxAlmacenxProveedorxRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obtenerCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
End Class
