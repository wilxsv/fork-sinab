Partial Public Class cUBICACIONESPRODUCTOS

#Region " Métodos Agregados "

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDUBICACION As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDPRODUCTO, IDUBICACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDUBICACION As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDPRODUCTO, IDUBICACION, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarUBICACIONESPRODUCTOS(ByVal aEntidad As UBICACIONESPRODUCTOS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDsUbicacionProducto(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDLOTES As Int32) As DataSet
        Try
            Return mDb.ObtenerDsUbicacionProducto(IDALMACEN, IDPRODUCTO, IDLOTES)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
