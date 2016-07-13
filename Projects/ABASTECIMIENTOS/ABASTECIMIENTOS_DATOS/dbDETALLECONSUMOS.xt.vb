Partial Public Class dbDETALLECONSUMOS

#Region " Metodos agregados "

    ''' <summary>
    ''' Devuelve el numero de productos en el detalle de consumo
    ''' </summary>
    ''' <param name="IDCONSUMO"></param> 'identificador de consumo
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' el numero entero de productos
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ContarProductos(ByVal IDCONSUMO As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM FROM SAB_EST_DETALLECONSUMOS ")
        strSQL.Append(" WHERE IDCONSUMO = @IDCONSUMO ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDCONSUMO", SqlDbType.VarChar)
        args(0).Value = IDCONSUMO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.VarChar)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args) = 0

        Return True
    End Function

    ''' <summary>
    ''' Elimina el detalle de un consumo
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLECONSUMOS
    ''' <returns>
    ''' devuelve uno si todo fue correcto
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' </list> 
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function EliminarDetalles(ByVal aEntidad As DETALLECONSUMOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_DETALLECONSUMOS ")
        strSQL.Append("WHERE IDCONSUMO = @IDCONSUMO ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDCONSUMO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' obtener la informacion de un producto del detalle filtrado por codigo
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDCONSUMO"></param> 'identificador del consumo
    ''' <param name="IDCODIGOPRODUCTO"></param> 'codigo de producto utilizado por MSPAS
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' </list> 
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetPorCodigo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64, ByVal IDCODIGOPRODUCTO As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT vv_CATALOGOPRODUCTOS.IDSUMINISTRO, vv_CATALOGOPRODUCTOS.CORRSUMINISTRO, vv_CATALOGOPRODUCTOS.DESCSUMINISTRO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.IDGRUPO, vv_CATALOGOPRODUCTOS.CORRGRUPO, vv_CATALOGOPRODUCTOS.DESCGRUPO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.IDSUBGRUPO, vv_CATALOGOPRODUCTOS.CORRSUBGRUPO, vv_CATALOGOPRODUCTOS.CORRPRODUCTO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.DESCSUBGRUPO, vv_CATALOGOPRODUCTOS.IDPRODUCTO, vv_CATALOGOPRODUCTOS.DESCLARGO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.NOMBRECORTO, vv_CATALOGOPRODUCTOS.IDNIVELUSO, vv_CATALOGOPRODUCTOS.DESCPRODUCTO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.PRECIOACTUAL, vv_CATALOGOPRODUCTOS.EXISTENCIAACTUAL, vv_CATALOGOPRODUCTOS.DESCRIPCION, ")
        strSQL.Append("SAB_EST_DETALLECONSUMOS.IDESTABLECIMIENTO, SAB_EST_DETALLECONSUMOS.IDCONSUMO, SAB_EST_DETALLECONSUMOS.IDDETALLE, ")
        strSQL.Append("SAB_EST_DETALLECONSUMOS.IDPRODUCTO AS Expr1 ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS INNER JOIN ")
        strSQL.Append("SAB_EST_DETALLECONSUMOS ON vv_CATALOGOPRODUCTOS.IDPRODUCTO = SAB_EST_DETALLECONSUMOS.IDPRODUCTO ")
        strSQL.Append(" WHERE SAB_EST_DETALLECONSUMOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND SAB_EST_DETALLECONSUMOS.IDCONSUMO = @IDCONSUMO ")
        strSQL.Append(" AND vv_CATALOGOPRODUCTOS.CORRPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(1).Value = IDCONSUMO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.VarChar)
        args(2).Value = IDCODIGOPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Validadr que existan productos asociados a un consumo
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLECONSUMOS    
    ''' <returns>
    ''' Verdadero si hay productos para el consumo
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarHayProductoAsociadoConsumo(ByVal aEntidad As DETALLECONSUMOS) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_EST_DETALLECONSUMOS ")
        strSQL.Append("WHERE IDCONSUMO = @IDCONSUMO ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDCONSUMO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Recupera la informacion de productos de un consumo
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDCONSUMO"></param> 'identificador de consumo
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetDetalleConsumo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_DETALLECONSUMOS.IDESTABLECIMIENTO, SAB_EST_DETALLECONSUMOS.IDCONSUMO, SAB_EST_DETALLECONSUMOS.IDPRODUCTO, SAB_EST_DETALLECONSUMOS.IDDETALLE, ")
        strSQL.Append("SAB_EST_DETALLECONSUMOS.IDUNIDADMEDIDA, SAB_EST_DETALLECONSUMOS.CANTIDADCONSUMIDA, SAB_EST_DETALLECONSUMOS.DEMANDAINSATISFECHA, ")
        strSQL.Append("SAB_EST_DETALLECONSUMOS.EXISTENCIAACTUAL, SAB_CAT_UNIDADMEDIDAS.DESCRIPCION AS UNIDAD, vv_CATALOGOPRODUCTOS.DESCLARGO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.CORRPRODUCTO ")
        strSQL.Append("FROM SAB_EST_DETALLECONSUMOS INNER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS ON SAB_EST_DETALLECONSUMOS.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS ON SAB_EST_DETALLECONSUMOS.IDPRODUCTO = vv_CATALOGOPRODUCTOS.IDPRODUCTO ")
        strSQL.Append("WHERE SAB_EST_DETALLECONSUMOS.IDCONSUMO = @IDCONSUMO ")
        strSQL.Append("AND SAB_EST_DETALLECONSUMOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(1).Value = IDCONSUMO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el reporte de Demanda Insatisfecha.
    ''' </summary>
    ''' <param name="FECHADESDE">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="FECHAHASTA">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDESTABLECIMIENTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDZONA">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDGRUPO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDPRODUCTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' 
    ''' <returns>Dataset con el listado de productos y cantidades de demanda insatisfecha</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' <item><description>SAB_EST_CONSUMOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function RptDemandaInsatisfecha(ByVal FECHADESDE As DateTime, ByVal FECHAHASTA As DateTime, ByVal IDESTABLECIMIENTO As Integer, ByVal IDZONA As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDSUBGRUPO As Integer, ByVal IDPRODUCTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append("        	E.IDZONA,Z.DESCRIPCION AS ZONA, ")
        strSQL.Append("        	DC.IDESTABLECIMIENTO, E.NOMBRE, ")
        strSQL.Append("        	CP.IDSUMINISTRO, CP.DESCSUMINISTRO, ")
        strSQL.Append("        	CP.IDGRUPO, CP.DESCGRUPO, ")
        strSQL.Append("        	CP.IDSUBGRUPO, CP.DESCSUBGRUPO, ")
        strSQL.Append("        	DC.IDPRODUCTO, CP.CORRPRODUCTO AS CODIGO, CP.DESCLARGO, ")
        strSQL.Append(" 	    CP.DESCRIPCION, ")
        strSQL.Append("        	SUM(DEMANDAINSATISFECHA) DEMANDAINSATISFECHA, ")
        strSQL.Append("        	MESCONSUMO, ")
        strSQL.Append("        	ANIOCONSUMO ")
        strSQL.Append("        	FROM SAB_EST_DETALLECONSUMOS DC ")
        strSQL.Append("        	INNER JOIN SAB_EST_CONSUMOS C ")
        strSQL.Append("        	ON dc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO ")
        strSQL.Append("        	AND dc.IDCONSUMO = c.IDCONSUMO ")
        strSQL.Append("        	INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("        	ON dc.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append("        	INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("        	ON dc.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" 	    INNER JOIN SAB_CAT_ESTABLECIMIENTOS  ES ")
        strSQL.Append(" 	    ON ES.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO ")
        strSQL.Append(" 	    INNER JOIN SAB_CAT_ZONAS Z ")
        strSQL.Append(" 	    ON Z.IDZONA = E.IDZONA ")
        strSQL.Append("WHERE ")
        strSQL.Append("((convert(datetime, convert(varchar, C.ANIOCONSUMO) + '/' + convert(varchar, C.MESCONSUMO) + '/1') between @FECHADESDE AND @FECHAHASTA) OR (@FECHADESDE is null AND @FECHAHASTA is null)) ")
        strSQL.Append("AND ")
        strSQL.Append("( ")
        strSQL.Append(" (DC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO OR @IDESTABLECIMIENTO = 0) ")
        strSQL.Append(" AND ")
        strSQL.Append(" ((E.IDZONA = @IDZONA ) OR @IDZONA = 0) ")
        strSQL.Append(") ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        strSQL.Append("AND (CP.IDSUBGRUPO = @IDSUBGRUPO OR @IDSUBGRUPO = 0) ")
        strSQL.Append("AND (DC.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) ")
        strSQL.Append("AND (c.IDESTADO = 2) ")
        strSQL.Append(" GROUP BY E.IDZONA, DC.IDESTABLECIMIENTO, CP.IDSUMINISTRO, CP.IDGRUPO, CP.IDSUBGRUPO, DC.IDPRODUCTO, DEMANDAINSATISFECHA, MESCONSUMO, ANIOCONSUMO, E.NOMBRE,CP.DESCSUMINISTRO, CP.DESCGRUPO,CP.DESCSUBGRUPO, CP.DESCLARGO, CP.DESCRIPCION, Z.DESCRIPCION, CP.CORRPRODUCTO ")
        strSQL.Append(" ORDER BY E.IDZONA, DC.IDESTABLECIMIENTO, CP.IDSUMINISTRO, CP.IDGRUPO, CP.IDSUBGRUPO, DC.IDPRODUCTO, convert(varchar,ANIOCONSUMO) + convert(varchar,MESCONSUMO) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        args(0).Value = FECHADESDE
        args(1) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(1).Value = FECHAHASTA
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO
        args(3) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(3).Value = IDZONA
        args(4) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(4).Value = IDSUMINISTRO
        args(5) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(5).Value = IDGRUPO
        args(6) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        args(6).Value = IDSUBGRUPO
        args(7) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(7).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el reporte de COnsumos.
    ''' </summary>
    ''' <param name="FECHADESDE">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="FECHAHASTA">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDESTABLECIMIENTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDZONA">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDGRUPO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDPRODUCTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' 
    ''' <returns>Dataset con el listado de productos y cantidades de consumos</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' <item><description>SAB_EST_CONSUMOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function RptConsumoInventario(ByVal FECHADESDE As DateTime, ByVal FECHAHASTA As DateTime, ByVal IDESTABLECIMIENTO As Integer, ByVal IDZONA As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDSUBGRUPO As Integer, ByVal IDPRODUCTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append("        	E.IDZONA,Z.DESCRIPCION AS ZONA, ")
        strSQL.Append("        	DC.IDESTABLECIMIENTO, E.NOMBRE, ")
        strSQL.Append("        	CP.IDSUMINISTRO, CP.DESCSUMINISTRO, ")
        strSQL.Append("        	CP.IDGRUPO, CP.DESCGRUPO, ")
        strSQL.Append("        	CP.IDSUBGRUPO, CP.DESCSUBGRUPO, ")
        strSQL.Append("        	DC.IDPRODUCTO, CP.CORRPRODUCTO AS CODIGO, CP.DESCLARGO, ")
        strSQL.Append(" 	    CP.DESCRIPCION, ")
        strSQL.Append("        	SUM(dc.CANTIDADCONSUMIDA) AS CONSUMO, ")
        strSQL.Append("        	MESCONSUMO, ")
        strSQL.Append("        	ANIOCONSUMO ")
        strSQL.Append("        	FROM SAB_EST_DETALLECONSUMOS DC ")
        strSQL.Append("        	INNER JOIN SAB_EST_CONSUMOS C ")
        strSQL.Append("        	ON dc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO ")
        strSQL.Append("        	AND dc.IDCONSUMO = c.IDCONSUMO ")
        strSQL.Append("        	INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("        	ON dc.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append("        	INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("        	ON dc.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" 	    INNER JOIN SAB_CAT_ESTABLECIMIENTOS  ES ")
        strSQL.Append(" 	    ON ES.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO ")
        strSQL.Append(" 	    INNER JOIN SAB_CAT_ZONAS Z ")
        strSQL.Append(" 	    ON Z.IDZONA = E.IDZONA ")
        strSQL.Append("WHERE ")
        strSQL.Append("((convert(datetime, convert(varchar, C.ANIOCONSUMO) + '/' + convert(varchar, C.MESCONSUMO) + '/1') between @FECHADESDE AND @FECHAHASTA) OR (@FECHADESDE is null AND @FECHAHASTA is null)) ")
        strSQL.Append("AND ")
        strSQL.Append("( ")
        strSQL.Append(" (DC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO OR @IDESTABLECIMIENTO = 0) ")
        strSQL.Append(" OR ")
        strSQL.Append(" ((E.IDZONA = @IDZONA ) OR @IDZONA = 0) ")
        strSQL.Append(") ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        strSQL.Append("AND CP.IDSUBGRUPO = @IDSUBGRUPO OR @IDSUBGRUPO = 0) ")
        strSQL.Append("AND (DC.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) ")
        strSQL.Append("AND (c.IDESTADO = 2) ")
        strSQL.Append(" GROUP BY E.IDZONA, DC.IDESTABLECIMIENTO, CP.IDSUMINISTRO, CP.IDGRUPO, CP.IDSUBGRUPO, DC.IDPRODUCTO, DEMANDAINSATISFECHA, MESCONSUMO, ANIOCONSUMO, E.NOMBRE,CP.DESCSUMINISTRO, CP.DESCGRUPO,CP.DESCSUBGRUPO, CP.DESCLARGO, CP.DESCRIPCION, Z.DESCRIPCION, CP.CORRPRODUCTO ")
        strSQL.Append(" ORDER BY E.IDZONA, DC.IDESTABLECIMIENTO, CP.IDSUMINISTRO, CP.IDGRUPO, CP.IDSUBGRUPO, DC.IDPRODUCTO, convert(varchar,ANIOCONSUMO) + convert(varchar,MESCONSUMO) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        args(0).Value = FECHADESDE
        args(1) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(1).Value = FECHAHASTA
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO
        args(3) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(3).Value = IDZONA
        args(4) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(4).Value = IDSUMINISTRO
        args(5) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(5).Value = IDGRUPO
        args(6) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        args(6).Value = IDSUBGRUPO
        args(7) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(7).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene las existencias totales de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <returns>Dataset con la existencia de un producto</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ExistenciasCriticos(ByVal IDPRODUCTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO CODIGOPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        'strSQL.Append("L.PRECIOLOTE PRECIOUNITARIO, ")
        strSQL.Append("SUM(L.CANTIDADDISPONIBLE) TOTALDISPONIBLE ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_RESPONSABLEDISTRIBUCION R ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON R.IDRESPONSABLEDISTRIBUCION = L.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS F ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = F.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append("ON L.IDALMACEN = AE.IDALMACEN ")
        strSQL.Append("WHERE ")
        strSQL.Append("(L.IDPRODUCTO = @IDPRODUCTO) ")
        strSQL.Append("group by L.IDPRODUCTO, CP.CORRPRODUCTO, CP.DESCLARGO,CP.DESCRIPCION,L.PRECIOLOTE ")

        Dim args(1) As SqlParameter
        'args(0) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        'args(0).Value = FECHADESDE
        'args(1) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        'args(1).Value = FECHAHASTA
        'args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        'args(2).Value = IDESTABLECIMIENTO
        'args(3) = New SqlParameter("@IDZONA", SqlDbType.Int)
        'args(3).Value = IDZONA
        'args(4) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        'args(4).Value = IDSUMINISTRO
        'args(5) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        'args(5).Value = IDGRUPO
        'args(6) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        'args(6).Value = IDSUBGRUPO
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene las compras en transito totales de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <returns>Dataset con compras en transito de un producto</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ComprasTransitoCriticos(ByVal IDPRODUCTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("SUM(AEC.CANTIDAD - AEC.CANTIDADENTREGADA) TRANSITO ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("ON (AEC.IDESTABLECIMIENTO = EC.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = EC.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = EC.IDCONTRATO ")
        strSQL.Append("AND AEC.RENGLON = EC.RENGLON ")
        strSQL.Append("AND AEC.IDDETALLE = EC.IDDETALLE) ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (EC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = C.IDCONTRATO ) ")
        strSQL.Append("INNER JOIN  SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON (C.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = PC.IDCONTRATO) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON CP.IDPRODUCTO = PC.IDPRODUCTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(PC.IDPRODUCTO = @IDPRODUCTO) ")
        strSQL.Append("AND PC.ESTAHABILITADO = 1 ")
        strSQL.Append("AND C.IDESTADOCONTRATO = 3 ")
        strSQL.Append("AND EC.ESTAHABILITADA = 1 ")
        strSQL.Append("GROUP BY PC.IDPRODUCTO ")

        Dim args(1) As SqlParameter
        'args(0) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        'args(0).Value = FECHADESDE
        'args(1) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        'args(1).Value = FECHAHASTA
        'args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        'args(2).Value = IDESTABLECIMIENTO
        'args(3) = New SqlParameter("@IDZONA", SqlDbType.Int)
        'args(3).Value = IDZONA
        'args(4) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        'args(4).Value = IDSUMINISTRO
        'args(5) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        'args(5).Value = IDGRUPO
        'args(6) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        'args(6).Value = IDSUBGRUPO
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el promedio de consumo mensual de un producto en base a un año.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <returns>Dataset con el promedio de consumo mensual</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    ''' <item><description>SAB_EST_CONSUMOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function PromedioConsumoMensualCriticos(ByVal IDPRODUCTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DC.IDPRODUCTO, ")
        strSQL.Append("sum(dc.CANTIDADCONSUMIDA)/12 AS PROMCONSUMO ")
        strSQL.Append("FROM SAB_EST_DETALLECONSUMOS DC ")
        strSQL.Append("INNER JOIN SAB_EST_CONSUMOS C ")
        strSQL.Append("ON (dc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO ")
        strSQL.Append("AND dc.IDCONSUMO = c.IDCONSUMO) ")
        strSQL.Append("WHERE ")
        strSQL.Append("(convert(datetime, convert(varchar, C.ANIOCONSUMO) + '/' + convert(varchar, C.MESCONSUMO) + '/1') ")
        strSQL.Append("between dateadd(year, -1, getdate()) AND getdate()) ")
        strSQL.Append("AND (dc.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) ")
        strSQL.Append("AND c.IDESTADO = 2 ")
        strSQL.Append("GROUP BY DC.IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene la cantidad proximo a vencer en un mes determinado de un producto
    ''' </summary>
    ''' <param name="IDPRODUCTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="FECHA">Especifica el campo a utilizar para filtrar la información</param>
    ''' <returns>Dataset con la cantidad proximo a vencer en un mes determinado de un producto</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ProximosAvencerCriticos(ByVal IDPRODUCTO As Integer, ByVal FECHA As Date) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("sum(L.CANTIDADDISPONIBLE) ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_RESPONSABLEDISTRIBUCION R ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON R.IDRESPONSABLEDISTRIBUCION = L.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("WHERE ")
        strSQL.Append("(L.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) AND ")
        strSQL.Append("( ")
        strSQL.Append("DATEPART(MONTH, L.FECHAVENCIMIENTO) = DATEPART(MONTH, @FECHA) ")
        strSQL.Append("AND ")
        strSQL.Append("DATEPART(YEAR, L.FECHAVENCIMIENTO) = DATEPART(YEAR, @FECHA) ")
        strSQL.Append(") ")
        strSQL.Append("group by L.IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(0).Value = FECHA
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
