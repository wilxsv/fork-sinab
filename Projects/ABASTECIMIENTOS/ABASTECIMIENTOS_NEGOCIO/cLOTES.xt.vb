Partial Public Class cLOTES

#Region "  Metodos Agregados  "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODIGOPRODUCTO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerDsLote(ByVal CODIGOPRODUCTO As String, ByVal IDALMACEN As Int64) As DataSet
        Try
            Return mDb.ObtenerDsLote(CODIGOPRODUCTO, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerListaXproducto(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As listaLOTES
        Try
            Return mDb.ObtenerListaPorID(IDALMACEN, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <param name="IDTIPOCONSULTA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function SeleccionarLoteDs(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int32, ByVal IDTIPOCONSULTA As Int16) As DataSet
        Try
            Return mDb.SeleccionarLoteDs(IDALMACEN, IDPRODUCTO, IDTIPOCONSULTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDLOTE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerDsDetalleLote(ByVal IDALMACEN As Int32, ByVal IDLOTE As Int64) As DataSet
        Try
            Return mDb.ObtenerDsDetalleLote(IDALMACEN, IDLOTE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDLOTE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerLotePorIdloteDS(ByVal IDALMACEN As Int64, ByVal IDLOTE As Int64) As DataSet
        Try
            Return mDb.ObtenerLotePorIdloteDS(IDALMACEN, IDLOTE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDPRODUCTO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDTIPOFILTRO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerDsLoteFiltrado(ByVal IDPRODUCTO As Int32, ByVal IDALMACEN As Int64, ByVal IDTIPOFILTRO As Int16) As DataSet
        Try
            Return mDb.ObtenerDsLoteFiltrado(IDPRODUCTO, IDALMACEN, IDTIPOFILTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDsLoteFiltrado2(ByVal IDALMACEN As Int64, ByVal IDSUMINISTRO As Integer, ByVal IDPRODUCTO As Integer, ByVal CODIGO As String, ByVal IDTIPOFILTRO As Int16) As DataSet
        Try
            Return mDb.ObtenerDsLoteFiltrado2(IDALMACEN, IDSUMINISTRO, IDPRODUCTO, CODIGO, IDTIPOFILTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="PRODUCTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function SeleccionarLotes(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Integer, ByVal CODIGO As String, Optional ByVal ESTADISPONIBLE As Integer = 1) As DataSet
        Try
            Return mDb.SeleccionarLotes(IDALMACEN, IDPRODUCTO, CODIGO, ESTADISPONIBLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve el código y descripción de cada producto con existencia disponible en el almacén indicado.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificdor del almacén.</param>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function RecuperarProductosAlmacen(ByVal IDALMACEN As Integer, Optional ByVal ESTADISPONIBLE As Integer = 1) As DataSet
        Try
            Return mDb.RecuperarProductosAlmacen(IDALMACEN, ESTADISPONIBLE)
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
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ObtenerID(ByVal aEntidad As entidadBase) As String
        Try
            Return mDb.ObtenerID(aEntidad)
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
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function Agregar(ByVal aEntidad As entidadBase) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="FECHAHASTA"></param>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDZONA"></param>
    ''' <param name="IDSUMINISTRO"></param>
    ''' <param name="IDGRUPO"></param>
    ''' <param name="IDSUBGRUPO"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function RptProximosAVencer(ByVal FECHAHASTA As DateTime, ByVal IDESTABLECIMIENTO As Integer, ByVal IDZONA As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDSUBGRUPO As Integer, ByVal IDPRODUCTO As Integer) As DataSet
        Try
            Return mDb.RptProximosAVencer(FECHAHASTA, IDESTABLECIMIENTO, IDZONA, IDSUMINISTRO, IDGRUPO, IDSUBGRUPO, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptProximosAVencerAlmacen(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal FECHAHASTA As DateTime, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, Optional IDPROGRAMA As Integer = 0) As DataSet
        Try
            Return mDb.RptProximosAVencerAlmacen(IDALMACEN, IDSUMINISTRO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, FECHAHASTA, IDGRUPOFUENTEFINANCIAMIENTO, IDPROGRAMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptVencidosAlmacen(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer) As DataSet
        Try
            Return mDb.RptVencidosAlmacen(IDALMACEN, IDSUMINISTRO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDGRUPOFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptAgotadosAlmacen(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer) As DataSet
        Try
            Return mDb.RptAgotadosAlmacen(IDALMACEN, IDSUMINISTRO, IDGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function RptAgotadosAlmacen2(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer) As DataSet
        Try
            Return mDb.RptAgotadosAlmacen2(IDALMACEN, IDSUMINISTRO, IDGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <param name="IDFUENTE"></param>
    ''' <param name="IDRESPONSABLE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ExistenciaPorProductosActual(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Integer, ByVal CODIGO As String, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer) As DataSet
        Try
            Return mDb.ExistenciaPorProductosActual(IDALMACEN, IDPRODUCTO, CODIGO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDGRUPOFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDZONA"></param>
    ''' <param name="IDSUMINISTRO"></param>
    ''' <param name="IDGRUPO"></param>
    ''' <param name="IDSUBGRUPO"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function RptExistencias(ByVal IDESTABLECIMIENTO As Integer, ByVal IDZONA As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDSUBGRUPO As Integer, ByVal IDPRODUCTO As Integer) As DataSet
        Try
            Return mDb.RptExistencias(IDESTABLECIMIENTO, IDZONA, IDSUMINISTRO, IDGRUPO, IDSUBGRUPO, IDPRODUCTO)
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
    ''' <param name="IDFUENTE"></param>
    ''' <param name="IDRESPONSABLE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ExistenciaPorTipoProductosActual(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int64, ByVal IDGRUPO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDESPECIFICOGASTO As Integer) As DataSet
        Try
            Return mDb.ExistenciaPorTipoProductosActual(IDALMACEN, IDSUMINISTRO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDGRUPOFUENTEFINANCIAMIENTO, IDESPECIFICOGASTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ExistenciaAlmacenHospital(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int64, ByVal IDGRUPO As Int32) As DataSet
        Try
            Return mDb.ExistenciaAlmacenHospital(IDALMACEN, IDSUMINISTRO, IDGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ExistenciaHistoricaPorTipoProducto(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int64, ByVal IDGRUPO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal FECHAHASTA As Date, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Int32, ByVal fos As Integer, ByVal IDESPECIFICOGASTO As Integer) As DataSet
        Try
            Return mDb.ExistenciaHistoricaPorTipoProducto(IDALMACEN, IDSUMINISTRO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, FECHAHASTA, IDGRUPOFUENTEFINANCIAMIENTO, fos, IDESPECIFICOGASTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function VencimientoHistoricaPorTipoProducto(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int64, ByVal FECHAHASTA As Date, ByVal FECHADESDE As Date) As DataSet
        Try
            Return mDb.VencimientoHistoricaPorTipoProducto(IDALMACEN, IDSUMINISTRO, FECHAHASTA, FECHADESDE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <param name="IDALMACENORIGEN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ExistenciaTemporalPorProductosActual(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDALMACENORIGEN As Int32) As DataSet
        Try
            Return mDb.ExistenciaTemporalPorProductosActual(IDALMACEN, IDPRODUCTO, IDALMACENORIGEN)
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
    ''' <param name="IDGRUPO"></param>
    ''' <param name="IDALMACENORIGEN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ExistenciaTemporalPorTipoProducto(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDALMACENORIGEN As Integer) As DataSet
        Try
            Return mDb.ExistenciaTemporalPorTipoProducto(IDALMACEN, IDSUMINISTRO, IDGRUPO, IDALMACENORIGEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExisteLoteSIMProducto(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As Boolean
        Try
            Return mDb.ExisteLoteSIMProducto(IDALMACEN, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExistenciaLoteSIMProducto(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As Double
        Try
            Return mDb.ExistenciaLoteSIMProducto(IDALMACEN, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Obtener el idlote del los productos con lote SM
    ''' </summary>
    ''' <param name="IDALMACEN"></param> 'identificador del almacen
    ''' <param name="IDPRODUCTO"></param> 'identificador del producto
    ''' <returns>
    ''' un entero que representa el identificador del lote
    ''' </returns>
    ''' <remarks></remarks>
    Public Function ObteneridLoteSIMProducto(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As Integer
        Try
            Return mDb.ObteneridLoteSIMProducto(IDALMACEN, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try
    End Function
    Public Function ObtenerRespyFF(ByVal IDALMACEN As Integer, IDPRODUCTO As Integer, IDLOTE As Integer) As DataSet
        Try
            Return mDb.ObtenerRespyFF(IDALMACEN, IDPRODUCTO, IDLOTE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class
