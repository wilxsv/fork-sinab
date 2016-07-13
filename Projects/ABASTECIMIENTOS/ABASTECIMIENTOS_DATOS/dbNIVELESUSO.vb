Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbNIVELESUSO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla NIVELESUSO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbNIVELESUSO
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NIVELESUSO
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDNIVELUSO = 0 _
            Or lEntidad.IDNIVELUSO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDNIVELUSO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_NIVELESUSO ")
        strSQL.Append(" SET NOMBRECORTO = @NOMBRECORTO, ")
        strSQL.Append(" DESCRIPCION = @DESCRIPCION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDNIVELUSO = @IDNIVELUSO ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@NOMBRECORTO", SqlDbType.VarChar)
        args(0).Value = lEntidad.NOMBRECORTO
        args(1) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.DESCRIPCION = Nothing, DBNull.Value, lEntidad.DESCRIPCION)
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
        args(7) = New SqlParameter("@IDNIVELUSO", SqlDbType.TinyInt)
        args(7).Value = lEntidad.IDNIVELUSO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NIVELESUSO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_NIVELESUSO ")
        strSQL.Append(" ( IDNIVELUSO, ")
        strSQL.Append(" NOMBRECORTO, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDNIVELUSO, ")
        strSQL.Append(" @NOMBRECORTO, ")
        strSQL.Append(" @DESCRIPCION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDNIVELUSO", SqlDbType.TinyInt)
        args(0).Value = lEntidad.IDNIVELUSO
        args(1) = New SqlParameter("@NOMBRECORTO", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRECORTO
        args(2) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.DESCRIPCION = Nothing, DBNull.Value, lEntidad.DESCRIPCION)
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

        Dim lEntidad As NIVELESUSO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_NIVELESUSO ")
        strSQL.Append(" WHERE IDNIVELUSO = @IDNIVELUSO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDNIVELUSO", SqlDbType.TinyInt)
        args(0).Value = lEntidad.IDNIVELUSO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NIVELESUSO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDNIVELUSO = @IDNIVELUSO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDNIVELUSO", SqlDbType.TinyInt)
        args(0).Value = lEntidad.IDNIVELUSO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.NOMBRECORTO = IIf(.Item("NOMBRECORTO") Is DBNull.Value, Nothing, .Item("NOMBRECORTO"))
                lEntidad.DESCRIPCION = IIf(.Item("DESCRIPCION") Is DBNull.Value, Nothing, .Item("DESCRIPCION"))
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

        Dim lEntidad As NIVELESUSO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDNIVELUSO),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_NIVELESUSO ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaNIVELESUSO

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaNIVELESUSO

        Try
            Do While dr.Read()
                Dim mEntidad As New NIVELESUSO
                mEntidad.IDNIVELUSO = IIf(dr("IDNIVELUSO") Is DBNull.Value, Nothing, dr("IDNIVELUSO"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
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
        tables(0) = New String("NIVELESUSO")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDNIVELUSO, ")
        strSQL.Append(" NOMBRECORTO, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_NIVELESUSO ")
        strSQL.Append(" ORDER BY NOMBRECORTO ")


    End Sub

#End Region

End Class