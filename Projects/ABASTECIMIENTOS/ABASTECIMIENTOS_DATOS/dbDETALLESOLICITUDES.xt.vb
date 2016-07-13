Partial Public Class dbDETALLESOLICITUDES

#Region " Métodos Agregados "

    ''' <summary>
    ''' obtenr informacion de productos del detalle de la solicitud de compra
    ''' </summary>
    ''' <param name="idSolicitud"></param> 'identificdor de la solicitud
    ''' <param name="IDEstablecimiento"></param> identificador del establecimiento
    ''' <returns>
    ''' dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDsDetalleSolicitud(ByVal idSolicitud As Int64, ByVal IDEstablecimiento As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = idSolicitud
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDEstablecimiento

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' elimianr los productos del detalle de una determinada solicitud
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLESOLICITUDES
    ''' <returns>
    ''' Devuelve uno si la operacion se completo
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function EliminarDettalesSolicitud(ByVal aEntidad As DETALLESOLICITUDES) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_DETALLESOLICITUDES ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarPRODUCTOSSolicitud(ByVal aEntidad As DETALLESOLICITUDES) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_PRODUCTOSSOLICITUD ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarAlmacenesEntrega(ByVal aEntidad As DETALLESOLICITUDES) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_ALMACENESENTREGA ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarEntregas(ByVal aEntidad As DETALLESOLICITUDES) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_ENTREGAS ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerRengloMaxEliminaSolicitud(ByVal IDSOLICITUD As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO, SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA, ")
        strSQL.Append(" MAX(SAB_EST_DETALLESOLICITUDES.NUMEROENTREGAS) AS NUMEROENTREGA, SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD ")
        strSQL.Append(" FROM SAB_EST_DETALLESOLICITUDES INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS ON SAB_EST_DETALLESOLICITUDES.IDESTABLECIMIENTO = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTOSOLICITUD AND ")
        strSQL.Append(" SAB_EST_DETALLESOLICITUDES.IDSOLICITUD = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD ")
        strSQL.Append(" WHERE (SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD <> @IDSOLICITUD) AND (SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND ")
        strSQL.Append(" (SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append(" GROUP BY SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO, SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' calcular el monto de la solicitud
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLESOLICITUDES
    ''' <returns>
    ''' Monto de la solicitud
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>

    Public Function CalularMontoTotalSolicitud(ByVal aEntidad As DETALLESOLICITUDES) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(sum(PRESUPUESTOUNITARIO * CANTIDAD), 0) ")
        strSQL.Append("FROM SAB_EST_DETALLESOLICITUDES ")
        strSQL.Append("WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene la información del detalle del consolidado.
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud o compra conjunta.</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertenece la solicitud.</param>
    ''' <returns>Dataset con el detalle de una solicitud.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_EST_ENTREGASOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  06/11/2006    Creado
    ''' </history> 
    Public Function ObtenerDsConsolidado(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("S.IDESTABLECIMIENTO, ")
        strSQL.Append("S.IDSOLICITUD, ")
        strSQL.Append("S.FECHASOLICITUD, ")
        strSQL.Append("S.IDAREATECNICA, ")
        strSQL.Append("S.IDESTADO, ")
        strSQL.Append("DS.IDDETALLE, ")
        strSQL.Append("DS.RENGLON, ")
        strSQL.Append("DS.IDPRODUCTO, ")
        strSQL.Append("DS.CANTIDAD, ")
        strSQL.Append("DS.IDUNIDADMEDIDA, ")
        strSQL.Append("DS.PRESUPUESTOUNITARIO, ")
        strSQL.Append("DS.PRESUPUESTOTOTAL, ")
        strSQL.Append("DS.NUMEROENTREGAS, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("(SELECT MAX(IDENTREGA) FROM SAB_EST_ENTREGASOLICITUDES ES WHERE ES.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND ES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) MAXENTREGA, ")
        strSQL.Append("S.OBSERVACION ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES AS S ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLESOLICITUDES AS DS ")
        strSQL.Append("ON S.IDSOLICITUD = DS.IDSOLICITUD AND S.IDESTABLECIMIENTO = DS.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS AS CP ON DS.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE S.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ORDER BY DS.RENGLON ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene la información del detalle del consolidado filtrado por un producto especifico.
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud o compra conjunta.</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertenece la solicitud.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto del detalle de la solicitud</param>
    ''' <returns>Dataset con la información del producto de una solicitud.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  02/01/2007    Creado
    ''' </history> 
    Public Function ObtenerDsConsolidadoPorProducto(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int64, ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT S.IDESTABLECIMIENTO, S.IDSOLICITUD, S.FECHASOLICITUD, S.IDAREATECNICA, S.IDESTADO, ")
        strSQL.Append(" DS.IDDETALLE, DS.RENGLON, DS.IDPRODUCTO, ")
        strSQL.Append(" DS.CANTIDAD, DS.IDUNIDADMEDIDA, ")
        strSQL.Append(" DS.PRESUPUESTOUNITARIO, DS.PRESUPUESTOTOTAL, ")
        strSQL.Append(" DS.NUMEROENTREGAS, CP.IDSUMINISTRO, ")
        strSQL.Append(" CP.DESCSUMINISTRO, CP.CORRPRODUCTO, ")
        strSQL.Append(" CP.DESCPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES AS S INNER JOIN SAB_EST_DETALLESOLICITUDES AS DS ON S.IDSOLICITUD = DS.IDSOLICITUD AND S.IDESTABLECIMIENTO = DS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS AS CP ON DS.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE S.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND DS.IDPRODUCTO = @IDPRODUCTO ORDER BY DS.RENGLON")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener la informacion para mostra en grid de detalle de productos en la solicitud
    ''' </summary>
    ''' <param name="idSolicitud"></param> identificador de solicitud
    ''' <param name="IDEstablecimiento"></param> identificador del establecimiento
    ''' <returns>
    ''' dataset filtrado
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDsGridDetalleSolicitud(ByVal idSolicitud As Int64, ByVal IDEstablecimiento As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_DETALLESOLICITUDES.IDSOLICITUD, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDESTABLECIMIENTO, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDESPECIFICACION, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDPRODUCTO, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.CANTIDAD, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDUNIDADMEDIDA, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.PRESUPUESTOUNITARIO,")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.PRESUPUESTOTOTAL, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.NUMEROENTREGAS, ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS.DESCRIPCION AS UNIDAD, vv_CATALOGOPRODUCTOS.IDGRUPO, vv_CATALOGOPRODUCTOS.IDSUBGRUPO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.IDSUMINISTRO, vv_CATALOGOPRODUCTOS.DESCLARGO, vv_CATALOGOPRODUCTOS.PRECIOACTUAL, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.IDNIVELUSO, vv_CATALOGOPRODUCTOS.CORRPRODUCTO, SAB_EST_DETALLESOLICITUDES.IDPRODUCTO,CANTIDAD, rank() OVER (ORDER BY vv_CATALOGOPRODUCTOS.CORRPRODUCTO) as RENGLON ")
        strSQL.Append("FROM SAB_EST_DETALLESOLICITUDES INNER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS ON SAB_EST_DETALLESOLICITUDES.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS ON SAB_EST_DETALLESOLICITUDES.IDPRODUCTO = vv_CATALOGOPRODUCTOS.IDPRODUCTO ")
        strSQL.Append("inner join SAB_EST_SOLICITUDES on SAB_EST_DETALLESOLICITUDES.IDSOLICITUD = SAB_EST_SOLICITUDES.IDSOLICITUD ")
        strSQL.Append("WHERE SAB_EST_SOLICITUDES.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND SAB_EST_SOLICITUDES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = idSolicitud
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDEstablecimiento

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDsGridDetalleSolicitud2(ByVal idSolicitud As Int64, ByVal IDEstablecimiento As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("row_number() over(ORDER BY SAB_EST_DETALLESOLICITUDES.RENGLON) ORDEN, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDSOLICITUD, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDESTABLECIMIENTO, ")
        'strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDDETALLE, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDPRODUCTO, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.CANTIDAD, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDUNIDADMEDIDA, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.PRESUPUESTOUNITARIO,")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.PRESUPUESTOTOTAL, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.NUMEROENTREGAS, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.RENGLON, ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS.DESCRIPCION AS UNIDAD, vv_CATALOGOPRODUCTOS.IDGRUPO, vv_CATALOGOPRODUCTOS.IDSUBGRUPO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.IDSUMINISTRO, vv_CATALOGOPRODUCTOS.DESCLARGO, vv_CATALOGOPRODUCTOS.PRECIOACTUAL, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.IDNIVELUSO, vv_CATALOGOPRODUCTOS.CORRPRODUCTO ")
        strSQL.Append("FROM SAB_EST_DETALLESOLICITUDES INNER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS ON SAB_EST_DETALLESOLICITUDES.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS ON SAB_EST_DETALLESOLICITUDES.IDPRODUCTO = vv_CATALOGOPRODUCTOS.IDPRODUCTO ")
        strSQL.Append("WHERE SAB_EST_DETALLESOLICITUDES.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND SAB_EST_DETALLESOLICITUDES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY SAB_EST_DETALLESOLICITUDES.RENGLON")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = idSolicitud
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDEstablecimiento

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtiene dataset de detalle de un producto por su codigo MSPAS
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <param name="IDCODIGOPRODUCTO"></param> codigo MSPAS del producto
    ''' <returns>
    ''' dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetPorCodigo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDCODIGOPRODUCTO As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT vv_CATALOGOPRODUCTOS.IDSUMINISTRO, vv_CATALOGOPRODUCTOS.CORRSUMINISTRO, vv_CATALOGOPRODUCTOS.DESCSUMINISTRO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.IDGRUPO, vv_CATALOGOPRODUCTOS.CORRGRUPO, vv_CATALOGOPRODUCTOS.DESCGRUPO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.IDSUBGRUPO, vv_CATALOGOPRODUCTOS.CORRSUBGRUPO, vv_CATALOGOPRODUCTOS.CORRPRODUCTO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.DESCSUBGRUPO, vv_CATALOGOPRODUCTOS.IDPRODUCTO, vv_CATALOGOPRODUCTOS.DESCLARGO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.NOMBRECORTO, vv_CATALOGOPRODUCTOS.IDNIVELUSO, vv_CATALOGOPRODUCTOS.DESCPRODUCTO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.PRECIOACTUAL, vv_CATALOGOPRODUCTOS.EXISTENCIAACTUAL, vv_CATALOGOPRODUCTOS.DESCRIPCION, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDESTABLECIMIENTO, SAB_EST_DETALLESOLICITUDES.IDSOLICITUD, SAB_EST_DETALLESOLICITUDES.IDDETALLE, ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES.IDPRODUCTO AS Expr1 ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS INNER JOIN ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES ON vv_CATALOGOPRODUCTOS.IDPRODUCTO = SAB_EST_DETALLESOLICITUDES.IDPRODUCTO ")
        strSQL.Append(" WHERE SAB_EST_DETALLESOLICITUDES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND SAB_EST_DETALLESOLICITUDES.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND vv_CATALOGOPRODUCTOS.CORRPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.VarChar)
        args(2).Value = IDCODIGOPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' valida si hay productos asociados a la solicitud
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLESOLICITUDES
    ''' <returns>
    ''' Verdadero si hay productos asociados
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarHayProductoAsociadoSolicitud(ByVal aEntidad As DETALLESOLICITUDES) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_EST_DETALLESOLICITUDES ")
        strSQL.Append("WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

#End Region

#Region "tabla productos solicitud"
    ''' <summary>
    ''' Contiene funciones y métodos para la manipulación y lectura de  información de los datos de los productos en la solicitud de compra
    ''' </summary>
    ''' <param name="idestablecimiento">Identificador del Establecimiento</param>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <returns>Lista de productos que contiene la solicitud en formato de dataset</returns>

    Public Function obtenerProductosSolicitud(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT")
        strSQL.Append("   PS.IDPRODUCTO, PS.IDENTREGA,PS.IDESPECIFICACION,CP.CORRPRODUCTO, CP.DESCLARGO, case when PS.PRECIOUNITARIO is null then CP.PRECIOACTUAL else PS.PRECIOUNITARIO end PRECIOACTUAL ,CP.UNIDADMEDIDA, E.NOMBREESPECIFICACION, PS.RENGLON, ISNULL(PS.CANTIDAD,0) AS CANTIDAD ")
        strSQL.Append(" FROM")
        strSQL.Append("   SAB_EST_PRODUCTOSSOLICITUD PS INNER JOIN vv_CATALOGOPRODUCTOS CP ON PS.IDPRODUCTO=CP.IDPRODUCTO LEFT OUTER JOIN SAB_CAT_ESPECIFICACIONES E ON E.IDESTABLECIMIENTO=PS.IDESTABLECIMIENTO AND E.IDPRODUCTO=PS.IDPRODUCTO AND E.IDESPECIFICACION=PS.IDESPECIFICACION ")
        strSQL.Append(" WHERE")
        strSQL.Append("   PS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")
        strSQL.Append("   AND PS.IDSOLICITUD = @IDSOLICITUD")
        strSQL.Append("   ORDER BY CP.CORRPRODUCTO ASC ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        Dim dS As New DataSet

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function


    Public Function obtenerProductos(ByVal IDTIPOUACI As Integer, ByVal idsolicitud As Integer, ByVal AREATECNICA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT ")
        strSQL.Append("   CP.IDPRODUCTO,CP.CORRPRODUCTO, CP.DESCLARGO, CP.PRECIOACTUAL,CP.UNIDADMEDIDA,CP.TIPOUACI,AREATECNICA ")
        strSQL.Append(" FROM ")
        strSQL.Append("   vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("   LEFT JOIN SAB_EST_PRODUCTOSSOLICITUD PS ON PS.IDPRODUCTO=CP.IDPRODUCTO  ")
        strSQL.Append(" WHERE")
        strSQL.Append("   (PS.IDSOLICITUD = @IDSOLICITUD  or @IDSOLICITUD=-1) ")
        strSQL.Append("   AND (CP.TIPOUACI=@TIPOUACI OR @TIPOUACI=-1) ")
        strSQL.Append("   AND (AREATECNICA=@AREATECNICA OR @AREATECNICA=-1) ")
        strSQL.Append("   ORDER BY CP.CORRPRODUCTO ASC ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@TIPOUACI", SqlDbType.Int)
        args(0).Value = IDTIPOUACI
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        args(2) = New SqlParameter("@AREATECNICA", SqlDbType.Int)
        args(2).Value = AREATECNICA

        Dim dS As New DataSet

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerProductosSolicitudConsolidar(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal iddependencia As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT")
        strSQL.Append("   PS.IDPRODUCTO, PS.IDENTREGA,PS.OBSERVACION,CP.CORRPRODUCTO, CP.DESCLARGO, CP.PRECIOACTUAL,CP.UNIDADMEDIDA, PS.CANTIDAD, PS.IDESPECIFICACION, PS.RENGLON  ")
        strSQL.Append(" FROM")
        strSQL.Append("   SAB_EST_PRODUCTOSSOLICITUD PS INNER JOIN vv_CATALOGOPRODUCTOS CP ON PS.IDPRODUCTO=CP.IDPRODUCTO")
        strSQL.Append(" WHERE")
        strSQL.Append("   PS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")
        strSQL.Append("   AND PS.IDSOLICITUD = @IDSOLICITUD AND PS.IDDEPENDENCIA=@IDDEPENDENCIA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        args(2) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(2).Value = iddependencia
        Dim dS As New DataSet

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function existeProductoSolicitud(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal IDPRODUCTO As Integer, ByVal IDESPECIFICACION As Integer) As Integer

        Dim strSQL As New Text.StringBuilder()

        strSQL.Append(" SELECT ")
        strSQL.Append("   ISNULL(PP.IDPRODUCTO, 0) ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_EST_PRODUCTOSSOLICITUD PP ")
        strSQL.Append(" WHERE PP.IDPRODUCTO = @IDPRODUCTO AND ")
        strSQL.Append("       PP.idestablecimiento = @idestablecimiento  AND PP.IDSOLICITUD=@IDSOLICITUD and pp.IDESPECIFICACION =@IDESPECIFICACION ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@idestablecimiento", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(2).Value = idsolicitud
        If Not IDESPECIFICACION = Nothing Then
            args(3) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
            args(3).Value = IDESPECIFICACION
        Else
            args(3) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
            args(3).Value = DBNull.Value

        End If
        
        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Método para adicionar registro de productos en la solicitud
    ''' </summary>
    ''' <param name="aEntidad">Entidad que representa la estructura de la tabla de productossolicitud</param>
    ''' <returns>Un entero con el resultado si la inserción se realizó de forma exitosa</returns>

    Public Function agregarProductoSolicitudes(ByVal aEntidad As PRODUCTOSSOLICITUD) As Integer

        Dim lEntidad As PRODUCTOSSOLICITUD
        lEntidad = aEntidad

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" DECLARE @RENGLON INT ")
        strSQL.Append(" SET @RENGLON= (SELECT ISNULL(MAX(RENGLON),0)+1 FROM SAB_EST_PRODUCTOSSOLICITUD WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDSOLICITUD=@IDSOLICITUD AND IDDEPENDENCIA=@IDDEPENDENCIA ) ")
        strSQL.Append(" INSERT INTO ")
        strSQL.Append("  SAB_EST_PRODUCTOSSOLICITUD(")
        strSQL.Append("  IDESTABLECIMIENTO,IDSOLICITUD, IDPRODUCTO, IDENTREGA, OBSERVACION,")
        strSQL.Append("  AUUSUARIOCREACION, AUFECHACREACION,IDDEPENDENCIA,CANTIDAD, RENGLON ")

        If lEntidad.IDESPECIFICACION <> 0 Then
            strSQL.Append("  ,IDESPECIFICACION ")
        End If

        strSQL.Append("  ) ")
        strSQL.Append("  VALUES(")
        strSQL.Append("  @IDESTABLECIMIENTO,@IDSOLICITUD, @IDPRODUCTO, @ENTREGA, @OBSERVACION, ")
        strSQL.Append("  @AUUSUARIOCREACION, @AUFECHACREACION,@IDDEPENDENCIA,@CANTIDAD, @RENGLON ")
        If lEntidad.IDESPECIFICACION <> 0 Then
            strSQL.Append("  ,@IDESPECIFICACION ")
        End If

        strSQL.Append("  ) ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@ENTREGA", SqlDbType.Int)
        args(2).Value = lEntidad.IDENTREGA
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Value = lEntidad.AUUSUARIOCREACION
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Value = lEntidad.AUFECHACREACION
        args(5) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(5).Value = lEntidad.IDSOLICITUD
        args(6) = New SqlParameter("@OBSERVACION", SqlDbType.Text)
        args(6).Value = lEntidad.OBSERVACION
        args(7) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(7).Value = lEntidad.IDDEPENDENCIA
        args(8) = New SqlParameter("@CANTIDAD", SqlDbType.Int)
        args(8).Value = lEntidad.CANTIDAD
        If lEntidad.IDESPECIFICACION <> 0 Then
            args(9) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
            args(9).Value = lEntidad.IDESPECIFICACION
        End If

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Método para actualizar los valores de la tabla de productos solicitud
    ''' </summary>
    ''' <param name="aEntidad">Entidad que representa la estructura de la tabla de productossolicitud</param>
    ''' <param name="tran">Variable que contiene la transacción</param>
    ''' <returns>Valor entero representado del resultado de la ejecución del metodo </returns>

    Public Function actualizarProductoSolicitud(ByVal aEntidad As PRODUCTOSSOLICITUD, ByVal tran As DistributedTransaction) As Integer

        Dim lEntidad As PRODUCTOSSOLICITUD
        Dim ret As Integer
        lEntidad = aEntidad

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_EST_PRODUCTOSSOLICITUD ")
        If aEntidad.CANTIDAD = 0 Then
            strSQL.Append("  SET IDENTREGA = @ENTREGAS, ")
        Else
            strSQL.Append("  SET CANTIDAD = @CANTIDAD, ")
        End If

        strSQL.Append("  AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION,PRECIOUNITARIO=@PRECIOUNITARIO ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDPRODUCTO = @IDPRODUCTO AND IDSOLICITUD=@IDSOLICITUD AND IDDEPENDENCIA=@IDDEPENDENCIA AND RENGLON=@RENGLON AND isnull(IDESPECIFICACION,0)=@IDESPECIFICACION; ")
      

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        If aEntidad.CANTIDAD = 0 Then
            args(2) = New SqlParameter("@ENTREGAS", SqlDbType.Int)
            args(2).Value = lEntidad.IDENTREGA
        Else
            args(2) = New SqlParameter("@CANTIDAD", SqlDbType.Int)
            args(2).Value = lEntidad.CANTIDAD
        End If

        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = lEntidad.AUUSUARIOMODIFICACION
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = lEntidad.AUFECHAMODIFICACION
        args(5) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(5).Value = lEntidad.IDSOLICITUD
        args(6) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(6).Value = lEntidad.IDDEPENDENCIA
        args(7) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(7).Value = lEntidad.RENGLON
        args(8) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Money)
        args(8).Value = lEntidad.PRECIOUNITARIO
        args(9) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(9).Value = lEntidad.IDESPECIFICACION
        strSQL.Append("; UPDATE  ")
        strSQL.Append(" SAB_EST_ALMACENESENTREGASOLICITUD ")
        strSQL.Append(" SET PRECIOUNITARIO=@PRECIOUNITARIO, AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND  IDSOLICITUD=@IDSOLICITUD   AND IDPRODUCTO=@IDPRODUCTO AND isnull(IDESPECIFICACION,0)=@IDESPECIFICACION;  ")
        strSQL.Append("; UPDATE  ")
        strSQL.Append(" SAB_EST_DETALLESOLICITUDES ")
        strSQL.Append(" SET PRESUPUESTOUNITARIO=@PRECIOUNITARIO,PRESUPUESTOTOTAL=@PRECIOUNITARIO*CANTIDAD, AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND  IDSOLICITUD=@IDSOLICITUD   AND IDPRODUCTO=@IDPRODUCTO AND isnull(IDESPECIFICACION,0)=@IDESPECIFICACION;  ")
        ret = SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)
        'strSQL = New Text.StringBuilder
        'strSQL.Append(" UPDATE  ")
        'strSQL.Append(" SAB_EST_ALMACENESENTREGASOLICITUD ")
        'strSQL.Append(" SET PRECIOUNITARIO=@PRECIOUNITARIO, AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        'strSQL.Append(" WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND  IDSOLICITUD=@IDSOLICITUD   AND IDPRODUCTO=@IDPRODUCTO;  ")
        'ret = SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)
        Return ret

    End Function
    Public Function actualizarProductoSolicitud2(ByVal aEntidad As PRODUCTOSSOLICITUD, ByVal tran As DistributedTransaction) As Integer

        Dim lEntidad As PRODUCTOSSOLICITUD
        lEntidad = aEntidad

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_EST_PRODUCTOSSOLICITUD ")
        strSQL.Append("  SET cantidad = @cantidad ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDPRODUCTO = @IDPRODUCTO AND IDSOLICITUD=@IDSOLICITUD AND RENGLON=@RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(2).Value = lEntidad.IDSOLICITUD
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = lEntidad.RENGLON
        args(4) = New SqlParameter("@CANTIDAD", SqlDbType.Int)
        args(4).Value = lEntidad.CANTIDAD

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function actualizarProductoSolicitud3(ByVal aEntidad As PRODUCTOSSOLICITUD, ByVal tran As DistributedTransaction) As Integer

        Dim lEntidad As PRODUCTOSSOLICITUD
        lEntidad = aEntidad

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_EST_PRODUCTOSSOLICITUD ")
        strSQL.Append("  SET IDESPECIFICACION = @IDESPECIFICACION ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDPRODUCTO = @IDPRODUCTO AND IDSOLICITUD=@IDSOLICITUD AND IDDEPENDENCIA=@IDDEPENDENCIA AND RENGLON=@RENGLON ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(2).Value = lEntidad.IDSOLICITUD
        args(3) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(3).Value = lEntidad.IDDEPENDENCIA
        args(4) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(4).Value = lEntidad.IDESPECIFICACION
        args(5) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(5).Value = lEntidad.RENGLON


        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function obtenerProductosSolicitud2(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        'strSQL.Append(" select  ")
        'strSQL.Append(" row_number() over (order by corrproducto) renglon,  ")
        'strSQL.Append(" ps.idproducto,corrproducto,case when ps.idespecificacion is null then desclargo else desclargo + ' (C/Especificación Técnica)' End as desclargo,unidadmedida,ps.identrega as entrega, ")
        ''strSQL.Append(" (select count(aes.renglon)  ")
        ''strSQL.Append(" from sab_est_almacenesentregasolicitud aes inner join sab_est_entregasolicitudes es on aes.idestablecimiento=es.idestablecimiento and aes.idsolicitud=es.idsolicitud and aes.renglon=es.renglon and aes.idproducto=es.idproducto and aes.identrega=es.identrega inner join sab_est_detallesolicitudes ds on ds.idestablecimiento=es.idestablecimiento and ds.idsolicitud=es.idsolicitud and ds.renglon=es.renglon and ds.idproducto=es.idproducto and ")
        ''strSQL.Append(" ds.idespecificacion=ps.idespecificacion and ")
        ''strSQL.Append(" ds.idproducto=ps.idproducto and ")
        ''strSQL.Append(" ds.idsolicitud=ps.idsolicitud and ")
        ''strSQL.Append(" ds.idestablecimiento = ps.idestablecimiento ")
        ''strSQL.Append(" where aes.idestablecimiento=ps.idestablecimiento and aes.idsolicitud=ps.idsolicitud ")
        ''strSQL.Append(" and aes.idproducto=ps.idproducto and (ds.idespecificacion=ps.idespecificacion)  ")
        'strSQL.Append(" 0 as capturado, ps.idespecificacion, vv.idunidadmedida, ps.renglon as identificadorproducto, isnull(ps.cantidad,0) as cantidad ,isnull(vv.precioactual,0.00) as precioactual,isnull(ps.cantidad*vv.precioactual,0.00) as montorenglon   ")
        'strSQL.Append(" from dbo.SAB_EST_PRODUCTOSSOLICITUD ps inner join dbo.vv_CATALOGOPRODUCTOS vv ")
        'strSQL.Append(" on vv.idproducto=ps.idproducto ")
        'strSQL.Append(" WHERE")
        'strSQL.Append("   PS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")
        'strSQL.Append("   AND PS.IDSOLICITUD = @IDSOLICITUD")
        'strSQL.Append(" order by corrproducto ")

        strSQL.Append(" select  ")
        strSQL.Append(" row_number() over (order by corrproducto) renglon,  ")
        strSQL.Append(" ps.idproducto,corrproducto,case when ps.idespecificacion is null then desclargo else desclargo + ' (C/Especificación Técnica)' End as desclargo,unidadmedida,ps.identrega as entrega, ")
        'strSQL.Append(" (select count(aes.renglon)  ")
        'strSQL.Append(" from sab_est_almacenesentregasolicitud aes inner join sab_est_entregasolicitudes es on aes.idestablecimiento=es.idestablecimiento and aes.idsolicitud=es.idsolicitud and aes.renglon=es.renglon and aes.idproducto=es.idproducto and aes.identrega=es.identrega inner join sab_est_detallesolicitudes ds on ds.idestablecimiento=es.idestablecimiento and ds.idsolicitud=es.idsolicitud and ds.renglon=es.renglon and ds.idproducto=es.idproducto and ")
        'strSQL.Append(" ds.idespecificacion=ps.idespecificacion and ")
        'strSQL.Append(" ds.idproducto=ps.idproducto and ")
        'strSQL.Append(" ds.idsolicitud=ps.idsolicitud and ")
        'strSQL.Append(" ds.idestablecimiento = ps.idestablecimiento ")
        'strSQL.Append(" where aes.idestablecimiento=ps.idestablecimiento and aes.idsolicitud=ps.idsolicitud ")
        'strSQL.Append(" and aes.idproducto=ps.idproducto and (ds.idespecificacion=ps.idespecificacion)  ")
        strSQL.Append(" 0 as capturado, ps.idespecificacion, vv.idunidadmedida, ps.renglon as identificadorproducto, isnull(ps.cantidad,0) as cantidad ,isnull(ps.preciounitario,0.00) as precioactual,isnull(ps.cantidad*ps.preciounitario,0.00) as montorenglon   ")
        strSQL.Append(" from dbo.SAB_EST_PRODUCTOSSOLICITUD ps inner join dbo.vv_CATALOGOPRODUCTOS vv ")
        strSQL.Append(" on vv.idproducto=ps.idproducto ")
        strSQL.Append(" WHERE")
        strSQL.Append("   PS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")
        strSQL.Append("   AND PS.IDSOLICITUD = @IDSOLICITUD")
        strSQL.Append(" order by corrproducto ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        Dim dS As New DataSet

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Método que valida la existencia de valores en la distribución de entregas de los productos en una solicitud
    ''' </summary>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="renglon">Identificador del renglon</param>
    ''' <param name="idproducto">Identificador del producto</param>
    ''' <returns>Un valor entero que representa el número de productos encontrados</returns>

    Public Function ExisteDistribucion(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal renglon As Integer, ByVal idproducto As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select ")
        strSQL.Append(" count(*) ")
        strSQL.Append(" from sab_est_almacenesentregasolicitud ")
        strSQL.Append(" where idestablecimiento= @IDESTABLECIMIENTO and idsolicitud= @IDSOLICITUD ")
        strSQL.Append(" and idproducto=@IDPRODUCTO and renglon=@RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = idproducto
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = renglon


        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Método que devuelve el listado de productos y su distribución de una solicitud de compra
    ''' </summary>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="renglon">Identificador del renglon</param>
    ''' <param name="idproducto">Identificador del producto</param>
    ''' <returns>Retorna un dataset</returns>

    Public Function obtenerProductosSolicitudDistribucion(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal renglon As Integer, ByVal idproducto As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        
        strSQL.Append(" select aes.idfuentefinanciamiento,aes.idalmacenentrega as idalmacen, gff.descripcion + '/' + ff.nombre as fuente,a.nombre as lugar, aes.idestablecimiento,aes.idsolicitud, aes.renglon, aes.idproducto, sum(aes.cantidad) as cantidad, case when ds.idespecificacion is null then 0 else ds.idespecificacion end as idespecificacion,preciounitario ")
        strSQL.Append(" from sab_est_almacenesentregasolicitud aes inner join ")
        strSQL.Append(" sab_cat_fuentefinanciamientos ff on aes.idfuentefinanciamiento=ff.idfuentefinanciamiento inner join sab_cat_gruposfuentefinanciamiento gff on gff.idgrupo=ff.idgrupo inner join sab_cat_almacenes a on a.idalmacen=aes.idalmacenentrega")
        strSQL.Append(" inner join sab_est_entregasolicitudes es on es.idestablecimiento=aes.idestablecimiento and es.idsolicitud=aes.idsolicitud and es.renglon=aes.renglon and es.idproducto=aes.idproducto and es.identrega=aes.identrega inner join sab_est_detallesolicitudes ds on ds.idestablecimiento = es.idestablecimiento and ds.idsolicitud=es.idsolicitud and ds.renglon=es.renglon and ds.idproducto=es.idproducto ")
        strSQL.Append(" WHERE")
        strSQL.Append("   aeS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")
        strSQL.Append("   AND aeS.IDSOLICITUD = @IDSOLICITUD")
        strSQL.Append("   AND aeS.RENGLON = @renglon AND aes.idproducto=@idproducto ")
        strSQL.Append("   GROUP BY aes.idfuentefinanciamiento,aes.idalmacenentrega,gff.descripcion,ff.nombre,a.nombre,aes.idestablecimiento,aes.idsolicitud, aes.renglon, aes.idproducto,ds.idespecificacion,preciounitario")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        args(2) = New SqlParameter("@renglon", SqlDbType.Int)
        args(2).Value = renglon
        args(3) = New SqlParameter("@idproducto", SqlDbType.Int)
        args(3).Value = idproducto

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo que inserta datos en el detalle de la solicitud
    ''' </summary>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="renglon">Identificador del renglon</param>
    ''' <param name="idproducto">Identificador del producto</param>
    ''' <param name="usuario">Identificador del usuario</param>
    ''' <returns>Un valor entero indicando si se actualizo correctamente</returns>

    Public Function InsertarDetallesSolicitudes(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal renglon As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer, ByVal usuario As String, ByVal identificadorproducto As Integer) As Integer
        Dim strSQL As New Text.StringBuilder

        strSQL.Append("sproc_IngresarDetallesSolicitudes")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = idestablecimiento
        args(2) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = idsolicitud
        args(3) = New SqlParameter("@renglon", SqlDbType.BigInt)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = renglon
        args(4) = New SqlParameter("@idproducto", SqlDbType.BigInt)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = idproducto
        args(5) = New SqlParameter("@idespecificacion", SqlDbType.BigInt)
        args(5).Direction = ParameterDirection.Input
        args(5).Value = idespecificacion
        args(6) = New SqlParameter("@USUARIOCREACION", SqlDbType.VarChar)
        args(6).Direction = ParameterDirection.Input
        args(6).Value = usuario
        args(7) = New SqlParameter("@identificadorproducto", SqlDbType.Int)
        args(7).Direction = ParameterDirection.Input
        args(7).Value = identificadorproducto

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function
    ''' <summary>
    ''' Metodo que borra el detalle de la solicitud
    ''' </summary>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idproducto">Identificador del producto</param>
    ''' <param name="tran">Variable que contiene la transacción</param>
    ''' <returns>Devuelve un entero indicando si se borro satisfactoriamente</returns>

    Public Function BorrarDetalleSolicitudes(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal IDDEPENDENCIA As Integer, ByVal IDESPECIFICACION As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" delete SAB_EST_PRODUCTOSSOLICITUD ")
        strSQL.Append(" where idestablecimiento= @IDESTABLECIMIENTO and idsolicitud= @IDSOLICITUD ")
        strSQL.Append(" and idproducto=@IDPRODUCTO and iddependencia=@iddependencia AND isnull(IDESPECIFICACION,0)=@IDESPECIFICACION ") ' and idespecificacion=@idespecificacion ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = idproducto
        args(3) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(3).Value = IDDEPENDENCIA

        args(4) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(4).Value = IDESPECIFICACION


        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo que actualiza la cantidad en la tabla productos solicitud
    ''' </summary>
    ''' <param name="cantidad">Identificador de la cantidad</param>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idproducto">Identificador del producto</param>
    ''' <param name="tran">Variable que contiene la transacción</param>
    ''' <returns>Valor entero que indica si se actualizo satisfactoriamente</returns>

    Public Function actualizarCantidadProductoSolicitud(ByVal cantidad As Integer, ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal IDPRODUCTO As Integer, ByVal idespecificacion As Integer) As Integer


        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_EST_PRODUCTOSSOLICITUD ")
        strSQL.Append("  SET CANTIDAD = @CANTIDAD ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDPRODUCTO = @IDPRODUCTO AND IDSOLICITUD=@IDSOLICITUD ")

        strSQL.Append("  AND isnull(IDESPECIFICACION,0)=@IDESPECIFICACION ")


        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@CANTIDAD", SqlDbType.Int)
        args(2).Value = cantidad
        args(3) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(3).Value = idsolicitud

        args(4) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(4).Value = idespecificacion



        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerSolicitudesAConsolidar(ByVal idclasesuministro As Integer, ByVal idestado As Integer) As DataSet
        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT S.IDSOLICITUD, S.CORRELATIVO,S.FECHASOLICITUD,S.MONTOSOLICITADO, S.EMPLEADOSOLICITANTE AS RESPONSABLE, ")
        strSQL.Append(" CASE WHEN S.COMPRACONJUNTA=0 THEN 'INDIVIDUAL' ELSE 'CONJUNTA' END AS TIPOSOLICITUD, CASE WHEN IDESTADO=1 THEN 'GRABADA' WHEN IDESTADO=2 THEN 'ENVIADA U.T.' END AS IDESTADO, D.NOMBRE AS DEPENDENCIA, SU.DESCRIPCION AS SUMINISTRO, PS.IDDEPENDENCIA ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES S INNER JOIN SAB_EST_PRODUCTOSSOLICITUD PS ON  ")
        strSQL.Append(" S.IDESTABLECIMIENTO=PS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" S.IDSOLICITUD=PS.IDSOLICITUD  ")
        strSQL.Append(" INNER JOIN SAB_CAT_DEPENDENCIAS D ON ")
        strSQL.Append(" D.IDDEPENDENCIA=S.IDDEPENDENCIASOLICITANTE  ")
        strSQL.Append(" INNER JOIN SAB_CAT_SUMINISTROS SU ON SU.IDSUMINISTRO=S.IDCLASESUMINISTRO ")
        'strSQL.Append(" INNER JOIN SAB_CAT_SUMINISTROSDEPENDENCIAS SE ON ")
        'strSQL.Append(" SE.IDSUMINISTRO=S.IDCLASESUMINISTRO AND SE.IDDEPENDENCIA=
        strSQL.Append(" WHERE IDESTADO=@IDESTADO  ")
        strSQL.Append(" AND IDCLASESUMINISTRO=@IDCLASESUMINISTRO AND S.COMPRACONJUNTA=1 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@idclasesuministro", SqlDbType.Int)
        args(0).Value = idclasesuministro
        args(1) = New SqlParameter("@idestado", SqlDbType.Int)
        args(1).Value = idestado

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)


    End Function

    Public Function ExisteProductosolicitud2(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal IDESPECIFICACION As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select count(idproducto) ")
        strSQL.Append(" from sab_est_productossolicitud  ")
        strSQL.Append(" where idestablecimiento=@IDESTABLECIMIENTO ")
        strSQL.Append(" and idsolicitud =@IDSOLICITUD ")
        strSQL.Append(" and idproducto=@IDPRODUCTO ")
        strSQL.Append(" and (idespecificacion=@IDESPECIFICACION OR @idespecificacion=0) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = idproducto
        args(3) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(3).Value = IDESPECIFICACION

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function agregarESPECIFICACION(ByVal aEntidad As ESPECIFICACION) As Integer

        Dim lEntidad As ESPECIFICACION
        lEntidad = aEntidad
        Dim strSQL As New Text.StringBuilder
        'If lEntidad.IDESPECIFICACION <> "" Then

        '    strSQL.Append("UPDATE  ")
        '    strSQL.Append("  SAB_CAT_ESPECIFICACIONES ")
        '    strSQL.Append("  SET ESPECIFICACION = @ESPECIFICACION")
        '    strSQL.Append("  WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDPRODUCTO=@IDPRODUCTO AND IDESPECIFICACION=@IDESPECIFICACION ")

        'Else

        strSQL.Append(" DECLARE @IDESPECIFICACION INT ")
        strSQL.Append(" SET @IDESPECIFICACION =  (SELECT ISNULL(MAX(IDESPECIFICACION),0)+1 FROM SAB_CAT_ESPECIFICACIONES WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDPRODUCTO=@IDPRODUCTO )")
        strSQL.Append(" INSERT INTO ")
        strSQL.Append("  SAB_CAT_ESPECIFICACIONES(")
        strSQL.Append("  IDESTABLECIMIENTO,IDPRODUCTO, IDESPECIFICACION, ESPECIFICACION, NOMBREESPECIFICACION ")
        strSQL.Append("  ) ")
        strSQL.Append("  VALUES(")
        strSQL.Append("  @IDESTABLECIMIENTO, @IDPRODUCTO, @IDESPECIFICACION, @ESPECIFICACION, @NOMBREESPECIFICACION")
        strSQL.Append("  ) ")
        ' End If



        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        'args(2) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        'args(2).Value = lEntidad.IDESPECIFICACION
        args(2) = New SqlParameter("@ESPECIFICACION", SqlDbType.VarChar)
        args(2).Value = lEntidad.ESPECIFICACION
        args(3) = New SqlParameter("@NOMBREESPECIFICACION", SqlDbType.VarChar)
        args(3).Value = lEntidad.NOMBREESPECIFICACION

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)



    End Function

    Public Function eliminarESPECIFICACION(ByVal aEntidad As ESPECIFICACION) As Integer

        Dim lEntidad As ESPECIFICACION
        lEntidad = aEntidad
        Dim strSQL As New Text.StringBuilder
        'If lEntidad.IDESPECIFICACION <> "" Then

        '    strSQL.Append("UPDATE  ")
        '    strSQL.Append("  SAB_CAT_ESPECIFICACIONES ")
        '    strSQL.Append("  SET ESPECIFICACION = @ESPECIFICACION")
        '    strSQL.Append("  WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDPRODUCTO=@IDPRODUCTO AND IDESPECIFICACION=@IDESPECIFICACION ")

        'Else

        strSQL.Append(" delete from ")
        strSQL.Append("  SAB_CAT_ESPECIFICACIONES(")
        strSQL.Append("  where IDESTABLECIMIENTO=@IDESTABLECIMIENTO and IDPRODUCTO=@IDPRODUCTO and IDESPECIFICACION=@ESPECIFICACION ")
        
        ' End If



        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(2).Value = lEntidad.IDESPECIFICACION
        

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)



    End Function
    Public Function agregarESPECIFICACIONESSOLICITUDES(ByVal aEntidad As ESPECIFICACIONESSOLICITUDES) As Integer

        Dim lEntidad As ESPECIFICACIONESSOLICITUDES
        lEntidad = aEntidad
        Dim strSQL As New Text.StringBuilder


        strSQL.Append(" INSERT INTO ")
        strSQL.Append("  SAB_EST_ESPECIFICACIONESSOLICITUDES(")
        strSQL.Append("  IDESTABLECIMIENTO,IDPRODUCTO, IDESPECIFICACION, ESPECIFICACION, NOMBREESPECIFICACION,PRECIO,IDSOLICITUD ")
        strSQL.Append("  ) ")
        strSQL.Append("  VALUES(")
        strSQL.Append("  @IDESTABLECIMIENTO, @IDPRODUCTO, @IDESPECIFICACION, @ESPECIFICACION, @NOMBREESPECIFICACION,@PRECIO,@IDSOLICITUD")
        strSQL.Append("  ) ")




        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(2).Value = lEntidad.IDESPECIFICACION
        args(3) = New SqlParameter("@ESPECIFICACION", SqlDbType.VarChar)
        args(3).Value = lEntidad.ESPECIFICACION
        args(4) = New SqlParameter("@NOMBREESPECIFICACION", SqlDbType.VarChar)
        args(4).Value = lEntidad.NOMBREESPECIFICACION
        args(5) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(5).Value = lEntidad.PRECIO
        args(6) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(6).Value = lEntidad.IDSOLICITUD

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)



    End Function
    Public Function ObtenerEspecificacion(ByVal idestablecimiento As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer) As DataSet
        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDESPECIFICACION, NOMBREESPECIFICACION, ESPECIFICACION, IDPRODUCTO, IDESTABLECIMIENTO, ISNULL(PRECIO,0.00) AS PRECIO, ISNULL(FECHAACTUALIZACION,'') AS FECHAACTUALIZACION ")
        strSQL.Append(" FROM SAB_CAT_ESPECIFICACIONES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTO  AND IDPRODUCTO=@IDPRODUCTO ")
        If idespecificacion <> 0 Then
            strSQL.Append(" AND IDESPECIFICACION=@IDESPECIFICACION ")
        End If

        strSQL.Append(" UNION ")
        strSQL.Append(" SELECT top 1 0,'Sin Especificaciones Técnicas','',IDPRODUCTO,IDESTABLECIMIENTO,ISNULL(PRECIO,0.00) AS PRECIO, ISNULL(FECHAACTUALIZACION,'') AS FECHAACTUALIZACION ")
        strSQL.Append(" FROM SAB_CAT_ESPECIFICACIONES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTO  AND IDPRODUCTO=@IDPRODUCTO ")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = idproducto
        args(2) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(2).Value = idespecificacion

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)


    End Function
    Public Function ExisteEspecificacion(ByVal idestablecimiento As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select ")
        strSQL.Append(" count(*) ")
        strSQL.Append(" from sab_cat_especificaciones ")
        strSQL.Append(" where idestablecimiento= @IDESTABLECIMIENTO and idproducto= @IDPRODUCTO ")
        strSQL.Append(" and idESPECIFICACION=@IDESPECIFICACION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(1).Value = idespecificacion
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = idproducto
   

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function obtenerUnProductosSolicitud(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append("  ISNULL(CANTIDAD,0) AS CANTIDAD, RENGLON ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_EST_PRODUCTOSSOLICITUD ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("   AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("   AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("   AND (IDESPECIFICACION = @IDESPECIFICACION OR @IDESPECIFICACION=0) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = idproducto
        args(3) = New SqlParameter("@idespecificacion", SqlDbType.Int)
        args(3).Value = idespecificacion

        Dim dS As New DataSet

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
    End Function
    Public Function BuscarEspecificacionTecnica(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append("  count(idproducto) ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_EST_ESPECIFICACIONESSOLICITUDES ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("   AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("   AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("   AND IDESPECIFICACION = @IDESPECIFICACION ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = idproducto
        args(3) = New SqlParameter("@idespecificacion", SqlDbType.Int)
        args(3).Value = idespecificacion

        Dim dS As New DataSet

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
    End Function
#End Region
End Class
