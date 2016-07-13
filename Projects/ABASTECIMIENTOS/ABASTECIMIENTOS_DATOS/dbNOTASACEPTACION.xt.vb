Partial Public Class dbNOTASACEPTACION

#Region " Metodos Agregados "

    ''' <summary>
    ''' Determina si faltan notas de aceptación por parte de alguno de los proveedores adjudicados.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_ADJUDICACION</item>
    ''' <item>SAB_UACI_NOTASACEPTACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function VerificarRecepcionNotasAceptacion(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("((SELECT count(DISTINCT IDPROVEEDOR) ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("WHERE A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND A.CANTIDADADJUDICADA > 0 ")
        strSQL.Append("GROUP BY IDPROCESOCOMPRA, IDESTABLECIMIENTO) ")
        strSQL.Append("- ")
        strSQL.Append("(SELECT count(IDPROVEEDOR) ")
        strSQL.Append("FROM SAB_UACI_NOTASACEPTACION NA ")
        strSQL.Append("WHERE NA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND NA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA)) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
