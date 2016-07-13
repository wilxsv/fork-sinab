Partial Public Class dbSERVICIOSHOSPITALARIOS

    ''' <summary>
    ''' Eliminar servicios hospitalarios por establecimiento
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo SERVICIOSHOSPITALARIOS
    ''' <returns>
    ''' Numero de registros afectados por la operacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_SERVICIOSHOSPITALARIOS</description></item>
    ''' </list>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function EliminarxEstablecimiento(ByVal aEntidad As SERVICIOSHOSPITALARIOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_SERVICIOSHOSPITALARIOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Verificar si existen servicios hospitalarios para el establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <returns>
    ''' verdadero si existen servicios hospitalarios para el establecimiento
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_SERVICIOSHOSPITALARIOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ExistenServiciosHospitalariosEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_SERVICIOSHOSPITALARIOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Busqueda de existencia de codigo de servicio
    ''' </summary>
    ''' <param name="IDestablecimiento"></param> identificador de establecimiento
    ''' <param name="CODIGOSERVICIO"></param> codigo de servicio
    ''' <returns>
    ''' verdadero si encontro que existe
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_SERVICIOSHOSPITALARIOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor:]      Creado
    ''' </history> 
    Public Function BuscarEstablecimientocodigo(ByVal IDestablecimiento As Int32, ByVal CODIGOSERVICIO As String) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDESTABLECIMIENTO, CODIGOSERVICIO ")
        strSQL.Append(" FROM SAB_CAT_SERVICIOSHOSPITALARIOS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (CODIGOSERVICIO = @CODIGOSERVICIO ) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDestablecimiento
        args(1) = New SqlParameter("@CODIGOSERVICIO", SqlDbType.Int)
        args(1).Value = CODIGOSERVICIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Obtener lista de servicios hospitalarios
    ''' </summary>
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_SERVICIOSHOSPITALARIOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor:Yessenia Henriquez]      Creado
    ''' </history> 

    Public Function ObtenerDataSetListaServiciosHospitalarios() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SH.IDSERVICIOHOSPITALARIO, SH.CODIGOSERVICIO, SH.NOMBRESERVICIO, SH.IDESTABLECIMIENTO, ES.NOMBRE AS ESTABLECIMIENTO, ")
        strSQL.Append(" SH.AUUSUARIOCREACION, SH.AUFECHACREACION, SH.AUUSUARIOMODIFICACION, SH.AUFECHAMODIFICACION, SH.ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_SERVICIOSHOSPITALARIOS AS SH INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS AS ES ON SH.IDESTABLECIMIENTO = ES.IDESTABLECIMIENTO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Dataset de servicios hospitalarios ordenado por ID
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificadr del establecimiento
    ''' <returns>
    ''' Dataset con la informacion ordenada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_SERVICIOSHOSPITALARIOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor:Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerListaPorIDOrdenada(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" ORDER BY NOMBRESERVICIO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

End Class
