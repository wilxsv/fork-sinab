Partial Public Class dbTIPODOCUMENTOCONTRATO

    ''' <summary>
    ''' Devuelve la lista de los tipos de documentos relacionados a las compras filtrados por el campo APLICASOLOALMACEN.
    ''' </summary>
    ''' <param name="CLASIFICACION">Indica el tipo de documento a mostrar.</param>
    ''' <returns>Dataset con la lista de documentos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_TIPODOCUMENTOSCONTRATOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  08/02/2007    Creado
    ''' </history> 
    Public Function ObtenerTipoDocumentoFiltrado(ByVal CLASIFICACION As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE APLICASOLOALMACEN = @CLASIFICACION ")
        strSQL.Append("ORDER BY DESCRIPCION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@CLASIFICACION", SqlDbType.Int)
        args(0).Value = CLASIFICACION

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la la información del tipo de documento.
    ''' </summary>
    ''' <param name="IDTIPODOCUMENTO">Indica el tipo de documento a mostrar.</param>
    ''' <returns>Dataset con la lista de documentos.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_TIPODOCUMENTOSCONTRATOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  Creado
    ''' </history> 
    Public Function ObtenerTipoDocumentoPorID(ByVal IDTIPODOCUMENTO As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)

        strSQL.Append("WHERE IDTIPODOCUMENTO = @IDTIPODOCUMENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(0).Value = IDTIPODOCUMENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function RecuperarOrdenada() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("with t as ")
        strSQL.Append("( ")
        strSQL.Append("select ")
        strSQL.Append("DESCRIPCION ")
        strSQL.Append("FROM SAB_CAT_TIPODOCUMENTOCONTRATO ")
        strSQL.Append("group by DESCRIPCION ")
        strSQL.Append("having count(DESCRIPCION) > 1 ")
        strSQL.Append(") ")
        strSQL.Append("SELECT ")
        strSQL.Append("TDC.IDTIPODOCUMENTO, ")
        strSQL.Append("case when t.DESCRIPCION is null then TDC.DESCRIPCION ")
        strSQL.Append("else ")
        strSQL.Append("TDC.DESCRIPCION + case when TDC.APLICASOLOALMACEN = 1 then ' (Almacén) ' else '' end ")
        strSQL.Append("end DESCRIPCION, ")
        strSQL.Append("TDC.APLICASOLOALMACEN, ")
        strSQL.Append("TDC.AUUSUARIOCREACION, ")
        strSQL.Append("TDC.AUFECHACREACION, ")
        strSQL.Append("TDC.AUUSUARIOMODIFICACION, ")
        strSQL.Append("TDC.AUFECHAMODIFICACION, ")
        strSQL.Append("TDC.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_TIPODOCUMENTOCONTRATO TDC ")
        strSQL.Append("left outer join t ")
        strSQL.Append("on TDC.DESCRIPCION = t.DESCRIPCION ")
        strSQL.Append("ORDER BY TDC.DESCRIPCION ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

End Class
