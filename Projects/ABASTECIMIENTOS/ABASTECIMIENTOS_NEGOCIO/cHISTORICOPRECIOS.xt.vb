Partial Public Class cHISTORICOPRECIOS

#Region " Metodos agregados "

    ''' <summary>
    ''' Recupera el historico de precios de un producto.
    ''' </summary>
    ''' <param name="BIDPRODUCTO">Identificador del producto.</param>
    ''' <returns>Dataset con la información del historial de precios</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_HISTORICOPRECIOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  25/09/2006    Creado
    ''' </history>
    Public Function ObtenerHistorialProducto(ByVal BIDPRODUCTO As Int64) As DataSet
        Try
            Return mDb.ObtenerHistorialProducto(BIDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Registra los precios de los productos adjudicados en un proceso de compra dado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="FECHAPRECIO">Fecha histórica en la que se registran los precios.</param>
    ''' <param name="USUARIOCREACION">Usuario que realiza la actualización.</param>
    ''' <param name="FECHACREACION">Fecha en la que se realiza la actualización.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function RegistrarPreciosHistoricos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal FECHAPRECIO As DateTime, ByVal USUARIOCREACION As String, ByVal FECHACREACION As DateTime) As Integer
        Try
            Return mDb.RegistrarPreciosHistoricos(IDESTABLECIMIENTO, IDPROCESOCOMPRA, FECHAPRECIO, USUARIOCREACION, FECHACREACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
