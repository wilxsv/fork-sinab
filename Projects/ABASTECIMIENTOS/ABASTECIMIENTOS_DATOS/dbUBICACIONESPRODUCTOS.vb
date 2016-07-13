Imports System.Text

Public Class dbUBICACIONESPRODUCTOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As UBICACIONESPRODUCTOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDUBICACION = 0 _
            Or lEntidad.IDUBICACION = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDUBICACION = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_ALM_UBICACIONESPRODUCTOS ")
        strSQL.Append(" SET UBICACION = @UBICACION, ")
        strSQL.Append(" IDLOTE = @IDLOTE, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDUBICACION = @IDUBICACION ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@UBICACION", SqlDbType.VarChar)
        args(0).Value = lEntidad.UBICACION
        args(1) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(1).Value = IIf(lEntidad.IDLOTE = Nothing, DBNull.Value, lEntidad.IDLOTE)
        args(2) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(3) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(4) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(5) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(5).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(6) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(6).Value = lEntidad.ESTASINCRONIZADA
        args(7) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(7).Value = lEntidad.IDALMACEN
        args(8) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(8).Value = lEntidad.IDPRODUCTO
        args(9) = New SqlParameter("@IDUBICACION", SqlDbType.Int)
        args(9).Value = lEntidad.IDUBICACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As UBICACIONESPRODUCTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_ALM_UBICACIONESPRODUCTOS ")
        strSQL.Append(" ( IDALMACEN, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDUBICACION, ")
        strSQL.Append(" UBICACION, ")
        strSQL.Append(" IDLOTE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALMACEN, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @IDUBICACION, ")
        strSQL.Append(" @UBICACION, ")
        strSQL.Append(" @IDLOTE, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@IDUBICACION", SqlDbType.Int)
        args(2).Value = lEntidad.IDUBICACION
        args(3) = New SqlParameter("@UBICACION", SqlDbType.VarChar)
        args(3).Value = lEntidad.UBICACION
        args(4) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(4).Value = IIf(lEntidad.IDLOTE = Nothing, DBNull.Value, lEntidad.IDLOTE)
        args(5) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(6) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(6).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(7) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(8) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(9) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(9).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As UBICACIONESPRODUCTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_UBICACIONESPRODUCTOS ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDUBICACION = @IDUBICACION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@IDUBICACION", SqlDbType.Int)
        args(2).Value = lEntidad.IDUBICACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As UBICACIONESPRODUCTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDUBICACION = @IDUBICACION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@IDUBICACION", SqlDbType.Int)
        args(2).Value = lEntidad.IDUBICACION

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.UBICACION = IIf(.Item("UBICACION") Is DBNull.Value, Nothing, .Item("UBICACION"))
                lEntidad.IDLOTE = IIf(.Item("IDLOTE") Is DBNull.Value, Nothing, .Item("IDLOTE"))
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

        Dim lEntidad As UBICACIONESPRODUCTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDUBICACION),0) + 1 ")
        strSQL.Append(" FROM SAB_ALM_UBICACIONESPRODUCTOS ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32) As listaUBICACIONESPRODUCTOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaUBICACIONESPRODUCTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New UBICACIONESPRODUCTOS
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.IDUBICACION = IIf(dr("IDUBICACION") Is DBNull.Value, Nothing, dr("IDUBICACION"))
                mEntidad.UBICACION = IIf(dr("UBICACION") Is DBNull.Value, Nothing, dr("UBICACION"))
                mEntidad.IDLOTE = IIf(dr("IDLOTE") Is DBNull.Value, Nothing, dr("IDLOTE"))
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

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim tables(0) As String
        tables(0) = New String("UBICACIONESPRODUCTOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDALMACEN, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDUBICACION, ")
        strSQL.Append(" UBICACION, ")
        strSQL.Append(" IDLOTE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_ALM_UBICACIONESPRODUCTOS ")

    End Sub
    Public Function ObtenerUbicacionesProductosAlmacen(ByVal IDALMACEN As Int32, ByVal idproducto As Integer) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append(" select l.codigo as lote, CONVERT(VARCHAR(8), l.fechavencimiento, 1) AS fechavencimiento, up.ubicacion ")
        strSQL.Append(" from sab_alm_ubicacionesproductos up ")
        strSQL.Append(" inner join sab_alm_lotes l on ")
        strSQL.Append(" l.idlote=up.idlote and ")
        strSQL.Append(" l.idalmacen=up.idalmacen ")
        strSQL.Append(" where up.idalmacen=" & IDALMACEN)
        strSQL.Append(" and up.idproducto=" & idproducto)


        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())


    End Function

#End Region

End Class
