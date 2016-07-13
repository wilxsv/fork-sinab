Imports System.Text

Partial Public Class dbNECESIDADESSOLICITUD

#Region " Metodos Agregados "

    ''' <summary>
    ''' Devuelve la información del plan de distribución para la UTMIM por establecimiento.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que elaboro la consolidación.</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud.</param>
    ''' <returns>Dataset con la información del plan de distribución UTMIM.</returns>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  11/11/2006    Creado
    ''' </history> 
    Public Function ObtenerDataSetDistribucion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet

        Dim strSQL As New StringBuilder
        'strSQL.Append("SELECT ")
        'strSQL.Append("NS.IDESTABLECIMIENTOSOLICITUD, ")
        'strSQL.Append("NS.IDESTABLECIMIENTONECESIDAD, ")
        'strSQL.Append("NS.IDNECESIDAD, ")
        'strSQL.Append("NS.IDSOLICITUD, ")
        'strSQL.Append("DNE.IDPRODUCTO, ")
        'strSQL.Append("CP.CORRPRODUCTO, ")
        'strSQL.Append("CP.DESCLARGO, ")
        'strSQL.Append("CP.DESCRIPCION, ")
        'strSQL.Append("DNE.NECESIDADFINAL, ")
        'strSQL.Append("DS.RENGLON, ")
        'strSQL.Append("DS.NUMEROENTREGAS, ")
        'strSQL.Append("E.NOMBRE, ")
        'strSQL.Append("E.CODIGOESTABLECIMIENTO, ")
        'strSQL.Append("DNE.PRECIOUNITARIO, ")
        'strSQL.Append("CP.CODIGONACIONESUNIDAS, ")
        'strSQL.Append("A.NOMBRE as ALMACEN ")

        'strSQL.Append("FROM SAB_EST_NECESIDADESSOLICITUD AS NS ")
        'strSQL.Append("INNER JOIN SAB_EST_DETALLENECESIDADESTABLECIMIENTOS AS DNE ")
        'strSQL.Append("ON NS.IDESTABLECIMIENTONECESIDAD = DNE.IDESTABLECIMIENTO ")
        'strSQL.Append("AND NS.IDNECESIDAD = DNE.IDNECESIDAD ")

        'strSQL.Append("INNER JOIN SAB_EST_NECESIDADESTABLECIMIENTOS AS NE ")
        'strSQL.Append("ON NE.IDESTABLECIMIENTO = DNE.IDESTABLECIMIENTO ")
        'strSQL.Append("AND NE.IDNECESIDAD = DNE.IDNECESIDAD ")

        'strSQL.Append("INNER JOIN SAB_EST_DETALLESOLICITUDES AS DS ")
        'strSQL.Append("ON NS.IDSOLICITUD = DS.IDSOLICITUD ")
        'strSQL.Append("AND NS.IDESTABLECIMIENTOSOLICITUD = DS.IDESTABLECIMIENTO ")
        'strSQL.Append("AND DNE.IDPRODUCTO = DS.IDPRODUCTO ")
        'strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS AS CP ")
        'strSQL.Append("ON DNE.IDPRODUCTO = CP.IDPRODUCTO ")
        'strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        'strSQL.Append("ON DNE.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")

        'strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        'strSQL.Append("ON A.IDALMACEN = NE.IDALMACENENTREGA ")

        'strSQL.Append("WHERE ")
        'strSQL.Append("NS.IDESTABLECIMIENTOSOLICITUD = @IDESTABLECIMIENTO ")
        'strSQL.Append("AND NS.IDSOLICITUD = @IDSOLICITUD ")
        'strSQL.Append("ORDER BY DS.RENGLON, E.CODIGOESTABLECIMIENTO")

        strSQL.Append("SELECT ")
        strSQL.Append("AES.IDESTABLECIMIENTO,  ")
        strSQL.Append("E.IDESTABLECIMIENTO as IDESTABLECIMIENTONECESIDAD,  ")
        strSQL.Append("AES.IDSOLICITUD,  ")
        strSQL.Append("AES.IDPRODUCTO,  ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("SUM(AES.CANTIDAD) AS NECESIDADFINAL,  ")
        strSQL.Append("AES.RENGLON,  ")
        strSQL.Append("DS.NUMEROENTREGAS, ")
        strSQL.Append("E.NOMBRE, ")
        strSQL.Append("E.CODIGOESTABLECIMIENTO, ")
        strSQL.Append("AES.PRECIOUNITARIO,  ")
        strSQL.Append("CP.CODIGONACIONESUNIDAS, ")
        strSQL.Append("A.NOMBRE as ALMACEN,  ")
        strSQL.Append("AES.IDFUENTEFINANCIAMIENTO,  ")
        strSQL.Append("F.NOMBRE as FUENTEFINANCIAMIENTO  ")
        strSQL.Append(" ")
        strSQL.Append("FROM SAB_EST_ALMACENESENTREGASOLICITUD AES ")
        strSQL.Append("INNER JOIN dbo.SAB_EST_ENTREGASOLICITUDES AS ES ")
        strSQL.Append("ON AES.IDESTABLECIMIENTO = ES.IDESTABLECIMIENTO  ")
        strSQL.Append("AND AES.IDSOLICITUD = ES.IDSOLICITUD  ")
        strSQL.Append("AND AES.IDPRODUCTO = ES.IDPRODUCTO ")
        strSQL.Append("AND AES.IDENTREGA = ES.IDENTREGA ")
        strSQL.Append("AND AES.RENGLON = ES.RENGLON ")
        strSQL.Append(" ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLESOLICITUDES AS DS ")
        strSQL.Append("ON ES.IDSOLICITUD = DS.IDSOLICITUD  ")
        strSQL.Append("AND ES.IDESTABLECIMIENTO = DS.IDESTABLECIMIENTO  ")
        strSQL.Append("AND ES.IDPRODUCTO = DS.IDPRODUCTO  ")
        strSQL.Append("AND ES.RENGLON = DS.RENGLON  ")
        strSQL.Append(" ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS AS CP ")
        strSQL.Append("ON AES.IDPRODUCTO = CP.IDPRODUCTO  ")
        strSQL.Append(" ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("ON A.IDALMACEN = AES.IDALMACENENTREGA  ")
        strSQL.Append(" ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE  ")
        strSQL.Append("ON AE.IDALMACEN= AES.IDALMACENENTREGA ")
        strSQL.Append(" ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON E.IDESTABLECIMIENTO=AE.IDESTABLECIMIENTO ")

        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS F ")
        strSQL.Append("ON F.IDFUENTEFINANCIAMIENTO=AES.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append(" ")
        strSQL.Append("WHERE ")
        strSQL.Append("AES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO  ")
        strSQL.Append("AND AES.IDSOLICITUD = @IDSOLICITUD  ")
        strSQL.Append(" ")
        strSQL.Append(" GROUP BY AES.IDESTABLECIMIENTO, E.IDESTABLECIMIENTO, AES.IDSOLICITUD, AES.IDPRODUCTO, CP.CORRPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION, AES.RENGLON, DS.NUMEROENTREGAS, E.NOMBRE, E.CODIGOESTABLECIMIENTO, AES.PRECIOUNITARIO, CP.CODIGONACIONESUNIDAS, A.NOMBRE,AES.IDFUENTEFINANCIAMIENTO, F.NOMBRE  ") ' AES.CANTIDAD,
        strSQL.Append("ORDER BY AES.RENGLON, E.CODIGOESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Eliminar solicitud
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo NECESIDADESSOLICITUD
    ''' <returns>
    ''' numero de registros afectados con la operacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function Eliminarsolicitud(ByVal aEntidad As NECESIDADESSOLICITUD) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_NECESIDADESSOLICITUD ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTOSOLICITUD = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTOSOLICITUD

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve la información del plan de distribución para la UACI.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento. (Filtro)</param>
    ''' <param name="IDPROCESOCOMPRA ">Identificador del proceso compra. (Filtro)</param>
    ''' <returns>Dataset con la información del plan de distribución UTMIM.</returns>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  11/11/2006    Creado
    ''' </history> 
    Public Function ObtenerDistribucionUACI(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("NS.IDESTABLECIMIENTOSOLICITUD, ")
        strSQL.Append("NS.IDESTABLECIMIENTONECESIDAD, ")
        strSQL.Append("NS.IDNECESIDAD, ")
        strSQL.Append("NS.IDSOLICITUD, ")
        strSQL.Append("DNE.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("DNE.NECESIDADFINAL, ")
        strSQL.Append("DS.RENGLON, ")
        strSQL.Append("DS.NUMEROENTREGAS, ")
        strSQL.Append("(E.CODIGOESTABLECIMIENTO + '  ' + E.NOMBRE) NOMBRE, ")
        strSQL.Append("DNE.PRECIOUNITARIO, ")
        strSQL.Append("CP.CODIGONACIONESUNIDAS, ")
        strSQL.Append("PC.IDPROCESOCOMPRA, ")
        strSQL.Append("PC.CODIGOLICITACION, ")
        strSQL.Append("PC.TITULOLICITACION, ")
        strSQL.Append("PC.DESCRIPCIONLICITACION ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("INNER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC ")
        strSQL.Append("ON PC.IDPROCESOCOMPRA = SPC.IDPROCESOCOMPRA AND PC.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_EST_NECESIDADESSOLICITUD NS ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLENECESIDADESTABLECIMIENTOS DNE ")
        strSQL.Append("ON NS.IDESTABLECIMIENTONECESIDAD = DNE.IDESTABLECIMIENTO AND NS.IDNECESIDAD = DNE.IDNECESIDAD ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLESOLICITUDES DS ")
        strSQL.Append("ON NS.IDSOLICITUD = DS.IDSOLICITUD AND NS.IDESTABLECIMIENTOSOLICITUD = DS.IDESTABLECIMIENTO AND DNE.IDPRODUCTO = DS.IDPRODUCTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DNE.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON DNE.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ON SPC.IDSOLICITUD = NS.IDSOLICITUD AND SPC.IDESTABLECIMIENTOSOLICITUD = NS.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append("WHERE ")
        strSQL.Append("PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("ORDER BY DS.RENGLON ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
