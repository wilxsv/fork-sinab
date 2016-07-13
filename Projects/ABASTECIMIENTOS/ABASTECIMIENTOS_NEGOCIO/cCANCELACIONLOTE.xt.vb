Partial Public Class cCANCELACIONLOTE

    ''' <summary>
    ''' Devuelve la informaci�n de los lotes examinados por el laboratorio para un rengl�n especifico,
    ''' mostrando unicamente aquellos lotes que han sido cancelados.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato al que pertenece el rengl�n.</param>
    ''' <param name="RENGLON">N�mero del rengl�n seleccionado.</param>
    ''' <returns>Valor num�rico que indica si el lote se ha cancelado.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Jos� Alberto Ch�vez Loarca]  05/02/2007    Creado
    ''' </history> 
    Public Function ObtenerInformacionLoteCancelado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal LOTE As String) As Int16
        Return mDb.ObtenerInformacionLoteCancelado(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, LOTE)
    End Function

End Class
