Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbDETALLEINVENTARIO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla DETALLEINVENTARIO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbDETALLEINVENTARIO
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEINVENTARIO
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
        strSQL.Append("UPDATE SAB_ALM_DETALLEINVENTARIO ")
        strSQL.Append(" SET IDPRODUCTO = @IDPRODUCTO, ")
        strSQL.Append(" IDLOTE = @IDLOTE, ")
        strSQL.Append(" IDUNIDADMEDIDA = @IDUNIDADMEDIDA, ")
        strSQL.Append(" PRECIO = @PRECIO, ")
        strSQL.Append(" CANTIDADDISPONIBLESISTEMA = @CANTIDADDISPONIBLESISTEMA, ")
        strSQL.Append(" CANTIDADDISPONIBLECAPTURA = @CANTIDADDISPONIBLECAPTURA, ")
        strSQL.Append(" CANTIDADDISPONIBLEDIFERENCIA = @CANTIDADDISPONIBLEDIFERENCIA, ")
        strSQL.Append(" CANTIDADNODISPONIBLESISTEMA = @CANTIDADNODISPONIBLESISTEMA, ")
        strSQL.Append(" CANTIDADNODISPONIBLECAPTURA = @CANTIDADNODISPONIBLECAPTURA, ")
        strSQL.Append(" CANTIDADNODISPONIBLEDIFERENCIA = @CANTIDADNODISPONIBLEDIFERENCIA, ")
        strSQL.Append(" CANTIDADVENCIDASISTEMA = @CANTIDADVENCIDASISTEMA, ")
        strSQL.Append(" CANTIDADVENCIDACAPTURA = @CANTIDADVENCIDACAPTURA, ")
        strSQL.Append(" CANTIDADVENCIDADIFERENCIA = @CANTIDADVENCIDADIFERENCIA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(20) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPRODUCTO
        args(1) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(1).Value = IIf(lEntidad.IDLOTE = Nothing, DBNull.Value, lEntidad.IDLOTE)
        args(2) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(2).Value = lEntidad.IDUNIDADMEDIDA
        args(3) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(3).Value = lEntidad.PRECIO
        args(4) = New SqlParameter("@CANTIDADDISPONIBLESISTEMA", SqlDbType.Decimal)
        args(4).Value = lEntidad.CANTIDADDISPONIBLESISTEMA
        args(5) = New SqlParameter("@CANTIDADDISPONIBLECAPTURA", SqlDbType.Decimal)
        args(5).Value = lEntidad.CANTIDADDISPONIBLECAPTURA
        args(6) = New SqlParameter("@CANTIDADDISPONIBLEDIFERENCIA", SqlDbType.Decimal)
        args(6).Value = lEntidad.CANTIDADDISPONIBLEDIFERENCIA
        args(7) = New SqlParameter("@CANTIDADNODISPONIBLESISTEMA", SqlDbType.Decimal)
        args(7).Value = lEntidad.CANTIDADNODISPONIBLESISTEMA
        args(8) = New SqlParameter("@CANTIDADNODISPONIBLECAPTURA", SqlDbType.Decimal)
        args(8).Value = lEntidad.CANTIDADNODISPONIBLECAPTURA
        args(9) = New SqlParameter("@CANTIDADNODISPONIBLEDIFERENCIA", SqlDbType.Decimal)
        args(9).Value = lEntidad.CANTIDADNODISPONIBLEDIFERENCIA
        args(10) = New SqlParameter("@CANTIDADVENCIDASISTEMA", SqlDbType.Decimal)
        args(10).Value = lEntidad.CANTIDADVENCIDASISTEMA
        args(11) = New SqlParameter("@CANTIDADVENCIDACAPTURA", SqlDbType.Decimal)
        args(11).Value = lEntidad.CANTIDADVENCIDACAPTURA
        args(12) = New SqlParameter("@CANTIDADVENCIDADIFERENCIA", SqlDbType.Decimal)
        args(12).Value = lEntidad.CANTIDADVENCIDADIFERENCIA
        args(13) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(14) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(15) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(15).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(16) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(17) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(17).Value = lEntidad.ESTASINCRONIZADA
        args(18) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(18).Value = lEntidad.IDALMACEN
        args(19) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(19).Value = lEntidad.IDINVENTARIO
        args(20) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(20).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEINVENTARIO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_ALM_DETALLEINVENTARIO ")
        strSQL.Append(" ( IDALMACEN, ")
        strSQL.Append(" IDINVENTARIO, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDLOTE, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" PRECIO, ")
        strSQL.Append(" CANTIDADDISPONIBLESISTEMA, ")
        strSQL.Append(" CANTIDADDISPONIBLECAPTURA, ")
        strSQL.Append(" CANTIDADDISPONIBLEDIFERENCIA, ")
        strSQL.Append(" CANTIDADNODISPONIBLESISTEMA, ")
        strSQL.Append(" CANTIDADNODISPONIBLECAPTURA, ")
        strSQL.Append(" CANTIDADNODISPONIBLEDIFERENCIA, ")
        strSQL.Append(" CANTIDADVENCIDASISTEMA, ")
        strSQL.Append(" CANTIDADVENCIDACAPTURA, ")
        strSQL.Append(" CANTIDADVENCIDADIFERENCIA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALMACEN, ")
        strSQL.Append(" @IDINVENTARIO, ")
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @IDLOTE, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @PRECIO, ")
        strSQL.Append(" @CANTIDADDISPONIBLESISTEMA, ")
        strSQL.Append(" @CANTIDADDISPONIBLECAPTURA, ")
        strSQL.Append(" @CANTIDADDISPONIBLEDIFERENCIA, ")
        strSQL.Append(" @CANTIDADNODISPONIBLESISTEMA, ")
        strSQL.Append(" @CANTIDADNODISPONIBLECAPTURA, ")
        strSQL.Append(" @CANTIDADNODISPONIBLEDIFERENCIA, ")
        strSQL.Append(" @CANTIDADVENCIDASISTEMA, ")
        strSQL.Append(" @CANTIDADVENCIDACAPTURA, ")
        strSQL.Append(" @CANTIDADVENCIDADIFERENCIA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(20) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO
        args(2) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(2).Value = lEntidad.IDDETALLE
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDPRODUCTO
        args(4) = New SqlParameter("@IDLOTE", SqlDbType.BigInt)
        args(4).Value = IIf(lEntidad.IDLOTE = Nothing, DBNull.Value, lEntidad.IDLOTE)
        args(5) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(5).Value = lEntidad.IDUNIDADMEDIDA
        args(6) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(6).Value = lEntidad.PRECIO
        args(7) = New SqlParameter("@CANTIDADDISPONIBLESISTEMA", SqlDbType.Decimal)
        args(7).Value = lEntidad.CANTIDADDISPONIBLESISTEMA
        args(8) = New SqlParameter("@CANTIDADDISPONIBLECAPTURA", SqlDbType.Decimal)
        args(8).Value = lEntidad.CANTIDADDISPONIBLECAPTURA
        args(9) = New SqlParameter("@CANTIDADDISPONIBLEDIFERENCIA", SqlDbType.Decimal)
        args(9).Value = lEntidad.CANTIDADDISPONIBLEDIFERENCIA
        args(10) = New SqlParameter("@CANTIDADNODISPONIBLESISTEMA", SqlDbType.Decimal)
        args(10).Value = lEntidad.CANTIDADNODISPONIBLESISTEMA
        args(11) = New SqlParameter("@CANTIDADNODISPONIBLECAPTURA", SqlDbType.Decimal)
        args(11).Value = lEntidad.CANTIDADNODISPONIBLECAPTURA
        args(12) = New SqlParameter("@CANTIDADNODISPONIBLEDIFERENCIA", SqlDbType.Decimal)
        args(12).Value = lEntidad.CANTIDADNODISPONIBLEDIFERENCIA
        args(13) = New SqlParameter("@CANTIDADVENCIDASISTEMA", SqlDbType.Decimal)
        args(13).Value = lEntidad.CANTIDADVENCIDASISTEMA
        args(14) = New SqlParameter("@CANTIDADVENCIDACAPTURA", SqlDbType.Decimal)
        args(14).Value = lEntidad.CANTIDADVENCIDACAPTURA
        args(15) = New SqlParameter("@CANTIDADVENCIDADIFERENCIA", SqlDbType.Decimal)
        args(15).Value = lEntidad.CANTIDADVENCIDADIFERENCIA
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEINVENTARIO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_DETALLEINVENTARIO ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO
        args(2) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(2).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As DETALLEINVENTARIO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDINVENTARIO = @IDINVENTARIO ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO
        args(2) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(2).Value = lEntidad.IDDETALLE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDPRODUCTO = IIf(.Item("IDPRODUCTO") Is DBNull.Value, Nothing, .Item("IDPRODUCTO"))
                lEntidad.IDLOTE = IIf(.Item("IDLOTE") Is DBNull.Value, Nothing, .Item("IDLOTE"))
                lEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
                lEntidad.PRECIO = IIf(.Item("PRECIO") Is DBNull.Value, Nothing, .Item("PRECIO"))
                lEntidad.CANTIDADDISPONIBLESISTEMA = IIf(.Item("CANTIDADDISPONIBLESISTEMA") Is DBNull.Value, Nothing, .Item("CANTIDADDISPONIBLESISTEMA"))
                lEntidad.CANTIDADDISPONIBLECAPTURA = IIf(.Item("CANTIDADDISPONIBLECAPTURA") Is DBNull.Value, Nothing, .Item("CANTIDADDISPONIBLECAPTURA"))
                lEntidad.CANTIDADDISPONIBLEDIFERENCIA = IIf(.Item("CANTIDADDISPONIBLEDIFERENCIA") Is DBNull.Value, Nothing, .Item("CANTIDADDISPONIBLEDIFERENCIA"))
                lEntidad.CANTIDADNODISPONIBLESISTEMA = IIf(.Item("CANTIDADNODISPONIBLESISTEMA") Is DBNull.Value, Nothing, .Item("CANTIDADNODISPONIBLESISTEMA"))
                lEntidad.CANTIDADNODISPONIBLECAPTURA = IIf(.Item("CANTIDADNODISPONIBLECAPTURA") Is DBNull.Value, Nothing, .Item("CANTIDADNODISPONIBLECAPTURA"))
                lEntidad.CANTIDADNODISPONIBLEDIFERENCIA = IIf(.Item("CANTIDADNODISPONIBLEDIFERENCIA") Is DBNull.Value, Nothing, .Item("CANTIDADNODISPONIBLEDIFERENCIA"))
                lEntidad.CANTIDADVENCIDASISTEMA = IIf(.Item("CANTIDADVENCIDASISTEMA") Is DBNull.Value, Nothing, .Item("CANTIDADVENCIDASISTEMA"))
                lEntidad.CANTIDADVENCIDACAPTURA = IIf(.Item("CANTIDADVENCIDACAPTURA") Is DBNull.Value, Nothing, .Item("CANTIDADVENCIDACAPTURA"))
                lEntidad.CANTIDADVENCIDADIFERENCIA = IIf(.Item("CANTIDADVENCIDADIFERENCIA") Is DBNull.Value, Nothing, .Item("CANTIDADVENCIDADIFERENCIA"))
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

        Dim lEntidad As DETALLEINVENTARIO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDETALLE),0) + 1 ")
        strSQL.Append(" FROM SAB_ALM_DETALLEINVENTARIO ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As listaDETALLEINVENTARIO

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaDETALLEINVENTARIO

        Try
            Do While dr.Read()
                Dim mEntidad As New DETALLEINVENTARIO
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.IDINVENTARIO = IDINVENTARIO
                mEntidad.IDDETALLE = IIf(dr("IDDETALLE") Is DBNull.Value, Nothing, dr("IDDETALLE"))
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.IDLOTE = IIf(dr("IDLOTE") Is DBNull.Value, Nothing, dr("IDLOTE"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.PRECIO = IIf(dr("PRECIO") Is DBNull.Value, Nothing, dr("PRECIO"))
                mEntidad.CANTIDADDISPONIBLESISTEMA = IIf(dr("CANTIDADDISPONIBLESISTEMA") Is DBNull.Value, Nothing, dr("CANTIDADDISPONIBLESISTEMA"))
                mEntidad.CANTIDADDISPONIBLECAPTURA = IIf(dr("CANTIDADDISPONIBLECAPTURA") Is DBNull.Value, Nothing, dr("CANTIDADDISPONIBLECAPTURA"))
                mEntidad.CANTIDADDISPONIBLEDIFERENCIA = IIf(dr("CANTIDADDISPONIBLEDIFERENCIA") Is DBNull.Value, Nothing, dr("CANTIDADDISPONIBLEDIFERENCIA"))
                mEntidad.CANTIDADNODISPONIBLESISTEMA = IIf(dr("CANTIDADNODISPONIBLESISTEMA") Is DBNull.Value, Nothing, dr("CANTIDADNODISPONIBLESISTEMA"))
                mEntidad.CANTIDADNODISPONIBLECAPTURA = IIf(dr("CANTIDADNODISPONIBLECAPTURA") Is DBNull.Value, Nothing, dr("CANTIDADNODISPONIBLECAPTURA"))
                mEntidad.CANTIDADNODISPONIBLEDIFERENCIA = IIf(dr("CANTIDADNODISPONIBLEDIFERENCIA") Is DBNull.Value, Nothing, dr("CANTIDADNODISPONIBLEDIFERENCIA"))
                mEntidad.CANTIDADVENCIDASISTEMA = IIf(dr("CANTIDADVENCIDASISTEMA") Is DBNull.Value, Nothing, dr("CANTIDADVENCIDASISTEMA"))
                mEntidad.CANTIDADVENCIDACAPTURA = IIf(dr("CANTIDADVENCIDACAPTURA") Is DBNull.Value, Nothing, dr("CANTIDADVENCIDACAPTURA"))
                mEntidad.CANTIDADVENCIDADIFERENCIA = IIf(dr("CANTIDADVENCIDADIFERENCIA") Is DBNull.Value, Nothing, dr("CANTIDADVENCIDADIFERENCIA"))
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

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim tables(0) As String
        tables(0) = New String("DETALLEINVENTARIO")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDALMACEN, ")
        strSQL.Append(" IDINVENTARIO, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDLOTE, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" PRECIO, ")
        strSQL.Append(" CANTIDADDISPONIBLESISTEMA, ")
        strSQL.Append(" CANTIDADDISPONIBLECAPTURA, ")
        strSQL.Append(" CANTIDADDISPONIBLEDIFERENCIA, ")
        strSQL.Append(" CANTIDADNODISPONIBLESISTEMA, ")
        strSQL.Append(" CANTIDADNODISPONIBLECAPTURA, ")
        strSQL.Append(" CANTIDADNODISPONIBLEDIFERENCIA, ")
        strSQL.Append(" CANTIDADVENCIDASISTEMA, ")
        strSQL.Append(" CANTIDADVENCIDACAPTURA, ")
        strSQL.Append(" CANTIDADVENCIDADIFERENCIA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_ALM_DETALLEINVENTARIO ")

    End Sub

#End Region

End Class
