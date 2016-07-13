Partial Public Class cDETALLEENTREGASPROCESOCOMPRA

#Region " METODOS AGREGADOS "

    ''' <summary>
    ''' Se utiliza para validar si existe el correlativo del detalle de la entrega.
    ''' </summary>
    ''' <param name="BIDPROCESOCOMPRA"></param>
    ''' <param name="BIDESTABLECIMIENTO"></param>
    ''' <param name="BIDENTREGA"></param>
    ''' <param name="BIDDETALLE"></param>
    ''' <returns>Boolean.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    04/12/06    Creado
    ''' </history>
    Public Function ValidarIDDETALLEENTREGA(ByVal BIDPROCESOCOMPRA As Int64, ByVal BIDESTABLECIMIENTO As Int32, ByVal BIDENTREGA As Int16, ByVal BIDDETALLE As Int16) As Boolean
        Try
            Return mDb.ValidarIDDETALLEENTREGA(BIDPROCESOCOMPRA, BIDESTABLECIMIENTO, BIDENTREGA, BIDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Esta funcion se utiliza para poder agregar una fila al detalle de las entregas del proceso de compras.
    ''' </summary>
    ''' <param name="aEntidad"></param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    20/11/2006    Creado
    ''' </history>
    Public Function AgregarDETALLEENTREGA(ByVal aEntidad As DETALLEENTREGASPROCESOCOMPRA) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Devuelve las entregas solicitadas para un renglón determinado.
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerEntregasPorRenglonProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal RENGLON As Int32) As DataSet
        Try
            Return mDb.ObtenerEntregasPorRenglonProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' yessenia
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA"></param>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDENTREGA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerDetalledeEntregasProcesoCompra(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDENTREGA As Int32)
        Return mDb.ObtenerDetalledeEntregasProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDENTREGA)
    End Function

#End Region

End Class
