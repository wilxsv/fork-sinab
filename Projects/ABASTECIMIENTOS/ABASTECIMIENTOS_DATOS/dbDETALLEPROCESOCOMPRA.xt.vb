Partial Public Class dbDETALLEPROCESOCOMPRA

#Region "Metodos agregados"

    ''' <summary>
    ''' Metodo para adicionar el detalle de un proceso de compra
    ''' </summary>
    ''' <param name="SOLICITUDSEL">Identificador de lista de solicitudes</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="ESTADOCALIFICACION">Identificador del estado de calificación</param>
    ''' <returns>Valor entero con el resultado de la adición</returns>

    Public Function AgregarDetalleProcesoCompra(ByVal SOLICITUDSEL As listaSOLICITUDES, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal ESTADOCALIFICACION As Integer) As Integer

        Dim dsConsolidadoDetalleSolicitud As DataSet
        Dim objDetalleSolicitud As New dbDETALLESOLICITUDES
        Dim lEntidad As New DETALLEPROCESOCOMPRA

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDPRODUCTO, SUM(CANTIDAD) AS CANTIDAD, MAX(NUMEROENTREGAS) AS NUMEROENTREGAS, IDUNIDADMEDIDA ")
        strSQL.Append(" FROM SAB_EST_DETALLESOLICITUDES ")

        For Each solic As SOLICITUDES In SOLICITUDSEL
            Dim i As Integer = SOLICITUDSEL.IndiceDe(solic)

            If i = 0 Then
                strSQL.Append(" WHERE ")
            Else
                strSQL.Append(" OR ")
            End If
            strSQL.Append(" (IDESTABLECIMIENTO = " & solic.IDESTABLECIMIENTO & " AND IDSOLICITUD = " & solic.IDSOLICITUD & ") ")
        Next

        strSQL.Append(" GROUP BY IDPRODUCTO, IDUNIDADMEDIDA, RENGLON ")
        strSQL.Append(" ORDER BY RENGLON ")

        dsConsolidadoDetalleSolicitud = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
        Try
            Dim j As Integer
            j = 1
            For i As Integer = 0 To dsConsolidadoDetalleSolicitud.Tables(0).Rows.Count - 1

                With lEntidad
                    .CANTIDAD = dsConsolidadoDetalleSolicitud.Tables(0).Rows(i).Item("CANTIDAD")
                    .IDDETALLE = 0
                    .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                    .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                    .IDPRODUCTO = dsConsolidadoDetalleSolicitud.Tables(0).Rows(i).Item("IDPRODUCTO")
                    .IDUNIDADMEDIDA = dsConsolidadoDetalleSolicitud.Tables(0).Rows(i).Item("IDUNIDADMEDIDA")
                    .NUMEROENTREGAS = dsConsolidadoDetalleSolicitud.Tables(0).Rows(i).Item("NUMEROENTREGAS")
                    .IDESTADOCALIFICACION = ESTADOCALIFICACION
                    .RENGLON = j
                    .ESTASINCRONIZADA = 1
                    j += 1
                End With
                Actualizar(lEntidad)
            Next
        Catch ex As Exception

        End Try

    End Function

    ''' <summary>
    ''' Obtener la información de un proceso de compra
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Listado de informacion de un proceso de compra en formato dataset</returns>

    Public Function ObtenerDataSetPorID(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener la informacion de un renglon de un proceso de compra
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <returns>Informacion del renglon en formato dataset</returns>

    Public Function obtenerDSRenglonProducto(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64, ByVal RENGLON As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DPC.IDPROCESOCOMPRA, ")
        strSQL.Append("DPC.IDESTABLECIMIENTO, ")
        strSQL.Append("DPC.RENGLON, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("DPC.CANTIDAD, ")
        strSQL.Append("DPC.IDUNIDADMEDIDA, ")
        strSQL.Append("DPC.IDPRODUCTO ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Actualizar la cantidad de un renglon de un proceso de compra
    ''' </summary>
    ''' <param name="aEntidad">Entidad que representa el detalle del proceso de compra</param>
    ''' <returns>Valor entero con el resultado de la actualización del método</returns>

    Public Function ActualizarCantidad(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEPROCESOCOMPRA SET ")
        strSQL.Append("CANTIDAD = @CANTIDAD, ")
        strSQL.Append("NUMEROENTREGAS = @NUMEROENTREGAS, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@CANTIDAD", SqlDbType.BigInt)
        args(0).Value = aEntidad.CANTIDAD
        args(1) = New SqlParameter("@NUMEROENTREGAS", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.NUMEROENTREGAS = Nothing, DBNull.Value, aEntidad.NUMEROENTREGAS)
        args(2) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(2).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(3) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(3).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(4) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(4).Value = aEntidad.ESTASINCRONIZADA
        args(5) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(5).Value = aEntidad.IDPROCESOCOMPRA
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = aEntidad.IDESTABLECIMIENTO
        args(7) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(7).Value = aEntidad.IDPRODUCTO
        args(8) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(8).Value = aEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene la informacion del encabezado para consolidar.
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información</param>
    ''' <param name="ds">Dataset referenciado para que capture el resultado de la consulta.</param>
    ''' <returns>Dataset con la informacion del encabezado para consolidar.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLEPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_ENTREGAPROCESOCOMPRA</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ObtenerDataSetParaConsolidar(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append(" dpc.RENGLON, ")
        strSQL.Append(" dpc.CANTIDAD, ")
        strSQL.Append(" dpc.NUMEROENTREGAS, ")
        strSQL.Append(" cp.DESCLARGO AS PRODUCTO, ")
        strSQL.Append(" um.DESCRIPCION AS UM, ")
        strSQL.Append(" cp.IDPRODUCTO, ")
        strSQL.Append(" dpc.IDDETALLE ")
        strSQL.Append(" FROM ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA AS dpc ")
        strSQL.Append(" INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS AS p ON dpc.IDESTABLECIMIENTO = p.IDESTABLECIMIENTO AND ")
        strSQL.Append(" dpc.IDPROCESOCOMPRA = p.IDPROCESOCOMPRA ")
        strSQL.Append(" INNER JOIN ")
        strSQL.Append(" SAB_UACI_ENTREGAPROCESOCOMPRA AS epc ON epc.IDESTABLECIMIENTO = p.IDESTABLECIMIENTO AND ")
        strSQL.Append(" epc.IDPROCESOCOMPRA = p.IDPROCESOCOMPRA And dpc.NUMEROENTREGAS = epc.IDENTREGA ")
        strSQL.Append(" INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS AS cp ON dpc.IDPRODUCTO = cp.IDPRODUCTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS AS um ON dpc.IDUNIDADMEDIDA = um.IDUNIDADMEDIDA ")
        strSQL.Append("WHERE (p.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (p.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("AND (dpc.IDESTADOCALIFICACION <> 8) ")
        strSQL.Append("ORDER BY dpc.RENGLON ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim tables(0) As String
        tables(0) = New String("ENCABEZADO")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function
    ''' <summary>
    ''' Información del detalle del proceso de compra para consolidación
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Listado de productos en formato dataset</returns>

    Public Function ObtenerDataSetParaConsolidar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DPC.IDDETALLE, ")
        strSQL.Append("DPC.RENGLON, ")
        strSQL.Append("DPC.CANTIDAD, ")
        strSQL.Append("DPC.NUMEROENTREGAS, ")
        strSQL.Append("CP.IDPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO PRODUCTO, ")
        strSQL.Append("CP.DESCRIPCION UM ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGAPROCESOCOMPRA EPC ")
        strSQL.Append("ON DPC.IDESTABLECIMIENTO = EPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = EPC.IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.NUMEROENTREGAS = EPC.IDENTREGA ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.IDESTADOCALIFICACION <> 8 ")
        'strSQL.Append("AND (select count(*) from SAB_UACI_DETALLEOFERTA DO where DO.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO AND DO.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA AND DO.RENGLON = DPC.RENGLON) > 0 ")
        strSQL.Append("ORDER BY DPC.RENGLON ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene la informacion para consolidar por renglón.
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información</param>
    ''' ''' <param name="IDRENGLON">Especifica el valor a utilizar para filtrar la información</param>
    ''' <param name="ds">Dataset referenciado para que capture el resultado de la consulta.</param>
    ''' <returns>Dataset con la informacion del consolidado por renglón.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLEPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_ENTREGAPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_UACI_DETALLEENTREGASPROCESOCOMPRA</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ObtenerDataSetParaConsolidarPorRenglon(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDRENGLON As Integer, ByRef ds As DataSet) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append(" dpc.RENGLON, dpc.CANTIDAD, dpc.NUMEROENTREGAS, ")
        strSQL.Append(" de.DIAS, de.PORCENTAJE, de.TIPOCONTEO, ")
        strSQL.Append(" cp.DESCLARGO AS PRODUCTO, ")
        strSQL.Append(" um.DESCRIPCION AS UM, ")
        strSQL.Append(" cp.IDPRODUCTO, ")
        strSQL.Append(" isnull(dpc.OBSERVACION,'') as OBSERVACION ")
        strSQL.Append(" FROM ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA dpc ")
        strSQL.Append(" INNER JOIN SAB_UACI_PROCESOCOMPRAS p ")
        strSQL.Append(" ON dpc.IDESTABLECIMIENTO = p.IDESTABLECIMIENTO AND ")
        strSQL.Append(" dpc.IDPROCESOCOMPRA = p.IDPROCESOCOMPRA ")
        strSQL.Append(" INNER JOIN SAB_UACI_ENTREGAPROCESOCOMPRA epc ")
        strSQL.Append(" ON epc.IDESTABLECIMIENTO = p.IDESTABLECIMIENTO AND ")
        strSQL.Append(" epc.IDPROCESOCOMPRA = p.IDPROCESOCOMPRA AND ")
        strSQL.Append(" dpc.NUMEROENTREGAS = epc.IDENTREGA ")
        strSQL.Append(" INNER JOIN SAB_UACI_DETALLEENTREGASPROCESOCOMPRA de ")
        strSQL.Append(" ON epc.IDESTABLECIMIENTO = de.IDESTABLECIMIENTO AND ")
        strSQL.Append(" epc.IDPROCESOCOMPRA = de.IDPROCESOCOMPRA AND ")
        strSQL.Append(" epc.IDENTREGA = de.IDENTREGA ")
        strSQL.Append(" INNER JOIN vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append(" ON dpc.IDPRODUCTO = cp.IDPRODUCTO ")
        strSQL.Append(" INNER JOIN SAB_CAT_UNIDADMEDIDAS um ")
        strSQL.Append(" ON dpc.IDUNIDADMEDIDA = um.IDUNIDADMEDIDA ")
        strSQL.Append(" WHERE ")
        strSQL.Append(" p.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append(" p.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND ")
        strSQL.Append(" dpc.RENGLON = @IDRENGLON ")
        strSQL.Append(" ORDER BY dpc.RENGLON, de.IDDETALLE ASC ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDRENGLON", SqlDbType.Int)
        args(2).Value = IDRENGLON

        Dim tables(0) As String
        tables(0) = New String("ENCABEZADO")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function
    ''' <summary>
    ''' Listado de informacion de un renglon de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <returns>cadena de caracteres </returns>

    Public Function ObtenerDataSetParaConsolidarPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DE.PORCENTAJE, DE.DIAS ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("INNER JOIN SAB_UACI_ENTREGAPROCESOCOMPRA EPC ")
        strSQL.Append("ON DPC.IDESTABLECIMIENTO = EPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = EPC.IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.NUMEROENTREGAS = EPC.IDENTREGA ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEENTREGASPROCESOCOMPRA DE ")
        strSQL.Append("ON EPC.IDESTABLECIMIENTO = DE.IDESTABLECIMIENTO AND ")
        strSQL.Append("EPC.IDPROCESOCOMPRA = DE.IDPROCESOCOMPRA AND ")
        strSQL.Append("EPC.IDENTREGA = DE.IDENTREGA ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.RENGLON = @RENGLON ")
        strSQL.Append("ORDER BY DPC.RENGLON, DE.IDDETALLE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim s As New Text.StringBuilder

        Try
            If dr.HasRows Then
                dr.Read()
                s.Append(dr("PORCENTAJE").ToString() + "% a " + dr("DIAS").ToString() + " días - ")

                Do While dr.Read()
                    s.Append(Environment.NewLine)
                    s.Append(dr("PORCENTAJE").ToString() + "% a " + dr("DIAS").ToString() + " días - ")
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return s.ToString

    End Function

    ''' <summary>
    ''' Agrega la observación relacionada  a la consolidación de datos.
    ''' </summary>
    ''' <param name="aEntidad">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Número que indica si la adición del registro se realizó en forma satisfactoria</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLEPROCESOCOMPRA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]      Creado
    ''' </history> 
    Public Function AgregarObservacion(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("SET OBSERVACION = @OBSERVACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO AND IDDETALLE = @IDDETALLE ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(0).Value = aEntidad.OBSERVACION
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(4).Value = aEntidad.IDPROCESOCOMPRA
        args(5) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(5).Value = aEntidad.IDESTABLECIMIENTO
        args(6) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(6).Value = aEntidad.IDPRODUCTO
        args(7) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(7).Value = aEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtener la observacion de un producto de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPRODUCTO">Identificador del producto</param>
    ''' <param name="IDDETALLE">Identificador del detalle</param>
    ''' <returns>Cadena de caracteres con la observación</returns>

    Public Function ObtenerObservacionConsolidacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPRODUCTO As Integer, ByVal IDDETALLE As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(OBSERVACION, '') OBSERVACION ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualizar los valores de la garantía
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad detalleprocesocompra</param>
    ''' <returns>Valor entero con el resultado de la actualización</returns>

    Public Function ActualizarGarantiaValor(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEPROCESOCOMPRA SET ")
        strSQL.Append("GARANTIAMTTOVALOR = @GARANTIAMTTOVALOR, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@GARANTIAMTTOVALOR", SqlDbType.Decimal)
        args(0).Value = aEntidad.GARANTIAMTTOVALOR
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = aEntidad.IDESTABLECIMIENTO
        args(5) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(5).Value = aEntidad.IDPROCESOCOMPRA
        args(6) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(6).Value = aEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtener el listado de productos de un proceso de compra
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Listado de productos en formato dataset</returns>

    Public Function ObtenerDataListaProductos(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_DETALLEPROCESOCOMPRA.RENGLON, SAB_CAT_CATALOGOPRODUCTOS.CODIGO, SAB_CAT_CATALOGOPRODUCTOS.NOMBRE, ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS.ESPECIFICACIONESTECNICAS, SAB_CAT_UNIDADMEDIDAS.DESCRIPCION, SAB_UACI_DETALLEPROCESOCOMPRA.CANTIDAD, ")
        strSQL.Append(" SAB_UACI_DETALLEPROCESOCOMPRA.NUMEROENTREGAS, ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS.NOMBRE + '  ' + ISNULL(SAB_CAT_CATALOGOPRODUCTOS.CONCENTRACION,'') ")
        strSQL.Append("  + '  ' + ISNULL(SAB_CAT_CATALOGOPRODUCTOS.FORMAFARMACEUTICA,'') + '  ' + ISNULL(SAB_CAT_CATALOGOPRODUCTOS.PRESENTACION,'') AS DESCRIPCIONNOMBRE ")
        strSQL.Append(" FROM SAB_UACI_DETALLEPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_CATALOGOPRODUCTOS ON SAB_UACI_DETALLEPROCESOCOMPRA.IDPRODUCTO = SAB_CAT_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_UNIDADMEDIDAS ON SAB_CAT_CATALOGOPRODUCTOS.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA ")
        strSQL.Append(" WHERE (SAB_UACI_DETALLEPROCESOCOMPRA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_DETALLEPROCESOCOMPRA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) order by SAB_CAT_CATALOGOPRODUCTOS.CODIGO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve todos los renglones asociados a un proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Numero de renglon.  Opcional.  El valor por defecto es cero, que indica que se deben devolver todos los renglones.</param>
    ''' <param name="IDESTADO">Array de identificadores del estado del renglon.  Opcional.  El valor por defecto es Nothing, que significa que se deben devolver todos los estados. </param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_CAT_ESTADOSCALIFICACIONES</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerRenglonesProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer, Optional ByVal IDESTADO() As Byte = Nothing) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT distinct ")
        strSQL.Append("DPC.IDDETALLE, ")
        strSQL.Append("DPC.RENGLON, ")
        strSQL.Append("CP.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        'strSQL.Append("CP.PRECIOACTUAL, ")
        strSQL.Append("ds.PRESUPUESTOUNITARIO PRECIOACTUAL, ")

        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("DPC.CANTIDAD CANTIDADSOLICITADA, ")
        strSQL.Append("DPC.NUMEROENTREGAS, ")
        strSQL.Append("EC.DESCRIPCION ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        'seleccionar precios de solicitudes 27112012 Mayra Martínez
        strSQL.Append("inner join SAB_EST_SOLICITUDESPROCESOCOMPRAS spc on spc.IDPROCESOCOMPRA=dpc.IDPROCESOCOMPRA and spc.IDESTABLECIMIENTO=dpc.IDESTABLECIMIENTO ")
        strSQL.Append("inner join SAB_EST_DETALLESOLICITUDES ds on ds.IDESTABLECIMIENTO=spc.IDESTABLECIMIENTOSOLICITUD and ds.IDSOLICITUD=spc.IDSOLICITUD and dpc.IDPRODUCTO=ds.IDPRODUCTO ")

        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSCALIFICACIONES EC ")
        strSQL.Append("ON DPC.IDESTADOCALIFICACION = EC.IDESTADO ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        If Not IsNothing(IDESTADO) Then
            For i As Integer = 0 To IDESTADO.Length - 1
                If i = 0 Then
                    strSQL.Append("AND DPC.IDESTADOCALIFICACION IN ( ")
                End If
                strSQL.Append("@IDESTADO" + i.ToString)
                If i = IDESTADO.Length - 1 Then
                    strSQL.Append(") ")
                Else
                    strSQL.Append(", ")
                End If
            Next
        End If
        strSQL.Append("AND (DPC.RENGLON = @RENGLON OR @RENGLON = 0) ")
        strSQL.Append("ORDER BY DPC.RENGLON ")

        Dim length As Integer
        If Not IsNothing(IDESTADO) Then length = IDESTADO.Length

        Dim args(3 + length) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON
        If Not IsNothing(IDESTADO) Then
            For i As Integer = 0 To IDESTADO.Length - 1
                args(3 + i) = New SqlParameter("@IDESTADO" + i.ToString, SqlDbType.Int)
                args(3 + i).Value = IDESTADO(i)
            Next
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener una cantidad de un producto de un detalle de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDPRODUCTO">Identificador del producto</param>
    ''' <param name="IDDETALLE">Identificador del detalle</param>
    ''' <returns>Un valor decimal con la cantidad</returns>

    Public Function ObtenerCantidad(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPRODUCTO As Integer, ByVal IDDETALLE As Integer) As Decimal

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CANTIDAD ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("WHERE ")
        strSQL.Append("IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.TinyInt)
        args(2).Value = IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza la calificación de un renglón.
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad detalleprocesocompra.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarEstadoCalificacionProcesoCompra(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("SET IDESTADOCALIFICACION = @IDESTADOCALIFICACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = aEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = aEntidad.IDDETALLE
        args(4) = New SqlParameter("@IDESTADOCALIFICACION", SqlDbType.Int)
        args(4).Value = aEntidad.IDESTADOCALIFICACION
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualizar la observacion a una recomendacion de un renglon de un proceso de compra
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad detalleprocesocompra.</param>
    ''' <returns>Valor entero con el resultado de la actualización</returns>

    Public Function ActualizarObservacionRecomendacion(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("SET OBSERVACIONRECOMENDACION = @OBSERVACIONRECOMENDACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = aEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = aEntidad.IDDETALLE
        args(4) = New SqlParameter("@OBSERVACIONRECOMENDACION", SqlDbType.VarChar)
        args(4).Value = aEntidad.OBSERVACIONRECOMENDACION
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve las observaciones registradas para un renglón al momento de efectuar la recomendación.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <param name="IDDETALLE">Identificador del renglón.</param>
    ''' <returns>String.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerObservacionRecomendacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPRODUCTO As Integer, ByVal IDDETALLE As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(OBSERVACIONRECOMENDACION, '') OBSERVACION ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve las observaciones registradas para un renglón al momento de efectuar la adjudicación.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <param name="IDDETALLE">Identificador del renglón.</param>
    ''' <returns>String.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerObservacionAdjudicacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPRODUCTO As Integer, ByVal IDDETALLE As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(OBSERVACIONADJUDICADA, '') OBSERVACION ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve las observaciones registradas para un renglón al momento de efectuar la adjudicación en firme.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <param name="IDDETALLE">Identificador del renglón.</param>
    ''' <returns>String.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerObservacionAdjudicacionEnFirme(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPRODUCTO As Integer, ByVal IDDETALLE As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(OBSERVACIONFIRME, '') OBSERVACION ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza el estado de un renglón para el cual no se ha recomendado/adjudicado.
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad detalleprocesocompra.</param>
    ''' <returns>Integer</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarEstadoCalificacionProcesoCompraNoAdjudicado(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("IF NOT EXISTS ( ")
        strSQL.Append("SELECT * ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (A.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND A.IDPROVEEDOR = DO.IDPROVEEDOR ")
        strSQL.Append("AND A.IDDETALLE = DO.IDDETALLE) ")
        strSQL.Append("WHERE ")
        strSQL.Append("A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.RENGLON = @RENGLON ")
        strSQL.Append("AND A.CANTIDADRECOMENDACION > 0) ")
        strSQL.Append("BEGIN ")
        strSQL.Append("	UPDATE SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("	SET IDESTADOCALIFICACION = @IDESTADOCALIFICACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("	WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("	AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("	AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("	AND IDDETALLE = @IDDETALLE ")
        strSQL.Append("END ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = aEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = aEntidad.IDDETALLE
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = aEntidad.RENGLON
        args(5) = New SqlParameter("@IDESTADOCALIFICACION", SqlDbType.Int)
        args(5).Value = aEntidad.IDESTADOCALIFICACION
        args(6) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(6).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(7) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(7).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Cantidad de renglones recomendados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTADO"></param>
    ''' <returns>Valor entero con la cantidad de renglones recomendados</returns>

    Public Function RenglonesRecomendados(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, Optional ByVal IDESTADO() As Byte = Nothing) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("count(RENGLON) ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("WHERE ")
        strSQL.Append("(DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        If Not IsNothing(IDESTADO) Then
            For i As Integer = 0 To IDESTADO.Length - 1
                If i = 0 Then
                    strSQL.Append("AND DPC.IDESTADOCALIFICACION IN ( ")
                End If
                strSQL.Append("@IDESTADO" + i.ToString)
                If i = IDESTADO.Length - 1 Then
                    strSQL.Append(") ")
                Else
                    strSQL.Append(", ")
                End If
            Next
        End If

        Dim length As Integer
        If Not IsNothing(IDESTADO) Then length = IDESTADO.Length

        Dim args(2 + length) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        If Not IsNothing(IDESTADO) Then
            For i As Integer = 0 To IDESTADO.Length - 1
                args(2 + i) = New SqlParameter("@IDESTADO" + i.ToString, SqlDbType.Int)
                args(2 + i).Value = IDESTADO(i)
            Next
        End If

        Dim NRenglonesxEstado As Integer
        NRenglonesxEstado = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim strSQL2 As New Text.StringBuilder
        strSQL2.Append("SELECT ")
        strSQL2.Append("count(RENGLON) ")
        strSQL2.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL2.Append("WHERE ")
        strSQL2.Append("(DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL2.Append("AND ")
        strSQL2.Append("(DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

        Dim NRenglonesxPC As Integer
        NRenglonesxPC = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL2.ToString(), args)

        Return (NRenglonesxPC - NRenglonesxEstado)

    End Function

    ''' <summary>
    ''' Actualiza las observaciones correspondientes a un renglón dado.
    ''' </summary>
    ''' <param name="aEntidad">Entidad DETALLEPROCESOCOMPRA.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarObservaciones(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("SET ")
        If Not aEntidad.OBSERVACIONRECOMENDACION = String.Empty Then
            strSQL.Append("OBSERVACIONRECOMENDACION = @OBSERVACIONRECOMENDACION, ")
        ElseIf Not aEntidad.OBSERVACIONADJUDICADA = String.Empty Then
            strSQL.Append("OBSERVACIONADJUDICADA = @OBSERVACIONADJUDICADA, ")
        ElseIf Not aEntidad.OBSERVACIONFIRME = String.Empty Then
            strSQL.Append("OBSERVACIONFIRME = @OBSERVACIONFIRME, ")
        End If
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = aEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = aEntidad.IDDETALLE
        If Not aEntidad.OBSERVACIONRECOMENDACION = String.Empty Then
            args(4) = New SqlParameter("@OBSERVACIONRECOMENDACION", SqlDbType.VarChar)
            args(4).Value = aEntidad.OBSERVACIONRECOMENDACION
        ElseIf Not aEntidad.OBSERVACIONADJUDICADA = String.Empty Then
            args(4) = New SqlParameter("@OBSERVACIONADJUDICADA", SqlDbType.VarChar)
            args(4).Value = aEntidad.OBSERVACIONADJUDICADA
        ElseIf Not aEntidad.OBSERVACIONFIRME = String.Empty Then
            args(4) = New SqlParameter("@OBSERVACIONFIRME", SqlDbType.VarChar)
            args(4).Value = aEntidad.OBSERVACIONFIRME
        End If
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(7) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(7).Value = aEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve todos los renglones asociados a un proceso de compra para los cuales los proveedores adjudicados no presentaron nota de aceptacion.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Numero de renglon.  Opcional.  El valor por defecto es cero, que indica que se deben devolver todos los renglones.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_CAT_ESTADOSCALIFICACIONES</item>
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' <item>SAB_UACI_NOTASACEPTACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerRenglonesSinNotasAceptacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, Optional ByVal RENGLON As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("DPC.IDDETALLE, ")
        strSQL.Append("DPC.RENGLON, ")
        strSQL.Append("DO.RENGLON, ")
        strSQL.Append("CP.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.PRECIOACTUAL, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("DPC.CANTIDAD CANTIDADSOLICITADA, ")
        strSQL.Append("DPC.NUMEROENTREGAS, ")
        strSQL.Append("EC.DESCRIPCION ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
        strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOSCALIFICACIONES EC ")
        strSQL.Append("ON DPC.IDESTADOCALIFICACION = EC.IDESTADO ")
        strSQL.Append("WHERE DO.IDPROVEEDOR NOT IN ")
        strSQL.Append("( ")
        strSQL.Append(" SELECT A.IDPROVEEDOR ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append(" INNER JOIN SAB_UACI_NOTASACEPTACION NA ")
        strSQL.Append(" ON (A.IDESTABLECIMIENTO = NA.IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROCESOCOMPRA = NA.IDPROCESOCOMPRA ")
        strSQL.Append(" AND A.IDPROVEEDOR = NA.IDPROVEEDOR) ")
        strSQL.Append(" WHERE A.CANTIDADADJUDICADA > 0 ")
        strSQL.Append(") ")
        strSQL.Append("AND DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND (DPC.RENGLON = @RENGLON OR @RENGLON = 0) ")
        strSQL.Append("ORDER BY DPC.RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Información del detalle de proceso de compra relacionada a la resolución de adjudicación
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="ds"></param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_CAT_ESTADOSCALIFICACIONES</item>
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' <item>SAB_UACI_NOTASACEPTACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ResolucionAdjudicacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByRef ds As DataSet, ByVal IDALMACEN As Integer) As Integer

        Dim strSQL As New Text.StringBuilder

        Select Case IDALMACEN
            Case Is = 0
                Dim X As New dbPROGRAMADISTRIBUCION
                If X.ObtenerAlmacenFosIsss(IDESTABLECIMIENTO, IDPROCESOCOMPRA) = 0 Then
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                    strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                    strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                    strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                    strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                    strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                    strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                    strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("isnull(A.CANTIDADFIRME, 0) CANTIDAD, ")
                    strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                    strSQL.Append("isnull(DO.PRECIOUNITARIO * A.CANTIDADFIRME, 0) MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")
                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")

                    strSQL.Append("UNION ")
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("null OFERTA, ")
                    strSQL.Append("null ALTERNATIVA, ")
                    strSQL.Append("'' PROVEEDOR, ")
                    strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("case ")
                    strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                    strSQL.Append("    else 'NO ADJUDICADO' ")
                    strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("null CANTIDAD, ")
                    strSQL.Append("null PRECIOUNITARIO, ")
                    strSQL.Append("null MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                    strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                    strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                    strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND A.CANTIDADADJUDICADA > 0) ")
                    strSQL.Append("OR DO.RENGLON is null) ")
                    strSQL.Append("ORDER BY RENGLON ")

                    '------------------------------------
                    strSQL.Append("SELECT ")
                    strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                    strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                    strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
                    strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                    strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    strSQL.Append("IF NOT EXISTS ")
                    strSQL.Append("    ( ")
                    strSQL.Append("        SELECT ")
                    strSQL.Append("            TIPOPLANTILLA ")
                    strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                    strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("        AND TIPOPLANTILLA = 2 ")
                    strSQL.Append("    ) ")
                    strSQL.Append("BEGIN ")
                    strSQL.Append("    SELECT ")
                    strSQL.Append("    CODIGOFUENTE TEXTO ")
                    strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
                    strSQL.Append("    WHERE TIPOPLANTILLA = 2 ")
                    strSQL.Append("END ")
                    strSQL.Append("ELSE ")
                    strSQL.Append("BEGIN ")
                    strSQL.Append("    SELECT ")
                    strSQL.Append("    TEXTO ")
                    strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                    strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("    AND TIPOPLANTILLA = 2 ")
                    strSQL.Append("END ")
                Else

                    'mspas

                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                    strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                    strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                    strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                    strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                    strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                    strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                    strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("isnull(SUM(AEA.CANTIDAD), 0) CANTIDAD, ")
                    strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                    strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * AEA.CANTIDAD), 0) MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES, ")
                    strSQL.Append(" 1 as IDAGRUPACION, 'MSPAS' AS NOMBREGRUPO ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                    strSQL.Append(" AND AEA.IDALMACEN NOT IN (114,499,116) ")

                    strSQL.Append("group by  ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("DO.CORRELATIVORENGLON, ")
                    strSQL.Append("P.NOMBRE, ")
                    strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                    strSQL.Append("CP.DESCRIPCION, ")
                    strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("DO.MARCA, ")
                    strSQL.Append("DO.ORIGEN, ")
                    strSQL.Append("DO.VENCIMIENTO, ")
                    strSQL.Append("DO.CASAREPRESENTADA, ")
                    strSQL.Append("DO.NUMEROCSSP, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("DPC.OBSERVACIONFIRME ")

                    strSQL.Append(" UNION ")

                    'fosalud
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                    strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                    strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                    strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                    strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                    strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                    strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                    strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("isnull(SUM(AEA.CANTIDAD), 0) CANTIDAD, ")
                    strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                    strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * AEA.CANTIDAD), 0) MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES, ")
                    strSQL.Append(" 2 as IDAGRUPACION, 'FOSALUD' AS NOMBREGRUPO ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                    strSQL.Append(" AND AEA.IDALMACEN in (114,116) ")

                    strSQL.Append("group by  ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("DO.CORRELATIVORENGLON, ")
                    strSQL.Append("P.NOMBRE, ")
                    strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                    strSQL.Append("CP.DESCRIPCION, ")
                    strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("DO.MARCA, ")
                    strSQL.Append("DO.ORIGEN, ")
                    strSQL.Append("DO.VENCIMIENTO, ")
                    strSQL.Append("DO.CASAREPRESENTADA, ")
                    strSQL.Append("DO.NUMEROCSSP, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("DPC.OBSERVACIONFIRME ")

                    strSQL.Append(" UNION ")

                    'isss
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                    strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                    strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                    strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                    strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                    strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                    strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                    strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("isnull(SUM(AEA.CANTIDAD), 0) CANTIDAD, ")
                    strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                    strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * AEA.CANTIDAD), 0) MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES, ")
                    strSQL.Append(" 3 as IDAGRUPACION, 'ISSS' AS NOMBREGRUPO ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                    strSQL.Append(" AND AEA.IDALMACEN=499 ")

                    strSQL.Append("group by  ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("DO.CORRELATIVORENGLON, ")
                    strSQL.Append("P.NOMBRE, ")
                    strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                    strSQL.Append("CP.DESCRIPCION, ")
                    strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("DO.MARCA, ")
                    strSQL.Append("DO.ORIGEN, ")
                    strSQL.Append("DO.VENCIMIENTO, ")
                    strSQL.Append("DO.CASAREPRESENTADA, ")
                    strSQL.Append("DO.NUMEROCSSP, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("DPC.OBSERVACIONFIRME ")

                    '--------------
                    strSQL.Append("UNION ")
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("null OFERTA, ")
                    strSQL.Append("null ALTERNATIVA, ")
                    strSQL.Append("'' PROVEEDOR, ")
                    strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("case ")
                    strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                    strSQL.Append("    else 'NO ADJUDICADO' ")
                    strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("null CANTIDAD, ")
                    strSQL.Append("null PRECIOUNITARIO, ")
                    strSQL.Append("null MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES, ")
                    strSQL.Append(" 4 AS IDAGRUPACION, '' AS NOMBREGRUPO ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                    strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                    strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                    strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND A.CANTIDADADJUDICADA > 0) ")
                    strSQL.Append("OR DO.RENGLON is null) ")
                    strSQL.Append("ORDER BY RENGLON ")

                    '------------------------------------

                    'SUBREPORTE MSPAS
                    strSQL.Append("SELECT ")
                    strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, aea.iddetalle, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("sum(AEA.CANTIDAD) CANTIDADADJUDICADA, ")
                    strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
                    strSQL.Append(" 1 AS IDAGRUPACION, 'MSPAS' AS AGRUPACION ")

                    strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")
                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")


                    strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                    strSQL.Append("AND AEA.IDALMACEN NOT IN (114,499,116) ")

                    strSQL.Append("GROUP BY OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, aea.iddetalle, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("P.NOMBRE ")

                    ' strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    strSQL.Append(" UNION ")

                    strSQL.Append("SELECT ")
                    strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, aea.iddetalle,")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("sum(AEA.CANTIDAD) CANTIDADADJUDICADA, ")
                    strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
                    strSQL.Append(" 2 AS IDAGRUPACION, 'FOSALUD' AS AGRUPACION ")

                    strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")


                    strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                    strSQL.Append("AND AEA.IDALMACEN in (114,116) ")

                    strSQL.Append("GROUP BY OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, aea.iddetalle, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("P.NOMBRE ")

                    'strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    strSQL.Append(" UNION ")

                    strSQL.Append("SELECT ")
                    strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, aea.iddetalle, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("sum(AEA.CANTIDAD) CANTIDADADJUDICADA, ")
                    strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
                    strSQL.Append(" 3 AS IDAGRUPACION, 'ISSS' AS AGRUPACION ")

                    strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")


                    strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                    strSQL.Append("AND AEA.IDALMACEN=499 ")

                    strSQL.Append("GROUP BY OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, aea.iddetalle, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("P.NOMBRE ")

                    'strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    ''SUBREPORTE FOSALUD
                    'strSQL.Append("SELECT ")
                    'strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    'strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    'strSQL.Append("OPC.IDPROVEEDOR, ")
                    'strSQL.Append("DO.RENGLON, ")
                    'strSQL.Append("DO.PRECIOUNITARIO, ")
                    'strSQL.Append("RO.ORDENLLEGADA, ")
                    'strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                    'strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                    'strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    'strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    'strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    'strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    'strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    'strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")

                    'strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    'strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    'strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    'strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    'strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")


                    'strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    'strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    'strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    'strSQL.Append("AND PD.IDALMACEN=114 ")
                    'strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    ''SUBREPORTE ISSS
                    'strSQL.Append("SELECT ")
                    'strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    'strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    'strSQL.Append("OPC.IDPROVEEDOR, ")
                    'strSQL.Append("DO.RENGLON, ")
                    'strSQL.Append("DO.PRECIOUNITARIO, ")
                    'strSQL.Append("RO.ORDENLLEGADA, ")
                    'strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                    'strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                    'strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    'strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    'strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    'strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    'strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    'strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")

                    'strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    'strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    'strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    'strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    'strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")


                    'strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    'strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    'strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    'strSQL.Append("AND PD.IDALMACEN=499 ")
                    'strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    strSQL.Append("IF NOT EXISTS ")
                    strSQL.Append("    ( ")
                    strSQL.Append("        SELECT ")
                    strSQL.Append("            TIPOPLANTILLA ")
                    strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                    strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("        AND TIPOPLANTILLA = 2 ")
                    strSQL.Append("    ) ")
                    strSQL.Append("BEGIN ")
                    strSQL.Append("    SELECT ")
                    strSQL.Append("    CODIGOFUENTE TEXTO ")
                    strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
                    strSQL.Append("    WHERE TIPOPLANTILLA = 2 ")
                    strSQL.Append("END ")
                    strSQL.Append("ELSE ")
                    strSQL.Append("BEGIN ")
                    strSQL.Append("    SELECT ")
                    strSQL.Append("    TEXTO ")
                    strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                    strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("    AND TIPOPLANTILLA = 2 ")
                    strSQL.Append("END ")

                End If

            Case Is = 1
                'mspas
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("isnull(SUM(PD.CANTIDADADJUDICADA), 0) CANTIDAD, ")
                strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA), 0) MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                strSQL.Append(" AND PD.IDALMACEN NOT IN (114,116,499) ")

                strSQL.Append("group by  ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("DO.CORRELATIVORENGLON, ")
                strSQL.Append("P.NOMBRE, ")
                strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                strSQL.Append("CP.DESCRIPCION, ")
                strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("DO.MARCA, ")
                strSQL.Append("DO.ORIGEN, ")
                strSQL.Append("DO.VENCIMIENTO, ")
                strSQL.Append("DO.CASAREPRESENTADA, ")
                strSQL.Append("DO.NUMEROCSSP, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("DPC.OBSERVACIONFIRME ")


                strSQL.Append("UNION ")
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("null OFERTA, ")
                strSQL.Append("null ALTERNATIVA, ")
                strSQL.Append("'' PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("case ")
                strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                strSQL.Append("    else 'NO ADJUDICADO' ")
                strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("null CANTIDAD, ")
                strSQL.Append("null PRECIOUNITARIO, ")
                strSQL.Append("null MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("                        AND A.CANTIDADADJUDICADA > 0) ")
                strSQL.Append("OR DO.RENGLON is null) ")
                strSQL.Append("ORDER BY RENGLON ")

                '------------------------------------
                strSQL.Append("SELECT ")
                strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                strSQL.Append("OPC.IDPROVEEDOR, ")
                strSQL.Append("DO.RENGLON, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
                strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                strSQL.Append("IF NOT EXISTS ")
                strSQL.Append("    ( ")
                strSQL.Append("        SELECT ")
                strSQL.Append("            TIPOPLANTILLA ")
                strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("        AND TIPOPLANTILLA = 2 ")
                strSQL.Append("    ) ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    CODIGOFUENTE TEXTO ")
                strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
                strSQL.Append("    WHERE TIPOPLANTILLA = 2 ")
                strSQL.Append("END ")
                strSQL.Append("ELSE ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    TEXTO ")
                strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("    AND TIPOPLANTILLA = 2 ")
                strSQL.Append("END ")
            Case Is = 114, 116
                'fosalud
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("isnull(SUM(PD.CANTIDADADJUDICADA), 0) CANTIDAD, ")
                strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA), 0) MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                strSQL.Append(" AND PD.IDALMACEN in (114,116) ")

                strSQL.Append("group by  ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("DO.CORRELATIVORENGLON, ")
                strSQL.Append("P.NOMBRE, ")
                strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                strSQL.Append("CP.DESCRIPCION, ")
                strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("DO.MARCA, ")
                strSQL.Append("DO.ORIGEN, ")
                strSQL.Append("DO.VENCIMIENTO, ")
                strSQL.Append("DO.CASAREPRESENTADA, ")
                strSQL.Append("DO.NUMEROCSSP, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("DPC.OBSERVACIONFIRME ")


                strSQL.Append("UNION ")
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("null OFERTA, ")
                strSQL.Append("null ALTERNATIVA, ")
                strSQL.Append("'' PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("case ")
                strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                strSQL.Append("    else 'NO ADJUDICADO' ")
                strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("null CANTIDAD, ")
                strSQL.Append("null PRECIOUNITARIO, ")
                strSQL.Append("null MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("                        AND A.CANTIDADADJUDICADA > 0) ")
                strSQL.Append("OR DO.RENGLON is null) ")
                strSQL.Append("ORDER BY RENGLON ")

                '------------------------------------
                strSQL.Append("SELECT ")
                strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                strSQL.Append("OPC.IDPROVEEDOR, ")
                strSQL.Append("DO.RENGLON, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
                strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                strSQL.Append("IF NOT EXISTS ")
                strSQL.Append("    ( ")
                strSQL.Append("        SELECT ")
                strSQL.Append("            TIPOPLANTILLA ")
                strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("        AND TIPOPLANTILLA = 2 ")
                strSQL.Append("    ) ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    CODIGOFUENTE TEXTO ")
                strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
                strSQL.Append("    WHERE TIPOPLANTILLA = 2 ")
                strSQL.Append("END ")
                strSQL.Append("ELSE ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    TEXTO ")
                strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("    AND TIPOPLANTILLA = 2 ")
                strSQL.Append("END ")
            Case Is = 499
                'isss
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("isnull(SUM(PD.CANTIDADADJUDICADA), 0) CANTIDAD, ")
                strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA), 0) MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                strSQL.Append(" AND PD.IDALMACEN=499 ")

                strSQL.Append("group by  ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("DO.CORRELATIVORENGLON, ")
                strSQL.Append("P.NOMBRE, ")
                strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                strSQL.Append("CP.DESCRIPCION, ")
                strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("DO.MARCA, ")
                strSQL.Append("DO.ORIGEN, ")
                strSQL.Append("DO.VENCIMIENTO, ")
                strSQL.Append("DO.CASAREPRESENTADA, ")
                strSQL.Append("DO.NUMEROCSSP, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("DPC.OBSERVACIONFIRME ")


                strSQL.Append("UNION ")
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("null OFERTA, ")
                strSQL.Append("null ALTERNATIVA, ")
                strSQL.Append("'' PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("case ")
                strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                strSQL.Append("    else 'NO ADJUDICADO' ")
                strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("null CANTIDAD, ")
                strSQL.Append("null PRECIOUNITARIO, ")
                strSQL.Append("null MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("                        AND A.CANTIDADADJUDICADA > 0) ")
                strSQL.Append("OR DO.RENGLON is null) ")
                strSQL.Append("ORDER BY RENGLON ")

                '------------------------------------
                strSQL.Append("SELECT ")
                strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                strSQL.Append("OPC.IDPROVEEDOR, ")
                strSQL.Append("DO.RENGLON, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
                strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
                strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                strSQL.Append("IF NOT EXISTS ")
                strSQL.Append("    ( ")
                strSQL.Append("        SELECT ")
                strSQL.Append("            TIPOPLANTILLA ")
                strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("        AND TIPOPLANTILLA =2 ")
                strSQL.Append("    ) ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    CODIGOFUENTE TEXTO ")
                strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
                strSQL.Append("    WHERE TIPOPLANTILLA = 2 ")
                strSQL.Append("END ")
                strSQL.Append("ELSE ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    TEXTO ")
                strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("    AND TIPOPLANTILLA = 2 ")
                strSQL.Append("END ")
        End Select



        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim tables(2) As String
        tables(0) = New String("dtValorizacionPorRenglon")
        tables(1) = New String("ResolucionAdjudicacion")
        tables(2) = New String("Encabezado")
        'If idalmacen = 0 Then
        '    Dim X As New dbPROGRAMADISTRIBUCION
        '    If X.ObtenerAlmacenFosIsss(IDESTABLECIMIENTO, IDPROCESOCOMPRA) <> 0 Then
        '        tables(2) = New String("ResolucionAdjudicacion2")
        '        tables(3) = New String("ResolucionAdjudicacion3")
        '        tables(4) = New String("Encabezado")
        '    Else
        '        tables(2) = New String("Encabezado")
        '    End If
        'Else
        '    tables(2) = New String("Encabezado")
        'End If

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    ''' <summary>
    ''' Información del detalle de proceso de compra relacionada a la resolución de adjudicación en firme
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="ds"></param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' <item>SAB_UACI_DETALLEOFERTA</item>
    ''' <item>vv_CATALOGOPRODUCTOS</item>
    ''' <item>SAB_CAT_ESTADOSCALIFICACIONES</item>
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' <item>SAB_UACI_NOTASACEPTACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ResolucionAdjudicacionEnFirme(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByRef ds As DataSet, ByVal idalmacen As Integer) As Integer

        Dim strSQL As New Text.StringBuilder

        Select Case IDALMACEN
            Case Is = 0
                Dim X As New dbPROGRAMADISTRIBUCION
                If X.ObtenerAlmacenFosIsss(IDESTABLECIMIENTO, IDPROCESOCOMPRA) = 0 Then
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                    strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                    strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                    strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                    strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                    strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                    strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                    strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("isnull(A.CANTIDADFIRME, 0) CANTIDAD, ")
                    strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                    strSQL.Append("isnull(DO.PRECIOUNITARIO * A.CANTIDADFIRME, 0) MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")
                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")
                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADFIRME > 0 ")

                    strSQL.Append("UNION ")
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("null OFERTA, ")
                    strSQL.Append("null ALTERNATIVA, ")
                    strSQL.Append("'' PROVEEDOR, ")
                    strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("case ")
                    strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                    strSQL.Append("    else 'NO ADJUDICADO' ")
                    strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("null CANTIDAD, ")
                    strSQL.Append("null PRECIOUNITARIO, ")
                    strSQL.Append("null MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                    strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                    strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                    strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                    strSQL.Append("OR DO.RENGLON is null) ")
                    strSQL.Append("ORDER BY RENGLON ")

                    '------------------------------------
                    strSQL.Append("SELECT ")
                    strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                    strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                    strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
                    strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    strSQL.Append("IF NOT EXISTS ")
                    strSQL.Append("    ( ")
                    strSQL.Append("        SELECT ")
                    strSQL.Append("            TIPOPLANTILLA ")
                    strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                    strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("        AND TIPOPLANTILLA = 3 ")
                    strSQL.Append("    ) ")
                    strSQL.Append("BEGIN ")
                    strSQL.Append("    SELECT ")
                    strSQL.Append("    CODIGOFUENTE TEXTO ")
                    strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
                    strSQL.Append("    WHERE TIPOPLANTILLA = 3 ")
                    strSQL.Append("END ")
                    strSQL.Append("ELSE ")
                    strSQL.Append("BEGIN ")
                    strSQL.Append("    SELECT ")
                    strSQL.Append("    TEXTO ")
                    strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                    strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("    AND TIPOPLANTILLA = 3 ")
                    strSQL.Append("END ")
                Else

                    'mspas

                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                    strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                    strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                    strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                    strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                    strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                    strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                    strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("isnull(SUM(AEA.CANTIDAD), 0) CANTIDAD, ")
                    strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                    strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * AEA.CANTIDAD), 0) MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES, ")
                    strSQL.Append(" 1 as IDAGRUPACION, 'MSPAS' AS NOMBREGRUPO ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    strSQL.Append(" AND AEA.IDALMACEN NOT IN (114,499) ")

                    strSQL.Append("group by  ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("DO.CORRELATIVORENGLON, ")
                    strSQL.Append("P.NOMBRE, ")
                    strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                    strSQL.Append("CP.DESCRIPCION, ")
                    strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("DO.MARCA, ")
                    strSQL.Append("DO.ORIGEN, ")
                    strSQL.Append("DO.VENCIMIENTO, ")
                    strSQL.Append("DO.CASAREPRESENTADA, ")
                    strSQL.Append("DO.NUMEROCSSP, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("DPC.OBSERVACIONFIRME ")

                    strSQL.Append(" UNION ")

                    'fosalud
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                    strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                    strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                    strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                    strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                    strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                    strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                    strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("isnull(SUM(AEA.CANTIDAD), 0) CANTIDAD, ")
                    strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                    strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * AEA.CANTIDAD), 0) MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES, ")
                    strSQL.Append(" 2 as IDAGRUPACION, 'FOSALUD' AS NOMBREGRUPO ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    strSQL.Append(" AND AEA.IDALMACEN=114 ")

                    strSQL.Append("group by  ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("DO.CORRELATIVORENGLON, ")
                    strSQL.Append("P.NOMBRE, ")
                    strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                    strSQL.Append("CP.DESCRIPCION, ")
                    strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("DO.MARCA, ")
                    strSQL.Append("DO.ORIGEN, ")
                    strSQL.Append("DO.VENCIMIENTO, ")
                    strSQL.Append("DO.CASAREPRESENTADA, ")
                    strSQL.Append("DO.NUMEROCSSP, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("DPC.OBSERVACIONFIRME ")

                    strSQL.Append(" UNION ")

                    'isss
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                    strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                    strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                    strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                    strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                    strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                    strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                    strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                    strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("isnull(SUM(AEA.CANTIDAD), 0) CANTIDAD, ")
                    strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                    strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * AEA.CANTIDAD), 0) MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES, ")
                    strSQL.Append(" 3 as IDAGRUPACION, 'ISSS' AS NOMBREGRUPO ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    strSQL.Append(" AND AEA.IDALMACEN=499 ")

                    strSQL.Append("group by  ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("DO.CORRELATIVORENGLON, ")
                    strSQL.Append("P.NOMBRE, ")
                    strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                    strSQL.Append("CP.DESCRIPCION, ")
                    strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("DO.MARCA, ")
                    strSQL.Append("DO.ORIGEN, ")
                    strSQL.Append("DO.VENCIMIENTO, ")
                    strSQL.Append("DO.CASAREPRESENTADA, ")
                    strSQL.Append("DO.NUMEROCSSP, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("DPC.OBSERVACIONFIRME ")

                    '--------------
                    strSQL.Append("UNION ")
                    strSQL.Append("SELECT ")
                    strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("DPC.RENGLON, ")
                    strSQL.Append("null OFERTA, ")
                    strSQL.Append("null ALTERNATIVA, ")
                    strSQL.Append("'' PROVEEDOR, ")
                    strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                    strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                    strSQL.Append("case ")
                    strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                    strSQL.Append("    else 'NO ADJUDICADO' ")
                    strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                    strSQL.Append("null CANTIDAD, ")
                    strSQL.Append("null PRECIOUNITARIO, ")
                    strSQL.Append("null MONTO, ")
                    strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES, ")
                    strSQL.Append(" 4 AS IDAGRUPACION, '' AS NOMBREGRUPO ")

                    strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                    strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                    strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                    strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                    strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                    strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                    strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                    strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                    strSQL.Append("OR DO.RENGLON is null) ")
                    strSQL.Append("ORDER BY RENGLON ")

                    '------------------------------------

                    'SUBREPORTE MSPAS
                    strSQL.Append("SELECT ")
                    strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("sum(AEA.CANTIDAD) CANTIDADADJUDICADA, ")
                    strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
                    strSQL.Append(" 1 AS IDAGRUPACION, 'MSPAS' AS AGRUPACION ")

                    strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")


                    strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    strSQL.Append("AND AEA.IDALMACEN NOT IN (114,499) ")

                    strSQL.Append("GROUP BY OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("P.NOMBRE ")

                    ' strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    strSQL.Append(" UNION ")

                    strSQL.Append("SELECT ")
                    strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("sum(AEA.CANTIDAD) CANTIDADADJUDICADA, ")
                    strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
                    strSQL.Append(" 2 AS IDAGRUPACION, 'FOSALUD' AS AGRUPACION ")

                    strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")


                    strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    strSQL.Append("AND AEA.IDALMACEN=114 ")

                    strSQL.Append("GROUP BY OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("P.NOMBRE ")

                    'strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    strSQL.Append(" UNION ")

                    strSQL.Append("SELECT ")
                    strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("sum(AEA.CANTIDAD) CANTIDADADJUDICADA, ")
                    strSQL.Append("P.NOMBRE AS PROVEEDOR, ")
                    strSQL.Append(" 3 AS IDAGRUPACION, 'ISSS' AS AGRUPACION ")

                    strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")

                    strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                    strSQL.Append("INNER JOIN SAB_UACI_ENTREGAADJUDICACION EA ")
                    strSQL.Append("ON EA.IDESTABLECIMIENTO=A.IDESTABLECIMIENTO AND ")
                    strSQL.Append("EA.IDPROCESOCOMPRA=A.IDPROCESOCOMPRA AND ")
                    strSQL.Append("EA.IDPROVEEDOR=A.IDPROVEEDOR AND ")
                    strSQL.Append("EA.IDDETALLE = A.IDDETALLE ")

                    strSQL.Append("INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
                    strSQL.Append("ON AEA.IDESTABLECIMIENTO=EA.IDESTABLECIMIENTO AND ")
                    strSQL.Append("AEA.IDPROCESOCOMPRA=EA.IDPROCESOCOMPRA AND ")
                    strSQL.Append("AEA.IDPROVEEDOR=EA.IDPROVEEDOR AND ")
                    strSQL.Append("AEA.IDDETALLE=EA.IDDETALLE AND ")
                    strSQL.Append("AEA.IDENTREGA = EA.IDENTREGA ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")


                    strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    strSQL.Append("AND AEA.IDALMACEN=499 ")

                    strSQL.Append("GROUP BY OPC.IDESTABLECIMIENTO, ")
                    strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    strSQL.Append("OPC.IDPROVEEDOR, ")
                    strSQL.Append("DO.RENGLON, ")
                    strSQL.Append("DO.PRECIOUNITARIO, ")
                    strSQL.Append("RO.ORDENLLEGADA, ")
                    strSQL.Append("P.NOMBRE ")

                    'strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    ''SUBREPORTE FOSALUD
                    'strSQL.Append("SELECT ")
                    'strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    'strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    'strSQL.Append("OPC.IDPROVEEDOR, ")
                    'strSQL.Append("DO.RENGLON, ")
                    'strSQL.Append("DO.PRECIOUNITARIO, ")
                    'strSQL.Append("RO.ORDENLLEGADA, ")
                    'strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                    'strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                    'strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    'strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    'strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    'strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    'strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    'strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")

                    'strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    'strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    'strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    'strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    'strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")


                    'strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    'strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    'strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    'strSQL.Append("AND PD.IDALMACEN=114 ")
                    'strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    ''SUBREPORTE ISSS
                    'strSQL.Append("SELECT ")
                    'strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                    'strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                    'strSQL.Append("OPC.IDPROVEEDOR, ")
                    'strSQL.Append("DO.RENGLON, ")
                    'strSQL.Append("DO.PRECIOUNITARIO, ")
                    'strSQL.Append("RO.ORDENLLEGADA, ")
                    'strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                    'strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                    'strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                    'strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                    'strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                    'strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                    'strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                    'strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")

                    'strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                    'strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                    'strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                    'strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                    'strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")

                    'strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                    'strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                    'strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                    'strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")


                    'strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    'strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    'strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                    'strSQL.Append("AND PD.IDALMACEN=499 ")
                    'strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                    strSQL.Append("IF NOT EXISTS ")
                    strSQL.Append("    ( ")
                    strSQL.Append("        SELECT ")
                    strSQL.Append("            TIPOPLANTILLA ")
                    strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                    strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("        AND TIPOPLANTILLA = 3 ")
                    strSQL.Append("    ) ")
                    strSQL.Append("BEGIN ")
                    strSQL.Append("    SELECT ")
                    strSQL.Append("    CODIGOFUENTE TEXTO ")
                    strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
                    strSQL.Append("    WHERE TIPOPLANTILLA = 3 ")
                    strSQL.Append("END ")
                    strSQL.Append("ELSE ")
                    strSQL.Append("BEGIN ")
                    strSQL.Append("    SELECT ")
                    strSQL.Append("    TEXTO ")
                    strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                    strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                    strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                    strSQL.Append("    AND TIPOPLANTILLA = 3 ")
                    strSQL.Append("END ")

                End If

            Case Is = 1
                'mspas
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("isnull(SUM(PD.CANTIDADADJUDICADA), 0) CANTIDAD, ")
                strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA), 0) MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                strSQL.Append(" AND PD.IDALMACEN NOT IN (114,116,499) ")

                strSQL.Append("group by  ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("DO.CORRELATIVORENGLON, ")
                strSQL.Append("P.NOMBRE, ")
                strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                strSQL.Append("CP.DESCRIPCION, ")
                strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("DO.MARCA, ")
                strSQL.Append("DO.ORIGEN, ")
                strSQL.Append("DO.VENCIMIENTO, ")
                strSQL.Append("DO.CASAREPRESENTADA, ")
                strSQL.Append("DO.NUMEROCSSP, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("DPC.OBSERVACIONFIRME ")


                strSQL.Append("UNION ")
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("null OFERTA, ")
                strSQL.Append("null ALTERNATIVA, ")
                strSQL.Append("'' PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("case ")
                strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                strSQL.Append("    else 'NO ADJUDICADO' ")
                strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("null CANTIDAD, ")
                strSQL.Append("null PRECIOUNITARIO, ")
                strSQL.Append("null MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                strSQL.Append("OR DO.RENGLON is null) ")
                strSQL.Append("ORDER BY RENGLON ")

                '------------------------------------
                strSQL.Append("SELECT ")
                strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                strSQL.Append("OPC.IDPROVEEDOR, ")
                strSQL.Append("DO.RENGLON, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
                strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                strSQL.Append("IF NOT EXISTS ")
                strSQL.Append("    ( ")
                strSQL.Append("        SELECT ")
                strSQL.Append("            TIPOPLANTILLA ")
                strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("        AND TIPOPLANTILLA = 3 ")
                strSQL.Append("    ) ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    CODIGOFUENTE TEXTO ")
                strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
                strSQL.Append("    WHERE TIPOPLANTILLA = 3 ")
                strSQL.Append("END ")
                strSQL.Append("ELSE ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    TEXTO ")
                strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("    AND TIPOPLANTILLA = 3 ")
                strSQL.Append("END ")
            Case Is = 114
                'fosalud
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("isnull(SUM(PD.CANTIDADADJUDICADA), 0) CANTIDAD, ")
                strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA), 0) MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                strSQL.Append(" AND PD.IDALMACEN in (114,116) ")

                strSQL.Append("group by  ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("DO.CORRELATIVORENGLON, ")
                strSQL.Append("P.NOMBRE, ")
                strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                strSQL.Append("CP.DESCRIPCION, ")
                strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("DO.MARCA, ")
                strSQL.Append("DO.ORIGEN, ")
                strSQL.Append("DO.VENCIMIENTO, ")
                strSQL.Append("DO.CASAREPRESENTADA, ")
                strSQL.Append("DO.NUMEROCSSP, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("DPC.OBSERVACIONFIRME ")


                strSQL.Append("UNION ")
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("null OFERTA, ")
                strSQL.Append("null ALTERNATIVA, ")
                strSQL.Append("'' PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("case ")
                strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                strSQL.Append("    else 'NO ADJUDICADO' ")
                strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("null CANTIDAD, ")
                strSQL.Append("null PRECIOUNITARIO, ")
                strSQL.Append("null MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                strSQL.Append("OR DO.RENGLON is null) ")
                strSQL.Append("ORDER BY RENGLON ")

                '------------------------------------
                strSQL.Append("SELECT ")
                strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                strSQL.Append("OPC.IDPROVEEDOR, ")
                strSQL.Append("DO.RENGLON, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
                strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                strSQL.Append("IF NOT EXISTS ")
                strSQL.Append("    ( ")
                strSQL.Append("        SELECT ")
                strSQL.Append("            TIPOPLANTILLA ")
                strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("        AND TIPOPLANTILLA = 3 ")
                strSQL.Append("    ) ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    CODIGOFUENTE TEXTO ")
                strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
                strSQL.Append("    WHERE TIPOPLANTILLA = 3 ")
                strSQL.Append("END ")
                strSQL.Append("ELSE ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    TEXTO ")
                strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("    AND TIPOPLANTILLA = 3 ")
                strSQL.Append("END ")
            Case Is = 499
                'isss
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("isnull(RO.ORDENLLEGADA, 0) OFERTA, ")
                strSQL.Append("isnull(DO.CORRELATIVORENGLON, 0) ALTERNATIVA, ")
                strSQL.Append("isnull(P.NOMBRE, '') PROVEEDOR, ")
                strSQL.Append("CP.CORRPRODUCTO + char(10) + CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("isnull(rtrim(DO.DESCRIPCIONPROVEEDOR) + char(10), '') + ")
                strSQL.Append("isnull('Marca: '+ rtrim(DO.MARCA) + char(10), '') + ")
                strSQL.Append("isnull('Origen: ' + rtrim(DO.ORIGEN) + char(10), '') + ")
                strSQL.Append("isnull('Vencimiento: ' + rtrim(DO.VENCIMIENTO) + char(10), '') + ")
                strSQL.Append("isnull('Casa representada: ' + rtrim(DO.CASAREPRESENTADA) + char(10), '') + ")
                strSQL.Append("isnull('CSSP: ' + rtrim(DO.NUMEROCSSP), '') DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("isnull(SUM(PD.CANTIDADADJUDICADA), 0) CANTIDAD, ")
                strSQL.Append("isnull(DO.PRECIOUNITARIO, 0) PRECIOUNITARIO, ")
                strSQL.Append("isnull(SUM(DO.PRECIOUNITARIO * PD.CANTIDADADJUDICADA), 0) MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = RO.IDPROVEEDOR) ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON DO.IDPROVEEDOR = P.IDPROVEEDOR ")

                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON (DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE) ")

                strSQL.Append("INNER JOIN SAB_UACI_PROGRAMADISTRIBUCION PD ")
                strSQL.Append("ON (PD.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND PD.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND PD.RENGLON = DO.RENGLON) ")

                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                strSQL.Append(" AND PD.IDALMACEN=499 ")

                strSQL.Append("group by  ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("DO.CORRELATIVORENGLON, ")
                strSQL.Append("P.NOMBRE, ")
                strSQL.Append("CP.CORRPRODUCTO, CP.DESCLARGO, ")
                strSQL.Append("CP.DESCRIPCION, ")
                strSQL.Append("DO.DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("DO.MARCA, ")
                strSQL.Append("DO.ORIGEN, ")
                strSQL.Append("DO.VENCIMIENTO, ")
                strSQL.Append("DO.CASAREPRESENTADA, ")
                strSQL.Append("DO.NUMEROCSSP, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("DPC.OBSERVACIONFIRME ")


                strSQL.Append("UNION ")
                strSQL.Append("SELECT ")
                strSQL.Append("DPC.IDESTABLECIMIENTO, ")
                strSQL.Append("DPC.RENGLON, ")
                strSQL.Append("null OFERTA, ")
                strSQL.Append("null ALTERNATIVA, ")
                strSQL.Append("'' PROVEEDOR, ")
                strSQL.Append("CP.DESCLARGO DESCRIPCIONGENERICA, ")
                strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
                strSQL.Append("case ")
                strSQL.Append("    when DO.DESCRIPCIONPROVEEDOR is null then 'DESIERTO' ")
                strSQL.Append("    else 'NO ADJUDICADO' ")
                strSQL.Append("end DESCRIPCIONPROVEEDOR, ")
                strSQL.Append("null CANTIDAD, ")
                strSQL.Append("null PRECIOUNITARIO, ")
                strSQL.Append("null MONTO, ")
                strSQL.Append("isnull(DPC.OBSERVACIONFIRME, '') OBSERVACIONES ")
                strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
                strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
                strSQL.Append("ON DPC.IDPRODUCTO = CP.IDPRODUCTO ")
                strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON (DPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND DPC.RENGLON = DO.RENGLON) ")
                strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND (DPC.RENGLON NOT IN (SELECT DISTINCT RENGLON ")
                strSQL.Append("                        FROM SAB_UACI_DETALLEOFERTA DO1 ")
                strSQL.Append("                        LEFT OUTER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("                        ON (DO1.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("                        AND DO1.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("                        AND DO1.IDDETALLE = A.IDDETALLE) ")
                strSQL.Append("                        WHERE DO1.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("                        AND DO1.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("                        AND A.CANTIDADFIRME > 0) ")
                strSQL.Append("OR DO.RENGLON is null) ")
                strSQL.Append("ORDER BY RENGLON ")

                '------------------------------------
                strSQL.Append("SELECT ")
                strSQL.Append("OPC.IDESTABLECIMIENTO, ")
                strSQL.Append("OPC.IDPROCESOCOMPRA, ")
                strSQL.Append("OPC.IDPROVEEDOR, ")
                strSQL.Append("DO.RENGLON, ")
                strSQL.Append("DO.PRECIOUNITARIO, ")
                strSQL.Append("RO.ORDENLLEGADA, ")
                strSQL.Append("A.CANTIDADFIRME CANTIDADADJUDICADA, ")
                strSQL.Append("P.NOMBRE AS PROVEEDOR ")
                strSQL.Append("FROM SAB_UACI_OFERTAPROCESOCOMPRA OPC ")
                strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO ")
                strSQL.Append("ON OPC.IDPROVEEDOR = DO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO ")
                strSQL.Append("ON OPC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA ")
                strSQL.Append("AND OPC.IDPROVEEDOR = RO.IDPROVEEDOR ")
                strSQL.Append("AND OPC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO ")
                strSQL.Append("INNER JOIN SAB_UACI_ADJUDICACION A ")
                strSQL.Append("ON DO.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA ")
                strSQL.Append("AND DO.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO ")
                strSQL.Append("AND DO.IDPROVEEDOR = A.IDPROVEEDOR ")
                strSQL.Append("AND DO.IDDETALLE = A.IDDETALLE ")
                strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
                strSQL.Append("ON OPC.IDPROVEEDOR = P.IDPROVEEDOR ")
                strSQL.Append("WHERE OPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("AND OPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("AND A.CANTIDADFIRME > 0 ")
                strSQL.Append("ORDER BY OPC.IDPROVEEDOR ")

                strSQL.Append("IF NOT EXISTS ")
                strSQL.Append("    ( ")
                strSQL.Append("        SELECT ")
                strSQL.Append("            TIPOPLANTILLA ")
                strSQL.Append("        FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("        WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("        AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("        AND TIPOPLANTILLA = 3 ")
                strSQL.Append("    ) ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    CODIGOFUENTE TEXTO ")
                strSQL.Append("    FROM SAB_CAT_PLANTILLAS ")
                strSQL.Append("    WHERE TIPOPLANTILLA = 3 ")
                strSQL.Append("END ")
                strSQL.Append("ELSE ")
                strSQL.Append("BEGIN ")
                strSQL.Append("    SELECT ")
                strSQL.Append("    TEXTO ")
                strSQL.Append("    FROM SAB_UACI_DETALLEPLANTILLAPROCESOCOMPRA ")
                strSQL.Append("    WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
                strSQL.Append("    AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
                strSQL.Append("    AND TIPOPLANTILLA = 3 ")
                strSQL.Append("END ")
        End Select



        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim tables(2) As String
        tables(0) = New String("dtValorizacionPorRenglon")
        tables(1) = New String("ResolucionAdjudicacion")
        tables(2) = New String("Encabezado")
        'If idalmacen = 0 Then
        '    Dim X As New dbPROGRAMADISTRIBUCION
        '    If X.ObtenerAlmacenFosIsss(IDESTABLECIMIENTO, IDPROCESOCOMPRA) <> 0 Then
        '        tables(2) = New String("ResolucionAdjudicacion2")
        '        tables(3) = New String("ResolucionAdjudicacion3")
        '        tables(4) = New String("Encabezado")
        '    Else
        '        tables(2) = New String("Encabezado")
        '    End If
        'Else
        '    tables(2) = New String("Encabezado")
        'End If

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    ''' <summary>
    ''' Validar si el proceso de compra es de medicamentos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <returns>Valor entero con el resultado de la consulta</returns>

    Public Function EsCompraMedicamentos(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DPC.IDPRODUCTO ")
        strSQL.Append("FROM SAB_UACI_DETALLEPROCESOCOMPRA DPC INNER JOIN vv_CATALOGOPRODUCTOS VV ")
        strSQL.Append("ON DPC.IDPRODUCTO = VV.IDPRODUCTO ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND VV.IDSUMINISTRO = 1 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count > 0 Then
            'MEDICAMENTOS
            Return 1
        Else
            'NO MEDICAMENTOS
            Return 0
        End If
    End Function
    ''' <summary>
    ''' Actualizar el estado del detalle de compras
    ''' </summary>
    ''' <param name="aEntidad">Identificación de la entidad detalleprocesodecompra</param>
    ''' <returns>Valor entero on el resultado de la actualización</returns>

    Public Function ActualizarEstadoNoDesierto(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append("SET IDESTADOCALIFICACION = 1, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = aEntidad.RENGLON
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Consulta de resumen de las evaluaciones por renglon de un proceso de compra
    ''' </summary>
    ''' <param name="aEntidad">identificador de la entidad detalleProcesoDeCompra</param>
    ''' <returns>Valor entero con el resultado de la consulta</returns>
    Public Function ResumenProcesoEvalxRenglon(ByVal aEntidad As DETALLEPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT do.renglon, ")
        strSQL.Append("         CASE  ")
        strSQL.Append("         WHEN (CASE WHEN (ER.ENTREGADO1 <> 0 AND ER.ENTREGADO2 <> 0) THEN ER.ENTREGADO2 ELSE ER.ENTREGADO1 END) = 1 THEN 'CUMPLE'  ")
        strSQL.Append("         WHEN (CASE WHEN (ER.ENTREGADO1 <> 0 AND ER.ENTREGADO2 <> 0) THEN ER.ENTREGADO2 ELSE ER.ENTREGADO1 END) = 2 THEN 'NO CUMPLE'  ")
        strSQL.Append("         WHEN (CASE WHEN (ER.ENTREGADO1 <> 0 AND ER.ENTREGADO2 <> 0) THEN ER.ENTREGADO2 ELSE ER.ENTREGADO1 END) = 3 THEN 'NO APLICA'  ")
        strSQL.Append("         END AS ENTREGADO, SUM(entregado1) as totalDoc, ")
        strSQL.Append("         RO.ORDENLLEGADA AS NOFERTA ")
        strSQL.Append("         FROM SAB_UACI_PROCESOCOMPRAS PC  ")
        strSQL.Append("         INNER JOIN SAB_CAT_TIPOCOMPRAS TC  ")
        strSQL.Append("         ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA  ")
        strSQL.Append("         INNER JOIN SAB_UACI_EXAMENRENGLON ER  ")
        strSQL.Append("         ON PC.IDESTABLECIMIENTO = ER.IDESTABLECIMIENTO  ")
        strSQL.Append("         AND PC.IDPROCESOCOMPRA = ER.IDPROCESOCOMPRA  ")
        strSQL.Append("         INNER JOIN SAB_CAT_DOCUMENTOSBASE DB  ")
        strSQL.Append("         ON ER.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE  ")
        strSQL.Append("         INNER JOIN SAB_UACI_DETALLEOFERTA DO  ")
        strSQL.Append("         ON ER.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA  ")
        strSQL.Append("         AND ER.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO  ")
        strSQL.Append("         AND ER.IDPROVEEDOR = DO.IDPROVEEDOR  ")
        strSQL.Append("         AND ER.IDDETALLE = DO.IDDETALLE  ")
        strSQL.Append("         INNER JOIN SAB_UACI_RECEPCIONOFERTAS RO  ")
        strSQL.Append("         ON PC.IDESTABLECIMIENTO = RO.IDESTABLECIMIENTO  ")
        strSQL.Append("         AND PC.IDPROCESOCOMPRA = RO.IDPROCESOCOMPRA  ")
        strSQL.Append("         AND DO.IDPROVEEDOR = RO.IDPROVEEDOR  ")
        strSQL.Append("         WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("         AND PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA  group by do.renglon, er.entregado1, entregado2, ro.ordenllegada ")
        strSQL.Append("order by do.renglon ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDPROCESOCOMPRA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function


#End Region

End Class
