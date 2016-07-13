Partial Public Class dbTIPODOCUMENTOREFERENCIAS

    Public Function BuscarDescripcion(ByVal DESCRIPCION As String) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DESCRIPCION ")
        strSQL.Append(" FROM SAB_CAT_TIPODOCUMENTOREFERENCIAS ")
        strSQL.Append(" WHERE (DESCRIPCION = @DESCRIPCION) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(0).Value = DESCRIPCION

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 1
        Else
            Return 0
        End If

    End Function

End Class
