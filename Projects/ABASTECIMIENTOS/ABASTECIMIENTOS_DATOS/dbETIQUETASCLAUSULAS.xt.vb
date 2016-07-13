Partial Public Class dbETIQUETASCLAUSULAS

    Public Function ObtenerDataSetPorTipo(ByVal tipo As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" where MODIFICATIVA = " & tipo)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

End Class
