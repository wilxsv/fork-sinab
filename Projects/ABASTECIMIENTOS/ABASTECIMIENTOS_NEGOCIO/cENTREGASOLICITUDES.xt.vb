Partial Public Class cENTREGASOLICITUDES

#Region " METODOS AGREGADOS "

    ''' <summary>
    ''' Agregar una nueva entrega
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo ENTREGASOLICITUDES
    ''' <returns>
    ''' Numero de registros afectados con la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function AgregarENTREGASOLICITUDES(ByVal aEntidad As ENTREGASOLICITUDES) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ValidarIDENTREGA(ByVal BIDSOLICITUD As Int64, ByVal BIDESTABLECIMIENTO As Int32, ByVal BIDENTREGA As Int16) As Boolean
        Try
            Return mDb.ValidarIDENTREGA(BIDSOLICITUD, BIDESTABLECIMIENTO, BIDENTREGA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' eliminar las entregas asociadas a una solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' Devuelve uno si completo operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function EliminarENTREGASXSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO

            Return mDb.EliminarEntregasXsolicitud(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function EliminarEntregasXsolicitudProducto(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer) As Integer
        Try

            Return mDb.EliminarEntregasXsolicitudProducto(idestablecimiento, idsolicitud, idproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' validar existencia de entregas para la solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' verdadero si existe entregas asociadas
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarExistenciaEntregasSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Boolean
        Try
            Return mDb.ValidarExistenciaEntregas(IDSOLICITUD, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener el numero de entregas realizado
    ''' </summary>
    ''' <param name="IDSOLICITUD"></param> identificador de solicitudes
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimientos
    ''' <returns>
    ''' numero de entregas
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerNumeroEntregas(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            Return mDb.ObtenerNumeroEntregas(IDSOLICITUD, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener el detalle para una entrega
    ''' </summary>
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDENTREGA"></param> identificador de entrega
    ''' <returns>
    ''' dataset con el detalle de la entrega
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDetalleEntrega(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDENTREGA As Int32) As DataSet
        Try
            Return mDb.ObtenerDetalleEntrega(IDSOLICITUD, IDESTABLECIMIENTO, IDENTREGA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener el Máximo de Entregas
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="ARR_SOLICITUD"></param> Arreglo que contiene los codigos de las solicitudes que se van a consolidar
    ''' <returns>
    '''  Valor entero, que contiene el número mayor de entregas
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Juan José Rivas]      Creado
    ''' </history>
    Public Function obtenerMaximoEntregas(ByVal ARR_SOLICITUD As listaSOLICITUDES) As Integer
        Try
            Return mDb.obtenerMaximoEntregas(ARR_SOLICITUD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerIDEntrega(ByVal aEntidad As entidadBase) As String
        Try
            Return mDb.ObtenerIDEntrega(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerMaximoEntregaTemp2() As Integer
        Try
            Return mDb.ObtenerMaximoEntregaTemp2()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDatosTemp2Entregas1() As DataSet
        Try
            Return mDb.ObtenerDatosTemp2Entregas1()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDatosTemp2Entregas2(ByVal idproducto As Integer) As DataSet
        Try
            Return mDb.ObtenerDatosTemp2Entregas2(idproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "SAB_EST_ENTREGAS"
    Public Function obtenerEntregas(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer) As ArrayList

        Try
            Return mDb.obtenerEntregas(idestablecimiento, idsolicitud)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return New ArrayList
        End Try

    End Function

    Public Function obtenerTotalEntregas(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer
        Try
            Dim i As Integer = mDb.obtenerTotalEntregas(IDSOLICITUD, IDESTABLECIMIENTO)
            Return i
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try
    End Function

    Public Function actualizarTotalEntregas(ByVal eEntidad As SOLICITUDES) As Integer

        Dim tran As New DistributedTransaction

        Try
            mDb.actualizarTotalEntregas(eEntidad, tran)
            mDb.borrarEntregas(eEntidad.IDSOLICITUD, eEntidad.IDESTABLECIMIENTO, tran, eEntidad.ENTREGAS)

            tran.Commit()
            Return 1

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function actualizarEntregas(ByVal idsolicitud As Integer, ByVal idestablecimiento As Integer, ByVal arr As ArrayList) As Integer

        Dim tran As New DistributedTransaction

        Try

            'Borremos
            mDb.borrarEntregas(idsolicitud, idestablecimiento, tran)


            For i As Integer = 0 To arr.Count - 1
                Dim eEntidad As ENTREGASOLICITUD = arr.Item(i)

                mDb.ingresarEntregas(eEntidad, tran)

            Next

            tran.Commit()
            'actualizar entregas en solicitudes
            Dim cs As New cSOLICITUDES
            Dim ce As New cENTREGASOLICITUDES
            Dim s As New SOLICITUDES

            s.IDESTABLECIMIENTO = idestablecimiento
            s.IDSOLICITUD = idsolicitud
            s.ENTREGAS = ce.ObtenerNumeroEntregas(idsolicitud, idestablecimiento)
            cs.ActualizarEntregas(s)

            Return 1

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try


    End Function

    Public Function obtenerEntregasParaProrratear(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal renglon As Integer) As DataSet
        Try
            Return mDb.obtenerEntregasParaProrratear(idestablecimiento, idsolicitud, idproducto, renglon)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function actualizarPlazoEntregaSolicitud(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer) As Integer
        Try
            mDb.actualizarPlazoEntregaSolicitud(idestablecimiento, idsolicitud)
            Return 1

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
