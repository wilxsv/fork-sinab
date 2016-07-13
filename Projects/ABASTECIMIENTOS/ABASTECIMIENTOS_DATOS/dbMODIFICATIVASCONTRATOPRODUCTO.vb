Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbMODIFICATIVASCONTRATOPRODUCTO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbMODIFICATIVASCONTRATOPRODUCTO
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MODIFICATIVASCONTRATOPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO ")
        strSQL.Append(" SET DESCRIPCION = @DESCRIPCION, ")
        strSQL.Append(" CANTIDADCONTRATADA = @CANTIDADCONTRATADA, ")
        strSQL.Append(" PRECIOUNITARIO = @PRECIOUNITARIO, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(0).Value = IIf(lEntidad.DESCRIPCION = Nothing, DBNull.Value, lEntidad.DESCRIPCION)
        args(1) = New SqlParameter("@CANTIDADCONTRATADA", SqlDbType.Decimal)
        args(1).Value = IIf(lEntidad.CANTIDADCONTRATADA = Nothing, DBNull.Value, lEntidad.CANTIDADCONTRATADA)
        args(2) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Decimal)
        args(2).Value = IIf(lEntidad.PRECIOUNITARIO = Nothing, DBNull.Value, lEntidad.PRECIOUNITARIO)
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(5) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(5).Value = lEntidad.ESTASINCRONIZADA
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = lEntidad.IDESTABLECIMIENTO
        args(7) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(7).Value = lEntidad.IDPROVEEDOR
        args(8) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(8).Value = lEntidad.IDCONTRATO
        args(9) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(9).Value = lEntidad.IDMODIFICATIVA
        args(10) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(10).Value = lEntidad.RENGLON

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MODIFICATIVASCONTRATOPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" CANTIDADCONTRATADA, ")
        strSQL.Append(" PRECIOUNITARIO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @IDMODIFICATIVA, ")
        strSQL.Append(" @RENGLON, ")
        strSQL.Append(" @DESCRIPCION, ")
        strSQL.Append(" @CANTIDADCONTRATADA, ")
        strSQL.Append(" @PRECIOUNITARIO, ")
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
        args(3) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDMODIFICATIVA
        args(4) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(4).Value = lEntidad.RENGLON
        args(5) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.DESCRIPCION = Nothing, DBNull.Value, lEntidad.DESCRIPCION)
        args(6) = New SqlParameter("@CANTIDADCONTRATADA", SqlDbType.Decimal)
        args(6).Value = IIf(lEntidad.CANTIDADCONTRATADA = Nothing, DBNull.Value, lEntidad.CANTIDADCONTRATADA)
        args(7) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Decimal)
        args(7).Value = IIf(lEntidad.PRECIOUNITARIO = Nothing, DBNull.Value, lEntidad.PRECIOUNITARIO)
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

        Dim lEntidad As MODIFICATIVASCONTRATOPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDMODIFICATIVA
        args(4) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(4).Value = lEntidad.RENGLON

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As MODIFICATIVASCONTRATOPRODUCTO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDMODIFICATIVA
        args(4) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(4).Value = lEntidad.RENGLON

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.DESCRIPCION = IIf(.Item("DESCRIPCION") Is DBNull.Value, Nothing, .Item("DESCRIPCION"))
                lEntidad.CANTIDADCONTRATADA = IIf(.Item("CANTIDADCONTRATADA") Is DBNull.Value, Nothing, .Item("CANTIDADCONTRATADA"))
                lEntidad.PRECIOUNITARIO = IIf(.Item("PRECIOUNITARIO") Is DBNull.Value, Nothing, .Item("PRECIOUNITARIO"))
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

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64) As listaMODIFICATIVASCONTRATOPRODUCTO

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(3).Value = IDMODIFICATIVA
        args(4) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(4).Value = RENGLON

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaMODIFICATIVASCONTRATOPRODUCTO

        Try
            Do While dr.Read()
                Dim mEntidad As New MODIFICATIVASCONTRATOPRODUCTO
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
                mEntidad.IDMODIFICATIVA = IDMODIFICATIVA
                mEntidad.RENGLON = RENGLON
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                mEntidad.CANTIDADCONTRATADA = IIf(dr("CANTIDADCONTRATADA") Is DBNull.Value, Nothing, dr("CANTIDADCONTRATADA"))
                mEntidad.PRECIOUNITARIO = IIf(dr("PRECIOUNITARIO") Is DBNull.Value, Nothing, dr("PRECIOUNITARIO"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(3).Value = IDMODIFICATIVA
        args(4) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(4).Value = RENGLON

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(3).Value = IDMODIFICATIVA
        args(4) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(4).Value = RENGLON

        Dim tables(0) As String
        tables(0) = New String("MODIFICATIVASCONTRATOPRODUCTO")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" DESCRIPCION, ")
        strSQL.Append(" CANTIDADCONTRATADA, ")
        strSQL.Append(" PRECIOUNITARIO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO ")

    End Sub

#End Region

End Class
