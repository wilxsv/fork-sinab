Partial Public Class cOPCIONESSISTEMAROLES

#Region " Metodos Agregados "

    Public Function ObtenerDatasetRolesOpciones() As DataSet
        Try
            Return mDb.ObtenerDatasetRolesOpciones
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function OpcionPermiteEditar(ByVal IDROL As Int32, ByVal URL As String) As Boolean
        Try
            Return mDb.OpcionPermiteEditar(IDROL, URL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

#End Region

End Class
