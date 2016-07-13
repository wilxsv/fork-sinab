Partial Public Class cADENDAS

#Region " Metodos Agregados "

    Public Function ObtenerAdendasPorProceso(ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerAdendasPorProceso(IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataporAdenda(ByVal IDADENDA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataporAdenda(IDADENDA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
