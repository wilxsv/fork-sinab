Imports System.Text
Partial Class dbALMACENESENTREGASOLICITUD
    ''' <summary>
    '''  Listado de almacenes y lugares de entrega
    ''' </summary>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <returns>Listado de almacenes en formato dataset</returns>

    Public Function obtenerAlmacenesEntrega(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT")
        strSQL.Append("   AE.IDALMACEN,A.NOMBRE")
        strSQL.Append(" FROM")
        strSQL.Append("   SAB_EST_ALMACENESENTREGA AE INNER JOIN SAB_CAT_ALMACENES A ON A.IDALMACEN=AE.IDALMACEN")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDESTABLECIMIENTO = @IDESTABLECIMIENTO")
        strSQL.Append("   AND IDSOLICITUD = @IDSOLICITUD")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = idsolicitud
        Dim dS As New DataSet

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo para borrar los almacenes de entrega 
    ''' </summary>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="tran">Variable de tipo transacción</param>
    ''' <returns>Variable entera que representa la ejecucion del metodo</returns>

    Public Function borrarAlmacenesEntrega(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" DELETE FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGA")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDALMACEN=@IDALMACEN")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = IDALMACEN

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function borrarAlmacenesEntregaSolicitud(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" DELETE FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo para ingresar almacenes y lugares de entrega 
    ''' </summary>
    ''' <param name="eEntidad">Entidad que representa la tabla almacenesentrega</param>
    ''' <param name="tran">Variable de tipo transacción</param>
    ''' <returns>Variable entera que representa la ejecucion del metodo</returns>

    Public Function ingresarALMACENESENTREGA(ByVal eEntidad As ALMACENESENTREGA, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" INSERT INTO")
        strSQL.Append("   SAB_EST_ALMACENESENTREGA")
        strSQL.Append("     (IDSOLICITUD, IDESTABLECIMIENTO, IDALMACEN, AUUSUARIOCREACION,")
        strSQL.Append("     AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION)")
        strSQL.Append(" VALUES(")
        strSQL.Append("   @IDSOLICITUD, @IDESTABLECIMIENTO,@IDALMACEN, @AUUSUARIOCREACION,")
        strSQL.Append("   @AUFECHACREACION, NULL, NULL)")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = eEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = eEntidad.IDALMACEN
        args(2) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(2).Value = eEntidad.AUUSUARIOCREACION
        args(3) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(3).Value = eEntidad.AUFECHACREACION
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = eEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Eliminar los almacenes de entrega de una solicitud
    ''' </summary>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="IDALMACENENTREGA">Identificador del almacen de entrega</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="RENGLON">Identificacion del renglon</param>
    ''' <param name="IDPRODUCTO">Identificacion del producto</param>
    ''' <param name="tran">Variable de tipo transacción</param>
    ''' <returns>Variable entera que representa la ejecucion del metodo</returns>

    Public Function borrarAlmacenesEntregaSolicitud(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACENENTREGA As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal RENGLON As Integer, ByVal IDPRODUCTO As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" DELETE FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDALMACENENTREGA=@IDALMACENENTREGA AND IDFUENTEFINANCIAMIENTO=@IDFUENTEFINANCIAMIENTO AND RENGLON=@RENGLON AND IDPRODUCTO=@IDPRODUCTO")


        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(2).Value = IDALMACENENTREGA
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Value = IDFUENTEFINANCIAMIENTO
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = RENGLON
        args(5) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(5).Value = IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo que obtiene la cantidad total de un producto
    ''' </summary>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="IDALMACENENTREGA">Identificador del almacen de entrega</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <param name="IDPRODUCTO">Identificador del producto</param>
    ''' <returns>Valor entero con la cantidad total</returns>

    Public Function ObtenerSumaCantidad(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACENENTREGA As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal RENGLON As Integer, ByVal IDPRODUCTO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT isnull(SUM(CANTIDAD),0) FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDALMACENENTREGA=@IDALMACENENTREGA AND IDFUENTEFINANCIAMIENTO=@IDFUENTEFINANCIAMIENTO AND RENGLON=@RENGLON AND IDPRODUCTO=@IDPRODUCTO ")


        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(2).Value = IDALMACENENTREGA
        args(3) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(3).Value = IDFUENTEFINANCIAMIENTO
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = RENGLON
        args(5) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(5).Value = IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    Public Function ObtenerMontosxFuente(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT IDFUENTEFINANCIAMIENTO, SUM(CANTIDAD*PRECIOUNITARIO) AS MONTO FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")
        strSQL.Append("   GROUP BY IDFUENTEFINANCIAMIENTO ")


        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO


        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    ''' <summary>
    ''' Metodo que actualiza la cantidad en almacenesentregasolicitud
    ''' </summary>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="iddetalle"></param>
    ''' <param name="RENGLON">Identificador del renglon</param>
    ''' <param name="IDPRODUCTO">Identificador del producto</param>
    ''' <param name="idalmacen">Identificador del almacen</param>
    ''' <param name="idfuente">Identificador de la fuente</param>
    ''' <param name="cantidad">Identificador de la cantidad</param>
    ''' <param name="tran">Variable de tipo transacción</param>
    ''' <returns>Un valor entero que representa el éxito de ejecución del método</returns>

    Public Function ActualizarCantidad(ByVal idestablecimiento As Integer, ByVal idsolicitud As Integer, ByVal IDENTREGA As Integer, ByVal NUMEROENTREGA As Integer, ByVal renglon As Integer, ByVal idproducto As Integer, ByVal idalmacen As Integer, ByVal idfuente As Integer, ByVal cantidad As Integer, ByVal preciounitario As Decimal, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" UPDATE  ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD ")
        strSQL.Append("     SET CANTIDAD=@CANTIDAD ,PRECIOUNITARIO=@PRECIOUNITARIO")
        strSQL.Append(" WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND  IDSOLICITUD=@IDSOLICITUD AND IDENTREGA=@IDENTREGA AND NUMEROENTREGA=@NUMEROENTREGA AND RENGLON=@RENGLON AND IDPRODUCTO=@IDPRODUCTO AND IDALMACENENTREGA=@IDALMACEN AND IDFUENTEFINANCIAMIENTO=@IDFUENTEFINANCIAMIENTO;  ")
        
        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = idsolicitud
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = idalmacen
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.Int)
        args(2).Value = IDENTREGA
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = renglon
        args(4) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(4).Value = idproducto
        args(5) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(5).Value = idfuente
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = idestablecimiento
        args(7) = New SqlParameter("@CANTIDAD", SqlDbType.Int)
        args(7).Value = cantidad
        args(8) = New SqlParameter("@NUMEROENTREGA", SqlDbType.Int)
        args(8).Value = NUMEROENTREGA
        args(9) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Money)
        args(9).Value = preciounitario

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo que valida la existencia de registros en la tabla almacenesentregacontratos
    ''' </summary>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="IDPRODUCTO">Identificador del producto</param>
    ''' <returns>Un valor entero que representa el éxito de ejecución del método</returns>

    Public Function ExistenRegistrosAES(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer, Optional ByVal RENGLON As Integer = 0) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT isnull(SUM(CANTIDAD),0) FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDPRODUCTO=@IDPRODUCTO ")
        If renglon <> 0 Then
            strSQL.Append("   AND RENGLON=@RENGLON ")
        End If


        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO
        If RENGLON <> 0 Then
            args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
            args(3).Value = RENGLON
        End If

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    ''' <summary>
    ''' Metodo que borra los productos de almacenes
    ''' </summary>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="IDPRODUCTO">Identificador del producto</param>
    ''' <param name="tran">Variable de tipo transacción</param>
    ''' <returns>Un valor entero que representa el éxito de ejecución del método</returns>

    Public Function borrarProductoAlmacenesEntregaSolicitud(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer, ByVal IDESPECIFICACION As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" DELETE FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDPRODUCTO=@IDPRODUCTO AND isnull(IDESPECIFICACION,0)=@IDESPECIFICACION")


        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO
        args(3) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(3).Value = IDESPECIFICACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo que valida la existencia de registros en lugares de entrega
    ''' </summary>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <returns>Un valor entero que representa el éxito de ejecución del método</returns>

    Public Function ExistenRegistrosAES_LE(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT ISNULL(SUM(CANTIDAD),0) FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDALMACENENTREGA=@IDALMACEN ")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = IDALMACEN

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    ''' <summary>
    ''' Metodo que valida la existencia de registros en almacenes entrega contratos y formas de entrega
    ''' </summary>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="IDFUENTE">Identificador de la fuente de financiamiento</param>
    ''' <returns>Un valor entero que representa el éxito de ejecución del método</returns>

    Public Function ExistenRegistrosAES_FE(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDFUENTE As Integer) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT ISNULL(SUM(CANTIDAD),0) FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD=@IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDFUENTEFINANCIAMIENTO=@IDFUENTE ")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDFUENTE", SqlDbType.Int)
        args(2).Value = IDFUENTE

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    ''' <summary>
    ''' Metodo para borrar los almacenes y entregas de una solicitud
    ''' </summary>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="tran">Variable de tipo transacción</param>
    ''' <returns>Un valor entero que representa el éxito de ejecución del método</returns>

    Public Function borrarAlmacenesEntregaSolicitud_AE(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" DELETE FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDALMACENENTREGA=@IDALMACEN")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = IDALMACEN

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Metodo para borrar las entregas de los almacenes de una solicitud
    ''' </summary>
    ''' <param name="idsolicitud">Identificador de la solicitud</param>
    ''' <param name="idestablecimiento">Identificador del establecimiento</param>
    ''' <param name="IDFUENTE">Identificador de la fuente</param>
    ''' <param name="tran">Variable de tipo transacción</param>
    ''' <returns>Un valor entero que representa el éxito de ejecución del método</returns>

    Public Function borrarAlmacenesEntregaSolicitud_FF(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDFUENTE As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" DELETE FROM ")
        strSQL.Append("   SAB_EST_ALMACENESENTREGASOLICITUD")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND IDFUENTEFINANCIAMIENTO=@IDFUENTE")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDFUENTE", SqlDbType.Int)
        args(2).Value = IDFUENTE

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
End Class
