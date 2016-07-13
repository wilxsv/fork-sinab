Partial Public Class cMUNICIPIOS

#Region "Metodos adicionales"

    Public Function VALIDARNOMBRE(ByVal NOMBRE As String, ByVal IDMUNICIPIO As Int16) As Int16
        Try
            Return mDb.VALIDARNOMBRE(NOMBRE, IDMUNICIPIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetListaMunicipios() As DataSet
        Try
            Return mDb.ObtenerDataSetListaMunicipios()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
