Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbALTERNATIVASPRODUCTO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla ALTERNATIVASPRODUCTO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbALTERNATIVASPRODUCTO
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALTERNATIVASPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_ALTERNATIVASPRODUCTO ")
        strSQL.Append(" SET AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDALTERNATIVA = @IDALTERNATIVA ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(0).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(1) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(1).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(2) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(3) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(4) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(4).Value = lEntidad.ESTASINCRONIZADA
        args(5) = New SqlParameter("@IDALTERNATIVA", SqlDbType.BigInt)
        args(5).Value = lEntidad.IDALTERNATIVA
        args(6) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(6).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALTERNATIVASPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_ALTERNATIVASPRODUCTO ")
        strSQL.Append(" ( IDALTERNATIVA, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALTERNATIVA, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDALTERNATIVA", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDALTERNATIVA
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALTERNATIVASPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_ALTERNATIVASPRODUCTO ")
        strSQL.Append(" WHERE IDALTERNATIVA = @IDALTERNATIVA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALTERNATIVA", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDALTERNATIVA
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALTERNATIVASPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALTERNATIVA = @IDALTERNATIVA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALTERNATIVA", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDALTERNATIVA
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
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

        Return -1

    End Function

    Public Function ObtenerListaPorID(ByVal IDALTERNATIVA As Int64, ByVal IDPRODUCTO As Int64) As listaALTERNATIVASPRODUCTO

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALTERNATIVA = @IDALTERNATIVA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALTERNATIVA", SqlDbType.BigInt)
        args(0).Value = IDALTERNATIVA
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaALTERNATIVASPRODUCTO

        Try
            Do While dr.Read()
                Dim mEntidad As New ALTERNATIVASPRODUCTO
                mEntidad.IDALTERNATIVA = IDALTERNATIVA
                mEntidad.IDPRODUCTO = IDPRODUCTO
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

    Public Function ObtenerDataSetPorID(ByVal IDALTERNATIVA As Int64, ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALTERNATIVA = @IDALTERNATIVA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALTERNATIVA", SqlDbType.BigInt)
        args(0).Value = IDALTERNATIVA
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALTERNATIVA As Int64, ByVal IDPRODUCTO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALTERNATIVA = @IDALTERNATIVA ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALTERNATIVA", SqlDbType.BigInt)
        args(0).Value = IDALTERNATIVA
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO

        Dim tables(0) As String
        tables(0) = New String("ALTERNATIVASPRODUCTO")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDALTERNATIVA, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_ALTERNATIVASPRODUCTO ")

    End Sub

#End Region

End Class
