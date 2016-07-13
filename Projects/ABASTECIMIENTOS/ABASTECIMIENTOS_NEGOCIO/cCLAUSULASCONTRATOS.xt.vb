Partial Public Class cCLAUSULASCONTRATOS

    Public Function verificaExistencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCLAUSULA As Int32) As DataSet
        Try
            Return mDb.verificaExistencia(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, IDCLAUSULA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function validaOrden(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal ORDEN As Integer) As DataSet
        Try
            Return mDb.validaOrden(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, ORDEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
