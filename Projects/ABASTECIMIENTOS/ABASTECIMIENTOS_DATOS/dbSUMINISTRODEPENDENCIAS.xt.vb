Partial Public Class dbSUMINISTRODEPENDENCIAS

    Public Function ObtenerDataSetListaSuministrosDependencias() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SD.IDDEPENDENCIA, SD.IDSUMINISTRO, D.NOMBRE AS DEPENDENCIA, S.DESCRIPCION AS SUMINISTRO, SD.AUUSUARIOCREACION, ")
        strSQL.Append(" SD.AUFECHACREACION, SD.AUUSUARIOMODIFICACION, SD.AUFECHAMODIFICACION, SD.ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_DEPENDENCIAS AS D INNER JOIN ")
        strSQL.Append(" SAB_CAT_SUMINISTRODEPENDENCIAS AS SD ON D.IDDEPENDENCIA = SD.IDDEPENDENCIA INNER JOIN ")
        strSQL.Append(" SAB_CAT_SUMINISTROS AS S ON SD.IDSUMINISTRO = S.IDSUMINISTRO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function BuscarSuministrosDependencias(ByVal IDSUMINISTRO As Int32, ByVal IDDEPENDENCIA As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDDEPENDENCIA, IDSUMINISTRO ")
        strSQL.Append(" FROM(SAB_CAT_SUMINISTRODEPENDENCIAS) ")
        strSQL.Append(" WHERE (IDDEPENDENCIA = @IDDEPENDENCIA) AND (IDSUMINISTRO = @IDSUMINISTRO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDDEPENDENCIA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
