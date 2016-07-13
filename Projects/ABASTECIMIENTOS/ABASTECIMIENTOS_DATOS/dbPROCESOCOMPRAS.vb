Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbPROCESOCOMPRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_PROCESOCOMPRAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/06/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbPROCESOCOMPRAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROCESOCOMPRAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDPROCESOCOMPRA = 0 _
            Or lEntidad.IDPROCESOCOMPRA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDPROCESOCOMPRA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" SET IDTITULAR = @IDTITULAR, ")
        strSQL.Append(" IDENTIDADSOLICITA = @IDENTIDADSOLICITA, ")
        strSQL.Append(" FECHAENVIONOTA = @FECHAENVIONOTA, ")
        strSQL.Append(" COSTOBASE = @COSTOBASE, ")
        strSQL.Append(" LUGARAPERTURABASE = @LUGARAPERTURABASE, ")
        strSQL.Append(" DIRECCIONAPERTURABASE = @DIRECCIONAPERTURABASE, ")
        strSQL.Append(" IDMUNICIPIOAPERTURA = @IDMUNICIPIOAPERTURA, ")
        strSQL.Append(" FECHAHORAINICIOAPERTURA = @FECHAHORAINICIOAPERTURA, ")
        strSQL.Append(" FECHAHORAFINAPERTURA = @FECHAHORAFINAPERTURA, ")
        strSQL.Append(" FECHAREALIZADAAPERTURA = @FECHAREALIZADAAPERTURA, ")
        strSQL.Append(" FECHAPUBLICACION = @FECHAPUBLICACION, ")
        strSQL.Append(" LUGARRETIROBASE = @LUGARRETIROBASE, ")
        strSQL.Append(" FECHAHORAINICIORETIRO = @FECHAHORAINICIORETIRO, ")
        strSQL.Append(" FECHAHORAFINRETIRO = @FECHAHORAFINRETIRO, ")
        strSQL.Append(" LUGARRECEPCIONOFERTA = @LUGARRECEPCIONOFERTA, ")
        strSQL.Append(" DIRECCIONRECEPCIONOFERTA = @DIRECCIONRECEPCIONOFERTA, ")
        strSQL.Append(" IDMUNICIPIORECEPCION = @IDMUNICIPIORECEPCION, ")
        strSQL.Append(" FECHAHORAINICIORECEPCION = @FECHAHORAINICIORECEPCION, ")
        strSQL.Append(" FECHAHORAFINRECEPCION = @FECHAHORAFINRECEPCION, ")
        strSQL.Append(" CODIGOLICITACION = @CODIGOLICITACION, ")
        strSQL.Append(" TITULOLICITACION = @TITULOLICITACION, ")
        strSQL.Append(" DESCRIPCIONLICITACION = @DESCRIPCIONLICITACION, ")
        strSQL.Append(" IDTIPOCOMPRASUGERIDO = @IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" IDTIPOCOMPRAEJECUTAR = @IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" IDESTADOPROCESOCOMPRA = @IDESTADOPROCESOCOMPRA, ")
        strSQL.Append(" IDENCARGADO = @IDENCARGADO, ")
        strSQL.Append(" IDJEFEUACI = @IDJEFEUACI, ")
        strSQL.Append(" FECHAINICIOPROCESOCOMPRA = @FECHAINICIOPROCESOCOMPRA, ")
        strSQL.Append(" FECHAELABORACIONBASE = @FECHAELABORACIONBASE, ")
        strSQL.Append(" FECHAAPROBACIONBASE = @FECHAAPROBACIONBASE, ")
        strSQL.Append(" FECHAINICIOACLARACIONES = @FECHAINICIOACLARACIONES, ")
        strSQL.Append(" FECHAFINACLARACIONES = @FECHAFINACLARACIONES, ")
        strSQL.Append(" FECHAINICIOCONSULTA = @FECHAINICIOCONSULTA, ")
        strSQL.Append(" FECHAFINCONSULTA = @FECHAFINCONSULTA, ")
        strSQL.Append(" PORCENTAJEFINANCIERO = @PORCENTAJEFINANCIERO, ")
        strSQL.Append(" PORCENTAJEINDICESOLVENCIA = @PORCENTAJEINDICESOLVENCIA, ")
        strSQL.Append(" PORCENTAJECAPITALTRABAJO = @PORCENTAJECAPITALTRABAJO, ")
        strSQL.Append(" PORCENTAJEENDEUDAMIENTO = @PORCENTAJEENDEUDAMIENTO, ")
        strSQL.Append(" PORCENTAJEREFERENCIASBANC = @PORCENTAJEREFERENCIASBANC, ")
        strSQL.Append(" GARANTIAMTTOENTREGA = @GARANTIAMTTOENTREGA, ")
        strSQL.Append(" GARANTIAMTTOVIGENCIA = @GARANTIAMTTOVIGENCIA, ")
        strSQL.Append(" LUGARMTTO = @LUGARMTTO, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOVALOR = @GARANTIACUMPLIMIENTOVALOR, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOENTREGA = @GARANTIACUMPLIMIENTOENTREGA, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOVIGENCIA = @GARANTIACUMPLIMIENTOVIGENCIA, ")
        strSQL.Append(" LUGARCUMPLIMIENTO = @LUGARCUMPLIMIENTO, ")
        strSQL.Append(" GARANTIACALIDADVALOR = @GARANTIACALIDADVALOR, ")
        strSQL.Append(" GARANTIACALIDADENTREGA = @GARANTIACALIDADENTREGA, ")
        strSQL.Append(" GARANTIACALIDADVIGENCIA = @GARANTIACALIDADVIGENCIA, ")
        strSQL.Append(" LUGARCALIDAD = @LUGARCALIDAD, ")
        strSQL.Append(" FECHAINICIOANALISIS = @FECHAINICIOANALISIS, ")
        strSQL.Append(" FECHAFINANALISIS = @FECHAFINANALISIS, ")
        strSQL.Append(" FECHAFIRMARESOLUCION = @FECHAFIRMARESOLUCION, ")
        strSQL.Append(" NUMERORESOLUCION = @NUMERORESOLUCION, ")
        strSQL.Append(" FECHALIMITEACEPTACION = @FECHALIMITEACEPTACION, ")
        strSQL.Append(" FECHANOTIFICACION = @FECHANOTIFICACION, ")
        strSQL.Append(" FECHAPUBLICACIONRESOLUCION = @FECHAPUBLICACIONRESOLUCION, ")
        strSQL.Append(" MEDIOSDIVULGACION = @MEDIOSDIVULGACION, ")
        strSQL.Append(" FECHAFIRMAACEPTACION = @FECHAFIRMAACEPTACION, ")
        strSQL.Append(" VIGENCIACOTIZACION = @VIGENCIACOTIZACION, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOORDENCOMPRA = @GARANTIACUMPLIMIENTOORDENCOMPRA, ")
        strSQL.Append(" TIEMPOENTREGA = @TIEMPOENTREGA, ")
        strSQL.Append(" FECHAFINRECOMENDACION = @FECHAFINRECOMENDACION, ")
        strSQL.Append(" FECHAFINEXAMEN = @FECHAFINEXAMEN, ")
        strSQL.Append(" IDTITULARADJUDICACION = @IDTITULARADJUDICACION, ")
        strSQL.Append(" ACTAAPERTURA = @ACTAAPERTURA, ")
        strSQL.Append(" OBSERVACIONESACTA = @OBSERVACIONESACTA, ")
        strSQL.Append(" GARANTIAANTICIPOVALOR = @GARANTIAANTICIPOVALOR, ")
        strSQL.Append(" GARANTIAANTICIPOENTREGAS = @GARANTIAANTICIPOENTREGAS, ")
        strSQL.Append(" GARANTIAANTICIPOVIGENCIA = @GARANTIAANTICIPOVIGENCIA, ")
        strSQL.Append(" LUGARANTICIPO = @LUGARANTICIPO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(77) As SqlParameter
        args(0) = New SqlParameter("@IDTITULAR", SqlDbType.Int)
        args(0).Value = IIf(lEntidad.IDTITULAR = Nothing, DBNull.Value, lEntidad.IDTITULAR)
        args(1) = New SqlParameter("@IDENTIDADSOLICITA", SqlDbType.Int)
        args(1).Value = IIf(lEntidad.IDENTIDADSOLICITA = Nothing, DBNull.Value, lEntidad.IDENTIDADSOLICITA)
        args(2) = New SqlParameter("@FECHAENVIONOTA", SqlDbType.DateTime)
        args(2).Value = IIf(lEntidad.FECHAENVIONOTA = Nothing, DBNull.Value, lEntidad.FECHAENVIONOTA)
        args(3) = New SqlParameter("@COSTOBASE", SqlDbType.Decimal)
        args(3).Value = IIf(lEntidad.COSTOBASE = Nothing, DBNull.Value, lEntidad.COSTOBASE)
        args(4) = New SqlParameter("@LUGARAPERTURABASE", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.LUGARAPERTURABASE = Nothing, DBNull.Value, lEntidad.LUGARAPERTURABASE)
        args(5) = New SqlParameter("@DIRECCIONAPERTURABASE", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.DIRECCIONAPERTURABASE = Nothing, DBNull.Value, lEntidad.DIRECCIONAPERTURABASE)
        args(6) = New SqlParameter("@IDMUNICIPIOAPERTURA", SqlDbType.SmallInt)
        args(6).Value = IIf(lEntidad.IDMUNICIPIOAPERTURA = Nothing, DBNull.Value, lEntidad.IDMUNICIPIOAPERTURA)
        args(7) = New SqlParameter("@FECHAHORAINICIOAPERTURA", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.FECHAHORAINICIOAPERTURA = Nothing, DBNull.Value, lEntidad.FECHAHORAINICIOAPERTURA)
        args(8) = New SqlParameter("@FECHAHORAFINAPERTURA", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.FECHAHORAFINAPERTURA = Nothing, DBNull.Value, lEntidad.FECHAHORAFINAPERTURA)
        args(9) = New SqlParameter("@FECHAREALIZADAAPERTURA", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.FECHAREALIZADAAPERTURA = Nothing, DBNull.Value, lEntidad.FECHAREALIZADAAPERTURA)
        args(10) = New SqlParameter("@FECHAPUBLICACION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.FECHAPUBLICACION = Nothing, DBNull.Value, lEntidad.FECHAPUBLICACION)
        args(11) = New SqlParameter("@LUGARRETIROBASE", SqlDbType.VarChar)
        args(11).Value = IIf(lEntidad.LUGARRETIROBASE = Nothing, DBNull.Value, lEntidad.LUGARRETIROBASE)
        args(12) = New SqlParameter("@FECHAHORAINICIORETIRO", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.FECHAHORAINICIORETIRO = Nothing, DBNull.Value, lEntidad.FECHAHORAINICIORETIRO)
        args(13) = New SqlParameter("@FECHAHORAFINRETIRO", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.FECHAHORAFINRETIRO = Nothing, DBNull.Value, lEntidad.FECHAHORAFINRETIRO)
        args(14) = New SqlParameter("@LUGARRECEPCIONOFERTA", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.LUGARRECEPCIONOFERTA = Nothing, DBNull.Value, lEntidad.LUGARRECEPCIONOFERTA)
        args(15) = New SqlParameter("@DIRECCIONRECEPCIONOFERTA", SqlDbType.VarChar)
        args(15).Value = IIf(lEntidad.DIRECCIONRECEPCIONOFERTA = Nothing, DBNull.Value, lEntidad.DIRECCIONRECEPCIONOFERTA)
        args(16) = New SqlParameter("@IDMUNICIPIORECEPCION", SqlDbType.SmallInt)
        args(16).Value = IIf(lEntidad.IDMUNICIPIORECEPCION = Nothing, DBNull.Value, lEntidad.IDMUNICIPIORECEPCION)
        args(17) = New SqlParameter("@FECHAHORAINICIORECEPCION", SqlDbType.DateTime)
        args(17).Value = IIf(lEntidad.FECHAHORAINICIORECEPCION = Nothing, DBNull.Value, lEntidad.FECHAHORAINICIORECEPCION)
        args(18) = New SqlParameter("@FECHAHORAFINRECEPCION", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.FECHAHORAFINRECEPCION = Nothing, DBNull.Value, lEntidad.FECHAHORAFINRECEPCION)
        args(19) = New SqlParameter("@CODIGOLICITACION", SqlDbType.VarChar)
        args(19).Value = IIf(lEntidad.CODIGOLICITACION = Nothing, DBNull.Value, lEntidad.CODIGOLICITACION)
        args(20) = New SqlParameter("@TITULOLICITACION", SqlDbType.VarChar)
        args(20).Value = IIf(lEntidad.TITULOLICITACION = Nothing, DBNull.Value, lEntidad.TITULOLICITACION)
        args(21) = New SqlParameter("@DESCRIPCIONLICITACION", SqlDbType.VarChar)
        args(21).Value = IIf(lEntidad.DESCRIPCIONLICITACION = Nothing, DBNull.Value, lEntidad.DESCRIPCIONLICITACION)
        args(22) = New SqlParameter("@IDTIPOCOMPRASUGERIDO", SqlDbType.Int)
        args(22).Value = IIf(lEntidad.IDTIPOCOMPRASUGERIDO = Nothing, DBNull.Value, lEntidad.IDTIPOCOMPRASUGERIDO)
        args(23) = New SqlParameter("@IDTIPOCOMPRAEJECUTAR", SqlDbType.Int)
        args(23).Value = IIf(lEntidad.IDTIPOCOMPRAEJECUTAR = Nothing, DBNull.Value, lEntidad.IDTIPOCOMPRAEJECUTAR)
        args(24) = New SqlParameter("@IDESTADOPROCESOCOMPRA", SqlDbType.Int)
        args(24).Value = IIf(lEntidad.IDESTADOPROCESOCOMPRA = Nothing, DBNull.Value, lEntidad.IDESTADOPROCESOCOMPRA)
        args(25) = New SqlParameter("@IDENCARGADO", SqlDbType.Int)
        args(25).Value = lEntidad.IDENCARGADO
        args(26) = New SqlParameter("@IDJEFEUACI", SqlDbType.Int)
        args(26).Value = IIf(lEntidad.IDJEFEUACI = Nothing, DBNull.Value, lEntidad.IDJEFEUACI)
        args(27) = New SqlParameter("@FECHAINICIOPROCESOCOMPRA", SqlDbType.DateTime)
        args(27).Value = lEntidad.FECHAINICIOPROCESOCOMPRA
        args(28) = New SqlParameter("@FECHAELABORACIONBASE", SqlDbType.DateTime)
        args(28).Value = IIf(lEntidad.FECHAELABORACIONBASE = Nothing, DBNull.Value, lEntidad.FECHAELABORACIONBASE)
        args(29) = New SqlParameter("@FECHAAPROBACIONBASE", SqlDbType.DateTime)
        args(29).Value = IIf(lEntidad.FECHAAPROBACIONBASE = Nothing, DBNull.Value, lEntidad.FECHAAPROBACIONBASE)
        args(30) = New SqlParameter("@FECHAINICIOACLARACIONES", SqlDbType.DateTime)
        args(30).Value = IIf(lEntidad.FECHAINICIOACLARACIONES = Nothing, DBNull.Value, lEntidad.FECHAINICIOACLARACIONES)
        args(31) = New SqlParameter("@FECHAFINACLARACIONES", SqlDbType.DateTime)
        args(31).Value = IIf(lEntidad.FECHAFINACLARACIONES = Nothing, DBNull.Value, lEntidad.FECHAFINACLARACIONES)
        args(32) = New SqlParameter("@FECHAINICIOCONSULTA", SqlDbType.DateTime)
        args(32).Value = IIf(lEntidad.FECHAINICIOCONSULTA = Nothing, DBNull.Value, lEntidad.FECHAINICIOCONSULTA)
        args(33) = New SqlParameter("@FECHAFINCONSULTA", SqlDbType.DateTime)
        args(33).Value = IIf(lEntidad.FECHAFINCONSULTA = Nothing, DBNull.Value, lEntidad.FECHAFINCONSULTA)
        args(34) = New SqlParameter("@PORCENTAJEFINANCIERO", SqlDbType.Decimal)
        args(34).Value = lEntidad.PORCENTAJEFINANCIERO
        args(35) = New SqlParameter("@PORCENTAJEINDICESOLVENCIA", SqlDbType.Decimal)
        args(35).Value = lEntidad.PORCENTAJEINDICESOLVENCIA
        args(36) = New SqlParameter("@PORCENTAJECAPITALTRABAJO", SqlDbType.Decimal)
        args(36).Value = lEntidad.PORCENTAJECAPITALTRABAJO
        args(37) = New SqlParameter("@PORCENTAJEENDEUDAMIENTO", SqlDbType.Decimal)
        args(37).Value = lEntidad.PORCENTAJEENDEUDAMIENTO
        args(38) = New SqlParameter("@PORCENTAJEREFERENCIASBANC", SqlDbType.Decimal)
        args(38).Value = lEntidad.PORCENTAJEREFERENCIASBANC
        args(39) = New SqlParameter("@GARANTIAMTTOENTREGA", SqlDbType.SmallInt)
        args(39).Value = lEntidad.GARANTIAMTTOENTREGA
        args(40) = New SqlParameter("@GARANTIAMTTOVIGENCIA", SqlDbType.SmallInt)
        args(40).Value = lEntidad.GARANTIAMTTOVIGENCIA
        args(41) = New SqlParameter("@LUGARMTTO", SqlDbType.VarChar)
        args(41).Value = lEntidad.LUGARMTTO
        args(42) = New SqlParameter("@GARANTIACUMPLIMIENTOVALOR", SqlDbType.Decimal)
        args(42).Value = lEntidad.GARANTIACUMPLIMIENTOVALOR
        args(43) = New SqlParameter("@GARANTIACUMPLIMIENTOENTREGA", SqlDbType.SmallInt)
        args(43).Value = lEntidad.GARANTIACUMPLIMIENTOENTREGA
        args(44) = New SqlParameter("@GARANTIACUMPLIMIENTOVIGENCIA", SqlDbType.SmallInt)
        args(44).Value = lEntidad.GARANTIACUMPLIMIENTOVIGENCIA
        args(45) = New SqlParameter("@LUGARCUMPLIMIENTO", SqlDbType.VarChar)
        args(45).Value = IIf(lEntidad.LUGARCUMPLIMIENTO = Nothing, DBNull.Value, lEntidad.LUGARCUMPLIMIENTO)
        args(46) = New SqlParameter("@GARANTIACALIDADVALOR", SqlDbType.Decimal)
        args(46).Value = lEntidad.GARANTIACALIDADVALOR
        args(47) = New SqlParameter("@GARANTIACALIDADENTREGA", SqlDbType.SmallInt)
        args(47).Value = lEntidad.GARANTIACALIDADENTREGA
        args(48) = New SqlParameter("@GARANTIACALIDADVIGENCIA", SqlDbType.SmallInt)
        args(48).Value = lEntidad.GARANTIACALIDADVIGENCIA
        args(49) = New SqlParameter("@LUGARCALIDAD", SqlDbType.VarChar)
        args(49).Value = IIf(lEntidad.LUGARCALIDAD = Nothing, DBNull.Value, lEntidad.LUGARCALIDAD)
        args(50) = New SqlParameter("@FECHAINICIOANALISIS", SqlDbType.DateTime)
        args(50).Value = IIf(lEntidad.FECHAINICIOANALISIS = Nothing, DBNull.Value, lEntidad.FECHAINICIOANALISIS)
        args(51) = New SqlParameter("@FECHAFINANALISIS", SqlDbType.DateTime)
        args(51).Value = IIf(lEntidad.FECHAFINANALISIS = Nothing, DBNull.Value, lEntidad.FECHAFINANALISIS)
        args(52) = New SqlParameter("@FECHAFIRMARESOLUCION", SqlDbType.DateTime)
        args(52).Value = IIf(lEntidad.FECHAFIRMARESOLUCION = Nothing, DBNull.Value, lEntidad.FECHAFIRMARESOLUCION)
        args(53) = New SqlParameter("@NUMERORESOLUCION", SqlDbType.VarChar)
        args(53).Value = IIf(lEntidad.NUMERORESOLUCION = Nothing, DBNull.Value, lEntidad.NUMERORESOLUCION)
        args(54) = New SqlParameter("@FECHALIMITEACEPTACION", SqlDbType.DateTime)
        args(54).Value = IIf(lEntidad.FECHALIMITEACEPTACION = Nothing, DBNull.Value, lEntidad.FECHALIMITEACEPTACION)
        args(55) = New SqlParameter("@FECHANOTIFICACION", SqlDbType.DateTime)
        args(55).Value = IIf(lEntidad.FECHANOTIFICACION = Nothing, DBNull.Value, lEntidad.FECHANOTIFICACION)
        args(56) = New SqlParameter("@FECHAPUBLICACIONRESOLUCION", SqlDbType.DateTime)
        args(56).Value = IIf(lEntidad.FECHAPUBLICACIONRESOLUCION = Nothing, DBNull.Value, lEntidad.FECHAPUBLICACIONRESOLUCION)
        args(57) = New SqlParameter("@MEDIOSDIVULGACION", SqlDbType.VarChar)
        args(57).Value = IIf(lEntidad.MEDIOSDIVULGACION = Nothing, DBNull.Value, lEntidad.MEDIOSDIVULGACION)
        args(58) = New SqlParameter("@FECHAFIRMAACEPTACION", SqlDbType.DateTime)
        args(58).Value = IIf(lEntidad.FECHAFIRMAACEPTACION = Nothing, DBNull.Value, lEntidad.FECHAFIRMAACEPTACION)
        args(59) = New SqlParameter("@VIGENCIACOTIZACION", SqlDbType.SmallInt)
        args(59).Value = IIf(lEntidad.VIGENCIACOTIZACION = Nothing, DBNull.Value, lEntidad.VIGENCIACOTIZACION)
        args(60) = New SqlParameter("@GARANTIACUMPLIMIENTOORDENCOMPRA", SqlDbType.Decimal)
        args(60).Value = IIf(lEntidad.GARANTIACUMPLIMIENTOORDENCOMPRA = Nothing, DBNull.Value, lEntidad.GARANTIACUMPLIMIENTOORDENCOMPRA)
        args(61) = New SqlParameter("@TIEMPOENTREGA", SqlDbType.SmallInt)
        args(61).Value = IIf(lEntidad.TIEMPOENTREGA = Nothing, DBNull.Value, lEntidad.TIEMPOENTREGA)
        args(62) = New SqlParameter("@FECHAFINRECOMENDACION", SqlDbType.DateTime)
        args(62).Value = IIf(lEntidad.FECHAFINRECOMENDACION = Nothing, DBNull.Value, lEntidad.FECHAFINRECOMENDACION)
        args(63) = New SqlParameter("@FECHAFINEXAMEN", SqlDbType.DateTime)
        args(63).Value = IIf(lEntidad.FECHAFINEXAMEN = Nothing, DBNull.Value, lEntidad.FECHAFINEXAMEN)
        args(64) = New SqlParameter("@IDTITULARADJUDICACION", SqlDbType.Int)
        args(64).Value = IIf(lEntidad.IDTITULARADJUDICACION = Nothing, DBNull.Value, lEntidad.IDTITULARADJUDICACION)
        args(65) = New SqlParameter("@ACTAAPERTURA", SqlDbType.VarChar)
        args(65).Value = IIf(lEntidad.ACTAAPERTURA = Nothing, DBNull.Value, lEntidad.ACTAAPERTURA)
        args(66) = New SqlParameter("@OBSERVACIONESACTA", SqlDbType.VarChar)
        args(66).Value = IIf(lEntidad.OBSERVACIONESACTA = Nothing, DBNull.Value, lEntidad.OBSERVACIONESACTA)
        args(67) = New SqlParameter("@GARANTIAANTICIPOVALOR", SqlDbType.Decimal)
        args(67).Value = lEntidad.GARANTIAANTICIPOVALOR
        args(68) = New SqlParameter("@GARANTIAANTICIPOENTREGAS", SqlDbType.SmallInt)
        args(68).Value = lEntidad.GARANTIAANTICIPOENTREGAS
        args(69) = New SqlParameter("@GARANTIAANTICIPOVIGENCIA", SqlDbType.SmallInt)
        args(69).Value = lEntidad.GARANTIAANTICIPOVIGENCIA
        args(70) = New SqlParameter("@LUGARANTICIPO", SqlDbType.VarChar)
        args(70).Value = IIf(lEntidad.LUGARANTICIPO = Nothing, DBNull.Value, lEntidad.LUGARANTICIPO)
        args(71) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(71).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(72) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(72).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(73) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(73).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(74) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(74).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(75) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(75).Value = lEntidad.ESTASINCRONIZADA
        args(76) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(76).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(77) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(77).Value = IIf(lEntidad.IDPROCESOCOMPRA = Nothing, DBNull.Value, lEntidad.IDPROCESOCOMPRA)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overloads Function Actualizar(ByVal IDEstablecimiento As Integer, ByVal IDProcesoCompra As Integer, ByVal HabilitaModificacionDistribucion As Boolean) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" UPDATE SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" SET HabilitaModDistr = @HabilitaModDistr ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDEstablecimiento
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDProcesoCompra
        args(2) = New SqlParameter("@HabilitaModDistr", SqlDbType.Bit)
        args(2).Value = HabilitaModificacionDistribucion
        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROCESOCOMPRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDTITULAR, ")
        strSQL.Append(" IDENTIDADSOLICITA, ")
        strSQL.Append(" FECHAENVIONOTA, ")
        strSQL.Append(" COSTOBASE, ")
        strSQL.Append(" LUGARAPERTURABASE, ")
        strSQL.Append(" DIRECCIONAPERTURABASE, ")
        strSQL.Append(" IDMUNICIPIOAPERTURA, ")
        strSQL.Append(" FECHAHORAINICIOAPERTURA, ")
        strSQL.Append(" FECHAHORAFINAPERTURA, ")
        strSQL.Append(" FECHAREALIZADAAPERTURA, ")
        strSQL.Append(" FECHAPUBLICACION, ")
        strSQL.Append(" LUGARRETIROBASE, ")
        strSQL.Append(" FECHAHORAINICIORETIRO, ")
        strSQL.Append(" FECHAHORAFINRETIRO, ")
        strSQL.Append(" LUGARRECEPCIONOFERTA, ")
        strSQL.Append(" DIRECCIONRECEPCIONOFERTA, ")
        strSQL.Append(" IDMUNICIPIORECEPCION, ")
        strSQL.Append(" FECHAHORAINICIORECEPCION, ")
        strSQL.Append(" FECHAHORAFINRECEPCION, ")
        strSQL.Append(" CODIGOLICITACION, ")
        strSQL.Append(" TITULOLICITACION, ")
        strSQL.Append(" DESCRIPCIONLICITACION, ")
        strSQL.Append(" IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" IDESTADOPROCESOCOMPRA, ")
        strSQL.Append(" IDENCARGADO, ")
        strSQL.Append(" IDJEFEUACI, ")
        strSQL.Append(" FECHAINICIOPROCESOCOMPRA, ")
        strSQL.Append(" FECHAELABORACIONBASE, ")
        strSQL.Append(" FECHAAPROBACIONBASE, ")
        strSQL.Append(" FECHAINICIOACLARACIONES, ")
        strSQL.Append(" FECHAFINACLARACIONES, ")
        strSQL.Append(" FECHAINICIOCONSULTA, ")
        strSQL.Append(" FECHAFINCONSULTA, ")
        strSQL.Append(" PORCENTAJEFINANCIERO, ")
        strSQL.Append(" PORCENTAJEINDICESOLVENCIA, ")
        strSQL.Append(" PORCENTAJECAPITALTRABAJO, ")
        strSQL.Append(" PORCENTAJEENDEUDAMIENTO, ")
        strSQL.Append(" PORCENTAJEREFERENCIASBANC, ")
        strSQL.Append(" GARANTIAMTTOENTREGA, ")
        strSQL.Append(" GARANTIAMTTOVIGENCIA, ")
        strSQL.Append(" LUGARMTTO, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOVALOR, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOENTREGA, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOVIGENCIA, ")
        strSQL.Append(" LUGARCUMPLIMIENTO, ")
        strSQL.Append(" GARANTIACALIDADVALOR, ")
        strSQL.Append(" GARANTIACALIDADENTREGA, ")
        strSQL.Append(" GARANTIACALIDADVIGENCIA, ")
        strSQL.Append(" LUGARCALIDAD, ")
        strSQL.Append(" FECHAINICIOANALISIS, ")
        strSQL.Append(" FECHAFINANALISIS, ")
        strSQL.Append(" FECHAFIRMARESOLUCION, ")
        strSQL.Append(" NUMERORESOLUCION, ")
        strSQL.Append(" FECHALIMITEACEPTACION, ")
        strSQL.Append(" FECHANOTIFICACION, ")
        strSQL.Append(" FECHAPUBLICACIONRESOLUCION, ")
        strSQL.Append(" MEDIOSDIVULGACION, ")
        strSQL.Append(" FECHAFIRMAACEPTACION, ")
        strSQL.Append(" VIGENCIACOTIZACION, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOORDENCOMPRA, ")
        strSQL.Append(" TIEMPOENTREGA, ")
        strSQL.Append(" FECHAFINRECOMENDACION, ")
        strSQL.Append(" FECHAFINEXAMEN, ")
        strSQL.Append(" IDTITULARADJUDICACION, ")
        strSQL.Append(" ACTAAPERTURA, ")
        strSQL.Append(" OBSERVACIONESACTA, ")
        strSQL.Append(" GARANTIAANTICIPOVALOR, ")
        strSQL.Append(" GARANTIAANTICIPOENTREGAS, ")
        strSQL.Append(" GARANTIAANTICIPOVIGENCIA, ")
        strSQL.Append(" LUGARANTICIPO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDTITULAR, ")
        strSQL.Append(" @IDENTIDADSOLICITA, ")
        strSQL.Append(" @FECHAENVIONOTA, ")
        strSQL.Append(" @COSTOBASE, ")
        strSQL.Append(" @LUGARAPERTURABASE, ")
        strSQL.Append(" @DIRECCIONAPERTURABASE, ")
        strSQL.Append(" @IDMUNICIPIOAPERTURA, ")
        strSQL.Append(" @FECHAHORAINICIOAPERTURA, ")
        strSQL.Append(" @FECHAHORAFINAPERTURA, ")
        strSQL.Append(" @FECHAREALIZADAAPERTURA, ")
        strSQL.Append(" @FECHAPUBLICACION, ")
        strSQL.Append(" @LUGARRETIROBASE, ")
        strSQL.Append(" @FECHAHORAINICIORETIRO, ")
        strSQL.Append(" @FECHAHORAFINRETIRO, ")
        strSQL.Append(" @LUGARRECEPCIONOFERTA, ")
        strSQL.Append(" @DIRECCIONRECEPCIONOFERTA, ")
        strSQL.Append(" @IDMUNICIPIORECEPCION, ")
        strSQL.Append(" @FECHAHORAINICIORECEPCION, ")
        strSQL.Append(" @FECHAHORAFINRECEPCION, ")
        strSQL.Append(" @CODIGOLICITACION, ")
        strSQL.Append(" @TITULOLICITACION, ")
        strSQL.Append(" @DESCRIPCIONLICITACION, ")
        strSQL.Append(" @IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" @IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" @IDESTADOPROCESOCOMPRA, ")
        strSQL.Append(" @IDENCARGADO, ")
        strSQL.Append(" @IDJEFEUACI, ")
        strSQL.Append(" @FECHAINICIOPROCESOCOMPRA, ")
        strSQL.Append(" @FECHAELABORACIONBASE, ")
        strSQL.Append(" @FECHAAPROBACIONBASE, ")
        strSQL.Append(" @FECHAINICIOACLARACIONES, ")
        strSQL.Append(" @FECHAFINACLARACIONES, ")
        strSQL.Append(" @FECHAINICIOCONSULTA, ")
        strSQL.Append(" @FECHAFINCONSULTA, ")
        strSQL.Append(" @PORCENTAJEFINANCIERO, ")
        strSQL.Append(" @PORCENTAJEINDICESOLVENCIA, ")
        strSQL.Append(" @PORCENTAJECAPITALTRABAJO, ")
        strSQL.Append(" @PORCENTAJEENDEUDAMIENTO, ")
        strSQL.Append(" @PORCENTAJEREFERENCIASBANC, ")
        strSQL.Append(" @GARANTIAMTTOENTREGA, ")
        strSQL.Append(" @GARANTIAMTTOVIGENCIA, ")
        strSQL.Append(" @LUGARMTTO, ")
        strSQL.Append(" @GARANTIACUMPLIMIENTOVALOR, ")
        strSQL.Append(" @GARANTIACUMPLIMIENTOENTREGA, ")
        strSQL.Append(" @GARANTIACUMPLIMIENTOVIGENCIA, ")
        strSQL.Append(" @LUGARCUMPLIMIENTO, ")
        strSQL.Append(" @GARANTIACALIDADVALOR, ")
        strSQL.Append(" @GARANTIACALIDADENTREGA, ")
        strSQL.Append(" @GARANTIACALIDADVIGENCIA, ")
        strSQL.Append(" @LUGARCALIDAD, ")
        strSQL.Append(" @FECHAINICIOANALISIS, ")
        strSQL.Append(" @FECHAFINANALISIS, ")
        strSQL.Append(" @FECHAFIRMARESOLUCION, ")
        strSQL.Append(" @NUMERORESOLUCION, ")
        strSQL.Append(" @FECHALIMITEACEPTACION, ")
        strSQL.Append(" @FECHANOTIFICACION, ")
        strSQL.Append(" @FECHAPUBLICACIONRESOLUCION, ")
        strSQL.Append(" @MEDIOSDIVULGACION, ")
        strSQL.Append(" @FECHAFIRMAACEPTACION, ")
        strSQL.Append(" @VIGENCIACOTIZACION, ")
        strSQL.Append(" @GARANTIACUMPLIMIENTOORDENCOMPRA, ")
        strSQL.Append(" @TIEMPOENTREGA, ")
        strSQL.Append(" @FECHAFINRECOMENDACION, ")
        strSQL.Append(" @FECHAFINEXAMEN, ")
        strSQL.Append(" @IDTITULARADJUDICACION, ")
        strSQL.Append(" @ACTAAPERTURA, ")
        strSQL.Append(" @OBSERVACIONESACTA, ")
        strSQL.Append(" @GARANTIAANTICIPOVALOR, ")
        strSQL.Append(" @GARANTIAANTICIPOENTREGAS, ")
        strSQL.Append(" @GARANTIAANTICIPOVIGENCIA, ")
        strSQL.Append(" @LUGARANTICIPO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(77) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDTITULAR", SqlDbType.Int)
        args(2).Value = IIf(lEntidad.IDTITULAR = Nothing, DBNull.Value, lEntidad.IDTITULAR)
        args(3) = New SqlParameter("@IDENTIDADSOLICITA", SqlDbType.Int)
        args(3).Value = IIf(lEntidad.IDENTIDADSOLICITA = Nothing, DBNull.Value, lEntidad.IDENTIDADSOLICITA)
        args(4) = New SqlParameter("@FECHAENVIONOTA", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.FECHAENVIONOTA = Nothing, DBNull.Value, lEntidad.FECHAENVIONOTA)
        args(5) = New SqlParameter("@COSTOBASE", SqlDbType.Decimal)
        args(5).Value = IIf(lEntidad.COSTOBASE = Nothing, DBNull.Value, lEntidad.COSTOBASE)
        args(6) = New SqlParameter("@LUGARAPERTURABASE", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.LUGARAPERTURABASE = Nothing, DBNull.Value, lEntidad.LUGARAPERTURABASE)
        args(7) = New SqlParameter("@DIRECCIONAPERTURABASE", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.DIRECCIONAPERTURABASE = Nothing, DBNull.Value, lEntidad.DIRECCIONAPERTURABASE)
        args(8) = New SqlParameter("@IDMUNICIPIOAPERTURA", SqlDbType.SmallInt)
        args(8).Value = IIf(lEntidad.IDMUNICIPIOAPERTURA = Nothing, DBNull.Value, lEntidad.IDMUNICIPIOAPERTURA)
        args(9) = New SqlParameter("@FECHAHORAINICIOAPERTURA", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.FECHAHORAINICIOAPERTURA = Nothing, DBNull.Value, lEntidad.FECHAHORAINICIOAPERTURA)
        args(10) = New SqlParameter("@FECHAHORAFINAPERTURA", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.FECHAHORAFINAPERTURA = Nothing, DBNull.Value, lEntidad.FECHAHORAFINAPERTURA)
        args(11) = New SqlParameter("@FECHAREALIZADAAPERTURA", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.FECHAREALIZADAAPERTURA = Nothing, DBNull.Value, lEntidad.FECHAREALIZADAAPERTURA)
        args(12) = New SqlParameter("@FECHAPUBLICACION", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.FECHAPUBLICACION = Nothing, DBNull.Value, lEntidad.FECHAPUBLICACION)
        args(13) = New SqlParameter("@LUGARRETIROBASE", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.LUGARRETIROBASE = Nothing, DBNull.Value, lEntidad.LUGARRETIROBASE)
        args(14) = New SqlParameter("@FECHAHORAINICIORETIRO", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.FECHAHORAINICIORETIRO = Nothing, DBNull.Value, lEntidad.FECHAHORAINICIORETIRO)
        args(15) = New SqlParameter("@FECHAHORAFINRETIRO", SqlDbType.DateTime)
        args(15).Value = IIf(lEntidad.FECHAHORAFINRETIRO = Nothing, DBNull.Value, lEntidad.FECHAHORAFINRETIRO)
        args(16) = New SqlParameter("@LUGARRECEPCIONOFERTA", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.LUGARRECEPCIONOFERTA = Nothing, DBNull.Value, lEntidad.LUGARRECEPCIONOFERTA)
        args(17) = New SqlParameter("@DIRECCIONRECEPCIONOFERTA", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.DIRECCIONRECEPCIONOFERTA = Nothing, DBNull.Value, lEntidad.DIRECCIONRECEPCIONOFERTA)
        args(18) = New SqlParameter("@IDMUNICIPIORECEPCION", SqlDbType.SmallInt)
        args(18).Value = IIf(lEntidad.IDMUNICIPIORECEPCION = Nothing, DBNull.Value, lEntidad.IDMUNICIPIORECEPCION)
        args(19) = New SqlParameter("@FECHAHORAINICIORECEPCION", SqlDbType.DateTime)
        args(19).Value = IIf(lEntidad.FECHAHORAINICIORECEPCION = Nothing, DBNull.Value, lEntidad.FECHAHORAINICIORECEPCION)
        args(20) = New SqlParameter("@FECHAHORAFINRECEPCION", SqlDbType.DateTime)
        args(20).Value = IIf(lEntidad.FECHAHORAFINRECEPCION = Nothing, DBNull.Value, lEntidad.FECHAHORAFINRECEPCION)
        args(21) = New SqlParameter("@CODIGOLICITACION", SqlDbType.VarChar)
        args(21).Value = IIf(lEntidad.CODIGOLICITACION = Nothing, DBNull.Value, lEntidad.CODIGOLICITACION)
        args(22) = New SqlParameter("@TITULOLICITACION", SqlDbType.VarChar)
        args(22).Value = IIf(lEntidad.TITULOLICITACION = Nothing, DBNull.Value, lEntidad.TITULOLICITACION)
        args(23) = New SqlParameter("@DESCRIPCIONLICITACION", SqlDbType.VarChar)
        args(23).Value = IIf(lEntidad.DESCRIPCIONLICITACION = Nothing, DBNull.Value, lEntidad.DESCRIPCIONLICITACION)
        args(24) = New SqlParameter("@IDTIPOCOMPRASUGERIDO", SqlDbType.Int)
        args(24).Value = IIf(lEntidad.IDTIPOCOMPRASUGERIDO = Nothing, DBNull.Value, lEntidad.IDTIPOCOMPRASUGERIDO)
        args(25) = New SqlParameter("@IDTIPOCOMPRAEJECUTAR", SqlDbType.Int)
        args(25).Value = IIf(lEntidad.IDTIPOCOMPRAEJECUTAR = Nothing, DBNull.Value, lEntidad.IDTIPOCOMPRAEJECUTAR)
        args(26) = New SqlParameter("@IDESTADOPROCESOCOMPRA", SqlDbType.Int)
        args(26).Value = IIf(lEntidad.IDESTADOPROCESOCOMPRA = Nothing, DBNull.Value, lEntidad.IDESTADOPROCESOCOMPRA)
        args(27) = New SqlParameter("@IDENCARGADO", SqlDbType.Int)
        args(27).Value = lEntidad.IDENCARGADO
        args(28) = New SqlParameter("@IDJEFEUACI", SqlDbType.Int)
        args(28).Value = IIf(lEntidad.IDJEFEUACI = Nothing, DBNull.Value, lEntidad.IDJEFEUACI)
        args(29) = New SqlParameter("@FECHAINICIOPROCESOCOMPRA", SqlDbType.DateTime)
        args(29).Value = lEntidad.FECHAINICIOPROCESOCOMPRA
        args(30) = New SqlParameter("@FECHAELABORACIONBASE", SqlDbType.DateTime)
        args(30).Value = IIf(lEntidad.FECHAELABORACIONBASE = Nothing, DBNull.Value, lEntidad.FECHAELABORACIONBASE)
        args(31) = New SqlParameter("@FECHAAPROBACIONBASE", SqlDbType.DateTime)
        args(31).Value = IIf(lEntidad.FECHAAPROBACIONBASE = Nothing, DBNull.Value, lEntidad.FECHAAPROBACIONBASE)
        args(32) = New SqlParameter("@FECHAINICIOACLARACIONES", SqlDbType.DateTime)
        args(32).Value = IIf(lEntidad.FECHAINICIOACLARACIONES = Nothing, DBNull.Value, lEntidad.FECHAINICIOACLARACIONES)
        args(33) = New SqlParameter("@FECHAFINACLARACIONES", SqlDbType.DateTime)
        args(33).Value = IIf(lEntidad.FECHAFINACLARACIONES = Nothing, DBNull.Value, lEntidad.FECHAFINACLARACIONES)
        args(34) = New SqlParameter("@FECHAINICIOCONSULTA", SqlDbType.DateTime)
        args(34).Value = IIf(lEntidad.FECHAINICIOCONSULTA = Nothing, DBNull.Value, lEntidad.FECHAINICIOCONSULTA)
        args(35) = New SqlParameter("@FECHAFINCONSULTA", SqlDbType.DateTime)
        args(35).Value = IIf(lEntidad.FECHAFINCONSULTA = Nothing, DBNull.Value, lEntidad.FECHAFINCONSULTA)
        args(36) = New SqlParameter("@PORCENTAJEFINANCIERO", SqlDbType.Decimal)
        args(36).Value = lEntidad.PORCENTAJEFINANCIERO
        args(37) = New SqlParameter("@PORCENTAJEINDICESOLVENCIA", SqlDbType.Decimal)
        args(37).Value = lEntidad.PORCENTAJEINDICESOLVENCIA
        args(38) = New SqlParameter("@PORCENTAJECAPITALTRABAJO", SqlDbType.Decimal)
        args(38).Value = lEntidad.PORCENTAJECAPITALTRABAJO
        args(39) = New SqlParameter("@PORCENTAJEENDEUDAMIENTO", SqlDbType.Decimal)
        args(39).Value = lEntidad.PORCENTAJEENDEUDAMIENTO
        args(40) = New SqlParameter("@PORCENTAJEREFERENCIASBANC", SqlDbType.Decimal)
        args(40).Value = lEntidad.PORCENTAJEREFERENCIASBANC
        args(41) = New SqlParameter("@GARANTIAMTTOENTREGA", SqlDbType.SmallInt)
        args(41).Value = lEntidad.GARANTIAMTTOENTREGA
        args(42) = New SqlParameter("@GARANTIAMTTOVIGENCIA", SqlDbType.SmallInt)
        args(42).Value = lEntidad.GARANTIAMTTOVIGENCIA
        args(43) = New SqlParameter("@LUGARMTTO", SqlDbType.VarChar)
        args(43).Value = IIf(lEntidad.LUGARMTTO = Nothing, DBNull.Value, lEntidad.LUGARMTTO)
        args(44) = New SqlParameter("@GARANTIACUMPLIMIENTOVALOR", SqlDbType.Decimal)
        args(44).Value = lEntidad.GARANTIACUMPLIMIENTOVALOR
        args(45) = New SqlParameter("@GARANTIACUMPLIMIENTOENTREGA", SqlDbType.SmallInt)
        args(45).Value = lEntidad.GARANTIACUMPLIMIENTOENTREGA
        args(46) = New SqlParameter("@GARANTIACUMPLIMIENTOVIGENCIA", SqlDbType.SmallInt)
        args(46).Value = lEntidad.GARANTIACUMPLIMIENTOVIGENCIA
        args(47) = New SqlParameter("@LUGARCUMPLIMIENTO", SqlDbType.VarChar)
        args(47).Value = IIf(lEntidad.LUGARCUMPLIMIENTO = Nothing, DBNull.Value, lEntidad.LUGARCUMPLIMIENTO)
        args(48) = New SqlParameter("@GARANTIACALIDADVALOR", SqlDbType.Decimal)
        args(48).Value = lEntidad.GARANTIACALIDADVALOR
        args(49) = New SqlParameter("@GARANTIACALIDADENTREGA", SqlDbType.SmallInt)
        args(49).Value = lEntidad.GARANTIACALIDADENTREGA
        args(50) = New SqlParameter("@GARANTIACALIDADVIGENCIA", SqlDbType.SmallInt)
        args(50).Value = lEntidad.GARANTIACALIDADVIGENCIA
        args(51) = New SqlParameter("@LUGARCALIDAD", SqlDbType.VarChar)
        args(51).Value = IIf(lEntidad.LUGARCALIDAD = Nothing, DBNull.Value, lEntidad.LUGARCALIDAD)
        args(52) = New SqlParameter("@FECHAINICIOANALISIS", SqlDbType.DateTime)
        args(52).Value = IIf(lEntidad.FECHAINICIOANALISIS = Nothing, DBNull.Value, lEntidad.FECHAINICIOANALISIS)
        args(53) = New SqlParameter("@FECHAFINANALISIS", SqlDbType.DateTime)
        args(53).Value = IIf(lEntidad.FECHAFINANALISIS = Nothing, DBNull.Value, lEntidad.FECHAFINANALISIS)
        args(54) = New SqlParameter("@FECHAFIRMARESOLUCION", SqlDbType.DateTime)
        args(54).Value = IIf(lEntidad.FECHAFIRMARESOLUCION = Nothing, DBNull.Value, lEntidad.FECHAFIRMARESOLUCION)
        args(55) = New SqlParameter("@NUMERORESOLUCION", SqlDbType.VarChar)
        args(55).Value = IIf(lEntidad.NUMERORESOLUCION = Nothing, DBNull.Value, lEntidad.NUMERORESOLUCION)
        args(56) = New SqlParameter("@FECHALIMITEACEPTACION", SqlDbType.DateTime)
        args(56).Value = IIf(lEntidad.FECHALIMITEACEPTACION = Nothing, DBNull.Value, lEntidad.FECHALIMITEACEPTACION)
        args(57) = New SqlParameter("@FECHANOTIFICACION", SqlDbType.DateTime)
        args(57).Value = IIf(lEntidad.FECHANOTIFICACION = Nothing, DBNull.Value, lEntidad.FECHANOTIFICACION)
        args(58) = New SqlParameter("@FECHAPUBLICACIONRESOLUCION", SqlDbType.DateTime)
        args(58).Value = IIf(lEntidad.FECHAPUBLICACIONRESOLUCION = Nothing, DBNull.Value, lEntidad.FECHAPUBLICACIONRESOLUCION)
        args(59) = New SqlParameter("@MEDIOSDIVULGACION", SqlDbType.VarChar)
        args(59).Value = IIf(lEntidad.MEDIOSDIVULGACION = Nothing, DBNull.Value, lEntidad.MEDIOSDIVULGACION)
        args(60) = New SqlParameter("@FECHAFIRMAACEPTACION", SqlDbType.DateTime)
        args(60).Value = IIf(lEntidad.FECHAFIRMAACEPTACION = Nothing, DBNull.Value, lEntidad.FECHAFIRMAACEPTACION)
        args(61) = New SqlParameter("@VIGENCIACOTIZACION", SqlDbType.SmallInt)
        args(61).Value = IIf(lEntidad.VIGENCIACOTIZACION = Nothing, DBNull.Value, lEntidad.VIGENCIACOTIZACION)
        args(62) = New SqlParameter("@GARANTIACUMPLIMIENTOORDENCOMPRA", SqlDbType.Decimal)
        args(62).Value = IIf(lEntidad.GARANTIACUMPLIMIENTOORDENCOMPRA = Nothing, DBNull.Value, lEntidad.GARANTIACUMPLIMIENTOORDENCOMPRA)
        args(63) = New SqlParameter("@TIEMPOENTREGA", SqlDbType.SmallInt)
        args(63).Value = IIf(lEntidad.TIEMPOENTREGA = Nothing, DBNull.Value, lEntidad.TIEMPOENTREGA)
        args(64) = New SqlParameter("@FECHAFINRECOMENDACION", SqlDbType.DateTime)
        args(64).Value = IIf(lEntidad.FECHAFINRECOMENDACION = Nothing, DBNull.Value, lEntidad.FECHAFINRECOMENDACION)
        args(65) = New SqlParameter("@FECHAFINEXAMEN", SqlDbType.DateTime)
        args(65).Value = IIf(lEntidad.FECHAFINEXAMEN = Nothing, DBNull.Value, lEntidad.FECHAFINEXAMEN)
        args(66) = New SqlParameter("@IDTITULARADJUDICACION", SqlDbType.Int)
        args(66).Value = IIf(lEntidad.IDTITULARADJUDICACION = Nothing, DBNull.Value, lEntidad.IDTITULARADJUDICACION)
        args(67) = New SqlParameter("@ACTAAPERTURA", SqlDbType.VarChar)
        args(67).Value = IIf(lEntidad.ACTAAPERTURA = Nothing, DBNull.Value, lEntidad.ACTAAPERTURA)
        args(68) = New SqlParameter("@OBSERVACIONESACTA", SqlDbType.VarChar)
        args(68).Value = IIf(lEntidad.OBSERVACIONESACTA = Nothing, DBNull.Value, lEntidad.OBSERVACIONESACTA)
        args(69) = New SqlParameter("@GARANTIAANTICIPOVALOR", SqlDbType.Decimal)
        args(69).Value = lEntidad.GARANTIAANTICIPOVALOR
        args(70) = New SqlParameter("@GARANTIAANTICIPOENTREGAS", SqlDbType.SmallInt)
        args(70).Value = lEntidad.GARANTIAANTICIPOENTREGAS
        args(71) = New SqlParameter("@GARANTIAANTICIPOVIGENCIA", SqlDbType.SmallInt)
        args(71).Value = lEntidad.GARANTIAANTICIPOVIGENCIA
        args(72) = New SqlParameter("@LUGARANTICIPO", SqlDbType.VarChar)
        args(72).Value = IIf(lEntidad.LUGARANTICIPO = Nothing, DBNull.Value, lEntidad.LUGARANTICIPO)
        args(73) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(73).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(74) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(74).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(75) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(75).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(76) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(76).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(77) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(77).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROCESOCOMPRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROCESOCOMPRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDTITULAR = IIf(.Item("IDTITULAR") Is DBNull.Value, Nothing, .Item("IDTITULAR"))
                lEntidad.IDENTIDADSOLICITA = IIf(.Item("IDENTIDADSOLICITA") Is DBNull.Value, Nothing, .Item("IDENTIDADSOLICITA"))
                lEntidad.FECHAENVIONOTA = IIf(.Item("FECHAENVIONOTA") Is DBNull.Value, Nothing, .Item("FECHAENVIONOTA"))
                lEntidad.COSTOBASE = IIf(.Item("COSTOBASE") Is DBNull.Value, Nothing, .Item("COSTOBASE"))
                lEntidad.LUGARAPERTURABASE = IIf(.Item("LUGARAPERTURABASE") Is DBNull.Value, Nothing, .Item("LUGARAPERTURABASE"))
                lEntidad.DIRECCIONAPERTURABASE = IIf(.Item("DIRECCIONAPERTURABASE") Is DBNull.Value, Nothing, .Item("DIRECCIONAPERTURABASE"))
                lEntidad.IDMUNICIPIOAPERTURA = IIf(.Item("IDMUNICIPIOAPERTURA") Is DBNull.Value, Nothing, .Item("IDMUNICIPIOAPERTURA"))
                lEntidad.FECHAHORAINICIOAPERTURA = IIf(.Item("FECHAHORAINICIOAPERTURA") Is DBNull.Value, Nothing, .Item("FECHAHORAINICIOAPERTURA"))
                lEntidad.FECHAHORAFINAPERTURA = IIf(.Item("FECHAHORAFINAPERTURA") Is DBNull.Value, Nothing, .Item("FECHAHORAFINAPERTURA"))
                lEntidad.FECHAREALIZADAAPERTURA = IIf(.Item("FECHAREALIZADAAPERTURA") Is DBNull.Value, Nothing, .Item("FECHAREALIZADAAPERTURA"))
                lEntidad.FECHAPUBLICACION = IIf(.Item("FECHAPUBLICACION") Is DBNull.Value, Nothing, .Item("FECHAPUBLICACION"))
                lEntidad.LUGARRETIROBASE = IIf(.Item("LUGARRETIROBASE") Is DBNull.Value, Nothing, .Item("LUGARRETIROBASE"))
                lEntidad.FECHAHORAINICIORETIRO = IIf(.Item("FECHAHORAINICIORETIRO") Is DBNull.Value, Nothing, .Item("FECHAHORAINICIORETIRO"))
                lEntidad.FECHAHORAFINRETIRO = IIf(.Item("FECHAHORAFINRETIRO") Is DBNull.Value, Nothing, .Item("FECHAHORAFINRETIRO"))
                lEntidad.LUGARRECEPCIONOFERTA = IIf(.Item("LUGARRECEPCIONOFERTA") Is DBNull.Value, Nothing, .Item("LUGARRECEPCIONOFERTA"))
                lEntidad.DIRECCIONRECEPCIONOFERTA = IIf(.Item("DIRECCIONRECEPCIONOFERTA") Is DBNull.Value, Nothing, .Item("DIRECCIONRECEPCIONOFERTA"))
                lEntidad.IDMUNICIPIORECEPCION = IIf(.Item("IDMUNICIPIORECEPCION") Is DBNull.Value, Nothing, .Item("IDMUNICIPIORECEPCION"))
                lEntidad.FECHAHORAINICIORECEPCION = IIf(.Item("FECHAHORAINICIORECEPCION") Is DBNull.Value, Nothing, .Item("FECHAHORAINICIORECEPCION"))
                lEntidad.FECHAHORAFINRECEPCION = IIf(.Item("FECHAHORAFINRECEPCION") Is DBNull.Value, Nothing, .Item("FECHAHORAFINRECEPCION"))
                lEntidad.CODIGOLICITACION = IIf(.Item("CODIGOLICITACION") Is DBNull.Value, Nothing, .Item("CODIGOLICITACION"))
                lEntidad.TITULOLICITACION = IIf(.Item("TITULOLICITACION") Is DBNull.Value, Nothing, .Item("TITULOLICITACION"))
                lEntidad.DESCRIPCIONLICITACION = IIf(.Item("DESCRIPCIONLICITACION") Is DBNull.Value, Nothing, .Item("DESCRIPCIONLICITACION"))
                lEntidad.IDTIPOCOMPRASUGERIDO = IIf(.Item("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, .Item("IDTIPOCOMPRASUGERIDO"))
                lEntidad.IDTIPOCOMPRAEJECUTAR = IIf(.Item("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, .Item("IDTIPOCOMPRAEJECUTAR"))
                lEntidad.IDESTADOPROCESOCOMPRA = IIf(.Item("IDESTADOPROCESOCOMPRA") Is DBNull.Value, Nothing, .Item("IDESTADOPROCESOCOMPRA"))
                lEntidad.IDENCARGADO = IIf(.Item("IDENCARGADO") Is DBNull.Value, Nothing, .Item("IDENCARGADO"))
                lEntidad.IDJEFEUACI = IIf(.Item("IDJEFEUACI") Is DBNull.Value, Nothing, .Item("IDJEFEUACI"))
                lEntidad.FECHAINICIOPROCESOCOMPRA = IIf(.Item("FECHAINICIOPROCESOCOMPRA") Is DBNull.Value, Nothing, .Item("FECHAINICIOPROCESOCOMPRA"))
                lEntidad.FECHAELABORACIONBASE = IIf(.Item("FECHAELABORACIONBASE") Is DBNull.Value, Nothing, .Item("FECHAELABORACIONBASE"))
                lEntidad.FECHAAPROBACIONBASE = IIf(.Item("FECHAAPROBACIONBASE") Is DBNull.Value, Nothing, .Item("FECHAAPROBACIONBASE"))
                lEntidad.FECHAINICIOACLARACIONES = IIf(.Item("FECHAINICIOACLARACIONES") Is DBNull.Value, Nothing, .Item("FECHAINICIOACLARACIONES"))
                lEntidad.FECHAFINACLARACIONES = IIf(.Item("FECHAFINACLARACIONES") Is DBNull.Value, Nothing, .Item("FECHAFINACLARACIONES"))
                lEntidad.FECHAINICIOCONSULTA = IIf(.Item("FECHAINICIOCONSULTA") Is DBNull.Value, Nothing, .Item("FECHAINICIOCONSULTA"))
                lEntidad.FECHAFINCONSULTA = IIf(.Item("FECHAFINCONSULTA") Is DBNull.Value, Nothing, .Item("FECHAFINCONSULTA"))
                lEntidad.PORCENTAJEFINANCIERO = IIf(.Item("PORCENTAJEFINANCIERO") Is DBNull.Value, Nothing, .Item("PORCENTAJEFINANCIERO"))
                lEntidad.PORCENTAJEINDICESOLVENCIA = IIf(.Item("PORCENTAJEINDICESOLVENCIA") Is DBNull.Value, Nothing, .Item("PORCENTAJEINDICESOLVENCIA"))
                lEntidad.PORCENTAJECAPITALTRABAJO = IIf(.Item("PORCENTAJECAPITALTRABAJO") Is DBNull.Value, Nothing, .Item("PORCENTAJECAPITALTRABAJO"))
                lEntidad.PORCENTAJEENDEUDAMIENTO = IIf(.Item("PORCENTAJEENDEUDAMIENTO") Is DBNull.Value, Nothing, .Item("PORCENTAJEENDEUDAMIENTO"))
                lEntidad.PORCENTAJEREFERENCIASBANC = IIf(.Item("PORCENTAJEREFERENCIASBANC") Is DBNull.Value, Nothing, .Item("PORCENTAJEREFERENCIASBANC"))
                lEntidad.GARANTIAMTTOENTREGA = IIf(.Item("GARANTIAMTTOENTREGA") Is DBNull.Value, Nothing, .Item("GARANTIAMTTOENTREGA"))
                lEntidad.GARANTIAMTTOVIGENCIA = IIf(.Item("GARANTIAMTTOVIGENCIA") Is DBNull.Value, Nothing, .Item("GARANTIAMTTOVIGENCIA"))
                lEntidad.LUGARMTTO = IIf(.Item("LUGARMTTO") Is DBNull.Value, Nothing, .Item("LUGARMTTO"))
                lEntidad.GARANTIACUMPLIMIENTOVALOR = IIf(.Item("GARANTIACUMPLIMIENTOVALOR") Is DBNull.Value, Nothing, .Item("GARANTIACUMPLIMIENTOVALOR"))
                lEntidad.GARANTIACUMPLIMIENTOENTREGA = IIf(.Item("GARANTIACUMPLIMIENTOENTREGA") Is DBNull.Value, Nothing, .Item("GARANTIACUMPLIMIENTOENTREGA"))
                lEntidad.GARANTIACUMPLIMIENTOVIGENCIA = IIf(.Item("GARANTIACUMPLIMIENTOVIGENCIA") Is DBNull.Value, Nothing, .Item("GARANTIACUMPLIMIENTOVIGENCIA"))
                lEntidad.LUGARCUMPLIMIENTO = IIf(.Item("LUGARCUMPLIMIENTO") Is DBNull.Value, Nothing, .Item("LUGARCUMPLIMIENTO"))
                lEntidad.GARANTIACALIDADVALOR = IIf(.Item("GARANTIACALIDADVALOR") Is DBNull.Value, Nothing, .Item("GARANTIACALIDADVALOR"))
                lEntidad.GARANTIACALIDADENTREGA = IIf(.Item("GARANTIACALIDADENTREGA") Is DBNull.Value, Nothing, .Item("GARANTIACALIDADENTREGA"))
                lEntidad.GARANTIACALIDADVIGENCIA = IIf(.Item("GARANTIACALIDADVIGENCIA") Is DBNull.Value, Nothing, .Item("GARANTIACALIDADVIGENCIA"))
                lEntidad.LUGARCALIDAD = IIf(.Item("LUGARCALIDAD") Is DBNull.Value, Nothing, .Item("LUGARCALIDAD"))
                lEntidad.FECHAINICIOANALISIS = IIf(.Item("FECHAINICIOANALISIS") Is DBNull.Value, Nothing, .Item("FECHAINICIOANALISIS"))
                lEntidad.FECHAFINANALISIS = IIf(.Item("FECHAFINANALISIS") Is DBNull.Value, Nothing, .Item("FECHAFINANALISIS"))
                lEntidad.FECHAFIRMARESOLUCION = IIf(.Item("FECHAFIRMARESOLUCION") Is DBNull.Value, Nothing, .Item("FECHAFIRMARESOLUCION"))
                lEntidad.NUMERORESOLUCION = IIf(.Item("NUMERORESOLUCION") Is DBNull.Value, Nothing, .Item("NUMERORESOLUCION"))
                lEntidad.FECHALIMITEACEPTACION = IIf(.Item("FECHALIMITEACEPTACION") Is DBNull.Value, Nothing, .Item("FECHALIMITEACEPTACION"))
                lEntidad.FECHANOTIFICACION = IIf(.Item("FECHANOTIFICACION") Is DBNull.Value, Nothing, .Item("FECHANOTIFICACION"))
                lEntidad.FECHAPUBLICACIONRESOLUCION = IIf(.Item("FECHAPUBLICACIONRESOLUCION") Is DBNull.Value, Nothing, .Item("FECHAPUBLICACIONRESOLUCION"))
                lEntidad.MEDIOSDIVULGACION = IIf(.Item("MEDIOSDIVULGACION") Is DBNull.Value, Nothing, .Item("MEDIOSDIVULGACION"))
                lEntidad.FECHAFIRMAACEPTACION = IIf(.Item("FECHAFIRMAACEPTACION") Is DBNull.Value, Nothing, .Item("FECHAFIRMAACEPTACION"))
                lEntidad.VIGENCIACOTIZACION = IIf(.Item("VIGENCIACOTIZACION") Is DBNull.Value, Nothing, .Item("VIGENCIACOTIZACION"))
                lEntidad.GARANTIACUMPLIMIENTOORDENCOMPRA = IIf(.Item("GARANTIACUMPLIMIENTOORDENCOMPRA") Is DBNull.Value, Nothing, .Item("GARANTIACUMPLIMIENTOORDENCOMPRA"))
                lEntidad.TIEMPOENTREGA = IIf(.Item("TIEMPOENTREGA") Is DBNull.Value, Nothing, .Item("TIEMPOENTREGA"))
                lEntidad.FECHAFINRECOMENDACION = IIf(.Item("FECHAFINRECOMENDACION") Is DBNull.Value, Nothing, .Item("FECHAFINRECOMENDACION"))
                lEntidad.FECHAFINEXAMEN = IIf(.Item("FECHAFINEXAMEN") Is DBNull.Value, Nothing, .Item("FECHAFINEXAMEN"))
                lEntidad.IDTITULARADJUDICACION = IIf(.Item("IDTITULARADJUDICACION") Is DBNull.Value, Nothing, .Item("IDTITULARADJUDICACION"))
                lEntidad.ACTAAPERTURA = IIf(.Item("ACTAAPERTURA") Is DBNull.Value, Nothing, .Item("ACTAAPERTURA"))
                lEntidad.OBSERVACIONESACTA = IIf(.Item("OBSERVACIONESACTA") Is DBNull.Value, Nothing, .Item("OBSERVACIONESACTA"))
                lEntidad.GARANTIAANTICIPOVALOR = IIf(.Item("GARANTIAANTICIPOVALOR") Is DBNull.Value, Nothing, .Item("GARANTIAANTICIPOVALOR"))
                lEntidad.GARANTIAANTICIPOENTREGAS = IIf(.Item("GARANTIAANTICIPOENTREGAS") Is DBNull.Value, Nothing, .Item("GARANTIAANTICIPOENTREGAS"))
                lEntidad.GARANTIAANTICIPOVIGENCIA = IIf(.Item("GARANTIAANTICIPOVIGENCIA") Is DBNull.Value, Nothing, .Item("GARANTIAANTICIPOVIGENCIA"))
                lEntidad.LUGARANTICIPO = IIf(.Item("LUGARANTICIPO") Is DBNull.Value, Nothing, .Item("LUGARANTICIPO"))
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

        Dim lEntidad As PROCESOCOMPRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDPROCESOCOMPRA),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32) As listaPROCESOCOMPRAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaPROCESOCOMPRAS

        Try
            Do While dr.Read()
                Dim mEntidad As New PROCESOCOMPRAS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROCESOCOMPRA = IIf(dr("IDPROCESOCOMPRA") Is DBNull.Value, Nothing, dr("IDPROCESOCOMPRA"))
                mEntidad.IDTITULAR = IIf(dr("IDTITULAR") Is DBNull.Value, Nothing, dr("IDTITULAR"))
                mEntidad.IDENTIDADSOLICITA = IIf(dr("IDENTIDADSOLICITA") Is DBNull.Value, Nothing, dr("IDENTIDADSOLICITA"))
                mEntidad.FECHAENVIONOTA = IIf(dr("FECHAENVIONOTA") Is DBNull.Value, Nothing, dr("FECHAENVIONOTA"))
                mEntidad.COSTOBASE = IIf(dr("COSTOBASE") Is DBNull.Value, Nothing, dr("COSTOBASE"))
                mEntidad.LUGARAPERTURABASE = IIf(dr("LUGARAPERTURABASE") Is DBNull.Value, Nothing, dr("LUGARAPERTURABASE"))
                mEntidad.DIRECCIONAPERTURABASE = IIf(dr("DIRECCIONAPERTURABASE") Is DBNull.Value, Nothing, dr("DIRECCIONAPERTURABASE"))
                mEntidad.IDMUNICIPIOAPERTURA = IIf(dr("IDMUNICIPIOAPERTURA") Is DBNull.Value, Nothing, dr("IDMUNICIPIOAPERTURA"))
                mEntidad.FECHAHORAINICIOAPERTURA = IIf(dr("FECHAHORAINICIOAPERTURA") Is DBNull.Value, Nothing, dr("FECHAHORAINICIOAPERTURA"))
                mEntidad.FECHAHORAFINAPERTURA = IIf(dr("FECHAHORAFINAPERTURA") Is DBNull.Value, Nothing, dr("FECHAHORAFINAPERTURA"))
                mEntidad.FECHAREALIZADAAPERTURA = IIf(dr("FECHAREALIZADAAPERTURA") Is DBNull.Value, Nothing, dr("FECHAREALIZADAAPERTURA"))
                mEntidad.FECHAPUBLICACION = IIf(dr("FECHAPUBLICACION") Is DBNull.Value, Nothing, dr("FECHAPUBLICACION"))
                mEntidad.LUGARRETIROBASE = IIf(dr("LUGARRETIROBASE") Is DBNull.Value, Nothing, dr("LUGARRETIROBASE"))
                mEntidad.FECHAHORAINICIORETIRO = IIf(dr("FECHAHORAINICIORETIRO") Is DBNull.Value, Nothing, dr("FECHAHORAINICIORETIRO"))
                mEntidad.FECHAHORAFINRETIRO = IIf(dr("FECHAHORAFINRETIRO") Is DBNull.Value, Nothing, dr("FECHAHORAFINRETIRO"))
                mEntidad.LUGARRECEPCIONOFERTA = IIf(dr("LUGARRECEPCIONOFERTA") Is DBNull.Value, Nothing, dr("LUGARRECEPCIONOFERTA"))
                mEntidad.DIRECCIONRECEPCIONOFERTA = IIf(dr("DIRECCIONRECEPCIONOFERTA") Is DBNull.Value, Nothing, dr("DIRECCIONRECEPCIONOFERTA"))
                mEntidad.IDMUNICIPIORECEPCION = IIf(dr("IDMUNICIPIORECEPCION") Is DBNull.Value, Nothing, dr("IDMUNICIPIORECEPCION"))
                mEntidad.FECHAHORAINICIORECEPCION = IIf(dr("FECHAHORAINICIORECEPCION") Is DBNull.Value, Nothing, dr("FECHAHORAINICIORECEPCION"))
                mEntidad.FECHAHORAFINRECEPCION = IIf(dr("FECHAHORAFINRECEPCION") Is DBNull.Value, Nothing, dr("FECHAHORAFINRECEPCION"))
                mEntidad.CODIGOLICITACION = IIf(dr("CODIGOLICITACION") Is DBNull.Value, Nothing, dr("CODIGOLICITACION"))
                mEntidad.TITULOLICITACION = IIf(dr("TITULOLICITACION") Is DBNull.Value, Nothing, dr("TITULOLICITACION"))
                mEntidad.DESCRIPCIONLICITACION = IIf(dr("DESCRIPCIONLICITACION") Is DBNull.Value, Nothing, dr("DESCRIPCIONLICITACION"))
                mEntidad.IDTIPOCOMPRASUGERIDO = IIf(dr("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASUGERIDO"))
                mEntidad.IDTIPOCOMPRAEJECUTAR = IIf(dr("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRAEJECUTAR"))
                mEntidad.IDESTADOPROCESOCOMPRA = IIf(dr("IDESTADOPROCESOCOMPRA") Is DBNull.Value, Nothing, dr("IDESTADOPROCESOCOMPRA"))
                mEntidad.IDENCARGADO = IIf(dr("IDENCARGADO") Is DBNull.Value, Nothing, dr("IDENCARGADO"))
                mEntidad.IDJEFEUACI = IIf(dr("IDJEFEUACI") Is DBNull.Value, Nothing, dr("IDJEFEUACI"))
                mEntidad.FECHAINICIOPROCESOCOMPRA = IIf(dr("FECHAINICIOPROCESOCOMPRA") Is DBNull.Value, Nothing, dr("FECHAINICIOPROCESOCOMPRA"))
                mEntidad.FECHAELABORACIONBASE = IIf(dr("FECHAELABORACIONBASE") Is DBNull.Value, Nothing, dr("FECHAELABORACIONBASE"))
                mEntidad.FECHAAPROBACIONBASE = IIf(dr("FECHAAPROBACIONBASE") Is DBNull.Value, Nothing, dr("FECHAAPROBACIONBASE"))
                mEntidad.FECHAINICIOACLARACIONES = IIf(dr("FECHAINICIOACLARACIONES") Is DBNull.Value, Nothing, dr("FECHAINICIOACLARACIONES"))
                mEntidad.FECHAFINACLARACIONES = IIf(dr("FECHAFINACLARACIONES") Is DBNull.Value, Nothing, dr("FECHAFINACLARACIONES"))
                mEntidad.FECHAINICIOCONSULTA = IIf(dr("FECHAINICIOCONSULTA") Is DBNull.Value, Nothing, dr("FECHAINICIOCONSULTA"))
                mEntidad.FECHAFINCONSULTA = IIf(dr("FECHAFINCONSULTA") Is DBNull.Value, Nothing, dr("FECHAFINCONSULTA"))
                mEntidad.PORCENTAJEFINANCIERO = IIf(dr("PORCENTAJEFINANCIERO") Is DBNull.Value, Nothing, dr("PORCENTAJEFINANCIERO"))
                mEntidad.PORCENTAJEINDICESOLVENCIA = IIf(dr("PORCENTAJEINDICESOLVENCIA") Is DBNull.Value, Nothing, dr("PORCENTAJEINDICESOLVENCIA"))
                mEntidad.PORCENTAJECAPITALTRABAJO = IIf(dr("PORCENTAJECAPITALTRABAJO") Is DBNull.Value, Nothing, dr("PORCENTAJECAPITALTRABAJO"))
                mEntidad.PORCENTAJEENDEUDAMIENTO = IIf(dr("PORCENTAJEENDEUDAMIENTO") Is DBNull.Value, Nothing, dr("PORCENTAJEENDEUDAMIENTO"))
                mEntidad.PORCENTAJEREFERENCIASBANC = IIf(dr("PORCENTAJEREFERENCIASBANC") Is DBNull.Value, Nothing, dr("PORCENTAJEREFERENCIASBANC"))
                mEntidad.GARANTIAMTTOENTREGA = IIf(dr("GARANTIAMTTOENTREGA") Is DBNull.Value, Nothing, dr("GARANTIAMTTOENTREGA"))
                mEntidad.GARANTIAMTTOVIGENCIA = IIf(dr("GARANTIAMTTOVIGENCIA") Is DBNull.Value, Nothing, dr("GARANTIAMTTOVIGENCIA"))
                mEntidad.LUGARMTTO = IIf(dr("LUGARMTTO") Is DBNull.Value, Nothing, dr("LUGARMTTO"))
                mEntidad.GARANTIACUMPLIMIENTOVALOR = IIf(dr("GARANTIACUMPLIMIENTOVALOR") Is DBNull.Value, Nothing, dr("GARANTIACUMPLIMIENTOVALOR"))
                mEntidad.GARANTIACUMPLIMIENTOENTREGA = IIf(dr("GARANTIACUMPLIMIENTOENTREGA") Is DBNull.Value, Nothing, dr("GARANTIACUMPLIMIENTOENTREGA"))
                mEntidad.GARANTIACUMPLIMIENTOVIGENCIA = IIf(dr("GARANTIACUMPLIMIENTOVIGENCIA") Is DBNull.Value, Nothing, dr("GARANTIACUMPLIMIENTOVIGENCIA"))
                mEntidad.LUGARCUMPLIMIENTO = IIf(dr("LUGARCUMPLIMIENTO") Is DBNull.Value, Nothing, dr("LUGARCUMPLIMIENTO"))
                mEntidad.GARANTIACALIDADVALOR = IIf(dr("GARANTIACALIDADVALOR") Is DBNull.Value, Nothing, dr("GARANTIACALIDADVALOR"))
                mEntidad.GARANTIACALIDADENTREGA = IIf(dr("GARANTIACALIDADENTREGA") Is DBNull.Value, Nothing, dr("GARANTIACALIDADENTREGA"))
                mEntidad.GARANTIACALIDADVIGENCIA = IIf(dr("GARANTIACALIDADVIGENCIA") Is DBNull.Value, Nothing, dr("GARANTIACALIDADVIGENCIA"))
                mEntidad.LUGARCALIDAD = IIf(dr("LUGARCALIDAD") Is DBNull.Value, Nothing, dr("LUGARCALIDAD"))
                mEntidad.FECHAINICIOANALISIS = IIf(dr("FECHAINICIOANALISIS") Is DBNull.Value, Nothing, dr("FECHAINICIOANALISIS"))
                mEntidad.FECHAFINANALISIS = IIf(dr("FECHAFINANALISIS") Is DBNull.Value, Nothing, dr("FECHAFINANALISIS"))
                mEntidad.FECHAFIRMARESOLUCION = IIf(dr("FECHAFIRMARESOLUCION") Is DBNull.Value, Nothing, dr("FECHAFIRMARESOLUCION"))
                mEntidad.NUMERORESOLUCION = IIf(dr("NUMERORESOLUCION") Is DBNull.Value, Nothing, dr("NUMERORESOLUCION"))
                mEntidad.FECHALIMITEACEPTACION = IIf(dr("FECHALIMITEACEPTACION") Is DBNull.Value, Nothing, dr("FECHALIMITEACEPTACION"))
                mEntidad.FECHANOTIFICACION = IIf(dr("FECHANOTIFICACION") Is DBNull.Value, Nothing, dr("FECHANOTIFICACION"))
                mEntidad.FECHAPUBLICACIONRESOLUCION = IIf(dr("FECHAPUBLICACIONRESOLUCION") Is DBNull.Value, Nothing, dr("FECHAPUBLICACIONRESOLUCION"))
                mEntidad.MEDIOSDIVULGACION = IIf(dr("MEDIOSDIVULGACION") Is DBNull.Value, Nothing, dr("MEDIOSDIVULGACION"))
                mEntidad.FECHAFIRMAACEPTACION = IIf(dr("FECHAFIRMAACEPTACION") Is DBNull.Value, Nothing, dr("FECHAFIRMAACEPTACION"))
                mEntidad.VIGENCIACOTIZACION = IIf(dr("VIGENCIACOTIZACION") Is DBNull.Value, Nothing, dr("VIGENCIACOTIZACION"))
                mEntidad.GARANTIACUMPLIMIENTOORDENCOMPRA = IIf(dr("GARANTIACUMPLIMIENTOORDENCOMPRA") Is DBNull.Value, Nothing, dr("GARANTIACUMPLIMIENTOORDENCOMPRA"))
                mEntidad.TIEMPOENTREGA = IIf(dr("TIEMPOENTREGA") Is DBNull.Value, Nothing, dr("TIEMPOENTREGA"))
                mEntidad.FECHAFINRECOMENDACION = IIf(dr("FECHAFINRECOMENDACION") Is DBNull.Value, Nothing, dr("FECHAFINRECOMENDACION"))
                mEntidad.FECHAFINEXAMEN = IIf(dr("FECHAFINEXAMEN") Is DBNull.Value, Nothing, dr("FECHAFINEXAMEN"))
                mEntidad.IDTITULARADJUDICACION = IIf(dr("IDTITULARADJUDICACION") Is DBNull.Value, Nothing, dr("IDTITULARADJUDICACION"))
                mEntidad.ACTAAPERTURA = IIf(dr("ACTAAPERTURA") Is DBNull.Value, Nothing, dr("ACTAAPERTURA"))
                mEntidad.OBSERVACIONESACTA = IIf(dr("OBSERVACIONESACTA") Is DBNull.Value, Nothing, dr("OBSERVACIONESACTA"))
                mEntidad.GARANTIAANTICIPOVALOR = IIf(dr("GARANTIAANTICIPOVALOR") Is DBNull.Value, Nothing, dr("GARANTIAANTICIPOVALOR"))
                mEntidad.GARANTIAANTICIPOENTREGAS = IIf(dr("GARANTIAANTICIPOENTREGAS") Is DBNull.Value, Nothing, dr("GARANTIAANTICIPOENTREGAS"))
                mEntidad.GARANTIAANTICIPOVIGENCIA = IIf(dr("GARANTIAANTICIPOVIGENCIA") Is DBNull.Value, Nothing, dr("GARANTIAANTICIPOVIGENCIA"))
                mEntidad.LUGARANTICIPO = IIf(dr("LUGARANTICIPO") Is DBNull.Value, Nothing, dr("LUGARANTICIPO"))
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
        tables(0) = New String("PROCESOCOMPRAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Public Function ObtenerDataSetPorHabilitaModDistr(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO and HabilitaModDistr=1")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim tables(0) As String
        tables(0) = New String("PROCESOCOMPRAS")
        Dim ds As New DataSet
        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return ds

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDTITULAR, ")
        strSQL.Append(" IDENTIDADSOLICITA, ")
        strSQL.Append(" FECHAENVIONOTA, ")
        strSQL.Append(" COSTOBASE, ")
        strSQL.Append(" LUGARAPERTURABASE, ")
        strSQL.Append(" DIRECCIONAPERTURABASE, ")
        strSQL.Append(" IDMUNICIPIOAPERTURA, ")
        strSQL.Append(" FECHAHORAINICIOAPERTURA, ")
        strSQL.Append(" FECHAHORAFINAPERTURA, ")
        strSQL.Append(" FECHAREALIZADAAPERTURA, ")
        strSQL.Append(" FECHAPUBLICACION, ")
        strSQL.Append(" LUGARRETIROBASE, ")
        strSQL.Append(" FECHAHORAINICIORETIRO, ")
        strSQL.Append(" FECHAHORAFINRETIRO, ")
        strSQL.Append(" LUGARRECEPCIONOFERTA, ")
        strSQL.Append(" DIRECCIONRECEPCIONOFERTA, ")
        strSQL.Append(" IDMUNICIPIORECEPCION, ")
        strSQL.Append(" FECHAHORAINICIORECEPCION, ")
        strSQL.Append(" FECHAHORAFINRECEPCION, ")
        strSQL.Append(" CODIGOLICITACION, ")
        strSQL.Append(" TITULOLICITACION, ")
        strSQL.Append(" DESCRIPCIONLICITACION, ")
        strSQL.Append(" IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" IDESTADOPROCESOCOMPRA, ")
        strSQL.Append(" IDENCARGADO, ")
        strSQL.Append(" IDJEFEUACI, ")
        strSQL.Append(" FECHAINICIOPROCESOCOMPRA, ")
        strSQL.Append(" FECHAELABORACIONBASE, ")
        strSQL.Append(" FECHAAPROBACIONBASE, ")
        strSQL.Append(" FECHAINICIOACLARACIONES, ")
        strSQL.Append(" FECHAFINACLARACIONES, ")
        strSQL.Append(" FECHAINICIOCONSULTA, ")
        strSQL.Append(" FECHAFINCONSULTA, ")
        strSQL.Append(" PORCENTAJEFINANCIERO, ")
        strSQL.Append(" PORCENTAJEINDICESOLVENCIA, ")
        strSQL.Append(" PORCENTAJECAPITALTRABAJO, ")
        strSQL.Append(" PORCENTAJEENDEUDAMIENTO, ")
        strSQL.Append(" PORCENTAJEREFERENCIASBANC, ")
        strSQL.Append(" GARANTIAMTTOENTREGA, ")
        strSQL.Append(" GARANTIAMTTOVIGENCIA, ")
        strSQL.Append(" LUGARMTTO, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOVALOR, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOENTREGA, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOVIGENCIA, ")
        strSQL.Append(" LUGARCUMPLIMIENTO, ")
        strSQL.Append(" GARANTIACALIDADVALOR, ")
        strSQL.Append(" GARANTIACALIDADENTREGA, ")
        strSQL.Append(" GARANTIACALIDADVIGENCIA, ")
        strSQL.Append(" LUGARCALIDAD, ")
        strSQL.Append(" FECHAINICIOANALISIS, ")
        strSQL.Append(" FECHAFINANALISIS, ")
        strSQL.Append(" FECHAFIRMARESOLUCION, ")
        strSQL.Append(" NUMERORESOLUCION, ")
        strSQL.Append(" FECHALIMITEACEPTACION, ")
        strSQL.Append(" FECHANOTIFICACION, ")
        strSQL.Append(" FECHAPUBLICACIONRESOLUCION, ")
        strSQL.Append(" MEDIOSDIVULGACION, ")
        strSQL.Append(" FECHAFIRMAACEPTACION, ")
        strSQL.Append(" VIGENCIACOTIZACION, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOORDENCOMPRA, ")
        strSQL.Append(" TIEMPOENTREGA, ")
        strSQL.Append(" FECHAFINRECOMENDACION, ")
        strSQL.Append(" FECHAFINEXAMEN, ")
        strSQL.Append(" IDTITULARADJUDICACION, ")
        strSQL.Append(" ACTAAPERTURA, ")
        strSQL.Append(" OBSERVACIONESACTA, ")
        strSQL.Append(" GARANTIAANTICIPOVALOR, ")
        strSQL.Append(" GARANTIAANTICIPOENTREGAS, ")
        strSQL.Append(" GARANTIAANTICIPOVIGENCIA, ")
        strSQL.Append(" LUGARANTICIPO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" HabilitaModDistr ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS ")

    End Sub

#End Region

End Class
