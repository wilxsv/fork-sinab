Partial Public Class cADJUDICACION

#Region "  Métodos Agregados  "

    Public Function obtenerDatasetProveedoresAdjudicados(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtenerDatasetProveedoresAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDatasetProveedoresAdjudicadosConNotas(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtenerDatasetProveedoresAdjudicadosConNotas(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptObtenerDatasetProveedoresAdjudicadosConNotas(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.RptObtenerDatasetProveedoresAdjudicadosConNotas(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptObtenerDatasetProveedoresAdjudicadosSolvencias(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.RptObtenerDatasetProveedoresAdjudicadosSolvencias(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCantidades(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer) As DataSet
        Try
            Return mDb.ObtenerCantidades(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Para un renglón dado, actualiza las tablas correspondientes según el proceso que se realiza (recomendación, adjudicación o adjudicación en firme):
    ''' 1. Actualiza las entregas (porcentajes y plazos) según lo indicado por el analista.
    ''' 2. Redistribuye proporcionalmente las cantidades de acuerdo a lo solicitado, en caso de que se recomiende/adjudique una cantidad inferior a la solicitada.
    ''' 3. Actualiza el estado del renglón (recomendado/adjudicado/no adjudicado).
    ''' 4. Actualiza las observaciones que se hayan ingresado para el renglón.
    ''' </summary>
    ''' <param name="aA">Entidad ADJUDICACION.</param>
    ''' <param name="aLista">Lista de entidades ENTREGAADJUDICACION.</param>
    ''' <param name="aDPC">Entidad DETALLEPROCESOCOMPRA.</param>
    ''' <param name="TipoCantidad">Identificador que permite determinar el proceso que se está realizando.  Valores: 1 recomendación de compra, 2 resolución de adjudicación, 3 adjudicación en firme.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function AgregarCantidadesYEntregas(ByVal aA As ADJUDICACION, ByVal aLista As listaENTREGAADJUDICACION, ByVal aDPC As DETALLEPROCESOCOMPRA, ByVal TipoCantidad As Integer, ByVal momento As Integer) As Integer

        Try
            Dim totalOferta As Decimal
            Dim totalPorRenglon As Decimal

            Dim cE As New cENTREGAADJUDICACION
            cE.EliminarEntregasPorOferta(aA.IDESTABLECIMIENTO, aA.IDPROCESOCOMPRA, aA.IDPROVEEDOR, aA.IDDETALLE, momento)

            mDb.AgregarCantidad(aA)

            Select Case TipoCantidad
                Case Is = 1 'cantidad recomendada
                    aDPC.IDESTADOCALIFICACION = 4
                    totalOferta = aA.CANTIDADRECOMENDACION
                    totalPorRenglon = ObtenerTotalRecomendadoPorRenglon(aDPC.IDESTABLECIMIENTO, aDPC.IDPROCESOCOMPRA, aDPC.RENGLON)
                Case Is = 2 'cantidad adjudicada
                    aDPC.IDESTADOCALIFICACION = 6
                    totalOferta = aA.CANTIDADADJUDICADA
                    totalPorRenglon = ObtenerTotalAdjudicadoPorRenglon(aDPC.IDESTABLECIMIENTO, aDPC.IDPROCESOCOMPRA, aDPC.RENGLON)
                Case Is = 3 'cantidad adjudicada en firme
                    aDPC.IDESTADOCALIFICACION = 6
                    totalOferta = aA.CANTIDADFIRME
                    totalPorRenglon = ObtenerTotalAdjudicadoEnFirmePorRenglon(aDPC.IDESTABLECIMIENTO, aDPC.IDPROCESOCOMPRA, aDPC.RENGLON)
            End Select

            cE.DistribuirCantidadTotalPorEntrega(totalOferta, aLista)

            cE.AgregarEntregasPorOferta(aLista, 2)

            Dim cPD As New cPROGRAMADISTRIBUCION
            cPD.ActualizarCantidadAdjudicadaPorSolicitud(aDPC.IDESTABLECIMIENTO, aDPC.IDPROCESOCOMPRA, aDPC.RENGLON, totalPorRenglon, aDPC.AUUSUARIOMODIFICACION, aDPC.AUFECHAMODIFICACION)

            Dim cDPC As New cDETALLEPROCESOCOMPRA
            cDPC.ActualizarEstadoCalificacionProcesoCompra(aDPC)

            cDPC.ActualizarObservaciones(aDPC)

            Return 1

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Elimina o actualiza (según corresponda) las cantidades y entregas recomendadas/adjudicadas para una oferta dada.
    ''' </summary>
    ''' <param name="aA">Entidad ADJUDICACION.</param>
    ''' <param name="aDPC">Entidad DETALLEPROCESOCOMPRA.</param>
    ''' <param name="TipoCantidad">Identificador que permite determinar el proceso que se está realizando.  Valores: 1 recomendación de compra, 2 resolución de adjudicación, 3 adjudicación en firme.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarCantidadesYEntregasPorOferta(ByVal aA As ADJUDICACION, ByVal aDPC As DETALLEPROCESOCOMPRA, ByVal TipoCantidad As Integer, ByVal MOMENTO As Integer) As Integer
        Try
            Dim cE As New cENTREGAADJUDICACION
            cE.EliminarEntregasPorOferta(aA.IDESTABLECIMIENTO, aA.IDPROCESOCOMPRA, aA.IDPROVEEDOR, aA.IDDETALLE, MOMENTO)

            Select Case TipoCantidad
                Case Is = 1 'cantidad recomendada
                    mDb.Eliminar(aA)
                Case Is = 2 'cantidad adjudicada
                    mDb.ActualizarCantidadAdjudicada(aA)
                Case Is = 3
                    mDb.ActualizarCantidadAdjudicadaEnFirme(aA)
            End Select

            Dim cDPC As New cDETALLEPROCESOCOMPRA
            aDPC.IDESTADOCALIFICACION = 7
            cDPC.ActualizarEstadoCalificacionProcesoCompraNoAdjudicado(aDPC)

            Return 0
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarCantidadRecomendada(ByVal aEntidad As ADJUDICACION) As Integer
        Try
            Return mDb.ActualizarCantidadRecomendada(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarCantidadAdjudicada(ByVal aEntidad As ADJUDICACION) As Integer
        Try
            Return mDb.ActualizarCantidadAdjudicada(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarCantidadAdjudicadaEnFirme(ByVal aEntidad As ADJUDICACION) As Integer
        Try
            Return mDb.ActualizarCantidadAdjudicadaEnFirme(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="aA"></param>
    ''' <param name="aDPC"></param>
    ''' <param name="TipoCantidad"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarCantidadesYEntregasPorRenglon(ByVal aA As ADJUDICACION, ByVal aDPC As DETALLEPROCESOCOMPRA, ByVal TipoCantidad As Int32) As Integer
        Try
            Dim cE As New cENTREGAADJUDICACION
            cE.EliminarEntregasPorRenglon(aA.IDESTABLECIMIENTO, aA.IDPROCESOCOMPRA, aDPC.RENGLON)

            Select Case TipoCantidad
                Case Is = 1 'cantidad recomendada
                    mDb.EliminarCantidadRecomendadaPorRenglon(aA.IDESTABLECIMIENTO, aA.IDPROCESOCOMPRA, aDPC.RENGLON)
                Case Is = 2 'cantidad adjudicada
                    mDb.ActualizarCantidadAdjudicadaPorRenglon(aA, aDPC.RENGLON)
                Case Is = 3 'cantidad adjudicada en firme
                    mDb.ActualizarCantidadAdjudicadaEnFirmePorRenglon(aA, aDPC.RENGLON)
            End Select

            Dim cDPC As New cDETALLEPROCESOCOMPRA
            aDPC.IDESTADOCALIFICACION = 7
            cDPC.ActualizarEstadoCalificacionProcesoCompra(aDPC)

            Return 0
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la cantidad total recomendada a un renglón dado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>Decimal.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerTotalRecomendadoPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Int32) As Decimal
        Try
            Return mDb.ObtenerTotalRecomendadoPorRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la cantidad total adjudicada a un renglón dado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>Decimal.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerTotalAdjudicadoPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Int32) As Decimal
        Try
            Return mDb.ObtenerTotalAdjudicadoPorRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la cantidad total adjudicada en firme a un renglón dado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>Decimal.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerTotalAdjudicadoEnFirmePorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Int32) As Decimal
        Try
            Return mDb.ObtenerTotalAdjudicadoEnFirmePorRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerCantidadAdjudicadaProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obtenerCantidadAdjudicadaProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerCantidadAdjudicadaProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obtenerCantidadAdjudicadaProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerRenglonesAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, Optional ByVal TIPOADJUDICACION As Integer = 0, Optional ByVal IDINSPECTOR As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerRenglonesAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, TIPOADJUDICACION, IDINSPECTOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerRenglonesAdjudicadosOfiAdj(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.ObtenerRenglonesAdjudicadosOfiAdj(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerRenglonesAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerRenglonesAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerRenglonAdjudicadoProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obtenerRenglonAdjudicadoProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCantidadProveedores(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As Integer
        Try
            Return mDb.ObtenerCantidadProveedores(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerRenglonRecomendado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obtenerRenglonRecomendado(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ResolucionModificada(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Boolean
        Try
            Return mDb.ResolucionModificada(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptNotificacionAdjudicacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32) As DataSet
        Try
            Return mDb.RptNotificacionAdjudicacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerDatasetRenglonProductoCantidadRecomendada(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64, ByVal renglon As Integer) As DataSet
        Try
            Return mDb.obtenerDatasetRenglonProductoCantidadRecomendada(IDESTABLECIMIENTO, IDPROCESOCOMPRA, renglon)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerDatasetRenglonProveedorAlmacenCantidad(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64, ByVal renglon As Integer) As DataSet
        Try
            Return mDb.obtenerDatasetRenglonProveedorAlmacenCantidad(IDESTABLECIMIENTO, IDPROCESOCOMPRA, renglon)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarALMACENESENTREGAADJUDICACION(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64, ByVal renglon As Integer, ByVal idproveedor As Integer, ByVal idalmacen As Integer, ByVal identrega As Integer, ByVal cantidad As Double, ByVal CodUsuario As String, ByVal idDetalle As Int64) As Integer
        Try
            Return mDb.ActualizarALMACENESENTREGAADJUDICACION(IDESTABLECIMIENTO, IDPROCESOCOMPRA, idproveedor, idalmacen, renglon, identrega, cantidad, CodUsuario, idDetalle)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerRenglonesAdjudicadosControlCalidad(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, Optional ByVal TIPOADJUDICACION As Integer = 0, Optional ByVal IDINSPECTOR As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerRenglonesAdjudicadosControlCalidad(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, TIPOADJUDICACION, IDINSPECTOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
