Partial Public Class dbDETALLECANCELACIONPRODUCTO

#Region " Metodos Agregados "

    ''' <summary>
    ''' Sobrecarga la función Actualizar para permitir actualizar o insertar un registro de la tabla de detalles de cancelación en un solo método.
    ''' </summary>
    ''' <param name="aEntidad">Entidad DETALLECANCELACIONPRODUCTO.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLECANCELACIONPRODUCTO</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]   Creado
    ''' </history>
    Public Overloads Function Actualizar(ByVal aEntidad As DETALLECANCELACIONPRODUCTO) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("IF NOT EXISTS ")
        strSQL.Append("    ( ")
        strSQL.Append("     SELECT ")
        strSQL.Append("     LOTE ")
        strSQL.Append("     FROM SAB_UACI_DETALLECANCELACIONPRODUCTO ")
        strSQL.Append("     WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("     AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("     AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("     AND RENGLON = @RENGLON ")
        strSQL.Append("     AND IDCANCELACION = @IDCANCELACION ")
        strSQL.Append("     AND LOTE = @LOTE ")
        strSQL.Append("    ) ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    INSERT INTO SAB_UACI_DETALLECANCELACIONPRODUCTO ")
        strSQL.Append("    ( IDESTABLECIMIENTO, ")
        strSQL.Append("    IDPROVEEDOR, ")
        strSQL.Append("    IDCONTRATO, ")
        strSQL.Append("    RENGLON, ")
        strSQL.Append("    IDCANCELACION, ")
        strSQL.Append("    LOTE, ")
        strSQL.Append("    ESTAHABILITADO, ")
        strSQL.Append("    AUUSUARIOCREACION, ")
        strSQL.Append("    AUFECHACREACION, ")
        strSQL.Append("    AUUSUARIOMODIFICACION, ")
        strSQL.Append("    AUFECHAMODIFICACION, ")
        strSQL.Append("    ESTASINCRONIZADA) ")
        strSQL.Append("    VALUES ")
        strSQL.Append("    ( @IDESTABLECIMIENTO, ")
        strSQL.Append("    @IDPROVEEDOR, ")
        strSQL.Append("    @IDCONTRATO, ")
        strSQL.Append("    @RENGLON, ")
        strSQL.Append("    @IDCANCELACION, ")
        strSQL.Append("    @LOTE, ")
        strSQL.Append("    @ESTAHABILITADO, ")
        strSQL.Append("    @AUUSUARIOCREACION, ")
        strSQL.Append("    @AUFECHACREACION, ")
        strSQL.Append("    @AUUSUARIOMODIFICACION, ")
        strSQL.Append("    @AUFECHAMODIFICACION, ")
        strSQL.Append("    @ESTASINCRONIZADA) ")
        strSQL.Append("END ")
        strSQL.Append("ELSE ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    UPDATE SAB_UACI_DETALLECANCELACIONPRODUCTO ")
        strSQL.Append("    SET ESTAHABILITADO = @ESTAHABILITADO, ")
        strSQL.Append("    AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("    AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("    ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("    AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("    AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("    AND RENGLON = @RENGLON ")
        strSQL.Append("    AND IDCANCELACION = @IDCANCELACION ")
        strSQL.Append("    AND LOTE = @LOTE ")
        strSQL.Append("END ")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@ESTAHABILITADO", SqlDbType.TinyInt)
        args(0).Value = aEntidad.ESTAHABILITADO
        args(1) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args(2) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHACREACION = Nothing, DBNull.Value, aEntidad.AUFECHACREACION)
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(5) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(5).Value = aEntidad.ESTASINCRONIZADA
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = aEntidad.IDESTABLECIMIENTO
        args(7) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(7).Value = aEntidad.IDPROVEEDOR
        args(8) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(8).Value = aEntidad.IDCONTRATO
        args(9) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(9).Value = aEntidad.RENGLON
        args(10) = New SqlParameter("@IDCANCELACION", SqlDbType.SmallInt)
        args(10).Value = aEntidad.IDCANCELACION
        args(11) = New SqlParameter("@LOTE", SqlDbType.VarChar)
        args(11).Value = aEntidad.LOTE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve las cancelaciones y anulaciones efectuadas para un renglón dado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLECANCELACIONPRODUCTO</item>
    ''' <item>SAB_UACI_CANCELACIONPRODUCTO</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]   Creado
    ''' </history>
    Public Function ObtenerCancelacionDetalles(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CP.ESTAHABILITADO RENGLONHABILITADO, ")
        strSQL.Append("CP.FECHACANCELACION, ")
        strSQL.Append("isnull(CP.MOTIVOCANCELACION, '') MOTIVOCANCELACION, ")
        strSQL.Append("CP.FECHAANULACION, ")
        strSQL.Append("isnull(CP.MOTIVOANULACION, '') MOTIVOANULACION ")
        strSQL.Append("DCP.LOTE, ")
        strSQL.Append("DCP.ESTAHABILITADO LOTEHABILITADO ")
        strSQL.Append("FROM SAB_UACI_DETALLECANCELACIONPRODUCTO DCP ")
        strSQL.Append("INNER JOIN SAB_UACI_CANCELACIONPRODUCTO CP ")
        strSQL.Append("ON (DCP.IDESTABLECIMIENTOCONTRATO = CP.IDESTABLECIMIENTO ")
        strSQL.Append("AND DCP.IDPROVEEDOR = CP.IDPROVEEDOR ")
        strSQL.Append("AND DCP.IDCONTRATO = CP.IDCONTRATO ")
        strSQL.Append("AND DCP.RENGLON = CP.RENGLON) ")
        strSQL.Append("WHERE DCP.IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DCP.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND DCP.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND DCP.RENGLON = @RENGLON ")
        strSQL.Append("ORDER BY CP.FECHACANCELACION DESC ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
