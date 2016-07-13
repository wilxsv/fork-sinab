Imports System.Text

Public Class dbESPECIFICOSGASTO
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ESPECIFICOSGASTO
        lEntidad = aEntidad

        Dim lID As Int16

        If lEntidad.IDESPECIFICOGASTO = 0 _
            Or lEntidad.IDESPECIFICOGASTO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDESPECIFICOGASTO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_ESPECIFICOSGASTO ")
        strSQL.Append("SET CODIGO = @CODIGO, ")
        strSQL.Append("NOMBRE = @NOMBRE, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDESPECIFICOGASTO = @IDESPECIFICOGASTO ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(0).Value = lEntidad.IDESPECIFICOGASTO
        args(1) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(1).Value = lEntidad.CODIGO
        args(2) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(2).Value = lEntidad.NOMBRE
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ESPECIFICOSGASTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_ESPECIFICOSGASTO ")
        strSQL.Append("( IDESPECIFICOGASTO, ")
        strSQL.Append("CODIGO, ")
        strSQL.Append("NOMBRE, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("ESTASINCRONIZADA) ")
        strSQL.Append("VALUES ")
        strSQL.Append("( @IDESPECIFICOGASTO, ")
        strSQL.Append("@CODIGO, ")
        strSQL.Append("@NOMBRE, ")
        strSQL.Append("@AUUSUARIOCREACION, ")
        strSQL.Append("@AUFECHACREACION, ")
        strSQL.Append("@ESTASINCRONIZADA) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(0).Value = lEntidad.IDESPECIFICOGASTO
        args(1) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(1).Value = lEntidad.CODIGO
        args(2) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(2).Value = lEntidad.NOMBRE
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ESPECIFICOSGASTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_ESPECIFICOSGASTO ")
        strSQL.Append("WHERE IDESPECIFICOGASTO = @IDESPECIFICOGASTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(0).Value = lEntidad.IDESPECIFICOGASTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ESPECIFICOSGASTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESPECIFICOGASTO = @IDESPECIFICOGASTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(0).Value = lEntidad.IDESPECIFICOGASTO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.CODIGO = IIf(.Item("CODIGO") Is DBNull.Value, Nothing, .Item("CODIGO"))
                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
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

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDESPECIFICOGASTO), 0) + 1 ")
        strSQL.Append("FROM SAB_CAT_ESPECIFICOSGASTO ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaESPECIFICOSGASTO

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaESPECIFICOSGASTO

        Try
            Do While dr.Read()
                Dim mEntidad As New ESPECIFICOSGASTO
                mEntidad.IDESPECIFICOGASTO = IIf(dr("IDESPECIFICOGASTO") Is DBNull.Value, Nothing, dr("IDESPECIFICOGASTO"))
                mEntidad.CODIGO = IIf(dr("CODIGO") Is DBNull.Value, Nothing, dr("CODIGO"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw
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
        tables(0) = New String("ESPECIFICOGASTO")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)
        strSQL.Append("SELECT ")
        strSQL.Append("IDESPECIFICOGASTO, ")
        strSQL.Append("CODIGO, ")
        strSQL.Append("NOMBRE, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_ESPECIFICOSGASTO ")
    End Sub

#End Region

    Public Function BuscarCodigo(ByVal CODIGO As String, ByVal IDESPECIFICOGASTO As Int16) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_ESPECIFICOSGASTO ")
        strSQL.Append("WHERE CODIGO = @CODIGO ")
        strSQL.Append("AND (IDESPECIFICOGASTO <> @IDESPECIFICOGASTO OR @IDESPECIFICOGASTO = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(0).Value = IDESPECIFICOGASTO
        args(1) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(1).Value = CODIGO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 1, 0)

    End Function

    Public Function RecuperarEspecificos() As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDESPECIFICOGASTO, ")
        strSQL.Append("CODIGO, ")
        strSQL.Append("NOMBRE, ")
        strSQL.Append("CODIGO + ' - ' + NOMBRE CODIGONOMBRE ")
        strSQL.Append("FROM SAB_CAT_ESPECIFICOSGASTO ")
        strSQL.Append("ORDER BY CODIGO ")

        Dim args(-1) As SqlParameter

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

End Class
