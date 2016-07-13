Partial Public Class dbMUNICIPIOS

#Region " Validaciones Agregadas "

    Public Function VALIDARNOMBRE(ByVal NOMBRE As String, ByVal IDMUNICIPIO As Int16) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_MUNICIPIOS ")
        strSQL.Append("WHERE NOMBRE = @NOMBRE AND (IDMUNICIPIO <> @IDMUNICIPIO OR @IDMUNICIPIO = 0) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(0).Value = NOMBRE
        args(1) = New SqlParameter("@IDMUNICIPIO", SqlDbType.SmallInt)
        args(1).Value = IDMUNICIPIO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 0, 1)

    End Function

    'obtener Dataset de lista de almacenes "Eduardo"
    Public Function ObtenerDataSetListaMunicipios() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT M.IDMUNICIPIO, M.CODIGOMUNICIPIO, M.IDDEPARTAMENTO, M.NOMBRE, M.AUUSUARIOCREACION, M.AUFECHACREACION, ")
        strSQL.Append(" M.AUUSUARIOMODIFICACION, M.AUFECHAMODIFICACION, M.ESTASINCRONIZADA, D.NOMBRE AS DEPARTAMENTO ")
        strSQL.Append(" FROM SAB_CAT_MUNICIPIOS AS M INNER JOIN ")
        strSQL.Append(" SAB_CAT_DEPARTAMENTOS AS D ON M.IDDEPARTAMENTO = D.IDDEPARTAMENTO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

#End Region

End Class
