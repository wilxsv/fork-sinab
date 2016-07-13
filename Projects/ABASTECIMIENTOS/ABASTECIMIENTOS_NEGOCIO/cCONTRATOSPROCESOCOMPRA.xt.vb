Partial Public Class cCONTRATOSPROCESOCOMPRA

    Public Function ObtenerPCporContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As Integer
        Try
            Return mDb.ObtenerPCporContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

End Class
