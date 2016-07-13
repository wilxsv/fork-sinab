Partial Public Class cMODIFICATIVASCONTRATO

#Region " Metodos agregados "

    Public Function ObtenerModificativasContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As String
        Try
            Return mDb.ObtenerModificativasContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
