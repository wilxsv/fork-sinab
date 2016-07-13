Partial Public Class dbMOVIMIENTOS

#Region " Metodos Agregados "

    ''' <summary>
    ''' Devuelve un listado de los movimientos al inventario filtrado por cada uno de los parámetros, solamente 
    ''' muestra la información de la tabla padre.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">El ID del establecimiento.</param>
    ''' <param name="IDTIPOTRANSACCION">El ID del tipo de transacción.</param>
    ''' <param name="IDMOVIMIENTO">El ID del movimiento que se desea recuperar.</param>
    ''' <param name="IDALMACEN">El ID  del almacén.</param>
    ''' <param name="IDDEPENDENCIA">El ID de la dependencia.</param>
    ''' <param name="IDTIPOCONSULTA">Identificador del tipo de consulta que se desea aplicar.</param>
    ''' <returns>Dataset con el listado de movimientos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  11/12/2006    Creado
    ''' </history> 
    Public Function ObtenerDsMovimientosFiltrado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int16, ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal IDDEPENDENCIA As Int32, ByVal IDTIPOCONSULTA As Int16, Optional ByVal CLASIFICACION As Int16 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("M.*, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTODESTINO, ")
        strSQL.Append("TDR.DESCRIPCION TIPODOCUREFERENCIA, ")
        strSQL.Append("A.NOMBRE ALMACEN, ")
        strSQL.Append("EM.DESCRIPCION ESTADO, ")
        strSQL.Append("TT.DESCRIPCION TIPOTRANSACCION ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS AS M ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOTRANSACCIONES TT ")
        strSQL.Append("ON M.IDTIPOTRANSACCION = TT.IDTIPOTRANSACCION ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS EM ")
        strSQL.Append("ON M.IDESTADO = EM.IDESTADO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON M.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON DM.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPODOCUMENTOREFERENCIAS TDR ")
        strSQL.Append("ON M.IDTIPODOCREF = TDR.IDTIPODOCREF ")
        strSQL.Append("WHERE (M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")

        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append(" AND (M.IDESTADO in (1, 2)) ")
            Case Is = 2
                strSQL.Append(" AND (M.IDESTADO = 1) ")
            Case Is = 3
                strSQL.Append(" AND (M.IDESTADO = 4) ")
            Case Is = 4
                strSQL.Append(" AND (M.IDESTADO = 2) ")
        End Select

        strSQL.Append(" AND (M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION OR @IDTIPOTRANSACCION = 0) ")
        strSQL.Append(" AND (M.IDMOVIMIENTO = @IDMOVIMIENTO OR @IDMOVIMIENTO = 0)")
        strSQL.Append(" AND (M.IDUNIDADSOLICITA = @IDDEPENDENCIA OR @IDDEPENDENCIA = 0) ")
        strSQL.Append(" AND (DM.IDALMACEN = @IDALMACEN OR DM.IDALMACEN is null OR @IDALMACEN = 0) ")

        Select Case CLASIFICACION
            Case Is = 10
                strSQL.Append(" AND (M.CLASIFICACIONMOVIMIENTO = 10) ")
            Case Is = 0
                strSQL.Append(" AND (M.CLASIFICACIONMOVIMIENTO <> 10)")
        End Select

        strSQL.Append(" ORDER BY M.IDMOVIMIENTO DESC ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.Int)
        args(2).Value = IDMOVIMIENTO
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(3).Value = IDALMACEN
        args(4) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(4).Value = IDDEPENDENCIA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene los movimientos anulados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDTIPOTRANSACCION">Identificador del tipo de transacciones</param>
    ''' <param name="IDALMACEN">Identificacion del almacen</param>
    ''' <returns>dataset</returns>

    Public Function ObtenerMovimientosAnular(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int16, ByVal IDALMACEN As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("M.*, ")
        strSQL.Append("isnull(convert(varchar, M.IDDOCUMENTO) + '/' + convert(varchar, M.ANIO), '') NUMERODOCUMENTO, ")
        strSQL.Append("E.DESCRIPCION ESTADO, ")
        strSQL.Append("TT.DESCRIPCION TIPOTRANSACCION ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS AS M ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOTRANSACCIONES TT ")
        strSQL.Append("ON M.IDTIPOTRANSACCION = TT.IDTIPOTRANSACCION ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS EM ")
        strSQL.Append("ON M.IDESTADO = EM.IDESTADO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON DM.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND M.IDESTADO in (1, 2) ")
        strSQL.Append("ORDER BY M.IDMOVIMIENTO DESC ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve el detalle completo de los movimientos al inventario mostrando la información de la tabla padre 
    ''' y la tabla dependiente.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">El ID del establecimiento.</param>
    ''' <param name="IDTIPOTRANSACCION">El ID del tipo de transacción.</param>
    ''' <param name="IDMOVIMIENTO">El ID del movimiento que se desea recuperar.</param>
    ''' <param name="IDALMACEN">El ID  del almacén.</param>
    ''' <param name="IDDEPENDENCIA">El ID de la dependencia.</param>
    ''' <param name="IDTIPOCONSULTA">Identificador del tipo de consulta que se desea aplicar.</param>
    ''' <returns>Dataset con el listado de movimientos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  10/01/2007    Creado
    ''' </history> 
    Public Function ObtenerMovimientosDetalleLoteDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int16, ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal IDDEPENDENCIA As Int32, ByVal IDDESTINO As Int32, ByVal IDTIPOCONSULTA As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDESTABLECIMIENTO, ")
        strSQL.Append("m.IDTIPOTRANSACCION, ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("m.ANIO, ")
        strSQL.Append("m.IDDOCUMENTO, ")
        strSQL.Append("m.IDESTADO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.AUFECHACREACION AS FECHADOCUMENTO, ")
        strSQL.Append("m.IDALMACEN, ")
        strSQL.Append("alm.NOMBRE AS NOMBREALMACEN, ")
        strSQL.Append("m.IDUNIDADSOLICITA, ")
        strSQL.Append("dep.NOMBRE AS NOMBREDEPENDENCIA, ")
        strSQL.Append("m.IDESTABLECIMIENTODESTINO, ")
        strSQL.Append("est.NOMBRE AS DESTINO, ")
        strSQL.Append("m.RESPONSABLEDISTRIBUCION NOMBRERESPONSABLEDISTRIBUCION, ")
        strSQL.Append("m.TOTALMOVIMIENTO, ")
        strSQL.Append("m.IDEMPLEADOSOLICITA, ")
        strSQL.Append("(SELECT (NOMBRE + APELLIDO) NOMBRECOMPLETO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = m.IDEMPLEADOSOLICITA)) AS NOMBREEMPLEADOSOLICITA, ")
        strSQL.Append("m.IDEMPLEADOAUTORIZA, ")
        strSQL.Append("(SELECT (NOMBRE + APELLIDO) NOMBRECOMPLETO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_1 WHERE (IDEMPLEADO = m.IDEMPLEADOAUTORIZA)) AS NOMBREEMPLEADOAUTORIZA, ")
        strSQL.Append("m.IDEMPLEADOALMACEN, ")
        strSQL.Append("(SELECT (NOMBRE + APELLIDO) NOMBRECOMPLETO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_2 WHERE (IDEMPLEADO = m.IDEMPLEADOALMACEN)) AS NOMBREEMPLEADOALMACEN, ")
        strSQL.Append("m.IDEMPLEADODESPACHA, ")
        strSQL.Append("(SELECT (NOMBRE + APELLIDO) NOMBRECOMPLETO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_3 WHERE (IDEMPLEADO = m.IDEMPLEADODESPACHA)) AS NOMBREEMPLEADODESPACHA, ")
        strSQL.Append("m.IDEMPLEADORECIBE, ")
        strSQL.Append("(SELECT (NOMBRE + APELLIDO) NOMBRECOMPLETO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_4 WHERE (IDEMPLEADO = m.IDEMPLEADORECIBE)) AS NOMBREEMPLEADORECIBE, ")
        strSQL.Append("m.IDEMPLEADOPREPARA, ")
        strSQL.Append("(SELECT (NOMBRE + APELLIDO) NOMBRECOMPLETO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_5 WHERE (IDEMPLEADO = m.IDEMPLEADOPREPARA)) AS NOMBREEMPLEADOPREPARA, ")
        strSQL.Append("m.IDEMPLEADOENVIADO, ")
        strSQL.Append("(SELECT (NOMBRE + APELLIDO) NOMBRECOMPLETO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_6 WHERE (IDEMPLEADO = m.IDEMPLEADOENVIADO)) AS NOMBREEMPLEADOENVIADO, ")
        strSQL.Append("dm.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("dm.IDLOTE, ")
        strSQL.Append("dm.CANTIDAD, ")
        strSQL.Append("dm.CANTIDADRECHAZADA, ")
        strSQL.Append("dm.CANTIDADANTERIOR, ")
        strSQL.Append("dm.NUMEROFACTURA, ")
        strSQL.Append("dm.FECHAFACTURA, ")
        strSQL.Append("dm.MONTO, ")
        strSQL.Append("dm.IDPRODUCTO, ")
        strSQL.Append("l.IDUNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("l.PRECIOLOTE, ")
        strSQL.Append("l.FECHAVENCIMIENTO, ")
        strSQL.Append("l.CANTIDADDISPONIBLE, ")
        strSQL.Append("l.CANTIDADNODISPONIBLE, ")
        strSQL.Append("l.CANTIDADVENCIDA, ")
        strSQL.Append("l.CANTIDADRESERVADA, ")
        strSQL.Append("l.CANTIDADTEMPORAL, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("rpd.NOMBRE AS RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("ff.NOMBRE AS FUENTEFINANCIAMIENTO, ")
        strSQL.Append("cp.CORRPRODUCTO, ")
        strSQL.Append("cp.DESCLARGO, ")
        strSQL.Append("cp.IDNIVELUSO, ")
        strSQL.Append("cp.DESCRIPCION DESCRIPCION2, ")
        strSQL.Append("cp.PRECIOACTUAL, ")
        strSQL.Append("um.DESCRIPCION ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_ALMACENES AS alm ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS AS m ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS dm ")
        strSQL.Append("ON m.IDESTABLECIMIENTO = dm.IDESTABLECIMIENTO AND m.IDTIPOTRANSACCION = dm.IDTIPOTRANSACCION AND m.IDMOVIMIENTO = dm.IDMOVIMIENTO ")
        strSQL.Append("ON alm.IDALMACEN = m.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_DEPENDENCIAS dep ")
        strSQL.Append("ON m.IDUNIDADSOLICITA = dep.IDDEPENDENCIA ")
        strSQL.Append("LEFT OUTER JOIN vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("ON dm.IDPRODUCTO = cp.IDPRODUCTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS AS ff ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS um ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES AS l ")
        strSQL.Append("ON um.IDUNIDADMEDIDA = l.IDUNIDADMEDIDA ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION AS rpd ")
        strSQL.Append("ON l.IDRESPONSABLEDISTRIBUCION = rpd.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("ON ff.IDFUENTEFINANCIAMIENTO = l.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("ON dm.IDALMACEN = l.IDALMACEN AND dm.IDLOTE = l.IDLOTE ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS est ")
        strSQL.Append("ON m.IDESTABLECIMIENTODESTINO = est.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE ")

        If IDESTABLECIMIENTO > 0 Then
            strSQL.Append("(m.IDESTABLECIMIENTO = " + Str(IDESTABLECIMIENTO) + ") AND ")
        End If

        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append(" (m.IDESTADO >= 1) AND (m.IDESTADO <= 2) ")
            Case Is = 2
                strSQL.Append(" ((m.IDESTADO = 1) OR (m.IDESTADO = 4)) ")
        End Select

        If IDTIPOTRANSACCION > 0 Then
            strSQL.Append(" AND (m.IDTIPOTRANSACCION = " + Str(IDTIPOTRANSACCION) + ") ")
        End If
        If IDMOVIMIENTO > 0 Then
            strSQL.Append(" AND (m.IDMOVIMIENTO = " + Str(IDMOVIMIENTO) + ") ")
        End If

        If IDALMACEN > 0 Then
            strSQL.Append(" AND (m.IDALMACEN = " + Str(IDALMACEN) + ") ")
        End If

        If IDDESTINO > 0 Then
            strSQL.Append(" AND (m.IDESTABLECIMIENTODESTINO = " + Str(IDALMACEN) + ") ")
        End If

        If IDDEPENDENCIA > 0 Then
            strSQL.Append(" AND (m.IDUNIDADSOLICITA = " + Str(IDDEPENDENCIA) + ")")
        End If

        strSQL.Append(" ORDER BY m.IDMOVIMIENTO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información completa del vale de salida. 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO">El ID del movimiento que se desea recuperar.</param>
    ''' <param name="IDALMACEN">El ID  del almacén.</param>
    ''' <returns>Dataset con el vale de salida.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' ''' <item><description>SAB_ALM_VALESSALIDA</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  22/01/2007    Creado
    ''' </history> 
    Public Function ObtenerValeSalidaDS(ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal ANIO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDESTABLECIMIENTO, ")
        strSQL.Append("m.IDTIPOTRANSACCION, ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("m.ANIO, ")
        strSQL.Append("convert(varchar, va.IDVALE) + '/' + convert(varchar, va.ANIO) NUMEROVALE, ")
        strSQL.Append("m.IDDOCUMENTO, ")
        strSQL.Append("m.IDESTADO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.AUFECHACREACION AS FECHADOCUMENTO, ")
        strSQL.Append("m.IDALMACEN, ")
        strSQL.Append("alm.NOMBRE AS NOMBREALMACEN, ")
        strSQL.Append("m.IDUNIDADSOLICITA, ")
        strSQL.Append("dep.NOMBRE AS NOMBREDEPENDENCIA, ")
        strSQL.Append("m.IDESTABLECIMIENTODESTINO, ")
        strSQL.Append("est.NOMBRE AS DESTINO, ")
        strSQL.Append("m.TOTALMOVIMIENTO, ")
        strSQL.Append("m.RESPONSABLEDISTRIBUCION NOMBRERESPONSABLEDISTRIBUCION, ")
        strSQL.Append("m.IDEMPLEADOSOLICITA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = m.IDEMPLEADOSOLICITA)) AS NOMBREEMPLEADOSOLICITA, ")
        strSQL.Append("m.IDEMPLEADOAUTORIZA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_1 WHERE (IDEMPLEADO = m.IDEMPLEADOAUTORIZA)) AS NOMBREEMPLEADOAUTORIZA, ")
        strSQL.Append("m.IDEMPLEADOALMACEN, ")
        strSQL.Append("(SELECT NOMBRE + ' ' + APELLIDO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_2 WHERE (IDEMPLEADO = m.IDEMPLEADOALMACEN)) AS NOMBREEMPLEADOALMACEN, ")
        strSQL.Append("m.IDEMPLEADODESPACHA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_3 WHERE (IDEMPLEADO = m.IDEMPLEADODESPACHA)) AS NOMBREEMPLEADODESPACHA, ")
        strSQL.Append("m.IDEMPLEADORECIBE, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_4 WHERE (IDEMPLEADO = m.IDEMPLEADORECIBE)) AS NOMBREEMPLEADORECIBE, ")
        strSQL.Append("m.IDEMPLEADOPREPARA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_5 WHERE (IDEMPLEADO = m.IDEMPLEADOPREPARA)) AS NOMBREEMPLEADOPREPARA, ")
        strSQL.Append("m.IDEMPLEADOENVIADO, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_6 WHERE (IDEMPLEADO = m.IDEMPLEADOENVIADO)) AS NOMBREEMPLEADOENVIADO, ")
        strSQL.Append("dm.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("dm.IDLOTE, ")
        strSQL.Append("dm.CANTIDAD, ")
        strSQL.Append("dm.CANTIDADRECHAZADA, ")
        strSQL.Append("dm.CANTIDADANTERIOR, ")
        strSQL.Append("dm.NUMEROFACTURA, ")
        strSQL.Append("dm.FECHAFACTURA, ")
        strSQL.Append("dm.MONTO, ")
        strSQL.Append("l.IDPRODUCTO, ")
        strSQL.Append("l.IDUNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("l.PRECIOLOTE, ")
        strSQL.Append("l.FECHAVENCIMIENTO, ")
        strSQL.Append("l.CANTIDADDISPONIBLE, ")
        strSQL.Append("l.CANTIDADNODISPONIBLE, ")
        strSQL.Append("l.CANTIDADVENCIDA, ")
        strSQL.Append("l.CANTIDADRESERVADA, ")
        strSQL.Append("l.CANTIDADTEMPORAL, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("rpd.NOMBRE AS RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("ff.NOMBRE AS FUENTEFINANCIAMIENTO, ")
        strSQL.Append("cp.CORRPRODUCTO, ")
        strSQL.Append("cp.DESCLARGO, ")
        strSQL.Append("cp.IDNIVELUSO, ")
        strSQL.Append("um.DESCRIPCION, ")
        strSQL.Append("va.IDVALE, ")
        strSQL.Append("va.TRANSPORTISTA, ")
        strSQL.Append("va.MATRICULAVEHICULO, ")
        strSQL.Append("va.PERSONARECIBE, ")
        strSQL.Append("va.IDTIPOIDENTIFICACION, ")
        strSQL.Append("ti.DESCRIPCION NOMBRETIPOIDENTIFICACION, ")
        strSQL.Append("va.NUMEROIDENTIFICACION, ")
        strSQL.Append("va.OBSERVACION ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_FUENTEFINANCIAMIENTOS AS ff RIGHT OUTER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS AS um RIGHT OUTER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS l ON um.IDUNIDADMEDIDA = l.IDUNIDADMEDIDA ON ")
        strSQL.Append("ff.IDFUENTEFINANCIAMIENTO = l.IDFUENTEFINANCIAMIENTO RIGHT OUTER JOIN ")
        strSQL.Append("SAB_CAT_DEPENDENCIAS AS dep RIGHT OUTER JOIN ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS m INNER JOIN ")
        strSQL.Append("SAB_ALM_DETALLEMOVIMIENTOS AS dm ON m.IDESTABLECIMIENTO = dm.IDESTABLECIMIENTO AND ")
        strSQL.Append("m.IDTIPOTRANSACCION = dm.IDTIPOTRANSACCION AND m.IDMOVIMIENTO = dm.IDMOVIMIENTO INNER JOIN ")
        strSQL.Append("SAB_ALM_VALESSALIDA AS va ON m.IDALMACEN = va.IDALMACEN AND m.IDDOCUMENTO = va.IDVALE AND m.ANIO = va.ANIO ON ")
        strSQL.Append("dep.IDDEPENDENCIA = m.IDUNIDADSOLICITA ON l.IDALMACEN = dm.IDALMACEN AND l.IDLOTE = dm.IDLOTE LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_ALMACENES AS alm ON m.IDALMACEN = alm.IDALMACEN LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_RESPONSABLEDISTRIBUCION AS rpd ON l.IDRESPONSABLEDISTRIBUCION = rpd.IDRESPONSABLEDISTRIBUCION LEFT OUTER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS cp ON l.IDPRODUCTO = cp.IDPRODUCTO LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS AS est ON m.IDESTABLECIMIENTODESTINO = est.IDESTABLECIMIENTO LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_TIPOIDENTIFICACION AS ti ON va.IDTIPOIDENTIFICACION = ti.IDTIPOIDENTIFICACION ")
        strSQL.Append("WHERE m.IDTIPOTRANSACCION = 2 ")

        If IDMOVIMIENTO > 0 Then
            strSQL.Append(" AND (m.IDMOVIMIENTO = " + Str(IDMOVIMIENTO) + ") ")
        End If

        If IDALMACEN > 0 Then
            strSQL.Append(" AND (m.IDALMACEN = " + Str(IDALMACEN) + ") ")
        End If

        If ANIO > 0 Then
            strSQL.Append(" AND (m.ANIO = " + Str(ANIO) + ") ")
        End If

        strSQL.Append(" ORDER BY m.FECHAMOVIMIENTO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene la información del vale de salida
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDMOVIMIENTO">Identificacion del movimiento</param>
    ''' <returns>dataset</returns>

    Public Function ObtenerValeSalidaDS2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("row_number() over(ORDER BY CP.CORRPRODUCTO, DM.CANTIDAD DESC, L.PRECIOLOTE DESC) SECUENCIA, ")
        strSQL.Append("M.*, ")
        strSQL.Append("convert(varchar, VS.IDVALE) + '/' + convert(varchar, VS.ANIO) NUMEROVALE, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("D.NOMBRE NOMBREDEPENDENCIA, ")
        strSQL.Append("CASE WHEN E.NOMBRE IS NULL THEN convert(varchar, LEH.ID_LUGAR_ENTREGA_HOSPITAL) + ' - ' + LEH.NOMBRE_LUGAR_ENTREGA_HOSPITAL ELSE E.CODIGOESTABLECIMIENTO+ ' - ' + E.NOMBRE END DESTINO, ")
        strSQL.Append("E2.NOMBRE + ' ' + E2.APELLIDO NOMBREEMPLEADOSOLICITA, ")
        strSQL.Append("M.EMPLEADOALMACEN NOMBREEMPLEADOALMACEN, ")
        strSQL.Append("M.EMPLEADOPREPARA, ")
        strSQL.Append("DM.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("DM.RENGLON, ")
        strSQL.Append("DM.IDPRODUCTO, ")
        strSQL.Append("DM.IDLOTE, ")
        strSQL.Append("DM.CANTIDAD, ")
        strSQL.Append("DM.NUMEROFACTURA, ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN DM.NUMEROFACTURA IS NOT NULL THEN DM.NUMEROFACTURA ")
        strSQL.Append("WHEN DM.NOENVIO IS NOT NULL THEN DM.NOENVIO ")
        strSQL.Append("END DOCUMENTO, ")
        strSQL.Append("DM.FECHAFACTURA, ")
        strSQL.Append("L.PRECIOLOTE PRECIOUNITARIO, ")
        strSQL.Append("(DM.CANTIDAD * L.PRECIOLOTE) MONTOTOTAL, ")
        strSQL.Append("L.IDUNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') NUMEROLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("L.NUMEROINFORMECONTROLCALIDAD, ")
        strSQL.Append("L.FECHAINFORMECONTROLCALIDAD, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("VS.IDVALE, ")
        strSQL.Append("VS.TRANSPORTISTA, ")
        strSQL.Append("VS.MATRICULAVEHICULO, ")
        strSQL.Append("VS.PERSONARECIBE, ")
        strSQL.Append("VS.IDTIPOIDENTIFICACION, ")
        strSQL.Append("VS.NUMEROIDENTIFICACION, ")
        strSQL.Append("VS.OBSERVACION, ")
        strSQL.Append("isnull(A.DIRECCION, '') DIRECCIONALMACEN, ")
        strSQL.Append("isnull(UP.UBICACION, '') UBICACION ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON M.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_DEPENDENCIAS D ")
        strSQL.Append("ON M.IDUNIDADSOLICITA = D.IDDEPENDENCIA ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON M.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")

        strSQL.Append("LEFT OUTER JOIN SAB_CAT_LUGARES_ENTREGA_HOSPITALES LEH ")
        strSQL.Append("ON M.ID_LUGAR_ENTREGA_HOSPITAL = LEH.ID_LUGAR_ENTREGA_HOSPITAL ")
        strSQL.Append("AND M.IDALMACEN = LEH.IDALMACEN ")

        strSQL.Append("LEFT OUTER JOIN SAB_CAT_EMPLEADOS E2 ")
        strSQL.Append("ON M.IDEMPLEADOSOLICITA = E2.IDEMPLEADO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_VALESSALIDA VS ")
        strSQL.Append("ON M.IDALMACEN = VS.IDALMACEN ")
        strSQL.Append("AND M.IDDOCUMENTO = VS.IDVALE ")
        strSQL.Append("AND M.ANIO = VS.ANIO ")
        strSQL.Append("LEFT OUTER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP ")
        strSQL.Append("ON (L.IDALMACEN = UP.IDALMACEN ")
        strSQL.Append("AND L.IDPRODUCTO = UP.IDPRODUCTO ")
        strSQL.Append("AND L.IDLOTE = UP.IDLOTE) ")
        strSQL.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = 2 ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO, DM.CANTIDAD DESC, L.PRECIOLOTE DESC ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.Int)
        args(1).Value = IDMOVIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene la información de un movimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDTIPOTRANSACCION">Identificador del tipo de transacciones</param>
    ''' <param name="IDMOVIMIENTO">Identificacion del movimiento</param>
    ''' <returns>dataset</returns>

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.Int)
        args(2).Value = IDMOVIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene la informacion de un movimiento en una lista
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDTIPOTRANSACCION">Identificador del tipo de transacciones</param>
    ''' <param name="IDMOVIMIENTO">Identificacion del movimiento</param>
    ''' <returns>Lista</returns>

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As listaMOVIMIENTOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.Int)
        args(2).Value = IDMOVIMIENTO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaMOVIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New MOVIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDTIPOTRANSACCION = IDTIPOTRANSACCION
                mEntidad.IDMOVIMIENTO = IIf(dr("IDMOVIMIENTO") Is DBNull.Value, Nothing, dr("IDMOVIMIENTO"))
                mEntidad.IDTIPODOCREF = IIf(dr("IDTIPODOCREF") Is DBNull.Value, Nothing, dr("IDTIPODOCREF"))
                mEntidad.NUMERODOCREF = IIf(dr("NUMERODOCREF") Is DBNull.Value, Nothing, dr("NUMERODOCREF"))
                mEntidad.IDDOCUMENTO = IIf(dr("IDDOCUMENTO") Is DBNull.Value, Nothing, dr("IDDOCUMENTO"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.FECHAMOVIMIENTO = IIf(dr("FECHAMOVIMIENTO") Is DBNull.Value, Nothing, dr("FECHAMOVIMIENTO"))
                mEntidad.IDALMACEN = IIf(dr("IDALMACEN") Is DBNull.Value, Nothing, dr("IDALMACEN"))
                mEntidad.IDESTABLECIMIENTODESTINO = IIf(dr("IDESTABLECIMIENTODESTINO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTODESTINO"))
                mEntidad.IDUNIDADSOLICITA = IIf(dr("IDUNIDADSOLICITA") Is DBNull.Value, Nothing, dr("IDUNIDADSOLICITA"))
                mEntidad.TOTALMOVIMIENTO = IIf(dr("TOTALMOVIMIENTO") Is DBNull.Value, Nothing, dr("TOTALMOVIMIENTO"))
                mEntidad.IDEMPLEADOSOLICITA = IIf(dr("IDEMPLEADOSOLICITA") Is DBNull.Value, Nothing, dr("IDEMPLEADOSOLICITA"))
                mEntidad.IDEMPLEADOAUTORIZA = IIf(dr("IDEMPLEADOAUTORIZA") Is DBNull.Value, Nothing, dr("IDEMPLEADOAUTORIZA"))
                mEntidad.IDEMPLEADOALMACEN = IIf(dr("IDEMPLEADOALMACEN") Is DBNull.Value, Nothing, dr("IDEMPLEADOALMACEN"))
                mEntidad.IDEMPLEADODESPACHA = IIf(dr("IDEMPLEADODESPACHA") Is DBNull.Value, Nothing, dr("IDEMPLEADODESPACHA"))
                mEntidad.IDEMPLEADORECIBE = IIf(dr("IDEMPLEADORECIBE") Is DBNull.Value, Nothing, dr("IDEMPLEADORECIBE"))
                mEntidad.IDEMPLEADOPREPARA = IIf(dr("IDEMPLEADOPREPARA") Is DBNull.Value, Nothing, dr("IDEMPLEADOPREPARA"))
                mEntidad.IDEMPLEADOENVIADO = IIf(dr("IDEMPLEADOENVIADO") Is DBNull.Value, Nothing, dr("IDEMPLEADOENVIADO"))
                mEntidad.CLASIFICACIONMOVIMIENTO = IIf(dr("CLASIFICACIONMOVIMIENTO") Is DBNull.Value, Nothing, dr("CLASIFICACIONMOVIMIENTO"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    ''' <summary>
    ''' Valida si el documento puedo ser anulado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertenece el documento.</param>
    ''' <param name="IDTIPOTRANSACCION">Identificador del tipo de transacción realizada.</param>
    ''' <param name="IDMOVIMIENTO">Identificador unico del documento.</param>
    ''' <returns>Valor numerico que indica si el documento puede ser anulado "0 = Si se puede anular | 1 = No se puede anular"</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  29/01/2007    Creado
    ''' </history> 
    Public Function AnularDocumentoValidacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As Int16

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append(" AND (IDESTADO = 1 OR IDESTADO = 2) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.Int)
        args(2).Value = IDMOVIMIENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) > 0, 1, 0)

    End Function

    ''' <summary>
    ''' Devuelve la información completa del recibo de recepción. 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO">El ID del movimiento que se desea recuperar.</param>
    ''' <param name="IDALMACEN">El ID  del almacén.</param>
    ''' <returns>Dataset con el recibo de recepción.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  22/01/2007    Creado
    ''' </history>
    Public Function ObtenerReciboRecepcionDS(ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal ANIO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDESTABLECIMIENTO, ")
        strSQL.Append("m.IDTIPOTRANSACCION, ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("m.ANIO, ")
        strSQL.Append("m.IDDOCUMENTO, ")
        strSQL.Append("m.IDESTADO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.AUFECHACREACION FECHADOCUMENTO, ")
        strSQL.Append("m.IDALMACEN, ")
        strSQL.Append("alm.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("m.IDUNIDADSOLICITA, ")
        strSQL.Append("dep.NOMBRE NOMBREDEPENDENCIA, ")
        strSQL.Append("m.IDESTABLECIMIENTODESTINO, ")
        strSQL.Append("est.NOMBRE DESTINO, ")
        strSQL.Append("m.TOTALMOVIMIENTO, ")
        strSQL.Append("m.RESPONSABLEDISTRIBUCION NOMBRERESPONSABLEDISTRIBUCION, ")
        strSQL.Append("m.IDEMPLEADOSOLICITA, ")
        strSQL.Append("e2.NOMBRE + ' ' + e2.APELLIDO NOMBREEMPLEADOSOLICITA, ")
        strSQL.Append("m.IDEMPLEADOALMACEN, ")
        strSQL.Append("e3.NOMBRE + ' ' + e3.APELLIDO NOMBREEMPLEADOALMACEN, ")
        strSQL.Append("dm.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("dm.RENGLON, ")
        strSQL.Append("dm.IDPRODUCTO, ")
        strSQL.Append("dm.IDLOTE, ")
        strSQL.Append("dm.CANTIDAD, ")
        strSQL.Append("dm.NUMEROFACTURA, ")
        strSQL.Append("dm.FECHAFACTURA, ")
        strSQL.Append("dm.MONTO PRECIOUNITARIO, ")
        strSQL.Append("(dm.CANTIDAD * dm.MONTO) MONTOTOTAL, ")
        strSQL.Append("l.IDUNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("l.FECHAVENCIMIENTO, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("rpd.NOMBRE RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("ff.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("l.PRECIOLOTE, ")
        strSQL.Append("cp.CORRPRODUCTO, ")
        strSQL.Append("cp.DESCLARGO, ")
        strSQL.Append("cp.IDNIVELUSO, ")
        strSQL.Append("um.DESCRIPCION, ")
        strSQL.Append("um.DESCRIPCION DESCRIPCION2, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("rr.IDPROVEEDOR, ")
        strSQL.Append("rr.IDCONTRATO, ")
        strSQL.Append("rr.RESPONSABLEPROVEEDOR, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("pv.NOMBRE NOMBREPROVEEDOR, ")
        strSQL.Append("rr.OBSERVACION, ")
        strSQL.Append("alm.DIRECCION DIRECCIONALMACEN ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_EMPLEADOS e3 ")
        strSQL.Append("RIGHT OUTER JOIN SAB_CAT_UNIDADMEDIDAS um ")
        strSQL.Append("RIGHT OUTER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS ff ")
        strSQL.Append("RIGHT OUTER JOIN SAB_ALM_LOTES l ")
        strSQL.Append("ON ff.IDFUENTEFINANCIAMIENTO = l.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("ON um.IDUNIDADMEDIDA = l.IDUNIDADMEDIDA ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION rpd ")
        strSQL.Append("ON l.IDRESPONSABLEDISTRIBUCION = rpd.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("RIGHT OUTER JOIN vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS dm ")
        strSQL.Append("ON cp.IDPRODUCTO = dm.IDPRODUCTO ")
        strSQL.Append("ON l.IDLOTE = dm.IDLOTE AND l.IDALMACEN = dm.IDALMACEN ")
        strSQL.Append("RIGHT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS est ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS m ")
        strSQL.Append("ON est.IDESTABLECIMIENTO = m.IDESTABLECIMIENTODESTINO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_RECIBOSRECEPCION rr ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_PROVEEDORES pv ")
        strSQL.Append("ON rr.IDPROVEEDOR = pv.IDPROVEEDOR ")
        strSQL.Append("ON m.IDALMACEN = rr.IDALMACEN AND m.ANIO = rr.ANIO AND m.IDDOCUMENTO = rr.IDRECIBO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_DEPENDENCIAS dep ")
        strSQL.Append("ON m.IDUNIDADSOLICITA = dep.IDDEPENDENCIA ")
        strSQL.Append("RIGHT OUTER JOIN SAB_CAT_ALMACENES alm ")
        strSQL.Append("ON m.IDALMACEN = alm.IDALMACEN ")
        strSQL.Append("ON dm.IDESTABLECIMIENTO = m.IDESTABLECIMIENTO AND dm.IDTIPOTRANSACCION = m.IDTIPOTRANSACCION ")
        strSQL.Append("AND dm.IDMOVIMIENTO = m.IDMOVIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_EMPLEADOS e2 ")
        strSQL.Append("ON m.IDEMPLEADOSOLICITA = e2.IDEMPLEADO ")
        strSQL.Append("ON e3.IDEMPLEADO = m.IDEMPLEADOALMACEN ")
        strSQL.Append("WHERE m.IDTIPOTRANSACCION = 12 ")

        If IDMOVIMIENTO > 0 Then
            strSQL.Append(" AND (m.IDMOVIMIENTO = " + Str(IDMOVIMIENTO) + ") ")
        End If

        If IDALMACEN > 0 Then
            strSQL.Append(" AND (m.IDALMACEN = " + Str(IDALMACEN) + ") ")
        End If

        If ANIO > 0 Then
            strSQL.Append(" AND (m.ANIO = " + Str(ANIO) + ") ")
        End If

        strSQL.Append(" ORDER BY m.FECHAMOVIMIENTO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información completa del recibo de recepción. 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO">El ID del movimiento que se desea recuperar.</param>
    ''' <returns>Dataset con el recibo de recepción.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  22/01/2007    Creado
    '''     [Carlos Ceconi]               26/06/2008    Modificado
    ''' </history>
    Public Function ObtenerReciboRecepcionDS2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("row_number() over(ORDER BY DM.RENGLON, CP.CORRPRODUCTO, DM.IDDETALLEMOVIMIENTO) SECUENCIA, ")
        strSQL.Append("M.*, ")
        strSQL.Append("CASE WHEN M.IDESTADO = 2 THEN 'ACTA' ")
        strSQL.Append("ELSE 'RECIBO' ")
        strSQL.Append("END RECIBOACTA, ")
        strSQL.Append("convert(varchar, RR.IDRECIBO) + '/' + convert(varchar, RR.ANIO) NUMERORECIBO, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("D.NOMBRE NOMBREDEPENDENCIA, ")
        strSQL.Append("E.NOMBRE DESTINO, ")
        strSQL.Append("E2.NOMBRE + ' ' + E2.APELLIDO NOMBREEMPLEADOSOLICITA, ")
        strSQL.Append("M.EMPLEADOALMACEN NOMBREEMPLEADOALMACEN, ")
        strSQL.Append("DM.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("DM.RENGLON, ")
        strSQL.Append("DM.IDPRODUCTO, ")
        strSQL.Append("DM.IDLOTE, ")
        strSQL.Append("DM.CANTIDAD, ")
        strSQL.Append("case M.IDTIPOTRANSACCION ")
        strSQL.Append("when 8 then TDR.DESCRIPCION ")
        strSQL.Append("when 16 then 'Vale de salida' ")
        strSQL.Append("when 17 then 'Devolución' ")
        strSQL.Append("else '' ")
        strSQL.Append("end TIPODOCUMENTO, ")
        strSQL.Append("case M.IDTIPOTRANSACCION ")
        strSQL.Append("when 8 then ")
        strSQL.Append("case ")
        strSQL.Append("when DM.NUMEROFACTURA IS NOT NULL THEN DM.NUMEROFACTURA ")
        strSQL.Append("when DM.NOENVIO IS NOT NULL THEN DM.NOENVIO ")
        strSQL.Append("end ")
        strSQL.Append("when 16 then RR.NUMEROVALE ")
        strSQL.Append("when 17 then RR.NUMEROVALE ")
        strSQL.Append("else '' ")
        strSQL.Append("end DOCUMENTO, ")
        strSQL.Append("DM.FECHAFACTURA, ")
        strSQL.Append("L.PRECIOLOTE PRECIOUNITARIO, ")
        strSQL.Append("(DM.CANTIDAD * L.PRECIOLOTE) MONTOTOTAL, ")
        strSQL.Append("L.IDUNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') NUMEROLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRE RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("L.NUMEROINFORMECONTROLCALIDAD, ")
        strSQL.Append("L.FECHAINFORMECONTROLCALIDAD, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("RR.IDRECIBO, ")
        strSQL.Append("RR.IDPROVEEDOR, ")
        strSQL.Append("RR.IDCONTRATO, ")
        strSQL.Append("RR.RESPONSABLEPROVEEDOR, ")
        strSQL.Append("RR.NUMEROACTA, ")
        strSQL.Append("RR.ADMCONTRATO, ")
        strSQL.Append("case M.IDTIPOTRANSACCION ")
        strSQL.Append("when 8 then P.NOMBRE ")
        strSQL.Append("when 16 then isnull(A1.NOMBRE, '') ")
        strSQL.Append("when 17 then isnull(E1.NOMBRE, '') ")
        strSQL.Append("else '' ")
        strSQL.Append("end NOMBREPROVEEDOR, ")
        strSQL.Append("RR.OBSERVACION, ")
        strSQL.Append("A.DIRECCION DIRECCIONALMACEN ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON M.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_DEPENDENCIAS D ")
        strSQL.Append("ON M.IDUNIDADSOLICITA = D.IDDEPENDENCIA ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON M.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_EMPLEADOS E2 ")
        strSQL.Append("ON M.IDEMPLEADOSOLICITA = E2.IDEMPLEADO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_RECIBOSRECEPCION RR ")
        strSQL.Append("ON M.IDALMACEN = RR.IDALMACEN ")
        strSQL.Append("AND M.IDDOCUMENTO = RR.IDRECIBO ")
        strSQL.Append("AND M.ANIO = RR.ANIO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON RR.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES A1 ")
        strSQL.Append("ON RR.IDALMACENVALE = A1.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E1 ")
        strSQL.Append("ON RR.IDESTABLECIMIENTODEVOLUCION = E1.IDESTABLECIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPODOCUMENTORECEPCION TDR ")
        strSQL.Append("ON DM.IDTIPODOCUMENTO = TDR.IDTIPODOCUMENTORECEPCION ")
        strSQL.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("ORDER BY DM.RENGLON, CP.CORRPRODUCTO, DM.IDDETALLEMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.Int)
        args(2).Value = IDMOVIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información completa del recibo de recepción. 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO">El ID del movimiento que se desea recuperar.</param>
    ''' <param name="IDALMACEN">El ID  del almacÃ©n.</param>
    ''' <returns>Dataset con el recibo de recepciÃ³n.</returns>
    ''' <remarks>Lista de tablas utilizadas en estÃ¡ funciÃ³n:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [JosÃ© Alberto Chávez Loarca]  22/01/2007    Creado
    ''' </history>
    Public Function ObtenerReciboRecepcionDS3(ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal ANIO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDESTABLECIMIENTO, ")
        strSQL.Append("m.IDTIPOTRANSACCION, ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("m.ANIO, ")
        strSQL.Append("m.IDDOCUMENTO, ")
        strSQL.Append("m.IDESTADO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.AUFECHACREACION FECHADOCUMENTO, ")
        strSQL.Append("m.IDALMACEN, ")
        strSQL.Append("alm.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("m.IDUNIDADSOLICITA, ")
        strSQL.Append("dep.NOMBRE NOMBREDEPENDENCIA, ")
        strSQL.Append("m.IDESTABLECIMIENTODESTINO, ")
        strSQL.Append("est.NOMBRE DESTINO, ")
        strSQL.Append("m.TOTALMOVIMIENTO, ")
        strSQL.Append("m.RESPONSABLEDISTRIBUCION NOMBRERESPONSABLEDISTRIBUCION, ")
        strSQL.Append("m.IDEMPLEADOSOLICITA, ")
        strSQL.Append("e2.NOMBRE + ' ' + e2.APELLIDO NOMBREEMPLEADOSOLICITA, ")
        strSQL.Append("m.IDEMPLEADOALMACEN, ")
        strSQL.Append("e3.NOMBRE + ' ' + e3.APELLIDO NOMBREEMPLEADOALMACEN, ")
        strSQL.Append("dm.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("dm.RENGLON, ")
        strSQL.Append("dm.IDPRODUCTO, ")
        strSQL.Append("dm.IDLOTE, ")
        strSQL.Append("dm.CANTIDAD, ")
        strSQL.Append("dm.NUMEROFACTURA, ")
        strSQL.Append("dm.FECHAFACTURA, ")
        strSQL.Append("dm.MONTO PRECIOUNITARIO, ")
        strSQL.Append("(dm.CANTIDAD * dm.MONTO) MONTOTOTAL, ")
        strSQL.Append("l.IDUNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') NUMEROLOTE, ")
        strSQL.Append("l.FECHAVENCIMIENTO, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("rpd.NOMBRE RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("ff.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("cp.CORRPRODUCTO, ")
        strSQL.Append("cp.DESCLARGO, ")
        strSQL.Append("cp.IDNIVELUSO, ")
        strSQL.Append("um.DESCRIPCION, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("rr.IDPROVEEDOR, ")
        strSQL.Append("rr.IDCONTRATO, ")
        strSQL.Append("rr.RESPONSABLEPROVEEDOR, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("pv.NOMBRE NOMBREPROVEEDOR, ")
        strSQL.Append("rr.OBSERVACION, ")
        strSQL.Append("alm.DIRECCION DIRECCIONALMACEN, ")
        strSQL.Append("dm.ESTASINCRONIZADA ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_DEPENDENCIAS AS dep RIGHT OUTER JOIN ")
        strSQL.Append("SAB_CAT_EMPLEADOS AS e3 RIGHT OUTER JOIN ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS m INNER JOIN ")
        strSQL.Append("SAB_ALM_DETALLEMOVIMIENTOS AS dm ON m.IDESTABLECIMIENTO = dm.IDESTABLECIMIENTO AND ")
        strSQL.Append("m.IDTIPOTRANSACCION = dm.IDTIPOTRANSACCION AND m.IDMOVIMIENTO = dm.IDMOVIMIENTO LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_EMPLEADOS AS e2 ON m.IDEMPLEADOSOLICITA = e2.IDEMPLEADO ON e3.IDEMPLEADO = m.IDEMPLEADOALMACEN ON ")
        strSQL.Append("dep.IDDEPENDENCIA = m.IDUNIDADSOLICITA LEFT OUTER JOIN ")
        strSQL.Append("SAB_ALM_RECIBOSRECEPCION AS rr LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES AS pv ON rr.IDPROVEEDOR = pv.IDPROVEEDOR ON m.IDALMACEN = rr.IDALMACEN AND ")
        strSQL.Append("m.IDDOCUMENTO = rr.IDRECIBO AND m.ANIO = rr.ANIO LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_ALMACENES AS alm ON m.IDALMACEN = alm.IDALMACEN LEFT OUTER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS cp RIGHT OUTER JOIN ")
        strSQL.Append("SAB_CAT_FUENTEFINANCIAMIENTOS AS ff RIGHT OUTER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS l ON ff.IDFUENTEFINANCIAMIENTO = l.IDFUENTEFINANCIAMIENTO LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_RESPONSABLEDISTRIBUCION AS rpd ON l.IDRESPONSABLEDISTRIBUCION = rpd.IDRESPONSABLEDISTRIBUCION ON ")
        strSQL.Append("cp.IDPRODUCTO = l.IDPRODUCTO LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS AS um ON l.IDUNIDADMEDIDA = um.IDUNIDADMEDIDA ON dm.IDALMACEN = l.IDALMACEN AND ")
        strSQL.Append("dm.IDLOTE = l.IDLOTE LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS AS est ON m.IDESTABLECIMIENTODESTINO = est.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE m.IDTIPOTRANSACCION = 12 ")

        If IDMOVIMIENTO > 0 Then
            strSQL.Append(" AND (m.IDMOVIMIENTO = " + Str(IDMOVIMIENTO) + ") ")
        End If

        If IDALMACEN > 0 Then
            strSQL.Append(" AND (m.IDALMACEN = " + Str(IDALMACEN) + ") ")
        End If

        strSQL.Append(" ORDER BY m.FECHAMOVIMIENTO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información de los recibos de recepción con estado Guardado, muestra solo la
    ''' información de la tabla principal.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertencen los recibos.</param>
    ''' <param name="IDALMACEN">Identificador del almacén(Filtro).</param>
    ''' <returns>Dataset con la información de los recibos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  30/01/2007    Creado
    ''' </history> 
    Public Function ObtenerRecepcionesPrincipalDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDRECIBO As Int32, ByVal IDALMACEN As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDALMACEN, ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("tdr.DESCRIPCION AS DESCRIPCIONTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("p.NOMBRE AS NOMBREPROVEEDOR, ")
        strSQL.Append("m.CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("f.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("r.NOMBRECORTO NOMBRERESPONSABLE ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_ALM_LOTES l ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS dm ")
        strSQL.Append("ON l.IDALMACEN = dm.IDALMACEN AND l.IDLOTE = dm.IDLOTE ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS f ")
        strSQL.Append("ON l.IDFUENTEFINANCIAMIENTO = f.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION r ")
        strSQL.Append("ON l.IDRESPONSABLEDISTRIBUCION = r.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("RIGHT OUTER JOIN SAB_CAT_PROVEEDORES p ")
        strSQL.Append("INNER JOIN SAB_ALM_RECIBOSRECEPCION rr ")
        strSQL.Append("ON p.IDPROVEEDOR = rr.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS m ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOREFERENCIAS tdr ")
        strSQL.Append("ON m.IDTIPODOCREF = tdr.IDTIPODOCREF ON rr.IDALMACEN = m.IDALMACEN AND rr.IDRECIBO = m.IDDOCUMENTO ")
        strSQL.Append("ON dm.IDESTABLECIMIENTO = m.IDESTABLECIMIENTO AND dm.IDTIPOTRANSACCION = m.IDTIPOTRANSACCION AND dm.IDMOVIMIENTO = m.IDMOVIMIENTO ")
        strSQL.Append("WHERE (m.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (m.IDTIPOTRANSACCION = 8) AND (m.IDESTADO = 1) AND (m.IDALMACEN = @IDALMACEN) ")
        If IDRECIBO > 0 Then
            strSQL.Append(" AND (m.IDDOCUMENTO = @IDRECIBO ) ")
        End If
        strSQL.Append("GROUP BY ")
        strSQL.Append("m.IDALMACEN, ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("tdr.DESCRIPCION, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("p.NOMBRE, ")
        strSQL.Append("m.CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("f.NOMBRE, ")
        strSQL.Append("r.NOMBRECORTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDRECIBO", SqlDbType.Int)
        args(1).Value = IDRECIBO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function

    ''' <summary>
    ''' Devuelve la información de los recibos de recepción con estado Cerrado, muestra solo la
    ''' información de la tabla principal.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertencen los recibos.</param>
    ''' <returns>Dataset con la información de los recibos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  30/01/2007    Creado
    ''' </history> 
    Public Function BuscarRecepcionesPrincipalDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDRECIBO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("tdr.DESCRIPCION AS DESCRIPCIONTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("p.NOMBRE AS NOMBREPROVEEDOR, ")
        strSQL.Append("m.CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("f.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("r.NOMBRE NOMBRERESPONSABLE ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_ALM_LOTES l ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS dm ")
        strSQL.Append("ON l.IDALMACEN = dm.IDALMACEN AND l.IDLOTE = dm.IDLOTE ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS f ")
        strSQL.Append("ON l.IDFUENTEFINANCIAMIENTO = f.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION r ")
        strSQL.Append("ON l.IDRESPONSABLEDISTRIBUCION = r.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("RIGHT OUTER JOIN SAB_CAT_PROVEEDORES p ")
        strSQL.Append("INNER JOIN SAB_ALM_RECIBOSRECEPCION rr ")
        strSQL.Append("ON p.IDPROVEEDOR = rr.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS m ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOREFERENCIAS tdr ")
        strSQL.Append("ON m.IDTIPODOCREF = tdr.IDTIPODOCREF ON rr.IDALMACEN = m.IDALMACEN AND rr.IDRECIBO = m.IDDOCUMENTO ")
        strSQL.Append("ON dm.IDESTABLECIMIENTO = m.IDESTABLECIMIENTO AND dm.IDTIPOTRANSACCION = m.IDTIPOTRANSACCION AND dm.IDMOVIMIENTO = m.IDMOVIMIENTO ")
        strSQL.Append("WHERE (m.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (m.IDTIPOTRANSACCION = 8) AND (m.IDESTADO = 2) ")
        If IDRECIBO > 0 Then
            strSQL.Append(" AND (m.IDDOCUMENTO = @IDRECIBO ) ")
        End If
        strSQL.Append("GROUP BY ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("tdr.DESCRIPCION, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("p.NOMBRE, ")
        strSQL.Append("m.CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("f.NOMBRE, ")
        strSQL.Append("r.NOMBRE ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDRECIBO", SqlDbType.Int)
        args(1).Value = IDRECIBO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function

    ''' <summary>
    ''' Devuelve la información de los recibos de recepción con estado Cerrado, muestra solo la
    ''' información de la tabla principal.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertencen los recibos.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param> 
    ''' <param name="IDFUENTE">Identificador de la fuente de financiamiento.</param> 
    ''' <param name="IDRESPONSABLE">Identificador del responsable de distribución.</param>
    ''' <returns>Dataset con la información de los recibos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  30/01/2007    Creado
    ''' </history> 
    Public Function BuscarRecepcionesPrincipalGeneral(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDFUENTE As Int32, ByVal IDRESPONSABLE As Int32, ByVal FECHAINICIO As Date) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("tdr.DESCRIPCION AS DESCRIPCIONTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("p.NOMBRE AS NOMBREPROVEEDOR, ")
        strSQL.Append("m.CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("f.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("r.NOMBRE NOMBRERESPONSABLE ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_ALM_LOTES l ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS dm ")
        strSQL.Append("ON l.IDALMACEN = dm.IDALMACEN AND l.IDLOTE = dm.IDLOTE ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS f ")
        strSQL.Append("ON l.IDFUENTEFINANCIAMIENTO = f.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION r ")
        strSQL.Append("ON l.IDRESPONSABLEDISTRIBUCION = r.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("RIGHT OUTER JOIN SAB_CAT_PROVEEDORES p ")
        strSQL.Append("INNER JOIN SAB_ALM_RECIBOSRECEPCION rr ")
        strSQL.Append("ON p.IDPROVEEDOR = rr.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS m ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOREFERENCIAS tdr ")
        strSQL.Append("ON m.IDTIPODOCREF = tdr.IDTIPODOCREF ON rr.IDALMACEN = m.IDALMACEN AND rr.IDRECIBO = m.IDDOCUMENTO ")
        strSQL.Append("ON dm.IDESTABLECIMIENTO = m.IDESTABLECIMIENTO AND dm.IDTIPOTRANSACCION = m.IDTIPOTRANSACCION AND dm.IDMOVIMIENTO = m.IDMOVIMIENTO ")
        strSQL.Append("WHERE (m.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (m.IDTIPOTRANSACCION = 8) AND (m.IDESTADO = 2) ")

        'EN MODIFICACION
        If IDPROVEEDOR > 0 Then
            strSQL.Append(" AND (rr.IDPROVEEDOR = @IDPROVEEDOR) ")
        End If
        If IDFUENTE > 0 Then
            strSQL.Append(" AND (l.IDFUENTEFINANCIAMIENTO = @IDFUENTE) ")
        End If
        If IDRESPONSABLE > 0 Then
            strSQL.Append("AND (l.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLE) ")
        End If

        strSQL.Append("GROUP BY ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("tdr.DESCRIPCION, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("p.NOMBRE, ")
        strSQL.Append("m.CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("f.NOMBRE, ")
        strSQL.Append("r.NOMBRE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDFUENTE", SqlDbType.Int)
        args(2).Value = IDFUENTE
        args(3) = New SqlParameter("@IDRESPONSABLE", SqlDbType.Int)
        args(3).Value = IDRESPONSABLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function

    ''' <summary>
    ''' Devuelve la información de los recibos de recepción con estado Guardado, muestra solo la
    ''' información de la tabla principal.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertencen los recibos.</param>
    ''' <returns>Dataset con la información de los recibos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  30/01/2007    Creado
    ''' </history> 
    Public Function ObtenerRecepcionesDependenciaPrincipalDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDRECIBO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("tdr.DESCRIPCION AS DESCRIPCIONTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("p.NOMBRE AS NOMBREPROVEEDOR, ")
        strSQL.Append("m.CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("dm.IDLOTE, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("f.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("r.NOMBRECORTO NOMBRERESPONSABLE, ")
        strSQL.Append("m.IDUNIDADSOLICITA, ")
        strSQL.Append("dep.NOMBRE NOMBREDEPENDENCIA ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_DEPENDENCIAS dep ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS m ")
        strSQL.Append("INNER JOIN SAB_ALM_RECIBOSRECEPCION rr ")
        strSQL.Append("ON m.IDALMACEN = rr.IDALMACEN AND m.IDDOCUMENTO = rr.IDRECIBO ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOREFERENCIAS tdr ")
        strSQL.Append("ON m.IDTIPODOCREF = tdr.IDTIPODOCREF ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS dm ")
        strSQL.Append("ON m.IDESTABLECIMIENTO = dm.IDESTABLECIMIENTO AND m.IDTIPOTRANSACCION = dm.IDTIPOTRANSACCION ")
        strSQL.Append("AND m.IDMOVIMIENTO = dm.IDMOVIMIENTO ")
        strSQL.Append("ON dep.IDDEPENDENCIA = m.IDUNIDADSOLICITA ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS f ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES l ")
        strSQL.Append("ON f.IDFUENTEFINANCIAMIENTO = l.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION r ")
        strSQL.Append("ON l.IDRESPONSABLEDISTRIBUCION = r.IDRESPONSABLEDISTRIBUCION ON dm.IDALMACEN = l.IDALMACEN ")
        strSQL.Append("AND dm.IDLOTE = l.IDLOTE ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_PROVEEDORES p ON rr.IDPROVEEDOR = p.IDPROVEEDOR ")
        strSQL.Append("WHERE (m.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (m.IDTIPOTRANSACCION = 12) AND (m.IDESTADO = 1)")
        If IDRECIBO > 0 Then
            strSQL.Append(" AND (m.IDDOCUMENTO = @IDRECIBO ) ")
        End If
        strSQL.Append("GROUP BY ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("tdr.DESCRIPCION, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("p.NOMBRE, ")
        strSQL.Append("m.CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("dm.IDLOTE, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("f.NOMBRE, ")
        strSQL.Append("m.IDUNIDADSOLICITA, ")
        strSQL.Append("dep.NOMBRE, ")
        strSQL.Append("r.NOMBRECORTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDRECIBO", SqlDbType.Int)
        args(1).Value = IDRECIBO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información de los informes de no aceptación con estado Guardado, muestra solo la
    ''' información de la tabla principal.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertencen los informes.</param>
    ''' <returns>Dataset con la información de los informes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_INFORMESNOACEPTACION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  30/01/2007    Creado
    ''' </history> 
    Public Function ObtenerNoAceptacionPrincipalDS(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("ia.IDINFORME, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("tdr.DESCRIPCION DESCRIPCIONTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("p.NOMBRE NOMBREPROVEEDOR, ")
        strSQL.Append("m.CLASIFICACIONMOVIMIENTO ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_TIPODOCUMENTOREFERENCIAS AS tdr RIGHT OUTER JOIN ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS m ON tdr.IDTIPODOCREF = m.IDTIPODOCREF LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES AS p RIGHT OUTER JOIN ")
        strSQL.Append("SAB_ALM_INFORMESNOACEPTACION AS ia ON p.IDPROVEEDOR = ia.IDPROVEEDOR ON m.IDALMACEN = ia.IDALMACEN AND ")
        strSQL.Append("m.IDDOCUMENTO = ia.IDINFORME And m.ANIO = ia.ANIO ")
        strSQL.Append("WHERE ")
        strSQL.Append("m.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND m.IDTIPOTRANSACCION = 11 AND m.IDESTADO = 1 ")
        strSQL.Append("ORDER BY m.FECHAMOVIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información completa del informe de no aceptación. 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO">El ID del movimiento que se desea recuperar.</param>
    ''' <param name="IDESTABLECIMIENTO">El ID  del establecimiento.</param>
    ''' <returns>Dataset con el recibo de recepción.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_INFORMESNOACEPTACION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  Creado
    ''' </history>
    Public Function ObtenerNoAceptacionDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("M.*, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("M.EMPLEADOALMACEN NOMBREEMPLEADOALMACEN, ")
        strSQL.Append("DM.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("DM.RENGLON, ")
        strSQL.Append("DM.IDPRODUCTO, ")
        strSQL.Append("DM.IDLOTE, ")
        strSQL.Append("DM.CANTIDAD, ")
        strSQL.Append("TDR.DESCRIPCION TIPODOCUMENTO, ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN DM.NUMEROFACTURA IS NOT NULL THEN DM.NUMEROFACTURA ")
        strSQL.Append("WHEN DM.NOENVIO IS NOT NULL THEN DM.NOENVIO ")
        strSQL.Append("END DOCUMENTO, ")
        strSQL.Append("DM.FECHAFACTURA FECHADOCUMENTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("INA.IDINFORME, ")
        strSQL.Append("INA.IDPROVEEDOR, ")
        strSQL.Append("INA.IDCONTRATO, ")
        strSQL.Append("INA.RESPONSABLEPROVEEDOR, ")
        strSQL.Append("convert(varchar, INA.IDINFORME) + '/' + convert(varchar, INA.ANIO) NUMEROINFORME, ")
        strSQL.Append("P.NOMBRE NOMBREPROVEEDOR, ")
        strSQL.Append("INA.MOTIVO MOTIVONOACEPTACION, ")
        strSQL.Append("INA.OBSERVACION, ")
        strSQL.Append("A.DIRECCION DIRECCIONALMACEN ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON M.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_INFORMESNOACEPTACION INA ")
        strSQL.Append("ON M.IDALMACEN = INA.IDALMACEN ")
        strSQL.Append("AND M.IDDOCUMENTO = INA.IDINFORME ")
        strSQL.Append("AND M.ANIO = INA.ANIO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON INA.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("LEFT OUTER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPODOCUMENTORECEPCION TDR ")
        strSQL.Append("ON DM.IDTIPODOCUMENTO = TDR.IDTIPODOCUMENTORECEPCION ")
        strSQL.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = 11 ")
        strSQL.Append("ORDER BY M.FECHAMOVIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.Int)
        args(1).Value = IDMOVIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información completa del recibo de recepción. 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO">El ID del movimiento que se desea recuperar.</param>
    ''' <param name="IDALMACEN">El ID  del almacén.</param>
    ''' <returns>Dataset con el recibo de recepción.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  22/01/2007    Creado
    ''' </history>
    Public Function BuscarRecepciones(ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int32, ByVal ANIO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDESTABLECIMIENTO, ")
        strSQL.Append("m.IDTIPOTRANSACCION, ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
        strSQL.Append("m.ANIO, ")
        strSQL.Append("m.IDDOCUMENTO, ")
        strSQL.Append("m.IDESTADO, ")
        strSQL.Append("m.FECHAMOVIMIENTO, ")
        strSQL.Append("m.IDALMACEN, ")
        strSQL.Append("rr.IDRECIBO, ")
        strSQL.Append("rr.IDPROVEEDOR, ")
        strSQL.Append("rr.IDCONTRATO, ")
        strSQL.Append("rr.NUMEROACTA, ")
        strSQL.Append("pv.NOMBRE NOMBREPROVEEDOR ")
        strSQL.Append("FROM SAB_CAT_PROVEEDORES pv ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS m ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS dm ")
        strSQL.Append("ON m.IDESTABLECIMIENTO = dm.IDESTABLECIMIENTO AND m.IDTIPOTRANSACCION = dm.IDTIPOTRANSACCION AND m.IDMOVIMIENTO = dm.IDMOVIMIENTO ")
        strSQL.Append("INNER JOIN SAB_ALM_RECIBOSRECEPCION rr ")
        strSQL.Append("ON m.IDALMACEN = rr.IDALMACEN AND m.IDDOCUMENTO = rr.IDRECIBO AND m.ANIO = rr.ANIO ")
        strSQL.Append("ON alm.IDALMACEN = m.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_DEPENDENCIAS dep ")
        strSQL.Append("ON m.IDUNIDADSOLICITA = dep.IDDEPENDENCIA ")
        strSQL.Append("ON pv.IDPROVEEDOR = rr.IDPROVEEDOR ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION rpd ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES l ")
        strSQL.Append("ON cp.IDPRODUCTO = l.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS um ")
        strSQL.Append("ON l.IDUNIDADMEDIDA = um.IDUNIDADMEDIDA ")
        strSQL.Append("ON rpd.IDRESPONSABLEDISTRIBUCION = l.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS ff ")
        strSQL.Append("ON l.IDFUENTEFINANCIAMIENTO = ff.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("ON dm.IDALMACEN = l.IDALMACEN AND dm.IDLOTE = l.IDLOTE ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS est ")
        strSQL.Append("ON m.IDESTABLECIMIENTODESTINO = est.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS e2 ")
        strSQL.Append("ON m.IDEMPLEADOSOLICITA = e2.IDEMPLEADO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS e3 ")
        strSQL.Append("ON m.IDEMPLEADOALMACEN = e3.IDEMPLEADO ")
        strSQL.Append("WHERE m.IDTIPOTRANSACCION = 8 ")

        If IDMOVIMIENTO > 0 Then
            strSQL.Append(" AND (m.IDMOVIMIENTO = " + Str(IDMOVIMIENTO) + ") ")
        End If

        If IDALMACEN > 0 Then
            strSQL.Append(" AND (m.IDALMACEN = " + Str(IDALMACEN) + ") ")
        End If

        strSQL.Append(" ORDER BY m.FECHAMOVIMIENTO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene la informacion de la existencia historica por producto
    ''' </summary>
    ''' <param name="IDALMACEN">Identificacion del almacen</param>
    ''' <param name="IDPRODUCTO">Identificación del producto</param>
    ''' <param name="FECHAHASTA">Identificacion de la fecha limite</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificacion de la fuente de financiamiento</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificacion del responsable de distribucion</param>
    ''' <returns>dataset</returns>

    Public Function ExistenciaHistoricaPorProducto(ByVal IDALMACEN As Integer, ByVal IDPRODUCTO As Integer, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_ExistenciaHistoricaPorProducto")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Direction = ParameterDirection.Input
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDFUENTEFINANCIAMIENTO
        args(3) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = IDRESPONSABLEDISTRIBUCION
        args(4) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = FECHAHASTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve un listado de los movimientos al inventario filtrado por cada uno de los parametros, solamente 
    ''' muestra la información de la tabla padre.
    ''' </summary>
    ''' <param name="IDMOVIMIENTO">Identificador del movimiento que se desea recuperar. (Filtro)</param>
    ''' <param name="IDALMACENDESTINO ">Identificador del almacén destino. (Filtro)</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la unidad que solicita. (Filtro)</param>
    ''' <param name="IDTIPOCONSULTA">Identificador del tipo de consulta que se desea aplicar. </param>
    ''' <param name="CLASIFICACION">Identificador de la clasificación del movimiento.(Filtro)</param> 
    ''' <returns>Dataset con el listado de movimientos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list>
    ''' <history>
    '''     [JosÃ© Alberto ChÃ¡vez Loarca]  10/02/2007    Creado
    ''' </history>  
    ''' </remarks>
    Public Function ObtenerRequisicionesFiltradas(ByVal IDMOVIMIENTO As Int64, ByVal IDALMACENDESTINO As Int32, ByVal IDDEPENDENCIA As Int32, ByVal IDTIPOCONSULTA As Int16, Optional ByVal CLASIFICACION As Int16 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("M.IDESTABLECIMIENTO, ")
        strSQL.Append("M.IDTIPOTRANSACCION, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("M.IDTIPODOCREF, ")
        strSQL.Append("M.NUMERODOCREF, ")
        strSQL.Append("M.ANIO, ")
        strSQL.Append("M.IDDOCUMENTO, ")
        strSQL.Append("M.IDESTADO, ")
        strSQL.Append("M.FECHAMOVIMIENTO, ")
        strSQL.Append("M.IDALMACEN, ")
        strSQL.Append("M.IDESTABLECIMIENTODESTINO, ")
        strSQL.Append("EST.NOMBRE AS ESTABLECIMIENTODESTINO, ")
        strSQL.Append("M.IDALMACENDESTINO, ")
        strSQL.Append("(SELECT NOMBRE FROM SAB_CAT_ALMACENES WHERE (IDALMACEN = M.IDALMACENDESTINO)) AS NOMBREALMACENDESTINO, ")
        strSQL.Append("M.IDUNIDADSOLICITA, ")
        strSQL.Append("M.TOTALMOVIMIENTO, ")
        strSQL.Append("M.AUFECHACREACION, ")
        strSQL.Append("TDR.DESCRIPCION AS DESCRIPCIONTIPODOCUREFERENCIA, ")
        strSQL.Append("A.NOMBRE AS NOMBREALMACEN, ")
        strSQL.Append("EM.DESCRIPCION AS DESCRIPCIONESTADO, ")
        strSQL.Append("D.NOMBRE AS NOMBREDEPEDENCIASOLICITA, ")
        strSQL.Append("M.IDEMPLEADOSOLICITA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = M.IDEMPLEADOSOLICITA)) AS NOMBREEMPLEADOSOLICITA, ")
        strSQL.Append("M.IDEMPLEADOAUTORIZA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_1 WHERE (IDEMPLEADO = M.IDEMPLEADOAUTORIZA)) AS NOMBREEMPLEADOAUTORIZA, ")
        strSQL.Append("M.IDEMPLEADOALMACEN, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_2 WHERE (IDEMPLEADO = M.IDEMPLEADOALMACEN)) AS NOMBREEMPLEADOALMACEN, ")
        strSQL.Append("M.IDEMPLEADODESPACHA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_6 WHERE (IDEMPLEADO = M.IDEMPLEADODESPACHA)) AS NOMBREEMPLEADODESPACHA, ")
        strSQL.Append("M.IDEMPLEADORECIBE, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_5 WHERE (IDEMPLEADO = M.IDEMPLEADORECIBE)) AS NOMBREEMPLEADORECIBE, ")
        strSQL.Append("M.IDEMPLEADOPREPARA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_4 WHERE (IDEMPLEADO = M.IDEMPLEADOPREPARA)) AS NOMBREEMPLEADOPREPARA, ")
        strSQL.Append("M.IDEMPLEADOENVIADO, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_3 WHERE (IDEMPLEADO = M.IDEMPLEADOENVIADO)) AS NOMBREEMPLEADOENVIADO, ")
        strSQL.Append("TT.DESCRIPCION AS DESCRIPCIONTIPOMOVIMIENTO, ")
        strSQL.Append("M.CLASIFICACIONMOVIMIENTO, M.SUBCLASIFICACIONMOVIMIENTO ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS AS M ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON M.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS EM ")
        strSQL.Append("ON M.IDESTADO = EM.IDESTADO ")
        strSQL.Append("INNER JOIN SAB_CAT_DEPENDENCIAS D ")
        strSQL.Append("ON M.IDUNIDADSOLICITA = D.IDDEPENDENCIA ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOTRANSACCIONES TT ")
        strSQL.Append("ON M.IDTIPOTRANSACCION = TT.IDTIPOTRANSACCION ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPODOCUMENTOREFERENCIAS TDR ")
        strSQL.Append("ON M.IDTIPODOCREF = TDR.IDTIPODOCREF ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS EST ")
        strSQL.Append("ON M.IDESTABLECIMIENTODESTINO = EST.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE (M.IDALMACENDESTINO = @IDALMACENDESTINO) ")

        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append(" AND (M.IDESTADO in (1, 2)) ")
            Case Is = 2
                strSQL.Append(" AND (M.IDESTADO = 1) ")
            Case Is = 3
                strSQL.Append(" AND (M.IDESTADO = 4) ")
            Case Is = 4
                strSQL.Append(" AND (M.IDESTADO = 2) ")
        End Select

        If IDMOVIMIENTO > 0 Then
            strSQL.Append(" AND (M.IDMOVIMIENTO = " + Str(IDMOVIMIENTO) + ") ")
        End If

        If IDDEPENDENCIA > 0 Then
            strSQL.Append(" AND (M.IDUNIDADSOLICITA = " + Str(IDDEPENDENCIA) + ") ")
        End If

        Select Case CLASIFICACION
            Case Is = 10
                strSQL.Append(" AND (M.CLASIFICACIONMOVIMIENTO = 10) ")
            Case Is = 0
                strSQL.Append(" AND (M.CLASIFICACIONMOVIMIENTO <> 10)")
        End Select

        strSQL.Append(" ORDER BY M.FECHAMOVIMIENTO DESC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACENDESTINO", SqlDbType.Int)
        args(0).Value = IDALMACENDESTINO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve un listado de los movimientos al inventario filtrado por cada uno de los parÃ¡metros, solamente 
    ''' muestra la informaciÃ³n de la tabla padre.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTODESTINO">Identificador del establecimiento de destino.(Filtro)</param>
    ''' <param name="IDMOVIMIENTO">Identificador del movimiento que se desea recuperar.(Filtro)</param>
    ''' <param name="IDALMACENDESTINO">Identificador del almacÃ©n destino.(Filtro)</param>
    ''' <param name="IDTIPOCONSULTA">Identificador del tipo de consulta que se desea aplicar.</param>
    ''' <param name="CLASIFICACION">ClasificaciÃ³n del movimiento.(Filtro)</param>
    ''' <returns>Dataset con el listado de vales de salida pendientes de despacho en el almacÃ©n.</returns>
    ''' <remarks>Lista de tablas utilizadas en estÃ¡ funciÃ³n:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [JosÃ© Alberto ChÃ¡vez Loarca]  11/12/2006    Creado
    ''' </history> 
    Public Function ObtenerValesPendientesAlmacen(ByVal IDESTABLECIMIENTOORIGEN As Int32, ByVal IDESTABLECIMIENTODESTINO As Int32, ByVal IDMOVIMIENTO As Int64, ByVal IDALMACENDESTINO As Int32, ByVal IDTIPOCONSULTA As Int16, Optional ByVal CLASIFICACION As Int16 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("M.IDESTABLECIMIENTO, ")
        strSQL.Append("M.IDTIPOTRANSACCION, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("M.IDTIPODOCREF, ")
        strSQL.Append("M.NUMERODOCREF, ")
        strSQL.Append("M.ANIO, ")
        strSQL.Append("M.IDDOCUMENTO, ")
        strSQL.Append("M.IDESTADO, ")
        strSQL.Append("M.FECHAMOVIMIENTO, ")
        strSQL.Append("M.IDALMACEN, ")
        strSQL.Append("M.IDESTABLECIMIENTODESTINO, ")
        strSQL.Append("EST.NOMBRE AS ESTABLECIMIENTODESTINO, ")
        strSQL.Append("M.IDALMACENDESTINO, ")
        strSQL.Append("(SELECT NOMBRE FROM SAB_CAT_ALMACENES WHERE (IDALMACEN = M.IDALMACENDESTINO)) AS NOMBREALMACENDESTINO, ")
        strSQL.Append("M.IDUNIDADSOLICITA, ")
        strSQL.Append("M.TOTALMOVIMIENTO, ")
        strSQL.Append("M.AUFECHACREACION, ")
        strSQL.Append("TDR.DESCRIPCION AS DESCRIPCIONTIPODOCUREFERENCIA, ")
        strSQL.Append("A.NOMBRE AS NOMBREALMACEN, ")
        strSQL.Append("EM.DESCRIPCION AS DESCRIPCIONESTADO, ")
        strSQL.Append("D.NOMBRE AS NOMBREDEPEDENCIASOLICITA, ")
        strSQL.Append("M.IDEMPLEADOSOLICITA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = M.IDEMPLEADOSOLICITA)) AS NOMBREEMPLEADOSOLICITA, ")
        strSQL.Append("M.IDEMPLEADOAUTORIZA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_1 WHERE (IDEMPLEADO = M.IDEMPLEADOAUTORIZA)) AS NOMBREEMPLEADOAUTORIZA, ")
        strSQL.Append("M.IDEMPLEADOALMACEN, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_2 WHERE (IDEMPLEADO = M.IDEMPLEADOALMACEN)) AS NOMBREEMPLEADOALMACEN, ")
        strSQL.Append("M.IDEMPLEADODESPACHA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_6 WHERE (IDEMPLEADO = M.IDEMPLEADODESPACHA)) AS NOMBREEMPLEADODESPACHA, ")
        strSQL.Append("M.IDEMPLEADORECIBE, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_5 WHERE (IDEMPLEADO = M.IDEMPLEADORECIBE)) AS NOMBREEMPLEADORECIBE, ")
        strSQL.Append("M.IDEMPLEADOPREPARA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_4 WHERE (IDEMPLEADO = M.IDEMPLEADOPREPARA)) AS NOMBREEMPLEADOPREPARA, ")
        strSQL.Append("M.IDEMPLEADOENVIADO, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_3 WHERE (IDEMPLEADO = M.IDEMPLEADOENVIADO)) AS NOMBREEMPLEADOENVIADO, ")
        strSQL.Append("TT.DESCRIPCION AS DESCRIPCIONTIPOMOVIMIENTO, ")
        strSQL.Append("M.CLASIFICACIONMOVIMIENTO, M.SUBCLASIFICACIONMOVIMIENTO ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS M LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_DEPENDENCIAS AS D ON M.IDUNIDADSOLICITA = D.IDDEPENDENCIA LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_TIPOTRANSACCIONES AS TT ON M.IDTIPOTRANSACCION = TT.IDTIPOTRANSACCION LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_ESTADOSMOVIMIENTOS AS EM ON M.IDESTADO = EM.IDESTADO LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_ALMACENES AS A ON M.IDALMACEN = A.IDALMACEN LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_TIPODOCUMENTOREFERENCIAS AS TDR ON M.IDTIPODOCREF = TDR.IDTIPODOCREF LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS AS EST ON M.IDESTABLECIMIENTODESTINO = EST.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE (M.IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO) ")
        strSQL.Append("AND (M.IDTIPOTRANSACCION = 2) ")

        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append(" AND (M.IDESTADO in (1, 2)) ")
            Case Is = 2
                strSQL.Append(" AND (M.IDESTADO = 1) ")
            Case Is = 3
                strSQL.Append(" AND (M.IDESTADO = 4) ")
            Case Is = 4
                strSQL.Append(" AND (M.IDESTADO = 2) ")
        End Select

        If IDMOVIMIENTO > 0 Then
            strSQL.Append(" AND (M.IDMOVIMIENTO = " + Str(IDMOVIMIENTO) + ") ")
        End If

        If IDALMACENDESTINO > 0 Then
            strSQL.Append(" AND (M.IDALMACENDESTINO = " + Str(IDALMACENDESTINO) + ") ")
        End If

        If IDESTABLECIMIENTOORIGEN > 0 Then
            strSQL.Append(" AND (M.IDESTABLECIMIENTO = " + Str(IDESTABLECIMIENTOORIGEN) + ") ")
        End If

        Select Case CLASIFICACION
            Case Is = 10
                strSQL.Append(" AND (M.CLASIFICACIONMOVIMIENTO = 10) ")
            Case Is = 0
                strSQL.Append(" AND (M.CLASIFICACIONMOVIMIENTO <> 10)")
        End Select

        strSQL.Append(" ORDER BY M.FECHAMOVIMIENTO DESC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTODESTINO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener la informacion de los vales pendientes en un almacen
    ''' </summary>
    ''' <param name="IDALMACENDESTINO">Identificación del almacen destino</param>
    ''' <param name="IDMOVIMIENTO">Identificacion del movimiento</param>
    ''' <returns>dataset</returns>

    Public Function ObtenerValesPendientesAlmacen(ByVal IDALMACENDESTINO As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("M.*, ")
        strSQL.Append("A.NOMBRE AS NOMBREALMACEN, ")
        strSQL.Append("EM.DESCRIPCION AS DESCRIPCIONESTADO ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON M.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS EM ")
        strSQL.Append("ON M.IDESTADO = EM.IDESTADO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_RECIBOSRECEPCION RR ")
        strSQL.Append("ON M.IDALMACEN = RR.IDALMACENVALE ")
        strSQL.Append("AND M.ANIO = RR.ANIOVALE ")
        strSQL.Append("AND M.IDDOCUMENTO = RR.IDVALE ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_MOVIMIENTOS M1 ")
        strSQL.Append("ON RR.IDALMACEN = M1.IDALMACEN ")
        strSQL.Append("AND RR.ANIO = M1.ANIO ")
        strSQL.Append("AND RR.IDRECIBO = M1.IDDOCUMENTO ")
        strSQL.Append("AND M1.IDTIPOTRANSACCION = 8 ")
        strSQL.Append("WHERE M.IDALMACENDESTINO = @IDALMACENDESTINO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = 2 ")
        strSQL.Append("AND M.IDESTADO = 2 ")
        strSQL.Append("AND (M1.IDESTADO = 1 or M1.IDESTADO is null) ")
        strSQL.Append("ORDER BY M.FECHAMOVIMIENTO DESC, M.IDMOVIMIENTO DESC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACENDESTINO", SqlDbType.Int)
        args(0).Value = IDALMACENDESTINO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Consulta de movimientos
    ''' </summary>
    ''' <param name="aEntidad">Entidad que identifica la informacion del movimiento</param>
    ''' <returns>Valor entero con el resultado de la consulta</returns>

    Public Function Recuperar2(ByVal aEntidad As MOVIMIENTOS) As Integer

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND IDDOCUMENTO = @IDDOCUMENTO ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDALMACEN = @IDALMACEN ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = aEntidad.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDDOCUMENTO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDDOCUMENTO
        args(3) = New SqlParameter("@ANIO", SqlDbType.Int)
        args(3).Value = aEntidad.ANIO
        args(4) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(4).Value = aEntidad.IDALMACEN

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    aEntidad.IDTIPODOCREF = IIf(dr("IDTIPODOCREF") Is DBNull.Value, Nothing, dr("IDTIPODOCREF"))
                    aEntidad.NUMERODOCREF = IIf(dr("NUMERODOCREF") Is DBNull.Value, Nothing, dr("NUMERODOCREF"))
                    aEntidad.IDALMACEN = IIf(dr("IDALMACEN") Is DBNull.Value, Nothing, dr("IDALMACEN"))
                    aEntidad.ANIO = IIf(dr("ANIO") Is DBNull.Value, Nothing, dr("ANIO"))
                    aEntidad.IDMOVIMIENTO = IIf(dr("IDMOVIMIENTO") Is DBNull.Value, Nothing, dr("IDMOVIMIENTO"))
                    aEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                    aEntidad.FECHAMOVIMIENTO = IIf(dr("FECHAMOVIMIENTO") Is DBNull.Value, Nothing, dr("FECHAMOVIMIENTO"))
                    aEntidad.IDESTABLECIMIENTODESTINO = IIf(dr("IDESTABLECIMIENTODESTINO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTODESTINO"))
                    aEntidad.IDALMACENDESTINO = IIf(dr("IDALMACENDESTINO") Is DBNull.Value, Nothing, dr("IDALMACENDESTINO"))
                    aEntidad.IDUNIDADSOLICITA = IIf(dr("IDUNIDADSOLICITA") Is DBNull.Value, Nothing, dr("IDUNIDADSOLICITA"))
                    aEntidad.TOTALMOVIMIENTO = IIf(dr("TOTALMOVIMIENTO") Is DBNull.Value, Nothing, dr("TOTALMOVIMIENTO"))
                    aEntidad.IDEMPLEADOSOLICITA = IIf(dr("IDEMPLEADOSOLICITA") Is DBNull.Value, Nothing, dr("IDEMPLEADOSOLICITA"))
                    aEntidad.IDEMPLEADOAUTORIZA = IIf(dr("IDEMPLEADOAUTORIZA") Is DBNull.Value, Nothing, dr("IDEMPLEADOAUTORIZA"))
                    aEntidad.IDEMPLEADOALMACEN = IIf(dr("IDEMPLEADOALMACEN") Is DBNull.Value, Nothing, dr("IDEMPLEADOALMACEN"))
                    aEntidad.IDEMPLEADODESPACHA = IIf(dr("IDEMPLEADODESPACHA") Is DBNull.Value, Nothing, dr("IDEMPLEADODESPACHA"))
                    aEntidad.IDEMPLEADORECIBE = IIf(dr("IDEMPLEADORECIBE") Is DBNull.Value, Nothing, dr("IDEMPLEADORECIBE"))
                    aEntidad.IDEMPLEADOPREPARA = IIf(dr("IDEMPLEADOPREPARA") Is DBNull.Value, Nothing, dr("IDEMPLEADOPREPARA"))
                    aEntidad.IDEMPLEADOENVIADO = IIf(dr("IDEMPLEADOENVIADO") Is DBNull.Value, Nothing, dr("IDEMPLEADOENVIADO"))
                    aEntidad.CLASIFICACIONMOVIMIENTO = IIf(dr("CLASIFICACIONMOVIMIENTO") Is DBNull.Value, Nothing, dr("CLASIFICACIONMOVIMIENTO"))
                    aEntidad.SUBCLASIFICACIONMOVIMIENTO = IIf(dr("SUBCLASIFICACIONMOVIMIENTO") Is DBNull.Value, Nothing, dr("SUBCLASIFICACIONMOVIMIENTO"))
                    aEntidad.RESPONSABLEDISTRIBUCION = IIf(dr("RESPONSABLEDISTRIBUCION") Is DBNull.Value, Nothing, dr("RESPONSABLEDISTRIBUCION"))
                    aEntidad.MOTIVO = IIf(dr("MOTIVO") Is DBNull.Value, Nothing, dr("MOTIVO"))
                    aEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                    aEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                    aEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                    aEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                    aEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return 1

    End Function
    ''' <summary>
    ''' Información de los renglones recibidos que estan en estado de abiertos
    ''' </summary>
    ''' <param name="IDALMACEN">Identificacion del almacen</param>
    ''' <param name="IDDOCUMENTO">Identificación del documento</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Dataset</returns>

    Public Function RenglonesRecibosAbiertos(ByVal IDALMACEN As Integer, ByVal IDDOCUMENTO As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DM.NUMEROFACTURA NOFACTURA, DM.NOENVIO, DM.FECHAFACTURA FCHDOCUMENTO, DM.RENGLON, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') LOTE, ")
        strSQL.Append(" L.FECHAVENCIMIENTO FCHVENCIMIENTO, ")
        strSQL.Append(" IM.NUMEROINFORME NOINFCC, IM.FECHAELABORACIONINFORME,DM.CANTIDAD, U.UBICACION, IM.IDESTABLECIMIENTO IDESTCC, L.IDINFORMECONTROLCALIDAD IDINFCC,IM.IDTIPOINFORME IDTIPCC, CASE WHEN L.IDINFORMECONTROLCALIDAD IS NULL THEN '1' WHEN L.IDINFORMECONTROLCALIDAD IS NOT NULL THEN '0' END AS PROVIENE, DM.MONTO IMPORTE, DM.IDPRODUCTO, UM.IDUNIDADMEDIDA UM, ")
        strSQL.Append(" L.PRECIOLOTE PRECIO ")
        strSQL.Append(" FROM ")
        strSQL.Append(" SAB_ALM_DETALLEMOVIMIENTOS DM INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append(" ON DM.IDALMACEN = L.IDALMACEN AND ")
        strSQL.Append(" DM.IDLOTE = L.IDLOTE AND ")
        strSQL.Append(" DM.IDPRODUCTO = L.IDPRODUCTO ")
        strSQL.Append(" INNER JOIN SAB_ALM_MOVIMIENTOS M ON ")
        strSQL.Append(" M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO AND ")
        strSQL.Append(" M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION AND ")
        strSQL.Append(" M.IDMOVIMIENTO = DM.IDMOVIMIENTO ")
        strSQL.Append(" LEFT OUTER JOIN SAB_LAB_INFORMEMUESTRAS IM ON ")
        strSQL.Append(" IM.IDINFORME = L.IDINFORMECONTROLCALIDAD AND ")
        strSQL.Append(" IM.IDTIPOINFORME = 1 ")
        strSQL.Append(" INNER JOIN SAB_ALM_UBICACIONESPRODUCTOS U ON ")
        strSQL.Append(" U.IDALMACEN = DM.IDALMACEN AND ")
        strSQL.Append(" U.IDPRODUCTO = DM.IDPRODUCTO AND ")
        strSQL.Append(" U.IDLOTE = DM.IDLOTE ")
        strSQL.Append(" INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ON ")
        strSQL.Append(" UM.IDUNIDADMEDIDA = L.IDUNIDADMEDIDA ")
        strSQL.Append(" WHERE DM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append(" DM.IDTIPOTRANSACCION = 8 AND ")
        strSQL.Append(" DM.IDALMACEN = @IDALMACEN AND ")
        strSQL.Append(" M.IDDOCUMENTO = @IDDOCUMENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDDOCUMENTO", SqlDbType.Int)
        args(1).Value = IDDOCUMENTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene las fuentes de financiamientos de un movimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDTIPOTRANSACCION">Identificador del tipo de transacciones</param>
    ''' <param name="IDMOVIMIENTO">Identificacion del movimiento</param>
    ''' <returns>String</returns>

    Public Function ObtenerFuentesFinanciamientoMovimiento(ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOTRANSACCION As Integer, ByVal IDMOVIMIENTO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT distinct FF.NOMBRE ")
        strSQL.Append("FROM SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (L.IDALMACEN = DM.IDALMACEN ")
        strSQL.Append("AND L.IDLOTE = DM.IDLOTE) ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (DM.IDESTABLECIMIENTO = M.IDESTABLECIMIENTO ")
        strSQL.Append("AND DM.IDTIPOTRANSACCION = M.IDTIPOTRANSACCION ")
        strSQL.Append("AND DM.IDMOVIMIENTO = M.IDMOVIMIENTO) ")
        strSQL.Append("WHERE ")
        strSQL.Append("M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("ORDER BY FF.NOMBRE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.Int)
        args(2).Value = IDMOVIMIENTO

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim f As String = String.Empty

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    If f <> String.Empty Then f += ", "
                    f += dr.Item(0)
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return f

    End Function
    ''' <summary>
    ''' Ingresa el registro de despacho en las tablas de almacenes
    ''' </summary>
    ''' <param name="eM">Entidad con la informacion del movimiento</param>
    ''' <param name="eVS">Entidad con la informacion del vales de salida</param>
    ''' <returns>Valor entero con el resultado de la ejecución</returns>

    Public Function GuardarDespacho(ByVal eM As MOVIMIENTOS, ByVal eVS As VALESSALIDA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_ALM_MOVIMIENTOS ")
        strSQL.Append("SET ")
        strSQL.Append("FECHAMOVIMIENTO = @FECHAMOVIMIENTO, ")
        strSQL.Append("IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO, ")
        strSQL.Append("IDALMACENDESTINO = @IDALMACENDESTINO, ")
        strSQL.Append("ID_LUGAR_ENTREGA_HOSPITAL = @ID_LUGAR_ENTREGA_HOSPITAL, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("EMPLEADOALMACEN = @EMPLEADOALMACEN, ")
        strSQL.Append("EMPLEADOPREPARA = @EMPLEADOPREPARA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = 2")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND IDESTADO = 1 ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@FECHAMOVIMIENTO", SqlDbType.DateTime)
        args(0).Value = eM.FECHAMOVIMIENTO
        args(1) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.Int)
        args(1).Value = IIf(eM.IDESTABLECIMIENTODESTINO = Nothing, DBNull.Value, eM.IDESTABLECIMIENTODESTINO)
        args(2) = New SqlParameter("@IDALMACENDESTINO", SqlDbType.Int)
        args(2).Value = IIf(eM.IDALMACENDESTINO = Nothing, DBNull.Value, eM.IDALMACENDESTINO)
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = IIf(eM.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eM.AUUSUARIOMODIFICACION)
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = IIf(eM.AUFECHAMODIFICACION = Nothing, DBNull.Value, eM.AUFECHAMODIFICACION)
        args(5) = New SqlParameter("@EMPLEADOALMACEN", SqlDbType.VarChar)
        args(5).Value = IIf(eM.EMPLEADOALMACEN = Nothing, DBNull.Value, eM.EMPLEADOALMACEN)
        args(6) = New SqlParameter("@EMPLEADOPREPARA", SqlDbType.VarChar)
        args(6).Value = IIf(eM.EMPLEADOPREPARA = Nothing, DBNull.Value, eM.EMPLEADOPREPARA)
        args(7) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(7).Value = eM.IDESTABLECIMIENTO
        args(8) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(8).Value = eM.IDMOVIMIENTO
        args(9) = New SqlParameter("@ID_LUGAR_ENTREGA_HOSPITAL", SqlDbType.Int)
        args(9).Value = IIf(eM.ID_LUGAR_ENTREGA_HOSPITAL = Nothing, DBNull.Value, eM.ID_LUGAR_ENTREGA_HOSPITAL)

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("UPDATE SAB_ALM_VALESSALIDA ")
        strSQL1.Append("SET ")
        strSQL1.Append("TRANSPORTISTA = @TRANSPORTISTA, ")
        strSQL1.Append("MATRICULAVEHICULO = @MATRICULAVEHICULO, ")
        strSQL1.Append("PERSONARECIBE = @PERSONARECIBE, ")
        strSQL1.Append("IDTIPOIDENTIFICACION = @IDTIPOIDENTIFICACION, ")
        strSQL1.Append("NUMEROIDENTIFICACION = @NUMEROIDENTIFICACION, ")
        strSQL1.Append("OBSERVACION = @OBSERVACION, ")
        strSQL1.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL1.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL1.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSQL1.Append("INNER JOIN SAB_ALM_VALESSALIDA VS ")
        strSQL1.Append("ON VS.IDALMACEN = M.IDALMACEN ")
        strSQL1.Append("AND VS.ANIO = M.ANIO ")
        strSQL1.Append("AND VS.IDVALE = M.IDDOCUMENTO ")
        strSQL1.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL1.Append("AND M.IDTIPOTRANSACCION = 2 ")
        strSQL1.Append("AND M.IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args1(9) As SqlParameter
        args1(0) = New SqlParameter("@TRANSPORTISTA", SqlDbType.VarChar)
        args1(0).Value = IIf(eVS.TRANSPORTISTA = Nothing, DBNull.Value, eVS.TRANSPORTISTA)
        args1(1) = New SqlParameter("@MATRICULAVEHICULO", SqlDbType.VarChar)
        args1(1).Value = IIf(eVS.MATRICULAVEHICULO = Nothing, DBNull.Value, eVS.MATRICULAVEHICULO)
        args1(2) = New SqlParameter("@PERSONARECIBE", SqlDbType.VarChar)
        args1(2).Value = IIf(eVS.PERSONARECIBE = Nothing, DBNull.Value, eVS.PERSONARECIBE)
        args1(3) = New SqlParameter("@IDTIPOIDENTIFICACION", SqlDbType.SmallInt)
        args1(3).Value = IIf(eVS.IDTIPOIDENTIFICACION = Nothing, DBNull.Value, eVS.IDTIPOIDENTIFICACION)
        args1(4) = New SqlParameter("@NUMEROIDENTIFICACION", SqlDbType.VarChar)
        args1(4).Value = IIf(eVS.NUMEROIDENTIFICACION = Nothing, DBNull.Value, eVS.NUMEROIDENTIFICACION)
        args1(5) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args1(5).Value = IIf(eVS.OBSERVACION = Nothing, DBNull.Value, eVS.OBSERVACION)
        args1(6) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args1(6).Value = IIf(eVS.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eVS.AUUSUARIOMODIFICACION)
        args1(7) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args1(7).Value = IIf(eVS.AUFECHAMODIFICACION = Nothing, DBNull.Value, eVS.AUFECHAMODIFICACION)
        args1(8) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args1(8).Value = eM.IDESTABLECIMIENTO
        args1(9) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args1(9).Value = eM.IDMOVIMIENTO

        Dim resultado As Integer

        Using c As New SqlConnection(Me.cnnStr)

            c.Open()

            Dim t As SqlTransaction = c.BeginTransaction()

            Try

                SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args)

                SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args1)

                t.Commit()

                resultado = 1

            Catch ex As Exception
                t.Rollback()
                Throw ex
            Finally
                If c.State = ConnectionState.Open Then c.Close()
            End Try

        End Using

        Return resultado

    End Function

#End Region

End Class
