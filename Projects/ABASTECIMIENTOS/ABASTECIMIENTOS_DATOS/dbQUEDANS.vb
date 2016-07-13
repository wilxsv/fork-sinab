Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbQUEDANS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_QUEDANS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	24/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbQUEDANS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As QUEDANS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDQUEDAN = 0 _
            Or lEntidad.IDQUEDAN = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDQUEDAN = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_QUEDANS ")
        strSQL.Append(" SET FECHAINGRESO = @FECHAINGRESO, ")
        strSQL.Append(" FECHAVENCIMIENTO = @FECHAVENCIMIENTO, ")
        strSQL.Append(" DESCRIPCION = @DESCRIPCION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")
        strSQL.Append(" AND IDQUEDAN = @IDQUEDAN ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@FECHAINGRESO", SqlDbType.DateTime)
        args(0).Value = lEntidad.FECHAINGRESO
        args(1) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(1).Value = lEntidad.FECHAVENCIMIENTO
        args(2) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.DESCRIPCION = Nothing, DBNull.Value, lEntidad.DESCRIPCION)
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
        args(8) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(8).Value = lEntidad.IDESTABLECIMIENTO
        args(9) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(9).Value = lEntidad.IDPROVEEDOR
        args(10) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(10).Value = lEntidad.IDCONTRATO
        args(11) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(11).Value = lEntidad.IDTIPOGARANTIA
        args(12) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(12).Value = lEntidad.IDGARANTIACONTRATO
        args(13) = New SqlParameter("@IDQUEDAN", SqlDbType.SmallInt)
        args(13).Value = lEntidad.IDQUEDAN

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As QUEDANS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_QUEDANS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDTIPOGARANTIA, ")
        strSQL.Append(" IDGARANTIACONTRATO, ")
        strSQL.Append(" IDQUEDAN, ")
        strSQL.Append(" FECHAINGRESO, ")
        strSQL.Append(" FECHAVENCIMIENTO, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @IDTIPOGARANTIA, ")
        strSQL.Append(" @IDGARANTIACONTRATO, ")
        strSQL.Append(" @IDQUEDAN, ")
        strSQL.Append(" @FECHAINGRESO, ")
        strSQL.Append(" @FECHAVENCIMIENTO, ")
        strSQL.Append(" @DESCRIPCION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = lEntidad.IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = lEntidad.IDGARANTIACONTRATO
        args(5) = New SqlParameter("@IDQUEDAN", SqlDbType.SmallInt)
        args(5).Value = lEntidad.IDQUEDAN
        args(6) = New SqlParameter("@FECHAINGRESO", SqlDbType.DateTime)
        args(6).Value = lEntidad.FECHAINGRESO
        args(7) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(7).Value = lEntidad.FECHAVENCIMIENTO
        args(8) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.DESCRIPCION = Nothing, DBNull.Value, lEntidad.DESCRIPCION)
        args(9) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(10) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(11) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(11).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(12) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(13) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(13).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As QUEDANS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_QUEDANS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")
        strSQL.Append(" AND IDQUEDAN = @IDQUEDAN ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = lEntidad.IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = lEntidad.IDGARANTIACONTRATO
        args(5) = New SqlParameter("@IDQUEDAN", SqlDbType.SmallInt)
        args(5).Value = lEntidad.IDQUEDAN

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As QUEDANS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")
        strSQL.Append(" AND IDQUEDAN = @IDQUEDAN ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = lEntidad.IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = lEntidad.IDGARANTIACONTRATO
        args(5) = New SqlParameter("@IDQUEDAN", SqlDbType.SmallInt)
        args(5).Value = lEntidad.IDQUEDAN

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.FECHAINGRESO = IIf(.Item("FECHAINGRESO") Is DBNull.Value, Nothing, .Item("FECHAINGRESO"))
                lEntidad.FECHAVENCIMIENTO = IIf(.Item("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, .Item("FECHAVENCIMIENTO"))
                lEntidad.DESCRIPCION = IIf(.Item("DESCRIPCION") Is DBNull.Value, Nothing, .Item("DESCRIPCION"))
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

        Dim lEntidad As QUEDANS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDQUEDAN),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_QUEDANS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = lEntidad.IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = lEntidad.IDGARANTIACONTRATO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16, ByVal IDGARANTIACONTRATO As Int32) As listaQUEDANS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = IDGARANTIACONTRATO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaQUEDANS

        Try
            Do While dr.Read()
                Dim mEntidad As New QUEDANS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
                mEntidad.IDTIPOGARANTIA = IDTIPOGARANTIA
                mEntidad.IDGARANTIACONTRATO = IDGARANTIACONTRATO
                mEntidad.IDQUEDAN = IIf(dr("IDQUEDAN") Is DBNull.Value, Nothing, dr("IDQUEDAN"))
                mEntidad.FECHAINGRESO = IIf(dr("FECHAINGRESO") Is DBNull.Value, Nothing, dr("FECHAINGRESO"))
                mEntidad.FECHAVENCIMIENTO = IIf(dr("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, dr("FECHAVENCIMIENTO"))
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16, ByVal IDGARANTIACONTRATO As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = IDGARANTIACONTRATO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16, ByVal IDGARANTIACONTRATO As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = IDGARANTIACONTRATO

        Dim tables(0) As String
        tables(0) = New String("QUEDANS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDTIPOGARANTIA, ")
        strSQL.Append(" IDGARANTIACONTRATO, ")
        strSQL.Append(" IDQUEDAN, ")
        strSQL.Append(" FECHAINGRESO, ")
        strSQL.Append(" FECHAVENCIMIENTO, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_QUEDANS ")

    End Sub

#End Region

End Class
