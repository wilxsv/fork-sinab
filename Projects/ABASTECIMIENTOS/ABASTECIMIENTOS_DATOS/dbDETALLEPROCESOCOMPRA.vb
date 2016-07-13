Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLEPROCESOCOMPRA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_DETALLEPROCESOCOMPRA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLEPROCESOCOMPRA
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEPROCESOCOMPRA
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDDETALLE = 0 _
            Or lEntidad.IDDETALLE = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDDETALLE = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append(" SET RENGLON = @RENGLON, ")
        strSQL.Append(" CANTIDAD = @CANTIDAD, ")
        strSQL.Append(" NUMEROENTREGAS = @NUMEROENTREGAS, ")
        strSQL.Append(" IDUNIDADMEDIDA = @IDUNIDADMEDIDA, ")
        strSQL.Append(" GARANTIAMTTOVALOR = @GARANTIAMTTOVALOR, ")
        strSQL.Append(" IDESTADOCALIFICACION = @IDESTADOCALIFICACION, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" OBSERVACIONRECOMENDACION = @OBSERVACIONRECOMENDACION, ")
        strSQL.Append(" OBSERVACIONADJUDICADA = @OBSERVACIONADJUDICADA, ")
        strSQL.Append(" OBSERVACIONFIRME = @OBSERVACIONFIRME, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(18) As SqlParameter
        args(0) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(0).Value = lEntidad.RENGLON
        args(1) = New SqlParameter("@CANTIDAD", SqlDbType.BigInt)
        args(1).Value = lEntidad.CANTIDAD
        args(2) = New SqlParameter("@NUMEROENTREGAS", SqlDbType.TinyInt)
        args(2).Value = IIf(lEntidad.NUMEROENTREGAS = Nothing, DBNull.Value, lEntidad.NUMEROENTREGAS)
        args(3) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(3).Value = lEntidad.IDUNIDADMEDIDA
        args(4) = New SqlParameter("@GARANTIAMTTOVALOR", SqlDbType.Decimal)
        args(4).Value = IIf(lEntidad.GARANTIAMTTOVALOR = Nothing, DBNull.Value, lEntidad.GARANTIAMTTOVALOR)
        args(5) = New SqlParameter("@IDESTADOCALIFICACION", SqlDbType.TinyInt)
        args(5).Value = lEntidad.IDESTADOCALIFICACION
        args(6) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(7) = New SqlParameter("@OBSERVACIONRECOMENDACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.OBSERVACIONRECOMENDACION = Nothing, DBNull.Value, lEntidad.OBSERVACIONRECOMENDACION)
        args(8) = New SqlParameter("@OBSERVACIONADJUDICADA", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.OBSERVACIONADJUDICADA = Nothing, DBNull.Value, lEntidad.OBSERVACIONADJUDICADA)
        args(9) = New SqlParameter("@OBSERVACIONFIRME", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.OBSERVACIONFIRME = Nothing, DBNull.Value, lEntidad.OBSERVACIONFIRME)
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
        args(15) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(15).Value = lEntidad.IDESTABLECIMIENTO
        args(16) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(16).Value = lEntidad.IDPROCESOCOMPRA
        args(17) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(17).Value = lEntidad.IDPRODUCTO
        args(18) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(18).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" NUMEROENTREGAS, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" GARANTIAMTTOVALOR, ")
        strSQL.Append(" IDESTADOCALIFICACION, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" OBSERVACIONRECOMENDACION, ")
        strSQL.Append(" OBSERVACIONADJUDICADA, ")
        strSQL.Append(" OBSERVACIONFIRME, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @RENGLON, ")
        strSQL.Append(" @CANTIDAD, ")
        strSQL.Append(" @NUMEROENTREGAS, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @GARANTIAMTTOVALOR, ")
        strSQL.Append(" @IDESTADOCALIFICACION, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @OBSERVACIONRECOMENDACION, ")
        strSQL.Append(" @OBSERVACIONADJUDICADA, ")
        strSQL.Append(" @OBSERVACIONFIRME, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(18) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLE
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = lEntidad.RENGLON
        args(5) = New SqlParameter("@CANTIDAD", SqlDbType.BigInt)
        args(5).Value = lEntidad.CANTIDAD
        args(6) = New SqlParameter("@NUMEROENTREGAS", SqlDbType.TinyInt)
        args(6).Value = IIf(lEntidad.NUMEROENTREGAS = Nothing, DBNull.Value, lEntidad.NUMEROENTREGAS)
        args(7) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(7).Value = lEntidad.IDUNIDADMEDIDA
        args(8) = New SqlParameter("@GARANTIAMTTOVALOR", SqlDbType.Decimal)
        args(8).Value = IIf(lEntidad.GARANTIAMTTOVALOR = Nothing, DBNull.Value, lEntidad.GARANTIAMTTOVALOR)
        args(9) = New SqlParameter("@IDESTADOCALIFICACION", SqlDbType.TinyInt)
        args(9).Value = lEntidad.IDESTADOCALIFICACION
        args(10) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(11) = New SqlParameter("@OBSERVACIONRECOMENDACION", SqlDbType.VarChar)
        args(11).Value = IIf(lEntidad.OBSERVACIONRECOMENDACION = Nothing, DBNull.Value, lEntidad.OBSERVACIONRECOMENDACION)
        args(12) = New SqlParameter("@OBSERVACIONADJUDICADA", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.OBSERVACIONADJUDICADA = Nothing, DBNull.Value, lEntidad.OBSERVACIONADJUDICADA)
        args(13) = New SqlParameter("@OBSERVACIONFIRME", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.OBSERVACIONFIRME = Nothing, DBNull.Value, lEntidad.OBSERVACIONFIRME)
        args(14) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(15) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(15).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(16) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(17) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(17).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(18) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(18).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.RENGLON = IIf(.Item("RENGLON") Is DBNull.Value, Nothing, .Item("RENGLON"))
                lEntidad.CANTIDAD = IIf(.Item("CANTIDAD") Is DBNull.Value, Nothing, .Item("CANTIDAD"))
                lEntidad.NUMEROENTREGAS = IIf(.Item("NUMEROENTREGAS") Is DBNull.Value, Nothing, .Item("NUMEROENTREGAS"))
                lEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
                lEntidad.GARANTIAMTTOVALOR = IIf(.Item("GARANTIAMTTOVALOR") Is DBNull.Value, Nothing, .Item("GARANTIAMTTOVALOR"))
                lEntidad.IDESTADOCALIFICACION = IIf(.Item("IDESTADOCALIFICACION") Is DBNull.Value, Nothing, .Item("IDESTADOCALIFICACION"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
                lEntidad.OBSERVACIONRECOMENDACION = IIf(.Item("OBSERVACIONRECOMENDACION") Is DBNull.Value, Nothing, .Item("OBSERVACIONRECOMENDACION"))
                lEntidad.OBSERVACIONADJUDICADA = IIf(.Item("OBSERVACIONADJUDICADA") Is DBNull.Value, Nothing, .Item("OBSERVACIONADJUDICADA"))
                lEntidad.OBSERVACIONFIRME = IIf(.Item("OBSERVACIONFIRME") Is DBNull.Value, Nothing, .Item("OBSERVACIONFIRME"))
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

        Dim lEntidad As DETALLEPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_DETALLEPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPRODUCTO As Int64) As listaDETALLEPROCESOCOMPRA

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLEPROCESOCOMPRA

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLEPROCESOCOMPRA
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
                mEntidad.IDPRODUCTO = IDPRODUCTO
                mEntidad.IDDETALLE = IIf(dr("IDDETALLE") Is DBNull.Value, Nothing, dr("IDDETALLE"))
                mEntidad.RENGLON = IIf(dr("RENGLON") Is DBNull.Value, Nothing, dr("RENGLON"))
                mEntidad.CANTIDAD = IIf(dr("CANTIDAD") Is DBNull.Value, Nothing, dr("CANTIDAD"))
                mEntidad.NUMEROENTREGAS = IIf(dr("NUMEROENTREGAS") Is DBNull.Value, Nothing, dr("NUMEROENTREGAS"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.GARANTIAMTTOVALOR = IIf(dr("GARANTIAMTTOVALOR") Is DBNull.Value, Nothing, dr("GARANTIAMTTOVALOR"))
                mEntidad.IDESTADOCALIFICACION = IIf(dr("IDESTADOCALIFICACION") Is DBNull.Value, Nothing, dr("IDESTADOCALIFICACION"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.OBSERVACIONRECOMENDACION = IIf(dr("OBSERVACIONRECOMENDACION") Is DBNull.Value, Nothing, dr("OBSERVACIONRECOMENDACION"))
                mEntidad.OBSERVACIONADJUDICADA = IIf(dr("OBSERVACIONADJUDICADA") Is DBNull.Value, Nothing, dr("OBSERVACIONADJUDICADA"))
                mEntidad.OBSERVACIONFIRME = IIf(dr("OBSERVACIONFIRME") Is DBNull.Value, Nothing, dr("OBSERVACIONFIRME"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPRODUCTO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim tables(0) As String
        tables(0) = New String("DETALLEPROCESOCOMPRA")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" NUMEROENTREGAS, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" GARANTIAMTTOVALOR, ")
        strSQL.Append(" IDESTADOCALIFICACION, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" OBSERVACIONRECOMENDACION, ")
        strSQL.Append(" OBSERVACIONADJUDICADA, ")
        strSQL.Append(" OBSERVACIONFIRME, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_DETALLEPROCESOCOMPRA ")

    End Sub

#End Region

End Class
