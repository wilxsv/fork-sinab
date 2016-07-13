Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbEMPLEADOSALMACEN
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_CAT_EMPLEADOSALMACEN
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbEMPLEADOSALMACEN
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EMPLEADOSALMACEN
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_EMPLEADOSALMACEN ")
        strSQL.Append("SET ESGUARDAALMACEN = @ESGUARDAALMACEN, ")
        strSQL.Append("IDSUMINISTRO = @IDSUMINISTRO, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append("WHERE IDEMPLEADO = @IDEMPLEADO ")
        strSQL.Append("AND IDALMACEN = @IDALMACEN ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(1).Value = lEntidad.IDEMPLEADO
        args(2) = New SqlParameter("@ESGUARDAALMACEN", SqlDbType.TinyInt)
        args(2).Value = lEntidad.ESGUARDAALMACEN
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
        args(8) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(8).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EMPLEADOSALMACEN
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_EMPLEADOSALMACEN ")
        strSQL.Append("(IDALMACEN, ")
        strSQL.Append("IDEMPLEADO, ")
        strSQL.Append("ESGUARDAALMACEN, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("ESTASINCRONIZADA, ")
        strSQL.Append("IDSUMINISTRO) ")
        strSQL.Append("VALUES ")
        strSQL.Append("(@IDALMACEN, ")
        strSQL.Append("@IDEMPLEADO, ")
        strSQL.Append("@ESGUARDAALMACEN, ")
        strSQL.Append("@AUUSUARIOCREACION, ")
        strSQL.Append("@AUFECHACREACION, ")
        strSQL.Append("@ESTASINCRONIZADA, ")
        strSQL.Append("@IDSUMINISTRO) ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(1).Value = lEntidad.IDEMPLEADO
        args(2) = New SqlParameter("@ESGUARDAALMACEN", SqlDbType.TinyInt)
        args(2).Value = lEntidad.ESGUARDAALMACEN
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
        args(8) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(8).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EMPLEADOSALMACEN
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_EMPLEADOSALMACEN ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDEMPLEADO = @IDEMPLEADO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(1).Value = lEntidad.IDEMPLEADO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EMPLEADOSALMACEN
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDEMPLEADO = @IDEMPLEADO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(1).Value = lEntidad.IDEMPLEADO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.ESGUARDAALMACEN = IIf(.Item("ESGUARDAALMACEN") Is DBNull.Value, Nothing, .Item("ESGUARDAALMACEN"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.IDSUMINISTRO = IIf(.Item("IDSUMINISTRO") Is DBNull.Value, Nothing, .Item("IDSUMINISTRO"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Return -1

    End Function

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32, ByVal IDEMPLEADO As Int32) As listaEMPLEADOSALMACEN

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDEMPLEADO = @IDEMPLEADO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(1).Value = IDEMPLEADO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaEMPLEADOSALMACEN

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOSALMACEN
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.IDEMPLEADO = IDEMPLEADO
                mEntidad.ESGUARDAALMACEN = IIf(dr("ESGUARDAALMACEN") Is DBNull.Value, Nothing, dr("ESGUARDAALMACEN"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.IDSUMINISTRO = IIf(dr("IDSUMINISTRO") Is DBNull.Value, Nothing, dr("IDSUMINISTRO"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDEMPLEADO As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDEMPLEADO = @IDEMPLEADO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(1).Value = IDEMPLEADO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDEMPLEADO As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDEMPLEADO = @IDEMPLEADO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(1).Value = IDEMPLEADO

        Dim tables(0) As String
        tables(0) = New String("EMPLEADOSALMACEN")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append("SELECT IDALMACEN, ")
        strSQL.Append("IDEMPLEADO, ")
        strSQL.Append("ESGUARDAALMACEN, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA, ")
        strSQL.Append("IDSUMINISTRO ")
        strSQL.Append("FROM SAB_CAT_EMPLEADOSALMACEN ")

    End Sub

#End Region

End Class
