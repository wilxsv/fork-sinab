Partial Public Class dbAJUSTE

    ''' <summary>
    ''' Valida si existe  ajuste asociado al detalle del inventario
    ''' </summary>
    ''' <param name="IDALMACEN"></param> 'identificador de almacen
    ''' <param name="IDINVENTARIO"></param> 'identificador de inventario
    ''' <param name="IDDETALLE"></param> 'identificador de detalle
    ''' <returns></returns>
    ''' un valor verdadero si existe
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_AJUSTE</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarExistenciaAjuste(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, Optional ByVal IDDETALLE As Int32 = 0) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_ALM_AJUSTE ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")
        If IDDETALLE <> 0 Then strSQL.Append("AND IDDETALLE = @IDDETALLE ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO
        args(2) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(2).Value = IDDETALLE

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

End Class
