Partial Public Class dbCATALOGOPRODUCTOS

#Region " METODOS AGREGADOS"

    ''' <summary>
    ''' Obtiene un producto en base a su Id
    ''' </summary>
    ''' <param name="IDPRODUCTO">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function ObtenerDataSetPorIDProducto(ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT C.IDPRODUCTO, ")
        strSQL.Append(" C.CODIGO, ")
        strSQL.Append(" C.IDTIPOPRODUCTO, ")
        strSQL.Append(" C.IDUNIDADMEDIDA, ")
        strSQL.Append(" C.NOMBRE, ")
        strSQL.Append(" C.NIVELUSO, ")
        strSQL.Append(" C.CONCENTRACION, ")
        strSQL.Append(" C.FORMAFARMACEUTICA, ")
        strSQL.Append(" C.PRESENTACION, ")
        strSQL.Append(" C.PRIORIDAD, ")
        strSQL.Append(" C.PRECIOACTUAL, ")
        strSQL.Append(" C.EXISTENCIAACTUAL, ")
        strSQL.Append(" C.PERTENECELISTADOOFICIAL, ")
        strSQL.Append(" C.ESTADOPRODUCTO, ")
        strSQL.Append(" C.OBSERVACION, ")
        strSQL.Append(" C.AUUSUARIOCREACION, ")
        strSQL.Append(" C.AUFECHACREACION, ")
        strSQL.Append(" C.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" C.AUFECHAMODIFICACION, ")
        strSQL.Append(" C.ESTASINCRONIZADA, ")
        strSQL.Append(" C.NOMBRE + ' ' + C.CONCENTRACION + ' ' + C.FORMAFARMACEUTICA +  ' ' + C.PRESENTACION AS DESCLARGO, substring(codigo,1,5) as cod, substring(codigo,6,8) as cod2, C.CODIGONACIONESUNIDAS, C.APLICALOTE ")
        strSQL.Append(" FROM SAB_CAT_CATALOGOPRODUCTOS C INNER JOIN SAB_CAT_UNIDADMEDIDAS U ON C.IDUNIDADMEDIDA = U.IDUNIDADMEDIDA ")
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener la informacion de un producto
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param>
    ''' <returns>Dataset</returns>

    Public Function ObtenerDataSetPorCodigoProducto(ByVal IDPRODUCTO As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTablaII(strSQL)
        strSQL.Append(" WHERE CODIGO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.VarChar)
        args(0).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener la informacion de todo el catalogo de productos
    ''' </summary>
    ''' <returns>Dataset</returns>

    Public Function ObtenerCatalogoProductos() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_CAT_SUMINISTROS.IDSUMINISTRO, SAB_CAT_SUMINISTROS.CORRELATIVO AS CORRSUMINISTRO, ")
        strSQL.Append(" SAB_CAT_SUMINISTROS.DESCRIPCION AS DESCSUMINISTRO, SAB_CAT_GRUPOS.IDGRUPO, SAB_CAT_GRUPOS.CORRELATIVO AS CORRGRUPO, ")
        strSQL.Append(" SAB_CAT_GRUPOS.DESCRIPCION AS DESCGRUPO, SAB_CAT_SUBGRUPOS.IDSUBGRUPO, SAB_CAT_SUBGRUPOS.CORRELATIVO AS CORRSUBGRUPO, ")
        strSQL.Append(" SAB_CAT_SUBGRUPOS.DESCRIPCION AS DESCSUBGRUPO, SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO, ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS.CODIGO AS CORRPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE AS DESCPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.PRECIOACTUAL ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTROS INNER JOIN SAB_CAT_GRUPOS ON SAB_CAT_SUMINISTROS.IDSUMINISTRO = SAB_CAT_GRUPOS.IDSUMINISTRO INNER JOIN ")
        strSQL.Append(" SAB_CAT_SUBGRUPOS ON SAB_CAT_GRUPOS.IDGRUPO = SAB_CAT_SUBGRUPOS.IDGRUPO INNER JOIN SAB_CAT_CATALOGOPRODUCTOS ON SAB_CAT_SUBGRUPOS.IDSUBGRUPO = ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS.IDTIPOPRODUCTO")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene un listado de productos completo.
    ''' </summary>
    ''' <param name="CRITERIO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="TIPO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="CERO">Especifica si el listado incluye los productos con precio mayor que cero.</param>
    ''' <returns>Dataset con el listado de productos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  09/12/2006    Creado
    ''' </history> 
    Public Function FiltrarCatalogoProductos(ByVal CRITERIO As String, ByVal TIPO As Int16, ByVal CERO As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT * from vv_CATALOGOPRODUCTOS ")

        Select Case TIPO
            Case Is = 1
                strSQL.Append(" WHERE IDSUMINISTRO = " & Val(CRITERIO))

            Case Is = 2
                strSQL.Append(" WHERE IDGRUPO = " & Val(CRITERIO))

            Case Is = 3
                strSQL.Append(" WHERE IDSUBGRUPO = " & Val(CRITERIO))

            Case Is = 4
                strSQL.Append(" WHERE CORRPRODUCTO = '" & CRITERIO & "'")

        End Select
        If CERO = 1 And TIPO > 0 Then
            strSQL.Append(" AND PRECIOACTUAL = 0")
        ElseIf CERO = 1 Then
            strSQL.Append(" WHERE PRECIOACTUAL = 0")
        End If

        strSQL.Append(" ORDER BY CORRPRODUCTO")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene informacion de catalogo de productos de la vista vv_CATALOGOPRODUCTOS
    ''' </summary>
    ''' <returns>
    ''' Dataset con toda la informacion de la vista
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompleto() As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Seleccionar la informacion del catalogo de productos
    ''' </summary>
    ''' <param name="strSQL">Consulta a realizar en la tabla de productos</param>

    Private Sub SelectTablaII(ByRef strSQL As Text.StringBuilder)

        strSQL.Append(" SELECT IDPRODUCTO, ")
        strSQL.Append(" CODIGO, ")
        strSQL.Append(" IDTIPOPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" NIVELUSO, ")
        strSQL.Append(" CONCENTRACION, ")
        strSQL.Append(" FORMAFARMACEUTICA, ")
        strSQL.Append(" PRESENTACION, ")
        strSQL.Append(" PRIORIDAD, ")
        strSQL.Append(" PRECIOACTUAL, ")
        strSQL.Append(" EXISTENCIAACTUAL, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" NOMBRE + ' ' + CONCENTRACION + ' ' + FORMAFARMACEUTICA +  ' ' + PRESENTACION AS DESCLARGO")
        strSQL.Append(" FROM SAB_CAT_CATALOGOPRODUCTOS ")

    End Sub

    ''' <summary>
    ''' obtener informacion de catalogo de productos de la vista vv_CATALOGOPRODUCTOS filtrada por grupo
    ''' </summary>
    ''' <param name="IDgrupo"></param> 'identificador grupo
    ''' <returns>
    ''' Data set con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoPorGrupo(ByVal IDGRUPO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE IDGRUPO = @IDGRUPO ")
        strSQL.Append("ORDER BY DESCLARGO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.BigInt)
        args(0).Value = IDGRUPO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos de la vista vv_CATALOGOPRODUCTOS filtrada por subgrupo
    ''' </summary>
    ''' <param name="IDSUBGRUPO">Identificacion del subgrupo</param> 'identificador de subgrupo
    ''' <returns>
    ''' Data set con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoPorSubgrupo(ByVal IDSUBGRUPO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE IDSUBGRUPO = @IDSUBGRUPO ")
        strSQL.Append("ORDER BY CORRPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUBGRUPO", SqlDbType.BigInt)
        args(0).Value = IDSUBGRUPO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener los productos por subgrupo
    ''' </summary>
    ''' <param name="IDSUBGRUPO">Identificacion del subgrupo</param>
    ''' <returns>dataset</returns>

    Public Function ObtenerCatalogoProductosCompletoPorSubgrupo2(ByVal IDSUBGRUPO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CP.*, ")
        strSQL.Append("'(' + CP.CORRPRODUCTO + ') ' + CP.DESCLARGO CORRELATIVODESCRIPCION, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("WHERE CP.IDSUBGRUPO = @IDSUBGRUPO ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUBGRUPO", SqlDbType.BigInt)
        args(0).Value = IDSUBGRUPO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos de la vista vv_CATALOGOPRODUCTOS filtrada por suministro
    ''' </summary>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param> 'identificador de suministro
    ''' <returns>
    ''' Data set con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoPorSuministro(ByVal IDSUMINISTRO As Int32, Optional ByVal CRITERIO As String = "") As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE IDSUMINISTRO = @IDSUMINISTRO ")

        If CRITERIO <> "" Then
            strSQL.Append("AND DESCLARGO LIKE '%" & CRITERIO & "%' OR CORRPRODUCTO = '" & CRITERIO & "'")
        End If

        strSQL.Append("ORDER BY CORRPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function


    ''' <summary>
    '''  obtener informacion de catalogo de productos habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador de establecimiento
    ''' <returns>
    ''' Dataset con la informacion de la vista
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_PRODUCTOSHABILITADOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 

    Public Function ObtenerCatalogoProductosCompletoHabilitadoEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaProductosHabilitados(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY DESCLARGO")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por grupo
    ''' </summary>
    ''' <param name="IDgrupo"></param> 'identificador de grupo
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'idetificador de parametro
    ''' <returns>
    '''  ''' Dataset con la informacion de la vista filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_PRODUCTOSHABILITADOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoHabilitadoPorGrupo(ByVal IDgrupo As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaProductosHabilitados(strSQL)
        strSQL.Append("WHERE IDGRUPO = @IDGRUPO ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY DESCLARGO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.BigInt)
        args(0).Value = IDgrupo
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por subgrupo
    ''' </summary>
    ''' <param name="IDSUBGRUPO">Identificacion del subgrupo</param> 'identifiacdor de subgrupo
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador de establecimiento
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_PRODUCTOSHABILITADOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosHabilitadosCompletoPorSubgrupo(ByVal IDsubgrupo As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaProductosHabilitados(strSQL)
        strSQL.Append("WHERE IDSUBGRUPO = @IDSUBGRUPO ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY DESCLARGO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSUBGRUPO", SqlDbType.BigInt)
        args(0).Value = IDsubgrupo
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por suministro
    ''' </summary>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param> 'identificador de suministro
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador de establecimiento
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_PRODUCTOSHABILITADOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoHabilitadoPorSuministro(ByVal IDsuministro As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaProductosHabilitados(strSQL)
        strSQL.Append("WHERE IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY IDPRODUCTO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.BigInt)
        args(0).Value = IDsuministro
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por codigo producto usado por MSPAS
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param> 'codigo de producto usado por el MSPAS
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_PRODUCTOSHABILITADOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetPorCodigoProductoHabilitado(ByVal IDPRODUCTO As String, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaProductosHabilitados(strSQL)
        strSQL.Append("WHERE CORRPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.VarChar)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos por suministro habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por codigo producto usado por MSPAS
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param> 'identificador producto
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param> identificador de suministro
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetPorCodigoXSuministro(ByVal IDPRODUCTO As String, ByVal IDSUMINISTRO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE CORRPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.VarChar)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.BigInt)
        args(1).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos por suministro habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por codigo producto usado por MSPAS
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param> 'identificador producto
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> identificador de establecimiento
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param> identificador de suministro
    ''' <returns>dataset</returns>

    Public Function ObtenerDataSetPorCodigoProductoHabilitadoXSuministro(ByVal IDPRODUCTO As String, ByVal IDESTABLECIMIENTO As Int32, ByVal IDSUMINISTRO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaProductosHabilitados(strSQL)
        strSQL.Append("WHERE CORRPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.VarChar)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.BigInt)
        args(2).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' seleccinar los campos de la vista vv_CATALOGOPRODUCTOS
    ''' </summary>
    ''' <param name="strSQL">Consulta</param>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS </description></item>
    ''' </list> 
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Private Sub SeleccionaVistaCatalogoProductos(ByRef strSQL As Text.StringBuilder)
        strSQL.Append("SELECT ")
        strSQL.Append("IDTIPOSUMINISTRO, ")
        strSQL.Append("TIPOSUMINISTRO, ")
        strSQL.Append("IDSUMINISTRO, ")
        strSQL.Append("CORRSUMINISTRO, ")
        strSQL.Append("DESCSUMINISTRO, ")
        strSQL.Append("IDGRUPO, ")
        strSQL.Append("CORRGRUPO, ")
        strSQL.Append("DESCGRUPO, ")
        strSQL.Append("IDSUBGRUPO, ")
        strSQL.Append("CORRSUBGRUPO, ")
        strSQL.Append("DESCSUBGRUPO, ")
        strSQL.Append("IDPRODUCTO, ")
        strSQL.Append("CORRPRODUCTO, ")
        strSQL.Append("DESCPRODUCTO, ")
        strSQL.Append("DESCLARGO, ")
        strSQL.Append("IDNIVELUSO, ")
        strSQL.Append("NOMBRECORTO, ")
        strSQL.Append("PRECIOACTUAL, ")
        strSQL.Append("EXISTENCIAACTUAL, ")
        strSQL.Append("DESCRIPCION, ")
        strSQL.Append("DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("IDUNIDADMEDIDA, ")
        strSQL.Append("DESCRIPCION, ")
        strSQL.Append("UNIDADMEDIDA, ")
        strSQL.Append("UNIDADESCONTENIDAS, ")
        strSQL.Append("CANTIDADDECIMAL, ")
        strSQL.Append("CODIGONACIONESUNIDAS, ")
        strSQL.Append("CODIGONOMBRE, ")
        strSQL.Append("ALTERNATIVA, ")
        strSQL.Append("IDESTABLECIMIENTO, ")
        strSQL.Append("CLASIFICACION, ")
        strSQL.Append("ESPECIFICACIONESTECNICAS, ")
        strSQL.Append("PERTENECELISTADOOFICIAL, ")
        strSQL.Append("AREATECNICA, ")
        strSQL.Append("TIPOUACI, ")
        strSQL.Append("IDESPECIFICOGASTO, ")
        strSQL.Append("NOMBREESPECIFICOGASTO, ")
        strSQL.Append("CODIGOESPECIFICOGASTO ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS ")
    End Sub

    ''' <summary>
    ''' seleccinar los campos de la vista vv_PRODUCTOSHABILITADOS
    ''' </summary>
    ''' <param name="strSQL">Consulta</param>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_PRODUCTOSHABILITADOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Private Sub SeleccionaVistaProductosHabilitados(ByRef strSQL As Text.StringBuilder)
        strSQL.Append("SELECT ")
        strSQL.Append("IDSUMINISTRO, ")
        strSQL.Append("CORRSUMINISTRO, ")
        strSQL.Append("DESCSUMINISTRO, ")
        strSQL.Append("IDGRUPO, ")
        strSQL.Append("CORRGRUPO, ")
        strSQL.Append("DESCGRUPO, ")
        strSQL.Append("IDSUBGRUPO, ")
        strSQL.Append("CORRSUBGRUPO, ")
        strSQL.Append("DESCSUBGRUPO, ")
        strSQL.Append("IDPRODUCTO, ")
        strSQL.Append("CORRPRODUCTO, ")
        strSQL.Append("DESCPRODUCTO, ")
        strSQL.Append("DESCLARGO, ")
        strSQL.Append("IDNIVELUSO, ")
        strSQL.Append("NOMBRECORTO, ")
        strSQL.Append("PRECIOACTUAL, ")
        strSQL.Append("EXISTENCIAACTUAL, ")
        strSQL.Append("DESCRIPCION, ")
        '   strSQL.Append("ESTAHABILITADO, ")
        strSQL.Append("IDESTABLECIMIENTO, ")
        strSQL.Append("IDUNIDADMEDIDA ")
        strSQL.Append("FROM vv_PRODUCTOSHABILITADOS ")
    End Sub
    ''' <summary>
    ''' Obtener la informacion de los renglones adjudicados por oferta
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>dataset</returns>

    Public Function obtenerRenglonesAdjudicadosOferta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("  SELECT SAB_UACI_DETALLEOFERTA.RENGLON, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE ")
        strSQL.Append("  FROM SAB_UACI_DETALLEOFERTA INNER JOIN ")
        strSQL.Append("  SAB_UACI_DETALLEPROCESOCOMPRA ON SAB_UACI_DETALLEOFERTA.RENGLON = SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON AND ")
        strSQL.Append("  SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append("  SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA  ")
        'strSQL.Append("  AND SAB_UACI_DETALLEOFERTA.IDDETALLE = SAB_UACI_DETALLEPROCESOCOMPRA.IDDETALLE  ")
        strSQL.Append("  INNER JOIN SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append("  SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO ")
        strSQL.Append("  WHERE (SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")
        strSQL.Append("  GROUP BY SAB_UACI_DETALLEOFERTA.RENGLON, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE ")
        ''prueba orden contrato
        strSQL.Append("  ORDER BY SAB_UACI_DETALLEOFERTA.RENGLON, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtener la informacion de los productos en base al filtro
    ''' </summary>
    ''' <param name="CRITERIO">Identificador del criterio</param>
    ''' <param name="TIPO">Identificador del tipo de producto</param>
    ''' <returns>Lista de productos</returns>

    Public Function ObtenerListaPorID(ByVal CRITERIO As String, ByVal TIPO As Int16) As listaCATALOGOPRODUCTOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)

        Select Case TIPO
            Case Is = 1
                strSQL.Append(" WHERE IDTIPOPRODUCTO = " & Val(CRITERIO))
            Case Is = 2
                strSQL.Append(" WHERE CODIGO = '" & CRITERIO & "'")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaCATALOGOPRODUCTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New CATALOGOPRODUCTOS
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.CODIGO = IIf(dr("CODIGO") Is DBNull.Value, Nothing, dr("CODIGO"))
                mEntidad.IDTIPOPRODUCTO = IIf(dr("IDTIPOPRODUCTO") Is DBNull.Value, Nothing, dr("IDTIPOPRODUCTO"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.NIVELUSO = IIf(dr("NIVELUSO") Is DBNull.Value, Nothing, dr("NIVELUSO"))
                mEntidad.CONCENTRACION = IIf(dr("CONCENTRACION") Is DBNull.Value, Nothing, dr("CONCENTRACION"))
                mEntidad.FORMAFARMACEUTICA = IIf(dr("FORMAFARMACEUTICA") Is DBNull.Value, Nothing, dr("FORMAFARMACEUTICA"))
                mEntidad.PRESENTACION = IIf(dr("PRESENTACION") Is DBNull.Value, Nothing, dr("PRESENTACION"))
                mEntidad.PRIORIDAD = IIf(dr("PRIORIDAD") Is DBNull.Value, Nothing, dr("PRIORIDAD"))
                mEntidad.PRECIOACTUAL = IIf(dr("PRECIOACTUAL") Is DBNull.Value, Nothing, dr("PRECIOACTUAL"))
                mEntidad.APLICALOTE = IIf(dr("APLICALOTE") Is DBNull.Value, Nothing, dr("APLICALOTE"))
                mEntidad.EXISTENCIAACTUAL = IIf(dr("EXISTENCIAACTUAL") Is DBNull.Value, Nothing, dr("EXISTENCIAACTUAL"))
                mEntidad.ESPECIFICACIONESTECNICAS = IIf(dr("ESPECIFICACIONESTECNICAS") Is DBNull.Value, Nothing, dr("ESPECIFICACIONESTECNICAS"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function
    ''' <summary>
    ''' Obtener la informacion de los productos adjudicados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDCONTRATO">Identificador del contrato</param>
    ''' <returns>dataset</returns>

    Public Function obtenerProductosAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_CATALOGOPRODUCTOS.CODIGO + ', ' + SAB_CAT_CATALOGOPRODUCTOS.NOMBRE + ', ' + SAB_CAT_CATALOGOPRODUCTOS.CONCENTRACION ")
        strSQL.Append(" AS CODIGONOMBRE ")
        strSQL.Append(" FROM SAB_UACI_DETALLEPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON = SAB_UACI_DETALLEOFERTA.RENGLON INNER JOIN ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS ON ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_UACI_ALMACENESENTREGACONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDDETALLE = SAB_UACI_ALMACENESENTREGACONTRATOS.IDDETALLE AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.RENGLON = SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON ")
        strSQL.Append(" WHERE (SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO = " & IDCONTRATO & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene la información de contratos por proceso de compras
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Filtro para devolver los datos.</param>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function ObtenerDataSetPorContratoProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT distinct pc.IDPRODUCTO, v.DESCLARGO ")
        strSQL.Append(" FROM SAB_UACI_PRODUCTOSCONTRATO pc INNER JOIN ")
        strSQL.Append("        SAB_UACI_CONTRATOSPROCESOCOMPRA cpc ON ")
        strSQL.Append("        pc.IDESTABLECIMIENTO = cpc.IDESTABLECIMIENTO AND ")
        strSQL.Append("        pc.IDPROVEEDOR = cpc.IDPROVEEDOR AND ")
        strSQL.Append("        pc.IDCONTRATO = cpc.IDCONTRATO INNER JOIN ")
        strSQL.Append("        vv_CATALOGOPRODUCTOS v ON pc.IDPRODUCTO = v.IDPRODUCTO ")
        strSQL.Append(" WHERE (cpc.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (cpc.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene información de un producto
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos.</param>
    ''' <param name="IDPROCESOCOMPRA">Filtro para devolver los datos.</param>
    ''' <param name="IDPRODUCTO">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_UACI_ENTREGAADJUDICACION</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function DevolverProducto(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT PC.RENGLON, V.IDPRODUCTO, V.CORRPRODUCTO, V.DESCLARGO, Max(A.IDENTREGA) AS CANTIDADENTREGAS, ")
        strSQL.Append(" '' AS NUMEROCONTRATO, '' AS NOMBRECONTRATO, '' AS NOMBREALMACEN, '' AS CODIGOPROVEEDOR, '' AS ")
        strSQL.Append(" NOMBREPROVEEDOR ")
        strSQL.Append(" FROM SAB_UACI_PRODUCTOSCONTRATO PC inner join  vv_CATALOGOPRODUCTOS V ON ")
        strSQL.Append(" PC.IDPRODUCTO = V.IDPRODUCTO ")
        strSQL.Append(" INNER JOIN SAB_UACI_ENTREGAADJUDICACION A ON ")
        strSQL.Append(" PC.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO AND ")
        strSQL.Append(" PC.IDPROVEEDOR = A.IDPROVEEDOR AND PC.RENGLON = A.IDDETALLE ")
        strSQL.Append(" WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND  A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA and V.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" GROUP BY PC.RENGLON,  V.IDPRODUCTO, V.CORRPRODUCTO, V.DESCLARGO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener el identificador del producto
    ''' </summary>
    ''' <returns>Valor entero</returns>

    Public Function ObtenerIDPRODUCTO() As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(IDPRODUCTO), 0) ")
        strSQL.Append("FROM SAB_CAT_CATALOGOPRODUCTOS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Obtiene el catalogo de productos
    ''' </summary>
    ''' <param name="NM">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_CAT_SUBGRUPOS</description></item>
    ''' <item><description>SAB_CAT_GRUPOS</description></item>
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function RecuperarCP(ByVal NM As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT C.IDPRODUCTO, ")
        strSQL.Append(" C.CODIGO, ")
        strSQL.Append(" C.IDTIPOPRODUCTO, ")
        strSQL.Append(" C.IDUNIDADMEDIDA, ")
        strSQL.Append(" C.NOMBRE, ")
        strSQL.Append(" C.NIVELUSO, ")
        strSQL.Append(" C.CONCENTRACION, ")
        strSQL.Append(" C.FORMAFARMACEUTICA, ")
        strSQL.Append(" C.PRESENTACION, ")
        strSQL.Append(" C.PRIORIDAD, ")
        strSQL.Append(" C.PRECIOACTUAL, ")
        strSQL.Append(" C.APLICALOTE, ")
        strSQL.Append(" C.EXISTENCIAACTUAL, ")
        strSQL.Append(" C.PERTENECELISTADOOFICIAL, ")
        strSQL.Append(" C.ESTADOPRODUCTO, ")
        strSQL.Append(" C.OBSERVACION, ")
        strSQL.Append(" C.ESPECIFICACIONESTECNICAS, C.NOMBRE + ' ' + isnull(C.CONCENTRACION,'') + ' ' + isnull(C.FORMAFARMACEUTICA,'') +  ' ' + isnull(C.PRESENTACION,'') AS DESCLARGO, U.DESCRIPCION UNIDADMEDIDA, N.NOMBRECORTO ")
        strSQL.Append(" FROM SAB_CAT_CATALOGOPRODUCTOS C INNER JOIN SAB_CAT_UNIDADMEDIDAS U ON C.IDUNIDADMEDIDA = U.IDUNIDADMEDIDA INNER JOIN SAB_CAT_NIVELESUSO N ON N.IDNIVELUSO = C.NIVELUSO ")
        strSQL.Append(" INNER JOIN SAB_CAT_SUBGRUPOS S ON S.IDSUBGRUPO = C.IDTIPOPRODUCTO ")
        strSQL.Append(" INNER JOIN SAB_CAT_GRUPOS G ON G.IDGRUPO = S.IDGRUPO ")
        strSQL.Append(" INNER JOIN SAB_CAT_SUMINISTROS SS ON SS.IDSUMINISTRO = G.IDSUMINISTRO ")

        If NM = 0 Then
            'strSQL.Append(" WHERE SS.IDSUMINISTRO = 1 ")
        Else
            strSQL.Append(" WHERE SS.IDTIPOSUMINISTRO <> 1 AND C.IDESTABLECIMIENTO IS NULL ")
        End If

        strSQL.Append("ORDER BY C.CODIGO ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Informacion de los productos no medicos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>dataset</returns>

    Public Function RecuperarCatalogoNoMedico(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)

        strSQL.Append("WHERE IDTIPOSUMINISTRO <> 1 ")
        strSQL.Append("AND (IDESTABLECIMIENTO = @IDESTABLECIMIENTO OR (@IDESTABLECIMIENTO = 0 AND IDESTABLECIMIENTO IS NULL)) ")
        strSQL.Append("ORDER BY C.CODIGO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener la informacion de los productos en base a un subgrupo
    ''' </summary>
    ''' <param name="IDSUBGRUPO">Identificacion del subgrupo</param>
    ''' <param name="NM">Identificador del filtro</param>
    ''' <returns>dataset</returns>

    Public Function RecuperarCP2(ByVal idsubgrupo As Integer, Optional ByVal NM As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT C.IDPRODUCTO, ")
        strSQL.Append(" C.CODIGO, ")
        strSQL.Append(" C.IDTIPOPRODUCTO, ")
        strSQL.Append(" C.IDUNIDADMEDIDA, ")
        strSQL.Append(" C.NOMBRE, ")
        strSQL.Append(" C.NIVELUSO, ")
        strSQL.Append(" C.CONCENTRACION, ")
        strSQL.Append(" C.FORMAFARMACEUTICA, ")
        strSQL.Append(" C.PRESENTACION, ")
        strSQL.Append(" C.PRIORIDAD, ")
        strSQL.Append(" C.PRECIOACTUAL, ")
        strSQL.Append(" C.APLICALOTE, ")
        strSQL.Append(" C.EXISTENCIAACTUAL, ")
        strSQL.Append(" C.PERTENECELISTADOOFICIAL, ")
        strSQL.Append(" C.ESTADOPRODUCTO, ")
        strSQL.Append(" C.OBSERVACION, ")
        strSQL.Append(" C.ESPECIFICACIONESTECNICAS, C.NOMBRE + ' ' + isnull(C.CONCENTRACION,'') + ' ' + isnull(C.FORMAFARMACEUTICA,'') +  ' ' + isnull(C.PRESENTACION,'') AS DESCLARGO, U.DESCRIPCIONLARGA, N.NOMBRECORTO ")
        strSQL.Append(" FROM SAB_CAT_CATALOGOPRODUCTOS C INNER JOIN SAB_CAT_UNIDADMEDIDAS U ON C.IDUNIDADMEDIDA = U.IDUNIDADMEDIDA INNER JOIN SAB_CAT_NIVELESUSO N ON N.IDNIVELUSO = C.NIVELUSO ")
        strSQL.Append(" INNER JOIN SAB_CAT_SUBGRUPOS S ON S.IDSUBGRUPO = C.IDTIPOPRODUCTO ")
        strSQL.Append(" INNER JOIN SAB_CAT_GRUPOS G ON G.IDGRUPO = S.IDGRUPO ")
        strSQL.Append(" INNER JOIN SAB_CAT_SUMINISTROS SS ON SS.IDSUMINISTRO = G.IDSUMINISTRO ")

        If NM = 0 Then
            strSQL.Append(" WHERE SS.IDSUMINISTRO = 1 AND ")
            strSQL.Append(" IDTIPOPRODUCTO = " & idsubgrupo & "")
        Else
            strSQL.Append(" WHERE SS.IDTIPOSUMINISTRO <> 1 AND ")
            strSQL.Append(" IDTIPOPRODUCTO = " & idsubgrupo & " AND C.IDESTABLECIMIENTO IS NULL ")
        End If

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' obtener catalogo de productos de productos de la vista vv_CATALOGOPRODUCTOS filtrado por tipo de suministros no medico
    ''' y por codigo de producto utilizado por el MSPAS
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param> 'Codigo producto utilizado por MSPAS
    ''' <param name="IDTIPOSUMINISTRO"></param> 'idtificador del tipo de suministro
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetPorCodigoProductosNoMedicos(ByVal IDPRODUCTO As String, ByVal IDTIPOSUMINISTRO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE CORRPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDTIPOSUMINISTRO = @IDTIPOSUMINISTRO ")
        strSQL.Append("ORDER BY DESCLARGO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.VarChar)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@IDTIPOSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDTIPOSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener informacion del producto por codigo de producto no medico
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param>
    ''' <param name="IDTIPOSUMINISTRO">Identificador del tipo de suministro</param>
    ''' <returns>Dataset</returns>

    Public Function ObtenerDataSetPorCodigoProductoNoMedicoConHomogeneos(ByVal IDPRODUCTO As String, ByVal IDTIPOSUMINISTRO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE CORRPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND (IDTIPOSUMINISTRO = @IDTIPOSUMINISTRO ")
        strSQL.Append(" OR IDSUMINISTRO IN (SELECT DISTINCT IDSUMINISTRO FROM SAB_CAT_SUMINISTROSHOMOGENEOS SH WHERE SH.IDSUMINISTRO = @IDTIPOSUMINISTRO OR SH.IDSUMINISTROHOMOGENEO = @IDTIPOSUMINISTRO)) ")
        strSQL.Append("ORDER BY DESCLARGO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.VarChar)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@IDTIPOSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDTIPOSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener catalogo de productos de productos de la vista vv_CATALOGOPRODUCTOS filtrado por tipo de suministros no medico
    ''' </summary>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param> 'identificador del suministro
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompleto(ByVal IDSUMINISTRO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append("ORDER BY DESCLARGO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener informacion de los productos habilitados
    ''' </summary>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="CRITERIO">Identificador del criterio</param>
    ''' <returns>Dataset</returns>

    Public Function ObtenerCatalogoProductosCompletoHabilitados(ByVal IDSUMINISTRO As Int32, Optional ByVal CRITERIO As String = "") As DataSet

        Dim strSQL As New Text.StringBuilder
        'SeleccionaVistaProductosHabilitados(strSQL)
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE IDSUMINISTRO = @IDSUMINISTRO ")
        If CRITERIO <> "" Then
            strSQL.Append("AND DESCLARGO LIKE '%" & CRITERIO & "%' OR CORRPRODUCTO = '" & CRITERIO & "'")
        End If

        strSQL.Append("ORDER BY DESCLARGO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener informacion de los productos habilitados
    ''' </summary>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="CRITERIO">Identificador del criterio</param>
    ''' <returns>Dataset</returns>

    Public Function ObtenerCatalogoProductosCompletoOficial(ByVal IDSUMINISTRO As Int32, Optional ByVal CRITERIO As String = "") As DataSet

        Dim strSQL As New Text.StringBuilder
        'SeleccionaVistaProductosHabilitados(strSQL)
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append("AND (((PERTENECELISTADOOFICIAL = 1) or idgrupo in(104,106,193,57,194,195,197,198))  ")

        If CRITERIO <> "" Then
            strSQL.Append("AND DESCLARGO LIKE '%" & CRITERIO & "%' OR CORRPRODUCTO = '" & CRITERIO & "')")
        End If
        '    strSQL.Append("AND (PERTENECELISTADOOFICIAL = 1 or idgrupo in(104,106,193,57,194,195,197,198)) ")

        strSQL.Append("ORDER BY DESCLARGO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function





    ''' <summary>
    ''' Obtener la informacion de los productos completos no medicos 
    ''' </summary>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <returns>DATASET</returns>

    Public Function ObtenerCatalogoProductosCompletoNoMedicoConHomogeneos(ByVal IDSUMINISTRO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append("OR IDSUMINISTRO IN (SELECT DISTINCT IDSUMINISTRO FROM SAB_CAT_SUMINISTROSHOMOGENEOS SH WHERE SH.IDSUMINISTRO = @IDSUMINISTRO OR SH.IDSUMINISTROHOMOGENEO = @IDSUMINISTRO) ")
        strSQL.Append("ORDER BY DESCLARGO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener catalogo de productos de productos de la vista vv_CATALOGOPRODUCTOS filtrado por tipo de suministros no medico
    ''' y el grupo al que pertenece
    ''' </summary>
    ''' <param name="IDgrupo"></param> 'identificador de grupo
    ''' <param name="IDTIPOSUMINISTRO"></param> 'identificador de suministro
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoPorGrupoNoMedico(ByVal IDgrupo As Int32, ByVal IDTIPOSUMINISTRO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE IDGRUPO = @IDGRUPO ")
        strSQL.Append("AND IDTIPOSUMINISTRO = @IDTIPOSUMINISTRO ")
        strSQL.Append("ORDER BY DESCLARGO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.BigInt)
        args(0).Value = IDgrupo
        args(1) = New SqlParameter("@IDTIPOSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDTIPOSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener la informacion de los productos adjudicados por proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Dataset</returns>

    Public Function obtenerProductosAdjudicadosProCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON, SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO, ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS.NOMBRE + ' ' + SAB_CAT_CATALOGOPRODUCTOS.CONCENTRACION + ' ' + SAB_CAT_CATALOGOPRODUCTOS.FORMAFARMACEUTICA ")
        strSQL.Append("  + ' ' + SAB_CAT_CATALOGOPRODUCTOS.PRESENTACION AS PRODUCTO ")
        strSQL.Append(" FROM SAB_UACI_ALMACENESENTREGACONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON = SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO ")
        strSQL.Append(" WHERE (SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtener la informacion de los productos de un proceso de compra entre rangos de fechas
    ''' </summary>
    ''' <param name="Fini">Identificador de la fecha inicial</param>
    ''' <param name="Ffin">Identificador de la fecha final</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>dataset</returns>

    Public Function ObtenerDataSetPorPeriodoProcesoCompra(ByVal Fini As Date, ByVal Ffin As Date, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT pc.IDPRODUCTO, v.DESCLARGO, cpc.IDESTABLECIMIENTO")
        strSQL.Append(" FROM SAB_UACI_PRODUCTOSCONTRATO AS pc INNER JOIN")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc ON pc.IDESTABLECIMIENTO = cpc.IDESTABLECIMIENTO AND ")
        strSQL.Append(" pc.IDPROVEEDOR = cpc.IDPROVEEDOR AND pc.IDCONTRATO = cpc.IDCONTRATO INNER JOIN")
        strSQL.Append(" vv_CATALOGOPRODUCTOS AS v ON pc.IDPRODUCTO = v.IDPRODUCTO INNER JOIN")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS AS PrC ON cpc.IDPROCESOCOMPRA = PrC.IDPROCESOCOMPRA AND ")
        strSQL.Append(" cpc.IDESTABLECIMIENTO = PrC.IDESTABLECIMIENTO")
        strSQL.Append(" WHERE (cpc.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (PrC.FECHAINICIOPROCESOCOMPRA <= @Ffin) AND ")
        strSQL.Append(" (PrC.FECHAINICIOPROCESOCOMPRA >= @Fini) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@Fini", SqlDbType.DateTime)
        args(0).Value = Fini
        args(1) = New SqlParameter("@Ffin", SqlDbType.DateTime)
        args(1).Value = Ffin
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Eliminar un producto
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param>
    ''' <returns>Valor entero con el resultado de la ejecucion</returns>

    Public Function EliminarProducto(ByVal IDPRODUCTO As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_EliminarProducto")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDPRODUCTO

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

    ''' <summary>
    ''' Obtiene el próximo correlativo de un producto
    ''' </summary>
    ''' <param name="IDSUBGRUPO">Filtro para devolver el dato.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function DevolverProxCorrProducto(ByVal IDSUBGRUPO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT MAX(CODIGO) ")
        strSQL.Append("FROM SAB_CAT_CATALOGOPRODUCTOS ")
        strSQL.Append("WHERE IDTIPOPRODUCTO = @IDSUBGRUPO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        args(0).Value = IDSUBGRUPO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener la informacion de los productos con descripciones largas
    ''' </summary>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <returns>Dataset</returns>

    Public Function ObtenerListaDescripcionLarga(ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT *, ")
        strSQL.Append("'(' + CORRPRODUCTO + ') ' + DESCLARGO CORRELATIVODESCRIPCION ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS ")
        strSQL.Append("WHERE (IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("and pertenecelistadooficial = 1 ")
        strSQL.Append("ORDER BY DESCLARGO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' selecciona la informacion de los productos con devolución
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param>
    ''' <param name="dsP">Identificador de un conjunto de datos</param>
    ''' <returns>dataset</returns>

    Public Function DevolverProductoPeriodo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Int64, ByVal dsP As DataSet) As DataSet

        Dim strSQL As New Text.StringBuilder
        Dim i As Integer
        For i = 0 To dsP.Tables(0).Rows.Count - 1
            strSQL.Append(" SELECT PC.RENGLON, V.IDPRODUCTO, V.CORRPRODUCTO, V.DESCLARGO, COUNT(A.IDENTREGA) AS CANTIDADENTREGAS, ")
            strSQL.Append(" '' AS NUMEROCONTRATO, '' AS NOMBRECONTRATO, '' AS NOMBREALMACEN, '' AS CODIGOPROVEEDOR, '' AS ")
            strSQL.Append(" NOMBREPROVEEDOR ")
            strSQL.Append(" FROM SAB_UACI_PRODUCTOSCONTRATO PC inner join  vv_CATALOGOPRODUCTOS V ON ")
            strSQL.Append(" PC.IDPRODUCTO = V.IDPRODUCTO ")
            strSQL.Append(" INNER JOIN SAB_UACI_ENTREGAADJUDICACION A ON ")
            strSQL.Append(" PC.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO AND ")
            strSQL.Append(" PC.IDPROVEEDOR = A.IDPROVEEDOR ")
            strSQL.Append(" WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO and V.IDPRODUCTO = @IDPRODUCTO  AND  A.IDPROCESOCOMPRA = " & dsP.Tables(0).Rows(i).Item(0).ToString)
            strSQL.Append(" GROUP BY PC.RENGLON,  V.IDPRODUCTO, V.CORRPRODUCTO, V.DESCLARGO ")
            If i < dsP.Tables(0).Rows.Count - 1 Then
                strSQL.Append(" union ")
            End If

        Next

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Validacion de la existencia de un codigo de producto
    ''' </summary>
    ''' <param name="CODIGO">Identificador del codigo del producto</param>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param>
    ''' <returns>Valor booleano</returns>

    Public Function ExisteCodigo(ByVal CODIGO As String, ByVal IDPRODUCTO As Int64) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_CATALOGOPRODUCTOS ")
        strSQL.Append("WHERE lower(CODIGO) = lower(@CODIGO) ")
        strSQL.Append("AND (IDPRODUCTO <> @IDPRODUCTO OR @IDPRODUCTO = 0) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(0).Value = CODIGO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function
    ''' <summary>
    ''' Consulta de identificacion del producto
    ''' </summary>
    ''' <param name="CODIGO">Identificador del codigo del producto</param>
    ''' <returns>valor entero con el identificador del producto</returns>

    Public Function DevolverIDProducto(ByVal CODIGO As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDPRODUCTO ")
        strSQL.Append("FROM SAB_CAT_CATALOGOPRODUCTOS ")
        strSQL.Append("WHERE lower(CODIGO) = lower(@CODIGO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(0).Value = CODIGO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Devuelve la informacion de la vista de productos
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param>
    ''' <returns>entidad de catalogoproductos</returns>

    Public Function devolverEntidadVista(ByVal idProducto As Integer) As CATALOGOPRODUCTOS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT corrproducto, desclargo, descripcion ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS ")
        strSQL.Append("WHERE idProducto = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = idProducto

        Dim eEntidad As New CATALOGOPRODUCTOS

        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Do While dr.Read
            eEntidad.CODIGO = dr.Item(0)
            eEntidad.NOMBRE = dr.Item(1)
            eEntidad.CONCENTRACION = dr.Item(2)
        Loop

        dr.Close()

        Return eEntidad

    End Function


#End Region

#Region " METODOS ALMACEN "

    ''' <summary>
    ''' Devuelve un listado de productos filtrado por un criterio, dicho criterio puede ser el IDPRODUCTO o el CODIGO el 
    ''' cual se especifica en el parametro IDTIPOCONSULTA.
    ''' </summary>
    ''' <param name="CRITERIO">Criterio utilizado para filtrar la información.</param>
    ''' <param name="IDTIPOCONSULTA">Define el campo utilizado para filtrar la información</param>
    ''' <returns>Dataset con el listado de productos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  31/12/2006    Creado
    ''' </history> 
    Public Function FiltrarProductoDS(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Int16, Optional ByVal listadooficial As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)

        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append("WHERE IDPRODUCTO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
            Case Is = 2
                strSQL.Append("WHERE CORRPRODUCTO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
            Case Is = 3
                strSQL.Append("WHERE IDSUBGRUPO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
        End Select

        strSQL.Append("ORDER BY CORRPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@CRITERIO", SqlDbType.VarChar)
        args(0).Value = CRITERIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function FiltrarProductoDSUT(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Int16, ByVal AREATECNICA As Integer, Optional ByVal listadooficial As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)

        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append("WHERE IDPRODUCTO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
            Case Is = 2
                strSQL.Append("WHERE CORRPRODUCTO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
            Case Is = 3
                strSQL.Append("WHERE IDSUBGRUPO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
        End Select
        strSQL.Append("AND AREATECNICA=@AREATECNICA ")
        strSQL.Append("ORDER BY CORRPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@CRITERIO", SqlDbType.VarChar)
        args(0).Value = CRITERIO
        args(1) = New SqlParameter("@AREATECNICA", SqlDbType.VarChar)
        args(1).Value = AREATECNICA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function FiltrarProductoDSUTyGU(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Int16, ByVal AREATECNICA As Integer, ByVal GU As Integer, Optional ByVal listadooficial As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)

        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append("WHERE IDPRODUCTO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
            Case Is = 2
                strSQL.Append("WHERE CORRPRODUCTO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
            Case Is = 3
                strSQL.Append("WHERE IDSUBGRUPO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
        End Select
        strSQL.Append("AND AREATECNICA=@AREATECNICA AND TIPOUACI=@TIPOUACI ")
        strSQL.Append("ORDER BY CORRPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@CRITERIO", SqlDbType.VarChar)
        args(0).Value = CRITERIO
        args(1) = New SqlParameter("@AREATECNICA", SqlDbType.VarChar)
        args(1).Value = AREATECNICA
        args(2) = New SqlParameter("@TIPOUACI", SqlDbType.VarChar)
        args(2).Value = GU

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function FiltrarProductoDSUTyGUSuministros(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Int16, ByVal AREATECNICA As Integer, ByVal GU As Integer, Optional ByVal listadooficial As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT * FROM vv_CATALOGOPRODUCTOS_SUMINISTRODEPENDENCIAS ")

        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append("WHERE IDPRODUCTO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
            Case Is = 2
                strSQL.Append("WHERE CORRPRODUCTO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
            Case Is = 3
                strSQL.Append("WHERE IDSUBGRUPO = @CRITERIO ")
                If listadooficial <> 0 Then
                    strSQL.Append(" AND PERTENECELISTADOOFICIAL=1 ")
                End If
        End Select
        strSQL.Append("AND AREATECNICA=@AREATECNICA AND TIPOUACI=@TIPOUACI ")
        strSQL.Append("ORDER BY CORRPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@CRITERIO", SqlDbType.VarChar)
        args(0).Value = CRITERIO
        args(1) = New SqlParameter("@AREATECNICA", SqlDbType.VarChar)
        args(1).Value = AREATECNICA
        args(2) = New SqlParameter("@TIPOUACI", SqlDbType.VarChar)
        args(2).Value = GU

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Devuelve el código de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <returns>Cadena de texto con el código del producto.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/02/2007   Creado
    ''' </history> 
    Public Function DevolverCodigoProducto(ByVal IDPRODUCTO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CORRPRODUCTO ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS ")
        strSQL.Append("WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve el nombre de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <returns>Cadena de texto con el nombre del producto.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/02/2007   Creado
    ''' </history> 
    Public Function DevolverNombreProducto(ByVal IDPRODUCTO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DESCLARGO ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS ")
        strSQL.Append("WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve la unidad de medida de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <returns>Cadena de texto con la unidad de medida del producto.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/02/2007   Creado
    ''' </history> 
    Public Function DevolverUMProducto(ByVal IDPRODUCTO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DESCRIPCION ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS ")
        strSQL.Append("WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function DevolverPrecioProducto(ByVal IDPRODUCTO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PRECIOACTUAL ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS ")
        strSQL.Append("WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Devuelve un listado de productos filtrado por un criterio, dicho criterio puede ser el IDPRODUCTO o el CODIGO el 
    ''' cual se especifica en el parametro IDTIPOCONSULTA.
    ''' </summary>
    ''' <param name="CRITERIO">Criterio utilizado para filtrar la información.</param>
    ''' <param name="IDTIPOCONSULTA">Define el campo utilizado para filtrar la información</param>
    ''' <returns>Dataset con el listado de productos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  31/12/2006    Creado
    '''     [Mayra Evelyn Martínez Cárcamo]  25/11/2010 Modificado
    ''' </history>
    Public Function FiltrarProductoDSAlmacen(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Int16, ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)

        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append("WHERE IDPRODUCTO = @CRITERIO AND (PERTENECELISTADOOFICIAL = 1 or idgrupo in(104,106,193,57,191,194,195,197,198)) ")
            Case Is = 2
                strSQL.Append("WHERE CORRPRODUCTO = @CRITERIO AND (PERTENECELISTADOOFICIAL = 1 or idgrupo in(104,106,193,57,191,194,195,197,198)) ")
            Case Is = 3
                strSQL.Append("WHERE IDSUBGRUPO = @CRITERIO AND (PERTENECELISTADOOFICIAL = 1 or idgrupo in(104,106,193,57,191,194,195,197,198)) ")
        End Select

        strSQL.Append("AND (IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")

        strSQL.Append("ORDER BY DESCLARGO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@CRITERIO", SqlDbType.VarChar)
        args(0).Value = CRITERIO
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.VarChar)
        args(1).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Consulta de productos filtrada por almacen
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param>
    ''' <param name="CODIGO">Identificador del codigo del producto</param>
    ''' <returns>dataset</returns>

    Public Function FiltrarProductoDSAlmacen(ByVal IDPRODUCTO As Integer, ByVal CODIGO As String) As CATALOGOPRODUCTOS

        Dim strSQL As New Text.StringBuilder
        SeleccionaVistaCatalogoProductos(strSQL)
        strSQL.Append("WHERE IDPRODUCTO = @IDPRODUCTO OR CORRPRODUCTO = @CORRPRODUCTO ")
        strSQL.Append("ORDER BY CORRPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@CORRPRODUCTO", SqlDbType.VarChar)
        args(1).Value = CODIGO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim mEntidad As New CATALOGOPRODUCTOS

        Try
            If dr.HasRows Then
                dr.Read()
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.CODIGO = IIf(dr("CORRPRODUCTO") Is DBNull.Value, Nothing, dr("CORRPRODUCTO"))
                mEntidad.NOMBRE = IIf(dr("DESCLARGO") Is DBNull.Value, Nothing, dr("DESCLARGO"))
                mEntidad.CANTIDADDECIMAL = IIf(dr("CANTIDADDECIMAL") Is DBNull.Value, Nothing, dr("CANTIDADDECIMAL"))
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return mEntidad

    End Function

    ''' <summary>
    ''' Devuelve el identificador de la unidad de medida de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <returns>Cadena de texto con el identificador de la unidad de medida del producto.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/02/2007   Creado
    ''' </history> 
    Public Function DevolverIDUMProducto(ByVal IDPRODUCTO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDUNIDADMEDIDA ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS ")
        strSQL.Append("WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve el listado de productos con existencias de un almacén.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del producto.</param>
    ''' <returns>Dataset con la lista de productos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_EXISTENCIASALMACENES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/02/2007   Creado
    ''' </history>
    Public Function FiltrarProductosConExistencia(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int32, ByVal IDSUBGRUPO As Int32, ByVal IDTIPOFILTRO As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("E.IDALMACEN, ")
        strSQL.Append("E.IDPRODUCTO, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("'(' + CP.CORRPRODUCTO + ') ' + CP.DESCLARGO CORRELATIVODESCRIPCION, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.NOMBRECORTO, ")
        strSQL.Append("CP.PRECIOACTUAL, ")
        strSQL.Append("CP.EXISTENCIAACTUAL, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.UNIDADESCONTENIDAS, ")
        strSQL.Append("CP.ALTERNATIVA, ")
        strSQL.Append("CP.CODIGONACIONESUNIDAS, ")
        strSQL.Append("CP.IDTIPOSUMINISTRO, ")
        strSQL.Append("CP.CODIGONOMBRE, ")
        strSQL.Append("E.CANTIDADDISPONIBLE, ")
        strSQL.Append("E.CANTIDADNODISPONIBLE, ")
        strSQL.Append("E.CANTIDADRESERVADA, ")
        strSQL.Append("E.CANTIDADTEMPORAL, ")
        strSQL.Append("E.CANTIDADVENCIDA ")
        strSQL.Append("FROM ")
        strSQL.Append("vv_EXISTENCIASALMACENES E ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON E.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE E.IDALMACEN = @IDALMACEN ")

        Select Case IDTIPOFILTRO
            Case 0, 1
                strSQL.Append("AND E.CANTIDADDISPONIBLE > 0 ")
            Case 2
                strSQL.Append("AND E.CANTIDADNODISPONIBLE > 0 ")
            Case 3
                strSQL.Append("AND E.CANTIDADVENCIDA > 0 ")
            Case 4
                strSQL.Append("AND E.CANTIDADRESERVADA > 0 ")
            Case 5
                strSQL.Append("AND E.CANTIDADTEMPORAL > 0 ")
        End Select

        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("AND (CP.IDSUBGRUPO = @IDSUBGRUPO OR @IDSUBGRUPO = 0) ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        args(2).Value = IDSUBGRUPO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Consulta de la existencia de un producto
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param>
    ''' <param name="CODIGO">Identificador del codigo del producto</param>
    ''' <param name="IDSUBGRUPO">Identificacion del subgrupo</param>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="CANTIDADDISPONIBLE">Identificador de la cantidad disponible</param>
    ''' <param name="CANTIDADNODISPONIBLE">Identificador de la cantidad no disponible</param>
    ''' <param name="CANTIDADVENCIDA">Identificador de la cantidad vencida</param>
    ''' <param name="CANTIDADRESERVADA">Identificador de la cantidad reservada</param>
    ''' <param name="CANTIDADTEMPORAL">Identificador de la cantidad temporal</param>
    ''' <returns>dataset</returns>

    Public Function BuscarProducto(ByVal IDPRODUCTO As Integer, ByVal CODIGO As String, ByVal IDSUBGRUPO As Integer, ByVal IDALMACEN As Integer, ByVal CANTIDADDISPONIBLE As Integer, ByVal CANTIDADNODISPONIBLE As Integer, ByVal CANTIDADVENCIDA As Integer, ByVal CANTIDADRESERVADA As Integer, ByVal CANTIDADTEMPORAL As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_CATALOGOPRODUCTOS CP ")
        strSQL.Append("WHERE (CP.IDPRODUCTO = @IDPRODUCTO OR CP.CORRPRODUCTO = @CORRPRODUCTO OR (CP.IDTIPOPRODUCTO = @IDSUBGRUPO OR @IDSUBGRUPO = 0)) ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@CORRPRODUCTO", SqlDbType.VarChar)
        args(1).Value = CODIGO
        args(2) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        args(2).Value = IDSUBGRUPO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then
            Return Nothing
        Else
            strSQL.Length = 0
            strSQL.Append("SELECT ")
            strSQL.Append("CP.* ")
            strSQL.Append("FROM vv_CATALOGOPRODUCTOS CP ")
            strSQL.Append("WHERE ")
            strSQL.Append("(CP.IDPRODUCTO = @IDPRODUCTO OR CP.CORRPRODUCTO = @CORRPRODUCTO OR (CP.IDSUBGRUPO = @IDSUBGRUPO OR @IDSUBGRUPO = 0)) ")
            strSQL.Append("AND (@IDALMACEN = 0 OR (@IDALMACEN > 0 AND CP.IDPRODUCTO IN ( ")
            strSQL.Append("SELECT EA.IDPRODUCTO ")
            strSQL.Append("FROM vv_EXISTENCIASALMACENES EA ")
            strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
            strSQL.Append("ON EA.IDPRODUCTO = CP.IDPRODUCTO ")
            strSQL.Append("WHERE (CP.IDPRODUCTO = @IDPRODUCTO OR CP.CORRPRODUCTO = @CORRPRODUCTO OR (CP.IDSUBGRUPO = @IDSUBGRUPO OR @IDSUBGRUPO = 0)) ")
            strSQL.Append("AND (EA.IDALMACEN = @IDALMACEN) ")
            strSQL.Append("AND (EA.CANTIDADDISPONIBLE > 0 OR @CANTIDADDISPONIBLE = 0) ")
            strSQL.Append("AND (EA.CANTIDADNODISPONIBLE > 0 OR @CANTIDADNODISPONIBLE = 0) ")
            strSQL.Append("AND (EA.CANTIDADVENCIDA > 0 OR @CANTIDADVENCIDA = 0) ")
            strSQL.Append("AND (EA.CANTIDADRESERVADA > 0 OR @CANTIDADRESERVADA = 0) ")
            strSQL.Append("AND (EA.CANTIDADTEMPORAL > 0 OR @CANTIDADTEMPORAL = 0)))) ")
            strSQL.Append("ORDER BY CP.CORRPRODUCTO, CP.DESCLARGO ")

            args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
            args(3).Value = IDALMACEN
            args(4) = New SqlParameter("@CANTIDADDISPONIBLE", SqlDbType.Int)
            args(4).Value = CANTIDADDISPONIBLE
            args(5) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.Int)
            args(5).Value = CANTIDADNODISPONIBLE
            args(6) = New SqlParameter("@CANTIDADVENCIDA", SqlDbType.Int)
            args(6).Value = CANTIDADVENCIDA
            args(7) = New SqlParameter("@CANTIDADRESERVADA", SqlDbType.Int)
            args(7).Value = CANTIDADRESERVADA
            args(8) = New SqlParameter("@CANTIDADTEMPORAL", SqlDbType.Int)
            args(8).Value = CANTIDADTEMPORAL

            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

            Return ds

        End If

    End Function

#End Region
    ''' <summary>
    ''' Obtener los precios historicos de los productos
    ''' </summary>
    ''' <param name="CODIGO">Identificador del codigo del producto</param>
    ''' <returns>dataset</returns>

    Public Function ObtenerPreciosHistoricosUACI(ByVal codigo As String) As DataSet
        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT * ")
        strSQL.Append("FROM SAB_UACI_PRECIOSHISTORICOS  ")
        strSQL.Append("WHERE CODIGO= @CODIGO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(0).Value = codigo


        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    Public Function ObtenerCatalogoProductosPorUT(ByVal IDSUBGRUPO As Int32, ByVal AREATECNICA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDPRODUCTO, CORRPRODUCTO+' - '+ DESCLARGO as DESCLARGO ")
        strSQL.Append("from vv_catalogoproductos  ")
        strSQL.Append("WHERE IDSUBGRUPO = @IDSUBGRUPO AND AREATECNICA=@AREATECNICA ")
        strSQL.Append("ORDER BY CORRPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSUBGRUPO", SqlDbType.BigInt)
        args(0).Value = IDSUBGRUPO
        args(1) = New SqlParameter("@AREATECNICA", SqlDbType.BigInt)
        args(1).Value = AREATECNICA
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerCatalogoProductosPorUTyGU(ByVal IDSUBGRUPO As Int32, ByVal AREATECNICA As Integer, ByVal GU As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDPRODUCTO, CORRPRODUCTO+' - '+ DESCLARGO as DESCLARGO ")
        strSQL.Append("from vv_CATALOGOPRODUCTOS_SUMINISTRODEPENDENCIAS  ")
        strSQL.Append("WHERE IDSUBGRUPO = @IDSUBGRUPO AND AREATECNICA=@AREATECNICA AND TIPOUACI=@TIPOUACI ")
        strSQL.Append("ORDER BY CORRPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSUBGRUPO", SqlDbType.BigInt)
        args(0).Value = IDSUBGRUPO
        args(1) = New SqlParameter("@AREATECNICA", SqlDbType.BigInt)
        args(1).Value = AREATECNICA
        args(2) = New SqlParameter("@TIPOUACI", SqlDbType.BigInt)
        args(2).Value = GU
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerCatalogoProductosPorUT2(ByVal IDSUBGRUPO As Int32, ByVal AREATECNICA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDPRODUCTO, CORRPRODUCTO, DESCLARGO, DESCRIPCION ")
        strSQL.Append("from vv_catalogoproductos  ")
        strSQL.Append("WHERE IDSUBGRUPO = @IDSUBGRUPO AND AREATECNICA=@AREATECNICA ")
        strSQL.Append("ORDER BY CORRPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSUBGRUPO", SqlDbType.BigInt)
        args(0).Value = IDSUBGRUPO
        args(1) = New SqlParameter("@AREATECNICA", SqlDbType.BigInt)
        args(1).Value = AREATECNICA
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerListaSolicitudesxProducto(ByVal IdProducto As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select distinct correlativo, s.idsolicitud ")
        strSQL.Append("from sab_est_solicitudes s inner join sab_est_detallesolicitudes ds ")
        strSQL.Append("on s.idestablecimiento=ds.idestablecimiento and ")
        strSQL.Append("s.idsolicitud=ds.idsolicitud ")
        strSQL.Append("where ds.idproducto=@IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IdProducto
        
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerListaPCxProducto(ByVal IdProducto As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select distinct isnull(codigolicitacion,'<sin código>') as codigo, pc.idprocesocompra ")
        strSQL.Append("from sab_uaci_procesocompras pc inner join sab_uaci_detalleprocesocompra dpc ")
        strSQL.Append("on pc.idestablecimiento=dpc.idestablecimiento and ")
        strSQL.Append("pc.idprocesocompra=dpc.idprocesocompra ")
        strSQL.Append("where dpc.idproducto=@IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IdProducto

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerListaEstablecimientosxProducto(ByVal IdProducto As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select distinct a.nombre, a.idalmacen ")
        strSQL.Append("from sab_est_almacenesentregasolicitud aes inner join sab_cat_almacenes a on ")
        strSQL.Append("aes.idalmacenentrega=a.idalmacen ")
        strSQL.Append("where idproducto=@idproducto ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IdProducto

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerInformacionSINAB(ByVal IdProducto As Integer, ByVal mSC As Integer, ByVal mPC As Integer, ByVal mPE As Integer, ByVal mD As Integer, ByVal vSc As Integer, ByVal vPc As Integer, ByVal vE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT * FROM dbo.fn_InfoSINAB(@IDPRODUCTO,@mSC,@mPC,@mPE,@mD,@vSc,@vPc,@vE) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IdProducto
        args(1) = New SqlParameter("@mSC", SqlDbType.Int)
        args(1).Value = mSC
        args(2) = New SqlParameter("@mPC", SqlDbType.Int)
        args(2).Value = mPC
        args(3) = New SqlParameter("@mPE", SqlDbType.Int)
        args(3).Value = mPE
        args(4) = New SqlParameter("@mD", SqlDbType.Int)
        args(4).Value = mD
        args(5) = New SqlParameter("@vSc", SqlDbType.Int)
        args(5).Value = vSc
        args(6) = New SqlParameter("@vPc", SqlDbType.Int)
        args(6).Value = vPc
        args(7) = New SqlParameter("@vE", SqlDbType.Int)
        args(7).Value = vE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds


    End Function

    Public Function ObtenerProductosxTipoUACI(ByVal idsubgrupo As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT V.idproducto,v.corrproducto,v.desclargo,v.descripcion,ISNULL(D.NOMBRE,'<No asignado>') AS DEPENDENCIA, G.IDGRUPO as IDGRUPOUACI,G.GRUPOUACI AS GRUPO FROM vv_CATALOGOPRODUCTOS V ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_DEPENDENCIAS D ON ")
        strSQL.Append("D.IDDEPENDENCIA= V.AREATECNICA ")
        strSQL.Append("INNER JOIN SAB_CAT_GRUPOUACI G ON ")
        strSQL.Append("G.IDGRUPO=V.TIPOUACI ")
        strSQL.Append("WHERE v.IDSUBGRUPO=@idsubgrupo ")
        strSQL.Append("ORDER BY V.corrproducto ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@idsubgrupo", SqlDbType.Int)
        args(0).Value = idsubgrupo


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds


    End Function
    Public Function ObtenerTipoUACI() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDGRUPO, GRUPOUACI ")
        strSQL.Append("FROM SAB_CAT_GRUPOUACI ")
        strSQL.Append("ORDER BY GRUPOUACI ")
        
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function

    Public Function ObtenerTipoUACI(ByVal IDUNIDADTECNICA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        'SELECT distinct gu.IDGRUPO,	gu.GRUPOUACI
        '       
        '       
        '	
        '       ORDER BY GRUPOUACI
        'dt = objIndices.ObtenerDataSetPorId(619).Tables(0)
        strSQL.Append(" SELECT distinct gu.IDGRUPO,  CASE WHEN gu.GRUPOUACI='' THEN 'NO DEFINIDO' ELSE UPPER(gu.GRUPOUACI) END GRUPOUACI ")
        strSQL.Append(" FROM SAB_CAT_GRUPOUACI gu ")
        strSQL.Append(" inner join vv_CATALOGOPRODUCTOS_SUMINISTRODEPENDENCIAS vcp on gu.IDGRUPO=vcp.TIPOUACI ")
        strSQL.Append(" inner join SAB_CAT_SUMINISTRODEPENDENCIAS su on su.iddependencia= vcp.AREATECNICA ")
        strSQL.Append(" where vcp.AREATECNICA= @IDUNIDADTECNICA OR @IDUNIDADTECNICA=-1 ")
        strSQL.Append("ORDER BY GRUPOUACI ")
        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDUNIDADTECNICA", SqlDbType.Int)
        args(0).Value = IDUNIDADTECNICA
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function

    Public Function ObtenerAreaTecnicaByGRUPOUACI(ByVal IDUNIDADTECNICA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        'SELECT distinct gu.IDGRUPO,	gu.GRUPOUACI
        '       
        '       
        '	
        '       ORDER BY GRUPOUACI
        'dt = objIndices.ObtenerDataSetPorId(619).Tables(0)
        strSQL.Append(" SELECT distinct d.iddependencia , d.nombre ")
        strSQL.Append(" FROM SAB_CAT_GRUPOUACI gu ")
        strSQL.Append(" inner join vv_CATALOGOPRODUCTOS_SUMINISTRODEPENDENCIAS vcp on gu.IDGRUPO=vcp.TIPOUACI ")
        strSQL.Append(" inner join SAB_CAT_SUMINISTRODEPENDENCIAS su on su.iddependencia= vcp.AREATECNICA ")
        strSQL.Append("inner join SAB_CAT_DEPENDENCIAS d on d.iddependencia=su.iddependencia ")
        strSQL.Append(" where gu.IDGRUPO= @IDGRUPO OR @IDGRUPO=-1 ")
        strSQL.Append(" ORDER BY nombre ")
        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDUNIDADTECNICA
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function

    Public Function ObtenerEspecificacionesTecnicas(ByVal IdProducto As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDPRODUCTO, IDESPECIFICACION, NOMBREESPECIFICACION, ISNULL(FECHAACTUALIZACION,' ') AS FECHAACTUALIZACION ,ISNULL(PRECIO,0.00) AS PRECIO FROM SAB_CAT_ESPECIFICACIONES WHERE IDPRODUCTO=@IDPRODUCTO")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IdProducto

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds


    End Function
    Public Function ObtenerIDEspecificacionesTecnicas(ByVal IdProducto As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ISNULL(MAX(IDESPECIFICACION)+1,1) AS IDESPECIFICACION FROM SAB_CAT_ESPECIFICACIONES WHERE IDPRODUCTO=@IDPRODUCTO")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IdProducto

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function AgregarEspecificacionesTecnicas(ByVal lE As ESPECIFICACION) As Integer

        Dim e As ESPECIFICACION
        e = lE

        Dim str As New Text.StringBuilder
        str.Append("UPDATE SAB_CAT_CATALOGOPRODUCTOS SET ESPECIFICACIONESTECNICAS=1 WHERE IDPRODUCTO=@IDPRODUCTO")
        Dim args2(0) As SqlParameter
        args2(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args2(0).Value = e.IDPRODUCTO
        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, str.ToString(), args2)

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("INSERT INTO SAB_CAT_ESPECIFICACIONES ")
        strSQL.Append(" ( IDPRODUCTO, ")
        strSQL.Append(" IDESPECIFICACION, ")
        strSQL.Append(" NOMBREESPECIFICACION, ")
        strSQL.Append(" ESPECIFICACION, ")
        strSQL.Append(" FECHAACTUALIZACION, ")
        strSQL.Append(" PRECIO, ")
        strSQL.Append(" IDESTABLECIMIENTO) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDPRODUCTO, ")
        strSQL.Append(" @IDESPECIFICACION, ")
        strSQL.Append(" @NOMBREESPECIFICACION, ")
        strSQL.Append(" @ESPECIFICACION, ")
        strSQL.Append(" @FECHAACTUALIZACION, ")
        strSQL.Append(" @PRECIO, ")
        strSQL.Append(" @IDESTABLECIMIENTO) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = e.IDPRODUCTO
        args(1) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(1).Value = e.IDESPECIFICACION
        args(2) = New SqlParameter("@NOMBREESPECIFICACION", SqlDbType.Text)
        args(2).Value = e.NOMBREESPECIFICACION
        args(3) = New SqlParameter("@ESPECIFICACION", SqlDbType.Text)
        args(3).Value = e.ESPECIFICACION
        args(4) = New SqlParameter("@FECHAACTUALIZACION", SqlDbType.DateTime)
        args(4).Value = e.FECHAACTUALIZACION
        args(5) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(5).Value = e.PRECIO
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = e.IDESTABLECIMIENTO


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)




    End Function
    Public Function DevolverTextoEspecificacion(ByVal IDPRODUCTO As Integer, ByVal IDESPECIFICACION As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("ESPECIFICACION ")
        strSQL.Append("FROM SAB_CAT_ESPECIFICACIONES ")
        strSQL.Append("WHERE IDPRODUCTO = @IDPRODUCTO AND IDESPECIFICACION=@IDESPECIFICACION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@IDESPECIFICACION", SqlDbType.BigInt)
        args(1).Value = IDESPECIFICACION


        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ActualizarEspecificacionesTecnicas(ByVal lE As ESPECIFICACION) As Integer

        Dim e As ESPECIFICACION
        e = lE

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_CAT_ESPECIFICACIONES ")
        strSQL.Append(" SET NOMBREESPECIFICACION=@NOMBREESPECIFICACION, ")
        strSQL.Append(" ESPECIFICACION=@ESPECIFICACION, ")
        strSQL.Append(" FECHAACTUALIZACION=@FECHAACTUALIZACION, ")
        strSQL.Append(" PRECIO=@PRECIO ")
        strSQL.Append(" WHERE IDPRODUCTO=@IDPRODUCTO AND @IDESPECIFICACION=@IDESPECIFICACION ")
        

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = e.IDPRODUCTO
        args(1) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(1).Value = e.IDESPECIFICACION
        args(2) = New SqlParameter("@NOMBREESPECIFICACION", SqlDbType.Text)
        args(2).Value = e.NOMBREESPECIFICACION
        args(3) = New SqlParameter("@ESPECIFICACION", SqlDbType.Text)
        args(3).Value = e.ESPECIFICACION
        args(4) = New SqlParameter("@FECHAACTUALIZACION", SqlDbType.DateTime)
        args(4).Value = e.FECHAACTUALIZACION
        args(5) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(5).Value = e.PRECIO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ActualizarPreciosCatalogoProductos(ByVal idestablecimiento As Integer, ByVal idprocesocompra As Integer) As Integer
        ' productos sin especificaciones técnicas
        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append(" SELECT distinct DPC.IDPRODUCTO, DO.PRECIOUNITARIO ")
        strSQL1.Append(" FROM ")
        strSQL1.Append(" SAB_UACI_PROCESOCOMPRAS pc ")
        strSQL1.Append(" INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA dpc ")
        strSQL1.Append(" ON pc.IDESTABLECIMIENTO = dpc.IDESTABLECIMIENTO AND ")
        strSQL1.Append(" pc.IDPROCESOCOMPRA = dpc.IDPROCESOCOMPRA ")
        strSQL1.Append(" INNER JOIN SAB_UACI_DETALLEOFERTA do ")
        strSQL1.Append(" ON dpc.IDESTABLECIMIENTO = do.IDESTABLECIMIENTO AND ")
        strSQL1.Append(" dpc.IDPROCESOCOMPRA = do.IDPROCESOCOMPRA AND ")
        strSQL1.Append(" dpc.RENGLON = do.RENGLON ")
        strSQL1.Append(" INNER JOIN SAB_UACI_ADJUDICACION a ")
        strSQL1.Append(" ON do.IDESTABLECIMIENTO = a.IDESTABLECIMIENTO AND ")
        strSQL1.Append(" do.IDPROCESOCOMPRA = a.IDPROCESOCOMPRA AND  ")
        strSQL1.Append(" do.IDPROVEEDOR = a.IDPROVEEDOR AND  ")
        strSQL1.Append(" do.IDDETALLE = a.IDDETALLE  ")
        strSQL1.Append(" WHERE ")
        strSQL1.Append(" a.CANTIDADFIRME > 0 AND ")
        strSQL1.Append(" pc.IDESTABLECIMIENTO = @idestablecimiento AND ")
        strSQL1.Append(" pc.IDPROCESOCOMPRA = @idprocesocompra AND ")
        strSQL1.Append(" dpc.IDESPECIFICACION IS NULL ")

        Dim args1(1) As SqlParameter
        args1(0) = New SqlParameter("@idestablecimiento", SqlDbType.Int)
        args1(0).Value = idestablecimiento
        args1(1) = New SqlParameter("@idprocesocompra", SqlDbType.Int)
        args1(1).Value = idprocesocompra

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL1.ToString(), args1)


        Dim row As DataRow = ds.Tables(0).NewRow
        For Each row In ds.Tables(0).Rows

        Dim strSQL As New Text.StringBuilder
            strSQL.Append(" UPDATE SAB_CAT_CATALOGOPRODUCTOS ")
            strSQL.Append(" SET PRECIOACTUAL=" & row("PRECIOUNITARIO"))
            strSQL.Append(" WHERE IDPRODUCTO=" & row("IDPRODUCTO"))
            SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())
        Next

        ' actualizacion para los precios de productos con especificaciones técnicas
        Dim strSQL2 As New Text.StringBuilder
        strSQL2.Append(" SELECT dpc.renglon, DPC.IDPRODUCTO, DO.PRECIOUNITARIO, DPC.IDESPECIFICACION ")
        strSQL2.Append(" FROM ")
        strSQL2.Append(" SAB_UACI_PROCESOCOMPRAS pc ")
        strSQL2.Append(" INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA dpc ")
        strSQL2.Append(" ON pc.IDESTABLECIMIENTO = dpc.IDESTABLECIMIENTO AND ")
        strSQL2.Append(" pc.IDPROCESOCOMPRA = dpc.IDPROCESOCOMPRA ")
        strSQL2.Append(" INNER JOIN SAB_UACI_DETALLEOFERTA do ")
        strSQL2.Append(" ON dpc.IDESTABLECIMIENTO = do.IDESTABLECIMIENTO AND ")
        strSQL2.Append(" dpc.IDPROCESOCOMPRA = do.IDPROCESOCOMPRA AND ")
        strSQL2.Append(" dpc.RENGLON = do.RENGLON ")
        strSQL2.Append(" INNER JOIN SAB_UACI_ADJUDICACION a ")
        strSQL2.Append(" ON do.IDESTABLECIMIENTO = a.IDESTABLECIMIENTO AND ")
        strSQL2.Append(" do.IDPROCESOCOMPRA = a.IDPROCESOCOMPRA AND  ")
        strSQL2.Append(" do.IDPROVEEDOR = a.IDPROVEEDOR AND  ")
        strSQL2.Append(" do.IDDETALLE = a.IDDETALLE  ")
        strSQL2.Append(" WHERE ")
        strSQL2.Append(" a.CANTIDADFIRME > 0 AND ")
        strSQL2.Append(" pc.IDESTABLECIMIENTO = @idestablecimiento AND ")
        strSQL2.Append(" pc.IDPROCESOCOMPRA = @idprocesocompra AND ")
        strSQL2.Append(" dpc.IDESPECIFICACION is not NULL ")

        Dim args2(1) As SqlParameter
        args2(0) = New SqlParameter("@idestablecimiento", SqlDbType.Int)
        args2(0).Value = idestablecimiento
        args2(1) = New SqlParameter("@idprocesocompra", SqlDbType.Int)
        args2(1).Value = idprocesocompra

        Dim ds2 As New DataSet
        ds2 = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL2.ToString(), args2)

        Dim row2 As DataRow = ds2.Tables(0).NewRow
        For Each row2 In ds2.Tables(0).Rows

            Dim strSQL As New Text.StringBuilder
            strSQL.Append(" UPDATE SAB_CAT_ESPECIFICACIONES ")
            strSQL.Append(" SET PRECIO=" & row2("PRECIOUNITARIO"))
            strSQL.Append(" , FECHAACTUALIZACION=getdate() ")
            strSQL.Append(" WHERE IDPRODUCTO=" & row2("IDPRODUCTO"))
            strSQL.Append(" AND IDESPECIFICACION=" & row2("IDESPECIFICACION"))
            SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())
        Next

    End Function
    Public Function ObtenerECOSValorizados(ByVal Idregion As Integer, ByVal mes As Integer, ByVal anio As Integer) As DataSet

        '    Dim strSQL As New Text.StringBuilder

        '    strSQL.Append("SELECT r.nombre as region, s.idsibasi, s.nombre as sibasi, e.idestablecimiento,e.nombre as eco  ")
        '    strSQL.Append(",sum(c.consumofarmacia*cpr.ultimoprecio) total, 'Medicamentos' as tipo ")
        '    strSQL.Append("FROM sce..consumo c inner join sce..establecimiento e on c.idestablecimiento=e.idestablecimiento ")
        '    strSQL.Append("inner  join sce..sibasi s on s.idsibasi=e.idsibasi ")
        '    strSQL.Append("inner  join sce..region r on r.idregion=s.idregion ")
        '    strSQL.Append("inner  join sce..catalogoProducto cp on cp.idproducto=c.idproducto ")
        '    strSQL.Append("inner  join abastecimiento..sab_cat_catalogoproductos cpr on cp.codigo=cpr.codigo ")
        '    strSQL.Append("where e.tipoestablecimiento in ('J','L')  ")
        '    strSQL.Append("and month(c.fechaconsumo)=@mes and year(c.fechaconsumo)=@anio ")
        '    strSQL.Append("and c.consumofarmacia <> 0 ")
        '    strSQL.Append("and r.idregion=@idregion ")
        '    strSQL.Append("group by r.nombre, s.idsibasi, s.nombre, e.idestablecimiento,e.nombre ")
        '    strSQL.Append(" ")
        '    strSQL.Append("union ")
        '    strSQL.Append(" ")
        '    strSQL.Append("select r.nombre as region, s.idsibasi, s.nombre as sibasi, e.idestablecimiento,e.nombre as eco  ")
        '    strSQL.Append(",0 total, 'Medicamentos' as tipo ")
        '    strSQL.Append("from sce..establecimiento e  ")
        '    strSQL.Append("inner join sce..sibasi s on s.idsibasi=e.idsibasi ")
        '    strSQL.Append("inner join sce..region r on r.idregion=s.idregion ")
        '    strSQL.Append("where e.tipoestablecimiento in ('J','L')  ")
        '    strSQL.Append("and r.idregion=@idregion ")
        '    strSQL.Append("and e.idestablecimiento not in ")
        '    strSQL.Append("(select e.idestablecimiento ")
        '    strSQL.Append("from sce..consumo c inner join sce..establecimiento e on c.idestablecimiento=e.idestablecimiento ")
        '    strSQL.Append("inner  join sce..sibasi s on s.idsibasi=e.idsibasi ")
        '    strSQL.Append("inner  join sce..region r on r.idregion=s.idregion ")
        '    strSQL.Append("where e.tipoestablecimiento in ('J','L')  ")
        '    strSQL.Append("and month(c.fechaconsumo)=@mes and year(c.fechaconsumo)=@anio ")
        '    strSQL.Append("and c.consumofarmacia <> 0 ")
        '    strSQL.Append("and r.idregion=@idregion ")
        '    strSQL.Append("group by e.idestablecimiento) ")
        '    strSQL.Append(" ")
        '    strSQL.Append("union  ")
        '    strSQL.Append(" ")
        '    strSQL.Append("SELECT r.nombre as region, s.idsibasi, s.nombre as sibasi, e.idestablecimiento,e.nombre as eco  ")
        '    strSQL.Append(",sum(c.consumofarmacia*cpr.ultimoprecio) total, 'Insumos médicos' as tipo ")
        '    strSQL.Append("FROM sce..consumoInsumo c inner join sce..establecimiento e on c.idestablecimiento=e.idestablecimiento ")
        '    strSQL.Append("inner  join sce..sibasi s on s.idsibasi=e.idsibasi ")
        '    strSQL.Append("inner  join sce..region r on r.idregion=s.idregion ")
        '    strSQL.Append("inner  join sce..catalogoInsumo cp on cp.idproducto=c.idproducto ")
        '    strSQL.Append("inner  join abastecimiento..sab_cat_catalogoproductos cpr on cp.codigo=cpr.codigo ")
        '    strSQL.Append("where e.tipoestablecimiento in ('J','L')  ")
        '    strSQL.Append("and month(c.fechaconsumo)=@mes and year(c.fechaconsumo)=@anio ")
        '    strSQL.Append("and c.consumofarmacia <> 0 ")
        '    strSQL.Append("and r.idregion=@idregion ")
        '    strSQL.Append("group by r.nombre, s.idsibasi, s.nombre, e.idestablecimiento,e.nombre ")
        '    strSQL.Append(" ")
        '    strSQL.Append("union ")
        '    strSQL.Append(" ")
        '    strSQL.Append("select r.nombre as region, s.idsibasi, s.nombre as sibasi, e.idestablecimiento,e.nombre as eco  ")
        '    strSQL.Append(",0 total, 'Insumos médicos' as tipo ")
        '    strSQL.Append("from sce..establecimiento e  ")
        '    strSQL.Append("inner join sce..sibasi s on s.idsibasi=e.idsibasi ")
        '    strSQL.Append("inner join sce..region r on r.idregion=s.idregion ")
        '    strSQL.Append("where e.tipoestablecimiento in ('J','L')  ")
        '    strSQL.Append("and r.idregion=@idregion ")
        '    strSQL.Append("and e.idestablecimiento not in ")
        '    strSQL.Append("(select e.idestablecimiento ")
        '    strSQL.Append("from sce..consumoInsumo c inner join sce..establecimiento e on c.idestablecimiento=e.idestablecimiento ")
        '    strSQL.Append("inner  join sce..sibasi s on s.idsibasi=e.idsibasi ")
        '    strSQL.Append("inner  join sce..region r on r.idregion=s.idregion ")
        '    strSQL.Append("where e.tipoestablecimiento in ('J','L')  ")
        '    strSQL.Append("and month(c.fechaconsumo)=@mes and year(c.fechaconsumo)=@anio ")
        '    strSQL.Append("and c.consumofarmacia <> 0 ")
        '    strSQL.Append("and r.idregion=@idregion ")
        '    strSQL.Append("group by e.idestablecimiento) ")

        '    Dim args(2) As SqlParameter
        '    args(0) = New SqlParameter("@idregion", SqlDbType.Int)
        '    args(0).Value = Idregion
        '    args(1) = New SqlParameter("@mes", SqlDbType.Int)
        '    args(1).Value = mes
        '    args(2) = New SqlParameter("@anio", SqlDbType.Int)
        '    args(2).Value = anio

        '    Dim ds As DataSet
        '    ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        '    Return ds

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT r.nombre as region, s.idsibasi, s.nombre as sibasi, e.idestablecimiento,e.nombre as eco ")
        strSQL.Append(",sum(c.consumofarmacia*cpr.ultimoprecio) total, 'Medicamentos' as tipo ")
        'strSQL.Append("--,sum(c.consumofarmacia*abastecimiento_20110412.dbo.fn_UltimoPrecioProducto(c.idproducto)) ")
        strSQL.Append("FROM sce..consumo c inner join sce..establecimiento e on c.idestablecimiento=e.idestablecimiento ")
        strSQL.Append("inner join sce..sibasi s on s.idsibasi=e.idsibasi ")
        strSQL.Append("inner join sce..region r on r.idregion=s.idregion ")
        strSQL.Append("inner join sce..catalogoProducto cp on cp.idproducto =c.idproducto ")
        strSQL.Append("inner join abastecimiento..sab_cat_catalogoproductos cpr on cp.codigo=cpr.codigo ")
        strSQL.Append("where e.tipoestablecimiento in ('J','L','I','B','E')  ")
        strSQL.Append("and month(c.fechaconsumo)=@mes and year(c.fechaconsumo)=@anio ")
        strSQL.Append("and c.consumofarmacia <> 0 and r.idregion=@idregion ")
        'strSQL.Append("--and r.idregion= ")
        strSQL.Append("group by r.nombre, s.idsibasi, s.nombre, e.idestablecimiento,e.nombre ")
        'strSQL.Append("--order by r.nombre,s.idsibasi,e.idestablecimiento ")
        strSQL.Append(" ")
        strSQL.Append("union  ")
        strSQL.Append(" ")
        strSQL.Append("SELECT r.nombre as region, s.idsibasi, s.nombre as sibasi, e.idestablecimiento,e.nombre as eco  ")
        strSQL.Append(",sum(c.consumofarmacia*cpr.ultimoprecio) total, 'Insumos médicos' as tipo ")
        'strSQL.Append("--,sum(c.consumofarmacia*abastecimiento_20110412.dbo.fn_UltimoPrecioProducto(c.idproducto)) ")
        strSQL.Append("FROM sce..consumoInsumo c inner join sce..establecimiento e on c.idestablecimiento=e.idestablecimiento ")
        strSQL.Append("inner join sce..sibasi s on s.idsibasi=e.idsibasi ")
        strSQL.Append("inner join sce..region r on r.idregion=s.idregion ")
        strSQL.Append("inner join sce..catalogoProducto cp on cp.idproducto=c.idproducto ")
        strSQL.Append("inner join abastecimiento..sab_cat_catalogoproductos cpr on cp.codigo=cpr.codigo ")
        strSQL.Append("where e.tipoestablecimiento in ('J','L','I','B','E')  ")
        strSQL.Append("and month(c.fechaconsumo)=@mes and year(c.fechaconsumo)=@anio ")
        strSQL.Append("and c.consumofarmacia <> 0 and r.idregion=@idregion ")
        'strSQL.Append("--and r.idregion= ")
        strSQL.Append("group by r.nombre, s.idsibasi, s.nombre, e.idestablecimiento,e.nombre ")
        'strSQL.Append("--order by r.nombre,s.idsibasi,e.idestablecimiento ")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@idregion", SqlDbType.Int)
        args(0).Value = Idregion
        args(1) = New SqlParameter("@mes", SqlDbType.Int)
        args(1).Value = mes
        args(2) = New SqlParameter("@anio", SqlDbType.Int)
        args(2).Value = anio

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds


    End Function




End Class
