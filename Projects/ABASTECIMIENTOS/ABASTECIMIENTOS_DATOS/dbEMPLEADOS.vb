Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbEMPLEADOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla EMPLEADOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbEMPLEADOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EMPLEADOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDEMPLEADO = 0 _
            Or lEntidad.IDEMPLEADO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDEMPLEADO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_EMPLEADOS ")
        strSQL.Append(" SET IDDEPENDENCIA = @IDDEPENDENCIA, ")
        strSQL.Append(" NOMBRECORTO = @NOMBRECORTO, ")
        strSQL.Append(" NOMBRE = @NOMBRE, ")
        strSQL.Append(" APELLIDO = @APELLIDO, ")
        strSQL.Append(" TITULAR = @TITULAR, ")
        strSQL.Append(" IDCARGO = @IDCARGO, ")
        strSQL.Append(" IDESTABLECIMIENTO = @IDESTABLECIMIENTO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDEMPLEADO = @IDEMPLEADO ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(0).Value = IIf(lEntidad.IDDEPENDENCIA = Nothing, DBNull.Value, lEntidad.IDDEPENDENCIA)
        args(1) = New SqlParameter("@NOMBRECORTO", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.NOMBRECORTO = Nothing, DBNull.Value, lEntidad.NOMBRECORTO)
        args(2) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.NOMBRE = Nothing, DBNull.Value, lEntidad.NOMBRE)
        args(3) = New SqlParameter("@APELLIDO", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.APELLIDO = Nothing, DBNull.Value, lEntidad.APELLIDO)
        args(4) = New SqlParameter("@IDCARGO", SqlDbType.Int)
        args(4).Value = IIf(lEntidad.IDCARGO = Nothing, DBNull.Value, lEntidad.IDCARGO)
        args(5) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(5).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
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
        args(11) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(11).Value = lEntidad.IDEMPLEADO
        args(12) = New SqlParameter("@TITULAR", SqlDbType.TinyInt)
        args(12).Value = lEntidad.TITULAR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EMPLEADOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_EMPLEADOS ")
        strSQL.Append(" ( IDEMPLEADO, ")
        strSQL.Append(" IDDEPENDENCIA, ")
        strSQL.Append(" NOMBRECORTO, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" APELLIDO, ")
        strSQL.Append(" TITULAR, ")
        strSQL.Append(" IDCARGO, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDEMPLEADO, ")
        strSQL.Append(" @IDDEPENDENCIA, ")
        strSQL.Append(" @NOMBRECORTO, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @APELLIDO, ")
        strSQL.Append(" @TITULAR, ")
        strSQL.Append(" @IDCARGO, ")
        strSQL.Append(" @IDESTABLECIMIENTO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(0).Value = lEntidad.IDEMPLEADO
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IIf(lEntidad.IDDEPENDENCIA = Nothing, DBNull.Value, lEntidad.IDDEPENDENCIA)
        args(2) = New SqlParameter("@NOMBRECORTO", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.NOMBRECORTO = Nothing, DBNull.Value, lEntidad.NOMBRECORTO)
        args(3) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.NOMBRE = Nothing, DBNull.Value, lEntidad.NOMBRE)
        args(4) = New SqlParameter("@APELLIDO", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.APELLIDO = Nothing, DBNull.Value, lEntidad.APELLIDO)
        args(5) = New SqlParameter("@IDCARGO", SqlDbType.Int)
        args(5).Value = IIf(lEntidad.IDCARGO = Nothing, DBNull.Value, lEntidad.IDCARGO)
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(7) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(8) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(9) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(10) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(11) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(11).Value = lEntidad.ESTASINCRONIZADA
        args(12) = New SqlParameter("@TITULAR", SqlDbType.TinyInt)
        args(12).Value = lEntidad.TITULAR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EMPLEADOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_EMPLEADOS ")
        strSQL.Append(" WHERE IDEMPLEADO = @IDEMPLEADO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(0).Value = lEntidad.IDEMPLEADO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EMPLEADOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDEMPLEADO = @IDEMPLEADO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(0).Value = lEntidad.IDEMPLEADO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDDEPENDENCIA = IIf(.Item("IDDEPENDENCIA") Is DBNull.Value, Nothing, .Item("IDDEPENDENCIA"))
                lEntidad.NOMBRECORTO = IIf(.Item("NOMBRECORTO") Is DBNull.Value, Nothing, .Item("NOMBRECORTO"))
                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                lEntidad.APELLIDO = IIf(.Item("APELLIDO") Is DBNull.Value, Nothing, .Item("APELLIDO"))
                lEntidad.TITULAR = IIf(.Item("TITULAR") Is DBNull.Value, Nothing, .Item("TITULAR"))
                lEntidad.IDCARGO = IIf(.Item("IDCARGO") Is DBNull.Value, Nothing, .Item("IDCARGO"))
                lEntidad.IDESTABLECIMIENTO = IIf(.Item("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTO"))
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

        Dim lEntidad As EMPLEADOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDEMPLEADO),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_EMPLEADOS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaEMPLEADOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaEMPLEADOS

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOS
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.TITULAR = IIf(dr("TITULAR") Is DBNull.Value, Nothing, dr("TITULAR"))
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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
        tables(0) = New String("EMPLEADOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDEMPLEADO, ")
        strSQL.Append(" IDDEPENDENCIA, ")
        strSQL.Append(" NOMBRECORTO, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" APELLIDO, ")
        strSQL.Append(" TITULAR, ")
        strSQL.Append(" IDCARGO, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_EMPLEADOS ")

    End Sub

#End Region

End Class
