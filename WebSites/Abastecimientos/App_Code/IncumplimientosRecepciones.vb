Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class IncumplimientosRecepciones

    Private dataRetornar As DataSet
    Private msgError As String

    'Variables a utilizar
    Public cEstablecimiento As Integer
    Public cProveedor As Integer
    Public cContrato As Int64
    Public cProducto As Integer
    Public cAlmacen As Integer
    Public cProcesoCompra As Int64
    Public cRenglon As Integer
    Public cEntrega As Integer

    Public Sub incumplimientosRecepciones()
        Me.dataRetornar = New DataSet
        Me.msgError = ""

        cEstablecimiento = 0
        cProveedor = 0
        cContrato = 0
        cProducto = 0
        cAlmacen = 0
        cProcesoCompra = 0
        cRenglon = 0
        cEntrega = 0

    End Sub

    Public Function dev_Error() As String
        Return Me.msgError
    End Function

    Public Function dev_DS() As DataSet
        Return Me.dataRetornar
    End Function

    Private Function query_entregas() As String

        Dim sql As New Text.StringBuilder("select ")
        sql.Append("c.idestablecimiento, c.idproveedor, c.idcontrato, ")
        sql.Append("c.fechadistribucion, pc.cantidad, pc.preciounitario, ec.entrega, ")
        sql.Append("ec.plazoentrega , ec.porcentajeentrega, pc.idproducto, ")
        sql.Append("dateadd(dd, ec.plazoentrega, c.fechadistribucion) as fechalimite, aec.idalmacenentrega, ")
        sql.Append("aec.cantidad, cp.desclargo as producto, a.nombre as almacen, p.nombre, um.descripcion, ")
        sql.Append("ec.renglon, c.numerocontrato, cp.CORRPRODUCTO ")
        sql.Append("from ")
        sql.Append("SAB_UACI_CONTRATOS c ")
        sql.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO pc ")
        sql.Append("ON c.idestablecimiento = pc.idestablecimiento AND ")
        sql.Append("c.idproveedor = pc.idproveedor AND ")
        sql.Append("c.idcontrato = pc.idcontrato ")
        sql.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO ec ")
        sql.Append("ON pc.idestablecimiento = ec.idestablecimiento AND ")
        sql.Append("pc.idproveedor = ec.idproveedor AND ")
        sql.Append("pc.idcontrato = ec.idcontrato AND ")
        sql.Append("pc.renglon = ec.renglon ")
        sql.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS aec ")
        sql.Append("ON ec.idestablecimiento = aec.idestablecimiento AND ")
        sql.Append("ec.idproveedor = aec.idproveedor AND ")
        sql.Append("ec.idcontrato = aec.idcontrato AND ")
        sql.Append("ec.renglon = aec.renglon AND ")
        sql.Append("ec.iddetalle = aec.iddetalle ")
        sql.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA cpc ")
        sql.Append("ON c.idestablecimiento = cpc.idestablecimiento AND ")
        sql.Append("c.idcontrato = cpc.idcontrato AND ")
        sql.Append("c.idproveedor = cpc.idproveedor ")
        sql.Append("INNER JOIN vv_CATALOGOPRODUCTOS cp ")
        sql.Append("ON  pc.idproducto = cp.idproducto ")
        sql.Append("INNER JOIN SAB_CAT_ALMACENES a ")
        sql.Append("ON  aec.idalmacenentrega = a.idalmacen ")
        sql.Append("INNER JOIN SAB_CAT_PROVEEDORES p ")
        sql.Append("ON  c.idproveedor = p.idproveedor ")
        sql.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS um ")
        sql.Append("ON  pc.idunidadmedida = um.idunidadmedida ")
        sql.Append("where ")
        sql.Append("ec.ESTAHABILITADA = 1")
        sql.Append(" AND c.idestadocontrato = 3 ") ' Contrato distribuido
        sql.Append("AND cpc.IdProcesoCompra = " & Me.cProcesoCompra & " ")
        'sql.Append("AND dateadd(dd, ec.plazoentrega, c.fechadistribucion) <= getdate() ") 'Fecha

        'Filtros
        If Me.cProveedor > 0 Then sql.Append("AND c.idproveedor = " & Me.cProveedor & " ")
        If Me.cEstablecimiento > 0 Then sql.Append("AND c.idestablecimiento = " & Me.cEstablecimiento & " ")
        If Me.cContrato > 0 Then sql.Append("AND c.idcontrato = " & Me.cContrato & " ")
        If Me.cProducto > 0 Then sql.Append("AND pc.idproducto = " & Me.cProducto & " ")
        If Me.cAlmacen > 0 Then sql.Append("AND a.idalmacen = " & Me.cAlmacen & " ")
        If Me.cRenglon > 0 Then sql.Append("AND ec.renglon = " & Me.cRenglon & " ")
        If Me.cEntrega > 0 Then sql.Append("AND aec.identrega = " & Me.cEntrega & " ")

        sql.Append("ORDER BY c.idestablecimiento, c.idproveedor, c.idcontrato, ec.renglon, ec.entrega, a.idalmacen ASC ")

        Return sql.ToString


    End Function

    Private Function query_recibos(ByVal est As Integer, ByVal prov As Integer, ByVal contr As Integer, ByVal reng As Integer, ByVal alm As Integer) As String

        Dim Sql As New Text.StringBuilder("select ")
        Sql.Append("rr.idalmacen, m.fechamovimiento, l.codigo, dm.cantidad, l.idestablecimiento, l.idinformecontrolcalidad ")
        Sql.Append("from ")
        Sql.Append("SAB_ALM_RECIBOSRECEPCION rr ")
        Sql.Append("INNER JOIN SAB_ALM_MOVIMIENTOS m ")
        Sql.Append("ON rr.idalmacen = m.idalmacen AND ")
        Sql.Append("rr.idrecibo = m.iddocumento AND ")
        Sql.Append("rr.anio = m.anio ")
        Sql.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS dm ")
        Sql.Append("ON m.idestablecimiento = dm.idestablecimiento AND ")
        Sql.Append("m.idtipotransaccion = dm.idtipotransaccion AND ")
        Sql.Append("m.idmovimiento = dm.idmovimiento ")
        Sql.Append("LEFT OUTER JOIN SAB_ALM_LOTES l ")
        Sql.Append("ON dm.idalmacen = l.idalmacen AND ")
        Sql.Append("dm.idlote = l.idlote ")
        Sql.Append("where ")
        Sql.Append("m.idtipotransaccion = 8 AND ") '8 es para las recepciones
        Sql.Append("rr.idestablecimiento = " & est & " AND ")
        Sql.Append("rr.idproveedor = " & prov & " AND ")
        Sql.Append("rr.idcontrato = " & contr & " AND ")
        Sql.Append("dm.renglon = " & reng & " AND ")
        Sql.Append("rr.idalmacen = " & alm & " ")
        Sql.Append("order by m.fechamovimiento ASC")

        Return Sql.ToString

    End Function

    Private Function query_controlcalidad(ByVal est As Integer, ByVal prov As Integer, ByVal contr As Integer, ByVal reng As Integer) As String

        Dim Sql As New Text.StringBuilder("select ")
        Sql.Append("numeroinforme, ")
        Sql.Append("fechasolicitudinspeccion, ")
        Sql.Append("fechacertificacion, ")
        Sql.Append("abs(datediff(dd, fechasolicitudinspeccion, fechacertificacion)), lote ")
        Sql.Append("from ")
        Sql.Append("SAB_LAB_INFORMEMUESTRAS ")
        Sql.Append("where ")
        Sql.Append("idestablecimientocontrato = " & est & " AND ")
        Sql.Append("idproveedor = " & prov & " AND ")
        Sql.Append("idcontrato = " & contr & " AND ")
        Sql.Append("renglon = " & reng & " ")
        Sql.Append("ORDER BY fechasolicitudinspeccion ASC ")

        Return Sql.ToString

    End Function


    Public Sub generarDataset()

        'Variables de conexion
        Dim con As New SqlConnection

        Dim cmd As SqlCommand

        Dim rs As SqlDataReader

        Dim sql As String

        Dim data_entrega As New ArrayList
        Dim data_cambio As New ArrayList
        Dim pos_cambio As New ArrayList

        Dim data_lotes As New ArrayList
        Dim pos_lotes As New ArrayList

        Dim i As Integer
        Dim j As Integer

        Dim strTemp As String
        Dim strTemp2 As String

        Dim en As IEnumerator

        Dim idx_inicio As Integer
        Dim idx_final As Integer

        Dim iniciado As Integer = 0

        If Me.cProcesoCompra = 0 And Me.cEstablecimiento = 0 Then
            Me.msgError = "Proceso de compra no definido"
            Exit Sub
        End If

        'Conexion a la base de datos
        con.ConnectionString = System.Configuration.ConfigurationManager.AppSettings("cnnString")

        'Tratamos de abrir la base de datos
        Try
            con.Open()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Me.msgError = ex.Message
            Exit Sub
        End Try

        'Se hace el query inicial para trabajar
        sql = Me.query_entregas()

        pos_cambio.Add(0)

        Try
            cmd = New SqlCommand(sql, con)
            rs = cmd.ExecuteReader

            If Not rs.HasRows Then
                Me.msgError = "No se encontraron datos para la consulta"
                Exit Sub
            End If

            Dim cont As Integer = 0
            'Se lee el resultado de la consulta
            Do While rs.Read

                Dim arrTemp(23) As Object
                cont += 1
                'Llenamos la matriz con los datos que queremos

                'Contenido de los campos.......si, yo se que es algo grande
                '0 establecimiento
                '1 proveedor
                '2 contrato
                '3 fecha dist
                '4 cantidad total de producto
                '5 precio unitario
                '6 entrega
                '7 plazo entrega
                '8 % entrega
                '9 producto
                '10 fecha limite
                '11 almacen
                '12 cantidad almacen
                '13 producto (nombre)
                '14 almacen (nombre)
                '15 proveedor (nombre)
                '16 Unidad de medida 
                '17 Renglon
                '18 numero contrato

                '19 codigo producto

                '20 cantidad entregada del producto
                '21 cantidad entregada con atraso
                '22 tiempo atraso
                '23 autoincremental para el dataset?

                For i = 0 To rs.FieldCount - 1
                    arrTemp(i) = rs.Item(i)
                Next
                'Las que hacen falta y se van a calcular
                arrTemp(20) = 0
                arrTemp(21) = 0
                arrTemp(22) = DBNull.Value
                arrTemp(23) = cont

                'Dato para revision de posicion en matriz
                'Establecimiento|Proveedor|Contrato|Renglon
                strTemp2 = rs.Item(0) & "|" & rs.Item(1) & "|" & rs.Item(2) & "|" & rs.Item(17)
                'Establecimiento|Proveedor|Contrato|Renglon|Almacen
                strTemp = strTemp2 & "|" & rs.Item(11)

                data_entrega.Add(arrTemp)
                data_cambio.Add(strTemp)

                If iniciado <> 0 Then

                    strTemp = CStr(data_cambio.Item(iniciado - 1))
                    j = strTemp.LastIndexOf("|")

                    If strTemp2 <> strTemp.Substring(0, j) Then
                        pos_cambio.Add(iniciado)
                    End If

                End If

                iniciado += 1

            Loop

            'Liberamos de memoria los objetos para reutilizarlos despues
            cmd.Dispose()
            rs.Close()

            'El unico dato que nos interesa es la cantidad de cambios en los productos en estos momentos
            'Lo recorremos para obtener datos que queremos con otro superquery
            en = pos_cambio.GetEnumerator

            While en.MoveNext
                j = CInt(en.Current)
                strTemp = data_cambio.Item(j)

                'Declaramos el array que va a contener los datos
                Dim arrTemp() As String
                Dim arrControlCalidad As New ArrayList

                'Asi queda, ojo! 
                'Establecimiento|Proveedor|Contrato|Renglon
                arrTemp = strTemp.Split("|")


                'Antes necesitamos todos los datos de control de calidad para ese contrato y ojo: ese renglon
                sql = Me.query_controlcalidad(arrTemp(0), arrTemp(1), arrTemp(2), arrTemp(3))

                'Ejecutamos y leemos
                cmd = New SqlCommand(sql, con)
                rs = cmd.ExecuteReader

                Do While rs.Read
                    Dim arrTemp2(4) As String
                    For i = 0 To rs.FieldCount - 1
                        arrTemp2(i) = rs.Item(i)
                    Next
                    arrControlCalidad.Add(arrTemp2) 'Todos los datos de control de calidad para ese renglon
                Loop

                'Liberamos de memoria los objetos para reutilizarlos despues
                cmd.Dispose()
                rs.Close()

                sql = Me.query_recibos(arrTemp(0), arrTemp(1), arrTemp(2), arrTemp(3), arrTemp(4))

                'Ejecutamos y leemos
                cmd = New SqlCommand(sql, con)
                rs = cmd.ExecuteReader

                'Su nombre las explica
                Dim cantidad_residuo As Double
                Dim fecha_residuo As Date

                Dim cantidad_trabajo As Double
                Dim fecha_trabajo As Date

                'No pasa mucho si no devuelve datos
                Do While rs.Read
                    strTemp2 = arrTemp(0) & "|" & arrTemp(1) & "|" & arrTemp(2) & "|" & arrTemp(3) & "|" & rs.Item(0)
                    'Se busca la posicion de inicio
                    idx_inicio = data_cambio.IndexOf(strTemp2)
                    'Se busca la posicion final
                    idx_final = data_cambio.LastIndexOf(strTemp2)

                    Dim arrTemp2(23) As Object
                    Dim cant_diferencia As Double

                    iniciado = False

                    'Reseteamos todo
                    cantidad_residuo = 0.0

                    'Se procede a trabajar y llenar todas las cosas necesarias
                    For i = idx_inicio To idx_final

                        arrTemp2 = data_entrega(i)
                        Dim tiempo_muerto As Integer = 0

                        ''Revisamos tiempos de control de calidad
                        en = arrControlCalidad.GetEnumerator
                        While en.MoveNext
                            Dim arrTemp3(4) As String
                            Dim arrTemp4(5) As String

                            '    'sabemos que el lote se encuentra en la pos 4
                            arrTemp3 = en.Current

                            arrTemp4(0) = arrTemp3(0)
                            arrTemp4(1) = arrTemp3(1)
                            arrTemp4(2) = arrTemp3(2)
                            arrTemp4(3) = arrTemp3(3)
                            arrTemp4(4) = arrTemp3(4)
                            arrTemp4(5) = arrTemp(23) 'Contador para hacer referencia

                            data_lotes.Add(arrTemp3)

                            If CDate(arrTemp3(1)) > CDate(arrTemp2(10)) Then
                                '            'Solicitud mayor a la fecha de entrega, no se toma en cuenta el tiempo muerto, es incumplimiento en todo caso
                                tiempo_muerto = 0
                            Else
                                '            'Esto significa que se hizo la entrega a tiempo sin importar el CC
                                tiempo_muerto = arrTemp3(3) 'Tiempo muerto
                            End If

                        End While

                        If iniciado And cantidad_residuo = 0.0 Then Exit For

                        If CDbl(arrTemp2(12)) <> CDbl(arrTemp2(20)) Then 'Esto significa que no se ha hecho full entrega

                            cant_diferencia = CDbl(arrTemp2(12)) - CDbl(arrTemp2(20))

                            If Not iniciado Then
                                cantidad_trabajo = rs.Item(3)
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
                                        arrTemp2(20) = cant_diferencia
                                    Else
                                        fecha_trabajo = fecha_residuo
                                        cantidad_residuo = cantidad_residuo - cant_diferencia
                                        arrTemp2(20) = arrTemp2(20) + cant_diferencia
                                    End If

                                    'Control de residuos

                                    'Existe retraso
                                    If fecha_trabajo > DateAdd(DateInterval.Day, tiempo_muerto, CDate(arrTemp2(10))) Then
                                        arrTemp2(21) = CDbl(arrTemp2(21)) + cant_diferencia 'Cantidad en retraso
                                        arrTemp2(22) = Math.Abs(DateDiff(DateInterval.Day, fecha_trabajo, CDate(arrTemp2(10))))
                                    End If

                                Case Is > 0 'Caso medio

                                    arrTemp2(20) = CDbl(arrTemp2(20)) + cantidad_trabajo

                                    If Not iniciado Then
                                        fecha_trabajo = rs.Item(1)
                                    Else
                                        fecha_trabajo = fecha_residuo
                                        cantidad_residuo = 0.0
                                    End If

                                    'Existe retraso
                                    'If fecha_trabajo > CDate(arrTemp2(10)) Then
                                    If fecha_trabajo > DateAdd(DateInterval.Day, tiempo_muerto, CDate(arrTemp2(10))) Then
                                        arrTemp2(21) = CDbl(arrTemp2(21)) + cantidad_trabajo 'Cantidad en retraso
                                        arrTemp2(22) = Math.Abs(DateDiff(DateInterval.Day, fecha_trabajo, CDate(arrTemp2(10))))
                                    End If

                                Case Else 'Caso mas facil, no nos preocupamos por los residuos

                                    If Not iniciado Then
                                        fecha_trabajo = rs.Item(1)
                                    Else
                                        fecha_trabajo = fecha_residuo
                                    End If

                                    'Existe retraso, ya sea por control de calidad o no
                                    'If fecha_trabajo > CDate(arrTemp2(10)) Then
                                    If fecha_trabajo > DateAdd(DateInterval.Day, tiempo_muerto, CDate(arrTemp2(10))) Then
                                        arrTemp2(20) = cantidad_trabajo
                                        arrTemp2(21) = cantidad_trabajo 'Cantidad en retraso
                                        arrTemp2(22) = Math.Abs(DateDiff(DateInterval.Day, fecha_trabajo, CDate(arrTemp2(10))))
                                    Else
                                        'No existe retraso
                                        arrTemp2(20) = cantidad_trabajo
                                    End If

                            End Select

                            'Actualizacion de datos
                            data_entrega(i) = arrTemp2

                            iniciado = True

                        End If

                    Next

                Loop

                rs.Close()

            End While

            'Variables para el dataset a crear
            Dim col As New DataColumn
            Dim tbl As New DataTable("incumplimientos")
            Dim tbl2 As New DataTable("lotes")
            Dim dr As DataRow

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
            '23 id del dataset
            col = New DataColumn("id", System.Type.GetType("System.Int32"))
            tbl.Columns.Add(col)

            '23 # informe cc
            col = New DataColumn("numerocontrolcalidad", System.Type.GetType("System.String"))
            tbl2.Columns.Add(col)
            '24 fecha limite
            col = New DataColumn("fechasolicitudinspeccion", System.Type.GetType("System.DateTime"))
            tbl2.Columns.Add(col)
            '25 fecha limite
            col = New DataColumn("fechacertificacion", System.Type.GetType("System.DateTime"))
            tbl2.Columns.Add(col)
            '26 tiempo atraso
            col = New DataColumn("tiempomuerto", System.Type.GetType("System.Int32"))
            tbl2.Columns.Add(col)
            '22 lote
            col = New DataColumn("lote", System.Type.GetType("System.String"))
            tbl2.Columns.Add(col)
            '22 id del dataset
            col = New DataColumn("id", System.Type.GetType("System.Int32"))
            tbl2.Columns.Add(col)

            en = data_entrega.GetEnumerator

            Dim arrFinal As Object

            While en.MoveNext
                arrFinal = en.Current

                dr = tbl.NewRow

                'Pequeño fix para los dias de atraso
                If arrFinal(12) <> arrFinal(20) And CDate(arrFinal(10)) < Today Then
                    arrFinal(22) = Math.Abs(DateDiff(DateInterval.Day, arrFinal(10), Today))
                End If

                For j = 0 To 23
                    dr(j) = arrFinal(j)
                Next

                tbl.Rows.Add(dr)


            End While

            'Vamos con los lotes
            en = data_lotes.GetEnumerator

            While en.MoveNext
                arrFinal = en.Current

                dr = tbl.NewRow

                For j = 0 To 5
                    dr(j) = arrFinal(j)
                Next

                tbl2.Rows.Add(dr)

            End While

            Me.dataRetornar.Tables.Add(tbl)
            Me.dataRetornar.Tables.Add(tbl2)

            Me.dataRetornar.Relations.Add("ids", _
                            Me.dataRetornar.Tables("incumplimientos").Columns("id"), _
                            Me.dataRetornar.Tables("lotes").Columns("id"))

        Catch ex As Exception
            Me.msgError = ex.Message
            con.Close()
            Exit Sub
        End Try

        Try
            con.Close()
        Catch ex As Exception
            'Me.msgError = ex.Message
        End Try

        Me.msgError = "All fine and dandy"

    End Sub

End Class
