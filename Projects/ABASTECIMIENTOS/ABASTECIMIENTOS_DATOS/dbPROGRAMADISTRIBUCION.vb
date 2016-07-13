Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbPROGRAMADISTRIBUCION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_PROGRAMADISTRIBUCION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	29/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbPROGRAMADISTRIBUCION
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROGRAMADISTRIBUCION
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.RENGLON = 0 _
            Or lEntidad.RENGLON = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.RENGLON = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_PROGRAMADISTRIBUCION ")
        strSQL.Append(" SET IDALMACEN = @IDALMACEN, ")
        strSQL.Append(" CANTIDADSOLICITADA = @CANTIDADSOLICITADA, ")
        strSQL.Append(" CANTIDADADJUDICADA = @CANTIDADADJUDICADA, ")
        strSQL.Append(" CANTIDADENTREGADA = @CANTIDADENTREGADA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTOSOLICITA ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@CANTIDADSOLICITADA", SqlDbType.Decimal)
        args(1).Value = lEntidad.CANTIDADSOLICITADA
        args(2) = New SqlParameter("@CANTIDADADJUDICADA", SqlDbType.Decimal)
        args(2).Value = IIf(lEntidad.CANTIDADADJUDICADA = Nothing, DBNull.Value, lEntidad.CANTIDADADJUDICADA)
        args(3) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.Decimal)
        args(3).Value = IIf(lEntidad.CANTIDADENTREGADA = Nothing, DBNull.Value, lEntidad.CANTIDADENTREGADA)
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
        args(10) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(10).Value = lEntidad.IDPROCESOCOMPRA
        args(11) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(11).Value = lEntidad.IDESTABLECIMIENTOSOLICITA
        args(12) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(12).Value = lEntidad.IDSOLICITUD
        args(13) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(13).Value = lEntidad.RENGLON

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROGRAMADISTRIBUCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_PROGRAMADISTRIBUCION ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDESTABLECIMIENTOSOLICITA, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDALMACEN, ")
        strSQL.Append(" CANTIDADSOLICITADA, ")
        strSQL.Append(" CANTIDADADJUDICADA, ")
        strSQL.Append(" CANTIDADENTREGADA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDESTABLECIMIENTOSOLICITA, ")
        strSQL.Append(" @IDSOLICITUD, ")
        strSQL.Append(" @RENGLON, ")
        strSQL.Append(" @IDALMACEN, ")
        strSQL.Append(" @CANTIDADSOLICITADA, ")
        strSQL.Append(" @CANTIDADADJUDICADA, ")
        strSQL.Append(" @CANTIDADENTREGADA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(2).Value = lEntidad.IDESTABLECIMIENTOSOLICITA
        args(3) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDSOLICITUD
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = lEntidad.RENGLON
        args(5) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(5).Value = lEntidad.IDALMACEN
        args(6) = New SqlParameter("@CANTIDADSOLICITADA", SqlDbType.Decimal)
        args(6).Value = lEntidad.CANTIDADSOLICITADA
        args(7) = New SqlParameter("@CANTIDADADJUDICADA", SqlDbType.Decimal)
        args(7).Value = IIf(lEntidad.CANTIDADADJUDICADA = Nothing, DBNull.Value, lEntidad.CANTIDADADJUDICADA)
        args(8) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.Decimal)
        args(8).Value = IIf(lEntidad.CANTIDADENTREGADA = Nothing, DBNull.Value, lEntidad.CANTIDADENTREGADA)
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

        Dim lEntidad As PROGRAMADISTRIBUCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_PROGRAMADISTRIBUCION ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTOSOLICITA ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(2).Value = lEntidad.IDESTABLECIMIENTOSOLICITA
        args(3) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDSOLICITUD
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = lEntidad.RENGLON

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROGRAMADISTRIBUCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTOSOLICITA ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(2).Value = lEntidad.IDESTABLECIMIENTOSOLICITA
        args(3) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDSOLICITUD
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = lEntidad.RENGLON

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDALMACEN = IIf(.Item("IDALMACEN") Is DBNull.Value, Nothing, .Item("IDALMACEN"))
                lEntidad.CANTIDADSOLICITADA = IIf(.Item("CANTIDADSOLICITADA") Is DBNull.Value, Nothing, .Item("CANTIDADSOLICITADA"))
                lEntidad.CANTIDADADJUDICADA = IIf(.Item("CANTIDADADJUDICADA") Is DBNull.Value, Nothing, .Item("CANTIDADADJUDICADA"))
                lEntidad.CANTIDADENTREGADA = IIf(.Item("CANTIDADENTREGADA") Is DBNull.Value, Nothing, .Item("CANTIDADENTREGADA"))
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

        Dim lEntidad As PROGRAMADISTRIBUCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(RENGLON),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_PROGRAMADISTRIBUCION ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTOSOLICITA ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(2).Value = lEntidad.IDESTABLECIMIENTOSOLICITA
        args(3) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDSOLICITUD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTOSOLICITA As Int32, ByVal IDSOLICITUD As Int64) As listaPROGRAMADISTRIBUCION

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTOSOLICITA ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTOSOLICITA
        args(3) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(3).Value = IDSOLICITUD

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaPROGRAMADISTRIBUCION

        Try
            Do While dr.Read()
                Dim mEntidad As New PROGRAMADISTRIBUCION
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
                mEntidad.IDESTABLECIMIENTOSOLICITA = IDESTABLECIMIENTOSOLICITA
                mEntidad.IDSOLICITUD = IDSOLICITUD
                mEntidad.RENGLON = IIf(dr("RENGLON") Is DBNull.Value, Nothing, dr("RENGLON"))
                mEntidad.IDALMACEN = IIf(dr("IDALMACEN") Is DBNull.Value, Nothing, dr("IDALMACEN"))
                mEntidad.CANTIDADSOLICITADA = IIf(dr("CANTIDADSOLICITADA") Is DBNull.Value, Nothing, dr("CANTIDADSOLICITADA"))
                mEntidad.CANTIDADADJUDICADA = IIf(dr("CANTIDADADJUDICADA") Is DBNull.Value, Nothing, dr("CANTIDADADJUDICADA"))
                mEntidad.CANTIDADENTREGADA = IIf(dr("CANTIDADENTREGADA") Is DBNull.Value, Nothing, dr("CANTIDADENTREGADA"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTOSOLICITA As Int32, ByVal IDSOLICITUD As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTOSOLICITA ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTOSOLICITA
        args(3) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(3).Value = IDSOLICITUD

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTOSOLICITA As Int32, ByVal IDSOLICITUD As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTOSOLICITA ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTOSOLICITA
        args(3) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(3).Value = IDSOLICITUD

        Dim tables(0) As String
        tables(0) = New String("PROGRAMADISTRIBUCION")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDESTABLECIMIENTOSOLICITA, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDALMACEN, ")
        strSQL.Append(" CANTIDADSOLICITADA, ")
        strSQL.Append(" CANTIDADADJUDICADA, ")
        strSQL.Append(" CANTIDADENTREGADA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA,IDFUENTEFINANCIAMIENTO ")
        strSQL.Append(" FROM SAB_UACI_PROGRAMADISTRIBUCION ")

    End Sub

#End Region

End Class
