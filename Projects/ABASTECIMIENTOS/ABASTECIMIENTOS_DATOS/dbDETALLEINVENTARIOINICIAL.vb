Imports System.Text

Public Class dbDETALLEINVENTARIOINICIAL
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEINVENTARIOINICIAL
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDLOTE = 0 _
            Or lEntidad.IDLOTE = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDLOTE = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_ALM_DETALLEINVENTARIOINICIAL ")
        strSQL.Append("SET IDPRODUCTO = @IDPRODUCTO, ")
        strSQL.Append("IDUNIDADMEDIDA = @IDUNIDADMEDIDA, ")
        strSQL.Append("CODIGO = @CODIGO, ")
        strSQL.Append("DETALLE = @DETALLE, ")
        strSQL.Append("PRECIOLOTE = @PRECIOLOTE, ")
        strSQL.Append("FECHAVENCIMIENTO = @FECHAVENCIMIENTO, ")
        strSQL.Append("IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("CANTIDADDISPONIBLE = @CANTIDADDISPONIBLE, ")
        strSQL.Append("CANTIDADNODISPONIBLE = @CANTIDADNODISPONIBLE, ")
        strSQL.Append("CANTIDADVENCIDA = @CANTIDADVENCIDA, ")
        strSQL.Append("UBICACION = @UBICACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append("AND IDLOTE = @IDLOTE ")

        Dim args(19) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO
        args(2) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDLOTE
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDPRODUCTO
        args(4) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(4).Value = lEntidad.IDUNIDADMEDIDA
        args(5) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.CODIGO = Nothing, DBNull.Value, lEntidad.CODIGO)
        args(6) = New SqlParameter("@DETALLE", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.DETALLE = Nothing, DBNull.Value, lEntidad.DETALLE)
        args(7) = New SqlParameter("@PRECIOLOTE", SqlDbType.Decimal)
        args(7).Value = lEntidad.PRECIOLOTE
        args(8) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.FECHAVENCIMIENTO = Nothing, DBNull.Value, lEntidad.FECHAVENCIMIENTO)
        args(9) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(9).Value = IIf(lEntidad.IDFUENTEFINANCIAMIENTO = Nothing, DBNull.Value, lEntidad.IDFUENTEFINANCIAMIENTO)
        args(10) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(10).Value = IIf(lEntidad.IDRESPONSABLEDISTRIBUCION = Nothing, DBNull.Value, lEntidad.IDRESPONSABLEDISTRIBUCION)
        args(11) = New SqlParameter("@CANTIDADDISPONIBLE", SqlDbType.Decimal)
        args(11).Value = lEntidad.CANTIDADDISPONIBLE
        args(12) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.Decimal)
        args(12).Value = lEntidad.CANTIDADNODISPONIBLE
        args(13) = New SqlParameter("@CANTIDADVENCIDA", SqlDbType.Decimal)
        args(13).Value = lEntidad.CANTIDADVENCIDA
        args(14) = New SqlParameter("@UBICACION", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.UBICACION = Nothing, DBNull.Value, lEntidad.UBICACION)
        args(15) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(15).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(16) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(17) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(18) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(19) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(19).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEINVENTARIOINICIAL
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_ALM_DETALLEINVENTARIOINICIAL ")
        strSQL.Append("(IDALMACEN, ")
        strSQL.Append("IDINVENTARIO, ")
        strSQL.Append("IDLOTE, ")
        strSQL.Append("IDPRODUCTO, ")
        strSQL.Append("IDUNIDADMEDIDA, ")
        strSQL.Append("CODIGO, ")
        strSQL.Append("DETALLE, ")
        strSQL.Append("PRECIOLOTE, ")
        strSQL.Append("FECHAVENCIMIENTO, ")
        strSQL.Append("IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("CANTIDADDISPONIBLE, ")
        strSQL.Append("CANTIDADNODISPONIBLE, ")
        strSQL.Append("CANTIDADVENCIDA, ")
        strSQL.Append("UBICACION, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("ESTASINCRONIZADA) ")
        strSQL.Append("VALUES ")
        strSQL.Append("(@IDALMACEN, ")
        strSQL.Append("@IDINVENTARIO, ")
        strSQL.Append("@IDLOTE, ")
        strSQL.Append("@IDPRODUCTO, ")
        strSQL.Append("@IDUNIDADMEDIDA, ")
        strSQL.Append("@CODIGO, ")
        strSQL.Append("@DETALLE, ")
        strSQL.Append("@PRECIOLOTE, ")
        strSQL.Append("@FECHAVENCIMIENTO, ")
        strSQL.Append("@IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("@IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("@CANTIDADDISPONIBLE, ")
        strSQL.Append("@CANTIDADNODISPONIBLE, ")
        strSQL.Append("@CANTIDADVENCIDA, ")
        strSQL.Append("@UBICACION, ")
        strSQL.Append("@AUUSUARIOCREACION, ")
        strSQL.Append("@AUFECHACREACION, ")
        strSQL.Append("@ESTASINCRONIZADA) ")

        Dim args(19) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO
        args(2) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDLOTE
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDPRODUCTO
        args(4) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(4).Value = lEntidad.IDUNIDADMEDIDA
        args(5) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.CODIGO = Nothing, DBNull.Value, lEntidad.CODIGO)
        args(6) = New SqlParameter("@DETALLE", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.DETALLE = Nothing, DBNull.Value, lEntidad.DETALLE)
        args(7) = New SqlParameter("@PRECIOLOTE", SqlDbType.Decimal)
        args(7).Value = lEntidad.PRECIOLOTE
        args(8) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.FECHAVENCIMIENTO = Nothing, DBNull.Value, lEntidad.FECHAVENCIMIENTO)
        args(9) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(9).Value = IIf(lEntidad.IDFUENTEFINANCIAMIENTO = Nothing, DBNull.Value, lEntidad.IDFUENTEFINANCIAMIENTO)
        args(10) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(10).Value = IIf(lEntidad.IDRESPONSABLEDISTRIBUCION = Nothing, DBNull.Value, lEntidad.IDRESPONSABLEDISTRIBUCION)
        args(11) = New SqlParameter("@CANTIDADDISPONIBLE", SqlDbType.Decimal)
        args(11).Value = lEntidad.CANTIDADDISPONIBLE
        args(12) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.Decimal)
        args(12).Value = lEntidad.CANTIDADNODISPONIBLE
        args(13) = New SqlParameter("@CANTIDADVENCIDA", SqlDbType.Decimal)
        args(13).Value = lEntidad.CANTIDADVENCIDA
        args(14) = New SqlParameter("@UBICACION", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.UBICACION = Nothing, DBNull.Value, lEntidad.UBICACION)
        args(15) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(15).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(16) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(17) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(18) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(19) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(19).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEINVENTARIOINICIAL
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_DETALLEINVENTARIOINICIAL ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append("AND IDLOTE = @IDLOTE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO
        args(2) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDLOTE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEINVENTARIOINICIAL
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append("AND IDLOTE = @IDLOTE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO
        args(2) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDLOTE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDPRODUCTO = IIf(.Item("IDPRODUCTO") Is DBNull.Value, Nothing, .Item("IDPRODUCTO"))
                lEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
                lEntidad.CODIGO = IIf(.Item("CODIGO") Is DBNull.Value, Nothing, .Item("CODIGO"))
                lEntidad.DETALLE = IIf(.Item("DETALLE") Is DBNull.Value, Nothing, .Item("DETALLE"))
                lEntidad.PRECIOLOTE = IIf(.Item("PRECIOLOTE") Is DBNull.Value, Nothing, .Item("PRECIOLOTE"))
                lEntidad.FECHAVENCIMIENTO = IIf(.Item("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, .Item("FECHAVENCIMIENTO"))
                lEntidad.IDFUENTEFINANCIAMIENTO = IIf(.Item("IDFUENTEFINANCIAMIENTO") Is DBNull.Value, Nothing, .Item("IDFUENTEFINANCIAMIENTO"))
                lEntidad.IDRESPONSABLEDISTRIBUCION = IIf(.Item("IDRESPONSABLEDISTRIBUCION") Is DBNull.Value, Nothing, .Item("IDRESPONSABLEDISTRIBUCION"))
                lEntidad.UBICACION = IIf(.Item("UBICACION") Is DBNull.Value, Nothing, .Item("UBICACION"))
                lEntidad.CANTIDADDISPONIBLE = IIf(.Item("CANTIDADDISPONIBLE") Is DBNull.Value, Nothing, .Item("CANTIDADDISPONIBLE"))
                lEntidad.CANTIDADNODISPONIBLE = IIf(.Item("CANTIDADNODISPONIBLE") Is DBNull.Value, Nothing, .Item("CANTIDADNODISPONIBLE"))
                lEntidad.CANTIDADVENCIDA = IIf(.Item("CANTIDADVENCIDA") Is DBNull.Value, Nothing, .Item("CANTIDADVENCIDA"))
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

        Dim lEntidad As DETALLEINVENTARIOINICIAL
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDLOTE),0) + 1 ")
        strSQL.Append("FROM SAB_ALM_DETALLEINVENTARIOINICIAL ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As listaDETALLEINVENTARIOINICIAL

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLEINVENTARIOINICIAL

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLEINVENTARIOINICIAL
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.IDINVENTARIO = IDINVENTARIO
                mEntidad.IDLOTE = IIf(dr("IDLOTE") Is DBNull.Value, Nothing, dr("IDLOTE"))
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.CODIGO = IIf(dr("CODIGO") Is DBNull.Value, Nothing, dr("CODIGO"))
                mEntidad.DETALLE = IIf(dr("DETALLE") Is DBNull.Value, Nothing, dr("DETALLE"))
                mEntidad.PRECIOLOTE = IIf(dr("PRECIOLOTE") Is DBNull.Value, Nothing, dr("PRECIOLOTE"))
                mEntidad.FECHAVENCIMIENTO = IIf(dr("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, dr("FECHAVENCIMIENTO"))
                mEntidad.IDFUENTEFINANCIAMIENTO = IIf(dr("IDFUENTEFINANCIAMIENTO") Is DBNull.Value, Nothing, dr("IDFUENTEFINANCIAMIENTO"))
                mEntidad.IDRESPONSABLEDISTRIBUCION = IIf(dr("IDRESPONSABLEDISTRIBUCION") Is DBNull.Value, Nothing, dr("IDRESPONSABLEDISTRIBUCION"))
                mEntidad.CANTIDADDISPONIBLE = IIf(dr("CANTIDADDISPONIBLE") Is DBNull.Value, Nothing, dr("CANTIDADDISPONIBLE"))
                mEntidad.CANTIDADNODISPONIBLE = IIf(dr("CANTIDADNODISPONIBLE") Is DBNull.Value, Nothing, dr("CANTIDADNODISPONIBLE"))
                mEntidad.CANTIDADVENCIDA = IIf(dr("CANTIDADVENCIDA") Is DBNull.Value, Nothing, dr("CANTIDADVENCIDA"))
                mEntidad.UBICACION = IIf(dr("UBICACION") Is DBNull.Value, Nothing, dr("UBICACION"))
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

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim tables(0) As String
        tables(0) = New String("DETALLEINVENTARIOINICIAL")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append("SELECT IDALMACEN, ")
        strSQL.Append("IDINVENTARIO, ")
        strSQL.Append("IDLOTE, ")
        strSQL.Append("IDPRODUCTO, ")
        strSQL.Append("IDUNIDADMEDIDA, ")
        strSQL.Append("CODIGO, ")
        strSQL.Append("DETALLE, ")
        strSQL.Append("PRECIOLOTE, ")
        strSQL.Append("FECHAVENCIMIENTO, ")
        strSQL.Append("IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("CANTIDADDISPONIBLE, ")
        strSQL.Append("CANTIDADNODISPONIBLE, ")
        strSQL.Append("CANTIDADVENCIDA, ")
        strSQL.Append("UBICACION, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_ALM_DETALLEINVENTARIOINICIAL ")

    End Sub

#End Region

End Class
