Partial Public Class cPLANTILLASCONTRATO

    Public Function obtenerPlantillasContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOCOMPRA As Integer, ByVal IDSUMINISTRO As Integer, ByVal tipoPLantilla As Integer) As DataSet
        Try
            Return mDb.obtenerPlantillasContrato(IDESTABLECIMIENTO, IDTIPOCOMPRA, IDSUMINISTRO, tipoPLantilla)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function AgregarPLANTILLASCONTRATO(ByVal aEntidad As PLANTILLASCONTRATO) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerDataSetxPlantilla(ByVal aEntidad As entidadBase) As DataSet
        Try
            Return mDb.obtenerDataSetxPlantilla(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
