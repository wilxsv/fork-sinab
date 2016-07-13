Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbETIQUETASCLAUSULAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_CAT_ETIQUETASCLAUSULAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbETIQUETASCLAUSULAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ETIQUETASCLAUSULAS
        lEntidad = aEntidad

        Dim lID As String
        If lEntidad.ETIQUETA = "" _
            Or lEntidad.ETIQUETA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = "" Then Return -1

            lEntidad.ETIQUETA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_ETIQUETASCLAUSULAS ")
        strSQL.Append(" SET NOMBRE = @NOMBRE, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" MODIFICATIVA = @MODIFICATIVA, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE TABLA = @TABLA ")
        strSQL.Append(" AND CAMPO = @CAMPO ")
        strSQL.Append(" AND ETIQUETA = @ETIQUETA ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(0).Value = lEntidad.NOMBRE
        args(1) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(2) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(2).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(4) = New SqlParameter("@MODIFICATIVA", SqlDbType.SmallInt)
        args(4).Value = lEntidad.MODIFICATIVA
        args(5) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(5).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(6) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(6).Value = lEntidad.ESTASINCRONIZADA
        args(7) = New SqlParameter("@TABLA", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.TABLA = Nothing, DBNull.Value, lEntidad.TABLA)
        args(8) = New SqlParameter("@CAMPO", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.CAMPO = Nothing, DBNull.Value, lEntidad.CAMPO)
        args(9) = New SqlParameter("@ETIQUETA", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.ETIQUETA = Nothing, DBNull.Value, lEntidad.ETIQUETA)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ETIQUETASCLAUSULAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_ETIQUETASCLAUSULAS ")
        strSQL.Append(" ( TABLA, ")
        strSQL.Append(" CAMPO, ")
        strSQL.Append(" ETIQUETA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" MODIFICATIVA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @TABLA, ")
        strSQL.Append(" @CAMPO, ")
        strSQL.Append(" @ETIQUETA, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA, ")
        strSQL.Append(" @MODIFICATIVA) ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@TABLA", SqlDbType.VarChar)
        args(0).Value = lEntidad.TABLA
        args(1) = New SqlParameter("@CAMPO", SqlDbType.VarChar)
        args(1).Value = lEntidad.CAMPO
        args(2) = New SqlParameter("@ETIQUETA", SqlDbType.VarChar)
        args(2).Value = lEntidad.ETIQUETA
        args(3) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(3).Value = lEntidad.NOMBRE
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
        args(9) = New SqlParameter("@MODIFICATIVA", SqlDbType.SmallInt)
        args(9).Value = lEntidad.MODIFICATIVA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ETIQUETASCLAUSULAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_ETIQUETASCLAUSULAS ")
        strSQL.Append(" WHERE TABLA = @TABLA ")
        strSQL.Append(" AND CAMPO = @CAMPO ")
        strSQL.Append(" AND ETIQUETA = @ETIQUETA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@TABLA", SqlDbType.VarChar)
        args(0).Value = lEntidad.TABLA
        args(1) = New SqlParameter("@CAMPO", SqlDbType.VarChar)
        args(1).Value = lEntidad.CAMPO
        args(2) = New SqlParameter("@ETIQUETA", SqlDbType.VarChar)
        args(2).Value = lEntidad.ETIQUETA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ETIQUETASCLAUSULAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE TABLA = @TABLA ")
        strSQL.Append(" AND CAMPO = @CAMPO ")
        strSQL.Append(" AND ETIQUETA = @ETIQUETA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@TABLA", SqlDbType.VarChar)
        args(0).Value = lEntidad.TABLA
        args(1) = New SqlParameter("@CAMPO", SqlDbType.VarChar)
        args(1).Value = lEntidad.CAMPO
        args(2) = New SqlParameter("@ETIQUETA", SqlDbType.VarChar)
        args(2).Value = lEntidad.ETIQUETA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.MODIFICATIVA = IIf(.Item("MODIFICATIVA") Is DBNull.Value, Nothing, .Item("MODIFICATIVA"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As ETIQUETASCLAUSULAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(ETIQUETA),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_ETIQUETASCLAUSULAS ")
        strSQL.Append(" WHERE TABLA = @TABLA ")
        strSQL.Append(" AND CAMPO = @CAMPO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@TABLA", SqlDbType.VarChar)
        args(0).Value = lEntidad.TABLA
        args(1) = New SqlParameter("@CAMPO", SqlDbType.VarChar)
        args(1).Value = lEntidad.CAMPO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID() As listaETIQUETASCLAUSULAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaETIQUETASCLAUSULAS

        Try
            Do While dr.Read()
                Dim mEntidad As New ETIQUETASCLAUSULAS
                mEntidad.TABLA = IIf(dr("TABLA") Is DBNull.Value, Nothing, dr("TABLA"))
                mEntidad.CAMPO = IIf(dr("CAMPO") Is DBNull.Value, Nothing, dr("CAMPO"))
                mEntidad.ETIQUETA = IIf(dr("ETIQUETA") Is DBNull.Value, Nothing, dr("ETIQUETA"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.MODIFICATIVA = IIf(dr("MODIFICATIVA") Is DBNull.Value, Nothing, dr("MODIFICATIVA"))
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
        tables(0) = New String("ETIQUETASCLAUSULAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)
        strSQL.Append(" SELECT TABLA, ")
        strSQL.Append(" CAMPO, ")
        strSQL.Append(" ETIQUETA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" MODIFICATIVA ")
        strSQL.Append(" FROM SAB_CAT_ETIQUETASCLAUSULAS ")
    End Sub

#End Region

End Class
