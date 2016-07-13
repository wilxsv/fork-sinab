Partial Class cASESORIAPREDEFINIDA

#Region "Metodos adicionales"

    Public Function VALIDARDESCRIPCION(ByVal DESCRIPCION As String, ByVal IDASESORIA As Int16) As Int16
        Try
            Return mDb.VALIDARDESCRIPCION(DESCRIPCION, IDASESORIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
