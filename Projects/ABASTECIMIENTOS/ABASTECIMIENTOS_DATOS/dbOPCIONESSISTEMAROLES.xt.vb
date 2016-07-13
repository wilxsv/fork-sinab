Partial Public Class dbOPCIONESSISTEMAROLES

#Region " Metodos Agregados "

    Public Function ObtenerDatasetRolesOpciones() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("R.NOMBRE, ")
        strSQL.Append("R.DESCRIPCION, ")
        strSQL.Append("R.ESTAHABILITADO, ")
        strSQL.Append("OS.DESCRIPCION DESCRIPCIONOPCION, ")
        strSQL.Append("OS.ESTAHABILITADO ESTAHABILITADOOPCION ")
        strSQL.Append("FROM SEGROLES R ")
        strSQL.Append("LEFT OUTER JOIN SEGOPCIONESSISTEMAROLES OSR ")
        strSQL.Append("ON R.IDROL = OSR.IDROL ")
        strSQL.Append("LEFT OUTER JOIN SEGOPCIONESSISTEMA OS ")
        strSQL.Append("ON OSR.IDOPCIONSISTEMA = OS.IDOPCIONSISTEMA ")
        strSQL.Append("ORDER BY R.DESCRIPCION ASC, OS.DESCRIPCION ASC ")

        Return SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString)

    End Function

    Public Function OpcionPermiteEditar(ByVal IDROL As Int32, ByVal URL As String) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("count(*) ")
        strSQL.Append("FROM SEGOPCIONESSISTEMAROLES OSR ")
        strSQL.Append("INNER JOIN SEGOPCIONESSISTEMA OS ")
        strSQL.Append("ON OSR.IDOPCIONSISTEMA = OS.IDOPCIONSISTEMA ")
        strSQL.Append("WHERE OSR.PERMITEEDITAR = 1 ")
        strSQL.Append("AND OSR.IDROL = @IDROL ")
        strSQL.Append("AND lower(left(@URL, len(OS.URL))) = lower(OS.URL)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = IDROL
        args(1) = New SqlParameter("@URL", SqlDbType.VarChar)
        args(1).Value = URL

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStrSeg, CommandType.Text, strSQL.ToString, args) > 0, True, False)

    End Function

#End Region

End Class
