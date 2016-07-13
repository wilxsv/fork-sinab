Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbOPCIONESSISTEMAROLES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SEGOPCIONESSISTEMAROLES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbOPCIONESSISTEMAROLES
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OPCIONESSISTEMAROLES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SEGOPCIONESSISTEMAROLES ")
        strSQL.Append(" SET PERMITEEDITAR = @PERMITEEDITAR, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDROL = @IDROL ")
        strSQL.Append(" AND IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(0).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(1) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(1).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(2) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(3) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(4) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(4).Value = lEntidad.ESTASINCRONIZADA
        args(5) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(5).Value = lEntidad.IDROL
        args(6) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(6).Value = lEntidad.IDOPCIONSISTEMA
        args(7) = New SqlParameter("@PERMITEEDITAR", SqlDbType.TinyInt)
        args(7).Value = lEntidad.PERMITEEDITAR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OPCIONESSISTEMAROLES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SEGOPCIONESSISTEMAROLES ")
        strSQL.Append(" ( IDROL, ")
        strSQL.Append(" IDOPCIONSISTEMA, ")
        strSQL.Append(" PERMITEEDITAR, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDROL, ")
        strSQL.Append(" @IDOPCIONSISTEMA, ")
        strSQL.Append(" @PERMITEEDITAR, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = lEntidad.IDROL
        args(1) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(1).Value = lEntidad.IDOPCIONSISTEMA
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
        args(7) = New SqlParameter("@PERMITEEDITAR", SqlDbType.TinyInt)
        args(7).Value = lEntidad.PERMITEEDITAR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OPCIONESSISTEMAROLES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SEGOPCIONESSISTEMAROLES ")
        strSQL.Append(" WHERE IDROL = @IDROL ")
        strSQL.Append(" AND IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = lEntidad.IDROL
        args(1) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(1).Value = lEntidad.IDOPCIONSISTEMA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OPCIONESSISTEMAROLES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDROL = @IDROL ")
        strSQL.Append(" AND IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = lEntidad.IDROL
        args(1) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(1).Value = lEntidad.IDOPCIONSISTEMA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.PERMITEEDITAR = .Item("PERMITEEDITAR")
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

    Public Function ObtenerListaPorID(ByVal IDROL As Int32, ByVal IDOPCIONSISTEMA As Int32) As listaOPCIONESSISTEMAROLES

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDROL = @IDROL ")
        strSQL.Append(" AND IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = IDROL
        args(1) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(1).Value = IDOPCIONSISTEMA

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaOPCIONESSISTEMAROLES

        Try
            Do While dr.Read()
                Dim mEntidad As New OPCIONESSISTEMAROLES
                mEntidad.IDROL = IDROL
                mEntidad.IDOPCIONSISTEMA = IDOPCIONSISTEMA
                mEntidad.PERMITEEDITAR = dr("PERMITEEDITAR")
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

    Public Function ObtenerDataSetPorID(ByVal IDROL As Int32, ByVal IDOPCIONSISTEMA As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDROL = @IDROL ")
        strSQL.Append(" AND IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = IDROL
        args(1) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(1).Value = IDOPCIONSISTEMA

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDROL As Int32, ByVal IDOPCIONSISTEMA As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDROL = @IDROL ")
        strSQL.Append(" AND IDOPCIONSISTEMA = @IDOPCIONSISTEMA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = IDROL
        args(1) = New SqlParameter("@IDOPCIONSISTEMA", SqlDbType.Int)
        args(1).Value = IDOPCIONSISTEMA

        Dim tables(0) As String
        tables(0) = New String("OPCIONESSISTEMAROLES")

        SqlHelper.FillDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDROL, ")
        strSQL.Append(" IDOPCIONSISTEMA, ")
        strSQL.Append(" PERMITEEDITAR, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SEGOPCIONESSISTEMAROLES ")

    End Sub

#End Region

End Class
