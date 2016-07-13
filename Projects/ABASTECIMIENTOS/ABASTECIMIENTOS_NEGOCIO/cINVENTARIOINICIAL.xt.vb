Partial Public Class cINVENTARIOINICIAL
    Inherits controladorBase

#Region "Metodos Adicionales"

    Public Function ObtenerInventariosPorAlmacen(ByVal IDALMACEN As Int32, ByVal ESTACERRADO As Byte) As DataSet
        Try
            Return mDb.ObtenerInventariosPorAlmacen(IDALMACEN, ESTACERRADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarInventarioDetalle(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As Integer
        Try
            Return mDb.EliminarInventarioDetalle(IDALMACEN, IDINVENTARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
