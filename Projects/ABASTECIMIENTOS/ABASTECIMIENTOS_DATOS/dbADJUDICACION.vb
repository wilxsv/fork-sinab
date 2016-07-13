Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbADJUDICACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_ADJUDICACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbADJUDICACION
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ADJUDICACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ADJUDICACION ")
        strSQL.Append(" SET CANTIDADRECOMENDACION = @CANTIDADRECOMENDACION, ")
        strSQL.Append(" CANTIDADADJUDICADA = @CANTIDADADJUDICADA, ")
        strSQL.Append(" CANTIDADFIRME = @CANTIDADFIRME, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@CANTIDADRECOMENDACION", SqlDbType.Decimal)
        args(0).Value = lEntidad.CANTIDADRECOMENDACION
        args(1) = New SqlParameter("@CANTIDADADJUDICADA", SqlDbType.Decimal)
        args(1).Value = IIf(lEntidad.CANTIDADADJUDICADA = Nothing, DBNull.Value, lEntidad.CANTIDADADJUDICADA)
        args(2) = New SqlParameter("@CANTIDADFIRME", SqlDbType.Decimal)
        args(2).Value = IIf(lEntidad.CANTIDADFIRME = Nothing, DBNull.Value, lEntidad.CANTIDADFIRME)
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
        args(8) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(8).Value = lEntidad.IDPROCESOCOMPRA
        args(9) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(9).Value = lEntidad.IDESTABLECIMIENTO
        args(10) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(10).Value = lEntidad.IDPROVEEDOR
        args(11) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(11).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ADJUDICACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_ADJUDICACION ")
        strSQL.Append(" ( IDPROCESOCOMPRA, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" CANTIDADRECOMENDACION, ")
        strSQL.Append(" CANTIDADADJUDICADA, ")
        strSQL.Append(" CANTIDADFIRME, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDDETALLE, ")
        strSQL.Append(" @CANTIDADRECOMENDACION, ")
        strSQL.Append(" @CANTIDADADJUDICADA, ")
        strSQL.Append(" @CANTIDADFIRME, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLE
        args(4) = New SqlParameter("@CANTIDADRECOMENDACION", SqlDbType.Decimal)
        args(4).Value = lEntidad.CANTIDADRECOMENDACION
        args(5) = New SqlParameter("@CANTIDADADJUDICADA", SqlDbType.Decimal)
        args(5).Value = IIf(lEntidad.CANTIDADADJUDICADA = Nothing, DBNull.Value, lEntidad.CANTIDADADJUDICADA)
        args(6) = New SqlParameter("@CANTIDADFIRME", SqlDbType.Decimal)
        args(6).Value = IIf(lEntidad.CANTIDADFIRME = Nothing, DBNull.Value, lEntidad.CANTIDADFIRME)
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ADJUDICACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_ADJUDICACION ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ADJUDICACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = lEntidad.IDDETALLE

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.CANTIDADRECOMENDACION = IIf(.Item("CANTIDADRECOMENDACION") Is DBNull.Value, Nothing, .Item("CANTIDADRECOMENDACION"))
                lEntidad.CANTIDADADJUDICADA = IIf(.Item("CANTIDADADJUDICADA") Is DBNull.Value, Nothing, .Item("CANTIDADADJUDICADA"))
                lEntidad.CANTIDADFIRME = IIf(.Item("CANTIDADFIRME") Is DBNull.Value, Nothing, .Item("CANTIDADFIRME"))
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

    Public Function ObtenerListaPorID(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As listaADJUDICACION

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaADJUDICACION

        Try
            Do While dr.Read()
                Dim mEntidad As New ADJUDICACION
                mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDDETALLE = IDDETALLE
                mEntidad.CANTIDADRECOMENDACION = IIf(dr("CANTIDADRECOMENDACION") Is DBNull.Value, Nothing, dr("CANTIDADRECOMENDACION"))
                mEntidad.CANTIDADADJUDICADA = IIf(dr("CANTIDADADJUDICADA") Is DBNull.Value, Nothing, dr("CANTIDADADJUDICADA"))
                mEntidad.CANTIDADFIRME = IIf(dr("CANTIDADFIRME") Is DBNull.Value, Nothing, dr("CANTIDADFIRME"))
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

    Public Function ObtenerDataSetPorID(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Dim tables(0) As String
        tables(0) = New String("ADJUDICACION")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDPROCESOCOMPRA, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDDETALLE, ")
        strSQL.Append(" CANTIDADRECOMENDACION, ")
        strSQL.Append(" CANTIDADADJUDICADA, ")
        strSQL.Append(" CANTIDADFIRME, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION ")

    End Sub

#End Region

End Class
