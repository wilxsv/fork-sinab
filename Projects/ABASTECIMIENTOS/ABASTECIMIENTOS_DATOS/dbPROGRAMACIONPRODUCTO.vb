Imports System.Text
''' <summary>
''' Contiene funciones y métodos para la manipulación y lectura de  información de los productos de las programaciones de compra
''' </summary>
''' <remarks></remarks>
Public Class dbPROGRAMACIONPRODUCTO
    Inherits dbBase

#Region "Sin utilizar"
    Public Overrides Function Actualizar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As ENTIDADES.entidadBase) As String
        Return String.Empty
    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function
#End Region

    ''' <summary>
    ''' Obtiene el listado de productos de una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="C">Filtro de reporte a generar</param>
    ''' <param name="IDPROGRAMA">Identificador del programa a consultar</param>
    ''' <returns>Lista de productos para la programación en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerProgramacionProductos(ByVal IDPROGRAMACION As Integer, Optional ByVal C As Boolean = False, Optional ByVal IDPROGRAMA As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" SELECT ")
        strSQL.Append("   PP.IDPROGRAMACION, CP.CORRPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION as UM, PP.PRECIO, convert(decimal(15,4),(PP.PRECIO*(1+(P.INDICEINFLACION/100)))) AS PRECIOAJUSTADO, PP.IDPRODUCTO, cp.idsuministro ")
        strSQL.Append(" FROM ")
        strSQL.Append("     SAB_URMIM_PROGRAMACION P ")
        strSQL.Append("     INNER JOIN SAB_URMIM_PROGRAMACIONPRODUCTO PP ")
        strSQL.Append("       ON P.IDPROGRAMACION = PP.IDPROGRAMACION ")
        strSQL.Append("     INNER JOIN VV_CATALOGOPRODUCTOS CP ")
        strSQL.Append("       ON PP.IDPRODUCTO = CP.IDPRODUCTO ")

        If IDPROGRAMA > 0 Then
            strSQL.Append("     INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PRP ")
            strSQL.Append("       ON PP.IDPRODUCTO = PRP.IDPRODUCTO ")
        End If

        strSQL.Append(" WHERE PP.IDPROGRAMACION = @IDPROGRAMACION ")

        If C Then
            strSQL.Append(" AND (PP.PRECIO*(1+(P.INDICEINFLACION/100))) = 0 ")
        End If

        If IDPROGRAMA > 0 Then
            strSQL.Append(" AND PRP.IDPROGRAMA = @IDPROGRAMA ")
        End If

        If IDPROGRAMA = -1 Then
            strSQL.Append(" AND (PP.IDPRODUCTO NOT IN (SELECT DISTINCT IDPRODUCTO FROM SAB_CAT_PRODUCTOSPROGRAMAS)) ")
        End If

        strSQL.Append(" ORDER BY ")

        strSQL.Append("   CP.CORRPRODUCTO ASC ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(1).Value = IDPROGRAMA

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el listado de productos de una programación específica según el tipo de establecimiento
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="IDTIPOESTABLECIMIENTO">Identificador del tipo de establecimiento que se desea consultar</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro de los productos a consultar</param>
    ''' <returns>Lista de productos de la programación para el tipo de establecimiento en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerProgramacionProductos2(ByVal IDPROGRAMACION As Integer, ByVal IDTIPOESTABLECIMIENTO As Integer, Optional ByVal IDSUMINISTRO As Integer = 1) As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" SELECT ")
        strSQL.Append("   PP.IDPROGRAMACION, CP.CORRPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION as UM, PP.PRECIO, (PP.PRECIO*(1+(P.INDICEINFLACION/100))) AS PRECIOAJUSTADO, PP.IDPRODUCTO ")
        strSQL.Append(" FROM ")
        strSQL.Append("     SAB_URMIM_PROGRAMACION P ")
        strSQL.Append("     INNER JOIN SAB_URMIM_PROGRAMACIONPRODUCTO PP ")
        strSQL.Append("       ON P.IDPROGRAMACION = PP.IDPROGRAMACION ")
        strSQL.Append("     INNER JOIN VV_CATALOGOPRODUCTOS CP ")
        strSQL.Append("       ON PP.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE PP.IDPROGRAMACION = @IDPROGRAMACION ")

        If IDTIPOESTABLECIMIENTO = 10 And IDSUMINISTRO = 1 Then
            strSQL.Append("AND CP.IDNIVELUSO IN (1, 2, 4) ")
        End If

        strSQL.Append(" ORDER BY ")
        strSQL.Append("   CP.DESCLARGO ASC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el listado de productos de una programación para un establecimiento específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento a consultar</param>
    ''' <returns>Lista de productos de la programación para el establecimiento en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerProgramacionProductosEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" SELECT ")
        strSQL.Append("   PP.IDPROGRAMACION, PP.IDESTABLECIMIENTO, CP.CORRPRODUCTO, CP.DESCLARGO, PP.COMPRATRANSITO, PP.IDPRODUCTO, ")
        strSQL.Append("   CASE CP.CLASIFICACION  ")
        strSQL.Append("     WHEN 'E' THEN 'Esencial' ")
        strSQL.Append("     WHEN 'V' THEN 'Vital' ")
        strSQL.Append("     WHEN 'N' THEN 'No esencial' ")
        strSQL.Append("     WHEN '1' THEN 'Prioridad 1' ")
        strSQL.Append("     WHEN '2' THEN 'Prioridad 2' ")
        strSQL.Append("     ELSE 'No definido' ")
        strSQL.Append("   END AS CLASIFICACION ")
        strSQL.Append(" FROM ")
        strSQL.Append("     SAB_URMIM_PROGRAMACION P ")
        strSQL.Append("     INNER JOIN SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO PP ")
        strSQL.Append("       ON P.IDPROGRAMACION = PP.IDPROGRAMACION ")
        strSQL.Append("     INNER JOIN VV_CATALOGOPRODUCTOS CP ")
        strSQL.Append("       ON PP.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE PP.IDPROGRAMACION = @IDPROGRAMACION AND ")
        strSQL.Append(" PP.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("   CP.CORRPRODUCTO ASC ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el detalle de una programación para un establecimiento específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento a consultar</param>
    ''' <param name="m">Cobertura del programa de compras</param>
    ''' <param name="n">Meses para el cálculo del CPM</param>
    ''' <param name="reporte">Especifica si la consulta es para la generación de un reporte</param>
    ''' <param name="ordenABC">Especifica el tipo de filtro utilizado</param>
    ''' <returns>Detalle de la programación para el establecimiento en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerProgramacionProductosDetalle(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal m As Integer, ByVal n As Integer, Optional ByVal reporte As Integer = 0, Optional ByVal ordenABC As Boolean = False) As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" select * from fn_ConsultaProgramacion(@IDPROGRAMACION, @IDESTABLECIMIENTO)  ")
        'strSQL.Append(" where clasificacion in ('V', 'E', 'N') ")
        'strSQL.Append(" where ")

        If reporte = 1 Then
            strSQL.Append("where  montototal > 0 ")
        ElseIf reporte = 2 Then
            strSQL.Append("where  montototalajustado > 0 ")
        ElseIf reporte = 3 Then
            strSQL.Append("where  (montototalajustado > 0 or montototal > 0) ")
        End If

        If ordenABC Then
            strSQL.Append(" order by montoTotal desc ")
        Else
            strSQL.Append(" order by corrproducto asc ")
        End If

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el detalle de una programación para un establecimiento específico con una cobertura definida
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento a consultar</param>
    ''' <param name="m">Cobertura del programa de compras</param>
    ''' <returns>Detalle de la programación para el establecimiento en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerProgramacionProductosDetalle2(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal m As Integer) As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" select * from fn_ConsultaProgramacion(@IDPROGRAMACION, @IDESTABLECIMIENTO)  ")
        'strSQL.Append(" where clasificacion in ('V', 'E', 'N') ")
        strSQL.Append(" where ")
        strSQL.Append(" cobertura < @M ")
        strSQL.Append(" order by corrproducto asc ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@M", SqlDbType.Int)
        args(2).Value = m

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function obtenerProgramacionProductosDetalle3(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" select * from fn_ConsultaProgramacion2(@IDPROGRAMACION, @IDESTABLECIMIENTO)  ")
        'strSQL.Append(" where clasificacion in ('V', 'E', 'N') ")
        'strSQL.Append(" where ")
        'strSQL.Append(" cobertura < @M ")
        strSQL.Append(" order by corrproducto asc ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        'args(2) = New SqlParameter("@M", SqlDbType.Int)
        'args(2).Value = m

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtiene el detalle consolidado de una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="ordenABC">Filtro de reporte a generar</param>
    ''' <param name="IDPROGRAMA">Identificador del programa a consultar</param>
    ''' <returns>Detalle consolidado de la programación en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerProgramacionProductosConsolidado(ByVal IDPROGRAMACION As Integer, Optional ByVal ordenABC As Boolean = False, Optional ByVal IDPROGRAMA As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" select ")
        strSQL.Append("   cp.corrproducto, cp.desclargo, cp.descripcion, sum(cp.cantidadcomprarajustada) as cantidadcomprar, ")
        strSQL.Append("   (sum(cp.cantidadcomprarajustada)*cp.precio) as montototal, cp.grupo, cp.descclase, cp.clasificacion, ")
        strSQL.Append("   (sum(cp.cantidadcomprarajustada)*cp.precio) as montototalajustado, sum(cp.cantidadcomprarajustada) as cantidadcomprarajustada, cp.precio ")
        strSQL.Append(" from ")
        strSQL.Append("   fn_ConsultaProgramacion(@IDPROGRAMACION, @IDESTABLECIMIENTO) cp ")

        If IDPROGRAMA > 0 Then
            strSQL.Append("   INNER JOIN sab_cat_productosprogramas pp on cp.idProducto = pp.idProducto ")
            strSQL.Append(" WHERE pp.idPrograma = @IDPROGRAMA ")
        End If

        If IDPROGRAMA = -1 Then
            strSQL.Append("   WHERE cp.idProducto not in (SELECT DISTINCT IDPRODUCTO FROM SAB_CAT_PRODUCTOSPROGRAMAS) ")
        End If

        strSQL.Append(" group by ")
        strSQL.Append("   cp.corrproducto, cp.desclargo, cp.descripcion, cp.precio, cp.grupo, cp.descclase, cp.clasificacion ")
        strSQL.Append(" having (sum(cp.cantidadcomprarajustada)) > 0 ")
        'strSQL.Append(" having (sum(cp.cantidadcomprarajustada)*cp.precio) > 0 ")
        'strSQL.Append(" having (sum(cp.cantidadcomprarajustada)*cp.precio) > 0 and cp.clasificacion in ('V', 'E', 'N') ")

        If ordenABC Then
            strSQL.Append(" order by (sum(cp.cantidadcomprarajustada)*cp.precio) desc ")
        Else
            strSQL.Append(" order by corrproducto asc ")
        End If

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = 0
        args(2) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(2).Value = IDPROGRAMA

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el detalle de la programación para un producto específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="IDPRODUCTO">Identificador del producto a consultar</param>
    ''' <param name="IDPROGRAMA">Identificador del programa a consultar</param>
    ''' <returns>Detalle de la programación para el producto en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerProgramacionDetallePorProducto(ByVal IDPROGRAMACION As Integer, ByVal IDPRODUCTO As Integer, Optional ByVal IDPROGRAMA As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" select ")
        strSQL.Append("   e.nombre as establecimiento, cp.corrproducto, cp.desclargo, cp.cantidadcomprarajustada as cantidadcomprarajustada, ")
        strSQL.Append("   (cp.precio*cp.cantidadcomprarajustada) as montototalajustado, cp.precio ")
        strSQL.Append(" from ")
        strSQL.Append("   fn_ConsultaProgramacion(@IDPROGRAMACION, 0) cp ")
        strSQL.Append("     inner join SAB_CAT_ESTABLECIMIENTOS e ")
        strSQL.Append("       on cp.idEstablecimiento = e.idEstablecimiento ")
        strSQL.Append("     inner join SAB_CAT_CATALOGOPRODUCTOS cp1 ")
        strSQL.Append("       on cp.corrproducto = cp1.codigo ")

        If IDPROGRAMA > 0 Then
            strSQL.Append("   INNER JOIN sab_cat_productosprogramas pp on cp.idProducto = pp.idProducto ")
        End If

        strSQL.Append(" WHERE ")
        strSQL.Append("   (cp1.idProducto = @IDPRODUCTO OR @IDPRODUCTO = 0) and cp.cantidadcomprarajustada > 0 ")

        If IDPROGRAMA = -1 Then
            strSQL.Append("   AND (cp.idProducto not in (SELECT DISTINCT IDPRODUCTO FROM SAB_CAT_PRODUCTOSPROGRAMAS)) ")
        End If

        If IDPROGRAMA > 0 Then
            strSQL.Append(" AND pp.idPrograma = @IDPROGRAMA ")
        End If

        strSQL.Append(" ORDER BY ")
        strSQL.Append("   cp.corrproducto, e.nombre ASC ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(2).Value = IDPROGRAMA

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Agrega un producto a una programación específica
    ''' </summary>
    ''' <param name="aEntidad">Entidad relacionada al producto de la programación</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function agregarProgramacionProducto(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

        Dim lEntidad As PROGRAMACIONPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO ")
        strSQL.Append("  SAB_URMIM_PROGRAMACIONPRODUCTO(")
        strSQL.Append("  IDPROGRAMACION, IDPRODUCTO, PRECIO, ")
        strSQL.Append("  AUUSUARIOCREACION, AUFECHACREACION ")
        strSQL.Append("  ) ")
        strSQL.Append("  VALUES(")
        strSQL.Append("  @IDPROGRAMACION, @IDPRODUCTO, @PRECIO, ")
        strSQL.Append("  @AUUSUARIOCREACION, @AUFECHACREACION ")
        strSQL.Append("  ) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(2).Value = lEntidad.PRECIO
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Value = lEntidad.AUUSUARIOCREACION
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Value = lEntidad.AUFECHACREACION

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza un producto de una programación específica
    ''' </summary>
    ''' <param name="aEntidad">Entidad relacionada al producto de la programación</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarProgramacionProducto(ByVal aEntidad As ENTIDADES.entidadBase, ByVal tran As DistributedTransaction) As Integer

        Dim lEntidad As PROGRAMACIONPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_URMIM_PROGRAMACIONPRODUCTO ")
        strSQL.Append("  SET PRECIO = @PRECIO, ")
        strSQL.Append("  AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDPROGRAMACION = @IDPROGRAMACION AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(2).Value = lEntidad.PRECIO
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = lEntidad.AUUSUARIOMODIFICACION
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = lEntidad.AUFECHAMODIFICACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza un producto de una programación de un establecimiento específico
    ''' </summary>
    ''' <param name="aEntidad">Entidad relacionada al producto de la programación</param>
    ''' <param name="eEntidad">Entidad relacionada a la programación</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarProgramacionProductoEstablecimiento(ByVal aEntidad As ENTIDADES.entidadBase, ByVal eEntidad As PROGRAMACION, ByVal tran As DistributedTransaction) As Integer

        Dim lEntidad As PROGRAMACIONPRODUCTO
        Dim m As Integer
        Dim n As Integer
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
        strSQL.Append("  SET COMPRATRANSITO = @COMPRATRANSITO, CANTIDADALMACEN = @CANTIDADALMACEN, CANTIDADREGION = @CANTIDADREGION, ")
        strSQL.Append("  CONSUMOPROMEDIOAJUSTADO = @CONSUMOPROMEDIO, AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("  COBERTURA = @COBERTURA, CANTIDADCOMPRAR = @CANTIDADCOMPRAR, CANTIDADCOMPRARAJUSTADA = @CANTIDADCOMPRAR ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDPROGRAMACION = @IDPROGRAMACION AND IDPRODUCTO = @IDPRODUCTO AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim m1 As Integer = DateDiff(DateInterval.Month, eEntidad.FECHAPROGRAMACION, eEntidad.FECHAPROYECCION) + 1
        If m1 < 0 Then m1 = 0

        m = m1
        n = eEntidad.MESESPLANEACION
        'Calculo de la cobertura y de los montos
        Dim cobertura As Integer
        Dim cantidadComprar As Decimal

        If lEntidad.CONSUMOPROMEDIO = 0 Then
            cobertura = 0
            'modificar la cantidad en almacen validando fecha de vencimiento
        Else
            cobertura = Math.Round((lEntidad.COMPRATRANSITO + lEntidad.CANTIDADALMACEN + lEntidad.CANTIDADREGION) / lEntidad.CONSUMOPROMEDIO, 0)
        End If

        If cobertura >= (m + n) Then
            cantidadComprar = 0
        ElseIf cobertura > m And cobertura < (m + n) Then
            cantidadComprar = Math.Ceiling(lEntidad.CONSUMOPROMEDIO * (m + n - cobertura))
        Else
            cantidadComprar = Math.Ceiling(lEntidad.CONSUMOPROMEDIO * n)
        End If

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@COMPRATRANSITO", SqlDbType.Decimal)
        args(2).Value = lEntidad.COMPRATRANSITO
        args(3) = New SqlParameter("@CANTIDADALMACEN", SqlDbType.Decimal)
        args(3).Value = lEntidad.CANTIDADALMACEN
        args(4) = New SqlParameter("@CANTIDADREGION", SqlDbType.Decimal)
        args(4).Value = lEntidad.CANTIDADREGION
        args(5) = New SqlParameter("@CONSUMOPROMEDIO", SqlDbType.Decimal)
        args(5).Value = lEntidad.CONSUMOPROMEDIO
        args(6) = New SqlParameter("@COBERTURA", SqlDbType.Int)
        args(6).Value = cobertura
        args(7) = New SqlParameter("@CANTIDADCOMPRAR", SqlDbType.Decimal)
        args(7).Value = cantidadComprar
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = lEntidad.AUUSUARIOMODIFICACION
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = lEntidad.AUFECHAMODIFICACION
        args(10) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(10).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza el consumo ajustado de un producto de una programación para un establecimiento específico
    ''' </summary>
    ''' <param name="eEntidad">Entidad relacionada al producto de la programación</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarProgramacionAjusteProductoEstablecimiento(ByVal eEntidad As PROGRAMACIONPRODUCTO, ByVal tran As DistributedTransaction) As Integer

        Dim m As Integer
        Dim n As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
        strSQL.Append("  SET CONSUMOPROMEDIOAJUSTADO = @CONSUMOPROMEDIO, AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("  DIASDESABASTECIDOS = @DIASDESABASTECIDOS, DEMANDAINSATISFECHA = @DEMANDAINSATISFECHA, ")
        strSQL.Append("  COBERTURA = @COBERTURA, CANTIDADCOMPRAR = @CANTIDADCOMPRAR, CANTIDADCOMPRARAJUSTADA = @CANTIDADCOMPRAR ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDPROGRAMACION = @IDPROGRAMACION AND IDPRODUCTO = @IDPRODUCTO AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim m1 As Integer = DateDiff(DateInterval.Month, eEntidad.FECHAPROGRAMACION, eEntidad.FECHAPROYECCION) + 1
        If m1 < 0 Then m1 = 0

        m = m1
        n = eEntidad.MESESPLANEACION
        Dim cobertura As Integer
        Dim cantidadComprar As Decimal

        If eEntidad.CONSUMOPROMEDIO = 0 Then
            cobertura = 0
        Else
            cobertura = Math.Round((eEntidad.COMPRATRANSITO + eEntidad.CANTIDADALMACEN + eEntidad.CANTIDADREGION) / eEntidad.CONSUMOPROMEDIO, 0)
        End If

        If cobertura >= (m + n) Then
            cantidadComprar = 0
        ElseIf cobertura > m And cobertura < (m + n) Then
            cantidadComprar = Math.Ceiling(eEntidad.CONSUMOPROMEDIO * (m + n - cobertura))
        Else
            cantidadComprar = Math.Ceiling(eEntidad.CONSUMOPROMEDIO * n)
        End If

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = eEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@CONSUMOPROMEDIO", SqlDbType.Decimal)
        args(2).Value = eEntidad.CONSUMOPROMEDIO
        args(3) = New SqlParameter("@DIASDESABASTECIDOS", SqlDbType.Int)
        args(3).Value = eEntidad.DIASDESABASTECIDOS
        args(4) = New SqlParameter("@DEMANDAINSATISFECHA", SqlDbType.Decimal)
        args(4).Value = eEntidad.DEMANDAINSATISFECHA
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = eEntidad.AUUSUARIOMODIFICACION
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = Now
        args(7) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(7).Value = eEntidad.IDESTABLECIMIENTO
        args(8) = New SqlParameter("@COBERTURA", SqlDbType.Int)
        args(8).Value = cobertura
        args(9) = New SqlParameter("@CANTIDADCOMPRAR", SqlDbType.Decimal)
        args(9).Value = cantidadComprar

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza la cantidad a comprar ajustada de un producto de una programación para un establecimiento específico
    ''' </summary>
    ''' <param name="aEntidad">Entidad relacionada al producto de la programación</param>
    ''' <param name="eEntidad">Entidad relacionada a la programación</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarProgramacionAjusteEstablecimiento(ByVal aEntidad As ENTIDADES.entidadBase, ByVal eEntidad As PROGRAMACION, ByVal tran As DistributedTransaction) As Integer

        Dim lEntidad As PROGRAMACIONPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
        strSQL.Append("  SET CANTIDADCOMPRARAJUSTADA = @CANTIDADCOMPRARAJUSTADA, AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDPROGRAMACION = @IDPROGRAMACION AND IDPRODUCTO = @IDPRODUCTO AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@CANTIDADCOMPRARAJUSTADA", SqlDbType.Decimal)
        args(2).Value = lEntidad.CANTIDADCOMPRAR
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = lEntidad.AUUSUARIOMODIFICACION
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = lEntidad.AUFECHAMODIFICACION
        args(5) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(5).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Elimina un producto de una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a la que pertenece el producto</param>
    ''' <param name="IDPRODUCTO">Identificador del producto a eliminar</param> 
    ''' <returns>Un entero indicando si se ha eliminado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function eliminarProgramacionProducto(ByVal IDPROGRAMACION As Integer, ByVal IDPRODUCTO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM ")
        strSQL.Append("  SAB_URMIM_PROGRAMACIONPRODUCTO ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDPROGRAMACION = @IDPROGRAMACION AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function


    ''' <summary>
    ''' Elimina todos los producto de una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a la que pertenece el producto</param>
    ''' <param name="IDPRODUCTO">Identificador del producto a eliminar</param> 
    ''' <returns>Un entero indicando si se ha eliminado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function eliminarProgramacionProductoTODOS(ByVal IDPROGRAMACION As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM ")
        strSQL.Append("  SAB_URMIM_PROGRAMACIONPRODUCTO ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDPROGRAMACION = @IDPROGRAMACION  ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function





    ''' <summary>
    ''' Elimina un producto de una programación de un establecimiento específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a la que pertenece el producto</param>
    ''' <param name="IDPRODUCTO">Identificador del producto a eliminar</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertenece el producto a eliminar</param>
    ''' <returns>Un entero indicando si se ha eliminado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function eliminarProgramacionProductoEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDPRODUCTO As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM ")
        strSQL.Append("  SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDPROGRAMACION = @IDPROGRAMACION AND IDPRODUCTO = @IDPRODUCTO AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Verifica si existe o no un producto para una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="IDPRODUCTO">Identificador del producto a consultar</param>
    ''' <returns>Un entero indicando si existe o no el producto en la programación</returns>
    ''' <remarks></remarks>
    Public Function existeProgramacionProducto(ByVal IDPROGRAMACION As Integer, ByVal IDPRODUCTO As Integer) As Integer

        Dim strSQL As New StringBuilder()

        strSQL.Append(" SELECT ")
        strSQL.Append("   ISNULL(PP.IDPRODUCTO, 0) ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONPRODUCTO PP ")
        strSQL.Append(" WHERE PP.IDPRODUCTO = @IDPRODUCTO AND ")
        strSQL.Append("       PP.IDPROGRAMACION = @IDPROGRAMACION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Verifica si existe o no un producto para una programación de un establecimiento específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="IDPRODUCTO">Identificador del producto a consultar</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento a consultar</param>
    ''' <returns>Un entero indicando si existe o no el producto en la programación</returns>
    ''' <remarks></remarks>
    Public Function existeProgramacionProductoEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDPRODUCTO As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder()

        strSQL.Append(" SELECT ")
        strSQL.Append("   ISNULL(PP.IDPRODUCTO, 0) ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO PP ")
        strSQL.Append(" WHERE PP.IDPRODUCTO = @IDPRODUCTO AND ")
        strSQL.Append("       PP.IDPROGRAMACION = @IDPROGRAMACION AND ")
        strSQL.Append("       PP.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el estado de la programación de un establecimiento específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento a consultar</param>
    ''' <returns>Un entero indicando el estado de la programación del establecimiento</returns>
    ''' <remarks></remarks>
    Public Function numeroRegistrosEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New StringBuilder()

        strSQL.Append(" SELECT ")
        strSQL.Append("   ESTADO ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONDETALLE PPE ")
        strSQL.Append(" WHERE PPE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("       PPE.IDPROGRAMACION = @IDPROGRAMACION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function numeroRegistrosEstablecimiento2(ByVal IDPROGRAMACION As Integer) As Integer

        Dim strSQL As New StringBuilder()

        strSQL.Append(" SELECT ")
        strSQL.Append("   max(ESTADO) ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONDETALLE PPE ")
        strSQL.Append(" WHERE  ")
        strSQL.Append("       PPE.IDPROGRAMACION = @IDPROGRAMACION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION


        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Agrega el detalle de la programación para un establecimiento específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a la que se asigna el establecimiento</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento a agregar</param>
    ''' <param name="USUARIO">Usuario que agrega el establecimiento</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function agregarProgramacionRegion(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONDETALLE(IDPROGRAMACION, IDESTABLECIMIENTO, ESTADO, AUUSUARIOCREACION, AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION) ")
        strSQL.Append("  VALUES(@IDPROGRAMACION, @IDESTABLECIMIENTO, 1, @USUARIO, @FECHA, NULL, NULL) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(2).Value = USUARIO
        args(3) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(3).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Agrega el detalle de productos de una programación para un establecimiento específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento a agregar los productos</param>
    ''' <param name="IDTIPOESTABLECIMIENTO">Identificador del tipo al que pertenece Establecimiento</param>
    ''' <param name="USUARIO">Usuario que agrega el detalle de productos</param>
    ''' <param name="eEntidad">Entidad relacionada a los productos de la programación</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se han agregado o no los registros en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function agregarProgramacionProductoRegion(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOESTABLECIMIENTO As Integer, ByVal USUARIO As String, ByVal eEntidad As PROGRAMACION, ByVal tran As DistributedTransaction) As Integer

        Dim M As Integer
        Dim N As Integer

        Dim strSQL As New StringBuilder

        If IDTIPOESTABLECIMIENTO = 10 And eEntidad.IDSUMINISTRO = 1 Then
            strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            strSQL.Append("  SELECT ")
            strSQL.Append("     @IDPROGRAMACION, IDPRODUCTO, @IDESTABLECIMIENTO, COMPRATRANSITO, EXISTENCIAALMACEN, ")
            strSQL.Append("     EXISTENCIAREGION, CPM, CPM, CANTIDADCOMPRAR, CANTIDADCOMPRAR, COBERTURA, CTOTAL, 0, 0, @USUARIO, getDate(), NULL, NULL ")
            strSQL.Append("  FROM ")
            strSQL.Append("    dbo.fn_DetalleProgramacion(@IDPROGRAMACION, @IDESTABLECIMIENTO, @M, @N, @FINI, @FFIN) ")
            strSQL.Append("WHERE ")
            strSQL.Append("  NIVELUSO IN (1,2,4) ")

        ElseIf eEntidad.IDSUMINISTRO = 1 Then

            'strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            'strSQL.Append("  SELECT ")
            'strSQL.Append("     @IDPROGRAMACION, IDPRODUCTO, @IDESTABLECIMIENTO, 0, 0, ")
            'strSQL.Append("     0, 0, 0, 0, 0, 0, 0, 0, 0, @USUARIO, getDate(), NULL, NULL ")
            'strSQL.Append("  FROM ")
            'strSQL.Append("    SAB_URMIM_PROGRAMACIONPRODUCTO PP ")
            'strSQL.Append("WHERE ")
            'strSQL.Append("  PP.IDPROGRAMACION = @IDPROGRAMACION ")

            strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            strSQL.Append("  SELECT ")
            strSQL.Append("     @IDPROGRAMACION, IDPRODUCTO, @IDESTABLECIMIENTO, COMPRATRANSITO, EXISTENCIAALMACEN, ")
            strSQL.Append("     EXISTENCIAESTABLECIMIENTO, CPM, CPM, CANTIDADCOMPRAR, CANTIDADCOMPRAR, COBERTURA, CTOTAL, 0, 0, @USUARIO, getDate(), NULL, NULL ")
            strSQL.Append("  FROM ")
            strSQL.Append("    dbo.fn_DetalleProgramacionEstablecimiento(@IDPROGRAMACION, @IDESTABLECIMIENTO, @M, @N, @FINI, @FFIN) ")

        Else
            strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            strSQL.Append("  SELECT ")
            strSQL.Append("     @IDPROGRAMACION, IDPRODUCTO, @IDESTABLECIMIENTO, 0, 0, ")
            strSQL.Append("     0, 0, 0, 0, 0, 0, 0, 0, 0, @USUARIO, getDate(), NULL, NULL ")
            strSQL.Append("  FROM ")
            strSQL.Append("    SAB_URMIM_PROGRAMACIONPRODUCTO PP ")
            strSQL.Append("WHERE ")
            strSQL.Append("  PP.IDPROGRAMACION = @IDPROGRAMACION ")
        End If

        Dim m1 As Integer = DateDiff(DateInterval.Month, eEntidad.FECHAPROGRAMACION, eEntidad.FECHAPROYECCION) + 1
        If m1 < 0 Then m1 = 0

        M = m1
        N = eEntidad.MESESPLANEACION

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(2).Value = USUARIO
        args(3) = New SqlParameter("@FINI", SqlDbType.DateTime)
        args(3).Value = DateAdd(DateInterval.Month, eEntidad.MESESCPM * (-1), eEntidad.FECHACORTE)
        args(4) = New SqlParameter("@FFIN", SqlDbType.DateTime)
        args(4).Value = eEntidad.FECHACORTE
        args(5) = New SqlParameter("@M", SqlDbType.Int)
        args(5).Value = M
        args(6) = New SqlParameter("@N", SqlDbType.Int)
        args(6).Value = N

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function agregarProgramacionProductoRegion2(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOESTABLECIMIENTO As Integer, ByVal USUARIO As String, ByVal eEntidad As PROGRAMACION, ByVal tran As DistributedTransaction) As Integer

        Dim M As Integer
        Dim N As Integer

        Dim strSQL As New StringBuilder

        If IDTIPOESTABLECIMIENTO = 10 And eEntidad.IDSUMINISTRO = 1 Then
            strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            strSQL.Append("  SELECT ")
            strSQL.Append("     @IDPROGRAMACION, IDPRODUCTO, @IDESTABLECIMIENTO, COMPRATRANSITO, EXISTENCIAALMACEN, ")
            strSQL.Append("     EXISTENCIAREGION, CPM, CPM, CANTIDADCOMPRAR, CANTIDADCOMPRAR, 0, CTOTAL, 0, 0, @USUARIO, getDate(), NULL, NULL ")
            strSQL.Append("  FROM ")
            strSQL.Append("    dbo.fn_DetalleProgramacion2(@IDPROGRAMACION, @IDESTABLECIMIENTO, @M, @N, @FINI, @FFIN) ")
            strSQL.Append("WHERE ")
            strSQL.Append("  NIVELUSO IN (1,2,4) ")

        ElseIf eEntidad.IDSUMINISTRO = 1 Then

            'strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            'strSQL.Append("  SELECT ")
            'strSQL.Append("     @IDPROGRAMACION, IDPRODUCTO, @IDESTABLECIMIENTO, 0, 0, ")
            'strSQL.Append("     0, 0, 0, 0, 0, 0, 0, 0, 0, @USUARIO, getDate(), NULL, NULL ")
            'strSQL.Append("  FROM ")
            'strSQL.Append("    SAB_URMIM_PROGRAMACIONPRODUCTO PP ")
            'strSQL.Append("WHERE ")
            'strSQL.Append("  PP.IDPROGRAMACION = @IDPROGRAMACION ")

            strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            strSQL.Append("  SELECT ")
            strSQL.Append("     @IDPROGRAMACION, IDPRODUCTO, @IDESTABLECIMIENTO, COMPRATRANSITO, EXISTENCIAALMACEN, ")
            strSQL.Append("     EXISTENCIAESTABLECIMIENTO, CPM, CPM, CANTIDADCOMPRAR, CANTIDADCOMPRAR, COBERTURA, CTOTAL, 0, 0, @USUARIO, getDate(), NULL, NULL ")
            strSQL.Append("  FROM ")
            strSQL.Append("    dbo.fn_DetalleProgramacionEstablecimiento(@IDPROGRAMACION, @IDESTABLECIMIENTO, @M, @N, @FINI, @FFIN) ")

        Else
            strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            strSQL.Append("  SELECT ")
            strSQL.Append("     @IDPROGRAMACION, IDPRODUCTO, @IDESTABLECIMIENTO, 0, 0, ")
            strSQL.Append("     0, 0, 0, 0, 0, 0, 0, 0, 0, @USUARIO, getDate(), NULL, NULL ")
            strSQL.Append("  FROM ")
            strSQL.Append("    SAB_URMIM_PROGRAMACIONPRODUCTO PP ")
            strSQL.Append("WHERE ")
            strSQL.Append("  PP.IDPROGRAMACION = @IDPROGRAMACION ")
        End If

        Dim m1 As Integer = DateDiff(DateInterval.Month, eEntidad.FECHAPROGRAMACION, eEntidad.FECHAPROYECCION) + 1
        If m1 < 0 Then m1 = 0

        M = m1
        N = eEntidad.MESESPLANEACION

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(2).Value = USUARIO
        args(3) = New SqlParameter("@FINI", SqlDbType.DateTime)
        args(3).Value = DateAdd(DateInterval.Month, eEntidad.MESESCPM * (-1), eEntidad.FECHACORTE)
        args(4) = New SqlParameter("@FFIN", SqlDbType.DateTime)
        args(4).Value = eEntidad.FECHACORTE
        args(5) = New SqlParameter("@M", SqlDbType.Int)
        args(5).Value = M
        args(6) = New SqlParameter("@N", SqlDbType.Int)
        args(6).Value = N

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ajustarCobertura(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal tran As DistributedTransaction, Optional ByVal IDPRODUCTO As Integer = 0) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" with s as( ")
        strSQL.Append(" 	select ")
        strSQL.Append(" 	  l.idproducto, datediff(month, getdate(), max(l.fechavencimiento)) as diferencia ")
        strSQL.Append(" 	from ")
        strSQL.Append(" 	  sab_alm_lotes l ")
        strSQL.Append(" 		inner join sab_cat_almacenesestablecimientos ae on ")
        strSQL.Append(" 		  l.idalmacen = ae.idalmacen ")
        strSQL.Append(" 		inner join vv_catalogoproductos cp on ")
        strSQL.Append(" 		  l.idproducto = cp.idproducto ")
        strSQL.Append(" 	where ")
        strSQL.Append(" 	  ae.idEstablecimiento = @IDESTABLECIMIENTO and ")
        strSQL.Append(" 	  l.fechavencimiento > getDate() and ")
        strSQL.Append(" 	  cp.idsuministro = 1 and ")
        strSQL.Append(" 	  (l.idProducto = @IDPRODUCTO or @IDPRODUCTO = 0) ")
        strSQL.Append(" 	group by ")
        strSQL.Append(" 	  l.idproducto ")
        strSQL.Append(" ) ")
        strSQL.Append("  ")
        strSQL.Append(" update ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
        strSQL.Append(" set ")
        strSQL.Append("   cobertura = s.diferencia ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ppe ")
        strSQL.Append("     inner join s on ")
        strSQL.Append("       ppe.idproducto = s.idproducto ")
        strSQL.Append(" where ")
        strSQL.Append("   ppe.idprogramacion = @IDPROGRAMACION and  ")
        strSQL.Append("   ppe.idestablecimiento = @IDESTABLECIMIENTO and ")
        strSQL.Append("   ppe.cobertura > s.diferencia ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function


    ''' <summary>
    ''' Agrega el detalle de productos sin filtro de una programación para un establecimiento específico
    ''' </summary>
    ''' <param name="eEntidad">Entidad relacionada a los productos de la programación</param>
    ''' <param name="IDTIPOESTABLECIMIENTO">Identificador del tipo al que pertenece Establecimiento</param>
    ''' <returns>Un entero indicando si se han agregado o no los registros en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function agregarProgramacionProductoEstablecimiento(ByVal eEntidad As PROGRAMACIONPRODUCTO, ByVal IDTIPOESTABLECIMIENTO As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim M As Integer
        Dim N As Integer

        Dim strSQL As New StringBuilder

        If IDTIPOESTABLECIMIENTO = 10 And eEntidad.IDSUMINISTRO = 1 Then
            strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            strSQL.Append("  SELECT ")
            strSQL.Append("     @IDPROGRAMACION, IDPRODUCTO, @IDESTABLECIMIENTO, COMPRATRANSITO, EXISTENCIAALMACEN, ")
            strSQL.Append("     EXISTENCIAREGION, CPM, CPM, CANTIDADCOMPRAR, CANTIDADCOMPRAR, COBERTURA, CTOTAL, 0, 0, @USUARIO, @FMOD, NULL, NULL ")
            strSQL.Append("  FROM ")
            strSQL.Append("    dbo.fn_DetalleProgramacionSinFiltro(@IDPROGRAMACION, @IDESTABLECIMIENTO, @M, @N, @FINI, @FFIN) ")
            strSQL.Append("WHERE ")
            strSQL.Append("  IDPRODUCTO = @IDPRODUCTO ")
        ElseIf eEntidad.IDSUMINISTRO = 1 Then
            strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            strSQL.Append("  SELECT ")
            strSQL.Append("     @IDPROGRAMACION, IDPRODUCTO, @IDESTABLECIMIENTO, COMPRATRANSITO, EXISTENCIAALMACEN, ")
            strSQL.Append("     EXISTENCIAESTABLECIMIENTO, CPM, CPM, CANTIDADCOMPRAR, CANTIDADCOMPRAR, COBERTURA, CTOTAL, 0, 0, @USUARIO, @FMOD, NULL, NULL ")
            strSQL.Append("  FROM ")
            strSQL.Append("    dbo.fn_DetalleProgramacionEstablecimientoSinFiltro(@IDPROGRAMACION, @IDESTABLECIMIENTO, @M, @N, @FINI, @FFIN) ")
            strSQL.Append("WHERE ")
            strSQL.Append("  IDPRODUCTO = @IDPRODUCTO ")
            'strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            'strSQL.Append("([IDPROGRAMACION],[IDPRODUCTO],[IDESTABLECIMIENTO],[COMPRATRANSITO],[CANTIDADALMACEN],[CANTIDADREGION],[CONSUMOPROMEDIO],[CONSUMOPROMEDIOAJUSTADO]")
            'strSQL.Append(",[CANTIDADCOMPRAR],[CANTIDADCOMPRARAJUSTADA],[COBERTURA],[CONSUMOTOTAL],[DIASDESABASTECIDOS],[DEMANDAINSATISFECHA],[AUUSUARIOCREACION],[AUFECHACREACION],[AUUSUARIOMODIFICACION]")
            'strSQL.Append(",[AUFECHAMODIFICACION])")
            'strSQL.Append(" VALUES( ")
            'strSQL.Append("     @IDPROGRAMACION, @IDPRODUCTO, @IDESTABLECIMIENTO, 0, 0, ")
            'strSQL.Append("     0, 0, 0, 0, 0, 0, 0, 0, 0, @USUARIO, @FMOD, NULL, NULL) ")
            ''strSQL.Append("  FROM ")
            ''strSQL.Append("    SAB_URMIM_PROGRAMACIONPRODUCTO PP ")
            ''strSQL.Append("WHERE ")
            ''strSQL.Append("  PP.IDPROGRAMACION = @IDPROGRAMACION ")
        Else

            strSQL.Append(" insert into dbo.SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
            strSQL.Append(" values(@IDPROGRAMACION, @IDPRODUCTO, @IDESTABLECIMIENTO, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, @USUARIO, @FMOD, null, null) ")

        End If

        Dim m1 As Integer = DateDiff(DateInterval.Month, eEntidad.FECHACORTE, eEntidad.FECHAPROYECCION)
        If m1 < 0 Then m1 = 0

        M = m1
        N = eEntidad.MESESPLANEACION

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = eEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(2).Value = eEntidad.AUUSUARIOCREACION
        args(3) = New SqlParameter("@FINI", SqlDbType.DateTime)
        args(3).Value = DateAdd(DateInterval.Month, eEntidad.MESESCPM * (-1), eEntidad.FECHAPROGRAMACION)
        args(4) = New SqlParameter("@FFIN", SqlDbType.DateTime)
        args(4).Value = eEntidad.FECHAPROGRAMACION
        args(5) = New SqlParameter("@M", SqlDbType.Int)
        args(5).Value = M
        args(6) = New SqlParameter("@N", SqlDbType.Int)
        args(6).Value = N
        args(7) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(7).Value = eEntidad.IDPRODUCTO
        args(8) = New SqlParameter("@FMOD", SqlDbType.DateTime)
        args(8).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene la información de un producto para una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="CODIGO">Código de producto a consultar</param>
    ''' <param name="IDTIPOESTABLECIMIENTO">Identificador del tipo al que pertenece Establecimiento</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro al que pertenece el producto</param>
    ''' <returns>Información del producto en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerCodigoProductoProgramacion(ByVal IDPROGRAMACION As Integer, ByVal CODIGO As String, ByVal IDTIPOESTABLECIMIENTO As Integer, Optional ByVal IDSUMINISTRO As Integer = 1) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   vvCP.idProducto, vvCP.idUnidadMedida, vvCP.desclargo ")
        strSQL.Append(" from ")
        strSQL.Append("   VV_CATALOGOPRODUCTOS vvCP ")
        strSQL.Append("     inner join dbo.SAB_URMIM_PROGRAMACIONPRODUCTO pp ")
        strSQL.Append("       ON vvCP.idProducto = pp.idProducto and ")
        strSQL.Append("          pp.idProgramacion = @IDPROGRAMACION ")
        strSQL.Append(" where ")
        strSQL.Append("   vvCP.idSuministro = @IDSUMINISTRO AND ")
        strSQL.Append("   vvCP.corrproducto = @CODIGO ")

        If IDTIPOESTABLECIMIENTO = 10 And IDSUMINISTRO = 1 Then
            strSQL.Append("   AND vvCP.idNivelUso in (1,2,4) ")
        End If

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(1).Value = CODIGO
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(2).Value = IDSUMINISTRO

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function VerificarProgramacionProductoEstablecimiento(ByVal IDPROGRAMACION As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" select count(*) ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ")
        strSQL.Append(" where ")
        strSQL.Append("   IDPROGRAMACION =" & IDPROGRAMACION)

        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerEstablecimientosProgramacion(ByVal IDPROGRAMACION As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select idestablecimiento ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONDETALLE ")
        strSQL.Append(" where ")
        strSQL.Append("   IDPROGRAMACION =" & IDPROGRAMACION)

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Actualiza el estado y presupuesto ajustado/real de una programación para un establecimiento específico
    ''' </summary>
    ''' <param name="eEntidad">Entidad relacionada a la programación del establecimiento</param>
    ''' <param name="b">Identifica si se actualizará el presupuesto asignado</param>
    ''' <param name="c">Identifica si se actualizará el presupuesto real</param>
    ''' <returns>Un entero indicando si se han actualizado o no los registros en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarEstadoProgramacion(ByVal eEntidad As PROGRAMACIONPRODUCTO, Optional ByVal b As Boolean = False, Optional ByVal c As Boolean = False) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONDETALLE SET ")
        strSQL.Append("     ESTADO = @ESTADO, ")

        If b Then
            If c Then
                strSQL.Append("     PRESUPUESTOAJUSTADO = @PRESUPUESTOREAL, ")
            Else
                strSQL.Append("     PRESUPUESTOREAL = @PRESUPUESTOREAL, ")
            End If
        End If

        strSQL.Append("     AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append(" WHERE IDPROGRAMACION = @IDPROGRAMACION AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = eEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(2).Value = eEntidad.ESTADO
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = eEntidad.AUUSUARIOMODIFICACION
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = eEntidad.AUFECHAMODIFICACION
        args(5) = New SqlParameter("@PRESUPUESTOREAL", SqlDbType.Decimal)
        args(5).Value = eEntidad.PRESUPUESTOREAL

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el detalle consolidado de desabastecimiento de una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="M">Meses de cobertura a tomar en cuenta para el cálculo</param>
    ''' <param name="IDPROGRAMA">Identificador del programa a consultar</param>
    ''' <returns>Lista de detalle consolidado de desabastecimiento en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDesabastecimientoConsolidado(ByVal IDPROGRAMACION As Integer, ByVal M As Integer, Optional ByVal IDPROGRAMA As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" with s as( ")
        strSQL.Append("   select ")
        strSQL.Append("     e.nombre, cp.corrproducto, cp.desclargo, cp.descripcion, ")
        strSQL.Append(" 	  cp.cobertura, cp.consumopromedioajustado, cp.idprogramacion, cp.idproducto, ")
        strSQL.Append(" 	  case ")
        strSQL.Append(" 	    when @M < 3 then 0 ")
        strSQL.Append(" 	    when cp.cobertura < 3 then ((@M-3)*cp.consumopromedioajustado) ")
        strSQL.Append(" 		else ((@M-cp.cobertura)*cp.consumopromedioajustado) ")
        strSQL.Append(" 	  end as cantidadComprar ")
        strSQL.Append("   from ")
        strSQL.Append("     sab_cat_establecimientos e  ")
        strSQL.Append(" 	    inner join fn_ConsultaProgramacion(@IDPROGRAMACION, 0) cp ")
        strSQL.Append(" 		    on e.idEstablecimiento = cp.idEstablecimiento and ")
        strSQL.Append(" 			     cp.cobertura < @M ")

        If IDPROGRAMA <> 0 Then
            strSQL.Append(" 	    inner join sab_cat_productosprogramas ppg ")
            strSQL.Append(" 		    on cp.idProducto = ppg.idProducto and ppg.idPrograma = @IDPROGRAMA ")
        End If

        strSQL.Append(" ) ")
        strSQL.Append("  ")
        strSQL.Append(" select ")
        strSQL.Append("   s.corrproducto, s.desclargo, (sum(s.cantidadcomprar)) as cantidadcomprarajustada, ")
        strSQL.Append("   s.descripcion, (pp.precio * (1+(p.indiceinflacion/100))) as precio, isnull(vea.CANTIDADDISPONIBLE,0) as cantidadalmacen")
        'strSQL.Append("   , isnull(t.CANTIDAD,0) as cantidadregion ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_urmim_programacion p ")
        strSQL.Append(" 	  inner join s ")
        strSQL.Append(" 		  on p.idprogramacion = s.idprogramacion ")
        strSQL.Append(" 	  inner join sab_urmim_programacionproducto	pp ")
        strSQL.Append(" 		  on p.idprogramacion = pp.idprogramacion and ")
        strSQL.Append(" 			   s.idproducto = pp.idproducto ")
        strSQL.Append(" 	  left outer join vv_EXISTENCIASALMACENES vea ")
        strSQL.Append(" 	 	  on pp.idproducto = vea.idproducto and ")
        strSQL.Append(" 	 		 vea.idalmacen = 42 ")
        'strSQL.Append(" 	  left outer join temp2 t ")
        'strSQL.Append(" 	 	  on pp.idproducto = t.idproducto ")
        strSQL.Append(" group by ")
        strSQL.Append("   s.corrproducto, s.desclargo, s.descripcion, pp.precio, p.indiceinflacion, vea.CANTIDADDISPONIBLE") ', t.CANTIDAD ")
        strSQL.Append(" having ")
        strSQL.Append("   SUM(s.cantidadcomprar) > 0 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@M", SqlDbType.Int)
        args(1).Value = M
        args(2) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(2).Value = IDPROGRAMA

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene las entregas para los productos de una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <returns>Lista de entregas en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDetalleEntregaProductos(ByVal IDPROGRAMACION As Integer) As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" SELECT ")
        strSQL.Append("   PED.RENGLON, CP.CORRPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION, ")
        ' strSQL.Append("   PED.ENTREGA, CONVERT(INTEGER, SUM(CANTIDADCOMPRARAJUSTADA)) as CANTIDAD, ")
        strSQL.Append("   PED.ENTREGA, (SUM(CANTIDADCOMPRARAJUSTADA)) as CANTIDAD, ")
        strSQL.Append("   PED.IDPROGRAMACION, PED.IDPRODUCTO, PED.OBSERVACION ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONENTREGADETALLE PED ")
        strSQL.Append("     INNER JOIN VV_CATALOGOPRODUCTOS CP ON ")
        strSQL.Append("       PED.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("     INNER JOIN SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO PPE ON ")
        strSQL.Append("       PED.IDPROGRAMACION = PPE.IDPROGRAMACION AND ")
        strSQL.Append("       PED.IDPRODUCTO = PPE.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   PED.IDPROGRAMACION = @IDPROGRAMACION ")
        strSQL.Append(" GROUP BY ")
        strSQL.Append("   PED.RENGLON, CP.CORRPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION, PED.ENTREGA, PED.IDPROGRAMACION, PED.IDPRODUCTO, PED.OBSERVACION ")
        strSQL.Append(" ORDER BY RENGLON ASC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el detalle de entregas con filtro para los productos de una programación específica 
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="TIPO">Tipo de consulta a realizar</param>
    ''' <param name="alternativas">Lista de alternativas de productos</param>
    ''' <returns>Lista de detalle de entregas para los productos en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDistribucionProgramacion(ByVal IDPROGRAMACION As Integer, ByVal TIPO As Integer, Optional ByVal alternativas As String = "") As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" ")
        strSQL.Append("  select ")
        strSQL.Append("    e.nombre as establecimiento, cp.corrproducto, cp.desclargo, cp.descripcion, cp1.codigonacionesunidas, ")
        strSQL.Append("    cp.cantidadcomprarajustada as cantidadcomprarajustada, cp.precio, ")
        strSQL.Append("    (cp.precio*cp.cantidadcomprarajustada) as montototalajustado, ")
        strSQL.Append("    s.entrega, s.observacion, s.idProducto, ")
        strSQL.Append("    (select count(idAlternativa) from dbo.SAB_CAT_ALTERNATIVASPRODUCTO where idAlternativa = cp.idProducto) ")
        strSQL.Append("  from ")
        strSQL.Append("    fn_ConsultaProgramacion(@IDPROGRAMACION, 0) cp ")
        strSQL.Append("      inner join SAB_CAT_ESTABLECIMIENTOS e on ")
        strSQL.Append("        cp.idEstablecimiento = e.idEstablecimiento ")
        strSQL.Append("      inner join vv_CATALOGOPRODUCTOS cp1 on ")
        strSQL.Append("        cp.corrproducto = cp1.corrproducto ")
        strSQL.Append("      inner join SAB_URMIM_PROGRAMACIONENTREGADETALLE s on ")
        strSQL.Append("        cp.idProducto = s.idProducto and ")
        strSQL.Append("        cp.idProgramacion = s.idProgramacion ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   cp.cantidadcomprarajustada > 0  ")

        If TIPO = 0 Then
            strSQL.Append(" and cp.precio > 0 and s.entrega > 0 ")
        ElseIf TIPO = 1 Then
            strSQL.Append(" and ped.entrega = 0 ")
        ElseIf alternativas = "()" Then 'Alternativas
            strSQL.Append(" and cp.precio = 0 and s.entrega > 0 ")
        Else
            strSQL.Append(" and cp.precio = 0 and s.entrega > 0 and s.idProducto in " & alternativas)
        End If

        strSQL.Append(" ORDER BY ")
        strSQL.Append("   cp.corrproducto, e.nombre ASC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el detalle de entregas para los productos de una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <param name="TIPO">Tipo de consulta a realizar</param>
    ''' <returns>Lista de detalle de entregas para los productos en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDistribucionProgramacion2(ByVal IDPROGRAMACION As Integer, ByVal TIPO As Integer) As DataSet

        Dim strSQL As New StringBuilder()

        strSQL.Append(" with s as( ")
        strSQL.Append(" 	 select ")
        strSQL.Append(" 	   row_number() over(order by cp.corrproducto) as linea, ped.idProducto, ped.entrega, ped.observacion ")
        strSQL.Append(" 	 from ")
        strSQL.Append(" 		SAB_URMIM_PROGRAMACIONENTREGADETALLE ped ")
        strSQL.Append(" 		  inner join vv_CATALOGOPRODUCTOS cp on ")
        strSQL.Append(" 		   ped.idProducto = cp.idProducto ")
        strSQL.Append(" 	 where ")
        strSQL.Append(" 	   ped.idProgramacion = @IDPROGRAMACION and ")

        If TIPO = 0 Then
            strSQL.Append("   ped.entrega > 0 ")
        Else
            strSQL.Append("   ped.entrega = 0 ")
        End If

        strSQL.Append(" ) ")
        strSQL.Append(" ")
        strSQL.Append("  select ")
        strSQL.Append("    s.linea, e.nombre as establecimiento, cp.corrproducto, cp.desclargo, cp.descripcion, cp1.codigonacionesunidas, ")
        strSQL.Append("    cp.cantidadcomprarajustada as cantidadcomprarajustada, cp.precio, ")
        strSQL.Append("    (cp.precio*cp.cantidadcomprarajustada) as montototalajustado, ")
        strSQL.Append("    s.entrega, s.observacion ")
        strSQL.Append("  from ")
        strSQL.Append("    fn_ConsultaProgramacion(@IDPROGRAMACION, 0) cp ")
        strSQL.Append("      inner join SAB_CAT_ESTABLECIMIENTOS e on ")
        strSQL.Append("        cp.idEstablecimiento = e.idEstablecimiento ")
        strSQL.Append("      inner join vv_CATALOGOPRODUCTOS cp1 on ")
        strSQL.Append("        cp.corrproducto = cp1.corrproducto ")
        strSQL.Append("      inner join s on ")
        strSQL.Append("        cp.idProducto = s.idProducto ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   cp.cantidadcomprarajustada > 0 ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("   cp.corrproducto, e.nombre ASC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene un listado de las alternativas para un producto específico
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto del que se desean conocer sus alternativas</param>
    ''' <returns>Lista de alternativas para el producto en forma de cadena de caracteres</returns>
    ''' <remarks></remarks>
    Public Function obtenerAlternativasProgramacion(ByVal IDPRODUCTO) As String

        Dim strSQL As New StringBuilder()
        Dim t As String
        Dim i As Integer = 0

        strSQL.Append(" SELECT ")
        strSQL.Append("   idProducto ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_CAT_ALTERNATIVASPRODUCTO ")
        strSQL.Append(" where ")
        strSQL.Append("   idalternativa = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

        t = "("

        Do While dr.Read

            If i <> 0 Then
                t = t & ", " & dr.Item(0)
            Else
                t = t & dr.Item(0)
                i += 1
            End If

        Loop

        t = t & ")"

        dr.Close()

        Return t

    End Function

    ''' <summary>
    ''' Actualiza el detalle de una programación para un establecimiento específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identidicador de la programación</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del que se desea actualizar el estado</param>
    ''' <param name="ESTADO">Nuevo estado del detalle de la programación</param>
    ''' <param name="USUARIO">Usuario que actualiza el estado</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarEstadoProgramacion(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal ESTADO As Integer, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONDETALLE SET ")
        strSQL.Append("     ESTADO = @ESTADO, ")
        strSQL.Append("     AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append(" WHERE IDPROGRAMACION = @IDPROGRAMACION AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(2).Value = ESTADO
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = USUARIO
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = Now

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function actualizarEstadoProgramacion2(ByVal IDPROGRAMACION As Integer, ByVal ESTADO As Integer, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONDETALLE SET ")
        strSQL.Append("     ESTADO = @ESTADO, ")
        strSQL.Append("     AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append(" WHERE IDPROGRAMACION = @IDPROGRAMACION  ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(2) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(2).Value = ESTADO
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = USUARIO
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = Now

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function actualizarMontoProgramacion(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal PRESUPUESTOASIGNADO As Decimal, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONDETALLE SET ")
        strSQL.Append("     PRESUPUESTOASIGNADO = @PRESUPUESTOASIGNADO, ")
        strSQL.Append("     AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append(" WHERE IDPROGRAMACION = @IDPROGRAMACION AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@PRESUPUESTOASIGNADO", SqlDbType.Decimal)
        args(2).Value = PRESUPUESTOASIGNADO
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = USUARIO
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = Now

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerTechoProgramacion(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Decimal

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT PRESUPUESTOASIGNADO FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONDETALLE ")
        strSQL.Append(" WHERE IDPROGRAMACION = @IDPROGRAMACION AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerMontoAjustado(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Decimal

        Dim strSQL As New StringBuilder()

        strSQL.Append(" select sum(montototalajustado) from fn_ConsultaProgramacion(@IDPROGRAMACION, @IDESTABLECIMIENTO)  ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Agrega un producto a una programación específica
    ''' </summary>
    ''' <param name="aEntidad">Entidad relacionada al producto de la programación</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function agregarProgramacionProductoAlternativa(ByVal aEntidad As PROGRAMACIONPRODUCTO) As Integer

        Dim lEntidad As PROGRAMACIONPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append(" INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTO(IDPROGRAMACION, IDPRODUCTO, PRECIO, AUUSUARIOCREACION, AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION) ")
        strSQL.Append(" SELECT DISTINCT @IDPROGRAMACION, IDALTERNATIVA, 0, @AUUSUARIOCREACION, @AUFECHACREACION, NULL, NULL ")
        strSQL.Append("  FROM   SAB_CAT_ALTERNATIVASPRODUCTO WHERE IDALTERNATIVA NOT IN ( ")
        strSQL.Append("  SELECT DISTINCT IDPRODUCTO FROM DBO.SAB_URMIM_PROGRAMACIONPRODUCTO WHERE IDPROGRAMACION = @IDPROGRAMACION)and  ")
        strSQL.Append("  idproducto  IN (SELECT DISTINCT IDPRODUCTO FROM DBO.SAB_URMIM_PROGRAMACIONPRODUCTO WHERE IDPROGRAMACION = @IDPROGRAMACION)  ")


        'Trabajamos los datos de la programacion. Esto se hace solo copiando y pegando al mismo tiempo que se sustituye la cantidadcomprarajustada */
        strSQL.Append(" INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO  ")
        strSQL.Append(" SELECT PPE.IDPROGRAMACION,A.IDPRODUCTO,PPE.IDESTABLECIMIENTO,0,0,0,  ")
        strSQL.Append(" 0,0,CEILING(PPE.CANTIDADCOMPRAR*A.DIVISOR/A.MULTIPLICADOR),CEILING(PPE.CANTIDADCOMPRARAJUSTADA*A.DIVISOR/A.MULTIPLICADOR),PPE.COBERTURA, ")
        strSQL.Append(" 0,0,0,@AUUSUARIOCREACION,getDate(),null,null ")
        strSQL.Append(" FROM SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO PPE ")
        strSQL.Append(" INNER JOIN SAB_CAT_ALTERNATIVASPRODUCTO A ON ")
        strSQL.Append(" PPE.IDPRODUCTO = A.IDALTERNATIVA AND ")
        strSQL.Append(" PPE.IDPROGRAMACION = @IDPROGRAMACION ")




        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(1).Value = lEntidad.AUUSUARIOCREACION
        args(2) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(2).Value = lEntidad.AUFECHACREACION

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

End Class
