Partial Public Class dbINVENTARIO

#Region " Métodos agregados "

    Public Function ObtenerDataSetPorID2(ByVal IDALMACEN As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("I.*, ")
        strSQL.Append("S.DESCRIPCION SUMINISTRO ")
        strSQL.Append("FROM SAB_ALM_INVENTARIO I ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON I.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener existencia disponible de inventarios de almacen
    ''' </summary>
    ''' <param name="IDALMACEN"></param> identificador de almacen
    ''' <param name="IDSUMINISTRO"></param> identificador de suministro
    ''' <param name="FECHAEXISTENCIA"></param> fecha de existencia
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param> identificador de fuente de financiamiento
    ''' <param name="IDRESPONSABLEDIST"></param> identificdor de responsable de distribucion
    ''' <param name="VENCIDOS"></param> si aplica los vencidos
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEMOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerExistenciasDisponiblesInventarioAlmacen(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int32, ByVal FECHAEXISTENCIA As Date, Optional ByVal IDFUENTEFINANCIAMIENTO As Int32 = 0, Optional ByVal IDRESPONSABLEDIST As Int32 = 0, Optional ByVal VENCIDOS As Int32 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SUM(dm.CANTIDAD * tt.AFECTAINVENTARIO) AS total, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("l.IDUNIDADMEDIDA, l.PRECIOLOTE, l.FECHAVENCIMIENTO, ")
        strSQL.Append("l.IDLOTE, l.IDRESPONSABLEDISTRIBUCION, l.IDFUENTEFINANCIAMIENTO, cp.DESCLARGO, cp.IDSUMINISTRO, cp.DESCSUMINISTRO, ")
        strSQL.Append("l.IDALMACEN, l.IDPRODUCTO, l.ESTADISPONIBLE ")
        strSQL.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS AS dm INNER JOIN ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS m ON dm.IDESTABLECIMIENTO = m.IDESTABLECIMIENTO AND dm.IDTIPOTRANSACCION = m.IDTIPOTRANSACCION AND ")
        strSQL.Append("dm.IDMOVIMIENTO = m.IDMOVIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOTRANSACCIONES AS tt ON m.IDTIPOTRANSACCION = tt.IDTIPOTRANSACCION INNER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS l ON dm.IDALMACEN = l.IDALMACEN AND dm.IDLOTE = l.IDLOTE AND dm.IDPRODUCTO = l.IDPRODUCTO INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS cp ON l.IDPRODUCTO = cp.IDPRODUCTO ")
        strSQL.Append("WHERE l.ESTADISPONIBLE = 1 ")
        strSQL.Append("AND m.FECHAMOVIMIENTO <= @FECHAEXISTENCIA ")
        strSQL.Append("AND l.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND m.IDTIPOTRANSACCION <> 6 ")
        strSQL.Append("AND cp.IDSUMINISTRO = @IDSUMINISTRO ")

        If IDFUENTEFINANCIAMIENTO <> 0 Then strSQL.Append("AND l.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")
        If IDRESPONSABLEDIST <> 0 Then strSQL.Append("AND l.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDIST ")
        If VENCIDOS = 1 Then strSQL.Append("AND l.FECHAVENCIMIENTO <= @FECHAEXISTENCIA ")

        strSQL.Append("GROUP BY l.CODIGO, l.IDUNIDADMEDIDA, l.PRECIOLOTE, l.FECHAVENCIMIENTO, l.IDLOTE, l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, cp.DESCLARGO, cp.IDSUMINISTRO, cp.DESCSUMINISTRO, l.IDALMACEN, l.IDPRODUCTO, l.ESTADISPONIBLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@FECHAEXISTENCIA", SqlDbType.DateTime)
        args(2).Value = FECHAEXISTENCIA
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Value = IDFUENTEFINANCIAMIENTO
        args(4) = New SqlParameter("@IDRESPONSABLEDIST", SqlDbType.Int)
        args(4).Value = IDRESPONSABLEDIST

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Calcular la existencia no disponible en el almacen
    ''' </summary>
    ''' <param name="IDALMACEN"></param> identificador del almacen
    ''' <param name="IDSUMINISTRO"></param> identificador del suministro
    ''' <param name="FECHAEXISTENCIA"></param> fecha de existencia
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param> identificador de fuente de financiamiento
    ''' <param name="IDRESPONSABLEDIST"></param> identificador de responsable de distribucion
    ''' <param name="VENCIDOS"></param> aoplica vencidos
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEMOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerExistenciasNoDisponiblesInventarioAlmacen(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int32, ByVal FECHAEXISTENCIA As Date, Optional ByVal IDFUENTEFINANCIAMIENTO As Int32 = 0, Optional ByVal IDRESPONSABLEDIST As Int32 = 0, Optional ByVal VENCIDOS As Int32 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SUM(dm.CANTIDAD) AS total, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("l.IDUNIDADMEDIDA, l.PRECIOLOTE, l.FECHAVENCIMIENTO, l.IDLOTE, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, l.IDFUENTEFINANCIAMIENTO, cp.DESCLARGO, cp.IDSUMINISTRO, cp.DESCSUMINISTRO, l.IDALMACEN, l.IDPRODUCTO, l.ESTADISPONIBLE ")
        strSQL.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS AS dm INNER JOIN ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS m ON dm.IDESTABLECIMIENTO = m.IDESTABLECIMIENTO AND dm.IDTIPOTRANSACCION = m.IDTIPOTRANSACCION AND ")
        strSQL.Append("dm.IDMOVIMIENTO = m.IDMOVIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOTRANSACCIONES AS tt ON m.IDTIPOTRANSACCION = tt.IDTIPOTRANSACCION INNER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS l ON dm.IDALMACEN = l.IDALMACEN AND dm.IDLOTE = l.IDLOTE AND dm.IDPRODUCTO = l.IDPRODUCTO INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS cp ON l.IDPRODUCTO = cp.IDPRODUCTO ")
        strSQL.Append("WHERE l.ESTADISPONIBLE = 1 ")
        strSQL.Append("AND m.FECHAMOVIMIENTO <= @FECHAEXISTENCIA ")
        strSQL.Append("AND l.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND tt.AFECTAINVENTARIO = 0 ")
        strSQL.Append("AND m.IDTIPOTRANSACCION = 6 ")
        strSQL.Append("AND cp.IDSUMINISTRO = @IDSUMINISTRO ")

        If IDFUENTEFINANCIAMIENTO <> 0 Then strSQL.Append("AND l.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")
        If IDRESPONSABLEDIST <> 0 Then strSQL.Append("AND l.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDIST ")
        If VENCIDOS = 1 Then strSQL.Append("AND l.FECHAVENCIMIENTO <= @FECHAEXISTENCIA ")

        strSQL.Append("GROUP BY l.CODIGO, l.IDUNIDADMEDIDA, l.PRECIOLOTE, l.FECHAVENCIMIENTO, l.IDLOTE, l.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("l.IDFUENTEFINANCIAMIENTO, cp.DESCLARGO, cp.IDSUMINISTRO, cp.DESCSUMINISTRO, l.IDALMACEN, l.IDPRODUCTO, l.ESTADISPONIBLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@FECHAEXISTENCIA", SqlDbType.DateTime)
        args(2).Value = FECHAEXISTENCIA
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Value = IDFUENTEFINANCIAMIENTO
        args(4) = New SqlParameter("@IDRESPONSABLEDIST", SqlDbType.Int)
        args(4).Value = IDRESPONSABLEDIST

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Dataset con la informacion para generar reporte gerenciales
    ''' </summary>
    ''' <param name="IDZONA"></param> idenficador de zona o region
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador de pro
    ''' <param name="FECHAREFERENCIA"></param> fecha de referencia
    ''' <param name="OPERADOR"></param> operador de comparación
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ZONAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ReportesGerencialesEstablecimiento(Optional ByVal IDZONA As Int32 = 0, Optional ByVal IDESTABLECIMIENTO As Int32 = 0, Optional ByVal IDPRODUCTO As Int32 = 0, Optional ByVal FECHAREFERENCIA As Date = Nothing, Optional ByVal OPERADOR As String = "") As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_ALM_LOTES.IDPRODUCTO, vv_CATALOGOPRODUCTOS.DESCLARGO, vv_CATALOGOPRODUCTOS.CORRPRODUCTO, SAB_ALM_LOTES.IDLOTE, ")
        strSQL.Append("SAB_ALM_LOTES.CODIGO AS LOTE, SAB_ALM_LOTES.IDUNIDADMEDIDA, vv_CATALOGOPRODUCTOS.DESCRIPCION AS UNIDADMEDIDA, ")
        strSQL.Append("SAB_ALM_LOTES.PRECIOLOTE, SAB_ALM_LOTES.FECHAVENCIMIENTO, SAB_ALM_LOTES.CANTIDADDISPONIBLE, ")
        strSQL.Append("SAB_ALM_LOTES.CANTIDADNODISPONIBLE, SAB_ALM_LOTES.CANTIDADVENCIDA, SAB_ALM_LOTES.CANTIDADRESERVADA, ")
        strSQL.Append("SAB_ALM_LOTES.CANTIDADTEMPORAL, SAB_CAT_ALMACENESESTABLECIMIENTOS.IDALMACEN, ")
        strSQL.Append("SAB_CAT_ALMACENESESTABLECIMIENTOS.IDESTABLECIMIENTO, SAB_CAT_ESTABLECIMIENTOS.CODIGOESTABLECIMIENTO, ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS.IDZONA, ")
        strSQL.Append("SAB_ALM_LOTES.CANTIDADDISPONIBLE + SAB_ALM_LOTES.CANTIDADNODISPONIBLE + SAB_ALM_LOTES.CANTIDADVENCIDA AS EXISTENCIA, ")
        strSQL.Append("SAB_CAT_ZONAS.DESCRIPCION AS ZONA, SAB_CAT_ESTABLECIMIENTOS.NOMBRE AS ESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_CAT_ALMACENESESTABLECIMIENTOS INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS ON ")
        strSQL.Append("SAB_CAT_ALMACENESESTABLECIMIENTOS.IDESTABLECIMIENTO = SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_ALM_LOTES INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS ON SAB_ALM_LOTES.IDPRODUCTO = vv_CATALOGOPRODUCTOS.IDPRODUCTO ON ")
        strSQL.Append("SAB_CAT_ALMACENESESTABLECIMIENTOS.IDALMACEN = SAB_ALM_LOTES.IDALMACEN INNER JOIN ")
        strSQL.Append("SAB_CAT_ZONAS ON SAB_CAT_ESTABLECIMIENTOS.IDZONA = SAB_CAT_ZONAS.IDZONA ")
        strSQL.Append("WHERE SAB_CAT_ESTABLECIMIENTOS.IDTIPOESTABLECIMIENTO > 0 ") 'Hospital (3)

        If IDZONA <> 0 Then strSQL.Append("AND SAB_CAT_ESTABLECIMIENTOS.IDZONA = @IDZONA ")
        If IDESTABLECIMIENTO <> 0 Then strSQL.Append("AND SAB_CAT_ALMACENESESTABLECIMIENTOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        If IDPRODUCTO <> 0 Then strSQL.Append("AND SAB_ALM_LOTES.IDPRODUCTO = @IDPRODUCTO ")

        If OPERADOR <> "" And FECHAREFERENCIA <> Nothing Then
            strSQL.Append("AND SAB_ALM_LOTES.FECHAVENCIMIENTO OPER @FECHAREFERENCIA ")
            strSQL.Replace("OPER", OPERADOR)
        End If

        strSQL.Append("OR SAB_CAT_ESTABLECIMIENTOS.IDTIPOESTABLECIMIENTO = 2 ") 'sibasi o region (2)
        If IDZONA <> 0 Then strSQL.Append("AND SAB_CAT_ESTABLECIMIENTOS.IDZONA = @IDZONA ")
        If IDESTABLECIMIENTO <> 0 Then strSQL.Append("AND SAB_CAT_ALMACENESESTABLECIMIENTOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        If IDPRODUCTO <> 0 Then strSQL.Append("AND SAB_ALM_LOTES.IDPRODUCTO = @IDPRODUCTO ")

        If OPERADOR <> "" And FECHAREFERENCIA <> Nothing Then
            strSQL.Append("AND SAB_ALM_LOTES.FECHAVENCIMIENTO OPER @FECHAREFERENCIA ")
            strSQL.Replace("OPER", OPERADOR)
        End If

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@OPERADOR", SqlDbType.VarChar)
        args(1).Value = OPERADOR
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO
        args(3) = New SqlParameter("@FECHAREFERENCIA", SqlDbType.DateTime)
        args(3).Value = IIf(FECHAREFERENCIA = Nothing, DBNull.Value, FECHAREFERENCIA)
        args(4) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(4).Value = IDZONA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Dataset para reporte gerencial de establecimiento de inventario 
    ''' </summary>
    ''' <param name="IDZONA"></param> identificador de zona
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPRODUCTO"></param> identificdor de producto
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ZONAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function RptGerencialesEstablecimientoInventario(Optional ByVal IDZONA As Int32 = 0, Optional ByVal IDESTABLECIMIENTO As Int32 = 0, Optional ByVal IDPRODUCTO As Int32 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT l.IDPRODUCTO, vvc.DESCLARGO, vvc.CORRPRODUCTO, l.IDUNIDADMEDIDA, vvc.DESCRIPCION AS UNIDADMEDIDA, SUM(l.CANTIDADDISPONIBLE) ")
        strSQL.Append("AS DISPONIBLE, SUM(l.CANTIDADNODISPONIBLE) AS NODISPONIBLE, SUM(l.CANTIDADVENCIDA) AS VENCIDA, SUM(l.CANTIDADRESERVADA) ")
        strSQL.Append("AS RESERVADA, SUM(l.CANTIDADTEMPORAL) AS TEMPORAL, ae.IDESTABLECIMIENTO, e.CODIGOESTABLECIMIENTO, e.IDZONA, ")
        strSQL.Append("SUM(l.CANTIDADDISPONIBLE + l.CANTIDADNODISPONIBLE + l.CANTIDADVENCIDA) AS EXISTENCIA, z.DESCRIPCION AS ZONA, e.NOMBRE AS ESTABLECIMIENTO, e.IDTIPOESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_CAT_ALMACENESESTABLECIMIENTOS AS ae INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS AS e ON ae.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS l INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS vvc ON l.IDPRODUCTO = vvc.IDPRODUCTO ON ae.IDALMACEN = l.IDALMACEN INNER JOIN ")
        strSQL.Append("SAB_CAT_ZONAS AS z ON e.IDZONA = z.IDZONA ")
        strSQL.Append("GROUP BY l.IDPRODUCTO, vvc.DESCLARGO, vvc.CORRPRODUCTO, l.IDUNIDADMEDIDA, vvc.DESCRIPCION, ae.IDESTABLECIMIENTO, ")
        strSQL.Append("e.CODIGOESTABLECIMIENTO, e.IDZONA, z.DESCRIPCION, e.NOMBRE, e.IDTIPOESTABLECIMIENTO ")
        strSQL.Append("HAVING e.IDTIPOESTABLECIMIENTO > 0 ") 'Hospital (3)

        If IDZONA <> 0 Then strSQL.Append("AND e.IDZONA = @IDZONA ")
        If IDESTABLECIMIENTO <> 0 Then strSQL.Append("AND ae.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        If IDPRODUCTO <> 0 Then strSQL.Append("AND l.IDPRODUCTO = @IDPRODUCTO ")

        strSQL.Append("OR e.IDTIPOESTABLECIMIENTO = 2 ") 'sibasi o region (2)
        If IDZONA <> 0 Then strSQL.Append("AND e.IDZONA = @IDZONA ")
        If IDESTABLECIMIENTO <> 0 Then strSQL.Append("AND ae.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        If IDPRODUCTO <> 0 Then strSQL.Append("AND l.IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(2).Value = IDZONA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Dataset con la informacion de productos sin movimiento de salida
    ''' </summary>
    ''' <param name="IDZONA"></param> identificdaor de zona
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador de producto
    ''' <param name="FECHAREFERENCIA"></param> fecha de referencia
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ZONAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DatasetProductosSinmovimientoSalida(Optional ByVal IDZONA As Int32 = 0, Optional ByVal IDESTABLECIMIENTO As Int32 = 0, Optional ByVal IDPRODUCTO As Int32 = 0, Optional ByVal FECHAREFERENCIA As Date = Nothing) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT MAX(am.FECHAMOVIMIENTO) AS FECHASALIDA, dm.MONTO, tt.AFECTAINVENTARIO, dm.IDLOTE, e.CODIGOESTABLECIMIENTO, ")
        strSQL.Append("e.NOMBRE AS ESTABLECIMIENTO, e.IDZONA, e.IDTIPOESTABLECIMIENTO, dm.IDPRODUCTO, vvc.DESCLARGO, vvc.CORRPRODUCTO, ")
        strSQL.Append("vvc.DESCRIPCION AS UNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') LOTE, ")
        strSQL.Append("l.FECHAVENCIMIENTO, SUM(dm.CANTIDAD) AS CANTIDADTOTAL, z.DESCRIPCION AS ZONA ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS AS am INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOTRANSACCIONES AS tt ON am.IDTIPOTRANSACCION = tt.IDTIPOTRANSACCION INNER JOIN ")
        strSQL.Append("SAB_ALM_DETALLEMOVIMIENTOS AS dm ON am.IDESTABLECIMIENTO = dm.IDESTABLECIMIENTO AND ")
        strSQL.Append("am.IDTIPOTRANSACCION = dm.IDTIPOTRANSACCION AND am.IDMOVIMIENTO = dm.IDMOVIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS AS e ON am.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS vvc ON dm.IDPRODUCTO = vvc.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS l ON dm.IDLOTE = l.IDLOTE INNER JOIN ")
        strSQL.Append("SAB_CAT_ZONAS AS z ON e.IDZONA = z.IDZONA ")
        strSQL.Append("WHERE e.IDTIPOESTABLECIMIENTO > 0 ") 'Hospital (3)
        If IDPRODUCTO <> 0 Then strSQL.Append("AND dm.IDPRODUCTO = @IDPRODUCTO ")
        If IDESTABLECIMIENTO <> 0 Then strSQL.Append("AND am.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        If IDZONA <> 0 Then strSQL.Append("AND e.IDZONA = @IDZONA ")

        strSQL.Append("OR e.IDTIPOESTABLECIMIENTO = 2 ") 'sibasi o region (2)
        If IDPRODUCTO <> 0 Then strSQL.Append("AND dm.IDPRODUCTO = @IDPRODUCTO ")
        If IDESTABLECIMIENTO <> 0 Then strSQL.Append("AND am.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        If IDZONA <> 0 Then strSQL.Append("AND e.IDZONA = @IDZONA ")

        strSQL.Append("GROUP BY dm.MONTO, tt.AFECTAINVENTARIO, dm.IDLOTE, e.CODIGOESTABLECIMIENTO, e.IDZONA, e.NOMBRE, e.IDTIPOESTABLECIMIENTO, ")
        strSQL.Append("dm.IDPRODUCTO, vvc.DESCLARGO, vvc.CORRPRODUCTO, vvc.DESCRIPCION, l.CODIGO, l.FECHAVENCIMIENTO, z.DESCRIPCION ")
        strSQL.Append("HAVING tt.AFECTAINVENTARIO = '-1' ") 'MOVIMIENTO DE SALIDA INVENTARIO
        If FECHAREFERENCIA <> Nothing Then strSQL.Append("AND MAX(am.FECHAMOVIMIENTO) < @FECHAREFERENCIA ")
        strSQL.Append("ORDER BY FECHASALIDA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(2).Value = IDZONA
        args(3) = New SqlParameter("@FECHAREFERENCIA", SqlDbType.DateTime)
        args(3).Value = IIf(FECHAREFERENCIA = Nothing, DBNull.Value, FECHAREFERENCIA)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Dataset para generar reporte de entrada de productos sin movimientos de salida
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificdor de establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador de producto
    ''' <param name="IDLOTE"></param> identificador de lote
    ''' <param name="FECHAREFERENCIA"></param> fecha de referencia
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DatasetFechaEntradaProductosSinmovimientoSalida(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal IDLOTE As Int32, ByVal FECHAREFERENCIA As Date) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT MAX(am.FECHAMOVIMIENTO) AS FECHAENTRADA, dm.IDPRODUCTO, dm.MONTO, tt.AFECTAINVENTARIO, dm.IDLOTE ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS AS am INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOTRANSACCIONES AS tt ON am.IDTIPOTRANSACCION = tt.IDTIPOTRANSACCION INNER JOIN ")
        strSQL.Append("SAB_ALM_DETALLEMOVIMIENTOS AS dm ON am.IDESTABLECIMIENTO = dm.IDESTABLECIMIENTO AND ")
        strSQL.Append("am.IDTIPOTRANSACCION = dm.IDTIPOTRANSACCION And am.IDMOVIMIENTO = dm.IDMOVIMIENTO ")
        strSQL.Append("WHERE dm.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND am.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND dm.IDLOTE = @IDLOTE ")
        strSQL.Append("GROUP BY dm.IDPRODUCTO, dm.MONTO, tt.AFECTAINVENTARIO, dm.IDLOTE ")
        strSQL.Append("HAVING MAX(am.FECHAMOVIMIENTO) < @FECHAREFERENCIA ")
        strSQL.Append("AND tt.AFECTAINVENTARIO = '1' ") 'MOVIMIENTO DE ENTRADA A INVENTARIO

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDLOTE", SqlDbType.Int)
        args(2).Value = IDLOTE
        args(3) = New SqlParameter("@FECHAREFERENCIA", SqlDbType.DateTime)
        args(3).Value = IIf(FECHAREFERENCIA = Nothing, DBNull.Value, FECHAREFERENCIA)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Dataset para reporte gerencial de establecimiento de compra en transito
    ''' </summary>
    ''' <param name="IDZONA"></param> identificdor de zona
    ''' <param name="IDESTABLECIMIENTO"></param> identificdor de establecimiento
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <param name="IDPRODUCTO"></param> identificdor del producto
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ZONAS</description></item>
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function RptGerencialesEstablecimientoComprasTransito(Optional ByVal IDZONA As Int32 = 0, Optional ByVal IDESTABLECIMIENTO As Int32 = 0, Optional ByVal IDPROVEEDOR As Int32 = 0, Optional ByVal IDPRODUCTO As Int32 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT pc.IDESTABLECIMIENTO, pc.IDPROVEEDOR, pc.IDCONTRATO, pc.RENGLON, pc.CANTIDAD, pc.PRECIOUNITARIO, pc.ESTAHABILITADO, ")
        strSQL.Append("e.CODIGOESTABLECIMIENTO, e.NOMBRE AS ESTABLECIMIENTO, z.IDZONA, z.DESCRIPCION AS ZONA, ec.ESTAHABILITADA, SUM(aec.CANTIDAD) ")
        strSQL.Append("AS CANTIDADALMACEN, SUM(aec.CANTIDADENTREGADA) AS ENTREGADAALMACEN, SUM(aec.CANTIDAD - aec.CANTIDADENTREGADA) AS TRANSITO, ")
        strSQL.Append("vvc.CORRPRODUCTO, vvc.DESCLARGO, p.NOMBRE AS PROVEEDOR, e.IDTIPOESTABLECIMIENTO, pc.IDPRODUCTO, p.CODIGOPROVEEDOR, vvc.DESCRIPCION AS UNIDADMEDIDA ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO AS pc INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS AS e ON pc.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_ZONAS AS z ON e.IDZONA = z.IDZONA INNER JOIN ")
        strSQL.Append("SAB_UACI_ENTREGACONTRATO AS ec ON pc.IDESTABLECIMIENTO = ec.IDESTABLECIMIENTO AND pc.IDPROVEEDOR = ec.IDPROVEEDOR AND ")
        strSQL.Append("pc.IDCONTRATO = ec.IDCONTRATO AND pc.RENGLON = ec.RENGLON INNER JOIN ")
        strSQL.Append("SAB_UACI_ALMACENESENTREGACONTRATOS AS aec ON ec.IDESTABLECIMIENTO = aec.IDESTABLECIMIENTO AND ")
        strSQL.Append("ec.IDPROVEEDOR = aec.IDPROVEEDOR AND ec.IDCONTRATO = aec.IDCONTRATO AND ec.RENGLON = aec.RENGLON AND ")
        strSQL.Append("ec.IDDETALLE = aec.IDDETALLE INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS vvc ON pc.IDPRODUCTO = vvc.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES AS p ON pc.IDPROVEEDOR = p.IDPROVEEDOR ")
        strSQL.Append("WHERE e.IDTIPOESTABLECIMIENTO > 0 ") 'Hospital (3)
        strSQL.Append("AND ec.ESTAHABILITADA = 1 ") 'La entrega debe estar habilitada
        strSQL.Append("AND pc.ESTAHABILITADO = 1 ") 'el proveedor debe estar habilitado en el renglon

        If IDESTABLECIMIENTO <> 0 Then strSQL.Append("AND pc.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        If IDPROVEEDOR <> 0 Then strSQL.Append("AND pc.IDPROVEEDOR = @IDPROVEEDOR ")
        If IDZONA <> 0 Then strSQL.Append("AND z.IDZONA = @IDZONA ")
        If IDPRODUCTO <> 0 Then strSQL.Append("AND pc.IDPRODUCTO = @IDPRODUCTO ")

        strSQL.Append("OR e.IDTIPOESTABLECIMIENTO = 3 ") 'sibasi o region (2)
        strSQL.Append("AND ec.ESTAHABILITADA = 1 ") 'La entrega debe estar habilitada
        strSQL.Append("AND pc.ESTAHABILITADO = 1 ") 'el proveedor debe estar habilitado en el renglon
        If IDESTABLECIMIENTO <> 0 Then strSQL.Append("AND pc.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        If IDPROVEEDOR <> 0 Then strSQL.Append("AND pc.IDPROVEEDOR = @IDPROVEEDOR ")
        If IDZONA <> 0 Then strSQL.Append("AND z.IDZONA = @IDZONA ")
        If IDPRODUCTO <> 0 Then strSQL.Append("AND pc.IDPRODUCTO = @IDPRODUCTO ")

        strSQL.Append("GROUP BY pc.IDESTABLECIMIENTO, pc.IDPROVEEDOR, pc.IDCONTRATO, pc.RENGLON, pc.CANTIDAD, pc.PRECIOUNITARIO, pc.ESTAHABILITADO, ")
        strSQL.Append("e.CODIGOESTABLECIMIENTO, e.NOMBRE, z.IDZONA, z.DESCRIPCION, ec.ESTAHABILITADA, vvc.CORRPRODUCTO, vvc.DESCLARGO, p.NOMBRE, ")
        strSQL.Append("e.IDTIPOESTABLECIMIENTO, pc.IDPRODUCTO, p.CODIGOPROVEEDOR, vvc.DESCRIPCION ")
        strSQL.Append("HAVING SUM(aec.CANTIDAD - aec.CANTIDADENTREGADA) > 0 ") 'compras en transito mayores de 0

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(2).Value = IDZONA
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(3).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Dataset para reporte de inventario fisico
    ''' </summary>
    ''' <param name="IDALMACEN"></param> identificador de almacen
    ''' <param name="IDINVENTARIO"></param> identificdor de inventario
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEINVENTARIO</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_ALM_INVENTARIO</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDsReporteInventarioFisico(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DI.IDDETALLE, ")
        strSQL.Append("DI.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("CP.CANTIDADDECIMAL, ")
        strSQL.Append("DI.PRECIO, ")
        strSQL.Append("DI.CANTIDADDISPONIBLESISTEMA, ")
        strSQL.Append("DI.CANTIDADDISPONIBLECAPTURA, ")
        strSQL.Append("(L.PRECIOLOTE * DI.CANTIDADDISPONIBLECAPTURA) TOTALDISPONIBLECAPTURA, ")
        strSQL.Append("DI.CANTIDADDISPONIBLEDIFERENCIA, ")
        strSQL.Append("DI.CANTIDADNODISPONIBLESISTEMA, ")
        strSQL.Append("DI.CANTIDADNODISPONIBLECAPTURA, ")
        strSQL.Append("(L.PRECIOLOTE * DI.CANTIDADNODISPONIBLECAPTURA) TOTALNODISPONIBLECAPTURA, ")
        strSQL.Append("DI.CANTIDADNODISPONIBLEDIFERENCIA, ")
        strSQL.Append("DI.CANTIDADVENCIDASISTEMA, ")
        strSQL.Append("DI.CANTIDADVENCIDACAPTURA, ")
        strSQL.Append("(L.PRECIOLOTE * DI.CANTIDADVENCIDACAPTURA) TOTALVENCIDACAPTURA, ")
        strSQL.Append("DI.CANTIDADVENCIDADIFERENCIA, ")
        strSQL.Append("DI.IDLOTE, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("I.FECHAINICIO, ")
        strSQL.Append("I.FECHACIERRE, ")
        strSQL.Append("I.FECHACIERREEXISTENCIA, ")
        strSQL.Append("I.IDSUMINISTRO, ")
        strSQL.Append("S.DESCRIPCION SUMINISTRO, ")
        strSQL.Append("I.ESTACERRADO, ")
        strSQL.Append("case I.ESTACERRADO ")
        strSQL.Append("when 0 then 'ABIERTO' ")
        strSQL.Append("when 1 then 'CERRADO' ")
        strSQL.Append("end ESTADO, ")
        strSQL.Append("I.CONSIDERARFUENTE, ")
        strSQL.Append("I.CONSIDERARRESPONSABLE, ")
        strSQL.Append("I.CONSIDERARDISPONIBLES, ")
        strSQL.Append("I.CONSIDERARNODISPONIBLES, ")
        strSQL.Append("I.CONSIDERARVENCIDOS, ")
        strSQL.Append("I.IDALMACEN, ")
        strSQL.Append("I.IDINVENTARIO, ")
        strSQL.Append("A.NOMBRE ALMACEN ")
        strSQL.Append("FROM SAB_ALM_DETALLEINVENTARIO DI ")
        strSQL.Append("INNER JOIN SAB_ALM_INVENTARIO I ")
        strSQL.Append("ON DI.IDALMACEN = I.IDALMACEN AND DI.IDINVENTARIO = I.IDINVENTARIO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON I.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DI.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON DI.IDALMACEN = L.IDALMACEN AND DI.IDLOTE = L.IDLOTE ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON I.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("WHERE DI.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND DI.IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append("AND (I.ESTACERRADO = 0 or ((I.ESTACERRADO = 1 and (DI.CANTIDADDISPONIBLECAPTURA > 0 or DI.CANTIDADNODISPONIBLECAPTURA > 0 or DI.CANTIDADVENCIDACAPTURA > 0)))) ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO, L.CODIGO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDsReporteInventarioFisicoDiferencia(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DI.IDDETALLE, ")
        strSQL.Append("DI.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("CP.CANTIDADDECIMAL, ")
        strSQL.Append("DI.PRECIO, ")
        strSQL.Append("DI.CANTIDADDISPONIBLESISTEMA, ")
        strSQL.Append("DI.CANTIDADDISPONIBLECAPTURA, ")
        strSQL.Append("(L.PRECIOLOTE * DI.CANTIDADDISPONIBLECAPTURA) TOTALDISPONIBLECAPTURA, ")
        strSQL.Append("DI.CANTIDADDISPONIBLEDIFERENCIA, ")
        strSQL.Append("DI.CANTIDADNODISPONIBLESISTEMA, ")
        strSQL.Append("DI.CANTIDADNODISPONIBLECAPTURA, ")
        strSQL.Append("(L.PRECIOLOTE * DI.CANTIDADNODISPONIBLECAPTURA) TOTALNODISPONIBLECAPTURA, ")
        strSQL.Append("DI.CANTIDADNODISPONIBLEDIFERENCIA, ")
        strSQL.Append("DI.CANTIDADVENCIDASISTEMA, ")
        strSQL.Append("DI.CANTIDADVENCIDACAPTURA, ")
        strSQL.Append("(L.PRECIOLOTE * DI.CANTIDADVENCIDACAPTURA) TOTALVENCIDACAPTURA, ")
        strSQL.Append("DI.CANTIDADVENCIDADIFERENCIA, ")
        strSQL.Append("DI.IDLOTE, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("I.FECHAINICIO, ")
        strSQL.Append("I.FECHACIERRE, ")
        strSQL.Append("I.FECHACIERREEXISTENCIA, ")
        strSQL.Append("I.IDSUMINISTRO, ")
        strSQL.Append("S.DESCRIPCION SUMINISTRO, ")
        strSQL.Append("I.ESTACERRADO, ")
        strSQL.Append("case I.ESTACERRADO ")
        strSQL.Append("when 0 then 'ABIERTO' ")
        strSQL.Append("when 1 then 'CERRADO' ")
        strSQL.Append("end ESTADO, ")
        strSQL.Append("I.CONSIDERARFUENTE, ")
        strSQL.Append("I.CONSIDERARRESPONSABLE, ")
        strSQL.Append("I.CONSIDERARDISPONIBLES, ")
        strSQL.Append("I.CONSIDERARNODISPONIBLES, ")
        strSQL.Append("I.CONSIDERARVENCIDOS, ")
        strSQL.Append("I.IDALMACEN, ")
        strSQL.Append("I.IDINVENTARIO, ")
        strSQL.Append("A.NOMBRE ALMACEN ")
        strSQL.Append("FROM SAB_ALM_DETALLEINVENTARIO DI ")
        strSQL.Append("INNER JOIN SAB_ALM_INVENTARIO I ")
        strSQL.Append("ON DI.IDALMACEN = I.IDALMACEN AND DI.IDINVENTARIO = I.IDINVENTARIO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON I.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DI.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON DI.IDALMACEN = L.IDALMACEN AND DI.IDLOTE = L.IDLOTE ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON I.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("WHERE DI.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND DI.IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append("AND ")
        strSQL.Append("((DI.CANTIDADDISPONIBLESISTEMA > DI.CANTIDADDISPONIBLECAPTURA) ")
        strSQL.Append("OR ")
        strSQL.Append("(DI.CANTIDADNODISPONIBLESISTEMA > DI.CANTIDADNODISPONIBLESISTEMA) ")
        strSQL.Append("OR ")
        strSQL.Append("(DI.CANTIDADVENCIDASISTEMA > DI.CANTIDADVENCIDACAPTURA)) ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO, L.CODIGO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Data set para el reporte de ajuste de inventario
    ''' </summary>
    ''' <param name="IDALMACEN"></param> identificador del almacen
    ''' <param name="IDINVENTARIO"></param> identicador de inventario
    ''' <param name="IDDETALLE"></param> identificador de detalle de inventario
    ''' <returns>
    ''' Datset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEINVENTARIO</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_ALM_INVENTARIO</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_ALM_AJUSTE</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_CARGOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerDsReporteaAjusteInventario(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal IDDETALLE As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT di.IDDETALLE, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("vvc.DESCLARGO, vvc.DESCRIPCION, di.PRECIO, di.CANTIDADDISPONIBLESISTEMA, di.CANTIDADDISPONIBLECAPTURA, ")
        strSQL.Append("di.CANTIDADDISPONIBLEDIFERENCIA, di.CANTIDADNODISPONIBLESISTEMA, di.CANTIDADNODISPONIBLECAPTURA, ")
        strSQL.Append("di.CANTIDADNODISPONIBLEDIFERENCIA, di.CANTIDADVENCIDASISTEMA, di.CANTIDADVENCIDACAPTURA, di.CANTIDADVENCIDADIFERENCIA, ")
        strSQL.Append("vvc.CORRPRODUCTO, i.FECHAINICIO, i.FECHACIERRE, i.FECHACIERREEXISTENCIA, i.IDSUMINISTRO, l.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("l.IDRESPONSABLEDISTRIBUCION, i.ESTACERRADO, i.CONSIDERARFUENTE, i.CONSIDERARRESPONSABLE, i.CONSIDERARVENCIDOS, ")
        strSQL.Append("i.CONSIDERARNODISPONIBLES, i.IDALMACEN, i.IDINVENTARIO, SAB_CAT_ALMACENES.NOMBRE AS ALMACEN, f.NOMBRE AS FUENTE, ")
        strSQL.Append("rd.NOMBRE AS RESPONSABLE, aa.MOTIVO, aa.OBSERVACION, e.NOMBRE, e.APELLIDO, c.DESCRIPCION AS CARGO, l.FECHAVENCIMIENTO ")
        strSQL.Append("FROM SAB_ALM_DETALLEINVENTARIO AS di INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS vvc ON di.IDPRODUCTO = vvc.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS l ON di.IDALMACEN = l.IDALMACEN AND di.IDLOTE = l.IDLOTE INNER JOIN ")
        strSQL.Append("SAB_ALM_INVENTARIO AS i ON di.IDALMACEN = i.IDALMACEN AND di.IDINVENTARIO = i.IDINVENTARIO INNER JOIN ")
        strSQL.Append("SAB_CAT_ALMACENES ON i.IDALMACEN = SAB_CAT_ALMACENES.IDALMACEN INNER JOIN ")
        strSQL.Append("SAB_CAT_FUENTEFINANCIAMIENTOS AS f ON l.IDFUENTEFINANCIAMIENTO = f.IDFUENTEFINANCIAMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_RESPONSABLEDISTRIBUCION AS rd ON l.IDRESPONSABLEDISTRIBUCION = rd.IDRESPONSABLEDISTRIBUCION INNER JOIN ")
        strSQL.Append("SAB_ALM_AJUSTE AS aa ON di.IDALMACEN = aa.IDALMACEN AND di.IDINVENTARIO = aa.IDINVENTARIO AND ")
        strSQL.Append("di.IDDETALLE = aa.IDDETALLE INNER JOIN ")
        strSQL.Append("SAB_CAT_EMPLEADOS AS e ON aa.IDJEFEALMACEN = e.IDEMPLEADO INNER JOIN ")
        strSQL.Append("SAB_CAT_CARGOS AS c ON e.IDCARGO = c.IDCARGO ")
        strSQL.Append("WHERE i.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND i.IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append("AND di.IDDETALLE = @IDDETALLE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO
        args(2) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(2).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function CopiarDetalleInventario(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal AUUSUARIOCREACION As String, ByVal IDSUMINISTRO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal CONSIDERARDISPONIBLES As Int32, ByVal CONSIDERARNODISPONIBLES As Int32, ByVal CONSIDERARVENCIDOS As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_CopiarDetalleInventario")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDALMACEN
        args(2) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDINVENTARIO
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = AUUSUARIOCREACION
        args(4) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = IDSUMINISTRO
        args(5) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(5).Direction = ParameterDirection.Input
        args(5).Value = IDFUENTEFINANCIAMIENTO
        args(6) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(6).Direction = ParameterDirection.Input
        args(6).Value = IDRESPONSABLEDISTRIBUCION
        args(7) = New SqlParameter("@CONSIDERARDISPONIBLES", SqlDbType.Int)
        args(7).Direction = ParameterDirection.Input
        args(7).Value = CONSIDERARDISPONIBLES
        args(8) = New SqlParameter("@CONSIDERARNODISPONIBLES", SqlDbType.Int)
        args(8).Direction = ParameterDirection.Input
        args(8).Value = CONSIDERARNODISPONIBLES
        args(9) = New SqlParameter("@CONSIDERARVENCIDOS", SqlDbType.Int)
        args(9).Direction = ParameterDirection.Input
        args(9).Value = CONSIDERARVENCIDOS

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

#End Region

End Class
