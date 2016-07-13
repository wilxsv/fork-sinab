Partial Public Class cCONTRATOS

    ''' <summary>
    ''' Devuelve la información de completa de un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento en el que fue elaborado.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <returns>Dataset con la información del contrato.</returns>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  29/12/2006    Creado
    ''' </history> 
    Public Function ObtenerContratoNoUACI(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32) As DataSet
        Try
            Return mDb.ObtenerContratoNoUACI(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve la información de completa de un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento en el que fue elaborado.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <returns>Dataset con la información del contrato.</returns>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  29/12/2006    Creado
    ''' </history> 
    Public Function ObtenerContratoNoUACI2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32) As DataSet
        Try
            Return mDb.ObtenerContratoNoUACI2(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <param name="RENGLON"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: JOSE CHAVEZ]   Creado
    ''' </history>
    Public Function ObtenerRenglonesPendientesTotales(ByVal IDESTABLECIMIENTO As Int32, ByVal IDALMACEN As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32, ByVal RENGLON As Int32) As DataSet
        Try
            Return mDb.ObtenerRenglonesPendientesTotales(IDESTABLECIMIENTO, IDALMACEN, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <param name="RENGLON"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: JOSE CHAVEZ]   Creado
    ''' </history>
    Public Function ObtenerRenglonesPendientesTotales2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDALMACEN As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32, Optional ByVal RENGLON As Int32 = 0, Optional ByVal IDSUMINISTRO As Int32 = 0) As DataSet
        Try
            Return mDb.ObtenerRenglonesPendientesTotales2(IDESTABLECIMIENTO, IDALMACEN, IDPROVEEDOR, IDCONTRATO, RENGLON, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve todos los renglones habilitados, con o sin entregas pendientes.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <param name="TODOS">Indica si se deben devolver todos los renglones (valor 1) o sólo aquellos on entregas pendientes (valor 0).  Opcional, el valor por defecto es cero.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]   Creado
    ''' </history>
    Public Function ObtenerRenglonesPendientesTotales(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32, Optional ByVal TODOS As Byte = 0) As DataSet
        Try
            Return mDb.ObtenerRenglonesPendientesTotales(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, TODOS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'JOSE CHAVEZ
    Public Function ObtenerRenglonesPendientesDetallado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDALMACEN As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int32, ByVal RENGLON As Int32) As DataSet
        Try
            Return mDb.ObtenerRenglonesPendientesDetallado(IDESTABLECIMIENTO, IDALMACEN, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve el listado de proveedores con entregas pendiente.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén (Filtro).</param>
    ''' <param name="IDTIPODOCUMENTO">Identificador del tipo de documento (Filtro).</param> 
    ''' <returns>Dataset con el listado de proveedores.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>SAB_UACI_ENTREGAMODIFICATIVA</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGAMODIFICATIVA</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  30/12/2006    Creado
    ''' </history> 
    Public Function ObtenerProveedoresEntregasPendiente(ByVal IDALMACEN As Int32, Optional ByVal IDTIPODOCUMENTO As Int16 = 0) As DataSet
        Try
            Return mDb.ObtenerProveedoresEntregasPendiente(IDALMACEN, IDTIPODOCUMENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function ObtenerProveedoresAnticiposPendiente(ByVal IDALMACEN As Int32, Optional ByVal IDTIPODOCUMENTO As Int16 = 0) As DataSet
        Try
            Return mDb.ObtenerProveedoresAnticiposPendiente(IDALMACEN, IDTIPODOCUMENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Devuelve todos los proveedores con contratos distribuidos.
    ''' </summary>
    ''' <param name="TODOS">Determina si se devuelven todos los proveedores o sólo aquellos que tienen entregas pendientes.  Por defecto es cero, que indica sólo con entregas pendientes.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerProveedoresEntregasPendiente(Optional ByVal TODOS As Byte = 0) As DataSet
        Try
            Return mDb.ObtenerProveedoresEntregasPendiente(TODOS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve el listado de documentos pendientes por proveedor de un almacén especifico.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén. (Filtro)</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor. (Filtro)</param>
    ''' <param name="IDTIPODOCUMENTO">Identificador del tipo de documento. (Filtro)</param> 
    ''' <returns>Dataset con el listado de documentos pendientes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>SAB_UACI_ENTREGAMODIFICATIVA</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGAMODIFICATIVA</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  30/12/2006    Creado
    ''' </history>
    Public Function ObtenerDocumentosPendientesPorProveedorDS(ByVal IDALMACEN As Int32, ByVal IDPROVEEDOR As Int32, Optional ByVal IDTIPODOCUMENTO As Int16 = 0) As DataSet
        Try
            Return mDb.ObtenerDocumentosPendientesPorProveedorDS(IDALMACEN, IDPROVEEDOR, IDTIPODOCUMENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerAnticiposPendientesPorProveedorDS(ByVal IDALMACEN As Int32, ByVal IDPROVEEDOR As Int32, Optional ByVal IDTIPODOCUMENTO As Int16 = 0) As DataSet
        Try
            Return mDb.ObtenerAnticiposPendientesPorProveedorDS(IDALMACEN, IDPROVEEDOR, IDTIPODOCUMENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve todos los documentos correspondientes al proveedor indicado.
    ''' </summary>
    ''' <param name="IDPROVEEDOR">Indica el proveedor para el cual se efectúa la búsqueda</param>
    ''' <param name="TODOS">Determina si se devuelven todos los documentos o sólo aquellos que tienen entregas pendientes.  Por defecto es cero, que indica sólo con entregas pendientes.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerDocumentosPendientesPorProveedor(ByVal IDPROVEEDOR As Int32, Optional ByVal TODOS As Byte = 0) As DataSet
        Try
            Return mDb.ObtenerDocumentosPendientesPorProveedor(IDPROVEEDOR, TODOS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'JOSE CHAVEZ
    Public Function ObtenerDsContratos(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADOCONTRATO As Int16, Optional ByVal IDPROVEEDOR As Int32 = 0, Optional ByVal IDTIPODOCUMENTO As Int16 = 0, Optional ByVal NUMEROCONTRATO As String = "", Optional ByVal IDPRODUCTO As Int32 = 0) As DataSet
        Try
            Return mDb.ObtenerDsContratos(IDESTABLECIMIENTO, IDESTADOCONTRATO, IDPROVEEDOR, IDTIPODOCUMENTO, NUMEROCONTRATO, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerID(ByVal aEntidad As CONTRATOS) As String
        Try
            Return mDb.ObtenerID(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obterProveedoresGenerarContrato(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obterProveedoresGenerarContrato(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerContratosDR(ByVal IDESTABLECIMIENTO As Int32) As System.Data.SqlClient.SqlDataReader
        Try
            Return mDb.ObtenerContratosDR(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener cuales contratos etan asociados a un proceso de compra
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA"></param> 'identificador del proceso de compra
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <returns>
    ''' Dataset con contratos por proceso de compra
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerContratosOfertaXProcesoCompra(ByVal IDPROCESOCOMPRA As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.obtenerContratosOfertaXProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener los contratos de un proceso de compra filtrado por numero de contrato
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA"></param> 'identificador del proceso de compra
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDCODIGO"></param> 'codigo del contrato utilizado por el MSPAS
    ''' <returns>
    ''' Dataset con contratos que cumplan con el filtro de numero de contrato
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerContratosOfertaXProcesoCompraXNumeroContrato(ByVal IDPROCESOCOMPRA As Int32, ByVal IDESTABLECIMIENTO As Int32, ByVal IDCODIGO As String) As DataSet
        Try
            Return mDb.obtenerContratosOfertaXProcesoCompraXNumeroContrato(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDCODIGO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener contratos que cumplan con el filto de proveedor
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA"></param> 'identificador del proceso de compra
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDPROVEEDOR"></param> 'identificador del proveedor
    ''' <returns>
    ''' Dataset con contratos filtrado por proveedor
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerContratosOfertaXProcesoCompraXProveedor(ByVal IDPROCESOCOMPRA As Int32, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As String) As DataSet
        Try
            Return mDb.obtenerContratosOfertaXProcesoCompraXProveedor(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener cuales fueron los renglones adjudicados para un contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDCONTRATO"></param> 'identificador del contrato
    ''' <returns>
    ''' Dataset con la informacion del renglon adjudicado
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function obtenerRenglonesAdjudicadosXContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet
        Try
            Return mDb.obtenerRenglonesAdjudicadosXContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RenglonesAdjudicadosPorOferta() As DataSet
        Try
            Return mDb.RenglonesAdjudicadosPorOferta()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RenglonesAdjudicadosPorOferta2(ByVal IDPROC As Integer, ByVal IDESTABLECIMIENTO As Integer, Optional ByVal IDEMPLEADO As Integer = 0) As DataSet
        Try
            Return mDb.RenglonesAdjudicadosPorOferta2(IDPROC, IDESTABLECIMIENTO, IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarRetornaEntidad(ByRef aEntidad As entidadBase) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarPersoneriaJuridicaActaNotarial(ByVal aEntidad As entidadBase) As Integer
        Try
            Return mDb.ActualizarPersoneriaJuridicaActaNotarial(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDsContratosProcesoCompraMultas(ByVal IDPROCESOCOMPRA As Int32, ByVal IDESTABLECIMIENTO As Int32, ByVal IDANALISTA As Integer) As DataSet
        Try
            Return mDb.ObtenerDsContratosProcesoCompraMultas(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDANALISTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ElaboraContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPLANTILLA As Integer) As DataSet
        Try
            Return mDb.ElaboraContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDPROCESOCOMPRA, IDPLANTILLA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ElaboraOficioAdj(ByVal IDPLANTILLA As Integer) As DataSet
        Try
            Return mDb.ElaboraOficioAdj(IDPLANTILLA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ElaboraModificativaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ElaboraModificativaContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDsContratosProcesoCompra(ByVal IDPROCESOCOMPRA As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDsContratosProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'jmejia
    Public Function ObtenerDatasetContratosPorPeriodo(ByVal fini As Date, ByVal ffin As Date, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDatasetContratosPorPeriodo(fini, ffin, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DevolverContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Int64, ByVal IDCONTRATO As Integer, ByVal idproveedor As Integer) As DataSet
        Try
            Return mDb.DevolverContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCONTRATO, idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerIDProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer) As Integer
        Try
            Return mDb.ObtenerIDProveedor(IDESTABLECIMIENTO, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProductosAdjudicadosProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obtenerProductosAdjudicadosProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProveedoresContratados(Optional ByVal IDESTABLECIMIENTO As Integer = 0) As DataSet
        Try
            Return mDb.obtenerProveedoresContratados(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Juan Rivas
    Public Function ObtenerDsConsultaContratos(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDTIPODOCUMENTO As Int16, ByVal NCONTRATO As String, ByVal IDPRODUCTO As Int32, ByVal IDTIPOCONSULTA As Int16, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerDsConsultaContratos(IDESTABLECIMIENTO, IDPROVEEDOR, IDTIPODOCUMENTO, NCONTRATO, IDPRODUCTO, IDTIPOCONSULTA, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerNEntregas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obtenerNEntregas(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerMontoContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.obtenerMontoContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerTotalMontoContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.obtenerTotalMontoContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Carlos Ceconi
    Public Function ObtenerDatosContratoProcesoCompra(ByVal aEntidad As CONTRATOS) As Integer
        Try
            Return mDb.ObtenerDatosContratoProcesoCompra(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    'Henry Zavaleta
    Public Function ActualizarFechaDistribucion(ByVal fechadistribucion As DateTime, ByVal idprocesocompra As Integer, ByVal idestablecimiento As Integer, Optional ByVal idcontrato As Integer = 0, Optional ByVal idproveedor As Integer = 0) As Integer
        Try
            Return mDb.ActualizarFechaDistribucion(fechadistribucion, idprocesocompra, idestablecimiento, idcontrato, idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    'Juan Rivas
    Public Function actualizaFechaGeneracion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal FECHAAPROBACION As String) As Integer
        Try
            Return mDb.actualizaFechaGeneracion(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, FECHAAPROBACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    'Henry Zavaleta
    Public Function ContratosEnProcesoCompra(ByVal idestablecimiento As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerContratosEnProcesoCompra(idestablecimiento, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Juan Rivas
    Public Function ActualizarEstadoContrato(ByVal aEntidad As entidadBase) As Integer
        Try
            Return mDb.ActualizarEstadoContrato(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    'Jrivas
    Public Function obtenerDependenciasConsultaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerDependenciasConsultaContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Jrivas
    Public Function obtenerClaseSuministroConsultaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerClaseSuministroConsultaContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'jRIVAS
    Public Function obteniendoFuenteFinanConsultaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obteniendoFuenteFinanConsultaContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Jrivas
    Public Function obteniendoCodigoBaseFechaAceptacionConsultaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer)
        Try
            Return mDb.obteniendoCodigoBaseFechaAceptacionConsultaContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Jrivas
    Public Function obtenerFechaDistribucionAMontoTotal(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obtenerFechaDistribucionAMontoTotal(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCONTRATO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Jrivas
    Public Function obteniendoDatosGarantiaConsultaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obteniendoDatosGarantiaConsultaContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Jrivas
    Public Function obteniendoInformacionProductosConsulta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obteniendoInformacionProductosConsulta(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Jrivas
    Public Function obteniendoDetalleProductosConsulta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obteniendoDetalleProductosConsulta(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function copiarDatosEntregaProductosContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCONTRATO As Integer, ByVal USUARIOCREACION As String, ByVal FECHACREACION As String, ByVal BORRAR As String) As Integer
        Try
            Return mDb.copiarDatosEntregaProductosContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDPROCESOCOMPRA, IDCONTRATO, USUARIOCREACION, FECHACREACION, BORRAR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerContratoModificativa(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerContratoModificativa(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDatasetContratosyOtrosDoc(ByVal idtipodocumento As Integer, ByVal numerodocumento As String, ByVal fechadocumento As Date, _
                                                     ByVal idmodalidad As Integer, ByVal numeromodalidad As String, ByVal idfuente As Integer, _
                                                     ByVal idresponsable As Integer, ByVal idalmacen As Integer, ByVal idtiposuministro As Integer, _
                                                     ByVal producto As String, ByVal idproveedor As Integer, ByVal entrega As Integer) As DataSet
        Try
            Return mDb.ObtenerDatasetContratosyOtrosDoc(idtipodocumento, numerodocumento, fechadocumento, idmodalidad, numeromodalidad, idfuente, idresponsable, idalmacen, idtiposuministro, producto, idproveedor, entrega)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDatasetContratosyOtrosDoc2(ByVal IDTIPODOCUMENTO As Integer, ByVal NUMERODOCUMENTO As String, _
                                                      ByVal IDMODALIDAD As Integer, ByVal IDALMACEN As Integer, ByVal IDTIPOSUMINISTRO As Integer, _
                                                      ByVal IDPROVEEDOR As Integer, ByVal PRODUCTO As String, ByVal ENTREGA As Integer, Optional ByVal IDESTABLECIMIENTO As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerDatasetContratosyOtrosDoc2(IDTIPODOCUMENTO, NUMERODOCUMENTO, IDMODALIDAD, IDALMACEN, IDTIPOSUMINISTRO, IDPROVEEDOR, PRODUCTO, ENTREGA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDatasetFuentesFinanciamientoContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.ObtenerDatasetFuentesFinanciamientoContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'jmejia
    Public Function ObtenerDatasetRenglonesContratoOtrosDoc(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDALMACEN As Integer) As DataSet
        Try
            Return mDb.ObtenerDatasetRenglonesContratoOtrosDoc(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'jmejia
    Public Function ObtenerDatasetRenglonesContratoOtrosDoc2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDALMACEN As Integer) As DataSet
        Try
            Return mDb.ObtenerDatasetRenglonesContratoOtrosDoc2(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDatasetRenglonesContratoOtrosDoc3(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, Optional ByVal IDALMACEN As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerDatasetRenglonesContratoOtrosDoc3(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerEntregasProgramadas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, Optional ByVal RENGLON As Integer = 0, Optional ByVal IDALMACEN As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerEntregasProgramadas(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerEntregasProgramadasXContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDALMACEN As Integer) As DataSet
        Try
            Return mDb.ObtenerEntregasProgramadasXContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDetalleEntregasContratoRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDALMACEN As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.ObtenerDetalleEntregasContratoRenglon(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDALMACEN, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDetalleEntregasContratoRenglon2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDALMACEN As Integer, ByVal ds As DataSet, Optional ByVal RENGLON As Integer = 0) As DataSet
        Try

            Dim i As Integer = 0 'Fila en la que estoy, seria la primera entrega para comenzar
            Dim filas As Integer = ds.Tables(0).Rows.Count 'Total de entregas que tiene el renglon

            Dim Entrega As Integer = ds.Tables(0).Rows(i).Item("ENTREGA")
            Dim CantidadEntrega As Decimal = ds.Tables(0).Rows(i).Item("CANTIDAD")

            Dim CantidadEntregada, TotalEntregado As Decimal

            Dim dsDetalle As DataSet

            dsDetalle = mDb.ObtenerDetalleEntregasContratoRenglon(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDALMACEN, RENGLON)

            dsDetalle.Tables(0).Columns.Add(New DataColumn("ENTREGA", System.Type.GetType("System.Int32")))

            For Each row As DataRow In dsDetalle.Tables(0).Rows

                CantidadEntregada = row("CANTIDAD")

                row("ENTREGA") = Entrega

                If TotalEntregado + CantidadEntregada > CantidadEntrega Then
                    i = Math.Min(i + 1, filas - 1)
                    Entrega = ds.Tables(0).Rows(i).Item("ENTREGA")
                    CantidadEntrega = ds.Tables(0).Rows(i).Item("CANTIDAD")
                    If Entrega <> row("ENTREGA") Then TotalEntregado = 0
                Else
                    TotalEntregado = TotalEntregado + CantidadEntregada
                End If

            Next

            Return dsDetalle

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDetalleEntregasXContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDALMACEN As Integer) As DataSet
        Try
            Return mDb.obtenerDetalleEntregasXContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'jmejia
    Public Function ObtenerDatasetRptRenglonesContratoOtrosDoc(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDALMACEN As Integer) As DataSet
        Try
            Return mDb.ObtenerDatasetRptRenglonesContratoOtrosDoc(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'jmejia
    Public Function ObtenerDatasetPlazosEntregaRenglonContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.ObtenerDatasetPlazosEntregaRenglonContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'jmejia
    Public Function ObtenerDatasetDocumentosRelacionados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.ObtenerDatasetDocumentosRelacionados(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'JMEJIA
    Public Function ObtenerDatasetRptEncabezadoContratosOtrosDoc(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.ObtenerDatasetRptEncabezadoContratosOtrosDoc(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDatasetRptContratosOtrosDoc(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Integer, ByVal IDALMACENENTREGA As Integer, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDatasetRptContratosOtrosDoc(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDALMACENENTREGA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ChequearContratosDistribuidos(ByVal idestablecimiento As Integer, ByVal idprocesocompra As Integer) As Boolean
        Try
            Return mDb.ChequearContratosDistribuidos(idestablecimiento, idprocesocompra)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'jmejia 
    Public Function DevolverContratoPeriodo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Int64, ByVal IDPROVEEDOR As Integer, ByVal dsP As DataSet) As DataSet
        Try
            Return mDb.DevolverContratoPeriodo(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, dsP)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' CCeconi
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROCESOCOMPRA"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerContratosProcesoCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, Optional ByVal IDPROVEEDOR As Integer = 0, Optional ByVal IDCONTRATO As Integer = 0, Optional ByVal IDESTADOCONTRATO As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerContratosProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDESTADOCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerRenglonesAmpliaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerRenglonesAmpliaContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerFechaAprobacion(ByVal idcontrato As Integer, ByVal idestablecimiento As Integer, ByVal idproveedor As Integer) As DateTime
        Try
            Return mDb.ObtenerFechaAprobacion(idcontrato, idestablecimiento, idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCantidadProveedores(ByVal idestablecimiento As Integer, ByVal idprocesocompra As Integer) As Integer
        Try
            Return mDb.ObtenerCantidadProveedores(idestablecimiento, idprocesocompra)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function validadNumContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCONTRATO As Integer) As Integer
        Try
            Return mDb.validadNumContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProveedores(ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.obtenerProveedores(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DiasAtraso(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal FECHAINICIO As String, ByVal FECHAFIN As String) As Integer
        Try
            Return mDb.DiasAtraso(IDESTABLECIMIENTO, IDPROVEEDOR, FECHAINICIO, FECHAFIN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function CalculoRechazo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer) As Integer
        Try
            Return mDb.CalculoRechazos(IDESTABLECIMIENTO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDatosContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obtenerDatosContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDatosContrato2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As CONTRATOS
        Try

            Dim eEntidad As CONTRATOS = mDb.obtenerDatosContrato2(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

            Dim cFFC As New cFUENTEFINANCIAMIENTOSCONTRATOS
            eEntidad.FUENTESFINANCIAMIENTO = cFFC.ObtenerFuentesFinanciamientoContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

            Dim cRDC As New cRESPONSABLEDISTRIBUCIONCONTRATO
            eEntidad.RESPONSABLEDISTRIBUCION = cRDC.obtenerResponsablesDistribucion(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

            Dim cMC As New cMODIFICATIVASCONTRATO
            eEntidad.MODIFICATIVASCONTRATO = cMC.ObtenerMODIFICATIVASCONTRATO(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

            Return eEntidad

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDatosAnticipo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPROCESOCOMPRA As Integer) As CONTRATOS
        Try

            Dim eEntidad As CONTRATOS = mDb.obtenerDatosAnticipo(IDESTABLECIMIENTO, IDPROVEEDOR, IDPROCESOCOMPRA)

            eEntidad.FUENTESFINANCIAMIENTO = "" '   mDb.ObtenerFuentesFinanciamientoContrato2(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
            eEntidad.RESPONSABLEDISTRIBUCION = "" 'mDb.ObtenerResponsablesDistribucion(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)

            Return eEntidad

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerRenglonesContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDALMACEN As Integer) As DataSet
        Try
            Return mDb.ObtenerRenglonesContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerRenglonesAdjudicacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDALMACEN As Integer) As DataSet
        Try
            Return mDb.ObtenerRenglonesAdjudicacion(IDESTABLECIMIENTO, IDPROVEEDOR, IDPROCESOCOMPRA, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
