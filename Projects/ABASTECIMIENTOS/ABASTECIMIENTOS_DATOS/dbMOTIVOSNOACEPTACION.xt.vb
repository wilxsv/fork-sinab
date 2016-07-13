Partial Public Class dbMOTIVOSNOACEPTACION

#Region " Metodos Agregados "

    Public Function BuscarDescripcion(ByVal DESCRIPCION As String, ByVal IDMOTIVONOACEPTACION As Byte) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_MOTIVOSNOACEPTACION ")
        strSQL.Append("WHERE DESCRIPCION = @DESCRIPCION AND (IDMOTIVONOACEPTACION <> @IDMOTIVONOACEPTACION OR @IDMOTIVONOACEPTACION = 0) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(0).Value = DESCRIPCION
        args(1) = New SqlParameter("@IDMOTIVONOACEPTACION", SqlDbType.TinyInt)
        args(1).Value = IDMOTIVONOACEPTACION

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

#End Region

End Class
