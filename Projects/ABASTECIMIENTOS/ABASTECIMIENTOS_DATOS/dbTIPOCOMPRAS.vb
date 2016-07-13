Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbTIPOCOMPRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_CAT_TIPOCOMPRAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	21/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbTIPOCOMPRAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As TIPOCOMPRAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDTIPOCOMPRA = 0 _
            Or lEntidad.IDTIPOCOMPRA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDTIPOCOMPRA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_TIPOCOMPRAS ")
        strSQL.Append(" SET IDMODALIDADCOMPRA = @IDMODALIDADCOMPRA, ")
        strSQL.Append(" DESCRIPCION = @DESCRIPCION, ")
        strSQL.Append(" MIN = @MIN, ")
        strSQL.Append(" MAX = @MAX, ")
        strSQL.Append(" REQUIERECALIFICACION = @REQUIERECALIFICACION, ")
        strSQL.Append(" PREFIJOBASE = @PREFIJOBASE, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDTIPOCOMPRA = @IDTIPOCOMPRA ")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.TinyInt)
        args(0).Value = lEntidad.IDMODALIDADCOMPRA
        args(1) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.DESCRIPCION = Nothing, DBNull.Value, lEntidad.DESCRIPCION)
        args(2) = New SqlParameter("@MIN", SqlDbType.Decimal)
        args(2).Value = lEntidad.MIN
        args(3) = New SqlParameter("@MAX", SqlDbType.Decimal)
        args(3).Value = lEntidad.MAX
        args(4) = New SqlParameter("@REQUIERECALIFICACION", SqlDbType.TinyInt)
        args(4).Value = lEntidad.REQUIERECALIFICACION
        args(5) = New SqlParameter("@PREFIJOBASE", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.PREFIJOBASE = Nothing, DBNull.Value, lEntidad.PREFIJOBASE)
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(10) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(10).Value = lEntidad.ESTASINCRONIZADA
        args(11) = New SqlParameter("@IDTIPOCOMPRA", SqlDbType.Int)
        args(11).Value = lEntidad.IDTIPOCOMPRA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As TIPOCOMPRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_TIPOCOMPRAS ")
        strSQL.Append(" ( IDTIPOCOMPRA, ")
        strSQL.Append(" IDMODALIDADCOMPRA, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" MIN, ")
        strSQL.Append(" MAX, ")
        strSQL.Append(" REQUIERECALIFICACION, ")
        strSQL.Append(" PREFIJOBASE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDTIPOCOMPRA, ")
        strSQL.Append(" @IDMODALIDADCOMPRA, ")
        strSQL.Append(" @DESCRIPCION, ")
        strSQL.Append(" @MIN, ")
        strSQL.Append(" @MAX, ")
        strSQL.Append(" @REQUIERECALIFICACION, ")
        strSQL.Append(" @PREFIJOBASE, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOCOMPRA", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOCOMPRA
        args(1) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.TinyInt)
        args(1).Value = lEntidad.IDMODALIDADCOMPRA
        args(2) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.DESCRIPCION = Nothing, DBNull.Value, lEntidad.DESCRIPCION)
        args(3) = New SqlParameter("@MIN", SqlDbType.Decimal)
        args(3).Value = lEntidad.MIN
        args(4) = New SqlParameter("@MAX", SqlDbType.Decimal)
        args(4).Value = lEntidad.MAX
        args(5) = New SqlParameter("@REQUIERECALIFICACION", SqlDbType.TinyInt)
        args(5).Value = lEntidad.REQUIERECALIFICACION
        args(6) = New SqlParameter("@PREFIJOBASE", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.PREFIJOBASE = Nothing, DBNull.Value, lEntidad.PREFIJOBASE)
        args(7) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(8) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(9) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(10) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(11) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(11).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As TIPOCOMPRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_TIPOCOMPRAS ")
        strSQL.Append(" WHERE IDTIPOCOMPRA = @IDTIPOCOMPRA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOCOMPRA", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOCOMPRA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As TIPOCOMPRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDTIPOCOMPRA = @IDTIPOCOMPRA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOCOMPRA", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOCOMPRA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDMODALIDADCOMPRA = IIf(.Item("IDMODALIDADCOMPRA") Is DBNull.Value, Nothing, .Item("IDMODALIDADCOMPRA"))
                lEntidad.DESCRIPCION = IIf(.Item("DESCRIPCION") Is DBNull.Value, Nothing, .Item("DESCRIPCION"))
                lEntidad.MIN = IIf(.Item("MIN") Is DBNull.Value, Nothing, .Item("MIN"))
                lEntidad.MAX = IIf(.Item("MAX") Is DBNull.Value, Nothing, .Item("MAX"))
                lEntidad.REQUIERECALIFICACION = IIf(.Item("REQUIERECALIFICACION") Is DBNull.Value, Nothing, .Item("REQUIERECALIFICACION"))
                lEntidad.PREFIJOBASE = IIf(.Item("PREFIJOBASE") Is DBNull.Value, Nothing, .Item("PREFIJOBASE"))
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

        Dim lEntidad As TIPOCOMPRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDTIPOCOMPRA),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_TIPOCOMPRAS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerMax() As String
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT Max FROM SAB_CAT_TIPOCOMPRAS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    Public Function ObtenerListaPorID() As listaTIPOCOMPRAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaTIPOCOMPRAS

        Try
            Do While dr.Read()
                Dim mEntidad As New TIPOCOMPRAS
                mEntidad.IDTIPOCOMPRA = IIf(dr("IDTIPOCOMPRA") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRA"))
                mEntidad.IDMODALIDADCOMPRA = IIf(dr("IDMODALIDADCOMPRA") Is DBNull.Value, Nothing, dr("IDMODALIDADCOMPRA"))
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                mEntidad.MIN = IIf(dr("MIN") Is DBNull.Value, Nothing, dr("MIN"))
                mEntidad.MAX = IIf(dr("MAX") Is DBNull.Value, Nothing, dr("MAX"))
                mEntidad.REQUIERECALIFICACION = IIf(dr("REQUIERECALIFICACION") Is DBNull.Value, Nothing, dr("REQUIERECALIFICACION"))
                mEntidad.PREFIJOBASE = IIf(dr("PREFIJOBASE") Is DBNull.Value, Nothing, dr("PREFIJOBASE"))
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
        tables(0) = New String("TIPOCOMPRAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDTIPOCOMPRA, ")
        strSQL.Append(" IDMODALIDADCOMPRA, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" MIN, ")
        strSQL.Append(" MAX, ")
        strSQL.Append(" REQUIERECALIFICACION, ")
        strSQL.Append(" PREFIJOBASE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_TIPOCOMPRAS ")

    End Sub

#End Region

End Class
