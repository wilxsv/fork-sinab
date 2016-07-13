Partial Public Class dbANALISTAPROVEEDORES

    Public Function ObtenerProveedoresNoAsignados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("A.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")

        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON A.IDPROVEEDOR = P.IDPROVEEDOR ")

        strSQL.Append("LEFT OUTER JOIN SAB_UACI_ANALISTAPROVEEDORES AP ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = AP.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = AP.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = AP.IDPROVEEDOR) ")

        strSQL.Append("WHERE A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND AP.IDPROVEEDOR is null ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerProveedoresAsignados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDANALISTA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("OPC.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_ANALISTAPROVEEDORES AP ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON AP.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
        strSQL.Append("ON (AP.IDESTABLECIMIENTO = OPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND AP.IDPROCESOCOMPRA = OPC.IDPROCESOCOMPRA ")
        strSQL.Append("AND AP.IDPROVEEDOR = OPC.IDPROVEEDOR) ")
        strSQL.Append("WHERE AP.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND AP.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND AP.IDANALISTA = @IDANALISTA ")

        Dim args(2) As SqlParameter
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

    Public Function ObtenerProveedoresAsignadosPorProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDANALISTA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("count(OPC.IDPROVEEDOR) ")
        strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
        strSQL.Append("INNER JOIN SAB_UACI_ANALISTAPROVEEDORES AP ")
        strSQL.Append("ON (OPC.IDESTABLECIMIENTO = AP.IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = AP.IDPROCESOCOMPRA ")
        strSQL.Append("AND OPC.IDPROVEEDOR = AP.IDPROVEEDOR) ")
        strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND AP.IDANALISTA = @IDANALISTA ")
        strSQL.Append("GROUP BY AP.IDANALISTA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDANALISTA", SqlDbType.Int)
        args(2).Value = IDANALISTA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

End Class
