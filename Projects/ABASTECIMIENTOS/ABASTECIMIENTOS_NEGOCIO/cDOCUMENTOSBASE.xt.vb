Partial Public Class cDOCUMENTOSBASE

#Region " Métodos Agregados "

    Public Function ObtenerDataSetPorTipoDocumento(ByVal IDTIPODOCUMENTOBASE As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetTipoDocumento(IDTIPODOCUMENTOBASE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetPorTipoDocumento2(ByVal IDTIPODOCUMENTOBASE As Int64, ByVal idgruporeqdoc As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetTipoDocumento2(IDTIPODOCUMENTOBASE, idgruporeqdoc)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetXTipoDocumento(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPODOCUMENTOBASE As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetXProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDTIPODOCUMENTOBASE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetXTipoDocumento2(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetXProcesoCompra2(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDsListaDocumentoBase() As DataSet
        Try
            Return mDb.ObtenerDsListaDocumentoBase
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetXTipoDocumento3(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetXProcesoCompra3(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDocumentosProcesoCompra(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDTIPODOCUMENTOBASE As Integer, ByVal ENTREGADO1 As Integer) As DataSet
        Try
            Return mDb.ObtenerDocumentosProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDTIPODOCUMENTOBASE, ENTREGADO1)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDocumentosProcesoCompraRenglon(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal IDTIPODOCUMENTOBASE As Integer, ByVal ENTREGADO1 As Integer) As DataSet
        Try
            Return mDb.ObtenerDocumentosProcesoCompraRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, IDTIPODOCUMENTOBASE, ENTREGADO1)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDocumentosProcesoCompraRenglonM(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal IDTIPODOCUMENTOBASE As Integer, ByVal ENTREGADO1 As Integer, ByVal idproducto As Integer, ByVal IDGRUPOREQTEC As Integer) As DataSet
        Try
            Return mDb.ObtenerDocumentosProcesoCompraRenglonM(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, IDTIPODOCUMENTOBASE, ENTREGADO1, idproducto, IDGRUPOREQTEC)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class
