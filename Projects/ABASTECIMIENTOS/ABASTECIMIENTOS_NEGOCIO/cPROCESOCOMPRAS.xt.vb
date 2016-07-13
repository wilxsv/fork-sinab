
Partial Public Class cPROCESOCOMPRAS

#Region " Privadas "
    Private mDbSol As New dbDETALLESOLICITUDES
    Private mDbDetSolProc As New dbDETALLEPROCESOCOMPRA
    Private mDbSolicitud As New dbSOLICITUDES
    Private mDbSolProcCompra As New dbSOLICITUDESPROCESOCOMPRAS
#End Region

#Region "  Métodos Agregados  "

    Public Function ObtenerListapor_ESTADO(ByVal aENTIDAD As PROCESOCOMPRAS, ByVal EVAL_FECHA_RET As Boolean, ByVal EVAL_FECHA_REC As Boolean, Optional ByVal ESTADOS() As Integer = Nothing, Optional ByVal USUARIOCOMISION As String = "") As DataSet
        Try
            Return mDb.ObtenerListaPorESTADO(aENTIDAD, EVAL_FECHA_RET, EVAL_FECHA_REC, ESTADOS, USUARIOCOMISION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function AgregarPROCESOCOMPRAS(ByVal aEntidad As PROCESOCOMPRAS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function recuperarDatosProcesoCompra(ByVal aEntidad As PROCESOCOMPRAS) As DataSet
        Try
            Return mDb.RecuperarDatosProcesoCompra(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarPROCESOCOMPRASAperturaBase(ByVal aEntidad As PROCESOCOMPRAS) As Integer
        Try
            Return mDb.ActualizarAperturaBase(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarEstadoFinRecepcion(ByVal aEntidad As entidadBase) As Integer
        Try
            Return mDb.ActualizarEstadoFinRecepcion(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerDatasetActaAperturaOferta(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtenerDatasetActaAperturaOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDatasetEmpleadoAperturaOferta(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtieneDatasetEmpleadosAperturaOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarPROCESOCOMPRASpublicarBase(ByVal aEntidad As PROCESOCOMPRAS) As Integer
        Try
            Return mDb.ActualizarPublicarBase(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Sub RechazarSolicitud(ByVal idProcesoCompra As Integer, ByVal idSolicitud As Integer, ByVal idEstablecimiento As Integer)
        Try
            Dim dsDetSolicitud As DataSet
            Dim idSol, i, idProducto As Integer
            Dim cantidad, numEntrega As Decimal
            Dim lEntidad As New DETALLEPROCESOCOMPRA
            Dim dsDetalleProceso As DataSet
            Dim dr As DataRow()

            dsDetSolicitud = mDbSol.ObtenerDsDetalleSolicitud(idSolicitud, idEstablecimiento)

            For i = 0 To dsDetSolicitud.Tables(0).Rows.Count - 1
                With dsDetSolicitud.Tables(0).Rows(i)
                    idSol = .Item("IDPRODUCTO")
                    cantidad = .Item("CANTIDAD")
                    numEntrega = .Item("NUMEROENTREGAS")
                    idProducto = .Item("IDPRODUCTO")
                End With
                lEntidad.IDPROCESOCOMPRA = idProcesoCompra
                lEntidad.IDESTABLECIMIENTO = idEstablecimiento
                dsDetalleProceso = mDbDetSolProc.ObtenerDataSetPorID(idProcesoCompra, idEstablecimiento)
                dr = dsDetalleProceso.Tables(0).Select("IDPRODUCTO=" & idProducto)

                Dim SumCantidad As Decimal
                Dim numEntregas As Integer

                SumCantidad = dr(0).Item("CANTIDAD")
                numEntregas = dr(0).Item("NUMEROENTREGAS")

                lEntidad.IDPRODUCTO = dr(0).Item("IDPRODUCTO")
                lEntidad.IDDETALLE = dr(0).Item("IDDETALLE")

                If SumCantidad = cantidad Then

                    mDbDetSolProc.Eliminar(lEntidad)   'Elimino la solicitud del detalle del proceso compra
                    Dim lEntidadSolProcCompra As New SOLICITUDESPROCESOCOMPRAS
                    With lEntidadSolProcCompra
                        .IDESTABLECIMIENTO = idEstablecimiento
                        .IDPROCESOCOMPRA = idProcesoCompra
                        .IDSOLICITUD = idSolicitud
                    End With
                    Me.mDbSolProcCompra.Eliminar(lEntidadSolProcCompra)  'Elimino de solicprocesocompra
                Else
                    lEntidad.CANTIDAD = SumCantidad - cantidad

                    Dim ds As DataSet
                    ds = mDbSol.ObtenerRengloMaxEliminaSolicitud(idSolicitud, idProcesoCompra, idEstablecimiento)
                    lEntidad.NUMEROENTREGAS = ds.Tables(0).Rows(0).Item("NUMEROENTREGA")
                    mDbDetSolProc.ActualizarCantidad(lEntidad)
                    'Debe restarse la cantidad del total
                    Dim lEntidadSolProcCompra As New SOLICITUDESPROCESOCOMPRAS
                    With lEntidadSolProcCompra
                        .IDESTABLECIMIENTO = idEstablecimiento
                        .IDPROCESOCOMPRA = idProcesoCompra
                        .IDSOLICITUD = idSolicitud
                    End With
                    Me.mDbSolProcCompra.Eliminar(lEntidadSolProcCompra)  'Elimino de solicprocesocompra
                End If
            Next
            Dim lEntidadSolicitud As New SOLICITUDES
            lEntidadSolicitud.IDESTADO = 2
            mDbSolicitud.ActualizarEstado(lEntidadSolicitud)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Actualiza el estado del proceso de compra, registrando información adicional del mismo según corresponda.
    ''' Además permite: realizar la distribución de las cantidades por almacén, registrar precios históricos e inhabilitar al usuario de alto nivel.
    ''' </summary>
    ''' <param name="aEntidad">Entidad que contiene la información relativa al proceso de compra.</param>
    ''' <param name="DistribuirCantidadesAlmacen">Indica si se debe realizar la distribución por almacén.  Opcional.  Por defecto es falso.</param>
    ''' <param name="RegistrarPreciosHistoricos">Indica si se deben registrar los precios históricos.  Opcional.  Por defecto es falso.</param>
    ''' <param name="InhabilitarUsuarioComisionAltoNivel">Indica si se debe inhabilitar el usuario creado para la comisión de alto nivel.  Opcional.  Por defecto es falso.</param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarEstado(ByVal aEntidad As PROCESOCOMPRAS, ByVal MOMENTO As Integer, Optional ByVal DistribuirCantidadesAlmacen As Boolean = False, Optional ByVal RegistrarPreciosHistoricos As Boolean = False, Optional ByVal InhabilitarUsuarioComisionAltoNivel As Boolean = False) As Integer
        Try
            If DistribuirCantidadesAlmacen Then
                Dim cU As New cUTILERIAS
                cU.calcularDistribucionEntregas(aEntidad.IDESTABLECIMIENTO, aEntidad.IDPROCESOCOMPRA, aEntidad.AUUSUARIOMODIFICACION, MOMENTO)
            End If
            If RegistrarPreciosHistoricos Then
                Dim cHP As New cHISTORICOPRECIOS
                'cHP.RegistrarPreciosHistoricos(aEntidad.IDESTABLECIMIENTO, aEntidad.IDPROCESOCOMPRA, aEntidad.AUFECHAMODIFICACION, aEntidad.AUUSUARIOMODIFICACION, aEntidad.AUFECHAMODIFICACION)
                'AQUI SE ACTUALIZAR PRECIOS DE PRODUCTOS EN EL CATALOGO DE PRODUCTOS
                Dim cc As New cCATALOGOPRODUCTOS
                'cc.ActualizarPreciosCatalogoProductos(aEntidad.IDESTABLECIMIENTO, aEntidad.IDPROCESOCOMPRA)
            End If


            If InhabilitarUsuarioComisionAltoNivel Then
                Dim cCPC As New cCOMISIONPROCESOCOMPRA
                cCPC.InhabilitarUsuarioComisionAltoNivel(aEntidad.IDESTABLECIMIENTO, aEntidad.IDPROCESOCOMPRA)
            End If
            Return mDb.ActualizarEstado(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerCodigoyTipoLicitacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerCodigoyTipoLicitacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerInfoLicitacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32, ByRef ds As DataSet) As DataSet
        Try
            Return mDb.ObtenerInfoLicitacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la información relacionada con un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>ArrayList.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerInfoLicitacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Integer) As ArrayList
        Try
            Return mDb.ObtenerInfoLicitacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarValores_GenerarBases(ByVal aEntidad As PROCESOCOMPRAS, ByVal flag As Integer) As Integer
        Try
            Return mDb.ActualizarValores_GenerarBases(aEntidad, flag)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarValores_GenerarBasesLibreGestion(ByVal aEntidad As PROCESOCOMPRAS) As Integer
        Try
            Return mDb.ActualizarValores_GenerarBasesLibreGestion(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerDetalleProductos(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As Data.DataSet
        Try
            Return mDb.obtenerDetalleProductos(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerLugarPlazoEntrega(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As Data.DataSet
        Try
            Return mDb.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerLugarPlazoEntrega(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64, ByVal ENTREGA As Integer) As Data.DataSet
        Try
            Return mDb.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, IDESTABLECIMIENTO, ENTREGA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener los procesos de compra que cumplan con un estado en particular
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDESTADO"></param> 'identificado del estado del proceso de compra
    ''' <returns>
    ''' Dataset con los prcesos de compra que cumpla con el estado
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetEstado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADO As Int32) As DataSet
        Try
            Return mDb.ObtenerProcesoCompraEstado(IDESTABLECIMIENTO, IDESTADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtiene un filtro de procesos de compras por codigo de proceso de compra utilizado por MSPAS
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'Identificador dele stablecimiento
    ''' <param name="IDESTADO"></param> 'identificar el estado del proceso
    ''' <param name="IDCODIGO"></param> 'codigo del proceso de compras utilizado por el MSPAS
    ''' <returns>
    ''' Dataset con los procesos de compra filtrados por codigo
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetEstadoXCodigo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADO As Int32, ByVal IDCODIGO As String) As DataSet
        Try
            Return mDb.ObtenerProcesoCompraEstadoXCodigo(IDESTABLECIMIENTO, IDESTADO, IDCODIGO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener las ofertas de un proceso de compra filtradas por estado del proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDESTADO"></param> 'identificador del estado del proceso de compra
    ''' <param name="IDPROCESO"></param> 'identificador del proceso de compra
    ''' <returns>
    ''' Dataset con las ofertas que cumplen con el filtro
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerOfertasPrcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADO As Int32, ByVal IDPROCESO As Int32) As DataSet
        Try
            Return mDb.ObtenerOfertasProcesoCompra(IDESTABLECIMIENTO, IDESTADO, IDPROCESO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' validar si faltan documentos faltantes de la oferta en la entrega 1
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROCESO"></param> 'identificador del proceso de compra
    ''' <param name="IDPROVEEDOR"></param> 'identificador del proveedor
    ''' <returns>
    ''' verdadero si faltaron documentos en primera entrega
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function FaltanDocumentosOfertaEntrega1(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean
        Try
            Return mDb.FaltanDocumentosOfertaEntrega1(IDESTABLECIMIENTO, IDPROCESO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' validacion si falta documentos de la oferta para la segunda entrega
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROCESO"></param> 'identificador del proceso de compra
    ''' <param name="IDPROVEEDOR"></param> 'identificador del proveedor
    ''' <returns>
    ''' verdadero si falta documentacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function FaltanDocumentosOfertaEntrega2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean
        Try
            Return mDb.FaltanDocumentosOfertaEntrega2(IDESTABLECIMIENTO, IDPROCESO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Validacion si faltaron entregar documentos del renglon para la entrega 1
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROCESO"></param> 'identificador del proceso
    ''' <param name="IDPROVEEDOR"></param> 'identificador del proveedor
    ''' <returns>
    ''' verdadero si faltaron documentos que entregar
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function FaltanDocumentosRenglonOfertaEntrega1(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean
        Try
            Return mDb.FaltanDocumentosRenglonesOfertaEntrega1(IDESTABLECIMIENTO, IDPROCESO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Validacion si faltaron documentos del renglon para la segunda entrega
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROCESO"></param> 'identificador del procesod de compra
    ''' <param name="IDPROVEEDOR"></param> 'identificacion del proveedor
    ''' <returns>
    ''' verdadero si falto documentacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function FaltanDocumentosRenglonOfertaEntrega2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean
        Try
            Return mDb.FaltanDocumentosRenglonesOfertaEntrega2(IDESTABLECIMIENTO, IDPROCESO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' informacion para el reporte de hoja de analisis para un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROCESO"></param> 'identificador del proceso de compra
    ''' <returns>
    ''' Dataset con la informacion de hoja de analisis
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerHojaAnalisis(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32) As DataSet
        Try
            Return mDb.ObtenerHojaAnalisis(IDESTABLECIMIENTO, IDPROCESO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerHojaAnalisis2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32) As DataSet
        Try
            Return mDb.ObtenerHojaAnalisis2(IDESTABLECIMIENTO, IDPROCESO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerHojaAnalisisXProveedor(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.ObtenerHojaAnalisisXProveedor(IDESTABLECIMIENTO, IDPROCESO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' informacion para reprote de hoja analisis con los renglones desiertos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROCESO"></param> 'identificador del proceso de compra
    ''' <returns>
    ''' datase con la informacion de la hoja de analisis renglones desiertos
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerHojaAnalisisDesierto(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32) As DataSet
        Try
            Return mDb.ObtenerHojaAnalisisDesierto(IDESTABLECIMIENTO, IDPROCESO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' informacion para el reporte de resolucion de adjudicacion
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROCESO"></param> 'identificador del proceso de compras
    ''' <returns>
    ''' Dataset con la informacion de la resolucion de adjudicacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerResolucionAdjudicacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, Optional ByVal idalmacen As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerResolucionAdjudicacion(IDESTABLECIMIENTO, IDPROCESO, idalmacen)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener todos aquello documentos que no fuenron entregados por el ofertante en la primera entrega
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROCESO"></param> 'identificador del proceso
    ''' <param name="IDPROVEEDOR"></param> 'identificador del proveedor
    ''' <returns>
    ''' Dataset con la informacion de la documentacion faltante del ofertante
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDocumentosFaltantesOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet
        Try
            Return mDb.ObtenerDocumentosFaltantesOferta(IDESTABLECIMIENTO, IDPROCESO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener todos aquellos documentos que no fuenron entregados por el ofertante para un renglon especifico en la primera entrega
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROCESO"></param> 'identificador del proceso de compra
    ''' <param name="IDPROVEEDOR"></param> 'identificador del proveedor
    ''' <returns>
    ''' Dataset con los documentos faltantes para el renglon
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDocumentosFaltantesRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDGRUPOREQTEC As Integer) As DataSet
        Try
            Return mDb.ObtenerDocumentosFaltantesRenglon(IDESTABLECIMIENTO, IDPROCESO, IDPROVEEDOR, IDGRUPOREQTEC)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function generarProgramaDistribucion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal USUARIOCREACION As String, ByVal FECHACREACION As String, ByVal BORRAR As String) As Integer
        Try
            Return mDb.generarProgramaDistribucion(IDESTABLECIMIENTO, IDPROCESO, USUARIOCREACION, FECHACREACION, BORRAR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerRenglonesProcesoCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerRenglonesProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProgramaDistribucion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDRENGLON As Integer) As DataSet
        Try
            Return mDb.obtenerProgramaDistribucion(IDESTABLECIMIENTO, IDPROCESO, IDRENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarNotificacion(ByVal aEntidad As PROCESOCOMPRAS) As Integer
        Try
            Return mDb.ActualizarNotificacion(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerExamenFinanciero(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtenerExamenFinanciero(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerExamenEvalFinanciero(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtenerExamenEvalFinanciero(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDocumentosOfertaEP(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obtenerDocumentosOfertaEP(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerExamenRenglonEP(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal idrectec As Integer, ByVal IDPRODUCTO As String) As DataSet
        Try
            Return mDb.obtenerExamenRenglonEP(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, idrectec, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerTipoProcesoCompra(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtenerTipoProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function validaExisteBase(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.validaExisteBase(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerParametrosGeneraContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerParametrosGeneraContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ChequearEstadosSolicitudes(ByVal IDPROCESOCOMPRAS As Integer, ByVal IDESTABLECIMIENTO As Integer) As Boolean
        Try
            Return mDb.ChequearEstadoSolicitudes(IDESTABLECIMIENTO, IDPROCESOCOMPRAS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNoActaApertura(ByVal IDESTABLECIMIENTO As Int32, ByVal NOACTA As String) As DataSet
        Try
            Return mDb.ObtenerNoActaApertura(IDESTABLECIMIENTO, NOACTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProveedoresProcesoCompraDS(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerProveedoresProcesoCompraDS(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProveedoresContratoDS(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, Optional ByVal IDANALISTA As Integer = 0) As DataSet
        Try
            Return mDb.obtenerProveedoresContratoDS(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDANALISTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProveedoresContratoDS_LG(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, Optional ByVal IDANALISTA As Integer = 0) As DataSet
        Try
            Return mDb.obtenerProveedoresContratoDS_LG(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDANALISTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerProveedoresOficioAdj(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerProveedoresOficioAdj(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ChequearEstadosPC(ByVal IDPROCESOCOMPRAS As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer
        Try
            Return mDb.ChequearEstadoPC(IDESTABLECIMIENTO, IDPROCESOCOMPRAS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function verificarDesiertos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer
        Try
            Return mDb.verificarDesiertos(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerFechaLimiteAceptacion(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As Date
        Try
            Return mDb.ObtenerFechaLimiteAceptacion(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetProcesoCompraPorPeriodo(ByVal Fini As Date, ByVal Ffin As Date, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetProcesoCompraPorPeriodo(Fini, Ffin, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'metodo elaborado por: Boris Martinez
    'descripción: obtener todos los procesos de compra de un establecimiento para saber el estado y el analista asignado.
    Public Function ObtenerProcesoCompraAnalista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADO As Int32, ByVal IDEMPLEADO As Int32, ByVal Todos As Boolean) As DataSet
        Try
            Return mDb.ObtenerConsultaProcesoCompra(IDESTABLECIMIENTO, IDESTADO, IDEMPLEADO, Todos)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function eliminarProcesoCompleto(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer
        Return mDb.eliminarProcesoCompleto(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
    End Function

    Public Function obtenerTitular(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Return mDb.obtenerTitular(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
    End Function

    Public Function obtenerTitularAdjudicacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Return mDb.obtenerTitularAdjudicacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
    End Function

    Public Function validarExistenciaCodigoLicitacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Boolean
        Return mDb.validarExistenciaCodigoLicitacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
    End Function

    Public Function validarExistenciaCodigoLicitacion2(ByVal IDESTABLECIMIENTO As Integer, ByVal CODIGOLICITACION As String) As Boolean
        Return mDb.validarExistenciaCodigoLicitacion2(IDESTABLECIMIENTO, CODIGOLICITACION)
    End Function

    Public Function obtenerCifradoPresupuestario(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As String
        Return mDb.obtenerCifradoPresupuestario(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
    End Function

    ''' <summary>
    ''' Devuelve el detalle de un proceso de compra de un establecimiento especifico.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento. (Filtro)</param>
    ''' <param name="IDPROCESOCOMPRA ">Identificador del proceso compra. (Filtro)</param>
    ''' <returns>Dataset con el detalle de un proceso compra.</returns>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  01/02/2007    Creado
    ''' </history> 
    Public Function ObtenerProcesoCompraReporte(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerProcesoCompraReporte(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerGarantiaMttoProducto(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerGarantiaMttoProducto(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerMiembros(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As String
        Try
            Return mDb.ObtenerMiembros(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return String.Empty
        End Try
    End Function

    Public Function ObtenerListaProveedores(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As String
        Try
            Return mDb.ObtenerListaProveedores(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return String.Empty
        End Try
    End Function

    Public Function obtenerMaxFechaRecepcion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Return mDb.obtenerMaxFechaRecepcion(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
    End Function

    Public Function obtenerNvoDatasetEmpleadoAperturaOferta(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtieneNvoDatasetEmpleadosAperturaOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function dsConsultarMontoSolicitado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Decimal
        Try
            Return mDb.dsConsultarMontoSolicitado(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function dsTotalAdjudicado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Decimal
        Try
            Return mDb.dsTotalAdjudicado(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerExamenRenglonGeneral(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerExamenRenglonGeneral(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProcesoCompraDV(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerProcesoCompraDV(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProcesoCompraAviso(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerProcesoCompraAviso(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDatosAvisoAdjudicacionFirme(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerDatosAvisoAdjudicacionFirme(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerInformacionProceso(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerInformacionProceso(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerTipoSuministro(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerTipoSuministro(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDsProcesoCompra(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDsProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerAnexo1(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.ObtenerAnexo1(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProcesoCompraAdjudicados() As DataSet
        Try
            Return mDb.ObtenerProcesoCompraAdjudicados()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerPC_Solicitud(ByVal IDESTABLECIMIENTO As Integer, ByVal flag As Integer, ByVal VALOR As String) As DataSet
        Try
            Return mDb.ObtenerPC_Solicitud(IDESTABLECIMIENTO, flag, VALOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerFF_Solicitud(ByVal IDESTABLECIMIENTO As Integer, ByVal IDSOLICITUD As Integer) As DataSet
        Try
            Return mDb.ObtenerFF_Solicitud(IDESTABLECIMIENTO, IDSOLICITUD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerGrupoReqDoc(ByVal IDPRODUCTO As Integer) As Integer
        Try
            Return mDb.ObtenerGrupoReqDoc(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class
