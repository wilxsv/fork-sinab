Partial Public Class dbASESORIAPREDEFINIDA

#Region " VALIDACIONES ADICIONALES "

    'Validar descripcion 
    Public Function VALIDARDESCRIPCION(ByVal DESCRIPCION As String, ByVal IDASESORIA As Int16) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT COUNT(*) ")
        strSQL.Append("FROM SAB_CAT_ASESORIAPREDEFINIDA ")
        strSQL.Append("WHERE DESCRIPCION = @DESCRIPCION AND (IDASESORIA <> @IDASESORIA OR @IDASESORIA = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(0).Value = DESCRIPCION
        args(1) = New SqlParameter("@IDASESORIA", SqlDbType.SmallInt)
        args(1).Value = IDASESORIA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
