Partial Public Class dbALMACENESENTREGACONTRATOS

    Public Function obtenerCantidadEntregada(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal IDDETALLE As Integer, ByVal IDALMACENENTREGA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" Select Case CANTIDADENTREGADA ")
        strSQL.Append(" FROM SAB_UACI_ALMACENESENTREGACONTRATOS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ") AND (RENGLON = " & RENGLON & ") AND (IDDETALLE = " & IDDETALLE & ") AND ")
        strSQL.Append(" IDALMACENENTREGA = " & IDALMACENENTREGA & " ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Obtiene las compras en tránsito
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos.</param>
    ''' <param name="IDZONA">Filtro para devolver los datos.</param>
    ''' <param name="IDSUMINISTRO">Filtro para devolver los datos.</param>
    ''' <param name="IDGRUPO">Filtro para devolver los datos.</param>
    ''' <param name="IDSUBGRUPO">Filtro para devolver los datos.</param>
    ''' <param name="IDPRODUCTO">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ZONAS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function RptComprasEnTransito(ByVal IDESTABLECIMIENTO As Integer, ByVal IDZONA As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDSUBGRUPO As Integer, ByVal IDPRODUCTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("E.IDZONA, ")
        strSQL.Append("Z.DESCRIPCION as ZONA, ")
        strSQL.Append("AEC.IDESTABLECIMIENTO, ")
        strSQL.Append("E.NOMBRE, ")
        strSQL.Append("CP.IDSUMINISTRO, CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, CP.DESCSUBGRUPO, ")
        strSQL.Append("PC.IDPRODUCTO, CP.CORRPRODUCTO as CODIGO, CP.DESCLARGO, CP.DESCRIPCION, ")
        strSQL.Append("SUM(AEC.CANTIDAD - AEC.CANTIDADENTREGADA) TRANSITO ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append("ON (AEC.IDESTABLECIMIENTO = EC.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = EC.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = EC.IDCONTRATO ")
        strSQL.Append("AND AEC.RENGLON = EC.RENGLON ")
        strSQL.Append("AND AEC.IDDETALLE = EC.IDDETALLE) ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (EC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND EC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND EC.IDCONTRATO = C.IDCONTRATO ) ")
        strSQL.Append("INNER JOIN  SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON (C.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = PC.IDCONTRATO) ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ZONAS Z ")
        strSQL.Append("ON E.IDZONA = Z.IDZONA ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON CP.IDPRODUCTO = PC.IDPRODUCTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("((PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO OR @IDESTABLECIMIENTO = 0) ")
        strSQL.Append("AND ")
        strSQL.Append("(E.IDZONA = @IDZONA OR @IDZONA = 0)) ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        strSQL.Append("AND (CP.IDSUBGRUPO = @IDSUBGRUPO OR @IDSUBGRUPO = 0) ")
        strSQL.Append("AND (PC.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) ")
        strSQL.Append("AND PC.ESTAHABILITADO = 1 ")
        strSQL.Append("AND C.IDESTADOCONTRATO = 3 ")
        strSQL.Append("AND EC.ESTAHABILITADA = 1 ")
        strSQL.Append("GROUP BY E.IDZONA, Z.DESCRIPCION, AEC.IDESTABLECIMIENTO, E.NOMBRE, PC.IDPRODUCTO,CP.CORRPRODUCTO,CP.DESCLARGO,CP.IDSUMINISTRO, CP.DESCSUMINISTRO,CP.IDGRUPO, CP.IDSUBGRUPO,CP.DESCGRUPO, CP.DESCSUBGRUPO,CP.DESCRIPCION ")
        strSQL.Append("ORDER BY E.IDZONA, AEC.IDESTABLECIMIENTO,  CP.IDSUMINISTRO, CP.IDGRUPO, CP.IDSUBGRUPO,PC.IDPRODUCTO ")

        Dim args(7) As SqlParameter
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(2).Value = IDZONA
        args(3) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(3).Value = IDSUMINISTRO
        args(4) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(4).Value = IDGRUPO
        args(5) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        args(5).Value = IDSUBGRUPO
        args(6) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(6).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDsEntrega(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDALMACENENTREGA As Int32, ByVal ORDEN As Int16, ByVal IDFUENTEFINANCIAMIENTO As Integer) As DataSet

        'Adicion de campo idfuente 20/12/2012

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDDETALLE, CANTIDAD, CANTIDADENTREGADA ,IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND RENGLON = @RENGLON ")
        strSQL.Append("AND IDALMACENENTREGA = @IDALMACENENTREGA ")
        strSQL.Append("AND (IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO or @IDFUENTEFINANCIAMIENTO=-1) ")
        If ORDEN <> 0 Then
            strSQL.Append(" ORDER BY IDDETALLE DESC ")
        End If

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = RENGLON
        args(4) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(4).Value = IDALMACENENTREGA
        args(5) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(5).Value = IDFUENTEFINANCIAMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ActualizarCantidadEntregada(ByVal aEntidad As ALMACENESENTREGACONTRATOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ALMACENESENTREGACONTRATOS ")
        strSQL.Append("SET CANTIDADENTREGADA = @CANTIDADENTREGADA, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND RENGLON = @RENGLON ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")
        strSQL.Append("AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.Decimal)
        args(0).Value = aEntidad.CANTIDADENTREGADA
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(3).Value = aEntidad.IDESTABLECIMIENTO
        args(4) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(4).Value = aEntidad.IDPROVEEDOR
        args(5) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(5).Value = aEntidad.IDCONTRATO
        args(6) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(6).Value = aEntidad.RENGLON
        args(7) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(7).Value = aEntidad.IDDETALLE
        args(8) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(8).Value = aEntidad.IDALMACENENTREGA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

End Class
