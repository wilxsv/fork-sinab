Partial Public Class dbPLANTILLAS

#Region " Métodos Agregados "

    Public Function ObtenerDataSetPlantilla(ByVal IDPLANTILLA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPLANTILLA = @IDPLANTILLA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPLANTILLA", SqlDbType.BigInt)
        args(0).Value = IDPLANTILLA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ExisteNombrePlantilla(ByVal NOMBRE As String) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT isnull(count(*), 0) ")
        strSQL.Append(" FROM SAB_CAT_PLANTILLAS ")
        strSQL.Append(" WHERE NOMBRE = @NOMBRE ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(0).Value = NOMBRE

        Dim i As Integer
        i = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return IIf(i = 0, False, True)

    End Function

#End Region

End Class
