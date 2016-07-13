Partial Public Class dbFUENTEFINANCIAMIENTOSOLICITUDES

#Region " Métodos Agregados "

    ''' <summary>
    ''' Obtener dataset con las fuente de financiamiento asociadas a un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">identificador de establecimientos</param> 
    ''' <param name="IDPROCESOCOMPRA">identificador de proceso de compras</param> 
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' <item><description>SAB_EST_SOLICITUDESPROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history>
    Public Function obtenerdatasetFuenteFinanciamientoProceCompra(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA, SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE, ")
        strSQL.Append("SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append("INNER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS ")
        strSQL.Append("ON SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDSOLICITUD = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD ")
        strSQL.Append("AND SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDESTABLECIMIENTO = SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS ")
        strSQL.Append("ON SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO = SAB_CAT_FUENTEFINANCIAMIENTOS.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("WHERE SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", IDPROCESOCOMPRA)
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", IDESTABLECIMIENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Eliminar fuente de financiamiento de una solicitud
    ''' </summary>
    ''' <param name="aEntidad"> entidad del tipo FUENTEFINANCIAMIENTOSOLICITUDES</param>
    ''' <returns>
    ''' numero de registros afectados con la operacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function EliminarFuentesSolicitud(ByVal aEntidad As FUENTEFINANCIAMIENTOSOLICITUDES) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.VarChar)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtener listado de fuentes de financiamiento por solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">identificador del establecimiento</param> 
    ''' <param name="IDSOLICITUD">identificador de la solicitud</param> 
    ''' <returns>
    ''' listado de fuente de financiamiento
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDatasetFuentesPorSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener listado de fuentes de financiamiento por solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">identificador del establecimiento</param> 
    ''' <param name="IDSOLICITUD">identificador de la solicitud</param> 
    ''' <returns>
    ''' listado de fuente de financiamiento
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerListaPorSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As listaFUENTEFINANCIAMIENTOSOLICITUDES

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaFUENTEFINANCIAMIENTOSOLICITUDES

        Try
            Do While dr.Read()
                Dim mEntidad As New FUENTEFINANCIAMIENTOSOLICITUDES
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDSOLICITUD = IDSOLICITUD
                mEntidad.IDFUENTEFINANCIAMIENTO = IIf(dr("IDFUENTEFINANCIAMIENTO") Is DBNull.Value, Nothing, dr("IDFUENTEFINANCIAMIENTO"))
                mEntidad.MONTOPARTICIPACION = IIf(dr("MONTOPARTICIPACION") Is DBNull.Value, Nothing, dr("MONTOPARTICIPACION"))
                mEntidad.PORCENTAJEPARTICIPACION = IIf(dr("PORCENTAJEPARTICIPACION") Is DBNull.Value, Nothing, dr("PORCENTAJEPARTICIPACION"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    ''' <summary>
    ''' Calculo del monto total de la fuente de financiamiento de una solicitud
    ''' </summary>
    ''' <param name="aEntidad">entidad tipo FUENTEFINANCIAMIENTOSOLICITUDES</param> 
    ''' <returns>
    ''' valor del monto total
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CalculoMontoTotalFuentesSolicitud(ByVal aEntidad As FUENTEFINANCIAMIENTOSOLICITUDES) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(SUM(MONTOPARTICIPACION), 0) ")
        strSQL.Append("FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append("WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Calculo del porcentaje total de las fuentes de financiamiento de una solicitud
    ''' </summary>
    ''' <param name="aEntidad">entidad del tipo FUENTEFINANCIAMIENTOSOLICITUDES</param> 
    ''' <returns>
    ''' Valor del porcentaje total
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CalculoPorcentajeTotalFuentesSolicitud(ByVal aEntidad As FUENTEFINANCIAMIENTOSOLICITUDES) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(SUM(PORCENTAJEPARTICIPACION), 0) ")
        strSQL.Append("FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append("WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Validar existencia de fuente de financiamiento
    ''' </summary>
    ''' <param name="aEntidad">entidad del tipo FUENTEFINANCIAMIENTOSOLICITUDES</param> 
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarExistenciaFuente(ByVal aEntidad As FUENTEFINANCIAMIENTOSOLICITUDES) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append("WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Value = aEntidad.IDFUENTEFINANCIAMIENTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Validar si hay fuente de financiamiento asociado a la solicitud
    ''' </summary>
    ''' <param name="aEntidad"> entidad del tipo FUENTEFINANCIAMIENTOSOLICITUDES</param>
    ''' <returns>
    ''' verdadero si hay fuentes asociados
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarHayFuenteAsociadaSolicitud(ByVal aEntidad As FUENTEFINANCIAMIENTOSOLICITUDES) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append("WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Obtener listado de nombres de fuente de financiamiento asociados a una solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">identificador del establecimiento</param> 
    ''' <param name="IDSOLICITUD">identificador de la solicitud</param> 
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history>
    Public Function ObtenerNombresFuenteFinanciamientoSolicitud(ByVal IDESTABLECIMIENTO As Int64, ByVal IDSOLICITUD As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE ")
        strSQL.Append("FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS ")
        strSQL.Append("ON SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDFUENTEFINANCIAMIENTO = SAB_CAT_FUENTEFINANCIAMIENTOS.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("WHERE SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Obtiene las fuentes de financiamiento del disco URMIM
    ''' </summary>
    ''' <returns>Listado de fuentes en formato de dataset</returns>

    Public Function ObtenerFFDiscoURMIM() As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append("select t.idfuentefinanciamiento, ff.nombre, sum(t.cantidad*t.precio) as monto ")
        strSQL.Append("from temp2 t inner join sab_cat_fuentefinanciamientos ff on t.idfuentefinanciamiento=ff.idfuentefinanciamiento ")
        strSQL.Append("group by t.idfuentefinanciamiento,ff.nombre ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Metodo que obtiene las fuentes de financiamiento de la solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador para el establecimiento</param>
    ''' <param name="IDSOLICITUD">Identificador para la solicitud</param>
    ''' <returns>Listado de fuentes en formato de dataset</returns>

    Public Function ObtenerFF(ByVal IDESTABLECIMIENTO As Int64, ByVal IDSOLICITUD As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" select ffs.idfuentefinanciamiento, gff.descripcion + '/' + ff.nombre as nombre")
        strSQL.Append(" from sab_est_fuentefinanciamientosolicitudes ffs inner join sab_cat_fuentefinanciamientos ff on ffs.idfuentefinanciamiento=ff.idfuentefinanciamiento inner join SAB_CAT_GRUPOSFUENTEFINANCIAMIENTO gff on gff.idgrupo=ff.idgrupo ")
        strSQL.Append(" where idestablecimiento= " & IDESTABLECIMIENTO & " and idsolicitud=" & IDSOLICITUD)
        strSQL.Append(" group by ffs.idfuentefinanciamiento,ff.nombre,gff.descripcion ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
#End Region

End Class
