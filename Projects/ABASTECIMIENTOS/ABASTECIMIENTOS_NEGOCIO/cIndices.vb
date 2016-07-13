Public Class cIndices
#Region " Privadas "
    Private mDb As New dbIndices
    'Private mEntidad As New COMISIONPROCESOCOMPRA
#End Region

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer, ByVal IDALMACEN As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.GET_INFO_INDICADORES_MR(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDALMACEN, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.GET_INFO_INDICADORES_MR(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
End Class
