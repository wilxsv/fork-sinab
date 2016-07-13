Partial Public Class cDEPARTAMENTOS

    'Validar si un nombre corto ya existe
    '04/01/07 Responsable SONIA MARIBEL VIANA
    Public Function BuscarCODIGODEPARTAMENTO(ByVal CODIGODEPARTAMENTO As String, ByVal IDDEPARTAMENTO As Int16) As Int16
        Try
            Return mDb.BuscarCODIGODEPARTAMENTO(CODIGODEPARTAMENTO, IDDEPARTAMENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
