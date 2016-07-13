Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbNECESIDADESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla NECESIDADESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbNECESIDADESTABLECIMIENTOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NECESIDADESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDNECESIDAD = 0 _
            Or lEntidad.IDNECESIDAD = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDNECESIDAD = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" SET PROPUESTA = @PROPUESTA, ")
        strSQL.Append(" CORRELATIVO = @CORRELATIVO, ")
        strSQL.Append(" IDESTADO = @IDESTADO, ")
        strSQL.Append(" FECHAELABORACION = @FECHAELABORACION, ")
        strSQL.Append(" PERIODOUTILIZACION = @PERIODOUTILIZACION, ")
        strSQL.Append(" MESINICIOPERIODO = @MESINICIOPERIODO, ")
        strSQL.Append(" ANIOINICIOPERIODO = @ANIOINICIOPERIODO, ")
        strSQL.Append(" MESFINPERIODO = @MESFINPERIODO, ")
        strSQL.Append(" ANIOFINPERIODO = @ANIOFINPERIODO, ")
        strSQL.Append(" IDEMPLEADO = @IDEMPLEADO, ")
        strSQL.Append(" IDALMACENENTREGA = @IDALMACENENTREGA, ")
        strSQL.Append(" IDSUMINISTRO = @IDSUMINISTRO, ")
        strSQL.Append(" PRESUPUESTOASIGNADO = @PRESUPUESTOASIGNADO, ")
        strSQL.Append(" MONTONECESIDADREAL = @MONTONECESIDADREAL, ")
        strSQL.Append(" MONTONECESIDADAJUSTADA = @MONTONECESIDADAJUSTADA, ")
        strSQL.Append(" MONTONECESIDADFINAL = @MONTONECESIDADFINAL, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDNECESIDAD = @IDNECESIDAD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(23) As SqlParameter
        args(0) = New SqlParameter("@PROPUESTA", SqlDbType.TinyInt)
        args(0).Value = lEntidad.PROPUESTA
        args(1) = New SqlParameter("@CORRELATIVO", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.CORRELATIVO = Nothing, DBNull.Value, lEntidad.CORRELATIVO)
        args(2) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(2).Value = IIf(lEntidad.IDESTADO = Nothing, DBNull.Value, lEntidad.IDESTADO)
        args(3) = New SqlParameter("@FECHAELABORACION", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.FECHAELABORACION = Nothing, DBNull.Value, lEntidad.FECHAELABORACION)
        args(4) = New SqlParameter("@PERIODOUTILIZACION", SqlDbType.SmallInt)
        args(4).Value = IIf(lEntidad.PERIODOUTILIZACION = Nothing, DBNull.Value, lEntidad.PERIODOUTILIZACION)
        args(5) = New SqlParameter("@MESINICIOPERIODO", SqlDbType.SmallInt)
        args(5).Value = IIf(lEntidad.MESINICIOPERIODO = Nothing, DBNull.Value, lEntidad.MESINICIOPERIODO)
        args(6) = New SqlParameter("@ANIOINICIOPERIODO", SqlDbType.SmallInt)
        args(6).Value = IIf(lEntidad.ANIOINICIOPERIODO = Nothing, DBNull.Value, lEntidad.ANIOINICIOPERIODO)
        args(7) = New SqlParameter("@MESFINPERIODO", SqlDbType.SmallInt)
        args(7).Value = IIf(lEntidad.MESFINPERIODO = Nothing, DBNull.Value, lEntidad.MESFINPERIODO)
        args(8) = New SqlParameter("@ANIOFINPERIODO", SqlDbType.SmallInt)
        args(8).Value = IIf(lEntidad.ANIOFINPERIODO = Nothing, DBNull.Value, lEntidad.ANIOFINPERIODO)
        args(9) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(9).Value = IIf(lEntidad.IDEMPLEADO = Nothing, DBNull.Value, lEntidad.IDEMPLEADO)
        args(10) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(10).Value = IIf(lEntidad.IDALMACENENTREGA = Nothing, DBNull.Value, lEntidad.IDALMACENENTREGA)
        args(11) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(11).Value = IIf(lEntidad.IDSUMINISTRO = Nothing, DBNull.Value, lEntidad.IDSUMINISTRO)
        args(12) = New SqlParameter("@PRESUPUESTOASIGNADO", SqlDbType.Decimal)
        args(12).Value = lEntidad.PRESUPUESTOASIGNADO
        args(13) = New SqlParameter("@MONTONECESIDADREAL", SqlDbType.Decimal)
        args(13).Value = lEntidad.MONTONECESIDADREAL
        args(14) = New SqlParameter("@MONTONECESIDADAJUSTADA", SqlDbType.Decimal)
        args(14).Value = lEntidad.MONTONECESIDADAJUSTADA
        args(15) = New SqlParameter("@MONTONECESIDADFINAL", SqlDbType.Decimal)
        args(15).Value = lEntidad.MONTONECESIDADFINAL
        args(16) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(17) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(18) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(19) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(19).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(20) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(20).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(21) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(21).Value = lEntidad.ESTASINCRONIZADA
        args(22) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(22).Value = lEntidad.IDESTABLECIMIENTO
        args(23) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(23).Value = lEntidad.IDNECESIDAD

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NECESIDADESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDNECESIDAD, ")
        strSQL.Append(" PROPUESTA, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" IDESTADO, ")
        strSQL.Append(" FECHAELABORACION, ")
        strSQL.Append(" PERIODOUTILIZACION, ")
        strSQL.Append(" MESINICIOPERIODO, ")
        strSQL.Append(" ANIOINICIOPERIODO, ")
        strSQL.Append(" MESFINPERIODO, ")
        strSQL.Append(" ANIOFINPERIODO, ")
        strSQL.Append(" IDEMPLEADO, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" IDSUMINISTRO, ")
        strSQL.Append(" PRESUPUESTOASIGNADO, ")
        strSQL.Append(" MONTONECESIDADREAL, ")
        strSQL.Append(" MONTONECESIDADAJUSTADA, ")
        strSQL.Append(" MONTONECESIDADFINAL, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDNECESIDAD, ")
        strSQL.Append(" @PROPUESTA, ")
        strSQL.Append(" @CORRELATIVO, ")
        strSQL.Append(" @IDESTADO, ")
        strSQL.Append(" @FECHAELABORACION, ")
        strSQL.Append(" @PERIODOUTILIZACION, ")
        strSQL.Append(" @MESINICIOPERIODO, ")
        strSQL.Append(" @ANIOINICIOPERIODO, ")
        strSQL.Append(" @MESFINPERIODO, ")
        strSQL.Append(" @ANIOFINPERIODO, ")
        strSQL.Append(" @IDEMPLEADO, ")
        strSQL.Append(" @IDALMACENENTREGA, ")
        strSQL.Append(" @IDSUMINISTRO, ")
        strSQL.Append(" @PRESUPUESTOASIGNADO, ")
        strSQL.Append(" @MONTONECESIDADREAL, ")
        strSQL.Append(" @MONTONECESIDADAJUSTADA, ")
        strSQL.Append(" @MONTONECESIDADFINAL, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(23) As SqlParameter
        args(0) = New SqlParameter("@PROPUESTA", SqlDbType.TinyInt)
        args(0).Value = lEntidad.PROPUESTA
        args(1) = New SqlParameter("@CORRELATIVO", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.CORRELATIVO = Nothing, DBNull.Value, lEntidad.CORRELATIVO)
        args(2) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(2).Value = IIf(lEntidad.IDESTADO = Nothing, DBNull.Value, lEntidad.IDESTADO)
        args(3) = New SqlParameter("@FECHAELABORACION", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.FECHAELABORACION = Nothing, DBNull.Value, lEntidad.FECHAELABORACION)
        args(4) = New SqlParameter("@PERIODOUTILIZACION", SqlDbType.SmallInt)
        args(4).Value = IIf(lEntidad.PERIODOUTILIZACION = Nothing, DBNull.Value, lEntidad.PERIODOUTILIZACION)
        args(5) = New SqlParameter("@MESINICIOPERIODO", SqlDbType.SmallInt)
        args(5).Value = IIf(lEntidad.MESINICIOPERIODO = Nothing, DBNull.Value, lEntidad.MESINICIOPERIODO)
        args(6) = New SqlParameter("@ANIOINICIOPERIODO", SqlDbType.SmallInt)
        args(6).Value = IIf(lEntidad.ANIOINICIOPERIODO = Nothing, DBNull.Value, lEntidad.ANIOINICIOPERIODO)
        args(7) = New SqlParameter("@MESFINPERIODO", SqlDbType.SmallInt)
        args(7).Value = IIf(lEntidad.MESFINPERIODO = Nothing, DBNull.Value, lEntidad.MESFINPERIODO)
        args(8) = New SqlParameter("@ANIOFINPERIODO", SqlDbType.SmallInt)
        args(8).Value = IIf(lEntidad.ANIOFINPERIODO = Nothing, DBNull.Value, lEntidad.ANIOFINPERIODO)
        args(9) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(9).Value = IIf(lEntidad.IDEMPLEADO = Nothing, DBNull.Value, lEntidad.IDEMPLEADO)
        args(10) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(10).Value = IIf(lEntidad.IDALMACENENTREGA = Nothing, DBNull.Value, lEntidad.IDALMACENENTREGA)
        args(11) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(11).Value = IIf(lEntidad.IDSUMINISTRO = Nothing, DBNull.Value, lEntidad.IDSUMINISTRO)
        args(12) = New SqlParameter("@PRESUPUESTOASIGNADO", SqlDbType.Decimal)
        args(12).Value = lEntidad.PRESUPUESTOASIGNADO
        args(13) = New SqlParameter("@MONTONECESIDADREAL", SqlDbType.Decimal)
        args(13).Value = lEntidad.MONTONECESIDADREAL
        args(14) = New SqlParameter("@MONTONECESIDADAJUSTADA", SqlDbType.Decimal)
        args(14).Value = lEntidad.MONTONECESIDADAJUSTADA
        args(15) = New SqlParameter("@MONTONECESIDADFINAL", SqlDbType.Decimal)
        args(15).Value = lEntidad.MONTONECESIDADFINAL
        args(16) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(17) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(18) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(19) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(19).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(20) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(20).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(21) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(21).Value = lEntidad.ESTASINCRONIZADA
        args(22) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(22).Value = lEntidad.IDESTABLECIMIENTO
        args(23) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(23).Value = lEntidad.IDNECESIDAD

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NECESIDADESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDNECESIDAD

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NECESIDADESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDNECESIDAD = @IDNECESIDAD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDNECESIDAD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDNECESIDAD

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.PROPUESTA = IIf(.Item("PROPUESTA") Is DBNull.Value, Nothing, .Item("PROPUESTA"))
                lEntidad.CORRELATIVO = IIf(.Item("CORRELATIVO") Is DBNull.Value, Nothing, .Item("CORRELATIVO"))
                lEntidad.IDESTADO = IIf(.Item("IDESTADO") Is DBNull.Value, Nothing, .Item("IDESTADO"))
                lEntidad.FECHAELABORACION = IIf(.Item("FECHAELABORACION") Is DBNull.Value, Nothing, .Item("FECHAELABORACION"))
                lEntidad.PERIODOUTILIZACION = IIf(.Item("PERIODOUTILIZACION") Is DBNull.Value, Nothing, .Item("PERIODOUTILIZACION"))
                lEntidad.MESINICIOPERIODO = IIf(.Item("MESINICIOPERIODO") Is DBNull.Value, Nothing, .Item("MESINICIOPERIODO"))
                lEntidad.ANIOINICIOPERIODO = IIf(.Item("ANIOINICIOPERIODO") Is DBNull.Value, Nothing, .Item("ANIOINICIOPERIODO"))
                lEntidad.MESFINPERIODO = IIf(.Item("MESFINPERIODO") Is DBNull.Value, Nothing, .Item("MESFINPERIODO"))
                lEntidad.ANIOFINPERIODO = IIf(.Item("ANIOFINPERIODO") Is DBNull.Value, Nothing, .Item("ANIOFINPERIODO"))
                lEntidad.IDEMPLEADO = IIf(.Item("IDEMPLEADO") Is DBNull.Value, Nothing, .Item("IDEMPLEADO"))
                lEntidad.IDALMACENENTREGA = IIf(.Item("IDALMACENENTREGA") Is DBNull.Value, Nothing, .Item("IDALMACENENTREGA"))
                lEntidad.IDSUMINISTRO = IIf(.Item("IDSUMINISTRO") Is DBNull.Value, Nothing, .Item("IDSUMINISTRO"))
                lEntidad.PRESUPUESTOASIGNADO = IIf(.Item("PRESUPUESTOASIGNADO") Is DBNull.Value, Nothing, .Item("PRESUPUESTOASIGNADO"))
                lEntidad.MONTONECESIDADREAL = IIf(.Item("MONTONECESIDADREAL") Is DBNull.Value, Nothing, .Item("MONTONECESIDADREAL"))
                lEntidad.MONTONECESIDADAJUSTADA = IIf(.Item("MONTONECESIDADAJUSTADA") Is DBNull.Value, Nothing, .Item("MONTONECESIDADAJUSTADA"))
                lEntidad.MONTONECESIDADFINAL = IIf(.Item("MONTONECESIDADFINAL") Is DBNull.Value, Nothing, .Item("MONTONECESIDADFINAL"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
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

        Dim lEntidad As NECESIDADESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDNECESIDAD),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32) As listaNECESIDADESTABLECIMIENTOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaNECESIDADESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New NECESIDADESTABLECIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDNECESIDAD = IIf(dr("IDNECESIDAD") Is DBNull.Value, Nothing, dr("IDNECESIDAD"))
                mEntidad.PROPUESTA = IIf(dr("PROPUESTA") Is DBNull.Value, Nothing, dr("PROPUESTA"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.FECHAELABORACION = IIf(dr("FECHAELABORACION") Is DBNull.Value, Nothing, dr("FECHAELABORACION"))
                mEntidad.PERIODOUTILIZACION = IIf(dr("PERIODOUTILIZACION") Is DBNull.Value, Nothing, dr("PERIODOUTILIZACION"))
                mEntidad.MESINICIOPERIODO = IIf(dr("MESINICIOPERIODO") Is DBNull.Value, Nothing, dr("MESINICIOPERIODO"))
                mEntidad.ANIOINICIOPERIODO = IIf(dr("ANIOINICIOPERIODO") Is DBNull.Value, Nothing, dr("ANIOINICIOPERIODO"))
                mEntidad.MESFINPERIODO = IIf(dr("MESFINPERIODO") Is DBNull.Value, Nothing, dr("MESFINPERIODO"))
                mEntidad.ANIOFINPERIODO = IIf(dr("ANIOFINPERIODO") Is DBNull.Value, Nothing, dr("ANIOFINPERIODO"))
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDALMACENENTREGA = IIf(dr("IDALMACENENTREGA") Is DBNull.Value, Nothing, dr("IDALMACENENTREGA"))
                mEntidad.IDSUMINISTRO = IIf(dr("IDSUMINISTRO") Is DBNull.Value, Nothing, dr("IDSUMINISTRO"))
                mEntidad.PRESUPUESTOASIGNADO = IIf(dr("PRESUPUESTOASIGNADO") Is DBNull.Value, Nothing, dr("PRESUPUESTOASIGNADO"))
                mEntidad.MONTONECESIDADREAL = IIf(dr("MONTONECESIDADREAL") Is DBNull.Value, Nothing, dr("MONTONECESIDADREAL"))
                mEntidad.MONTONECESIDADAJUSTADA = IIf(dr("MONTONECESIDADAJUSTADA") Is DBNull.Value, Nothing, dr("MONTONECESIDADAJUSTADA"))
                mEntidad.MONTONECESIDADFINAL = IIf(dr("MONTONECESIDADFINAL") Is DBNull.Value, Nothing, dr("MONTONECESIDADFINAL"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
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
        tables(0) = New String("NECESIDADESTABLECIMIENTOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDNECESIDAD, ")
        strSQL.Append(" PROPUESTA, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" IDESTADO, ")
        strSQL.Append(" FECHAELABORACION, ")
        strSQL.Append(" PERIODOUTILIZACION, ")
        strSQL.Append(" MESINICIOPERIODO, ")
        strSQL.Append(" ANIOINICIOPERIODO, ")
        strSQL.Append(" MESFINPERIODO, ")
        strSQL.Append(" ANIOFINPERIODO, ")
        strSQL.Append(" IDEMPLEADO, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" IDSUMINISTRO, ")
        strSQL.Append(" PRESUPUESTOASIGNADO, ")
        strSQL.Append(" MONTONECESIDADREAL, ")
        strSQL.Append(" MONTONECESIDADAJUSTADA, ")
        strSQL.Append(" MONTONECESIDADFINAL, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_NECESIDADESTABLECIMIENTOS ")

    End Sub

#End Region

End Class

