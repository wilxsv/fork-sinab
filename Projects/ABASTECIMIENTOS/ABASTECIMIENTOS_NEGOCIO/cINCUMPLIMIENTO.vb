Public Class cINCUMPLIMIENTO
    Inherits controladorBase

#Region "Propiedades get y set"

    Private _idEstablecimiento As Int32
    Public Property idEstablecimiento() As Int32
        Get
            Return _idEstablecimiento
        End Get
        Set(ByVal value As Int32)
            _idEstablecimiento = value
        End Set
    End Property

    Private _idProveedor As Int32
    Public Property idProveedor() As Int32
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As Int32)
            _idProveedor = value
        End Set
    End Property

    Private _idContrato As Int64
    Public Property idContrato() As Int64
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Int64)
            _idContrato = value
        End Set
    End Property

    Private _idProducto As Int32
    Public Property idProducto() As Int32
        Get
            Return _idProducto
        End Get
        Set(ByVal value As Int32)
            _idProducto = value
        End Set
    End Property

    Private _idAlmacen As Int32
    Public Property idAlmacen() As Int32
        Get
            Return _idAlmacen
        End Get
        Set(ByVal value As Int32)
            _idAlmacen = value
        End Set
    End Property

    Private _idProcesoCompra As Array
    Public Property idProcesoCompra() As Array
        Get
            Return _idProcesoCompra
        End Get
        Set(ByVal value As Array)
            _idProcesoCompra = value
        End Set
    End Property

    Private _renglon As Int64
    Public Property renglon() As Int64
        Get
            Return _renglon
        End Get
        Set(ByVal value As Int64)
            _renglon = value
        End Set
    End Property

    Private _entrega As Int64
    Public Property entrega() As Int16
        Get
            Return _entrega
        End Get
        Set(ByVal value As Int16)
            _entrega = value
        End Set
    End Property

#End Region

    Dim T As New DataTable
    Public Function obtenerDatasetIncumplimientos() As DataSet

        Dim data_entrega As New ArrayList
        Dim data_cambio As New ArrayList
        Dim pos_cambio As New ArrayList

        Dim data_lotes As New ArrayList

        Dim i As Integer
        Dim j As Integer

        Dim strTemp As String
        Dim strTemp2 As String

        Dim en As IEnumerator

        Dim idx_inicio As Integer
        Dim idx_final As Integer

        Dim iniciado As Integer = 0

        Dim ds As New DataSet

        Dim tbl As New DataTable("incumplimientos")
        Dim tbl2 As New DataTable("lotes")

        construirTablaIncumplimientos(tbl)
        construirTablaControlCalidad(tbl2)

        'Se verifica si se pasa un proceso de compra o no. Es la base para todo el calculo
        If _idProcesoCompra.Length = 0 And _idEstablecimiento = 0 Then

            ds.Tables.Add(tbl)
            ds.Tables.Add(tbl2)

            ds.Relations.Add("ids", _
                            ds.Tables("incumplimientos").Columns("id"), _
                            ds.Tables("lotes").Columns("id"))

            Return ds
            Exit Function
        End If

        'Se obtienen los datos para trabajar
        Dim dbInc As New dbINCUMPLIMIENTO

        dbInc.obtenerEntregas(_idProcesoCompra, _idEstablecimiento, _idProveedor, _idContrato, _idProducto, _idAlmacen, _
                              _renglon, _entrega, data_entrega, data_cambio, pos_cambio)

        'Salimos de no haber datos de entrega
        If pos_cambio.Count = 0 Then
            ds.Tables.Add(tbl)
            ds.Tables.Add(tbl2)

            ds.Relations.Add("ids", _
                            ds.Tables("incumplimientos").Columns("id"), _
                            ds.Tables("lotes").Columns("id"))

            Return ds
        End If

        en = pos_cambio.GetEnumerator

        'El unico dato que nos interesa es la cantidad de cambios en los productos en estos momentos
        'Lo recorremos para obtener datos que queremos con otro query

        While en.MoveNext
            Dim TotalRecibo As Double = 0
            j = CInt(en.Current)
            strTemp = data_cambio.Item(j)

            'Declaramos el array que va a contener los datos
            Dim arrTemp() As String

            'Establecimiento|Proveedor|Contrato|Renglon|Almacen
            arrTemp = strTemp.Split("|")

            'Control de calidad ****************************************************************************
            '
            'Control de calidad ****************************************************************************

            'Su nombre las explica
            Dim cantidad_residuo As Double
            Dim fecha_residuo As Date

            Dim cantidad_trabajo As Double
            Dim fecha_trabajo As Date

            Dim lotes_tmp As New ArrayList

            'Recepcion de productos
            Dim rs As SqlClient.SqlDataReader = dbInc.obtenerDatareaderRecibos(arrTemp(0), arrTemp(1), arrTemp(2), arrTemp(4), arrTemp(3))

            'No pasa mucho si no devuelve datos
            Do While rs.Read
                strTemp2 = arrTemp(0) & "|" & arrTemp(1) & "|" & arrTemp(2) & "|" & arrTemp(3) & "|" & rs.Item(0)
                'Se busca la posicion de inicio
                idx_inicio = data_cambio.IndexOf(strTemp2)
                'Se busca la posicion final
                idx_final = data_cambio.LastIndexOf(strTemp2)

                Dim CI As INCUMPLIMIENTOS
                Dim cant_diferencia As Double

                iniciado = False

                'Reseteamos todo
                cantidad_residuo = 0.0

                Dim arrControlCalidad As New ArrayList
                'En teoria solo debe obtener 1 dato de control de calidad, no mas.
                'Aun asi hay que proratear
                dbInc.obtenerControlCalidad(arrTemp(0), arrTemp(1), arrTemp(2), arrTemp(3), rs.Item("codigo"), arrControlCalidad)

                'Se procede a trabajar y llenar todas las cosas necesarias
                For i = idx_inicio To idx_final

                    CI = data_entrega(i)
                    Dim tiempo_muerto As Integer = 0

                    '#Comentario de control de calidad

                    If iniciado And cantidad_residuo = 0.0 Then Exit For 'No hay residuos para trabajar

                    'Se verifica si se ha hecho full entrega
                    If CI.cantidadSolicitadaAlmacen <> CI.cantidadEntregadaAlmacen Then

                        'Variable para el control de calidad, solo las principales
                        'Datos principales
                        Dim ccx As New CONTROLCALIDAD
                        ccx.fechaRecepcion = rs.Item("fechamovimiento")
                        ccx.fechaVencimiento = rs.Item("fechavencimiento")
                        ccx.factura = rs.Item("numerofactura")
                        ccx.lote = rs.Item("codigo")
                        ccx.contador = CI.identificador
                        ccx.acta = rs.Item("NUMEROACTA")

                        If arrControlCalidad.Count <> 0 Then
                            Dim cctmp As New CONTROLCALIDAD
                            cctmp = arrControlCalidad(0)
                            ccx.fechaCertificacion = cctmp.fechaCertificacion
                            ccx.fechaSolicitudInspeccion = cctmp.fechaSolicitudInspeccion
                            ccx.numeroInforme = cctmp.numeroInforme
                        End If

                        cant_diferencia = CI.cantidadSolicitadaAlmacen - CI.cantidadEntregadaAlmacen

                        If Not iniciado Then
                            cantidad_trabajo = rs.Item(3) 'Cantidad entregada en el almacen en ese momento
                        Else
                            cantidad_trabajo = cantidad_residuo
                        End If

                        Select Case cant_diferencia - cantidad_trabajo
                            'verificacion segun resultado

                            Case Is < 0 'Caso complicado

                                If Not iniciado Then
                                    fecha_trabajo = rs.Item(1)
                                    cantidad_residuo = rs.Item(3) - cant_diferencia
                                    fecha_residuo = rs.Item(1)
                                    CI.cantidadEntregadaAlmacen = cant_diferencia
                                Else
                                    fecha_trabajo = fecha_residuo
                                    cantidad_residuo = cantidad_residuo - cant_diferencia
                                    CI.cantidadEntregadaAlmacen = CI.cantidadEntregadaAlmacen + cant_diferencia
                                End If

                                'Control de residuos

                                'Existe retraso
                                If fecha_trabajo > DateAdd(DateInterval.Day, tiempo_muerto, CI.fechaLimite) Then
                                    CI.cantidadAtrasoAlmacen = CI.cantidadAtrasoAlmacen + cant_diferencia 'Cantidad en retraso
                                    CI.tiempoAtraso = Math.Abs(DateDiff(DateInterval.Day, fecha_trabajo, CI.fechaLimite))
                                End If

                            Case Is > 0 'Caso medio

                                CI.cantidadEntregadaAlmacen = CI.cantidadEntregadaAlmacen + cantidad_trabajo

                                If Not iniciado Then
                                    fecha_trabajo = rs.Item(1)
                                Else
                                    fecha_trabajo = fecha_residuo
                                    cantidad_residuo = 0.0
                                End If

                                'Existe retraso
                                If fecha_trabajo > DateAdd(DateInterval.Day, tiempo_muerto, CI.fechaLimite) Then
                                    CI.cantidadAtrasoAlmacen = CI.cantidadAtrasoAlmacen + cantidad_trabajo 'Cantidad en retraso
                                    CI.tiempoAtraso = Math.Abs(DateDiff(DateInterval.Day, fecha_trabajo, CI.fechaLimite))
                                End If

                            Case Else 'Caso mas facil, no nos preocupamos por los residuos

                                If Not iniciado Then
                                    fecha_trabajo = rs.Item(1) 'rs(1) es la fecha de recepcion
                                Else
                                    fecha_trabajo = fecha_residuo
                                End If

                                'Existe retraso, ya sea por control de calidad o no
                                If fecha_trabajo > DateAdd(DateInterval.Day, tiempo_muerto, CI.fechaLimite) Then
                                    CI.cantidadEntregadaAlmacen = CI.cantidadEntregadaAlmacen + cantidad_trabajo
                                    CI.cantidadAtrasoAlmacen = cantidad_trabajo 'Cantidad en retraso
                                    CI.tiempoAtraso = Math.Abs(DateDiff(DateInterval.Day, fecha_trabajo, CI.fechaLimite))
                                Else
                                    'No existe retraso
                                    CI.cantidadEntregadaAlmacen = CI.cantidadEntregadaAlmacen + cantidad_trabajo
                                End If

                        End Select
                        ccx.cantidadentregadarecepcion = CI.cantidadEntregadaAlmacen
                        ccx.cantidad = cantidad_trabajo
                        data_lotes.Add(ccx)

                        'Actualizacion de datos
                        data_entrega(i) = CI

                        iniciado = True

                    End If

                Next

            Loop

            rs.Close()

        End While

        'Variables para el dataset a crear

        Dim dr As DataRow

        en = data_entrega.GetEnumerator

        Dim CII As INCUMPLIMIENTOS
        Dim CCI As CONTROLCALIDAD

        While en.MoveNext
            CII = en.Current

            dr = tbl.NewRow

            'Pequeño fix para los dias de atraso
            If CII.cantidadSolicitadaAlmacen <> CII.cantidadEntregadaAlmacen And CII.fechaLimite < Today Then
                CII.tiempoAtraso = Math.Abs(DateDiff(DateInterval.Day, CII.fechaLimite, Today))
            End If

            dr(0) = CII.idEstablecimiento
            dr(1) = CII.idProveedor
            dr(2) = CII.idContrato
            dr(3) = CII.fechaDistribucion
            dr(4) = CII.cantidadTotal
            dr(5) = CII.precioUnitario
            dr(6) = CII.numeroEntrega
            dr(7) = CII.plazoEntrega
            dr(8) = CII.porcentajeEngrega
            dr(9) = CII.idProducto
            dr(10) = CII.fechaLimite
            dr(11) = CII.idAlmacen
            dr(12) = CII.cantidadSolicitadaAlmacen
            dr(13) = CII.nombreProducto
            dr(14) = CII.nombreAlmacen
            dr(15) = CII.nombreProveedor
            dr(16) = CII.unidadMedida
            dr(17) = CII.renglon
            dr(18) = CII.numeroContrato
            dr(19) = CII.codigoProducto
            dr(20) = CII.cantidadEntregadaAlmacen
            dr(21) = CII.cantidadAtrasoAlmacen
            dr(22) = CII.tiempoAtraso
            dr(23) = CII.totalEntregas
            dr(24) = CII.identificador
            tbl.Rows.Add(dr)

        End While

        'Vamos con los lotes
        en = data_lotes.GetEnumerator

        While en.MoveNext
            CCI = en.Current

            dr = tbl2.NewRow

            dr(0) = CCI.numeroInforme
            dr(1) = CCI.fechaSolicitudInspeccion
            dr(2) = CCI.fechaCertificacion
            dr(3) = CCI.lote
            dr(4) = CCI.factura
            dr(5) = CCI.fechaRecepcion
            dr(6) = CCI.cantidad
            dr(7) = CCI.contador
            dr(8) = CCI.cantidadentregadarecepcion
            dr(9) = CCI.fechaVencimiento
            dr(10) = CCI.acta

            tbl2.Rows.Add(dr)

        End While

        ds.Tables.Add(tbl)
        ds.Tables.Add(tbl2)

        ds.Relations.Add("ids", _
                        ds.Tables("incumplimientos").Columns("id"), _
                        ds.Tables("lotes").Columns("id"))

        'Return ds

        Dim dr1 As DataRow = tbl.NewRow
        Dim dr2 As DataRow = tbl2.NewRow
        construirTablaGlobal()

        For Each dr1 In tbl.Rows
            For Each dr2 In tbl2.Rows
                If dr1(24) = dr2(7) Then
                    Dim tr As DataRow = T.NewRow
                    For i = 0 To 33
                        If i <= 24 Then
                            tr(i) = dr1(i)
                        Else
                            tr(i) = dr2(i - 25)
                        End If
                    Next
                    tr(32) = CalculoTiempoMuerto(tr(30), tr(26), tr(27), tr(10))
                    tr(33) = dr2(8)
                    tr(34) = dr2(9)
                    tr(35) = dr2(10)
                    T.Rows.Add(tr)
                End If
            Next
        Next
        ds.Tables.Add(T)
        ds.Tables(2).TableName = "Global"

        Return ds

    End Function

    Private Function CalculoTiempoMuerto(ByVal recepcion As DateTime, ByVal solicitud As DateTime, ByVal notificacion As DateTime, ByVal entrega As DateTime) As Integer

        If solicitud.Year > 1900 And notificacion.Year > 1900 Then
            If DateTime.Compare(entrega, recepcion) = -1 Then ' > recepcion Then
                If DateTime.Compare(solicitud, recepcion) = 1 Then 'solicitud > recepcion Then
                    Return 0
                ElseIf DateTime.Compare(solicitud, recepcion) <= 0 And DateTime.Compare(notificacion, recepcion) = 1 Then 'solicitud <= recepcion And notificacion > recepcion Then
                    Return Math.Abs(CInt(DateDiff(DateInterval.Day, recepcion, solicitud)))
                ElseIf DateTime.Compare(solicitud, recepcion) <= 0 And DateTime.Compare(notificacion, recepcion) <= 0 Then 'solicitud <= recepcion And notificacion <= recepcion Then
                    Return Math.Abs(CInt(DateDiff(DateInterval.Day, notificacion, solicitud)))
                End If
            Else
                Return 0
            End If
        Else
            Return 0
        End If

    End Function

    Private Sub construirTablaIncumplimientos(ByRef tbl As DataTable)

        Dim col As New DataColumn
        'Ahora se crea el dataset y se termina todo
        '0 establecimiento
        col = New DataColumn("establecimiento", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '1 proveedor
        col = New DataColumn("idproveedor", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '2 contrato
        col = New DataColumn("contrato", System.Type.GetType("System.Int64"))
        tbl.Columns.Add(col)
        '3 fecha dist
        col = New DataColumn("fechadistribucion", System.Type.GetType("System.DateTime"))
        tbl.Columns.Add(col)
        '4 cantidad total de producto
        col = New DataColumn("cantidadtotal", System.Type.GetType("System.Double"))
        tbl.Columns.Add(col)
        '5 precio unitario
        col = New DataColumn("preciounitario", System.Type.GetType("System.Decimal"))
        tbl.Columns.Add(col)
        '6 entrega
        col = New DataColumn("numeroentrega", System.Type.GetType("System.Int16"))
        tbl.Columns.Add(col)
        '7 plazo entrega
        col = New DataColumn("plazoentrega", System.Type.GetType("System.Int16"))
        tbl.Columns.Add(col)
        '8 % entrega
        col = New DataColumn("porcentajeentrega", System.Type.GetType("System.Decimal"))
        tbl.Columns.Add(col)
        '9 producto
        col = New DataColumn("idproducto", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '10 fecha limite
        col = New DataColumn("fechalimite", System.Type.GetType("System.DateTime"))
        tbl.Columns.Add(col)
        '11 almacen
        col = New DataColumn("idalmacen", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '12 cantidad almacen
        col = New DataColumn("cantidadalmacen", System.Type.GetType("System.Double"))
        tbl.Columns.Add(col)
        '13 producto (nombre)
        col = New DataColumn("producto", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '14 almacen (nombre)
        col = New DataColumn("almacen", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '15 proveedor (nombre)
        col = New DataColumn("proveedor", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '16 unidad de medida
        col = New DataColumn("unidadmedida", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '17 renglon
        col = New DataColumn("renglon", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '18 numero contrato
        col = New DataColumn("numerocontrato", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '19 codigo producto
        col = New DataColumn("codigoproducto", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        '20 cantidad entregada del producto
        col = New DataColumn("cantidadentregadaalmacen", System.Type.GetType("System.Double"))
        tbl.Columns.Add(col)
        '21 cantidad entregada con atraso
        col = New DataColumn("cantidadatrasoalmacen", System.Type.GetType("System.Double"))
        tbl.Columns.Add(col)
        '22 tiempo atraso
        col = New DataColumn("tiempoatraso", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '23 total de entregas
        col = New DataColumn("totalEntregas", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        '24 id del dataset
        col = New DataColumn("id", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)

    End Sub

    Private Sub construirTablaControlCalidad(ByRef tbl As DataTable)

        Dim col As DataColumn

        col = New DataColumn("numerocontrolcalidad", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        col = New DataColumn("fechasolicitudinspeccion", System.Type.GetType("System.DateTime"))
        tbl.Columns.Add(col)
        col = New DataColumn("fechacertificacion", System.Type.GetType("System.DateTime"))
        tbl.Columns.Add(col)
        col = New DataColumn("lote", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        col = New DataColumn("factura", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)
        col = New DataColumn("fecharecepcion", System.Type.GetType("System.DateTime"))
        tbl.Columns.Add(col)
        col = New DataColumn("cantidad", System.Type.GetType("System.Double"))
        tbl.Columns.Add(col)
        col = New DataColumn("id", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)
        'CANTIDADENTREGADARECEPCION
        col = New DataColumn("cantidadentregadarecepcion", System.Type.GetType("System.Double"))
        tbl.Columns.Add(col)
        col = New DataColumn("fechavencimiento", System.Type.GetType("System.DateTime"))
        tbl.Columns.Add(col)
        col = New DataColumn("acta", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)

    End Sub

    Private Sub construirTablaGlobal()

        Dim col As New DataColumn
        'Ahora se crea el dataset y se termina todo
        '0 establecimiento
        col = New DataColumn("establecimiento", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '1 proveedor
        col = New DataColumn("idproveedor", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '2 contrato
        col = New DataColumn("contrato", System.Type.GetType("System.Int64"))
        T.Columns.Add(col)
        '3 fecha dist
        col = New DataColumn("fechadistribucion", System.Type.GetType("System.DateTime"))
        T.Columns.Add(col)
        '4 cantidad total de producto
        col = New DataColumn("cantidadtotal", System.Type.GetType("System.Double"))
        T.Columns.Add(col)
        '5 precio unitario
        col = New DataColumn("preciounitario", System.Type.GetType("System.Decimal"))
        T.Columns.Add(col)
        '6 entrega
        col = New DataColumn("numeroentrega", System.Type.GetType("System.Int16"))
        T.Columns.Add(col)
        '7 plazo entrega
        col = New DataColumn("plazoentrega", System.Type.GetType("System.Int16"))
        T.Columns.Add(col)
        '8 % entrega
        col = New DataColumn("porcentajeentrega", System.Type.GetType("System.Decimal"))
        T.Columns.Add(col)
        '9 producto
        col = New DataColumn("idproducto", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '10 fecha limite
        col = New DataColumn("fechalimite", System.Type.GetType("System.DateTime"))
        T.Columns.Add(col)
        '11 almacen
        col = New DataColumn("idalmacen", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '12 cantidad almacen
        col = New DataColumn("cantidadalmacen", System.Type.GetType("System.Double"))
        T.Columns.Add(col)
        '13 producto (nombre)
        col = New DataColumn("producto", System.Type.GetType("System.String"))
        T.Columns.Add(col)
        '14 almacen (nombre)
        col = New DataColumn("almacen", System.Type.GetType("System.String"))
        T.Columns.Add(col)
        '15 proveedor (nombre)
        col = New DataColumn("proveedor", System.Type.GetType("System.String"))
        T.Columns.Add(col)
        '16 unidad de medida
        col = New DataColumn("unidadmedida", System.Type.GetType("System.String"))
        T.Columns.Add(col)
        '17 renglon
        col = New DataColumn("renglon", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '18 numero contrato
        col = New DataColumn("numerocontrato", System.Type.GetType("System.String"))
        T.Columns.Add(col)
        '19 codigo producto
        col = New DataColumn("codigoproducto", System.Type.GetType("System.String"))
        T.Columns.Add(col)
        '20 cantidad entregada del producto
        col = New DataColumn("cantidadentregadaalmacen", System.Type.GetType("System.Double"))
        T.Columns.Add(col)
        '21 cantidad entregada con atraso
        col = New DataColumn("cantidadatrasoalmacen", System.Type.GetType("System.Double"))
        T.Columns.Add(col)
        '22 tiempo atraso
        col = New DataColumn("tiempoatraso", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '23 id del dataset
        col = New DataColumn("totalEntregas", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '24
        col = New DataColumn("id", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '25
        col = New DataColumn("numerocontrolcalidad", System.Type.GetType("System.String"))
        T.Columns.Add(col)
        '26
        col = New DataColumn("fechasolicitudinspeccion", System.Type.GetType("System.DateTime"))
        T.Columns.Add(col)
        '27
        col = New DataColumn("fechacertificacion", System.Type.GetType("System.DateTime"))
        T.Columns.Add(col)
        '28
        col = New DataColumn("lote", System.Type.GetType("System.String"))
        T.Columns.Add(col)
        '29
        col = New DataColumn("factura", System.Type.GetType("System.String"))
        T.Columns.Add(col)
        '30
        col = New DataColumn("fecharecepcion", System.Type.GetType("System.DateTime"))
        T.Columns.Add(col)
        '31
        col = New DataColumn("cantidad", System.Type.GetType("System.Double"))
        T.Columns.Add(col)
        'DIAS MUERTOS
        '32
        col = New DataColumn("tiempomuerto", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        'CANTIDADENTREGADARECEPCION
        '33
        col = New DataColumn("cantidadentregadarecepcion", System.Type.GetType("System.Double"))
        T.Columns.Add(col)
        'FECHA DE VENCIMIENTO DE LOTE
        '34
        col = New DataColumn("fechavencimiento", System.Type.GetType("System.DateTime"))
        T.Columns.Add(col)
        '35
        col = New DataColumn("acta", System.Type.GetType("System.String"))
        T.Columns.Add(col)
    End Sub
End Class

''Revisamos tiempos de control de calidad *****************************************************
'en = arrControlCalidad.GetEnumerator
'While en.MoveNext

'    '    'sabemos que el lote se encuentra en la pos 4
'    Dim CC As CONTROLCALIDAD = en.Current

'    CC.contador = CI.identificador  'Contador para hacer referencia

'    data_lotes.Add(CC)

'    If CDate(CC.fechaSolicitudInspeccion) > CI.fechaLimite Then
'        'Solicitud mayor a la fecha de entrega, no se toma en cuenta el tiempo muerto, es incumplimiento en todo caso
'        tiempo_muerto = 0
'    Else
'        'Esto significa que se hizo la entrega a tiempo sin importar el CC
'        tiempo_muerto = CC.tiempoDiferencia  'Tiempo muerto
'    End If

'End While
'**********************************************************************************************
