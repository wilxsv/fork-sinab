Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbCORRECCIONESALMACENES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_ALM_CORRECCIONESALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbCORRECCIONESALMACENES
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CORRECCIONESALMACENES
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDCORRECCION = 0 _
            Or lEntidad.IDCORRECCION = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDCORRECCION = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_ALM_CORRECCIONESALMACENES ")
        strSQL.Append(" SET IDJEFEALMACEN = @IDJEFEALMACEN, ")
        strSQL.Append(" MOTIVO = @MOTIVO, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDCORRECCION = @IDCORRECCION ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDJEFEALMACEN", SqlDbType.Int)
        args(0).Value = IIf(lEntidad.IDJEFEALMACEN = Nothing, DBNull.Value, lEntidad.IDJEFEALMACEN)
        args(1) = New SqlParameter("@MOTIVO", SqlDbType.VarChar)
        args(1).Value = lEntidad.MOTIVO
        args(2) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
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
        args(8) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(8).Value = lEntidad.IDALMACEN
        args(9) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(9).Value = lEntidad.ANIO
        args(10) = New SqlParameter("@IDCORRECCION", SqlDbType.Int)
        args(10).Value = lEntidad.IDCORRECCION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CORRECCIONESALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_ALM_CORRECCIONESALMACENES ")
        strSQL.Append(" ( IDALMACEN, ")
        strSQL.Append(" ANIO, ")
        strSQL.Append(" IDCORRECCION, ")
        strSQL.Append(" IDJEFEALMACEN, ")
        strSQL.Append(" MOTIVO, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALMACEN, ")
        strSQL.Append(" @ANIO, ")
        strSQL.Append(" @IDCORRECCION, ")
        strSQL.Append(" @IDJEFEALMACEN, ")
        strSQL.Append(" @MOTIVO, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDCORRECCION", SqlDbType.Int)
        args(2).Value = lEntidad.IDCORRECCION
        args(3) = New SqlParameter("@IDJEFEALMACEN", SqlDbType.Int)
        args(3).Value = IIf(lEntidad.IDJEFEALMACEN = Nothing, DBNull.Value, lEntidad.IDJEFEALMACEN)
        args(4) = New SqlParameter("@MOTIVO", SqlDbType.VarChar)
        args(4).Value = lEntidad.MOTIVO
        args(5) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
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

        Dim lEntidad As CORRECCIONESALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_CORRECCIONESALMACENES ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDCORRECCION = @IDCORRECCION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDCORRECCION", SqlDbType.Int)
        args(2).Value = lEntidad.IDCORRECCION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CORRECCIONESALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDCORRECCION = @IDCORRECCION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDCORRECCION", SqlDbType.Int)
        args(2).Value = lEntidad.IDCORRECCION

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDJEFEALMACEN = IIf(.Item("IDJEFEALMACEN") Is DBNull.Value, Nothing, .Item("IDJEFEALMACEN"))
                lEntidad.MOTIVO = IIf(.Item("MOTIVO") Is DBNull.Value, Nothing, .Item("MOTIVO"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
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

        Dim lEntidad As CORRECCIONESALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDCORRECCION),0) + 1 ")
        strSQL.Append(" FROM SAB_ALM_CORRECCIONESALMACENES ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32) As listaCORRECCIONESALMACENES

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaCORRECCIONESALMACENES

        Try
            Do While dr.Read()
                Dim mEntidad As New CORRECCIONESALMACENES
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.ANIO = IIf(dr("ANIO") Is DBNull.Value, Nothing, dr("ANIO"))
                mEntidad.IDCORRECCION = IIf(dr("IDCORRECCION") Is DBNull.Value, Nothing, dr("IDCORRECCION"))
                mEntidad.IDJEFEALMACEN = IIf(dr("IDJEFEALMACEN") Is DBNull.Value, Nothing, dr("IDJEFEALMACEN"))
                mEntidad.MOTIVO = IIf(dr("MOTIVO") Is DBNull.Value, Nothing, dr("MOTIVO"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
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

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim tables(0) As String
        tables(0) = New String("CORRECCIONESALMACENES")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDALMACEN, ")
        strSQL.Append(" ANIO, ")
        strSQL.Append(" IDCORRECCION, ")
        strSQL.Append(" IDJEFEALMACEN, ")
        strSQL.Append(" MOTIVO, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_ALM_CORRECCIONESALMACENES ")

    End Sub

#End Region

End Class
