Partial Public Class dbSUBGRUPOS

#Region " Métodos adicionales "

    Public Function ObtenerSubgruposporSuministro(ByVal idsuministro As Integer) As listaSUBGRUPOS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_CAT_SUBGRUPOS.IDSUBGRUPO, SAB_CAT_SUBGRUPOS.CORRELATIVO, SAB_CAT_SUBGRUPOS.IDGRUPO, SAB_CAT_SUBGRUPOS.DESCRIPCION, ")
        strSQL.Append("    SAB_CAT_SUBGRUPOS.AUUSUARIOCREACION, SAB_CAT_SUBGRUPOS.AUFECHACREACION, SAB_CAT_SUBGRUPOS.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" SAB_CAT_SUBGRUPOS.AUFECHAMODIFICACION, SAB_CAT_SUBGRUPOS.ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_GRUPOS INNER JOIN ")
        strSQL.Append("     SAB_CAT_SUBGRUPOS ON SAB_CAT_GRUPOS.IDGRUPO = SAB_CAT_SUBGRUPOS.IDGRUPO INNER JOIN ")
        strSQL.Append(" SAB_CAT_SUMINISTROS ON SAB_CAT_GRUPOS.IDSUMINISTRO = SAB_CAT_SUMINISTROS.IDSUMINISTRO ")
        strSQL.Append(" WHERE (SAB_CAT_SUMINISTROS.IDSUMINISTRO = " & idsuministro & ") ")
        strSQL.Append(" ORDER BY SAB_CAT_SUBGRUPOS.DESCRIPCION")

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaSUBGRUPOS

        Try
            Do While dr.Read()
                Dim mEntidad As New SUBGRUPOS
                mEntidad.IDSUBGRUPO = IIf(dr("IDSUBGRUPO") Is DBNull.Value, Nothing, dr("IDSUBGRUPO"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.IDGRUPO = IIf(dr("IDGRUPO") Is DBNull.Value, Nothing, dr("IDGRUPO"))
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

    Public Function ObtenerListaPorGrupo(ByVal IDGRUPO As Integer) As listaSUBGRUPOS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDSUBGRUPO, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" IDGRUPO, ")
        'strSQL.Append(" DESCRIPCION, ")
        strSQL.Append("'(' + CORRELATIVO + ') ' + DESCRIPCION DESCRIPCION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_SUBGRUPOS WHERE IDGRUPO = @IDGRUPO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaSUBGRUPOS

        Try
            Do While dr.Read()
                Dim mEntidad As New SUBGRUPOS
                mEntidad.IDSUBGRUPO = IIf(dr("IDSUBGRUPO") Is DBNull.Value, Nothing, dr("IDSUBGRUPO"))
                mEntidad.IDGRUPO = IIf(dr("IDGRUPO") Is DBNull.Value, Nothing, dr("IDGRUPO"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
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

    Public Function DevolverCorrSubgrupo(ByVal IDSUBGRUPO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT CORRELATIVO ")
        strSQL.Append(" FROM SAB_CAT_SUBGRUPOS ")
        strSQL.Append(" WHERE IDSUBGRUPO = '" & IDSUBGRUPO & "'")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerListaPorGrupoUT(ByVal IDGRUPO As Integer, ByVal AREATECNICA As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT IDSUBGRUPO, ")
        strSQL.Append(" '('+CORRSUBGRUPO+') '+ ")
        strSQL.Append(" DESCSUBGRUPO as DESCSUBGRUPO, CORRSUBGRUPO ")
        strSQL.Append(" from vv_catalogoproductos WHERE IDGRUPO = @IDGRUPO AND AREATECNICA=@AREATECNICA ORDER BY CORRSUBGRUPO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO
        args(1) = New SqlParameter("@AREATECNICA", SqlDbType.Int)
        args(1).Value = AREATECNICA

        Dim dr As DataSet
        dr = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return dr

    End Function

    Public Function ObtenerListaPorGrupoUTyGU(ByVal IDGRUPO As Integer, ByVal AREATECNICA As Int16, ByVal GU As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT IDSUBGRUPO, ")
        strSQL.Append(" '('+CORRSUBGRUPO+') '+ ")
        strSQL.Append(" DESCSUBGRUPO as DESCSUBGRUPO, CORRSUBGRUPO ")
        strSQL.Append(" from vv_CATALOGOPRODUCTOS_SUMINISTRODEPENDENCIAS WHERE IDGRUPO = @IDGRUPO AND AREATECNICA=@AREATECNICA AND TIPOUACI=@TIPOUACI ORDER BY CORRSUBGRUPO")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO
        args(1) = New SqlParameter("@AREATECNICA", SqlDbType.Int)
        args(1).Value = AREATECNICA
        args(2) = New SqlParameter("@TIPOUACI", SqlDbType.Int)
        args(2).Value = GU
        Dim dr As DataSet
        dr = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return dr

    End Function
#End Region

End Class
