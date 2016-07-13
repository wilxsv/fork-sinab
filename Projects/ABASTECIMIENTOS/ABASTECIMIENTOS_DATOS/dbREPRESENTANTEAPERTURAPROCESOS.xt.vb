Partial Public Class dbREPRESENTANTEAPERTURAPROCESOS

    Public Function ObtenerRepresentantes(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function EliminarTodos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_REPRESENTANTEAPERTURAPROCESOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & " ")
        strSQL.Append(" AND IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & " ")

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

End Class
