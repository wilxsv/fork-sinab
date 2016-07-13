Partial Public Class dbESTADOS

    ''' <summary>
    ''' Datset de estados de la solicitud de compras 
    ''' </summary>
    ''' <param name="operador"></param> identificador de operador de comparacion
    ''' <param name="idestado"></param> identificador de estado
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>FROM SAB_CAT_ESTADOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetEstados(ByVal operador As String, ByVal idestado As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTADO OPER @IDESTADO ")
        strSQL.Replace("OPER", operador)

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(0).Value = idestado

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

End Class
