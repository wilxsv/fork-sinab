Partial Public Class dbNOTASINCUMPLIMIENTO

#Region " METODOS AGREGADOS"
    ''' <summary>
    ''' Validar existencia de nota
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPROCESO"></param> identificdor de proceso de compra
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_NOTASINCUMPLIMIENTO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarExistenciaNota(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_UACI_NOTASINCUMPLIMIENTO ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Dataset con la informacion de la documentacion faltante por el ofertante
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPROCESO"></param> identificador de proceso
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_OFERTAPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_UACI_DOCUMENTOSOFERTA</description></item>
    ''' <item><description>SAB_CAT_DOCUMENTOSBASE</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOBASE</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' <item><description>SAB_CAT_ESTADOPROCESOSCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_TIPOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_NOTASINCUMPLIMIENTO</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_CARGOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetRptDocumentacionFaltanteOfertante(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("OPC.IDESTABLECIMIENTO, ")
        strSQL.Append("OPC.IDPROCESOCOMPRA, ")
        strSQL.Append("OPC.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
        strSQL.Append("P.DIRECCION, ")
        strSQL.Append("P.REPRESENTANTELEGAL, ")
        strSQL.Append("DO.IDDOCUMENTOBASE, ")
        strSQL.Append("DO.ENTREGADO1, ")
        strSQL.Append("DO.ENTREGADO2, ")
        strSQL.Append("DB.IDTIPODOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION DOCUMENTOBASE, ")
        strSQL.Append("TDB.DESCRIPCION TIPODOCUMENTOBASE, ")
        strSQL.Append("PC.IDTITULAR, ")
        strSQL.Append("PC.IDENTIDADSOLICITA, ")
        strSQL.Append("PC.TITULOLICITACION, ")
        strSQL.Append("PC.DESCRIPCIONLICITACION, ")
        strSQL.Append("PC.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append("PC.IDENCARGADO, ")
        strSQL.Append("PC.IDESTADOPROCESOCOMPRA, ")
        strSQL.Append("PC.FECHAFINANALISIS, ")
        strSQL.Append("RO.ORDENLLEGADA AS ORDENLLEGADAOFERTA, ")
        strSQL.Append("RO.FECHAENTREGA AS FECHAENTREGAOFERTA, ")
        strSQL.Append("RO.PERSONAENTREGA AS PERSONAENTREGAOFERTA, ")
        strSQL.Append("EPC.DESCRIPCION AS ESTADOPROCESO, ")
        strSQL.Append("TC.DESCRIPCION AS COMPRAEJECUTAR, ")
        strSQL.Append("NI.FECHALIMITE, ")
        strSQL.Append("NI.NUMEROOFICIO, ")
        strSQL.Append("NI.IDEMPLEADOEMITE, ")
        strSQL.Append("NI.OBSERVACION AS OBSERVACIONNOTIFICACION, ")
        strSQL.Append("OPC.ESTAHABILITADO, ")
        strSQL.Append("OPC.OBSERVACIONDOCUMENTO, ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("PC.FECHAINICIOANALISIS, ")
        strSQL.Append("E.NOMBRE, ")
        strSQL.Append("E.APELLIDO, ")
        strSQL.Append("C.DESCRIPCION AS CARGO ")
        strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_DOCUMENTOSOFERTA DO ")
        strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON DO.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOBASE TDB ")
        strSQL.Append("ON DB.IDTIPODOCUMENTOBASE = TDB.IDTIPODOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON OPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOPROCESOSCOMPRAS EPC ")
        strSQL.Append("ON PC.IDESTADOPROCESOCOMPRA = EPC.IDESTADOPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_UACI_NOTASINCUMPLIMIENTO NI ")
        strSQL.Append("ON OPC.IDPROVEEDOR = NI.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = NI.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = NI.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS E ")
        strSQL.Append("ON NI.IDEMPLEADOEMITE = E.IDEMPLEADO ")
        strSQL.Append("INNER JOIN SAB_CAT_CARGOS C ")
        strSQL.Append("ON E.IDCARGO = C.IDCARGO ")
        strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESO ")
        strSQL.Append("AND (OPC.IDPROVEEDOR = @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")
        strSQL.Append("AND DO.ENTREGADO1 = 2 ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    '''   dataset con la informacion de la documentacion faltante de los renglones ofertados por el proveedor
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDPROCESO"></param> identificador del proceso de compra
    ''' <param name="IDPROVEEDOR"></param> identificador del proveedor
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_OFERTAPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_CAT_DOCUMENTOSBASE</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOBASE</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_RECEPCIONOFERTAS</description></item>
    ''' <item><description>SAB_CAT_ESTADOPROCESOSCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_TIPOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_NOTASINCUMPLIMIENTO</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_CARGOS</description></item>
    ''' <item><description>SAB_UACI_DETALLEOFERTA</description></item>
    ''' <item><description>SAB_UACI_EXAMENRENGLON</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>

    Public Function DataSetRptDocumentacionFaltanteRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDGRUPOREQTEC As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("OPC.IDESTABLECIMIENTO, ")
        strSQL.Append("OPC.IDPROCESOCOMPRA, ")
        strSQL.Append("OPC.IDPROVEEDOR, ")
        strSQL.Append("OPC.OBSERVACION, ")
        strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
        strSQL.Append("P.DIRECCION, ")
        strSQL.Append("PC.IDTITULAR, ")
        strSQL.Append("PC.IDENTIDADSOLICITA, ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("PC.TITULOLICITACION, ")
        strSQL.Append("PC.DESCRIPCIONLICITACION, ")
        strSQL.Append("PC.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append("PC.IDESTADOPROCESOCOMPRA, ")
        strSQL.Append("RO.ORDENLLEGADA AS ORDENLLEGADAOFERTA, ")
        strSQL.Append("RO.FECHAENTREGA AS FECHAENTREGAOFERTA, ")
        strSQL.Append("RO.PERSONAENTREGA AS PERSONAENTREGAOFERTA, ")
        strSQL.Append("EPC.DESCRIPCION AS ESTADOPROCESO, ")
        strSQL.Append("TC.DESCRIPCION AS COMPRAEJECUTAR, ")
        strSQL.Append("DO.IDDETALLE, DO.RENGLON, ")
        strSQL.Append("DO.CORRELATIVORENGLON, ")
        strSQL.Append("DO.CASAREPRESENTADA, ")
        strSQL.Append("DO.MARCA, ")
        strSQL.Append("DO.ORIGEN, ")
        strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("DO.IDUNIDADMEDIDA, ")
        strSQL.Append("DO.CANTIDAD, DO.VENCIMIENTO, ")
        strSQL.Append("DO.PRECIOUNITARIO, ")
        strSQL.Append("DO.PLAZOENTREGA, ")
        strSQL.Append("DO.NUMEROCSSP, ")
        strSQL.Append("DO.VIGENCIA, ")
        'se adiciona iddocumentooferta
        strSQL.Append("DB.IDDOCUMENTOBASE, ")
        strSQL.Append("UM.DESCRIPCION, ")
        strSQL.Append("TDB.DESCRIPCION AS TIPODOCUMENTO, ")
        strSQL.Append("DB.IDTIPODOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION AS DOCUMENTOBASE, ")
        strSQL.Append("ER.ENTREGADO1, ")
        strSQL.Append("ER.ENTREGADO2, ")
        strSQL.Append("DO.OBSERVACIONDOCUMENTO, ")
        strSQL.Append("OPC.ESTAHABILITADO, ")
        strSQL.Append("P.REPRESENTANTELEGAL, ")
        strSQL.Append("PC.IDENCARGADO, ")
        strSQL.Append("NI.FECHALIMITE, ")
        strSQL.Append("NI.NUMEROOFICIO, ")
        strSQL.Append("NI.IDEMPLEADOEMITE, ")
        strSQL.Append("NI.OBSERVACION AS OBSERVACIONNOTIFICACION, ")
        strSQL.Append("ER.IDDOCUMENTOBASE, ")
        strSQL.Append("E.NOMBRE, ")
        strSQL.Append("E.APELLIDO, ")
        strSQL.Append("C.DESCRIPCION AS CARGO ")
        strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON OPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOPROCESOSCOMPRAS EPC ")
        strSQL.Append("ON PC.IDESTADOPROCESOCOMPRA = EPC.IDESTADOPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_UACI_EXAMENRENGLON ER ")
        strSQL.Append("ON DO.IDPROCESOCOMPRA = ER.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = ER.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = ER.IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = ER.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON ER.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOBASE TDB ")
        strSQL.Append("ON DB.IDTIPODOCUMENTOBASE = TDB.IDTIPODOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
        strSQL.Append("ON DO.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("INNER JOIN SAB_UACI_NOTASINCUMPLIMIENTO NI ")
        strSQL.Append("ON OPC.IDPROVEEDOR = NI.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = NI.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = NI.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS E ")
        strSQL.Append("ON NI.IDEMPLEADOEMITE = E.IDEMPLEADO ")
        strSQL.Append("INNER JOIN SAB_CAT_CARGOS C ")
        strSQL.Append("ON E.IDCARGO = C.IDCARGO ")

        'ojo
        strSQL.Append("left JOIN SAB_CAT_GRUPOSREQTECNICOS GRT ")
        strSQL.Append("ON GRT.IDGRUPOREQ = db.IDGRUPOREQTEC ")

        'strSQL.Append("INNER JOIN SAB_UACI_GRUPOREQTEC_PRODUCTOS GP  ")
        'strSQL.Append("ON GP.IDGRUPOREQ = GRT.IDGRUPOREQ ")
        'strSQL.Append("AND GP.IDPRODUCTO = @IDPRODUCTO ")

        strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESO ")
        strSQL.Append("AND (OPC.IDPROVEEDOR = @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")
        strSQL.Append("AND ER.ENTREGADO1 = 2 ")
        strSQL.Append("and (db.IDGRUPOREQTEC=@IDGRUPOREQTEC or @IDGRUPOREQTEC=0) ")




        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDGRUPOREQTEC", SqlDbType.Int)
        args(3).Value = IDGRUPOREQTEC

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' validar existencia de numero de oficio
    ''' </summary>
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <param name="NUMEROOFICIO"></param> numero de oficio
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_UACI_NOTASINCUMPLIMIENTO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarNumeroOficio(ByVal IDPROVEEDOR As Int32, ByVal NUMEROOFICIO As String, ByVal IDESTABLECIMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_UACI_NOTASINCUMPLIMIENTO ")
        strSQL.Append("WHERE NUMEROOFICIO = @NUMEROOFICIO ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR <> @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@NUMEROOFICIO", SqlDbType.VarChar)
        args(0).Value = NUMEROOFICIO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

    ''' <summary>
    ''' Obtener fecha de examen preliminar
    ''' </summary>
    ''' <param name="IDPROCESO"></param> identificador de proceso
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <returns>
    ''' fecha de examen preliminar
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerFechaExamenPreliminar(ByVal IDPROCESO As Int32, ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROVEEDOR As Int64) As Date

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT FECHAEXAMEN ")
        strSQL.Append(" FROM SAB_UACI_OFERTAPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        If (SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)) Is DBNull.Value Then
            Return Nothing
        Else
            Return CDate(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args))
        End If

    End Function
    ''' <summary>
    ''' Consulta de la documentación faltante
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <returns>Listado de la información en formato dataset</returns>

    Public Function RptDocumentacionFaltante(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("OPC.IDESTABLECIMIENTO, ")
        strSQL.Append("OPC.IDPROCESOCOMPRA, ")
        strSQL.Append("OPC.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        strSQL.Append("P.DIRECCION, ")
        strSQL.Append("isnull(TC.DESCRIPCION, '') + ' ' + isnull(PC.CODIGOLICITACION, '') + ' ' + isnull(PC.DESCRIPCIONLICITACION, '') DESCRIPCIONPROCESO, ")
        strSQL.Append("NI.FECHALIMITE, ")
        strSQL.Append("RO.ORDENLLEGADA , ")
        strSQL.Append("NI.NUMEROOFICIO, ")
        strSQL.Append("isnull(NI.OBSERVACION, '') OBSERVACIONNOTIFICACION, ")
        strSQL.Append("isnull(E.NOMBRE, '') + ' ' + isnull(E.APELLIDO, '') EMPLEADOEMITE, ")
        strSQL.Append("C.DESCRIPCION CARGO ")
        strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_UACI_EXAMENRENGLON ER ")
        strSQL.Append("ON DO.IDPROCESOCOMPRA = ER.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = ER.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = ER.IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = ER.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON OPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_UACI_NOTASINCUMPLIMIENTO NI ")
        strSQL.Append("ON OPC.IDPROVEEDOR = NI.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = NI.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = NI.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS E ")
        strSQL.Append("ON NI.IDEMPLEADOEMITE = E.IDEMPLEADO ")
        strSQL.Append("INNER JOIN SAB_CAT_CARGOS C ")
        strSQL.Append("ON E.IDCARGO = C.IDCARGO ")
        strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND ER.ENTREGADO1 = 2 ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT ")
        strSQL.Append("OPC.IDESTABLECIMIENTO, ")
        strSQL.Append("OPC.IDPROCESOCOMPRA, ")
        strSQL.Append("OPC.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        strSQL.Append("P.DIRECCION, ")
        strSQL.Append("isnull(TC.DESCRIPCION, '') + ' ' + isnull(PC.CODIGOLICITACION, '') + ' ' + isnull(PC.DESCRIPCIONLICITACION, '') DESCRIPCIONPROCESO, ")
        strSQL.Append("NI.FECHALIMITE, ")
        strSQL.Append("RO.ORDENLLEGADA, ")
        strSQL.Append("NI.NUMEROOFICIO, ")
        strSQL.Append("isnull(NI.OBSERVACION, '') OBSERVACIONNOTIFICACION, ")
        strSQL.Append("isnull(E.NOMBRE, '') + ' ' + isnull(E.APELLIDO, '') EMPLEADOEMITE, ")
        strSQL.Append("C.DESCRIPCION CARGO ")
        strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_DOCUMENTOSOFERTA DO ")
        strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON OPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_UACI_NOTASINCUMPLIMIENTO NI ")
        strSQL.Append("ON OPC.IDPROVEEDOR = NI.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = NI.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = NI.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS E ")
        strSQL.Append("ON NI.IDEMPLEADOEMITE = E.IDEMPLEADO ")
        strSQL.Append("INNER JOIN SAB_CAT_CARGOS C ")
        strSQL.Append("ON E.IDCARGO = C.IDCARGO ")
        strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.ENTREGADO1 = 2 ")
        strSQL.Append("ORDER BY ORDENLLEGADA ")

        'renglones
        strSQL.Append("SELECT ")
        strSQL.Append("OPC.IDESTABLECIMIENTO, ")
        strSQL.Append("OPC.IDPROCESOCOMPRA, ")
        strSQL.Append("OPC.IDPROVEEDOR, ")
        strSQL.Append("DO.RENGLON, ")
        strSQL.Append("DO.MARCA, ")
        strSQL.Append("DB.IDTIPODOCUMENTOBASE, ")
        strSQL.Append("TDB.DESCRIPCION TIPODOCUMENTOBASE, ")
        strSQL.Append("ER.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION DOCUMENTOBASE, ")
        strSQL.Append("isnull(DO.OBSERVACIONDOCUMENTO, '') OBSERVACIONDOCUMENTO ")
        strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_UACI_EXAMENRENGLON ER ")
        strSQL.Append("ON DO.IDPROCESOCOMPRA = ER.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = ER.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = ER.IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = ER.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON ER.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOBASE TDB ")
        strSQL.Append("ON DB.IDTIPODOCUMENTOBASE = TDB.IDTIPODOCUMENTOBASE ")
        strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND (OPC.IDPROVEEDOR = @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")
        strSQL.Append("AND ER.ENTREGADO1 = 2 ")

        'ofertas
        strSQL.Append("SELECT ")
        strSQL.Append("OPC.IDESTABLECIMIENTO, ")
        strSQL.Append("OPC.IDPROCESOCOMPRA, ")
        strSQL.Append("OPC.IDPROVEEDOR, ")
        strSQL.Append("DB.IDTIPODOCUMENTOBASE, ")
        strSQL.Append("TDB.DESCRIPCION TIPODOCUMENTOBASE, ")
        strSQL.Append("DO.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION DOCUMENTOBASE, ")
        strSQL.Append("isnull(OPC.OBSERVACIONDOCUMENTO, '') OBSERVACIONDOCUMENTO, ")
        strSQL.Append("isnull(NI.OBSERVACION, '') AS OBSERVACIONNOTIFICACION ")
        strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
        strSQL.Append("INNER JOIN SAB_UACI_DOCUMENTOSOFERTA DO ")
        strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON DO.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOBASE TDB ")
        strSQL.Append("ON DB.IDTIPODOCUMENTOBASE = TDB.IDTIPODOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_UACI_NOTASINCUMPLIMIENTO NI ")
        strSQL.Append("ON OPC.IDPROVEEDOR = NI.IDPROVEEDOR ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = NI.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDESTABLECIMIENTO = NI.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND (OPC.IDPROVEEDOR = @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")
        strSQL.Append("AND DO.ENTREGADO1 = 2 ")

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

#End Region

End Class
