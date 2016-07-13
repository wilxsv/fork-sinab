Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbOBSERVACIONDETALLENECESIDAD
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla OBSERVACIONDETALLENECESIDAD
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbOBSERVACIONDETALLENECESIDAD
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OBSERVACIONDETALLENECESIDAD
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDOBSERVACION = 0 _
            Or lEntidad.IDOBSERVACION = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDOBSERVACION = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UTMIM_OBSERVACIONDETALLENECESIDAD ")
        strSQL.Append(" SET IDASESORIA = @IDASESORIA, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" FECHA = @FECHA, ")
        strSQL.Append(" CANTIDADACTUAL = @CANTIDADACTUAL, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDOBSERVACION = @IDOBSERVACION ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDASESORIA", SqlDbType.SmallInt)
        args(0).Value = IIf(lEntidad.IDASESORIA = Nothing, DBNull.Value, lEntidad.IDASESORIA)
        args(1) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(1).Value = lEntidad.OBSERVACION
        args(2) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(2).Value = lEntidad.FECHA
        args(3) = New SqlParameter("@CANTIDADACTUAL", SqlDbType.BigInt)
        args(3).Value = lEntidad.CANTIDADACTUAL
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
        args(10) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(10).Value = lEntidad.IDNECESIDAD
        args(11) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(11).Value = lEntidad.IDPRODUCTO
        args(12) = New SqlParameter("@IDOBSERVACION", SqlDbType.BigInt)
        args(12).Value = lEntidad.IDOBSERVACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OBSERVACIONDETALLENECESIDAD
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UTMIM_OBSERVACIONDETALLENECESIDAD ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDNECESIDAD, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDOBSERVACION, ")
        strSQL.Append(" IDASESORIA, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" FECHA, ")
        strSQL.Append(" CANTIDADACTUAL, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDNECESIDAD, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @IDOBSERVACION, ")
        strSQL.Append(" @IDASESORIA, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @FECHA, ")
        strSQL.Append(" @CANTIDADACTUAL, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDOBSERVACION", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDOBSERVACION
        args(4) = New SqlParameter("@IDASESORIA", SqlDbType.SmallInt)
        args(4).Value = IIf(lEntidad.IDASESORIA = Nothing, DBNull.Value, lEntidad.IDASESORIA)
        args(5) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(5).Value = lEntidad.OBSERVACION
        args(6) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(6).Value = lEntidad.FECHA
        args(7) = New SqlParameter("@CANTIDADACTUAL", SqlDbType.BigInt)
        args(7).Value = lEntidad.CANTIDADACTUAL
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

        Dim lEntidad As OBSERVACIONDETALLENECESIDAD
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UTMIM_OBSERVACIONDETALLENECESIDAD ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDOBSERVACION = @IDOBSERVACION ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDOBSERVACION", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDOBSERVACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OBSERVACIONDETALLENECESIDAD
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" AND IDOBSERVACION = @IDOBSERVACION ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDOBSERVACION", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDOBSERVACION

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDASESORIA = IIf(.Item("IDASESORIA") Is DBNull.Value, Nothing, .Item("IDASESORIA"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
                lEntidad.FECHA = IIf(.Item("FECHA") Is DBNull.Value, Nothing, .Item("FECHA"))
                lEntidad.CANTIDADACTUAL = IIf(.Item("CANTIDADACTUAL") Is DBNull.Value, Nothing, .Item("CANTIDADACTUAL"))
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

        Dim lEntidad As OBSERVACIONDETALLENECESIDAD
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDOBSERVACION),0) + 1 ")
        strSQL.Append(" FROM SAB_UTMIM_OBSERVACIONDETALLENECESIDAD ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64) As listaOBSERVACIONDETALLENECESIDAD

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaOBSERVACIONDETALLENECESIDAD

        Try
            Do While dr.Read()
                Dim mEntidad As New OBSERVACIONDETALLENECESIDAD
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDNECESIDAD = IDNECESIDAD
                mEntidad.IDPRODUCTO = IDPRODUCTO
                mEntidad.IDOBSERVACION = IIf(dr("IDOBSERVACION") Is DBNull.Value, Nothing, dr("IDOBSERVACION"))
                mEntidad.IDASESORIA = IIf(dr("IDASESORIA") Is DBNull.Value, Nothing, dr("IDASESORIA"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.FECHA = IIf(dr("FECHA") Is DBNull.Value, Nothing, dr("FECHA"))
                mEntidad.CANTIDADACTUAL = IIf(dr("CANTIDADACTUAL") Is DBNull.Value, Nothing, dr("CANTIDADACTUAL"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = IDNECESIDAD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = IDPRODUCTO

        Dim tables(0) As String
        tables(0) = New String("OBSERVACIONDETALLENECESIDAD")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDNECESIDAD, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDOBSERVACION, ")
        strSQL.Append(" IDASESORIA, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" FECHA, ")
        strSQL.Append(" CANTIDADACTUAL, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UTMIM_OBSERVACIONDETALLENECESIDAD ")

    End Sub

#End Region

End Class
