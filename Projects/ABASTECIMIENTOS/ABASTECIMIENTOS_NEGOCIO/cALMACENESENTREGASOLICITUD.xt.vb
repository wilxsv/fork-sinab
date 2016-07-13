Partial Class cALMACENESENTREGASOLICITUD

    Public Function obtenerAlmacenesEntrega(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer) As DataSet

        'Try
            Return mDb.obtenerAlmacenesEntrega(idestablecimiento, idsolicitud)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
    Public Function borrarAlmacenesEntrega(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer) As Integer
        Dim tran As New DistributedTransaction

        'Try
            mDb.borrarAlmacenesEntrega(IDSOLICITUD, IDESTABLECIMIENTO, IDALMACEN, tran)
            tran.Commit()

            Return 1
        'Catch ex As Exception
            'tran.Abort()
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function borrarAlmacenesEntregaSolicitud(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer


        'Try
            mDb.borrarAlmacenesEntregaSolicitud(IDSOLICITUD, IDESTABLECIMIENTO)


            Return 1
        'Catch ex As Exception

            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function ingresarALMACENESENTREGA(ByVal eEntidad As ALMACENESENTREGA) As Integer
        Dim tran As New DistributedTransaction
        'Try

            mDb.ingresarALMACENESENTREGA(eEntidad, tran)
            tran.Commit()

            Return 1
        'Catch ex As Exception
            'tran.Abort()
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try

    End Function
    Public Function borrarAlmacenesEntregaSolicitud(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer, ByVal RENGLON As Integer, ByVal IDPRODUCTO As Integer, ByVal idfuente As Integer) As Integer
        Dim tran As New DistributedTransaction

        'Try
            mDb.borrarAlmacenesEntregaSolicitud(IDSOLICITUD, IDESTABLECIMIENTO, IDALMACEN, idfuente, RENGLON, IDPRODUCTO, tran)
            tran.Commit()

            Return 1
        'Catch ex As Exception
            'tran.Abort()
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function ObtenerSumaCantidad(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACENENTREGA As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal RENGLON As Integer, ByVal IDPRODUCTO As Integer) As Integer
        'Try
            Return mDb.ObtenerSumaCantidad(IDSOLICITUD, IDESTABLECIMIENTO, IDALMACENENTREGA, IDFUENTEFINANCIAMIENTO, RENGLON, IDPRODUCTO)

        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function actualizarCantidad(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal identrega As Integer, ByVal numeroentrega As Integer, ByVal renglon As Integer, ByVal idproducto As Integer, ByVal idalmacen As Integer, ByVal idfuente As Integer, ByVal cantidad As Integer, ByVal preciounitario As Decimal) As Integer
        Dim tran As New DistributedTransaction
        'Try

            mDb.ActualizarCantidad(idestablecimiento, idsolicitud, identrega, numeroentrega, renglon, idproducto, idalmacen, idfuente, cantidad, preciounitario, tran)
            tran.Commit()

            Return 1
        'Catch ex As Exception
            'tran.Abort()
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try

    End Function

    Public Function ExistenRegistrosAES(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer, Optional ByVal RENGLON As Integer = 0) As Integer
        'Try
            Return mDb.ExistenRegistrosAES(IDSOLICITUD, IDESTABLECIMIENTO, IDPRODUCTO, RENGLON)

        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function borrarAlmacenesEntregaSolicitudyPS(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer, ByVal iddependencia As Integer, ByVal idespecificacion As Integer) As Integer
        Dim tran As New DistributedTransaction

        'Try
            'borrar AES
            mDb.borrarProductoAlmacenesEntregaSolicitud(IDSOLICITUD, IDESTABLECIMIENTO, IDPRODUCTO, idespecificacion, tran)
            'borrar ES
            Dim ces As New cENTREGASOLICITUDES
        ces.EliminarEntregasXsolicitudProducto(IDESTABLECIMIENTO, IDSOLICITUD, IDPRODUCTO)
            'borrar ds
            Dim cdso As New cDETALLESOLICITUDES
            cdso.EliminarDETALLESOLICITUDES(IDESTABLECIMIENTO, IDSOLICITUD, IDPRODUCTO, idespecificacion)
            'borrar ps
            Dim cds As New cDETALLESOLICITUDES
            cds.BorrarDetallesSolicitudes(IDESTABLECIMIENTO, IDSOLICITUD, IDPRODUCTO, iddependencia, idespecificacion, tran)
            tran.Commit()

            Return 1
        'Catch ex As Exception
            'tran.Abort()
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function ExistenRegistrosAES_LE(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer) As Integer
        'Try
            Return mDb.ExistenRegistrosAES_LE(IDSOLICITUD, IDESTABLECIMIENTO, IDALMACEN)

        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function ExistenRegistrosAES_FE(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDFUENTE As Integer) As Integer
        'Try
            Return mDb.ExistenRegistrosAES_FE(IDSOLICITUD, IDESTABLECIMIENTO, IDFUENTE)

        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function borrarAlmacenesEntregaSolicitudyAE(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer) As Integer
        Dim tran As New DistributedTransaction

        'Try
            mDb.borrarAlmacenesEntregaSolicitud_AE(IDSOLICITUD, IDESTABLECIMIENTO, IDALMACEN, tran)
            mDb.borrarAlmacenesEntrega(IDSOLICITUD, IDESTABLECIMIENTO, IDALMACEN, tran)
            tran.Commit()

            Return 1
        'Catch ex As Exception
            'tran.Abort()
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function borrarAlmacenesEntregaSolicitudyFF(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDFUENTE As Integer) As Integer
        Dim tran As New DistributedTransaction

        'Try
            mDb.borrarAlmacenesEntregaSolicitud_FF(IDSOLICITUD, IDESTABLECIMIENTO, IDFUENTE, tran)
            Dim cffs As New cFUENTEFINANCIAMIENTOSOLICITUDES
            cffs.EliminarFUENTEFINANCIAMIENTOSOLICITUDES(IDESTABLECIMIENTO, IDSOLICITUD, IDFUENTE)

            tran.Commit()

            Return 1
        'Catch ex As Exception
            'tran.Abort()
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function ObtenerMontosxFuente(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        'Try
            Return mDb.ObtenerMontosxFuente(IDSOLICITUD, IDESTABLECIMIENTO)

        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
End Class
