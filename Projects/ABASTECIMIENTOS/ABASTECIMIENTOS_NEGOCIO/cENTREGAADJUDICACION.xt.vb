Partial Public Class cENTREGAADJUDICACION

#Region " Metodos Agregados "

    ''' <summary>
    ''' Obtiene las entregas ingresadas según lo indicado por el proveedor en su oferta, para un renglón dado.
    ''' En caso de que no se haya ingresado ninguna, devuelve las entregas solicitadas según el proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerEntregasPorOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal RENGLON As Int32) As DataSet
        Try
            Return mDb.ObtenerEntregasPorOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Elimina los datos de entrega (porcentajes y plazos) para una oferta dada.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDDETALLE">Identificador de la oferta.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarEntregasPorOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal momento As Integer) As Integer
        Try
            Return mDb.EliminarEntregasPorOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, momento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Guarda en las tablas correspondientes los valores calculados para cada entrega de un proveedor, para un renglón dado.
    ''' </summary>
    ''' <param name="aLista">Lista de entidades ENTREGAADJUDICACION, donde se indican las cantidades, porcentajes y plazos.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function AgregarEntregasPorOferta(ByVal aLista As listaENTREGAADJUDICACION, ByVal MOMENTO As Integer) As Integer
        Try
            Return mDb.AgregarEntregasPorOferta(aLista, MOMENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Elimina todas las entregas registradas para las distintas ofertas recomendadas/adjudicadas para un renglón dado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarEntregasPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Int32) As Integer
        Try
            Return mDb.EliminarEntregasPorRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Distribuye la cantidad recomendada/adjudicada/adjudicada en firme a un proveedor para un renglón dado según los porcentajes y cantidad de entregas indicadas.
    ''' </summary>
    ''' <param name="CantidadTotal">Cantidad total a distribuir.</param>
    ''' <param name="aLista">Lista de entregas donde se guardan las cantidades a partir de los porcentajes y plazos.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function DistribuirCantidadTotalPorEntrega(ByVal CantidadTotal As Decimal, ByRef aLista As listaENTREGAADJUDICACION) As Integer

        Dim i, numeroEntregas As Integer
        Dim sumaDistribucion As Decimal

        Dim valor, valorAprox As Decimal

        numeroEntregas = aLista.Count

        For i = 0 To numeroEntregas - 1

            If (CantidadTotal - sumaDistribucion) > 0 Then
                If i = numeroEntregas - 1 Then
                    aLista(i).CANTIDAD = CantidadTotal - sumaDistribucion
                Else
                    valorAprox = Fix((CantidadTotal * aLista(i).PORCENTAJE) / 100)
                    valor = (CantidadTotal * (aLista(i).PORCENTAJE) / 100)
                    If (valor - valorAprox) >= 0.5 Then
                        aLista(i).CANTIDAD = valorAprox + 1
                    Else
                        aLista(i).CANTIDAD = valorAprox
                    End If
                    sumaDistribucion += aLista(i).CANTIDAD
                End If
            End If
        Next

        Return 1

    End Function

    Public Function obtenerEntregasProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet
        Return mDb.obtenerEntregasProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)
    End Function
    Public Function obtenerEntregasProveedor1(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet
        Return mDb.obtenerEntregasProveedor1(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)
    End Function
    Public Function obtenerEntregasProveedor3(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As DataSet
        Return mDb.obtenerEntregasProveedor3(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)
    End Function

    Public Function obtenerNumntregasProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Return mDb.obtenerNumntregasProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
    End Function

    Public Function obtenerRenglosAdjudicados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Return mDb.obtenerRenglosAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
    End Function
    Public Function obtenerEntregasProveedor2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As ArrayList

        Try
            Return mDb.obtenerEntregasProveedor2(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return New ArrayList
        End Try

    End Function

    Public Function obtenerNumntregasProveedor2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer) As ArrayList

        Try
            Return mDb.obtenerNumntregasProveedor2(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return New ArrayList
        End Try

    End Function
#End Region

End Class
