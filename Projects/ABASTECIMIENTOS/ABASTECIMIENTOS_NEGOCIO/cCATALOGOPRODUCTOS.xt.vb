Partial Public Class cCATALOGOPRODUCTOS

#Region " METODOS AGREGADOS "

    Public Function ObtenerDataSetPorIDProducto(ByVal IDPRODUCTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorIDProducto(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorCodigoProducto(ByVal IDPRODUCTO As String) As DataSet
        Try
            Return mDb.ObtenerDataSetPorCodigoProducto(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por codigo producto usado por MSPAS
    ''' </summary>
    ''' <param name="IDPRODUCTO"></param> 'codigo de producto usado por el MSPAS
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetPorCodigoProductoHabilitados(ByVal IDPRODUCTO As String, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorCodigoProductoHabilitado(IDPRODUCTO, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCatalogoProductos() As DataSet
        Try
            Return mDb.ObtenerCatalogoProductos()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function FiltrarCatalogoProductos(ByVal BCRITERIO As String, ByVal BTIPO As Int16, ByVal BCERO As Int16) As DataSet
        Try
            Return mDb.FiltrarCatalogoProductos(BCRITERIO, BTIPO, BCERO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtiene informacion de catalogo de productos de la vista vv_CATALOGOPRODUCTOS
    ''' </summary>
    ''' <returns>
    ''' Dataset con toda la informacion de la vista
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompleto() As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompleto()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProductosAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.obtenerProductosAdjudicados(IDESTABLECIMIENTO, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'JRivas
    Public Function obtenerProductosAdjudicadosProCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerProductosAdjudicadosProCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos de la vista vv_CATALOGOPRODUCTOS filtrada por grupo
    ''' </summary>
    ''' <param name="IDgrupo"></param> 'identificador grupo
    ''' <returns>
    ''' Data set con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoXgrupo(ByVal IDgrupo As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoPorGrupo(IDgrupo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos de la vista vv_CATALOGOPRODUCTOS filtrada por subgrupo
    ''' </summary>
    ''' <param name="IDsubgrupo"></param> 'identificador de subgrupo
    ''' <returns>
    ''' Data set con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoPorSubgrupo(ByVal IDSUBGRUPO As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoPorSubgrupo(IDSUBGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProductosxTipoUACI(ByVal IDSUBGRUPO As Int32) As DataSet
        Try
            Return mDb.ObtenerProductosxTipoUACI(IDSUBGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerTipoUACI() As DataSet
        Try
            Return mDb.ObtenerTipoUACI()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerTipoUACI(ByVal IDAREATECNICA As Integer) As DataSet
        Try
            Return mDb.ObtenerTipoUACI(IDAREATECNICA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerAreaTecnicaByGRUPOUACI(ByVal grupoUACI As Integer) As DataSet
        Try
            Return mDb.ObtenerAreaTecnicaByGRUPOUACI(grupoUACI)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerCatalogoProductosCompletoPorSubgrupo2(ByVal IDSUBGRUPO As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoPorSubgrupo2(IDSUBGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos de la vista vv_CATALOGOPRODUCTOS filtrada por suministro
    ''' </summary>
    ''' <param name="IDsuministro"></param> 'identificador de suministro
    ''' <returns>
    ''' Data set con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoXsuministro(ByVal IDsuministro As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoPorSuministro(IDsuministro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCatalogoProductosCompletoHabilitados(ByVal IDSUMINISTRO As Int32, Optional ByVal criterio As String = "") As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoHabilitados(IDSUMINISTRO, criterio)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function



    Public Function ObtenerCatalogoProductosCompletoOficial(ByVal IDSUMINISTRO As Int32, Optional ByVal criterio As String = "") As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoOficial(IDSUMINISTRO, criterio)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    '''  obtener informacion de catalogo de productos habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' Dataset con la informacion de la vista
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_PRODUCTOSHABILITADOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoHabilitadoEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoHabilitadoEstablecimiento(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por grupo
    ''' </summary>
    ''' <param name="IDgrupo"></param> 'identificador de grupo
    ''' <param name="IDESTABLECIMIENTO"></param> 'idetificador de parametro
    ''' <returns>
    '''  ''' Dataset con la informacion de la vista filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoHabilitadoXgrupo(ByVal IDgrupo As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoHabilitadoPorGrupo(IDgrupo, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por subgrupo
    ''' </summary>
    ''' <param name="IDsubgrupo"></param> 'identifiacdor de subgrupo
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoHabilitadoXsubgrupo(ByVal IDsubgrupo As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosHabilitadosCompletoPorSubgrupo(IDsubgrupo, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por suministro
    ''' </summary>
    ''' <param name="IDsuministro"></param> 'identificador de suministro
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoHabilitadoXsuministro(ByVal IDsuministro As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoHabilitadoPorSuministro(IDsuministro, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerRenglonesAdjudicadosOferta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerRenglonesAdjudicadosOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaPorID(ByVal BCRITERIO As String, ByVal BTIPO As Int16) As listaCATALOGOPRODUCTOS
        Try
            Return mDb.ObtenerListaPorID(BCRITERIO, BTIPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorContratoProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorContratoProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorPeriodoProcesoCompra(ByVal Fini As Date, ByVal Ffin As Date, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorPeriodoProcesoCompra(Fini, Ffin, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DevolverProducto(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPRODUCTO As Integer) As DataSet
        Try
            Return mDb.DevolverProducto(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerIDPRODUCTO() As Integer
        Try
            Return mDb.ObtenerIDPRODUCTO()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarCP(Optional ByVal NM As Integer = 0) As DataSet
        Try
            Return mDb.RecuperarCP(NM)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarCatalogoNoMedico(Optional ByVal IDESTABLECIMIENTO As Integer = 0) As DataSet
        Try
            Return mDb.RecuperarCatalogoNoMedico(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarCP2(ByVal IDSUBGRUPO As Integer, Optional ByVal NM As Integer = 0) As DataSet
        Try
            Return mDb.RecuperarCP2(IDSUBGRUPO, NM)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener catalogo de productos de productos de la vista vv_CATALOGOPRODUCTOS filtrado por tipo de suministros no medico
    ''' y por codigo de producto utilizado por el MSPAS
    ''' </summary>
    ''' <param name="IDPRODUCTO"></param> 'Codigo producto utilizado por MSPAS
    ''' <param name="IDTIPOSUMINISTRO"></param> 'idtificador del tipo de suministro
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetPorCodigoProductoNoMedico(ByVal IDPRODUCTO As String, ByVal IDTIPOSUMINISTRO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorCodigoProductosNoMedicos(IDPRODUCTO, IDTIPOSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorCodigoProductoNoMedicoConHomogeneos(ByVal IDPRODUCTO As String, ByVal IDTIPOSUMINISTRO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorCodigoProductoNoMedicoConHomogeneos(IDPRODUCTO, IDTIPOSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener catalogo de productos de productos de la vista vv_CATALOGOPRODUCTOS filtrado por tipo de suministros no medico
    ''' </summary>
    ''' <param name="IDSUMINISTRO"></param> 'identificador del suministro
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompleto(ByVal IDSUMINISTRO As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompleto(IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCatalogoProductosCompletoNoMedicoConHomogeneos(ByVal IDSUMINISTRO As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoNoMedicoConHomogeneos(IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener catalogo de productos de productos de la vista vv_CATALOGOPRODUCTOS filtrado por tipo de suministros no medico
    ''' y el grupo al que pertenece
    ''' </summary>
    ''' <param name="IDgrupo"></param> 'identificador de grupo
    ''' <param name="IDTIPOSUMINISTRO"></param> 'identificador de suministro
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS </description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCatalogoProductosCompletoXgrupoNoMedico(ByVal IDgrupo As Int32, ByVal IDTIPOSUMINISTRO As Int32) As DataSet
        Try
            Return mDb.ObtenerCatalogoProductosCompletoPorGrupoNoMedico(IDgrupo, IDTIPOSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos por suministro habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por codigo producto usado por MSPAS
    ''' </summary>
    ''' <param name="IDPRODUCTO"></param> 'identificador producto
    ''' <param name="IDSUMINISTRO"></param> identificador de suministro
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetPorCodigoXSuministro(ByVal IDPRODUCTO As String, ByVal IDSUMINISTRO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorCodigoXSuministro(IDPRODUCTO, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener informacion de catalogo de productos por suministro habilitados por establecimiento de la vista vv_PRODUCTOSHABILITADOS filtrada por codigo producto usado por MSPAS
    ''' </summary>
    ''' <param name="IDPRODUCTO"></param> 'identificador producto
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDSUMINISTRO"></param> identificador de suministro
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerDataSetPorCodigoProductoHabilitadoXSuministro(ByVal IDPRODUCTO As String, ByVal IDESTABLECIMIENTO As Int32, ByVal IDSUMINISTRO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorCodigoProductoHabilitadoXSuministro(IDPRODUCTO, IDESTABLECIMIENTO, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarProducto(ByVal IDPRODUCTO As Integer) As Integer
        Try
            Return mDb.EliminarProducto(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProximoCorrProducto(ByVal IDSUBGRUPO As Integer) As String
        Try
            Return mDb.DevolverProxCorrProducto(IDSUBGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DevolverProductoPeriodo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Int64, ByVal dsP As DataSet) As DataSet
        Try
            Return mDb.DevolverProductoPeriodo(IDESTABLECIMIENTO, IDPRODUCTO, dsP)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ExisteCodigo(ByVal CODIGO As String, Optional ByVal IDPRODUCTO As Int64 = 0) As Boolean
        Try
            Return mDb.ExisteCodigo(CODIGO, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DevolverIDProducto(ByVal CODIGO As String) As Integer
        Try
            Return mDb.DevolverIDProducto(CODIGO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#Region " METODOS ALMACEN "

    ''' <summary>
    ''' Devuelve un listado de productos filtrado por un criterio, dicho criterio puede ser el IDPRODUCTO o el CODIGO el 
    ''' cual se especifica en el parametro IDTIPOCONSULTA.
    ''' </summary>
    ''' <param name="CRITERIO">Criterio utilizado para filtrar la información.</param>
    ''' <param name="IDTIPOCONSULTA">Define el campo utilizado para filtrar la información</param>
    ''' <returns>Dataset con el listado de productos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_MOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_ESTADOSMOVIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' <item><description>SAB_CAT_TIPODOCUMENTOREFERENCIAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  31/12/2006    Creado
    ''' </history> 
    Public Function FiltrarProductoDS(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Int16, Optional ByVal PERTENECELISTADOOFICIAL As Integer = 0) As DataSet
        Try
            Return mDb.FiltrarProductoDS(CRITERIO, IDTIPOCONSULTA, PERTENECELISTADOOFICIAL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function FiltrarProductoDSUT(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Int16, ByVal AREATECNICA As Integer, Optional ByVal PERTENECELISTADOOFICIAL As Integer = 0) As DataSet
        Try
            Return mDb.FiltrarProductoDSUT(CRITERIO, IDTIPOCONSULTA, AREATECNICA, PERTENECELISTADOOFICIAL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function FiltrarProductoDSUTyGUSuminitro(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Int16, ByVal AREATECNICA As Integer, ByVal GU As Integer, Optional ByVal PERTENECELISTADOOFICIAL As Integer = 0) As DataSet
        Try
            Return mDb.FiltrarProductoDSUTyGUSuministros(CRITERIO, IDTIPOCONSULTA, AREATECNICA, GU, PERTENECELISTADOOFICIAL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function FiltrarProductoDSUTyGU(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Int16, ByVal AREATECNICA As Integer, ByVal GU As Integer, Optional ByVal PERTENECELISTADOOFICIAL As Integer = 0) As DataSet
        Try
            Return mDb.FiltrarProductoDSUTyGU(CRITERIO, IDTIPOCONSULTA, AREATECNICA, GU, PERTENECELISTADOOFICIAL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Devuelve el código de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <returns>Cadena de texto con el código del producto.</returns>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/02/2007   Creado
    ''' </history> 
    Public Function DevolverCodigoProducto(ByVal IDPRODUCTO As Integer) As String
        'JOSE CHAVEZ
        Try
            Return mDb.DevolverCodigoProducto(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve la unidad de medida de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <returns>Cadena de texto con la unidad de medida del producto.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/02/2007   Creado
    ''' </history> 
    Public Function DevolverUMProducto(ByVal IDPRODUCTO As Integer) As String
        Try
            Return mDb.DevolverUMProducto(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function DevolverPrecioProducto(ByVal IDPRODUCTO As Integer) As String
        Try
            Return mDb.DevolverPrecioProducto(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Devuelve el nombre de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <returns>Cadena de texto con el nombre del producto.</returns>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/02/2007   Creado
    ''' </history> 
    Public Function DevolverNombreProducto(ByVal IDPRODUCTO As Integer) As String
        Try
            Return mDb.DevolverNombreProducto(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve el identificador de la unidad de medida de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <returns>Cadena de texto con el identificador de la unidad de medida del producto.</returns>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/02/2007   Creado
    ''' </history> 
    Public Function DevolverIDUMProducto(ByVal IDPRODUCTO As Integer) As String
        Try
            Return mDb.DevolverIDUMProducto(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve un listado de productos filtrado por un criterio, dicho criterio puede ser el IDPRODUCTO o el CODIGO el 
    ''' cual se especifica en el parametro IDTIPOCONSULTA.
    ''' </summary>
    ''' <param name="CRITERIO">Criterio utilizado para filtrar la información.</param>
    ''' <param name="IDTIPOCONSULTA">Define el campo utilizado para filtrar la información</param>
    ''' <returns>Dataset con el listado de productos.</returns>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  31/12/2006    Creado
    ''' </history> 
    Public Function FiltrarProductoDSAlmacen(ByVal CRITERIO As String, ByVal IDTIPOCONSULTA As Int16, Optional ByVal IDSUMINISTRO As Integer = 0) As DataSet
        Try
            Return mDb.FiltrarProductoDSAlmacen(CRITERIO, IDTIPOCONSULTA, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

    Public Function ObtenerListaDescripcionLarga(Optional ByVal IDSUMINISTRO As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerListaDescripcionLarga(IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve el listado de productos con existencias de un almacén.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del producto.</param>
    ''' <returns>Dataset con la lista de productos.</returns>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  07/02/2007   Creado
    ''' </history> 
    Public Function FiltrarProductosConExistencia(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int32, ByVal IDSUBGRUPO As Int32, Optional ByVal IDTIPOFILTRO As Int16 = 0) As DataSet
        Try
            Return mDb.FiltrarProductosConExistencia(IDALMACEN, IDSUMINISTRO, IDSUBGRUPO, IDTIPOFILTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarProducto(ByVal IDPRODUCTO As Integer, ByVal CODIGO As String, ByVal IDSUBGRUPO As Integer, ByVal IDALMACEN As Integer, ByVal CANTIDADDISPONIBLE As Integer, ByVal CANTIDADNODISPONIBLE As Integer, ByVal CANTIDADVENCIDA As Integer, ByVal CANTIDADRESERVADA As Integer, ByVal CANTIDADTEMPORAL As Integer) As DataSet
        Try
            Return mDb.BuscarProducto(IDPRODUCTO, CODIGO, IDSUBGRUPO, IDALMACEN, CANTIDADDISPONIBLE, CANTIDADNODISPONIBLE, CANTIDADVENCIDA, CANTIDADRESERVADA, CANTIDADTEMPORAL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function devolverEntidadVista(ByVal idProducto As Integer) As CATALOGOPRODUCTOS

        Try
            Return mDb.devolverEntidadVista(idProducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return New CATALOGOPRODUCTOS
        End Try

    End Function

#End Region
    Public Function ObtenerPreciosHistoricosUACI(ByVal codigo As String) As DataSet
        'Try
        Return mDb.ObtenerPreciosHistoricosUACI(codigo)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ObtenerCatalogoProductosPorUT(ByVal IDSUBGRUPO As Int32, ByVal AREATECNICA As Integer) As DataSet
        'Try
        Return mDb.ObtenerCatalogoProductosPorUT(IDSUBGRUPO, AREATECNICA)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ObtenerCatalogoProductosPorUTyGU(ByVal IDSUBGRUPO As Int32, ByVal AREATECNICA As Integer, ByVal GU As Integer) As DataSet
        'Try
        Return mDb.ObtenerCatalogoProductosPorUTyGU(IDSUBGRUPO, AREATECNICA, GU)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ObtenerCatalogoProductosPorUT2(ByVal IDSUBGRUPO As Int32, ByVal AREATECNICA As Integer) As DataSet
        'Try
        Return mDb.ObtenerCatalogoProductosPorUT2(IDSUBGRUPO, AREATECNICA)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ObtenerListaSolicitudesxProducto(ByVal IdProducto As Int32) As DataSet
        'Try
        Return mDb.ObtenerListaSolicitudesxProducto(IdProducto)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ObtenerListaPCxProducto(ByVal IdProducto As Int32) As DataSet
        'Try
        Return mDb.ObtenerListaPCxProducto(IdProducto)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ObtenerListaEstablecimientoxProducto(ByVal IdProducto As Int32) As DataSet
        'Try
        Return mDb.ObtenerListaEstablecimientosxProducto(IdProducto)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ObtenerInformacionSINAB(ByVal IdProducto As Integer, ByVal mSC As Integer, ByVal mPC As Integer, ByVal mPE As Integer, ByVal mD As Integer, ByVal vSc As Integer, ByVal vPc As Integer, ByVal vE As Integer) As DataSet
        'Try
        Return mDb.ObtenerInformacionSINAB(IdProducto, mSC, mPC, mPE, mD, vSc, vPc, vE)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ObtenerEspecificacionesTecnicas(ByVal IdProducto As Integer) As DataSet
        'Try
        Return mDb.ObtenerEspecificacionesTecnicas(IdProducto)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ObtenerIDEspecificacionesTecnicas(ByVal IdProducto As Integer) As Integer
        'Try
        Return mDb.ObtenerIDEspecificacionesTecnicas(IdProducto)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function AgregarEspecificacionesTecnicas(ByVal lE As ESPECIFICACION) As Integer
        'Try
        Return mDb.AgregarEspecificacionesTecnicas(lE)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function DevolverTextoEspecificacion(ByVal IDPRODUCTO As Integer, ByVal IDESPECIFICACION As Integer) As String
        'Try
        Return mDb.DevolverTextoEspecificacion(IDPRODUCTO, IDESPECIFICACION)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ActualizarEspecificacionesTecnicas(ByVal lE As ESPECIFICACION) As Integer
        'Try
        Return mDb.ActualizarEspecificacionesTecnicas(lE)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ActualizarPreciosCatalogoProductos(ByVal idestablecimiento As Integer, ByVal idprocesocompra As Integer) As Integer
        'Public Function ObtenerCatalogoProductosCompletoPorSuministro(ByVal IDSUMINISTRO As Int32, Optional ByVal CRITERIO As String = "") As DataSet
        'Try
        ' Return mDb.ObtenerCatalogoProductosCompletoPorSuministro(IDSUMINISTRO, CRITERIO)
        Return mDb.ActualizarPreciosCatalogoProductos(idestablecimiento, idprocesocompra)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
    Public Function ObtenerCatalogoProductosCompletoPorSuministro(ByVal IDSUMINISTRO As Int32, Optional ByVal CRITERIO As String = "") As DataSet
        'Try
        Return mDb.ObtenerCatalogoProductosCompletoPorSuministro(IDSUMINISTRO, CRITERIO)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try

    End Function
    'Public Function ObtenerEspecificoGasto() As DataSet
    ''      Try
    '          Return mDb.ObtenerEspecificoGasto()
    '      Catch ex As Exception
    '          ExceptionManager.Publish(ex)
    '          Return Nothing
    ''      End Try
    '  End Function
    Public Function ObtenerECOSValorizados(ByVal Idregion As Integer, ByVal mes As Integer, ByVal anio As Integer) As DataSet
        'Try
        Return mDb.ObtenerECOSValorizados(Idregion, mes, anio)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function
End Class
