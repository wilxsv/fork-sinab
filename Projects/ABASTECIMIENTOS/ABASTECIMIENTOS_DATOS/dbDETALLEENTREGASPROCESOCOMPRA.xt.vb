Partial Public Class dbDETALLEENTREGASPROCESOCOMPRA

#Region " Métodos Agregados "

    Public Function AgregardetalleEntregaProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int64, ByVal IDENTREGA As Int64) As Integer

        Dim objDetalleEntregaSolicitud As New dbDETALLEENTREGAS
        Dim lEntidad As New DETALLEENTREGASPROCESOCOMPRA

        Dim dsDetalleEntregaSolicitud As DataSet
        dsDetalleEntregaSolicitud = objDetalleEntregaSolicitud.ObtenerDataSetPorID(IDSOLICITUD, IDESTABLECIMIENTO, IDENTREGA)

        Dim i As Integer
        For i = 0 To dsDetalleEntregaSolicitud.Tables(0).Rows.Count - 1
            With lEntidad
                .IDFECHACONTEO = dsDetalleEntregaSolicitud.Tables(0).Rows(i).Item("FECHACONTEO")
                .IDDETALLE = dsDetalleEntregaSolicitud.Tables(0).Rows(i).Item("IDDETALLE")
                .IDENTREGA = IDENTREGA
                .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                .PORCENTAJE = dsDetalleEntregaSolicitud.Tables(0).Rows(i).Item("PORCENTAJE")
                .TIPOCONTEO = dsDetalleEntregaSolicitud.Tables(0).Rows(i).Item("TIPOCONTEO")
            End With
            Return Agregar(lEntidad)
        Next

    End Function

    ''' <summary>
    ''' Se utiliza para validar si existe el correlativo del detalle de la entrega.
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA"></param>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDENTREGA"></param>
    ''' <param name="IDDETALLE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    04/12/06    Creado
    ''' </history>
    Public Function ValidarIDDETALLEENTREGA(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDENTREGA As Int16, ByVal IDDETALLE As Int16) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_UACI_DETALLEENTREGASPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDENTREGA = @IDENTREGA AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.SmallInt)
        args(2).Value = IDENTREGA
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Devuelve las entregas solicitadas para un renglón determinado.
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLEENTREGASPROCESOCOMPRA</item>
    ''' <item>SAB_CAT_FECHACONTEOS</item>
    ''' <item>SAB_UACI_DETALLEPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    'Public Function ObtenerEntregasPorRenglonProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal RENGLON As Int32) As DataSet

    '    Dim strSQL As New Text.StringBuilder
    '    strSQL.Append("SELECT ")
    '    strSQL.Append("DEPC.IDESTABLECIMIENTO, ")
    '    strSQL.Append("DEPC.IDPROCESOCOMPRA, ")
    '    strSQL.Append("DEPC.IDENTREGA, ")
    '    strSQL.Append("DEPC.IDDETALLE, ")
    '    strSQL.Append("DEPC.DIAS, ")
    '    strSQL.Append("DEPC.PORCENTAJE, ")
    '    strSQL.Append("DEPC.TIPOCONTEO, ")
    '    strSQL.Append("DEPC.IDFECHACONTEO, ")
    '    strSQL.Append("FC.DESCRIPCION FECHACONTEO, ")
    '    strSQL.Append("DEPC.AUUSUARIOCREACION, ")
    '    strSQL.Append("DEPC.AUFECHACREACION, ")
    '    strSQL.Append("DEPC.AUUSUARIOMODIFICACION, ")
    '    strSQL.Append("DEPC.AUFECHAMODIFICACION, ")
    '    strSQL.Append("DEPC.ESTASINCRONIZADA ")
    '    strSQL.Append("FROM SAB_UACI_DETALLEENTREGASPROCESOCOMPRA DEPC ")
    '    strSQL.Append("INNER JOIN SAB_CAT_FECHACONTEOS FC ")
    '    strSQL.Append("ON (DEPC.IDFECHACONTEO = FC.IDFECHACONTEO) ")
    '    strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
    '    strSQL.Append("ON (DEPC.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
    '    strSQL.Append("AND DEPC.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
    '    strSQL.Append("AND DEPC.IDENTREGA = DPC.NUMEROENTREGAS) ")
    '    strSQL.Append("WHERE ")
    '    strSQL.Append("DEPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
    '    strSQL.Append("AND DEPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
    '    strSQL.Append("AND DPC.RENGLON = @RENGLON ")
    '    strSQL.Append("ORDER BY DEPC.IDENTREGA ")

    '    Dim args(3) As SqlParameter
    '    args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
    '    args(0).Value = IDPROCESOCOMPRA
    '    args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(1).Value = IDESTABLECIMIENTO
    '    args(2) = New SqlParameter("@RENGLON", SqlDbType.TinyInt)
    '    args(2).Value = RENGLON

    '    Dim ds As DataSet
    '    ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    '    Return ds

    'End Function

    Public Function ObtenerEntregasPorRenglonProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal RENGLON As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DEPC.IDESTABLECIMIENTO, ")
        strSQL.Append("DEPC.IDPROCESOCOMPRA, ")
        strSQL.Append("DEPC.IDENTREGA, ")
        strSQL.Append("DEPC.IDDETALLE, ")
        strSQL.Append("DEPC.DIAS, ")
        strSQL.Append("DEPC.PORCENTAJE, ")
        strSQL.Append("DEPC.TIPOCONTEO, ")
        strSQL.Append("DEPC.IDFECHACONTEO, ")
        strSQL.Append("FC.DESCRIPCION FECHACONTEO, ")
        strSQL.Append("DEPC.AUUSUARIOCREACION, ")
        strSQL.Append("DEPC.AUFECHACREACION, ")
        strSQL.Append("DEPC.AUUSUARIOMODIFICACION, ")
        strSQL.Append("DEPC.AUFECHAMODIFICACION, ")
        strSQL.Append("DEPC.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_UACI_DETALLEENTREGASPROCESOCOMPRA DEPC ")
        strSQL.Append("INNER JOIN SAB_CAT_FECHACONTEOS FC ")
        strSQL.Append("ON (DEPC.IDFECHACONTEO = FC.IDFECHACONTEO) ")
        strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPC ")
        strSQL.Append("ON (DEPC.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND DEPC.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
        strSQL.Append("AND DEPC.IDENTREGA = DPC.NUMEROENTREGAS) ")
        strSQL.Append("WHERE ")
        strSQL.Append("DEPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DEPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DPC.RENGLON = @RENGLON ")
        strSQL.Append("ORDER BY DEPC.IDENTREGA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

        Return ds

    End Function

    ''' <summary>
    ''' yessenia
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA"></param>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDENTREGA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerDetalledeEntregasProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDENTREGA As Int32)

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DIAS, PORCENTAJE ")
        strSQL.Append(" FROM SAB_UACI_DETALLEENTREGASPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(2).Value = IDENTREGA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Return ds

    End Function

#End Region

End Class
