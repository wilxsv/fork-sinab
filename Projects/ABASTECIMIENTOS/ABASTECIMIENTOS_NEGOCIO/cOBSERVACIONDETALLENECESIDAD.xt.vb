Partial Public Class cOBSERVACIONDETALLENECESIDAD

#Region "metodos adicionales"

    ' Autor: Henry Zavaleta
    '-------------------------------------------------------------------------------------------------------------------------
    ' Esta función devuelve el listado de observaciones a un programa de compra para dicho establecimiento
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function Obtenerobservaciones(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64) As DataSet
        Try
            Return mDb.ObtenerListadeObservaciones(IDESTABLECIMIENTO, IDNECESIDAD, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Verifica la existencia de observaciones para la necesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> identificador de la necesidad
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ExistenObservacionesNecesidad(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int32) As Boolean
        Try
            Return mDb.ExistenObservacionesNecesidad(IDESTABLECIMIENTO, IDNECESIDAD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Verifica si tienen existencia los productos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDNECESIDAD"></param> identificador de necesidad
    ''' <param name="IDPRODUCTO"></param> identificador de producto
    ''' <returns>
    ''' verdadero si existen observaciones en producto
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ExistenObservacionesProductos(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int32, ByVal IDPRODUCTO As Int32) As Boolean
        Try
            Return mDb.ExistenObservacionesProducto(IDESTABLECIMIENTO, IDNECESIDAD, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Dataset con la informacion de las observaciones de l anecesidad
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDNECESIDAD"></param> identificador de la necesidad
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DsObservacionesNecesidades(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, Optional ByVal IDPRODUCTO As Int64 = 0) As DataSet
        Try
            Return mDb.dstObservacionesNecesidades(IDESTABLECIMIENTO, IDNECESIDAD, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
