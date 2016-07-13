Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLEALMACENESENTREGACONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_DETALLEALMACENESENTREGACONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLEALMACENESENTREGACONTRATOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEALMACENESENTREGACONTRATOS
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
        strSQL.Append("UPDATE SAB_UACI_DETALLEALMACENESENTREGACONTRATOS ")
        strSQL.Append(" SET CANTIDADENTREGADA = @CANTIDADENTREGADA, ")
        strSQL.Append(" FECHAENTREGA = @FECHAENTREGA, ")
        strSQL.Append(" ANULADA = @ANULADA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLEENTREGA = @IDDETALLEENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(14) As SqlParameter
        args(0) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.Decimal)
        args(0).Value = lEntidad.CANTIDADENTREGADA
        args(1) = New SqlParameter("@FECHAENTREGA", SqlDbType.DateTime)
        args(1).Value = lEntidad.FECHAENTREGA
        args(2) = New SqlParameter("@ANULADA", SqlDbType.TinyInt)
        args(2).Value = lEntidad.ANULADA
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
        args(11) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(11).Value = lEntidad.RENGLON
        args(12) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.BigInt)
        args(12).Value = lEntidad.IDDETALLEENTREGA
        args(13) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(13).Value = lEntidad.IDALMACENENTREGA
        args(14) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(14).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEALMACENESENTREGACONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_DETALLEALMACENESENTREGACONTRATOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDDETALLEENTREGA, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" CANTIDADENTREGADA, ")
        strSQL.Append(" FECHAENTREGA, ")
        strSQL.Append(" ANULADA, ")
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
        strSQL.Append(" @IDDETALLEENTREGA, ")
        strSQL.Append(" @IDALMACENENTREGA, ")
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @CANTIDADENTREGADA, ")
        strSQL.Append(" @FECHAENTREGA, ")
        strSQL.Append(" @ANULADA, ")
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
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = lEntidad.RENGLON
        args(4) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDDETALLEENTREGA
        args(5) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(5).Value = lEntidad.IDALMACENENTREGA
        args(6) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(6).Value = lEntidad.IDDETALLE
        args(7) = New SqlParameter("@CANTIDADENTREGADA", SqlDbType.Decimal)
        args(7).Value = lEntidad.CANTIDADENTREGADA
        args(8) = New SqlParameter("@FECHAENTREGA", SqlDbType.DateTime)
        args(8).Value = lEntidad.FECHAENTREGA
        args(9) = New SqlParameter("@ANULADA", SqlDbType.TinyInt)
        args(9).Value = lEntidad.ANULADA
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

        Dim lEntidad As DETALLEALMACENESENTREGACONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_DETALLEALMACENESENTREGACONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLEENTREGA = @IDDETALLEENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = lEntidad.RENGLON
        args(4) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDDETALLEENTREGA
        args(5) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(5).Value = lEntidad.IDALMACENENTREGA
        args(6) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(6).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEALMACENESENTREGACONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLEENTREGA = @IDDETALLEENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = lEntidad.RENGLON
        args(4) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDDETALLEENTREGA
        args(5) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(5).Value = lEntidad.IDALMACENENTREGA
        args(6) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(6).Value = lEntidad.IDDETALLE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.CANTIDADENTREGADA = IIf(.Item("CANTIDADENTREGADA") Is DBNull.Value, Nothing, .Item("CANTIDADENTREGADA"))
                lEntidad.FECHAENTREGA = IIf(.Item("FECHAENTREGA") Is DBNull.Value, Nothing, .Item("FECHAENTREGA"))
                lEntidad.ANULADA = IIf(.Item("ANULADA") Is DBNull.Value, Nothing, .Item("ANULADA"))
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

        Dim lEntidad As DETALLEALMACENESENTREGACONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_DETALLEALMACENESENTREGACONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLEENTREGA = @IDDETALLEENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = lEntidad.RENGLON
        args(4) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDDETALLEENTREGA
        args(5) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(5).Value = lEntidad.IDALMACENENTREGA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDDETALLEENTREGA As Int64, ByVal IDALMACENENTREGA As Int32) As listaDETALLEALMACENESENTREGACONTRATOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLEENTREGA = @IDDETALLEENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = RENGLON
        args(4) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.BigInt)
        args(4).Value = IDDETALLEENTREGA
        args(5) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(5).Value = IDALMACENENTREGA

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLEALMACENESENTREGACONTRATOS

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLEALMACENESENTREGACONTRATOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
                mEntidad.RENGLON = RENGLON
                mEntidad.IDDETALLEENTREGA = IDDETALLEENTREGA
                mEntidad.IDALMACENENTREGA = IDALMACENENTREGA
                mEntidad.IDDETALLE = IIf(dr("IDDETALLE") Is DBNull.Value, Nothing, dr("IDDETALLE"))
                mEntidad.CANTIDADENTREGADA = IIf(dr("CANTIDADENTREGADA") Is DBNull.Value, Nothing, dr("CANTIDADENTREGADA"))
                mEntidad.FECHAENTREGA = IIf(dr("FECHAENTREGA") Is DBNull.Value, Nothing, dr("FECHAENTREGA"))
                mEntidad.ANULADA = IIf(dr("ANULADA") Is DBNull.Value, Nothing, dr("ANULADA"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDDETALLEENTREGA As Int64, ByVal IDALMACENENTREGA As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLEENTREGA = @IDDETALLEENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = RENGLON
        args(4) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.BigInt)
        args(4).Value = IDDETALLEENTREGA
        args(5) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(5).Value = IDALMACENENTREGA

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDDETALLEENTREGA As Int64, ByVal IDALMACENENTREGA As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND RENGLON = @RENGLON ")
        strSQL.Append(" AND IDDETALLEENTREGA = @IDDETALLEENTREGA ")
        strSQL.Append(" AND IDALMACENENTREGA = @IDALMACENENTREGA ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = RENGLON
        args(4) = New SqlParameter("@IDDETALLEENTREGA", SqlDbType.BigInt)
        args(4).Value = IDDETALLEENTREGA
        args(5) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(5).Value = IDALMACENENTREGA

        Dim tables(0) As String
        tables(0) = New String("DETALLEALMACENESENTREGACONTRATOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDDETALLEENTREGA, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" CANTIDADENTREGADA, ")
        strSQL.Append(" FECHAENTREGA, ")
        strSQL.Append(" ANULADA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_DETALLEALMACENESENTREGACONTRATOS ")

    End Sub

#End Region

End Class
