
Partial Public Class dbDETALLEMOVIMIENTOS

    ''' <summary>
    ''' Obtiene el detalle de un movimiento especifico.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDTIPOTRANSACCION">Identificador del tipo de transacción.</param>
    ''' <param name="IDMOVIMIENTO">Identificador del movimiento que se desea recuperar.</param>
    ''' <returns>Dataset con el detalle de un movimiento especifico.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_MOVIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  08/01/2007    Creado
    ''' </history> 
    Public Function ObtenerDetalleMovimientosDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("row_number() over(ORDER BY CP.CORRPRODUCTO, DM.IDDETALLEMOVIMIENTO) SECUENCIA, ")
        strSQL.Append("M.IDESTABLECIMIENTO, ")
        strSQL.Append("M.IDTIPOTRANSACCION, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("M.IDTIPODOCREF, ")
        strSQL.Append("M.NUMERODOCREF, ")
        strSQL.Append("M.IDDOCUMENTO, ")
        strSQL.Append("M.IDESTADO, ")
        strSQL.Append("M.FECHAMOVIMIENTO, ")
        strSQL.Append("M.FECHAMOVIMIENTO FECHADOCUMENTO, ")
        strSQL.Append("M.IDALMACEN, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("M.IDUNIDADSOLICITA, ")
        strSQL.Append("D.NOMBRE NOMBREDEPENDENCIA, ")
        strSQL.Append("M.IDESTABLECIMIENTODESTINO, ")
        strSQL.Append("E.NOMBRE DESTINO, ")
        strSQL.Append("M.TOTALMOVIMIENTO, ")
        strSQL.Append("M.IDEMPLEADOSOLICITA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = M.IDEMPLEADOSOLICITA)) NOMBREEMPLEADOSOLICITA, ")
        strSQL.Append("M.IDEMPLEADOAUTORIZA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = M.IDEMPLEADOAUTORIZA)) NOMBREEMPLEADOAUTORIZA, ")
        strSQL.Append("M.IDEMPLEADOALMACEN, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = M.IDEMPLEADOALMACEN)) NOMBREEMPLEADOALMACEN, ")
        strSQL.Append("M.IDEMPLEADODESPACHA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = M.IDEMPLEADODESPACHA)) NOMBREEMPLEADODESPACHA, ")
        strSQL.Append("M.IDEMPLEADORECIBE, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = M.IDEMPLEADORECIBE)) NOMBREEMPLEADORECIBE, ")
        strSQL.Append("M.IDEMPLEADOPREPARA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = M.IDEMPLEADOPREPARA)) NOMBREEMPLEADOPREPARA, ")
        strSQL.Append("M.IDEMPLEADOENVIADO, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = M.IDEMPLEADOENVIADO)) NOMBREEMPLEADOENVIADO, ")
        strSQL.Append("DM.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("DM.IDLOTE, ")
        strSQL.Append("DM.IDPRODUCTO, ")
        strSQL.Append("DM.CANTIDAD, ")
        strSQL.Append("DM.CANTIDADRECHAZADA, ")
        strSQL.Append("DM.CANTIDADANTERIOR, ")
        strSQL.Append("DM.NUMEROFACTURA, ")
        strSQL.Append("DM.FECHAFACTURA, ")
        strSQL.Append("DM.MONTO, ")
        strSQL.Append("L.IDUNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("case when L.CODIGO is null then case when L.DETALLE is null then '(N/A)' else L.DETALLE end else L.CODIGO + isnull(L.DETALLE, '') end CODIGODETALLE, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("(DM.CANTIDAD * L.PRECIOLOTE) TOTAL, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.PRECIOACTUAL, ")
        strSQL.Append("isnull(UP.UBICACION, '') UBICACION ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON DM.IDALMACEN = L.IDALMACEN AND DM.IDLOTE = L.IDLOTE ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON RD.IDRESPONSABLEDISTRIBUCION = L.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON M.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_DEPENDENCIAS D ")
        strSQL.Append("ON M.IDUNIDADSOLICITA = D.IDDEPENDENCIA ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON M.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP ")
        strSQL.Append("ON (L.IDALMACEN = UP.IDALMACEN ")
        strSQL.Append("AND L.IDPRODUCTO = UP.IDPRODUCTO ")
        strSQL.Append("AND L.IDLOTE = UP.IDLOTE) ")
        strSQL.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO, DM.IDDETALLEMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = IDMOVIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el detalle del movimiento de vales de salida
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDTIPOTRANSACCION">Identificador del tipo de transaccion</param>
    ''' <param name="IDMOVIMIENTO">Identificador del movimiento</param>
    ''' <returns>dataset</returns>
    Public Function ObtenerDetalleMovimientoSalida(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("M.*, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("DM.*, ")
        strSQL.Append("L.IDUNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("L.IDESTABLECIMIENTO IDESTABLECIMIENTOCONTROLCALIDAD, ")
        strSQL.Append("L.IDINFORMECONTROLCALIDAD, ")
        strSQL.Append("L.NUMEROINFORMECONTROLCALIDAD, ")
        strSQL.Append("L.FECHAINFORMECONTROLCALIDAD, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.PRECIOACTUAL ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON DM.IDALMACEN = L.IDALMACEN AND DM.IDLOTE = L.IDLOTE ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON FF.IDFUENTEFINANCIAMIENTO = L.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON M.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO, DM.IDDETALLEMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = IDMOVIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene los movimientos de un producto en el almacen
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribucion</param>
    ''' <param name="FECHADESDE">Identificador de la fecha de inicio</param>
    ''' <param name="FECHAHASTA">Identificador de la fecha final</param>
    ''' <returns>dataset</returns>
    Public Function MovimientosPorProducto(ByVal IDALMACEN As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer, ByVal IDPRODUCTO As String, ByVal CODIGO As String, ByVal IDGRUPO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_MovimientosProducto")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Direction = ParameterDirection.Input
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = CODIGO
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = IDFUENTEFINANCIAMIENTO
        args(4) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = IDRESPONSABLEDISTRIBUCION
        args(5) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        args(5).Direction = ParameterDirection.Input
        args(5).Value = IIf(FECHADESDE = Nothing, DBNull.Value, FECHADESDE)
        args(6) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(6).Direction = ParameterDirection.Input
        args(6).Value = IIf(FECHAHASTA = Nothing, DBNull.Value, FECHAHASTA)
        args(7) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(7).Direction = ParameterDirection.Input
        args(7).Value = IDGRUPO
        args(8) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(8).Direction = ParameterDirection.Input
        args(8).Value = IDGRUPOFUENTEFINANCIAMIENTO


        Dim ds As New DataSet
        Dim da As New SqlDataAdapter(strSQL.ToString(), Me.cnnStr)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandTimeout = 0
        For Each param As SqlParameter In args
            If Not param Is Nothing Then
                da.SelectCommand.Parameters.Add(param)
            End If
        Next
        'ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)
        da.Fill(ds)


        'Dim ds As DataSet
        'ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene la informacion de los ingresos generales para cada tipo de producto
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="FECHADESDE">Identificador de la fecha de inicio</param>
    ''' <param name="FECHAHASTA">Identificador de la fecha final</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribucion</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="IDGRUPO">Identificador del grupo</param>
    ''' <param name="orden">Identificador del orden</param>
    ''' <param name="IDGRUPOFUENTEFINANCIAMIENTO">Identificador del grupo de fuente de financiamiento</param>
    ''' <param name="fos">Identificador del filtro de Fosalud</param>
    ''' <returns>dataset</returns>
    Public Function IngresosGeneralesPorTipoProducto(ByVal IDALMACEN As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal orden As Int16, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal fos As Integer, ByVal IDESPECIFICOGASTO As Integer, ByVal transf As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("DM.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("convert(varchar, M.FECHAMOVIMIENTO, 103) FECHAMOVIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, M.IDDOCUMENTO) + '/' + convert(varchar, M.ANIO), '') NUMERODOCUMENTO, ")
        strSQL.Append("CASE WHEN RR.IDALMACENVALE IS NOT NULL THEN ALM.NOMBRE WHEN RR.IDESTABLECIMIENTODEVOLUCION IS NOT NULL THEN EST.NOMBRE WHEN RR.IDPROVEEDOR IS NOT NULL THEN PROV.NOMBRE ELSE '' END AS NOMBRELUGAR, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') LOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("DM.CANTIDAD CANTIDADINGRESO, ")
        strSQL.Append("L.PRECIOLOTE PRECIOUNITARIO, ")
        strSQL.Append("L.PRECIOLOTE , ")
        strSQL.Append("(DM.CANTIDAD * L.PRECIOLOTE) MONTOINGRESO, ")
        strSQL.Append("(DM.CANTIDAD * L.PRECIOLOTE) MONTOCALCULADO, ")
        strSQL.Append("EM.DESCRIPCION ESTADO, ")
        strSQL.Append("TT.DESCRIPCION TIPOTRANSACCION, ")
        strSQL.Append("isnull(M.EMPLEADOALMACEN, '') EMPLEADOALMACEN, ")
        strSQL.Append("'' CARGO ")
        strSQL.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (DM.IDESTABLECIMIENTO = M.IDESTABLECIMIENTO ")
        strSQL.Append("AND DM.IDTIPOTRANSACCION = M.IDTIPOTRANSACCION ")
        strSQL.Append("AND DM.IDMOVIMIENTO = M.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON DM.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS EM ")
        strSQL.Append("ON M.IDESTADO = EM.IDESTADO ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOTRANSACCIONES TT ")
        strSQL.Append("ON M.IDTIPOTRANSACCION = TT.IDTIPOTRANSACCION ")
       
        strSQL.Append("INNER JOIN SAB_ALM_RECIBOSRECEPCION RR ")
        strSQL.Append("ON (RR.IDALMACEN = M.IDALMACEN) AND ")
        strSQL.Append(" (RR.ANIO = M.ANIO) AND ")
        strSQL.Append(" (RR.IDRECIBO = M.IDDOCUMENTO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES ALM ")
        strSQL.Append("ON (ALM.IDALMACEN = RR.IDALMACENVALE) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS EST ")
        strSQL.Append("ON (EST.IDESTABLECIMIENTO = RR.IDESTABLECIMIENTODEVOLUCION) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_PROVEEDORES PROV ")
        strSQL.Append("ON (PROV.IDPROVEEDOR = RR.IDPROVEEDOR) ")
        strSQL.Append("WHERE DM.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("AND (CP.IDESPECIFICOGASTO = @IDESPECIFICOGASTO OR @IDESPECIFICOGASTO = 0) ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        If transf <> 0 Then
            strSQL.Append("AND DM.IDTIPOTRANSACCION in (16) ")
        Else
            strSQL.Append("AND DM.IDTIPOTRANSACCION in (8, 16, 17) ")
        End If


        strSQL.Append("AND M.IDESTADO in (1, 2) ")

        If fos = -1 Then
            strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
            strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
        Else
            If IDGRUPOFUENTEFINANCIAMIENTO = 3 Then
                strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO IN (6,30)) ")
            Else
                If fos = 0 Then
                    strSQL.Append("AND L.IDFUENTEFINANCIAMIENTO NOT IN (6,30) ")
                    strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
                    strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
                Else
                    strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
                    strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
                End If
            End If
        End If

        strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        strSQL.Append("AND ((M.FECHAMOVIMIENTO between @FECHADESDE AND @FECHAHASTA) OR (@FECHADESDE IS NULL OR @FECHAHASTA IS NULL)) ")

        Select Case orden
            Case 1
                strSQL.Append("ORDER BY M.FECHAMOVIMIENTO, M.IDMOVIMIENTO, CP.CORRPRODUCTO, DM.IDDETALLEMOVIMIENTO ")
            Case 2, 3
                strSQL.Append("ORDER BY CP.CORRGRUPO, CP.CORRPRODUCTO, M.FECHAMOVIMIENTO, M.IDMOVIMIENTO, DM.IDDETALLEMOVIMIENTO ")
        End Select

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(1).Value = IDFUENTEFINANCIAMIENTO
        args(2) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(2).Value = IDRESPONSABLEDISTRIBUCION
        args(3) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        args(3).Value = IIf(FECHADESDE = Nothing, DBNull.Value, FECHADESDE)
        args(4) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(4).Value = IIf(FECHAHASTA = Nothing, DBNull.Value, FECHAHASTA)
        args(5) = New SqlParameter("@IDSUMINISTRO", SqlDbType.VarChar)
        args(5).Value = IDSUMINISTRO
        args(6) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(6).Value = IDGRUPO
        args(7) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(7).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(8) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(8).Value = IDESPECIFICOGASTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene la informacion de los despachos generales para cada tipo de productos
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="FECHADESDE">Identificador de la fecha de inicio</param>
    ''' <param name="FECHAHASTA">Identificador de la fecha final</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribucion</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="IDGRUPO">Identificador del grupo</param>
    ''' <param name="IDESTABLECIMIENTODESTINO">Identificador del establecimiento destino</param>
    ''' <param name="orden">Identificador del orden</param>
    ''' <param name="IDGRUPOFUENTEFINANCIAMIENTO">Identificador del grupo de fuente de financiamiento</param>
    ''' <param name="fos">Identificador del filtro de Fosalud</param>
    ''' <returns>dataset</returns>
    Public Function DespachosGeneralesPorTipoProducto(ByVal IDALMACEN As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDESTABLECIMIENTODESTINO As Integer, ByVal orden As Int16, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal fos As Integer, ByVal IDESPECIFICOGASTO As Integer, ByVal TRANSF As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("DM.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("convert(varchar, M.FECHAMOVIMIENTO, 103) FECHAMOVIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, M.IDDOCUMENTO) + '/' + convert(varchar, M.ANIO), '') NUMERODOCUMENTO, ")
        strSQL.Append("M.IDESTABLECIMIENTODESTINO, ")

        'strSQL.Append("E.NOMBRE ESTABLECIMIENTODESTINO, ")
        strSQL.Append("CASE WHEN E.NOMBRE IS NULL THEN LEH.NOMBRE_LUGAR_ENTREGA_HOSPITAL ELSE E.NOMBRE END ESTABLECIMIENTODESTINO, ")

        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') LOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("DM.CANTIDAD CANTIDADEGRESO, ")
        strSQL.Append("L.PRECIOLOTE PRECIOUNITARIO, ")
        strSQL.Append("(DM.CANTIDAD * L.PRECIOLOTE) MONTOEGRESO, ")
        strSQL.Append("(DM.CANTIDAD * L.PRECIOLOTE) MONTOCALCULADO, ")
        strSQL.Append("EM.DESCRIPCION ESTADO, ")
        strSQL.Append("TT.DESCRIPCION TIPOTRANSACCION ")
        strSQL.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (DM.IDESTABLECIMIENTO = M.IDESTABLECIMIENTO ")
        strSQL.Append("AND DM.IDTIPOTRANSACCION = M.IDTIPOTRANSACCION ")
        strSQL.Append("AND DM.IDMOVIMIENTO = M.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON M.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")

        strSQL.Append("LEFT OUTER JOIN SAB_CAT_LUGARES_ENTREGA_HOSPITALES LEH ")
        strSQL.Append("ON M.ID_LUGAR_ENTREGA_HOSPITAL = LEH.ID_LUGAR_ENTREGA_HOSPITAL ")
        strSQL.Append("AND M.IDALMACEN = LEH.IDALMACEN ")

        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON DM.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS EM ")
        strSQL.Append("ON M.IDESTADO = EM.IDESTADO ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOTRANSACCIONES TT ")
        strSQL.Append("ON M.IDTIPOTRANSACCION = TT.IDTIPOTRANSACCION ")
        strSQL.Append("WHERE DM.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("AND (CP.IDESPECIFICOGASTO = @IDESPECIFICOGASTO OR @IDESPECIFICOGASTO = 0) ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        strSQL.Append("AND DM.IDTIPOTRANSACCION = 2 ")
        strSQL.Append("AND M.IDESTADO in (1, 2) ")

        If TRANSF <> 0 Then
            strSQL.Append("AND M.SUBCLASIFICACIONMOVIMIENTO <3 ")
            strSQL.Append("AND E.IDTIPOESTABLECIMIENTO in (3,8,7,10) ")
        End If

        strSQL.Append("AND ((M.IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO OR @IDESTABLECIMIENTODESTINO = 0) OR (M.ID_LUGAR_ENTREGA_HOSPITAL = @IDESTABLECIMIENTODESTINO OR @IDESTABLECIMIENTODESTINO = 0)) ")

        If fos = -1 Then
            strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
            strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
        Else
            If IDGRUPOFUENTEFINANCIAMIENTO = 3 Then
                strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO IN (6,30)) ")
            Else
                strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
                strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
                If fos = 0 Then
                    strSQL.Append("AND L.IDFUENTEFINANCIAMIENTO NOT IN (6,30) ")
                End If
            End If
        End If

        strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        strSQL.Append("AND ((M.FECHAMOVIMIENTO between @FECHADESDE AND @FECHAHASTA) OR (@FECHADESDE IS NULL OR @FECHAHASTA IS NULL)) ")

        Select Case orden
            Case 1
                strSQL.Append("ORDER BY M.FECHAMOVIMIENTO, M.IDMOVIMIENTO, CP.CORRPRODUCTO, DM.IDDETALLEMOVIMIENTO ")
            Case 2, 3
                strSQL.Append("ORDER BY CP.CORRGRUPO, CP.CORRPRODUCTO, M.FECHAMOVIMIENTO, M.IDMOVIMIENTO, DM.IDDETALLEMOVIMIENTO ")
        End Select

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(1).Value = IDFUENTEFINANCIAMIENTO
        args(2) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(2).Value = IDRESPONSABLEDISTRIBUCION
        args(3) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        args(3).Value = IIf(FECHADESDE = Nothing, DBNull.Value, FECHADESDE)
        args(4) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(4).Value = IIf(FECHAHASTA = Nothing, DBNull.Value, FECHAHASTA)
        args(5) = New SqlParameter("@IDSUMINISTRO", SqlDbType.VarChar)
        args(5).Value = IDSUMINISTRO
        args(6) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(6).Value = IDGRUPO
        args(7) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.Int)
        args(7).Value = IDESTABLECIMIENTODESTINO
        args(8) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(8).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(9) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(9).Value = IDESPECIFICOGASTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el número de sequencia del detalle de movimiento para un producto que ya existe.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertenece el movimiento.</param>
    ''' <param name="IDTIPOTRANSACCION">Identificador del tipo de transacción.</param>
    ''' <param name="IDMOVIMIENTO">Identificador del movimiento.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto a buscar.</param>
    ''' <returns>Valor numerico que representa la sequencia del producto.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEMOVIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  07/02/2007    Creado
    ''' </history> 
    Public Function BuscarProductoDetalle(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int16, ByVal IDMOVIMIENTO As Int64, ByVal IDPRODUCTO As Int64) As Int32

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = IDMOVIMIENTO
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(3).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        Else
            Return ds.Tables(0).Rows(0).Item("IDDETALLEMOVIMIENTO")
        End If

    End Function

    ''' <summary>
    ''' Listado de la informacion de ingresos generales
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDTIPOSUMINISTRO">Identificador del tipo de suministro</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="IDRESPONSABLEDISTRIBICION">Identificador del responsable de distribucion</param>
    ''' <param name="FEC1">Identificador de la fecha inicial</param>
    ''' <param name="FEC2">Identificador de la fecha final</param>
    ''' <returns>dataset</returns>
    Public Function ObtenerIngresosGenerales(ByVal IDALMACEN As Int32, ByVal IDTIPOSUMINISTRO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Int64, ByVal IDRESPONSABLEDISTRIBICION As Int16, ByVal FEC1 As Date, ByVal FEC2 As Date) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT A.NOMBRE AS ALMACEN, CP.CODIGO, CP.NOMBRE AS PRODUCTO, UM.DESCRIPCION AS UNIDADMEDIDA, M.FECHAMOVIMIENTO, RR.NUMEROACTA, ")
        strSQL.Append("FF.NOMBRE AS FUENTE, RD.NOMBRE AS RESPONSABLE, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, DM.CANTIDAD, DM.MONTO, ")
        strSQL.Append("TS.DESCRIPCION AS TIPOSUMINISTRO, vv_CATALOGOPRODUCTOS.IDTIPOSUMINISTRO, L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" L.IDRESPONSABLEDISTRIBUCION, DM.IDALMACEN ")
        strSQL.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS AS DM INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS AS CP ON DM.IDPRODUCTO = CP.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_CAT_ALMACENES AS A ON DM.IDALMACEN = A.IDALMACEN INNER JOIN ")
        strSQL.Append("SAB_ALM_RECIBOSRECEPCION AS RR ON A.IDALMACEN = RR.IDALMACEN INNER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS L ON DM.IDALMACEN = L.IDALMACEN AND DM.IDLOTE = L.IDLOTE AND A.IDALMACEN = L.IDALMACEN INNER JOIN ")
        strSQL.Append("SAB_CAT_FUENTEFINANCIAMIENTOS AS FF ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_RESPONSABLEDISTRIBUCION AS RD ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION INNER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS AS UM ON CP.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA AND L.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS M ON DM.IDESTABLECIMIENTO = M.IDESTABLECIMIENTO AND DM.IDTIPOTRANSACCION = M.IDTIPOTRANSACCION AND ")
        strSQL.Append(" DM.IDMOVIMIENTO = M.IDMOVIMIENTO AND A.IDALMACEN = M.IDALMACEN AND A.IDALMACEN = M.IDALMACENDESTINO AND ")
        strSQL.Append("RR.IDALMACEN = M.IDALMACEN AND RR.IDRECIBO = M.IDDOCUMENTO AND RR.ANIO = M.ANIO INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS ON CP.IDPRODUCTO = vv_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOSUMINISTROS AS TS ON vv_CATALOGOPRODUCTOS.IDTIPOSUMINISTRO = TS.IDTIPOSUMINISTRO ")
        strSQL.Append("WHERE (vv_CATALOGOPRODUCTOS.IDTIPOSUMINISTRO = @IDTIPOSUMINISTRO) AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO) AND ")
        strSQL.Append("(M.FECHAMOVIMIENTO BETWEEN @FEC1 AND @FEC2) AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION) AND ")
        strSQL.Append("(DM.IDALMACEN = @IDALMACEN) ")
        strSQL.Append("ORDER BY M.FECHAMOVIMIENTO ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDTIPOSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDTIPOSUMINISTRO
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Value = IDFUENTEFINANCIAMIENTO
        args(3) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(3).Value = IDRESPONSABLEDISTRIBICION
        args(4) = New SqlParameter("@FEC1", SqlDbType.DateTime)
        args(4).Value = FEC1
        args(5) = New SqlParameter("@FEC2", SqlDbType.DateTime)
        args(5).Value = FEC2

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el reporte de Despachos mensuales por producto y almacen.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen.</param>
    ''' <param name="ANIO">Identificador del año.</param>
    ''' <param name="IDESTABLECIMIENTODESTINO">Identificador del establecimiento.</param>
    ''' <returns>Informacion de despachos por mes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEMOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]  07/02/2007    Creado
    ''' </history> 
    Public Function RptDespachosMensualesXProducto(ByVal IDALMACEN As Int32, ByVal ANIO As Int16, ByVal PRODUCTO As String, ByVal IDESTABLECIMIENTODESTINO As Int64, ByVal IDP As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("CASE WHEN PVT.IDESTABLECIMIENTODESTINO2 IS NULL THEN LEH.NOMBRE_LUGAR_ENTREGA_HOSPITAL ELSE E.NOMBRE END ESTABLECIMIENTODESTINO, ")
        strSQL.Append("PVT.CORRPRODUCTO, ")
        strSQL.Append("PVT.DESCLARGO, ")
        strSQL.Append("PVT.UNIDADMEDIDA, ")
        strSQL.Append("PVT.ID_LUGAR_ENTREGA_HOSPITAL, ")
        strSQL.Append("isnull(PVT.[1], 0) Enero, ")
        strSQL.Append("isnull(PVT.[2], 0) Febrero, ")
        strSQL.Append("isnull(PVT.[3], 0) Marzo, ")
        strSQL.Append("isnull(PVT.[4], 0) Abril, ")
        strSQL.Append("isnull(PVT.[5], 0) Mayo, ")
        strSQL.Append("isnull(PVT.[6], 0) Junio, ")
        strSQL.Append("isnull(PVT.[7], 0) Julio, ")
        strSQL.Append("isnull(PVT.[8], 0) Agosto, ")
        strSQL.Append("isnull(PVT.[9], 0) Septiembre, ")
        strSQL.Append("isnull(PVT.[10], 0) Octubre, ")
        strSQL.Append("isnull(PVT.[11], 0) Noviembre, ")
        strSQL.Append("isnull(PVT.[12], 0) Diciembre ")
        strSQL.Append("FROM ")
        strSQL.Append("(SELECT ")
        strSQL.Append(" DM.IDALMACEN, ")
        'strSQL.Append(" M.IDESTABLECIMIENTODESTINO, ")
        strSQL.Append(" CASE WHEN M.IDESTABLECIMIENTODESTINO IS NULL THEN M.ID_LUGAR_ENTREGA_HOSPITAL ELSE M.IDESTABLECIMIENTODESTINO END IDESTABLECIMIENTODESTINO, ")
        strSQL.Append(" M.IDESTABLECIMIENTODESTINO as IDESTABLECIMIENTODESTINO2, ")
        strSQL.Append(" M.ID_LUGAR_ENTREGA_HOSPITAL, ")
        strSQL.Append(" DM.IDPRODUCTO, ")
        strSQL.Append(" CP.CORRPRODUCTO, ")
        strSQL.Append(" CP.DESCLARGO, ")
        strSQL.Append(" CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append(" datepart(month, M.FECHAMOVIMIENTO) MES, ")
        strSQL.Append(" SUM(DM.CANTIDAD) CANTIDAD ")
        strSQL.Append(" FROM SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append(" INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append(" ON (DM.IDESTABLECIMIENTO = M.IDESTABLECIMIENTO ")
        strSQL.Append(" AND DM.IDTIPOTRANSACCION = M.IDTIPOTRANSACCION ")
        strSQL.Append(" AND DM.IDMOVIMIENTO = M.IDMOVIMIENTO) ")
        strSQL.Append(" INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append(" ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append(" M.IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND M.ANIO = @ANIO ")
        strSQL.Append(" AND (DM.IDPRODUCTO = @IDPRODUCTO OR CP.CORRPRODUCTO = @CODIGO) ")
        ' strSQL.Append(" AND M.IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO ")
        strSQL.Append("AND ((M.IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO OR @IDESTABLECIMIENTODESTINO = 0) OR (M.ID_LUGAR_ENTREGA_HOSPITAL = @IDESTABLECIMIENTODESTINO OR @IDESTABLECIMIENTODESTINO = 0)) ")
        strSQL.Append(" AND M.IDTIPOTRANSACCION = 2 ")
        strSQL.Append(" AND M.IDESTADO in (2, 4, 6) ")
        strSQL.Append(" GROUP BY DM.IDALMACEN, M.IDESTABLECIMIENTODESTINO, M.ID_LUGAR_ENTREGA_HOSPITAL, DM.IDPRODUCTO, CP.CORRPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION, DATEPART(month, M.FECHAMOVIMIENTO)) P ")
        strSQL.Append(" PIVOT (SUM(CANTIDAD) FOR MES IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) PVT ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON PVT.IDALMACEN = A.IDALMACEN ")
        'strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        'strSQL.Append("ON PVT.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PVT.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")

        strSQL.Append("LEFT OUTER JOIN SAB_CAT_LUGARES_ENTREGA_HOSPITALES LEH ")
        strSQL.Append("ON PVT.ID_LUGAR_ENTREGA_HOSPITAL = LEH.ID_LUGAR_ENTREGA_HOSPITAL ")
        strSQL.Append("AND PVT.IDALMACEN = LEH.IDALMACEN  ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = ANIO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDP
        args(3) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.Int)
        args(3).Value = IDESTABLECIMIENTODESTINO
        args(4) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(4).Value = PRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el reporte de Despachos mensuales por tipo de producto y almacen.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen.</param>
    ''' <param name="ANIO">Identificador del año.</param>
    ''' <param name="IDSUMINISTRO">Identificador del tipo de producto.</param>
    ''' <param name="IDESTABLECIMIENTODESTINO">Identificador del establecimiento.</param>
    ''' <returns>Informacion de despachos por mes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEMOVIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]  07/02/2007    Creado
    ''' </history>
    Public Function RptDespachosMensualesXTipoProducto(ByVal IDALMACEN As Int32, ByVal ANIO As Int16, ByVal IDSUMINISTRO As Int64, ByVal IDESTABLECIMIENTODESTINO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("CASE WHEN PVT.IDESTABLECIMIENTODESTINO2 IS NULL THEN LEH.NOMBRE_LUGAR_ENTREGA_HOSPITAL ELSE E.NOMBRE END ESTABLECIMIENTODESTINO, ")
        strSQL.Append("PVT.ID_LUGAR_ENTREGA_HOSPITAL, ")
        strSQL.Append("PVT.SUMINISTRO, ")
        strSQL.Append("PVT.CORRPRODUCTO, ")
        strSQL.Append("PVT.DESCLARGO, ")
        strSQL.Append("PVT.UNIDADMEDIDA, ")
        strSQL.Append("isnull([1], 0) Enero, ")
        strSQL.Append("isnull([2], 0) Febrero, ")
        strSQL.Append("isnull([3], 0) Marzo, ")
        strSQL.Append("isnull([4], 0) Abril, ")
        strSQL.Append("isnull([5], 0) Mayo, ")
        strSQL.Append("isnull([6], 0) Junio, ")
        strSQL.Append("isnull([7], 0) Julio, ")
        strSQL.Append("isnull([8], 0) Agosto, ")
        strSQL.Append("isnull([9], 0) Septiembre, ")
        strSQL.Append("isnull([10], 0) Octubre, ")
        strSQL.Append("isnull([11], 0) Noviembre, ")
        strSQL.Append("isnull([12], 0) Diciembre ")
        strSQL.Append("FROM ")
        strSQL.Append(" (SELECT ")
        strSQL.Append(" DM.IDALMACEN, ")

        strSQL.Append(" CASE WHEN M.IDESTABLECIMIENTODESTINO IS NULL THEN M.ID_LUGAR_ENTREGA_HOSPITAL ELSE M.IDESTABLECIMIENTODESTINO END IDESTABLECIMIENTODESTINO, ")
        strSQL.Append(" M.IDESTABLECIMIENTODESTINO as IDESTABLECIMIENTODESTINO2, ")

        strSQL.Append(" M.ID_LUGAR_ENTREGA_HOSPITAL, ")
        strSQL.Append(" DM.IDPRODUCTO, ")
        strSQL.Append(" CP.DESCSUMINISTRO SUMINISTRO, ")
        strSQL.Append(" CP.CORRPRODUCTO, ")
        strSQL.Append(" CP.DESCLARGO, ")
        strSQL.Append(" CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append(" DATEPART(month, FECHAMOVIMIENTO) MES, ")
        strSQL.Append(" SUM(DM.CANTIDAD) CANTIDAD ")
        strSQL.Append(" FROM SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append(" INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append(" ON (DM.IDESTABLECIMIENTO = M.IDESTABLECIMIENTO ")
        strSQL.Append(" AND DM.IDTIPOTRANSACCION = M.IDTIPOTRANSACCION ")
        strSQL.Append(" AND DM.IDMOVIMIENTO = M.IDMOVIMIENTO) ")
        strSQL.Append(" INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append(" ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append(" M.IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND M.ANIO = @ANIO ")
        strSQL.Append(" AND CP.IDSUMINISTRO = @IDSUMINISTRO ")

        'strSQL.Append(" AND M.IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO ")
        strSQL.Append("AND ((M.IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO OR @IDESTABLECIMIENTODESTINO = 0) OR (M.ID_LUGAR_ENTREGA_HOSPITAL = @IDESTABLECIMIENTODESTINO OR @IDESTABLECIMIENTODESTINO = 0)) ")

        strSQL.Append(" AND M.IDTIPOTRANSACCION = 2 ")
        strSQL.Append(" AND M.IDESTADO in (2, 4, 6) ")

        strSQL.Append(" GROUP BY DM.IDALMACEN, M.IDESTABLECIMIENTODESTINO, M.ID_LUGAR_ENTREGA_HOSPITAL, DM.IDPRODUCTO, CP.DESCSUMINISTRO, CP.CORRPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION,  DATEPART(month, FECHAMOVIMIENTO)) P ")

        strSQL.Append(" PIVOT (SUM(CANTIDAD) FOR MES IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) PVT ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON PVT.IDALMACEN = A.IDALMACEN ")

        'strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        'strSQL.Append("ON PVT.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")

        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PVT.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")

        strSQL.Append("LEFT OUTER JOIN SAB_CAT_LUGARES_ENTREGA_HOSPITALES LEH ")
        strSQL.Append("ON PVT.ID_LUGAR_ENTREGA_HOSPITAL = LEH.ID_LUGAR_ENTREGA_HOSPITAL ")
        strSQL.Append("AND PVT.IDALMACEN = LEH.IDALMACEN  ")


        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = ANIO
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.BigInt)
        args(2).Value = IDSUMINISTRO
        args(3) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.BigInt)
        args(3).Value = IDESTABLECIMIENTODESTINO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Reporte de contabilidad
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="MESPERIODO">Identificador del mes</param>
    ''' <param name="ANIOPERIODO">Identificador del año</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="MONTOINICIAL">Identificador del monto</param>
    ''' <returns>dataset</returns>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    ''' 
    Public Function RptContabilidadAlmacen(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal MESPERIODO As Integer, ByVal ANIOPERIODO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal MONTOINICIAL As Decimal) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("M.IDTIPOTRANSACCION, ")
        strSQL.Append("TT.DESCRIPCION TIPOTRANSACCION, ")
        strSQL.Append("TT.AFECTAINVENTARIO, ")
        strSQL.Append("M.SUBCLASIFICACIONMOVIMIENTO, ")
        strSQL.Append("TM.DESCRIPCION TIPOMOVIMIENTO, ")
        strSQL.Append("E.CODIGOESTABLECIMIENTO, ")
        strSQL.Append("isnull(E.NOMBRE, '') ESTABLECIMIENTODESTINO, ")
        strSQL.Append("count(distinct M.IDMOVIMIENTO) MOVIMIENTOS, ")
        strSQL.Append("sum(DM.CANTIDAD * L.PRECIOLOTE) MONTO, ")
        strSQL.Append("sum(case when TT.AFECTAINVENTARIO > 0 then DM.CANTIDAD * L.PRECIOLOTE else 0 end) MONTOINGRESO, ")
        strSQL.Append("sum(case when TT.AFECTAINVENTARIO < 0 then DM.CANTIDAD * L.PRECIOLOTE else 0 end) MONTOEGRESO ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON M.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOTRANSACCIONES TT ")
        strSQL.Append("ON M.IDTIPOTRANSACCION = TT.IDTIPOTRANSACCION ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON M.IDESTABLECIMIENTODESTINO = E.IDESTABLECIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPOESTABLECIMIENTOS TE ")
        strSQL.Append("ON E.IDTIPOESTABLECIMIENTO = TE.IDTIPOESTABLECIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPOMOVIMIENTOS TM ")
        strSQL.Append("ON (M.IDTIPOTRANSACCION = TM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.SUBCLASIFICACIONMOVIMIENTO = TM.IDTIPOMOVIMIENTO) ")
        strSQL.Append("WHERE M.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND CP.IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append("AND (datepart(month, M.FECHAMOVIMIENTO) = @MESPERIODO AND datepart(year, M.FECHAMOVIMIENTO) = @ANIOPERIODO) ")
        strSQL.Append("AND FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO ")
        strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO or @IDFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND TT.AFECTAINVENTARIO <> 0 ")
        strSQL.Append("AND M.IDESTADO = 2 ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("M.IDTIPOTRANSACCION, ")
        strSQL.Append("TT.DESCRIPCION, ")
        strSQL.Append("TT.AFECTAINVENTARIO, ")
        strSQL.Append("M.SUBCLASIFICACIONMOVIMIENTO, ")
        strSQL.Append("TM.DESCRIPCION, ")
        strSQL.Append("E.IDTIPOESTABLECIMIENTO, ")
        strSQL.Append("TE.DESCRIPCION, ")
        strSQL.Append("E.CODIGOESTABLECIMIENTO, ")
        strSQL.Append("E.NOMBRE ")
        strSQL.Append("ORDER BY TT.AFECTAINVENTARIO DESC, E.IDTIPOESTABLECIMIENTO ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.BigInt)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@MESPERIODO", SqlDbType.Int)
        args(2).Value = MESPERIODO
        args(3) = New SqlParameter("@ANIOPERIODO", SqlDbType.Int)
        args(3).Value = ANIOPERIODO
        args(4) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(4).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(5) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(5).Value = IDFUENTEFINANCIAMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Verifica si ya existe un lote con la misma fecha de vencimiento en una recepcion.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDTIPOTRANSACCION">Identificador del tipo de transacción.</param>
    ''' <param name="IDMOVIMIENTO">Identificador del movimiento que se desea recuperar.</param>
    ''' <param name="IDALMACEN">Identificador del almacen.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <param name="CODIGOLOTE">Codigo del lote buscado.</param>
    ''' <param name="FECHAVENCIMIENTO">Fecha de vencimiento a validar.</param>
    ''' <returns>Valor numerico indicando si existe o no el lote buscado.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_MOVIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  08/01/2007    Creado
    ''' </history> 
    Public Function VerificarCodigoLote(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64, ByVal IDALMACEN As Int64, ByVal IDPRODUCTO As Int64, ByVal CODIGOLOTE As String, ByVal FECHAVENCIMIENTO As Date) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("m.IDESTABLECIMIENTO, ")
        strSQL.Append("m.IDTIPOTRANSACCION, ")
        strSQL.Append("m.IDMOVIMIENTO, ")
        strSQL.Append("m.IDTIPODOCREF, ")
        strSQL.Append("m.NUMERODOCREF, ")
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
        strSQL.Append("m.IDEMPLEADOSOLICITA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS WHERE (IDEMPLEADO = m.IDEMPLEADOSOLICITA)) AS NOMBREEMPLEADOSOLICITA, ")
        strSQL.Append("m.IDEMPLEADOAUTORIZA, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_1 WHERE (IDEMPLEADO = m.IDEMPLEADOAUTORIZA)) AS NOMBREEMPLEADOAUTORIZA, ")
        strSQL.Append("m.IDEMPLEADOALMACEN, ")
        strSQL.Append("(SELECT NOMBRECORTO FROM SAB_CAT_EMPLEADOS AS EMPLEADOS_2 WHERE (IDEMPLEADO = m.IDEMPLEADOALMACEN)) AS NOMBREEMPLEADOALMACEN, ")
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
        strSQL.Append("dm.IDPRODUCTO, ")
        strSQL.Append("dm.CANTIDAD, ")
        strSQL.Append("dm.CANTIDADRECHAZADA, ")
        strSQL.Append("dm.CANTIDADANTERIOR, ")
        strSQL.Append("dm.NUMEROFACTURA, ")
        strSQL.Append("dm.FECHAFACTURA, ")
        strSQL.Append("dm.MONTO, ")
        strSQL.Append("l.IDUNIDADMEDIDA, ")
        strSQL.Append("l.CODIGO, ")
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
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS um ")
        strSQL.Append("RIGHT OUTER JOIN ")
        strSQL.Append("SAB_CAT_RESPONSABLEDISTRIBUCION AS rpd RIGHT OUTER JOIN ")
        strSQL.Append("SAB_ALM_LOTES AS l ON rpd.IDRESPONSABLEDISTRIBUCION = l.IDRESPONSABLEDISTRIBUCION ON ")
        strSQL.Append("um.IDUNIDADMEDIDA = l.IDUNIDADMEDIDA LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_FUENTEFINANCIAMIENTOS AS ff ON l.IDFUENTEFINANCIAMIENTO = ff.IDFUENTEFINANCIAMIENTO RIGHT OUTER JOIN ")
        strSQL.Append("SAB_CAT_ALMACENES AS alm RIGHT OUTER JOIN ")
        strSQL.Append("SAB_ALM_MOVIMIENTOS AS m INNER JOIN ")
        strSQL.Append("SAB_ALM_DETALLEMOVIMIENTOS AS dm ON m.IDESTABLECIMIENTO = dm.IDESTABLECIMIENTO AND ")
        strSQL.Append("m.IDTIPOTRANSACCION = dm.IDTIPOTRANSACCION AND m.IDMOVIMIENTO = dm.IDMOVIMIENTO INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS cp ON dm.IDPRODUCTO = cp.IDPRODUCTO ON alm.IDALMACEN = m.IDALMACEN LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_DEPENDENCIAS AS dep ON m.IDUNIDADSOLICITA = dep.IDDEPENDENCIA ON l.IDALMACEN = dm.IDALMACEN AND ")
        strSQL.Append("l.IDLOTE = dm.IDLOTE LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS AS est ON m.IDESTABLECIMIENTODESTINO = est.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE m.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND m.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND m.IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append(" AND m.IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND dm.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND l.CODIGO = @CODIGOLOTE ")
        strSQL.Append(" ORDER BY dm.IDDETALLEMOVIMIENTO")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = IDMOVIMIENTO
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.BigInt)
        args(3).Value = IDALMACEN
        args(4) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(4).Value = IDPRODUCTO
        args(5) = New SqlParameter("@CODIGOLOTE", SqlDbType.VarChar)
        args(5).Value = CODIGOLOTE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Eliminar un detalle de movimientos
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad de detallemovimientos</param>
    ''' <returns>Valor entero con el resultado</returns>
    Public Function Eliminar2(ByVal aEntidad As DETALLEMOVIMIENTOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = aEntidad.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDMOVIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza las cantidades en el detalle de movimientos
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad de detallemovimientos</param>
    ''' <param name="OPERACIONCANTIDADDISPONIBLE">Identificador de la cantidad disponible</param>
    ''' <param name="OPERACIONCANTIDADNODISPONIBLE">Identificador de la cantidad no disponible</param>
    ''' <param name="OPERACIONCANTIDADRESERVADA">Identificador de la cantidad reservada</param>
    ''' <param name="OPERACIONCANTIDADVENCIDA">Identificador de la cantidad vencida</param>
    ''' <param name="OPERACIONCANTIDADTEMPORAL">Identificador de la cantidad temporal</param>
    ''' <returns>Valor entero con el resultado</returns>
    Public Function ActualizarCantidades(ByVal aEntidad As DETALLEMOVIMIENTOS, ByVal OPERACIONCANTIDADDISPONIBLE As Int16, ByVal OPERACIONCANTIDADNODISPONIBLE As Int16, ByVal OPERACIONCANTIDADRESERVADA As Int16, ByVal OPERACIONCANTIDADVENCIDA As Int16, ByVal OPERACIONCANTIDADTEMPORAL As Int16) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_ALM_LOTES ")
        strSQL.Append("SET CANTIDADDISPONIBLE = ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN @OPERACIONCANTIDADDISPONIBLE = 1 THEN CANTIDADDISPONIBLE + @CANTIDAD ")
        strSQL.Append("WHEN @OPERACIONCANTIDADDISPONIBLE = 2 THEN CANTIDADDISPONIBLE - @CANTIDAD ")
        strSQL.Append("ELSE CANTIDADDISPONIBLE ")
        strSQL.Append("END, ")
        strSQL.Append("CANTIDADNODISPONIBLE = ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN @OPERACIONCANTIDADNODISPONIBLE = 1 THEN CANTIDADNODISPONIBLE + @CANTIDAD ")
        strSQL.Append("WHEN @OPERACIONCANTIDADNODISPONIBLE = 2 THEN CANTIDADNODISPONIBLE - @CANTIDAD ")
        strSQL.Append("ELSE CANTIDADNODISPONIBLE ")
        strSQL.Append("END, ")
        strSQL.Append("CANTIDADRESERVADA = ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN @OPERACIONCANTIDADRESERVADA = 1 THEN CANTIDADRESERVADA + @CANTIDAD ")
        strSQL.Append("WHEN @OPERACIONCANTIDADRESERVADA = 2 THEN CANTIDADRESERVADA - @CANTIDAD ")
        strSQL.Append("ELSE CANTIDADRESERVADA ")
        strSQL.Append("END, ")
        strSQL.Append("CANTIDADVENCIDA = ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN @OPERACIONCANTIDADVENCIDA = 1 THEN CANTIDADVENCIDA + @CANTIDAD ")
        strSQL.Append("WHEN @OPERACIONCANTIDADVENCIDA = 2 THEN CANTIDADVENCIDA - @CANTIDAD ")
        strSQL.Append("ELSE CANTIDADVENCIDA ")
        strSQL.Append("END, ")
        strSQL.Append("CANTIDADTEMPORAL = ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN @OPERACIONCANTIDADTEMPORAL = 1 THEN CANTIDADTEMPORAL + @CANTIDAD ")
        strSQL.Append("WHEN @OPERACIONCANTIDADTEMPORAL = 2 THEN CANTIDADTEMPORAL - @CANTIDAD ")
        strSQL.Append("ELSE CANTIDADTEMPORAL ")
        strSQL.Append("END, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN AND IDLOTE = @IDLOTE ")
        strSQL.Append("AND ((CANTIDADDISPONIBLE >= @CANTIDAD AND @OPERACIONCANTIDADDISPONIBLE = 2) OR @OPERACIONCANTIDADDISPONIBLE = 1 OR @OPERACIONCANTIDADDISPONIBLE IS NULL) ")
        strSQL.Append("AND ((CANTIDADNODISPONIBLE >= @CANTIDAD AND @OPERACIONCANTIDADNODISPONIBLE = 2) OR @OPERACIONCANTIDADNODISPONIBLE = 1 OR @OPERACIONCANTIDADNODISPONIBLE IS NULL) ")
        strSQL.Append("AND ((CANTIDADRESERVADA >= @CANTIDAD AND @OPERACIONCANTIDADRESERVADA = 2) OR @OPERACIONCANTIDADRESERVADA = 1 OR @OPERACIONCANTIDADRESERVADA IS NULL) ")
        strSQL.Append("AND ((CANTIDADVENCIDA >= @CANTIDAD AND @OPERACIONCANTIDADVENCIDA = 2) OR @OPERACIONCANTIDADVENCIDA = 1 OR @OPERACIONCANTIDADVENCIDA IS NULL) ")
        strSQL.Append("AND ((CANTIDADTEMPORAL >= @CANTIDAD AND @OPERACIONCANTIDADTEMPORAL = 2) OR @OPERACIONCANTIDADTEMPORAL = 1 OR @OPERACIONCANTIDADTEMPORAL IS NULL) ")

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("INSERT INTO SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL1.Append(" ( IDESTABLECIMIENTO, ")
        strSQL1.Append(" IDTIPOTRANSACCION, ")
        strSQL1.Append(" IDMOVIMIENTO, ")
        strSQL1.Append(" IDDETALLEMOVIMIENTO, ")
        strSQL1.Append(" IDALMACEN, ")
        strSQL1.Append(" IDLOTE, ")
        strSQL1.Append(" IDPRODUCTO, ")
        strSQL1.Append(" RENGLON, ")
        strSQL1.Append(" CANTIDAD, ")
        strSQL1.Append(" CANTIDADRECHAZADA, ")
        strSQL1.Append(" CANTIDADANTERIOR, ")
        strSQL1.Append(" NUMEROFACTURA, ")
        strSQL1.Append(" NOENVIO, ")
        strSQL1.Append(" FECHAFACTURA, ")
        strSQL1.Append(" MONTO, ")
        strSQL1.Append(" NUMEROINFORMECONTROLCALIDAD, ")
        strSQL1.Append(" IDDETALLEENTREGA, ")
        strSQL1.Append(" IDTIPODOCUMENTO, ")
        strSQL1.Append(" AUUSUARIOCREACION, ")
        strSQL1.Append(" AUFECHACREACION, ")
        strSQL1.Append(" AUUSUARIOMODIFICACION, ")
        strSQL1.Append(" AUFECHAMODIFICACION, ")
        strSQL1.Append(" ESTASINCRONIZADA, ")
        strSQL1.Append(" CANTIDADNODISPONIBLE) ")
        strSQL1.Append(" SELECT ")
        strSQL1.Append(" @IDESTABLECIMIENTO, ")
        strSQL1.Append(" @IDTIPOTRANSACCION, ")
        strSQL1.Append(" @IDMOVIMIENTO, ")
        strSQL1.Append(" (SELECT isnull(max(IDDETALLEMOVIMIENTO),0) + 1 ")
        strSQL1.Append(" FROM SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL1.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL1.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL1.Append(" AND IDMOVIMIENTO = @IDMOVIMIENTO), ")
        strSQL1.Append(" @IDALMACEN, ")
        strSQL1.Append(" @IDLOTE, ")
        strSQL1.Append(" @IDPRODUCTO, ")
        strSQL1.Append(" @RENGLON, ")
        strSQL1.Append(" @CANTIDAD, ")
        strSQL1.Append(" @CANTIDADRECHAZADA, ")
        strSQL1.Append(" @CANTIDADANTERIOR, ")
        strSQL1.Append(" @NUMEROFACTURA, ")
        strSQL1.Append(" @NOENVIO, ")
        strSQL1.Append(" @FECHAFACTURA, ")
        strSQL1.Append(" @MONTO, ")
        strSQL1.Append(" @NUMEROINFORMECONTROLCALIDAD, ")
        strSQL1.Append(" @IDDETALLEENTREGA, ")
        strSQL1.Append(" @IDTIPODOCUMENTO, ")
        strSQL1.Append(" @AUUSUARIOCREACION, ")
        strSQL1.Append(" @AUFECHACREACION, ")
        strSQL1.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL1.Append(" @AUFECHAMODIFICACION, ")
        strSQL1.Append(" @ESTASINCRONIZADA, ")
        strSQL1.Append(" @CANTIDADNODISPONIBLE ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@OPERACIONCANTIDADDISPONIBLE", SqlDbType.TinyInt)
        args(0).Value = IIf(OPERACIONCANTIDADDISPONIBLE = 0, Nothing, OPERACIONCANTIDADDISPONIBLE)
        args(1) = New SqlParameter("@OPERACIONCANTIDADNODISPONIBLE", SqlDbType.TinyInt)
        args(1).Value = IIf(OPERACIONCANTIDADNODISPONIBLE = 0, Nothing, OPERACIONCANTIDADNODISPONIBLE)
        args(2) = New SqlParameter("@OPERACIONCANTIDADRESERVADA", SqlDbType.TinyInt)
        args(2).Value = IIf(OPERACIONCANTIDADRESERVADA = 0, Nothing, OPERACIONCANTIDADRESERVADA)
        args(3) = New SqlParameter("@OPERACIONCANTIDADVENCIDA", SqlDbType.TinyInt)
        args(3).Value = IIf(OPERACIONCANTIDADVENCIDA = 0, Nothing, OPERACIONCANTIDADVENCIDA)
        args(4) = New SqlParameter("@OPERACIONCANTIDADTEMPORAL", SqlDbType.TinyInt)
        args(4).Value = IIf(OPERACIONCANTIDADTEMPORAL = 0, Nothing, OPERACIONCANTIDADTEMPORAL)
        args(5) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args(5).Value = aEntidad.CANTIDAD
        args(6) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(6).Value = aEntidad.IDALMACEN
        args(7) = New SqlParameter("@IDLOTE", SqlDbType.Int)
        args(7).Value = aEntidad.IDLOTE
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(10) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(10).Value = aEntidad.IDPRODUCTO

        Dim args1(23) As SqlParameter
        args1(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args1(0).Value = aEntidad.IDESTABLECIMIENTO
        args1(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args1(1).Value = aEntidad.IDTIPOTRANSACCION
        args1(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args1(2).Value = aEntidad.IDMOVIMIENTO
        args1(3) = New SqlParameter("@IDDETALLEMOVIMIENTO", SqlDbType.BigInt)
        args1(3).Value = aEntidad.IDDETALLEMOVIMIENTO
        args1(4) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args1(4).Value = aEntidad.IDALMACEN
        args1(5) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args1(5).Value = IIf(aEntidad.IDLOTE = Nothing, DBNull.Value, aEntidad.IDLOTE)
        args1(6) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args1(6).Value = aEntidad.IDPRODUCTO
        args1(7) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args1(7).Value = IIf(aEntidad.RENGLON = Nothing, DBNull.Value, aEntidad.RENGLON)
        args1(8) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args1(8).Value = aEntidad.CANTIDAD
        args1(9) = New SqlParameter("@CANTIDADRECHAZADA", SqlDbType.Decimal)
        args1(9).Value = IIf(aEntidad.CANTIDADRECHAZADA = Nothing, DBNull.Value, aEntidad.CANTIDADRECHAZADA)
        args1(10) = New SqlParameter("@CANTIDADANTERIOR", SqlDbType.Decimal)
        args1(10).Value = IIf(aEntidad.CANTIDADANTERIOR = Nothing, DBNull.Value, aEntidad.CANTIDADANTERIOR)
        args1(11) = New SqlParameter("@NUMEROFACTURA", SqlDbType.VarChar)
        args1(11).Value = IIf(aEntidad.NUMEROFACTURA = Nothing, DBNull.Value, aEntidad.NUMEROFACTURA)
        args1(12) = New SqlParameter("@FECHAFACTURA", SqlDbType.DateTime)
        args1(12).Value = IIf(aEntidad.FECHAFACTURA = Nothing, DBNull.Value, aEntidad.FECHAFACTURA)
        args1(13) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args1(13).Value = aEntidad.MONTO
        args1(14) = New SqlParameter("@NUMEROINFORMECONTROLCALIDAD", SqlDbType.VarChar)
        args1(14).Value = IIf(aEntidad.NUMEROINFORMECONTROLCALIDAD = Nothing, DBNull.Value, aEntidad.NUMEROINFORMECONTROLCALIDAD)
        args1(15) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.Int)
        args1(15).Value = aEntidad.IDDETALLEENTREGA
        args1(16) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args1(16).Value = IIf(aEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args1(17) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args1(17).Value = IIf(aEntidad.AUFECHACREACION = Nothing, DBNull.Value, aEntidad.AUFECHACREACION)
        args1(18) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args1(18).Value = DBNull.Value
        args1(19) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args1(19).Value = DBNull.Value
        args1(20) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args1(20).Value = aEntidad.ESTASINCRONIZADA
        args1(21) = New SqlParameter("@NOENVIO", SqlDbType.VarChar)
        args1(21).Value = IIf(aEntidad.NOENVIO = Nothing, DBNull.Value, aEntidad.NOENVIO)
        args1(22) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args1(22).Value = IIf(aEntidad.IDTIPODOCUMENTO = Nothing, DBNull.Value, aEntidad.IDTIPODOCUMENTO)
        args1(23) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.SmallInt)
        args1(23).Value = aEntidad.CANTIDADNODISPONIBLE

        Dim resultado As Integer

        Using c As New SqlConnection(Me.cnnStr)

            c.Open()

            Dim t As SqlTransaction = c.BeginTransaction()

            Try

                If SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args) = 1 Then

                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args1)

                    t.Commit()

                    resultado = 1
                Else
                    t.Rollback()
                End If
            Catch ex As Exception
                t.Rollback()
                Throw
            Finally
                If Not t Is Nothing Then t.Dispose()
                If Not c.State = ConnectionState.Closed Then c.Close()
            End Try

        End Using

        Return resultado

    End Function

    'Public Function GuardarRecepcion(ByVal eM As MOVIMIENTOS, ByVal eRR As RECIBOSRECEPCION) As Integer

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("UPDATE SAB_ALM_MOVIMIENTOS ")
    '    strSQL.Append("SET ")
    '    strSQL.Append("IDESTADO = @IDESTADO, ")
    '    strSQL.Append("FECHAMOVIMIENTO = @FECHAMOVIMIENTO, ")
    '    strSQL.Append("IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO, ")
    '    strSQL.Append("IDALMACENDESTINO = @IDALMACENDESTINO, ")
    '    strSQL.Append("IDEMPLEADOALMACEN = @IDEMPLEADOALMACEN, ")
    '    strSQL.Append("EMPLEADOALMACEN = @EMPLEADOALMACEN, ")
    '    strSQL.Append("IDEMPLEADODESPACHA = @IDEMPLEADODESPACHA, ")
    '    strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
    '    strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
    '    strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
    '    strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL.Append("AND IDTIPOTRANSACCION = 2")
    '    strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
    '    strSQL.Append("AND IDESTADO = 1 ")

    '    Dim args(12) As SqlParameter
    '    args(0) = New SqlParameter("@IDESTADO", SqlDbType.Int)
    '    args(0).Value = eM.IDESTADO
    '    args(1) = New SqlParameter("@FECHAMOVIMIENTO", SqlDbType.DateTime)
    '    args(1).Value = IIf(eM.FECHAMOVIMIENTO = Nothing, DBNull.Value, eM.FECHAMOVIMIENTO)
    '    args(2) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.Int)
    '    args(2).Value = IIf(eM.IDESTABLECIMIENTODESTINO = Nothing, DBNull.Value, eM.IDESTABLECIMIENTODESTINO)
    '    args(3) = New SqlParameter("@IDALMACENDESTINO", SqlDbType.Int)
    '    args(3).Value = IIf(eM.IDALMACENDESTINO = Nothing, DBNull.Value, eM.IDALMACENDESTINO)
    '    args(4) = New SqlParameter("@IDEMPLEADOALMACEN", SqlDbType.Int)
    '    args(4).Value = IIf(eM.IDEMPLEADOALMACEN = Nothing, DBNull.Value, eM.IDEMPLEADOALMACEN)
    '    args(5) = New SqlParameter("@EMPLEADOALMACEN", SqlDbType.VarChar)
    '    args(5).Value = IIf(eM.EMPLEADOALMACEN = Nothing, DBNull.Value, eM.EMPLEADOALMACEN)
    '    args(6) = New SqlParameter("@IDEMPLEADODESPACHA", SqlDbType.Int)
    '    args(6).Value = IIf(eM.IDEMPLEADODESPACHA = Nothing, DBNull.Value, eM.IDEMPLEADODESPACHA)
    '    args(7) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
    '    args(7).Value = IIf(eM.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eM.AUUSUARIOMODIFICACION)
    '    args(8) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
    '    args(8).Value = IIf(eM.AUFECHAMODIFICACION = Nothing, DBNull.Value, eM.AUFECHAMODIFICACION)
    '    args(9) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
    '    args(9).Value = eM.ESTASINCRONIZADA
    '    args(10) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(10).Value = eM.IDESTABLECIMIENTO
    '    args(11) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
    '    args(11).Value = eM.IDTIPOTRANSACCION
    '    args(12) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
    '    args(12).Value = eM.IDMOVIMIENTO

    '    Dim strSQL1 As New Text.StringBuilder
    '    strSQL1.Append("UPDATE SAB_ALM_VALESSALIDA ")
    '    strSQL1.Append(" SET TRANSPORTISTA = @TRANSPORTISTA, ")
    '    strSQL1.Append(" MATRICULAVEHICULO = @MATRICULAVEHICULO, ")
    '    strSQL1.Append(" PERSONARECIBE = @PERSONARECIBE, ")
    '    strSQL1.Append(" IDTIPOIDENTIFICACION = @IDTIPOIDENTIFICACION, ")
    '    strSQL1.Append(" NUMEROIDENTIFICACION = @NUMEROIDENTIFICACION, ")
    '    strSQL1.Append(" OBSERVACION = @OBSERVACION, ")
    '    strSQL1.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
    '    strSQL1.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
    '    strSQL1.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
    '    strSQL1.Append("FROM SAB_ALM_MOVIMIENTOS M ")
    '    strSQL1.Append("INNER JOIN SAB_ALM_VALESSALIDA VS ")
    '    strSQL1.Append("ON VS.IDALMACEN = M.IDALMACEN ")
    '    strSQL1.Append("AND VS.ANIO = M.ANIO ")
    '    strSQL1.Append("AND VS.IDVALE = M.IDDOCUMENTO ")
    '    strSQL1.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL1.Append("AND M.IDTIPOTRANSACCION = 2")
    '    strSQL1.Append("AND M.IDMOVIMIENTO = @IDMOVIMIENTO ")

    '    Dim args1(13) As SqlParameter
    '    args1(0) = New SqlParameter("@TRANSPORTISTA", SqlDbType.VarChar)
    '    args1(0).Value = IIf(eVS.TRANSPORTISTA = Nothing, DBNull.Value, eVS.TRANSPORTISTA)
    '    args1(1) = New SqlParameter("@MATRICULAVEHICULO", SqlDbType.VarChar)
    '    args1(1).Value = IIf(eVS.MATRICULAVEHICULO = Nothing, DBNull.Value, eVS.MATRICULAVEHICULO)
    '    args1(2) = New SqlParameter("@PERSONARECIBE", SqlDbType.VarChar)
    '    args1(2).Value = IIf(eVS.PERSONARECIBE = Nothing, DBNull.Value, eVS.PERSONARECIBE)
    '    args1(3) = New SqlParameter("@IDTIPOIDENTIFICACION", SqlDbType.SmallInt)
    '    args1(3).Value = IIf(eVS.IDTIPOIDENTIFICACION = Nothing, DBNull.Value, eVS.IDTIPOIDENTIFICACION)
    '    args1(4) = New SqlParameter("@NUMEROIDENTIFICACION", SqlDbType.VarChar)
    '    args1(4).Value = IIf(eVS.NUMEROIDENTIFICACION = Nothing, DBNull.Value, eVS.NUMEROIDENTIFICACION)
    '    args1(5) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
    '    args1(5).Value = IIf(eVS.OBSERVACION = Nothing, DBNull.Value, eVS.OBSERVACION)
    '    args1(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
    '    args1(6).Value = IIf(eVS.AUUSUARIOCREACION = Nothing, DBNull.Value, eVS.AUUSUARIOCREACION)
    '    args1(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
    '    args1(7).Value = IIf(eVS.AUFECHACREACION = Nothing, DBNull.Value, eVS.AUFECHACREACION)
    '    args1(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
    '    args1(8).Value = IIf(eVS.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eVS.AUUSUARIOMODIFICACION)
    '    args1(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
    '    args1(9).Value = IIf(eVS.AUFECHAMODIFICACION = Nothing, DBNull.Value, eVS.AUFECHAMODIFICACION)
    '    args1(10) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
    '    args1(10).Value = eVS.ESTASINCRONIZADA
    '    args1(11) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args1(11).Value = eM.IDESTABLECIMIENTO
    '    args1(12) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
    '    args1(12).Value = eM.IDTIPOTRANSACCION
    '    args1(13) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
    '    args1(13).Value = eM.IDMOVIMIENTO

    '    Dim strSQL2 As New Text.StringBuilder
    '    strSQL2.Append("UPDATE SAB_ALM_LOTES ")
    '    strSQL2.Append("SET ESTADISPONIBLE = 1, ")
    '    strSQL2.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
    '    strSQL2.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
    '    strSQL2.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS DM ")
    '    strSQL2.Append("INNER JOIN SAB_ALM_LOTES L ")
    '    strSQL2.Append("ON DM.IDALMACEN = L.IDALMACEN ")
    '    strSQL2.Append("AND DM.IDLOTE = L.IDLOTE ")
    '    strSQL2.Append("WHERE DM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL2.Append("AND DM.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
    '    strSQL2.Append("AND DM.IDMOVIMIENTO = @IDMOVIMIENTO ")

    '    Dim resultado As Integer

    '    Using c As New SqlConnection(Me.cnnStr)

    '        c.Open()

    '        Dim t As SqlTransaction = c.BeginTransaction()

    '        Try

    '            If SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args) = 1 Then

    '                SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args1)

    '                SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL2.ToString, args)

    '                t.Commit()

    '                resultado = 1
    '            Else
    '                t.Rollback()
    '            End If
    '        Catch ex As Exception
    '            t.Rollback()
    '            Throw
    '        Finally
    '            If c.State = ConnectionState.Open Then c.Close()
    '        End Try

    '    End Using

    '    Return resultado

    'End Function
    ''' <summary>
    ''' Ingresar un lote en la recepcion
    ''' </summary>
    ''' <param name="eL">Identificador de la entidad lotes</param>
    ''' <param name="eDM">Identificador de la entidad detallemovimientos</param>
    ''' <param name="eU">Identificador de la entidad de ubicacion</param>
    ''' <param name="lAEC">Identificador de la lista de almacenes entregas contratos</param>
    ''' <returns>Valor entero con el resultado</returns>

    Public Function AgregarLoteRecepcion(ByVal eL As LOTES, ByVal eDM As DETALLEMOVIMIENTOS, ByVal eU As UBICACIONESPRODUCTOS, ByVal lAEC As listaALMACENESENTREGACONTRATOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("INSERT INTO SAB_ALM_LOTES ")
        strSQL.Append(" ( IDALMACEN, ")
        strSQL.Append(" IDLOTE, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" CODIGO, ")
        strSQL.Append(" PRECIOLOTE, ")
        strSQL.Append(" FECHAVENCIMIENTO, ")
        strSQL.Append(" IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDINFORMECONTROLCALIDAD, ")
        strSQL.Append(" NUMEROINFORMECONTROLCALIDAD, ")
        strSQL.Append(" FECHAINFORMECONTROLCALIDAD, ")
        strSQL.Append(" IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" CANTIDADDISPONIBLE, ")
        strSQL.Append(" CANTIDADNODISPONIBLE, ")
        strSQL.Append(" CANTIDADVENCIDA, ")
        strSQL.Append(" CANTIDADRESERVADA, ")
        strSQL.Append(" CANTIDADTEMPORAL, ")
        strSQL.Append(" ESTADISPONIBLE, ")
        strSQL.Append(" IDALMACENORIGEN, ")
        strSQL.Append(" DETALLE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALMACEN, ")
        strSQL.Append(" (@IDLOTE), ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @CODIGO, ")
        strSQL.Append(" @PRECIOLOTE, ")
        strSQL.Append(" @FECHAVENCIMIENTO, ")
        strSQL.Append(" @IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDINFORMECONTROLCALIDAD, ")
        strSQL.Append(" @NUMEROINFORMECONTROLCALIDAD, ")
        strSQL.Append(" @FECHAINFORMECONTROLCALIDAD, ")
        strSQL.Append(" @IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" @CANTIDADDISPONIBLE, ")
        strSQL.Append(" @CANTIDADNODISPONIBLE, ")
        strSQL.Append(" @CANTIDADVENCIDA, ")
        strSQL.Append(" @CANTIDADRESERVADA, ")
        strSQL.Append(" @CANTIDADTEMPORAL, ")
        strSQL.Append(" @ESTADISPONIBLE, ")
        strSQL.Append(" @IDALMACENORIGEN, ")
        strSQL.Append(" @DETALLE, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION) ")

        Dim args(22) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = eL.IDALMACEN
        args(1) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(1).Value = eL.IDLOTE
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = eL.IDPRODUCTO
        args(3) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(3).Value = eL.IDUNIDADMEDIDA
        args(4) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(4).Value = IIf(eL.CODIGO = Nothing, DBNull.Value, eL.CODIGO)
        args(5) = New SqlParameter("@PRECIOLOTE", SqlDbType.Decimal)
        args(5).Value = eL.PRECIOLOTE
        args(6) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(6).Value = IIf(eL.FECHAVENCIMIENTO = Nothing, DBNull.Value, eL.FECHAVENCIMIENTO)
        args(7) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(7).Value = eL.IDRESPONSABLEDISTRIBUCION
        args(8) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(8).Value = IIf(eL.IDESTABLECIMIENTO = Nothing, DBNull.Value, eL.IDESTABLECIMIENTO)
        args(9) = New SqlParameter("@IDINFORMECONTROLCALIDAD", SqlDbType.Int)
        args(9).Value = IIf(eL.IDINFORMECONTROLCALIDAD = Nothing, DBNull.Value, eL.IDINFORMECONTROLCALIDAD)
        args(10) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(10).Value = eL.IDFUENTEFINANCIAMIENTO
        args(11) = New SqlParameter("@CANTIDADDISPONIBLE", SqlDbType.Decimal)
        args(11).Value = eL.CANTIDADDISPONIBLE
        args(12) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.Decimal)
        args(12).Value = eL.CANTIDADNODISPONIBLE
        args(13) = New SqlParameter("@CANTIDADVENCIDA", SqlDbType.Decimal)
        args(13).Value = eL.CANTIDADVENCIDA
        args(14) = New SqlParameter("@CANTIDADRESERVADA", SqlDbType.Decimal)
        args(14).Value = eL.CANTIDADRESERVADA
        args(15) = New SqlParameter("@CANTIDADTEMPORAL", SqlDbType.Decimal)
        args(15).Value = eL.CANTIDADTEMPORAL
        args(16) = New SqlParameter("@ESTADISPONIBLE", SqlDbType.TinyInt)
        args(16).Value = eL.ESTADISPONIBLE
        args(17) = New SqlParameter("@IDALMACENORIGEN", SqlDbType.Int)
        args(17).Value = IIf(eL.IDALMACENORIGEN = Nothing, DBNull.Value, eL.IDALMACENORIGEN)
        args(18) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(18).Value = IIf(eL.AUUSUARIOCREACION = Nothing, DBNull.Value, eL.AUUSUARIOCREACION)
        args(19) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(19).Value = IIf(eL.AUFECHACREACION = Nothing, DBNull.Value, eL.AUFECHACREACION)
        args(20) = New SqlParameter("@NUMEROINFORMECONTROLCALIDAD", SqlDbType.VarChar)
        args(20).Value = IIf(eL.NUMEROINFORMECONTROLCALIDAD = Nothing, DBNull.Value, eL.NUMEROINFORMECONTROLCALIDAD)
        args(21) = New SqlParameter("@FECHAINFORMECONTROLCALIDAD", SqlDbType.DateTime)
        args(21).Value = IIf(eL.FECHAINFORMECONTROLCALIDAD = Nothing, DBNull.Value, eL.FECHAINFORMECONTROLCALIDAD)
        args(22) = New SqlParameter("@DETALLE", SqlDbType.VarChar)
        args(22).Value = IIf(eL.DETALLE = Nothing, DBNull.Value, eL.DETALLE)

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("INSERT INTO SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL1.Append(" ( IDESTABLECIMIENTO, ")
        strSQL1.Append(" IDTIPOTRANSACCION, ")
        strSQL1.Append(" IDMOVIMIENTO, ")
        strSQL1.Append(" IDDETALLEMOVIMIENTO, ")
        strSQL1.Append(" IDALMACEN, ")
        strSQL1.Append(" IDLOTE, ")
        strSQL1.Append(" IDPRODUCTO, ")
        strSQL1.Append(" RENGLON, ")
        strSQL1.Append(" CANTIDAD, ")
        strSQL1.Append(" CANTIDADRECHAZADA, ")
        strSQL1.Append(" CANTIDADANTERIOR, ")
        strSQL1.Append(" NUMEROFACTURA, ")
        strSQL1.Append(" NOENVIO, ")
        strSQL1.Append(" FECHAFACTURA, ")
        strSQL1.Append(" MONTO, ")
        strSQL1.Append(" NUMEROINFORMECONTROLCALIDAD, ")
        strSQL1.Append(" IDDETALLEENTREGA, ")
        strSQL1.Append(" IDTIPODOCUMENTO, ")
        strSQL1.Append(" AUUSUARIOCREACION, ")
        strSQL1.Append(" AUFECHACREACION) ")
        strSQL1.Append(" SELECT ")
        strSQL1.Append(" @IDESTABLECIMIENTO, ")
        strSQL1.Append(" @IDTIPOTRANSACCION, ")
        strSQL1.Append(" @IDMOVIMIENTO, ")
        strSQL1.Append(" (SELECT isnull(max(IDDETALLEMOVIMIENTO),0) + 1 ")
        strSQL1.Append(" FROM SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL1.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL1.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL1.Append(" AND IDMOVIMIENTO = @IDMOVIMIENTO), ")
        strSQL1.Append(" @IDALMACEN, ")
        strSQL1.Append(" @IDLOTE, ")
        strSQL1.Append(" @IDPRODUCTO, ")
        strSQL1.Append(" @RENGLON, ")
        strSQL1.Append(" @CANTIDAD, ")
        strSQL1.Append(" @CANTIDADRECHAZADA, ")
        strSQL1.Append(" @CANTIDADANTERIOR, ")
        strSQL1.Append(" @NUMEROFACTURA, ")
        strSQL1.Append(" @NOENVIO, ")
        strSQL1.Append(" @FECHAFACTURA, ")
        strSQL1.Append(" @MONTO, ")
        strSQL1.Append(" @NUMEROINFORMECONTROLCALIDAD, ")
        strSQL1.Append(" @IDDETALLEENTREGA, ")
        strSQL1.Append(" @IDTIPODOCUMENTO, ")
        strSQL1.Append(" @AUUSUARIOCREACION, ")
        strSQL1.Append(" @AUFECHACREACION ")

        Dim args1(19) As SqlParameter
        args1(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args1(0).Value = eDM.IDESTABLECIMIENTO
        args1(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args1(1).Value = eDM.IDTIPOTRANSACCION
        args1(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args1(2).Value = eDM.IDMOVIMIENTO
        args1(4) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args1(4).Value = eDM.IDALMACEN
        args1(5) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args1(5).Value = eL.IDLOTE
        args1(6) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args1(6).Value = eDM.IDPRODUCTO
        args1(7) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args1(7).Value = IIf(eDM.RENGLON = Nothing, DBNull.Value, eDM.RENGLON)
        args1(8) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args1(8).Value = eDM.CANTIDAD
        args1(9) = New SqlParameter("@CANTIDADRECHAZADA", SqlDbType.Decimal)
        args1(9).Value = IIf(eDM.CANTIDADRECHAZADA = Nothing, DBNull.Value, eDM.CANTIDADRECHAZADA)
        args1(10) = New SqlParameter("@CANTIDADANTERIOR", SqlDbType.Decimal)
        args1(10).Value = IIf(eDM.CANTIDADANTERIOR = Nothing, DBNull.Value, eDM.CANTIDADANTERIOR)
        args1(11) = New SqlParameter("@NUMEROFACTURA", SqlDbType.VarChar)
        args1(11).Value = IIf(eDM.NUMEROFACTURA = Nothing, DBNull.Value, eDM.NUMEROFACTURA)
        args1(12) = New SqlParameter("@FECHAFACTURA", SqlDbType.DateTime)
        args1(12).Value = IIf(eDM.FECHAFACTURA = Nothing, DBNull.Value, eDM.FECHAFACTURA)
        args1(13) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args1(13).Value = eDM.MONTO
        args1(14) = New SqlParameter("@NUMEROINFORMECONTROLCALIDAD", SqlDbType.VarChar)
        args1(14).Value = IIf(eDM.NUMEROINFORMECONTROLCALIDAD = Nothing, DBNull.Value, eDM.NUMEROINFORMECONTROLCALIDAD)
        args1(15) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.Int)
        args1(15).Value = eDM.IDDETALLEENTREGA
        args1(16) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args1(16).Value = IIf(eDM.AUUSUARIOCREACION = Nothing, DBNull.Value, eDM.AUUSUARIOCREACION)
        args1(17) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args1(17).Value = IIf(eDM.AUFECHACREACION = Nothing, DBNull.Value, eDM.AUFECHACREACION)
        args1(18) = New SqlParameter("@NOENVIO", SqlDbType.VarChar)
        args1(18).Value = IIf(eDM.NOENVIO = Nothing, DBNull.Value, eDM.NOENVIO)
        args1(19) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args1(19).Value = IIf(eDM.IDTIPODOCUMENTO = Nothing, DBNull.Value, eDM.IDTIPODOCUMENTO)

        Dim strSQL2 As New Text.StringBuilder
        strSQL2.Append("INSERT INTO SAB_ALM_UBICACIONESPRODUCTOS ")
        strSQL2.Append(" ( IDALMACEN, ")
        strSQL2.Append(" IDPRODUCTO, ")
        strSQL2.Append(" IDUBICACION, ")
        strSQL2.Append(" UBICACION, ")
        strSQL2.Append(" IDLOTE, ")
        strSQL2.Append(" AUUSUARIOCREACION, ")
        strSQL2.Append(" AUFECHACREACION) ")
        strSQL2.Append(" SELECT ")
        strSQL2.Append(" @IDALMACEN, ")
        strSQL2.Append(" @IDPRODUCTO, ")
        strSQL2.Append(" (SELECT isnull(max(IDUBICACION),0) + 1 ")
        strSQL2.Append(" FROM SAB_ALM_UBICACIONESPRODUCTOS ")
        strSQL2.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL2.Append(" AND IDPRODUCTO = @IDPRODUCTO), ")
        strSQL2.Append(" @UBICACION, ")
        strSQL2.Append(" @IDLOTE, ")
        strSQL2.Append(" @AUUSUARIOCREACION, ")
        strSQL2.Append(" @AUFECHACREACION ")

        Dim args2(6) As SqlParameter
        args2(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args2(0).Value = eU.IDALMACEN
        args2(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args2(1).Value = eU.IDPRODUCTO
        args2(2) = New SqlParameter("@IDUBICACION", SqlDbType.Int)
        args2(2).Value = eU.IDUBICACION
        args2(3) = New SqlParameter("@UBICACION", SqlDbType.VarChar)
        args2(3).Value = eU.UBICACION
        args2(4) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args2(4).Value = eL.IDLOTE
        args2(5) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args2(5).Value = IIf(eU.AUUSUARIOCREACION = Nothing, DBNull.Value, eU.AUUSUARIOCREACION)
        args2(6) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args2(6).Value = IIf(eU.AUFECHACREACION = Nothing, DBNull.Value, eU.AUFECHACREACION)

        Dim strSQL3 As New Text.StringBuilder
        strSQL3.Append("UPDATE SAB_UACI_ALMACENESENTREGACONTRATOS ")
        strSQL3.Append("SET CANTIDADENTREGADA = @CANTIDADENTREGADA, ")
        strSQL3.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL3.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL3.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL3.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL3.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL3.Append("AND RENGLON = @RENGLON ")
        strSQL3.Append("AND IDDETALLE = @IDDETALLE ")
        strSQL3.Append("AND IDALMACENENTREGA = @IDALMACENENTREGA ")
        strSQL3.Append("AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")

        ''ojo yo
        Dim args3(9) As SqlParameter
        args3(0) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.Decimal)
        args3(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args3(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args3(3) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args3(4) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args3(5) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args3(6) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args3(7) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args3(8) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args3(9) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        Dim resultado As Integer

        Using c As New SqlConnection(Me.cnnStr)

            c.Open()

            Dim t As SqlTransaction = c.BeginTransaction()

            Try

                If SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args) = 1 Then

                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args1)

                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL2.ToString, args2)

                    For Each eAEC As ALMACENESENTREGACONTRATOS In lAEC
                        args3(0).Value = eAEC.CANTIDADENTREGADA
                        args3(1).Value = IIf(eAEC.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eAEC.AUUSUARIOMODIFICACION)
                        args3(2).Value = IIf(eAEC.AUFECHAMODIFICACION = Nothing, DBNull.Value, eAEC.AUFECHAMODIFICACION)
                        args3(3).Value = eAEC.IDESTABLECIMIENTO
                        args3(4).Value = eAEC.IDPROVEEDOR
                        args3(5).Value = eAEC.IDCONTRATO
                        args3(6).Value = eAEC.RENGLON
                        args3(7).Value = eAEC.IDDETALLE
                        args3(8).Value = eAEC.IDALMACENENTREGA
                        args3(9).Value = eAEC.IDFUENTEFINANCIAMIENTO
                        SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL3.ToString, args3)
                    Next

                    t.Commit()

                    resultado = 1
                Else
                    t.Rollback()
                End If
            Catch ex As Exception
                t.Rollback()
                Throw
            Finally
                If Not t Is Nothing Then t.Dispose()
                If Not c.State = ConnectionState.Closed Then c.Close()
            End Try

        End Using

        Return resultado

    End Function

    'Public Function AgregarLoteDespacho(ByVal eL As LOTES, ByVal eDM As DETALLEMOVIMIENTOS, ByVal eU As UBICACIONESPRODUCTOS, ByVal lAEC As listaALMACENESENTREGACONTRATOS) As Integer

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("INSERT INTO SAB_ALM_LOTES ")
    '    strSQL.Append(" ( IDALMACEN, ")
    '    strSQL.Append(" IDLOTE, ")
    '    strSQL.Append(" IDPRODUCTO, ")
    '    strSQL.Append(" IDUNIDADMEDIDA, ")
    '    strSQL.Append(" CODIGO, ")
    '    strSQL.Append(" PRECIOLOTE, ")
    '    strSQL.Append(" FECHAVENCIMIENTO, ")
    '    strSQL.Append(" IDRESPONSABLEDISTRIBUCION, ")
    '    strSQL.Append(" IDESTABLECIMIENTO, ")
    '    strSQL.Append(" IDINFORMECONTROLCALIDAD, ")
    '    strSQL.Append(" NUMEROINFORMECONTROLCALIDAD, ")
    '    strSQL.Append(" FECHAINFORMECONTROLCALIDAD, ")
    '    strSQL.Append(" IDFUENTEFINANCIAMIENTO, ")
    '    strSQL.Append(" CANTIDADDISPONIBLE, ")
    '    strSQL.Append(" CANTIDADNODISPONIBLE, ")
    '    strSQL.Append(" CANTIDADVENCIDA, ")
    '    strSQL.Append(" CANTIDADRESERVADA, ")
    '    strSQL.Append(" CANTIDADTEMPORAL, ")
    '    strSQL.Append(" ESTADISPONIBLE, ")
    '    strSQL.Append(" IDALMACENORIGEN, ")
    '    strSQL.Append(" DETALLE, ")
    '    strSQL.Append(" AUUSUARIOCREACION, ")
    '    strSQL.Append(" AUFECHACREACION) ")
    '    strSQL.Append(" VALUES ")
    '    strSQL.Append(" ( @IDALMACEN, ")
    '    strSQL.Append(" (@IDLOTE), ")
    '    strSQL.Append(" @IDPRODUCTO, ")
    '    strSQL.Append(" @IDUNIDADMEDIDA, ")
    '    strSQL.Append(" @CODIGO, ")
    '    strSQL.Append(" @PRECIOLOTE, ")
    '    strSQL.Append(" @FECHAVENCIMIENTO, ")
    '    strSQL.Append(" @IDRESPONSABLEDISTRIBUCION, ")
    '    strSQL.Append(" @IDESTABLECIMIENTO, ")
    '    strSQL.Append(" @IDINFORMECONTROLCALIDAD, ")
    '    strSQL.Append(" @NUMEROINFORMECONTROLCALIDAD, ")
    '    strSQL.Append(" @FECHAINFORMECONTROLCALIDAD, ")
    '    strSQL.Append(" @IDFUENTEFINANCIAMIENTO, ")
    '    strSQL.Append(" @CANTIDADDISPONIBLE, ")
    '    strSQL.Append(" @CANTIDADNODISPONIBLE, ")
    '    strSQL.Append(" @CANTIDADVENCIDA, ")
    '    strSQL.Append(" @CANTIDADRESERVADA, ")
    '    strSQL.Append(" @CANTIDADTEMPORAL, ")
    '    strSQL.Append(" @ESTADISPONIBLE, ")
    '    strSQL.Append(" @IDALMACENORIGEN, ")
    '    strSQL.Append(" @DETALLE, ")
    '    strSQL.Append(" @AUUSUARIOCREACION, ")
    '    strSQL.Append(" @AUFECHACREACION) ")

    '    Dim args(22) As SqlParameter
    '    args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
    '    args(0).Value = eL.IDALMACEN
    '    args(1) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
    '    args(1).Value = eL.IDLOTE
    '    args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
    '    args(2).Value = eL.IDPRODUCTO
    '    args(3) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
    '    args(3).Value = eL.IDUNIDADMEDIDA
    '    args(4) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
    '    args(4).Value = IIf(eL.CODIGO = Nothing, DBNull.Value, eL.CODIGO)
    '    args(5) = New SqlParameter("@PRECIOLOTE", SqlDbType.Decimal)
    '    args(5).Value = eL.PRECIOLOTE
    '    args(6) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
    '    args(6).Value = IIf(eL.FECHAVENCIMIENTO = Nothing, DBNull.Value, eL.FECHAVENCIMIENTO)
    '    args(7) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
    '    args(7).Value = eL.IDRESPONSABLEDISTRIBUCION
    '    args(8) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(8).Value = IIf(eL.IDESTABLECIMIENTO = Nothing, DBNull.Value, eL.IDESTABLECIMIENTO)
    '    args(9) = New SqlParameter("@IDINFORMECONTROLCALIDAD", SqlDbType.Int)
    '    args(9).Value = IIf(eL.IDINFORMECONTROLCALIDAD = Nothing, DBNull.Value, eL.IDINFORMECONTROLCALIDAD)
    '    args(10) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
    '    args(10).Value = eL.IDFUENTEFINANCIAMIENTO
    '    args(11) = New SqlParameter("@CANTIDADDISPONIBLE", SqlDbType.Decimal)
    '    args(11).Value = eL.CANTIDADDISPONIBLE
    '    args(12) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.Decimal)
    '    args(12).Value = eL.CANTIDADNODISPONIBLE
    '    args(13) = New SqlParameter("@CANTIDADVENCIDA", SqlDbType.Decimal)
    '    args(13).Value = eL.CANTIDADVENCIDA
    '    args(14) = New SqlParameter("@CANTIDADRESERVADA", SqlDbType.Decimal)
    '    args(14).Value = eL.CANTIDADRESERVADA
    '    args(15) = New SqlParameter("@CANTIDADTEMPORAL", SqlDbType.Decimal)
    '    args(15).Value = eL.CANTIDADTEMPORAL
    '    args(16) = New SqlParameter("@ESTADISPONIBLE", SqlDbType.TinyInt)
    '    args(16).Value = eL.ESTADISPONIBLE
    '    args(17) = New SqlParameter("@IDALMACENORIGEN", SqlDbType.Int)
    '    args(17).Value = IIf(eL.IDALMACENORIGEN = Nothing, DBNull.Value, eL.IDALMACENORIGEN)
    '    args(18) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
    '    args(18).Value = IIf(eL.AUUSUARIOCREACION = Nothing, DBNull.Value, eL.AUUSUARIOCREACION)
    '    args(19) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
    '    args(19).Value = IIf(eL.AUFECHACREACION = Nothing, DBNull.Value, eL.AUFECHACREACION)
    '    args(20) = New SqlParameter("@NUMEROINFORMECONTROLCALIDAD", SqlDbType.VarChar)
    '    args(20).Value = IIf(eL.NUMEROINFORMECONTROLCALIDAD = Nothing, DBNull.Value, eL.NUMEROINFORMECONTROLCALIDAD)
    '    args(21) = New SqlParameter("@FECHAINFORMECONTROLCALIDAD", SqlDbType.DateTime)
    '    args(21).Value = IIf(eL.FECHAINFORMECONTROLCALIDAD = Nothing, DBNull.Value, eL.FECHAINFORMECONTROLCALIDAD)
    '    args(22) = New SqlParameter("@DETALLE", SqlDbType.VarChar)
    '    args(22).Value = IIf(eL.DETALLE = Nothing, DBNull.Value, eL.DETALLE)

    '    Dim strSQL1 As New Text.StringBuilder
    '    strSQL1.Append("INSERT INTO SAB_ALM_DETALLEMOVIMIENTOS ")
    '    strSQL1.Append(" ( IDESTABLECIMIENTO, ")
    '    strSQL1.Append(" IDTIPOTRANSACCION, ")
    '    strSQL1.Append(" IDMOVIMIENTO, ")
    '    strSQL1.Append(" IDDETALLEMOVIMIENTO, ")
    '    strSQL1.Append(" IDALMACEN, ")
    '    strSQL1.Append(" IDLOTE, ")
    '    strSQL1.Append(" IDPRODUCTO, ")
    '    strSQL1.Append(" RENGLON, ")
    '    strSQL1.Append(" CANTIDAD, ")
    '    strSQL1.Append(" CANTIDADRECHAZADA, ")
    '    strSQL1.Append(" CANTIDADANTERIOR, ")
    '    strSQL1.Append(" NUMEROFACTURA, ")
    '    strSQL1.Append(" NOENVIO, ")
    '    strSQL1.Append(" FECHAFACTURA, ")
    '    strSQL1.Append(" MONTO, ")
    '    strSQL1.Append(" NUMEROINFORMECONTROLCALIDAD, ")
    '    strSQL1.Append(" IDDETALLEENTREGA, ")
    '    strSQL1.Append(" IDTIPODOCUMENTO, ")
    '    strSQL1.Append(" AUUSUARIOCREACION, ")
    '    strSQL1.Append(" AUFECHACREACION) ")
    '    strSQL1.Append(" SELECT ")
    '    strSQL1.Append(" @IDESTABLECIMIENTO, ")
    '    strSQL1.Append(" @IDTIPOTRANSACCION, ")
    '    strSQL1.Append(" @IDMOVIMIENTO, ")
    '    strSQL1.Append(" (SELECT isnull(max(IDDETALLEMOVIMIENTO),0) + 1 ")
    '    strSQL1.Append(" FROM SAB_ALM_DETALLEMOVIMIENTOS ")
    '    strSQL1.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL1.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
    '    strSQL1.Append(" AND IDMOVIMIENTO = @IDMOVIMIENTO), ")
    '    strSQL1.Append(" @IDALMACEN, ")
    '    strSQL1.Append(" @IDLOTE, ")
    '    strSQL1.Append(" @IDPRODUCTO, ")
    '    strSQL1.Append(" @RENGLON, ")
    '    strSQL1.Append(" @CANTIDAD, ")
    '    strSQL1.Append(" @CANTIDADRECHAZADA, ")
    '    strSQL1.Append(" @CANTIDADANTERIOR, ")
    '    strSQL1.Append(" @NUMEROFACTURA, ")
    '    strSQL1.Append(" @NOENVIO, ")
    '    strSQL1.Append(" @FECHAFACTURA, ")
    '    strSQL1.Append(" @MONTO, ")
    '    strSQL1.Append(" @NUMEROINFORMECONTROLCALIDAD, ")
    '    strSQL1.Append(" @IDDETALLEENTREGA, ")
    '    strSQL1.Append(" @IDTIPODOCUMENTO, ")
    '    strSQL1.Append(" @AUUSUARIOCREACION, ")
    '    strSQL1.Append(" @AUFECHACREACION ")

    '    Dim args1(19) As SqlParameter
    '    args1(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args1(0).Value = eDM.IDESTABLECIMIENTO
    '    args1(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
    '    args1(1).Value = eDM.IDTIPOTRANSACCION
    '    args1(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
    '    args1(2).Value = eDM.IDMOVIMIENTO
    '    args1(4) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
    '    args1(4).Value = eDM.IDALMACEN
    '    args1(5) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
    '    args1(5).Value = eL.IDLOTE
    '    args1(6) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
    '    args1(6).Value = eDM.IDPRODUCTO
    '    args1(7) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
    '    args1(7).Value = IIf(eDM.RENGLON = Nothing, DBNull.Value, eDM.RENGLON)
    '    args1(8) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
    '    args1(8).Value = eDM.CANTIDAD
    '    args1(9) = New SqlParameter("@CANTIDADRECHAZADA", SqlDbType.Decimal)
    '    args1(9).Value = IIf(eDM.CANTIDADRECHAZADA = Nothing, DBNull.Value, eDM.CANTIDADRECHAZADA)
    '    args1(10) = New SqlParameter("@CANTIDADANTERIOR", SqlDbType.Decimal)
    '    args1(10).Value = IIf(eDM.CANTIDADANTERIOR = Nothing, DBNull.Value, eDM.CANTIDADANTERIOR)
    '    args1(11) = New SqlParameter("@NUMEROFACTURA", SqlDbType.VarChar)
    '    args1(11).Value = IIf(eDM.NUMEROFACTURA = Nothing, DBNull.Value, eDM.NUMEROFACTURA)
    '    args1(12) = New SqlParameter("@FECHAFACTURA", SqlDbType.DateTime)
    '    args1(12).Value = IIf(eDM.FECHAFACTURA = Nothing, DBNull.Value, eDM.FECHAFACTURA)
    '    args1(13) = New SqlParameter("@MONTO", SqlDbType.Decimal)
    '    args1(13).Value = eDM.MONTO
    '    args1(14) = New SqlParameter("@NUMEROINFORMECONTROLCALIDAD", SqlDbType.VarChar)
    '    args1(14).Value = IIf(eDM.NUMEROINFORMECONTROLCALIDAD = Nothing, DBNull.Value, eDM.NUMEROINFORMECONTROLCALIDAD)
    '    args1(15) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.Int)
    '    args1(15).Value = eDM.IDDETALLEENTREGA
    '    args1(16) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
    '    args1(16).Value = IIf(eDM.AUUSUARIOCREACION = Nothing, DBNull.Value, eDM.AUUSUARIOCREACION)
    '    args1(17) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
    '    args1(17).Value = IIf(eDM.AUFECHACREACION = Nothing, DBNull.Value, eDM.AUFECHACREACION)
    '    args1(18) = New SqlParameter("@NOENVIO", SqlDbType.VarChar)
    '    args1(18).Value = IIf(eDM.NOENVIO = Nothing, DBNull.Value, eDM.NOENVIO)
    '    args1(19) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
    '    args1(19).Value = IIf(eDM.IDTIPODOCUMENTO = Nothing, DBNull.Value, eDM.IDTIPODOCUMENTO)

    '    Dim strSQL2 As New Text.StringBuilder
    '    strSQL2.Append("INSERT INTO SAB_ALM_UBICACIONESPRODUCTOS ")
    '    strSQL2.Append(" ( IDALMACEN, ")
    '    strSQL2.Append(" IDPRODUCTO, ")
    '    strSQL2.Append(" IDUBICACION, ")
    '    strSQL2.Append(" UBICACION, ")
    '    strSQL2.Append(" IDLOTE, ")
    '    strSQL2.Append(" AUUSUARIOCREACION, ")
    '    strSQL2.Append(" AUFECHACREACION) ")
    '    strSQL2.Append(" SELECT ")
    '    strSQL2.Append(" @IDALMACEN, ")
    '    strSQL2.Append(" @IDPRODUCTO, ")
    '    strSQL2.Append(" (SELECT isnull(max(IDUBICACION),0) + 1 ")
    '    strSQL2.Append(" FROM SAB_ALM_UBICACIONESPRODUCTOS ")
    '    strSQL2.Append(" WHERE IDALMACEN = @IDALMACEN ")
    '    strSQL2.Append(" AND IDPRODUCTO = @IDPRODUCTO), ")
    '    strSQL2.Append(" @UBICACION, ")
    '    strSQL2.Append(" @IDLOTE, ")
    '    strSQL2.Append(" @AUUSUARIOCREACION, ")
    '    strSQL2.Append(" @AUFECHACREACION ")

    '    Dim args2(6) As SqlParameter
    '    args2(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
    '    args2(0).Value = eU.IDALMACEN
    '    args2(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
    '    args2(1).Value = eU.IDPRODUCTO
    '    args2(2) = New SqlParameter("@IDUBICACION", SqlDbType.Int)
    '    args2(2).Value = eU.IDUBICACION
    '    args2(3) = New SqlParameter("@UBICACION", SqlDbType.VarChar)
    '    args2(3).Value = eU.UBICACION
    '    args2(4) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
    '    args2(4).Value = eL.IDLOTE
    '    args2(5) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
    '    args2(5).Value = IIf(eU.AUUSUARIOCREACION = Nothing, DBNull.Value, eU.AUUSUARIOCREACION)
    '    args2(6) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
    '    args2(6).Value = IIf(eU.AUFECHACREACION = Nothing, DBNull.Value, eU.AUFECHACREACION)

    '    Dim strSQL3 As New Text.StringBuilder
    '    strSQL3.Append("UPDATE SAB_UACI_ALMACENESENTREGACONTRATOS ")
    '    strSQL3.Append("SET CANTIDADENTREGADA = @CANTIDADENTREGADA, ")
    '    strSQL3.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
    '    strSQL3.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
    '    strSQL3.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL3.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
    '    strSQL3.Append("AND IDCONTRATO = @IDCONTRATO ")
    '    strSQL3.Append("AND RENGLON = @RENGLON ")
    '    strSQL3.Append("AND IDDETALLE = @IDDETALLE ")
    '    strSQL3.Append("AND IDALMACENENTREGA = @IDALMACENENTREGA ")

    '    Dim args3(8) As SqlParameter
    '    args3(0) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.Decimal)
    '    args3(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
    '    args3(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
    '    args3(3) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args3(4) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
    '    args3(5) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
    '    args3(6) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
    '    args3(7) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
    '    args3(8) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)

    '    Dim resultado As Integer

    '    Using c As New SqlConnection(Me.cnnStr)

    '        c.Open()

    '        Dim t As SqlTransaction = c.BeginTransaction()

    '        Try

    '            If SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args) = 1 Then

    '                SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args1)

    '                SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL2.ToString, args2)

    '                For Each eAEC As ALMACENESENTREGACONTRATOS In lAEC
    '                    args3(0).Value = eAEC.CANTIDADENTREGADA
    '                    args3(1).Value = IIf(eAEC.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eAEC.AUUSUARIOMODIFICACION)
    '                    args3(2).Value = IIf(eAEC.AUFECHAMODIFICACION = Nothing, DBNull.Value, eAEC.AUFECHAMODIFICACION)
    '                    args3(3).Value = eAEC.IDESTABLECIMIENTO
    '                    args3(4).Value = eAEC.IDPROVEEDOR
    '                    args3(5).Value = eAEC.IDCONTRATO
    '                    args3(6).Value = eAEC.RENGLON
    '                    args3(7).Value = eAEC.IDDETALLE
    '                    args3(8).Value = eAEC.IDALMACENENTREGA

    '                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL3.ToString, args3)
    '                Next

    '                t.Commit()

    '                resultado = 1
    '            Else
    '                t.Rollback()
    '            End If
    '        Catch ex As Exception
    '            t.Rollback()
    '            Throw
    '        Finally
    '            If c.State = ConnectionState.Open Then c.Close()
    '        End Try

    '    End Using

    '    Return resultado

    'End Function
    ''' <summary>
    ''' Eliminar un lote en la recepcion
    ''' </summary>
    ''' <param name="eDM">Identificador de la entidad detalle movimientos</param>
    ''' <param name="lAEC">Identificador de la lista de almacenes entrega contratos</param>
    ''' <returns>Valor entero con el resultado</returns>

    Public Function EliminarLoteRecepcion(ByVal eDM As DETALLEMOVIMIENTOS, ByVal lAEC As listaALMACENESENTREGACONTRATOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_UBICACIONESPRODUCTOS ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDLOTE = @IDLOTE ")

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("DELETE FROM SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL1.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL1.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL1.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL1.Append("AND IDDETALLEMOVIMIENTO = @IDDETALLEMOVIMIENTO ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = eDM.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = eDM.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = eDM.IDMOVIMIENTO
        args(3) = New SqlParameter("@IDDETALLEMOVIMIENTO", SqlDbType.BigInt)
        args(3).Value = eDM.IDDETALLEMOVIMIENTO
        args(4) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(4).Value = eDM.IDPRODUCTO
        args(5) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(5).Value = eDM.IDALMACEN
        args(6) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(6).Value = eDM.IDLOTE

        Dim strSQL2 As New Text.StringBuilder
        strSQL2.Append("DELETE FROM SAB_ALM_LOTES ")
        strSQL2.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL2.Append("AND IDLOTE = @IDLOTE ")

        Dim strSQL3 As New Text.StringBuilder
        strSQL3.Append("UPDATE SAB_UACI_ALMACENESENTREGACONTRATOS ")
        strSQL3.Append("SET CANTIDADENTREGADA = @CANTIDADENTREGADA, ")
        strSQL3.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL3.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL3.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL3.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL3.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL3.Append("AND RENGLON = @RENGLON ")
        strSQL3.Append("AND IDDETALLE = @IDDETALLE ")
        strSQL3.Append("AND IDALMACENENTREGA = @IDALMACENENTREGA ")
        strSQL3.Append("AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")


        Dim args3(9) As SqlParameter
        args3(0) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.Decimal)
        args3(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args3(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args3(3) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args3(4) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args3(5) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args3(6) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args3(7) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args3(8) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args3(9) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)

        Using c As New SqlConnection(Me.cnnStr)

            c.Open()

            Dim t As SqlTransaction = c.BeginTransaction()

            Try
                Dim regmod As Integer

                regmod = SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args)

                regmod = SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args)

                regmod = SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL2.ToString, args)

                For Each eAEC As ALMACENESENTREGACONTRATOS In lAEC
                    args3(0).Value = eAEC.CANTIDADENTREGADA
                    args3(1).Value = IIf(eAEC.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eAEC.AUUSUARIOMODIFICACION)
                    args3(2).Value = IIf(eAEC.AUFECHAMODIFICACION = Nothing, DBNull.Value, eAEC.AUFECHAMODIFICACION)
                    args3(3).Value = eAEC.IDESTABLECIMIENTO
                    args3(4).Value = eAEC.IDPROVEEDOR
                    args3(5).Value = eAEC.IDCONTRATO
                    args3(6).Value = eAEC.RENGLON
                    args3(7).Value = eAEC.IDDETALLE
                    args3(8).Value = eAEC.IDALMACENENTREGA
                    args3(9).Value = eAEC.IDFUENTEFINANCIAMIENTO


                    regmod = SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL3.ToString, args3)
                Next

                t.Commit()

            Catch ex As Exception
                t.Rollback()
                Throw
            Finally
                If Not t Is Nothing Then t.Dispose()
                If Not c.State = ConnectionState.Closed Then c.Close()
            End Try

        End Using

    End Function

    ''' <summary>
    ''' Eliminar un lote del despacho de productos
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad con el detalle del movimiento</param>
    ''' <param name="OPERACIONCANTIDADDISPONIBLE">Identificador de la cantidad disponible</param>
    ''' <param name="OPERACIONCANTIDADNODISPONIBLE">Identificador de la cantidad no disponible</param>
    ''' <param name="OPERACIONCANTIDADRESERVADA">Identificador de la cantidad reservada</param>
    ''' <param name="OPERACIONCANTIDADVENCIDA">Identificador de la cantidad vencida</param>
    ''' <param name="OPERACIONCANTIDADTEMPORAL">Identificador de la cantidad temporal</param>
    ''' <returns>valor entero con el resultado</returns>
    Public Function EliminarLoteDespacho(ByVal aEntidad As DETALLEMOVIMIENTOS, Optional ByVal OPERACIONCANTIDADDISPONIBLE As Int16 = 0, Optional ByVal OPERACIONCANTIDADNODISPONIBLE As Int16 = 0, Optional ByVal OPERACIONCANTIDADRESERVADA As Int16 = 0, Optional ByVal OPERACIONCANTIDADVENCIDA As Int16 = 0, Optional ByVal OPERACIONCANTIDADTEMPORAL As Int16 = 0) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND IDDETALLEMOVIMIENTO = @IDDETALLEMOVIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = aEntidad.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDMOVIMIENTO
        args(3) = New SqlParameter("@IDDETALLEMOVIMIENTO", SqlDbType.BigInt)
        args(3).Value = aEntidad.IDDETALLEMOVIMIENTO

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("UPDATE SAB_ALM_LOTES ")
        strSQL1.Append("SET CANTIDADDISPONIBLE = ")
        strSQL1.Append("CASE ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADDISPONIBLE = 1 THEN CANTIDADDISPONIBLE + @CANTIDAD ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADDISPONIBLE = 2 THEN CANTIDADDISPONIBLE - @CANTIDAD ")
        strSQL1.Append("ELSE CANTIDADDISPONIBLE ")
        strSQL1.Append("END, ")
        strSQL1.Append("CANTIDADNODISPONIBLE = ")
        strSQL1.Append("CASE ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADNODISPONIBLE = 1 THEN CANTIDADNODISPONIBLE + @CANTIDAD ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADNODISPONIBLE = 2 THEN CANTIDADNODISPONIBLE - @CANTIDAD ")
        strSQL1.Append("ELSE CANTIDADNODISPONIBLE ")
        strSQL1.Append("END, ")
        strSQL1.Append("CANTIDADRESERVADA = ")
        strSQL1.Append("CASE ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADRESERVADA = 1 THEN CANTIDADRESERVADA + @CANTIDAD ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADRESERVADA = 2 THEN CANTIDADRESERVADA - @CANTIDAD ")
        strSQL1.Append("ELSE CANTIDADRESERVADA ")
        strSQL1.Append("END, ")
        strSQL1.Append("CANTIDADVENCIDA = ")
        strSQL1.Append("CASE ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADVENCIDA = 1 THEN CANTIDADVENCIDA + @CANTIDAD ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADVENCIDA = 2 THEN CANTIDADVENCIDA - @CANTIDAD ")
        strSQL1.Append("ELSE CANTIDADVENCIDA ")
        strSQL1.Append("END, ")
        strSQL1.Append("CANTIDADTEMPORAL = ")
        strSQL1.Append("CASE ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADTEMPORAL = 1 THEN CANTIDADTEMPORAL + @CANTIDAD ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADTEMPORAL = 2 THEN CANTIDADTEMPORAL - @CANTIDAD ")
        strSQL1.Append("ELSE CANTIDADTEMPORAL ")
        strSQL1.Append("END, ")
        strSQL1.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL1.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL1.Append("WHERE IDALMACEN = @IDALMACEN AND IDLOTE = @IDLOTE ")
        strSQL1.Append("AND ((CANTIDADDISPONIBLE >= @CANTIDAD AND @OPERACIONCANTIDADDISPONIBLE = 2) OR @OPERACIONCANTIDADDISPONIBLE = 1 OR @OPERACIONCANTIDADDISPONIBLE IS NULL) ")
        strSQL1.Append("AND ((CANTIDADNODISPONIBLE >= @CANTIDAD AND @OPERACIONCANTIDADNODISPONIBLE = 2) OR @OPERACIONCANTIDADNODISPONIBLE = 1 OR @OPERACIONCANTIDADNODISPONIBLE IS NULL) ")
        strSQL1.Append("AND ((CANTIDADRESERVADA >= @CANTIDAD AND @OPERACIONCANTIDADRESERVADA = 2) OR @OPERACIONCANTIDADRESERVADA = 1 OR @OPERACIONCANTIDADRESERVADA IS NULL) ")
        strSQL1.Append("AND ((CANTIDADVENCIDA >= @CANTIDAD AND @OPERACIONCANTIDADVENCIDA = 2) OR @OPERACIONCANTIDADVENCIDA = 1 OR @OPERACIONCANTIDADVENCIDA IS NULL) ")
        strSQL1.Append("AND ((CANTIDADTEMPORAL >= @CANTIDAD AND @OPERACIONCANTIDADTEMPORAL = 2) OR @OPERACIONCANTIDADTEMPORAL = 1 OR @OPERACIONCANTIDADTEMPORAL IS NULL) ")

        Dim args1(9) As SqlParameter
        args1(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args1(0).Value = aEntidad.IDALMACEN
        args1(1) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args1(1).Value = aEntidad.IDLOTE
        args1(2) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args1(2).Value = aEntidad.CANTIDAD
        args1(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args1(3).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args1(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args1(4).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args1(5) = New SqlParameter("@OPERACIONCANTIDADDISPONIBLE", SqlDbType.TinyInt)
        args1(5).Value = IIf(OPERACIONCANTIDADDISPONIBLE = 0, Nothing, OPERACIONCANTIDADDISPONIBLE)
        args1(6) = New SqlParameter("@OPERACIONCANTIDADNODISPONIBLE", SqlDbType.TinyInt)
        args1(6).Value = IIf(OPERACIONCANTIDADNODISPONIBLE = 0, Nothing, OPERACIONCANTIDADNODISPONIBLE)
        args1(7) = New SqlParameter("@OPERACIONCANTIDADRESERVADA", SqlDbType.TinyInt)
        args1(7).Value = IIf(OPERACIONCANTIDADRESERVADA = 0, Nothing, OPERACIONCANTIDADRESERVADA)
        args1(8) = New SqlParameter("@OPERACIONCANTIDADVENCIDA", SqlDbType.TinyInt)
        args1(8).Value = IIf(OPERACIONCANTIDADVENCIDA = 0, Nothing, OPERACIONCANTIDADVENCIDA)
        args1(9) = New SqlParameter("@OPERACIONCANTIDADTEMPORAL", SqlDbType.TinyInt)
        args1(9).Value = IIf(OPERACIONCANTIDADTEMPORAL = 0, Nothing, OPERACIONCANTIDADTEMPORAL)

        Dim resultado As Integer

        Using c As New SqlConnection(Me.cnnStr)

            c.Open()

            Dim t As SqlTransaction = c.BeginTransaction()

            Try

                If SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args) = 1 Then

                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args1)

                    t.Commit()

                    resultado = 1
                Else
                    t.Rollback()
                End If
            Catch ex As Exception
                t.Rollback()
                Throw
            Finally
                If Not t Is Nothing Then t.Dispose()
                If Not c.State = ConnectionState.Closed Then c.Close()
            End Try

        End Using

        Return resultado

    End Function

    ''' <summary>
    ''' Actualizacion del estado de un recibo de recepcion
    ''' </summary>
    ''' <param name="eM">identificador de la entidad de movimientos</param>
    ''' <param name="eRR">identificador de los recibos de recepcion</param>
    ''' <returns>Valor entero con el resultado</returns>
    Public Function CerrarRecepcion(ByVal eM As MOVIMIENTOS, ByVal eRR As RECIBOSRECEPCION) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_ALM_MOVIMIENTOS ")
        strSQL.Append("SET ")
        strSQL.Append("IDESTADO = @IDESTADO, ")
        strSQL.Append("FECHAMOVIMIENTO = @FECHAMOVIMIENTO, ")
        strSQL.Append("IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO, ")
        strSQL.Append("IDALMACENDESTINO = @IDALMACENDESTINO, ")
        strSQL.Append("IDEMPLEADOALMACEN = @IDEMPLEADOALMACEN, ")
        strSQL.Append("EMPLEADOALMACEN = @EMPLEADOALMACEN, ")
        strSQL.Append("IDEMPLEADODESPACHA = @IDEMPLEADODESPACHA, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = 2")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND IDESTADO = 1 ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(0).Value = eM.IDESTADO
        args(1) = New SqlParameter("@FECHAMOVIMIENTO", SqlDbType.DateTime)
        args(1).Value = IIf(eM.FECHAMOVIMIENTO = Nothing, DBNull.Value, eM.FECHAMOVIMIENTO)
        args(2) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.Int)
        args(2).Value = IIf(eM.IDESTABLECIMIENTODESTINO = Nothing, DBNull.Value, eM.IDESTABLECIMIENTODESTINO)
        args(3) = New SqlParameter("@IDALMACENDESTINO", SqlDbType.Int)
        args(3).Value = IIf(eM.IDALMACENDESTINO = Nothing, DBNull.Value, eM.IDALMACENDESTINO)
        args(4) = New SqlParameter("@IDEMPLEADOALMACEN", SqlDbType.Int)
        args(4).Value = IIf(eM.IDEMPLEADOALMACEN = Nothing, DBNull.Value, eM.IDEMPLEADOALMACEN)
        args(5) = New SqlParameter("@EMPLEADOALMACEN", SqlDbType.VarChar)
        args(5).Value = IIf(eM.EMPLEADOALMACEN = Nothing, DBNull.Value, eM.EMPLEADOALMACEN)
        args(6) = New SqlParameter("@IDEMPLEADODESPACHA", SqlDbType.Int)
        args(6).Value = IIf(eM.IDEMPLEADODESPACHA = Nothing, DBNull.Value, eM.IDEMPLEADODESPACHA)
        args(7) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(7).Value = IIf(eM.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eM.AUUSUARIOMODIFICACION)
        args(8) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(8).Value = IIf(eM.AUFECHAMODIFICACION = Nothing, DBNull.Value, eM.AUFECHAMODIFICACION)
        args(9) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(9).Value = eM.ESTASINCRONIZADA
        args(10) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(10).Value = eM.IDESTABLECIMIENTO
        args(11) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(11).Value = eM.IDTIPOTRANSACCION
        args(12) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(12).Value = eM.IDMOVIMIENTO

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("UPDATE SAB_ALM_VALESSALIDA ")
        strSQL1.Append(" SET TRANSPORTISTA = @TRANSPORTISTA, ")
        strSQL1.Append(" MATRICULAVEHICULO = @MATRICULAVEHICULO, ")
        strSQL1.Append(" PERSONARECIBE = @PERSONARECIBE, ")
        strSQL1.Append(" IDTIPOIDENTIFICACION = @IDTIPOIDENTIFICACION, ")
        strSQL1.Append(" NUMEROIDENTIFICACION = @NUMEROIDENTIFICACION, ")
        strSQL1.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL1.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL1.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL1.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL1.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSQL1.Append("INNER JOIN SAB_ALM_VALESSALIDA VS ")
        strSQL1.Append("ON VS.IDALMACEN = M.IDALMACEN ")
        strSQL1.Append("AND VS.ANIO = M.ANIO ")
        strSQL1.Append("AND VS.IDVALE = M.IDDOCUMENTO ")
        strSQL1.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL1.Append("AND M.IDTIPOTRANSACCION = 2")
        strSQL1.Append("AND M.IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args1(13) As SqlParameter
        'args1(0) = New SqlParameter("@TRANSPORTISTA", SqlDbType.VarChar)
        'args1(0).Value = IIf(eVS.TRANSPORTISTA = Nothing, DBNull.Value, eVS.TRANSPORTISTA)
        'args1(1) = New SqlParameter("@MATRICULAVEHICULO", SqlDbType.VarChar)
        'args1(1).Value = IIf(eVS.MATRICULAVEHICULO = Nothing, DBNull.Value, eVS.MATRICULAVEHICULO)
        'args1(2) = New SqlParameter("@PERSONARECIBE", SqlDbType.VarChar)
        'args1(2).Value = IIf(eVS.PERSONARECIBE = Nothing, DBNull.Value, eVS.PERSONARECIBE)
        'args1(3) = New SqlParameter("@IDTIPOIDENTIFICACION", SqlDbType.SmallInt)
        'args1(3).Value = IIf(eVS.IDTIPOIDENTIFICACION = Nothing, DBNull.Value, eVS.IDTIPOIDENTIFICACION)
        'args1(4) = New SqlParameter("@NUMEROIDENTIFICACION", SqlDbType.VarChar)
        'args1(4).Value = IIf(eVS.NUMEROIDENTIFICACION = Nothing, DBNull.Value, eVS.NUMEROIDENTIFICACION)
        'args1(5) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        'args1(5).Value = IIf(eVS.OBSERVACION = Nothing, DBNull.Value, eVS.OBSERVACION)
        'args1(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        'args1(6).Value = IIf(eVS.AUUSUARIOCREACION = Nothing, DBNull.Value, eVS.AUUSUARIOCREACION)
        'args1(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        'args1(7).Value = IIf(eVS.AUFECHACREACION = Nothing, DBNull.Value, eVS.AUFECHACREACION)
        'args1(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        'args1(8).Value = IIf(eVS.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eVS.AUUSUARIOMODIFICACION)
        'args1(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        'args1(9).Value = IIf(eVS.AUFECHAMODIFICACION = Nothing, DBNull.Value, eVS.AUFECHAMODIFICACION)
        'args1(10) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        'args1(10).Value = eVS.ESTASINCRONIZADA
        'args1(11) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        'args1(11).Value = eM.IDESTABLECIMIENTO
        'args1(12) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        'args1(12).Value = eM.IDTIPOTRANSACCION
        'args1(13) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        'args1(13).Value = eM.IDMOVIMIENTO

        Dim strSQL2 As New Text.StringBuilder
        strSQL2.Append("UPDATE SAB_ALM_LOTES ")
        strSQL2.Append("SET ESTADISPONIBLE = 1, ")
        strSQL2.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL2.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL2.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL2.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL2.Append("ON DM.IDALMACEN = L.IDALMACEN ")
        strSQL2.Append("AND DM.IDLOTE = L.IDLOTE ")
        strSQL2.Append("WHERE DM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL2.Append("AND DM.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL2.Append("AND DM.IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim resultado As Integer

        Using c As New SqlConnection(Me.cnnStr)

            c.Open()

            Dim t As SqlTransaction = c.BeginTransaction()

            Try

                If SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args) = 1 Then

                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args1)

                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL2.ToString, args)

                    t.Commit()

                    resultado = 1
                Else
                    t.Rollback()
                End If
            Catch ex As Exception
                t.Rollback()
                Throw
            Finally
                If Not t Is Nothing Then t.Dispose()
                If Not c.State = ConnectionState.Closed Then c.Close()
            End Try

        End Using

        Return resultado

    End Function

    ''' <summary>
    ''' Actualizacion para cerrar un despacho
    ''' </summary>
    ''' <param name="eM">Identificador de la entidad movimientos</param>
    ''' <param name="eVS">Identificador de la entidad vale de salida</param>
    ''' <returns>Valor entero con el resultado</returns>
    Public Function CerrarDespacho(ByVal eM As MOVIMIENTOS, ByVal eVS As VALESSALIDA, ByVal esFarmacia As Boolean) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_ALM_MOVIMIENTOS ")
        strSQL.Append("SET ")
        strSQL.Append("IDESTADO = 2, ")
        strSQL.Append("FECHAMOVIMIENTO = @FECHAMOVIMIENTO, ")
        strSQL.Append("IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO, ")
        strSQL.Append("IDALMACENDESTINO = @IDALMACENDESTINO, ")
        strSQL.Append("ID_LUGAR_ENTREGA_HOSPITAL = @ID_LUGAR_ENTREGA_HOSPITAL, ")
        strSQL.Append("IDEMPLEADOALMACEN = @IDEMPLEADOALMACEN, ")
        strSQL.Append("EMPLEADOALMACEN = @EMPLEADOALMACEN, ")
        strSQL.Append("IDEMPLEADODESPACHA = @IDEMPLEADODESPACHA, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = 2")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND IDESTADO = 1 ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@FECHAMOVIMIENTO", SqlDbType.DateTime)
        args(0).Value = IIf(eM.FECHAMOVIMIENTO = Nothing, DBNull.Value, eM.FECHAMOVIMIENTO)
        args(1) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.Int)
        args(1).Value = IIf(eM.IDESTABLECIMIENTODESTINO = Nothing, DBNull.Value, eM.IDESTABLECIMIENTODESTINO)
        args(2) = New SqlParameter("@IDALMACENDESTINO", SqlDbType.Int)
        args(2).Value = IIf(eM.IDALMACENDESTINO = Nothing, DBNull.Value, eM.IDALMACENDESTINO)
        args(3) = New SqlParameter("@IDEMPLEADOALMACEN", SqlDbType.Int)
        args(3).Value = IIf(eM.IDEMPLEADOALMACEN = Nothing, DBNull.Value, eM.IDEMPLEADOALMACEN)
        args(4) = New SqlParameter("@EMPLEADOALMACEN", SqlDbType.VarChar)
        args(4).Value = IIf(eM.EMPLEADOALMACEN = Nothing, DBNull.Value, eM.EMPLEADOALMACEN)
        args(5) = New SqlParameter("@IDEMPLEADODESPACHA", SqlDbType.Int)
        args(5).Value = IIf(eM.IDEMPLEADODESPACHA = Nothing, DBNull.Value, eM.IDEMPLEADODESPACHA)
        args(6) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(6).Value = IIf(eM.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eM.AUUSUARIOMODIFICACION)
        args(7) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(7).Value = IIf(eM.AUFECHAMODIFICACION = Nothing, DBNull.Value, eM.AUFECHAMODIFICACION)
        args(8) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(8).Value = eM.ESTASINCRONIZADA
        args(9) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(9).Value = eM.IDESTABLECIMIENTO
        args(10) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(10).Value = eM.IDTIPOTRANSACCION
        args(11) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(11).Value = eM.IDMOVIMIENTO
        args(12) = New SqlParameter("@ID_LUGAR_ENTREGA_HOSPITAL", SqlDbType.Int)
        args(12).Value = IIf(eM.ID_LUGAR_ENTREGA_HOSPITAL = Nothing, DBNull.Value, eM.ID_LUGAR_ENTREGA_HOSPITAL)

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("UPDATE SAB_ALM_VALESSALIDA ")
        strSQL1.Append("SET TRANSPORTISTA = @TRANSPORTISTA, ")
        strSQL1.Append("MATRICULAVEHICULO = @MATRICULAVEHICULO, ")
        strSQL1.Append("PERSONARECIBE = @PERSONARECIBE, ")
        strSQL1.Append("IDTIPOIDENTIFICACION = @IDTIPOIDENTIFICACION, ")
        strSQL1.Append("NUMEROIDENTIFICACION = @NUMEROIDENTIFICACION, ")
        strSQL1.Append("OBSERVACION = @OBSERVACION, ")
        strSQL1.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL1.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL1.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL1.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSQL1.Append("INNER JOIN SAB_ALM_VALESSALIDA VS ")
        strSQL1.Append("ON VS.IDALMACEN = M.IDALMACEN ")
        strSQL1.Append("AND VS.ANIO = M.ANIO ")
        strSQL1.Append("AND VS.IDVALE = M.IDDOCUMENTO ")
        strSQL1.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL1.Append("AND M.IDTIPOTRANSACCION = 2")
        strSQL1.Append("AND M.IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args1(13) As SqlParameter
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
        args1(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args1(6).Value = IIf(eVS.AUUSUARIOCREACION = Nothing, DBNull.Value, eVS.AUUSUARIOCREACION)
        args1(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args1(7).Value = IIf(eVS.AUFECHACREACION = Nothing, DBNull.Value, eVS.AUFECHACREACION)
        args1(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args1(8).Value = IIf(eVS.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eVS.AUUSUARIOMODIFICACION)
        args1(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args1(9).Value = IIf(eVS.AUFECHAMODIFICACION = Nothing, DBNull.Value, eVS.AUFECHAMODIFICACION)
        args1(10) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args1(10).Value = eVS.ESTASINCRONIZADA
        args1(11) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args1(11).Value = eM.IDESTABLECIMIENTO
        args1(12) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args1(12).Value = eM.IDTIPOTRANSACCION
        args1(13) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args1(13).Value = eM.IDMOVIMIENTO

        Dim strSQL2 As New Text.StringBuilder
        strSQL2.Append("UPDATE SAB_ALM_LOTES ")
        strSQL2.Append("SET CANTIDADRESERVADA = CANTIDADRESERVADA - DM.CANTIDAD, ")
        strSQL2.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL2.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL2.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL2.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL2.Append("ON DM.IDALMACEN = L.IDALMACEN ")
        strSQL2.Append("AND DM.IDLOTE = L.IDLOTE ")
        strSQL2.Append("WHERE DM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL2.Append("AND DM.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL2.Append("AND DM.IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim strSqlUreg As New Text.StringBuilder
        strSqlUreg.Append("SELECT  EM.IDEMPLEADO ")
        strSqlUreg.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSqlUreg.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ON M.AUUSUARIOCREACION = EM.NOMBRECORTO ")
        strSqlUreg.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND M.IDMOVIMIENTO = @IDMOVIMIENTO AND M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim strSqlUmod As New Text.StringBuilder
        strSqlUmod.Append("SELECT  EM.IDEMPLEADO ")
        strSqlUmod.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSqlUmod.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ON M.AUUSUARIOMODIFICACION = EM.NOMBRECORTO ")
        strSqlUmod.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND M.IDMOVIMIENTO = @IDMOVIMIENTO AND M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim argsU(2) As SqlParameter
        argsU(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        argsU(0).Value = eM.IDESTABLECIMIENTO
        argsU(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        argsU(1).Value = eM.IDTIPOTRANSACCION
        argsU(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        argsU(2).Value = eM.IDMOVIMIENTO

        Dim argsUm(2) As SqlParameter
        argsUm(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        argsUm(0).Value = eM.IDESTABLECIMIENTO
        argsUm(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        argsUm(1).Value = eM.IDTIPOTRANSACCION
        argsUm(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        argsUm(2).Value = eM.IDMOVIMIENTO

        'RECUPERA REGISTROS PARA EXISTENCIAS ________________________________________________
        'PARAMETROS
        Dim args3(2) As SqlParameter
        args3(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args3(0).Value = eM.IDESTABLECIMIENTO
        args3(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args3(1).Value = eM.IDTIPOTRANSACCION
        args3(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args3(2).Value = eM.IDMOVIMIENTO
        'CONSULTA
        Dim strSQL3 As New Text.StringBuilder
        strSQL3.Append("SELECT CONVERT(VARCHAR, VS.IDVALE) + '/' + CONVERT(VARCHAR, VS.ANIO) NUMEROVALE, CP.IDSUMINISTRO, AL.ESFARMACIA, ")
        strSQL3.Append("M.AUUSUARIOCREACION, M.AUUSUARIOMODIFICACION, ")
        strSQL3.Append("L.CODIGO Lote, CP.CORRPRODUCTO Codigo,  L.PRECIOLOTE Precio,  ")
        strSQL3.Append("DM.CANTIDAD Cantidad, L.FECHAVENCIMIENTO, L.IDFUENTEFINANCIAMIENTO FuenteFinanciamiento, M.AUFECHACREACION, M.AUFECHAMODIFICACION ")
        strSQL3.Append("FROM SAB_ALM_MOVIMIENTOS M  ")
        strSQL3.Append("LEFT JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO  ")
        strSQL3.Append("LEFT JOIN SAB_ALM_LOTES L ON DM.IDALMACEN = L.IDALMACEN AND DM.IDLOTE = L.IDLOTE  ")
        strSQL3.Append("LEFT JOIN SAB_ALM_VALESSALIDA VS ON M.IDALMACEN = VS.IDALMACEN AND M.IDDOCUMENTO = VS.IDVALE AND M.ANIO = VS.ANIO  ")
        strSQL3.Append("LEFT JOIN vv_CATALOGOPRODUCTOS CP ON DM.IDPRODUCTO = CP.IDPRODUCTO   ")
        If esFarmacia Then
            strSQL3.Append("LEFT JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE on M.IDESTABLECIMIENTO = AE.IDESTABLECIMIENTO ")
            strSQL3.Append("LEFT JOIN SAB_CAT_ALMACENES AL on AE.IDALMACEN = AL.IDALMACEN ")
            strSQL3.Append("WHERE(M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO And M.IDMOVIMIENTO = @IDMOVIMIENTO And M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION AND AL.ESFARMACIA = 1) ")
        Else
            strSQL3.Append("LEFT JOIN SAB_CAT_ALMACENES AL ON M.IDALMACEN = AL.IDALMACEN ")
            strSQL3.Append("WHERE(M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO And M.IDMOVIMIENTO = @IDMOVIMIENTO And M.IDTIPOTRANSACCION = @IDTIPOTRANSACCION) ")
        End If


        Dim resultado As Integer

        'Dim dat As DataTable

        Using conmod As New SqlConnection(Me.cnnStr)
            conmod.Open()
            Using getMod As New SqlCommand(strSqlUmod.ToString, conmod)
                getMod.Parameters.AddRange(argsUm)

            End Using

            Using getReg As New SqlCommand(strSqlUreg.ToString, conmod)
                getReg.Parameters.AddRange(argsU)

            End Using
        End Using

        'RECUPERA LOS REGISTROS DE EXISTENCIAS DEL MOVIMIENTO




        Using c As New SqlConnection(Me.cnnStr)

            c.Open()
            Dim t As SqlTransaction = c.BeginTransaction()

            Try

                If SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args) = 1 Then
                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args1)
                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL2.ToString, args)
                    SqlHelper.ExecuteDataset(t, CommandType.Text, strSQL3.ToString(), args3)
                    t.Commit()
                    resultado = 1
                Else
                    t.Rollback()
                End If
            Catch ex As Exception
                t.Rollback()
                Throw
            Finally
                If Not t Is Nothing Then t.Dispose()
                If Not c.State = ConnectionState.Closed Then c.Close()
            End Try

        End Using

        Return resultado

    End Function

    ''' <summary>
    ''' Actualizacion para cerrar un despacho
    ''' </summary>
    ''' <param name="eM">Identificador de la entidad de movimientos</param>
    ''' <returns>Valor entero con el resultado</returns>
    Public Function CerrarDespacho2(ByVal eM As MOVIMIENTOS, ByVal EsFarmacia As Boolean) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_ALM_MOVIMIENTOS ")
        strSQL.Append("SET ")
        strSQL.Append("IDESTADO = 2, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = 2")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND IDESTADO = 1 ")

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("UPDATE SAB_ALM_LOTES ")
        strSQL1.Append("SET CANTIDADRESERVADA = CANTIDADRESERVADA - DM.CANTIDAD, ")
        strSQL1.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL1.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL1.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL1.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL1.Append("ON DM.IDALMACEN = L.IDALMACEN ")
        strSQL1.Append("AND DM.IDLOTE = L.IDLOTE ")
        strSQL1.Append("WHERE DM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL1.Append("AND DM.IDTIPOTRANSACCION = 2 ")
        strSQL1.Append("AND DM.IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(0).Value = eM.IDESTADO
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(eM.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, eM.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(eM.AUFECHAMODIFICACION = Nothing, DBNull.Value, eM.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = eM.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = eM.IDESTABLECIMIENTO
        args(5) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(5).Value = eM.IDMOVIMIENTO

        'MYSQL-------------------------------------------------------
        'CONSULTA PARA EXISTENCIAS
        Dim strSQL3 As New Text.StringBuilder
        strSQL3.Append("SELECT CONVERT(VARCHAR, VS.IDVALE) + '/' + CONVERT(VARCHAR, VS.ANIO) NUMEROVALE, CP.IDSUMINISTRO, AL.ESFARMACIA, ")
        strSQL3.Append("M.AUUSUARIOCREACION, M.AUUSUARIOMODIFICACION, ")
        strSQL3.Append("L.CODIGO Lote, CP.CORRPRODUCTO Codigo,  L.PRECIOLOTE Precio,  ")
        strSQL3.Append("DM.CANTIDAD Cantidad, L.FECHAVENCIMIENTO, L.IDFUENTEFINANCIAMIENTO FuenteFinanciamiento, M.AUFECHACREACION, M.AUFECHAMODIFICACION ")
        strSQL3.Append("FROM SAB_ALM_MOVIMIENTOS M  ")
        strSQL3.Append("LEFT JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO  ")
        strSQL3.Append("LEFT JOIN SAB_ALM_LOTES L ON DM.IDALMACEN = L.IDALMACEN AND DM.IDLOTE = L.IDLOTE  ")
        strSQL3.Append("LEFT JOIN SAB_ALM_VALESSALIDA VS ON M.IDALMACEN = VS.IDALMACEN AND M.IDDOCUMENTO = VS.IDVALE AND M.ANIO = VS.ANIO  ")
        strSQL3.Append("LEFT JOIN vv_CATALOGOPRODUCTOS CP ON DM.IDPRODUCTO = CP.IDPRODUCTO   ")
        If EsFarmacia Then
            strSQL3.Append("LEFT JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE on M.IDESTABLECIMIENTO = AE.IDESTABLECIMIENTO ")
            strSQL3.Append("LEFT JOIN SAB_CAT_ALMACENES AL on AE.IDALMACEN = AL.IDALMACEN ")
            strSQL3.Append("WHERE(M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO And M.IDMOVIMIENTO = @IDMOVIMIENTO And M.IDTIPOTRANSACCION = 2 AND AL.ESFARMACIA = 1) ")
        Else
            strSQL3.Append("LEFT JOIN SAB_CAT_ALMACENES AL ON M.IDALMACEN = AL.IDALMACEN ")
            strSQL3.Append("WHERE(M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO And M.IDMOVIMIENTO = @IDMOVIMIENTO And M.IDTIPOTRANSACCION = 2) ")
        End If

        'OBTIENE LOS USUARIOS MODIFICADORES Y CREADORES PARA LOS MOVIMIENTOS_______________________
        Dim strSqlUreg As New Text.StringBuilder
        strSqlUreg.Append("SELECT  EM.IDEMPLEADO ")
        strSqlUreg.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSqlUreg.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ON M.AUUSUARIOCREACION = EM.NOMBRECORTO ")
        strSqlUreg.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND M.IDMOVIMIENTO = @IDMOVIMIENTO AND M.IDTIPOTRANSACCION =2 ")

        Dim strSqlUmod As New Text.StringBuilder
        strSqlUmod.Append("SELECT  EM.IDEMPLEADO ")
        strSqlUmod.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        strSqlUmod.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ON M.AUUSUARIOMODIFICACION = EM.NOMBRECORTO ")
        strSqlUmod.Append("WHERE M.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND M.IDMOVIMIENTO = @IDMOVIMIENTO AND M.IDTIPOTRANSACCION =2 ")

        Dim argsU(2) As SqlParameter
        argsU(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        argsU(0).Value = eM.IDESTABLECIMIENTO
        argsU(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        argsU(1).Value = eM.IDTIPOTRANSACCION
        argsU(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        argsU(2).Value = eM.IDMOVIMIENTO

        'INSERCION MYSQL TRANSACCIONES SINAB ________________________________________________
        'CONSULTA
        Dim strMySQL1 As New Text.StringBuilder
        strMySQL1.Append("INSERT INTO trans_sinab ")
        strMySQL1.Append("(No_Vale, IdEstado, IdUsuarioReg, FechaHoraReg, IdUsuarioMod, FechaHoraMod) ")
        strMySQL1.Append("Values(@VALE, 'E', @USUARIOREG, @FECHAREG, @USUARIOMOD, @FECHAMOD) ")

        'INSERCION MYSQL EXISTENCIAS SINAB ________________________________________________
        Dim strMySQL2 As New Text.StringBuilder
        strMySQL2.Append("INSERT INTO trans_existencias ")
        strMySQL2.Append("(IdTrans, Codigo, Cantidad, Lote, Precio,  FechaVencimiento, FuenteFinanciamiento, IdUsuarioReg, FechaHoraReg, IdUsuarioMod, FechaHoraMod) ")
        strMySQL2.Append("Values(@IDTRANS, @CODIGO, @CANTIDAD, @LOTE, @PRECIO,  @FECHAVENCE, @FINANCIAMIENTO, @USUARIOREG, @FECHAREG, @USUARIOMOD, @FECHAMOD) ")


        Dim resultado As Integer
        Dim idUserReg As Integer
        Dim idUserMod As Integer
        Dim ds As DataSet

        'RECUPERA LOS ID DE USUARIOS_____________________________
        Using c As New SqlConnection(Me.cnnStr)
            c.Open()
            Using getMod As New SqlCommand(strSqlUmod.ToString, c)
                getMod.Parameters.AddRange(argsU)
                idUserMod = getMod.ExecuteScalar()
                getMod.Parameters.Clear()
            End Using

            Using getReg As New SqlCommand(strSqlUreg.ToString, c)
                getReg.Parameters.AddRange(argsU)
                idUserReg = getReg.ExecuteScalar()
                getReg.Parameters.Clear()

            End Using
        End Using

        If idUserMod = 0 And idUserReg > 0 Then
            idUserMod = idUserReg
        ElseIf idUserMod > 0 And idUserReg = 0 Then
            idUserReg = idUserMod
        End If
        'RECUPERA LOS ID DE USUARIOS_____________________________

        Using c As New SqlConnection(Me.cnnStr)
            c.Open()
            Dim t As SqlTransaction = c.BeginTransaction()

            Try

                If SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args) = 1 Then

                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args)
                    ds = SqlHelper.ExecuteDataset(t, CommandType.Text, strSQL3.ToString(), argsU)

                    Dim suministro As Integer = 0


                    If ds.Tables(0).Rows.Count > 0 Then
                        suministro = IIf(ds.Tables(0).Rows(0).Item(1).ToString Is String.Empty, 0, ds.Tables(0).Rows(0).Item(1))

                    End If


                    If suministro = 1 And EsFarmacia Then

                        'PRECESANDO MYSQL_______________________________________

                        'Using cnn As MySqlConnection = New MySqlConnection(Me.cnnStrSiap)
                        '    cnn.Open()

                        '    Dim i As Integer = 0
                        '    Dim lastTransId As Integer

                        '    ' Dim dt As SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL3.ToString, args3)

                        '    'RECORRE LOS REGISTROS

                        '    For Each r As DataRow In ds.Tables(0).Rows
                        '        'here i want to loop through each item


                        '        If i = 0 Then
                        '            'INSERTA LA TRANSACCION
                        '            Dim insertTrans As MySqlCommand = New MySqlCommand(strMySQL1.ToString())
                        '            With insertTrans
                        '                .Connection = cnn
                        '                'PARAMETROS
                        '                .Parameters.AddWithValue("@VALE", r("NUMEROVALE"))
                        '                .Parameters.AddWithValue("@FECHAREG", IIf(r("AUFECHACREACION") = Nothing, DBNull.Value, r("AUFECHACREACION")))
                        '                .Parameters.AddWithValue("@FECHAMOD", IIf(r("AUFECHAMODIFICACION") = Nothing, DBNull.Value, r("AUFECHAMODIFICACION")))
                        '                .Parameters.AddWithValue("@USUARIOREG", idUserReg)
                        '                .Parameters.AddWithValue("@USUARIOMOD", idUserMod)
                        '                'EJECUTA LA CONSULTA
                        '                .ExecuteNonQuery()
                        '            End With

                        '            'RECUPERA EL ID DE LA TRANSACCION RECIEN INSERTADA
                        '            Dim getTrans As New MySqlCommand
                        '            getTrans.Connection = cnn
                        '            getTrans.CommandText = "SELECT IdTrans FROM trans_sinab ORDER BY IdTrans DESC LIMIT 1"
                        '            lastTransId = getTrans.ExecuteScalar

                        '        End If
                        '        i += 1

                        '        'INSERTA LA EXISTENCIA
                        '        Dim insertEx As MySqlCommand = New MySqlCommand(strMySQL2.ToString())
                        '        With insertEx
                        '            .Connection = cnn
                        '            'PARAMETROS
                        '            .Parameters.AddWithValue("@IDTRANS", lastTransId)
                        '            .Parameters.AddWithValue("@CODIGO", r("Codigo"))
                        '            .Parameters.AddWithValue("@CANTIDAD", r("Cantidad"))
                        '            .Parameters.AddWithValue("@LOTE", r("Lote"))
                        '            .Parameters.AddWithValue("@PRECIO", r("Precio"))
                        '            .Parameters.AddWithValue("@FECHAVENCE", r("FECHAVENCIMIENTO"))
                        '            .Parameters.AddWithValue("@FINANCIAMIENTO", r("FuenteFinanciamiento"))
                        '            .Parameters.AddWithValue("@FECHAREG", IIf(r("AUFECHACREACION") = Nothing, DBNull.Value, r("AUFECHACREACION")))
                        '            .Parameters.AddWithValue("@FECHAMOD", IIf(r("AUFECHAMODIFICACION") = Nothing, DBNull.Value, r("AUFECHAMODIFICACION")))
                        '            .Parameters.AddWithValue("@USUARIOREG", idUserReg)
                        '            .Parameters.AddWithValue("@USUARIOMOD", idUserMod)
                        '            'EJECUTA LA CONSULTA
                        '            .ExecuteNonQuery()
                        '        End With
                        '    Next

                        '    cnn.Close()

                        'End Using
                        'FIN PRECESANDO MYSQL_______________________________________
                    End If

                    t.Commit()

                    resultado = 1
                Else
                    t.Rollback()
                End If
            Catch ex As Exception
                t.Rollback()
                Throw
            Finally
                If Not t Is Nothing Then t.Dispose()
                If Not c.State = ConnectionState.Closed Then c.Close()
            End Try

        End Using

        Return resultado

    End Function

    ''' <summary>
    ''' Anular un movimiento de almacenes
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad detallemovimientos</param>
    ''' <param name="OPERACIONCANTIDADDISPONIBLE">Identificador de la cantidad disponible</param>
    ''' <param name="OPERACIONCANTIDADNODISPONIBLE">Identificador de la cantidad no disponible</param>
    ''' <param name="OPERACIONCANTIDADRESERVADA">Identificador de la cantidad reservada</param>
    ''' <param name="OPERACIONCANTIDADVENCIDA">Identificador de la cantidad vencida</param>
    ''' <param name="OPERACIONCANTIDADTEMPORAL">Identificador de la cantidad temporal</param>
    ''' <returns>Valor de tipo entero con el resultado</returns>
    Public Function AnularMovimiento(ByVal aEntidad As DETALLEMOVIMIENTOS, Optional ByVal OPERACIONCANTIDADDISPONIBLE As Int16 = 0, Optional ByVal OPERACIONCANTIDADNODISPONIBLE As Int16 = 0, Optional ByVal OPERACIONCANTIDADRESERVADA As Int16 = 0, Optional ByVal OPERACIONCANTIDADVENCIDA As Int16 = 0, Optional ByVal OPERACIONCANTIDADTEMPORAL As Int16 = 0) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_ALM_MOVIMIENTOS ")
        strSQL.Append("SET ")
        strSQL.Append("IDESTADO = 8, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND IDESTADO in (1, 2) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = aEntidad.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDMOVIMIENTO
        args(3) = New SqlParameter("@IDDETALLEMOVIMIENTO", SqlDbType.BigInt)
        args(3).Value = aEntidad.IDDETALLEMOVIMIENTO

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("UPDATE SAB_ALM_LOTES ")
        strSQL1.Append("SET ")
        strSQL1.Append("CANTIDADDISPONIBLE = ")
        strSQL1.Append("CASE ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADDISPONIBLE = 1 THEN CANTIDADDISPONIBLE + DM.CANTIDAD ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADDISPONIBLE = 2 THEN CANTIDADDISPONIBLE - DM.CANTIDAD ")
        strSQL1.Append("ELSE CANTIDADDISPONIBLE ")
        strSQL1.Append("END, ")
        strSQL1.Append("CANTIDADNODISPONIBLE = ")
        strSQL1.Append("CASE ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADNODISPONIBLE = 1 THEN CANTIDADNODISPONIBLE + DM.CANTIDAD ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADNODISPONIBLE = 2 THEN CANTIDADNODISPONIBLE - DM.CANTIDAD ")
        strSQL1.Append("ELSE CANTIDADNODISPONIBLE ")
        strSQL1.Append("END, ")
        strSQL1.Append("CANTIDADRESERVADA = ")
        strSQL1.Append("CASE ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADRESERVADA = 1 THEN CANTIDADRESERVADA + DM.CANTIDAD ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADRESERVADA = 2 THEN CANTIDADRESERVADA - DM.CANTIDAD ")
        strSQL1.Append("ELSE CANTIDADRESERVADA ")
        strSQL1.Append("END, ")
        strSQL1.Append("CANTIDADVENCIDA = ")
        strSQL1.Append("CASE ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADVENCIDA = 1 THEN CANTIDADVENCIDA + DM.CANTIDAD ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADVENCIDA = 2 THEN CANTIDADVENCIDA - DM.CANTIDAD ")
        strSQL1.Append("ELSE CANTIDADVENCIDA ")
        strSQL1.Append("END, ")
        strSQL1.Append("CANTIDADTEMPORAL = ")
        strSQL1.Append("CASE ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADTEMPORAL = 1 THEN CANTIDADTEMPORAL + DM.CANTIDAD ")
        strSQL1.Append("WHEN @OPERACIONCANTIDADTEMPORAL = 2 THEN CANTIDADTEMPORAL - DM.CANTIDAD ")
        strSQL1.Append("ELSE CANTIDADTEMPORAL ")
        strSQL1.Append("END, ")
        strSQL1.Append("ESTADISPONIBLE = 0, ")
        strSQL1.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL1.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL1.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL1.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL1.Append("ON DM.IDALMACEN = L.IDALMACEN ")
        strSQL1.Append("AND DM.IDLOTE = L.IDLOTE ")
        strSQL1.Append("WHERE DM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL1.Append("AND DM.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL1.Append("AND DM.IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim resultado As Integer

        Using c As New SqlConnection(Me.cnnStr)

            c.Open()

            Dim t As SqlTransaction = c.BeginTransaction()

            Try

                If SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args) = 1 Then

                    SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args)

                    t.Commit()

                    resultado = 1
                Else
                    t.Rollback()
                End If
            Catch ex As Exception
                t.Rollback()
                Throw
            Finally
                If Not t Is Nothing Then t.Dispose()
                If Not c.State = ConnectionState.Closed Then c.Close()
            End Try

        End Using

        Return resultado

    End Function

    ''' <summary>
    ''' Reporte de contabilidad en los almacenes
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="MESPERIODO">Identificador del mes</param>
    ''' <param name="ANIOPERIODO">Identificador del año</param>
    ''' <param name="IDGRUPOFUENTEFINANCIAMIENTO">Identificador del grupo de fuente de financiamiento</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="MONTOINICIAL">Monto</param>
    ''' <param name="SinFosalud">Identificador de FOSALUD</param>
    ''' <param name="IDESPECIFICOGASTO">Identificador del específico de gasto</param>
    ''' <returns>dataset</returns>
    Public Function RptContabilidadAlmacen2(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal MESPERIODO As Integer, ByVal ANIOPERIODO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal MONTOINICIAL As Decimal, ByVal SinFosalud As Integer, ByVal IDESPECIFICOGASTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        If SinFosalud <> 0 Then
            strSQL.Append("SELECT * FROM dbo.fn_ReporteContableSinFosalud(@IDALMACEN, @MESPERIODO, @ANIOPERIODO, @IDGRUPOFUENTEFINANCIAMIENTO, @IDSUMINISTRO, @IDESPECIFICOGASTO) ")
        Else
            strSQL.Append("SELECT * FROM dbo.fn_ReporteContable(@IDALMACEN, @MESPERIODO, @ANIOPERIODO, @IDGRUPOFUENTEFINANCIAMIENTO, @IDSUMINISTRO, @IDESPECIFICOGASTO) ")
        End If

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@MESPERIODO", SqlDbType.Int)
        args(2).Value = MESPERIODO
        args(3) = New SqlParameter("@ANIOPERIODO", SqlDbType.Int)
        args(3).Value = ANIOPERIODO
        args(4) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(4).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(5) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(5).Value = IDFUENTEFINANCIAMIENTO
        args(6) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(6).Value = IDESPECIFICOGASTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    '''  Reporte de contabilidad en los almacenes
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="MESPERIODO">Identificador del mes</param>
    ''' <param name="ANIOPERIODO">Identificador del año</param>
    ''' <param name="IDGRUPOFUENTEFINANCIAMIENTO">Identificador del grupo de fuente de financiamiento</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="MONTOINICIAL">Identificador del monto</param>
    ''' <param name="SinFOsalud">Identificador de FOSALUD</param>
    ''' <returns>dataset</returns>
    Public Function RptContabilidadAlmacen3(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal MESPERIODO As Integer, ByVal ANIOPERIODO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal MONTOINICIAL As Decimal, ByVal SinFosalud As Integer, ByVal IDESPECIFICOGASTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        If SinFosalud <> 0 Then
            strSQL.Append("SELECT * FROM dbo.fn_ReporteContable2SinFosalud(@IDALMACEN, @MESPERIODO, @ANIOPERIODO, @IDGRUPOFUENTEFINANCIAMIENTO, @IDSUMINISTRO, @IDESPECIFICOGASTO) ")
        Else
            strSQL.Append("SELECT * FROM dbo.fn_ReporteContable2(@IDALMACEN, @MESPERIODO, @ANIOPERIODO, @IDGRUPOFUENTEFINANCIAMIENTO, @IDSUMINISTRO, @IDESPECIFICOGASTO) ")
        End If

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@MESPERIODO", SqlDbType.Int)
        args(2).Value = MESPERIODO
        args(3) = New SqlParameter("@ANIOPERIODO", SqlDbType.Int)
        args(3).Value = ANIOPERIODO
        args(4) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(4).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(5) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(5).Value = IDFUENTEFINANCIAMIENTO
        args(6) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(6).Value = IDESPECIFICOGASTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener el monto del inventario inicial
    ''' </summary>
    ''' <param name="MESPERIODO">Identificador del mes inicial</param>
    ''' <param name="ANIOPERIODO">Identificador del año inicial</param>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="IDGRUPOFUENTEFINANCIAMIENTO">Identificador del grupo de fuente de financiamiento</param>
    ''' <param name="sinFosalud">Identificador del filtro fosalud</param>
    ''' <returns>Valor decimal</returns>
    Public Function ObtenerInventarioInicial(ByVal MESPERIODO As Integer, ByVal ANIOPERIODO As Integer, ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal sinFosalud As Integer, ByVal IDESPECIFICOGASTO As Integer) As Decimal

        Dim strSQL As New Text.StringBuilder

        If IDGRUPOFUENTEFINANCIAMIENTO = 3 Then
            strSQL.Append("sproc_InventarioInicialFOSALUD")
        Else
            If sinFosalud <> 0 Then
                strSQL.Append("sproc_InventarioInicialSinFosalud")
            Else
                strSQL.Append("sproc_InventarioInicial")
            End If
        End If

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(0).Direction = ParameterDirection.Input
        args(0).Value = New Date(ANIOPERIODO, MESPERIODO, 1)
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.BigInt)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDALMACEN
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDSUMINISTRO
        args(3) = New SqlParameter("@IDGRUPO", SqlDbType.SmallInt)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(4) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = IDESPECIFICOGASTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Reporte de contabilidad sin incluir movimientos de FOSALUD
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="MESPERIODO">Identificador del mes</param>
    ''' <param name="ANIOPERIODO">Identificador del año</param>
    ''' <param name="IDGRUPOFUENTEFINANCIAMIENTO">Identificador del grupo de fuente de financiamiento</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="MONTOINICIAL">Identificador del monto inicial</param>
    ''' <returns>Dataset</returns>
    Public Function RptContabilidadAlmacenFOSALUD(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal MESPERIODO As Integer, ByVal ANIOPERIODO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal MONTOINICIAL As Decimal, ByVal IDESPECIFICOGASTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT * FROM dbo.fn_ReporteContableFOSALUD(@IDALMACEN, @MESPERIODO, @ANIOPERIODO, @IDGRUPOFUENTEFINANCIAMIENTO, @IDSUMINISTRO, @IDESPECIFICOGASTO) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.BigInt)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@MESPERIODO", SqlDbType.Int)
        args(2).Value = MESPERIODO
        args(3) = New SqlParameter("@ANIOPERIODO", SqlDbType.Int)
        args(3).Value = ANIOPERIODO
        args(4) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(4).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(5) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(5).Value = IDFUENTEFINANCIAMIENTO
        args(6) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(6).Value = IDESPECIFICOGASTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerSuministrosMovimiento(ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOTRANSACCION As Integer, ByVal IDMOVIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DM.IDESTABLECIMIENTO, ")
        strSQL.Append("DM.IDTIPOTRANSACCION, ")
        strSQL.Append("DM.IDMOVIMIENTO, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("COUNT(CP.IDSUMINISTRO) CANTIDAD ")
        strSQL.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE DM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DM.IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND DM.IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("GROUP BY DM.IDESTABLECIMIENTO, ")
        strSQL.Append("DM.IDTIPOTRANSACCION, ")
        strSQL.Append("DM.IDMOVIMIENTO, ")
        strSQL.Append("CP.IDSUMINISTRO ")
        strSQL.Append("ORDER BY DM.IDESTABLECIMIENTO, ")
        strSQL.Append("DM.IDTIPOTRANSACCION, ")
        strSQL.Append("DM.IDMOVIMIENTO, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CANTIDAD DESC ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.BigInt)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.Int)
        args(2).Value = IDMOVIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

End Class
