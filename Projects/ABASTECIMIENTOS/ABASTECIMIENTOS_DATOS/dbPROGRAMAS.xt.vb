Imports System.Text

Partial Public Class dbPROGRAMAS

    'Validar si un nombre codigo ya existe
    '02/03/07 Responsable Eduardo Rodriguez
    Public Function BuscarCodigo(ByVal CODIGO As String, ByVal IDPROGRAMA As Int16) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_PROGRAMAS ")
        strSQL.Append("WHERE CODIGO = @CODIGO AND (IDPROGRAMA <> @IDPROGRAMA OR @IDPROGRAMA = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(0).Value = CODIGO
        args(1) = New SqlParameter("@IDPROGRAMA", SqlDbType.SmallInt)
        args(1).Value = IDPROGRAMA

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 1, 0)

    End Function

    Public Function obtenerProgramas() As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append("SELECT idPrograma, nombre FROM sab_cat_programas ORDER BY nombre ASC ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString)

    End Function

End Class
