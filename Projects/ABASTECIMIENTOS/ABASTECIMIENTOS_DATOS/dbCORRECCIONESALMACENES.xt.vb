Partial Public Class dbCORRECCIONESALMACENES

#Region " Metodos Agregados "

    ''' <summary>
    ''' Devuelve los datos necesarios para el reporte de corrección de existencias.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén.</param>
    ''' <param name="ANIO">Año del movimiento.</param>
    ''' <param name="IDCORRECCION">Identificador del movimiento de corrección.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_ALM_CORRECCIONESALMACENES</item>
    ''' <item>SAB_ALM_MOVIMIENTOS</item>
    ''' <item>SAB_ALM_DETALLEMOVIMIENTOS</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_ALM_LOTES</item>
    ''' <item>SAB_CAT_FUENTEFINANCIAMIENTOS</item>
    ''' <item>SAB_CAT_RESPONSABLEDISTRIBUCION</item>
    ''' <item>SAB_CAT_ALMACENES</item>
    ''' <item>SAB_CAT_EMPLEADOSALMACEN</item>
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' <item>SAB_CAT_CARGOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]   Creado
    ''' </history>
    Public Function RptCorreccionesAlmacen(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDCORRECCION As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("convert(varchar, CA.IDCORRECCION) + '/' + convert(varchar, CA.ANIO) NUMEROMOVIMIENTO, ")
        strSQL.Append("convert(varchar, M.FECHAMOVIMIENTO, 103) FECHAMOVIMIENTO, ")
        strSQL.Append("CP.CORRPRODUCTO CODIGOPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO DESCRIPCION, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("isnull(L.CODIGO, '') LOTE, ")
        strSQL.Append("isnull(L.PRECIOLOTE, 0) PRECIO, ")
        strSQL.Append("convert(varchar, DATEPART(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, DATEPART(year, L.FECHAVENCIMIENTO)) FECHAVENCIMIENTO, ")
        strSQL.Append("DM.CANTIDADANTERIOR, ")
        strSQL.Append("(DM.CANTIDADANTERIOR + (TT.AFECTAINVENTARIO * DM.CANTIDAD)) CANTIDADDISPONIBLE, ")

        'se cambia para reporte de correccion de existencias 260809
        strSQL.Append("(TT.AFECTAINVENTARIO * DM.CANTIDAD) DIFERENCIA, ")
        strSQL.Append("M.IDTIPOTRANSACCION, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("CA.MOTIVO, ")
        strSQL.Append("isnull(CA.OBSERVACION, '') OBSERVACION, ")
        strSQL.Append("isnull(EM.NOMBRE + ' ' + EM.APELLIDO, '') EMPLEADOALMACEN, ")
        strSQL.Append("isnull(C.DESCRIPCION, '') CARGO ")
        strSQL.Append("FROM SAB_ALM_CORRECCIONESALMACENES CA ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (CA.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND CA.ANIO = M.ANIO ")
        strSQL.Append("AND CA.IDCORRECCION = M.IDDOCUMENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOTRANSACCIONES TT ")
        strSQL.Append("ON TT.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON CA.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_EMPLEADOSALMACEN EA ")
        strSQL.Append("ON (M.IDALMACEN = EA.IDALMACEN ")
        strSQL.Append("AND M.IDEMPLEADOALMACEN = EA.IDEMPLEADO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_EMPLEADOS EM ")
        strSQL.Append("ON (EA.IDEMPLEADO = EM.IDEMPLEADO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_CARGOS C ")
        strSQL.Append("ON (EM.IDCARGO = C.IDCARGO) ")
        strSQL.Append("WHERE CA.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND CA.ANIO = @ANIO ")
        strSQL.Append("AND CA.IDCORRECCION = @IDCORRECCION ")
        strSQL.Append("AND M.IDTIPOTRANSACCION IN (4, 5, 9, 10, 15) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = ANIO
        args(2) = New SqlParameter("@IDCORRECCION", SqlDbType.Int)
        args(2).Value = IDCORRECCION

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerListaCorreccionesAlmacen(ByVal IDALMACEN As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal NUMEROCORRECCION As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CA.IDALMACEN, ")
        strSQL.Append("CA.ANIO, ")
        strSQL.Append("CA.IDCORRECCION, ")
        strSQL.Append("M.IDESTABLECIMIENTO IDESTABLECIMIENTOMOVIMIENTO, ")
        strSQL.Append("M.IDDOCUMENTO, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("convert(varchar, CA.IDCORRECCION) + '/' + convert(varchar, CA.ANIO) NUMEROCORRECCION, ")
        strSQL.Append("convert(varchar, M.FECHAMOVIMIENTO, 103) FECHAMOVIMIENTO, ")
        strSQL.Append("EM.DESCRIPCION ESTADO ")
        strSQL.Append("FROM SAB_ALM_CORRECCIONESALMACENES CA ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (CA.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND CA.ANIO = M.ANIO ")
        strSQL.Append("AND CA.IDCORRECCION = M.IDDOCUMENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS EM ")
        strSQL.Append("ON M.IDESTADO = EM.IDESTADO ")
        strSQL.Append("WHERE CA.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND ((M.FECHAMOVIMIENTO between @FECHADESDE AND @FECHAHASTA) OR (@FECHADESDE IS NULL OR @FECHAHASTA IS NULL)) ")
        strSQL.Append("AND (CA.IDCORRECCION = @NUMEROCORRECCION OR @NUMEROCORRECCION = 0) ")
        strSQL.Append("AND M.IDTIPOTRANSACCION IN (4, 5, 9, 10, 15) ")
        strSQL.Append("AND M.IDESTADO=2 ")
        strSQL.Append("ORDER BY M.FECHAMOVIMIENTO, M.IDDOCUMENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        args(1).Value = IIf(FECHADESDE = Nothing, DBNull.Value, FECHADESDE)
        args(2) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(2).Value = IIf(FECHAHASTA = Nothing, DBNull.Value, FECHAHASTA)
        args(3) = New SqlParameter("@NUMEROCORRECCION", SqlDbType.Int)
        args(3).Value = NUMEROCORRECCION

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
