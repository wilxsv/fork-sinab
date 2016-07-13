Partial Public Class dbFUENTEFINANCIAMIENTOSCONTRATOS

    ''' <summary>
    ''' Devuelve un listado de las fuentes de financiamiento de un contrato específico
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">El ID del establecimiento.</param>
    ''' <param name="IDCONTRATO">El ID del contrato que se desea recuperar.</param>
    ''' <param name="IDPROVEEDOR">El ID del proveedor que se desea recuperar.</param>
    ''' <returns>Dataset con el listado de fuentes de financiamiento.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  30/12/2006    Creado
    ''' </history> 
    Public Function ObtenerFuentesPorContratoDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("FFC.IDESTABLECIMIENTO, ")
        strSQL.Append("FFC.IDPROVEEDOR, ")
        strSQL.Append("FFC.IDCONTRATO, ")
        strSQL.Append("FFC.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FFC.MONTOCONTRATADO, ")
        strSQL.Append("FF.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS FFC ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON FFC.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("WHERE FFC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND FFC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND FFC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("ORDER BY FF.NOMBRE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene el monto total de un contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDCONTRATO">Identificador del contrato</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <returns>Cadena de caracteres con el monto del contrato</returns>
    Public Function CalculoMontoTotalFuentesContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int64, ByVal IDPROVEEDOR As Int32) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(sum(MONTOCONTRATADO), 0) ")
        strSQL.Append("from SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Elimina todas las fuentes de financiamiento asociados a un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <returns>Valor numerico indicando el estado de la transacción</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  13/02/2007    Creado
    ''' </history> 
    Public Function EliminarAsociados(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtiene las fuentes de financiamiento de una solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="IDCONTRATO">Identificador del contrato</param>
    ''' <returns>Fuentes de financiamiento en formato dataset</returns>

    Public Function obtenerFuenteFinanciamientoSolicitud(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        'strSQL.Append(" SELECT SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO, ")
        'strSQL.Append(" SUM(SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.MONTOPARTICIPACION) AS MONTO ")
        'strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA INNER JOIN ")
        'strSQL.Append(" SAB_UACI_PROCESOCOMPRAS ON ")
        'strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA AND ")
        'strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO INNER JOIN ")
        'strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS ON ")
        'strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA AND ")
        'strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO INNER JOIN ")
        'strSQL.Append(" SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ON ")
        'strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTOSOLICITUD = SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDESTABLECIMIENTO AND ")
        'strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD = SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDSOLICITUD ")
        'strSQL.Append(" WHERE (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR = " & IDPROVEEDOR & ") AND ")
        'strSQL.Append(" (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO = " & IDCONTRATO & ") ")
        'strSQL.Append(" AND      (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")
        'strSQL.Append(" GROUP BY SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO, ")
        'strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA ")

        strSQL.Append(" SELECT AEC.IDFUENTEFINANCIAMIENTO, SUM(convert(decimal(12,2),AEC.CANTIDAD*PC.PRECIOUNITARIO)) AS MONTO ")
        strSQL.Append(" FROM SAB_UACI_PRODUCTOSCONTRATO PC INNER JOIN SAB_UACI_ENTREGACONTRATO EC ON ")
        strSQL.Append(" PC.IDESTABLECIMIENTO=EC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" PC.IDPROVEEDOR=EC.IDPROVEEDOR AND ")
        strSQL.Append(" PC.IDCONTRATO=EC.IDCONTRATO AND ")
        strSQL.Append(" PC.RENGLON=EC.RENGLON ")
        strSQL.Append(" INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ON ")
        strSQL.Append(" AEC.IDESTABLECIMIENTO=EC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" AEC.IDPROVEEDOR=EC.IDPROVEEDOR AND ")
        strSQL.Append(" AEC.IDCONTRATO=EC.IDCONTRATO AND ")
        strSQL.Append(" AEC.RENGLON=EC.RENGLON AND ")
        strSQL.Append(" AEC.IDDETALLE = EC.IDDETALLE ")
        strSQL.Append(" WHERE PC.IDESTABLECIMIENTO=" & IDESTABLECIMIENTO & " AND PC.IDPROVEEDOR=" & IDPROVEEDOR & " AND PC.IDCONTRATO=" & IDCONTRATO)
        strSQL.Append(" GROUP BY AEC.IDFUENTEFINANCIAMIENTO ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Validacion de las fuentes de financiamiento de un contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="IDCONTRATO">Identificador del contrato</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <returns>Valor entero con el resultado de la validacion</returns>

    Public Function validaExisteFuenteFinaciamientoContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Value = IDFUENTEFINANCIAMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtiene el monto de la fuente de financiamiento del contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDCONTRATO">Identificador del contrato</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <returns>Monto por fuente en formato dataset</returns>

    Public Function obtenerMontoFFContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        'strSQL.Append(" SELECT SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO, SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE, 0 AS MONTO, ")
        'strSQL.Append(" 0 AS CHK ")
        'strSQL.Append(" FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES INNER JOIN ")
        'strSQL.Append(" SAB_CAT_FUENTEFINANCIAMIENTOS ON ")
        'strSQL.Append(" SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO = SAB_CAT_FUENTEFINANCIAMIENTOS.IDFUENTEFINANCIAMIENTO INNER ")
        'strSQL.Append("  JOIN ")
        'strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS ON ")
        'strSQL.Append(" SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDESTABLECIMIENTO = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTOSOLICITUD AND ")
        'strSQL.Append(" SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDSOLICITUD = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD INNER JOIN ")
        'strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        'strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        'strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA ")
        'strSQL.Append(" WHERE (SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO = " & IDCONTRATO & ") ")
        'strSQL.Append(" AND (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR = " & IDPROVEEDOR & ") AND ")
        'strSQL.Append(" (SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO NOT IN ")
        'strSQL.Append("     (SELECT SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.IDFUENTEFINANCIAMIENTO ")
        'strSQL.Append("       FROM SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS INNER JOIN ")
        'strSQL.Append("         SAB_CAT_FUENTEFINANCIAMIENTOS AS SAB_CAT_FUENTEFINANCIAMIENTOS_1 ON ")
        'strSQL.Append("        SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.IDFUENTEFINANCIAMIENTO = SAB_CAT_FUENTEFINANCIAMIENTOS_1.IDFUENTEFINANCIAMIENTO ")
        'strSQL.Append("       WHERE (SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        'strSQL.Append("       (SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.IDCONTRATO = " & IDCONTRATO & ") AND ")
        'strSQL.Append("        (SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & "))) ")
        'strSQL.Append(" UNION ")
        'strSQL.Append(" SELECT SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS_1.IDFUENTEFINANCIAMIENTO, SAB_CAT_FUENTEFINANCIAMIENTOS_2.NOMBRE, ")
        'strSQL.Append(" SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS_1.MONTOCONTRATADO, 1 AS chk ")
        'strSQL.Append(" FROM SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS AS SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS_1 INNER JOIN ")
        'strSQL.Append(" SAB_CAT_FUENTEFINANCIAMIENTOS AS SAB_CAT_FUENTEFINANCIAMIENTOS_2 ON ")
        'strSQL.Append(" SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS_1.IDFUENTEFINANCIAMIENTO = SAB_CAT_FUENTEFINANCIAMIENTOS_2.IDFUENTEFINANCIAMIENTO ")
        'strSQL.Append(" WHERE (SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS_1.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        'strSQL.Append(" (SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS_1.IDCONTRATO = " & IDCONTRATO & ") AND ")
        'strSQL.Append(" (SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS_1.IDPROVEEDOR = " & IDPROVEEDOR & ") ")

        strSQL.Append(" SELECT FFC.IDFUENTEFINANCIAMIENTO,FF.NOMBRE,FFC.MONTOCONTRATADO AS MONTO,0 ")
        strSQL.Append(" FROM SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS FFC INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ON ")
        strSQL.Append(" FFC.IDFUENTEFINANCIAMIENTO=FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append(" WHERE (FFC.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (FFC.IDCONTRATO = " & IDCONTRATO & ") AND ")
        strSQL.Append(" (FFC.IDPROVEEDOR = " & IDPROVEEDOR & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Obtiene el monto GOES de un proveedor
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDCONTRATO">Identificador del contrato</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="idprocesocompra">Identificador del proceso de compra</param>
    ''' <returns>Valor decimal con el monto GOES</returns>

    Public Function obtenerMontoGOES(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal idprocesocompra As Integer) As Decimal

        Dim strSQL As New Text.StringBuilder
        ' strSQL.Append(" --goes ")
        strSQL.Append(" select isnull(sum(aec.cantidad*pc.preciounitario),0.0) ")
        strSQL.Append(" from sab_uaci_almacenesentregacontratos aec  ")
        strSQL.Append(" inner join sab_uaci_entregacontrato ec on ")
        strSQL.Append(" ec.idestablecimiento=aec.idestablecimiento and ")
        strSQL.Append(" ec.idproveedor=aec.idproveedor and ")
        strSQL.Append(" ec.idcontrato=aec.idcontrato and ")
        strSQL.Append(" ec.renglon=aec.renglon and ")
        strSQL.Append(" ec.iddetalle=aec.iddetalle inner ")
        strSQL.Append(" join dbo.SAB_UACI_PRODUCTOSCONTRATO pc on ")
        strSQL.Append(" aec.idestablecimiento=pc.idestablecimiento and ")
        strSQL.Append(" aec.idproveedor=pc.idproveedor and ")
        strSQL.Append(" aec.idcontrato=pc.idcontrato and ")
        strSQL.Append(" aec.renglon=pc.renglon inner join ")
        strSQL.Append(" dbo.SAB_UACI_CONTRATOSPROCESOCOMPRA cpc on ")
        strSQL.Append(" cpc.idestablecimiento=pc.idestablecimiento and ")
        strSQL.Append(" cpc.idproveedor=pc.idproveedor and ")
        strSQL.Append(" cpc.idcontrato=pc.idcontrato ")
        strSQL.Append(" where idalmacenentrega not in (77,98,99,100,101,102,103,104,105,106,107,111,112) and ") '  GOES que no sea PEIS cobertura Insumos Medicos o PEIS Cobertura Insumos Laboratorio o medicamentos
        strSQL.Append(" cpc.idprocesocompra=@idprocesocompra and cpc.idestablecimiento=@IDESTABLECIMIENTO  and cpc.idproveedor=@IDPROVEEDOR and cpc.idcontrato=@IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@idprocesocompra", SqlDbType.Int)
        args(3).Value = idprocesocompra

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener Monto PEIS de un contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDCONTRATO">Identificador del contrato</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="idprocesocompra">Identificador del proceso de compra</param>
    ''' <returns>Valor decimal con el monto PEIS</returns>

    Public Function obtenerMontoPEIS(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal idprocesocompra As Integer) As Decimal

        Dim strSQL As New Text.StringBuilder
        ' strSQL.Append(" --peis ")
        strSQL.Append(" select isnull(sum(aec.cantidad*pc.preciounitario),0.0) ")
        strSQL.Append(" from sab_uaci_almacenesentregacontratos aec ")
        strSQL.Append(" inner join sab_uaci_entregacontrato ec on ")
        strSQL.Append(" ec.idestablecimiento=aec.idestablecimiento and ")
        strSQL.Append(" ec.idproveedor=aec.idproveedor and ")
        strSQL.Append(" ec.idcontrato=aec.idcontrato and ")
        strSQL.Append(" ec.renglon=aec.renglon and ")
        strSQL.Append(" ec.iddetalle=aec.iddetalle inner ")
        strSQL.Append(" join dbo.SAB_UACI_PRODUCTOSCONTRATO pc on ")
        strSQL.Append(" aec.idestablecimiento=pc.idestablecimiento and ")
        strSQL.Append(" aec.idproveedor=pc.idproveedor and ")
        strSQL.Append(" aec.idcontrato=pc.idcontrato and ")
        strSQL.Append(" aec.renglon=pc.renglon inner join ")
        strSQL.Append(" dbo.SAB_UACI_CONTRATOSPROCESOCOMPRA cpc on ")
        strSQL.Append(" cpc.idestablecimiento=pc.idestablecimiento and ")
        strSQL.Append(" cpc.idproveedor=pc.idproveedor and ")
        strSQL.Append(" cpc.idcontrato=pc.idcontrato ")
        strSQL.Append(" where idalmacenentrega in (77,99,100,101,102,103,104,105,106,107)  and ") ' PEIS
        strSQL.Append(" cpc.idprocesocompra=@idprocesocompra and cpc.idestablecimiento=@IDESTABLECIMIENTO  and cpc.idproveedor=@IDPROVEEDOR and cpc.idcontrato=@IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@idprocesocompra", SqlDbType.Int)
        args(3).Value = idprocesocompra

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener Monto PEIS Cobertura de un contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDCONTRATO">Identificador del contrato</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="idprocesocompra">Identificador del proceso de compra</param>
    ''' <returns>Valor decimal con el monto PEIS Cobertura</returns>

    Public Function obtenerMontoPEISCobertura(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal idprocesocompra As Integer) As Decimal

        Dim strSQL As New Text.StringBuilder
        'strSQL.Append(" --peis cobertura ")
        strSQL.Append(" select isnull(sum(aec.cantidad*pc.preciounitario),0.0) ")
        strSQL.Append(" from sab_uaci_almacenesentregacontratos aec ")
        strSQL.Append(" inner join sab_uaci_entregacontrato ec on ")
        strSQL.Append(" ec.idestablecimiento=aec.idestablecimiento and ")
        strSQL.Append(" ec.idproveedor=aec.idproveedor and ")
        strSQL.Append(" ec.idcontrato=aec.idcontrato and ")
        strSQL.Append(" ec.renglon=aec.renglon and ")
        strSQL.Append(" ec.iddetalle=aec.iddetalle inner ")
        strSQL.Append(" join dbo.SAB_UACI_PRODUCTOSCONTRATO pc on ")
        strSQL.Append(" aec.idestablecimiento=pc.idestablecimiento and ")
        strSQL.Append(" aec.idproveedor=pc.idproveedor and ")
        strSQL.Append(" aec.idcontrato=pc.idcontrato and ")
        strSQL.Append(" aec.renglon=pc.renglon inner join ")
        strSQL.Append(" dbo.SAB_UACI_CONTRATOSPROCESOCOMPRA cpc on ")
        strSQL.Append(" cpc.idestablecimiento=pc.idestablecimiento and ")
        strSQL.Append(" cpc.idproveedor=pc.idproveedor and ")
        strSQL.Append(" cpc.idcontrato=pc.idcontrato ")
        strSQL.Append(" where idalmacenentrega in (98,111,112) and ") ' PEIS Cobertura medicamentos, insumos medicos e insumos de laboratorio
        strSQL.Append(" cpc.idprocesocompra=@idprocesocompra and cpc.idestablecimiento=@IDESTABLECIMIENTO  and cpc.idproveedor=@IDPROVEEDOR and cpc.idcontrato=@IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@idprocesocompra", SqlDbType.Int)
        args(3).Value = idprocesocompra

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtiene las fuentes de financiamiento de un contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="IDCONTRATO">Identificador del contrato</param>
    ''' <returns>Cadena de caracteres con el nombre del fuente</returns>

    Public Function ObtenerFuentesFinanciamientoContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT FF.NOMBRE ")
        strSQL.Append("FROM SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("INNER JOIN SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS FFC ")
        strSQL.Append("ON FF.IDFUENTEFINANCIAMIENTO = FFC.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("WHERE FFC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND FFC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND FFC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("ORDER BY FF.NOMBRE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim dr As SqlClient.SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim f As String = String.Empty

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    If f <> String.Empty Then f += ", "
                    f += dr.Item(0)
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return f

    End Function

End Class
