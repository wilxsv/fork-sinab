Imports System.Text

Public Class dbDISTRIBUCION
    Inherits dbBase

#Region "Sin utilizar"
    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer
    End Function
#End Region

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT ")
        strSQL.Append("   D.IDESTABLECIMIENTO, D.FECHACORTE, D.FECHADISTRIBUCION, (convert(varchar, MONTH(D.FECHADISTRIBUCION)) + '/' + ")
        strSQL.Append("   convert(varchar, YEAR(D.FECHADISTRIBUCION))) AS PERIODO, D.IDDISTRIBUCION, D.DESCRIPCION, ")
        strSQL.Append("   D.MESESCPM, D.MESESDISTRIBUCION, D.MESESSEGURIDAD, D.MESESADMINISTRACION, D.IDALMACEN, A.NOMBRE AS ALMACEN, S.IDSUMINISTRO, D.ESTADO, S.DESCRIPCION as SUMINISTRO, ")
        strSQL.Append("   CASE ")
        strSQL.Append("     WHEN D.ESTADO = 0 THEN 'Iniciada' ")
        strSQL.Append("     WHEN D.ESTADO = 1 THEN 'Guardada' ")
        strSQL.Append("     WHEN D.ESTADO = 2 THEN 'Cerrada' ")
        strSQL.Append("     WHEN D.ESTADO = 3 THEN 'Pendiente' ")
        strSQL.Append("     WHEN D.ESTADO = 4 THEN 'Finalizada' ")
        ' Se agrega estado Anulada a peticion de la UNAB 19032012
        strSQL.Append("     WHEN D.ESTADO = 5 THEN 'Anulada' ")

        strSQL.Append("     ELSE 'Finalizada' ")
        strSQL.Append("   END AS NESTADO, D.IDPROGRAMA ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_EST_DISTRIBUCION D ")
        strSQL.Append("     INNER JOIN SAB_CAT_ALMACENES A ")
        strSQL.Append("       ON D.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("     INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("       ON D.IDSUMINISTRO = S.IDSUMINISTRO ")


    End Sub

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As DISTRIBUCION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDDISTRIBUCION),0) + 1 ")
        strSQL.Append(" FROM SAB_EST_DISTRIBUCION WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function actualizarDistribucion(ByVal aEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction) As Integer

        Dim lID As Long

        If aEntidad.IDDISTRIBUCION = 0 Or aEntidad.IDDISTRIBUCION = Nothing Then

            lID = Me.ObtenerID(aEntidad)

            If lID = -1 Then Return -1

            aEntidad.IDDISTRIBUCION = lID

            Return agregarDistribucion(aEntidad, tran)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_EST_DISTRIBUCION SET ")
        strSQL.Append("  IDALMACEN = @IDALMACEN, DESCRIPCION = @DESCRIPCION, FECHACORTE = @FECHACORTE, ")
        strSQL.Append("  MESESCPM = @MESESCPM, MESESADMINISTRACION = @MESESADMINCPM, MESESSEGURIDAD = @MESESSEGURIDADCPM, MESESDISTRIBUCION = @MESESCOBERTURA,")
        strSQL.Append("  AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("  IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@FECHADISTRIBUCION", SqlDbType.DateTime)
        args(2).Value = aEntidad.FECHADISTRIBUCION
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(3).Value = aEntidad.IDALMACEN
        args(4) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(4).Value = aEntidad.DESCRIPCION
        args(5) = New SqlParameter("@MESESCPM", SqlDbType.Int)
        args(5).Value = aEntidad.MESESCPM
        args(6) = New SqlParameter("@MESESCOBERTURA", SqlDbType.Int)
        args(6).Value = aEntidad.MESESCOBERTURA
        args(7) = New SqlParameter("@MESESADMINCPM", SqlDbType.Int)
        args(7).Value = aEntidad.MESESADMINCPM
        args(8) = New SqlParameter("@MESESSEGURIDADCPM", SqlDbType.Int)
        args(8).Value = aEntidad.MESESSEGURIDADCPM
        args(9) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(9).Value = aEntidad.AUUSUARIOMODIFICACION
        args(10) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(10).Value = aEntidad.AUFECHAMODIFICACION
        args(11) = New SqlParameter("@FECHACORTE", SqlDbType.DateTime)
        args(11).Value = aEntidad.FECHACORTE

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function agregarDistribucion(ByVal aEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO ")
        strSQL.Append("  SAB_EST_DISTRIBUCION(")
        strSQL.Append("  IDDISTRIBUCION, IDESTABLECIMIENTO, IDSUMINISTRO, FECHADISTRIBUCION, FECHACORTE, ")
        strSQL.Append("  IDALMACEN, DESCRIPCION, MESESCPM, MESESDISTRIBUCION, MESESADMINISTRACION, MESESSEGURIDAD, ESTADO, ")
        strSQL.Append("  AUUSUARIOCREACION, AUFECHACREACION,IDPROGRAMA ")
        strSQL.Append("  ) ")
        strSQL.Append("  VALUES(")
        strSQL.Append("  @IDDISTRIBUCION, @IDESTABLECIMIENTO, @IDSUMINISTRO, @FECHADISTRIBUCION, @FECHACORTE, ")
        strSQL.Append("  @IDALMACEN, @DESCRIPCION, @MESESCPM, @MESESCOBERTURA, @MESESADMINCPM, @MESESSEGURIDADCPM, 0, ")
        strSQL.Append("  @AUUSUARIOCREACION, @AUFECHACREACION,@IDPROGRAMA ")
        strSQL.Append("  ) ")

        Dim args(13) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(2).Value = aEntidad.IDSUMINISTRO
        args(3) = New SqlParameter("@FECHADISTRIBUCION", SqlDbType.DateTime)
        args(3).Value = aEntidad.FECHADISTRIBUCION
        args(4) = New SqlParameter("@FECHACORTE", SqlDbType.DateTime)
        args(4).Value = aEntidad.FECHACORTE
        args(5) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(5).Value = aEntidad.IDALMACEN
        args(6) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(6).Value = aEntidad.DESCRIPCION
        args(7) = New SqlParameter("@MESESCPM", SqlDbType.Int)
        args(7).Value = aEntidad.MESESCPM
        args(8) = New SqlParameter("@MESESCOBERTURA", SqlDbType.Int)
        args(8).Value = aEntidad.MESESCOBERTURA
        args(9) = New SqlParameter("@MESESADMINCPM", SqlDbType.Int)
        args(9).Value = aEntidad.MESESADMINCPM
        args(10) = New SqlParameter("@MESESSEGURIDADCPM", SqlDbType.Int)
        args(10).Value = aEntidad.MESESSEGURIDADCPM
        args(11) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(11).Value = aEntidad.AUUSUARIOCREACION
        args(12) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(12).Value = aEntidad.AUFECHACREACION
        args(13) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(13).Value = aEntidad.IDPROGRAMA

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)
    End Function

#Region "AGREGAR PRODUCTOS Y LOTES A DISTRIBUCION POR LISTA DE PRODUCTOS SELECCIONADOS"
    'Agrega los productos dependiendo si existe en la lista
    'Parametros aEntidad: Distribucion, Tran: Transaccion, Lista: ids de productos
    Public Function agregarDistribucionListaProductos(ByVal aEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction, ByVal lista As List(Of Integer)) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO SAB_EST_DISTRIBUCIONPRODUCTO ")
        strSQL.Append("   (IDDISTRIBUCION, IDESTABLECIMIENTO, IDPRODUCTO, AUUSUARIOCREACION, AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION) ")
        strSQL.Append(" VALUES  ")

        Dim cad As New System.Text.StringBuilder()
        For Each idprod As Integer In lista
            cad.Append(" (@IDDISTRIBUCION, @IDESTABLECIMIENTO, " + idprod.ToString() + ", @AUUSUARIOCREACION,  @AUFECHACREACION, NULL, NULL ),")
        Next
        Dim cadm As String = cad.ToString().Remove(cad.Length - 1)

        strSQL.Append(cadm)

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(2).Value = aEntidad.AUUSUARIOCREACION
        args(3) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(3).Value = aEntidad.AUFECHACREACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    'Agrega los lotes dependiendo si existe en la lista
    'Parametros aEntidad: Distribucion, Tran: Transaccion, Lista: ids de productos
    Public Function agregarDistribucionListaProductosLote(ByVal aEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction, ByVal Lista As List(Of Integer)) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append(" INSERT INTO SAB_EST_DISTRIBUCIONPRODUCTOLOTE ")
        strSQL.Append("   SELECT ")
        strSQL.Append("     DP.IDDISTRIBUCION, DP.IDESTABLECIMIENTO, DP.IDPRODUCTO, L.IDALMACEN, L.IDLOTE, ")
        strSQL.Append("     @AUUSUARIOCREACION, @AUFECHACREACION, NULL, NULL ")
        strSQL.Append("   FROM ")
        strSQL.Append("     SAB_EST_DISTRIBUCIONPRODUCTO DP ")
        strSQL.Append("       INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("         ON DP.IDPRODUCTO = L.IDPRODUCTO ")
        strSQL.Append("         AND L.CANTIDADDISPONIBLE > 0 ")
        strSQL.Append("   WHERE ")
        strSQL.Append("     DP.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("     DP.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("     L.IDALMACEN = @IDALMACEN ")
        strSQL.Append("     AND ( ")

        Dim cad As New System.Text.StringBuilder()
        For Each idprod As Integer In Lista
            cad.Append(" L.IDPRODUCTO = " + idprod.ToString() + " OR")
        Next

        Dim cadm As String = cad.ToString().Remove(cad.Length - 2)
        strSQL.Append(cadm)

        strSQL.Append("     ) ")
        'Dim cadm As String = cad.ToString().Remove(cad.Length - 1)
        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = aEntidad.IDALMACEN
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Value = aEntidad.AUUSUARIOCREACION
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Value = aEntidad.AUFECHACREACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
#End Region


#Region "AGREGAR DISTRIBUCION POR ID DE LISTA"
    'Agrega los productos dependiendo si existe el valor de la lista, si lista = 0 se agregan todos los productos
    'Parametros aEntidad: Distribucion, Tran: Transaccion, IdLista: id de la lista de productos = 0
    Public Function agregarDistribucionIdListaProducto(ByVal aEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction, ByVal idLista As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO SAB_EST_DISTRIBUCIONPRODUCTO ")
        strSQL.Append("   SELECT ")
        strSQL.Append("     @IDDISTRIBUCION, @IDESTABLECIMIENTO, EA.IDPRODUCTO, @AUUSUARIOCREACION, @AUFECHACREACION, NULL, NULL ")
        strSQL.Append("   FROM ")
        strSQL.Append("   SAB_UACI_GRUPOREQTEC_PRODUCTOS LP ")
        strSQL.Append("     INNER JOIN VV_EXISTENCIASALMACENES EA ON ")
        strSQL.Append("         LP.IDPRODUCTO = EA.IDPRODUCTO ")
        strSQL.Append("         INNER JOIN VV_CATALOGOPRODUCTOS CP ON ")
        strSQL.Append("             EA.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("   WHERE ")
        strSQL.Append("     EA.IDALMACEN = @IDALMACEN AND ")
        strSQL.Append("     CP.IDSUMINISTRO = @IDSUMINISTRO ")

        'Evaluando el valor de lista en SQL
        If idLista > 0 Then
            strSQL.Append(" AND   LP.IDGRUPOREQ = @IDLISTA ")
        End If

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = aEntidad.IDALMACEN
        args(3) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(3).Value = aEntidad.IDSUMINISTRO
        args(4) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(4).Value = aEntidad.AUUSUARIOCREACION
        args(5) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(5).Value = aEntidad.AUFECHACREACION
        args(6) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(6).Value = idLista

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    'Agrega los lotes dependiendo si existe el valor de la lista, si lista = 0 se agregan todos los lotes
    'Parametros aEntidad: Distribucion, Tran: Transaccion, IdLista: id de la lista de productos = 0
    Public Function agregarDistribucionIdListaProductoLote(ByVal aEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction, ByVal IdLista As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO SAB_EST_DISTRIBUCIONPRODUCTOLOTE ")
        strSQL.Append("   SELECT ")
        strSQL.Append("     DP.IDDISTRIBUCION, DP.IDESTABLECIMIENTO, DP.IDPRODUCTO, L.IDALMACEN, L.IDLOTE, ")
        strSQL.Append("     @AUUSUARIOCREACION, @AUFECHACREACION, NULL, NULL ")
        strSQL.Append("   FROM ")
        strSQL.Append("     SAB_UACI_GRUPOREQTEC_PRODUCTOS LP ")
        strSQL.Append("    inner join  SAB_EST_DISTRIBUCIONPRODUCTO DP on LP.IDPRODUCTO = DP.IDPRODUCTO")
        strSQL.Append("       INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("         ON DP.IDPRODUCTO = L.IDPRODUCTO ")
        strSQL.Append("   WHERE ")

        If IdLista > 0 Then
            strSQL.Append(" LP.IDGRUPOREQ = @IDLISTA AND ")
        End If

        strSQL.Append("     DP.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("     DP.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("     L.IDALMACEN = @IDALMACEN ")


        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = aEntidad.IDALMACEN
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Value = aEntidad.AUUSUARIOCREACION
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Value = aEntidad.AUFECHACREACION
        args(5) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(5).Value = IdLista

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
#End Region

    Public Function agregarDistribucionProducto(ByVal aEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO SAB_EST_DISTRIBUCIONPRODUCTO ")
        strSQL.Append("   SELECT ")
        strSQL.Append("     @IDDISTRIBUCION, @IDESTABLECIMIENTO, EA.IDPRODUCTO, @AUUSUARIOCREACION, @AUFECHACREACION, NULL, NULL ")
        strSQL.Append("   FROM ")
        strSQL.Append("     DBO.VV_EXISTENCIASALMACENES EA ")
        strSQL.Append("       INNER JOIN VV_CATALOGOPRODUCTOS CP ON ")
        strSQL.Append("         EA.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("   WHERE ")
        strSQL.Append("     EA.IDALMACEN = @IDALMACEN AND ")
        strSQL.Append("     CP.IDSUMINISTRO = @IDSUMINISTRO ")



        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = aEntidad.IDALMACEN
        args(3) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(3).Value = aEntidad.IDSUMINISTRO
        args(4) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(4).Value = aEntidad.AUUSUARIOCREACION
        args(5) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(5).Value = aEntidad.AUFECHACREACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function agregarDistribucionProductoLote(ByVal aEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction, Optional ByVal IDPRODUCTO As Integer = 0) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO SAB_EST_DISTRIBUCIONPRODUCTOLOTE ")
        strSQL.Append("   SELECT ")
        strSQL.Append("     DP.IDDISTRIBUCION, DP.IDESTABLECIMIENTO, DP.IDPRODUCTO, L.IDALMACEN, L.IDLOTE, ")
        strSQL.Append("     @AUUSUARIOCREACION, @AUFECHACREACION, NULL, NULL ")
        strSQL.Append("   FROM ")
        strSQL.Append("     SAB_EST_DISTRIBUCIONPRODUCTO DP ")
        strSQL.Append("       INNER JOIN SAB_ALM_LOTES L ")
        strSQL.Append("         ON DP.IDPRODUCTO = L.IDPRODUCTO ")
        strSQL.Append("   WHERE ")
        strSQL.Append("     DP.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("     DP.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("     L.IDALMACEN = @IDALMACEN ")

        If IDPRODUCTO > 0 Then
            strSQL.Append(" AND L.IDPRODUCTO = @IDPRODUCTO ")
        End If

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = aEntidad.IDALMACEN
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Value = aEntidad.AUUSUARIOCREACION
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Value = aEntidad.AUFECHACREACION
        args(5) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(5).Value = IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function



    Public Function obtenerDistribucionPorID(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DISTRIBUCION

        Dim lEntidad As New DISTRIBUCION

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDDISTRIBUCION = @IDDISTRIBUCION AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dr.Read Then

            lEntidad.IDESTABLECIMIENTO = dr.Item("IDESTABLECIMIENTO")
            lEntidad.FECHADISTRIBUCION = dr.Item("FECHADISTRIBUCION")
            lEntidad.FECHACORTE = dr.Item("FECHACORTE")
            lEntidad.IDDISTRIBUCION = dr.Item("IDDISTRIBUCION")
            lEntidad.DESCRIPCION = dr.Item("DESCRIPCION")
            lEntidad.MESESCPM = dr.Item("MESESCPM")
            lEntidad.MESESSEGURIDADCPM = dr.Item("MESESSEGURIDAD")
            lEntidad.MESESADMINCPM = dr.Item("MESESADMINISTRACION")
            lEntidad.IDALMACEN = dr.Item("IDALMACEN")
            lEntidad.IDSUMINISTRO = dr.Item("IDSUMINISTRO")
            lEntidad.MESESCOBERTURA = dr.Item("MESESDISTRIBUCION")
            lEntidad.NOMBREALMACEN = dr.Item("ALMACEN")
            lEntidad.ESTADO = dr.Item("ESTADO")
            lEntidad.SUMINISTRO = dr.Item("SUMINISTRO")
            lEntidad.IDPROGRAMA = IIf(IsDBNull(dr.Item("IDPROGRAMA")), 0, dr.Item("IDPROGRAMA"))
        Else
            lEntidad = Nothing
        End If

        dr.Close()

        Return lEntidad

    End Function

    Public Function obtenerDistribucionesPorEstado(ByVal Estado As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDDISTRIBUCION, DESCRIPCION FROM SAB_EST_DISTRIBUCION ")
        strSQL.Append(" WHERE ESTADO = @ESTADO ")
        strSQL.Append(" ORDER BY IDDISTRIBUCION DESC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(0).Value = Estado

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerDsDistribucion(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE ")
        strSQL.Append("   IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("   IDDISTRIBUCION DESC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Private Sub selectUnidadesSalud(ByRef strSQL As StringBuilder)
        strSQL.Append("     inner join sce.dbo.vv_EstablecimientoRegion er on ")
        strSQL.Append("       e.codigoEstablecimiento = er.codigoEstablecimiento ")
        strSQL.Append(" where ")
        strSQL.Append("   er.idEstablecimientoAbas = @IDESTABLECIMIENTO ")
    End Sub

    Private Sub selectHospitalesRegiones(ByRef strSQL As StringBuilder)
        strSQL.Append(" where ")
        strSQL.Append("   e.idTipoEstablecimiento in (3, 8, 10) and ")
        strSQL.Append("   e.idEstablecimiento not in (506, 656) ")
    End Sub

    Public Function agregarDistribucionEstablecimiento(ByVal aEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" insert into SAB_EST_DISTRIBUCIONESTABLECIMIENTO ")
        strSQL.Append(" select ")
        strSQL.Append("   @IDDISTRIBUCION, @IDESTABLECIMIENTO, e.idEstablecimiento, @USUARIO, @FECHA, null, null ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_cat_establecimientos e ")

        If aEntidad.IDTIPOESTABLECIMIENTO = 10 Then
            selectUnidadesSalud(strSQL)
        Else
            selectHospitalesRegiones(strSQL)
        End If

        Dim args(3) As SqlParameter

        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = aEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = aEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(2).Value = aEntidad.AUUSUARIOCREACION
        args(3) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(3).Value = aEntidad.AUFECHACREACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerEstablecimientosDistribucion(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   e.idEstablecimiento, e.nombre, de.idDistribucion ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.SAB_EST_DISTRIBUCIONESTABLECIMIENTO de ")
        strSQL.Append("     inner join SAB_CAT_ESTABLECIMIENTOS e on ")
        strSQL.Append("       de.idEstablecimientoDistribucion = e.idEstablecimiento ")
        strSQL.Append(" where ")
        strSQL.Append("   de.idDistribucion = @IDDISTRIBUCION and ")
        strSQL.Append("   de.idEstablecimiento = @IDESTABLECIMIENTO ")
        strSQL.Append(" order by ")
        strSQL.Append("   e.nombre asc ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function eliminarDistribucionEstablecimiento(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDESTABLECIMIENTODISTRIBUCION As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM ")
        strSQL.Append("  SAB_EST_DISTRIBUCIONESTABLECIMIENTO ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDDISTRIBUCION = @IDDISTRIBUCION AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDESTABLECIMIENTODISTRIBUCION = @IDESTABLECIMIENTODISTRIBUCION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTODISTRIBUCION", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTODISTRIBUCION

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerEstablecimientosFueraDistribucion(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   e.idEstablecimiento, e.nombre ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_cat_establecimientos e ")

        If IDTIPOESTABLECIMIENTO = 10 Then
            selectUnidadesSalud(strSQL)
        Else
            selectHospitalesRegiones(strSQL)
        End If

        strSQL.Append(" and e.idEstablecimiento ")
        strSQL.Append(" not in (")
        strSQL.Append(" select idEstablecimientoDistribucion ")
        strSQL.Append(" from SAB_EST_DISTRIBUCIONESTABLECIMIENTO ")
        strSQL.Append(" where IDDISTRIBUCION = @IDDISTRIBUCION and ")
        strSQL.Append(" IDESTABLECIMIENTO = @IDESTABLECIMIENTO ) ")

        Dim args(3) As SqlParameter

        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function agregarDistribucionEstablecimientos(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDESTABLECIMIENTODISTRIBUCION As Integer, ByVal USUARIO As String) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_DISTRIBUCIONESTABLECIMIENTO(IDDISTRIBUCION, IDESTABLECIMIENTO, IDESTABLECIMIENTODISTRIBUCION, AUUSUARIOCREACION, AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION) ")
        strSQL.Append("  VALUES(@IDDISTRIBUCION, @IDESTABLECIMIENTO, @IDESTABLECIMIENTODISTRIBUCION, @USUARIO, @FECHA, NULL, NULL) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDESTABLECIMIENTODISTRIBUCION", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTODISTRIBUCION
        args(3) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(3).Value = USUARIO
        args(4) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(4).Value = Now


        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function actualizarEstadoDistribucion(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal ESTADO As Integer, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE SAB_EST_DISTRIBUCION ")
        strSQL.Append(" SET ESTADO = @ESTADO, AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("   IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(2).Value = ESTADO
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = USUARIO
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerRptDistribucionEstablecimiento(ByVal FECHAINICIO As String, ByVal FECHAFIN As String, Optional ByVal IDDISTRIBUCION As Integer = 0, Optional ByVal IDESTABLECIMIENTO As Integer = 0, Optional ByVal IDPRODUCTO As Integer = 0, Optional ByVal DISTRIBUYE As Boolean = False) As DataSet
        'CONSULTA
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT DISTINCT D.IDDISTRIBUCION, DD.IDESTABLECIMIENTO , D.DESCRIPCION, ")
        strSQL.Append(" CONVERT(VARCHAR, MONTH(D.FECHADISTRIBUCION)) + '/' + CONVERT(VARCHAR, YEAR(D.FECHADISTRIBUCION)) PERIODO, ")
        strSQL.Append(" S.DESCRIPCION SUMINISTRO, E.NOMBRE ESTABLECIMIENTO,  ED.NOMBRE AS ESTABLECIMIENTODISTRIBUCION,")
        strSQL.Append(" DD.CANTIDADREAL CANTIDAD, (DD.CANTIDADREAL * AL.PRECIOLOTE) MONTO, DD.IDPRODUCTO, VVC.CORRPRODUCTO, ")
        strSQL.Append(" VVC.DESCLARGO DESCPRODUCTO, VVC.UNIDADMEDIDA MEDIDAPRODUCTO ")
        strSQL.Append(" FROM SAB_EST_DISTRIBUCION AS D  ")

        strSQL.Append(" INNER JOIN	SAB_EST_DISTRIBUCIONPRODUCTOLOTE DDL ON D.IDDISTRIBUCION = DDL.IDDISTRIBUCION   ")
        strSQL.Append(" INNER JOIN	SAB_ALM_LOTES AS AL ON DDL.IDLOTE = AL.IDLOTE AND DDL.IDPRODUCTO = AL.IDPRODUCTO AND AL.CANTIDADDISPONIBLE > 0 ")
        strSQL.Append(" INNER JOIN SAB_EST_DISTRIBUCIONESTABLECIMIENTO DE ON D.IDDISTRIBUCION = DE.IDDISTRIBUCION AND D.IDESTABLECIMIENTO = DE.IDESTABLECIMIENTO  ")
        strSQL.Append(" INNER JOIN SAB_CAT_ESTABLECIMIENTOS ED ON DE.IDESTABLECIMIENTODISTRIBUCION = ED.IDESTABLECIMIENTO  ")
        strSQL.Append(" INNER JOIN	SAB_EST_DISTRIBUCIONDETALLE DD ON D.IDDISTRIBUCION = DD.IDDISTRIBUCION AND DDL.IDPRODUCTO = DD.IDPRODUCTO AND DD.CANTIDADREAL > 0 AND DE.IDESTABLECIMIENTODISTRIBUCION = DD.IDESTABLECIMIENTODISTRIBUCION AND DE.IDESTABLECIMIENTO = DD.IDESTABLECIMIENTO ")
        strSQL.Append(" INNER JOIN	SAB_CAT_ESTABLECIMIENTOS E ON D.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append(" INNER JOIN	vv_CATALOGOPRODUCTOS VVC ON DD.IDPRODUCTO = VVC.IDPRODUCTO ")
        strSQL.Append(" INNER JOIN	SAB_CAT_SUMINISTROS S ON D.IDSUMINISTRO = S.IDSUMINISTRO ")

        'strSQL.Append(" INNER JOIN SAB_EST_DISTRIBUCIONESTABLECIMIENTO DE ON D.IDDISTRIBUCION = DE.IDDISTRIBUCION AND D.IDESTABLECIMIENTO = DE.IDESTABLECIMIENTO  ")
        'strSQL.Append(" INNER JOIN SAB_CAT_ESTABLECIMIENTOS ED ON DE.IDESTABLECIMIENTODISTRIBUCION = ED.IDESTABLECIMIENTO  ")
        'strSQL.Append(" INNER JOIN SAB_EST_DISTRIBUCIONPRODUCTO DP ON D.IDDISTRIBUCION = DP.IDDISTRIBUCION AND D.IDESTABLECIMIENTO = DP.IDESTABLECIMIENTO ")
        'strSQL.Append(" INNER JOIN	SAB_EST_DISTRIBUCIONDETALLE DD ON D.IDDISTRIBUCION = DD.IDDISTRIBUCION AND DP.IDPRODUCTO = DD.IDPRODUCTO AND DP.IDESTABLECIMIENTO = DD.IDESTABLECIMIENTO ")
        'strSQL.Append(" INNER JOIN	SAB_EST_DISTRIBUCIONPRODUCTOLOTE DDL ON D.IDDISTRIBUCION = DDL.IDDISTRIBUCION AND DP.IDPRODUCTO = DDL.IDPRODUCTO AND DP.IDESTABLECIMIENTO = DDL.IDESTABLECIMIENTO  ")
        'strSQL.Append(" INNER JOIN	SAB_ALM_LOTES AS AL ON DDL.IDLOTE = AL.IDLOTE AND DDL.IDALMACEN = AL.IDALMACEN AND DDL.IDPRODUCTO = AL.IDPRODUCTO AND AL.CANTIDADDISPONIBLE > 0  ")
        'strSQL.Append(" INNER JOIN	vv_CATALOGOPRODUCTOS VVC ON DD.IDPRODUCTO = VVC.IDPRODUCTO  ")
        'strSQL.Append(" INNER JOIN	SAB_CAT_SUMINISTROS S ON D.IDSUMINISTRO = S.IDSUMINISTRO  ")
        'strSQL.Append(" INNER JOIN	SAB_CAT_ESTABLECIMIENTOS E ON D.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO  ")



        strSQL.Append(" WHERE D.FECHADISTRIBUCION BETWEEN @FECHAINI AND @FECHAFIN ")

        'FILTROS
        If IDDISTRIBUCION > 0 Then
            strSQL.Append(" AND D.IDDISTRIBUCION = @IDDISTRIBUCION ")
        End If

        If IDESTABLECIMIENTO > 0 Then
            If DISTRIBUYE Then
                strSQL.Append(" AND DD.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
            Else
                strSQL.Append(" AND ED.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
            End If
        End If

        If IDPRODUCTO > 0 Then
            strSQL.Append(" AND DD.IDPRODUCTO = @IDPRODUCTO ")
        End If

        'PARAMETROS
        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO
        args(3) = New SqlParameter("@FECHAINI", SqlDbType.DateTime)
        args(3).Value = DateTime.ParseExact(FECHAINICIO, "dd/MM/yyyy", Nothing)
        args(4) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(4).Value = DateTime.ParseExact(FECHAFIN, "dd/MM/yyyy", Nothing)

        Using conn As New SqlConnection(Me._cnnStr)
            Dim cmd As SqlCommand = New SqlCommand(strSQL.ToString(), conn)
            cmd.CommandTimeout = 160

            'AGREGA PARAMETROS AL COMMAND
            cmd.Parameters.AddRange(args)

            'ABRE LA CONEXION 
            conn.Open()

            'EJECUTA Y CAPTURA EL READER QUE LLENA EL DATASET A RETORNAR
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
    End Function


    Public Function obtenerRptDistribucion(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal ORDEN As Integer, Optional ByVal IDPRODUCTO As Integer = 0, Optional ByVal IDESTABLECIMIENTODISTRIBUCION As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append("  SELECT ")
        strSQL.Append("    (CONVERT(VARCHAR, MONTH(D.FECHADISTRIBUCION)) + '/' + CONVERT(VARCHAR, YEAR(D.FECHADISTRIBUCION))) AS PERIODO, ")
        strSQL.Append("     D.DESCRIPCION, A.NOMBRE AS ALMACEN, S.DESCRIPCION AS SUMINISTRO, ")
        strSQL.Append("     D.IDDISTRIBUCION, E.NOMBRE AS ESTABLECIMIENTO, E1.NOMBRE AS ESTABLECIMIENTODISTRIBUCION, ")
        strSQL.Append("     CP.CORRPRODUCTO AS CODPRODUCTO, CP.DESCLARGO AS NOMPRODUCTO, ")
        strSQL.Append("     CP.DESCRIPCION AS UM, DD.CANTIDADREAL AS CANTIDAD ")
        strSQL.Append("     , L.IDLOTE , L.CODIGO, L.FECHAVENCIMIENTO as FECHAFENCIMIENTO, FF.NOMBRE ")
        strSQL.Append("  FROM ")
        strSQL.Append("    SAB_EST_DISTRIBUCION D ")
       
        strSQL.Append("      INNER JOIN SAB_EST_DISTRIBUCIONESTABLECIMIENTO DE ON ")
        strSQL.Append("        D.IDDISTRIBUCION = DE.IDDISTRIBUCION AND ")
        strSQL.Append("        D.IDESTABLECIMIENTO = DE.IDESTABLECIMIENTO ")
      
        strSQL.Append("      INNER JOIN SAB_EST_DISTRIBUCIONDETALLE DD ON ")
        strSQL.Append("        DE.IDDISTRIBUCION = DD.IDDISTRIBUCION AND ")
        strSQL.Append("        DE.IDESTABLECIMIENTO = DD.IDESTABLECIMIENTO AND ")
        strSQL.Append("        DE.IDESTABLECIMIENTODISTRIBUCION = DD.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append("        INNER JOIN SAB_EST_DISTRIBUCIONPRODUCTOLOTE DPL ON ")
        strSQL.Append("        DPL.IDDISTRIBUCION=D.IDDISTRIBUCION AND DPL.IDESTABLECIMIENTO=D.IDESTABLECIMIENTO AND DPL.IDPRODUCTO=DD.IDPRODUCTO AND DPL.IDALMACEN=D.IDALMACEN ")
        
       strSQL.Append("        INNER JOIN SAB_ALM_LOTES L ON  ")
        strSQL.Append("        L.IDALMACEN=DPL.IDALMACEN AND ")
        strSQL.Append("        L.IDLOTE=DPL.IDLOTE ")

        strSQL.Append("      INNER JOIN VV_CATALOGOPRODUCTOS CP ON ")
        strSQL.Append("        DD.IDPRODUCTO = CP.IDPRODUCTO ")


        strSQL.Append("      INNER JOIN SAB_CAT_ALMACENES A ON ")
        strSQL.Append("        D.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("      INNER JOIN SAB_CAT_SUMINISTROS S ON ")
        strSQL.Append("        D.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("        INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ON ")
        strSQL.Append("        FF.IDFUENTEFINANCIAMIENTO=L.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("      INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ON ")
        strSQL.Append("        D.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("      INNER JOIN SAB_CAT_ESTABLECIMIENTOS E1 ON ")
        strSQL.Append("        DE.IDESTABLECIMIENTODISTRIBUCION = E1.IDESTABLECIMIENTO ")
        
        strSQL.Append("  WHERE ")
        strSQL.Append("    D.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("    D.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("    DD.CANTIDADREAL > 0 AND ")
        strSQL.Append("    (DE.IDESTABLECIMIENTODISTRIBUCION = @IDESTABLECIMIENTODISTRIBUCION OR @IDESTABLECIMIENTODISTRIBUCION = 0) AND ")
        strSQL.Append("    (DD.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) ")
        strSQL.Append("  ORDER BY ")

        If ORDEN = 0 Then
            strSQL.Append("    E1.NOMBRE ")
        Else
            strSQL.Append("    CP.DESCLARGO ")
        End If

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO
        args(3) = New SqlParameter("@IDESTABLECIMIENTODISTRIBUCION", SqlDbType.Int)
        args(3).Value = IDESTABLECIMIENTODISTRIBUCION

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function obtenerRptDistribucion22(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal ORDEN As Integer, ByRef ds As DataSet, Optional ByVal IDPRODUCTO As Integer = 0, Optional ByVal IDESTABLECIMIENTODISTRIBUCION As Integer = 0) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("  SELECT ")
        strSQL.Append("    (CONVERT(VARCHAR, MONTH(D.FECHADISTRIBUCION)) + '/' + CONVERT(VARCHAR, YEAR(D.FECHADISTRIBUCION))) AS PERIODO, ")
        strSQL.Append("     D.DESCRIPCION, A.NOMBRE AS ALMACEN, S.DESCRIPCION AS SUMINISTRO, ")
        strSQL.Append("     D.IDDISTRIBUCION, E.NOMBRE AS ESTABLECIMIENTO, E1.NOMBRE AS ESTABLECIMIENTODISTRIBUCION, ")
        strSQL.Append("     CP.CORRPRODUCTO AS CODPRODUCTO, CP.DESCLARGO AS NOMPRODUCTO, ")
        strSQL.Append("     CP.DESCRIPCION AS UM, DD.CANTIDADREAL AS CANTIDAD, cp.idproducto ")
        ''strSQL.Append("     , L.IDLOTE , L.CODIGO, L.FECHAVENCIMIENTO as FECHAFENCIMIENTO, FF.NOMBRE ")
        strSQL.Append("  FROM ")
        strSQL.Append("    SAB_EST_DISTRIBUCION D ")
        strSQL.Append("      INNER JOIN SAB_CAT_ALMACENES A ON ")
        strSQL.Append("        D.IDALMACEN = A.IDALMACEN ")
        strSQL.Append("      INNER JOIN SAB_CAT_SUMINISTROS S ON ")
        strSQL.Append("        D.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("      INNER JOIN SAB_EST_DISTRIBUCIONESTABLECIMIENTO DE ON ")
        strSQL.Append("        D.IDDISTRIBUCION = DE.IDDISTRIBUCION AND ")
        strSQL.Append("        D.IDESTABLECIMIENTO = DE.IDESTABLECIMIENTO ")
        strSQL.Append("      INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ON ")
        strSQL.Append("        D.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("      INNER JOIN SAB_CAT_ESTABLECIMIENTOS E1 ON ")
        strSQL.Append("        DE.IDESTABLECIMIENTODISTRIBUCION = E1.IDESTABLECIMIENTO ")
        strSQL.Append("      INNER JOIN SAB_EST_DISTRIBUCIONDETALLE DD ON ")
        strSQL.Append("        DE.IDDISTRIBUCION = DD.IDDISTRIBUCION AND ")
        strSQL.Append("        DE.IDESTABLECIMIENTO = DD.IDESTABLECIMIENTO AND ")
        strSQL.Append("        DE.IDESTABLECIMIENTODISTRIBUCION = DD.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append("      INNER JOIN VV_CATALOGOPRODUCTOS CP ON ")
        strSQL.Append("        DD.IDPRODUCTO = CP.IDPRODUCTO ")
        'If IDESTABLECIMIENTO = 620 Then
        '    strSQL.Append("                      INNER JOIN SAB_EST_DISTRIBUCIONESCERRRADASLOTES DCL ON ")
        '    strSQL.Append("        DCL.IDDISTRIBUCION=D.IDDISTRIBUCION AND ")
        '    strSQL.Append("        DCL.IDESTABLECIMIENTO=D.IDESTABLECIMIENTO AND ")
        '    strSQL.Append("        DCL.IDPRODUCTO=DD.IDPRODUCTO ")

        'Else
        '    strSQL.Append("                      INNER JOIN SAB_EST_DISTRIBUCIONPRODUCTOLOTE DCL ON ")
        '    strSQL.Append("        DCL.IDDISTRIBUCION=D.IDDISTRIBUCION AND ")
        '    strSQL.Append("        DCL.IDESTABLECIMIENTO=D.IDESTABLECIMIENTO AND ")
        '    strSQL.Append("        DCL.IDPRODUCTO=DD.IDPRODUCTO ")
        'End If
        strSQL.Append("        INNER JOIN SAB_EST_DISTRIBUCIONPRODUCTOLOTE DPL ON ")
        strSQL.Append("        DPL.IDDISTRIBUCION=D.IDDISTRIBUCION AND DPL.IDESTABLECIMIENTO=D.IDESTABLECIMIENTO AND DPL.IDPRODUCTO=DD.IDPRODUCTO AND DPL.IDALMACEN=D.IDALMACEN ")

        'strSQL.Append("        INNER JOIN SAB_ALM_LOTES L ON  ")
        'strSQL.Append("        L.IDALMACEN=DPL.IDALMACEN AND ")
        'strSQL.Append("        L.IDLOTE=DPL.IDLOTE ")

        'strSQL.Append("        INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ON ")
        'strSQL.Append("        FF.IDFUENTEFINANCIAMIENTO=L.IDFUENTEFINANCIAMIENTO ")


        strSQL.Append("  WHERE ")
        strSQL.Append("    D.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("    D.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("    DD.CANTIDADREAL > 0 AND ")
        strSQL.Append("    (DE.IDESTABLECIMIENTODISTRIBUCION = @IDESTABLECIMIENTODISTRIBUCION OR @IDESTABLECIMIENTODISTRIBUCION = 0) AND ")
        strSQL.Append("    (DD.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) ")
        strSQL.Append("  ORDER BY ")

        If ORDEN = 0 Then
            strSQL.Append("    E1.NOMBRE ")
        Else
            strSQL.Append("    CP.DESCLARGO ")
        End If

        '---------------------------------------------------------------------------------
        strSQL.Append("  select L.IDLOTE , L.CODIGO, L.FECHAVENCIMIENTO as FECHAFENCIMIENTO, FF.NOMBRE , dpl.IDPRODUCTO  ")
        strSQL.Append("  from  ")
        strSQL.Append("  SAB_EST_DISTRIBUCION D  ")
        strSQL.Append("  INNER JOIN SAB_EST_DISTRIBUCIONPRODUCTOLOTE DPL ON      ")
        strSQL.Append("  DPL.IDDISTRIBUCION=D.IDDISTRIBUCION AND  ")
        strSQL.Append("                              DPL.IDESTABLECIMIENTO=D.IDESTABLECIMIENTO AND  ")
        strSQL.Append("                                                DPL.IDALMACEN=D.IDALMACEN    ")
        strSQL.Append("    inner join SAB_ALM_LOTES L ON          ")
        strSQL.Append("  L.IDALMACEN=DPL.IDALMACEN AND         ")
        strSQL.Append("  L.IDLOTE=DPL.IDLOTE         ")
        strSQL.Append("                                                    ")
        strSQL.Append("  INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ON      ")
        strSQL.Append("  FF.IDFUENTEFINANCIAMIENTO=L.IDFUENTEFINANCIAMIENTO      ")
        strSQL.Append("   ")
        strSQL.Append("  where              D.IDDISTRIBUCION = @IDDISTRIBUCION AND   D.IDESTABLECIMIENTO = @IDESTABLECIMIENTO  ")


        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO
        args(3) = New SqlParameter("@IDESTABLECIMIENTODISTRIBUCION", SqlDbType.Int)
        args(3).Value = IDESTABLECIMIENTODISTRIBUCION

        Dim tables(1) As String
        tables(0) = New String("table1")
        tables(1) = New String("table2")


        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function
    Public Function obtenerRptDistribucionFechaEntrega(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append("  SELECT ")
        strSQL.Append("   D.DESCRIPCION, E.NOMBRE, DFE.FECHAENTREGA, isnull(dfe.observacion,'') as observacion ")
  
        strSQL.Append("  FROM SAB_EST_DISTRIBUCION D inner join ")
        strSQL.Append("    SAB_EST_DISTRIBUCIONFECHAENTREGA DFE ON ")
        strSQL.Append("        D.IDESTABLECIMIENTO = DFE.IDESTABLECIMIENTO AND D.IDDISTRIBUCION=DFE.IDDISTRIBUCION ")
        strSQL.Append("      INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ON E.IDESTABLECIMIENTO=DFE.IDESTABLECIMIENTODISTRIBUCION ")
        'strSQL.Append("      INNER JOIN SAB_EST_DISTRIBUCION D ON ")
        'strSQL.Append("        D.IDDISTRIBUCION = @IDDISTRIBUCION AND D.IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")
        ''strSQL.Append("      INNER JOIN SAB_EST_DISTRIBUCIONESTABLECIMIENTO DE ON ")
        'strSQL.Append("        D.IDDISTRIBUCION = DE.IDDISTRIBUCION AND ")
        'strSQL.Append("        D.IDESTABLECIMIENTO = DE.IDESTABLECIMIENTO ")
        'strSQL.Append("      INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ON ")
        'strSQL.Append("        D.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        'strSQL.Append("      INNER JOIN SAB_CAT_ESTABLECIMIENTOS E1 ON ")
        'strSQL.Append("        DE.IDESTABLECIMIENTODISTRIBUCION = E1.IDESTABLECIMIENTO ")
        'strSQL.Append("      INNER JOIN SAB_EST_DISTRIBUCIONDETALLE DD ON ")
        'strSQL.Append("        DE.IDDISTRIBUCION = DD.IDDISTRIBUCION AND ")
        'strSQL.Append("        DE.IDESTABLECIMIENTO = DD.IDESTABLECIMIENTO AND ")
        'strSQL.Append("        DE.IDESTABLECIMIENTODISTRIBUCION = DD.IDESTABLECIMIENTODISTRIBUCION ")
        'strSQL.Append("      INNER JOIN VV_CATALOGOPRODUCTOS CP ON ")
        'strSQL.Append("        DD.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("  WHERE ")
        strSQL.Append("    D.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("    D.IDESTABLECIMIENTO = @IDESTABLECIMIENTO  ")
        'strSQL.Append("    DD.CANTIDADREAL > 0 AND ")
        'strSQL.Append("    (DE.IDESTABLECIMIENTODISTRIBUCION = @IDESTABLECIMIENTODISTRIBUCION OR @IDESTABLECIMIENTODISTRIBUCION = 0) AND ")
        'strSQL.Append("    (DD.IDPRODUCTO = @IDPRODUCTO OR @IDPRODUCTO = 0) ")
        'strSQL.Append("  ORDER BY ")

        'If ORDEN = 0 Then
        '    strSQL.Append("    E1.NOMBRE ")
        'Else
        '    strSQL.Append("    CP.DESCLARGO ")
        'End If

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        'args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        'args(2).Value = IDPRODUCTO
        'args(3) = New SqlParameter("@IDESTABLECIMIENTODISTRIBUCION", SqlDbType.Int)
        'args(3).Value = IDESTABLECIMIENTODISTRIBUCION

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function crearDistribucionRegiones(ByVal eEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction, Optional ByVal PRODUCTO As String = "", Optional ByVal IDPRODUCTO As Integer = 0) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_DistribucionRegion")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = eEntidad.IDDISTRIBUCION
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = eEntidad.IDESTABLECIMIENTO
        args(3) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = eEntidad.IDALMACEN
        args(4) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = DateAdd(DateInterval.Month, (-1) * (eEntidad.MESESCPM - 1), eEntidad.FECHACORTE)
        args(5) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(5).Direction = ParameterDirection.Input
        args(5).Value = eEntidad.FECHACORTE
        args(6) = New SqlParameter("@PRODUCTO", SqlDbType.VarChar)
        args(6).Direction = ParameterDirection.Input
        args(6).Value = PRODUCTO
        args(7) = New SqlParameter("@PERIODO", SqlDbType.Int)
        args(7).Direction = ParameterDirection.Input
        args(7).Value = eEntidad.MESESADMINCPM + eEntidad.MESESCOBERTURA + eEntidad.MESESSEGURIDADCPM
        args(8) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(8).Direction = ParameterDirection.Input
        args(8).Value = eEntidad.AUUSUARIOCREACION
        args(9) = New SqlParameter("@MESESCPM", SqlDbType.VarChar)
        args(9).Direction = ParameterDirection.Input
        args(9).Value = eEntidad.MESESCPM
        args(10) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(10).Direction = ParameterDirection.Input
        args(10).Value = IDPRODUCTO

        SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

    Public Function crearDistribucionHospitales(ByVal eEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction, Optional ByVal PRODUCTO As String = "", Optional ByVal IDPRODUCTO As Integer = 0, Optional ByVal IDREGION As Integer = 0) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_DistribucionHospitales")

        Dim args(11) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = eEntidad.IDDISTRIBUCION
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = eEntidad.IDESTABLECIMIENTO
        args(3) = New SqlParameter("@IDREGION", SqlDbType.Int)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = IDREGION
        args(4) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = eEntidad.IDALMACEN
        args(5) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(5).Direction = ParameterDirection.Input
        args(5).Value = DateAdd(DateInterval.Month, (-1) * (eEntidad.MESESCPM - 1), eEntidad.FECHACORTE)
        args(6) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(6).Direction = ParameterDirection.Input
        args(6).Value = eEntidad.FECHACORTE
        args(7) = New SqlParameter("@PRODUCTO", SqlDbType.VarChar)
        args(7).Direction = ParameterDirection.Input
        args(7).Value = PRODUCTO
        args(8) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(8).Direction = ParameterDirection.Input
        args(8).Value = IDPRODUCTO
        args(9) = New SqlParameter("@PERIODO", SqlDbType.Int)
        args(9).Direction = ParameterDirection.Input
        args(9).Value = eEntidad.MESESADMINCPM + eEntidad.MESESCOBERTURA + eEntidad.MESESSEGURIDADCPM
        args(10) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(10).Direction = ParameterDirection.Input
        args(10).Value = eEntidad.AUUSUARIOCREACION
        args(11) = New SqlParameter("@MESESCPM", SqlDbType.Int)
        args(11).Direction = ParameterDirection.Input
        args(11).Value = eEntidad.MESESCPM

        SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

    Public Function crearDistribucionGenerica(ByVal eEntidad As DISTRIBUCION, ByVal tran As DistributedTransaction, Optional ByVal IDPRODUCTO As Integer = 0) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" insert into dbo.SAB_EST_DISTRIBUCIONDETALLE ")
        strSQL.Append(" 	select ")
        strSQL.Append(" 	  de.idDistribucion, de.idEstablecimiento, de.idEstablecimientoDistribucion, ")
        strSQL.Append(" 	  dp.idProducto, 0, 0, 0, 0, 0, 0, @USUARIO, getDate(), null, null, null ")
        strSQL.Append(" 	from ")
        strSQL.Append(" 	  dbo.SAB_EST_DISTRIBUCIONESTABLECIMIENTO de ")
        strSQL.Append(" 		inner join dbo.SAB_EST_DISTRIBUCIONPRODUCTO dp on ")
        strSQL.Append(" 		  de.idDistribucion = dp.idDistribucion and ")
        strSQL.Append(" 		  de.idEstablecimiento = dp.idEstablecimiento ")
        strSQL.Append(" 	where ")
        strSQL.Append(" 	  de.idDistribucion = @IDDISTRIBUCION and ")
        strSQL.Append(" 	  de.idEstablecimiento = @IDESTABLECIMIENTO and ")
        strSQL.Append(" 	  (dp.idProducto = @IDPRODUCTO or @IDPRODUCTO = 0) ")

        Dim args(3) As SqlParameter

        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = eEntidad.IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(2).Value = eEntidad.AUUSUARIOCREACION
        args(3) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(3).Value = IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function existenciaAlmacen(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT ")
        strSQL.Append("   isnull(SUM(L.CANTIDADDISPONIBLE), 0) ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_EST_DISTRIBUCIONPRODUCTOLOTE DPL ")
        strSQL.Append("     INNER JOIN SAB_ALM_LOTES L ON ")
        strSQL.Append("       DPL.IDALMACEN = L.IDALMACEN AND ")
        strSQL.Append("       DPL.IDPRODUCTO = L.IDPRODUCTO AND ")
        strSQL.Append("       DPL.IDLOTE = L.IDLOTE ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   DPL.IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("   DPL.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("   DPL.IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter

        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO

        Return SqlHelper.ExecuteScalar(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)


    End Function

    Public Function cantidadDistribuir(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT ")
        strSQL.Append("   ISNULL(SUM(CANTIDADREAL), 0) ")
        strSQL.Append(" FROM ")
        strSQL.Append("   DBO.SAB_EST_DISTRIBUCIONDETALLE ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   IDDISTRIBUCION = @IDDISTRIBUCION AND ")
        strSQL.Append("   IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("   IDPRODUCTO = @IDPRODUCTO ")

        Dim args(2) As SqlParameter

        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = IDPRODUCTO

        Return SqlHelper.ExecuteScalar(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function AniosDistribuciones() As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append("    select distinct YEAR(fechadistribucion) as anio from [SAB_EST_DISTRIBUCION] ")
      
        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ListaDistribuciones(anio As Integer, idestablecimiento As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append("  select distinct D.iddistribucion,D.descripcion from SAB_EST_DISTRIBUCION D INNER JOIN SAB_EST_DISTRIBUCIONDETALLE  DD ON D.IDDISTRIBUCION=DD.IDDISTRIBUCION AND D.IDESTABLECIMIENTO=DD.IDESTABLECIMIENTO  INNER JOIN SAB_EST_DISTRIBUCIONESCERRADAS DC ON DC.IDDISTRIBUCION=D.IDDISTRIBUCION AND DC.IDESTABLECIMIENTO=D.IDESTABLECIMIENTO  where DD.IDESTABLECIMIENTODISTRIBUCION=" & idestablecimiento & " and YEAR(D.fechadistribucion)=" & anio)

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ListaDistribucionesCerradas(anio As Integer, idestablecimiento As Integer, Optional g As Integer = 0, Optional IDESTABLECIMIENTODISTRIBUCION As Integer = 0, Optional todosestados As Boolean = False) As DataSet

        Dim strSQL As New StringBuilder

        'strSQL.Append("  select distinct D.iddistribucion,D.descripcion from SAB_EST_DISTRIBUCION D INNER JOIN SAB_EST_DISTRIBUCIONDETALLE  DD ON D.IDDISTRIBUCION=DD.IDDISTRIBUCION AND D.IDESTABLECIMIENTO=DD.IDESTABLECIMIENTO where DD.IDESTABLECIMIENTODISTRIBUCION=" & idestablecimiento & " and YEAR(D.fechadistribucion)=" & anio)
        strSQL.Append(" select distinct D.iddistribucion,   convert(varchar, D.iddistribucion) + ' - ' + D.descripcion as DESCRIPCION ")
        strSQL.Append(" from SAB_EST_DISTRIBUCION D INNER JOIN SAB_EST_DISTRIBUCIONDETALLE  DD  ")
        strSQL.Append(" ON D.IDDISTRIBUCION=DD.IDDISTRIBUCION AND  ")
        strSQL.Append(" D.IDESTABLECIMIENTO=DD.IDESTABLECIMIENTO  ")
        strSQL.Append(" INNER JOIN SAB_EST_DISTRIBUCIONESCERRADAS DC ON ")
        strSQL.Append(" DC.IDDISTRIBUCION=D.IDDISTRIBUCION AND ")
        strSQL.Append(" DC.IDESTABLECIMIENTO=D.IDESTABLECIMIENTO ")

        If g <> 0 Then
            strSQL.Append(" INNER JOIN SAB_EST_DISTRIBUCIONFECHAENTREGA DFE ON ")
            strSQL.Append(" DFE.IDDISTRIBUCION=DC.IDDISTRIBUCION AND ")
            strSQL.Append(" DFE.IDESTABLECIMIENTO=DC.IDESTABLECIMIENTO AND ")
            strSQL.Append(" DFE.FECHAENTREGA<> '19000101' AND ")
            strSQL.Append(" DFE.IDESTABLECIMIENTODISTRIBUCION=" & IDESTABLECIMIENTODISTRIBUCION)
        End If
        If todosestados = True Then
            strSQL.Append("  where D.estado in (2,3,4,5) and DD.IDESTABLECIMIENTO = " & IIf(idestablecimiento = 619, 620, idestablecimiento) & " And Year(D.fechadistribucion) = " & anio)
        Else
            strSQL.Append("  where D.estado in (2,3) and DD.IDESTABLECIMIENTO = " & IIf(idestablecimiento = 619, 620, idestablecimiento) & " And Year(D.fechadistribucion) = " & anio)
        End If


        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    'SCMS
    Public Function agregarDistribucionesCerradas(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO SAB_EST_DISTRIBUCIONESCERRADAS ")
        strSQL.Append(" select d.IDDISTRIBUCION,d.IDESTABLECIMIENTO, d.IDPROGRAMA,de.IDESTABLECIMIENTODISTRIBUCION, ")
        strSQL.Append(" dd.IDPRODUCTO,dd.CANTIDADREAL,0,NULL  ")
        strSQL.Append(" from sab_est_distribucion d inner join sab_est_distribucionestablecimiento de  ")
        strSQL.Append(" on d.iddistribucion=de.iddistribucion and d.idestablecimiento=de.idestablecimiento  ")
        strSQL.Append(" inner join sab_est_distribuciondetalle dd on dd.iddistribucion=de.iddistribucion and  ")
        strSQL.Append(" dd.idestablecimiento=de.idestablecimiento and dd.IDESTABLECIMIENTODISTRIBUCION=de.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append("  ")
        strSQL.Append(" where d.iddistribucion=@IDDISTRIBUCION and d.IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")
        strSQL.Append(" and dd.cantidadreal>0 ")
        strSQL.Append(" order by dd.IDPRODUCTO,de.IDESTABLECIMIENTODISTRIBUCION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
       
        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    'SCMS
    Public Function agregarDistribucionesCerradasFechas(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" insert into SAB_EST_DISTRIBUCIONFECHAENTREGA ")
        strSQL.Append(" select distinct IDDISTRIBUCION,IDESTABLECIMIENTO,IDPROGRAMA,IDESTABLECIMIENTODISTRIBUCION,0,NULL,'' ")
        strSQL.Append(" from SAB_EST_DISTRIBUCIONESCERRADAS ")
        strSQL.Append(" where IDDISTRIBUCION=@IDDISTRIBUCION and IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function agregarDistribucionesCerradaslotes(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append(" INSERT INTO SAB_EST_DISTRIBUCIONESCERRRADASLOTES ")

        strSQL.Append(" select distinct d.IDDISTRIBUCION,d.IDESTABLECIMIENTO, d.IDPROGRAMA, dp.IDPRODUCTO, dpl.IDALMACEN,dpl.IDLOTE ")

        strSQL.Append(" from sab_est_distribucion d inner join sab_est_distribucionproducto dp  ")
        strSQL.Append(" on d.iddistribucion=dp.iddistribucion  ")
        strSQL.Append(" and d.idestablecimiento=dp.idestablecimiento  ")

        strSQL.Append(" inner join sab_est_distribucionproductolote dpl  ")
        strSQL.Append(" on dpl.iddistribucion=dp.iddistribucion and  ")
        strSQL.Append(" dpl.idestablecimiento=dp.idestablecimiento and  ")
        strSQL.Append(" dpl.IDPRODUCTO=dp.IDPRODUCTO ")

        strSQL.Append(" inner join SAB_EST_DISTRIBUCIONESTABLECIMIENTO de  ")
        strSQL.Append(" on de.IDDISTRIBUCION=d.IDDISTRIBUCION and  ")
        strSQL.Append(" de.IDESTABLECIMIENTO=d.IDESTABLECIMIENTO ")

        strSQL.Append(" inner join SAB_EST_DISTRIBUCIONDETALLE dd on  ")
        strSQL.Append(" dd.IDDISTRIBUCION=de.IDDISTRIBUCION ")
        strSQL.Append(" and dd.IDESTABLECIMIENTO=de.IDESTABLECIMIENTO and  ")
        strSQL.Append(" dd.IDESTABLECIMIENTODISTRIBUCION=de.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append(" and dd.IDPRODUCTO=dp.IDPRODUCTO   ")
        strSQL.Append(" and dpl.IDPRODUCTO=dd.IDPRODUCTO ")
        strSQL.Append(" and dd.CANTIDADREAL>0 ")

        strSQL.Append(" inner join SAB_ALM_LOTES l on  ")
        strSQL.Append(" l.IDALMACEN=dpl.IDALMACEN and ")
        strSQL.Append(" l.IDLOTE=dpl.IDLOTE ")

        strSQL.Append(" where d.iddistribucion=@IDDISTRIBUCION and d.IDESTABLECIMIENTO=@IDESTABLECIMIENTO and l.CANTIDADDISPONIBLE>0 ")
        strSQL.Append(" order by dp.idproducto, dpl.IDLOTE  ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function eliminarTodoDistribucionEstablecimiento(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM ")
        strSQL.Append("  SAB_EST_DISTRIBUCIONESTABLECIMIENTO ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDDISTRIBUCION = @IDDISTRIBUCION AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO  ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
    

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerIDSuministroDistribucion(iddistribucion As Integer, idestablecimiento As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("  select idsuministro from sab_est_distribucion where iddistribucion=" & iddistribucion & " and idestablecimiento=" & idestablecimiento)

        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ListaEstablecimientosPorDistribucion(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Dim strSQL As New StringBuilder

        'strSQL.Append(" select distinct dc.idestablecimientodistribucion as idestablecimiento, e.NOMBRE ")
        'strSQL.Append(" from dbo.SAB_EST_DISTRIBUCIONESCERRADAS dc inner join SAB_CAT_ESTABLECIMIENTOS e on  ")
        'strSQL.Append(" dc.IDESTABLECIMIENTODISTRIBUCION=e.IDESTABLECIMIENTO ")
        'strSQL.Append(" where dc.IDDISTRIBUCION =" & iddistribucion & "  and dc.IDESTABLECIMIENTO=" & idestablecimiento)

        strSQL.Append(" select  dc.idestablecimientodistribucion as idestablecimiento, e.NOMBRE, SUM(dc.CANTIDADDISTRIBUIR), SUM(dc.cantidaddistribuida) ")
        strSQL.Append(" from dbo.SAB_EST_DISTRIBUCIONESCERRADAS dc inner join SAB_CAT_ESTABLECIMIENTOS e on  ")
        strSQL.Append(" dc.IDESTABLECIMIENTODISTRIBUCION=e.IDESTABLECIMIENTO  ")
        strSQL.Append(" where dc.IDDISTRIBUCION =" & iddistribucion & "  and dc.IDESTABLECIMIENTO=" & idestablecimiento)
        strSQL.Append(" group by dc.idestablecimientodistribucion, e.NOMBRE ")
        strSQL.Append(" having SUM(dc.CANTIDADDISTRIBUIR)<>SUM(dc.cantidaddistribuida) ")

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ListaProductosPorEstabyDistribucion(iddistribucion As Integer, idestablecimiento As Integer, idestablecimientodistribucion As Integer) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append("    select  distinct dc.idproducto, corrproducto, desclargo, dc.CANTIDADDISTRIBUIR-isnull(dc.CANTIDADDISTRIBUIDA,0) as CANTIDADDISTRIBUIR ")
        strSQL.Append(" from SAB_EST_DISTRIBUCIONESCERRADAS dc inner join vv_CATALOGOPRODUCTOS v on  ")
        strSQL.Append(" dc.IDPRODUCTO=v.IDPRODUCTO inner join SAB_EST_DISTRIBUCIONESCERRRADASLOTES dcl on ")
        strSQL.Append(" dcl.iddistribucion=dc.IDDISTRIBUCION and dcl.idestablecimiento=dc.IDESTABLECIMIENTO ")
        strSQL.Append(" and dcl.idproducto=dc.IDPRODUCTO and dc.cantidaddistribuir<>dc.cantidaddistribuida  ")

        strSQL.Append(" where dc.IDDISTRIBUCION=" & iddistribucion & "  and dc.IDESTABLECIMIENTO=" & idestablecimiento & " and dc.IDESTABLECIMIENTODISTRIBUCION =  " & idestablecimientodistribucion)

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    Public Function ListaDistribucionFechaEntrega(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Dim strSQL As New StringBuilder


        'strSQL.Append(" select d.IDDISTRIBUCION,d.IDESTABLECIMIENTO,e.nombre as establecimiento,d.IDPROGRAMA,d.IDESTABLECIMIENTODISTRIBUCION, CASE WHEN d.idfechaentrega is null THEN GETDATE() ELSE d.FECHAENTREGA END AS FECHAENTREGA, isnull(d.observacion,'') as observacion ")
        'strSQL.Append(" from SAB_EST_DISTRIBUCIONFECHAENTREGA d inner join sab_cat_establecimientos e on e.idestablecimiento=d.idestablecimientodistribucion ")

        'strSQL.Append("  LEFT OUTER JOIN SAB_EST_DISTRIBUCIONFECHAENTREGAHISTORIAL DFEH ON DFEH.IDDISTRIBUCION=D.IDDISTRIBUCION ")
        'strSQL.Append("  AND DFEH.IDESTABLECIMIENTO=D.IDESTABLECIMIENTO ")
        'strSQL.Append("  AND DFEH.IDESTABLECIMIENTODISTRIBUCION=D.IDESTABLECIMIENTODISTRIBUCION ")
        'strSQL.Append("  AND DFEH.IDFECHAENTREGA=D.IDFECHAENTREGA ")

        strSQL.Append(" WITH X AS ( ")
        strSQL.Append(" SELECT IDDISTRIBUCION,IDESTABLECIMIENTO,IDPROGRAMA,IDESTABLECIMIENTODISTRIBUCION,MAX(IDFECHAENTREGA) AS IDFECHAENTREGA ")
        strSQL.Append(" FROM SAB_EST_DISTRIBUCIONFECHAENTREGA ")
        strSQL.Append(" GROUP BY IDDISTRIBUCION,IDESTABLECIMIENTO,IDPROGRAMA,IDESTABLECIMIENTODISTRIBUCION ) ")
        strSQL.Append("  ")
        strSQL.Append(" SELECT X.IDDISTRIBUCION,X.IDESTABLECIMIENTO,e.nombre as establecimiento,X.IDPROGRAMA,X.IDESTABLECIMIENTODISTRIBUCION, CASE WHEN c.idfechaentrega is null THEN GETDATE() ELSE c.FECHAENTREGA END AS FECHAENTREGA, ISNULL(c.observacion,'') as observacion  ")
        strSQL.Append(" FROM X INNER JOIN SAB_EST_DISTRIBUCIONFECHAENTREGA C  ")
        strSQL.Append(" ON X.IDDISTRIBUCION=C.IDDISTRIBUCION AND ")
        strSQL.Append(" X.IDESTABLECIMIENTO=C.IDESTABLECIMIENTO AND ")
        strSQL.Append(" X.IDPROGRAMA=C.IDPROGRAMA AND ")
        strSQL.Append(" X.IDESTABLECIMIENTODISTRIBUCION=C.IDESTABLECIMIENTODISTRIBUCION AND ")
        strSQL.Append(" X.IDFECHAENTREGA=C.IDFECHAENTREGA ")
        strSQL.Append(" inner join SAB_CAT_ESTABLECIMIENTOS E on e.IDESTABLECIMIENTO=c.IDESTABLECIMIENTODISTRIBUCION ")


        strSQL.Append(" where c.IDDISTRIBUCION=" & iddistribucion & " and c.IDESTABLECIMIENTO=" & idestablecimiento)
        strSQL.Append(" ORDER BY c.IDFECHAENTREGA DESC ")
        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    Public Function ActualizarFechasEntrega(iddistribucion As Integer, idestablecimiento As Integer, idprograma As Integer, idestablecimientodistribucion As Integer, fechaentrega As DateTime, observacion As String) As Integer

        ' EliminarFechasEntrega(iddistribucion, idestablecimiento, idprograma)
        Dim nuevoid As Integer
        Dim IDO As Integer
        IDO = ObtenerIDFechaEntrega(iddistribucion, idestablecimiento, idprograma, idestablecimientodistribucion)
        nuevoid = ObtenerIDFechaEntrega(iddistribucion, idestablecimiento, idprograma, idestablecimientodistribucion) + 1

        If IDO = 0 Then
            Dim strSQL As New StringBuilder
            strSQL.Append(" UPDATE SAB_EST_DISTRIBUCIONFECHAENTREGA SET IDFECHAENTREGA=1, fechaentrega=@fechaentrega, observacion='" & observacion & "'  WHERE IDDISTRIBUCION=" & iddistribucion & " AND IDESTABLECIMIENTO=" & idestablecimiento & " AND IDESTABLECIMIENTODISTRIBUCION=" & idestablecimientodistribucion)
            Dim args(0) As SqlParameter
            args(0) = New SqlParameter("@fechaentrega", SqlDbType.Date)
            args(0).Value = fechaentrega
            SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

            'Dim strSQL2 As New StringBuilder
            'strSQL2.Append(" INSERT sab_est_distribucionfechaentregahistorial(iddistribucion, idestablecimiento, idestablecimientodistribucion,idfechaentrega,fechaentrega,observacion) ")
            'strSQL2.Append(" values(" & iddistribucion & "," & idestablecimiento & "," & idestablecimientodistribucion & ",1,CONVERT(DATETIME,'" & CStr(fechaentrega) & "',103),'" & observacion & "')")
            'Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL2.ToString())
        Else
            Dim strSQL As New StringBuilder
            strSQL.Append(" INSERT sab_est_distribucionfechaentrega(iddistribucion, idestablecimiento,idprograma, idestablecimientodistribucion,idfechaentrega,fechaentrega,observacion) ")
            strSQL.Append(" values(" & iddistribucion & "," & idestablecimiento & "," & idprograma & "," & idestablecimientodistribucion & "," & nuevoid & ",@fechaentrega,'" & observacion & "')")
            Dim args(0) As SqlParameter
            args(0) = New SqlParameter("@fechaentrega", SqlDbType.Date)
            args(0).Value = fechaentrega
            SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

            'Dim strSQL2 As New StringBuilder
            'strSQL2.Append(" INSERT sab_est_distribucionfechaentregahistorial(iddistribucion, idestablecimiento, idestablecimientodistribucion,idfechaentrega,fechaentrega,observacion) ")
            'strSQL2.Append(" values(" & iddistribucion & "," & idestablecimiento & "," & idestablecimientodistribucion & "," & nuevoid & ",CONVERT(DATETIME,'" & CStr(fechaentrega) & "',103),'" & observacion & "')")
            'Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL2.ToString())
        End If

        End Function
    Public Function ObtenerIDFechaEntrega(iddistribucion As Integer, idestablecimiento As Integer, idprograma As Integer, idestablecimientodistribucion As Integer) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append(" select max(idfechaentrega) from sab_est_distribucionfechaentrega WHERE  iddistribucion=" & iddistribucion & " and idestablecimiento=" & idestablecimiento & " and idprograma=" & idprograma & " and idestablecimientodistribucion=" & idestablecimientodistribucion)
        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function EliminarFechasEntrega(iddistribucion As Integer, idestablecimiento As Integer) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append(" DELETE sab_est_distribucionfechaentrega WHERE  iddistribucion=" & iddistribucion & " and idestablecimiento=" & idestablecimiento)
        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function EliminarFechasEntregaHistorial(iddistribucion As Integer, idestablecimiento As Integer) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append(" DELETE sab_est_distribucionfechaentregahistorial WHERE  iddistribucion=" & iddistribucion & " and idestablecimiento=" & idestablecimiento)
        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ActualizarCantidadDistribuida(iddistribucion As Integer, idestablecimiento As Integer, idestablecimientodistribucion As Integer, idproducto As Integer, cantidaddistribuida As Decimal) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" UPDATE SAB_EST_DISTRIBUCIONESCERRADAS SET CANTIDADDISTRIBUIDA=" & cantidaddistribuida & ", FECHADOCUMENTO=GETDATE() WHERE IDDISTRIBUCION=" & iddistribucion & " AND IDESTABLECIMIENTO=" & idestablecimiento & " AND IDESTABLECIMIENTODISTRIBUCION=" & idestablecimientodistribucion & " AND IDPRODUCTO=" & idproducto) '(iddistribucion, idestablecimiento,idprograma, idestablecimientodistribucion,fechaentrega) values(" & iddistribucion & "," & idestablecimiento & "," & idprograma & "," & idestablecimientodistribucion & ",CONVERT(DATETIME,'" & CStr(fechaentrega) & "',103))")
        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerCantidadDistribuida(iddistribucion As Integer, idestablecimiento As Integer, idestablecimientodistribucion As Integer, idproducto As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" select isnull(cantidaddistribuida,0) from SAB_EST_DISTRIBUCIONESCERRADAS WHERE IDDISTRIBUCION=" & iddistribucion & " AND IDESTABLECIMIENTO=" & idestablecimiento & " AND IDESTABLECIMIENTODISTRIBUCION=" & idestablecimientodistribucion & " AND IDPRODUCTO=" & idproducto) '(iddistribucion, idestablecimiento,idprograma, idestablecimientodistribucion,fechaentrega) values(" & iddistribucion & "," & idestablecimiento & "," & idprograma & "," & idestablecimientodistribucion & ",CONVERT(DATETIME,'" & CStr(fechaentrega) & "',103))")
        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerLotesDistribucion(iddistribucion As Integer, idestablecimiento As Integer, idproducto As Integer, idalmacen As Integer) As DataSet
        Dim strSQL As New StringBuilder


        strSQL.Append(" select idlote from dbo.SAB_EST_DISTRIBUCIONESCERRRADASLOTES where iddistribucion=" & iddistribucion & " and idestablecimiento=" & idestablecimiento & " and idproducto=" & idproducto & " and idalmacen=" & idalmacen)

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    Public Function ObtenerFechaEntregaDistribucion(iddistribucion As Integer, idestablecimiento As Integer, idestablecimientodistribucion As Integer) As String
        Dim strSQL As New StringBuilder


        strSQL.Append(" select TOP 1 convert(varchar,fechaentrega,103) fechaentrega from SAB_EST_DISTRIBUCIONFECHAENTREGA where IDDISTRIBUCION=" & iddistribucion & " and idestablecimiento=" & idestablecimiento & " and idestablecimientodistribucion=" & idestablecimientodistribucion & " ORDER BY IDFECHAENTREGA DESC ")

        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerMesesCalculo(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT MESESDISTRIBUCION+MESESADMINISTRACION+MESESSEGURIDAD FROM SAB_EST_DISTRIBUCION WHERE IDDISTRIBUCION=@IDDISTRIBUCION AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO


        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function Obtenerfechaconsumo(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Date

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT FECHACORTE FROM SAB_EST_DISTRIBUCION WHERE IDDISTRIBUCION=@IDDISTRIBUCION AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDISTRIBUCION", SqlDbType.Int)
        args(0).Value = IDDISTRIBUCION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO


        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function VerificarLista(ByVal IDDISTRIBUCION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append(" select  dc.idestablecimientodistribucion as idestablecimiento, e.NOMBRE, SUM(dc.CANTIDADDISTRIBUIR), SUM(dc.cantidaddistribuida) ")
        strSQL.Append(" from dbo.SAB_EST_DISTRIBUCIONESCERRADAS dc inner join SAB_CAT_ESTABLECIMIENTOS e on  ")
        strSQL.Append(" dc.IDESTABLECIMIENTODISTRIBUCION=e.IDESTABLECIMIENTO  ")
        strSQL.Append(" where dc.IDDISTRIBUCION =" & IDDISTRIBUCION & "  and dc.IDESTABLECIMIENTO=" & IDESTABLECIMIENTO)
        strSQL.Append(" group by dc.idestablecimientodistribucion, e.NOMBRE ")
        strSQL.Append(" having SUM(dc.CANTIDADDISTRIBUIR)<>SUM(dc.cantidaddistribuida) ")

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerReporteDistribucion4(idestablecimiento As Integer, anio As Integer) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append(" select d.DESCRIPCION, SUM(v.PRECIOACTUAL*CANTIDADDISTRIBUIR) as montodistribuir, isnull(SUM(v.precioactual*cantidaddistribuida),0) as montorecibido,  ")
        strSQL.Append("   CASE ")
        strSQL.Append("     WHEN D.ESTADO = 0 THEN 'Iniciada' ")
        strSQL.Append("     WHEN D.ESTADO = 1 THEN 'Guardada' ")
        strSQL.Append("     WHEN D.ESTADO = 2 THEN 'Cerrada' ")
        strSQL.Append("     WHEN D.ESTADO = 3 THEN 'Pendiente' ")
        strSQL.Append("     WHEN D.ESTADO = 4 THEN 'Finalizada' ")
        ' Se agrega estado Anulada a peticion de la UNAB 19032012
        strSQL.Append("     WHEN D.ESTADO = 5 THEN 'Anulada' ")

        strSQL.Append("     ELSE 'Finalizada' ")
        strSQL.Append("   END AS ESTADO ")
        strSQL.Append(" from dbo.SAB_EST_DISTRIBUCIONESCERRADAS dc inner join SAB_EST_DISTRIBUCION d ")
        strSQL.Append(" on d.IDDISTRIBUCION=dc.IDDISTRIBUCION and d.IDESTABLECIMIENTO=dc.IDESTABLECIMIENTO ")
        strSQL.Append(" inner join vv_CATALOGOPRODUCTOS v on v.IDPRODUCTO=dc.IDPRODUCTO ")
        strSQL.Append(" where year(d.fechadistribucion)=" & anio & " and d.estado in (2,3,4,5) and d.idestablecimiento=" & idestablecimiento)
        strSQL.Append(" group by d.DESCRIPCION, d.estado ")

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerReporteDistribucion1(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append(" select d.DESCRIPCION, e.NOMBRE,sum(v.PRECIOACTUAL*CANTIDADDISTRIBUIR) as montodistribuir, isnull(SUM(v.precioactual*cantidaddistribuida),0) as montorecibido, count(dc.IDPRODUCTO) as asignados ")
        strSQL.Append(" ,( select COUNT(idproducto)  ")
        strSQL.Append(" from dbo.SAB_EST_DISTRIBUCIONESCERRADAS  ")
        strSQL.Append(" where IDDISTRIBUCION=d.iddistribucion and IDESTABLECIMIENTO=d.IDESTABLECIMIENTO and IDESTABLECIMIENTODISTRIBUCION=dc.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append(" and CANTIDADDISTRIBUIDA=CANTIDADDISTRIBUIR) as despachados ")

        strSQL.Append(" ,( select COUNT(idproducto)  ")
        strSQL.Append(" from dbo.SAB_EST_DISTRIBUCIONESCERRADAS  ")
        strSQL.Append(" where IDDISTRIBUCION=d.iddistribucion and IDESTABLECIMIENTO=d.IDESTABLECIMIENTO and IDESTABLECIMIENTODISTRIBUCION=dc.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append(" and ((CANTIDADDISTRIBUIDA<CANTIDADDISTRIBUIR) and (cantidaddistribuida>0))) as productosEnDespacho ")

        strSQL.Append(" from dbo.SAB_EST_DISTRIBUCIONESCERRADAS dc inner join SAB_EST_DISTRIBUCION d ")
        strSQL.Append(" on d.IDDISTRIBUCION=dc.IDDISTRIBUCION and d.IDESTABLECIMIENTO=dc.IDESTABLECIMIENTO ")
        strSQL.Append(" inner join vv_CATALOGOPRODUCTOS v on v.IDPRODUCTO=dc.IDPRODUCTO ")
        strSQL.Append(" inner join SAB_CAT_ESTABLECIMIENTOS e on e.IDESTABLECIMIENTO=dc.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append(" where d.iddistribucion=" & iddistribucion & " and d.IDESTABLECIMIENTO=" & idestablecimiento)
        strSQL.Append(" group by d.DESCRIPCION, e.nombre, dc.IDESTABLECIMIENTODISTRIBUCION,d.iddistribucion,d.IDESTABLECIMIENTO ")


        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerReporteDistribucion2(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append(" select d.DESCRIPCION, e.NOMBRE,v.corrproducto, v.desclargo,v.unidadmedida,dc.CANTIDADDISTRIBUIR ")
        strSQL.Append(" ,case when isnull(dd.CONSUMOPROMEDIOAJUSTADO,0)=0 then '-' else convert(varchar,cast(round(dc.CANTIDADDISTRIBUIR/dd.CONSUMOPROMEDIOAJUSTADO,2) as decimal(18,2))) end as cobertura ")
        strSQL.Append("  ")
        strSQL.Append(" from dbo.SAB_EST_DISTRIBUCIONESCERRADAS dc inner join SAB_EST_DISTRIBUCION d ")
        strSQL.Append(" on d.IDDISTRIBUCION=dc.IDDISTRIBUCION and d.IDESTABLECIMIENTO=dc.IDESTABLECIMIENTO ")
        strSQL.Append(" inner join vv_CATALOGOPRODUCTOS v on v.IDPRODUCTO=dc.IDPRODUCTO ")
        strSQL.Append(" inner join SAB_CAT_ESTABLECIMIENTOS e on e.IDESTABLECIMIENTO=dc.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append(" inner join SAB_EST_DISTRIBUCIONDETALLE dd on dd.IDDISTRIBUCION=d.IDDISTRIBUCION and dd.IDESTABLECIMIENTO=d.IDESTABLECIMIENTO ")
        strSQL.Append(" and dd.IDPRODUCTO=dc.IDPRODUCTO and dd.IDESTABLECIMIENTODISTRIBUCION=dc.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append(" where d.iddistribucion=" & iddistribucion & " and d.IDESTABLECIMIENTO=" & idestablecimiento)

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerReporteDistribucion3(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append(" select d.DESCRIPCION, d.fechadistribucion,e.NOMBRE,  dfe.fechaentrega  ,v.corrproducto, v.desclargo,v.unidadmedida, ")
        strSQL.Append(" case when dc.fechadocumento is null then '-' else convert(varchar,dc.fechadocumento,103) end as fechaentregaproducto, case when dc.fechadocumento is null then '-' else convert(varchar,dc.fechadocumento,103) end as fecharecepcionproducto ")

        strSQL.Append(" from dbo.SAB_EST_DISTRIBUCIONESCERRADAS dc inner join SAB_EST_DISTRIBUCION d ")
        strSQL.Append(" on d.IDDISTRIBUCION=dc.IDDISTRIBUCION and d.IDESTABLECIMIENTO=dc.IDESTABLECIMIENTO ")
        strSQL.Append(" inner join vv_CATALOGOPRODUCTOS v on v.IDPRODUCTO=dc.IDPRODUCTO ")
        strSQL.Append(" inner join SAB_CAT_ESTABLECIMIENTOS e on e.IDESTABLECIMIENTO=dc.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append(" inner join SAB_EST_DISTRIBUCIONDETALLE dd on dd.IDDISTRIBUCION=d.IDDISTRIBUCION and dd.IDESTABLECIMIENTO=d.IDESTABLECIMIENTO ")
        strSQL.Append(" and dd.IDPRODUCTO=dc.IDPRODUCTO and dd.IDESTABLECIMIENTODISTRIBUCION=dc.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append(" inner join sab_est_distribucionfechaentrega dfe on dfe.iddistribucion=dc.iddistribucion and dfe.idestablecimiento=dc.idestablecimiento ")
        strSQL.Append(" and dfe.idestablecimientodistribucion=dc.idestablecimientodistribucion ")

        strSQL.Append(" where  d.iddistribucion=" & iddistribucion & " and d.IDESTABLECIMIENTO=" & idestablecimiento)
        strSQL.Append("  order by e.nombre ")
        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerReporteDistribucion5(iddistribucion As Integer, idestablecimiento As Integer) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append(" select d.DESCRIPCION, e.NOMBRE,v.corrproducto, v.desclargo,v.unidadmedida,dc.CANTIDADDISTRIBUIR,  ")
        strSQL.Append(" case when d.ESTADO=2 then 'Cerrada'  when d.estado=3 then 'Pendiente'  when d.estado=4 then 'Finalizada' when d.estado=5 then 'Suspendida' end AS estado, ")
        strSQL.Append(" dt.valesalida, dt.FECHACIERREVALE,dt.CANTIDADVALE,dt.NUMERORECIBO,dt.FECHACIERRERECIBO,dt.CANTIDADRECIBO ")
        strSQL.Append("     ")
        strSQL.Append(" from dbo.SAB_EST_DISTRIBUCIONESCERRADAS dc inner join SAB_EST_DISTRIBUCION d  ")
        strSQL.Append(" on d.IDDISTRIBUCION=dc.IDDISTRIBUCION and d.IDESTABLECIMIENTO=dc.IDESTABLECIMIENTO  ")
        strSQL.Append(" inner join vv_CATALOGOPRODUCTOS v on v.IDPRODUCTO=dc.IDPRODUCTO  ")
        strSQL.Append(" inner join SAB_CAT_ESTABLECIMIENTOS e on e.IDESTABLECIMIENTO=dc.IDESTABLECIMIENTODISTRIBUCION  ")
        strSQL.Append(" inner join SAB_EST_DISTRIBUCIONDETALLE dd on dd.IDDISTRIBUCION=d.IDDISTRIBUCION and dd.IDESTABLECIMIENTO=d.IDESTABLECIMIENTO  ")
        strSQL.Append(" and dd.IDPRODUCTO=dc.IDPRODUCTO and dd.IDESTABLECIMIENTODISTRIBUCION=dc.IDESTABLECIMIENTODISTRIBUCION  ")
        strSQL.Append("       ")
        strSQL.Append(" inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
        strSQL.Append(" ae.IDESTABLECIMIENTO=dc.IDESTABLECIMIENTODISTRIBUCION ")
        strSQL.Append("        ")
        strSQL.Append(" inner join SAB_EST_DISTRIBUCIONTRAZABILIDAD dt on ")
        strSQL.Append(" dt.IDDISTRIBUCION=d.IDDISTRIBUCION and ")
        strSQL.Append(" dt.IDESTABLECIMIENTO=d.IDESTABLECIMIENTO and ")
        strSQL.Append(" dt.IDALMACEN=d.IDALMACEN and ")
        strSQL.Append(" dt.IDPRODUCTO = dc.IDPRODUCTO and ")
        strSQL.Append(" dt.IDALMACENDISTRIBUCION= ae.IDALMACEN ")
        strSQL.Append("       ")
        strSQL.Append(" where d.iddistribucion=" & iddistribucion & " and d.IDESTABLECIMIENTO=" & idestablecimiento & " and d.ESTADO>1 ")

        'strSQL.Append(" where d.iddistribucion=" & iddistribucion & " and d.IDESTABLECIMIENTO=" & idestablecimiento)

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ActualizarTrazabilidad(iddistribucion As Integer, idestablecimiento As Integer, idalmacen As Integer, idproducto As Integer, numerovale As Integer, fechacierrevale As String, cantidadvale As Decimal, idalmacendistribucion As Integer, numerorecibo As String, fechacierrerecibo As String, cantidadrecibo As Decimal, VALESALIDA As String) As Integer
        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT SAB_EST_DISTRIBUCIONTRAZABILIDAD(iddistribucion, idestablecimiento, idalmacen,idproducto,numerovale,fechacierrevale,cantidadvale,idalmacendistribucion,numerorecibo,fechacierrerecibo,cantidadrecibo,valesalida) values(" & iddistribucion & "," & idestablecimiento & "," & idalmacen & "," & idproducto & "," & numerovale & ",'" & fechacierrevale & "'," & cantidadvale & "," & idalmacendistribucion & ",'" & numerorecibo & "/" & Now.Year & "','" & fechacierrerecibo & "'," & cantidadvale & ",'" & numerovale & "/" & Now.Year & "' )")
        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function InsertarValeSalidaDistribucion(iddistribucion As Integer, idvale As Integer)
        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT SAB_EST_DISTRIBUCIONVALESALIDA(iddistribucion, idvalesalida) values(" & iddistribucion & "," & idvale & ")") '," & idalmacen & "," & idproducto & "," & numerovale & ",'" & fechacierrevale & "'," & cantidadvale & "," & idalmacendistribucion & ",'" & numerorecibo & "/" & Now.Year & "','" & fechacierrerecibo & "'," & cantidadvale & ",'" & numerovale & "/" & Now.Year & "' )")
        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerIdDistribucion(idalmacen As Integer, idmovimiento As Integer) As Integer
        Dim strSQL As New StringBuilder

        strSQL.Append(" select iddistribucion ")
        strSQL.Append(" from sab_est_distribucionvalesalida ")
        strSQL.Append(" where idvalesalida=( ")
        strSQL.Append(" select iddocumento ")
        strSQL.Append(" from SAB_ALM_MOVIMIENTOS ")
        strSQL.Append(" where IDALMACEN=" & idalmacen & " and IDMOVIMIENTO=" & idmovimiento & " and idtipotransaccion=2)")

        Return SqlHelper.ExecuteScalar(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function
End Class
