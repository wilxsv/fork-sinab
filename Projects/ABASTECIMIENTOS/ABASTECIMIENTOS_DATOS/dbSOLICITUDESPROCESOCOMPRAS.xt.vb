Partial Public Class dbSOLICITUDESPROCESOCOMPRAS

#Region " Metodos Agregados "

    ' Comentario
    ' Autor: Juan José Rivas
    ' Presenta un listado de solicitudes consolidadas para un proceso de compra relacionadas con las siguientes tablas:
    ' DEPENDENCIA
    ' FUENTEFINANCIAMIENTOS
    ' SOLICITUDESPROCESOCOMPRAS
    ' TIPOPRODUCTOS
    Public Function ObtenerSolProcCompra(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL, strSQLDet As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("SL.IDESTABLECIMIENTO, ")
        strSQL.Append("SL.IDSOLICITUD, ")
        strSQL.Append("SL.CORRELATIVO, ")
        strSQL.Append("D.NOMBRE DEPENDENCIASOLICITANTE, ")
        strSQL.Append("SL.IDCLASESUMINISTRO, ")
        strSQL.Append("SM.DESCRIPCION CLASESUMINISTRO, ")
        strSQL.Append("isnull(SL.MONTOSOLICITADO, 0) MONTOSOLICITADO, ")
        strSQL.Append("E.DESCRIPCION ESTADO, ")
        strSQL.Append("convert(varchar, SL.FECHASOLICITUD, 103) FECHASOLICITUD ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES SL ")
        strSQL.Append("INNER JOIN SAB_CAT_DEPENDENCIAS D ")
        strSQL.Append("ON SL.IDDEPENDENCIASOLICITANTE = D.IDDEPENDENCIA ")
        strSQL.Append("INNER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC ")
        strSQL.Append("ON (SL.IDSOLICITUD = SPC.IDSOLICITUD ")
        strSQL.Append("AND SL.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTOSOLICITUD) ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS SM ")
        strSQL.Append("ON SL.IDCLASESUMINISTRO = SM.IDSUMINISTRO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOS E ")
        strSQL.Append("ON SL.IDESTADO = E.IDESTADO ")
        strSQL.Append("WHERE SPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' dataset solicitudes asociadas a un proceso de compra
    ''' </summary>
    ''' <param name="idProceso"></param> identificador de proceso de compra
    ''' <param name="idESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' dataset con los datos solicitados
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_EST_SOLICITUDESPROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetProcesosComprasSolicitudes(ByVal IDPROCESO As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT s.IDSOLICITUD, s.IDESTABLECIMIENTO, (s.CORRELATIVO+'-'+ ISNULL( rtrim(s.CorrelativoGeneral) + char(10), '' )) as CORRELATIVO,  s.FECHASOLICITUD, s.PLAZOENTREGA, s.IDCLASESUMINISTRO, s.PERIODOUTILIZACION, ")
        strSQL.Append("s.MONTOSOLICITADO, s.MONTOSOLICITADO as MONTODISPONIBLE, s.OBSERVACION, s.IDSOLICITANTE, s.IDAREATECNICA, s.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append("s.RESERVAFONDO, s.FECHAAUTORIZACION, s.MONTOAUTORIZADO, s.CODRESERVAFONDO, s.IDCERTIFICA, s.IDAUTORIZA, s.IDESTADO, ")
        strSQL.Append("s.IDDEPENDENCIASOLICITANTE, s.IDTIPOCOMPRASOLICITADO, s.IDTIPOCOMPRASUGERIDO, s.IDTIPOCOMPRAEJECUTAR, s.AUUSUARIOCREACION, ")
        strSQL.Append("s.AUFECHACREACION, s.AUUSUARIOMODIFICACION, s.AUFECHAMODIFICACION, s.ESTASINCRONIZADA, PC.IDPROCESOCOMPRA, ")
        strSQL.Append("SAB_CAT_SUMINISTROS.DESCRIPCION AS SUMINISTRO, SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE AS FUENTE, PC.FECHAINICIOANALISIS, PC.FECHAFINEXAMEN, ")
        strSQL.Append("SAB_CAT_DEPENDENCIAS.NOMBRE AS DEPENDENCIA ")

        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append("SAB_EST_SOLICITUDESPROCESOCOMPRAS AS SP ON PC.IDPROCESOCOMPRA = SP.IDPROCESOCOMPRA AND ")
        strSQL.Append("PC.IDESTABLECIMIENTO = SP.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_EST_SOLICITUDES AS s ON SP.IDSOLICITUD = s.IDSOLICITUD AND SP.IDESTABLECIMIENTOSOLICITUD = s.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_SUMINISTROS ON s.IDCLASESUMINISTRO = SAB_CAT_SUMINISTROS.IDSUMINISTRO INNER JOIN ")
        strSQL.Append("SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ON s.IDSOLICITUD = SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDSOLICITUD AND ")
        strSQL.Append("s.IDESTABLECIMIENTO = SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_FUENTEFINANCIAMIENTOS ON ")
        strSQL.Append("SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO = SAB_CAT_FUENTEFINANCIAMIENTOS.IDFUENTEFINANCIAMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_DEPENDENCIAS ON s.IDDEPENDENCIASOLICITANTE = SAB_CAT_DEPENDENCIAS.IDDEPENDENCIA ")
        strSQL.Append("WHERE PC.IDPROCESOCOMPRA = @IDPROCESO ")
        strSQL.Append("AND PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' dataset con las solicitudes de un proceso de compra
    ''' </summary>
    ''' <param name="idProceso"></param> identificador del proceso de compra
    ''' <param name="idEstablecimiento"></param> identificador del establecimiento
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_EST_SOLICITUDESPROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetProcesosComprasSolicitudesconFuente(ByVal IDPROCESO As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataTable

        Dim strSQL, strSQLDet As New Text.StringBuilder
        strSQL.Append("SELECT s.IDSOLICITUD, s.IDESTABLECIMIENTO, s.CORRELATIVO, s.FECHASOLICITUD, s.PLAZOENTREGA, s.IDCLASESUMINISTRO, s.PERIODOUTILIZACION, ")
        strSQL.Append("s.MONTOSOLICITADO, s.MONTODISPONIBLE, s.OBSERVACION, s.IDSOLICITANTE, s.IDAREATECNICA, s.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append("s.RESERVAFONDO, s.FECHAAUTORIZACION, s.MONTOAUTORIZADO, s.CODRESERVAFONDO, s.IDCERTIFICA, s.IDAUTORIZA, s.IDESTADO, ")
        strSQL.Append("s.IDDEPENDENCIASOLICITANTE, s.IDTIPOCOMPRASOLICITADO, s.IDTIPOCOMPRASUGERIDO, s.IDTIPOCOMPRAEJECUTAR, s.AUUSUARIOCREACION, ")
        strSQL.Append("s.AUFECHACREACION, s.AUUSUARIOMODIFICACION, s.AUFECHAMODIFICACION, s.ESTASINCRONIZADA, PC.IDPROCESOCOMPRA, ")
        strSQL.Append("SAB_CAT_SUMINISTROS.DESCRIPCION AS SUMINISTRO, SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE AS FUENTE, PC.FECHAINICIOANALISIS, ")
        strSQL.Append("SAB_CAT_DEPENDENCIAS.NOMBRE AS DEPENDENCIA ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append("SAB_EST_SOLICITUDESPROCESOCOMPRAS AS SP ON PC.IDPROCESOCOMPRA = SP.IDPROCESOCOMPRA AND ")
        strSQL.Append("PC.IDESTABLECIMIENTO = SP.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_EST_SOLICITUDES AS s ON SP.IDSOLICITUD = s.IDSOLICITUD AND SP.IDESTABLECIMIENTOSOLICITUD = s.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_EST_SUMINISTROS ON s.IDCLASESUMINISTRO = SAB_EST_SUMINISTROS.IDSUMINISTRO INNER JOIN ")
        strSQL.Append("SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ON s.IDSOLICITUD = SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDSOLICITUD AND ")
        strSQL.Append("s.IDESTABLECIMIENTO = SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_FUENTEFINANCIAMIENTOS ON ")
        strSQL.Append("SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO = SAB_CAT_FUENTEFINANCIAMIENTOS.IDFUENTEFINANCIAMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_DEPENDENCIAS ON s.IDDEPENDENCIASOLICITANTE = SAB_CAT_DEPENDENCIAS.IDDEPENDENCIA ")
        strSQL.Append("WHERE PC.IDPROCESOCOMPRA = @IDPROCESO ")
        strSQL.Append("AND PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO

        Dim dsDatos As DataSet
        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dr As DataRow

        Dim i, j As Integer

        For j = 0 To dsDatos.Tables(0).Rows.Count - 1

            dr = dt.NewRow
            dr(0) = dsDatos.Tables(0).Rows(j).Item(0)
            dr(1) = dsDatos.Tables(0).Rows(j).Item(1)
            dr(3) = dsDatos.Tables(0).Rows(j).Item(2)
            dr(4) = dsDatos.Tables(0).Rows(j).Item(3)
            dr(5) = dsDatos.Tables(0).Rows(j).Item(4)
            dr(6) = dsDatos.Tables(0).Rows(j).Item(5)
            dr(7) = dsDatos.Tables(0).Rows(j).Item(6)
            dr(8) = dsDatos.Tables(0).Rows(j).Item(7)
            dr(9) = dsDatos.Tables(0).Rows(j).Item(8)
            dr(10) = dsDatos.Tables(0).Rows(j).Item(9)
            dr(11) = dsDatos.Tables(0).Rows(j).Item(10)
            dr(12) = dsDatos.Tables(0).Rows(j).Item(11)
            dr(13) = dsDatos.Tables(0).Rows(j).Item(12)
            dr(14) = dsDatos.Tables(0).Rows(j).Item(13)
            dr(15) = dsDatos.Tables(0).Rows(j).Item(14)
            dr(16) = dsDatos.Tables(0).Rows(j).Item(15)
            dr(17) = dsDatos.Tables(0).Rows(j).Item(16)
            dr(18) = dsDatos.Tables(0).Rows(j).Item(17)
            dr(19) = dsDatos.Tables(0).Rows(j).Item(18)
            dr(20) = dsDatos.Tables(0).Rows(j).Item(19)
            dr(21) = dsDatos.Tables(0).Rows(j).Item(20)
            dr(22) = dsDatos.Tables(0).Rows(j).Item(21)
            dr(23) = dsDatos.Tables(0).Rows(j).Item(22)
            dr(24) = dsDatos.Tables(0).Rows(j).Item(23)
            dr(25) = dsDatos.Tables(0).Rows(j).Item(24)
            dr(26) = dsDatos.Tables(0).Rows(j).Item(25)
            dr(27) = dsDatos.Tables(0).Rows(j).Item(26)
            dr(28) = dsDatos.Tables(0).Rows(j).Item(27)
            dr(29) = dsDatos.Tables(0).Rows(j).Item(28)
            dr(30) = dsDatos.Tables(0).Rows(j).Item(29)
            dr(31) = dsDatos.Tables(0).Rows(j).Item(30)

            strSQLDet.Append("SELECT SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDSOLICITUD, SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO, ")
            strSQLDet.Append(" SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE, SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDESTABLECIMIENTO ")
            strSQLDet.Append(" FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES INNER JOIN ")
            strSQLDet.Append(" SAB_CAT_FUENTEFINANCIAMIENTOS ON ")
            strSQLDet.Append(" SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO = SAB_CAT_FUENTEFINANCIAMIENTOS.IDFUENTEFINANCIAMIENTO ")
            strSQLDet.Append(" WHERE (SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDSOLICITUD = @IDSOLICITUD)")

            Dim argsDet(1) As SqlParameter
            argsDet(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
            argsDet(0).Value = dsDatos.Tables(0).Rows(j).Item(2)
            argsDet(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
            argsDet(1).Value = IDESTABLECIMIENTO

            Dim dsDatosDet As DataSet
            dsDatosDet = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQLDet.ToString(), argsDet)

            For i = 0 To dsDatosDet.Tables(0).Rows.Count - 1

                If i = dsDatosDet.Tables(0).Rows.Count - 1 Then
                    dr(2) = dr(2) + dsDatosDet.Tables(0).Rows(i).Item(2)
                Else
                    dr(2) = dr(2) + dsDatosDet.Tables(0).Rows(i).Item(2) & " / "
                End If
            Next

            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

    Public Function ObtenerProcesosComprasSolicitudes(ByVal IDPROCESO As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT S.MONTOSOLICITADO, S.IDESTABLECIMIENTO, S.IDSOLICITUD, S.CORRELATIVO, S.FECHASOLICITUD, S.PLAZOENTREGA, S.IDCLASESUMINISTRO, ")
        strSQL.Append(" S.PERIODOUTILIZACION, S.MONTODISPONIBLE, S.OBSERVACION, S.IDSOLICITANTE, S.IDAREATECNICA, S.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" S.RESERVAFONDO, S.FECHAAUTORIZACION, S.MONTOAUTORIZADO, S.CODRESERVAFONDO, S.IDCERTIFICA, S.IDAUTORIZA, S.IDESTADO, ")
        strSQL.Append(" S.IDDEPENDENCIASOLICITANTE, S.IDTIPOCOMPRASOLICITADO, S.IDTIPOCOMPRASUGERIDO, S.IDTIPOCOMPRAEJECUTAR, S.IDALMACENENTREGA, ")
        strSQL.Append(" S.COMPRACONJUNTA, S.NUMCORR, S.IDESTABLECIMIENTOENTREGA, ")
        strSQL.Append(" ISNULL(E.DIRECCION,'') AS DIRECCIONESTABLECIMIENTO, ISNULL(A.DIRECCION,'') AS DIRECCIONALMACEN, ")
        strSQL.Append(" D.NOMBRE AS DEPEDENCIASOLICITANTE, ISNULL(E.NOMBRE,'') AS ESTABLECIMIENTOENTREGA, ISNULL(A.NOMBRE,'') AS ALMACENENTREGA ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS AS SPC ")
        strSQL.Append(" ON PC.IDPROCESOCOMPRA = SPC.IDPROCESOCOMPRA AND PC.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTO ")
        strSQL.Append(" INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDES AS S ")
        strSQL.Append(" ON S.IDSOLICITUD = SPC.IDSOLICITUD AND S.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append(" LEFT JOIN SAB_CAT_ESTABLECIMIENTOS E ON ")
        strSQL.Append("  E.IDESTABLECIMIENTO = S.IDESTABLECIMIENTOENTREGA ")
        strSQL.Append(" LEFT JOIN SAB_CAT_ALMACENES A ON ")
        strSQL.Append(" A.IDALMACEN = S.IDALMACENENTREGA ")
        strSQL.Append(" INNER JOIN SAB_CAT_DEPENDENCIAS D ON ")
        strSQL.Append(" D.IDDEPENDENCIA = S.IDDEPENDENCIASOLICITANTE ")
        strSQL.Append(" WHERE (PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (PC.IDPROCESOCOMPRA = @IDPROCESO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(1).Value = IDPROCESO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerIdSolicitud(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDSOLICITUD ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDESPROCESOCOMPRAS ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim dr As Integer
        dr = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return dr

    End Function

#End Region

End Class
