Partial Public Class dbOBSERVACIONDETALLENECESIDAD

#Region "metodos agregados"
    ''' <summary>
    ''' Obtiene un listado de Observaciones hechas el programa de compras.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el establecimiento para filtrar la información.</param>
    ''' <param name="IDNECESIDAD">Especifica la necesidad para filtrar la información</param>
    ''' <param name="IDPRODUCTO">Especifica el producto para filtrar la información.</param>
    ''' <returns>Dataset con el listado de observaciones.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_ASESORIAPREDEFINIDA</description></item>
    ''' <item><description>SAB_UTMIM_OBSERVACIONDETALLENECESIDAD</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ObtenerListadeObservaciones(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("ODN.*, ")
        strSQL.Append("AP.DESCRIPCION ")
        strSQL.Append("FROM SAB_CAT_ASESORIAPREDEFINIDA AP ")
        strSQL.Append("INNER JOIN SAB_UTMIM_OBSERVACIONDETALLENECESIDAD ODN ")
        strSQL.Append("ON AP.IDASESORIA = ODN.IDASESORIA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Verifica la existencia de observaciones para la necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> identificador de la necesidad
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UTMIM_OBSERVACIONDETALLENECESIDAD</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ExistenObservacionesNecesidad(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_UTMIM_OBSERVACIONDETALLENECESIDAD ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Verifica si tienen existencia los productos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> identificador de necesidad
    ''' <param name="IDPRODUCTO"></param> identificador de producto
    ''' <returns>
    ''' verdadero si existen observaciones en producto
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UTMIM_OBSERVACIONDETALLENECESIDAD</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ExistenObservacionesProducto(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int32, ByVal IDPRODUCTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_UTMIM_OBSERVACIONDETALLENECESIDAD ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Dataset con la informacion de las observaciones de l anecesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDNECESIDAD"></param> identificador de la necesidad
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UTMIM_OBSERVACIONDETALLENECESIDAD</description></item>
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ASESORIAPREDEFINIDA</description></item>
    ''' </list>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function dstObservacionesNecesidades(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, Optional ByVal IDPRODUCTO As Int64 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT dn.IDESTABLECIMIENTO, dn.IDPRODUCTO, dn.IDNECESIDAD, dn.IDUNIDADMEDIDA, dn.CONSUMOANUAL, dn.RESERVAESTABLECIMIENTO, ")
        strSQL.Append("dn.DEMANDAINSATISFECHA, dn.RESERVATOTAL, dn.EXISTENCIAESTIMADA, dn.NECESIDADREAL, dn.PRECIOUNITARIO, dn.NECESIDADAJUSTADA, ")
        strSQL.Append("dn.NECESIDADFINAL, dn.COSTOTOTALAJUSTADO, dn.COSTOTOTALREAL, odn.OBSERVACION, odn.IDOBSERVACION, odn.FECHA, ")
        strSQL.Append("odn.CANTIDADACTUAL, ad.DESCRIPCION, vvc.CORRPRODUCTO, vvc.DESCLARGO, vvc.DESCRIPCION AS UNIDADMEDIDA ")
        strSQL.Append("FROM SAB_UTMIM_OBSERVACIONDETALLENECESIDAD AS odn INNER JOIN ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS AS dn ON odn.IDNECESIDAD = dn.IDNECESIDAD AND odn.IDPRODUCTO = dn.IDPRODUCTO AND ")
        strSQL.Append("odn.IDESTABLECIMIENTO = dn.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_ASESORIAPREDEFINIDA AS ad ON odn.IDASESORIA = ad.IDASESORIA INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS vvc ON odn.IDPRODUCTO = vvc.IDPRODUCTO ")
        strSQL.Append("WHERE dn.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND dn.IDNECESIDAD = @IDNECESIDAD ")
        If IDPRODUCTO <> 0 Then strSQL.Append("AND dn.IDPRODUCTO = @IDPRODUCTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
