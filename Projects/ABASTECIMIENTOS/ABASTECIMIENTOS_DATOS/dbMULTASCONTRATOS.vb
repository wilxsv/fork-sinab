Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbMULTASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_MULTASCONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	21/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbMULTASCONTRATOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MULTASCONTRATOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDMULTA = 0 _
            Or lEntidad.IDMULTA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDMULTA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_MULTASCONTRATOS ")
        strSQL.Append(" SET IDPLANTILLA = @IDPLANTILLA, ")
        strSQL.Append(" FECHAMULTA = @FECHAMULTA, ")
        strSQL.Append(" NUMEROINFORMESEGUIMIENTO = @NUMEROINFORMESEGUIMIENTO, ")
        strSQL.Append(" NUMEROMULTA = @NUMEROMULTA, ")
        strSQL.Append(" CONTENIDO = @CONTENIDO, ")
        strSQL.Append(" TIPODOCUMENTO = @TIPODOCUMENTO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMULTA = @IDMULTA ")

        Dim args(14) As SqlParameter
        args(0) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(0).Value = lEntidad.IDPLANTILLA
        args(1) = New SqlParameter("@FECHAMULTA", SqlDbType.DateTime)
        args(1).Value = lEntidad.FECHAMULTA
        args(2) = New SqlParameter("@NUMEROINFORMESEGUIMIENTO", SqlDbType.VarChar)
        args(2).Value = lEntidad.NUMEROINFORMESEGUIMIENTO
        args(3) = New SqlParameter("@NUMEROMULTA", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.NUMEROMULTA = Nothing, DBNull.Value, lEntidad.NUMEROMULTA)
        args(4) = New SqlParameter("@CONTENIDO", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.CONTENIDO = Nothing, DBNull.Value, lEntidad.CONTENIDO)
        args(5) = New SqlParameter("@TIPODOCUMENTO", SqlDbType.SmallInt)
        args(5).Value = lEntidad.TIPODOCUMENTO
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
        args(11) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(11).Value = lEntidad.IDESTABLECIMIENTO
        args(12) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(12).Value = lEntidad.IDPROVEEDOR
        args(13) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(13).Value = lEntidad.IDCONTRATO
        args(14) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(14).Value = lEntidad.IDMULTA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MULTASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_MULTASCONTRATOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDMULTA, ")
        strSQL.Append(" IDPLANTILLA, ")
        strSQL.Append(" FECHAMULTA, ")
        strSQL.Append(" NUMEROINFORMESEGUIMIENTO, ")
        strSQL.Append(" NUMEROMULTA, ")
        strSQL.Append(" CONTENIDO, ")
        strSQL.Append(" TIPODOCUMENTO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @IDMULTA, ")
        strSQL.Append(" @IDPLANTILLA, ")
        strSQL.Append(" @FECHAMULTA, ")
        strSQL.Append(" @NUMEROINFORMESEGUIMIENTO, ")
        strSQL.Append(" @NUMEROMULTA, ")
        strSQL.Append(" @CONTENIDO, ")
        strSQL.Append(" @TIPODOCUMENTO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(14) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDMULTA
        args(4) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(4).Value = lEntidad.IDPLANTILLA
        args(5) = New SqlParameter("@FECHAMULTA", SqlDbType.DateTime)
        args(5).Value = lEntidad.FECHAMULTA
        args(6) = New SqlParameter("@NUMEROINFORMESEGUIMIENTO", SqlDbType.VarChar)
        args(6).Value = lEntidad.NUMEROINFORMESEGUIMIENTO
        args(7) = New SqlParameter("@NUMEROMULTA", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.NUMEROMULTA = Nothing, DBNull.Value, lEntidad.NUMEROMULTA)
        args(8) = New SqlParameter("@CONTENIDO", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.CONTENIDO = Nothing, DBNull.Value, lEntidad.CONTENIDO)
        args(9) = New SqlParameter("@TIPODOCUMENTO", SqlDbType.SmallInt)
        args(9).Value = lEntidad.TIPODOCUMENTO
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MULTASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_MULTASCONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMULTA = @IDMULTA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDMULTA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MULTASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMULTA = @IDMULTA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDMULTA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDPLANTILLA = IIf(.Item("IDPLANTILLA") Is DBNull.Value, Nothing, .Item("IDPLANTILLA"))
                lEntidad.FECHAMULTA = IIf(.Item("FECHAMULTA") Is DBNull.Value, Nothing, .Item("FECHAMULTA"))
                lEntidad.NUMEROINFORMESEGUIMIENTO = IIf(.Item("NUMEROINFORMESEGUIMIENTO") Is DBNull.Value, Nothing, .Item("NUMEROINFORMESEGUIMIENTO"))
                lEntidad.NUMEROMULTA = IIf(.Item("NUMEROMULTA") Is DBNull.Value, Nothing, .Item("NUMEROMULTA"))
                lEntidad.CONTENIDO = IIf(.Item("CONTENIDO") Is DBNull.Value, Nothing, .Item("CONTENIDO"))
                lEntidad.TIPODOCUMENTO = IIf(.Item("TIPODOCUMENTO") Is DBNull.Value, Nothing, .Item("TIPODOCUMENTO"))
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

        Dim lEntidad As MULTASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDMULTA),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_MULTASCONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As listaMULTASCONTRATOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaMULTASCONTRATOS

        Try
            Do While dr.Read()
                Dim mEntidad As New MULTASCONTRATOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
                mEntidad.IDMULTA = IIf(dr("IDMULTA") Is DBNull.Value, Nothing, dr("IDMULTA"))
                mEntidad.IDPLANTILLA = IIf(dr("IDPLANTILLA") Is DBNull.Value, Nothing, dr("IDPLANTILLA"))
                mEntidad.FECHAMULTA = IIf(dr("FECHAMULTA") Is DBNull.Value, Nothing, dr("FECHAMULTA"))
                mEntidad.NUMEROINFORMESEGUIMIENTO = IIf(dr("NUMEROINFORMESEGUIMIENTO") Is DBNull.Value, Nothing, dr("NUMEROINFORMESEGUIMIENTO"))
                mEntidad.NUMEROMULTA = IIf(dr("NUMEROMULTA") Is DBNull.Value, Nothing, dr("NUMEROMULTA"))
                mEntidad.CONTENIDO = IIf(dr("CONTENIDO") Is DBNull.Value, Nothing, dr("CONTENIDO"))
                mEntidad.TIPODOCUMENTO = IIf(dr("TIPODOCUMENTO") Is DBNull.Value, Nothing, dr("TIPODOCUMENTO"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Dim tables(0) As String
        tables(0) = New String("MULTASCONTRATOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDMULTA, ")
        strSQL.Append(" IDPLANTILLA, ")
        strSQL.Append(" FECHAMULTA, ")
        strSQL.Append(" NUMEROINFORMESEGUIMIENTO, ")
        strSQL.Append(" NUMEROMULTA, ")
        strSQL.Append(" CONTENIDO, ")
        strSQL.Append(" TIPODOCUMENTO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_MULTASCONTRATOS ")

    End Sub

#End Region

End Class
