Partial Public Class dbINSTITUCIONES

    Public Function ObtenerPorcentajeReserva() As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT PORCENTAJERESERVA, IDINSTITUCION ")
        strSQL.Append("FROM SAB_CAT_INSTITUCIONES ")
        strSQL.Append("WHERE IDINSTITUCION = 1 ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

End Class
