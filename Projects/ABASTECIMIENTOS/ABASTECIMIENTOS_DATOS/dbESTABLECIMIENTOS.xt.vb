Partial Public Class dbESTABLECIMIENTOS

#Region "Funciones adicionales"

    ''' <summary>
    ''' Obtiene los SIBASIS agrupados por zonas
    ''' </summary>
    ''' <param name="IDZONA">Identificador de zona</param>
    ''' <returns>Lista de establecimientos</returns>
    Public Function ObtenerSIBASISporZona(ByVal IDZONA As Integer) As listaESTABLECIMIENTOS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDMUNICIPIO, ")
        strSQL.Append(" E.IDTIPOESTABLECIMIENTO, ")
        strSQL.Append(" E.IDZONA, ")
        strSQL.Append(" IDINSTITUCION, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" DIRECCION, ")
        strSQL.Append(" TELEFONO, ")
        strSQL.Append(" FAX, ")
        strSQL.Append(" IDPADRE, ")
        strSQL.Append(" NIVEL, ")
        strSQL.Append(" E.AUUSUARIOCREACION, ")
        strSQL.Append(" E.AUFECHACREACION, ")
        strSQL.Append(" E.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" E.AUFECHAMODIFICACION, ")
        strSQL.Append(" E.ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_ESTABLECIMIENTOS E INNER JOIN SAB_CAT_TIPOESTABLECIMIENTOS T ON E.IDTIPOESTABLECIMIENTO = T.IDTIPOESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ZONAS Z ON E.IDZONA = Z.IDZONA ")
        strSQL.Append(" WHERE Z.IDZONA = " & IDZONA)
        strSQL.Append(" ORDER BY NOMBRE, E.IDTIPOESTABLECIMIENTO ")

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New ESTABLECIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.IDMUNICIPIO = IIf(dr("IDMUNICIPIO") Is DBNull.Value, Nothing, dr("IDMUNICIPIO"))
                mEntidad.IDTIPOESTABLECIMIENTO = IIf(dr("IDTIPOESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDTIPOESTABLECIMIENTO"))
                mEntidad.IDZONA = IIf(dr("IDZONA") Is DBNull.Value, Nothing, dr("IDZONA"))
                mEntidad.IDINSTITUCION = IIf(dr("IDINSTITUCION") Is DBNull.Value, Nothing, dr("IDINSTITUCION"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.IDPADRE = IIf(dr("IDPADRE") Is DBNull.Value, Nothing, dr("IDPADRE"))
                mEntidad.NIVEL = IIf(dr("NIVEL") Is DBNull.Value, Nothing, dr("NIVEL"))
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
    ''' Filtro de establecimientos consolidados
    ''' </summary>
    ''' <returns>LIsta de establecimientos en formato dataset</returns>
    Public Function FiltrarEstabParaConsolidado() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT E.IDESTABLECIMIENTO, E.IDTIPOESTABLECIMIENTO, ")
        strSQL.Append("E.NOMBRE FROM SAB_CAT_ESTABLECIMIENTOS E WHERE ")
        strSQL.Append("E.IDTIPOESTABLECIMIENTO = '2' ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Obtener la dirección de un establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Direccion de un establecimiento en formato dataset</returns>
    Public Function ObtenerUbicacionEstablecimiento(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        strSQL.Append("SELECT E.IDESTABLECIMIENTO, isnull(E.DIRECCION, '') DIRECCION, isnull(M.NOMBRE, '') NOMBRE ")
        strSQL.Append("FROM SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("INNER JOIN SAB_CAT_MUNICIPIOS M ")
        strSQL.Append("ON E.IDMUNICIPIO = M.IDMUNICIPIO ")
        strSQL.Append("WHERE E.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Validacion de region en un establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Valor booleano con el resultado de la validacion</returns>
    Public Function EsRegionElEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOESTABLECIMIENTO = 2 ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Validacion si un establecimiento es clasificado como especial
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Valor booleano con el resultado de la validacion</returns>
    Public Function EsEspecialElEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDTIPOESTABLECIMIENTO = 9 ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True
    End Function

    ''' <summary>
    ''' Filtro de establecimientos por sibasi
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Resultado del filtro de establecimientos en formato dataset</returns>
    Public Function FiltrarEstablecimientosPorSibasi(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT E.IDESTABLECIMIENTO, E.IDTIPOESTABLECIMIENTO, ")
        strSQL.Append("E.NOMBRE FROM SAB_CAT_ESTABLECIMIENTOS E WHERE ")
        strSQL.Append("E.IDPADRE = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtener listado de establecimientos en forma ordenada
    ''' </summary>
    ''' <param name="tipo">Identificador del tipo</param>
    ''' <returns>Lista de establecimientos</returns>
    Public Function ObtenerListaOrden(ByVal tipo As Integer) As listaESTABLECIMIENTOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("ORDER BY NOMBRE ")

        Select Case tipo
            Case 0
                strSQL.Append("ASC ")
            Case 1
                strSQL.Append("DESC ")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New ESTABLECIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.CODIGOESTABLECIMIENTO = IIf(dr("CODIGOESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("CODIGOESTABLECIMIENTO"))
                mEntidad.IDMUNICIPIO = IIf(dr("IDMUNICIPIO") Is DBNull.Value, Nothing, dr("IDMUNICIPIO"))
                mEntidad.IDTIPOESTABLECIMIENTO = IIf(dr("IDTIPOESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDTIPOESTABLECIMIENTO"))
                mEntidad.IDZONA = IIf(dr("IDZONA") Is DBNull.Value, Nothing, dr("IDZONA"))
                mEntidad.IDINSTITUCION = IIf(dr("IDINSTITUCION") Is DBNull.Value, Nothing, dr("IDINSTITUCION"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.IDPADRE = IIf(dr("IDPADRE") Is DBNull.Value, Nothing, dr("IDPADRE"))
                mEntidad.NIVEL = IIf(dr("NIVEL") Is DBNull.Value, Nothing, dr("NIVEL"))
                mEntidad.TIPOCONSUMO = IIf(dr("TIPOCONSUMO") Is DBNull.Value, Nothing, dr("TIPOCONSUMO"))
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

    ' Filtrar Por Nombre de Establecimiento 15/07/2007
    ''' <summary>
    ''' Filtro de establecimientos por su nombre
    ''' </summary>
    ''' <param name="filtro">Identificacion del filtro</param>
    ''' <returns>Lista de establecimientos</returns>
    Public Function BuscarEstablecimiento(ByVal filtro As String) As listaESTABLECIMIENTOS

        filtro = "'" & filtro & "%" & "'"
        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE NOMBRE LIKE @filtro ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@filtro", SqlDbType.VarChar)
        args(0).Value = filtro

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New ESTABLECIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.CODIGOESTABLECIMIENTO = IIf(dr("CODIGOESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("CODIGOESTABLECIMIENTO"))
                mEntidad.IDMUNICIPIO = IIf(dr("IDMUNICIPIO") Is DBNull.Value, Nothing, dr("IDMUNICIPIO"))
                mEntidad.IDTIPOESTABLECIMIENTO = IIf(dr("IDTIPOESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDTIPOESTABLECIMIENTO"))
                mEntidad.IDZONA = IIf(dr("IDZONA") Is DBNull.Value, Nothing, dr("IDZONA"))
                mEntidad.IDINSTITUCION = IIf(dr("IDINSTITUCION") Is DBNull.Value, Nothing, dr("IDINSTITUCION"))
                mEntidad.NOMBRE = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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
    ''' Filtro de establecimientos segun la zona a la que pertenecen
    ''' </summary>
    ''' <param name="IDZONA">Identificador de zona</param>
    ''' <returns>Lista de establecimientos en formato dataset</returns>
    Public Function FiltrosEstablecimientosZonaETZ(Optional ByVal IDZONA As Int32 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT SAB_CAT_ZONAS.IDZONA, SAB_CAT_ZONAS.DESCRIPCION, SAB_CAT_ESTABLECIMIENTOS.CODIGOESTABLECIMIENTO, ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS.IDESTABLECIMIENTO, SAB_CAT_ESTABLECIMIENTOS.NOMBRE, SAB_CAT_ESTABLECIMIENTOS.IDPADRE, ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS.IDTIPOESTABLECIMIENTO, SAB_CAT_TIPOESTABLECIMIENTOS.DESCRIPCION AS TIPO, ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS.NIVEL ")
        strSQL.Append("FROM SAB_CAT_ZONAS INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS ON SAB_CAT_ZONAS.IDZONA = SAB_CAT_ESTABLECIMIENTOS.IDZONA INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOESTABLECIMIENTOS ON ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS.IDTIPOESTABLECIMIENTO = SAB_CAT_TIPOESTABLECIMIENTOS.IDTIPOESTABLECIMIENTO ")
        strSQL.Append("WHERE (SAB_CAT_ESTABLECIMIENTOS.IDTIPOESTABLECIMIENTO = 3 ") 'Hospital
        strSQL.Append("AND (SAB_CAT_ZONAS.IDZONA = @IDZONA OR SAB_CAT_ZONAS.IDZONA = 0)) ")
        strSQL.Append("OR (SAB_CAT_ESTABLECIMIENTOS.IDTIPOESTABLECIMIENTO = 2 ") 'sibasi o region
        strSQL.Append("AND (SAB_CAT_ZONAS.IDZONA = @IDZONA OR SAB_CAT_ZONAS.IDZONA = 0)) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(0).Value = IDZONA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Listado de establecimientos
    ''' </summary>
    ''' <returns>Establecimientos en formato dataset</returns>
    Public Function ObtenerdsEstablecimiento() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT E.IDESTABLECIMIENTO, E.CODIGOESTABLECIMIENTO, M.NOMBRE AS MUNICIPIO, TE.DESCRIPCION AS TIPOESTABLECIMIENTO, ")
        strSQL.Append("Z.DESCRIPCION AS ZONA, E.NOMBRE AS ESTABLECIMIENTO, E.DIRECCION, E.TELEFONO, E.FAX, E.IDPADRE, E.NIVEL, E.TIPOCONSUMO, ")
        strSQL.Append("E.AUUSUARIOCREACION, E.AUFECHACREACION, E.AUUSUARIOMODIFICACION, E.AUFECHAMODIFICACION, E.ESTASINCRONIZADA, ")
        strSQL.Append("TE.IDTIPOESTABLECIMIENTO, Z.IDZONA, M.IDMUNICIPIO ")
        strSQL.Append("FROM SAB_CAT_ESTABLECIMIENTOS AS E INNER JOIN ")
        strSQL.Append("SAB_CAT_MUNICIPIOS AS M ON E.IDMUNICIPIO = M.IDMUNICIPIO INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPOESTABLECIMIENTOS AS TE ON E.IDTIPOESTABLECIMIENTO = TE.IDTIPOESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_ZONAS AS Z ON E.IDZONA = Z.IDZONA ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el listado de los establecimientos por zona
    ''' </summary>
    ''' <param name="IDZONA">Filtro para devolver los datos por zona.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENESESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function ObtenerListaPorID2(ByVal IDZONA As Integer) As listaESTABLECIMIENTOS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT E.IDESTABLECIMIENTO, ")
        strSQL.Append(" E.CODIGOESTABLECIMIENTO, ")
        strSQL.Append(" E.IDMUNICIPIO, ")
        strSQL.Append(" E.IDTIPOESTABLECIMIENTO, ")
        strSQL.Append(" E.IDZONA, ")
        strSQL.Append(" E.IDINSTITUCION, ")
        strSQL.Append(" E.NOMBRE, ")
        strSQL.Append(" E.DIRECCION, ")
        strSQL.Append(" E.TELEFONO, ")
        strSQL.Append(" E.FAX, ")
        strSQL.Append(" E.IDPADRE, ")
        strSQL.Append(" E.NIVEL, ")
        strSQL.Append(" E.TIPOCONSUMO, ")
        strSQL.Append(" E.AUUSUARIOCREACION, ")
        strSQL.Append(" E.AUFECHACREACION, ")
        strSQL.Append(" E.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" E.AUFECHAMODIFICACION, ")
        strSQL.Append(" E.ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_ESTABLECIMIENTOS E INNER JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS A ON E.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO")
        strSQL.Append(" WHERE E.IDZONA = " & IDZONA & " and NOT NOMBRE LIKE  'ALM%' ")

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New ESTABLECIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.CODIGOESTABLECIMIENTO = IIf(dr("CODIGOESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("CODIGOESTABLECIMIENTO"))
                mEntidad.IDMUNICIPIO = IIf(dr("IDMUNICIPIO") Is DBNull.Value, Nothing, dr("IDMUNICIPIO"))
                mEntidad.IDTIPOESTABLECIMIENTO = IIf(dr("IDTIPOESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDTIPOESTABLECIMIENTO"))
                mEntidad.IDZONA = IIf(dr("IDZONA") Is DBNull.Value, Nothing, dr("IDZONA"))
                mEntidad.IDINSTITUCION = IIf(dr("IDINSTITUCION") Is DBNull.Value, Nothing, dr("IDINSTITUCION"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.IDPADRE = IIf(dr("IDPADRE") Is DBNull.Value, Nothing, dr("IDPADRE"))
                mEntidad.NIVEL = IIf(dr("NIVEL") Is DBNull.Value, Nothing, dr("NIVEL"))
                mEntidad.TIPOCONSUMO = IIf(dr("TIPOCONSUMO") Is DBNull.Value, Nothing, dr("TIPOCONSUMO"))
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
    ''' Obtener los codigos de los establecimientos
    ''' </summary>
    ''' <returns>Lista de establecimientos</returns>
    Public Function ObtenerDataSetCodigoEstablecimiento() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT E.IDESTABLECIMIENTO, E.CODIGOESTABLECIMIENTO + ' / ' + E.NOMBRE as NOMBRECODIGO ")
        strSQL.Append("FROM SAB_CAT_ESTABLECIMIENTOS E ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Obtener el nombre del establecimientos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Nombre del establecimiento</returns>
    Public Function ObtenerNomEstablecimiento(ByVal IDESTABLECIMIENTO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT NOMBRE FROM SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Validacion si existe codigo de un establecimiento
    ''' </summary>
    ''' <param name="CODIGOESTABLECIMIENTO">Identificacion del codigo del establecimiento</param>
    ''' <returns>Valor booleano con el resultado de la validacion</returns>
    Public Function ExisteCodigo(ByVal CODIGOESTABLECIMIENTO As String) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) FROM SAB_CAT_ESTABLECIMIENTOS WHERE CODIGOESTABLECIMIENTO = @CODIGOESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@CODIGOESTABLECIMIENTO", SqlDbType.VarChar)
        args(0).Value = CODIGOESTABLECIMIENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

    ''' <summary>
    ''' Obtener el identificador unico del establecimiento
    ''' </summary>
    ''' <param name="CODIGOESTABLECIMIENTO">Identificacion del codigo del establecimiento</param>
    ''' <returns>Valor entero con el Identificador unico</returns>
    Public Function ObtenerIDEstablecimiento(ByVal CODIGOESTABLECIMIENTO As String) As Integer
        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDESTABLECIMIENTO FROM SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append("WHERE CODIGOESTABLECIMIENTO = @CODIGOESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@CODIGOESTABLECIMIENTO", SqlDbType.VarChar)
        args(0).Value = CODIGOESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
    End Function

    ''' <summary>
    ''' Inserción de la informacion relacionada a las solicitudes
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad Detallecompradisco</param>
    ''' <returns>Valor entero con el resultado de la inserción</returns>
    Public Function InsertarDetalleDisco2(ByVal aEntidad As DetalleCompraDisco) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("INSERT INTO temp2 ")
        strSQL.Append(" ( RENGLON, ")
        strSQL.Append(" U_M, ")
        strSQL.Append(" PRECIO, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" COD_ESTA, ")
        strSQL.Append(" CODIGO, ")
        strSQL.Append(" ENTREGA, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDALMACEN, IDFUENTEFINANCIAMIENTO) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @RENGLON, ")
        strSQL.Append(" @U_M, ")
        strSQL.Append(" @PRECIO, ")
        strSQL.Append(" @CANTIDAD, ")
        strSQL.Append(" @COD_ESTA, ")
        strSQL.Append(" @CODIGO, ")
        strSQL.Append(" @ENTREGA, ")
        strSQL.Append(" @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDALMACEN, @IDFF) ")

        Dim args(9) As SqlParameter
        args(0) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(0).Value = aEntidad.RENGLON
        args(1) = New SqlParameter("@U_M", SqlDbType.VarChar)
        args(1).Value = aEntidad.U_M
        args(2) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(2).Value = aEntidad.PRECIO
        args(3) = New SqlParameter("@CANTIDAD", SqlDbType.Int)
        args(3).Value = aEntidad.CANTIDAD
        args(4) = New SqlParameter("@COD_ESTA", SqlDbType.VarChar)
        args(4).Value = aEntidad.COD_ESTA
        args(5) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(5).Value = aEntidad.CODIGO
        args(6) = New SqlParameter("@ENTREGA", SqlDbType.Int)
        args(6).Value = aEntidad.ENTREGA
        args(7) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(7).Value = aEntidad.IDESTABLECIMIENTO
        args(8) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(8).Value = aEntidad.IDALMACEN
        args(9) = New SqlParameter("@IDFF", SqlDbType.Int)
        args(9).Value = aEntidad.IDFF

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Inserción de informacion de una solicitud de compra
    ''' </summary>
    ''' <param name="aEntidad">Identificador de la entidad detallecompradisco</param>
    ''' <returns>Valor entero con el resultado de la inserción</returns>
    Public Function InsertarDetalleDisco(ByVal aEntidad As DetalleCompraDisco) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("INSERT INTO temp ")
        strSQL.Append(" ( RENGLON, ")
        strSQL.Append(" U_M, ")
        strSQL.Append(" PRECIO, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" COD_ESTA, ")
        strSQL.Append(" CODIGO, ")
        strSQL.Append(" ENTREGA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @RENGLON, ")
        strSQL.Append(" @U_M, ")
        strSQL.Append(" @PRECIO, ")
        strSQL.Append(" @CANTIDAD, ")
        strSQL.Append(" @COD_ESTA, ")
        strSQL.Append(" @CODIGO, ")
        strSQL.Append(" @ENTREGA) ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(0).Value = aEntidad.RENGLON
        args(1) = New SqlParameter("@U_M", SqlDbType.VarChar)
        args(1).Value = aEntidad.U_M
        args(2) = New SqlParameter("@PRECIO", SqlDbType.Decimal)
        args(2).Value = aEntidad.PRECIO
        args(3) = New SqlParameter("@CANTIDAD", SqlDbType.Int)
        args(3).Value = aEntidad.CANTIDAD
        args(4) = New SqlParameter("@COD_ESTA", SqlDbType.VarChar)
        args(4).Value = aEntidad.COD_ESTA
        args(5) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(5).Value = aEntidad.CODIGO
        args(6) = New SqlParameter("@ENTREGA", SqlDbType.Int)
        args(6).Value = aEntidad.ENTREGA
        'args(7) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        'args(7).Value = aEntidad.IDESTABLECIMIENTO
        'args(8) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        'args(8).Value = aEntidad.IDALMACEN

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Borrar la informacion del detalle del disco de solicitud de compra
    ''' </summary>
    ''' <returns>Valor entero con el resultado de la ejecución</returns>
    Public Function BorrarDetalleDisco() As Integer
        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE temp ")
        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    ''' <summary>
    ''' Borrar la informacion del detalle del disco de solicitud de compra
    ''' </summary>
    ''' <returns>Valor entero con el resultado de la ejecución</returns>
    Public Function BorrarDetalleDisco2() As Integer
        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE temp2 ")
        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    ''' <summary>
    ''' Inserción de la informacion del detalle de la solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTOSOLICITUD">Identificador del establecimiento solicitante</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <param name="usuario">Identificador del usuario</param>
    ''' <returns>Valor entero con el resultado de la ejecución</returns>
    Public Function CrearDetalleSolicitudDiscoURMIM(ByVal IDESTABLECIMIENTOSOLICITUD As Int64, ByVal IDSOLICITUD As Integer, ByVal usuario As String, ByVal idgrupo As Integer, ByVal IDESPECIFICACION As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_CargaDiscoURMIM")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue

        args(1) = New SqlParameter("@IDESTABLECIMIENTOSOLICITUD", SqlDbType.BigInt)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDESTABLECIMIENTOSOLICITUD
        args(2) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDSOLICITUD
        args(3) = New SqlParameter("@USUARIOCREACION", SqlDbType.VarChar)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = usuario
        args(4) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = idgrupo
        'args(5) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
        'args(5).Direction = ParameterDirection.Input
        'args(5).Value = IDESPECIFICACION
        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function
    ''' <summary>
    ''' Inserción de la informacion del detalle de la solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTOSOLICITUD">Identificador del establecimiento solicitante</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <param name="usuario">Identificador del usuario</param>
    ''' <returns>Valor entero con el resultado de la ejecución</returns>
    Public Function CrearDetalleSolicitudDiscoURMIM2(ByVal IDESTABLECIMIENTOSOLICITUD As Int64, ByVal IDSOLICITUD As Integer, ByVal usuario As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_CargaDiscoURMIM2")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDESTABLECIMIENTOSOLICITUD", SqlDbType.BigInt)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDESTABLECIMIENTOSOLICITUD
        args(2) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDSOLICITUD
        args(3) = New SqlParameter("@USUARIOCREACION", SqlDbType.VarChar)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = usuario

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

    ''' <summary>
    ''' Inserción de la informacion del detalle de la solicitud de compra conjunta
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTOSOLICITUD">Identificador del establecimiento solicitante</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="usuario">Identificador del usuario</param>
    ''' <returns>Valor entero con el resultado de la ejecución</returns>
    Public Function CrearDetalleSolicitudDiscoURMIM_CJ(ByVal IDESTABLECIMIENTOSOLICITUD As Int64, ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Int64, ByVal IDALMACEN As Integer, ByVal usuario As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_CargaDiscoURMIM_CJ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDESTABLECIMIENTOSOLICITUD", SqlDbType.BigInt)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDESTABLECIMIENTOSOLICITUD
        args(2) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDSOLICITUD
        args(3) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = IDESTABLECIMIENTO
        args(4) = New SqlParameter("@IDALMACEN", SqlDbType.BigInt)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = IDALMACEN
        args(5) = New SqlParameter("@USUARIOCREACION", SqlDbType.VarChar)
        args(5).Direction = ParameterDirection.Input
        args(5).Value = usuario

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

    ''' <summary>
    ''' Inserción de la informacion del detalle de la solicitud de compra conjunta
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTOSOLICITUD">Identificador del establecimiento solicitante</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <param name="usuario">Identificador del usuario</param>
    ''' <returns>Valor entero con el resultado de la ejecución</returns>
    Public Function CrearDetalleSolicitudDiscoURMIM2_CJ(ByVal IDESTABLECIMIENTOSOLICITUD As Int64, ByVal IDSOLICITUD As Integer, ByVal usuario As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_CargaDiscoURMIM2_CJ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDESTABLECIMIENTOSOLICITUD", SqlDbType.BigInt)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDESTABLECIMIENTOSOLICITUD
        args(2) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDSOLICITUD
        args(3) = New SqlParameter("@USUARIOCREACION", SqlDbType.VarChar)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = usuario

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

    ''' <summary>
    ''' Lista de establecimientos por almacen
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="VERTODOS">Identificador del filtro</param>
    ''' <returns>Listado de establecimientos en formato dataset</returns>
    Public Function RecuperarEstablecimientosPorZonaAlmancen(ByVal IDALMACEN As Integer, ByVal VERTODOS As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        'strSQL.Append("SELECT IDESTABLECIMIENTO, CODIGOESTABLECIMIENTO + ' - ' + NOMBRE NOMBRE ")
        strSQL.Append("SELECT IDESTABLECIMIENTO,  NOMBRE NOMBRE ")

        strSQL.Append("FROM SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append("WHERE ")
        strSQL.Append("(IDZONA IN (SELECT E2.IDZONA ")
        strSQL.Append("            FROM SAB_CAT_ESTABLECIMIENTOS E2 ")
        strSQL.Append("            LEFT OUTER JOIN SAB_CAT_ZONAS Z ")
        strSQL.Append("            ON E2.IDZONA = Z.IDZONA ")
        strSQL.Append("            LEFT OUTER JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append("            ON E2.IDESTABLECIMIENTO = AE.IDESTABLECIMIENTO ")
        strSQL.Append("            WHERE AE.IDALMACEN = @IDALMACEN or AE.IDALMACEN=512) ") ''SE AGREGA EL ALMACEN DE EVENTUALES QUE PERTENECE A OTRA ZONA Y SE CREA UNA NUEVA ZONA 6 Y SE ASOCIA EVENTUALES
        strSQL.Append("AND NIVEL = 1 ")
        strSQL.Append("AND IDTIPOESTABLECIMIENTO in (1, 2)) ")
        strSQL.Append("OR (@VERTODOS = 1) ")
        strSQL.Append("ORDER BY NOMBRE ")
        ' strSQL.Append("ORDER BY NIVEL, IDTIPOESTABLECIMIENTO, CODIGOESTABLECIMIENTO ")


        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@VERTODOS", SqlDbType.Int)
        args(1).Value = VERTODOS

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Lista de lugares de entrega de hospitales
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacen</param>
    ''' <param name="VERTODOS">Identificador del filtro</param>
    ''' <returns>Lista de lugares en formato dataset</returns>
    Public Function RecuperarLugaresDestinoPorHospital(ByVal IDALMACEN As Integer, ByVal VERTODOS As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        If VERTODOS = 0 Then
            strSQL.Append("SELECT ID_LUGAR_ENTREGA_HOSPITAL, convert(varchar,ID_LUGAR_ENTREGA_HOSPITAL) + ' - ' + NOMBRE_LUGAR_ENTREGA_HOSPITAL as NOMBRE ")
            strSQL.Append("FROM SAB_CAT_LUGARES_ENTREGA_HOSPITALES ")
            strSQL.Append("WHERE ")
            strSQL.Append(" (IDALMACEN = @IDALMACEN) ")
            strSQL.Append("ORDER BY ID_LUGAR_ENTREGA_HOSPITAL ")
        End If

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@VERTODOS", SqlDbType.Int)
        args(1).Value = VERTODOS

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Listado de establecimientos relacionados a la carga del disco 
    ''' </summary>
    ''' <returns>Listado de establecimientos en formato dataset</returns>
    Public Function RecuperarEstablecimientosCargaDiscoURMIM() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT E.IDESTABLECIMIENTO, T.COD_ESTA, E.NOMBRE ")
        strSQL.Append(" FROM TEMP T INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append(" ON T.COD_ESTA = E.CODIGOESTABLECIMIENTO ")
        'strSQL.Append(" --INNER JOIN SAB_CAT_ALMACENESESTABLECIMIENTOS AE ON ")
        'strSQL.Append(" --AE.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append(" GROUP BY E.IDESTABLECIMIENTO,E.NOMBRE, T.COD_ESTA ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Listado de establecimientos relacionados a la carga del disco 
    ''' </summary>
    ''' <returns>Listado de establecimientos en formato dataset</returns>
    Public Function RecuperarEstablecimientosCargaDiscoURMIM2() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT T.IDESTABLECIMIENTO, T.IDALMACEN, T.COD_ESTA, E.NOMBRE, A.NOMBRE almacen ")
        strSQL.Append(" FROM TEMP2 T INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append(" ON T.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO  ")
        strSQL.Append(" INNER JOIN SAB_CAT_ALMACENES A ON ")
        strSQL.Append(" A.IDALMACEN= T.IDALMACEN ")
        strSQL.Append(" GROUP BY T.IDESTABLECIMIENTO,T.IDALMACEN, E.NOMBRE, T.COD_ESTA, A.NOMBRE   ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Listado de establecimientos 
    ''' </summary>
    ''' <returns>Listado de establecimientos en formato dataset</returns>
    Public Function RecuperarEstablecimientos() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select  E.IDESTABLECIMIENTO, CODIGOESTABLECIMIENTO + ' - ' + NOMBRE as NOMBRE  ")
        strSQL.Append(" from SAB_CAT_ESTABLECIMIENTOS e inner join SAB_CAT_ALMACENESESTABLECIMIENTOS AE ")
        strSQL.Append(" on e.idestablecimiento = ae.idestablecimiento ")
        strSQL.Append(" where CODIGOESTABLECIMIENTO LIKE '%R' or  CODIGOESTABLECIMIENTO LIKE '%h' and e.idestablecimiento not in (656) ")
        strSQL.Append(" GROUP BY E.IDESTABLECIMIENTO, CODIGOESTABLECIMIENTO,NOMBRE ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Listado de Hospitales 
    ''' </summary>
    ''' <returns>Listados de hospitales en formato dataset</returns>
    Public Function obtenerHospitalesRegiones() As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   idEstablecimiento, nombre ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append(" where ")
        strSQL.Append("   idTipoEstablecimiento in (3,8, 10) and ")
        strSQL.Append("   idEstablecimiento not in (506, 656) ")
        strSQL.Append(" order by ")
        strSQL.Append("   nombre asc ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerEstablecimientosProgramacion(ByVal IDPROGRAMACION As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   e.idEstablecimiento, e.nombre ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_cat_establecimientos e ")
        strSQL.Append("     inner join sab_urmim_programaciondetalle pd on ")
        strSQL.Append("       e.idEstablecimiento = pd.idEstablecimiento ")
        strSQL.Append(" where ")
        strSQL.Append("   pd.idProgramacion = @IDPROGRAMACION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerHospitalesRegionesParaiso(ByVal IDPROGRAMACION) As DataSet

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   idEstablecimiento, nombre ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append(" where ")
        strSQL.Append("   (idTipoEstablecimiento in (3, 7, 8, 10) or idEstablecimiento=661) and ")
        strSQL.Append("   idEstablecimiento not in (506, 619, 656, 763) and ")

        strSQL.Append("   idEstablecimiento not in (select idEstablecimiento from sab_urmim_programaciondetalle where idProgramacion = @IDPROGRAMACION) ")
        strSQL.Append(" order by ")
        strSQL.Append("   nombre asc ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
