Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbPORCENTAJESMULTAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla PORCENTAJESMULTAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbPORCENTAJESMULTAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PORCENTAJESMULTAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDPORCENTAJE = 0 _
            Or lEntidad.IDPORCENTAJE = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDPORCENTAJE = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_PORCENTAJESMULTAS ")
        strSQL.Append(" SET INICIOPERIODO = @INICIOPERIODO, ")
        strSQL.Append(" FINPERIODO = @FINPERIODO, ")
        strSQL.Append(" PORCENTAJE = @PORCENTAJE, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPORCENTAJE = @IDPORCENTAJE ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@INICIOPERIODO", SqlDbType.TinyInt)
        args(0).Value = lEntidad.INICIOPERIODO
        args(1) = New SqlParameter("@FINPERIODO", SqlDbType.TinyInt)
        args(1).Value = IIf(lEntidad.FINPERIODO = Nothing, DBNull.Value, lEntidad.FINPERIODO)
        args(2) = New SqlParameter("@PORCENTAJE", SqlDbType.Decimal)
        args(2).Value = lEntidad.PORCENTAJE
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
        args(8) = New SqlParameter("@IDPORCENTAJE", SqlDbType.TinyInt)
        args(8).Value = lEntidad.IDPORCENTAJE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PORCENTAJESMULTAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_PORCENTAJESMULTAS ")
        strSQL.Append(" ( IDPORCENTAJE, ")
        strSQL.Append(" INICIOPERIODO, ")
        strSQL.Append(" FINPERIODO, ")
        strSQL.Append(" PORCENTAJE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDPORCENTAJE, ")
        strSQL.Append(" @INICIOPERIODO, ")
        strSQL.Append(" @FINPERIODO, ")
        strSQL.Append(" @PORCENTAJE, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDPORCENTAJE", SqlDbType.TinyInt)
        args(0).Value = lEntidad.IDPORCENTAJE
        args(1) = New SqlParameter("@INICIOPERIODO", SqlDbType.TinyInt)
        args(1).Value = lEntidad.INICIOPERIODO
        args(2) = New SqlParameter("@FINPERIODO", SqlDbType.TinyInt)
        args(2).Value = IIf(lEntidad.FINPERIODO = Nothing, DBNull.Value, lEntidad.FINPERIODO)
        args(3) = New SqlParameter("@PORCENTAJE", SqlDbType.Decimal)
        args(3).Value = lEntidad.PORCENTAJE
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

        Dim lEntidad As PORCENTAJESMULTAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_PORCENTAJESMULTAS ")
        strSQL.Append(" WHERE IDPORCENTAJE = @IDPORCENTAJE ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPORCENTAJE", SqlDbType.TinyInt)
        args(0).Value = lEntidad.IDPORCENTAJE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PORCENTAJESMULTAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPORCENTAJE = @IDPORCENTAJE ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPORCENTAJE", SqlDbType.TinyInt)
        args(0).Value = lEntidad.IDPORCENTAJE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.INICIOPERIODO = IIf(.Item("INICIOPERIODO") Is DBNull.Value, Nothing, .Item("INICIOPERIODO"))
                lEntidad.FINPERIODO = IIf(.Item("FINPERIODO") Is DBNull.Value, Nothing, .Item("FINPERIODO"))
                lEntidad.PORCENTAJE = IIf(.Item("PORCENTAJE") Is DBNull.Value, Nothing, .Item("PORCENTAJE"))
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

        Dim lEntidad As PORCENTAJESMULTAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDPORCENTAJE),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_PORCENTAJESMULTAS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaPORCENTAJESMULTAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaPORCENTAJESMULTAS

        Try
            Do While dr.Read()
                Dim mEntidad As New PORCENTAJESMULTAS
                mEntidad.IDPORCENTAJE = IIf(dr("IDPORCENTAJE") Is DBNull.Value, Nothing, dr("IDPORCENTAJE"))
                mEntidad.INICIOPERIODO = IIf(dr("INICIOPERIODO") Is DBNull.Value, Nothing, dr("INICIOPERIODO"))
                mEntidad.FINPERIODO = IIf(dr("FINPERIODO") Is DBNull.Value, Nothing, dr("FINPERIODO"))
                mEntidad.PORCENTAJE = IIf(dr("PORCENTAJE") Is DBNull.Value, Nothing, dr("PORCENTAJE"))
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
        tables(0) = New String("PORCENTAJESMULTAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDPORCENTAJE, ")
        strSQL.Append(" INICIOPERIODO, ")
        strSQL.Append(" FINPERIODO, ")
        strSQL.Append(" PORCENTAJE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_PORCENTAJESMULTAS ")

    End Sub

#End Region

End Class
