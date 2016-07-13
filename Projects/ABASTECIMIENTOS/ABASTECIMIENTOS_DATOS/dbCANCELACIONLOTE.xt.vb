Partial Public Class dbCANCELACIONLOTE

#Region " Metodos Agregados "

    Public Overloads Function Actualizar(ByVal aEntidad As CANCELACIONLOTE) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("IF NOT EXISTS ")
        strSQL.Append("    ( ")
        strSQL.Append("     SELECT ")
        strSQL.Append("     LOTE ")
        strSQL.Append("     FROM SAB_UACI_CANCELACIONLOTE ")
        strSQL.Append("     WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("     AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("     AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("     AND RENGLON = @RENGLON ")
        strSQL.Append("     AND LOTE = @LOTE ")
        strSQL.Append("    ) ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    INSERT INTO SAB_UACI_CANCELACIONLOTE ")
        strSQL.Append("    ( IDESTABLECIMIENTO, ")
        strSQL.Append("    IDPROVEEDOR, ")
        strSQL.Append("    IDCONTRATO, ")
        strSQL.Append("    RENGLON, ")
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
        strSQL.Append("    UPDATE SAB_UACI_CANCELACIONLOTE ")
        strSQL.Append("    SET ESTAHABILITADO = @ESTAHABILITADO, ")
        strSQL.Append("    AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("    AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("    ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("    AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("    AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("    AND RENGLON = @RENGLON ")
        strSQL.Append("    AND LOTE = @LOTE ")
        strSQL.Append("END ")

        Dim args(10) As SqlParameter
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
        args(10) = New SqlParameter("@LOTE", SqlDbType.VarChar)
        args(10).Value = aEntidad.LOTE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve la información de los lotes examinados por el laboratorio para un renglón especifico,
    ''' mostrando unicamente aquellos lotes que han sido cancelados.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato al que pertenece el renglón.</param>
    ''' <param name="RENGLON">Número del renglón seleccionado.</param>
    ''' <returns>Valor numérico que indica si el lote se ha cancelado.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CANCELACIONLOTE</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  05/02/2007    Creado
    ''' </history> 
    Public Function ObtenerInformacionLoteCancelado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal LOTE As String) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT COUNT(LOTE) FROM SAB_UACI_CANCELACIONLOTE ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND RENGLON = @RENGLON ")
        strSQL.Append("AND LOTE = @LOTE ")
        strSQL.Append("AND ESTAHABILITADO <> 1 ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON
        args(4) = New SqlParameter("@LOTE", SqlDbType.VarChar)
        args(4).Value = LOTE

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
