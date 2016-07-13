Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbNOTASACEPTACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla NOTASACEPTACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	24/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbNOTASACEPTACION
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NOTASACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_NOTASACEPTACION ")
        strSQL.Append(" SET FECHARECEPCION = @FECHARECEPCION, ")
        strSQL.Append(" NOMBREPERSONAFIRMA = @NOMBREPERSONAFIRMA, ")
        strSQL.Append(" DUIPERSONAFIRMA = @DUIPERSONAFIRMA, ")
        strSQL.Append(" AFPCONFIARECEPCION = @AFPCONFIARECEPCION, ")
        strSQL.Append(" AFPCONFIAVIGENCIA = @AFPCONFIAVIGENCIA, ")
        strSQL.Append(" AFPCRECERRECEPCION = @AFPCRECERRECEPCION, ")
        strSQL.Append(" AFPCRECERVIGENCIA = @AFPCRECERVIGENCIA, ")
        strSQL.Append(" IPFARECEPCION = @IPFARECEPCION, ")
        strSQL.Append(" IPFAVIGENCIA = @IPFAVIGENCIA, ")
        strSQL.Append(" SSRECEPCION = @SSRECEPCION, ")
        strSQL.Append(" SSVIGENCIA = @SSVIGENCIA, ")
        strSQL.Append(" ISSSRECEPCION = @ISSSRECEPCION, ")
        strSQL.Append(" ISSSVIGENCIA = @ISSSVIGENCIA, ")
        strSQL.Append(" IMPUESTOSRECEPCION = @IMPUESTOSRECEPCION, ")
        strSQL.Append(" IMPUESTOSVIGENCIA = @IMPUESTOSVIGENCIA, ")
        strSQL.Append(" ALCALDIARECEPCION = @ALCALDIARECEPCION, ")
        strSQL.Append(" ALCALDIAVIGENCIA = @ALCALDIAVIGENCIA, ")
        strSQL.Append(" PRESENTANOTA = @PRESENTANOTA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(25) As SqlParameter
        args(0) = New SqlParameter("@FECHARECEPCION", SqlDbType.DateTime)
        args(0).Value = lEntidad.FECHARECEPCION
        args(1) = New SqlParameter("@NOMBREPERSONAFIRMA", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBREPERSONAFIRMA
        args(2) = New SqlParameter("@DUIPERSONAFIRMA", SqlDbType.VarChar)
        args(2).Value = lEntidad.DUIPERSONAFIRMA
        args(3) = New SqlParameter("@AFPCONFIARECEPCION", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.AFPCONFIARECEPCION = Nothing, DBNull.Value, lEntidad.AFPCONFIARECEPCION)
        args(4) = New SqlParameter("@AFPCONFIAVIGENCIA", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.AFPCONFIAVIGENCIA = Nothing, DBNull.Value, lEntidad.AFPCONFIAVIGENCIA)
        args(5) = New SqlParameter("@AFPCRECERRECEPCION", SqlDbType.DateTime)
        args(5).Value = IIf(lEntidad.AFPCRECERRECEPCION = Nothing, DBNull.Value, lEntidad.AFPCRECERRECEPCION)
        args(6) = New SqlParameter("@AFPCRECERVIGENCIA", SqlDbType.DateTime)
        args(6).Value = IIf(lEntidad.AFPCRECERVIGENCIA = Nothing, DBNull.Value, lEntidad.AFPCRECERVIGENCIA)
        args(7) = New SqlParameter("@IPFARECEPCION", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.IPFARECEPCION = Nothing, DBNull.Value, lEntidad.IPFARECEPCION)
        args(8) = New SqlParameter("@IPFAVIGENCIA", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.IPFAVIGENCIA = Nothing, DBNull.Value, lEntidad.IPFAVIGENCIA)
        args(9) = New SqlParameter("@SSRECEPCION", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.SSRECEPCION = Nothing, DBNull.Value, lEntidad.SSRECEPCION)
        args(10) = New SqlParameter("@SSVIGENCIA", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.SSVIGENCIA = Nothing, DBNull.Value, lEntidad.SSVIGENCIA)
        args(11) = New SqlParameter("@ISSSRECEPCION", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.ISSSRECEPCION = Nothing, DBNull.Value, lEntidad.ISSSRECEPCION)
        args(12) = New SqlParameter("@ISSSVIGENCIA", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.ISSSVIGENCIA = Nothing, DBNull.Value, lEntidad.ISSSVIGENCIA)
        args(13) = New SqlParameter("@IMPUESTOSRECEPCION", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.IMPUESTOSRECEPCION = Nothing, DBNull.Value, lEntidad.IMPUESTOSRECEPCION)
        args(14) = New SqlParameter("@IMPUESTOSVIGENCIA", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.IMPUESTOSVIGENCIA = Nothing, DBNull.Value, lEntidad.IMPUESTOSVIGENCIA)
        args(15) = New SqlParameter("@ALCALDIARECEPCION", SqlDbType.DateTime)
        args(15).Value = IIf(lEntidad.ALCALDIARECEPCION = Nothing, DBNull.Value, lEntidad.ALCALDIARECEPCION)
        args(16) = New SqlParameter("@ALCALDIAVIGENCIA", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.ALCALDIAVIGENCIA = Nothing, DBNull.Value, lEntidad.ALCALDIAVIGENCIA)
        args(17) = New SqlParameter("@PRESENTANOTA", SqlDbType.TinyInt)
        args(17).Value = lEntidad.PRESENTANOTA
        args(18) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(18).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(19) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(19).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(20) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(20).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(21) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(21).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(22) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(22).Value = lEntidad.ESTASINCRONIZADA
        args(23) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(23).Value = lEntidad.IDESTABLECIMIENTO
        args(24) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(24).Value = lEntidad.IDPROCESOCOMPRA
        args(25) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(25).Value = lEntidad.IDPROVEEDOR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NOTASACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_NOTASACEPTACION ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" FECHARECEPCION, ")
        strSQL.Append(" NOMBREPERSONAFIRMA, ")
        strSQL.Append(" DUIPERSONAFIRMA, ")
        strSQL.Append(" AFPCONFIARECEPCION, ")
        strSQL.Append(" AFPCONFIAVIGENCIA, ")
        strSQL.Append(" AFPCRECERRECEPCION, ")
        strSQL.Append(" AFPCRECERVIGENCIA, ")
        strSQL.Append(" IPFARECEPCION, ")
        strSQL.Append(" IPFAVIGENCIA, ")
        strSQL.Append(" SSRECEPCION, ")
        strSQL.Append(" SSVIGENCIA, ")
        strSQL.Append(" ISSSRECEPCION, ")
        strSQL.Append(" ISSSVIGENCIA, ")
        strSQL.Append(" IMPUESTOSRECEPCION, ")
        strSQL.Append(" IMPUESTOSVIGENCIA, ")
        strSQL.Append(" ALCALDIARECEPCION, ")
        strSQL.Append(" ALCALDIAVIGENCIA, ")
        strSQL.Append(" PRESENTANOTA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @FECHARECEPCION, ")
        strSQL.Append(" @NOMBREPERSONAFIRMA, ")
        strSQL.Append(" @DUIPERSONAFIRMA, ")
        strSQL.Append(" @AFPCONFIARECEPCION, ")
        strSQL.Append(" @AFPCONFIAVIGENCIA, ")
        strSQL.Append(" @AFPCRECERRECEPCION, ")
        strSQL.Append(" @AFPCRECERVIGENCIA, ")
        strSQL.Append(" @IPFARECEPCION, ")
        strSQL.Append(" @IPFAVIGENCIA, ")
        strSQL.Append(" @SSRECEPCION, ")
        strSQL.Append(" @SSVIGENCIA, ")
        strSQL.Append(" @ISSSRECEPCION, ")
        strSQL.Append(" @ISSSVIGENCIA, ")
        strSQL.Append(" @IMPUESTOSRECEPCION, ")
        strSQL.Append(" @IMPUESTOSVIGENCIA, ")
        strSQL.Append(" @ALCALDIARECEPCION, ")
        strSQL.Append(" @ALCALDIAVIGENCIA, ")
        strSQL.Append(" @PRESENTANOTA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(25) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROVEEDOR
        args(3) = New SqlParameter("@FECHARECEPCION", SqlDbType.DateTime)
        args(3).Value = lEntidad.FECHARECEPCION
        args(4) = New SqlParameter("@NOMBREPERSONAFIRMA", SqlDbType.VarChar)
        args(4).Value = lEntidad.NOMBREPERSONAFIRMA
        args(5) = New SqlParameter("@DUIPERSONAFIRMA", SqlDbType.VarChar)
        args(5).Value = lEntidad.DUIPERSONAFIRMA
        args(6) = New SqlParameter("@AFPCONFIARECEPCION", SqlDbType.DateTime)
        args(6).Value = IIf(lEntidad.AFPCONFIARECEPCION = Nothing, DBNull.Value, lEntidad.AFPCONFIARECEPCION)
        args(7) = New SqlParameter("@AFPCONFIAVIGENCIA", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.AFPCONFIAVIGENCIA = Nothing, DBNull.Value, lEntidad.AFPCONFIAVIGENCIA)
        args(8) = New SqlParameter("@AFPCRECERRECEPCION", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.AFPCRECERRECEPCION = Nothing, DBNull.Value, lEntidad.AFPCRECERRECEPCION)
        args(9) = New SqlParameter("@AFPCRECERVIGENCIA", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.AFPCRECERVIGENCIA = Nothing, DBNull.Value, lEntidad.AFPCRECERVIGENCIA)
        args(10) = New SqlParameter("@IPFARECEPCION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.IPFARECEPCION = Nothing, DBNull.Value, lEntidad.IPFARECEPCION)
        args(11) = New SqlParameter("@IPFAVIGENCIA", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.IPFAVIGENCIA = Nothing, DBNull.Value, lEntidad.IPFAVIGENCIA)
        args(12) = New SqlParameter("@SSRECEPCION", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.SSRECEPCION = Nothing, DBNull.Value, lEntidad.SSRECEPCION)
        args(13) = New SqlParameter("@SSVIGENCIA", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.SSVIGENCIA = Nothing, DBNull.Value, lEntidad.SSVIGENCIA)
        args(14) = New SqlParameter("@ISSSRECEPCION", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.ISSSRECEPCION = Nothing, DBNull.Value, lEntidad.ISSSRECEPCION)
        args(15) = New SqlParameter("@ISSSVIGENCIA", SqlDbType.DateTime)
        args(15).Value = IIf(lEntidad.ISSSVIGENCIA = Nothing, DBNull.Value, lEntidad.ISSSVIGENCIA)
        args(16) = New SqlParameter("@IMPUESTOSRECEPCION", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.IMPUESTOSRECEPCION = Nothing, DBNull.Value, lEntidad.IMPUESTOSRECEPCION)
        args(17) = New SqlParameter("@IMPUESTOSVIGENCIA", SqlDbType.DateTime)
        args(17).Value = IIf(lEntidad.IMPUESTOSVIGENCIA = Nothing, DBNull.Value, lEntidad.IMPUESTOSVIGENCIA)
        args(18) = New SqlParameter("@ALCALDIARECEPCION", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.ALCALDIARECEPCION = Nothing, DBNull.Value, lEntidad.ALCALDIARECEPCION)
        args(19) = New SqlParameter("@ALCALDIAVIGENCIA", SqlDbType.DateTime)
        args(19).Value = IIf(lEntidad.ALCALDIAVIGENCIA = Nothing, DBNull.Value, lEntidad.ALCALDIAVIGENCIA)
        args(20) = New SqlParameter("@PRESENTANOTA", SqlDbType.TinyInt)
        args(20).Value = lEntidad.PRESENTANOTA
        args(21) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(21).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(22) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(22).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(23) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(23).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(24) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(24).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(25) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(25).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NOTASACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_NOTASACEPTACION ")
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

        Dim lEntidad As NOTASACEPTACION
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
                lEntidad.FECHARECEPCION = IIf(.Item("FECHARECEPCION") Is DBNull.Value, Nothing, .Item("FECHARECEPCION"))
                lEntidad.NOMBREPERSONAFIRMA = IIf(.Item("NOMBREPERSONAFIRMA") Is DBNull.Value, Nothing, .Item("NOMBREPERSONAFIRMA"))
                lEntidad.DUIPERSONAFIRMA = IIf(.Item("DUIPERSONAFIRMA") Is DBNull.Value, Nothing, .Item("DUIPERSONAFIRMA"))
                lEntidad.AFPCONFIARECEPCION = IIf(.Item("AFPCONFIARECEPCION") Is DBNull.Value, Nothing, .Item("AFPCONFIARECEPCION"))
                lEntidad.AFPCONFIAVIGENCIA = IIf(.Item("AFPCONFIAVIGENCIA") Is DBNull.Value, Nothing, .Item("AFPCONFIAVIGENCIA"))
                lEntidad.AFPCRECERRECEPCION = IIf(.Item("AFPCRECERRECEPCION") Is DBNull.Value, Nothing, .Item("AFPCRECERRECEPCION"))
                lEntidad.AFPCRECERVIGENCIA = IIf(.Item("AFPCRECERVIGENCIA") Is DBNull.Value, Nothing, .Item("AFPCRECERVIGENCIA"))
                lEntidad.IPFARECEPCION = IIf(.Item("IPFARECEPCION") Is DBNull.Value, Nothing, .Item("IPFARECEPCION"))
                lEntidad.IPFAVIGENCIA = IIf(.Item("IPFAVIGENCIA") Is DBNull.Value, Nothing, .Item("IPFAVIGENCIA"))
                lEntidad.SSRECEPCION = IIf(.Item("SSRECEPCION") Is DBNull.Value, Nothing, .Item("SSRECEPCION"))
                lEntidad.SSVIGENCIA = IIf(.Item("SSVIGENCIA") Is DBNull.Value, Nothing, .Item("SSVIGENCIA"))
                lEntidad.ISSSRECEPCION = IIf(.Item("ISSSRECEPCION") Is DBNull.Value, Nothing, .Item("ISSSRECEPCION"))
                lEntidad.ISSSVIGENCIA = IIf(.Item("ISSSVIGENCIA") Is DBNull.Value, Nothing, .Item("ISSSVIGENCIA"))
                lEntidad.IMPUESTOSRECEPCION = IIf(.Item("IMPUESTOSRECEPCION") Is DBNull.Value, Nothing, .Item("IMPUESTOSRECEPCION"))
                lEntidad.IMPUESTOSVIGENCIA = IIf(.Item("IMPUESTOSVIGENCIA") Is DBNull.Value, Nothing, .Item("IMPUESTOSVIGENCIA"))
                lEntidad.ALCALDIARECEPCION = IIf(.Item("ALCALDIARECEPCION") Is DBNull.Value, Nothing, .Item("ALCALDIARECEPCION"))
                lEntidad.ALCALDIAVIGENCIA = IIf(.Item("ALCALDIAVIGENCIA") Is DBNull.Value, Nothing, .Item("ALCALDIAVIGENCIA"))
                lEntidad.PRESENTANOTA = IIf(.Item("PRESENTANOTA") Is DBNull.Value, Nothing, .Item("PRESENTANOTA"))
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

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32) As listaNOTASACEPTACION

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

        Dim lista As New listaNOTASACEPTACION

        Try
            Do While dr.Read()
                Dim mEntidad As New NOTASACEPTACION
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.FECHARECEPCION = IIf(dr("FECHARECEPCION") Is DBNull.Value, Nothing, dr("FECHARECEPCION"))
                mEntidad.NOMBREPERSONAFIRMA = IIf(dr("NOMBREPERSONAFIRMA") Is DBNull.Value, Nothing, dr("NOMBREPERSONAFIRMA"))
                mEntidad.DUIPERSONAFIRMA = IIf(dr("DUIPERSONAFIRMA") Is DBNull.Value, Nothing, dr("DUIPERSONAFIRMA"))
                mEntidad.AFPCONFIARECEPCION = IIf(dr("AFPCONFIARECEPCION") Is DBNull.Value, Nothing, dr("AFPCONFIARECEPCION"))
                mEntidad.AFPCONFIAVIGENCIA = IIf(dr("AFPCONFIAVIGENCIA") Is DBNull.Value, Nothing, dr("AFPCONFIAVIGENCIA"))
                mEntidad.AFPCRECERRECEPCION = IIf(dr("AFPCRECERRECEPCION") Is DBNull.Value, Nothing, dr("AFPCRECERRECEPCION"))
                mEntidad.AFPCRECERVIGENCIA = IIf(dr("AFPCRECERVIGENCIA") Is DBNull.Value, Nothing, dr("AFPCRECERVIGENCIA"))
                mEntidad.IPFARECEPCION = IIf(dr("IPFARECEPCION") Is DBNull.Value, Nothing, dr("IPFARECEPCION"))
                mEntidad.IPFAVIGENCIA = IIf(dr("IPFAVIGENCIA") Is DBNull.Value, Nothing, dr("IPFAVIGENCIA"))
                mEntidad.SSRECEPCION = IIf(dr("SSRECEPCION") Is DBNull.Value, Nothing, dr("SSRECEPCION"))
                mEntidad.SSVIGENCIA = IIf(dr("SSVIGENCIA") Is DBNull.Value, Nothing, dr("SSVIGENCIA"))
                mEntidad.ISSSRECEPCION = IIf(dr("ISSSRECEPCION") Is DBNull.Value, Nothing, dr("ISSSRECEPCION"))
                mEntidad.ISSSVIGENCIA = IIf(dr("ISSSVIGENCIA") Is DBNull.Value, Nothing, dr("ISSSVIGENCIA"))
                mEntidad.IMPUESTOSRECEPCION = IIf(dr("IMPUESTOSRECEPCION") Is DBNull.Value, Nothing, dr("IMPUESTOSRECEPCION"))
                mEntidad.IMPUESTOSVIGENCIA = IIf(dr("IMPUESTOSVIGENCIA") Is DBNull.Value, Nothing, dr("IMPUESTOSVIGENCIA"))
                mEntidad.ALCALDIARECEPCION = IIf(dr("ALCALDIARECEPCION") Is DBNull.Value, Nothing, dr("ALCALDIARECEPCION"))
                mEntidad.ALCALDIAVIGENCIA = IIf(dr("ALCALDIAVIGENCIA") Is DBNull.Value, Nothing, dr("ALCALDIAVIGENCIA"))
                mEntidad.PRESENTANOTA = IIf(dr("PRESENTANOTA") Is DBNull.Value, Nothing, dr("PRESENTANOTA"))
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
        tables(0) = New String("NOTASACEPTACION")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" FECHARECEPCION, ")
        strSQL.Append(" NOMBREPERSONAFIRMA, ")
        strSQL.Append(" DUIPERSONAFIRMA, ")
        strSQL.Append(" AFPCONFIARECEPCION, ")
        strSQL.Append(" AFPCONFIAVIGENCIA, ")
        strSQL.Append(" AFPCRECERRECEPCION, ")
        strSQL.Append(" AFPCRECERVIGENCIA, ")
        strSQL.Append(" IPFARECEPCION, ")
        strSQL.Append(" IPFAVIGENCIA, ")
        strSQL.Append(" SSRECEPCION, ")
        strSQL.Append(" SSVIGENCIA, ")
        strSQL.Append(" ISSSRECEPCION, ")
        strSQL.Append(" ISSSVIGENCIA, ")
        strSQL.Append(" IMPUESTOSRECEPCION, ")
        strSQL.Append(" IMPUESTOSVIGENCIA, ")
        strSQL.Append(" ALCALDIARECEPCION, ")
        strSQL.Append(" ALCALDIAVIGENCIA, ")
        strSQL.Append(" PRESENTANOTA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_NOTASACEPTACION ")

    End Sub

#End Region

End Class
