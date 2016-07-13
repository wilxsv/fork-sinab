Partial Public Class dbOPCIONESSISTEMA

#Region "Agregados"

    ''' <summary>
    ''' Obtiene la lista de opciones del sistema que corresponden al rol indicado.
    ''' </summary>
    ''' <param name="IDROL">Identificador del rol.</param>
    ''' <returns>listaOPCIONESSISTEMA</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGOPCIONESSISTEMA</description></item>
    ''' <item><description>SEGOPCIONESSISTEMAROLES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaPorRol(ByVal IDROL As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("OS.*, ")
        strSQL.Append("isnull(OS1.DESCRIPCION, '') PADRE ")
        strSQL.Append("FROM SEGOPCIONESSISTEMA OS ")
        strSQL.Append("INNER JOIN SEGOPCIONESSISTEMAROLES OSR ")
        strSQL.Append("ON OS.IDOPCIONSISTEMA = OSR.IDOPCIONSISTEMA ")
        strSQL.Append("LEFT OUTER JOIN SEGOPCIONESSISTEMA OS1 ")
        strSQL.Append("ON OS.IDPADRE = OS1.IDOPCIONSISTEMA ")
        strSQL.Append("WHERE (OSR.IDROL = @IDROL) ")
        strSQL.Append("ORDER BY OS.DESCRIPCION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = IDROL

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerOpcionesPorRol(ByVal IDROL As Integer, ByVal SOLOPAGINAS As Boolean) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("OS.IDOPCIONSISTEMA, ")
        strSQL.Append("OS.DESCRIPCION, ")
        strSQL.Append("OSR.PERMITEEDITAR, ")
        strSQL.Append("OSR.AUUSUARIOCREACION, ")
        strSQL.Append("OSR.AUFECHACREACION ")
        strSQL.Append("FROM SEGOPCIONESSISTEMA OS ")
        strSQL.Append("INNER JOIN SEGOPCIONESSISTEMAROLES OSR ")
        strSQL.Append("ON OS.IDOPCIONSISTEMA = OSR.IDOPCIONSISTEMA ")
        strSQL.Append("WHERE (OSR.IDROL = @IDROL) ")
        strSQL.Append("AND ((URL IS NOT NULL AND URL <> '') OR (@SOLOPAGINAS = 0)) ")
        strSQL.Append("ORDER BY OS.DESCRIPCION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = IDROL
        args(1) = New SqlParameter("@SOLOPAGINAS", SqlDbType.Int)
        args(1).Value = SOLOPAGINAS

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Eliminar una opcion del rol
    ''' </summary>
    ''' <param name="IDOPCIONSISTEMA">Identificador de la opción del sistema.</param>
    ''' <param name="IDROL">Identificador del rol.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGOPCIONESSISTEMAROLES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history> 
    Public Function EliminarOpcionRol(ByVal IDOPCIONSISTEMA As Integer, ByVal IDROL As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SEGOPCIONESSISTEMAROLES ")
        strSQL.Append("WHERE IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")
        strSQL.Append("AND IDROL = @IDROL ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(0).Value = IDOPCIONSISTEMA
        args(1) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(1).Value = IDROL

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene la lista de usuarios sin rol asignado.
    ''' </summary>
    ''' <param name="IDROL">Identificador de rol.</param>
    ''' <returns>listaOPCIONESSISTEMA</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGOPCIONESSISTEMA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history> 
    Public Function ObtenerListaUsuariosSinRol(ByVal IDROL As Integer) As listaOPCIONESSISTEMA

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDOPCIONSISTEMA, ")
        strSQL.Append("DESCRIPCION, ")
        strSQL.Append("URL, ")
        strSQL.Append("ESTAHABILITADO, ")
        strSQL.Append("IDPADRE, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA ")
        strSQL.Append("FROM SEGOPCIONESSISTEMA ")
        strSQL.Append("WHERE IDOPCIONSISTEMA NOT IN (SELECT IDOPCIONSISTEMA FROM SEGOPCIONESSISTEMAROLES WHERE IDROL = @IDROL) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = IDROL

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaOPCIONESSISTEMA

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    Dim mEntidad As New OPCIONESSISTEMA
                    mEntidad.IDOPCIONSISTEMA = IIf(dr("IDOPCIONSISTEMA") Is DBNull.Value, Nothing, dr("IDOPCIONSISTEMA"))
                    mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                    mEntidad.URL = IIf(dr("URL") Is DBNull.Value, Nothing, dr("URL"))
                    mEntidad.ESTAHABILITADO = IIf(dr("ESTAHABILITADO") Is DBNull.Value, Nothing, dr("ESTAHABILITADO"))
                    mEntidad.IDPADRE = IIf(dr("IDPADRE") Is DBNull.Value, Nothing, dr("IDPADRE"))
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

    ''' <summary>
    ''' Obtiene la lista de opciones padre del sistema.
    ''' </summary>
    ''' <returns>listaOPCIONESSISTEMA</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGOPCIONESSISTEMA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history> 
    Public Function ObtenerListaPadres() As listaOPCIONESSISTEMA

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE (IDPADRE IS NULL OR URL is null OR ltrim(rtrim(URL)) = '') ")
        strSQL.Append("AND ESTAHABILITADO = 1 ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT ")
        strSQL.Append("0 IDOPCIONSISTEMA, ")
        strSQL.Append("'[Ninguna]' DESCRIPCION, ")
        strSQL.Append("'' URL, ")
        strSQL.Append("0 ESTAHABILITADO, ")
        strSQL.Append("0 IDPADRE, ")
        strSQL.Append("0 ORDEN, ")
        strSQL.Append("NULL AUUSUARIOCREACION, ")
        strSQL.Append("NULL AUFECHACREACION, ")
        strSQL.Append("NULL AUUSUARIOMODIFICACION, ")
        strSQL.Append("NULL AUFECHAMODIFICACION, ")
        strSQL.Append("0 ESTASINCRONIZADA ")
        strSQL.Append("ORDER BY DESCRIPCION ")

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Dim lista As New listaOPCIONESSISTEMA

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    Dim mEntidad As New OPCIONESSISTEMA
                    mEntidad.IDOPCIONSISTEMA = IIf(dr("IDOPCIONSISTEMA") Is DBNull.Value, Nothing, dr("IDOPCIONSISTEMA"))
                    mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                    mEntidad.URL = IIf(dr("URL") Is DBNull.Value, Nothing, dr("URL"))
                    mEntidad.ESTAHABILITADO = IIf(dr("ESTAHABILITADO") Is DBNull.Value, Nothing, dr("ESTAHABILITADO"))
                    mEntidad.IDPADRE = IIf(dr("IDPADRE") Is DBNull.Value, Nothing, dr("IDPADRE"))
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

    ''' <summary>
    ''' Obtener listado de opciones por rol
    ''' </summary>
    ''' <param name="IDROL">Identificador del rol.</param>
    ''' <returns>listaOPCIONESSISTEMA</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGOPCIONESSISTEMA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history> 
    Public Function ObtenerListaOpcionesParaRolPorID(ByVal IDROL As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("OS.IDOPCIONSISTEMA, ")
        strSQL.Append("OS.DESCRIPCION, ")
        strSQL.Append("isnull(OS.URL, '') URL, ")
        strSQL.Append("OS.ESTAHABILITADO, ")
        strSQL.Append("OS.IDPADRE, ")
        strSQL.Append("isnull(OS1.DESCRIPCION, '') PADRE, ")
        strSQL.Append("OS.AUUSUARIOCREACION, ")
        strSQL.Append("OS.AUFECHACREACION, ")
        strSQL.Append("OS.AUUSUARIOMODIFICACION, ")
        strSQL.Append("OS.AUFECHAMODIFICACION, ")
        strSQL.Append("OS.ESTASINCRONIZADA ")
        strSQL.Append("FROM SEGOPCIONESSISTEMA OS ")
        strSQL.Append("LEFT OUTER JOIN SEGOPCIONESSISTEMA OS1 ")
        strSQL.Append("ON OS.IDPADRE = OS1.IDOPCIONSISTEMA ")
        strSQL.Append("WHERE OS.ESTAHABILITADO = 1 ")
        strSQL.Append("AND OS.IDOPCIONSISTEMA not in(SELECT OSR.IDOPCIONSISTEMA ")
        strSQL.Append("                              FROM SEGOPCIONESSISTEMAROLES OSR ")
        strSQL.Append("                              WHERE OSR.IDOPCIONSISTEMA = OS.IDOPCIONSISTEMA ")
        strSQL.Append("                              AND OSR.IDROL = @IDROL) ")
        strSQL.Append("ORDER BY OS.DESCRIPCION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = IDROL

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Dataset de listado de opciones
    ''' </summary>
    ''' <returns>
    ''' Dataset solicitado
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGOPCIONESSISTEMA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history> 
    Public Function ObtenerListaOpciones() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("O.IDOPCIONSISTEMA, ")
        strSQL.Append("O.DESCRIPCION, ")
        strSQL.Append("O.ESTAHABILITADO, ")
        strSQL.Append("(SELECT count(*) FROM SEGOPCIONESSISTEMA OS WHERE OS.IDPADRE = O.IDOPCIONSISTEMA) OPCIONES, ")
        strSQL.Append("O.AUUSUARIOCREACION, ")
        strSQL.Append("O.AUFECHACREACION ")
        strSQL.Append("FROM SEGOPCIONESSISTEMA O ")
        strSQL.Append("ORDER BY O.DESCRIPCION ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Obtener el listado de opciones de reporte.  Esta función se utiliza para los reportes.
    ''' </summary>
    ''' <param name="campoOrdenar"></param> nombre de campo por que se ordenara
    ''' <returns>
    ''' Dataset con la informacion solicitada.
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGOPCIONESSISTEMA</description></item>
    ''' <item><description>ConsultaRoles</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Jürgen Kappler]      Creado
    ''' </history> 
    Public Function ObtenerListaOpcionesReporte(ByVal campoOrdenar As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("WITH CONSULTAROLES(ID, DESCRIPCION, URL, LEVEL, ESTAHABILITADO, SORTKEY) ")
        strSQL.Append("AS ")
        strSQL.Append("( ")
        strSQL.Append(" SELECT O.IDOPCIONSISTEMA, O.DESCRIPCION, O.URL, 0 LEVEL, O.ESTAHABILITADO, ")
        strSQL.Append(" cast(O." & campoOrdenar & " as varbinary(900)) ")
        strSQL.Append(" FROM SEGOPCIONESSISTEMA O ")
        strSQL.Append(" WHERE O.IDPADRE IS NULL ")
        strSQL.Append(" UNION ALL ")
        strSQL.Append(" SELECT O.IDOPCIONSISTEMA, O.DESCRIPCION, O.URL, LEVEL + 1, O.ESTAHABILITADO, cast(C.SORTKEY + cast(O." & campoOrdenar & " as varbinary(900)) as varbinary(900)) ")
        strSQL.Append(" FROM SEGOPCIONESSISTEMA O, CONSULTAROLES C ")
        strSQL.Append(" WHERE C.ID = O.IDPADRE ")
        strSQL.Append(") ")
        strSQL.Append("SELECT * FROM CONSULTAROLES ORDER BY SORTKEY ASC ")

        Return SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerOpcionesPorOrden() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("O.IDOPCIONSISTEMA, ")
        strSQL.Append("O.DESCRIPCION, ")
        strSQL.Append("O.IDPADRE ")
        strSQL.Append("FROM SEGOPCIONESSISTEMA O ")
        strSQL.Append("WHERE O.ESTAHABILITADO = 1 ")
        strSQL.Append("ORDER BY O.ORDEN ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ActualizarOrden(ByVal aEntidad As OPCIONESSISTEMA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SEGOPCIONESSISTEMA ")
        strSQL.Append("SET ")
        strSQL.Append("ORDEN = @ORDEN, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@ORDEN", SqlDbType.SmallInt)
        args(0).Value = aEntidad.ORDEN
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(4).Value = aEntidad.IDOPCIONSISTEMA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
