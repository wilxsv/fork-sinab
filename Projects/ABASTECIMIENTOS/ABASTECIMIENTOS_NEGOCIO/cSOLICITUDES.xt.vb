Partial Public Class cSOLICITUDES

#Region " Métodos Agregados "

    ''' <summary>
    ''' En esta función se obtiene el listado de solicitudes filtrando por criterio o campo de solicitudes y un operador
    ''' </summary>
    ''' <param name="Filtro"></param> dato a comparar 
    ''' <param name="Criterio"></param> campo a comparar con filtro
    ''' <param name="Operador"></param> operando de comparacion
    ''' <param name="BEstablecimiento"></param> identificador del establecimiento
    ''' <returns>
    ''' lista filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Enum estadoSolicititud
        Grabada = 1
        Enviada_Area_Técnica = 2
        Autorizada = 3
        Rechazada_AT = 4
        Rechazada_UACI = 5
        Aprobada_UACI = 6
        En_Proceso_Compra = 7
        Pendiente_Asignar = 8
    End Enum
    Public Function Filtrar(ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal IDESTABLECIMIENTO As Integer, ByVal IDUNIDADTECNICA As Int32) As listaSOLICITUDES
        'Try
            Return mDb.Filtrar(Filtro, Criterio, Operador, IDESTABLECIMIENTO, IDUNIDADTECNICA)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function Filtrar(ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal IDESTABLECIMIENTO As Integer) As listaSOLICITUDES
        'Try
            Return mDb.Filtrar(Filtro, Criterio, Operador, IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function Filtrar2(ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal Establecimiento As Int32) As DataSet
        'Try
            Return mDb.Filtrar2(Filtro, Criterio, Operador, Establecimiento)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function Filtrar(ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal IDEMPLEADOENCARGADO As String, ByVal IDESTABLECIMIENTO As String) As DataSet
        'Try
            Return mDb.Filtrar(Filtro, Criterio, Operador, IDEMPLEADOENCARGADO, IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    '''  En esta función se obtiene el listado de solicitudes filtrando por rango de fecha
    ''' </summary>
    ''' <param name="BFechaInicio"></param> fecha de inicio
    ''' <param name="BFechaFin"></param> fecha de fin
    ''' <param name="BCriterio"></param> campo de fecha a filtrar
    ''' <param name="BEstablecimiento"></param> identificador de estabelcimiento
    ''' <returns>
    ''' listado filtrado
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function FiltrarRangosFecha(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Criterio As String, ByVal IDESTABLECIMIENTO As Int32) As listaSOLICITUDES
        'Try
            Return mDb.FiltrarRangoFecha(FechaInicio, FechaFin, Criterio, IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function FiltrarRangosFecha(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Criterio As String, ByVal AUUSUARIOCREACION As String) As listaSOLICITUDES
        'Try
            Return mDb.FiltrarRangoFecha(FechaInicio, FechaFin, Criterio, AUUSUARIOCREACION)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' En esta función muestra las fechas de cambio de estado de una solicitud
    ''' </summary>
    ''' <param name="idSOLICITUD"></param> identificador de solicitud
    ''' <param name="idEstado"></param> identificador de estado de solicitud
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerFechaEstadoSolicitud(ByVal IDSOLICITUD As Int32, ByVal IDESTADO As Int32) As DataSet
        'Try
            Return mDb.DataSetHistoricoEstadoSolicitud(IDSOLICITUD, IDESTADO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' En esta función muestra las fechas de cambio de estado solicitudes
    ''' </summary>
    ''' <param name="IDESTADO"></param> identificador de estado
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerFechaEstados(ByVal IDESTADO As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        'Try
            Return mDb.DataSetHistoricoEstados(IDESTADO, IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' En esta función para dataset de reporte de solicitud
    ''' </summary>
    ''' <param name="idSOLICITUD"></param> identificador de solicitud
    ''' <param name="idEstablecimiento"></param> identificador de establecimiento
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDsSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, Optional ByVal esp As Integer = 0) As DataSet
        'Try
            Return mDb.DataSetSolicitud(IDSOLICITUD, IDESTABLECIMIENTO, esp)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ObtenerDsSolicitudProductoSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, Optional ByVal esp As Integer = 0) As DataSet
        'Try
            Return mDb.DataSetSolicitudProductoSolicitud(IDSOLICITUD, IDESTABLECIMIENTO, esp)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ObtenerLaSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDEMPLEADO As String) As DataSet
        'Try
            Return mDb.DataSetConSolicitud(IDSOLICITUD, IDESTABLECIMIENTO, IDEMPLEADO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerDsSolicitud2(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        'Try
            Return mDb.DataSetSolicitud2(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' En esta función valida si existe correlativo de solicitud
    ''' </summary>
    ''' <param name="idSolicitud"></param> identificador de solicitud
    ''' <param name="idCorrelativo"></param> id correlativo
    ''' <param name="idEstablecimiento"></param> identificador establecimiento
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarCorrelativoSolicitud(ByVal IDSOLICITUD As Int32, ByVal IDCORRELATIVO As String, ByVal IDESTABLECIMIENTO As Int32) As Boolean
        'Try
            Return mDb.ValidarCorrelativoSolicitud(IDSOLICITUD, IDCORRELATIVO, IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' En esta función valida si existe correlativo de solicitud
    ''' </summary>
    ''' <param name="idNumCorrelativo"></param> nemero correlativo
    ''' <param name="idEstablecimiento"></param> identificador establecimiento
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarNumeroCorrelativoSolicitud(ByVal IDNUMCORRELATIVO As Int32, ByVal IDESTABLECIMIENTO As Int32) As Boolean
        'Try
            Return mDb.ValidarNumeroCorrelativoSolicitud(IDNUMCORRELATIVO, IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ValidarCodigoSolicitud(ByVal CODIGO As String, ByVal IDESTABLECIMIENTO As Int32, Optional ByVal IDDEPENDENCIASOLICITANTE As Integer = 0) As Boolean
        'Try
            Return mDb.ValidarCodigoSolicitud(CODIGO, IDESTABLECIMIENTO, IDDEPENDENCIASOLICITANTE)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' En esta función se obtiene el proximo id de la solicitud
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo SOLICITUDES
    ''' <returns>
    ''' el id siguiente
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function id_Solicitud(ByVal aEntidad As SOLICITUDES) As Integer
        'Try
            Return mDb.ObtenerID(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' En esta función se obtiene el listado de solicitudes pero relacionandola con las siguientes tablas:
    ''' DEPENDENCIAS
    ''' TIPOPRODUCTOS
    ''' FUENTEFINANCIAMIENTOS
    ''' TIPOCOMPRAS
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador establecimiento
    ''' <param name="BFiltro"></param> dato a comparar
    ''' <param name="BCriterio"></param> campo a comparar con filtro
    ''' <param name="BOperador"></param> operador de comparacion
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor:Juan Rivas]      Creado
    ''' </history>
    Public Function Filtrar_VistaSolitud(ByVal IDESTABLECIMIENTO As Int64, ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String) As DataSet
        'Try
            Return mDb.Filtrar_VistaSolicitudes(IDESTABLECIMIENTO, Filtro, Criterio, Operador)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function Filtrar_VistaSolitudLG(ByVal IDESTABLECIMIENTO As Int64, ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal AUUSUARIOCREACION As String) As DataSet
        'Try
            Return mDb.Filtrar_VistaSolicitudesLG(IDESTABLECIMIENTO, Filtro, Criterio, Operador, AUUSUARIOCREACION)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' agregar una nueva solicitud
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo SOLICITUDES
    ''' <returns>
    ''' numero de registros afectados
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function AgregarSOLICITUDES(ByVal aEntidad As SOLICITUDES) As Integer
        'Try
            Return mDb.Agregar(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    ''' <summary>
    ''' Rechazar una solicitud
    ''' </summary>
    ''' <param name="aEntidad"></param>
    ''' <returns>
    ''' el numero de registros afectados con la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor:Juan Rivas]      Creado
    ''' </history>
    Public Function RechazarSolicitud(ByVal aEntidad As entidadBase) As Integer
        'Try
            Return mDb.RechazarSolicitud(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    ''' <summary>
    ''' Actualiza el estado de una solicitud de compras que ya esta grabada
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo SOLICITUD
    ''' <returns>
    ''' el numero de lineas afectadas con la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor:Juan Rivas]      Creado
    ''' </history>
    Public Function ActualizarEstado(ByVal aEntidad As entidadBase) As Integer
        'Try
            Return mDb.ActualizarEstado(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    ''' <summary>
    ''' Obtener el numero de correlativo
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo SOLICITUDES
    ''' <returns>
    ''' el correlativo siguiente
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history> 
    Public Function Correlativo_Solicitud(ByVal aEntidad As SOLICITUDES) As Integer
        'Try
            Return mDb.ObtenerCorrelativo(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' Funcion para actualizar las observaciones de la solicitud de compra
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo SOLICITUD
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <returns>
    ''' numero de registros afectados
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor:Juan Rivas]      Creado
    ''' </history>
    Public Function ActualizarObservacionSolicitud(ByVal aEntidad As entidadBase, ByVal IDESTABLECIMIENTO As Integer, ByVal IDSOLICITUD As Integer) As Integer
        'Try
            Return mDb.ActualizarObservacionSolicitud(aEntidad, IDESTABLECIMIENTO, IDSOLICITUD)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    ''' <summary>
    ''' Obtener el monto de la solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD"></param> identificador de la solicitud
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <returns>
    ''' monto de la solicitud
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history> 
    Public Function ObtenerMontoSolicitud(ByVal IDSOLICITUD As Int32, ByVal IDESTABLECIMIENTO As Int64) As Double
        'Try
            Return mDb.ObtenerMontoSolicitud(IDSOLICITUD, IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' Devuelve la información del plan de distribución para la solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que elaboro la consolidación.</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud.</param>
    ''' <returns>Dataset con la información del plan de distribución </returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history> 
    Public Function ObtenerDataSetDistribucionSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet
        'Try
            Return mDb.ObtenerDataSetDistribucionSolicitud(IDESTABLECIMIENTO, IDSOLICITUD)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' Validar que certificado de fondos no sea un campo nulo
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <returns>
    ''' verdadero si campo es nulo o vacio
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history>
    Public Function ValidarCertificadoFondosNulosSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As Boolean
        'Try
            Return mDb.ValidarCertificadoFondosNulosSolicitud(IDESTABLECIMIENTO, IDSOLICITUD)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' obtener el identificador suministro asociado a una solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <returns>
    ''' identificador de suministro
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history> 
    Public Function obtenerSuministroSolicitud(ByVal IDESTABLECIMIENTO As Integer, ByVal IDSOLICITUD As Integer) As Integer
        'Try
            Return mDb.obtenerSuministroSolicitud(IDESTABLECIMIENTO, IDSOLICITUD)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function obtenerIdSolicitud(ByVal IDESTABLECIMIENTO As Integer, ByVal correlativo As String) As Integer
        'Try
            Dim resultado As Integer
            resultado = mDb.obtenerIdSolicitud(IDESTABLECIMIENTO, correlativo)
            Return resultado
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function obtenerIdSolicitud2(ByVal IDESTABLECIMIENTO As Integer, ByVal iddependencia As Integer) As Integer
        'Try
            Return mDb.obtenerIdSolicitud2(IDESTABLECIMIENTO, iddependencia)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function


    ''' <summary>
    ''' En esta función se obtiene el listado de solicitudes filtrando por criterio o campo de solicitudes y un operador
    ''' </summary>
    ''' <param name="BFiltro"></param> dato a comparar 
    ''' <param name="BCriterio"></param> campo a comparar con filtro
    ''' <param name="BOperador"></param> operando de comparacion
    ''' <param name="BEstablecimiento"></param> identificador del establecimiento
    ''' <returns>
    ''' lista filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function FiltrarSolicitudesNoAsociadasProcesoCompra(ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal IDESTABLECIMIENTO As Int32) As listaSOLICITUDES
        'Try
            Return mDb.FiltrarSolicitudesNoAsociadasProcesoCompra(Filtro, Criterio, Operador, IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    '''  En esta función se obtiene el listado de solicitudes filtrando por rango de fecha
    ''' </summary>
    ''' <param name="BFechaInicio"></param> fecha de inicio
    ''' <param name="BFechaFin"></param> fecha de fin
    ''' <param name="BCriterio"></param> campo de fecha a filtrar
    ''' <param name="BEstablecimiento"></param> identificador de estabelcimiento
    ''' <returns>
    ''' listado filtrado
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function FiltrarRangoFechaSolicitudesSinProceso(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Criterio As String, ByVal IDESTABLECIMIENTO As Int32) As listaSOLICITUDES
        'Try
            Return mDb.FiltrarRangoFechaSolicitudesSinProceso(FechaInicio, FechaFin, Criterio, IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerSolicitudes(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        'Try
            Return mDb.ObtenerSolicitudes(IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerSolicitudesPorDependencia(ByVal IDESTABLECIMIENTO As Int32, ByVal IDDEPENDENCIA As Int32) As DataSet
        'Try
            Return mDb.ObtenerSolicitudesPorDependencia(IDESTABLECIMIENTO, IDDEPENDENCIA)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerSolicitudesLG(ByVal USUARIO As String) As DataSet
        'Try
            Return mDb.ObtenerSolicitudesLG(USUARIO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ObtenerSolicitudesEstablecimientosAutorizacion(ByVal iddependencia As Integer) As DataSet
        'Try
            Return mDb.ObtenerSolicitudesEstablecimientosAutorizacion(iddependencia)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ObtenerSolicitudesEstablecimientos(ByVal valor As String, ByVal tipob As Integer, Optional ByVal iddependencia As Integer = 0) As DataSet
        'Try
            Return mDb.ObtenerSolicitudesEstablecimientos(valor, tipob, iddependencia)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ObtenerSolicitudesEstablecimientosUT(ByVal valor As String, ByVal tipob As Integer, Optional ByVal iddependencia As Integer = 0) As DataSet
        'Try
            Return mDb.ObtenerSolicitudesEstablecimientosUT(valor, tipob, iddependencia)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ActualizarMontoSolicitado(ByVal aEntidad As entidadBase) As Integer
        'Try
            Return mDb.ActualizarMontoSolicitado(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ActualizarEntregas(ByVal aEntidad As entidadBase) As Integer
        'Try
            Return mDb.ActualizarEntregas(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function EliminarTodaLaSOLICITUD(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As Integer
        'Try

            'AES
            Dim caes As New cALMACENESENTREGASOLICITUD
            caes.borrarAlmacenesEntregaSolicitud(IDSOLICITUD, IDESTABLECIMIENTO)

            'ES
            Dim ces As New cENTREGASOLICITUDES
            ces.EliminarENTREGASXSolicitud(IDSOLICITUD, IDESTABLECIMIENTO)

            'DS
            Dim cds As New cDETALLESOLICITUDES
            cds.EliminarDetallesSolicitud(IDSOLICITUD, IDESTABLECIMIENTO)

            'PS
            cds.EliminarPRODUCTOSSolicitud(IDSOLICITUD, IDESTABLECIMIENTO)

            'AE
            cds.EliminarAlmacenesEntrega(IDSOLICITUD, IDESTABLECIMIENTO)

            'E
            cds.EliminarEntregas(IDSOLICITUD, IDESTABLECIMIENTO)

            'FFS
            Dim cff As New cFUENTEFINANCIAMIENTOSOLICITUDES
            cff.EliminarFUENTESSOLICITUD(IDSOLICITUD, IDESTABLECIMIENTO)

            'S
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDSOLICITUD = IDSOLICITUD
            Return mDb.Eliminar(mEntidad)

        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function ObtenerMontoProgramacionCompraSolicitudes(ByVal grupo As Integer) As Decimal
        'Try
            Return mDb.ObtenerMontoProgramacionCompraSolicitudes(grupo)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function CopiarProgramacionATemp2(ByVal grupo As Integer) As Integer
        'Try
            Return mDb.CopiarProgramacionATemp2(grupo)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function ObtenerSolicitudesEstablecimientosPorEstado(ByVal IDEstablecimiento As Integer, ByVal estado As estadoSolicititud) As DataSet
        'Try
            Return mDb.ObtenerSolicitudesEstablecimientosPorEstado(IDEstablecimiento, estado)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function CambioEstadoSolicitudesEstablecimientos(ByVal IDEstablecimiento As Integer, ByVal IDSolicitud As Integer, ByVal estado As estadoSolicititud) As Integer
        'Try
            Return mDb.CambioEstadoSolicitudesEstablecimientosPorEstado(IDEstablecimiento, IDSolicitud, estado)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
#End Region
End Class
