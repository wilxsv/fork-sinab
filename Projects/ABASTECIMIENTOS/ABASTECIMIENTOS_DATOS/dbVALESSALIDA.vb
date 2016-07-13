Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbVALESSALIDA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_ALM_VALESSALIDA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	06/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbVALESSALIDA
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As VALESSALIDA
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDVALE = 0 _
            Or lEntidad.IDVALE = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDVALE = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_ALM_VALESSALIDA ")
        strSQL.Append(" SET TRANSPORTISTA = @TRANSPORTISTA, ")
        strSQL.Append(" MATRICULAVEHICULO = @MATRICULAVEHICULO, ")
        strSQL.Append(" PERSONARECIBE = @PERSONARECIBE, ")
        strSQL.Append(" IDTIPOIDENTIFICACION = @IDTIPOIDENTIFICACION, ")
        strSQL.Append(" NUMEROIDENTIFICACION = @NUMEROIDENTIFICACION, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDVALE = @IDVALE ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@TRANSPORTISTA", SqlDbType.VarChar)
        args(0).Value = IIf(lEntidad.TRANSPORTISTA = Nothing, DBNull.Value, lEntidad.TRANSPORTISTA)
        args(1) = New SqlParameter("@MATRICULAVEHICULO", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.MATRICULAVEHICULO = Nothing, DBNull.Value, lEntidad.MATRICULAVEHICULO)
        args(2) = New SqlParameter("@PERSONARECIBE", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.PERSONARECIBE = Nothing, DBNull.Value, lEntidad.PERSONARECIBE)
        args(3) = New SqlParameter("@IDTIPOIDENTIFICACION", SqlDbType.SmallInt)
        args(3).Value = IIf(lEntidad.IDTIPOIDENTIFICACION = Nothing, DBNull.Value, lEntidad.IDTIPOIDENTIFICACION)
        args(4) = New SqlParameter("@NUMEROIDENTIFICACION", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.NUMEROIDENTIFICACION = Nothing, DBNull.Value, lEntidad.NUMEROIDENTIFICACION)
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
        args(11) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(11).Value = lEntidad.IDALMACEN
        args(12) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(12).Value = lEntidad.ANIO
        args(13) = New SqlParameter("@IDVALE", SqlDbType.Int)
        args(13).Value = lEntidad.IDVALE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As VALESSALIDA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_ALM_VALESSALIDA ")
        strSQL.Append(" ( IDALMACEN, ")
        strSQL.Append(" ANIO, ")
        strSQL.Append(" IDVALE, ")
        strSQL.Append(" TRANSPORTISTA, ")
        strSQL.Append(" MATRICULAVEHICULO, ")
        strSQL.Append(" PERSONARECIBE, ")
        strSQL.Append(" IDTIPOIDENTIFICACION, ")
        strSQL.Append(" NUMEROIDENTIFICACION, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALMACEN, ")
        strSQL.Append(" @ANIO, ")
        strSQL.Append(" @IDVALE, ")
        strSQL.Append(" @TRANSPORTISTA, ")
        strSQL.Append(" @MATRICULAVEHICULO, ")
        strSQL.Append(" @PERSONARECIBE, ")
        strSQL.Append(" @IDTIPOIDENTIFICACION, ")
        strSQL.Append(" @NUMEROIDENTIFICACION, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDVALE", SqlDbType.Int)
        args(2).Value = lEntidad.IDVALE
        args(3) = New SqlParameter("@TRANSPORTISTA", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.TRANSPORTISTA = Nothing, DBNull.Value, lEntidad.TRANSPORTISTA)
        args(4) = New SqlParameter("@MATRICULAVEHICULO", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.MATRICULAVEHICULO = Nothing, DBNull.Value, lEntidad.MATRICULAVEHICULO)
        args(5) = New SqlParameter("@PERSONARECIBE", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.PERSONARECIBE = Nothing, DBNull.Value, lEntidad.PERSONARECIBE)
        args(6) = New SqlParameter("@IDTIPOIDENTIFICACION", SqlDbType.SmallInt)
        args(6).Value = IIf(lEntidad.IDTIPOIDENTIFICACION = Nothing, DBNull.Value, lEntidad.IDTIPOIDENTIFICACION)
        args(7) = New SqlParameter("@NUMEROIDENTIFICACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.NUMEROIDENTIFICACION = Nothing, DBNull.Value, lEntidad.NUMEROIDENTIFICACION)
        args(8) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(9) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(10) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(11) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(11).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(12) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(13) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(13).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As VALESSALIDA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_VALESSALIDA ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDVALE = @IDVALE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDVALE", SqlDbType.Int)
        args(2).Value = lEntidad.IDVALE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As VALESSALIDA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDVALE = @IDVALE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDVALE", SqlDbType.Int)
        args(2).Value = lEntidad.IDVALE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.TRANSPORTISTA = IIf(.Item("TRANSPORTISTA") Is DBNull.Value, Nothing, .Item("TRANSPORTISTA"))
                lEntidad.MATRICULAVEHICULO = IIf(.Item("MATRICULAVEHICULO") Is DBNull.Value, Nothing, .Item("MATRICULAVEHICULO"))
                lEntidad.PERSONARECIBE = IIf(.Item("PERSONARECIBE") Is DBNull.Value, Nothing, .Item("PERSONARECIBE"))
                lEntidad.IDTIPOIDENTIFICACION = IIf(.Item("IDTIPOIDENTIFICACION") Is DBNull.Value, Nothing, .Item("IDTIPOIDENTIFICACION"))
                lEntidad.NUMEROIDENTIFICACION = IIf(.Item("NUMEROIDENTIFICACION") Is DBNull.Value, Nothing, .Item("NUMEROIDENTIFICACION"))
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

        Dim lEntidad As VALESSALIDA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDVALE),0) + 1 ")
        strSQL.Append(" FROM SAB_ALM_VALESSALIDA ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32) As listaVALESSALIDA

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaVALESSALIDA

        Try
            Do While dr.Read()
                Dim mEntidad As New VALESSALIDA
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.ANIO = IIf(dr("ANIO") Is DBNull.Value, Nothing, dr("ANIO"))
                mEntidad.IDVALE = IIf(dr("IDVALE") Is DBNull.Value, Nothing, dr("IDVALE"))
                mEntidad.TRANSPORTISTA = IIf(dr("TRANSPORTISTA") Is DBNull.Value, Nothing, dr("TRANSPORTISTA"))
                mEntidad.MATRICULAVEHICULO = IIf(dr("MATRICULAVEHICULO") Is DBNull.Value, Nothing, dr("MATRICULAVEHICULO"))
                mEntidad.PERSONARECIBE = IIf(dr("PERSONARECIBE") Is DBNull.Value, Nothing, dr("PERSONARECIBE"))
                mEntidad.IDTIPOIDENTIFICACION = IIf(dr("IDTIPOIDENTIFICACION") Is DBNull.Value, Nothing, dr("IDTIPOIDENTIFICACION"))
                mEntidad.NUMEROIDENTIFICACION = IIf(dr("NUMEROIDENTIFICACION") Is DBNull.Value, Nothing, dr("NUMEROIDENTIFICACION"))
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
        tables(0) = New String("VALESSALIDA")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDALMACEN, ")
        strSQL.Append(" ANIO, ")
        strSQL.Append(" IDVALE, ")
        strSQL.Append(" TRANSPORTISTA, ")
        strSQL.Append(" MATRICULAVEHICULO, ")
        strSQL.Append(" PERSONARECIBE, ")
        strSQL.Append(" IDTIPOIDENTIFICACION, ")
        strSQL.Append(" NUMEROIDENTIFICACION, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_ALM_VALESSALIDA ")

    End Sub

#End Region

End Class
