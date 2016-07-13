Partial Public Class dbLOTES

#Region " Métodos Agregados "

    ''' <summary>
    ''' Obtener el listado de lotes
    ''' </summary>
    ''' <param name="CODIGOPRODUCTO">identificador del codigo del producto</param>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <returns>Listado de lotes en formato de dataset</returns>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerDsLote(ByVal CODIGOPRODUCTO As String, ByVal IDALMACEN As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.FECHAVENCIMIENTO, FF.NOMBRE, L.PRECIOLOTE, L.IDUNIDADMEDIDA, L.CANTIDADDISPONIBLE, L.CANTIDADNODISPONIBLE, ")
        strSQL.Append(" L.CANTIDADVENCIDA, L.IDLOTE, RD.NOMBRE AS RESPONSABLEDISTRIBUCION ")
        strSQL.Append(" FROM SAB_ALM_LOTES AS L INNER JOIN ")
        strSQL.Append(" SAB_CAT_FUENTEFINANCIAMIENTOS AS FF ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_RESPONSABLEDISTRIBUCION AS RD ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS AS CC ON L.IDPRODUCTO = CC.IDPRODUCTO ")
        strSQL.Append(" WHERE (CC.CODIGO = '" & CODIGOPRODUCTO & "') AND (L.IDALMACEN = " & IDALMACEN & ") ")
        strSQL.Append(" ORDER BY L.FECHAVENCIMIENTO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Recupera el listado de lotes disponibles en un almacén determinado y filtrado por
    ''' los diferentes campos de disponibilidad.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <param name="IDALMACEN">Identificador del almacén.</param>
    ''' <param name="TIPOFILTRO">Especifica que cantidad a de ser validada.</param>
    ''' <returns>Dataset con el listado de lotes por disponibilidad.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  18/01/2007    Creado
    ''' </history> 
    Public Function ObtenerDsLoteFiltrado(ByVal IDPRODUCTO As Int32, ByVal IDALMACEN As Int64, ByVal TIPOFILTRO As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.IDUNIDADMEDIDA, ")
        strSQL.Append("UM.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("case @TIPOFILTRO ")
        strSQL.Append("when 1 then L.CANTIDADDISPONIBLE ")
        strSQL.Append("when 2 then L.CANTIDADNODISPONIBLE ")
        strSQL.Append("when 3 then L.CANTIDADVENCIDA ")
        strSQL.Append("when 4 then L.CANTIDADRESERVADA ")
        strSQL.Append("when 5 then L.CANTIDADTEMPORAL ")
        strSQL.Append("end CANTIDAD, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("case when L.CODIGO is null then case when L.DETALLE is null then '(N/A)' else L.DETALLE end else L.CODIGO + isnull(L.DETALLE, '') end CODIGODETALLE, ")
        strSQL.Append("isnull(L.CODIGO + isnull(' - ' + convert(varchar, month(L.FECHAVENCIMIENTO)) + '/' + convert(varchar, year(L.FECHAVENCIMIENTO)),''), '(N/A)') CODIGOFECHA ")
        strSQL.Append("FROM SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN SAB_CAT_UNIDADMEDIDAS UM ")
        strSQL.Append("ON L.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("WHERE L.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND L.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0) ")
        strSQL.Append("AND L.ESTADISPONIBLE = 1 ")
        strSQL.Append("ORDER BY L.FECHAVENCIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = IDALMACEN
        args(2) = New SqlParameter("@TIPOFILTRO", SqlDbType.Int)
        args(2).Value = TIPOFILTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Listado de lotes filtrados
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDPRODUCTO">Identificador del producto</param>
    ''' <param name="CODIGO">Identificador del codigo</param>
    ''' <param name="TIPOFILTRO">Identificador del tipo de filtro</param>
    ''' <returns>Listado en formato de dataset</returns>
    Public Function ObtenerDsLoteFiltrado2(ByVal IDALMACEN As Int64, ByVal IDSUMINISTRO As Integer, ByVal IDPRODUCTO As Integer, ByVal CODIGO As String, ByVal TIPOFILTRO As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("WHERE (CP.CORRPRODUCTO = @CORRPRODUCTO OR CP.IDPRODUCTO = @IDPRODUCTO) ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.VarChar)
        args(0).Value = IDSUMINISTRO
        args(1) = New SqlParameter("@CORRPRODUCTO", SqlDbType.VarChar)
        args(1).Value = CODIGO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then
            Return Nothing
        Else
            strSQL.Length = 0
            strSQL.Append("SELECT ")
            strSQL.Append("L.IDPRODUCTO, ")
            strSQL.Append("CP.CORRPRODUCTO, ")
            strSQL.Append("CP.DESCLARGO, ")
            strSQL.Append("CP.CANTIDADDECIMAL, ")
            strSQL.Append("L.IDLOTE, ")
            strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
            strSQL.Append("case when L.CODIGO is null then case when L.DETALLE is null then '(N/A)' else L.DETALLE end else L.CODIGO + isnull(L.DETALLE, '') end CODIGODETALLE, ")
            strSQL.Append("isnull(L.CODIGO + isnull(' - ' + convert(varchar, month(L.FECHAVENCIMIENTO)) + '/' + convert(varchar, year(L.FECHAVENCIMIENTO)),''), '(N/A)') CODIGOFECHA, ")
            strSQL.Append("L.FECHAVENCIMIENTO, ")
            strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
            strSQL.Append("L.PRECIOLOTE, ")
            strSQL.Append("L.IDUNIDADMEDIDA, ")
            strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
            strSQL.Append("L.CANTIDADDISPONIBLE, ")
            strSQL.Append("L.CANTIDADNODISPONIBLE, ")
            strSQL.Append("L.CANTIDADVENCIDA, ")
            strSQL.Append("L.CANTIDADRESERVADA, ")
            strSQL.Append("L.CANTIDADTEMPORAL, ")
            strSQL.Append("case @TIPOFILTRO ")
            strSQL.Append("when 1 then L.CANTIDADDISPONIBLE ")
            strSQL.Append("when 2 then L.CANTIDADNODISPONIBLE ")
            strSQL.Append("when 3 then L.CANTIDADVENCIDA ")
            strSQL.Append("when 4 then L.CANTIDADRESERVADA ")
            strSQL.Append("when 5 then L.CANTIDADTEMPORAL ")
            strSQL.Append("when 6 then case when L.CANTIDADDISPONIBLE > 0 then L.CANTIDADDISPONIBLE when L.CANTIDADVENCIDA > 0 then L.CANTIDADVENCIDA end ")
            strSQL.Append("end CANTIDAD, ")
            'strSQL.Append("end CANTIDAD, ")
            strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
            strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
            strSQL.Append("isnull(UP.IDUBICACION, 0) IDUBICACION, ")
            strSQL.Append("isnull(UP.UBICACION, '') UBICACION ")
            strSQL.Append("FROM SAB_ALM_LOTES L ")
            strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
            strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
            strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
            strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
            strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
            strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
            strSQL.Append("LEFT OUTER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP ")
            strSQL.Append("ON (L.IDALMACEN = UP.IDALMACEN ")
            strSQL.Append("AND L.IDPRODUCTO = UP.IDPRODUCTO ")
            strSQL.Append("AND L.IDLOTE = UP.IDLOTE) ")
            strSQL.Append("WHERE (CP.CORRPRODUCTO = @CORRPRODUCTO OR CP.IDPRODUCTO = @IDPRODUCTO) ")
            strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
            strSQL.Append("AND L.IDALMACEN = @IDALMACEN ")
            'strSQL.Append("AND (((@TIPOFILTRO = 1 AND L.CANTIDADDISPONIBLE > 0) OR (@TIPOFILTRO = 2 AND L.CANTIDADNODISPONIBLE > 0) OR (@TIPOFILTRO = 3 AND L.CANTIDADVENCIDA > 0) OR (@TIPOFILTRO = 4 AND L.CANTIDADRESERVADA > 0) OR (@TIPOFILTRO = 5 AND L.CANTIDADTEMPORAL > 0)) OR (@TIPOFILTRO = 0 AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0))) ")
            strSQL.Append("AND (((@TIPOFILTRO = 1 AND L.CANTIDADDISPONIBLE > 0) OR (@TIPOFILTRO = 2 AND L.CANTIDADNODISPONIBLE > 0) OR (@TIPOFILTRO = 3 AND L.CANTIDADVENCIDA > 0) OR (@TIPOFILTRO = 4 AND L.CANTIDADRESERVADA > 0) OR (@TIPOFILTRO = 5 AND L.CANTIDADTEMPORAL > 0) OR (@TIPOFILTRO = 6 AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0))) OR (@TIPOFILTRO = 0 AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0))) ")
            strSQL.Append("AND L.ESTADISPONIBLE = 1 ")
            strSQL.Append("ORDER BY L.FECHAVENCIMIENTO ")

            args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
            args(3).Value = IDALMACEN
            args(4) = New SqlParameter("@TIPOFILTRO", SqlDbType.Int)
            args(4).Value = TIPOFILTRO

            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

            Return ds

        End If

    End Function

    ''' <summary>
    ''' Lista de lotes fitrado por un identificador
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDPRODUCTO">Identificador del producto</param>
    ''' <returns>Lista de lotes en formato de lista</returns>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As listaLOTES

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN AND IDPRODUCTO = @IDPRODUCTO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaLOTES

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    Dim mEntidad As New LOTES
                    mEntidad.IDALMACEN = IDALMACEN
                    mEntidad.IDLOTE = IIf(dr("IDLOTE") Is DBNull.Value, Nothing, dr("IDLOTE"))
                    mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                    mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                    mEntidad.CODIGO = IIf(dr("CODIGO") Is DBNull.Value, Nothing, dr("CODIGO"))
                    mEntidad.PRECIOLOTE = IIf(dr("PRECIOLOTE") Is DBNull.Value, Nothing, dr("PRECIOLOTE"))
                    mEntidad.FECHAVENCIMIENTO = IIf(dr("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, dr("FECHAVENCIMIENTO"))
                    mEntidad.IDINFORMECONTROLCALIDAD = IIf(dr("IDINFORMECONTROLCALIDAD") Is DBNull.Value, Nothing, dr("IDINFORMECONTROLCALIDAD"))
                    mEntidad.NUMEROINFORMECONTROLCALIDAD = IIf(dr("NUMEROINFORMECONTROLCALIDAD") Is DBNull.Value, Nothing, dr("NUMEROINFORMECONTROLCALIDAD"))
                    mEntidad.FECHAINFORMECONTROLCALIDAD = IIf(dr("FECHAINFORMECONTROLCALIDAD") Is DBNull.Value, Nothing, dr("FECHAINFORMECONTROLCALIDAD"))
                    mEntidad.IDFUENTEFINANCIAMIENTO = IIf(dr("IDFUENTEFINANCIAMIENTO") Is DBNull.Value, Nothing, dr("IDFUENTEFINANCIAMIENTO"))
                    mEntidad.CANTIDADDISPONIBLE = IIf(dr("CANTIDADDISPONIBLE") Is DBNull.Value, Nothing, dr("CANTIDADDISPONIBLE"))
                    mEntidad.CANTIDADNODISPONIBLE = IIf(dr("CANTIDADNODISPONIBLE") Is DBNull.Value, Nothing, dr("CANTIDADNODISPONIBLE"))
                    mEntidad.CANTIDADVENCIDA = IIf(dr("CANTIDADVENCIDA") Is DBNull.Value, Nothing, dr("CANTIDADVENCIDA"))
                    mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                    mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                    mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                    mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                    mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                    lista.Add(mEntidad)
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
    ''' Metodo para seleccionar un lote específico
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDPRODUCTO">Identificador del producto</param>
    ''' <param name="IDTIPOCONSULTA">Identificador del tipo de consulta</param>
    ''' <returns>Los lotes en formato de dataset</returns>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function SeleccionarLoteDs(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int32, ByVal IDTIPOCONSULTA As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN AND IDPRODUCTO = @IDPRODUCTO ")
        Select Case IDTIPOCONSULTA
            Case Is = 1
                strSQL.Append(" AND CANTIDADDISPONIBLE > 0 ")
        End Select

        strSQL.Append(" ORDER BY FECHAVENCIMIENTO")
        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Metodo para obtener el detalle de lotes
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDLOTE">Identificador del lote</param>
    ''' <returns>Detalle de lotes en formato dataset</returns>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerDsDetalleLote(ByVal IDALMACEN As Int32, ByVal IDLOTE As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("L.IDUNIDADMEDIDA, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("L.IDINFORMECONTROLCALIDAD, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("FF.NOMBRE, ")
        strSQL.Append("RD.NOMBRE AS NOMBRERESPONSABLEDISTRIBUCION ")
        strSQL.Append("FROM SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE (L.IDALMACEN = @IDALMACEN) ")
        strSQL.Append("AND (L.IDLOTE = @IDLOTE) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDLOTE", SqlDbType.Int)
        args(1).Value = IDLOTE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener la información completa de un lote.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén al que pertenece el lote.</param>
    ''' <param name="IDLOTE">Identificador del lote seleccionado.</param>
    ''' <returns>Dataset con la información de un lote.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  08/01/2007    Creado
    ''' </history> 
    Public Function ObtenerLotePorIdloteDS(ByVal IDALMACEN As Int64, ByVal IDLOTE As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.IDUNIDADMEDIDA, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.CANTIDADDECIMAL ")
        strSQL.Append("FROM SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("WHERE L.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND L.IDLOTE = @IDLOTE ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDLOTE", SqlDbType.Int)
        args(1).Value = IDLOTE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Metodo para obtener un conjunto de lotes seleccionados
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDPRODUCTO">Identificador del producto</param>
    ''' <returns>Lotes seleccionados en formato de dataset</returns>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function SeleccionarLotes(ByVal IDALMACEN As Integer, ByVal IDPRODUCTO As Integer, ByVal CODIGO As String, ByVal ESTADISPONIBLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("L.IDUNIDADMEDIDA, ")
        strSQL.Append("L.CODIGO, ")
        strSQL.Append("isnull(L.DETALLE, '') DETALLE, ")
        strSQL.Append("case when L.CODIGO is null then case when L.DETALLE is null then '(N/A)' else L.DETALLE end else L.CODIGO + isnull(L.DETALLE, '') end CODIGODETALLE, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("L.IDESTABLECIMIENTO, ")
        strSQL.Append("L.IDINFORMECONTROLCALIDAD, ")
        strSQL.Append("L.NUMEROINFORMECONTROLCALIDAD, ")
        strSQL.Append("L.FECHAINFORMECONTROLCALIDAD, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("L.AUUSUARIOCREACION, ")
        strSQL.Append("L.AUFECHACREACION, ")
        strSQL.Append("L.AUUSUARIOMODIFICACION, ")
        strSQL.Append("L.AUFECHAMODIFICACION, ")
        strSQL.Append("L.ESTASINCRONIZADA, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.CANTIDADDECIMAL, ")
        strSQL.Append("FF.NOMBRE FUENTEFINANCIAMIENTO, ")
        strSQL.Append("RD.NOMBRECORTO RESPONSABLEDISTRIBUCION, ")
        strSQL.Append("isnull(UP.IDUBICACION, 0) IDUBICACION, ")
        strSQL.Append("isnull(UP.UBICACION, '') UBICACION ")
        strSQL.Append("FROM SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP ")
        strSQL.Append("ON (L.IDALMACEN = UP.IDALMACEN ")
        strSQL.Append("AND L.IDPRODUCTO = UP.IDPRODUCTO ")
        strSQL.Append("AND L.IDLOTE = UP.IDLOTE) ")
        strSQL.Append("WHERE L.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND (L.IDPRODUCTO = @IDPRODUCTO OR CP.CORRPRODUCTO = @CODIGO) ")
        strSQL.Append("AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0) ")
        strSQL.Append("AND L.ESTADISPONIBLE = @ESTADISPONIBLE ")
        strSQL.Append("ORDER BY L.FECHAVENCIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(2).Value = CODIGO
        args(3) = New SqlParameter("@ESTADISPONIBLE", SqlDbType.Int)
        args(3).Value = ESTADISPONIBLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve el código y descripción de cada producto con existencia disponible en el almacén indicado.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificdor del almacén.</param>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_ALM_LOTES</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function RecuperarProductosAlmacen(ByVal IDALMACEN As Integer, ByVal ESTADISPONIBLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO + ' - ' + CP.DESCLARGO PRODUCTO ")
        strSQL.Append("FROM SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE L.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0) ")
        strSQL.Append("AND (L.ESTADISPONIBLE = @ESTADISPONIBLE OR @ESTADISPONIBLE is null) ")
        strSQL.Append("ORDER BY PRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ESTADISPONIBLE", SqlDbType.Int)
        args(1).Value = IIf(IsNothing(ESTADISPONIBLE), DBNull.Value, ESTADISPONIBLE)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el reporte de Próximos a vencerse.
    ''' </summary>
    ''' <param name="FECHAHASTA">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDESTABLECIMIENTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDZONA">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDGRUPO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDPRODUCTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <returns>Dataset con la información del reporte.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ZONAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]  10/02/2007    Creado
    ''' </history> 
    Public Function RptProximosAVencer(ByVal FECHAHASTA As DateTime, ByVal IDESTABLECIMIENTO As Integer, ByVal IDZONA As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDSUBGRUPO As Integer, ByVal IDPRODUCTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("E.IDZONA, ")
        strSQL.Append("Z.DESCRIPCION AS ZONA, ")
        strSQL.Append("AE.IDESTABLECIMIENTO, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTO, ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE ALMACEN, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO CODIGOPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') LOTE, ")
        strSQL.Append("L.PRECIOLOTE PRECIOUNITARIO, ")
        strSQL.Append("convert(varchar, L.FECHAVENCIMIENTO, 103) FECHAVENCIMIENTO ")
        strSQL.Append("from SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append("ON L.IDALMACEN = AE.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON AE.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ZONAS Z ")
        strSQL.Append("ON Z.IDZONA = E.IDZONA ")
        strSQL.Append("WHERE ")
        strSQL.Append("L.FECHAVENCIMIENTO between getdate() and @FECHAHASTA ")
        strSQL.Append("AND ")
        strSQL.Append("( ")
        strSQL.Append(" (AE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO OR @IDESTABLECIMIENTO = 0) ")
        strSQL.Append(" AND ")
        strSQL.Append(" ((E.IDZONA = @IDZONA ) OR @IDZONA = 0) ")
        strSQL.Append(") ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        strSQL.Append("AND (CP.IDSUBGRUPO = @IDSUBGRUPO OR @IDSUBGRUPO = 0) ")
        strSQL.Append("AND (L.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(0).Value = FECHAHASTA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(2).Value = IDZONA
        args(3) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(3).Value = IDSUMINISTRO
        args(4) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(4).Value = IDGRUPO
        args(5) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        args(5).Value = IDSUBGRUPO
        args(6) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(6).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Consulta para el reporte de proximos a vencer
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del Almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="IDGRUPO">Identificador del grupo</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribucion</param>
    ''' <param name="FECHAHASTA">Identificador de la fecha limite</param>
    ''' <param name="IDGRUPOFUENTEFINANCIAMIENTO">Identificador del grupo de la fuente</param>
    ''' <returns>Listado de proximos a vencer en formato dataset</returns>

    Public Function RptProximosAVencerAlmacen(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal FECHAHASTA As DateTime, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, Optional IDPROGRAMA As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRE NOMBRERESPONSABLE, ")
        strSQL.Append("RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("(L.CANTIDADDISPONIBLE * L.PRECIOLOTE) MONTODISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("(L.CANTIDADNODISPONIBLE * L.PRECIOLOTE) MONTONODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("(L.CANTIDADVENCIDA * L.PRECIOLOTE) MONTOVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("(L.CANTIDADRESERVADA * L.PRECIOLOTE) MONTORESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("(L.CANTIDADTEMPORAL * L.PRECIOLOTE) MONTOTEMPORAL, ")
        strSQL.Append("L.ESTADISPONIBLE, ")
        strSQL.Append(" ISNULL(UP.UBICACION,'') UBICACION ")

        strSQL.Append("FROM SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")

        If IDPROGRAMA <> 0 Then
            strSQL.Append("INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PP ")
            strSQL.Append("ON PP.IDPRODUCTO = CP.IDPRODUCTO AND ")
            strSQL.Append(" PP.IDPROGRAMA = @IDPROGRAMA ")
        End If

        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP ")
        strSQL.Append("ON L.IDALMACEN = UP.IDALMACEN ")
        strSQL.Append("AND L.IDLOTE = UP.IDLOTE ")

        strSQL.Append("WHERE (L.IDALMACEN = @IDALMACEN or @IDALMACEN=0) ")
        strSQL.Append("AND CP.IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        strSQL.Append("AND L.CANTIDADDISPONIBLE > 0 ")
        strSQL.Append("AND L.ESTADISPONIBLE = 1 ")
        strSQL.Append("AND L.FECHAVENCIMIENTO is not null ")
        strSQL.Append("AND L.FECHAVENCIMIENTO between getdate() and @FECHAHASTA ")
        strSQL.Append("ORDER BY L.FECHAVENCIMIENTO, CP.CORRPRODUCTO, L.CANTIDADDISPONIBLE ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(2).Value = IDGRUPO
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Value = IDFUENTEFINANCIAMIENTO
        args(4) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(4).Value = IDRESPONSABLEDISTRIBUCION
        args(5) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(5).Value = FECHAHASTA
        args(6) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(6).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(7) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(7).Value = IDPROGRAMA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Reporte de vencidos
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="IDGRUPO">Identificador del grupo</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribucion</param>
    ''' <param name="IDGRUPOFUENTEFINANCIAMIENTO">Identificador del grupo de la fuente de financiamiento</param>
    ''' <returns>Listado de productos vencidos en formato dataset</returns>

    Public Function RptVencidosAlmacen(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRE NOMBRERESPONSABLE, ")
        strSQL.Append("RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("(L.CANTIDADDISPONIBLE * L.PRECIOLOTE) MONTODISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("(L.CANTIDADNODISPONIBLE * L.PRECIOLOTE) MONTONODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("(L.CANTIDADVENCIDA * L.PRECIOLOTE) MONTOVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("(L.CANTIDADRESERVADA * L.PRECIOLOTE) MONTORESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("(L.CANTIDADTEMPORAL * L.PRECIOLOTE) MONTOTEMPORAL, ")
        strSQL.Append("L.ESTADISPONIBLE, ")
        'AGREGAR PARA REPORTE 170709
        strSQL.Append(" ISNULL(UP.UBICACION,'') UBICACION ")
        strSQL.Append("FROM SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        'agregar ubicacion al reporte 170709 Y REPORTE UACI 170809
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP ")
        strSQL.Append("ON L.IDALMACEN = UP.IDALMACEN ")
        strSQL.Append("AND L.IDLOTE = UP.IDLOTE ")

        strSQL.Append("WHERE (L.IDALMACEN = @IDALMACEN OR @IDALMACEN=0) ")
        strSQL.Append("AND CP.IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        strSQL.Append("AND L.FECHAVENCIMIENTO is not null ")
        strSQL.Append("AND L.CANTIDADVENCIDA > 0 ")
        strSQL.Append("AND L.ESTADISPONIBLE = 1 ")
        strSQL.Append("ORDER BY L.FECHAVENCIMIENTO DESC, CP.CORRPRODUCTO, L.CANTIDADDISPONIBLE DESC ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(2).Value = IDGRUPO
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Value = IDFUENTEFINANCIAMIENTO
        args(4) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(4).Value = IDRESPONSABLEDISTRIBUCION
        args(5) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(5).Value = IDGRUPOFUENTEFINANCIAMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Reporte de productos agotados por almacen
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="IDGRUPO">Identificador del grupo</param>
    ''' <returns>Lista de agotados en formato de dataset</returns>

    Public Function RptAgotadosAlmacen(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        'strSQL.Append("--L.IDLOTE, ")
        'strSQL.Append("--isnull(L.CODIGO, '(N/A)') CODIGO, ")
        'strSQL.Append("--L.PRECIOLOTE, ")
        'strSQL.Append("--L.FECHAVENCIMIENTO, ")
        'strSQL.Append("--isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        'strSQL.Append("--L.IDRESPONSABLEDISTRIBUCION, ")
        'strSQL.Append("--RD.NOMBRE NOMBRERESPONSABLE, ")
        'strSQL.Append("--RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        'strSQL.Append("--L.IDFUENTEFINANCIAMIENTO, ")
        'strSQL.Append("--FF.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("sum(L.CANTIDADDISPONIBLE), sum(L.CANTIDADDISPONIBLE * L.PRECIOLOTE) MONTODISPONIBLE, sum(L.CANTIDADNODISPONIBLE), sum(L.CANTIDADNODISPONIBLE * L.PRECIOLOTE) MONTONODISPONIBLE, sum(L.CANTIDADVENCIDA), sum(L.CANTIDADVENCIDA * L.PRECIOLOTE) MONTOVENCIDA, sum(L.CANTIDADRESERVADA), sum(L.CANTIDADRESERVADA * L.PRECIOLOTE) MONTORESERVADA, sum(L.CANTIDADTEMPORAL) ")
        strSQL.Append("FROM SAB_ALM_LOTES L  ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP  ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO  ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A  ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        strSQL.Append(" ")
        strSQL.Append("WHERE L.IDALMACEN = @IDALMACEN AND  ")
        strSQL.Append("CP.IDSUMINISTRO = @IDSUMINISTRO AND  ")
        strSQL.Append("(CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) AND  ")
        strSQL.Append("L.FECHAVENCIMIENTO is not null AND  ")
        strSQL.Append("L.ESTADISPONIBLE = 1  ")
        strSQL.Append(" ")
        strSQL.Append("group by ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        'strSQL.Append("--L.IDLOTE, ")
        'strSQL.Append("--L.CODIGO, ")
        'strSQL.Append("--L.PRECIOLOTE, ")
        'strSQL.Append("--L.FECHAVENCIMIENTO, ")
        'strSQL.Append("--L.IDRESPONSABLEDISTRIBUCION, ")
        'strSQL.Append("--RD.NOMBRE, ")
        'strSQL.Append("--RD.NOMBRECORTO, ")
        'strSQL.Append("--L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("CP.CORRPRODUCTO ")
        strSQL.Append("having sum(L.CANTIDADDISPONIBLE) = 0 and sum(L.CANTIDADRESERVADA) = 0 and sum(l.cantidadvencida)=0 and sum(l.cantidadreservada)=0 ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(2).Value = IDGRUPO
        'args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        'args(3).Value = IDFUENTEFINANCIAMIENTO
        'args(4) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        'args(4).Value = IDRESPONSABLEDISTRIBUCION
        'args(5) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        'args(5).Value = IDGRUPOFUENTEFINANCIAMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function RptAgotadosAlmacen2(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        'strSQL.Append("--L.IDLOTE, ")
        'strSQL.Append("--isnull(L.CODIGO, '(N/A)') CODIGO, ")
        'strSQL.Append("--L.PRECIOLOTE, ")
        'strSQL.Append("--L.FECHAVENCIMIENTO, ")
        'strSQL.Append("--isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        'strSQL.Append("--L.IDRESPONSABLEDISTRIBUCION, ")
        'strSQL.Append("--RD.NOMBRE NOMBRERESPONSABLE, ")
        'strSQL.Append("--RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        'strSQL.Append("--L.IDFUENTEFINANCIAMIENTO, ")
        'strSQL.Append("--FF.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("sum(L.CANTIDADDISPONIBLE), sum(L.CANTIDADDISPONIBLE * L.PRECIOLOTE) MONTODISPONIBLE, sum(L.CANTIDADNODISPONIBLE), sum(L.CANTIDADNODISPONIBLE * L.PRECIOLOTE) MONTONODISPONIBLE, sum(L.CANTIDADVENCIDA), sum(L.CANTIDADVENCIDA * L.PRECIOLOTE) MONTOVENCIDA, sum(L.CANTIDADRESERVADA), sum(L.CANTIDADRESERVADA * L.PRECIOLOTE) MONTORESERVADA, sum(L.CANTIDADTEMPORAL) ")

        strSQL.Append("FROM SAB_ALM_LOTES L  ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP  ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO  ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A  ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")

        strSQL.Append("INNER JOIN SAB_ALM_PRODUCTOSALMACEN PA ")
        strSQL.Append("ON PA.IDHOSPITAL = A.IDALMACEN ")
        strSQL.Append("AND PA.IDSUMINISTRO = CP.IDSUMINISTRO ")
        strSQL.Append("AND PA.IDPRODUCTO = L.IDPRODUCTO ")
        strSQL.Append(" ")
        strSQL.Append("WHERE L.IDALMACEN = @IDALMACEN AND  ")
        strSQL.Append("CP.IDSUMINISTRO = @IDSUMINISTRO AND  ")
        strSQL.Append("(CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) AND  ")
        strSQL.Append("L.FECHAVENCIMIENTO is not null AND  ")
        strSQL.Append("L.ESTADISPONIBLE = 1 and pa.habilitado = 1 ")
        strSQL.Append(" ")
        strSQL.Append("group by ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        'strSQL.Append("--L.IDLOTE, ")
        'strSQL.Append("--L.CODIGO, ")
        'strSQL.Append("--L.PRECIOLOTE, ")
        'strSQL.Append("--L.FECHAVENCIMIENTO, ")
        'strSQL.Append("--L.IDRESPONSABLEDISTRIBUCION, ")
        'strSQL.Append("--RD.NOMBRE, ")
        'strSQL.Append("--RD.NOMBRECORTO, ")
        'strSQL.Append("--L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("CP.CORRPRODUCTO ")
        strSQL.Append("having sum(L.CANTIDADDISPONIBLE) = 0 ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(2).Value = IDGRUPO
        'args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        'args(3).Value = IDFUENTEFINANCIAMIENTO
        'args(4) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        'args(4).Value = IDRESPONSABLEDISTRIBUCION
        'args(5) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        'args(5).Value = IDGRUPOFUENTEFINANCIAMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Devuelve la información de las existencias a la fecha de un almacén especifico.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén(Filtro).</param>
    ''' <param name="IDPRODUCTO">Identificador del producto(Filtro).</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento(Filtro).</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribución(Filtro).</param>
    ''' <returns>Dataset con la información de las existencias a la fecha.</returns>
    ''' <remarks>Lista de tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_FUENTESFINANCIAMIENTO</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  10/02/2007    Creado
    ''' </history> 
    Public Function ExistenciaPorProductosActual(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Integer, ByVal CODIGO As String, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("isnull(L.CODIGO + isnull(L.DETALLE, ''), '(N/A)') CODIGO, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRE NOMBRERESPONSABLE, ")
        strSQL.Append("RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("(L.CANTIDADDISPONIBLE * L.PRECIOLOTE) MONTODISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("(L.CANTIDADNODISPONIBLE * L.PRECIOLOTE) MONTONODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("(L.CANTIDADVENCIDA * L.PRECIOLOTE) MONTOVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("(L.CANTIDADRESERVADA * L.PRECIOLOTE) MONTORESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("(L.CANTIDADTEMPORAL * L.PRECIOLOTE) MONTOTEMPORAL, ")
        strSQL.Append("L.ESTADISPONIBLE, ")
        strSQL.Append("isnull(UP.UBICACION, '') UBICACION ")
        strSQL.Append("FROM SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP ")
        strSQL.Append("ON L.IDALMACEN = UP.IDALMACEN ")
        strSQL.Append("AND L.IDLOTE = UP.IDLOTE ")
        strSQL.Append("WHERE (L.IDALMACEN = @IDALMACEN OR @IDALMACEN=0) ")
        strSQL.Append("AND (L.IDPRODUCTO = @IDPRODUCTO OR CP.CORRPRODUCTO = @CODIGO) ")
        strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        strSQL.Append("AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0) ")
        strSQL.Append("AND (L.ESTADISPONIBLE = 1) ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO, L.FECHAVENCIMIENTO, L.CANTIDADDISPONIBLE, L.CANTIDADVENCIDA, L.CANTIDADNODISPONIBLE ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(2).Value = CODIGO
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Value = IDFUENTEFINANCIAMIENTO
        args(4) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(4).Value = IDRESPONSABLEDISTRIBUCION
        args(5) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(5).Value = IDGRUPOFUENTEFINANCIAMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el reporte de Existencias.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDZONA">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDGRUPO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <param name="IDPRODUCTO">Especifica el campo a utilizar para filtrar la información</param>
    ''' <returns>Dataset con la información del reporte.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ZONAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]  10/02/2007    Creado
    ''' </history> 
    Public Function RptExistencias(ByVal IDESTABLECIMIENTO As Integer, ByVal IDZONA As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDSUBGRUPO As Integer, ByVal IDPRODUCTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("E.IDZONA, ")
        strSQL.Append("Z.DESCRIPCION ZONA, ")
        strSQL.Append("AE.IDESTABLECIMIENTO, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTO, ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE ALMACEN, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.PRECIOLOTE PRECIOUNITARIO, ")
        strSQL.Append("F.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("R.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION R ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = R.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS F ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = F.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append("ON L.IDALMACEN = AE.IDALMACEN ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON AE.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ZONAS Z ")
        strSQL.Append("ON Z.IDZONA = E.IDZONA ")
        strSQL.Append("WHERE ")
        strSQL.Append("L.CANTIDADDISPONIBLE > 0 ")
        strSQL.Append("AND ((AE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO OR @IDESTABLECIMIENTO = 0) AND ((E.IDZONA = @IDZONA ) OR @IDZONA = 0)) ")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        strSQL.Append("AND (CP.IDSUBGRUPO = @IDSUBGRUPO OR @IDSUBGRUPO = 0) ")
        strSQL.Append("AND (L.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(1).Value = IDZONA
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(2).Value = IDSUMINISTRO
        args(3) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(3).Value = IDGRUPO
        args(4) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        args(4).Value = IDSUBGRUPO
        args(5) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(5).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información de las existencias a la fecha de un almacén especifico.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén(Filtro).</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro(Filtro).</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento(Filtro).</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribución(Filtro).</param>
    ''' <returns>Dataset con la información de las existencias a la fecha.</returns>
    ''' <remarks>Lista de tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_FUENTESFINANCIAMIENTO</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  10/02/2007    Creado
    ''' </history> 
    Public Function ExistenciaPorTipoProductosActual(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int64, ByVal IDGRUPO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Integer, ByVal IDESPECIFICOGASTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("isnull(L.CODIGO + isnull(L.DETALLE, ''), '(N/A)') CODIGO, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRE NOMBRERESPONSABLE, ")
        strSQL.Append("RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("FF.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("(L.CANTIDADDISPONIBLE * L.PRECIOLOTE) MONTODISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("(L.CANTIDADNODISPONIBLE * L.PRECIOLOTE) MONTONODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("(L.CANTIDADVENCIDA * L.PRECIOLOTE) MONTOVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("(L.CANTIDADRESERVADA * L.PRECIOLOTE) MONTORESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("(L.CANTIDADTEMPORAL * L.PRECIOLOTE) MONTOTEMPORAL, ")
        strSQL.Append("L.ESTADISPONIBLE, ")
        strSQL.Append("isnull(UP.UBICACION, '') UBICACION ")
        strSQL.Append("FROM SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP ")
        strSQL.Append("ON L.IDALMACEN = UP.IDALMACEN ")
        strSQL.Append("AND L.IDLOTE = UP.IDLOTE ")
        strSQL.Append("WHERE (L.IDALMACEN = @IDALMACEN OR @IDALMACEN = 0)")
        strSQL.Append("AND (CP.IDSUMINISTRO = @IDSUMINISTRO OR @IDSUMINISTRO = 0) ")
        strSQL.Append("AND (CP.IDESPECIFICOGASTO = @IDESPECIFICOGASTO OR @IDESPECIFICOGASTO = 0) ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO  OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
        strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        strSQL.Append("AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0) ")
        strSQL.Append("AND L.ESTADISPONIBLE = 1 ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO, L.FECHAVENCIMIENTO, L.CANTIDADDISPONIBLE, L.CANTIDADVENCIDA, L.CANTIDADNODISPONIBLE ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(2).Value = IDGRUPO
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Value = IDFUENTEFINANCIAMIENTO
        args(4) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(4).Value = IDRESPONSABLEDISTRIBUCION
        args(5) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(5).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(6) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(6).Value = IDESPECIFICOGASTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Consulta de existencias de almacenes de hospitales
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="IDGRUPO">Identificador del grupo</param>
    ''' <returns>Listado de existencias de almacenes de hospitales en formato dataset</returns>

    Public Function ExistenciaAlmacenHospital(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int64, ByVal IDGRUPO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT  ")
        strSQL.Append("		ROW_NUMBER() OVER(ORDER BY CP.IDGRUPO ASC, CP.IDSUBGRUPO ASC) AS 'SEC', ")
        strSQL.Append("        L.IDALMACEN,  ")
        strSQL.Append("        A.NOMBRE NOMBREALMACEN,  ")
        strSQL.Append("        A.DIRECCION,  ")
        strSQL.Append("        A.ESFARMACIA,  ")
        strSQL.Append("        L.IDPRODUCTO,  ")
        strSQL.Append("        CP.CORRPRODUCTO,  ")
        strSQL.Append("        CP.DESCLARGO,  ")
        strSQL.Append("        CP.IDUNIDADMEDIDA,  ")
        strSQL.Append("        CP.DESCRIPCION UNIDADMEDIDA,  ")
        strSQL.Append("        CP.IDSUMINISTRO,  ")
        strSQL.Append("        CP.CORRSUMINISTRO,  ")
        strSQL.Append("        CP.DESCSUMINISTRO,  ")
        strSQL.Append("        CP.IDGRUPO,  ")
        strSQL.Append("        CP.CORRGRUPO,  ")
        strSQL.Append("        CP.DESCGRUPO,  ")
        strSQL.Append("        CP.IDSUBGRUPO,  ")
        strSQL.Append("        CP.CORRSUBGRUPO,  ")
        strSQL.Append("        CP.DESCSUBGRUPO, ISNULL(UP.UBICACION,'') AS UBICACION ")
        strSQL.Append("        FROM SAB_ALM_LOTES L  ")
        strSQL.Append("        INNER JOIN vv_CATALOGOPRODUCTOS CP  ")
        strSQL.Append("        ON L.IDPRODUCTO = CP.IDPRODUCTO  ")
        strSQL.Append("        INNER JOIN SAB_CAT_ALMACENES A  ")
        strSQL.Append("        ON L.IDALMACEN = A.IDALMACEN  ")
        strSQL.Append("        LEFT OUTER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP  ")
        strSQL.Append("        ON L.IDALMACEN = UP.IDALMACEN AND ")
        strSQL.Append("        L.IDPRODUCTO = UP.IDPRODUCTO AND  ")
        strSQL.Append("        L.IDLOTE = UP.IDLOTE  ")
        strSQL.Append("        WHERE (L.IDALMACEN = @IDALMACEN OR @IDALMACEN=0) ")
        strSQL.Append("        AND CP.IDSUMINISTRO = 1  ")
        strSQL.Append("        AND (CP.IDGRUPO = 0 OR 0 = 0)  ")
        strSQL.Append("        AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0) ")
        strSQL.Append("        AND L.ESTADISPONIBLE = 1  ")
        strSQL.Append("		GROUP BY  L.IDALMACEN,A.NOMBRE,  ")
        strSQL.Append("A.NOMBRE,A.DIRECCION,A.ESFARMACIA,L.IDPRODUCTO,CP.CORRPRODUCTO,CP.DESCLARGO,CP.IDUNIDADMEDIDA,CP.DESCRIPCION,  ")
        strSQL.Append("UNIDADMEDIDA,CP.IDSUMINISTRO,CP.CORRSUMINISTRO,CP.DESCSUMINISTRO,CP.IDGRUPO,CP.CORRGRUPO,CP.DESCGRUPO,CP.IDSUBGRUPO,CP.CORRSUBGRUPO,CP.DESCSUBGRUPO,UP.UBICACION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(2).Value = IDGRUPO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    'Public Function ExistenciaPorTipoProductosActual(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int64, ByVal IDGRUPO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32) As DataSet

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("SELECT ")
    '    strSQL.Append("G.IDSUMINISTRO, ")
    '    strSQL.Append("S.CORRELATIVO CORRSUMINISTRO, ")
    '    strSQL.Append("S.DESCRIPCION DESCSUMINISTRO, ")
    '    strSQL.Append("G.IDGRUPO, ")
    '    strSQL.Append("G.CORRELATIVO CORRGRUPO, ")
    '    strSQL.Append("G.DESCRIPCION DESCGRUPO ")
    '    strSQL.Append("FROM SAB_CAT_GRUPOS G ")
    '    strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
    '    strSQL.Append("ON G.IDSUMINISTRO = S.IDSUMINISTRO ")
    '    strSQL.Append("WHERE G.IDSUMINISTRO = @IDSUMINISTRO ")
    '    strSQL.Append("AND (G.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")

    '    strSQL.Append("SELECT ")
    '    strSQL.Append("CP.IDSUMINISTRO, ")
    '    strSQL.Append("CP.IDGRUPO, ")
    '    strSQL.Append("CP.CORRPRODUCTO, ")
    '    strSQL.Append("CP.DESCLARGO, ")
    '    strSQL.Append("CP.IDUNIDADMEDIDA, ")
    '    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA ")
    '    strSQL.Append("FROM SAB_ALM_LOTES L ")
    '    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
    '    strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
    '    strSQL.Append("WHERE L.IDALMACEN = @IDALMACEN ")
    '    strSQL.Append("AND CP.IDSUMINISTRO = @IDSUMINISTRO ")
    '    strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
    '    strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
    '    strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
    '    strSQL.Append("AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0) ")
    '    strSQL.Append("AND L.ESTADISPONIBLE = 1 ")
    '    strSQL.Append("GROUP BY ")
    '    strSQL.Append("CP.IDSUMINISTRO, ")
    '    strSQL.Append("CP.IDGRUPO, ")
    '    strSQL.Append("CP.CORRPRODUCTO, ")
    '    strSQL.Append("CP.DESCLARGO, ")
    '    strSQL.Append("CP.IDUNIDADMEDIDA, ")
    '    strSQL.Append("CP.DESCRIPCION ")

    '    strSQL.Append("SELECT ")
    '    strSQL.Append("A.IDALMACEN, ")
    '    strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
    '    strSQL.Append("A.DIRECCION, ")
    '    strSQL.Append("A.ESFARMACIA ")
    '    strSQL.Append("FROM SAB_CAT_ALMACENES A ")
    '    strSQL.Append("WHERE A.IDALMACEN = @IDALMACEN ")

    '    strSQL.Append("SELECT ")
    '    strSQL.Append("L.IDPRODUCTO, ")
    '    strSQL.Append("L.IDLOTE, ")
    '    strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
    '    strSQL.Append("L.PRECIOLOTE, ")
    '    strSQL.Append("L.FECHAVENCIMIENTO, ")
    '    strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
    '    strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
    '    strSQL.Append("RD.NOMBRE NOMBRERESPONSABLE, ")
    '    strSQL.Append("RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
    '    strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
    '    strSQL.Append("FF.NOMBRE NOMBREFUENTE, ")
    '    strSQL.Append("L.CANTIDADDISPONIBLE, ")
    '    strSQL.Append("(L.CANTIDADDISPONIBLE * L.PRECIOLOTE) MONTODISPONIBLE, ")
    '    strSQL.Append("L.CANTIDADNODISPONIBLE, ")
    '    strSQL.Append("(L.CANTIDADNODISPONIBLE * L.PRECIOLOTE) MONTONODISPONIBLE, ")
    '    strSQL.Append("L.CANTIDADVENCIDA, ")
    '    strSQL.Append("(L.CANTIDADVENCIDA * L.PRECIOLOTE) MONTOVENCIDA, ")
    '    strSQL.Append("L.CANTIDADRESERVADA, ")
    '    strSQL.Append("(L.CANTIDADRESERVADA * L.PRECIOLOTE) MONTORESERVADA, ")
    '    strSQL.Append("L.CANTIDADTEMPORAL, ")
    '    strSQL.Append("(L.CANTIDADTEMPORAL * L.PRECIOLOTE) MONTOTEMPORAL, ")
    '    strSQL.Append("L.ESTADISPONIBLE ")
    '    strSQL.Append("FROM SAB_ALM_LOTES L ")
    '    strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
    '    strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
    '    strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
    '    strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
    '    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
    '    strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
    '    strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
    '    strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
    '    strSQL.Append("WHERE L.IDALMACEN = @IDALMACEN ")
    '    strSQL.Append("AND CP.IDSUMINISTRO = @IDSUMINISTRO ")
    '    strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
    '    strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
    '    strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
    '    strSQL.Append("AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0) ")
    '    strSQL.Append("AND L.ESTADISPONIBLE = 1 ")
    '    strSQL.Append("ORDER BY CP.CORRPRODUCTO, L.FECHAVENCIMIENTO, L.CANTIDADDISPONIBLE, L.CANTIDADVENCIDA, L.CANTIDADNODISPONIBLE ")

    '    Dim args(4) As SqlParameter
    '    args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
    '    args(0).Value = IDALMACEN
    '    args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
    '    args(1).Value = IDSUMINISTRO
    '    args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
    '    args(2).Value = IDGRUPO
    '    args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
    '    args(3).Value = IDFUENTEFINANCIAMIENTO
    '    args(4) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
    '    args(4).Value = IDRESPONSABLEDISTRIBUCION

    '    Dim tables(3) As String
    '    tables(0) = New String("dtSuministro")
    '    tables(1) = New String("dtProducto")
    '    tables(2) = New String("dtAlmacen")
    '    tables(3) = New String("ExistenciasAlmacenes")

    '    Dim ds As New DataSet
    '    SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

    '    'por error en el método FillDataset
    '    ds.Tables(0).TableName = tables(0)
    '    ds.Tables(1).TableName = tables(1)
    '    ds.Tables(2).TableName = tables(2)
    '    ds.Tables(3).TableName = tables(3)

    '    Return ds

    'End Function
    ''' <summary>
    ''' Consulta de existencias historicas por tipo de producto
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="IDGRUPO">Identificador del grupo</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION">Identificador del responsable de distribucion</param>
    ''' <param name="FECHAHASTA">identificador de la fecha limite</param>
    ''' <param name="IDGRUPOFUENTEFINANCIAMIENTO">Identificador del grupo de la fuente de financiamiento</param>
    ''' <param name="fos">Identificador de variable fosalud</param>
    ''' <returns>Listado en formato dataset</returns>
    Public Function ExistenciaHistoricaPorTipoProducto(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int64, ByVal IDGRUPO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByVal FECHAHASTA As Date, ByVal IDGRUPOFUENTEFINANCIAMIENTO As Int32, ByVal fos As Integer, ByVal IDESPECIFICOGASTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_ExistenciaFechaDada")

        'strSQL.Append("with t as (")
        'strSQL.Append("SELECT ")
        'strSQL.Append("L.IDALMACEN, ")
        'strSQL.Append("L.IDLOTE, ")
        'strSQL.Append("sum(CASE WHEN L.FECHAVENCIMIENTO IS NOT NULL AND L.FECHAVENCIMIENTO < @FECHAHASTA THEN 0 ELSE DM.CANTIDAD * TT.AFECTAINVENTARIO END) CANTIDADDISPONIBLE, ")
        'strSQL.Append("sum(CASE WHEN L.FECHAVENCIMIENTO IS NOT NULL AND L.FECHAVENCIMIENTO < @FECHAHASTA THEN 0 ELSE DM.CANTIDAD * TT.AFECTAINVENTARIO * L.PRECIOLOTE END) MONTODISPONIBLE, ")
        'strSQL.Append("SUM(CASE WHEN L.FECHAVENCIMIENTO IS NOT NULL AND L.FECHAVENCIMIENTO < @FECHAHASTA THEN DM.CANTIDAD * TT.AFECTAINVENTARIO ELSE 0 END) CANTIDADVENCIDA, ")
        'strSQL.Append("SUM(CASE WHEN L.FECHAVENCIMIENTO IS NOT NULL AND L.FECHAVENCIMIENTO < @FECHAHASTA THEN DM.CANTIDAD * TT.AFECTAINVENTARIO * L.PRECIOLOTE ELSE 0 END) MONTOVENCIDA, ")
        'strSQL.Append("SUM(CASE WHEN TT.IDTIPOTRANSACCION = 6 THEN DM.CANTIDAD ELSE 0 END) CANTIDADNODISPONIBLE, ")
        'strSQL.Append("SUM(CASE WHEN TT.IDTIPOTRANSACCION = 6 THEN DM.CANTIDAD * L.PRECIOLOTE ELSE 0 END) MONTONODISPONIBLE ")
        'strSQL.Append("FROM SAB_ALM_MOVIMIENTOS M ")
        'strSQL.Append("INNER JOIN SAB_CAT_TIPOTRANSACCIONES TT ")
        'strSQL.Append("ON M.IDTIPOTRANSACCION = TT.IDTIPOTRANSACCION ")
        'strSQL.Append("INNER JOIN SAB_ALM_DETALLEMOVIMIENTOS DM ")
        'strSQL.Append("ON (M.IDESTABLECIMIENTO = DM.IDESTABLECIMIENTO ")
        'strSQL.Append("AND M.IDTIPOTRANSACCION = DM.IDTIPOTRANSACCION ")
        'strSQL.Append("AND M.IDMOVIMIENTO = DM.IDMOVIMIENTO) ")
        'strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        'strSQL.Append("ON (DM.IDALMACEN = L.IDALMACEN ")
        'strSQL.Append("AND DM.IDLOTE = L.IDLOTE) ")
        'strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        'strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        'strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        'strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        'strSQL.Append("WHERE L.IDALMACEN = @IDALMACEN ")
        'strSQL.Append("AND CP.IDSUMINISTRO = @IDSUMINISTRO ")
        'strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        'strSQL.Append("AND M.IDESTADO = 2 ")
        'strSQL.Append("AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
        'strSQL.Append("AND (FF.IDGRUPO = @IDGRUPOFUENTEFINANCIAMIENTO OR @IDGRUPOFUENTEFINANCIAMIENTO = 0) ")
        'strSQL.Append("AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        'strSQL.Append("AND (TT.AFECTAINVENTARIO <> 0 OR TT.IDTIPOTRANSACCION = 6) ")
        'strSQL.Append("AND M.FECHAMOVIMIENTO <= @FECHAHASTA ")
        'strSQL.Append("GROUP BY ")
        'strSQL.Append("L.IDALMACEN, ")
        'strSQL.Append("L.IDLOTE ")
        ''strSQL.Append("-- ORDER BY ")
        ''strSQL.Append("-- L.IDALMACEN, ")
        ''strSQL.Append("-- L.IDLOTE ")
        'strSQL.Append(") ")
        'strSQL.Append("")
        'strSQL.Append("SELECT ")
        'strSQL.Append("L.IDALMACEN, ")
        'strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        'strSQL.Append("A.DIRECCION, ")
        'strSQL.Append("A.ESFARMACIA, ")
        'strSQL.Append("L.IDPRODUCTO, ")
        'strSQL.Append("CP.CORRPRODUCTO, ")
        'strSQL.Append("CP.DESCLARGO, ")
        'strSQL.Append("CP.IDUNIDADMEDIDA, ")
        'strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        'strSQL.Append("CP.IDSUMINISTRO, ")
        'strSQL.Append("CP.CORRSUMINISTRO, ")
        'strSQL.Append("CP.DESCSUMINISTRO, ")
        'strSQL.Append("CP.IDGRUPO, ")
        'strSQL.Append("CP.CORRGRUPO, ")
        'strSQL.Append("CP.DESCGRUPO, ")
        'strSQL.Append("CP.IDSUBGRUPO, ")
        'strSQL.Append("CP.CORRSUBGRUPO, ")
        'strSQL.Append("CP.DESCSUBGRUPO, ")
        'strSQL.Append("L.IDLOTE, ")
        'strSQL.Append("isnull(L.CODIGO + isnull(L.DETALLE, ''), '(N/A)') CODIGO, ")
        'strSQL.Append("L.PRECIOLOTE, ")
        'strSQL.Append("L.FECHAVENCIMIENTO, ")
        'strSQL.Append("isnull(convert(varchar, datepart(month, L.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, L.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTOMMAAAA, ")
        'strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        'strSQL.Append("RD.NOMBRE NOMBRERESPONSABLE, ")
        'strSQL.Append("RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        'strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        'strSQL.Append("FF.NOMBRE NOMBREFUENTE, ")
        'strSQL.Append("t.CANTIDADDISPONIBLE, ")
        'strSQL.Append("t.MONTODISPONIBLE, ")
        'strSQL.Append("T.CANTIDADNODISPONIBLE, ")
        'strSQL.Append("T.MONTONODISPONIBLE,  ")
        'strSQL.Append("T.CANTIDADVENCIDA,  ")
        'strSQL.Append("T.MONTOVENCIDA,  ")
        'strSQL.Append("0 CANTIDADRESERVADA, ")
        'strSQL.Append("0 MONTORESERVADA, ")
        'strSQL.Append("0 CANTIDADTEMPORAL, ")
        'strSQL.Append("0 MONTOTEMPORAL, ")
        'strSQL.Append("1 ESTADISPONIBLE, ")
        'strSQL.Append("isnull(UP.UBICACION, '') UBICACION ")
        'strSQL.Append("FROM t ")
        'strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        'strSQL.Append("ON t.IDALMACEN = L.IDALMACEN ")
        'strSQL.Append("AND t.IDLOTE = L.IDLOTE ")
        'strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        'strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        'strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        'strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = FF.IDFUENTEFINANCIAMIENTO ")
        'strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        'strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        'strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        'strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        'strSQL.Append("LEFT OUTER JOIN SAB_ALM_UBICACIONESPRODUCTOS UP ")
        'strSQL.Append("ON L.IDALMACEN = UP.IDALMACEN ")
        'strSQL.Append("AND L.IDLOTE = UP.IDLOTE ")
        'strSQL.Append("WHERE ")
        ''strSQL.Append("--L.IDALMACEN = @IDALMACEN ")
        ''strSQL.Append("--AND CP.IDSUMINISTRO = @IDSUMINISTRO ")
        ''strSQL.Append("--AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        ''strSQL.Append("--AND (L.IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")
        ''strSQL.Append("--AND (L.IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION OR @IDRESPONSABLEDISTRIBUCION = 0) ")
        ''strSQL.Append("--AND (L.CANTIDADDISPONIBLE > 0 OR L.CANTIDADNODISPONIBLE > 0 OR L.CANTIDADVENCIDA > 0 OR L.CANTIDADRESERVADA > 0 OR L.CANTIDADTEMPORAL > 0) ")
        'strSQL.Append("(t.CANTIDADDISPONIBLE > 0 OR t.CANTIDADNODISPONIBLE > 0 OR t.CANTIDADVENCIDA > 0) ")
        'strSQL.Append("AND L.ESTADISPONIBLE = 1 ")
        'strSQL.Append("ORDER BY CP.CORRPRODUCTO, L.FECHAVENCIMIENTO, L.CANTIDADDISPONIBLE, L.CANTIDADVENCIDA, L.CANTIDADNODISPONIBLE ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(0).Direction = ParameterDirection.Input
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(1).Direction = ParameterDirection.Input
        args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(2).Value = IDGRUPO
        args(2).Direction = ParameterDirection.Input
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Value = IDFUENTEFINANCIAMIENTO
        args(3).Direction = ParameterDirection.Input
        args(4) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(4).Value = IDRESPONSABLEDISTRIBUCION
        args(4).Direction = ParameterDirection.Input
        args(5) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(5).Value = FECHAHASTA
        args(5).Direction = ParameterDirection.Input
        args(6) = New SqlParameter("@IDGRUPOFUENTEFINANCIAMIENTO", SqlDbType.SmallInt)
        args(6).Value = IDGRUPOFUENTEFINANCIAMIENTO
        args(6).Direction = ParameterDirection.Input
        args(7) = New SqlParameter("@FOS", SqlDbType.Int)
        args(7).Value = fos
        args(7).Direction = ParameterDirection.Input
        args(8) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.SmallInt)
        args(8).Value = IDESPECIFICOGASTO
        args(8).Direction = ParameterDirection.Input

        Dim ds As New DataSet

        'Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Dim da As New SqlDataAdapter(strSQL.ToString(), Me.cnnStr)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandTimeout = 0
        For Each param As SqlParameter In args
            If Not param Is Nothing Then
                da.SelectCommand.Parameters.Add(param)
            End If
        Next
        da.Fill(ds)

        '        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function VencimientoHistoricaPorTipoProducto(ByVal IDALMACEN As Int32, ByVal IDSUMINISTRO As Int64, ByVal FECHAHASTA As Date, ByVal FECHADESDE As Date) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_VencimientoFechaDada")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(0).Direction = ParameterDirection.Input
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(1).Direction = ParameterDirection.Input
        args(2) = New SqlParameter("@FECHADESDE", SqlDbType.DateTime)
        args(2).Value = FECHADESDE
        args(2).Direction = ParameterDirection.Input
        args(3) = New SqlParameter("@FECHAHASTA", SqlDbType.DateTime)
        args(3).Value = FECHAHASTA
        args(3).Direction = ParameterDirection.Input

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información de las existencias a la fecha de un almacén especifico.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén(Filtro).</param>
    ''' <param name="IDPRODUCTO">Identificador del producto(Filtro).</param>
    ''' <param name="IDALMACENORIGEN">Identificador del almacén de origen(Filtro).</param>
    ''' <returns>Dataset con la información de las existencias a la fecha.</returns>
    ''' <remarks>Lista de tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_FUENTESFINANCIAMIENTO</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  10/02/2007    Creado
    ''' </history> 
    Public Function ExistenciaTemporalPorProductosActual(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDALMACENORIGEN As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION DESCRIPCIONUNIDADMEDIDA, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("R.NOMBRE NOMBRERESPONSABLE, ")
        strSQL.Append("R.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("F.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("L.ESTADISPONIBLE, ")
        strSQL.Append("L.IDALMACENORIGEN ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_RESPONSABLEDISTRIBUCION R ")
        strSQL.Append("INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("ON R.IDRESPONSABLEDISTRIBUCION = L.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS F ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = F.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("WHERE (L.IDALMACEN = @IDALMACEN) ")
        strSQL.Append("AND (L.IDALMACENORIGEN = @IDALMACENORIGEN OR @IDALMACENORIGEN = 0) ")
        strSQL.Append("AND (L.IDPRODUCTO = @IDPRODUCTO) ")
        strSQL.Append("AND (L.ESTADISPONIBLE = 1) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDALMACENORIGEN", SqlDbType.Int)
        args(1).Value = IDALMACENORIGEN
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Consulta de Existencia Temporal Por Tipo de Producto
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="IDSUMINISTRO">Identificador del suministro</param>
    ''' <param name="IDGRUPO">Identificador del grupo</param>
    ''' <param name="IDALMACENORIGEN"></param>
    ''' <returns>Listado de existencias en formato dataset</returns>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ExistenciaTemporalPorTipoProducto(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDALMACENORIGEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("L.IDALMACEN, ")
        strSQL.Append("A.NOMBRE, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.ESFARMACIA, ")
        strSQL.Append("L.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION DESCRIPCIONUNIDADMEDIDA, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("L.IDLOTE, ")
        strSQL.Append("isnull(L.CODIGO, '(N/A)') CODIGO, ")
        strSQL.Append("L.PRECIOLOTE, ")
        strSQL.Append("L.FECHAVENCIMIENTO, ")
        strSQL.Append("L.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRE NOMBRERESPONSABLE, ")
        strSQL.Append("RD.NOMBRECORTO NOMBRECORTORESPONSABLE, ")
        strSQL.Append("L.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("F.NOMBRE NOMBREFUENTE, ")
        strSQL.Append("L.CANTIDADDISPONIBLE, ")
        strSQL.Append("L.CANTIDADNODISPONIBLE, ")
        strSQL.Append("L.CANTIDADVENCIDA, ")
        strSQL.Append("L.CANTIDADRESERVADA, ")
        strSQL.Append("L.CANTIDADTEMPORAL, ")
        strSQL.Append("L.ESTADISPONIBLE, ")
        strSQL.Append("L.IDALMACENORIGEN ")
        strSQL.Append("FROM SAB_ALM_LOTES L ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON L.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("ON L.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS F ")
        strSQL.Append("ON L.IDFUENTEFINANCIAMIENTO = F.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON L.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("WHERE L.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND L.ESTADISPONIBLE = 1 ")
        strSQL.Append("AND CP.IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append("AND (CP.IDGRUPO = @IDGRUPO OR @IDGRUPO = 0) ")
        strSQL.Append("AND (L.IDALMACENORIGEN = @IDALMACENORIGEN OR @IDALMACENORIGEN = 0) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = IDSUMINISTRO
        args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(2).Value = IDGRUPO
        args(3) = New SqlParameter("@IDALMACENORIGEN", SqlDbType.Int)
        args(3).Value = IDALMACENORIGEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Verifica si esta creado lote SIM para un producto
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param> 'identificador del almacen
    ''' <param name="IDPRODUCTO">Identificador del producto</param> 'identificador del producto
    ''' <returns>
    ''' verdadero si existe, de lo contrario falso
    ''' </returns>

    Public Function ExisteLoteSIMProducto(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_ALM_LOTES ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND CODIGO = 'SIM' ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True
    End Function

    ''' <summary>
    ''' la existencia en cantidad disponible de un producto de lote SIM
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param> 'Identificador del almacen
    ''' <param name="IDPRODUCTO">Identificador del producto</param> 'identificador del producto
    ''' <returns></returns>

    Public Function ExistenciaLoteSIMProducto(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT CANTIDADDISPONIBLE ")
        strSQL.Append("FROM SAB_ALM_LOTES ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND CODIGO = 'SIM' ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO

        Return CDbl(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args))
    End Function

    ''' <summary>
    ''' Obtener el idlote del los productos con lote SM
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param> 'identificador del almacen
    ''' <param name="IDPRODUCTO">Identificador del producto</param> 'identificador del producto
    ''' <returns>
    ''' un entero que representa el identificador del lote
    ''' </returns>

    Public Function ObteneridLoteSIMProducto(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDLOTE ")
        strSQL.Append("FROM SAB_ALM_LOTES ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND CODIGO = 'SIM' ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        Dim cn As New SqlConnection(Me.cnnStr)
        Dim cmd As New SqlCommand(strSQL.ToString(), cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        For Each param As SqlParameter In args
            If Not param Is Nothing Then
                cmd.Parameters.Add(param)
            End If
        Next
        'Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Dim ret As Integer
        cn.Open()
        ret = cmd.ExecuteScalar
        cn.Close()
        Return ret
    End Function
    Public Function ObtenerRespyFF(ByVal IDALMACEN As Integer, IDPRODUCTO As Integer, IDLOTE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDRESPONSABLEDISTRIBUCION, IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("FROM SAB_ALM_LOTES ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN AND IDLOTE=@IDLOTE AND IDPRODUCTO=@IDPRODUCTO ")
        
        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDLOTE", SqlDbType.Int)
        args(2).Value = IDLOTE
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
#End Region

End Class
