Partial Public Class dbTIPOSUMINISTROS

    Public Function BuscarTIPOSUMINISTROS(ByVal IDTIPOSUMINISTRO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDTIPOSUMINISTRO ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTROS ")
        strSQL.Append(" WHERE (IDTIPOSUMINISTRO = @IDTIPOSUMINISTRO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDTIPOSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
