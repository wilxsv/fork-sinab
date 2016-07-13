Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLEOFERTA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla DETALLEOFERTA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	12/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLEOFERTA
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEOFERTA
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
        strSQL.Append("UPDATE SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" SET RENGLON = @RENGLON, ")
        strSQL.Append(" CORRELATIVORENGLON = @CORRELATIVORENGLON, ")
        strSQL.Append(" CASAREPRESENTADA = @CASAREPRESENTADA, ")
        strSQL.Append(" MARCA = @MARCA, ")
        strSQL.Append(" ORIGEN = @ORIGEN, ")
        strSQL.Append(" DESCRIPCIONPROVEEDOR = @DESCRIPCIONPROVEEDOR, ")
        strSQL.Append(" VENCIMIENTO = @VENCIMIENTO, ")
        strSQL.Append(" IDUNIDADMEDIDA = @IDUNIDADMEDIDA, ")
        strSQL.Append(" CANTIDAD = @CANTIDAD, ")
        strSQL.Append(" PRECIOUNITARIO = @PRECIOUNITARIO, ")
        strSQL.Append(" PLAZOENTREGA = @PLAZOENTREGA, ")
        strSQL.Append(" NUMEROCSSP = @NUMEROCSSP, ")
        strSQL.Append(" VIGENCIA = @VIGENCIA, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" OBSERVACIONDOCUMENTO = @OBSERVACIONDOCUMENTO, ")
        strSQL.Append(" IDESTADOCALIFICACION = @IDESTADOCALIFICACION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(24) As SqlParameter
        args(0) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(0).Value = lEntidad.RENGLON
        args(1) = New SqlParameter("@CORRELATIVORENGLON", SqlDbType.SmallInt)
        args(1).Value = lEntidad.CORRELATIVORENGLON
        args(2) = New SqlParameter("@CASAREPRESENTADA", SqlDbType.VarChar)
        args(2).Value = lEntidad.CASAREPRESENTADA
        args(3) = New SqlParameter("@MARCA", SqlDbType.VarChar)
        args(3).Value = lEntidad.MARCA
        args(4) = New SqlParameter("@ORIGEN", SqlDbType.VarChar)
        args(4).Value = lEntidad.ORIGEN
        args(5) = New SqlParameter("@DESCRIPCIONPROVEEDOR", SqlDbType.VarChar)
        args(5).Value = IIf(IsNothing(lEntidad.DESCRIPCIONPROVEEDOR), DBNull.Value, lEntidad.DESCRIPCIONPROVEEDOR)
        args(6) = New SqlParameter("@VENCIMIENTO", SqlDbType.VarChar)
        args(6).Value = lEntidad.VENCIMIENTO
        args(7) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(7).Value = lEntidad.IDUNIDADMEDIDA
        args(8) = New SqlParameter("@CANTIDAD", SqlDbType.BigInt)
        args(8).Value = lEntidad.CANTIDAD
        args(9) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Decimal)
        args(9).Value = lEntidad.PRECIOUNITARIO
        args(10) = New SqlParameter("@PLAZOENTREGA", SqlDbType.VarChar)
        args(10).Value = lEntidad.PLAZOENTREGA
        args(11) = New SqlParameter("@NUMEROCSSP", SqlDbType.VarChar)
        args(11).Value = IIf(IsNothing(lEntidad.NUMEROCSSP), DBNull.Value, lEntidad.NUMEROCSSP)
        args(12) = New SqlParameter("@VIGENCIA", SqlDbType.VarChar)
        args(12).Value = lEntidad.VIGENCIA
        args(13) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(13).Value = IIf(IsNothing(lEntidad.OBSERVACION), DBNull.Value, lEntidad.OBSERVACION)
        args(14) = New SqlParameter("@OBSERVACIONDOCUMENTO", SqlDbType.VarChar)
        args(14).Value = IIf(IsNothing(lEntidad.OBSERVACIONDOCUMENTO), DBNull.Value, lEntidad.OBSERVACIONDOCUMENTO)
        args(15) = New SqlParameter("@IDESTADOCALIFICACION", SqlDbType.TinyInt)
        args(15).Value = IIf(lEntidad.IDESTADOCALIFICACION = Nothing, DBNull.Value, lEntidad.IDESTADOCALIFICACION)
        args(16) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(17) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(17).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(18) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(18).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(19) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(19).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(20) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(20).Value = lEntidad.ESTASINCRONIZADA
        args(21) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(21).Value = lEntidad.IDESTABLECIMIENTO
        args(22) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(22).Value = lEntidad.IDPROCESOCOMPRA
        args(23) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(23).Value = lEntidad.IDPROVEEDOR
        args(24) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(24).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEOFERTA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" CORRELATIVORENGLON, ")
        strSQL.Append(" CASAREPRESENTADA, ")
        strSQL.Append(" MARCA, ")
        strSQL.Append(" ORIGEN, ")
        strSQL.Append(" DESCRIPCIONPROVEEDOR, ")
        strSQL.Append(" VENCIMIENTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" PRECIOUNITARIO, ")
        strSQL.Append(" PLAZOENTREGA, ")
        strSQL.Append(" NUMEROCSSP, ")
        strSQL.Append(" VIGENCIA, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" OBSERVACIONDOCUMENTO, ")
        strSQL.Append(" IDESTADOCALIFICACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @RENGLON, ")
        strSQL.Append(" @CORRELATIVORENGLON, ")
        strSQL.Append(" @CASAREPRESENTADA, ")
        strSQL.Append(" @MARCA, ")
        strSQL.Append(" @ORIGEN, ")
        strSQL.Append(" @DESCRIPCIONPROVEEDOR, ")
        strSQL.Append(" @VENCIMIENTO, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @CANTIDAD, ")
        strSQL.Append(" @PRECIOUNITARIO, ")
        strSQL.Append(" @PLAZOENTREGA, ")
        strSQL.Append(" @NUMEROCSSP, ")
        strSQL.Append(" @VIGENCIA, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @OBSERVACIONDOCUMENTO, ")
        strSQL.Append(" @IDESTADOCALIFICACION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(24) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLE
        args(4) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(4).Value = lEntidad.RENGLON
        args(5) = New SqlParameter("@CORRELATIVORENGLON", SqlDbType.SmallInt)
        args(5).Value = lEntidad.CORRELATIVORENGLON
        args(6) = New SqlParameter("@CASAREPRESENTADA", SqlDbType.VarChar)
        args(6).Value = lEntidad.CASAREPRESENTADA
        args(7) = New SqlParameter("@MARCA", SqlDbType.VarChar)
        args(7).Value = lEntidad.MARCA
        args(8) = New SqlParameter("@ORIGEN", SqlDbType.VarChar)
        args(8).Value = lEntidad.ORIGEN
        args(9) = New SqlParameter("@DESCRIPCIONPROVEEDOR", SqlDbType.VarChar)
        args(9).Value = IIf(IsNothing(lEntidad.DESCRIPCIONPROVEEDOR), DBNull.Value, lEntidad.DESCRIPCIONPROVEEDOR)
        args(10) = New SqlParameter("@VENCIMIENTO", SqlDbType.VarChar)
        args(10).Value = lEntidad.VENCIMIENTO
        args(11) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(11).Value = lEntidad.IDUNIDADMEDIDA
        args(12) = New SqlParameter("@CANTIDAD", SqlDbType.BigInt)
        args(12).Value = lEntidad.CANTIDAD
        args(13) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Decimal)
        args(13).Value = lEntidad.PRECIOUNITARIO
        args(14) = New SqlParameter("@PLAZOENTREGA", SqlDbType.VarChar)
        args(14).Value = lEntidad.PLAZOENTREGA
        args(15) = New SqlParameter("@NUMEROCSSP", SqlDbType.VarChar)
        args(15).Value = IIf(IsNothing(lEntidad.NUMEROCSSP), DBNull.Value, lEntidad.NUMEROCSSP)
        args(16) = New SqlParameter("@VIGENCIA", SqlDbType.VarChar)
        args(16).Value = lEntidad.VIGENCIA
        args(17) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(17).Value = IIf(IsNothing(lEntidad.OBSERVACION), DBNull.Value, lEntidad.OBSERVACION)
        args(18) = New SqlParameter("@OBSERVACIONDOCUMENTO", SqlDbType.VarChar)
        args(18).Value = IIf(IsNothing(lEntidad.OBSERVACIONDOCUMENTO), DBNull.Value, lEntidad.OBSERVACIONDOCUMENTO)
        args(19) = New SqlParameter("@IDESTADOCALIFICACION", SqlDbType.TinyInt)
        args(19).Value = IIf(lEntidad.IDESTADOCALIFICACION = Nothing, DBNull.Value, lEntidad.IDESTADOCALIFICACION)
        args(20) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(20).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(21) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(21).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(22) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(22).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(23) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(23).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(24) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(24).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEOFERTA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEOFERTA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.RENGLON = IIf(.Item("RENGLON") Is DBNull.Value, Nothing, .Item("RENGLON"))
                lEntidad.CORRELATIVORENGLON = IIf(.Item("CORRELATIVORENGLON") Is DBNull.Value, Nothing, .Item("CORRELATIVORENGLON"))
                lEntidad.CASAREPRESENTADA = IIf(.Item("CASAREPRESENTADA") Is DBNull.Value, Nothing, .Item("CASAREPRESENTADA"))
                lEntidad.MARCA = IIf(.Item("MARCA") Is DBNull.Value, Nothing, .Item("MARCA"))
                lEntidad.ORIGEN = IIf(.Item("ORIGEN") Is DBNull.Value, Nothing, .Item("ORIGEN"))
                lEntidad.DESCRIPCIONPROVEEDOR = IIf(.Item("DESCRIPCIONPROVEEDOR") Is DBNull.Value, Nothing, .Item("DESCRIPCIONPROVEEDOR"))
                lEntidad.VENCIMIENTO = IIf(.Item("VENCIMIENTO") Is DBNull.Value, Nothing, .Item("VENCIMIENTO"))
                lEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
                lEntidad.CANTIDAD = IIf(.Item("CANTIDAD") Is DBNull.Value, Nothing, .Item("CANTIDAD"))
                lEntidad.PRECIOUNITARIO = IIf(.Item("PRECIOUNITARIO") Is DBNull.Value, Nothing, .Item("PRECIOUNITARIO"))
                lEntidad.PLAZOENTREGA = IIf(.Item("PLAZOENTREGA") Is DBNull.Value, Nothing, .Item("PLAZOENTREGA"))
                lEntidad.NUMEROCSSP = IIf(.Item("NUMEROCSSP") Is DBNull.Value, Nothing, .Item("NUMEROCSSP"))
                lEntidad.VIGENCIA = IIf(.Item("VIGENCIA") Is DBNull.Value, Nothing, .Item("VIGENCIA"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
                lEntidad.OBSERVACIONDOCUMENTO = IIf(.Item("OBSERVACIONDOCUMENTO") Is DBNull.Value, Nothing, .Item("OBSERVACIONDOCUMENTO"))
                lEntidad.IDESTADOCALIFICACION = IIf(.Item("IDESTADOCALIFICACION") Is DBNull.Value, Nothing, .Item("IDESTADOCALIFICACION"))
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

        Dim lEntidad As DETALLEOFERTA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA ")
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

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As listaDETALLEOFERTA

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

        Dim lista As New listaDETALLEOFERTA

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLEOFERTA
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDDETALLE = IIf(dr("IDDETALLE") Is DBNull.Value, Nothing, dr("IDDETALLE"))
                mEntidad.RENGLON = IIf(dr("RENGLON") Is DBNull.Value, Nothing, dr("RENGLON"))
                mEntidad.CORRELATIVORENGLON = IIf(dr("CORRELATIVORENGLON") Is DBNull.Value, Nothing, dr("CORRELATIVORENGLON"))
                mEntidad.CASAREPRESENTADA = IIf(dr("CASAREPRESENTADA") Is DBNull.Value, Nothing, dr("CASAREPRESENTADA"))
                mEntidad.MARCA = IIf(dr("MARCA") Is DBNull.Value, Nothing, dr("MARCA"))
                mEntidad.ORIGEN = IIf(dr("ORIGEN") Is DBNull.Value, Nothing, dr("ORIGEN"))
                mEntidad.DESCRIPCIONPROVEEDOR = IIf(dr("DESCRIPCIONPROVEEDOR") Is DBNull.Value, Nothing, dr("DESCRIPCIONPROVEEDOR"))
                mEntidad.VENCIMIENTO = IIf(dr("VENCIMIENTO") Is DBNull.Value, Nothing, dr("VENCIMIENTO"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.CANTIDAD = IIf(dr("CANTIDAD") Is DBNull.Value, Nothing, dr("CANTIDAD"))
                mEntidad.PRECIOUNITARIO = IIf(dr("PRECIOUNITARIO") Is DBNull.Value, Nothing, dr("PRECIOUNITARIO"))
                mEntidad.PLAZOENTREGA = IIf(dr("PLAZOENTREGA") Is DBNull.Value, Nothing, dr("PLAZOENTREGA"))
                mEntidad.NUMEROCSSP = IIf(dr("NUMEROCSSP") Is DBNull.Value, Nothing, dr("NUMEROCSSP"))
                mEntidad.VIGENCIA = IIf(dr("VIGENCIA") Is DBNull.Value, Nothing, dr("VIGENCIA"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.OBSERVACIONDOCUMENTO = IIf(dr("OBSERVACIONDOCUMENTO") Is DBNull.Value, Nothing, dr("OBSERVACIONDOCUMENTO"))
                mEntidad.IDESTADOCALIFICACION = IIf(dr("IDESTADOCALIFICACION") Is DBNull.Value, Nothing, dr("IDESTADOCALIFICACION"))
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
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ORDER BY RENGLON")

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
        tables(0) = New String("DETALLEOFERTA")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" CORRELATIVORENGLON, ")
        strSQL.Append(" CASAREPRESENTADA, ")
        strSQL.Append(" MARCA, ")
        strSQL.Append(" ORIGEN, ")
        strSQL.Append(" DESCRIPCIONPROVEEDOR, ")
        strSQL.Append(" VENCIMIENTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" PRECIOUNITARIO, ")
        strSQL.Append(" PLAZOENTREGA, ")
        strSQL.Append(" NUMEROCSSP, ")
        strSQL.Append(" VIGENCIA, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" OBSERVACIONDOCUMENTO, ")
        strSQL.Append(" IDESTADOCALIFICACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_DETALLEOFERTA ")

    End Sub

#End Region

End Class
