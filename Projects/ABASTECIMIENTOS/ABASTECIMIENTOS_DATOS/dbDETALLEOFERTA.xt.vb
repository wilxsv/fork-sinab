Partial Public Class dbDETALLEOFERTA

#Region " Métodos Agregados "

    Public Function ObtenerIDDETALLE(ByVal aEntidad As DETALLEOFERTA) As Int64

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = aEntidad.IDPROVEEDOR

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerDataSetDetalleOferta(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el detalle de la consolidación de ofertas.
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDESTABLECIMIENTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="RENGLON">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="ds">Dataset referenciado que almacenara la informacion del detalle de la consolidacion de ofertas</param>
    ''' <returns>Dataset con el detalle de la consolidacion de ofertas.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' <item><description>SAB_UACI_OFERTAPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ObtenerDetalleConsolidacionOferta(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal RENGLON As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA, SAB_UACI_DETALLEOFERTA.RENGLON, SAB_UACI_DETALLEOFERTA.CORRELATIVORENGLON, ")
        strSQL.Append("            SAB_UACI_DETALLEOFERTA.DESCRIPCIONPROVEEDOR AS PRODUCTO, SAB_CAT_UNIDADMEDIDAS.DESCRIPCION AS UM, SAB_UACI_DETALLEOFERTA.CANTIDAD, ")
        strSQL.Append("             SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO, SAB_UACI_DETALLEOFERTA.CANTIDAD * SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO AS VALORTOTAL, ")
        strSQL.Append("           SAB_UACI_DETALLEOFERTA.PLAZOENTREGA AS ENTREGA, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.CASAREPRESENTADA, SAB_UACI_DETALLEOFERTA.MARCA, SAB_UACI_DETALLEOFERTA.ORIGEN, SAB_UACI_DETALLEOFERTA.VENCIMIENTO, SAB_UACI_DETALLEOFERTA.NUMEROCSSP ")
        strSQL.Append(" FROM SAB_CAT_UNIDADMEDIDAS INNER JOIN ")
        strSQL.Append("                SAB_UACI_DETALLEOFERTA ON SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA = SAB_UACI_DETALLEOFERTA.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("                 SAB_UACI_OFERTAPROCESOCOMPRA ON SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append("                SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append("                SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("                SAB_UACI_RECEPCIONOFERTAS ON SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("               SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append("   SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_DETALLEOFERTA.RENGLON = @RENGLON) ")
        strSQL.Append(" ORDER BY SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA")  '************************Agregado: 16/10/2007 NéstorGiovanniMejia

        '******Modificado
        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Dim tables(0) As String
        tables(0) = New String("DETALLECONSOLIDAROFERTA")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Public Function ObtenerValorizacionPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DO.RENGLON, ")
        strSQL.Append("RO.ORDENLLEGADA OFERTA, ")
        strSQL.Append("DO.CORRELATIVORENGLON ALTERNATIVA, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
        strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("UM.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("A.CANTIDADFIRME CANTIDAD, ")
        strSQL.Append("DO.PRECIOUNITARIO, ")
        strSQL.Append("DO.PRECIOUNITARIO * A.CANTIDADFIRME MONTO ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("ON (DO.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.RENGLON = DPC.RENGLON) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON CP.IDPRODUCTO = DPC.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
        strSQL.Append("ON DO.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
        strSQL.Append(" WHERE (DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("AND (DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (A.CANTIDADFIRME > 0) ")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim tables(0) As String
        tables(0) = New String("valorizacion")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Public Function ObtenerValorizacionPorRenglon2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByRef ds As DataSet, Optional ByVal idalmacen As Integer = 0) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("D.NOMBRE  NOMBRE, ")
        strSQL.Append("D.CARGO, D.ESTAHABILITADO, CPC.IDPROCESOCOMPRA, CPC.IDESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_UACI_COMISIONESEVALUADORAS C INNER JOIN ")
        strSQL.Append("SAB_UACI_COMISIONPROCESOCOMPRA CPC ON ")
        strSQL.Append("C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND C.IDCOMISION = ")
        strSQL.Append("CPC.IDCOMISION ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLECOMISIONEVALUADORA D ON ")
        strSQL.Append("C.IDESTABLECIMIENTO = D.IDESTABLECIMIENTO AND ")
        strSQL.Append("C.IDCOMISION = D.IDCOMISION ") 'INNER JOIN SAB_CAT_EMPLEADOS E ON 
        strSQL.Append("WHERE C.ESALTONIVEL = 0 AND D.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND D.ESTAHABILITADO = 1 ")

        Select Case idalmacen
            Case Is = 0
                Dim x As New dbPROGRAMADISTRIBUCION
                If x.ObtenerAlmacenFosIsss(IDESTABLECIMIENTO, IDPROCESOCOMPRA) = 0 Then
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("RO.ORDENLLEGADA OFERTA, ")
                    strSQL.Append("DO.CORRELATIVORENGLON ALTERNATIVA, ")
                    strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("isnull(DO.DESCRIPCIONPROVEEDOR, '') DESCRIPCIONPROVEEDOR, ")

                    strSQL.Append("A.CANTIDADFIRME CANTIDAD, ")

                    strSQL.Append("DO.PRECIOUNITARIO PRECIOUNITARIO, ")

                    strSQL.Append("(DO.PRECIOUNITARIO * A.CANTIDADFIRME) MONTO, ")

                    strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADFIRME > 0 ")

                    strSQL.Append(" UNION ")

                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("null OFERTA, ")
                    strSQL.Append("null ALTERNATIVA, ")
                    strSQL.Append("'' PROVEEDOR, ")
                    strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("case ")
                    strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                    strSQL.Append("    else 'NO ADJUDICADO' ")
                    strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("null CANTIDAD, ")
                    strSQL.Append("null PRECIOUNITARIO, ")
                    strSQL.Append("null MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                    ' strSQL.Append(",4 AS IDAGRUPACION,  '' AS NOMBREGRUPO ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                    strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                    strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                    strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                    strSQL.Append("OR DO.RENGLON is null) ")
                    strSQL.Append("ORDER BY RENGLON ")

                Else
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("RO.ORDENLLEGADA OFERTA, ")
                    strSQL.Append("DO.CORRELATIVORENGLON ALTERNATIVA, ")
                    strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("isnull(DO.DESCRIPCIONPROVEEDOR, '') DESCRIPCIONPROVEEDOR, ")

                    strSQL.Append("A.CANTIDADFIRME CANTIDAD, ")

                    strSQL.Append("DO.PRECIOUNITARIO PRECIOUNITARIO, ")

                    strSQL.Append("(DO.PRECIOUNITARIO * A.CANTIDADFIRME) MONTO, ")

                    strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADFIRME > 0 ")

                    strSQL.Append(" UNION ")

                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("null OFERTA, ")
                    strSQL.Append("null ALTERNATIVA, ")
                    strSQL.Append("'' PROVEEDOR, ")
                    strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("case ")
                    strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                    strSQL.Append("    else 'NO ADJUDICADO' ")
                    strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("null CANTIDAD, ")
                    strSQL.Append("null PRECIOUNITARIO, ")
                    strSQL.Append("null MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                    ' strSQL.Append(",4 AS IDAGRUPACION,  '' AS NOMBREGRUPO ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                    strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                    strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                    strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                    strSQL.Append("OR DO.RENGLON is null) ")
                    strSQL.Append("ORDER BY RENGLON ")
                    'query para reporte compra conjunta requerimiento del juridico
                    'strSQL.Append("SELECT ")
                    'strSQL.Append("DPC.RENGLON, ")
                    'strSQL.Append("RO.ORDENLLEGADA OFERTA, ")
                    'strSQL.Append("DO.CORRELATIVORENGLON ALTERNATIVA, ")
                    'strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    'strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    'strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    'strSQL.Append("isnull(DO.DESCRIPCIONPROVEEDOR, '') DESCRIPCIONPROVEEDOR, ")

                    ''strSQL.Append("A.CANTIDADFIRME CANTIDAD, ")
                    'strSQL.Append("SUM(PD.CANTIDADADJUDICADA) AS  CANTIDAD, ")

                    'strSQL.Append("DO.PRECIOUNITARIO PRECIOUNITARIO, ")

                    'strSQL.Append(" SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA) MONTO, ")

                    'strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                    'strSQL.Append(",1 AS IDAGRUPACION,  'MSPAS' AS NOMBREGRUPO ")

                    'strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    'strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    'strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    'strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    'strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    'strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    'strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    'strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    'strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
                    'strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    'strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    'strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DPC.RENGLON) ")

                    'strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    'strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    'strSQL.Append("AND PD.IDALMACEN NOT IN (114,499) ")

                    'strSQL.Append(" GROUP BY ")
                    'strSQL.Append("DPC.RENGLON, ")
                    'strSQL.Append("RO.ORDENLLEGADA , ")
                    'strSQL.Append("DO.CORRELATIVORENGLON , ")
                    'strSQL.Append("P.NOMBRE , ")
                    'strSQL.Append("CP.DESCLARGO , ")
                    'strSQL.Append("CP.DESCRIPCION , ")
                    'strSQL.Append("DO.DESCRIPCIONPROVEEDOR , ")
                    'strSQL.Append("DO.PRECIOUNITARIO, ")
                    'strSQL.Append("DPC.OBSERVACIONRECOMENDACION ")

                    'strSQL.Append(" UNION  ")

                    'strSQL.Append("SELECT ")
                    'strSQL.Append("DPC.RENGLON, ")
                    'strSQL.Append("RO.ORDENLLEGADA OFERTA, ")
                    'strSQL.Append("DO.CORRELATIVORENGLON ALTERNATIVA, ")
                    'strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    'strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    'strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    'strSQL.Append("isnull(DO.DESCRIPCIONPROVEEDOR, '') DESCRIPCIONPROVEEDOR, ")

                    ''strSQL.Append("A.CANTIDADFIRME CANTIDAD, ")
                    'strSQL.Append("SUM(PD.CANTIDADADJUDICADA) AS  CANTIDAD, ")

                    'strSQL.Append("DO.PRECIOUNITARIO PRECIOUNITARIO, ")

                    'strSQL.Append(" SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA) MONTO, ")

                    'strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                    'strSQL.Append(",2 AS IDAGRUPACION,  'FOSALUD' AS NOMBREGRUPO ")

                    'strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    'strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    'strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    'strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    'strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    'strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    'strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    'strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    'strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
                    'strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    'strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    'strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DPC.RENGLON) ")

                    'strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    'strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    'strSQL.Append("AND PD.IDALMACEN=114 ")

                    'strSQL.Append(" GROUP BY ")
                    'strSQL.Append("DPC.RENGLON, ")
                    'strSQL.Append("RO.ORDENLLEGADA , ")
                    'strSQL.Append("DO.CORRELATIVORENGLON , ")
                    'strSQL.Append("P.NOMBRE , ")
                    'strSQL.Append("CP.DESCLARGO , ")
                    'strSQL.Append("CP.DESCRIPCION , ")
                    'strSQL.Append("DO.DESCRIPCIONPROVEEDOR , ")
                    'strSQL.Append("DO.PRECIOUNITARIO, ")
                    'strSQL.Append("DPC.OBSERVACIONRECOMENDACION ")

                    'strSQL.Append(" UNION  ")

                    'strSQL.Append("SELECT ")
                    'strSQL.Append("DPC.RENGLON, ")
                    'strSQL.Append("RO.ORDENLLEGADA OFERTA, ")
                    'strSQL.Append("DO.CORRELATIVORENGLON ALTERNATIVA, ")
                    'strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    'strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    'strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    'strSQL.Append("isnull(DO.DESCRIPCIONPROVEEDOR, '') DESCRIPCIONPROVEEDOR, ")

                    ''strSQL.Append("A.CANTIDADFIRME CANTIDAD, ")
                    'strSQL.Append("SUM(PD.CANTIDADADJUDICADA) AS  CANTIDAD, ")

                    'strSQL.Append("DO.PRECIOUNITARIO PRECIOUNITARIO, ")

                    'strSQL.Append(" SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA) MONTO, ")

                    'strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                    'strSQL.Append(",3 AS IDAGRUPACION,  'ISSS' AS NOMBREGRUPO ")

                    'strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    'strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    'strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    'strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    'strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    'strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    'strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    'strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    'strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
                    'strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    'strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    'strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DPC.RENGLON) ")

                    'strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    'strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    'strSQL.Append("AND PD.IDALMACEN=499 ")

                    'strSQL.Append(" GROUP BY ")
                    'strSQL.Append("DPC.RENGLON, ")
                    'strSQL.Append("RO.ORDENLLEGADA , ")
                    'strSQL.Append("DO.CORRELATIVORENGLON , ")
                    'strSQL.Append("P.NOMBRE , ")
                    'strSQL.Append("CP.DESCLARGO , ")
                    'strSQL.Append("CP.DESCRIPCION , ")
                    'strSQL.Append("DO.DESCRIPCIONPROVEEDOR , ")
                    'strSQL.Append("DO.PRECIOUNITARIO, ")
                    'strSQL.Append("DPC.OBSERVACIONRECOMENDACION")

                    'strSQL.Append(" UNION ")

                    'strSQL.Append("SELECT ")
                    'strSQL.Append("DPC.RENGLON, ")
                    'strSQL.Append("null OFERTA, ")
                    'strSQL.Append("null ALTERNATIVA, ")
                    'strSQL.Append("'' PROVEEDOR, ")
                    'strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    'strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    'strSQL.Append("case ")
                    'strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                    'strSQL.Append("    else 'NO ADJUDICADO' ")
                    'strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                    'strSQL.Append("null CANTIDAD, ")
                    'strSQL.Append("null PRECIOUNITARIO, ")
                    'strSQL.Append("null MONTO, ")
                    'strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                    'strSQL.Append(",4 AS IDAGRUPACION,  '' AS NOMBREGRUPO ")

                    'strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    'strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    'strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    'strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    'strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    'strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    'strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                    'strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                    'strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                    'strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    'strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    'strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                    'strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                    'strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    'strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    'strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                    'strSQL.Append("OR DO.RENGLON is null) ")
                    'strSQL.Append("ORDER BY RENGLON ")
                End If

            Case Is = 1
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA OFERTA, ")
                strSQL.Append("DO.CORRELATIVORENGLON ALTERNATIVA, ")
                strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("isnull(DO.DESCRIPCIONPROVEEDOR, '') DESCRIPCIONPROVEEDOR, ")

                'strSQL.Append("A.CANTIDADFIRME CANTIDAD, ")
                strSQL.Append("SUM(PD.CANTIDADADJUDICADA) AS  CANTIDAD, ")

                strSQL.Append("DO.PRECIOUNITARIO PRECIOUNITARIO, ")

                strSQL.Append(" SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA) MONTO, ")

                strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON (PD.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.RENGLON = DPC.RENGLON) ")

                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                strSQL.Append("AND PD.IDALMACEN NOT IN (114,499) ")

                strSQL.Append(" GROUP BY ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA , ")
                strSQL.Append("DO.CORRELATIVORENGLON , ")
                strSQL.Append("P.NOMBRE , ")
                strSQL.Append("CP.DESCLARGO , ")
                strSQL.Append("CP.DESCRIPCION , ")
                strSQL.Append("DO.DESCRIPCIONPROVEEDOR , ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("DPC.OBSERVACIONRECOMENDACION ")

                strSQL.Append(" UNION ")

                strSQL.Append("SELECT ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("null OFERTA, ")
                strSQL.Append("null ALTERNATIVA, ")
                strSQL.Append("'' PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("case ")
                strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                strSQL.Append("    else 'NO ADJUDICADO' ")
                strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("null CANTIDAD, ")
                strSQL.Append("null PRECIOUNITARIO, ")
                strSQL.Append("null MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                ' strSQL.Append(",4 AS IDAGRUPACION,  '' AS NOMBREGRUPO ")

                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                strSQL.Append("OR DO.RENGLON is null) ")
                strSQL.Append("ORDER BY RENGLON ")


            Case Is = 114
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA OFERTA, ")
                strSQL.Append("DO.CORRELATIVORENGLON ALTERNATIVA, ")
                strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("isnull(DO.DESCRIPCIONPROVEEDOR, '') DESCRIPCIONPROVEEDOR, ")

                'strSQL.Append("A.CANTIDADFIRME CANTIDAD, ")
                strSQL.Append("SUM(PD.CANTIDADADJUDICADA) AS  CANTIDAD, ")

                strSQL.Append("DO.PRECIOUNITARIO PRECIOUNITARIO, ")

                strSQL.Append(" SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA) MONTO, ")

                strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON (PD.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.RENGLON = DPC.RENGLON) ")

                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                strSQL.Append("AND PD.IDALMACEN =@IDALMACEN ")

                strSQL.Append(" GROUP BY ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA , ")
                strSQL.Append("DO.CORRELATIVORENGLON , ")
                strSQL.Append("P.NOMBRE , ")
                strSQL.Append("CP.DESCLARGO , ")
                strSQL.Append("CP.DESCRIPCION , ")
                strSQL.Append("DO.DESCRIPCIONPROVEEDOR , ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("DPC.OBSERVACIONRECOMENDACION ")

                strSQL.Append(" UNION ")

                strSQL.Append("SELECT ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("null OFERTA, ")
                strSQL.Append("null ALTERNATIVA, ")
                strSQL.Append("'' PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("case ")
                strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                strSQL.Append("    else 'NO ADJUDICADO' ")
                strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("null CANTIDAD, ")
                strSQL.Append("null PRECIOUNITARIO, ")
                strSQL.Append("null MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                'strSQL.Append(",4 AS IDAGRUPACION,  '' AS NOMBREGRUPO ")

                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                strSQL.Append("OR DO.RENGLON is null) ")
                strSQL.Append("ORDER BY RENGLON ")

            Case Is = 499
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA OFERTA, ")
                strSQL.Append("DO.CORRELATIVORENGLON ALTERNATIVA, ")
                strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("isnull(DO.DESCRIPCIONPROVEEDOR, '') DESCRIPCIONPROVEEDOR, ")

                'strSQL.Append("A.CANTIDADFIRME CANTIDAD, ")
                strSQL.Append("SUM(PD.CANTIDADADJUDICADA) AS  CANTIDAD, ")

                strSQL.Append("DO.PRECIOUNITARIO PRECIOUNITARIO, ")

                strSQL.Append(" SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA) MONTO, ")

                strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON (PD.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.RENGLON = DPC.RENGLON) ")

                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                strSQL.Append("AND PD.IDALMACEN =@IDALMACEN ")

                strSQL.Append(" GROUP BY ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA , ")
                strSQL.Append("DO.CORRELATIVORENGLON , ")
                strSQL.Append("P.NOMBRE , ")
                strSQL.Append("CP.DESCLARGO , ")
                strSQL.Append("CP.DESCRIPCION , ")
                strSQL.Append("DO.DESCRIPCIONPROVEEDOR , ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("DPC.OBSERVACIONRECOMENDACION ")

                strSQL.Append(" UNION ")

                strSQL.Append("SELECT ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("null OFERTA, ")
                strSQL.Append("null ALTERNATIVA, ")
                strSQL.Append("'' PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("case ")
                strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                strSQL.Append("    else 'NO ADJUDICADO' ")
                strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("null CANTIDAD, ")
                strSQL.Append("null PRECIOUNITARIO, ")
                strSQL.Append("null MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")

                'strSQL.Append(",4 AS IDAGRUPACION,  '' AS NOMBREGRUPO ")

                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                strSQL.Append("OR DO.RENGLON is null) ")
                strSQL.Append("ORDER BY RENGLON ")
        End Select
        

       

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        If idalmacen = 114 Or idalmacen = 499 Then
            args(2) = New SqlParameter("@IDALMACEN", SqlDbType.BigInt)
            args(2).Value = idalmacen
        End If
        Dim tables(1) As String
        tables(0) = New String("dtComision")
        tables(1) = New String("dtValorizacionPorRenglon")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    ''' <summary>
    ''' Obtiene informacion sobre el renglón.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROVEEDOR">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Dataset con la informacion sobre el renglón.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function ObtenerRenglon(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT convert(VARCHAR,RENGLON) + ' - '+ convert(varchar,CORRELATIVORENGLON) AS RENGLONCONCATENADO, IDDETALLE FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" ORDER BY RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerRenglon2(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT RENGLON, IDDETALLE FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" ORDER BY RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene la observacion de los documentos.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROVEEDOR">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDDETALLE">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Obtiene la observación de los documentos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function ObtenerDocumentoObservacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT isnull(OBSERVACIONDOCUMENTO,'') OBSERVACIONDOCUMENTO FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza la observación de los documentos.
    ''' </summary>
    ''' <param name="aEntidad">Especifica la entidad a utilizar para filtrar la información.</param>
    ''' <returns>Valor indicando si la actualizacion se realizó con éxito.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function ActualizarObservacionDocumento(ByVal aEntidad As DETALLEOFERTA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEOFERTA ")
        strSQL.Append("SET OBSERVACIONDOCUMENTO = @OBSERVACIONDOCUMENTO, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@OBSERVACIONDOCUMENTO", SqlDbType.VarChar)
        args(0).Value = IIf(IsNothing(aEntidad.OBSERVACIONDOCUMENTO), DBNull.Value, aEntidad.OBSERVACIONDOCUMENTO)
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = aEntidad.IDESTABLECIMIENTO
        args(5) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(5).Value = aEntidad.IDPROCESOCOMPRA
        args(6) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(6).Value = aEntidad.IDPROVEEDOR
        args(7) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(7).Value = aEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene todas las ofertas recibidas para un renglón correspondiente a un proceso de compra dado.
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="IDDETALLE">Idnetificador del detalle de la oferta.  Opcional, sólo si se desea devolver los datos de una sola oferta.  Por defecto es 0, que significa que se muestran todas.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>SAB_UACI_RECEPCIONOFERTAS</item>
    ''' 
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerOfertasPorRenglonProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal RENGLON As Int32, Optional ByVal IDPROVEEDOR As Integer = 0, Optional ByVal IDDETALLE As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        'ok
        strSQL.Append("SELECT ")
        strSQL.Append("DO.IDPROVEEDOR, ")
        strSQL.Append("DO.IDDETALLE, ")
        strSQL.Append("DO.RENGLON, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        strSQL.Append("DO.CORRELATIVORENGLON, ")
        strSQL.Append("RO.ORDENLLEGADA, ")
        strSQL.Append("DO.DESCRIPCIONPROVEEDOR ")
        strSQL.Append("+  'CASA: ' + rtrim(isnull(DO.CASAREPRESENTADA, '')) + ")
        strSQL.Append("' MARCA: ' + rtrim(isnull(DO.MARCA, '')) + ")
        strSQL.Append("' ORIGEN: ' + rtrim(isnull(DO.ORIGEN, '')) + ")
        strSQL.Append("' VTO.: ' + rtrim(isnull(DO.VENCIMIENTO, '')) DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("UM.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("isnull(UM.CANTIDADDECIMAL, 0) CANTIDADDECIMALES, ")
        strSQL.Append("DO.CANTIDAD, ")
        strSQL.Append("DO.PRECIOUNITARIO, ")
        strSQL.Append("DO.PRECIOUNITARIO * DO.CANTIDAD MONTO, ")
        strSQL.Append("DO.PLAZOENTREGA, ")
        strSQL.Append("(SELECT isnull(sum(isnull(PORCENTAJE, 0)), 0) from SAB_UACI_CALIFICACIONRENGLONOFERTAS CRO ")
        strSQL.Append(" WHERE CRO.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append(" AND CRO.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append(" AND CRO.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append(" AND CRO.IDDETALLE = DO.IDDETALLE) CALIFICACION, ")
        strSQL.Append("isnull(CANTIDADRECOMENDACION, 0) CANTIDADRECOMENDADA, ")
        strSQL.Append("isnull(CANTIDADADJUDICADA, 0) CANTIDADADJUDICADA, ")
        strSQL.Append("isnull(CANTIDADFIRME, 0) CANTIDADENFIRME ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ON DO.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append("ON (A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("(DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("AND (DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (DO.RENGLON = @RENGLON) ")
        If IDPROVEEDOR > 0 Then
            strSQL.Append("AND (DO.IDPROVEEDOR = @IDPROVEEDOR) ")
        End If
        If IDDETALLE > 0 Then
            strSQL.Append("AND (DO.IDDETALLE = @IDDETALLE) ")
        End If
        'strSQL.Append("ORDER BY CALIFICACION DESC")
        strSQL.Append("ORDER BY RO.ORDENLLEGADA ASC")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON
        If IDPROVEEDOR > 0 Then
            args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
            args(3).Value = IDPROVEEDOR
        End If
        If IDDETALLE > 0 Then
            args(4) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
            args(4).Value = IDDETALLE
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el numero de proveedores en detalle de la oferta.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Dataset con el numero de proveedores</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function ObtenerProveedores(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT COUNT(IDdetalle) FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA GROUP BY IDPROVEEDOR")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Actualiza el estado de la calificacion de ofertas.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROVEEDOR">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDDETALLE">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDESTADOCALIFICACION">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Valor indicando si la actualizacion se realizó con éxito.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function ActualizarEstadoCalificacionOferta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal IDESTADOCALIFICACION As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEOFERTA ")
        strSQL.Append("SET IDESTADOCALIFICACION = @IDESTADOCALIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE
        args(4) = New SqlParameter("@IDESTADOCALIFICACION", SqlDbType.Int)
        args(4).Value = IDESTADOCALIFICACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Chequea si el ofertante ya ha sido calificado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROVEEDOR">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDDETALLE">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="RENGLON">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Valor indicando si la actualizacion se realizó con éxito.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function OfertanteCalificado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal idproveedor As Integer, ByVal iddetalle As Integer, ByVal RENGLON As Integer) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("COUNT(DO1.IDDETALLE) - ")
        strSQL.Append("( ")
        strSQL.Append(" SELECT ")
        strSQL.Append(" COUNT(DO2.IDDETALLE) ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA DO2 ")
        strSQL.Append(" WHERE DO2.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND DO2.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND DO2.RENGLON = @RENGLON ")
        strSQL.Append(" AND DO2.IDESTADOCALIFICACION = 2 ")
        strSQL.Append(" ) ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA DO1 ")
        strSQL.Append("WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO1.RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(2).Value = RENGLON

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Obtiene el cuadro de evaluaciones de las ofertas.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="RENGLON">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROVEEDOR">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDDETALLE">Especifica el valor a utilizar para filtrar la información.</param>
    ''' 
    ''' <returns>Dataset con la informacion del cuadro basico</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CALIFICACIONRENGLONOFERTAS</description></item>
    ''' <item><description>SAB_UACI_ADJUDICACION</description></item>
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function CuadroEvaluacionOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer, Optional ByVal IDPROVEEDOR As Integer = 0, Optional ByVal IDDETALLE As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DO.IDPROVEEDOR, ")
        strSQL.Append("DO.IDDETALLE, ")
        strSQL.Append("DO.CORRELATIVORENGLON, ")
        strSQL.Append("RO.ORDENLLEGADA, ")
        strSQL.Append("convert(varchar, (SELECT isnull(sum(isnull(PORCENTAJE, 0)), 0) ")
        strSQL.Append(" FROM SAB_UACI_CALIFICACIONRENGLONOFERTAS CRO ")
        strSQL.Append(" WHERE CRO.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append(" AND CRO.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append(" AND CRO.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append(" AND CRO.IDDETALLE = DO.IDDETALLE)) + '%' TOTALCALIFICACION, ")
        strSQL.Append("isnull((SELECT CANTIDADRECOMENDACION ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" WHERE A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDDETALLE = DO.IDDETALLE), 0) CANTIDADRECOMENDADA ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
        strSQL.Append("WHERE DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.RENGLON = @RENGLON ")
        strSQL.Append("ORDER BY RO.ORDENLLEGADA, DO.CORRELATIVORENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(2).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el cuadro de evaluación de criterios.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROVEEDOR">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDDETALLE">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Dataset conteniendo el cuadro de evaluacion</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CALIFICACIONRENGLONOFERTAS</description></item>
    ''' <item><description>SAB_CAT_CRITERIOSEVALUACION</description></item>
    ''' <item><description>SAB_UACI_EXAMENOFERTA</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function CuadroEvaluacionCriterios(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CRO.IDCRITERIOEVALUACION, ")
        strSQL.Append("CE.DESCRIPCION + ' (' + convert(varchar, CPC.PORCENTAJE) + '%)' CRITERIO, ")
        strSQL.Append("convert(varchar, CRO.PORCENTAJE) + '%' PORCENTAJE ")
        strSQL.Append("FROM SAB_UACI_CALIFICACIONRENGLONOFERTAS CRO ")
        strSQL.Append("INNER JOIN SAB_UACI_CRITERIOPROCESOCOMPRA CPC ")
        strSQL.Append("ON (CRO.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND CRO.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA ")
        strSQL.Append("AND CRO.IDCRITERIOEVALUACION = CPC.IDCRITERIOEVALUACION) ")
        strSQL.Append("INNER JOIN SAB_CAT_CRITERIOSEVALUACION CE ")
        strSQL.Append("ON CRO.IDCRITERIOEVALUACION = CE.IDCRITERIOEVALUACION ")
        strSQL.Append("WHERE CE.IDTIPOCRITERIO = 1 ")
        strSQL.Append("AND CE.ESGLOBAL <> 1 ")
        strSQL.Append("AND CRO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CRO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND CRO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND CRO.IDDETALLE = @IDDETALLE ")
        strSQL.Append("")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT ")
        strSQL.Append("99 IDCRITERIOEVALUACION, ")
        strSQL.Append("'Evaluación Financiera (' + CONVERT(varchar, PORCENTAJEFINANCIERO) + '%)' CRITERIO, ")
        strSQL.Append("convert(varchar, PONDERACIONCAPITAL + PONDERACIONSOLVENCIA + PONDERACIONENDEUDAMIENTO + PONDERACIONREFERENCIA) + '%' PORCENTAJE ")
        strSQL.Append("FROM SAB_UACI_EXAMENOFERTA ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append("ON (SAB_UACI_EXAMENOFERTA.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_EXAMENOFERTA.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA) ")
        strSQL.Append("WHERE SAB_UACI_EXAMENOFERTA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_EXAMENOFERTA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Para un renglón y oferta dados, devuelve el total recomendado a otras ofertas, del mismo y otros proveedores.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <param name="TOTALRECOMENDADOOTROSPROVEEDORES">Cantidad total recomendada a ofertas de otros proveedores.</param>
    ''' <param name="TOTALRECOMENDADOMISMOPROVEEDOR">Cantidad total recomendada a ofertas del mismo proveedor.</param>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Sub ObtenerTotalesRecomendados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal RENGLON As Integer, ByRef TOTALRECOMENDADOOTROSPROVEEDORES As Decimal, ByRef TOTALRECOMENDADOMISMOPROVEEDOR As Decimal)

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("(SELECT isnull(sum(isnull(CANTIDADRECOMENDACION, 0)), 0) ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA DO2 ")
        strSQL.Append(" INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" ON (A.IDPROCESOCOMPRA = DO2.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A.IDESTABLECIMIENTO = DO2.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROVEEDOR <> DO.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO2.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDDETALLE = DO2.IDDETALLE) ")
        strSQL.Append(" WHERE DO2.RENGLON = @RENGLON ")
        strSQL.Append(" AND DO2.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND DO2.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) TOTALRECOMENDADOOTROSPROVEEDORES, ")
        strSQL.Append("(SELECT isnull(sum(CANTIDADRECOMENDACION), 0) ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA DO3 ")
        strSQL.Append(" INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" ON (A.IDPROCESOCOMPRA = DO3.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A.IDESTABLECIMIENTO = DO3.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO3.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDDETALLE <> DO.IDDETALLE ")
        strSQL.Append(" AND A.IDDETALLE = DO3.IDDETALLE ")
        strSQL.Append(" AND DO3.RENGLON = DO.RENGLON) ")
        strSQL.Append(" WHERE DO3.RENGLON = @RENGLON AND ")
        strSQL.Append(" DO3.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND ")
        strSQL.Append(" DO3.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) TOTALRECOMENDADOMISMOPROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = @IDDETALLE ")
        strSQL.Append("AND DO.RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = RENGLON

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dr.HasRows Then
            dr.Read()
            TOTALRECOMENDADOOTROSPROVEEDORES = dr("TOTALRECOMENDADOOTROSPROVEEDORES")
            TOTALRECOMENDADOMISMOPROVEEDOR = dr("TOTALRECOMENDADOMISMOPROVEEDOR")
        Else
            TOTALRECOMENDADOOTROSPROVEEDORES = 0
            TOTALRECOMENDADOMISMOPROVEEDOR = 0
        End If

        dr.Close()

    End Sub

    ''' <summary>
    ''' Para un renglón y oferta dados, devuelve el total adjudicado a otras ofertas, del mismo y otros proveedores.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <param name="TOTALADJUDICADOOTROSPROVEEDORES">Cantidad total adjudicada a ofertas de otros proveedores.</param>
    ''' <param name="TOTALADJUDICADOMISMOPROVEEDOR">Cantidad total adjudicada a ofertas del mismo proveedor.</param>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Sub ObtenerTotalesAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal RENGLON As Integer, ByRef TOTALADJUDICADOOTROSPROVEEDORES As Decimal, ByRef TOTALADJUDICADOMISMOPROVEEDOR As Decimal)

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("(SELECT isnull(sum(isnull(CANTIDADADJUDICADA, 0)), 0) ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA DO2 ")
        strSQL.Append(" INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" ON (A.IDPROCESOCOMPRA = DO2.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A.IDESTABLECIMIENTO = DO2.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROVEEDOR <> DO.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO2.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDDETALLE = DO2.IDDETALLE) ")
        strSQL.Append(" WHERE DO2.RENGLON = @RENGLON ")
        strSQL.Append(" AND DO2.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND DO2.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) TOTALADJUDICADOOTROSPROVEEDORES, ")
        strSQL.Append("(SELECT isnull(sum(CANTIDADADJUDICADA), 0) ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA DO3 ")
        strSQL.Append(" INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" ON (A.IDPROCESOCOMPRA = DO3.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A.IDESTABLECIMIENTO = DO3.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO3.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDDETALLE <> DO.IDDETALLE ")
        strSQL.Append(" AND A.IDDETALLE = DO3.IDDETALLE ")
        strSQL.Append(" AND DO3.RENGLON = DO.RENGLON) ")
        strSQL.Append(" WHERE DO3.RENGLON = @RENGLON AND ")
        strSQL.Append(" DO3.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND ")
        strSQL.Append(" DO3.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) TOTALADJUDICADOMISMOPROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = @IDDETALLE ")
        strSQL.Append("AND DO.RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = RENGLON

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dr.HasRows Then
            dr.Read()
            TOTALADJUDICADOOTROSPROVEEDORES = dr("TOTALADJUDICADOOTROSPROVEEDORES")
            TOTALADJUDICADOMISMOPROVEEDOR = dr("TOTALADJUDICADOMISMOPROVEEDOR")
        Else
            TOTALADJUDICADOOTROSPROVEEDORES = 0
            TOTALADJUDICADOMISMOPROVEEDOR = 0
        End If

        dr.Close()

    End Sub

    ''' <summary>
    ''' Para un renglón y oferta dados, devuelve el total adjudicado en firme a otras ofertas, del mismo y otros proveedores.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <param name="TOTALENFIRMEOTROSPROVEEDORES">Cantidad total adjudicada en firme a ofertas de otros proveedores.</param>
    ''' <param name="TOTALENFIRMEMISMOPROVEEDOR">Cantidad total adjudicado en firme a ofertas del mismo proveedor.</param>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Sub ObtenerTotalesAdjudicadosEnFirme(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal RENGLON As Integer, ByRef TOTALENFIRMEOTROSPROVEEDORES As Decimal, ByRef TOTALENFIRMEMISMOPROVEEDOR As Decimal)

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("(SELECT isnull(sum(isnull(CANTIDADFIRME, 0)), 0) ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA DO2 ")
        strSQL.Append(" INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" ON (A.IDPROCESOCOMPRA = DO2.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A.IDESTABLECIMIENTO = DO2.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROVEEDOR <> DO.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO2.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDDETALLE = DO2.IDDETALLE) ")
        strSQL.Append(" WHERE DO2.RENGLON = @RENGLON ")
        strSQL.Append(" AND DO2.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND DO2.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) TOTALENFIRMEOTROSPROVEEDORES, ")
        strSQL.Append("(SELECT isnull(sum(CANTIDADFIRME), 0) ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA DO3 ")
        strSQL.Append(" INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" ON (A.IDPROCESOCOMPRA = DO3.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A.IDESTABLECIMIENTO = DO3.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO3.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDDETALLE <> DO.IDDETALLE ")
        strSQL.Append(" AND A.IDDETALLE = DO3.IDDETALLE ")
        strSQL.Append(" AND DO3.RENGLON = DO.RENGLON) ")
        strSQL.Append(" WHERE DO3.RENGLON = @RENGLON AND ")
        strSQL.Append(" DO3.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND ")
        strSQL.Append(" DO3.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) TOTALENFIRMEMISMOPROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = @IDDETALLE ")
        strSQL.Append("AND DO.RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = RENGLON

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dr.HasRows Then
            dr.Read()
            TOTALENFIRMEOTROSPROVEEDORES = dr("TOTALENFIRMEOTROSPROVEEDORES")
            TOTALENFIRMEMISMOPROVEEDOR = dr("TOTALENFIRMEMISMOPROVEEDOR")
        Else
            TOTALENFIRMEOTROSPROVEEDORES = 0
            TOTALENFIRMEMISMOPROVEEDOR = 0
        End If

        dr.Close()

    End Sub

    Public Function CuadroTecnicoFinanciero(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT  DO.RENGLON, DPC.IDPRODUCTO, UM.DESCRIPCION, CRO.IDPROVEEDOR, CRO.IDDETALLE, CRO.IDCRITERIOEVALUACION, ")
        strSQL.Append("       DO.CORRELATIVORENGLON, RO.ORDENLLEGADA, CASE CRO.IDCRITERIOEVALUACION WHEN 99 THEN isnull ")
        strSQL.Append("       ((SELECT 'Evaluación Financiera (' + CONVERT(varchar, PC.PORCENTAJEFINANCIERO) + '%)' ")
        strSQL.Append("       FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("       WHERE PC.IDESTABLECIMIENTO = CRO.IDESTABLECIMIENTO AND PC.IDPROCESOCOMPRA = CRO.IDPROCESOCOMPRA), '') ")
        strSQL.Append("       ELSE isnull ")
        strSQL.Append("       ((SELECT  CE.DESCRIPCION + ' (' + CONVERT(varchar, CPC.PORCENTAJE) + '%)' AS CRITERIO ")
        strSQL.Append("       FROM SAB_CAT_CRITERIOSEVALUACION CE INNER JOIN ")
        strSQL.Append("       SAB_UACI_CRITERIOPROCESOCOMPRA CPC ON CE.IDCRITERIOEVALUACION = CPC.IDCRITERIOEVALUACION ")
        strSQL.Append("       WHERE CPC.IDESTABLECIMIENTO = CRO.IDESTABLECIMIENTO AND CPC.IDPROCESOCOMPRA = CRO.IDPROCESOCOMPRA AND ")
        strSQL.Append("       CE.IDCRITERIOEVALUACION = CRO.IDCRITERIOEVALUACION), '') END AS CRITERIO, CRO.PORCENTAJE, ")
        strSQL.Append("       ISNULL(A.CANTIDADRECOMENDACION, 0) AS CANTIDADRECOMENDADA, ISNULL(DPC.OBSERVACIONRECOMENDACION, '') AS OBSERVACIONES, ")
        strSQL.Append("       CASE WHEN RO.ORDENLLEGADA<10 THEN '0' + CONVERT(varchar, RO.ORDENLLEGADA) + '-' + CONVERT(varchar, DO.CORRELATIVORENGLON) ELSE CONVERT(varchar, RO.ORDENLLEGADA) + '-' + CONVERT(varchar, DO.CORRELATIVORENGLON) END AS OFERTARPT,")
        'strSQL.Append("       CONVERT(varchar, RO.ORDENLLEGADA) + '-' + CONVERT(varchar, DO.CORRELATIVORENGLON) AS OFERTARPT, ")
        strSQL.Append("       VCP.DESCLARGO AS DESCLARGO ")
        strSQL.Append("FROM SAB_UACI_CALIFICACIONRENGLONOFERTAS AS CRO INNER JOIN ")
        strSQL.Append("       SAB_UACI_DETALLEOFERTA AS DO ON CRO.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO AND ")
        strSQL.Append("       CRO.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA AND CRO.IDPROVEEDOR = DO.IDPROVEEDOR AND ")
        strSQL.Append("       CRO.IDDETALLE = DO.IDDETALLE INNER JOIN ")
        strSQL.Append("       SAB_UACI_RECEPCIONOFERTAS AS RO ON DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA AND ")
        strSQL.Append("       DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO AND DO.IDPROVEEDOR = RO.IDPROVEEDOR INNER JOIN ")
        strSQL.Append("       SAB_UACI_DETALLEPROCESOCOMPRA AS DPC ON CRO.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO AND ")
        strSQL.Append("       CRO.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA AND DO.RENGLON = DPC.RENGLON INNER JOIN ")
        strSQL.Append("       SAB_CAT_CATALOGOPRODUCTOS AS CP ON DPC.IDPRODUCTO = CP.IDPRODUCTO LEFT OUTER JOIN ")
        strSQL.Append("       SAB_UACI_ADJUDICACION AS A ON CRO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO AND CRO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA AND ")
        strSQL.Append("       CRO.IDPROVEEDOR = A.IDPROVEEDOR AND CRO.IDDETALLE = A.IDDETALLE INNER JOIN ")
        strSQL.Append("       SAB_CAT_UNIDADMEDIDAS AS UM ON UM.IDUNIDADMEDIDA = CP.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("       vv_CATALOGOPRODUCTOS AS VCP ON DPC.IDPRODUCTO = VCP.IDPRODUCTO ")
        strSQL.Append("WHERE (CRO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (CRO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (DO.RENGLON = @RENGLON) ")
        strSQL.Append("ORDER BY RO.ORDENLLEGADA, DO.CORRELATIVORENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(2).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    'Jrivas
    Public Function validarExistenciaOferta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(CORRELATIVORENGLON),0) + 1 CORRELATIVORENGLON ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function rptDetalleOferta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DO.IDESTABLECIMIENTO, DO.IDPROCESOCOMPRA, DO.IDPROVEEDOR, DO.RENGLON, DO.CORRELATIVORENGLON, DO.CASAREPRESENTADA, ")
        strSQL.Append(" DO.MARCA, DO.ORIGEN, DO.DESCRIPCIONPROVEEDOR, DO.VENCIMIENTO, DO.CANTIDAD, DO.PRECIOUNITARIO, DO.PLAZOENTREGA, ")
        strSQL.Append(" DO.NUMEROCSSP, DO.VIGENCIA, DO.OBSERVACION, UM.DESCRIPCION AS UM, PRO.CODIGOPROVEEDOR, PRO.NOMBRE AS PROVEEDOR, ")
        strSQL.Append(" PC.CODIGOLICITACION, vv_CATALOGOPRODUCTOS.CORRPRODUCTO AS CODIGOARTICULO, ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS.NOMBRE AS ESTABLECIMIENTO, SAB_CAT_TIPOCOMPRAS.DESCRIPCION AS TIPOCOMPRA, ")
        strSQL.Append(" (SELECT COUNT(DO1.IDPROVEEDOR) AS paginas ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA AS DO1 INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS AS PC1 ON DO1.IDESTABLECIMIENTO = PC1.IDESTABLECIMIENTO AND ")
        strSQL.Append(" DO1.IDPROCESOCOMPRA = PC1.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS PRO1 ON DO1.IDPROVEEDOR = PRO1.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS AS UM1 ON DO1.IDUNIDADMEDIDA = UM1.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA AS DPC1 ON PC1.IDPROCESOCOMPRA = DPC1.IDPROCESOCOMPRA AND ")
        strSQL.Append(" PC1.IDESTABLECIMIENTO = DPC1.IDESTABLECIMIENTO AND DO1.IDESTABLECIMIENTO = DPC1.IDESTABLECIMIENTO AND ")
        strSQL.Append(" DO1.IDPROCESOCOMPRA = DPC1.IDPROCESOCOMPRA AND DO1.RENGLON = DPC1.RENGLON INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS AS CP1 ON DPC1.IDPRODUCTO = CP1.IDPRODUCTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS AS EST1 ON PC1.IDESTABLECIMIENTO = EST1.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS AS TC1 ON PC1.IDTIPOCOMPRAEJECUTAR = TC1.IDTIPOCOMPRA ")
        strSQL.Append(" WHERE (DO1.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO) AND (DO1.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA) AND (DO1.IDPROVEEDOR = DO.IDPROVEEDOR) ")
        strSQL.Append(" GROUP BY DO1.IDESTABLECIMIENTO, DO1.IDPROCESOCOMPRA, DO1.IDPROVEEDOR) ")
        strSQL.Append(" AS PAGINAS ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA AS DO INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS AS PC ON DO.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" DO.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS PRO ON DO.IDPROVEEDOR = PRO.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS AS UM ON DO.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA ON PC.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" PC.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" DO.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" DO.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" DO.RENGLON = SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS ON SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = vv_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS ON PC.IDESTABLECIMIENTO = SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS ON PC.IDTIPOCOMPRAEJECUTAR = SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA ")
        strSQL.Append("WHERE (DO.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (DO.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        If IDPROVEEDOR <> 0 Then
            strSQL.Append(" AND (DO.IDPROVEEDOR = " & IDPROVEEDOR & ") ")
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerCantidadOfertas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT COUNT(IDDETALLE) ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerProveedoresAdjudXRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDRENGLON As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append(" DPC.RENGLON, ")
        strSQL.Append(" isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
        strSQL.Append(" isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
        strSQL.Append(" isnull(P.NOMBRE, '') PROVEEDOR, ")
        strSQL.Append(" CP.DESCLARGO DESCRIPCIONGENERICA, ")
        strSQL.Append(" CP.DESCRIPCION UNIDADMEDIDA, ")
        'strSQL.Append(" --isnull(DO.DESCRIPCIONPROVEEDOR, '') DESCRIPCIONPROVEEDOR, ")
        strSQL.Append(" isnull(A.CANTIDADADJUDICADA, 0) CANTIDAD, ")
        strSQL.Append(" isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
        strSQL.Append(" isnull(DO.PRECIOUNITARIO * A.CANTIDADFIRME, 0) MONTO ")
        'strSQL.Append(" --isnull(DPC.OBSERVACIONRECOMENDACION, '') OBSERVACIONES ")
        strSQL.Append(" FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append(" INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append(" ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append(" ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append(" AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append(" AND DPC.RENGLON = DO.RENGLON) ")
        strSQL.Append(" INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append(" ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append(" AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append(" AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
        strSQL.Append(" INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append(" ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append(" INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
        strSQL.Append(" AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
        strSQL.Append(" AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
        strSQL.Append(" AND DO.IDDETALLE = A.IDDETALLE) ")
        strSQL.Append(" WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        'strSQL.Append(" --AND A.CANTIDADFIRME > 0 ")
        strSQL.Append(" and DPC.RENGLON = @IDRENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDRENGLON", SqlDbType.BigInt)
        args(2).Value = IDRENGLON

        Dim tables(0) As String
        tables(0) = New String("ProveedoresAfectados")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Public Function ObtenerMontoOfertado(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32) As Decimal

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT sum(cantidad*preciounitario) ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(2).Value = IDPROVEEDOR

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerDataSetIdDetalleOfertaXrENGLON(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal RENGLON As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDDETALLE FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
