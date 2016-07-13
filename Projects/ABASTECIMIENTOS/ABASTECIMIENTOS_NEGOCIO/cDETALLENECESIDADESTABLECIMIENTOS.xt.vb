Partial Public Class cDETALLENECESIDADESTABLECIMIENTOS

#Region "metodos agregados"

    ''' <summary>
    ''' obtiene la informacion del detalle de la necesidad para un codigo MSPAS de producto
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identificador de la necesidad
    ''' <param name="IDCODIGOPRODUCTO"></param> 'codigo de producto utilizado por MSPAS
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetPorCodigo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDCODIGOPRODUCTO As String) As DataSet
        Try
            Return mDb.ObtenerDataSetPorCodigo(IDESTABLECIMIENTO, IDNECESIDAD, IDCODIGOPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtiene un listado de detalle de productos por necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> identificador de necesidad
    ''' <param name="IDPRODUCTO"></param> identificador de producto
    ''' <returns>
    ''' listado de detalle por necesidad
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int32) As listaDETALLENECESIDADESTABLECIMIENTOS
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDNECESIDAD, IDPRODUCTO)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaxEstablecimiento(ByVal IDESTABLECIMIENTO As Int64, ByVal IDNECESIDAD As Integer, ByVal PROPUESTA As Integer, ByVal ANIOINICIOPERIODO As Integer, ByVal IDSUMINISTRO As Integer) As DataSet
        Try
            Return mDb.ObtenerListaPorIDEstablecimiento(IDESTABLECIMIENTO, IDNECESIDAD, PROPUESTA, ANIOINICIOPERIODO, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaxGRUPO(ByVal IDESTABLECIMIENTO As Int64, ByVal IDNECESIDAD As Integer, ByVal IDGRUPO As Integer) As listaDETALLENECESIDADESTABLECIMIENTOS
        Try
            Return mDb.ObtenerListaPorGrupo(IDESTABLECIMIENTO, IDNECESIDAD, IDGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaxSUBGRUPO(ByVal IDESTABLECIMIENTO As Int64, ByVal IDNECESIDAD As Integer, ByVal IDSUBGRUPO As Integer) As listaDETALLENECESIDADESTABLECIMIENTOS
        Try
            Return mDb.ObtenerListaPorSubGrupo(IDESTABLECIMIENTO, IDNECESIDAD, IDSUBGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaxCodProducto(ByVal IDESTABLECIMIENTO As Int64, ByVal IDNECESIDAD As Integer, ByVal codProducto As String, ByVal IDSUMINISTRO As Integer) As DataSet
        Try
            Return mDb.ObtenerListaPorCodProducto(IDESTABLECIMIENTO, IDNECESIDAD, codProducto, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerAyudaExterna(ByVal BIDPADRE As Int32, ByVal BIDPRODUCTO As Int64) As Int64
        Try
            Return mDb.ObtenerAyudaExterna(BIDPADRE, BIDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
        End Try
    End Function

    ''' <summary>
    ''' obtener informacion de detalle de productos para una necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identificador de necesidad
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetDetalleNecesidad(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As DataSet
        Return mDb.ObtenerDataSetDetalleNecesidad(IDESTABLECIMIENTO, IDNECESIDAD)
    End Function

    ''' <summary>
    ''' obtener la informacion de un producto en la necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identificador de la necesidad
    ''' <param name="IDPRODUCTO"></param> 'identificador del producto
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetDetalleNecesidadPorProducto(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int32) As DataSet
        Return mDb.ObtenerDataSetDetalleNecesidadPorProducto(IDESTABLECIMIENTO, IDNECESIDAD, IDPRODUCTO)
    End Function

    Public Function ObtenerDsDetalleNecesidadPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSUMINISTRO As Int32) As DataSet
        ' Autor: José Chávez
        '-------------------------------------------------------------------------------------------------------------------------
        ' Utilidad: Se utiliza para recuperar del detalle de la necesidad de un producto especifico y devolver en un dataset
        ' Creación: 26/10/06 
        '-------------------------------------------------------------------------------------------------------------------------

        Return mDb.ObtenerDsDetalleNecesidadPorId(IDESTABLECIMIENTO, IDNECESIDAD, IDSUMINISTRO)
    End Function

    ''' <summary>
    ''' obtener informacion de´productos de la necesidad filtrado por un tipo de criterio
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identificador de la necesidad
    ''' <param name="IDSUMINISTRO"></param> 'identificador del suministro
    ''' <param name="TIPOCRITERIO"></param> 'identificador del tipo de criterio del filtro
    ''' <param name="CADENABUSQUEDA"></param> 'cadena a buscar
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDsDetalleNecesidadPorIdFiltrado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSUMINISTRO As Int32, ByVal TIPOCRITERIO As Int16, ByVal CADENABUSQUEDA As String) As DataSet
        Return mDb.ObtenerDsDetalleNecesidadPorIdFiltrado(IDESTABLECIMIENTO, IDNECESIDAD, IDSUMINISTRO, TIPOCRITERIO, CADENABUSQUEDA)

    End Function

    ' Autor: José Chávez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Se utiliza para recuperar del detalle de la estimacion de necesidades y devolver en un dataset
    ' Creación: 06/11/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerDsDetalleNecesidadPorPropuesta(ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int32) As DataSet
        Return mDb.ObtenerDsDetalleNecesidadPorPropuesta(IDANIO, IDPROPUESTA)
    End Function

    'Jose Chavez
    Public Function ObtenerDsDetalleNecesidadPorPropuestaFiltrada(ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int32, ByVal TIPOCRITERIO As Int16, ByVal CADENABUSQUEDA As String) As DataSet
        Return mDb.ObtenerDsDetalleNecesidadPorPropuestaFiltrada(IDANIO, IDPROPUESTA, TIPOCRITERIO, CADENABUSQUEDA)
    End Function

    ' Autor: José Chávez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Se utiliza para recuperar del detalle de la estimacion de necesidades y devolver en un dataset
    '           filtrado por año, propuesta y producto
    ' Creación: 24/11/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerDsDetalleNecesidadPorPropuestaPorProducto(ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int32, ByVal IDPRODUCTO As Int64) As DataSet
        Return mDb.ObtenerDsDetalleNecesidadPorPropuestaPorProducto(IDANIO, IDPROPUESTA, IDPRODUCTO)
    End Function

    ' Autor: José Chávez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Funcion utilizada para consolidar todas las estimaciones de necesidades hechas por los establecimientos
    '           y que genera el detalle de la solicitud o programa de compras.
    ' Creación: 06/11/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ConsolidarEstimaciones(ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int32, ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer

        Dim mCompDetalleSolicitud As New cDETALLESOLICITUDES
        Dim mEntDetalleSolicitud As New DETALLESOLICITUDES
        Dim iRenglon As Int64 = 0
        Dim iFila As Int64
        Dim dCantidadTotal As Decimal = 0

        Dim dsDetalleNecesidades As DataSet
        dsDetalleNecesidades = ObtenerDsDetalleNecesidadPorPropuesta(IDANIO, IDPROPUESTA)

        If IsNothing(dsDetalleNecesidades) Then
            Return 1     'Retorno el valor de uno cuando la actualizacion no se pudo realizar por algun error de datos
        Else
            For iFila = 0 To (dsDetalleNecesidades.Tables(0).Rows.Count - 1)
                'ESTA EVALUACION ES TEMPORAL
                If Not (dsDetalleNecesidades.Tables(0).Rows(iFila).Item("NECESIDADFINAL") Is DBNull.Value) And (dsDetalleNecesidades.Tables(0).Rows(iFila).Item("NECESIDADFINAL") > 0) Then
                    iRenglon = iRenglon + 1
                    mEntDetalleSolicitud.IDSOLICITUD = IDSOLICITUD
                    mEntDetalleSolicitud.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                    mEntDetalleSolicitud.IDDETALLE = 0
                    mEntDetalleSolicitud.RENGLON = iRenglon
                    mEntDetalleSolicitud.IDPRODUCTO = dsDetalleNecesidades.Tables(0).Rows(iFila).Item("IDPRODUCTO")
                    'Colocar procedimiento para obtener alternativa producto

                    'mEntDetalleSolicitud.CANTIDAD = dsDetalleNecesidades.Tables(0).Rows(iFila).Item("NECESIDADFINAL")
                    dCantidadTotal = ObtenerCantidadAlternativa(mEntDetalleSolicitud.IDPRODUCTO, IDANIO, IDPROPUESTA)
                    If dCantidadTotal > 0 Then
                        mEntDetalleSolicitud.CANTIDAD = dsDetalleNecesidades.Tables(0).Rows(iFila).Item("NECESIDADFINAL") + dCantidadTotal
                    Else
                        mEntDetalleSolicitud.CANTIDAD = dsDetalleNecesidades.Tables(0).Rows(iFila).Item("NECESIDADFINAL")
                    End If
                    '********************************************************
                    mEntDetalleSolicitud.IDUNIDADMEDIDA = dsDetalleNecesidades.Tables(0).Rows(iFila).Item("IDUNIDADMEDIDA")
                    mEntDetalleSolicitud.PRESUPUESTOUNITARIO = IIf(dsDetalleNecesidades.Tables(0).Rows(iFila).Item("PRECIOUNITARIO") Is DBNull.Value, 0, dsDetalleNecesidades.Tables(0).Rows(iFila).Item("PRECIOUNITARIO"))
                    mEntDetalleSolicitud.PRESUPUESTOTOTAL = mEntDetalleSolicitud.CANTIDAD * mEntDetalleSolicitud.PRESUPUESTOUNITARIO
                    mEntDetalleSolicitud.NUMEROENTREGAS = 1
                    mEntDetalleSolicitud.AUUSUARIOCREACION = 1
                    mEntDetalleSolicitud.AUFECHACREACION = Now()
                    mEntDetalleSolicitud.AUUSUARIOMODIFICACION = 1
                    mEntDetalleSolicitud.AUFECHAMODIFICACION = Now()
                    mEntDetalleSolicitud.ESTASINCRONIZADA = 0

                    mCompDetalleSolicitud.ActualizarDETALLESOLICITUDES(mEntDetalleSolicitud)
                End If

            Next iFila
            Return 0     'Retorno el valor de cero cuando la actualizacion fue todo un exito
        End If

    End Function

    Public Function ObtenerCantidadAlternativa(ByVal IDPRODUCTO As Int64, ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int16) As Decimal
        ' Autor: José Chávez
        '-------------------------------------------------------------------------------------------------------------------------
        ' Utilidad: Funcion utilizada para obtener la cantidad total de las diferentes alternativas para un producto
        ' Creación: 14/12/06 
        '-------------------------------------------------------------------------------------------------------------------------
        Dim mCompAlternativas As New cALTERNATIVASPRODUCTO
        Dim dsConsolidadoPorProducto As DataSet
        Dim dTotalCantidad As Decimal = 0
        Dim iFila As Int64

        Dim dsAlternativasPorProducto As DataSet
        dsAlternativasPorProducto = mCompAlternativas.ObtenerDsAlternativas(IDPRODUCTO)

        If dsAlternativasPorProducto.Tables(0).Rows.Count > 0 Then
            For iFila = 0 To dsAlternativasPorProducto.Tables(0).Rows.Count - 1
                'Recuperando la cantidad por alternativa
                dsConsolidadoPorProducto = ObtenerDsDetalleNecesidadPorPropuestaPorProducto(IDANIO, IDPROPUESTA, dsAlternativasPorProducto.Tables(0).Rows(iFila).Item("IDALTERNATIVA"))
                If dsConsolidadoPorProducto.Tables(0).Rows.Count > 0 Then
                    dTotalCantidad = dTotalCantidad + dsConsolidadoPorProducto.Tables(0).Rows(0).Item("NECESIDADFINAL")
                End If
            Next
        Else
            Dim IDPRODUCTO2 As Int64 = 0
            IDPRODUCTO2 = mCompAlternativas.ObtenerDsAlternativasDe(IDPRODUCTO)
            If IDPRODUCTO2 > 0 Then
                dTotalCantidad = ObtenerCantidadAlternativa(IDPRODUCTO2, IDANIO, IDPROPUESTA)
            End If
        End If

        Return dTotalCantidad
    End Function

    ''' <summary>
    ''' eliminar los productos de una necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identidiacdor de necesidad
    ''' <returns>
    ''' Devuelve uno si se completo con la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function EliminarDETALLES(ByVal IDNECESIDAD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDNECESIDAD = IDNECESIDAD
            Return mDb.EliminarDetalleNecesidad(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Calcular el monto de la necesidad real
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identidiacdor de necesidad
    ''' <returns>
    ''' El monto real de la necesidad
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CalcularMontoRealNecesidad(ByVal IDNECESIDAD As Int64, ByVal IDESTABLECIMIENTO As Int32) As String
        'Calcular el monto total de la necesidad segun detalle de la misma
        mEntidad.IDNECESIDAD = IDNECESIDAD
        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        Return mDb.CalularMontoRealNecesidad(mEntidad)
    End Function

    ''' <summary>
    ''' calcular el monto de la necesidad ajustada
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identidiacdor de necesidad
    ''' <returns>
    ''' Monto de la necesidad ajustada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CalcularMontoAjustadoNecesidad(ByVal IDNECESIDAD As Int64, ByVal IDESTABLECIMIENTO As Int32) As String
        'Calcular el monto ajustado de la necesidad segun detalle de la misma
        mEntidad.IDNECESIDAD = IDNECESIDAD
        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        Return mDb.CalularMontoAjustadoNecesidad(mEntidad)
    End Function

    ''' <summary>
    ''' calcula el monto de la necesidad final
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identidiacdor de necesidad
    ''' <returns>
    ''' Monto de la necesidad final
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>

    Public Function CalcularMontoFinalNecesidad(ByVal IDNECESIDAD As Int64, ByVal IDESTABLECIMIENTO As Int32) As String
        'Calcular el monto final de la necesidad segun detalle de la misma
        mEntidad.IDNECESIDAD = IDNECESIDAD
        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        Return mDb.CalularMontoFinalNecesidad(mEntidad)
    End Function

    ''' <summary>
    ''' obtiene un listado de los detalle de productos de una necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identidiacdor de necesidad
    ''' <returns>
    ''' lista filtrada por necesidad
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerListaxNecesidad(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As listaDETALLENECESIDADESTABLECIMIENTOS
        Try
            Return mDb.ObtenerListaPorNececidad(IDESTABLECIMIENTO, IDNECESIDAD)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' valida existencia de productos asociados a la necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDNECECIDAD"></param> identificador de necesidad
    ''' <returns>
    ''' Verdadero si hay productos asociados a la necesidad
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ExisteProductosAsociadosNecesidad(ByVal IDNECECIDAD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Boolean
        Try
            mEntidad.IDNECESIDAD = IDNECECIDAD
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO

            Return mDb.ValidarHayProductoAsociadoNececidad(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

#End Region

#Region "Funciones Consolidado Con Programas"

    Public Function ConsolidarEstimacionesConProgramas(ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int32, ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROGRAMA As Int32) As Integer
        ' Autor: José Chávez
        '-------------------------------------------------------------------------------------------------------------------------
        ' Utilidad: Funcion utilizada para consolidar todas las estimaciones de necesidades hechas por los establecimientos
        '           y que genera el detalle de la solicitud o programa de compras.
        ' Creación: 06/11/06 
        '-------------------------------------------------------------------------------------------------------------------------

        Dim mCompDetalleSolicitud As New cDETALLESOLICITUDES
        Dim mEntDetalleSolicitud As New DETALLESOLICITUDES
        Dim iRenglon As Int64 = 0
        Dim iFila As Int64
        Dim dCantidadTotal As Decimal = 0

        Dim dsDetalleNecesidades As DataSet
        dsDetalleNecesidades = ObtenerDsDetalleNecesidadPorPropuestaConProgramas(IDANIO, IDPROPUESTA, IDPROGRAMA)

        If IsNothing(dsDetalleNecesidades) Then
            Return 1     'Retorno el valor de uno cuando la actualizacion no se pudo realizar por algun error de datos
        Else
            For iFila = 0 To (dsDetalleNecesidades.Tables(0).Rows.Count - 1)
                'ESTA EVALUACION ES TEMPORAL
                If Not (dsDetalleNecesidades.Tables(0).Rows(iFila).Item("NECESIDADFINAL") Is DBNull.Value) And (dsDetalleNecesidades.Tables(0).Rows(iFila).Item("NECESIDADFINAL") > 0) Then
                    iRenglon = iRenglon + 1
                    mEntDetalleSolicitud.IDSOLICITUD = IDSOLICITUD
                    mEntDetalleSolicitud.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                    mEntDetalleSolicitud.IDDETALLE = 0
                    mEntDetalleSolicitud.RENGLON = iRenglon
                    mEntDetalleSolicitud.IDPRODUCTO = dsDetalleNecesidades.Tables(0).Rows(iFila).Item("IDPRODUCTO")
                    'Colocar procedimiento para obtener alternativa producto

                    'mEntDetalleSolicitud.CANTIDAD = dsDetalleNecesidades.Tables(0).Rows(iFila).Item("NECESIDADFINAL")
                    dCantidadTotal = ObtenerCantidadAlternativa(mEntDetalleSolicitud.IDPRODUCTO, IDANIO, IDPROPUESTA)
                    If dCantidadTotal > 0 Then
                        mEntDetalleSolicitud.CANTIDAD = dsDetalleNecesidades.Tables(0).Rows(iFila).Item("NECESIDADFINAL") + dCantidadTotal
                    Else
                        mEntDetalleSolicitud.CANTIDAD = dsDetalleNecesidades.Tables(0).Rows(iFila).Item("NECESIDADFINAL")
                    End If
                    '********************************************************
                    mEntDetalleSolicitud.IDUNIDADMEDIDA = dsDetalleNecesidades.Tables(0).Rows(iFila).Item("IDUNIDADMEDIDA")
                    mEntDetalleSolicitud.PRESUPUESTOUNITARIO = IIf(dsDetalleNecesidades.Tables(0).Rows(iFila).Item("PRECIOUNITARIO") Is DBNull.Value, 0, dsDetalleNecesidades.Tables(0).Rows(iFila).Item("PRECIOUNITARIO"))
                    mEntDetalleSolicitud.PRESUPUESTOTOTAL = mEntDetalleSolicitud.CANTIDAD * mEntDetalleSolicitud.PRESUPUESTOUNITARIO
                    mEntDetalleSolicitud.NUMEROENTREGAS = 1
                    mEntDetalleSolicitud.AUUSUARIOCREACION = 1
                    mEntDetalleSolicitud.AUFECHACREACION = Now()
                    mEntDetalleSolicitud.AUUSUARIOMODIFICACION = 1
                    mEntDetalleSolicitud.AUFECHAMODIFICACION = Now()
                    mEntDetalleSolicitud.ESTASINCRONIZADA = 0

                    mCompDetalleSolicitud.ActualizarDETALLESOLICITUDES(mEntDetalleSolicitud)
                End If

            Next iFila
            Return 0     'Retorno el valor de cero cuando la actualizacion fue todo un exito
        End If

    End Function

    Public Function ObtenerDsDetalleNecesidadPorPropuestaConProgramas(ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int32, ByVal IDPROGRAMA As Int32) As DataSet
        'JOSE CHAVEZ
        Return mDb.ObtenerDsDetalleNecesidadPorPropuestaConProgramas(IDANIO, IDPROPUESTA, IDPROGRAMA)
    End Function

#End Region

End Class
