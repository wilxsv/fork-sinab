Partial Public Class cDETALLESOLICITUDES

#Region " Metodos Creados "

    ''' <summary>
    ''' elimianr los productos del detalle de una determinada solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' Devuelve uno si la operacion se completo
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function EliminarDetallesSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        'Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.EliminarDettalesSolicitud(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function EliminarDetalledocumento(ByVal CODIGOENCABEZADODOCUMENTO As Int32, ByVal CODIGODETALLEDOCUMENTO As Int32, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim mEntidad As New DETALLESOLICITUDES
        mEntidad.IDSOLICITUD = CODIGOENCABEZADODOCUMENTO
        mEntidad.IDSOLICITUD = CODIGODETALLEDOCUMENTO
        mDb.Recuperar(mEntidad)

        If mDb.Eliminar(mEntidad) = -1 Then Return -1

        Dim mEntidadEncabezado As New SOLICITUDES
        Dim mDbEncabezado As New dbSOLICITUDES
        mEntidadEncabezado.IDSOLICITUD = CODIGOENCABEZADODOCUMENTO
        mDbEncabezado.Recuperar(mEntidadEncabezado)

        Dim mListaDetalle As listaDETALLESOLICITUDES
        mListaDetalle = mDb.ObtenerListaPorID(CODIGOENCABEZADODOCUMENTO, IDESTABLECIMIENTO)

        'Dim subtotal As Decimal = 0
        'For Each mDetalle In mListaDetalle
        '    subtotal += mDetalle.PRECIODETALLEDOCUMENTO * mDetalle.CANTIDADDETALLEDOCUMENTO
        'Next
        ' mEntidadEncabezado.SUBTOTALENCABEZADODOCUMENTO = subtotal
        'Dim iva As Decimal
        'iva = CDec((New cIvaporcentaje).ObtenerPorTipo((New cCliente).ObtenerCliente(mEntidadEncabezado.IDCLIENTE).TIPOIVACLIENTE).PORCENTAJEIVAPORCENTAJE)

        'mEntidadEncabezado.IVATOTALENCABEZADODOCUMENTO = (mEntidadEncabezado.SUBTOTALENCABEZADODOCUMENTO - (mEntidadEncabezado.SUBTOTALENCABEZADODOCUMENTO * mEntidadEncabezado.DESCUENTOENCABEZADODOCUMENTO / 100)) * iva / 100
        'mEntidadEncabezado.TOTALENCABEZADODOCUMENTO = (mEntidadEncabezado.SUBTOTALENCABEZADODOCUMENTO - (mEntidadEncabezado.SUBTOTALENCABEZADODOCUMENTO * mEntidadEncabezado.DESCUENTOENCABEZADODOCUMENTO / 100)) + mEntidadEncabezado.IVATOTALENCABEZADODOCUMENTO
        'Reserva de Productos
        'Dim mDbProducto As New dbCUADROBASICO
        'Dim mProductoInv As New CUADROBASICO
        'mProductoInv.IDPRODUCTO = mEntidad.IDPRODUCTO
        'mDbProducto.Recuperar(mProductoInv)
        'mProductoInv.RESERVADEPRODUCTO -= mEntidad.CANTIDADDETALLEDOCUMENTO
        'mProductoInv.USUARIOACTUALIZACION = EL.configuracion.usuarioActualizacion
        'mDbProducto.Actualizar(mProductoInv)

        Return mDbEncabezado.Actualizar(mEntidadEncabezado)

    End Function

    ''' <summary>
    ''' Calcular el monto total de la solicitud segun detalle de la misma
    ''' </summary>
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' Monto de la solicitud
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CalcularMontoTotalSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As String
        mEntidad.IDSOLICITUD = IDSOLICITUD
        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        Return mDb.CalularMontoTotalSolicitud(mEntidad)
    End Function

    ' Autor: José Chávez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Se utiliza para recuperar el consolidado de compras para una solicitud especifica
    ' Creación: 06/11/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerDsConsolidado(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Return mDb.ObtenerDsConsolidado(IDSOLICITUD, IDESTABLECIMIENTO)
    End Function

    ' Autor: José Chávez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Creación: 02/01/07 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerDsConsolidadoPorProducto(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int64, ByVal IDPRODUCTO As Int64) As DataSet
        Return mDb.ObtenerDsConsolidadoPorProducto(IDSOLICITUD, IDESTABLECIMIENTO, IDPRODUCTO)
    End Function

    ' Autor: José Chávez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Funcion utilizada para obtener el ID del detalle de una solicitud
    ' Creación: 06/11/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerID(ByVal aEntidad As entidadBase) As String
        Return mDb.ObtenerID(aEntidad)
    End Function

    ''' <summary>
    ''' obtener la informacion para mostra en grid de detalle de productos en la solicitud
    ''' </summary>
    ''' <param name="idSolicitud"></param> identificador de solicitud
    ''' <param name="IDEstablecimiento"></param> identificador del establecimiento
    ''' <returns>
    ''' dataset filtrado
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDsGridDetalleSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Return mDb.ObtenerDsGridDetalleSolicitud(IDSOLICITUD, IDESTABLECIMIENTO)
    End Function

    Public Function ObtenerDsGridDetalleSolicitud2(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Return mDb.ObtenerDsGridDetalleSolicitud2(IDSOLICITUD, IDESTABLECIMIENTO)
    End Function

    ''' <summary>
    ''' obtiene dataset de detalle de un producto por su codigo MSPAS
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <param name="IDCODIGOPRODUCTO"></param> codigo MSPAS del producto
    ''' <returns>
    ''' dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetPorCodigo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDCODIGOPRODUCTO As String) As DataSet
        'Try
            Return mDb.ObtenerDataSetPorCodigo(IDESTABLECIMIENTO, IDSOLICITUD, IDCODIGOPRODUCTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' valida si hay productos asociados a la solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDSOLICITUD"></param> identificador de solicitud
    ''' <returns>
    ''' Verdadero si hay productos asociados
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ExisteSolicitudesAsociadasSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Boolean
        'Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO

            Return mDb.ValidarHayProductoAsociadoSolicitud(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return False
        'End Try
    End Function

#End Region

#Region "TABLA PRODUCTOSSOLICITUD"
    Public Function obtenerProductosSolicitud(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer) As DataSet
        'Try
            Return mDb.obtenerProductosSolicitud(idestablecimiento, idsolicitud)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function obtenerProductos(ByVal TIPOUACI As Integer, ByVal idsolicitud As Integer, ByVal UNIDADTECNICA As String) As DataSet
        'Try
            Return mDb.obtenerProductos(TIPOUACI, idsolicitud, UNIDADTECNICA)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function obtenerProductosSolicitudConsolidar(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal IDDEPENDENCIA As Integer) As DataSet
        'Try
            Return mDb.obtenerProductosSolicitudConsolidar(idestablecimiento, idsolicitud, IDDEPENDENCIA)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function agregarProductossolicitud(ByVal lEntidad As PRODUCTOSSOLICITUD) As Integer

        'Try

            'Primero, revisamos si existe el producto
            Dim IDALMACEN As Integer = mDb.existeProductoSolicitud(lEntidad.IDESTABLECIMIENTO, lEntidad.IDSOLICITUD, lEntidad.IDPRODUCTO, lEntidad.IDESPECIFICACION)

            If IDALMACEN <> 0 Then Return 0

            'Ahora que lo tenemos todo, solo insertamos en la base
            Return mDb.agregarProductoSolicitudes(lEntidad)

        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try

    End Function
    Public Function actualizarProductoSolicitud(ByVal arr As ArrayList) As Integer

        Dim tran As New DistributedTransaction

        'Try

            For i As Integer = 0 To arr.Count - 1

                Dim lentidad As PRODUCTOSSOLICITUD = arr.Item(i)

                mDb.actualizarProductoSolicitud(lentidad, tran)

            Next

            tran.Commit()

            Return 0

        'Catch ex As Exception
            'tran.Abort()
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try

    End Function
    Public Function actualizarProductoSolicitud2(ByVal entidad As PRODUCTOSSOLICITUD) As Integer

        Dim tran As New DistributedTransaction

        'Try
            mDb.actualizarProductoSolicitud2(entidad, tran)
            tran.Commit()

            Return 0

        'Catch ex As Exception
            'tran.Abort()
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try

    End Function
    Public Function actualizarProductoSolicitud3(ByVal entidad As PRODUCTOSSOLICITUD) As Integer

        Dim tran As New DistributedTransaction

        'Try
            mDb.actualizarProductoSolicitud3(entidad, tran)
            tran.Commit()

            Return 0

        'Catch ex As Exception
            'tran.Abort()
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try

    End Function
    Public Function obtenerProductosSolicitud2(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer) As DataSet
        'Try
            Return mDb.obtenerProductosSolicitud2(idestablecimiento, idsolicitud)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
    Public Function ExisteDistribucion(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal renglon As Integer, ByVal idproducto As Integer) As Integer
        'Try
            Return mDb.ExisteDistribucion(idestablecimiento, idsolicitud, renglon, idproducto)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function

    Public Function obtenerProductosSolicitudDistribucion(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal renglon As Integer, ByVal idproducto As Integer) As DataSet
        'Try
            Return mDb.obtenerProductosSolicitudDistribucion(idestablecimiento, idsolicitud, renglon, idproducto)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
    Public Function InsertarDetallesSolicitudes(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal renglon As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer, ByVal usuariocreacion As String, ByVal identificadorproducto As Integer) As Integer
        'Try
            Return mDb.InsertarDetallesSolicitudes(idestablecimiento, idsolicitud, renglon, idproducto, idespecificacion, usuariocreacion, identificadorproducto)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
        'End Try
    End Function

    Public Function BorrarDetallesSolicitudes(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal iddependencia As Integer, ByVal IDESPECIFICACION As Integer, ByVal TRAN As DistributedTransaction) As Integer
        'Try
            Return mDb.BorrarDetalleSolicitudes(idestablecimiento, idsolicitud, idproducto, iddependencia, IDESPECIFICACION, TRAN)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
        'End Try
    End Function
    Public Function actualizarCANTIDADProductoSolicitud(ByVal cantidad As Integer, ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer) As Integer

        'Try
            Return mDb.actualizarCantidadProductoSolicitud(cantidad, idestablecimiento, idsolicitud, idproducto, idespecificacion)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
        'End Try

    End Function
    Public Function ObtenerSolicitudesAConsolidar(ByVal idclasesuministro As Integer, ByVal idestado As Integer) As DataSet
        'Try
            Return mDb.ObtenerSolicitudesAConsolidar(idclasesuministro, idestado)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
    Public Function ExisteProductosolicitud(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal IDESPECIFICACION As Integer) As Integer
        'Try
            Return mDb.existeProductoSolicitud(idestablecimiento, idsolicitud, idproducto, IDESPECIFICACION)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
    Public Function ExisteProductosolicitud2(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal IDESPECIFICACION As Integer) As Integer
        'Try
            Return mDb.ExisteProductosolicitud2(idestablecimiento, idsolicitud, idproducto, IDESPECIFICACION)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
    Public Function agregarESPECIFICACION(ByVal lEntidad As ESPECIFICACION) As Integer

        'Try

            'Primero, revisamos si existe el producto
            'Dim IDALMACEN As Integer = mDb.existeProductoSolicitud(lEntidad.IDESTABLECIMIENTO, lEntidad.IDSOLICITUD, lEntidad.IDPRODUCTO)

            'If IDALMACEN <> 0 Then Return 0

            'Ahora que lo tenemos todo, solo insertamos en la base
            Return mDb.agregarESPECIFICACION(lEntidad)

        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try

    End Function

    Public Function ObtenerEspecificacion(ByVal idestablecimiento As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer) As DataSet
        'Try
            Return mDb.ObtenerEspecificacion(idestablecimiento, idproducto, idespecificacion)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
    Public Function ExisteEspecificacion(ByVal idestablecimiento As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer) As Integer
        'Try
            Return mDb.ExisteEspecificacion(idestablecimiento, idproducto, idespecificacion)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
    Public Function EliminarProductoSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        'Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.EliminarDettalesSolicitud(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function EliminarPRODUCTOSSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        'Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.EliminarPRODUCTOSSolicitud(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function EliminarAlmacenesEntrega(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        'Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.EliminarAlmacenesEntrega(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function EliminarEntregas(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        'Try
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.EliminarEntregas(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function obtenerUnProductosSolicitud(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer) As DataSet
        'Try
            Return mDb.obtenerUnProductosSolicitud(idestablecimiento, idsolicitud, idproducto, idespecificacion)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
    Public Function BuscarEspecificacionTecnica(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal idespecificacion As Integer) As Integer
        'Try
            Return mDb.BuscarEspecificacionTecnica(idestablecimiento, idsolicitud, idproducto, idespecificacion)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)

        'End Try
    End Function
    Public Function agregarESPECIFICACIONESSOLICITUDES(ByVal lEntidad As ESPECIFICACIONESSOLICITUDES) As Integer

        'Try

            Return mDb.agregarESPECIFICACIONESSOLICITUDES(lEntidad)

        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try

    End Function
#End Region

End Class
