Partial Public Class cLOTESNOACEPTACION

    Public Function ObtenerID(ByVal aEntidad As entidadBase) As String
        'JOSE CHAVEZ
        Return mDb.ObtenerID(aEntidad)
    End Function

    Public Function Agregar(ByVal aEntidad As entidadBase) As Integer
        'JOSE CHAVEZ
        Return mDb.Agregar(aEntidad)
    End Function

End Class
