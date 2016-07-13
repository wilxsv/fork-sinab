Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbPLANTILLAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla PLANTILLAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbPLANTILLAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PLANTILLAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDPLANTILLA = 0 _
            Or lEntidad.IDPLANTILLA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDPLANTILLA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_PLANTILLAS ")
        strSQL.Append(" SET IDTIPOCOMPRA = @IDTIPOCOMPRA, ")
        strSQL.Append(" NOMBRE = @NOMBRE, ")
        strSQL.Append(" CODIGOFUENTE = @CODIGOFUENTE, ")
        strSQL.Append(" TIPOPLANTILLA = @TIPOPLANTILLA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPLANTILLA = @IDPLANTILLA ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOCOMPRA", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOCOMPRA
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@CODIGOFUENTE", SqlDbType.VarChar)
        args(2).Value = lEntidad.CODIGOFUENTE
        args(3) = New SqlParameter("@TIPOPLANTILLA", SqlDbType.TinyInt)
        args(3).Value = IIf(lEntidad.TIPOPLANTILLA = Nothing, DBNull.Value, lEntidad.TIPOPLANTILLA)
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
        args(9) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(9).Value = lEntidad.IDPLANTILLA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PLANTILLAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_PLANTILLAS ")
        strSQL.Append(" ( IDPLANTILLA, ")
        strSQL.Append(" IDTIPOCOMPRA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" CODIGOFUENTE, ")
        strSQL.Append(" TIPOPLANTILLA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDPLANTILLA, ")
        strSQL.Append(" @IDTIPOCOMPRA, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @CODIGOFUENTE, ")
        strSQL.Append(" @TIPOPLANTILLA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(0).Value = lEntidad.IDPLANTILLA
        args(1) = New SqlParameter("@IDTIPOCOMPRA", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOCOMPRA
        args(2) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(2).Value = lEntidad.NOMBRE
        args(3) = New SqlParameter("@CODIGOFUENTE", SqlDbType.VarChar)
        args(3).Value = lEntidad.CODIGOFUENTE
        args(4) = New SqlParameter("@TIPOPLANTILLA", SqlDbType.TinyInt)
        args(4).Value = IIf(lEntidad.TIPOPLANTILLA = Nothing, DBNull.Value, lEntidad.TIPOPLANTILLA)
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

        Dim lEntidad As PLANTILLAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_PLANTILLAS ")
        strSQL.Append(" WHERE IDPLANTILLA = @IDPLANTILLA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(0).Value = lEntidad.IDPLANTILLA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PLANTILLAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPLANTILLA = @IDPLANTILLA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(0).Value = lEntidad.IDPLANTILLA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDTIPOCOMPRA = IIf(.Item("IDTIPOCOMPRA") Is DBNull.Value, Nothing, .Item("IDTIPOCOMPRA"))
                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                lEntidad.CODIGOFUENTE = IIf(.Item("CODIGOFUENTE") Is DBNull.Value, Nothing, .Item("CODIGOFUENTE"))
                lEntidad.TIPOPLANTILLA = IIf(.Item("TIPOPLANTILLA") Is DBNull.Value, Nothing, .Item("TIPOPLANTILLA"))
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

        Dim lEntidad As PLANTILLAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDPLANTILLA),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_PLANTILLAS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID(ByVal IDTIPOCOMPRA As Integer) As listaPLANTILLAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDTIPOCOMPRA = @IDTIPOCOMPRA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOCOMPRA", SqlDbType.Int)
        args(0).Value = IDTIPOCOMPRA

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaPLANTILLAS

        Try
            Do While dr.Read()
                Dim mEntidad As New PLANTILLAS
                mEntidad.IDPLANTILLA = IIf(dr("IDPLANTILLA") Is DBNull.Value, Nothing, dr("IDPLANTILLA"))
                mEntidad.IDTIPOCOMPRA = IIf(dr("IDTIPOCOMPRA") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRA"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.CODIGOFUENTE = IIf(dr("CODIGOFUENTE") Is DBNull.Value, Nothing, dr("CODIGOFUENTE"))
                mEntidad.TIPOPLANTILLA = IIf(dr("TIPOPLANTILLA") Is DBNull.Value, Nothing, dr("TIPOPLANTILLA"))
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
        tables(0) = New String("PLANTILLAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDPLANTILLA, ")
        strSQL.Append(" IDTIPOCOMPRA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" CODIGOFUENTE, ")
        strSQL.Append(" TIPOPLANTILLA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_PLANTILLAS ")

    End Sub

#End Region

End Class
