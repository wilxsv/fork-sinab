Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbEXISTENCIASALMACENES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla EXISTENCIASALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbEXISTENCIASALMACENES
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EXISTENCIASALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_ALM_EXISTENCIASALMACENES ")
        strSQL.Append(" SET MAX = @MAX, ")
        strSQL.Append(" MIN = @MIN, ")
        strSQL.Append(" CANTIDADDISPONIBLE = @CANTIDADDISPONIBLE, ")
        strSQL.Append(" CANTIDADNODISPONIBLE = @CANTIDADNODISPONIBLE, ")
        strSQL.Append(" CANTIDADRESERVADA = @CANTIDADRESERVADA, ")
        strSQL.Append(" CANTIDADTEMPORAL = @CANTIDADTEMPORAL, ")
        strSQL.Append(" CANTIDADVENCIDA = @CANTIDADVENCIDA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@MAX", SqlDbType.Decimal)
        args(0).Value = lEntidad.MAX
        args(1) = New SqlParameter("@MIN", SqlDbType.Decimal)
        args(1).Value = lEntidad.MIN
        args(2) = New SqlParameter("@CANTIDADDISPONIBLE", SqlDbType.Decimal)
        args(2).Value = lEntidad.CANTIDADDISPONIBLE
        args(3) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.Decimal)
        args(3).Value = lEntidad.CANTIDADNODISPONIBLE
        args(4) = New SqlParameter("@CANTIDADRESERVADA", SqlDbType.Decimal)
        args(4).Value = lEntidad.CANTIDADRESERVADA
        args(5) = New SqlParameter("@CANTIDADTEMPORAL", SqlDbType.Decimal)
        args(5).Value = lEntidad.CANTIDADTEMPORAL
        args(6) = New SqlParameter("@CANTIDADVENCIDA", SqlDbType.Decimal)
        args(6).Value = lEntidad.CANTIDADVENCIDA
        args(7) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(8) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(9) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(10) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(11) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(11).Value = lEntidad.ESTASINCRONIZADA
        args(12) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(12).Value = lEntidad.IDALMACEN
        args(13) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(13).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EXISTENCIASALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_ALM_EXISTENCIASALMACENES ")
        strSQL.Append(" ( IDALMACEN, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" MAX, ")
        strSQL.Append(" MIN, ")
        strSQL.Append(" CANTIDADDISPONIBLE, ")
        strSQL.Append(" CANTIDADNODISPONIBLE, ")
        strSQL.Append(" CANTIDADRESERVADA, ")
        strSQL.Append(" CANTIDADTEMPORAL, ")
        strSQL.Append(" CANTIDADVENCIDA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALMACEN, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @MAX, ")
        strSQL.Append(" @MIN, ")
        strSQL.Append(" @CANTIDADDISPONIBLE, ")
        strSQL.Append(" @CANTIDADNODISPONIBLE, ")
        strSQL.Append(" @CANTIDADRESERVADA, ")
        strSQL.Append(" @CANTIDADTEMPORAL, ")
        strSQL.Append(" @CANTIDADVENCIDA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@MAX", SqlDbType.Decimal)
        args(2).Value = lEntidad.MAX
        args(3) = New SqlParameter("@MIN", SqlDbType.Decimal)
        args(3).Value = lEntidad.MIN
        args(4) = New SqlParameter("@CANTIDADDISPONIBLE", SqlDbType.Decimal)
        args(4).Value = lEntidad.CANTIDADDISPONIBLE
        args(5) = New SqlParameter("@CANTIDADNODISPONIBLE", SqlDbType.Decimal)
        args(5).Value = lEntidad.CANTIDADNODISPONIBLE
        args(6) = New SqlParameter("@CANTIDADRESERVADA", SqlDbType.Decimal)
        args(6).Value = lEntidad.CANTIDADRESERVADA
        args(7) = New SqlParameter("@CANTIDADTEMPORAL", SqlDbType.Decimal)
        args(7).Value = lEntidad.CANTIDADTEMPORAL
        args(8) = New SqlParameter("@CANTIDADVENCIDA", SqlDbType.Decimal)
        args(8).Value = lEntidad.CANTIDADVENCIDA
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

        Dim lEntidad As EXISTENCIASALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_EXISTENCIASALMACENES ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EXISTENCIASALMACENES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPRODUCTO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.MAX = IIf(.Item("MAX") Is DBNull.Value, Nothing, .Item("MAX"))
                lEntidad.MIN = IIf(.Item("MIN") Is DBNull.Value, Nothing, .Item("MIN"))
                lEntidad.CANTIDADDISPONIBLE = IIf(.Item("CANTIDADDISPONIBLE") Is DBNull.Value, Nothing, .Item("CANTIDADDISPONIBLE"))
                lEntidad.CANTIDADNODISPONIBLE = IIf(.Item("CANTIDADNODISPONIBLE") Is DBNull.Value, Nothing, .Item("CANTIDADNODISPONIBLE"))
                lEntidad.CANTIDADRESERVADA = IIf(.Item("CANTIDADRESERVADA") Is DBNull.Value, Nothing, .Item("CANTIDADRESERVADA"))
                lEntidad.CANTIDADTEMPORAL = IIf(.Item("CANTIDADTEMPORAL") Is DBNull.Value, Nothing, .Item("CANTIDADTEMPORAL"))
                lEntidad.CANTIDADVENCIDA = IIf(.Item("CANTIDADVENCIDA") Is DBNull.Value, Nothing, .Item("CANTIDADVENCIDA"))
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

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As listaEXISTENCIASALMACENES

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaEXISTENCIASALMACENES

        Try
            Do While dr.Read()
                Dim mEntidad As New EXISTENCIASALMACENES
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.IDPRODUCTO = IDPRODUCTO
                mEntidad.MAX = IIf(dr("MAX") Is DBNull.Value, Nothing, dr("MAX"))
                mEntidad.MIN = IIf(dr("MIN") Is DBNull.Value, Nothing, dr("MIN"))
                mEntidad.CANTIDADDISPONIBLE = IIf(dr("CANTIDADDISPONIBLE") Is DBNull.Value, Nothing, dr("CANTIDADDISPONIBLE"))
                mEntidad.CANTIDADNODISPONIBLE = IIf(dr("CANTIDADNODISPONIBLE") Is DBNull.Value, Nothing, dr("CANTIDADNODISPONIBLE"))
                mEntidad.CANTIDADRESERVADA = IIf(dr("CANTIDADRESERVADA") Is DBNull.Value, Nothing, dr("CANTIDADRESERVADA"))
                mEntidad.CANTIDADTEMPORAL = IIf(dr("CANTIDADTEMPORAL") Is DBNull.Value, Nothing, dr("CANTIDADTEMPORAL"))
                mEntidad.CANTIDADVENCIDA = IIf(dr("CANTIDADVENCIDA") Is DBNull.Value, Nothing, dr("CANTIDADVENCIDA"))
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

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(1).Value = IDPRODUCTO

        Dim tables(0) As String
        tables(0) = New String("EXISTENCIASALMACENES")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDALMACEN, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" MAX, ")
        strSQL.Append(" MIN, ")
        strSQL.Append(" CANTIDADDISPONIBLE, ")
        strSQL.Append(" CANTIDADNODISPONIBLE, ")
        strSQL.Append(" CANTIDADRESERVADA, ")
        strSQL.Append(" CANTIDADTEMPORAL, ")
        strSQL.Append(" CANTIDADVENCIDA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_ALM_EXISTENCIASALMACENES ")

    End Sub

#End Region

End Class
