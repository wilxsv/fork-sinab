Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbFUENTEFINANCIAMIENTOSOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla FUENTEFINANCIAMIENTOSOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbFUENTEFINANCIAMIENTOSOLICITUDES
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As FUENTEFINANCIAMIENTOSOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append(" SET MONTOPARTICIPACION = @MONTOPARTICIPACION, ")
        strSQL.Append(" PORCENTAJEPARTICIPACION = @PORCENTAJEPARTICIPACION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@MONTOPARTICIPACION", SqlDbType.Decimal)
        args(0).Value = lEntidad.MONTOPARTICIPACION
        args(1) = New SqlParameter("@PORCENTAJEPARTICIPACION", SqlDbType.Decimal)
        args(1).Value = lEntidad.PORCENTAJEPARTICIPACION
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
        args(7) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(7).Value = lEntidad.IDESTABLECIMIENTO
        args(8) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(8).Value = lEntidad.IDSOLICITUD
        args(9) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(9).Value = lEntidad.IDFUENTEFINANCIAMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As FUENTEFINANCIAMIENTOSOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" MONTOPARTICIPACION, ")
        strSQL.Append(" PORCENTAJEPARTICIPACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDSOLICITUD, ")
        strSQL.Append(" @IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" @MONTOPARTICIPACION, ")
        strSQL.Append(" @PORCENTAJEPARTICIPACION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Value = lEntidad.IDFUENTEFINANCIAMIENTO
        args(3) = New SqlParameter("@MONTOPARTICIPACION", SqlDbType.Decimal)
        args(3).Value = lEntidad.MONTOPARTICIPACION
        args(4) = New SqlParameter("@PORCENTAJEPARTICIPACION", SqlDbType.Decimal)
        args(4).Value = lEntidad.PORCENTAJEPARTICIPACION
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

        Dim lEntidad As FUENTEFINANCIAMIENTOSOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Value = lEntidad.IDFUENTEFINANCIAMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As FUENTEFINANCIAMIENTOSOLICITUDES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Value = lEntidad.IDFUENTEFINANCIAMIENTO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.MONTOPARTICIPACION = IIf(.Item("MONTOPARTICIPACION") Is DBNull.Value, Nothing, .Item("MONTOPARTICIPACION"))
                lEntidad.PORCENTAJEPARTICIPACION = IIf(.Item("PORCENTAJEPARTICIPACION") Is DBNull.Value, Nothing, .Item("PORCENTAJEPARTICIPACION"))
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

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32) As listaFUENTEFINANCIAMIENTOSOLICITUDES

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Value = IDFUENTEFINANCIAMIENTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaFUENTEFINANCIAMIENTOSOLICITUDES

        Try
            Do While dr.Read()
                Dim mEntidad As New FUENTEFINANCIAMIENTOSOLICITUDES
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDSOLICITUD = IDSOLICITUD
                mEntidad.IDFUENTEFINANCIAMIENTO = IDFUENTEFINANCIAMIENTO
                mEntidad.MONTOPARTICIPACION = IIf(dr("MONTOPARTICIPACION") Is DBNull.Value, Nothing, dr("MONTOPARTICIPACION"))
                mEntidad.PORCENTAJEPARTICIPACION = IIf(dr("PORCENTAJEPARTICIPACION") Is DBNull.Value, Nothing, dr("PORCENTAJEPARTICIPACION"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Value = IDFUENTEFINANCIAMIENTO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Value = IDFUENTEFINANCIAMIENTO

        Dim tables(0) As String
        tables(0) = New String("FUENTEFINANCIAMIENTOSOLICITUDES")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" MONTOPARTICIPACION, ")
        strSQL.Append(" PORCENTAJEPARTICIPACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")

    End Sub

#End Region

End Class
