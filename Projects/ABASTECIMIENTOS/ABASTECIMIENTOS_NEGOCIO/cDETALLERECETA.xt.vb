Partial Class cDETALLERECETA

    Public Function AgregarDETALLERECETA(ByVal aEntidad As DETALLERECETA) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

End Class
