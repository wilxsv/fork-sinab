Partial Public Class dbRECURSOSREVISION

#Region " Metodos Agregados "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function obtenerDatasetProveedores(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("OPC.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

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
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function obtenerDatasetRecursos(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT RR.IDRECURSO AS idrecurso, RR.IDPROVEEDOR AS idproveedor, PRO.NOMBRE AS proveedor, CONVERT(varchar(10), RR.FECHAPRESENTACION, ")
        strSQL.Append(" 103) AS fecha, RR.DESCRIPCION, CASE WHEN ISNULL(RR.ADMITIDO, 0) ")
        strSQL.Append(" = 0 THEN 'NO' ELSE 'SI' END AS admitido, CONVERT(varchar(25), RR.JUSTIFICACION) AS justificacion ")
        strSQL.Append(" FROM SAB_UACI_RECURSOSREVISION AS RR INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS PRO ON RR.IDPROVEEDOR = PRO.IDPROVEEDOR ")
        strSQL.Append(" WHERE (RR.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (RR.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

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
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function RptobtenerDatasetRecursos(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA, SAB_CAT_PROVEEDORES.NOMBRE, SAB_UACI_RECURSOSREVISION.FECHAPRESENTACION, ")
        strSQL.Append(" SAB_UACI_RECURSOSREVISION.DESCRIPCION, SAB_UACI_RECURSOSREVISION.IDESTABLECIMIENTO, SAB_UACI_RECURSOSREVISION.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS.NOMBRE AS Establecimiento, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, (SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION + ' ' + SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION) as TITULOLICITACION, ")
        strSQL.Append(" CASE WHEN ISNULL(SAB_UACI_RECURSOSREVISION.ADMITIDO, 0) = 0 THEN 'NO' ELSE 'SI' END AS admitido, SAB_UACI_RECURSOSREVISION.justificacion ")
        strSQL.Append(" FROM SAB_UACI_RECURSOSREVISION INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_RECURSOSREVISION.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS ON SAB_UACI_RECURSOSREVISION.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_RECURSOSREVISION.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_RECURSOSREVISION.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_CAT_PROVEEDORES.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS ON SAB_UACI_RECURSOSREVISION.IDESTABLECIMIENTO = SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS ON SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_RECURSOSREVISION.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA ")
        strSQL.Append(" WHERE (SAB_UACI_RECURSOSREVISION.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_RECURSOSREVISION.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

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
    ''' Determina si existen recursos de revisión admitidos para un proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_RECURSOSREVISION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerRecursosDeRevision(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("count(IDRECURSO) ")
        strSQL.Append("FROM SAB_UACI_RECURSOSREVISION RR ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON (RR.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND RR.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA) ")
        strSQL.Append("WHERE RR.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND RR.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND RR.ADMITIDO = 1 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Determina si se han presentado recursos de revisión para un proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_RECURSOSREVISION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ExistenRecursos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("count(IDRECURSO) ")
        strSQL.Append("FROM SAB_UACI_RECURSOSREVISION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerRenglonesAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT DO.RENGLON ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION AS AD INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA AS DO ON AD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA AND ")
        strSQL.Append(" AD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO AND AD.IDPROVEEDOR = DO.IDPROVEEDOR AND AD.IDDETALLE = DO.IDDETALLE ")
        strSQL.Append(" WHERE (DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append(" ORDER BY DO.RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerProveedoresOfertaRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DO.IDESTABLECIMIENTO, DO.IDPROCESOCOMPRA, DO.RENGLON, P.NOMBRE, P.IDPROVEEDOR ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES AS P INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA AS DO ON P.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append(" WHERE (DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (DO.RENGLON = @RENGLON) ")
        strSQL.Append(" GROUP BY DO.IDESTABLECIMIENTO, DO.IDPROCESOCOMPRA, DO.RENGLON, P.NOMBRE, P.IDPROVEEDOR ")
        strSQL.Append(" ORDER BY P.NOMBRE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(2).Value = RENGLON

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerProveedoresadjudicadosRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DO.IDESTABLECIMIENTO, DO.IDPROCESOCOMPRA, DO.RENGLON, P.NOMBRE, P.IDPROVEEDOR, AD.CANTIDADFIRME ")
        strSQL.Append("FROM SAB_UACI_DETALLEOFERTA AS DO INNER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES AS P ON DO.IDPROVEEDOR = P.IDPROVEEDOR INNER JOIN ")
        strSQL.Append("SAB_UACI_ADJUDICACION AS AD ON DO.IDPROCESOCOMPRA = AD.IDPROCESOCOMPRA AND ")
        strSQL.Append("DO.IDESTABLECIMIENTO = AD.IDESTABLECIMIENTO AND DO.IDPROVEEDOR = AD.IDPROVEEDOR AND DO.IDDETALLE = AD.IDDETALLE ")
        strSQL.Append("WHERE DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.RENGLON = @RENGLON ")
        strSQL.Append("GROUP BY DO.IDESTABLECIMIENTO, DO.IDPROCESOCOMPRA, DO.RENGLON, P.NOMBRE, P.IDPROVEEDOR, AD.CANTIDADFIRME ")
        strSQL.Append("ORDER BY P.NOMBRE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(2).Value = RENGLON

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerRecursosDeRevisionRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA, SAB_CAT_PROVEEDORES.NOMBRE, SAB_UACI_RECURSOSREVISION.FECHAPRESENTACION, ")
        strSQL.Append(" SAB_UACI_RECURSOSREVISION.DESCRIPCION, SAB_UACI_RECURSOSREVISION.IDESTABLECIMIENTO, SAB_UACI_RECURSOSREVISION.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS.NOMBRE AS Establecimiento, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, (SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION + ' ' + SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION) as TITULOLICITACION, ")
        strSQL.Append(" CASE WHEN ISNULL(SAB_UACI_RECURSOSREVISION.ADMITIDO, 0) = 0 THEN 'NO' ELSE 'SI' END AS admitido, SAB_UACI_RECURSOSREVISION.justificacion ")
        strSQL.Append(" FROM SAB_UACI_RECURSOSREVISION INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_RECURSOSREVISION.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_RECEPCIONOFERTAS ON SAB_UACI_RECURSOSREVISION.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_RECURSOSREVISION.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_RECURSOSREVISION.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_CAT_PROVEEDORES.IDPROVEEDOR = SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS ON SAB_UACI_RECURSOSREVISION.IDESTABLECIMIENTO = SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS ON SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_RECURSOSREVISION.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA ")
        strSQL.Append(" WHERE (SAB_UACI_RECURSOSREVISION.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_RECURSOSREVISION.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("AND RR.RENGLON = @RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
