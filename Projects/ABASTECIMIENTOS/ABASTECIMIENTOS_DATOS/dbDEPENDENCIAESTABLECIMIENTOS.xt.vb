Partial Public Class dbDEPENDENCIAESTABLECIMIENTOS

    Public Function obtenerDependenciaEstablecimiento(ByVal IDESTABLECIMIENTO As Integer) As System.Data.DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DE.IDDEPENDENCIA, ")
        strSQL.Append("D.NOMBRE ")
        strSQL.Append("FROM SAB_CAT_DEPENDENCIAS D ")
        strSQL.Append("INNER JOIN SAB_CAT_DEPENDENCIAESTABLECIMIENTOS DE ")
        strSQL.Append("ON D.IDDEPENDENCIA = DE.IDDEPENDENCIA ")
        strSQL.Append("WHERE ")
        strSQL.Append("(DE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetListaDependenciaEstablecimiento() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DPE.IDDEPENDENCIA, DPE.IDESTABLECIMIENTO, DE.NOMBRE DEPENDENCIA, ES.NOMBRE ESTABLECIMIENTO, ")
        strSQL.Append("DPE.AUUSUARIOCREACION, DPE.AUFECHACREACION, DPE.AUUSUARIOMODIFICACION, DPE.AUFECHAMODIFICACION, DPE.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_DEPENDENCIAESTABLECIMIENTOS DPE INNER JOIN SAB_CAT_ESTABLECIMIENTOS ES ")
        strSQL.Append("ON DPE.IDESTABLECIMIENTO = ES.IDESTABLECIMIENTO INNER JOIN SAB_CAT_DEPENDENCIAS DE ")
        strSQL.Append("ON DPE.IDDEPENDENCIA = DE.IDDEPENDENCIA ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function BuscarEstablecimientoDependencia(ByVal IDestablecimiento As Int32, ByVal IDdependencia As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDESTABLECIMIENTO, IDDEPENDENCIA ")
        strSQL.Append(" FROM SAB_CAT_DEPENDENCIAESTABLECIMIENTOS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDDEPENDENCIA = @IDDEPENDENCIA) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDestablecimiento
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDdependencia

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
