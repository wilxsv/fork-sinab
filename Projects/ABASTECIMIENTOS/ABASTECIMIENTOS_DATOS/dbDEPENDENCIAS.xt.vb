Partial Public Class dbDEPENDENCIAS

#Region " Validaciones adicionales "

    Public Function ValidarNombre(ByVal NOMBRE As String, ByVal IDDEPENDENCIA As Int32) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_DEPENDENCIAS ")
        strSQL.Append("WHERE NOMBRE = @NOMBRE AND (IDDEPENDENCIA <> @IDDEPENDENCIA OR @IDDEPENDENCIA = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(0).Value = NOMBRE
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDDEPENDENCIA

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 0, 1)

    End Function

#End Region

    Public Function ObtenerListaOrden(ByVal tipo As Integer) As listaDEPENDENCIAS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        Select Case tipo
            Case Is = 1
                strSQL.Append(" order by NOMBRE ASC ")
            Case Is = 0
                strSQL.Append(" order by NOMBRE DESC ")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaDEPENDENCIAS

        Try
            Do While dr.Read()
                Dim mEntidad As New DEPENDENCIAS
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerNOMDEPENDENCIA(ByVal IDDEPENDENCIA As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT CODIGO ")
        strSQL.Append(" FROM SAB_CAT_DEPENDENCIAS where iddependencia = " & IDDEPENDENCIA & "")

        Dim ds As String
        ds = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerCODDEPENDENCIA(ByVal IDDEPENDENCIA As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT CODIGO ")
        strSQL.Append(" FROM SAB_CAT_DEPENDENCIAS where iddependencia = " & IDDEPENDENCIA & "")

        Dim ds As String
        ds = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerdsDependencia() As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("ORDER BY NOMBRE")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerdsAreaTecnica() As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE AREATECNICA=1 ORDER BY NOMBRE")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
End Class
