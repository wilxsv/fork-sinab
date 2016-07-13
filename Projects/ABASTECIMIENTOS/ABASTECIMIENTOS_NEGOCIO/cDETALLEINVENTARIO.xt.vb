Partial Class cDETALLEINVENTARIO

    ''' <summary>
    ''' obtener la informacion del detalle de productos de un inventario
    ''' </summary>
    ''' <param name="IDINVENTARIO"></param> identificador de inventario
    ''' <param name="IDALMACEN"></param> identificador de almacen
    ''' <param name="IDDETALLE"></param> 'identificador de detalle de producto
    ''' <returns>
    ''' Dataset filtrado
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDsDetalleInventario(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, Optional ByVal IDDETALLE As Int32 = 0) As DataSet
        Try
            Return mDb.ObtenerDsDetalleInventario(IDALMACEN, IDINVENTARIO, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Recupera la informacion de un producto especifico del detalle
    ''' </summary>
    ''' <param name="mEntidad"></param> entidad tipo DETALLEINVENTARIO
    ''' <returns>
    ''' devuelve uno si la operacion se completo
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDetalleProducto(ByRef mEntidad As DETALLEINVENTARIO) As DETALLEINVENTARIO
        mDb.RecuperarDetalleProducto(mEntidad)
        Return mEntidad
    End Function

    ''' <summary>
    ''' Elimina los productos del detalle de un inventario
    ''' </summary>
    ''' <param name="IDINVENTARIO"></param> identificador de inventario
    ''' <param name="IDALMACEN"></param> identificador de almacen
    ''' <returns>
    ''' devuelve uno si la operacion se completo
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function EliminarInventarioDetalle(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDINVENTARIO = IDINVENTARIO
            Return mDb.EliminarDetalleInventario(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function AjusteInventario(ByVal eCA As CORRECCIONESALMACENES, ByVal eM As MOVIMIENTOS, ByVal eDMDisponible As DETALLEMOVIMIENTOS, ByVal eDMNoDisponible As DETALLEMOVIMIENTOS, ByVal eDMVencida As DETALLEMOVIMIENTOS, ByVal eL As LOTES, ByVal eDI As DETALLEINVENTARIO) As Integer
        Try
            Return mDb.AjusteInventario(eCA, eM, eDMDisponible, eDMNoDisponible, eDMVencida, eL, eDI)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
