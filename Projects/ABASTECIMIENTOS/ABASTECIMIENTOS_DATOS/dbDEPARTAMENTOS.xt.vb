Partial Public Class dbDEPARTAMENTOS

    'Validar si un nombre corto ya existe
    '04/01/07 Responsable SONIA
    Public Function BuscarCODIGODEPARTAMENTO(ByVal CODIGODEPARTAMENTO As String, ByVal IDDEPARTAMENTO As Int16) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_DEPARTAMENTOS ")
        strSQL.Append("WHERE CODIGODEPARTAMENTO = @CODIGODEPARTAMENTO AND (IDDEPARTAMENTO <> @IDDEPARTAMENTO OR @IDDEPARTAMENTO = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@CODIGODEPARTAMENTO", SqlDbType.VarChar)
        args(0).Value = CODIGODEPARTAMENTO
        args(1) = New SqlParameter("@IDDEPARTAMENTO", SqlDbType.SmallInt)
        args(1).Value = IDDEPARTAMENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 1, 0)

    End Function

End Class
