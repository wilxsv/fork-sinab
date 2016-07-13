Partial Class cESTADOS

    ''' <summary>
    ''' Datset de estados de la solicitud de compras 
    ''' </summary>
    ''' <param name="operador"></param> identificador de operador de comparacion
    ''' <param name="idestado"></param> identificador de estado
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerDataSetEstados(ByVal operador As String, ByVal idestado As Integer) As DataSet
        Return mDb.ObtenerDataSetEstados(operador, idestado)
    End Function

End Class
