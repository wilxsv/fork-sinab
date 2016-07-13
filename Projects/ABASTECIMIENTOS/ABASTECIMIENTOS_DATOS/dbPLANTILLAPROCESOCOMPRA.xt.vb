Imports System.Text

Partial Public Class dbPLANTILLAPROCESOCOMPRA

    Public Function obtenerPlantillaProcesoCompra(ByVal IDTIPOCOMPRA As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDPLANTILLA, NOMBRE, IDTIPOCOMPRA ")
        strSQL.Append(" FROM SAB_CAT_PLANTILLAS ")
        strSQL.Append(" WHERE (IDTIPOCOMPRA = @IDTIPOCOMPRA) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOCOMPRA", SqlDbType.TinyInt)
        args(0).Value = IDTIPOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function obtenerPlantillaProcesoCompra(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer)

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT SAB_UACI_PLANTILLAPROCESOCOMPRA.IDESTABLECIMIENTO, SAB_UACI_PLANTILLAPROCESOCOMPRA.IDPROCESOCOMPRA, ")
        strSQL.Append(" SAB_UACI_PLANTILLAPROCESOCOMPRA.IDPLANTILLA, SAB_CAT_PLANTILLAS.CODIGOFUENTE, SAB_CAT_PLANTILLAS.NOMBRE ")
        strSQL.Append(" FROM SAB_UACI_PLANTILLAPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_CAT_PLANTILLAS ON SAB_UACI_PLANTILLAPROCESOCOMPRA.IDPLANTILLA = SAB_CAT_PLANTILLAS.IDPLANTILLA ")
        strSQL.Append(" WHERE (SAB_UACI_PLANTILLAPROCESOCOMPRA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_PLANTILLAPROCESOCOMPRA.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

End Class
