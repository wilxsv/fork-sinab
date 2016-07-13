Partial Public Class cDETALLEENTREGAS

#Region " METODOS AGREGADOS "

    'AUTOR: JOSE CHAVEZ
    '--------------------------------------------------------------------------------------
    'Esta funcion se utiliza para poder agregar una fila al detalle de las entregas
    '--------------------------------------------------------------------------------------
    'FECHA CREACION: 20/11/2006
    Public Function AgregarDETALLEENTREGA(ByVal aEntidad As DETALLEENTREGAS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ValidarIDDETALLEENTREGA(ByVal BIDSOLICITUD As Int64, ByVal BIDESTABLECIMIENTO As Int32, ByVal BIDENTREGA As Int16, ByVal BIDDETALLE As Int16) As Boolean
        Try
            Return mDb.ValidarIDDETALLEENTREGA(BIDSOLICITUD, BIDESTABLECIMIENTO, BIDENTREGA, BIDDETALLE)
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' Obtener informacion de detalle de entregas asociada a una solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD"></param> 'identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetPorSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorSolicitud(IDSOLICITUD, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Eliminar el detalle de entregas para una solicitud especifica
    ''' </summary>
    ''' <param name="IDSOLICITUD"></param> 'identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' devuelve uno si se realizo la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function EliminarDETALLEENTREGASxSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO

            Return mDb.EliminarDetalleEntregasXsolicitud(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ' AUTOR: JOSE CHAVEZ 
    '-------------------------------------------------------------------------------------------------------------------------
    ' Se utiliza para obtener el limite de las entregas para una solicitud de compras
    ' FECHA 06/12/06 
    '-------------------------------------------------------------------------------------------------------
    Public Function ObtenerLimiteEntrega(ByVal IDESTABLECIMIENTO As Int64, ByVal IDSOLICITUD As Int64) As Int16
        Return mDb.ObtenerLimiteEntrega(IDESTABLECIMIENTO, IDSOLICITUD)
    End Function

    ' AUTOR: JUAN RIVAS
    '-------------------------------------------------------------------------------------------------------------------------
    ' Se utiliza para obtener los días y porcentajes de entregas
    ' FECHA 27/02/07
    '-------------------------------------------------------------------------------------------------------
    Public Function obtenerDiasPorcentaje(ByVal IDENTREGA As Integer, ByVal ARR_SOLICITUD As listaSOLICITUDES, ByVal IDDETALLE As Integer) As DataSet
        Try
            Return mDb.obtenerDiasPorcentaje(IDENTREGA, ARR_SOLICITUD, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

#End Region

End Class
