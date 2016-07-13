Partial Public Class dbQUEDANS

    ''' <summary>
    ''' Validar la existencia de quedan para el proveedor para un contrato especifico
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador establecimiento
    ''' <param name="IDCONTRATO"></param> identificador de contrato
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <param name="IDTIPOGARANTIA"></param> identificador de tipo de garantia
    ''' <param name="IDGARANTIACONTRATO"></param> identificador de garantia contrato
    ''' <returns>
    ''' verdadero si quedan existe
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_QUEDANS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarExistenciaQuedan(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDTIPOGARANTIA As Int32, ByVal IDGARANTIACONTRATO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_UACI_QUEDANS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append("AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(1).Value = IDCONTRATO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.Int)
        args(3).Value = IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = IDGARANTIACONTRATO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True
    End Function

    ''' <summary>
    ''' Recupera la informacion de datos para la elaboracion de quedan
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo QUEDAN
    ''' <returns>
    ''' Numero de registros recuperados
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_QUEDANS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function RecuperarInformacionQuedan(ByVal aEntidad As QUEDANS) As Integer

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = aEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.SmallInt)
        args(4).Value = aEntidad.IDGARANTIACONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With ds.Tables(0).Rows(0)
                aEntidad.IDQUEDAN = IIf(.Item("IDQUEDAN") Is DBNull.Value, Nothing, .Item("IDQUEDAN"))
                aEntidad.FECHAINGRESO = IIf(.Item("FECHAINGRESO") Is DBNull.Value, Nothing, .Item("FECHAINGRESO"))
                aEntidad.FECHAVENCIMIENTO = IIf(.Item("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, .Item("FECHAVENCIMIENTO"))
                aEntidad.DESCRIPCION = IIf(.Item("DESCRIPCION") Is DBNull.Value, Nothing, .Item("DESCRIPCION"))
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
    ''' Dataset con la informacion necesaria de los contratos con referente al quedan
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDCONTRATO"></param> identificador del contrato
    ''' <param name="IDTIPOGARANTIA"></param> identificador del tipo de garantia
    ''' <param name="IDPROVEEDOR"></param> identificador del proveedor
    ''' <param name="IDGARANTIACONTRATO"></param> identificador de la garantia contrato
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_GARANTIASCONTRATOS</description></item>
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_TIPOGARANTIAS</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 

    Public Function DatasetContratoQuedan(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDTIPOGARANTIA As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDGARANTIACONTRATO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_CAT_TIPOGARANTIAS.NOMBRE AS TIPOGARANTIA, SAB_UACI_GARANTIASCONTRATOS.NUMEROGARANTIA, ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.FECHARECEPCION, SAB_UACI_GARANTIASCONTRATOS.MONTO, SAB_UACI_GARANTIASCONTRATOS.VIGENCIA, ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.FECHAVENCIMIENTO AS VENCIMIENTOGARANTIA, SAB_UACI_GARANTIASCONTRATOS.ASEGURADORA, ")
        strSQL.Append("SAB_UACI_CONTRATOS.NUMEROCONTRATO, SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, SAB_UACI_PROCESOCOMPRAS.NUMERORESOLUCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA, SAB_UACI_CONTRATOS.IDESTABLECIMIENTO, SAB_UACI_CONTRATOS.IDPROVEEDOR, ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDCONTRATO, SAB_CAT_PROVEEDORES.CODIGOPROVEEDOR, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.NOMBRE AS NOMBREPROVEEDOR, SAB_CAT_PROVEEDORES.DIRECCION, SAB_CAT_PROVEEDORES.TELEFONO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_UACI_CONTRATOS.MONTOCONTRATO, ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.CLASEGARANTIA, SAB_UACI_GARANTIASCONTRATOS.IDTIPOGARANTIA, SAB_UACI_GARANTIASCONTRATOS.IDGARANTIACONTRATO ")
        strSQL.Append("FROM SAB_UACI_GARANTIASCONTRATOS INNER JOIN ")
        strSQL.Append("SAB_UACI_CONTRATOS ON SAB_UACI_GARANTIASCONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOS.IDCONTRATO INNER JOIN ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO INNER JOIN ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS ON ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOGARANTIAS ON SAB_UACI_GARANTIASCONTRATOS.IDTIPOGARANTIA = SAB_CAT_TIPOGARANTIAS.IDTIPOGARANTIA INNER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES ON SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append("WHERE SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_CONTRATOS.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND SAB_UACI_GARANTIASCONTRATOS.IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append("AND SAB_UACI_CONTRATOS.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND SAB_UACI_GARANTIASCONTRATOS.IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(1).Value = IDCONTRATO
        args(2) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.Int)
        args(2).Value = IDTIPOGARANTIA
        args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(3).Value = IDPROVEEDOR
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = IDGARANTIACONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Dataset con la informacion necesaria para la elaboracion del reporte de quedan
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDCONTRATO"></param> identificador de contrato
    ''' <param name="IDTIPOGARANTIA"></param> identificador de tipo de garantia
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <param name="IDQUEDAN"></param> identificador de quedan
    ''' <param name="IDGARANTIACONTRATO"></param> identificador de garantia contrato
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_GARANTIASCONTRATOS</description></item>
    ''' <item><description>SAB_UACI_CONTRATOS</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_CAT_TIPOGARANTIAS</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_UACI_QUEDANS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DatasetReporteQuedan(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDTIPOGARANTIA As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDQUEDAN As Int32, ByVal IDGARANTIACONTRATO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_CAT_TIPOGARANTIAS.NOMBRE AS TIPOGARANTIA, SAB_UACI_GARANTIASCONTRATOS.NUMEROGARANTIA, ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.FECHARECEPCION, SAB_UACI_GARANTIASCONTRATOS.MONTO, SAB_UACI_GARANTIASCONTRATOS.VIGENCIA, ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.FECHAVENCIMIENTO AS VENCIMIENTOGARANTIA, SAB_UACI_GARANTIASCONTRATOS.ASEGURADORA, ")
        strSQL.Append("SAB_UACI_CONTRATOS.NUMEROCONTRATO, SAB_UACI_PROCESOCOMPRAS.TITULOLICITACION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION, SAB_UACI_PROCESOCOMPRAS.NUMERORESOLUCION, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA, SAB_UACI_CONTRATOS.IDESTABLECIMIENTO, SAB_UACI_CONTRATOS.IDPROVEEDOR, ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDCONTRATO, SAB_CAT_PROVEEDORES.CODIGOPROVEEDOR, ")
        strSQL.Append("SAB_CAT_PROVEEDORES.NOMBRE AS NOMBREPROVEEDOR, SAB_CAT_PROVEEDORES.DIRECCION, SAB_CAT_PROVEEDORES.TELEFONO, ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION, SAB_UACI_CONTRATOS.MONTOCONTRATO, ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.CLASEGARANTIA, SAB_UACI_GARANTIASCONTRATOS.IDTIPOGARANTIA, SAB_UACI_QUEDANS.IDQUEDAN, ")
        strSQL.Append("SAB_UACI_QUEDANS.FECHAINGRESO, SAB_UACI_QUEDANS.FECHAVENCIMIENTO, SAB_UACI_QUEDANS.DESCRIPCION, ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDTIPODOCUMENTO, SAB_UACI_GARANTIASCONTRATOS.IDGARANTIACONTRATO ")
        strSQL.Append("FROM SAB_UACI_GARANTIASCONTRATOS INNER JOIN ")
        strSQL.Append("SAB_UACI_CONTRATOS ON SAB_UACI_GARANTIASCONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOS.IDCONTRATO INNER JOIN ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_CONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO INNER JOIN ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS ON ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOGARANTIAS ON SAB_UACI_GARANTIASCONTRATOS.IDTIPOGARANTIA = SAB_CAT_TIPOGARANTIAS.IDTIPOGARANTIA INNER JOIN ")
        strSQL.Append("SAB_CAT_PROVEEDORES ON SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR INNER JOIN ")
        strSQL.Append("SAB_UACI_QUEDANS ON SAB_UACI_GARANTIASCONTRATOS.IDESTABLECIMIENTO = SAB_UACI_QUEDANS.IDESTABLECIMIENTO AND ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.IDPROVEEDOR = SAB_UACI_QUEDANS.IDPROVEEDOR AND ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.IDCONTRATO = SAB_UACI_QUEDANS.IDCONTRATO AND ")
        strSQL.Append("SAB_UACI_GARANTIASCONTRATOS.IDTIPOGARANTIA = SAB_UACI_QUEDANS.IDTIPOGARANTIA ")
        strSQL.Append("WHERE SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_UACI_CONTRATOS.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND SAB_UACI_GARANTIASCONTRATOS.IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append("AND SAB_UACI_GARANTIASCONTRATOS.IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")
        strSQL.Append("AND SAB_UACI_CONTRATOS.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND SAB_UACI_QUEDANS.IDQUEDAN = @IDQUEDAN ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(1).Value = IDCONTRATO
        args(2) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.Int)
        args(2).Value = IDTIPOGARANTIA
        args(3) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(3).Value = IDPROVEEDOR
        args(4) = New SqlParameter("@IDQUEDAN", SqlDbType.Int)
        args(4).Value = IDQUEDAN
        args(5) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(5).Value = IDGARANTIACONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener idntificador de quedan
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo QUEDAN
    ''' <returns>
    ''' el numero de identificador
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_QUEDANS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerIdQuedan(ByVal aEntidad As QUEDANS) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(IDQUEDAN),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_QUEDANS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

End Class
