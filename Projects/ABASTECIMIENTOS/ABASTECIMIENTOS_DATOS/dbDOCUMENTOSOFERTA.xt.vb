Partial Public Class dbDOCUMENTOSOFERTA

    Public Function Chequeo1Entrega(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ENTREGADO1 ")
        strSQL.Append(" FROM SAB_UACI_DOCUMENTOSOFERTA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function Chequeo2Entrega(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ENTREGADO2 ")
        strSQL.Append(" FROM SAB_UACI_DOCUMENTOSOFERTA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetDOC(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDOCEntrega1(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DB.DESCRIPCION, ")
        strSQL.Append("DO.ENTREGADO1, ")
        strSQL.Append("DO.IDDOCUMENTOBASE ")
        strSQL.Append("FROM SAB_UACI_DOCUMENTOSOFERTA DO ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON DO.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("WHERE DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND DB.IDTIPODOCUMENTOBASE <> 3 ")
        'SOLO MOSTRAR LOS QUE ESTAN EN ESTADO NO CUMPLE
        strSQL.Append("AND DO.ENTREGADO1 = 2 ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDOCEntrega2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DB.DESCRIPCION, ")
        strSQL.Append("DO.ENTREGADO1, ")
        strSQL.Append("DO.ENTREGADO2, ")
        strSQL.Append("DO.IDDOCUMENTOBASE ")
        strSQL.Append("FROM SAB_UACI_DOCUMENTOSOFERTA DO ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON DO.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("WHERE ")
        strSQL.Append("(DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("AND (DO.IDPROVEEDOR = @IDPROVEEDOR) ")
        strSQL.Append("AND (DB.IDTIPODOCUMENTOBASE <> 3) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function Actualizar2Entrega(ByVal aEntidad As DOCUMENTOSOFERTA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DOCUMENTOSOFERTA ")
        strSQL.Append(" SET ")
        strSQL.Append(" ENTREGADO1 = @ENTREGADO1, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDOCUMENTOBASE = @IDDOCUMENTOBASE ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@ENTREGADO1", SqlDbType.TinyInt)
        args(0).Value = aEntidad.ENTREGADO1
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = aEntidad.IDESTABLECIMIENTO
        args(5) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(5).Value = aEntidad.IDPROCESOCOMPRA
        args(6) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(6).Value = aEntidad.IDPROVEEDOR
        args(7) = New SqlParameter("@IDDOCUMENTOBASE", SqlDbType.SmallInt)
        args(7).Value = aEntidad.IDDOCUMENTOBASE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerProveedores(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT COUNT(DISTINCT IDPROVEEDOR) ")
        strSQL.Append("FROM SAB_UACI_DOCUMENTOSOFERTA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerUnProveedor(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT COUNT(DISTINCT IDPROVEEDOR) ")
        strSQL.Append("FROM SAB_UACI_DOCUMENTOSOFERTA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(2).Value = IDPROVEEDOR

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

End Class
