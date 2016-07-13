Partial Public Class dbALTERNATIVASPRODUCTO

    ' Autor: José Chávez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Funcion utilizada para obtener las alternativas de un producto
    ' Creación: 14/12/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerDsAlternativas(ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ' Autor: José Chávez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Funcion utilizada para verificar si un producto es alternativa de otro
    ' Creación: 14/12/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerDsAlternativasDe(ByVal IDALTERNATIVA As Int64) As Int64

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDALTERNATIVA = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDALTERNATIVA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        Else
            Return ds.Tables(0).Rows(0).Item("IDPRODUCTO")
        End If

    End Function

End Class
