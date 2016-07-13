Partial Public Class cEXISTENCIASALMACENES

#Region " Métodos Agregados "

    Public Function obtenerDsDatosProducto(ByVal IDPRODUCTO As Int64) As DataSet
        Try
            Return mDb.obtenerDsDatosProducto(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDsDatosProductoxCODIGO(ByVal IDALMACEN As Integer, ByVal CODIGOPRODUCTO As String) As DataSet
        Try
            Return mDb.ObtenerDsDatosProductoxCODIGO(IDALMACEN, CODIGOPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
