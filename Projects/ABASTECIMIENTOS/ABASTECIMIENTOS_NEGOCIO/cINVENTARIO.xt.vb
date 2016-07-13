Partial Class cINVENTARIO

    Public Function ObtenerDataSetPorId2(ByVal IDALMACEN As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener existencia disponible de inventarios de almacen
    ''' </summary>
    ''' <param name="IDALMACEN"></param> identificador de almacen
    ''' <param name="IDSUMINISTRO"></param> identificador de suministro
    ''' <param name="FECHAEXISTENCIA"></param> fecha de existencia
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param> identificador de fuente de financiamiento
    ''' <param name="IDRESPONSABLEDIST"></param> identificdor de responsable de distribucion
    ''' <param name="VENCIDOS"></param> si aplica los vencidos
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerExistenciasDisponiblesInventarioAlmacen(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int32, ByVal FECHAEXISTENCIA As Date, Optional ByVal IDFUENTEFINANCIAMIENTO As Int32 = 0, Optional ByVal IDRESPONSABLEDISTRIBUCION As Int32 = 0, Optional ByVal VENCIDOS As Int32 = 0) As DataSet
        Try
            Return mDb.obtenerExistenciasDisponiblesInventarioAlmacen(IDALMACEN, IDSUMINISTRO, FECHAEXISTENCIA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, VENCIDOS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Calcular la existencia no disponible en el almacen
    ''' </summary>
    ''' <param name="IDALMACEN"></param> identificador del almacen
    ''' <param name="IDSUMINISTRO"></param> identificador del suministro
    ''' <param name="FECHAEXISTENCIA"></param> fecha de existencia
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param> identificador de fuente de financiamiento
    ''' <param name="IDRESPONSABLEDIST"></param> identificador de responsable de distribucion
    ''' <param name="VENCIDOS"></param> aoplica vencidos
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerExistenciasNoDisponiblesInventarioAlmacen(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int32, ByVal FECHAEXISTENCIA As Date, Optional ByVal IDFUENTEFINANCIAMIENTO As Int32 = 0, Optional ByVal IDRESPONSABLEDIST As Int32 = 0, Optional ByVal VENCIDOS As Int32 = 0) As DataSet
        Try
            Return mDb.obtenerExistenciasNoDisponiblesInventarioAlmacen(IDALMACEN, IDSUMINISTRO, FECHAEXISTENCIA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDIST, VENCIDOS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Dataset con la informacion para generar reporte gerenciales
    ''' </summary>
    ''' <param name="IDZONA"></param> idenficador de zona o region
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador de pro
    ''' <param name="FECHAREFERENCIA"></param> fecha de referencia
    ''' <param name="OPERADOR"></param> operador de comparación
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetReportesGerencialesEstablecimiento(Optional ByVal IDZONA As Int32 = 0, Optional ByVal IDESTABLECIMIENTO As Int32 = 0, Optional ByVal IDPRODUCTO As Int32 = 0, Optional ByVal FECHAREFERENCIA As Date = Nothing, Optional ByVal OPERADOR As String = "") As DataSet
        Try
            Return mDb.ReportesGerencialesEstablecimiento(IDZONA, IDESTABLECIMIENTO, IDPRODUCTO, FECHAREFERENCIA, OPERADOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Dataset para reporte gerencial de establecimiento de inventario 
    ''' </summary>
    ''' <param name="IDZONA"></param> identificador de zona
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPRODUCTO"></param> identificdor de producto
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetReptsGerencialesEstablecimientoInventario(Optional ByVal IDZONA As Int32 = 0, Optional ByVal IDESTABLECIMIENTO As Int32 = 0, Optional ByVal IDPRODUCTO As Int32 = 0) As DataSet
        Try
            Return mDb.RptGerencialesEstablecimientoInventario(IDZONA, IDESTABLECIMIENTO, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Dataset con la informacion de productos sin movimiento de salida
    ''' </summary>
    ''' <param name="IDZONA"></param> identificdaor de zona
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador de producto
    ''' <param name="FECHAREFERENCIA"></param> fecha de referencia
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DatasetProductosSinmovimientoSalida(Optional ByVal IDZONA As Int32 = 0, Optional ByVal IDESTABLECIMIENTO As Int32 = 0, Optional ByVal IDPRODUCTO As Int32 = 0, Optional ByVal FECHAREFERENCIA As Date = Nothing) As DataSet
        Try
            Return mDb.DatasetProductosSinmovimientoSalida(IDZONA, IDESTABLECIMIENTO, IDPRODUCTO, FECHAREFERENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Dataset para generar reporte de entrada de productos sin movimientos de salida
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificdor de establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador de producto
    ''' <param name="IDLOTE"></param> identificador de lote
    ''' <param name="FECHAREFERENCIA"></param> fecha de referencia
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DatasetFechaEntradaProductosSinmovimientoSalida(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int32, ByVal IDLOTE As Int32, ByVal FECHAREFERENCIA As Date) As DataSet
        Try
            Return mDb.DatasetFechaEntradaProductosSinmovimientoSalida(IDESTABLECIMIENTO, IDPRODUCTO, IDLOTE, FECHAREFERENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Dataset para reporte gerencial de establecimiento de compra en transito
    ''' </summary>
    ''' <param name="IDZONA"></param> identificdor de zona
    ''' <param name="IDESTABLECIMIENTO"></param> identificdor de establecimiento
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <param name="IDPRODUCTO"></param> identificdor del producto
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function RptGerencialesEstablecimientoComprasTransito(Optional ByVal IDZONA As Int32 = 0, Optional ByVal IDESTABLECIMIENTO As Int32 = 0, Optional ByVal IDPROVEEDOR As Int32 = 0, Optional ByVal IDPRODUCTO As Int32 = 0) As DataSet
        Try
            Return mDb.RptGerencialesEstablecimientoComprasTransito(IDZONA, IDESTABLECIMIENTO, IDPROVEEDOR, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener id para un nuevo inventario
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo INVENTARIO
    ''' <returns>
    ''' devuel un identificador para el inventario entero
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerID(ByRef aEntidad As INVENTARIO) As Integer
        Return mDb.ObtenerID(aEntidad)
    End Function

    ''' <summary>
    ''' Permite agregar un nuevo inventario
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo INVENTARIO
    ''' <returns>
    ''' numero de registros afectados con la operación
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function AgregarINVENTARIO(ByVal aEntidad As INVENTARIO) As Integer
        Return mDb.Agregar(aEntidad)
    End Function

    ''' <summary>
    ''' Dataset para reporte de inventario fisico
    ''' </summary>
    ''' <param name="IDALMACEN"></param> identificador de almacen
    ''' <param name="IDINVENTARIO"></param> identificdor de inventario
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDsReporteInventarioFisico(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As DataSet
        Try
            Return mDb.ObtenerDsReporteInventarioFisico(IDALMACEN, IDINVENTARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDsReporteInventarioFisicoDiferencia(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As DataSet
        Try
            Return mDb.ObtenerDsReporteInventarioFisicoDiferencia(IDALMACEN, IDINVENTARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Data set para el reporte de ajuste de inventario
    ''' </summary>
    ''' <param name="IDALMACEN"></param> identificador del almacen
    ''' <param name="IDINVENTARIO"></param> identicador de inventario
    ''' <param name="IDDETALLE"></param> identificador de detalle de inventario
    ''' <returns>
    ''' Datset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerDsReporteAjusteInventario(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal IDDETALLE As Int32) As DataSet
        Try
            Return mDb.obtenerDsReporteaAjusteInventario(IDALMACEN, IDINVENTARIO, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function CopiarDetalleInventario(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal AUUSUARIOCREACION As String, Optional ByVal IDSUMINISTRO As Int32 = 0, Optional ByVal IDFUENTEFINANCIAMIENTO As Int32 = 0, Optional ByVal IDRESPONSABLEDISTRIBUCION As Int32 = 0, Optional ByVal CONSIDERARDISPONIBLES As Int32 = 0, Optional ByVal CONSIDERARNODISPONIBLES As Int32 = 0, Optional ByVal CONSIDERARVENCIDOS As Int32 = 0) As Integer
        Try
            Return mDb.CopiarDetalleInventario(IDALMACEN, IDINVENTARIO, AUUSUARIOCREACION, IDSUMINISTRO, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, CONSIDERARDISPONIBLES, CONSIDERARNODISPONIBLES, CONSIDERARVENCIDOS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
