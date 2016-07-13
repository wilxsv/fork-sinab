Partial Public Class dbALMACENES

#Region " METODOS AGREGADOS "
    ''' <summary>
    ''' Consulta de almacenes filtrado por parámetros
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <returns>Listado de almacenes en formato dataset</returns>

    Public Function FiltroAlmacenPorId(ByVal IDALMACEN As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALMACEN = " + IDALMACEN)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Listado de almacenes
    ''' </summary>
    ''' <returns>Listado de almacenes en formato dataset</returns>

    Public Function ObtenerAlmacenesDS() As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE ESFARMACIA = 1")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    ''' <summary>
    ''' Obtener la lista de almacenes por orden alfabetico
    ''' </summary>
    ''' <param name="tipo">Identificador del tipo de orden</param>
    ''' <returns>Listado de almacenes en formato de lista</returns>

    Public Function ObtenerListaOrden(ByVal tipo As Integer) As listaALMACENES

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        Select Case tipo
            Case Is = 0
                strSQL.Append(" WHERE NOMBRE NOT LIKE 'U%' order by NOMBRE ASC ")
            Case Is = 1
                strSQL.Append(" WHERE NOMBRE NOT LIKE 'U%'order by NOMBRE DESC ")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaALMACENES

        Try
            Do While dr.Read()
                Dim mEntidad As New ALMACENES
                mEntidad.IDALMACEN = IIf(dr("IDALMACEN") Is DBNull.Value, Nothing, dr("IDALMACEN"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.ESFARMACIA = IIf(dr("ESFARMACIA") Is DBNull.Value, Nothing, dr("ESFARMACIA"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function
    ''' <summary>
    ''' Obtener la lista de almacenes por orden alfabetico
    ''' </summary>
    ''' <param name="tipo">Identificador del tipo de orden</param>
    ''' <returns>Listado de almacenes en formato de lista</returns>

    Public Function ObtenerListaOrden2(ByVal tipo As Integer) As listaALMACENES

        Dim strSQL As New Text.StringBuilder
        SelectTabla2(strSQL)
        Select Case tipo
            Case Is = 0
                strSQL.Append(" order by NOMBRE ASC ")
            Case Is = 1
                strSQL.Append(" order by NOMBRE DESC ")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaALMACENES

        Try
            Do While dr.Read()
                Dim mEntidad As New ALMACENES
                mEntidad.IDALMACEN = IIf(dr("IDALMACEN") Is DBNull.Value, Nothing, dr("IDALMACEN"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.ESFARMACIA = IIf(dr("ESFARMACIA") Is DBNull.Value, Nothing, dr("ESFARMACIA"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function
    ''' <summary>
    ''' Obtiene los almacenes que se relacionen a un proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos.</param>
    ''' <param name="idprocesocompra">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_PROGRAMADISTRIBUCION</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function ObtenerAlmacenesDSProcesoCompraContrato(ByVal idprocesocompra As Integer, ByVal idestablecimiento As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT distinct a.IDALMACEN, a.NOMBRE ")
        strSQL.Append(" FROM SAB_UACI_PROGRAMADISTRIBUCION pd INNER JOIN ")
        strSQL.Append(" SAB_CAT_ALMACENES a ON pd.IDALMACEN = a.IDALMACEN ")
        strSQL.Append(" WHERE (pd.IDESTABLECIMIENTO = " & idestablecimiento & ") AND (pd.IDPROCESOCOMPRA = " & idprocesocompra & " ) ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    '''Devuelve todos los almacenes para los cuales se esperan recepciones generadas por procesos de compra iniciados en el periodo especificado 
    ''' </summary>
    ''' <param name="fini">Identificador de la fecha inicial</param>
    ''' <param name="ffin">Identificador de la fecha fin</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns></returns>

    Public Function ObtenerAlmacenesDatasetPorPeriodo(ByVal fini As Date, ByVal ffin As Date, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT a.IDALMACEN, a.NOMBRE")
        strSQL.Append(" FROM SAB_UACI_PROGRAMADISTRIBUCION AS pd INNER JOIN")
        strSQL.Append(" SAB_CAT_ALMACENES AS a ON pd.IDALMACEN = a.IDALMACEN INNER JOIN")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS AS pc ON pd.IDPROCESOCOMPRA = pc.IDPROCESOCOMPRA AND ")
        strSQL.Append(" pd.IDESTABLECIMIENTO = pc.IDESTABLECIMIENTO")
        strSQL.Append(" WHERE (pd.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND ")
        strSQL.Append(" (pc.FECHAINICIOPROCESOCOMPRA >= @fini) AND (pc.FECHAINICIOPROCESOCOMPRA <= @ffin) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@fini", SqlDbType.DateTime)
        args(1).Value = fini
        args(2) = New SqlParameter("@ffin", SqlDbType.DateTime)
        args(2).Value = ffin

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene información de los almacenes de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos.</param>
    ''' <param name="IDPROCESOCOMPRA">Filtro para devolver los datos.</param>
    ''' <param name="IDALMACEN">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_UACI_PROGRAMADISTRIBUCION</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function DevolverAlmacen(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT 0 AS RENGLON, '' AS CORRPRODUCTO, '' AS DESCLARGO, 0 AS CANTIDADENTREGAS, '' AS NUMEROCONTRATO, '' AS NOMBRECONTRATO, A.NOMBRE AS NOMBREALMACEN, '' AS CODIGOPROVEEDOR, '' AS NOMBREPROVEEDOR ")
        strSQL.Append(" FROM SAB_CAT_ALMACENES A INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROGRAMADISTRIBUCION PD ON ")
        strSQL.Append(" A.IDALMACEN = PD.IDALMACEN ")
        strSQL.Append(" WHERE PD.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND PD.IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND A.IDALMACEN = @IDALMACEN ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.BigInt)
        args(2).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Lista de almacenes 
    ''' </summary>
    ''' <returns>Lista de almacenes en formato de dataset</returns>

    Public Function RecuperarOrdenada() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDALMACEN, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" DIRECCION, ")
        strSQL.Append(" TELEFONO, ")
        strSQL.Append(" FAX, ")
        strSQL.Append(" ESFARMACIA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_ALMACENES ")
        strSQL.Append(" ORDER BY NOMBRE")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    ''' <summary>
    ''' Consulta de periodos de devolucion
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="dsP">Identificador de un conjunto de datos</param>
    ''' <returns>Listado del periodo en formato de dataset</returns>

    Public Function DevolverAlmacenPeriodo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer, ByVal dsP As DataSet) As DataSet

        Dim strSQL As New Text.StringBuilder
        Dim i As Integer
        For i = 0 To dsP.Tables(0).Rows.Count - 1
            strSQL.Append(" SELECT DISTINCT 0 AS RENGLON, '' AS CORRPRODUCTO, '' AS DESCLARGO, 0 AS CANTIDADENTREGAS, '' AS NUMEROCONTRATO, '' AS NOMBRECONTRATO, A.NOMBRE AS NOMBREALMACEN, '' AS CODIGOPROVEEDOR, '' AS NOMBREPROVEEDOR ")
            strSQL.Append(" FROM SAB_CAT_ALMACENES A INNER JOIN ")
            strSQL.Append(" SAB_UACI_PROGRAMADISTRIBUCION PD ON ")
            strSQL.Append(" A.IDALMACEN = PD.IDALMACEN ")
            strSQL.Append(" WHERE PD.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND PD.IDPROCESOCOMPRA = " & dsP.Tables(0).Rows(i).Item(0).ToString & "  AND A.IDALMACEN = @IDALMACEN")
            If i < dsP.Tables(0).Rows.Count - 1 Then
                strSQL.Append(" union ")
            End If
        Next

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.BigInt)
        args(1).Value = IDALMACEN

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    '''  obtener Dataset de lista de almacenes 
    ''' </summary>
    ''' <returns>Listado de almacenes en formato dataset</returns>
    Public Function ObtenerDataSetListaAlmacenes() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDALMACEN, NOMBRE, DIRECCION, TELEFONO, FAX, ESFARMACIA, AUUSUARIOCREACION, AUFECHACREACION, AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION, ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_ALMACENES")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Listado de almacenes de un establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Informacion del almacen en formato dataset</returns>
    Public Function ObtenerListaAlmacenes(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT A.IDALMACEN, A.NOMBRE  ")
        strSQL.Append("FROM SAB_CAT_ALMACENES A INNER JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append("ON A.IDALMACEN = AE.IDALMACEN ")
        strSQL.Append("WHERE A.ESTADOALMACEN = 1 AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerSemana(ByVal fecha As DateTime) As Int32


        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDSEMANA ")
        strSQL.Append(" FROM SAB_CAT_SEMANAS ")
        strSQL.Append(" WHERE ANIO=" & fecha.Year)
        'strSQL.Append(" AND INICIOMES=" & fecha.Month)
        strSQL.Append(" AND convert(varchar,@fecha,112) BETWEEN INICIO AND FIN")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@fecha", SqlDbType.DateTime)
        args(0).Value = fecha

        Dim A As Integer
        A = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Return A
        'If A = 0 Then
        '    Dim strSQL2 As New Text.StringBuilder
        '    strSQL2.Append(" Select MAX(IDSEMANA) ")
        '    strSQL2.Append(" FROM SAB_CAT_SEMANAS ")
        '    strSQL2.Append(" WHERE ANIO=" & fecha.Year)
        '    strSQL2.Append(" AND INICIOMES = " & fecha.Month)
        '    Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL2.ToString())
        'Else
        '    Return A
        'End If

    End Function
    Public Function ObtenerSemanaAnio(ByVal fecha As DateTime, ByVal anio As Integer) As Int32


        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDSEMANA ")
        strSQL.Append(" FROM SAB_CAT_SEMANAS ")
        strSQL.Append(" WHERE ANIO=" & fecha.Year)
        'strSQL.Append(" AND INICIOMES=" & fecha.Month)
        strSQL.Append(" AND convert(varchar,@fecha,112) BETWEEN INICIO AND FIN")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@fecha", SqlDbType.DateTime)
        args(0).Value = fecha

        Dim A As Integer
        A = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Return A
        'If A = 0 Then
        '    Dim strSQL2 As New Text.StringBuilder
        '    strSQL2.Append(" Select MAX(IDSEMANA) ")
        '    strSQL2.Append(" FROM SAB_CAT_SEMANAS ")
        '    strSQL2.Append(" WHERE ANIO=" & fecha.Year)
        '    strSQL2.Append(" AND INICIOMES = " & fecha.Month)
        '    Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL2.ToString())
        'Else
        '    Return A
        'End If

    End Function

    Public Function ObtenerDatosSemana(ByVal IDSEMANA As Integer) As String


        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT 'Del ' + CONVERT(VARCHAR,DAY(INICIO)) + ' de ' +  CONVERT(VARCHAR,DATENAME(m,INICIO))")
        'strSQL.Append(" CASE WHEN INICIOMES=1 THEN 'ENERO' WHEN INICIOMES=2 THEN 'FEBRERO' WHEN INICIOMES=3 THEN 'MARZO'   ")
        'strSQL.Append(" WHEN INICIOMES=4 THEN 'ABRIL' WHEN INICIOMES=5 THEN 'MAYO' WHEN INICIOMES=6 THEN 'JUNIO'  ")
        'strSQL.Append(" WHEN INICIOMES=7 THEN 'JULIO' WHEN INICIOMES=8 THEN 'AGOSTO' WHEN INICIOMES=9 THEN 'SEPTIEMBRE'  ")
        'strSQL.Append(" WHEN INICIOMES=10 THEN 'OCTUBRE' WHEN INICIOMES=11 THEN 'NOVIEMBRE' WHEN INICIOMES=12 THEN 'DICIEMBRE' END  ")
        strSQL.Append(" + ' al ' + CONVERT(VARCHAR,DAY(FIN)) + ' de ' +  CONVERT(VARCHAR,DATENAME(m,FIN)) ")
        'strSQL.Append(" CASE WHEN FINMES=1 THEN 'ENERO' WHEN FINMES=2 THEN 'FEBRERO' WHEN FINMES=3 THEN 'MARZO' WHEN FINMES=4 THEN 'ABRIL'  ")
        'strSQL.Append(" WHEN FINMES=5 THEN 'MAYO' WHEN FINMES=6 THEN 'JUNIO' WHEN FINMES=7 THEN 'JULIO' WHEN FINMES=8 THEN 'AGOSTO'  ")
        'strSQL.Append(" WHEN FINMES=9 THEN 'SEPTIEMBRE' WHEN FINMES=10 THEN 'OCTUBRE' WHEN FINMES=11 THEN 'NOVIEMBRE' WHEN FINMES=12 THEN 'DICIEMBRE' END + ' de '  ")
        strSQL.Append(" + ' ' + CONVERT(VARCHAR,ANIO ) ")
        strSQL.Append(" FROM SAB_CAT_SEMANAS  ")
        strSQL.Append(" WHERE IDSEMANA=" & IDSEMANA)
        strSQL.Append(" AND ANIO=" & DateTime.Now.Year)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    
    Public Function EliminarProductosSinExistencia(ByVal Idalmacen As Integer, ByVal idsemana As Integer, ByVal idsuministro As Integer) As Integer


        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" DELETE  FROM SAB_ALM_PRODUCTOSSINEXISTENCIA ")
        strSQL.Append(" WHERE IDALMACEN =" & Idalmacen)
        strSQL.Append(" AND IDSUMINISTRO=" & idsuministro)
        strSQL.Append(" AND IDSEMANA = " & idsemana)
        strSQL.Append(" AND ANIO=" & DateTime.Now.Year)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function AdicionarProductosSinExistencia(ByVal Idalmacen As Integer, ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal idproducto As Integer) As Integer


        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" INSERT INTO SAB_ALM_PRODUCTOSSINEXISTENCIA ")
        strSQL.Append(" VALUES(" & Idalmacen)
        strSQL.Append(" ," & DateTime.Now.Year)
        strSQL.Append(" ," & idsuministro)
        strSQL.Append(" ," & idsemana)
        strSQL.Append(" ," & idproducto)
        strSQL.Append(" ,NULL,0)")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerProductosSinExistencia(ByVal Idalmacen As Integer, ByVal anio As Integer, ByVal idsuministro As Integer, ByVal idsemana As Integer) As DataSet
        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("P.IDALMACEN, ")
        strSQL.Append("A.NOMBRE NOMBREALMACEN, ")
        strSQL.Append("P.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.IDUNIDADMEDIDA, ")
        strSQL.Append("CP.DESCRIPCION UNIDADMEDIDA, ")
        strSQL.Append("CP.IDSUMINISTRO, ")
        strSQL.Append("CP.CORRSUMINISTRO, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.IDGRUPO, ")
        strSQL.Append("CP.CORRGRUPO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.IDSUBGRUPO, ")
        strSQL.Append("CP.CORRSUBGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
       
        strSQL.Append("P.EXISTENCIAFARMACIA ")

        strSQL.Append("FROM SAB_ALM_PRODUCTOSSINEXISTENCIA P  ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS CP  ")
        strSQL.Append("ON P.IDPRODUCTO = CP.IDPRODUCTO  ")
        strSQL.Append("INNER JOIN SAB_CAT_ALMACENES A  ")
        strSQL.Append("ON P.IDALMACEN = A.IDALMACEN ")

        strSQL.Append("WHERE P.IDALMACEN = @IDALMACEN AND  ")
        strSQL.Append("CP.IDSUMINISTRO = @IDSUMINISTRO AND  ")
        strSQL.Append("P.ANIO = @ANIO AND  ")
        strSQL.Append("P.IDSEMANA = @IDSEMANA   ")

        strSQL.Append("ORDER BY CP.CORRPRODUCTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = Idalmacen
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = idsuministro
        args(2) = New SqlParameter("@ANIO", SqlDbType.Int)
        args(2).Value = anio
        args(3) = New SqlParameter("@IDSEMANA", SqlDbType.Int)
        args(3).Value = idsemana
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function
    Public Function ActualizarProductosSinExistencia(ByVal Idalmacen As Integer, ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal idproducto As Integer, ByVal ANIO As Integer, ByVal existenciafarmacia As Integer) As Integer


        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" UPDATE SAB_ALM_PRODUCTOSSINEXISTENCIA ")
        strSQL.Append(" SET FECHA=GETDATE(), EXISTENCIAFARMACIA=" & existenciafarmacia)
        strSQL.Append(" WHERE IDALMACEN=" & Idalmacen)
        strSQL.Append(" AND IDSUMINISTRO=" & idsuministro)
        strSQL.Append(" AND IDSEMANA=" & idsemana)
        strSQL.Append(" AND IDPRODUCTO=" & idproducto)
        strSQL.Append(" AND ANIO=" & ANIO)


        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerSemanasAConsultar(ByVal idsemana As Integer) As DataSet


        Dim strSQL As New Text.StringBuilder
        'strSQL.Append("declare @idsemana int,@anio int ")
        'strSQL.Append("if not @idsemana=1 ")
        'strSQL.Append("begin ")
        strSQL.Append(" SELECT idsemana,'Semana ' + convert(varchar,idsemana) + ' - Del ' + CONVERT(VARCHAR,DAY(INICIO)) + ' de ' +  CONVERT(VARCHAR,DATENAME(m,INICIO)) ")
        '+ convert(varchar,iniciodia) + ' de ' + ")
        '        strSQL.Append(" CASE WHEN INICIOMES=1 THEN 'Enero' WHEN INICIOMES=2 THEN 'Febrero' WHEN INICIOMES=3 THEN 'Marzo'    ")
        '        strSQL.Append(" WHEN INICIOMES=4 THEN 'Abril' WHEN INICIOMES=5 THEN 'Mayo' WHEN INICIOMES=6 THEN 'Junio'   ")
        '        strSQL.Append(" WHEN INICIOMES=7 THEN 'Julio' WHEN INICIOMES=8 THEN 'Aagosto' WHEN INICIOMES=9 THEN 'Septiembre'   ")
        '        strSQL.Append(" WHEN INICIOMES=10 THEN 'Octubre' WHEN INICIOMES=11 THEN 'Noviembre' WHEN INICIOMES=12 THEN 'Diciembre' END ")
        strSQL.Append(" + ' al ' + CONVERT(VARCHAR,DAY(FIN)) + ' de ' +  CONVERT(VARCHAR,DATENAME(m,FIN)) as SEMANA ")
        'strSQL.Append(" CASE WHEN FINMES=1 THEN 'Enero' WHEN FINMES=2 THEN 'Febrero' WHEN FINMES=3 THEN 'Marzo'    ")
        'strSQL.Append(" WHEN FINMES=4 THEN 'Abril' WHEN FINMES=5 THEN 'Mayo' WHEN FINMES=6 THEN 'Junio'   ")
        'strSQL.Append(" WHEN FINMES=7 THEN 'Julio' WHEN FINMES=8 THEN 'Aagosto' WHEN FINMES=9 THEN 'Septiembre'   ")
        'strSQL.Append(" WHEN FINMES=10 THEN 'Octubre' WHEN FINMES=11 THEN 'Noviembre' WHEN FINMES=12 THEN 'Diciembre' END AS SEMANA ")
        strSQL.Append(" from SAB_CAT_SEMANAS ")
        strSQL.Append(" where  anio=@anio and idsemana < @idsemana ")
        ' strSQL.Append("end ")
        'strSQL.Append("else ")
        'strSQL.Append("begin ")
        'strSQL.Append(" SELECT idsemana,'Semana ' + ")
        'strSQL.Append("convert(varchar,idsemana) + ")
        'strSQL.Append("'  Del ' + CONVERT(VARCHAR,DAY(INICIO)) + ")
        'strSQL.Append("' de ' +  CONVERT(VARCHAR,DATENAME(m,INICIO))  + ")
        'strSQL.Append(" ' al ' + CONVERT(VARCHAR,DAY(FIN)) + ' de ' +  CONVERT(VARCHAR,DATENAME(m,FIN)) as SEMANA ")
        'strSQL.Append(" from SAB_CAT_SEMANAS ")
        'strSQL.Append("where idsemana = 52 and ANIO=@anio-1 ")
        'strSQL.Append("end ")
        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idsemana", SqlDbType.Int)
        args(0).Value = idsemana
        args(1) = New SqlParameter("@anio", SqlDbType.Int)
        args(1).Value = Now.Year

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerSemanasAConsultarAnteriores(ByVal Anio As Integer) As DataSet


        Dim strSQL As New Text.StringBuilder
        'strSQL.Append("declare @idsemana int,@anio int ")
        strSQL.Append(" SELECT idsemana,'Semana ' + convert(varchar,idsemana) + ' - Del ' + CONVERT(VARCHAR,DAY(INICIO)) + ' de ' +  CONVERT(VARCHAR,DATENAME(m,INICIO)) ")
        '+ convert(varchar,iniciodia) + ' de ' + ")
        '        strSQL.Append(" CASE WHEN INICIOMES=1 THEN 'Enero' WHEN INICIOMES=2 THEN 'Febrero' WHEN INICIOMES=3 THEN 'Marzo'    ")
        '        strSQL.Append(" WHEN INICIOMES=4 THEN 'Abril' WHEN INICIOMES=5 THEN 'Mayo' WHEN INICIOMES=6 THEN 'Junio'   ")
        '        strSQL.Append(" WHEN INICIOMES=7 THEN 'Julio' WHEN INICIOMES=8 THEN 'Aagosto' WHEN INICIOMES=9 THEN 'Septiembre'   ")
        '        strSQL.Append(" WHEN INICIOMES=10 THEN 'Octubre' WHEN INICIOMES=11 THEN 'Noviembre' WHEN INICIOMES=12 THEN 'Diciembre' END ")
        strSQL.Append(" + ' al ' + CONVERT(VARCHAR,DAY(FIN)) + ' de ' +  CONVERT(VARCHAR,DATENAME(m,FIN)) as SEMANA ")
        'strSQL.Append(" CASE WHEN FINMES=1 THEN 'Enero' WHEN FINMES=2 THEN 'Febrero' WHEN FINMES=3 THEN 'Marzo'    ")
        'strSQL.Append(" WHEN FINMES=4 THEN 'Abril' WHEN FINMES=5 THEN 'Mayo' WHEN FINMES=6 THEN 'Junio'   ")
        'strSQL.Append(" WHEN FINMES=7 THEN 'Julio' WHEN FINMES=8 THEN 'Aagosto' WHEN FINMES=9 THEN 'Septiembre'   ")
        'strSQL.Append(" WHEN FINMES=10 THEN 'Octubre' WHEN FINMES=11 THEN 'Noviembre' WHEN FINMES=12 THEN 'Diciembre' END AS SEMANA ")
        strSQL.Append(" from SAB_CAT_SEMANAS ")
        strSQL.Append(" where  anio=@anio ")
        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@anio", SqlDbType.Int)
        args(0).Value = Anio
     

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerAnioAbastecimiento() As DataSet


        Dim strSQL As New Text.StringBuilder
        'strSQL.Append("declare @idsemana int,@anio int ")

        strSQL.Append(" SELECT distinct anio ")
        strSQL.Append(" from SAB_CAT_SEMANAS ")


        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    'SCMS
    Public Function ObtenerNivelAbastecimiento(ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal anio As Integer, Optional idprograma As Integer = 0) As DataSet
        Dim strSQL As New Text.StringBuilder
        '--select c1.idhospital,count(c1.idproducto), case when count(c2.idproducto)=0 then '-' else convert(varchar,count(c2.idproducto)) end as se
        strSQL.Append(" select ROW_NUMBER() OVER (ORDER BY e.nombre) AS 'Correlativo',e.nombre,count(c1.idproducto) cb, count(c2.idproducto)as se ") '--,convert(decimal(15,2),count(c2.idproducto)/count(c1.idproducto)) as porcdes ")
        strSQL.Append(" from sab_alm_productosalmacen c1 ")
        strSQL.Append(" inner join sab_cat_almacenesestablecimientos ae ")
        strSQL.Append(" on ae.idalmacen=c1.idhospital ")
        strSQL.Append(" inner join sab_Cat_establecimientos e on ")
        strSQL.Append(" e.idestablecimiento=ae.idestablecimiento ")

        If idprograma <> 0 Then
            strSQL.Append(" inner join sab_Cat_productosprogramas pp on ")
            strSQL.Append(" pp.idproducto=c1.idproducto and ")
            strSQL.Append(" pp.idprograma=" & idprograma)
        End If

        strSQL.Append(" left outer join sab_alm_productossinexistencia c2 ")
        strSQL.Append(" on c1.idhospital=c2.idalmacen and ")
        strSQL.Append(" c1.idsuministro=c2.idsuministro and ")
        strSQL.Append(" c1.idproducto=c2.idproducto and ")
        strSQL.Append(" c2.existenciafarmacia=0 and ")
        strSQL.Append(" c2.idsemana=" & idsemana)
        strSQL.Append(" and c2.anio=" & anio)
        strSQL.Append(" and c2.idsuministro=" & idsuministro)
        strSQL.Append(" group by e.nombre ")


        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerNivelAbastecimientoPantalla(ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal anio As Integer) As DataSet
        Dim strSQL As New Text.StringBuilder
        '--select c1.idhospital,count(c1.idproducto), case when count(c2.idproducto)=0 then '-' else convert(varchar,count(c2.idproducto)) end as se
        strSQL.Append(" select ROW_NUMBER() OVER (ORDER BY e.nombre) AS 'Correlativo',c1.idhospital, e.nombre,count(c1.idproducto) cb, count(c2.idproducto)as se ,convert(decimal(15,1),round(convert(decimal(15,3),convert(decimal(15,3),count(c2.idproducto))/convert(decimal(15,3),count(c1.idproducto)))*100,1)) as porcdes, convert(decimal(15,1),round(100-(convert(decimal(15,3),convert(decimal(15,3),count(c2.idproducto))/convert(decimal(15,3),count(c1.idproducto)))*100),1)) as porcabas ")
        strSQL.Append(" from sab_alm_productosalmacen c1 ")
        strSQL.Append(" inner join sab_cat_almacenesestablecimientos ae ")
        strSQL.Append(" on ae.idalmacen=c1.idhospital ")
        strSQL.Append(" inner join sab_Cat_establecimientos e on ")
        strSQL.Append(" e.idestablecimiento=ae.idestablecimiento ")
        strSQL.Append(" left outer join sab_alm_productossinexistencia c2 ")
        strSQL.Append(" on c1.idhospital=c2.idalmacen and ")
        strSQL.Append(" c1.idsuministro=c2.idsuministro and ")
        strSQL.Append(" c1.idproducto=c2.idproducto and ")
        strSQL.Append(" c2.existenciafarmacia=0 and ")
        strSQL.Append(" c2.idsemana=" & idsemana)
        strSQL.Append(" and c2.anio=" & anio)
        strSQL.Append(" and c2.idsuministro=" & idsuministro)
        strSQL.Append(" group by e.nombre,c1.idhospital ")


        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerNivelAbastecimientoProductos(ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal anio As Integer, ByVal idhospital As Integer) As DataSet
        Dim strSQL As New Text.StringBuilder

        strSQL.Append("select ROW_NUMBER() OVER (ORDER BY cp.corrproducto) AS 'Correlativo',cp.corrproducto,cp.desclargo ")
        strSQL.Append("from sab_alm_productossinexistencia pe inner join vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append(" on pe.idproducto=cp.idproducto ")
        strSQL.Append("where pe.anio= " & anio)
        strSQL.Append("and pe.idsuministro= " & idsuministro)
        strSQL.Append("and pe.idsemana=" & idsemana)
        strSQL.Append("and pe.idalmacen= " & idhospital)
        strSQL.Append("and pe.existenciafarmacia=0 ")
        strSQL.Append("order by cp.corrproducto ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    'scms
    Public Function ObtenerNivelAbastecimientoProductosMensual(ByVal Mes As String, ByVal idsuministro As Integer, ByVal anio As Integer, ByVal idhospital As Integer, Optional idprograma As Integer = 0) As DataSet
        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" select ROW_NUMBER() OVER (ORDER BY cp.corrproducto) AS 'Correlativo',cp.corrproducto,cp.desclargo ")
        strSQL.Append(" from sab_alm_productossinexistencia pe inner join vv_CATALOGOPRODUCTOS cp  ")
        strSQL.Append(" on pe.idproducto=cp.idproducto  ")
        If idhospital <> 0 Then
            strSQL.Append("     inner join SAB_CAT_PRODUCTOSPROGRAMAS pp on ")
            strSQL.Append("       pp.idProducto = cp.idproducto and ")
            strSQL.Append("       pp.idPrograma =" & idhospital)
        End If
        strSQL.Append(" where pe.anio= " & anio)
        strSQL.Append(" and pe.idsuministro= " & idsuministro)
        strSQL.Append(" and pe.existenciafarmacia=0 ")
        strSQL.Append(" and pe.FECHA between '" & anio & Mes & "01' and DATEADD(d, -1, DATEADD(m, DATEDIFF(m, 0,'" & anio & Mes & "01') + 1, 0)) ")
        strSQL.Append(" group by cp.corrproducto,cp.desclargo ")
        strSQL.Append(" order by cp.corrproducto  ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    Public Function ObtenerNombre(ByVal idhospital As Integer) As String
        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" SELECT E.NOMBRE ")
        strSQL.Append(" from sab_alm_productossinexistencia c1 ")
        strSQL.Append(" inner join sab_cat_almacenesestablecimientos ae ")
        strSQL.Append(" on ae.idalmacen=c1.idalmacen ")
        strSQL.Append(" inner join sab_Cat_establecimientos e on ")
        strSQL.Append(" e.idestablecimiento=ae.idestablecimiento ")
        strSQL.Append(" WHERE C1.IDALMACEN=" & idhospital)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerPromedioNacional(ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal anio As Integer) As Decimal
        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" select avg(convert(decimal(15,4),convert(decimal(15,4),se)/convert(decimal(15,4),cb))) ")
        strSQL.Append(" from FN_NIVELABAS(" & idsemana & "," & anio & "," & idsuministro & ") ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
#End Region

End Class
