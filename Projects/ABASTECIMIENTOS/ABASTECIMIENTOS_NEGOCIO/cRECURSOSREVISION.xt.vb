Partial Public Class cRECURSOSREVISION

#Region " Metodos Agregados "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function obtenerDatasetProveedores(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtenerDatasetProveedores(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function obtenerDatasetRecursos(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.obtenerDatasetRecursos(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function RptobtenerDatasetRecursos(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.RptobtenerDatasetRecursos(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Determina si existen recursos de revisión admitidos para un proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerRecursosDeRevision(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer
        Try
            Return mDb.ObtenerRecursosDeRevision(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Determina si se han presentado recursos de revisión para un proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ExistenRecursos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer
        Try
            Return mDb.ExistenRecursos(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerRenglonesAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerRenglonesAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
