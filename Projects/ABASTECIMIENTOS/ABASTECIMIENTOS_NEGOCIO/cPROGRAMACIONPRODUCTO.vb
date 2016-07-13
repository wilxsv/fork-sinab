Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.DATOS

Public Class cPROGRAMACIONPRODUCTO
    Inherits controladorBase

    Private mdb As New dbPROGRAMACIONPRODUCTO

    Public Function obtenerProgramacionProductos(ByVal IDPROGRAMACION As Integer, Optional ByVal C As Boolean = False, Optional ByVal IDPROGRAMA As Integer = 0) As DataSet

        Try
            Dim ds As DataSet = mdb.obtenerProgramacionProductos(IDPROGRAMACION, C, IDPROGRAMA)
            ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerProgramacionProductos2(ByVal IDPROGRAMACION As Integer, ByVal IDTIPOESTABLECIMIENTO As Integer, Optional ByVal IDSUMINISTRO As Integer = 1) As DataSet

        Try
            Dim ds As DataSet = mdb.obtenerProgramacionProductos2(IDPROGRAMACION, IDTIPOESTABLECIMIENTO, IDSUMINISTRO)
            ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerProgramacionProductosEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Try
            Return mdb.obtenerProgramacionProductosEstablecimiento(IDPROGRAMACION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerProgramacionProductosDetalle(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal m As Integer, ByVal n As Integer, Optional ByVal reporte As Integer = 0, Optional ByVal ordenABC As Boolean = False) As DataSet

        Try
            Dim ds As DataSet = mdb.obtenerProgramacionProductosDetalle(IDPROGRAMACION, IDESTABLECIMIENTO, m, n, reporte, ordenABC)

            If ds Is Nothing Then Return Nothing

            Dim total As Decimal = 1
            Dim sum As Decimal = 0
            Dim categoria As Integer = 1

            If ds.Tables(0).Rows.Count > 0 Then
                total = ds.Tables(0).Compute("SUM(MONTOTOTAL)", "")
            End If

            Dim c1 As DataColumn = New DataColumn("porcentaje", GetType(Decimal), IIf(total = 0, "0", "(MONTOTOTAL/" & total & ")*100"))
            ds.Tables(0).Columns.Add(c1)

            Dim c2 As DataColumn = New DataColumn("categoriaABC", GetType(Integer))
            ds.Tables(0).Columns.Add(c2)

            ds.Tables(0).TableName = "tblProgramacion"

            If ordenABC Then
                For Each row As DataRow In ds.Tables(0).Rows

                    sum = sum + row.Item("porcentaje")
                    row("categoriaABC") = categoria

                    If sum > 80 And categoria = 1 Then
                        categoria = 2
                    ElseIf sum > 95 And categoria = 2 Then
                        categoria = 3
                    End If

                Next
            End If

            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerProgramacionProductosDetalle2(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal m As Integer) As DataSet

        Try
            Dim ds As DataSet = mdb.obtenerProgramacionProductosDetalle2(IDPROGRAMACION, IDESTABLECIMIENTO, m)

            ds.Tables(0).TableName = "tblProgramacion"

            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function obtenerProgramacionProductosDetalle3(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Try
            Dim ds As DataSet = mdb.obtenerProgramacionProductosDetalle3(IDPROGRAMACION, IDESTABLECIMIENTO)

            ds.Tables(0).TableName = "tblProgramacion"

            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function obtenerProgramacionProductosConsolidado(ByVal IDPROGRAMACION As Integer, Optional ByVal ordenABC As Boolean = False, Optional ByVal IDPROGRAMA As Integer = 0) As DataSet

        Try
            Dim ds As DataSet = mdb.obtenerProgramacionProductosConsolidado(IDPROGRAMACION, ordenABC, IDPROGRAMA)

            If ds Is Nothing Then Return Nothing

            Dim total As Decimal = 1
            Dim sum As Decimal = 0
            Dim categoria As Integer = 1

            If ds.Tables(0).Rows.Count > 0 Then
                total = ds.Tables(0).Compute("SUM(MONTOTOTALAJUSTADO)", "")
            End If

            Dim c1 As DataColumn = New DataColumn("porcentaje", GetType(Decimal), IIf(total = 0, "0", "(MONTOTOTALAJUSTADO/" & total & ")*100"))
            ds.Tables(0).Columns.Add(c1)

            Dim c2 As DataColumn = New DataColumn("categoriaABC", GetType(Integer))
            ds.Tables(0).Columns.Add(c2)

            ds.Tables(0).TableName = "tblProgramacion"

            If ordenABC Then
                For Each row As DataRow In ds.Tables(0).Rows

                    sum = sum + row.Item("porcentaje")
                    row("categoriaABC") = categoria

                    If sum > 80 And categoria = 1 Then
                        categoria = 2
                    ElseIf sum > 95 And categoria = 2 Then
                        categoria = 3
                    End If

                Next
            End If

            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerProgramacionDetallePorProducto(ByVal IDPROGRAMACION As Integer, ByVal IDPRODUCTO As Integer, Optional ByVal IDPROGRAMA As Integer = 0) As DataSet

        Try
            Dim ds As DataSet = mdb.obtenerProgramacionDetallePorProducto(IDPROGRAMACION, IDPRODUCTO, IDPROGRAMA)

            ds.Tables(0).TableName = "tblProgramacion"

            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function agregarProgramacionProducto(ByVal lEntidad As PROGRAMACIONPRODUCTO) As Integer

        Try

            'Primero, revisamos si existe el producto
            Dim IDALMACEN As Integer = mdb.existeProgramacionProducto(lEntidad.IDPROGRAMACION, lEntidad.IDPRODUCTO)

            If IDALMACEN <> 0 Then Return 0

            'Ahora que lo tenemos todo, solo insertamos en la base
            Return mdb.agregarProgramacionProducto(lEntidad)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function agregarProgramacionProductoEstablecimiento(ByVal lEntidad As PROGRAMACIONPRODUCTO, ByVal IDTIPOESTABLECIMIENTO As Integer) As Integer


        Dim tran As New DistributedTransaction
        Dim i As Integer

        Try

            'Primero, revisamos si existe el producto
            Dim PRUEBA As Integer = mdb.existeProgramacionProductoEstablecimiento(lEntidad.IDPROGRAMACION, lEntidad.IDPRODUCTO, lEntidad.IDESTABLECIMIENTO, tran)

            If PRUEBA <> 0 Then Return 0

            i = mdb.agregarProgramacionProductoEstablecimiento(lEntidad, IDTIPOESTABLECIMIENTO, tran)

            If lEntidad.IDSUMINISTRO = 1 Then
                i = mdb.ajustarCobertura(lEntidad.IDPROGRAMACION, lEntidad.IDESTABLECIMIENTO, tran, lEntidad.IDPRODUCTO)
            End If

            tran.Commit()
            'Ahora que lo tenemos todo, solo insertamos en la base
            Return 1

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            tran.Abort()
            Return -1
        End Try

    End Function

    Public Function actualizarProgramacionProducto(ByVal arr As ArrayList) As Integer

        Dim tran As New DistributedTransaction

        Try

            For i As Integer = 0 To arr.Count - 1

                Dim lentidad As PROGRAMACIONPRODUCTO = arr.Item(i)

                mdb.actualizarProgramacionProducto(lentidad, tran)

            Next

            tran.Commit()

            Return 0

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function actualizarProgramacionProductoEstablecimiento(ByVal arr As ArrayList, ByVal eEntidad As PROGRAMACION) As Integer

        Dim tran As New DistributedTransaction
        Dim idestablecimiento As Integer

        Try

            For i As Integer = 0 To arr.Count - 1

                Dim lentidad As PROGRAMACIONPRODUCTO = arr.Item(i)
                idestablecimiento = lentidad.IDESTABLECIMIENTO

                mdb.actualizarProgramacionProductoEstablecimiento(lentidad, eEntidad, tran)

            Next

            Dim j As Integer = mdb.ajustarCobertura(eEntidad.IDPROGRAMACION, idestablecimiento, tran)

            tran.Commit()

            Return 0

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function


    Public Function actualizarProgramacionAjusteProductoEstablecimiento(ByVal eEntidad As PROGRAMACIONPRODUCTO) As Integer

        Dim tran As New DistributedTransaction
        Dim i As Integer
        Try

            i = mdb.actualizarProgramacionAjusteProductoEstablecimiento(eEntidad, tran)

            Return 1
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function actualizarProgramacionAjusteEstablecimiento(ByVal arr As ArrayList, ByVal eEntidad As PROGRAMACION) As Integer

        Dim tran As New DistributedTransaction

        Try

            For i As Integer = 0 To arr.Count - 1

                Dim lentidad As PROGRAMACIONPRODUCTO = arr.Item(i)

                mdb.actualizarProgramacionAjusteEstablecimiento(lentidad, eEntidad, tran)

            Next

            tran.Commit()

            Return 0

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function eliminarProgramacionProductoTODOS(ByVal IDPROGRAMACION As Integer) As Integer

        Try
            Return mdb.eliminarProgramacionProductoTODOS(IDPROGRAMACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try

    End Function

    Public Function eliminarProgramacionProducto(ByVal IDPROGRAMACION As Integer, ByVal IDPRODUCTO As Integer) As Integer

        Try
            Return mdb.eliminarProgramacionProducto(IDPROGRAMACION, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try

    End Function

    Public Function eliminarProgramacionProductoEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDPRODUCTO As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Try
            Return mdb.eliminarProgramacionProductoEstablecimiento(IDPROGRAMACION, IDPRODUCTO, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try

    End Function

    Public Function numeroRegistrosEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Try
            Return mdb.numeroRegistrosEstablecimiento(IDPROGRAMACION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function
    Public Function numeroRegistrosEstablecimiento2(ByVal IDPROGRAMACION As Integer) As Integer

        Try
            Return mdb.numeroRegistrosEstablecimiento2(IDPROGRAMACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function agregarProgramacionProductoRegion(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOESTABLECIMIENTO As Integer, ByVal USUARIO As String, ByVal eEntidad As PROGRAMACION) As Integer


        Dim tran As New DistributedTransaction

        Try
            Dim i As Integer = 0

            mdb.actualizarEstadoProgramacion(IDPROGRAMACION, IDESTABLECIMIENTO, 1, USUARIO, tran)
            'i = mdb.agregarProgramacionRegion(IDPROGRAMACION, IDESTABLECIMIENTO, USUARIO, tran)

            i = mdb.agregarProgramacionProductoRegion(IDPROGRAMACION, IDESTABLECIMIENTO, IDTIPOESTABLECIMIENTO, USUARIO, eEntidad, tran)

            If eEntidad.IDSUMINISTRO = 1 Then
                i = mdb.ajustarCobertura(IDPROGRAMACION, IDESTABLECIMIENTO, tran)
            End If

            tran.Commit()

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function
    Public Function agregarProgramacionProductoRegion2(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOESTABLECIMIENTO As Integer, ByVal USUARIO As String, ByVal eEntidad As PROGRAMACION) As Integer


        Dim tran As New DistributedTransaction

        Try
            Dim i As Integer = 0

            mdb.actualizarEstadoProgramacion2(IDPROGRAMACION, 1, USUARIO, tran)
            'i = mdb.agregarProgramacionRegion(IDPROGRAMACION, IDESTABLECIMIENTO, USUARIO, tran)

            i = mdb.agregarProgramacionProductoRegion(IDPROGRAMACION, IDESTABLECIMIENTO, IDTIPOESTABLECIMIENTO, USUARIO, eEntidad, tran)

            If eEntidad.IDSUMINISTRO = 1 Then
                i = mdb.ajustarCobertura(IDPROGRAMACION, IDESTABLECIMIENTO, tran)
            End If

            tran.Commit()

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function
    Public Function VerificarProgramacionProductoEstablecimiento(ByVal IDPROGRAMACION As Integer) As Integer

        Try
            Return mdb.VerificarProgramacionProductoEstablecimiento(IDPROGRAMACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function ObtenerEstablecimientosProgramacion(ByVal IDPROGRAMACION As Integer) As DataSet

        Try
            Return mdb.ObtenerEstablecimientosProgramacion(IDPROGRAMACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function obtenerCodigoProductoProgramacion(ByVal IDPROGRAMACION As Integer, ByVal CODIGO As String, ByVal IDTIPOESTABLECIMIENTO As Integer, Optional ByVal IDSUMINISTRO As Integer = 1) As DataSet

        Try
            Return mdb.obtenerCodigoProductoProgramacion(IDPROGRAMACION, CODIGO, IDTIPOESTABLECIMIENTO, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function actualizarEstadoProgramacion(ByVal eEntidad As PROGRAMACIONPRODUCTO, Optional ByVal b As Boolean = False, Optional ByVal c As Boolean = False) As Integer

        Try

            Return mdb.actualizarEstadoProgramacion(eEntidad, b, c)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try


    End Function


    Public Function obtenerDesabastecimientoConsolidado(ByVal IDPROGRAMACION As Integer, ByVal M As Integer, Optional ByVal IDPROGRAMA As Integer = 0) As DataSet

        Try
            Dim ds As DataSet = mdb.obtenerDesabastecimientoConsolidado(IDPROGRAMACION, M, IDPROGRAMA)

            ds.Tables(0).TableName = "tblProgramacion"

            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerDetalleEntregaProductos(ByVal IDPROGRAMACION As Integer) As DataSet

        Try
            Dim ds As DataSet = mdb.obtenerDetalleEntregaProductos(IDPROGRAMACION)
            ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerDistribucionProgramacion(ByVal IDPROGRAMACION As Integer, ByVal TIPO As Integer) As DataSet

        Try

            'Se obtienen todos los medicamentos con precios mayores a 0
            Dim ds As DataSet = mdb.obtenerDistribucionProgramacion(IDPROGRAMACION, TIPO)
            Dim ds2 As New DataSet
            Dim linea As Integer = 0
            Dim codigo As Integer = 0
            Dim codigo2 As Integer = 0
            Dim alternativa As Integer = 0

            Dim tabla As DataTable

            tabla = crearTabla()


            'Tenemos que crear el modelo del dataset, linea, codigo, etc
            For Each row As DataRow In ds.Tables(0).Rows

                If codigo <> row.Item(10) Then

                    'Esta parte es sumamente importante porque aqui anexamos las alternativas
                    'Con el codigo obtenemos todas las alternativas para este y las anexamos a la
                    'tabla

                    If alternativa <> 0 Then

                        'aumentamos la linea en 1
                        'linea = linea + 1

                        'buscamos por alternativas
                        Dim t As String = mdb.obtenerAlternativasProgramacion(codigo)

                        'Obtenemos los datos de las alternativas y los agregamos a la tabla
                        Dim dsA As DataSet = mdb.obtenerDistribucionProgramacion(IDPROGRAMACION, 2, t)

                        For Each row2 As DataRow In dsA.Tables(0).Rows

                            If codigo2 <> row2.Item(10) Then
                                codigo2 = row2.Item(10)
                                linea = linea + 1
                            End If


                            Dim rowTemp2 As DataRow
                            rowTemp2 = tabla.NewRow()

                            ' Then add the new row to the collection.
                            rowTemp2("linea") = linea
                            rowTemp2("establecimiento") = row2.Item(0)
                            rowTemp2("corrproducto") = row2.Item(1)
                            rowTemp2("desclargo") = row2.Item(2)
                            rowTemp2("descripcion") = row2.Item(3)
                            rowTemp2("codigonacionesunidas") = row2.Item(4)
                            rowTemp2("cantidadcomprarajustada") = row2.Item(5)
                            rowTemp2("precio") = row2.Item(6)
                            rowTemp2("montototalajustado") = row2.Item(7)
                            rowTemp2("entrega") = row2.Item(8)
                            rowTemp2("observacion") = row2.Item(9)
                            rowTemp2("alternativa") = 1

                            tabla.Rows.Add(rowTemp2)

                        Next


                    End If

                    alternativa = row.Item(11)
                    codigo = row.Item(10)
                    linea = linea + 1

                End If

                Dim rowTemp As DataRow
                rowTemp = tabla.NewRow()

                ' Then add the new row to the collection.
                rowTemp("linea") = linea
                rowTemp("establecimiento") = row.Item(0)
                rowTemp("corrproducto") = row.Item(1)
                rowTemp("desclargo") = row.Item(2)
                rowTemp("descripcion") = row.Item(3)
                rowTemp("codigonacionesunidas") = row.Item(4)
                rowTemp("cantidadcomprarajustada") = row.Item(5)
                rowTemp("precio") = row.Item(6)
                rowTemp("montototalajustado") = row.Item(7)
                rowTemp("entrega") = row.Item(8)
                rowTemp("observacion") = row.Item(9)
                rowTemp("alternativa") = 0

                tabla.Rows.Add(rowTemp)

            Next

            ds2.Tables.Add(tabla)

            Return ds2
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try


    End Function

    Public Function obtenerDistribucionProgramacion2(ByVal IDPROGRAMACION As Integer, ByVal TIPO As Integer) As DataSet

        Try
            Dim ds As DataSet = mdb.obtenerDistribucionProgramacion2(IDPROGRAMACION, TIPO)

            ds.Tables(0).TableName = "tblProgramacion"

            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try


    End Function

    Private Function crearTabla() As DataTable
        ' Create a new DataTable titled 'Names.'
        Dim tabla As DataTable = New DataTable("tblProgramacion")

        'Primero la linea
        Dim clLinea As DataColumn = New DataColumn()
        clLinea.DataType = System.Type.GetType("System.Int32")
        clLinea.ColumnName = "linea"
        tabla.Columns.Add(clLinea)

        'Seguimos con el establecimiento
        Dim clEstablecimiento As DataColumn = New DataColumn()
        clEstablecimiento.DataType = System.Type.GetType("System.String")
        clEstablecimiento.ColumnName = "establecimiento"
        tabla.Columns.Add(clEstablecimiento)

        'Seguimos con el correlativo
        Dim clCorrelativo As DataColumn = New DataColumn()
        clCorrelativo.DataType = System.Type.GetType("System.String")
        clCorrelativo.ColumnName = "corrproducto"
        tabla.Columns.Add(clCorrelativo)

        'Seguimos con el descripcion
        Dim clDescLargo As DataColumn = New DataColumn()
        clDescLargo.DataType = System.Type.GetType("System.String")
        clDescLargo.ColumnName = "desclargo"
        tabla.Columns.Add(clDescLargo)

        'Seguimos con el descripcion
        Dim clUnidad As DataColumn = New DataColumn()
        clUnidad.DataType = System.Type.GetType("System.String")
        clUnidad.ColumnName = "descripcion"
        tabla.Columns.Add(clUnidad)

        'Seguimos con el codigo de naciones unidas
        Dim clNacionesUnidad As DataColumn = New DataColumn()
        clNacionesUnidad.DataType = System.Type.GetType("System.String")
        clNacionesUnidad.ColumnName = "codigonacionesunidas"
        clNacionesUnidad.AllowDBNull = True
        tabla.Columns.Add(clNacionesUnidad)

        'Seguimos con la cantidad a comprar
        Dim clCantidadComprar As DataColumn = New DataColumn()
        clCantidadComprar.DataType = System.Type.GetType("System.Decimal")
        clCantidadComprar.ColumnName = "cantidadcomprarajustada"
        tabla.Columns.Add(clCantidadComprar)

        'Seguimos con el precio
        Dim clPrecio As DataColumn = New DataColumn()
        clPrecio.DataType = System.Type.GetType("System.Decimal")
        clPrecio.ColumnName = "precio"
        tabla.Columns.Add(clPrecio)

        'Seguimos con el monto
        Dim clMonto As DataColumn = New DataColumn()
        clMonto.DataType = System.Type.GetType("System.Decimal")
        clMonto.ColumnName = "montototalajustado"
        tabla.Columns.Add(clMonto)

        'Seguimos con las entregas
        Dim clEntregas As DataColumn = New DataColumn()
        clEntregas.DataType = System.Type.GetType("System.Int32")
        clEntregas.ColumnName = "entrega"
        tabla.Columns.Add(clEntregas)

        'Terminamos con las observaciones
        Dim clObservaciones As DataColumn = New DataColumn()
        clObservaciones.DataType = System.Type.GetType("System.String")
        clObservaciones.ColumnName = "observacion"
        tabla.Columns.Add(clObservaciones)


        Dim clAlternativa As DataColumn = New DataColumn()
        clAlternativa.DataType = System.Type.GetType("System.Int32")
        clAlternativa.ColumnName = "alternativa"
        tabla.Columns.Add(clAlternativa)

        ' Return the new DataTable.
        crearTabla = tabla

    End Function

    Public Function actualizarProgramacionMonto(ByVal arr As ArrayList) As Integer

        Dim tran As New DistributedTransaction

        Try

            For i As Integer = 0 To arr.Count - 1

                Dim lentidad As PROGRAMACIONPRODUCTO = arr.Item(i)

                mdb.actualizarMontoProgramacion(lentidad.IDPROGRAMACION, lentidad.IDESTABLECIMIENTO, lentidad.PRESUPUESTOREAL, lentidad.AUUSUARIOMODIFICACION, tran)

            Next

            tran.Commit()

            Return 0

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function obtenerTechoProgramacion(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Decimal

        Try
            Return mdb.obtenerTechoProgramacion(IDPROGRAMACION, IDESTABLECIMIENTO)
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function montoSobrepasaTecho(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByRef DIF As Decimal) As Boolean

        Try
            Dim techo As Decimal = mdb.obtenerTechoProgramacion(IDPROGRAMACION, IDESTABLECIMIENTO)
            Dim montoAjustado As Decimal = mdb.obtenerMontoAjustado(IDPROGRAMACION, IDESTABLECIMIENTO)

            DIF = Math.Abs(techo - montoAjustado)

            'Se adiciona validacion para no cerrar una programacion con monto ajustado =0  Mayra Martínez 03102012
            If techo >= montoAjustado And montoAjustado <> 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function agregarProgramacionProductoAlternativa(ByVal lEntidad As PROGRAMACIONPRODUCTO) As Integer

        Try

            'Primero, revisamos si existe el producto
            Dim IDALMACEN As Integer = mdb.existeProgramacionProducto(lEntidad.IDPROGRAMACION, lEntidad.IDPRODUCTO)

            If IDALMACEN <> 0 Then Return 0

            'Ahora que lo tenemos todo, solo insertamos en la base
            Return mdb.agregarProgramacionProductoAlternativa(lEntidad)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

End Class
