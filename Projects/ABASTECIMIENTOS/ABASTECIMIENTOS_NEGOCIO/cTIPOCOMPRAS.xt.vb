Partial Public Class cTIPOCOMPRAS

#Region " Metodos Agregados "

    Public Function obtenerListaporMonto(ByVal totalMonto As Decimal) As DataSet
        Try
            Return mDb.obtenerListaporMonto(totalMonto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarOrdenada() As DataSet
        Try
            Return mDb.RecuperarOrdenada
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerTipoCompraxMODALIDAD(ByVal IDMODALIDADCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerTipoCompraxMODALIDAD(IDMODALIDADCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerTipoCompraporMonto(ByVal MONTO As Decimal) As DataSet
        Try
            Return mDb.obtenerTipoCompraporMonto(MONTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerTipoCompraporMontoLG(ByVal MONTO As Decimal) As DataSet
        Try
            Return mDb.obtenerTipoCompraporMontoLG(MONTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
