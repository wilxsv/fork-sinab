Imports System.Text

Public Class dbSUMINISTROS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SUMINISTROS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDSUMINISTRO = 0 _
            Or lEntidad.IDSUMINISTRO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDSUMINISTRO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_SUMINISTROS ")
        strSQL.Append(" SET IDTIPOSUMINISTRO = @IDTIPOSUMINISTRO, ")
        strSQL.Append(" CORRELATIVO = @CORRELATIVO, ")
        strSQL.Append(" DESCRIPCION = @DESCRIPCION, ")
        strSQL.Append(" MONTODISPONIBLE = @MONTODISPONIBLE, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOSUMINISTRO", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOSUMINISTRO
        args(1) = New SqlParameter("@CORRELATIVO", SqlDbType.VarChar)
        args(1).Value = lEntidad.CORRELATIVO
        args(2) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(2).Value = lEntidad.DESCRIPCION
        args(3) = New SqlParameter("@MONTODISPONIBLE", SqlDbType.Decimal)
        args(3).Value = IIf(lEntidad.MONTODISPONIBLE = Nothing, DBNull.Value, lEntidad.MONTODISPONIBLE)
        args(4) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(5) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(5).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(6) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(7) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(8) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(8).Value = lEntidad.ESTASINCRONIZADA
        args(9) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(9).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SUMINISTROS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_SUMINISTROS ")
        strSQL.Append(" ( IDSUMINISTRO, ")
        strSQL.Append(" IDTIPOSUMINISTRO, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" MONTODISPONIBLE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDSUMINISTRO, ")
        strSQL.Append(" @IDTIPOSUMINISTRO, ")
        strSQL.Append(" @CORRELATIVO, ")
        strSQL.Append(" @DESCRIPCION, ")
        strSQL.Append(" @MONTODISPONIBLE, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = lEntidad.IDSUMINISTRO
        args(1) = New SqlParameter("@IDTIPOSUMINISTRO", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOSUMINISTRO
        args(2) = New SqlParameter("@CORRELATIVO", SqlDbType.VarChar)
        args(2).Value = lEntidad.CORRELATIVO
        args(3) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(3).Value = lEntidad.DESCRIPCION
        args(4) = New SqlParameter("@MONTODISPONIBLE", SqlDbType.Decimal)
        args(4).Value = IIf(lEntidad.MONTODISPONIBLE = Nothing, DBNull.Value, lEntidad.MONTODISPONIBLE)
        args(5) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(6) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(6).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(7) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(8) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(9) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(9).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SUMINISTROS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_SUMINISTROS ")
        strSQL.Append(" WHERE IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SUMINISTROS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = lEntidad.IDSUMINISTRO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDTIPOSUMINISTRO = IIf(.Item("IDTIPOSUMINISTRO") Is DBNull.Value, Nothing, .Item("IDTIPOSUMINISTRO"))
                lEntidad.CORRELATIVO = IIf(.Item("CORRELATIVO") Is DBNull.Value, Nothing, .Item("CORRELATIVO"))
                lEntidad.DESCRIPCION = IIf(.Item("DESCRIPCION") Is DBNull.Value, Nothing, .Item("DESCRIPCION"))
                lEntidad.MONTODISPONIBLE = IIf(.Item("MONTODISPONIBLE") Is DBNull.Value, Nothing, .Item("MONTODISPONIBLE"))
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

        Dim lEntidad As SUMINISTROS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDSUMINISTRO),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTROS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaSUMINISTROS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaSUMINISTROS

        Try
            Do While dr.Read()
                Dim mEntidad As New SUMINISTROS
                mEntidad.IDSUMINISTRO = IIf(dr("IDSUMINISTRO") Is DBNull.Value, Nothing, dr("IDSUMINISTRO"))
                mEntidad.IDTIPOSUMINISTRO = IIf(dr("IDTIPOSUMINISTRO") Is DBNull.Value, Nothing, dr("IDTIPOSUMINISTRO"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
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

    Public Function ObtenerDataSetPorID() As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim tables(0) As String
        tables(0) = New String("SUMINISTROS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDSUMINISTRO, ")
        strSQL.Append(" IDTIPOSUMINISTRO, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" MONTODISPONIBLE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTROS ")

    End Sub

#End Region

End Class
