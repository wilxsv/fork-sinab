Partial Public Class dbFUENTEFINANCIAMIENTOS

    ''' <summary>
    ''' Busca fuente de financimiamiento en necesidades
    ''' </summary>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param> identificador de fuente de financiamiento
    ''' <returns>
    ''' verdero si encuentra coinciedencia
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSNECESIDADES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history>
    Public Function BuscarFuenteFinanciamientoEnFFNececidades(ByVal IDFUENTEFINANCIAMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDFUENTEFINANCIAMIENTO) ")
        strSQL.Append("FROM SAB_EST_FUENTEFINANCIAMIENTOSNECESIDADES ")
        strSQL.Append("WHERE (IDFUENTEFINANCIAMIENTO = @IIDFUENTEFINANCIAMIENTO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IIDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(0).Value = IDFUENTEFINANCIAMIENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    ''' <summary>
    ''' Buscar fuente de financiamiento de fuente de finaciamientos de solicitudes
    ''' </summary>
    '''  identificador de la fuente de financiamiento
    ''' <returns>
    ''' verdadero si encuentra coincidencia
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history>
    Public Function BuscarFuenteFinanciamientoEnFFSolicitudes(ByVal IDFUENTEFINANCIAMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDFUENTEFINANCIAMIENTO) ")
        strSQL.Append("FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES ")
        strSQL.Append("WHERE (IDFUENTEFINANCIAMIENTO = @IIDFUENTEFINANCIAMIENTO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IIDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(0).Value = IDFUENTEFINANCIAMIENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function
    ''' <summary>
    ''' Busca la fuente de financiamiento en contratos
    ''' </summary>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <returns>Valor booleano </returns>

    Public Function BuscarFuenteFinanciamientoEnFFContratos(ByVal IDFUENTEFINANCIAMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDFUENTEFINANCIAMIENTO) ")
        strSQL.Append("FROM SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS ")
        strSQL.Append("WHERE (IDFUENTEFINANCIAMIENTO = @IIDFUENTEFINANCIAMIENTO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IIDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(0).Value = IDFUENTEFINANCIAMIENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function
    ''' <summary>
    ''' Busqueda de fuente de financiamiento en Almacenes
    ''' </summary>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <returns>Valor booleano</returns>

    Public Function BuscarFuenteFinanciamientoEnInventarios(ByVal IDFUENTEFINANCIAMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDFUENTEFINANCIAMIENTO) ")
        strSQL.Append("FROM SAB_ALM_INVENTARIO ")
        strSQL.Append("WHERE (IDFUENTEFINANCIAMIENTO = @IIDFUENTEFINANCIAMIENTO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IIDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(0).Value = IDFUENTEFINANCIAMIENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function
    ''' <summary>
    ''' Bùsqueda de la fuente de financiamiento en la tabla de lotes
    ''' </summary>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <returns>Valor booleano</returns>

    Public Function BuscarFuenteFinanciamientoEnLotes(ByVal IDFUENTEFINANCIAMIENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(IDFUENTEFINANCIAMIENTO) ")
        strSQL.Append("FROM SAB_ALM_LOTES ")
        strSQL.Append("WHERE (IDFUENTEFINANCIAMIENTO = @IIDFUENTEFINANCIAMIENTO) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IIDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(0).Value = IDFUENTEFINANCIAMIENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    ''' <summary>
    ''' Listado de fuentes de financiamiento
    ''' </summary>
    ''' <returns>Listado de fuentes de financ. en formato de dataset</returns>
    Public Function RecuperarOrdenada() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("FF.*, ")
        strSQL.Append("case when FF.NOMBRE = 'GOES' then '_GOES' else FF.NOMBRE end NOMBREORDEN ")
        strSQL.Append("FROM SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("ORDER BY NOMBREORDEN ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Fuente de financiamiento de un proceso de compra
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Nombre de la fuente de financiamiento</returns>

    Public Function DevolverFFPC(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT FF.NOMBRE ")
        strSQL.Append(" FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES F ")
        strSQL.Append(" INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ON ")
        strSQL.Append(" FF.IDFUENTEFINANCIAMIENTO = F.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append(" INNER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS S ")
        strSQL.Append(" ON F.IDESTABLECIMIENTO = S.IDESTABLECIMIENTOSOLICITUD AND F.IDSOLICITUD = S.IDSOLICITUD ")
        strSQL.Append(" WHERE IDPROCESOCOMPRA = @IDPROCESOCOMPRA AND F.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim str As New Text.StringBuilder

        For Each dr As DataRow In ds.Tables(0).Rows
            str.Append(dr(0).ToString)
            str.Append(" ")
        Next

        Return str.ToString

    End Function

    ''' <summary>
    ''' Devuelve el nombre de la fuente de financiamiento de la solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDFUENTE">Identificador de la fuente de financiamiento</param>
    ''' <returns>Nombre de la fuente de financiamiento</returns>
    Public Function DevolverFFSo(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDFUENTE As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT FF.NOMBRE ")
        strSQL.Append(" FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES F ")
        strSQL.Append(" INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS FF ON ")
        strSQL.Append(" FF.IDFUENTEFINANCIAMIENTO = F.IDFUENTEFINANCIAMIENTO ")
        'strSQL.Append(" INNER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS S ")
        'strSQL.Append(" ON F.IDESTABLECIMIENTO = S.IDESTABLECIMIENTOSOLICITUD AND F.IDSOLICITUD = S.IDSOLICITUD ")
        strSQL.Append(" WHERE F.IDSOLICITUD = @IDSOLICITUD AND F.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND F.IDFUENTEFINANCIAMIENTO = @IDFUENTE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDFUENTE", SqlDbType.Int)
        args(2).Value = IDFUENTE

        Dim ds As String
        ds = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve las fuentes de financiamiento de un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns>Cadena de texto con las fuentes de financiamiento.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS</description></item>
    ''' <item><description>SAB_CAT_FUENTEFINANCIAMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  18/01/2007    Creado
    ''' </history> 
    Public Function DevolverFFContratos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("FFC.IDESTABLECIMIENTO, ")
        strSQL.Append("FFC.IDPROVEEDOR, ")
        strSQL.Append("FFC.IDCONTRATO, ")
        strSQL.Append("FFC.IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("F.NOMBRE ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS FFC ")
        strSQL.Append("INNER JOIN SAB_CAT_FUENTEFINANCIAMIENTOS F ")
        strSQL.Append("ON FFC.IDFUENTEFINANCIAMIENTO = F.IDFUENTEFINANCIAMIENTO ")
        strSQL.Append("WHERE (FFC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (FFC.IDPROVEEDOR = @IDPROVEEDOR) AND (FFC.IDCONTRATO = @IDCONTRATO) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim str As New Text.StringBuilder

        For Each dr As DataRow In ds.Tables(0).Rows
            str.Append(dr(4).ToString)
            str.Append(" ")
        Next

        Return str.ToString

    End Function

    ''' <summary>
    ''' Listado de fuentes de financiamientos por grupo
    ''' </summary>
    ''' <param name="IDGRUPO">Identificador del grupo de la fuente de financiamiento</param>
    ''' <returns>Listado de fuentes en formato de dataset</returns>
    Public Function RecuperarPorGrupo(ByVal IDGRUPO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("FF.*, ")
        strSQL.Append("isnull(GFF.DESCRIPCION, '') GRUPO, ")
        strSQL.Append("isnull(GFF.DESCRIPCION, '') + '/' + ff.NOMBRE AS GRUPOYFUENTE, ")
        strSQL.Append("case when FF.NOMBRE = 'GOES' then '_GOES' else FF.NOMBRE end NOMBREORDEN ")
        strSQL.Append("FROM SAB_CAT_FUENTEFINANCIAMIENTOS FF ")
        strSQL.Append("INNER JOIN SAB_CAT_GRUPOSFUENTEFINANCIAMIENTO GFF ")
        strSQL.Append("ON FF.IDGRUPO = GFF.IDGRUPO ")
        strSQL.Append("WHERE (FF.IDGRUPO = @IDGRUPO or @IDGRUPO = 0) ")
        strSQL.Append("ORDER BY NOMBREORDEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Valida el nombre de la fuente de financiamiento
    ''' </summary>
    ''' <param name="NOMBRE">Identificador del nombre de la fuente de financiamiento</param>
    ''' <param name="IDGRUPO">Identificador del grupo de la fuente de financiamiento</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento</param>
    ''' <returns>Valor entero</returns>

    Public Function ValidarNombreGrupo(ByVal NOMBRE As String, ByVal IDGRUPO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Int32) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_FUENTEFINANCIAMIENTOS ")
        strSQL.Append("WHERE NOMBRE = @NOMBRE ")
        strSQL.Append("AND IDGRUPO = @IDGRUPO ")
        strSQL.Append("AND (IDFUENTEFINANCIAMIENTO <> @IDFUENTEFINANCIAMIENTO OR @IDFUENTEFINANCIAMIENTO = 0) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(0).Value = NOMBRE
        args(1) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(1).Value = IDGRUPO
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Value = IDFUENTEFINANCIAMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

End Class
