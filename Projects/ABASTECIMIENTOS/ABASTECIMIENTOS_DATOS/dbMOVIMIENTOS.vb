Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_ALM_MOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	06/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbMOVIMIENTOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        

        Dim lEntidad As MOVIMIENTOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDMOVIMIENTO = 0 _
            Or lEntidad.IDMOVIMIENTO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDMOVIMIENTO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_ALM_MOVIMIENTOS ")
        strSQL.Append(" SET IDTIPODOCREF = @IDTIPODOCREF, ")
        strSQL.Append(" NUMERODOCREF = @NUMERODOCREF, ")
        strSQL.Append(" IDALMACEN = @IDALMACEN, ")
        strSQL.Append(" ANIO = @ANIO, ")
        strSQL.Append(" IDDOCUMENTO = @IDDOCUMENTO, ")
        strSQL.Append(" IDESTADO = @IDESTADO, ")
        strSQL.Append(" FECHAMOVIMIENTO = @FECHAMOVIMIENTO, ")
        strSQL.Append(" IDESTABLECIMIENTODESTINO = @IDESTABLECIMIENTODESTINO, ")
        strSQL.Append(" IDALMACENDESTINO = @IDALMACENDESTINO, ")
        strSQL.Append(" IDUNIDADSOLICITA = @IDUNIDADSOLICITA, ")
        strSQL.Append(" TOTALMOVIMIENTO = @TOTALMOVIMIENTO, ")
        strSQL.Append(" IDEMPLEADOSOLICITA = @IDEMPLEADOSOLICITA, ")
        strSQL.Append(" IDEMPLEADOAUTORIZA = @IDEMPLEADOAUTORIZA, ")
        strSQL.Append(" IDEMPLEADOALMACEN = @IDEMPLEADOALMACEN, ")
        strSQL.Append(" EMPLEADOALMACEN = @EMPLEADOALMACEN, ")
        strSQL.Append(" IDEMPLEADODESPACHA = @IDEMPLEADODESPACHA, ")
        strSQL.Append(" IDEMPLEADORECIBE = @IDEMPLEADORECIBE, ")
        strSQL.Append(" IDEMPLEADOPREPARA = @IDEMPLEADOPREPARA, ")
        strSQL.Append(" IDEMPLEADOENVIADO = @IDEMPLEADOENVIADO, ")
        strSQL.Append(" CLASIFICACIONMOVIMIENTO = @CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append(" SUBCLASIFICACIONMOVIMIENTO = @SUBCLASIFICACIONMOVIMIENTO, ")
        strSQL.Append(" RESPONSABLEDISTRIBUCION = @RESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" MOTIVO = @MOTIVO, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA, ")
        strSQL.Append(" EMPLEADOPREPARA = @EMPLEADOPREPARA, ")
        strSQL.Append(" ID_LUGAR_ENTREGA_HOSPITAL = @ID_LUGAR_ENTREGA_HOSPITAL ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args(32) As SqlParameter
        args(0) = New SqlParameter("@IDTIPODOCREF", SqlDbType.Int)
        args(0).Value = IIf(lEntidad.IDTIPODOCREF = Nothing, DBNull.Value, lEntidad.IDTIPODOCREF)
        args(1) = New SqlParameter("@NUMERODOCREF", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.NUMERODOCREF = Nothing, DBNull.Value, lEntidad.NUMERODOCREF)
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = IIf(lEntidad.IDALMACEN = Nothing, DBNull.Value, lEntidad.IDALMACEN)
        args(3) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(3).Value = IIf(lEntidad.ANIO = Nothing, DBNull.Value, lEntidad.ANIO)
        args(4) = New SqlParameter("@IDDOCUMENTO", SqlDbType.Int)
        args(4).Value = IIf(lEntidad.IDDOCUMENTO = Nothing, DBNull.Value, lEntidad.IDDOCUMENTO)
        args(5) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(5).Value = lEntidad.IDESTADO
        args(6) = New SqlParameter("@FECHAMOVIMIENTO", SqlDbType.DateTime)
        args(6).Value = IIf(lEntidad.FECHAMOVIMIENTO = Nothing, DBNull.Value, lEntidad.FECHAMOVIMIENTO)
        args(7) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.Int)
        args(7).Value = IIf(lEntidad.IDESTABLECIMIENTODESTINO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTODESTINO)
        args(8) = New SqlParameter("@IDALMACENDESTINO", SqlDbType.Int)
        args(8).Value = IIf(lEntidad.IDALMACENDESTINO = Nothing, DBNull.Value, lEntidad.IDALMACENDESTINO)
        args(9) = New SqlParameter("@IDUNIDADSOLICITA", SqlDbType.Int)
        args(9).Value = IIf(lEntidad.IDUNIDADSOLICITA = Nothing, DBNull.Value, lEntidad.IDUNIDADSOLICITA)
        args(10) = New SqlParameter("@TOTALMOVIMIENTO", SqlDbType.Decimal)
        args(10).Value = lEntidad.TOTALMOVIMIENTO
        args(11) = New SqlParameter("@IDEMPLEADOSOLICITA", SqlDbType.Int)
        args(11).Value = IIf(lEntidad.IDEMPLEADOSOLICITA = Nothing, DBNull.Value, lEntidad.IDEMPLEADOSOLICITA)
        args(12) = New SqlParameter("@IDEMPLEADOAUTORIZA", SqlDbType.Int)
        args(12).Value = IIf(lEntidad.IDEMPLEADOAUTORIZA = Nothing, DBNull.Value, lEntidad.IDEMPLEADOAUTORIZA)
        args(13) = New SqlParameter("@IDEMPLEADOALMACEN", SqlDbType.Int)
        args(13).Value = IIf(lEntidad.IDEMPLEADOALMACEN = Nothing, DBNull.Value, lEntidad.IDEMPLEADOALMACEN)
        args(14) = New SqlParameter("@EMPLEADOALMACEN", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.EMPLEADOALMACEN = Nothing, DBNull.Value, lEntidad.EMPLEADOALMACEN)
        args(15) = New SqlParameter("@IDEMPLEADODESPACHA", SqlDbType.Int)
        args(15).Value = IIf(lEntidad.IDEMPLEADODESPACHA = Nothing, DBNull.Value, lEntidad.IDEMPLEADODESPACHA)
        args(16) = New SqlParameter("@IDEMPLEADORECIBE", SqlDbType.Int)
        args(16).Value = IIf(lEntidad.IDEMPLEADORECIBE = Nothing, DBNull.Value, lEntidad.IDEMPLEADORECIBE)
        args(17) = New SqlParameter("@IDEMPLEADOPREPARA", SqlDbType.Int)
        args(17).Value = IIf(lEntidad.IDEMPLEADOPREPARA = Nothing, DBNull.Value, lEntidad.IDEMPLEADOPREPARA)
        args(18) = New SqlParameter("@IDEMPLEADOENVIADO", SqlDbType.Int)
        args(18).Value = IIf(lEntidad.IDEMPLEADOENVIADO = Nothing, DBNull.Value, lEntidad.IDEMPLEADOENVIADO)
        args(19) = New SqlParameter("@CLASIFICACIONMOVIMIENTO", SqlDbType.TinyInt)
        args(19).Value = IIf(lEntidad.CLASIFICACIONMOVIMIENTO = Nothing, 0, lEntidad.CLASIFICACIONMOVIMIENTO)
        args(20) = New SqlParameter("@SUBCLASIFICACIONMOVIMIENTO", SqlDbType.TinyInt)
        args(20).Value = IIf(lEntidad.SUBCLASIFICACIONMOVIMIENTO = Nothing, 0, lEntidad.SUBCLASIFICACIONMOVIMIENTO)
        args(21) = New SqlParameter("@RESPONSABLEDISTRIBUCION", SqlDbType.VarChar)
        args(21).Value = IIf(lEntidad.RESPONSABLEDISTRIBUCION = Nothing, DBNull.Value, lEntidad.RESPONSABLEDISTRIBUCION)
        args(22) = New SqlParameter("@MOTIVO", SqlDbType.VarChar)
        args(22).Value = IIf(lEntidad.MOTIVO = Nothing, DBNull.Value, lEntidad.MOTIVO)
        args(23) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(23).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(24) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(24).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(25) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(25).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(26) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(26).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(27) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(27).Value = lEntidad.ESTASINCRONIZADA
        args(28) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(28).Value = lEntidad.IDESTABLECIMIENTO
        args(29) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(29).Value = lEntidad.IDTIPOTRANSACCION
        args(30) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(30).Value = lEntidad.IDMOVIMIENTO
        args(31) = New SqlParameter("@EMPLEADOPREPARA", SqlDbType.VarChar)
        args(31).Value = IIf(lEntidad.EMPLEADOPREPARA = Nothing, DBNull.Value, lEntidad.EMPLEADOPREPARA)
        args(32) = New SqlParameter("@ID_LUGAR_ENTREGA_HOSPITAL", SqlDbType.Int)
        args(32).Value = IIf(lEntidad.ID_LUGAR_ENTREGA_HOSPITAL = Nothing, DBNull.Value, lEntidad.ID_LUGAR_ENTREGA_HOSPITAL)



       



        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_ALM_MOVIMIENTOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDTIPOTRANSACCION, ")
        strSQL.Append(" IDMOVIMIENTO, ")
        strSQL.Append(" IDTIPODOCREF, ")
        strSQL.Append(" NUMERODOCREF, ")
        strSQL.Append(" IDALMACEN, ")
        strSQL.Append(" ANIO, ")
        strSQL.Append(" IDDOCUMENTO, ")
        strSQL.Append(" IDESTADO, ")
        strSQL.Append(" FECHAMOVIMIENTO, ")
        strSQL.Append(" IDESTABLECIMIENTODESTINO, ")
        strSQL.Append(" IDALMACENDESTINO, ")
        strSQL.Append(" IDUNIDADSOLICITA, ")
        strSQL.Append(" TOTALMOVIMIENTO, ")
        strSQL.Append(" IDEMPLEADOSOLICITA, ")
        strSQL.Append(" IDEMPLEADOAUTORIZA, ")
        strSQL.Append(" IDEMPLEADOALMACEN, ")
        strSQL.Append(" EMPLEADOALMACEN, ")
        strSQL.Append(" IDEMPLEADODESPACHA, ")
        strSQL.Append(" IDEMPLEADORECIBE, ")
        strSQL.Append(" IDEMPLEADOPREPARA, ")
        strSQL.Append(" IDEMPLEADOENVIADO, ")
        strSQL.Append(" CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append(" SUBCLASIFICACIONMOVIMIENTO, ")
        strSQL.Append(" RESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" MOTIVO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" EMPLEADOPREPARA, ")
        strSQL.Append(" ID_LUGAR_ENTREGA_HOSPITAL) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDTIPOTRANSACCION, ")
        strSQL.Append(" @IDMOVIMIENTO, ")
        strSQL.Append(" @IDTIPODOCREF, ")
        strSQL.Append(" @NUMERODOCREF, ")
        strSQL.Append(" @IDALMACEN, ")
        strSQL.Append(" @ANIO, ")
        strSQL.Append(" @IDDOCUMENTO, ")
        strSQL.Append(" @IDESTADO, ")
        strSQL.Append(" @FECHAMOVIMIENTO, ")
        strSQL.Append(" @IDESTABLECIMIENTODESTINO, ")
        strSQL.Append(" @IDALMACENDESTINO, ")
        strSQL.Append(" @IDUNIDADSOLICITA, ")
        strSQL.Append(" @TOTALMOVIMIENTO, ")
        strSQL.Append(" @IDEMPLEADOSOLICITA, ")
        strSQL.Append(" @IDEMPLEADOAUTORIZA, ")
        strSQL.Append(" @IDEMPLEADOALMACEN, ")
        strSQL.Append(" @EMPLEADOALMACEN, ")
        strSQL.Append(" @IDEMPLEADODESPACHA, ")
        strSQL.Append(" @IDEMPLEADORECIBE, ")
        strSQL.Append(" @IDEMPLEADOPREPARA, ")
        strSQL.Append(" @IDEMPLEADOENVIADO, ")
        strSQL.Append(" @CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append(" @SUBCLASIFICACIONMOVIMIENTO, ")
        strSQL.Append(" @RESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" @MOTIVO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @ESTASINCRONIZADA, ")
        strSQL.Append(" @EMPLEADOPREPARA, ")
        strSQL.Append(" @ID_LUGAR_ENTREGA_HOSPITAL) ")

        Dim args(32) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDMOVIMIENTO
        args(3) = New SqlParameter("@IDTIPODOCREF", SqlDbType.Int)
        args(3).Value = IIf(lEntidad.IDTIPODOCREF = Nothing, DBNull.Value, lEntidad.IDTIPODOCREF)
        args(4) = New SqlParameter("@NUMERODOCREF", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.NUMERODOCREF = Nothing, DBNull.Value, lEntidad.NUMERODOCREF)
        args(5) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(5).Value = IIf(lEntidad.IDALMACEN = Nothing, DBNull.Value, lEntidad.IDALMACEN)
        args(6) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(6).Value = IIf(lEntidad.ANIO = Nothing, DBNull.Value, lEntidad.ANIO)
        args(7) = New SqlParameter("@IDDOCUMENTO", SqlDbType.Int)
        args(7).Value = IIf(lEntidad.IDDOCUMENTO = Nothing, DBNull.Value, lEntidad.IDDOCUMENTO)
        args(8) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(8).Value = lEntidad.IDESTADO
        args(9) = New SqlParameter("@FECHAMOVIMIENTO", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.FECHAMOVIMIENTO = Nothing, DBNull.Value, lEntidad.FECHAMOVIMIENTO)
        args(10) = New SqlParameter("@IDESTABLECIMIENTODESTINO", SqlDbType.Int)
        args(10).Value = IIf(lEntidad.IDESTABLECIMIENTODESTINO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTODESTINO)
        args(11) = New SqlParameter("@IDALMACENDESTINO", SqlDbType.Int)
        args(11).Value = IIf(lEntidad.IDALMACENDESTINO = Nothing, DBNull.Value, lEntidad.IDALMACENDESTINO)
        args(12) = New SqlParameter("@IDUNIDADSOLICITA", SqlDbType.Int)
        args(12).Value = IIf(lEntidad.IDUNIDADSOLICITA = Nothing, DBNull.Value, lEntidad.IDUNIDADSOLICITA)
        args(13) = New SqlParameter("@TOTALMOVIMIENTO", SqlDbType.Decimal)
        args(13).Value = lEntidad.TOTALMOVIMIENTO
        args(14) = New SqlParameter("@IDEMPLEADOSOLICITA", SqlDbType.Int)
        args(14).Value = IIf(lEntidad.IDEMPLEADOSOLICITA = Nothing, DBNull.Value, lEntidad.IDEMPLEADOSOLICITA)
        args(15) = New SqlParameter("@IDEMPLEADOAUTORIZA", SqlDbType.Int)
        args(15).Value = IIf(lEntidad.IDEMPLEADOAUTORIZA = Nothing, DBNull.Value, lEntidad.IDEMPLEADOAUTORIZA)
        args(16) = New SqlParameter("@IDEMPLEADOALMACEN", SqlDbType.Int)
        args(16).Value = IIf(lEntidad.IDEMPLEADOALMACEN = Nothing, DBNull.Value, lEntidad.IDEMPLEADOALMACEN)
        args(17) = New SqlParameter("@IDEMPLEADODESPACHA", SqlDbType.Int)
        args(17).Value = IIf(lEntidad.IDEMPLEADODESPACHA = Nothing, DBNull.Value, lEntidad.IDEMPLEADODESPACHA)
        args(18) = New SqlParameter("@IDEMPLEADORECIBE", SqlDbType.Int)
        args(18).Value = IIf(lEntidad.IDEMPLEADORECIBE = Nothing, DBNull.Value, lEntidad.IDEMPLEADORECIBE)
        args(19) = New SqlParameter("@IDEMPLEADOPREPARA", SqlDbType.Int)
        args(19).Value = IIf(lEntidad.IDEMPLEADOPREPARA = Nothing, DBNull.Value, lEntidad.IDEMPLEADOPREPARA)
        args(20) = New SqlParameter("@IDEMPLEADOENVIADO", SqlDbType.Int)
        args(20).Value = IIf(lEntidad.IDEMPLEADOENVIADO = Nothing, DBNull.Value, lEntidad.IDEMPLEADOENVIADO)
        args(21) = New SqlParameter("@CLASIFICACIONMOVIMIENTO", SqlDbType.TinyInt)
        args(21).Value = IIf(lEntidad.CLASIFICACIONMOVIMIENTO = Nothing, 0, lEntidad.CLASIFICACIONMOVIMIENTO)
        args(22) = New SqlParameter("@SUBCLASIFICACIONMOVIMIENTO", SqlDbType.TinyInt)
        args(22).Value = IIf(lEntidad.SUBCLASIFICACIONMOVIMIENTO = Nothing, 0, lEntidad.SUBCLASIFICACIONMOVIMIENTO)
        args(23) = New SqlParameter("@RESPONSABLEDISTRIBUCION", SqlDbType.VarChar)
        args(23).Value = IIf(lEntidad.RESPONSABLEDISTRIBUCION = Nothing, DBNull.Value, lEntidad.RESPONSABLEDISTRIBUCION)
        args(24) = New SqlParameter("@MOTIVO", SqlDbType.VarChar)
        args(24).Value = IIf(lEntidad.MOTIVO = Nothing, DBNull.Value, lEntidad.MOTIVO)
        args(25) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(25).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(26) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(26).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(27) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(27).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(28) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(28).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(29) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(29).Value = lEntidad.ESTASINCRONIZADA
        args(30) = New SqlParameter("@EMPLEADOALMACEN", SqlDbType.VarChar)
        args(30).Value = IIf(lEntidad.EMPLEADOALMACEN = Nothing, DBNull.Value, lEntidad.EMPLEADOALMACEN)
        args(31) = New SqlParameter("@EMPLEADOPREPARA", SqlDbType.VarChar)
        args(31).Value = IIf(lEntidad.EMPLEADOPREPARA = Nothing, DBNull.Value, lEntidad.EMPLEADOPREPARA)
        args(32) = New SqlParameter("@ID_LUGAR_ENTREGA_HOSPITAL", SqlDbType.Int)
        args(32).Value = IIf(lEntidad.ID_LUGAR_ENTREGA_HOSPITAL = Nothing, DBNull.Value, lEntidad.ID_LUGAR_ENTREGA_HOSPITAL)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_MOVIMIENTOS ")
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND IDMOVIMIENTO = @IDMOVIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOTRANSACCION
        args(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDMOVIMIENTO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDTIPODOCREF = IIf(.Item("IDTIPODOCREF") Is DBNull.Value, Nothing, .Item("IDTIPODOCREF"))
                lEntidad.NUMERODOCREF = IIf(.Item("NUMERODOCREF") Is DBNull.Value, Nothing, .Item("NUMERODOCREF"))
                lEntidad.IDALMACEN = IIf(.Item("IDALMACEN") Is DBNull.Value, Nothing, .Item("IDALMACEN"))
                lEntidad.ANIO = IIf(.Item("ANIO") Is DBNull.Value, Nothing, .Item("ANIO"))
                lEntidad.IDDOCUMENTO = IIf(.Item("IDDOCUMENTO") Is DBNull.Value, Nothing, .Item("IDDOCUMENTO"))
                lEntidad.IDESTADO = IIf(.Item("IDESTADO") Is DBNull.Value, Nothing, .Item("IDESTADO"))
                lEntidad.FECHAMOVIMIENTO = IIf(.Item("FECHAMOVIMIENTO") Is DBNull.Value, Nothing, .Item("FECHAMOVIMIENTO"))
                lEntidad.IDESTABLECIMIENTODESTINO = IIf(.Item("IDESTABLECIMIENTODESTINO") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTODESTINO"))
                lEntidad.IDALMACENDESTINO = IIf(.Item("IDALMACENDESTINO") Is DBNull.Value, Nothing, .Item("IDALMACENDESTINO"))
                lEntidad.IDUNIDADSOLICITA = IIf(.Item("IDUNIDADSOLICITA") Is DBNull.Value, Nothing, .Item("IDUNIDADSOLICITA"))
                lEntidad.TOTALMOVIMIENTO = IIf(.Item("TOTALMOVIMIENTO") Is DBNull.Value, Nothing, .Item("TOTALMOVIMIENTO"))
                lEntidad.IDEMPLEADOSOLICITA = IIf(.Item("IDEMPLEADOSOLICITA") Is DBNull.Value, Nothing, .Item("IDEMPLEADOSOLICITA"))
                lEntidad.IDEMPLEADOAUTORIZA = IIf(.Item("IDEMPLEADOAUTORIZA") Is DBNull.Value, Nothing, .Item("IDEMPLEADOAUTORIZA"))
                lEntidad.IDEMPLEADOALMACEN = IIf(.Item("IDEMPLEADOALMACEN") Is DBNull.Value, Nothing, .Item("IDEMPLEADOALMACEN"))
                lEntidad.EMPLEADOALMACEN = IIf(.Item("EMPLEADOALMACEN") Is DBNull.Value, Nothing, .Item("EMPLEADOALMACEN"))
                lEntidad.IDEMPLEADODESPACHA = IIf(.Item("IDEMPLEADODESPACHA") Is DBNull.Value, Nothing, .Item("IDEMPLEADODESPACHA"))
                lEntidad.IDEMPLEADORECIBE = IIf(.Item("IDEMPLEADORECIBE") Is DBNull.Value, Nothing, .Item("IDEMPLEADORECIBE"))
                lEntidad.IDEMPLEADOPREPARA = IIf(.Item("IDEMPLEADOPREPARA") Is DBNull.Value, Nothing, .Item("IDEMPLEADOPREPARA"))
                lEntidad.IDEMPLEADOENVIADO = IIf(.Item("IDEMPLEADOENVIADO") Is DBNull.Value, Nothing, .Item("IDEMPLEADOENVIADO"))
                lEntidad.CLASIFICACIONMOVIMIENTO = IIf(.Item("CLASIFICACIONMOVIMIENTO") Is DBNull.Value, Nothing, .Item("CLASIFICACIONMOVIMIENTO"))
                lEntidad.SUBCLASIFICACIONMOVIMIENTO = IIf(.Item("SUBCLASIFICACIONMOVIMIENTO") Is DBNull.Value, Nothing, .Item("SUBCLASIFICACIONMOVIMIENTO"))
                lEntidad.RESPONSABLEDISTRIBUCION = IIf(.Item("RESPONSABLEDISTRIBUCION") Is DBNull.Value, Nothing, .Item("RESPONSABLEDISTRIBUCION"))
                lEntidad.MOTIVO = IIf(.Item("MOTIVO") Is DBNull.Value, Nothing, .Item("MOTIVO"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.EMPLEADOPREPARA = IIf(.Item("EMPLEADOPREPARA") Is DBNull.Value, Nothing, .Item("EMPLEADOPREPARA"))
                lEntidad.ID_LUGAR_ENTREGA_HOSPITAL = IIf(.Item("ID_LUGAR_ENTREGA_HOSPITAL") Is DBNull.Value, Nothing, .Item("ID_LUGAR_ENTREGA_HOSPITAL"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As MOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDMOVIMIENTO),0) + 1 ")
        strSQL.Append(" FROM SAB_ALM_MOVIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOTRANSACCION

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32) As listaMOVIMIENTOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaMOVIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New MOVIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDTIPOTRANSACCION = IDTIPOTRANSACCION
                mEntidad.IDMOVIMIENTO = IIf(dr("IDMOVIMIENTO") Is DBNull.Value, Nothing, dr("IDMOVIMIENTO"))
                mEntidad.IDTIPODOCREF = IIf(dr("IDTIPODOCREF") Is DBNull.Value, Nothing, dr("IDTIPODOCREF"))
                mEntidad.NUMERODOCREF = IIf(dr("NUMERODOCREF") Is DBNull.Value, Nothing, dr("NUMERODOCREF"))
                mEntidad.IDALMACEN = IIf(dr("IDALMACEN") Is DBNull.Value, Nothing, dr("IDALMACEN"))
                mEntidad.ANIO = IIf(dr("ANIO") Is DBNull.Value, Nothing, dr("ANIO"))
                mEntidad.IDDOCUMENTO = IIf(dr("IDDOCUMENTO") Is DBNull.Value, Nothing, dr("IDDOCUMENTO"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.FECHAMOVIMIENTO = IIf(dr("FECHAMOVIMIENTO") Is DBNull.Value, Nothing, dr("FECHAMOVIMIENTO"))
                mEntidad.IDESTABLECIMIENTODESTINO = IIf(dr("IDESTABLECIMIENTODESTINO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTODESTINO"))
                mEntidad.IDALMACENDESTINO = IIf(dr("IDALMACENDESTINO") Is DBNull.Value, Nothing, dr("IDALMACENDESTINO"))
                mEntidad.IDUNIDADSOLICITA = IIf(dr("IDUNIDADSOLICITA") Is DBNull.Value, Nothing, dr("IDUNIDADSOLICITA"))
                mEntidad.TOTALMOVIMIENTO = IIf(dr("TOTALMOVIMIENTO") Is DBNull.Value, Nothing, dr("TOTALMOVIMIENTO"))
                mEntidad.IDEMPLEADOSOLICITA = IIf(dr("IDEMPLEADOSOLICITA") Is DBNull.Value, Nothing, dr("IDEMPLEADOSOLICITA"))
                mEntidad.IDEMPLEADOAUTORIZA = IIf(dr("IDEMPLEADOAUTORIZA") Is DBNull.Value, Nothing, dr("IDEMPLEADOAUTORIZA"))
                mEntidad.IDEMPLEADOALMACEN = IIf(dr("IDEMPLEADOALMACEN") Is DBNull.Value, Nothing, dr("IDEMPLEADOALMACEN"))
                mEntidad.EMPLEADOALMACEN = IIf(dr("EMPLEADOALMACEN") Is DBNull.Value, Nothing, dr("EMPLEADOALMACEN"))
                mEntidad.IDEMPLEADODESPACHA = IIf(dr("IDEMPLEADODESPACHA") Is DBNull.Value, Nothing, dr("IDEMPLEADODESPACHA"))
                mEntidad.IDEMPLEADORECIBE = IIf(dr("IDEMPLEADORECIBE") Is DBNull.Value, Nothing, dr("IDEMPLEADORECIBE"))
                mEntidad.IDEMPLEADOPREPARA = IIf(dr("IDEMPLEADOPREPARA") Is DBNull.Value, Nothing, dr("IDEMPLEADOPREPARA"))
                mEntidad.IDEMPLEADOENVIADO = IIf(dr("IDEMPLEADOENVIADO") Is DBNull.Value, Nothing, dr("IDEMPLEADOENVIADO"))
                mEntidad.CLASIFICACIONMOVIMIENTO = IIf(dr("CLASIFICACIONMOVIMIENTO") Is DBNull.Value, Nothing, dr("CLASIFICACIONMOVIMIENTO"))
                mEntidad.SUBCLASIFICACIONMOVIMIENTO = IIf(dr("SUBCLASIFICACIONMOVIMIENTO") Is DBNull.Value, Nothing, dr("SUBCLASIFICACIONMOVIMIENTO"))
                mEntidad.RESPONSABLEDISTRIBUCION = IIf(dr("RESPONSABLEDISTRIBUCION") Is DBNull.Value, Nothing, dr("RESPONSABLEDISTRIBUCION"))
                mEntidad.MOTIVO = IIf(dr("MOTIVO") Is DBNull.Value, Nothing, dr("MOTIVO"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.EMPLEADOPREPARA = IIf(dr("EMPLEADOPREPARA") Is DBNull.Value, Nothing, dr("EMPLEADOPREPARA"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(1).Value = IDTIPOTRANSACCION

        Dim tables(0) As String
        tables(0) = New String("MOVIMIENTOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDTIPOTRANSACCION, ")
        strSQL.Append(" IDMOVIMIENTO, ")
        strSQL.Append(" IDTIPODOCREF, ")
        strSQL.Append(" NUMERODOCREF, ")
        strSQL.Append(" IDALMACEN, ")
        strSQL.Append(" ANIO, ")
        strSQL.Append(" IDDOCUMENTO, ")
        strSQL.Append(" IDESTADO, ")
        strSQL.Append(" FECHAMOVIMIENTO, ")
        strSQL.Append(" IDESTABLECIMIENTODESTINO, ")
        strSQL.Append(" IDALMACENDESTINO, ")
        strSQL.Append(" IDUNIDADSOLICITA, ")
        strSQL.Append(" TOTALMOVIMIENTO, ")
        strSQL.Append(" IDEMPLEADOSOLICITA, ")
        strSQL.Append(" IDEMPLEADOAUTORIZA, ")
        strSQL.Append(" IDEMPLEADOALMACEN, ")
        strSQL.Append(" EMPLEADOALMACEN, ")
        strSQL.Append(" IDEMPLEADODESPACHA, ")
        strSQL.Append(" IDEMPLEADORECIBE, ")
        strSQL.Append(" IDEMPLEADOPREPARA, ")
        strSQL.Append(" IDEMPLEADOENVIADO, ")
        strSQL.Append(" CLASIFICACIONMOVIMIENTO, ")
        strSQL.Append(" SUBCLASIFICACIONMOVIMIENTO, ")
        strSQL.Append(" RESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" MOTIVO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" EMPLEADOPREPARA, ")
        strSQL.Append(" ID_LUGAR_ENTREGA_HOSPITAL ")
        strSQL.Append(" FROM SAB_ALM_MOVIMIENTOS ")

    End Sub

#End Region

End Class
