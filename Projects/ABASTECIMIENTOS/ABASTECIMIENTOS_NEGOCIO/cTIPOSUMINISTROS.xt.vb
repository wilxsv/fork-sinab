Partial Public Class cTIPOSUMINISTROS
    Public Function BuscarTIPOSUMINISTROS(ByVal IDTIPOSUMINISTRO As Int32) As Boolean
        Try
            Return mDb.BuscarTIPOSUMINISTROS(IDTIPOSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
