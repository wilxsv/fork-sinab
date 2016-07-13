Partial Public Class dbPRODUCTOSCONTRATO

#Region " Metodos Agregados "

    ''' <summary>
    ''' Devuelve un listado con los productos que pertenecen a un contrato especifico. 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento en el que se elaboro el contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato o documento de compra.</param>
    ''' <returns>Dataset con el detalle del contrato.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  31/12/2006    Creado
    ''' </history> 
    Public Function ObtenerDetalleContratoDs(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROVEEDOR, ")
        strSQL.Append("PC.IDCONTRATO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("PC.CANTIDAD, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("(PC.CANTIDAD * PC.PRECIOUNITARIO) TOTAL, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("PC.ESTAHABILITADO, ")
        strSQL.Append("PC.FECHADESHABILITACION, ")
        strSQL.Append("PC.OBSERVACION, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO AS PC ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS AS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE (PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (PC.IDPROVEEDOR = @IDPROVEEDOR) ")
        strSQL.Append("AND (PC.IDCONTRATO = @IDCONTRATO) ")
        strSQL.Append("ORDER BY RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function obtenerRenglonesAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT  SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR, SAB_UACI_PRODUCTOSCONTRATO.IDCONTRATO, ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO.RENGLON ")
        strSQL.Append(" FROM SAB_UACI_PRODUCTOSCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Elimina los productos asociados a un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Indica el identificador del establecimiento.</param>
    ''' <param name="IDPROVEEDOR">Indica el identificador del proveedor.</param>
    ''' <param name="IDCONTRATO ">Indica el identificador del contrato.</param>
    ''' <returns>Devuelve un valor numerico que indica el resultado de la operación.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  13/02/2007    Creado
    ''' </history> 
    ''' 
    Public Function EliminarProductosAsociados(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_PRODUCTOSCONTRATO ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    'Jrivas
    Public Function obtenerProductosAdjudicadosContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_PRODUCTOSCONTRATO.RENGLON, SAB_UACI_PRODUCTOSCONTRATO.IDPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO.CANTIDAD, SAB_UACI_PRODUCTOSCONTRATO.PRECIOUNITARIO, 0 AS 'IDMODIFICATIVA' ")
        strSQL.Append(" FROM SAB_UACI_PRODUCTOSCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS ON SAB_UACI_PRODUCTOSCONTRATO.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO ")
        strSQL.Append(" WHERE (SAB_UACI_PRODUCTOSCONTRATO.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_PRODUCTOSCONTRATO.IDCONTRATO = " & IDCONTRATO & ") AND ")
        strSQL.Append(" (SAB_UACI_PRODUCTOSCONTRATO.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (NOT (SAB_UACI_PRODUCTOSCONTRATO.RENGLON IN ")
        strSQL.Append(" (SELECT RENGLON ")
        strSQL.Append(" FROM SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ")))) ")
        strSQL.Append(" UNION ")
        strSQL.Append(" SELECT SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.RENGLON, SAB_CAT_CATALOGOPRODUCTOS_1.IDPRODUCTO, ")
        strSQL.Append(" SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.DESCRIPCION AS NOMBRE, ")
        strSQL.Append(" SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.CANTIDADCONTRATADA AS CANTIDAD, ")
        strSQL.Append(" SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.PRECIOUNITARIO, SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.IDMODIFICATIVA ")
        strSQL.Append(" FROM SAB_UACI_PRODUCTOSCONTRATO AS SAB_UACI_PRODUCTOSCONTRATO_1 INNER JOIN ")
        strSQL.Append(" SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO AS SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1 ON ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO_1.IDESTABLECIMIENTO = SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO_1.IDPROVEEDOR = SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO_1.IDCONTRATO = SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.IDCONTRATO AND ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO_1.RENGLON = SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.RENGLON INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS AS SAB_CAT_CATALOGOPRODUCTOS_1 ON ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO_1.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS_1.IDPRODUCTO ")
        strSQL.Append(" WHERE (SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.IDPROVEEDOR = " & IDPROVEEDOR & ") AND ")
        strSQL.Append(" (SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO_1.IDCONTRATO = " & IDCONTRATO & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Verifica si el número de renglon o linea ya fue utilizado por otro
    ''' producto.
    ''' </summary>
    ''' <param name="aEntidad">Entidad con los valores de busqueda del renglón</param>
    ''' <returns>Retorna un valor númerico que define si el renglón ya fue utilizado o no</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/03/2007    Creado
    ''' </history>
    Public Function ValidarRenglonNoUaci(ByVal aEntidad As PRODUCTOSCONTRATO) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(RENGLON) ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = aEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = aEntidad.RENGLON

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Verifica si el número de renglon o linea ya fue utilizado por otro
    ''' producto.
    ''' </summary>
    ''' <param name="aEntidad">Entidad con los valores de busqueda del renglón</param>
    ''' <returns>Retorna un valor númerico que define si el renglón ya fue utilizado o no</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/03/2007    Creado
    ''' </history>
    Public Function ValidarProductoNoUaci(ByVal aEntidad As PRODUCTOSCONTRATO) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT RENGLON ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND PRECIOUNITARIO = @PRECIOUNITARIO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = aEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(3).Value = aEntidad.IDPRODUCTO
        args(4) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Decimal)
        args(4).Value = aEntidad.PRECIOUNITARIO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve todos los renglones de un contrato, actualizados según la última 
    ''' modificativa que se haya registrado para cada uno de ellos.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns>Un dataset con todos los renglones del contrato.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]  11/03/2007    Creado
    ''' </history>
    Public Function ObtenerRenglonesContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROVEEDOR, ")
        strSQL.Append("PC.IDCONTRATO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("PC.CANTIDAD CANTIDAD, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("isnull(PC.DESCRIPCIONPROVEEDOR, '') DESCRIPCION, ")
        strSQL.Append("PC.ESTAHABILITADO, ")
        strSQL.Append("PC.FECHADESHABILITACION, ")
        strSQL.Append("PC.OBSERVACION, ")
        strSQL.Append("isnull(MCP.IDMODIFICATIVA, 0) IDMODIFICATIVA, ")
        strSQL.Append("isnull(MCP.CANTIDADCONTRATADA, 0) CANTIDAD1, ")
        strSQL.Append("isnull(MCP.PRECIOUNITARIO, 0) PRECIOUNITARIO1, ")
        strSQL.Append("isnull(MCP.DESCRIPCION, '') DESCRIPCION1, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO MCP ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = MCP.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = MCP.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = MCP.IDCONTRATO ")
        strSQL.Append("AND PC.RENGLON = MCP.RENGLON) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND PC.RENGLON = @RENGLON ")
        'strSQL.Append("AND PC.ESTAHABILITADO = 1 ")
        strSQL.Append("AND MCP.IDESTABLECIMIENTO is null ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROVEEDOR, ")
        strSQL.Append("PC.IDCONTRATO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("MCP.CANTIDADCONTRATADA CANTIDAD, ")
        strSQL.Append("MCP.PRECIOUNITARIO, ")
        strSQL.Append("isnull(MCP.DESCRIPCION, '') DESCRIPCION, ")
        strSQL.Append("PC.ESTAHABILITADO, ")
        strSQL.Append("PC.FECHADESHABILITACION, ")
        strSQL.Append("PC.OBSERVACION, ")
        strSQL.Append("MCP.IDMODIFICATIVA IDMODIFICATIVA, ")
        strSQL.Append("PC.CANTIDAD CANTIDAD1, ")
        strSQL.Append("PC.PRECIOUNITARIO PRECIOUNITARIO1, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR DESCRIPCION1, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA ")
        strSQL.Append("FROM SAB_UACI_MODIFICATIVASCONTRATO MC ")
        strSQL.Append("INNER JOIN SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO MCP ")
        strSQL.Append("ON (MCP.IDESTABLECIMIENTO = MC.IDESTABLECIMIENTO ")
        strSQL.Append("AND MCP.IDPROVEEDOR = MC.IDPROVEEDOR ")
        strSQL.Append("AND MCP.IDCONTRATO = MC.IDCONTRATO ")
        strSQL.Append("AND MCP.IDMODIFICATIVA = MC.IDMODIFICATIVA) ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON (MCP.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND MCP.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND MCP.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND MCP.RENGLON = PC.RENGLON) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("MC.FECHAMODIFICATIVA = ( ")
        strSQL.Append("                        SELECT ")
        strSQL.Append("                        MAX(MC2.FECHAMODIFICATIVA) ")
        strSQL.Append("                        FROM SAB_UACI_MODIFICATIVASCONTRATO MC2 ")
        strSQL.Append("                        INNER JOIN SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO MCP2 ")
        strSQL.Append("                        ON (MCP2.IDESTABLECIMIENTO = MC2.IDESTABLECIMIENTO ")
        strSQL.Append("                        AND MCP2.IDPROVEEDOR = MC2.IDPROVEEDOR ")
        strSQL.Append("                        AND MCP2.IDCONTRATO = MC2.IDCONTRATO ")
        strSQL.Append("                        AND MCP2.IDMODIFICATIVA = MC2.IDMODIFICATIVA) ")
        strSQL.Append("                        WHERE ")
        strSQL.Append("                        MC2.IDESTABLECIMIENTO = MC.IDESTABLECIMIENTO ")
        strSQL.Append("                        AND MC2.IDPROVEEDOR = MC.IDPROVEEDOR ")
        strSQL.Append("                        AND MC2.IDCONTRATO = MC.IDCONTRATO ")
        strSQL.Append("                        AND MCP2.RENGLON = MCP.RENGLON ")
        strSQL.Append("                        ) ")
        strSQL.Append("AND PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND PC.RENGLON = @RENGLON ")
        'strSQL.Append("AND PC.ESTAHABILITADO = 1 ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve todos los renglones de un contrato, actualizados según la última 
    ''' modificativa que se haya registrado para cada uno de ellos.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns>Un dataset con todos los renglones del contrato.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]  11/03/2007    Creado
    ''' </history>
    Public Function ObtenerRenglonesContratoConEntregas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROVEEDOR, ")
        strSQL.Append("PC.IDCONTRATO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("PC.CANTIDAD CANTIDAD, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("isnull(PC.DESCRIPCIONPROVEEDOR, '') DESCRIPCION, ")
        strSQL.Append("PC.ESTAHABILITADO, ")
        strSQL.Append("PC.FECHADESHABILITACION, ")
        strSQL.Append("PC.OBSERVACION, ")
        strSQL.Append("isnull(MCP.IDMODIFICATIVA, 0) IDMODIFICATIVA, ")
        strSQL.Append("isnull(MCP.CANTIDADCONTRATADA, 0) CANTIDAD1, ")
        strSQL.Append("isnull(MCP.PRECIOUNITARIO, 0) PRECIOUNITARIO1, ")
        strSQL.Append("isnull(MCP.DESCRIPCION, '') DESCRIPCION1, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("isnull(SUM(AEC.CANTIDADENTREGADA), 0) CANTIDADENTREGADA, ")
        strSQL.Append("isnull((SELECT MAX(IDCANCELACION) ")
        strSQL.Append("        FROM SAB_UACI_CANCELACIONPRODUCTO CP ")
        strSQL.Append("        WHERE(CP.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO) ")
        strSQL.Append("        AND CP.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("        AND CP.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("        AND CP.RENGLON = PC.RENGLON), 0) IDCANCELACION ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO MCP ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = MCP.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = MCP.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = MCP.IDCONTRATO ")
        strSQL.Append("AND PC.RENGLON = MCP.RENGLON) ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = AEC.IDCONTRATO ")
        strSQL.Append("AND PC.RENGLON = AEC.RENGLON) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND AEC.CANTIDAD > AEC.CANTIDADENTREGADA ")
        strSQL.Append("AND MCP.IDESTABLECIMIENTO is null ")
        strSQL.Append("AND (PC.RENGLON = @RENGLON OR @RENGLON = 0) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROVEEDOR, ")
        strSQL.Append("PC.IDCONTRATO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("PC.CANTIDAD, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("PC.ESTAHABILITADO, ")
        strSQL.Append("PC.FECHADESHABILITACION, ")
        strSQL.Append("PC.OBSERVACION, ")
        strSQL.Append("MCP.IDMODIFICATIVA, ")
        strSQL.Append("MCP.CANTIDADCONTRATADA, ")
        strSQL.Append("MCP.PRECIOUNITARIO, ")
        strSQL.Append("MCP.DESCRIPCION, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROVEEDOR, ")
        strSQL.Append("PC.IDCONTRATO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("MCP.CANTIDADCONTRATADA CANTIDAD, ")
        strSQL.Append("MCP.PRECIOUNITARIO, ")
        strSQL.Append("isnull(MCP.DESCRIPCION, '') DESCRIPCION, ")
        strSQL.Append("PC.ESTAHABILITADO, ")
        strSQL.Append("PC.FECHADESHABILITACION, ")
        strSQL.Append("PC.OBSERVACION, ")
        strSQL.Append("MCP.IDMODIFICATIVA IDMODIFICATIVA, ")
        strSQL.Append("PC.CANTIDAD CANTIDAD1, ")
        strSQL.Append("PC.PRECIOUNITARIO PRECIOUNITARIO1, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR DESCRIPCION1, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("isnull(SUM(AEC.CANTIDADENTREGADA), 0) CANTIDADENTREGADA, ")
        strSQL.Append("isnull((SELECT MAX(IDCANCELACION) ")
        strSQL.Append("        FROM SAB_UACI_CANCELACIONPRODUCTO CP ")
        strSQL.Append("        WHERE(CP.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO) ")
        strSQL.Append("        AND CP.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("        AND CP.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("        AND CP.RENGLON = PC.RENGLON), 0) IDCANCELACION ")
        strSQL.Append("FROM SAB_UACI_MODIFICATIVASCONTRATO MC ")
        strSQL.Append("INNER JOIN SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO MCP ")
        strSQL.Append("ON (MCP.IDESTABLECIMIENTO = MC.IDESTABLECIMIENTO ")
        strSQL.Append("AND MCP.IDPROVEEDOR = MC.IDPROVEEDOR ")
        strSQL.Append("AND MCP.IDCONTRATO = MC.IDCONTRATO ")
        strSQL.Append("AND MCP.IDMODIFICATIVA = MC.IDMODIFICATIVA) ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON (MCP.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND MCP.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND MCP.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND MCP.RENGLON = PC.RENGLON) ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = AEC.IDCONTRATO ")
        strSQL.Append("AND PC.RENGLON = AEC.RENGLON) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("MC.FECHAMODIFICATIVA = ( ")
        strSQL.Append("                        SELECT ")
        strSQL.Append("                        MAX(MC2.FECHAMODIFICATIVA) ")
        strSQL.Append("                        FROM SAB_UACI_MODIFICATIVASCONTRATO MC2 ")
        strSQL.Append("                        INNER JOIN SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO MCP2 ")
        strSQL.Append("                        ON (MCP2.IDESTABLECIMIENTO = MC2.IDESTABLECIMIENTO ")
        strSQL.Append("                        AND MCP2.IDPROVEEDOR = MC2.IDPROVEEDOR ")
        strSQL.Append("                        AND MCP2.IDCONTRATO = MC2.IDCONTRATO ")
        strSQL.Append("                        AND MCP2.IDMODIFICATIVA = MC2.IDMODIFICATIVA) ")
        strSQL.Append("                        WHERE ")
        strSQL.Append("                        MC2.IDESTABLECIMIENTO = MC.IDESTABLECIMIENTO ")
        strSQL.Append("                        AND MC2.IDPROVEEDOR = MC.IDPROVEEDOR ")
        strSQL.Append("                        AND MC2.IDCONTRATO = MC.IDCONTRATO ")
        strSQL.Append("                        AND MCP2.RENGLON = MCP.RENGLON ")
        strSQL.Append("                        ) ")
        strSQL.Append("AND PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND AEC.CANTIDAD > AEC.CANTIDADENTREGADA ")
        strSQL.Append("AND (PC.RENGLON = @RENGLON OR @RENGLON = 0) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROVEEDOR, ")
        strSQL.Append("PC.IDCONTRATO, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("PC.IDUNIDADMEDIDA, ")
        strSQL.Append("MCP.CANTIDADCONTRATADA, ")
        strSQL.Append("MCP.PRECIOUNITARIO, ")
        strSQL.Append("MCP.DESCRIPCION, ")
        strSQL.Append("PC.ESTAHABILITADO, ")
        strSQL.Append("PC.FECHADESHABILITACION, ")
        strSQL.Append("PC.OBSERVACION, ")
        strSQL.Append("MCP.IDMODIFICATIVA, ")
        strSQL.Append("PC.CANTIDAD, ")
        strSQL.Append("PC.PRECIOUNITARIO, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function HabilitarRecepcionesRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal ESTAHABILITADO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_PRODUCTOSCONTRATO ")
        strSQL.Append("SET ESTAHABILITADO = @ESTAHABILITADO ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND RENGLON = @RENGLON ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON
        args(4) = New SqlParameter("@ESTAHABILITADO", SqlDbType.Int)
        args(4).Value = ESTAHABILITADO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerTiposSuministroContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CP.DESCSUMINISTRO ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO ")
        strSQL.Append("ORDER BY ")
        strSQL.Append("CP.CORRSUMINISTRO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim dr As SqlClient.SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim s As String = String.Empty

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    If s <> String.Empty Then s += ", "
                    s += dr.Item(0)
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return s

    End Function

#End Region

End Class
