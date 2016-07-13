Public Class cLogo
#Region " Privadas "
    Private mDb As New dbLogo
    Private mEntidad As New COMISIONPROCESOCOMPRA
#End Region

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.GetLogo(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
End Class
