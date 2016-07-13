Partial Public Class dbUNIDADMEDIDAS

#Region " Métodos Agregados "

    Public Function ObtenerDataSetIDUNIDADMEDIDA(ByVal unidadMedida As String) As Int64

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE DESCRIPCION = @DESCRIPCION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(0).Value = unidadMedida

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args).Tables(0).Rows(0).Item("IDUNIDADMEDIDA")

    End Function

#End Region

#Region " Validaciones Agregadas "

    'Validar nombre corto
    Public Function ValidarDescripcion(ByVal DESCRIPCION As String, ByVal IDUNIDADMEDIDA As Int32) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_UNIDADMEDIDAS ")
        strSQL.Append("WHERE DESCRIPCION = @DESCRIPCION AND (IDUNIDADMEDIDA <> @IDUNIDADMEDIDA OR @IDUNIDADMEDIDA = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(0).Value = DESCRIPCION
        args(1) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(1).Value = IDUNIDADMEDIDA

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 1, 0)

    End Function

    'Validar Descripcion
    Public Function ValidarDescripcionlarga(ByVal DESCRIPCIONLARGA As String, ByVal IDUNIDADMEDIDA As Int32) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_UNIDADMEDIDAS ")
        strSQL.Append("WHERE DESCRIPCIONLARGA = @DESCRIPCIONLARGA AND (IDUNIDADMEDIDA <> @IDUNIDADMEDIDA OR @IDUNIDADMEDIDA = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCIONLARGA", SqlDbType.VarChar)
        args(0).Value = DESCRIPCIONLARGA
        args(1) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(1).Value = IDUNIDADMEDIDA

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 1, 0)

    End Function

    Public Function ObtenerListaPorSuministro(ByVal IDSUMINISTRO As Integer) As listaUNIDADMEDIDAS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT U.* ")
        strSQL.Append("FROM SAB_CAT_UNIDADMEDIDAS U ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDASUMINISTROS S ")
        strSQL.Append("ON U.IDUNIDADMEDIDA = S.IDUNIDADMEDIDA ")
        strSQL.Append("WHERE S.IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaUNIDADMEDIDAS

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    Dim mEntidad As New UNIDADMEDIDAS
                    mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                    mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                    mEntidad.DESCRIPCIONLARGA = IIf(dr("DESCRIPCIONLARGA") Is DBNull.Value, Nothing, dr("DESCRIPCIONLARGA"))
                    mEntidad.UNIDADESCONTENIDAS = IIf(dr("UNIDADESCONTENIDAS") Is DBNull.Value, Nothing, dr("UNIDADESCONTENIDAS"))
                    mEntidad.CANTIDADDECIMAL = IIf(dr("CANTIDADDECIMAL") Is DBNull.Value, Nothing, dr("CANTIDADDECIMAL"))
                    mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                    mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                    mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                    mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                    mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                    lista.Add(mEntidad)
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

#End Region

End Class
