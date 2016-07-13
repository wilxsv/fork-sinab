Partial Public Class cDETALLEMOVIMIENTOS

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDTIPOTRANSACCION"></param>
    ''' <param name="IDMOVIMIENTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerDetalleMovimientosDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDetalleMovimientosDS(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDetalleMovimientoSalida(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDetalleMovimientoSalida(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="FECHADESDE"></param>
    ''' <param name="FECHAHASTA"></param>
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param>
    ''' <param name="IDRESPONSABLEDISTRIBICION"></param>
    ''' <param name="PRODUCTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function MovimientosPorProducto(ByVal IDALMACEN As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBICION As Integer, ByVal IDPRODUCTO As String, ByVal CODIGO As String, ByVal IDGRUPO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer) As DataSet
        'Try
        Return mDb.MovimientosPorProducto(IDALMACEN, FECHADESDE, FECHAHASTA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBICION, IDPRODUCTO, CODIGO, IDGRUPO, IDGRUPOFUENTEFINANCIAMIENTO)
        'Catch ex As Exception
        '    ExceptionManager.Publish(ex)
        '    Return Nothing
        'End Try


    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="FECHADESDE"></param>
    ''' <param name="FECHAHASTA"></param>
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION"></param>
    ''' <param name="IDSUMINISTRO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function IngresosGeneralesPorTipoProducto(ByVal IDALMACEN As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal orden As Int16, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal fos As Integer, ByVal IDESPECIFICOGASTO As Integer, ByVal transf As Integer) As DataSet
        Try
            Return mDb.IngresosGeneralesPorTipoProducto(IDALMACEN, FECHADESDE, FECHAHASTA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDSUMINISTRO, IDGRUPO, orden, IDGRUPOFUENTEFINANCIAMIENTO, fos, IDESPECIFICOGASTO, transf)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="FECHADESDE"></param>
    ''' <param name="FECHAHASTA"></param>
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION"></param>
    ''' <param name="IDSUMINISTRO"></param>
    ''' <param name="IDESTABLECIMIENTODESTINO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function DespachosGeneralesPorTipoProducto(ByVal IDALMACEN As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDESTABLECIMIENTODESTINO As Integer, ByVal orden As Int16, ByVal IDGRUPOFUENTEFINANCIAMIENTOS As Integer, ByVal fos As Integer, ByVal IDESPECIFICOGASTO As Integer, ByVal TRANSF As Integer) As DataSet
        Try
            Return mDb.DespachosGeneralesPorTipoProducto(IDALMACEN, FECHADESDE, FECHAHASTA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDSUMINISTRO, IDGRUPO, IDESTABLECIMIENTODESTINO, orden, IDGRUPOFUENTEFINANCIAMIENTOS, fos, IDESPECIFICOGASTO, TRANSF)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDTIPOTRANSACCION"></param>
    ''' <param name="IDMOVIMIENTO"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function BuscarProductoDetalle(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int16, ByVal IDMOVIMIENTO As Int64, ByVal IDPRODUCTO As Int64) As Int32
        Return mDb.BuscarProductoDetalle(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO, IDPRODUCTO)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDMOVIMIENTO"></param>
    ''' <param name="aListaMovimientos"></param>
    ''' <param name="aListaLotes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarDETALLEMOVIMIENTOS(ByVal IDMOVIMIENTO As Integer, ByVal aListaMovimientos As listaDETALLEMOVIMIENTOS, ByVal aListaLotes As listaLOTES) As Integer

        Dim cL As New cLOTES
        Dim cEA As New cEXISTENCIASALMACENES

        For Each eDM As DETALLEMOVIMIENTOS In aListaMovimientos

            cL.ActualizarLOTES(aListaLotes.BuscarPorId(eDM.IDALMACEN, eDM.IDLOTE))

            'Actualizar existencias por almacén
            If eDM.CANTIDAD > 0 Then

                Dim eEA As New EXISTENCIASALMACENES
                eEA.IDALMACEN = eDM.IDALMACEN
                eEA.IDPRODUCTO = eDM.IDPRODUCTO

                If cEA.ObtenerEXISTENCIASALMACENES(eEA) = 1 Then
                    Select Case eDM.IDTIPOTRANSACCION
                        Case 4 'Actualización de existencia +
                            eEA.CANTIDADDISPONIBLE = eEA.CANTIDADDISPONIBLE + eDM.CANTIDAD
                        Case 5 'Actualización de existencia -
                            eEA.CANTIDADDISPONIBLE = eEA.CANTIDADDISPONIBLE - eDM.CANTIDAD
                    End Select
                Else
                    eEA.CANTIDADDISPONIBLE = eDM.CANTIDAD
                End If

                cEA.ActualizarEXISTENCIASALMACENES(eEA)
            End If

            eDM.IDMOVIMIENTO = IDMOVIMIENTO
            mDb.Actualizar(eDM)
        Next

        Return 1

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDTIPOSUMINISTRO"></param>
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param>
    ''' <param name="IDRESPONSABLEDISTRIBICION"></param>
    ''' <param name="FEC1"></param>
    ''' <param name="FEC2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerIngresosGenerales(ByVal IDALMACEN As Int32, ByVal IDTIPOSUMINISTRO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Int64, ByVal IDRESPONSABLEDISTRIBICION As Int16, ByVal FEC1 As Date, ByVal FEC2 As Date) As DataSet
        Try
            Return mDb.ObtenerIngresosGenerales(IDALMACEN, IDTIPOSUMINISTRO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBICION, FEC1, FEC2)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="ANIO"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <param name="IDESTABLECIMIENTODESTINO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function RptDespachosMensualesXProducto(ByVal IDALMACEN As Int32, ByVal ANIO As Int16, ByVal PRODUCTO As String, ByVal IDESTABLECIMIENTODESTINO As Int64, ByVal IDP As Integer) As DataSet
        Try
            Return mDb.RptDespachosMensualesXProducto(IDALMACEN, ANIO, PRODUCTO, IDESTABLECIMIENTODESTINO, IDP)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="ANIO"></param>
    ''' <param name="IDSUMINISTRO"></param>
    ''' <param name="IDESTABLECIMIENTODESTINO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function RptDespachosMensualesXTipoProducto(ByVal IDALMACEN As Int32, ByVal ANIO As Int16, ByVal IDSUMINISTRO As Int64, ByVal IDESTABLECIMIENTODESTINO As Int64) As DataSet
        Try
            Return mDb.RptDespachosMensualesXTipoProducto(IDALMACEN, ANIO, IDSUMINISTRO, IDESTABLECIMIENTODESTINO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDSUMINISTRO"></param>
    ''' <param name="MESPERIODO"></param>
    ''' <param name="ANIOPERIODO"></param>
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param>
    ''' <param name="MONTOINICIAL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function RptContabilidadAlmacen(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal MESPERIODO As Integer, ByVal ANIOPERIODO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, Optional ByVal MONTOINICIAL As Decimal = 0) As DataSet
        Try
            Return mDb.RptContabilidadAlmacen(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, MONTOINICIAL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarDETALLEMOVIMIENTOS2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDTIPOTRANSACCION = IDTIPOTRANSACCION
            mEntidad.IDMOVIMIENTO = IDMOVIMIENTO
            Return mDb.Eliminar2(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarCantidades(ByVal aEntidad As DETALLEMOVIMIENTOS, Optional ByVal OPERACIONCANTIDADDISPONIBLE As Int16 = 0, Optional ByVal OPERACIONCANTIDADNODISPONIBLE As Int16 = 0, Optional ByVal OPERACIONCANTIDADRESERVADA As Int16 = 0, Optional ByVal OPERACIONCANTIDADVENCIDA As Int16 = 0, Optional ByVal OPERACIONCANTIDADTEMPORAL As Int16 = 0) As Integer
        Try
            Return mDb.ActualizarCantidades(aEntidad, OPERACIONCANTIDADDISPONIBLE, OPERACIONCANTIDADNODISPONIBLE, OPERACIONCANTIDADRESERVADA, OPERACIONCANTIDADVENCIDA, OPERACIONCANTIDADTEMPORAL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarLoteDespacho(ByVal aEntidad As DETALLEMOVIMIENTOS, Optional ByVal OPERACIONCANTIDADDISPONIBLE As Int16 = 0, Optional ByVal OPERACIONCANTIDADNODISPONIBLE As Int16 = 0, Optional ByVal OPERACIONCANTIDADRESERVADA As Int16 = 0, Optional ByVal OPERACIONCANTIDADVENCIDA As Int16 = 0, Optional ByVal OPERACIONCANTIDADTEMPORAL As Int16 = 0) As Integer
        Try
            Return mDb.EliminarLoteDespacho(aEntidad, OPERACIONCANTIDADDISPONIBLE, OPERACIONCANTIDADNODISPONIBLE, OPERACIONCANTIDADRESERVADA, OPERACIONCANTIDADVENCIDA, OPERACIONCANTIDADTEMPORAL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function AgregarLoteRecepcion(ByVal eL As LOTES, ByVal eDM As DETALLEMOVIMIENTOS, ByVal eU As UBICACIONESPRODUCTOS, ByVal lAEC As listaALMACENESENTREGACONTRATOS) As Integer
        Try
            Dim cL As New cLOTES
            eL.IDLOTE = cL.ObtenerID(eL)
            Return mDb.AgregarLoteRecepcion(eL, eDM, eU, lAEC)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarLoteRecepcion(ByVal eDM As DETALLEMOVIMIENTOS, ByVal lAEC As listaALMACENESENTREGACONTRATOS) As Integer
        Return mDb.EliminarLoteRecepcion(eDM, lAEC)
    End Function

    Public Function CerrarDespacho(ByVal eM As MOVIMIENTOS, ByVal eVS As VALESSALIDA, ByVal esFarmacia As Boolean) As Integer
        Try
            Return mDb.CerrarDespacho(eM, eVS, esFarmacia)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function CerrarDespacho2(ByVal eM As MOVIMIENTOS, ByVal esFarmacia As Boolean) As Integer
        Try
            Return mDb.CerrarDespacho2(eM, esFarmacia)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function CerrarRecepcion(ByVal eM As MOVIMIENTOS, ByVal eRR As RECIBOSRECEPCION) As Integer
        Try
            Return mDb.CerrarRecepcion(eM, eRR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptContabilidadAlmacen2(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal MESPERIODO As Integer, ByVal ANIOPERIODO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, Optional ByVal MONTOINICIAL As Decimal = 0, Optional ByVal SinFosalud As Integer = 0, Optional ByVal IDESPECIFICOGASTO As Integer = 0) As DataSet
        Try
            Return mDb.RptContabilidadAlmacen2(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, MONTOINICIAL, SinFosalud, IDESPECIFICOGASTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptContabilidadAlmacen3(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal MESPERIODO As Integer, ByVal ANIOPERIODO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, Optional ByVal MONTOINICIAL As Decimal = 0, Optional ByVal SinFosalud As Integer = 0, Optional ByVal IDESPECIFICOGASTO As Integer = 0) As DataSet
        Try
            Return mDb.RptContabilidadAlmacen3(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, MONTOINICIAL, SinFosalud, IDESPECIFICOGASTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerInventarioInicial(ByVal MESPERIODO As Integer, ByVal ANIOPERIODO As Integer, ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, Optional ByVal SinFosalud As Integer = 0, Optional ByVal IDESPECIFICOGASTO As Integer = 0) As Decimal
        Try
            Return mDb.ObtenerInventarioInicial(MESPERIODO, ANIOPERIODO, IDALMACEN, IDSUMINISTRO, IDGRUPOFUENTEFINANCIAMIENTO, SinFosalud, IDESPECIFICOGASTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptContabilidadAlmacenFOSALUD(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal MESPERIODO As Integer, ByVal ANIOPERIODO As Integer, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, Optional ByVal MONTOINICIAL As Decimal = 0, Optional ByVal IDESPECIFICOGASTO As Integer = 0) As DataSet
        Try
            Return mDb.RptContabilidadAlmacenFOSALUD(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, MONTOINICIAL, IDESPECIFICOGASTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerSuministrosMovimiento(ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOTRANSACCION As Integer, ByVal IDMOVIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerSuministrosMovimiento(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
