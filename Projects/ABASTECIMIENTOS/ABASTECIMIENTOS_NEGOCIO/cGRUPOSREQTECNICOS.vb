Public Class cGRUPOSREQTECNICOS
    Inherits controladorBase
    Private mDb As New dbGRUPOSREQTECNICOS
    ' Private mEntidad As New ACCESOS
    Public Function ObtenerDataSetGRUPOSREQTECNICOS()
        Return mDb.ObtenerDataSetGRUPOSREQTECNICOS
    End Function

End Class
