Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbINFORMESNOACEPTACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_ALM_INFORMESNOACEPTACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbINFORMESNOACEPTACION
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INFORMESNOACEPTACION
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDINFORME = 0 _
            Or lEntidad.IDINFORME = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDINFORME = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_ALM_INFORMESNOACEPTACION ")
        strSQL.Append(" SET IDESTABLECIMIENTO = @IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR = @IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO = @IDCONTRATO, ")
        strSQL.Append(" RESPONSABLEPROVEEDOR = @RESPONSABLEPROVEEDOR, ")
        strSQL.Append(" IDJEFEALMACEN = @IDJEFEALMACEN, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" MOTIVO = @MOTIVO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDINFORME = @IDINFORME ")

        Dim args(14) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@RESPONSABLEPROVEEDOR", SqlDbType.VarChar)
        args(3).Value = lEntidad.RESPONSABLEPROVEEDOR
        args(4) = New SqlParameter("@IDJEFEALMACEN", SqlDbType.Int)
        args(4).Value = IIf(lEntidad.IDJEFEALMACEN = Nothing, DBNull.Value, lEntidad.IDJEFEALMACEN)
        args(5) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(6) = New SqlParameter("@MOTIVO", SqlDbType.VarChar)
        args(6).Value = lEntidad.MOTIVO
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
        args(12).Value = IIf(lEntidad.IDALMACEN = Nothing, DBNull.Value, lEntidad.IDALMACEN)
        args(13) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(13).Value = IIf(lEntidad.ANIO = Nothing, DBNull.Value, lEntidad.ANIO)
        args(14) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(14).Value = IIf(lEntidad.IDINFORME = Nothing, DBNull.Value, lEntidad.IDINFORME)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INFORMESNOACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_ALM_INFORMESNOACEPTACION ")
        strSQL.Append(" ( IDALMACEN, ")
        strSQL.Append(" ANIO, ")
        strSQL.Append(" IDINFORME, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" RESPONSABLEPROVEEDOR, ")
        strSQL.Append(" IDJEFEALMACEN, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" MOTIVO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALMACEN, ")
        strSQL.Append(" @ANIO, ")
        strSQL.Append(" @IDINFORME, ")
        strSQL.Append(" @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @RESPONSABLEPROVEEDOR, ")
        strSQL.Append(" @IDJEFEALMACEN, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @MOTIVO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(14) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(2).Value = lEntidad.IDINFORME
        args(3) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(3).Value = lEntidad.IDESTABLECIMIENTO
        args(4) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(4).Value = lEntidad.IDPROVEEDOR
        args(5) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(5).Value = lEntidad.IDCONTRATO
        args(6) = New SqlParameter("@RESPONSABLEPROVEEDOR", SqlDbType.VarChar)
        args(6).Value = lEntidad.RESPONSABLEPROVEEDOR
        args(7) = New SqlParameter("@IDJEFEALMACEN", SqlDbType.Int)
        args(7).Value = IIf(lEntidad.IDJEFEALMACEN = Nothing, DBNull.Value, lEntidad.IDJEFEALMACEN)
        args(8) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(9) = New SqlParameter("@MOTIVO", SqlDbType.VarChar)
        args(9).Value = lEntidad.MOTIVO
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

        Dim lEntidad As INFORMESNOACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_INFORMESNOACEPTACION ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDINFORME = @IDINFORME ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(2).Value = lEntidad.IDINFORME

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INFORMESNOACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDINFORME = @IDINFORME ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(2).Value = lEntidad.IDINFORME

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDESTABLECIMIENTO = IIf(.Item("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTO"))
                lEntidad.IDPROVEEDOR = IIf(.Item("IDPROVEEDOR") Is DBNull.Value, Nothing, .Item("IDPROVEEDOR"))
                lEntidad.IDCONTRATO = IIf(.Item("IDCONTRATO") Is DBNull.Value, Nothing, .Item("IDCONTRATO"))
                lEntidad.RESPONSABLEPROVEEDOR = IIf(.Item("RESPONSABLEPROVEEDOR") Is DBNull.Value, Nothing, .Item("RESPONSABLEPROVEEDOR"))
                lEntidad.IDJEFEALMACEN = IIf(.Item("IDJEFEALMACEN") Is DBNull.Value, Nothing, .Item("IDJEFEALMACEN"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
                lEntidad.MOTIVO = IIf(.Item("MOTIVO") Is DBNull.Value, Nothing, .Item("MOTIVO"))
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

        Dim lEntidad As INFORMESNOACEPTACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDINFORME),0) + 1 ")
        strSQL.Append(" FROM SAB_ALM_INFORMESNOACEPTACION ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32) As listaINFORMESNOACEPTACION

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaINFORMESNOACEPTACION

        Try
            Do While dr.Read()
                Dim mEntidad As New INFORMESNOACEPTACION
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.ANIO = IIf(dr("ANIO") Is DBNull.Value, Nothing, dr("ANIO"))
                mEntidad.IDINFORME = IIf(dr("IDINFORME") Is DBNull.Value, Nothing, dr("IDINFORME"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.IDPROVEEDOR = IIf(dr("IDPROVEEDOR") Is DBNull.Value, Nothing, dr("IDPROVEEDOR"))
                mEntidad.IDCONTRATO = IIf(dr("IDCONTRATO") Is DBNull.Value, Nothing, dr("IDCONTRATO"))
                mEntidad.RESPONSABLEPROVEEDOR = IIf(dr("RESPONSABLEPROVEEDOR") Is DBNull.Value, Nothing, dr("RESPONSABLEPROVEEDOR"))
                mEntidad.IDJEFEALMACEN = IIf(dr("IDJEFEALMACEN") Is DBNull.Value, Nothing, dr("IDJEFEALMACEN"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.MOTIVO = IIf(dr("MOTIVO") Is DBNull.Value, Nothing, dr("MOTIVO"))
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

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim tables(0) As String
        tables(0) = New String("INFORMESNOACEPTACION")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDALMACEN, ")
        strSQL.Append(" ANIO, ")
        strSQL.Append(" IDINFORME, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" RESPONSABLEPROVEEDOR, ")
        strSQL.Append(" IDJEFEALMACEN, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" MOTIVO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_ALM_INFORMESNOACEPTACION ")

    End Sub

#End Region

End Class
