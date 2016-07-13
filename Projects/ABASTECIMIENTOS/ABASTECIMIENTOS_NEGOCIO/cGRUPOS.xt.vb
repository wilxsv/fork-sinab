Partial Public Class cGRUPOS

#Region "Metodo adicionales"

    Public Function ObtenerListaPorSuministro(ByVal IDSUMINISTRO As Integer) As DataSet
        'Try
            Return mDb.ObtenerListaPorSuministro(IDSUMINISTRO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerListaOrdenada() As DataSet
        'Try
            Return mDb.ObtenerListaOrdenada()
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function DevolverCorrGrupo(ByVal IDGRUPO As Integer) As String
        'Try
            Return mDb.DevolverCorrGrupo(IDGRUPO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerListaConSuministro() As DataSet
        'Try
            Return mDb.ObtenerListaConSuministro
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ValidarCorrelativoSuministro(ByVal CORRELATIVO As String, ByVal IDSUMINISTRO As Int32, ByVal IDGRUPO As Int32) As Int16
        'Try
            Return mDb.ValidarCorrelativoSuministro(CORRELATIVO, IDSUMINISTRO, IDGRUPO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ObtenerListaPorUT(ByVal IDSUMINISTRO As Integer, ByVal AREATECNICA As Integer) As DataSet
        'Try
            Return mDb.ObtenerListaPorUT(IDSUMINISTRO, AREATECNICA)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ObtenerListaPorUTyGU(ByVal IDSUMINISTRO As Integer, ByVal AREATECNICA As Integer, ByVal GU As Integer) As DataSet
        'Try
            Return mDb.ObtenerListaPorUTyGU(IDSUMINISTRO, AREATECNICA, GU)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
#End Region

End Class
