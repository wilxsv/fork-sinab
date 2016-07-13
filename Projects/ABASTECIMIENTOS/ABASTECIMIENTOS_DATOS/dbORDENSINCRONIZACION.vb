Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbORDENSINCRONIZACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla ORDENSINCRONIZACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbORDENSINCRONIZACION
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ORDENSINCRONIZACION
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.ORDEN = 0 _
            Or lEntidad.ORDEN = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.ORDEN = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE ORDENSINCRONIZACION ")
        strSQL.Append(" SET TABLA = @TABLA, ")
        strSQL.Append(" HABILITADA = @HABILITADA ")
        strSQL.Append(" WHERE ORDEN = @ORDEN ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@TABLA", SqlDbType.VarChar)
        args(0).Value = IIf(lEntidad.TABLA = Nothing, DBNull.Value, lEntidad.TABLA)
        args(1) = New SqlParameter("@HABILITADA", SqlDbType.TinyInt)
        args(1).Value = IIf(lEntidad.HABILITADA = Nothing, DBNull.Value, lEntidad.HABILITADA)
        args(2) = New SqlParameter("@ORDEN", SqlDbType.SmallInt)
        args(2).Value = IIf(lEntidad.ORDEN = Nothing, DBNull.Value, lEntidad.ORDEN)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ORDENSINCRONIZACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO ORDENSINCRONIZACION ")
        strSQL.Append(" ( ORDEN, ")
        strSQL.Append(" TABLA, ")
        strSQL.Append(" HABILITADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @ORDEN, ")
        strSQL.Append(" @TABLA, ")
        strSQL.Append(" @HABILITADA) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@ORDEN", SqlDbType.SmallInt)
        args(0).Value = lEntidad.ORDEN
        args(1) = New SqlParameter("@TABLA", SqlDbType.VarChar)
        args(1).Value = IIf(lEntidad.TABLA = Nothing, DBNull.Value, lEntidad.TABLA)
        args(2) = New SqlParameter("@HABILITADA", SqlDbType.TinyInt)
        args(2).Value = IIf(lEntidad.HABILITADA = Nothing, DBNull.Value, lEntidad.HABILITADA)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ORDENSINCRONIZACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM ORDENSINCRONIZACION ")
        strSQL.Append(" WHERE ORDEN = @ORDEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@ORDEN", SqlDbType.SmallInt)
        args(0).Value = lEntidad.ORDEN

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ORDENSINCRONIZACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE ORDEN = @ORDEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@ORDEN", SqlDbType.SmallInt)
        args(0).Value = lEntidad.ORDEN

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.TABLA = IIf(.Item("TABLA") Is DBNull.Value, Nothing, .Item("TABLA"))
                lEntidad.HABILITADA = IIf(.Item("HABILITADA") Is DBNull.Value, Nothing, .Item("HABILITADA"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As ORDENSINCRONIZACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(ORDEN),0) + 1 ")
        strSQL.Append(" FROM ORDENSINCRONIZACION ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaORDENSINCRONIZACION

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaORDENSINCRONIZACION

        Try
            Do While dr.Read()
                Dim mEntidad As New ORDENSINCRONIZACION
                mEntidad.ORDEN = IIf(dr("ORDEN") Is DBNull.Value, Nothing, dr("ORDEN"))
                mEntidad.TABLA = IIf(dr("TABLA") Is DBNull.Value, Nothing, dr("TABLA"))
                mEntidad.HABILITADA = IIf(dr("HABILITADA") Is DBNull.Value, Nothing, dr("HABILITADA"))
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
        tables(0) = New String("ORDENSINCRONIZACION")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT ORDEN, ")
        strSQL.Append(" TABLA, ")
        strSQL.Append(" HABILITADA ")
        strSQL.Append(" FROM ORDENSINCRONIZACION ")

    End Sub

#End Region

End Class
