Partial Public Class dbCONSUMOS

#Region " Metodos Creados"

    '''' <summary>
    '''' Se obtiene el mes de consumo
    '''' </summary>
    '''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    '''' <param name="ANIO"></param> 'anio de consumo
    '''' <returns>
    '''' devuelve el numero que corresponde al mes del consumo
    '''' </returns>
    '''' <remarks>
    ''''  <list type="bullet">
    '''' <item><description>SAB_EST_CONSUMOS</description></item>
    '''' </list> 
    '''' </remarks>
    '''' <history>
    ''''     [Autor: Yessenia Henriquez]      Creado
    '''' </history> 
    'Public Function ObtenerMes(ByVal IDESTABLECIMIENTO As Int32, ByVal ANIO As Int32) As Integer

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("SELECT isnull(max(MESCONSUMO),0) + 1 ")
    '    strSQL.Append(" FROM SAB_EST_CONSUMOS ")
    '    strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL.Append(" AND ANIOCONSUMO = @ANIO ")

    '    Dim args(1) As SqlParameter
    '    args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(0).Value = IDESTABLECIMIENTO
    '    args(1) = New SqlParameter("@ANIO", SqlDbType.Int)
    '    args(1).Value = ANIO

    '    Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    'End Function

    '''' <summary>
    '''' En esta función se obtiene el listado de consumos filtrando por mes o año de consumo
    '''' </summary>
    '''' <param name="BfiltroAño"></param> 'año consumo
    '''' <param name="Bfiltromes"></param> 'mes consumo
    '''' <param name="BEstablecimiento"></param>
    '''' <returns>
    '''' lista de consumos filtrada
    '''' </returns>
    '''' <remarks>
    ''''  <list type="bullet">
    '''' <item><description>SAB_EST_CONSUMOS</description></item>
    '''' </list>
    '''' </remarks>
    ''''  <history>
    ''''     [Autor: Yessenia Henriquez]      Creado
    '''' </history> 
    'Public Function Filtrar(ByVal FILTROAÑO As String, ByVal FILTROMES As String, ByVal IDESTABLECIMIENTO As Int32) As listaCONSUMOS

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
    '    strSQL.Append(" IDCONSUMO, ")
    '    strSQL.Append(" FECHAINGRESO, ")
    '    strSQL.Append(" MESCONSUMO, ")
    '    strSQL.Append(" ANIOCONSUMO, ")
    '    strSQL.Append(" DIACONSUMO, ")
    '    strSQL.Append(" IDEMPLEADO, ")
    '    strSQL.Append(" IDESTADO, ")
    '    strSQL.Append(" AUUSUARIOCREACION, ")
    '    strSQL.Append(" AUFECHACREACION, ")
    '    strSQL.Append(" AUUSUARIOMODIFICACION, ")
    '    strSQL.Append(" AUFECHAMODIFICACION, ")
    '    strSQL.Append(" ESTASINCRONIZADA ")
    '    strSQL.Append(" FROM SAB_EST_CONSUMOS ")
    '    strSQL.Append(" WHERE MESCONSUMO = @FILTROMES")
    '    strSQL.Append(" AND ANIOCONSUMO = @FILTROANIO ")
    '    strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL.Append(" AND IDESTADO > 1 ")

    '    Dim args(2) As SqlParameter
    '    args(0) = New SqlParameter("@FILTROANIO", SqlDbType.VarChar)
    '    args(0).Value = FILTROAÑO
    '    args(1) = New SqlParameter("@FILTROMES", SqlDbType.Int)
    '    args(1).Value = FILTROMES
    '    args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(2).Value = IDESTABLECIMIENTO

    '    Dim dr As SqlDataReader
    '    dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    '    Dim lista As New listaCONSUMOS

    '    Try
    '        If dr.HasRows Then
    '            Do While dr.Read()
    '                Dim mEntidad As New CONSUMOS
    '                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
    '                mEntidad.IDCONSUMO = IIf(dr("IDCONSUMO") Is DBNull.Value, Nothing, dr("IDCONSUMO"))
    '                mEntidad.FECHAINGRESO = IIf(dr("FECHAINGRESO") Is DBNull.Value, Nothing, dr("FECHAINGRESO"))
    '                mEntidad.MESCONSUMO = IIf(dr("MESCONSUMO") Is DBNull.Value, Nothing, dr("MESCONSUMO"))
    '                mEntidad.ANIOCONSUMO = IIf(dr("ANIOCONSUMO") Is DBNull.Value, Nothing, dr("ANIOCONSUMO"))
    '                mEntidad.DIACONSUMO = IIf(dr("DIACONSUMO") Is DBNull.Value, Nothing, dr("DIACONSUMO"))
    '                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
    '                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
    '                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
    '                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
    '                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
    '                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
    '                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
    '                lista.Add(mEntidad)
    '            Loop
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        dr.Close()
    '    End Try

    '    Return lista

    'End Function

    '''' <summary>
    '''' En esta función para dataset con la informacion de un consumo en especifico
    '''' </summary>
    '''' <param name="idConsumo"></param> 'identiicdor del consumo
    '''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    '''' <returns>
    '''' Dataset con la informacion del consumo
    '''' </returns>
    '''' <remarks>
    '''' <list type="bullet">
    '''' <item><description>SAB_EST_CONSUMOS</description></item>
    '''' <item><description>SAB_EST_DETALLECONSUMOS</description></item>
    '''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    '''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    '''' <item><description>SAB_CAT_CARGOS</description></item>
    '''' <item><description>SAB_CAT_CATALOGOPRODUCTOS</description></item>
    '''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    '''' </list>
    '''' </remarks>
    '''' <history>
    ''''     [Autor: Yessenia Henriquez]      Creado
    '''' </history> 
    'Public Function DataSetConsumo(ByVal IDCONSUMO As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("SELECT SAB_EST_CONSUMOS.IDCONSUMO, SAB_EST_CONSUMOS.FECHAINGRESO, SAB_EST_CONSUMOS.MESCONSUMO, SAB_EST_CONSUMOS.ANIOCONSUMO, ")
    '    strSQL.Append("SAB_EST_CONSUMOS.DIACONSUMO, SAB_CAT_UNIDADMEDIDAS.DESCRIPCION AS UNIDAD, SAB_CAT_EMPLEADOS.NOMBRE, SAB_CAT_EMPLEADOS.APELLIDO, ")
    '    strSQL.Append("SAB_CAT_CARGOS.DESCRIPCION AS CARGO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE AS PRODUCTO, ")
    '    strSQL.Append("SAB_CAT_ESTABLECIMIENTOS.NOMBRE AS ESTABLECIMIENTO, SAB_CAT_ESTABLECIMIENTOS.NIVEL, SAB_EST_DETALLECONSUMOS.IDPRODUCTO, ")
    '    strSQL.Append("SAB_EST_DETALLECONSUMOS.CANTIDADCONSUMIDA, SAB_EST_DETALLECONSUMOS.DEMANDAINSATISFECHA, SAB_EST_DETALLECONSUMOS.EXISTENCIAACTUAL, ")
    '    strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.CONCENTRACION, SAB_CAT_CATALOGOPRODUCTOS.FORMAFARMACEUTICA, SAB_CAT_CATALOGOPRODUCTOS.PRESENTACION, ")
    '    strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.CODIGO ")
    '    strSQL.Append("FROM SAB_EST_CONSUMOS INNER JOIN ")
    '    strSQL.Append("SAB_EST_DETALLECONSUMOS ON SAB_EST_CONSUMOS.IDCONSUMO = SAB_EST_DETALLECONSUMOS.IDCONSUMO AND ")
    '    strSQL.Append("SAB_EST_CONSUMOS.IDESTABLECIMIENTO = SAB_EST_DETALLECONSUMOS.IDESTABLECIMIENTO INNER JOIN ")
    '    strSQL.Append("SAB_CAT_ESTABLECIMIENTOS ON SAB_EST_CONSUMOS.IDESTABLECIMIENTO = SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO INNER JOIN ")
    '    strSQL.Append("SAB_CAT_EMPLEADOS ON SAB_EST_CONSUMOS.IDEMPLEADO = SAB_CAT_EMPLEADOS.IDEMPLEADO INNER JOIN ")
    '    strSQL.Append("SAB_CAT_CARGOS ON SAB_CAT_EMPLEADOS.IDCARGO = SAB_CAT_CARGOS.IDCARGO INNER JOIN ")
    '    strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS ON SAB_EST_DETALLECONSUMOS.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
    '    strSQL.Append("SAB_CAT_UNIDADMEDIDAS ON SAB_EST_DETALLECONSUMOS.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA ")
    '    strSQL.Append("WHERE SAB_EST_CONSUMOS.IDCONSUMO = @IDCONSUMO ")
    '    strSQL.Append("AND SAB_EST_CONSUMOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")

    '    Dim args(1) As SqlParameter
    '    args(0) = New SqlParameter("@IDCONSUMO", SqlDbType.Int)
    '    args(0).Value = IDCONSUMO
    '    args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(1).Value = IDESTABLECIMIENTO

    '    Dim ds As DataSet
    '    ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    '    Return ds

    'End Function

    '''' <summary>
    '''' Funcion para obtener el año de consumo 
    '''' </summary>
    '''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    '''' <returns>
    '''' El numero entero que representa el año de consumo
    '''' </returns>
    '''' <remarks>
    '''' <list type="bullet">
    '''' <item><description>SAB_EST_CONSUMOS</description></item>
    '''' </list>
    '''' </remarks>
    ''''  <history>
    ''''     [Autor: Yessenia Henriquez]      Creado
    '''' </history> 
    'Public Function ObtenerAño(ByVal IDESTABLECIMIENTO As Int32) As Integer
    '    Dim year As Integer
    '    year = DateTime.Now.Year

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("SELECT isnull(max(ANIOCONSUMO),yyyy) ")
    '    strSQL.Append("FROM SAB_EST_CONSUMOS ")
    '    strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL.Replace("yyyy", year)

    '    Dim args(0) As SqlParameter
    '    args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(0).Value = IDESTABLECIMIENTO

    '    Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    'End Function

    '''' <summary>
    '''' Funcion para obtener dia de consumo
    '''' </summary>
    '''' <param name="IDESTABLECIMIENTO"></param> 'identificador del etablecimiento
    '''' <param name="MES"></param> 'numero que identifica al mes de consumo
    '''' <returns>
    '''' numero entero que identifica el dia de consumo
    '''' </returns>
    '''' <remarks>
    '''' <list type="bullet">
    '''' <item><description>SAB_EST_CONSUMOS</description></item>
    '''' </list>
    '''' </remarks>
    '''' <history>
    ''''     [Autor: Yessenia Henriquez]      Creado
    '''' </history> 
    'Public Function ObtenerDia(ByVal IDESTABLECIMIENTO As Int32, ByVal MES As Int32) As Integer

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("SELECT isnull(max(DIACONSUMO),0) + 1 ")
    '    strSQL.Append("FROM SAB_EST_CONSUMOS ")
    '    strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL.Append(" AND MESCONSUMO = @MES ")

    '    Dim args(1) As SqlParameter
    '    args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(0).Value = IDESTABLECIMIENTO
    '    args(1) = New SqlParameter("@MES", SqlDbType.Int)
    '    args(1).Value = MES

    '    Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    'End Function

    '''' <summary>
    '''' Funcion para verificar existencia de consumo en los establecimientos
    '''' </summary>
    '''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    '''' <returns>
    '''' valor verdadero si existe
    '''' </returns>
    '''' <remarks>
    '''' <list type="bullet">
    '''' <item><description>SAB_EST_CONSUMOS</description></item>
    '''' </list>
    '''' </remarks>
    ''''  <history>
    ''''     [Autor: Yessenia Henriquez]      Creado
    '''' </history> 
    'Public Function ExistenConsumosEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As Boolean

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("SELECT count(*) ")
    '    strSQL.Append("FROM SAB_EST_CONSUMOS ")
    '    strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

    '    Dim args(0) As SqlParameter
    '    args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(0).Value = IDESTABLECIMIENTO

    '    If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

    '    Return True
    'End Function

    '''' <summary>
    '''' Obtener cual es el primer consumo en estado de grabado que no ha sido enviado
    '''' </summary>
    '''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    '''' <returns>
    '''' el identificador del primer consumo sin enviar
    '''' </returns>
    '''' <remarks>
    '''' <list type="bullet">
    '''' <item><description>SAB_EST_CONSUMOS</description></item>
    '''' </list>
    '''' </remarks>
    '''' <history>
    ''''     [Autor: Yessenia Henriquez]      Creado
    '''' </history> 

    'Public Function ObtenerPrimerConsumoSinEnviar(ByVal IDESTABLECIMIENTO As Int32) As String

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("SELECT (MIN (IDCONSUMO)) ")
    '    strSQL.Append("FROM SAB_EST_CONSUMOS ")
    '    strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL.Append("AND IDESTADO = 1 ") 'grabado

    '    Dim args(0) As SqlParameter
    '    args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(0).Value = IDESTABLECIMIENTO

    '    Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    'End Function

#End Region

End Class
