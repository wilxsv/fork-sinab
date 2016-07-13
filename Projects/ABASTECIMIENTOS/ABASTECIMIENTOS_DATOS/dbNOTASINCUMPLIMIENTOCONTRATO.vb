Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbNOTASINCUMPLIMIENTOCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla NOTASINCUMPLIMIENTOCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbNOTASINCUMPLIMIENTOCONTRATO
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NOTASINCUMPLIMIENTOCONTRATO
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDNOTA = 0 _
            Or lEntidad.IDNOTA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDNOTA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO ")
        strSQL.Append(" SET NOMBREPERSONADIRIGIDA = @NOMBREPERSONADIRIGIDA, ")
        strSQL.Append(" CARGOPERSONADIRIGIDA = @CARGOPERSONADIRIGIDA, ")
        strSQL.Append(" IDEMPLEADOENVIA = @IDEMPLEADOENVIA, ")
        strSQL.Append(" TITULONOTA = @TITULONOTA, ")
        strSQL.Append(" FECHAENTREGA = @FECHAENTREGA, ")
        strSQL.Append(" NUMEROINFORME = @NUMEROINFORME, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDNOTA = @IDNOTA ")

        Dim args(14) As SqlParameter
        args(0) = New SqlParameter("@NOMBREPERSONADIRIGIDA", SqlDbType.VarChar)
        args(0).Value = lEntidad.NOMBREPERSONADIRIGIDA
        args(1) = New SqlParameter("@CARGOPERSONADIRIGIDA", SqlDbType.VarChar)
        args(1).Value = lEntidad.CARGOPERSONADIRIGIDA
        args(2) = New SqlParameter("@IDEMPLEADOENVIA", SqlDbType.Int)
        args(2).Value = lEntidad.IDEMPLEADOENVIA
        args(3) = New SqlParameter("@TITULONOTA", SqlDbType.VarChar)
        args(3).Value = lEntidad.TITULONOTA
        args(4) = New SqlParameter("@FECHAENTREGA", SqlDbType.DateTime)
        args(4).Value = lEntidad.FECHAENTREGA
        args(5) = New SqlParameter("@NUMEROINFORME", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.NUMEROINFORME = Nothing, DBNull.Value, lEntidad.NUMEROINFORME)
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(10) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(10).Value = lEntidad.ESTASINCRONIZADA
        args(11) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(11).Value = lEntidad.IDESTABLECIMIENTO
        args(12) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(12).Value = lEntidad.IDPROVEEDOR
        args(13) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(13).Value = lEntidad.IDCONTRATO
        args(14) = New SqlParameter("@IDNOTA", SqlDbType.Int)
        args(14).Value = lEntidad.IDNOTA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NOTASINCUMPLIMIENTOCONTRATO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDNOTA, ")
        strSQL.Append(" NOMBREPERSONADIRIGIDA, ")
        strSQL.Append(" CARGOPERSONADIRIGIDA, ")
        strSQL.Append(" IDEMPLEADOENVIA, ")
        strSQL.Append(" TITULONOTA, ")
        strSQL.Append(" FECHAENTREGA, ")
        strSQL.Append(" NUMEROINFORME, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @IDNOTA, ")
        strSQL.Append(" @NOMBREPERSONADIRIGIDA, ")
        strSQL.Append(" @CARGOPERSONADIRIGIDA, ")
        strSQL.Append(" @IDEMPLEADOENVIA, ")
        strSQL.Append(" @TITULONOTA, ")
        strSQL.Append(" @FECHAENTREGA, ")
        strSQL.Append(" @NUMEROINFORME, ")
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
        args(3) = New SqlParameter("@IDNOTA", SqlDbType.Int)
        args(3).Value = lEntidad.IDNOTA
        args(4) = New SqlParameter("@NOMBREPERSONADIRIGIDA", SqlDbType.VarChar)
        args(4).Value = lEntidad.NOMBREPERSONADIRIGIDA
        args(5) = New SqlParameter("@CARGOPERSONADIRIGIDA", SqlDbType.VarChar)
        args(5).Value = lEntidad.CARGOPERSONADIRIGIDA
        args(6) = New SqlParameter("@IDEMPLEADOENVIA", SqlDbType.Int)
        args(6).Value = lEntidad.IDEMPLEADOENVIA
        args(7) = New SqlParameter("@TITULONOTA", SqlDbType.VarChar)
        args(7).Value = lEntidad.TITULONOTA
        args(8) = New SqlParameter("@FECHAENTREGA", SqlDbType.DateTime)
        args(8).Value = lEntidad.FECHAENTREGA
        args(9) = New SqlParameter("@NUMEROINFORME", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.NUMEROINFORME = Nothing, DBNull.Value, lEntidad.NUMEROINFORME)
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

        Dim lEntidad As NOTASINCUMPLIMIENTOCONTRATO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDNOTA = @IDNOTA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDNOTA", SqlDbType.Int)
        args(3).Value = lEntidad.IDNOTA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As NOTASINCUMPLIMIENTOCONTRATO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDNOTA = @IDNOTA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDNOTA", SqlDbType.Int)
        args(3).Value = lEntidad.IDNOTA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.NOMBREPERSONADIRIGIDA = IIf(.Item("NOMBREPERSONADIRIGIDA") Is DBNull.Value, Nothing, .Item("NOMBREPERSONADIRIGIDA"))
                lEntidad.CARGOPERSONADIRIGIDA = IIf(.Item("CARGOPERSONADIRIGIDA") Is DBNull.Value, Nothing, .Item("CARGOPERSONADIRIGIDA"))
                lEntidad.IDEMPLEADOENVIA = IIf(.Item("IDEMPLEADOENVIA") Is DBNull.Value, Nothing, .Item("IDEMPLEADOENVIA"))
                lEntidad.TITULONOTA = IIf(.Item("TITULONOTA") Is DBNull.Value, Nothing, .Item("TITULONOTA"))
                lEntidad.FECHAENTREGA = IIf(.Item("FECHAENTREGA") Is DBNull.Value, Nothing, .Item("FECHAENTREGA"))
                lEntidad.NUMEROINFORME = IIf(.Item("NUMEROINFORME") Is DBNull.Value, Nothing, .Item("NUMEROINFORME"))
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

        Dim lEntidad As NOTASINCUMPLIMIENTOCONTRATO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDNOTA),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As listaNOTASINCUMPLIMIENTOCONTRATO

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaNOTASINCUMPLIMIENTOCONTRATO

        Try
            Do While dr.Read()
                Dim mEntidad As New NOTASINCUMPLIMIENTOCONTRATO
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
                mEntidad.IDNOTA = IIf(dr("IDNOTA") Is DBNull.Value, Nothing, dr("IDNOTA"))
                mEntidad.NOMBREPERSONADIRIGIDA = IIf(dr("NOMBREPERSONADIRIGIDA") Is DBNull.Value, Nothing, dr("NOMBREPERSONADIRIGIDA"))
                mEntidad.CARGOPERSONADIRIGIDA = IIf(dr("CARGOPERSONADIRIGIDA") Is DBNull.Value, Nothing, dr("CARGOPERSONADIRIGIDA"))
                mEntidad.IDEMPLEADOENVIA = IIf(dr("IDEMPLEADOENVIA") Is DBNull.Value, Nothing, dr("IDEMPLEADOENVIA"))
                mEntidad.TITULONOTA = IIf(dr("TITULONOTA") Is DBNull.Value, Nothing, dr("TITULONOTA"))
                mEntidad.FECHAENTREGA = IIf(dr("FECHAENTREGA") Is DBNull.Value, Nothing, dr("FECHAENTREGA"))
                mEntidad.NUMEROINFORME = IIf(dr("NUMEROINFORME") Is DBNull.Value, Nothing, dr("NUMEROINFORME"))
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

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Dim tables(0) As String
        tables(0) = New String("NOTASINCUMPLIMIENTOCONTRATO")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDNOTA, ")
        strSQL.Append(" NOMBREPERSONADIRIGIDA, ")
        strSQL.Append(" CARGOPERSONADIRIGIDA, ")
        strSQL.Append(" IDEMPLEADOENVIA, ")
        strSQL.Append(" TITULONOTA, ")
        strSQL.Append(" FECHAENTREGA, ")
        strSQL.Append(" NUMEROINFORME, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO ")

    End Sub
#End Region

End Class
