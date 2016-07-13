Partial Public Class dbNIVELESUSO

    Public Function ObtenerDescripcionNU(ByVal IDNIVELUSO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DESCRIPCION ")
        strSQL.Append("FROM SAB_CAT_NIVELESUSO ")
        strSQL.Append("WHERE IDNIVELUSO = @IDNIVELUSO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDNIVELUSO", SqlDbType.TinyInt)
        args(0).Value = IDNIVELUSO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    'Validar si un nombre corto ya existe
    '04/01/07 Responsable SONIA MARIBEL VIANA
    Public Function BuscarNOMBRE(ByVal NOMBRECORTO As String, ByVal IDNIVELUSO As Byte) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_NIVELESUSO ")
        strSQL.Append("WHERE NOMBRECORTO = @NOMBRECORTO AND (IDNIVELUSO <> @IDNIVELUSO OR @IDNIVELUSO = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@NOMBRECORTO", SqlDbType.VarChar)
        args(0).Value = NOMBRECORTO
        args(1) = New SqlParameter("@IDNIVELUSO", SqlDbType.TinyInt)
        args(1).Value = IDNIVELUSO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 1, 0)

    End Function

    Public Function ObtenerNivelesUsoLetras(Optional ByVal SOLOLETRAS As Boolean = False) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDNIVELUSO, NOMBRECORTO + ' ' + DESCRIPCION AS NIVELUSO ")
        strSQL.Append("FROM SAB_CAT_NIVELESUSO ")

        If SOLOLETRAS = False Then
            strSQL.Append("WHERE IDNIVELUSO > 6")
        Else
            strSQL.Append("WHERE IDNIVELUSO <= 6")
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

End Class
