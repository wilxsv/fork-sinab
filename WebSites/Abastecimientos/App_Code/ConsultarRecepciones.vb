Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Collections
Imports System.Text
Imports Microsoft.VisualBasic

Public Class ConsultarRecepciones

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
    Public csql As String
    Public cTipoConsulta As Integer = 0
    Public cDsProcesos As DataSet

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

    Public Function query_entregas() As String

        Dim sql As New Text.StringBuilder("select ")
        'sql.Append("c.idestablecimiento, c.idproveedor, c.idcontrato, ")
        'sql.Append("c.fechadistribucion, pc.cantidad, pc.preciounitario, ec.entrega, ")
        'sql.Append("ec.plazoentrega , ec.porcentajeentrega, pc.idproducto, ")
        'sql.Append("dateadd(dd, ec.plazoentrega, c.fechadistribucion) as fechalimite, aec.idalmacenentrega, ")
        'sql.Append("aec.cantidad, cp.desclargo as producto, a.nombre as almacen, p.nombre, um.descripcion ")
        'sql.Append("from ")
        'sql.Append("SAB_UACI_CONTRATOS c ")
        'sql.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO pc ")
        'sql.Append("ON c.idestablecimiento = pc.idestablecimiento AND ")
        'sql.Append("c.idproveedor = pc.idproveedor AND ")
        'sql.Append("c.idcontrato = pc.idcontrato ")
        'sql.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO ec ")
        'sql.Append("ON pc.idestablecimiento = ec.idestablecimiento AND ")
        'sql.Append("pc.idproveedor = ec.idproveedor AND ")
        'sql.Append("pc.idcontrato = ec.idcontrato AND ")
        'sql.Append("pc.idproveedor = ec.idproveedor ")
        'sql.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS aec ")
        'sql.Append("ON ec.idestablecimiento = aec.idestablecimiento AND ")
        'sql.Append("ec.idproveedor = aec.idproveedor AND ")
        'sql.Append("ec.idcontrato = aec.idcontrato AND ")
        'sql.Append("ec.renglon = aec.renglon AND ")
        'sql.Append("ec.iddetalle = aec.iddetalle ")
        'sql.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA cpc ")
        'sql.Append("ON c.idestablecimiento = cpc.idestablecimiento AND ")
        'sql.Append("c.idcontrato = cpc.idcontrato ")
        'sql.Append("INNER JOIN vv_CATALOGOPRODUCTOS cp ")
        'sql.Append("ON  pc.idproducto = cp.idproducto ")
        'sql.Append("INNER JOIN SAB_CAT_ALMACENES a ")
        'sql.Append("ON  aec.idalmacenentrega = a.idalmacen ")
        'sql.Append("INNER JOIN SAB_CAT_PROVEEDORES p ")
        'sql.Append("ON  c.idproveedor = p.idproveedor ")
        'sql.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS um ")
        'sql.Append("ON  pc.idunidadmedida = um.idunidadmedida ")
        'sql.Append("where ")
        'sql.Append("ec.ESTAHABILITADA = 1 AND ")
        'sql.Append("cpc.IdProcesoCompra = " & Me.cProcesoCompra & " ")
        'sql.Append("AND dateadd(dd, ec.plazoentrega, c.fechadistribucion) <= getdate() ") 'Fecha


        sql.Append(" SELECT     c.IDESTABLECIMIENTO, c.IDPROVEEDOR, c.IDCONTRATO, c.FECHADISTRIBUCION, pc.CANTIDAD, pc.PRECIOUNITARIO, ec.ENTREGA,  ")
        sql.Append(" ec.PLAZOENTREGA, ec.PORCENTAJEENTREGA, pc.IDPRODUCTO, DATEADD(dd, ec.PLAZOENTREGA, c.FECHADISTRIBUCION) AS fechalimite,  ")
        sql.Append(" aec.IDALMACENENTREGA, aec.CANTIDAD AS Expr1, cp.DESCLARGO AS producto, a.NOMBRE AS almacen, p.NOMBRE, um.DESCRIPCION,  ")
        sql.Append(" cpc.IdProcesoCompra() ")
        sql.Append(" FROM         SAB_UACI_CONTRATOS AS c INNER JOIN ")
        sql.Append(" SAB_UACI_PRODUCTOSCONTRATO AS pc ON c.IDESTABLECIMIENTO = pc.IDESTABLECIMIENTO AND c.IDPROVEEDOR = pc.IDPROVEEDOR AND  ")
        sql.Append(" c.IDCONTRATO = pc.IDCONTRATO INNER JOIN ")
        sql.Append(" SAB_UACI_ENTREGACONTRATO AS ec ON pc.IDESTABLECIMIENTO = ec.IDESTABLECIMIENTO AND pc.IDPROVEEDOR = ec.IDPROVEEDOR AND  ")
        sql.Append(" pc.IDCONTRATO = ec.IDCONTRATO AND pc.IDPROVEEDOR = ec.IDPROVEEDOR INNER JOIN ")
        sql.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS AS aec ON ec.IDESTABLECIMIENTO = aec.IDESTABLECIMIENTO AND  ")
        sql.Append(" ec.IDPROVEEDOR = aec.IDPROVEEDOR AND ec.IDCONTRATO = aec.IDCONTRATO AND ec.RENGLON = aec.RENGLON AND  ")
        sql.Append(" ec.IDDETALLE = aec.IDDETALLE INNER JOIN ")
        sql.Append(" SAB_UACI_CONTRATOSPROCESOCOMPRA AS cpc ON c.IDESTABLECIMIENTO = cpc.IDESTABLECIMIENTO AND c.IDCONTRATO = cpc.IDCONTRATO AND ")
        sql.Append(" c.IDPROVEEDOR = cpc.IDPROVEEDOR INNER JOIN ")
        sql.Append(" vv_CATALOGOPRODUCTOS AS cp ON pc.IDPRODUCTO = cp.IDPRODUCTO INNER JOIN ")
        sql.Append(" SAB_CAT_ALMACENES AS a ON aec.IDALMACENENTREGA = a.IDALMACEN INNER JOIN ")
        sql.Append(" SAB_CAT_PROVEEDORES AS p ON c.IDPROVEEDOR = p.IDPROVEEDOR INNER JOIN ")
        sql.Append(" SAB_CAT_UNIDADMEDIDAS AS um ON pc.IDUNIDADMEDIDA = um.IDUNIDADMEDIDA ")
        sql.Append(" WHERE     (ec.ESTAHABILITADA = 1) AND (cpc.IdProcesoCompra = 1) ")


        'Filtros
        If Me.cProveedor > 0 Then sql.Append("AND c.idproveedor = " & Me.cProveedor & " ")
        If Me.cEstablecimiento > 0 Then sql.Append("AND c.idestablecimiento = " & Me.cEstablecimiento & " ")
        If Me.cContrato > 0 Then sql.Append("AND c.idcontrato = " & Me.cContrato & " ")
        If Me.cProducto > 0 Then sql.Append("AND pc.idproducto = " & Me.cProducto & " ")
        If Me.cAlmacen > 0 Then sql.Append("AND a.idalmacen = " & Me.cAlmacen & " ")
        If Me.cRenglon > 0 Then sql.Append("AND ec.renglon = " & Me.cRenglon & " ")
        If Me.cEntrega > 0 Then sql.Append("AND aec.identrega = " & Me.cEntrega & " ")

        Return sql.ToString


    End Function

    Private Function query_recibos(ByVal est As Integer, ByVal prov As Integer, ByVal contr As Integer, ByVal prod As Integer) As String

        'Private Function query_recibos() As String

        Dim Sql As New Text.StringBuilder("select ")
        Sql.Append("rr.idalmacen, m.fechamovimiento, l.codigo, dm.cantidad ")
        Sql.Append("from ")
        Sql.Append("SAB_ALM_RECIBOSRECEPCION rr ")
        Sql.Append("INNER JOIN SAB_ALM_MOVIMIENTOS m ")
        Sql.Append("ON rr.idalmacen = m.idalmacen AND ")
        Sql.Append("rr.idrecibo = m.iddocumento ")
        Sql.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS dm ")
        Sql.Append("ON m.idestablecimiento = dm.idestablecimiento AND ")
        Sql.Append("m.idtipotransaccion = dm.idtipotransaccion AND ")
        Sql.Append("m.idmovimiento = dm.idmovimiento ")
        Sql.Append("LEFT OUTER JOIN SAB_ALM_LOTES l ")
        Sql.Append("ON dm.idalmacen = l.idalmacen AND ")
        Sql.Append("dm.idlote = l.idlote ")
        Sql.Append("where ")
        Sql.Append("m.idtipotransaccion = 8 AND ") '8 es para las recepciones
        Sql.Append("rr.idestablecimiento = " & est & " AND ") '@ESTABLECIMIENTO
        Sql.Append("rr.idproveedor = " & prov & " AND ") '@PROVEEDOR
        Sql.Append("rr.idcontrato = " & contr & " AND ") '@CONTRATO
        Sql.Append("dm.idproducto = " & prod & " ") '@PRODUCTO
        Sql.Append("order by m.fechamovimiento ASC") '@PRODUCTO

        Return Sql.ToString

    End Function

    Public Sub generarDataset()

        'Variables de conexion
        Dim con As New SqlConnection
        Dim cmd As SqlCommand
        Dim rs As SqlDataReader


        Dim data_entrega As New ArrayList
        Dim data_cambio As New ArrayList
        Dim pos_cambio As New ArrayList

        Dim i As Integer
        Dim j As Integer

        Dim strTemp As String
        Dim strTemp2 As String

        Dim en As IEnumerator
        'Dim args(4) As SqlParameter

        Dim idx_inicio As Integer
        Dim idx_final As Integer

        Dim iniciado As Integer = 0

        If Me.cProcesoCompra = 0 And Me.cEstablecimiento = 0 Then
            Me.msgError = "Proceso de compra no definido"
            Exit Sub
        End If

        'Conexion a la base de datos
        con.ConnectionString = "Data Source=10.10.20.7\desarrollo;Initial Catalog=abastecimiento_desarrollo;Persist Security Info=True;User ID=usuario_sab; pwd=12345"

        'Tratamos de abrir la base de datos
        Try
            con.Open()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Me.msgError = ex.Message
            Exit Sub
        End Try

        'Se hace el query inicial para trabajar
        Dim StrSql As New StringBuilder

        If cTipoConsulta = 1 Then ' Si es por periodos hay "n" procesos de compra

            For i = 0 To cDsProcesos.Tables(0).Rows.Count - 1
                cProcesoCompra = cDsProcesos.Tables(0).Rows(i).Item(0)
                If i = 0 Then
                    StrSql.Append(Me.query_entregas)
                Else
                    StrSql.Append(" union ")
                    StrSql.Append(Me.query_entregas)
                End If

            Next

        Else
            StrSql.Append(Me.query_entregas())
        End If

        pos_cambio.Add(0)

        Try
            cmd = New SqlCommand(StrSql.ToString, con)
            rs = cmd.ExecuteReader

            If Not rs.HasRows Then
                Me.msgError = "No se encontraron datos para la consulta"
                Exit Sub
            End If

            'Se lee el resultado de la consulta
            Do While rs.Read

                Dim arrTemp(21) As Object

                'Llenamos la matriz con los datos que queremos

                'Prueba de performance, se podria poner separado


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

                '17 cantidad entregada del producto
                '18 cantidad entregada con atraso
                '19 tiempo atraso
                '20 lote

                For i = 0 To rs.FieldCount - 1
                    arrTemp(i) = rs.Item(i)
                Next
                'Las que hacen falta y se van a calcular
                arrTemp(17) = 0
                arrTemp(18) = 0
                arrTemp(19) = DBNull.Value
                arrTemp(20) = ""

                'Dato para revision de posicion en matriz
                'Establecimiento|Proveedor|Contrato|Producto
                strTemp2 = rs.Item(0) & "|" & rs.Item(1) & "|" & rs.Item(2) & "|" & rs.Item(9)
                'Establecimiento|Proveedor|Contrato|Producto|Almacen
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

            'Variables que se pasan al query, cuando exista el dbhelper
            'args(0) = New SqlParameter("@ESTABLECIMIENTO", SqlDbType.Int)
            'args(1) = New SqlParameter("@PROVEEDOR", SqlDbType.Int)
            'args(2) = New SqlParameter("@CONTRATO", SqlDbType.BigInt)
            'args(3) = New SqlParameter("@PRODUCTO", SqlDbType.BigInt)

            While en.MoveNext
                j = CInt(en.Current)
                strTemp = data_cambio.Item(j)

                'Declaramos el array que va a contener los datos
                Dim arrTemp() As String
                Dim alm_ant As Integer = 0

                'Asi queda, ojo! 
                'Establecimiento|Proveedor|Contrato|Producto
                arrTemp = strTemp.Split("|")

                csql = Me.query_recibos(arrTemp(0), arrTemp(1), arrTemp(2), arrTemp(3))

                'Esto sirve para despues, para el datahelper
                'Se podria meter en un for, es de revisar performance. 

                'args(0).Value = CInt(arrTemp(0))
                'args(1).Value = CInt(arrTemp(1))
                'args(2).Value = CInt(arrTemp(2))
                'args(3).Value = CInt(arrTemp(3))

                'Ejecutamos y leemos
                cmd = New SqlCommand(csql, con)
                rs = cmd.ExecuteReader

                'Su nombre las explica
                Dim cantidad_residuo As Double
                Dim fecha_residuo As Date

                Dim cantidad_trabajo As Double
                Dim fecha_trabajo As Date

                'No pasa mucho si no devuelve datos
                Do While rs.Read
                    'Se busca la posicion de inicio
                    strTemp2 = arrTemp(0) & "|" & arrTemp(1) & "|" & arrTemp(2) & "|" & arrTemp(3) & "|" & rs.Item(0)
                    'Se busca la posicion de inicio
                    idx_inicio = data_cambio.IndexOf(strTemp2)
                    'Se busca la posicion final
                    idx_final = data_cambio.LastIndexOf(strTemp2)

                    Dim arrTemp2(21) As Object
                    Dim cant_diferencia As Double

                    iniciado = False

                    'Reseteamos todo
                    If alm_ant <> rs.Item(0) Then
                        alm_ant = rs.Item(0)
                        cantidad_residuo = 0.0
                    End If

                    'Se procede a trabajar y llenar todas las cosas necesarias
                    For i = idx_inicio To idx_final

                        arrTemp2 = data_entrega(i)

                        'Lo de los lotes, me obligaron a hacerlo, ESTO DEBERIA DE HABERLO HECHO HENRY O JAVIER
                        If Not IsDBNull(rs.Item(2)) Then
                            If arrTemp2(20) = "" Then
                                arrTemp2(20) = rs.Item(2)
                            Else
                                arrTemp2(20) = arrTemp2(20) & ", " & rs.Item(2)
                            End If
                        End If

                        If iniciado And cantidad_residuo = 0.0 Then Exit For

                        If CDbl(arrTemp2(12)) <> CDbl(arrTemp2(17)) Then 'Esto significa que no se ha hecho full entrega

                            'OJO. Ver lo de las fechas, ya que los movimientos tienen horas
                            cant_diferencia = CDbl(arrTemp2(12)) - CDbl(arrTemp2(17))

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
                                        arrTemp2(17) = cant_diferencia
                                    Else
                                        fecha_trabajo = fecha_residuo
                                        cantidad_residuo = cantidad_residuo - cant_diferencia
                                        arrTemp2(17) = arrTemp2(17) + cant_diferencia
                                    End If


                                    'Control de residuos

                                    If fecha_trabajo > CDate(arrTemp2(10)) Then
                                        arrTemp2(18) = CDbl(arrTemp2(18)) + cant_diferencia 'Cantidad en retraso
                                        arrTemp2(19) = Math.Abs(DateDiff(DateInterval.Day, fecha_trabajo, CDate(arrTemp2(10))))
                                    End If


                                Case Is > 0 'Caso medio

                                    arrTemp2(17) = CDbl(arrTemp2(17)) + cantidad_trabajo

                                    If Not iniciado Then
                                        fecha_trabajo = rs.Item(1)
                                    Else
                                        fecha_trabajo = fecha_residuo
                                        cantidad_residuo = 0.0
                                    End If

                                    If fecha_trabajo > CDate(arrTemp2(10)) Then
                                        arrTemp2(18) = CDbl(arrTemp2(18)) + cantidad_trabajo 'Cantidad en retraso
                                        arrTemp2(19) = Math.Abs(DateDiff(DateInterval.Day, fecha_trabajo, CDate(arrTemp2(10))))
                                    End If


                                Case Else 'Caso mas facil, no nos preocupamos por los residuos

                                    If Not iniciado Then
                                        fecha_trabajo = rs.Item(1)
                                    Else
                                        fecha_trabajo = fecha_residuo
                                    End If

                                    If fecha_trabajo > CDate(arrTemp2(10)) Then
                                        arrTemp2(17) = cantidad_trabajo
                                        arrTemp2(18) = cantidad_trabajo 'Cantidad en retraso
                                        arrTemp2(19) = Math.Abs(DateDiff(DateInterval.Day, fecha_trabajo, CDate(arrTemp2(10))))
                                    Else
                                        arrTemp2(17) = cantidad_trabajo
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
            '26 unidad de medida
            col = New DataColumn("unidadmedida", System.Type.GetType("System.String"))
            tbl.Columns.Add(col)
            '17 cantidad entregada del producto
            col = New DataColumn("cantidadentregadaalmacen", System.Type.GetType("System.Double"))
            tbl.Columns.Add(col)
            '18 cantidad entregada con atraso
            col = New DataColumn("cantidadatrasoalmacen", System.Type.GetType("System.Double"))
            tbl.Columns.Add(col)
            '19 tiempo atraso
            col = New DataColumn("tiempoatraso", System.Type.GetType("System.Int32"))
            tbl.Columns.Add(col)
            '20 lote
            col = New DataColumn("lote", System.Type.GetType("System.String"))
            tbl.Columns.Add(col)


            en = data_entrega.GetEnumerator

            Dim arrFinal As Object

            While en.MoveNext
                arrFinal = en.Current



                dr = tbl.NewRow

                For j = 0 To 20
                    dr(j) = arrFinal(j)
                Next

                tbl.Rows.Add(dr)


            End While

            Me.dataRetornar.Tables.Add(tbl)

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
