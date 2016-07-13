Partial Public Class dbCONTRATOS

    ''' <summary>
    ''' Devuelve el listado de los renglones.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del Establecimiento al que pertenece la la tabla.</param>
    ''' <param name="IDALMACEN">Identificador que me dice cual es la existecia.</param>
    ''' <param name="IDPROVEEDOR">Identificador del almace de entrega para ese renglon.</param>
    ''' <param name="IDCONTRATO">Identificador unico del contrato.</param>
    ''' <param name="RENGLON">Identificador del renglon que se a seleccionado</param>
    ''' <returns>Dataset con el listado de los renglones</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  03/01/2007    Creado
    ''' </history> 
    Public Function ObtenerRenglonesPendientesTotales(ByVal IDESTABLECIMIENTO As Int32, ByVal IDALMACEN As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32, ByVal RENGLON As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("  pc.IDESTABLECIMIENTO, ")
        strSQL.Append("  aec.IDPROVEEDOR, ")
        strSQL.Append("  aec.IDCONTRATO, ")
        strSQL.Append("  aec.IDALMACENENTREGA, ")
        strSQL.Append("  pc.RENGLON, ")
        strSQL.Append("  pc.IDPRODUCTO, ")
        strSQL.Append("  cp.CORRPRODUCTO, ")
        strSQL.Append("  cp.DESCLARGO, ")
        strSQL.Append("  pc.PRECIOUNITARIO, ")
        strSQL.Append("  pc.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("  pc.IDUNIDADMEDIDA, ")
        strSQL.Append("  cp.DESCRIPCION, ")
        strSQL.Append("  SUM(pc.CANTIDAD) AS CANTOTALSOLICITADA, ")
        strSQL.Append("  SUM(aec.CANTIDAD) AS CANTIDADENTREGA, ")
        strSQL.Append("  SUM(aec.CANTIDADENTREGADA) AS CANTIDADENTREGAALMACEN, ")
        strSQL.Append("  aec.IDDETALLE ")
        strSQL.Append("FROM ")
        strSQL.Append("  SAB_UACI_ENTREGACONTRATO ec ")
        strSQL.Append("    INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS aec ")
        strSQL.Append("      ON ec.IDESTABLECIMIENTO = aec.IDESTABLECIMIENTO AND ")
        strSQL.Append("         ec.IDPROVEEDOR = aec.IDPROVEEDOR AND ")
        strSQL.Append("         ec.IDCONTRATO = aec.IDCONTRATO AND ")
        strSQL.Append("         ec.RENGLON = aec.RENGLON AND ")
        strSQL.Append("         ec.IDDETALLE = aec.IDDETALLE ")
        strSQL.Append("    INNER JOIN SAB_CAT_PROVEEDORES p ")
        strSQL.Append("      ON aec.IDPROVEEDOR = p.IDPROVEEDOR ")
        strSQL.Append("    INNER JOIN SAB_UACI_PRODUCTOSCONTRATO pc ")
        strSQL.Append("      ON ec.IDESTABLECIMIENTO = pc.IDESTABLECIMIENTO AND ")
        strSQL.Append("         ec.IDPROVEEDOR = pc.IDPROVEEDOR AND ")
        strSQL.Append("         ec.IDCONTRATO = pc.IDCONTRATO AND ")
        strSQL.Append("         ec.RENGLON = pc.RENGLON ")
        strSQL.Append("    INNER JOIN vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("      ON pc.IDPRODUCTO = cp.IDPRODUCTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(pc.ESTAHABILITADO = 1) ")

        If IDESTABLECIMIENTO > 0 Then
            strSQL.Append("AND (pc.IDESTABLECIMIENTO = " + Str(IDESTABLECIMIENTO) + ") ")
        End If

        If IDALMACEN > 0 Then
            strSQL.Append("AND (aec.IDALMACENENTREGA = " + Str(IDALMACEN) + ") ")
        End If

        If IDPROVEEDOR > 0 Then
            strSQL.Append("AND (pc.IDPROVEEDOR = " + Str(IDPROVEEDOR) + ") ")
        End If

        If IDCONTRATO > 0 Then
            strSQL.Append("AND (pc.IDCONTRATO = " + Str(IDCONTRATO) + ") ")
        End If

        If RENGLON > 0 Then
            strSQL.Append("AND (pc.RENGLON = " + Str(RENGLON) + ") ")
        End If

        strSQL.Append("GROUP BY ")
        strSQL.Append("pc.IDESTABLECIMIENTO, aec.IDPROVEEDOR, aec.IDCONTRATO, aec.IDALMACENENTREGA, ")
        strSQL.Append("pc.RENGLON, pc.IDPRODUCTO, cp.CORRPRODUCTO, pc.PRECIOUNITARIO, ")
        strSQL.Append("pc.DESCRIPCIONPROVEEDOR, pc.IDUNIDADMEDIDA, cp.DESCRIPCION, cp.DESCLARGO, aec.IDDETALLE ")
        strSQL.Append("HAVING (SUM(aec.CANTIDAD) > SUM(aec.CANTIDADENTREGADA)) ")
        strSQL.Append("ORDER BY pc.RENGLON ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerRenglonesPendientesTotales2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDALMACEN As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32, ByVal RENGLON As Int32, ByVal IDSUMINISTRO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.CANTIDADDECIMAL, aec.IDFUENTEFINANCIAMIENTO, CF.NOMBRE, ")
        strSQL.Append("SUM(PC.CANTIDAD) CANTOTALSOLICITADA, ")
        strSQL.Append("SUM(AEC.CANTIDAD) CANTIDADENTREGA, ")
        strSQL.Append("SUM(AEC.CANTIDADENTREGADA) CANTIDADENTREGAALMACEN, ")
        strSQL.Append("SUM(AEC.CANTIDAD) - SUM(AEC.CANTIDADENTREGADA) CANTIDADPENDIENTE ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("ON EC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO AND ")
        strSQL.Append("EC.IDPROVEEDOR = AEC.IDPROVEEDOR AND ")
        strSQL.Append("EC.IDCONTRATO = AEC.IDCONTRATO AND ")
        strSQL.Append("EC.RENGLON = AEC.RENGLON AND ")
        strSQL.Append("EC.IDDETALLE = AEC.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON AEC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON EC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND ")
        strSQL.Append("EC.IDPROVEEDOR = PC.IDPROVEEDOR AND ")
        strSQL.Append("EC.IDCONTRATO = PC.IDCONTRATO AND ")
        strSQL.Append("EC.RENGLON = PC.RENGLON ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER join dbo.SAB_CAT_FUENTEFINANCIAMIENTOS cf ")
        strSQL.Append("on cf.IDFUENTEFINANCIAMIENTO = aec.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(PC.ESTAHABILITADO = 1) ")
        strSQL.Append("AND (PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (AEC.IDALMACENENTREGA = @IDALMACEN) ")
        strSQL.Append("AND (PC.IDPROVEEDOR = @IDPROVEEDOR) ")
        strSQL.Append("AND (PC.IDCONTRATO = @IDCONTRATO) ")
        strSQL.Append("AND ((PC.RENGLON = @RENGLON) OR @RENGLON = 0) ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("CP.CANTIDADDECIMAL, ")
        strSQL.Append("CP.DESCLARGO , aec.IDFUENTEFINANCIAMIENTO , CF.NOMBRE ") 'Se agrega fuente de financiamiento para validar contratos//Mayra Martinez//15032012
        strSQL.Append("HAVING (SUM(AEC.CANTIDAD) > SUM(AEC.CANTIDADENTREGADA)) ")
        strSQL.Append("ORDER BY PC.RENGLON ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = IDALMACEN
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(3).Value = IDCONTRATO
        args(4) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(4).Value = RENGLON
        args(5) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(5).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve todos los renglones habilitados, con o sin entregas pendientes.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <param name="TODOS">Indica si se deben devolver todos los renglones (valor 1) o sólo aquellos on entregas pendientes (valor 0)</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_PRODUCTOSCONTRATO</item>
    ''' <item>SAB_UACI_ENTREGACONTRATO</item>
    ''' <item>SAB_UACI_ALMACENESENTREGACONTRATOS</item>
    ''' <item>SAB_CAT_PROVEEDORES</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_UACI_PRODUCTOSCONTRATO</item>
    ''' <item>SAB_UACI_PRODUCTOSCONTRATO</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]   Creado
    ''' </history>
    Public Function ObtenerRenglonesPendientesTotales(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32, ByVal TODOS As Byte) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROVEEDOR, ")
        strSQL.Append("PC.IDCONTRATO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.CANTIDAD, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.DESCLARGO ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = EC.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = EC.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = EC.IDCONTRATO ")
        strSQL.Append("AND PC.RENGLON = EC.RENGLON) ")
        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("ON (EC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = AEC.IDCONTRATO ")
        strSQL.Append("AND EC.RENGLON = AEC.RENGLON ")
        strSQL.Append("AND EC.IDDETALLE = AEC.IDDETALLE) ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON PC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE PC.ESTAHABILITADO = 1 ")
        strSQL.Append("AND PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND ((AEC.CANTIDAD > AEC.CANTIDADENTREGADA AND @TODOS = 0) OR @TODOS = 1) ")
        strSQL.Append("ORDER BY PC.RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@TODOS", SqlDbType.TinyInt)
        args(3).Value = TODOS

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve el listado de los renglones cruzada con las entregas por hacer en los almacenes filtrados.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del Establecimiento al que pertenece la la tabla.</param>
    ''' <param name="IDALMACEN">Identificador que me dice cual es la existecia.</param>
    ''' <param name="IDPROVEEDOR">Identificador del almace de entrega para ese renglon.</param>
    ''' <param name="IDCONTRATO">Identificador unico del contrato.</param>
    ''' <param name="RENGLON">Identificador del renglon que se a seleccionado</param>
    ''' <returns>Dataset con el listado de los renglones</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  03/01/2007    Creado
    ''' </history> 
    Public Function ObtenerRenglonesPendientesDetallado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDALMACEN As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32, ByVal RENGLON As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("EC.IDDETALLE, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("UM.DESCRIPCION, ")
        strSQL.Append("PC.CANTIDAD CANTOTALSOLICITADA, ")
        strSQL.Append("AEC.CANTIDAD CANTIDADENTREGA, ")
        strSQL.Append("AEC.CANTIDADENTREGADA CANTIDADENTREGAALMACEN, ")
        strSQL.Append("PC.ESTAHABILITADO ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("ON EC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO AND EC.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = AEC.IDCONTRATO AND EC.RENGLON = AEC.RENGLON AND EC.IDDETALLE = AEC.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON AEC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON EC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND EC.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = PC.IDCONTRATO AND EC.RENGLON = PC.RENGLON ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
        strSQL.Append("ON PC.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("WHERE ")
        strSQL.Append("PC.ESTAHABILIDATADO = 1 AND AEC.CANTIDAD > AEC.CANTIDADENTREGADA ")

        If IDESTABLECIMIENTO > 0 Then
            strSQL.Append("AND (pc.IDESTABLECIMIENTO = " + Str(IDESTABLECIMIENTO) + ") ")
        End If

        If IDALMACEN > 0 Then
            strSQL.Append("pc.IDALMACEN = " + Str(IDALMACEN) + ") ")
        End If

        If IDPROVEEDOR > 0 Then
            strSQL.Append("pc.IDPROVEEDOR = " + Str(IDPROVEEDOR) + ") ")
        End If

        If IDCONTRATO > 0 Then
            strSQL.Append("pc.IDCONTRATO = " + Str(IDCONTRATO) + ") ")
        End If

        If RENGLON > 0 Then
            strSQL.Append("pc.RENGLON = " + RENGLON + ") ")
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve el listado de proveedores con entregas pendiente.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén (Filtro).</param>
    ''' <param name="IDTIPODOCUMENTO">Identificador del tipo de documento (Filtro).</param> 
    ''' <returns>Dataset con el listado de proveedores.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>SAB_UACI_ENTREGAMODIFICATIVA</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGAMODIFICATIVA</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  30/12/2006    Creado
    ''' </history> 
    Public Function ObtenerProveedoresEntregasPendiente(ByVal IDALMACEN As Int32, Optional ByVal IDTIPODOCUMENTO As Int16 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE NOMBREPROVEEDOR ")
        'strSQL.Append("C.IDTIPODOCUMENTO ")
        strSQL.Append("FROM SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("ON (EC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = AEC.IDCONTRATO ")
        strSQL.Append("AND EC.RENGLON = AEC.RENGLON ")
        strSQL.Append("AND EC.IDDETALLE = AEC.IDDETALLE) ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON AEC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON EC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND EC.IDPROVEEDOR = C.IDPROVEEDOR AND EC.IDCONTRATO = C.IDCONTRATO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(EC.ESTAHABILITADA = 1) ")
        'If IDTIPODOCUMENTO = 0 Then
        '    strSQL.Append(" AND ((C.IDTIPODOCUMENTO = 1) OR (C.IDTIPODOCUMENTO = 3)) ")
        'Else
        '    strSQL.Append(" AND (C.IDTIPODOCUMENTO = @IDTIPODOCUMENTO) ")
        'End If
        strSQL.Append("AND (AEC.IDALMACENENTREGA = @IDALMACEN OR @IDALMACEN = 0) ")
        strSQL.Append("GROUP BY AEC.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE ")
        strSQL.Append("HAVING SUM(AEC.CANTIDAD) > SUM(AEC.CANTIDADENTREGADA) ")
        strSQL.Append("ORDER BY NOMBREPROVEEDOR ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(1).Value = IDTIPODOCUMENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerProveedoresAnticiposPendiente(ByVal IDALMACEN As Int32, Optional ByVal IDTIPODOCUMENTO As Int16 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select ")
        strSQL.Append("   distinct a.idproveedor, p.nombre nombreproveedor, 1 as IDTIPODOCUMENTO ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_UACI_ADJUDICACION a ")
        strSQL.Append("     inner join SAB_CAT_PROVEEDORES p ")
        strSQL.Append("       on a.idproveedor = p.idproveedor ")
        strSQL.Append("     inner join SAB_UACI_ENTREGAADJUDICACION ea ")
        strSQL.Append("       on a.idestablecimiento = ea.idestablecimiento and ")
        strSQL.Append("          a.idprocesocompra = ea.idprocesocompra and ")
        strSQL.Append("          a.idproveedor = ea.idproveedor and ")
        strSQL.Append("          a.iddetalle = ea.iddetalle ")
        strSQL.Append("     inner join SAB_UACI_ALMACENESENTREGAADJUDICACION aea ")
        strSQL.Append(" 	  on ea.idestablecimiento = aea.idestablecimiento and ")
        strSQL.Append("          ea.idprocesocompra = aea.idprocesocompra and ")
        strSQL.Append("          ea.idproveedor = aea.idproveedor and ")
        strSQL.Append("          ea.iddetalle = aea.iddetalle and ")
        strSQL.Append("          ea.identrega = aea.identrega ")
        strSQL.Append(" 	left outer join SAB_UACI_CONTRATOSPROCESOCOMPRA cpc ")
        strSQL.Append("       on a.idestablecimiento = cpc.idestablecimiento and ")
        strSQL.Append("          a.idprocesocompra = cpc.idprocesocompra and ")
        strSQL.Append("          a.idproveedor = cpc.idproveedor ")
        strSQL.Append(" where ")
        strSQL.Append("   cantidadfirme > 0 and ")
        strSQL.Append("   cpc.idcontrato is null and ")
        strSQL.Append("   aea.IDALMACEN = @IDALMACEN ")
        strSQL.Append("ORDER BY NOMBREPROVEEDOR ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(1).Value = IDTIPODOCUMENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Similar al anterior, devuelve todos los proveedores con contratos distribuidos.
    ''' </summary>
    ''' <param name="TODOS">Determina si se devuelven todos los proveedores o sólo aquellos que tienen entregas pendientes.  Por defecto es cero, que indica sólo con entregas pendientes.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerProveedoresEntregasPendiente(ByVal TODOS As Byte) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE NOMBREPROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (EC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("ON (EC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = AEC.IDCONTRATO ")
        strSQL.Append("AND EC.RENGLON = AEC.RENGLON ")
        strSQL.Append("AND EC.IDDETALLE = AEC.IDDETALLE) ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON AEC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE EC.ESTAHABILITADA = 1 ")
        strSQL.Append("AND C.IDESTADOCONTRATO = 3 ")
        strSQL.Append("AND ((AEC.CANTIDAD > AEC.CANTIDADENTREGADA AND @TODOS = 0) OR @TODOS = 1) ")
        strSQL.Append("ORDER BY NOMBREPROVEEDOR ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@TODOS", SqlDbType.TinyInt)
        args(0).Value = TODOS

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve el listado de documentos pendientes por proveedor de un almacén especifico.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén. (Filtro)</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor. (Filtro)</param>
    ''' <param name="IDTIPODOCUMENTO">Identificador del tipo de documento. (Filtro)</param> 
    ''' <returns>Dataset con el listado de documentos pendientes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>SAB_UACI_ENTREGAMODIFICATIVA</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGAMODIFICATIVA</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  30/12/2006    Creado
    ''' </history>
    Public Function ObtenerAnticiposPendientesPorProveedorDS(ByVal IDALMACEN As Int32, ByVal IDPROVEEDOR As Int32, Optional ByVal IDTIPODOCUMENTO As Int16 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select distinct ")
        strSQL.Append("   pc.idestablecimiento, a.idproveedor, pc.idprocesocompra as idcontrato, ")
        strSQL.Append("   pc.numeroresolucion as numerocontrato, aea.idalmacen, e.nombre as establecimientocontrato, ")
        strSQL.Append("   1 as IDTIPODOCUMENTO, 'Resolución' as TIPODOC ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_UACI_ADJUDICACION a ")
        strSQL.Append("     inner join SAB_UACI_PROCESOCOMPRAS pc ")
        strSQL.Append("       on a.idestablecimiento = pc.idestablecimiento and ")
        strSQL.Append(" 		 a.idprocesocompra = pc.idprocesocompra ")
        strSQL.Append("     inner join SAB_CAT_PROVEEDORES p ")
        strSQL.Append("       on a.idproveedor = p.idproveedor ")
        strSQL.Append("     inner join SAB_CAT_ESTABLECIMIENTOS e ")
        strSQL.Append("       on pc.idestablecimiento = e.idestablecimiento ")
        strSQL.Append("     inner join SAB_UACI_ENTREGAADJUDICACION ea ")
        strSQL.Append("       on a.idestablecimiento = ea.idestablecimiento and ")
        strSQL.Append(" 		 a.idprocesocompra = ea.idprocesocompra and ")
        strSQL.Append(" 		 a.idproveedor = ea.idproveedor and ")
        strSQL.Append(" 		 a.iddetalle = ea.iddetalle ")
        strSQL.Append("     inner join SAB_UACI_ALMACENESENTREGAADJUDICACION aea ")
        strSQL.Append(" 	  on ea.idestablecimiento = aea.idestablecimiento and ")
        strSQL.Append(" 		 ea.idprocesocompra = aea.idprocesocompra and ")
        strSQL.Append(" 		 ea.idproveedor = aea.idproveedor and ")
        strSQL.Append(" 		 ea.iddetalle = aea.iddetalle and ")
        strSQL.Append(" 		 ea.identrega = aea.identrega ")
        strSQL.Append(" 	left outer join SAB_UACI_CONTRATOSPROCESOCOMPRA cpc ")
        strSQL.Append("       on a.idestablecimiento = cpc.idestablecimiento and ")
        strSQL.Append(" 		 a.idprocesocompra = cpc.idprocesocompra and ")
        strSQL.Append(" 		 a.idproveedor = cpc.idproveedor ")
        strSQL.Append(" where ")
        strSQL.Append("   cantidadfirme > 0 and ")
        strSQL.Append("   cpc.idcontrato is null and ")
        strSQL.Append("   aea.IDALMACEN = @IDALMACEN and a.IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(2).Value = IDTIPODOCUMENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDocumentosPendientesPorProveedorDS(ByVal IDALMACEN As Int32, ByVal IDPROVEEDOR As Int32, Optional ByVal IDTIPODOCUMENTO As Int16 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("aec.IDESTABLECIMIENTO, ")
        strSQL.Append("aec.IDPROVEEDOR, ")
        strSQL.Append("aec.IDCONTRATO, ")
        strSQL.Append("c.NUMEROCONTRATO, ")
        strSQL.Append("aec.IDALMACENENTREGA, ")
        strSQL.Append("e.NOMBRE AS ESTABLECIMIENTOCONTRATO, ")
        strSQL.Append("c.IDTIPODOCUMENTO, ")
        strSQL.Append("TPC.DESCRIPCION AS TIPODOC ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_UACI_ENTREGACONTRATO ec ")
        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS aec ")
        strSQL.Append("ON ec.IDESTABLECIMIENTO = aec.IDESTABLECIMIENTO AND ec.IDPROVEEDOR = aec.IDPROVEEDOR AND ec.IDCONTRATO = aec.IDCONTRATO ")
        strSQL.Append("AND ec.RENGLON = aec.RENGLON AND ec.IDDETALLE = aec.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES p ")
        strSQL.Append("ON aec.IDPROVEEDOR = p.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS c ")
        strSQL.Append("ON aec.IDCONTRATO = c.IDCONTRATO AND aec.IDPROVEEDOR = c.IDPROVEEDOR AND aec.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS e ")
        strSQL.Append("ON aec.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO TPC ")
        strSQL.Append("ON c.IDTIPODOCUMENTO = TPC.IDTIPODOCUMENTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(ec.ESTAHABILITADA = 1) AND (aec.CANTIDAD - aec.CANTIDADENTREGADA > 0) ")
        strSQL.Append("AND (aec.IDALMACENENTREGA = @IDALMACEN) AND (c.IDPROVEEDOR = @IDPROVEEDOR) ")

        'If IDTIPODOCUMENTO = 0 Then
        '    strSQL.Append("AND ((c.IDTIPODOCUMENTO = 2) OR (c.IDTIPODOCUMENTO = 3) OR (c.IDTIPODOCUMENTO = 4))")
        'Else
        '    strSQL.Append("AND (c.IDTIPODOCUMENTO = @IDTIPODOCUMENTO) ")
        'End If

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(2).Value = IDTIPODOCUMENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve todos los documentos correspondientes al proveedor indicado.
    ''' </summary>
    ''' <param name="IDPROVEEDOR">Indica el proveedor para el cual se efectúa la búsqueda</param>
    ''' <param name="TODOS">Determina si se devuelven todos los documentos o sólo aquellos que tienen entregas pendientes.  Por defecto es cero, que indica sólo con entregas pendientes.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>SAB_CAT_MODALIDADESCOMPRA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerDocumentosPendientesPorProveedor(ByVal IDPROVEEDOR As Integer, ByVal TODOS As Byte) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("C.IDESTABLECIMIENTO, ")
        strSQL.Append("C.IDPROVEEDOR, ")
        strSQL.Append("C.IDCONTRATO, ")
        strSQL.Append("isnull(MC.DESCRIPCION, '') MODALIDADCOMPRA, ")
        strSQL.Append("isnull(C.NUMEROMODALIDADCOMPRA, 0) NUMEROMODALIDADCOMPRA, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("C.FECHADISTRIBUCION, ")
        strSQL.Append("isnull(PCOM.NUMERORESOLUCION, '') NUMERORESOLUCION, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS C ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("ON (C.IDESTABLECIMIENTO = EC.IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = EC.IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = EC.IDCONTRATO) ")
        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("ON (EC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = AEC.IDCONTRATO ")
        strSQL.Append("AND EC.RENGLON = AEC.RENGLON ")
        strSQL.Append("AND EC.IDDETALLE = AEC.IDDETALLE) ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON C.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON C.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON (C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = CPC.IDCONTRATO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_PROCESOCOMPRAS PCOM ")
        strSQL.Append("ON (CPC.IDESTABLECIMIENTO = PCOM.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = PCOM.IDPROCESOCOMPRA) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_MODALIDADESCOMPRA MC ")
        strSQL.Append("ON C.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append("WHERE C.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND C.IDESTADOCONTRATO = 3 ") 'VERIFICAR CONTRATO DISTRIBUIDO
        strSQL.Append("AND EC.ESTAHABILITADA = 1 ")
        strSQL.Append("AND ((AEC.CANTIDAD > AEC.CANTIDADENTREGADA AND @TODOS = 0) OR @TODOS = 1) ")
        'TODO: AGREGAR FILTRO PARA QUE RETORNE SOLO PROVEEDORES CON PRODUCTOS DE MEDICAMENTOS
        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(0).Value = IDPROVEEDOR
        args(1) = New SqlParameter("@TODOS", SqlDbType.TinyInt)
        args(1).Value = TODOS

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve un listado de los documentos de compras pendientes de cierre, muestra unicamente la
    ''' información de la tabla padre.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">El ID del establecimiento.</param>
    ''' <param name="IDPROVEEDOR">El ID del proveedor.</param>
    ''' <param name="IDTIPODOCUMENTO">El ID del tipo de documento.</param>
    ''' <param name="NCONTRATO">El numero de contrato que se desea recuperar.</param>
    ''' <param name="IDTIPOCONSULTA">Identificador del tipo de consulta que se desea aplicar.</param>
    ''' <returns>Dataset con el listado de documentos de compras.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  29/12/2006    Creado
    ''' </history> 
    Public Function ObtenerDsContratos(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADOCONTRATO As Int16, ByVal IDPROVEEDOR As Int32, ByVal IDTIPODOCUMENTO As Int16, ByVal NUMEROCONTRATO As String, ByVal IDPRODUCTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("C.IDESTABLECIMIENTO, ")
        strSQL.Append("C.IDPROVEEDOR, ")
        strSQL.Append("C.IDCONTRATO, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("C.IDTIPODOCUMENTO, ")
        strSQL.Append("C.TIPOPERSONA, ")
        strSQL.Append("C.REPRESENTANTELEGAL, ")
        strSQL.Append("C.PERSONERIAJURIDICA, ")
        strSQL.Append("C.FECHAGENERACION, ")
        strSQL.Append("C.FECHAAPROBACION, ")
        strSQL.Append("C.IDESTADOCONTRATO, ")
        strSQL.Append("PR.NOMBRE AS NOMBREPROVEEDOR, ")
        strSQL.Append("TD.DESCRIPCION AS DESCRIPCIONTIPODOCUMENTO ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS AS C ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO AS TD ")
        strSQL.Append("ON C.IDTIPODOCUMENTO = TD.IDTIPODOCUMENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_PROVEEDORES AS PR ")
        strSQL.Append("ON C.IDPROVEEDOR = PR.IDPROVEEDOR ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON C.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND C.IDPROVEEDOR = PC.IDPROVEEDOR AND C.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("WHERE C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDESTADOCONTRATO = @IDESTADOCONTRATO ")
        strSQL.Append("AND (C.IDPROVEEDOR = @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")
        strSQL.Append("AND (C.IDTIPODOCUMENTO = @IDTIPODOCUMENTO OR @IDTIPODOCUMENTO = 0) ")
        strSQL.Append("AND (C.NUMEROCONTRATO = @NUMEROCONTRATO OR @NUMEROCONTRATO = '') ")
        strSQL.Append("AND (PC.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) ")
        strSQL.Append("ORDER BY C.FECHAGENERACION ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDESTADOCONTRATO", SqlDbType.Int)
        args(1).Value = IDESTADOCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(3).Value = IDTIPODOCUMENTO
        args(4) = New SqlParameter("@NUMEROCONTRATO", SqlDbType.VarChar)
        args(4).Value = NUMEROCONTRATO
        args(5) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(5).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function obterProveedoresGenerarContrato(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA, SAB_CAT_PROVEEDORES.NOMBRE, '' AS RENGLONES, '' AS CONTRATO_GENERADO ")
        strSQL.Append(" FROM SAB_UACI_DETALLEPROCESOCOMPRA INNER JOIN ")
        strSQL.Append("  SAB_UACI_DETALLEOFERTA ON ")
        strSQL.Append("  SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append("  SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append("  SAB_UACI_DETALLEPROCESOCOMPRA.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE AND ")
        strSQL.Append("  SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON = SAB_UACI_DETALLEOFERTA.RENGLON INNER JOIN ")
        strSQL.Append("  SAB_UACI_RECEPCIONOFERTAS ON ")
        strSQL.Append("  SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO AND ")
        strSQL.Append("  SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("  SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR INNER JOIN ")
        strSQL.Append("  SAB_CAT_PROVEEDORES ON SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR INNER JOIN ")
        strSQL.Append("  SAB_UACI_ADJUDICACION ON SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA AND ")
        strSQL.Append("  SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO AND ")
        strSQL.Append("  SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_UACI_ADJUDICACION.IDPROVEEDOR AND ")
        strSQL.Append("  SAB_UACI_DETALLEOFERTA.IDDETALLE = SAB_UACI_ADJUDICACION.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append("  (SAB_UACI_ADJUDICACION.IDPROVEEDOR = " & IDPROVEEDOR & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Recupera la información de los contratos con el estado de guardado cruzada con la fuente de 
    ''' financiamiento.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <returns>Datareader con la información de los contratos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' <item><description>SAB_CAT_ESTADOSCONTRATOS</description></item>
    ''' <item><description>SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  04/01/2007    Creado
    ''' </history> 
    Public Function ObtenerContratosDR(ByVal IDESTABLECIMIENTO As Int32) As SqlDataReader

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select ")
        strSQL.Append("c.idtipodocumento AS IDTIPO, tdc.descripcion AS TIPODOCUMENTO, ")
        strSQL.Append("c.idcontrato AS IDCONTRATO, c.numerocontrato AS NUMCONTRATO, ")
        strSQL.Append("c.idproveedor AS IDPROVEEDOR, p.nombre as PROVEEDOR, ")
        strSQL.Append("c.idestadocontrato AS IDESTADO, ec.descripcion AS ESTADO, ")
        strSQL.Append("ffc.idfuentefinanciamiento AS IDFUENTE, ff.nombre AS FUENTE ")
        strSQL.Append("from ")
        strSQL.Append("SAB_UACI_CONTRATOS c ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO tdc ")
        strSQL.Append("ON c.idtipodocumento = tdc.idtipodocumento ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES p ")
        strSQL.Append("ON c.idproveedor = p.idproveedor ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSCONTRATOS ec ")
        strSQL.Append("ON c.idestadocontrato = ec.idestadocontrato ")
        strSQL.Append("INNER JOIN SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS ffc ")
        strSQL.Append("ON c.idestablecimiento = ffc.idestablecimiento AND ")
        strSQL.Append("c.idcontrato = ffc.idcontrato ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS ff ")
        strSQL.Append("ON ffc.idfuentefinanciamiento = ff.idfuentefinanciamiento ")
        strSQL.Append("where ")
        strSQL.Append("c.idestablecimiento = @IDESTABLECIMIENTO AND c.idestadocontrato = 1 ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return dr

    End Function

    ''' <summary>
    ''' obtener cuales contratos etan asociados a un proceso de compra
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA"></param> 'identificador del proceso de compra
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <returns>
    ''' Dataset con contratos por proceso de compra
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPR</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list> 
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerContratosOfertaXProcesoCompra(ByVal IDPROCESOCOMPRA As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT cpc.IDPROCESOCOMPRA, c.IDCONTRATO, c.IDPROVEEDOR, c.IDESTABLECIMIENTO, c.NUMEROCONTRATO, c.IDTIPODOCUMENTO, ")
        strSQL.Append("c.FECHAGENERACION, ro.ORDENLLEGADA AS OFERTA, SAB_CAT_TIPODOCUMENTOCONTRATO.DESCRIPCION AS DOCUMENTO, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.NOMBRE AS PROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS AS c INNER JOIN ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc ON c.IDESTABLECIMIENTO = cpc.IDESTABLECIMIENTO AND ")
        strSQL.Append("c.IDPROVEEDOR = cpc.IDPROVEEDOR AND c.IDCONTRATO = cpc.IDCONTRATO INNER JOIN ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS AS ro ON cpc.IDESTABLECIMIENTO = ro.IDESTABLECIMIENTO AND ")
        strSQL.Append("cpc.IDPROCESOCOMPRA = ro.IDPROCESOCOMPRA AND cpc.IDPROVEEDOR = ro.IDPROVEEDOR INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPODOCUMENTOCONTRATO ON c.IDTIPODOCUMENTO = SAB_CAT_TIPODOCUMENTOCONTRATO.IDTIPODOCUMENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES ON c.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append("WHERE c.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND cpc.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener los contratos de un proceso de compra filtrado por numero de contrato
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA"></param> 'identificador del proceso de compra
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDCODIGO"></param> 'codigo del contrato utilizado por el MSPAS
    ''' <returns>
    ''' Dataset con contratos que cumplan con el filtro de numero de contrato
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list> </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerContratosOfertaXProcesoCompraXNumeroContrato(ByVal IDPROCESOCOMPRA As Int32, ByVal IDESTABLECIMIENTO As Int32, ByVal IDCODIGO As String) As DataSet
        Dim codigo As String
        codigo = "%" & IDCODIGO & "%"

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT cpc.IDPROCESOCOMPRA, c.IDCONTRATO, c.IDPROVEEDOR, c.IDESTABLECIMIENTO, c.NUMEROCONTRATO, c.IDTIPODOCUMENTO, ")
        strSQL.Append("c.FECHAGENERACION, ro.ORDENLLEGADA AS OFERTA, SAB_CAT_TIPODOCUMENTOCONTRATO.DESCRIPCION AS DOCUMENTO, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.NOMBRE AS PROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS AS c INNER JOIN ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc ON c.IDESTABLECIMIENTO = cpc.IDESTABLECIMIENTO AND ")
        strSQL.Append("c.IDPROVEEDOR = cpc.IDPROVEEDOR AND c.IDCONTRATO = cpc.IDCONTRATO INNER JOIN ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS AS ro ON cpc.IDESTABLECIMIENTO = ro.IDESTABLECIMIENTO AND ")
        strSQL.Append("cpc.IDPROCESOCOMPRA = ro.IDPROCESOCOMPRA AND cpc.IDPROVEEDOR = ro.IDPROVEEDOR INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPODOCUMENTOCONTRATO ON c.IDTIPODOCUMENTO = SAB_CAT_TIPODOCUMENTOCONTRATO.IDTIPODOCUMENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES ON c.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append("WHERE c.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND cpc.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND c.NUMEROCONTRATO LIKE @IDCODIGO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDCODIGO", SqlDbType.VarChar)
        args(2).Value = codigo

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener contratos que cumplan con el filto de proveedor
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA"></param> 'identificador del proceso de compra
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROVEEDOR"></param> 'identificador del proveedor
    ''' <returns>
    ''' Dataset con contratos filtrado por proveedor
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerContratosOfertaXProcesoCompraXProveedor(ByVal IDPROCESOCOMPRA As Int32, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT cpc.IDPROCESOCOMPRA, c.IDCONTRATO, c.IDPROVEEDOR, c.IDESTABLECIMIENTO, c.NUMEROCONTRATO, c.IDTIPODOCUMENTO, ")
        strSQL.Append("c.FECHAGENERACION, ro.ORDENLLEGADA AS OFERTA, SAB_CAT_TIPODOCUMENTOCONTRATO.DESCRIPCION AS DOCUMENTO, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.NOMBRE AS PROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS AS c INNER JOIN ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc ON c.IDESTABLECIMIENTO = cpc.IDESTABLECIMIENTO AND ")
        strSQL.Append("c.IDPROVEEDOR = cpc.IDPROVEEDOR AND c.IDCONTRATO = cpc.IDCONTRATO INNER JOIN ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS AS ro ON cpc.IDESTABLECIMIENTO = ro.IDESTABLECIMIENTO AND ")
        strSQL.Append("cpc.IDPROCESOCOMPRA = ro.IDPROCESOCOMPRA AND cpc.IDPROVEEDOR = ro.IDPROVEEDOR INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPODOCUMENTOCONTRATO ON c.IDTIPODOCUMENTO = SAB_CAT_TIPODOCUMENTOCONTRATO.IDTIPODOCUMENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES ON c.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append("WHERE c.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND cpc.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND SAB_CAT_PROVEEDORES.NOMBRE LIKE @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.VarChar)
        args(2).Value = "%" & IDPROVEEDOR & "%"

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener cuales fueron los renglones adjudicados para un contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDCONTRATO"></param> 'identificador del contrato
    ''' <returns>
    ''' Dataset con la informacion del renglon adjudicado
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' </list> 
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 

    Public Function obtenerRenglonesAdjudicadosXContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT c.IDCONTRATO, c.IDPROVEEDOR, c.IDESTABLECIMIENTO, c.NUMEROCONTRATO, c.FECHAGENERACION, do.RENGLON ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS AS c INNER JOIN ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO AS do ON c.IDESTABLECIMIENTO = do.IDESTABLECIMIENTO AND ")
        strSQL.Append("c.IDCONTRATO = do.IDCONTRATO AND c.IDPROVEEDOR = do.IDPROVEEDOR ")
        strSQL.Append("WHERE c.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND c.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND c.IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(1).Value = IDCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function RenglonesAdjudicadosPorOferta() As DataSet

        Dim NumOferta As Integer
        Dim Proveedor As String = String.Empty
        Dim Renglon As String = String.Empty
        Dim IdProcesoCompra As Integer
        Dim IdContrato As Integer
        Dim IdProveedor As Integer = 0
        Dim IdEstablecimiento As Integer
        Dim NumeroContrato As String = String.Empty
        Dim IdEstadoCalificacion As Integer

        Dim strSQL As New Text.StringBuilder
        Dim col As New DataColumn
        Dim tbl As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        Dim iniciado As Boolean = False

        col.ColumnName = "NUMOFERTA"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn

        col.ColumnName = "PROVEEDOR"
        col.DataType = System.Type.GetType("System.String")
        tbl.Columns.Add(col)

        col = New DataColumn

        col.ColumnName = "RENGLON"
        col.DataType = System.Type.GetType("System.String")
        tbl.Columns.Add(col)

        col = New DataColumn

        col.ColumnName = "IDPROCESOCOMPRA"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn

        col.ColumnName = "IDCONTRATO"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn

        col.ColumnName = "IDPROVEEDOR"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn

        col.ColumnName = "IDESTABLECIMIENTO"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn

        col.ColumnName = "NUMEROCONTRATO"
        col.DataType = System.Type.GetType("System.String")
        tbl.Columns.Add(col)

        col = New DataColumn

        col.ColumnName = "IDESTADOCALIFICACION"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        strSQL.Append(" SELECT ro.ORDENLLEGADA as NumOferta,SAB_CAT_PROVEEDORES.NOMBRE AS PROVEEDOR, do.RENGLON, cpc.IDPROCESOCOMPRA, c.IDCONTRATO, c.IDPROVEEDOR, c.IDESTABLECIMIENTO, c.NUMEROCONTRATO, ")
        strSQL.Append("                       do.IDESTADOCALIFICACION ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS AS c INNER JOIN ")
        strSQL.Append("              SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc ON c.IDESTABLECIMIENTO = cpc.IDESTABLECIMIENTO AND ")
        strSQL.Append("                       c.IDPROVEEDOR = cpc.IDPROVEEDOR AND c.IDCONTRATO = cpc.IDCONTRATO INNER JOIN ")
        strSQL.Append("              SAB_UACI_RECEPCIONOFERTAS AS ro ON cpc.IDESTABLECIMIENTO = ro.IDESTABLECIMIENTO AND ")
        strSQL.Append("                       cpc.IDPROCESOCOMPRA = ro.IDPROCESOCOMPRA AND cpc.IDPROVEEDOR = ro.IDPROVEEDOR INNER JOIN ")
        strSQL.Append("              SAB_UACI_DETALLEOFERTA AS do ON ro.IDESTABLECIMIENTO = do.IDESTABLECIMIENTO AND ")
        strSQL.Append("                       ro.IDPROCESOCOMPRA = do.IDPROCESOCOMPRA AND ro.IDPROVEEDOR = do.IDPROVEEDOR INNER JOIN ")
        strSQL.Append("              SAB_CAT_PROVEEDORES ON c.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")

        Dim cmd As SqlCommand
        Dim rs As SqlDataReader
        Dim SQLCnn As New SqlConnection
        SQLCnn.ConnectionString = cnnStr

        Dim dsError As New DataSet
        Try
            SQLCnn.Open()
        Catch ex As Exception
            Return dsError
        End Try

        Try
            cmd = New SqlCommand(strSQL.ToString, SQLCnn)
            rs = cmd.ExecuteReader

            Do While rs.Read

                If IdProveedor = 0 Then

                    'Se leen los datos y se almacenan en las variables
                    NumOferta = rs.Item("NUMOFERTA")
                    Proveedor = rs.Item("PROVEEDOR")
                    Renglon = rs.Item("RENGLON")
                    IdProcesoCompra = rs.Item("IDPROCESOCOMPRA")
                    IdContrato = rs.Item("IDCONTRATO")
                    IdProveedor = rs.Item("IDPROVEEDOR")
                    IdEstablecimiento = rs.Item("IDESTABLECIMIENTO")
                    NumeroContrato = rs.Item("NUMEROCONTRATO")
                    IdEstadoCalificacion = rs.Item("IDESTADOCALIFICACION")

                    iniciado = True
                Else

                    If IdProveedor <> rs.Item("IDPROVEEDOR") And _
                       IdContrato <> rs.Item("IDCONTRATO") Then

                        'Se crea la nueva fila
                        dr = tbl.NewRow

                        'Se agregan los datos
                        dr(0) = NumOferta
                        dr(1) = Proveedor
                        dr(2) = Renglon
                        dr(3) = IdProcesoCompra
                        dr(4) = IdContrato
                        dr(5) = IdProveedor
                        dr(6) = IdEstablecimiento
                        dr(7) = NumeroContrato
                        dr(8) = IdEstadoCalificacion

                        tbl.Rows.Add(dr)

                        NumOferta = rs.Item("NUMOFERTA")
                        Proveedor = rs.Item("PROVEEDOR")
                        Renglon = rs.Item("RENGLON")
                        IdProcesoCompra = rs.Item("IDPROCESOCOMPRA")
                        IdContrato = rs.Item("IDCONTRATO")
                        IdProveedor = rs.Item("IDPROVEEDOR")
                        IdEstablecimiento = rs.Item("IDESTABLECIMIENTO")
                        NumeroContrato = rs.Item("NUMEROCONTRATO")
                        IdEstadoCalificacion = rs.Item("IDESTADOCALIFICACION")

                    Else
                        Renglon = Renglon & ", " & rs.Item("RENGLON")
                    End If

                End If

            Loop

            'El ultimo valor
            If iniciado Then
                'Se crea la nueva fila
                dr = tbl.NewRow

                'Se agregan los datos
                dr(0) = NumOferta
                dr(1) = Proveedor
                dr(2) = Renglon
                dr(3) = IdProcesoCompra
                dr(4) = IdContrato
                dr(5) = IdProveedor
                dr(6) = IdEstablecimiento
                dr(7) = NumeroContrato
                dr(8) = IdEstadoCalificacion

                tbl.Rows.Add(dr)
            End If

            'Ahora se agrega el datatable al dataset 
            ds.Tables.Add(tbl)

            Return ds
        Catch ex As Exception
            Return dsError
        Finally
            SQLCnn.Close()
        End Try

    End Function

    ''' <summary>
    ''' Obtiene los renglones adjudicados por oferta.
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDEMPLEADO"></param>
    ''' <returns>Dataset con informacion de los renglones adjudicados</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function RenglonesAdjudicadosPorOferta2(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDEMPLEADO As Integer) As DataSet

        Dim NumOferta As Integer
        Dim Proveedor As String = String.Empty
        Dim Renglon As String = String.Empty
        Dim IdPC As Integer
        Dim IdContrato As Integer
        Dim IdProveedor As Integer = 0
        Dim NumeroContrato As String = String.Empty
        Dim IdEstadoCalificacion As Integer
        Dim IdEstadoContrato As String = String.Empty
        Dim CodigoLicitacion As String = String.Empty

        Dim col As DataColumn
        Dim tbl As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        Dim iniciado As Boolean = False

        col = New DataColumn
        col.ColumnName = "NUMOFERTA"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "PROVEEDOR"
        col.DataType = System.Type.GetType("System.String")
        tbl.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "RENGLON"
        col.DataType = System.Type.GetType("System.String")
        tbl.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "IDPROCESOCOMPRA"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "IDCONTRATO"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "IDPROVEEDOR"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "IDESTABLECIMIENTO"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "NUMEROCONTRATO"
        col.DataType = System.Type.GetType("System.String")
        tbl.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "IDESTADOCALIFICACION"
        col.DataType = System.Type.GetType("System.Int32")
        tbl.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "IDESTADOCONTRATO"
        col.DataType = System.Type.GetType("System.String")
        tbl.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "CODIGOLICITACION"
        col.DataType = System.Type.GetType("System.String")
        tbl.Columns.Add(col)

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("RO.ORDENLLEGADA AS NUMOFERTA, ")
        strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
        strSQL.Append("DO.RENGLON, ")
        strSQL.Append("CPC.IDPROCESOCOMPRA, ")
        strSQL.Append("C.IDCONTRATO, ")
        strSQL.Append("C.IDPROVEEDOR, ")
        strSQL.Append("C.IDESTABLECIMIENTO, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("DO.IDESTADOCALIFICACION, ")
        strSQL.Append("case C.IDESTADOCONTRATO ")
        strSQL.Append("when 1 then 'GENERADO' ")
        strSQL.Append("when 2 then 'LIBERADO' ")
        strSQL.Append("when 3 then 'DISTRIBUIDO' ")
        strSQL.Append("end IDESTADOCONTRATO ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS AS C ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA AS CPC ")
        strSQL.Append("ON C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = CPC.IDCONTRATO ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAs AS PC ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS AS RO ")
        strSQL.Append("ON CPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND CPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA AS DO ")
        strSQL.Append("ON RO.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND RO.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND RO.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON C.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_ANALISTAPROVEEDORES AP ")
        strSQL.Append("ON CPC.IDESTABLECIMIENTO = AP.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = AP.IDPROCESOCOMPRA ")
        strSQL.Append("AND CPC.IDPROVEEDOR = AP.IDPROVEEDOR ")
        strSQL.Append("WHERE CPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND (AP.IDANALISTA = @IDEMPLEADO OR @IDEMPLEADO = 0) ")
        strSQL.Append("AND A.CANTIDADFIRME > 0 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(2).Value = IDEMPLEADO

        Dim rs As SqlDataReader
        rs = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

        If rs.HasRows Then

            Do While rs.Read

                If IdProveedor = 0 Then

                    'Se leen los datos y se almacenan en las variables
                    NumOferta = rs.Item("NUMOFERTA")
                    Proveedor = rs.Item("PROVEEDOR")
                    Renglon = rs.Item("RENGLON")
                    IdPC = rs.Item("IDPROCESOCOMPRA")
                    IdContrato = rs.Item("IDCONTRATO")
                    IdProveedor = rs.Item("IDPROVEEDOR")
                    IDESTABLECIMIENTO = rs.Item("IDESTABLECIMIENTO")
                    NumeroContrato = rs.Item("NUMEROCONTRATO")
                    IdEstadoCalificacion = rs.Item("IDESTADOCALIFICACION")
                    IdEstadoContrato = rs.Item("IDESTADOCONTRATO")
                    CodigoLicitacion = rs.Item("CODIGOLICITACION")

                    iniciado = True
                Else

                    If IdProveedor <> rs.Item("IDPROVEEDOR") Or _
                       IdContrato <> rs.Item("IDCONTRATO") Then

                        'Se crea la nueva fila
                        dr = tbl.NewRow

                        'Se agregan los datos
                        dr(0) = NumOferta
                        dr(1) = Proveedor
                        dr(2) = Renglon
                        dr(3) = IdPC
                        dr(4) = IdContrato
                        dr(5) = IdProveedor
                        dr(6) = IDESTABLECIMIENTO
                        dr(7) = NumeroContrato
                        dr(8) = IdEstadoCalificacion
                        dr(9) = IdEstadoContrato
                        dr(10) = CodigoLicitacion

                        tbl.Rows.Add(dr)

                        NumOferta = rs.Item("NUMOFERTA")
                        Proveedor = rs.Item("PROVEEDOR")
                        Renglon = rs.Item("RENGLON")
                        IdPC = rs.Item("IDPROCESOCOMPRA")
                        IdContrato = rs.Item("IDCONTRATO")
                        IdProveedor = rs.Item("IDPROVEEDOR")
                        IDESTABLECIMIENTO = rs.Item("IDESTABLECIMIENTO")
                        NumeroContrato = rs.Item("NUMEROCONTRATO")
                        IdEstadoCalificacion = rs.Item("IDESTADOCALIFICACION")
                        IdEstadoContrato = rs.Item("IDESTADOCONTRATO")
                        CodigoLicitacion = rs.Item("CODIGOLICITACION")

                    Else
                        Renglon = Renglon & ", " & rs.Item("RENGLON")
                    End If

                End If

            Loop

            'El ultimo valor
            If iniciado Then
                'Se crea la nueva fila
                dr = tbl.NewRow

                'Se agregan los datos
                dr(0) = NumOferta
                dr(1) = Proveedor
                dr(2) = Renglon
                dr(3) = IdPC
                dr(4) = IdContrato
                dr(5) = IdProveedor
                dr(6) = IDESTABLECIMIENTO
                dr(7) = NumeroContrato
                dr(8) = IdEstadoCalificacion
                dr(9) = IdEstadoContrato
                dr(10) = CodigoLicitacion

                tbl.Rows.Add(dr)
            End If

        End If

        'Ahora se agrega el datatable al dataset 
        ds.Tables.Add(tbl)

        rs.Close()

        Return ds

    End Function

    Public Function ActualizarRetornaEntidad(ByRef aEntidad As CONTRATOS) As Integer

        Dim lID As Long
        If aEntidad.IDCONTRATO = 0 _
            Or aEntidad.IDCONTRATO = Nothing Then

            lID = Me.ObtenerID(aEntidad)

            If lID = -1 Then Return -1

            aEntidad.IDCONTRATO = lID

            Return Agregar(aEntidad)

        End If

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_CONTRATOS ")
        strSQL.Append(" SET NUMEROCONTRATO = @NUMEROCONTRATO, ")
        strSQL.Append(" IDTIPODOCUMENTO = @IDTIPODOCUMENTO, ")
        strSQL.Append(" IDPLANTILLA = @IDPLANTILLA, ")
        strSQL.Append(" TIPOPERSONA = @TIPOPERSONA, ")
        strSQL.Append(" REPRESENTANTELEGAL = @REPRESENTANTELEGAL, ")
        strSQL.Append(" PERSONERIAJURIDICA = @PERSONERIAJURIDICA, ")
        strSQL.Append(" FECHAGENERACION = @FECHAGENERACION, ")
        strSQL.Append(" FECHAAPROBACION = @FECHAAPROBACION, ")
        strSQL.Append(" FECHADISTRIBUCION = @FECHADISTRIBUCION, ")
        strSQL.Append(" CODIGOLICITACION = @CODIGOLICITACION, ")
        strSQL.Append(" FECHAINICIOENTREGA = @FECHAINICIOENTREGA, ")
        strSQL.Append(" IDESTADOCONTRATO = @IDESTADOCONTRATO, ")
        strSQL.Append(" IDCALIFICACIONCUMPLIMIENTO = @IDCALIFICACIONCUMPLIMIENTO, ")
        strSQL.Append(" IDCALIFICACIONCALIDAD = @IDCALIFICACIONCALIDAD, ")
        strSQL.Append(" IDMODALIDADCOMPRA = @IDMODALIDADCOMPRA, ")
        strSQL.Append(" NUMEROMODALIDADCOMPRA = @NUMEROMODALIDADCOMPRA, ")
        strSQL.Append(" MONTOCONTRATO = @MONTOCONTRATO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(24) As SqlParameter
        args(0) = New SqlParameter("@NUMEROCONTRATO", SqlDbType.VarChar)
        args(0).Value = aEntidad.NUMEROCONTRATO
        args(1) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.SmallInt)
        args(1).Value = aEntidad.IDTIPODOCUMENTO
        args(2) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(2).Value = IIf(aEntidad.IDPLANTILLA = Nothing, DBNull.Value, aEntidad.IDPLANTILLA)
        args(3) = New SqlParameter("@TIPOPERSONA", SqlDbType.VarChar)
        args(3).Value = aEntidad.TIPOPERSONA
        args(4) = New SqlParameter("@REPRESENTANTELEGAL", SqlDbType.VarChar)
        args(4).Value = aEntidad.REPRESENTANTELEGAL
        args(5) = New SqlParameter("@PERSONERIAJURIDICA", SqlDbType.VarChar)
        args(5).Value = IIf(IsNothing(aEntidad.PERSONERIAJURIDICA), DBNull.Value, aEntidad.PERSONERIAJURIDICA)
        args(6) = New SqlParameter("@FECHAGENERACION", SqlDbType.DateTime)
        args(6).Value = aEntidad.FECHAGENERACION
        args(7) = New SqlParameter("@FECHAAPROBACION", SqlDbType.DateTime)
        args(7).Value = IIf(aEntidad.FECHAAPROBACION = Nothing, DBNull.Value, aEntidad.FECHAAPROBACION)
        args(8) = New SqlParameter("@FECHADISTRIBUCION", SqlDbType.DateTime)
        args(8).Value = IIf(aEntidad.FECHADISTRIBUCION = Nothing, DBNull.Value, aEntidad.FECHADISTRIBUCION)
        args(9) = New SqlParameter("@CODIGOLICITACION", SqlDbType.VarChar)
        args(9).Value = IIf(aEntidad.CODIGOLICITACION = Nothing, DBNull.Value, aEntidad.CODIGOLICITACION)
        args(10) = New SqlParameter("@FECHAINICIOENTREGA", SqlDbType.DateTime)
        args(10).Value = IIf(aEntidad.FECHAINICIOENTREGA = Nothing, DBNull.Value, aEntidad.FECHAINICIOENTREGA)
        args(11) = New SqlParameter("@IDESTADOCONTRATO", SqlDbType.SmallInt)
        args(11).Value = aEntidad.IDESTADOCONTRATO
        args(12) = New SqlParameter("@IDCALIFICACIONCUMPLIMIENTO", SqlDbType.SmallInt)
        args(12).Value = IIf(aEntidad.IDCALIFICACIONCUMPLIMIENTO = Nothing, DBNull.Value, aEntidad.IDCALIFICACIONCUMPLIMIENTO)
        args(13) = New SqlParameter("@IDCALIFICACIONCALIDAD", SqlDbType.SmallInt)
        args(13).Value = IIf(aEntidad.IDCALIFICACIONCALIDAD = Nothing, DBNull.Value, aEntidad.IDCALIFICACIONCALIDAD)
        args(14) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.TinyInt)
        args(14).Value = IIf(aEntidad.IDMODALIDADCOMPRA = Nothing, DBNull.Value, aEntidad.IDMODALIDADCOMPRA)
        args(15) = New SqlParameter("@NUMEROMODALIDADCOMPRA", SqlDbType.VarChar)
        args(15).Value = IIf(aEntidad.NUMEROMODALIDADCOMPRA = Nothing, DBNull.Value, aEntidad.NUMEROMODALIDADCOMPRA)
        args(16) = New SqlParameter("@MONTOCONTRATO", SqlDbType.Decimal)
        args(16).Value = aEntidad.MONTOCONTRATO
        args(17) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(17).Value = IIf(aEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args(18) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(18).Value = IIf(aEntidad.AUFECHACREACION = Nothing, DBNull.Value, aEntidad.AUFECHACREACION)
        args(19) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(19).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(20) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(20).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(21) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(21).Value = aEntidad.ESTASINCRONIZADA
        args(22) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(22).Value = aEntidad.IDESTABLECIMIENTO
        args(23) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(23).Value = aEntidad.IDPROVEEDOR
        args(24) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(24).Value = aEntidad.IDCONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarPersoneriaJuridicaActaNotarial(ByVal aEntidad As CONTRATOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_CONTRATOS SET ")
        strSQL.Append(" PERSONERIAJURIDICA = @PERSONERIAJURIDICA, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA, ")
        strSQL.Append(" ACTANOTARIAL = @ACTANOTARIAL ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@PERSONERIAJURIDICA", SqlDbType.VarChar)
        args(0).Value = IIf(IsNothing(aEntidad.PERSONERIAJURIDICA), DBNull.Value, aEntidad.PERSONERIAJURIDICA)
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = aEntidad.IDESTABLECIMIENTO
        args(5) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(5).Value = aEntidad.IDPROVEEDOR
        args(6) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(6).Value = aEntidad.IDCONTRATO
        args(7) = New SqlParameter("@ACTANOTARIAL", SqlDbType.VarChar)
        args(7).Value = IIf(IsNothing(aEntidad.ACTANOTARIAL), DBNull.Value, aEntidad.ACTANOTARIAL)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ElaboraContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPLANTILLA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CL.NOMBRE, ")
        strSQL.Append("CP.CONTENIDO CONTENIDO, ")
        strSQL.Append("CP.ORDEN, ")
        strSQL.Append("C.PERSONERIAJURIDICA, ")
        strSQL.Append("C.ACTANOTARIAL ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS C ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND C.IDPROVEEDOR = CPC.IDPROVEEDOR AND C.IDCONTRATO = CPC.IDCONTRATO ")

        'strSQL.Append("INNER JOIN SAB_UACI_CLAUSULASCONTRATOS CC ")
        'strSQL.Append("ON C.IDESTABLECIMIENTO = CC.IDESTABLECIMIENTO AND C.IDPROVEEDOR = CC.IDPROVEEDOR AND C.IDCONTRATO = CC.IDCONTRATO ")

        strSQL.Append(" INNER JOIN SAB_UACI_CLAUSULASPLANTILLA CP ")
        strSQL.Append(" ON CP.IDESTABLECIMIENTO=c.IDESTABLECIMIENTO  ")

        strSQL.Append("INNER JOIN SAB_CAT_CLAUSULAS CL ")
        strSQL.Append("ON CP.IDCLAUSULA = CL.IDCLAUSULA ")
        strSQL.Append("WHERE C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        'strSQL.Append("AND C.IDPROVEEDOR = @IDPROVEEDOR ")
        'strSQL.Append("AND C.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND CP.IDPLANTILLA = @IDPLANTILLA ")
        strSQL.Append("group by CL.NOMBRE, CP.CONTENIDO, CP.ORDEN, C.PERSONERIAJURIDICA, C.ACTANOTARIAL  ")
        strSQL.Append("ORDER BY CP.ORDEN ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(3).Value = IDPROCESOCOMPRA
        args(4) = New SqlParameter("@IDPLANTILLA", SqlDbType.BigInt)
        args(4).Value = IDPLANTILLA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ElaboraOficioAdj(ByVal IDPLANTILLA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("			CL.NOMBRE,  ")
        strSQL.Append("			CP.CONTENIDO CONTENIDO,  ")
        strSQL.Append("			CP.ORDEN ")
        strSQL.Append("			 ")
        strSQL.Append("        FROM SAB_UACI_CLAUSULASPLANTILLA CP  ")
        strSQL.Append("			 			 INNER JOIN SAB_CAT_CLAUSULAS CL  ")
        strSQL.Append("			 ON CP.IDCLAUSULA = CL.IDCLAUSULA  ")
        strSQL.Append("        WHERE  CP.IDPLANTILLA = @IDPLANTILLA  ")
        strSQL.Append("        ORDER BY CP.ORDEN  ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(0).Value = IDPLANTILLA
        'args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        'args(1).Value = IDPROVEEDOR
        'args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        'args(2).Value = IDCONTRATO
        'args(3) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        'args(3).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ElaboraModificativaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_CLAUSULAS.NOMBRE, SAB_UACI_CLAUSULASCONTRATOS.ENCABEZADOCLAUSULA AS CONTENIDO, ")
        strSQL.Append(" SAB_UACI_CLAUSULASCONTRATOS.ORDEN, SAB_UACI_CONTRATOS.PERSONERIAJURIDICA ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_CLAUSULASCONTRATOS ON ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CLAUSULASCONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_UACI_CLAUSULASCONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDCONTRATO = SAB_UACI_CLAUSULASCONTRATOS.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_CAT_CLAUSULAS ON SAB_UACI_CLAUSULASCONTRATOS.IDCLAUSULA = SAB_CAT_CLAUSULAS.IDCLAUSULA ")
        strSQL.Append(" WHERE (SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ") AND ")
        strSQL.Append(" (SAB_UACI_CONTRATOS.IDCONTRATO = " & IDCONTRATO & ") AND (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (SAB_UACI_CLAUSULASCONTRATOS.IDMODIFICATIVA = 1) ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene la información de contratos por proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos.</param>
    ''' <param name="IDPROCESOCOMPRA">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function ObtenerDsContratosProcesoCompra(ByVal IDPROCESOCOMPRA As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT cpc.IDCONTRATO, c.NUMEROCONTRATO, cpc.IDPROVEEDOR, p.NOMBRE")
        strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc INNER JOIN")
        strSQL.Append(" SAB_UACI_CONTRATOS AS c ON cpc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO AND cpc.IDPROVEEDOR = c.IDPROVEEDOR AND ")
        strSQL.Append(" cpc.IDCONTRATO = c.IDCONTRATO INNER JOIN")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS p ON c.IDPROVEEDOR = p.IDPROVEEDOR ")
        strSQL.Append(" WHERE (cpc.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (cpc.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ' Cuando se quiere saber una cosa, lo mejor que se puede hacer es preguntarla.
    'obetener todos los contratos de los procesos de compra iniciados en el periodo especificado
    Public Function ObtenerDatasetContratosPorPeriodo(ByVal fini As Date, ByVal ffin As Date, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT cpc.IDCONTRATO, cpc.IDPROCESOCOMPRA, cpc.IDPROVEEDOR, Pc.CODIGOLICITACION AS PROCESOCOMPRA, c.NUMEROCONTRATO, ")
        strSQL.Append(" Pro.NOMBRE AS PROVEEDOR")
        strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc INNER JOIN")
        strSQL.Append(" SAB_UACI_CONTRATOS AS c ON cpc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO AND cpc.IDPROVEEDOR = c.IDPROVEEDOR AND ")
        strSQL.Append(" cpc.IDCONTRATO = c.IDCONTRATO INNER JOIN")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS AS Pc ON cpc.IDPROCESOCOMPRA = Pc.IDPROCESOCOMPRA AND ")
        strSQL.Append(" cpc.IDESTABLECIMIENTO = Pc.IDESTABLECIMIENTO INNER JOIN")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS Pro ON c.IDPROVEEDOR = Pro.IDPROVEEDOR AND cpc.IDPROVEEDOR = Pro.IDPROVEEDOR")
        strSQL.Append(" WHERE (cpc.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (Pc.FECHAINICIOPROCESOCOMPRA >= @fini) AND ")
        strSQL.Append(" (Pc.FECHAINICIOPROCESOCOMPRA <= @ffin) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@fini", SqlDbType.DateTime)
        args(1).Value = fini
        args(2) = New SqlParameter("@ffin", SqlDbType.DateTime)
        args(2).Value = ffin

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene información de contratos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos.</param>
    ''' <param name="IDPROCESOCOMPRA">Filtro para devolver los datos.</param>
    ''' <param name="IDCONTRATO">Filtro para devolver los datos.</param>
    ''' <param name="IDPROVEEDOR">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function DevolverContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCONTRATO As Int64, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT 0 AS RENGLON, '' AS CORRPRODUCTO, '' AS DESCLARGO, 0 AS CANTIDADENTREGAS, C.NUMEROCONTRATO, P.NOMBRE AS NOMBRECONTRATO, '' AS NOMBREALMACEN, '' AS CODIGOPROVEEDOR, '' AS NOMBREPROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_CONTRATOSPROCESOCOMPRA CPC INNER JOIN ")
        strSQL.Append("SAB_UACI_CONTRATOS C ON CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        strSQL.Append("CPC.IDPROVEEDOR = C.IDPROVEEDOR AND ")
        strSQL.Append("CPC.IDCONTRATO = C.IDCONTRATO INNER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES P ON CPC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND CPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND CPC.IDCONTRATO = @IDCONTRATO AND CPC.IDPROVEEDOR = @IDPROVEEDOR")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(3).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function obtenerProductosAdjudicadosProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DPC.IDPRODUCTO, DO.RENGLON, DO.IDUNIDADMEDIDA, SUM(AEA.CANTIDAD) AS CANTIDADFIRME, DO.PRECIOUNITARIO, DO.DESCRIPCIONPROVEEDOR ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA as DO INNER JOIN SAB_UACI_ADJUDICACION as AD ON DO.IDPROCESOCOMPRA = AD.IDPROCESOCOMPRA AND ")
        strSQL.Append(" DO.IDESTABLECIMIENTO = AD.IDESTABLECIMIENTO AND DO.IDPROVEEDOR = AD.IDPROVEEDOR AND DO.IDDETALLE = AD.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA as DPC ON DO.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO AND DO.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA AND ")
        strSQL.Append(" DO.RENGLON = DPC.RENGLON INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ON EA.IDESTABLECIMIENTO=AD.IDESTABLECIMIENTO AND EA.IDPROCESOCOMPRA=AD.IDPROCESOCOMPRA AND EA.IDPROVEEDOR=AD.IDPROVEEDOR AND EA.IDDETALLE=AD.IDDETALLE INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND AEA.IDDETALLE=EA.IDDETALLE AND AEA.IDENTREGA=EA.IDENTREGA ")
        strSQL.Append(" WHERE (DPC.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (DPC.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (DO.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (AD.CANTIDADFIRME > 0) AND (AEA.IDALMACEN NOT IN (144,499) OR AEA.IDESTABLECIMIENTO=661 )")
        strSQL.Append(" GROUP BY DPC.IDPRODUCTO,DO.RENGLON, DO.IDUNIDADMEDIDA,DO.PRECIOUNITARIO, DO.DESCRIPCIONPROVEEDOR ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerIDProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDPROVEEDOR FROM SAB_UACI_CONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & "  AND IDCONTRATO = " & IDCONTRATO & "")

        Dim ds As Integer
        ds = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene los proveedores contratados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos por establecimiento.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function obtenerProveedoresContratados(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT PC.CODIGOLICITACION, C.NUMEROCONTRATO, P.CODIGOPROVEEDOR, P.NOMBRE, ")
        strSQL.Append("C.MONTOCONTRATO, CONVERT(varchar(10), C.FECHADISTRIBUCION, 103) as FECHADISTRIBUCION, P.IDPROVEEDOR, C.IDCONTRATO ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS C INNER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES P ON C.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
        strSQL.Append("CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        strSQL.Append("CPC.IDCONTRATO = C.IDCONTRATO AND ")
        strSQL.Append("CPC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ON ")
        strSQL.Append("PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append("PC.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA ")
        strSQL.Append("WHERE (C.IDESTADOCONTRATO <> 2) ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve un listado la consulta de los contratos generados.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">El ID del establecimiento.</param>
    ''' <param name="IDPROVEEDOR">El ID del proveedor.</param>
    ''' <param name="IDTIPODOCUMENTO">El ID del tipo de documento.</param>
    ''' <param name="NCONTRATO">El numero de contrato que se desea recuperar.</param>
    ''' <param name="IDTIPOCONSULTA">Identificador del tipo de consulta que se desea aplicar.</param>
    ''' <returns>Dataset con el listado de documentos de compras.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:IDPRO
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  29/12/2006    Creado
    ''' </history> 
    Public Function ObtenerDsConsultaContratos(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDTIPODOCUMENTO As Int16, ByVal NCONTRATO As String, ByVal IDPRODUCTO As Int32, ByVal IDTIPOCONSULTA As Int16, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT ")
        strSQL.Append(" CO.IDESTABLECIMIENTO, CO.IDPROVEEDOR, CO.IDCONTRATO, CO.NUMEROCONTRATO, CO.IDTIPODOCUMENTO, CO.TIPOPERSONA, ")
        strSQL.Append(" CO.REPRESENTANTELEGAL, CO.PERSONERIAJURIDICA, CO.FECHAGENERACION, CO.FECHAAPROBACION, CO.IDESTADOCONTRATO, ")
        strSQL.Append(" PR.NOMBRE AS NOMBREPROVEEDOR, TD.DESCRIPCION AS DESCRIPCIONTIPODOCUMENTO, ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA, CO.CODIGOLICITACION, ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA AS NUMEROOFERTA, ")
        strSQL.Append("(SELECT count(IDDETALLE) ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION A1 ")
        strSQL.Append(" WHERE A1.IDESTABLECIMIENTO = CO.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A1.IDPROCESOCOMPRA = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A1.IDPROVEEDOR = CO.IDPROVEEDOR ")
        strSQL.Append(" AND A1.CANTIDADFIRME > 0) RENGLONESADJUDICADOS ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS AS CO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_CAT_TIPODOCUMENTOCONTRATO AS TD ON CO.IDTIPODOCUMENTO = TD.IDTIPODOCUMENTO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS PR ON CO.IDPROVEEDOR = PR.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO AS PC ON CO.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND CO.IDPROVEEDOR = PC.IDPROVEEDOR AND ")
        strSQL.Append(" CO.IDCONTRATO = PC.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA ON CO.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" CO.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append(" CO.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA AS SAB_UACI_CONTRATOSPROCESOCOMPRA_1 ON ")
        strSQL.Append(" CO.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA_1.IDESTABLECIMIENTO AND ")
        strSQL.Append(" CO.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA_1.IDPROVEEDOR AND ")
        strSQL.Append(" CO.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA_1.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS ON ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA_1.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA_1.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA_1.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR ")
        strSQL.Append("WHERE (CO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")

        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append("AND (CO.IDESTADOCONTRATO = 2) ")
        End Select

        If IDPROVEEDOR > 0 Then
            strSQL.Append(" AND (CO.IDPROVEEDOR = " + Str(IDPROVEEDOR) + ") ")
        End If

        If IDTIPODOCUMENTO > 0 Then
            strSQL.Append(" AND (CO.IDTIPODOCUMENTO = " + Str(IDTIPODOCUMENTO) + ") ")
        End If

        If NCONTRATO > "" Then
            strSQL.Append(" AND (CO.NUMEROCONTRATO = '" & NCONTRATO & "') ")
        End If

        If IDPRODUCTO > 0 Then
            strSQL.Append(" AND (PC.IDPRODUCTO = '" + Str(IDPRODUCTO) + "') ")
        End If

        If IDPROCESOCOMPRA > 0 Then
            strSQL.Append(" AND (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ")")
        End If

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function obtenerNEntregas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDRENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT COUNT(IDDETALLE) ")
        strSQL.Append("FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & " AND IDPROVEEDOR = " & IDPROVEEDOR & " AND IDCONTRATO = " & IDCONTRATO & " AND RENGLON = " & IDRENGLON & " ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function obtenerMontoContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_CONTRATOS.MONTOCONTRATO ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS INNER JOIN ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO ")
        strSQL.Append("WHERE (SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & " ) AND (SAB_UACI_CONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ") AND ")
        strSQL.Append("(SAB_UACI_CONTRATOS.IDCONTRATO = " & IDCONTRATO & ") AND (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function obtenerTotalMontoContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        'strSQL.Append(" SELECT sum(MONTO) ")
        'strSQL.Append(" FROM ")

        strSQL.Append(" SELECT SUM(AEA.CANTIDAD * SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO) AS Monto ")
        'strSQL.Append(" (SELECT SUM(SUM(AEA.CANTIDAD * SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO) AS Monto ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION A INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON A.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" A.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" A.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" A.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR ")
        strSQL.Append(" INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND EA.IDPROVEEDOR=A.IDPROVEEDOR AND EA.IDDETALLE=A.IDDETALLE INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND AEA.IDDETALLE=EA.IDDETALLE AND AEA.IDENTREGA=EA.IDENTREGA ")


        strSQL.Append(" WHERE (SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO = " & IDCONTRATO & ") ")
        strSQL.Append(" AND ( AEA.IDALMACEN NOT IN (114,499) OR a.IDESTABLECIMIENTO=661) ")
        '        strSQL.Append(" GROUP BY A.CANTIDADFIRME, SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO ")
        ' strSQL.Append(" HAVING (A.CANTIDADFIRME > 0)) A ")
        '       strSQL.Append(" HAVING (A.CANTIDADFIRME > 0) ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDatosContratoProcesoCompra(ByVal aEntidad As CONTRATOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("C.CODIGOLICITACION, ")
        strSQL.Append("PC.NUMERORESOLUCION ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND CPC.IDCONTRATO = C.IDCONTRATO ")
        strSQL.Append("WHERE ")
        strSQL.Append("C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = @IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = aEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDCONTRATO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dr.HasRows Then
            dr.Read()

            aEntidad.CODIGOLICITACION = IIf(IsDBNull(dr("CODIGOLICITACION")), "", dr("CODIGOLICITACION"))
            aEntidad.NUMEROMODALIDADCOMPRA = IIf(IsDBNull(dr("NUMERORESOLUCION")), "", dr("NUMERORESOLUCION"))
        End If

        dr.Close()

        Return 1

    End Function

    ''' <summary>
    ''' Obtiene el nombre de una dependencia.
    ''' </summary>
    ''' <param name="fechadistribucion">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="idprocesocompra">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="idestablecimiento">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Un valor entero indicando si la actualizacion se ha realizado con exito</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function ActualizarFechaDistribucion(ByVal FECHADISTRIBUCION As DateTime, ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer, Optional ByVal IDCONTRATO As Integer = 0, Optional ByVal IDPROVEEDOR As Integer = 0) As Integer

        actualizarFechaEntregaGarantias(FECHADISTRIBUCION, IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_CONTRATOS SET ")
        strSQL.Append(" FECHADISTRIBUCION = @FECHADISTRIBUCION ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS AS C, SAB_UACI_CONTRATOSPROCESOCOMPRA AS CP ")
        strSQL.Append(" WHERE C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        If IDPROVEEDOR <> 0 And IDCONTRATO <> 0 Then
            strSQL.Append(" AND C.IDPROVEEDOR = @IDPROVEEDOR ")
            strSQL.Append(" AND C.IDCONTRATO = @IDCONTRATO ")
        End If
        strSQL.Append(" AND CP.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@FECHADISTRIBUCION", SqlDbType.DateTime)
        args(0).Value = FECHADISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        If IDPROVEEDOR <> 0 And IDCONTRATO <> 0 Then
            args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
            args(2).Value = IDPROVEEDOR
            args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
            args(3).Value = IDCONTRATO
        End If
        args(4) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(4).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Sub actualizarFechaEntregaGarantias(ByVal FECHADISTRIBUCION As DateTime, ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer)

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" update sab_uaci_garantiascontratos ")
        strSQL.Append(" set fechaentrega = dateadd(day, entrega, @fechadistribucion) ")
        strSQL.Append(" where(idestablecimiento = @IDESTABLECIMIENTO) ")
        strSQL.Append(" and idproveedor = @IDPROVEEDOR ")
        strSQL.Append(" and idcontrato = @IDCONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(1).Value = IDCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@fechadistribucion", SqlDbType.DateTime)
        args(3).Value = FECHADISTRIBUCION
        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Sub

    Public Function actualizaFechaGeneracion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal FECHAAPROBACION As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" UPDATE SAB_UACI_CONTRATOS SET ")
        strSQL.Append(" FECHAGENERACION = GETDATE(), ")
        strSQL.Append(" FECHAAPROBACION = '" & FECHAAPROBACION & "' ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ") ")

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerContratosEnProcesoCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT CPC.IDESTABLECIMIENTO, CPC.IDPROCESOCOMPRA, ")
        strSQL.Append("        CPC.IDPROVEEDOR, CPC.IDCONTRATO ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS C INNER JOIN ")
        strSQL.Append("        SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
        strSQL.Append("        C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append("        C.IDPROVEEDOR = CPC.IDPROVEEDOR AND ")
        strSQL.Append("        C.IDCONTRATO = CPC.IDCONTRATO ")
        strSQL.Append(" WHERE C.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO)
        strSQL.Append(" AND CPC.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ActualizarEstadoContrato(ByVal aEntidad As CONTRATOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_CONTRATOS ")
        strSQL.Append("SET IDESTADOCONTRATO = @IDESTADOCONTRATO ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTADOCONTRATO", SqlDbType.SmallInt)
        args(0).Value = aEntidad.IDESTADOCONTRATO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = aEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(3).Value = aEntidad.IDCONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve la información de completa de un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento en el que fue elaborado.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <returns>Dataset con la información del contrato.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  29/12/2006    Creado
    ''' </history> 
    Public Function ObtenerContratoNoUACI(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CO.IDESTABLECIMIENTO, ")
        strSQL.Append("CO.IDPROVEEDOR, ")
        strSQL.Append("CO.IDCONTRATO, ")
        strSQL.Append("CO.NUMEROCONTRATO, ")
        strSQL.Append("CO.IDTIPODOCUMENTO, ")
        strSQL.Append("CO.TIPOPERSONA, ")
        strSQL.Append("CO.REPRESENTANTELEGAL, ")
        strSQL.Append("CO.PERSONERIAJURIDICA, ")
        strSQL.Append("CO.FECHAGENERACION, ")
        strSQL.Append("CO.FECHAAPROBACION, ")
        strSQL.Append("CO.IDESTADOCONTRATO, ")
        strSQL.Append("PR.NOMBRE NOMBREPROVEEDOR, ")
        strSQL.Append("TD.DESCRIPCION DESCRIPCIONTIPODOCUMENTO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("PC.CANTIDAD, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("RDC.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("FFC.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FFC.MONTOCONTRATADO, ")
        strSQL.Append("FF.NOMBRE NOMBREFUENTEFINANCIAMIENTO, ")
        strSQL.Append("RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        strSQL.Append("RD.NOMBRE NOMBRELARGORESPONSABLE, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION ")
        strSQL.Append("FROM ")
        strSQL.Append("vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON CP.IDPRODUCTO = PC.IDPRODUCTO ")
        strSQL.Append("RIGHT OUTER JOIN SAB_UACI_CONTRATOS CO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("INNER JOIN SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO RDC ")
        strSQL.Append("ON RD.IDRESPONSABLEDISTRIBUCION = RDC.IDRESPONSABLEDISTRIBUCION ON CO.IDESTABLECIMIENTO = RDC.IDESTABLECIMIENTO ")
        strSQL.Append("AND CO.IDPROVEEDOR = RDC.IDPROVEEDOR AND CO.IDCONTRATO = RDC.IDCONTRATO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("INNER JOIN SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS FFC ")
        strSQL.Append("ON FF.IDFUENTEFINANCIAMIENTO = FFC.IDFUENTEFINANCIAMIENTO ON CO.IDESTABLECIMIENTO = FFC.IDESTABLECIMIENTO ")
        strSQL.Append("AND CO.IDPROVEEDOR = FFC.IDPROVEEDOR AND CO.IDCONTRATO = FFC.IDCONTRATO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO TD ")
        strSQL.Append("ON CO.IDTIPODOCUMENTO = TD.IDTIPODOCUMENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_PROVEEDORES PR ")
        strSQL.Append("ON CO.IDPROVEEDOR = PR.IDPROVEEDOR ON PC.IDESTABLECIMIENTO = CO.IDESTABLECIMIENTO AND PC.IDPROVEEDOR = CO.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = CO.IDCONTRATO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(CO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (CO.IDESTADOCONTRATO = 1) ")
        strSQL.Append("AND (CO.IDPROVEEDOR = @IDPROVEEDOR) ")
        strSQL.Append("AND (CO.IDCONTRATO = @IDCONTRATO) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información de completa de un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento en el que fue elaborado.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <returns>Dataset con la información del contrato.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  29/12/2006    Creado
    ''' </history> 
    Public Function ObtenerContratoNoUACI2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CO.IDESTABLECIMIENTO, ")
        strSQL.Append("CO.IDPROVEEDOR, ")
        strSQL.Append("CO.IDCONTRATO, ")
        strSQL.Append("CO.NUMEROCONTRATO, ")
        strSQL.Append("CO.IDTIPODOCUMENTO, ")
        strSQL.Append("CO.TIPOPERSONA, ")
        strSQL.Append("CO.REPRESENTANTELEGAL, ")
        strSQL.Append("CO.PERSONERIAJURIDICA, ")
        strSQL.Append("CO.FECHAGENERACION, ")
        strSQL.Append("CO.FECHAAPROBACION, ")
        strSQL.Append("CO.IDESTADOCONTRATO, ")
        strSQL.Append("PR.NOMBRE NOMBREPROVEEDOR, ")
        strSQL.Append("TD.DESCRIPCION DESCRIPCIONTIPODOCUMENTO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("PC.CANTIDAD, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON CP.IDPRODUCTO = PC.IDPRODUCTO ")
        strSQL.Append("RIGHT OUTER JOIN SAB_UACI_CONTRATOS CO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO TD ")
        strSQL.Append("ON CO.IDTIPODOCUMENTO = TD.IDTIPODOCUMENTO LEFT OUTER JOIN SAB_CAT_PROVEEDORES PR ")
        strSQL.Append("ON CO.IDPROVEEDOR = PR.IDPROVEEDOR ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = CO.IDESTABLECIMIENTO AND PC.IDPROVEEDOR = CO.IDPROVEEDOR AND PC.IDCONTRATO = CO.IDCONTRATO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(CO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (CO.IDESTADOCONTRATO = 1) ")
        strSQL.Append("AND (CO.IDPROVEEDOR = @IDPROVEEDOR) ")
        strSQL.Append("AND (CO.IDCONTRATO = @IDCONTRATO) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    'Jrivas
    'Obteniendo las dependendias para el proceso de compra seleccionado
    Public Function obtenerDependenciasConsultaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_EST_SOLICITUDES.IDDEPENDENCIASOLICITANTE, SAB_CAT_DEPENDENCIAS.NOMBRE ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDESPROCESOCOMPRAS INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDES ON SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD = SAB_EST_SOLICITUDES.IDSOLICITUD AND ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTOSOLICITUD = SAB_EST_SOLICITUDES.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_DEPENDENCIAS ON SAB_EST_SOLICITUDES.IDDEPENDENCIASOLICITANTE = SAB_CAT_DEPENDENCIAS.IDDEPENDENCIA ")
        strSQL.Append(" WHERE (SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    'Jrivas
    'Obteniendo la Clase de Suministro
    Public Function obtenerClaseSuministroConsultaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_TIPOSUMINISTROS.DESCRIPCION ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS ON ")
        strSQL.Append(" SAB_EST_SOLICITUDES.IDSOLICITUD = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD AND ")
        strSQL.Append(" SAB_EST_SOLICITUDES.IDESTABLECIMIENTO = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTOSOLICITUD INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOSUMINISTROS ON SAB_EST_SOLICITUDES.IDCLASESUMINISTRO = SAB_CAT_TIPOSUMINISTROS.IDTIPOSUMINISTRO ")
        strSQL.Append(" WHERE (SAB_EST_SOLICITUDES.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function obteniendoFuenteFinanConsultaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE, SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.MONTOCONTRATADO AS MONTO ")
        strSQL.Append(" FROM SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_CAT_FUENTEFINANCIAMIENTOS ON ")
        strSQL.Append(" SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.IDFUENTEFINANCIAMIENTO = SAB_CAT_FUENTEFINANCIAMIENTOS.IDFUENTEFINANCIAMIENTO INNER ")
        strSQL.Append("  JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOS ON SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_CONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_CONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO = SAB_UACI_CONTRATOS.IDCONTRATO ON ")
        strSQL.Append(" SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOS.IDCONTRATO ")
        strSQL.Append(" WHERE (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")
        strSQL.Append(" AND (SAB_UACI_CONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    'Jrivas
    'Obteniendo el codigo de las bases y la fecha firma de aceptacion
    Public Function obteniendoCodigoBaseFechaAceptacionConsultaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT CODIGOLICITACION, CONVERT(varchar(10), FECHAFIRMAACEPTACION, 103) AS FECHAFIRMAACEPTACION ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    'Obteniendo fecha de distribucion hasta monto total
    Public Function obtenerFechaDistribucionAMontoTotal(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_CONTRATOS.FECHADISTRIBUCION, SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA, ")
        strSQL.Append(" SAB_CAT_PROVEEDORES.NOMBRE AS PROVEEDOR, SAB_UACI_CONTRATOS.TIPOPERSONA, SAB_UACI_CONTRATOS.MONTOCONTRATO ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS ON SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CONTRATOS.IDCONTRATO = " & IDCONTRATO & ") AND ")
        strSQL.Append(" (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (SAB_UACI_CONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ")")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    'Obteniendo los datos de la garantia
    Public Function obteniendoDatosGarantiaConsultaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_GARANTIASCONTRATOS.NUMEROGARANTIA, SAB_CAT_TIPOGARANTIAS.NOMBRE, SAB_UACI_GARANTIASCONTRATOS.ASEGURADORA, ")
        strSQL.Append(" SAB_UACI_GARANTIASCONTRATOS.MONTO, SAB_UACI_GARANTIASCONTRATOS.VIGENCIA ")
        strSQL.Append(" FROM SAB_UACI_GARANTIASCONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOGARANTIAS ON SAB_UACI_GARANTIASCONTRATOS.IDTIPOGARANTIA = SAB_CAT_TIPOGARANTIAS.IDTIPOGARANTIA ")
        strSQL.Append(" WHERE (SAB_UACI_GARANTIASCONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_GARANTIASCONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ") AND ")
        strSQL.Append(" (SAB_UACI_GARANTIASCONTRATOS.IDCONTRATO = " & IDCONTRATO & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function obteniendoInformacionProductosConsulta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_DETALLEOFERTA.RENGLON, SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.CANTIDADFIRME, SAB_CAT_UNIDADMEDIDAS.DESCRIPCION, convert(decimal(15,2),SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO) as PRECIOUNITARIO, ")
        strSQL.Append(" convert(decimal(15,2), SAB_UACI_ADJUDICACION.CANTIDADFIRME * SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO) AS MONTO, SAB_CAT_CATALOGOPRODUCTOS.CODIGO ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.RENGLON = SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS ON SAB_UACI_DETALLEPROCESOCOMPRA.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA ")
        strSQL.Append(" WHERE (SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (SAB_UACI_ADJUDICACION.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (SAB_UACI_ADJUDICACION.CANTIDADFIRME > 0) ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    'Obteniendo información de los productos
    Public Function obteniendoDetalleProductosConsulta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_ENTREGAADJUDICACION.IDENTREGA, SAB_UACI_ENTREGAADJUDICACION.CANTIDAD, SAB_CAT_UNIDADMEDIDAS.DESCRIPCION, ")
        strSQL.Append("  SAB_UACI_ENTREGAADJUDICACION.DIAS, SAB_CAT_ALMACENES.NOMBRE AS ALMACEN ")
        strSQL.Append(" FROM SAB_CAT_UNIDADMEDIDAS INNER JOIN ")
        strSQL.Append(" SAB_UACI_ADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE ON ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA = SAB_UACI_DETALLEOFERTA.IDUNIDADMEDIDA LEFT OUTER JOIN ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_ENTREGAADJUDICACION ON ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_ENTREGAADJUDICACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_ENTREGAADJUDICACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROVEEDOR = SAB_UACI_ENTREGAADJUDICACION.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDDETALLE = SAB_UACI_ENTREGAADJUDICACION.IDDETALLE AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDENTREGA = SAB_UACI_ENTREGAADJUDICACION.IDENTREGA INNER JOIN ")
        strSQL.Append(" SAB_CAT_ALMACENES ON SAB_UACI_ALMACENESENTREGAADJUDICACION.IDALMACEN = SAB_CAT_ALMACENES.IDALMACEN ON ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_ENTREGAADJUDICACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_ENTREGAADJUDICACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_ENTREGAADJUDICACION.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_ENTREGAADJUDICACION.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (SAB_UACI_ADJUDICACION.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (SAB_UACI_ADJUDICACION.CANTIDADFIRME > 0) AND ")
        strSQL.Append(" (SAB_UACI_DETALLEOFERTA.RENGLON = " & RENGLON & ") ")
        strSQL.Append(" ORDER BY ALMACEN, SAB_UACI_ENTREGAADJUDICACION.IDENTREGA ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function copiarDatosEntregaProductosContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCONTRATO As Integer, ByVal USUARIOCREACION As String, ByVal FECHACREACION As String, ByVal BORRAR As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_CopiarEntregas")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = IDPROCESOCOMPRA
        args(4) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = IDCONTRATO
        args(5) = New SqlParameter("@USUARIOCREACION", SqlDbType.VarChar)
        args(5).Direction = ParameterDirection.Input
        args(5).Value = USUARIOCREACION
        args(6) = New SqlParameter("@FECHACREACION", SqlDbType.DateTime)
        args(6).Direction = ParameterDirection.Input
        args(6).Value = FECHACREACION
        args(7) = New SqlParameter("@BORRAR", SqlDbType.VarChar)
        args(7).Direction = ParameterDirection.Input
        args(7).Value = BORRAR

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

    Public Function obtenerContratoModificativa(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT cpc.IDPROCESOCOMPRA, c.IDCONTRATO, c.IDPROVEEDOR, c.IDESTABLECIMIENTO, c.NUMEROCONTRATO, c.IDTIPODOCUMENTO, ")
        strSQL.Append(" c.FECHAGENERACION, ro.ORDENLLEGADA AS OFERTA, SAB_CAT_TIPODOCUMENTOCONTRATO.DESCRIPCION AS DOCUMENTO, ")
        strSQL.Append(" SAB_CAT_PROVEEDORES.NOMBRE AS PROVEEDOR, ")
        strSQL.Append(" (SELECT COUNT(RENGLONES) AS Expr1 ")
        strSQL.Append(" FROM (SELECT SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON AS RENGLONES ")
        strSQL.Append(" 		FROM SAB_UACI_CONTRATOS INNER JOIN ")
        strSQL.Append(" 		SAB_UACI_ALMACENESENTREGACONTRATOS ON ")
        strSQL.Append(" 		SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" 		SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_UACI_ALMACENESENTREGACONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append(" 		SAB_UACI_CONTRATOS.IDCONTRATO = SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO INNER JOIN ")
        strSQL.Append(" 		SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append(" 		SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" 		SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append(" 		SAB_UACI_CONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO ")
        strSQL.Append("			 WHERE (SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = 1) AND (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = 9) ")
        strSQL.Append(" 		GROUP BY SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON) AS A) AS NUNRENGLONES, ")
        strSQL.Append(" case when c.IDESTADOCONTRATO = 1 then 'Generado' when c.IDESTADOCONTRATO = 2 then 'Liberado' when c.IDESTADOCONTRATO = 3 then 'Distribuido' end as ESTADOCONTRATO ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS AS c INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc ON c.IDESTABLECIMIENTO = cpc.IDESTABLECIMIENTO AND ")
        strSQL.Append(" c.IDPROVEEDOR = cpc.IDPROVEEDOR AND c.IDCONTRATO = cpc.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS AS ro ON cpc.IDESTABLECIMIENTO = ro.IDESTABLECIMIENTO AND ")
        strSQL.Append(" cpc.IDPROCESOCOMPRA = ro.IDPROCESOCOMPRA AND cpc.IDPROVEEDOR = ro.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPODOCUMENTOCONTRATO ON c.IDTIPODOCUMENTO = SAB_CAT_TIPODOCUMENTOCONTRATO.IDTIPODOCUMENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON c.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append(" WHERE (c.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (cpc.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    'jmejia
    Public Function ObtenerDatasetContratosyOtrosDoc(ByVal IDTIPODOCUMENTO As Integer, ByVal NUMERODOCUMENTO As String, ByVal FECHADOCUMENTO As Date, _
      ByVal IDMODALIDAD As Integer, ByVal NUMEROMODALIDAD As String, ByVal IDFUENTE As Integer, _
      ByVal IDRESPONSABLE As Integer, ByVal IDALMACEN As Integer, ByVal IDTIPOSUMINISTRO As Integer, _
      ByVal PRODUCTO As String, ByVal IDPROVEEDOR As Integer, ByVal ENTREGA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT ")
        strSQL.Append(" C.IDESTABLECIMIENTO, C.IDPROVEEDOR, C.IDCONTRATO, TDC.DESCRIPCION AS TIPODOCUMENTO, ")
        strSQL.Append(" C.NUMEROCONTRATO AS NUMERODOCUMENTO, CONVERT(varchar(10), C.FECHAGENERACION, 103) AS FECHADOCUMENTO, ")
        strSQL.Append(" TC.DESCRIPCION AS TIPOCOMPRA, C.NUMEROMODALIDADCOMPRA AS NUMEROCOMPRA, RD.NOMBRE AS RESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" PRO.NOMBRE AS PROVEEDOR, ALM.NOMBRE AS ALMACEN, TS.DESCRIPCION AS TIPOPRODUCTO, C.MONTOCONTRATO, C.IDTIPODOCUMENTO, ")
        strSQL.Append(" C.IDMODALIDADCOMPRA, FFC.IDFUENTEFINANCIAMIENTO, RDC.IDRESPONSABLEDISTRIBUCION, AEC.IDALMACENENTREGA, ")
        strSQL.Append(" TS.IDTIPOSUMINISTRO")
        strSQL.Append(" FROM SAB_CAT_RESPONSABLEDISTRIBUCION AS RD INNER JOIN ")
        strSQL.Append(" SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO AS RDC ON ")
        strSQL.Append(" RD.IDRESPONSABLEDISTRIBUCION = RDC.IDRESPONSABLEDISTRIBUCION RIGHT OUTER JOIN ")
        strSQL.Append(" SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS AS FFC RIGHT OUTER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS PRO INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOS AS C ON PRO.IDPROVEEDOR = C.IDPROVEEDOR ON FFC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        strSQL.Append(" FFC.IDPROVEEDOR = C.IDPROVEEDOR AND FFC.IDCONTRATO = C.IDCONTRATO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS AS AEC INNER JOIN ")
        strSQL.Append(" SAB_CAT_ALMACENES AS ALM ON AEC.IDALMACENENTREGA = ALM.IDALMACEN ON PRO.IDPROVEEDOR = AEC.IDPROVEEDOR AND ")
        strSQL.Append(" C.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO AND C.IDPROVEEDOR = AEC.IDPROVEEDOR AND ")
        strSQL.Append(" C.IDCONTRATO = AEC.IDCONTRATO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_CAT_TIPODOCUMENTOCONTRATO AS TDC ON C.IDTIPODOCUMENTO = TDC.IDTIPODOCUMENTO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS AS TC ON C.IDMODALIDADCOMPRA = TC.IDTIPOCOMPRA ON RDC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        strSQL.Append(" RDC.IDPROVEEDOR = C.IDPROVEEDOR AND RDC.IDCONTRATO = C.IDCONTRATO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOSUMINISTROS AS TS INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS AS CATP INNER JOIN ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO AS PC ON CATP.IDPRODUCTO = PC.IDPRODUCTO ON TS.IDTIPOSUMINISTRO = CATP.IDTIPOSUMINISTRO ON ")
        strSQL.Append(" C.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND C.IDPROVEEDOR = PC.IDPROVEEDOR AND C.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append(" WHERE (AEC.IDALMACENENTREGA = " & IDALMACEN & ") ")

        If IDTIPODOCUMENTO <> 0 Then
            strSQL.Append(" AND (C.IDTIPODOCUMENTO = " & IDTIPODOCUMENTO & ") ")
        End If

        If IDMODALIDAD <> 0 Then
            strSQL.Append(" AND (C.IDMODALIDADCOMPRA = " & IDMODALIDAD & ") ")
        End If

        If NUMERODOCUMENTO.Length > 0 Then
            strSQL.Append(" AND (C.NUMEROCONTRATO like '%" & NUMERODOCUMENTO & "%') ")
        End If

        If FECHADOCUMENTO > Date.MinValue Then
            strSQL.Append(" AND (c.FECHAGENERACION = " & FECHADOCUMENTO & ") ")
        End If

        If NUMEROMODALIDAD.Length > 0 Then
            strSQL.Append(" AND (C.NUMEROMODALIDADCOMPRA like '%" & NUMEROMODALIDAD & "%') ")
        End If

        If IDFUENTE <> 0 Then
            strSQL.Append(" AND (FFC.IDFUENTEFINANCIAMIENTO = " & IDFUENTE & ") ")
        End If

        If IDRESPONSABLE <> 0 Then
            strSQL.Append(" AND (RDC.IDRESPONSABLEDISTRIBUCION = " & IDRESPONSABLE & ") ")
        End If

        If IDTIPOSUMINISTRO <> 0 Then
            strSQL.Append(" AND (TS.IDTIPOSUMINISTRO = " & IDTIPOSUMINISTRO & ") ")
        End If

        If IDPROVEEDOR <> 0 Then
            strSQL.Append(" AND (C.IDPROVEEDOR = " & IDPROVEEDOR & ") ")
        End If

        If PRODUCTO.Length > 0 Then
            strSQL.Append(" AND (CATP.CORRPRODUCTO = '" & PRODUCTO & "' ) ")
        End If

        Select Case ENTREGA
            Case 1 ' no se han realizado entregas
                strSQL.Append(" AND (AEC.CANTIDADENTREGADA = 0) ")
            Case 2 ' faltan entregas
                strSQL.Append(" AND (AEC.CANTIDADENTREGADA > 0 and AEC.CANTIDADENTREGADA < AEC.CANTIDAD) ")
            Case 3 ' entregas completas
                strSQL.Append(" AND (AEC.CANTIDAD = AEC.CANTIDADENTREGADA ) ")
        End Select

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    'jmejia
    Public Function ObtenerDatasetContratosyOtrosDoc2(ByVal IDTIPODOCUMENTO As Integer, ByVal NUMERODOCUMENTO As String, _
                                                      ByVal IDMODALIDAD As Integer, ByVal IDALMACEN As Integer, ByVal IDTIPOSUMINISTRO As Integer, _
                                                      ByVal IDPROVEEDOR As Integer, ByVal PRODUCTO As String, ByVal ENTREGA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("C.IDESTABLECIMIENTO, ")
        strSQL.Append("C.IDPROVEEDOR, ")
        strSQL.Append("C.IDCONTRATO, ")
        strSQL.Append("TDC.DESCRIPCION TIPODOCUMENTO, ")
        strSQL.Append("C.NUMEROCONTRATO NUMERODOCUMENTO, ")
        strSQL.Append("convert(varchar, C.FECHADISTRIBUCION, 103) FECHADOCUMENTO, ")
        strSQL.Append("MC.DESCRIPCION TIPOCOMPRA, ")
        strSQL.Append("C.NUMEROMODALIDADCOMPRA NUMEROCOMPRA, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        strSQL.Append("C.MONTOCONTRATO ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS C ")
        strSQL.Append("INNER JOIN SAB_CAT_MODALIDADESCOMPRA MC ")
        strSQL.Append("ON C.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO TDC ")
        strSQL.Append("ON C.IDTIPODOCUMENTO = TDC.IDTIPODOCUMENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON C.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("ON C.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = AEC.IDCONTRATO ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = EC.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = EC.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = EC.IDCONTRATO ")
        strSQL.Append("AND AEC.RENGLON = EC.RENGLON ")
        strSQL.Append("AND AEC.IDDETALLE = EC.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON EC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND EC.RENGLON = PC.RENGLON ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE (C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO OR @IDESTABLECIMIENTO = 0) ")
        strSQL.Append("AND (C.IDTIPODOCUMENTO = @IDTIPODOCUMENTO OR @IDTIPODOCUMENTO = 0) ")
        strSQL.Append("AND (C.IDMODALIDADCOMPRA = @IDMODALIDAD OR @IDMODALIDAD = 0) ")
        strSQL.Append("AND (C.IDPROVEEDOR = @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")
        strSQL.Append("AND (C.NUMEROCONTRATO = @NUMERODOCUMENTO OR @NUMERODOCUMENTO = '') ")
        strSQL.Append("AND (AEC.IDALMACENENTREGA = @IDALMACEN OR @IDALMACEN = 0) ")
        strSQL.Append("AND (CP.CORRPRODUCTO = @PRODUCTO OR @PRODUCTO = '') ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("C.IDESTABLECIMIENTO, ")
        strSQL.Append("C.IDPROVEEDOR, ")
        strSQL.Append("C.IDCONTRATO, ")
        strSQL.Append("TDC.DESCRIPCION, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("C.FECHADISTRIBUCION, ")
        strSQL.Append("MC.DESCRIPCION, ")
        strSQL.Append("C.NUMEROMODALIDADCOMPRA, ")
        strSQL.Append("P.NOMBRE, ")
        strSQL.Append("C.MONTOCONTRATO ")

        Select Case ENTREGA
            Case 1 ' no se han realizado entregas
                strSQL.Append("HAVING sum(AEC.CANTIDADENTREGADA) = 0 ")
            Case 2 ' faltan entregas
                strSQL.Append("HAVING sum(AEC.CANTIDADENTREGADA) < sum(AEC.CANTIDAD) ")
            Case 3 ' entregas completas
                strSQL.Append("HAVING sum(AEC.CANTIDADENTREGADA) = sum(AEC.CANTIDAD) ")
        End Select

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(1).Value = IDTIPODOCUMENTO
        args(2) = New SqlParameter("@IDMODALIDAD", SqlDbType.Int)
        args(2).Value = IDMODALIDAD
        args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(3).Value = IDPROVEEDOR
        args(4) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(4).Value = IDALMACEN
        args(5) = New SqlParameter("@NUMERODOCUMENTO", SqlDbType.VarChar)
        args(5).Value = NUMERODOCUMENTO
        args(6) = New SqlParameter("@PRODUCTO", SqlDbType.VarChar)
        args(6).Value = PRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    'Obteniendo los datos de las fuentes de financiamiento
    Public Function ObtenerTipoSuministro2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("with ")
        strSQL.Append("  cte (idRango, lista, nombre, longitud) ")
        strSQL.Append("as ( ")
        strSQL.Append("  SELECT ")
        strSQL.Append("    1, CAST('' as varchar(8000)), CAST('' as varchar(8000)), 0 ")
        strSQL.Append("  FROM ")
        strSQL.Append("    SAB_UACI_PRODUCTOSCONTRATO pc ")
        strSQL.Append("      inner join vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("        on pc.idproducto = cp.idproducto ")
        strSQL.Append("  WHERE ")
        strSQL.Append("    pc.idestablecimiento = @IDESTABLECIMIENTO AND ")
        strSQL.Append("    pc.idproveedor = @IDPROVEEDOR AND ")
        strSQL.Append("    pc.idcontrato = @IDCONTRATO ")
        strSQL.Append("  UNION ALL ")
        strSQL.Append("  SELECT ")
        strSQL.Append("    1 as idFF, ")
        strSQL.Append("    CAST(lista + CASE WHEN longitud = 0 THEN '' ELSE ', ' END + cp2.descsuministro as varchar(8000)), ")
        strSQL.Append("    CAST(cp2.descsuministro as varchar(8000)), longitud + 1 ")
        strSQL.Append("  FROM cte c ")
        strSQL.Append("    inner join SAB_UACI_PRODUCTOSCONTRATO pc ")
        strSQL.Append("      on c.idRango = 1 ")
        strSQL.Append("    inner join vv_CATALOGOPRODUCTOS cp2 ")
        strSQL.Append("        on pc.idproducto = cp2.idproducto ")
        strSQL.Append("  WHERE ")
        strSQL.Append("    cp2.descsuministro > c.nombre AND ")
        strSQL.Append("    pc.idestablecimiento = @IDESTABLECIMIENTO AND ")
        strSQL.Append("    pc.idproveedor = @IDPROVEEDOR AND ")
        strSQL.Append("    pc.idcontrato = @IDCONTRATO ")
        strSQL.Append(") ")
        strSQL.Append("select ")
        strSQL.Append("  idRango, lista ")
        strSQL.Append("from ")
        strSQL.Append("  ( ")
        strSQL.Append("  select distinct idRango, lista, rank() over (partition by idRango order by longitud desc) from cte) d (idRango, lista, rank) ")
        strSQL.Append("where rank = 1 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dr.Read Then
            Return dr.Item(1)
        Else
            Return ""
        End If

    End Function

    'jmejia
    'Obteniendo los datos de las fuentes de financiamiento
    Public Function ObtenerDatasetFuentesFinanciamientoContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("FF.NOMBRE, ")
        strSQL.Append("FFC.MONTOCONTRATADO ")
        strSQL.Append("FROM SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS FFC ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON FFC.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("WHERE FFC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND FFC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND FFC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("ORDER BY FF.NOMBRE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    'jmejia
    'Obteniendo todos los renglones que pertenecen al contrato o documento especificado
    Public Function ObtenerDatasetRenglonesContratoOtrosDoc(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT AEC.IDESTABLECIMIENTO, AEC.IDPROVEEDOR, AEC.IDCONTRATO, AEC.IDALMACENENTREGA, AEC.RENGLON, CAT.DESCLARGO AS PRODUCTO, ")
        strSQL.Append(" UM.DESCRIPCION AS UM, SUM(AEC.CANTIDAD) AS CANTIDAD, PC.PRECIOUNITARIO, MAX(AEC.IDDETALLE) AS ENTREGAS, ")
        strSQL.Append(" PC.DESCRIPCIONPROVEEDOR, CAT.CORRPRODUCTO ")
        strSQL.Append(" FROM SAB_UACI_ALMACENESENTREGACONTRATOS AS AEC INNER JOIN ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO AS PC ON AEC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND AEC.IDPROVEEDOR = PC.IDPROVEEDOR AND ")
        strSQL.Append(" AEC.IDCONTRATO = PC.IDCONTRATO AND AEC.RENGLON = PC.RENGLON INNER JOIN ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS AS UM ON PC.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS AS CAT ON PC.IDPRODUCTO = CAT.IDPRODUCTO ")
        strSQL.Append(" GROUP BY AEC.IDESTABLECIMIENTO, AEC.IDPROVEEDOR, AEC.IDCONTRATO, AEC.IDALMACENENTREGA, AEC.RENGLON, CAT.DESCLARGO, UM.DESCRIPCION, ")
        strSQL.Append(" PC.PRECIOUNITARIO, PC.DESCRIPCIONPROVEEDOR,  CAT.CORRPRODUCTO")
        strSQL.Append(" HAVING (AEC.IDALMACENENTREGA = " & IDALMACEN & ") AND (AEC.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (AEC.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (AEC.IDCONTRATO = " & IDCONTRATO & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    'Obteniendo todos los renglones que pertenecen al contrato o documento especificado
    Public Function ObtenerDatasetRenglonesContratoOtrosDoc2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("AEC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("CP.DESCLARGO PRODUCTO, ")
        strSQL.Append("CP.DESCRIPCION UM, ")
        strSQL.Append("SUM(AEC.CANTIDAD) CANTIDAD, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("MAX(AEC.IDDETALLE) ENTREGAS, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("SUM(AEC.CANTIDAD) - SUM(AEC.CANTIDADENTREGADA) CANTIDADPENDIENTE, ")
        strSQL.Append("SUM(AEC.CANTIDADENTREGADA) * 100 / SUM(AEC.CANTIDAD) PORTENTAJEENTREGADO, ")
        strSQL.Append("100 - SUM(AEC.CANTIDADENTREGADA) * 100 / SUM(AEC.CANTIDAD) PORCENTAJEPEDIENTE ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND AEC.IDPROVEEDOR = PC.IDPROVEEDOR AND AEC.IDCONTRATO = PC.IDCONTRATO AND AEC.RENGLON = PC.RENGLON ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE AEC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND AEC.IDALMACENENTREGA = @IDALMACEN ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("AEC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("CP.CORRPRODUCTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(3).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    'Obteniendo todos los renglones que pertenecen al contrato o documento especificado
    Public Function ObtenerDatasetRenglonesContratoOtrosDoc3(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDALMACEN As Integer) As DataSet




        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("AEC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("CP.DESCLARGO PRODUCTO, ")
        strSQL.Append("CP.DESCRIPCION UM, ")
        strSQL.Append("sum(AEC.CANTIDAD) CANTIDAD, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("max(AEC.IDDETALLE) ENTREGAS, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("sum(AEC.CANTIDAD) - sum(AEC.CANTIDADENTREGADA) CANTIDADPENDIENTE, ")
        strSQL.Append("sum(AEC.CANTIDADENTREGADA) * 100 / sum(AEC.CANTIDAD) PORCENTAJEENTREGADO, ")
        strSQL.Append("100 - (sum(AEC.CANTIDADENTREGADA) * 100 / sum(AEC.CANTIDAD)) PORCENTAJEPENDIENTE ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND AEC.RENGLON = PC.RENGLON ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE AEC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND (AEC.IDALMACENENTREGA = @IDALMACEN OR @IDALMACEN = 0) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("AEC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("CP.CORRPRODUCTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(3).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDetalleEntregasContratoRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDALMACEN As Integer, Optional ByVal RENGLON As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("with t as ")
        strSQL.Append("( ")
        strSQL.Append("SELECT ")
        strSQL.Append("AEC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("sum(AEC.CANTIDAD) CANTIDAD ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("WHERE ")
        strSQL.Append("AEC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND (AEC.IDALMACENENTREGA = @IDALMACEN OR @IDALMACEN = 0) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("AEC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("AEC.RENGLON ")
        strSQL.Append(") ")

        strSQL.Append("SELECT  ")
        strSQL.Append("RR.IDESTABLECIMIENTO, ")
        strSQL.Append("RR.IDPROVEEDOR, ")
        strSQL.Append("RR.IDCONTRATO, ")
        strSQL.Append("RR.IDALMACEN, ")
        strSQL.Append("A.NOMBRE ALMACEN, ")
        strSQL.Append("DM.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("DM.RENGLON, ")
        strSQL.Append("DM.CANTIDAD, ")
        strSQL.Append("convert(varchar, M.FECHAMOVIMIENTO, 103) FECHAMOVIMIENTO, ")
        strSQL.Append("DM.CANTIDAD * 100 / AEC.CANTIDAD AS PORCENTAJERECEPCION, ")
        strSQL.Append("CONVERT(varchar, RR.NUMEROACTA) + '/' + CONVERT(varchar, RR.ANIO) as NUMEROACTA ")
        strSQL.Append("FROM SAB_ALM_RECIBOSRECEPCION RR ")

        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON RR.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND RR.ANIO = M.ANIO ")
        strSQL.Append("AND RR.IDRECIBO = M.IDDOCUMENTO ")

        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS AS DM ")
        strSQL.Append("ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO ")

        strSQL.Append("INNER JOIN t AEC ")
        strSQL.Append("ON RR.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO ")
        strSQL.Append("AND RR.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND RR.IDCONTRATO = AEC.IDCONTRATO ")
        strSQL.Append("AND RR.IDALMACEN = AEC.IDALMACENENTREGA ")
        strSQL.Append("AND DM.RENGLON = AEC.RENGLON ")

        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON RR.IDALMACEN = A.IDALMACEN ")

        strSQL.Append("WHERE RR.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND RR.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND RR.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND (RR.IDALMACEN = @IDALMACEN OR @IDALMACEN = 0) ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = 8 ")
        strSQL.Append("AND M.IDESTADO = 2 ")
        strSQL.Append("AND (DM.RENGLON = @RENGLON OR @RENGLON = 0) ")

        strSQL.Append("GROUP BY ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("RR.IDESTABLECIMIENTO, ")
        strSQL.Append("RR.IDPROVEEDOR, ")
        strSQL.Append("RR.IDCONTRATO, ")
        strSQL.Append("RR.IDALMACEN, ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("DM.IDDETALLEMOVIMIENTO, ")
        strSQL.Append("DM.RENGLON, ")
        strSQL.Append("DM.CANTIDAD, ")
        strSQL.Append("M.FECHAMOVIMIENTO, ")
        strSQL.Append("DM.CANTIDAD, ")
        strSQL.Append("AEC.CANTIDAD, ")
        strSQL.Append("RR.NUMEROACTA, ")
        strSQL.Append("RR.ANIO ")
        strSQL.Append("ORDER BY  ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("M.FECHAMOVIMIENTO, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("DM.IDDETALLEMOVIMIENTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(3).Value = IDALMACEN
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function obtenerDetalleEntregasXContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT RR.IDESTABLECIMIENTO, RR.IDPROVEEDOR, RR.IDCONTRATO, RR.IDALMACEN as IDALMACENENTREGA, DM.RENGLON, DM.CANTIDAD, M.FECHAMOVIMIENTO, ")
        strSQL.Append(" DM.CANTIDAD * 100 / PC.CANTIDAD AS PORCENTAJERECEPCION, RR.NUMEROACTA ")
        strSQL.Append(" FROM SAB_ALM_MOVIMIENTOS AS M INNER JOIN ")
        strSQL.Append(" SAB_ALM_RECIBOSRECEPCION AS RR ON M.IDALMACEN = RR.IDALMACEN AND M.IDDOCUMENTO = RR.IDRECIBO AND ")
        strSQL.Append(" M.ANIO = RR.ANIO INNER JOIN ")
        strSQL.Append(" SAB_ALM_DETALLEMOVIMIENTOS AS DM ON M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO AND ")
        strSQL.Append(" M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO AS PC ON M.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND RR.IDPROVEEDOR = PC.IDPROVEEDOR AND ")
        strSQL.Append(" RR.IDCONTRATO = PC.IDCONTRATO And RR.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO And DM.RENGLON = PC.RENGLON ")
        strSQL.Append(" WHERE (RR.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (RR.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (RR.IDCONTRATO = " & IDCONTRATO & ") AND (RR.IDALMACEN = " & IDALMACEN & ") ")
        strSQL.Append(" ORDER BY DM.RENGLON ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    'Obteniendo todos los renglones que pertenecen al contrato o documento especificado
    Public Function ObtenerDatasetRptRenglonesContratoOtrosDoc(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT AEC.IDESTABLECIMIENTO, AEC.IDPROVEEDOR, AEC.IDCONTRATO, AEC.IDALMACENENTREGA AS IDALMACEN, AEC.RENGLON, ")
        strSQL.Append(" CAT.CORRPRODUCTO AS CODIGO, CAT.DESCLARGO AS DESCRIPCION, CAT.DESCRIPCION AS UM, SUM(AEC.CANTIDAD) AS CANTIDAD, ")
        strSQL.Append(" PC.PRECIOUNITARIO, MAX(AEC.IDDETALLE) AS ENTREGAS, SUM(AEC.CANTIDAD * PC.PRECIOUNITARIO) AS TOTAL")
        strSQL.Append(" FROM SAB_UACI_ALMACENESENTREGACONTRATOS AS AEC INNER JOIN")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO AS PC ON AEC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND AEC.IDPROVEEDOR = PC.IDPROVEEDOR AND")
        strSQL.Append(" AEC.IDCONTRATO = PC.IDCONTRATO AND AEC.RENGLON = PC.RENGLON INNER JOIN")
        strSQL.Append(" vv_CATALOGOPRODUCTOS AS CAT ON PC.IDPRODUCTO = CAT.IDPRODUCTO")
        strSQL.Append(" WHERE (AEC.IDALMACENENTREGA = @IDALMACEN ) AND (AEC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ) AND (AEC.IDPROVEEDOR = @IDPROVEEDOR ) AND (AEC.IDCONTRATO = @IDCONTRATO ) ")
        strSQL.Append(" GROUP BY AEC.IDESTABLECIMIENTO, AEC.IDPROVEEDOR, AEC.IDCONTRATO, AEC.IDALMACENENTREGA, AEC.RENGLON, CAT.DESCLARGO, CAT.DESCRIPCION, ")
        strSQL.Append(" PC.PRECIOUNITARIO, CAT.CORRPRODUCTO")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(3).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    'jmejia
    'Obteniendo los plazos de entrega para cada renglon del contrato o documento especificado
    Public Function ObtenerDatasetPlazosEntregaRenglonContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT PLAZOENTREGA, PORCENTAJEENTREGA ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ") AND (RENGLON = " & RENGLON & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerEntregasProgramadas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("A.NOMBRE ALMACEN, ")
        strSQL.Append("EC.ENTREGA, ")
        strSQL.Append("AEC.CANTIDAD, ")
        strSQL.Append("CP.DESCRIPCION UM, ")
        strSQL.Append("EC.PORCENTAJEENTREGA, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("AEC.CANTIDAD * PC.PRECIOUNITARIO PRECIOTOTAL, ")
        strSQL.Append("convert(varchar, dateadd(day, EC.PLAZOENTREGA, C.FECHADISTRIBUCION), 103) FECHAENTREGA ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = EC.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = EC.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = EC.IDCONTRATO ")
        strSQL.Append("AND AEC.RENGLON = EC.RENGLON ")
        strSQL.Append("AND AEC.IDDETALLE = EC.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = C.IDCONTRATO ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND AEC.RENGLON = PC.RENGLON ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON AEC.IDALMACENENTREGA = A.IDALMACEN ")
        strSQL.Append("WHERE AEC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND (AEC.RENGLON = @RENGLON OR @RENGLON = 0) ")
        strSQL.Append("AND (AEC.IDALMACENENTREGA = @IDALMACEN OR @IDALMACEN = 0) ")
        strSQL.Append("ORDER BY ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("EC.ENTREGA ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON
        args(4) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(4).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerEntregasProgramadasXContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDALMACENENTREGA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("AEC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("EC.ENTREGA, ")
        strSQL.Append("AEC.CANTIDAD, ")
        strSQL.Append("EC.PORCENTAJEENTREGA, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("AEC.CANTIDAD * PC.PRECIOUNITARIO AS PRECIOTOTAL, ")
        strSQL.Append("CONVERT(VARCHAR, DATEADD(DD, EC.PLAZOENTREGA, C.FECHADISTRIBUCION), 103) AS FECHAENTREGA ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS AS AEC ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO AS EC ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = EC.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = EC.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = EC.IDCONTRATO ")
        strSQL.Append("AND AEC.RENGLON = EC.RENGLON ")
        strSQL.Append("AND AEC.IDDETALLE = EC.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS AS C ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = C.IDCONTRATO ")
        strSQL.Append("AND EC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = C.IDCONTRATO ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO AS PC ")
        strSQL.Append("ON EC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND EC.RENGLON = PC.RENGLON ")
        strSQL.Append("AND C.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("WHERE AEC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND AEC.IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(3).Value = IDALMACENENTREGA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    'Se obtienen todos los documentos que estan relacionados al contrato seleccionado
    Public Function ObtenerDatasetDocumentosRelacionados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT 'Informe no aceptación' AS TIPO, CONVERT(varchar, IDINFORME) + '/' + CONVERT(varchar, ANIO) AS NUMERO, IDESTABLECIMIENTO, ")
        strSQL.Append("IDPROVEEDOR, IDCONTRATO ")
        strSQL.Append("FROM SAB_ALM_INFORMESNOACEPTACION AS I ")
        strSQL.Append("WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ") ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT 'Recibo de recepción' AS TIPO, CONVERT(varchar, R.IDRECIBO) + '/' + CONVERT(varchar, R.ANIO) AS NUMERO, R.IDESTABLECIMIENTO, ")
        strSQL.Append(" R.IDPROVEEDOR, R.IDCONTRATO ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS AS M INNER JOIN ")
        strSQL.Append("SAB_ALM_RECIBOSRECEPCION AS R ON M.IDALMACEN = R.IDALMACEN AND M.IDDOCUMENTO = R.IDRECIBO AND M.ANIO = R.ANIO ")
        strSQL.Append("WHERE (M.IDESTADO <> 2) AND (R.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (R.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (R.IDCONTRATO = " & IDCONTRATO & ") AND (R.NUMEROACTA IS NULL) ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT 'Acta de recepción' AS TIPO, CONVERT(varchar, R.NUMEROACTA) + '/' + CONVERT(varchar, R.ANIO) AS NUMERO, ")
        strSQL.Append("R.IDESTABLECIMIENTO, R.IDPROVEEDOR, R.IDCONTRATO ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS AS M INNER JOIN ")
        strSQL.Append("SAB_ALM_RECIBOSRECEPCION AS R ON M.IDALMACEN = R.IDALMACEN AND M.IDDOCUMENTO = R.IDRECIBO AND M.ANIO = R.ANIO ")
        strSQL.Append("WHERE (M.IDESTADO <> 1) AND (R.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (R.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (R.IDCONTRATO = " & IDCONTRATO & ") AND (R.NUMEROACTA IS NOT NULL) ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT 'Modificativa de contrato' AS TIPO, NUMEROMODIFICATIVA as NUMERO, IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO ")
        strSQL.Append("FROM SAB_UACI_MODIFICATIVASCONTRATO ")
        strSQL.Append("WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerProveedorContratoRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROVEEDOR, ")
        strSQL.Append("PC.IDCONTRATO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("P.NOMBRE NOMBREPROVEEDOR, ")
        strSQL.Append("PC.CANTIDAD, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = EC.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = EC.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = EC.IDCONTRATO ")
        strSQL.Append("AND PC.RENGLON = EC.RENGLON) ")
        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("ON (EC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = AEC.IDCONTRATO ")
        strSQL.Append("AND EC.RENGLON = AEC.RENGLON ")
        strSQL.Append("AND EC.IDDETALLE = AEC.IDDETALLE) ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON PC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
        strSQL.Append("ON PC.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("WHERE ")
        strSQL.Append("PC.ESTAHABILITADO = 1 ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROVEEDOR, ")
        strSQL.Append("PC.IDCONTRATO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("P.NOMBRE, ")
        strSQL.Append("PC.CANTIDAD, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("E.NOMBRE ")
        strSQL.Append("HAVING (SUM(AEC.CANTIDAD) > SUM(AEC.CANTIDADENTREGADA)) ")
        strSQL.Append("ORDER BY PC.IDPROVEEDOR, PC.IDESTABLECIMIENTO, PC.IDCONTRATO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    'jmejia
    'Se obtienen todos los documentos que estan relacionados al contrato seleccionado
    Public Function ObtenerDatasetRptEncabezadoContratosOtrosDoc(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("C.IDESTABLECIMIENTO, ")
        strSQL.Append("C.IDPROVEEDOR, ")
        strSQL.Append("C.IDCONTRATO, ")
        strSQL.Append("C.IDTIPODOCUMENTO, ")
        strSQL.Append("TDC.DESCRIPCION TIPODOCUMENTO, ")
        strSQL.Append("C.NUMEROCONTRATO NUMERODOCUMENTO, ")
        strSQL.Append("convert(varchar, C.FECHADISTRIBUCION, 103) FECHADOCUMENTO, ")
        strSQL.Append("TC.DESCRIPCION TIPOCOMPRA, ")
        strSQL.Append("C.IDMODALIDADCOMPRA, ")
        strSQL.Append("C.NUMEROMODALIDADCOMPRA NUMEROCOMPRA, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        strSQL.Append("C.MONTOCONTRATO ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS C ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON C.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO TDC ")
        strSQL.Append("ON C.IDTIPODOCUMENTO = TDC.IDTIPODOCUMENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON C.IDMODALIDADCOMPRA = TC.IDTIPOCOMPRA ")
        strSQL.Append("WHERE C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    'JMEJIA
    'PARA OBTENER EL ENCABEZADO DEL CONTRATO
    Public Function ObtenerDatasetRptContratosOtrosDoc(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Integer, ByVal IDALMACENENTREGA As Integer, ByRef ds As DataSet) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" Select DISTINCT top(1) ")
        strSQL.Append(" C.IDESTABLECIMIENTO, C.IDPROVEEDOR, C.IDCONTRATO, TDC.DESCRIPCION AS TIPODOCUMENTO, ")
        strSQL.Append(" C.NUMEROCONTRATO AS NUMERODOCUMENTO, CONVERT(varchar(10), C.FECHAGENERACION, 103) AS FECHADOCUMENTO, ")
        strSQL.Append(" TC.DESCRIPCION AS TIPOCOMPRA, C.NUMEROMODALIDADCOMPRA AS NUMEROCOMPRA, RD.NOMBRE AS RESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" PRO.NOMBRE AS PROVEEDOR, ALM.NOMBRE AS ALMACEN, TS.DESCRIPCION AS TIPOPRODUCTO, C.MONTOCONTRATO, C.IDTIPODOCUMENTO, ")
        strSQL.Append(" C.IDMODALIDADCOMPRA, FFC.IDFUENTEFINANCIAMIENTO, RDC.IDRESPONSABLEDISTRIBUCION, AEC.IDALMACENENTREGA, ")
        strSQL.Append(" TS.IDTIPOSUMINISTRO, CATP.CORRPRODUCTO, AEC.CANTIDAD, AEC.CANTIDADENTREGADA ")
        strSQL.Append(" FROM SAB_CAT_RESPONSABLEDISTRIBUCION AS RD INNER JOIN ")
        strSQL.Append(" SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO AS RDC ON ")
        strSQL.Append(" RD.IDRESPONSABLEDISTRIBUCION = RDC.IDRESPONSABLEDISTRIBUCION RIGHT OUTER JOIN ")
        strSQL.Append(" SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS AS FFC RIGHT OUTER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS PRO INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOS AS C ON PRO.IDPROVEEDOR = C.IDPROVEEDOR ON FFC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        strSQL.Append(" FFC.IDPROVEEDOR = C.IDPROVEEDOR AND FFC.IDCONTRATO = C.IDCONTRATO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS AS AEC INNER JOIN ")
        strSQL.Append(" SAB_CAT_ALMACENES AS ALM ON AEC.IDALMACENENTREGA = ALM.IDALMACEN ON PRO.IDPROVEEDOR = AEC.IDPROVEEDOR AND ")
        strSQL.Append(" C.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO AND C.IDPROVEEDOR = AEC.IDPROVEEDOR AND ")
        strSQL.Append(" C.IDCONTRATO = AEC.IDCONTRATO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_CAT_TIPODOCUMENTOCONTRATO AS TDC ON C.IDTIPODOCUMENTO = TDC.IDTIPODOCUMENTO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS AS TC ON C.IDMODALIDADCOMPRA = TC.IDTIPOCOMPRA ON RDC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        strSQL.Append(" RDC.IDPROVEEDOR = C.IDPROVEEDOR AND RDC.IDCONTRATO = C.IDCONTRATO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOSUMINISTROS AS TS INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS AS CATP INNER JOIN ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO AS PC ON CATP.IDPRODUCTO = PC.IDPRODUCTO ON TS.IDTIPOSUMINISTRO = CATP.IDTIPOSUMINISTRO ON ")
        strSQL.Append(" C.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO And C.IDPROVEEDOR = PC.IDPROVEEDOR And C.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append(" WHERE (C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (C.IDPROVEEDOR = @IDPROVEEDOR) AND (C.IDCONTRATO = @IDCONTRATO) AND (AEC.IDALMACENENTREGA = @IDALMACENENTREGA) ")

        'para los documentos relacionados
        strSQL.Append("SELECT 'Informe no aceptación' AS TIPO, CONVERT(varchar, IDINFORME) + '/' + CONVERT(varchar, ANIO) AS NUMERO, IDESTABLECIMIENTO, ")
        strSQL.Append("IDPROVEEDOR, IDCONTRATO ")
        strSQL.Append("FROM SAB_ALM_INFORMESNOACEPTACION AS I ")
        strSQL.Append("WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND (IDCONTRATO = @IDCONTRATO) ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT 'Recibo de recepción' AS TIPO, CONVERT(varchar, R.IDRECIBO) + '/' + CONVERT(varchar, R.ANIO) AS NUMERO, R.IDESTABLECIMIENTO, ")
        strSQL.Append(" R.IDPROVEEDOR, R.IDCONTRATO ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS AS M INNER JOIN ")
        strSQL.Append("SAB_ALM_RECIBOSRECEPCION AS R ON M.IDALMACEN = R.IDALMACEN AND M.IDDOCUMENTO = R.IDRECIBO AND M.ANIO = R.ANIO ")
        strSQL.Append("WHERE (M.IDESTADO <> 2) AND (R.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (R.IDPROVEEDOR = @IDPROVEEDOR) AND (R.IDCONTRATO = @IDCONTRATO) AND (R.NUMEROACTA IS NULL) ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT 'Acta de recepción' AS TIPO, CONVERT(varchar, R.NUMEROACTA) + '/' + CONVERT(varchar, R.ANIO) AS NUMERO, ")
        strSQL.Append("R.IDESTABLECIMIENTO, R.IDPROVEEDOR, R.IDCONTRATO ")
        strSQL.Append("FROM SAB_ALM_MOVIMIENTOS AS M INNER JOIN ")
        strSQL.Append("SAB_ALM_RECIBOSRECEPCION AS R ON M.IDALMACEN = R.IDALMACEN AND M.IDDOCUMENTO = R.IDRECIBO AND M.ANIO = R.ANIO ")
        strSQL.Append("WHERE (M.IDESTADO <> 1) AND (R.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (R.IDPROVEEDOR = @IDPROVEEDOR) AND (R.IDCONTRATO = @IDCONTRATO) AND (R.NUMEROACTA IS NOT NULL) ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT 'Modificativa de contrato' AS TIPO, NUMEROMODIFICATIVA AS NUMERO, IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO ")
        strSQL.Append("FROM SAB_UACI_MODIFICATIVASCONTRATO ")
        strSQL.Append("WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND (IDCONTRATO = @IDCONTRATO) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(3).Value = IDALMACENENTREGA

        Dim tables(1) As String
        tables(0) = New String("EncabezadoDocumento")
        tables(1) = New String("Documentos")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Public Function ChequearContratosDistribuidos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT COUNT(*) ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS C ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CP ")
        strSQL.Append("ON C.IDCONTRATO = CP.IDCONTRATO AND ")
        strSQL.Append("	C.IDPROVEEDOR = CP.IDPROVEEDOR AND ")
        strSQL.Append("	C.IDESTABLECIMIENTO = CP.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE C.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & " AND ")
        strSQL.Append("CP.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & " AND ")
        strSQL.Append("C.IDESTADOCONTRATO<> 3 ")

        Dim ds As Integer
        ds = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

        If ds = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function DevolverContratoPeriodo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Int64, ByVal IDPROVEEDOR As Integer, ByVal dsP As DataSet) As DataSet

        Dim strSQL As New Text.StringBuilder
        Dim i As Integer
        For i = 0 To dsP.Tables(0).Rows.Count - 1
            strSQL.Append(" SELECT 0 AS RENGLON, '' AS CORRPRODUCTO, '' AS DESCLARGO, 0 AS CANTIDADENTREGAS, C.NUMEROCONTRATO, P.NOMBRE AS NOMBRECONTRATO, '' AS NOMBREALMACEN, '' AS CODIGOPROVEEDOR, '' AS NOMBREPROVEEDOR ")
            strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA CPC INNER JOIN ")
            strSQL.Append("        SAB_UACI_CONTRATOS C ON CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
            strSQL.Append("        CPC.IDPROVEEDOR = C.IDPROVEEDOR AND ")
            strSQL.Append("        CPC.IDCONTRATO = C.IDCONTRATO INNER JOIN ")
            strSQL.Append("        SAB_CAT_PROVEEDORES P ON CPC.IDPROVEEDOR = P.IDPROVEEDOR ")
            strSQL.Append(" WHERE CPC.IDPROCESOCOMPRA = " & dsP.Tables(0).Rows(i).Item(0).ToString & " AND CPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND CPC.IDCONTRATO = @IDCONTRATO AND CPC.IDPROVEEDOR = @IDPROVEEDOR")
            If i < dsP.Tables(0).Rows.Count - 1 Then
                strSQL.Append(" union ")
            End If

        Next

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(1).Value = IDCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerContratosProcesoCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, Optional ByVal IDPROVEEDOR As Integer = 0, Optional ByVal IDCONTRATO As Integer = 0, Optional ByVal IDESTADOCONTRATO As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CPC.IDPROCESOCOMPRA, ")
        strSQL.Append("C.IDCONTRATO, ")
        strSQL.Append("C.IDPROVEEDOR, ")
        strSQL.Append("C.IDESTABLECIMIENTO, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("C.IDTIPODOCUMENTO, ")
        strSQL.Append("C.FECHAGENERACION, ")
        strSQL.Append("RO.ORDENLLEGADA OFERTA, ")
        strSQL.Append("TDC.DESCRIPCION DOCUMENTO, ")
        strSQL.Append("P.NOMBRE PROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS C ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON (C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = CPC.IDCONTRATO) ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON (CPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND CPC.IDPROVEEDOR = RO.IDPROVEEDOR) ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO TDC ")
        strSQL.Append("ON C.IDTIPODOCUMENTO = TDC.IDTIPODOCUMENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON C.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND (C.IDPROVEEDOR = @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")
        strSQL.Append("AND (C.IDCONTRATO = @IDCONTRATO OR @IDCONTRATO = 0) ")
        strSQL.Append("AND (C.IDESTADOCONTRATO = @IDESTADOCONTRATO OR @IDESTADOCONTRATO = 0) ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(3).Value = IDCONTRATO
        args(4) = New SqlParameter("@IDESTADOCONTRATO", SqlDbType.Int)
        args(4).Value = IDESTADOCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    'Este query se utiliza para mostrar todos los renglones de un proceso de compra (ampliacion de contrato)
    Public Function obtenerRenglonesAmpliaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_DETALLEOFERTA.RENGLON, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_CAT_PROVEEDORES.NOMBRE AS PROVEEDOR, ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS.CODIGO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE AS DESCRIPCION, ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS.DESCRIPCION AS UNIDADMEDIDA, SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO, ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.CANTIDADFIRME, ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO * SAB_UACI_ADJUDICACION.CANTIDADFIRME AS 'MONTORENGLON', ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO, SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO, SAB_UACI_ADJUDICACION.IDPROVEEDOR ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS ON SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.RENGLON = SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS ON SAB_CAT_CATALOGOPRODUCTOS.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS ON ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_ALMACENESENTREGACONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO = SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.RENGLON = SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON ")
        strSQL.Append(" GROUP BY SAB_UACI_DETALLEOFERTA.RENGLON, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_CAT_PROVEEDORES.NOMBRE, ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS.CODIGO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, SAB_CAT_UNIDADMEDIDAS.DESCRIPCION, ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO, SAB_UACI_ADJUDICACION.CANTIDADFIRME, ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO * SAB_UACI_ADJUDICACION.CANTIDADFIRME, SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO, ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA, SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO, ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR ")
        strSQL.Append(" HAVING (SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerDsContratosProcesoCompraMultas(ByVal IDPROCESOCOMPRA As Int32, ByVal IDESTABLECIMIENTO As Int32, ByVal IDANALISTA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT cpc.IDCONTRATO, c.NUMEROCONTRATO, cpc.IDPROVEEDOR, AP.IDANALISTA ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOS AS c ON cpc.IDESTABLECIMIENTO = c.IDESTABLECIMIENTO AND cpc.IDPROVEEDOR = c.IDPROVEEDOR AND ")
        strSQL.Append(" cpc.IDCONTRATO = c.IDCONTRATO AND cpc.IDCONTRATO = c.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO AS NI ON c.IDESTABLECIMIENTO = NI.IDESTABLECIMIENTO AND ")
        strSQL.Append(" c.IDPROVEEDOR = NI.IDPROVEEDOR AND c.IDCONTRATO = NI.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_ANALISTAPROVEEDORES AS AP ON cpc.IDPROCESOCOMPRA = AP.IDPROCESOCOMPRA AND cpc.IDPROVEEDOR = AP.IDPROVEEDOR AND ")
        strSQL.Append(" cpc.IDESTABLECIMIENTO = AP.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (cpc.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (cpc.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (AP.IDANALISTA = " & IDANALISTA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerFechaAprobacion(ByVal IDCONTRATO As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer) As DateTime

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT fechaaprobacion from SAB_UACI_CONTRATOS ")
        strSQL.Append(" where idcontrato = @IDCONTRATO and idestablecimiento = @IDESTABLECIMIENTO and idproveedor = @IDPROVEEDOR ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(0).Value = IDCONTRATO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerCantidadProveedores(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT COUNT(IDPROVEEDOR) ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function validadNumContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCONTRATO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_CONTRATOS.IDESTABLECIMIENTO, SAB_UACI_CONTRATOS.IDCONTRATO, ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOS ON SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_CONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_CONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO = SAB_UACI_CONTRATOS.IDCONTRATO ")
        strSQL.Append(" WHERE (SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CONTRATOS.IDCONTRATO = " & IDCONTRATO & ") AND ")
        strSQL.Append(" (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString()).Tables(0).Rows.Count

    End Function

    Public Function obtenerProveedores(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT SAB_UACI_CONTRATOS.IDPROVEEDOR, SAB_CAT_PROVEEDORES.NOMBRE ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append(" WHERE SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & " ")
        strSQL.Append(" Order By SAB_CAT_PROVEEDORES.NOMBRE ASC ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function DiasAtraso(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal FECHAINICIO As String, ByVal FECHAFIN As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT AVG(SAB_UACI_DETALLEMULTASCONTRATOS.DIASATRASO) AS DIASATRASO ")
        strSQL.Append(" FROM SAB_UACI_DETALLEMULTASCONTRATOS INNER JOIN ")
        strSQL.Append("  SAB_UACI_CONTRATOS ON SAB_UACI_DETALLEMULTASCONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append("  SAB_UACI_DETALLEMULTASCONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append("  SAB_UACI_DETALLEMULTASCONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOS.IDCONTRATO ")
        strSQL.Append(" WHERE (SAB_UACI_DETALLEMULTASCONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_DETALLEMULTASCONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ") ")
        strSQL.Append(" AND (SAB_UACI_CONTRATOS.FECHAGENERACION BETWEEN CONVERT(DATETIME, '" & FECHAINICIO & "', 103) AND CONVERT(DATETIME, '" & FECHAFIN & "', 103))")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return IIf(IsDBNull(ds.Tables(0).Rows(0).Item("DIASATRASO")), 0, ds.Tables(0).Rows(0).Item("DIASATRASO"))

    End Function

    Public Function CalculoRechazos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer) As Integer
        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT COUNT(IDINFORME) AS Rechazos ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append(" WHERE (IDTIPOINFORME = 1) AND (IDESTADO = 3) AND (RESULTADOINSPECCION = 2) AND (IDESTABLECIMIENTOCONTRATO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append("  (IDPROVEEDOR = " & IDPROVEEDOR & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds.Tables(0).Rows(0).Item("Rechazos")

    End Function

    Public Function obtenerDatosContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_CONTRATOS.IDESTABLECIMIENTO, SAB_UACI_CONTRATOS.IDPROVEEDOR, ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA, SAB_UACI_CONTRATOS.IDCONTRATO, ")
        strSQL.Append(" SAB_UACI_CONTRATOS.NUMEROCONTRATO, SAB_UACI_CONTRATOS.IDTIPODOCUMENTO, SAB_UACI_CONTRATOS.IDPLANTILLA, ")
        strSQL.Append(" SAB_UACI_CONTRATOS.TIPOPERSONA, SAB_UACI_CONTRATOS.REPRESENTANTELEGAL, SAB_UACI_CONTRATOS.PERSONERIAJURIDICA, ")
        strSQL.Append(" SAB_UACI_CONTRATOS.FECHAGENERACION, SAB_UACI_CONTRATOS.FECHAAPROBACION, SAB_UACI_CONTRATOS.FECHADISTRIBUCION, ")
        strSQL.Append(" SAB_UACI_CONTRATOS.CODIGOLICITACION, SAB_UACI_CONTRATOS.FECHAINICIOENTREGA, SAB_UACI_CONTRATOS.IDESTADOCONTRATO, ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDCALIFICACIONCUMPLIMIENTO, SAB_UACI_CONTRATOS.IDCALIFICACIONCALIDAD, ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDMODALIDADCOMPRA, SAB_UACI_CONTRATOS.NUMEROMODALIDADCOMPRA, SAB_UACI_CONTRATOS.MONTOCONTRATO, ")
        strSQL.Append(" SAB_UACI_CONTRATOS.AUUSUARIOCREACION, SAB_UACI_CONTRATOS.AUFECHACREACION, SAB_UACI_CONTRATOS.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" SAB_UACI_CONTRATOS.AUFECHAMODIFICACION, SAB_UACI_CONTRATOS.ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO ")
        strSQL.Append(" WHERE (SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ") AND ")
        strSQL.Append(" (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerDatosContrato2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As CONTRATOS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("C.IDESTABLECIMIENTO, ")
        strSQL.Append("C.IDPROVEEDOR, ")
        strSQL.Append("C.IDCONTRATO, ")
        strSQL.Append("TDC.DESCRIPCION TIPODOCUMENTO, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("C.FECHADISTRIBUCION, ")
        strSQL.Append("C.IDMODALIDADCOMPRA, ")
        strSQL.Append("MC.DESCRIPCION, ")
        strSQL.Append("C.NUMEROMODALIDADCOMPRA, ")
        strSQL.Append("isnull(PC.NUMERORESOLUCION, '') NUMERORESOLUCION, ")
        strSQL.Append("P.NOMBRE, ")
        strSQL.Append("C.RESOLUCION, ")
        strSQL.Append("C.MODIFICATIVA ")
        strSQL.Append("FROM SAB_UACI_CONTRATOS C ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_MODALIDADESCOMPRA MC ")
        strSQL.Append("ON C.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = CPC.IDCONTRATO ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON CPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON C.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO TDC ")
        strSQL.Append("ON C.IDTIPODOCUMENTO = TDC.IDTIPODOCUMENTO ")
        strSQL.Append("WHERE C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim eC As New CONTRATOS

        Try
            If dr.HasRows Then
                dr.Read()
                eC.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                eC.IDPROVEEDOR = IDPROVEEDOR
                eC.IDCONTRATO = IDCONTRATO
                eC.TIPODOCUMENTO = IIf(dr.Item("TIPODOCUMENTO") Is DBNull.Value, Nothing, dr.Item("TIPODOCUMENTO"))
                eC.NUMEROCONTRATO = IIf(dr.Item("NUMEROCONTRATO") Is DBNull.Value, Nothing, dr.Item("NUMEROCONTRATO"))
                eC.FECHADISTRIBUCION = IIf(dr.Item("FECHADISTRIBUCION") Is DBNull.Value, Nothing, dr.Item("FECHADISTRIBUCION"))
                eC.IDMODALIDADCOMPRA = IIf(dr.Item("IDMODALIDADCOMPRA") Is DBNull.Value, Nothing, dr.Item("IDMODALIDADCOMPRA"))
                eC.DESCRIPCIONMODALIDADCOMPRA = IIf(dr.Item("DESCRIPCION") Is DBNull.Value, Nothing, dr.Item("DESCRIPCION"))
                eC.NUMEROMODALIDADCOMPRA = IIf(dr.Item("NUMEROMODALIDADCOMPRA") Is DBNull.Value, Nothing, dr.Item("NUMEROMODALIDADCOMPRA"))
                eC.RESOLUCIONADJUDICACION = IIf(dr.Item("NUMERORESOLUCION") Is DBNull.Value, Nothing, dr.Item("NUMERORESOLUCION"))
                eC.NOMBREPROVEEDOR = IIf(dr.Item("NOMBRE") Is DBNull.Value, Nothing, dr.Item("NOMBRE"))
                eC.RESOLUCION = IIf(dr.Item("RESOLUCION") Is DBNull.Value, Nothing, dr.Item("RESOLUCION"))
                eC.MODIFICATIVA = IIf(dr.Item("MODIFICATIVA") Is DBNull.Value, Nothing, dr.Item("MODIFICATIVA"))
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return eC

    End Function

    Public Function obtenerDatosAnticipo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPROCESOCOMPRA As Integer) As CONTRATOS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select ")
        strSQL.Append("     distinct ")
        strSQL.Append("       pc.idestablecimiento, ")
        strSQL.Append("       a.idproveedor, ")
        strSQL.Append("       pc.idprocesocompra, ")
        strSQL.Append("       pc.idtipocompraejecutar, ")
        strSQL.Append("       mc.descripcion, ")
        strSQL.Append("       pc.codigolicitacion, ")
        strSQL.Append("       pc.numeroresolucion, ")
        strSQL.Append("       p.nombre ")
        strSQL.Append(" from ")
        strSQL.Append("     sab_uaci_procesocompras pc ")
        strSQL.Append("        inner join sab_uaci_adjudicacion a ")
        strSQL.Append("           on pc.idestablecimiento = a.idestablecimiento and ")
        strSQL.Append("              pc.idprocesocompra = a.idprocesocompra ")
        strSQL.Append("        inner join sab_cat_proveedores p ")
        strSQL.Append("           on a.idproveedor = p.idproveedor ")
        strSQL.Append("        inner join sab_uaci_entregaadjudicacion ea ")
        strSQL.Append("           on a.idestablecimiento = ea.idestablecimiento and ")
        strSQL.Append("              a.idprocesocompra = ea.idprocesocompra and ")
        strSQL.Append("              a.idproveedor = ea.idproveedor and ")
        strSQL.Append("              a.iddetalle = ea.iddetalle ")
        strSQL.Append("       inner join sab_uaci_almacenesentregaadjudicacion aea ")
        strSQL.Append("  	     on ea.idestablecimiento = aea.idestablecimiento and ")
        strSQL.Append("             ea.idprocesocompra = aea.idprocesocompra and ")
        strSQL.Append("             ea.idproveedor = aea.idproveedor and ")
        strSQL.Append("             ea.iddetalle = aea.iddetalle and ")
        strSQL.Append("             ea.identrega = aea.identrega ")
        strSQL.Append("      inner join sab_cat_tipocompras tc ")
        strSQL.Append("         on pc.idtipocompraejecutar = tc.idtipocompra ")
        strSQL.Append("      inner join sab_cat_modalidadescompra mc ")
        strSQL.Append("         on tc.idmodalidadcompra = mc.idmodalidadcompra ")
        strSQL.Append("      left outer join sab_uaci_contratosprocesocompra cpc ")
        strSQL.Append("         on pc.idestablecimiento = cpc.idestablecimiento and ")
        strSQL.Append(" 		   a.idproveedor = cpc.idproveedor and ")
        strSQL.Append(" 		   pc.idprocesocompra = cpc.idprocesocompra ")
        strSQL.Append(" where ")
        strSQL.Append("   cpc.idcontrato is null and ")
        strSQL.Append("   cantidadfirme > 0 and ")
        strSQL.Append("   pc.idestablecimiento = @IDESTABLECIMIENTO AND ")
        strSQL.Append("   a.idproveedor = @IDPROVEEDOR  AND ")
        strSQL.Append("   pc.idprocesocompra = @IDPROCESOCOMPRA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = IDPROCESOCOMPRA

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dr.Read Then

            Dim eEntidad As New CONTRATOS

            eEntidad.IDESTABLECIMIENTO = dr.Item("IDESTABLECIMIENTO")
            eEntidad.IDPROVEEDOR = dr.Item("IDPROVEEDOR")
            eEntidad.IDCONTRATO = dr.Item("IDPROCESOCOMPRA")
            eEntidad.IDMODALIDADCOMPRA = dr.Item("idtipocompraejecutar")
            eEntidad.DESCRIPCIONMODALIDADCOMPRA = dr.Item("DESCRIPCION")
            eEntidad.NUMEROMODALIDADCOMPRA = dr.Item("codigolicitacion")
            eEntidad.RESOLUCIONADJUDICACION = dr.Item("NUMERORESOLUCION")
            eEntidad.NOMBREPROVEEDOR = dr.Item("NOMBRE")

            Return eEntidad
        Else
            Return Nothing
        End If

    End Function

    Public Function ObtenerRenglonesContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT ")
        strSQL.Append("   PC.IDESTABLECIMIENTO, ")
        strSQL.Append("   PC.IDPROVEEDOR, ")
        strSQL.Append("   PC.IDCONTRATO, ")
        strSQL.Append("   PC.RENGLON, ")
        strSQL.Append("   PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("   CP.DESCLARGO, ")
        strSQL.Append("   AEC.IDALMACENENTREGA ")
        strSQL.Append(" FROM SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("   INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("     ON  PC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        strSQL.Append("         PC.IDPROVEEDOR = C.IDPROVEEDOR AND ")
        strSQL.Append("         PC.IDCONTRATO = C.IDCONTRATO ")
        strSQL.Append("   INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("     ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("   INNER JOIN SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("     ON PC.IDESTABLECIMIENTO = EC.IDESTABLECIMIENTO AND ")
        strSQL.Append("        PC.IDPROVEEDOR = EC.IDPROVEEDOR AND ")
        strSQL.Append("        PC.IDCONTRATO = EC.IDCONTRATO AND ")
        strSQL.Append(" 	   PC.RENGLON = EC.RENGLON ")
        strSQL.Append("   INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("     ON EC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO AND ")
        strSQL.Append("        EC.IDPROVEEDOR = AEC.IDPROVEEDOR AND ")
        strSQL.Append("        EC.IDCONTRATO = AEC.IDCONTRATO AND ")
        strSQL.Append("        EC.RENGLON = AEC.RENGLON AND ")
        strSQL.Append("        EC.IDDETALLE = AEC.IDDETALLE ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   PC.ESTAHABILITADO = 1 AND ")
        strSQL.Append("   C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("   C.IDPROVEEDOR = @IDPROVEEDOR AND ")
        strSQL.Append("   C.IDCONTRATO = @IDCONTRATO AND ")
        strSQL.Append("   AEC.IDALMACENENTREGA = @IDALMACEN AND ")
        strSQL.Append("   AEC.CANTIDAD - CANTIDADENTREGADA > 0 ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("   PC.IDPROVEEDOR, PC.IDESTABLECIMIENTO, PC.IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(3).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerRenglonesAdjudicacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select ")
        strSQL.Append("   DISTINCT ")
        strSQL.Append("    a.IDESTABLECIMIENTO, ")
        strSQL.Append("    a.IDPROVEEDOR, ")
        strSQL.Append("    a.IDPROCESOCOMPRA, ")
        strSQL.Append("    do.RENGLON, ")
        strSQL.Append("    do.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("    CP.DESCLARGO, ")
        strSQL.Append("    AEa.IDALMACEN ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_uaci_adjudicacion a ")
        strSQL.Append("     inner join sab_uaci_detalleoferta do ")
        strSQL.Append("       on a.idestablecimiento = do.idestablecimiento and ")
        strSQL.Append("          a.idprocesocompra = do.idprocesocompra and ")
        strSQL.Append("          a.idproveedor = do.idproveedor and ")
        strSQL.Append("          a.iddetalle = do.iddetalle ")
        strSQL.Append("     inner join sab_uaci_entregaadjudicacion ea ")
        strSQL.Append("       on a.idestablecimiento = ea.idestablecimiento and ")
        strSQL.Append("          a.idprocesocompra = ea.idprocesocompra and ")
        strSQL.Append("          a.idproveedor = ea.idproveedor and ")
        strSQL.Append("          a.iddetalle = ea.iddetalle ")
        strSQL.Append("     inner join sab_uaci_almacenesentregaadjudicacion aea ")
        strSQL.Append("       on ea.idestablecimiento = aea.idestablecimiento and ")
        strSQL.Append("          ea.idprocesocompra = aea.idprocesocompra and ")
        strSQL.Append("          ea.idproveedor = aea.idproveedor and ")
        strSQL.Append("          ea.iddetalle = aea.iddetalle and ")
        strSQL.Append("          ea.identrega = aea.identrega ")
        strSQL.Append("     inner join sab_uaci_detalleprocesocompra dpc ")
        strSQL.Append("       on a.idestablecimiento = dpc.idestablecimiento and ")
        strSQL.Append("          a.idprocesocompra = dpc.idprocesocompra and ")
        strSQL.Append("          dpc.renglon = do.renglon ")
        strSQL.Append("     inner join vv_catalogoproductos cp ")
        strSQL.Append("       on dpc.idproducto = cp.idproducto ")
        strSQL.Append("     left outer join sab_uaci_contratosprocesocompra cpc ")
        strSQL.Append("       on a.idestablecimiento = cpc.idestablecimiento and ")
        strSQL.Append("          a.idproveedor = cpc.idproveedor and ")
        strSQL.Append("          a.idprocesocompra = cpc.idprocesocompra ")
        strSQL.Append(" where ")
        strSQL.Append("   a.cantidadfirme > 0 and ")
        strSQL.Append("   cpc.idcontrato is null and ")
        strSQL.Append("   a.idestablecimiento = @IDESTABLECIMIENTO AND ")
        strSQL.Append("   a.idproveedor = @IDPROVEEDOR AND ")
        strSQL.Append("   a.idprocesocompra = @IDPROCESOCOMPRA AND ")
        strSQL.Append("   aea.idalmacen = @IDALMACEN ")
        strSQL.Append(" order by ")
        strSQL.Append("   a.idproveedor, a.idestablecimiento, a.idprocesocompra ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = IDPROCESOCOMPRA
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(3).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

End Class
