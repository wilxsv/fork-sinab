Partial Public Class cNECESIDADESTABLECIMIENTOS

#Region " METODOS AGREGADOS"
    ''' <summary>
    ''' Devuelve un listado de las diferentes propuestas en evaluación para un período específico.
    ''' </summary>
    ''' <param name="BPERIODO">Identificador del período de trabajo, es un valor de tipo númerico.</param>
    ''' <returns>Dataset con el listado de las propuestas activas.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  03/10/2006    Creado
    ''' </history>
    Public Function ObtenerPeriodos(ByVal BPERIODO As Int32) As DataSet
        Return mDb.ObtenerPeriodos(BPERIODO)
    End Function

    ''' <summary>
    ''' Obtiene el listado de las estimaciones de necesidades filtrado para un período y número de propuesta especifica,
    ''' recupera solo la información de la tabla padre.
    ''' </summary>
    ''' <param name="BPERIODO">Período al cual sera aplicado esta función.</param>
    ''' <param name="BPROPUESTA">Identificador del número de la propuesta seleccionada.</param>
    ''' <returns>Dataset con el listado de las necesidades.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  03/10/2006    Creado
    ''' </history> 
    Public Function FiltrarEstimacionNecesidades(ByVal BPERIODO As Int32, ByVal BPROPUESTA As Int16) As DataSet
        Try
            Return mDb.FiltrarEstimacionNecesidades(BPERIODO, BPROPUESTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Dataset con la infomacion del calculo de necesidades
    ''' </summary>
    ''' <param name="idEstablecimiento"></param> identificador de estabelcimiento
    ''' <param name="idNecesidad"></param> identiicador de necesidad
    ''' <returns>
    ''' datset con la informacionsolicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDsNecesidad(ByVal idEstablecimiento As Int32, ByVal idNecesidad As Int32) As DataSet
        Return mDb.DataSetNecesidad(idEstablecimiento, idNecesidad)
    End Function

    ''' <summary>
    ''' Obtiene un listado con las necesidades filtrada por el período y propuesta seleccionada.
    ''' </summary>
    ''' <param name="IDTIPOESTABLECIMIENTO">Identificador del tipo de establecimiento.</param>
    ''' <param name="ANNIO">Período al cual sera aplicado esta función.</param>
    ''' <param name="IDPROPUESTA">Identificador del número de la propuesta seleccionada.</param>
    ''' <returns>Dataset con el listado de las necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  07/12/2006    Creado
    ''' </history>
    Public Function obtenerDsConsultaEstimacionNecesidad(ByVal IDTIPOESTABLECIMIENTO As Int64, ByVal ANNIO As Int64, ByVal IDPROPUESTA As Int16) As DataSet
        Return mDb.obtenerDsConsultaEstimacionNecesidades(IDTIPOESTABLECIMIENTO, ANNIO, IDPROPUESTA)
    End Function

    ''' <summary>
    ''' Actualiza el estado a la necesidad.
    ''' </summary>
    ''' <param name="aEntidad"> Entidad con todos los atributos de la necesidad de compra.</param>
    ''' <returns>Un numero entero indicando si la actualizacion fue exitosa o no.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history>
    Public Function ActualizarEstados(ByVal aEntidad As NECESIDADESTABLECIMIENTOS) As Integer
        Try
            Return mDb.ActualizarEstado(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Agregar un nuevo programa de compras
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo NECESIDADESESTABLECIMIENTOS
    ''' <returns>
    ''' numero de registros afectados por la operación
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function AgregarNECESIDADESTABLECIMIENTOS(ByVal aEntidad As NECESIDADESTABLECIMIENTOS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Obtener id de un programa de compras nuevo
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo NECECIDADESESTABLECIMIENTOS
    ''' <returns>
    ''' Identificador del programa de compras
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerID(ByVal aEntidad As NECESIDADESTABLECIMIENTOS) As Integer
        Try
            Return mDb.ObtenerID(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' obtiene el numero correlativo
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo NECECIDADESESTABLECIMIENTOS
    ''' <returns>
    ''' El numero correlativo
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerCorrelativo(ByRef aEntidad As NECESIDADESTABLECIMIENTOS) As Integer
        Try
            Return mDb.ObtenerCorrelativo(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' obtener propuesta
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo NRCESIDADESESTABLECIMIENTOS
    ''' <returns>
    ''' numero de propuesta
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerPropuesta(ByRef aEntidad As NECESIDADESTABLECIMIENTOS) As Integer
        Try
            Return mDb.ObtenerPropuesta(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Devuelve un listado con las necesidades filtrada por el periodo y la propuesta seleccionada
    ''' pero consolidado por SIBASI, recupera información de la tabla padre.
    ''' </summary>
    ''' <param name="ANNIO">Es el año para el cual se desea trabajar.</param>
    ''' <param name="IDPROPUESTA">El identificador de la propuesta bajo la cual trabaja la función.</param>
    ''' <returns>Dataset con el consolidado de las necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  10/12/2006    Creado
    ''' </history> 
    Public Function obtenerDsConsultaEstimacionNecesidadesPorSibasi(ByVal ANNIO As Int64, ByVal IDPROPUESTA As Int16) As DataSet
        Return mDb.obtenerDsConsultaEstimacionNecesidadesPorSibasi(ANNIO, IDPROPUESTA)
    End Function

    ''' <summary>
    ''' Devuelve un listado con el detalle de las necesidades filtrada por el periodo y la propuesta seleccionada
    ''' pero consolidado por SIBASI. 
    ''' </summary>
    ''' <param name="ANNIO">Es el año para el cual se desea trabajar.</param>
    ''' <param name="IDPROPUESTA">El identificador de la propuesta bajo la cual trabaja la función.</param>
    ''' <param name="IDSIBASI">El identificador del SIBASI a consultar.</param>
    ''' <param name="TIPOCRITERIO">Indica el campo que desea utilizar para el filtro especifico.</param>
    ''' <param name="CADENABUSQUEDA">Cadena de busqueda aplicada al criterio especificado.</param>
    ''' <returns>Dataset con el consolidado detallado de las necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  10/12/2006    Creado
    ''' </history> 
    Public Function ObtenerDsDetalleEstimacionNecesidadesPorSibasi(ByVal ANNIO As Int64, ByVal IDPROPUESTA As Int16, ByVal IDSIBASI As Int32, ByVal TIPOCRITERIO As Int16, ByVal CADENABUSQUEDA As String) As DataSet
        Return mDb.ObtenerDsDetalleEstimacionNecesidadesPorSibasi(ANNIO, IDPROPUESTA, IDSIBASI, TIPOCRITERIO, CADENABUSQUEDA)
    End Function

    ''' <summary>
    ''' Devuelve la información de los presupuestos del consolidado a nivel nacional.
    ''' </summary>
    ''' <param name="IDPERIODO">Es el año para el cual se desea trabajar.</param>
    ''' <param name="IDPROPUESTA">El identificador de la propuesta bajo la cual trabaja la función.</param>
    ''' <returns>Dataset con la información de los presupuestos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  25/12/2006    Creado
    ''' </history>
    Public Function ConsultaPresupuestosDS(ByVal IDPERIODO As Int16, ByVal IDPROPUESTA As Int16) As DataSet
        Return mDb.ConsultaPresupuestosDS(IDPERIODO, IDPROPUESTA)
    End Function

    ''' <summary>
    ''' Devuelve la información de los presupuestos del consolidado a nivel de SIBASI o Región.
    ''' </summary>
    ''' <param name="IDPERIODO">Es el año para el cual se desea trabajar.</param>
    ''' <param name="IDPROPUESTA">El identificador de la propuesta bajo la cual trabaja la función.</param>
    ''' <param name="IDSIBASI">Identificador del SIBASI a consultar.</param>
    ''' <returns>Dataset con la información de los presupuestos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  25/12/2006    Creado
    ''' </history>
    Public Function ConsultaPresupuestosPorSibasiDS(ByVal IDPERIODO As Int16, ByVal IDPROPUESTA As Int16, ByVal IDSIBASI As Int32) As DataSet
        Return mDb.ConsultaPresupuestosPorSibasiDS(IDPERIODO, IDPROPUESTA, IDSIBASI)
    End Function

    ''' <summary>
    ''' Devuelve la información de una estimación de necesidades especifica.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento en el que fue elaborada.</param>
    ''' <param name="IDNECESIDAD">Identificador de la estimación solicitada.</param>
    ''' <returns>Dataset con la información de la estimación de necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  09/01/2007    Creado
    ''' </history>
    Public Function ObtenerNecesidadPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As DataSet
        Return mDb.ObtenerNecesidadPorID(IDESTABLECIMIENTO, IDNECESIDAD)
    End Function

    ''' <summary>
    ''' obtener presupuesto mensual
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimientos
    ''' <param name="IDNECESIDAD"></param> identificador de necesidad
    ''' <returns>
    ''' presupueto del programa de compras
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history>
    Public Function ObtenerPresupuestoNecesidad(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Double
        Return mDb.ObtenerPresupuesto(IDESTABLECIMIENTO, IDNECESIDAD)
    End Function

    ''' <summary>
    ''' Obtiene el listado de las estimaciones de necesidades filtrado para un período,propuesta y programa especifico,
    ''' recupera solo la información de la tabla padre.
    ''' </summary>
    ''' <param name="BPERIODO">Período al cual sera aplicado esta función.</param>
    ''' <param name="BPROPUESTA">Identificador del número de la propuesta seleccionada.</param>
    ''' <param name="IDPROGRAMA">Identificador del programa seleccionado.</param>
    ''' <returns>Dataset con el listado de las necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  03/10/2006    Creado
    ''' </history> 
    Public Function FiltrarEstimacionNecesidadesConProgramas(ByVal BPERIODO As Int32, ByVal BPROPUESTA As Int16, ByVal IDPROGRAMA As Int32) As DataSet
        Return mDb.FiltrarEstimacionNecesidadesConProgramas(BPERIODO, BPROPUESTA, IDPROGRAMA)
    End Function

    Public Function ObtenerIDN() As Integer
        Return mDb.ObtenerIDN()
    End Function

#End Region

#Region " METODOS CALCULO NECESIDADES"
    ''' <summary>
    ''' Obtener periodo de compras
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificdor de establecimiento
    ''' <param name="IDNECESIDAD"></param> identificador de necesidad
    ''' <returns>
    ''' periodo de compras
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history> 
    Public Function ObtenerPeriododeCompras(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer
        Return mDb.ObtenerPeriododeCompras(IDESTABLECIMIENTO, IDNECESIDAD)
    End Function

    ''' <summary>
    ''' obtener el consumo mensual por Sibasi
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de estabelcimiento
    ''' <param name="IDPRODUCTO"></param> identificador de prueba
    ''' <param name="MESCONSUMO"></param> entero identificando mes de consumo
    ''' <param name="ANIOCONSUMO"></param> entero identificando año de consumo
    ''' <returns>
    ''' consumo mensual de sibasi
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history> 
    Public Function ObtenerConsumoMensualSibasi(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double
        Return mDb.ObtenerConsumoMensualSibasi(IDESTABLECIMIENTO, IDPRODUCTO, MESCONSUMO, ANIOCONSUMO)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador de producto
    ''' <param name="MESCONSUMO"></param> entero mes de consumo
    ''' <param name="ANIOCONSUMO"></param> entero año de consumo
    ''' <returns>
    ''' demanda instisfecha mensual para la sibasi
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history> 
    Public Function ObtenerDemandaMensualSibasi(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double
        Return mDb.ObtenerDemandaMensualSibasi(IDESTABLECIMIENTO, IDPRODUCTO, MESCONSUMO, ANIOCONSUMO)
    End Function

    ''' <summary>
    ''' obtener existencia mensual del sibasi
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador de producto
    ''' <param name="MESCONSUMO"></param> entero mes de consumo
    ''' <param name="ANIOCONSUMO"></param> entero año de consumo
    ''' <returns>
    ''' existencias mensuales Sibasi
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history> 
    Public Function ObtenerExistenciasMensualSibasi(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double
        Return mDb.ObtenerExistenciasMensualSibasi(IDESTABLECIMIENTO, IDPRODUCTO, MESCONSUMO, ANIOCONSUMO)
    End Function

    ''' <summary>
    ''' Obtener consumo mensual establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador producto
    ''' <param name="MESCONSUMO"></param> entero mes consumo
    ''' <param name="ANIOCONSUMO"></param> entero año consumo
    ''' <returns>
    ''' consumo mensual del establecimiento
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history>
    Public Function ObtenerConsumoMensualEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double
        Return mDb.ObtenerConsumoMensualEstablecimiento(IDESTABLECIMIENTO, IDPRODUCTO, MESCONSUMO, ANIOCONSUMO)
    End Function

    ''' <summary>
    ''' Obtener la demanda nmensual del establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <param name="MESCONSUMO"></param> entero mes del consumo
    ''' <param name="ANIOCONSUMO"></param> entero año del consumo
    ''' <returns>
    ''' Demanda mensual establecimiento
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history>
    Public Function ObtenerDemandaMensualEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double
        Return mDb.ObtenerDemandaMensualEstablecimiento(IDESTABLECIMIENTO, IDPRODUCTO, MESCONSUMO, ANIOCONSUMO)
    End Function

    ''' <summary>
    ''' obtener existencia mensual del establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <param name="MESCONSUMO"></param> entero del mes de consumo
    ''' <param name="ANIOCONSUMO"></param> entero del año de consumo
    ''' <returns>
    ''' existencia mensual del establecimiento
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history>
    Public Function ObtenerExistenciasMensualEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double
        Return mDb.ObtenerExistenciasMensualEstablecimiento(IDESTABLECIMIENTO, IDPRODUCTO, MESCONSUMO, ANIOCONSUMO)
    End Function

    ''' <summary>
    ''' Obtener compras de transito de establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <param name="FECHACORTE"></param> fecha de corte
    ''' <returns>
    ''' compras en transito
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerComprasTransitoEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal FECHACORTE As Date) As Double
        Return mDb.ObtenerComprasTransitoEstablecimiento(IDESTABLECIMIENTO, IDPRODUCTO, FECHACORTE)
    End Function

    ''' <summary>
    ''' Obtener el mes inicial
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimientos
    ''' <param name="IDNECESIDAD"></param> identificador de la necesidad
    ''' <returns>
    ''' </returns>
    ''' entero como mes inicial
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerMesInicial(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer
        Return mDb.ObtenerMesInicial(IDESTABLECIMIENTO, IDNECESIDAD)
    End Function

    ''' <summary>
    ''' Obtener mes final
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDNECESIDAD"></param>
    ''' <returns>
    ''' entero como mes final para el calculo de necesidades
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerMesFinal(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer
        Return mDb.ObtenerMesFinal(IDESTABLECIMIENTO, IDNECESIDAD)
    End Function

    ''' <summary>
    ''' Obtener año final
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDNECESIDAD"></param> identificador de la necesidad
    ''' <returns>
    ''' entero como año inicial para el calculo de necesidades
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerAñoInicial(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer
        Return mDb.ObtenerAñoInicial(IDESTABLECIMIENTO, IDNECESIDAD)
    End Function

    ''' <summary>
    ''' Obtener año final
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDNECESIDAD"></param> identificdor de la necesidad
    ''' <returns>
    ''' entero como año final
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerAñoFinal(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer
        Return mDb.ObtenerAñoFinal(IDESTABLECIMIENTO, IDNECESIDAD)
    End Function

    ''' <summary>
    ''' Obtener existencia disponible no vencida
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <param name="FECHACORTE"></param> Fecha de corte
    ''' <param name="FECHAFIN"></param> fecha fin
    ''' <returns>
    ''' existencia desponible no vencida
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerExistenciaDisponibleNoVencida(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal FECHACORTE As Date, ByVal FECHAFIN As Date) As Double
        Return mDb.ObtenerExistenciaDisponibleNoVencida(IDESTABLECIMIENTO, IDPRODUCTO, FECHACORTE, FECHAFIN)
    End Function

    ''' <summary>
    ''' obtener la existencia que vence en el plazo de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <param name="FECHACORTE"></param> fecha de corte
    ''' <param name="FECHAINICIO"></param> fecha de inicio 
    ''' <param name="FECHAFIN"></param> fecha de fin
    ''' <returns>
    ''' existencia que vence en el plazo de compra
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerExistenciaVencePlazoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal FECHACORTE As Date, ByVal FECHAINICIO As Date, ByVal FECHAFIN As Date) As DataSet
        Return mDb.ObtenerExistenciaVencePlazoCompra(IDESTABLECIMIENTO, IDPRODUCTO, FECHACORTE, FECHAINICIO, FECHAFIN)
    End Function

#End Region

End Class
