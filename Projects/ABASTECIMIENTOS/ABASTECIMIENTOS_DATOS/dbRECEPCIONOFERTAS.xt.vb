Partial Public Class dbRECEPCIONOFERTAS

#Region " Metodos Agregados "

    Public Function ObtenerDataSet_OfertasRecibidas(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("RO.IDPROVEEDOR, ")
        strSQL.Append("RO.IDPROCESOCOMPRA, ")
        strSQL.Append("RO.IDESTABLECIMIENTO, ")
        strSQL.Append("P.NOMBRE, ")
        strSQL.Append("RO.ORDENLLEGADA, ")
        strSQL.Append("RO.FECHAENTREGA, ")
        strSQL.Append("OPC.MONTOOFERTA, ")
        strSQL.Append("OPC.MONTOGARANTIA, ")
        strSQL.Append("OPC.NOMBREREPRESENTANTE, ")
        strSQL.Append("OPC.ESTAHABILITADO, ")
        strSQL.Append("OPC.OBSERVACION, ")
        strSQL.Append("RO.PERSONAENTREGA, ")
        strSQL.Append("CASE WHEN ISNULL(OPC.NOMBREREPRESENTANTE, '') = '' THEN RO.PERSONAENTREGA ")
        strSQL.Append("ELSE OPC.NOMBREREPRESENTANTE ")
        strSQL.Append("END REPRESENTATE ")
        strSQL.Append("FROM SAB_UACI_RECEPCIONOFERTAS RO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON RO.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
        strSQL.Append("ON RO.IDPROCESOCOMPRA = OPC.IDPROCESOCOMPRA ")
        strSQL.Append("AND RO.IDPROVEEDOR = OPC.IDPROVEEDOR ")
        strSQL.Append("AND RO.IDESTABLECIMIENTO = OPC.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE RO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND RO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY RO.ORDENLLEGADA")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerProveedoresNoAsignados(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_ENTREGABASES.IDPROCESOCOMPRA, SAB_CAT_PROVEEDORES.NOMBRE, SAB_UACI_ENTREGABASES.IDPROVEEDOR, ")
        strSQL.Append(" SAB_UACI_ENTREGABASES.IDESTABLECIMIENTO ")
        strSQL.Append(" FROM SAB_UACI_ENTREGABASES INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_ENTREGABASES.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_ENTREGABASES.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (SAB_UACI_ENTREGABASES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND ")
        strSQL.Append(" (SAB_UACI_ENTREGABASES.IDPROVEEDOR NOT IN ")
        strSQL.Append(" (SELECT IDPROVEEDOR ")
        strSQL.Append(" FROM SAB_UACI_RECEPCIONOFERTAS ")
        strSQL.Append(" WHERE (IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (IDESTABLECIMIENTO = @IDESTABLECIMIENTO))) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerIDProveedor(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64, ByVal ORDENLLEGADA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDPROVEEDOR ")
        strSQL.Append(" FROM SAB_UACI_RECEPCIONOFERTAS ")
        strSQL.Append("WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (ORDENLLEGADA = @ORDENLLEGADA) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)
        args(2) = New SqlParameter("@ordenllegada", ORDENLLEGADA)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerDescripcionRazon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, SAB_CAT_PROVEEDORES.NOMBRE ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS INNER JOIN ")
        strSQL.Append("  SAB_UACI_RECEPCIONOFERTAS ON ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO = SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA = SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_RECEPCIONOFERTAS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_RECEPCIONOFERTAS.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (SAB_UACI_RECEPCIONOFERTAS.IDPROVEEDOR = " & IDPROVEEDOR & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDataSet_OfertasRecibidasRpt(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append(" RO.ORDENLLEGADA AS CORRELATIVO, P.NOMBRE AS NOMBRE, P.CODIGOPROVEEDOR AS CODIGO ")
        strSQL.Append(" FROM SAB_UACI_RECEPCIONOFERTAS RO INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES P ON RO.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append(" WHERE RO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND RO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" ORDER BY RO.ORDENLLEGADA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSet_OfertasRecibidas2(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append(" RO.ORDENLLEGADA As OFERTA, P.NOMBRE as PROVEEDOR, P.CODIGOPROVEEDOR as CODIGO, p.IDPROVEEDOR ")
        strSQL.Append(" FROM SAB_UACI_RECEPCIONOFERTAS RO INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES P ON RO.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append(" WHERE RO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND RO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" ORDER BY RO.ORDENLLEGADA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
