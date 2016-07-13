Partial Public Class dbENTREGAPROCESOCOMPRA

#Region " Métodos Agregados "

    ''' <summary>
    ''' Ingresar a la base de datos el detalle de las entregas para el proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> 'identificador del establecimiento
    ''' <param name="ARR_SOLICITUD"></param> 'arreglo que contiene el id de las solicitudes consolidadas
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param> 'identificador del proceso de compra
    ''' <returns></returns>
    ''' Valor entero que notifica que se ha realizado la inserción de datos
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>No actualiza tabla directamente</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Juan José Rivas]      Creado
    ''' </history> 
    Public Function AgregarEntregasProcesoCompra(ByVal ARR_SOLICITUD As listaSOLICITUDES, ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As Integer
        Dim dsEntregaSolicitud As DataSet
        Dim dsDetalleEntregaSolicitud As DataSet
        Dim objEntregaSolicitud As New dbENTREGASOLICITUDES
        Dim objDetalleEntregaSolicitud As New dbDETALLEENTREGAS
        Dim objDetalleEntregaProcesoCompra As New dbDETALLEENTREGASPROCESOCOMPRA
        Dim lEntidad As New ENTREGAPROCESOCOMPRA
        Dim lEntidadDet As New DETALLEENTREGASPROCESOCOMPRA
        Dim Resultado As Integer
        Dim idEntrega As Integer

        dsEntregaSolicitud = objEntregaSolicitud.ObtenerEntregaSolicitudes(ARR_SOLICITUD)
        Dim i, j As Integer
        For i = 0 To dsEntregaSolicitud.Tables(0).Rows.Count - 1
            idEntrega = dsEntregaSolicitud.Tables(0).Rows(i).Item("IDENTREGA")
            With lEntidad
                .IDENTREGA = idEntrega
                .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            End With
            If Me.ObtenerDataSetPorIDENTREGA(IDPROCESOCOMPRA, IDESTABLECIMIENTO, idEntrega).Tables(0).Rows.Count = 0 Then
                Resultado = Agregar(lEntidad)
            End If
            dsDetalleEntregaSolicitud = objDetalleEntregaSolicitud.ObtenerDataSetDetalleEntrega(ARR_SOLICITUD, dsEntregaSolicitud.Tables(0).Rows(i).Item("IDENTREGA"))
            For j = 0 To dsDetalleEntregaSolicitud.Tables(0).Rows.Count - 1
                With lEntidadDet
                    .DIAS = dsDetalleEntregaSolicitud.Tables(0).Rows(j).Item("DIAS")
                    .IDFECHACONTEO = dsDetalleEntregaSolicitud.Tables(0).Rows(j).Item("FECHACONTEO")
                    .IDENTREGA = dsEntregaSolicitud.Tables(0).Rows(i).Item("IDENTREGA")
                    .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                    .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                    .PORCENTAJE = dsDetalleEntregaSolicitud.Tables(0).Rows(j).Item("PORCENTAJE")
                    .TIPOCONTEO = dsDetalleEntregaSolicitud.Tables(0).Rows(j).Item("TIPOCONTEO")
                    .IDDETALLE = objDetalleEntregaProcesoCompra.ObtenerID(lEntidadDet)
                End With
                Resultado = objDetalleEntregaProcesoCompra.Agregar(lEntidadDet)
            Next
        Next
        Return Resultado
    End Function
    ''' <summary>
    ''' Informacion de una entrega por proceso de compra
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDENTREGA">Identificador de las entregas</param>
    ''' <returns>Informacion de la entrega en forma de dataset</returns>

    Public Function ObtenerDataSetPorIDENTREGA(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDENTREGA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.Int)
        args(2).Value = IDENTREGA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ' AUTOR: JOSE CHAVEZ 
    '-------------------------------------------------------------------------------------------------------------------------
    ' En esta función valida si existe correlativo de solicitud
    ' FECHA 04/12/06 
    '-------------------------------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Validación de la entrega
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDENTREGA">Identificador de las entregas</param>
    ''' <returns>Valor entero con el resultado de la validacion</returns>

    Public Function ValidarIDENTREGA(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDENTREGA As Int16) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_UACI_ENTREGAPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDENTREGA = @IDENTREGA")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDENTREGA", SqlDbType.SmallInt)
        args(2).Value = IDENTREGA

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

#End Region
    ''' <summary>
    ''' Adición de la información de entregas de un proceso de compras
    ''' </summary>
    ''' <param name="ARR_SOLICITUD">Identificador de las solicitudes</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador de los establecimientos</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compras</param>
    ''' <returns>Valor entero con el resultado de las entregas</returns>

    Public Function AgregarEntregasProcesoCompra2(ByVal ARR_SOLICITUD As listaSOLICITUDES, ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As Integer
        Try
            Dim strSQL As New Text.StringBuilder
            Dim objDetalleEntregaProcesoCompra As New dbDETALLEENTREGASPROCESOCOMPRA

            For Each solic As SOLICITUDES In ARR_SOLICITUD
                'para una entrega
                strSQL.Append(" select identrega ")
                strSQL.Append(" from sab_est_entregas ")
                strSQL.Append(" where idsolicitud=" & solic.IDSOLICITUD) 'and porcentajeentrega=100 ")
                strSQL.Append(" group by identrega ")

                Dim ds As DataSet
                ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

                If ds.Tables(0).Rows.Count > 0 Then
                    Dim lEntidad As New ENTREGAPROCESOCOMPRA
                    Dim row As DataRow = ds.Tables(0).NewRow
                    For Each row In ds.Tables(0).Rows
                        With lEntidad
                            .IDENTREGA = row("identrega")
                            .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                        End With
                        Me.Agregar(lEntidad)
                    Next

                    Dim strSQL2 As New Text.StringBuilder
                    strSQL2.Append(" select identrega,numeroentrega,diasentrega,porcentajeentrega ")
                    strSQL2.Append(" from sab_est_entregas ")
                    strSQL2.Append(" where idsolicitud=" & solic.IDSOLICITUD) ' & " and porcentajeentrega=100 and idproducto=" & ds.Tables(0).Rows(0).Item(0))
                    'strSQL2.Append(" group by idproducto,iddetalle,plazoentrega,porcentajeentrega ")
                    Dim ds2 As DataSet
                    ds2 = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL2.ToString())

                    Dim lEntidadDet As New DETALLEENTREGASPROCESOCOMPRA
                    Dim row2 As DataRow = ds2.Tables(0).NewRow
                    For Each row2 In ds2.Tables(0).Rows
                        With lEntidadDet
                            .DIAS = row2("diasentrega")
                            .IDFECHACONTEO = 1
                            .IDENTREGA = row2("identrega")
                            .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                            .PORCENTAJE = row2("porcentajeentrega")
                            .TIPOCONTEO = 1
                            .IDDETALLE = row2("numeroentrega")
                        End With
                        objDetalleEntregaProcesoCompra.Agregar(lEntidadDet)
                    Next
                End If

                ''para dos entregas
                'Dim strSQL3 As New Text.StringBuilder
                'strSQL3.Append(" select idproducto,iddetalle,plazoentrega,porcentajeentrega ")
                'strSQL3.Append(" from sab_est_entregasolicitudes ")
                'strSQL3.Append(" where idsolicitud=" & solic.IDSOLICITUD & " and iddetalle<3 and porcentajeentrega<>100 ")
                'strSQL3.Append(" group by idproducto,iddetalle,plazoentrega,porcentajeentrega ")
                'Dim ds3 As DataSet
                'ds3 = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL3.ToString())
                'If ds3.Tables(0).Rows.Count > 0 Then
                '    Dim strSQL4 As New Text.StringBuilder
                '    strSQL4.Append(" select idproducto,iddetalle,plazoentrega,porcentajeentrega ")
                '    strSQL4.Append(" from sab_est_entregasolicitudes ")
                '    strSQL4.Append(" where idsolicitud=" & solic.IDSOLICITUD & " and iddetalle<3 and porcentajeentrega<>100 and idproducto=" & ds3.Tables(0).Rows(0).Item(0))
                '    strSQL4.Append(" group by idproducto,iddetalle,plazoentrega,porcentajeentrega  order by iddetalle")
                '    Dim ds4 As DataSet
                '    ds4 = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL4.ToString())

                '    Dim lEntidad As New ENTREGAPROCESOCOMPRA
                '    Dim lEntidadDet As New DETALLEENTREGASPROCESOCOMPRA
                'With lEntidad
                '    .IDENTREGA = 2
                '    .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                '    .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                'End With
                'Me.Agregar(lEntidad)

                '    With lEntidadDet
                '        .DIAS = ds4.Tables(0).Rows(0).Item(2)
                '        .IDFECHACONTEO = 1
                '        .IDENTREGA = 2
                '        .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                '        .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                '        .PORCENTAJE = ds4.Tables(0).Rows(0).Item(3)
                '        .TIPOCONTEO = 1
                '        .IDDETALLE = objDetalleEntregaProcesoCompra.ObtenerID(lEntidadDet)
                '    End With
                '    objDetalleEntregaProcesoCompra.Agregar(lEntidadDet)

                '    'With lEntidad
                '    '    .IDENTREGA = 2
                '    '    .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                '    '    .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                '    'End With
                '    'Me.Agregar(lEntidad)

                '    With lEntidadDet
                '        .DIAS = ds4.Tables(0).Rows(1).Item(2)
                '        .IDFECHACONTEO = 1
                '        .IDENTREGA = 2
                '        .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                '        .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                '        .PORCENTAJE = ds4.Tables(0).Rows(1).Item(3)
                '        .TIPOCONTEO = 1
                '        .IDDETALLE = objDetalleEntregaProcesoCompra.ObtenerID(lEntidadDet)
                '    End With
                '    objDetalleEntregaProcesoCompra.Agregar(lEntidadDet)

                'End If

                ''para tres entregas
                'Dim strSQL5 As New Text.StringBuilder
                'strSQL5.Append(" select idproducto,iddetalle,plazoentrega,porcentajeentrega ")
                'strSQL5.Append(" from sab_est_entregasolicitudes ")
                'strSQL5.Append(" where idsolicitud=" & solic.IDSOLICITUD & " and iddetalle=3 ")
                'strSQL5.Append(" group by idproducto,iddetalle,plazoentrega,porcentajeentrega ")
                'Dim ds5 As DataSet
                'ds5 = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL5.ToString())
                'If ds5.Tables(0).Rows.Count > 0 Then
                '    Dim strSQL6 As New Text.StringBuilder
                '    strSQL6.Append(" select idproducto,iddetalle,plazoentrega,porcentajeentrega ")
                '    strSQL6.Append(" from sab_est_entregasolicitudes ")
                '    strSQL6.Append(" where idsolicitud=" & solic.IDSOLICITUD & " and idproducto=" & ds5.Tables(0).Rows(0).Item(0))
                '    strSQL6.Append(" group by idproducto,iddetalle,plazoentrega,porcentajeentrega  order by iddetalle")
                '    Dim ds6 As DataSet
                '    ds6 = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL6.ToString())

                '    Dim lEntidad As New ENTREGAPROCESOCOMPRA
                '    Dim lEntidadDet As New DETALLEENTREGASPROCESOCOMPRA
                'With lEntidad
                '        .IDENTREGA = 3
                '    .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                '    .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                'End With
                'Me.Agregar(lEntidad)

                '    With lEntidadDet
                '        .DIAS = ds6.Tables(0).Rows(0).Item(2)
                '        .IDFECHACONTEO = 1
                '        .IDENTREGA = 1
                '        .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                '        .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                '        .PORCENTAJE = ds6.Tables(0).Rows(0).Item(3)
                '        .TIPOCONTEO = 1
                '        .IDDETALLE = objDetalleEntregaProcesoCompra.ObtenerID(lEntidadDet)
                '    End With
                '    objDetalleEntregaProcesoCompra.Agregar(lEntidadDet)

                '    'With lEntidad
                '    '    .IDENTREGA = 2
                '    '    .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                '    '    .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                '    'End With
                '    'Me.Agregar(lEntidad)

                '    With lEntidadDet
                '        .DIAS = ds6.Tables(0).Rows(1).Item(2)
                '        .IDFECHACONTEO = 1
                '    .IDENTREGA = 3
                '    .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                '    .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                '        .PORCENTAJE = ds6.Tables(0).Rows(1).Item(3)
                '        .TIPOCONTEO = 1
                '        .IDDETALLE = objDetalleEntregaProcesoCompra.ObtenerID(lEntidadDet)
                'End With
                '    objDetalleEntregaProcesoCompra.Agregar(lEntidadDet)

                '    'With lEntidad
                '    '    .IDENTREGA = 3
                '    '    .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                '    '    .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                '    'End With
                '    'Me.Agregar(lEntidad)

                '    With lEntidadDet
                '        .DIAS = ds6.Tables(0).Rows(2).Item(2)
                '        .IDFECHACONTEO = 1
                '        .IDENTREGA = 3
                '        .IDESTABLECIMIENTO = IDESTABLECIMIENTO
                '        .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                '        .PORCENTAJE = ds6.Tables(0).Rows(2).Item(3)
                '        .TIPOCONTEO = 1
                '        .IDDETALLE = objDetalleEntregaProcesoCompra.ObtenerID(lEntidadDet)
                '    End With
                '    objDetalleEntregaProcesoCompra.Agregar(lEntidadDet)
                'End If

                'para 4 entregas
                'Dim strSQL4 As New Text.StringBuilder
                'strSQL.Append(" select idproducto,iddetalle,plazoentrega,porcentajeentrega ")
                'strSQL.Append(" from sab_est_entregasolicitudes ")
                'strSQL.Append(" where idsolicitud=" & solic.IDSOLICITUD & " and porcentajeentrega=100 ")
                'strSQL.Append(" group by idproducto,iddetalle,plazoentrega,porcentajeentrega ")

            Next
            Return 1
        Catch ex As Exception
            Return -1
        End Try

    End Function

End Class
