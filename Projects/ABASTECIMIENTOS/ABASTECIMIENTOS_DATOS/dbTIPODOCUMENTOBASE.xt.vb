Partial Public Class dbTIPODOCUMENTOBASE

    Public Function BuscarTipoDocuentoBaseEnDocumentoBase(ByVal IDTIPODOCUMENTO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_DOCUMENTOSBASE ")
        strSQL.Append("WHERE IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(0).Value = IDTIPODOCUMENTO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    Public Function RecuperarListaPorProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32, ByVal IDTIPODOCUMENTOBASE() As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT TDB.IDTIPODOCUMENTOBASE, TDB.DESCRIPCION ")
        strSQL.Append("FROM SAB_CAT_TIPODOCUMENTOBASE TDB ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON TDB.IDTIPODOCUMENTOBASE = DB.IDTIPODOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_UACI_DOCUMENTOSPROCESOSCOMPRA DPC ")
        strSQL.Append("ON DB.IDDOCUMENTOBASE = DPC.IDDOCUMENTOBASE ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        If Not IsNothing(IDTIPODOCUMENTOBASE) Then
            For i As Integer = 0 To IDTIPODOCUMENTOBASE.Length - 1
                If i = 0 Then
                    strSQL.Append("AND TDB.IDTIPODOCUMENTOBASE IN ( ")
                End If
                strSQL.Append("@IDTIPODOCUMENTOBASE" + i.ToString)
                If i = IDTIPODOCUMENTOBASE.Length - 1 Then
                    strSQL.Append(") ")
                Else
                    strSQL.Append(", ")
                End If
            Next
        End If

        strSQL.Append("ORDER BY TDB.IDTIPODOCUMENTOBASE ")

        Dim length As Integer
        If Not IsNothing(IDTIPODOCUMENTOBASE) Then length = IDTIPODOCUMENTOBASE.Length

        Dim args(1 + length) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        If Not IsNothing(IDTIPODOCUMENTOBASE) Then
            For i As Integer = 0 To IDTIPODOCUMENTOBASE.Length - 1
                args(2 + i) = New SqlParameter("@IDTIPODOCUMENTOBASE" + i.ToString, SqlDbType.Int)
                args(2 + i).Value = IDTIPODOCUMENTOBASE(i)
            Next
        End If

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function RecuperarListaPorProcesoCompraRecTec(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32, ByVal IDTIPODOCUMENTOBASE() As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT grt.IDGRUPOREQ,grt.[NOMBRE] ")
        strSQL.Append("FROM SAB_CAT_TIPODOCUMENTOBASE TDB ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON TDB.IDTIPODOCUMENTOBASE = DB.IDTIPODOCUMENTOBASE ")
        strSQL.Append("INNER JOIN SAB_UACI_DOCUMENTOSPROCESOSCOMPRA DPC ")
        strSQL.Append("ON DB.IDDOCUMENTOBASE = DPC.IDDOCUMENTOBASE ")
        strSQL.Append("inner join SAB_CAT_GRUPOSREQTECNICOS grt on db.IDGRUPOREQTEC=grt.IDGRUPOREQ ")
        strSQL.Append("WHERE DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        If Not IsNothing(IDTIPODOCUMENTOBASE) Then
            For i As Integer = 0 To IDTIPODOCUMENTOBASE.Length - 1
                If i = 0 Then
                    strSQL.Append("AND TDB.IDTIPODOCUMENTOBASE IN ( ")
                End If
                strSQL.Append("@IDTIPODOCUMENTOBASE" + i.ToString)
                If i = IDTIPODOCUMENTOBASE.Length - 1 Then
                    strSQL.Append(") ")
                Else
                    strSQL.Append(", ")
                End If
            Next
        End If

        strSQL.Append("ORDER BY grt.[NOMBRE] ")

        Dim length As Integer
        If Not IsNothing(IDTIPODOCUMENTOBASE) Then length = IDTIPODOCUMENTOBASE.Length

        Dim args(1 + length) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA
        If Not IsNothing(IDTIPODOCUMENTOBASE) Then
            For i As Integer = 0 To IDTIPODOCUMENTOBASE.Length - 1
                args(2 + i) = New SqlParameter("@IDTIPODOCUMENTOBASE" + i.ToString, SqlDbType.Int)
                args(2 + i).Value = IDTIPODOCUMENTOBASE(i)
            Next
        End If
        Dim ds As New System.Data.DataSet("RECTEC")
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Dim fila As DataRow = ds.Tables(0).NewRow
        fila("IDGRUPOREQ") = "0"
        fila("NOMBRE") = "Todos"
        ds.Tables(0).Rows.Add(fila)
        Return ds

    End Function

End Class
