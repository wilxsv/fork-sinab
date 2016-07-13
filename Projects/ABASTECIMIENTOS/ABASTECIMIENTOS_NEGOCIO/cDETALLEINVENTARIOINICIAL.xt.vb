Partial Public Class cDETALLEINVENTARIOINICIAL
    Inherits controladorBase

#Region "Metodos Adicionales"

    Public Function ObtenerInventarioInicial(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As DataSet
        Try
            Return mDb.ObtenerInventarioInicial(IDALMACEN, IDINVENTARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function CerrarInventarioInicial(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal IDESTABLECIMIENTO As Int32, ByVal AUUSUARIOCREACION As String, ByVal AUFECHACREACION As DateTime) As Integer
        Try
            Return mDb.CerrarInventarioInicial(IDALMACEN, IDINVENTARIO, IDESTABLECIMIENTO, AUUSUARIOCREACION, AUFECHACREACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ConsultaInventarioInicial(ByVal IDALMACEN As Integer, ByVal IDINVENTARIO As Integer) As DataSet
        Try
            Return mDb.ConsultaInventarioInicial(IDALMACEN, IDINVENTARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
