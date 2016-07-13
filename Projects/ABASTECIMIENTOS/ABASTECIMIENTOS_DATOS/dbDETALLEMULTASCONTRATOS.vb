Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLEMULTASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_DETALLEMULTASCONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLEMULTASCONTRATOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEMULTASCONTRATOS
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
        strSQL.Append("UPDATE SAB_UACI_DETALLEMULTASCONTRATOS ")
        strSQL.Append(" SET RENGLON = @RENGLON, ")
        strSQL.Append(" PRECIOUNITARIO = @PRECIOUNITARIO, ")
        strSQL.Append(" CANTIDADCONTRATADA = @CANTIDADCONTRATADA, ")
        strSQL.Append(" CANTIDADENTREGAATRASO = @CANTIDADENTREGAATRASO, ")
        strSQL.Append(" FECHAENTREGAPROGRAMADA = @FECHAENTREGAPROGRAMADA, ")
        strSQL.Append(" FECHAENTREGAREAL = @FECHAENTREGAREAL, ")
        strSQL.Append(" DIASATRASO = @DIASATRASO, ")
        strSQL.Append(" MONTOINCUMPLIDO = @MONTOINCUMPLIDO, ")
        strSQL.Append(" PORCENTAJECALCULO = @PORCENTAJECALCULO, ")
        strSQL.Append(" ENTREGA = @ENTREGA, ")
        strSQL.Append(" TIPOINCUMPLIMIENTO = @TIPOINCUMPLIMIENTO, ")
        strSQL.Append(" JUSTIFICACION = @JUSTIFICACION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMULTA = @IDMULTA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(21) As SqlParameter
        args(0) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(0).Value = lEntidad.RENGLON
        args(1) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Decimal)
        args(1).Value = lEntidad.PRECIOUNITARIO
        args(2) = New SqlParameter("@CANTIDADCONTRATADA", SqlDbType.Decimal)
        args(2).Value = lEntidad.CANTIDADCONTRATADA
        args(3) = New SqlParameter("@CANTIDADENTREGAATRASO", SqlDbType.Decimal)
        args(3).Value = lEntidad.CANTIDADENTREGAATRASO
        args(4) = New SqlParameter("@FECHAENTREGAPROGRAMADA", SqlDbType.DateTime)
        args(4).Value = lEntidad.FECHAENTREGAPROGRAMADA
        args(5) = New SqlParameter("@FECHAENTREGAREAL", SqlDbType.DateTime)
        args(5).Value = lEntidad.FECHAENTREGAREAL
        args(6) = New SqlParameter("@DIASATRASO", SqlDbType.Int)
        args(6).Value = lEntidad.DIASATRASO
        args(7) = New SqlParameter("@MONTOINCUMPLIDO", SqlDbType.Decimal)
        args(7).Value = lEntidad.MONTOINCUMPLIDO
        args(8) = New SqlParameter("@PORCENTAJECALCULO", SqlDbType.Decimal)
        args(8).Value = lEntidad.PORCENTAJECALCULO
        args(9) = New SqlParameter("@ENTREGA", SqlDbType.Int)
        args(9).Value = IIf(lEntidad.ENTREGA = Nothing, DBNull.Value, lEntidad.ENTREGA)
        args(10) = New SqlParameter("@TIPOINCUMPLIMIENTO", SqlDbType.SmallInt)
        args(10).Value = IIf(lEntidad.TIPOINCUMPLIMIENTO = Nothing, DBNull.Value, lEntidad.TIPOINCUMPLIMIENTO)
        args(11) = New SqlParameter("@JUSTIFICACION", SqlDbType.VarChar)
        args(11).Value = IIf(lEntidad.JUSTIFICACION = Nothing, DBNull.Value, lEntidad.JUSTIFICACION)
        args(12) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(13) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(14) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(15) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(15).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(16) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(16).Value = lEntidad.ESTASINCRONIZADA
        args(17) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(17).Value = lEntidad.IDESTABLECIMIENTO
        args(18) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(18).Value = lEntidad.IDPROVEEDOR
        args(19) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(19).Value = lEntidad.IDCONTRATO
        args(20) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(20).Value = lEntidad.IDMULTA
        args(21) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(21).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEMULTASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_DETALLEMULTASCONTRATOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDMULTA, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" PRECIOUNITARIO, ")
        strSQL.Append(" CANTIDADCONTRATADA, ")
        strSQL.Append(" CANTIDADENTREGAATRASO, ")
        strSQL.Append(" FECHAENTREGAPROGRAMADA, ")
        strSQL.Append(" FECHAENTREGAREAL, ")
        strSQL.Append(" DIASATRASO, ")
        strSQL.Append(" MONTOINCUMPLIDO, ")
        strSQL.Append(" PORCENTAJECALCULO, ")
        strSQL.Append(" ENTREGA, ")
        strSQL.Append(" TIPOINCUMPLIMIENTO, ")
        strSQL.Append(" JUSTIFICACION, ")
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
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @RENGLON, ")
        strSQL.Append(" @PRECIOUNITARIO, ")
        strSQL.Append(" @CANTIDADCONTRATADA, ")
        strSQL.Append(" @CANTIDADENTREGAATRASO, ")
        strSQL.Append(" @FECHAENTREGAPROGRAMADA, ")
        strSQL.Append(" @FECHAENTREGAREAL, ")
        strSQL.Append(" @DIASATRASO, ")
        strSQL.Append(" @MONTOINCUMPLIDO, ")
        strSQL.Append(" @PORCENTAJECALCULO, ")
        strSQL.Append(" @ENTREGA, ")
        strSQL.Append(" @TIPOINCUMPLIMIENTO, ")
        strSQL.Append(" @JUSTIFICACION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(21) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDMULTA
        args(4) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDDETALLE
        args(5) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(5).Value = lEntidad.RENGLON
        args(6) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Decimal)
        args(6).Value = lEntidad.PRECIOUNITARIO
        args(7) = New SqlParameter("@CANTIDADCONTRATADA", SqlDbType.Decimal)
        args(7).Value = lEntidad.CANTIDADCONTRATADA
        args(8) = New SqlParameter("@CANTIDADENTREGAATRASO", SqlDbType.Decimal)
        args(8).Value = lEntidad.CANTIDADENTREGAATRASO
        args(9) = New SqlParameter("@FECHAENTREGAPROGRAMADA", SqlDbType.DateTime)
        args(9).Value = lEntidad.FECHAENTREGAPROGRAMADA
        args(10) = New SqlParameter("@FECHAENTREGAREAL", SqlDbType.DateTime)
        args(10).Value = lEntidad.FECHAENTREGAREAL
        args(11) = New SqlParameter("@DIASATRASO", SqlDbType.Int)
        args(11).Value = lEntidad.DIASATRASO
        args(12) = New SqlParameter("@MONTOINCUMPLIDO", SqlDbType.Decimal)
        args(12).Value = lEntidad.MONTOINCUMPLIDO
        args(13) = New SqlParameter("@PORCENTAJECALCULO", SqlDbType.Decimal)
        args(13).Value = lEntidad.PORCENTAJECALCULO
        args(14) = New SqlParameter("@ENTREGA", SqlDbType.Int)
        args(14).Value = IIf(lEntidad.ENTREGA = Nothing, DBNull.Value, lEntidad.ENTREGA)
        args(15) = New SqlParameter("@TIPOINCUMPLIMIENTO", SqlDbType.SmallInt)
        args(15).Value = IIf(lEntidad.TIPOINCUMPLIMIENTO = Nothing, DBNull.Value, lEntidad.TIPOINCUMPLIMIENTO)
        args(16) = New SqlParameter("@JUSTIFICACION", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.JUSTIFICACION = Nothing, DBNull.Value, lEntidad.JUSTIFICACION)
        args(17) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(18) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(19) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(19).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(20) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(20).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(21) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(21).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEMULTASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_DETALLEMULTASCONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMULTA = @IDMULTA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDMULTA
        args(4) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEMULTASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMULTA = @IDMULTA ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDMULTA
        args(4) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(4).Value = lEntidad.IDDETALLE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.RENGLON = IIf(.Item("RENGLON") Is DBNull.Value, Nothing, .Item("RENGLON"))
                lEntidad.PRECIOUNITARIO = IIf(.Item("PRECIOUNITARIO") Is DBNull.Value, Nothing, .Item("PRECIOUNITARIO"))
                lEntidad.CANTIDADCONTRATADA = IIf(.Item("CANTIDADCONTRATADA") Is DBNull.Value, Nothing, .Item("CANTIDADCONTRATADA"))
                lEntidad.CANTIDADENTREGAATRASO = IIf(.Item("CANTIDADENTREGAATRASO") Is DBNull.Value, Nothing, .Item("CANTIDADENTREGAATRASO"))
                lEntidad.FECHAENTREGAPROGRAMADA = IIf(.Item("FECHAENTREGAPROGRAMADA") Is DBNull.Value, Nothing, .Item("FECHAENTREGAPROGRAMADA"))
                lEntidad.FECHAENTREGAREAL = IIf(.Item("FECHAENTREGAREAL") Is DBNull.Value, Nothing, .Item("FECHAENTREGAREAL"))
                lEntidad.DIASATRASO = IIf(.Item("DIASATRASO") Is DBNull.Value, Nothing, .Item("DIASATRASO"))
                lEntidad.MONTOINCUMPLIDO = IIf(.Item("MONTOINCUMPLIDO") Is DBNull.Value, Nothing, .Item("MONTOINCUMPLIDO"))
                lEntidad.PORCENTAJECALCULO = IIf(.Item("PORCENTAJECALCULO") Is DBNull.Value, Nothing, .Item("PORCENTAJECALCULO"))
                lEntidad.ENTREGA = IIf(.Item("ENTREGA") Is DBNull.Value, Nothing, .Item("ENTREGA"))
                lEntidad.TIPOINCUMPLIMIENTO = IIf(.Item("TIPOINCUMPLIMIENTO") Is DBNull.Value, Nothing, .Item("TIPOINCUMPLIMIENTO"))
                lEntidad.JUSTIFICACION = IIf(.Item("JUSTIFICACION") Is DBNull.Value, Nothing, .Item("JUSTIFICACION"))
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

        Dim lEntidad As DETALLEMULTASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_DETALLEMULTASCONTRATOS ")
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

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMULTA As Int64) As listaDETALLEMULTASCONTRATOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMULTA = @IDMULTA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(3).Value = IDMULTA

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLEMULTASCONTRATOS

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLEMULTASCONTRATOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
                mEntidad.IDMULTA = IDMULTA
                mEntidad.IDDETALLE = IIf(dr("IDDETALLE") Is DBNull.Value, Nothing, dr("IDDETALLE"))
                mEntidad.RENGLON = IIf(dr("RENGLON") Is DBNull.Value, Nothing, dr("RENGLON"))
                mEntidad.PRECIOUNITARIO = IIf(dr("PRECIOUNITARIO") Is DBNull.Value, Nothing, dr("PRECIOUNITARIO"))
                mEntidad.CANTIDADCONTRATADA = IIf(dr("CANTIDADCONTRATADA") Is DBNull.Value, Nothing, dr("CANTIDADCONTRATADA"))
                mEntidad.CANTIDADENTREGAATRASO = IIf(dr("CANTIDADENTREGAATRASO") Is DBNull.Value, Nothing, dr("CANTIDADENTREGAATRASO"))
                mEntidad.FECHAENTREGAPROGRAMADA = IIf(dr("FECHAENTREGAPROGRAMADA") Is DBNull.Value, Nothing, dr("FECHAENTREGAPROGRAMADA"))
                mEntidad.FECHAENTREGAREAL = IIf(dr("FECHAENTREGAREAL") Is DBNull.Value, Nothing, dr("FECHAENTREGAREAL"))
                mEntidad.DIASATRASO = IIf(dr("DIASATRASO") Is DBNull.Value, Nothing, dr("DIASATRASO"))
                mEntidad.MONTOINCUMPLIDO = IIf(dr("MONTOINCUMPLIDO") Is DBNull.Value, Nothing, dr("MONTOINCUMPLIDO"))
                mEntidad.PORCENTAJECALCULO = IIf(dr("PORCENTAJECALCULO") Is DBNull.Value, Nothing, dr("PORCENTAJECALCULO"))
                mEntidad.ENTREGA = IIf(dr("ENTREGA") Is DBNull.Value, Nothing, dr("ENTREGA"))
                mEntidad.TIPOINCUMPLIMIENTO = IIf(dr("TIPOINCUMPLIMIENTO") Is DBNull.Value, Nothing, dr("TIPOINCUMPLIMIENTO"))
                mEntidad.JUSTIFICACION = IIf(dr("JUSTIFICACION") Is DBNull.Value, Nothing, dr("JUSTIFICACION"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMULTA As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMULTA = @IDMULTA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(3).Value = IDMULTA

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMULTA As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDMULTA = @IDMULTA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.BigInt)
        args(3).Value = IDMULTA

        Dim tables(0) As String
        tables(0) = New String("DETALLEMULTASCONTRATOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDMULTA, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" PRECIOUNITARIO, ")
        strSQL.Append(" CANTIDADCONTRATADA, ")
        strSQL.Append(" CANTIDADENTREGAATRASO, ")
        strSQL.Append(" FECHAENTREGAPROGRAMADA, ")
        strSQL.Append(" FECHAENTREGAREAL, ")
        strSQL.Append(" DIASATRASO, ")
        strSQL.Append(" MONTOINCUMPLIDO, ")
        strSQL.Append(" PORCENTAJECALCULO, ")
        strSQL.Append(" ENTREGA, ")
        strSQL.Append(" TIPOINCUMPLIMIENTO, ")
        strSQL.Append(" JUSTIFICACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_DETALLEMULTASCONTRATOS ")

    End Sub

#End Region

End Class
