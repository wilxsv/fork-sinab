Imports System.Text

Public Class dbINCUMPLIMIENTO
    Inherits dbBase

#Region "Funciones que no se utilizan"

    'Funcion que se encarga de Actualizar los datos de la Entidad
    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Return 0
    End Function

    'Funcion que se encarga de Insertar los datos de la Entidad
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer
        Return 0
    End Function

    'Funcion que se encarga de Eliminar los datos de la Entidad
    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer
        Return 0
    End Function

    'Funcion que se encarga de Recuperar los datos de la Entidad
    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer
        Return 0
    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String
        Return ""
    End Function

#End Region

    Public Sub obtenerEntregas(ByVal IDPROCESOCOMPRA As Array, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, _
                                              ByVal IDCONTRATO As Int64, ByVal IDPRODUCTO As Int64, ByVal IDALMACEN As Int32, _
                                              ByVal RENGLON As Int64, ByVal ENTREGA As Int16, ByRef dataEntrega As ArrayList, _
                                              ByRef dataCambio As ArrayList, ByRef posCambio As ArrayList)

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select ")
        strSQL.Append("c.idestablecimiento, c.idproveedor, c.idcontrato, ")
        strSQL.Append("c.fechadistribucion, pc.cantidad, pc.preciounitario, ec.entrega, ")
        strSQL.Append("ec.plazoentrega , ec.porcentajeentrega, pc.idproducto, ")
        strSQL.Append("dateadd(dd, ec.plazoentrega, c.fechadistribucion) as fechalimite, aec.idalmacenentrega, ")
        strSQL.Append("aec.cantidad, cp.desclargo as producto, a.nombre as almacen, p.nombre as proveedor, um.descripcion as unidadmedida, ")
        strSQL.Append("ec.renglon, c.numerocontrato, cp.corrproducto, ")
        strSQL.Append("( ")
        strSQL.Append("SELECT MAX(entrega) FROM SAB_UACI_ENTREGACONTRATO ec_1 WHERE ")
        strSQL.Append("pc.idestablecimiento = ec_1.idestablecimiento AND ")
        strSQL.Append("pc.idproveedor = ec_1.idproveedor AND ")
        strSQL.Append("pc.idcontrato = ec_1.idcontrato AND ")
        strSQL.Append("pc.renglon = ec_1.renglon ")
        strSQL.Append(") as totalEntregas ")
        strSQL.Append("from ")
        strSQL.Append("SAB_UACI_CONTRATOS c ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO pc ")
        strSQL.Append("ON c.idestablecimiento = pc.idestablecimiento AND ")
        strSQL.Append("c.idproveedor = pc.idproveedor AND ")
        strSQL.Append("c.idcontrato = pc.idcontrato ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO ec ")
        strSQL.Append("ON pc.idestablecimiento = ec.idestablecimiento AND ")
        strSQL.Append("pc.idproveedor = ec.idproveedor AND ")
        strSQL.Append("pc.idcontrato = ec.idcontrato AND ")
        strSQL.Append("pc.renglon = ec.renglon ")
        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS aec ")
        strSQL.Append("ON ec.idestablecimiento = aec.idestablecimiento AND ")
        strSQL.Append("ec.idproveedor = aec.idproveedor AND ")
        strSQL.Append("ec.idcontrato = aec.idcontrato AND ")
        strSQL.Append("ec.renglon = aec.renglon AND ")
        strSQL.Append("ec.iddetalle = aec.iddetalle ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA cpc ")
        strSQL.Append("ON c.idestablecimiento = cpc.idestablecimiento AND ")
        strSQL.Append("c.idcontrato = cpc.idcontrato AND ")
        strSQL.Append("c.idproveedor = cpc.idproveedor ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("ON pc.idproducto = cp.idproducto ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES a ")
        strSQL.Append("ON aec.idalmacenentrega = a.idalmacen ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES p ")
        strSQL.Append("ON c.idproveedor = p.idproveedor ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS um ")
        strSQL.Append("ON pc.idunidadmedida = um.idunidadmedida ")
        strSQL.Append("WHERE ")
        strSQL.Append("ec.ESTAHABILITADA = 1 AND ")
        strSQL.Append("c.idestadocontrato = 3 AND ") ' Contrato distribuido Join(ArrayList.Adapter(IDPROCESOCOMPRA).ToArray(), ",")
        strSQL.Append("cpc.idprocesocompra in (" & Join(ArrayList.Adapter(IDPROCESOCOMPRA).ToArray(), ",") & ") AND ")
        'strSQL.Append("cpc.idprocesocompra in (@IDPROCESOCOMPRA) AND ")
        strSQL.Append("c.idestablecimiento = @IDESTABLECIMIENTO ")

        'Filtros
        strSQL.Append("AND (c.idproveedor = @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")
        strSQL.Append("AND (c.idcontrato = @IDCONTRATO OR @IDCONTRATO = 0) ")
        strSQL.Append("AND (pc.idproducto = @IDPRODUCTO OR @IDPRODUCTO = 0) ")
        strSQL.Append("AND (a.idalmacen = @IDALMACEN OR @IDALMACEN = 0) ")
        strSQL.Append("AND (ec.renglon = @RENGLON OR @RENGLON = 0) ")
        strSQL.Append("AND (ec.entrega = @ENTREGA OR @ENTREGA = 0) ")

        'Orden requirido
        strSQL.Append("ORDER BY c.idestablecimiento, c.idproveedor, c.idcontrato, ec.renglon, ec.entrega, a.idalmacen ASC ")

        'Parametros
        Dim args(6) As SqlParameter
        'args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.VarChar)
        'args(0).Value = Join(ArrayList.Adapter(IDPROCESOCOMPRA).ToArray(), ",")
        'args(0).Value = IDPROCESOCOMPRA
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(3).Value = IDPRODUCTO
        args(4) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(4).Value = IDALMACEN
        args(5) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(5).Value = RENGLON
        args(6) = New SqlParameter("@ENTREGA", SqlDbType.Int)
        args(6).Value = ENTREGA

        Dim dr As SqlDataReader
        'Extrae los Proveedores
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim cont As Integer = 0
        Dim iniciado As Integer = 0
        Dim strTemp As String
        Dim strTemp2 As String

        Try

            If Not dr.HasRows Then Exit Sub

            posCambio.Add(0)

            Do While dr.Read()
                Dim CI As New INCUMPLIMIENTOS

                cont += 1

                CI.idEstablecimiento = dr.Item("idestablecimiento")
                CI.idProveedor = dr.Item("idproveedor")
                CI.idContrato = dr.Item("idcontrato")
                CI.fechaDistribucion = dr.Item("fechadistribucion")
                CI.cantidadTotal = dr.Item("cantidad")
                CI.precioUnitario = dr.Item("preciounitario")
                CI.numeroEntrega = dr.Item("entrega")
                CI.plazoEntrega = dr.Item("plazoentrega")
                CI.porcentajeEngrega = dr.Item("porcentajeentrega")
                CI.idProducto = dr.Item("idproducto")
                CI.fechaLimite = dr.Item("fechalimite")
                CI.idAlmacen = dr.Item("idalmacenentrega")
                CI.cantidadSolicitadaAlmacen = dr.Item("cantidad")
                CI.nombreProducto = dr.Item("producto")
                CI.nombreAlmacen = dr.Item("almacen")
                CI.nombreProveedor = dr.Item("proveedor")
                CI.unidadMedida = dr.Item("unidadmedida")
                CI.renglon = dr.Item("renglon")
                CI.numeroContrato = dr.Item("numerocontrato")
                CI.codigoProducto = dr.Item("corrproducto")
                CI.totalEntregas = dr.Item("totalEntregas")
                CI.cantidadEntregadaAlmacen = 0
                CI.cantidadAtrasoAlmacen = 0
                CI.tiempoAtraso = 0
                CI.identificador = cont

                'Dato para revision de posicion en matriz

                'Establecimiento|Proveedor|Contrato|Renglon
                strTemp2 = dr.Item("idestablecimiento") & "|" & dr.Item("idproveedor") & "|" & dr.Item("idcontrato") & "|" & dr.Item("renglon")
                'Establecimiento|Proveedor|Contrato|Renglon|Almacen
                strTemp = strTemp2 & "|" & dr.Item("idalmacenentrega")

                'Agregamos la informacion para reutilizarla despues
                dataEntrega.Add(CI)
                dataCambio.Add(strTemp)

                If iniciado <> 0 Then

                    Dim j As Integer
                    strTemp = CStr(dataCambio.Item(iniciado - 1))
                    j = strTemp.LastIndexOf("|")

                    'Definimos el punto de cambio, para hacer más facil las busquedas despues
                    If strTemp2 <> strTemp.Substring(0, j) Then
                        posCambio.Add(iniciado)
                    End If

                End If

                iniciado += 1

            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

    End Sub

    Public Function obtenerDatareaderRecibos(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, _
                                              ByVal IDCONTRATO As Int64, ByVal IDALMACEN As Int32, _
                                              ByVal RENGLON As Int64) As SqlDataReader

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select ")
        strSQL.Append("rr.idalmacen, m.fechamovimiento, l.codigo, dm.cantidad, l.idestablecimiento, l.idinformecontrolcalidad, dm.numerofactura, l.fechavencimiento, CONVERT(varchar, rr.NUMEROACTA) + '/' + CONVERT(varchar, rr.ANIO) AS NUMEROACTA ")
        strSQL.Append("from ")
        strSQL.Append("SAB_ALM_RECIBOSRECEPCION rr ")
        strSQL.Append("INNER JOIN SAB_ALM_MOVIMIENTOS m ")
        strSQL.Append("ON rr.idalmacen = m.idalmacen AND ")
        strSQL.Append("rr.idrecibo = m.iddocumento AND ")
        strSQL.Append("rr.anio = m.anio ")
        strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS dm ")
        strSQL.Append("ON m.idestablecimiento = dm.idestablecimiento AND ")
        strSQL.Append("m.idtipotransaccion = dm.idtipotransaccion AND ")
        strSQL.Append("m.idmovimiento = dm.idmovimiento ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_LOTES l ")
        strSQL.Append("ON dm.idalmacen = l.idalmacen AND ")
        strSQL.Append("dm.idlote = l.idlote ")
        strSQL.Append("where ")
        strSQL.Append("m.idtipotransaccion = 8 AND ") '8 es para las recepciones
        strSQL.Append("rr.idestablecimiento = @IDESTABLECIMIENTO AND ")
        strSQL.Append("rr.idproveedor = @IDPROVEEDOR AND ")
        strSQL.Append("rr.idcontrato = @IDCONTRATO AND ")
        strSQL.Append("rr.idalmacen = @IDALMACEN AND ")
        strSQL.Append("dm.renglon = @RENGLON ")
        strSQL.Append("order by m.fechamovimiento ASC")

        'Parametros
        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(3).Value = IDALMACEN
        args(4) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(4).Value = RENGLON

        Dim drDatos As SqlDataReader
        'Extrae los Proveedores
        drDatos = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Return drDatos

    End Function

    Public Sub obtenerControlCalidad(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, _
                                                ByVal IDCONTRATO As Int64, _
                                                ByVal RENGLON As Int64, ByVal LOTE As String, ByRef dataControlCalidad As ArrayList)

        Dim strSQL As New Text.StringBuilder

        strSQL.Append("select ")
        strSQL.Append("numeroinforme, ")
        strSQL.Append("fechasolicitudinspeccion, ")
        strSQL.Append("fechacertificacion, ")
        strSQL.Append("lote ")
        strSQL.Append("from ")
        strSQL.Append("SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("where ")
        strSQL.Append("idestablecimientocontrato = @IDESTABLECIMIENTO AND ")
        strSQL.Append("idproveedor = @IDPROVEEDOR AND ")
        strSQL.Append("idcontrato = @IDCONTRATO AND ")
        strSQL.Append("renglon = @RENGLON AND ")
        strSQL.Append("lote = @LOTE ")
        strSQL.Append("ORDER BY fechasolicitudinspeccion ASC ")

        'Parametros
        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = RENGLON
        args(4) = New SqlParameter("@LOTE", SqlDbType.VarChar)
        args(4).Value = LOTE

        Dim dr As SqlDataReader
        'Extrae los Proveedores
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Try
            Do While dr.Read()
                Dim CC As New CONTROLCALIDAD

                CC.numeroInforme = dr.Item("numeroinforme")
                CC.fechaSolicitudInspeccion = dr.Item("fechasolicitudinspeccion")
                CC.fechaCertificacion = dr.Item("fechacertificacion")
                CC.lote = dr.Item("lote")
                CC.cantidadentregadarecepcion = 0

                dataControlCalidad.Add(CC)

            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

    End Sub

End Class
