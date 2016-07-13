Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbOFERTAPROCESOCOMPRA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_OFERTAPROCESOCOMPRA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	21/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbOFERTAPROCESOCOMPRA
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OFERTAPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_OFERTAPROCESOCOMPRA ")
        strSQL.Append(" SET NOMBREREPRESENTANTE = @NOMBREREPRESENTANTE, ")
        strSQL.Append(" MONTOOFERTA = @MONTOOFERTA, ")
        strSQL.Append(" MONTOGARANTIA = @MONTOGARANTIA, ")
        strSQL.Append(" ESTAHABILITADO = @ESTAHABILITADO, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" ACTIVOCIRCULANTE = @ACTIVOCIRCULANTE, ")
        strSQL.Append(" PASIVOCIRCULANTE = @PASIVOCIRCULANTE, ")
        strSQL.Append(" ACTIVOTOTAL = @ACTIVOTOTAL, ")
        strSQL.Append(" PASIVOTOTAL = @PASIVOTOTAL, ")
        strSQL.Append(" PRESENTAREFERENCIASBANCARIAS = @PRESENTAREFERENCIASBANCARIAS, ")
        strSQL.Append(" OBSERVACIONDOCUMENTO = @OBSERVACIONDOCUMENTO, ")
        strSQL.Append(" FECHAEXAMEN = @FECHAEXAMEN, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(19) As SqlParameter
        args(0) = New SqlParameter("@NOMBREREPRESENTANTE", SqlDbType.VarChar)
        args(0).Value = IIf(lEntidad.NOMBREREPRESENTANTE = Nothing, DBNull.Value, lEntidad.NOMBREREPRESENTANTE)
        args(1) = New SqlParameter("@MONTOOFERTA", SqlDbType.Decimal)
        args(1).Value = lEntidad.MONTOOFERTA
        args(2) = New SqlParameter("@MONTOGARANTIA", SqlDbType.Decimal)
        args(2).Value = lEntidad.MONTOGARANTIA
        args(3) = New SqlParameter("@ESTAHABILITADO", SqlDbType.TinyInt)
        args(3).Value = IIf(lEntidad.ESTAHABILITADO = Nothing, DBNull.Value, lEntidad.ESTAHABILITADO)
        args(4) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(5) = New SqlParameter("@ACTIVOCIRCULANTE", SqlDbType.Decimal)
        args(5).Value = IIf(lEntidad.ACTIVOCIRCULANTE = Nothing, DBNull.Value, lEntidad.ACTIVOCIRCULANTE)
        args(6) = New SqlParameter("@PASIVOCIRCULANTE", SqlDbType.Decimal)
        args(6).Value = IIf(lEntidad.PASIVOCIRCULANTE = Nothing, DBNull.Value, lEntidad.PASIVOCIRCULANTE)
        args(7) = New SqlParameter("@ACTIVOTOTAL", SqlDbType.Decimal)
        args(7).Value = IIf(lEntidad.ACTIVOTOTAL = Nothing, DBNull.Value, lEntidad.ACTIVOTOTAL)
        args(8) = New SqlParameter("@PASIVOTOTAL", SqlDbType.Decimal)
        args(8).Value = IIf(lEntidad.PASIVOTOTAL = Nothing, DBNull.Value, lEntidad.PASIVOTOTAL)
        args(9) = New SqlParameter("@PRESENTAREFERENCIASBANCARIAS", SqlDbType.TinyInt)
        args(9).Value = lEntidad.PRESENTAREFERENCIASBANCARIAS
        args(10) = New SqlParameter("@OBSERVACIONDOCUMENTO", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.OBSERVACIONDOCUMENTO = Nothing, DBNull.Value, lEntidad.OBSERVACIONDOCUMENTO)
        args(11) = New SqlParameter("@FECHAEXAMEN", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.FECHAEXAMEN = Nothing, DBNull.Value, lEntidad.FECHAEXAMEN)
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
        args(18) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(18).Value = lEntidad.IDPROCESOCOMPRA
        args(19) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(19).Value = lEntidad.IDPROVEEDOR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OFERTAPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_OFERTAPROCESOCOMPRA ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" NOMBREREPRESENTANTE, ")
        strSQL.Append(" MONTOOFERTA, ")
        strSQL.Append(" MONTOGARANTIA, ")
        strSQL.Append(" ESTAHABILITADO, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" ACTIVOCIRCULANTE, ")
        strSQL.Append(" PASIVOCIRCULANTE, ")
        strSQL.Append(" ACTIVOTOTAL, ")
        strSQL.Append(" PASIVOTOTAL, ")
        strSQL.Append(" PRESENTAREFERENCIASBANCARIAS, ")
        strSQL.Append(" OBSERVACIONDOCUMENTO, ")
        strSQL.Append(" FECHAEXAMEN, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @NOMBREREPRESENTANTE, ")
        strSQL.Append(" @MONTOOFERTA, ")
        strSQL.Append(" @MONTOGARANTIA, ")
        strSQL.Append(" @ESTAHABILITADO, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @ACTIVOCIRCULANTE, ")
        strSQL.Append(" @PASIVOCIRCULANTE, ")
        strSQL.Append(" @ACTIVOTOTAL, ")
        strSQL.Append(" @PASIVOTOTAL, ")
        strSQL.Append(" @PRESENTAREFERENCIASBANCARIAS, ")
        strSQL.Append(" @OBSERVACIONDOCUMENTO, ")
        strSQL.Append(" @FECHAEXAMEN, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(19) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@NOMBREREPRESENTANTE", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.NOMBREREPRESENTANTE = Nothing, DBNull.Value, lEntidad.NOMBREREPRESENTANTE)
        args(4) = New SqlParameter("@MONTOOFERTA", SqlDbType.Decimal)
        args(4).Value = lEntidad.MONTOOFERTA
        args(5) = New SqlParameter("@MONTOGARANTIA", SqlDbType.Decimal)
        args(5).Value = lEntidad.MONTOGARANTIA
        args(6) = New SqlParameter("@ESTAHABILITADO", SqlDbType.TinyInt)
        args(6).Value = IIf(lEntidad.ESTAHABILITADO = Nothing, DBNull.Value, lEntidad.ESTAHABILITADO)
        args(7) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(8) = New SqlParameter("@ACTIVOCIRCULANTE", SqlDbType.Decimal)
        args(8).Value = IIf(lEntidad.ACTIVOCIRCULANTE = Nothing, DBNull.Value, lEntidad.ACTIVOCIRCULANTE)
        args(9) = New SqlParameter("@PASIVOCIRCULANTE", SqlDbType.Decimal)
        args(9).Value = IIf(lEntidad.PASIVOCIRCULANTE = Nothing, DBNull.Value, lEntidad.PASIVOCIRCULANTE)
        args(10) = New SqlParameter("@ACTIVOTOTAL", SqlDbType.Decimal)
        args(10).Value = IIf(lEntidad.ACTIVOTOTAL = Nothing, DBNull.Value, lEntidad.ACTIVOTOTAL)
        args(11) = New SqlParameter("@PASIVOTOTAL", SqlDbType.Decimal)
        args(11).Value = IIf(lEntidad.PASIVOTOTAL = Nothing, DBNull.Value, lEntidad.PASIVOTOTAL)
        args(12) = New SqlParameter("@PRESENTAREFERENCIASBANCARIAS", SqlDbType.TinyInt)
        args(12).Value = lEntidad.PRESENTAREFERENCIASBANCARIAS
        args(13) = New SqlParameter("@OBSERVACIONDOCUMENTO", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.OBSERVACIONDOCUMENTO = Nothing, DBNull.Value, lEntidad.OBSERVACIONDOCUMENTO)
        args(14) = New SqlParameter("@FECHAEXAMEN", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.FECHAEXAMEN = Nothing, DBNull.Value, lEntidad.FECHAEXAMEN)
        args(15) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(15).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(16) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(17) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(18) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(19) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(19).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OFERTAPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_OFERTAPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As OFERTAPROCESOCOMPRA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.NOMBREREPRESENTANTE = IIf(.Item("NOMBREREPRESENTANTE") Is DBNull.Value, Nothing, .Item("NOMBREREPRESENTANTE"))
                lEntidad.MONTOOFERTA = IIf(.Item("MONTOOFERTA") Is DBNull.Value, Nothing, .Item("MONTOOFERTA"))
                lEntidad.MONTOGARANTIA = IIf(.Item("MONTOGARANTIA") Is DBNull.Value, Nothing, .Item("MONTOGARANTIA"))
                lEntidad.ESTAHABILITADO = IIf(.Item("ESTAHABILITADO") Is DBNull.Value, Nothing, .Item("ESTAHABILITADO"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
                lEntidad.ACTIVOCIRCULANTE = IIf(.Item("ACTIVOCIRCULANTE") Is DBNull.Value, Nothing, .Item("ACTIVOCIRCULANTE"))
                lEntidad.PASIVOCIRCULANTE = IIf(.Item("PASIVOCIRCULANTE") Is DBNull.Value, Nothing, .Item("PASIVOCIRCULANTE"))
                lEntidad.ACTIVOTOTAL = IIf(.Item("ACTIVOTOTAL") Is DBNull.Value, Nothing, .Item("ACTIVOTOTAL"))
                lEntidad.PASIVOTOTAL = IIf(.Item("PASIVOTOTAL") Is DBNull.Value, Nothing, .Item("PASIVOTOTAL"))
                lEntidad.PRESENTAREFERENCIASBANCARIAS = IIf(.Item("PRESENTAREFERENCIASBANCARIAS") Is DBNull.Value, Nothing, .Item("PRESENTAREFERENCIASBANCARIAS"))
                lEntidad.OBSERVACIONDOCUMENTO = IIf(.Item("OBSERVACIONDOCUMENTO") Is DBNull.Value, Nothing, .Item("OBSERVACIONDOCUMENTO"))
                lEntidad.FECHAEXAMEN = IIf(.Item("FECHAEXAMEN") Is DBNull.Value, Nothing, .Item("FECHAEXAMEN"))
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

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As listaOFERTAPROCESOCOMPRA

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaOFERTAPROCESOCOMPRA

        Try
            Do While dr.Read()
                Dim mEntidad As New OFERTAPROCESOCOMPRA
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.NOMBREREPRESENTANTE = IIf(dr("NOMBREREPRESENTANTE") Is DBNull.Value, Nothing, dr("NOMBREREPRESENTANTE"))
                mEntidad.MONTOOFERTA = IIf(dr("MONTOOFERTA") Is DBNull.Value, Nothing, dr("MONTOOFERTA"))
                mEntidad.MONTOGARANTIA = IIf(dr("MONTOGARANTIA") Is DBNull.Value, Nothing, dr("MONTOGARANTIA"))
                mEntidad.ESTAHABILITADO = IIf(dr("ESTAHABILITADO") Is DBNull.Value, Nothing, dr("ESTAHABILITADO"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.ACTIVOCIRCULANTE = IIf(dr("ACTIVOCIRCULANTE") Is DBNull.Value, Nothing, dr("ACTIVOCIRCULANTE"))
                mEntidad.PASIVOCIRCULANTE = IIf(dr("PASIVOCIRCULANTE") Is DBNull.Value, Nothing, dr("PASIVOCIRCULANTE"))
                mEntidad.ACTIVOTOTAL = IIf(dr("ACTIVOTOTAL") Is DBNull.Value, Nothing, dr("ACTIVOTOTAL"))
                mEntidad.PASIVOTOTAL = IIf(dr("PASIVOTOTAL") Is DBNull.Value, Nothing, dr("PASIVOTOTAL"))
                mEntidad.PRESENTAREFERENCIASBANCARIAS = IIf(dr("PRESENTAREFERENCIASBANCARIAS") Is DBNull.Value, Nothing, dr("PRESENTAREFERENCIASBANCARIAS"))
                mEntidad.OBSERVACIONDOCUMENTO = IIf(dr("OBSERVACIONDOCUMENTO") Is DBNull.Value, Nothing, dr("OBSERVACIONDOCUMENTO"))
                mEntidad.FECHAEXAMEN = IIf(dr("FECHAEXAMEN") Is DBNull.Value, Nothing, dr("FECHAEXAMEN"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR

        Dim tables(0) As String
        tables(0) = New String("OFERTAPROCESOCOMPRA")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" NOMBREREPRESENTANTE, ")
        strSQL.Append(" MONTOOFERTA, ")
        strSQL.Append(" MONTOGARANTIA, ")
        strSQL.Append(" ESTAHABILITADO, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" ACTIVOCIRCULANTE, ")
        strSQL.Append(" PASIVOCIRCULANTE, ")
        strSQL.Append(" ACTIVOTOTAL, ")
        strSQL.Append(" PASIVOTOTAL, ")
        strSQL.Append(" PRESENTAREFERENCIASBANCARIAS, ")
        strSQL.Append(" OBSERVACIONDOCUMENTO, ")
        strSQL.Append(" FECHAEXAMEN, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_OFERTAPROCESOCOMPRA ")

    End Sub

#End Region

End Class
