Partial Public Class cETIQUETASCAMPOS

#Region " Metodos Agregados  "

    Public Function ObtenerDataSetPorTABLA(ByVal TABLA As String) As DataSet
        Try
            Return mDb.ObtenerDataSetPorTABLA(TABLA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
