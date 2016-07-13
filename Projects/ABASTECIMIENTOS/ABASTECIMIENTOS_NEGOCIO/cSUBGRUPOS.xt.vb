Partial Public Class cSUBGRUPOS

#Region " Métodos adicionales "

    Public Function ObtenerSubgruposporSuministro(ByVal IDSUMINISTRO As Integer) As listaSUBGRUPOS
        'Try
            Return mDb.ObtenerSubgruposporSuministro(IDSUMINISTRO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerListaPorGrupo(ByVal IDGRUPO As Integer) As listaSUBGRUPOS
        'Try
            Return mDb.ObtenerListaPorGrupo(IDGRUPO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function DevolverCorrSubgrupo(ByVal IDSUBGRUPO As Integer) As String
        'Try
            Return mDb.DevolverCorrSubgrupo(IDSUBGRUPO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ObtenerListaPorGrupoUT(ByVal IDGRUPO As Integer, ByVal AREATECNICA As Integer) As DataSet
        'Try
            Return mDb.ObtenerListaPorGrupoUT(IDGRUPO, AREATECNICA)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ObtenerListaPorGrupoUTYGU(ByVal IDGRUPO As Integer, ByVal AREATECNICA As Integer, ByVal GU As Integer) As DataSet
        'Try
            Return mDb.ObtenerListaPorGrupoUTyGU(IDGRUPO, AREATECNICA, GU)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
#End Region

End Class
