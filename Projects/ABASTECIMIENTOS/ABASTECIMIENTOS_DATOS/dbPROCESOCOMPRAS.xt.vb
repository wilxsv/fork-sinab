Partial Public Class dbPROCESOCOMPRAS

#Region " Métodos Agregados "
    ''' <summary>
    ''' Seleccion de toda la informacion del proceso de compras
    ''' </summary>
    ''' <param name="strSQL">Cadena de caracteres con la consulta SQL</param>

    Private Sub SelectTabla2(ByRef strSQL As Text.StringBuilder)

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
        strSQL.Append(" CONVERT(varchar(10), FECHAPUBLICACION, 102) AS FECHAPUBLICACION, ")
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
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS ")

    End Sub
    ''' <summary>
    ''' Obtener informacion del proceso de compra por estado
    ''' </summary>
    ''' <param name="aEntidad">Entidad que representa el proceso de compra</param>
    ''' <param name="EVAL_FECHA_RET">Identificacion de la Fecha de retiro</param>
    ''' <param name="EVAL_FECHA_REC">Identificacion de la fecha de recepcion</param>
    ''' <param name="ESTADOS">Identificador del estado</param>
    ''' <param name="USUARIOCOMISION">Identificador del usuario de la comision</param>
    ''' <returns>Informacion del proceso de compra en formato dataset</returns>

    Public Function ObtenerListaPorESTADO(ByVal aEntidad As PROCESOCOMPRAS, ByVal EVAL_FECHA_RET As Boolean, ByVal EVAL_FECHA_REC As Boolean, Optional ByVal ESTADOS() As Integer = Nothing, Optional ByVal USUARIOCOMISION As String = "") As DataSet

        Dim strSQL As New Text.StringBuilder
        'strSQL.Append("SELECT PC.*, ")
        'strSQL.Append("isnull(EPC.DESCRIPCION, '') ESTADOPROCESOCOMPRA, OBSERVACION ")
        'strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        'strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTADOPROCESOSCOMPRAS EPC ")
        'strSQL.Append("ON PC.IDESTADOPROCESOCOMPRA = EPC.IDESTADOPROCESOCOMPRA ")
        'strSQL.Append("INNER JOIN  SAB_UACI_OBSERVACIONPROCESOSCOMPRAS OPC ON PC.IDPROCESOCOMPRA = OPC.IDPROCESO ")
        strSQL.Append("SELECT distinct PC.*, ")
        strSQL.Append("isnull(EPC.DESCRIPCION, '') ESTADOPROCESOCOMPRA,OPC.OBSERVACION,e.NOMBRE,e.NOMBRE,e.APELLIDO,e.NOMBRE+ ' ' + e.APELLIDO NOMBRECOMPLETO,s.MONTOAUTORIZADO,s.MONTODISPONIBLE,s.MONTOSOLICITADO ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTADOPROCESOSCOMPRAS EPC ")
        strSQL.Append("ON PC.IDESTADOPROCESOCOMPRA = EPC.IDESTADOPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN  SAB_UACI_OBSERVACIONPROCESOSCOMPRAS OPC ON PC.IDPROCESOCOMPRA = OPC.IDPROCESO and pc.idestablecimiento=opc.idestablecimiento ")
        strSQL.Append(" inner join SAB_CAT_EMPLEADOS e on PC.IDENCARGADO=e.IDEMPLEADO ")
        strSQL.Append(" left join SAB_EST_SOLICITUDESPROCESOCOMPRAS spc on PC.IDPROCESOCOMPRA= spc.IDPROCESOCOMPRA and PC.IDESTABLECIMIENTO=spc.IDESTABLECIMIENTO ")
        strSQL.Append(" left join SAB_EST_SOLICITUDES s on spc.IDSOLICITUD=s.idsolicitud and   spc.IDESTABLECIMIENTOSOLICITUD =s.idestablecimiento ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        If IsNothing(ESTADOS) Then
            If aEntidad.IDESTADOPROCESOCOMPRA <> 0 Then
                strSQL.Append("AND PC.IDESTADOPROCESOCOMPRA = @IDESTADOPROCESOCOMPRA ")
            Else
                strSQL.Append("AND PC.IDESTADOPROCESOCOMPRA <> @IDESTADOPROCESOCOMPRA ")
            End If
        Else
            For i As Integer = 0 To ESTADOS.Length - 1
                If i = 0 Then
                    strSQL.Append("AND PC.IDESTADOPROCESOCOMPRA IN ( ")
                End If
                strSQL.Append("@IDESTADO" + i.ToString)
                If i = ESTADOS.Length - 1 Then
                    strSQL.Append(") ")
                Else
                    strSQL.Append(", ")
                End If
            Next
        End If

        If EVAL_FECHA_RET = True Then
            strSQL.Append("AND getdate() between PC.FECHAHORAINICIORETIRO and convert(varchar(10),FECHAHORAINICIOAPERTURA,112) + ' ' + '23:59:59' ")
            'strSQL.Append("AND getdate() between PC.FECHAHORAINICIORETIRO and convert(varchar(10),FECHAHORAINICIOAPERTURA,103) + ' ' + '23:59:59' ")

        End If

        If EVAL_FECHA_REC = True Then
            strSQL.Append("AND getdate() between PC.FECHAHORAINICIORECEPCION and PC.FECHAHORAFINRECEPCION ")
        End If

        If USUARIOCOMISION <> String.Empty Then
            strSQL.Append("AND ( ")

            If aEntidad.IDENCARGADO > 0 Then
                strSQL.Append("  PC.IDENCARGADO = @IDENCARGADO ")
                strSQL.Append("  OR ")
                strSQL.Append("  PC.IDJEFEUACI = @IDENCARGADO ")
                strSQL.Append("  OR ")
            End If

            strSQL.Append("      PC.IDPROCESOCOMPRA IN ")
            strSQL.Append("      ( ")
            strSQL.Append("        SELECT CPC.IDPROCESOCOMPRA ")
            strSQL.Append("        FROM SAB_UACI_COMISIONPROCESOCOMPRA CPC ")
            strSQL.Append("        INNER JOIN SAB_UACI_COMISIONESEVALUADORAS CE ")
            strSQL.Append("        ON (CPC.IDESTABLECIMIENTO = CE.IDESTABLECIMIENTO ")
            strSQL.Append("        AND CPC.IDCOMISION = CE.IDCOMISION) ")
            strSQL.Append("        WHERE CPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
            strSQL.Append("        AND CPC.USUARIOCOMISION = @USUARIOCOMISION ")
            strSQL.Append("        AND CE.ESTADO = 1 ")
            strSQL.Append("        AND CE.ESALTONIVEL = 1 ")
            strSQL.Append("       ) ")
            strSQL.Append("     ) ")
        Else
            If aEntidad.IDENCARGADO > 0 Then
                strSQL.Append("AND (PC.IDENCARGADO = @IDENCARGADO OR PC.IDJEFEUACI = @IDENCARGADO) ")
            End If
        End If

        strSQL.Append("   order  by FECHAINICIOPROCESOCOMPRA desc   ")

        Dim length As Integer
        If Not IsNothing(ESTADOS) Then length = ESTADOS.Length

        Dim args(4 + length) As SqlParameter
        args(0) = New SqlParameter("@IDESTADOPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDESTADOPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDENCARGADO", SqlDbType.Int)
        args(2).Value = aEntidad.IDENCARGADO
        args(3) = New SqlParameter("@USUARIOCOMISION", SqlDbType.VarChar)
        args(3).Value = USUARIOCOMISION
        If Not IsNothing(ESTADOS) Then
            For i As Integer = 0 To ESTADOS.Length - 1
                args(4 + i) = New SqlParameter("@IDESTADO" + i.ToString, SqlDbType.Int)
                args(4 + i).Value = ESTADOS(i)
            Next
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Consulta informacion del proceso de compra
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad del proceso de compra</param>
    ''' <returns>Informacion del proceso de compra en formato dataset</returns>

    Public Function RecuperarDatosProcesoCompra(ByVal aEntidad As PROCESOCOMPRAS) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.VarChar)
        args(0).Value = aEntidad.IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Actualizacion de la informacion de la apertura de la base
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad del proceso de compra</param>
    ''' <returns>Valor entero con el resultado de la actualización</returns>

    Public Function ActualizarAperturaBase(ByVal aEntidad As PROCESOCOMPRAS) As Integer

        Dim lID As Long
        If aEntidad.IDPROCESOCOMPRA = 0 _
            Or aEntidad.IDPROCESOCOMPRA = Nothing Then

            lID = Me.ObtenerID(aEntidad)

            If lID = -1 Then Return -1

            aEntidad.IDPROCESOCOMPRA = lID

            Return Agregar(aEntidad)

        End If

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" set LUGARAPERTURABASE = @LUGARAPERTURABASE, ")
        strSQL.Append(" FECHAREALIZADAAPERTURA = @FECHAREALIZADAAPERTURA, ")
        strSQL.Append(" IDESTADOPROCESOCOMPRA = @IDESTADOPROCESOCOMPRA, ")
        strSQL.Append(" ACTAAPERTURA = @ACTAAPERTURA, ")
        strSQL.Append(" OBSERVACIONESACTA = @OBSERVACIONESACTA, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@LUGARAPERTURABASE", SqlDbType.VarChar)
        args(0).Value = IIf(aEntidad.LUGARAPERTURABASE = Nothing, DBNull.Value, aEntidad.LUGARAPERTURABASE)
        args(1) = New SqlParameter("@FECHAREALIZADAAPERTURA", SqlDbType.DateTime)
        args(1).Value = IIf(aEntidad.FECHAREALIZADAAPERTURA = Nothing, DBNull.Value, aEntidad.FECHAREALIZADAAPERTURA)
        args(2) = New SqlParameter("@IDESTADOPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = IIf(aEntidad.IDESTADOPROCESOCOMPRA = Nothing, DBNull.Value, aEntidad.IDESTADOPROCESOCOMPRA)
        args(3) = New SqlParameter("@ACTAAPERTURA", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.ACTAAPERTURA = Nothing, DBNull.Value, aEntidad.ACTAAPERTURA)
        args(4) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(4).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(5) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(5).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(6) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(6).Value = aEntidad.ESTASINCRONIZADA
        args(7) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(7).Value = IIf(aEntidad.IDPROCESOCOMPRA = Nothing, DBNull.Value, aEntidad.IDPROCESOCOMPRA)
        args(8) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(8).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)
        args(9) = New SqlParameter("@OBSERVACIONESACTA", SqlDbType.VarChar)
        args(9).Value = IIf(aEntidad.OBSERVACIONESACTA = Nothing, DBNull.Value, aEntidad.OBSERVACIONESACTA)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Actualizacion del estado de la fase de recepción 
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad del proceso de compra</param>
    ''' <returns>Valor entero con el resultado</returns>

    Public Function ActualizarEstadoFinRecepcion(ByVal aEntidad As PROCESOCOMPRAS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_PROCESOCOMPRAS set ")
        strSQL.Append(" IDESTADOPROCESOCOMPRA = @IDESTADOPROCESOCOMPRA, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(7) As SqlParameter
        args(1) = New SqlParameter("@IDESTADOPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IIf(aEntidad.IDESTADOPROCESOCOMPRA = Nothing, DBNull.Value, aEntidad.IDESTADOPROCESOCOMPRA)
        args(2) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(2).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(3) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(3).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(4) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(4).Value = aEntidad.ESTASINCRONIZADA
        args(5) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(5).Value = IIf(aEntidad.IDPROCESOCOMPRA = Nothing, DBNull.Value, aEntidad.IDPROCESOCOMPRA)
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener la informacion del Acta de Apertura
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Informacion del acta de apertura en formato dataset</returns>

    Public Function obtenerDatasetActaAperturaOferta(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION AS TITULOLICITACION, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_CAT_PROVEEDORES.NOMBRE, ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.NOMBREREPRESENTANTE, SAB_UACI_OFERTAPROCESOCOMPRA.MONTOOFERTA, ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.MONTOGARANTIA, SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO, SAB_UACI_PROCESOCOMPRAS.FECHAREALIZADAAPERTURA, ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS.DESCRIPCION, SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA, SAB_UACI_PROCESOCOMPRAS.OBSERVACIONESACTA,1 AS DETALLE, ")
        'SE ADICIONA CAMPO DE DUI A REPORTE
        strSQL.Append("  SAB_UACI_RECEPCIONOFERTAS.DUIENTREGA  ")

        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS ON SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR = SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS ON ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND ")
        strSQL.Append(" (SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_OFERTAPROCESOCOMPRA.ESTAHABILITADO = 1) ")
        strSQL.Append(" ORDER BY SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene los empleados de la apertura de ofertas
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Listado de empleados en formato de dataset</returns>

    Public Function obtieneDatasetEmpleadosAperturaOferta(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_CAT_EMPLEADOS.NOMBRE, SAB_CAT_EMPLEADOS.APELLIDO, SAB_CAT_CARGOS.DESCRIPCION AS CARGO, ")
        strSQL.Append(" SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDPROCESOCOMPRA, SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append(" SAB_UACI_REPRESENTANTEAPERTURAPROCESOS ON ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_EMPLEADOS ON SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDEMPLEADO = SAB_CAT_EMPLEADOS.IDEMPLEADO INNER JOIN ")
        strSQL.Append(" SAB_CAT_CARGOS ON SAB_CAT_EMPLEADOS.IDCARGO = SAB_CAT_CARGOS.IDCARGO ")
        strSQL.Append("WHERE (SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Actualiza la fecha de publicacion de las bases.
    ''' </summary>
    ''' <param name="aEntidad">Especifica los valores necesarios para actualizar la publicacion de bases.</param>
    ''' <returns>Valor indicando si la actualizacion se realizó con éxito.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function ActualizarPublicarBase(ByVal aEntidad As PROCESOCOMPRAS) As Integer

        Dim lID As Long
        If aEntidad.IDPROCESOCOMPRA = 0 _
            Or aEntidad.IDPROCESOCOMPRA = Nothing Then

            lID = Me.ObtenerID(aEntidad)

            If lID = -1 Then Return -1

            aEntidad.IDPROCESOCOMPRA = lID

            Return Agregar(aEntidad)

        End If

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" SET FECHAENVIONOTA = @FECHAENVIONOTA, ")
        strSQL.Append(" COSTOBASE = @COSTOBASE, ")
        strSQL.Append(" FECHAPUBLICACION = @FECHAPUBLICACION, ")
        strSQL.Append(" LUGARRETIROBASE = @LUGARRETIROBASE, ")
        strSQL.Append(" FECHAHORAINICIORETIRO = @FECHAHORAINICIORETIRO, ")
        strSQL.Append(" FECHAHORAFINRETIRO = @FECHAHORAFINRETIRO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@FECHAENVIONOTA", SqlDbType.DateTime)
        args(0).Value = IIf(aEntidad.FECHAENVIONOTA = Nothing, DBNull.Value, aEntidad.FECHAENVIONOTA)
        args(1) = New SqlParameter("@COSTOBASE", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.COSTOBASE = Nothing, DBNull.Value, aEntidad.COSTOBASE)

        args(2) = New SqlParameter("@FECHAPUBLICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.FECHAPUBLICACION = Nothing, DBNull.Value, aEntidad.FECHAPUBLICACION)
        args(3) = New SqlParameter("@LUGARRETIROBASE", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.LUGARRETIROBASE = Nothing, DBNull.Value, aEntidad.LUGARRETIROBASE)
        args(4) = New SqlParameter("@FECHAHORAINICIORETIRO", SqlDbType.DateTime)
        args(4).Value = IIf(aEntidad.FECHAHORAINICIORETIRO = Nothing, DBNull.Value, aEntidad.FECHAHORAINICIORETIRO)
        args(5) = New SqlParameter("@FECHAHORAFINRETIRO", SqlDbType.DateTime)
        args(5).Value = IIf(aEntidad.FECHAHORAFINRETIRO = Nothing, DBNull.Value, aEntidad.FECHAHORAFINRETIRO)

        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = IIf(aEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(7).Value = IIf(aEntidad.AUFECHACREACION = Nothing, DBNull.Value, aEntidad.AUFECHACREACION)
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(10) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(10).Value = 0
        args(11) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(11).Value = IIf(aEntidad.IDPROCESOCOMPRA = Nothing, DBNull.Value, aEntidad.IDPROCESOCOMPRA)
        args(12) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(12).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza el estado del proceso de compras.
    ''' </summary>
    ''' <param name="aEntidad">Entidad que representa a la estructura del proceso de compras</param>
    ''' <returns>Numero entero indicando si la actualización fue satisfactoria</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ActualizarEstado(ByVal aEntidad As PROCESOCOMPRAS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_PROCESOCOMPRAS SET ")
        If aEntidad.FECHAELABORACIONBASE > DateTime.MinValue Then
            strSQL.Append(" FECHAELABORACIONBASE = @FECHAELABORACIONBASE, ")
            strSQL.Append(" FECHAAPROBACIONBASE = @FECHAELABORACIONBASE, ")
        End If
        If aEntidad.FECHAHORAFINRETIRO > DateTime.MinValue Then
            strSQL.Append("FECHAHORAFINRETIRO = @FECHAHORAFINRETIRO, ")
        End If
        If aEntidad.FECHAHORAFINRECEPCION > DateTime.MinValue Then
            strSQL.Append("FECHAHORAFINRECEPCION = @FECHAHORAFINRECEPCION, ")
        End If
        If aEntidad.FECHAPUBLICACION > DateTime.MinValue Then
            strSQL.Append("FECHAPUBLICACION = @FECHAPUBLICACION, ")
        End If
        If aEntidad.FECHAHORAFINAPERTURA > DateTime.MinValue Then
            strSQL.Append("FECHAHORAFINAPERTURA = @FECHAHORAFINAPERTURA, ")
        End If
        If aEntidad.FECHAFINEXAMEN > DateTime.MinValue Then
            strSQL.Append("FECHAFINEXAMEN = @FECHAFINEXAMEN, ")
        End If
        If aEntidad.FECHAFINRECOMENDACION > DateTime.MinValue Then
            strSQL.Append("FECHAFINRECOMENDACION = @FECHAFINRECOMENDACION, ")
        End If
        If aEntidad.FECHAFIRMARESOLUCION > DateTime.MinValue Then
            strSQL.Append("FECHAFIRMARESOLUCION = @FECHAFIRMARESOLUCION, ")
        End If
        If aEntidad.FECHAFIRMAACEPTACION > DateTime.MinValue Then
            strSQL.Append("FECHAFIRMAACEPTACION = @FECHAFIRMAACEPTACION, ")
        End If
        If aEntidad.NUMERORESOLUCION <> String.Empty And Not aEntidad.NUMERORESOLUCION = Nothing Then
            strSQL.Append(" NUMERORESOLUCION = @NUMERORESOLUCION, ")
        End If
        If aEntidad.IDTITULARADJUDICACION > 0 And Not aEntidad.IDTITULARADJUDICACION = Nothing Then
            strSQL.Append(" IDTITULARADJUDICACION = @IDTITULARADJUDICACION, ")
        End If
        strSQL.Append(" IDESTADOPROCESOCOMPRA = @IDESTADOPROCESOCOMPRA, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(17) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDESTADOPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = aEntidad.IDESTADOPROCESOCOMPRA
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = Now
        args(5) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(5).Value = 0
        If aEntidad.FECHAELABORACIONBASE > DateTime.MinValue Then
            args(6) = New SqlParameter("@FECHAELABORACIONBASE", SqlDbType.DateTime)
            args(6).Value = aEntidad.FECHAELABORACIONBASE
        End If
        If aEntidad.FECHAFINEXAMEN > DateTime.MinValue Then
            args(7) = New SqlParameter("@FECHAFINEXAMEN", SqlDbType.DateTime)
            args(7).Value = aEntidad.FECHAFINEXAMEN
        End If
        If aEntidad.FECHAFINRECOMENDACION > DateTime.MinValue Then
            args(8) = New SqlParameter("@FECHAFINRECOMENDACION", SqlDbType.DateTime)
            args(8).Value = aEntidad.FECHAFINRECOMENDACION
        End If
        If aEntidad.FECHAFIRMARESOLUCION > DateTime.MinValue Then
            args(9) = New SqlParameter("@FECHAFIRMARESOLUCION", SqlDbType.DateTime)
            args(9).Value = aEntidad.FECHAFIRMARESOLUCION
        End If
        If aEntidad.FECHAFIRMAACEPTACION > DateTime.MinValue Then
            args(10) = New SqlParameter("@FECHAFIRMAACEPTACION", SqlDbType.DateTime)
            args(10).Value = aEntidad.FECHAFIRMAACEPTACION
        End If
        If aEntidad.NUMERORESOLUCION <> String.Empty And Not aEntidad.NUMERORESOLUCION = Nothing Then
            args(11) = New SqlParameter("@NUMERORESOLUCION", SqlDbType.VarChar)
            args(11).Value = aEntidad.NUMERORESOLUCION
        End If
        If aEntidad.IDTITULARADJUDICACION > 0 And Not aEntidad.IDTITULARADJUDICACION = Nothing Then
            args(12) = New SqlParameter("@IDTITULARADJUDICACION", SqlDbType.Int)
            args(12).Value = aEntidad.IDTITULARADJUDICACION
        End If

        If aEntidad.FECHAHORAFINRETIRO > DateTime.MinValue Then
            args(13) = New SqlParameter("@FECHAHORAFINRETIRO", SqlDbType.DateTime)
            args(13).Value = aEntidad.FECHAHORAFINRETIRO
        End If
        If aEntidad.FECHAHORAFINRECEPCION > DateTime.MinValue Then
            args(14) = New SqlParameter("@FECHAHORAFINRECEPCION", SqlDbType.DateTime)
            args(14).Value = aEntidad.FECHAHORAFINRECEPCION
        End If
        If aEntidad.FECHAHORAFINAPERTURA > DateTime.MinValue Then
            args(15) = New SqlParameter("@FECHAHORAFINAPERTURA", SqlDbType.DateTime)
            args(15).Value = aEntidad.FECHAHORAFINAPERTURA
        End If
        If aEntidad.FECHAPUBLICACION > DateTime.MinValue Then
            args(16) = New SqlParameter("@FECHAPUBLICACION", SqlDbType.DateTime)
            args(16).Value = aEntidad.FECHAPUBLICACION
        End If

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el código y el tipo de licitación del proceso de compras.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="idprocesocompra">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="ds">Dataset referenciado que almacenara la informacion devuelta</param>
    ''' 
    ''' <returns>Dataset con la informacion de la licitación</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_TIPOCOMPRAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ObtenerCodigoyTipoLicitacion(ByVal IDESTABLECIMIENTO As Int32, ByVal idprocesocompra As Integer, ByRef ds As DataSet) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_TIPOCOMPRAS.DESCRIPCION, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA, SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION,  SAB_CAT_TIPOCOMPRAS.IDMODALIDADCOMPRA ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS ON SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR = SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA ")
        strSQL.Append(" WHERE (SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ) AND (SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = idprocesocompra

        Dim tables(0) As String
        tables(0) = New String("licitacion")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    ''' <summary>
    ''' Obtiene la información de la Licitacion.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el establecimiento a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el proceso de compra a utilizar para filtrar la información</param>
    ''' <param name="ds">Dataset enviado por referencia para obtener la informacion.</param>
    ''' <returns>Dataset devuelto con la informacion de la licitación.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_TIPOCOMPRAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history>
    Public Function ObtenerInfoLicitacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Integer, ByRef ds As DataSet) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("TC.DESCRIPCION, ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("PC.TITULOLICITACION, ")
        strSQL.Append("PC.DESCRIPCIONLICITACION ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        strSQL.Append("WHERE PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim tables(0) As String
        tables(0) = New String("licitacion")

        'SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)


        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

        'Return 1

    End Function

    ''' <summary>
    ''' Obtiene la información relacionada con un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>ArrayList.</returns>
    ''' <remarks>Lista de tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_PROCESOCOMPRAS</item>
    ''' <item>SAB_CAT_ESTABLECIMIENTOS</item>
    ''' <item>SAB_CAT_TIPOCOMPRAS</item>
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' <item>SAB_CAT_CARGOS</item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerInfoLicitacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Integer) As ArrayList

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTO, ")
        strSQL.Append("isnull(TP.DESCRIPCION, '') DESCRIPCION, ")
        strSQL.Append("isnull(PC.CODIGOLICITACION, '') CODIGOLICITACION, ")
        strSQL.Append("isnull(PC.TITULOLICITACION, '') TITULOLICITACION, ")
        strSQL.Append("isnull(PC.DESCRIPCIONLICITACION, '') DESCRIPCIONLICITACION, ")
        strSQL.Append("isnull(PC.NUMERORESOLUCION, '') NUMERORESOLUCION, ")
        strSQL.Append("isnull(EM.NOMBRE + ' ' + EM.APELLIDO, '') TITULAR, ")
        strSQL.Append("isnull(C.DESCRIPCION, '') CARGOTITULAR ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_TIPOCOMPRAS TP ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TP.IDTIPOCOMPRA ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_EMPLEADOS EM ")
        strSQL.Append("ON PC.IDTITULARADJUDICACION = EM.IDEMPLEADO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_CARGOS C ")
        strSQL.Append("ON EM.IDCARGO = C.IDCARGO ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim a As New ArrayList

        If dr.HasRows Then
            dr.Read()

            a.Add(New String(dr("ESTABLECIMIENTO").ToString))
            a.Add(New String(dr("DESCRIPCION").ToString + " " + dr("CODIGOLICITACION").ToString))
            a.Add(New String(dr("TITULOLICITACION").ToString))
            a.Add(New String(dr("DESCRIPCIONLICITACION").ToString))
            a.Add(New String(dr("NUMERORESOLUCION").ToString))
            a.Add(New String(dr("TITULAR").ToString))
            a.Add(New String(dr("CARGOTITULAR").ToString))
        End If

        dr.Close()

        Return a

    End Function
    ''' <summary>
    ''' Actualizacion de la informacion de generación de bases
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad del proceso de compra</param>
    ''' <param name="flag">Identificador del tipo de consulta</param>
    ''' <returns>Valor entero con el resultado de la actualizacion</returns>

    Public Function ActualizarValores_GenerarBases(ByVal aEntidad As PROCESOCOMPRAS, ByVal flag As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_PROCESOCOMPRAS SET ")
        Select Case flag
            Case Is = 1
                strSQL.Append(" IDTITULAR = @IDTITULAR, ")
                strSQL.Append(" IDENTIDADSOLICITA = @IDENTIDADSOLICITA, ")
                strSQL.Append(" CODIGOLICITACION = @CODIGOLICITACION, ")
                strSQL.Append(" TITULOLICITACION = @TITULOLICITACION, ")
                strSQL.Append(" DESCRIPCIONLICITACION = @DESCRIPCIONLICITACION,")
            Case Is = 2
                strSQL.Append(" LUGARRECEPCIONOFERTA = @LUGARRECEPCIONOFERTA, ")
                strSQL.Append(" DIRECCIONRECEPCIONOFERTA = @DIRECCIONRECEPCIONOFERTA, ")
                strSQL.Append(" IDMUNICIPIORECEPCION = @IDMUNICIPIORECEPCION, ")
                strSQL.Append(" FECHAHORAINICIORECEPCION = @FECHAHORAINICIORECEPCION, ")
                strSQL.Append(" FECHAHORAFINRECEPCION = @FECHAHORAFINRECEPCION, ")
            Case Is = 3
                strSQL.Append(" LUGARAPERTURABASE = @LUGARAPERTURABASE, ")
                strSQL.Append(" DIRECCIONAPERTURABASE = @DIRECCIONAPERTURABASE, ")
                strSQL.Append(" IDMUNICIPIOAPERTURA = @IDMUNICIPIOAPERTURA, ")
                strSQL.Append(" FECHAHORAINICIOAPERTURA = @FECHAHORAINICIOAPERTURA, ")
                strSQL.Append(" FECHAHORAFINAPERTURA = @FECHAHORAFINAPERTURA, ")
            Case Is = 4
                strSQL.Append(" FECHAINICIOACLARACIONES = @FECHAINICIOACLARACIONES, ")
                strSQL.Append(" FECHAFINACLARACIONES = @FECHAFINACLARACIONES, ")
                strSQL.Append(" FECHAINICIOCONSULTA = @FECHAINICIOCONSULTA, ")
                strSQL.Append(" FECHAFINCONSULTA = @FECHAFINCONSULTA, ")
            Case Is = 7
                strSQL.Append(" PORCENTAJEFINANCIERO = @PORCENTAJEFINANCIERO, ")
                strSQL.Append(" PORCENTAJEINDICESOLVENCIA = @PORCENTAJEINDICESOLVENCIA, ")
                strSQL.Append(" PORCENTAJECAPITALTRABAJO = @PORCENTAJECAPITALTRABAJO, ")
                strSQL.Append(" PORCENTAJEENDEUDAMIENTO = @PORCENTAJEENDEUDAMIENTO, ")
                strSQL.Append(" PORCENTAJEREFERENCIASBANC = @PORCENTAJEREFERENCIASBANC, ")
            Case Is = 8
                strSQL.Append(" GARANTIAMTTOENTREGA = 0, ")
                strSQL.Append(" GARANTIAMTTOVIGENCIA = @GARANTIAMTTOVIGENCIA, ")
                strSQL.Append(" LUGARMTTO = @LUGARMTTO, ")
                strSQL.Append(" GARANTIACUMPLIMIENTOVALOR = @GARANTIACUMPLIMIENTOVALOR, ")
                strSQL.Append(" GARANTIACUMPLIMIENTOENTREGA = @GARANTIACUMPLIMIENTOENTREGA, ")
                strSQL.Append(" GARANTIACUMPLIMIENTOVIGENCIA = @GARANTIACUMPLIMIENTOVIGENCIA, ")
                strSQL.Append(" LUGARCUMPLIMIENTO = @LUGARCUMPLIMIENTO, ")
                strSQL.Append(" GARANTIAANTICIPOVALOR = @GARANTIAANTICIPOVALOR, ")
                strSQL.Append(" GARANTIAANTICIPOENTREGAS = @GARANTIAANTICIPOENTREGAS, ")
                strSQL.Append(" GARANTIAANTICIPOVIGENCIA = @GARANTIAANTICIPOVIGENCIA, ")
                strSQL.Append(" LUGARANTICIPO = @LUGARANTICIPO, ")
                strSQL.Append(" GARANTIACALIDADVALOR = @GARANTIACALIDADVALOR, ")
                strSQL.Append(" GARANTIACALIDADENTREGA = @GARANTIACALIDADENTREGA, ")
                strSQL.Append(" GARANTIACALIDADVIGENCIA = @GARANTIACALIDADVIGENCIA, ")
                strSQL.Append(" LUGARCALIDAD = @LUGARCALIDAD, ")
            Case Is = 10
                strSQL.Append(" FECHAAPROBACIONBASE = @FECHAAPROBACIONBASE, ")
        End Select

        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        'strSQL.Append(" IDESTADOPROCESOCOMPRA = @IDESTADOPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(47) As SqlParameter
        Select Case flag
            Case Is = 1
                args(0) = New SqlParameter("@IDTITULAR", SqlDbType.Int)
                args(0).Value = IIf(aEntidad.IDTITULAR = Nothing, DBNull.Value, aEntidad.IDTITULAR)
                args(1) = New SqlParameter("@IDENTIDADSOLICITA", SqlDbType.Int)
                args(1).Value = IIf(aEntidad.IDENTIDADSOLICITA = Nothing, DBNull.Value, aEntidad.IDENTIDADSOLICITA)
                args(12) = New SqlParameter("@CODIGOLICITACION", SqlDbType.VarChar)
                args(12).Value = IIf(aEntidad.CODIGOLICITACION = Nothing, DBNull.Value, aEntidad.CODIGOLICITACION)
                args(13) = New SqlParameter("@TITULOLICITACION", SqlDbType.VarChar)
                args(13).Value = IIf(aEntidad.TITULOLICITACION = Nothing, DBNull.Value, aEntidad.TITULOLICITACION)
                args(14) = New SqlParameter("@DESCRIPCIONLICITACION", SqlDbType.VarChar)
                args(14).Value = IIf(aEntidad.DESCRIPCIONLICITACION = Nothing, DBNull.Value, aEntidad.DESCRIPCIONLICITACION)
            Case Is = 2
                args(7) = New SqlParameter("@LUGARRECEPCIONOFERTA", SqlDbType.VarChar)
                args(7).Value = IIf(aEntidad.LUGARRECEPCIONOFERTA = Nothing, DBNull.Value, aEntidad.LUGARRECEPCIONOFERTA)
                args(8) = New SqlParameter("@DIRECCIONRECEPCIONOFERTA", SqlDbType.VarChar)
                args(8).Value = IIf(aEntidad.DIRECCIONRECEPCIONOFERTA = Nothing, DBNull.Value, aEntidad.DIRECCIONRECEPCIONOFERTA)
                args(9) = New SqlParameter("@IDMUNICIPIORECEPCION", SqlDbType.SmallInt)
                args(9).Value = IIf(aEntidad.IDMUNICIPIORECEPCION = Nothing, DBNull.Value, aEntidad.IDMUNICIPIORECEPCION)
                args(10) = New SqlParameter("@FECHAHORAINICIORECEPCION", SqlDbType.DateTime)
                args(10).Value = IIf(aEntidad.FECHAHORAINICIORECEPCION = Nothing, DBNull.Value, aEntidad.FECHAHORAINICIORECEPCION)
                args(11) = New SqlParameter("@FECHAHORAFINRECEPCION", SqlDbType.DateTime)
                args(11).Value = IIf(aEntidad.FECHAHORAFINRECEPCION = Nothing, DBNull.Value, aEntidad.FECHAHORAFINRECEPCION)
            Case Is = 3
                args(2) = New SqlParameter("@LUGARAPERTURABASE", SqlDbType.VarChar)
                args(2).Value = IIf(aEntidad.LUGARAPERTURABASE = Nothing, DBNull.Value, aEntidad.LUGARAPERTURABASE)
                args(3) = New SqlParameter("@DIRECCIONAPERTURABASE", SqlDbType.VarChar)
                args(3).Value = IIf(aEntidad.DIRECCIONAPERTURABASE = Nothing, DBNull.Value, aEntidad.DIRECCIONAPERTURABASE)
                args(4) = New SqlParameter("@IDMUNICIPIOAPERTURA", SqlDbType.SmallInt)
                args(4).Value = IIf(aEntidad.IDMUNICIPIOAPERTURA = Nothing, DBNull.Value, aEntidad.IDMUNICIPIOAPERTURA)
                args(5) = New SqlParameter("@FECHAHORAINICIOAPERTURA", SqlDbType.DateTime)
                args(5).Value = IIf(aEntidad.FECHAHORAINICIOAPERTURA = Nothing, DBNull.Value, aEntidad.FECHAHORAINICIOAPERTURA)
                args(6) = New SqlParameter("@FECHAHORAFINAPERTURA", SqlDbType.DateTime)
                args(6).Value = IIf(aEntidad.FECHAHORAFINAPERTURA = Nothing, DBNull.Value, aEntidad.FECHAHORAFINAPERTURA)
            Case Is = 4
                args(15) = New SqlParameter("@FECHAINICIOACLARACIONES", SqlDbType.DateTime)
                args(15).Value = IIf(aEntidad.FECHAINICIOACLARACIONES = Nothing, DBNull.Value, aEntidad.FECHAINICIOACLARACIONES)
                args(16) = New SqlParameter("@FECHAFINACLARACIONES", SqlDbType.DateTime)
                args(16).Value = IIf(aEntidad.FECHAFINACLARACIONES = Nothing, DBNull.Value, aEntidad.FECHAFINACLARACIONES)
                args(17) = New SqlParameter("@FECHAINICIOCONSULTA", SqlDbType.DateTime)
                args(17).Value = IIf(aEntidad.FECHAINICIOCONSULTA = Nothing, DBNull.Value, aEntidad.FECHAINICIOCONSULTA)
                args(18) = New SqlParameter("@FECHAFINCONSULTA", SqlDbType.DateTime)
                args(18).Value = IIf(aEntidad.FECHAFINCONSULTA = Nothing, DBNull.Value, aEntidad.FECHAFINCONSULTA)
            Case Is = 7
                args(19) = New SqlParameter("@PORCENTAJEFINANCIERO", SqlDbType.Decimal)
                args(19).Value = IIf(aEntidad.PORCENTAJEFINANCIERO = Nothing, DBNull.Value, aEntidad.PORCENTAJEFINANCIERO)
                args(20) = New SqlParameter("@PORCENTAJEINDICESOLVENCIA", SqlDbType.Decimal)
                args(20).Value = IIf(aEntidad.PORCENTAJEINDICESOLVENCIA = Nothing, DBNull.Value, aEntidad.PORCENTAJEINDICESOLVENCIA)
                args(21) = New SqlParameter("@PORCENTAJECAPITALTRABAJO", SqlDbType.Decimal)
                args(21).Value = IIf(aEntidad.PORCENTAJECAPITALTRABAJO = Nothing, DBNull.Value, aEntidad.PORCENTAJECAPITALTRABAJO)
                args(22) = New SqlParameter("@PORCENTAJEENDEUDAMIENTO", SqlDbType.Decimal)
                args(22).Value = IIf(aEntidad.PORCENTAJEENDEUDAMIENTO = Nothing, DBNull.Value, aEntidad.PORCENTAJEENDEUDAMIENTO)
                args(23) = New SqlParameter("@PORCENTAJEREFERENCIASBANC", SqlDbType.Decimal)
                args(23).Value = IIf(aEntidad.PORCENTAJEREFERENCIASBANC = Nothing, DBNull.Value, aEntidad.PORCENTAJEREFERENCIASBANC)
            Case Is = 8
                args(24) = New SqlParameter("@GARANTIAMTTOENTREGA", SqlDbType.SmallInt)
                args(24).Value = IIf(aEntidad.GARANTIAMTTOENTREGA = Nothing, DBNull.Value, aEntidad.GARANTIAMTTOENTREGA)
                args(25) = New SqlParameter("@GARANTIAMTTOVIGENCIA", SqlDbType.SmallInt)
                args(25).Value = IIf(aEntidad.GARANTIAMTTOVIGENCIA = Nothing, DBNull.Value, aEntidad.GARANTIAMTTOVIGENCIA)
                args(26) = New SqlParameter("@LUGARMTTO", SqlDbType.VarChar)
                args(26).Value = IIf(aEntidad.LUGARMTTO = Nothing, DBNull.Value, aEntidad.LUGARMTTO)
                args(27) = New SqlParameter("@GARANTIACUMPLIMIENTOVALOR", SqlDbType.Decimal)
                args(27).Value = IIf(aEntidad.GARANTIACUMPLIMIENTOVALOR = Nothing, DBNull.Value, aEntidad.GARANTIACUMPLIMIENTOVALOR)
                args(28) = New SqlParameter("@GARANTIACUMPLIMIENTOENTREGA", SqlDbType.SmallInt)
                args(28).Value = IIf(aEntidad.GARANTIACUMPLIMIENTOENTREGA = Nothing, DBNull.Value, aEntidad.GARANTIACUMPLIMIENTOENTREGA)
                args(29) = New SqlParameter("@GARANTIACUMPLIMIENTOVIGENCIA", SqlDbType.SmallInt)
                args(29).Value = IIf(aEntidad.GARANTIACUMPLIMIENTOVIGENCIA = Nothing, DBNull.Value, aEntidad.GARANTIACUMPLIMIENTOVIGENCIA)
                args(30) = New SqlParameter("@LUGARCUMPLIMIENTO", SqlDbType.VarChar)
                args(30).Value = IIf(aEntidad.LUGARCUMPLIMIENTO = Nothing, DBNull.Value, aEntidad.LUGARCUMPLIMIENTO)
                args(31) = New SqlParameter("@GARANTIACALIDADVALOR", SqlDbType.Decimal)
                args(31).Value = IIf(aEntidad.GARANTIACALIDADVALOR = Nothing, DBNull.Value, aEntidad.GARANTIACALIDADVALOR)
                args(32) = New SqlParameter("@GARANTIACALIDADENTREGA", SqlDbType.SmallInt)
                args(32).Value = IIf(aEntidad.GARANTIACALIDADENTREGA = Nothing, DBNull.Value, aEntidad.GARANTIACALIDADENTREGA)
                args(33) = New SqlParameter("@GARANTIACALIDADVIGENCIA", SqlDbType.SmallInt)
                args(33).Value = IIf(aEntidad.GARANTIACALIDADVIGENCIA = Nothing, DBNull.Value, aEntidad.GARANTIACALIDADVIGENCIA)
                args(34) = New SqlParameter("@LUGARCALIDAD", SqlDbType.VarChar)
                args(34).Value = IIf(aEntidad.LUGARCALIDAD = Nothing, DBNull.Value, aEntidad.LUGARCALIDAD)
                args(43) = New SqlParameter("@GARANTIAANTICIPOVALOR", SqlDbType.Decimal)
                args(43).Value = IIf(aEntidad.GARANTIAANTICIPOVALOR = Nothing, DBNull.Value, aEntidad.GARANTIAANTICIPOVALOR)
                args(44) = New SqlParameter("@GARANTIAANTICIPOENTREGAS", SqlDbType.SmallInt)
                args(44).Value = IIf(aEntidad.GARANTIAANTICIPOENTREGAS = Nothing, DBNull.Value, aEntidad.GARANTIAANTICIPOENTREGAS)
                args(45) = New SqlParameter("@GARANTIAANTICIPOVIGENCIA", SqlDbType.SmallInt)
                args(45).Value = IIf(aEntidad.GARANTIAANTICIPOVIGENCIA = Nothing, DBNull.Value, aEntidad.GARANTIAANTICIPOVIGENCIA)
                args(46) = New SqlParameter("@LUGARANTICIPO", SqlDbType.VarChar)
                args(46).Value = IIf(aEntidad.LUGARANTICIPO = Nothing, DBNull.Value, aEntidad.LUGARANTICIPO)
            Case Is = 10
                args(35) = New SqlParameter("@FECHAAPROBACIONBASE", SqlDbType.DateTime)
                args(35).Value = IIf(aEntidad.FECHAAPROBACIONBASE = Nothing, DBNull.Value, aEntidad.FECHAAPROBACIONBASE)
        End Select

        args(36) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(36).Value = IIf(aEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args(37) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(37).Value = IIf(aEntidad.AUFECHACREACION = Nothing, DBNull.Value, aEntidad.AUFECHACREACION)
        args(38) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(38).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(39) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(39).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(40) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(40).Value = 1
        args(41) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(41).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)
        args(42) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(42).Value = IIf(aEntidad.IDPROCESOCOMPRA = Nothing, DBNull.Value, aEntidad.IDPROCESOCOMPRA)

        'args(42) = New SqlParameter("@IDESTADOPROCESOCOMPRA", SqlDbType.BigInt)
        'args(42).Value = IIf(aentidad.IDESTADOPROCESOCOMPRA = Nothing, DBNull.Value, aentidad.IDESTADOPROCESOCOMPRA)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Actualizacion de la informacion de bases de libre gestion
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad del proceso de compra</param>
    ''' <returns>Valor entero con el resultado de la actualizacion</returns>

    Public Function ActualizarValores_GenerarBasesLibreGestion(ByVal aEntidad As PROCESOCOMPRAS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_PROCESOCOMPRAS SET ")
        strSQL.Append(" IDENTIDADSOLICITA = @IDENTIDADSOLICITA, ")
        strSQL.Append(" FECHAHORAINICIORETIRO = @FECHAHORAINICIORETIRO, ")
        strSQL.Append(" FECHAHORAFINRETIRO = @FECHAHORAFINRETIRO, ")
        strSQL.Append(" FECHAINICIOACLARACIONES = @FECHAINICIOACLARACIONES, ")
        strSQL.Append(" FECHAFINACLARACIONES = @FECHAFINACLARACIONES, ")
        strSQL.Append(" FECHAHORAINICIORECEPCION = @FECHAHORAINICIORECEPCION, ")
        strSQL.Append(" FECHAHORAFINRECEPCION = @FECHAHORAFINRECEPCION, ")
        strSQL.Append(" FECHAHORAINICIOAPERTURA = @FECHAHORAINICIOAPERTURA, ")
        strSQL.Append(" FECHAHORAFINAPERTURA = @FECHAHORAFINAPERTURA, ")
        strSQL.Append(" CODIGOLICITACION = @CODIGOLICITACION, ")
        strSQL.Append(" TITULOLICITACION = @TITULOLICITACION, ")
        strSQL.Append(" DESCRIPCIONLICITACION = @DESCRIPCIONLICITACION, ")
        strSQL.Append(" IDESTADOPROCESOCOMPRA = @IDESTADOPROCESOCOMPRA, ")
        strSQL.Append(" FECHAELABORACIONBASE = @FECHAELABORACIONBASE, ")
        strSQL.Append(" VIGENCIACOTIZACION = @VIGENCIACOTIZACION, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOORDENCOMPRA = @GARANTIACUMPLIMIENTOORDENCOMPRA, ")
        strSQL.Append(" TIEMPOENTREGA = @TIEMPOENTREGA, ")
        strSQL.Append(" GARANTIACALIDADVALOR = @GARANTIACALIDADVALOR, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(23) As SqlParameter
        args(0) = New SqlParameter("@IDENTIDADSOLICITA", SqlDbType.Int)
        args(0).Value = IIf(aEntidad.IDENTIDADSOLICITA = Nothing, DBNull.Value, aEntidad.IDENTIDADSOLICITA)
        args(1) = New SqlParameter("@FECHAHORAINICIORETIRO", SqlDbType.DateTime)
        args(1).Value = IIf(aEntidad.FECHAHORAINICIORETIRO = Nothing, DBNull.Value, aEntidad.FECHAHORAINICIORETIRO)
        args(2) = New SqlParameter("@FECHAHORAFINRETIRO", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.FECHAHORAFINRETIRO = Nothing, DBNull.Value, aEntidad.FECHAHORAFINRETIRO)
        args(3) = New SqlParameter("@FECHAINICIOACLARACIONES", SqlDbType.DateTime)
        args(3).Value = IIf(aEntidad.FECHAINICIOACLARACIONES = Nothing, DBNull.Value, aEntidad.FECHAINICIOACLARACIONES)
        args(4) = New SqlParameter("@FECHAFINACLARACIONES", SqlDbType.DateTime)
        args(4).Value = IIf(aEntidad.FECHAFINACLARACIONES = Nothing, DBNull.Value, aEntidad.FECHAFINACLARACIONES)
        args(5) = New SqlParameter("@FECHAHORAINICIORECEPCION", SqlDbType.DateTime)
        args(5).Value = IIf(aEntidad.FECHAHORAINICIORECEPCION = Nothing, DBNull.Value, aEntidad.FECHAHORAINICIORECEPCION)
        args(6) = New SqlParameter("@FECHAHORAFINRECEPCION", SqlDbType.DateTime)
        args(6).Value = IIf(aEntidad.FECHAHORAFINRECEPCION = Nothing, DBNull.Value, aEntidad.FECHAHORAFINRECEPCION)
        args(7) = New SqlParameter("@FECHAHORAINICIOAPERTURA", SqlDbType.DateTime)
        args(7).Value = IIf(aEntidad.FECHAHORAINICIOAPERTURA = Nothing, DBNull.Value, aEntidad.FECHAHORAINICIOAPERTURA)
        args(8) = New SqlParameter("@FECHAHORAFINAPERTURA", SqlDbType.DateTime)
        args(8).Value = IIf(aEntidad.FECHAHORAFINAPERTURA = Nothing, DBNull.Value, aEntidad.FECHAHORAFINAPERTURA)
        args(9) = New SqlParameter("@CODIGOLICITACION", SqlDbType.VarChar)
        args(9).Value = IIf(aEntidad.CODIGOLICITACION = Nothing, DBNull.Value, aEntidad.CODIGOLICITACION)
        args(10) = New SqlParameter("@TITULOLICITACION", SqlDbType.VarChar)
        args(10).Value = IIf(aEntidad.TITULOLICITACION = Nothing, DBNull.Value, aEntidad.TITULOLICITACION)
        args(11) = New SqlParameter("@DESCRIPCIONLICITACION", SqlDbType.VarChar)
        args(11).Value = IIf(aEntidad.DESCRIPCIONLICITACION = Nothing, DBNull.Value, aEntidad.DESCRIPCIONLICITACION)
        args(12) = New SqlParameter("@IDESTADOPROCESOCOMPRA", SqlDbType.Int)
        args(12).Value = IIf(aEntidad.IDESTADOPROCESOCOMPRA = Nothing, DBNull.Value, aEntidad.IDESTADOPROCESOCOMPRA)
        args(13) = New SqlParameter("@FECHAELABORACIONBASE", SqlDbType.DateTime)
        args(13).Value = IIf(aEntidad.FECHAELABORACIONBASE = Nothing, DBNull.Value, aEntidad.FECHAELABORACIONBASE)
        args(14) = New SqlParameter("@VIGENCIACOTIZACION", SqlDbType.VarChar)
        args(14).Value = IIf(aEntidad.VIGENCIACOTIZACION = Nothing, DBNull.Value, aEntidad.VIGENCIACOTIZACION)
        args(15) = New SqlParameter("@GARANTIACUMPLIMIENTOORDENCOMPRA", SqlDbType.VarChar)
        args(15).Value = IIf(aEntidad.GARANTIACUMPLIMIENTOORDENCOMPRA = Nothing, DBNull.Value, aEntidad.GARANTIACUMPLIMIENTOORDENCOMPRA)
        args(16) = New SqlParameter("@TIEMPOENTREGA", SqlDbType.Decimal)
        args(16).Value = IIf(aEntidad.TIEMPOENTREGA = Nothing, DBNull.Value, aEntidad.TIEMPOENTREGA)
        args(17) = New SqlParameter("@GARANTIACALIDADVALOR", SqlDbType.Decimal)
        args(17).Value = IIf(aEntidad.GARANTIACALIDADVALOR = Nothing, DBNull.Value, aEntidad.GARANTIACALIDADVALOR)
        args(18) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(18).Value = IIf(aEntidad.IDPROCESOCOMPRA = Nothing, DBNull.Value, aEntidad.IDPROCESOCOMPRA)
        args(19) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(19).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)
        args(20) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(20).Value = aEntidad.ESTASINCRONIZADA
        args(21) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(21).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(22) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(22).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener el titular
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Lista de la informacion del titular en formato dataset</returns>

    Public Function obtenerTitular(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_EMPLEADOS.NOMBRE + ' ' + SAB_CAT_EMPLEADOS.APELLIDO AS TITULAR, SAB_CAT_CARGOS.DESCRIPCION AS CARGO ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append(" SAB_CAT_EMPLEADOS ON SAB_UACI_PROCESOCOMPRAS.IDTITULAR = SAB_CAT_EMPLEADOS.IDEMPLEADO INNER JOIN ")
        strSQL.Append(" SAB_CAT_CARGOS ON SAB_CAT_EMPLEADOS.IDCARGO = SAB_CAT_CARGOS.IDCARGO ")
        strSQL.Append(" WHERE SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener los titulares de adjudicacion
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Lista de los titulares en formato dataset</returns>

    Public Function obtenerTitularAdjudicacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_EMPLEADOS.NOMBRE + ' ' + SAB_CAT_EMPLEADOS.APELLIDO AS TITULAR, SAB_CAT_CARGOS.DESCRIPCION AS CARGO ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append(" SAB_CAT_EMPLEADOS ON SAB_UACI_PROCESOCOMPRAS.IDTITULARADJUDICACION = SAB_CAT_EMPLEADOS.IDEMPLEADO INNER JOIN ")
        strSQL.Append(" SAB_CAT_CARGOS ON SAB_CAT_EMPLEADOS.IDCARGO = SAB_CAT_CARGOS.IDCARGO ")
        strSQL.Append(" WHERE SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener el detalle de los productos
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Listad de productos en formato dataset</returns>

    Public Function obtenerDetalleProductos(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DPC.IDESTABLECIMIENTO, ")
        strSQL.Append("DPC.IDPROCESOCOMPRA, ")
        strSQL.Append("DPC.RENGLON, ")
        strSQL.Append("DPC.IDPRODUCTO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("CP.ESPECIFICACIONESTECNICAS, ")
        strSQL.Append("DPC.CANTIDAD, ")
        strSQL.Append("DPC.NUMEROENTREGAS, ")
        strSQL.Append("CP.CORRPRODUCTO CODIGO, ")
        strSQL.Append("CP.DESCPRODUCTO NOMBRE, ")
        'strSQL.Append("CP.PRECIOACTUAL * DPC.CANTIDAD MONTO, ")
        strSQL.Append("ds.PRESUPUESTOUNITARIO * DPC.CANTIDAD MONTO, ")

        strSQL.Append("CP.DESCLARGO AS DESCRIPCIONNOMBRE, ")
        strSQL.Append("isnull(DPC.GARANTIAMTTOVALOR,'0') GARANTIAMTTOVALOR ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")

        strSQL.Append("inner join SAB_EST_SOLICITUDESPROCESOCOMPRAS spc on spc.IDPROCESOCOMPRA=dpc.IDPROCESOCOMPRA and spc.IDESTABLECIMIENTO=dpc.IDESTABLECIMIENTO ")
        strSQL.Append("inner join SAB_EST_DETALLESOLICITUDES ds on ds.IDESTABLECIMIENTO=spc.IDESTABLECIMIENTO and ds.IDSOLICITUD=spc.IDSOLICITUD and dpc.RENGLON=ds.RENGLON and dpc.IDPRODUCTO=ds.IDPRODUCTO ")

        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE (DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Listado de los lugares de entrega
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Listado de lugares de entrega en formato dataset</returns>

    Public Function obtenerLugarPlazoEntrega(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDENTREGA ")
        strSQL.Append(" FROM SAB_UACI_DETALLEENTREGASPROCESOCOMPRA ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append(" GROUP BY IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDENTREGA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene los lugares y plazos de entrega
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="ENTREGA">Identificador de la entrega</param>
    ''' <returns>Lugares y plazos en formato de dataset</returns>

    Public Function obtenerLugarPlazoEntrega(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64, ByVal ENTREGA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDENTREGA, PORCENTAJE, DIAS ")
        strSQL.Append(" FROM SAB_UACI_DETALLEENTREGASPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND IDENTREGA = @IDENTREGA ")
        strSQL.Append(" GROUP BY IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDENTREGA, PORCENTAJE, DIAS ")
        strSQL.Append(" ORDER BY DIAS ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.BigInt)
        args(2).Value = ENTREGA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener los procesos de compra que cumplan con un estado en particular
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDESTADO">Identificador del estado</param> 'identificado del estado del proceso de compra
    ''' <returns>
    ''' Dataset con los prcesos de compra que cumpla con el estado
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_ESTADOPROCESOSCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOCONTRATO</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerProcesoCompraEstado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO, SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA, SAB_UACI_PROCESOCOMPRAS.IDTITULAR, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDENTIDADSOLICITA, SAB_UACI_PROCESOCOMPRAS.FECHAENVIONOTA, SAB_UACI_PROCESOCOMPRAS.COSTOBASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.LUGARAPERTURABASE, SAB_UACI_PROCESOCOMPRAS.DIRECCIONAPERTURABASE, SAB_UACI_PROCESOCOMPRAS.IDMUNICIPIOAPERTURA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAINICIOAPERTURA, SAB_UACI_PROCESOCOMPRAS.FECHAHORAFINAPERTURA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAREALIZADAAPERTURA, SAB_UACI_PROCESOCOMPRAS.FECHAPUBLICACION, SAB_UACI_PROCESOCOMPRAS.LUGARRETIROBASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAINICIORETIRO, SAB_UACI_PROCESOCOMPRAS.FECHAHORAFINRETIRO, SAB_UACI_PROCESOCOMPRAS.LUGARRECEPCIONOFERTA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DIRECCIONRECEPCIONOFERTA, SAB_UACI_PROCESOCOMPRAS.IDMUNICIPIORECEPCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAINICIORECEPCION, SAB_UACI_PROCESOCOMPRAS.FECHAHORAFINRECEPCION, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR, SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA, SAB_UACI_PROCESOCOMPRAS.IDENCARGADO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAINICIOPROCESOCOMPRA, SAB_UACI_PROCESOCOMPRAS.FECHAELABORACIONBASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAAPROBACIONBASE, SAB_UACI_PROCESOCOMPRAS.FECHAINICIOACLARACIONES, SAB_UACI_PROCESOCOMPRAS.FECHAFINACLARACIONES, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAINICIOCONSULTA, SAB_UACI_PROCESOCOMPRAS.FECHAFINCONSULTA, SAB_UACI_PROCESOCOMPRAS.PORCENTAJEFINANCIERO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.PORCENTAJEINDICESOLVENCIA, SAB_UACI_PROCESOCOMPRAS.PORCENTAJECAPITALTRABAJO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.PORCENTAJEENDEUDAMIENTO, SAB_UACI_PROCESOCOMPRAS.PORCENTAJEREFERENCIASBANC, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIAMTTOENTREGA, SAB_UACI_PROCESOCOMPRAS.GARANTIAMTTOVIGENCIA, SAB_UACI_PROCESOCOMPRAS.LUGARMTTO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACUMPLIMIENTOVALOR, SAB_UACI_PROCESOCOMPRAS.GARANTIACUMPLIMIENTOENTREGA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACUMPLIMIENTOVIGENCIA, SAB_UACI_PROCESOCOMPRAS.LUGARCUMPLIMIENTO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACALIDADVALOR, SAB_UACI_PROCESOCOMPRAS.GARANTIACALIDADENTREGA, SAB_UACI_PROCESOCOMPRAS.GARANTIACALIDADVIGENCIA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.LUGARCALIDAD, SAB_UACI_PROCESOCOMPRAS.FECHAINICIOANALISIS, SAB_UACI_PROCESOCOMPRAS.FECHAFINANALISIS, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAFIRMARESOLUCION, SAB_UACI_PROCESOCOMPRAS.NUMERORESOLUCION, SAB_UACI_PROCESOCOMPRAS.FECHALIMITEACEPTACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHANOTIFICACION, SAB_UACI_PROCESOCOMPRAS.FECHAPUBLICACIONRESOLUCION, SAB_UACI_PROCESOCOMPRAS.MEDIOSDIVULGACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAFIRMAACEPTACION, SAB_UACI_PROCESOCOMPRAS.AUUSUARIOCREACION, SAB_UACI_PROCESOCOMPRAS.AUFECHACREACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.AUUSUARIOMODIFICACION, SAB_UACI_PROCESOCOMPRAS.AUFECHAMODIFICACION, SAB_UACI_PROCESOCOMPRAS.ESTASINCRONIZADA, ")
        strSQL.Append("SAB_CAT_ESTADOPROCESOSCOMPRAS.DESCRIPCION AS ESTADO ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTADOPROCESOSCOMPRAS ON SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA = SAB_CAT_ESTADOPROCESOSCOMPRAS.IDESTADOPROCESOCOMPRA ")
        strSQL.Append("WHERE SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA = @IDESTADO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(1).Value = IDESTADO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene un filtro de procesos de compras por codigo de proceso de compra utilizado por MSPAS
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'Identificador dele stablecimiento
    ''' <param name="IDESTADO">Identificador del estado</param> 'identificar el estado del proceso
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param> 'identificar el proceso de compras
    ''' <returns>
    ''' Dataset con los procesos de compra filtrados por codigo
    ''' </returns>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_ESTADOPROCESOSCOMPRAS</description></item>
    ''' </list> 
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerProcesoCompraEstadoXCodigo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADO As Int32, ByVal IDPROCESO As String) As DataSet
        Dim CODIGOCOMPRA As String
        CODIGOCOMPRA = "%" & IDPROCESO & "%"

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO, SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA, SAB_UACI_PROCESOCOMPRAS.IDTITULAR, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDENTIDADSOLICITA, SAB_UACI_PROCESOCOMPRAS.FECHAENVIONOTA, SAB_UACI_PROCESOCOMPRAS.COSTOBASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.LUGARAPERTURABASE, SAB_UACI_PROCESOCOMPRAS.DIRECCIONAPERTURABASE, SAB_UACI_PROCESOCOMPRAS.IDMUNICIPIOAPERTURA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAINICIOAPERTURA, SAB_UACI_PROCESOCOMPRAS.FECHAHORAFINAPERTURA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAREALIZADAAPERTURA, SAB_UACI_PROCESOCOMPRAS.FECHAPUBLICACION, SAB_UACI_PROCESOCOMPRAS.LUGARRETIROBASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAINICIORETIRO, SAB_UACI_PROCESOCOMPRAS.FECHAHORAFINRETIRO, SAB_UACI_PROCESOCOMPRAS.LUGARRECEPCIONOFERTA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DIRECCIONRECEPCIONOFERTA, SAB_UACI_PROCESOCOMPRAS.IDMUNICIPIORECEPCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAINICIORECEPCION, SAB_UACI_PROCESOCOMPRAS.FECHAHORAFINRECEPCION, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR, SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA, SAB_UACI_PROCESOCOMPRAS.IDENCARGADO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAINICIOPROCESOCOMPRA, SAB_UACI_PROCESOCOMPRAS.FECHAELABORACIONBASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAAPROBACIONBASE, SAB_UACI_PROCESOCOMPRAS.FECHAINICIOACLARACIONES, SAB_UACI_PROCESOCOMPRAS.FECHAFINACLARACIONES, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAINICIOCONSULTA, SAB_UACI_PROCESOCOMPRAS.FECHAFINCONSULTA, SAB_UACI_PROCESOCOMPRAS.PORCENTAJEFINANCIERO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.PORCENTAJEINDICESOLVENCIA, SAB_UACI_PROCESOCOMPRAS.PORCENTAJECAPITALTRABAJO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.PORCENTAJEENDEUDAMIENTO, SAB_UACI_PROCESOCOMPRAS.PORCENTAJEREFERENCIASBANC, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIAMTTOENTREGA, SAB_UACI_PROCESOCOMPRAS.GARANTIAMTTOVIGENCIA, SAB_UACI_PROCESOCOMPRAS.LUGARMTTO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACUMPLIMIENTOVALOR, SAB_UACI_PROCESOCOMPRAS.GARANTIACUMPLIMIENTOENTREGA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACUMPLIMIENTOVIGENCIA, SAB_UACI_PROCESOCOMPRAS.LUGARCUMPLIMIENTO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACALIDADVALOR, SAB_UACI_PROCESOCOMPRAS.GARANTIACALIDADENTREGA, SAB_UACI_PROCESOCOMPRAS.GARANTIACALIDADVIGENCIA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.LUGARCALIDAD, SAB_UACI_PROCESOCOMPRAS.FECHAINICIOANALISIS, SAB_UACI_PROCESOCOMPRAS.FECHAFINANALISIS, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAFIRMARESOLUCION, SAB_UACI_PROCESOCOMPRAS.NUMERORESOLUCION, SAB_UACI_PROCESOCOMPRAS.FECHALIMITEACEPTACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHANOTIFICACION, SAB_UACI_PROCESOCOMPRAS.FECHAPUBLICACIONRESOLUCION, SAB_UACI_PROCESOCOMPRAS.MEDIOSDIVULGACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAFIRMAACEPTACION, SAB_UACI_PROCESOCOMPRAS.AUUSUARIOCREACION, SAB_UACI_PROCESOCOMPRAS.AUFECHACREACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.AUUSUARIOMODIFICACION, SAB_UACI_PROCESOCOMPRAS.AUFECHAMODIFICACION, SAB_UACI_PROCESOCOMPRAS.ESTASINCRONIZADA, ")
        strSQL.Append("SAB_CAT_ESTADOPROCESOSCOMPRAS.DESCRIPCION AS ESTADO ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTADOPROCESOSCOMPRAS ON SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA = SAB_CAT_ESTADOPROCESOSCOMPRAS.IDESTADOPROCESOCOMPRA ")
        strSQL.Append("WHERE SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA = @IDESTADO ")
        strSQL.Append("AND SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION LIKE @IDPROCESO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(1).Value = IDESTADO
        args(2) = New SqlParameter("@IDPROCESO", SqlDbType.VarChar)
        args(2).Value = CODIGOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener las ofertas de un proceso de compra filtradas por estado del proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDESTADO">Identificador del estado</param> 'identificador del estado del proceso de compra
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param> 'identificador del proceso de compra
    ''' <returns>
    ''' Dataset con las ofertas que cumplen con el filtro
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_OFERTAPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' <item><description>SAB_CAT_ESTADOPROCESOSCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_OFERTAPROCESOCOMPRA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerOfertasProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADO As Int32, ByVal IDPROCESO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.NOMBREREPRESENTANTE, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.MONTOGARANTIA, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.ESTAHABILITADO, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.MONTOOFERTA, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.OBSERVACION, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.ACTIVOCIRCULANTE, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.PASIVOCIRCULANTE, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.ACTIVOTOTAL, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.PASIVOTOTAL, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.FECHAEXAMEN, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.PRESENTAREFERENCIASBANCARIAS, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.NOMBRE AS PROVEEDOR, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.DIRECCION, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.REPRESENTANTELEGAL, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.MATRICULA, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.TELEFONO, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.FAX, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.NIT, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.GIRO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDTITULAR, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDENTIDADSOLICITA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAENVIONOTA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.COSTOBASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.LUGARAPERTURABASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DIRECCIONAPERTURABASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDMUNICIPIOAPERTURA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAINICIOAPERTURA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAFINAPERTURA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAREALIZADAAPERTURA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAPUBLICACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.LUGARRETIROBASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAINICIORETIRO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAFINRETIRO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.LUGARRECEPCIONOFERTA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DIRECCIONRECEPCIONOFERTA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDMUNICIPIORECEPCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAINICIORECEPCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAFINRECEPCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAINICIOPROCESOCOMPRA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAELABORACIONBASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAAPROBACIONBASE, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAINICIOACLARACIONES, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAFINACLARACIONES, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDENCARGADO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAINICIOCONSULTA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAFINCONSULTA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.PORCENTAJEFINANCIERO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.PORCENTAJEINDICESOLVENCIA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.PORCENTAJECAPITALTRABAJO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.PORCENTAJEENDEUDAMIENTO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.PORCENTAJEREFERENCIASBANC, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIAMTTOENTREGA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIAMTTOVIGENCIA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.LUGARMTTO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACUMPLIMIENTOVALOR, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACUMPLIMIENTOENTREGA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACUMPLIMIENTOVIGENCIA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.LUGARCUMPLIMIENTO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACALIDADVALOR, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACALIDADENTREGA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.GARANTIACALIDADVIGENCIA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.LUGARCALIDAD, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAINICIOANALISIS, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAFINANALISIS, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAFIRMARESOLUCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.NUMERORESOLUCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHALIMITEACEPTACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHANOTIFICACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAPUBLICACIONRESOLUCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.MEDIOSDIVULGACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAFIRMAACEPTACION, ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA AS ORDENLLEGADAOFERTA, ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS.FECHAENTREGA AS FECHAENTREGAOFERTA, ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS.PERSONAENTREGA AS PERSONAENTREGAOFERTA, ")
        strSQL.Append("SAB_CAT_ESTADOPROCESOSCOMPRAS.DESCRIPCION AS ESTADOPROCESO, ")
        strSQL.Append("SAB_CAT_TIPOCOMPRAS.DESCRIPCION AS COMPRAEJECUTAR ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA INNER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES ON SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ON ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS ON SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTADOPROCESOSCOMPRAS ON ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA = SAB_CAT_ESTADOPROCESOSCOMPRAS.IDESTADOPROCESOCOMPRA INNER JOIN SAB_CAT_TIPOCOMPRAS ON SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR = SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA ")
        strSQL.Append("WHERE SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA = @IDESTADO ")
        strSQL.Append("AND SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("ORDER BY SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(1).Value = IDESTADO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = IDPROCESO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' validar si faltan documentos faltantes de la oferta en la entrega 1
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param> 'identificador del proceso de compra
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param> 'identificador del proveedor
    ''' <returns>
    ''' verdadero si faltaron documentos en primera entrega
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_UACI_DOCUMENTOSOFERTA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function FaltanDocumentosOfertaEntrega1(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT count(*) ")
        strSQL.Append(" FROM SAB_UACI_DOCUMENTOSOFERTA ")
        strSQL.Append(" WHERE ENTREGADO1 = 2 ") 'falto docuimentos
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

    ''' <summary>
    ''' validacion si falta documentos de la oferta para la segunda entrega
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param> 'identificador del proceso de compra
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param> 'identificador del proveedor
    ''' <returns>
    ''' verdadero si falta documentacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DOCUMENTOSOFERTA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function FaltanDocumentosOfertaEntrega2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_UACI_DOCUMENTOSOFERTA ")
        strSQL.Append(" WHERE ENTREGADO2 = 2 ") 'no entregados
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

    ''' <summary>
    ''' Validacion si faltaron entregar documentos del renglon para la entrega 1
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param> 'identificador del proceso
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param> 'identificador del proveedor
    ''' <returns>
    ''' verdadero si faltaron documentos que entregar
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_EXAMENRENGLON</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function FaltanDocumentosRenglonesOfertaEntrega1(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT count(*) ")
        strSQL.Append(" FROM SAB_UACI_EXAMENRENGLON ")
        strSQL.Append(" WHERE ENTREGADO1 = 2 ") 'faltan documentos
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

    ''' <summary>
    ''' Validacion si faltaron documentos del renglon para la segunda entrega
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param> 'identificador del procesod de compra
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param> 'identificacion del proveedor
    ''' <returns>
    ''' verdadero si falto documentacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_EXAMENRENGLON</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function FaltanDocumentosRenglonesOfertaEntrega2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_UACI_EXAMENRENGLON ")
        strSQL.Append(" WHERE ENTREGADO2 = 2 ") 'no entrego
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

    ''' <summary>
    ''' informacion para el reporte de hoja de analisis para un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param> 'identificador del proceso de compra
    ''' <returns>
    ''' Dataset con la informacion de hoja de analisis
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_OFERTAPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_DETALLEPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' <item><description>SAB_CAT_CATALOGOPRODUCTOSS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_CAT_TIPOCOMPRAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerHojaAnalisis(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO, SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR, SAB_UACI_OFERTAPROCESOCOMPRA.NOMBREREPRESENTANTE, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON, SAB_UACI_DETALLEOFERTA.CORRELATIVORENGLON, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.CASAREPRESENTADA, SAB_UACI_DETALLEOFERTA.MARCA, SAB_UACI_DETALLEOFERTA.ORIGEN, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.DESCRIPCIONPROVEEDOR, SAB_UACI_DETALLEOFERTA.VENCIMIENTO, SAB_UACI_DETALLEOFERTA.CANTIDAD, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO, SAB_UACI_DETALLEOFERTA.PLAZOENTREGA, SAB_UACI_DETALLEOFERTA.NUMEROCSSP, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.VIGENCIA, SAB_CAT_UNIDADMEDIDAS_1.DESCRIPCION AS UNIDAD, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.CANTIDAD AS CANTIDADPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.NUMEROENTREGAS AS ENTREGASPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.OBSERVACION AS OBSERVACIONPRODUCTO, ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS_1.DESCRIPCION AS UNIDADPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.CODIGO, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.IDTIPOPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.CONCENTRACION, SAB_CAT_CATALOGOPRODUCTOS.FORMAFARMACEUTICA, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.PRESENTACION, SAB_CAT_TIPOCOMPRAS.DESCRIPCION AS TIPOCOMPRA, ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA ")
        strSQL.Append("FROM SAB_CAT_TIPOCOMPRAS INNER JOIN ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS ON ")
        strSQL.Append("SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR LEFT OUTER JOIN ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA INNER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS AS SAB_CAT_UNIDADMEDIDAS_1 ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS_1.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS INNER JOIN ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA ON SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA = SAB_UACI_DETALLEOFERTA.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA ON SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON = SAB_UACI_DETALLEOFERTA.RENGLON AND ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA LEFT OUTER JOIN ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS ON ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO ON ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("ORDER BY SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene la hoja de analisis
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param>
    ''' <returns>Hoja de analisis en formato dataset</returns>

    Public Function ObtenerHojaAnalisis2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO, SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR, SAB_UACI_OFERTAPROCESOCOMPRA.NOMBREREPRESENTANTE, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON, SAB_UACI_DETALLEOFERTA.CORRELATIVORENGLON, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.CASAREPRESENTADA, SAB_UACI_DETALLEOFERTA.MARCA, SAB_UACI_DETALLEOFERTA.ORIGEN, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.DESCRIPCIONPROVEEDOR, SAB_UACI_DETALLEOFERTA.VENCIMIENTO, SAB_UACI_DETALLEOFERTA.CANTIDAD, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO, SAB_UACI_DETALLEOFERTA.PLAZOENTREGA, SAB_UACI_DETALLEOFERTA.NUMEROCSSP, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.VIGENCIA, SAB_CAT_UNIDADMEDIDAS_1.DESCRIPCION AS UNIDAD, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.CANTIDAD AS CANTIDADPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.NUMEROENTREGAS AS ENTREGASPRODUCTO, ")
        strSQL.Append("isnull (SAB_UACI_DETALLEPROCESOCOMPRA.OBSERVACION,'') AS OBSERVACIONPRODUCTO, ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS_1.DESCRIPCION AS UNIDADPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.CODIGO, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.IDTIPOPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.CONCENTRACION, SAB_CAT_CATALOGOPRODUCTOS.FORMAFARMACEUTICA, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.PRESENTACION, SAB_CAT_TIPOCOMPRAS.DESCRIPCION AS TIPOCOMPRA, ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA ")
        strSQL.Append("FROM SAB_CAT_TIPOCOMPRAS INNER JOIN ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS ON ")
        strSQL.Append("SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR LEFT OUTER JOIN ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA INNER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS AS SAB_CAT_UNIDADMEDIDAS_1 ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS_1.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS INNER JOIN ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA ON SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA = SAB_UACI_DETALLEOFERTA.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA ON SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON = SAB_UACI_DETALLEOFERTA.RENGLON AND ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA LEFT OUTER JOIN ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS ON ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO ON ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("ORDER BY SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Metodo que obtiene la hoja de analisis por proveedor
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <returns>Hoja de analisis en formato dataset</returns>

    Public Function ObtenerHojaAnalisisXProveedor(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO, SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA, ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR, SAB_UACI_OFERTAPROCESOCOMPRA.NOMBREREPRESENTANTE, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON, SAB_UACI_DETALLEOFERTA.CORRELATIVORENGLON, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.CASAREPRESENTADA, SAB_UACI_DETALLEOFERTA.MARCA, SAB_UACI_DETALLEOFERTA.ORIGEN, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.DESCRIPCIONPROVEEDOR, SAB_UACI_DETALLEOFERTA.VENCIMIENTO, SAB_UACI_DETALLEOFERTA.CANTIDAD, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO, SAB_UACI_DETALLEOFERTA.PLAZOENTREGA, SAB_UACI_DETALLEOFERTA.NUMEROCSSP, ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.VIGENCIA, SAB_CAT_UNIDADMEDIDAS_1.DESCRIPCION AS UNIDAD, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.CANTIDAD AS CANTIDADPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.NUMEROENTREGAS AS ENTREGASPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.OBSERVACION AS OBSERVACIONPRODUCTO, ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS_1.DESCRIPCION AS UNIDADPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.CODIGO, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.IDTIPOPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.CONCENTRACION, SAB_CAT_CATALOGOPRODUCTOS.FORMAFARMACEUTICA, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.PRESENTACION, SAB_CAT_TIPOCOMPRAS.DESCRIPCION AS TIPOCOMPRA, ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA, P.CODIGOPROVEEDOR + ' - ' + P.NOMBRE AS PROVEEDOR ")
        strSQL.Append("FROM SAB_CAT_TIPOCOMPRAS INNER JOIN ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS ON ")
        strSQL.Append("SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR LEFT OUTER JOIN ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA INNER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS AS SAB_CAT_UNIDADMEDIDAS_1 ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS_1.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO LEFT OUTER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS INNER JOIN ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA ON SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA = SAB_UACI_DETALLEOFERTA.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA ON SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON = SAB_UACI_DETALLEOFERTA.RENGLON AND ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA LEFT OUTER JOIN ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS ON ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO ON ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO ")
        strSQL.Append(" INNER Join SAB_CAT_PROVEEDORES P ON P.IDPROVEEDOR = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR ")
        strSQL.Append("WHERE SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Ejecuta el procedimiento almacenado para la generación del Programa de Distribución
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param> 'identificador del proceso de compra
    ''' <param name="USUARIOCREACION"></param> 'Usuario 
    ''' <param name="FECHACREACION"></param> 'Fecha
    ''' <param name="BORRAR"></param> 'parámetro que indica si se realiza el borrado de la tabla previo a la generación del programa de compra
    ''' <returns>
    ''' Valor entero que indica si que el proceso se realizó satisfactoriamente o nó
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>sproc_ProgramaDistribucion</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Juan José Rivas]      Creado
    ''' </history>
    Public Function generarProgramaDistribucion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal USUARIOCREACION As String, ByVal FECHACREACION As String, ByVal BORRAR As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_ProgramaDistribucion")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDPROCESOCOMPRA
        args(3) = New SqlParameter("@USUARIOCREACION", SqlDbType.VarChar)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = USUARIOCREACION
        args(4) = New SqlParameter("@FECHACREACION", SqlDbType.DateTime)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = FECHACREACION
        args(5) = New SqlParameter("@BORRAR", SqlDbType.VarChar)
        args(5).Direction = ParameterDirection.Input
        args(5).Value = BORRAR

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

    ''' <summary>
    ''' informacion para el reporte de resolucion de adjudicacion
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param> 'identificador del proceso de compras
    ''' <returns>
    ''' Dataset con la informacion de la resolucion de adjudicacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_OFERTAPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_DETALLEPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' <item><description>SAB_CAT_CATALOGOPRODUCTOSS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_CAT_TIPOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_ADJUDICACION</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerResolucionAdjudicacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32, Optional ByVal idAlmacen As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder

        Select Case idAlmacen
            Case Is = 0
                strSQL.Append("SELECT ")
                strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                strSQL.Append("OPC.IDPROVEEDOR, ")
                strSQL.Append("DO.RENGLON, ")
                strSQL.Append("DO.CORRELATIVORENGLON, ")
                strSQL.Append("DO.CANTIDAD, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("UM.DESCRIPCION UNIDAD, ")
                strSQL.Append("PC.CODIGOLICITACION, ")
                strSQL.Append("PC.TITULOLICITACION, ")
                strSQL.Append("PC.DESCRIPCIONLICITACION, ")
                strSQL.Append("DPC.IDPRODUCTO, ")
                strSQL.Append("UM1.DESCRIPCION UNIDADPRODUCTO, ")
                strSQL.Append("CP.CODIGO, ")
                strSQL.Append("CP.IDTIPOPRODUCTO, ")
                strSQL.Append("CP.NOMBRE, ")
                strSQL.Append("CP.CONCENTRACION, ")
                strSQL.Append("CP.FORMAFARMACEUTICA, ")
                strSQL.Append("CP.PRESENTACION, ")
                strSQL.Append("TC.DESCRIPCION AS TIPOCOMPRA, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("PC.IDPROCESOCOMPRA AS IDPROCESO2, ")
                strSQL.Append("A.CANTIDADRECOMENDACION, ")
                strSQL.Append("A.CANTIDADADJUDICADA, ")
                strSQL.Append("A.CANTIDADFIRME, ")
                strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
                strSQL.Append("ON DO.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
                strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
                strSQL.Append("ON OPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("ON PC.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                strSQL.Append("AND PC.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.RENGLON = DPC.RENGLON ")
                strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM1 ")
                strSQL.Append("ON DPC.IDUNIDADMEDIDA = UM1.IDUNIDADMEDIDA ")
                strSQL.Append("INNER JOIN SAB_CAT_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
                strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")

                strSQL.Append("ORDER BY RO.ORDENLLEGADA, DO.RENGLON ")


            Case Is = 114
                strSQL.Append("SELECT ")
                strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                strSQL.Append("OPC.IDPROVEEDOR, ")
                strSQL.Append("DO.RENGLON, ")
                strSQL.Append("DO.CORRELATIVORENGLON, ")
                strSQL.Append("DO.CANTIDAD, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("UM.DESCRIPCION UNIDAD, ")
                strSQL.Append("PC.CODIGOLICITACION, ")
                strSQL.Append("PC.TITULOLICITACION, ")
                strSQL.Append("PC.DESCRIPCIONLICITACION, ")
                strSQL.Append("DPC.IDPRODUCTO, ")
                strSQL.Append("UM1.DESCRIPCION UNIDADPRODUCTO, ")
                strSQL.Append("CP.CODIGO, ")
                strSQL.Append("CP.IDTIPOPRODUCTO, ")
                strSQL.Append("CP.NOMBRE, ")
                strSQL.Append("CP.CONCENTRACION, ")
                strSQL.Append("CP.FORMAFARMACEUTICA, ")
                strSQL.Append("CP.PRESENTACION, ")
                strSQL.Append("TC.DESCRIPCION AS TIPOCOMPRA, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("PC.IDPROCESOCOMPRA AS IDPROCESO2, ")
                strSQL.Append("A.CANTIDADRECOMENDACION, ")
                strSQL.Append("A.CANTIDADADJUDICADA, ")

                'strSQL.Append("A.CANTIDADFIRME, ")
                strSQL.Append("SUM(PD.CANTIDADADJUDICADA) AS CANTIDADFIRME, ")

                strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
                strSQL.Append("ON DO.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
                strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
                strSQL.Append("ON OPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("ON PC.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                strSQL.Append("AND PC.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.RENGLON = DPC.RENGLON ")
                strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM1 ")
                strSQL.Append("ON DPC.IDUNIDADMEDIDA = UM1.IDUNIDADMEDIDA ")
                strSQL.Append("INNER JOIN SAB_CAT_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
                strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON PD.IDESTABLECIMIENTO=DPC.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.RENGLON = DPC.RENGLON ")

                strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")

                strSQL.Append("AND PD.IDALMACEN=@IDALMACEN ")

                strSQL.Append(" GROUP BY OPC.IDESTABLECIMIENTO, OPC.IDPROCESOCOMPRA, OPC.IDPROVEEDOR, DO.RENGLON, DO.CORRELATIVORENGLON, DO.CANTIDAD, ")
                strSQL.Append(" DO.PRECIOUNITARIO, UM.DESCRIPCION, ")
                strSQL.Append("PC.CODIGOLICITACION, ")
                strSQL.Append("PC.TITULOLICITACION, ")
                strSQL.Append("PC.DESCRIPCIONLICITACION, ")
                strSQL.Append("DPC.IDPRODUCTO, ")
                strSQL.Append("UM1.DESCRIPCION, ")
                strSQL.Append("CP.CODIGO, ")
                strSQL.Append("CP.IDTIPOPRODUCTO, ")
                strSQL.Append("CP.NOMBRE, ")
                strSQL.Append("CP.CONCENTRACION, ")
                strSQL.Append("CP.FORMAFARMACEUTICA, ")
                strSQL.Append("CP.PRESENTACION, ")
                strSQL.Append("TC.DESCRIPCION, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("PC.IDPROCESOCOMPRA, ")
                strSQL.Append("A.CANTIDADRECOMENDACION, ")
                strSQL.Append("A.CANTIDADADJUDICADA, ")
                'strSQL.Append("A.CANTIDADFIRME, ")
                strSQL.Append("P.NOMBRE ")

                strSQL.Append("ORDER BY RO.ORDENLLEGADA, DO.RENGLON ")

            Case Is = 499
                strSQL.Append("SELECT ")
                strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                strSQL.Append("OPC.IDPROVEEDOR, ")
                strSQL.Append("DO.RENGLON, ")
                strSQL.Append("DO.CORRELATIVORENGLON, ")
                strSQL.Append("DO.CANTIDAD, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("UM.DESCRIPCION UNIDAD, ")
                strSQL.Append("PC.CODIGOLICITACION, ")
                strSQL.Append("PC.TITULOLICITACION, ")
                strSQL.Append("PC.DESCRIPCIONLICITACION, ")
                strSQL.Append("DPC.IDPRODUCTO, ")
                strSQL.Append("UM1.DESCRIPCION UNIDADPRODUCTO, ")
                strSQL.Append("CP.CODIGO, ")
                strSQL.Append("CP.IDTIPOPRODUCTO, ")
                strSQL.Append("CP.NOMBRE, ")
                strSQL.Append("CP.CONCENTRACION, ")
                strSQL.Append("CP.FORMAFARMACEUTICA, ")
                strSQL.Append("CP.PRESENTACION, ")
                strSQL.Append("TC.DESCRIPCION AS TIPOCOMPRA, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("PC.IDPROCESOCOMPRA AS IDPROCESO2, ")
                strSQL.Append("A.CANTIDADRECOMENDACION, ")
                strSQL.Append("A.CANTIDADADJUDICADA, ")

                'strSQL.Append("A.CANTIDADFIRME, ")
                strSQL.Append("SUM(PD.CANTIDADADJUDICADA) AS CANTIDADFIRME, ")

                strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
                strSQL.Append("ON DO.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
                strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
                strSQL.Append("ON OPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("ON PC.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                strSQL.Append("AND PC.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.RENGLON = DPC.RENGLON ")
                strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM1 ")
                strSQL.Append("ON DPC.IDUNIDADMEDIDA = UM1.IDUNIDADMEDIDA ")
                strSQL.Append("INNER JOIN SAB_CAT_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
                strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON PD.IDESTABLECIMIENTO=DPC.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.RENGLON = DPC.RENGLON ")

                strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")

                strSQL.Append("AND PD.IDALMACEN=@IDALMACEN ")

                strSQL.Append(" GROUP BY OPC.IDESTABLECIMIENTO, OPC.IDPROCESOCOMPRA, OPC.IDPROVEEDOR, DO.RENGLON, DO.CORRELATIVORENGLON, DO.CANTIDAD, ")
                strSQL.Append(" DO.PRECIOUNITARIO, UM.DESCRIPCION, ")
                strSQL.Append("PC.CODIGOLICITACION, ")
                strSQL.Append("PC.TITULOLICITACION, ")
                strSQL.Append("PC.DESCRIPCIONLICITACION, ")
                strSQL.Append("DPC.IDPRODUCTO, ")
                strSQL.Append("UM1.DESCRIPCION, ")
                strSQL.Append("CP.CODIGO, ")
                strSQL.Append("CP.IDTIPOPRODUCTO, ")
                strSQL.Append("CP.NOMBRE, ")
                strSQL.Append("CP.CONCENTRACION, ")
                strSQL.Append("CP.FORMAFARMACEUTICA, ")
                strSQL.Append("CP.PRESENTACION, ")
                strSQL.Append("TC.DESCRIPCION, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("PC.IDPROCESOCOMPRA, ")
                strSQL.Append("A.CANTIDADRECOMENDACION, ")
                strSQL.Append("A.CANTIDADADJUDICADA, ")
                'strSQL.Append("A.CANTIDADFIRME, ")
                strSQL.Append("P.NOMBRE ")

                strSQL.Append("ORDER BY RO.ORDENLLEGADA, DO.RENGLON ")
            Case Is = 1
                strSQL.Append("SELECT ")
                strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                strSQL.Append("OPC.IDPROVEEDOR, ")
                strSQL.Append("DO.RENGLON, ")
                strSQL.Append("DO.CORRELATIVORENGLON, ")
                strSQL.Append("DO.CANTIDAD, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("UM.DESCRIPCION UNIDAD, ")
                strSQL.Append("PC.CODIGOLICITACION, ")
                strSQL.Append("PC.TITULOLICITACION, ")
                strSQL.Append("PC.DESCRIPCIONLICITACION, ")
                strSQL.Append("DPC.IDPRODUCTO, ")
                strSQL.Append("UM1.DESCRIPCION UNIDADPRODUCTO, ")
                strSQL.Append("CP.CODIGO, ")
                strSQL.Append("CP.IDTIPOPRODUCTO, ")
                strSQL.Append("CP.NOMBRE, ")
                strSQL.Append("CP.CONCENTRACION, ")
                strSQL.Append("CP.FORMAFARMACEUTICA, ")
                strSQL.Append("CP.PRESENTACION, ")
                strSQL.Append("TC.DESCRIPCION AS TIPOCOMPRA, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("PC.IDPROCESOCOMPRA AS IDPROCESO2, ")
                strSQL.Append("A.CANTIDADRECOMENDACION, ")
                strSQL.Append("A.CANTIDADADJUDICADA, ")

                'strSQL.Append("A.CANTIDADFIRME, ")
                strSQL.Append("SUM(PD.CANTIDADADJUDICADA) AS CANTIDADFIRME, ")

                strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
                strSQL.Append("ON DO.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
                strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
                strSQL.Append("ON OPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("ON PC.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                strSQL.Append("AND PC.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.RENGLON = DPC.RENGLON ")
                strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM1 ")
                strSQL.Append("ON DPC.IDUNIDADMEDIDA = UM1.IDUNIDADMEDIDA ")
                strSQL.Append("INNER JOIN SAB_CAT_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
                strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON PD.IDESTABLECIMIENTO=DPC.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.RENGLON = DPC.RENGLON ")

                strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")

                strSQL.Append("AND PD.IDALMACEN NOT IN (114,499) ")

                strSQL.Append(" GROUP BY OPC.IDESTABLECIMIENTO, OPC.IDPROCESOCOMPRA, OPC.IDPROVEEDOR, DO.RENGLON, DO.CORRELATIVORENGLON, DO.CANTIDAD, ")
                strSQL.Append(" DO.PRECIOUNITARIO, UM.DESCRIPCION, ")
                strSQL.Append("PC.CODIGOLICITACION, ")
                strSQL.Append("PC.TITULOLICITACION, ")
                strSQL.Append("PC.DESCRIPCIONLICITACION, ")
                strSQL.Append("DPC.IDPRODUCTO, ")
                strSQL.Append("UM1.DESCRIPCION, ")
                strSQL.Append("CP.CODIGO, ")
                strSQL.Append("CP.IDTIPOPRODUCTO, ")
                strSQL.Append("CP.NOMBRE, ")
                strSQL.Append("CP.CONCENTRACION, ")
                strSQL.Append("CP.FORMAFARMACEUTICA, ")
                strSQL.Append("CP.PRESENTACION, ")
                strSQL.Append("TC.DESCRIPCION, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("PC.IDPROCESOCOMPRA, ")
                strSQL.Append("A.CANTIDADRECOMENDACION, ")
                strSQL.Append("A.CANTIDADADJUDICADA, ")
                'strSQL.Append("A.CANTIDADFIRME, ")
                strSQL.Append("P.NOMBRE ")

                strSQL.Append("ORDER BY RO.ORDENLLEGADA, DO.RENGLON ")
        End Select

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        If idAlmacen = 114 Or idAlmacen = 499 Then
            args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
            args(2).Value = idAlmacen
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns></returns>

    Public Function obtenerRenglonesProcesoCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, ")
        strSQL.Append(" NOMBRE + ' ' + CONCENTRACION + ' ' + FORMAFARMACEUTICA + ' ' + PRESENTACION AS DESCRIPCION ")
        strSQL.Append(" FROM SAB_UACI_DETALLEPROCESOCOMPRA INNER JOIN ")
        strSQL.Append("  SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append("  SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO ")
        strSQL.Append(" WHERE (SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtener el programa de distribución
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDRENGLON">Identificador del renglon</param>
    ''' <returns>Programa de distribucion en formato dataset</returns>

    Public Function obtenerProgramaDistribucion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDRENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_ESTABLECIMIENTOS_1.NOMBRE AS ESTABLECIMIENTO_SOLICITA, SAB_UACI_PROGRAMADISTRIBUCION.RENGLON, ")
        strSQL.Append(" SAB_CAT_ALMACENES.NOMBRE AS Almacen, SAB_UACI_PROGRAMADISTRIBUCION.CANTIDADSOLICITADA, ")
        strSQL.Append(" SAB_UACI_PROGRAMADISTRIBUCION.CANTIDADADJUDICADA ")
        strSQL.Append(" FROM SAB_UACI_PROGRAMADISTRIBUCION INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS ON ")
        strSQL.Append(" SAB_UACI_PROGRAMADISTRIBUCION.IDESTABLECIMIENTO = SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS AS SAB_CAT_ESTABLECIMIENTOS_1 ON ")
        strSQL.Append(" SAB_UACI_PROGRAMADISTRIBUCION.IDESTABLECIMIENTOSOLICITA = SAB_CAT_ESTABLECIMIENTOS_1.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ALMACENES ON SAB_UACI_PROGRAMADISTRIBUCION.IDALMACEN = SAB_CAT_ALMACENES.IDALMACEN ")
        strSQL.Append(" WHERE (SAB_UACI_PROGRAMADISTRIBUCION.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_PROGRAMADISTRIBUCION.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (SAB_UACI_PROGRAMADISTRIBUCION.RENGLON = " & IDRENGLON & ") AND (SAB_UACI_PROGRAMADISTRIBUCION.CANTIDADSOLICITADA > 0)")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Actualizacion de la notificación
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad del proceso de compra</param>
    ''' <returns>Valor entero con el resultado de la actualización</returns>

    Public Function ActualizarNotificacion(ByVal aEntidad As PROCESOCOMPRAS) As Integer

        Dim lID As Long
        If aEntidad.IDPROCESOCOMPRA = 0 _
            Or aEntidad.IDPROCESOCOMPRA = Nothing Then

            lID = Me.ObtenerID(aEntidad)

            If lID = -1 Then Return -1

            aEntidad.IDPROCESOCOMPRA = lID

            Return Agregar(aEntidad)

        End If

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" FECHALIMITEACEPTACION = @FECHALIMITEACEPTACION, ")
        strSQL.Append(" FECHANOTIFICACION = @FECHANOTIFICACION, ")
        strSQL.Append(" FECHAPUBLICACIONRESOLUCION = @FECHAPUBLICACIONRESOLUCION, ")
        strSQL.Append(" MEDIOSDIVULGACION = @MEDIOSDIVULGACION, ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@FECHALIMITEACEPTACION", SqlDbType.DateTime)
        args(0).Value = IIf(aEntidad.FECHALIMITEACEPTACION = Nothing, DBNull.Value, aEntidad.FECHALIMITEACEPTACION)
        args(1) = New SqlParameter("@FECHANOTIFICACION", SqlDbType.DateTime)
        args(1).Value = IIf(aEntidad.FECHANOTIFICACION = Nothing, DBNull.Value, aEntidad.FECHANOTIFICACION)
        args(2) = New SqlParameter("@FECHAPUBLICACIONRESOLUCION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.FECHAPUBLICACIONRESOLUCION = Nothing, DBNull.Value, aEntidad.FECHAPUBLICACIONRESOLUCION)
        args(3) = New SqlParameter("@MEDIOSDIVULGACION", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.MEDIOSDIVULGACION = Nothing, DBNull.Value, aEntidad.MEDIOSDIVULGACION)
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)
        args(5) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(5).Value = IIf(aEntidad.IDPROCESOCOMPRA = Nothing, DBNull.Value, aEntidad.IDPROCESOCOMPRA)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' obtener todos aquello documentos que no fuenron entregados por el ofertante en la primera entrega
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param> 'identificador del proceso
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param> 'identificador del proveedor
    ''' <returns>
    ''' Dataset con la informacion de la documentacion faltante del ofertante
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_OFERTAPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_DOCUMENTOSOFERTA</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_DOCUMENTOSBASE</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 

    Public Function ObtenerDocumentosFaltantesOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO, SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR, SAB_UACI_DOCUMENTOSOFERTA.IDDOCUMENTOBASE, ")
        strSQL.Append(" SAB_UACI_DOCUMENTOSOFERTA.ENTREGADO1, SAB_UACI_DOCUMENTOSOFERTA.ENTREGADO2, ")
        strSQL.Append(" SAB_CAT_DOCUMENTOSBASE.IDTIPODOCUMENTOBASE, SAB_CAT_DOCUMENTOSBASE.DESCRIPCION AS DOCUMENTOBASE, ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA, SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA AS ORDENLLEGADAOFERTA, ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.OBSERVACIONDOCUMENTO ")
        strSQL.Append(" FROM SAB_UACI_OFERTAPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_DOCUMENTOSOFERTA ON SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_DOCUMENTOSOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_DOCUMENTOSOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_DOCUMENTOSOFERTA.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_DOCUMENTOSBASE ON ")
        strSQL.Append(" SAB_UACI_DOCUMENTOSOFERTA.IDDOCUMENTOBASE = SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS ON ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS ON ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND SAB_UACI_DOCUMENTOSOFERTA.ENTREGADO1 = 2 ")
   



        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener todos aquellos documentos que no fuenron entregados por el ofertante para un renglon especifico en la primera entrega
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param> 'identificador del proceso de compra
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param> 'identificador del proveedor
    ''' <returns>
    ''' Dataset con los documentos faltantes para el renglon
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_OFERTAPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_EXAMENRENGLON</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_DOCUMENTOSBASE</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDocumentosFaltantesRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDGRUPOREQTEC As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO, SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR, SAB_UACI_DETALLEOFERTA.IDDETALLE, SAB_UACI_DETALLEOFERTA.RENGLON, ")
        strSQL.Append(" SAB_CAT_DOCUMENTOSBASE.IDTIPODOCUMENTOBASE, SAB_CAT_DOCUMENTOSBASE.DESCRIPCION AS DOCUMENTOBASE, ")
        strSQL.Append(" SAB_UACI_EXAMENRENGLON.ENTREGADO1, SAB_UACI_EXAMENRENGLON.ENTREGADO2, SAB_UACI_EXAMENRENGLON.IDDOCUMENTOBASE, ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.OBSERVACIONDOCUMENTO, SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA ")
        strSQL.Append(" FROM SAB_UACI_OFERTAPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS ON ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_UACI_EXAMENRENGLON ON SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_EXAMENRENGLON.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_EXAMENRENGLON.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_UACI_EXAMENRENGLON.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDDETALLE = SAB_UACI_EXAMENRENGLON.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_CAT_DOCUMENTOSBASE ON SAB_UACI_EXAMENRENGLON.IDDOCUMENTOBASE = SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE ")
        strSQL.Append("AND SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND SAB_UACI_EXAMENRENGLON.ENTREGADO1 = 2 ")
        strSQL.Append("AND (SAB_CAT_DOCUMENTOSBASE.IDGRUPOREQTEC = @IDGRUPOREQTEC or  @IDGRUPOREQTEC=0)  ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDGRUPOREQTEC", SqlDbType.Int)
        args(3).Value = IDGRUPOREQTEC

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener el examen financiero de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Examen financiero en formato de dataset</returns>

    Public Function obtenerExamenFinanciero(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT TC.DESCRIPCION, PC.CODIGOLICITACION, PC.TITULOLICITACION, RO.ORDENLLEGADA, PV.NOMBRE, OPC.ACTIVOCIRCULANTE, ")
        strSQL.Append(" OPC.PASIVOCIRCULANTE, OPC.PASIVOTOTAL, OPC.ACTIVOTOTAL, CASE WHEN EO.REFERENCIABANCARIA = 0 THEN 'NO' ELSE 'SI' END AS REFERENCIAS, ")
        strSQL.Append(" EO.OBSERVACION AS OBSERVACIONDOCUMENTO, PC.DESCRIPCIONLICITACION ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS AS TC ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA AS OPC ON PC.IDESTABLECIMIENTO = OPC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" PC.IDPROCESOCOMPRA = OPC.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS PV ON OPC.IDPROVEEDOR = PV.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS AS RO ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR AND ")
        strSQL.Append(" OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_UACI_EXAMENOFERTA AS EO ON OPC.IDPROVEEDOR = EO.IDPROVEEDOR AND OPC.IDPROCESOCOMPRA = EO.IDPROCESOCOMPRA AND ")
        strSQL.Append(" OPC.IDESTABLECIMIENTO = EO.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ORDER BY RO.ORDENLLEGADA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Informacion del examen de evaluación financiero
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Examen de evaluación financiero en formato dataset</returns>

    Public Function obtenerExamenEvalFinanciero(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_TIPOCOMPRAS.DESCRIPCION, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, ")
        strSQL.Append("       SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA, SAB_UACI_EXAMENOFERTA.INDICESOLVENCIA, SAB_UACI_EXAMENOFERTA.PONDERACIONSOLVENCIA, ")
        strSQL.Append(" SAB_UACI_EXAMENOFERTA.CAPITALTRABAJO, SAB_UACI_EXAMENOFERTA.PONDERACIONCAPITAL, SAB_UACI_EXAMENOFERTA.INDICEENDEUDAMIENTO, ")
        strSQL.Append(" SAB_UACI_EXAMENOFERTA.PONDERACIONENDEUDAMIENTO, CASE WHEN SAB_UACI_EXAMENOFERTA.REFERENCIABANCARIA = 0 THEN 'NO' ELSE 'SI' END AS REFERENCIAS, SAB_UACI_EXAMENOFERTA.PONDERACIONREFERENCIA, ")
        strSQL.Append(" SAB_UACI_EXAMENOFERTA.PONDERACIONSOLVENCIA+SAB_UACI_EXAMENOFERTA.PONDERACIONCAPITAL + SAB_UACI_EXAMENOFERTA.PONDERACIONENDEUDAMIENTO + SAB_UACI_EXAMENOFERTA.PONDERACIONREFERENCIA ")
        strSQL.Append(" AS TOTAL, SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS ON SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR = SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_EXAMENOFERTA ON SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_EXAMENOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_EXAMENOFERTA.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS ON SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_EXAMENOFERTA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append(" ORDER BY SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene los documentos de oferta
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <returns>Documentacion por oferta en formato dataset</returns>

    Public Function obtenerDocumentosOfertaEP(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_TIPOCOMPRAS.DESCRIPCION, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, ")
        strSQL.Append("       SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE, SAB_CAT_DOCUMENTOSBASE.DESCRIPCION AS DOCUMENTO, CASE WHEN (CASE WHEN (entregado1 <> 0 AND ")
        strSQL.Append(" entregado2 <> 0) THEN Entregado2 ELSE Entregado1 END) = 1 THEN 'CUMPLE' WHEN (CASE WHEN (entregado1 <> 0 AND entregado2 <> 0) ")
        strSQL.Append(" THEN Entregado2 ELSE Entregado1 END) = 2 THEN 'NO CUMPLE' WHEN (CASE WHEN (entregado1 <> 0 AND entregado2 <> 0) ")
        strSQL.Append(" THEN Entregado2 ELSE Entregado1 END) = 3 THEN 'NO APLICA' END AS ENTREGADO, SAB_UACI_OFERTAPROCESOCOMPRA.OBSERVACIONDOCUMENTO, ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA AS NOFERTA, SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS ON SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR = SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_UACI_DOCUMENTOSOFERTA ON SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_DOCUMENTOSOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_DOCUMENTOSOFERTA.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_DOCUMENTOSBASE ON SAB_UACI_DOCUMENTOSOFERTA.IDDOCUMENTOBASE = SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE INNER JOIN ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA ON SAB_UACI_DOCUMENTOSOFERTA.IDPROVEEDOR = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_DOCUMENTOSOFERTA.IDPROCESOCOMPRA = SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_DOCUMENTOSOFERTA.IDESTABLECIMIENTO = SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS ON SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND ")
        strSQL.Append(" (SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = @IDPROVEEDOR) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene el examen por renglon de cada oferta
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="IDDETALLE">Identificador del detalle</param>
    ''' <returns>Examen por renglon por oferta en formato dataset</returns>

    Public Function obtenerExamenRenglonEP(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal idrectec As Integer, ByVal IDPRODUCTO As String) As DataSet
        'SE ADICIONA LETANIA NO CUMPLE SEGUN PETICION UACI 18/06/2012
        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("TC.DESCRIPCION, ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("PC.TITULOLICITACION, ")
        strSQL.Append("DB.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION AS DOCUMENTO, vp.corrproducto, vp.desclargo, ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN (CASE WHEN (ER.ENTREGADO1 <> 0 AND ER.ENTREGADO2 <> 0) THEN ER.ENTREGADO2 ELSE ER.ENTREGADO1 END) = 1 THEN 'CUMPLE CON LOS REQUISITOS TECNICOS SOLICITADOS' ")
        strSQL.Append("WHEN (CASE WHEN (ER.ENTREGADO1 <> 0 AND ER.ENTREGADO2 <> 0) THEN ER.ENTREGADO2 ELSE ER.ENTREGADO1 END) = 2 THEN 'NO CUMPLE CON LOS REQUISITOS TECNICOS SOLICITADOS' ")
        strSQL.Append("WHEN (CASE WHEN (ER.ENTREGADO1 <> 0 AND ER.ENTREGADO2 <> 0) THEN ER.ENTREGADO2 ELSE ER.ENTREGADO1 END) = 3 THEN 'NO APLICA' ")
        strSQL.Append("END AS ENTREGADO, ")
        strSQL.Append("DO.RENGLON, ")
        strSQL.Append("DO.CORRELATIVORENGLON, ")
        strSQL.Append("DO.OBSERVACIONDOCUMENTO, ")
        strSQL.Append("RO.ORDENLLEGADA AS NOFERTA, ")
        strSQL.Append("PC.DESCRIPCIONLICITACION ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_UACI_EXAMENRENGLON ER ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = ER.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = ER.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON ER.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON ER.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND ER.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND ER.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND ER.IDDETALLE = DO.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR ")

        strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA dpc ON do.IDESTABLECIMIENTO = dpc.IDESTABLECIMIENTO AND do.IDPROCESOCOMPRA = dpc.IDPROCESOCOMPRA AND do.RENGLON = dpc.RENGLON  ")
        strSQL.Append("inner join vv_CATALOGOPRODUCTOS vp on vp.IDPRODUCTO=dpc.IDPRODUCTO ")
        If Not IDPRODUCTO = "" Then
            strSQL.Append("INNER JOIN SAB_CAT_GRUPOSREQTECNICOS GRT ON GRT.IDGRUPOREQ = DB.IDGRUPOREQTEC  ")
            strSQL.Append("inner JOIN SAB_UACI_GRUPOREQTEC_PRODUCTOS GP  ON GP.IDGRUPOREQ = GRT.IDGRUPOREQ  ")
        End If
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = @IDDETALLE ")
        strSQL.Append("and (db.IDGRUPOREQTEC=@IDGRUPOREQTEC or @IDGRUPOREQTEC  = 0) ")
        If Not IDPRODUCTO = "" Then
            strSQL.Append("AND GP.IDPRODUCTO = @IDPRODUCTO ")
        End If
        'strSQL.Append(" AND ER.ENTREGADO1 = 2 ")
        ' strSQL.Append(" AND ER.ENTREGADO1 <> 3 ")




        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE
        args(4) = New SqlParameter("@IDGRUPOREQTEC", SqlDbType.Int)
        args(4).Value = idrectec
        If Not IDPRODUCTO = "" Then
            args(5) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
            args(5).Value = IDPRODUCTO
        End If    
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el tipo de proceso de compras.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Devuelve el tipo de proceso de compra.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_TIPOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_MODALIDADESCOMPRA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function obtenerTipoProcesoCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("   SELECT SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR, SAB_CAT_TIPOCOMPRAS.DESCRIPCION, SAB_CAT_TIPOCOMPRAS.IDMODALIDADCOMPRA ")
        strSQL.Append("   FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append("                      SAB_CAT_TIPOCOMPRAS ON SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR = SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA INNER JOIN ")
        strSQL.Append("                      SAB_CAT_MODALIDADESCOMPRA ON SAB_CAT_TIPOCOMPRAS.IDMODALIDADCOMPRA = SAB_CAT_MODALIDADESCOMPRA.IDMODALIDADCOMPRA ")
        strSQL.Append(" WHERE (SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Validación de existencia de la base
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>La base en formato dataset</returns>

    Public Function validaExisteBase(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDTITULAR, IDENTIDADSOLICITA, FECHAENVIONOTA, COSTOBASE, LUGARAPERTURABASE, ")
        strSQL.Append(" DIRECCIONAPERTURABASE, IDMUNICIPIOAPERTURA, FECHAHORAINICIOAPERTURA, FECHAHORAFINAPERTURA, FECHAREALIZADAAPERTURA, ")
        strSQL.Append(" FECHAPUBLICACION, LUGARRETIROBASE, FECHAHORAINICIORETIRO, FECHAHORAFINRETIRO, LUGARRECEPCIONOFERTA, ")
        strSQL.Append(" DIRECCIONRECEPCIONOFERTA, IDMUNICIPIORECEPCION, FECHAHORAINICIORECEPCION, FECHAHORAFINRECEPCION, CODIGOLICITACION, ")
        strSQL.Append(" TITULOLICITACION, DESCRIPCIONLICITACION, IDTIPOCOMPRASUGERIDO, IDTIPOCOMPRAEJECUTAR, IDESTADOPROCESOCOMPRA, IDENCARGADO, ")
        strSQL.Append(" FECHAINICIOPROCESOCOMPRA, FECHAELABORACIONBASE, FECHAAPROBACIONBASE, FECHAINICIOACLARACIONES, FECHAFINACLARACIONES, ")
        strSQL.Append(" FECHAINICIOCONSULTA, FECHAFINCONSULTA, PORCENTAJEFINANCIERO, PORCENTAJEINDICESOLVENCIA, PORCENTAJECAPITALTRABAJO, ")
        strSQL.Append(" PORCENTAJEENDEUDAMIENTO, PORCENTAJEREFERENCIASBANC, GARANTIAMTTOENTREGA, GARANTIAMTTOVIGENCIA, LUGARMTTO, ")
        strSQL.Append(" GARANTIACUMPLIMIENTOVALOR, GARANTIACUMPLIMIENTOENTREGA, GARANTIACUMPLIMIENTOVIGENCIA, LUGARCUMPLIMIENTO, ")
        strSQL.Append(" GARANTIACALIDADVALOR, GARANTIACALIDADENTREGA, GARANTIACALIDADVIGENCIA, LUGARCALIDAD, FECHAINICIOANALISIS, FECHAFINANALISIS, ")
        strSQL.Append(" FECHAFIRMARESOLUCION, NUMERORESOLUCION, FECHALIMITEACEPTACION, FECHANOTIFICACION, FECHAPUBLICACIONRESOLUCION, ")
        strSQL.Append(" MEDIOSDIVULGACION, FECHAFIRMAACEPTACION, VIGENCIACOTIZACION, GARANTIACUMPLIMIENTOORDENCOMPRA, TIEMPOENTREGA ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene los parametro para la generación de contratos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Parametros en formato dataset</returns>

    Public Function obtenerParametrosGeneraContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT CODIGOLICITACION, TITULOLICITACION, FECHAFIRMAACEPTACION ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Chequea el estado de las solicitudes.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Valor indicando el resultado del chequeo de las solicitudes</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDESPROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function ChequearEstadoSolicitudes(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDPROCESOCOMPRA, SPC.IDESTABLECIMIENTO, SPC.IDSOLICITUD, IDESTADO ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDES S ON SPC.IDESTABLECIMIENTOSOLICITUD = S.IDESTABLECIMIENTO AND ")
        strSQL.Append("    SPC.IDSOLICITUD = S.IDSOLICITUD ")
        strSQL.Append("    WHERE (SPC.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & " And IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")
        strSQL.Append(" AND IDESTADO<>6 ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        If ds.Tables(0).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    ''' <summary>
    ''' Obtiene un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Un Proceso de compra en formato dataset</returns>

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene los proveedores de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Listado de proveedores en formato dataset</returns>

    Public Function obtenerProveedoresProcesoCompraDS(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR, SAB_CAT_PROVEEDORES.NOMBRE, SAB_CAT_PROVEEDORES.REPRESENTANTELEGAL, ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.CANTIDADFIRME ")
        strSQL.Append(" FROM SAB_UACI_OFERTAPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_ADJUDICACION ON SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_OFERTAPROCESOCOMPRA.IDPROVEEDOR = SAB_UACI_ADJUDICACION.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_OFERTAPROCESOCOMPRA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_OFERTAPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (SAB_UACI_ADJUDICACION.CANTIDADFIRME > 0) ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene los proveedores de los contratos de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDANALISTA">Identificador del analista</param>
    ''' <returns>Listado de proveedores en formato dataset</returns>

    Public Function obtenerProveedoresContratoDS(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDANALISTA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        'strSQL.Append("SELECT DISTINCT ")
        'strSQL.Append("OPC.IDPROVEEDOR, P.NOMBRE, P.REPRESENTANTELEGAL, RO.ORDENLLEGADA AS NUMEROOFERTA, ")
        'strSQL.Append("CASE ")
        'strSQL.Append("WHEN C.IDESTADOCONTRATO IS NULL THEN 'No' ")
        'strSQL.Append("WHEN C.IDESTADOCONTRATO = 1 THEN 'Si' ")
        'strSQL.Append("WHEN C.IDESTADOCONTRATO = 2 THEN 'Si' ")
        'strSQL.Append("END AS GENERADO, ")
        'strSQL.Append("(SELECT COUNT(IDDETALLE) ")
        'strSQL.Append("FROM SAB_UACI_ADJUDICACION AS A1 ")
        'strSQL.Append("WHERE (A1.IDESTABLECIMIENTO = OPC.IDESTABLECIMIENTO) AND ")
        'strSQL.Append("(A1.IDPROCESOCOMPRA = OPC.IDPROCESOCOMPRA) AND ")
        'strSQL.Append("(A1.IDPROVEEDOR = OPC.IDPROVEEDOR) AND ")
        'strSQL.Append("(A1.CANTIDADFIRME > 0)) AS RENGLONESADJUDICADOS, ")
        'strSQL.Append("NA.NOMBREPERSONAFIRMA ")
        'strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA AS OPC ")
        'strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES AS P ON ")
        'strSQL.Append("OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
        'strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
        'strSQL.Append("OPC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        'strSQL.Append("OPC.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA AND ")
        'strSQL.Append("OPC.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        'strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOS AS C ON ")
        'strSQL.Append("CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        'strSQL.Append("CPC.IDPROVEEDOR = C.IDPROVEEDOR AND ")
        'strSQL.Append("CPC.IDCONTRATO = C.IDCONTRATO ")
        'strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION AS A ON ")
        'strSQL.Append("OPC.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO AND ")
        'strSQL.Append("OPC.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA AND ")
        'strSQL.Append("OPC.IDPROVEEDOR = A.IDPROVEEDOR ")
        'strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS AS RO ON ")
        'strSQL.Append("OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO AND ")
        'strSQL.Append("OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA AND ")
        'strSQL.Append("OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
        'strSQL.Append("INNER JOIN SAB_UACI_ANALISTAPROVEEDORES AS AP ON ")
        'strSQL.Append("OPC.IDESTABLECIMIENTO = AP.IDESTABLECIMIENTO AND ")
        'strSQL.Append("OPC.IDPROVEEDOR = AP.IDPROVEEDOR ")
        'strSQL.Append("LEFT OUTER JOIN SAB_UACI_NOTASACEPTACION NA ON ")
        'strSQL.Append("OPC.IDPROVEEDOR = NA.IDPROVEEDOR AND ")
        'strSQL.Append("OPC.IDPROCESOCOMPRA = NA.IDPROCESOCOMPRA AND ")
        'strSQL.Append("OPC.IDESTABLECIMIENTO = NA.IDESTABLECIMIENTO ")
        'strSQL.Append("WHERE (OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        'strSQL.Append("AND (OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        'strSQL.Append("AND (AP.IDANALISTA = @IDANALISTA OR @IDANALISTA = 0) ")
        'strSQL.Append("AND (A.CANTIDADFIRME > 0) ")
        'strSQL.Append("ORDER BY NUMEROOFERTA ")
        strSQL.Append("SELECT DISTINCT A.IDPROVEEDOR, P.NOMBRE, P.REPRESENTANTELEGAL, ")
        strSQL.Append("RO.ORDENLLEGADA AS NUMEROOFERTA, ")
        strSQL.Append(" CASE WHEN C.IDESTADOCONTRATO IS NULL THEN 'No' WHEN C.IDESTADOCONTRATO = 1 THEN 'Si' WHEN C.IDESTADOCONTRATO = 2 THEN 'Si' END AS GENERADO,  ")
        strSQL.Append(" ")
        strSQL.Append("(SELECT COUNT(IDDETALLE)  ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION AS A1  ")
        strSQL.Append("WHERE (A1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO) AND (A1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA) AND (A1.IDPROVEEDOR = A.IDPROVEEDOR) AND (A1.CANTIDADFIRME > 0))   ")
        strSQL.Append("AS RENGLONESADJUDICADOS,  ")
        strSQL.Append(" ")
        strSQL.Append("NA.NOMBREPERSONAFIRMA ")
        strSQL.Append(" ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION AS A  ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES AS P ON  ")
        strSQL.Append("A.IDPROVEEDOR = P.IDPROVEEDOR  ")
        strSQL.Append(" ")
        strSQL.Append(" ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON  ")
        strSQL.Append("A.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND A.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA AND  ")
        strSQL.Append("A.IDPROVEEDOR = CPC.IDPROVEEDOR  ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOS AS C  ")
        strSQL.Append("ON CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND CPC.IDPROVEEDOR = C.IDPROVEEDOR AND ")
        strSQL.Append(" CPC.IDCONTRATO = C.IDCONTRATO  ")
        strSQL.Append(" ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS AS RO ON ")
        strSQL.Append(" A.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO AND A.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA AND ")
        strSQL.Append(" A.IDPROVEEDOR = RO.IDPROVEEDOR   ")

        strSQL.Append(" ")
        strSQL.Append("INNER JOIN SAB_UACI_ANALISTAPROVEEDORES AS AP ON ")
        strSQL.Append(" A.IDESTABLECIMIENTO = AP.IDESTABLECIMIENTO  ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = AP.IDPROCESOCOMPRA  ")
        strSQL.Append("AND A.IDPROVEEDOR = AP.IDPROVEEDOR  ")
        strSQL.Append(" ")
        strSQL.Append(" ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_NOTASACEPTACION NA ON A.IDPROVEEDOR = NA.IDPROVEEDOR AND  ")
        strSQL.Append("A.IDPROCESOCOMPRA = NA.IDPROCESOCOMPRA AND A.IDESTABLECIMIENTO = NA.IDESTABLECIMIENTO  ")
        strSQL.Append(" ")
        strSQL.Append("WHERE (A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND  ")
        strSQL.Append("(A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA)  ")
        strSQL.Append("AND (AP.IDANALISTA = @IDANALISTA OR @IDANALISTA = 0)  ")
        strSQL.Append("AND (A.CANTIDADFIRME > 0)  ")
        strSQL.Append("ORDER BY NUMEROOFERTA  ")
        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDANALISTA", SqlDbType.Int)
        args(2).Value = IDANALISTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function


    Public Function obtenerProveedoresContratoDS_LG(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDANALISTA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
       
        strSQL.Append("SELECT DISTINCT A.IDPROVEEDOR, P.NOMBRE, P.REPRESENTANTELEGAL, ")
        strSQL.Append("RO.ORDENLLEGADA AS NUMEROOFERTA, ")
        strSQL.Append(" CASE WHEN C.IDESTADOCONTRATO IS NULL THEN 'No' WHEN C.IDESTADOCONTRATO = 1 THEN 'Si' WHEN C.IDESTADOCONTRATO = 2 THEN 'Si' END AS GENERADO,  ")
        strSQL.Append(" ")
        strSQL.Append("(SELECT COUNT(IDDETALLE)  ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION AS A1  ")
        strSQL.Append("WHERE (A1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO) AND (A1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA) AND (A1.IDPROVEEDOR = A.IDPROVEEDOR) AND (A1.CANTIDADFIRME > 0))   ")
        strSQL.Append("AS RENGLONESADJUDICADOS,  ")
        strSQL.Append(" ")
        strSQL.Append("NA.NOMBREPERSONAFIRMA ")
        strSQL.Append(" ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION AS A  ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES AS P ON  ")
        strSQL.Append("A.IDPROVEEDOR = P.IDPROVEEDOR  ")
        strSQL.Append(" ")
        strSQL.Append(" ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON  ")
        strSQL.Append("A.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND A.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA AND  ")
        strSQL.Append("A.IDPROVEEDOR = CPC.IDPROVEEDOR  ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOS AS C  ")
        strSQL.Append("ON CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND CPC.IDPROVEEDOR = C.IDPROVEEDOR AND ")
        strSQL.Append(" CPC.IDCONTRATO = C.IDCONTRATO  ")
        strSQL.Append(" ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS AS RO ON ")
        strSQL.Append(" A.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO AND A.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA AND ")
        strSQL.Append(" A.IDPROVEEDOR = RO.IDPROVEEDOR   ")

        strSQL.Append(" ")
        'strSQL.Append("INNER JOIN SAB_UACI_ANALISTAPROVEEDORES AS AP ON ")
        'strSQL.Append(" A.IDESTABLECIMIENTO = AP.IDESTABLECIMIENTO  ")
        'strSQL.Append("AND A.IDPROCESOCOMPRA = AP.IDPROCESOCOMPRA  ")
        'strSQL.Append("AND A.IDPROVEEDOR = AP.IDPROVEEDOR  ")
        strSQL.Append(" ")
        strSQL.Append(" ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_NOTASACEPTACION NA ON A.IDPROVEEDOR = NA.IDPROVEEDOR AND  ")
        strSQL.Append("A.IDPROCESOCOMPRA = NA.IDPROCESOCOMPRA AND A.IDESTABLECIMIENTO = NA.IDESTABLECIMIENTO  ")
        strSQL.Append(" ")
        strSQL.Append("WHERE (A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND  ")
        strSQL.Append("(A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA)  ")
        'strSQL.Append("AND (AP.IDANALISTA = @IDANALISTA OR @IDANALISTA = 0)  ")
        strSQL.Append("AND (A.CANTIDADFIRME > 0)  ")
        strSQL.Append("ORDER BY NUMEROOFERTA  ")
        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDANALISTA", SqlDbType.Int)
        args(2).Value = IDANALISTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene los proveedores de oficios de adjudicacion
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Proveedores en formato dataset</returns>

    Public Function obtenerProveedoresOficioAdj(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("        OPC.IDPROVEEDOR, P.NOMBRE, RO.ORDENLLEGADA AS NUMEROOFERTA,  ")
        strSQL.Append("       (SELECT COUNT(IDDETALLE)  ")
        strSQL.Append("        FROM SAB_UACI_ADJUDICACION AS A1  ")
        strSQL.Append("        WHERE (A1.IDESTABLECIMIENTO = OPC.IDESTABLECIMIENTO) AND  ")
        strSQL.Append("        (A1.IDPROCESOCOMPRA = OPC.IDPROCESOCOMPRA) AND  ")
        strSQL.Append("        (A1.IDPROVEEDOR = OPC.IDPROVEEDOR) AND  ")
        strSQL.Append("        (A1.CANTIDADADJUDICADA > 0)) AS RENGLONESADJUDICADOS ")

        strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA AS OPC  ")
        strSQL.Append("        INNER JOIN SAB_CAT_PROVEEDORES AS P ON  ")
        strSQL.Append("        OPC.IDPROVEEDOR = P.IDPROVEEDOR  ")
        strSQL.Append("        INNER JOIN SAB_UACI_ADJUDICACION AS A ON  ")
        strSQL.Append("        OPC.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO AND  ")
        strSQL.Append("        OPC.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA AND  ")
        strSQL.Append("        OPC.IDPROVEEDOR = A.IDPROVEEDOR  ")
        strSQL.Append("        INNER JOIN SAB_UACI_RECEPCIONOFERTAS AS RO ON  ")
        strSQL.Append("        OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO AND  ")
        strSQL.Append("        OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA AND  ")
        strSQL.Append("        OPC.IDPROVEEDOR = RO.IDPROVEEDOR  ")

        strSQL.Append("WHERE (OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO)  ")
        strSQL.Append("        AND (OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA)  ")
        strSQL.Append("        AND (A.CANTIDADADJUDICADA > 0)  ")
        strSQL.Append("        ORDER BY NUMEROOFERTA  ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Chequa el Estado al proceso de compras en un momento determinado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica la identificacion del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica la identificacion del proceso de compras</param>
    ''' <returns>Numero entero que representa el estado del proceso de compras</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ChequearEstadoPC(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDESTADOPROCESOCOMPRA ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append(" WHERE PC.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & " And IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & " ")

        Dim estado As Integer
        estado = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return estado

    End Function
    ''' <summary>
    ''' Verificacion de renglones desiertos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Valor entero con el resultado de la verificacion</returns>

    Public Function verificarDesiertos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" UPDATE SAB_UACI_DETALLEPROCESOCOMPRA SET ")
        strSQL.Append(" IDESTADOCALIFICACION = 8 ")
        strSQL.Append(" WHERE (RENGLON NOT IN ")
        strSQL.Append("   	  (SELECT RENGLON ")
        strSQL.Append("   	   FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append("        WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")
        strSQL.Append("        GROUP BY RENGLON)) AND (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' informacion para reprote de hoja analisis con los renglones desiertos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="IDPROCESO">Identificador del proceso de compra</param> 'identificador del proceso de compra
    ''' <returns>
    ''' datase con la informacion de la hoja de analisis renglones desiertos
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_OFERTAPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_DETALLEPROCESOCOMPRA</description></item>
    '''  <item><description>SAB_CAT_CATALOGOPRODUCTOSS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_CAT_TIPOCOMPRAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>

    Public Function ObtenerHojaAnalisisDesierto(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.CANTIDAD AS CANTIDADPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.NUMEROENTREGAS AS ENTREGASPRODUCTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.OBSERVACION AS OBSERVACIONPRODUCTO, ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS_1.DESCRIPCION AS UNIDADPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.CODIGO, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.IDTIPOPRODUCTO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.CONCENTRACION, SAB_CAT_CATALOGOPRODUCTOS.FORMAFARMACEUTICA, ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS.PRESENTACION, SAB_CAT_TIPOCOMPRAS.DESCRIPCION AS TIPOCOMPRA, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA, SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO, ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDESTADOCALIFICACION, SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA ON ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS AS SAB_CAT_UNIDADMEDIDAS_1 ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS_1.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append("SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOCOMPRAS ON SAB_UACI_PROCESOCOMPRAS.IDTIPOCOMPRAEJECUTAR = SAB_CAT_TIPOCOMPRAS.IDTIPOCOMPRA ")
        strSQL.Append("WHERE SAB_UACI_DETALLEPROCESOCOMPRA.IDESTADOCALIFICACION = 8 ") 'estado de calificacion desierto
        strSQL.Append("AND SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene la fecha limite de notas de aceptacion
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Fecha limite en formato fecha</returns>

    Public Function ObtenerFechaLimiteAceptacion(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As Date

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT FECHALIMITEACEPTACION ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Consulta de informacion del proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDESTADO">Identificador del estado</param>
    ''' <param name="IDEMPLEADO">Identificador del empleado</param>
    ''' <param name="Todos">Identificador del filtro</param>
    ''' <returns>Informacion del proceso de compra en formato dataset</returns>

    Public Function ObtenerConsultaProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADO As Int32, ByVal IDEMPLEADO As Int32, ByVal Todos As Boolean) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("E.NOMBRE NOMBRE_ESTA, ")
        strSQL.Append("PC.IDPROCESOCOMPRA, ")
        strSQL.Append("TC.DESCRIPCION TIPOCOMPRA, ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("PC.TITULOLICITACION, ")
        strSQL.Append("PC.IDESTADOPROCESOCOMPRA, ")
        strSQL.Append("EPC.DESCRIPCION NOMBRE_ESTADO, ")
        strSQL.Append("PC.IDENCARGADO, ")
        strSQL.Append("isnull(EM.NOMBRE + ' ' + EM.APELLIDO, '') NOMBRE_ANALISTA, ")
        strSQL.Append("PC.FECHAINICIOPROCESOCOMPRA FECHAPROCESO ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ")
        strSQL.Append("ON PC.IDENCARGADO = EM.IDEMPLEADO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOPROCESOSCOMPRAS EPC ")
        strSQL.Append("ON PC.IDESTADOPROCESOCOMPRA = EPC.IDESTADOPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        If Todos = False Then
            strSQL.Append("AND PC.IDENCARGADO = @IDEMPLEADO ")
            strSQL.Append("AND PC.IDESTADOPROCESOCOMPRA = @IDESTADO ")
        End If
        strSQL.Append("ORDER BY PC.IDESTADOPROCESOCOMPRA, PC.IDENCARGADO, PC.FECHAINICIOPROCESOCOMPRA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(1).Value = IDEMPLEADO
        args(2) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(2).Value = IDESTADO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener la información del proceso de compra por periodo
    ''' </summary>
    ''' <param name="Fini">Identificador de la fecha de inicio</param>
    ''' <param name="Ffin">Identificador de la fecha fin</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Informacion del proceso de compra en formato dataset</returns>

    Public Function ObtenerDataSetProcesoCompraPorPeriodo(ByVal Fini As Date, ByVal Ffin As Date, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("  SELECT DISTINCT PrC.IDPROCESOCOMPRA, PrC.CODIGOLICITACION, cpc.IDESTABLECIMIENTO, PrC.FECHAINICIOPROCESOCOMPRA")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS AS PrC INNER JOIN")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc ON PrC.IDPROCESOCOMPRA = cpc.IDPROCESOCOMPRA AND ")
        strSQL.Append(" PrC.IDESTABLECIMIENTO = cpc.IDESTABLECIMIENTO")
        strSQL.Append(" WHERE (cpc.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (PrC.FECHAINICIOPROCESOCOMPRA <= @Ffin) AND ")
        strSQL.Append(" (PrC.FECHAINICIOPROCESOCOMPRA >= @Fini)")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@Fini", SqlDbType.DateTime)
        args(0).Value = Fini
        args(1) = New SqlParameter("@Ffin", SqlDbType.DateTime)
        args(1).Value = Ffin
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Eliminar un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Valor entero con el resultado de la eliminacion</returns>

    Public Function eliminarProcesoCompleto(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_EliminarProcesoCompra")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDPROCESOCOMPRA

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function
    ''' <summary>
    ''' Validacion de la existencia del codigo del proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Valor booleano con el resultado de la validacion</returns>

    Public Function validarExistenciaCodigoLicitacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT count(CODIGOLICITACION) ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString()) > 0, True, False)

    End Function
    ''' <summary>
    ''' Validacion de la existencia del codigo del proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="CODIGOLICITACION">Identificador del codigo del proceso de compra</param>
    ''' <returns>Valor booleano con el resultado de la validacion</returns>

    Public Function validarExistenciaCodigoLicitacion2(ByVal IDESTABLECIMIENTO As Integer, ByVal CODIGOLICITACION As String) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT count(CODIGOLICITACION) ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (CODIGOLICITACION = '" & CODIGOLICITACION & "') ")

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString()) > 0, True, False)

    End Function
    ''' <summary>
    ''' Obtiene el numero del acta de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="NoACTA">Identificador del No.Acta</param>
    ''' <returns>Numero del acta en formato dataset</returns>

    Public Function ObtenerNoActaApertura(ByVal IDESTABLECIMIENTO As Int32, ByVal NoACTA As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ACTAAPERTURA = '" & NoACTA & "' ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene el cifrado presupuestario de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Cadena de caracteres con el cifrado</returns>

    Public Function obtenerCifradoPresupuestario(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ISNULL(SAB_EST_SOLICITUDES.CIFRADOPRESUPUESTARIO, 0) AS CIFRADOPRESUPUESTARIO ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS ON ")
        strSQL.Append(" SAB_EST_SOLICITUDES.IDSOLICITUD = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD AND ")
        strSQL.Append(" SAB_EST_SOLICITUDES.IDESTABLECIMIENTO = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append(" WHERE (SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim cifradoPresupuestario As String = String.Empty

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            If i = (ds.Tables(0).Rows.Count - 1) Then
                cifradoPresupuestario += ds.Tables(0).Rows(i).Item("CIFRADOPRESUPUESTARIO")
            Else
                cifradoPresupuestario += ds.Tables(0).Rows(i).Item("CIFRADOPRESUPUESTARIO") & ", "
            End If
        Next

        Return cifradoPresupuestario

    End Function

    ''' <summary>
    ''' Devuelve el detalle de un proceso de compra de un establecimiento especifico.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento. (Filtro)</param>
    ''' <param name="IDPROCESOCOMPRA ">Identificador del proceso compra. (Filtro)</param>
    ''' <returns>Dataset con el detalle de un proceso compra.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_DETALLEPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  01/02/2007    Creado
    ''' </history> 
    Public Function ObtenerProcesoCompraReporte(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROCESOCOMPRA, ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("PC.TITULOLICITACION, ")
        strSQL.Append("PC.DESCRIPCIONLICITACION, ")
        strSQL.Append("PC.FECHAINICIOPROCESOCOMPRA, ")
        strSQL.Append("PC.IDENTIDADSOLICITA, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTOSOLICITA, ")
        strSQL.Append("DPC.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("DPC.RENGLON, ")
        strSQL.Append("DPC.CANTIDAD, ")
        strSQL.Append("DPC.NUMEROENTREGAS, ")
        strSQL.Append("DPC.IDUNIDADMEDIDA, ")
        strSQL.Append("UM.DESCRIPCION NOMBREUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCLARGO ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("ON PC.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA AND PC.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PC.IDENTIDADSOLICITA = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
        strSQL.Append("ON DPC.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("WHERE (PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene la garantía del mantenimiento de los productos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Garantias del producto en formato dataset</returns>

    Public Function obtenerGarantiaMttoProducto(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DPC.RENGLON, ")
        strSQL.Append("CP.CORRPRODUCTO CODIGO, ")
        strSQL.Append("CP.DESCLARGO NOMBRE, ")
        strSQL.Append("CP.DESCRIPCION UNIDAD_MEDIDA, ")
        strSQL.Append("convert(decimal(15, 2), isnull(DPC.GARANTIAMTTOVALOR,0)) GARANTIA_MTTO ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtiene los integrantes de la comision de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Miembro de la comision en formato texto</returns>

    Public Function ObtenerMiembros(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(DC.NOMBRE + ', ' + DC.CARGO, '') MIEMBRO ")
        strSQL.Append("FROM SAB_UACI_DETALLECOMISIONEVALUADORA DC ")
        strSQL.Append("INNER JOIN SAB_UACI_COMISIONPROCESOCOMPRA CPC ")
        strSQL.Append("ON (DC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND DC.IDCOMISION = CPC.IDCOMISION) ")
        strSQL.Append("INNER JOIN SAB_UACI_COMISIONESEVALUADORAS CE ")
        strSQL.Append("ON (CE.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND CE.IDCOMISION = CPC.IDCOMISION) ")
        strSQL.Append("WHERE CPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND CE.ESTADO = 1 ")
        strSQL.Append("AND CE.ESALTONIVEL = 0 ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New Text.StringBuilder

        If dr.HasRows Then
            Do While dr.Read()
                lista.Append(dr("MIEMBRO").ToString)
                lista.Append("; ")
            Loop
        End If

        dr.Close()

        Return lista.ToString

    End Function
    ''' <summary>
    ''' Obtiene la lista de ofertas de un proceso de compras
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Proveedor en cadena de caracteres</returns>

    Public Function ObtenerListaProveedores(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("P.NOMBRE PROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("ORDER BY PROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim listProveedores As New Text.StringBuilder

        If dr.HasRows Then
            Do While dr.Read()
                listProveedores.Append(dr("PROVEEDOR").ToString)
                listProveedores.Append("; ")
            Loop
        End If

        dr.Close()

        Return listProveedores.ToString

    End Function
    ''' <summary>
    ''' Obtiene la fecha maxima de recepcion de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Fecha en formato de dataset</returns>

    Public Function obtenerMaxFechaRecepcion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT MAX(FECHAENTREGA) AS FECHAENTREGA ")
        strSQL.Append(" FROM SAB_UACI_RECEPCIONOFERTAS ")
        strSQL.Append(" GROUP BY IDESTABLECIMIENTO, IDPROCESOCOMPRA ")
        strSQL.Append(" HAVING (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Listado de empleados en la apertura de ofertas
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Listado en formato dataset</returns>

    Public Function obtieneNvoDatasetEmpleadosAperturaOferta(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDPROCESOCOMPRA, SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDESTABLECIMIENTO,")
        strSQL.Append(" SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDDETALLE, SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.NOMBRE AS EMPLEADO, ")
        strSQL.Append(" SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.CARGO AS CARGO ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append(" SAB_UACI_REPRESENTANTEAPERTURAPROCESOS ON ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND ")
        strSQL.Append("(SAB_UACI_REPRESENTANTEAPERTURAPROCESOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Consulta de monto total del proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Valor decimal con el monto total</returns>

    Public Function dsConsultarMontoSolicitado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Decimal

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT S.MONTOSOLICITADO AS MONTO ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append("SAB_EST_SOLICITUDESPROCESOCOMPRAS AS SP ON PC.IDPROCESOCOMPRA = SP.IDPROCESOCOMPRA AND ")
        strSQL.Append("PC.IDESTABLECIMIENTO = SP.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_EST_SOLICITUDES AS S ON SP.IDSOLICITUD = S.IDSOLICITUD AND SP.IDESTABLECIMIENTOSOLICITUD = S.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Montos totales adjudicados de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Valor decimal con el monto</returns>

    Public Function dsTotalAdjudicado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Decimal

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT isnull(SUM(SAB_UACI_ADJUDICACION.CANTIDADADJUDICADA * SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO), 0.00) AS total ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA INNER JOIN ")
        strSQL.Append(" SAB_UACI_ADJUDICACION ON SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = SAB_UACI_ADJUDICACION.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDDETALLE = SAB_UACI_ADJUDICACION.IDDETALLE ")
        strSQL.Append(" WHERE SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtiene el examen tecnico por renglon de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Examenes por renglones en formato dataset</returns>

    Public Function obtenerExamenRenglonGeneral(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.DESCRIPCIONLICITACION, ")
        strSQL.Append("TP.DESCRIPCION AS TIPO, ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("PC.TITULOLICITACION, ")
        strSQL.Append("ER.idestablecimiento, ")
        strSQL.Append("ER.idprocesocompra, ")
        strSQL.Append("ER.idproveedor, ")
        strSQL.Append("RO.ordenllegada, ")
        strSQL.Append("DO.renglon, ")
        strSQL.Append("DO.correlativorenglon, ")
        strSQL.Append("ER.iddocumentobase, ")
        strSQL.Append("DB.descripcion as documento, ")
        strSQL.Append("ER.entregado1 as entregado ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_UACI_EXAMENRENGLON ER INNER JOIN ")
        strSQL.Append("SAB_UACI_RECEPCIONOFERTAS RO ON ")
        strSQL.Append("	ER.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO AND ")
        strSQL.Append("	ER.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA AND ")
        strSQL.Append("	ER.IDPROVEEDOR = RO.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN ")
        strSQL.Append("SAB_UACI_DETALLEOFERTA DO ON ")
        strSQL.Append("	ER.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO AND ")
        strSQL.Append("	ER.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA AND ")
        strSQL.Append("	ER.IDPROVEEDOR = DO.IDPROVEEDOR AND ")
        strSQL.Append("	ER.IDDETALLE = DO.IDDETALLE ")
        strSQL.Append("INNER JOIN ")
        strSQL.Append("SAB_CAT_DOCUMENTOSBASE DB ON ")
        strSQL.Append("	DB.IDDOCUMENTOBASE = ER.IDDOCUMENTOBASE ")
        strSQL.Append("INNER JOIN ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS PC ON ")
        strSQL.Append("	ER.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND ")
        strSQL.Append("	ER.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOCOMPRAS TP ON ")
        strSQL.Append("	TP.IDTIPOCOMPRA = PC.IDTIPOCOMPRAEJECUTAR ")
        strSQL.Append("WHERE ")
        strSQL.Append("DB.IDTIPODOCUMENTOBASE = 3 AND ")
        strSQL.Append("ER.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("ER.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND ER.ENTREGADO1 = 2 ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene informacion del proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Informacion del proceso de compra en formato dataset</returns>

    Public Function ObtenerProcesoCompraDV(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT PC.CODIGOLICITACION, PC.TITULOLICITACION, PC.DESCRIPCIONLICITACION, D.NOMBRE AS DEPENDENCIA, E.NOMBRE AS NTITULAR, ")
        strSQL.Append(" E.APELLIDO AS ATITULAR, C.DESCRIPCION AS CARGOTITULAR, PC.LUGARRECEPCIONOFERTA, PC.DIRECCIONRECEPCIONOFERTA, ")
        strSQL.Append(" PC.FECHAHORAINICIORECEPCION, PC.FECHAHORAFINRECEPCION, PC.LUGARAPERTURABASE, PC.DIRECCIONAPERTURABASE, ")
        strSQL.Append(" PC.FECHAHORAINICIOAPERTURA, PC.FECHAHORAFINAPERTURA, PC.FECHAINICIOACLARACIONES, PC.FECHAFINACLARACIONES, ")
        strSQL.Append(" PC.PORCENTAJEINDICESOLVENCIA, PC.PORCENTAJECAPITALTRABAJO, PC.PORCENTAJEENDEUDAMIENTO, PC.PORCENTAJEREFERENCIASBANC, ")
        strSQL.Append(" PC.GARANTIAMTTOVIGENCIA AS GARANTIAMANTENIMIENTOOFERTA, PC.LUGARMTTO, PC.GARANTIACUMPLIMIENTOVALOR, ")
        strSQL.Append(" PC.GARANTIACUMPLIMIENTOENTREGA, PC.GARANTIACUMPLIMIENTOVIGENCIA, PC.LUGARCUMPLIMIENTO, PC.GARANTIACALIDADVALOR, ")
        strSQL.Append(" PC.GARANTIACALIDADENTREGA, PC.GARANTIACALIDADVIGENCIA, PC.LUGARCALIDAD, PC.GARANTIAANTICIPOVALOR, ")
        strSQL.Append(" PC.GARANTIAANTICIPOENTREGAS, PC.GARANTIAANTICIPOVIGENCIA, PC.LUGARANTICIPO, PC.FECHAAPROBACIONBASE, DB.DESCRIPCION AS DOCUMENTOBASE, ")
        strSQL.Append(" TD.DESCRIPCION AS TIPODOCUMENTO ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS AS SP ON PC.IDPROCESOCOMPRA = SP.IDPROCESOCOMPRA AND ")
        strSQL.Append(" PC.IDESTABLECIMIENTO = SP.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDES AS S ON SP.IDSOLICITUD = S.IDSOLICITUD AND SP.IDESTABLECIMIENTOSOLICITUD = S.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_DEPENDENCIAS AS D ON S.IDDEPENDENCIASOLICITANTE = D.IDDEPENDENCIA INNER JOIN ")
        strSQL.Append(" SAB_CAT_EMPLEADOS AS E ON PC.IDTITULAR = E.IDEMPLEADO INNER JOIN ")
        strSQL.Append(" SAB_CAT_CARGOS AS C ON E.IDCARGO = C.IDCARGO INNER JOIN ")
        strSQL.Append(" SAB_UACI_DOCUMENTOSPROCESOSCOMPRA AS DC ON PC.IDESTABLECIMIENTO = DC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" PC.IDPROCESOCOMPRA = DC.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_DOCUMENTOSBASE AS DB ON DC.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPODOCUMENTOBASE AS TD ON DB.IDTIPODOCUMENTOBASE = TD.IDTIPODOCUMENTOBASE ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener la información del aviso de la compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Información del aviso en formato dataset</returns>

    Public Function ObtenerProcesoCompraAviso(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT PC.CODIGOLICITACION, PC.TITULOLICITACION, PC.DESCRIPCIONLICITACION, TC.DESCRIPCION AS TIPOCOMPRA, PC.COSTOBASE, PC.FECHAHORAINICIORETIRO, ")
        strSQL.Append(" PC.FECHAHORAFINRETIRO, PC.LUGARRETIROBASE, PC.FECHAHORAINICIORECEPCION, PC.FECHAHORAFINRECEPCION, ")
        strSQL.Append(" PC.FECHAHORAINICIOAPERTURA, PC.FECHAHORAFINAPERTURA, PC.LUGARAPERTURABASE, PC.DIRECCIONAPERTURABASE, ")
        strSQL.Append(" PC.IDPROCESOCOMPRA, SM.DESCRIPCION AS SUMINISTRO, EMPLEADO.NOMBRE, EMPLEADO.APELLIDO, PC.IDTIPOCOMPRAEJECUTAR AS IDTIPOCOMPRA, PC.FECHAPUBLICACION AS FECHAPUBLICACION ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS AS TC ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS AS SP INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDES AS S ON SP.IDSOLICITUD = S.IDSOLICITUD AND SP.IDESTABLECIMIENTOSOLICITUD = S.IDESTABLECIMIENTO ON ")
        strSQL.Append(" PC.IDPROCESOCOMPRA = SP.IDPROCESOCOMPRA AND PC.IDESTABLECIMIENTO = SP.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_SUMINISTROS AS SM ON S.IDCLASESUMINISTRO = SM.IDSUMINISTRO INNER JOIN ")
        strSQL.Append(" SAB_CAT_EMPLEADOS AS EMPLEADO ON PC.IDJEFEUACI = EMPLEADO.IDEMPLEADO ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Informacion del aviso de adjudicacion en firme
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Informacion del aviso de adjudicacion en firme en formato dataset</returns>

    Public Function ObtenerDatosAvisoAdjudicacionFirme(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT PC.IDPROCESOCOMPRA, MC.DESCRIPCION AS MODALIDAD, PC.CODIGOLICITACION, PC.TITULOLICITACION, PC.DESCRIPCIONLICITACION, F.NOMBRE AS FUENTEFINANCIAMIENTO, PC.NUMERORESOLUCION ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS AS TC ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_MODALIDADESCOMPRA AS MC ON TC.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS ON PC.IDPROCESOCOMPRA = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" PC.IDESTABLECIMIENTO = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDES AS S ON SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD = S.IDSOLICITUD AND ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTOSOLICITUD = S.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES AS FS ON S.IDSOLICITUD = FS.IDSOLICITUD AND ")
        strSQL.Append(" S.IDESTABLECIMIENTO = FS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_FUENTEFINANCIAMIENTOS AS F ON FS.IDFUENTEFINANCIAMIENTO = F.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener información del proceso
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Informacion del proceso en formato dataset</returns>

    Public Function ObtenerInformacionProceso(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT MC.DESCRIPCION, PC.CODIGOLICITACION, PC.NUMERORESOLUCION ")
        strSQL.Append(" FROM ")
        strSQL.Append(" 		SAB_UACI_PROCESOCOMPRAS PC INNER JOIN SAB_CAT_TIPOCOMPRAS TP ")
        strSQL.Append(" 		ON TP.IDTIPOCOMPRA = PC.IDTIPOCOMPRAEJECUTAR ")
        strSQL.Append(" 		INNER JOIN SAB_CAT_MODALIDADESCOMPRA MC ON ")
        strSQL.Append("   		MC.IDMODALIDADCOMPRA = TP.IDMODALIDADCOMPRA ")
        strSQL.Append(" WHERE PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene el tipo de suministro de un proceso de compra
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Tipo de suministro en formato dataset</returns>

    Public Function ObtenerTipoSuministro(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT S.IDCLASESUMINISTRO ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS AS SPC ON PC.IDPROCESOCOMPRA = SPC.IDPROCESOCOMPRA AND ")
        strSQL.Append(" PC.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDES AS S ON SPC.IDSOLICITUD = S.IDSOLICITUD AND SPC.IDESTABLECIMIENTOSOLICITUD = S.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtener informacion del proceso de compra
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Infomacion del proceso de compra en formato dataset</returns>

    Public Function ObtenerDsProcesoCompra(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT PC.DESCRIPCIONLICITACION, PC.CODIGOLICITACION, PC.IDTIPOCOMPRAEJECUTAR, TC.DESCRIPCION MODALIDAD")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append(" SAB_CAT_TIPOCOMPRAS AS TC ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA  ")
        strSQL.Append(" INNER JOIN ")
        strSQL.Append(" SAB_CAT_MODALIDADESCOMPRA AS MC ON TC.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append(" WHERE (PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Información del anexo del proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="IDCONTRATO">Identificador del contrato</param>
    ''' <returns>Anexo en formato dataset</returns>

    Public Function ObtenerAnexo1(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        'strSQL.Append("SELECT ")
        'strSQL.Append("upper(TC.DESCRIPCION) TIPOCOMPRA, ")
        'strSQL.Append("PC.CODIGOLICITACION, ")
        'strSQL.Append("PC.DESCRIPCIONLICITACION, ")
        'strSQL.Append("P.NOMBRE PROVEEDOR, ")
        'strSQL.Append("DPC.RENGLON, ")
        'strSQL.Append("CP.DESCLARGO NOMBRE, ")
        'strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        'strSQL.Append("A.CANTIDADFIRME, ")
        'strSQL.Append("A.IDDETALLE, ")
        'strSQL.Append("EA.IDENTREGA ENTREGAS, ")
        'strSQL.Append("AEA.IDALMACEN, ")
        'strSQL.Append("AEA.CANTIDAD, ")
        'strSQL.Append("ALM.NOMBRE ALMACEN, ")
        'strSQL.Append("case ")
        'strSQL.Append("when PD.IDESTABLECIMIENTO = PD.IDESTABLECIMIENTOSOLICITA then '' ")
        'strSQL.Append("else E.CODIGOESTABLECIMIENTO ")
        'strSQL.Append("end CODIGOESTABLECIMIENTO, ")

        'strSQL.Append("CP.CORRPRODUCTO CODIGOPRODUCTO ")

        'strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        'strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        'strSQL.Append("ON A.IDPROVEEDOR = P.IDPROVEEDOR ")
        'strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
        'strSQL.Append("ON A.IDESTABLECIMIENTO = EA.IDESTABLECIMIENTO ")
        'strSQL.Append("AND A.IDPROCESOCOMPRA = EA.IDPROCESOCOMPRA ")
        'strSQL.Append("AND A.IDPROVEEDOR = EA.IDPROVEEDOR ")
        'strSQL.Append("AND A.IDDETALLE = EA.IDDETALLE ")
        'strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        'strSQL.Append("ON A.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        'strSQL.Append("AND A.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        'strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        'strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        'strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        'strSQL.Append("ON A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        'strSQL.Append("AND A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        'strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        'strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE ")
        'strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        'strSQL.Append("ON A.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
        'strSQL.Append("AND A.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
        'strSQL.Append("AND DO.RENGLON = DPC.RENGLON ")
        'strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        'strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        'strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
        'strSQL.Append("ON EA.IDESTABLECIMIENTO = AEA.IDESTABLECIMIENTO ")
        'strSQL.Append("AND EA.IDPROCESOCOMPRA = AEA.IDPROCESOCOMPRA ")
        'strSQL.Append("AND EA.IDPROVEEDOR = AEA.IDPROVEEDOR ")
        'strSQL.Append("AND EA.IDDETALLE = AEA.IDDETALLE ")
        'strSQL.Append("AND EA.IDENTREGA = AEA.IDENTREGA ")
        'strSQL.Append("INNER JOIN SAB_CAT_ALMACENES ALM ")
        'strSQL.Append("ON AEA.IDALMACEN = ALM.IDALMACEN ")
        'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
        'strSQL.Append("ON A.IDESTABLECIMIENTO = PD.IDESTABLECIMIENTO ")
        'strSQL.Append("AND A.IDPROCESOCOMPRA = PD.IDPROCESOCOMPRA ")
        'strSQL.Append("AND DPC.RENGLON = PD.RENGLON ")
        'strSQL.Append("AND AEA.IDALMACEN = PD.IDALMACEN ")
        'strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        'strSQL.Append("ON PD.IDESTABLECIMIENTOSOLICITA = E.IDESTABLECIMIENTO ")
        'strSQL.Append("WHERE ")
        'strSQL.Append("A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        'strSQL.Append("AND A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        'strSQL.Append("AND A.IDPROVEEDOR = @IDPROVEEDOR ")
        'strSQL.Append("AND A.CANTIDADFIRME > 0 ")
        'strSQL.Append("GROUP BY ")
        'strSQL.Append("TC.DESCRIPCION, ")
        'strSQL.Append("PC.CODIGOLICITACION, ")
        'strSQL.Append("PC.DESCRIPCIONLICITACION, ")
        'strSQL.Append("P.NOMBRE, ")
        'strSQL.Append("DPC.RENGLON, ")
        'strSQL.Append("CP.DESCLARGO, ")
        'strSQL.Append("CP.DESCRIPCION,")
        'strSQL.Append("A.CANTIDADFIRME, ")
        'strSQL.Append("A.IDDETALLE, ")
        'strSQL.Append("AEA.IDALMACEN, ")
        'strSQL.Append("AEA.CANTIDAD, ")
        'strSQL.Append("ALM.NOMBRE, ")
        'strSQL.Append("PD.IDESTABLECIMIENTO, ")
        'strSQL.Append("PD.IDESTABLECIMIENTOSOLICITA, ")
        'strSQL.Append("E.CODIGOESTABLECIMIENTO, ")
        'strSQL.Append("EA.IDENTREGA, ")
        'strSQL.Append("CP.CORRPRODUCTO ")
        'strSQL.Append("ORDER BY RENGLON ")
        strSQL.Append(" SELECT upper(TC.DESCRIPCION) TIPOCOMPRA, PC.CODIGOLICITACION, PC.DESCRIPCIONLICITACION, ")
        strSQL.Append(" P.NOMBRE PROVEEDOR, AEC.RENGLON, CP.DESCLARGO NOMBRE, CP.DESCRIPCION UNIDADMEDIDA,  ")
        strSQL.Append(" AEC.IDDETALLE ENTREGAS, AEC.IDALMACENENTREGA, AEC.CANTIDAD,  ")
        strSQL.Append(" ALM.NOMBRE ALMACEN,  ")
        strSQL.Append(" CP.CORRPRODUCTO CODIGOPRODUCTO, AEC.IDFUENTEFINANCIAMIENTO, FF.NOMBRE AS NOMBREFUENTEFINANCIAMIENTO  ")
        strSQL.Append("  ")
        strSQL.Append(" FROM   ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS AEC INNER JOIN SAB_UACI_ENTREGACONTRATO EC ON  ")
        strSQL.Append(" EC.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO AND  ")
        strSQL.Append(" EC.IDPROVEEDOR = AEC.IDPROVEEDOR AND  ")
        strSQL.Append(" EC.IDCONTRATO = AEC.IDCONTRATO AND  ")
        strSQL.Append(" EC.RENGLON = AEC.RENGLON AND ")
        strSQL.Append(" EC.IDDETALLE = AEC.IDDETALLE   ")
        strSQL.Append("  ")
        strSQL.Append(" INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PCON ON ")
        strSQL.Append(" PCON.IDESTABLECIMIENTO=EC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" PCON.IDPROVEEDOR=EC.IDPROVEEDOR AND ")
        strSQL.Append(" PCON.IDCONTRATO=EC.IDCONTRATO AND ")
        strSQL.Append(" PCON.RENGLON=EC.RENGLON ")
        strSQL.Append("  ")
        strSQL.Append(" INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
        strSQL.Append(" CPC.IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND ")
        strSQL.Append(" CPC.IDPROCESOCOMPRA=@IDPROCESOCOMPRA AND ")
        strSQL.Append(" CPC.IDPROVEEDOR=PCon.IDPROVEEDOR AND  ")
        strSQL.Append(" CPC.IDCONTRATO=PCon.IDCONTRATO  ")
        strSQL.Append("  ")
        strSQL.Append(" INNER JOIN  SAB_UACI_PROCESOCOMPRAS PC on  ")
        strSQL.Append(" PC.IDESTABLECIMIENTO=CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" PC.IDPROCESOCOMPRA=CPC.IDPROCESOCOMPRA ")
        strSQL.Append("  ")
        strSQL.Append(" INNER JOIN SAB_CAT_ALMACENES ALM ON  ")
        strSQL.Append(" AEC.IDALMACENENTREGA = ALM.IDALMACEN  ")
        strSQL.Append("  ")
        strSQL.Append(" INNER JOIN vv_CATALOGOPRODUCTOS CP ON  ")
        strSQL.Append(" PCON.IDPRODUCTO = CP.IDPRODUCTO  ")
        strSQL.Append("  ")
        strSQL.Append(" INNER JOIN SAB_CAT_TIPOCOMPRAS TC ON  ")
        strSQL.Append(" PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA  ")
        strSQL.Append("  ")
        strSQL.Append(" INNER JOIN SAB_CAT_PROVEEDORES P ON  ")
        strSQL.Append(" 	AEC.IDPROVEEDOR = P.IDPROVEEDOR  ")
        strSQL.Append("  ")
        strSQL.Append(" INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ON  ")
        strSQL.Append(" 	FF.IDFUENTEFINANCIAMIENTO = AEC.IDFUENTEFINANCIAMIENTO  ")
        strSQL.Append("  ")
        strSQL.Append(" WHERE AEC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND  ")
        strSQL.Append(" CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND  ")
        strSQL.Append(" PCON.IDPROVEEDOR = @IDPROVEEDOR AND  ")
        strSQL.Append(" PCON.IDCONTRATO = @IDCONTRATO   ")
        strSQL.Append("  ")
        strSQL.Append(" GROUP BY TC.DESCRIPCION, PC.CODIGOLICITACION, PC.DESCRIPCIONLICITACION, P.NOMBRE, AEC.RENGLON, CP.DESCLARGO, CP.DESCRIPCION, AEC.IDALMACENENTREGA, AEC.CANTIDAD, ALM.NOMBRE, AEC.IDDETALLE, CP.CORRPRODUCTO, AEC.IDFUENTEFINANCIAMIENTO,FF.NOMBRE  ")
        strSQL.Append(" ORDER BY RENGLON  ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(3).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Informacion de las adjudicaciones de un proceso de compra
    ''' </summary>
    ''' <returns>Informacion en formato dataset</returns>

    Public Function ObtenerProcesoCompraAdjudicados() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT PC.IDESTABLECIMIENTO, PC.IDPROCESOCOMPRA, ")
        strSQL.Append("       PC.IDENTIDADSOLICITA, PC.CODIGOLICITACION, ")
        strSQL.Append("       PC.TITULOLICITACION, PC.DESCRIPCIONLICITACION, ")
        strSQL.Append("       PC.IDTIPOCOMPRAEJECUTAR, PC.IDESTADOPROCESOCOMPRA, PC.IDENCARGADO, ")
        strSQL.Append("        PC.NUMERORESOLUCION, PC.AUUSUARIOCREACION, PC.AUFECHACREACION, ")
        strSQL.Append("       PC.AUUSUARIOMODIFICACION, PC.AUFECHAMODIFICACION, ")
        strSQL.Append("		E.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ON ")
        strSQL.Append("		A.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND A.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC ON ")
        strSQL.Append("		SPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND ")
        strSQL.Append("		SPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_EST_SOLICITUDES S ON ")
        strSQL.Append("		S.IDSOLICITUD = SPC.IDSOLICITUD AND ")
        strSQL.Append("		S.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ON ")
        strSQL.Append("E.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.CANTIDADFIRME > 0 AND ")
        strSQL.Append("		S.IDCLASESUMINISTRO = 1 ")
        strSQL.Append("ORDER BY ")
        strSQL.Append("PC.AUUSUARIOCREACION desc ")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtener informacion del proceso de compra y su solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="flag">Identificador del filtro</param>
    ''' <param name="VALOR">Identificador del valor del filtro</param>
    ''' <returns>Informacion en formato dataset</returns>

    Public Function ObtenerPC_Solicitud(ByVal IDESTABLECIMIENTO As Integer, ByVal flag As Integer, ByVal VALOR As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT S.CORRELATIVO, S.IDSOLICITUD, S.MONTOSOLICITADO,D.NOMBRE AS DEPENDENCIA, SU.DESCRIPCION AS SUMINISTRO, PC.IDPROCESOCOMPRA,PC.CODIGOLICITACION,PC.DESCRIPCIONLICITACION, ")
        strSQL.Append(" isnull(EPC.DESCRIPCION, '') ESTADOPROCESOCOMPRA ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append(" LEFT OUTER JOIN SAB_CAT_ESTADOPROCESOSCOMPRAS EPC ")
        strSQL.Append(" ON PC.IDESTADOPROCESOCOMPRA = EPC.IDESTADOPROCESOCOMPRA ")
        strSQL.Append(" INNER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC ")
        strSQL.Append(" ON PC.IDPROCESOCOMPRA = SPC.IDPROCESOCOMPRA AND ")
        strSQL.Append(" PC.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTO ")
        strSQL.Append(" INNER JOIN SAB_EST_SOLICITUDES S ")
        strSQL.Append(" ON S.IDSOLICITUD = SPC.IDSOLICITUD AND ")
        strSQL.Append(" S.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append(" INNER JOIN SAB_CAT_SUMINISTROS SU ")
        strSQL.Append(" ON SU.IDSUMINISTRO = S.IDCLASESUMINISTRO ")
        strSQL.Append(" INNER JOIN SAB_CAT_DEPENDENCIAS D ")
        strSQL.Append(" ON D.IDDEPENDENCIA = S.IDDEPENDENCIASOLICITANTE ")
        strSQL.Append(" WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Select Case flag
            Case Is = 1
                strSQL.Append(" AND PC.CODIGOLICITACION LIKE '%' + @VALOR + '%'")
            Case Is = 2
                strSQL.Append(" AND PC.DESCRIPCIONLICITACION LIKE '%' + @VALOR + '%'")
            Case Is = 3
                strSQL.Append(" AND SU.DESCRIPCION LIKE '%' + @VALOR + '%'")
            Case Is = 4
                strSQL.Append(" AND D.NOMBRE LIKE '%' + @VALOR + '%'")
        End Select

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        If flag > 0 Then
            args(1) = New SqlParameter("@VALOR", SqlDbType.VarChar)
            args(1).Value = VALOR
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Informacion de las fuentes de financiamiento de la solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <returns>Informacion en formato dataset</returns>

    Public Function ObtenerFF_Solicitud(ByVal IDESTABLECIMIENTO As Integer, ByVal IDSOLICITUD As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT FF.NOMBRE AS FUENTE,FFS.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append(" from ")
        strSQL.Append(" SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append(" ON FF.IDFUENTEFINANCIAMIENTO = FFS.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append(" where ")
        strSQL.Append(" FFS.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND FFS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = IDSOLICITUD

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerGrupoReqDoc(ByVal IDPRODUCTO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT D.IDGRUPOREQTEC ")
        strSQL.Append("FROM SAB_CAT_DOCUMENTOSBASE D INNER JOIN ")
        strSQL.Append("SAB_UACI_GRUPOREQTEC_PRODUCTOS GRP ON ")
        strSQL.Append("GRP.IDGRUPOREQ=D.IDGRUPOREQTEC ")
        strSQL.Append("WHERE IDTIPODOCUMENTOBASE=3 ")
        strSQL.Append("AND GRP.IDPRODUCTO=" & IDPRODUCTO)
        strSQL.Append(" GROUP BY D.IDGRUPOREQTEC ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
#End Region

End Class
