Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbUNIDADMEDIDAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_CAT_UNIDADMEDIDAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	05/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbUNIDADMEDIDAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As UNIDADMEDIDAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDUNIDADMEDIDA = 0 _
            Or lEntidad.IDUNIDADMEDIDA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDUNIDADMEDIDA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_UNIDADMEDIDAS ")
        strSQL.Append(" SET DESCRIPCION = @DESCRIPCION, ")
        strSQL.Append(" DESCRIPCIONLARGA = @DESCRIPCIONLARGA, ")
        strSQL.Append(" UNIDADESCONTENIDAS = @UNIDADESCONTENIDAS, ")
        strSQL.Append(" CANTIDADDECIMAL = @CANTIDADDECIMAL, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDUNIDADMEDIDA = @IDUNIDADMEDIDA ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(0).Value = lEntidad.DESCRIPCION
        args(1) = New SqlParameter("@DESCRIPCIONLARGA", SqlDbType.VarChar)
        args(1).Value = lEntidad.DESCRIPCIONLARGA
        args(2) = New SqlParameter("@UNIDADESCONTENIDAS", SqlDbType.Int)
        args(2).Value = lEntidad.UNIDADESCONTENIDAS
        args(3) = New SqlParameter("@CANTIDADDECIMAL", SqlDbType.TinyInt)
        args(3).Value = IIf(lEntidad.CANTIDADDECIMAL = Nothing, DBNull.Value, lEntidad.CANTIDADDECIMAL)
        args(4) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(5) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(5).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(6) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(7) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(8) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(8).Value = lEntidad.ESTASINCRONIZADA
        args(9) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(9).Value = lEntidad.IDUNIDADMEDIDA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As UNIDADMEDIDAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_UNIDADMEDIDAS ")
        strSQL.Append(" ( IDUNIDADMEDIDA, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" DESCRIPCIONLARGA, ")
        strSQL.Append(" UNIDADESCONTENIDAS, ")
        strSQL.Append(" CANTIDADDECIMAL, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDUNIDADMEDIDA, ")
        strSQL.Append(" @DESCRIPCION, ")
        strSQL.Append(" @DESCRIPCIONLARGA, ")
        strSQL.Append(" @UNIDADESCONTENIDAS, ")
        strSQL.Append(" @CANTIDADDECIMAL, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(0).Value = lEntidad.IDUNIDADMEDIDA
        args(1) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(1).Value = lEntidad.DESCRIPCION
        args(2) = New SqlParameter("@DESCRIPCIONLARGA", SqlDbType.VarChar)
        args(2).Value = lEntidad.DESCRIPCIONLARGA
        args(3) = New SqlParameter("@UNIDADESCONTENIDAS", SqlDbType.Int)
        args(3).Value = lEntidad.UNIDADESCONTENIDAS
        args(4) = New SqlParameter("@CANTIDADDECIMAL", SqlDbType.TinyInt)
        args(4).Value = IIf(lEntidad.CANTIDADDECIMAL = Nothing, DBNull.Value, lEntidad.CANTIDADDECIMAL)
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

        Dim lEntidad As UNIDADMEDIDAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_UNIDADMEDIDAS ")
        strSQL.Append(" WHERE IDUNIDADMEDIDA = @IDUNIDADMEDIDA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(0).Value = lEntidad.IDUNIDADMEDIDA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As UNIDADMEDIDAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDUNIDADMEDIDA = @IDUNIDADMEDIDA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(0).Value = lEntidad.IDUNIDADMEDIDA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.DESCRIPCION = IIf(.Item("DESCRIPCION") Is DBNull.Value, Nothing, .Item("DESCRIPCION"))
                lEntidad.DESCRIPCIONLARGA = IIf(.Item("DESCRIPCIONLARGA") Is DBNull.Value, Nothing, .Item("DESCRIPCIONLARGA"))
                lEntidad.UNIDADESCONTENIDAS = IIf(.Item("UNIDADESCONTENIDAS") Is DBNull.Value, Nothing, .Item("UNIDADESCONTENIDAS"))
                lEntidad.CANTIDADDECIMAL = IIf(.Item("CANTIDADDECIMAL") Is DBNull.Value, Nothing, .Item("CANTIDADDECIMAL"))
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

        Dim lEntidad As UNIDADMEDIDAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDUNIDADMEDIDA),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_UNIDADMEDIDAS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaUNIDADMEDIDAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaUNIDADMEDIDAS

        Try
            Do While dr.Read()
                Dim mEntidad As New UNIDADMEDIDAS
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                mEntidad.DESCRIPCIONLARGA = IIf(dr("DESCRIPCIONLARGA") Is DBNull.Value, Nothing, dr("DESCRIPCIONLARGA"))
                mEntidad.UNIDADESCONTENIDAS = IIf(dr("UNIDADESCONTENIDAS") Is DBNull.Value, Nothing, dr("UNIDADESCONTENIDAS"))
                mEntidad.CANTIDADDECIMAL = IIf(dr("CANTIDADDECIMAL") Is DBNull.Value, Nothing, dr("CANTIDADDECIMAL"))
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

    Public Function ObtenerDataSetPorID() As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim tables(0) As String
        tables(0) = New String("UNIDADMEDIDAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDUNIDADMEDIDA, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" DESCRIPCIONLARGA, ")
        strSQL.Append(" UNIDADESCONTENIDAS, ")
        strSQL.Append(" CANTIDADDECIMAL, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_UNIDADMEDIDAS ")

    End Sub

#End Region

End Class
