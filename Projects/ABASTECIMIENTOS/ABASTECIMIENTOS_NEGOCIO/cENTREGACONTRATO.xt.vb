Partial Public Class cENTREGACONTRATO

    'JOSE CHAVEZ
    Public Function EliminarEntregasContrato(ByVal aEntidad As entidadBase) As Integer
        Try
            Return mDb.EliminarEntregasContrato(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener el numero de entregas de un contrato
    ''' </summary>
    ''' <param name="IDCONTRATO"></param> 'identificador de contrat
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <returns>
    ''' numero entero de las entregas de un contrato
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerNumeroEntregas(ByVal IDCONTRATO As Int64, ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            Return mDb.ObtenerNumeroEntregas(IDCONTRATO, IDESTABLECIMIENTO)
        Catch ex As Exception
        End Try
    End Function

    'JOSE CHAVEZ
    Public Function EliminarEntregasContratoTodas(ByVal aEntidad As entidadBase) As Integer
        Try
            Return mDb.EliminarEntregasContratoTodas(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerPlazoEntregaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obtenerPlazoEntregaContrato(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerEntregasProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obtenerEntregasProveedor(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerEntregasProveedorAmpliacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obtenerEntregasProveedorAmpliacion(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarHabilitados(ByVal aEntidad As entidadBase) As Integer
        Try
            Return mDb.ActualizarHabilitados(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtieneSumaCantidadEntregada(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As Decimal
        Try
            Return mDb.obtieneSumaCantidadEntregada(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ValidarProductoEntregado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal IDDETALLE As Integer) As Integer
        Try
            Return mDb.validaCantidadEntregada(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtieneEntregasAmpliacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.obtieneEntregasAmpliacion(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ValidarEntrega(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal ENTREGA As Integer) As Integer
        Try
            Return mDb.ValidarEntrega(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, ENTREGA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarAmpliacion(ByVal aEntidad As entidadBase) As Integer
        Try
            Return mDb.ActualizarAmpliacion(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerEntregas(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64) As DataSet
        Try
            Return mDb.ObtenerEntregas(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
