Partial Public Class cDOCUMENTOSBASEPLANTILLA

#Region " Metodos Agregados "

    Public Function ObtenerDataSetDocumentosPlantilla(ByVal IDTIPODOCUMENTOBASE As Int64, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetDocumentosPlantilla(IDTIPODOCUMENTOBASE, IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetDocumentosPlantilla2(ByVal IDTIPODOCUMENTOBASE As Int64, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetDocumentosPlantilla2(IDTIPODOCUMENTOBASE, IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarPorPLANTILLA(ByVal IDPLANTILLA As Int32) As Integer
        Try
            mEntidad.IDPLANTILLA = IDPLANTILLA
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
