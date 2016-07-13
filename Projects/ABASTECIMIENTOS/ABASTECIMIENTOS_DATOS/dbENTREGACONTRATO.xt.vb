Partial Public Class dbENTREGACONTRATO

    ''' <summary>
    ''' Elimina todas las entregas para un contrato determinado.
    ''' </summary>
    ''' <param name="aEntidad">Objeto con el criterio de eliminación.</param>
    ''' <returns>Valor numerico que indica el número de filas afectadas.</returns>
    ''' <remarks>Lista de los elementos que componen el criterio de eliminación:
    ''' <list type="bullet">
    ''' <item><description>IDESTABLECIMIENTO</description></item>
    ''' <item><description>IDPROVEEDOR</description></item>
    ''' <item><description>IDCONTRATO</description></item>
    ''' <item><description>RENGLON</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  08/02/2007    Creado
    ''' </history> 
    Public Function EliminarEntregasContrato(ByVal aEntidad As ENTREGACONTRATO) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = aEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = aEntidad.RENGLON

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtener el numero de entregas de un contrato
    ''' </summary>
    ''' <param name="IDCONTRATO"></param> 'identificador de contrat
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' numero entero de las entregas de un contrato
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerNumeroEntregas(ByVal IDCONTRATO As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(ENTREGA),0) ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND ESTAHABILITADA = 1 ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(1).Value = IDCONTRATO

        Return CInt(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args))

    End Function

    ''' <summary>
    ''' Elimina todas las entregas para un contrato determinado.
    ''' </summary>
    ''' <param name="aEntidad">Objeto con el criterio de eliminación.</param>
    ''' <returns>Valor numerico que indica el número de filas afectadas.</returns>
    ''' <remarks>Lista de los elementos que componen el criterio de eliminación:
    ''' <list type="bullet">
    ''' <item><description>IDESTABLECIMIENTO</description></item>
    ''' <item><description>IDPROVEEDOR</description></item>
    ''' <item><description>IDCONTRATO</description></item>
    ''' <item><description>RENGLON</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  08/02/2007    Creado
    ''' </history> 
    Public Function EliminarEntregasContratoTodas(ByVal aEntidad As ENTREGACONTRATO) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = aEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDCONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerPlazoEntregaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_ENTREGACONTRATO.ENTREGA, SAB_UACI_ENTREGACONTRATO.PLAZOENTREGA, ")
        strSQL.Append(" SAB_UACI_ENTREGACONTRATO.PORCENTAJEENTREGA, SAB_UACI_ENTREGACONTRATO.IDDETALLE, ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDALMACENENTREGA, SAB_UACI_ALMACENESENTREGACONTRATOS.CANTIDADENTREGADA ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO LEFT OUTER JOIN ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS ON ")
        strSQL.Append(" SAB_UACI_ENTREGACONTRATO.IDESTABLECIMIENTO = SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ENTREGACONTRATO.IDPROVEEDOR = SAB_UACI_ALMACENESENTREGACONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ENTREGACONTRATO.IDCONTRATO = SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO AND ")
        strSQL.Append(" SAB_UACI_ENTREGACONTRATO.RENGLON = SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON AND ")
        strSQL.Append(" SAB_UACI_ENTREGACONTRATO.IDDETALLE = SAB_UACI_ALMACENESENTREGACONTRATOS.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_ENTREGACONTRATO.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_ENTREGACONTRATO.IDPROVEEDOR = " & IDPROVEEDOR & ") AND ")
        strSQL.Append(" (SAB_UACI_ENTREGACONTRATO.IDCONTRATO = " & IDCONTRATO & ") AND (SAB_UACI_ENTREGACONTRATO.RENGLON = " & RENGLON & ") AND (SAB_UACI_ENTREGACONTRATO.ESTAHABILITADA = 1) ")
        strSQL.Append(" ORDER BY SAB_UACI_ENTREGACONTRATO.ENTREGA ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerEntregasProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ENTREGA, PLAZOENTREGA, PORCENTAJEENTREGA, IDDETALLE ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDCONTRATO = " & IDCONTRATO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (RENGLON = " & RENGLON & ") AND (ESTAHABILITADA = 1) ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function obtenerEntregasProveedorAmpliacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ENTREGA, PLAZOENTREGA, PORCENTAJEENTREGA, IDDETALLE ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDCONTRATO = " & IDCONTRATO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (RENGLON = " & RENGLON & ") AND (ESTAHABILITADA = 1) AND (ESTASINCRONIZADA = 1)")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ActualizarHabilitados(ByVal aEntidad As ENTREGACONTRATO) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ENTREGACONTRATO SET ")
        strSQL.Append(" ESTAHABILITADA = @ESTAHABILITADA, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@ESTAHABILITADA", SqlDbType.TinyInt)
        args(0).Value = aEntidad.ESTAHABILITADA
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)
        args(5) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(5).Value = IIf(aEntidad.IDPROVEEDOR = Nothing, DBNull.Value, aEntidad.IDPROVEEDOR)
        args(6) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(6).Value = IIf(aEntidad.IDCONTRATO = Nothing, DBNull.Value, aEntidad.IDCONTRATO)
        args(7) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(7).Value = IIf(aEntidad.RENGLON = Nothing, DBNull.Value, aEntidad.RENGLON)
        args(8) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(8).Value = IIf(aEntidad.IDDETALLE = Nothing, DBNull.Value, aEntidad.IDDETALLE)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtieneSumaCantidadEntregada(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As Decimal

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SUM(SAB_UACI_ALMACENESENTREGACONTRATOS.CANTIDADENTREGADA) AS SUMA_CANTIDADENTREGADA, ")
        strSQL.Append(" SAB_UACI_ENTREGACONTRATO.ESTAHABILITADA ")
        strSQL.Append(" FROM SAB_UACI_ALMACENESENTREGACONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_UACI_ENTREGACONTRATO ON ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO = SAB_UACI_ENTREGACONTRATO.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDPROVEEDOR = SAB_UACI_ENTREGACONTRATO.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO = SAB_UACI_ENTREGACONTRATO.IDCONTRATO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON = SAB_UACI_ENTREGACONTRATO.RENGLON AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDDETALLE = SAB_UACI_ENTREGACONTRATO.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_ALMACENESENTREGACONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ") ")
        strSQL.Append(" AND (SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO = " & IDCONTRATO & ") AND (SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON = " & RENGLON & ") ")
        strSQL.Append(" GROUP BY SAB_UACI_ENTREGACONTRATO.ESTAHABILITADA ")
        strSQL.Append(" HAVING (SAB_UACI_ENTREGACONTRATO.ESTAHABILITADA = 1) ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function validaCantidadEntregada(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal IDDETALLE As Integer) As Decimal

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_ALMACENESENTREGACONTRATOS.CANTIDADENTREGADA ")
        strSQL.Append(" FROM SAB_UACI_ALMACENESENTREGACONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_UACI_ENTREGACONTRATO ON ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO = SAB_UACI_ENTREGACONTRATO.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDPROVEEDOR = SAB_UACI_ENTREGACONTRATO.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO = SAB_UACI_ENTREGACONTRATO.IDCONTRATO AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON = SAB_UACI_ENTREGACONTRATO.RENGLON AND ")
        strSQL.Append(" SAB_UACI_ALMACENESENTREGACONTRATOS.IDDETALLE = SAB_UACI_ENTREGACONTRATO.IDDETALLE ")
        strSQL.Append(" WHERE (SAB_UACI_ALMACENESENTREGACONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_ALMACENESENTREGACONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ") ")
        strSQL.Append(" AND (SAB_UACI_ALMACENESENTREGACONTRATOS.IDCONTRATO = " & IDCONTRATO & ") AND (SAB_UACI_ALMACENESENTREGACONTRATOS.RENGLON = " & RENGLON & ") AND ")
        strSQL.Append(" (SAB_UACI_ALMACENESENTREGACONTRATOS.IDDETALLE = " & IDDETALLE & ") AND (SAB_UACI_ENTREGACONTRATO.ESTAHABILITADA = 1) ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtieneEntregasAmpliacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ENTREGA, PLAZOENTREGA, PORCENTAJEENTREGA, IDDETALLE ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ") AND (RENGLON = " & RENGLON & ") AND (ESTAHABILITADA = 1) AND ")
        strSQL.Append(" (ESTASINCRONIZADA > 0) ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ValidarEntrega(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal ENTREGA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT COUNT(*) AS Expr1 ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ") AND (RENGLON = " & RENGLON & ") AND (ENTREGA = " & ENTREGA & ") AND (ESTASINCRONIZADA > 0) ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ActualizarAmpliacion(ByVal aEntidad As ENTREGACONTRATO) As Integer

        Dim lID As Long
        If aEntidad.IDDETALLE = 0 _
            Or aEntidad.IDDETALLE = Nothing Then

            lID = ObtenerID(aEntidad)

            If lID = -1 Then Return -1

            aEntidad.IDDETALLE = lID

            Return AgregarAmpliacion(aEntidad)

        End If

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" SET ENTREGA = @ENTREGA, ")
        strSQL.Append(" PLAZOENTREGA = @PLAZOENTREGA, ")
        strSQL.Append(" PORCENTAJEENTREGA = @PORCENTAJEENTREGA, ")
        strSQL.Append(" FECHACONTEO = @FECHACONTEO, ")
        strSQL.Append(" IDMODIFICATIVA = @IDMODIFICATIVA, ")
        strSQL.Append(" ESTAHABILITADA = @ESTAHABILITADA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(15) As SqlParameter
        args(0) = New SqlParameter("@ENTREGA", SqlDbType.TinyInt)
        args(0).Value = aEntidad.ENTREGA
        args(1) = New SqlParameter("@PLAZOENTREGA", SqlDbType.SmallInt)
        args(1).Value = aEntidad.PLAZOENTREGA
        args(2) = New SqlParameter("@PORCENTAJEENTREGA", SqlDbType.Decimal)
        args(2).Value = aEntidad.PORCENTAJEENTREGA
        args(3) = New SqlParameter("@FECHACONTEO", SqlDbType.TinyInt)
        args(3).Value = aEntidad.FECHACONTEO
        args(4) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(4).Value = IIf(aEntidad.IDMODIFICATIVA = Nothing, DBNull.Value, aEntidad.IDMODIFICATIVA)
        args(5) = New SqlParameter("@ESTAHABILITADA", SqlDbType.TinyInt)
        args(5).Value = aEntidad.ESTAHABILITADA
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = IIf(aEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(7).Value = IIf(aEntidad.AUFECHACREACION = Nothing, DBNull.Value, aEntidad.AUFECHACREACION)
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(10) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(10).Value = aEntidad.ESTASINCRONIZADA
        args(11) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(11).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)
        args(12) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(12).Value = IIf(aEntidad.IDPROVEEDOR = Nothing, DBNull.Value, aEntidad.IDPROVEEDOR)
        args(13) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(13).Value = IIf(aEntidad.IDCONTRATO = Nothing, DBNull.Value, aEntidad.IDCONTRATO)
        args(14) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(14).Value = IIf(aEntidad.RENGLON = Nothing, DBNull.Value, aEntidad.RENGLON)
        args(15) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(15).Value = IIf(aEntidad.IDDETALLE = Nothing, DBNull.Value, aEntidad.IDDETALLE)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function AgregarAmpliacion(ByVal aEntidad As ENTREGACONTRATO) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("INSERT INTO SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" ENTREGA, ")
        strSQL.Append(" PLAZOENTREGA, ")
        strSQL.Append(" PORCENTAJEENTREGA, ")
        strSQL.Append(" FECHACONTEO, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" ESTAHABILITADA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @RENGLON, ")
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @ENTREGA, ")
        strSQL.Append(" @PLAZOENTREGA, ")
        strSQL.Append(" @PORCENTAJEENTREGA, ")
        strSQL.Append(" @FECHACONTEO, ")
        strSQL.Append(" @IDMODIFICATIVA, ")
        strSQL.Append(" @ESTAHABILITADA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(15) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = aEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = aEntidad.RENGLON
        args(4) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(4).Value = aEntidad.IDDETALLE
        args(5) = New SqlParameter("@ENTREGA", SqlDbType.TinyInt)
        args(5).Value = aEntidad.ENTREGA
        args(6) = New SqlParameter("@PLAZOENTREGA", SqlDbType.SmallInt)
        args(6).Value = aEntidad.PLAZOENTREGA
        args(7) = New SqlParameter("@PORCENTAJEENTREGA", SqlDbType.Decimal)
        args(7).Value = aEntidad.PORCENTAJEENTREGA
        args(8) = New SqlParameter("@FECHACONTEO", SqlDbType.TinyInt)
        args(8).Value = aEntidad.FECHACONTEO
        args(9) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(9).Value = IIf(aEntidad.IDMODIFICATIVA = Nothing, DBNull.Value, aEntidad.IDMODIFICATIVA)
        args(10) = New SqlParameter("@ESTAHABILITADA", SqlDbType.TinyInt)
        args(10).Value = aEntidad.ESTAHABILITADA
        args(11) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(11).Value = IIf(aEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args(12) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(12).Value = IIf(aEntidad.AUFECHACREACION = Nothing, DBNull.Value, aEntidad.AUFECHACREACION)
        args(13) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(13).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(14) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(14).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(15) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(15).Value = aEntidad.ESTASINCRONIZADA

        If SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 1 Then
            Return aEntidad.IDDETALLE
        Else
            Return 0
        End If

    End Function

    Public Function ObtenerEntregas(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" ORDER BY ENTREGA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

End Class
