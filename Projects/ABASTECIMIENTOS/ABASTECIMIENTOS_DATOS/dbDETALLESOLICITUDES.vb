Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLESOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla DETALLESOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLESOLICITUDES
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLESOLICITUDES
        lEntidad = aEntidad

        ' Dim lID As Long
        'If lEntidad.IDDETALLE = 0 _
        '    Or lEntidad.IDDETALLE = Nothing Then
        '    lID = Me.ObtenerID(lEntidad)
        '    If lID = -1 Then Return -1
        '    lEntidad.IDDETALLE = lID
        '    Return Agregar(lEntidad)
        'End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_EST_DETALLESOLICITUDES ")
        strSQL.Append(" SET RENGLON = @RENGLON, ")
        strSQL.Append(" IDPRODUCTO = @IDPRODUCTO, ")
        strSQL.Append(" CANTIDAD = @CANTIDAD, ")
        strSQL.Append(" IDUNIDADMEDIDA = @IDUNIDADMEDIDA, ")
        strSQL.Append(" PRESUPUESTOUNITARIO = @PRESUPUESTOUNITARIO, ")
        strSQL.Append(" PRESUPUESTOTOTAL = @PRESUPUESTOTOTAL, ")
        strSQL.Append(" NUMEROENTREGAS = @NUMEROENTREGAS, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        If lEntidad.IDESPECIFICACION <> 0 Then
            strSQL.Append(" , IDESPECIFICACION = @IDESPECIFICACION ")
        End If

        strSQL.Append(" WHERE RENGLON = @RENGLON ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(14) As SqlParameter
        args(0) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(0).Value = lEntidad.RENGLON
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@CANTIDAD", SqlDbType.BigInt)
        args(2).Value = lEntidad.CANTIDAD
        args(3) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(3).Value = IIf(lEntidad.IDUNIDADMEDIDA = Nothing, 0, lEntidad.IDUNIDADMEDIDA)
        args(4) = New SqlParameter("@PRESUPUESTOUNITARIO", SqlDbType.Decimal)
        args(4).Value = lEntidad.PRESUPUESTOUNITARIO
        args(5) = New SqlParameter("@PRESUPUESTOTOTAL", SqlDbType.Decimal)
        args(5).Value = lEntidad.PRESUPUESTOTOTAL
        args(6) = New SqlParameter("@NUMEROENTREGAS", SqlDbType.TinyInt)
        args(6).Value = lEntidad.NUMEROENTREGAS
        args(7) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(8) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(9) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(10) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(11) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(11).Value = lEntidad.ESTASINCRONIZADA
        args(12) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(12).Value = lEntidad.IDESTABLECIMIENTO
        args(13) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(13).Value = lEntidad.IDSOLICITUD
        If lEntidad.IDESPECIFICACION <> 0 Then
            args(14) = New SqlParameter("@IDESPECIFICACION", SqlDbType.BigInt)
            args(14).Value = lEntidad.IDESPECIFICACION
        End If


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLESOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_DETALLESOLICITUDES ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDESPECIFICACION, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" PRESUPUESTOUNITARIO, ")
        strSQL.Append(" PRESUPUESTOTOTAL, ")
        strSQL.Append(" NUMEROENTREGAS, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDSOLICITUD, ")
        strSQL.Append(" @IDESPECIFICACION, ")
        strSQL.Append(" @RENGLON, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @CANTIDAD, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @PRESUPUESTOUNITARIO, ")
        strSQL.Append(" @PRESUPUESTOTOTAL, ")
        strSQL.Append(" @NUMEROENTREGAS, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        If lEntidad.RENGLON = 0 Then
            Dim ds As System.Data.DataSet
            ds = ObtenerRenglonPorSolicitud(lEntidad.IDESTABLECIMIENTO, lEntidad.IDSOLICITUD)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim ds1 As System.Data.DataSet
                ds1 = ObtenerRenglon(lEntidad.IDESTABLECIMIENTO, lEntidad.IDSOLICITUD)
                lEntidad.RENGLON = ds1.Tables(0).Rows(0).Item(0)
            Else
                lEntidad.RENGLON = 1
            End If
        End If

        Dim args(14) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDDETALLE
        args(3) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(3).Value = lEntidad.RENGLON
        args(4) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDPRODUCTO
        args(5) = New SqlParameter("@CANTIDAD", SqlDbType.BigInt)
        args(5).Value = lEntidad.CANTIDAD
        args(6) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(6).Value = IIf(lEntidad.IDUNIDADMEDIDA = Nothing, DBNull.Value, lEntidad.IDUNIDADMEDIDA)
        args(7) = New SqlParameter("@PRESUPUESTOUNITARIO", SqlDbType.Decimal)
        args(7).Value = lEntidad.PRESUPUESTOUNITARIO
        args(8) = New SqlParameter("@PRESUPUESTOTOTAL", SqlDbType.Decimal)
        args(8).Value = lEntidad.PRESUPUESTOTOTAL
        args(9) = New SqlParameter("@NUMEROENTREGAS", SqlDbType.TinyInt)
        args(9).Value = lEntidad.NUMEROENTREGAS
        args(10) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(11) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(12) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(13) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(14) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(14).Value = lEntidad.ESTASINCRONIZADA
        args(15) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        args(15).Value = lEntidad.IDESPECIFICACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLESOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_DETALLESOLICITUDES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND isnull(IDESPECIFICACION,0) = @IDESPECIFICACION ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO

        args(3) = New SqlParameter("@IDESPECIFICACION", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDESPECIFICACION


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarEspecificacionessolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal idproducto As Int64, ByVal IDESPECIFICACION As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_ESPECIFICACIONESSOLICITUDES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDESPECIFICACION = @IDESPECIFICACION; ")
        strSQL.Append(" UPDATE  SAB_EST_PRODUCTOSSOLICITUD SET IDESPECIFICACION = NULL ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO= @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD= @IDSOLICITUD ")
        strSQL.Append(" AND IDPRODUCTO= @IDPRODUCTO ")
        strSQL.Append(" AND IDESPECIFICACION = @IDESPECIFICACION; ")


        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = idproducto
        args(3) = New SqlParameter("@IDESPECIFICACION", SqlDbType.BigInt)
        args(3).Value = IDESPECIFICACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ActualizaIDEspecificacionProductosSolicitud(ByVal idsolicitud As Int64, ByVal idestablecimiento As Integer, ByVal idproducto As Int64, ByVal renglon As Integer, ByVal idespecificacion As Int64)
        Dim strSQL As New StringBuilder
        strSQL.Append(" UPDATE  SAB_EST_PRODUCTOSSOLICITUD SET IDESPECIFICACION = @IDESPECIFICACION ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO= @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD= @IDSOLICITUD ")
        strSQL.Append(" AND IDPRODUCTO= @IDPRODUCTO ")
        strSQL.Append(" AND renglon = @renglon; ")


        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = idsolicitud
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = idproducto
        args(3) = New SqlParameter("@renglon", SqlDbType.Int)
        args(3).Value = renglon
        args(4) = New SqlParameter("@IDESPECIFICACION", SqlDbType.BigInt)
        args(4).Value = idespecificacion

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function AsignarRenglon(ByVal idSolicitud As Int64, ByVal IDEstablecimiento As Int64) As Integer

        Dim strSQL As New StringBuilder

        ' strSQL.Append(" UPDATE SAB_EST_DETALLESOLICITUDES SET SAB_EST_DETALLESOLICITUDES.RENGLON = SubQuery.Rank ")
        '        strSQL.Append(" FROM (Select ROW_NUMBER() OVER ( ORDER BY VC.CORRPRODUCTO) AS Rank,DS.IDPRODUCTO, DS.CANTIDAD, ")

        strSQL.Append(" UPDATE SAB_EST_DETALLESOLICITUDES  ")
        strSQL.Append(" FROM ds.renglon, DS.IDPRODUCTO, DS.CANTIDAD, ")
        strSQL.Append(" VC.CORRPRODUCTO AS CODIGO, DS.RENGLON , DS.IDSOLICITUD AS SOLICITUD, S.IDESTABLECIMIENTO AS ESTABLEC ")
        strSQL.Append(" FROM SAB_EST_DETALLESOLICITUDES AS DS inner join SAB_EST_SOLICITUDES AS S on DS.IDSOLICITUD = S.IDSOLICITUD  ")
        strSQL.Append(" inner join vv_CATALOGOPRODUCTOS AS VC on DS.IDPRODUCTO = VC.IDPRODUCTO ")
        strSQL.Append(" WHERE S.IDSOLICITUD = @IDSOLICITUD AND S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO)  ")
        strSQL.Append(" SubQuery INNER JOIN SAB_EST_DETALLESOLICITUDES ON  SubQuery.SOLICITUD  = SAB_EST_DETALLESOLICITUDES.IDSOLICITUD  ")
        strSQL.Append(" AND SubQuery.ESTABLEC   = SAB_EST_DETALLESOLICITUDES.IDESTABLECIMIENTO and SubQuery.IDPRODUCTO = SAB_EST_DETALLESOLICITUDES.IDPRODUCTO ")
        strSQL.Append(" WHERE SAB_EST_DETALLESOLICITUDES.IDSOLICITUD = @IDSOLICITUD AND SAB_EST_DETALLESOLICITUDES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDEstablecimiento
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = idSolicitud

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function


    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLESOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(2).Value = lEntidad.RENGLON

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.RENGLON = IIf(.Item("RENGLON") Is DBNull.Value, Nothing, .Item("RENGLON"))
                lEntidad.IDPRODUCTO = IIf(.Item("IDPRODUCTO") Is DBNull.Value, Nothing, .Item("IDPRODUCTO"))
                lEntidad.CANTIDAD = IIf(.Item("CANTIDAD") Is DBNull.Value, Nothing, .Item("CANTIDAD"))
                lEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
                lEntidad.PRESUPUESTOUNITARIO = IIf(.Item("PRESUPUESTOUNITARIO") Is DBNull.Value, Nothing, .Item("PRESUPUESTOUNITARIO"))
                lEntidad.PRESUPUESTOTOTAL = IIf(.Item("PRESUPUESTOTOTAL") Is DBNull.Value, Nothing, .Item("PRESUPUESTOTOTAL"))
                lEntidad.NUMEROENTREGAS = IIf(.Item("NUMEROENTREGAS") Is DBNull.Value, Nothing, .Item("NUMEROENTREGAS"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As DETALLESOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_DETALLESOLICITUDES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As listaDETALLESOLICITUDES

        Dim strSQL As New StringBuilder
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

        Dim lista As New listaDETALLESOLICITUDES

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLESOLICITUDES
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDSOLICITUD = IDSOLICITUD
                mEntidad.IDDETALLE = IIf(dr("IDDETALLE") Is DBNull.Value, Nothing, dr("IDDETALLE"))
                mEntidad.RENGLON = IIf(dr("RENGLON") Is DBNull.Value, Nothing, dr("RENGLON"))
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.CANTIDAD = IIf(dr("CANTIDAD") Is DBNull.Value, Nothing, dr("CANTIDAD"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.PRESUPUESTOUNITARIO = IIf(dr("PRESUPUESTOUNITARIO") Is DBNull.Value, Nothing, dr("PRESUPUESTOUNITARIO"))
                mEntidad.PRESUPUESTOTOTAL = IIf(dr("PRESUPUESTOTOTAL") Is DBNull.Value, Nothing, dr("PRESUPUESTOTOTAL"))
                mEntidad.NUMEROENTREGAS = IIf(dr("NUMEROENTREGAS") Is DBNull.Value, Nothing, dr("NUMEROENTREGAS"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet

        Dim strSQL As New StringBuilder
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

    Public Function ObtenerRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" Select max(SAB_EST_DETALLESOLICITUDES.RENGLON) + 1 ")
        strSQL.Append(" FROM SAB_EST_DETALLESOLICITUDES ")
        strSQL.Append(" inner join SAB_EST_SOLICITUDES on SAB_EST_DETALLESOLICITUDES.IDSOLICITUD = SAB_EST_SOLICITUDES.IDSOLICITUD ")
        strSQL.Append(" WHERE SAB_EST_SOLICITUDES.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND SAB_EST_SOLICITUDES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Return ds
    End Function

    Public Function ObtenerRenglonPorSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" Select SAB_EST_DETALLESOLICITUDES.RENGLON ")
        strSQL.Append(" FROM SAB_EST_DETALLESOLICITUDES ")
        strSQL.Append(" inner join SAB_EST_SOLICITUDES on SAB_EST_DETALLESOLICITUDES.IDSOLICITUD = SAB_EST_SOLICITUDES.IDSOLICITUD ")
        strSQL.Append(" WHERE SAB_EST_SOLICITUDES.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND SAB_EST_SOLICITUDES.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Return ds
    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD

        Dim tables(0) As String
        tables(0) = New String("DETALLESOLICITUDES")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" PRESUPUESTOUNITARIO, ")
        strSQL.Append(" PRESUPUESTOTOTAL, ")
        strSQL.Append(" NUMEROENTREGAS, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" IDESPECIFICACION ")
        strSQL.Append(" FROM SAB_EST_DETALLESOLICITUDES ")

    End Sub

#End Region

End Class
