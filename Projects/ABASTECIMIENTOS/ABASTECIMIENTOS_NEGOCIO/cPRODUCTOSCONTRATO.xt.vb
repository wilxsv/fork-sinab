Partial Public Class cPRODUCTOSCONTRATO

#Region "METODOS AGREGADOS"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerDetalleContratoDs(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As DataSet
        Try
            Return mDb.ObtenerDetalleContratoDs(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="aEntidad"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function AgregarPRODUCTOSCONTRATO(ByVal aEntidad As PRODUCTOSCONTRATO) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROCESOCOMPRA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function obtenerRenglonesAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Return mDb.obtenerRenglonesAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function EliminarProductosAsociados(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As Integer
        Try
            Return mDb.EliminarProductosAsociados(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function obtenerProductosAdjudicadosContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obtenerProductosAdjudicadosContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Verifica si el número de renglon o linea ya fue utilizado por otro
    ''' producto.
    ''' </summary>
    ''' <param name="aEntidad">Entidad con los valores de busqueda del renglón</param>
    ''' <returns>Retorna un valor númerico que define si el renglón ya fue utilizado o no</returns>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/03/2007    Creado
    ''' </history>
    Public Function ValidarRenglonNoUaci(ByVal aEntidad As entidadBase) As Int16
        Try
            Return mDb.ValidarRenglonNoUaci(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Verifica si ya fue registro el producto.
    ''' </summary>
    ''' <param name="aEntidad">Entidad con los valores de busqueda del renglón</param>
    ''' <returns>Retorna un valor númerico que define si el renglón ya fue utilizado o no</returns>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/03/2007    Creado
    ''' </history>
    Public Function ValidarProductoNoUaci(ByVal aEntidad As PRODUCTOSCONTRATO) As Int16
        Try
            Return mDb.ValidarProductoNoUaci(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerRenglonesContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, Optional ByVal RENGLON As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerRenglonesContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerRenglonesContratoConEntregas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, Optional ByVal RENGLON As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerRenglonesContratoConEntregas(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <param name="RENGLON"></param>
    ''' <param name="ESTAHABILITADO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function HabilitarRecepcionesRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal ESTAHABILITADO As Integer) As Integer
        Try
            Return mDb.HabilitarRecepcionesRenglon(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, ESTAHABILITADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerTiposSuministroContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As String
        Try
            Return mDb.ObtenerTiposSuministroContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
