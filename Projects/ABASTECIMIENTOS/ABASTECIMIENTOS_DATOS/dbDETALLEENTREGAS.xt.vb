Partial Public Class dbDETALLEENTREGAS

#Region " METODOS AGREGADOS "

    ' AUTOR: JOSE CHAVEZ 
    '-------------------------------------------------------------------------------------------------------------------------
    ' En esta función valida si existe correlativo del detalle de la entrega
    ' FECHA 04/10/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ValidarIDDETALLEENTREGA(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDENTREGA As Int16, ByVal IDDETALLE As Int16) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_EST_DETALLEENTREGAS ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDENTREGA = @IDENTREGA AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.SmallInt)
        args(2).Value = IDENTREGA
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

    ''' <summary>
    ''' Obtener informacion de detalle de entregas asociada a una solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD"></param> 'identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_DETALLEENTREGAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetPorSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Eliminar el detalle de entregas para una solicitud especifica
    ''' </summary>
    ''' <param name="aEntidad"></param> entididad tipo DETALLEENTREGAS
    ''' <returns>
    ''' devuelve uno si se realizo la operacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLEENTREGAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function EliminarDetalleEntregasXsolicitud(ByVal aEntidad As DETALLEENTREGAS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_DETALLEENTREGAS ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ' AUTOR: JOSE CHAVEZ 
    '-------------------------------------------------------------------------------------------------------------------------
    ' Se utiliza para obtener el limite de las entregas para una solicitud de compras
    ' FECHA 06/12/06 
    '-------------------------------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Obtiene el limite de una entrega
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <returns>Valor entero con la información del limite</returns>

    Public Function ObtenerLimiteEntrega(ByVal IDESTABLECIMIENTO As Int64, ByVal IDSOLICITUD As Int64) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(IDENTREGA),0) ")
        strSQL.Append(" FROM SAB_EST_DETALLEENTREGAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obteniene información del detalle de entregas
    ''' </summary>
    ''' <param name="IDENTREGA"></param> 'identificador de la entrega
    ''' <param name="ARR_SOLICITUD"></param> 'Arreglo que contiene el identificador de solicitudes
    ''' <param name="IDDETALLE"></param> 'identificador del detalle de entrega
    ''' <returns>
    ''' dataset contiene el detalle de la entrega de Dias y porcentaje de entrega 
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLEENTREGAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Juan José Rivas]      Creado
    ''' </history> 
    Public Function obtenerDiasPorcentaje(ByVal IDENTREGA As Integer, ByVal ARR_SOLICITUD As listaSOLICITUDES, ByVal IDDETALLE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDSOLICITUD, IDDETALLE, PLAZOENTREGA, PORCENTAJEENTREGA ")
        strSQL.Append(" FROM SAB_EST_ENTREGASOLICITUDES ")

        For Each solic As SOLICITUDES In ARR_SOLICITUD
            Dim i As Integer = ARR_SOLICITUD.IndiceDe(solic)

            If i = 0 Then
                strSQL.Append(" WHERE ")
            Else
                strSQL.Append(" OR ")
            End If
            strSQL.Append(" (IDESTABLECIMIENTO = " & solic.IDESTABLECIMIENTO & " AND IDENTREGA = " & IDENTREGA & " AND IDDETALLE = " & IDDETALLE & " AND IDSOLICITUD = " & solic.IDSOLICITUD & ") ")

        Next

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene la información del detalle de las entregas
    ''' </summary>
    ''' <param name="ARR_SOLICITUD">identificador de la solicitud</param>
    ''' <param name="IDENTREGA">identificador de la entrega</param>
    ''' <returns>Informacion de las entregas en formato dataset</returns>

    Public Function ObtenerDataSetDetalleEntrega(ByVal ARR_SOLICITUD As listaSOLICITUDES, ByVal IDENTREGA As Byte) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DIAS, FECHACONTEO, PORCENTAJE, TIPOCONTEO, IDDETALLE ")
        strSQL.Append(" FROM SAB_EST_DETALLEENTREGAS ")

        For Each solic As SOLICITUDES In ARR_SOLICITUD
            Dim i As Integer = ARR_SOLICITUD.IndiceDe(solic)

            If i = 0 Then
                strSQL.Append(" WHERE ")
            Else
                strSQL.Append(" OR ")
            End If
            strSQL.Append(" (IDESTABLECIMIENTO = " & solic.IDESTABLECIMIENTO & " AND IDSOLICITUD = " & solic.IDSOLICITUD & ") ")
        Next

        strSQL.Append(" AND (IDENTREGA = " & IDENTREGA & ") ")
        strSQL.Append(" GROUP BY DIAS, FECHACONTEO, PORCENTAJE, TIPOCONTEO, IDDETALLE ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

#End Region

End Class
