Partial Public Class cDETALLECOMISIONEVALUADORA

#Region "Metodos Adicionales"

    Public Function AgregarDETALLECOMISIONEVALUADORA(ByVal aEntidad As DETALLECOMISIONEVALUADORA) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDetalleporComision(ByVal idcomision As Integer, ByVal idestablecimiento As Integer) As DataSet
        Try
            Return mDb.ObtenerDetallePorComision(idcomision, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDetalleporComisionAN(ByVal idcomision As Integer, ByVal idestablecimiento As Integer) As DataSet
        Try
            Return mDb.ObtenerDetallePorComisionAN(idcomision, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarEmpleadoComision(ByVal aentidad As DETALLECOMISIONEVALUADORA) As Integer
        Try
            Return mDb.ActualizarEmpleado(aentidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarEmpleadoComisionAN(ByVal aentidad As DETALLECOMISIONEVALUADORA) As Integer
        Try
            Return mDb.ActualizarEmpleadoAN(aentidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
