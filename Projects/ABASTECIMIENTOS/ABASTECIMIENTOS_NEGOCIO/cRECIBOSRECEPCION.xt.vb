Partial Public Class cRECIBOSRECEPCION

    ''' <summary>
    ''' Devuelve el Identificador para el nuevo registro.
    ''' </summary>
    ''' <param name="aEntidad">Entidad de datos en la que se almacena el nuevo registro.</param>
    ''' <returns>Cadena de texto con el nuevo identificador.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  12/02/2007    Creado
    ''' </history> 
    Public Function ObtenerID(ByVal aEntidad As RECIBOSRECEPCION) As String
        Try
            Return mDb.ObtenerID(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ExisteRecibo(ByVal aEntidad As entidadBase) As Integer
        Try
            Return mDb.ExisteRecibo(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Agrega un registro con la información del recibo de recepción.
    ''' </summary>
    ''' <param name="aEntidad">Entidad de datos en la que se almacena el nuevo registro.</param>
    ''' <returns>Valor númerico indicando el estado de la transacción.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_RECIBOSRECEPCION</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  12/02/2007    Creado
    ''' </history> 
    Public Function AgregarRECIBOSRECEPCION(ByVal aEntidad As RECIBOSRECEPCION) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve una lista de todos los recibos de recepción y actas, de acuerdo al criterio de búsqueda seleccionada.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="FECHADESDE">Fecha de inicio del período.</param>
    ''' <param name="FECHAHASTA">Fecha de finalización del período.</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente del financiamiento.</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribución.</param>
    ''' <param name="IDESTADO">Identificador del estado del documento.</param>
    ''' <param name="NUMERORECIBO">Número de recibo de recepción.  Opcional.  El valor por defecto es cero, que indica que no se incluye en el criterio.</param>
    ''' <param name="NUMEROACTA">Número de acta de recepción.  Opcional.  El valor por defecto es cero, que indica que no se incluye en el criterio.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaRecibosRecepcionActas(ByVal IDALMACEN As Integer, Optional ByVal IDPROVEEDOR As Integer = 0, Optional ByVal FECHADESDE As Date = Nothing, Optional ByVal FECHAHASTA As Date = Nothing, Optional ByVal IDFUENTEFINANCIAMIENTO As Integer = 0, Optional ByVal IDRESPONSABLEDISTRIBUCION As Integer = 0, Optional ByVal IDESTADO As Integer = 0, Optional ByVal NUMERORECIBO As Integer = 0, Optional ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer = 0, Optional ByVal NUMEROACTA As Integer = 0, Optional ByVal IDSUMINISTRO As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerListaRecibosRecepcionActas(IDALMACEN, IDPROVEEDOR, FECHADESDE, FECHAHASTA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDESTADO, NUMERORECIBO, NUMEROACTA, IDGRUPOFUENTEFINANCIAMIENTO, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerRecepciones(ByVal IDALMACEN As Integer, ByVal IDTIPOTRANSACCION As Integer, Optional ByVal IDESTADO As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerRecepciones(IDALMACEN, IDTIPOTRANSACCION, IDESTADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerFuentesRecibosRecepcionActas(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDRECIBO As Integer) As DataSet
        Try
            Return mDb.ObtenerFuentesRecibosRecepcionActas(IDALMACEN, ANIO, IDRECIBO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerResponsablesDistribucionRecibosRecepcionActas(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDRECIBO As Integer) As DataSet
        Try
            Return mDb.ObtenerResponsablesDistribucionRecibosRecepcionActas(IDALMACEN, ANIO, IDRECIBO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarDetalleRecepcion(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDRECIBO As Integer, ByVal IDTIPOTRANSACCION As Integer) As DataSet
        Try
            Return mDb.RecuperarDetalleRecepcion(IDALMACEN, ANIO, IDRECIBO, IDTIPOTRANSACCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNumeroACTA(ByVal IDALMACEN As Int32, ByVal ANIO As Int16) As String
        Try
            Return mDb.ObtenerNumeroACTA(IDALMACEN, ANIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
