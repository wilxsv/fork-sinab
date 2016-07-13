Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLECONSUMOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla DETALLECONSUMOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLECONSUMOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLECONSUMOS
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
        strSQL.Append("UPDATE SAB_EST_DETALLECONSUMOS ")
        strSQL.Append(" SET IDPRODUCTO = @IDPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA = @IDUNIDADMEDIDA, ")
        strSQL.Append(" CANTIDADCONSUMIDA = @CANTIDADCONSUMIDA, ")
        strSQL.Append(" DEMANDAINSATISFECHA = @DEMANDAINSATISFECHA, ")
        strSQL.Append(" EXISTENCIAACTUAL = @EXISTENCIAACTUAL, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDDETALLE = @IDDETALLE ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCONSUMO = @IDCONSUMO ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPRODUCTO
        args(1) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(1).Value = lEntidad.IDUNIDADMEDIDA
        args(2) = New SqlParameter("@CANTIDADCONSUMIDA", SqlDbType.Decimal)
        args(2).Value = lEntidad.CANTIDADCONSUMIDA
        args(3) = New SqlParameter("@DEMANDAINSATISFECHA", SqlDbType.Decimal)
        args(3).Value = lEntidad.DEMANDAINSATISFECHA
        args(4) = New SqlParameter("@EXISTENCIAACTUAL", SqlDbType.Decimal)
        args(4).Value = lEntidad.EXISTENCIAACTUAL
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
        args(10) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(10).Value = lEntidad.IDESTABLECIMIENTO
        args(11) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(11).Value = lEntidad.IDCONSUMO
        args(12) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(12).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLECONSUMOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_DETALLECONSUMOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCONSUMO, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" CANTIDADCONSUMIDA, ")
        strSQL.Append(" DEMANDAINSATISFECHA, ")
        strSQL.Append(" EXISTENCIAACTUAL, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDCONSUMO, ")
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @CANTIDADCONSUMIDA, ")
        strSQL.Append(" @DEMANDAINSATISFECHA, ")
        strSQL.Append(" @EXISTENCIAACTUAL, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDCONSUMO
        args(2) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDDETALLE
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDPRODUCTO
        args(4) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(4).Value = lEntidad.IDUNIDADMEDIDA
        args(5) = New SqlParameter("@CANTIDADCONSUMIDA", SqlDbType.Decimal)
        args(5).Value = lEntidad.CANTIDADCONSUMIDA
        args(6) = New SqlParameter("@DEMANDAINSATISFECHA", SqlDbType.Decimal)
        args(6).Value = lEntidad.DEMANDAINSATISFECHA
        args(7) = New SqlParameter("@EXISTENCIAACTUAL", SqlDbType.Decimal)
        args(7).Value = lEntidad.EXISTENCIAACTUAL
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

        Dim lEntidad As DETALLECONSUMOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_DETALLECONSUMOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCONSUMO = @IDCONSUMO ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDCONSUMO
        args(2) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLECONSUMOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCONSUMO = @IDCONSUMO ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDCONSUMO
        args(2) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDDETALLE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDPRODUCTO = IIf(.Item("IDPRODUCTO") Is DBNull.Value, Nothing, .Item("IDPRODUCTO"))
                lEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
                lEntidad.CANTIDADCONSUMIDA = IIf(.Item("CANTIDADCONSUMIDA") Is DBNull.Value, Nothing, .Item("CANTIDADCONSUMIDA"))
                lEntidad.DEMANDAINSATISFECHA = IIf(.Item("DEMANDAINSATISFECHA") Is DBNull.Value, Nothing, .Item("DEMANDAINSATISFECHA"))
                lEntidad.EXISTENCIAACTUAL = IIf(.Item("EXISTENCIAACTUAL") Is DBNull.Value, Nothing, .Item("EXISTENCIAACTUAL"))
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

        Dim lEntidad As DETALLECONSUMOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_DETALLECONSUMOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCONSUMO = @IDCONSUMO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDCONSUMO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64) As listaDETALLECONSUMOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCONSUMO = @IDCONSUMO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(1).Value = IDCONSUMO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLECONSUMOS

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLECONSUMOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDCONSUMO = IDCONSUMO
                mEntidad.IDDETALLE = IIf(dr("IDDETALLE") Is DBNull.Value, Nothing, dr("IDDETALLE"))
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.CANTIDADCONSUMIDA = IIf(dr("CANTIDADCONSUMIDA") Is DBNull.Value, Nothing, dr("CANTIDADCONSUMIDA"))
                mEntidad.DEMANDAINSATISFECHA = IIf(dr("DEMANDAINSATISFECHA") Is DBNull.Value, Nothing, dr("DEMANDAINSATISFECHA"))
                mEntidad.EXISTENCIAACTUAL = IIf(dr("EXISTENCIAACTUAL") Is DBNull.Value, Nothing, dr("EXISTENCIAACTUAL"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCONSUMO = @IDCONSUMO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(1).Value = IDCONSUMO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCONSUMO = @IDCONSUMO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONSUMO", SqlDbType.BigInt)
        args(1).Value = IDCONSUMO

        Dim tables(0) As String
        tables(0) = New String("DETALLECONSUMOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCONSUMO, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" CANTIDADCONSUMIDA, ")
        strSQL.Append(" DEMANDAINSATISFECHA, ")
        strSQL.Append(" EXISTENCIAACTUAL, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_DETALLECONSUMOS ")

    End Sub

#End Region

End Class
