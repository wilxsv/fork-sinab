Partial Public Class cVALESSALIDA

#Region " Metodos agregados "

    'JOSE CHAVEZ
    Public Function RecuperarID(ByVal IDALMACEN As Int32) As Integer
        Return mDb.RecuperarID(IDALMACEN)
    End Function

    'JOSE CHAVEZ
    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDVALE As Int32, ByVal ANIO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDVALE, ANIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaValesSalida(ByVal IDALMACEN As Integer, Optional ByVal IDESTABLECIMIENTODESTINO As Integer = 0, Optional ByVal FECHADESDE As Date = Nothing, Optional ByVal FECHAHASTA As Date = Nothing, Optional ByVal IDFUENTEFINANCIAMIENTO As Integer = 0, Optional ByVal IDRESPONSABLEDISTRIBUCION As Integer = 0, Optional ByVal IDESTADO As Integer = 0, Optional ByVal NUMEROVALE As Integer = 0, Optional ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer = 0, Optional ByVal IDSUMINISTRO As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerListaValesSalida(IDALMACEN, IDESTABLECIMIENTODESTINO, FECHADESDE, FECHAHASTA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDESTADO, NUMEROVALE, IDGRUPOFUENTEFINANCIAMIENTO, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerFuentesValesSalida(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDVALE As Integer) As DataSet
        Try
            Return mDb.ObtenerFuentesValesSalida(IDALMACEN, ANIO, IDVALE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerResponsablesDistribucionValesSalida(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDVALE As Integer) As DataSet
        Try
            Return mDb.ObtenerResponsablesDistribucionValesSalida(IDALMACEN, ANIO, IDVALE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
