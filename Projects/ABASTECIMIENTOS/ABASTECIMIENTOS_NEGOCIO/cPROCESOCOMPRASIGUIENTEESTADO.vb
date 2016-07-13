Public Class cPROCESOCOMPRASIGUIENTEESTADO
    Inherits controladorBase
    
    Private mDb As New dbPROCESOCOMPRASIGUIENTEESTADO
    Public Function getSiguienteEstado(ByVal idestablecimiento As Integer, ByVal iddependencia As Integer, ByVal idestado As Integer) As Integer
        Return mDb.getSiguienteEstado(idestablecimiento, iddependencia, idestado)
    End Function
    Public Function getSiguienteEstadoByUser(ByVal usuario As String, ByVal idestado As Integer) As Integer
        Return mDb.getSiguienteEstadoByUser(usuario, idestado)
    End Function
End Class
