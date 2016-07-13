Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLEENTREGAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla DETALLEENTREGAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLEENTREGAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEENTREGAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDDETALLE = 0 _
            Or lEntidad.IDDETALLE = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDDETALLE = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_EST_DETALLEENTREGAS ")
        strSQL.Append(" SET DIAS = @DIAS, ")
        strSQL.Append(" PORCENTAJE = @PORCENTAJE, ")
        strSQL.Append(" TIPOCONTEO = @TIPOCONTEO, ")
        strSQL.Append(" FECHACONTEO = @FECHACONTEO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@DIAS", SqlDbType.TinyInt)
        args(0).Value = lEntidad.DIAS
        args(1) = New SqlParameter("@PORCENTAJE", SqlDbType.Decimal)
        args(1).Value = lEntidad.PORCENTAJE
        args(2) = New SqlParameter("@TIPOCONTEO", SqlDbType.TinyInt)
        args(2).Value = lEntidad.TIPOCONTEO
        args(3) = New SqlParameter("@FECHACONTEO", SqlDbType.TinyInt)
        args(3).Value = lEntidad.FECHACONTEO
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
        args(10) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(10).Value = lEntidad.IDSOLICITUD
        args(11) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(11).Value = lEntidad.IDENTREGA
        args(12) = New SqlParameter("@IDDETALLE", SqlDbType.TinyInt)
        args(12).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEENTREGAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_DETALLEENTREGAS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" IDENTREGA, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" DIAS, ")
        strSQL.Append(" PORCENTAJE, ")
        strSQL.Append(" TIPOCONTEO, ")
        strSQL.Append(" FECHACONTEO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDSOLICITUD, ")
        strSQL.Append(" @IDENTREGA, ")
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @DIAS, ")
        strSQL.Append(" @PORCENTAJE, ")
        strSQL.Append(" @TIPOCONTEO, ")
        strSQL.Append(" @FECHACONTEO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(2).Value = lEntidad.IDENTREGA
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.TinyInt)
        args(3).Value = lEntidad.IDDETALLE
        args(4) = New SqlParameter("@DIAS", SqlDbType.TinyInt)
        args(4).Value = lEntidad.DIAS
        args(5) = New SqlParameter("@PORCENTAJE", SqlDbType.Decimal)
        args(5).Value = lEntidad.PORCENTAJE
        args(6) = New SqlParameter("@TIPOCONTEO", SqlDbType.TinyInt)
        args(6).Value = lEntidad.TIPOCONTEO
        args(7) = New SqlParameter("@FECHACONTEO", SqlDbType.TinyInt)
        args(7).Value = lEntidad.FECHACONTEO
        args(8) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(9) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(10) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(11) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(12) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(12).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEENTREGAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_DETALLEENTREGAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(2).Value = lEntidad.IDENTREGA
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.TinyInt)
        args(3).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEENTREGAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(2).Value = lEntidad.IDENTREGA
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.TinyInt)
        args(3).Value = lEntidad.IDDETALLE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.DIAS = IIf(.Item("DIAS") Is DBNull.Value, Nothing, .Item("DIAS"))
                lEntidad.PORCENTAJE = IIf(.Item("PORCENTAJE") Is DBNull.Value, Nothing, .Item("PORCENTAJE"))
                lEntidad.TIPOCONTEO = IIf(.Item("TIPOCONTEO") Is DBNull.Value, Nothing, .Item("TIPOCONTEO"))
                lEntidad.FECHACONTEO = IIf(.Item("FECHACONTEO") Is DBNull.Value, Nothing, .Item("FECHACONTEO"))
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

        Dim lEntidad As DETALLEENTREGAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_DETALLEENTREGAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(2).Value = lEntidad.IDENTREGA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDENTREGA As Byte) As listaDETALLEENTREGAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(2).Value = IDENTREGA

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLEENTREGAS

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLEENTREGAS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDSOLICITUD = IDSOLICITUD
                mEntidad.IDENTREGA = IDENTREGA
                mEntidad.IDDETALLE = IIf(dr("IDDETALLE") Is DBNull.Value, Nothing, dr("IDDETALLE"))
                mEntidad.DIAS = IIf(dr("DIAS") Is DBNull.Value, Nothing, dr("DIAS"))
                mEntidad.PORCENTAJE = IIf(dr("PORCENTAJE") Is DBNull.Value, Nothing, dr("PORCENTAJE"))
                mEntidad.TIPOCONTEO = IIf(dr("TIPOCONTEO") Is DBNull.Value, Nothing, dr("TIPOCONTEO"))
                mEntidad.FECHACONTEO = IIf(dr("FECHACONTEO") Is DBNull.Value, Nothing, dr("FECHACONTEO"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDENTREGA As Byte) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(2).Value = IDENTREGA

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDENTREGA As Byte, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(2).Value = IDENTREGA

        Dim tables(0) As String
        tables(0) = New String("DETALLEENTREGAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" IDENTREGA, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" DIAS, ")
        strSQL.Append(" PORCENTAJE, ")
        strSQL.Append(" TIPOCONTEO, ")
        strSQL.Append(" FECHACONTEO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_DETALLEENTREGAS ")

    End Sub

#End Region

End Class
