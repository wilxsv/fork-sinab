Partial Public Class cPLANTILLAS

#Region "  Metodos Agregados  "

    Public Function ObtenerDataSetPlantillas(ByVal IDPLANTILLA As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPlantilla(IDPLANTILLA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ExisteNombrePlantilla(ByVal NOMBRE As String) As Boolean
        Try
            Return mDb.ExisteNombrePlantilla(NOMBRE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
