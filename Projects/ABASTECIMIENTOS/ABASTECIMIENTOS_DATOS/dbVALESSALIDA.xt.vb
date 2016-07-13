Partial Public Class dbVALESSALIDA

    ''' <summary>
    ''' Recupera el siguiente identificador del vale de salida.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén</param>
    ''' <returns>String con el identificador del vale de salida</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_VALESSALIDA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  15/01/2007    Creado
    ''' </history>
    Public Function RecuperarID(ByVal IDALMACEN As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(IDVALE),0) + 1 ")
        strSQL.Append("FROM SAB_ALM_VALESSALIDA ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve la informacion complementaria del vale de salida.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén al que pertenece el vale.</param>
    ''' <param name="IDVALE">Número del vale de salida.</param>
    ''' <param name="ANIO">Año en el que fue elaborado el vale de salida.</param>
    ''' <returns>Dataset con la información del vale de salida</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_VALESSALIDA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  06/02/2007    Creado
    ''' </history>
    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDVALE As Int32, ByVal ANIO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN AND IDVALE = @IDVALE AND ANIO = @ANIO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDVALE", SqlDbType.Int)
        args(1).Value = IDVALE
        args(2) = New SqlParameter("@ANIO", SqlDbType.Int)
        args(2).Value = ANIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve una lista con todos los vales de salida que cumplen con el criterio de búsqueda.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén.</param>
    ''' <param name="IDESTABLECIMIENTODESTINO">Identificador del establecimiento al que se despacharon los productos.</param>
    ''' <param name="FECHADESDE">Fecha de inicio del período.</param>
    ''' <param name="FECHAHASTA">Fecha de fin del período.</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento.</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribución.</param>
    ''' <param name="IDESTADO">Identificador del estado del vale.</param>
    ''' <param name="NUMEROVALE">Número del vale de salida.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_ALM_VALESSALIDA</item>
    ''' <item>SAB_ALM_MOVIMIENTOS</item>
    ''' <item>SAB_ALM_DETALLEMOVIMIENTOS</item>
    ''' <item>SAB_CAT_ESTABLECIMIENTOS</item>
    ''' <item>SAB_CAT_FUENTEFINANCIAMIENTOS</item>
    ''' <item>SAB_CAT_RESPONSABLEDISTRIBUCION</item>
    ''' <item>SAB_CAT_ESTADOSMOVIMIENTOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaValesSalida(ByVal IDALMACEN As Integer, ByVal IDESTABLECIMIENTODESTINO As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer, ByVal IDESTADO As Integer, ByVal NUMEROVALE As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("VS.IDALMACEN, ")
        strSQL.Append("VS.ANIO, ")
        strSQL.Append("VS.IDVALE, ")
        strSQL.Append("M.IDESTABLECIMIENTO IDESTABLECIMIENTOMOVIMIENTO, ")
        strSQL.Append("M.IDDOCUMENTO, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("convert(varchar, VS.IDVALE) + '/' + convert(varchar, VS.ANIO) NUMEROVALE, ")
        strSQL.Append("convert(varchar, M.FECHAMOVIMIENTO, 103) FECHAMOVIMIENTO, ")
        strSQL.Append("CASE WHEN E.NOMBRE IS NULL THEN LEH.NOMBRE_LUGAR_ENTREGA_HOSPITAL ELSE E.NOMBRE END ESTABLECIMIENTODESTINO, ")
        'strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        'strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("EM.DESCRIPCION ESTADO, ")
        strSQL.Append("count(DM.IDDETALLEMOVIMIENTO) RENGLONES, ")
        strSQL.Append("isnull(sum(DM.CANTIDAD * L.PRECIOLOTE), 0) TOTAL ")
        strSQL.Append("FROM SAB_ALM_VALESSALIDA VS ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (VS.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND VS.ANIO = M.ANIO ")
        strSQL.Append("AND VS.IDVALE = M.IDDOCUMENTO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("LEFT OUTER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_LOTES L ON (DM.IDALMACEN = L.IDALMACEN AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON M.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")

        strSQL.Append("LEFT OUTER JOIN SAB_CAT_LUGARES_ENTREGA_HOSPITALES LEH ")
        strSQL.Append("ON M.ID_LUGAR_ENTREGA_HOSPITAL = LEH.ID_LUGAR_ENTREGA_HOSPITAL ")
        strSQL.Append("AND M.IDALMACEN = LEH.IDALMACEN ")

        strSQL.Append("LEFT OUTER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS EM ")
        strSQL.Append("ON M.IDESTADO = EM.IDESTADO ")
        strSQL.Append("WHERE VS.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = 2 ")
        strSQL.Append("AND (M.IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO OR @IDESTABLECIMIENTODESTINO = 0) ")
        strSQL.Append("AND ((M.FECHAMOVIMIENTO between @FECHADESDE AND @FECHAHASTA) OR (@FECHADESDE IS NULL OR @FECHAHASTA IS NULL)) ")
        strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        strSQL.Append("AND (M.IDESTADO = @IDESTADO OR @IDESTADO = 0) ")
        strSQL.Append("AND (VS.IDVALE = @NUMEROVALE OR @NUMEROVALE = 0) ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("VS.IDALMACEN, ")
        strSQL.Append("VS.ANIO, ")
        strSQL.Append("VS.IDVALE, ")
        strSQL.Append("M.IDESTABLECIMIENTO, ")
        strSQL.Append("M.IDDOCUMENTO, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("M.FECHAMOVIMIENTO, ")
        strSQL.Append("E.NOMBRE, ")
        strSQL.Append("EM.DESCRIPCION, ")
        strSQL.Append("LEH.NOMBRE_LUGAR_ENTREGA_HOSPITAL ")
        strSQL.Append("ORDER BY ")
        strSQL.Append("M.FECHAMOVIMIENTO, ")
        strSQL.Append("M.IDDOCUMENTO ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTODESTINO
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
        args(7) = New SqlParameter("@NUMEROVALE", SqlDbType.Int)
        args(7).Value = NUMEROVALE
        args(8) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(8).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(9) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(9).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener las fuentes de financiamiento de un vale de salida
    ''' </summary>
    ''' <param name="IDALMACEN">Identificacion del almacen</param>
    ''' <param name="ANIO">Identificacion del año</param>
    ''' <param name="IDVALE">Identificacion del vale</param>
    ''' <returns>dataset</returns>

    Public Function ObtenerFuentesValesSalida(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDVALE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("GF.DESCRIPCION + '/' + FF.NOMBRE FUENTEFINANCIAMIENTO ")
        strSQL.Append("FROM SAB_ALM_VALESSALIDA VS ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (VS.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND VS.ANIO = M.ANIO ")
        strSQL.Append("AND VS.IDVALE = M.IDDOCUMENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_GRUPOSFUENTEFINANCIAMIENTO GF ")
        strSQL.Append("ON FF.IDGRUPO = GF.IDGRUPO ")
        strSQL.Append("WHERE VS.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND VS.ANIO = @ANIO ")
        strSQL.Append("AND VS.IDVALE = @IDVALE ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = 2 ")
        strSQL.Append("ORDER BY 1 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.Int)
        args(1).Value = ANIO
        args(2) = New SqlParameter("@IDVALE", SqlDbType.Int)
        args(2).Value = IDVALE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener los responsables de distribucion de un vale de salida
    ''' </summary>
    ''' <param name="IDALMACEN">Identificacion del almacen</param>
    ''' <param name="ANIO">Identificacion del año</param>
    ''' <param name="IDVALE">Identificacion del vale</param>
    ''' <returns>dataset</returns>

    Public Function ObtenerResponsablesDistribucionValesSalida(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDVALE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION ")
        strSQL.Append("FROM SAB_ALM_VALESSALIDA VS ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (VS.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND VS.ANIO = M.ANIO ")
        strSQL.Append("AND VS.IDVALE = M.IDDOCUMENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("WHERE VS.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND VS.ANIO = @ANIO ")
        strSQL.Append("AND VS.IDVALE = @IDVALE ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = 2 ")
        strSQL.Append("ORDER BY 1 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.Int)
        args(1).Value = ANIO
        args(2) = New SqlParameter("@IDVALE", SqlDbType.Int)
        args(2).Value = IDVALE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

End Class
