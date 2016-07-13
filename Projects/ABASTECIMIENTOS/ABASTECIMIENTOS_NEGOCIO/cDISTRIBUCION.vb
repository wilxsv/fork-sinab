Imports ABASTECIMIENTOS.ENTIDADES

Public Class cDistribucion
    Inherits controladorBase

    Private mDb As New dbDISTRIBUCION()

    Public Function obtenerDsDistribucion(ByVal IDESTABLECIMIENTO As Integer)

        Try
            Return mDb.obtenerDsDistribucion(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    'Public Function ActualizarConProductos(ByVal aEntidad As DISTRIBUCION, ByVal IdLista As Integer) As Integer

    '    Dim tran As New DistributedTransaction
    '    Dim dbEntidad As New dbDISTRIBUCIONDETALLE

    '    Try

    '        Dim IDDISTRIBUCION As Integer = aEntidad.IDDISTRIBUCION
    '        'Se crea o modifica la distribucion
    '        Dim i As Integer = mDb.actualizarDistribucion(aEntidad, tran)

    '        'En caso de ser una nueva distribucion, se crea la lista de productos para ella con sus respectivas compras en transito
    '        If IDDISTRIBUCION = 0 Then

    '            'Se agregan los productos que tiene el almacén y sus respectivos lotes
    '            i = mDb.agregarDistribucionListaProducto(aEntidad, tran, IdLista)
    '            i = mDb.agregarDistribucionListaProductoLote(aEntidad, tran, IdLista)

    '            'Y todos los datos de los productos por establecimiento
    '            i = mDb.agregarDistribucionEstablecimiento(aEntidad, tran)

    '            If i > 0 Then
    '                tran.Commit()
    '                Return i
    '            Else
    '                tran.Abort()
    '                Return -1
    '            End If

    '        End If

    '        tran.Commit()

    '        Return i

    '    Catch ex As Exception
    '        tran.Abort()
    '        ExceptionManager.Publish(ex)
    '        Return -1
    '    End Try
    'End Function
    Public Function ActualizarLista(ByVal aEntidad As DISTRIBUCION, ByVal lista As List(Of Integer)) As Integer

        Dim tran As New DistributedTransaction
        Dim dbEntidad As New dbDISTRIBUCIONDETALLE

        Try

            Dim IDDISTRIBUCION As Integer = aEntidad.IDDISTRIBUCION
            'Se crea o modifica la distribucion
            Dim i As Integer = mDb.actualizarDistribucion(aEntidad, tran)

            'En caso de ser una nueva distribucion, se crea la lista de productos para ella con sus respectivas compras en transito
            If IDDISTRIBUCION = 0 Then

                'Se agregan los productos que tiene el almacén y sus respectivos lotes

                i = mDb.agregarDistribucionListaProductos(aEntidad, tran, lista)
                i = mDb.agregarDistribucionListaProductosLote(aEntidad, tran, lista)


                'Y todos los datos de los productos por establecimiento
                i = mDb.agregarDistribucionEstablecimiento(aEntidad, tran)

                If i > 0 Then
                    tran.Commit()
                    Return i
                Else
                    tran.Abort()
                    Return -1
                End If

            End If

            tran.Commit()

            Return i

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function Actualizar(ByVal aEntidad As DISTRIBUCION) As Integer

        Dim tran As New DistributedTransaction
        Dim dbEntidad As New dbDISTRIBUCIONDETALLE

        Try

            Dim IDDISTRIBUCION As Integer = aEntidad.IDDISTRIBUCION
            'Se crea o modifica la distribucion
            Dim i As Integer = mDb.actualizarDistribucion(aEntidad, tran)

            'En caso de ser una nueva distribucion, se crea la lista de productos para ella con sus respectivas compras en transito
            If IDDISTRIBUCION = 0 Then

                'Se agregan los productos que tiene el almacén y sus respectivos lotes

                i = mDb.agregarDistribucionProducto(aEntidad, tran)
                i = mDb.agregarDistribucionProductoLote(aEntidad, tran)


                'Y todos los datos de los productos por establecimiento
                i = mDb.agregarDistribucionEstablecimiento(aEntidad, tran)

                If i > 0 Then
                    tran.Commit()
                    Return i
                Else
                    tran.Abort()
                    Return -1
                End If

            End If

            tran.Commit()

            Return i

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerDistribucionPorID(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DISTRIBUCION
        Try
            Return mDb.obtenerDistribucionPorID(IDDISTRIBUCION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDistribucionPorEstado(ByVal Estado As Integer)
        Try
            Return mDb.obtenerDistribucionesPorEstado(Estado)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerEstablecimientosDistribucion(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Try
            Dim ds As DataSet = mDb.obtenerEstablecimientosDistribucion(IDDISTRIBUCION, IDESTABLECIMIENTO)
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function eliminarDistribucionEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDESTABLECIMIENTODISTRIBUCION As Integer) As Integer

        Try
            Return mDb.eliminarDistribucionEstablecimiento(IDPROGRAMACION, IDESTABLECIMIENTO, IDESTABLECIMIENTODISTRIBUCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try

    End Function

    Public Function obtenerEstablecimientosFueraDistribucion(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOESTABLECIMIENTO As Integer) As DataSet

        Try
            Return mDb.obtenerEstablecimientosFueraDistribucion(IDDISTRIBUCION, IDESTABLECIMIENTO, IDTIPOESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function agregarDistribucionEstablecimientos(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDESTABLECIMIENTODISTRIBUCION As Integer, ByVal USUARIO As String) As Integer

        Try
            Return mDb.agregarDistribucionEstablecimientos(IDDISTRIBUCION, IDESTABLECIMIENTO, IDESTABLECIMIENTODISTRIBUCION, USUARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function actualizarEstadoDistribucion(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal ESTADO As Integer, ByVal USUARIO As String, ByVal TIPOESTABLECIMIENTO As Integer) As Integer

        Dim eEntidad As DISTRIBUCION = mDb.obtenerDistribucionPorID(IDDISTRIBUCION, IDESTABLECIMIENTO)
        eEntidad.AUUSUARIOCREACION = USUARIO

        Dim tran As New DistributedTransaction

        Try

            Dim i As Integer

            i = mDb.actualizarEstadoDistribucion(IDDISTRIBUCION, IDESTABLECIMIENTO, ESTADO, USUARIO, tran)

            If ESTADO = 1 Then 'Creamos cuadro de distribución

                'Aquí depende del tipo de establecimiento
                i = -1

                If eEntidad.IDSUMINISTRO = 1 And TIPOESTABLECIMIENTO = 10 Then
                    i = mDb.crearDistribucionRegiones(eEntidad, tran)
                ElseIf eEntidad.IDSUMINISTRO = 1 Then
                    i = mDb.crearDistribucionHospitales(eEntidad, tran)
                Else 'Se llena vacio todo para que ellos capturen
                    i = mDb.crearDistribucionGenerica(eEntidad, tran)
                End If

                If i <= 0 Then
                    tran.Abort()
                    Return -1
                End If

            End If

            tran.Commit()

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function obtenerRptDistribucion(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal ORDEN As Integer, Optional ByVal IDPRODUCTO As Integer = 0, Optional ByVal IDESTABLECIMIENTODISTRIBUCION As Integer = 0) As DataSet

        Try
            Dim ds As Data.DataSet = mDb.obtenerRptDistribucion(IDDISTRIBUCION, IDESTABLECIMIENTO, ORDEN, IDPRODUCTO, IDESTABLECIMIENTODISTRIBUCION)
            ds.Tables(0).TableName = "dtTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function obtenerRptDistribucion22(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal ORDEN As Integer, ByRef ds As DataSet, Optional ByVal IDPRODUCTO As Integer = 0, Optional ByVal IDESTABLECIMIENTODISTRIBUCION As Integer = 0) As Integer

        Try
            mDb.obtenerRptDistribucion22(IDDISTRIBUCION, IDESTABLECIMIENTO, ORDEN, ds, IDPRODUCTO, IDESTABLECIMIENTODISTRIBUCION)

            Return 1
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function obtenerRptDistribucionFechaEntrega(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Try
            Dim ds As Data.DataSet = mDb.obtenerRptDistribucionFechaEntrega(IDDISTRIBUCION, IDESTABLECIMIENTO)
            ds.Tables(0).TableName = "dtTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function obtenerRptDistribucionLotesMonto(ByVal FECHAINICIO As String, ByVal FECHAFIN As String, Optional ByVal IDDISTRIBUCION As Integer = 0, Optional ByVal IDESTABLECIMIENTO As Integer = 0, Optional ByVal IDPRODUCTO As Integer = 0, Optional ByVal DISTRIBUYE As Boolean = False) As DataSet

        Try
            Dim ds As Data.DataSet = mDb.obtenerRptDistribucionEstablecimiento(FECHAINICIO, FECHAFIN, IDDISTRIBUCION, IDESTABLECIMIENTO, IDPRODUCTO, DISTRIBUYE)
            ds.Tables(0).TableName = "dtTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function existenciaAlmacen(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer) As Integer

        Dim tran As New DistributedTransaction

        Try
            Dim i As Integer

            i = mDb.existenciaAlmacen(IDDISTRIBUCION, IDESTABLECIMIENTO, IDPRODUCTO, tran)

            tran.Commit()

            Return i

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            tran.Abort()
            Return 0
        End Try

    End Function


    Public Function AniosDistribuciones() As DataSet

        Try
            Dim ds As Data.DataSet = mDb.AniosDistribuciones()
            ds.Tables(0).TableName = "dtTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ListaDistribuciones(anio As Integer, idestablecimiento As Integer) As DataSet
        Try
            Dim ds As Data.DataSet = mDb.ListaDistribuciones(anio, idestablecimiento)
            ds.Tables(0).TableName = "dtTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ListaDistribucionesCerradas(anio As Integer, idestablecimiento As Integer, Optional g As Integer = 0, Optional IDESTABLECIMIENTODISTRIBUCION As Integer = 0, Optional todosestados As Boolean = False) As DataSet
        Try
            Dim ds As Data.DataSet = mDb.ListaDistribucionesCerradas(anio, idestablecimiento, g, IDESTABLECIMIENTODISTRIBUCION, todosestados)
            ds.Tables(0).TableName = "dtTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    'SCMS
    Public Function agregarDistribucionCerradas(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Try
            mDb.agregarDistribucionesCerradas(IDDISTRIBUCION, IDESTABLECIMIENTO)
            mDb.agregarDistribucionesCerradasFechas(IDDISTRIBUCION, IDESTABLECIMIENTO)
            Return mDb.agregarDistribucionesCerradaslotes(IDDISTRIBUCION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function
    Public Function eliminarTodoDistribucionEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Try
            Return mDb.eliminarTodoDistribucionEstablecimiento(IDPROGRAMACION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try

    End Function
    Public Function ObtenerSuministroDistribucion(iddistribucion As Integer, idestablecimiento As Integer) As Integer
        Try
            Return mDb.ObtenerIDSuministroDistribucion(iddistribucion, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ListaEstablecimientosPorDistribucion(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Try
            Dim ds As Data.DataSet = mDb.ListaEstablecimientosPorDistribucion(iddistribucion, idestablecimiento)
            ds.Tables(0).TableName = "dtTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ListaProductosPorEstabyDistribucion(iddistribucion As Integer, idestablecimiento As Integer, idestablecimientodistribucion As Integer) As DataSet
        Try
            Dim ds As Data.DataSet = mDb.ListaProductosPorEstabyDistribucion(iddistribucion, idestablecimiento, idestablecimientodistribucion)
            ds.Tables(0).TableName = "dtTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ListaDistribucionFechaEntrega(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Try
            Dim ds As Data.DataSet = mDb.ListaDistribucionFechaEntrega(iddistribucion, idestablecimiento)
            ds.Tables(0).TableName = "dtTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarFechasEntrega(iddistribucion As Integer, idestablecimiento As Integer, idprograma As Integer, idestablecimientodistribucion As Integer, fechaentrega As DateTime, observacion As String) As Integer
        Try
            Return mDb.ActualizarFechasEntrega(iddistribucion, idestablecimiento, idprograma, idestablecimientodistribucion, fechaentrega, observacion)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarCantidadDistribuida(iddistribucion As Integer, idestablecimiento As Integer, idestablecimientodistribucion As Integer, idproducto As Integer, cantidaddistribuida As Decimal) As Integer
        Try
            Dim q As Decimal
            q = mDb.ObtenerCantidadDistribuida(iddistribucion, idestablecimiento, idestablecimientodistribucion, idproducto)
            Return mDb.ActualizarCantidadDistribuida(iddistribucion, idestablecimiento, idestablecimientodistribucion, idproducto, cantidaddistribuida + q)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function EliminarFechasEntrega(iddistribucion As Integer, idestablecimiento As Integer) As Integer
        Try
            mDb.EliminarFechasEntregaHistorial(iddistribucion, idestablecimiento)
            Return mDb.EliminarFechasEntrega(iddistribucion, idestablecimiento)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerLotesDistribucion(iddistribucion As Integer, idestablecimiento As Integer, idproducto As Integer, idalmacen As Integer) As DataSet
        Try
            Dim ds As Data.DataSet = mDb.ObtenerLotesDistribucion(iddistribucion, idestablecimiento, idproducto, idalmacen)
            ds.Tables(0).TableName = "dtTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerFechaEntregaDistribucion(iddistribucion As Integer, idestablecimiento As Integer, idestablecimientodistribucion As Integer) As String
        Try
            Dim ds As String = mDb.ObtenerFechaEntregaDistribucion(iddistribucion, idestablecimiento, idestablecimientodistribucion)

            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerMesesCalculo(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Try
            Return mDb.ObtenerMesesCalculo(IDDISTRIBUCION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function
    Public Function Obtenerfechaconsumo(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Date
        Try
            Return mDb.Obtenerfechaconsumo(IDDISTRIBUCION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function VerificarLista(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.VerificarLista(IDDISTRIBUCION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteDistribucion4(idestablecimiento As Integer, anio As integer) As DataSet
        Try
            Return mDb.ObtenerReporteDistribucion4(idestablecimiento, anio)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteDistribucion1(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Try
            Return mDb.ObtenerReporteDistribucion1(iddistribucion, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteDistribucion2(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Try
            Return mDb.ObtenerReporteDistribucion2(iddistribucion, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteDistribucion3(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Try
            Return mDb.ObtenerReporteDistribucion3(iddistribucion, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteDistribucion5(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Try
            Return mDb.ObtenerReporteDistribucion5(iddistribucion, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarTrazabilidad(iddistribucion As Integer, idestablecimiento As Integer, idalmacen As Integer, idproducto As Integer, numerovale As Integer, fechacierrevale As String, cantidadvale As Decimal, idalmacendistribucion As Integer, numerorecibo As String, fechacierrerecibo As String, cantidadrecibo As Decimal, VALESALIDA As String) As Integer
        Try

            Return mDb.ActualizarTrazabilidad(iddistribucion, idestablecimiento, idalmacen, idproducto, numerovale, fechacierrevale, cantidadvale, idalmacendistribucion, numerorecibo, fechacierrerecibo, cantidadrecibo, VALESALIDA)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function InsertarValeSalidaDistribucion(iddistribucion As Integer, idvale As Integer) ', idalmacen As Integer, idproducto As Integer, numerovale As Integer, fechacierrevale As String, cantidadvale As Decimal, idalmacendistribucion As Integer, numerorecibo As String, fechacierrerecibo As String, cantidadrecibo As Decimal, VALESALIDA As String) As Integer
        Try

            Return mDb.InsertarValeSalidaDistribucion(iddistribucion, idvale) ', idalmacen, idproducto, numerovale, fechacierrevale, cantidadvale, idalmacendistribucion, numerorecibo, fechacierrerecibo, cantidadrecibo, VALESALIDA)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerIdDistribucion(idalmacen As Integer, idmovimiento As Integer) As Integer
        Try
            Return mDb.ObtenerIdDistribucion(idalmacen, idmovimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
End Class
