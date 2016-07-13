Partial Public Class dbSUMINISTROS

    Public Function ObtenerListaPorID2() As listaSUMINISTROS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDTIPOSUMINISTRO = 1 ")

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaSUMINISTROS

        Try
            Do While dr.Read()
                Dim mEntidad As New SUMINISTROS
                mEntidad.IDSUMINISTRO = IIf(dr("IDSUMINISTRO") Is DBNull.Value, Nothing, dr("IDSUMINISTRO"))
                mEntidad.IDTIPOSUMINISTRO = IIf(dr("IDTIPOSUMINISTRO") Is DBNull.Value, Nothing, dr("IDTIPOSUMINISTRO"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
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
    ''' Obtiene el listado de suministros filtrado por el tipo de suministro.
    ''' </summary>
    ''' <param name="IDTIPO">Identificador del tipo de suministro</param>
    ''' <returns>Una lista con los suministros.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  21/12/2006    Creado
    ''' </history> 
    Public Function ObtenerListaPorIDtipo(ByVal IDTIPOSUMINISTRO As Int32, ByVal NM As Integer) As listaSUMINISTROS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)

        If NM = 0 Then
            strSQL.Append("WHERE IDTIPOSUMINISTRO = @IDTIPO ")
        Else
            strSQL.Append("WHERE IDTIPOSUMINISTRO <> @IDTIPO ")
        End If

        strSQL.Append("ORDER BY CORRELATIVO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPO", SqlDbType.Int)
        args(0).Value = IDTIPOSUMINISTRO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaSUMINISTROS

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    Dim mEntidad As New SUMINISTROS
                    mEntidad.IDSUMINISTRO = IIf(dr("IDSUMINISTRO") Is DBNull.Value, Nothing, dr("IDSUMINISTRO"))
                    mEntidad.IDTIPOSUMINISTRO = IIf(dr("IDTIPOSUMINISTRO") Is DBNull.Value, Nothing, dr("IDTIPOSUMINISTRO"))
                    mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                    mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                    mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
                    mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                    mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                    mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                    mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                    mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                    lista.Add(mEntidad)
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerListaPorIDtipo2() As listaSUMINISTROS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDSUMINISTRO, ")
        strSQL.Append(" IDTIPOSUMINISTRO, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" '('+CORRELATIVO+') '+ DESCRIPCION AS DESCRIPCION, ")
        strSQL.Append(" MONTODISPONIBLE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTROS ")
        strSQL.Append("ORDER BY CORRELATIVO ")

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaSUMINISTROS

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    Dim mEntidad As New SUMINISTROS
                    mEntidad.IDSUMINISTRO = IIf(dr("IDSUMINISTRO") Is DBNull.Value, Nothing, dr("IDSUMINISTRO"))
                    mEntidad.IDTIPOSUMINISTRO = IIf(dr("IDTIPOSUMINISTRO") Is DBNull.Value, Nothing, dr("IDTIPOSUMINISTRO"))
                    mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                    mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                    mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
                    mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                    mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                    mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                    mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                    mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                    lista.Add(mEntidad)
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function BuscarTSuministrosCorrelativo(ByVal IDTIPOSUMINISTRO As Int32, ByVal CORRELATIVO As String) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(CORRELATIVO) ")
        strSQL.Append("FROM SAB_CAT_SUMINISTROS ")
        strSQL.Append("WHERE (IDTIPOSUMINISTRO = @IDTIPOSUMINISTRO) AND (CORRELATIVO = @CORRELATIVO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDTIPOSUMINISTRO
        args(1) = New SqlParameter("@CORRELATIVO", SqlDbType.Int)
        args(1).Value = CORRELATIVO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    'buscar
    Public Function BuscarSuministrosEnGrupos(ByVal IDSUMINISTRO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDSUMINISTRO) ")
        strSQL.Append("FROM SAB_CAT_GRUPOS ")
        strSQL.Append("WHERE (IDSUMINISTRO = @IDSUMINISTRO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    Public Function BuscarSuministrosEnInventarios(ByVal IDSUMINISTRO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDSUMINISTRO) ")
        strSQL.Append("FROM SAB_ALM_INVENTARIO ")
        strSQL.Append("WHERE (IDSUMINISTRO = @IDSUMINISTRO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    Public Function BuscarSuministrosEnNecesidadesEstablecimiento(ByVal IDSUMINISTRO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDSUMINISTRO) ")
        strSQL.Append("FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append("WHERE (IDSUMINISTRO = @IDSUMINISTRO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    Public Function BuscarSuministrosEnPlantillasContrato(ByVal IDSUMINISTRO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDSUMINISTRO) ")
        strSQL.Append("FROM SAB_UACI_PLANTILLASCONTRATO ")
        strSQL.Append("WHERE (IDSUMINISTRO = @IDSUMINISTRO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    Public Function BuscarSuministrosEnSuministroDependencia(ByVal IDSUMINISTRO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDSUMINISTRO) ")
        strSQL.Append("FROM SAB_CAT_SUMINISTRODEPENDENCIAS ")
        strSQL.Append("WHERE (IDSUMINISTRO = @IDSUMINISTRO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    Public Function BuscarSuministrosEnSolicitudes(ByVal IDCLASESUMINISTRO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDCLASESUMINISTRO ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES ")
        strSQL.Append("WHERE (IDCLASESUMINISTRO = @IDCLASESUMINISTRO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDCLASESUMINISTRO", SqlDbType.Int)
        args(0).Value = IDCLASESUMINISTRO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    ''' <summary>
    ''' Obtiene el correlativo de un suministro
    ''' </summary>
    ''' <param name="IDSUMINISTRO">Filtro para devolver el dato.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function DevolverCORRSuministro(ByVal IDSUMINISTRO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT CORRELATIVO ")
        strSQL.Append("FROM SAB_CAT_SUMINISTROS ")
        strSQL.Append("WHERE (IDSUMINISTRO = @IDSUMINISTRO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function DevolverIDSuministro(ByVal CORRELATIVO As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDSUMINISTRO ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTROS ")
        strSQL.Append(" WHERE (CORRELATIVO = @CORRELATIVO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@CORRELATIVO", SqlDbType.VarChar)
        args(0).Value = CORRELATIVO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function RecuperarOrdenada() As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("ORDER BY DESCRIPCION ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function RecuperarOrdenadaPorCorrelativo() As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("ORDER BY CORRELATIVO ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerTIPOSUMINISTROS(ByVal IDSUMINISTRO As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDTIPOSUMINISTRO ")
        strSQL.Append("FROM SAB_CAT_SUMINISTROS ")
        strSQL.Append("WHERE (IDSUMINISTRO = @IDSUMINISTRO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerSuministroOrdenado(Optional ByVal campoOrden As String = "idSuministro") As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDSUMINISTRO, ")
        strSQL.Append(" DESCRIPCION ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTROS ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append(campoOrden)
        strSQL.Append(" ASC ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerSuministroUT(ByVal iddependencia As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT S.IDSUMINISTRO, ")
        strSQL.Append(" S.DESCRIPCION ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTROS S INNER JOIN SAB_CAT_SUMINISTROSDEPENDENCIAS SD ON")
        strSQL.Append(" S.IDSUMINISTRO=SD.IDSUMINISTRO ")
        'strSQL.Append(campoOrden)
        strSQL.Append(" WHERE SD.IDDEPENDENCIA=" & iddependencia)

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerSuministroPorUT(ByVal idUT As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT '('+ CORRSUMINISTRO + ') ' + DESCSUMINISTRO as DESCSUMINISTRO,IDSUMINISTRO,CORRSUMINISTRO ")
        strSQL.Append(" FROM vv_catalogoproductos ")
        strSQL.Append(" WHERE AREATECNICA=" & idUT)
        strSQL.Append(" ORDER BY CORRSUMINISTRO")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerSuministroPorUTyGU(ByVal idUT As Integer, ByVal GU As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT '('+ CORRSUMINISTRO + ') ' + DESCSUMINISTRO as DESCSUMINISTRO,IDSUMINISTRO,CORRSUMINISTRO ")
        strSQL.Append(" FROM vv_CATALOGOPRODUCTOS_SUMINISTRODEPENDENCIAS ")
        strSQL.Append(" WHERE AREATECNICA=" & idUT & " AND TIPOUACI=" & GU)
        strSQL.Append(" ORDER BY CORRSUMINISTRO")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerSuministroPorUTyGUWithCorrProducto(ByVal idUT As Integer, ByVal GU As Integer, ByVal corrprOducto As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT '('+ CORRSUMINISTRO + ') ' + DESCSUMINISTRO as DESCSUMINISTRO,IDSUMINISTRO,CORRSUMINISTRO, ,CORRPRODUCTO,AREATECNICA,TIPOUACI ")
        strSQL.Append(" FROM vv_CATALOGOPRODUCTOS_SUMINISTRODEPENDENCIAS ")
        strSQL.Append(" WHERE AREATECNICA=" & idUT & " AND TIPOUACI=" & GU & " AND CORRPRODUCTO LIKE '%" & corrprOducto & "%'")
        strSQL.Append(" ORDER BY CORRPRODUCTO")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function RecuperarParaCargaInicial(ByVal IDALMACEN As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("with t as ")
        strSQL.Append("( ")
        strSQL.Append("select ")
        strSQL.Append("CP.IDSUMINISTRO ")
        strSQL.Append("from SAB_ALM_LOTES L ")
        strSQL.Append("inner join vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("on L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("where L.IDALMACEN = @IDALMACEN ")
        strSQL.Append("group by CP.IDSUMINISTRO ")
        strSQL.Append("union ")
        strSQL.Append("select ")
        strSQL.Append("II.IDSUMINISTRO ")
        strSQL.Append("from SAB_ALM_INVENTARIOINICIAL II ")
        strSQL.Append("where II.IDALMACEN = @IDALMACEN ")
        strSQL.Append(") ")
        strSQL.Append("select S.* ")
        strSQL.Append("from SAB_CAT_SUMINISTROS S ")
        strSQL.Append("left outer join t ")
        strSQL.Append("on S.IDSUMINISTRO = t.IDSUMINISTRO ")
        strSQL.Append("where t.IDSUMINISTRO is null ")
        strSQL.Append("order by S.CORRELATIVO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function DevolverDescSuministro(ByVal IDSUMINISTRO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DESCRIPCION ")
        strSQL.Append("FROM SAB_CAT_SUMINISTROS ")
        strSQL.Append("WHERE (IDSUMINISTRO = @IDSUMINISTRO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

End Class
