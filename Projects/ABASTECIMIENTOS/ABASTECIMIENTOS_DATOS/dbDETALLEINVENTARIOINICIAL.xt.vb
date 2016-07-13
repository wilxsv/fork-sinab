Imports System.Text

Partial Public Class dbDETALLEINVENTARIOINICIAL
    Inherits dbBase

#Region "Metodos Adicionales"

    Public Function ObtenerInventarioInicial(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("row_number() over (ORDER BY IDALMACEN, IDINVENTARIO, IDLOTE) RENGLON, ")
        strSQL.Append("DII.IDALMACEN, ")
        strSQL.Append("DII.IDINVENTARIO, ")
        strSQL.Append("DII.IDLOTE, ")
        strSQL.Append("DII.IDPRODUCTO, ")
        strSQL.Append("DII.IDUNIDADMEDIDA, ")
        strSQL.Append("DII.CODIGO, ")
        strSQL.Append("DII.DETALLE, ")
        strSQL.Append("DII.PRECIOLOTE, ")
        strSQL.Append("DII.FECHAVENCIMIENTO, ")
        strSQL.Append("DII.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("DII.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("DII.CANTIDADDISPONIBLE, ")
        strSQL.Append("DII.CANTIDADNODISPONIBLE, ")
        strSQL.Append("DII.CANTIDADVENCIDA, ")
        strSQL.Append("DII.UBICACION, ")
        strSQL.Append("DII.AUUSUARIOCREACION, ")
        strSQL.Append("DII.AUFECHACREACION, ")
        strSQL.Append("DII.AUUSUARIOMODIFICACION, ")
        strSQL.Append("DII.AUFECHAMODIFICACION, ")
        strSQL.Append("DII.ESTASINCRONIZADA, ")
        strSQL.Append("case when DII.CODIGO is null then case when DII.DETALLE is null then '(N/A)' else DII.DETALLE end else DII.CODIGO + isnull(DII.DETALLE, '') end CODIGODETALLE, ")
        strSQL.Append("isnull(replicate('0', 2 - len(convert(varchar, datepart(month, DII.FECHAVENCIMIENTO)))) + convert(varchar, datepart(month, DII.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, DII.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("((DII.CANTIDADDISPONIBLE + DII.CANTIDADNODISPONIBLE + DII.CANTIDADVENCIDA) * DII.PRECIOLOTE) TOTAL, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.UNIDADMEDIDA, ")
        strSQL.Append("CP.CANTIDADDECIMAL, ")
        strSQL.Append("FF.NOMBRE NOMBREFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.IDGRUPO IDGRUPOFUENTEFINANCIAMIENTO ")
        strSQL.Append("FROM SAB_ALM_DETALLEINVENTARIOINICIAL DII ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DII.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON DII.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("WHERE DII.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND DII.IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append("ORDER BY ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("DII.FECHAVENCIMIENTO, ")
        strSQL.Append("DII.CANTIDADDISPONIBLE, ")
        strSQL.Append("DII.CANTIDADVENCIDA, ")
        strSQL.Append("DII.CANTIDADNODISPONIBLE ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

        Return ds

    End Function

    Public Function CerrarInventarioInicial(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal IDESTABLECIMIENTO As Int32, ByVal AUUSUARIOCREACION As String, ByVal AUFECHACREACION As DateTime) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("sproc_CerrarInventarioInicial ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Direction = ParameterDirection.Input
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDINVENTARIO
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDESTABLECIMIENTO
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = AUUSUARIOCREACION
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = AUFECHACREACION
        args(5) = New SqlParameter("@resultado", SqlDbType.Int)
        args(5).Direction = ParameterDirection.ReturnValue

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString, args)

        Return args(5).Value

    End Function

    Public Function ConsultaInventarioInicial(ByVal IDALMACEN As Integer, ByVal IDINVENTARIO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("II.IDALMACEN, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("convert(varchar, II.FECHAINVENTARIO, 103) FECHAMOVIMIENTO, ")
        strSQL.Append("DII.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.UNIDADMEDIDA, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("DII.IDLOTE, ")
        strSQL.Append("isnull(DII.CODIGO + isnull(DII.DETALLE, ''), '(N/A)') CODIGO, ")
        strSQL.Append("DII.PRECIOLOTE, ")
        strSQL.Append("DII.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(replicate('0', 2 - len(convert(varchar, datepart(month, DII.FECHAVENCIMIENTO)))) + convert(varchar, datepart(month, DII.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, DII.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("DII.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRE NOMBRERESPONSABLE, ")
        strSQL.Append("RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        strSQL.Append("DII.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("DII.CANTIDADDISPONIBLE, ")
        strSQL.Append("(DII.CANTIDADDISPONIBLE * DII.PRECIOLOTE) MONTODISPONIBLE, ")
        strSQL.Append("DII.CANTIDADNODISPONIBLE, ")
        strSQL.Append("(DII.CANTIDADNODISPONIBLE * DII.PRECIOLOTE) MONTONODISPONIBLE, ")
        strSQL.Append("DII.CANTIDADVENCIDA, ")
        strSQL.Append("(DII.CANTIDADVENCIDA * DII.PRECIOLOTE) MONTOVENCIDA, ")
        strSQL.Append("isnull(DII.UBICACION, '') UBICACION ")
        strSQL.Append("FROM SAB_ALM_INVENTARIOINICIAL II ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON II.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEINVENTARIOINICIAL DII ")
        strSQL.Append("ON II.IDALMACEN = DII.IDALMACEN ")
        strSQL.Append("AND II.IDINVENTARIO = DII.IDINVENTARIO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON DII.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON DII.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DII.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE II.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND II.IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append("ORDER BY ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("DII.FECHAVENCIMIENTO, ")
        strSQL.Append("DII.CANTIDADDISPONIBLE, ")
        strSQL.Append("DII.CANTIDADVENCIDA, ")
        strSQL.Append("DII.CANTIDADNODISPONIBLE ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

        Return ds

    End Function

#End Region

End Class
