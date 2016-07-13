Partial Public Class cTIPOESTABLECIMIENTOS

#Region " Validaciones agregadas "

    'Validar Nombre Corto 
    Public Function VALIDARNOMBRECORTO(ByVal NOMBRECORTO As String, ByVal IDTIPOESTABLECIMIENTO As Byte) As Int16
        Try
            Return mDb.VALIDARNOMBRECORTO(NOMBRECORTO, IDTIPOESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Validar Descripcion de Tipo Establecimientos
    Public Function VALIDARDESCRIPCION(ByVal DESCRIPCION As String, ByVal IDTIPOESTABLECIMIENTO As Byte) As Int16
        Try
            Return mDb.VALIDARDESCRIPCION(DESCRIPCION, IDTIPOESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaPorOrden(ByVal Tipo As Integer) As listaTIPOESTABLECIMIENTOS
        Try
            Return mDb.ObtenerListaPorOrden(Tipo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
