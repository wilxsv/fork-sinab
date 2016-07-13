Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbRECIBOSRECEPCION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_ALM_RECIBOSRECEPCION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	06/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbRECIBOSRECEPCION
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RECIBOSRECEPCION
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDRECIBO = 0 _
            Or lEntidad.IDRECIBO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDRECIBO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_ALM_RECIBOSRECEPCION ")
        strSQL.Append(" SET IDESTABLECIMIENTO = @IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR = @IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO = @IDCONTRATO, ")
        strSQL.Append(" RESPONSABLEPROVEEDOR = @RESPONSABLEPROVEEDOR, ")
        strSQL.Append(" NUMEROACTA = @NUMEROACTA, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA, ")
        strSQL.Append(" IDALMACENVALE = @IDALMACENVALE, ")
        strSQL.Append(" ANIOVALE = @ANIOVALE, ")
        strSQL.Append(" IDVALE = @IDVALE, ")
        strSQL.Append(" NUMEROVALE = @NUMEROVALE, ")
        strSQL.Append(" IDESTABLECIMIENTODEVOLUCION = @IDESTABLECIMIENTODEVOLUCION, ")
        strSQL.Append(" ADMCONTRATO = @ADMCONTRATO ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND IDRECIBO = @IDRECIBO ")
        strSQL.Append(" AND ANIO = @ANIO ")


        Dim args(19) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IIf(lEntidad.IDPROVEEDOR = Nothing, DBNull.Value, lEntidad.IDPROVEEDOR)
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IIf(lEntidad.IDCONTRATO = Nothing, DBNull.Value, lEntidad.IDCONTRATO)
        args(3) = New SqlParameter("@RESPONSABLEPROVEEDOR", SqlDbType.VarChar)
        args(3).Value = lEntidad.RESPONSABLEPROVEEDOR
        args(4) = New SqlParameter("@NUMEROACTA", SqlDbType.Int)
        args(4).Value = lEntidad.NUMEROACTA
        args(5) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
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
        args(11) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(11).Value = lEntidad.IDALMACEN
        args(12) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(12).Value = lEntidad.ANIO
        args(13) = New SqlParameter("@IDRECIBO", SqlDbType.Int)
        args(13).Value = lEntidad.IDRECIBO
        args(14) = New SqlParameter("@IDALMACENVALE", SqlDbType.Int)
        args(14).Value = IIf(lEntidad.IDALMACENVALE = Nothing, DBNull.Value, lEntidad.IDALMACENVALE)
        args(15) = New SqlParameter("@ANIOVALE", SqlDbType.SmallInt)
        args(15).Value = IIf(lEntidad.ANIOVALE = Nothing, DBNull.Value, lEntidad.ANIOVALE)
        args(16) = New SqlParameter("@IDVALE", SqlDbType.Int)
        args(16).Value = IIf(lEntidad.IDVALE = Nothing, DBNull.Value, lEntidad.IDVALE)
        args(17) = New SqlParameter("@NUMEROVALE", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.NUMEROVALE = Nothing, DBNull.Value, lEntidad.NUMEROVALE)
        args(18) = New SqlParameter("@IDESTABLECIMIENTODEVOLUCION", SqlDbType.Int)
        args(18).Value = IIf(lEntidad.IDESTABLECIMIENTODEVOLUCION = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTODEVOLUCION)
        args(19) = New SqlParameter("@ADMCONTRATO", SqlDbType.VarChar)
        args(19).Value = lEntidad.ADMCONTRATO


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RECIBOSRECEPCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_ALM_RECIBOSRECEPCION ")
        strSQL.Append(" ( IDALMACEN, ")
        strSQL.Append(" ANIO, ")
        strSQL.Append(" IDRECIBO, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" RESPONSABLEPROVEEDOR, ")
        strSQL.Append(" NUMEROACTA, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" IDALMACENVALE, ")
        strSQL.Append(" ANIOVALE, ")
        strSQL.Append(" IDVALE, ")
        strSQL.Append(" NUMEROVALE, ")
        strSQL.Append(" IDESTABLECIMIENTODEVOLUCION) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDALMACEN, ")
        strSQL.Append(" @ANIO, ")
        strSQL.Append(" @IDRECIBO, ")
        strSQL.Append(" @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @RESPONSABLEPROVEEDOR, ")
        strSQL.Append(" @NUMEROACTA, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @ESTASINCRONIZADA, ")
        strSQL.Append(" @IDALMACENVALE, ")
        strSQL.Append(" @ANIOVALE, ")
        strSQL.Append(" @IDVALE, ")
        strSQL.Append(" @NUMEROVALE, ")
        strSQL.Append(" @IDESTABLECIMIENTODEVOLUCION) ")

        Dim args(18) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDRECIBO", SqlDbType.Int)
        args(2).Value = lEntidad.IDRECIBO
        args(3) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(3).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(4) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(4).Value = IIf(lEntidad.IDPROVEEDOR = Nothing, DBNull.Value, lEntidad.IDPROVEEDOR)
        args(5) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(5).Value = IIf(lEntidad.IDCONTRATO = Nothing, DBNull.Value, lEntidad.IDCONTRATO)
        args(6) = New SqlParameter("@RESPONSABLEPROVEEDOR", SqlDbType.VarChar)
        args(6).Value = lEntidad.RESPONSABLEPROVEEDOR
        args(7) = New SqlParameter("@NUMEROACTA", SqlDbType.Int)
        args(7).Value = lEntidad.NUMEROACTA
        args(8) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
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
        args(14) = New SqlParameter("@IDALMACENVALE", SqlDbType.Int)
        args(14).Value = IIf(lEntidad.IDALMACENVALE = Nothing, DBNull.Value, lEntidad.IDALMACENVALE)
        args(15) = New SqlParameter("@ANIOVALE", SqlDbType.SmallInt)
        args(15).Value = IIf(lEntidad.ANIOVALE = Nothing, DBNull.Value, lEntidad.ANIOVALE)
        args(16) = New SqlParameter("@IDVALE", SqlDbType.Int)
        args(16).Value = IIf(lEntidad.IDVALE = Nothing, DBNull.Value, lEntidad.IDVALE)
        args(17) = New SqlParameter("@NUMEROVALE", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.NUMEROVALE = Nothing, DBNull.Value, lEntidad.NUMEROVALE)
        args(18) = New SqlParameter("@IDESTABLECIMIENTODEVOLUCION", SqlDbType.Int)
        args(18).Value = IIf(lEntidad.IDESTABLECIMIENTODEVOLUCION = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTODEVOLUCION)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RECIBOSRECEPCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_RECIBOSRECEPCION ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDRECIBO = @IDRECIBO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDRECIBO", SqlDbType.Int)
        args(2).Value = lEntidad.IDRECIBO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As RECIBOSRECEPCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")
        strSQL.Append(" AND IDRECIBO = @IDRECIBO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO
        args(2) = New SqlParameter("@IDRECIBO", SqlDbType.Int)
        args(2).Value = lEntidad.IDRECIBO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDESTABLECIMIENTO = IIf(.Item("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTO"))
                lEntidad.IDPROVEEDOR = IIf(.Item("IDPROVEEDOR") Is DBNull.Value, Nothing, .Item("IDPROVEEDOR"))
                lEntidad.IDCONTRATO = IIf(.Item("IDCONTRATO") Is DBNull.Value, Nothing, .Item("IDCONTRATO"))
                lEntidad.RESPONSABLEPROVEEDOR = IIf(.Item("RESPONSABLEPROVEEDOR") Is DBNull.Value, Nothing, .Item("RESPONSABLEPROVEEDOR"))
                lEntidad.NUMEROACTA = IIf(.Item("NUMEROACTA") Is DBNull.Value, Nothing, .Item("NUMEROACTA"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.IDALMACENVALE = IIf(.Item("IDALMACENVALE") Is DBNull.Value, Nothing, .Item("IDALMACENVALE"))
                lEntidad.ANIOVALE = IIf(.Item("ANIOVALE") Is DBNull.Value, Nothing, .Item("ANIOVALE"))
                lEntidad.IDVALE = IIf(.Item("IDVALE") Is DBNull.Value, Nothing, .Item("IDVALE"))
                lEntidad.NUMEROVALE = IIf(.Item("NUMEROVALE") Is DBNull.Value, Nothing, .Item("NUMEROVALE"))
                lEntidad.IDESTABLECIMIENTODEVOLUCION = IIf(.Item("IDESTABLECIMIENTODEVOLUCION") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTODEVOLUCION"))
                lEntidad.ADMCONTRATO = IIf(.Item("admcontrato") Is DBNull.Value, Nothing, .Item("admcontrato"))

            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As RECIBOSRECEPCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDRECIBO),0) + 1 ")
        strSQL.Append(" FROM SAB_ALM_RECIBOSRECEPCION ")
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append(" AND ANIO = @ANIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@ANIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.ANIO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32) As listaRECIBOSRECEPCION

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaRECIBOSRECEPCION

        Try
            Do While dr.Read()
                Dim mEntidad As New RECIBOSRECEPCION
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.ANIO = IIf(dr("ANIO") Is DBNull.Value, Nothing, dr("ANIO"))
                mEntidad.IDRECIBO = IIf(dr("IDRECIBO") Is DBNull.Value, Nothing, dr("IDRECIBO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.IDPROVEEDOR = IIf(dr("IDPROVEEDOR") Is DBNull.Value, Nothing, dr("IDPROVEEDOR"))
                mEntidad.IDCONTRATO = IIf(dr("IDCONTRATO") Is DBNull.Value, Nothing, dr("IDCONTRATO"))
                mEntidad.RESPONSABLEPROVEEDOR = IIf(dr("RESPONSABLEPROVEEDOR") Is DBNull.Value, Nothing, dr("RESPONSABLEPROVEEDOR"))
                mEntidad.NUMEROACTA = IIf(dr("NUMEROACTA") Is DBNull.Value, Nothing, dr("NUMEROACTA"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.IDALMACENVALE = IIf(dr("IDALMACENVALE") Is DBNull.Value, Nothing, dr("IDALMACENVALE"))
                mEntidad.ANIOVALE = IIf(dr("ANIOVALE") Is DBNull.Value, Nothing, dr("ANIOVALE"))
                mEntidad.IDVALE = IIf(dr("IDVALE") Is DBNull.Value, Nothing, dr("IDVALE"))
                mEntidad.NUMEROVALE = IIf(dr("NUMEROVALE") Is DBNull.Value, Nothing, dr("NUMEROVALE"))
                mEntidad.IDESTABLECIMIENTODEVOLUCION = IIf(dr("IDESTABLECIMIENTODEVOLUCION") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTODEVOLUCION"))
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
        tables(0) = New String("RECIBOSRECEPCION")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append("SELECT IDALMACEN, ")
        strSQL.Append("ANIO, ")
        strSQL.Append("IDRECIBO, ")
        strSQL.Append("IDESTABLECIMIENTO, ")
        strSQL.Append("IDPROVEEDOR, ")
        strSQL.Append("IDCONTRATO, ")
        strSQL.Append("RESPONSABLEPROVEEDOR, ")
        strSQL.Append("NUMEROACTA, ")
        strSQL.Append("OBSERVACION, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA, ")
        strSQL.Append("IDALMACENVALE, ")
        strSQL.Append("ANIOVALE, ")
        strSQL.Append("IDVALE, ")
        strSQL.Append("NUMEROVALE, ")
        strSQL.Append("IDESTABLECIMIENTODEVOLUCION, ")
        strSQL.Append("ADMCONTRATO ")

        strSQL.Append("FROM SAB_ALM_RECIBOSRECEPCION ")

    End Sub

#End Region

End Class
