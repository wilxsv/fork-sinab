Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbALMACENES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla ALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbALMACENES
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALMACENES
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDALMACEN = 0 _
            Or lEntidad.IDALMACEN = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDALMACEN = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_ALMACENES ")
        strSQL.Append(" SET NOMBRE = @NOMBRE, ")
        strSQL.Append(" DIRECCION = @DIRECCION, ")
        strSQL.Append(" TELEFONO = @TELEFONO, ")
        strSQL.Append(" FAX = @FAX, ")
        strSQL.Append(" ESFARMACIA = @ESFARMACIA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(0).Value = lEntidad.NOMBRE
        args(1) = New SqlParameter("@DIRECCION", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.DIRECCION = Nothing, DBNull.Value, lEntidad.DIRECCION)
        args(2) = New SqlParameter("@TELEFONO", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.TELEFONO = Nothing, DBNull.Value, lEntidad.TELEFONO)
        args(3) = New SqlParameter("@FAX", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.FAX = Nothing, DBNull.Value, lEntidad.FAX)
        args(4) = New SqlParameter("@ESFARMACIA", SqlDbType.TinyInt)
        args(4).Value = lEntidad.ESFARMACIA
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
        args(10) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(10).Value = lEntidad.IDALMACEN

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_ALMACENES ")
        strSQL.Append(" ( IDALMACEN, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" DIRECCION, ")
        strSQL.Append(" TELEFONO, ")
        strSQL.Append(" FAX, ")
        strSQL.Append(" ESFARMACIA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALMACEN, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @DIRECCION, ")
        strSQL.Append(" @TELEFONO, ")
        strSQL.Append(" @FAX, ")
        strSQL.Append(" @ESFARMACIA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@DIRECCION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.DIRECCION = Nothing, DBNull.Value, lEntidad.DIRECCION)
        args(3) = New SqlParameter("@TELEFONO", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.TELEFONO = Nothing, DBNull.Value, lEntidad.TELEFONO)
        args(4) = New SqlParameter("@FAX", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.FAX = Nothing, DBNull.Value, lEntidad.FAX)
        args(5) = New SqlParameter("@ESFARMACIA", SqlDbType.TinyInt)
        args(5).Value = lEntidad.ESFARMACIA
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_ALMACENES ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN  ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try

            With dsDatos.Tables(0).Rows(0)

                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                lEntidad.DIRECCION = IIf(.Item("DIRECCION") Is DBNull.Value, Nothing, .Item("DIRECCION"))
                lEntidad.TELEFONO = IIf(.Item("TELEFONO") Is DBNull.Value, Nothing, .Item("TELEFONO"))
                lEntidad.FAX = IIf(.Item("FAX") Is DBNull.Value, Nothing, .Item("FAX"))
                lEntidad.ESFARMACIA = IIf(.Item("ESFARMACIA") Is DBNull.Value, Nothing, .Item("ESFARMACIA"))
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

        Dim lEntidad As ALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDALMACEN),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_ALMACENES ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaALMACENES

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaALMACENES

        Try
            Do While dr.Read()
                Dim mEntidad As New ALMACENES
                mEntidad.IDALMACEN = IIf(dr("IDALMACEN") Is DBNull.Value, Nothing, dr("IDALMACEN"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.ESFARMACIA = IIf(dr("ESFARMACIA") Is DBNull.Value, Nothing, dr("ESFARMACIA"))
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
        tables(0) = New String("ALMACENES")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDALMACEN, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" DIRECCION, ")
        strSQL.Append(" TELEFONO, ")
        strSQL.Append(" FAX, ")
        strSQL.Append(" ESFARMACIA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_ALMACENES ")
        'strSQL.Append(" WHERE NOMBRE NOT LIKE 'U%' ")

    End Sub
    Private Sub SelectTabla2(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDALMACEN, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" DIRECCION, ")
        strSQL.Append(" TELEFONO, ")
        strSQL.Append(" FAX, ")
        strSQL.Append(" ESFARMACIA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_ALMACENES ")
        'strSQL.Append(" WHERE NOMBRE NOT LIKE 'U%' ")

    End Sub
#End Region

End Class
