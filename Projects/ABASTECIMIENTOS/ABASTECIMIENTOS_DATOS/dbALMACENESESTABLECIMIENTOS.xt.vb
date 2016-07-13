Partial Public Class dbALMACENESESTABLECIMIENTOS

#Region " METODOS AGREGADOS "

    Public Function ObtenerAlmacenXEstablecimiento(ByVal IDALMACEN As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT AE.IDESTABLECIMIENTO, ")
        strSQL.Append("AE.IDALMACEN, ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("AE.ESPRINCIPAL ")
        strSQL.Append("FROM SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON AE.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("WHERE AE.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND AE.ESPRINCIPAL = 1 ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene un listado de todos aquellos almacenes asociados a un establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    '''  devuelve un dataset con la informacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerTodosAlmacenEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal ESFARMACIA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("AE.IDESTABLECIMIENTO, ")
        strSQL.Append("AE.IDALMACEN, ")
        strSQL.Append("A.NOMBRE ")
        strSQL.Append("FROM SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON AE.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("WHERE (AE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND A.ESFARMACIA = @ESFARMACIA ")
        strSQL.Append("ORDER BY A.NOMBRE ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@ESFARMACIA", SqlDbType.Int)
        args(1).Value = ESFARMACIA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene un listado de todos aquellas farmacias asociadas a un establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    '''  devuelve un dataset con la informacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerTodosFarmaciasEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("AE.IDESTABLECIMIENTO, ")
        strSQL.Append("AE.IDALMACEN, ")
        strSQL.Append("A.NOMBRE ")
        strSQL.Append("FROM SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON AE.IDALMACEN = SAB_CAT_ALMACENES.IDALMACEN ")
        strSQL.Append("WHERE AE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND A.ESFARMACIA = 1 ")
        strSQL.Append("ORDER BY A.NOMBRE ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetListaAlmacenesEstablecimientos() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("AE.IDESTABLECIMIENTO, ")
        strSQL.Append("AE.IDALMACEN, ")
        strSQL.Append("ES.NOMBRE ESTABLECIMIENTO, ")
        strSQL.Append("AE.ESPRINCIPAL, ")
        strSQL.Append("A.NOMBRE ALMACEN, ")
        strSQL.Append("AE.AUUSUARIOCREACION, ")
        strSQL.Append("AE.AUFECHACREACION, ")
        strSQL.Append("AE.AUUSUARIOMODIFICACION, ")
        strSQL.Append("AE.AUFECHAMODIFICACION, ")
        strSQL.Append("AE.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS ES ")
        strSQL.Append("ON AE.IDESTABLECIMIENTO = ES.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON AE.IDALMACEN = A.IDALMACEN ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function BuscarEstablecimientoAlmacen(ByVal IDESTABLECIMIENTO As Int32, ByVal IDALMACEN As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_ALMACENESESTABLECIMIENTOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDALMACEN = @IDALMACEN ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = IDALMACEN

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    Public Function BuscarAlmacen(ByVal IDESTABLECIMIENTO As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDALMACEN ")
        strSQL.Append(" FROM SAB_CAT_ALMACENESESTABLECIMIENTOS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function BuscarAlmacenFarmacia(ByVal IDESTABLECIMIENTO As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ae.IDALMACEN ")
        strSQL.Append(" FROM SAB_CAT_ALMACENESESTABLECIMIENTOS AE inner join SAB_CAT_ALMACENES A on a.idalmacen=ae.idalmacen ")
        strSQL.Append(" WHERE (ae.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) and (a.esfarmacia=1)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function BuscarEstablecimientoAlmacenPrincipal(ByVal IDALMACEN As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT AE.IDESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES AS A ")
        strSQL.Append("ON AE.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("WHERE AE.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND AE.ESPRINCIPAL = 1 ")
        strSQL.Append("AND A.ESFARMACIA <> 1 ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve un listado de los almacenes de un establecimiento.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento(Filtro).</param>
    ''' <returns>Dataset con el listado de almacenes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' </list>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  09/12/2006    Creado
    ''' </history>  
    ''' </remarks>
    Public Function ObtenerAlmacenesPrincipales(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("AE.IDESTABLECIMIENTO, ")
        strSQL.Append("AE.IDALMACEN, ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("A.DIRECCION ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_ALMACENESESTABLECIMIENTOS AS AE ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ALMACENES AS A ")
        strSQL.Append("ON AE.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("WHERE (AE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (A.ESFARMACIA <> 1) ")
        strSQL.Append("ORDER BY AE.ESPRINCIPAL DESC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
