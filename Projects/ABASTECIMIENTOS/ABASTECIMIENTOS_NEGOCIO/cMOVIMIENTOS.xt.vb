Partial Public Class cMOVIMIENTOS

#Region " Metodos Agregados "

    Public Function ObtenerID(ByVal aEntidad As MOVIMIENTOS) As String
        Try
            Return mDb.ObtenerID(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Se utiliza para devolver un dataset con la lista de movimientos filtrada
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDTIPOTRANSACCION"></param>
    ''' <param name="IDMOVIMIENTO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDDEPENDENCIA"></param>
    ''' <param name="IDTIPOCONSULTA"></param>
    ''' <param name="CLASIFICACION"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    11/12/06    Creado
    ''' </history>
    Public Function ObtenerDsMovimientosFiltrado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int16, ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal IDDEPENDENCIA As Int32, ByVal IDTIPOCONSULTA As Int16, Optional ByVal CLASIFICACION As Int16 = 0) As DataSet
        Try
            Return mDb.ObtenerDsMovimientosFiltrado(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO, IDALMACEN, IDDEPENDENCIA, IDTIPOCONSULTA, CLASIFICACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerMovimientosAnular(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int16, ByVal IDALMACEN As Int32) As DataSet
        Try
            Return mDb.ObtenerMovimientosAnular(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerMovimientosDetalleLoteDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int16, ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal IDDEPENDENCIA As Int32, ByVal IDDESTINO As Int32, ByVal IDTIPOCONSULTA As Int16) As DataSet
        Try
            Return mDb.ObtenerMovimientosDetalleLoteDS(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO, IDALMACEN, IDDEPENDENCIA, IDDESTINO, IDTIPOCONSULTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As listaMOVIMIENTOS
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function AgregarMOVIMIENTOS(ByVal aEntidad As MOVIMIENTOS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="ANIO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ObtenerValeSalidaDS(ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal ANIO As Int32) As DataSet
        Try
            Return mDb.ObtenerValeSalidaDS(IDMOVIMIENTO, IDALMACEN, ANIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerValeSalidaDS2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerValeSalidaDS2(IDESTABLECIMIENTO, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDTIPOTRANSACCION"></param>
    ''' <param name="IDMOVIMIENTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function AnularDocumentoValidacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As Int16
        Try
            Return mDb.AnularDocumentoValidacion(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDRECIBO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ObtenerRecepcionesPrincipalDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDRECIBO As Int32, ByVal IDALMACEN As Int32) As DataSet
        Try
            Return mDb.ObtenerRecepcionesPrincipalDS(IDESTABLECIMIENTO, IDRECIBO, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDRECIBO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function BuscarRecepcionesPrincipalDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDRECIBO As Int32) As DataSet
        Try
            Return mDb.BuscarRecepcionesPrincipalDS(IDESTABLECIMIENTO, IDRECIBO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDFUENTE"></param>
    ''' <param name="IDRESPONSABLE"></param>
    ''' <param name="FECHAINICIO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function BuscarRecepcionesPrincipalGeneral(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDFUENTE As Int32, ByVal IDRESPONSABLE As Int32, ByVal FECHAINICIO As Date) As DataSet
        Try
            Return mDb.BuscarRecepcionesPrincipalGeneral(IDESTABLECIMIENTO, IDPROVEEDOR, IDFUENTE, IDRESPONSABLE, FECHAINICIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDRECIBO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ObtenerRecepcionesDependenciaPrincipalDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDRECIBO As Int32) As DataSet
        Try
            Return mDb.ObtenerRecepcionesDependenciaPrincipalDS(IDESTABLECIMIENTO, IDRECIBO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="ANIO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ObtenerReciboRecepcionDS(ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal ANIO As Int32) As DataSet
        Try
            Return mDb.ObtenerReciboRecepcionDS(IDMOVIMIENTO, IDALMACEN, ANIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="ANIO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ObtenerReciboRecepcionDS2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerReciboRecepcionDS2(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="ANIO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ObtenerReciboRecepcionDS3(ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal ANIO As Int32) As DataSet
        Try
            Return mDb.ObtenerReciboRecepcionDS3(IDMOVIMIENTO, IDALMACEN, ANIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ObtenerNoAceptacionPrincipalDS(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerNoAceptacionPrincipalDS(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="ANIO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ObtenerNoAceptacionDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerNoAceptacionDS(IDESTABLECIMIENTO, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="aEntidad"></param>
    ''' <param name="aListaMovimientos"></param>
    ''' <param name="aListaLotes"></param>
    ''' <param name="aEntidadDocumento"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarDocumentoMovimientoDetalleLote(ByVal aEntidad As MOVIMIENTOS, ByVal aListaMovimientos As listaDETALLEMOVIMIENTOS, ByVal aListaLotes As listaLOTES, ByVal aEntidadDocumento As entidadBase) As Integer
        Try

            Select Case aEntidad.IDTIPOTRANSACCION
                Case 4, 5, 15
                    Dim cCA As New cCORRECCIONESALMACENES
                    Dim eCA As CORRECCIONESALMACENES = aEntidadDocumento
                    cCA.ActualizarCORRECCIONESALMACENES(eCA)

                    aEntidad.IDALMACEN = eCA.IDALMACEN
                    aEntidad.ANIO = eCA.ANIO
                    aEntidad.IDDOCUMENTO = eCA.IDCORRECCION
            End Select

            mDb.Actualizar(aEntidad)

            Dim cDM As New cDETALLEMOVIMIENTOS
            Return cDM.ActualizarDETALLEMOVIMIENTOS(aEntidad.IDMOVIMIENTO, aListaMovimientos, aListaLotes)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <param name="FECHAHASTA"></param>
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ExistenciaHistoricaPorProducto(ByVal IDALMACEN As Integer, ByVal IDPRODUCTO As Integer, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer) As DataSet
        Try
            Return mDb.ExistenciaHistoricaPorProducto(IDALMACEN, IDPRODUCTO, FECHAHASTA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve un listado de los movimientos al inventario filtrado por cada uno de los parámetros, solamente 
    ''' muestra la información de la tabla padre.
    ''' </summary>
    ''' <param name="IDMOVIMIENTO">Identificador del movimiento que se desea recuperar. (Filtro)</param>
    ''' <param name="IDALMACENDESTINO ">Identificador del almacén destino. (Filtro)</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la unidad que solicita. (Filtro)</param>
    ''' <param name="IDTIPOCONSULTA">Identificador del tipo de consulta que se desea aplicar. </param>
    ''' <param name="CLASIFICACION">Identificador de la clasificación del movimiento.(Filtro)</param> 
    ''' <returns>Dataset con el listado de movimientos.</returns>
    ''' <remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  10/02/2007    Creado
    ''' </history> 
    ''' </remarks>
    Public Function ObtenerRequisicionesFiltradas(ByVal IDMOVIMIENTO As Int64, ByVal IDALMACENDESTINO As Int32, ByVal IDDEPENDENCIA As Int32, ByVal IDTIPOCONSULTA As Int16, Optional ByVal CLASIFICACION As Int16 = 0) As DataSet
        Try
            Return mDb.ObtenerRequisicionesFiltradas(IDMOVIMIENTO, IDALMACENDESTINO, IDDEPENDENCIA, IDTIPOCONSULTA, CLASIFICACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve un listado de los movimientos al inventario filtrado por cada uno de los parámetros, solamente 
    ''' muestra la información de la tabla padre.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTODESTINO">Identificador del establecimiento de destino.(Filtro)</param>
    ''' <param name="IDMOVIMIENTO">Identificador del movimiento que se desea recuperar.(Filtro)</param>
    ''' <param name="IDALMACENDESTINO">Identificador del almacén destino.(Filtro)</param>
    ''' <param name="IDTIPOCONSULTA">Identificador del tipo de consulta que se desea aplicar.</param>
    ''' <param name="CLASIFICACION">Clasificación del movimiento.(Filtro)</param>
    ''' <returns>Dataset con el listado de vales de salida pendientes de despacho en el almacén.</returns>
    ''' <remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  11/12/2006    Creado
    ''' </history>  
    ''' </remarks>
    Public Function ObtenerValesPendientesAlmacen(ByVal IDESTABLECIMIENTOORIGEN As Int32, ByVal IDESTABLECIMIENTODESTINO As Int32, ByVal IDMOVIMIENTO As Int64, ByVal IDALMACENDESTINO As Int32, ByVal IDTIPOCONSULTA As Int16, Optional ByVal CLASIFICACION As Int16 = 0) As DataSet
        Try
            Return mDb.ObtenerValesPendientesAlmacen(IDESTABLECIMIENTOORIGEN, IDESTABLECIMIENTODESTINO, IDMOVIMIENTO, IDALMACENDESTINO, IDTIPOCONSULTA, CLASIFICACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerValesPendientesAlmacen(ByVal IDALMACENDESTINO As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerValesPendientesAlmacen(IDALMACENDESTINO, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function Recuperar2(ByRef aEntidad As MOVIMIENTOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar2(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function RenglonesRecibosAbiertos(ByVal IDALMACEN As Integer, ByVal IDDOCUMENTO As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.RenglonesRecibosAbiertos(IDALMACEN, IDDOCUMENTO, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerFuentesFinanciamientoMovimiento(ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOTRANSACCION As Integer, ByVal IDMOVIMIENTO As Integer) As String
        Try
            Return mDb.ObtenerFuentesFinanciamientoMovimiento(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function GuardarDespacho(ByVal eM As MOVIMIENTOS, ByVal eVS As VALESSALIDA) As Integer
        Try
            Return mDb.GuardarDespacho(eM, eVS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
