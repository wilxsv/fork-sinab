Partial Public Class dbCLAUSULAS

    Public Function ObtenerDataSetPorID(ByVal IDCLAUSULA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDCLAUSULA = @IDCLAUSULA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(0).Value = IDCLAUSULA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorTipoModificativa(ByVal IDTIPOCOMPRA As Integer, ByVal MODIFICATIVA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE MODIFICATIVA = @MODIFICATIVA ")
        strSQL.Append(" AND IDMODALIDADCOMPRA IN (SELECT IDMODALIDADCOMPRA FROM SAB_CAT_TIPOCOMPRAS WHERE IDTIPOCOMPRA = @IDTIPOCOMPRA) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOCOMPRA", SqlDbType.TinyInt)
        args(0).Value = IDTIPOCOMPRA
        args(1) = New SqlParameter("@MODIFICATIVA", SqlDbType.TinyInt)
        args(1).Value = MODIFICATIVA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorModalidad(ByVal IDMODALIDADCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDMODALIDADCOMPRA = @IDMODALIDADCOMPRA")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.TinyInt)
        args(0).Value = IDMODALIDADCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

End Class
