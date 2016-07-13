Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbINFORMEMUESTRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_LAB_INFORMEMUESTRAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	04/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbINFORMEMUESTRAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INFORMEMUESTRAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDINFORME = 0 _
            Or lEntidad.IDINFORME = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDINFORME = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append(" SET IDTIPOINFORME = @IDTIPOINFORME, ")
        strSQL.Append(" NUMEROINFORME = @NUMEROINFORME, ")
        strSQL.Append(" IDESTADO = @IDESTADO, ")
        strSQL.Append(" IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTOCONTRATO, ")
        strSQL.Append(" IDPROVEEDOR = @IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO = @IDCONTRATO, ")
        strSQL.Append(" RENGLON = @RENGLON, ")
        strSQL.Append(" NOMBREMEDICAMENTO = @NOMBREMEDICAMENTO, ")
        strSQL.Append(" NOMBRECOMERCIAL = @NOMBRECOMERCIAL, ")
        strSQL.Append(" LABORATORIOFABRICANTE = @LABORATORIOFABRICANTE, ")
        strSQL.Append(" PROVEEDOR = @PROVEEDOR, ")
        strSQL.Append(" LOTE = @LOTE, ")
        strSQL.Append(" FECHAFABRICACION = @FECHAFABRICACION, ")
        strSQL.Append(" FECHAVENCIMIENTO = @FECHAVENCIMIENTO, ")
        strSQL.Append(" NUMEROUNIDADES = @NUMEROUNIDADES, ")
        strSQL.Append(" CANTIDADREMITIDA = @CANTIDADREMITIDA, ")
        strSQL.Append(" ESTABLECIMIENTOREMITE = @ESTABLECIMIENTOREMITE, ")
        strSQL.Append(" NUMERORECEPCION = @NUMERORECEPCION, ")
        strSQL.Append(" GUIAAEREA = @GUIAAEREA, ")
        strSQL.Append(" DESCRIPCIONEMPAQUE = @DESCRIPCIONEMPAQUE, ")
        strSQL.Append(" LEYENDAREQUERIDA = @LEYENDAREQUERIDA, ")
        strSQL.Append(" NUMEROREGISTRO = @NUMEROREGISTRO, ")
        strSQL.Append(" VIAADMINISTRACION = @VIAADMINISTRACION, ")
        strSQL.Append(" FORMADISOLUCION = @FORMADISOLUCION, ")
        strSQL.Append(" CONDICIONESALMACENAMIENTO = @CONDICIONESALMACENAMIENTO, ")
        strSQL.Append(" NUMEROLOTE = @NUMEROLOTE, ")
        strSQL.Append(" FECHAEXPIRACION = @FECHAEXPIRACION, ")
        strSQL.Append(" OTROSEMPAQUES = @OTROSEMPAQUES, ")
        strSQL.Append(" DESCRIPCIONOTROSEMPAQUES = @DESCRIPCIONOTROSEMPAQUES, ")
        strSQL.Append(" DESCRIPCIONPRODUCTO = @DESCRIPCIONPRODUCTO, ")
        strSQL.Append(" CANTIDADFISICOQUIMICO = @CANTIDADFISICOQUIMICO, ")
        strSQL.Append(" CANTIDADMICROBIOLOGIA = @CANTIDADMICROBIOLOGIA, ")
        strSQL.Append(" CANTIDADRETENCION = @CANTIDADRETENCION, ")
        strSQL.Append(" DESCRIPCIONCONDICIONESALMACENAMIENTO = @DESCRIPCIONCONDICIONESALMACENAMIENTO, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" IDINSPECTOR = @IDINSPECTOR, ")
        strSQL.Append(" FECHAELABORACIONINFORME = @FECHAELABORACIONINFORME, ")
        strSQL.Append(" IDCOORDINADOR = @IDCOORDINADOR, ")
        strSQL.Append(" MOTIVOSNOINSPECCION = @MOTIVOSNOINSPECCION, ")
        strSQL.Append(" FECHACERTIFICACION = @FECHACERTIFICACION, ")
        strSQL.Append(" FECHASOLICITUDINSPECCION = @FECHASOLICITUDINSPECCION, ")
        strSQL.Append(" FECHARECOLECCIONMUESTRA = @FECHARECOLECCIONMUESTRA, ")
        strSQL.Append(" OBSERVACIONCERTIFICACION = @OBSERVACIONCERTIFICACION, ")
        strSQL.Append(" IDJEFELABORATORIO = @IDJEFELABORATORIO, ")
        strSQL.Append(" REPRESENTANTEPROVEEDOR = @REPRESENTANTEPROVEEDOR, ")
        strSQL.Append(" RESULTADOINSPECCION = @RESULTADOINSPECCION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA, ")
        strSQL.Append(" ORIGENPRODUCTO = @ORIGENPRODUCTO, ")
        strSQL.Append(" TIPOPRODUCTO = @TIPOPRODUCTO, ")
        strSQL.Append(" MOTIVONOACEPTACION = @MOTIVOSNOACEPTACION, ")
        strSQL.Append(" COMPROBANTECREDITOFISCAL = @COMPROBANTECREDITOFISCAL, ")
        strSQL.Append(" NUMEROEMPAQUEPRIMARIO = @NUMEROEMPAQUEPRIMARIO, ")
        strSQL.Append(" NUMEROEMPAQUESECUNDARIO = @NUMEROEMPAQUESECUNDARIO, ")
        strSQL.Append(" DESCRIPCIONEMPAQUESECUNDARIO = @DESCRIPCIONEMPAQUESECUNDARIO, ")
        strSQL.Append(" NUMEROEMPAQUECOLECTIVO = @NUMEROEMPAQUECOLECTIVO, ")
        strSQL.Append(" DESCRIPCIONEMPAQUECOLECTIVO = @DESCRIPCIONEMPAQUECOLECTIVO, ")
        strSQL.Append(" CONDICIONESALMACENAMIENTORECOMENDADAS = @CONDICIONESALMACENAMIENTORECOMENDADAS, ")
        strSQL.Append(" NIVELINSPECCIONUTILIZABLE = @NIVELINSPECCIONUTILIZABLE, ")
        strSQL.Append(" NUMEROUNIDADESAMUESTREAR = @NUMEROUNIDADESAMUESTREAR, ")
        strSQL.Append(" NIVELCALIDADACEPTABLE = @NIVELCALIDADACEPTABLE, ")
        strSQL.Append(" RANGOACEPTACIONRECHAZO = @RANGOACEPTACIONRECHAZO, ")
        strSQL.Append(" CALCULOS = @CALCULOS, ")
        strSQL.Append(" DESCRIPCIONDISOLUCION = @DESCRIPCIONDISOLUCION, ")
        strSQL.Append(" FECHANOTIFICACION = @FECHANOTIFICACION, ")
        strSQL.Append(" NUMERONOTIFICACION = @NUMERONOTIFICACION, ")
        strSQL.Append(" CANTIDADAENTREGAR = @CANTIDADAENTREGAR, ")
        strSQL.Append(" IDPROCESOCOMPRA = @IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPRODUCTO = @IDPRODUCTO, ")
        strSQL.Append(" OBSERVACIONLEYENDA = @OBSERVACIONLEYENDA, ")
        strSQL.Append(" OBSERVACIONNREGISTRO = @OBSERVACIONNREGISTRO, ")
        strSQL.Append(" OBSERVACIONVIAADMON = @OBSERVACIONVIAADMON, ")
        strSQL.Append(" OBSERVACIONCONDIALMA = @OBSERVACIONCONDIALMA, ")
        strSQL.Append(" OBSERVACIONNLOTE = @OBSERVACIONNLOTE, ")
        strSQL.Append(" OBSERVACIONFECHAEXP = @OBSERVACIONFECHAEXP, ")
        strSQL.Append(" LUGARINSPECCION = @LUGARINSPECCION, ")
        strSQL.Append(" PAGOANALISIS = @PAGOANALISIS, ")
        'A PETICION DE LAB.CONTROL SE ADICIONA CAMPO Y SE GUARDA, Mayra Martínez Cárcamo, 22 de junio 2011
        strSQL.Append(" NOMBREINSPECCION = @NOMBREINSPECCION ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDINFORME = @IDINFORME ")

        Dim args(82) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOINFORME", SqlDbType.SmallInt)
        args(0).Value = lEntidad.IDTIPOINFORME
        args(1) = New SqlParameter("@NUMEROINFORME", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.NUMEROINFORME = Nothing, DBNull.Value, lEntidad.NUMEROINFORME)
        args(2) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(2).Value = lEntidad.IDESTADO
        args(3) = New SqlParameter("@IDESTABLECIMIENTOCONTRATO", SqlDbType.Int)
        args(3).Value = lEntidad.IDESTABLECIMIENTOCONTRATO
        args(4) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(4).Value = lEntidad.IDPROVEEDOR
        args(5) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(5).Value = lEntidad.IDCONTRATO
        args(6) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(6).Value = lEntidad.RENGLON
        args(7) = New SqlParameter("@NOMBREMEDICAMENTO", SqlDbType.VarChar)
        args(7).Value = lEntidad.NOMBREMEDICAMENTO
        args(8) = New SqlParameter("@NOMBRECOMERCIAL", SqlDbType.VarChar)
        args(8).Value = lEntidad.NOMBRECOMERCIAL
        args(9) = New SqlParameter("@LABORATORIOFABRICANTE", SqlDbType.VarChar)
        args(9).Value = lEntidad.LABORATORIOFABRICANTE
        args(10) = New SqlParameter("@PROVEEDOR", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.PROVEEDOR = Nothing, DBNull.Value, lEntidad.PROVEEDOR)
        args(11) = New SqlParameter("@LOTE", SqlDbType.VarChar)
        args(11).Value = lEntidad.LOTE
        args(12) = New SqlParameter("@FECHAFABRICACION", SqlDbType.DateTime)
        args(12).Value = lEntidad.FECHAFABRICACION
        args(13) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(13).Value = lEntidad.FECHAVENCIMIENTO
        args(14) = New SqlParameter("@NUMEROUNIDADES", SqlDbType.Decimal)
        args(14).Value = lEntidad.NUMEROUNIDADES
        args(15) = New SqlParameter("@CANTIDADREMITIDA", SqlDbType.Decimal)
        args(15).Value = lEntidad.CANTIDADREMITIDA
        args(16) = New SqlParameter("@ESTABLECIMIENTOREMITE", SqlDbType.VarChar)
        args(16).Value = lEntidad.ESTABLECIMIENTOREMITE
        args(17) = New SqlParameter("@NUMERORECEPCION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.NUMERORECEPCION = Nothing, DBNull.Value, lEntidad.NUMERORECEPCION)
        args(18) = New SqlParameter("@GUIAAEREA", SqlDbType.VarChar)
        args(18).Value = IIf(lEntidad.GUIAAEREA = Nothing, DBNull.Value, lEntidad.GUIAAEREA)
        args(19) = New SqlParameter("@DESCRIPCIONEMPAQUE", SqlDbType.VarChar)
        args(19).Value = IIf(lEntidad.DESCRIPCIONEMPAQUE = Nothing, DBNull.Value, lEntidad.DESCRIPCIONEMPAQUE)
        args(20) = New SqlParameter("@LEYENDAREQUERIDA", SqlDbType.TinyInt)
        args(20).Value = lEntidad.LEYENDAREQUERIDA
        args(21) = New SqlParameter("@NUMEROREGISTRO", SqlDbType.TinyInt)
        args(21).Value = lEntidad.NUMEROREGISTRO
        args(22) = New SqlParameter("@VIAADMINISTRACION", SqlDbType.TinyInt)
        args(22).Value = lEntidad.VIAADMINISTRACION
        args(23) = New SqlParameter("@FORMADISOLUCION", SqlDbType.TinyInt)
        args(23).Value = lEntidad.FORMADISOLUCION
        args(24) = New SqlParameter("@CONDICIONESALMACENAMIENTO", SqlDbType.TinyInt)
        args(24).Value = lEntidad.CONDICIONESALMACENAMIENTO
        args(25) = New SqlParameter("@NUMEROLOTE", SqlDbType.TinyInt)
        args(25).Value = lEntidad.NUMEROLOTE
        args(26) = New SqlParameter("@FECHAEXPIRACION", SqlDbType.TinyInt)
        args(26).Value = lEntidad.FECHAEXPIRACION
        args(27) = New SqlParameter("@OTROSEMPAQUES", SqlDbType.TinyInt)
        args(27).Value = lEntidad.OTROSEMPAQUES
        args(28) = New SqlParameter("@DESCRIPCIONOTROSEMPAQUES", SqlDbType.VarChar)
        args(28).Value = IIf(lEntidad.DESCRIPCIONOTROSEMPAQUES = Nothing, DBNull.Value, lEntidad.DESCRIPCIONOTROSEMPAQUES)
        args(29) = New SqlParameter("@DESCRIPCIONPRODUCTO", SqlDbType.VarChar)
        args(29).Value = IIf(lEntidad.DESCRIPCIONPRODUCTO = Nothing, DBNull.Value, lEntidad.DESCRIPCIONPRODUCTO)
        args(30) = New SqlParameter("@CANTIDADFISICOQUIMICO", SqlDbType.Decimal)
        args(30).Value = lEntidad.CANTIDADFISICOQUIMICO
        args(31) = New SqlParameter("@CANTIDADMICROBIOLOGIA", SqlDbType.Decimal)
        args(31).Value = lEntidad.CANTIDADMICROBIOLOGIA
        args(32) = New SqlParameter("@CANTIDADRETENCION", SqlDbType.Decimal)
        args(32).Value = lEntidad.CANTIDADRETENCION
        args(33) = New SqlParameter("@DESCRIPCIONCONDICIONESALMACENAMIENTO", SqlDbType.VarChar)
        args(33).Value = IIf(lEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO = Nothing, DBNull.Value, lEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO)
        args(34) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(34).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(35) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
        args(35).Value = IIf(lEntidad.IDINSPECTOR = 0, DBNull.Value, lEntidad.IDINSPECTOR)
        args(36) = New SqlParameter("@FECHAELABORACIONINFORME", SqlDbType.DateTime)
        args(36).Value = lEntidad.FECHAELABORACIONINFORME
        args(37) = New SqlParameter("@IDCOORDINADOR", SqlDbType.Int)
        args(37).Value = IIf(lEntidad.IDCOORDINADOR = Nothing, DBNull.Value, lEntidad.IDCOORDINADOR)
        args(38) = New SqlParameter("@MOTIVOSNOINSPECCION", SqlDbType.VarChar)
        args(38).Value = IIf(lEntidad.MOTIVOSNOINSPECCION = Nothing, DBNull.Value, lEntidad.MOTIVOSNOINSPECCION)
        args(39) = New SqlParameter("@FECHACERTIFICACION", SqlDbType.DateTime)
        args(39).Value = IIf(lEntidad.FECHACERTIFICACION = Nothing, DBNull.Value, lEntidad.FECHACERTIFICACION)
        args(40) = New SqlParameter("@FECHASOLICITUDINSPECCION", SqlDbType.DateTime)
        args(40).Value = IIf(lEntidad.FECHASOLICITUDINSPECCION = Nothing, DBNull.Value, lEntidad.FECHASOLICITUDINSPECCION)
        args(41) = New SqlParameter("@FECHARECOLECCIONMUESTRA", SqlDbType.DateTime)
        args(41).Value = IIf(lEntidad.FECHARECOLECCIONMUESTRA = Nothing, DBNull.Value, lEntidad.FECHARECOLECCIONMUESTRA)
        args(42) = New SqlParameter("@OBSERVACIONCERTIFICACION", SqlDbType.VarChar)
        args(42).Value = IIf(lEntidad.OBSERVACIONCERTIFICACION = Nothing, DBNull.Value, lEntidad.OBSERVACIONCERTIFICACION)
        args(43) = New SqlParameter("@IDJEFELABORATORIO", SqlDbType.Int)
        args(43).Value = IIf(lEntidad.IDJEFELABORATORIO = Nothing, DBNull.Value, lEntidad.IDJEFELABORATORIO)
        args(44) = New SqlParameter("@REPRESENTANTEPROVEEDOR", SqlDbType.VarChar)
        args(44).Value = IIf(lEntidad.REPRESENTANTEPROVEEDOR = Nothing, DBNull.Value, lEntidad.REPRESENTANTEPROVEEDOR)
        args(45) = New SqlParameter("@RESULTADOINSPECCION", SqlDbType.TinyInt)
        args(45).Value = IIf(lEntidad.RESULTADOINSPECCION = Nothing, DBNull.Value, lEntidad.RESULTADOINSPECCION)
        args(46) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(46).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(47) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(47).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(48) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(48).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(49) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(49).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(50) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(50).Value = lEntidad.ESTASINCRONIZADA
        args(51) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(51).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(52) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(52).Value = IIf(lEntidad.IDINFORME = Nothing, DBNull.Value, lEntidad.IDINFORME)
        args(53) = New SqlParameter("@ORIGENPRODUCTO", SqlDbType.Int)
        args(53).Value = lEntidad.ORIGENPRODUCTO
        args(54) = New SqlParameter("@TIPOPRODUCTO", SqlDbType.Int)
        args(54).Value = lEntidad.TIPOPRODUCTO
        args(55) = New SqlParameter("@MOTIVOSNOACEPTACION", SqlDbType.Text)
        args(55).Value = IIf(lEntidad.MOTIVONOACEPTACION = Nothing, DBNull.Value, lEntidad.MOTIVONOACEPTACION)
        args(56) = New SqlParameter("@DESCRIPCIONDISOLUCION", SqlDbType.Text)
        args(56).Value = IIf(lEntidad.DESCRIPCIONDISOLUCION = Nothing, DBNull.Value, lEntidad.DESCRIPCIONDISOLUCION)
        args(57) = New SqlParameter("@COMPROBANTECREDITOFISCAL", SqlDbType.VarChar)
        args(57).Value = IIf(lEntidad.COMPROBANTECREDITOFISCAL = Nothing, DBNull.Value, lEntidad.COMPROBANTECREDITOFISCAL)
        args(58) = New SqlParameter("@NUMEROEMPAQUEPRIMARIO", SqlDbType.VarChar)
        args(58).Value = IIf(lEntidad.NUMEROEMPAQUEPRIMARIO = Nothing, DBNull.Value, lEntidad.NUMEROEMPAQUEPRIMARIO)
        args(59) = New SqlParameter("@NUMEROEMPAQUESECUNDARIO", SqlDbType.VarChar)
        args(59).Value = IIf(lEntidad.NUMEROEMPAQUESECUNDARIO = Nothing, DBNull.Value, lEntidad.NUMEROEMPAQUESECUNDARIO)
        args(60) = New SqlParameter("@DESCRIPCIONEMPAQUESECUNDARIO", SqlDbType.VarChar)
        args(60).Value = IIf(lEntidad.DESCRIPCIONEMPAQUESECUNDARIO = Nothing, DBNull.Value, lEntidad.DESCRIPCIONEMPAQUESECUNDARIO)
        args(61) = New SqlParameter("@NUMEROEMPAQUECOLECTIVO", SqlDbType.VarChar)
        args(61).Value = IIf(lEntidad.NUMEROEMPAQUECOLECTIVO = Nothing, DBNull.Value, lEntidad.NUMEROEMPAQUECOLECTIVO)
        args(62) = New SqlParameter("@DESCRIPCIONEMPAQUECOLECTIVO", SqlDbType.VarChar)
        args(62).Value = IIf(lEntidad.DESCRIPCIONEMPAQUECOLECTIVO = Nothing, DBNull.Value, lEntidad.DESCRIPCIONEMPAQUECOLECTIVO)
        args(63) = New SqlParameter("@CONDICIONESALMACENAMIENTORECOMENDADAS", SqlDbType.VarChar)
        args(63).Value = IIf(lEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS = Nothing, DBNull.Value, lEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS)
        args(64) = New SqlParameter("@NIVELINSPECCIONUTILIZABLE", SqlDbType.Int)
        args(64).Value = IIf(lEntidad.NIVELINSPECCIONUTILIZABLE = Nothing, DBNull.Value, lEntidad.NIVELINSPECCIONUTILIZABLE)
        args(65) = New SqlParameter("@NUMEROUNIDADESAMUESTREAR", SqlDbType.Int)
        args(65).Value = IIf(lEntidad.NUMEROUNIDADESAMUESTREAR = Nothing, DBNull.Value, lEntidad.NUMEROUNIDADESAMUESTREAR)
        args(66) = New SqlParameter("@NIVELCALIDADACEPTABLE", SqlDbType.VarChar)
        args(66).Value = IIf(lEntidad.NIVELCALIDADACEPTABLE = Nothing, DBNull.Value, lEntidad.NIVELCALIDADACEPTABLE)
        args(67) = New SqlParameter("@RANGOACEPTACIONRECHAZO", SqlDbType.VarChar)
        args(67).Value = IIf(lEntidad.RANGOACEPTACIONRECHAZO = Nothing, DBNull.Value, lEntidad.RANGOACEPTACIONRECHAZO)
        args(68) = New SqlParameter("@CALCULOS", SqlDbType.VarChar)
        args(68).Value = IIf(lEntidad.CALCULOS = Nothing, DBNull.Value, lEntidad.CALCULOS)
        args(69) = New SqlParameter("@FECHANOTIFICACION", SqlDbType.DateTime)
        args(69).Value = IIf(lEntidad.FECHANOTIFICACION = Nothing, DBNull.Value, lEntidad.FECHANOTIFICACION)
        args(70) = New SqlParameter("@NUMERONOTIFICACION", SqlDbType.VarChar)
        args(70).Value = IIf(lEntidad.NUMERONOTIFICACION = Nothing, DBNull.Value, lEntidad.NUMERONOTIFICACION)
        args(71) = New SqlParameter("@CANTIDADAENTREGAR", SqlDbType.Decimal)
        args(71).Value = IIf(lEntidad.CANTIDADAENTREGAR = Nothing, DBNull.Value, lEntidad.CANTIDADAENTREGAR)
        args(72) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(72).Value = IIf(lEntidad.IDPROCESOCOMPRA = Nothing, DBNull.Value, lEntidad.IDPROCESOCOMPRA)
        args(73) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(73).Value = IIf(lEntidad.IDPRODUCTO = Nothing, DBNull.Value, lEntidad.IDPRODUCTO)
        args(74) = New SqlParameter("@OBSERVACIONLEYENDA", SqlDbType.Text)
        args(74).Value = IIf(lEntidad.OBSERVACIONLEYENDA = Nothing, DBNull.Value, lEntidad.OBSERVACIONLEYENDA)
        args(75) = New SqlParameter("@OBSERVACIONNREGISTRO", SqlDbType.Text)
        args(75).Value = IIf(lEntidad.OBSERVACIONNREGISTRO = Nothing, DBNull.Value, lEntidad.OBSERVACIONNREGISTRO)
        args(76) = New SqlParameter("@OBSERVACIONVIAADMON", SqlDbType.Text)
        args(76).Value = IIf(lEntidad.OBSERVACIONVIAADMON = Nothing, DBNull.Value, lEntidad.OBSERVACIONVIAADMON)
        args(77) = New SqlParameter("@OBSERVACIONCONDIALMA", SqlDbType.Text)
        args(77).Value = IIf(lEntidad.OBSERVACIONCONDIALMA = Nothing, DBNull.Value, lEntidad.OBSERVACIONCONDIALMA)
        args(78) = New SqlParameter("@OBSERVACIONNLOTE", SqlDbType.Text)
        args(78).Value = IIf(lEntidad.OBSERVACIONNLOTE = Nothing, DBNull.Value, lEntidad.OBSERVACIONNLOTE)
        args(79) = New SqlParameter("@OBSERVACIONFECHAEXP", SqlDbType.Text)
        args(79).Value = IIf(lEntidad.OBSERVACIONFECHAEXP = Nothing, DBNull.Value, lEntidad.OBSERVACIONFECHAEXP)
        args(80) = New SqlParameter("@LUGARINSPECCION", SqlDbType.Text)
        args(80).Value = IIf(lEntidad.LUGARINSPECCION = Nothing, DBNull.Value, lEntidad.LUGARINSPECCION)
        args(81) = New SqlParameter("@PAGOANALISIS", SqlDbType.Text)
        args(81).Value = IIf(lEntidad.PAGOANALISIS = Nothing, DBNull.Value, lEntidad.PAGOANALISIS)
        args(82) = New SqlParameter("@NOMBREINSPECCION", SqlDbType.Text)
        args(82).Value = IIf(lEntidad.NOMBREINSPECCION = Nothing, DBNull.Value, lEntidad.NOMBREINSPECCION)


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INFORMEMUESTRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDINFORME, ")
        strSQL.Append(" IDTIPOINFORME, ")
        strSQL.Append(" NUMEROINFORME, ")
        strSQL.Append(" IDESTADO, ")
        strSQL.Append(" IDESTABLECIMIENTOCONTRATO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" NOMBREMEDICAMENTO, ")
        strSQL.Append(" NOMBRECOMERCIAL, ")
        strSQL.Append(" LABORATORIOFABRICANTE, ")
        strSQL.Append(" PROVEEDOR, ")
        strSQL.Append(" LOTE, ")
        strSQL.Append(" FECHAFABRICACION, ")
        strSQL.Append(" FECHAVENCIMIENTO, ")
        strSQL.Append(" NUMEROUNIDADES, ")
        strSQL.Append(" CANTIDADREMITIDA, ")
        strSQL.Append(" ESTABLECIMIENTOREMITE, ")
        strSQL.Append(" NUMERORECEPCION, ")
        strSQL.Append(" GUIAAEREA, ")
        strSQL.Append(" DESCRIPCIONEMPAQUE, ")
        strSQL.Append(" LEYENDAREQUERIDA, ")
        strSQL.Append(" NUMEROREGISTRO, ")
        strSQL.Append(" VIAADMINISTRACION, ")
        strSQL.Append(" FORMADISOLUCION, ")
        strSQL.Append(" CONDICIONESALMACENAMIENTO, ")
        strSQL.Append(" NUMEROLOTE, ")
        strSQL.Append(" FECHAEXPIRACION, ")
        strSQL.Append(" OTROSEMPAQUES, ")
        strSQL.Append(" DESCRIPCIONOTROSEMPAQUES, ")
        strSQL.Append(" DESCRIPCIONPRODUCTO, ")
        strSQL.Append(" CANTIDADFISICOQUIMICO, ")
        strSQL.Append(" CANTIDADMICROBIOLOGIA, ")
        strSQL.Append(" CANTIDADRETENCION, ")
        strSQL.Append(" DESCRIPCIONCONDICIONESALMACENAMIENTO, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" IDINSPECTOR, ")
        strSQL.Append(" FECHAELABORACIONINFORME, ")
        strSQL.Append(" IDCOORDINADOR, ")
        strSQL.Append(" MOTIVOSNOINSPECCION, ")
        strSQL.Append(" FECHACERTIFICACION, ")
        strSQL.Append(" FECHASOLICITUDINSPECCION, ")
        strSQL.Append(" FECHARECOLECCIONMUESTRA, ")
        strSQL.Append(" OBSERVACIONCERTIFICACION, ")
        strSQL.Append(" IDJEFELABORATORIO, ")
        strSQL.Append(" REPRESENTANTEPROVEEDOR, ")
        strSQL.Append(" RESULTADOINSPECCION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ORIGENPRODUCTO, ")
        strSQL.Append(" TIPOPRODUCTO, ")
        strSQL.Append(" MOTIVONOACEPTACION, ")
        strSQL.Append(" DESCRIPCIONDISOLUCION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" COMPROBANTECREDITOFISCAL, ")
        strSQL.Append(" NUMEROEMPAQUEPRIMARIO, ")
        strSQL.Append(" NUMEROEMPAQUESECUNDARIO, ")
        strSQL.Append(" DESCRIPCIONEMPAQUESECUNDARIO, ")
        strSQL.Append(" NUMEROEMPAQUECOLECTIVO, ")
        strSQL.Append(" DESCRIPCIONEMPAQUECOLECTIVO, ")
        strSQL.Append(" CONDICIONESALMACENAMIENTORECOMENDADAS, ")
        strSQL.Append(" NIVELINSPECCIONUTILIZABLE, ")
        strSQL.Append(" NUMEROUNIDADESAMUESTREAR, ")
        strSQL.Append(" NIVELCALIDADACEPTABLE, ")
        strSQL.Append(" RANGOACEPTACIONRECHAZO, ")
        strSQL.Append(" CALCULOS,")
        strSQL.Append(" FECHANOTIFICACION, ")
        strSQL.Append(" NUMERONOTIFICACION, ")
        strSQL.Append(" CANTIDADAENTREGAR, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" OBSERVACIONLEYENDA, ")
        strSQL.Append(" OBSERVACIONNREGISTRO, ")
        strSQL.Append(" OBSERVACIONVIAADMON, ")
        strSQL.Append(" OBSERVACIONCONDIALMA, ")
        strSQL.Append(" OBSERVACIONNLOTE, ")
        strSQL.Append(" OBSERVACIONFECHAEXP, ")
        strSQL.Append(" LUGARINSPECCION, ")
        strSQL.Append(" PAGOANALISIS) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDINFORME, ")
        strSQL.Append(" @IDTIPOINFORME, ")
        strSQL.Append(" @NUMEROINFORME, ")
        strSQL.Append(" @IDESTADO, ")
        strSQL.Append(" @IDESTABLECIMIENTOCONTRATO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @RENGLON, ")
        strSQL.Append(" @NOMBREMEDICAMENTO, ")
        strSQL.Append(" @NOMBRECOMERCIAL, ")
        strSQL.Append(" @LABORATORIOFABRICANTE, ")
        strSQL.Append(" @PROVEEDOR, ")
        strSQL.Append(" @LOTE, ")
        strSQL.Append(" @FECHAFABRICACION, ")
        strSQL.Append(" @FECHAVENCIMIENTO, ")
        strSQL.Append(" @NUMEROUNIDADES, ")
        strSQL.Append(" @CANTIDADREMITIDA, ")
        strSQL.Append(" @ESTABLECIMIENTOREMITE, ")
        strSQL.Append(" @NUMERORECEPCION, ")
        strSQL.Append(" @GUIAAEREA, ")
        strSQL.Append(" @DESCRIPCIONEMPAQUE, ")
        strSQL.Append(" @LEYENDAREQUERIDA, ")
        strSQL.Append(" @NUMEROREGISTRO, ")
        strSQL.Append(" @VIAADMINISTRACION, ")
        strSQL.Append(" @FORMADISOLUCION, ")
        strSQL.Append(" @CONDICIONESALMACENAMIENTO, ")
        strSQL.Append(" @NUMEROLOTE, ")
        strSQL.Append(" @FECHAEXPIRACION, ")
        strSQL.Append(" @OTROSEMPAQUES, ")
        strSQL.Append(" @DESCRIPCIONOTROSEMPAQUES, ")
        strSQL.Append(" @DESCRIPCIONPRODUCTO, ")
        strSQL.Append(" @CANTIDADFISICOQUIMICO, ")
        strSQL.Append(" @CANTIDADMICROBIOLOGIA, ")
        strSQL.Append(" @CANTIDADRETENCION, ")
        strSQL.Append(" @DESCRIPCIONCONDICIONESALMACENAMIENTO, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @IDINSPECTOR, ")
        strSQL.Append(" @FECHAELABORACIONINFORME, ")
        strSQL.Append(" @IDCOORDINADOR, ")
        strSQL.Append(" @MOTIVOSNOINSPECCION, ")
        strSQL.Append(" @FECHACERTIFICACION, ")
        strSQL.Append(" @FECHASOLICITUDINSPECCION, ")
        strSQL.Append(" @FECHARECOLECCIONMUESTRA, ")
        strSQL.Append(" @OBSERVACIONCERTIFICACION, ")
        strSQL.Append(" @IDJEFELABORATORIO, ")
        strSQL.Append(" @REPRESENTANTEPROVEEDOR, ")
        strSQL.Append(" @RESULTADOINSPECCION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ORIGENPRODUCTO, ")
        strSQL.Append(" @TIPOPRODUCTO, ")
        strSQL.Append(" @MOTIVONOACEPTACION, ")
        strSQL.Append(" @DESCRIPCIONDISOLUCION, ")
        strSQL.Append(" @ESTASINCRONIZADA, ")
        strSQL.Append(" @COMPROBANTECREDITOFISCAL, ")
        strSQL.Append(" @NUMEROEMPAQUEPRIMARIO, ")
        strSQL.Append(" @NUMEROEMPAQUESECUNDARIO, ")
        strSQL.Append(" @DESCRIPCIONEMPAQUESECUNDARIO, ")
        strSQL.Append(" @NUMEROEMPAQUECOLECTIVO, ")
        strSQL.Append(" @DESCRIPCIONEMPAQUECOLECTIVO, ")
        strSQL.Append(" @CONDICIONESALMACENAMIENTORECOMENDADAS, ")
        strSQL.Append(" @NIVELINSPECCIONUTILIZABLE, ")
        strSQL.Append(" @NUMEROUNIDADESAMUESTREAR, ")
        strSQL.Append(" @NIVELCALIDADACEPTABLE, ")
        strSQL.Append(" @RANGOACEPTACIONRECHAZO, ")
        strSQL.Append(" @CALCULOS, ")
        strSQL.Append(" @FECHANOTIFICACION, ")
        strSQL.Append(" @NUMERONOTIFICACION, ")
        strSQL.Append(" @CANTIDADAENTREGAR, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @OBSERVACIONLEYENDA, ")
        strSQL.Append(" @OBSERVACIONNREGISTRO, ")
        strSQL.Append(" @OBSERVACIONVIAADMON, ")
        strSQL.Append(" @OBSERVACIONCONDIALMA, ")
        strSQL.Append(" @OBSERVACIONNLOTE, ")
        strSQL.Append(" @OBSERVACIONFECHAEXP, ")
        strSQL.Append(" @LUGARINSPECCION, ")
        strSQL.Append(" @PAGOANALISIS) ")

        Dim args(81) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = lEntidad.IDINFORME
        args(2) = New SqlParameter("@IDTIPOINFORME", SqlDbType.SmallInt)
        args(2).Value = lEntidad.IDTIPOINFORME
        args(3) = New SqlParameter("@NUMEROINFORME", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.NUMEROINFORME = Nothing, DBNull.Value, lEntidad.NUMEROINFORME)
        args(4) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(4).Value = lEntidad.IDESTADO
        args(5) = New SqlParameter("@IDESTABLECIMIENTOCONTRATO", SqlDbType.Int)
        args(5).Value = lEntidad.IDESTABLECIMIENTOCONTRATO
        args(6) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(6).Value = lEntidad.IDPROVEEDOR
        args(7) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(7).Value = lEntidad.IDCONTRATO
        args(8) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(8).Value = lEntidad.RENGLON
        args(9) = New SqlParameter("@NOMBREMEDICAMENTO", SqlDbType.VarChar)
        args(9).Value = lEntidad.NOMBREMEDICAMENTO
        args(10) = New SqlParameter("@NOMBRECOMERCIAL", SqlDbType.VarChar)
        args(10).Value = lEntidad.NOMBRECOMERCIAL
        args(11) = New SqlParameter("@LABORATORIOFABRICANTE", SqlDbType.VarChar)
        args(11).Value = lEntidad.LABORATORIOFABRICANTE
        args(12) = New SqlParameter("@PROVEEDOR", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.PROVEEDOR = Nothing, DBNull.Value, lEntidad.PROVEEDOR)
        args(13) = New SqlParameter("@LOTE", SqlDbType.VarChar)
        args(13).Value = lEntidad.LOTE
        args(14) = New SqlParameter("@FECHAFABRICACION", SqlDbType.DateTime)
        args(14).Value = lEntidad.FECHAFABRICACION
        args(15) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(15).Value = lEntidad.FECHAVENCIMIENTO
        args(16) = New SqlParameter("@NUMEROUNIDADES", SqlDbType.Decimal)
        args(16).Value = lEntidad.NUMEROUNIDADES
        args(17) = New SqlParameter("@CANTIDADREMITIDA", SqlDbType.Decimal)
        args(17).Value = lEntidad.CANTIDADREMITIDA
        args(18) = New SqlParameter("@ESTABLECIMIENTOREMITE", SqlDbType.VarChar)
        args(18).Value = lEntidad.ESTABLECIMIENTOREMITE
        args(19) = New SqlParameter("@NUMERORECEPCION", SqlDbType.VarChar)
        args(19).Value = IIf(lEntidad.NUMERORECEPCION = Nothing, DBNull.Value, lEntidad.NUMERORECEPCION)
        args(20) = New SqlParameter("@GUIAAEREA", SqlDbType.VarChar)
        args(20).Value = IIf(lEntidad.GUIAAEREA = Nothing, DBNull.Value, lEntidad.GUIAAEREA)
        args(21) = New SqlParameter("@DESCRIPCIONEMPAQUE", SqlDbType.VarChar)
        args(21).Value = IIf(lEntidad.DESCRIPCIONEMPAQUE = Nothing, DBNull.Value, lEntidad.DESCRIPCIONEMPAQUE)
        args(22) = New SqlParameter("@LEYENDAREQUERIDA", SqlDbType.TinyInt)
        args(22).Value = lEntidad.LEYENDAREQUERIDA
        args(23) = New SqlParameter("@NUMEROREGISTRO", SqlDbType.TinyInt)
        args(23).Value = lEntidad.NUMEROREGISTRO
        args(24) = New SqlParameter("@VIAADMINISTRACION", SqlDbType.TinyInt)
        args(24).Value = lEntidad.VIAADMINISTRACION
        args(25) = New SqlParameter("@FORMADISOLUCION", SqlDbType.TinyInt)
        args(25).Value = lEntidad.FORMADISOLUCION
        args(26) = New SqlParameter("@CONDICIONESALMACENAMIENTO", SqlDbType.TinyInt)
        args(26).Value = lEntidad.CONDICIONESALMACENAMIENTO
        args(27) = New SqlParameter("@NUMEROLOTE", SqlDbType.TinyInt)
        args(27).Value = lEntidad.NUMEROLOTE
        args(28) = New SqlParameter("@FECHAEXPIRACION", SqlDbType.TinyInt)
        args(28).Value = lEntidad.FECHAEXPIRACION
        args(29) = New SqlParameter("@OTROSEMPAQUES", SqlDbType.TinyInt)
        args(29).Value = lEntidad.OTROSEMPAQUES
        args(30) = New SqlParameter("@DESCRIPCIONOTROSEMPAQUES", SqlDbType.VarChar)
        args(30).Value = IIf(lEntidad.DESCRIPCIONOTROSEMPAQUES = Nothing, DBNull.Value, lEntidad.DESCRIPCIONOTROSEMPAQUES)
        args(31) = New SqlParameter("@DESCRIPCIONPRODUCTO", SqlDbType.VarChar)
        args(31).Value = IIf(lEntidad.DESCRIPCIONPRODUCTO = Nothing, DBNull.Value, lEntidad.DESCRIPCIONPRODUCTO)
        args(32) = New SqlParameter("@CANTIDADFISICOQUIMICO", SqlDbType.Decimal)
        args(32).Value = lEntidad.CANTIDADFISICOQUIMICO
        args(33) = New SqlParameter("@CANTIDADMICROBIOLOGIA", SqlDbType.Decimal)
        args(33).Value = lEntidad.CANTIDADMICROBIOLOGIA
        args(34) = New SqlParameter("@CANTIDADRETENCION", SqlDbType.Decimal)
        args(34).Value = lEntidad.CANTIDADRETENCION
        args(35) = New SqlParameter("@DESCRIPCIONCONDICIONESALMACENAMIENTO", SqlDbType.VarChar)
        args(35).Value = IIf(lEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO = Nothing, DBNull.Value, lEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO)
        args(36) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(36).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(37) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
        args(37).Value = IIf(lEntidad.IDINSPECTOR = 0, DBNull.Value, lEntidad.IDINSPECTOR)
        args(38) = New SqlParameter("@FECHAELABORACIONINFORME", SqlDbType.DateTime)
        args(38).Value = lEntidad.FECHAELABORACIONINFORME
        args(39) = New SqlParameter("@IDCOORDINADOR", SqlDbType.Int)
        args(39).Value = IIf(lEntidad.IDCOORDINADOR = Nothing, DBNull.Value, lEntidad.IDCOORDINADOR)
        args(40) = New SqlParameter("@MOTIVOSNOINSPECCION", SqlDbType.VarChar)
        args(40).Value = IIf(lEntidad.MOTIVOSNOINSPECCION = Nothing, DBNull.Value, lEntidad.MOTIVOSNOINSPECCION)
        args(41) = New SqlParameter("@FECHACERTIFICACION", SqlDbType.DateTime)
        args(41).Value = IIf(lEntidad.FECHACERTIFICACION = Nothing, DBNull.Value, lEntidad.FECHACERTIFICACION)
        args(42) = New SqlParameter("@FECHASOLICITUDINSPECCION", SqlDbType.DateTime)
        args(42).Value = IIf(lEntidad.FECHASOLICITUDINSPECCION = Nothing, DBNull.Value, lEntidad.FECHASOLICITUDINSPECCION)
        args(43) = New SqlParameter("@FECHARECOLECCIONMUESTRA", SqlDbType.DateTime)
        args(43).Value = IIf(lEntidad.FECHARECOLECCIONMUESTRA = Nothing, DBNull.Value, lEntidad.FECHARECOLECCIONMUESTRA)
        args(44) = New SqlParameter("@OBSERVACIONCERTIFICACION", SqlDbType.VarChar)
        args(44).Value = IIf(lEntidad.OBSERVACIONCERTIFICACION = Nothing, DBNull.Value, lEntidad.OBSERVACIONCERTIFICACION)
        args(45) = New SqlParameter("@IDJEFELABORATORIO", SqlDbType.Int)
        args(45).Value = IIf(lEntidad.IDJEFELABORATORIO = Nothing, DBNull.Value, lEntidad.IDJEFELABORATORIO)
        args(46) = New SqlParameter("@REPRESENTANTEPROVEEDOR", SqlDbType.VarChar)
        args(46).Value = IIf(lEntidad.REPRESENTANTEPROVEEDOR = Nothing, DBNull.Value, lEntidad.REPRESENTANTEPROVEEDOR)
        args(47) = New SqlParameter("@RESULTADOINSPECCION", SqlDbType.TinyInt)
        args(47).Value = IIf(lEntidad.RESULTADOINSPECCION = Nothing, DBNull.Value, lEntidad.RESULTADOINSPECCION)
        args(48) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(48).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(49) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(49).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(50) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(50).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(51) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(51).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(52) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(52).Value = lEntidad.ESTASINCRONIZADA
        args(53) = New SqlParameter("@ORIGENPRODUCTO", SqlDbType.Int)
        args(53).Value = lEntidad.ORIGENPRODUCTO
        args(54) = New SqlParameter("@TIPOPRODUCTO", SqlDbType.Int)
        args(54).Value = lEntidad.TIPOPRODUCTO
        args(55) = New SqlParameter("@MOTIVONOACEPTACION", SqlDbType.Text)
        args(55).Value = IIf(lEntidad.MOTIVONOACEPTACION = Nothing, DBNull.Value, lEntidad.MOTIVONOACEPTACION)
        args(56) = New SqlParameter("@DESCRIPCIONDISOLUCION", SqlDbType.Text)
        args(56).Value = IIf(lEntidad.DESCRIPCIONDISOLUCION = Nothing, DBNull.Value, lEntidad.DESCRIPCIONDISOLUCION)
        args(57) = New SqlParameter("@COMPROBANTECREDITOFISCAL", SqlDbType.VarChar)
        args(57).Value = IIf(lEntidad.COMPROBANTECREDITOFISCAL = Nothing, DBNull.Value, lEntidad.COMPROBANTECREDITOFISCAL)
        args(58) = New SqlParameter("@NUMEROEMPAQUEPRIMARIO", SqlDbType.VarChar)
        args(58).Value = IIf(lEntidad.NUMEROEMPAQUEPRIMARIO = Nothing, DBNull.Value, lEntidad.NUMEROEMPAQUEPRIMARIO)
        args(59) = New SqlParameter("@NUMEROEMPAQUESECUNDARIO", SqlDbType.VarChar)
        args(59).Value = IIf(lEntidad.NUMEROEMPAQUESECUNDARIO = Nothing, DBNull.Value, lEntidad.NUMEROEMPAQUESECUNDARIO)
        args(60) = New SqlParameter("@DESCRIPCIONEMPAQUESECUNDARIO", SqlDbType.VarChar)
        args(60).Value = IIf(lEntidad.DESCRIPCIONEMPAQUESECUNDARIO = Nothing, DBNull.Value, lEntidad.DESCRIPCIONEMPAQUESECUNDARIO)
        args(61) = New SqlParameter("@NUMEROEMPAQUECOLECTIVO", SqlDbType.VarChar)
        args(61).Value = IIf(lEntidad.NUMEROEMPAQUECOLECTIVO = Nothing, DBNull.Value, lEntidad.NUMEROEMPAQUECOLECTIVO)
        args(62) = New SqlParameter("@DESCRIPCIONEMPAQUECOLECTIVO", SqlDbType.VarChar)
        args(62).Value = IIf(lEntidad.DESCRIPCIONEMPAQUECOLECTIVO = Nothing, DBNull.Value, lEntidad.DESCRIPCIONEMPAQUECOLECTIVO)
        args(63) = New SqlParameter("@CONDICIONESALMACENAMIENTORECOMENDADAS", SqlDbType.VarChar)
        args(63).Value = IIf(lEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS = Nothing, DBNull.Value, lEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS)
        args(64) = New SqlParameter("@NIVELINSPECCIONUTILIZABLE", SqlDbType.Int)
        args(64).Value = IIf(lEntidad.NIVELINSPECCIONUTILIZABLE = Nothing, DBNull.Value, lEntidad.NIVELINSPECCIONUTILIZABLE)
        args(65) = New SqlParameter("@NUMEROUNIDADESAMUESTREAR", SqlDbType.Int)
        args(65).Value = IIf(lEntidad.NUMEROUNIDADESAMUESTREAR = Nothing, DBNull.Value, lEntidad.NUMEROUNIDADESAMUESTREAR)
        args(66) = New SqlParameter("@NIVELCALIDADACEPTABLE", SqlDbType.VarChar)
        args(66).Value = IIf(lEntidad.NIVELCALIDADACEPTABLE = Nothing, DBNull.Value, lEntidad.NIVELCALIDADACEPTABLE)
        args(67) = New SqlParameter("@RANGOACEPTACIONRECHAZO", SqlDbType.VarChar)
        args(67).Value = IIf(lEntidad.RANGOACEPTACIONRECHAZO = Nothing, DBNull.Value, lEntidad.RANGOACEPTACIONRECHAZO)
        args(68) = New SqlParameter("@CALCULOS", SqlDbType.VarChar)
        args(68).Value = IIf(lEntidad.CALCULOS = Nothing, DBNull.Value, lEntidad.CALCULOS)
        args(69) = New SqlParameter("@FECHANOTIFICACION", SqlDbType.DateTime)
        args(69).Value = IIf(lEntidad.FECHANOTIFICACION = Nothing, DBNull.Value, lEntidad.FECHANOTIFICACION)
        args(70) = New SqlParameter("@NUMERONOTIFICACION", SqlDbType.VarChar)
        args(70).Value = IIf(lEntidad.NUMERONOTIFICACION = Nothing, DBNull.Value, lEntidad.NUMERONOTIFICACION)
        args(71) = New SqlParameter("@CANTIDADAENTREGAR", SqlDbType.Decimal)
        args(71).Value = IIf(lEntidad.CANTIDADAENTREGAR = Nothing, DBNull.Value, lEntidad.CANTIDADAENTREGAR)
        args(72) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(72).Value = IIf(lEntidad.IDPROCESOCOMPRA = Nothing, DBNull.Value, lEntidad.IDPROCESOCOMPRA)
        args(73) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(73).Value = IIf(lEntidad.IDPRODUCTO = Nothing, DBNull.Value, lEntidad.IDPRODUCTO)
        args(74) = New SqlParameter("@OBSERVACIONLEYENDA", SqlDbType.Text)
        args(74).Value = IIf(lEntidad.OBSERVACIONLEYENDA = Nothing, DBNull.Value, lEntidad.OBSERVACIONLEYENDA)
        args(75) = New SqlParameter("@OBSERVACIONNREGISTRO", SqlDbType.Text)
        args(75).Value = IIf(lEntidad.OBSERVACIONNREGISTRO = Nothing, DBNull.Value, lEntidad.OBSERVACIONNREGISTRO)
        args(76) = New SqlParameter("@OBSERVACIONVIAADMON", SqlDbType.Text)
        args(76).Value = IIf(lEntidad.OBSERVACIONVIAADMON = Nothing, DBNull.Value, lEntidad.OBSERVACIONVIAADMON)
        args(77) = New SqlParameter("@OBSERVACIONCONDIALMA", SqlDbType.Text)
        args(77).Value = IIf(lEntidad.OBSERVACIONCONDIALMA = Nothing, DBNull.Value, lEntidad.OBSERVACIONCONDIALMA)
        args(78) = New SqlParameter("@OBSERVACIONNLOTE", SqlDbType.Text)
        args(78).Value = IIf(lEntidad.OBSERVACIONNLOTE = Nothing, DBNull.Value, lEntidad.OBSERVACIONNLOTE)
        args(79) = New SqlParameter("@OBSERVACIONFECHAEXP", SqlDbType.Text)
        args(79).Value = IIf(lEntidad.OBSERVACIONFECHAEXP = Nothing, DBNull.Value, lEntidad.OBSERVACIONFECHAEXP)
        args(80) = New SqlParameter("@LUGARINSPECCION", SqlDbType.Text)
        args(80).Value = IIf(lEntidad.LUGARINSPECCION = Nothing, DBNull.Value, lEntidad.LUGARINSPECCION)
        args(81) = New SqlParameter("@PAGOANALISIS", SqlDbType.Text)
        args(81).Value = IIf(lEntidad.PAGOANALISIS = Nothing, DBNull.Value, lEntidad.PAGOANALISIS)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INFORMEMUESTRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDINFORME = @IDINFORME ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = lEntidad.IDINFORME

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INFORMEMUESTRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDINFORME = @IDINFORME ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = lEntidad.IDINFORME

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDTIPOINFORME = IIf(.Item("IDTIPOINFORME") Is DBNull.Value, Nothing, .Item("IDTIPOINFORME"))
                lEntidad.NUMEROINFORME = IIf(.Item("NUMEROINFORME") Is DBNull.Value, Nothing, .Item("NUMEROINFORME"))
                lEntidad.IDESTADO = IIf(.Item("IDESTADO") Is DBNull.Value, Nothing, .Item("IDESTADO"))
                lEntidad.IDESTABLECIMIENTOCONTRATO = IIf(.Item("IDESTABLECIMIENTOCONTRATO") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTOCONTRATO"))
                lEntidad.IDPROVEEDOR = IIf(.Item("IDPROVEEDOR") Is DBNull.Value, Nothing, .Item("IDPROVEEDOR"))
                lEntidad.IDCONTRATO = IIf(.Item("IDCONTRATO") Is DBNull.Value, Nothing, .Item("IDCONTRATO"))
                lEntidad.RENGLON = IIf(.Item("RENGLON") Is DBNull.Value, Nothing, .Item("RENGLON"))
                lEntidad.NOMBREMEDICAMENTO = IIf(.Item("NOMBREMEDICAMENTO") Is DBNull.Value, Nothing, .Item("NOMBREMEDICAMENTO"))
                lEntidad.NOMBRECOMERCIAL = IIf(.Item("NOMBRECOMERCIAL") Is DBNull.Value, Nothing, .Item("NOMBRECOMERCIAL"))
                lEntidad.LABORATORIOFABRICANTE = IIf(.Item("LABORATORIOFABRICANTE") Is DBNull.Value, Nothing, .Item("LABORATORIOFABRICANTE"))
                lEntidad.PROVEEDOR = IIf(.Item("PROVEEDOR") Is DBNull.Value, Nothing, .Item("PROVEEDOR"))
                lEntidad.LOTE = IIf(.Item("LOTE") Is DBNull.Value, Nothing, .Item("LOTE"))
                lEntidad.FECHAFABRICACION = IIf(.Item("FECHAFABRICACION") Is DBNull.Value, Nothing, .Item("FECHAFABRICACION"))
                lEntidad.FECHAVENCIMIENTO = IIf(.Item("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, .Item("FECHAVENCIMIENTO"))
                lEntidad.NUMEROUNIDADES = IIf(.Item("NUMEROUNIDADES") Is DBNull.Value, Nothing, .Item("NUMEROUNIDADES"))
                lEntidad.CANTIDADREMITIDA = IIf(.Item("CANTIDADREMITIDA") Is DBNull.Value, Nothing, .Item("CANTIDADREMITIDA"))
                lEntidad.ESTABLECIMIENTOREMITE = IIf(.Item("ESTABLECIMIENTOREMITE") Is DBNull.Value, Nothing, .Item("ESTABLECIMIENTOREMITE"))
                lEntidad.NUMERORECEPCION = IIf(.Item("NUMERORECEPCION") Is DBNull.Value, Nothing, .Item("NUMERORECEPCION"))
                lEntidad.GUIAAEREA = IIf(.Item("GUIAAEREA") Is DBNull.Value, Nothing, .Item("GUIAAEREA"))
                lEntidad.DESCRIPCIONEMPAQUE = IIf(.Item("DESCRIPCIONEMPAQUE") Is DBNull.Value, Nothing, .Item("DESCRIPCIONEMPAQUE"))
                lEntidad.LEYENDAREQUERIDA = IIf(.Item("LEYENDAREQUERIDA") Is DBNull.Value, Nothing, .Item("LEYENDAREQUERIDA"))
                lEntidad.NUMEROREGISTRO = IIf(.Item("NUMEROREGISTRO") Is DBNull.Value, Nothing, .Item("NUMEROREGISTRO"))
                lEntidad.VIAADMINISTRACION = IIf(.Item("VIAADMINISTRACION") Is DBNull.Value, Nothing, .Item("VIAADMINISTRACION"))
                lEntidad.FORMADISOLUCION = IIf(.Item("FORMADISOLUCION") Is DBNull.Value, Nothing, .Item("FORMADISOLUCION"))
                lEntidad.CONDICIONESALMACENAMIENTO = IIf(.Item("CONDICIONESALMACENAMIENTO") Is DBNull.Value, Nothing, .Item("CONDICIONESALMACENAMIENTO"))
                lEntidad.NUMEROLOTE = IIf(.Item("NUMEROLOTE") Is DBNull.Value, Nothing, .Item("NUMEROLOTE"))
                lEntidad.FECHAEXPIRACION = IIf(.Item("FECHAEXPIRACION") Is DBNull.Value, Nothing, .Item("FECHAEXPIRACION"))
                lEntidad.OTROSEMPAQUES = IIf(.Item("OTROSEMPAQUES") Is DBNull.Value, Nothing, .Item("OTROSEMPAQUES"))
                lEntidad.DESCRIPCIONOTROSEMPAQUES = IIf(.Item("DESCRIPCIONOTROSEMPAQUES") Is DBNull.Value, Nothing, .Item("DESCRIPCIONOTROSEMPAQUES"))
                lEntidad.DESCRIPCIONPRODUCTO = IIf(.Item("DESCRIPCIONPRODUCTO") Is DBNull.Value, Nothing, .Item("DESCRIPCIONPRODUCTO"))
                lEntidad.CANTIDADFISICOQUIMICO = IIf(.Item("CANTIDADFISICOQUIMICO") Is DBNull.Value, Nothing, .Item("CANTIDADFISICOQUIMICO"))
                lEntidad.CANTIDADMICROBIOLOGIA = IIf(.Item("CANTIDADMICROBIOLOGIA") Is DBNull.Value, Nothing, .Item("CANTIDADMICROBIOLOGIA"))
                lEntidad.CANTIDADRETENCION = IIf(.Item("CANTIDADRETENCION") Is DBNull.Value, Nothing, .Item("CANTIDADRETENCION"))
                lEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO = IIf(.Item("DESCRIPCIONCONDICIONESALMACENAMIENTO") Is DBNull.Value, Nothing, .Item("DESCRIPCIONCONDICIONESALMACENAMIENTO"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
                lEntidad.IDINSPECTOR = IIf(.Item("IDINSPECTOR") Is DBNull.Value, Nothing, .Item("IDINSPECTOR"))
                lEntidad.FECHAELABORACIONINFORME = IIf(.Item("FECHAELABORACIONINFORME") Is DBNull.Value, Nothing, .Item("FECHAELABORACIONINFORME"))
                lEntidad.IDCOORDINADOR = IIf(.Item("IDCOORDINADOR") Is DBNull.Value, Nothing, .Item("IDCOORDINADOR"))
                lEntidad.MOTIVOSNOINSPECCION = IIf(.Item("MOTIVOSNOINSPECCION") Is DBNull.Value, Nothing, .Item("MOTIVOSNOINSPECCION"))
                lEntidad.MOTIVONOACEPTACION = IIf(.Item("MOTIVONOACEPTACION") Is DBNull.Value, Nothing, .Item("MOTIVONOACEPTACION"))
                lEntidad.FECHACERTIFICACION = IIf(.Item("FECHACERTIFICACION") Is DBNull.Value, Nothing, .Item("FECHACERTIFICACION"))
                lEntidad.FECHASOLICITUDINSPECCION = IIf(.Item("FECHASOLICITUDINSPECCION") Is DBNull.Value, Nothing, .Item("FECHASOLICITUDINSPECCION"))
                lEntidad.FECHARECOLECCIONMUESTRA = IIf(.Item("FECHARECOLECCIONMUESTRA") Is DBNull.Value, Nothing, .Item("FECHARECOLECCIONMUESTRA"))
                lEntidad.OBSERVACIONCERTIFICACION = IIf(.Item("OBSERVACIONCERTIFICACION") Is DBNull.Value, Nothing, .Item("OBSERVACIONCERTIFICACION"))
                lEntidad.IDJEFELABORATORIO = IIf(.Item("IDJEFELABORATORIO") Is DBNull.Value, Nothing, .Item("IDJEFELABORATORIO"))
                lEntidad.REPRESENTANTEPROVEEDOR = IIf(.Item("REPRESENTANTEPROVEEDOR") Is DBNull.Value, Nothing, .Item("REPRESENTANTEPROVEEDOR"))
                lEntidad.RESULTADOINSPECCION = IIf(.Item("RESULTADOINSPECCION") Is DBNull.Value, Nothing, .Item("RESULTADOINSPECCION"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))

                'se adiciona el campo origen, Mayra Martínez 240709 
                lEntidad.ORIGENPRODUCTO = IIf(.Item("ORIGENPRODUCTO") Is DBNull.Value, Nothing, .Item("ORIGENPRODUCTO"))
                lEntidad.COMPROBANTECREDITOFISCAL = IIf(.Item("COMPROBANTECREDITOFISCAL") Is DBNull.Value, Nothing, .Item("COMPROBANTECREDITOFISCAL"))
                lEntidad.NUMEROEMPAQUEPRIMARIO = IIf(.Item("NUMEROEMPAQUEPRIMARIO") Is DBNull.Value, Nothing, .Item("NUMEROEMPAQUEPRIMARIO"))
                lEntidad.NUMEROEMPAQUESECUNDARIO = IIf(.Item("NUMEROEMPAQUESECUNDARIO") Is DBNull.Value, Nothing, .Item("NUMEROEMPAQUESECUNDARIO"))
                lEntidad.DESCRIPCIONEMPAQUESECUNDARIO = IIf(.Item("DESCRIPCIONEMPAQUESECUNDARIO") Is DBNull.Value, Nothing, .Item("DESCRIPCIONEMPAQUESECUNDARIO"))
                lEntidad.NUMEROEMPAQUECOLECTIVO = IIf(.Item("NUMEROEMPAQUECOLECTIVO") Is DBNull.Value, Nothing, .Item("NUMEROEMPAQUECOLECTIVO"))
                lEntidad.DESCRIPCIONEMPAQUECOLECTIVO = IIf(.Item("DESCRIPCIONEMPAQUECOLECTIVO") Is DBNull.Value, Nothing, .Item("DESCRIPCIONEMPAQUECOLECTIVO"))
                lEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS = IIf(.Item("CONDICIONESALMACENAMIENTORECOMENDADAS") Is DBNull.Value, Nothing, .Item("CONDICIONESALMACENAMIENTORECOMENDADAS"))
                lEntidad.NIVELINSPECCIONUTILIZABLE = IIf(.Item("NIVELINSPECCIONUTILIZABLE") Is DBNull.Value, Nothing, .Item("NIVELINSPECCIONUTILIZABLE"))
                lEntidad.NUMEROUNIDADESAMUESTREAR = IIf(.Item("NUMEROUNIDADESAMUESTREAR") Is DBNull.Value, Nothing, .Item("NUMEROUNIDADESAMUESTREAR"))
                lEntidad.NIVELCALIDADACEPTABLE = IIf(.Item("NIVELCALIDADACEPTABLE") Is DBNull.Value, Nothing, .Item("NIVELCALIDADACEPTABLE"))
                lEntidad.RANGOACEPTACIONRECHAZO = IIf(.Item("RANGOACEPTACIONRECHAZO") Is DBNull.Value, Nothing, .Item("RANGOACEPTACIONRECHAZO"))
                lEntidad.CALCULOS = IIf(.Item("CALCULOS") Is DBNull.Value, Nothing, .Item("CALCULOS"))
                lEntidad.FECHANOTIFICACION = IIf(.Item("FECHANOTIFICACION") Is DBNull.Value, Nothing, .Item("FECHANOTIFICACION"))
                lEntidad.NUMERONOTIFICACION = IIf(.Item("NUMERONOTIFICACION") Is DBNull.Value, Nothing, .Item("NUMERONOTIFICACION"))
                lEntidad.CANTIDADAENTREGAR = IIf(.Item("CANTIDADAENTREGAR") Is DBNull.Value, Nothing, .Item("CANTIDADAENTREGAR"))
                lEntidad.IDPROCESOCOMPRA = IIf(.Item("IDPROCESOCOMPRA") Is DBNull.Value, Nothing, .Item("IDPROCESOCOMPRA"))
                lEntidad.IDPRODUCTO = IIf(.Item("IDPRODUCTO") Is DBNull.Value, Nothing, .Item("IDPRODUCTO"))
                lEntidad.OBSERVACIONLEYENDA = IIf(.Item("OBSERVACIONLEYENDA") Is DBNull.Value, Nothing, .Item("OBSERVACIONLEYENDA"))
                lEntidad.OBSERVACIONNREGISTRO = IIf(.Item("OBSERVACIONNREGISTRO") Is DBNull.Value, Nothing, .Item("OBSERVACIONNREGISTRO"))
                lEntidad.OBSERVACIONVIAADMON = IIf(.Item("OBSERVACIONVIAADMON") Is DBNull.Value, Nothing, .Item("OBSERVACIONVIAADMON"))
                lEntidad.OBSERVACIONCONDIALMA = IIf(.Item("OBSERVACIONCONDIALMA") Is DBNull.Value, Nothing, .Item("OBSERVACIONCONDIALMA"))
                lEntidad.OBSERVACIONNLOTE = IIf(.Item("OBSERVACIONNLOTE") Is DBNull.Value, Nothing, .Item("OBSERVACIONNLOTE"))
                lEntidad.OBSERVACIONFECHAEXP = IIf(.Item("OBSERVACIONFECHAEXP") Is DBNull.Value, Nothing, .Item("OBSERVACIONFECHAEXP"))
                lEntidad.LUGARINSPECCION = IIf(.Item("LUGARINSPECCION") Is DBNull.Value, Nothing, .Item("LUGARINSPECCION"))
                lEntidad.PAGOANALISIS = IIf(.Item("PAGOANALISIS") Is DBNull.Value, Nothing, .Item("PAGOANALISIS"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As INFORMEMUESTRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDINFORME),0) + 1 ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32) As listaINFORMEMUESTRAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaINFORMEMUESTRAS

        Try
            Do While dr.Read()
                Dim mEntidad As New INFORMEMUESTRAS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDINFORME = IIf(dr("IDINFORME") Is DBNull.Value, Nothing, dr("IDINFORME"))
                mEntidad.IDTIPOINFORME = IIf(dr("IDTIPOINFORME") Is DBNull.Value, Nothing, dr("IDTIPOINFORME"))
                mEntidad.NUMEROINFORME = IIf(dr("NUMEROINFORME") Is DBNull.Value, Nothing, dr("NUMEROINFORME"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.IDESTABLECIMIENTOCONTRATO = IIf(dr("IDESTABLECIMIENTOCONTRATO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTOCONTRATO"))
                mEntidad.IDPROVEEDOR = IIf(dr("IDPROVEEDOR") Is DBNull.Value, Nothing, dr("IDPROVEEDOR"))
                mEntidad.IDCONTRATO = IIf(dr("IDCONTRATO") Is DBNull.Value, Nothing, dr("IDCONTRATO"))
                mEntidad.RENGLON = IIf(dr("RENGLON") Is DBNull.Value, Nothing, dr("RENGLON"))
                mEntidad.NOMBREMEDICAMENTO = IIf(dr("NOMBREMEDICAMENTO") Is DBNull.Value, Nothing, dr("NOMBREMEDICAMENTO"))
                mEntidad.NOMBRECOMERCIAL = IIf(dr("NOMBRECOMERCIAL") Is DBNull.Value, Nothing, dr("NOMBRECOMERCIAL"))
                mEntidad.LABORATORIOFABRICANTE = IIf(dr("LABORATORIOFABRICANTE") Is DBNull.Value, Nothing, dr("LABORATORIOFABRICANTE"))
                mEntidad.PROVEEDOR = IIf(dr("PROVEEDOR") Is DBNull.Value, Nothing, dr("PROVEEDOR"))
                mEntidad.LOTE = IIf(dr("LOTE") Is DBNull.Value, Nothing, dr("LOTE"))
                mEntidad.FECHAFABRICACION = IIf(dr("FECHAFABRICACION") Is DBNull.Value, Nothing, dr("FECHAFABRICACION"))
                mEntidad.FECHAVENCIMIENTO = IIf(dr("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, dr("FECHAVENCIMIENTO"))
                mEntidad.NUMEROUNIDADES = IIf(dr("NUMEROUNIDADES") Is DBNull.Value, Nothing, dr("NUMEROUNIDADES"))
                mEntidad.CANTIDADREMITIDA = IIf(dr("CANTIDADREMITIDA") Is DBNull.Value, Nothing, dr("CANTIDADREMITIDA"))
                mEntidad.ESTABLECIMIENTOREMITE = IIf(dr("ESTABLECIMIENTOREMITE") Is DBNull.Value, Nothing, dr("ESTABLECIMIENTOREMITE"))
                mEntidad.NUMERORECEPCION = IIf(dr("NUMERORECEPCION") Is DBNull.Value, Nothing, dr("NUMERORECEPCION"))
                mEntidad.GUIAAEREA = IIf(dr("GUIAAEREA") Is DBNull.Value, Nothing, dr("GUIAAEREA"))
                mEntidad.DESCRIPCIONEMPAQUE = IIf(dr("DESCRIPCIONEMPAQUE") Is DBNull.Value, Nothing, dr("DESCRIPCIONEMPAQUE"))
                mEntidad.LEYENDAREQUERIDA = IIf(dr("LEYENDAREQUERIDA") Is DBNull.Value, Nothing, dr("LEYENDAREQUERIDA"))
                mEntidad.NUMEROREGISTRO = IIf(dr("NUMEROREGISTRO") Is DBNull.Value, Nothing, dr("NUMEROREGISTRO"))
                mEntidad.VIAADMINISTRACION = IIf(dr("VIAADMINISTRACION") Is DBNull.Value, Nothing, dr("VIAADMINISTRACION"))
                mEntidad.FORMADISOLUCION = IIf(dr("FORMADISOLUCION") Is DBNull.Value, Nothing, dr("FORMADISOLUCION"))
                mEntidad.CONDICIONESALMACENAMIENTO = IIf(dr("CONDICIONESALMACENAMIENTO") Is DBNull.Value, Nothing, dr("CONDICIONESALMACENAMIENTO"))
                mEntidad.NUMEROLOTE = IIf(dr("NUMEROLOTE") Is DBNull.Value, Nothing, dr("NUMEROLOTE"))
                mEntidad.FECHAEXPIRACION = IIf(dr("FECHAEXPIRACION") Is DBNull.Value, Nothing, dr("FECHAEXPIRACION"))
                mEntidad.OTROSEMPAQUES = IIf(dr("OTROSEMPAQUES") Is DBNull.Value, Nothing, dr("OTROSEMPAQUES"))
                mEntidad.DESCRIPCIONOTROSEMPAQUES = IIf(dr("DESCRIPCIONOTROSEMPAQUES") Is DBNull.Value, Nothing, dr("DESCRIPCIONOTROSEMPAQUES"))
                mEntidad.DESCRIPCIONPRODUCTO = IIf(dr("DESCRIPCIONPRODUCTO") Is DBNull.Value, Nothing, dr("DESCRIPCIONPRODUCTO"))
                mEntidad.CANTIDADFISICOQUIMICO = IIf(dr("CANTIDADFISICOQUIMICO") Is DBNull.Value, Nothing, dr("CANTIDADFISICOQUIMICO"))
                mEntidad.CANTIDADMICROBIOLOGIA = IIf(dr("CANTIDADMICROBIOLOGIA") Is DBNull.Value, Nothing, dr("CANTIDADMICROBIOLOGIA"))
                mEntidad.CANTIDADRETENCION = IIf(dr("CANTIDADRETENCION") Is DBNull.Value, Nothing, dr("CANTIDADRETENCION"))
                mEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO = IIf(dr("DESCRIPCIONCONDICIONESALMACENAMIENTO") Is DBNull.Value, Nothing, dr("DESCRIPCIONCONDICIONESALMACENAMIENTO"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.IDINSPECTOR = IIf(dr("IDINSPECTOR") Is DBNull.Value, Nothing, dr("IDINSPECTOR"))
                mEntidad.FECHAELABORACIONINFORME = IIf(dr("FECHAELABORACIONINFORME") Is DBNull.Value, Nothing, dr("FECHAELABORACIONINFORME"))
                mEntidad.IDCOORDINADOR = IIf(dr("IDCOORDINADOR") Is DBNull.Value, Nothing, dr("IDCOORDINADOR"))
                mEntidad.MOTIVOSNOINSPECCION = IIf(dr("MOTIVOSNOINSPECCION") Is DBNull.Value, Nothing, dr("MOTIVOSNOINSPECCION"))
                mEntidad.FECHACERTIFICACION = IIf(dr("FECHACERTIFICACION") Is DBNull.Value, Nothing, dr("FECHACERTIFICACION"))
                mEntidad.FECHASOLICITUDINSPECCION = IIf(dr("FECHASOLICITUDINSPECCION") Is DBNull.Value, Nothing, dr("FECHASOLICITUDINSPECCION"))
                mEntidad.FECHARECOLECCIONMUESTRA = IIf(dr("FECHARECOLECCIONMUESTRA") Is DBNull.Value, Nothing, dr("FECHARECOLECCIONMUESTRA"))
                mEntidad.OBSERVACIONCERTIFICACION = IIf(dr("OBSERVACIONCERTIFICACION") Is DBNull.Value, Nothing, dr("OBSERVACIONCERTIFICACION"))
                mEntidad.IDJEFELABORATORIO = IIf(dr("IDJEFELABORATORIO") Is DBNull.Value, Nothing, dr("IDJEFELABORATORIO"))
                mEntidad.REPRESENTANTEPROVEEDOR = IIf(dr("REPRESENTANTEPROVEEDOR") Is DBNull.Value, Nothing, dr("REPRESENTANTEPROVEEDOR"))
                mEntidad.RESULTADOINSPECCION = IIf(dr("RESULTADOINSPECCION") Is DBNull.Value, Nothing, dr("RESULTADOINSPECCION"))
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
        tables(0) = New String("INFORMEMUESTRAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDINFORME, ")
        strSQL.Append(" IDTIPOINFORME, ")
        strSQL.Append(" NUMEROINFORME, ")
        strSQL.Append(" IDESTADO, ")
        strSQL.Append(" IDESTABLECIMIENTOCONTRATO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" NOMBREMEDICAMENTO, ")
        strSQL.Append(" NOMBRECOMERCIAL, ")
        strSQL.Append(" LABORATORIOFABRICANTE, ")
        strSQL.Append(" PROVEEDOR, ")
        strSQL.Append(" LOTE, ")
        strSQL.Append(" FECHAFABRICACION, ")
        strSQL.Append(" FECHAVENCIMIENTO, ")
        strSQL.Append(" NUMEROUNIDADES, ")
        strSQL.Append(" CANTIDADREMITIDA, ")
        strSQL.Append(" ESTABLECIMIENTOREMITE, ")
        strSQL.Append(" NUMERORECEPCION, ")
        strSQL.Append(" GUIAAEREA, ")
        strSQL.Append(" DESCRIPCIONEMPAQUE, ")
        strSQL.Append(" LEYENDAREQUERIDA, ")
        strSQL.Append(" NUMEROREGISTRO, ")
        strSQL.Append(" VIAADMINISTRACION, ")
        strSQL.Append(" FORMADISOLUCION, ")
        strSQL.Append(" CONDICIONESALMACENAMIENTO, ")
        strSQL.Append(" NUMEROLOTE, ")
        strSQL.Append(" FECHAEXPIRACION, ")
        strSQL.Append(" OTROSEMPAQUES, ")
        strSQL.Append(" DESCRIPCIONOTROSEMPAQUES, ")
        strSQL.Append(" DESCRIPCIONPRODUCTO, ")
        strSQL.Append(" CANTIDADFISICOQUIMICO, ")
        strSQL.Append(" CANTIDADMICROBIOLOGIA, ")
        strSQL.Append(" CANTIDADRETENCION, ")
        strSQL.Append(" DESCRIPCIONCONDICIONESALMACENAMIENTO, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" IDINSPECTOR, ")
        strSQL.Append(" FECHAELABORACIONINFORME, ")
        strSQL.Append(" IDCOORDINADOR, ")
        strSQL.Append(" MOTIVOSNOINSPECCION, ")
        strSQL.Append(" FECHACERTIFICACION, ")
        strSQL.Append(" FECHASOLICITUDINSPECCION, ")
        strSQL.Append(" FECHARECOLECCIONMUESTRA, ")
        strSQL.Append(" OBSERVACIONCERTIFICACION, ")
        strSQL.Append(" IDJEFELABORATORIO, ")
        strSQL.Append(" REPRESENTANTEPROVEEDOR, ")
        strSQL.Append(" RESULTADOINSPECCION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ORIGENPRODUCTO, ")
        strSQL.Append(" TIPOPRODUCTO, ")
        strSQL.Append(" MOTIVONOACEPTACION, ")
        strSQL.Append(" DESCRIPCIONDISOLUCION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" COMPROBANTECREDITOFISCAL, ")
        strSQL.Append(" NUMEROEMPAQUEPRIMARIO, ")
        strSQL.Append(" NUMEROEMPAQUESECUNDARIO, ")
        strSQL.Append(" DESCRIPCIONEMPAQUESECUNDARIO, ")
        strSQL.Append(" NUMEROEMPAQUECOLECTIVO, ")
        strSQL.Append(" DESCRIPCIONEMPAQUECOLECTIVO, ")
        strSQL.Append(" CONDICIONESALMACENAMIENTORECOMENDADAS, ")
        strSQL.Append(" NIVELINSPECCIONUTILIZABLE, ")
        strSQL.Append(" NUMEROUNIDADESAMUESTREAR, ")
        strSQL.Append(" NIVELCALIDADACEPTABLE, ")
        strSQL.Append(" RANGOACEPTACIONRECHAZO, ")
        strSQL.Append(" CALCULOS, ")
        strSQL.Append(" FECHANOTIFICACION, ")
        strSQL.Append(" NUMERONOTIFICACION, ")
        strSQL.Append(" CANTIDADAENTREGAR, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" OBSERVACIONLEYENDA, ")
        strSQL.Append(" OBSERVACIONNREGISTRO, ")
        strSQL.Append(" OBSERVACIONVIAADMON, ")
        strSQL.Append(" OBSERVACIONCONDIALMA, ")
        strSQL.Append(" OBSERVACIONNLOTE, ")
        strSQL.Append(" OBSERVACIONFECHAEXP, ")
        strSQL.Append(" LUGARINSPECCION, ")
        strSQL.Append(" PAGOANALISIS ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS ")

    End Sub

#End Region

End Class
