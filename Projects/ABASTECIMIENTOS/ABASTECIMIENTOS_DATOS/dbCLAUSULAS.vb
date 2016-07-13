Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbCLAUSULAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla CLAUSULAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbCLAUSULAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CLAUSULAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDCLAUSULA = 0 _
            Or lEntidad.IDCLAUSULA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDCLAUSULA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_CLAUSULAS ")
        strSQL.Append(" SET NOMBRE = @NOMBRE, ")
        strSQL.Append(" CONTENIDO = @CONTENIDO, ")
        strSQL.Append(" ESREQUERIDA = @ESREQUERIDA, ")
        strSQL.Append(" IDMODALIDADCOMPRA = @IDMODALIDADCOMPRA, ")
        strSQL.Append(" MODIFICATIVA = @MODIFICATIVA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDCLAUSULA = @IDCLAUSULA ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(0).Value = lEntidad.NOMBRE
        args(1) = New SqlParameter("@CONTENIDO", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.CONTENIDO = Nothing, DBNull.Value, lEntidad.CONTENIDO)
        args(2) = New SqlParameter("@ESREQUERIDA", SqlDbType.TinyInt)
        args(2).Value = lEntidad.ESREQUERIDA
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
        args(8) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(8).Value = lEntidad.IDCLAUSULA
        args(9) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.TinyInt)
        args(9).Value = lEntidad.IDMODALIDADCOMPRA
        args(10) = New SqlParameter("@MODIFICATIVA", SqlDbType.TinyInt)
        args(10).Value = lEntidad.MODIFICATIVA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CLAUSULAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_CLAUSULAS ")
        strSQL.Append(" ( IDCLAUSULA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" CONTENIDO, ")
        strSQL.Append(" ESREQUERIDA, ")
        strSQL.Append(" IDMODALIDADCOMPRA, ")
        strSQL.Append(" MODIFICATIVA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDCLAUSULA, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @CONTENIDO, ")
        strSQL.Append(" @ESREQUERIDA, ")
        strSQL.Append(" @IDMODALIDADCOMPRA, ")
        strSQL.Append(" @MODIFICATIVA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(0).Value = lEntidad.IDCLAUSULA
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@CONTENIDO", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.CONTENIDO = Nothing, DBNull.Value, lEntidad.CONTENIDO)
        args(3) = New SqlParameter("@ESREQUERIDA", SqlDbType.TinyInt)
        args(3).Value = lEntidad.ESREQUERIDA
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
        args(9) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.TinyInt)
        args(9).Value = lEntidad.IDMODALIDADCOMPRA
        args(10) = New SqlParameter("@MODIFICATIVA", SqlDbType.TinyInt)
        args(10).Value = lEntidad.MODIFICATIVA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CLAUSULAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_CLAUSULAS ")
        strSQL.Append(" WHERE IDCLAUSULA = @IDCLAUSULA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(0).Value = lEntidad.IDCLAUSULA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CLAUSULAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDCLAUSULA = @IDCLAUSULA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(0).Value = lEntidad.IDCLAUSULA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                lEntidad.CONTENIDO = IIf(.Item("CONTENIDO") Is DBNull.Value, Nothing, .Item("CONTENIDO"))
                lEntidad.ESREQUERIDA = IIf(.Item("ESREQUERIDA") Is DBNull.Value, Nothing, .Item("ESREQUERIDA"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.IDMODALIDADCOMPRA = .Item("IDMODALIDADCOMPRA")
                lEntidad.MODIFICATIVA = .Item("MODIFICATIVA")
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As CLAUSULAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDCLAUSULA),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_CLAUSULAS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaCLAUSULAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaCLAUSULAS

        Try
            Do While dr.Read()
                Dim mEntidad As New CLAUSULAS
                mEntidad.IDCLAUSULA = IIf(dr("IDCLAUSULA") Is DBNull.Value, Nothing, dr("IDCLAUSULA"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.CONTENIDO = IIf(dr("CONTENIDO") Is DBNull.Value, Nothing, dr("CONTENIDO"))
                mEntidad.ESREQUERIDA = IIf(dr("ESREQUERIDA") Is DBNull.Value, Nothing, dr("ESREQUERIDA"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.IDMODALIDADCOMPRA = dr("IDMODALIDADCOMPRA")
                mEntidad.MODIFICATIVA = dr("MODIFICATIVA")
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
        tables(0) = New String("CLAUSULAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDCLAUSULA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" CONTENIDO, ")
        strSQL.Append(" ESREQUERIDA, ")
        strSQL.Append(" IDMODALIDADCOMPRA, ")
        strSQL.Append(" MODIFICATIVA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_CLAUSULAS ")

    End Sub

#End Region

End Class
