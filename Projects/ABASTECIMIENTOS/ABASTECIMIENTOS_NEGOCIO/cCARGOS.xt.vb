Partial Public Class cCARGOS

#Region " Metodos Agregados "

    Public Function ObtenerListaOrden(ByVal Tipo As Integer) As listaCARGOS
        Try
            Return mDb.ObtenerListaorden(Tipo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarCargosEnEmpleados(ByVal IDCARGO As Int32) As Boolean
        Try
            Return mDb.BuscarCargosEnEmpleados(IDCARGO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
