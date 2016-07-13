Partial Public Class cMODIFICATIVASCONTRATOPRODUCTO

#Region " Metodos Agregados "

    Public Function obtenerCantidadModificativa(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet
        Return mDb.obtenerCantidadModificativa(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
    End Function

    Public Function obtenerProductoModificativa(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMODIFICATIVA As Integer) As DataSet
        Return mDb.obtenerProductoModificativa(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMODIFICATIVA)
    End Function

    Public Function obtenerDetalleEntregaModificativa(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer)
        Return mDb.obtenerDetalleEntregaModificativa(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
    End Function

    Public Function ObtenerModificativas(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, Optional ByVal RENGLON As Int64 = 0) As String
        Try
            Return mDb.ObtenerModificativas(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

#End Region

End Class
