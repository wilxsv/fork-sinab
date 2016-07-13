Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLENECESIDADESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla DETALLENECESIDADESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLENECESIDADESTABLECIMIENTOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLENECESIDADESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" SET IDUNIDADMEDIDA = @IDUNIDADMEDIDA, ")
        strSQL.Append(" CONSUMOANUAL = @CONSUMOANUAL, ")
        strSQL.Append(" DEMANDAINSATISFECHA = @DEMANDAINSATISFECHA, ")
        strSQL.Append(" RESERVAESTABLECIMIENTO = @RESERVAESTABLECIMIENTO, ")
        strSQL.Append(" RESERVATOTAL = @RESERVATOTAL, ")
        strSQL.Append(" EXISTENCIAESTIMADA = @EXISTENCIAESTIMADA, ")
        strSQL.Append(" PRECIOUNITARIO = @PRECIOUNITARIO, ")
        strSQL.Append(" NECESIDADREAL = @NECESIDADREAL, ")
        strSQL.Append(" NECESIDADAJUSTADA = @NECESIDADAJUSTADA, ")
        strSQL.Append(" NECESIDADFINAL = @NECESIDADFINAL, ")
        strSQL.Append(" PRESUPUESTOREAL = @PRESUPUESTOREAL, ")
        strSQL.Append(" PRESUPUESTOAJUSTADO = @PRESUPUESTOAJUSTADO, ")
        strSQL.Append(" PRESUPUESTOFINAL = @PRESUPUESTOFINAL, ")
        strSQL.Append(" COSTOTOTALREAL = @COSTOTOTALREAL, ")
        strSQL.Append(" COSTOTOTALAJUSTADO = @COSTOTOTALAJUSTADO, ")
        strSQL.Append(" COMPRASENTRANSITO = @COMPRASENTRANSITO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(23) As SqlParameter
        args(0) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(0).Value = lEntidad.IDUNIDADMEDIDA
        args(1) = New SqlParameter("@CONSUMOANUAL", SqlDbType.Decimal)
        args(1).Value = lEntidad.CONSUMOANUAL
        args(2) = New SqlParameter("@DEMANDAINSATISFECHA", SqlDbType.Decimal)
        args(2).Value = lEntidad.DEMANDAINSATISFECHA
        args(3) = New SqlParameter("@RESERVAESTABLECIMIENTO", SqlDbType.Decimal)
        args(3).Value = lEntidad.RESERVAESTABLECIMIENTO
        args(4) = New SqlParameter("@RESERVATOTAL", SqlDbType.Decimal)
        args(4).Value = lEntidad.RESERVATOTAL
        args(5) = New SqlParameter("@EXISTENCIAESTIMADA", SqlDbType.Decimal)
        args(5).Value = lEntidad.EXISTENCIAESTIMADA
        args(6) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Decimal)
        args(6).Value = lEntidad.PRECIOUNITARIO
        args(7) = New SqlParameter("@NECESIDADREAL", SqlDbType.Decimal)
        args(7).Value = lEntidad.NECESIDADREAL
        args(8) = New SqlParameter("@NECESIDADAJUSTADA", SqlDbType.Decimal)
        args(8).Value = lEntidad.NECESIDADAJUSTADA
        args(9) = New SqlParameter("@NECESIDADFINAL", SqlDbType.Decimal)
        args(9).Value = lEntidad.NECESIDADFINAL
        args(10) = New SqlParameter("@PRESUPUESTOREAL", SqlDbType.Decimal)
        args(10).Value = lEntidad.PRESUPUESTOREAL
        args(11) = New SqlParameter("@PRESUPUESTOAJUSTADO", SqlDbType.Decimal)
        args(11).Value = lEntidad.PRESUPUESTOAJUSTADO
        args(12) = New SqlParameter("@PRESUPUESTOFINAL", SqlDbType.Decimal)
        args(12).Value = lEntidad.PRESUPUESTOFINAL
        args(13) = New SqlParameter("@COSTOTOTALREAL", SqlDbType.Decimal)
        args(13).Value = lEntidad.COSTOTOTALREAL
        args(14) = New SqlParameter("@COSTOTOTALAJUSTADO", SqlDbType.Decimal)
        args(14).Value = lEntidad.COSTOTOTALAJUSTADO
        args(15) = New SqlParameter("@COMPRASENTRANSITO", SqlDbType.Decimal)
        args(15).Value = lEntidad.COMPRASENTRANSITO
        args(16) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(17) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(17).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(18) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(18).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(19) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(19).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(20) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(20).Value = lEntidad.ESTASINCRONIZADA
        args(21) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(21).Value = lEntidad.IDESTABLECIMIENTO
        args(22) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(22).Value = lEntidad.IDNECESIDAD
        args(23) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(23).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLENECESIDADESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDNECESIDAD, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" CONSUMOANUAL, ")
        strSQL.Append(" DEMANDAINSATISFECHA, ")
        strSQL.Append(" RESERVAESTABLECIMIENTO, ")
        strSQL.Append(" RESERVATOTAL, ")
        strSQL.Append(" EXISTENCIAESTIMADA, ")
        strSQL.Append(" PRECIOUNITARIO, ")
        strSQL.Append(" NECESIDADREAL, ")
        strSQL.Append(" NECESIDADAJUSTADA, ")
        strSQL.Append(" NECESIDADFINAL, ")
        strSQL.Append(" PRESUPUESTOREAL, ")
        strSQL.Append(" PRESUPUESTOAJUSTADO, ")
        strSQL.Append(" PRESUPUESTOFINAL, ")
        strSQL.Append(" COSTOTOTALREAL, ")
        strSQL.Append(" COSTOTOTALAJUSTADO, ")
        strSQL.Append(" COMPRASENTRANSITO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDNECESIDAD, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @CONSUMOANUAL, ")
        strSQL.Append(" @DEMANDAINSATISFECHA, ")
        strSQL.Append(" @RESERVAESTABLECIMIENTO, ")
        strSQL.Append(" @RESERVATOTAL, ")
        strSQL.Append(" @EXISTENCIAESTIMADA, ")
        strSQL.Append(" @PRECIOUNITARIO, ")
        strSQL.Append(" @NECESIDADREAL, ")
        strSQL.Append(" @NECESIDADAJUSTADA, ")
        strSQL.Append(" @NECESIDADFINAL, ")
        strSQL.Append(" @PRESUPUESTOREAL, ")
        strSQL.Append(" @PRESUPUESTOAJUSTADO, ")
        strSQL.Append(" @PRESUPUESTOFINAL, ")
        strSQL.Append(" @COSTOTOTALREAL, ")
        strSQL.Append(" @COSTOTOTALAJUSTADO, ")
        strSQL.Append(" @COMPRASENTRANSITO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(23) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(3).Value = lEntidad.IDUNIDADMEDIDA
        args(4) = New SqlParameter("@CONSUMOANUAL", SqlDbType.Decimal)
        args(4).Value = lEntidad.CONSUMOANUAL
        args(5) = New SqlParameter("@DEMANDAINSATISFECHA", SqlDbType.Decimal)
        args(5).Value = lEntidad.DEMANDAINSATISFECHA
        args(6) = New SqlParameter("@RESERVAESTABLECIMIENTO", SqlDbType.Decimal)
        args(6).Value = lEntidad.RESERVAESTABLECIMIENTO
        args(7) = New SqlParameter("@RESERVATOTAL", SqlDbType.Decimal)
        args(7).Value = lEntidad.RESERVATOTAL
        args(8) = New SqlParameter("@EXISTENCIAESTIMADA", SqlDbType.Decimal)
        args(8).Value = lEntidad.EXISTENCIAESTIMADA
        args(9) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Decimal)
        args(9).Value = lEntidad.PRECIOUNITARIO
        args(10) = New SqlParameter("@NECESIDADREAL", SqlDbType.Decimal)
        args(10).Value = lEntidad.NECESIDADREAL
        args(11) = New SqlParameter("@NECESIDADAJUSTADA", SqlDbType.Decimal)
        args(11).Value = lEntidad.NECESIDADAJUSTADA
        args(12) = New SqlParameter("@NECESIDADFINAL", SqlDbType.Decimal)
        args(12).Value = lEntidad.NECESIDADFINAL
        args(13) = New SqlParameter("@PRESUPUESTOREAL", SqlDbType.Decimal)
        args(13).Value = lEntidad.PRESUPUESTOREAL
        args(14) = New SqlParameter("@PRESUPUESTOAJUSTADO", SqlDbType.Decimal)
        args(14).Value = lEntidad.PRESUPUESTOAJUSTADO
        args(15) = New SqlParameter("@PRESUPUESTOFINAL", SqlDbType.Decimal)
        args(15).Value = lEntidad.PRESUPUESTOFINAL
        args(16) = New SqlParameter("@COSTOTOTALREAL", SqlDbType.Decimal)
        args(16).Value = lEntidad.COSTOTOTALREAL
        args(17) = New SqlParameter("@COSTOTOTALAJUSTADO", SqlDbType.Decimal)
        args(17).Value = lEntidad.COSTOTOTALAJUSTADO
        args(18) = New SqlParameter("@COMPRASENTRANSITO", SqlDbType.Decimal)
        args(18).Value = lEntidad.COMPRASENTRANSITO
        args(19) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(19).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(20) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(20).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(21) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(21).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(22) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(22).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(23) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(23).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLENECESIDADESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLENECESIDADESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
                lEntidad.CONSUMOANUAL = IIf(.Item("CONSUMOANUAL") Is DBNull.Value, Nothing, .Item("CONSUMOANUAL"))
                lEntidad.DEMANDAINSATISFECHA = IIf(.Item("DEMANDAINSATISFECHA") Is DBNull.Value, Nothing, .Item("DEMANDAINSATISFECHA"))
                lEntidad.RESERVAESTABLECIMIENTO = IIf(.Item("RESERVAESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("RESERVAESTABLECIMIENTO"))
                lEntidad.RESERVATOTAL = IIf(.Item("RESERVATOTAL") Is DBNull.Value, Nothing, .Item("RESERVATOTAL"))
                lEntidad.EXISTENCIAESTIMADA = IIf(.Item("EXISTENCIAESTIMADA") Is DBNull.Value, Nothing, .Item("EXISTENCIAESTIMADA"))
                lEntidad.PRECIOUNITARIO = IIf(.Item("PRECIOUNITARIO") Is DBNull.Value, Nothing, .Item("PRECIOUNITARIO"))
                lEntidad.NECESIDADREAL = IIf(.Item("NECESIDADREAL") Is DBNull.Value, Nothing, .Item("NECESIDADREAL"))
                lEntidad.NECESIDADAJUSTADA = IIf(.Item("NECESIDADAJUSTADA") Is DBNull.Value, Nothing, .Item("NECESIDADAJUSTADA"))
                lEntidad.NECESIDADFINAL = IIf(.Item("NECESIDADFINAL") Is DBNull.Value, Nothing, .Item("NECESIDADFINAL"))
                lEntidad.PRESUPUESTOREAL = IIf(.Item("PRESUPUESTOREAL") Is DBNull.Value, Nothing, .Item("PRESUPUESTOREAL"))
                lEntidad.PRESUPUESTOAJUSTADO = IIf(.Item("PRESUPUESTOAJUSTADO") Is DBNull.Value, Nothing, .Item("PRESUPUESTOAJUSTADO"))
                lEntidad.PRESUPUESTOFINAL = IIf(.Item("PRESUPUESTOFINAL") Is DBNull.Value, Nothing, .Item("PRESUPUESTOFINAL"))
                lEntidad.COSTOTOTALREAL = IIf(.Item("COSTOTOTALREAL") Is DBNull.Value, Nothing, .Item("COSTOTOTALREAL"))
                lEntidad.COSTOTOTALAJUSTADO = IIf(.Item("COSTOTOTALAJUSTADO") Is DBNull.Value, Nothing, .Item("COSTOTOTALAJUSTADO"))
                lEntidad.COMPRASENTRANSITO = IIf(.Item("COMPRASENTRANSITO") Is DBNull.Value, Nothing, .Item("COMPRASENTRANSITO"))
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

        Return -1

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64) As listaDETALLENECESIDADESTABLECIMIENTOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLENECESIDADESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLENECESIDADESTABLECIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDNECESIDAD = IDNECESIDAD
                mEntidad.IDPRODUCTO = IDPRODUCTO
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.CONSUMOANUAL = IIf(dr("CONSUMOANUAL") Is DBNull.Value, Nothing, dr("CONSUMOANUAL"))
                mEntidad.DEMANDAINSATISFECHA = IIf(dr("DEMANDAINSATISFECHA") Is DBNull.Value, Nothing, dr("DEMANDAINSATISFECHA"))
                mEntidad.RESERVAESTABLECIMIENTO = IIf(dr("RESERVAESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("RESERVAESTABLECIMIENTO"))
                mEntidad.RESERVATOTAL = IIf(dr("RESERVATOTAL") Is DBNull.Value, Nothing, dr("RESERVATOTAL"))
                mEntidad.EXISTENCIAESTIMADA = IIf(dr("EXISTENCIAESTIMADA") Is DBNull.Value, Nothing, dr("EXISTENCIAESTIMADA"))
                mEntidad.PRECIOUNITARIO = IIf(dr("PRECIOUNITARIO") Is DBNull.Value, Nothing, dr("PRECIOUNITARIO"))
                mEntidad.NECESIDADREAL = IIf(dr("NECESIDADREAL") Is DBNull.Value, Nothing, dr("NECESIDADREAL"))
                mEntidad.NECESIDADAJUSTADA = IIf(dr("NECESIDADAJUSTADA") Is DBNull.Value, Nothing, dr("NECESIDADAJUSTADA"))
                mEntidad.NECESIDADFINAL = IIf(dr("NECESIDADFINAL") Is DBNull.Value, Nothing, dr("NECESIDADFINAL"))
                mEntidad.PRESUPUESTOREAL = IIf(dr("PRESUPUESTOREAL") Is DBNull.Value, Nothing, dr("PRESUPUESTOREAL"))
                mEntidad.PRESUPUESTOAJUSTADO = IIf(dr("PRESUPUESTOAJUSTADO") Is DBNull.Value, Nothing, dr("PRESUPUESTOAJUSTADO"))
                mEntidad.PRESUPUESTOFINAL = IIf(dr("PRESUPUESTOFINAL") Is DBNull.Value, Nothing, dr("PRESUPUESTOFINAL"))
                mEntidad.COSTOTOTALREAL = IIf(dr("COSTOTOTALREAL") Is DBNull.Value, Nothing, dr("COSTOTOTALREAL"))
                mEntidad.COSTOTOTALAJUSTADO = IIf(dr("COSTOTOTALAJUSTADO") Is DBNull.Value, Nothing, dr("COSTOTOTALAJUSTADO"))
                mEntidad.COMPRASENTRANSITO = IIf(dr("COMPRASENTRANSITO") Is DBNull.Value, Nothing, dr("COMPRASENTRANSITO"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim tables(0) As String
        tables(0) = New String("DETALLENECESIDADESTABLECIMIENTOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDNECESIDAD, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" CONSUMOANUAL, ")
        strSQL.Append(" DEMANDAINSATISFECHA, ")
        strSQL.Append(" RESERVAESTABLECIMIENTO, ")
        strSQL.Append(" RESERVATOTAL, ")
        strSQL.Append(" EXISTENCIAESTIMADA, ")
        strSQL.Append(" PRECIOUNITARIO, ")
        strSQL.Append(" NECESIDADREAL, ")
        strSQL.Append(" NECESIDADAJUSTADA, ")
        strSQL.Append(" NECESIDADFINAL, ")
        strSQL.Append(" PRESUPUESTOREAL, ")
        strSQL.Append(" PRESUPUESTOAJUSTADO, ")
        strSQL.Append(" PRESUPUESTOFINAL, ")
        strSQL.Append(" COSTOTOTALREAL, ")
        strSQL.Append(" COSTOTOTALAJUSTADO, ")
        strSQL.Append(" COMPRASENTRANSITO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ")

    End Sub

#End Region

End Class
