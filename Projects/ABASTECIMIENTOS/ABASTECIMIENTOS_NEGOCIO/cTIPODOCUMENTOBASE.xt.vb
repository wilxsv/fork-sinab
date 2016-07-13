Partial Public Class cTIPODOCUMENTOBASE

    Public Function BuscarTipoDocuentoBaseEnDocumentoBase(ByVal IDTIPODOCUEMENTO As Int32) As Boolean
        Try
            Return mDb.BuscarTipoDocuentoBaseEnDocumentoBase(IDTIPODOCUEMENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarListaPorProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32, Optional ByVal IDTIPODOCUMENTOBASE() As Integer = Nothing) As DataSet
        Try
            Return mDb.RecuperarListaPorProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDTIPODOCUMENTOBASE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function RecuperarListaPorProcesoCompraRecTec(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32, Optional ByVal IDTIPODOCUMENTOBASE() As Integer = Nothing) As DataSet
        Try
            Return mDb.RecuperarListaPorProcesoCompraRecTec(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDTIPODOCUMENTOBASE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
End Class
