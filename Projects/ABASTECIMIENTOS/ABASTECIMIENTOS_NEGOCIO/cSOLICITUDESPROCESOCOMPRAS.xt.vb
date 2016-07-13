Partial Public Class cSOLICITUDESPROCESOCOMPRAS

#Region "  metodos agregados "

    'Public Function ObtenerLista_IDPROCESOCOMPRA(ByVal IDSOLICITUD As Int64, ByVal IDPROCESOCOMPRA As Int64) As listaSOLICITUDESPROCESOCOMPRAS
    '    Try
    '        Return mDb.ObtenerListaPorIDPROCESOCOMPRA(IDSOLICITUD, IDPROCESOCOMPRA)
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return Nothing
    '    End Try
    'End Function

    Public Function obtenerSolProcCompra(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerSolProcCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' dataset solicitudes asociadas a un proceso de compra
    ''' </summary>
    ''' <param name="idProceso"></param> identificador de proceso de compra
    ''' <param name="idESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' dataset con los datos solicitados
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerSolicitudesProcesoCompra(ByVal idProceso As Int32, ByVal idESTABLECIMIENTO As Int32) As DataSet
        Return mDb.DataSetProcesosComprasSolicitudes(idProceso, idESTABLECIMIENTO)
    End Function

    ''' <summary>
    ''' dataset con las solicitudes de un proceso de compra
    ''' </summary>
    ''' <param name="idProceso"></param> identificador del proceso de compra
    ''' <param name="idEstablecimiento"></param> identificador del establecimiento
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerSolicitudesProcesoCompraconFuente(ByVal idProceso As Int32, ByVal idESTABLECIMIENTO As Int32) As Data.DataTable
        Return mDb.DataSetProcesosComprasSolicitudesconFuente(idProceso, idESTABLECIMIENTO)
    End Function

    Public Function ObtenerSolicitudesProcesoCompra1(ByVal idProceso As Int32, ByVal idESTABLECIMIENTO As Int32) As DataSet
        Return mDb.ObtenerProcesosComprasSolicitudes(idProceso, idESTABLECIMIENTO)
    End Function

    Public Function ObtenerIdSolicitud(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Integer) As Integer
        Try
            Return mDb.ObtenerIdSolicitud(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
