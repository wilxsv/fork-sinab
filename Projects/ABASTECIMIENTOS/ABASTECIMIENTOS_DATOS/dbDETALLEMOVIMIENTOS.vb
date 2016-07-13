Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLEMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_ALM_DETALLEMOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	12/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLEMOVIMIENTOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEMOVIMIENTOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDDETALLEMOVIMIENTO = 0 _
            Or lEntidad.IDDETALLEMOVIMIENTO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDDETALLEMOVIMIENTO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL.Append("SET IDALMACEN = @IDALMACEN, ")
        strSQL.Append("IDLOTE = @IDLOTE, ")
        strSQL.Append("IDPRODUCTO = @IDPRODUCTO, ")
        strSQL.Append("RENGLON = @RENGLON, ")
        strSQL.Append("CANTIDAD = @CANTIDAD, ")
        strSQL.Append("CANTIDADRECHAZADA = @CANTIDADRECHAZADA, ")
        strSQL.Append("CANTIDADANTERIOR = @CANTIDADANTERIOR, ")
        strSQL.Append("NUMEROFACTURA = @NUMEROFACTURA, ")
        strSQL.Append("NOENVIO = @NOENVIO, ")
        strSQL.Append("FECHAFACTURA = @FECHAFACTURA, ")
        strSQL.Append("MONTO = @MONTO, ")
        strSQL.Append("NUMEROINFORMECONTROLCALIDAD = @NUMEROINFORMECONTROLCALIDAD, ")
        strSQL.Append("IDDETALLEENTREGA = @IDDETALLEENTREGA, ")
        strSQL.Append("IDTIPODOCUMENTO = @IDTIPODOCUMENTO, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA, ")
        strSQL.Append("CANTIDADNODISPONIBLE = @CANTIDADNODISPONIBLE ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND IDDETALLEMOVIMIENTO = @IDDETALLEMOVIMIENTO ")

        Dim args(23) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(1).Value = IIf(lEntidad.IDLOTE = Nothing, DBNull.Value, lEntidad.IDLOTE)
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = IIf(lEntidad.RENGLON = Nothing, DBNull.Value, lEntidad.RENGLON)
        args(4) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args(4).Value = lEntidad.CANTIDAD
        args(5) = New SqlParameter("@CANTIDADRECHAZADA", SqlDbType.Decimal)
        args(5).Value = IIf(lEntidad.CANTIDADRECHAZADA = Nothing, DBNull.Value, lEntidad.CANTIDADRECHAZADA)
        args(6) = New SqlParameter("@CANTIDADANTERIOR", SqlDbType.Decimal)
        args(6).Value = IIf(lEntidad.CANTIDADANTERIOR = Nothing, DBNull.Value, lEntidad.CANTIDADANTERIOR)
        args(7) = New SqlParameter("@NUMEROFACTURA", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.NUMEROFACTURA = Nothing, DBNull.Value, lEntidad.NUMEROFACTURA)
        args(8) = New SqlParameter("@FECHAFACTURA", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.FECHAFACTURA = Nothing, DBNull.Value, lEntidad.FECHAFACTURA)
        args(9) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args(9).Value = lEntidad.MONTO
        args(10) = New SqlParameter("@NUMEROINFORMECONTROLCALIDAD", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.NUMEROINFORMECONTROLCALIDAD = Nothing, DBNull.Value, lEntidad.NUMEROINFORMECONTROLCALIDAD)
        args(11) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.Int)
        args(11).Value = lEntidad.IDDETALLEENTREGA
        args(12) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(13) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(14) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(15) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(15).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(16) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(16).Value = lEntidad.ESTASINCRONIZADA
        args(17) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(17).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(18) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(18).Value = IIf(lEntidad.IDTIPOTRANSACCION = Nothing, DBNull.Value, lEntidad.IDTIPOTRANSACCION)
        args(19) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(19).Value = IIf(lEntidad.IDMOVIMIENTO = Nothing, DBNull.Value, lEntidad.IDMOVIMIENTO)
        args(20) = New SqlParameter("@IDDETALLEMOVIMIENTO", SqlDbType.BigInt)
        args(20).Value = IIf(lEntidad.IDDETALLEMOVIMIENTO = Nothing, DBNull.Value, lEntidad.IDDETALLEMOVIMIENTO)
        args(21) = New SqlParameter("@NOENVIO", SqlDbType.VarChar)
        args(21).Value = IIf(lEntidad.NOENVIO = Nothing, DBNull.Value, lEntidad.NOENVIO)
        args(22) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(22).Value = IIf(lEntidad.IDTIPODOCUMENTO = Nothing, DBNull.Value, lEntidad.IDTIPODOCUMENTO)
        args(23) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.SmallInt)
        args(23).Value = lEntidad.CANTIDADNODISPONIBLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEMOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL.Append("( IDESTABLECIMIENTO, ")
        strSQL.Append("IDTIPOTRANSACCION, ")
        strSQL.Append("IDMOVIMIENTO, ")
        strSQL.Append("IDDETALLEMOVIMIENTO, ")
        strSQL.Append("IDALMACEN, ")
        strSQL.Append("IDLOTE, ")
        strSQL.Append("IDPRODUCTO, ")
        strSQL.Append("RENGLON, ")
        strSQL.Append("CANTIDAD, ")
        strSQL.Append("CANTIDADRECHAZADA, ")
        strSQL.Append("CANTIDADANTERIOR, ")
        strSQL.Append("NUMEROFACTURA, ")
        strSQL.Append("NOENVIO, ")
        strSQL.Append("FECHAFACTURA, ")
        strSQL.Append("MONTO, ")
        strSQL.Append("NUMEROINFORMECONTROLCALIDAD, ")
        strSQL.Append("IDDETALLEENTREGA, ")
        strSQL.Append("IDTIPODOCUMENTO, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("ESTASINCRONIZADA, ")
        strSQL.Append("CANTIDADNODISPONIBLE) ")
        strSQL.Append("VALUES ")
        strSQL.Append("( @IDESTABLECIMIENTO, ")
        strSQL.Append("@IDTIPOTRANSACCION, ")
        strSQL.Append("@IDMOVIMIENTO, ")
        strSQL.Append("@IDDETALLEMOVIMIENTO, ")
        strSQL.Append("@IDALMACEN, ")
        strSQL.Append("@IDLOTE, ")
        strSQL.Append("@IDPRODUCTO, ")
        strSQL.Append("@RENGLON, ")
        strSQL.Append("@CANTIDAD, ")
        strSQL.Append("@CANTIDADRECHAZADA, ")
        strSQL.Append("@CANTIDADANTERIOR, ")
        strSQL.Append("@NUMEROFACTURA, ")
        strSQL.Append("@NOENVIO, ")
        strSQL.Append("@FECHAFACTURA, ")
        strSQL.Append("@MONTO, ")
        strSQL.Append("@NUMEROINFORMECONTROLCALIDAD, ")
        strSQL.Append("@IDDETALLEENTREGA, ")
        strSQL.Append("@IDTIPODOCUMENTO, ")
        strSQL.Append("@AUUSUARIOCREACION, ")
        strSQL.Append("@AUFECHACREACION, ")
        strSQL.Append("@ESTASINCRONIZADA, ")
        strSQL.Append("@CANTIDADNODISPONIBLE) ")

        Dim args(23) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDMOVIMIENTO
        args(3) = New SqlParameter("@IDDETALLEMOVIMIENTO", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLEMOVIMIENTO
        args(4) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(4).Value = lEntidad.IDALMACEN
        args(5) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(5).Value = IIf(lEntidad.IDLOTE = Nothing, DBNull.Value, lEntidad.IDLOTE)
        args(6) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(6).Value = lEntidad.IDPRODUCTO
        args(7) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(7).Value = IIf(lEntidad.RENGLON = Nothing, DBNull.Value, lEntidad.RENGLON)
        args(8) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args(8).Value = lEntidad.CANTIDAD
        args(9) = New SqlParameter("@CANTIDADRECHAZADA", SqlDbType.Decimal)
        args(9).Value = IIf(lEntidad.CANTIDADRECHAZADA = Nothing, DBNull.Value, lEntidad.CANTIDADRECHAZADA)
        args(10) = New SqlParameter("@CANTIDADANTERIOR", SqlDbType.Decimal)
        args(10).Value = IIf(lEntidad.CANTIDADANTERIOR = Nothing, DBNull.Value, lEntidad.CANTIDADANTERIOR)
        args(11) = New SqlParameter("@NUMEROFACTURA", SqlDbType.VarChar)
        args(11).Value = IIf(lEntidad.NUMEROFACTURA = Nothing, DBNull.Value, lEntidad.NUMEROFACTURA)
        args(12) = New SqlParameter("@FECHAFACTURA", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.FECHAFACTURA = Nothing, DBNull.Value, lEntidad.FECHAFACTURA)
        args(13) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args(13).Value = lEntidad.MONTO
        args(14) = New SqlParameter("@NUMEROINFORMECONTROLCALIDAD", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.NUMEROINFORMECONTROLCALIDAD = Nothing, DBNull.Value, lEntidad.NUMEROINFORMECONTROLCALIDAD)
        args(15) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.Int)
        args(15).Value = lEntidad.IDDETALLEENTREGA
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
        args(21) = New SqlParameter("@NOENVIO", SqlDbType.VarChar)
        args(21).Value = IIf(lEntidad.NOENVIO = Nothing, DBNull.Value, lEntidad.NOENVIO)
        args(22) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(22).Value = IIf(lEntidad.IDTIPODOCUMENTO = Nothing, DBNull.Value, lEntidad.IDTIPODOCUMENTO)
        args(23) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.SmallInt)
        args(23).Value = lEntidad.CANTIDADNODISPONIBLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEMOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND IDDETALLEMOVIMIENTO = @IDDETALLEMOVIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDMOVIMIENTO
        args(3) = New SqlParameter("@IDDETALLEMOVIMIENTO", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLEMOVIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEMOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")
        strSQL.Append("AND IDDETALLEMOVIMIENTO = @IDDETALLEMOVIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDMOVIMIENTO
        args(3) = New SqlParameter("@IDDETALLEMOVIMIENTO", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLEMOVIMIENTO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDALMACEN = IIf(.Item("IDALMACEN") Is DBNull.Value, Nothing, .Item("IDALMACEN"))
                lEntidad.IDLOTE = IIf(.Item("IDLOTE") Is DBNull.Value, Nothing, .Item("IDLOTE"))
                lEntidad.IDPRODUCTO = IIf(.Item("IDPRODUCTO") Is DBNull.Value, Nothing, .Item("IDPRODUCTO"))
                lEntidad.RENGLON = IIf(.Item("RENGLON") Is DBNull.Value, Nothing, .Item("RENGLON"))
                lEntidad.CANTIDAD = IIf(.Item("CANTIDAD") Is DBNull.Value, Nothing, .Item("CANTIDAD"))
                lEntidad.CANTIDADRECHAZADA = IIf(.Item("CANTIDADRECHAZADA") Is DBNull.Value, Nothing, .Item("CANTIDADRECHAZADA"))
                lEntidad.CANTIDADANTERIOR = IIf(.Item("CANTIDADANTERIOR") Is DBNull.Value, Nothing, .Item("CANTIDADANTERIOR"))
                lEntidad.NUMEROFACTURA = IIf(.Item("NUMEROFACTURA") Is DBNull.Value, Nothing, .Item("NUMEROFACTURA"))
                lEntidad.NOENVIO = IIf(.Item("NOENVIO") Is DBNull.Value, Nothing, .Item("NOENVIO"))
                lEntidad.FECHAFACTURA = IIf(.Item("FECHAFACTURA") Is DBNull.Value, Nothing, .Item("FECHAFACTURA"))
                lEntidad.MONTO = IIf(.Item("MONTO") Is DBNull.Value, Nothing, .Item("MONTO"))
                lEntidad.NUMEROINFORMECONTROLCALIDAD = IIf(.Item("NUMEROINFORMECONTROLCALIDAD") Is DBNull.Value, Nothing, .Item("NUMEROINFORMECONTROLCALIDAD"))
                lEntidad.IDDETALLEENTREGA = IIf(.Item("IDDETALLEENTREGA") Is DBNull.Value, Nothing, .Item("IDDETALLEENTREGA"))
                lEntidad.IDTIPODOCUMENTO = IIf(.Item("IDTIPODOCUMENTO") Is DBNull.Value, Nothing, .Item("IDTIPODOCUMENTO"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.CANTIDADNODISPONIBLE = IIf(.Item("CANTIDADNODISPONIBLE") Is DBNull.Value, Nothing, .Item("CANTIDADNODISPONIBLE"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As DETALLEMOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLEMOVIMIENTO),0) + 1 ")
        strSQL.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDMOVIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As listaDETALLEMOVIMIENTOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = IDMOVIMIENTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLEMOVIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLEMOVIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDTIPOTRANSACCION = IDTIPOTRANSACCION
                mEntidad.IDMOVIMIENTO = IDMOVIMIENTO
                mEntidad.IDDETALLEMOVIMIENTO = IIf(dr("IDDETALLEMOVIMIENTO") Is DBNull.Value, Nothing, dr("IDDETALLEMOVIMIENTO"))
                mEntidad.IDALMACEN = IIf(dr("IDALMACEN") Is DBNull.Value, Nothing, dr("IDALMACEN"))
                mEntidad.IDLOTE = IIf(dr("IDLOTE") Is DBNull.Value, Nothing, dr("IDLOTE"))
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.RENGLON = IIf(dr("RENGLON") Is DBNull.Value, Nothing, dr("RENGLON"))
                mEntidad.CANTIDAD = IIf(dr("CANTIDAD") Is DBNull.Value, Nothing, dr("CANTIDAD"))
                mEntidad.CANTIDADRECHAZADA = IIf(dr("CANTIDADRECHAZADA") Is DBNull.Value, Nothing, dr("CANTIDADRECHAZADA"))
                mEntidad.CANTIDADANTERIOR = IIf(dr("CANTIDADANTERIOR") Is DBNull.Value, Nothing, dr("CANTIDADANTERIOR"))
                mEntidad.NUMEROFACTURA = IIf(dr("NUMEROFACTURA") Is DBNull.Value, Nothing, dr("NUMEROFACTURA"))
                mEntidad.NOENVIO = IIf(dr("NOENVIO") Is DBNull.Value, Nothing, dr("NOENVIO"))
                mEntidad.FECHAFACTURA = IIf(dr("FECHAFACTURA") Is DBNull.Value, Nothing, dr("FECHAFACTURA"))
                mEntidad.MONTO = IIf(dr("MONTO") Is DBNull.Value, Nothing, dr("MONTO"))
                mEntidad.NUMEROINFORMECONTROLCALIDAD = IIf(dr("NUMEROINFORMECONTROLCALIDAD") Is DBNull.Value, Nothing, dr("NUMEROINFORMECONTROLCALIDAD"))
                mEntidad.IDDETALLEENTREGA = IIf(dr("IDDETALLEENTREGA") Is DBNull.Value, Nothing, dr("IDDETALLEENTREGA"))
                mEntidad.IDTIPODOCUMENTO = IIf(dr("IDTIPODOCUMENTO") Is DBNull.Value, Nothing, dr("IDTIPODOCUMENTO"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.CANTIDADNODISPONIBLE = IIf(dr("CANTIDADNODISPONIBLE") Is DBNull.Value, Nothing, dr("CANTIDADNODISPONIBLE"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = IDMOVIMIENTO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append("AND IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = IDMOVIMIENTO

        Dim tables(0) As String
        tables(0) = New String("DETALLEMOVIMIENTOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append("SELECT IDESTABLECIMIENTO, ")
        strSQL.Append("IDTIPOTRANSACCION, ")
        strSQL.Append("IDMOVIMIENTO, ")
        strSQL.Append("IDDETALLEMOVIMIENTO, ")
        strSQL.Append("IDALMACEN, ")
        strSQL.Append("IDLOTE, ")
        strSQL.Append("IDPRODUCTO, ")
        strSQL.Append("RENGLON, ")
        strSQL.Append("CANTIDAD, ")
        strSQL.Append("CANTIDADRECHAZADA, ")
        strSQL.Append("CANTIDADANTERIOR, ")
        strSQL.Append("NUMEROFACTURA, ")
        strSQL.Append("NOENVIO, ")
        strSQL.Append("FECHAFACTURA, ")
        strSQL.Append("MONTO, ")
        strSQL.Append("NUMEROINFORMECONTROLCALIDAD, ")
        strSQL.Append("IDDETALLEENTREGA, ")
        strSQL.Append("IDTIPODOCUMENTO, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA, ")
        strSQL.Append("CANTIDADNODISPONIBLE ")
        strSQL.Append("FROM SAB_ALM_DETALLEMOVIMIENTOS ")

    End Sub

#End Region

End Class
