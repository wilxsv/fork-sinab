Partial Public Class dbOFERTAPROCESOCOMPRA

#Region " Métodos Agregados "

    Public Function ActualizarOfertaProcesoCompra(ByVal aEntidad As OFERTAPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_OFERTAPROCESOCOMPRA ")
        strSQL.Append(" SET ACTIVOCIRCULANTE = @ACTIVOCIRCULANTE, ")
        strSQL.Append(" PASIVOCIRCULANTE = @PASIVOCIRCULANTE, ")
        strSQL.Append(" ACTIVOTOTAL = @ACTIVOTOTAL, ")
        strSQL.Append(" PASIVOTOTAL = @PASIVOTOTAL, ")
        strSQL.Append(" PRESENTAREFERENCIASBANCARIAS = @PRESENTAREFERENCIASBANCARIAS ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@ACTIVOCIRCULANTE", SqlDbType.VarChar)
        args(0).Value = IIf(aEntidad.ACTIVOCIRCULANTE = Nothing, DBNull.Value, aEntidad.ACTIVOCIRCULANTE)
        args(1) = New SqlParameter("@PASIVOCIRCULANTE", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.PASIVOCIRCULANTE = Nothing, DBNull.Value, aEntidad.PASIVOCIRCULANTE)
        args(2) = New SqlParameter("@ACTIVOTOTAL", SqlDbType.VarChar)
        args(2).Value = IIf(aEntidad.ACTIVOTOTAL = Nothing, DBNull.Value, aEntidad.ACTIVOTOTAL)
        args(3) = New SqlParameter("@PASIVOTOTAL", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.PASIVOTOTAL = Nothing, DBNull.Value, aEntidad.PASIVOTOTAL)
        args(4) = New SqlParameter("@PRESENTAREFERENCIASBANCARIAS", SqlDbType.VarChar)
        args(4).Value = IIf(aEntidad.PRESENTAREFERENCIASBANCARIAS = Nothing, DBNull.Value, aEntidad.PRESENTAREFERENCIASBANCARIAS)
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(7) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(7).Value = aEntidad.ESTASINCRONIZADA
        args(8) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(8).Value = aEntidad.IDPROCESOCOMPRA
        args(9) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(9).Value = aEntidad.IDESTABLECIMIENTO
        args(10) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(10).Value = aEntidad.IDPROVEEDOR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarMontos(ByVal aEntidad As OFERTAPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_OFERTAPROCESOCOMPRA ")
        strSQL.Append(" SET NOMBREREPRESENTANTE = @NOMBREREPRESENTANTE, ")
        strSQL.Append(" MONTOOFERTA = @MONTOOFERTA, ")
        strSQL.Append(" MONTOGARANTIA = @MONTOGARANTIA, ")
        strSQL.Append(" ESTAHABILITADO = @ESTAHABILITADO, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(18) As SqlParameter
        args(0) = New SqlParameter("@NOMBREREPRESENTANTE", SqlDbType.VarChar)
        args(0).Value = aEntidad.NOMBREREPRESENTANTE
        args(1) = New SqlParameter("@MONTOOFERTA", SqlDbType.VarChar)
        args(1).Value = aEntidad.MONTOOFERTA
        args(2) = New SqlParameter("@MONTOGARANTIA", SqlDbType.VarChar)
        args(2).Value = aEntidad.MONTOGARANTIA
        args(3) = New SqlParameter("@ESTAHABILITADO", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.ESTAHABILITADO = Nothing, DBNull.Value, aEntidad.ESTAHABILITADO)
        args(4) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(4).Value = IIf(aEntidad.OBSERVACION = Nothing, DBNull.Value, aEntidad.OBSERVACION)
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(7) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(7).Value = aEntidad.ESTASINCRONIZADA
        args(8) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(8).Value = aEntidad.IDPROCESOCOMPRA
        args(9) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(9).Value = aEntidad.IDESTABLECIMIENTO
        args(10) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(10).Value = aEntidad.IDPROVEEDOR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerInfoFinanciera(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal ordenllegada As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ACTIVOCIRCULANTE, PASIVOCIRCULANTE, ACTIVOTOTAL, ")
        strSQL.Append(" PASIVOTOTAL, PRESENTAREFERENCIASBANCARIAS ")
        strSQL.Append(" FROM SAB_UACI_OFERTAPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS ON SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR = @ORDENLLEGADA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@ORDENLLEGADA", SqlDbType.Int)
        args(2).Value = ordenllegada

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerOrdenLLegada(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ORDENLLEGADA, IDPROVEEDOR FROM SAB_UACI_RECEPCIONOFERTAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA order by ordenllegada asc")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ActualizarInfoFinanciera(ByVal aEntidad As OFERTAPROCESOCOMPRA, Optional ByVal joker As Integer = 0) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_OFERTAPROCESOCOMPRA ")
        strSQL.Append("SET ACTIVOCIRCULANTE = @ACTIVOCIRCULANTE, ")
        strSQL.Append("PASIVOCIRCULANTE = @PASIVOCIRCULANTE, ")
        strSQL.Append("ACTIVOTOTAL = @ACTIVOTOTAL, ")
        strSQL.Append("PASIVOTOTAL = @PASIVOTOTAL, ")
        strSQL.Append("PRESENTAREFERENCIASBANCARIAS = @PRESENTAREFERENCIASBANCARIAS, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        If joker = 0 Then
            strSQL.Append(" ,FECHAEXAMEN = @FECHAEXAMEN ")
        End If

        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@ACTIVOCIRCULANTE", SqlDbType.Decimal)
        args(0).Value = aEntidad.ACTIVOCIRCULANTE
        args(1) = New SqlParameter("@PASIVOCIRCULANTE", SqlDbType.Decimal)
        args(1).Value = aEntidad.PASIVOCIRCULANTE
        args(2) = New SqlParameter("@ACTIVOTOTAL", SqlDbType.Decimal)
        args(2).Value = aEntidad.ACTIVOTOTAL
        args(3) = New SqlParameter("@PRESENTAREFERENCIASBANCARIAS", SqlDbType.Bit)
        args(3).Value = aEntidad.PRESENTAREFERENCIASBANCARIAS
        args(4) = New SqlParameter("@PASIVOTOTAL", SqlDbType.Decimal)
        args(4).Value = aEntidad.PASIVOTOTAL
        args(5) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(5).Value = IIf(aEntidad.IDPROCESOCOMPRA = Nothing, DBNull.Value, aEntidad.IDPROCESOCOMPRA)
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)
        args(7) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(7).Value = IIf(aEntidad.IDPROVEEDOR = Nothing, DBNull.Value, aEntidad.IDPROVEEDOR)
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(10) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(10).Value = aEntidad.ESTASINCRONIZADA
        If joker = 0 Then
            args(11) = New SqlParameter("@FECHAEXAMEN", SqlDbType.DateTime)
            args(11).Value = aEntidad.FECHAEXAMEN
        End If

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarObservacionDocumento(ByVal aEntidad As OFERTAPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_OFERTAPROCESOCOMPRA ")
        strSQL.Append("SET OBSERVACIONDOCUMENTO = @OBSERVACIONDOCUMENTO, ")
        strSQL.Append("FECHAEXAMEN = @FECHAEXAMEN, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@OBSERVACIONDOCUMENTO", SqlDbType.VarChar)
        args(0).Value = IIf(IsNothing(aEntidad.OBSERVACIONDOCUMENTO), DBNull.Value, aEntidad.OBSERVACIONDOCUMENTO)
        args(1) = New SqlParameter("@FECHAEXAMEN", SqlDbType.DateTime)
        args(1).Value = aEntidad.FECHAEXAMEN
        args(2) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(2).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(3) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(3).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(4) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(4).Value = aEntidad.ESTASINCRONIZADA
        args(5) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(5).Value = aEntidad.IDESTABLECIMIENTO
        args(6) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(6).Value = aEntidad.IDPROCESOCOMPRA
        args(7) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(7).Value = aEntidad.IDPROVEEDOR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerDocumentoObservacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(OBSERVACIONDOCUMENTO, '') OBSERVACIONDOCUMENTO ")
        strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarFechaExamen(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal FECHAEXAMEN As DateTime) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_OFERTAPROCESOCOMPRA ")
        strSQL.Append("SET FECHAEXAMEN = @FECHAEXAMEN ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@FECHAEXAMEN", SqlDbType.DateTime)
        args(0).Value = FECHAEXAMEN
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(2).Value = IDPROCESOCOMPRA
        args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(3).Value = IDPROVEEDOR

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerDesiertosNoAdjudicados(ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT PC.IDESTABLECIMIENTO, PC.IDPROCESOCOMPRA, PC.IDESTADOPROCESOCOMPRA, DPC.RENGLON, DPC.CANTIDAD, DPC.NUMEROENTREGAS, ")
        strSQL.Append(" EC.DESCRIPCION AS ESTADO, DPC.IDESTADOCALIFICACION, PC.TITULOLICITACION, PC.DESCRIPCIONLICITACION, CP.DESCLARGO AS PRODUCTO, PC.CODIGOLICITACION")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA AS DPC ON PC.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA AND ")
        strSQL.Append(" PC.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTADOSCALIFICACIONES AS EC ON DPC.IDESTADOCALIFICACION = EC.IDESTADO INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS AS CP ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE (PC.IDESTADOPROCESOCOMPRA > 4) AND (PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (DPC.IDESTADOCALIFICACION = 8 OR ")
        strSQL.Append(" DPC.IDESTADOCALIFICACION = 7) ORDER BY DPC.RENGLON")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
