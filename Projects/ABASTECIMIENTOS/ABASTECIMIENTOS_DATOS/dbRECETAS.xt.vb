Partial Public Class dbRECETAS

#Region " Metodos Agregados "

    ''' <summary>
    ''' En esta función para dataset de recetas SIM por producto
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <param name="FECHAINICIO"></param> fecha de inicio
    ''' <param name="FECHAFIN"></param> fecha de fin
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_RECETAS</description></item>
    ''' <item><description>SAB_EST_DETALLERECETA</description></item>
    ''' <item><description>SAB_CAT_SERVICIOSHOSPITALARIOS</description></item>
    ''' <item><description>SAB_CAT_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_CAT_TIPOESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ZONAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DataSetRecetaXproducto(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal FECHAINICIO As Date, ByVal FECHAFIN As Date) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("R.IDESTABLECIMIENTO, ")
        strSQL.Append("R.IDRECETA, ")
        strSQL.Append("R.NUMERORECETA, ")
        strSQL.Append("SH.NOMBRESERVICIO, ")
        strSQL.Append("SH.CODIGOSERVICIO, ")
        strSQL.Append("R.FECHARECETA, ")
        strSQL.Append("R.MEDICO, ")
        strSQL.Append("R.DESPACHADO, ")
        strSQL.Append("DR.IDDETALLE, ")
        strSQL.Append("DR.CANTIDAD, ")
        strSQL.Append("CP.NOMBRE, ")
        strSQL.Append("CP.CONCENTRACION, ")
        strSQL.Append("CP.FORMAFARMACEUTICA, ")
        strSQL.Append("CP.PRESENTACION, ")
        strSQL.Append("E.NOMBRE AS ESTABLECIMIENTO, ")
        strSQL.Append("UM.DESCRIPCION AS UNIDAD, ")
        strSQL.Append("E.NIVEL, ")
        strSQL.Append("TE.DESCRIPCION AS TIPOESTABLECIM, ")
        strSQL.Append("Z.DESCRIPCION AS ZONA, ")
        strSQL.Append("R.IDSERVICIOHOSPITALARIO, ")
        strSQL.Append("DR.IDPRODUCTO, ")
        strSQL.Append("CP.CODIGO ")
        strSQL.Append("FROM SAB_EST_RECETAS R ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLERECETA DR ")
        strSQL.Append("ON (R.IDESTABLECIMIENTO = DR.IDESTABLECIMIENTO ")
        strSQL.Append("AND R.IDCARGA = DR.IDCARGA ")
        strSQL.Append("AND R.IDRECETA = DR.IDRECETA) ")
        strSQL.Append("INNER JOIN SAB_CAT_SERVICIOSHOSPITALARIOS SH ")
        strSQL.Append("ON R.IDSERVICIOHOSPITALARIO = SH.IDSERVICIOHOSPITALARIO ")
        strSQL.Append("INNER JOIN SAB_CAT_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DR.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON R.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
        strSQL.Append("ON DR.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOESTABLECIMIENTOS TE ")
        strSQL.Append("ON E.IDTIPOESTABLECIMIENTO = TE.IDTIPOESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ZONAS Z ")
        strSQL.Append("ON E.IDZONA = Z.IDZONA ")
        strSQL.Append("WHERE ")
        strSQL.Append("R.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DR.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND (R.FECHARECETA between @FECHAINICIO AND @FECHAFIN) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("R.IDESTABLECIMIENTO, ")
        strSQL.Append("R.IDRECETA, ")
        strSQL.Append("R.NUMERORECETA, ")
        strSQL.Append("SH.NOMBRESERVICIO, ")
        strSQL.Append("SH.CODIGOSERVICIO, ")
        strSQL.Append("R.FECHARECETA, ")
        strSQL.Append("R.MEDICO, ")
        strSQL.Append("R.DESPACHADO, ")
        strSQL.Append("DR.IDDETALLE, ")
        strSQL.Append("DR.CANTIDAD, ")
        strSQL.Append("CP.NOMBRE, ")
        strSQL.Append("CP.CONCENTRACION, ")
        strSQL.Append("CP.FORMAFARMACEUTICA, ")
        strSQL.Append("CP.PRESENTACION, ")
        strSQL.Append("E.NOMBRE, ")
        strSQL.Append("UM.DESCRIPCION, ")
        strSQL.Append("E.NIVEL, ")
        strSQL.Append("TE.DESCRIPCION, ")
        strSQL.Append("Z.DESCRIPCION, ")
        strSQL.Append("R.IDSERVICIOHOSPITALARIO, ")
        strSQL.Append("DR.IDPRODUCTO, ")
        strSQL.Append("CP.CODIGO ")
        strSQL.Append("ORDER BY R.NUMERORECETA")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(2).Value = FECHAINICIO
        args(3) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(3).Value = FECHAFIN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' En esta función para dataset de recetas SIM por servicio hospitalario
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador establecimento
    ''' <param name="IDSERVICIO"></param> identificadro de servicio 
    ''' <param name="FECHAINICIO"></param> fecha de inicio
    ''' <param name="FECHAFIN"></param> fecha de fin
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_RECETAS</description></item>
    ''' <item><description>SAB_EST_DETALLERECETA</description></item>
    ''' <item><description>SAB_CAT_SERVICIOSHOSPITALARIOS</description></item>
    ''' <item><description>SAB_CAT_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_CAT_TIPOESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ZONAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 

    Public Function DataSetRecetaXServicioHosp(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSERVICIO As Int32, ByVal FECHAINICIO As Date, ByVal FECHAFIN As Date) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("R.IDESTABLECIMIENTO, ")
        strSQL.Append("R.IDRECETA, ")
        strSQL.Append("R.NUMERORECETA, ")
        strSQL.Append("SH.NOMBRESERVICIO, ")
        strSQL.Append("SH.CODIGOSERVICIO, ")
        strSQL.Append("R.FECHARECETA, ")
        strSQL.Append("R.MEDICO, ")
        strSQL.Append("R.DESPACHADO, ")
        strSQL.Append("DR.IDDETALLE, ")
        strSQL.Append("DR.CANTIDAD, ")
        strSQL.Append("CP.NOMBRE, ")
        strSQL.Append("CP.CONCENTRACION, ")
        strSQL.Append("CP.FORMAFARMACEUTICA, ")
        strSQL.Append("CP.PRESENTACION, ")
        strSQL.Append("E.NOMBRE AS ESTABLECIMIENTO, ")
        strSQL.Append("UM.DESCRIPCION AS UNIDAD, ")
        strSQL.Append("E.NIVEL, ")
        strSQL.Append("TE.DESCRIPCION AS TIPOESTABLECIM, ")
        strSQL.Append("Z.DESCRIPCION AS ZONA, ")
        strSQL.Append("R.IDSERVICIOHOSPITALARIO, ")
        strSQL.Append("DR.IDPRODUCTO, ")
        strSQL.Append("CP.CODIGO ")
        strSQL.Append("FROM SAB_EST_RECETAS R ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLERECETA DR ")
        strSQL.Append("ON (R.IDESTABLECIMIENTO = DR.IDESTABLECIMIENTO ")
        strSQL.Append("AND R.IDCARGA = DR.IDCARGA ")
        strSQL.Append("AND R.IDRECETA = DR.IDRECETA) ")
        strSQL.Append("INNER JOIN SAB_CAT_SERVICIOSHOSPITALARIOS SH ")
        strSQL.Append("ON R.IDSERVICIOHOSPITALARIO = SH.IDSERVICIOHOSPITALARIO ")
        strSQL.Append("INNER JOIN SAB_CAT_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DR.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON R.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
        strSQL.Append("ON DR.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOESTABLECIMIENTOS TE ")
        strSQL.Append("ON E.IDTIPOESTABLECIMIENTO = TE.IDTIPOESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ZONAS Z ")
        strSQL.Append("ON E.IDZONA = Z.IDZONA ")
        strSQL.Append("WHERE R.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND R.IDSERVICIOHOSPITALARIO = @IDSERVICIO ")
        strSQL.Append("AND (R.FECHARECETA BETWEEN @FECHAINICIO AND @FECHAFIN) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("R.IDESTABLECIMIENTO, ")
        strSQL.Append("R.IDRECETA, ")
        strSQL.Append("R.NUMERORECETA, ")
        strSQL.Append("SH.NOMBRESERVICIO, ")
        strSQL.Append("SH.CODIGOSERVICIO, ")
        strSQL.Append("R.FECHARECETA, ")
        strSQL.Append("R.MEDICO, ")
        strSQL.Append("R.DESPACHADO, ")
        strSQL.Append("DR.IDDETALLE, ")
        strSQL.Append("DR.CANTIDAD, ")
        strSQL.Append("CP.NOMBRE, ")
        strSQL.Append("CP.CONCENTRACION, ")
        strSQL.Append("CP.FORMAFARMACEUTICA, ")
        strSQL.Append("CP.PRESENTACION, ")
        strSQL.Append("E.NOMBRE, ")
        strSQL.Append("UM.DESCRIPCION, ")
        strSQL.Append("E.NIVEL, ")
        strSQL.Append("TE.DESCRIPCION, ")
        strSQL.Append("Z.DESCRIPCION, ")
        strSQL.Append("R.IDSERVICIOHOSPITALARIO, ")
        strSQL.Append("DR.IDPRODUCTO, ")
        strSQL.Append("CP.CODIGO ")
        strSQL.Append("ORDER BY R.NUMERORECETA")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDSERVICIO", SqlDbType.Int)
        args(0).Value = IDSERVICIO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(2).Value = FECHAINICIO
        args(3) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(3).Value = FECHAFIN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' En esta función para dataset de recetas SIM
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_RECETAS</description></item>
    ''' <item><description>SAB_EST_DETALLERECETA</description></item>
    ''' <item><description>SAB_CAT_SERVICIOSHOSPITALARIOS</description></item>
    ''' <item><description>SAB_CAT_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_CAT_TIPOESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ZONAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 

    Public Function DataSetImportacionSIM(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("SIMR.IDESTABLECIMIENTO, ")
        strSQL.Append("SIMR.FECHA, ")
        strSQL.Append("SIMS.NOMDEP AS SERVICIO, ")
        strSQL.Append("SIMM.NOMMED AS MEDICO, ")
        strSQL.Append("SUM(SIMDR.CANTIDAD) AS TOTAL, ")
        strSQL.Append("SIMDR.CODDRO AS CODIGO, ")
        strSQL.Append("CP.IDPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO AS PRODUCTO, ")
        strSQL.Append("CP.DESCRIPCION AS UNIDAD, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.UNIDADESCONTENIDAS, ")
        strSQL.Append("CAST(SUM(SIMDR.CANTIDAD) / CP.UNIDADESCONTENIDAS AS DECIMAL(15, 2)) AS DIVISION ")
        strSQL.Append("FROM SAB_EST_SIMDETALLERECETAS SIMDR ")
        strSQL.Append("INNER JOIN SAB_EST_SIMMEDICOS SIMM ")
        strSQL.Append("ON SIMDR.IDESTABLECIMIENTO = SIMM.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_EST_SIMRECETAS SIMR ")
        strSQL.Append("ON (SIMDR.IDESTABLECIMIENTO = SIMR.IDESTABLECIMIENTO ")
        strSQL.Append("AND SIMDR.NUMRE = SIMR.NUMRE ")
        strSQL.Append("AND SIMM.IDESTABLECIMIENTO = SIMR.IDESTABLECIMIENTO ")
        strSQL.Append("AND SIMM.CODMED = SIMR.CODMED) ")
        strSQL.Append("INNER JOIN SAB_EST_SIMSERVICIOS SIMS ")
        strSQL.Append("ON (SIMR.IDESTABLECIMIENTO = SIMS.IDESTABLECIMIENTO ")
        strSQL.Append("AND SIMR.CODDEP = SIMS.CODDEP) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON SIMDR.CODDRO = CP.CORRPRODUCTO ")
        strSQL.Append("WHERE SIMR.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("SIMR.IDESTABLECIMIENTO, ")
        strSQL.Append("SIMR.FECHA, ")
        strSQL.Append("SIMS.NOMDEP, ")
        strSQL.Append("SIMM.NOMMED, ")
        strSQL.Append("SIMDR.CODDRO, ")
        strSQL.Append("CP.IDPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.UNIDADESCONTENIDAS ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Data set de servicios hospitalarios SIM
    ''' </summary>
    ''' <param name="idEstablecimiento"></param> identificadro de establecimiento
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SIMSERVICIOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetServiciosSIM(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDESTABLECIMIENTO, CODDEP, NOMDEP ")
        strSQL.Append("FROM SAB_EST_SIMSERVICIOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' En esta función para dataset de recetas SIM
    ''' </summary>
    ''' <param name="idEstablecimiento"></param> identificador establecimientos
    ''' <param name="idCarga"></param> identificador de carga
    ''' <returns>
    ''' </returns>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SIMRECETAS</description></item>
    ''' <item><description>SAB_EST_SIMMEDICOS</description></item>
    ''' <item><description>SAB_EST_CARGADATOSSIM</description></item>
    ''' <item><description>SAB_CAT_SERVICIOSHOSPITALARIOS</description></item>
    ''' </list>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetRecetasSIM(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCARGA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_SIMRECETAS.NUMRE, SAB_EST_SIMRECETAS.FECHA, SAB_EST_SIMMEDICOS.NOMMED AS MEDICO, SAB_EST_CARGADATOSSIM.IDCARGA, SAB_EST_SIMRECETAS.IDESTABLECIMIENTO, ")
        strSQL.Append("SAB_CAT_SERVICIOSHOSPITALARIOS.IDSERVICIOHOSPITALARIO, SAB_EST_SIMRECETAS.CODDEP ")
        strSQL.Append("FROM SAB_EST_SIMMEDICOS INNER JOIN ")
        strSQL.Append("SAB_EST_SIMRECETAS ON SAB_EST_SIMMEDICOS.IDESTABLECIMIENTO = SAB_EST_SIMRECETAS.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_EST_SIMMEDICOS.CODMED = SAB_EST_SIMRECETAS.CODMED INNER JOIN ")
        strSQL.Append("SAB_EST_CARGADATOSSIM ON SAB_EST_SIMRECETAS.IDESTABLECIMIENTO = SAB_EST_CARGADATOSSIM.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_SERVICIOSHOSPITALARIOS ON SAB_EST_CARGADATOSSIM.IDESTABLECIMIENTO = SAB_CAT_SERVICIOSHOSPITALARIOS.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_EST_SIMRECETAS.CODDEP = SAB_CAT_SERVICIOSHOSPITALARIOS.CODIGOSERVICIO ")
        strSQL.Append("WHERE SAB_EST_SIMRECETAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_EST_CARGADATOSSIM.IDCARGA = @IDCARGA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = IDCARGA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Dataset detalle de reseta SIM
    ''' </summary>
    ''' <param name="idEstablecimiento"></param> identificador de establecimiento
    ''' <param name="idCarga"></param>identificador de carga
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_RECETAS</description></item>
    ''' <item><description>SAB_EST_SIMDETALLERECETAS</description></item>
    ''' <item><description>SAB_EST_CARGADATOSSIM</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>

    Public Function DataSetDetalleRecetasSIM(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCARGA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_CARGADATOSSIM.IDCARGA, SAB_EST_CARGADATOSSIM.IDESTABLECIMIENTO, SAB_EST_SIMDETALLERECETAS.CODDRO, vv_CATALOGOPRODUCTOS.IDPRODUCTO, ")
        strSQL.Append("SAB_EST_SIMDETALLERECETAS.CANTIDAD, vv_CATALOGOPRODUCTOS.IDUNIDADMEDIDA, vv_CATALOGOPRODUCTOS.UNIDADESCONTENIDAS, ")
        strSQL.Append("CAST(SAB_EST_SIMDETALLERECETAS.CANTIDAD / vv_CATALOGOPRODUCTOS.UNIDADESCONTENIDAS AS DECIMAL(15, 2)) AS DIVISION, ")
        strSQL.Append("SAB_EST_RECETAS.NUMERORECETA, SAB_EST_RECETAS.IDRECETA ")
        strSQL.Append("FROM SAB_EST_RECETAS INNER JOIN ")
        strSQL.Append("SAB_EST_CARGADATOSSIM ON SAB_EST_RECETAS.IDESTABLECIMIENTO = SAB_EST_CARGADATOSSIM.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_EST_RECETAS.IDCARGA = SAB_EST_CARGADATOSSIM.IDCARGA INNER JOIN ")
        strSQL.Append("SAB_EST_SIMDETALLERECETAS INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS ON SAB_EST_SIMDETALLERECETAS.CODDRO = vv_CATALOGOPRODUCTOS.CORRPRODUCTO ON ")
        strSQL.Append("SAB_EST_RECETAS.NUMERORECETA = SAB_EST_SIMDETALLERECETAS.NUMRE ")
        strSQL.Append("WHERE SAB_EST_CARGADATOSSIM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_EST_CARGADATOSSIM.IDCARGA = @IDCARGA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = IDCARGA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Calcula cantidad de resetas por establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' cantidad de recetas por establecimiento
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SIMRECETAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CantidadRecetas(ByVal IDESTABLECIMIENTO As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_EST_SIMRECETAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND ESTASINCRONIZADA = 1 ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return CInt(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args))

    End Function

    ''' <summary>
    ''' Calcula cantidad de productos recetados en receta
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' cantidad de roductos por receta
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SIMDETALLERECETAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>

    Public Function CantidadDetalleRecetas(ByVal IDESTABLECIMIENTO As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_EST_SIMDETALLERECETAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND ESTASINCRONIZADA = 1 ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return CInt(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args))

    End Function

    ''' <summary>
    ''' dataset con la informacion del detalle de la receta
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SIMDETALLERECETAS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataDetalleConsumo(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("SUM(SIMDR.CANTIDAD) AS TOTAL, ")
        strSQL.Append("SIMDR.CODDRO AS CODIGO, ")
        strSQL.Append("CP.IDPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO AS PRODUCTO, ")
        strSQL.Append("CP.DESCRIPCION AS UNIDAD, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.UNIDADESCONTENIDAS, ")
        strSQL.Append("CAST(SUM(SIMDR.CANTIDAD) / CP.UNIDADESCONTENIDAS AS DECIMAL(15, 2)) AS DIVISION, ")
        strSQL.Append("SIMDR.IDESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_EST_SIMDETALLERECETAS SIMDR ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON SIMDR.CODDRO = CP.CORRPRODUCTO ")
        strSQL.Append("WHERE SIMDR.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("SIMDR.CODDRO, ")
        strSQL.Append("CP.IDPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.UNIDADESCONTENIDAS, ")
        strSQL.Append("SIMDR.IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
