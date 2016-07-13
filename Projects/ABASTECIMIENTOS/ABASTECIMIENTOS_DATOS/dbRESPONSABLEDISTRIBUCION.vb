Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbRESPONSABLEDISTRIBUCION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_CAT_RESPONSABLEDISTRIBUCION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbRESPONSABLEDISTRIBUCION
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RESPONSABLEDISTRIBUCION
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDRESPONSABLEDISTRIBUCION = 0 _
            Or lEntidad.IDRESPONSABLEDISTRIBUCION = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDRESPONSABLEDISTRIBUCION = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_RESPONSABLEDISTRIBUCION ")
        strSQL.Append(" SET IDESTABLECIMIENTO = @IDESTABLECIMIENTO, ")
        strSQL.Append(" IDDEPENDENCIA = @IDDEPENDENCIA, ")
        strSQL.Append(" NOMBRE = @NOMBRE, ")
        strSQL.Append(" NOMBRECORTO = @NOMBRECORTO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IIf(lEntidad.IDDEPENDENCIA = Nothing, DBNull.Value, lEntidad.IDDEPENDENCIA)
        args(2) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(2).Value = lEntidad.NOMBRE
        args(3) = New SqlParameter("@NOMBRECORTO", SqlDbType.VarChar)
        args(3).Value = lEntidad.NOMBRECORTO
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
        args(9) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(9).Value = lEntidad.IDRESPONSABLEDISTRIBUCION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RESPONSABLEDISTRIBUCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_RESPONSABLEDISTRIBUCION ")
        strSQL.Append(" ( IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDDEPENDENCIA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" NOMBRECORTO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDDEPENDENCIA, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @NOMBRECORTO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(0).Value = lEntidad.IDRESPONSABLEDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(2) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(2).Value = IIf(lEntidad.IDDEPENDENCIA = Nothing, DBNull.Value, lEntidad.IDDEPENDENCIA)
        args(3) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(3).Value = lEntidad.NOMBRE
        args(4) = New SqlParameter("@NOMBRECORTO", SqlDbType.VarChar)
        args(4).Value = lEntidad.NOMBRECORTO
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

        Dim lEntidad As RESPONSABLEDISTRIBUCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_RESPONSABLEDISTRIBUCION ")
        strSQL.Append(" WHERE IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(0).Value = lEntidad.IDRESPONSABLEDISTRIBUCION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RESPONSABLEDISTRIBUCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(0).Value = lEntidad.IDRESPONSABLEDISTRIBUCION

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDESTABLECIMIENTO = IIf(.Item("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTO"))
                lEntidad.IDDEPENDENCIA = IIf(.Item("IDDEPENDENCIA") Is DBNull.Value, Nothing, .Item("IDDEPENDENCIA"))
                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                lEntidad.NOMBRECORTO = IIf(.Item("NOMBRECORTO") Is DBNull.Value, Nothing, .Item("NOMBRECORTO"))
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

        Dim lEntidad As RESPONSABLEDISTRIBUCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDRESPONSABLEDISTRIBUCION),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_RESPONSABLEDISTRIBUCION ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaRESPONSABLEDISTRIBUCION

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaRESPONSABLEDISTRIBUCION

        Try
            Do While dr.Read()
                Dim mEntidad As New RESPONSABLEDISTRIBUCION
                mEntidad.IDRESPONSABLEDISTRIBUCION = IIf(dr("IDRESPONSABLEDISTRIBUCION") Is DBNull.Value, Nothing, dr("IDRESPONSABLEDISTRIBUCION"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
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
        tables(0) = New String("RESPONSABLEDISTRIBUCION")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDDEPENDENCIA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" NOMBRECORTO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_RESPONSABLEDISTRIBUCION ")

    End Sub

#End Region

End Class
