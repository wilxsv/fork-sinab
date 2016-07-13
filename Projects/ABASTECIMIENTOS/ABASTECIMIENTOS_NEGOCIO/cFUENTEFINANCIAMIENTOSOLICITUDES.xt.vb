Partial Public Class cFUENTEFINANCIAMIENTOSOLICITUDES

#Region " Metodos Agregados "
    ''' <summary>
    ''' Obtener listado de fuentes de financiamiento por solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de la solicitud
    ''' <returns>
    ''' listado de fuente de financiamiento
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerListaXSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As listaFUENTEFINANCIAMIENTOSOLICITUDES
        Try
            Return mDb.ObtenerListaPorSolicitud(IDESTABLECIMIENTO, IDSOLICITUD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener dataset con las fuente de financiamiento asociadas a un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimientos
    ''' <param name="IDPROCESOCOMPRA"></param> identificador de proceso de compras
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history>
    Public Function obtenerdatasetFuenteFinanciamientoProceCompra(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtenerdatasetFuenteFinanciamientoProceCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Eliminar fuente de financiamiento de una solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de la solicitud
    ''' <returns>
    ''' numero de registros afectados con la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function EliminarFUENTESSOLICITUD(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.EliminarFuentesSolicitud(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Calculo del monto total de la fuente de financiamiento de una solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de la solicitud
    ''' <returns>
    ''' valor del monto total
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CalcularMontoTotalFuenteSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As String
        'Calcular el monto total de la solicitud segun detalle de la misma
        mEntidad.IDSOLICITUD = IDSOLICITUD
        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        Return mDb.CalculoMontoTotalFuentesSolicitud(mEntidad)
    End Function

    ''' <summary>
    ''' Calculo del porcentaje total de las fuentes de financiamiento de una solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de la solicitud
    ''' <returns>
    ''' Valor del porcentaje total
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CalcularPorcentajeTotalFuenteSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As String
        'Calcular el monto total de la solicitud segun detalle de la misma
        mEntidad.IDSOLICITUD = IDSOLICITUD
        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        Return mDb.CalculoPorcentajeTotalFuentesSolicitud(mEntidad)
    End Function

    ''' <summary>
    ''' Validar existencia de fuente de financiamiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de la solicitud
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function FuenteSolicitudExiste(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDFUENTE As Int32) As Boolean
        Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDFUENTEFINANCIAMIENTO = IDFUENTE
            Return mDb.ValidarExistenciaFuente(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Validar si hay fuente de financiamiento asociado a la solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de la solicitud
    ''' <returns>
    ''' verdadero si hay fuentes asociados
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ExisteFuentesAsociadasSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Boolean
        Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO

            Return mDb.ValidarHayFuenteAsociadaSolicitud(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Obtener listado de nombres de fuente de financiamiento asociados a una solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de la solicitud
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history>
    Public Function ObtenerNombresFuenteFinanciamientoSolicitud(ByVal IDESTABLECIMIENTO As Int64, ByVal IDSOLICITUD As Int64) As DataSet
        Try
            Return mDb.ObtenerNombresFuenteFinanciamientoSolicitud(IDESTABLECIMIENTO, IDSOLICITUD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener listado de fuentes de financiamiento por solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de la solicitud
    ''' <returns>
    ''' listado de fuente de financiamiento
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDatasetFuentesPorSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet
        Return mDb.ObtenerDatasetFuentesPorSolicitud(IDESTABLECIMIENTO, IDSOLICITUD)
    End Function

    Public Function ObtenerFFDiscoURMIM() As DataSet
        Try
            Return mDb.ObtenerFFDiscoURMIM()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerFF(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet
        Try
            Return mDb.ObtenerFF(IDESTABLECIMIENTO, IDSOLICITUD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class
