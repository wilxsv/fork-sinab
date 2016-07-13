Partial Public Class dbEXISTENCIASALMACENES

#Region " Métodos Agregados "

    Public Function obtenerDsDatosProducto(ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CP.IDPRODUCTO, ")
        strSQL.Append("CP.NOMBRE, ")
        strSQL.Append("EA.CANTIDADDISPONIBLE, ")
        strSQL.Append("EA.CANTIDADNODISPONIBLE, ")
        strSQL.Append("CP.APLICALOTE, ")
        strSQL.Append("CP.PRECIOACTUAL, ")
        strSQL.Append("CP.DESCRIPCION AS UNIDAD_MEDIDA ")
        strSQL.Append("FROM vv_EXISTENCIASALMACENES EA ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON EA.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE (CP.IDPRODUCTO = @IDPRODUCTO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDsDatosProductoxCODIGO(ByVal IDALMACEN As Integer, ByVal CODIGOPRODUCTO As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CP.IDPRODUCTO, ")
        strSQL.Append("CP.NOMBRE, ")
        strSQL.Append("EA.CANTIDADDISPONIBLE, ")
        strSQL.Append("EA.CANTIDADNODISPONIBLE, ")
        strSQL.Append("CP.APLICALOTE, ")
        strSQL.Append("CP.PRECIOACTUAL, ")
        strSQL.Append("CP.DESCRIPCION UNIDAD_MEDIDA ")
        strSQL.Append("FROM vv_EXISTENCIASALMACENES EA ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON EA.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE EA.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND CP.CODIGO = @CODIGOPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@CODIGOPRODUCTO", SqlDbType.VarChar)
        args(1).Value = CODIGOPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
