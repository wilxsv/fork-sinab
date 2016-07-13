Partial Public Class cDETALLEPLANTILLAPROCESOCOMPRA

#Region " Metodos Agregados "

    Public Function ObtenerTextoPlantilla(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal TIPOPLANTILLA As Byte) As String
        Try
            Return mDb.ObtenerTextoPlantilla(IDESTABLECIMIENTO, IDPROCESOCOMPRA, TIPOPLANTILLA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return String.Empty
        End Try
    End Function

    Public Function AgregarDETALLEPLANTILLAPROCESOCOMPRA(ByVal aEntidad As DETALLEPLANTILLAPROCESOCOMPRA) As Integer
        Try
            Return mDb.AgregarDETALLEPLANTILLAPROCESOCOMPRA(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
