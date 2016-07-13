Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbEXAMENOFERTA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla EXAMENOFERTA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	28/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbEXAMENOFERTA
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EXAMENOFERTA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_EXAMENOFERTA ")
        strSQL.Append(" SET INDICESOLVENCIA = @INDICESOLVENCIA, ")
        strSQL.Append(" PONDERACIONSOLVENCIA = @PONDERACIONSOLVENCIA, ")
        strSQL.Append(" CAPITALTRABAJO = @CAPITALTRABAJO, ")
        strSQL.Append(" PONDERACIONCAPITAL = @PONDERACIONCAPITAL, ")
        strSQL.Append(" INDICEENDEUDAMIENTO = @INDICEENDEUDAMIENTO, ")
        strSQL.Append(" PONDERACIONENDEUDAMIENTO = @PONDERACIONENDEUDAMIENTO, ")
        strSQL.Append(" REFERENCIABANCARIA = @REFERENCIABANCARIA, ")
        strSQL.Append(" PONDERACIONREFERENCIA = @PONDERACIONREFERENCIA, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" NUMEROEXAMEN = @NUMEROEXAMEN, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(17) As SqlParameter
        args(0) = New SqlParameter("@INDICESOLVENCIA", SqlDbType.Decimal)
        args(0).Value = lEntidad.INDICESOLVENCIA
        args(1) = New SqlParameter("@PONDERACIONSOLVENCIA", SqlDbType.Decimal)
        args(1).Value = lEntidad.PONDERACIONSOLVENCIA
        args(2) = New SqlParameter("@CAPITALTRABAJO", SqlDbType.Decimal)
        args(2).Value = lEntidad.CAPITALTRABAJO
        args(3) = New SqlParameter("@PONDERACIONCAPITAL", SqlDbType.Decimal)
        args(3).Value = lEntidad.PONDERACIONCAPITAL
        args(4) = New SqlParameter("@INDICEENDEUDAMIENTO", SqlDbType.Decimal)
        args(4).Value = lEntidad.INDICEENDEUDAMIENTO
        args(5) = New SqlParameter("@PONDERACIONENDEUDAMIENTO", SqlDbType.Decimal)
        args(5).Value = lEntidad.PONDERACIONENDEUDAMIENTO
        args(6) = New SqlParameter("@REFERENCIABANCARIA", SqlDbType.TinyInt)
        args(6).Value = lEntidad.REFERENCIABANCARIA
        args(7) = New SqlParameter("@PONDERACIONREFERENCIA", SqlDbType.Decimal)
        args(7).Value = lEntidad.PONDERACIONREFERENCIA
        args(8) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(9) = New SqlParameter("@NUMEROEXAMEN", SqlDbType.TinyInt)
        args(9).Value = lEntidad.NUMEROEXAMEN
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
        args(15) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(15).Value = lEntidad.IDESTABLECIMIENTO
        args(16) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(16).Value = lEntidad.IDPROCESOCOMPRA
        args(17) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(17).Value = lEntidad.IDPROVEEDOR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EXAMENOFERTA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_EXAMENOFERTA ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" INDICESOLVENCIA, ")
        strSQL.Append(" PONDERACIONSOLVENCIA, ")
        strSQL.Append(" CAPITALTRABAJO, ")
        strSQL.Append(" PONDERACIONCAPITAL, ")
        strSQL.Append(" INDICEENDEUDAMIENTO, ")
        strSQL.Append(" PONDERACIONENDEUDAMIENTO, ")
        strSQL.Append(" REFERENCIABANCARIA, ")
        strSQL.Append(" PONDERACIONREFERENCIA, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" NUMEROEXAMEN, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @INDICESOLVENCIA, ")
        strSQL.Append(" @PONDERACIONSOLVENCIA, ")
        strSQL.Append(" @CAPITALTRABAJO, ")
        strSQL.Append(" @PONDERACIONCAPITAL, ")
        strSQL.Append(" @INDICEENDEUDAMIENTO, ")
        strSQL.Append(" @PONDERACIONENDEUDAMIENTO, ")
        strSQL.Append(" @REFERENCIABANCARIA, ")
        strSQL.Append(" @PONDERACIONREFERENCIA, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @NUMEROEXAMEN, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(17) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@INDICESOLVENCIA", SqlDbType.Decimal)
        args(3).Value = lEntidad.INDICESOLVENCIA
        args(4) = New SqlParameter("@PONDERACIONSOLVENCIA", SqlDbType.Decimal)
        args(4).Value = lEntidad.PONDERACIONSOLVENCIA
        args(5) = New SqlParameter("@CAPITALTRABAJO", SqlDbType.Decimal)
        args(5).Value = lEntidad.CAPITALTRABAJO
        args(6) = New SqlParameter("@PONDERACIONCAPITAL", SqlDbType.Decimal)
        args(6).Value = lEntidad.PONDERACIONCAPITAL
        args(7) = New SqlParameter("@INDICEENDEUDAMIENTO", SqlDbType.Decimal)
        args(7).Value = lEntidad.INDICEENDEUDAMIENTO
        args(8) = New SqlParameter("@PONDERACIONENDEUDAMIENTO", SqlDbType.Decimal)
        args(8).Value = lEntidad.PONDERACIONENDEUDAMIENTO
        args(9) = New SqlParameter("@REFERENCIABANCARIA", SqlDbType.TinyInt)
        args(9).Value = lEntidad.REFERENCIABANCARIA
        args(10) = New SqlParameter("@PONDERACIONREFERENCIA", SqlDbType.Decimal)
        args(10).Value = lEntidad.PONDERACIONREFERENCIA
        args(11) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(11).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(12) = New SqlParameter("@NUMEROEXAMEN", SqlDbType.TinyInt)
        args(12).Value = lEntidad.NUMEROEXAMEN
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As EXAMENOFERTA
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_EXAMENOFERTA ")
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

        Dim lEntidad As EXAMENOFERTA
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
                lEntidad.INDICESOLVENCIA = IIf(.Item("INDICESOLVENCIA") Is DBNull.Value, Nothing, .Item("INDICESOLVENCIA"))
                lEntidad.PONDERACIONSOLVENCIA = IIf(.Item("PONDERACIONSOLVENCIA") Is DBNull.Value, Nothing, .Item("PONDERACIONSOLVENCIA"))
                lEntidad.CAPITALTRABAJO = IIf(.Item("CAPITALTRABAJO") Is DBNull.Value, Nothing, .Item("CAPITALTRABAJO"))
                lEntidad.PONDERACIONCAPITAL = IIf(.Item("PONDERACIONCAPITAL") Is DBNull.Value, Nothing, .Item("PONDERACIONCAPITAL"))
                lEntidad.INDICEENDEUDAMIENTO = IIf(.Item("INDICEENDEUDAMIENTO") Is DBNull.Value, Nothing, .Item("INDICEENDEUDAMIENTO"))
                lEntidad.PONDERACIONENDEUDAMIENTO = IIf(.Item("PONDERACIONENDEUDAMIENTO") Is DBNull.Value, Nothing, .Item("PONDERACIONENDEUDAMIENTO"))
                lEntidad.REFERENCIABANCARIA = IIf(.Item("REFERENCIABANCARIA") Is DBNull.Value, Nothing, .Item("REFERENCIABANCARIA"))
                lEntidad.PONDERACIONREFERENCIA = IIf(.Item("PONDERACIONREFERENCIA") Is DBNull.Value, Nothing, .Item("PONDERACIONREFERENCIA"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
                lEntidad.NUMEROEXAMEN = IIf(.Item("NUMEROEXAMEN") Is DBNull.Value, Nothing, .Item("NUMEROEXAMEN"))
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

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As listaEXAMENOFERTA

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

        Dim lista As New listaEXAMENOFERTA

        Try
            Do While dr.Read()
                Dim mEntidad As New EXAMENOFERTA
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.INDICESOLVENCIA = IIf(dr("INDICESOLVENCIA") Is DBNull.Value, Nothing, dr("INDICESOLVENCIA"))
                mEntidad.PONDERACIONSOLVENCIA = IIf(dr("PONDERACIONSOLVENCIA") Is DBNull.Value, Nothing, dr("PONDERACIONSOLVENCIA"))
                mEntidad.CAPITALTRABAJO = IIf(dr("CAPITALTRABAJO") Is DBNull.Value, Nothing, dr("CAPITALTRABAJO"))
                mEntidad.PONDERACIONCAPITAL = IIf(dr("PONDERACIONCAPITAL") Is DBNull.Value, Nothing, dr("PONDERACIONCAPITAL"))
                mEntidad.INDICEENDEUDAMIENTO = IIf(dr("INDICEENDEUDAMIENTO") Is DBNull.Value, Nothing, dr("INDICEENDEUDAMIENTO"))
                mEntidad.PONDERACIONENDEUDAMIENTO = IIf(dr("PONDERACIONENDEUDAMIENTO") Is DBNull.Value, Nothing, dr("PONDERACIONENDEUDAMIENTO"))
                mEntidad.REFERENCIABANCARIA = IIf(dr("REFERENCIABANCARIA") Is DBNull.Value, Nothing, dr("REFERENCIABANCARIA"))
                mEntidad.PONDERACIONREFERENCIA = IIf(dr("PONDERACIONREFERENCIA") Is DBNull.Value, Nothing, dr("PONDERACIONREFERENCIA"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.NUMEROEXAMEN = IIf(dr("NUMEROEXAMEN") Is DBNull.Value, Nothing, dr("NUMEROEXAMEN"))
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
        tables(0) = New String("EXAMENOFERTA")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" INDICESOLVENCIA, ")
        strSQL.Append(" PONDERACIONSOLVENCIA, ")
        strSQL.Append(" CAPITALTRABAJO, ")
        strSQL.Append(" PONDERACIONCAPITAL, ")
        strSQL.Append(" INDICEENDEUDAMIENTO, ")
        strSQL.Append(" PONDERACIONENDEUDAMIENTO, ")
        strSQL.Append(" REFERENCIABANCARIA, ")
        strSQL.Append(" PONDERACIONREFERENCIA, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" NUMEROEXAMEN, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_EXAMENOFERTA ")

    End Sub

#End Region

End Class
