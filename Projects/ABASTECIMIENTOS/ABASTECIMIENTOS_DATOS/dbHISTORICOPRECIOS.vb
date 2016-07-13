Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbHISTORICOPRECIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla HISTORICOPRECIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbHISTORICOPRECIOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As HISTORICOPRECIOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.CORRELATIVO = 0 _
            Or lEntidad.CORRELATIVO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.CORRELATIVO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_HISTORICOPRECIOS ")
        strSQL.Append(" SET FECHA = @FECHA, ")
        strSQL.Append(" PRECIO = @PRECIO, ")
        strSQL.Append(" CODIGOLICITACION = @CODIGOLICITACION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND CORRELATIVO = @CORRELATIVO ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(0).Value = IIf(lEntidad.FECHA = Nothing, DBNull.Value, lEntidad.FECHA)
        args(1) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(1).Value = IIf(lEntidad.PRECIO = Nothing, DBNull.Value, lEntidad.PRECIO)
        args(2) = New SqlParameter("@CODIGOLICITACION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.CODIGOLICITACION = Nothing, DBNull.Value, lEntidad.CODIGOLICITACION)
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
        args(8) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(8).Value = lEntidad.IDPRODUCTO
        args(9) = New SqlParameter("@CORRELATIVO", SqlDbType.BigInt)
        args(9).Value = lEntidad.CORRELATIVO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As HISTORICOPRECIOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_HISTORICOPRECIOS ")
        strSQL.Append(" ( IDPRODUCTO, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" FECHA, ")
        strSQL.Append(" PRECIO, ")
        strSQL.Append(" CODIGOLICITACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDPRODUCTO, ")
        strSQL.Append(" @CORRELATIVO, ")
        strSQL.Append(" @FECHA, ")
        strSQL.Append(" @PRECIO, ")
        strSQL.Append(" @CODIGOLICITACION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPRODUCTO
        args(1) = New SqlParameter("@CORRELATIVO", SqlDbType.BigInt)
        args(1).Value = lEntidad.CORRELATIVO
        args(2) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(2).Value = IIf(lEntidad.FECHA = Nothing, DBNull.Value, lEntidad.FECHA)
        args(3) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(3).Value = IIf(lEntidad.PRECIO = Nothing, DBNull.Value, lEntidad.PRECIO)
        args(4) = New SqlParameter("@CODIGOLICITACION", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.CODIGOLICITACION = Nothing, DBNull.Value, lEntidad.CODIGOLICITACION)
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

        Dim lEntidad As HISTORICOPRECIOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_HISTORICOPRECIOS ")
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND CORRELATIVO = @CORRELATIVO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPRODUCTO
        args(1) = New SqlParameter("@CORRELATIVO", SqlDbType.BigInt)
        args(1).Value = lEntidad.CORRELATIVO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As HISTORICOPRECIOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND CORRELATIVO = @CORRELATIVO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPRODUCTO
        args(1) = New SqlParameter("@CORRELATIVO", SqlDbType.BigInt)
        args(1).Value = lEntidad.CORRELATIVO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.FECHA = IIf(.Item("FECHA") Is DBNull.Value, Nothing, .Item("FECHA"))
                lEntidad.PRECIO = IIf(.Item("PRECIO") Is DBNull.Value, Nothing, .Item("PRECIO"))
                lEntidad.CODIGOLICITACION = IIf(.Item("CODIGOLICITACION") Is DBNull.Value, Nothing, .Item("CODIGOLICITACION"))
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

        Dim lEntidad As HISTORICOPRECIOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(CORRELATIVO),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_HISTORICOPRECIOS ")
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDPRODUCTO As Int64) As listaHISTORICOPRECIOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaHISTORICOPRECIOS

        Try
            Do While dr.Read()
                Dim mEntidad As New HISTORICOPRECIOS
                mEntidad.IDPRODUCTO = IDPRODUCTO
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.FECHA = IIf(dr("FECHA") Is DBNull.Value, Nothing, dr("FECHA"))
                mEntidad.PRECIO = IIf(dr("PRECIO") Is DBNull.Value, Nothing, dr("PRECIO"))
                mEntidad.CODIGOLICITACION = IIf(dr("CODIGOLICITACION") Is DBNull.Value, Nothing, dr("CODIGOLICITACION"))
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

    Public Function ObtenerDataSetPorID(ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDPRODUCTO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Dim tables(0) As String
        tables(0) = New String("HISTORICOPRECIOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDPRODUCTO, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" FECHA, ")
        strSQL.Append(" PRECIO, ")
        strSQL.Append(" CODIGOLICITACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_HISTORICOPRECIOS ")

    End Sub

#End Region

End Class
