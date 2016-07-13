Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.DATOS

Public Class cDISTRIBUCIONPRODUCTO
    Inherits controladorBase

    Private mdb As New dbDISTRIBUCIONPRODUCTO
    Public Function ObtenerProductosParaDistribucion(ByVal IdAlmacen As Integer, ByVal IdSuminitro As Integer) As DataSet
        Try
            Return mdb.ObtenerProductosParaDistribucion(IdAlmacen, IdSuminitro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaProductosParaDistribucion(ByVal IdAlmacen As Integer, ByVal IdSuminitro As Integer, ByVal IdGrupo As Integer, ByVal IdSubGrupo As Integer) As DataSet
        Try
            Return mdb.ObtenerListaProductosDistribucion(IdAlmacen, IdSuminitro, IdGrupo, IdSubGrupo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function


    Public Function obtenerDistribucionProductos(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Try
            Return mdb.obtenerDistribucionProductos(IDDISTRIBUCION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function agregarDistribucionProducto(ByVal lEntidad As DISTRIBUCIONPRODUCTO) As Integer

        Dim tran As New DistributedTransaction
        Dim mdb2 As New dbDISTRIBUCION
        Dim eEntidad As DISTRIBUCION
        Dim dbC As New dbCATALOGOPRODUCTOS
        Dim dbEntidadDistro As New dbDISTRIBUCION

        Dim i As Integer

        eEntidad = mdb2.obtenerDistribucionPorID(lEntidad.IDDISTRIBUCION, lEntidad.IDESTABLECIMIENTO)

        Try

            'Agregamos el maestro
            i = mdb.agregarDistribucionProducto(lEntidad, tran)

            'Agregamos los lotes para ese producto
            i = dbEntidadDistro.agregarDistribucionProductoLote(lEntidad, tran, lEntidad.IDPRODUCTO)

            If eEntidad.ESTADO = 2 Then

                If lEntidad.IDTIPOESTABLECIMIENTO = 10 And eEntidad.IDSUMINISTRO = 1 Then
                    i = mdb2.crearDistribucionRegiones(eEntidad, tran, lEntidad.CODPRODUCTO, lEntidad.IDPRODUCTO)
                ElseIf eEntidad.IDSUMINISTRO = 1 Then
                    i = mdb2.crearDistribucionHospitales(eEntidad, tran, lEntidad.CODPRODUCTO, lEntidad.IDPRODUCTO)
                Else
                    i = mdb2.crearDistribucionGenerica(eEntidad, tran, lEntidad.IDPRODUCTO)
                End If

            End If

            tran.Commit()

            Return 1

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function


    Public Function actualizarDistribucionProducto(ByVal arr As ArrayList) As Integer

        Dim tran As New DistributedTransaction

        Try

            For i As Integer = 0 To arr.Count - 1

                Dim lentidad As DISTRIBUCIONPRODUCTO = arr.Item(i)

                mdb.actualizarDistribucionProducto(lentidad, tran)

            Next

            tran.Commit()

            Return 0

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function eliminarDistribucionProducto(ByVal IDDISTRIBUCION As Integer, ByVal IDPRODUCTO As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim tran As New DistributedTransaction
        Dim i As Integer
        Try

            'Eliminamos detalle
            i = mdb.eliminarDistribucionProductoDetalleLote(IDDISTRIBUCION, IDPRODUCTO, IDESTABLECIMIENTO, tran)
            i = mdb.eliminarDistribucionProductoDetalle(IDDISTRIBUCION, IDPRODUCTO, IDESTABLECIMIENTO, tran)
            'Eliminamos maestro
            i = mdb.eliminarDistribucionProducto(IDDISTRIBUCION, IDPRODUCTO, IDESTABLECIMIENTO, tran)

            tran.Commit()
            Return 1

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return 0
        End Try

    End Function

    Public Function productosSeleccionables(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, Optional ByVal CORRPRODUCTO As String = "", Optional IDPROGRAMA As Integer = 0) As DataSet

        Try
            Return mdb.productosSeleccionables(IDALMACEN, IDSUMINISTRO, CORRPRODUCTO, IDPROGRAMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerDistribucionProductosDetalle(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Try
            Return mdb.obtenerDistribucionProductosDetalle(IDDISTRIBUCION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerLotesDistribucion(ByVal eEntidad As DISTRIBUCIONPRODUCTO) As DataSet

        Try
            Return mdb.obtenerLotesDistribucion(eEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function


    Public Function actualizarLotes(ByVal eEntidad As DISTRIBUCIONPRODUCTO, ByVal arr As ArrayList) As Integer

        Dim tran As New DistributedTransaction
        Dim i As Integer

        Try

            i = mdb.eliminarDistribucionLotes(eEntidad, tran)

            For j As Integer = 0 To arr.Count - 1
                i = mdb.agregarDistribucionLotes(eEntidad, arr(j), tran)
            Next

            tran.Commit()
            Return 1

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try


    End Function
    Public Function ObtenerProductosParaDistribucionPorPrograma(ByVal IdAlmacen As Integer, ByVal IdPrograma As Integer) As DataSet
        Try
            Return mdb.ObtenerProductosParaDistribucionPorPrograma(IdAlmacen, IdPrograma)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
End Class
