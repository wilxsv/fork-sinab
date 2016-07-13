Partial Public Class dbEXAMENRENGLON

    Public Function Chequeo1Entrega(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ENTREGADO1 ")
        strSQL.Append(" FROM SAB_UACI_EXAMENRENGLON ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function Chequeo2Entrega(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ENTREGADO2 ")
        strSQL.Append(" FROM SAB_UACI_EXAMENRENGLON ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetDOC(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDOCEntrega1(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("   SELECT SAB_CAT_DOCUMENTOSBASE.DESCRIPCION, SAB_UACI_EXAMENRENGLON.ENTREGADO1, SAB_UACI_EXAMENRENGLON.IDDOCUMENTOBASE ")
        strSQL.Append(" FROM SAB_UACI_EXAMENRENGLON INNER JOIN ")
        strSQL.Append("               SAB_CAT_DOCUMENTOSBASE ON SAB_UACI_EXAMENRENGLON.IDDOCUMENTOBASE = SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE ")
        strSQL.Append(" WHERE (SAB_UACI_EXAMENRENGLON.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_EXAMENRENGLON.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND ")
        strSQL.Append("                      (SAB_UACI_EXAMENRENGLON.IDPROVEEDOR = @IDPROVEEDOR) AND (SAB_UACI_EXAMENRENGLON.IDDETALLE = @IDDETALLE)AND (SAB_CAT_DOCUMENTOSBASE.IDTIPODOCUMENTOBASE = 3) AND  (SAB_UACI_EXAMENRENGLON.ENTREGADO1 = 2) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.SmallInt)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDOCEntrega1General(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("   SELECT SAB_CAT_DOCUMENTOSBASE.DESCRIPCION, SAB_UACI_EXAMENRENGLON.ENTREGADO1, SAB_UACI_EXAMENRENGLON.IDDOCUMENTOBASE ")
        strSQL.Append(" FROM SAB_UACI_EXAMENRENGLON INNER JOIN ")
        strSQL.Append("               SAB_CAT_DOCUMENTOSBASE ON SAB_UACI_EXAMENRENGLON.IDDOCUMENTOBASE = SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE ")
        strSQL.Append(" WHERE (SAB_UACI_EXAMENRENGLON.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_EXAMENRENGLON.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND ")
        strSQL.Append("                      (SAB_UACI_EXAMENRENGLON.IDPROVEEDOR = @IDPROVEEDOR) AND (SAB_CAT_DOCUMENTOSBASE.IDTIPODOCUMENTOBASE = 3) AND  (SAB_UACI_EXAMENRENGLON.IDDETALLE = @IDDETALLE) and (SAB_UACI_EXAMENRENGLON.ESTASINCRONIZADA = 1) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.SmallInt)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDOCEntrega2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("   SELECT SAB_CAT_DOCUMENTOSBASE.DESCRIPCION, SAB_UACI_EXAMENRENGLON.ENTREGADO1, SAB_UACI_EXAMENRENGLON.ENTREGADO2, SAB_UACI_EXAMENRENGLON.IDDOCUMENTOBASE ")
        strSQL.Append(" FROM SAB_UACI_EXAMENRENGLON INNER JOIN ")
        strSQL.Append("               SAB_CAT_DOCUMENTOSBASE ON SAB_UACI_EXAMENRENGLON.IDDOCUMENTOBASE = SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE ")
        strSQL.Append(" WHERE (SAB_UACI_EXAMENRENGLON.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_EXAMENRENGLON.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND ")
        strSQL.Append("                      (SAB_UACI_EXAMENRENGLON.IDPROVEEDOR = @IDPROVEEDOR) AND (SAB_UACI_EXAMENRENGLON.IDDETALLE = @IDDETALLE) AND(SAB_CAT_DOCUMENTOSBASE.IDTIPODOCUMENTOBASE = 3) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.SmallInt)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function Actualizar2Entrega(ByVal aEntidad As EXAMENRENGLON) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_EXAMENRENGLON ")
        strSQL.Append(" SET ")
        strSQL.Append(" ENTREGADO1 = @ENTREGADO1, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")
        strSQL.Append(" AND IDDOCUMENTOBASE = @IDDOCUMENTOBASE ")

        Dim args(8) As SqlParameter
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
        args(7) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(7).Value = aEntidad.IDDETALLE
        args(8) = New SqlParameter("@IDDOCUMENTOBASE", SqlDbType.SmallInt)
        args(8).Value = aEntidad.IDDOCUMENTOBASE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ChequeoAnalisisCompletoXProveedor(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As Boolean

        Dim strSQL, strSQL2 As New Text.StringBuilder
        strSQL.Append(" SELECT COUNT(IDDETALLE) ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" WHERE ")
        strSQL.Append(" (IDPROVEEDOR = @IDPROVEEDOR) AND (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim NumeroDetalleOferta As Integer
        NumeroDetalleOferta = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        strSQL2.Append(" SELECT COUNT(DISTINCT IDDETALLE) ")
        strSQL2.Append(" FROM SAB_UACI_EXAMENRENGLON ")
        strSQL2.Append(" WHERE ")
        strSQL2.Append(" (IDPROVEEDOR = @IDPROVEEDOR) AND (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

        Dim args2(3) As SqlParameter
        args2(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args2(0).Value = IDESTABLECIMIENTO
        args2(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args2(1).Value = IDPROCESOCOMPRA
        args2(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args2(2).Value = IDPROVEEDOR

        Dim NumeroDetalleOferta2 As Integer
        NumeroDetalleOferta2 = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL2.ToString(), args2)

        If NumeroDetalleOferta = NumeroDetalleOferta2 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
