Partial Public Class cDETALLEPROCESOCOMPRA

#Region "Metodos agregados"

    Public Function AgregarDetalleProcesoCompra(ByVal SOLICITUDSEL As listaSOLICITUDES, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As Integer
        Try
            Dim mComProcesoCompra As New cPROCESOCOMPRAS
            Dim lEntidad As New PROCESOCOMPRAS
            Dim ESTADOCALIFICACION As Integer
            lEntidad = mComProcesoCompra.ObtenerPROCESOCOMPRAS(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

            Dim mComTipoCompra As New cTIPOCOMPRAS
            Dim lEntidadTPC As New TIPOCOMPRAS

            lEntidadTPC = mComTipoCompra.ObtenerTIPOCOMPRAS(lEntidad.IDTIPOCOMPRAEJECUTAR)

            If lEntidadTPC.IDMODALIDADCOMPRA = 1 Then
                ESTADOCALIFICACION = 8
            Else
                ESTADOCALIFICACION = 3
            End If

            Return mDb.AgregarDetalleProcesoCompra(SOLICITUDSEL, IDPROCESOCOMPRA, IDESTABLECIMIENTO, ESTADOCALIFICACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDSRenglonProducto(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal RENGLON As Int64) As DataSet
        Try
            Return mDb.obtenerDSRenglonProducto(IDPROCESOCOMPRA, IDESTABLECIMIENTO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetEncabezado(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetParaConsolidar(IDPROCESOCOMPRA, IDESTABLECIMIENTO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetEncabezado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetParaConsolidar(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetEncabezadoPorRenglon(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDRENGLON As Integer, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetParaConsolidarPorRenglon(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDRENGLON, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetEncabezadoPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer) As String
        Try
            Return mDb.ObtenerDataSetParaConsolidarPorRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function AgregarObservacion(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer
        Try
            Return mDb.AgregarObservacion(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarGarantiaValor(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer
        Try
            Return mDb.ActualizarGarantiaValor(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataListaProductos(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataListaProductos(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve todos los renglones asociados a un proceso de compra.
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="RENGLON">Numero de renglon.  Opcional.  El valor por defecto es cero, que indica que se deben devolver todos los renglones.</param>
    ''' <param name="IDESTADO">Array de identificadores del estado del renglon.  Opcional.  El valor por defecto es Nothing, que significa que se deben devolver todos los estados. </param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerRenglonesProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, Optional ByVal RENGLON As Integer = 0, Optional ByVal IDESTADO() As Byte = Nothing) As DataSet
        Try
            Return mDb.ObtenerRenglonesProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO, RENGLON, IDESTADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCantidad(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Integer, ByVal IDDETALLE As Integer) As Decimal
        Try
            Return mDb.ObtenerCantidad(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPRODUCTO, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Actualiza la calificación de un renglón.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <param name="IDDETALLE">Identificador del renglón.</param>
    ''' <param name="IDESTADOCALIFICACION">Identificador del estado correspondiente a la calificación.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarEstadoCalificacionProcesoCompra(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer
        Try
            Return mDb.ActualizarEstadoCalificacionProcesoCompra(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarObservacionRecomendacion(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer
        Try
            Return mDb.ActualizarObservacionRecomendacion(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Devuelve las observaciones registradas para un renglón al momento de efectuar la recomendación.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <param name="IDDETALLE">Identificador del renglón.</param>
    ''' <returns>String.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerObservacionRecomendacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPRODUCTO As Integer, ByVal IDDETALLE As Integer) As String
        Try
            Return mDb.ObtenerObservacionRecomendacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPRODUCTO, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Devuelve las observaciones registradas para un renglón al momento de efectuar la adjudicación.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <param name="IDDETALLE">Identificador del renglon.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerObservacionAdjudicacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPRODUCTO As Integer, ByVal IDDETALLE As Integer) As String
        Try
            Return mDb.ObtenerObservacionAdjudicacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPRODUCTO, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Devuelve las observaciones registradas para un renglón al momento de efectuar la adjudicación en firme.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <param name="IDDETALLE">Identificador del renglón.</param>
    ''' <returns>String.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerObservacionAdjudicacionEnFirme(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPRODUCTO As Integer, ByVal IDDETALLE As Integer) As String
        Try
            Return mDb.ObtenerObservacionAdjudicacionEnFirme(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPRODUCTO, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return ""
        End Try
    End Function

    Public Function ObtenerObservacionConsolidacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPRODUCTO As Integer, ByVal IDDETALLE As Integer) As String
        Try
            Return mDb.ObtenerObservacionConsolidacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPRODUCTO, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Actualiza el estado de un renglón para el cual no se ha recomendado/adjudicado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <param name="IDESTADOCALIFICACION">Identificador del estado de la calificación.</param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarEstadoCalificacionProcesoCompraNoAdjudicado(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer
        Try
            Return mDb.ActualizarEstadoCalificacionProcesoCompraNoAdjudicado(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function RenglonesRecomendados(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, Optional ByVal IDESTADO() As Byte = Nothing) As Integer
        Try
            Return mDb.RenglonesRecomendados(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDESTADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Actualiza las observaciones correspondientes a un renglón dado.
    ''' </summary>
    ''' <param name="aEntidad">Entidad DETALLEPROCESOCOMPRA.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarObservaciones(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer
        Try
            Return mDb.ActualizarObservaciones(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Devuelve todos los renglones asociados a un proceso de compra para los cuales los proveedores adjudicados no presentaron nota de aceptacion.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Numero de renglon.  Opcional.  El valor por defecto es cero, que indica que se deben devolver todos los renglones.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerRenglonesSinNotasAceptacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, Optional ByVal RENGLON As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerRenglonesSinNotasAceptacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ResolucionAdjudicacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByRef ds As DataSet, ByVal IDALMACEN As Integer) As Integer
        Try
            Return mDb.ResolucionAdjudicacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ResolucionAdjudicacionEnFirme(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByRef ds As DataSet, ByVal IDALMACEN As Integer) As Integer
        Try
            Return mDb.ResolucionAdjudicacionEnFirme(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function EsCompraMedicamentos(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Integer
        Try
            Return mDb.EsCompraMedicamentos(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarEstadoNoDesierto(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer
        Try
            Return mDb.ActualizarEstadoNoDesierto(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function


    Public Function ResumenProcesoEvalxRenglon(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer
        Try
            Return mDb.ActualizarObservacionRecomendacion(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
