Partial Class cAJUSTE

    ''' <summary>
    ''' Valida si existe  ajuste asociado al detalle del inventario
    ''' </summary>
    ''' <param name="IDALMACEN"></param> 'identificador de almacen
    ''' <param name="IDINVENTARIO"></param> 'identificador de inventario
    ''' <param name="IDDETALLE"></param> 'identificador de detalle
    ''' <returns></returns>
    ''' un valor verdadero si existe
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarExistenciaAjuste(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, Optional ByVal IDDETALLE As Int32 = 0) As Boolean
        Return mDb.ValidarExistenciaAjuste(IDALMACEN, IDINVENTARIO, IDDETALLE)
    End Function

End Class
