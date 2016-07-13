Partial Public Class dbDETALLENECESIDADESTABLECIMIENTOS

#Region "metodos adicionales"

    Public Function ObtenerListaPorIDEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Integer, ByVal PROPUESTA As Integer, ByVal ANIOINICIOPERIODO As Integer, ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DNE.IDESTABLECIMIENTO, ")
        strSQL.Append("DNE.IDNECESIDAD, ")
        strSQL.Append("DNE.IDPRODUCTO, ")
        strSQL.Append("DNE.IDUNIDADMEDIDA, ")
        strSQL.Append("DNE.CONSUMOANUAL, ")
        strSQL.Append("DNE.DEMANDAINSATISFECHA, ")
        strSQL.Append("DNE.RESERVAESTABLECIMIENTO, ")
        strSQL.Append("DNE.RESERVATOTAL, ")
        strSQL.Append("DNE.EXISTENCIAESTIMADA, ")
        strSQL.Append("DNE.PRECIOUNITARIO, ")
        strSQL.Append("DNE.NECESIDADREAL, ")
        strSQL.Append("DNE.NECESIDADAJUSTADA, ")
        strSQL.Append("DNE.NECESIDADFINAL, ")
        strSQL.Append("DNE.PRESUPUESTOREAL, ")
        strSQL.Append("DNE.PRESUPUESTOAJUSTADO, ")
        strSQL.Append("DNE.PRESUPUESTOFINAL, ")
        strSQL.Append("DNE.COSTOTOTALREAL, ")
        strSQL.Append("DNE.COSTOTOTALAJUSTADO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION AS UNIDAD ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS DNE ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DNE.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN  SAB_EST_NECESIDADESTABLECIMIENTOS NE ")
        strSQL.Append("ON DNE.IDNECESIDAD = NE.IDNECESIDAD ")
        strSQL.Append("AND DNE.IDESTABLECIMIENTO = NE.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE DNE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DNE.IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND NE.PROPUESTA = @PROPUESTA ")
        strSQL.Append("AND NE.ANIOINICIOPERIODO = @ANIOINICIOPERIODO ")
        strSQL.Append("AND NE.IDSUMINISTRO = @IDSUMINISTRO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@PROPUESTA", SqlDbType.Int)
        args(2).Value = PROPUESTA
        args(3) = New SqlParameter("@ANIOINICIOPERIODO", SqlDbType.Int)
        args(3).Value = ANIOINICIOPERIODO
        args(4) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(4).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerListaPorGrupo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Integer, ByVal idgrupo As Integer) As listaDETALLENECESIDADESTABLECIMIENTOS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDESTABLECIMIENTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDNECESIDAD, ")
        strSQL.Append("  SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDUNIDADMEDIDA, ")
        strSQL.Append("      SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.CONSUMOANUAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.DEMANDAINSATISFECHA, ")
        strSQL.Append("      SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.RESERVAESTABLECIMIENTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.RESERVATOTAL, ")
        strSQL.Append("         SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.EXISTENCIAESTIMADA, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRECIOUNITARIO, ")
        strSQL.Append("         SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADREAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADAJUSTADA, ")
        strSQL.Append("         SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADFINAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOREAL, ")
        strSQL.Append("        SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOAJUSTADO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOFINAL, ")
        strSQL.Append("         SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.COSTOTOTALREAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.COSTOTOTALAJUSTADO, ")
        strSQL.Append("         SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.AUUSUARIOCREACION, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.AUFECHACREACION, ")
        strSQL.Append("        SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.AUUSUARIOMODIFICACION, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.AUFECHAMODIFICACION, ")
        strSQL.Append("   SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.ESTASINCRONIZADA ")
        strSQL.Append(" FROM vv_CATALOGOPRODUCTOS INNER JOIN ")
        strSQL.Append("           SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ON ")
        strSQL.Append("    vv_CATALOGOPRODUCTOS.IDPRODUCTO = SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO ")
        strSQL.Append(" WHERE (vv_CATALOGOPRODUCTOS.IDGRUPO = @IDGRUPO) ")
        strSQL.Append("    AND SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDNECESIDAD = @IDNECESIDAD")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(2).Value = idgrupo

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLENECESIDADESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLENECESIDADESTABLECIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDNECESIDAD = IDNECESIDAD
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.CONSUMOANUAL = IIf(dr("CONSUMOANUAL") Is DBNull.Value, Nothing, dr("CONSUMOANUAL"))
                mEntidad.DEMANDAINSATISFECHA = IIf(dr("DEMANDAINSATISFECHA") Is DBNull.Value, Nothing, dr("DEMANDAINSATISFECHA"))
                mEntidad.RESERVAESTABLECIMIENTO = IIf(dr("RESERVAESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("RESERVAESTABLECIMIENTO"))
                mEntidad.RESERVATOTAL = IIf(dr("RESERVATOTAL") Is DBNull.Value, Nothing, dr("RESERVATOTAL"))
                mEntidad.EXISTENCIAESTIMADA = IIf(dr("EXISTENCIAESTIMADA") Is DBNull.Value, Nothing, dr("EXISTENCIAESTIMADA"))
                mEntidad.PRECIOUNITARIO = IIf(dr("PRECIOUNITARIO") Is DBNull.Value, Nothing, dr("PRECIOUNITARIO"))
                mEntidad.NECESIDADREAL = IIf(dr("NECESIDADREAL") Is DBNull.Value, Nothing, dr("NECESIDADREAL"))
                mEntidad.NECESIDADAJUSTADA = IIf(dr("NECESIDADAJUSTADA") Is DBNull.Value, Nothing, dr("NECESIDADAJUSTADA"))
                mEntidad.NECESIDADFINAL = IIf(dr("NECESIDADFINAL") Is DBNull.Value, Nothing, dr("NECESIDADFINAL"))
                mEntidad.PRESUPUESTOREAL = IIf(dr("PRESUPUESTOREAL") Is DBNull.Value, Nothing, dr("PRESUPUESTOREAL"))
                mEntidad.PRESUPUESTOAJUSTADO = IIf(dr("PRESUPUESTOAJUSTADO") Is DBNull.Value, Nothing, dr("PRESUPUESTOAJUSTADO"))
                mEntidad.PRESUPUESTOFINAL = IIf(dr("PRESUPUESTOFINAL") Is DBNull.Value, Nothing, dr("PRESUPUESTOFINAL"))
                mEntidad.COSTOTOTALREAL = IIf(dr("COSTOTOTALREAL") Is DBNull.Value, Nothing, dr("COSTOTOTALREAL"))
                mEntidad.COSTOTOTALAJUSTADO = IIf(dr("COSTOTOTALAJUSTADO") Is DBNull.Value, Nothing, dr("COSTOTOTALAJUSTADO"))
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

    Public Function ObtenerListaPorSubGrupo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Integer, ByVal idSubgrupo As Integer) As listaDETALLENECESIDADESTABLECIMIENTOS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDESTABLECIMIENTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDNECESIDAD, ")
        strSQL.Append("  SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDUNIDADMEDIDA, ")
        strSQL.Append("      SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.CONSUMOANUAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.DEMANDAINSATISFECHA, ")
        strSQL.Append("      SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.RESERVAESTABLECIMIENTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.RESERVATOTAL, ")
        strSQL.Append("         SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.EXISTENCIAESTIMADA, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRECIOUNITARIO, ")
        strSQL.Append("         SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADREAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADAJUSTADA, ")
        strSQL.Append("         SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADFINAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOREAL, ")
        strSQL.Append("        SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOAJUSTADO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOFINAL, ")
        strSQL.Append("         SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.COSTOTOTALREAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.COSTOTOTALAJUSTADO, ")
        strSQL.Append("         SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.AUUSUARIOCREACION, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.AUFECHACREACION, ")
        strSQL.Append("        SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.AUUSUARIOMODIFICACION, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.AUFECHAMODIFICACION, ")
        strSQL.Append("   SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.ESTASINCRONIZADA ")
        strSQL.Append(" FROM vv_CATALOGOPRODUCTOS INNER JOIN ")
        strSQL.Append("           SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ON ")
        strSQL.Append("    vv_CATALOGOPRODUCTOS.IDPRODUCTO = SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO ")
        strSQL.Append(" WHERE (vv_CATALOGOPRODUCTOS.IDSUBGRUPO = @IDSUBGRUPO) ")
        strSQL.Append("    AND SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDNECESIDAD = @IDNECESIDAD")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        args(2).Value = idSubgrupo

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLENECESIDADESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLENECESIDADESTABLECIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDNECESIDAD = IDNECESIDAD
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.CONSUMOANUAL = IIf(dr("CONSUMOANUAL") Is DBNull.Value, Nothing, dr("CONSUMOANUAL"))
                mEntidad.DEMANDAINSATISFECHA = IIf(dr("DEMANDAINSATISFECHA") Is DBNull.Value, Nothing, dr("DEMANDAINSATISFECHA"))
                mEntidad.RESERVAESTABLECIMIENTO = IIf(dr("RESERVAESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("RESERVAESTABLECIMIENTO"))
                mEntidad.RESERVATOTAL = IIf(dr("RESERVATOTAL") Is DBNull.Value, Nothing, dr("RESERVATOTAL"))
                mEntidad.EXISTENCIAESTIMADA = IIf(dr("EXISTENCIAESTIMADA") Is DBNull.Value, Nothing, dr("EXISTENCIAESTIMADA"))
                mEntidad.PRECIOUNITARIO = IIf(dr("PRECIOUNITARIO") Is DBNull.Value, Nothing, dr("PRECIOUNITARIO"))
                mEntidad.NECESIDADREAL = IIf(dr("NECESIDADREAL") Is DBNull.Value, Nothing, dr("NECESIDADREAL"))
                mEntidad.NECESIDADAJUSTADA = IIf(dr("NECESIDADAJUSTADA") Is DBNull.Value, Nothing, dr("NECESIDADAJUSTADA"))
                mEntidad.NECESIDADFINAL = IIf(dr("NECESIDADFINAL") Is DBNull.Value, Nothing, dr("NECESIDADFINAL"))
                mEntidad.PRESUPUESTOREAL = IIf(dr("PRESUPUESTOREAL") Is DBNull.Value, Nothing, dr("PRESUPUESTOREAL"))
                mEntidad.PRESUPUESTOAJUSTADO = IIf(dr("PRESUPUESTOAJUSTADO") Is DBNull.Value, Nothing, dr("PRESUPUESTOAJUSTADO"))
                mEntidad.PRESUPUESTOFINAL = IIf(dr("PRESUPUESTOFINAL") Is DBNull.Value, Nothing, dr("PRESUPUESTOFINAL"))
                mEntidad.COSTOTOTALREAL = IIf(dr("COSTOTOTALREAL") Is DBNull.Value, Nothing, dr("COSTOTOTALREAL"))
                mEntidad.COSTOTOTALAJUSTADO = IIf(dr("COSTOTOTALAJUSTADO") Is DBNull.Value, Nothing, dr("COSTOTOTALAJUSTADO"))
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

    Public Function ObtenerListaPorCodProducto(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Integer, ByVal CODIGOPRODUCTO As String, ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL, STRSQL2 As New Text.StringBuilder
        STRSQL2.Append("Select IDPRODUCTO ")
        STRSQL2.Append(" FROM vv_CATALOGOPRODUCTOS ")
        STRSQL2.Append(" WHERE CORRPRODUCTO = @IDCodPRODUCTO ")

        Dim args1(0) As SqlParameter
        args1(0) = New SqlParameter("@IDCodPRODUCTO", CODIGOPRODUCTO)

        Dim idproducto As Integer

        Dim ds1 As DataSet
        ds1 = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, STRSQL2.ToString(), args1)

        If ds1.Tables(0).Rows.Count = 0 Then
            Return ds1
        Else
            idproducto = ds1.Tables(0).Rows(0).Item(0)

            strSQL.Append("SELECT dne.IDESTABLECIMIENTO, dne.IDNECESIDAD, dne.IDPRODUCTO, dne.IDUNIDADMEDIDA, dne.CONSUMOANUAL, ")
            strSQL.Append(" dne.DEMANDAINSATISFECHA, dne.RESERVAESTABLECIMIENTO, dne.EXISTENCIAESTIMADA, ")
            strSQL.Append(" dne.PRECIOUNITARIO, dne.NECESIDADREAL, dne.NECESIDADAJUSTADA, dne.NECESIDADFINAL, (dne.CONSUMOANUAL + dne.DEMANDAINSATISFECHA + dne.RESERVAESTABLECIMIENTO) AS TOTAL, dne.PRESUPUESTOREAL, ")
            strSQL.Append(" dne.PRESUPUESTOAJUSTADO, dne.PRESUPUESTOFINAL, (dne.PRECIOUNITARIO * dne.NECESIDADREAL)AS PRESUPUESTOARTICULO, (DNE.PRECIOUNITARIO * dne.NECESIDADAJUSTADA)AS PRESUPUESTOARTICULOAJUSTADO, ")
            strSQL.Append(" (dne.PRECIOUNITARIO * dne.NECESIDADFINAL)AS PRESUPUESTOARTICULOFINAL, dne.COSTOTOTALREAL, dne.COSTOTOTALAJUSTADO, ")
            strSQL.Append(" cp.CORRPRODUCTO, cp.DESCPRODUCTO, cp.DESCLARGO, cp.IDSUMINISTRO, cp.IDGRUPO, cp.IDSUBGRUPO, cp.DESCRIPCION AS UNIDAD FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS as dne ")
            strSQL.Append(" LEFT OUTER JOIN vv_CATALOGOPRODUCTOS as cp ON dne.IDPRODUCTO = cp.IDPRODUCTO WHERE ")
            strSQL.Append(" (dne.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (dne.IDNECESIDAD = @IDNECESIDAD) AND (cp.IDSUMINISTRO = @IDSUMINISTRO) AND (cp.IDPRODUCTO = @IDPRODUCTO)")

            Dim args(3) As SqlParameter
            args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
            args(0).Value = IDESTABLECIMIENTO
            args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.Int)
            args(1).Value = IDNECESIDAD
            args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
            args(2).Value = idproducto
            args(3) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
            args(3).Value = IDSUMINISTRO

            Dim dr As DataSet
            dr = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

            Return dr

        End If

    End Function

    Public Function ObtenerAyudaExterna(ByVal IDPADRE As Int32, ByVal IDPRODUCTO As Int64) As Int64

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("SUM(DNE.NECESIDADFINAL) AS AYUDAEXTERNA ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS DNE ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON E.IDESTABLECIMIENTO = DNE.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE (E.IDPADRE = @IDPADRE) ")
        strSQL.Append("AND (DNE.IDPRODUCTO = @IDPRODUCTO) ")
        strSQL.Append("GROUP BY E.IDPADRE, DNE.IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPADRE", SqlDbType.Int)
        args(0).Value = IDPADRE
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO

        Dim iAyudaExterna As Int64 = 0
        iAyudaExterna = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return iAyudaExterna

    End Function

    ''' <summary>
    ''' obtener informacion de detalle de productos para una necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identificador de necesidad
    ''' <returns>
    ''' </returns>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' </list>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetDetalleNecesidad(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDESTABLECIMIENTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.COMPRASENTRANSITO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDNECESIDAD, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDUNIDADMEDIDA, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.CONSUMOANUAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.DEMANDAINSATISFECHA, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.RESERVAESTABLECIMIENTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.RESERVATOTAL, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.EXISTENCIAESTIMADA, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRECIOUNITARIO, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADREAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADAJUSTADA, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADFINAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOREAL, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOAJUSTADO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOFINAL, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.COSTOTOTALREAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.COSTOTOTALAJUSTADO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.CORRPRODUCTO, vv_CATALOGOPRODUCTOS.DESCLARGO, SAB_CAT_UNIDADMEDIDAS.DESCRIPCION AS UNIDAD ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS ON SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO = vv_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS ON SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA ")
        strSQL.Append("WHERE SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener la informacion de un producto en la necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identificador de la necesidad
    ''' <param name="IDPRODUCTO"></param> 'identificador del producto
    ''' <returns>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' </list>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetDetalleNecesidadPorProducto(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDESTABLECIMIENTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.COMPRASENTRANSITO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDNECESIDAD, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDUNIDADMEDIDA, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.CONSUMOANUAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.DEMANDAINSATISFECHA, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.RESERVAESTABLECIMIENTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.RESERVATOTAL, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.EXISTENCIAESTIMADA, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRECIOUNITARIO, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADREAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADAJUSTADA, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.NECESIDADFINAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOREAL, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOAJUSTADO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.PRESUPUESTOFINAL, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.COSTOTOTALREAL, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.COSTOTOTALAJUSTADO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.CORRPRODUCTO, vv_CATALOGOPRODUCTOS.DESCLARGO, SAB_CAT_UNIDADMEDIDAS.DESCRIPCION AS UNIDAD ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS ON SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO = vv_CATALOGOPRODUCTOS.IDPRODUCTO INNER JOIN ")
        strSQL.Append("SAB_CAT_UNIDADMEDIDAS ON SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDUNIDADMEDIDA = SAB_CAT_UNIDADMEDIDAS.IDUNIDADMEDIDA ")
        strSQL.Append("WHERE SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' obtener informacion de´productos de la necesidad filtrado por un tipo de criterio
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identificador de la necesidad
    ''' <param name="IDSUMINISTRO"></param> 'identificador del suministro
    ''' <param name="TIPOCRITERIO"></param> 'identificador del tipo de criterio del filtro
    ''' <param name="CADENABUSQUEDA"></param> 'cadena a buscar
    ''' <returns>
    ''' Dataset con la informacion filtrada
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDsDetalleNecesidadPorIdFiltrado(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSUMINISTRO As Int32, ByVal TIPOCRITERIO As Int16, ByVal CADENABUSQUEDA As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("dne.IDESTABLECIMIENTO, ")
        strSQL.Append("dne.COMPRASENTRANSITO, ")
        strSQL.Append("dne.IDNECESIDAD, ")
        strSQL.Append("dne.IDPRODUCTO, ")
        strSQL.Append("dne.IDUNIDADMEDIDA, ")
        strSQL.Append("dne.CONSUMOANUAL, ")
        strSQL.Append("dne.DEMANDAINSATISFECHA, ")
        strSQL.Append("dne.RESERVAESTABLECIMIENTO, ")
        strSQL.Append("dne.EXISTENCIAESTIMADA, ")
        strSQL.Append("dne.PRECIOUNITARIO, ")
        strSQL.Append("dne.NECESIDADREAL, ")
        strSQL.Append("dne.NECESIDADAJUSTADA, ")
        strSQL.Append("dne.NECESIDADFINAL, ")
        strSQL.Append("(dne.CONSUMOANUAL + dne.DEMANDAINSATISFECHA + dne.RESERVAESTABLECIMIENTO) AS TOTAL, ")
        strSQL.Append("dne.PRESUPUESTOREAL, ")
        strSQL.Append("dne.PRESUPUESTOAJUSTADO, ")
        strSQL.Append("dne.PRESUPUESTOFINAL, ")
        strSQL.Append("(dne.PRECIOUNITARIO * dne.NECESIDADREAL)AS PRESUPUESTOARTICULO, ")
        strSQL.Append("(DNE.PRECIOUNITARIO * dne.NECESIDADAJUSTADA)AS PRESUPUESTOARTICULOAJUSTADO, ")
        strSQL.Append("(dne.PRECIOUNITARIO * dne.NECESIDADFINAL)AS PRESUPUESTOARTICULOFINAL, ")
        strSQL.Append("dne.COSTOTOTALREAL, ")
        strSQL.Append("dne.COSTOTOTALAJUSTADO, ")
        strSQL.Append("cp.CORRPRODUCTO, ")
        strSQL.Append("cp.DESCPRODUCTO, ")
        strSQL.Append("cp.DESCLARGO, ")
        strSQL.Append("cp.IDSUMINISTRO, ")
        strSQL.Append("cp.IDGRUPO, ")
        strSQL.Append("cp.IDSUBGRUPO, ")
        strSQL.Append("cp.DESCRIPCION AS UNIDAD ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS dne ")
        strSQL.Append("LEFT OUTER JOIN vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("ON dne.IDPRODUCTO = cp.IDPRODUCTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(dne.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (dne.IDNECESIDAD = @IDNECESIDAD) AND (cp.IDSUMINISTRO = @IDSUMINISTRO) ")

        Select Case TIPOCRITERIO
            Case Is = 1
                strSQL.Append("AND (CP.IDGRUPO = @CADENABUSQUEDA) ")
            Case Is = 2
                strSQL.Append("AND (CP.IDSUBGRUPO = @CADENABUSQUEDA) ")
            Case Is = 3
                strSQL.Append("AND (CP.CORRPRODUCTO = @CADENABUSQUEDA) ")
        End Select
        strSQL.Append(" ORDER BY CP.CORRPRODUCTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.BigInt)
        args(2).Value = IDSUMINISTRO
        args(3) = New SqlParameter("@CADENABUSQUEDA", SqlDbType.VarChar)
        args(3).Value = CADENABUSQUEDA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDsDetalleNecesidadPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSUMINISTRO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("dne.IDESTABLECIMIENTO, ")
        strSQL.Append("dne.COMPRASENTRANSITO, ")
        strSQL.Append("dne.IDNECESIDAD, ")
        strSQL.Append("dne.IDPRODUCTO, ")
        strSQL.Append("dne.IDUNIDADMEDIDA, ")
        strSQL.Append("dne.CONSUMOANUAL, ")
        strSQL.Append("dne.DEMANDAINSATISFECHA, ")
        strSQL.Append("dne.RESERVAESTABLECIMIENTO, ")
        strSQL.Append("dne.EXISTENCIAESTIMADA, ")
        strSQL.Append("dne.PRECIOUNITARIO, ")
        strSQL.Append("dne.NECESIDADREAL, ")
        strSQL.Append("dne.NECESIDADAJUSTADA, ")
        strSQL.Append("dne.NECESIDADFINAL, ")
        strSQL.Append("(dne.CONSUMOANUAL + dne.DEMANDAINSATISFECHA + dne.RESERVAESTABLECIMIENTO) AS TOTAL, ")
        strSQL.Append("dne.PRESUPUESTOREAL, ")
        strSQL.Append("dne.PRESUPUESTOAJUSTADO, ")
        strSQL.Append("dne.PRESUPUESTOFINAL, ")
        strSQL.Append("(dne.PRECIOUNITARIO * dne.NECESIDADREAL)AS PRESUPUESTOARTICULO, ")
        strSQL.Append("(DNE.PRECIOUNITARIO * dne.NECESIDADAJUSTADA)AS PRESUPUESTOARTICULOAJUSTADO, ")
        strSQL.Append("(dne.PRECIOUNITARIO * dne.NECESIDADFINAL)AS PRESUPUESTOARTICULOFINAL, ")
        strSQL.Append("dne.COSTOTOTALREAL, ")
        strSQL.Append("dne.COSTOTOTALAJUSTADO, ")
        strSQL.Append("cp.CORRPRODUCTO, ")
        strSQL.Append("cp.DESCPRODUCTO, ")
        strSQL.Append("cp.DESCLARGO, ")
        strSQL.Append("cp.IDSUMINISTRO, ")
        strSQL.Append("cp.IDGRUPO, ")
        strSQL.Append("cp.IDSUBGRUPO, ")
        strSQL.Append("cp.DESCRIPCION AS UNIDAD ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS dne ")
        strSQL.Append("LEFT OUTER JOIN vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("ON dne.IDPRODUCTO = cp.IDPRODUCTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("(dne.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (dne.IDNECESIDAD = @IDNECESIDAD) AND (cp.IDSUMINISTRO = @IDSUMINISTRO)")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.BigInt)
        args(2).Value = IDSUMINISTRO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' eliminar los productos de una necesidad
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipoDETALLENECESIDADESESTABLECIMIENTOS
    ''' <returns>
    ''' Devuelve uno si se completo con la operacion
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function EliminarDetalleNecesidad(ByVal aEntidad As DETALLENECESIDADESTABLECIMIENTOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDNECESIDAD

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Rucupera el detalle de la estimación de necesidades.
    ''' </summary>
    ''' <param name="IDANIO">Período al cual sera aplicado esta función.</param>
    ''' <param name="IDPROPUESTA">Identificador de la propuesta seleccionada.</param>
    ''' <returns>Dataset con el detalle de la estimación de necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  26/10/2006    Creado
    ''' </history> 
    Public Function ObtenerDsDetalleNecesidadPorPropuesta(ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("NE.PROPUESTA, ")
        strSQL.Append("NE.ANIOFINPERIODO, ")
        strSQL.Append("DNE.IDPRODUCTO, ")
        strSQL.Append("DNE.IDUNIDADMEDIDA, ")
        strSQL.Append("DNE.PRECIOUNITARIO, ")
        strSQL.Append("SUM(DNE.NECESIDADFINAL) AS NECESIDADFINAL, ")
        strSQL.Append("SUM(DNE.CONSUMOANUAL) AS CONSUMOANUAL, ")
        strSQL.Append("SUM(DNE.DEMANDAINSATISFECHA) AS DEMANDAINSATISFECHA, ")
        strSQL.Append("SUM(DNE.RESERVAESTABLECIMIENTO) AS RESERVAESTABLECIMIENTO, ")
        strSQL.Append("SUM(DNE.RESERVATOTAL) AS RESERVATOTAL, ")
        strSQL.Append("SUM(DNE.EXISTENCIAESTIMADA) AS EXISTENCIAESTIMADA, ")
        strSQL.Append("SUM(DNE.NECESIDADREAL) AS NECESIDADREAL, ")
        strSQL.Append("SUM(DNE.NECESIDADAJUSTADA) AS NECESIDADAJUSTADA, ")
        strSQL.Append("(DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADREAL))AS PRESUPUESTOARTICULO, ")
        strSQL.Append("(DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADAJUSTADA))AS PRESUPUESTOARTICULOAJUSTADO, ")
        strSQL.Append("(DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADFINAL))AS PRESUPUESTOARTICULOFINAL, ")
        strSQL.Append("(SUM(DNE.CONSUMOANUAL) + SUM(DNE.DEMANDAINSATISFECHA) + SUM(DNE.RESERVAESTABLECIMIENTO)) AS TOTAL, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("CP.PRECIOACTUAL ")
        strSQL.Append("FROM SAB_EST_NECESIDADESTABLECIMIENTOS NE ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLENECESIDADESTABLECIMIENTOS DNE ")
        strSQL.Append("ON NE.IDNECESIDAD = DNE.IDNECESIDAD AND NE.IDESTABLECIMIENTO = DNE.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DNE.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append("(NE.PROPUESTA = @IDPROPUESTA) AND (NE.ANIOFINPERIODO = @IDANIO) AND (NE.IDESTADO = 2)")
        strSQL.Append(" GROUP BY NE.PROPUESTA, NE.ANIOFINPERIODO, DNE.IDPRODUCTO, DNE.IDUNIDADMEDIDA, DNE.PRECIOUNITARIO, ")
        strSQL.Append(" CP.CORRPRODUCTO, CP.DESCPRODUCTO, CP.DESCLARGO, CP.IDNIVELUSO, CP.IDGRUPO, CP.DESCGRUPO, CP.IDSUBGRUPO, ")
        strSQL.Append(" CP.DESCSUBGRUPO, CP.PRECIOACTUAL ORDER BY CP.CORRPRODUCTO")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDANIO", SqlDbType.Int)
        args(0).Value = IDANIO
        args(1) = New SqlParameter("@IDPROPUESTA", SqlDbType.BigInt)
        args(1).Value = IDPROPUESTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Rucupera el detalle de la estimación de necesidades.
    ''' </summary>
    ''' <param name="IDANIO">Período al cual sera aplicado esta función.</param>
    ''' <param name="IDPROPUESTA">Identificador de la propuesta seleccionada.</param>
    ''' <returns>Dataset con el detalle de la estimación de necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  26/10/2006    Creado
    ''' </history> 
    Public Function ObtenerDsDetalleNecesidadPorPropuestaFiltrada(ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int32, ByVal TIPOCRITERIO As Int16, ByVal CADENABUSQUEDA As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("NE.PROPUESTA, ")
        strSQL.Append("NE.ANIOFINPERIODO, ")
        strSQL.Append("DNE.IDPRODUCTO, ")
        strSQL.Append("DNE.IDUNIDADMEDIDA, ")
        strSQL.Append("DNE.PRECIOUNITARIO, ")
        strSQL.Append("SUM(DNE.NECESIDADFINAL) AS NECESIDADFINAL, ")
        strSQL.Append("SUM(DNE.CONSUMOANUAL) AS CONSUMOANUAL, ")
        strSQL.Append("SUM(DNE.DEMANDAINSATISFECHA) AS DEMANDAINSATISFECHA, ")
        strSQL.Append("SUM(DNE.RESERVAESTABLECIMIENTO) AS RESERVAESTABLECIMIENTO, ")
        strSQL.Append("SUM(DNE.RESERVATOTAL) AS RESERVATOTAL, ")
        strSQL.Append("SUM(DNE.EXISTENCIAESTIMADA) AS EXISTENCIAESTIMADA, ")
        strSQL.Append("SUM(DNE.NECESIDADREAL) AS NECESIDADREAL, ")
        strSQL.Append("SUM(DNE.NECESIDADAJUSTADA) AS NECESIDADAJUSTADA, ")
        strSQL.Append("(DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADREAL))AS PRESUPUESTOARTICULO, ")
        strSQL.Append("(DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADAJUSTADA))AS PRESUPUESTOARTICULOAJUSTADO, ")
        strSQL.Append("(DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADFINAL))AS PRESUPUESTOARTICULOFINAL, ")
        strSQL.Append("(SUM(DNE.CONSUMOANUAL) + SUM(DNE.DEMANDAINSATISFECHA) + SUM(DNE.RESERVAESTABLECIMIENTO)) AS TOTAL, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("CP.PRECIOACTUAL ")
        strSQL.Append("FROM SAB_EST_NECESIDADESTABLECIMIENTOS NE ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLENECESIDADESTABLECIMIENTOS DNE ")
        strSQL.Append("ON NE.IDNECESIDAD = DNE.IDNECESIDAD AND NE.IDESTABLECIMIENTO = DNE.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DNE.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE ")
        strSQL.Append("(NE.PROPUESTA = @IDPROPUESTA) AND (NE.ANIOFINPERIODO = @IDANIO) AND (NE.IDESTADO = 2)")
        strSQL.Append(" GROUP BY NE.PROPUESTA, NE.ANIOFINPERIODO, DNE.IDPRODUCTO, DNE.IDUNIDADMEDIDA, DNE.PRECIOUNITARIO, ")
        strSQL.Append(" CP.CORRPRODUCTO, CP.DESCPRODUCTO, CP.DESCLARGO, CP.IDNIVELUSO, CP.IDGRUPO, CP.DESCGRUPO, CP.IDSUBGRUPO, ")
        strSQL.Append(" CP.DESCSUBGRUPO, CP.PRECIOACTUAL ")
        strSQL.Append("HAVING ")

        Select Case TIPOCRITERIO
            Case Is = 1
                strSQL.Append(" (CP.IDGRUPO = @CADENABUSQUEDA) ")
            Case Is = 2
                strSQL.Append(" (CP.IDSUBGRUPO = @CADENABUSQUEDA) ")
            Case Is = 3
                strSQL.Append(" (CP.CORRPRODUCTO = @CADENABUSQUEDA) ")
            Case Is = 4
                strSQL.Append(" (CP.IDSUMINISTRO = @CADENABUSQUEDA) ")
        End Select
        strSQL.Append(" ORDER BY CP.CORRPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDANIO", SqlDbType.Int)
        args(0).Value = IDANIO
        args(1) = New SqlParameter("@IDPROPUESTA", SqlDbType.BigInt)
        args(1).Value = IDPROPUESTA
        args(2) = New SqlParameter("@CADENABUSQUEDA", SqlDbType.VarChar)
        args(2).Value = CADENABUSQUEDA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ' Autor: José Chávez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Se utiliza para recuperar del detalle de la estimacion de necesidades y devolver en un dataset
    '           filtrado por año, propuesta y producto
    ' Creación: 24/11/06 
    '-------------------------------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Rucupera el detalle de la estimación de necesidades para un producto especifico.
    ''' </summary>
    ''' <param name="IDANIO">Período al cual sera aplicado esta función.</param>
    ''' <param name="IDPROPUESTA">Identificador de la propuesta seleccionada.</param>
    ''' <param name="IDPRODUCTO">Identificador del producto a recuperar la información.</param>
    ''' <returns>Dataset con el detalle de la estimación de necesidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  26/10/2006    Creado
    ''' </history>
    Public Function ObtenerDsDetalleNecesidadPorPropuestaPorProducto(ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int32, ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT NE.PROPUESTA, NE.ANIOFINPERIODO, ")
        strSQL.Append(" DNE.IDPRODUCTO, DNE.IDUNIDADMEDIDA, ")
        strSQL.Append(" DNE.PRECIOUNITARIO, SUM(DNE.NECESIDADFINAL) AS NECESIDADFINAL, SUM(DNE.CONSUMOANUAL) AS CONSUMOANUAL, SUM(DNE.DEMANDAINSATISFECHA) AS DEMANDAINSATISFECHA, ")
        strSQL.Append(" SUM(DNE.RESERVAESTABLECIMIENTO) AS RESERVAESTABLECIMIENTO, SUM(DNE.RESERVATOTAL) AS RESERVATOTAL, SUM(DNE.EXISTENCIAESTIMADA) AS EXISTENCIAESTIMADA, ")
        strSQL.Append(" SUM(DNE.NECESIDADREAL) AS NECESIDADREAL, SUM(DNE.NECESIDADAJUSTADA) AS NECESIDADAJUSTADA, ")
        strSQL.Append(" (DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADREAL))AS PRESUPUESTOARTICULO, (DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADAJUSTADA))AS PRESUPUESTOARTICULOAJUSTADO, ")
        strSQL.Append(" (DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADFINAL))AS PRESUPUESTOARTICULOFINAL, (SUM(DNE.CONSUMOANUAL) + SUM(DNE.DEMANDAINSATISFECHA) + SUM(DNE.RESERVAESTABLECIMIENTO)) AS TOTAL, ")
        strSQL.Append(" CP.CORRPRODUCTO, CP.DESCPRODUCTO, CP.DESCLARGO, ")
        strSQL.Append(" CP.IDNIVELUSO, CP.IDGRUPO, CP.DESCGRUPO, ")
        strSQL.Append(" CP.IDSUBGRUPO, CP.DESCSUBGRUPO, CP.PRECIOACTUAL ")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS AS NE INNER JOIN ")
        strSQL.Append(" SAB_EST_DETALLENECESIDADESTABLECIMIENTOS AS DNE ON NE.IDNECESIDAD = DNE.IDNECESIDAD AND NE.IDESTABLECIMIENTO = DNE.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS AS CP ON DNE.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append(" WHERE (NE.PROPUESTA = @IDPROPUESTA) AND (NE.ANIOFINPERIODO = @IDANIO) AND (DNE.IDPRODUCTO = @IDPRODUCTO)")
        strSQL.Append(" GROUP BY NE.PROPUESTA, NE.ANIOFINPERIODO, DNE.IDPRODUCTO, DNE.IDUNIDADMEDIDA, DNE.PRECIOUNITARIO, ")
        strSQL.Append(" CP.CORRPRODUCTO, CP.DESCPRODUCTO, CP.DESCLARGO, CP.IDNIVELUSO, CP.IDGRUPO, CP.DESCGRUPO, CP.IDSUBGRUPO, ")
        strSQL.Append(" CP.DESCSUBGRUPO, CP.PRECIOACTUAL ORDER BY CP.CORRPRODUCTO")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDANIO", SqlDbType.Int)
        args(0).Value = IDANIO
        args(1) = New SqlParameter("@IDPROPUESTA", SqlDbType.BigInt)
        args(1).Value = IDPROPUESTA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Calcular el monto de la necesidad real
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLENECESIDADESETABLECIMIENTOS
    ''' <returns>
    ''' El monto real de la necesidad
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CalularMontoRealNecesidad(ByVal aEntidad As DETALLENECESIDADESTABLECIMIENTOS) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(sum(PRECIOUNITARIO * NECESIDADREAL), 0) ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ")
        strSQL.Append("WHERE IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDNECESIDAD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' calcular el monto de la necesidad ajustada
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLENECESIDADESTABLECIMIENTOS
    ''' <returns>
    ''' Monto de la necesidad ajustada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CalularMontoAjustadoNecesidad(ByVal aEntidad As DETALLENECESIDADESTABLECIMIENTOS) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(sum(PRECIOUNITARIO * NECESIDADAJUSTADA), 0) ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ")
        strSQL.Append("WHERE IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDNECESIDAD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' calcula el monto de la necesidad final
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLENECESIDADESESTABLECIMIENTOS
    ''' <returns>
    ''' Monto de la necesidad final
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function CalularMontoFinalNecesidad(ByVal aEntidad As DETALLENECESIDADESTABLECIMIENTOS) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select isnull(sum(PRECIOUNITARIO * NECESIDADFINAL), 0) ")
        strSQL.Append("from SAB_EST_detallenecesidadestablecimientos ")
        strSQL.Append("WHERE IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDNECESIDAD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' obtiene un listado de los detalle de productos de una necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identidiacdor de necesidad
    ''' <returns>
    ''' lista filtrada por necesidad
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>

    Public Function ObtenerListaPorNececidad(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As listaDETALLENECESIDADESTABLECIMIENTOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLENECESIDADESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLENECESIDADESTABLECIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDNECESIDAD = IDNECESIDAD
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.CONSUMOANUAL = IIf(dr("CONSUMOANUAL") Is DBNull.Value, Nothing, dr("CONSUMOANUAL"))
                mEntidad.DEMANDAINSATISFECHA = IIf(dr("DEMANDAINSATISFECHA") Is DBNull.Value, Nothing, dr("DEMANDAINSATISFECHA"))
                mEntidad.RESERVAESTABLECIMIENTO = IIf(dr("RESERVAESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("RESERVAESTABLECIMIENTO"))
                mEntidad.RESERVATOTAL = IIf(dr("RESERVATOTAL") Is DBNull.Value, Nothing, dr("RESERVATOTAL"))
                mEntidad.EXISTENCIAESTIMADA = IIf(dr("EXISTENCIAESTIMADA") Is DBNull.Value, Nothing, dr("EXISTENCIAESTIMADA"))
                mEntidad.PRECIOUNITARIO = IIf(dr("PRECIOUNITARIO") Is DBNull.Value, Nothing, dr("PRECIOUNITARIO"))
                mEntidad.NECESIDADREAL = IIf(dr("NECESIDADREAL") Is DBNull.Value, Nothing, dr("NECESIDADREAL"))
                mEntidad.NECESIDADAJUSTADA = IIf(dr("NECESIDADAJUSTADA") Is DBNull.Value, Nothing, dr("NECESIDADAJUSTADA"))
                mEntidad.NECESIDADFINAL = IIf(dr("NECESIDADFINAL") Is DBNull.Value, Nothing, dr("NECESIDADFINAL"))
                mEntidad.PRESUPUESTOREAL = IIf(dr("PRESUPUESTOREAL") Is DBNull.Value, Nothing, dr("PRESUPUESTOREAL"))
                mEntidad.PRESUPUESTOAJUSTADO = IIf(dr("PRESUPUESTOAJUSTADO") Is DBNull.Value, Nothing, dr("PRESUPUESTOAJUSTADO"))
                mEntidad.PRESUPUESTOFINAL = IIf(dr("PRESUPUESTOFINAL") Is DBNull.Value, Nothing, dr("PRESUPUESTOFINAL"))
                mEntidad.COSTOTOTALREAL = IIf(dr("COSTOTOTALREAL") Is DBNull.Value, Nothing, dr("COSTOTOTALREAL"))
                mEntidad.COSTOTOTALAJUSTADO = IIf(dr("COSTOTOTALAJUSTADO") Is DBNull.Value, Nothing, dr("COSTOTOTALAJUSTADO"))
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
    ''' obtiene la informacion del detalle de la necesidad para un codigo MSPAS de producto
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> 'identificador de la necesidad
    ''' <param name="IDCODIGOPRODUCTO"></param> 'codigo de producto utilizado por MSPAS
    ''' <returns>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetPorCodigo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDCODIGOPRODUCTO As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDESTABLECIMIENTO, SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDNECESIDAD, ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO, vv_CATALOGOPRODUCTOS.IDSUMINISTRO, vv_CATALOGOPRODUCTOS.CORRSUMINISTRO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.DESCSUMINISTRO, vv_CATALOGOPRODUCTOS.IDGRUPO, vv_CATALOGOPRODUCTOS.CORRGRUPO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.DESCGRUPO, vv_CATALOGOPRODUCTOS.IDSUBGRUPO, vv_CATALOGOPRODUCTOS.CORRSUBGRUPO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.DESCSUBGRUPO, vv_CATALOGOPRODUCTOS.IDPRODUCTO AS Expr1, vv_CATALOGOPRODUCTOS.CORRPRODUCTO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.DESCPRODUCTO, vv_CATALOGOPRODUCTOS.DESCLARGO, vv_CATALOGOPRODUCTOS.IDNIVELUSO, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.NOMBRECORTO, vv_CATALOGOPRODUCTOS.PRECIOACTUAL, vv_CATALOGOPRODUCTOS.EXISTENCIAACTUAL, ")
        strSQL.Append("vv_CATALOGOPRODUCTOS.DESCRIPCION ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS INNER JOIN ")
        strSQL.Append("SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ON vv_CATALOGOPRODUCTOS.IDPRODUCTO = SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDPRODUCTO ")
        strSQL.Append(" WHERE SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND SAB_EST_DETALLENECESIDADESTABLECIMIENTOS.IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND vv_CATALOGOPRODUCTOS.CORRPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.VarChar)
        args(2).Value = IDCODIGOPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ' Autor: José Chávez y Henry Zavaleta
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Se utiliza para recuperar del detalle de la estimacion de necesidades y devolver en un dataset
    ' Creación: 20/12/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerDsDetalleNecesidadPorGrupo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSUMINISTRO As Int32, ByVal idgRupo As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT dne.IDESTABLECIMIENTO, dne.IDNECESIDAD, dne.IDPRODUCTO, dne.IDUNIDADMEDIDA, dne.CONSUMOANUAL, ")
        strSQL.Append(" dne.DEMANDAINSATISFECHA, dne.RESERVAESTABLECIMIENTO, dne.EXISTENCIAESTIMADA, ")
        strSQL.Append(" dne.PRECIOUNITARIO, dne.NECESIDADREAL, dne.NECESIDADAJUSTADA, dne.NECESIDADFINAL, (dne.CONSUMOANUAL + dne.DEMANDAINSATISFECHA + dne.RESERVAESTABLECIMIENTO) AS TOTAL, dne.PRESUPUESTOREAL, ")
        strSQL.Append(" dne.PRESUPUESTOAJUSTADO, dne.PRESUPUESTOFINAL, (dne.PRECIOUNITARIO * dne.NECESIDADREAL)AS PRESUPUESTOARTICULO, (DNE.PRECIOUNITARIO * dne.NECESIDADAJUSTADA)AS PRESUPUESTOARTICULOAJUSTADO, ")
        strSQL.Append(" (dne.PRECIOUNITARIO * dne.NECESIDADFINAL)AS PRESUPUESTOARTICULOFINAL, dne.COSTOTOTALREAL, dne.COSTOTOTALAJUSTADO, ")
        strSQL.Append(" cp.CORRPRODUCTO, cp.DESCPRODUCTO, cp.DESCLARGO, cp.IDSUMINISTRO, cp.IDGRUPO, cp.IDSUBGRUPO, cp.DESCRIPCION AS UNIDAD FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS as dne ")
        strSQL.Append(" LEFT OUTER JOIN vv_CATALOGOPRODUCTOS as cp ON dne.IDPRODUCTO = cp.IDPRODUCTO WHERE ")
        strSQL.Append(" (dne.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (dne.IDNECESIDAD = @IDNECESIDAD) AND (cp.IDSUMINISTRO = @IDSUMINISTRO) AND (cp.IDGRUPO = @IDGRUPO)")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.BigInt)
        args(2).Value = IDSUMINISTRO
        args(3) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(3).Value = idgRupo

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ' Autor: José Chávez y Henry Zavaleta
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Se utiliza para recuperar del detalle de la estimacion de necesidades y devolver en un dataset
    ' Creación: 20/12/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerDsDetalleNecesidadPorSubgrupo(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSUMINISTRO As Int32, ByVal idSubGrupo As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT dne.IDESTABLECIMIENTO, dne.IDNECESIDAD, dne.IDPRODUCTO, dne.IDUNIDADMEDIDA, dne.CONSUMOANUAL, ")
        strSQL.Append(" dne.DEMANDAINSATISFECHA, dne.RESERVAESTABLECIMIENTO, dne.EXISTENCIAESTIMADA, ")
        strSQL.Append(" dne.PRECIOUNITARIO, dne.NECESIDADREAL, dne.NECESIDADAJUSTADA, dne.NECESIDADFINAL, (dne.CONSUMOANUAL + dne.DEMANDAINSATISFECHA + dne.RESERVAESTABLECIMIENTO) AS TOTAL, dne.PRESUPUESTOREAL, ")
        strSQL.Append(" dne.PRESUPUESTOAJUSTADO, dne.PRESUPUESTOFINAL, (dne.PRECIOUNITARIO * dne.NECESIDADREAL)AS PRESUPUESTOARTICULO, (DNE.PRECIOUNITARIO * dne.NECESIDADAJUSTADA)AS PRESUPUESTOARTICULOAJUSTADO, ")
        strSQL.Append(" (dne.PRECIOUNITARIO * dne.NECESIDADFINAL)AS PRESUPUESTOARTICULOFINAL, dne.COSTOTOTALREAL, dne.COSTOTOTALAJUSTADO, ")
        strSQL.Append(" cp.CORRPRODUCTO, cp.DESCPRODUCTO, cp.DESCLARGO, cp.IDSUMINISTRO, cp.IDGRUPO, cp.IDSUBGRUPO, cp.DESCRIPCION AS UNIDAD FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS as dne ")
        strSQL.Append(" LEFT OUTER JOIN vv_CATALOGOPRODUCTOS as cp ON dne.IDPRODUCTO = cp.IDPRODUCTO WHERE ")
        strSQL.Append(" (dne.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (dne.IDNECESIDAD = @IDNECESIDAD) AND (cp.IDSUMINISTRO = @IDSUMINISTRO) AND (cp.IDSUBGRUPO = @IDSUBGRUPO)")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.BigInt)
        args(2).Value = IDSUMINISTRO
        args(3) = New SqlParameter("@IDSUBGRUPO", SqlDbType.Int)
        args(3).Value = idSubGrupo

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' valida existencia de productos asociados a la necesidad
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo DETALLENECESIDADESESTABLECIMIENTO
    ''' <returns>
    ''' Verdadero si hay productos asociados a la necesidad
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarHayProductoAsociadoNececidad(ByVal aEntidad As DETALLENECESIDADESTABLECIMIENTOS) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_EST_DETALLENECESIDADESTABLECIMIENTOS ")
        strSQL.Append("WHERE IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(0).Value = aEntidad.IDNECESIDAD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

#End Region

#Region "Funciones Consolidado Con Programas"
    ''' <summary>
    ''' Rucupera el detalle de la estimación de necesidades para un programa especifico.
    ''' </summary>
    ''' <param name="IDANIO">Período al cual sera aplicado esta función.</param>
    ''' <param name="IDPROPUESTA">Identificador de la propuesta seleccionada.</param>
    ''' <param name="IDPROGRAMA">Identificador del programa seleccionado.</param>
    ''' <returns>Dataset con el detalle de la estimación de necesidades asociados a un programa.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_NECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_EST_DETALLENECESIDADESTABLECIMIENTOS</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_PRODUCTOSPROGRAMAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  10/01/2007    Creado
    ''' </history> 
    Public Function ObtenerDsDetalleNecesidadPorPropuestaConProgramas(ByVal IDANIO As Int32, ByVal IDPROPUESTA As Int32, ByVal IDPROGRAMA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("NE.PROPUESTA, ")
        strSQL.Append("NE.ANIOFINPERIODO, ")
        strSQL.Append("DNE.IDPRODUCTO, ")
        strSQL.Append("DNE.IDUNIDADMEDIDA, ")
        strSQL.Append("DNE.PRECIOUNITARIO, ")
        strSQL.Append("SUM(DNE.NECESIDADFINAL) AS NECESIDADFINAL, ")
        strSQL.Append("SUM(DNE.CONSUMOANUAL) AS CONSUMOANUAL, ")
        strSQL.Append("SUM(DNE.DEMANDAINSATISFECHA) AS DEMANDAINSATISFECHA, ")
        strSQL.Append("SUM(DNE.RESERVAESTABLECIMIENTO) AS RESERVAESTABLECIMIENTO, ")
        strSQL.Append("SUM(DNE.RESERVATOTAL) AS RESERVATOTAL, ")
        strSQL.Append("SUM(DNE.EXISTENCIAESTIMADA) AS EXISTENCIAESTIMADA, ")
        strSQL.Append("SUM(DNE.NECESIDADREAL) AS NECESIDADREAL, ")
        strSQL.Append("SUM(DNE.NECESIDADAJUSTADA) AS NECESIDADAJUSTADA, ")
        strSQL.Append("DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADREAL) AS PRESUPUESTOARTICULO, ")
        strSQL.Append("DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADAJUSTADA) AS PRESUPUESTOARTICULOAJUSTADO, ")
        strSQL.Append("DNE.PRECIOUNITARIO * SUM(DNE.NECESIDADFINAL) AS PRESUPUESTOARTICULOFINAL, ")
        strSQL.Append("SUM(DNE.CONSUMOANUAL) + SUM(DNE.DEMANDAINSATISFECHA) + SUM(DNE.RESERVAESTABLECIMIENTO) AS TOTAL, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("CP.PRECIOACTUAL, ")
        strSQL.Append("PG.IDPROGRAMA ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_EST_NECESIDADESTABLECIMIENTOS NE ")
        strSQL.Append("INNER JOIN SAB_EST_DETALLENECESIDADESTABLECIMIENTOS DNE ")
        strSQL.Append("ON NE.IDNECESIDAD = DNE.IDNECESIDAD AND NE.IDESTABLECIMIENTO = DNE.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DNE.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PG ")
        strSQL.Append("ON DNE.IDPRODUCTO = PG.IDPRODUCTO ")
        strSQL.Append("WHERE (NE.PROPUESTA = @IDPROPUESTA) AND (NE.ANIOFINPERIODO = @IDANIO) AND (NE.IDESTADO = 2) AND (PG.IDPROGRAMA = @IDPROGRAMA) ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("NE.PROPUESTA, ")
        strSQL.Append("NE.ANIOFINPERIODO, ")
        strSQL.Append("DNE.IDPRODUCTO, ")
        strSQL.Append("DNE.IDUNIDADMEDIDA, ")
        strSQL.Append("DNE.PRECIOUNITARIO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDNIVELUSO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("CP.PRECIOACTUAL, ")
        strSQL.Append("PG.IDPROGRAMA ")
        strSQL.Append("ORDER BY CP.CORRPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDANIO", SqlDbType.Int)
        args(0).Value = IDANIO
        args(1) = New SqlParameter("@IDPROPUESTA", SqlDbType.BigInt)
        args(1).Value = IDPROPUESTA
        args(2) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(2).Value = IDPROGRAMA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
