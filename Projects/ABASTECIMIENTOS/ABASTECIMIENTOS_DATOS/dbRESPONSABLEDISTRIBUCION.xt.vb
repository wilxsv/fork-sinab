Partial Public Class dbRESPONSABLEDISTRIBUCION

    Public Function ObtenerDataSetListaResponsableDistribucion() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("R.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("R.IDESTABLECIMIENTO, ")
        strSQL.Append("R.NOMBRE, ")
        strSQL.Append("R.NOMBRECORTO, ")
        strSQL.Append("E.NOMBRE ESTABLECIMIENTO, ")
        strSQL.Append("R.IDDEPENDENCIA, ")
        strSQL.Append("D.NOMBRE DEPENDENCIA, ")
        strSQL.Append("R.AUUSUARIOCREACION, ")
        strSQL.Append("R.AUFECHACREACION, ")
        strSQL.Append("R.AUUSUARIOMODIFICACION, ")
        strSQL.Append("R.AUFECHAMODIFICACION, ")
        strSQL.Append("R.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_RESPONSABLEDISTRIBUCION R ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_DEPENDENCIAESTABLECIMIENTOS DE ")
        strSQL.Append("ON (R.IDESTABLECIMIENTO = DE.IDESTABLECIMIENTO ")
        strSQL.Append("AND R.IDDEPENDENCIA = DE.IDDEPENDENCIA) ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON DE.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("LEFT OUTER JOIN SAB_CAT_DEPENDENCIAS D ")
        strSQL.Append("ON DE.IDDEPENDENCIA = D.IDDEPENDENCIA ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function BuscarEstablecimientoDependencia(ByVal IDestablecimiento As Int32, ByVal IDdependencia As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_RESPONSABLEDISTRIBUCION ")
        strSQL.Append("WHERE IDDEPENDENCIA = @IDDEPENDENCIA ")
        strSQL.Append("AND IDESTABLECIMIENTO <> @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDestablecimiento
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDdependencia

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, False, True)

    End Function

    Public Function RecuperarOrdenada() As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("ORDER BY NOMBRE ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Devuelve los responsables de distribución de un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns>Cadena de texto con los responsables de distribución.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  18/01/2007    Creado
    ''' </history> 
    Public Function DevolverRDContratos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("RDC.IDESTABLECIMIENTO, ")
        strSQL.Append("RDC.IDPROVEEDOR, ")
        strSQL.Append("RDC.IDCONTRATO, ")
        strSQL.Append("RDC.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("R.NOMBRE ")
        strSQL.Append("FROM ")
        strSQL.Append("SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO RDC ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION R ")
        strSQL.Append("ON RDC.IDRESPONSABLEDISTRIBUCION = R.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("WHERE (RDC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (RDC.IDPROVEEDOR = @IDPROVEEDOR) AND (RDC.IDCONTRATO = @IDCONTRATO) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim dr As DataRow = ds.Tables(0).NewRow

        Dim str As New Text.StringBuilder
        For Each dr In ds.Tables(0).Rows
            str.Append(dr(4).ToString)
            str.Append(" ")
        Next

        Return str.ToString

    End Function

End Class
