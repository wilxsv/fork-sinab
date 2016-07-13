Partial Public Class dbENTREGAADJUDICACION

#Region " Metodos Agregados "
    Public Function Agregar2(ByVal aEntidad As entidadBase, ByVal MOMENTO As Integer) As Integer

        Dim lEntidad As ENTREGAADJUDICACION
        lEntidad = aEntidad

        Dim strSQL As New Text.StringBuilder

        Select Case MOMENTO
            Case Is = 1
                strSQL.Append("INSERT INTO SAB_UACI_ENTREGARECOMENDACION ")
                strSQL.Append(" ( IDESTABLECIMIENTO, ")
                strSQL.Append(" IDPROCESOCOMPRA, ")
                strSQL.Append(" IDPROVEEDOR, ")
                strSQL.Append(" IDDETALLE, ")
                strSQL.Append(" IDENTREGA, ")
                strSQL.Append(" PORCENTAJE, ")
                strSQL.Append(" DIAS, ")
                strSQL.Append(" CANTIDAD, ")
                strSQL.Append(" IDFECHACONTEO, ")
                strSQL.Append(" AUUSUARIOCREACION, ")
                strSQL.Append(" AUFECHACREACION) ")
                strSQL.Append(" VALUES ")
                strSQL.Append(" ( @IDESTABLECIMIENTO, ")
                strSQL.Append(" @IDPROCESOCOMPRA, ")
                strSQL.Append(" @IDPROVEEDOR, ")
                strSQL.Append(" @IDDETALLE, ")
                strSQL.Append(" @IDENTREGA, ")
                strSQL.Append(" @PORCENTAJE, ")
                strSQL.Append(" @DIAS, ")
                strSQL.Append(" @CANTIDAD, ")
                strSQL.Append(" @IDFECHACONTEO, ")
                strSQL.Append(" @AUUSUARIOCREACION, ")
                strSQL.Append(" @AUFECHACREACION) ")
              
            Case Is = 2
                strSQL.Append("INSERT INTO SAB_UACI_ENTREGAADJUDICACION ")
                strSQL.Append(" ( IDESTABLECIMIENTO, ")
                strSQL.Append(" IDPROCESOCOMPRA, ")
                strSQL.Append(" IDPROVEEDOR, ")
                strSQL.Append(" IDDETALLE, ")
                strSQL.Append(" IDENTREGA, ")
                strSQL.Append(" PORCENTAJE, ")
                strSQL.Append(" DIAS, ")
                strSQL.Append(" CANTIDAD, ")
                strSQL.Append(" IDFECHACONTEO, ")
                strSQL.Append(" AUUSUARIOCREACION, ")
                strSQL.Append(" AUFECHACREACION, ")
                strSQL.Append(" AUUSUARIOMODIFICACION, ")
                strSQL.Append(" AUFECHAMODIFICACION, ")
                strSQL.Append(" ESTASINCRONIZADA) ")
                strSQL.Append(" VALUES ")
                strSQL.Append(" ( @IDESTABLECIMIENTO, ")
                strSQL.Append(" @IDPROCESOCOMPRA, ")
                strSQL.Append(" @IDPROVEEDOR, ")
                strSQL.Append(" @IDDETALLE, ")
                strSQL.Append(" @IDENTREGA, ")
                strSQL.Append(" @PORCENTAJE, ")
                strSQL.Append(" @DIAS, ")
                strSQL.Append(" @CANTIDAD, ")
                strSQL.Append(" @IDFECHACONTEO, ")
                strSQL.Append(" @AUUSUARIOCREACION, ")
                strSQL.Append(" @AUFECHACREACION, ")
                strSQL.Append(" @AUUSUARIOMODIFICACION, ")
                strSQL.Append(" @AUFECHAMODIFICACION, ")
                strSQL.Append(" @ESTASINCRONIZADA) ")
            Case Is = 3
                strSQL.Append("INSERT INTO SAB_UACI_ENTREGAADJUDICACIONFIRME ")
                strSQL.Append(" ( IDESTABLECIMIENTO, ")
                strSQL.Append(" IDPROCESOCOMPRA, ")
                strSQL.Append(" IDPROVEEDOR, ")
                strSQL.Append(" IDDETALLE, ")
                strSQL.Append(" IDENTREGA, ")
                strSQL.Append(" PORCENTAJE, ")
                strSQL.Append(" DIAS, ")
                strSQL.Append(" CANTIDAD, ")
                strSQL.Append(" IDFECHACONTEO, ")
                strSQL.Append(" AUUSUARIOCREACION, ")
                strSQL.Append(" AUFECHACREACION) ")
                
                strSQL.Append(" VALUES ")
                strSQL.Append(" ( @IDESTABLECIMIENTO, ")
                strSQL.Append(" @IDPROCESOCOMPRA, ")
                strSQL.Append(" @IDPROVEEDOR, ")
                strSQL.Append(" @IDDETALLE, ")
                strSQL.Append(" @IDENTREGA, ")
                strSQL.Append(" @PORCENTAJE, ")
                strSQL.Append(" @DIAS, ")
                strSQL.Append(" @CANTIDAD, ")
                strSQL.Append(" @IDFECHACONTEO, ")
                strSQL.Append(" @AUUSUARIOCREACION, ")
                strSQL.Append(" @AUFECHACREACION) ")
           

        End Select


        Dim args(13) As SqlParameter
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
        args(5) = New SqlParameter("@PORCENTAJE", SqlDbType.Decimal)
        args(5).Value = lEntidad.PORCENTAJE
        args(6) = New SqlParameter("@DIAS", SqlDbType.SmallInt)
        args(6).Value = lEntidad.DIAS
        args(7) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args(7).Value = lEntidad.CANTIDAD
        args(8) = New SqlParameter("@IDFECHACONTEO", SqlDbType.TinyInt)
        args(8).Value = lEntidad.IDFECHACONTEO
        args(9) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(10) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        If MOMENTO = 2 Then
            args(11) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
            args(11).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
            args(12) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
            args(12).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
            args(13) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
            args(13).Value = lEntidad.ESTASINCRONIZADA
        End If

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerID2(ByVal aEntidad As entidadBase, ByVal MOMENTO As Integer) As String

        Dim lEntidad As ENTREGAADJUDICACION
        lEntidad = aEntidad
        Dim strSQL As New Text.StringBuilder
        Select Case MOMENTO
            Case Is = 1
                strSQL.Append("SELECT isnull(max(IDENTREGA),0) + 1 ")
                strSQL.Append(" FROM SAB_UACI_ENTREGARECOMENDACION ")
                strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
                strSQL.Append(" AND IDDETALLE = @IDDETALLE ")
            Case Is = 2
                strSQL.Append("SELECT isnull(max(IDENTREGA),0) + 1 ")
                strSQL.Append(" FROM SAB_UACI_ENTREGAADJUDICACION ")
                strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
                strSQL.Append(" AND IDDETALLE = @IDDETALLE ")
            Case Is = 3
                strSQL.Append("SELECT isnull(max(IDENTREGA),0) + 1 ")
                strSQL.Append(" FROM SAB_UACI_ENTREGAADJUDICACIONFIRME ")
                strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
                strSQL.Append(" AND IDDETALLE = @IDDETALLE ")
        End Select



        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtiene las entregas ingresadas según lo indicado por el proveedor en su oferta, para un renglón dado.
    ''' En caso de que no se haya ingresado ninguna, devuelve las entregas solicitadas según el proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ENTREGAADJUDICACION</item>
    ''' <item>SAB_UACI_DETALLEENTREGASPROCESOCOMPRA</item>
    ''' <item>SAB_CAT_FECHACONTEOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerEntregasPorOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal RENGLON As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("IF NOT EXISTS ")
        strSQL.Append("    ( ")
        strSQL.Append("        SELECT ")
        strSQL.Append("            IDENTREGA ")
        strSQL.Append("        FROM SAB_UACI_ENTREGAADJUDICACION ")
        strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("        AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("        AND IDDETALLE = @IDDETALLE ")
        strSQL.Append("    ) ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    SELECT ")
        strSQL.Append("        DEPC.IDDETALLE ORDEN, ")
        strSQL.Append("        DEPC.DIAS, ")
        strSQL.Append("        DEPC.PORCENTAJE, ")
        strSQL.Append("        DEPC.IDFECHACONTEO ")
        strSQL.Append("    FROM SAB_UACI_DETALLEENTREGASPROCESOCOMPRA DEPC ")
        strSQL.Append("    INNER JOIN SAB_CAT_FECHACONTEOS FC ")
        strSQL.Append("    ON DEPC.IDFECHACONTEO = FC.IDFECHACONTEO ")
        strSQL.Append("    INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("    ON (DEPC.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
        strSQL.Append("    AND DEPC.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
        strSQL.Append("    AND DEPC.IDENTREGA = DPC.NUMEROENTREGAS) ")
        strSQL.Append("    WHERE ")
        strSQL.Append("    DEPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("    AND ")
        strSQL.Append("    DEPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("    AND ")
        strSQL.Append("    DPC.RENGLON = @RENGLON ")
        strSQL.Append("    ORDER BY ORDEN ")
        strSQL.Append("END ")
        strSQL.Append("ELSE ")
        strSQL.Append("BEGIN ")
        strSQL.Append("    SELECT ")
        strSQL.Append("        EPA.IDENTREGA ORDEN, ")
        strSQL.Append("        EPA.DIAS, ")
        strSQL.Append("        EPA.PORCENTAJE, ")
        strSQL.Append("        EPA.IDFECHACONTEO ")
        strSQL.Append("    FROM SAB_UACI_ENTREGAADJUDICACION EPA ")
        strSQL.Append("    INNER JOIN SAB_CAT_FECHACONTEOS FC ")
        strSQL.Append("    ON EPA.IDFECHACONTEO = FC.IDFECHACONTEO ")
        strSQL.Append("    WHERE ")
        strSQL.Append("    EPA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("    AND ")
        strSQL.Append("    EPA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("    AND ")
        strSQL.Append("    EPA.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("    AND ")
        strSQL.Append("    EPA.IDDETALLE = @IDDETALLE ")
        strSQL.Append("    ORDER BY ORDEN ")
        strSQL.Append("END ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Elimina los datos de entrega (porcentajes y plazos) para una oferta dada.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ENTREGAADJUDICACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    'Public Function EliminarEntregasPorOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As Integer

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("DELETE ")
    '    strSQL.Append("FROM SAB_UACI_ENTREGAADJUDICACION ")
    '    strSQL.Append("WHERE ")
    '    strSQL.Append("IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
    '    strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
    '    strSQL.Append("AND IDDETALLE = @IDDETALLE ")

    '    Dim args(4) As SqlParameter
    '    args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(0).Value = IDESTABLECIMIENTO
    '    args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
    '    args(1).Value = IDPROCESOCOMPRA
    '    args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
    '    args(2).Value = IDPROVEEDOR
    '    args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
    '    args(3).Value = IDDETALLE

    '    Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    'End Function



    Public Function EliminarEntregasPorOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal momento As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        Select Case momento
            Case Is = 1

                strSQL.Append("DELETE  SAB_UACI_ALMACENESENTREGAADJUDICACION ") 'SAB_UACI_ALMACENESENTREGARECOMENDACION ")
                strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
                strSQL.Append("AND IDDETALLE = @IDDETALLE ")

                strSQL.Append("DELETE SAB_UACI_ENTREGAADJUDICACION ") 'SAB_UACI_ENTREGARECOMENDACION ")
                strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
                strSQL.Append("AND IDDETALLE = @IDDETALLE ")
            Case Is = 2

                strSQL.Append("DELETE SAB_UACI_ALMACENESENTREGAADJUDICACION ")
                strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
                strSQL.Append("AND IDDETALLE = @IDDETALLE ")

                strSQL.Append("DELETE SAB_UACI_ENTREGAADJUDICACION ")
                strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
                strSQL.Append("AND IDDETALLE = @IDDETALLE ")
            Case Is = 3

                strSQL.Append("DELETE SAB_UACI_ALMACENESENTREGAADJUDICACIONFIRME ")
                strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
                strSQL.Append("AND IDDETALLE = @IDDETALLE ")

                strSQL.Append("DELETE SAB_UACI_ENTREGAADJUDICACIONFIRME ")
                strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
                strSQL.Append("AND IDDETALLE = @IDDETALLE ")
        End Select


        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function



    ''' <summary>
    ''' Guarda en las tablas correspondientes los valores calculados para cada entrega de un proveedor, para un renglón dado.
    ''' </summary>
    ''' <param name="aLista">Lista de entidades ENTREGAADJUDICACION, donde se indican las cantidades, porcentajes y plazos.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function AgregarEntregasPorOferta(ByVal aLista As listaENTREGAADJUDICACION, ByVal MOMENTO As Integer) As Integer

        Dim lEntidad As ENTREGAADJUDICACION
        For Each lEntidad In aLista
            Dim ID As Integer = Me.ObtenerID2(lEntidad, MOMENTO)
            lEntidad.IDENTREGA = ID
            Agregar2(lEntidad, MOMENTO)
        Next

        Return 1

    End Function

    ''' <summary>
    ''' Elimina todas las entregas registradas para las distintas ofertas recomendadas/adjudicadas para un renglón dado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>Integer</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ENTREGAADJUDICACION</item>
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarEntregasPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE ")
        strSQL.Append("FROM SAB_UACI_ENTREGAADJUDICACION ")
        strSQL.Append("FROM SAB_UACI_ENTREGAADJUDICACION EPA ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (EPA.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND EPA.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND EPA.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND EPA.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerEntregasProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_ENTREGAADJUDICACION.IDENTREGA, SAB_UACI_ENTREGAADJUDICACION.PORCENTAJE, SAB_UACI_ENTREGAADJUDICACION.DIAS, SAB_UACI_ENTREGAADJUDICACION.IDDETALLE, SAB_UACI_ENTREGAADJUDICACION.CANTIDAD ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_ENTREGAADJUDICACION ON ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_ENTREGAADJUDICACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_ENTREGAADJUDICACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_ENTREGAADJUDICACION.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_ENTREGAADJUDICACION.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (SAB_UACI_DETALLEOFERTA.RENGLON = " & RENGLON & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function obtenerEntregasProveedor1(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_ENTREGARECOMENDACION.IDENTREGA, SAB_UACI_ENTREGARECOMENDACION.PORCENTAJE, SAB_UACI_ENTREGARECOMENDACION.DIAS, SAB_UACI_ENTREGARECOMENDACION.IDDETALLE, SAB_UACI_ENTREGARECOMENDACION.CANTIDAD ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_ENTREGARECOMENDACION ON ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_ENTREGARECOMENDACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_ENTREGARECOMENDACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_ENTREGARECOMENDACION.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_ENTREGARECOMENDACION.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (SAB_UACI_DETALLEOFERTA.RENGLON = " & RENGLON & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function obtenerEntregasProveedor3(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_ENTREGAADJUDICACIONFIRME.IDENTREGA, SAB_UACI_ENTREGAADJUDICACIONFIRME.PORCENTAJE, SAB_UACI_ENTREGAADJUDICACIONFIRME.DIAS, SAB_UACI_ENTREGAADJUDICACIONFIRME.IDDETALLE, SAB_UACI_ENTREGAADJUDICACION.CANTIDAD ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_ENTREGAADJUDICACIONFIRME ON ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_ENTREGAADJUDICACIONFIRME.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_ENTREGAADJUDICACIONFIRME.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_ENTREGAADJUDICACIONFIRME.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_ENTREGAADJUDICACIONFIRME.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND ")
        strSQL.Append(" (SAB_UACI_DETALLEOFERTA.IDPROVEEDOR = " & IDPROVEEDOR & ") AND (SAB_UACI_DETALLEOFERTA.RENGLON = " & RENGLON & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function obtenerNumntregasProveedor2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As ArrayList

        Dim strSQL As New Text.StringBuilder
        Dim arr As New ArrayList

        strSQL.Append(" SELECT ")
        strSQL.Append("    EA.PORCENTAJE, EA.DIAS ")
        strSQL.Append("  FROM ")
        strSQL.Append("    SAB_UACI_ENTREGAADJUDICACION EA ")
        strSQL.Append("      INNER JOIN SAB_UACI_DETALLEOFERTA DO ON ")
        strSQL.Append("        EA.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA AND ")
        strSQL.Append("        EA.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO AND ")
        strSQL.Append("        EA.IDPROVEEDOR = DO.IDPROVEEDOR AND ")
        strSQL.Append("        EA.IDDETALLE = DO.IDDETALLE ")
        strSQL.Append("  WHERE ")
        strSQL.Append("    DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("    DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA  AND ")
        strSQL.Append("    DO.IDPROVEEDOR = @IDPROVEEDOR AND ")
        strSQL.Append("    DO.RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON

        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Do While dr.Read
            Dim s(1) As String
            s(0) = dr.Item(0) 'Entrega 
            s(1) = dr.Item(1) 'Renglon
            arr.Add(s)
        Loop

        dr.Close()

        Return arr

    End Function

    Public Function obtenerNumntregasProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDPROCESOCOMPRA, IDPROVEEDOR, IDENTREGA AS ENTREGAS ")
        strSQL.Append(" FROM SAB_UACI_ENTREGAADJUDICACION ")
        strSQL.Append(" GROUP BY IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDENTREGA ")
        strSQL.Append(" HAVING (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerRenglosAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, SAB_UACI_ADJUDICACION.CANTIDADFIRME, SAB_UACI_ADJUDICACION.IDDETALLE ")
        strSQL.Append(" FROM SAB_UACI_ENTREGAADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_ADJUDICACION ON SAB_UACI_ENTREGAADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ENTREGAADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ENTREGAADJUDICACION.IDPROVEEDOR = SAB_UACI_ADJUDICACION.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ENTREGAADJUDICACION.IDDETALLE = SAB_UACI_ADJUDICACION.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA ON SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_UACI_DETALLEOFERTA.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.IDDETALLE = SAB_UACI_DETALLEOFERTA.IDDETALLE INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA ON ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDESTABLECIMIENTO = SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.IDPROCESOCOMPRA = SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA AND ")
        strSQL.Append(" SAB_UACI_DETALLEOFERTA.RENGLON = SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS ON ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO ")
        strSQL.Append(" WHERE (SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (SAB_UACI_ADJUDICACION.IDPROVEEDOR = " & IDPROVEEDOR & ") ")
        strSQL.Append(" GROUP BY SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, ")
        strSQL.Append(" SAB_UACI_ADJUDICACION.CANTIDADFIRME, SAB_UACI_ADJUDICACION.IDDETALLE ")
        strSQL.Append(" HAVING (SAB_UACI_ADJUDICACION.CANTIDADFIRME > 0) ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerEntregasProveedor2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As ArrayList

        Dim strSQL As New Text.StringBuilder
        Dim arr As New ArrayList

        strSQL.Append(" SELECT ")
        strSQL.Append("    count(renglon) as entregas, DO.RENGLON ")
        strSQL.Append("  FROM ")
        strSQL.Append("    SAB_UACI_ENTREGAADJUDICACION EA ")
        strSQL.Append(" 	 INNER JOIN SAB_UACI_DETALLEOFERTA DO ON ")
        strSQL.Append(" 	   EA.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA AND ")
        strSQL.Append(" 	   EA.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO AND ")
        strSQL.Append(" 	   EA.IDPROVEEDOR = DO.IDPROVEEDOR AND ")
        strSQL.Append(" 	   EA.IDDETALLE = DO.IDDETALLE ")
        strSQL.Append(" WHERE ")
        strSQL.Append("    DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("    DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA  AND ")
        strSQL.Append("    DO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" GROUP BY ")
        strSQL.Append("   EA.PORCENTAJE, DO.RENGLON ")
        strSQL.Append(" ORDER BY count(renglon), DO.RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Do While dr.Read
            Dim s(1) As String
            s(0) = dr.Item(0) 'Entrega 
            s(1) = dr.Item(1) 'Renglon
            arr.Add(s)
        Loop

        dr.Close()

        Return arr

    End Function
#End Region

End Class
