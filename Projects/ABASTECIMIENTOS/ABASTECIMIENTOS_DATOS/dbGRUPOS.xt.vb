Partial Public Class dbGRUPOS

#Region "Metodos adicionales"

    Public Function ObtenerListaPorSuministro(ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDGRUPO, ")
        strSQL.Append("IDSUMINISTRO, ")
        strSQL.Append("CORRELATIVO, ")
        'strSQL.Append("DESCRIPCION, ")
        strSQL.Append("'(' + CORRELATIVO + ') ' + DESCRIPCION DESCRIPCION, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_GRUPOS ")
        strSQL.Append("WHERE IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append("ORDER BY CORRELATIVO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO

        'Dim dr As SqlDataReader
        'dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        'Dim lista As New listaGRUPOS

        'Try
        '    If dr.HasRows Then
        '        Do While dr.Read()
        '            Dim mEntidad As New GRUPOS
        '            mEntidad.IDGRUPO = IIf(dr("IDGRUPO") Is DBNull.Value, Nothing, dr("IDGRUPO"))
        '            mEntidad.IDSUMINISTRO = IIf(dr("IDSUMINISTRO") Is DBNull.Value, Nothing, dr("IDSUMINISTRO"))
        '            mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
        '            mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
        '            mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
        '            mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
        '            mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
        '            mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
        '            mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
        '            lista.Add(mEntidad)
        '        Loop
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    dr.Close()
        'End Try

        'Return lista
        Return ds

    End Function

    Public Function ObtenerListaOrdenada() As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("ORDER BY DESCRIPCION ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function DevolverCorrGrupo(ByVal IDGRUPO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT CORRELATIVO ")
        strSQL.Append(" FROM SAB_CAT_GRUPOS ")
        strSQL.Append("WHERE IDGRUPO = @IDGRUPO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaConSuministro() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDGRUPO, ")
        strSQL.Append("s.idsuministro as suministro,g.descripcion as grupo, S.DESCRIPCION AS IDSUMINISTRO, ")
        strSQL.Append("G.CORRELATIVO, ")
        strSQL.Append("G.DESCRIPCION, ")
        strSQL.Append("G.AUUSUARIOCREACION, ")
        strSQL.Append("G.AUFECHACREACION, ")
        strSQL.Append("G.AUUSUARIOMODIFICACION, ")
        strSQL.Append("G.AUFECHAMODIFICACION, ")
        strSQL.Append("G.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_GRUPOS G INNER JOIN SAB_CAT_SUMINISTROS S ON G.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("ORDER BY G.DESCRIPCION")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ValidarCorrelativoSuministro(ByVal CORRELATIVO As String, ByVal IDSUMINISTRO As Int32, ByVal IDGRUPO As Int32) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_GRUPOS ")
        strSQL.Append("WHERE CORRELATIVO = @CORRELATIVO ")
        strSQL.Append("AND IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append("AND (IDGRUPO <> @IDGRUPO OR @IDGRUPO = 0) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@CODIGOPROVEEDOR", SqlDbType.VarChar)
        args(0).Value = CORRELATIVO
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(2).Value = IDGRUPO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerListaPorUT(ByVal IDSUMINISTRO As Integer, ByVal AREATECNICA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("IDGRUPO, ")
        strSQL.Append("'('+CORRGRUPO+') '+ ")
        strSQL.Append("DESCGRUPO  as DESCGRUPO,CORRGRUPO ")
        strSQL.Append("from vv_catalogoproductos ")
        strSQL.Append("WHERE IDSUMINISTRO = @IDSUMINISTRO AND AREATECNICA=@AREATECNICA ")
        strSQL.Append("ORDER BY CORRGRUPO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO
        args(1) = New SqlParameter("@AREATECNICA", SqlDbType.Int)
        args(1).Value = AREATECNICA
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerListaPorUTyGU(ByVal IDSUMINISTRO As Integer, ByVal AREATECNICA As Integer, ByVal GU As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("IDGRUPO, ")
        strSQL.Append("'('+CORRGRUPO+') '+ ")
        strSQL.Append("DESCGRUPO  as DESCGRUPO,CORRGRUPO ")
        strSQL.Append("from vv_CATALOGOPRODUCTOS_SUMINISTRODEPENDENCIAS ")
        strSQL.Append("WHERE IDSUMINISTRO = @IDSUMINISTRO AND AREATECNICA=@AREATECNICA AND TIPOUACI=@TIPOUACI ")
        strSQL.Append("ORDER BY CORRGRUPO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO
        args(1) = New SqlParameter("@AREATECNICA", SqlDbType.Int)
        args(1).Value = AREATECNICA
        args(2) = New SqlParameter("@TIPOUACI", SqlDbType.Int)
        args(2).Value = GU
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
#End Region

End Class
