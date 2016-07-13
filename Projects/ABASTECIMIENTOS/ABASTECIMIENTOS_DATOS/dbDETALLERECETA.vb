Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLERECETA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla DETALLERECETA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLERECETA
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLERECETA
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
        strSQL.Append("UPDATE SAB_EST_DETALLERECETA ")
        strSQL.Append(" SET IDPRODUCTO = @IDPRODUCTO, ")
        strSQL.Append(" CANTIDAD = @CANTIDAD, ")
        strSQL.Append(" IDUNIDADMEDIDA = @IDUNIDADMEDIDA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")
        strSQL.Append(" AND IDRECETA = @IDRECETA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IIf(lEntidad.IDPRODUCTO = Nothing, DBNull.Value, lEntidad.IDPRODUCTO)
        args(1) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args(1).Value = lEntidad.CANTIDAD
        args(2) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(2).Value = IIf(lEntidad.IDUNIDADMEDIDA = Nothing, DBNull.Value, lEntidad.IDUNIDADMEDIDA)
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(7) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(7).Value = lEntidad.ESTASINCRONIZADA
        args(8) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(8).Value = lEntidad.IDESTABLECIMIENTO
        args(9) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(9).Value = lEntidad.IDCARGA
        args(10) = New SqlParameter("@IDRECETA", SqlDbType.Int)
        args(10).Value = lEntidad.IDRECETA
        args(11) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(11).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLERECETA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_DETALLERECETA ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCARGA, ")
        strSQL.Append(" IDRECETA, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDCARGA, ")
        strSQL.Append(" @IDRECETA, ")
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @CANTIDAD, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = lEntidad.IDCARGA
        args(2) = New SqlParameter("@IDRECETA", SqlDbType.Int)
        args(2).Value = lEntidad.IDRECETA
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = lEntidad.IDDETALLE
        args(4) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(4).Value = IIf(lEntidad.IDPRODUCTO = Nothing, DBNull.Value, lEntidad.IDPRODUCTO)
        args(5) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args(5).Value = lEntidad.CANTIDAD
        args(6) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(6).Value = IIf(lEntidad.IDUNIDADMEDIDA = Nothing, DBNull.Value, lEntidad.IDUNIDADMEDIDA)
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLERECETA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_DETALLERECETA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")
        strSQL.Append(" AND IDRECETA = @IDRECETA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = lEntidad.IDCARGA
        args(2) = New SqlParameter("@IDRECETA", SqlDbType.Int)
        args(2).Value = lEntidad.IDRECETA
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLERECETA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")
        strSQL.Append(" AND IDRECETA = @IDRECETA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = lEntidad.IDCARGA
        args(2) = New SqlParameter("@IDRECETA", SqlDbType.Int)
        args(2).Value = lEntidad.IDRECETA
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = lEntidad.IDDETALLE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDPRODUCTO = IIf(.Item("IDPRODUCTO") Is DBNull.Value, Nothing, .Item("IDPRODUCTO"))
                lEntidad.CANTIDAD = IIf(.Item("CANTIDAD") Is DBNull.Value, Nothing, .Item("CANTIDAD"))
                lEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
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

        Dim lEntidad As DETALLERECETA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_DETALLERECETA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")
        strSQL.Append(" AND IDRECETA = @IDRECETA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = lEntidad.IDCARGA
        args(2) = New SqlParameter("@IDRECETA", SqlDbType.Int)
        args(2).Value = lEntidad.IDRECETA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCARGA As Int32, ByVal IDRECETA As Int32) As listaDETALLERECETA

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")
        strSQL.Append(" AND IDRECETA = @IDRECETA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = IDCARGA
        args(2) = New SqlParameter("@IDRECETA", SqlDbType.Int)
        args(2).Value = IDRECETA

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLERECETA

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLERECETA
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDCARGA = IDCARGA
                mEntidad.IDRECETA = IDRECETA
                mEntidad.IDDETALLE = IIf(dr("IDDETALLE") Is DBNull.Value, Nothing, dr("IDDETALLE"))
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.CANTIDAD = IIf(dr("CANTIDAD") Is DBNull.Value, Nothing, dr("CANTIDAD"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCARGA As Int32, ByVal IDRECETA As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")
        strSQL.Append(" AND IDRECETA = @IDRECETA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = IDCARGA
        args(2) = New SqlParameter("@IDRECETA", SqlDbType.Int)
        args(2).Value = IDRECETA

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCARGA As Int32, ByVal IDRECETA As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")
        strSQL.Append(" AND IDRECETA = @IDRECETA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = IDCARGA
        args(2) = New SqlParameter("@IDRECETA", SqlDbType.Int)
        args(2).Value = IDRECETA

        Dim tables(0) As String
        tables(0) = New String("DETALLERECETA")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCARGA, ")
        strSQL.Append(" IDRECETA, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_DETALLERECETA ")

    End Sub

#End Region

End Class
