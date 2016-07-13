Imports System.Text

Public Class dbSUMINISTRODEPENDENCIAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SUMINISTRODEPENDENCIAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_SUMINISTRODEPENDENCIAS ")
        strSQL.Append(" SET AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDDEPENDENCIA = @IDDEPENDENCIA ")
        strSQL.Append(" AND IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(0).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(1) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(1).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(2) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(3) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(4) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(4).Value = lEntidad.ESTASINCRONIZADA
        args(5) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(5).Value = lEntidad.IDDEPENDENCIA
        args(6) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(6).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SUMINISTRODEPENDENCIAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_SUMINISTRODEPENDENCIAS ")
        strSQL.Append(" ( IDDEPENDENCIA, ")
        strSQL.Append(" IDSUMINISTRO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDDEPENDENCIA, ")
        strSQL.Append(" @IDSUMINISTRO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(0).Value = lEntidad.IDDEPENDENCIA
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = lEntidad.IDSUMINISTRO
        args(2) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(3) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(4) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(5) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(5).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(6) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(6).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SUMINISTRODEPENDENCIAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_SUMINISTRODEPENDENCIAS ")
        strSQL.Append(" WHERE IDDEPENDENCIA = @IDDEPENDENCIA ")
        strSQL.Append(" AND IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(0).Value = lEntidad.IDDEPENDENCIA
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SUMINISTRODEPENDENCIAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDDEPENDENCIA = @IDDEPENDENCIA ")
        strSQL.Append(" AND IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(0).Value = lEntidad.IDDEPENDENCIA
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = lEntidad.IDSUMINISTRO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Return -1

    End Function

    Public Function ObtenerListaPorID(ByVal IDDEPENDENCIA As Int32, ByVal IDSUMINISTRO As Int32) As listaSUMINISTRODEPENDENCIAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDDEPENDENCIA = @IDDEPENDENCIA ")
        strSQL.Append(" AND IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(0).Value = IDDEPENDENCIA
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaSUMINISTRODEPENDENCIAS

        Try
            Do While dr.Read()
                Dim mEntidad As New SUMINISTRODEPENDENCIAS
                mEntidad.IDDEPENDENCIA = IDDEPENDENCIA
                mEntidad.IDSUMINISTRO = IDSUMINISTRO
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDDEPENDENCIA As Int32, ByVal IDSUMINISTRO As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDDEPENDENCIA = @IDDEPENDENCIA ")
        strSQL.Append(" AND IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(0).Value = IDDEPENDENCIA
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDDEPENDENCIA As Int32, ByVal IDSUMINISTRO As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDDEPENDENCIA = @IDDEPENDENCIA ")
        strSQL.Append(" AND IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(0).Value = IDDEPENDENCIA
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO

        Dim tables(0) As String
        tables(0) = New String("SUMINISTRODEPENDENCIAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDDEPENDENCIA, ")
        strSQL.Append(" IDSUMINISTRO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTRODEPENDENCIAS ")

    End Sub

    Public Function ObtenerIdSuministro(ByVal IDDEPENDENCIA As Int32) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("   Select IDSUMINISTRO ")
        strSQL.Append(" from SAB_CAT_SUMINISTRODEPENDENCIAS ")
        strSQL.Append(" where iddependencia= @IDDEPENDENCIA")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(0).Value = IDDEPENDENCIA

        Dim ds As Integer
        ds = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
