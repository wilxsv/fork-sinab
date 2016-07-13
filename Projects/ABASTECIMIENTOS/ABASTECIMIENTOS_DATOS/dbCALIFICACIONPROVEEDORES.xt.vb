Partial Public Class dbCALIFICACIONPROVEEDORES

    Public Function obtenerContratosProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal DIASATRASO As Integer, ByVal RECHAZOS As Integer, ByVal FECHAINICIO As String, ByVal FECHAFIN As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_CONTRATOS.NUMEROCONTRATO, SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA, ")
        strSQL.Append("  SAB_UACI_CONTRATOS.FECHAGENERACION, '" & DIASATRASO & "' AS 'DiasAtraso', ")
        strSQL.Append("  (SELECT DESCRIPCION ")
        strSQL.Append("   FROM SAB_CAT_CALIFICACIONPROVEEDORES ")
        strSQL.Append("   WHERE (" & DIASATRASO & " BETWEEN PERIODOINICIO AND PERIODOFIN)) AS 'Calificacion1', '" & RECHAZOS & "' AS 'Rechazos', ")
        strSQL.Append("  (SELECT DESCRIPCION ")
        strSQL.Append("  FROM SAB_CAT_CALIFICACIONCALIDADPROVEEDORES ")
        strSQL.Append("  WHERE (" & RECHAZOS & " BETWEEN CANTIDADINICIO AND CANTIDADFIN)) AS 'Calificacion2', SAB_UACI_CONTRATOS.IDPROVEEDOR, ")
        strSQL.Append("   SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS INNER JOIN ")
        strSQL.Append("  SAB_UACI_CONTRATOSPROCESOCOMPRA ON ")
        strSQL.Append("  SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO AND ")
        strSQL.Append("  SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROVEEDOR AND ")
        strSQL.Append("  SAB_UACI_CONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOSPROCESOCOMPRA.IDCONTRATO INNER JOIN ")
        strSQL.Append("  SAB_UACI_PROCESOCOMPRAS ON ")
        strSQL.Append("  SAB_UACI_CONTRATOSPROCESOCOMPRA.IDPROCESOCOMPRA = SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA AND ")
        strSQL.Append("  SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO = SAB_UACI_PROCESOCOMPRAS.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (SAB_UACI_CONTRATOSPROCESOCOMPRA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ") ")
        strSQL.Append(" AND (SAB_UACI_CONTRATOS.FECHAGENERACION BETWEEN CONVERT(DATETIME, '" & FECHAINICIO & "', 103) AND CONVERT(DATETIME, '" & FECHAFIN & "', 103))")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

End Class
