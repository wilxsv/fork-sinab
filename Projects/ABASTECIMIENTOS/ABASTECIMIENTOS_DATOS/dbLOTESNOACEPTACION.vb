Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbLOTESNOACEPTACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_ALM_LOTESNOACEPTACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbLOTESNOACEPTACION
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As LOTESNOACEPTACION
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
        strSQL.Append("UPDATE SAB_ALM_LOTESNOACEPTACION ")
        strSQL.Append(" SET IDPRODUCTO = @IDPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA = @IDUNIDADMEDIDA, ")
        strSQL.Append(" CODIGO = @CODIGO, ")
        strSQL.Append(" PRECIOLOTE = @PRECIOLOTE, ")
        strSQL.Append(" FECHAVENCIMIENTO = @FECHAVENCIMIENTO, ")
        strSQL.Append(" IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" IDESTABLECIMIENTO = @IDESTABLECIMIENTO, ")
        strSQL.Append(" IDINFORMECONTROLCALIDAD = @IDINFORMECONTROLCALIDAD, ")
        strSQL.Append(" IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" CANTIDADENTREGA = @CANTIDADENTREGA, ")
        strSQL.Append(" ESTADISPONIBLE = @ESTADISPONIBLE, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDLOTE = @IDLOTE ")

        Dim args(17) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPRODUCTO
        args(1) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(1).Value = lEntidad.IDUNIDADMEDIDA
        args(2) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.CODIGO = Nothing, DBNull.Value, lEntidad.CODIGO)
        args(3) = New SqlParameter("@PRECIOLOTE", SqlDbType.Decimal)
        args(3).Value = lEntidad.PRECIOLOTE
        args(4) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.FECHAVENCIMIENTO = Nothing, DBNull.Value, lEntidad.FECHAVENCIMIENTO)
        args(5) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(5).Value = lEntidad.IDRESPONSABLEDISTRIBUCION
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(7) = New SqlParameter("@IDINFORMECONTROLCALIDAD", SqlDbType.Int)
        args(7).Value = IIf(lEntidad.IDINFORMECONTROLCALIDAD = Nothing, DBNull.Value, lEntidad.IDINFORMECONTROLCALIDAD)
        args(8) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(8).Value = lEntidad.IDFUENTEFINANCIAMIENTO
        args(9) = New SqlParameter("@CANTIDADENTREGA", SqlDbType.Decimal)
        args(9).Value = lEntidad.CANTIDADENTREGA
        args(10) = New SqlParameter("@ESTADISPONIBLE", SqlDbType.TinyInt)
        args(10).Value = lEntidad.ESTADISPONIBLE
        args(11) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(11).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(12) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(13) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(14) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(15) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(15).Value = lEntidad.ESTASINCRONIZADA
        args(16) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(16).Value = lEntidad.IDALMACEN
        args(17) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(17).Value = lEntidad.IDLOTE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As LOTESNOACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_ALM_LOTESNOACEPTACION ")
        strSQL.Append(" ( IDALMACEN, ")
        strSQL.Append(" IDLOTE, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" CODIGO, ")
        strSQL.Append(" PRECIOLOTE, ")
        strSQL.Append(" FECHAVENCIMIENTO, ")
        strSQL.Append(" IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDINFORMECONTROLCALIDAD, ")
        strSQL.Append(" IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" CANTIDADENTREGA, ")
        strSQL.Append(" ESTADISPONIBLE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALMACEN, ")
        strSQL.Append(" @IDLOTE, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @CODIGO, ")
        strSQL.Append(" @PRECIOLOTE, ")
        strSQL.Append(" @FECHAVENCIMIENTO, ")
        strSQL.Append(" @IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDINFORMECONTROLCALIDAD, ")
        strSQL.Append(" @IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" @CANTIDADENTREGA, ")
        strSQL.Append(" @ESTADISPONIBLE, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(17) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDLOTE
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(3).Value = lEntidad.IDUNIDADMEDIDA
        args(4) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.CODIGO = Nothing, DBNull.Value, lEntidad.CODIGO)
        args(5) = New SqlParameter("@PRECIOLOTE", SqlDbType.Decimal)
        args(5).Value = lEntidad.PRECIOLOTE
        args(6) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(6).Value = IIf(lEntidad.FECHAVENCIMIENTO = Nothing, DBNull.Value, lEntidad.FECHAVENCIMIENTO)
        args(7) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(7).Value = lEntidad.IDRESPONSABLEDISTRIBUCION
        args(8) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(8).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(9) = New SqlParameter("@IDINFORMECONTROLCALIDAD", SqlDbType.Int)
        args(9).Value = IIf(lEntidad.IDINFORMECONTROLCALIDAD = Nothing, DBNull.Value, lEntidad.IDINFORMECONTROLCALIDAD)
        args(10) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(10).Value = lEntidad.IDFUENTEFINANCIAMIENTO
        args(11) = New SqlParameter("@CANTIDADENTREGA", SqlDbType.Decimal)
        args(11).Value = lEntidad.CANTIDADENTREGA
        args(12) = New SqlParameter("@ESTADISPONIBLE", SqlDbType.TinyInt)
        args(12).Value = lEntidad.ESTADISPONIBLE
        args(13) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(14) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(15) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(15).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(16) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(17) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(17).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As LOTESNOACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_LOTESNOACEPTACION ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDLOTE = @IDLOTE ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDLOTE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As LOTESNOACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDLOTE = @IDLOTE ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDLOTE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDPRODUCTO = IIf(.Item("IDPRODUCTO") Is DBNull.Value, Nothing, .Item("IDPRODUCTO"))
                lEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
                lEntidad.CODIGO = IIf(.Item("CODIGO") Is DBNull.Value, Nothing, .Item("CODIGO"))
                lEntidad.PRECIOLOTE = IIf(.Item("PRECIOLOTE") Is DBNull.Value, Nothing, .Item("PRECIOLOTE"))
                lEntidad.FECHAVENCIMIENTO = IIf(.Item("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, .Item("FECHAVENCIMIENTO"))
                lEntidad.IDRESPONSABLEDISTRIBUCION = IIf(.Item("IDRESPONSABLEDISTRIBUCION") Is DBNull.Value, Nothing, .Item("IDRESPONSABLEDISTRIBUCION"))
                lEntidad.IDESTABLECIMIENTO = IIf(.Item("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTO"))
                lEntidad.IDINFORMECONTROLCALIDAD = IIf(.Item("IDINFORMECONTROLCALIDAD") Is DBNull.Value, Nothing, .Item("IDINFORMECONTROLCALIDAD"))
                lEntidad.IDFUENTEFINANCIAMIENTO = IIf(.Item("IDFUENTEFINANCIAMIENTO") Is DBNull.Value, Nothing, .Item("IDFUENTEFINANCIAMIENTO"))
                lEntidad.CANTIDADENTREGA = IIf(.Item("CANTIDADENTREGA") Is DBNull.Value, Nothing, .Item("CANTIDADENTREGA"))
                lEntidad.ESTADISPONIBLE = IIf(.Item("ESTADISPONIBLE") Is DBNull.Value, Nothing, .Item("ESTADISPONIBLE"))
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

        Dim lEntidad As LOTESNOACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDLOTE),0) + 1 ")
        strSQL.Append(" FROM SAB_ALM_LOTESNOACEPTACION ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32) As listaLOTESNOACEPTACION

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaLOTESNOACEPTACION

        Try
            Do While dr.Read()
                Dim mEntidad As New LOTESNOACEPTACION
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.IDLOTE = IIf(dr("IDLOTE") Is DBNull.Value, Nothing, dr("IDLOTE"))
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.CODIGO = IIf(dr("CODIGO") Is DBNull.Value, Nothing, dr("CODIGO"))
                mEntidad.PRECIOLOTE = IIf(dr("PRECIOLOTE") Is DBNull.Value, Nothing, dr("PRECIOLOTE"))
                mEntidad.FECHAVENCIMIENTO = IIf(dr("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, dr("FECHAVENCIMIENTO"))
                mEntidad.IDRESPONSABLEDISTRIBUCION = IIf(dr("IDRESPONSABLEDISTRIBUCION") Is DBNull.Value, Nothing, dr("IDRESPONSABLEDISTRIBUCION"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.IDINFORMECONTROLCALIDAD = IIf(dr("IDINFORMECONTROLCALIDAD") Is DBNull.Value, Nothing, dr("IDINFORMECONTROLCALIDAD"))
                mEntidad.IDFUENTEFINANCIAMIENTO = IIf(dr("IDFUENTEFINANCIAMIENTO") Is DBNull.Value, Nothing, dr("IDFUENTEFINANCIAMIENTO"))
                mEntidad.CANTIDADENTREGA = IIf(dr("CANTIDADENTREGA") Is DBNull.Value, Nothing, dr("CANTIDADENTREGA"))
                mEntidad.ESTADISPONIBLE = IIf(dr("ESTADISPONIBLE") Is DBNull.Value, Nothing, dr("ESTADISPONIBLE"))
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
        tables(0) = New String("LOTESNOACEPTACION")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDALMACEN, ")
        strSQL.Append(" IDLOTE, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" CODIGO, ")
        strSQL.Append(" PRECIOLOTE, ")
        strSQL.Append(" FECHAVENCIMIENTO, ")
        strSQL.Append(" IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDINFORMECONTROLCALIDAD, ")
        strSQL.Append(" IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" CANTIDADENTREGA, ")
        strSQL.Append(" ESTADISPONIBLE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_ALM_LOTESNOACEPTACION ")

    End Sub

#End Region

End Class
