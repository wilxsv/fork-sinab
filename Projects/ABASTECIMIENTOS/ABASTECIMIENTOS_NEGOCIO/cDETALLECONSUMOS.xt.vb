Partial Public Class cDETALLECONSUMOS

#Region " Metodos agregados "

    ''' <summary>
    ''' Obtiene una lista de detalle de consumo filtrada por consumo y establecimiento
    ''' </summary>
    ''' <param name="CODIGOENCABEZADODOCUMENTO"></param> 'identificador del consumo
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <returns>
    ''' lista de detalle de consumo filtrada
    ''' </returns>
    ''' <remarks></remarks>
    Public Function ObtenerLista(ByVal CODIGOENCABEZADODOCUMENTO As Int32, ByVal IDESTABLECIMIENTO As Int32) As listaDETALLECONSUMOS
        Try
            Return mDb.ObtenerListaPorID(CODIGOENCABEZADODOCUMENTO, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' elimina unicamente un elemento detalle de consumo
    ''' </summary>
    ''' <param name="IDDETALLE"></param> 'identificador del detalle de consumo
    ''' <param name="IDCONSUMO"></param> 'identificador del consumo
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <returns>
    ''' Elimina un registro detalle de producto
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function EliminarDETALLECONSUMOS(ByVal IDDETALLE As Int64, ByVal IDCONSUMO As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            mEntidad.IDDETALLE = IDDETALLE
            mEntidad.IDCONSUMO = IDCONSUMO
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' obtiene el correlativo de detalla de consumo
    ''' </summary>
    ''' <param name="aEntidad"></param> entidada tipoDETALLECONSUMOS
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function IdDetalleConsumo(ByVal aEntidad As DETALLECONSUMOS) As Integer
        Try
            Return mDb.ObtenerID(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Devuelve el numero de productos en el detalle de consumo
    ''' </summary>
    ''' <param name="IDCONSUMO"></param> 'identificador de consumo
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' el numero entero de productos
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ContarConsumos(ByVal IDCONSUMO As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            Return mDb.ContarProductos(IDCONSUMO, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Elimina el detalle de un consumo
    ''' </summary>
    ''' <param name="IDCONSUMO"></param> 'identificador de consumo
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' devuelve uno si todo fue correcto
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function EliminarDetalles(ByVal IDCONSUMO As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            mEntidad.IDCONSUMO = IDCONSUMO
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.EliminarDetalles(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Agregar un detaale de consumo nuevo
    ''' </summary>
    ''' <param name="aEntidad"></param> 'entidad tipoDETALLECONSUMOS
    ''' <returns>
    ''' Devuelve uno si se completo la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function AgregarDETALLECONSUMOS(ByVal aEntidad As DETALLECONSUMOS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' obtener la informacion de un producto del detalle filtrado por codigo
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDCONSUMO"></param> 'identificador del consumo
    ''' <param name="IDCODIGOPRODUCTO"></param> 'codigo de producto utilizado por MSPAS
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetPorCodigo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64, ByVal IDCODIGOPRODUCTO As String) As DataSet
        Try
            Return mDb.ObtenerDataSetPorCodigo(IDESTABLECIMIENTO, IDCONSUMO, IDCODIGOPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Validadr que existan productos asociados a un consumo
    ''' </summary>
    ''' <param name="IDCONSUMO"></param> identificador del consumo
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <returns>
    ''' Verdadero si hay productos para el consumo
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ExisteProductosAsociadosConsumo(ByVal IDCONSUMO As Int64, ByVal IDESTABLECIMIENTO As Int32) As Boolean
        Try
            mEntidad.IDCONSUMO = IDCONSUMO
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO

            Return mDb.ValidarHayProductoAsociadoConsumo(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Recupera la informacion de productos de un consumo
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDCONSUMO"></param> 'identificador de consumo
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetDetalleConsumo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetDetalleConsumo(IDESTABLECIMIENTO, IDCONSUMO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function RptDemandaInsatisfecha(ByVal FECHADESDE As DateTime, ByVal FECHAHASTA As DateTime, ByVal IDESTABLECIMIENTO As Integer, ByVal IDZONA As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDSUBGRUPO As Integer, ByVal IDPRODUCTO As Integer) As DataSet
        Try
            Return mDb.RptDemandaInsatisfecha(FECHADESDE, FECHAHASTA, IDESTABLECIMIENTO, IDZONA, IDSUMINISTRO, IDGRUPO, IDSUBGRUPO, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptConsumoInventario(ByVal FECHADESDE As DateTime, ByVal FECHAHASTA As DateTime, ByVal IDESTABLECIMIENTO As Integer, ByVal IDZONA As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDSUBGRUPO As Integer, ByVal IDPRODUCTO As Integer) As DataSet
        Try
            Return mDb.RptConsumoInventario(FECHADESDE, FECHAHASTA, IDESTABLECIMIENTO, IDZONA, IDSUMINISTRO, IDGRUPO, IDSUBGRUPO, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ExistenciasCriticos(ByVal IDPRODUCTO As Integer) As DataSet
        Try
            Return mDb.ExistenciasCriticos(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ComprasTransitoCriticos(ByVal IDPRODUCTO As Integer) As DataSet
        Try
            Return mDb.ComprasTransitoCriticos(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function PromedioConsumoCriticos(ByVal IDPRODUCTO As Integer) As DataSet
        Try
            Return mDb.PromedioConsumoMensualCriticos(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ProximoAVencerCriticos(ByVal IDPRODUCTO As Integer, ByVal FECHA As Date) As DataSet
        Try
            Return mDb.ProximosAvencerCriticos(IDPRODUCTO, FECHA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
