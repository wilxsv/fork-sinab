Partial Public Class dbINFORMEMUESTRAS

#Region " Metodos Agregados "

    ''' <summary>
    ''' Obtiene los informes de muestras que cumplen con el criterio especificado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del informe.</param>
    ''' <param name="IDESTADO">Identificador del estado en el que se encuentra el informe.  Opcional.  Por defecto es cero y no se considera.</param>
    ''' <param name="IDTIPOINFORME">Identificador del tipo de informe (aceptación, rechazo, no inspección).  Opcional.  Por defecto es cero y no se considera.</param>
    ''' <param name="IDEMPLEADO">Identificador del empleado responsable (inspector o coordinador) del informe.  Opcional.  Por defecto es cero y no se considera.</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_LAB_INFORMEMUESTRAS</item>
    ''' <item>SAB_CAT_TIPOINFORMES</item>
    ''' <item>SAB_CAT_PROVEEDORES</item>
    ''' <item>SAB_UACI_PRODUCTOSCONTRATO</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaInformes(ByVal IDESTABLECIMIENTO As Integer, ByVal IDESTADO As Integer, ByVal IDTIPOINFORME() As Byte, ByVal IDEMPLEADO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IM.IDESTABLECIMIENTO, ")
        strSQL.Append("IM.IDINFORME, ")
        strSQL.Append("IM.IDTIPOINFORME, ")
        strSQL.Append("TI.DESCRIPCION TIPOINFORME, ")
        strSQL.Append("IM.NUMEROINFORME, ")
        strSQL.Append("IM.IDESTADO, ")
        strSQL.Append("IM.FECHAELABORACIONINFORME, ")
        strSQL.Append("P.NOMBRE PROVEEDOR, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("IM.RENGLON, ")
        strSQL.Append("IM.LOTE, ")
        strSQL.Append("IM.FECHACERTIFICACION, ")
        strSQL.Append("case IM.RESULTADOINSPECCION ")
        strSQL.Append(" when 1 then 'ACEPTADO' ")
        strSQL.Append(" when 2 then 'RECHAZADO' ")
        strSQL.Append(" when 3 then 'NO INSPECCION' ")
        strSQL.Append(" else '' ")
        strSQL.Append("end RESULTADOINSPECCION, ")
        strSQL.Append("isnull(E.NOMBRE + ' ' + E.APELLIDO, '') INSPECTOR ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOINFORMES TI ")
        strSQL.Append("ON IM.IDTIPOINFORME = TI.IDTIPOINFORME ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON IM.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON (IM.IDESTABLECIMIENTOCONTRATO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND IM.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND IM.RENGLON = PC.RENGLON) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS E ")
        strSQL.Append("ON IM.IDINSPECTOR = E.IDEMPLEADO ")
        strSQL.Append("WHERE IM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND (@IDESTADO = 0 OR IM.IDESTADO = @IDESTADO) ")

        If Not IsNothing(IDTIPOINFORME) Then
            For i As Integer = 0 To IDTIPOINFORME.Length - 1
                If i = 0 Then
                    strSQL.Append("AND IM.IDTIPOINFORME IN ( ")
                End If
                strSQL.Append("@IDTIPOINFORME" + i.ToString)
                If i = IDTIPOINFORME.Length - 1 Then
                    strSQL.Append(") ")
                Else
                    strSQL.Append(", ")
                End If
            Next
        End If

        strSQL.Append("AND (@IDEMPLEADO = 0 OR (IM.IDINSPECTOR = @IDEMPLEADO OR IM.IDCOORDINADOR = @IDEMPLEADO)) ")
        strSQL.Append("ORDER BY IM.FECHAELABORACIONINFORME DESC, IM.IDINFORME DESC ")

        Dim length As Integer
        If Not IsNothing(IDTIPOINFORME) Then length = IDTIPOINFORME.Length

        Dim args(3 + length) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(1).Value = IDESTADO
        args(2) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(2).Value = IDEMPLEADO

        If Not IsNothing(IDTIPOINFORME) Then
            For i As Integer = 0 To IDTIPOINFORME.Length - 1
                args(3 + i) = New SqlParameter("@IDTIPOINFORME" + i.ToString, SqlDbType.Int)
                args(3 + i).Value = IDTIPOINFORME(i)
            Next
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Método para obtener la información de los proveedores.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos</param>
    ''' <param name="IDPROVEEDOR">Filtro para devolver los datos</param>
    ''' <param name="IDCONTRATO">Filtro para devolver los datos</param>
    ''' <param name="RENGLON">Filtro para devolver los datos</param>
    ''' <returns></returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_LAB_INFORMEMUESTRAS</item>
    ''' <item>SAB_CAT_TIPOINFORMES</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function ObtenerInformacionProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("LOTE, ")
        strSQL.Append("convert(varchar, FECHAVENCIMIENTO, 103) FECHAVENCIMIENTO, ")
        strSQL.Append("TI.DESCRIPCION RESULTADOINSPECCIONMUESTRA, ")
        strSQL.Append("CASE ")
        strSQL.Append(" WHEN (IM.IDTIPOINFORME = 1 AND RESULTADOINSPECCION = 1 AND IDESTADO = 3) THEN 'Aceptado' ")
        strSQL.Append(" WHEN (IM.IDTIPOINFORME = 1 AND RESULTADOINSPECCION = 2 AND IDESTADO = 3) THEN 'Rechazado' ")
        strSQL.Append(" WHEN (IM.IDTIPOINFORME = 1 AND (RESULTADOINSPECCION is NULL OR IDESTADO <> 3)) THEN 'Pendiente' ")
        strSQL.Append(" WHEN (IM.IDTIPOINFORME <> 1) THEN 'N/A' ")
        strSQL.Append("END RESULTADOANALISIS ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOINFORMES TI ")
        strSQL.Append("ON IM.IDTIPOINFORME = TI.IDTIPOINFORME ")
        strSQL.Append("WHERE IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene la información de un contrato dado, junto con la de los informes de muestras relacionados a los mismos.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ENTREGACONTRATO</item>
    ''' <item>SAB_UACI_PRODUCTOSCONTRATO</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_LAB_INFORMEMUESTRAS</item>
    ''' <item>SAB_CAT_TIPOINFORMES</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function ReporteProveedoresContratados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT PC.PRECIOUNITARIO * PC.CANTIDAD MONTOENTREGA, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("C.CORRPRODUCTO, ")
        strSQL.Append("C.DESCLARGO, ")
        strSQL.Append("C.DESCRIPCION, ")
        strSQL.Append("PC.CANTIDAD, ")
        strSQL.Append("(SELECT COUNT(IDDETALLE) AS Expr1 ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append(" AND RENGLON = PC.RENGLON) NENTREGA, ")
        strSQL.Append("IM.LOTE, ")
        strSQL.Append("IM.FECHAVENCIMIENTO, ")
        strSQL.Append("TI.DESCRIPCION RESULTADOINSPECCIONMUESTRA, ")
        strSQL.Append("CASE ")
        strSQL.Append(" WHEN (IM.IDTIPOINFORME = 1 AND RESULTADOINSPECCION = 1 AND IDESTADO = 3) THEN 'Aceptado' ")
        strSQL.Append(" WHEN (IM.IDTIPOINFORME = 1 AND RESULTADOINSPECCION = 2 AND IDESTADO = 3) THEN 'Rechazado' ")
        strSQL.Append(" WHEN (IM.IDTIPOINFORME = 1 AND (RESULTADOINSPECCION is NULL OR IDESTADO <> 3)) THEN 'Pendiente' ")
        strSQL.Append(" WHEN (IM.IDTIPOINFORME <> 1) THEN 'N/A' ")
        strSQL.Append("END RESULTADOANALISIS ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS C ")
        strSQL.Append("ON PC.IDPRODUCTO = C.IDPRODUCTO ")
        strSQL.Append("RIGHT OUTER JOIN SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("ON (IM.IDESTABLECIMIENTOCONTRATO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND IM.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND IM.RENGLON = PC.RENGLON) ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOINFORMES TI ")
        strSQL.Append("ON IM.IDTIPOINFORME = TI.IDTIPOINFORME ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = @IDCONTRATO ")

        Dim args(3) As SqlParameter
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
    ''' Devuelve la información de los lotes examinados por el laboratorio para un renglón especifico.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato al que pertenece el renglón.</param>
    ''' <param name="RENGLON">Número del renglón seleccionado.</param>
    ''' <returns>Dataset con la información de los lotes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_LAB_INFORMEMUESTRAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  05/02/2007    Creado
    ''' </history> 
    Public Function ObtenerInformacionLotesRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IM.*, ")
        strSQL.Append("TI.DESCRIPCION TIPOINFORME ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOINFORMES TI ")
        strSQL.Append("ON IM.IDTIPOINFORME = TI.IDTIPOINFORME ")
        strSQL.Append("WHERE IM.IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IM.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND IM.RENGLON = @RENGLON ")
        strSQL.Append("AND IM.IDTIPOINFORME in (1, 2) ")
        strSQL.Append("AND IM.IDESTADO = 3 ")
        strSQL.Append("AND IM.RESULTADOINSPECCION = 1 ")
        strSQL.Append("ORDER BY IM.FECHAELABORACIONINFORME ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerInformacionLotesRecibo(ByVal IDESTABLE As Integer, ByVal IDINFORMECONTROLCALIDAD As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select i.* ")
        strSQL.Append(" from SAB_ALM_LOTES L inner join SAB_LAB_INFORMEMUESTRAS I ")
        strSQL.Append(" on	i.idinforme = l.idinformecontrolcalidad ")
        strSQL.Append(" where i.idtipoinforme = 1 and i.idestado = 3 and l.idinformecontrolcalidad = @IDINFORMECONTROLCALIDAD ")
        strSQL.Append("AND i.RESULTADOINSPECCION = 1 AND i.idestablecimiento = @idestablecimiento")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDINFORMECONTROLCALIDAD", SqlDbType.Int)
        args(0).Value = IDINFORMECONTROLCALIDAD
        args(1) = New SqlParameter("@idestablecimiento", SqlDbType.Int)
        args(1).Value = IDESTABLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información de los lotes examinados por el laboratorio para un renglón especifico,
    ''' mostrando unicamente aquellos lotes que han sido rechazados.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato al que pertenece el renglón.</param>
    ''' <param name="RENGLON">Número del renglón seleccionado.</param>
    ''' <returns>Dataset con la información de los lotes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_LAB_INFORMEMUESTRAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  05/02/2007    Creado
    ''' </history> 
    Public Function ObtenerInformacionLoteRenglonRechazado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal LOTE As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND RENGLON = @RENGLON ")
        strSQL.Append("AND LOTE = @LOTE ")
        strSQL.Append("AND IDTIPOINFORME = 1 ")
        strSQL.Append("AND IDESTADO = 3 ")
        strSQL.Append("AND RESULTADOINSPECCION = 2 ")
        strSQL.Append("ORDER BY FECHAVENCIMIENTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON
        args(4) = New SqlParameter("@LOTE", SqlDbType.VarChar)
        args(4).Value = LOTE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la información de un informe de calidad para un renglón y lote especifico.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato al que pertenece el renglón.</param>
    ''' <param name="RENGLON">Número del renglón seleccionado.</param>
    ''' <returns>Dataset con la información de los lotes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_LAB_INFORMEMUESTRAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  05/02/2007    Creado
    ''' </history>
    Public Function ObtenerInformacionLote(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal LOTE As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND RENGLON = @RENGLON ")
        strSQL.Append("AND LOTE = @LOTE ")
        strSQL.Append("AND IDTIPOINFORME = 1 ")
        strSQL.Append("AND IDESTADO = 3 ")
        strSQL.Append("ORDER BY FECHAVENCIMIENTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON
        args(4) = New SqlParameter("@LOTE", SqlDbType.VarChar)
        args(4).Value = LOTE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve los datos del informe de muestras junto con los del contrato relacionado.
    ''' </summary>
    ''' <param name="aEntidad">Entidad INFORMEMUESTRAS.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_LAB_INFORMEMUESTRAS</item>
    ''' <item>SAB_UACI_PRODUCTOSCONTRATO</item>
    ''' <item>SAB_UACI_CONTRATOS</item>
    ''' <item>SAB_UACI_CONTRATOSPROCESOCOMPRA</item>
    ''' <item>SAB_UACI_PROCESOCOMPRAS</item>
    ''' <item>SAB_CAT_ESTABLECIMIENTOS</item>
    ''' <item>SAB_CAT_PROVEEDORES</item>
    ''' <item>SAB_CAT_MODALIDADESCOMPRA</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function RecuperarInformeMuestrasContrato(ByVal aEntidad As INFORMEMUESTRAS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IM.*, ")
        strSQL.Append("PC.CANTIDAD CANTIDADCONTRATADA, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("C.FECHADISTRIBUCION, ")
        strSQL.Append("isnull(MC.DESCRIPCION, '') MODALIDADCOMPRA, ")
        strSQL.Append("isnull(C.NUMEROMODALIDADCOMPRA, 0) NUMEROMODALIDADCOMPRA, ")
        strSQL.Append("isnull(PCOM.NUMERORESOLUCION, '') NUMERORESOLUCION, ")
        strSQL.Append("P.NOMBRE NOMBREPROVEEDOR, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTOCONTRATO, ")
        strSQL.Append("isnull(EM.NOMBRE + ' ' + EM.APELLIDO, '') INSPECTOR, ")
        strSQL.Append("isnull(EM.NOMBRECORTO, '') CODIGOINSPECTOR, ")
        strSQL.Append("isnull(EM1.NOMBRE + ' ' + EM1.APELLIDO, '') COORDINADOR, ")
        strSQL.Append("isnull(EM1.NOMBRECORTO, '') CODIGOCOORDINADOR, ")
        strSQL.Append("isnull(EM2.NOMBRE + ' ' + EM2.APELLIDO, '') JEFELABORATORIO, ")
        strSQL.Append("isnull(EM2.NOMBRECORTO, '') CODIGOJEFELABORATORIO ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON (IM.IDESTABLECIMIENTOCONTRATO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND IM.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND IM.RENGLON = PC.RENGLON) ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = CPC.IDCONTRATO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_PROCESOCOMPRAS PCOM ")
        strSQL.Append("ON (CPC.IDESTABLECIMIENTO = PCOM.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = PCOM.IDPROCESOCOMPRA) ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON PC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_MODALIDADESCOMPRA MC ")
        strSQL.Append("ON C.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ")
        strSQL.Append("ON IM.IDINSPECTOR = EM.IDEMPLEADO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM1 ")
        strSQL.Append("ON IM.IDCOORDINADOR = EM1.IDEMPLEADO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_EMPLEADOS EM2 ")
        strSQL.Append("ON IM.IDJEFELABORATORIO = EM2.IDEMPLEADO ")
        strSQL.Append("WHERE IM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDINFORME = @IDINFORME ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = aEntidad.IDINFORME

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Try
            Do While dr.Read()
                aEntidad.IDTIPOINFORME = IIf(dr("IDTIPOINFORME") Is DBNull.Value, Nothing, dr("IDTIPOINFORME"))
                aEntidad.NUMEROINFORME = IIf(dr("NUMEROINFORME") Is DBNull.Value, Nothing, dr("NUMEROINFORME"))
                aEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                aEntidad.IDESTABLECIMIENTOCONTRATO = IIf(dr("IDESTABLECIMIENTOCONTRATO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTOCONTRATO"))
                aEntidad.IDPROVEEDOR = IIf(dr("IDPROVEEDOR") Is DBNull.Value, Nothing, dr("IDPROVEEDOR"))
                aEntidad.IDCONTRATO = IIf(dr("IDCONTRATO") Is DBNull.Value, Nothing, dr("IDCONTRATO"))
                aEntidad.RENGLON = IIf(dr("RENGLON") Is DBNull.Value, Nothing, dr("RENGLON"))
                aEntidad.NOMBREMEDICAMENTO = IIf(dr("NOMBREMEDICAMENTO") Is DBNull.Value, Nothing, dr("NOMBREMEDICAMENTO"))
                aEntidad.NOMBRECOMERCIAL = IIf(dr("NOMBRECOMERCIAL") Is DBNull.Value, Nothing, dr("NOMBRECOMERCIAL"))
                aEntidad.LABORATORIOFABRICANTE = IIf(dr("LABORATORIOFABRICANTE") Is DBNull.Value, Nothing, dr("LABORATORIOFABRICANTE"))
                aEntidad.PROVEEDOR = IIf(dr("PROVEEDOR") Is DBNull.Value, Nothing, dr("PROVEEDOR"))
                aEntidad.LOTE = IIf(dr("LOTE") Is DBNull.Value, Nothing, dr("LOTE"))
                aEntidad.FECHAFABRICACION = IIf(dr("FECHAFABRICACION") Is DBNull.Value, Nothing, dr("FECHAFABRICACION"))
                aEntidad.FECHAVENCIMIENTO = IIf(dr("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, dr("FECHAVENCIMIENTO"))
                aEntidad.NUMEROUNIDADES = IIf(dr("NUMEROUNIDADES") Is DBNull.Value, Nothing, dr("NUMEROUNIDADES"))
                aEntidad.CANTIDADREMITIDA = IIf(dr("CANTIDADREMITIDA") Is DBNull.Value, Nothing, dr("CANTIDADREMITIDA"))
                aEntidad.ESTABLECIMIENTOREMITE = IIf(dr("ESTABLECIMIENTOREMITE") Is DBNull.Value, Nothing, dr("ESTABLECIMIENTOREMITE"))
                aEntidad.NUMERORECEPCION = IIf(dr("NUMERORECEPCION") Is DBNull.Value, Nothing, dr("NUMERORECEPCION"))
                aEntidad.GUIAAEREA = IIf(dr("GUIAAEREA") Is DBNull.Value, Nothing, dr("GUIAAEREA"))
                aEntidad.DESCRIPCIONEMPAQUE = IIf(dr("DESCRIPCIONEMPAQUE") Is DBNull.Value, Nothing, dr("DESCRIPCIONEMPAQUE"))
                aEntidad.LEYENDAREQUERIDA = IIf(dr("LEYENDAREQUERIDA") Is DBNull.Value, Nothing, dr("LEYENDAREQUERIDA"))
                aEntidad.NUMEROREGISTRO = IIf(dr("NUMEROREGISTRO") Is DBNull.Value, Nothing, dr("NUMEROREGISTRO"))
                aEntidad.VIAADMINISTRACION = IIf(dr("VIAADMINISTRACION") Is DBNull.Value, Nothing, dr("VIAADMINISTRACION"))
                aEntidad.FORMADISOLUCION = IIf(dr("FORMADISOLUCION") Is DBNull.Value, Nothing, dr("FORMADISOLUCION"))
                aEntidad.CONDICIONESALMACENAMIENTO = IIf(dr("CONDICIONESALMACENAMIENTO") Is DBNull.Value, Nothing, dr("CONDICIONESALMACENAMIENTO"))
                aEntidad.NUMEROLOTE = IIf(dr("NUMEROLOTE") Is DBNull.Value, Nothing, dr("NUMEROLOTE"))
                aEntidad.FECHAEXPIRACION = IIf(dr("FECHAEXPIRACION") Is DBNull.Value, Nothing, dr("FECHAEXPIRACION"))
                aEntidad.OTROSEMPAQUES = IIf(dr("OTROSEMPAQUES") Is DBNull.Value, Nothing, dr("OTROSEMPAQUES"))
                aEntidad.DESCRIPCIONOTROSEMPAQUES = IIf(dr("DESCRIPCIONOTROSEMPAQUES") Is DBNull.Value, Nothing, dr("DESCRIPCIONOTROSEMPAQUES"))
                aEntidad.DESCRIPCIONPRODUCTO = IIf(dr("DESCRIPCIONPRODUCTO") Is DBNull.Value, Nothing, dr("DESCRIPCIONPRODUCTO"))
                aEntidad.CANTIDADFISICOQUIMICO = IIf(dr("CANTIDADFISICOQUIMICO") Is DBNull.Value, Nothing, dr("CANTIDADFISICOQUIMICO"))
                aEntidad.CANTIDADMICROBIOLOGIA = IIf(dr("CANTIDADMICROBIOLOGIA") Is DBNull.Value, Nothing, dr("CANTIDADMICROBIOLOGIA"))
                aEntidad.CANTIDADRETENCION = IIf(dr("CANTIDADRETENCION") Is DBNull.Value, Nothing, dr("CANTIDADRETENCION"))
                aEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO = IIf(dr("DESCRIPCIONCONDICIONESALMACENAMIENTO") Is DBNull.Value, Nothing, dr("DESCRIPCIONCONDICIONESALMACENAMIENTO"))
                aEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                aEntidad.IDINSPECTOR = IIf(dr("IDINSPECTOR") Is DBNull.Value, Nothing, dr("IDINSPECTOR"))
                aEntidad.FECHAELABORACIONINFORME = IIf(dr("FECHAELABORACIONINFORME") Is DBNull.Value, Nothing, dr("FECHAELABORACIONINFORME"))
                aEntidad.IDCOORDINADOR = IIf(dr("IDCOORDINADOR") Is DBNull.Value, Nothing, dr("IDCOORDINADOR"))
                aEntidad.MOTIVOSNOINSPECCION = IIf(dr("MOTIVOSNOINSPECCION") Is DBNull.Value, Nothing, dr("MOTIVOSNOINSPECCION"))
                aEntidad.FECHACERTIFICACION = IIf(dr("FECHACERTIFICACION") Is DBNull.Value, Nothing, dr("FECHACERTIFICACION"))
                aEntidad.FECHASOLICITUDINSPECCION = IIf(dr("FECHASOLICITUDINSPECCION") Is DBNull.Value, Nothing, dr("FECHASOLICITUDINSPECCION"))
                aEntidad.FECHARECOLECCIONMUESTRA = IIf(dr("FECHARECOLECCIONMUESTRA") Is DBNull.Value, Nothing, dr("FECHARECOLECCIONMUESTRA"))
                aEntidad.OBSERVACIONCERTIFICACION = IIf(dr("OBSERVACIONCERTIFICACION") Is DBNull.Value, Nothing, dr("OBSERVACIONCERTIFICACION"))
                aEntidad.IDJEFELABORATORIO = IIf(dr("IDJEFELABORATORIO") Is DBNull.Value, Nothing, dr("IDJEFELABORATORIO"))
                aEntidad.REPRESENTANTEPROVEEDOR = IIf(dr("REPRESENTANTEPROVEEDOR") Is DBNull.Value, Nothing, dr("REPRESENTANTEPROVEEDOR"))
                aEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                aEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                aEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                aEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                aEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                aEntidad.ORIGENPRODUCTO = IIf(dr("ORIGENPRODUCTO") Is DBNull.Value, Nothing, dr("ORIGENPRODUCTO"))
                aEntidad.TIPOPRODUCTO = IIf(dr("TIPOPRODUCTO") Is DBNull.Value, Nothing, dr("TIPOPRODUCTO"))
                aEntidad.MOTIVONOACEPTACION = IIf(dr("MOTIVONOACEPTACION") Is DBNull.Value, Nothing, dr("MOTIVONOACEPTACION"))
                aEntidad.DESCRIPCIONDISOLUCION = IIf(dr("DESCRIPCIONDISOLUCION") Is DBNull.Value, Nothing, dr("DESCRIPCIONDISOLUCION"))

                aEntidad.ESTABLECIMIENTOCONTRATO = IIf(dr("ESTABLECIMIENTOCONTRATO") Is DBNull.Value, Nothing, dr("ESTABLECIMIENTOCONTRATO"))
                aEntidad.NUMEROCONTRATO = IIf(dr("NUMEROCONTRATO") Is DBNull.Value, Nothing, dr("NUMEROCONTRATO"))
                aEntidad.FECHADISTRIBUCION = IIf(dr("FECHADISTRIBUCION") Is DBNull.Value, Nothing, dr("FECHADISTRIBUCION"))
                aEntidad.CANTIDADCONTRATADA = IIf(dr("CANTIDADCONTRATADA") Is DBNull.Value, Nothing, dr("CANTIDADCONTRATADA"))
                aEntidad.NOMBREPROVEEDOR = IIf(dr("NOMBREPROVEEDOR") Is DBNull.Value, Nothing, dr("NOMBREPROVEEDOR"))
                aEntidad.UNIDADMEDIDA = IIf(dr("UNIDADMEDIDA") Is DBNull.Value, Nothing, dr("UNIDADMEDIDA"))
                aEntidad.DESCRIPCIONCP = IIf(dr("DESCLARGO") Is DBNull.Value, Nothing, dr("DESCLARGO"))
                aEntidad.DESCRIPCIONPROVEEDOR = IIf(dr("DESCRIPCIONPROVEEDOR") Is DBNull.Value, Nothing, dr("DESCRIPCIONPROVEEDOR"))
                aEntidad.INSPECTOR = IIf(dr("INSPECTOR") Is DBNull.Value, Nothing, dr("INSPECTOR"))
                aEntidad.CODIGOINSPECTOR = IIf(dr("CODIGOINSPECTOR") Is DBNull.Value, Nothing, dr("CODIGOINSPECTOR"))
                aEntidad.COORDINADOR = IIf(dr("COORDINADOR") Is DBNull.Value, Nothing, dr("COORDINADOR"))
                aEntidad.CODIGOCOORDINADOR = IIf(dr("CODIGOCOORDINADOR") Is DBNull.Value, Nothing, dr("CODIGOCOORDINADOR"))
                aEntidad.JEFELABORATORIO = IIf(dr("JEFELABORATORIO") Is DBNull.Value, Nothing, dr("JEFELABORATORIO"))
                aEntidad.CODIGOJEFELABORATORIO = IIf(dr("CODIGOJEFELABORATORIO") Is DBNull.Value, Nothing, dr("CODIGOJEFELABORATORIO"))

                aEntidad.MODALIDADCOMPRA = IIf(dr("MODALIDADCOMPRA") Is DBNull.Value, Nothing, dr("MODALIDADCOMPRA"))
                aEntidad.NUMEROMODALIDADCOMPRA = IIf(dr("NUMEROMODALIDADCOMPRA") Is DBNull.Value, Nothing, dr("NUMEROMODALIDADCOMPRA"))

                aEntidad.NUMERORESOLUCION = IIf(dr("NUMERORESOLUCION") Is DBNull.Value, Nothing, dr("NUMERORESOLUCION"))

            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return 1

    End Function

    Public Function RecuperarInformeMuestrasContrato2(ByVal aEntidad As INFORMEMUESTRAS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IM.*, ")
        strSQL.Append("PC.CANTIDAD CANTIDADCONTRATADA, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("C.FECHADISTRIBUCION, ")
        strSQL.Append("isnull(MC.DESCRIPCION, '') MODALIDADCOMPRA, ")
        strSQL.Append("isnull(C.NUMEROMODALIDADCOMPRA, 0) NUMEROMODALIDADCOMPRA, ")
        strSQL.Append("isnull(PCOM.NUMERORESOLUCION, '') NUMERORESOLUCION, ")
        strSQL.Append("P.NOMBRE NOMBREPROVEEDOR, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTOCONTRATO, ")
        strSQL.Append("isnull(EM.NOMBRE + ' ' + EM.APELLIDO, '') INSPECTOR, ")
        strSQL.Append("isnull(EM.NOMBRECORTO, '') CODIGOINSPECTOR ")
        'strSQL.Append("isnull(EM1.NOMBRE + ' ' + EM1.APELLIDO, '') COORDINADOR, ")
        'strSQL.Append("isnull(EM1.NOMBRECORTO, '') CODIGOCOORDINADOR, ")
        'strSQL.Append("isnull(EM2.NOMBRE + ' ' + EM2.APELLIDO, '') JEFELABORATORIO, ")
        'strSQL.Append("isnull(EM2.NOMBRECORTO, '') CODIGOJEFELABORATORIO ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON (IM.IDESTABLECIMIENTOCONTRATO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND IM.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND IM.RENGLON = PC.RENGLON) ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = CPC.IDCONTRATO) ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_PROCESOCOMPRAS PCOM ")
        strSQL.Append("ON (CPC.IDESTABLECIMIENTO = PCOM.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = PCOM.IDPROCESOCOMPRA) ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON PC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_MODALIDADESCOMPRA MC ")
        strSQL.Append("ON C.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ")
        strSQL.Append("ON IM.IDINSPECTOR = EM.IDEMPLEADO ")
        'strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM1 ")
        'strSQL.Append("ON IM.IDCOORDINADOR = EM1.IDEMPLEADO ")
        'strSQL.Append("LEFT OUTER JOIN SAB_CAT_EMPLEADOS EM2 ")
        'strSQL.Append("ON IM.IDJEFELABORATORIO = EM2.IDEMPLEADO ")
        strSQL.Append("WHERE IM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDINFORME = @IDINFORME ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = aEntidad.IDINFORME

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Try
            Do While dr.Read()
                aEntidad.IDTIPOINFORME = IIf(dr("IDTIPOINFORME") Is DBNull.Value, Nothing, dr("IDTIPOINFORME"))
                aEntidad.NUMEROINFORME = IIf(dr("NUMEROINFORME") Is DBNull.Value, Nothing, dr("NUMEROINFORME"))
                aEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                aEntidad.IDESTABLECIMIENTOCONTRATO = IIf(dr("IDESTABLECIMIENTOCONTRATO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTOCONTRATO"))
                aEntidad.IDPROVEEDOR = IIf(dr("IDPROVEEDOR") Is DBNull.Value, Nothing, dr("IDPROVEEDOR"))
                aEntidad.IDCONTRATO = IIf(dr("IDCONTRATO") Is DBNull.Value, Nothing, dr("IDCONTRATO"))
                aEntidad.RENGLON = IIf(dr("RENGLON") Is DBNull.Value, Nothing, dr("RENGLON"))
                aEntidad.NOMBREMEDICAMENTO = IIf(dr("NOMBREMEDICAMENTO") Is DBNull.Value, Nothing, dr("NOMBREMEDICAMENTO"))
                aEntidad.NOMBRECOMERCIAL = IIf(dr("NOMBRECOMERCIAL") Is DBNull.Value, Nothing, dr("NOMBRECOMERCIAL"))
                aEntidad.LABORATORIOFABRICANTE = IIf(dr("LABORATORIOFABRICANTE") Is DBNull.Value, Nothing, dr("LABORATORIOFABRICANTE"))
                aEntidad.PROVEEDOR = IIf(dr("PROVEEDOR") Is DBNull.Value, Nothing, dr("PROVEEDOR"))
                aEntidad.LOTE = IIf(dr("LOTE") Is DBNull.Value, Nothing, dr("LOTE"))
                aEntidad.FECHAFABRICACION = IIf(dr("FECHAFABRICACION") Is DBNull.Value, Nothing, dr("FECHAFABRICACION"))
                aEntidad.FECHAVENCIMIENTO = IIf(dr("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, dr("FECHAVENCIMIENTO"))
                aEntidad.NUMEROUNIDADES = IIf(dr("NUMEROUNIDADES") Is DBNull.Value, Nothing, dr("NUMEROUNIDADES"))
                aEntidad.CANTIDADREMITIDA = IIf(dr("CANTIDADREMITIDA") Is DBNull.Value, Nothing, dr("CANTIDADREMITIDA"))
                aEntidad.ESTABLECIMIENTOREMITE = IIf(dr("ESTABLECIMIENTOREMITE") Is DBNull.Value, Nothing, dr("ESTABLECIMIENTOREMITE"))
                aEntidad.NUMERORECEPCION = IIf(dr("NUMERORECEPCION") Is DBNull.Value, Nothing, dr("NUMERORECEPCION"))
                aEntidad.GUIAAEREA = IIf(dr("GUIAAEREA") Is DBNull.Value, Nothing, dr("GUIAAEREA"))
                aEntidad.DESCRIPCIONEMPAQUE = IIf(dr("DESCRIPCIONEMPAQUE") Is DBNull.Value, Nothing, dr("DESCRIPCIONEMPAQUE"))
                aEntidad.LEYENDAREQUERIDA = IIf(dr("LEYENDAREQUERIDA") Is DBNull.Value, Nothing, dr("LEYENDAREQUERIDA"))
                aEntidad.NUMEROREGISTRO = IIf(dr("NUMEROREGISTRO") Is DBNull.Value, Nothing, dr("NUMEROREGISTRO"))
                aEntidad.VIAADMINISTRACION = IIf(dr("VIAADMINISTRACION") Is DBNull.Value, Nothing, dr("VIAADMINISTRACION"))
                aEntidad.FORMADISOLUCION = IIf(dr("FORMADISOLUCION") Is DBNull.Value, Nothing, dr("FORMADISOLUCION"))
                aEntidad.CONDICIONESALMACENAMIENTO = IIf(dr("CONDICIONESALMACENAMIENTO") Is DBNull.Value, Nothing, dr("CONDICIONESALMACENAMIENTO"))
                aEntidad.NUMEROLOTE = IIf(dr("NUMEROLOTE") Is DBNull.Value, Nothing, dr("NUMEROLOTE"))
                aEntidad.FECHAEXPIRACION = IIf(dr("FECHAEXPIRACION") Is DBNull.Value, Nothing, dr("FECHAEXPIRACION"))
                aEntidad.OTROSEMPAQUES = IIf(dr("OTROSEMPAQUES") Is DBNull.Value, Nothing, dr("OTROSEMPAQUES"))
                aEntidad.DESCRIPCIONOTROSEMPAQUES = IIf(dr("DESCRIPCIONOTROSEMPAQUES") Is DBNull.Value, Nothing, dr("DESCRIPCIONOTROSEMPAQUES"))
                aEntidad.DESCRIPCIONPRODUCTO = IIf(dr("DESCRIPCIONPRODUCTO") Is DBNull.Value, Nothing, dr("DESCRIPCIONPRODUCTO"))
                aEntidad.CANTIDADFISICOQUIMICO = IIf(dr("CANTIDADFISICOQUIMICO") Is DBNull.Value, Nothing, dr("CANTIDADFISICOQUIMICO"))
                aEntidad.CANTIDADMICROBIOLOGIA = IIf(dr("CANTIDADMICROBIOLOGIA") Is DBNull.Value, Nothing, dr("CANTIDADMICROBIOLOGIA"))
                aEntidad.CANTIDADRETENCION = IIf(dr("CANTIDADRETENCION") Is DBNull.Value, Nothing, dr("CANTIDADRETENCION"))
                aEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO = IIf(dr("DESCRIPCIONCONDICIONESALMACENAMIENTO") Is DBNull.Value, Nothing, dr("DESCRIPCIONCONDICIONESALMACENAMIENTO"))
                aEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                aEntidad.IDINSPECTOR = IIf(dr("IDINSPECTOR") Is DBNull.Value, Nothing, dr("IDINSPECTOR"))
                aEntidad.FECHAELABORACIONINFORME = IIf(dr("FECHAELABORACIONINFORME") Is DBNull.Value, Nothing, dr("FECHAELABORACIONINFORME"))
                aEntidad.IDCOORDINADOR = IIf(dr("IDCOORDINADOR") Is DBNull.Value, Nothing, dr("IDCOORDINADOR"))
                aEntidad.MOTIVOSNOINSPECCION = IIf(dr("MOTIVOSNOINSPECCION") Is DBNull.Value, Nothing, dr("MOTIVOSNOINSPECCION"))
                aEntidad.FECHACERTIFICACION = IIf(dr("FECHACERTIFICACION") Is DBNull.Value, Nothing, dr("FECHACERTIFICACION"))
                aEntidad.FECHASOLICITUDINSPECCION = IIf(dr("FECHASOLICITUDINSPECCION") Is DBNull.Value, Nothing, dr("FECHASOLICITUDINSPECCION"))
                aEntidad.FECHARECOLECCIONMUESTRA = IIf(dr("FECHARECOLECCIONMUESTRA") Is DBNull.Value, Nothing, dr("FECHARECOLECCIONMUESTRA"))
                aEntidad.OBSERVACIONCERTIFICACION = IIf(dr("OBSERVACIONCERTIFICACION") Is DBNull.Value, Nothing, dr("OBSERVACIONCERTIFICACION"))
                aEntidad.IDJEFELABORATORIO = IIf(dr("IDJEFELABORATORIO") Is DBNull.Value, Nothing, dr("IDJEFELABORATORIO"))
                aEntidad.REPRESENTANTEPROVEEDOR = IIf(dr("REPRESENTANTEPROVEEDOR") Is DBNull.Value, Nothing, dr("REPRESENTANTEPROVEEDOR"))
                aEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                aEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                aEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                aEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                aEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                aEntidad.ORIGENPRODUCTO = IIf(dr("ORIGENPRODUCTO") Is DBNull.Value, Nothing, dr("ORIGENPRODUCTO"))
                aEntidad.TIPOPRODUCTO = IIf(dr("TIPOPRODUCTO") Is DBNull.Value, Nothing, dr("TIPOPRODUCTO"))
                aEntidad.MOTIVONOACEPTACION = IIf(dr("MOTIVONOACEPTACION") Is DBNull.Value, Nothing, dr("MOTIVONOACEPTACION"))
                aEntidad.DESCRIPCIONDISOLUCION = IIf(dr("DESCRIPCIONDISOLUCION") Is DBNull.Value, Nothing, dr("DESCRIPCIONDISOLUCION"))

                aEntidad.ESTABLECIMIENTOCONTRATO = IIf(dr("ESTABLECIMIENTOCONTRATO") Is DBNull.Value, Nothing, dr("ESTABLECIMIENTOCONTRATO"))
                aEntidad.NUMEROCONTRATO = IIf(dr("NUMEROCONTRATO") Is DBNull.Value, Nothing, dr("NUMEROCONTRATO"))
                aEntidad.FECHADISTRIBUCION = IIf(dr("FECHADISTRIBUCION") Is DBNull.Value, Nothing, dr("FECHADISTRIBUCION"))
                aEntidad.CANTIDADCONTRATADA = IIf(dr("CANTIDADCONTRATADA") Is DBNull.Value, Nothing, dr("CANTIDADCONTRATADA"))
                aEntidad.NOMBREPROVEEDOR = IIf(dr("NOMBREPROVEEDOR") Is DBNull.Value, Nothing, dr("NOMBREPROVEEDOR"))
                aEntidad.UNIDADMEDIDA = IIf(dr("UNIDADMEDIDA") Is DBNull.Value, Nothing, dr("UNIDADMEDIDA"))
                aEntidad.DESCRIPCIONCP = IIf(dr("DESCLARGO") Is DBNull.Value, Nothing, dr("DESCLARGO"))
                aEntidad.DESCRIPCIONPROVEEDOR = IIf(dr("DESCRIPCIONPROVEEDOR") Is DBNull.Value, Nothing, dr("DESCRIPCIONPROVEEDOR"))
                aEntidad.INSPECTOR = IIf(dr("INSPECTOR") Is DBNull.Value, Nothing, dr("INSPECTOR"))
                aEntidad.CODIGOINSPECTOR = IIf(dr("CODIGOINSPECTOR") Is DBNull.Value, Nothing, dr("CODIGOINSPECTOR"))
                'aEntidad.COORDINADOR = IIf(dr("COORDINADOR") Is DBNull.Value, Nothing, dr("COORDINADOR"))
                'aEntidad.CODIGOCOORDINADOR = IIf(dr("CODIGOCOORDINADOR") Is DBNull.Value, Nothing, dr("CODIGOCOORDINADOR"))
                'aEntidad.JEFELABORATORIO = IIf(dr("JEFELABORATORIO") Is DBNull.Value, Nothing, dr("JEFELABORATORIO"))
                'aEntidad.CODIGOJEFELABORATORIO = IIf(dr("CODIGOJEFELABORATORIO") Is DBNull.Value, Nothing, dr("CODIGOJEFELABORATORIO"))

                aEntidad.MODALIDADCOMPRA = IIf(dr("MODALIDADCOMPRA") Is DBNull.Value, Nothing, dr("MODALIDADCOMPRA"))
                aEntidad.NUMEROMODALIDADCOMPRA = IIf(dr("NUMEROMODALIDADCOMPRA") Is DBNull.Value, Nothing, dr("NUMEROMODALIDADCOMPRA"))

                aEntidad.NUMERORESOLUCION = IIf(dr("NUMERORESOLUCION") Is DBNull.Value, Nothing, dr("NUMERORESOLUCION"))

            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return 1

    End Function

    ''' <summary>
    ''' Devuelve todos los datos del informe de muestras necesarios para el reporte.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_LAB_INFORMEMUESTRAS</item>
    ''' <item>SAB_UACI_PRODUCTOSCONTRATO</item>
    ''' <item>SAB_UACI_CONTRATOS</item>
    ''' <item>SAB_UACI_CONTRATOSPROCESOCOMPRA</item>
    ''' <item>SAB_UACI_PROCESOCOMPRAS</item>
    ''' <item>SAB_CAT_TIPOINFORMES</item>
    ''' <item>SAB_CAT_ESTABLECIMIENTOS</item>
    ''' <item>SAB_CAT_ESTABLECIMIENTOS</item>
    ''' <item>SAB_CAT_PROVEEDORES</item>
    ''' <item>SAB_CAT_MODALIDADESCOMPRA</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' <item>SAB_LAB_MOTIVOSNOACEPTACIONINFORME</item>
    ''' <item>SAB_CAT_MOTIVOSNOACEPTACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function RptInformeMuestras(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IM.IDESTABLECIMIENTO, ")
        strSQL.Append("IM.IDINFORME, ")
        strSQL.Append("IM.IDTIPOINFORME, ")
        strSQL.Append("IM.NUMEROINFORME, ")
        strSQL.Append("IM.IDESTADO, ")
        strSQL.Append("IM.IDESTABLECIMIENTOCONTRATO, ")
        strSQL.Append("IM.IDPROVEEDOR, ")
        strSQL.Append("IM.IDCONTRATO, ")
        strSQL.Append("IM.RENGLON, ")
        strSQL.Append("IM.NOMBREMEDICAMENTO, ")
        strSQL.Append("IM.NOMBRECOMERCIAL, ")
        strSQL.Append("IM.LABORATORIOFABRICANTE, ")
        strSQL.Append("IM.PROVEEDOR, ")
        strSQL.Append("IM.LOTE, ")
        strSQL.Append("convert(varchar, IM.FECHAFABRICACION, 103) FECHAFABRICACION, ")
        strSQL.Append("convert(varchar, datepart(Mm, IM.FECHAFABRICACION)) + '/' + convert(varchar, datepart(Yy, IM.FECHAFABRICACION)) FECHAFABRICACIONMMAAAA, ")
        strSQL.Append("convert(varchar, IM.FECHAVENCIMIENTO, 103) FECHAVENCIMIENTO, ")
        strSQL.Append("convert(varchar, datepart(Mm, IM.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(Yy, IM.FECHAVENCIMIENTO)) FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append("IM.NUMEROUNIDADES, ")
        strSQL.Append("IM.CANTIDADREMITIDA, ")
        strSQL.Append("IM.ESTABLECIMIENTOREMITE, ")
        strSQL.Append("IM.NUMERORECEPCION, ")
        strSQL.Append("IM.GUIAAEREA, ")
        strSQL.Append("IM.DESCRIPCIONEMPAQUE, ")
        strSQL.Append("IM.LEYENDAREQUERIDA, ")
        strSQL.Append("IM.NUMEROREGISTRO, ")
        strSQL.Append("IM.VIAADMINISTRACION, ")
        strSQL.Append("IM.FORMADISOLUCION, ")
        strSQL.Append("IM.CONDICIONESALMACENAMIENTO, ")
        strSQL.Append("IM.NUMEROLOTE, ")
        strSQL.Append("IM.FECHAEXPIRACION, ")
        strSQL.Append("IM.OTROSEMPAQUES, ")
        strSQL.Append("isnull(IM.DESCRIPCIONOTROSEMPAQUES, '') DESCRIPCIONOTROSEMPAQUES, ")
        strSQL.Append("IM.DESCRIPCIONPRODUCTO, ")
        strSQL.Append("IM.CANTIDADFISICOQUIMICO, ")
        strSQL.Append("IM.CANTIDADMICROBIOLOGIA, ")
        strSQL.Append("IM.CANTIDADRETENCION, ")
        strSQL.Append("IM.DESCRIPCIONCONDICIONESALMACENAMIENTO, ")
        strSQL.Append("IM.OBSERVACION, ")
        strSQL.Append("IM.IDINSPECTOR, ")
        strSQL.Append("convert(varchar, IM.FECHAELABORACIONINFORME, 103) FECHAELABORACIONINFORME, ")
        strSQL.Append("IM.IDCOORDINADOR, ")
        strSQL.Append("IM.MOTIVOSNOINSPECCION, ")
        strSQL.Append("IM.MOTIVONOACEPTACION, ")
        strSQL.Append("convert(varchar, IM.FECHACERTIFICACION, 103) FECHACERTIFICACION, ")
        strSQL.Append("IM.FECHASOLICITUDINSPECCION, ")
        strSQL.Append("IM.FECHARECOLECCIONMUESTRA, ")
        strSQL.Append("IM.OBSERVACIONCERTIFICACION, ")
        strSQL.Append("case IM.RESULTADOINSPECCION ")
        strSQL.Append(" when 1 then 'ACEPTADO' ")
        strSQL.Append(" when 2 then 'RECHAZADO' ")
        strSQL.Append(" else '' ")
        strSQL.Append("end RESULTADOINSPECCION, ")
        strSQL.Append("IM.IDJEFELABORATORIO, ")
        strSQL.Append("IM.REPRESENTANTEPROVEEDOR, ")
        strSQL.Append("IM.AUUSUARIOCREACION, ")
        strSQL.Append("IM.AUFECHACREACION, ")
        strSQL.Append("IM.AUUSUARIOMODIFICACION, ")
        strSQL.Append("IM.AUFECHAMODIFICACION, ")
        strSQL.Append("IM.ESTASINCRONIZADA, ")
        strSQL.Append("PC.CANTIDAD CANTIDADCONTRATADA, ")
        strSQL.Append("PC.DESCRIPCIONPROVEEDOR + ' MARCA:' + DO.MARCA + ' ORIGEN:' + DO.ORIGEN + ' VENCIMIENTO:' + DO.VENCIMIENTO DESCRIPCIONPROVEEDOR, ")
        strSQL.Append("C.NUMEROCONTRATO, ")
        strSQL.Append("MC.DESCRIPCION MODALIDADCOMPRA, ")
        strSQL.Append("C.NUMEROMODALIDADCOMPRA, ")
        strSQL.Append("PCOM.NUMERORESOLUCION, ")
        strSQL.Append("P.NOMBRE NOMBREPROVEEDOR, ")
        strSQL.Append("CP.DESCLARGO DESCRIPCIONPRODUCTOCP, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTOCONTRATO, ")
        strSQL.Append("isnull(E1.DIRECCION, '') DIRECCION, ")
        strSQL.Append("isnull(E1.TELEFONO, '') TELEFONO, ")
        strSQL.Append("isnull(E1.FAX, '') FAX, ")
        strSQL.Append("isnull(EM.NOMBRE + ' ' + EM.APELLIDO, '') INSPECTOR, ")
        strSQL.Append("isnull(EM.NOMBRECORTO, '') CODIGOINSPECTOR, ")
        strSQL.Append("isnull(EM1.NOMBRE + ' ' + EM1.APELLIDO, '') COORDINADOR, ")
        strSQL.Append("isnull(EM1.NOMBRECORTO, '') CODIGOCOORDINADOR, ")
        strSQL.Append("isnull(EM2.NOMBRE + ' ' + EM2.APELLIDO, '') JEFELABORATORIO, ")
        strSQL.Append("isnull(EM2.NOMBRECORTO, '') CODIGOJEFELABORATORIO, ")
        strSQL.Append("TI.DESCRIPCION TIPOINFORME, ")
        strSQL.Append("PCOM.TITULOLICITACION, ")
        strSQL.Append("IM.DESCRIPCIONDISOLUCION, ")
        strSQL.Append("IM.COMPROBANTECREDITOFISCAL, ")
        strSQL.Append("IM.NUMEROEMPAQUEPRIMARIO, ")
        strSQL.Append("IM.NUMEROEMPAQUESECUNDARIO, ")
        strSQL.Append("IM.DESCRIPCIONEMPAQUESECUNDARIO, ")
        strSQL.Append("IM.NUMEROEMPAQUECOLECTIVO, ")
        strSQL.Append("IM.DESCRIPCIONEMPAQUECOLECTIVO, ")
        strSQL.Append("IM.CONDICIONESALMACENAMIENTORECOMENDADAS, ")
        strSQL.Append("CASE WHEN IM.NIVELINSPECCIONUTILIZABLE = 1 THEN 'NORMAL' WHEN IM.NIVELINSPECCIONUTILIZABLE = 2 THEN  'REDUCIDO' ELSE 'RIGUROSO' END AS NIVELINSPECCIONUTILIZABLE, ")
        strSQL.Append("IM.NUMEROUNIDADESAMUESTREAR, ")
        strSQL.Append("IM.NIVELCALIDADACEPTABLE, ")
        strSQL.Append("IM.RANGOACEPTACIONRECHAZO, ")
        strSQL.Append("IM.CALCULOS, ")
        strSQL.Append("IM.LUGARINSPECCION ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON (IM.IDESTABLECIMIENTOCONTRATO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND IM.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND IM.RENGLON = PC.RENGLON) ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = CPC.IDCONTRATO) ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PCOM ")
        strSQL.Append("ON (CPC.IDESTABLECIMIENTO = PCOM.IDESTABLECIMIENTO ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = PCOM.IDPROCESOCOMPRA) ")
        strSQL.Append("inner join SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("on (do.idestablecimiento = cpc.idestablecimiento ")
        strSQL.Append("and do.idprocesocompra = cpc.idprocesocompra ")
        strSQL.Append("and do.idproveedor = pc.idproveedor ")
        strSQL.Append("and do.renglon = im.renglon) ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOINFORMES TI ")
        strSQL.Append("ON IM.IDTIPOINFORME = TI.IDTIPOINFORME ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E1 ")
        strSQL.Append("ON IM.IDESTABLECIMIENTO = E1.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON PC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_MODALIDADESCOMPRA MC ")
        strSQL.Append("ON C.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ")
        strSQL.Append("ON IM.IDINSPECTOR = EM.IDEMPLEADO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM1 ")
        strSQL.Append("ON IM.IDCOORDINADOR = EM1.IDEMPLEADO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_EMPLEADOS EM2 ")
        strSQL.Append("ON IM.IDJEFELABORATORIO = EM2.IDEMPLEADO ")
        strSQL.Append("WHERE IM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDINFORME = @IDINFORME ")

        'strSQL.Append("SELECT ")
        'strSQL.Append("MNAI.IDESTABLECIMIENTO, ")
        'strSQL.Append("MNAI.IDINFORME, ")
        'strSQL.Append("MNAI.IDMOTIVONOACEPTACION, ")
        'strSQL.Append("MNA.DESCRIPCION ")
        'strSQL.Append("FROM SAB_LAB_MOTIVOSNOACEPTACIONINFORME MNAI ")
        'strSQL.Append("INNER JOIN SAB_CAT_MOTIVOSNOACEPTACION MNA ")
        'strSQL.Append("ON MNAI.IDMOTIVONOACEPTACION = MNA.IDMOTIVONOACEPTACION ")
        'strSQL.Append("WHERE MNAI.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        'strSQL.Append("AND MNAI.IDINFORME = @IDINFORME ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = IDINFORME

        Dim tables(0) As String
        tables(0) = New String("dtInformeMuestrasAceptacion")
        ' tables(1) = New String("dtMotivosNoAceptacion")

        Dim ds As New DataSet
        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return ds

    End Function

    Public Function RptInformeMuestras2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IM.IDESTABLECIMIENTO, IM.IDINFORME, IM.IDTIPOINFORME, IM.NUMEROINFORME, IM.IDESTADO, ")
        strSQL.Append(" IM.IDESTABLECIMIENTOCONTRATO, IM.IDPROVEEDOR, IM.IDCONTRATO, IM.RENGLON, cp.corrproducto + ' ' +  IM.NOMBREMEDICAMENTO NOMBREMEDICAMENTO, ")
        strSQL.Append(" IM.NOMBRECOMERCIAL, IM.LABORATORIOFABRICANTE, IM.PROVEEDOR, IM.LOTE, convert(varchar, IM.FECHAFABRICACION, 103) FECHAFABRICACION, ")
        strSQL.Append(" convert(varchar, datepart(Mm, IM.FECHAFABRICACION)) + '/' + convert(varchar, datepart(Yy, IM.FECHAFABRICACION)) FECHAFABRICACIONMMAAAA, convert(varchar, ")
        strSQL.Append(" IM.FECHAVENCIMIENTO, 103) FECHAVENCIMIENTO, convert(varchar, datepart(Mm, IM.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(Yy, IM.FECHAVENCIMIENTO)) FECHAVENCIMIENTOMMAAAA, ")
        strSQL.Append(" IM.NUMEROUNIDADES, IM.CANTIDADREMITIDA, IM.ESTABLECIMIENTOREMITE, IM.NUMERORECEPCION, IM.GUIAAEREA, ")
        strSQL.Append(" IM.DESCRIPCIONEMPAQUE, IM.LEYENDAREQUERIDA, IM.NUMEROREGISTRO, IM.VIAADMINISTRACION, IM.FORMADISOLUCION, ")
        strSQL.Append(" IM.CONDICIONESALMACENAMIENTO, IM.NUMEROLOTE, IM.FECHAEXPIRACION, IM.OTROSEMPAQUES, isnull(IM.DESCRIPCIONOTROSEMPAQUES, '') DESCRIPCIONOTROSEMPAQUES, ")
        strSQL.Append(" IM.DESCRIPCIONPRODUCTO, IM.CANTIDADFISICOQUIMICO, IM.CANTIDADMICROBIOLOGIA, IM.CANTIDADRETENCION, ")
        strSQL.Append(" IM.DESCRIPCIONCONDICIONESALMACENAMIENTO, IM.OBSERVACION, IM.IDINSPECTOR, convert(varchar, IM.FECHAELABORACIONINFORME, 103) FECHAELABORACIONINFORME, ")
        strSQL.Append(" IM.IDCOORDINADOR, IM.MOTIVOSNOINSPECCION, IM.MOTIVONOACEPTACION, convert(varchar, IM.FECHACERTIFICACION, 103) FECHACERTIFICACION, ")
        strSQL.Append(" IM.FECHASOLICITUDINSPECCION, IM.FECHARECOLECCIONMUESTRA, IM.OBSERVACIONCERTIFICACION, ")
        strSQL.Append(" case IM.RESULTADOINSPECCION  when 1 then 'ACEPTADO'  when 2 then 'RECHAZADO'  else '' end RESULTADOINSPECCION, ")
        strSQL.Append(" IM.IDJEFELABORATORIO, IM.REPRESENTANTEPROVEEDOR, IM.AUUSUARIOCREACION, IM.AUFECHACREACION, ")
        strSQL.Append(" IM.AUUSUARIOMODIFICACION, IM.AUFECHAMODIFICACION, IM.ESTASINCRONIZADA, ")
        strSQL.Append(" PC.CANTIDAD CANTIDADCONTRATADA, PC.DESCRIPCIONPROVEEDOR +','+ ' MARCA:' + DO.MARCA +','+ ' ORIGEN:' + DO.ORIGEN +','+ ' VENCIMIENTO:' + DO.VENCIMIENTO DESCRIPCIONPROVEEDOR, ")
        strSQL.Append(" C.NUMEROCONTRATO, MC.DESCRIPCION MODALIDADCOMPRA, C.NUMEROMODALIDADCOMPRA, PCOM.NUMERORESOLUCION, ")
        strSQL.Append(" P.NOMBRE NOMBREPROVEEDOR, CP.DESCLARGO DESCRIPCIONPRODUCTOCP, CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append(" '' ESTABLECIMIENTOCONTRATO, '' DIRECCION, '' TELEFONO, ")
        strSQL.Append(" '' FAX, isnull(EM.NOMBRE + ' ' + EM.APELLIDO, '') INSPECTOR, isnull(EM.NOMBRECORTO, '') CODIGOINSPECTOR, ")
        strSQL.Append(" '' COORDINADOR, '' CODIGOCOORDINADOR, ")
        strSQL.Append(" '' JEFELABORATORIO,'' CODIGOJEFELABORATORIO, ")
        strSQL.Append(" '' as  TIPOINFORME, PCOM.TITULOLICITACION, IM.DESCRIPCIONDISOLUCION, IM.COMPROBANTECREDITOFISCAL, IM.NUMEROEMPAQUEPRIMARIO, ")
        strSQL.Append(" IM.NUMEROEMPAQUESECUNDARIO, IM.DESCRIPCIONEMPAQUESECUNDARIO, IM.NUMEROEMPAQUECOLECTIVO, IM.DESCRIPCIONEMPAQUECOLECTIVO, ")
        strSQL.Append(" IM.CONDICIONESALMACENAMIENTORECOMENDADAS, CASE WHEN IM.NIVELINSPECCIONUTILIZABLE = 1 THEN 'NORMAL' WHEN IM.NIVELINSPECCIONUTILIZABLE = 2 THEN  'REDUCIDO' ELSE 'RIGUROSO' END AS NIVELINSPECCIONUTILIZABLE, ")
        strSQL.Append(" IM.NUMEROUNIDADESAMUESTREAR, IM.NIVELCALIDADACEPTABLE, IM.RANGOACEPTACIONRECHAZO, IM.CALCULOS, IM.LUGARINSPECCION, IM.OBSERVACIONLEYENDA, IM.OBSERVACIONNREGISTRO, IM.OBSERVACIONVIAADMON,IM.OBSERVACIONCONDIALMA,IM.OBSERVACIONNLOTE, IM.OBSERVACIONFECHAEXP, IM.FECHANOTIFICACION, DO.numerocssp, im.nombreinspeccion ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS IM INNER JOIN ")
        strSQL.Append(" SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append(" ON (IM.IDESTABLECIMIENTOCONTRATO = PC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" IM.IDPROVEEDOR = PC.IDPROVEEDOR AND ")
        strSQL.Append(" IM.IDCONTRATO = PC.IDCONTRATO AND ")
        strSQL.Append(" IM.RENGLON = PC.RENGLON) ")
        strSQL.Append(" INNER JOIN SAB_UACI_CONTRATOS C ON ")
        strSQL.Append(" (PC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        strSQL.Append(" PC.IDPROVEEDOR = C.IDPROVEEDOR AND ")
        strSQL.Append(" PC.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append(" INNER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
        strSQL.Append(" (PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" PC.IDPROVEEDOR = CPC.IDPROVEEDOR AND ")
        strSQL.Append(" PC.IDCONTRATO = CPC.IDCONTRATO) ")
        strSQL.Append(" INNER JOIN SAB_UACI_PROCESOCOMPRAS PCOM ON ")
        strSQL.Append(" (IM.IDESTABLECIMIENTOCONTRATO = PCOM.IDESTABLECIMIENTO AND ")
        strSQL.Append(" IM.IDPROCESOCOMPRA = PCOM.IDPROCESOCOMPRA) ")
        strSQL.Append(" inner join SAB_UACI_DETALLEOFERTA DO on ")
        strSQL.Append(" (do.idestablecimiento = cpc.idestablecimiento and ")
        strSQL.Append(" do.idprocesocompra = cpc.idprocesocompra and ")
        strSQL.Append(" do.idproveedor = pc.idproveedor and ")
        strSQL.Append(" do.renglon = im.renglon) ")
        strSQL.Append(" INNER JOIN SAB_CAT_PROVEEDORES P ON PC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append(" LEFT OUTER JOIN SAB_CAT_MODALIDADESCOMPRA MC ON C.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append(" INNER JOIN vv_CATALOGOPRODUCTOS CP ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" INNER JOIN SAB_CAT_EMPLEADOS EM ON IM.IDINSPECTOR = EM.IDEMPLEADO ")
        strSQL.Append(" WHERE IM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IM.IDINFORME = @IDINFORME ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = IDINFORME

        Dim tables(0) As String
        tables(0) = New String("dtInformeMuestrasAceptacion")
        ' tables(1) = New String("dtMotivosNoAceptacion")

        Dim ds As New DataSet
        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return ds

    End Function

    ''' <summary>
    ''' Para un renglón dado, obtiene todos los lotes que se han inspeccionado, certificado y aceptado para su recepción.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_LAB_INFORMEMUESTRAS</item>
    ''' <item>SAB_UACI_CANCELACIONLOTE</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerLotesCancelacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IM.LOTE, ")
        strSQL.Append("isnull(CL.ESTAHABILITADO, 1) ESTAHABILITADO ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_CANCELACIONLOTE CL ")
        strSQL.Append("ON (IM.IDESTABLECIMIENTOCONTRATO = CL.IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDPROVEEDOR = CL.IDPROVEEDOR ")
        strSQL.Append("AND IM.IDCONTRATO = CL.IDCONTRATO ")
        strSQL.Append("AND IM.RENGLON = CL.RENGLON ")
        strSQL.Append("AND IM.LOTE = CL.LOTE) ")
        strSQL.Append("WHERE IM.IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IM.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND IM.RENGLON = @RENGLON ")
        strSQL.Append("AND IM.IDTIPOINFORME = 1 ")
        strSQL.Append("AND IM.IDESTADO = 3 ")
        strSQL.Append("AND IM.RESULTADOINSPECCION = 1 ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Verifica si el número de informe indicado ya ha sido utilizado.
    ''' </summary>
    ''' <param name="NUMEROINFORME">Número de informe a verificar.</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del informe.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_LAB_INFORMEMUESTRAS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function VerificarNumeroInforme(ByVal NUMEROINFORME As String, ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(NUMEROINFORME) ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("WHERE NUMEROINFORME = @NUMEROINFORME ")
        strSQL.Append("AND ((NOT ")
        strSQL.Append("      (IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("       AND IDINFORME = @IDINFORME)) ")
        strSQL.Append("     OR @IDINFORME = 0) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@NUMEROINFORME", SqlDbType.VarChar)
        args(0).Value = NUMEROINFORME
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(2).Value = IDINFORME

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene todas las modificativas del contrato asociado al informe de muestras.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del informe.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>String.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_MODIFICATIVASCONTRATO</item>
    ''' <item>SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO</item>
    ''' <item>SAB_LAB_INFORMEMUESTRAS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerModificativas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT MC.NUMEROMODIFICATIVA ")
        strSQL.Append("FROM SAB_UACI_MODIFICATIVASCONTRATO MC ")
        strSQL.Append("INNER JOIN SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO MCP ")
        strSQL.Append("ON (MC.IDESTABLECIMIENTO = MCP.IDESTABLECIMIENTO ")
        strSQL.Append("AND MC.IDPROVEEDOR = MCP.IDPROVEEDOR ")
        strSQL.Append("AND MC.IDCONTRATO = MCP.IDCONTRATO ")
        strSQL.Append("AND MC.IDMODIFICATIVA = MCP.IDMODIFICATIVA) ")
        strSQL.Append("INNER JOIN SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("ON (MCP.IDESTABLECIMIENTO = IM.IDESTABLECIMIENTOCONTRATO ")
        strSQL.Append("AND MCP.IDPROVEEDOR = IM.IDPROVEEDOR ")
        strSQL.Append("AND MCP.IDCONTRATO = IM.IDCONTRATO ")
        strSQL.Append("AND MCP.RENGLON = IM.RENGLON) ")
        strSQL.Append("WHERE IM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDINFORME = @IDINFORME ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = IDINFORME

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim s As New Text.StringBuilder

        Try
            If dr.HasRows Then
                dr.Read()
                s.Append(dr("NUMEROMODIFICATIVA").ToString)

                Do While dr.Read()
                    s.Append(", ")
                    s.Append(dr("NUMEROMODIFICATIVA").ToString)
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return s.ToString

    End Function

    Public Function ObtenerFechasRemision(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal NUMEROINFORME As String = "", Optional ByVal IDTIPOINFOME As Integer = 0, Optional ByVal RESULTADOINSPECCION As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDESTABLECIMIENTO, IDINFORME, ")
        strSQL.Append("NUMEROINFORME, ")
        strSQL.Append("CASE IDTIPOINFORME WHEN 1 THEN 'Aceptado' WHEN 2 THEN 'Rechazado' WHEN 3 THEN 'No Inspección' ELSE '' END TIPOINFORME, ")
        strSQL.Append("CASE RESULTADOINSPECCION WHEN 1 THEN 'Aceptado' WHEN 2 THEN 'Rechazado' ELSE '' END RESULTADO, ")
        strSQL.Append("CASE isnull(FECHAREMISION,1) WHEN 1 THEN 'Pendiente' ELSE convert(varchar(10),FECHAREMISION,103) END FECHAREMISION, FECHACERTIFICACION, PROVEEDOR ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS ")
        If NUMEROINFORME = "" And IDTIPOINFOME = 0 And RESULTADOINSPECCION = 0 Then
            strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDESTADO = 6 ")
            strSQL.Append("ORDER BY FECHACERTIFICACION ")
        End If
        If NUMEROINFORME <> "" Then
            strSQL.Append("WHERE NUMEROINFORME like '%" & NUMEROINFORME & "%' AND IDESTADO = 6 ")
            strSQL.Append("ORDER BY FECHACERTIFICACION ")
        End If
        If IDTIPOINFOME <> 0 Then
            strSQL.Append("WHERE IDTIPOINFORME = @IDTIPOINFORME AND IDESTADO = 6 ")
            strSQL.Append("ORDER BY FECHACERTIFICACION ")
        End If
        If RESULTADOINSPECCION <> 0 Then
            strSQL.Append("WHERE resultadoinspeccion = @resultadoinspeccion AND IDESTADO = 6 ")
            strSQL.Append("ORDER BY FECHACERTIFICACION ")
        End If

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        If NUMEROINFORME <> "" Then
            args(1) = New SqlParameter("@NUMEROINFORME", SqlDbType.Text)
            args(1).Value = NUMEROINFORME
        End If
        If IDTIPOINFOME <> 0 Then
            args(1) = New SqlParameter("@IDTIPOINFORME", SqlDbType.Int)
            args(1).Value = IDTIPOINFOME
        End If
        If RESULTADOINSPECCION <> 0 Then
            args(1) = New SqlParameter("@resultadoinspeccion", SqlDbType.Int)
            args(1).Value = RESULTADOINSPECCION
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerFechasRemision2(ByVal IDESTABLECIMIENTOCONTRATO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDESTABLECIMIENTO, IDINFORME, ")
        strSQL.Append("NUMEROINFORME, ")
        strSQL.Append("CASE IDTIPOINFORME WHEN 1 THEN 'Aceptado' WHEN 2 THEN 'Rechazado' WHEN 3 THEN 'No Inspección' ELSE '' END TIPOINFORME, ")
        strSQL.Append("CASE RESULTADOINSPECCION WHEN 1 THEN 'Aceptado' WHEN 2 THEN 'Rechazado' ELSE '' END RESULTADO, ")
        strSQL.Append("CASE isnull(FECHAREMISION,1) WHEN 1 THEN 'Pendiente' ELSE convert(varchar(10),FECHAREMISION,103) END FECHAREMISION, ")
        strSQL.Append("FECHACERTIFICACION, ")
        strSQL.Append("PROVEEDOR, ")
        strSQL.Append("CASE isnull(FECHANOTIPROV ,1) WHEN 1 THEN 'Pendiente' ELSE convert(varchar(10),FECHANOTIPROV,103) END FECHANOTIPROV, ")
        strSQL.Append("FECHANOTIFICACION, ")
        strSQL.Append("RENGLON, ")
        strSQL.Append("LOTE ")
        'strSQL.Append("FECHANOTIPROV ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("WHERE ")
        strSQL.Append("IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO AND IDESTADO = 6 ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND (IDCONTRATO = @IDCONTRATO OR IDCONTRATO IS NULL) AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("ORDER BY FECHAREMISION ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTOCONTRATO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(3).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function

    Public Function ActualizarFechasRemision(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer, ByVal FECHAREMISION As Date) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE   SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("SET FECHAREMISION = @FECHAREMISION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDINFORME = @IDINFORME ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = IDINFORME
        args(2) = New SqlParameter("@FECHAREMISION", SqlDbType.DateTime)
        args(2).Value = FECHAREMISION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarFechaNotiProv(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer, ByVal FECHANOTIPROV As Date) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE   SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("SET FECHANOTIPROV = @FECHANOTIPROV ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDINFORME = @IDINFORME ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = IDINFORME
        args(2) = New SqlParameter("@FECHANOTIPROV", SqlDbType.DateTime)
        args(2).Value = FECHANOTIPROV

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function RecuperarProveedores() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT ")
        strSQL.Append(" IM.IDPROVEEDOR, ")
        strSQL.Append(" IM.PROVEEDOR ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS IM ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function RecuperarContratos() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("C.IDCONTRATO, ")
        strSQL.Append("C.NUMEROCONTRATO ")
        strSQL.Append("FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("ON (IM.IDESTABLECIMIENTOCONTRATO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("AND IM.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("AND IM.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("AND IM.RENGLON = PC.RENGLON) ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON (PC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = C.IDCONTRATO) ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function RecuperarCompras() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT distinct PCOM.IDPROCESOCOMPRA, ")
        strSQL.Append(" isnull(MC.DESCRIPCION, '') MODALIDADCOMPRA, ")
        strSQL.Append("       isnull(C.NUMEROMODALIDADCOMPRA, 0) NUMEROMODALIDADCOMPRA ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("        INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("        ON (IM.IDESTABLECIMIENTOCONTRATO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("        AND IM.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("        AND IM.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("        AND IM.RENGLON = PC.RENGLON) ")
        strSQL.Append("        INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("        ON (PC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("        AND PC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("        AND PC.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append("        LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("        ON (PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("        AND PC.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("        AND PC.IDCONTRATO = CPC.IDCONTRATO) ")
        strSQL.Append("        LEFT OUTER JOIN SAB_UACI_PROCESOCOMPRAS PCOM ")
        strSQL.Append("        ON (CPC.IDESTABLECIMIENTO = PCOM.IDESTABLECIMIENTO ")
        strSQL.Append("        AND CPC.IDPROCESOCOMPRA = PCOM.IDPROCESOCOMPRA) ")
        strSQL.Append("       LEFT OUTER JOIN SAB_CAT_MODALIDADESCOMPRA MC ")
        strSQL.Append("        ON C.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append(" WHERE PCOM.IDESTADOPROCESOCOMPRA >= 10 ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function RecuperarLotes() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append(" IM.IDINFORME, ")
        strSQL.Append(" IM.LOTE ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS IM ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function RecuperarProducto() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append(" IM.IDINFORME, ")
        strSQL.Append(" IM.NOMBREMEDICAMENTO ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS IM ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ConsultaInformes(ByVal idestablecimiento As Integer, Optional ByVal origenproducto As Int16 = 2, Optional ByVal tipoproducto As Int16 = 3, Optional ByVal idproveedor As Integer = 0, Optional ByVal idcontrato As String = "", Optional ByVal numeromodalidadcompra As String = "", Optional ByVal idtipoinforme As Int16 = 0, Optional ByVal lote As String = "", Optional ByVal nombremedicamento As String = "", Optional ByVal resultadoinspeccion As Int16 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append(" CASE IM.ORIGENPRODUCTO WHEN 1 THEN 'E' WHEN 0 THEN 'N' ELSE '' END ORIGENPRODUCTO, ")
        strSQL.Append(" CASE IM.TIPOPRODUCTO WHEN 0 THEN 'M' WHEN 1 THEN 'V' WHEN 2 THEN 'I' ELSE '' END TIPOPRODUCTO, ")
        strSQL.Append(" 		IM.RENGLON, ")
        strSQL.Append(" IM.NOMBREMEDICAMENTO, ")
        strSQL.Append(" IM.PROVEEDOR, ")
        strSQL.Append("  isnull(MC.DESCRIPCION, '') + ': ' + isnull(C.NUMEROMODALIDADCOMPRA, 0) NUMEROMODALIDADCOMPRA, ")
        strSQL.Append("  isnull(PCOM.NUMERORESOLUCION, '') NUMERORESOLUCION, ")
        strSQL.Append("  C.NUMEROCONTRATO, ")
        strSQL.Append("          IM.LOTE, ")
        strSQL.Append(" CONVERT(VARCHAR(10), month(IM.FECHAVENCIMIENTO))+ '/'+ CONVERT(VARCHAR(10), year(IM.FECHAVENCIMIENTO)) FECHAVENCIMIENTO, ")
        strSQL.Append(" IM.LABORATORIOFABRICANTE, ")
        strSQL.Append(" CASE IM.CANTIDADFISICOQUIMICO WHEN 0 THEN '' ELSE '*' END CANTIDADFISICOQUIMICO, ")
        strSQL.Append(" CASE IM.CANTIDADMICROBIOLOGIA WHEN 0 THEN '' ELSE '*' END CANTIDADMICROBIOLOGIA, ")
        strSQL.Append(" CASE IM.CANTIDADRETENCION WHEN 0 THEN '' ELSE '*' END CANTIDADRETENCION, ")
        strSQL.Append(" CONVERT(VARCHAR(10),IM.FECHAELABORACIONINFORME,103) FECHAELABORACIONINFORME, ")
        strSQL.Append(" IM.NUMEROINFORME, ")
        strSQL.Append(" CASE IM.IDTIPOINFORME WHEN 1 THEN 'Aceptado' WHEN 2 THEN 'Rechazo' WHEN 3 THEN 'Ni inspección' ELSE '' END IDTIPOINFORME, ")
        strSQL.Append(" CASE IM.IDESTADO WHEN 1 THEN 'Registrado' WHEN 2 THEN 'En revisión' WHEN 3 THEN 'Certificado' ELSE '' END ESTADO, ")
        strSQL.Append("   isnull(EM.NOMBRE + ' ' + EM.APELLIDO, '') INSPECTOR, ")
        strSQL.Append(" CASE IM.RESULTADOINSPECCION WHEN 1 THEN 'Aceptado' when 2 then 'Rechazo' else '' end RESULTADOINSPECCION, ")
        strSQL.Append("  isnull(IM.MOTIVONOACEPTACION,'') MOTIVONOACEPTACION, ")
        strSQL.Append(" CONVERT(VARCHAR(10),IM.FECHAREMISION,103) FECHAREMISION,")
        strSQL.Append(" 		IM.IDPROVEEDOR, ")
        strSQL.Append(" 		IM.IDCONTRATO, ")
        strSQL.Append(" 		CONVERT(VARCHAR(10),IM.FECHANOTIFICACION,103) FECHANOTIFICACION, ")
        strSQL.Append(" 		IM.CANTIDADAENTREGAR, ")
        strSQL.Append(" 		IM.OBSERVACION ")
        strSQL.Append("  FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append("         INNER JOIN SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("         ON (IM.IDESTABLECIMIENTOCONTRATO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("         AND IM.IDPROVEEDOR = PC.IDPROVEEDOR ")
        strSQL.Append("         AND IM.IDCONTRATO = PC.IDCONTRATO ")
        strSQL.Append("         AND IM.RENGLON = PC.RENGLON) ")
        strSQL.Append("         INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("         ON (PC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("         AND PC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("         AND PC.IDCONTRATO = C.IDCONTRATO) ")
        strSQL.Append("         LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ")
        strSQL.Append("         ON (PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("         AND PC.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("         AND PC.IDCONTRATO = CPC.IDCONTRATO) ")
        strSQL.Append("         LEFT OUTER JOIN SAB_UACI_PROCESOCOMPRAS PCOM ")
        strSQL.Append("         ON (CPC.IDESTABLECIMIENTO = PCOM.IDESTABLECIMIENTO ")
        strSQL.Append("         AND CPC.IDPROCESOCOMPRA = PCOM.IDPROCESOCOMPRA) ")
        strSQL.Append("         INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("         ON PC.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("         INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("         ON PC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("         LEFT OUTER JOIN SAB_CAT_MODALIDADESCOMPRA MC ")
        strSQL.Append("         ON C.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append("         INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("         ON PC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("         INNER JOIN SAB_CAT_EMPLEADOS EM ")
        strSQL.Append("         ON IM.IDINSPECTOR = EM.IDEMPLEADO ")
        strSQL.Append(" WHERE IM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        If origenproducto <> 2 Then
            strSQL.Append(" and IM.origenproducto = @origenproducto ")
        End If
        If tipoproducto <> 3 Then
            strSQL.Append(" and IM.tipoproducto = @tipoproducto ")
        End If
        If idproveedor <> 0 Then
            strSQL.Append(" and IM.idproveedor = @idproveedor ")
        End If
        If idcontrato <> "" Then
            strSQL.Append(" and C.numerocontrato = @idcontrato ")
        End If
        If numeromodalidadcompra <> "" Then
            strSQL.Append(" and c.numeromodalidadcompra = @numeromodalidadcompra ")
        End If
        If idtipoinforme <> 0 Then
            strSQL.Append(" and im.idtipoinforme = @idtipoinforme ")
        End If
        If lote <> "" Then
            strSQL.Append(" and im.lote = @lote ")
        End If
        If nombremedicamento <> "" Then
            strSQL.Append(" and im.nombremedicamento = @nombremedicamento ")
        End If
        If resultadoinspeccion <> 0 Then
            strSQL.Append(" and im.resultadoinspeccion = @resultadoinspeccion ")
        End If

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        If origenproducto <> 2 Then
            args(1) = New SqlParameter("@origenproducto", SqlDbType.Int)
            args(1).Value = origenproducto
        End If
        If tipoproducto <> 3 Then
            args(2) = New SqlParameter("@tipoproducto", SqlDbType.Int)
            args(2).Value = tipoproducto
        End If
        If idproveedor <> 0 Then
            args(3) = New SqlParameter("@idproveedor", SqlDbType.Int)
            args(3).Value = idproveedor
        End If
        If idcontrato <> "" Then
            args(4) = New SqlParameter("@idcontrato", SqlDbType.VarChar)
            args(4).Value = idcontrato
        End If
        If numeromodalidadcompra <> "" Then
            args(5) = New SqlParameter("@numeromodalidadcompra", SqlDbType.VarChar)
            args(5).Value = numeromodalidadcompra
        End If
        If idtipoinforme <> 0 Then
            args(6) = New SqlParameter("@idtipoinforme", SqlDbType.Int)
            args(6).Value = idtipoinforme
        End If
        If lote <> "" Then
            args(7) = New SqlParameter("@lote", SqlDbType.VarChar)
            args(7).Value = lote
        End If
        If nombremedicamento <> "" Then
            args(8) = New SqlParameter("@nombremedicamento", SqlDbType.VarChar)
            args(8).Value = nombremedicamento
        End If
        If resultadoinspeccion <> 0 Then
            args(9) = New SqlParameter("@resultadoinspeccion", SqlDbType.Int)
            args(9).Value = resultadoinspeccion
        End If

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerLotesNotificados(ByVal idestablecimiento As Integer, ByVal idproveedor As Integer, ByVal renglon As Integer, ByVal idprocesocompra As Integer, Optional ByVal idcontrato As Integer = 0, Optional ByVal IDINSPECTOR As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select * ")
        strSQL.Append(" from SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append(" where ")
        strSQL.Append(" NUMEROINFORME IS NULL AND ")
        strSQL.Append(" IDPROVEEDOR = @IDPROVEEDOR AND ")
        strSQL.Append("  IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO AND ")
        strSQL.Append(" RENGLON = @RENGLON AND ")
        strSQL.Append(" IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        If idcontrato <> 0 Then
            strSQL.Append(" AND IDCONTRATO = @IDCONTRATO	 ")
        End If
        If IDINSPECTOR <> 0 Then
            strSQL.Append(" AND IDINSPECTOR = @IDINSPECTOR	 ")
        End If

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = idprocesocompra
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = renglon
        args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(3).Value = idproveedor
        If idcontrato <> 0 Then
            args(4) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
            args(4).Value = idcontrato
        End If
        If IDINSPECTOR <> 0 Then
            args(5) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
            args(5).Value = IDINSPECTOR
        End If

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerLotesNotificadosXInspector(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDINSPECTOR As Integer, ByVal IDPROCESOCOMPRA As Integer, Optional ByVal IDCONTRATO As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IM.*, ")
        strSQL.Append(" ISNULL(IDINSPECTOR,0) IDINSPECTOR1, ")
        strSQL.Append(" CP.CORRPRODUCTO, CP.DESCLARGO ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append(" INNER JOIN  vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append(" ON IM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append(" IM.NUMEROINFORME IS NULL ")
        strSQL.Append(" AND IM.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IM.IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IM.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IM.IDINSPECTOR = @IDINSPECTOR ") 'OR IM.IDINSPECTOR IS NULL) ")
        strSQL.Append(" AND (IM.IDCONTRATO = @IDCONTRATO OR @IDCONTRATO = 0) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
        args(2).Value = IDINSPECTOR
        args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(3).Value = IDPROVEEDOR
        args(4) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(4).Value = IDCONTRATO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerLotesNotificadosSinInspector(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPROCESOCOMPRA As Integer, Optional ByVal IDCONTRATO As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IM.*, ")
        strSQL.Append(" ISNULL(IDINSPECTOR,0) IDINSPECTOR1, ")
        strSQL.Append(" CP.CORRPRODUCTO, CP.DESCLARGO ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append(" INNER JOIN  vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append(" ON IM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append(" IM.NUMEROINFORME IS NULL ")
        strSQL.Append(" AND IM.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IM.IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IM.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IM.IDINSPECTOR IS NULL ")
        strSQL.Append(" AND (IM.IDCONTRATO = @IDCONTRATO OR @IDCONTRATO = 0) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(3).Value = IDCONTRATO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarInspector(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer, ByVal IDINSPECTOR As Integer, ByVal AUUSUARIOMODIFICACION As String, ByVal OBSERVACIONASIGNACION As String, ByVal FECHAASIGNACION As DateTime) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" UPDATE SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append(" SET IDINSPECTOR = @IDINSPECTOR, ")
        strSQL.Append(" OBSERVACIONASIGNACION = @OBSERVACIONASIGNACION, ")
        strSQL.Append(" FECHAASIGNACION = @FECHAASIGNACION, ")
        strSQL.Append("	AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("	AUFECHAMODIFICACION = getdate() ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("	IDINFORME = @IDINFORME ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = IDINFORME
        args(2) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
        args(2).Value = IIf(IDINSPECTOR = 0, DBNull.Value, IDINSPECTOR)
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = AUUSUARIOMODIFICACION
        args(4) = New SqlParameter("@OBSERVACIONASIGNACION", SqlDbType.VarChar)
        args(4).Value = OBSERVACIONASIGNACION
        args(5) = New SqlParameter("@FECHAASIGNACION", SqlDbType.DateTime)
        args(5).Value = FECHAASIGNACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerRptCuadroAsignacion(ByVal IDESTABLECIMIENTOCONTRATO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select IM.PROVEEDOR,IM.FECHANOTIFICACION,IM.RENGLON,IM.NOMBREMEDICAMENTO,IM.LOTE,IM.FECHAFABRICACION,IM.FECHAVENCIMIENTO,IM.NUMEROUNIDADES,IM.CANTIDADAENTREGAR,IM.IDINFORME,IM.IDINSPECTOR, E.NOMBRE + ' ' + E.APELLIDO AS NOMBREINSPECTOR, PC.CODIGOLICITACION, CP.DESCRIPCION AS UM ")
        strSQL.Append(" from SAB_LAB_INFORMEMUESTRAS IM INNER JOIN SAB_CAT_EMPLEADOS E ON ")
        strSQL.Append(" IM.IDINSPECTOR = E.IDEMPLEADO ")
        strSQL.Append(" LEFT OUTER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append(" ON PC.IDESTABLECIMIENTO = IM.IDESTABLECIMIENTOCONTRATO ")
        strSQL.Append(" AND PC.IDPROCESOCOMPRA = IM.IDPROCESOCOMPRA ")
        strSQL.Append(" INNER JOIN vv_CATALOGOPRODUCTOS CP ON IM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE IM.NUMEROINFORME IS NULL AND IM.IDINSPECTOR IS NOT NULL AND IM.IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTOCONTRATO AND IM.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ORDER BY NOMBREINSPECTOR, IM.PROVEEDOR,RENGLON ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTOCONTRATO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTOCONTRATO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerLotesNotificadosRetiro(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDINSPECTOR As Integer, ByVal IDPROCESOCOMPRA As Integer, Optional ByVal IDCONTRATO As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IM.*, ")
        strSQL.Append(" ISNULL(IDINSPECTOR,0) IDINSPECTOR1, ")
        strSQL.Append(" CP.CORRPRODUCTO, CP.DESCLARGO ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS IM ")
        strSQL.Append(" INNER JOIN  vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append(" ON IM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append(" IM.NUMEROINFORME IS NULL ")
        strSQL.Append(" AND IM.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IM.IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IM.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IM.IDINSPECTOR = @IDINSPECTOR ")
        strSQL.Append(" AND (IM.IDCONTRATO = @IDCONTRATO OR @IDCONTRATO = 0) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
        args(2).Value = IDINSPECTOR
        args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(3).Value = IDPROVEEDOR
        args(4) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(4).Value = IDCONTRATO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerRptRetiroMuestras(ByVal IDESTABLECIMIENTOCONTRATO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDINSPECTOR As Integer, ByVal IDPROVEEDOR As Integer, ByVal NI As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select IM.PROVEEDOR,IM.FECHANOTIFICACION,IM.RENGLON,IM.NOMBREMEDICAMENTO,IM.LOTE,IM.FECHAFABRICACION,IM.FECHAVENCIMIENTO,IM.NUMEROUNIDADES,IM.CANTIDADAENTREGAR,IM.IDINFORME,IM.IDINSPECTOR, E.NOMBRE + ' ' + E.APELLIDO AS NOMBREINSPECTOR, PC.CODIGOLICITACION, CP.DESCRIPCION AS UM, IM.NUMERONOTIFICACION ")
        strSQL.Append(" from SAB_LAB_INFORMEMUESTRAS IM INNER JOIN SAB_CAT_EMPLEADOS E ON ")
        strSQL.Append(" IM.IDINSPECTOR = E.IDEMPLEADO ")
        strSQL.Append(" LEFT OUTER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append(" ON PC.IDESTABLECIMIENTO = IM.IDESTABLECIMIENTOCONTRATO ")
        strSQL.Append(" AND PC.IDPROCESOCOMPRA = IM.IDPROCESOCOMPRA ")
        strSQL.Append(" INNER JOIN vv_CATALOGOPRODUCTOS CP ON IM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE IM.NUMEROINFORME IS NULL AND IM.IDINSPECTOR = @IDINSPECTOR AND IM.IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTOCONTRATO AND IM.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND IM.IDPROVEEDOR = @IDPROVEEDOR AND IM.NUMERONOTIFICACION = @NI ORDER BY NOMBREINSPECTOR, IM.PROVEEDOR,RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTOCONTRATO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTOCONTRATO
        args(2) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
        args(2).Value = IDINSPECTOR
        args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(3).Value = IDPROVEEDOR
        args(4) = New SqlParameter("@NI", SqlDbType.Int)
        args(4).Value = NI

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerNumeroNotificacion(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTOCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ISNULL(MAX(NUMERONOTIFICACION),0) + 1 ")
        strSQL.Append(" FROM SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append(" WHERE ")
        strSQL.Append(" IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTOCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTOCONTRATO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTOCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(3).Value = IDCONTRATO
        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerNotificacionesCapturadas(ByVal estado As Integer, ByVal inspector As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT IM.NUMERONOTIFICACION, IM.FECHANOTIFICACION, A.IDPROVEEDOR, P.NOMBRE, isnull(C.NUMEROCONTRATO,'Pendiente') as NUMEROCONTRATO, ISNULL(C.IDCONTRATO,0) AS IDCONTRATO, A.IDESTABLECIMIENTO, PC.CODIGOLICITACION + ' - ' + PC.TITULOLICITACION AS PC, PC.IDPROCESOCOMPRA,PC.CODIGOLICITACION + ' - ' + PC.TITULOLICITACION AS PC, PC.IDPROCESOCOMPRA, PC.CODIGOLICITACION AS NUMPC,   E.NOMBRE AS ESTABLECIMIENTO, IM.FECHAASIGNACION,IM.OBSERVACIONASIGNACION, IM.IDINSPECTOR ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" INNER JOIN SAB_CAT_PROVEEDORES P ON ")
        strSQL.Append(" A.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append(" INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ON ")
        strSQL.Append(" E.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
        strSQL.Append(" LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
        strSQL.Append(" A.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" A.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA AND ")
        strSQL.Append(" A.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append(" LEFT OUTER JOIN SAB_UACI_PROCESOCOMPRAS PC  ON ")
        strSQL.Append(" A.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" A.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append(" LEFT OUTER JOIN SAB_UACI_CONTRATOS C ON ")
        strSQL.Append(" C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" C.IDPROVEEDOR = CPC.IDPROVEEDOR AND ")
        strSQL.Append(" C.IDCONTRATO = CPC.IDCONTRATO ")
        strSQL.Append(" INNER JOIN SAB_LAB_INFORMEMUESTRAS IM ON ")
        strSQL.Append(" P.IDPROVEEDOR = IM.IDPROVEEDOR AND ")
        strSQL.Append(" CPC.IDESTABLECIMIENTO = IM.IDESTABLECIMIENTOCONTRATO  AND ")
        strSQL.Append(" CPC.IDPROCESOCOMPRA = IM.IDPROCESOCOMPRA ")
        strSQL.Append(" WHERE A.CANTIDADFIRME > 0 AND ")
        strSQL.Append(" IM.NUMEROINFORME IS NULL ")
        'strSQL.Append(" AND IM.IDINSPECTOR IS NULL ")
        strSQL.Append(" AND (IM.IDESTADO = @ESTADO OR @ESTADO = 0) ")
        strSQL.Append(" AND ((IM.IDINSPECTOR = @IDINSPECTOR AND @IDINSPECTOR > 0) OR (IM.IDINSPECTOR IS NULL AND @IDINSPECTOR = 0) OR (@IDINSPECTOR < 0)) ")
        strSQL.Append(" ORDER BY IM.FECHANOTIFICACION DESC ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(0).Value = estado
        args(1) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
        args(1).Value = inspector
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(3).Value = IDCONTRATO
        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerLotesRegistroNotificacion(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTOCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal NUMERONOTIFICACION As Integer, ByVal IDESTADO As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select IM.*, DESCRIPCION AS UNIDAD_MEDIDA, CORRPRODUCTO AS CODIGOPRODUCTO, DESCLARGO AS DESCRIPCIONPRODUCTO, ISNULL(IM.IDINSPECTOR,0) AS IDINSPECTOR1, ")
        strSQL.Append(" isnull(convert(varchar, datepart(month, IM.FECHAVENCIMIENTO)) + '/' + convert(varchar, datepart(year, IM.FECHAVENCIMIENTO)), '') FECHAVENCIMIENTO2, isnull(convert(varchar, datepart(month, IM.FECHAFABRICACION)) + '/' + convert(varchar, datepart(year, IM.FECHAFABRICACION)), '') FECHAFABRICACION2 ")
        strSQL.Append(" from SAB_LAB_INFORMEMUESTRAS IM INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS cp ON IM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append(" IM.IDPROVEEDOR = @IDPROVEEDOR AND ")
        strSQL.Append(" IM.IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO AND ")
        strSQL.Append(" IM.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND ")
        strSQL.Append(" IM.NUMERONOTIFICACION = @NUMERONOTIFICACION AND ")
        strSQL.Append(" IM.IDESTADO = @IDESTADO ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTOCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@NUMERONOTIFICACION", SqlDbType.Int)
        args(3).Value = NUMERONOTIFICACION
        args(4) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(4).Value = IDESTADO
        args(5) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(5).Value = IDCONTRATO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarEstado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal NUMERONOTIFICACION As Integer, ByVal AUUSUARIOMODIFICACION As String, ByVal AUFECHAMODIFICACION As Date, ByVal IDESTADO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE   SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("SET IDESTADO = @IDESTADO, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND IDPROVEEDOR = @IDPROVEEDOR AND NUMERONOTIFICACION = @NUMERONOTIFICACION ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@NUMERONOTIFICACION", SqlDbType.Int)
        args(3).Value = NUMERONOTIFICACION
        args(4) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(4).Value = AUUSUARIOMODIFICACION
        args(5) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(5).Value = AUFECHAMODIFICACION
        args(6) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(6).Value = IDESTADO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function BorrarAsignacionesInspectores(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal NUMERONOTIFICACION As Integer, ByVal AUUSUARIOMODIFICACION As String, ByVal AUFECHAMODIFICACION As Date) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE   SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("SET IDINSPECTOR = NULL, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTOCONTRATO = @IDESTABLECIMIENTO AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND IDPROVEEDOR = @IDPROVEEDOR AND NUMERONOTIFICACION = @NUMERONOTIFICACION ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@NUMERONOTIFICACION", SqlDbType.Int)
        args(3).Value = NUMERONOTIFICACION
        args(4) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(4).Value = AUUSUARIOMODIFICACION
        args(5) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(5).Value = AUFECHAMODIFICACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerHojaCalculo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select IM.*, DESCRIPCION AS UNIDAD_MEDIDA, CORRPRODUCTO AS CODIGOPRODUCTO, DESCLARGO AS DESCRIPCIONPRODUCTO, ISNULL(IM.IDINSPECTOR,0) AS IDINSPECTOR1 ")
        strSQL.Append(" from SAB_LAB_INFORMEMUESTRAS IM INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS cp ON IM.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append(" IM.IDINFORME = @IDINFORME AND ")
        strSQL.Append(" IM.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(0).Value = IDINFORME
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarEstadoInforme(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer, ByVal AUUSUARIOMODIFICACION As String, ByVal AUFECHAMODIFICACION As Date, ByVal IDESTADO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE   SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("SET IDESTADO = @IDESTADO, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDINFORME = @IDINFORME ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = IDINFORME
        args(2) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(2).Value = AUUSUARIOMODIFICACION
        args(3) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(3).Value = AUFECHAMODIFICACION
        args(4) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(4).Value = IDESTADO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerNotificacionesCapturadasCoordinador(ByVal estado As Integer, ByVal inspector As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT IM.NUMERONOTIFICACION, IM.FECHANOTIFICACION, A.IDPROVEEDOR, P.NOMBRE, isnull(C.NUMEROCONTRATO,'Pendiente') as NUMEROCONTRATO, ISNULL(C.IDCONTRATO,0) AS IDCONTRATO, A.IDESTABLECIMIENTO, PC.CODIGOLICITACION + ' - ' + PC.TITULOLICITACION AS PC, PC.IDPROCESOCOMPRA,PC.CODIGOLICITACION + ' - ' + PC.TITULOLICITACION AS PC, PC.IDPROCESOCOMPRA, PC.CODIGOLICITACION AS NUMPC,   E.NOMBRE AS ESTABLECIMIENTO, isnull(IM.NUMEROINFORME, 'Pendiente') as NUMEROINFORME1, ")
        strSQL.Append(" (select nombre + ' '+ APELLIDO from SAB_CAT_EMPLEADOS where IDEMPLEADO = IM.IDINSPECTOR) AS INSPECTOR, ")
        strSQL.Append(" IM.FECHAASIGNACION, IM.OBSERVACIONASIGNACION, IM.IDINFORME,IM.IDINSPECTOR, IM.IDTIPOINFORME, IM.RENGLON, IM.LOTE ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" INNER JOIN SAB_CAT_PROVEEDORES P ON ")
        strSQL.Append(" A.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append(" INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ON ")
        strSQL.Append(" E.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
        strSQL.Append(" LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
        strSQL.Append(" A.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" A.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA AND ")
        strSQL.Append(" A.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append(" LEFT OUTER JOIN SAB_UACI_PROCESOCOMPRAS PC  ON ")
        strSQL.Append(" A.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" A.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append(" LEFT OUTER JOIN SAB_UACI_CONTRATOS C ON ")
        strSQL.Append(" C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" C.IDPROVEEDOR = CPC.IDPROVEEDOR AND ")
        strSQL.Append(" C.IDCONTRATO = CPC.IDCONTRATO ")
        strSQL.Append(" INNER JOIN SAB_LAB_INFORMEMUESTRAS IM ON ")
        strSQL.Append(" P.IDPROVEEDOR = IM.IDPROVEEDOR AND ")
        strSQL.Append(" CPC.IDESTABLECIMIENTO = IM.IDESTABLECIMIENTOCONTRATO  AND ")
        strSQL.Append(" CPC.IDPROCESOCOMPRA = IM.IDPROCESOCOMPRA ")
        strSQL.Append(" WHERE A.CANTIDADFIRME > 0 ")
        'strSQL.Append(" IM.NUMEROINFORME IS NULL ")
        'strSQL.Append(" AND IM.IDINSPECTOR IS NULL ")
        strSQL.Append(" AND (IM.IDESTADO = @ESTADO OR @ESTADO = 1) ")
        strSQL.Append(" AND ((IM.IDINSPECTOR = @IDINSPECTOR AND @IDINSPECTOR > 0) OR (IM.IDINSPECTOR IS NULL AND @IDINSPECTOR = 0) OR (@IDINSPECTOR < 0)) ")
        strSQL.Append(" ORDER BY IM.FECHANOTIFICACION DESC ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(0).Value = estado
        args(1) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
        args(1).Value = inspector

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarInformacionCoordinador(ByVal aEntidad As INFORMEMUESTRAS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE   SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("SET  IDTIPOINFORME = @IDTIPOINFORME, ")
        strSQL.Append(" NUMEROINFORME = @NUMEROINFORME, ")
        strSQL.Append(" CANTIDADFISICOQUIMICO = @CANTIDADFISICOQUIMICO, ")
        strSQL.Append(" CANTIDADMICROBIOLOGIA = @CANTIDADMICROBIOLOGIA, ")
        strSQL.Append(" CANTIDADRETENCION = @CANTIDADRETENCION, ")
        strSQL.Append(" IDCOORDINADOR = @IDCOORDINADOR, ")
        'strSQL.Append(" OBSERVACIONCOORDINADOR = @OBSERVACIONCOORDINADOR, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDINFORME = @IDINFORME ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = aEntidad.IDINFORME
        args(2) = New SqlParameter("@NUMEROINFORME", SqlDbType.VarChar)
        args(2).Value = aEntidad.NUMEROINFORME
        args(3) = New SqlParameter("@CANTIDADFISICOQUIMICO", SqlDbType.Decimal)
        args(3).Value = aEntidad.CANTIDADFISICOQUIMICO
        args(4) = New SqlParameter("@CANTIDADMICROBIOLOGIA", SqlDbType.Decimal)
        args(4).Value = aEntidad.CANTIDADMICROBIOLOGIA
        args(5) = New SqlParameter("@CANTIDADRETENCION", SqlDbType.Decimal)
        args(5).Value = aEntidad.CANTIDADRETENCION
        args(6) = New SqlParameter("@IDCOORDINADOR", SqlDbType.Int)
        args(6).Value = aEntidad.IDCOORDINADOR
        'args(7) = New SqlParameter("@OBSERVACIONCOORDINADOR", SqlDbType.VarChar)
        'args(7).Value = aEntidad.OBSERVACIONCOORDINADOR
        args(7) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(7).Value = aEntidad.AUUSUARIOMODIFICACION
        args(8) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(8).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(9) = New SqlParameter("@IDTIPOINFORME", SqlDbType.Int)
        args(9).Value = aEntidad.IDTIPOINFORME

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarObservacionAsignacionInforme(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer, ByVal AUUSUARIOMODIFICACION As String, ByVal AUFECHAMODIFICACION As Date, ByVal observacionasignacion As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE   SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("SET OBSERVACIONASIGNACION = @OBSERVACIONASIGNACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDINFORME = @IDINFORME ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = IDINFORME
        args(2) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(2).Value = AUUSUARIOMODIFICACION
        args(3) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(3).Value = AUFECHAMODIFICACION
        args(4) = New SqlParameter("@OBSERVACIONASIGNACION", SqlDbType.VarChar)
        args(4).Value = observacionasignacion

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarInformacionJefe(ByVal aEntidad As INFORMEMUESTRAS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE   SAB_LAB_INFORMEMUESTRAS ")
        strSQL.Append("SET  RESULTADOINSPECCION = @RESULTADOINSPECCION, ")
        strSQL.Append(" OBSERVACIONCERTIFICACION = @OBSERVACIONCERTIFICACION, ")
        strSQL.Append(" IDJEFELABORATORIO = @IDJEFELABORATORIO, ")
        strSQL.Append(" FECHACERTIFICACION = @FECHACERTIFICACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDINFORME = @IDINFORME ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = aEntidad.IDINFORME
        args(2) = New SqlParameter("@OBSERVACIONCERTIFICACION", SqlDbType.VarChar)
        args(2).Value = aEntidad.OBSERVACIONCERTIFICACION
        args(3) = New SqlParameter("@IDJEFELABORATORIO", SqlDbType.Int)
        args(3).Value = aEntidad.IDJEFELABORATORIO
        args(4) = New SqlParameter("@FECHACERTIFICACION", SqlDbType.DateTime)
        args(4).Value = IIf(aEntidad.FECHACERTIFICACION = Nothing, DBNull.Value, aEntidad.FECHACERTIFICACION)
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = aEntidad.AUUSUARIOMODIFICACION
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(7) = New SqlParameter("@RESULTADOINSPECCION", SqlDbType.Int)
        args(7).Value = aEntidad.RESULTADOINSPECCION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
