Partial Public Class cNECESIDADESSOLICITUD

#Region " Metodos Agregados "

    ''' <summary>
    ''' Devuelve la informaci�n del plan de distribuci�n para la UTMIM por establecimiento.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que elaboro la consolidaci�n.</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud.</param>
    ''' <returns>Dataset con la informaci�n del plan de distribuci�n UTMIM.</returns>
    ''' <history>
    '''     [Autor: Jos� Alberto Ch�vez Loarca]  11/11/2006    Creado
    ''' </history>
    Public Function ObtenerDataSetDistribucion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet
        Return mDb.ObtenerDataSetDistribucion(IDESTABLECIMIENTO, IDSOLICITUD)
    End Function

    ''' <summary>
    ''' Devuelve la informaci�n del plan de distribuci�n para la UACI.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento. (Filtro)</param>
    ''' <param name="IDPROCESOCOMPRA ">Identificador del proceso compra. (Filtro)</param>
    ''' <returns>Dataset con la informaci�n del plan de distribuci�n UACI.</returns>
    ''' <history>
    '''     [Autor: Jos� Alberto Ch�vez Loarca]  11/11/2006    Creado
    ''' </history> 
    Public Function ObtenerDistribucionUACI(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Return mDb.ObtenerDistribucionUACI(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
    End Function

    ''' <summary>
    ''' Eliminar solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que elaboro la consolidaci�n.</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud.</param>
    ''' <returns>
    ''' numero de registros afectados con la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function EliminarSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTOSOLICITUD = IDESTABLECIMIENTO

            Return mDb.Eliminarsolicitud(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
