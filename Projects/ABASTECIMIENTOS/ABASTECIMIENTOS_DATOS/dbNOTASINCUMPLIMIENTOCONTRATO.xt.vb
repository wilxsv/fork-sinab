Partial Public Class dbNOTASINCUMPLIMIENTOCONTRATO

    ''' <summary>
    ''' recupera la informacion necesaria a mostrar en la elaboracion de la nota de incumplimiento
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo NOTASINCUMPLIMIENTOSCONTRATOS
    ''' <returns>
    ''' Numero de registros afectados por la operacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function RecuperarInformacionNota(ByVal aEntidad As NOTASINCUMPLIMIENTOCONTRATO) As Integer

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
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

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With ds.Tables(0).Rows(0)
                aEntidad.IDNOTA = IIf(.Item("IDNOTA") Is DBNull.Value, Nothing, .Item("IDNOTA"))
                aEntidad.NOMBREPERSONADIRIGIDA = IIf(.Item("NOMBREPERSONADIRIGIDA") Is DBNull.Value, Nothing, .Item("NOMBREPERSONADIRIGIDA"))
                aEntidad.CARGOPERSONADIRIGIDA = IIf(.Item("CARGOPERSONADIRIGIDA") Is DBNull.Value, Nothing, .Item("CARGOPERSONADIRIGIDA"))
                aEntidad.IDEMPLEADOENVIA = IIf(.Item("IDEMPLEADOENVIA") Is DBNull.Value, Nothing, .Item("IDEMPLEADOENVIA"))
                aEntidad.TITULONOTA = IIf(.Item("TITULONOTA") Is DBNull.Value, Nothing, .Item("TITULONOTA"))
                aEntidad.FECHAENTREGA = IIf(.Item("FECHAENTREGA") Is DBNull.Value, Nothing, .Item("FECHAENTREGA"))
                aEntidad.NUMEROINFORME = IIf(.Item("NUMEROINFORME") Is DBNull.Value, Nothing, .Item("NUMEROINFORME"))
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

    ''' <summary>
    ''' valida la existencia de notas de incumplimiento de contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDCONTRATO"></param> identificador de contrato
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <returns>
    ''' verdadero si existe la nota
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO</description></item>
    ''' </list> 
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarExistenciaNotaContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(1).Value = IDCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Dataset con los renglones del contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDCONTRATO"></param> identificador de contrato
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGACONTRATOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DatasetRenglonesContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT pc.IDESTABLECIMIENTO, pc.IDPROVEEDOR, pc.IDCONTRATO, pc.RENGLON, pc.IDPRODUCTO, vvc.DESCLARGO, ")
        strSQL.Append("vvc.DESCRIPCION AS UNIDADMEDIDA, pc.PRECIOUNITARIO, pc.CANTIDAD, SUM(aec.CANTIDAD) AS CANTIDADALMACEN, ")
        strSQL.Append("SUM(aec.CANTIDADENTREGADA) AS ENTREGADO, SUM(aec.CANTIDAD - aec.CANTIDADENTREGADA) AS NOENTREGADO, vvc.CORRPRODUCTO, ")
        strSQL.Append("pc.CANTIDAD * pc.PRECIOUNITARIO AS COSTOTOTAL, SUM(aec.CANTIDADENTREGADA) * pc.PRECIOUNITARIO AS COSTOENTREGADO, ")
        strSQL.Append("SUM(aec.CANTIDAD - aec.CANTIDADENTREGADA) * pc.PRECIOUNITARIO AS COSTONOENTREGADO, pc.ESTAHABILITADO, ec.ESTAHABILITADA,  pc.DESCRIPCIONPROVEEDOR ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO AS pc INNER JOIN ")
        strSQL.Append("SAB_UACI_ENTREGACONTRATO AS ec ON pc.IDESTABLECIMIENTO = ec.IDESTABLECIMIENTO AND pc.IDPROVEEDOR = ec.IDPROVEEDOR AND ")
        strSQL.Append("pc.IDCONTRATO = ec.IDCONTRATO AND pc.RENGLON = ec.RENGLON INNER JOIN ")
        strSQL.Append("SAB_UACI_ALMACENESENTREGACONTRATOS AS aec ON ec.IDESTABLECIMIENTO = aec.IDESTABLECIMIENTO AND ")
        strSQL.Append("ec.IDPROVEEDOR = aec.IDPROVEEDOR AND ec.IDCONTRATO = aec.IDCONTRATO AND ec.RENGLON = aec.RENGLON AND ")
        strSQL.Append("ec.IDDETALLE = aec.IDDETALLE INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS vvc ON pc.IDPRODUCTO = vvc.IDPRODUCTO ")
        strSQL.Append("WHERE pc.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND pc.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND pc.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND ec.ESTAHABILITADA = 1 ")
        strSQL.Append("AND pc.ESTAHABILITADO = 1 ")
        strSQL.Append("GROUP BY pc.IDESTABLECIMIENTO, pc.IDPROVEEDOR, pc.IDCONTRATO, pc.RENGLON, pc.CANTIDAD, pc.PRECIOUNITARIO, pc.ESTAHABILITADO, ")
        strSQL.Append("ec.ESTAHABILITADA, vvc.CORRPRODUCTO, vvc.DESCLARGO, pc.IDPRODUCTO, vvc.DESCRIPCION,  pc.DESCRIPCIONPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(1).Value = IDCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' dataset con los renglones de la modificativa de contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDCONTRATO"></param> identificador de contrato
    ''' <param name="IDPROVEEDOR"></param> identificdor de proveedor
    ''' <returns>
    ''' dataset con la informacion solicitado
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_UACI_ALMACENESENTREGAMODIFICATIVA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history> 
    Public Function DatasetRenglonesModificativaContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_UACI_PRODUCTOSCONTRATO.IDESTABLECIMIENTO, SAB_UACI_PRODUCTOSCONTRATO.IDPROVEEDOR, ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.IDCONTRATO, SAB_UACI_PRODUCTOSCONTRATO.RENGLON, ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.IDUNIDADMEDIDA, vv_CATALOGOPRODUCTOS.DESCRIPCION AS UNIDADMEDIDA, ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.CANTIDAD, SAB_UACI_PRODUCTOSCONTRATO.PRECIOUNITARIO, vv_CATALOGOPRODUCTOS.IDPRODUCTO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.DESCLARGO, vv_CATALOGOPRODUCTOS.CORRPRODUCTO, ")
        strSQL.Append("SUM(SAB_UACI_ALMACENESENTREGAMODIFICATIVA.CANTIDADENTREGADA) AS ENTREGADO, ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.CANTIDAD - SUM(SAB_UACI_ALMACENESENTREGAMODIFICATIVA.CANTIDADENTREGADA) AS NOENTREGADO, ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.CANTIDAD * SAB_UACI_PRODUCTOSCONTRATO.PRECIOUNITARIO AS COSTOTOTAL, ")
        strSQL.Append("SUM(SAB_UACI_ALMACENESENTREGAMODIFICATIVA.CANTIDADENTREGADA) ")
        strSQL.Append("* SAB_UACI_PRODUCTOSCONTRATO.PRECIOUNITARIO AS COSTOENTREGADO, ")
        strSQL.Append("(SAB_UACI_PRODUCTOSCONTRATO.CANTIDAD - SUM(SAB_UACI_ALMACENESENTREGAMODIFICATIVA.CANTIDADENTREGADA)) ")
        strSQL.Append("* SAB_UACI_PRODUCTOSCONTRATO.PRECIOUNITARIO AS COSTONOENTREGADO ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS ON SAB_UACI_PRODUCTOSCONTRATO.IDPRODUCTO = vv_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_UACI_ALMACENESENTREGAMODIFICATIVA ON ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.IDESTABLECIMIENTO = SAB_UACI_ALMACENESENTREGAMODIFICATIVA.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.IDPROVEEDOR = SAB_UACI_ALMACENESENTREGAMODIFICATIVA.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.IDCONTRATO = SAB_UACI_ALMACENESENTREGAMODIFICATIVA.IDCONTRATO AND ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.RENGLON = SAB_UACI_ALMACENESENTREGAMODIFICATIVA.RENGLON ")
        strSQL.Append("GROUP BY SAB_UACI_PRODUCTOSCONTRATO.IDESTABLECIMIENTO, SAB_UACI_PRODUCTOSCONTRATO.IDPROVEEDOR, ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.IDCONTRATO, SAB_UACI_PRODUCTOSCONTRATO.RENGLON, ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.IDUNIDADMEDIDA, SAB_UACI_PRODUCTOSCONTRATO.CANTIDAD, ")
        strSQL.Append("SAB_UACI_PRODUCTOSCONTRATO.PRECIOUNITARIO, vv_CATALOGOPRODUCTOS.IDPRODUCTO, vv_CATALOGOPRODUCTOS.DESCLARGO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.CORRPRODUCTO, vv_CATALOGOPRODUCTOS.DESCRIPCION ")
        strSQL.Append("HAVING SAB_UACI_PRODUCTOSCONTRATO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_PRODUCTOSCONTRATO.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND SAB_UACI_PRODUCTOSCONTRATO.IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(1).Value = IDCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Validar el numero de informe si existe
    ''' </summary>
    ''' <param name="NUMEROINFORME"></param> numero de informe
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarNumeroInforme(ByVal NUMEROINFORME As String, ByVal IDESTABLECIMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO ")
        strSQL.Append(" WHERE NUMEROINFORME = @NUMEROINFORME ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@NUMEROINFORME", SqlDbType.VarChar)
        args(0).Value = NUMEROINFORME
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

End Class

