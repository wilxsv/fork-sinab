Partial Public Class dbDOCUMENTOSBASEPLANTILLA

#Region " Métodos Agregados "

    Public Function ObtenerDataSetDocumentosPlantilla(ByVal IDTIPODOCUMENTOBASE As Int16, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DPC.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.IDTIPODOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION ")
        strSQL.Append("FROM SAB_UACI_DOCUMENTOSPROCESOSCOMPRA DPC ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON ")
        strSQL.Append("DPC.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("WHERE ")
        strSQL.Append("(DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("AND (DB.IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPODOCUMENTOBASE", SqlDbType.BigInt)
        args(1).Value = IDTIPODOCUMENTOBASE
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(2).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerDataSetDocumentosPlantilla2(ByVal IDTIPODOCUMENTOBASE As Int16, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DPC.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.IDTIPODOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION, ")
        strSQL.Append("DB.IDGRUPOREQTEC ")
        strSQL.Append("FROM SAB_UACI_DOCUMENTOSPROCESOSCOMPRA DPC ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON ")
        strSQL.Append("DPC.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("WHERE ")
        strSQL.Append("(DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("AND (DB.IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPODOCUMENTOBASE", SqlDbType.BigInt)
        args(1).Value = IDTIPODOCUMENTOBASE
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(2).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
#End Region

End Class
