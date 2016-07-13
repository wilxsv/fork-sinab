Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbALMACENESENTREGAMODIFICATIVA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_ALMACENESENTREGAMODIFICATIVA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbALMACENESENTREGAMODIFICATIVA
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALMACENESENTREGAMODIFICATIVA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ALMACENESENTREGAMODIFICATIVA ")
        strSQL.Append(" SET CANTIDAD = @CANTIDAD, ")
        strSQL.Append(" CANTIDADENTREGADA = @CANTIDADENTREGADA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args(0).Value = lEntidad.CANTIDAD
        args(1) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.Decimal)
        args(1).Value = lEntidad.CANTIDADENTREGADA
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
        args(7) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(7).Value = lEntidad.IDESTABLECIMIENTO
        args(8) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(8).Value = lEntidad.IDPROVEEDOR
        args(9) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(9).Value = lEntidad.IDCONTRATO
        args(10) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(10).Value = lEntidad.IDMODIFICATIVA
        args(11) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(11).Value = lEntidad.RENGLON
        args(12) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(12).Value = lEntidad.IDENTREGA
        args(13) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(13).Value = lEntidad.IDALMACENENTREGA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALMACENESENTREGAMODIFICATIVA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_ALMACENESENTREGAMODIFICATIVA ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDENTREGA, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" CANTIDADENTREGADA, ")
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
        strSQL.Append(" @IDENTREGA, ")
        strSQL.Append(" @IDALMACENENTREGA, ")
        strSQL.Append(" @CANTIDAD, ")
        strSQL.Append(" @CANTIDADENTREGADA, ")
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
        args(3) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDMODIFICATIVA
        args(4) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(4).Value = lEntidad.RENGLON
        args(5) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(5).Value = lEntidad.IDENTREGA
        args(6) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(6).Value = lEntidad.IDALMACENENTREGA
        args(7) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args(7).Value = lEntidad.CANTIDAD
        args(8) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.Decimal)
        args(8).Value = lEntidad.CANTIDADENTREGADA
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

        Dim lEntidad As ALMACENESENTREGAMODIFICATIVA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_ALMACENESENTREGAMODIFICATIVA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(6) As SqlParameter
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
        args(5) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(5).Value = lEntidad.IDENTREGA
        args(6) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(6).Value = lEntidad.IDALMACENENTREGA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALMACENESENTREGAMODIFICATIVA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(6) As SqlParameter
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
        args(5) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(5).Value = lEntidad.IDENTREGA
        args(6) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(6).Value = lEntidad.IDALMACENENTREGA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.CANTIDAD = IIf(.Item("CANTIDAD") Is DBNull.Value, Nothing, .Item("CANTIDAD"))
                lEntidad.CANTIDADENTREGADA = IIf(.Item("CANTIDADENTREGADA") Is DBNull.Value, Nothing, .Item("CANTIDADENTREGADA"))
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

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64, ByVal IDENTREGA As Byte, ByVal IDALMACENENTREGA As Int32) As listaALMACENESENTREGAMODIFICATIVA

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(6) As SqlParameter
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
        args(5) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(5).Value = IDENTREGA
        args(6) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(6).Value = IDALMACENENTREGA

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaALMACENESENTREGAMODIFICATIVA

        Try
            Do While dr.Read()
                Dim mEntidad As New ALMACENESENTREGAMODIFICATIVA
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
                mEntidad.IDMODIFICATIVA = IDMODIFICATIVA
                mEntidad.RENGLON = RENGLON
                mEntidad.IDENTREGA = IDENTREGA
                mEntidad.IDALMACENENTREGA = IDALMACENENTREGA
                mEntidad.CANTIDAD = IIf(dr("CANTIDAD") Is DBNull.Value, Nothing, dr("CANTIDAD"))
                mEntidad.CANTIDADENTREGADA = IIf(dr("CANTIDADENTREGADA") Is DBNull.Value, Nothing, dr("CANTIDADENTREGADA"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64, ByVal IDENTREGA As Byte, ByVal IDALMACENENTREGA As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(6) As SqlParameter
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
        args(5) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(5).Value = IDENTREGA
        args(6) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(6).Value = IDALMACENENTREGA

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64, ByVal IDENTREGA As Byte, ByVal IDALMACENENTREGA As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMODIFICATIVA = @IDMODIFICATIVA ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDENTREGA = @IDENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(6) As SqlParameter
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
        args(5) = New SqlParameter("@IDENTREGA", SqlDbType.TinyInt)
        args(5).Value = IDENTREGA
        args(6) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(6).Value = IDALMACENENTREGA

        Dim tables(0) As String
        tables(0) = New String("ALMACENESENTREGAMODIFICATIVA")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDENTREGA, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" CANTIDADENTREGADA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_ALMACENESENTREGAMODIFICATIVA ")

    End Sub

#End Region

End Class
