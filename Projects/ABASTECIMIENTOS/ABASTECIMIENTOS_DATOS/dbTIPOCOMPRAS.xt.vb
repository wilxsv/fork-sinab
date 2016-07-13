Partial Public Class dbTIPOCOMPRAS

#Region " Métodos Agregados "

    Public Function obtenerListaporMonto(ByVal totalMonto As Decimal) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE @MONTO BETWEEN MIN AND MAX ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args(0).Value = totalMonto

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function RecuperarOrdenada() As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" ORDER BY DESCRIPCION")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerTipoCompraxMODALIDAD(ByVal IDMODALIDADCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDTIPOCOMPRA, IDMODALIDADCOMPRA, DESCRIPCION, MIN, MAX, REQUIERECALIFICACION, PREFIJOBASE ")
        strSQL.Append(" FROM SAB_CAT_TIPOCOMPRAS ")
        strSQL.Append(" WHERE IDMODALIDADCOMPRA = @IDMODALIDADCOMPRA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.Int)
        args(0).Value = IDMODALIDADCOMPRA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerTipoCompraporMonto(ByVal MONTO As Decimal) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDTIPOCOMPRA, IDMODALIDADCOMPRA, DESCRIPCION, MIN, MAX ")
        strSQL.Append(" FROM SAB_CAT_TIPOCOMPRAS ")
        strSQL.Append(" WHERE @MONTO BETWEEN MIN AND MAX or IDTIPOCOMPRA = 4")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args(0).Value = MONTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerTipoCompraporMontoLG(ByVal MONTO As Decimal) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDTIPOCOMPRA, IDMODALIDADCOMPRA, DESCRIPCION, MIN, MAX ")
        strSQL.Append(" FROM SAB_CAT_TIPOCOMPRAS ")
        strSQL.Append(" WHERE IDMODALIDADCOMPRA = 2 AND @MONTO BETWEEN MIN AND MAX ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args(0).Value = MONTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
