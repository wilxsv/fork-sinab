Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbENTREGACONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_ENTREGACONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	01/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbENTREGACONTRATO
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ENTREGACONTRATO
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDDETALLE = 0 _
            Or lEntidad.IDDETALLE = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDDETALLE = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" SET ENTREGA = @ENTREGA, ")
        strSQL.Append(" PLAZOENTREGA = @PLAZOENTREGA, ")
        strSQL.Append(" PORCENTAJEENTREGA = @PORCENTAJEENTREGA, ")
        strSQL.Append(" FECHACONTEO = @FECHACONTEO, ")
        strSQL.Append(" IDMODIFICATIVA = @IDMODIFICATIVA, ")
        strSQL.Append(" ESTAHABILITADA = @ESTAHABILITADA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(15) As SqlParameter
        args(0) = New SqlParameter("@ENTREGA", SqlDbType.TinyInt)
        args(0).Value = lEntidad.ENTREGA
        args(1) = New SqlParameter("@PLAZOENTREGA", SqlDbType.SmallInt)
        args(1).Value = lEntidad.PLAZOENTREGA
        args(2) = New SqlParameter("@PORCENTAJEENTREGA", SqlDbType.Decimal)
        args(2).Value = lEntidad.PORCENTAJEENTREGA
        args(3) = New SqlParameter("@FECHACONTEO", SqlDbType.TinyInt)
        args(3).Value = lEntidad.FECHACONTEO
        args(4) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(4).Value = IIf(lEntidad.IDMODIFICATIVA = Nothing, DBNull.Value, lEntidad.IDMODIFICATIVA)
        args(5) = New SqlParameter("@ESTAHABILITADA", SqlDbType.TinyInt)
        args(5).Value = lEntidad.ESTAHABILITADA
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
        args(14) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(14).Value = lEntidad.RENGLON
        args(15) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(15).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ENTREGACONTRATO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" ENTREGA, ")
        strSQL.Append(" PLAZOENTREGA, ")
        strSQL.Append(" PORCENTAJEENTREGA, ")
        strSQL.Append(" FECHACONTEO, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" ESTAHABILITADA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @RENGLON, ")
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @ENTREGA, ")
        strSQL.Append(" @PLAZOENTREGA, ")
        strSQL.Append(" @PORCENTAJEENTREGA, ")
        strSQL.Append(" @FECHACONTEO, ")
        strSQL.Append(" @IDMODIFICATIVA, ")
        strSQL.Append(" @ESTAHABILITADA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(15) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = lEntidad.RENGLON
        args(4) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDDETALLE
        args(5) = New SqlParameter("@ENTREGA", SqlDbType.TinyInt)
        args(5).Value = lEntidad.ENTREGA
        args(6) = New SqlParameter("@PLAZOENTREGA", SqlDbType.SmallInt)
        args(6).Value = lEntidad.PLAZOENTREGA
        args(7) = New SqlParameter("@PORCENTAJEENTREGA", SqlDbType.Decimal)
        args(7).Value = lEntidad.PORCENTAJEENTREGA
        args(8) = New SqlParameter("@FECHACONTEO", SqlDbType.TinyInt)
        args(8).Value = lEntidad.FECHACONTEO
        args(9) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(9).Value = IIf(lEntidad.IDMODIFICATIVA = Nothing, DBNull.Value, lEntidad.IDMODIFICATIVA)
        args(10) = New SqlParameter("@ESTAHABILITADA", SqlDbType.TinyInt)
        args(10).Value = lEntidad.ESTAHABILITADA
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ENTREGACONTRATO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = lEntidad.RENGLON
        args(4) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ENTREGACONTRATO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = lEntidad.RENGLON
        args(4) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDDETALLE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.ENTREGA = IIf(.Item("ENTREGA") Is DBNull.Value, Nothing, .Item("ENTREGA"))
                lEntidad.PLAZOENTREGA = IIf(.Item("PLAZOENTREGA") Is DBNull.Value, Nothing, .Item("PLAZOENTREGA"))
                lEntidad.PORCENTAJEENTREGA = IIf(.Item("PORCENTAJEENTREGA") Is DBNull.Value, Nothing, .Item("PORCENTAJEENTREGA"))
                lEntidad.FECHACONTEO = IIf(.Item("FECHACONTEO") Is DBNull.Value, Nothing, .Item("FECHACONTEO"))
                lEntidad.IDMODIFICATIVA = IIf(.Item("IDMODIFICATIVA") Is DBNull.Value, Nothing, .Item("IDMODIFICATIVA"))
                lEntidad.ESTAHABILITADA = IIf(.Item("ESTAHABILITADA") Is DBNull.Value, Nothing, .Item("ESTAHABILITADA"))
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

        Dim lEntidad As ENTREGACONTRATO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = lEntidad.RENGLON

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64) As listaENTREGACONTRATO

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = RENGLON

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaENTREGACONTRATO

        Try
            Do While dr.Read()
                Dim mEntidad As New ENTREGACONTRATO
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
                mEntidad.RENGLON = RENGLON
                mEntidad.IDDETALLE = IIf(dr("IDDETALLE") Is DBNull.Value, Nothing, dr("IDDETALLE"))
                mEntidad.ENTREGA = IIf(dr("ENTREGA") Is DBNull.Value, Nothing, dr("ENTREGA"))
                mEntidad.PLAZOENTREGA = IIf(dr("PLAZOENTREGA") Is DBNull.Value, Nothing, dr("PLAZOENTREGA"))
                mEntidad.PORCENTAJEENTREGA = IIf(dr("PORCENTAJEENTREGA") Is DBNull.Value, Nothing, dr("PORCENTAJEENTREGA"))
                mEntidad.FECHACONTEO = IIf(dr("FECHACONTEO") Is DBNull.Value, Nothing, dr("FECHACONTEO"))
                mEntidad.IDMODIFICATIVA = IIf(dr("IDMODIFICATIVA") Is DBNull.Value, Nothing, dr("IDMODIFICATIVA"))
                mEntidad.ESTAHABILITADA = IIf(dr("ESTAHABILITADA") Is DBNull.Value, Nothing, dr("ESTAHABILITADA"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = RENGLON

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = RENGLON

        Dim tables(0) As String
        tables(0) = New String("ENTREGACONTRATO")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" ENTREGA, ")
        strSQL.Append(" PLAZOENTREGA, ")
        strSQL.Append(" PORCENTAJEENTREGA, ")
        strSQL.Append(" FECHACONTEO, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" ESTAHABILITADA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO ")

    End Sub

#End Region

End Class
