Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbOPCIONESSISTEMA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SEGOPCIONESSISTEMA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	13/05/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbOPCIONESSISTEMA
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OPCIONESSISTEMA
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDOPCIONSISTEMA = 0 _
            Or lEntidad.IDOPCIONSISTEMA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDOPCIONSISTEMA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SEGOPCIONESSISTEMA ")
        strSQL.Append(" SET DESCRIPCION = @DESCRIPCION, ")
        strSQL.Append(" URL = @URL, ")
        strSQL.Append(" ESTAHABILITADO = @ESTAHABILITADO, ")
        strSQL.Append(" IDPADRE = @IDPADRE, ")
        strSQL.Append(" ORDEN = @ORDEN, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(0).Value = lEntidad.DESCRIPCION
        args(1) = New SqlParameter("@URL", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.URL = Nothing, DBNull.Value, lEntidad.URL)
        args(2) = New SqlParameter("@ESTAHABILITADO", SqlDbType.TinyInt)
        args(2).Value = lEntidad.ESTAHABILITADO
        args(3) = New SqlParameter("@IDPADRE", SqlDbType.Int)
        args(3).Value = IIf(lEntidad.IDPADRE = Nothing, DBNull.Value, lEntidad.IDPADRE)
        args(4) = New SqlParameter("@ORDEN", SqlDbType.SmallInt)
        args(4).Value = lEntidad.ORDEN
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
        args(10) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(10).Value = lEntidad.IDOPCIONSISTEMA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OPCIONESSISTEMA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SEGOPCIONESSISTEMA ")
        strSQL.Append(" ( IDOPCIONSISTEMA, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" URL, ")
        strSQL.Append(" ESTAHABILITADO, ")
        strSQL.Append(" IDPADRE, ")
        strSQL.Append(" ORDEN, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDOPCIONSISTEMA, ")
        strSQL.Append(" @DESCRIPCION, ")
        strSQL.Append(" @URL, ")
        strSQL.Append(" @ESTAHABILITADO, ")
        strSQL.Append(" @IDPADRE, ")
        strSQL.Append(" @ORDEN, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(0).Value = lEntidad.IDOPCIONSISTEMA
        args(1) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(1).Value = lEntidad.DESCRIPCION
        args(2) = New SqlParameter("@URL", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.URL = Nothing, DBNull.Value, lEntidad.URL)
        args(3) = New SqlParameter("@ESTAHABILITADO", SqlDbType.TinyInt)
        args(3).Value = lEntidad.ESTAHABILITADO
        args(4) = New SqlParameter("@IDPADRE", SqlDbType.Int)
        args(4).Value = IIf(lEntidad.IDPADRE = Nothing, DBNull.Value, lEntidad.IDPADRE)
        args(5) = New SqlParameter("@ORDEN", SqlDbType.SmallInt)
        args(5).Value = lEntidad.ORDEN
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OPCIONESSISTEMA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SEGOPCIONESSISTEMA ")
        strSQL.Append(" WHERE IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(0).Value = lEntidad.IDOPCIONSISTEMA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OPCIONESSISTEMA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(0).Value = lEntidad.IDOPCIONSISTEMA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.DESCRIPCION = IIf(.Item("DESCRIPCION") Is DBNull.Value, Nothing, .Item("DESCRIPCION"))
                lEntidad.URL = IIf(.Item("URL") Is DBNull.Value, Nothing, .Item("URL"))
                lEntidad.ESTAHABILITADO = IIf(.Item("ESTAHABILITADO") Is DBNull.Value, Nothing, .Item("ESTAHABILITADO"))
                lEntidad.IDPADRE = IIf(.Item("IDPADRE") Is DBNull.Value, Nothing, .Item("IDPADRE"))
                lEntidad.ORDEN = IIf(.Item("ORDEN") Is DBNull.Value, Nothing, .Item("ORDEN"))
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

        Dim lEntidad As OPCIONESSISTEMA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDOPCIONSISTEMA),0) + 1 ")
        strSQL.Append(" FROM SEGOPCIONESSISTEMA ")

        Return SqlHelper.ExecuteScalar(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaOPCIONESSISTEMA

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Dim lista As New listaOPCIONESSISTEMA

        Try
            Do While dr.Read()
                Dim mEntidad As New OPCIONESSISTEMA
                mEntidad.IDOPCIONSISTEMA = IIf(dr("IDOPCIONSISTEMA") Is DBNull.Value, Nothing, dr("IDOPCIONSISTEMA"))
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                mEntidad.URL = IIf(dr("URL") Is DBNull.Value, Nothing, dr("URL"))
                mEntidad.ESTAHABILITADO = IIf(dr("ESTAHABILITADO") Is DBNull.Value, Nothing, dr("ESTAHABILITADO"))
                mEntidad.IDPADRE = IIf(dr("IDPADRE") Is DBNull.Value, Nothing, dr("IDPADRE"))
                mEntidad.ORDEN = IIf(dr("ORDEN") Is DBNull.Value, Nothing, dr("ORDEN"))
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

        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim tables(0) As String
        tables(0) = New String("OPCIONESSISTEMA")

        SqlHelper.FillDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDOPCIONSISTEMA, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" URL, ")
        strSQL.Append(" ESTAHABILITADO, ")
        strSQL.Append(" IDPADRE, ")
        strSQL.Append(" ORDEN, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SEGOPCIONESSISTEMA ")

    End Sub

#End Region

End Class
