Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbTIPOMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_CAT_TIPOMOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/06/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbTIPOMOVIMIENTOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As TIPOMOVIMIENTOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDTIPOMOVIMIENTO = 0 _
            Or lEntidad.IDTIPOMOVIMIENTO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDTIPOMOVIMIENTO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_TIPOMOVIMIENTOS ")
        strSQL.Append(" SET DESCRIPCION = @DESCRIPCION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND IDTIPOMOVIMIENTO = @IDTIPOMOVIMIENTO ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(0).Value = lEntidad.DESCRIPCION
        args(1) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(2) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(2).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(5) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(5).Value = lEntidad.ESTASINCRONIZADA
        args(6) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(6).Value = lEntidad.IDTIPOTRANSACCION
        args(7) = New SqlParameter("@IDTIPOMOVIMIENTO", SqlDbType.Int)
        args(7).Value = lEntidad.IDTIPOMOVIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As TIPOMOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_TIPOMOVIMIENTOS ")
        strSQL.Append(" ( IDTIPOTRANSACCION, ")
        strSQL.Append(" IDTIPOMOVIMIENTO, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDTIPOTRANSACCION, ")
        strSQL.Append(" @IDTIPOMOVIMIENTO, ")
        strSQL.Append(" @DESCRIPCION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOTRANSACCION
        args(1) = New SqlParameter("@IDTIPOMOVIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOMOVIMIENTO
        args(2) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(2).Value = lEntidad.DESCRIPCION
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As TIPOMOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_TIPOMOVIMIENTOS ")
        strSQL.Append(" WHERE IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND IDTIPOMOVIMIENTO = @IDTIPOMOVIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOTRANSACCION
        args(1) = New SqlParameter("@IDTIPOMOVIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOMOVIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As TIPOMOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")
        strSQL.Append(" AND IDTIPOMOVIMIENTO = @IDTIPOMOVIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOTRANSACCION
        args(1) = New SqlParameter("@IDTIPOMOVIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOMOVIMIENTO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.DESCRIPCION = IIf(.Item("DESCRIPCION") Is DBNull.Value, Nothing, .Item("DESCRIPCION"))
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

        Dim lEntidad As TIPOMOVIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDTIPOMOVIMIENTO),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_TIPOMOVIMIENTOS ")
        strSQL.Append(" WHERE IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOTRANSACCION

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDTIPOTRANSACCION As Int32) As listaTIPOMOVIMIENTOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(0).Value = IDTIPOTRANSACCION

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaTIPOMOVIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New TIPOMOVIMIENTOS
                mEntidad.IDTIPOTRANSACCION = IDTIPOTRANSACCION
                mEntidad.IDTIPOMOVIMIENTO = IIf(dr("IDTIPOMOVIMIENTO") Is DBNull.Value, Nothing, dr("IDTIPOMOVIMIENTO"))
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
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

    Public Function ObtenerDataSetPorID(ByVal IDTIPOTRANSACCION As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(0).Value = IDTIPOTRANSACCION

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDTIPOTRANSACCION As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDTIPOTRANSACCION = @IDTIPOTRANSACCION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOTRANSACCION", SqlDbType.Int)
        args(0).Value = IDTIPOTRANSACCION

        Dim tables(0) As String
        tables(0) = New String("TIPOMOVIMIENTOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDTIPOTRANSACCION, " + vbCrLf)
        strSQL.Append(" IDTIPOMOVIMIENTO, " + vbCrLf)
        strSQL.Append(" DESCRIPCION, " + vbCrLf)
        strSQL.Append(" AUUSUARIOCREACION, " + vbCrLf)
        strSQL.Append(" AUFECHACREACION, " + vbCrLf)
        strSQL.Append(" AUUSUARIOMODIFICACION, " + vbCrLf)
        strSQL.Append(" AUFECHAMODIFICACION, " + vbCrLf)
        strSQL.Append(" ESTASINCRONIZADA " + vbCrLf)
        strSQL.Append(" FROM SAB_CAT_TIPOMOVIMIENTOS " + vbCrLf)

    End Sub

#End Region

End Class
