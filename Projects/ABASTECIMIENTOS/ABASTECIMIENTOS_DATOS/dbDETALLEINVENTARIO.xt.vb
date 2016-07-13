Partial Public Class dbDETALLEINVENTARIO

#Region "Metodos agregados"

    ''' <summary>
    ''' obtener la informacion del detalle de productos de un inventario
    ''' </summary>
    ''' <param name="IDINVENTARIO"></param> identificador de inventario
    ''' <param name="IDALMACEN"></param> identificador de almacen
    ''' <param name="IDDETALLE"></param> 'identificador de detalle de producto
    ''' <returns>
    ''' Dataset filtrado
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEINVENTARIO</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDsDetalleInventario(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, Optional ByVal IDDETALLE As Int32 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DI.IDINVENTARIO, ")
        strSQL.Append("DI.IDDETALLE, ")
        strSQL.Append("DI.IDALMACEN, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("DI.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.CORRPRODUCTO + ' ' + CP.DESCLARGO PRODUCTO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("DI.PRECIO, ")
        strSQL.Append("DI.CANTIDADDISPONIBLESISTEMA, ")
        strSQL.Append("DI.CANTIDADDISPONIBLECAPTURA, ")
        strSQL.Append("DI.CANTIDADDISPONIBLEDIFERENCIA, ")
        strSQL.Append("DI.CANTIDADNODISPONIBLESISTEMA, ")
        strSQL.Append("DI.CANTIDADNODISPONIBLECAPTURA, ")
        strSQL.Append("DI.CANTIDADNODISPONIBLEDIFERENCIA, ")
        strSQL.Append("DI.CANTIDADVENCIDASISTEMA, ")
        strSQL.Append("DI.CANTIDADVENCIDACAPTURA, ")
        strSQL.Append("DI.CANTIDADVENCIDADIFERENCIA ")
        strSQL.Append("FROM SAB_ALM_DETALLEINVENTARIO DI ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DI.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON DI.IDALMACEN = L.IDALMACEN ")
        strSQL.Append("AND DI.IDLOTE = L.IDLOTE ")
        strSQL.Append("WHERE DI.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND DI.IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append("AND (DI.IDDETALLE = @IDDETALLE OR @IDDETALLE = 0) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO
        args(2) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(2).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Recupera la informacion de un producto especifico del detalle
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLEINVENTARIO
    ''' <returns>
    ''' devuelve uno si la operacion se completo
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEINVENTARIO</description></item>
    ''' </list>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function RecuperarDetalleProducto(ByVal aEntidad As DETALLEINVENTARIO) As Integer

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDLOTE = @IDLOTE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = aEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = aEntidad.IDINVENTARIO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = aEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDLOTE", SqlDbType.Int)
        args(3).Value = aEntidad.IDLOTE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With ds.Tables(0).Rows(0)
                aEntidad.IDDETALLE = IIf(.Item("IDDETALLE") Is DBNull.Value, Nothing, .Item("IDDETALLE"))
                aEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
                aEntidad.PRECIO = IIf(.Item("PRECIO") Is DBNull.Value, Nothing, .Item("PRECIO"))
                aEntidad.CANTIDADDISPONIBLESISTEMA = IIf(.Item("CANTIDADDISPONIBLESISTEMA") Is DBNull.Value, Nothing, .Item("CANTIDADDISPONIBLESISTEMA"))
                aEntidad.CANTIDADDISPONIBLECAPTURA = IIf(.Item("CANTIDADDISPONIBLECAPTURA") Is DBNull.Value, Nothing, .Item("CANTIDADDISPONIBLECAPTURA"))
                aEntidad.CANTIDADDISPONIBLEDIFERENCIA = IIf(.Item("CANTIDADDISPONIBLEDIFERENCIA") Is DBNull.Value, Nothing, .Item("CANTIDADDISPONIBLEDIFERENCIA"))
                aEntidad.CANTIDADNODISPONIBLESISTEMA = IIf(.Item("CANTIDADNODISPONIBLESISTEMA") Is DBNull.Value, Nothing, .Item("CANTIDADNODISPONIBLESISTEMA"))
                aEntidad.CANTIDADNODISPONIBLECAPTURA = IIf(.Item("CANTIDADNODISPONIBLECAPTURA") Is DBNull.Value, Nothing, .Item("CANTIDADNODISPONIBLECAPTURA"))
                aEntidad.CANTIDADNODISPONIBLEDIFERENCIA = IIf(.Item("CANTIDADNODISPONIBLEDIFERENCIA") Is DBNull.Value, Nothing, .Item("CANTIDADNODISPONIBLEDIFERENCIA"))
                aEntidad.CANTIDADVENCIDASISTEMA = IIf(.Item("CANTIDADVENCIDASISTEMA") Is DBNull.Value, Nothing, .Item("CANTIDADVENCIDASISTEMA"))
                aEntidad.CANTIDADVENCIDACAPTURA = IIf(.Item("CANTIDADVENCIDACAPTURA") Is DBNull.Value, Nothing, .Item("CANTIDADVENCIDACAPTURA"))
                aEntidad.CANTIDADVENCIDADIFERENCIA = IIf(.Item("CANTIDADVENCIDADIFERENCIA") Is DBNull.Value, Nothing, .Item("CANTIDADVENCIDADIFERENCIA"))
                aEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                aEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                aEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                aEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                aEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    ''' <summary>
    ''' Elimina los productos del detalle de un inventario
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLEINVENTARIO
    ''' <returns>
    ''' devuelve uno si la operacion se completo
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_DETALLEINVENTARIO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function EliminarDetalleInventario(ByVal aEntidad As DETALLEINVENTARIO) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_DETALLEINVENTARIO ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = aEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = aEntidad.IDINVENTARIO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function AjusteInventario(ByVal eCA As CORRECCIONESALMACENES, ByVal eM As MOVIMIENTOS, ByVal eDMDisponible As DETALLEMOVIMIENTOS, ByVal eDMNoDisponible As DETALLEMOVIMIENTOS, ByVal eDMVencida As DETALLEMOVIMIENTOS, ByVal eL As LOTES, ByVal eDI As DETALLEINVENTARIO) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(IDCORRECCION), 0) + 1 ")
        strSQL.Append("FROM SAB_ALM_CORRECCIONESALMACENES ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND ANIO = @ANIO ")

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("INSERT INTO SAB_ALM_CORRECCIONESALMACENES ")
        strSQL1.Append(" (IDALMACEN, ")
        strSQL1.Append(" ANIO, ")
        strSQL1.Append(" IDCORRECCION, ")
        strSQL1.Append(" MOTIVO, ")
        strSQL1.Append(" OBSERVACION, ")
        strSQL1.Append(" AUUSUARIOCREACION, ")
        strSQL1.Append(" AUFECHACREACION) ")
        strSQL1.Append(" VALUES ")
        strSQL1.Append(" (@IDALMACEN, ")
        strSQL1.Append(" @ANIO, ")
        strSQL1.Append(" @IDCORRECCION, ")
        strSQL1.Append(" @MOTIVO, ")
        strSQL1.Append(" @OBSERVACION, ")
        strSQL1.Append(" @AUUSUARIOCREACION, ")
        strSQL1.Append(" @AUFECHACREACION) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = eCA.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = eCA.ANIO
        args(2) = New SqlParameter("@IDCORRECCION", SqlDbType.Int)
        args(4) = New SqlParameter("@MOTIVO", SqlDbType.VarChar)
        args(4).Value = eCA.MOTIVO
        args(5) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(5).Value = IIf(eCA.OBSERVACION = Nothing, DBNull.Value, eCA.OBSERVACION)
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = eCA.AUUSUARIOCREACION
        args(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(7).Value = eCA.AUFECHACREACION

        Dim strSQL2 As New Text.StringBuilder
        strSQL2.Append("SELECT isnull(max(IDMOVIMIENTO), 0) + 1 ")
        strSQL2.Append("FROM SAB_ALM_MOVIMIENTOS ")
        strSQL2.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL2.Append("AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim strSQL3 As New Text.StringBuilder
        strSQL3.Append("INSERT INTO SAB_ALM_MOVIMIENTOS ")
        strSQL3.Append(" (IDESTABLECIMIENTO, ")
        strSQL3.Append(" IDTIPOTRANSACCION, ")
        strSQL3.Append(" IDMOVIMIENTO, ")
        strSQL3.Append(" IDALMACEN, ")
        strSQL3.Append(" ANIO, ")
        strSQL3.Append(" IDDOCUMENTO, ")
        strSQL3.Append(" IDESTADO, ")
        strSQL3.Append(" FECHAMOVIMIENTO, ")
        strSQL3.Append(" TOTALMOVIMIENTO, ")
        strSQL3.Append(" IDEMPLEADOALMACEN, ")
        strSQL3.Append(" CLASIFICACIONMOVIMIENTO, ")
        strSQL3.Append(" SUBCLASIFICACIONMOVIMIENTO, ")
        strSQL3.Append(" AUUSUARIOCREACION, ")
        strSQL3.Append(" AUFECHACREACION) ")
        strSQL3.Append(" SELECT ")
        strSQL3.Append(" @IDESTABLECIMIENTO, ")
        strSQL3.Append(" @IDTIPOTRANSACCION, ")
        strSQL3.Append(" @IDMOVIMIENTO, ")
        strSQL3.Append(" @IDALMACEN, ")
        strSQL3.Append(" @ANIO, ")
        strSQL3.Append(" @IDDOCUMENTO, ")
        strSQL3.Append(" @IDESTADO, ")
        strSQL3.Append(" @FECHAMOVIMIENTO, ")
        strSQL3.Append(" @TOTALMOVIMIENTO, ")
        strSQL3.Append(" @IDEMPLEADOALMACEN, ")
        strSQL3.Append(" @CLASIFICACIONMOVIMIENTO, ")
        strSQL3.Append(" @SUBCLASIFICACIONMOVIMIENTO, ")
        strSQL3.Append(" @AUUSUARIOCREACION, ")
        strSQL3.Append(" @AUFECHACREACION ")

        Dim args1(13) As SqlParameter
        args1(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args1(0).Value = eM.IDESTABLECIMIENTO
        args1(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args1(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args1(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args1(3).Value = eM.IDALMACEN
        args1(4) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args1(4).Value = eM.ANIO
        args1(5) = New SqlParameter("@IDDOCUMENTO", SqlDbType.Int)
        args1(6) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args1(6).Value = eM.IDESTADO
        args1(7) = New SqlParameter("@FECHAMOVIMIENTO", SqlDbType.DateTime)
        args1(7).Value = eM.FECHAMOVIMIENTO
        args1(8) = New SqlParameter("@TOTALMOVIMIENTO", SqlDbType.Decimal)
        args1(8).Value = eM.TOTALMOVIMIENTO
        args1(9) = New SqlParameter("@IDEMPLEADOALMACEN", SqlDbType.Int)
        args1(9).Value = eM.IDEMPLEADOALMACEN
        args1(10) = New SqlParameter("@CLASIFICACIONMOVIMIENTO", SqlDbType.TinyInt)
        args1(10).Value = eM.CLASIFICACIONMOVIMIENTO
        args1(11) = New SqlParameter("@SUBCLASIFICACIONMOVIMIENTO", SqlDbType.TinyInt)
        args1(11).Value = eM.SUBCLASIFICACIONMOVIMIENTO
        args1(12) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args1(12).Value = eM.AUUSUARIOCREACION
        args1(13) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args1(13).Value = eM.AUFECHACREACION

        Dim strSQL4 As New Text.StringBuilder
        strSQL4.Append("INSERT INTO SAB_ALM_DETALLEMOVIMIENTOS ")
        strSQL4.Append(" (IDESTABLECIMIENTO, ")
        strSQL4.Append(" IDTIPOTRANSACCION, ")
        strSQL4.Append(" IDMOVIMIENTO, ")
        strSQL4.Append(" IDDETALLEMOVIMIENTO, ")
        strSQL4.Append(" IDALMACEN, ")
        strSQL4.Append(" IDLOTE, ")
        strSQL4.Append(" IDPRODUCTO, ")
        strSQL4.Append(" CANTIDAD, ")
        strSQL4.Append(" CANTIDADANTERIOR, ")
        strSQL4.Append(" MONTO, ")
        strSQL4.Append(" AUUSUARIOCREACION, ")
        strSQL4.Append(" AUFECHACREACION) ")
        strSQL4.Append(" SELECT ")
        strSQL4.Append(" @IDESTABLECIMIENTO, ")
        strSQL4.Append(" @IDTIPOTRANSACCION, ")
        strSQL4.Append(" @IDMOVIMIENTO, ")
        strSQL4.Append(" (SELECT isnull(max(IDDETALLEMOVIMIENTO),0) + 1 FROM SAB_ALM_DETALLEMOVIMIENTOS WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDTIPOTRANSACCION = @IDTIPOTRANSACCION AND IDMOVIMIENTO = @IDMOVIMIENTO), ")
        strSQL4.Append(" @IDALMACEN, ")
        strSQL4.Append(" @IDLOTE, ")
        strSQL4.Append(" @IDPRODUCTO, ")
        strSQL4.Append(" @CANTIDAD, ")
        strSQL4.Append(" @CANTIDADANTERIOR, ")
        strSQL4.Append(" @MONTO, ")
        strSQL4.Append(" @AUUSUARIOCREACION, ")
        strSQL4.Append(" @AUFECHACREACION ")

        Dim args2(10) As SqlParameter
        args2(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args2(0).Value = eM.IDESTABLECIMIENTO
        args2(1) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args2(2) = New SqlParameter("@IDMOVIMIENTO", SqlDbType.BigInt)
        args2(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args2(3).Value = eM.IDALMACEN
        args2(4) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args2(5) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args2(6) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args2(7) = New SqlParameter("@CANTIDADANTERIOR", SqlDbType.Decimal)
        args2(8) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args2(9) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args2(9).Value = eM.AUUSUARIOCREACION
        args2(10) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args2(10).Value = eM.AUFECHACREACION

        Dim strSQL5, strSQL51, strSQL52, strSQL53, strSQL54 As New Text.StringBuilder
        strSQL5.Append("UPDATE SAB_ALM_LOTES ")
        strSQL5.Append("SET ")
        strSQL51.Append("CANTIDADDISPONIBLE = @CANTIDADDISPONIBLE, ")
        strSQL52.Append("CANTIDADNODISPONIBLE = @CANTIDADNODISPONIBLE, ")
        strSQL53.Append("CANTIDADVENCIDA = @CANTIDADVENCIDA, ")
        'strSQL5.Append(" CANTIDADRESERVADA = @CANTIDADRESERVADA, ")
        strSQL54.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL54.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL54.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL54.Append("AND IDLOTE = @IDLOTE ")

        Dim args3(7) As SqlParameter
        args3(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args3(0).Value = eL.IDALMACEN
        args3(1) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args3(1).Value = eL.IDLOTE
        args3(2) = New SqlParameter("@CANTIDADDISPONIBLE", SqlDbType.Decimal)
        args3(2).Value = eL.CANTIDADDISPONIBLE
        args3(3) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.Decimal)
        args3(3).Value = eL.CANTIDADNODISPONIBLE
        args3(4) = New SqlParameter("@CANTIDADVENCIDA", SqlDbType.Decimal)
        args3(4).Value = eL.CANTIDADVENCIDA
        args3(5) = New SqlParameter("@CANTIDADRESERVADA", SqlDbType.Decimal)
        args3(5).Value = eL.CANTIDADRESERVADA
        args3(6) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args3(6).Value = eL.AUUSUARIOMODIFICACION
        args3(7) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args3(7).Value = eL.AUFECHAMODIFICACION

        Dim strSQL6, strSQL61, strSQL62, strSQL63, strSQL64 As New Text.StringBuilder
        strSQL6.Append("UPDATE SAB_ALM_DETALLEINVENTARIO ")
        strSQL6.Append(" SET ")

        strSQL61.Append(" CANTIDADDISPONIBLECAPTURA = @CANTIDADDISPONIBLECAPTURA, ")
        strSQL61.Append(" CANTIDADDISPONIBLEDIFERENCIA = @CANTIDADDISPONIBLECAPTURA - CANTIDADDISPONIBLESISTEMA, ")

        strSQL62.Append(" CANTIDADNODISPONIBLECAPTURA = @CANTIDADNODISPONIBLECAPTURA, ")
        strSQL62.Append(" CANTIDADNODISPONIBLEDIFERENCIA = @CANTIDADNODISPONIBLECAPTURA - CANTIDADNODISPONIBLESISTEMA, ")

        strSQL63.Append(" CANTIDADVENCIDACAPTURA = @CANTIDADVENCIDACAPTURA, ")
        strSQL63.Append(" CANTIDADVENCIDADIFERENCIA = @CANTIDADVENCIDACAPTURA - CANTIDADVENCIDASISTEMA, ")

        strSQL64.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL64.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL64.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL64.Append(" AND IDINVENTARIO = @IDINVENTARIO ")
        strSQL64.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args4(8) As SqlParameter
        args4(1) = New SqlParameter("@CANTIDADDISPONIBLECAPTURA", SqlDbType.Decimal)
        args4(1).Value = eL.CANTIDADDISPONIBLE
        args4(2) = New SqlParameter("@CANTIDADNODISPONIBLECAPTURA", SqlDbType.Decimal)
        args4(2).Value = eL.CANTIDADNODISPONIBLE
        args4(3) = New SqlParameter("@CANTIDADVENCIDACAPTURA", SqlDbType.Decimal)
        args4(3).Value = eL.CANTIDADVENCIDA
        args4(4) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args4(4).Value = eDI.AUUSUARIOMODIFICACION
        args4(5) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args4(5).Value = eDI.AUFECHAMODIFICACION
        args4(6) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args4(6).Value = eDI.IDALMACEN
        args4(7) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args4(7).Value = eDI.IDINVENTARIO
        args4(8) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args4(8).Value = eDI.IDDETALLE

        Dim resultado As Integer

        Using c As New SqlConnection(Me.cnnStr)

            c.Open()

            Dim t As SqlTransaction = c.BeginTransaction()

            Try

                If eDMDisponible.CANTIDAD > 0 Then
                    args(2).Value = SqlHelper.ExecuteScalar(t, CommandType.Text, strSQL.ToString, args) 'IDCORRECCION
                    SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL1.ToString, args) 'CORRECCION

                    args1(1).Value = eDMDisponible.IDTIPOTRANSACCION
                    args1(2).Value = SqlHelper.ExecuteScalar(t, CommandType.Text, strSQL2.ToString, args1) 'IDMOVIMIENTO
                    args1(5).Value = args(2).Value '@IDDOCUMENTO
                    SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL3.ToString, args1) 'MOVIMIENTO

                    args2(1).Value = args1(1).Value 'IDTIPOTRANSACCION
                    args2(2).Value = args1(2).Value 'IDMOVIMIENTO
                    args2(4).Value = eDMDisponible.IDLOTE
                    args2(5).Value = eDMDisponible.IDPRODUCTO
                    args2(6).Value = eDMDisponible.CANTIDAD
                    args2(7).Value = eDMDisponible.CANTIDADANTERIOR
                    args2(8).Value = eDMDisponible.MONTO

                    SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL4.ToString, args2) 'DETALLEMOVIMIENTO

                    strSQL5.Append(strSQL51.ToString)
                    strSQL6.Append(strSQL61.ToString)

                End If

                If eDMNoDisponible.CANTIDAD > 0 Then
                    args(2).Value = SqlHelper.ExecuteScalar(t, CommandType.Text, strSQL.ToString, args) 'IDCORRECCION
                    SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL1.ToString, args) 'CORRECCION

                    args1(1).Value = eDMNoDisponible.IDTIPOTRANSACCION
                    args1(2).Value = SqlHelper.ExecuteScalar(t, CommandType.Text, strSQL2.ToString, args1) 'IDMOVIMIENTO
                    SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL3.ToString, args1) 'MOVIMIENTO

                    args2(1).Value = eDMNoDisponible.IDTIPOTRANSACCION
                    args2(4).Value = args1(2).Value
                    args2(4).Value = eDMNoDisponible.IDLOTE
                    args2(5).Value = eDMNoDisponible.IDPRODUCTO
                    args2(6).Value = eDMNoDisponible.CANTIDAD
                    args2(7).Value = eDMNoDisponible.MONTO

                    SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL4.ToString, args2) 'DETALLEMOVIMIENTO

                    strSQL5.Append(strSQL52.ToString)
                    strSQL6.Append(strSQL62.ToString)

                End If

                If eDMVencida.CANTIDAD > 0 Then
                    args(2).Value = SqlHelper.ExecuteScalar(t, CommandType.Text, strSQL.ToString, args) 'IDCORRECCION
                    SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL1.ToString, args) 'CORRECCION

                    args1(1).Value = eDMVencida.IDTIPOTRANSACCION
                    args1(2).Value = SqlHelper.ExecuteScalar(t, CommandType.Text, strSQL2.ToString, args1) 'IDMOVIMIENTO
                    SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL3.ToString, args1) 'MOVIMIENTO

                    args2(1).Value = eDMVencida.IDTIPOTRANSACCION
                    args2(4).Value = args1(2).Value
                    args2(4).Value = eDMVencida.IDLOTE
                    args2(5).Value = eDMVencida.IDPRODUCTO
                    args2(6).Value = eDMVencida.CANTIDAD
                    args2(7).Value = eDMVencida.MONTO

                    SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL4.ToString, args2) 'DETALLEMOVIMIENTO

                    strSQL5.Append(strSQL53.ToString)
                    strSQL6.Append(strSQL63.ToString)

                End If

                strSQL5.Append(strSQL54.ToString)
                SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL5.ToString, args3) 'LOTE

                strSQL6.Append(strSQL64.ToString)
                SqlHelper.ExecuteNonQuery(t, CommandType.Text, strSQL6.ToString, args4) 'DETALLEINVENTARIO

                t.Commit()

                resultado = 1

            Catch ex As Exception
                t.Rollback()
                Throw ex
            Finally
                If c.State = ConnectionState.Open Then c.Close()
            End Try

        End Using

        Return resultado

    End Function

#End Region

End Class
