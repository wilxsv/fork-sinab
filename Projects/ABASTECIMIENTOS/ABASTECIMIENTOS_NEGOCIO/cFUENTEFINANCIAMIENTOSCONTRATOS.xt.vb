Partial Public Class cFUENTEFINANCIAMIENTOSCONTRATOS

#Region " Metodos Agregados "

    Public Function ObtenerFuentesPorContratoDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As DataSet
        Try
            Return mDb.ObtenerFuentesPorContratoDS(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Calcular el monto total de las fuentes contrato
    Public Function CalcularMontoTotalFuenteContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int64, ByVal IDPROVEEDOR As Int32) As String
        Try
            Return mDb.CalculoMontoTotalFuentesContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'JOSE CHAVEZ
    Public Function EliminarAsociados(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As Integer
        Try
            Return mDb.EliminarAsociados(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerFuenteFinanciamientoSolcitud(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.obtenerFuenteFinanciamientoSolicitud(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function validaExisteFuenteFinaciamientoContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer) As Integer
        Try
            Return mDb.validaExisteFuenteFinaciamientoContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerMontoFFContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obtenerMontoFFContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerMontoGOES(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal idprocesocompra As Integer) As Decimal
        Try
            Return mDb.obtenerMontoGOES(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, idprocesocompra)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerMontoPEIS(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal idprocesocompra As Integer) As Decimal
        Try
            Return mDb.obtenerMontoPEIS(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, idprocesocompra)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerMontoPEISCobertura(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal idprocesocompra As Integer) As Decimal
        Try
            Return mDb.obtenerMontoPEISCobertura(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, idprocesocompra)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerFuentesFinanciamientoContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As String
        Try
            Return mDb.ObtenerFuentesFinanciamientoContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
