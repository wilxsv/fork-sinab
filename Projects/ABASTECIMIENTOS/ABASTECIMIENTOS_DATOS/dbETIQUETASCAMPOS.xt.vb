Partial Public Class dbETIQUETASCAMPOS

#Region "Metodos Agregados"

    Public Function ObtenerDataSetPorTABLA(ByVal TABLA As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)

        strSQL.Append(" WHERE TABLA = @TABLA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@TABLA", SqlDbType.VarChar)
        args(0).Value = TABLA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
