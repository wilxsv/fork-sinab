Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbCONTRATOSPROCESOCOMPRA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_CONTRATOSPROCESOCOMPRA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	05/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbCONTRATOSPROCESOCOMPRA
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CONTRATOSPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_CONTRATOSPROCESOCOMPRA ")
        strSQL.Append(" SET AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(8) As SqlParameter
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
        args(5) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(5).Value = lEntidad.IDESTABLECIMIENTO
        args(6) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(6).Value = lEntidad.IDPROCESOCOMPRA
        args(7) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(7).Value = lEntidad.IDPROVEEDOR
        args(8) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(8).Value = lEntidad.IDCONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CONTRATOSPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_CONTRATOSPROCESOCOMPRA ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDCONTRATO
        args(4) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(5) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(5).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(6) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(7) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(8) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(8).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CONTRATOSPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_CONTRATOSPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDCONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CONTRATOSPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDCONTRATO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
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

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As listaCONTRATOSPROCESOCOMPRA

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(3).Value = IDCONTRATO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaCONTRATOSPROCESOCOMPRA

        Try
            Do While dr.Read()
                Dim mEntidad As New CONTRATOSPROCESOCOMPRA
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(3).Value = IDCONTRATO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(3).Value = IDCONTRATO

        Dim tables(0) As String
        tables(0) = New String("CONTRATOSPROCESOCOMPRA")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA ")

    End Sub

#End Region

End Class
