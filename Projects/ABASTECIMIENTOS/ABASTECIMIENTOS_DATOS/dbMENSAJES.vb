Imports System.Text

Public Class dbMENSAJES
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MENSAJES
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDMENSAJE = 0 _
        Or lEntidad.IDMENSAJE = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDMENSAJE = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_MENSAJES")
        strSQL.Append(" SET MENSAJE = @MENSAJE, ")
        strSQL.Append(" FECHAINICIO = @FECHAINICIO, ")
        strSQL.Append(" FECHAFIN = @FECHAFIN, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDMENSAJE = @IDMENSAJE ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@MENSAJE", SqlDbType.VarChar)
        args(0).Value = lEntidad.MENSAJE
        args(1) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(1).Value = IIf(lEntidad.FECHAINICIO = Nothing, DBNull.Value, lEntidad.FECHAINICIO)
        args(2) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(2).Value = IIf(lEntidad.FECHAFIN = Nothing, DBNull.Value, lEntidad.FECHAFIN)
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(7) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(7).Value = lEntidad.ESTASINCRONIZADA
        args(8) = New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        args(8).Value = lEntidad.IDMENSAJE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MENSAJES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_MENSAJES ")
        strSQL.Append(" ( IDMENSAJE, ")
        strSQL.Append(" MENSAJE, ")
        strSQL.Append(" FECHAINICIO, ")
        strSQL.Append(" FECHAFIN, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDMENSAJE, ")
        strSQL.Append(" @MENSAJE, ")
        strSQL.Append(" @FECHAINICIO, ")
        strSQL.Append(" @FECHAFIN, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        args(0).Value = lEntidad.IDMENSAJE
        args(1) = New SqlParameter("@MENSAJE", SqlDbType.VarChar)
        args(1).Value = lEntidad.MENSAJE
        args(2) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(2).Value = IIf(lEntidad.FECHAINICIO = Nothing, DBNull.Value, lEntidad.FECHAINICIO)
        args(3) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.FECHAFIN = Nothing, DBNull.Value, lEntidad.FECHAFIN)
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MENSAJES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_MENSAJES ")
        strSQL.Append(" WHERE IDMENSAJE = @IDMENSAJE ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        args(0).Value = lEntidad.IDMENSAJE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MENSAJES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDMENSAJE = @IDMENSAJE ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        args(0).Value = lEntidad.IDMENSAJE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.MENSAJE = IIf(.Item("MENSAJE") Is DBNull.Value, Nothing, .Item("MENSAJE"))
                lEntidad.FECHAINICIO = IIf(.Item("FECHAINICIO") Is DBNull.Value, Nothing, .Item("FECHAINICIO"))
                lEntidad.FECHAFIN = IIf(.Item("FECHAFIN") Is DBNull.Value, Nothing, .Item("FECHAFIN"))
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

        Dim lEntidad As MENSAJES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDMENSAJE),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_MENSAJES ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaMENSAJES

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaMENSAJES

        Try
            Do While dr.Read()
                Dim mEntidad As New MENSAJES
                mEntidad.IDMENSAJE = IIf(dr("IDMENSAJE") Is DBNull.Value, Nothing, dr("IDMENSAJE"))
                mEntidad.MENSAJE = IIf(dr("MENSAJE") Is DBNull.Value, Nothing, dr("MENSAJE"))
                mEntidad.FECHAINICIO = IIf(dr("FECHAINICIO") Is DBNull.Value, Nothing, dr("FECHAINICIO"))
                mEntidad.FECHAFIN = IIf(dr("FECHAFIN") Is DBNull.Value, Nothing, dr("FECHAFIN"))
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
        tables(0) = New String("MENSAJES")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDMENSAJE, ")
        strSQL.Append(" MENSAJE, ")
        strSQL.Append(" FECHAINICIO, ")
        strSQL.Append(" FECHAFIN, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_MENSAJES ")

    End Sub

#End Region

End Class
