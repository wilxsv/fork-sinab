Partial Public Class dbTIPOCRITERIO

    Public Function ObtenerDataSetPorIDxTIPO(ByVal IDTIPOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDTIPOCOMPRA = " & IDTIPOCOMPRA)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

End Class
