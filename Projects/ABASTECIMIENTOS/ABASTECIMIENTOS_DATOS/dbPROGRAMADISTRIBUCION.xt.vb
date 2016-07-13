Partial Public Class dbPROGRAMADISTRIBUCION

#Region " Metodos Agregados "

    ''' <summary>
    ''' Devuelve una lista con todas las solicitudes correspondientes a un renglón.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>listaPROGRAMADISTRIBUCION</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' <item>SAB_UACI_PROGRAMADISTRIBUCION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerSolicitudesPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer) As listaPROGRAMADISTRIBUCION

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PD.IDESTABLECIMIENTOSOLICITA, ")
        strSQL.Append("PD.IDSOLICITUD, ")
        strSQL.Append("PD.CANTIDADSOLICITADA, ")
        strSQL.Append("PD.CANTIDADSOLICITADA / DPC.CANTIDAD PORCENTAJE, ")
        strSQL.Append("PD.IDALMACEN, pd.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
        strSQL.Append("ON (DPC.IDESTABLECIMIENTO = PD.IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = PD.IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.RENGLON = PD.RENGLON) ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.RENGLON = @RENGLON ")
        strSQL.Append("ORDER BY PORCENTAJE ASC ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaPROGRAMADISTRIBUCION

        Try
            If dr.HasRows Then

                Do While dr.Read()
                    Dim ePD As New PROGRAMADISTRIBUCION

                    ePD.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                    ePD.IDPROCESOCOMPRA = IDPROCESOCOMPRA
                    ePD.IDESTABLECIMIENTOSOLICITA = dr("IDESTABLECIMIENTOSOLICITA")
                    ePD.IDSOLICITUD = dr("IDSOLICITUD")
                    ePD.RENGLON = RENGLON
                    ePD.CANTIDADSOLICITADA = dr("CANTIDADSOLICITADA")
                    ePD.PORCENTAJE = dr("PORCENTAJE")
                    ePD.IDALMACEN = dr("IDALMACEN")
                    ePD.IDFUENTEFINANCIAMIENTO = dr("IDFUENTEFINANCIAMIENTO")

                    lista.Add(ePD)
                Loop

            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    ''' <summary>
    ''' Actualiza la cantidad adjudicada a una solicitud, correspondiente a un renglón dado.
    ''' </summary>
    ''' <param name="aEntidad">Entidad PROGRAMADISTRIBUCION con la información a actualizar.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_PROGRAMADISTRIBUCION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarCantidadAdjudicada(ByVal aEntidad As PROGRAMADISTRIBUCION) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("SAB_UACI_PROGRAMADISTRIBUCION ")
        strSQL.Append("SET CANTIDADADJUDICADA = @CANTIDADADJUDICADA, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTOSOLICITA ")
        strSQL.Append("AND RENGLON = @RENGLON ")
        strSQL.Append("AND IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("AND IDSOLICITUD = @IDSOLICITUD ")


        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@CANTIDADADJUDICADA", SqlDbType.BigInt)
        args(0).Value = aEntidad.CANTIDADADJUDICADA
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = aEntidad.AUUSUARIOMODIFICACION
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = aEntidad.AUFECHAMODIFICACION
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = aEntidad.IDESTABLECIMIENTO
        args(5) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(5).Value = aEntidad.IDPROCESOCOMPRA
        args(6) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(6).Value = aEntidad.IDESTABLECIMIENTOSOLICITA
        args(7) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(7).Value = aEntidad.RENGLON
        args(8) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(8).Value = aEntidad.IDALMACEN
        args(9) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(9).Value = aEntidad.IDFUENTEFINANCIAMIENTO
        args(10) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(10).Value = aEntidad.IDSOLICITUD

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza la cantidad adjudicada a cada solicitud de un renglón dado, según lo recomendado/adjudicado.
    ''' </summary>
    ''' <param name="aLista">Lista de entidades PROGRAMADISTRIBUCION donde se indican las cantidades correspondientes a cada solicitud.</param>
    ''' <param name="USUARIOMODIFICACION">Usuario que realiza la modificación.</param>
    ''' <param name="FECHAMODIFICACION">Fecha en la cual se realiza la modificación.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarCantidadAdjudicadaPorSolicitud(ByVal aLista As listaPROGRAMADISTRIBUCION, ByVal USUARIOMODIFICACION As String, ByVal FECHAMODIFICACION As String) As Integer

        Dim lEntidad As PROGRAMADISTRIBUCION

        For Each lEntidad In aLista
            lEntidad.AUUSUARIOMODIFICACION = USUARIOMODIFICACION
            lEntidad.AUFECHAMODIFICACION = FECHAMODIFICACION
            ActualizarCantidadAdjudicada(lEntidad)
        Next

        Return 1

    End Function

    Public Function ObtenerCantidadAdjudicadaAlmacen(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND CANTIDADADJUDICADA > 0 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(2).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Busca un programa de distribución para incluirse en el despacho de productos.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento de destino.</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento.</param>
    ''' <param name="TIPOPRODUCTO">Especifica el tipo de producto o suministro.</param>
    ''' <returns>Dataset con el programa de distribución.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROGRAMADISTRIBUCION</description></item>
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  20/02/2007    Creado
    ''' </history>
    Public Function BuscarProgramaParaDespacho(ByVal IDESTABLECIMIENTO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PD.IDESTABLECIMIENTO, ")
        strSQL.Append("PD.IDPROCESOCOMPRA, ")
        strSQL.Append("PD.IDESTABLECIMIENTOSOLICITA, ")
        strSQL.Append("PD.IDSOLICITUD, ")
        strSQL.Append("PD.RENGLON, ")
        strSQL.Append("PD.IDALMACEN, ")
        strSQL.Append("PD.CANTIDADADJUDICADA, ")
        strSQL.Append("PD.CANTIDADENTREGADA, ")
        strSQL.Append("CPC.IDPROVEEDOR, ")
        strSQL.Append("CPC.IDCONTRATO, ")
        strSQL.Append("FFC.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("EA.CANTIDADDISPONIBLE, ")
        strSQL.Append("(PD.CANTIDADADJUDICADA - PD.CANTIDADENTREGADA) CANTIDADPENDIENTE ")
        strSQL.Append("FROM ")
        strSQL.Append("vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON CP.IDPRODUCTO = PC.IDPRODUCTO ")
        strSQL.Append("RIGHT OUTER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON PD.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA AND PD.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("ON PC.RENGLON = PD.RENGLON AND PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND PC.IDPROVEEDOR = CPC.IDPROVEEDOR AND PC.IDCONTRATO = CPC.IDCONTRATO ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS FFC ")
        strSQL.Append("ON CPC.IDESTABLECIMIENTO = FFC.IDESTABLECIMIENTO AND CPC.IDPROVEEDOR = FFC.IDPROVEEDOR AND CPC.IDCONTRATO = FFC.IDCONTRATO ")
        strSQL.Append("INNER JOIN vv_EXISTENCIASALMACENES EA ")
        strSQL.Append("ON PC.IDPRODUCTO = EA.IDPRODUCTO AND PD.IDALMACEN = EA.IDALMACEN ")
        strSQL.Append("WHERE (PD.IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTO) AND (FFC.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO) AND (CP.IDSUMINISTRO = @IDSUMINISTRO) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(1).Value = IDFUENTEFINANCIAMIENTO
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(2).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Busca un programa de distribución para incluirse en el despacho de productos.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento de destino.</param>
    ''' <param name="IDPROVEEDOR">Identificador unico del proveedor.</param>
    ''' <param name="IDCONTRATO ">Identificador unico del contrato.</param>
    ''' <returns>Dataset con la información de contratos y procesos de compras.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROGRAMADISTRIBUCION</description></item>
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]
    ''' </history>
    Public Function BuscarProgramaProceso(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("C.IDESTABLECIMIENTO, ")
        strSQL.Append("C.IDPROVEEDOR, ")
        strSQL.Append("C.IDCONTRATO, ")
        strSQL.Append("CPC.IDPROCESOCOMPRA, ")
        strSQL.Append("C.IDCALIFICACIONCUMPLIMIENTO, ")
        strSQL.Append("C.IDCALIFICACIONCALIDAD ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS AS C ")
        strSQL.Append("ON CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND CPC.IDPROVEEDOR = C.IDPROVEEDOR AND ")
        strSQL.Append("CPC.IDCONTRATO = C.IDCONTRATO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (C.IDPROVEEDOR = @IDPROVEEDOR) AND (C.IDCONTRATO = @IDCONTRATO) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROCESOCOMPRA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]
    ''' </history>
    Public Function CuadroDistribucion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("A.NOMBRE ALMACEN, ")
        strSQL.Append("CPC.IDESTABLECIMIENTO IDESTABLECIMIENTOPROCESOCOMPRA, ")
        strSQL.Append("CPC.IDPROCESOCOMPRA, ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("AEC.IDESTABLECIMIENTO IDESTABLECIMIENTOCONTRATO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTOSOLICITA, ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("CP.CORRPRODUCTO CODIGOPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO DESCPRODUCTO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("sum(AEC.CANTIDAD) CANTIDADADJUDICADA, ")
        strSQL.Append("isnull(sum(AEC.CANTIDADENTREGADA), 0) CANTIDADENTREGADA, ")
        strSQL.Append("sum(AEC.CANTIDAD) - isnull(sum(AEC.CANTIDADENTREGADA), 0) CANTIDADADPENDIENTE, ")
        strSQL.Append("( ")
        strSQL.Append("select ")
        strSQL.Append("max( ")
        strSQL.Append("case ")
        strSQL.Append("when AEC1.CANTIDAD - AEC1.CANTIDADENTREGADA > 0 and datediff(day, dateadd(day, EC1.PLAZOENTREGA, C1.FECHADISTRIBUCION), getdate()) > 0 then ")
        strSQL.Append("convert(varchar, datediff(day, dateadd(day, EC1.PLAZOENTREGA, C1.FECHADISTRIBUCION), getdate()), 103) ")
        strSQL.Append("else ")
        strSQL.Append("0 ")
        strSQL.Append("end) ")
        strSQL.Append("from SAB_UACI_ALMACENESENTREGACONTRATOS AEC1 ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGACONTRATO EC1 ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = EC1.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC1.IDPROVEEDOR = EC1.IDPROVEEDOR ")
        strSQL.Append("AND AEC1.IDCONTRATO = EC1.IDCONTRATO ")
        strSQL.Append("AND AEC1.RENGLON = EC1.RENGLON ")
        strSQL.Append("AND AEC1.IDDETALLE = EC1.IDDETALLE ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C1 ")
        strSQL.Append("ON (AEC1.IDESTABLECIMIENTO = C1.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC1.IDPROVEEDOR = C1.IDPROVEEDOR ")
        strSQL.Append("AND AEC1.IDCONTRATO = C1.IDCONTRATO) ")
        strSQL.Append("WHERE AEC1.IDESTABLECIMIENTO = AEC.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC1.IDPROVEEDOR = AEC.IDPROVEEDOR ")
        strSQL.Append("AND AEC1.IDCONTRATO = AEC.IDCONTRATO ")
        strSQL.Append("AND AEC1.RENGLON = AEC.RENGLON ")
        strSQL.Append("AND AEC1.IDALMACENENTREGA = AEC.IDALMACENENTREGA ")
        strSQL.Append(") DIASATRASO ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON (AEC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = CPC.IDCONTRATO) ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON (CPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA) ")
        strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
        strSQL.Append("ON (CPC.IDESTABLECIMIENTO = PD.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = PD.IDPROCESOCOMPRA ")
        strSQL.Append("AND AEC.RENGLON = PD.RENGLON ")
        strSQL.Append("AND AEC.IDALMACENENTREGA = PD.IDALMACEN) ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC1 ")
        strSQL.Append("ON (AEC.IDESTABLECIMIENTO = PC1.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = PC1.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = PC1.IDCONTRATO ")
        strSQL.Append("AND AEC.RENGLON = PC1.RENGLON) ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND CPC.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC1.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON CPC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON AEC.IDALMACENENTREGA = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PD.IDESTABLECIMIENTOSOLICITA = E.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE CPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND (AEC.IDALMACENENTREGA = @IDALMACEN OR @IDALMACEN = 0) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("AEC.IDALMACENENTREGA, ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("CPC.IDESTABLECIMIENTO, ")
        strSQL.Append("CPC.IDPROCESOCOMPRA, ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("AEC.IDESTABLECIMIENTO, ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("AEC.IDCONTRATO, ")
        strSQL.Append("P.NOMBRE, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("E.NOMBRE, ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION ")
        strSQL.Append("ORDER BY ")
        strSQL.Append("P.NOMBRE, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("AEC.RENGLON, ")
        strSQL.Append("A.NOMBRE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene todos los procesos de compra que incluyen entregas en el almacén indicado.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén destino.</param>
    ''' <returns>Dataset.</returns>
    ''' <remarks>Lista de tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_PROCESOCOMPRAS</item>
    ''' <item>SAB_UACI_PROGRAMADISTRIBUCION</item>
    ''' <item>SAB_CAT_ESTABLECIMIENTOS</item>
    ''' <item>SAB_CAT_TIPOCOMPRAS</item>
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerProcesosCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROCESOCOMPRA, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTO, ")
        strSQL.Append("PC.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.IDPROCESOCOMPRA, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTO, ")
        strSQL.Append("isnull(TC.DESCRIPCION, '') DESCRIPCION, ")
        strSQL.Append("isnull(PC.CODIGOLICITACION, '') CODIGOLICITACION, ")
        strSQL.Append("isnull(PC.TITULOLICITACION, '') TITULOLICITACION, ")
        strSQL.Append("isnull(PC.DESCRIPCIONLICITACION, '') DESCRIPCIONLICITACION, ")
        strSQL.Append("isnull(PC.NUMERORESOLUCION, '') NUMERORESOLUCION, ")
        strSQL.Append("EPC.DESCRIPCION ESTADO ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA) ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND CPC.IDCONTRATO = C.IDCONTRATO) ")


        strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")


        strSQL.Append("ON (C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND C.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("AND C.IDCONTRATO = CPC.IDCONTRATO) ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOPROCESOSCOMPRAS EPC ")
        strSQL.Append("ON PC.IDESTADOPROCESOCOMPRA = EPC.IDESTADOPROCESOCOMPRA ")
        strSQL.Append("WHERE (PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO OR @IDESTABLECIMIENTO = 0) ")
        strSQL.Append("AND (AEC.IDALMACENENTREGA = @IDALMACEN OR @IDALMACEN = 0) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ActualizarCantidadEntregada(ByVal aEntidad As PROGRAMADISTRIBUCION) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("SAB_UACI_PROGRAMADISTRIBUCION ")
        strSQL.Append("SET CANTIDADENTREGADA = @CANTIDADENTREGADA, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTOSOLICITA ")
        strSQL.Append("AND RENGLON = @RENGLON ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.BigInt)
        args(0).Value = aEntidad.CANTIDADENTREGADA
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = aEntidad.AUUSUARIOMODIFICACION
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = aEntidad.AUFECHAMODIFICACION
        args(3) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(3).Value = aEntidad.IDESTABLECIMIENTO
        args(4) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(4).Value = aEntidad.IDPROCESOCOMPRA
        args(5) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(5).Value = aEntidad.IDESTABLECIMIENTOSOLICITA
        args(6) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(6).Value = aEntidad.RENGLON

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function Recuperar2(ByVal aEntidad As PROGRAMADISTRIBUCION) As Integer

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTOSOLICITA = @IDESTABLECIMIENTOSOLICITA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDESTABLECIMIENTOSOLICITA", SqlDbType.Int)
        args(2).Value = aEntidad.IDESTABLECIMIENTOSOLICITA
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = aEntidad.RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With ds.Tables(0).Rows(0)
                aEntidad.IDALMACEN = IIf(.Item("IDALMACEN") Is DBNull.Value, Nothing, .Item("IDALMACEN"))
                aEntidad.CANTIDADSOLICITADA = IIf(.Item("CANTIDADSOLICITADA") Is DBNull.Value, Nothing, .Item("CANTIDADSOLICITADA"))
                aEntidad.CANTIDADADJUDICADA = IIf(.Item("CANTIDADADJUDICADA") Is DBNull.Value, Nothing, .Item("CANTIDADADJUDICADA"))
                aEntidad.CANTIDADENTREGADA = IIf(.Item("CANTIDADENTREGADA") Is DBNull.Value, Nothing, .Item("CANTIDADENTREGADA"))
                aEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                aEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                aEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                aEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                aEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Function ObtenerAlmacenFosIsss(ByVal IDESTABLECIMIENTO As Integer, ByVal idprocesocompra As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT  * ")
        strSQL.Append("FROM SAB_UACI_PROGRAMADISTRIBUCION ")
        strSQL.Append("WHERE IDPROCESOCOMPRA=@IDPROCESOCOMPRA AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")
        strSQL.Append("AND IDALMACEN IN (114,499,116)  ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = idprocesocompra

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function


    Public Function ObtenerCantidadAdjudicadaAlmacenSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append("SELECT  IDALMACEN,  SUM (CANTIDADADJUDICADA) as CANTIDADADJUDICADA ,IDESTABLECIMIENTO, IDPROCESOCOMPRA, ")
        strSQL.Append("IDFUENTEFINANCIAMIENTO FROM SAB_UACI_PROGRAMADISTRIBUCION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO And IDPROCESOCOMPRA = @IDPROCESOCOMPRA And CANTIDADADJUDICADA > 0 ")
        strSQL.Append("And RENGLON = @RENGLON ")
        strSQL.Append("GROUP By IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON, IDALMACEN, IDFUENTEFINANCIAMIENTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(2).Value = RENGLON


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function

#End Region

End Class
