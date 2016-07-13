Partial Public Class dbINFORMESNOACEPTACION

#Region " Metodos Agregados "

    Public Function ObtenerListaInformesNoAceptacion(ByVal IDALMACEN As Integer, ByVal IDPROVEEDOR As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer, ByVal IDESTADO As Integer, ByVal NUMEROINFORME As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("INA.IDALMACEN, ")
        strSQL.Append("INA.ANIO, ")
        strSQL.Append("INA.IDINFORME, ")
        strSQL.Append("M.IDESTABLECIMIENTO IDESTABLECIMIENTOMOVIMIENTO, ")
        strSQL.Append("M.IDMOVIMIENTO, ")
        strSQL.Append("INA.IDESTABLECIMIENTO, ")
        strSQL.Append("INA.IDPROVEEDOR, ")
        strSQL.Append("INA.IDCONTRATO, ")
        strSQL.Append("convert(varchar, INA.IDINFORME) + '/' + convert(varchar, INA.ANIO) NUMEROINFORME, ")
        strSQL.Append("convert(varchar, M.FECHAMOVIMIENTO, 103) FECHAMOVIMIENTO, ")
        strSQL.Append("TDC.DESCRIPCION + ' ' + C.NUMEROCONTRATO TIPONUMERODOCUMENTO, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        'strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        'strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("E.DESCRIPCION ESTADO ")
        strSQL.Append("FROM SAB_ALM_INFORMESNOACEPTACION INA ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (INA.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND INA.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND INA.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOCONTRATO TDC ")
        strSQL.Append("ON C.IDTIPODOCUMENTO = TDC.IDTIPODOCUMENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON INA.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS M ")
        strSQL.Append("ON (INA.IDALMACEN = M.IDALMACEN ")
        strSQL.Append("AND INA.ANIO = M.ANIO ")
        strSQL.Append("AND INA.IDINFORME = M.IDDOCUMENTO) ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_LOTESNOACEPTACION L ")
        strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSMOVIMIENTOS E ")
        strSQL.Append("ON M.IDESTADO = E.IDESTADO ")
        strSQL.Append("WHERE INA.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND (INA.IDPROVEEDOR = @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")
        strSQL.Append("AND ((M.FECHAMOVIMIENTO between @FECHADESDE AND @FECHAHASTA) OR (@FECHADESDE IS NULL OR @FECHAHASTA IS NULL)) ")
        strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        strSQL.Append("AND (M.IDESTADO = @IDESTADO OR @IDESTADO = 0) ")
        strSQL.Append("AND (INA.IDINFORME = @NUMEROINFORME OR @NUMEROINFORME = 0) ")
        strSQL.Append("AND M.IDTIPOTRANSACCION = 11 ")
        strSQL.Append("ORDER BY INA.ANIO DESC, INA.IDINFORME DESC")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        args(2).Value = IIf(FECHADESDE = Nothing, DBNull.Value, FECHADESDE)
        args(3) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(3).Value = IIf(FECHAHASTA = Nothing, DBNull.Value, FECHAHASTA)
        args(4) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(4).Value = IDFUENTEFINANCIAMIENTO
        args(5) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(5).Value = IDRESPONSABLEDISTRIBUCION
        args(6) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(6).Value = IDESTADO
        args(7) = New SqlParameter("@NUMEROINFORME", SqlDbType.Int)
        args(7).Value = NUMEROINFORME

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
