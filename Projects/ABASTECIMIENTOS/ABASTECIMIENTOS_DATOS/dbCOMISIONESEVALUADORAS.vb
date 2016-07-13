Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbCOMISIONESEVALUADORAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_COMISIONESEVALUADORAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	05/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbCOMISIONESEVALUADORAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As COMISIONESEVALUADORAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDCOMISION = 0 _
            Or lEntidad.IDCOMISION = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDCOMISION = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_COMISIONESEVALUADORAS ")
        strSQL.Append(" SET NOMBRE = @NOMBRE, ")
        strSQL.Append(" FECHACREACION = @FECHACREACION, ")
        strSQL.Append(" ESTADO = @ESTADO, ")
        strSQL.Append(" ESALTONIVEL = @ESALTONIVEL, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDCOMISION = @IDCOMISION ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(0).Value = lEntidad.NOMBRE
        args(1) = New SqlParameter("@FECHACREACION", SqlDbType.DateTime)
        args(1).Value = lEntidad.FECHACREACION
        args(2) = New SqlParameter("@ESTADO", SqlDbType.SmallInt)
        args(2).Value = lEntidad.ESTADO
        args(3) = New SqlParameter("@ESALTONIVEL", SqlDbType.SmallInt)
        args(3).Value = lEntidad.ESALTONIVEL
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
        args(9) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(9).Value = lEntidad.IDESTABLECIMIENTO
        args(10) = New SqlParameter("@IDCOMISION", SqlDbType.BigInt)
        args(10).Value = lEntidad.IDCOMISION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ActualizarAN(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As COMISIONESEVALUADORAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDCOMISION = 0 _
            Or lEntidad.IDCOMISION = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDCOMISION = lID

            Return AgregarAN(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_COMISIONESEVALUADORAS ")
        strSQL.Append(" SET NOMBRE = @NOMBRE, ")
        strSQL.Append(" FECHACREACION = @FECHACREACION, ")
        strSQL.Append(" ESTADO = @ESTADO, ")
        strSQL.Append(" ESALTONIVEL = @ESALTONIVEL, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDCOMISION = @IDCOMISION ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(0).Value = lEntidad.NOMBRE
        args(1) = New SqlParameter("@FECHACREACION", SqlDbType.DateTime)
        args(1).Value = lEntidad.FECHACREACION
        args(2) = New SqlParameter("@ESTADO", SqlDbType.SmallInt)
        args(2).Value = lEntidad.ESTADO
        args(3) = New SqlParameter("@ESALTONIVEL", SqlDbType.SmallInt)
        args(3).Value = lEntidad.ESALTONIVEL
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
        args(9) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(9).Value = lEntidad.IDESTABLECIMIENTO
        args(10) = New SqlParameter("@IDCOMISION", SqlDbType.BigInt)
        args(10).Value = lEntidad.IDCOMISION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As COMISIONESEVALUADORAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_COMISIONESEVALUADORAS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCOMISION, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" FECHACREACION, ")
        strSQL.Append(" ESTADO, ")
        strSQL.Append(" ESALTONIVEL, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, NUMRESOLUCION, FECHARESOLUCION) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDCOMISION, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @FECHACREACION, ")
        strSQL.Append(" @ESTADO, ")
        strSQL.Append(" @ESALTONIVEL, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA, @NUMRESOLUCION,@FECHARESOLUCION) ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCOMISION", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDCOMISION
        args(2) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(2).Value = lEntidad.NOMBRE
        args(3) = New SqlParameter("@FECHACREACION", SqlDbType.DateTime)
        args(3).Value = lEntidad.FECHACREACION
        args(4) = New SqlParameter("@ESTADO", SqlDbType.SmallInt)
        args(4).Value = lEntidad.ESTADO
        args(5) = New SqlParameter("@ESALTONIVEL", SqlDbType.SmallInt)
        args(5).Value = lEntidad.ESALTONIVEL
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(10) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(10).Value = lEntidad.ESTASINCRONIZADA
        args(11) = New SqlParameter("@NUMRESOLUCION", SqlDbType.VarChar)
        args(11).Value = lEntidad.NUMRESOLUCION
        args(12) = New SqlParameter("@FECHARESOLUCION", SqlDbType.DateTime)
        args(12).Value = lEntidad.FECHARESOLUCION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function AgregarAN(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As COMISIONESEVALUADORAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_COMISIONESEVALUADORAS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCOMISION, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" FECHACREACION, ")
        strSQL.Append(" ESTADO, ")
        strSQL.Append(" ESALTONIVEL, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, NUMRESOLUCION, FECHARESOLUCION) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDCOMISION, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @FECHACREACION, ")
        strSQL.Append(" @ESTADO, ")
        strSQL.Append(" @ESALTONIVEL, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA, 0,@FECHACREACION) ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCOMISION", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDCOMISION
        args(2) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(2).Value = lEntidad.NOMBRE
        args(3) = New SqlParameter("@FECHACREACION", SqlDbType.DateTime)
        args(3).Value = lEntidad.FECHACREACION
        args(4) = New SqlParameter("@ESTADO", SqlDbType.SmallInt)
        args(4).Value = lEntidad.ESTADO
        args(5) = New SqlParameter("@ESALTONIVEL", SqlDbType.SmallInt)
        args(5).Value = lEntidad.ESALTONIVEL
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(10) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(10).Value = lEntidad.ESTASINCRONIZADA
        'args(11) = New SqlParameter("@NUMRESOLUCION", SqlDbType.SmallInt)
        'args(11).Value = lEntidad.NUMRESOLUCION
        'args(12) = New SqlParameter("@FECHARESOLUCION", SqlDbType.DateTime)
        'args(12).Value = lEntidad.FECHACREACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As COMISIONESEVALUADORAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_COMISIONESEVALUADORAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCOMISION = @IDCOMISION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCOMISION", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDCOMISION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As COMISIONESEVALUADORAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCOMISION = @IDCOMISION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCOMISION", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDCOMISION

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                lEntidad.FECHACREACION = IIf(.Item("FECHACREACION") Is DBNull.Value, Nothing, .Item("FECHACREACION"))
                lEntidad.ESTADO = IIf(.Item("ESTADO") Is DBNull.Value, Nothing, .Item("ESTADO"))
                lEntidad.ESALTONIVEL = IIf(.Item("ESALTONIVEL") Is DBNull.Value, Nothing, .Item("ESALTONIVEL"))
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

        Dim lEntidad As COMISIONESEVALUADORAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDCOMISION),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_COMISIONESEVALUADORAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32) As listaCOMISIONESEVALUADORAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaCOMISIONESEVALUADORAS

        Try
            Do While dr.Read()
                Dim mEntidad As New COMISIONESEVALUADORAS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDCOMISION = IIf(dr("IDCOMISION") Is DBNull.Value, Nothing, dr("IDCOMISION"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.FECHACREACION = IIf(dr("FECHACREACION") Is DBNull.Value, Nothing, dr("FECHACREACION"))
                mEntidad.ESTADO = IIf(dr("ESTADO") Is DBNull.Value, Nothing, dr("ESTADO"))
                mEntidad.ESALTONIVEL = IIf(dr("ESALTONIVEL") Is DBNull.Value, Nothing, dr("ESALTONIVEL"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim tables(0) As String
        tables(0) = New String("COMISIONESEVALUADORAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCOMISION, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" FECHACREACION, ")
        strSQL.Append(" ESTADO, ")
        strSQL.Append(" ESALTONIVEL, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_COMISIONESEVALUADORAS ")

    End Sub

#End Region

End Class