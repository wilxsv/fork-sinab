Public Class cALMACENESENTREGASOLICITUD

    Inherits controladorBase

    Private mDb As New dbALMACENESENTREGASOLICITUD()
    Private mEntidad As New ALMACENESENTREGASOLICITUD

    Public Function AgregaralmacenesENTREGAsolicitud(ByVal aEntidad As ALMACENESENTREGASOLICITUD) As Integer
        'Try
            Return mDb.Agregar(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

End Class
