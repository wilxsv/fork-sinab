Partial Public Class cCANCELACIONLOTE

    ''' <summary>
    ''' Devuelve la información de los lotes examinados por el laboratorio para un renglón especifico,
    ''' mostrando unicamente aquellos lotes que han sido cancelados.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato al que pertenece el renglón.</param>
    ''' <param name="RENGLON">Número del renglón seleccionado.</param>
    ''' <returns>Valor numérico que indica si el lote se ha cancelado.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  05/02/2007    Creado
    ''' </history> 
    Public Function ObtenerInformacionLoteCancelado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal LOTE As String) As Int16
        Return mDb.ObtenerInformacionLoteCancelado(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, LOTE)
    End Function

End Class
