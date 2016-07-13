Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbRECETAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla RECETAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbRECETAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RECETAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDRECETA = 0 _
            Or lEntidad.IDRECETA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDRECETA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_EST_RECETAS ")
        strSQL.Append(" SET NUMERORECETA = @NUMERORECETA, ")
        strSQL.Append(" IDSERVICIOHOSPITALARIO = @IDSERVICIOHOSPITALARIO, ")
        strSQL.Append(" FECHARECETA = @FECHARECETA, ")
        strSQL.Append(" MEDICO = @MEDICO, ")
        strSQL.Append(" DESPACHADO = @DESPACHADO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")
        strSQL.Append(" AND IDRECETA = @IDRECETA ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@NUMERORECETA", SqlDbType.VarChar)
        args(0).Value = lEntidad.NUMERORECETA
        args(1) = New SqlParameter("@IDSERVICIOHOSPITALARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDSERVICIOHOSPITALARIO
        args(2) = New SqlParameter("@FECHARECETA", SqlDbType.DateTime)
        args(2).Value = IIf(lEntidad.FECHARECETA = Nothing, DBNull.Value, lEntidad.FECHARECETA)
        args(3) = New SqlParameter("@MEDICO", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.MEDICO = Nothing, DBNull.Value, lEntidad.MEDICO)
        args(4) = New SqlParameter("@DESPACHADO", SqlDbType.TinyInt)
        args(4).Value = IIf(lEntidad.DESPACHADO = Nothing, DBNull.Value, lEntidad.DESPACHADO)
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
        args(10) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(10).Value = lEntidad.IDESTABLECIMIENTO
        args(11) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(11).Value = lEntidad.IDCARGA
        args(12) = New SqlParameter("@IDRECETA", SqlDbType.Int)
        args(12).Value = lEntidad.IDRECETA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RECETAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_RECETAS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCARGA, ")
        strSQL.Append(" IDRECETA, ")
        strSQL.Append(" NUMERORECETA, ")
        strSQL.Append(" IDSERVICIOHOSPITALARIO, ")
        strSQL.Append(" FECHARECETA, ")
        strSQL.Append(" MEDICO, ")
        strSQL.Append(" DESPACHADO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDCARGA, ")
        strSQL.Append(" @IDRECETA, ")
        strSQL.Append(" @NUMERORECETA, ")
        strSQL.Append(" @IDSERVICIOHOSPITALARIO, ")
        strSQL.Append(" @FECHARECETA, ")
        strSQL.Append(" @MEDICO, ")
        strSQL.Append(" @DESPACHADO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = lEntidad.IDCARGA
        args(2) = New SqlParameter("@IDRECETA", SqlDbType.Int)
        args(2).Value = lEntidad.IDRECETA
        args(3) = New SqlParameter("@NUMERORECETA", SqlDbType.VarChar)
        args(3).Value = lEntidad.NUMERORECETA
        args(4) = New SqlParameter("@IDSERVICIOHOSPITALARIO", SqlDbType.Int)
        args(4).Value = lEntidad.IDSERVICIOHOSPITALARIO
        args(5) = New SqlParameter("@FECHARECETA", SqlDbType.DateTime)
        args(5).Value = IIf(lEntidad.FECHARECETA = Nothing, DBNull.Value, lEntidad.FECHARECETA)
        args(6) = New SqlParameter("@MEDICO", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.MEDICO = Nothing, DBNull.Value, lEntidad.MEDICO)
        args(7) = New SqlParameter("@DESPACHADO", SqlDbType.TinyInt)
        args(7).Value = IIf(lEntidad.DESPACHADO = Nothing, DBNull.Value, lEntidad.DESPACHADO)
        args(8) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(9) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(10) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(11) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(12) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(12).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RECETAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_RECETAS ")
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RECETAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
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

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.NUMERORECETA = IIf(.Item("NUMERORECETA") Is DBNull.Value, Nothing, .Item("NUMERORECETA"))
                lEntidad.IDSERVICIOHOSPITALARIO = IIf(.Item("IDSERVICIOHOSPITALARIO") Is DBNull.Value, Nothing, .Item("IDSERVICIOHOSPITALARIO"))
                lEntidad.FECHARECETA = IIf(.Item("FECHARECETA") Is DBNull.Value, Nothing, .Item("FECHARECETA"))
                lEntidad.MEDICO = IIf(.Item("MEDICO") Is DBNull.Value, Nothing, .Item("MEDICO"))
                lEntidad.DESPACHADO = IIf(.Item("DESPACHADO") Is DBNull.Value, Nothing, .Item("DESPACHADO"))
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

        Dim lEntidad As RECETAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDRECETA),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_RECETAS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = lEntidad.IDCARGA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCARGA As Int32) As listaRECETAS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = IDCARGA

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaRECETAS

        Try
            Do While dr.Read()
                Dim mEntidad As New RECETAS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDCARGA = IDCARGA
                mEntidad.IDRECETA = IIf(dr("IDRECETA") Is DBNull.Value, Nothing, dr("IDRECETA"))
                mEntidad.NUMERORECETA = IIf(dr("NUMERORECETA") Is DBNull.Value, Nothing, dr("NUMERORECETA"))
                mEntidad.IDSERVICIOHOSPITALARIO = IIf(dr("IDSERVICIOHOSPITALARIO") Is DBNull.Value, Nothing, dr("IDSERVICIOHOSPITALARIO"))
                mEntidad.FECHARECETA = IIf(dr("FECHARECETA") Is DBNull.Value, Nothing, dr("FECHARECETA"))
                mEntidad.MEDICO = IIf(dr("MEDICO") Is DBNull.Value, Nothing, dr("MEDICO"))
                mEntidad.DESPACHADO = IIf(dr("DESPACHADO") Is DBNull.Value, Nothing, dr("DESPACHADO"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCARGA As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = IDCARGA

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCARGA As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDCARGA = @IDCARGA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCARGA", SqlDbType.Int)
        args(1).Value = IDCARGA

        Dim tables(0) As String
        tables(0) = New String("RECETAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDCARGA, ")
        strSQL.Append(" IDRECETA, ")
        strSQL.Append(" NUMERORECETA, ")
        strSQL.Append(" IDSERVICIOHOSPITALARIO, ")
        strSQL.Append(" FECHARECETA, ")
        strSQL.Append(" MEDICO, ")
        strSQL.Append(" DESPACHADO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_RECETAS ")

    End Sub

#End Region

End Class
