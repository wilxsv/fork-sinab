Partial Public Class dbRECIBOSRECEPCION

#Region " Metodos Agregados "

    ''' <summary>
    ''' Devuelve una lista de todos los recibos de recepción y actas, de acuerdo al criterio de búsqueda seleccionada.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="FECHADESDE">Fecha de inicio del período.</param>
    ''' <param name="FECHAHASTA">Fecha de finalización del período.</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente del financiamiento.</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribución.</param>
    ''' <param name="IDESTADO">Identificador del estado del documento.</param>
    ''' <param name="NUMERORECIBO">Número de recibo de recepción.</param>
    ''' <param name="NUMEROACTA">Número de acta de recepción.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_ALM_RECIBOSRECEPCION</item>
    ''' <item>SAB_UACI_CONTRATOS</item>
    ''' <item>SAB_CAT_TIPODOCUMENTOCONTRATO</item>
    ''' <item>SAB_CAT_PROVEEDORES</item>
    ''' <item>SAB_ALM_MOVIMIENTOS</item>
    ''' <item>SAB_ALM_DETALLEMOVIMIENTOS</item>
    ''' <item>SAB_ALM_LOTES</item>
    ''' <item>SAB_CAT_FUENTEFINANCIAMIENTOS</item>
    ''' <item>SAB_CAT_RESPONSABLEDISTRIBUCION</item>
    ''' <item>SAB_CAT_ESTADOSMOVIMIENTOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaRecibosRecepcionActas(ByVal IDALMACEN As Integer, ByVal IDPROVEEDOR As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer, ByVal IDESTADO As Integer, ByVal NUMERORECIBO As Integer, ByVal NUMEROACTA As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("RR.IDALMACEN, ")
        strSQL.Append("RR.ANIO, ")
        strSQL.Append("RR.IDRECIBO, ")
        strSQL.Append("M.IDESTABLECIMIENTO IDESTABLECIMIENTOMOVIMIENTO, ")
        strSQL.Append("M.IDTIPOTRANSACCION, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("M.IDDOCUMENTO, ")
        strSQL.Append("RR.IDESTABLECIMIENTO, ")
        strSQL.Append("RR.IDPROVEEDOR, ")
        strSQL.Append("RR.IDCONTRATO, ")
        strSQL.Append("convert(varchar, RR.IDRECIBO) + '/' + convert(varchar, RR.ANIO) NUMERORECIBO, ")
        strSQL.Append("convert(varchar, RR.NUMEROACTA) + '/' + convert(varchar, RR.ANIO) NUMEROACTA, ")
        strSQL.Append("convert(varchar, M.FECHAMOVIMIENTO, 103) FECHAMOVIMIENTO, ")
        strSQL.Append("case M.IDTIPOTRANSACCION ")
        strSQL.Append("when 8 then TDC.DESCRIPCION + ' ' + C.NUMEROCONTRATO ")
        strSQL.Append("when 16 then isnull('Vale de salida ' + RR.NUMEROVALE, '') ")
        strSQL.Append("else '' ")
        strSQL.Append("end TIPONUMERODOCUMENTO, ")
        strSQL.Append("case M.IDTIPOTRANSACCION ")
        strSQL.Append("when 8 then P.NOMBRE ")
        strSQL.Append("when 16 then isnull(A1.NOMBRE, '') ")
        strSQL.Append("when 17 then isnull(E1.NOMBRE, '') ")
        strSQL.Append("else '' ")
        strSQL.Append("end PROVEEDOR, ")
        strSQL.Append("E.DESCRIPCION ESTADO ")
        strSQL.Append("FROM SAB_ALM_RECIBOSRECEPCION RR ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (RR.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND RR.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND RR.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO TDC ")
        strSQL.Append("ON C.IDTIPODOCUMENTO = TDC.IDTIPODOCUMENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON RR.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (RR.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND RR.ANIO = M.ANIO ")
        strSQL.Append("AND RR.IDRECIBO = M.IDDOCUMENTO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("LEFT OUTER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS E ")
        strSQL.Append("ON M.IDESTADO = E.IDESTADO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES A1 ")
        strSQL.Append("ON RR.IDALMACENVALE = A1.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E1 ")
        strSQL.Append("ON RR.IDESTABLECIMIENTODEVOLUCION = E1.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE RR.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND M.IDTIPOTRANSACCION in (8, 16, 17) ")
        strSQL.Append("AND (RR.IDPROVEEDOR = @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")
        strSQL.Append("AND ((M.FECHAMOVIMIENTO between @FECHADESDE AND @FECHAHASTA) OR (@FECHADESDE IS NULL OR @FECHAHASTA IS NULL)) ")
        strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        strSQL.Append("AND (M.IDESTADO = @IDESTADO OR @IDESTADO = 0) ")
        strSQL.Append("AND (RR.IDRECIBO = @NUMERORECIBO OR @NUMERORECIBO = 0) ")
        strSQL.Append("AND (RR.NUMEROACTA = @NUMEROACTA OR @NUMEROACTA = 0) ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("RR.IDALMACEN, ")
        strSQL.Append("RR.ANIO, ")
        strSQL.Append("RR.IDRECIBO, ")
        strSQL.Append("M.IDESTABLECIMIENTO, ")
        strSQL.Append("M.IDTIPOTRANSACCION, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("M.IDDOCUMENTO, ")
        strSQL.Append("RR.IDESTABLECIMIENTO, ")
        strSQL.Append("RR.IDPROVEEDOR, ")
        strSQL.Append("RR.IDCONTRATO, ")
        strSQL.Append("RR.NUMEROACTA, ")
        strSQL.Append("M.FECHAMOVIMIENTO, ")
        strSQL.Append("TDC.DESCRIPCION, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("RR.NUMEROVALE, ")
        strSQL.Append("P.NOMBRE, ")
        strSQL.Append("A1.NOMBRE, ")
        strSQL.Append("E1.NOMBRE, ")
        strSQL.Append("E.DESCRIPCION ")
        strSQL.Append("ORDER BY ")
        strSQL.Append("M.FECHAMOVIMIENTO, ")
        strSQL.Append("M.IDDOCUMENTO ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        args(2).Value = IIf(FECHADESDE = Nothing, DBNull.Value, FECHADESDE)
        args(3) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(3).Value = IIf(FECHAHASTA = Nothing, DBNull.Value, FECHAHASTA)
        args(4) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(4).Value = IDFUENTEFINANCIAMIENTO
        args(5) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(5).Value = IDRESPONSABLEDISTRIBUCION
        args(6) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(6).Value = IDESTADO
        args(7) = New SqlParameter("@NUMERORECIBO", SqlDbType.Int)
        args(7).Value = NUMERORECIBO
        args(8) = New SqlParameter("@NUMEROACTA", SqlDbType.Int)
        args(8).Value = NUMEROACTA
        args(9) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(9).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(10) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(10).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerRecepciones(ByVal IDALMACEN As Integer, ByVal IDTIPOTRANSACCION As Integer, ByVal IDESTADO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("RR.IDALMACEN, ")
        strSQL.Append("RR.ANIO, ")
        strSQL.Append("RR.IDRECIBO, ")
        strSQL.Append("M.IDESTABLECIMIENTO IDESTABLECIMIENTOMOVIMIENTO, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("M.IDDOCUMENTO, ")
        strSQL.Append("convert(varchar, RR.IDRECIBO) + '/' + convert(varchar, RR.ANIO) NUMERORECIBO, ")
        strSQL.Append("convert(varchar, RR.NUMEROACTA) + '/' + convert(varchar, RR.ANIO) NUMEROACTA, ")
        strSQL.Append("convert(varchar, M.FECHAMOVIMIENTO, 103) FECHAMOVIMIENTO, ")
        strSQL.Append("RR.IDESTABLECIMIENTO, ")
        strSQL.Append("RR.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        strSQL.Append("RR.IDCONTRATO, ")
        strSQL.Append("E.DESCRIPCION ESTADO ")
        strSQL.Append("FROM SAB_ALM_RECIBOSRECEPCION RR ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (RR.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND RR.ANIO = M.ANIO ")
        strSQL.Append("AND RR.IDRECIBO = M.IDDOCUMENTO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS E ")
        strSQL.Append("ON M.IDESTADO = E.IDESTADO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON RR.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE RR.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND (M.IDESTADO = @IDESTADO OR @IDESTADO = 0) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("RR.IDALMACEN, ")
        strSQL.Append("RR.ANIO, ")
        strSQL.Append("RR.IDRECIBO, ")
        strSQL.Append("M.IDESTABLECIMIENTO, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("M.IDDOCUMENTO, ")
        strSQL.Append("RR.IDRECIBO, ")
        strSQL.Append("RR.NUMEROACTA, ")
        strSQL.Append("RR.ANIO, ")
        strSQL.Append("M.FECHAMOVIMIENTO, ")
        strSQL.Append("RR.IDESTABLECIMIENTO, ")
        strSQL.Append("RR.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE, ")
        strSQL.Append("RR.IDCONTRATO, ")
        strSQL.Append("E.DESCRIPCION ")
        strSQL.Append("ORDER BY M.FECHAMOVIMIENTO, M.IDMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(2).Value = IDESTADO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerFuentesRecibosRecepcionActas(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDRECIBO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("CASE WHEN FF.IDGRUPO = 1 THEN 'GOES/' ELSE 'OTRAS FUENTES/' END + FF.NOMBRE FUENTEFINANCIAMIENTO ")
        strSQL.Append("FROM SAB_ALM_RECIBOSRECEPCION RR ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (RR.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND RR.ANIO = M.ANIO ")
        strSQL.Append("AND RR.IDRECIBO = M.IDDOCUMENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("WHERE RR.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND RR.ANIO = @ANIO ")
        strSQL.Append("AND RR.IDRECIBO = @IDRECIBO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION in (8, 16, 17) ")
        strSQL.Append("ORDER BY 1 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.Int)
        args(1).Value = ANIO
        args(2) = New SqlParameter("@IDRECIBO", SqlDbType.Int)
        args(2).Value = IDRECIBO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerResponsablesDistribucionRecibosRecepcionActas(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDRECIBO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION ")
        strSQL.Append("FROM SAB_ALM_RECIBOSRECEPCION RR ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (RR.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND RR.ANIO = M.ANIO ")
        strSQL.Append("AND RR.IDRECIBO = M.IDDOCUMENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("WHERE RR.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND RR.ANIO = @ANIO ")
        strSQL.Append("AND RR.IDRECIBO = @IDRECIBO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION in (8, 16, 17) ")
        strSQL.Append("ORDER BY 1 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.Int)
        args(1).Value = ANIO
        args(2) = New SqlParameter("@IDRECIBO", SqlDbType.Int)
        args(2).Value = IDRECIBO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ExisteRecibo(ByVal aEntidad As RECIBOSRECEPCION) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDRECIBO) ")
        strSQL.Append("FROM SAB_ALM_RECIBOSRECEPCION ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND ANIO = @ANIO ")
        strSQL.Append("AND IDRECIBO = @IDRECIBO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = aEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = aEntidad.ANIO
        args(2) = New SqlParameter("@IDRECIBO", SqlDbType.SmallInt)
        args(2).Value = aEntidad.IDRECIBO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function RecuperarDetalleRecepcion(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDRECIBO As Integer, ByVal IDTIPOTRANSACCION As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("row_number() over(ORDER BY DM.RENGLON, CP.CORRPRODUCTO, DM.IDDETALLEMOVIMIENTO) SECUENCIA, ")
        strSQL.Append("DM.RENGLON, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("L.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '') CODIGO, ")
        strSQL.Append("case when L.CODIGO is null then case when L.DETALLE is null then '(N/A)' else L.DETALLE end else L.CODIGO + isnull(L.DETALLE, '') end CODIGODETALLE, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("DM.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("DM.IDTIPODOCUMENTO, ")
        strSQL.Append("TDR.DESCRIPCION TIPODOCUMENTO, ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN DM.NUMEROFACTURA IS NOT NULL THEN DM.NUMEROFACTURA ")
        strSQL.Append("WHEN DM.NOENVIO IS NOT NULL THEN DM.NOENVIO ")
        strSQL.Append("END DOCUMENTO, ")
        strSQL.Append("DM.FECHAFACTURA FECHADOCUMENTO, ")
        strSQL.Append("L.FECHAVENCIMIENTO FECHAVTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("DM.CANTIDAD CANTIDAD, ")
        strSQL.Append("UP.IDUBICACION, ")
        strSQL.Append("UP.UBICACION, ")
        strSQL.Append("L.IDESTABLECIMIENTO IDESTABLECIMIENTOCC, ")
        strSQL.Append("L.IDINFORMECONTROLCALIDAD IDINFORMECC, ")
        strSQL.Append("L.NUMEROINFORMECONTROLCALIDAD NUMEROINFORMECC, ")
        strSQL.Append("L.FECHAINFORMECONTROLCALIDAD FECHAINFORMECC, ")
        strSQL.Append("DM.MONTO IMPORTE, ")
        strSQL.Append("DM.IDPRODUCTO, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("(DM.CANTIDAD * L.PRECIOLOTE) TOTAL, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRE RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("rr.admcontrato, ")

        strSQL.Append("M.IDESTADO ")
        strSQL.Append("FROM SAB_ALM_RECIBOSRECEPCION RR ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (RR.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND RR.ANIO = M.ANIO ")
        strSQL.Append("AND RR.IDRECIBO = M.IDDOCUMENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP ")
        strSQL.Append("ON (L.IDALMACEN = UP.IDALMACEN ")
        strSQL.Append("AND L.IDLOTE = UP.IDLOTE) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPODOCUMENTORECEPCION TDR ")
        strSQL.Append("ON DM.IDTIPODOCUMENTO = TDR.IDTIPODOCUMENTORECEPCION ")
        strSQL.Append("WHERE RR.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND RR.ANIO = @ANIO ")
        strSQL.Append("AND RR.IDRECIBO = @IDRECIBO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("ORDER BY DM.RENGLON, CP.CORRPRODUCTO, DM.IDDETALLEMOVIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = ANIO
        args(2) = New SqlParameter("@IDRECIBO", SqlDbType.SmallInt)
        args(2).Value = IDRECIBO
        args(3) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(3).Value = IDTIPOTRANSACCION

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerNumeroACTA(ByVal IDALMACEN As Int32, ByVal ANIO As Int16) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(NUMEROACTA),0) + 1 ")
        strSQL.Append("FROM SAB_ALM_RECIBOSRECEPCION ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND ANIO = @ANIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = ANIO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
