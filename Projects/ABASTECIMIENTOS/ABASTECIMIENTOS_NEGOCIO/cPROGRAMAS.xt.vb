Partial Public Class cPROGRAMAS

    'Validar si un CODIGO ya existe
    '02/03/07 Responsable Eduardo Rodriguez
    Public Function Buscarcodigo(ByVal CODIGO As String, ByVal IDPROGRAMA As Int16) As Int16
        Try
            Return mDb.BuscarCodigo(CODIGO, IDPROGRAMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProgramas() As DataSet

        Try
            Return mDb.obtenerProgramas()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

End Class
