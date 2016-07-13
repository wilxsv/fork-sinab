Partial Public Class dbALMACENESENTREGAADJUDICACION



    Public Function Agregar2(ByVal aEntidad As entidadBase, ByVal MOMENTO As Integer) As Integer

        Dim lEntidad As ALMACENESENTREGAADJUDICACION
        lEntidad = aEntidad

        Dim strSQL As New Text.StringBuilder
        Select Case MOMENTO
            Case Is = 1
                strSQL.Append("INSERT INTO SAB_UACI_ALMACENESENTREGARECOMENDACION ")
                strSQL.Append(" ( IDESTABLECIMIENTO, ")
                strSQL.Append(" IDPROCESOCOMPRA, ")
                strSQL.Append(" IDPROVEEDOR, ")
                strSQL.Append(" IDDETALLE, ")
                strSQL.Append(" IDENTREGA, ")
                strSQL.Append(" IDALMACEN, ")
                strSQL.Append(" CANTIDAD, ")
                strSQL.Append(" AUUSUARIOCREACION, ")
                strSQL.Append(" AUFECHACREACION, ")
                strSQL.Append(" IDFUENTEFINANCIAMIENTO) ")
                strSQL.Append(" VALUES ")
                strSQL.Append(" ( @IDESTABLECIMIENTO, ")
                strSQL.Append(" @IDPROCESOCOMPRA, ")
                strSQL.Append(" @IDPROVEEDOR, ")
                strSQL.Append(" @IDDETALLE, ")
                strSQL.Append(" @IDENTREGA, ")
                strSQL.Append(" @IDALMACEN, ")
                strSQL.Append(" @CANTIDAD, ")
                strSQL.Append(" @AUUSUARIOCREACION, ")
                strSQL.Append(" @AUFECHACREACION, ")
                strSQL.Append(" @IDFUENTEFINANCIAMIENTO) ")

                Dim args(9) As SqlParameter
                args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
                args(0).Value = lEntidad.IDESTABLECIMIENTO
                args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
                args(1).Value = lEntidad.IDPROCESOCOMPRA
                args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
                args(2).Value = lEntidad.IDPROVEEDOR
                args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
                args(3).Value = lEntidad.IDDETALLE
                args(4) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
                args(4).Value = lEntidad.IDENTREGA
                args(5) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
                args(5).Value = lEntidad.IDALMACEN
                args(6) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
                args(6).Value = lEntidad.CANTIDAD
                args(7) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
                args(7).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
                args(8) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
                args(8).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
                args(9) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
                args(9).Value = lEntidad.IDFUENTEFINANCIAMIENTO

                Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

            Case Is = 2
                strSQL.Append("INSERT INTO SAB_UACI_ALMACENESENTREGAADJUDICACION ")
                strSQL.Append(" ( IDESTABLECIMIENTO, ")
                strSQL.Append(" IDPROCESOCOMPRA, ")
                strSQL.Append(" IDPROVEEDOR, ")
                strSQL.Append(" IDDETALLE, ")
                strSQL.Append(" IDENTREGA, ")
                strSQL.Append(" IDALMACEN, ")
                strSQL.Append(" CANTIDAD, ")
                strSQL.Append(" AUUSUARIOCREACION, ")
                strSQL.Append(" AUFECHACREACION, ")
                strSQL.Append(" AUUSUARIOMODIFICACION, ")
                strSQL.Append(" AUFECHAMODIFICACION, ")
                strSQL.Append(" ESTASINCRONIZADA, IDFUENTEFINANCIAMIENTO) ")
                strSQL.Append(" VALUES ")
                strSQL.Append(" ( @IDESTABLECIMIENTO, ")
                strSQL.Append(" @IDPROCESOCOMPRA, ")
                strSQL.Append(" @IDPROVEEDOR, ")
                strSQL.Append(" @IDDETALLE, ")
                strSQL.Append(" @IDENTREGA, ")
                strSQL.Append(" @IDALMACEN, ")
                strSQL.Append(" @CANTIDAD, ")
                strSQL.Append(" @AUUSUARIOCREACION, ")
                strSQL.Append(" @AUFECHACREACION, ")
                strSQL.Append(" @AUUSUARIOMODIFICACION, ")
                strSQL.Append(" @AUFECHAMODIFICACION, ")
                strSQL.Append(" @ESTASINCRONIZADA, @IDFUENTEFINANCIAMIENTO) ")

                Dim args(12) As SqlParameter
                args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
                args(0).Value = lEntidad.IDESTABLECIMIENTO
                args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
                args(1).Value = lEntidad.IDPROCESOCOMPRA
                args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
                args(2).Value = lEntidad.IDPROVEEDOR
                args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
                args(3).Value = lEntidad.IDDETALLE
                args(4) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
                args(4).Value = lEntidad.IDENTREGA
                args(5) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
                args(5).Value = lEntidad.IDALMACEN
                args(6) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
                args(6).Value = lEntidad.CANTIDAD
                args(7) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
                args(7).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
                args(8) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
                args(8).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
                args(9) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
                args(9).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
                args(10) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
                args(10).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
                args(11) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
                args(11).Value = lEntidad.ESTASINCRONIZADA
                args(12) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
                args(12).Value = lEntidad.IDFUENTEFINANCIAMIENTO

                Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

            Case Is = 3

                strSQL.Append("INSERT INTO SAB_UACI_ALMACENESENTREGAADJUDICACIONFIRME ")
                strSQL.Append(" ( IDESTABLECIMIENTO, ")
                strSQL.Append(" IDPROCESOCOMPRA, ")
                strSQL.Append(" IDPROVEEDOR, ")
                strSQL.Append(" IDDETALLE, ")
                strSQL.Append(" IDENTREGA, ")
                strSQL.Append(" IDALMACEN, ")
                strSQL.Append(" CANTIDAD, ")
                strSQL.Append(" AUUSUARIOCREACION, ")
                strSQL.Append(" AUFECHACREACION, ")
                strSQL.Append(" IDFUENTEFINANCIAMIENTO) ")
                strSQL.Append(" VALUES ")
                strSQL.Append(" ( @IDESTABLECIMIENTO, ")
                strSQL.Append(" @IDPROCESOCOMPRA, ")
                strSQL.Append(" @IDPROVEEDOR, ")
                strSQL.Append(" @IDDETALLE, ")
                strSQL.Append(" @IDENTREGA, ")
                strSQL.Append(" @IDALMACEN, ")
                strSQL.Append(" @CANTIDAD, ")
                strSQL.Append(" @AUUSUARIOCREACION, ")
                strSQL.Append(" @AUFECHACREACION, ")
                strSQL.Append(" @IDFUENTEFINANCIAMIENTO) ")

                Dim args(9) As SqlParameter
                args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
                args(0).Value = lEntidad.IDESTABLECIMIENTO
                args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
                args(1).Value = lEntidad.IDPROCESOCOMPRA
                args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
                args(2).Value = lEntidad.IDPROVEEDOR
                args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
                args(3).Value = lEntidad.IDDETALLE
                args(4) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
                args(4).Value = lEntidad.IDENTREGA
                args(5) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
                args(5).Value = lEntidad.IDALMACEN
                args(6) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
                args(6).Value = lEntidad.CANTIDAD
                args(7) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
                args(7).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
                args(8) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
                args(8).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
                args(9) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
                args(9).Value = lEntidad.IDFUENTEFINANCIAMIENTO

                Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        End Select





    End Function
    ''' <summary>
    ''' Obtiene la información de los almacenes en la adjudicación
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="RENGLON">Identificador  del renglon</param>
    ''' <returns>Informacion de almacenes en formato de dataset</returns>

    Public Function obtenerAlmacenesAdjudicacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_ALMACENES.NOMBRE AS ALMACEN, SAB_UACI_ALMACENESENTREGAADJUDICACION.IDALMACEN ")
        strSQL.Append(" FROM SAB_CAT_ALMACENES INNER JOIN ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION ON ")
        strSQL.Append(" SAB_CAT_ALMACENES.IDALMACEN = SAB_UACI_ALMACENESENTREGAADJUDICACION.IDALMACEN INNER JOIN ")
        strSQL.Append(" SAB_UACI_ADJUDICACION ON ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROVEEDOR = SAB_UACI_ADJUDICACION.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDDETALLE = SAB_UACI_ADJUDICACION.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_ALMACENESENTREGAADJUDICACION.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (SAB_UACI_ALMACENESENTREGAADJUDICACION.IDDETALLE = " & RENGLON & ") ")
        strSQL.Append(" GROUP BY SAB_CAT_ALMACENES.NOMBRE, SAB_UACI_ALMACENESENTREGAADJUDICACION.IDALMACEN ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Distribución de un producto
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="IDALMACEN">Identificación del almacen</param>
    ''' <param name="RENGLON">Identificación del renglon</param>
    ''' <returns>Informacion de la distribución de un producto</returns>

    Public Function obtenerDistribucionProducto(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDALMACEN As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_ALMACENESENTREGAADJUDICACION.IDALMACEN, SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON, ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDDETALLE, SAB_UACI_ALMACENESENTREGAADJUDICACION.IDENTREGA, ")
        strSQL.Append(" SAB_CAT_ALMACENES.NOMBRE AS ALMACEN, SAB_UACI_ALMACENESENTREGAADJUDICACION.CANTIDAD, ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS.NOMBRE AS PRODUCTO, SAB_UACI_ENTREGAADJUDICACION.PORCENTAJE, ")
        strSQL.Append(" SAB_UACI_ENTREGAADJUDICACION.DIAS, SAB_UACI_ALMACENESENTREGAADJUDICACION.IDFUENTEFINANCIAMIENTO, FF.NOMBRE AS NOMBREFUENTEFINANCIAMIENTO  ")
        strSQL.Append(" FROM SAB_UACI_ALMACENESENTREGAADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_CAT_ALMACENES ON SAB_UACI_ALMACENESENTREGAADJUDICACION.IDALMACEN = SAB_CAT_ALMACENES.IDALMACEN INNER JOIN ")
        strSQL.Append(" SAB_UACI_ADJUDICACION ON ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROVEEDOR = SAB_UACI_ADJUDICACION.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDDETALLE = SAB_UACI_ADJUDICACION.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.RENGLON = SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append(" SAB_UACI_ENTREGAADJUDICACION ON ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_ENTREGAADJUDICACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_ENTREGAADJUDICACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROVEEDOR = SAB_UACI_ENTREGAADJUDICACION.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDDETALLE = SAB_UACI_ENTREGAADJUDICACION.IDDETALLE AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION.IDENTREGA = SAB_UACI_ENTREGAADJUDICACION.IDENTREGA ")
        strSQL.Append(" INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF  ON FF.IDFUENTEFINANCIAMIENTO=SAB_UACI_ALMACENESENTREGAADJUDICACION.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append(" WHERE (SAB_UACI_ALMACENESENTREGAADJUDICACION.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (SAB_UACI_ALMACENESENTREGAADJUDICACION.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (SAB_UACI_ALMACENESENTREGAADJUDICACION.IDALMACEN = " & IDALMACEN & ") AND ")
        strSQL.Append(" (SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON = " & RENGLON & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function obtenerSumatoriaxProveedorxRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SUM(AEA.CANTIDAD) ")
        strSQL.Append(" FROM SAB_UACI_ALMACENESENTREGAADJUDICACION AEA INNER JOIN SAB_UACI_DETALLEOFERTA DO ON ")
        strSQL.Append(" AEA.IDESTABLECIMIENTO=DO.IDESTABLECIMIENTO AND AEA.IDPROCESOCOMPRA=DO.IDPROCESOCOMPRA AND AEA.IDPROVEEDOR=DO.IDPROVEEDOR AND AEA.IDDETALLE=DO.IDDETALLE ")
        strSQL.Append(" WHERE (AEA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (AEA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (AEA.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (DO.RENGLON = " & RENGLON & ") ")


        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function obtenerCantidadxAlmacenxProveedorxRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT AEA.* ")
        strSQL.Append(" FROM SAB_UACI_ALMACENESENTREGAADJUDICACION AEA INNER JOIN SAB_UACI_DETALLEOFERTA DO ON ")
        strSQL.Append(" AEA.IDESTABLECIMIENTO=DO.IDESTABLECIMIENTO AND AEA.IDPROCESOCOMPRA=DO.IDPROCESOCOMPRA AND AEA.IDPROVEEDOR=DO.IDPROVEEDOR AND AEA.IDDETALLE=DO.IDDETALLE ")
        strSQL.Append(" WHERE (AEA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (AEA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (AEA.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (DO.RENGLON = " & RENGLON & ") ")


        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ActualizarCantidadxAlmacenxProveedorxRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal IDENTREGA As Integer, ByVal IDALMACEN As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal CANTIDAD As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" UPDATE ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGAADJUDICACION  ")
        strSQL.Append(" SET CANTIDAD=" & CANTIDAD)
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDDETALLE = " & IDDETALLE & ") AND (IDENTREGA=" & IDENTREGA & ") AND (IDALMACEN=" & IDALMACEN & ")  AND (IDFUENTEFINANCIAMIENTO=" & IDFUENTEFINANCIAMIENTO & ")")


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
End Class
