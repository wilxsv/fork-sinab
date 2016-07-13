Partial Public Class dbCLAUSULASCONTRATOS

#Region " Metodos Agregados "

    Public Function ObtenerListaPorID(ByVal IDCLAUSULA As Int32) As listaCLAUSULASCONTRATOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDCLAUSULA = @IDCLAUSULA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(0).Value = IDCLAUSULA

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaCLAUSULASCONTRATOS

        Try
            Do While dr.Read()
                Dim mEntidad As New CLAUSULASCONTRATOS
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.IDPROVEEDOR = IIf(dr("IDPROVEEDOR") Is DBNull.Value, Nothing, dr("IDPROVEEDOR"))
                mEntidad.IDCONTRATO = IIf(dr("IDCONTRATO") Is DBNull.Value, Nothing, dr("IDCONTRATO"))
                mEntidad.IDCLAUSULA = IDCLAUSULA
                mEntidad.ENCABEZADOCLAUSULA = IIf(dr("ENCABEZADOCLAUSULA") Is DBNull.Value, Nothing, dr("ENCABEZADOCLAUSULA"))
                mEntidad.ORDEN = IIf(dr("ORDEN") Is DBNull.Value, Nothing, dr("ORDEN"))

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

    Public Function ObtenerDataSetPorID(ByVal IDCLAUSULA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDCLAUSULA = @IDCLAUSULA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(0).Value = IDCLAUSULA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDCLAUSULA As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDCLAUSULA = @IDCLAUSULA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(0).Value = IDCLAUSULA

        Dim tables(0) As String
        tables(0) = New String("CLAUSULASCONTRATOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Public Function verificaExistencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCLAUSULA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCLAUSULA = @IDCLAUSULA ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(1).Value = IDCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(3).Value = IDCLAUSULA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function validaOrden(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal ORDEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ORDEN ")
        strSQL.Append(" FROM SAB_UACI_CLAUSULASCONTRATOS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ") AND (ORDEN = " & ORDEN & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

#End Region

End Class
