
Partial Public Class cGARANTIASCONTRATOS

#Region " Metodos Agregados "

    Public Function ObtenerDataSetRenglones(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetRenglones(IDESTABLECIMIENTO, IDPROVEEDOR, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetProcesoCompra(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetProcesoCompra(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetProveedor() As DataSet
        Try
            Return mDb.ObtenerDataSetProveedor()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetBusquedaProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetBusquedaProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDsRptProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer)
        Try
            Return mDb.obtenerDsRptProveedor(IDESTABLECIMIENTO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDsRptFechaVencimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal FECHAVENCIMIENTO As Date) As DataSet
        Try
            Return mDb.obtenerDsRptFechaVencimiento(IDESTABLECIMIENTO, FECHAVENCIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetBusquedaProveedor(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetBusquedaProveedor(IDESTABLECIMIENTO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetBusquedaContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal CONTRATO As String) As DataSet
        Try
            Return mDb.ObtenerDataSetBusquedaContrato(IDESTABLECIMIENTO, CONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetBusquedaFechaVencimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal FECHAVENCIMIENTO As Date) As DataSet
        Try
            Return mDb.ObtenerDataSetBusquedaFechaVencimiento(IDESTABLECIMIENTO, FECHAVENCIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetBusquedaTipoGarantia(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOGARANTIA As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetBusquedaTipoGarantia(IDESTABLECIMIENTO, IDTIPOGARANTIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDsRptTipoGarantia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOGARANTIA As Integer) As DataSet
        Try
            Return mDb.obtenerDsRptTipoGarantia(IDESTABLECIMIENTO, IDTIPOGARANTIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetBusquedaNumeroGarantia(ByVal IDESTABLECIMIENTO As Int32, ByVal NUMEROGARANTIA As String) As DataSet
        Try
            Return mDb.ObtenerDataSetBusquedaNumeroGarantia(IDESTABLECIMIENTO, NUMEROGARANTIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener las garantias por contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDCONTRATO"></param> identificador del contrato
    ''' <param name="IDPROVEEDOR"></param> identificador del proveedor
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerGarantiasXContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet
        Return mDb.obtenerGarantiasXContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
    End Function

    Public Function obtenerGARANTIAMNTTOVALOR(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As Decimal
        Return mDb.obtenerGARANTIAMNTTOVALOR(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
    End Function

    Public Function obtenerDatosGarantia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDTIPOGARANTIA As Integer) As DataSet
        Return mDb.obtenerDatosGarantia(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDTIPOGARANTIA)
    End Function

    Public Function obtenerDatasetGarantiasXContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet
        Try
            Return mDb.obtenerDatasetGarantiasXContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerEncabezadoGarantia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDTIPOGARANTIA As Integer, ByVal IDGARANTIACONTRATO As Integer) As DataSet
        Try
            Return mDb.obtenerEncabezadoGarantia(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDTIPOGARANTIA, IDGARANTIACONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Sub ActualizarEstadosGarantias()
        Try
            mDb.ActualizarEstadosGarantias()
        Catch ex As Exception
            ExceptionManager.Publish(ex)

        End Try
    End Sub

    Public Function obtenerGarantiaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal TIPOGARANTIA As Integer) As DataSet
        Try
            Return mDb.obtenerGarantiaContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, TIPOGARANTIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function validaExistenciaGarantia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDTIPOGARANTIA As Integer) As Integer
        Return mDb.validaExistenciaGarantia(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDTIPOGARANTIA)
    End Function

    Public Function validaExistenciaGarantiaModificativa(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDTIPOGARANTIA As Integer, ByVal IDMODIFICATIVA As Integer) As Integer
        Return mDb.validaExistenciaGarantiaModificativa(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDTIPOGARANTIA, IDMODIFICATIVA)
    End Function

#End Region

End Class
