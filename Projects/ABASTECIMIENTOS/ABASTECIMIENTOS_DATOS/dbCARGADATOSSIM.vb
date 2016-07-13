Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbCARGADATOSSIM
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla CARGADATOSSIM
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbCARGADATOSSIM
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CARGADATOSSIM
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDCARGA = 0 _
            Or lEntidad.IDCARGA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDCARGA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_EST_CARGADATOSSIM ")
        strSQL.Append(" SET FECHACARGA = @FECHACARGA, ")
        strSQL.Append(" FECHAINICIAL = @FECHAINICIAL, ")
        strSQL.Append(" FECHAFINAL = @FECHAFINAL, ")
        strSQL.Append(" IDEMPLEADO = @IDEMPLEADO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@FECHACARGA", SqlDbType.DateTime)
        args(0).Value = IIf(lEntidad.FECHACARGA = Nothing, DBNull.Value, lEntidad.FECHACARGA)
        args(1) = New SqlParameter("@FECHAINICIAL", SqlDbType.DateTime)
        args(1).Value = IIf(lEntidad.FECHAINICIAL = Nothing, DBNull.Value, lEntidad.FECHAINICIAL)
        args(2) = New SqlParameter("@FECHAFINAL", SqlDbType.DateTime)
        args(2).Value = IIf(lEntidad.FECHAFINAL = Nothing, DBNull.Value, lEntidad.FECHAFINAL)
        args(3) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(3).Value = IIf(lEntidad.IDEMPLEADO = Nothing, DBNull.Value, lEntidad.IDEMPLEADO)
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
        args(9) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(9).Value = lEntidad.IDESTABLECIMIENTO
        args(10) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(10).Value = lEntidad.IDCARGA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CARGADATOSSIM
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_CARGADATOSSIM ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCARGA, ")
        strSQL.Append(" FECHACARGA, ")
        strSQL.Append(" FECHAINICIAL, ")
        strSQL.Append(" FECHAFINAL, ")
        strSQL.Append(" IDEMPLEADO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDCARGA, ")
        strSQL.Append(" @FECHACARGA, ")
        strSQL.Append(" @FECHAINICIAL, ")
        strSQL.Append(" @FECHAFINAL, ")
        strSQL.Append(" @IDEMPLEADO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = lEntidad.IDCARGA
        args(2) = New SqlParameter("@FECHACARGA", SqlDbType.DateTime)
        args(2).Value = IIf(lEntidad.FECHACARGA = Nothing, DBNull.Value, lEntidad.FECHACARGA)
        args(3) = New SqlParameter("@FECHAINICIAL", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.FECHAINICIAL = Nothing, DBNull.Value, lEntidad.FECHAINICIAL)
        args(4) = New SqlParameter("@FECHAFINAL", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.FECHAFINAL = Nothing, DBNull.Value, lEntidad.FECHAFINAL)
        args(5) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(5).Value = IIf(lEntidad.IDEMPLEADO = Nothing, DBNull.Value, lEntidad.IDEMPLEADO)
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CARGADATOSSIM
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_CARGADATOSSIM ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = lEntidad.IDCARGA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CARGADATOSSIM
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = lEntidad.IDCARGA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.FECHACARGA = IIf(.Item("FECHACARGA") Is DBNull.Value, Nothing, .Item("FECHACARGA"))
                lEntidad.FECHAINICIAL = IIf(.Item("FECHAINICIAL") Is DBNull.Value, Nothing, .Item("FECHAINICIAL"))
                lEntidad.FECHAFINAL = IIf(.Item("FECHAFINAL") Is DBNull.Value, Nothing, .Item("FECHAFINAL"))
                lEntidad.IDEMPLEADO = IIf(.Item("IDEMPLEADO") Is DBNull.Value, Nothing, .Item("IDEMPLEADO"))
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

        Dim lEntidad As CARGADATOSSIM
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDCARGA),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_CARGADATOSSIM ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32) As listaCARGADATOSSIM

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaCARGADATOSSIM

        Try
            Do While dr.Read()
                Dim mEntidad As New CARGADATOSSIM
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDCARGA = IIf(dr("IDCARGA") Is DBNull.Value, Nothing, dr("IDCARGA"))
                mEntidad.FECHACARGA = IIf(dr("FECHACARGA") Is DBNull.Value, Nothing, dr("FECHACARGA"))
                mEntidad.FECHAINICIAL = IIf(dr("FECHAINICIAL") Is DBNull.Value, Nothing, dr("FECHAINICIAL"))
                mEntidad.FECHAFINAL = IIf(dr("FECHAFINAL") Is DBNull.Value, Nothing, dr("FECHAFINAL"))
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim tables(0) As String
        tables(0) = New String("CARGADATOSSIM")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCARGA, ")
        strSQL.Append(" FECHACARGA, ")
        strSQL.Append(" FECHAINICIAL, ")
        strSQL.Append(" FECHAFINAL, ")
        strSQL.Append(" IDEMPLEADO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_CARGADATOSSIM ")

    End Sub

#End Region

End Class
