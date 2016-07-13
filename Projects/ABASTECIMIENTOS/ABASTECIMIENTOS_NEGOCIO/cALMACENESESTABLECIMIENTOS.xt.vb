Partial Public Class cALMACENESESTABLECIMIENTOS

#Region " METODOS AGREGADOS "

    Public Function ObtenerAlmacenXEstablecimiento(ByVal BIDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerAlmacenXEstablecimiento(BIDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtiene un listado de todos aquellos almacenes asociados a un establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    '''  devuelve un dataset con la informacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerTodosAlmacenEstablecimiento(ByVal IDESTABLECIMIENTO As Int32, Optional ByVal ESFARMACIA As Int32 = 0) As DataSet
        Try
            Return mDb.ObtenerTodosAlmacenEstablecimiento(IDESTABLECIMIENTO, ESFARMACIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtiene un listado de todos aquellas farmacias asociadas a un establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    '''  devuelve un dataset con la informacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerTodosFarmaciasEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerTodosFarmaciasEstablecimiento(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetListaAlmacenesEstablecimientos() As DataSet
        Try
            Return mDb.ObtenerDataSetListaAlmacenesEstablecimientos()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarEstablecimientoAlmacen(ByVal IDESTABLECIMIENTO As Int32, ByVal IDALMACEN As Int32) As Boolean
        Try
            Return mDb.BuscarEstablecimientoAlmacen(IDESTABLECIMIENTO, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarAlmacen(ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            Return mDb.BuscarAlmacen(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function BuscarAlmacenFarmacia(ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            Return mDb.BuscarAlmacenFarmacia(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function BuscarEstablecimientoAlmacenPrincipal(ByVal IDALMACEN As Int32) As Integer
        Try
            Return mDb.BuscarEstablecimientoAlmacenPrincipal(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve un listado de los almacenes de un establecimiento.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento(Filtro).</param>
    ''' <returns>Dataset con el listado de almacenes.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  09/12/2006    Creado
    ''' </history>
    Public Function ObtenerAlmacenesPrincipales(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerAlmacenesPrincipales(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
