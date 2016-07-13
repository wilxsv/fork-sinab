Partial Public Class cCALIFICACIONPROVEEDORES

    Public Function obtenerContratosProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal DIASATRASO As Integer, ByVal RECHAZOS As Integer, ByVal FECHAINICIO As String, ByVal FECHAFIN As String) As DataSet
        Return mDb.obtenerContratosProveedor(IDESTABLECIMIENTO, IDPROVEEDOR, DIASATRASO, RECHAZOS, FECHAINICIO, FECHAFIN)
    End Function

End Class
