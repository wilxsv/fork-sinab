Partial Public Class dbENTREGABASES

#Region " Métodos Agregados "

    ' COMENTARIO
    ' Este método es utilizado para extraer los datos de la tabla ENTREGABASES con el Proveedor respectivo
    ' PROVEEDOR    
    Public Function ObtenerDataSetPorIDwPROVEEDOR(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_ENTREGABASES.IDPROCESOCOMPRA, SAB_UACI_ENTREGABASES.IDPROVEEDOR, SAB_CAT_PROVEEDORES.NOMBRE, SAB_UACI_ENTREGABASES.NUMERORECIBO, ")
        strSQL.Append(" SAB_UACI_ENTREGABASES.PERSONARECIBE, SAB_UACI_ENTREGABASES.FECHAHORAENTREGA, SAB_UACI_ENTREGABASES.ORDEN ")
        strSQL.Append(" FROM SAB_UACI_ENTREGABASES INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_ENTREGABASES.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_ENTREGABASES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO)")
        strSQL.Append(" AND     (SAB_UACI_ENTREGABASES.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append(" ORDER BY SAB_UACI_ENTREGABASES.ORDEN ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ' COMENTARIO
    ' Este método es utilizado para extraer los datos de la tabla ENTREGABASES con el Proveedor respectivo
    ' PROVEEDOR
    Public Function ObtenerDataSetPROVEEDOR(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_ENTREGABASES.IDPROCESOCOMPRA, SAB_UACI_ENTREGABASES.IDPROVEEDOR, SAB_CAT_PROVEEDORES.NOMBRE, SAB_UACI_ENTREGABASES.NUMERORECIBO, ")
        strSQL.Append(" SAB_UACI_ENTREGABASES.PERSONARECIBE, SAB_UACI_ENTREGABASES.FECHAHORAENTREGA, SAB_UACI_ENTREGABASES.ORDEN,SAB_CAT_PROVEEDORES.NIT ")
        strSQL.Append(" FROM SAB_UACI_ENTREGABASES INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_ENTREGABASES.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_ENTREGABASES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO)")
        strSQL.Append(" AND     (SAB_UACI_ENTREGABASES.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append(" ORDER BY SAB_UACI_ENTREGABASES.ORDEN ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function GeneraSolDetalleDiscoProveedor(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AS numero, SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON AS linea, ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS.CORRPRODUCTO AS codigo, vv_CATALOGOPRODUCTOS.DESCPRODUCTO AS nombre, ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.NUMEROENTREGAS AS entrega1, SAB_UACI_DETALLEPROCESOCOMPRA.cantidad as cantidad1, vv_CATALOGOPRODUCTOS.DESCLARGO AS descripcio, ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS.DESCRIPCION AS unidmedida, SAB_CAT_ESTABLECIMIENTOS.CODIGOESTABLECIMIENTO ")
        strSQL.Append(" FROM SAB_UACI_DETALLEPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS ON SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = vv_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS ON SAB_UACI_DETALLEPROCESOCOMPRA.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS ON SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append(" ORDER BY SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function GeneraSolDiscoProveedor(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT ")
        strSQL.Append("  SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA AS numero, SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION AS cod_licita, ")
        strSQL.Append("  SAB_UACI_PROCESOCOMPRAS.FECHAPUBLICACION AS fecha, SAB_CAT_SUMINISTROS.DESCRIPCION AS descripcio, ")
        strSQL.Append("  SAB_UACI_PROCESOCOMPRAS.IDESTADOPROCESOCOMPRA AS estado_sol, SAB_CAT_ESTABLECIMIENTOS.CODIGOESTABLECIMIENTO AS establec ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append("  SAB_EST_SOLICITUDESPROCESOCOMPRAS ON ")
        strSQL.Append("  SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("  SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("  SAB_EST_SOLICITUDES ON SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD = SAB_EST_SOLICITUDES.IDSOLICITUD AND ")
        strSQL.Append("  SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTOSOLICITUD = SAB_EST_SOLICITUDES.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("  SAB_CAT_SUMINISTROS ON SAB_EST_SOLICITUDES.IDCLASESUMINISTRO = SAB_CAT_SUMINISTROS.IDSUMINISTRO INNER JOIN ")
        strSQL.Append("  SAB_CAT_ESTABLECIMIENTOS ON SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function GeneraProvDiscoProveedor(ByVal IDPROVEEDOR As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT CODIGOPROVEEDOR, NOMBRE ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append(" WHERE (IDPROVEEDOR = @IDPROVEEDOR) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", IDPROVEEDOR)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetOrden(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

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

    Public Function ObtenerOrdenRecibeOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(MAX(ORDEN), 0) + 1 AS ORDEN ")
        strSQL.Append("FROM SAB_UACI_ENTREGABASES ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ' COMENTARIO
    ' Este método es utilizado para extraer los datos de la tabla ENTREGABASES con el Proveedor respectivo
    ' PROVEEDOR
    Public Function ObtenerDataSetPorIDwPROVEEDORRpt(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append(" row_number() OVER(ORDER BY EB.ORDEN ASC) AS CORRELATIVO, P.NOMBRE AS nombre, P.CODIGOPROVEEDOR AS codigo, EB.NUMERORECIBO as NUMERORECIBO ")
        strSQL.Append("FROM ")
        strSQL.Append(" SAB_UACI_ENTREGABASES EB ")
        strSQL.Append("   INNER JOIN ")
        strSQL.Append("     SAB_CAT_PROVEEDORES P ")
        strSQL.Append("       ON EB.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE ")
        strSQL.Append(" EB.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append(" EB.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("ORDER BY EB.ORDEN ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function Eliminar2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_ENTREGABASES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerDataSetRptLG(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_ENTREGABASES.IDPROCESOCOMPRA, ")
        strSQL.Append("SAB_UACI_ENTREGABASES.IDPROVEEDOR, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.NOMBRE, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.NIT, ")
        strSQL.Append("ISNULL(SAB_CAT_PROVEEDORES.DIRECCION,' ') AS DIRECCIONP, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS.NOMBRE AS NOMBREE, ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS.DIRECCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAINICIORETIRO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAHORAFINRETIRO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.FECHAPUBLICACION ")
        strSQL.Append("FROM SAB_UACI_ENTREGABASES INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_ENTREGABASES.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS ON ")
        strSQL.Append("SAB_UACI_ENTREGABASES.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_ENTREGABASES.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS ON ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO = SAB_UACI_ENTREGABASES.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE (SAB_UACI_ENTREGABASES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND     (SAB_UACI_ENTREGABASES.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append(" ORDER BY SAB_UACI_ENTREGABASES.ORDEN ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
