Partial Public Class dbADJUDICACION

#Region " Métodos Agregados "

    ''' <summary>
    ''' Obtiene los proveedores adjudicados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function obtenerDatasetProveedoresAdjudicados(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("A.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON A.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND A.CANTIDADFIRME > 0 ")
        strSQL.Append("ORDER BY P.NOMBRE ")

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
    ''' Obtiene informacion de las adjudicaciones
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' <item>SAB_CAT_PROVEEDORES</item>
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>SAB_UACI_RECEPCIONOFERTAS</item>
    ''' <item>SAB_UACI_NOTASACEPTACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function obtenerDatasetProveedoresAdjudicadosConNotas(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("RO.ORDENLLEGADA AS OFERTA, ")
        strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
        strSQL.Append("SUM(A.CANTIDADFIRME * DO.PRECIOUNITARIO) AS MONTO, ")
        strSQL.Append("CASE WHEN ISNULL(NA.PRESENTANOTA, 0) = 0 THEN 'NO' ELSE 'SI' END AS ACEPTA ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON A.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = RO.IDPROVEEDOR) ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_NOTASACEPTACION NA ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = NA.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = NA.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = NA.IDPROVEEDOR) ")
        strSQL.Append("WHERE ")
        strSQL.Append("(A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("AND (A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (A.CANTIDADFIRME > 0) ")
        strSQL.Append("GROUP BY P.NOMBRE, ISNULL(NA.PRESENTANOTA, 0), RO.ORDENLLEGADA ")
        strSQL.Append("ORDER BY OFERTA ")

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
    ''' Obtiene el reporte de los proveedores adjudicados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' <item>SAB_CAT_PROVEEDORES</item>
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>SAB_UACI_RECEPCIONOFERTAS</item>
    ''' <item>SAB_UACI_PROCESOCOMPRAS</item>
    ''' <item>SAB_CAT_ESTABLECIMIENTOS</item>
    ''' <item>SAB_UACI_NOTASACEPTACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function RptObtenerDatasetProveedoresAdjudicadosConNotas(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("RO.ORDENLLEGADA AS OFERTA, ")
        strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
        strSQL.Append("SUM(A.CANTIDADFIRME * DO.PRECIOUNITARIO) AS MONTO, ")
        strSQL.Append("CASE WHEN ISNULL(NA.PRESENTANOTA, 0) = 0 THEN 'No' ELSE 'Si' END AS ACEPTA, ")
        strSQL.Append("PC.CODIGOLICITACION AS CODIGOPROCESO, ")
        strSQL.Append("PC.DESCRIPCIONLICITACION NOMBREPROCESO, ")
        strSQL.Append("E.NOMBRE AS ESTABLECIMIENTO, ")
        strSQL.Append("A.IDPROCESOCOMPRA, ")
        strSQL.Append("A.IDESTABLECIMIENTO, ")
        strSQL.Append("convert(varchar, NA.FECHARECEPCION, 103) FECHARECEPCION ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON A.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = RO.IDPROVEEDOR) ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA) ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_NOTASACEPTACION NA ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = NA.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = NA.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = NA.IDPROVEEDOR) ")
        strSQL.Append("WHERE ")
        strSQL.Append("(A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("AND (A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (A.CANTIDADFIRME > 0) ")
        strSQL.Append("GROUP BY P.NOMBRE, ISNULL(NA.PRESENTANOTA, 0), RO.ORDENLLEGADA, ")
        strSQL.Append("PC.CODIGOLICITACION, PC.TITULOLICITACION,PC.DESCRIPCIONLICITACION, E.NOMBRE, NA.FECHARECEPCION ,")
        strSQL.Append("A.IDPROCESOCOMPRA, A.IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY OFERTA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener las solvencias de los proveedores adjudicados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>DataSet</returns>

    Public Function RptObtenerDatasetProveedoresAdjudicadosSolvencias(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA AS OFERTA, SAB_CAT_PROVEEDORES.NOMBRE AS PROVEEDOR, ")
        strSQL.Append(" SUM(SAB_UACI_ADJUDICACION.CANTIDADFIRME * SAB_UACI_DETALLEOFERTA.PRECIOUNITARIO) AS MONTO, ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION AS CODIGOPROCESO, (SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION + ' ' + SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION) AS NOMBREPROCESO, ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS.NOMBRE AS ESTABLECIMIENTO, SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO, Convert(varchar(10), SAB_UACI_NOTASACEPTACION.AFPCONFIARECEPCION, 103) ")
        strSQL.Append(" AS AFPCONFIARECEPCION, CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.AFPCONFIAVIGENCIA, 103) AS AFPCONFIAVIGENCIA, ")
        strSQL.Append(" CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.AFPCRECERRECEPCION, 103) AS AFPCRECERRECEPCION, CONVERT(varchar(10), ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION.AFPCRECERVIGENCIA, 103) AS AFPCRECERVIGENCIA, CONVERT(varchar(10), ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION.IPFARECEPCION, 103) AS IPFARECEPCION, CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.IPFAVIGENCIA, 103) ")
        strSQL.Append(" AS IPFAVIGENCIA, CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.SSRECEPCION, 103) AS SSRECEPCION, CONVERT(varchar(10), ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION.SSVIGENCIA, 103) AS SSVIGENCIA, CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.ISSSRECEPCION, 103) ")
        strSQL.Append(" AS ISSSRECEPCION, CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.ISSSVIGENCIA, 103) AS ISSSVIGENCIA, CONVERT(varchar(10), ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION.IMPUESTOSRECEPCION, 103) AS IMPUESTOSRECEPCION, CONVERT(varchar(10), ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION.IMPUESTOSVIGENCIA, 103) AS IMPUESTOSVIGENCIA, CONVERT(varchar(10), ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION.ALCALDIARECEPCION, 103) AS ALCALDIARECEPCION, CONVERT(varchar(10), ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION.ALCALDIAVIGENCIA, 103) AS ALCALDIAVIGENCIA ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS ON SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS ON SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS ON ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION ON SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_NOTASACEPTACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_NOTASACEPTACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_NOTASACEPTACION.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND ")
        strSQL.Append(" (SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_ADJUDICACION.CANTIDADFIRME > 0) ")
        strSQL.Append(" GROUP BY SAB_CAT_PROVEEDORES.NOMBRE, SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, SAB_CAT_ESTABLECIMIENTOS.NOMBRE, SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO, CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.AFPCONFIARECEPCION, 103), ")
        strSQL.Append(" CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.AFPCONFIAVIGENCIA, 103), CONVERT(varchar(10), ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION.AFPCRECERRECEPCION, 103), CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.AFPCRECERVIGENCIA, 103), ")
        strSQL.Append(" CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.IPFARECEPCION, 103), CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.IPFAVIGENCIA, ")
        strSQL.Append(" 103), CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.SSRECEPCION, 103), CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.SSVIGENCIA, ")
        strSQL.Append(" 103), CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.ISSSRECEPCION, 103), CONVERT(varchar(10), ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION.ISSSVIGENCIA, 103), CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.IMPUESTOSRECEPCION, 103), ")
        strSQL.Append(" CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.IMPUESTOSVIGENCIA, 103), CONVERT(varchar(10), ")
        strSQL.Append(" SAB_UACI_NOTASACEPTACION.ALCALDIARECEPCION, 103), CONVERT(varchar(10), SAB_UACI_NOTASACEPTACION.ALCALDIAVIGENCIA, 103) ")
        strSQL.Append(" ORDER BY OFERTA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener las cantidades adjudicadas, recomendadas y en firme
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador del detalle de la oferta.</param>
    ''' <returns>DataSet.</returns>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerCantidades(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CANTIDADRECOMENDACION, ")
        strSQL.Append("CANTIDADADJUDICADA, ")
        strSQL.Append("CANTIDADFIRME ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION ")
        strSQL.Append("WHERE ")
        strSQL.Append("IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.TinyInt)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Agrega o actualiza la cantidad recomendada/adjudicada/adjudicada en firme a una oferta dada.
    ''' </summary>
    ''' <param name="aEntidad">Entidad ADJUDICACION.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function AgregarCantidad(ByVal aEntidad As ADJUDICACION) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("IF NOT EXISTS ")
        strSQL.Append("    ( ")
        strSQL.Append("        SELECT ")
        strSQL.Append("        IDDETALLE ")
        strSQL.Append("        FROM SAB_UACI_ADJUDICACION ")
        strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("        AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("        AND IDDETALLE = @IDDETALLE ")
        strSQL.Append("    ) ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    INSERT INTO SAB_UACI_ADJUDICACION ")
        strSQL.Append("    ( IDPROCESOCOMPRA, ")
        strSQL.Append("    IDESTABLECIMIENTO, ")
        strSQL.Append("    IDPROVEEDOR, ")
        strSQL.Append("    IDDETALLE, ")
        strSQL.Append("    CANTIDADRECOMENDACION, ")
        strSQL.Append("    CANTIDADADJUDICADA, ")
        strSQL.Append("    CANTIDADFIRME, ")
        strSQL.Append("    AUUSUARIOCREACION, ")
        strSQL.Append("    AUFECHACREACION, ")
        strSQL.Append("    AUUSUARIOMODIFICACION, ")
        strSQL.Append("    AUFECHAMODIFICACION, ")
        strSQL.Append("    ESTASINCRONIZADA) ")
        strSQL.Append("    VALUES ")
        strSQL.Append("    ( @IDPROCESOCOMPRA, ")
        strSQL.Append("    @IDESTABLECIMIENTO, ")
        strSQL.Append("    @IDPROVEEDOR, ")
        strSQL.Append("    @IDDETALLE, ")
        strSQL.Append("    @CANTIDADRECOMENDACION, ")
        strSQL.Append("    @CANTIDADADJUDICADA, ")
        strSQL.Append("    @CANTIDADFIRME, ")
        strSQL.Append("    @AUUSUARIOCREACION, ")
        strSQL.Append("    @AUFECHACREACION, ")
        strSQL.Append("    NULL, ")
        strSQL.Append("    NULL, ")
        strSQL.Append("    @ESTASINCRONIZADA) ")
        strSQL.Append("END ")
        strSQL.Append("ELSE ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    UPDATE SAB_UACI_ADJUDICACION ")
        strSQL.Append("    SET ")
        strSQL.Append("    CANTIDADRECOMENDACION = @CANTIDADRECOMENDACION, ")
        strSQL.Append("    CANTIDADADJUDICADA = @CANTIDADADJUDICADA, ")
        strSQL.Append("    CANTIDADFIRME = @CANTIDADFIRME, ")
        strSQL.Append("    AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("    AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("    ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("    AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("    AND IDDETALLE = @IDDETALLE ")
        strSQL.Append("END ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = aEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = aEntidad.IDDETALLE
        args(4) = New SqlParameter("@CANTIDADRECOMENDACION", SqlDbType.Decimal)
        args(4).Value = aEntidad.CANTIDADRECOMENDACION
        args(5) = New SqlParameter("@CANTIDADADJUDICADA", SqlDbType.Decimal)
        args(5).Value = IIf(IsNothing(aEntidad.CANTIDADADJUDICADA), DBNull.Value, aEntidad.CANTIDADADJUDICADA)
        args(6) = New SqlParameter("@CANTIDADFIRME", SqlDbType.Decimal)
        args(6).Value = IIf(IsNothing(aEntidad.CANTIDADFIRME), DBNull.Value, aEntidad.CANTIDADFIRME)
        args(7) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(7).Value = IIf(IsNothing(aEntidad.AUUSUARIOCREACION), DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args(8) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(8).Value = IIf(IsNothing(aEntidad.AUFECHACREACION), DBNull.Value, aEntidad.AUFECHACREACION)
        args(9) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(9).Value = IIf(IsNothing(aEntidad.AUUSUARIOMODIFICACION), DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(10) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(10).Value = IIf(IsNothing(aEntidad.AUFECHAMODIFICACION), DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(11) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(11).Value = aEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza la cantidad recomendada a una oferta.
    ''' </summary>
    ''' <param name="aEntidad">Entidad ADJUDICACION.</param>
    ''' <returns>Integer</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarCantidadRecomendada(ByVal aEntidad As ADJUDICACION) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ADJUDICACION ")
        strSQL.Append("SET CANTIDADRECOMENDACION = @CANTIDADRECOMENDACION ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@CANTIDADRECOMENDACION", SqlDbType.Decimal)
        args(0).Value = aEntidad.CANTIDADRECOMENDACION
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(IsNothing(aEntidad.AUUSUARIOMODIFICACION), DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(IsNothing(aEntidad.AUFECHAMODIFICACION), DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(4).Value = aEntidad.IDPROCESOCOMPRA
        args(5) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(5).Value = aEntidad.IDESTABLECIMIENTO
        args(6) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(6).Value = aEntidad.IDPROVEEDOR
        args(7) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(7).Value = aEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza la cantidad adjudicada a una oferta.
    ''' </summary>
    ''' <param name="aEntidad">Entidad ADJUDICACION.</param>
    ''' <returns>Integer</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarCantidadAdjudicada(ByVal aEntidad As ADJUDICACION) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ADJUDICACION ")
        strSQL.Append("SET CANTIDADADJUDICADA = @CANTIDADADJUDICADA, ")
        strSQL.Append("CANTIDADFIRME = @CANTIDADADJUDICADA, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@CANTIDADADJUDICADA", SqlDbType.Decimal)
        args(0).Value = IIf(IsNothing(aEntidad.CANTIDADADJUDICADA), DBNull.Value, aEntidad.CANTIDADADJUDICADA)
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(IsNothing(aEntidad.AUUSUARIOMODIFICACION), DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(IsNothing(aEntidad.AUFECHAMODIFICACION), DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(4).Value = aEntidad.IDPROCESOCOMPRA
        args(5) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(5).Value = aEntidad.IDESTABLECIMIENTO
        args(6) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(6).Value = aEntidad.IDPROVEEDOR
        args(7) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(7).Value = aEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza la cantidad adjudicada en firme a una oferta.
    ''' </summary>
    ''' <param name="aEntidad">Entidad ADJUDICACION.</param>
    ''' <returns>Integer</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarCantidadAdjudicadaEnFirme(ByVal aEntidad As ADJUDICACION) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ADJUDICACION ")
        strSQL.Append("SET CANTIDADFIRME = @CANTIDADFIRME, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(11) As SqlParameter
        args(2) = New SqlParameter("@CANTIDADFIRME", SqlDbType.Decimal)
        args(2).Value = IIf(IsNothing(aEntidad.CANTIDADFIRME), DBNull.Value, aEntidad.CANTIDADFIRME)
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = IIf(IsNothing(aEntidad.AUUSUARIOMODIFICACION), DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(IsNothing(aEntidad.AUFECHAMODIFICACION), DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(7) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(7).Value = aEntidad.ESTASINCRONIZADA
        args(8) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(8).Value = aEntidad.IDPROCESOCOMPRA
        args(9) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(9).Value = aEntidad.IDESTABLECIMIENTO
        args(10) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(10).Value = aEntidad.IDPROVEEDOR
        args(11) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(11).Value = aEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Elimina las cantidades recomendadas para un renglon especifico
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <returns>Valor entero con el resultado de la ejecución</returns>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarCantidadRecomendadaPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza el valor de la cantidad adjudicada para un renglón.
    ''' </summary>
    ''' <param name="aEntidad">Entidad ADJUDICACION.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>Valor entero con el resultado de la actualización</returns>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarCantidadAdjudicadaPorRenglon(ByVal aEntidad As ADJUDICACION, ByVal RENGLON As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ADJUDICACION ")
        strSQL.Append("SET CANTIDADADJUDICADA = @CANTIDADADJUDICADA, ")
        strSQL.Append("CANTIDADFIRME = @CANTIDADADJUDICADA, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.RENGLON = @RENGLON ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@CANTIDADADJUDICADA", SqlDbType.Decimal)
        args(0).Value = IIf(IsNothing(aEntidad.CANTIDADADJUDICADA), DBNull.Value, aEntidad.CANTIDADADJUDICADA)
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(IsNothing(aEntidad.AUUSUARIOMODIFICACION), DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(IsNothing(aEntidad.AUFECHAMODIFICACION), DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = aEntidad.IDESTABLECIMIENTO
        args(5) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(5).Value = aEntidad.IDPROCESOCOMPRA
        args(6) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(6).Value = RENGLON

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza el valor de la cantidad adjudicada en firme para un renglón.
    ''' </summary>
    ''' <param name="aEntidad">Entidad ADJUDICACION.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>Integer.</returns>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarCantidadAdjudicadaEnFirmePorRenglon(ByVal aEntidad As ADJUDICACION, ByVal RENGLON As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ADJUDICACION ")
        strSQL.Append("SET CANTIDADFIRME = @CANTIDADFIRME, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.RENGLON = @RENGLON ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@CANTIDADFIRME", SqlDbType.Decimal)
        args(0).Value = IIf(IsNothing(aEntidad.CANTIDADFIRME), DBNull.Value, aEntidad.CANTIDADFIRME)
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(IsNothing(aEntidad.AUUSUARIOMODIFICACION), DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(IsNothing(aEntidad.AUFECHAMODIFICACION), DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = aEntidad.IDESTABLECIMIENTO
        args(5) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(5).Value = aEntidad.IDPROCESOCOMPRA
        args(6) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(6).Value = RENGLON

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene la cantidad adjudicada para un proveedor
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <returns>DataSet.</returns>

    Public Function obtenerCantidadAdjudicadaProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_DETALLEOFERTA.IDPROVEEDOR, SAB_UACI_DETALLEOFERTA.RENGLON, SAB_UACI_ADJUDICACION.CANTIDADFIRME, SAB_UACI_ADJUDICACION.IDDETALLE,SAB_UACI_ADJUDICACION.CANTIDADRECOMENDACION,SAB_UACI_ADJUDICACION.CANTIDADADJUDICADA ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")
        strSQL.Append(" AND (SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") ")
        strSQL.Append(" AND (SAB_UACI_ADJUDICACION.CANTIDADFIRME > 0) ")
        strSQL.Append(" AND (SAB_UACI_DETALLEOFERTA.RENGLON = " & RENGLON & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene las cantidades adjudicadas por proveedor
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <returns>Lista de cantidades adjudicadas por proveedor en formato dataset</returns>

    Public Function obtenerCantidadAdjudicadaProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_DETALLEOFERTA.IDPROVEEDOR, SAB_UACI_DETALLEOFERTA.RENGLON, SAB_UACI_ADJUDICACION.CANTIDADFIRME, SAB_UACI_ADJUDICACION.IDDETALLE ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (SAB_UACI_ADJUDICACION.CANTIDADFIRME > 0) AND (SAB_UACI_DETALLEOFERTA.RENGLON = " & RENGLON & ") AND (SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = " & IDPROVEEDOR & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtener el monto total recomendado por renglon
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <returns>Dataset</returns>

    Public Function ObtenerTotalRecomendadoPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Int32) As Decimal

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(SUM(CANTIDADRECOMENDACION), 0) TOTALRECOMENDADO ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener total adjudicado por renglon
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <returns>Valor Decimal</returns>

    Public Function ObtenerTotalAdjudicadoPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Int32) As Decimal

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(SUM(CANTIDADADJUDICADA), 0) TOTALADJUDICADO ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener el total adjudicado en firme por renglon
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <returns>VAlor de tipo decimal</returns>

    Public Function ObtenerTotalAdjudicadoEnFirmePorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Int32) As Decimal

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(SUM(CANTIDADFIRME), 0) TOTALADJUDICADOENFIRME ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Listado de renglones Adjudicados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="TIPOADJUDICACION">Identificador del tipo de adjudicacion</param>
    ''' <param name="IDINSPECTOR">Identificador del inspector</param>
    ''' <returns>dataset</returns>

    Public Function ObtenerRenglonesAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, Optional ByVal TIPOADJUDICACION As Integer = 0, Optional ByVal IDINSPECTOR As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        'strSQL.Append("SELECT ")
        'strSQL.Append("DO.RENGLON, ")
        'strSQL.Append("CP.CORRPRODUCTO CODIGO, ")
        'strSQL.Append("CP.DESCLARGO NOMBRE, ")
        'strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
        'strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
        'strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
        'strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
        'strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
        'strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
        'strSQL.Append("CP.DESCRIPCION UNIDAD_MEDIDA, ")
        'If TIPOADJUDICACION <> 0 Then
        '    strSQL.Append("A.CANTIDADADJUDICADA CANTIDADFIRME, ")
        'Else
        'strSQL.Append("A.CANTIDADFIRME, ")
        'End If

        'strSQL.Append("DO.PRECIOUNITARIO, ")
        'If TIPOADJUDICACION <> 0 Then
        '    strSQL.Append("A.CANTIDADADJUDICADA * DO.PRECIOUNITARIO VALORTOTAL, ")
        'Else
        'strSQL.Append("A.CANTIDADFIRME * DO.PRECIOUNITARIO VALORTOTAL, ")
        'End If

        'strSQL.Append("DPC.IDPRODUCTO, ")
        'strSQL.Append("DO.DESCRIPCIONPROVEEDOR AS DESCRIPCIONPROVEEDOR2, ")
        'strSQL.Append("DO.CASAREPRESENTADA ")
        'strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        'strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        'strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        'strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        'strSQL.Append("ON DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        'strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        'strSQL.Append("AND DPC.RENGLON = DO.RENGLON ")
        'strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
        'strSQL.Append("ON A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        'strSQL.Append("AND A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        'strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        'strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE ")
        'If IDINSPECTOR <> 0 Then
        '    strSQL.Append(" INNER JOIN SAB_LAB_INFORMEMUESTRAS IM ")
        '    strSQL.Append(" ON IM.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
        '    strSQL.Append(" AND IM.IDESTABLECIMIENTOCONTRATO = A.IDESTABLECIMIENTO ")
        '    strSQL.Append(" AND IM.IDPROVEEDOR = A.IDPROVEEDOR ")
        '    strSQL.Append(" AND IM.RENGLON = DO.RENGLON ")
        'End If
        strSQL.Append(" SELECT PC.RENGLON, ")
        strSQL.Append(" CP.CORRPRODUCTO CODIGO, ")
        strSQL.Append(" CP.DESCLARGO NOMBRE, ")
        'strSQL.Append(" PC.DESCRIPCIONPROVEEDOR,")

        strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
        strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
        strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
        strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
        strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
        strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")


        strSQL.Append(" CP.DESCRIPCION UNIDAD_MEDIDA, ")
        strSQL.Append(" SUM(AEC.CANTIDAD) AS CANTIDADFIRME, ")
        strSQL.Append(" PC.PRECIOUNITARIO, ")
        strSQL.Append(" convert(decimal(12,4),SUM(convert(decimal(12,4),AEC.CANTIDAD * PC.PRECIOUNITARIO))) VALORTOTAL, ")
        strSQL.Append(" PC.IDPRODUCTO, ")
        strSQL.Append(" DO.DESCRIPCIONPROVEEDOR AS DESCRIPCIONPROVEEDOR2, ")
        strSQL.Append(" DO.CASAREPRESENTADA AS CASAREPRESENTADA ")

        strSQL.Append(" FROM ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append(" INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ON")
        strSQL.Append(" PC.IDESTABLECIMIENTO=CPC.IDESTABLECIMIENTO AND")
        strSQL.Append(" PC.IDPROVEEDOR=CPC.IDPROVEEDOR AND")
        strSQL.Append(" PC.IDCONTRATO=CPC.IDCONTRATO ")
        strSQL.Append(" ")
        strSQL.Append(" INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ON")
        strSQL.Append(" AEC.IDESTABLECIMIENTO=PC.IDESTABLECIMIENTO AND")
        strSQL.Append(" AEC.IDPROVEEDOR=PC.IDPROVEEDOR AND")
        strSQL.Append(" AEC.IDCONTRATO=PC.IDCONTRATO AND")
        strSQL.Append(" AEC.RENGLON=PC.RENGLON ")

        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ON ")
        strSQL.Append("DO.IDESTABLECIMIENTO=PC.IDESTABLECIMIENTO AND ")
        strSQL.Append("DO.IDPROCESOCOMPRA=CPC.IDPROCESOCOMPRA AND ")
        strSQL.Append("DO.IDPROVEEDOR=PC.IDPROVEEDOR AND ")
        strSQL.Append("DO.RENGLON=PC.RENGLON ")

        'se adiciona para evitar que muestre porducto no adjudicado  Mayra Martínez 18/09/2010

        strSQL.Append("inner join dbo.SAB_UACI_ADJUDICACION a on ")
        strSQL.Append("do.idestablecimiento = a.idestablecimiento and ")
        strSQL.Append("do.idprocesocompra = a.idprocesocompra and ")
        strSQL.Append("do.idproveedor = a.idproveedor and ")
        strSQL.Append("do.iddetalle = a.iddetalle ")



        strSQL.Append(" INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS CP ON ")
        strSQL.Append(" PC.IDPRODUCTO = CP.IDPRODUCTO ")

        strSQL.Append("WHERE AEC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND AEC.IDPROVEEDOR = @IDPROVEEDOR ")
        'strSQL.Append("and aec.idalmacenentrega not in (114,116,499) and aec.idfuentefinanciamiento not in (76,30)")
        'strSQL.Append(" AND AEC.IDFUENTEFINANCIAMIENTO=@ ")

        ' garantizar que no se adicione cantidad adjudicada = 0  Mayra Martínez 18092012
        strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")

        strSQL.Append(" GROUP BY ")
        strSQL.Append(" PC.RENGLON, CP.CORRPRODUCTO , CP.DESCLARGO  ")
        strSQL.Append(" ")
        strSQL.Append(" ,CP.DESCRIPCION , ")
        strSQL.Append(" PC.PRECIOUNITARIO , ")
        strSQL.Append(" PC.IDPRODUCTO, ")
        strSQL.Append(" DO.DESCRIPCIONPROVEEDOR,DO.MARCA,DO.ORIGEN,DO.VENCIMIENTO,DO.CASAREPRESENTADA,DO.NUMEROCSSP   ")
        ' strSQL.Append(" AEC.IDFUENTEFINANCIAMIENTO,")
        'strSQL.Append(" AEC.IDALMACENENTREGA ")
        strSQL.Append(" ORDER BY PC.RENGLON ")
        'If TIPOADJUDICACION <> 0 Then
        '    strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
        'Else
        'strSQL.Append("AND A.CANTIDADFIRME > 0 ")
        'End If

        'If IDINSPECTOR <> 0 Then
        '    strSQL.Append("AND (IM.IDINSPECTOR = @IDINSPECTOR OR @IDINSPECTOR = 0) ")
        'End If



        'strSQL.Append("ORDER BY DO.RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
        args(3).Value = IDINSPECTOR

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener el oficio de adjudicacion
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <returns>Dataset</returns>

    Public Function ObtenerRenglonesAdjudicadosOfiAdj(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT  ")
        strSQL.Append("DO.RENGLON,  ")
        strSQL.Append("CP.CORRPRODUCTO CODIGO,  ")
        strSQL.Append("CP.DESCLARGO NOMBRE,  ")
        strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') +  ")
        strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') +  ")
        strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') +  ")
        strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') +  ")
        strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') +  ")
        strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR,  ")
        strSQL.Append("CP.DESCRIPCION UNIDAD_MEDIDA,  ")
        strSQL.Append("A.CANTIDADADJUDICADA CANTIDADFIRME,  ")
        strSQL.Append("DO.PRECIOUNITARIO,  ")
        strSQL.Append("A.CANTIDADADJUDICADA * DO.PRECIOUNITARIO VALORTOTAL,  ")
        strSQL.Append("DPC.IDPRODUCTO,  ")
        strSQL.Append("DO.DESCRIPCIONPROVEEDOR AS DESCRIPCIONPROVEEDOR2,  ")
        strSQL.Append("DO.CASAREPRESENTADA, ")
        strSQL.Append("P.NOMBRE AS NOMBREP,P.DIRECCION,P.TELEFONO, ")
        strSQL.Append("PC.TITULOLICITACION, PC.CODIGOLICITACION, ")
        strSQL.Append("PC.DESCRIPCIONLICITACION ")

        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC  ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP  ")
        strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO  ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO  ")
        strSQL.Append("ON DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO  ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA  ")
        strSQL.Append("AND DPC.RENGLON = DO.RENGLON  ")
        strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A  ")
        strSQL.Append("ON A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA  ")
        strSQL.Append("AND A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO  ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR  ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE  ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON P.IDPROVEEDOR=DO.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON PC.IDPROCESOCOMPRA=DPC.IDPROCESOCOMPRA AND ")
        strSQL.Append("PC.IDESTABLECIMIENTO=DPC.IDESTABLECIMIENTO    ")
        strSQL.Append("WHERE A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA  ")
        strSQL.Append("AND A.IDPROVEEDOR = @IDPROVEEDOR  ")
        strSQL.Append("AND A.CANTIDADADJUDICADA > 0    ")
        strSQL.Append("ORDER BY DO.RENGLON  ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener las entregas por proveedor
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <returns>Lista</returns>

    Public Function obtenerEntregasProveedor2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As ArrayList

        Dim strSQL As New Text.StringBuilder
        Dim arr As New ArrayList

        strSQL.Append(" SELECT ")
        strSQL.Append("    count(renglon) as entregas, DO.RENGLON ")
        strSQL.Append("  FROM ")
        strSQL.Append("    SAB_UACI_ENTREGAADJUDICACION EA ")
        strSQL.Append(" 	 INNER JOIN SAB_UACI_DETALLEOFERTA DO ON ")
        strSQL.Append(" 	   EA.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA AND ")
        strSQL.Append(" 	   EA.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO AND ")
        strSQL.Append(" 	   EA.IDPROVEEDOR = DO.IDPROVEEDOR AND ")
        strSQL.Append(" 	   EA.IDDETALLE = DO.IDDETALLE ")
        strSQL.Append(" WHERE ")
        strSQL.Append("    DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("    DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA  AND ")
        strSQL.Append("    DO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" GROUP BY ")
        strSQL.Append("   EA.PORCENTAJE, DO.RENGLON ")
        strSQL.Append(" ORDER BY count(renglon), DO.RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Do While dr.Read
            Dim s(1) As String
            s(0) = dr.Item(0) 'Entrega 
            s(1) = dr.Item(1) 'Renglon
            arr.Add(s)
        Loop

        dr.Close()

        Return arr

    End Function
    ''' <summary>
    ''' Obtener los renglones adjudicados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Dataset</returns>

    Public Function obtenerRenglonesAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("DPC.RENGLON, ")
        strSQL.Append("CP.CODIGO, ")
        strSQL.Append("CP.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("INNER JOIN SAB_CAT_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.RENGLON = DO.RENGLON ")
        strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")

        'strSQL.Append("        INNER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC ON ")
        'strSQL.Append("        SPC.IDESTABLECIMIENTO=DPC.IDESTABLECIMIENTO AND ")
        'strSQL.Append("        SPC.IDPROCESOCOMPRA=DPC.IDPROCESOCOMPRA ")
        'strSQL.Append("        INNER JOIN SAB_EST_ALMACENESENTREGASOLICITUD AES ON ")
        'strSQL.Append("        AES.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTO AND ")
        'strSQL.Append("        AES.IDSOLICITUD = SPC.IDSOLICITUD AND ")
        'strSQL.Append("        AES.RENGLON = DPC.RENGLON AND ")
        'strSQL.Append("        AES.IDPRODUCTO = DPC.IDPRODUCTO ")

        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND A.CANTIDADFIRME > 0 ")
        strSQL.Append("order by dpc.renglon ")


        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener los renglones adjudicados por proveedor
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <returns>Dataset</returns>

    Public Function obtenerRenglonAdjudicadoProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("DPC.RENGLON, ")
        strSQL.Append("CP.CODIGO, ")
        strSQL.Append("CP.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("INNER JOIN SAB_CAT_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.RENGLON = DO.RENGLON ")
        strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
        strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND A.CANTIDADFIRME > 0 ")
        strSQL.Append("AND A.IDPROVEEDOR = " & IDPROVEEDOR)
        strSQL.Append("AND DPC.RENGLON = " & RENGLON)

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener las cantidades adjudicadas por proveedor
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Valor entero</returns>

    Public Function ObtenerCantidadProveedores(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("COUNT( distinct A.IDPROVEEDOR) ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON A.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE ")
        strSQL.Append("A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND A.CANTIDADFIRME > 0 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener los renglones recomendados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <returns>Dataset</returns>

    Public Function obtenerRenglonRecomendado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer) As DataSet

        'se adiciona do.correlativorenglon para mostrar alternativa en reporte 27052009 

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT CONVERT(VARCHAR(2), RO.ORDENLLEGADA) + '-' + CONVERT(VARCHAR(2), DO.CORRELATIVORENGLON)  ORDENLLEGADA, A.CANTIDADRECOMENDACION ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION A INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append(" ON A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append(" AND A.IDDETALLE = DO.IDDETALLE ")
        strSQL.Append(" INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append(" ON A.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A.IDPROVEEDOR = RO.IDPROVEEDOR")
        strSQL.Append(" WHERE A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND DO.RENGLON = @RENGLON")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener la resolución modificada
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Valor booleano</returns>

    Public Function ResolucionModificada(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND CANTIDADADJUDICADA <> CANTIDADFIRME ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) > 0, True, False)

    End Function
    ''' <summary>
    ''' Informacion de la notificacion de adjudicacion
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>dataset</returns>

    Public Function RptNotificacionAdjudicacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("A.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        strSQL.Append("P.DIRECCION, ")
        strSQL.Append("isnull(TC.DESCRIPCION, '') + ' ' + isnull(PC.CODIGOLICITACION, '') TIPOCODIGOLICITACION ")
        strSQL.Append("isnull(PC.DESCRIPCIONLICITACION, '') DESCRIPCIONLICITACION, ")
        strSQL.Append("isnull(PC.NUMERORESOLUCION, '') NUMERORESOLUCION, ")
        strSQL.Append("RO.ORDENLLEGADA ")
        'strSQL.Append("NI.NUMEROOFICIO, ")
        'strSQL.Append("isnull(E.NOMBRE, '') + ' ' + isnull(E.APELLIDO, '') EMPLEADOEMITE, ")
        'strSQL.Append("C.DESCRIPCION CARGO ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("ON A.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = RO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON A.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        'strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS E ")
        'strSQL.Append("ON NI.IDEMPLEADOEMITE = E.IDEMPLEADO ")
        'strSQL.Append("INNER JOIN SAB_CAT_CARGOS C ")
        'strSQL.Append("ON E.IDCARGO = C.IDCARGO ")
        strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("ORDER BY ORDENLLEGADA ")

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
    ''' Obtiene informacion de las adjudicaciones
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>SAB_UACI_OFERTAPROCESOCOMPRA</item>
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function obtenerDatasetRenglonProductoCantidadRecomendada(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64, ByVal renglon As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("o.renglon, ")
        strSQL.Append("vp.DESCPRODUCTO producto, ")
        strSQL.Append("p.nombre proveedor ,p.IDPROVEEDOR,o.iddetalle, ")
        strSQL.Append("a.cantidadrecomendacion ")
        strSQL.Append("from SAB_UACI_ADJUDICACION a ")
        strSQL.Append("inner join sab_uaci_detalleoferta o on o.idestablecimiento = a.idestablecimiento ")
        strSQL.Append(" and o.idprocesocompra = a.idprocesocompra and o.idproveedor = a.idproveedor ")
        strSQL.Append(" and o.iddetalle = a.iddetalle ")
        strSQL.Append(" inner join SAB_UACI_OFERTAPROCESOCOMPRA opc ")
        strSQL.Append(" on o.IDPROVEEDOR=opc.IDPROVEEDOR ")
        strSQL.Append(" and o.IDPROCESOCOMPRA=opc.IDPROCESOCOMPRA ")
        strSQL.Append(" and o.IDESTABLECIMIENTO=opc.IDESTABLECIMIENTO ")
        strSQL.Append(" inner join SAB_UACI_DETALLEPROCESOCOMPRA dpc ")
        strSQL.Append(" on O.IDPROCESOCOMPRA=dpc.IDPROCESOCOMPRA ")
        strSQL.Append(" and O.IDESTABLECIMIENTO=dpc.IDESTABLECIMIENTO AND o.RENGLON=dpc.RENGLON ")
        strSQL.Append(" inner join vv_CATALOGOPRODUCTOS vp  ")
        strSQL.Append(" on dpc.IDPRODUCTO=vp.IDPRODUCTO ")
        strSQL.Append(" inner join sab_cat_proveedores p on p.idproveedor = a.idproveedor ")
        strSQL.Append("WHERE ")
        strSQL.Append(" a.idprocesocompra = @IDPROCESOCOMPRA and a.IDESTABLECIMIENTO=@idestablecimiento  ")
        strSQL.Append(" and (o.renglon=@renglon OR @renglon=-1)  ")
        '  strSQL.Append(" group by o.renglon,vp.DESCPRODUCTO ")
        strSQL.Append(" order by o.RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@renglon", SqlDbType.BigInt)
        args(2).Value = renglon

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene informacion de las adjudicaciones
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ALMACENESENTREGAADJUDICACION</item>
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>sab_cat_almacenes</item>
    ''' <item>sab_cat_proveedores</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function obtenerDatasetRenglonProveedorAlmacenCantidad(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64, ByVal renglon As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append("select o.renglon,a.cantidad,alm.nombre, p.nombre proveedor,p.idproveedor, o.iddetalle,  ")
        strSQL.Append("alm.idalmacen, a.identrega ")
        strSQL.Append("from dbo.SAB_UACI_ALMACENESENTREGAADJUDICACION a  ")
        strSQL.Append("inner join sab_uaci_detalleoferta o  ")
        strSQL.Append("on o.idestablecimiento = a.idestablecimiento ")
        strSQL.Append("and o.idprocesocompra = a.idprocesocompra  ")
        strSQL.Append("and o.idproveedor = a.idproveedor  ")
        strSQL.Append("and o.iddetalle = a.iddetalle ")
        strSQL.Append("inner join sab_cat_almacenes alm  ")
        strSQL.Append("on a.idalmacen = alm.idalmacen ")
        strSQL.Append("inner join sab_cat_proveedores p  ")
        strSQL.Append("on p.idproveedor = a.idproveedor ")
        'strSQL.Append("inner join SAB_UACI_DETALLEENTREGASPROCESOCOMPRA depc ")
        'strSQL.Append("on a.IDENTREGA=depc.IDENTREGA ")
        'strSQL.Append("and a.IDESTABLECIMIENTO=depc.IDESTABLECIMIENTO ")
        'strSQL.Append("and a.IDPROCESOCOMPRA=depc.IDPROCESOCOMPRA ")
        strSQL.Append("where a.idprocesocompra = @IDPROCESOCOMPRA  and (o.renglon = @renglon OR @renglon=-1 )  ")
        strSQL.Append("and o.IDESTABLECIMIENTO=@idestablecimiento ")
        strSQL.Append("order by alm.idalmacen,a.identrega ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@renglon", SqlDbType.BigInt)
        args(2).Value = renglon

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ActualizarALMACENESENTREGAADJUDICACION(ByVal idEstablecimiento As Integer, ByVal idProcesoCompra As Integer, ByVal idProveedor As Integer, ByVal idAlmacen As Integer, ByVal renglon As Integer, ByVal idEntrega As Integer, ByVal nuevaCantidad As Double, ByVal Usuario As String, ByVal idDetalle As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("update SAB_UACI_ALMACENESENTREGAADJUDICACION set CANTIDAD=@nuevaCantidad ")
        strSQL.Append(",AUUSUARIOMODIFICACION=@usuario,AUFECHAMODIFICACION=getdate() ")
        strSQL.Append("from SAB_UACI_ALMACENESENTREGAADJUDICACION aea ")
        strSQL.Append("inner join sab_uaci_detalleoferta do  ")
        strSQL.Append("on do.idestablecimiento = aea.idestablecimiento ")
        strSQL.Append("and do.idprocesocompra = aea.idprocesocompra  ")
        strSQL.Append("and do.idproveedor = aea.idproveedor ")
        strSQL.Append("and do.iddetalle = aea.iddetalle ")
        strSQL.Append("where ")
        strSQL.Append("aea.IDESTABLECIMIENTO=@idestablecimiento  ")
        strSQL.Append("and aea.IDPROCESOCOMPRA=@idProcesoCompra ")
        strSQL.Append("and aea.IDPROVEEDOR=@idProveedor ")
        strSQL.Append("and IDALMACEN=@idAlmacen ")
        strSQL.Append("and RENGLON=@renglon ")
        strSQL.Append("and IDENTREGA=@idEntrega ")
        strSQL.Append("and do.iddetalle=@idDetalle ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@idestablecimiento", SqlDbType.BigInt)
        args(0).Value = idEstablecimiento
        args(1) = New SqlParameter("@idProcesoCompra", SqlDbType.BigInt)
        args(1).Value = idProcesoCompra
        args(2) = New SqlParameter("@idProveedor", SqlDbType.Int)
        args(2).Value = idProveedor
        args(3) = New SqlParameter("@idAlmacen", SqlDbType.Int)
        args(3).Value = idAlmacen
        args(4) = New SqlParameter("@renglon", SqlDbType.Int)
        args(4).Value = renglon
        args(5) = New SqlParameter("@idEntrega", SqlDbType.Int)
        args(5).Value = idEntrega
        args(6) = New SqlParameter("@nuevaCantidad", SqlDbType.Float)
        args(6).Value = nuevaCantidad
        args(7) = New SqlParameter("@usuario", SqlDbType.VarChar)
        args(7).Value = Usuario
        args(8) = New SqlParameter("@idDetalle", SqlDbType.BigInt)
        args(8).Value = idDetalle

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
    End Function


    ''' <summary>
    ''' Listado de renglones Adjudicados para Control de calidad Sin ISSS ni FOSALUD
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="TIPOADJUDICACION">Identificador del tipo de adjudicacion</param>
    ''' <param name="IDINSPECTOR">Identificador del inspector</param>
    '''<returns>dataset</returns>
    ''' Mayra Martínez Cárcamo 24062011

    Public Function ObtenerRenglonesAdjudicadosControlCalidad(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, Optional ByVal TIPOADJUDICACION As Integer = 0, Optional ByVal IDINSPECTOR As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT PC.RENGLON, ")
        strSQL.Append(" CP.CORRPRODUCTO CODIGO, ")
        strSQL.Append(" CP.DESCLARGO NOMBRE, ")

        strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
        strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
        strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
        strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
        strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
        strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")


        strSQL.Append(" CP.DESCRIPCION UNIDAD_MEDIDA, ")
        strSQL.Append(" SUM(AEC.CANTIDAD) AS CANTIDADFIRME, ")
        strSQL.Append(" PC.PRECIOUNITARIO, ")
        strSQL.Append(" SUM(AEC.CANTIDAD * PC.PRECIOUNITARIO) VALORTOTAL, ")
        strSQL.Append(" PC.IDPRODUCTO, ")
        strSQL.Append(" DO.DESCRIPCIONPROVEEDOR AS DESCRIPCIONPROVEEDOR2, ")
        strSQL.Append(" DO.CASAREPRESENTADA AS CASAREPRESENTADA ")

        strSQL.Append(" FROM ")
        strSQL.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append(" INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ON")
        strSQL.Append(" PC.IDESTABLECIMIENTO=CPC.IDESTABLECIMIENTO AND")
        strSQL.Append(" PC.IDPROVEEDOR=CPC.IDPROVEEDOR AND")
        strSQL.Append(" PC.IDCONTRATO=CPC.IDCONTRATO ")
        strSQL.Append(" ")
        strSQL.Append(" INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ON")
        strSQL.Append(" AEC.IDESTABLECIMIENTO=PC.IDESTABLECIMIENTO AND")
        strSQL.Append(" AEC.IDPROVEEDOR=PC.IDPROVEEDOR AND")
        strSQL.Append(" AEC.IDCONTRATO=PC.IDCONTRATO AND")
        strSQL.Append(" AEC.RENGLON=PC.RENGLON ")

        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ON ")
        strSQL.Append("DO.IDESTABLECIMIENTO=PC.IDESTABLECIMIENTO AND ")
        strSQL.Append("DO.IDPROCESOCOMPRA=CPC.IDPROCESOCOMPRA AND ")
        strSQL.Append("DO.IDPROVEEDOR=PC.IDPROVEEDOR AND ")
        strSQL.Append("DO.RENGLON=PC.RENGLON ")

        'se adiciona para evitar que muestre porducto no adjudicado  Mayra Martínez 18/09/2010

        strSQL.Append("inner join dbo.SAB_UACI_ADJUDICACION a on ")
        strSQL.Append("do.idestablecimiento = a.idestablecimiento and ")
        strSQL.Append("do.idprocesocompra = a.idprocesocompra and ")
        strSQL.Append("do.idproveedor = a.idproveedor and ")
        strSQL.Append("do.iddetalle = a.iddetalle ")



        strSQL.Append(" INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS CP ON ")
        strSQL.Append(" PC.IDPRODUCTO = CP.IDPRODUCTO ")

        strSQL.Append("WHERE AEC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND AEC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
        strSQL.Append("and aec.idalmacenentrega not in (114,116,499) and aec.idfuentefinanciamiento not in (76,30)")

        strSQL.Append(" GROUP BY ")
        strSQL.Append(" PC.RENGLON, CP.CORRPRODUCTO , CP.DESCLARGO  ")
        strSQL.Append(" ")
        strSQL.Append(" ,CP.DESCRIPCION , ")
        strSQL.Append(" PC.PRECIOUNITARIO , ")
        strSQL.Append(" PC.IDPRODUCTO, ")
        strSQL.Append(" DO.DESCRIPCIONPROVEEDOR,DO.MARCA,DO.ORIGEN,DO.VENCIMIENTO,DO.CASAREPRESENTADA,DO.NUMEROCSSP   ")
        ' strSQL.Append(" AEC.IDFUENTEFINANCIAMIENTO,")
        'strSQL.Append(" AEC.IDALMACENENTREGA ")
        strSQL.Append(" ORDER BY PC.RENGLON ")
        'If TIPOADJUDICACION <> 0 Then
        '    strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
        'Else
        'strSQL.Append("AND A.CANTIDADFIRME > 0 ")
        'End If

        'If IDINSPECTOR <> 0 Then
        '    strSQL.Append("AND (IM.IDINSPECTOR = @IDINSPECTOR OR @IDINSPECTOR = 0) ")
        'End If



        'strSQL.Append("ORDER BY DO.RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
        args(3).Value = IDINSPECTOR

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
