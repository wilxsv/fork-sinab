Partial Public Class cDOCUMENTOSPROCESOSCOMPRA

#Region "  Metodos Agregados  "

    Public Function ObtenerDataSetPorTipoDocumento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDTIPODOCUMENTOBASE As Int16) As DataSet
        Try
            Return mDb.ObtenerDataSetPorTipoDocumento(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDTIPODOCUMENTOBASE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
