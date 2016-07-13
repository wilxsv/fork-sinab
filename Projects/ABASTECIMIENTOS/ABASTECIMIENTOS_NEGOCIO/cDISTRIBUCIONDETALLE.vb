Public Class cDISTRIBUCIONDETALLE
    Inherits controladorBase

    Private mDb As New dbDISTRIBUCIONDETALLE()


    Public Function obtenerDistribucionDetalle(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer, Optional meses As Integer = 0) As DataSet

        Try
            Return mDb.obtenerDistribucionDetalle(IDDISTRIBUCION, IDESTABLECIMIENTO, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function obtenerDistribucionDetalle2(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer, fechaconsumo As Date, Optional meses As Integer = 0) As DataSet

        Try
            Return mDb.obtenerDistribucionDetalle2(IDDISTRIBUCION, IDESTABLECIMIENTO, IDPRODUCTO, fechaconsumo, meses)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function actualizarDistribucionDetalle(ByVal eentidad As DISTRIBUCION, ByVal arr As Dictionary(Of Integer, Decimal), ByVal IDPRODUCTO As Integer) As Integer

        'Actualizamos el detalle primero, luego obtenemos el total.
        'Si el total sobrepasa la cantidad en almacén, hacemos rollback

        Dim tran As New DistributedTransaction
        Dim dDistro As New dbDISTRIBUCION

        Try

            Dim j As Integer

            For Each i As KeyValuePair(Of Integer, Decimal) In arr
                j = mDb.actualizarDistribucionDetalle(eentidad.IDDISTRIBUCION, eentidad.IDESTABLECIMIENTO, i.Key, IDPRODUCTO, i.Value, eentidad.AUUSUARIOMODIFICACION, tran)
            Next

            'Verificamos cantidades
            Dim cantidadAlmacen = dDistro.existenciaAlmacen(eentidad.IDDISTRIBUCION, eentidad.IDESTABLECIMIENTO, IDPRODUCTO, tran)
            Dim cantidadDistribuir = dDistro.cantidadDistribuir(eentidad.IDDISTRIBUCION, eentidad.IDESTABLECIMIENTO, IDPRODUCTO, tran)

            If cantidadAlmacen < cantidadDistribuir Then
                tran.Abort()

                Return -2
            Else
                tran.Commit()

                Return 1
            End If



        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function


End Class
