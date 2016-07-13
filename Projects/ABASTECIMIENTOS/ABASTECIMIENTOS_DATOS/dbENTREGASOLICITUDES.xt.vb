Partial Public Class dbENTREGASOLICITUDES

#Region " METODOS AGREGADOS "

    ''' <summary>
    ''' Metodo para validar las entregas 
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del Establecimiento</param>
    ''' <param name="IDENTREGA">Identificador de la entrega</param>
    ''' <returns>Retorna un valor booleano para validar la entrega</returns>

    Public Function ValidarIDENTREGA(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDENTREGA As Int16) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_EST_ENTREGASOLICITUDES ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDENTREGA = @IDENTREGA")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.SmallInt)
        args(2).Value = IDENTREGA

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

    ''' <summary>
    ''' eliminar las entregas asociadas a una solicitud
    ''' </summary>
    ''' <param name="aEntidad">entidad tipo ENTREGASOLICITUDES</param> 
    ''' <returns>
    ''' Devuelve uno si completo operacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_ENTREGASOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function EliminarEntregasXsolicitud(ByVal aEntidad As ENTREGASOLICITUDES) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_ENTREGASOLICITUDES ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' validar existencia de entregas para la solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param> identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO">Identificador del Establecimiento</param> identificador de establecimiento
    ''' <returns>
    ''' verdadero si existe entregas asociadas
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_ENTREGASOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>

    Public Function ValidarExistenciaEntregas(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_EST_ENTREGASOLICITUDES ")
        strSQL.Append("WHERE IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

    ''' <summary>
    ''' obtener el detalle para una entrega
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param> identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO">Identificador del Establecimiento</param> identificador del establecimiento
    ''' <param name="IDENTREGA">Identificador de la entrega</param> identificador de entrega
    ''' <returns>
    ''' dataset con el detalle de la entrega
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_ENTREGASOLICITUDES</description></item>
    ''' <item><description>SAB_EST_DETALLEENTREGAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDetalleEntrega(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDENTREGA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT es.IDESTABLECIMIENTO, es.IDSOLICITUD, es.IDENTREGA, de.DIAS, de.PORCENTAJE, fc.DESCRIPCION, de.IDDETALLE ")
        strSQL.Append("FROM SAB_EST_ENTREGASOLICITUDES AS es INNER JOIN ")
        strSQL.Append("SAB_EST_DETALLEENTREGAS AS de ON es.IDSOLICITUD = de.IDSOLICITUD AND es.IDESTABLECIMIENTO = de.IDESTABLECIMIENTO AND ")
        strSQL.Append("es.IDENTREGA = de.IDENTREGA INNER JOIN ")
        strSQL.Append("SAB_CAT_FECHACONTEOS AS fc ON de.FECHACONTEO = fc.IDFECHACONTEO ")
        strSQL.Append("WHERE es.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND es.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND es.IDENTREGA = @IDENTREGA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.BigInt)
        args(2).Value = IDENTREGA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener el número macimo de entregas para una solicitud
    ''' </summary>
    ''' <param name="ARR_SOLICITUD">Arreglo que contiene los codigos de las solitudes que serÃ¡n consolidadas
    '''  identificador del establecimiento</param> 
    ''' <returns>
    ''' Valor entero, que contiene el número mayor de entregas
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_ENTREGASOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Juan José Rivas]      Creado
    ''' </history>
    Public Function obtenerMaximoEntregas(ByVal ARR_SOLICITUD As listaSOLICITUDES) As Integer
        ' Query cambiado en cambios 2010
        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT isnull(MAX(IDDETALLE), 0) AS CANT_ENTREGAS ")
        strSQL.Append(" FROM SAB_EST_ENTREGASOLICITUDES ")

        For Each solic As SOLICITUDES In ARR_SOLICITUD
            Dim i As Integer = ARR_SOLICITUD.IndiceDe(solic)

            If i = 0 Then
                strSQL.Append(" WHERE ")
            Else
                strSQL.Append(" OR ")
            End If
            strSQL.Append(" (IDESTABLECIMIENTO = " & solic.IDESTABLECIMIENTO & " AND IDSOLICITUD = " & solic.IDSOLICITUD & ") ")

        Next

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Obtiene el identificador de la Entrega para cada solicitud
    ''' </summary>
    ''' <param name="ARR_SOLICITUD">arreglo que contiene el id de las solicitudes consolidadas</param> 
    ''' <returns></returns>
    ''' dataset contiene los identificadores de las entregas para las solicitudes
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_ENTREGASOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Juan José Rivas]      Creado
    ''' </history> 
    Public Function ObtenerEntregaSolicitudes(ByVal ARR_SOLICITUD As listaSOLICITUDES) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDENTREGA ")
        strSQL.Append(" FROM SAB_EST_ENTREGASOLICITUDES ")

        For Each solic As SOLICITUDES In ARR_SOLICITUD
            Dim i As Integer = ARR_SOLICITUD.IndiceDe(solic)

            If i = 0 Then
                strSQL.Append(" WHERE ")
            Else
                strSQL.Append(" OR ")
            End If
            strSQL.Append(" (IDESTABLECIMIENTO = " & solic.IDESTABLECIMIENTO & " AND IDSOLICITUD = " & solic.IDSOLICITUD & ") ")
        Next

        strSQL.Append(" GROUP BY IDENTREGA ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Metodo que obtiene un nuevo identificador de entrega
    ''' </summary>
    ''' <param name="aEntidad">Entidad de la tabla entregasolicitudes</param>
    ''' <returns>Valor caracter con el numero de entrega</returns>

    Public Function ObtenerIDEntrega(ByVal aEntidad As ENTREGASOLICITUDES) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(IDENTREGA),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_ENTREGASOLICITUDES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDSOLICITUD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo que devuelve el numero maximo de entregas
    ''' </summary>
    ''' <returns>Valor entero con el numero de entrega</returns>

    Public Function ObtenerMaximoEntregaTemp2() As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT max(ENTREGA)  ")
        strSQL.Append(" FROM temp2 ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Metodo que devuelve el producto y su entrega
    ''' </summary>
    ''' <returns>Lista de productos y entrega en forma de dataset</returns>

    Public Function ObtenerDatosTemp2Entregas1() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select c.idproducto,max(t.entrega) as entrega ")
        strSQL.Append("from temp2 t inner join sab_cat_catalogoproductos c on t.codigo=c.codigo ")
        strSQL.Append("group by c.idproducto ")
        strSQL.Append("order by c.idproducto ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Metodo que devuelve el producto y su entrega
    ''' </summary>
    ''' <param name="idproducto">Identificador del producto</param>
    ''' <returns>Lista de productos y entrega en forma de dataset</returns>

    Public Function ObtenerDatosTemp2Entregas2(ByVal idproducto As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select c.idproducto, t.entrega ")
        strSQL.Append("from temp2 t inner join sab_cat_catalogoproductos c on t.codigo=c.codigo ")
        strSQL.Append("where c.idproducto=@idproducto ")
        strSQL.Append("group by c.idproducto, t.entrega ")
        strSQL.Append("order by c.idproducto ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@idproducto", SqlDbType.Int)
        args(0).Value = idproducto

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

#Region "SAB_EST_ENTREGAS"
    ''' <summary>
    '''  Obtiene el detalle de las entregas
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del Establecimiento</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <returns>Lista de entregas en forma de arreglo</returns>

    Public Function obtenerEntregas(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer) As ArrayList

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT")
        strSQL.Append("   IDENTREGA, NUMEROENTREGA, PORCENTAJEENTREGA, DIASENTREGA")
        strSQL.Append(" FROM")
        strSQL.Append("   SAB_EST_ENTREGAS")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDESTABLECIMIENTO = @IDESTABLECIMIENTO")
        strSQL.Append("   AND IDSOLICITUD = @IDSOLICITUD")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idestablecimiento", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@idsolicitud", SqlDbType.Int)
        args(1).Value = idsolicitud
        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim arr As New ArrayList

        Do While dr.Read
            Dim s(3) As String
            s(0) = dr.Item("IDENTREGA")
            s(1) = dr.Item("NUMEROENTREGA")
            s(2) = dr.Item("PORCENTAJEENTREGA")
            s(3) = dr.Item("DIASENTREGA")
            arr.Add(s)
        Loop

        dr.Close()

        Return arr

    End Function
    ''' <summary>
    ''' Obtiene el numero maximo de entregas
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del Establecimiento</param>
    ''' <returns>El numero maximo de entregas</returns>

    Public Function obtenerTotalEntregas(ByVal idsolicitud As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT ISNULL(MAX(identrega), 0) as ENTREGAS")
        strSQL.Append(" FROM SAB_EST_ENTREGASOLICITUDES ")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("   AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = idsolicitud
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Metodo para actualizar las entregas en tabla solicitudes
    ''' </summary>
    ''' <param name="eEntidad">Entidad que representa la tabla solicitudes</param>
    ''' <param name="tran">Valor que representa la transaccion</param>
    ''' <returns>Valor entero que representa la ejecucion del metodo.</returns>

    Public Function actualizarTotalEntregas(ByVal eEntidad As SOLICITUDES, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" UPDATE")
        strSQL.Append("   SAB_EST_SOLICITUDES")
        strSQL.Append(" SET ENTREGAS=@ENTREGAS, AUUSUARIOMODIFICACION=@AUUSUARIOMODIFICACION, AUFECHAMODIFICACION=@AUFECHAMODIFICACION")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD")
        strSQL.Append("   AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = eEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = eEntidad.AUUSUARIOMODIFICACION
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = eEntidad.AUFECHAMODIFICACION
        args(3) = New SqlParameter("@ENTREGAS", SqlDbType.Int)
        args(3).Value = eEntidad.ENTREGAS
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = eEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo que borra las entregas de la tabla entregas
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del Establecimiento</param>
    ''' <param name="tran">Identificador de la transaccion</param>
    ''' <param name="entregas">Identificador de la entrega</param>
    ''' <returns>Valor entero que representa la ejecucion del metodo.</returns>

    Public Function borrarEntregas(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal tran As DistributedTransaction, Optional ByVal entregas As Integer = -1) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" DELETE FROM ")
        strSQL.Append("   SAB_EST_ENTREGAS")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO")

        If entregas > -1 Then
            strSQL.Append("   AND IDENTREGA > " & entregas)
        End If

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo que ingresa las entregas
    ''' </summary>
    ''' <param name="eEntidad">Entidad que representa la tabla entregasolicitud</param>
    ''' <param name="tran">Valor que representa la transaccion</param>
    ''' <returns>Valor entero que representa la ejecucion del metodo.</returns>

    Public Function ingresarEntregas(ByVal eEntidad As ENTREGASOLICITUD, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" INSERT INTO")
        strSQL.Append("   SAB_EST_ENTREGAS")
        strSQL.Append("     (IDSOLICITUD, IDESTABLECIMIENTO, IDENTREGA, NUMEROENTREGA, PORCENTAJEENTREGA, DIASENTREGA, AUUSUARIOCREACION,")
        strSQL.Append("     AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION)")
        strSQL.Append(" VALUES(")
        strSQL.Append("   @IDSOLICITUD, @IDESTABLECIMIENTO,@IDENTREGA, @NUMEROENTREGA, @PORCENTAJEENTREGA, @DIASENTREGA, @AUUSUARIOCREACION,")
        strSQL.Append("   @AUFECHACREACION, NULL, NULL)")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = eEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDENTREGA", SqlDbType.Int)
        args(1).Value = eEntidad.IDENTREGA
        args(2) = New SqlParameter("@NUMEROENTREGA", SqlDbType.Int)
        args(2).Value = eEntidad.NUMEROENTREGA
        args(3) = New SqlParameter("@PORCENTAJEENTREGA", SqlDbType.Decimal)
        args(3).Value = eEntidad.PORCENTAJEENTREGA
        args(4) = New SqlParameter("@DIASENTREGA", SqlDbType.Int)
        args(4).Value = eEntidad.DIASENTREGA
        args(5) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(5).Value = eEntidad.AUUSUARIOCREACION
        args(6) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(6).Value = eEntidad.AUFECHACREACION
        args(7) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(7).Value = eEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo que obtiene las entregas para prorratear cantidades
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del Establecimiento</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <param name="idproducto">Identificador del producto</param>
    ''' <returns>Listado de entregas en forma de dataset</returns>

    Public Function obtenerEntregasParaProrratear(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer, ByVal renglon As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT")
        strSQL.Append("   E.NUMEROENTREGA, E.PORCENTAJEENTREGA, 0 as cantidad")
        strSQL.Append(" FROM")
        strSQL.Append("   SAB_EST_ENTREGASOLICITUDES ES INNER JOIN SAB_EST_ENTREGAS E ON ES.IDESTABLECIMIENTO=E.IDESTABLECIMIENTO AND ES.IDSOLICITUD=E.IDSOLICITUD AND ES.IDENTREGA=E.IDENTREGA ")
        strSQL.Append(" WHERE")
        strSQL.Append("   ES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")
        strSQL.Append("   AND ES.IDSOLICITUD = @IDSOLICITUD AND ES.IDPRODUCTO=@IDPRODUCTO AND ES.RENGLON=@RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@idestablecimiento", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@idsolicitud", SqlDbType.Int)
        args(1).Value = idsolicitud
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = idproducto
        args(3) = New SqlParameter("@renglon", SqlDbType.Int)
        args(3).Value = renglon

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerNumeroEntregas(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(identrega),0) ")
        'strSQL.Append(" FROM SAB_EST_ENTREGASOLICITUDES ")

        strSQL.Append(" FROM SAB_EST_ENTREGAS ")

        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarEntregasXsolicitudProducto(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal idproducto As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_ENTREGASOLICITUDES ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDPRODUCTO=@IDPRODUCTO")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = idsolicitud
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = idestablecimiento
        args(2) = New SqlParameter("@idproducto", SqlDbType.Int)
        args(2).Value = idproducto

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function actualizarPlazoEntregaSolicitud(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("  DECLARE @dias DECIMAL ")
        strSQL.Append(" 	SET @dias = ( select max(diasentrega) from sab_Est_entregas where idsolicitud=@idsolicitud and  ")
        strSQL.Append(" idestablecimiento=@IDESTABLECIMIENTO ) ")
        strSQL.Append(" 	 ")
        strSQL.Append(" 	UPDATE SAB_EST_SOLICITUDES ")
        strSQL.Append(" 	SET PLAZOENTREGA=@DIAS ")
        strSQL.Append(" 	WHERE 	IDSOLICITUD=@IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = idsolicitud
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = idestablecimiento

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
