Partial Public Class dbDOCUMENTOSBASE

#Region " Métodos Agregados "

    Public Function ObtenerDataSetTipoDocumento(ByVal IDTIPODOCUMENTOBASE As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        'todo: REVISAR ESTE WHERE QUE POR AHORITA TIENE FIJO ESTE FILTRO
        strSQL.Append(" where IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE and IDDOCUMENTOBASE > 9997")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPODOCUMENTOBASE", SqlDbType.Int)
        args(0).Value = IDTIPODOCUMENTOBASE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerDataSetTipoDocumento2(ByVal IDTIPODOCUMENTOBASE As Int64, ByVal idgruporeqdoc As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" where IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE AND IDGRUPOREQTEC=" & idgruporeqdoc)

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPODOCUMENTOBASE", SqlDbType.Int)
        args(0).Value = IDTIPODOCUMENTOBASE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerDataSetXProcesoCompra(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Integer, ByVal IDTIPODOCUMENTOBASE As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DB.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION ")
        strSQL.Append("FROM SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("INNER JOIN SAB_UACI_DOCUMENTOSPROCESOSCOMPRA DPC ")
        strSQL.Append("ON DB.IDDOCUMENTOBASE = DPC.IDDOCUMENTOBASE ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DB.IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE ")
        'strSQL.Append("AND DB.IDTIPODOCUMENTOBASE <> 3 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDTIPODOCUMENTOBASE", SqlDbType.Int)
        args(2).Value = IDTIPODOCUMENTOBASE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetXProcesoCompra2(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE, SAB_CAT_DOCUMENTOSBASE.IDTIPODOCUMENTOBASE, SAB_CAT_DOCUMENTOSBASE.DESCRIPCION, ")
        strSQL.Append(" SAB_CAT_DOCUMENTOSBASE.AUUSUARIOCREACION, SAB_CAT_DOCUMENTOSBASE.AUFECHACREACION, SAB_CAT_DOCUMENTOSBASE.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" SAB_CAT_DOCUMENTOSBASE.AUFECHAMODIFICACION, SAB_CAT_DOCUMENTOSBASE.ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_DOCUMENTOSPROCESOSCOMPRA INNER JOIN ")
        strSQL.Append("       SAB_CAT_DOCUMENTOSBASE ON SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.IDDOCUMENTOBASE = SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE ")
        strSQL.Append(" WHERE (SAB_CAT_DOCUMENTOSBASE.IDTIPODOCUMENTOBASE = 3) AND (SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND ")
        strSQL.Append("       (SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (SAB_CAT_DOCUMENTOSBASE.ESTASINCRONIZADA = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetXProcesoCompra3(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE, SAB_CAT_DOCUMENTOSBASE.IDTIPODOCUMENTOBASE, SAB_CAT_DOCUMENTOSBASE.DESCRIPCION, ")
        strSQL.Append(" SAB_CAT_DOCUMENTOSBASE.AUUSUARIOCREACION, SAB_CAT_DOCUMENTOSBASE.AUFECHACREACION, SAB_CAT_DOCUMENTOSBASE.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" SAB_CAT_DOCUMENTOSBASE.AUFECHAMODIFICACION, SAB_CAT_DOCUMENTOSBASE.ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_DOCUMENTOSPROCESOSCOMPRA INNER JOIN ")
        strSQL.Append("       SAB_CAT_DOCUMENTOSBASE ON SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.IDDOCUMENTOBASE = SAB_CAT_DOCUMENTOSBASE.IDDOCUMENTOBASE ")
        strSQL.Append(" WHERE (SAB_CAT_DOCUMENTOSBASE.IDTIPODOCUMENTOBASE = 3) AND (SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND ")
        strSQL.Append("       (SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (SAB_CAT_DOCUMENTOSBASE.ESTASINCRONIZADA = 1) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDsListaDocumentoBase() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DB.IDTIPODOCUMENTOBASE, DB.IDDOCUMENTOBASE, DB.DESCRIPCION, DB.AUUSUARIOCREACION, DB.AUFECHACREACION, ")
        strSQL.Append("DB.AUUSUARIOMODIFICACION, DB.AUFECHAMODIFICACION, DB.ESTASINCRONIZADA, TB.IDTIPODOCUMENTOBASE AS CODTIPO, ")
        strSQL.Append("TB.DESCRIPCION AS TIPODOCUMENTO ")
        strSQL.Append("FROM SAB_CAT_DOCUMENTOSBASE AS DB INNER JOIN ")
        strSQL.Append("SAB_CAT_TIPODOCUMENTOBASE AS TB ON DB.IDTIPODOCUMENTOBASE = TB.IDTIPODOCUMENTOBASE ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDocumentosProcesoCompra(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDTIPODOCUMENTOBASE As Integer, ByVal ENTREGADO1 As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DB.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION, ")
        strSQL.Append("TDB.DESCRIPCION TIPODOCUMENTOBASE, ")
        strSQL.Append("isnull(DO.ENTREGADO1, 0) ENTREGADO1 ")
        strSQL.Append("FROM SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOBASE TDB ")
        strSQL.Append("ON DB.IDTIPODOCUMENTOBASE = TDB.IDTIPODOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_UACI_DOCUMENTOSPROCESOSCOMPRA DPC ")
        strSQL.Append("ON DB.IDDOCUMENTOBASE = DPC.IDDOCUMENTOBASE ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_DOCUMENTOSOFERTA DO ")
        strSQL.Append("ON DO.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND DO.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DB.IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE ")
        strSQL.Append("AND ((DO.ENTREGADO1 = @ENTREGADO1 OR @ENTREGADO1 = 0) OR DO.ENTREGADO1 is null) ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT ")
        strSQL.Append("DB.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION, ")
        strSQL.Append("TDB.DESCRIPCION TIPODOCUMENTOBASE, ")
        strSQL.Append("DO.ENTREGADO1 ")
        strSQL.Append("FROM SAB_UACI_DOCUMENTOSOFERTA DO ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON DO.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOBASE TDB ")
        strSQL.Append("ON DB.IDTIPODOCUMENTOBASE = TDB.IDTIPODOCUMENTOBASE ")
        strSQL.Append("WHERE DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND DB.IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE ")
        strSQL.Append("AND (DO.ENTREGADO1 = @ENTREGADO1 OR @ENTREGADO1 = 0) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDTIPODOCUMENTOBASE", SqlDbType.Int)
        args(3).Value = IDTIPODOCUMENTOBASE
        args(4) = New SqlParameter("@ENTREGADO1", SqlDbType.Int)
        args(4).Value = ENTREGADO1

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDocumentosProcesoCompraRenglon(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal IDTIPODOCUMENTOBASE As Integer, ByVal ENTREGADO1 As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DB.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION, ")
        strSQL.Append("TDB.DESCRIPCION TIPODOCUMENTOBASE, ")
        strSQL.Append("isnull(ER.ENTREGADO1, 0) ENTREGADO1 ")

        strSQL.Append("FROM SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOBASE TDB ")
        strSQL.Append("ON DB.IDTIPODOCUMENTOBASE = TDB.IDTIPODOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_UACI_DOCUMENTOSPROCESOSCOMPRA DPC ")
        strSQL.Append("ON DB.IDDOCUMENTOBASE = DPC.IDDOCUMENTOBASE ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_EXAMENRENGLON ER ")
        strSQL.Append("ON ER.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND ER.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
        strSQL.Append("AND ER.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND ER.IDDETALLE = @IDDETALLE ")
        strSQL.Append("AND ER.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")

        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DB.IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE ")
        strSQL.Append("AND ((ER.ENTREGADO1 = @ENTREGADO1 OR @ENTREGADO1 = 0) OR ER.ENTREGADO1 is null) ")

        strSQL.Append("UNION ")

        strSQL.Append("SELECT ")
        strSQL.Append("DB.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION, ")
        strSQL.Append("TDB.DESCRIPCION TIPODOCUMENTOBASE, ")
        strSQL.Append("ER.ENTREGADO1 ")

        strSQL.Append("FROM SAB_UACI_EXAMENRENGLON ER ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON ER.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOBASE TDB ")
        strSQL.Append("ON DB.IDTIPODOCUMENTOBASE = TDB.IDTIPODOCUMENTOBASE ")

        strSQL.Append("WHERE ER.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND ER.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND ER.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND ER.IDDETALLE = @IDDETALLE ")
        strSQL.Append("AND DB.IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE ")
        strSQL.Append("AND (ER.ENTREGADO1 = @ENTREGADO1 OR @ENTREGADO1 = 0) ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE
        args(4) = New SqlParameter("@IDTIPODOCUMENTOBASE", SqlDbType.Int)
        args(4).Value = IDTIPODOCUMENTOBASE
        args(5) = New SqlParameter("@ENTREGADO1", SqlDbType.Int)
        args(5).Value = ENTREGADO1

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerDocumentosProcesoCompraRenglonM(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal IDTIPODOCUMENTOBASE As Integer, ByVal ENTREGADO1 As Integer, ByVal idproducto As Integer, ByVal IDGRUPOREQTEC As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DB.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION, ")
        'strSQL.Append("TDB.DESCRIPCION TIPODOCUMENTOBASE, ")
        strSQL.Append("GRT.NOMBRE TIPODOCUMENTOBASE, ")
        strSQL.Append("isnull(ER.ENTREGADO1, 0) ENTREGADO1 ")

        strSQL.Append("FROM SAB_CAT_DOCUMENTOSBASE DB ")

        'strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOBASE TDB ")
        'strSQL.Append("ON DB.IDTIPODOCUMENTOBASE = TDB.IDTIPODOCUMENTOBASE ")

        strSQL.Append("INNER JOIN SAB_UACI_DOCUMENTOSPROCESOSCOMPRA DPC ")
        strSQL.Append("ON DB.IDDOCUMENTOBASE = DPC.IDDOCUMENTOBASE ")

        strSQL.Append("INNER JOIN SAB_CAT_GRUPOSREQTECNICOS GRT ")
        strSQL.Append("ON GRT.IDGRUPOREQ = DB.IDGRUPOREQTEC ")

        strSQL.Append("INNER JOIN SAB_UACI_GRUPOREQTEC_PRODUCTOS GP  ")
        strSQL.Append("ON GP.IDGRUPOREQ = GRT.IDGRUPOREQ ")
        strSQL.Append("AND GP.IDPRODUCTO = @IDPRODUCTO ")

        strSQL.Append("LEFT OUTER JOIN SAB_UACI_EXAMENRENGLON ER ")
        strSQL.Append("ON ER.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND ER.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
        strSQL.Append("AND ER.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND ER.IDDETALLE = @IDDETALLE ")
        strSQL.Append("AND ER.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")

        'strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEOFERTA DO  ")
        'strSQL.Append("ON DO.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
        'strSQL.Append("AND DO.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
        'strSQL.Append("AND DO.IDPROVEEDOR = @IDPROVEEDOR ")
        'strSQL.Append("AND DO.IDDETALLE = @IDDETALLE ")

        'strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPCO  ")
        'strSQL.Append("ON DPCO.IDESTABLECIMIENTO = DPC.IDESTABLECIMIENTO ")
        'strSQL.Append("AND DPCO.IDPROCESOCOMPRA = DPC.IDPROCESOCOMPRA ")
        'strSQL.Append("AND DPCO.RENGLON = DO.RENGLON ")



        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND DB.IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE ")
        strSQL.Append("AND ((ER.ENTREGADO1 = @ENTREGADO1 OR @ENTREGADO1 = 0) OR ER.ENTREGADO1 is null) ")
        strSQL.Append("AND (db.IDGRUPOREQTEC = @IDGRUPOREQTEC or @IDGRUPOREQTEC=0)")

        strSQL.Append("UNION ")

        strSQL.Append("SELECT ")
        strSQL.Append("DB.IDDOCUMENTOBASE, ")
        strSQL.Append("DB.DESCRIPCION, ")
        'strSQL.Append("TDB.DESCRIPCION TIPODOCUMENTOBASE, ")
        strSQL.Append("GRT.NOMBRE TIPODOCUMENTOBASE, ")
        strSQL.Append("ER.ENTREGADO1 ")

        strSQL.Append("FROM SAB_UACI_EXAMENRENGLON ER ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON ER.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        'strSQL.Append("INNER JOIN SAB_CAT_TIPODOCUMENTOBASE TDB ")
        'strSQL.Append("ON DB.IDTIPODOCUMENTOBASE = TDB.IDTIPODOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_CAT_GRUPOSREQTECNICOS GRT ")
        strSQL.Append("ON GRT.IDGRUPOREQ = DB.IDGRUPOREQTEC ")

        strSQL.Append("INNER JOIN SAB_UACI_GRUPOREQTEC_PRODUCTOS GP  ")
        strSQL.Append("ON GP.IDGRUPOREQ = GRT.IDGRUPOREQ ")
        strSQL.Append("AND GP.IDPRODUCTO = @IDPRODUCTO ")

        'strSQL.Append("INNER JOIN SAB_UACI_DETALLEOFERTA DO  ")
        'strSQL.Append("ON DO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        'strSQL.Append("AND DO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        'strSQL.Append("AND DO.IDPROVEEDOR = @IDPROVEEDOR ")
        'strSQL.Append("AND DO.IDDETALLE = @IDDETALLE ")

        'strSQL.Append("INNER JOIN SAB_UACI_DETALLEPROCESOCOMPRA DPCO  ")
        'strSQL.Append("ON DPCO.IDESTABLECIMIENTO = DO.IDESTABLECIMIENTO ")
        'strSQL.Append("AND DPCO.IDPROCESOCOMPRA = DO.IDPROCESOCOMPRA ")
        'strSQL.Append("AND DPCO.RENGLON = DO.RENGLON ")

        strSQL.Append("WHERE ER.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND ER.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND ER.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND ER.IDDETALLE = @IDDETALLE ")
        strSQL.Append("AND DB.IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE ")
        strSQL.Append("AND (db.IDGRUPOREQTEC = @IDGRUPOREQTEC or @IDGRUPOREQTEC=0)")
        strSQL.Append("AND (ER.ENTREGADO1 = @ENTREGADO1 OR @ENTREGADO1 = 0) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(3).Value = IDDETALLE
        args(4) = New SqlParameter("@IDTIPODOCUMENTOBASE", SqlDbType.Int)
        args(4).Value = IDTIPODOCUMENTOBASE
        args(5) = New SqlParameter("@ENTREGADO1", SqlDbType.Int)
        args(5).Value = ENTREGADO1
        args(6) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(6).Value = idproducto
        args(7) = New SqlParameter("@IDGRUPOREQTEC", SqlDbType.Int)
        args(7).Value = IDGRUPOREQTEC

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
#End Region

End Class
