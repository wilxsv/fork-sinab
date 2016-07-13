Imports System.Text

Public Class dbDISTRIBUCIONDETALLE
    Inherits dbBase

#Region "Sin Utilizar"
    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String
        Return String.Empty
    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer
    End Function
#End Region

    Public Function agregarDistribucionDetalle(ByVal lEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_LlenadoProductosDistribucion")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@RESULTADO", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue

        args(1) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = lEntidad.IDDISTRIBUCION

        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = lEntidad.IDESTABLECIMIENTO

        args(3) = New SqlParameter("@ABASTECIMIENTO", SqlDbType.Int)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = lEntidad.MESESADMINCPM + lEntidad.MESESCOBERTURA + lEntidad.MESESSEGURIDADCPM

        args(4) = New SqlParameter("@FINI", SqlDbType.DateTime)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = DateAdd(DateInterval.Month, (lEntidad.MESESCPM - 1) * (-1), lEntidad.FECHADISTRIBUCION)

        args(5) = New SqlParameter("@FFIN", SqlDbType.DateTime)
        args(5).Direction = ParameterDirection.Input
        args(5).Value = lEntidad.FECHADISTRIBUCION

        SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

    Public Function obtenerDistribucionDetalle(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT DISTINCT ")
        strSQL.Append("   IDDISTRIBUCION, IDESTABLECIMIENTODISTRIBUCION, DD.IDPRODUCTO, ")
        strSQL.Append("   ISNULL(CONVERT(VARCHAR, CONSUMOPROMEDIOAJUSTADO), '-') AS CPMA, ")
        strSQL.Append("   ISNULL(CONVERT(VARCHAR, EXISTENCIA), '-') AS EXISTENCIA, ")
        strSQL.Append("   CANTIDADDISTRIBUIR, CONVERT(INTEGER, CANTIDADREAL) as CANTIDADREAL, ")
        strSQL.Append("   CODIGOESTABLECIMIENTO, NOMBRE, ")
        strSQL.Append("   REPORTECOMPLETO, INCONSISTENCIA,ISNULL(EXISTENCIAFARMACIA,0) AS EXISTENCIAFARMACIA ")
        strSQL.Append(" FROM ")
        strSQL.Append("   DBO.SAB_EST_DISTRIBUCIONDETALLE DD ")
        strSQL.Append("     INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ON ")
        strSQL.Append("       DD.IDESTABLECIMIENTODISTRIBUCION = E.IDESTABLECIMIENTO ")
        strSQL.Append(" INNER JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE ON E.IDESTABLECIMIENTO = AE.IDESTABLECIMIENTO ")
        ' strSQL.Append(" INNER JOIN SAB_ALM_PRODUCTOSALMACEN A ON AE.IDALMACEN = A.IdHospital ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   DD.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("   DD.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("   DD.IDPRODUCTO = @IDPRODUCTO ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("   E.CODIGOESTABLECIMIENTO ASC ")


        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO
  

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    Public Function obtenerDistribucionDetalle2(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer, fechaconsumo As Date, Optional meses As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" exec sproc_obtenerDistribucionDetalle2 @IDDISTRIBUCION,@IDESTABLECIMIENTO,@IDPRODUCTO,@FECHACONSUMO," & meses)
        'strSQL.Append("   IDDISTRIBUCION, IDESTABLECIMIENTODISTRIBUCION, DD.IDPRODUCTO, ")
        'strSQL.Append("   ISNULL(CONVERT(VARCHAR, CONSUMOPROMEDIOAJUSTADO), '-') AS CPMA, ")
        'strSQL.Append("   ISNULL(CONVERT(VARCHAR, dbo.fn_ExistenciaAlmacenA(a.idhospital,@idproducto)), '-') AS EXISTENCIAA, ")
        'strSQL.Append("   ISNULL(CONVERT(VARCHAR, dbo.fn_ExistenciaAlmacenF(a.idhospital,@idproducto,AE.IDESTABLECIMIENTO,@fechaconsumo)), '-') AS EXISTENCIAF, ")
        'strSQL.Append(" CASE WHEN ((ISNULL(CONSUMOPROMEDIOAJUSTADO,0)*" & meses & ")-dbo.fn_ExistenciaAlmacen(a.idhospital,@idproducto,AE.IDESTABLECIMIENTO,@fechaconsumo))<0 THEN 0 ELSE ((ISNULL(CONSUMOPROMEDIOAJUSTADO,0)*" & meses & ")-dbo.fn_ExistenciaAlmacen(a.idhospital,@idproducto,AE.IDESTABLECIMIENTO,@fechaconsumo)) END as CANTIDADDISTRIBUIR,")
        'strSQL.Append(" CASE WHEN (CONVERT(INTEGER,(ISNULL(CONSUMOPROMEDIOAJUSTADO,0)*" & meses & ")-dbo.fn_ExistenciaAlmacen(a.idhospital,@idproducto,AE.IDESTABLECIMIENTO,@fechaconsumo)))<0 THEN 0 ELSE (CONVERT(INTEGER,(ISNULL(CONSUMOPROMEDIOAJUSTADO,0)*" & meses & ")-dbo.fn_ExistenciaAlmacen(a.idhospital,@idproducto,AE.IDESTABLECIMIENTO,@fechaconsumo))) END as CANTIDADREAL, ")

        ''strSQL.Append("   CANTIDADDISTRIBUIR, CONVERT(INTEGER, CANTIDADREAL) as CANTIDADREAL, ")
        'strSQL.Append("   CODIGOESTABLECIMIENTO, NOMBRE, ")
        'strSQL.Append("   REPORTECOMPLETO, INCONSISTENCIA ")
        'strSQL.Append(" FROM ")
        'strSQL.Append("   DBO.SAB_EST_DISTRIBUCIONDETALLE DD ")
        'strSQL.Append("     INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ON ")
        'strSQL.Append("       DD.IDESTABLECIMIENTODISTRIBUCION = E.IDESTABLECIMIENTO ")
        'strSQL.Append(" INNER JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE ON E.IDESTABLECIMIENTO = AE.IDESTABLECIMIENTO ")
        'strSQL.Append(" INNER JOIN SAB_ALM_PRODUCTOSALMACEN A ON AE.IDALMACEN = A.IdHospital ")
        'strSQL.Append(" WHERE ")
        'strSQL.Append("   DD.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        'strSQL.Append("   DD.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        'strSQL.Append("   DD.IDPRODUCTO = @IDPRODUCTO ")
        'strSQL.Append(" ORDER BY ")
        'strSQL.Append("   E.CODIGOESTABLECIMIENTO ASC ")


        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO
        args(3) = New SqlParameter("@fechaconsumo", SqlDbType.Date)
        args(3).Value = fechaconsumo
        Using conn As New SqlConnection(cnnStr)
            Dim cmd As SqlCommand = New SqlCommand(strSQL.ToString(), conn)
            cmd.CommandTimeout = 160
            cmd.Parameters.AddRange(args)
            conn.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                Dim dt As New DataTable
                Dim ds As New DataSet
                'LEE EL READER
                dt.Load(reader)

                'CIERRA CONEXION
                conn.Close()

                'AGREGA LA DATATABLE AL DATASOURCE
                ds.Tables.Add(dt)
                Return ds
            End Using
        End Using

        'Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    Public Function actualizarDistribucionDetalle(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDESTABLECIMIENTODISTRIBUCION As Integer, ByVal IDPRODUCTO As Integer, ByVal CANTIDAD As Decimal, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append("   UPDATE ")
        strSQL.Append("     DBO.SAB_EST_DISTRIBUCIONDETALLE ")
        strSQL.Append("   SET ")
        strSQL.Append("     CANTIDADREAL = @CANTIDADREAL, ")
        strSQL.Append("     AUUSUARIOMODIFICACION = @USUARIO, ")
        strSQL.Append("     AUFECHAMODIFICACION = @FECHA ")
        strSQL.Append("   WHERE ")
        strSQL.Append("     IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("     IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("     IDESTABLECIMIENTODISTRIBUCION = @IDESTABLECIMIENTODISTRIBUCION AND ")
        strSQL.Append("     IDPRODUCTO = @IDPRODUCTO ")


        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO
        args(3) = New SqlParameter("@IDESTABLECIMIENTODISTRIBUCION", SqlDbType.Int)
        args(3).Value = IDESTABLECIMIENTODISTRIBUCION
        args(4) = New SqlParameter("@CANTIDADREAL", SqlDbType.Decimal)
        args(4).Value = CANTIDAD
        args(5) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(5).Value = USUARIO
        args(6) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(6).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString, args)

    End Function

End Class
