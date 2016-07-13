Partial Public Class dbRESPONSABLEDISTRIBUCIONCONTRATO

    ''' <summary>
    ''' Devuelve un listado de las fuentes de financiamiento de un contrato específico
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">El ID del establecimiento.</param>
    ''' <param name="IDCONTRATO">El ID del contrato que se desea recuperar.</param>
    ''' <param name="IDPROVEEDOR">El ID del proveedor que se desea recuperar.</param>
    ''' <returns>Dataset con el listado de responsables de distribución.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATOS</description></item>
    ''' <item><description>SAB_CAT_RESPONSABLEDISTRIBUCION</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  05/01/2007    Creado
    ''' </history> 
    Public Function ObtenerResponsablesPorContratoDS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int64, ByVal IDCONTRATO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("RDC.IDESTABLECIMIENTO, ")
        strSQL.Append("RDC.IDPROVEEDOR, ")
        strSQL.Append("RDC.IDCONTRATO, ")
        strSQL.Append("RDC.IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("RD.NOMBRE, ")
        strSQL.Append("RD.NOMBRECORTO ")
        strSQL.Append("FROM SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO AS RDC ")
        strSQL.Append("INNER JOIN SAB_CAT_RESPONSABLEDISTRIBUCION AS RD ")
        strSQL.Append("ON RDC.IDRESPONSABLEDISTRIBUCION = RD.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("WHERE RDC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND RDC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND RDC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("ORDER BY RD.NOMBRE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Elimina todos los responsables de distribucion asociados a un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <returns>Valor numerico indicando el estado de la transacción</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  13/02/2007    Creado
    ''' </history> 
    Public Function EliminarAsociados(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO ")
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

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerResponsablesDistribucion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO, SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD, SAB_EST_SOLICITUDES.IDCLASESUMINISTRO, ")
        strSQL.Append(" SAB_EST_SOLICITUDES.IDDEPENDENCIASOLICITANTE ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDESPROCESOCOMPRAS INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDES ON SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDSOLICITUD = SAB_EST_SOLICITUDES.IDSOLICITUD AND ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTOSOLICITUD = SAB_EST_SOLICITUDES.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (SAB_EST_SOLICITUDESPROCESOCOMPRAS.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerResponsablesIngresados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append(" FROM SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ") AND (IDRESPONSABLEDISTRIBUCION = " & IDRESPONSABLEDISTRIBUCION & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerResponsablesDistribucion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT RD.NOMBRE ")
        strSQL.Append("FROM SAB_CAT_RESPONSABLEDISTRIBUCION RD ")
        strSQL.Append("INNER JOIN SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO RDC ")
        strSQL.Append("ON RD.IDRESPONSABLEDISTRIBUCION = RDC.IDRESPONSABLEDISTRIBUCION ")
        strSQL.Append("WHERE ")
        strSQL.Append("RDC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("RDC.IDPROVEEDOR = @IDPROVEEDOR AND ")
        strSQL.Append("RDC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("ORDER BY RD.NOMBRE ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim rd As String = String.Empty

        Try
            Do While dr.Read()
                If rd <> String.Empty Then rd += ", "
                rd += dr.Item(0)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return rd

    End Function

End Class
