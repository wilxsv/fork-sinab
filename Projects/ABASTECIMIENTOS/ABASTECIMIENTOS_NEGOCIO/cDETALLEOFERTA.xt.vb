Partial Public Class cDETALLEOFERTA

#Region "  Metodos Agregados  "

    Public Function ObtenerValorizacionPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerValorizacionPorRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerValorizacionPorRenglon2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByRef ds As DataSet, Optional ByVal IDALMACEN As Integer = 0) As Integer
        Try
            Return mDb.ObtenerValorizacionPorRenglon2(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function Agregar(ByVal aEntidad As DETALLEOFERTA) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerIDDETALLE(ByRef aEntidad As DETALLEOFERTA) As Integer
        Try
            Return mDb.ObtenerIDDETALLE(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetDetalleOferta(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetDetalleOferta(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDetalleConsolidacionOferta(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal RENGLON As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDetalleConsolidacionOferta(IDPROCESOCOMPRA, IDESTABLECIMIENTO, RENGLON, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerRenglon(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet
        Try
            Return mDb.ObtenerRenglon(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerRenglon2(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet
        Try
            Return mDb.ObtenerRenglon2(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerObservacionDocumento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal idproveedor As Integer, ByVal IDDETALLE As Integer) As String
        Try
            Return mDb.ObtenerDocumentoObservacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, idproveedor, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarObservacionDocumento(ByVal aEntidad As DETALLEOFERTA) As Integer
        Try
            Return mDb.ActualizarObservacionDocumento(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Obtiene todas las ofertas recibidas para un renglón correspondiente a un proceso de compra dado.
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor</param>
    ''' <param name="IDDETALLE">Idnetificador del detalle de la oferta.  Opcional, sólo si se desea devolver los datos de una sola oferta.  Por defecto es 0, que significa que se muestran todas.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerOfertasPorRenglonProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal RENGLON As Int32, Optional ByVal IDPROVEEDOR As Integer = 0, Optional ByVal IDDETALLE As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerOfertasPorRenglonProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO, RENGLON, IDPROVEEDOR, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProveedores(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerProveedores(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarEstadoCalificacionOferta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal IDESTADOCALIFICACIONOFERTA As Integer) As Integer
        Try
            Return mDb.ActualizarEstadoCalificacionOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, IDESTADOCALIFICACIONOFERTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function OfertanteCalificado(ByVal idestablecimiento As Integer, ByVal idprocesocompra As Integer, ByVal idproveedor As Integer, ByVal iddetalle As Integer, ByVal renglon As Integer) As Boolean
        Try
            Return mDb.OfertanteCalificado(idestablecimiento, idprocesocompra, idproveedor, iddetalle, renglon)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function CuadroEvaluacionOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer, Optional ByVal IDPROVEEDOR As Integer = 0, Optional ByVal IDDETALLE As Integer = 0) As DataSet
        Try
            Return mDb.CuadroEvaluacionOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON, IDPROVEEDOR, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function CuadroEvaluacionCriterio(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer) As DataSet
        Try
            Return mDb.CuadroEvaluacionCriterios(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Para un renglón y oferta dados, devuelve el total recomendado a otras ofertas, del mismo y otros proveedores.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <param name="TOTALRECOMENDADOOTROSPROVEEDORES">Cantidad total recomendada a ofertas de otros proveedores.</param>
    ''' <param name="TOTALRECOMENDADOMISMOPROVEEDOR">Cantidad total recomendada a ofertas del mismo proveedor.</param>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Sub ObtenerTotalesRecomendados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal RENGLON As Integer, ByRef TOTALRECOMENDADOOTROSPROVEEDORES As Decimal, ByRef TOTALRECOMENDADOMISMOPROVEEDOR As Decimal)
        Try
            mDb.ObtenerTotalesRecomendados(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, RENGLON, TOTALRECOMENDADOOTROSPROVEEDORES, TOTALRECOMENDADOMISMOPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Para un renglón y oferta dados, devuelve el total adjudicado a otras ofertas, del mismo y otros proveedores.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <param name="TOTALADJUDICADOOTROSPROVEEDORES">Cantidad total adjudicada a ofertas de otros proveedores.</param>
    ''' <param name="TOTALADJUDICADOMISMOPROVEEDOR">Cantidad total adjudicada a ofertas del mismo proveedor.</param>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Sub ObtenerTotalesAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal RENGLON As Integer, ByRef TOTALADJUDICADOOTROSPROVEEDORES As Decimal, ByRef TOTALADJUDICADOMISMOPROVEEDOR As Decimal)
        Try
            mDb.ObtenerTotalesAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, RENGLON, TOTALADJUDICADOOTROSPROVEEDORES, TOTALADJUDICADOMISMOPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Para un renglón y oferta dados, devuelve el total adjudicado en firme a otras ofertas, del mismo y otros proveedores.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <param name="TOTALENFIRMEOTROSPROVEEDORES">Cantidad total adjudicada en firme a ofertas de otros proveedores.</param>
    ''' <param name="TOTALENFIRMEMISMOPROVEEDOR">Cantidad total adjudicado en firme a ofertas del mismo proveedor.</param>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Sub ObtenerTotalesAdjudicadosEnFirme(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal RENGLON As Integer, ByRef TOTALENFIRMEOTROSPROVEEDORES As Decimal, ByRef TOTALENFIRMEMISMOPROVEEDOR As Decimal)
        Try
            mDb.ObtenerTotalesAdjudicadosEnFirme(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, RENGLON, TOTALENFIRMEOTROSPROVEEDORES, TOTALENFIRMEMISMOPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
        End Try
    End Sub

    Public Function CuadroTecnicoFinanciero(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.CuadroTecnicoFinanciero(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function validarExistenciaOferta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As Integer
        Try
            Return mDb.validarExistenciaOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function rptDetalleOferta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.rptDetalleOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCantidadOfertas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer
        Try
            Return mDb.ObtenerCantidadOfertas(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerProveedoresAdjudXRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDRENGLON As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerProveedoresAdjudXRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDRENGLON, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerMontoOfertado(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32) As Decimal
        Try
            Return mDb.ObtenerMontoOfertado(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetIdDetalleOfertaXrENGLON(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal RENGLON As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetIdDetalleOfertaXrENGLON(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

#End Region

End Class
