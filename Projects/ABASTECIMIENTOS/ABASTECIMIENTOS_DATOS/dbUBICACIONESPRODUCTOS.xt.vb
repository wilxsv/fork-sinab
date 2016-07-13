Partial Public Class dbUBICACIONESPRODUCTOS

#Region " Métodos Agregados "

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDUBICACION As Int32) As listaUBICACIONESPRODUCTOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDUBICACION = @IDUBICACION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDUBICACION", SqlDbType.Int)
        args(2).Value = IDUBICACION

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaUBICACIONESPRODUCTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New UBICACIONESPRODUCTOS
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.IDPRODUCTO = IDPRODUCTO
                mEntidad.IDUBICACION = IDUBICACION

                mEntidad.IDLOTE = IIf(dr("IDLOTE") Is DBNull.Value, Nothing, dr("IDLOTE"))
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

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDUBICACION As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDUBICACION = @IDUBICACION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDUBICACION", SqlDbType.Int)
        args(2).Value = IDUBICACION

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDUBICACION As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDUBICACION = @IDUBICACION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDUBICACION", SqlDbType.Int)
        args(2).Value = IDUBICACION

        Dim tables(0) As String
        tables(0) = New String("UBICACIONESPRODUCTOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Public Function ObtenerDsUbicacionProducto(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDLOTE As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("UP.IDUBICACION, ")
        strSQL.Append("UP.UBICACION DESCRIPCION ")
        strSQL.Append("FROM SAB_ALM_UBICACIONESPRODUCTOS UP ")
        strSQL.Append("WHERE UP.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND UP.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND (UP.IDLOTE = @IDLOTE OR @IDLOTE = 0) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDLOTE", SqlDbType.Int)
        args(2).Value = IDLOTE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
