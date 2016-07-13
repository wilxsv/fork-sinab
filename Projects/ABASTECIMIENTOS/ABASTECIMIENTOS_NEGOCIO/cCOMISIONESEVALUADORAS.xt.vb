Partial Public Class cCOMISIONESEVALUADORAS

#Region "Metodos adicionales"

    Public Function IngresarCOMISIONESEVALUADORAS(ByVal aEntidad As COMISIONESEVALUADORAS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerListaComisiones(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As listaCOMISIONESEVALUADORAS
        Try
            Return mDb.ObtenerListaComisiones(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaComisionesAN(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As listaCOMISIONESEVALUADORAS
        Try
            Return mDb.ObtenerListaComisionesAN(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerID(ByVal aEntidad As COMISIONESEVALUADORAS) As String
        Try
            Return mDb.ObtenerID(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerEstablecimiento(ByVal IDUSUARIOCOMISION As Integer) As Integer
        Try
            Return mDb.ObtenerEstablecimiento(IDUSUARIOCOMISION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DevolverIdUsuarioComision(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCOMISION As Integer) As Integer
        Try
            Return mDb.DevolverIDusuarioComision(IDESTABLECIMIENTO, IDCOMISION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
