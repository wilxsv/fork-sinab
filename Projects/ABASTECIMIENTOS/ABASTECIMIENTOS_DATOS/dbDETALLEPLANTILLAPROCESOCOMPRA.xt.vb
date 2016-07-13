Partial Public Class dbDETALLEPLANTILLAPROCESOCOMPRA

#Region " Metodos Agregados "

    Public Function ObtenerTextoPlantilla(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal TIPOPLANTILLA As Byte) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("IF NOT EXISTS ")
        strSQL.Append("    ( ")
        strSQL.Append("        SELECT ")
        strSQL.Append("            TIPOPLANTILLA ")
        strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
        strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("        AND TIPOPLANTILLA = @TIPOPLANTILLA ")
        strSQL.Append("    ) ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    SELECT ")
        strSQL.Append("    CODIGOFUENTE TEXTO ")
        strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
        strSQL.Append("    WHERE TIPOPLANTILLA = @TIPOPLANTILLA ")
        strSQL.Append("END ")
        strSQL.Append("ELSE ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    SELECT ")
        strSQL.Append("    TEXTO ")
        strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
        strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("    AND TIPOPLANTILLA = @TIPOPLANTILLA ")
        strSQL.Append("END ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@TIPOPLANTILLA", SqlDbType.TinyInt)
        args(2).Value = TIPOPLANTILLA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function AgregarDETALLEPLANTILLAPROCESOCOMPRA(ByVal aEntidad As DETALLEPLANTILLAPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("IF NOT EXISTS ")
        strSQL.Append("    ( ")
        strSQL.Append("        SELECT ")
        strSQL.Append("            TIPOPLANTILLA ")
        strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
        strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("        AND TIPOPLANTILLA = @TIPOPLANTILLA ")
        strSQL.Append("    ) ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    INSERT INTO SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
        strSQL.Append("    ( IDESTABLECIMIENTO, ")
        strSQL.Append("    IDPROCESOCOMPRA, ")
        strSQL.Append("    TIPOPLANTILLA, ")
        strSQL.Append("    TEXTO, ")
        strSQL.Append("    AUUSUARIOCREACION, ")
        strSQL.Append("    AUFECHACREACION, ")
        strSQL.Append("    AUUSUARIOMODIFICACION, ")
        strSQL.Append("    AUFECHAMODIFICACION, ")
        strSQL.Append("    ESTASINCRONIZADA) ")
        strSQL.Append("    VALUES ")
        strSQL.Append("    ( @IDESTABLECIMIENTO, ")
        strSQL.Append("    @IDPROCESOCOMPRA, ")
        strSQL.Append("    @TIPOPLANTILLA, ")
        strSQL.Append("    @TEXTO, ")
        strSQL.Append("    @AUUSUARIOCREACION, ")
        strSQL.Append("    @AUFECHACREACION, ")
        strSQL.Append("    @AUUSUARIOMODIFICACION, ")
        strSQL.Append("    @AUFECHAMODIFICACION, ")
        strSQL.Append("    @ESTASINCRONIZADA) ")
        strSQL.Append("END ")
        strSQL.Append("ELSE ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    UPDATE SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
        strSQL.Append("    SET TEXTO = @TEXTO, ")
        strSQL.Append("    AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("    AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("    ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("    AND TIPOPLANTILLA = @TIPOPLANTILLA ")
        strSQL.Append("END ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@TEXTO", SqlDbType.Text)
        args(0).Value = aEntidad.TEXTO
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
        args(7) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(7).Value = aEntidad.IDPROCESOCOMPRA
        args(8) = New SqlParameter("@TIPOPLANTILLA", SqlDbType.TinyInt)
        args(8).Value = aEntidad.TIPOPLANTILLA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
