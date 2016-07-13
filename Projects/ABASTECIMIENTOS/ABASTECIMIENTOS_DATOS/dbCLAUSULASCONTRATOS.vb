Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbCLAUSULASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_CLAUSULASCONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbCLAUSULASCONTRATOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CLAUSULASCONTRATOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDCLAUSULACONTRATO = 0 _
            Or lEntidad.IDCLAUSULACONTRATO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDCLAUSULACONTRATO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_CLAUSULASCONTRATOS ")
        strSQL.Append(" SET ENCABEZADOCLAUSULA = @ENCABEZADOCLAUSULA, ")
        strSQL.Append(" ORDEN = @ORDEN, ")
        strSQL.Append(" IDMODIFICATIVA = @IDMODIFICATIVA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDCLAUSULA = @IDCLAUSULA ")
        strSQL.Append(" AND IDCLAUSULACONTRATO = @IDCLAUSULACONTRATO ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@ENCABEZADOCLAUSULA", SqlDbType.VarChar)
        args(0).Value = lEntidad.ENCABEZADOCLAUSULA
        args(1) = New SqlParameter("@ORDEN", SqlDbType.TinyInt)
        args(1).Value = lEntidad.ORDEN
        args(2) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(2).Value = IIf(lEntidad.IDMODIFICATIVA = Nothing, DBNull.Value, lEntidad.IDMODIFICATIVA)
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
        args(11) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(11).Value = lEntidad.IDCLAUSULA
        args(12) = New SqlParameter("@IDCLAUSULACONTRATO", SqlDbType.SmallInt)
        args(12).Value = lEntidad.IDCLAUSULACONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CLAUSULASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_CLAUSULASCONTRATOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDCLAUSULA, ")
        strSQL.Append(" IDCLAUSULACONTRATO, ")
        strSQL.Append(" ENCABEZADOCLAUSULA, ")
        strSQL.Append(" ORDEN, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @IDCLAUSULA, ")
        strSQL.Append(" @IDCLAUSULACONTRATO, ")
        strSQL.Append(" @ENCABEZADOCLAUSULA, ")
        strSQL.Append(" @ORDEN, ")
        strSQL.Append(" @IDMODIFICATIVA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(3).Value = lEntidad.IDCLAUSULA
        args(4) = New SqlParameter("@IDCLAUSULACONTRATO", SqlDbType.SmallInt)
        args(4).Value = lEntidad.IDCLAUSULACONTRATO
        args(5) = New SqlParameter("@ENCABEZADOCLAUSULA", SqlDbType.VarChar)
        args(5).Value = lEntidad.ENCABEZADOCLAUSULA
        args(6) = New SqlParameter("@ORDEN", SqlDbType.TinyInt)
        args(6).Value = lEntidad.ORDEN
        args(7) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(7).Value = IIf(lEntidad.IDMODIFICATIVA = Nothing, DBNull.Value, lEntidad.IDMODIFICATIVA)
        args(8) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(9) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(10) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(11) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(12) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(12).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CLAUSULASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_CLAUSULASCONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDCLAUSULA = @IDCLAUSULA ")
        strSQL.Append(" AND IDCLAUSULACONTRATO = @IDCLAUSULACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(3).Value = lEntidad.IDCLAUSULA
        args(4) = New SqlParameter("@IDCLAUSULACONTRATO", SqlDbType.SmallInt)
        args(4).Value = lEntidad.IDCLAUSULACONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CLAUSULASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDCLAUSULA = @IDCLAUSULA ")
        strSQL.Append(" AND IDCLAUSULACONTRATO = @IDCLAUSULACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(3).Value = lEntidad.IDCLAUSULA
        args(4) = New SqlParameter("@IDCLAUSULACONTRATO", SqlDbType.SmallInt)
        args(4).Value = lEntidad.IDCLAUSULACONTRATO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.ENCABEZADOCLAUSULA = IIf(.Item("ENCABEZADOCLAUSULA") Is DBNull.Value, Nothing, .Item("ENCABEZADOCLAUSULA"))
                lEntidad.ORDEN = IIf(.Item("ORDEN") Is DBNull.Value, Nothing, .Item("ORDEN"))
                lEntidad.IDMODIFICATIVA = IIf(.Item("IDMODIFICATIVA") Is DBNull.Value, Nothing, .Item("IDMODIFICATIVA"))
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

        Dim lEntidad As CLAUSULASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDCLAUSULACONTRATO),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_CLAUSULASCONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDCLAUSULA = @IDCLAUSULA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(3).Value = lEntidad.IDCLAUSULA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDCLAUSULA As Int32) As listaCLAUSULASCONTRATOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDCLAUSULA = @IDCLAUSULA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(3).Value = IDCLAUSULA

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaCLAUSULASCONTRATOS

        Try
            Do While dr.Read()
                Dim mEntidad As New CLAUSULASCONTRATOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
                mEntidad.IDCLAUSULA = IDCLAUSULA
                mEntidad.IDCLAUSULACONTRATO = IIf(dr("IDCLAUSULACONTRATO") Is DBNull.Value, Nothing, dr("IDCLAUSULACONTRATO"))
                mEntidad.ENCABEZADOCLAUSULA = IIf(dr("ENCABEZADOCLAUSULA") Is DBNull.Value, Nothing, dr("ENCABEZADOCLAUSULA"))
                mEntidad.ORDEN = IIf(dr("ORDEN") Is DBNull.Value, Nothing, dr("ORDEN"))
                mEntidad.IDMODIFICATIVA = IIf(dr("IDMODIFICATIVA") Is DBNull.Value, Nothing, dr("IDMODIFICATIVA"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDCLAUSULA As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDCLAUSULA = @IDCLAUSULA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(3).Value = IDCLAUSULA

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDCLAUSULA As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDCLAUSULA = @IDCLAUSULA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(3).Value = IDCLAUSULA

        Dim tables(0) As String
        tables(0) = New String("CLAUSULASCONTRATOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDCLAUSULA, ")
        strSQL.Append(" IDCLAUSULACONTRATO, ")
        strSQL.Append(" ENCABEZADOCLAUSULA, ")
        strSQL.Append(" ORDEN, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_CLAUSULASCONTRATOS ")

    End Sub

#End Region

End Class
