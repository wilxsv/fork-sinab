Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbPROVEEDORES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_CAT_PROVEEDORES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbPROVEEDORES
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROVEEDORES
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDPROVEEDOR = 0 _
            Or lEntidad.IDPROVEEDOR = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDPROVEEDOR = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_PROVEEDORES ")
        strSQL.Append(" SET CODIGOPROVEEDOR = @CODIGOPROVEEDOR, ")
        strSQL.Append(" NOMBRE = @NOMBRE, ")
        strSQL.Append(" DIRECCION = @DIRECCION, ")
        strSQL.Append(" REPRESENTANTELEGAL = @REPRESENTANTELEGAL, ")
        strSQL.Append(" MATRICULA = @MATRICULA, ")
        strSQL.Append(" TELEFONO = @TELEFONO, ")
        strSQL.Append(" FAX = @FAX, ")
        strSQL.Append(" NIT = @NIT, ")
        strSQL.Append(" GIRO = @GIRO, ")
        strSQL.Append(" CORREO = @CORREO, ")
        strSQL.Append(" REALIZADONACIONES = @REALIZADONACIONES, ")
        strSQL.Append(" PROCEDENCIA = @PROCEDENCIA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(17) As SqlParameter
        args(0) = New SqlParameter("@CODIGOPROVEEDOR", SqlDbType.VarChar)
        args(0).Value = lEntidad.CODIGOPROVEEDOR
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@DIRECCION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.DIRECCION = Nothing, DBNull.Value, lEntidad.DIRECCION)
        args(3) = New SqlParameter("@REPRESENTANTELEGAL", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.REPRESENTANTELEGAL = Nothing, DBNull.Value, lEntidad.REPRESENTANTELEGAL)
        args(4) = New SqlParameter("@MATRICULA", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.MATRICULA = Nothing, DBNull.Value, lEntidad.MATRICULA)
        args(5) = New SqlParameter("@TELEFONO", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.TELEFONO = Nothing, DBNull.Value, lEntidad.TELEFONO)
        args(6) = New SqlParameter("@FAX", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.FAX = Nothing, DBNull.Value, lEntidad.FAX)
        args(7) = New SqlParameter("@NIT", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.NIT = Nothing, DBNull.Value, lEntidad.NIT)
        args(8) = New SqlParameter("@GIRO", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.GIRO = Nothing, DBNull.Value, lEntidad.GIRO)
        args(9) = New SqlParameter("@REALIZADONACIONES", SqlDbType.TinyInt)
        args(9).Value = lEntidad.REALIZADONACIONES
        args(17) = New SqlParameter("@PROCEDENCIA", SqlDbType.TinyInt)
        args(17).Value = lEntidad.PROCEDENCIA
        args(10) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(11) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(12) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(13) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(14) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(14).Value = lEntidad.ESTASINCRONIZADA
        args(15) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(15).Value = lEntidad.IDPROVEEDOR
        args(16) = New SqlParameter("@CORREO", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.CORREO = Nothing, DBNull.Value, lEntidad.CORREO)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROVEEDORES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_PROVEEDORES ")
        strSQL.Append(" ( IDPROVEEDOR, ")
        strSQL.Append(" CODIGOPROVEEDOR, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" DIRECCION, ")
        strSQL.Append(" REPRESENTANTELEGAL, ")
        strSQL.Append(" MATRICULA, ")
        strSQL.Append(" TELEFONO, ")
        strSQL.Append(" FAX, ")
        strSQL.Append(" NIT, ")
        strSQL.Append(" GIRO, ")
        strSQL.Append(" REALIZADONACIONES, ")
        strSQL.Append(" PROCEDENCIA, ")
        strSQL.Append(" CORREO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDPROVEEDOR, ")
        strSQL.Append(" @CODIGOPROVEEDOR, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @DIRECCION, ")
        strSQL.Append(" @REPRESENTANTELEGAL, ")
        strSQL.Append(" @MATRICULA, ")
        strSQL.Append(" @TELEFONO, ")
        strSQL.Append(" @FAX, ")
        strSQL.Append(" @NIT, ")
        strSQL.Append(" @GIRO, ")
        strSQL.Append(" @REALIZADONACIONES, ")
        strSQL.Append(" @PROCEDENCIA, ")
        strSQL.Append(" @CORREO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(17) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROVEEDOR
        args(1) = New SqlParameter("@CODIGOPROVEEDOR", SqlDbType.VarChar)
        args(1).Value = lEntidad.CODIGOPROVEEDOR
        args(2) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(2).Value = lEntidad.NOMBRE
        args(3) = New SqlParameter("@DIRECCION", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.DIRECCION = Nothing, DBNull.Value, lEntidad.DIRECCION)
        args(4) = New SqlParameter("@REPRESENTANTELEGAL", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.REPRESENTANTELEGAL = Nothing, DBNull.Value, lEntidad.REPRESENTANTELEGAL)
        args(5) = New SqlParameter("@MATRICULA", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.MATRICULA = Nothing, DBNull.Value, lEntidad.MATRICULA)
        args(6) = New SqlParameter("@TELEFONO", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.TELEFONO = Nothing, DBNull.Value, lEntidad.TELEFONO)
        args(7) = New SqlParameter("@FAX", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.FAX = Nothing, DBNull.Value, lEntidad.FAX)
        args(8) = New SqlParameter("@NIT", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.NIT = Nothing, DBNull.Value, lEntidad.NIT)
        args(9) = New SqlParameter("@GIRO", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.GIRO = Nothing, DBNull.Value, lEntidad.GIRO)
        args(10) = New SqlParameter("@REALIZADONACIONES", SqlDbType.TinyInt)
        args(10).Value = lEntidad.REALIZADONACIONES
        args(17) = New SqlParameter("@PROCEDENCIA", SqlDbType.TinyInt)
        args(17).Value = lEntidad.PROCEDENCIA
        args(11) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(11).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(12) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(13) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(14) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(15) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(15).Value = lEntidad.ESTASINCRONIZADA
        args(16) = New SqlParameter("@CORREO", SqlDbType.VarChar)
        args(16).Value = IIf(IsNothing(lEntidad.CORREO), DBNull.Value, lEntidad.CORREO)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROVEEDORES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROVEEDOR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROVEEDORES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROVEEDOR

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.CODIGOPROVEEDOR = IIf(.Item("CODIGOPROVEEDOR") Is DBNull.Value, Nothing, .Item("CODIGOPROVEEDOR"))
                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                lEntidad.DIRECCION = IIf(.Item("DIRECCION") Is DBNull.Value, Nothing, .Item("DIRECCION"))
                lEntidad.REPRESENTANTELEGAL = IIf(.Item("REPRESENTANTELEGAL") Is DBNull.Value, Nothing, .Item("REPRESENTANTELEGAL"))
                lEntidad.MATRICULA = IIf(.Item("MATRICULA") Is DBNull.Value, Nothing, .Item("MATRICULA"))
                lEntidad.TELEFONO = IIf(.Item("TELEFONO") Is DBNull.Value, Nothing, .Item("TELEFONO"))
                lEntidad.FAX = IIf(.Item("FAX") Is DBNull.Value, Nothing, .Item("FAX"))
                lEntidad.NIT = IIf(.Item("NIT") Is DBNull.Value, Nothing, .Item("NIT"))
                lEntidad.GIRO = IIf(.Item("GIRO") Is DBNull.Value, Nothing, .Item("GIRO"))
                lEntidad.REALIZADONACIONES = IIf(.Item("REALIZADONACIONES") Is DBNull.Value, Nothing, .Item("REALIZADONACIONES"))
                lEntidad.PROCEDENCIA = IIf(.Item("PROCEDENCIA") Is DBNull.Value, Nothing, .Item("PROCEDENCIA"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.CORREO = IIf(.Item("CORREO") Is DBNull.Value, Nothing, .Item("CORREO"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As PROVEEDORES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDPROVEEDOR),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaPROVEEDORES

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaPROVEEDORES

        Try
            Do While dr.Read()
                Dim mEntidad As New PROVEEDORES
                mEntidad.IDPROVEEDOR = IIf(dr("IDPROVEEDOR") Is DBNull.Value, Nothing, dr("IDPROVEEDOR"))
                mEntidad.CODIGOPROVEEDOR = IIf(dr("CODIGOPROVEEDOR") Is DBNull.Value, Nothing, dr("CODIGOPROVEEDOR"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.REPRESENTANTELEGAL = IIf(dr("REPRESENTANTELEGAL") Is DBNull.Value, Nothing, dr("REPRESENTANTELEGAL"))
                mEntidad.MATRICULA = IIf(dr("MATRICULA") Is DBNull.Value, Nothing, dr("MATRICULA"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.NIT = IIf(dr("NIT") Is DBNull.Value, Nothing, dr("NIT"))
                mEntidad.GIRO = IIf(dr("GIRO") Is DBNull.Value, Nothing, dr("GIRO"))
                mEntidad.REALIZADONACIONES = IIf(dr("REALIZADONACIONES") Is DBNull.Value, Nothing, dr("REALIZADONACIONES"))
                mEntidad.PROCEDENCIA = IIf(dr("PROCEDENCIA") Is DBNull.Value, Nothing, dr("PROCEDENCIA"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.CORREO = IIf(dr("CORREO") Is DBNull.Value, Nothing, dr("CORREO"))
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
        tables(0) = New String("PROVEEDORES")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDPROVEEDOR, ")
        strSQL.Append(" CODIGOPROVEEDOR, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" DIRECCION, ")
        strSQL.Append(" REPRESENTANTELEGAL, ")
        strSQL.Append(" MATRICULA, ")
        strSQL.Append(" TELEFONO, ")
        strSQL.Append(" FAX, ")
        strSQL.Append(" NIT, ")
        strSQL.Append(" GIRO, ")
        strSQL.Append(" REALIZADONACIONES, ")
        strSQL.Append(" PROCEDENCIA, ")
        strSQL.Append(" CORREO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES ")

    End Sub

#End Region

End Class
