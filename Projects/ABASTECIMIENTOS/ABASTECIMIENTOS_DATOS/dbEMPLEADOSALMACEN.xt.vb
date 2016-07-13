Partial Public Class dbEMPLEADOSALMACEN

#Region " Métodos Agregados "

    Public Function RecuperarAlmacen(ByVal aEntidad As EMPLEADOSALMACEN) As Integer

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDEMPLEADO = @IDEMPLEADO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(0).Value = aEntidad.IDEMPLEADO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then Return 0

        Try
            'For ri As Integer = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(0)
                'If CBool(.Item("ESFARMACIA")) Then
                aEntidad.IDALMACEN = IIf(.Item("IDALMACEN") Is DBNull.Value, Nothing, .Item("IDALMACEN"))
                aEntidad.ESGUARDAALMACEN = IIf(.Item("ESGUARDAALMACEN") Is DBNull.Value, Nothing, .Item("ESGUARDAALMACEN"))
                aEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                aEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                aEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                aEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                aEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                aEntidad.IDSUMINISTRO = IIf(.Item("IDSUMINISTRO") Is DBNull.Value, Nothing, .Item("IDSUMINISTRO"))
                'End If
            End With
            'Next
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Function ObtenerDsIdAlmacen(ByVal IDEMPLEADO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDEMPLEADO = @IDEMPLEADO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(0).Value = IDEMPLEADO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetListaEmpleadosAlmacen() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("EA.*, ")
        strSQL.Append("E.NOMBRE EMPLEADO, ")
        strSQL.Append("A.NOMBRE ALMACEN, ")
        strSQL.Append("isnull(S.DESCRIPCION, '') SUMINISTRO ")
        strSQL.Append("FROM SAB_CAT_EMPLEADOSALMACEN EA ")
        strSQL.Append("INNER JOIN vv_EMPLEADOS E ")
        strSQL.Append("ON EA.IDEMPLEADO = E.IDEMPLEADO ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON EA.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON EA.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("ORDER BY EA.IDALMACEN, E.NOMBRE ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function BuscarEmpleadosAlmacen(ByVal IDEMPLEADO As Int32, ByVal IDALMACEN As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT count(IDEMPLEADO) ")
        strSQL.Append(" FROM SAB_CAT_EMPLEADOSALMACEN ")
        strSQL.Append(" WHERE (IDEMPLEADO = @IDEMPLEADO) AND (IDALMACEN = @IDALMACEN) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(0).Value = IDEMPLEADO
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = IDALMACEN

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    ''' <summary>
    ''' Devuelve el listado de guardalmacenes para un establecimiento.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del establecimiento al que pertenecen los empleados.</param>
    ''' <returns>Devuelve un dataset con el listado de guardaalmacenes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_EMPLEADOSALMACEN</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]      Creado
    ''' </history> 
    Public Function RecuperarGuardalmacen(ByVal IDALMACEN As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("ea.IDALMACEN, ")
        strSQL.Append("ea.IDEMPLEADO IDEMPLEADOGUARDAALMACEN, ")
        strSQL.Append("e.NOMBRE + ' ' + e.APELLIDO NOMBREGUARDAALMACEN, ")
        strSQL.Append("ea.ESGUARDAALMACEN, ")
        strSQL.Append("e.NOMBRECORTO + '-' + e.APELLIDO + ',' + e.NOMBRE CODIGONOMBRE ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_EMPLEADOSALMACEN ea ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS e ON ea.IDEMPLEADO = e.IDEMPLEADO ")
        strSQL.Append("WHERE ea.IDALMACEN = @IDALMACEN ")
        strSQL.Append("ORDER BY e.NOMBRE, e.APELLIDO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerGuardalmacen(ByVal IDALMACEN As Int32) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("isnull(E.NOMBRE + ' ' + E.APELLIDO, '') NOMBREGUARDAALMACEN ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_CAT_EMPLEADOSALMACEN EA ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS E ")
        strSQL.Append("ON EA.IDEMPLEADO = E.IDEMPLEADO ")
        strSQL.Append("WHERE EA.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND EA.ESGUARDAALMACEN = 1 ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerDsDetalleAlmacenesEmpleados(ByVal IDEMPLEADO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT ")
        strSQL.Append("   EA.IDALMACEN, A.NOMBRE, A.ESFARMACIA ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_CAT_EMPLEADOSALMACEN EA ")
        strSQL.Append("     INNER JOIN ")
        strSQL.Append("       SAB_CAT_ALMACENES A ON ")
        strSQL.Append("         EA.IDALMACEN = A.IDALMACEN ")
        strSQL.Append(" WHERE EA.IDEMPLEADO = @IDEMPLEADO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(0).Value = IDEMPLEADO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
