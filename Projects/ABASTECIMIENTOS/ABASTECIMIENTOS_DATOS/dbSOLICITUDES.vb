Imports System.Text

Public Class dbSOLICITUDES
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SOLICITUDES
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDSOLICITUD = 0 _
            Or lEntidad.IDSOLICITUD = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDSOLICITUD = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_EST_SOLICITUDES ")
        strSQL.Append(" SET CORRELATIVO = @CORRELATIVO, ")
        strSQL.Append(" FECHASOLICITUD = @FECHASOLICITUD, ")
        strSQL.Append(" PLAZOENTREGA = @PLAZOENTREGA, ")
        strSQL.Append(" IDCLASESUMINISTRO = @IDCLASESUMINISTRO, ")
        strSQL.Append(" PERIODOUTILIZACION = @PERIODOUTILIZACION, ")
        strSQL.Append(" MONTOSOLICITADO = @MONTOSOLICITADO, ")
        strSQL.Append(" MONTODISPONIBLE = @MONTODISPONIBLE, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" IDSOLICITANTE = @IDSOLICITANTE, ")
        strSQL.Append(" IDAREATECNICA = @IDAREATECNICA, ")
        strSQL.Append(" CIFRADOPRESUPUESTARIO = @CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" RESERVAFONDO = @RESERVAFONDO, ")
        strSQL.Append(" FECHAAUTORIZACION = @FECHAAUTORIZACION, ")
        strSQL.Append(" MONTOAUTORIZADO = @MONTOAUTORIZADO, ")
        strSQL.Append(" CODRESERVAFONDO = @CODRESERVAFONDO, ")
        strSQL.Append(" IDCERTIFICA = @IDCERTIFICA, ")
        strSQL.Append(" IDAUTORIZA = @IDAUTORIZA, ")
        ' strSQL.Append(" IDESTADO = @IDESTADO, ")
        strSQL.Append(" IDDEPENDENCIASOLICITANTE = @IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" IDTIPOCOMPRASOLICITADO = @IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" IDTIPOCOMPRASUGERIDO = @IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" IDTIPOCOMPRAEJECUTAR = @IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" IDALMACENENTREGA = @IDALMACENENTREGA, ")
        strSQL.Append(" COMPRACONJUNTA = @COMPRACONJUNTA, ")
        strSQL.Append(" NUMCORR = @NUMCORR, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA, ")
        strSQL.Append(" EMPLEADOSOLICITANTE = @EMPLEADOSOLICITANTE, ")
        strSQL.Append(" EMPLEADOAREATECNICA = @EMPLEADOAREATECNICA, ")
        strSQL.Append(" EMPLEADOAUTORIZA = @EMPLEADOAUTORIZA, ")
        strSQL.Append(" IDESTABLECIMIENTOENTREGA = @IDESTABLECIMIENTOENTREGA, ")
        strSQL.Append(" CARGOSOLICITANTE = @CARGOSOLICITANTE, ")
        strSQL.Append(" ENTREGAS = @ENTREGAS ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(37) As SqlParameter
        args(0) = New SqlParameter("@CORRELATIVO", SqlDbType.VarChar)
        args(0).Value = IIf(lEntidad.CORRELATIVO = Nothing, DBNull.Value, lEntidad.CORRELATIVO)
        args(1) = New SqlParameter("@FECHASOLICITUD", SqlDbType.DateTime)
        args(1).Value = IIf(lEntidad.FECHASOLICITUD = Nothing, DBNull.Value, lEntidad.FECHASOLICITUD)
        args(2) = New SqlParameter("@PLAZOENTREGA", SqlDbType.Int)
        args(2).Value = lEntidad.PLAZOENTREGA
        args(3) = New SqlParameter("@IDCLASESUMINISTRO", SqlDbType.Int)
        args(3).Value = lEntidad.IDCLASESUMINISTRO
        args(4) = New SqlParameter("@PERIODOUTILIZACION", SqlDbType.SmallInt)
        args(4).Value = lEntidad.PERIODOUTILIZACION
        args(5) = New SqlParameter("@MONTOSOLICITADO", SqlDbType.Decimal)
        args(5).Value = lEntidad.MONTOSOLICITADO
        args(6) = New SqlParameter("@MONTODISPONIBLE", SqlDbType.Decimal)
        args(6).Value = lEntidad.MONTODISPONIBLE
        args(7) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(8) = New SqlParameter("@IDSOLICITANTE", SqlDbType.Int)
        args(8).Value = IIf(lEntidad.IDSOLICITANTE = Nothing, DBNull.Value, lEntidad.IDSOLICITANTE)
        args(9) = New SqlParameter("@IDAREATECNICA", SqlDbType.Int)
        args(9).Value = IIf(lEntidad.IDAREATECNICA = Nothing, DBNull.Value, lEntidad.IDAREATECNICA)
        args(10) = New SqlParameter("@CIFRADOPRESUPUESTARIO", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.CIFRADOPRESUPUESTARIO = Nothing, DBNull.Value, lEntidad.CIFRADOPRESUPUESTARIO)
        args(11) = New SqlParameter("@RESERVAFONDO", SqlDbType.Decimal)
        args(11).Value = lEntidad.RESERVAFONDO
        args(12) = New SqlParameter("@FECHAAUTORIZACION", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.FECHAAUTORIZACION = Nothing, DBNull.Value, lEntidad.FECHAAUTORIZACION)
        args(13) = New SqlParameter("@MONTOAUTORIZADO", SqlDbType.Decimal)
        args(13).Value = lEntidad.MONTOAUTORIZADO
        args(14) = New SqlParameter("@CODRESERVAFONDO", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.CODRESERVAFONDO = Nothing, DBNull.Value, lEntidad.CODRESERVAFONDO)
        args(15) = New SqlParameter("@IDCERTIFICA", SqlDbType.Int)
        args(15).Value = lEntidad.IDCERTIFICA
        args(16) = New SqlParameter("@IDAUTORIZA", SqlDbType.Int)
        args(16).Value = lEntidad.IDAUTORIZA
        'args(17) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        'args(17).Value = lEntidad.IDESTADO
        args(18) = New SqlParameter("@IDDEPENDENCIASOLICITANTE", SqlDbType.Int)
        args(18).Value = IIf(lEntidad.IDDEPENDENCIASOLICITANTE = Nothing, DBNull.Value, lEntidad.IDDEPENDENCIASOLICITANTE)
        args(19) = New SqlParameter("@IDTIPOCOMPRASOLICITADO", SqlDbType.Int)
        args(19).Value = lEntidad.IDTIPOCOMPRASOLICITADO
        args(20) = New SqlParameter("@IDTIPOCOMPRASUGERIDO", SqlDbType.Int)
        args(20).Value = lEntidad.IDTIPOCOMPRASUGERIDO
        args(21) = New SqlParameter("@IDTIPOCOMPRAEJECUTAR", SqlDbType.Int)
        args(21).Value = lEntidad.IDTIPOCOMPRAEJECUTAR
        args(22) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(22).Value = IIf(lEntidad.IDALMACENENTREGA = Nothing, DBNull.Value, lEntidad.IDALMACENENTREGA)
        args(23) = New SqlParameter("@COMPRACONJUNTA", SqlDbType.TinyInt)
        args(23).Value = lEntidad.COMPRACONJUNTA
        args(24) = New SqlParameter("@NUMCORR", SqlDbType.Int)
        args(24).Value = lEntidad.NUMCORR
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
        args(30) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(30).Value = lEntidad.IDESTABLECIMIENTO
        args(31) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(31).Value = lEntidad.IDSOLICITUD
        args(32) = New SqlParameter("@EMPLEADOSOLICITANTE", SqlDbType.VarChar)
        args(32).Value = lEntidad.EMPLEADOSOLICITANTE
        args(33) = New SqlParameter("@EMPLEADOAREATECNICA", SqlDbType.VarChar)
        args(33).Value = lEntidad.EMPLEADOAREATECNICA
        args(34) = New SqlParameter("@EMPLEADOAUTORIZA", SqlDbType.VarChar)
        args(34).Value = lEntidad.EMPLEADOAUTORIZA
        args(35) = New SqlParameter("@IDESTABLECIMIENTOENTREGA", SqlDbType.BigInt)
        args(35).Value = IIf(lEntidad.IDESTABLECIMIENTOENTREGA = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTOENTREGA)
        args(36) = New SqlParameter("@CARGOSOLICITANTE", SqlDbType.VarChar)
        args(36).Value = lEntidad.CARGOSOLICITANTE
        args(37) = New SqlParameter("@ENTREGAS", SqlDbType.Int)
        args(37).Value = lEntidad.ENTREGAS

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SOLICITUDES
        lEntidad = aEntidad
        'recuperando correlativo general, hecho por mi: Mayra
        Dim strSQL1 As New StringBuilder
        strSQL1.Append("select COUNT (CorrelativoGeneral) +1 from SAB_EST_SOLICITUDES where YEAR (FECHASOLICITUD) = year(GETDATE())")
        Dim correlativogeneral As Integer = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL1.ToString())
        'fin de recuperacion
        
        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_SOLICITUDES ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" FECHASOLICITUD, ")
        strSQL.Append(" PLAZOENTREGA, ")
        strSQL.Append(" IDCLASESUMINISTRO, ")
        strSQL.Append(" PERIODOUTILIZACION, ")
        strSQL.Append(" MONTOSOLICITADO, ")
        strSQL.Append(" MONTODISPONIBLE, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" IDSOLICITANTE, ")
        strSQL.Append(" IDAREATECNICA, ")
        strSQL.Append(" CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" RESERVAFONDO, ")
        strSQL.Append(" FECHAAUTORIZACION, ")
        strSQL.Append(" MONTOAUTORIZADO, ")
        strSQL.Append(" CODRESERVAFONDO, ")
        strSQL.Append(" IDCERTIFICA, ")
        strSQL.Append(" IDAUTORIZA, ")
        strSQL.Append(" IDESTADO, ")
        strSQL.Append(" IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" COMPRACONJUNTA, ")
        strSQL.Append(" NUMCORR, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" EMPLEADOSOLICITANTE, ")
        strSQL.Append(" EMPLEADOAREATECNICA, ")
        strSQL.Append(" EMPLEADOAUTORIZA, ")
        strSQL.Append(" IDESTABLECIMIENTOENTREGA, IDSOLICITUDEPENDENCIA,ENTREGAS,IDUNIDADTECNICA,GRUPOUACI, ")
        strSQL.Append(" PORDEMANDA, ENTREGAUNIFORME,CORRELATIVOGENERAL) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDSOLICITUD, ")
        strSQL.Append(" @CORRELATIVO, ")
        strSQL.Append(" @FECHASOLICITUD, ")
        strSQL.Append(" @PLAZOENTREGA, ")
        strSQL.Append(" @IDCLASESUMINISTRO, ")
        strSQL.Append(" @PERIODOUTILIZACION, ")
        strSQL.Append(" @MONTOSOLICITADO, ")
        strSQL.Append(" @MONTODISPONIBLE, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @IDSOLICITANTE, ")
        strSQL.Append(" @IDAREATECNICA, ")
        strSQL.Append(" @CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" @RESERVAFONDO, ")
        strSQL.Append(" @FECHAAUTORIZACION, ")
        strSQL.Append(" @MONTOAUTORIZADO, ")
        strSQL.Append(" @CODRESERVAFONDO, ")
        strSQL.Append(" @IDCERTIFICA, ")
        strSQL.Append(" @IDAUTORIZA, ")
        strSQL.Append(" @IDESTADO, ")
        strSQL.Append(" @IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" @IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" @IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" @IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" @IDALMACENENTREGA, ")
        strSQL.Append(" @COMPRACONJUNTA, ")
        strSQL.Append(" @NUMCORR, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA, ")
        strSQL.Append(" @EMPLEADOSOLICITANTE, ")
        strSQL.Append(" @EMPLEADOAREATECNICA, ")
        strSQL.Append(" @EMPLEADOAUTORIZA, ")
        strSQL.Append(" @IDESTABLECIMIENTOENTREGA,@IDSOLICITUDEPENDENCIA,@ENTREGAS,@IDUNIDADTECNICA,@GRUPOUACI, ")
        strSQL.Append(" 0,1,")
        strSQL.Append(correlativogeneral.ToString())
        strSQL.Append(")")

        Dim args(39) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@CORRELATIVO", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.CORRELATIVO = Nothing, DBNull.Value, lEntidad.CORRELATIVO)
        args(3) = New SqlParameter("@FECHASOLICITUD", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.FECHASOLICITUD = Nothing, DBNull.Value, lEntidad.FECHASOLICITUD)
        args(4) = New SqlParameter("@PLAZOENTREGA", SqlDbType.Int)
        args(4).Value = lEntidad.PLAZOENTREGA
        args(5) = New SqlParameter("@IDCLASESUMINISTRO", SqlDbType.Int)
        args(5).Value = lEntidad.IDCLASESUMINISTRO
        args(6) = New SqlParameter("@PERIODOUTILIZACION", SqlDbType.SmallInt)
        args(6).Value = lEntidad.PERIODOUTILIZACION
        args(7) = New SqlParameter("@MONTOSOLICITADO", SqlDbType.Decimal)
        args(7).Value = lEntidad.MONTOSOLICITADO
        args(8) = New SqlParameter("@MONTODISPONIBLE", SqlDbType.Decimal)
        args(8).Value = lEntidad.MONTODISPONIBLE
        args(9) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(10) = New SqlParameter("@IDSOLICITANTE", SqlDbType.Int)
        args(10).Value = IIf(lEntidad.IDSOLICITANTE = Nothing, DBNull.Value, lEntidad.IDSOLICITANTE)
        args(11) = New SqlParameter("@IDAREATECNICA", SqlDbType.Int)
        args(11).Value = IIf(lEntidad.IDAREATECNICA = Nothing, DBNull.Value, lEntidad.IDAREATECNICA)
        args(12) = New SqlParameter("@CIFRADOPRESUPUESTARIO", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.CIFRADOPRESUPUESTARIO = Nothing, DBNull.Value, lEntidad.CIFRADOPRESUPUESTARIO)
        args(13) = New SqlParameter("@RESERVAFONDO", SqlDbType.Decimal)
        args(13).Value = lEntidad.RESERVAFONDO
        args(14) = New SqlParameter("@FECHAAUTORIZACION", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.FECHAAUTORIZACION = Nothing, DBNull.Value, lEntidad.FECHAAUTORIZACION)
        args(15) = New SqlParameter("@MONTOAUTORIZADO", SqlDbType.Decimal)
        args(15).Value = lEntidad.MONTOAUTORIZADO
        args(16) = New SqlParameter("@CODRESERVAFONDO", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.CODRESERVAFONDO = Nothing, DBNull.Value, lEntidad.CODRESERVAFONDO)
        args(17) = New SqlParameter("@IDCERTIFICA", SqlDbType.Int)
        args(17).Value = IIf(lEntidad.IDCERTIFICA = Nothing, DBNull.Value, lEntidad.IDCERTIFICA)
        args(18) = New SqlParameter("@IDAUTORIZA", SqlDbType.Int)
        args(18).Value = IIf(lEntidad.IDAUTORIZA = Nothing, DBNull.Value, lEntidad.IDAUTORIZA)
        args(19) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(19).Value = lEntidad.IDESTADO
        args(20) = New SqlParameter("@IDDEPENDENCIASOLICITANTE", SqlDbType.Int)
        args(20).Value = lEntidad.IDDEPENDENCIASOLICITANTE
        args(21) = New SqlParameter("@IDTIPOCOMPRASOLICITADO", SqlDbType.Int)
        args(21).Value = lEntidad.IDTIPOCOMPRASOLICITADO
        args(22) = New SqlParameter("@IDTIPOCOMPRASUGERIDO", SqlDbType.Int)
        args(22).Value = lEntidad.IDTIPOCOMPRASUGERIDO
        args(23) = New SqlParameter("@IDTIPOCOMPRAEJECUTAR", SqlDbType.Int)
        args(23).Value = lEntidad.IDTIPOCOMPRAEJECUTAR
        args(24) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(24).Value = IIf(lEntidad.IDALMACENENTREGA = Nothing, DBNull.Value, lEntidad.IDALMACENENTREGA)
        args(25) = New SqlParameter("@COMPRACONJUNTA", SqlDbType.TinyInt)
        args(25).Value = lEntidad.COMPRACONJUNTA
        args(26) = New SqlParameter("@NUMCORR", SqlDbType.Int)
        args(26).Value = IIf(lEntidad.NUMCORR = Nothing, DBNull.Value, lEntidad.NUMCORR)
        args(27) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(27).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(28) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(28).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(29) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(29).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(30) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(30).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(31) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(31).Value = lEntidad.ESTASINCRONIZADA
        args(32) = New SqlParameter("@EMPLEADOSOLICITANTE", SqlDbType.VarChar)
        args(32).Value = lEntidad.EMPLEADOSOLICITANTE
        args(33) = New SqlParameter("@EMPLEADOAREATECNICA", SqlDbType.VarChar)
        args(33).Value = lEntidad.EMPLEADOAREATECNICA
        args(34) = New SqlParameter("@EMPLEADOAUTORIZA", SqlDbType.VarChar)
        args(34).Value = lEntidad.EMPLEADOAUTORIZA
        args(35) = New SqlParameter("@IDESTABLECIMIENTOENTREGA", SqlDbType.BigInt)
        args(35).Value = IIf(lEntidad.IDESTABLECIMIENTOENTREGA = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTOENTREGA)
        args(36) = New SqlParameter("@IDSOLICITUDEPENDENCIA", SqlDbType.BigInt)
        args(36).Value = IIf(lEntidad.IDSOLICITUDEPENDENCIA = Nothing, DBNull.Value, lEntidad.IDSOLICITUDEPENDENCIA)
        args(37) = New SqlParameter("@ENTREGAS", SqlDbType.TinyInt)
        args(37).Value = IIf(lEntidad.ENTREGAS = Nothing, DBNull.Value, lEntidad.ENTREGAS)
        args(38) = New SqlParameter("@IDUNIDADTECNICA", SqlDbType.TinyInt)
        args(38).Value = IIf(lEntidad.IDUNIDADTECNICA = Nothing, DBNull.Value, lEntidad.IDUNIDADTECNICA)
        args(39) = New SqlParameter("@GRUPOUACI", SqlDbType.TinyInt)
        args(39).Value = IIf(lEntidad.GRUPOUACI = Nothing, DBNull.Value, lEntidad.GRUPOUACI)
        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As SOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.CORRELATIVO = IIf(.Item("CORRELATIVO") Is DBNull.Value, Nothing, .Item("CORRELATIVO"))
                lEntidad.FECHASOLICITUD = IIf(.Item("FECHASOLICITUD") Is DBNull.Value, Nothing, .Item("FECHASOLICITUD"))
                lEntidad.PLAZOENTREGA = IIf(.Item("PLAZOENTREGA") Is DBNull.Value, Nothing, .Item("PLAZOENTREGA"))
                lEntidad.IDCLASESUMINISTRO = IIf(.Item("IDCLASESUMINISTRO") Is DBNull.Value, Nothing, .Item("IDCLASESUMINISTRO"))
                lEntidad.PERIODOUTILIZACION = IIf(.Item("PERIODOUTILIZACION") Is DBNull.Value, Nothing, .Item("PERIODOUTILIZACION"))
                lEntidad.MONTOSOLICITADO = IIf(.Item("MONTOSOLICITADO") Is DBNull.Value, Nothing, .Item("MONTOSOLICITADO"))
                lEntidad.MONTODISPONIBLE = IIf(.Item("MONTODISPONIBLE") Is DBNull.Value, Nothing, .Item("MONTODISPONIBLE"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
                lEntidad.IDSOLICITANTE = IIf(.Item("IDSOLICITANTE") Is DBNull.Value, Nothing, .Item("IDSOLICITANTE"))
                lEntidad.IDAREATECNICA = IIf(.Item("IDAREATECNICA") Is DBNull.Value, Nothing, .Item("IDAREATECNICA"))
                lEntidad.CIFRADOPRESUPUESTARIO = IIf(.Item("CIFRADOPRESUPUESTARIO") Is DBNull.Value, Nothing, .Item("CIFRADOPRESUPUESTARIO"))
                lEntidad.RESERVAFONDO = IIf(.Item("RESERVAFONDO") Is DBNull.Value, Nothing, .Item("RESERVAFONDO"))
                lEntidad.FECHAAUTORIZACION = IIf(.Item("FECHAAUTORIZACION") Is DBNull.Value, Nothing, .Item("FECHAAUTORIZACION"))
                lEntidad.MONTOAUTORIZADO = IIf(.Item("MONTOAUTORIZADO") Is DBNull.Value, Nothing, .Item("MONTOAUTORIZADO"))
                lEntidad.CODRESERVAFONDO = IIf(.Item("CODRESERVAFONDO") Is DBNull.Value, Nothing, .Item("CODRESERVAFONDO"))
                lEntidad.IDCERTIFICA = IIf(.Item("IDCERTIFICA") Is DBNull.Value, Nothing, .Item("IDCERTIFICA"))
                lEntidad.IDAUTORIZA = IIf(.Item("IDAUTORIZA") Is DBNull.Value, Nothing, .Item("IDAUTORIZA"))
                lEntidad.IDESTADO = IIf(.Item("IDESTADO") Is DBNull.Value, Nothing, .Item("IDESTADO"))
                lEntidad.IDDEPENDENCIASOLICITANTE = IIf(.Item("IDDEPENDENCIASOLICITANTE") Is DBNull.Value, Nothing, .Item("IDDEPENDENCIASOLICITANTE"))
                lEntidad.IDTIPOCOMPRASOLICITADO = IIf(.Item("IDTIPOCOMPRASOLICITADO") Is DBNull.Value, Nothing, .Item("IDTIPOCOMPRASOLICITADO"))
                lEntidad.IDTIPOCOMPRASUGERIDO = IIf(.Item("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, .Item("IDTIPOCOMPRASUGERIDO"))
                lEntidad.IDTIPOCOMPRAEJECUTAR = IIf(.Item("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, .Item("IDTIPOCOMPRAEJECUTAR"))
                lEntidad.IDALMACENENTREGA = IIf(.Item("IDALMACENENTREGA") Is DBNull.Value, Nothing, .Item("IDALMACENENTREGA"))
                lEntidad.COMPRACONJUNTA = IIf(.Item("COMPRACONJUNTA") Is DBNull.Value, Nothing, .Item("COMPRACONJUNTA"))
                lEntidad.NUMCORR = IIf(.Item("NUMCORR") Is DBNull.Value, Nothing, .Item("NUMCORR"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.EMPLEADOSOLICITANTE = IIf(.Item("EMPLEADOSOLICITANTE") Is DBNull.Value, Nothing, .Item("EMPLEADOSOLICITANTE"))
                lEntidad.EMPLEADOAREATECNICA = IIf(.Item("EMPLEADOAREATECNICA") Is DBNull.Value, Nothing, .Item("EMPLEADOAREATECNICA"))
                lEntidad.EMPLEADOAUTORIZA = IIf(.Item("EMPLEADOAUTORIZA") Is DBNull.Value, Nothing, .Item("EMPLEADOAUTORIZA"))
                lEntidad.IDESTABLECIMIENTOENTREGA = IIf(.Item("IDESTABLECIMIENTOENTREGA") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTOENTREGA"))
                lEntidad.ENTREGAS = IIf(.Item("ENTREGAS") Is DBNull.Value, Nothing, .Item("ENTREGAS"))
                lEntidad.CARGOSOLICITANTE = IIf(.Item("CARGOSOLICITANTE") Is DBNull.Value, Nothing, .Item("CARGOSOLICITANTE"))
                lEntidad.IDUNIDADTECNICA = IIf(.Item("IDUNIDADTECNICA") Is DBNull.Value, Nothing, .Item("IDUNIDADTECNICA"))
                lEntidad.GRUPOUACI = IIf(.Item("GRUPOUACI") Is DBNull.Value, Nothing, .Item("GRUPOUACI"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As SOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDSOLICITUD),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32) As listaSOLICITUDES

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaSOLICITUDES

        Try
            Do While dr.Read()
                Dim mEntidad As New SOLICITUDES
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDSOLICITUD = IIf(dr("IDSOLICITUD") Is DBNull.Value, Nothing, dr("IDSOLICITUD"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.FECHASOLICITUD = IIf(dr("FECHASOLICITUD") Is DBNull.Value, Nothing, dr("FECHASOLICITUD"))
                mEntidad.PLAZOENTREGA = IIf(dr("PLAZOENTREGA") Is DBNull.Value, Nothing, dr("PLAZOENTREGA"))
                mEntidad.IDCLASESUMINISTRO = IIf(dr("IDCLASESUMINISTRO") Is DBNull.Value, Nothing, dr("IDCLASESUMINISTRO"))
                mEntidad.PERIODOUTILIZACION = IIf(dr("PERIODOUTILIZACION") Is DBNull.Value, Nothing, dr("PERIODOUTILIZACION"))
                mEntidad.MONTOSOLICITADO = IIf(dr("MONTOSOLICITADO") Is DBNull.Value, Nothing, dr("MONTOSOLICITADO"))
                mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.IDSOLICITANTE = IIf(dr("IDSOLICITANTE") Is DBNull.Value, Nothing, dr("IDSOLICITANTE"))
                mEntidad.IDAREATECNICA = IIf(dr("IDAREATECNICA") Is DBNull.Value, Nothing, dr("IDAREATECNICA"))
                mEntidad.CIFRADOPRESUPUESTARIO = IIf(dr("CIFRADOPRESUPUESTARIO") Is DBNull.Value, Nothing, dr("CIFRADOPRESUPUESTARIO"))
                mEntidad.RESERVAFONDO = IIf(dr("RESERVAFONDO") Is DBNull.Value, Nothing, dr("RESERVAFONDO"))
                mEntidad.FECHAAUTORIZACION = IIf(dr("FECHAAUTORIZACION") Is DBNull.Value, Nothing, dr("FECHAAUTORIZACION"))
                mEntidad.MONTOAUTORIZADO = IIf(dr("MONTOAUTORIZADO") Is DBNull.Value, Nothing, dr("MONTOAUTORIZADO"))
                mEntidad.CODRESERVAFONDO = IIf(dr("CODRESERVAFONDO") Is DBNull.Value, Nothing, dr("CODRESERVAFONDO"))
                mEntidad.IDCERTIFICA = IIf(dr("IDCERTIFICA") Is DBNull.Value, Nothing, dr("IDCERTIFICA"))
                mEntidad.IDAUTORIZA = IIf(dr("IDAUTORIZA") Is DBNull.Value, Nothing, dr("IDAUTORIZA"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.IDDEPENDENCIASOLICITANTE = IIf(dr("IDDEPENDENCIASOLICITANTE") Is DBNull.Value, Nothing, dr("IDDEPENDENCIASOLICITANTE"))
                mEntidad.IDTIPOCOMPRASOLICITADO = IIf(dr("IDTIPOCOMPRASOLICITADO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASOLICITADO"))
                mEntidad.IDTIPOCOMPRASUGERIDO = IIf(dr("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASUGERIDO"))
                mEntidad.IDTIPOCOMPRAEJECUTAR = IIf(dr("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRAEJECUTAR"))
                mEntidad.IDALMACENENTREGA = IIf(dr("IDALMACENENTREGA") Is DBNull.Value, Nothing, dr("IDALMACENENTREGA"))
                mEntidad.COMPRACONJUNTA = IIf(dr("COMPRACONJUNTA") Is DBNull.Value, Nothing, dr("COMPRACONJUNTA"))
                mEntidad.NUMCORR = IIf(dr("NUMCORR") Is DBNull.Value, Nothing, dr("NUMCORR"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.EMPLEADOSOLICITANTE = IIf(dr("EMPLEADOSOLICITANTE") Is DBNull.Value, Nothing, dr("EMPLEADOSOLICITANTE"))
                mEntidad.EMPLEADOAREATECNICA = IIf(dr("EMPLEADOAREATECNICA") Is DBNull.Value, Nothing, dr("EMPLEADOAREATECNICA"))
                mEntidad.EMPLEADOAUTORIZA = IIf(dr("EMPLEADOAUTORIZA") Is DBNull.Value, Nothing, dr("EMPLEADOAUTORIZA"))
                mEntidad.IDESTABLECIMIENTOENTREGA = IIf(dr("IDESTABLECIMIENTOENTREGA") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTOENTREGA"))
                mEntidad.GRUPOUACI = IIf(dr("GRUPOUACI") Is DBNull.Value, Nothing, dr("GRUPOUACI"))
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
        tables(0) = New String("SOLICITUDES")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" FECHASOLICITUD, ")
        strSQL.Append(" PLAZOENTREGA, ")
        strSQL.Append(" IDCLASESUMINISTRO, ")
        strSQL.Append(" PERIODOUTILIZACION, ")
        strSQL.Append(" MONTOSOLICITADO, ")
        strSQL.Append(" MONTODISPONIBLE, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" IDSOLICITANTE, ")
        strSQL.Append(" IDAREATECNICA, ")
        strSQL.Append(" CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" RESERVAFONDO, ")
        strSQL.Append(" FECHAAUTORIZACION, ")
        strSQL.Append(" MONTOAUTORIZADO, ")
        strSQL.Append(" CODRESERVAFONDO, ")
        strSQL.Append(" IDCERTIFICA, ")
        strSQL.Append(" IDAUTORIZA, ")
        strSQL.Append(" IDESTADO, ")
        strSQL.Append(" IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" COMPRACONJUNTA, ")
        strSQL.Append(" NUMCORR, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" EMPLEADOSOLICITANTE, ")
        strSQL.Append(" EMPLEADOAREATECNICA, ")
        strSQL.Append(" EMPLEADOAUTORIZA, ")
        strSQL.Append(" IDESTABLECIMIENTOENTREGA, ")
        strSQL.Append(" ENTREGAS, ")
        strSQL.Append(" CARGOSOLICITANTE, ")
        strSQL.Append(" IDUNIDADTECNICA, ")
        strSQL.Append(" GRUPOUACI ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")

    End Sub

#End Region

End Class
