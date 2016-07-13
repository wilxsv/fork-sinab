Partial Public Class dbTIPOESTABLECIMIENTOS

#Region " Validaciones Adicionales "

    'Validar codigo Tipo Establecimiento
    Public Function VALIDARNOMBRECORTO(ByVal NOMBRECORTO As String, ByVal IDTIPOESTABLECIMIENTO As Byte) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_TIPOESTABLECIMIENTOS ")
        strSQL.Append("WHERE NOMBRECORTO = @NOMBRECORTO AND (IDTIPOESTABLECIMIENTO <> @IDTIPOESTABLECIMIENTO OR @IDTIPOESTABLECIMIENTO = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@NOMBRECORTO", SqlDbType.VarChar)
        args(0).Value = NOMBRECORTO
        args(1) = New SqlParameter("@IDTIPOESTABLECIMIENTO", SqlDbType.TinyInt)
        args(1).Value = IDTIPOESTABLECIMIENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 1, 0)

    End Function

    'Validar Nombre Tipo Establecimiento
    Public Function VALIDARDESCRIPCION(ByVal DESCRIPCION As String, ByVal IDTIPOESTABLECIMIENTO As Byte) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_TIPOESTABLECIMIENTOS ")
        strSQL.Append("WHERE DESCRIPCION = @DESCRIPCION AND (IDTIPOESTABLECIMIENTO <> @IDTIPOESTABLECIMIENTO OR @IDTIPOESTABLECIMIENTO = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(0).Value = DESCRIPCION
        args(0) = New SqlParameter("@IDTIPOESTABLECIMIENTO", SqlDbType.TinyInt)
        args(0).Value = IDTIPOESTABLECIMIENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 1, 0)

    End Function

    Public Function ObtenerListaPorOrden(ByVal tipo As Integer) As listaTIPOESTABLECIMIENTOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        Select Case tipo
            Case Is = 1
                strSQL.Append(" order by NOMBRECORTO ASC ")
            Case Is = 0
                strSQL.Append(" order by NOMBRECORTO DESC ")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaTIPOESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New TIPOESTABLECIMIENTOS
                mEntidad.IDTIPOESTABLECIMIENTO = IIf(dr("IDTIPOESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDTIPOESTABLECIMIENTO"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
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

#End Region

End Class
