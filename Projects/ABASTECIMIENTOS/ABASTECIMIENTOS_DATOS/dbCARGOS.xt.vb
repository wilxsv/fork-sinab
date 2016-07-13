Partial Public Class dbCARGOS

#Region " Metodos Agregados "

    Public Function ObtenerListaorden(ByVal tipo As Integer) As listaCARGOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        Select Case tipo
            Case Is = 1
                strSQL.Append(" order by DESCRIPCION ASC ")
            Case Is = 0
                strSQL.Append(" order by DESCRIPCION DESC ")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaCARGOS

        Try
            Do While dr.Read()
                Dim mEntidad As New CARGOS
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
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

    Public Function BuscarCargosEnEmpleados(ByVal IDCARGO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_EMPLEADOS ")
        strSQL.Append("WHERE IDCARGO = @IDCARGO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDCARGO", SqlDbType.Int)
        args(0).Value = IDCARGO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

#End Region

End Class
