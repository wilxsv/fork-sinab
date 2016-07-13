Partial Public Class dbNECESIDADESTABLECIMIENTOS

#Region " METODOS AGREGADOS"

    ''' <summary>
    ''' Actualiza el estado a la necesidad.
    ''' </summary>
    ''' <param name="aEntidad"> Entidad con todos los atributos de la necesidad de compra.</param>
    ''' <returns>Un numero entero indicando si la actualizacion fue exitosa o no.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ActualizarEstado(ByVal aEntidad As NECESIDADESTABLECIMIENTOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append("SET IDESTADO = @IDESTADO ")
        strSQL.Append("WHERE IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTADO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDNECESIDAD

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el listado de las estimaciones de necesidades filtrado para un período y número de propuesta especifica,
    ''' recupera solo la información de la tabla padre.
    ''' </summary>
    ''' <param name="PERIODO">Período al cual sera aplicado esta función.</param>
    ''' <param name="PROPUESTA">Identificador del número de la propuesta seleccionada.</param>
    ''' <returns>Dataset con el listado de las necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  03/10/2006    Creado
    ''' </history> 
    Public Function FiltrarEstimacionNecesidades(ByVal PERIODO As Int32, ByVal PROPUESTA As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDESTABLECIMIENTO, ")
        strSQL.Append("IDNECESIDAD, ")
        strSQL.Append("PROPUESTA, ")
        strSQL.Append("CORRELATIVO, ")
        strSQL.Append("IDESTADO, ")
        strSQL.Append("ANIOFINPERIODO, ")
        strSQL.Append("IDSUMINISTRO ")
        strSQL.Append("FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append("WHERE ANIOFINPERIODO = @PERIODO AND PROPUESTA = @PROPUESTA AND IDESTADO = 2 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@PERIODO", SqlDbType.Int)
        args(0).Value = PERIODO
        args(1) = New SqlParameter("@PROPUESTA", SqlDbType.Int)
        args(1).Value = PROPUESTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el listado de las estimaciones de necesidades filtrado para un período y número de propuesta especifica,
    ''' recupera solo la información de la tabla padre.
    ''' </summary>
    ''' <param name="PERIODO">Período al cual sera aplicado esta función.</param>
    ''' <param name="PROPUESTA">Identificador del número de la propuesta seleccionada.</param>
    ''' <returns>Dataset con el listado de las necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  03/10/2006    Creado
    ''' </history> 
    Public Function ValidarExistenciaProductosNecesidades(ByVal PERIODO As Int32, ByVal PROPUESTA As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDESTABLECIMIENTO, ")
        strSQL.Append("IDNECESIDAD, ")
        strSQL.Append("PROPUESTA, ")
        strSQL.Append("CORRELATIVO, ")
        strSQL.Append("IDESTADO, ")
        strSQL.Append("ANIOFINPERIODO, ")
        strSQL.Append("IDSUMINISTRO ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ")
        strSQL.Append("WHERE ANIOFINPERIODO = @PERIODO AND PROPUESTA = @PROPUESTA AND IDESTADO = 2 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@PERIODO", SqlDbType.Int)
        args(0).Value = PERIODO
        args(1) = New SqlParameter("@PROPUESTA", SqlDbType.Int)
        args(1).Value = PROPUESTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

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
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_CAT_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_CARGOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetNecesidad(ByVal idEstablecimiento As Int32, ByVal idNecesidad As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("NE.IDESTABLECIMIENTO, ")
        strSQL.Append("NE.IDNECESIDAD, ")
        strSQL.Append("NE.PROPUESTA, ")
        strSQL.Append("NE.CORRELATIVO, ")
        strSQL.Append("NE.FECHAELABORACION, ")
        strSQL.Append("NE.PERIODOUTILIZACION, ")
        strSQL.Append("NE.MESINICIOPERIODO, ")
        strSQL.Append("NE.ANIOINICIOPERIODO, ")
        strSQL.Append("NE.MESFINPERIODO, ")
        strSQL.Append("NE.ANIOFINPERIODO, ")
        strSQL.Append("NE.PRESUPUESTOASIGNADO, ")
        strSQL.Append("NE.MONTONECESIDADREAL, ")
        strSQL.Append("NE.MONTONECESIDADAJUSTADA, ")
        strSQL.Append("CP.IDPRODUCTO, ")
        strSQL.Append("CP.CODIGO, ")
        strSQL.Append("CP.NOMBRE AS PRODUCTO, ")
        strSQL.Append("CP.CONCENTRACION, ")
        strSQL.Append("CP.PRESENTACION, ")
        strSQL.Append("UM.DESCRIPCION AS UNIDAD, ")
        strSQL.Append("E.NOMBRE AS ESTABLECIMIENTO, ")
        strSQL.Append("E.NIVEL, ")
        strSQL.Append("DNE.CONSUMOANUAL, ")
        strSQL.Append("DNE.DEMANDAINSATISFECHA, ")
        strSQL.Append("DNE.RESERVAESTABLECIMIENTO, ")
        strSQL.Append("DNE.RESERVATOTAL, ")
        strSQL.Append("DNE.EXISTENCIAESTIMADA, ")
        strSQL.Append("DNE.PRECIOUNITARIO, ")
        strSQL.Append("DNE.NECESIDADREAL, ")
        strSQL.Append("DNE.NECESIDADAJUSTADA, ")
        strSQL.Append("DNE.NECESIDADFINAL, ")
        strSQL.Append("DNE.PRESUPUESTOREAL, ")
        strSQL.Append("DNE.PRESUPUESTOAJUSTADO, ")
        strSQL.Append("DNE.PRESUPUESTOFINAL, ")
        strSQL.Append("DNE.COSTOTOTALREAL, ")
        strSQL.Append("DNE.COSTOTOTALAJUSTADO, ")
        strSQL.Append("DNE.COMPRASENTRANSITO, ")
        strSQL.Append("A.NOMBRE AS ALMACEN, ")
        strSQL.Append("S.DESCRIPCION AS SUMINISTRO, ")
        strSQL.Append("CP.FORMAFARMACEUTICA, ")
        strSQL.Append("EM.NOMBRE, ")
        strSQL.Append("EM.APELLIDO, ")
        strSQL.Append("C.DESCRIPCION AS CARGO, ")
        strSQL.Append("NE.IDESTADO ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS DNE ")
        strSQL.Append("INNER JOIN SAB_EST_NECESIDADESTABLECIMIENTOS NE ")
        strSQL.Append("ON DNE.IDNECESIDAD = NE.IDNECESIDAD ")
        strSQL.Append("AND DNE.IDESTABLECIMIENTO = NE.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
        strSQL.Append("ON DNE.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("INNER JOIN SAB_CAT_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DNE.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON NE.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON NE.IDALMACENENTREGA = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON NE.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ")
        strSQL.Append("ON NE.IDEMPLEADO = EM.IDEMPLEADO ")
        strSQL.Append("INNER JOIN SAB_CAT_CARGOS C ")
        strSQL.Append("ON EM.IDCARGO = C.IDCARGO ")
        strSQL.Append("WHERE ")
        strSQL.Append("NE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND NE.IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND (DNE.NECESIDADAJUSTADA > 0 OR DNE.NECESIDADREAL > 0) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = idNecesidad

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene un listado con las necesidades filtrada por el período y propuesta seleccionada.
    ''' </summary>
    ''' <param name="IDTIPOESTABLECIMIENTO">Identificador del tipo de establecimiento.</param>
    ''' <param name="ANNIO">Período al cual sera aplicado esta función.</param>
    ''' <param name="IDPROPUESTA">Identificador del número de la propuesta seleccionada.</param>
    ''' <returns>Dataset con el listado de las necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTADOSNECESIDADES</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  07/12/2006    Creado
    ''' </history>
    Public Function obtenerDsConsultaEstimacionNecesidades(ByVal IDTIPOESTABLECIMIENTO As Int64, ByVal ANNIO As Int64, ByVal IDPROPUESTA As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("ES.NOMBRE, ")
        strSQL.Append("NE.FECHAELABORACION, ")
        strSQL.Append("NE.ANIOFINPERIODO AS Anno, ")
        strSQL.Append("EN.DESCRIPCION AS Estado, ")
        strSQL.Append("NE.IDESTABLECIMIENTO, ")
        strSQL.Append("NE.IDNECESIDAD, NE.PROPUESTA, ")
        strSQL.Append("NE.PRESUPUESTOASIGNADO, ")
        strSQL.Append("NE.MONTONECESIDADREAL, ")
        strSQL.Append("NE.MONTONECESIDADAJUSTADA, ")
        strSQL.Append("NE.MONTONECESIDADFINAL ")
        strSQL.Append("FROM SAB_EST_NECESIDADESTABLECIMIENTOS AS NE ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS AS ES ")
        strSQL.Append("ON NE.IDESTABLECIMIENTO = ES.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOESTABLECIMIENTOS TE ")
        strSQL.Append("ON ES.IDTIPOESTABLECIMIENTO = TE.IDTIPOESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSNECESIDADES EN ")
        strSQL.Append("ON NE.IDESTADO = EN.IDESTADONECESIDAD ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES ")
        strSQL.Append("ON NE.IDALMACENENTREGA = SAB_CAT_ALMACENES.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS ")
        strSQL.Append("ON NE.IDSUMINISTRO = SAB_CAT_SUMINISTROS.IDSUMINISTRO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(NE.IDESTADO = 2) ")
        strSQL.Append("AND (NE.ANIOFINPERIODO = @ANNIO) ")
        strSQL.Append("AND (NE.PROPUESTA = @IDPROPUESTA) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@TIPOESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDTIPOESTABLECIMIENTO
        args(1) = New SqlParameter("@ANNIO", SqlDbType.Int)
        args(1).Value = ANNIO
        args(2) = New SqlParameter("@IDPROPUESTA", SqlDbType.Int)
        args(2).Value = IDPROPUESTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtiene el numero correlativo
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo NECECIDADESESTABLECIMIENTOS
    ''' <returns>
    ''' El numero correlativo
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerCorrelativo(ByVal aEntidad As NECESIDADESTABLECIMIENTOS) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(CORRELATIVO),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' obtener propuesta
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo NRCESIDADESESTABLECIMIENTOS
    ''' <returns>
    ''' numero de propuesta
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerPropuesta(ByVal aEntidad As NECESIDADESTABLECIMIENTOS) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(PROPUESTA),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND ANIOFINPERIODO = @ANNIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@ANNIO", SqlDbType.Int)
        args(1).Value = aEntidad.ANIOFINPERIODO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve un listado de las diferentes propuestas en evaluación para un período específico.
    ''' </summary>
    ''' <param name="PERIODO">Identificador del período de trabajo, es un valor de tipo númerico.</param>
    ''' <returns>Dataset con el listado de las propuestas activas.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  03/10/2006    Creado
    ''' </history> 
    Public Function ObtenerPeriodos(ByVal PERIODO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PROPUESTA, ")
        strSQL.Append("ANIOFINPERIODO, ")
        strSQL.Append("('X') as NOMBRE ")
        strSQL.Append("FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append("WHERE ")
        strSQL.Append("ANIOFINPERIODO = @PERIODO ")
        strSQL.Append("GROUP BY PROPUESTA, ANIOFINPERIODO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@PERIODO", SqlDbType.Int)
        args(0).Value = PERIODO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve un listado con las necesidades filtrada por el periodo y la propuesta seleccionada
    ''' pero consolidado por SIBASI, recupera información de la tabla padre.
    ''' </summary>
    ''' <param name="ANNIO">Es el año para el cual se desea trabajar.</param>
    ''' <param name="IDPROPUESTA">El identificador de la propuesta bajo la cual trabaja la función.</param>
    ''' <returns>Dataset con el consolidado de las necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTADOSNECESIDADES</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  10/12/2006    Creado
    ''' </history> 
    Public Function obtenerDsConsultaEstimacionNecesidadesPorSibasi(ByVal ANNIO As Int64, ByVal IDPROPUESTA As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("ES.IDPADRE, ")
        strSQL.Append("(SELECT NOMBRE FROM SAB_CAT_ESTABLECIMIENTOS WHERE (IDESTABLECIMIENTO = ES.IDPADRE)) AS NOMBRE, ")
        strSQL.Append("NE.ANIOFINPERIODO AS Anno, ")
        strSQL.Append("EN.DESCRIPCION AS Estado, ")
        strSQL.Append("NE.PROPUESTA, ")
        strSQL.Append("NE.IDESTADO, ")
        strSQL.Append("SUM(NE.PRESUPUESTOASIGNADO) AS PRESUPUESTOASIGNADO, ")
        strSQL.Append("SUM(NE.MONTONECESIDADREAL) AS MONTONECESIDADREAL, ")
        strSQL.Append("SUM(NE.MONTONECESIDADAJUSTADA) AS MONTONECESIDADAJUSTADA, ")
        strSQL.Append("SUM(NE.MONTONECESIDADFINAL) AS MONTONECESIDADFINAL ")
        strSQL.Append("FROM SAB_EST_NECESIDADESTABLECIMIENTOS AS NE ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS AS ES ")
        strSQL.Append("ON NE.IDESTABLECIMIENTO = ES.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOESTABLECIMIENTOS TE ")
        strSQL.Append("ON ES.IDTIPOESTABLECIMIENTO = TE.IDTIPOESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSNECESIDADES EN ")
        strSQL.Append("ON NE.IDESTADO = EN.IDESTADONECESIDAD ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON NE.IDALMACENENTREGA = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON NE.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("WHERE (ES.IDPADRE IN (SELECT IDESTABLECIMIENTO FROM SAB_CAT_ESTABLECIMIENTOS AS ESTABLECIMIENTOS_1 WHERE (IDTIPOESTABLECIMIENTO = 2))) ")
        strSQL.Append("AND (NE.ANIOFINPERIODO = @ANNIO) AND (NE.PROPUESTA = @IDPROPUESTA) AND (NE.IDESTADO = 2) ")
        strSQL.Append("GROUP BY ES.IDPADRE, NE.ANIOFINPERIODO, EN.DESCRIPCION, NE.PROPUESTA, NE.IDESTADO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@ANNIO", SqlDbType.Int)
        args(0).Value = ANNIO
        args(1) = New SqlParameter("@IDPROPUESTA", SqlDbType.Int)
        args(1).Value = IDPROPUESTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

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
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTADOSNECESIDADES</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  10/12/2006    Creado
    ''' </history> 
    Public Function ObtenerDsDetalleEstimacionNecesidadesPorSibasi(ByVal ANNIO As Int64, ByVal IDPROPUESTA As Int16, ByVal IDSIBASI As Int32, ByVal TIPOCRITERIO As Int16, ByVal CADENABUSQUEDA As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("ES.IDPADRE, ")
        strSQL.Append("(SELECT NOMBRE FROM SAB_CAT_ESTABLECIMIENTOS WHERE (IDESTABLECIMIENTO = ES.IDPADRE)) AS NOMBRE, ")
        strSQL.Append("NE.ANIOFINPERIODO AS Anno, ")
        strSQL.Append("EN.DESCRIPCION AS Estado, ")
        strSQL.Append("NE.PROPUESTA, DNE.IDPRODUCTO, ")
        strSQL.Append("DNE.IDUNIDADMEDIDA, ")
        strSQL.Append("SUM(DNE.CONSUMOANUAL) AS CONSUMOANUAL, ")
        strSQL.Append("SUM(DNE.DEMANDAINSATISFECHA) AS DEMANDAINSATISFECHA, ")
        strSQL.Append("SUM(DNE.RESERVAESTABLECIMIENTO) AS RESERVAESTABLECIMIENTO, ")
        strSQL.Append("(SUM(DNE.CONSUMOANUAL) + SUM(DNE.DEMANDAINSATISFECHA) + SUM(DNE.RESERVAESTABLECIMIENTO)) AS TOTAL, ")
        strSQL.Append("SUM(DNE.RESERVATOTAL) AS RESERVATOTAL, ")
        strSQL.Append("SUM(DNE.EXISTENCIAESTIMADA) AS EXISTENCIAESTIMADA, ")
        strSQL.Append("MAX(DNE.PRECIOUNITARIO) AS PRECIOUNITARIO, ")
        strSQL.Append("SUM(DNE.NECESIDADREAL) AS NECESIDADREAL, ")
        strSQL.Append("SUM(DNE.NECESIDADAJUSTADA) AS NECESIDADAJUSTADA, ")
        strSQL.Append("SUM(DNE.NECESIDADFINAL) AS NECESIDADFINAL, ")
        strSQL.Append("(MAX(DNE.PRECIOUNITARIO) * SUM(DNE.NECESIDADREAL)) AS PRESUPUESTOARTICULO, ")
        strSQL.Append("(MAX(DNE.PRECIOUNITARIO) * SUM(DNE.NECESIDADAJUSTADA)) AS PRESUPUESTOARTICULOAJUSTADO, ")
        strSQL.Append("(MAX(DNE.PRECIOUNITARIO) * SUM(DNE.NECESIDADFINAL)) AS PRESUPUESTOARTICULOFINAL, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO ")
        strSQL.Append("FROM SAB_EST_NECESIDADESTABLECIMIENTOS AS NE ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS AS ES ")
        strSQL.Append("ON NE.IDESTABLECIMIENTO = ES.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOESTABLECIMIENTOS TE ")
        strSQL.Append("ON ES.IDTIPOESTABLECIMIENTO = TE.IDTIPOESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSNECESIDADES EN ")
        strSQL.Append("ON NE.IDESTADO = EN.IDESTADONECESIDAD ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON NE.IDALMACENENTREGA = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON NE.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLENECESIDADESTABLECIMIENTOS AS DNE ")
        strSQL.Append("ON NE.IDNECESIDAD = DNE.IDNECESIDAD ")
        strSQL.Append("And NE.IDESTABLECIMIENTO = DNE.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS AS CP ")
        strSQL.Append("ON DNE.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE (ES.IDPADRE IN (SELECT IDESTABLECIMIENTO FROM SAB_CAT_ESTABLECIMIENTOS AS ESTABLECIMIENTOS_1 WHERE (IDTIPOESTABLECIMIENTO = 2))) ")
        strSQL.Append("AND (NE.ANIOFINPERIODO = @ANNIO) AND (NE.PROPUESTA = @IDPROPUESTA) AND (ES.IDPADRE = @IDSIBASI) ")

        Select Case TIPOCRITERIO
            Case Is = 1
                strSQL.Append(" AND (CP.IDGRUPO = @CADENABUSQUEDA) ")
            Case Is = 2
                strSQL.Append(" AND (CP.IDSUBGRUPO = @CADENABUSQUEDA) ")
            Case Is = 3
                strSQL.Append(" AND (CP.CORRPRODUCTO = @CADENABUSQUEDA) ")
            Case Is = 4
                strSQL.Append(" AND (CP.IDSUMINISTRO = @CADENABUSQUEDA) ")
        End Select

        strSQL.Append("GROUP BY ES.IDPADRE, NE.ANIOFINPERIODO, EN.DESCRIPCION, NE.PROPUESTA, DNE.IDPRODUCTO, ")
        strSQL.Append("DNE.IDUNIDADMEDIDA, CP.IDGRUPO, CP.IDSUBGRUPO, CP.CORRPRODUCTO, CP.DESCLARGO ")
        strSQL.Append(" ORDER BY CP.CORRPRODUCTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@ANNIO", SqlDbType.Int)
        args(0).Value = ANNIO
        args(1) = New SqlParameter("@IDPROPUESTA", SqlDbType.Int)
        args(1).Value = IDPROPUESTA
        args(2) = New SqlParameter("@IDSIBASI", SqlDbType.Int)
        args(2).Value = IDSIBASI
        args(3) = New SqlParameter("@CADENABUSQUEDA", SqlDbType.VarChar)
        args(3).Value = CADENABUSQUEDA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información de los presupuestos del consolidado a nivel nacional.
    ''' </summary>
    ''' <param name="IDPERIODO">Es el año para el cual se desea trabajar.</param>
    ''' <param name="IDPROPUESTA">El identificador de la propuesta bajo la cual trabaja la función.</param>
    ''' <returns>Dataset con la información de los presupuestos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  25/12/2006    Creado
    ''' </history>
    Public Function ConsultaPresupuestosDS(ByVal IDPERIODO As Int16, ByVal IDPROPUESTA As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT PROPUESTA, ")
        strSQL.Append("ANIOFINPERIODO, ")
        strSQL.Append("SUM(PRESUPUESTOASIGNADO) AS PRESUPUESTOASIGNADO, ")
        strSQL.Append("SUM(MONTONECESIDADREAL) AS MONTONECESIDADREAL, ")
        strSQL.Append("SUM(MONTONECESIDADAJUSTADA) AS MONTONECESIDADAJUSTADA, ")
        strSQL.Append("SUM(MONTONECESIDADFINAL) AS MONTONECESIDADFINAL ")
        strSQL.Append("FROM SAB_EST_NECESIDADESTABLECIMIENTOS AS NE ")
        strSQL.Append("WHERE (PROPUESTA = @IDPROPUESTA) AND (ANIOFINPERIODO = @IDPERIODO) ")
        strSQL.Append("GROUP BY PROPUESTA, ANIOFINPERIODO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROPUESTA", SqlDbType.Int)
        args(0).Value = IDPROPUESTA
        args(1) = New SqlParameter("@IDPERIODO", SqlDbType.Int)
        args(1).Value = IDPERIODO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información de los presupuestos del consolidado a nivel de SIBASI o Región.
    ''' </summary>
    ''' <param name="IDPERIODO">Es el año para el cual se desea trabajar.</param>
    ''' <param name="IDPROPUESTA">El identificador de la propuesta bajo la cual trabaja la función.</param>
    ''' <param name="IDSIBASI">Identificador del SIBASI a consultar.</param>
    ''' <returns>Dataset con la información de los presupuestos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  25/12/2006    Creado
    ''' </history> 
    Public Function ConsultaPresupuestosPorSibasiDS(ByVal IDPERIODO As Int16, ByVal IDPROPUESTA As Int16, ByVal IDSIBASI As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ES.IDPADRE, ")
        strSQL.Append("(SELECT NOMBRE FROM SAB_CAT_ESTABLECIMIENTOS WHERE IDESTABLECIMIENTO = ES.IDPADRE) AS NOMBRE, ")
        strSQL.Append("NE.ANIOFINPERIODO AS Anno, ")
        strSQL.Append("NE.PROPUESTA, ")
        strSQL.Append("SUM(NE.PRESUPUESTOASIGNADO) AS PRESUPUESTOASIGNADO, ")
        strSQL.Append("SUM(NE.MONTONECESIDADREAL) AS MONTONECESIDADREAL, ")
        strSQL.Append("SUM(NE.MONTONECESIDADAJUSTADA) AS MONTONECESIDADAJUSTADA, ")
        strSQL.Append("SUM(NE.MONTONECESIDADFINAL) AS MONTONECESIDADFINAL ")
        strSQL.Append("FROM SAB_EST_NECESIDADESTABLECIMIENTOS AS NE ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS AS ES ")
        strSQL.Append("ON NE.IDESTABLECIMIENTO = ES.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOESTABLECIMIENTOS TE ")
        strSQL.Append("ON ES.IDTIPOESTABLECIMIENTO = TE.IDTIPOESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON NE.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("WHERE ES.IDPADRE IN (SELECT IDESTABLECIMIENTO FROM SAB_CAT_ESTABLECIMIENTOS AS ESTABLECIMIENTOS_1 WHERE IDTIPOESTABLECIMIENTO = 2) ")
        strSQL.Append("AND (NE.ANIOFINPERIODO = @IDPERIODO) AND (NE.PROPUESTA = @IDPROPUESTA) AND (ES.IDPADRE = @IDSIBASI) ")
        strSQL.Append("GROUP BY ES.IDPADRE, NE.ANIOFINPERIODO, NE.PROPUESTA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPERIODO", SqlDbType.Int)
        args(0).Value = IDPERIODO
        args(1) = New SqlParameter("@IDPROPUESTA", SqlDbType.Int)
        args(1).Value = IDPROPUESTA
        args(2) = New SqlParameter("@IDSIBASI", SqlDbType.Int)
        args(2).Value = IDSIBASI

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información de una estimación de necesidades especifica.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento en el que fue elaborada.</param>
    ''' <param name="IDNECESIDAD">Identificador de la estimación solicitada.</param>
    ''' <returns>Dataset con la información de la estimación de necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  09/01/2007    Creado
    ''' </history> 
    Public Function ObtenerNecesidadPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

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
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history> 
    Public Function ObtenerPresupuesto(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT PRESUPUESTOASIGNADO ")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtener periodo de compras
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificdor de establecimiento
    ''' <param name="IDNECESIDAD"></param> identificador de necesidad
    ''' <returns>
    ''' periodo de compras
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history> 
    Public Function ObtenerPeriododeCompras(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT PERIODOUTILIZACION ")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

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
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' <item><description>SAB_EST_CONSUMOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history> 
    Public Function ObtenerConsumoMensualSibasi(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SUM(dc.CANTIDADCONSUMIDA) AS CONSUMO ")
        strSQL.Append(" FROM SAB_EST_DETALLECONSUMOS AS dc INNER JOIN ")
        strSQL.Append(" SAB_EST_CONSUMOS AS c ON dc.IDCONSUMO = c.IDCONSUMO AND dc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS AS e ON c.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE dc.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND e.IDPADRE = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND c.MESCONSUMO = @MESCONSUMO ")
        strSQL.Append(" AND c.ANIOCONSUMO = @ANIOCONSUMO ")
        strSQL.Append(" AND c.IDESTADO = 2 ")
        strSQL.Append(" AND e.NIVEL = 1 ")
        strSQL.Append(" GROUP BY dc.IDPRODUCTO, dc.IDUNIDADMEDIDA, e.IDPADRE, c.MESCONSUMO, c.ANIOCONSUMO, c.IDESTADO, e.NIVEL ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@MESCONSUMO", SqlDbType.Int)
        args(2).Value = MESCONSUMO
        args(3) = New SqlParameter("@ANIOCONSUMO", SqlDbType.Int)
        args(3).Value = ANIOCONSUMO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

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
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' <item><description>SAB_EST_CONSUMOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history> 
    Public Function ObtenerDemandaMensualSibasi(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SUM(dc.DEMANDAINSATISFECHA) AS DEMANDA ")
        strSQL.Append(" FROM SAB_EST_DETALLECONSUMOS AS dc INNER JOIN ")
        strSQL.Append(" SAB_EST_CONSUMOS AS c ON dc.IDCONSUMO = c.IDCONSUMO AND dc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS AS e ON c.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE dc.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND e.IDPADRE = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND c.MESCONSUMO = @MESCONSUMO ")
        strSQL.Append(" AND c.ANIOCONSUMO = @ANIOCONSUMO ")
        strSQL.Append(" AND c.IDESTADO = 2 ")
        strSQL.Append(" AND e.NIVEL = 1 ")
        strSQL.Append(" GROUP BY dc.IDPRODUCTO, dc.IDUNIDADMEDIDA, e.IDPADRE, c.MESCONSUMO, c.ANIOCONSUMO, c.IDESTADO, e.NIVEL ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@MESCONSUMO", SqlDbType.Int)
        args(2).Value = MESCONSUMO
        args(3) = New SqlParameter("@ANIOCONSUMO", SqlDbType.Int)
        args(3).Value = ANIOCONSUMO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

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
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' <item><description>SAB_EST_CONSUMOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history> 
    Public Function ObtenerExistenciasMensualSibasi(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SUM(dc.EXISTENCIAACTUAL) AS EXISTENCIA ")
        strSQL.Append(" FROM SAB_EST_DETALLECONSUMOS AS dc INNER JOIN ")
        strSQL.Append(" SAB_EST_CONSUMOS AS c ON dc.IDCONSUMO = c.IDCONSUMO AND dc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS AS e ON c.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE dc.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND e.IDPADRE = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND c.MESCONSUMO = @MESCONSUMO ")
        strSQL.Append(" AND c.ANIOCONSUMO = @ANIOCONSUMO ")
        strSQL.Append(" AND c.IDESTADO = 2 ")
        strSQL.Append(" AND e.NIVEL = 1 ")
        strSQL.Append(" GROUP BY dc.IDPRODUCTO, dc.IDUNIDADMEDIDA, e.IDPADRE, c.MESCONSUMO, c.ANIOCONSUMO, c.IDESTADO, e.NIVEL ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@MESCONSUMO", SqlDbType.Int)
        args(2).Value = MESCONSUMO
        args(3) = New SqlParameter("@ANIOCONSUMO", SqlDbType.Int)
        args(3).Value = ANIOCONSUMO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtener consumo mensual establecimiento
    ''' Calculo solo con los datos de los consumos ya enviados del establecimiento si son del nivel 2 o 3
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador producto
    ''' <param name="MESCONSUMO"></param> entero mes consumo
    ''' <param name="ANIOCONSUMO"></param> entero año consumo
    ''' <returns>
    ''' consumo mensual del establecimiento
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' <item><description>SAB_EST_CONSUMOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history>
    Public Function ObtenerConsumoMensualEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SUM(dc.CANTIDADCONSUMIDA) AS CONSUMO ")
        strSQL.Append(" FROM SAB_EST_DETALLECONSUMOS AS dc INNER JOIN ")
        strSQL.Append(" SAB_EST_CONSUMOS AS c ON dc.IDCONSUMO = c.IDCONSUMO AND dc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS AS e ON c.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE dc.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND c.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND c.MESCONSUMO = @MESCONSUMO ")
        strSQL.Append(" AND c.ANIOCONSUMO = @ANIOCONSUMO ")
        strSQL.Append(" AND c.IDESTADO = 2 ")
        strSQL.Append(" AND e.NIVEL = 2 ")
        strSQL.Append(" OR  dc.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND c.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND c.MESCONSUMO = @MESCONSUMO ")
        strSQL.Append(" AND c.ANIOCONSUMO = @ANIOCONSUMO ")
        strSQL.Append(" AND c.IDESTADO = 2 ")
        strSQL.Append(" AND e.NIVEL = 3 ")
        strSQL.Append(" GROUP BY dc.IDPRODUCTO, e.IDPADRE, c.MESCONSUMO, c.ANIOCONSUMO, c.IDESTADO, e.NIVEL, c.IDESTABLECIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@MESCONSUMO", SqlDbType.Int)
        args(2).Value = MESCONSUMO
        args(3) = New SqlParameter("@ANIOCONSUMO", SqlDbType.Int)
        args(3).Value = ANIOCONSUMO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtener la demanda nmensual del establecimiento
    ''' Calculo solo con los datos de los consumos ya enviados del establecimiento si son del nivel 2 o 3
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <param name="MESCONSUMO"></param> entero mes del consumo
    ''' <param name="ANIOCONSUMO"></param> entero año del consumo
    ''' <returns>
    ''' Demanda mensual establecimiento
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' <item><description>SAB_EST_CONSUMOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history>
    Public Function ObtenerDemandaMensualEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SUM(dc.DEMANDAINSATISFECHA) AS DEMANDA ")
        strSQL.Append(" FROM SAB_EST_DETALLECONSUMOS AS dc INNER JOIN ")
        strSQL.Append(" SAB_EST_CONSUMOS AS c ON dc.IDCONSUMO = c.IDCONSUMO AND dc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS AS e ON c.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE dc.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND c.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND c.MESCONSUMO = @MESCONSUMO ")
        strSQL.Append(" AND c.ANIOCONSUMO = @ANIOCONSUMO ")
        strSQL.Append(" AND c.IDESTADO = 2 ")
        strSQL.Append(" AND e.NIVEL = 2 ")
        strSQL.Append(" OR  dc.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND c.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND c.MESCONSUMO = @MESCONSUMO ")
        strSQL.Append(" AND c.ANIOCONSUMO = @ANIOCONSUMO ")
        strSQL.Append(" AND c.IDESTADO = 2 ")
        strSQL.Append(" AND e.NIVEL = 3 ")
        strSQL.Append(" GROUP BY dc.IDPRODUCTO, e.IDPADRE, c.MESCONSUMO, c.ANIOCONSUMO, c.IDESTADO, e.NIVEL, c.IDESTABLECIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@MESCONSUMO", SqlDbType.Int)
        args(2).Value = MESCONSUMO
        args(3) = New SqlParameter("@ANIOCONSUMO", SqlDbType.Int)
        args(3).Value = ANIOCONSUMO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' obtener existencia mensual del establecimiento
    ''' Calculo solo con los datos de los consumos ya enviados del establecimiento si son del nivel 2 o 3
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <param name="MESCONSUMO"></param> entero del mes de consumo
    ''' <param name="ANIOCONSUMO"></param> entero del año de consumo
    ''' <returns>
    ''' existencia mensual del establecimiento
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' <item><description>SAB_EST_CONSUMOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  09/01/2007    Creado
    ''' </history>
    Public Function ObtenerExistenciasMensualEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal MESCONSUMO As Integer, ByVal ANIOCONSUMO As Integer) As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SUM(dc.EXISTENCIAACTUAL) AS EXISTENCIA ")
        strSQL.Append(" FROM SAB_EST_DETALLECONSUMOS AS dc INNER JOIN ")
        strSQL.Append(" SAB_EST_CONSUMOS AS c ON dc.IDCONSUMO = c.IDCONSUMO AND dc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS AS e ON c.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE dc.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND c.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND c.MESCONSUMO = @MESCONSUMO ")
        strSQL.Append(" AND c.ANIOCONSUMO = @ANIOCONSUMO ")
        strSQL.Append(" AND c.IDESTADO = 2 ")
        strSQL.Append(" AND e.NIVEL = 2 OR e.NIVEL = 3 ")
        strSQL.Append(" GROUP BY dc.IDPRODUCTO, dc.IDUNIDADMEDIDA, e.IDPADRE, c.MESCONSUMO, c.ANIOCONSUMO, c.IDESTADO, e.NIVEL,c.IDESTABLECIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@MESCONSUMO", SqlDbType.Int)
        args(2).Value = MESCONSUMO
        args(3) = New SqlParameter("@ANIOCONSUMO", SqlDbType.Int)
        args(3).Value = ANIOCONSUMO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

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
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerComprasTransitoEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal FECHACORTE As Date) As Double
        'Calculo compras transito
        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SUM(aec.CANTIDAD - aec.CANTIDADENTREGADA) AS TRANSITO ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO AS pc INNER JOIN ")
        strSQL.Append("SAB_UACI_ENTREGACONTRATO AS ec ON pc.IDESTABLECIMIENTO = ec.IDESTABLECIMIENTO AND pc.IDPROVEEDOR = ec.IDPROVEEDOR AND ")
        strSQL.Append("pc.IDCONTRATO = ec.IDCONTRATO AND pc.RENGLON = ec.RENGLON INNER JOIN ")
        strSQL.Append("SAB_UACI_ALMACENESENTREGACONTRATOS AS aec ON ec.IDESTABLECIMIENTO = aec.IDESTABLECIMIENTO AND ")
        strSQL.Append("ec.IDPROVEEDOR = aec.IDPROVEEDOR AND ec.IDCONTRATO = aec.IDCONTRATO AND ec.RENGLON = aec.RENGLON AND ")
        strSQL.Append("ec.IDDETALLE = aec.IDDETALLE INNER JOIN ")
        strSQL.Append("SAB_ALM_RECIBOSRECEPCION ON aec.IDALMACENENTREGA = SAB_ALM_RECIBOSRECEPCION.IDALMACEN AND ")
        strSQL.Append("aec.IDESTABLECIMIENTO = SAB_ALM_RECIBOSRECEPCION.IDESTABLECIMIENTO AND ")
        strSQL.Append("aec.IDPROVEEDOR = SAB_ALM_RECIBOSRECEPCION.IDPROVEEDOR AND ")
        strSQL.Append("aec.IDCONTRATO = SAB_ALM_RECIBOSRECEPCION.IDCONTRATO INNER JOIN ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS m ON SAB_ALM_RECIBOSRECEPCION.IDALMACEN = m.IDALMACEN AND ")
        strSQL.Append("SAB_ALM_RECIBOSRECEPCION.IDRECIBO = m.IDDOCUMENTO AND SAB_ALM_RECIBOSRECEPCION.ANIO = m.ANIO AND ")
        strSQL.Append("SAB_ALM_RECIBOSRECEPCION.IDESTABLECIMIENTO = m.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE pc.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND ec.ESTAHABILITADA = 1 ")
        strSQL.Append("AND pc.ESTAHABILITADO = 1 ")
        strSQL.Append("AND pc.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND m.FECHAMOVIMIENTO <= @FECHACORTE ")
        strSQL.Append("GROUP BY pc.IDESTABLECIMIENTO, pc.ESTAHABILITADO, ec.ESTAHABILITADA, pc.IDPRODUCTO, aec.IDESTABLECIMIENTO, aec.IDPROVEEDOR, ")
        strSQL.Append("aec.IDCONTRATO, m.FECHAMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@FECHACORTE", SqlDbType.DateTime)
        args(2).Value = FECHACORTE

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

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
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerMesInicial(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT MESINICIOPERIODO")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

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
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerMesFinal(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT MESFINPERIODO")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

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
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerAñoInicial(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ANIOINICIOPERIODO")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

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
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerAñoFinal(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ANIOFINPERIODO")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

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
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEMOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' <item><description>CAT_ESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerExistenciaDisponibleNoVencida(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal FECHACORTE As Date, ByVal FECHAFIN As Date) As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SUM(dm.CANTIDAD * tt.AFECTAINVENTARIO) AS EXISTENCIA ")
        strSQL.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS AS dm INNER JOIN ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS m ON dm.IDESTABLECIMIENTO = m.IDESTABLECIMIENTO AND dm.IDTIPOTRANSACCION = m.IDTIPOTRANSACCION AND ")
        strSQL.Append("dm.IDMOVIMIENTO = m.IDMOVIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOTRANSACCIONES AS tt ON m.IDTIPOTRANSACCION = tt.IDTIPOTRANSACCION INNER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS l ON dm.IDALMACEN = l.IDALMACEN AND dm.IDLOTE = l.IDLOTE AND dm.IDPRODUCTO = l.IDPRODUCTO INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS cp ON l.IDPRODUCTO = cp.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_CAT_ALMACENESESTABLECIMIENTOS ON l.IDALMACEN = SAB_CAT_ALMACENESESTABLECIMIENTOS.IDALMACEN INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS AS e ON SAB_CAT_ALMACENESESTABLECIMIENTOS.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE l.ESTADISPONIBLE = 1 ")
        strSQL.Append("AND m.IDTIPOTRANSACCION <> 6 ") 'solo disponible
        strSQL.Append("AND l.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND l.FECHAVENCIMIENTO > @FECHAFIN ")
        strSQL.Append("AND m.FECHAMOVIMIENTO <= @FECHACORTE ")
        strSQL.Append("AND e.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@FECHACORTE", SqlDbType.DateTime)
        args(2).Value = FECHACORTE
        args(3) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(3).Value = FECHAFIN

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) Is DBNull.Value Then
            Return 0
        Else
            Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        End If

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
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEMOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' <item><description>CAT_ESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]     Creado
    ''' </history>
    Public Function ObtenerExistenciaVencePlazoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal FECHACORTE As Date, ByVal FECHAINICIO As Date, ByVal FECHAFIN As Date) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SUM(dm.CANTIDAD * tt.AFECTAINVENTARIO) AS EXISTENCIA, l.FECHAVENCIMIENTO, l.IDPRODUCTO ")
        strSQL.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS AS dm INNER JOIN ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS m ON dm.IDESTABLECIMIENTO = m.IDESTABLECIMIENTO AND dm.IDTIPOTRANSACCION = m.IDTIPOTRANSACCION AND ")
        strSQL.Append("dm.IDMOVIMIENTO = m.IDMOVIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOTRANSACCIONES AS tt ON m.IDTIPOTRANSACCION = tt.IDTIPOTRANSACCION INNER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS l ON dm.IDALMACEN = l.IDALMACEN AND dm.IDLOTE = l.IDLOTE AND dm.IDPRODUCTO = l.IDPRODUCTO INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS cp ON l.IDPRODUCTO = cp.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_CAT_ALMACENESESTABLECIMIENTOS ON l.IDALMACEN = SAB_CAT_ALMACENESESTABLECIMIENTOS.IDALMACEN INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS AS e ON SAB_CAT_ALMACENESESTABLECIMIENTOS.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE l.ESTADISPONIBLE = 1 ")
        strSQL.Append("AND e.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND l.FECHAVENCIMIENTO BETWEEN @FECHAINICIO AND @FECHAFIN ")
        strSQL.Append("AND m.IDTIPOTRANSACCION <> 6 ")
        strSQL.Append("AND m.FECHAMOVIMIENTO <= @FECHACORTE ")
        strSQL.Append("AND l.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("GROUP BY l.FECHAVENCIMIENTO, l.IDPRODUCTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@FECHACORTE", SqlDbType.DateTime)
        args(2).Value = FECHACORTE
        args(3) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(3).Value = FECHAINICIO
        args(4) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(4).Value = FECHAFIN

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerIDN() As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(IDNECESIDAD),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

#End Region

#Region "Metódos agregados para el consolidado por programas"
    ''' <summary>
    ''' Obtiene el listado de las estimaciones de necesidades filtrado para un período,propuesta y programa especifico,
    ''' recupera solo la información de la tabla padre.
    ''' </summary>
    ''' <param name="PERIODO">Período al cual sera aplicado esta función.</param>
    ''' <param name="PROPUESTA">Identificador del número de la propuesta seleccionada.</param>
    ''' <param name="IDPROGRAMA">Identificador del programa seleccionado.</param>
    ''' <returns>Dataset con el listado de las necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  03/10/2006    Creado
    ''' </history> 
    Public Function FiltrarEstimacionNecesidadesConProgramas(ByVal PERIODO As Int32, ByVal PROPUESTA As Int16, ByVal IDPROGRAMA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("NE.IDESTABLECIMIENTO, ")
        strSQL.Append("NE.IDNECESIDAD, ")
        strSQL.Append("NE.PROPUESTA, ")
        strSQL.Append("NE.CORRELATIVO, ")
        strSQL.Append("NE.IDESTADO, ")
        strSQL.Append("NE.ANIOFINPERIODO, ")
        strSQL.Append("NE.IDSUMINISTRO, ")
        strSQL.Append("PG.IDPROGRAMA ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_EST_NECESIDADESTABLECIMIENTOS NE ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLENECESIDADESTABLECIMIENTOS DNE ")
        strSQL.Append("ON NE.IDNECESIDAD = DNE.IDNECESIDAD AND NE.IDESTABLECIMIENTO = DNE.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DNE.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PG ")
        strSQL.Append("ON DNE.IDPRODUCTO = PG.IDPRODUCTO ")
        strSQL.Append("WHERE (NE.PROPUESTA = @PROPUESTA) AND (NE.ANIOFINPERIODO = @PERIODO) AND (NE.IDESTADO = 2) AND (PG.IDPROGRAMA = @IDPROGRAMA) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("NE.IDESTABLECIMIENTO, ")
        strSQL.Append("NE.IDNECESIDAD, ")
        strSQL.Append("NE.PROPUESTA, ")
        strSQL.Append("NE.CORRELATIVO, ")
        strSQL.Append("NE.IDESTADO, ")
        strSQL.Append("NE.ANIOFINPERIODO, ")
        strSQL.Append("NE.IDSUMINISTRO, ")
        strSQL.Append("PG.IDPROGRAMA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@PERIODO", SqlDbType.Int)
        args(0).Value = PERIODO
        args(1) = New SqlParameter("@PROPUESTA", SqlDbType.Int)
        args(1).Value = PROPUESTA
        args(2) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(2).Value = IDPROGRAMA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
