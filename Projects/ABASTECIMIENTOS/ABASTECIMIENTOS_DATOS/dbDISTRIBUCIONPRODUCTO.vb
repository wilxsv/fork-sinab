Imports System.Text

Public Class dbDISTRIBUCIONPRODUCTO
    Inherits dbBase

#Region "Sin utilizar"
    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String
        Return String.Empty
    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer
    End Function
#End Region

    Public Function ObtenerProductosParaDistribucion(ByVal IdAlmacen As Integer, ByVal IdSuministro As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT * ")
        strSQL.Append(" FROM DBO.VV_EXISTENCIASALMACENES EA")
        strSQL.Append("         INNER JOIN VV_CATALOGOPRODUCTOS CP ON EA.IDPRODUCTO = CP.IDPRODUCTO")
        strSQL.Append(" WHERE ")
        strSQL.Append("     EA.IDALMACEN = @IdAlmacen AND CP.IDSUMINISTRO = @IdSuministro")


        'If Not String.IsNullOrEmpty(FilterCode) Then
        '    strSQL.Append("     AND CP.CORRPRODUCTO like '%@FilterCode%'")
        'End If
        'If Not String.IsNullOrEmpty(FilterCode) Then
        '    strSQL.Append("     AND CP.DESCLARGO like '%@FilterDesc%'")
        'End If

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IdAlmacen", SqlDbType.Int)
        args(0).Value = IdAlmacen

        args(1) = New SqlParameter("@IdSuministro", SqlDbType.Int)
        args(1).Value = IdSuministro

        'args(2) = New SqlParameter("@FilterCode", SqlDbType.Text)
        'args(2).Value = FilterCode

        'args(3) = New SqlParameter("@FilterDesc", SqlDbType.Text)
        'args(3).Value = FilterDesc


        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    'SCMS
    Public Function ObtenerProductosParaDistribucionPorPrograma(ByVal IdAlmacen As Integer, ByVal IdPrograma As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT * ")
        strSQL.Append(" FROM DBO.VV_EXISTENCIASALMACENES EA")
        strSQL.Append("         INNER JOIN VV_CATALOGOPRODUCTOS CP ON EA.IDPRODUCTO = CP.IDPRODUCTO")
        strSQL.Append("         INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PP ON PP.IDPRODUCTO = CP.IDPRODUCTO AND PP.IDPROGRAMA=" & IdPrograma)
        strSQL.Append(" WHERE ")
        strSQL.Append("     EA.IDALMACEN = @IdAlmacen ")


        'If Not String.IsNullOrEmpty(FilterCode) Then
        '    strSQL.Append("     AND CP.CORRPRODUCTO like '%@FilterCode%'")
        'End If
        'If Not String.IsNullOrEmpty(FilterCode) Then
        '    strSQL.Append("     AND CP.DESCLARGO like '%@FilterDesc%'")
        'End If

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IdAlmacen", SqlDbType.Int)
        args(0).Value = IdAlmacen

        'args(1) = New SqlParameter("@IdSuministro", SqlDbType.Int)
        'args(1).Value = IdSuministro

        'args(2) = New SqlParameter("@FilterCode", SqlDbType.Text)
        'args(2).Value = FilterCode

        'args(3) = New SqlParameter("@FilterDesc", SqlDbType.Text)
        'args(3).Value = FilterDesc


        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerListaProductosDistribucion(ByVal IdAlmacen As Integer, ByVal IdSuminitro As Integer, ByVal IdGrupo As Integer, ByVal IdSubGrupo As Integer) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append("SELECT CP.CORRPRODUCTO, CP.IDPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION, EA.CANTIDADDISPONIBLE FROM VV_CATALOGOPRODUCTOS CP ")
        strSQL.Append("INNER JOIN VV_EXISTENCIASALMACENES EA ON CP.IDPRODUCTO = EA.IDPRODUCTO ")
        strSQL.Append("WHERE EA.IDALMACEN = @IdAlmacen AND CP.IDSUMINISTRO = @IdSuministro AND (CP.IDSUBGRUPO = @IdSubGrupo or @IdSubgrupo=0) AND (CP.IDGRUPO = @IdGrupo or @IdGrupo=0) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IdAlmacen", SqlDbType.Int)
        args(0).Value = IdAlmacen

        args(1) = New SqlParameter("@IdSubGrupo", SqlDbType.Int)
        args(1).Value = IdSubGrupo

        args(2) = New SqlParameter("@IdGrupo", SqlDbType.Int)
        args(2).Value = IdGrupo

        args(3) = New SqlParameter("@IdSuministro", SqlDbType.Int)
        args(3).Value = IdSuminitro

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
    End Function

    Public Function obtenerDistribucionProductos(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append("  WITH S AS( ")
        strSQL.Append("	   SELECT ")
        strSQL.Append("	     DPL.IDPRODUCTO, SUM(CANTIDADDISPONIBLE) AS CANTIDAD ")
        strSQL.Append("	   FROM ")
        strSQL.Append("	     SAB_EST_DISTRIBUCIONPRODUCTOLOTE DPL ")
        strSQL.Append("		   INNER JOIN SAB_ALM_LOTES L ON ")
        strSQL.Append("		     DPL.IDALMACEN = L.IDALMACEN AND ")
        strSQL.Append("		     DPL.IDPRODUCTO = L.IDPRODUCTO AND ")
        strSQL.Append("		     DPL.IDLOTE = L.IDLOTE ")
        strSQL.Append("	   WHERE ")
        strSQL.Append("	     DPL.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("	     DPL.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("	   GROUP BY ")
        strSQL.Append("	     DPL.IDPRODUCTO ")
        strSQL.Append("  ) ")
        strSQL.Append("  ")
        strSQL.Append("  SELECT ")
        strSQL.Append("    DP.IDDISTRIBUCION, CP.CORRPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION, DP.IDPRODUCTO, ")
        strSQL.Append("    ISNULL(S.CANTIDAD, 0) as CANTIDAD ")
        strSQL.Append("  FROM ")
        strSQL.Append("    SAB_EST_DISTRIBUCIONPRODUCTO DP ")
        strSQL.Append("      INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("  	  ON DP.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("  	LEFT OUTER JOIN S ON ")
        strSQL.Append("  	  DP.IDPRODUCTO = S.IDPRODUCTO ")
        strSQL.Append("  WHERE DP.IDDISTRIBUCION = @IDDISTRIBUCION AND DP.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("  ORDER BY CP.CORRPRODUCTO ASC ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function agregarDistribucionProducto(ByVal aEntidad As DISTRIBUCIONPRODUCTO, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO ")
        strSQL.Append("  SAB_EST_DISTRIBUCIONPRODUCTO(")
        strSQL.Append("  IDDISTRIBUCION, IDESTABLECIMIENTO, IDPRODUCTO, ")
        strSQL.Append("  AUUSUARIOCREACION, AUFECHACREACION ")
        strSQL.Append("  ) ")
        strSQL.Append("  VALUES(")
        strSQL.Append("  @IDDISTRIBUCION, @IDESTABLECIMIENTO, @IDPRODUCTO, ")
        strSQL.Append("  @AUUSUARIOCREACION, @AUFECHACREACION ")
        strSQL.Append("  ) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = aEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Value = aEntidad.AUUSUARIOCREACION
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Value = aEntidad.AUFECHACREACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function actualizarDistribucionProducto(ByVal aEntidad As DISTRIBUCIONPRODUCTO, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_EST_DISTRIBUCIONPRODUCTO ")
        strSQL.Append("  SET COMPRATRANSITO = @COMPRATRANSITO, ")
        strSQL.Append("  AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDDISTRIBUCION = @IDDISTRIBUCION AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@COMPRATRANSITO", SqlDbType.Decimal)
        args(2).Value = aEntidad.COMPRATRANSITO
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = aEntidad.AUUSUARIOMODIFICACION
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = aEntidad.AUFECHAMODIFICACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function eliminarDistribucionProducto(ByVal IDDISTRIBUCION As Integer, ByVal IDPRODUCTO As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM ")
        strSQL.Append("  SAB_EST_DISTRIBUCIONPRODUCTO ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDDISTRIBUCION = @IDDISTRIBUCION AND IDPRODUCTO = @IDPRODUCTO AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function eliminarDistribucionProductoDetalle(ByVal IDDISTRIBUCION As Integer, ByVal IDPRODUCTO As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM ")
        strSQL.Append("  SAB_EST_DISTRIBUCIONDETALLE ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDDISTRIBUCION = @IDDISTRIBUCION AND IDPRODUCTO = @IDPRODUCTO AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function eliminarDistribucionProductoDetalleLote(ByVal IDDISTRIBUCION As Integer, ByVal IDPRODUCTO As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM ")
        strSQL.Append("  SAB_EST_DISTRIBUCIONPRODUCTOLOTE ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDDISTRIBUCION = @IDDISTRIBUCION AND IDPRODUCTO = @IDPRODUCTO AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function existeDistribucionProducto(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("  IDALMACEN ")
        strSQL.Append("FROM ")
        strSQL.Append("  SAB_EST_DISTRIBUCION D ")
        strSQL.Append("WHERE D.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("      D.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerExistenciaDistribucionProductoalmacen(ByVal IDALMACEN As Integer, ByVal IDPRODUCTO As Integer) As Decimal

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("  isnull(EA.CANTIDADDISPONIBLE, 0) ")
        strSQL.Append("FROM ")
        strSQL.Append("  vv_EXISTENCIASALMACENES EA ")
        strSQL.Append("WHERE ")
        strSQL.Append("   EA.IDPRODUCTO = @IDPRODUCTO AND ")
        strSQL.Append("   EA.IDALMACEN = @IDALMACEN ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = IDALMACEN

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function productosSeleccionables(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, Optional ByVal CORRPRODUCTO As String = "", Optional idprograma As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT ")
        strSQL.Append("   CP.IDPRODUCTO, CP.DESCLARGO, CP.IDUNIDADMEDIDA, CP.CORRPRODUCTO ")
        strSQL.Append(" FROM ")
        strSQL.Append("   VV_CATALOGOPRODUCTOS CP ")
        strSQL.Append("     INNER JOIN VV_EXISTENCIASALMACENES EA ON ")
        strSQL.Append("       CP.IDPRODUCTO = EA.IDPRODUCTO ")
        If idprograma <> 0 Then
            strSQL.Append("       INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PP ON PP.IDPRODUCTO=CP.IDPRODUCTO ")
        End If
        strSQL.Append(" WHERE ")
        strSQL.Append("   CP.IDSUMINISTRO = @IDSUMINISTRO AND ")
        strSQL.Append("   EA.IDALMACEN = @IDALMACEN ")

        If CORRPRODUCTO <> "" Then
            strSQL.Append(" AND CORRPRODUCTO = @CORRPRODUCTO ")
        End If

        If idprograma <> 0 Then
            strSQL.Append(" AND pp.idprograma = @IDPROGRAMA ")
        End If
        strSQL.Append(" ORDER BY DESCLARGO ASC ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO
        args(1) = New SqlParameter("@CORRPRODUCTO", SqlDbType.VarChar)
        args(1).Value = CORRPRODUCTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = IDALMACEN
        args(3) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(3).Value = idprograma

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerDistribucionProductosDetalle(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT  ")
        strSQL.Append("   DP.IDDISTRIBUCION, DP.IDESTABLECIMIENTO, DP.IDPRODUCTO, ")
        strSQL.Append("   VV.DESCLARGO, VV.CORRPRODUCTO, VV.DESCRIPCION AS UM, ")
        strSQL.Append("   ISNULL(( ")
        strSQL.Append("    SELECT ")
        strSQL.Append("      SUM(L2.CANTIDADDISPONIBLE) ")
        strSQL.Append("    FROM ")
        strSQL.Append("      SAB_EST_DISTRIBUCIONPRODUCTOLOTE DPL2 ")
        strSQL.Append("        INNER JOIN SAB_ALM_LOTES L2 ON ")
        strSQL.Append("          DPL2.IDALMACEN = L2.IDALMACEN AND ")
        strSQL.Append("          DPL2.IDPRODUCTO = L2.IDPRODUCTO AND ")
        strSQL.Append("          DPL2.IDLOTE = L2.IDLOTE ")
        strSQL.Append("    WHERE ")
        strSQL.Append("      DPL2.IDDISTRIBUCION = DP.IDDISTRIBUCION AND ")
        strSQL.Append("      DPL2.IDESTABLECIMIENTO = DP.IDESTABLECIMIENTO AND ")
        strSQL.Append("      DPL2.IDPRODUCTO = DP.IDPRODUCTO ")
        strSQL.Append("    ),0) as CANTIDADALMACEN, ")
        strSQL.Append("    ISNULL(( ")
        strSQL.Append("     SELECT ")
        strSQL.Append("       SUM(CANTIDADREAL) ")
        strSQL.Append("     FROM ")
        strSQL.Append("       DBO.SAB_EST_DISTRIBUCIONDETALLE DD ")
        strSQL.Append("     WHERE ")
        strSQL.Append("      DD.IDDISTRIBUCION = DP.IDDISTRIBUCION AND ")
        strSQL.Append("      DD.IDESTABLECIMIENTO = DP.IDESTABLECIMIENTO AND ")
        strSQL.Append("      DD.IDPRODUCTO = DP.IDPRODUCTO ")
        strSQL.Append("    ),0) as CANTIDADREAL ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_EST_DISTRIBUCIONPRODUCTO DP ")
        strSQL.Append("     INNER JOIN VV_CATALOGOPRODUCTOS VV ON ")
        strSQL.Append("       DP.IDPRODUCTO = VV.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   DP.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("   DP.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        'strSQL.Append(" and not ISNULL((     SELECT       SUM(L2.CANTIDADDISPONIBLE)     FROM       SAB_EST_DISTRIBUCIONPRODUCTOLOTE DPL2         INNER JOIN SAB_ALM_LOTES L2 ON           DPL2.IDALMACEN = L2.IDALMACEN AND           DPL2.IDPRODUCTO = L2.IDPRODUCTO AND           DPL2.IDLOTE = L2.IDLOTE     WHERE       DPL2.IDDISTRIBUCION = DP.IDDISTRIBUCION AND       DPL2.IDESTABLECIMIENTO = DP.IDESTABLECIMIENTO AND       DPL2.IDPRODUCTO = DP.IDPRODUCTO     ),0)=0 ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerLotesDistribucion(ByVal eEntidad As DISTRIBUCIONPRODUCTO) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT ")
        strSQL.Append("   L.CODIGO, UME.DESCRIPCION AS UM, L.PRECIOLOTE, CONVERT(VARCHAR(10), L.FECHAVENCIMIENTO, 103) AS FECHAVENCIMIENTO, FF.NOMBRE, ")
        strSQL.Append("   L.CANTIDADDISPONIBLE, L.IDPRODUCTO, L.IDALMACEN, L.IDLOTE, ")
        strSQL.Append("   CASE WHEN DPL.IDLOTE IS NULL THEN 0 ELSE 1 END AS EXISTE ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_ALM_LOTES L ")
        strSQL.Append("     INNER JOIN DBO.SAB_CAT_UNIDADMEDIDAS UME ON ")
        strSQL.Append("       L.IDUNIDADMEDIDA = UME.IDUNIDADMEDIDA ")
        strSQL.Append("     INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ON ")
        strSQL.Append("       L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("     LEFT OUTER JOIN SAB_EST_DISTRIBUCIONPRODUCTOLOTE DPL ON ")
        strSQL.Append("       L.IDALMACEN = DPL.IDALMACEN AND ")
        strSQL.Append("       L.IDPRODUCTO = DPL.IDPRODUCTO AND ")
        strSQL.Append("       L.IDLOTE = DPL.IDLOTE AND ")
        strSQL.Append("       DPL.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("       DPL.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   L.IDALMACEN = @IDALMACEN AND ")
        strSQL.Append("   L.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("    L.CANTIDADDISPONIBLE DESC, L.FECHAVENCIMIENTO DESC")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = eEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = eEntidad.IDALMACEN
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(3).Value = eEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function eliminarDistribucionLotes(ByVal eEntidad As DISTRIBUCIONPRODUCTO, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" DELETE FROM ")
        strSQL.Append("   DBO.SAB_EST_DISTRIBUCIONPRODUCTOLOTE ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("   IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("   IDPRODUCTO = @IDPRODUCTO AND ")
        strSQL.Append("   IDALMACEN = @IDALMACEN ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = eEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = eEntidad.IDALMACEN
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(3).Value = eEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function agregarDistribucionLotes(ByVal eEntidad As DISTRIBUCIONPRODUCTO, ByVal IDLOTE As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO ")
        strSQL.Append("   SAB_EST_DISTRIBUCIONPRODUCTOLOTE(IDDISTRIBUCION, IDESTABLECIMIENTO, IDPRODUCTO, IDALMACEN, IDLOTE, ")
        strSQL.Append("   AUUSUARIOCREACION, AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION) ")
        strSQL.Append("   VALUES( ")
        strSQL.Append("     @IDDISTRIBUCION, @IDESTABLECIMIENTO, @IDPRODUCTO, @IDALMACEN, @IDLOTE, ")
        strSQL.Append("     NULL, NULL, @AUUSUARIOMODIFICACION, @AUFECHAMODIFICACION ")
        strSQL.Append("   ) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = eEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = eEntidad.IDALMACEN
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(3).Value = eEntidad.IDPRODUCTO
        args(4) = New SqlParameter("@IDLOTE", SqlDbType.Int)
        args(4).Value = IDLOTE
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = eEntidad.AUUSUARIOMODIFICACION
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

End Class
