Partial Public Class cPROGRAMADISTRIBUCION

#Region " Metodos Agregados "

    ''' <summary>
    ''' Devuelve una lista con todas las solicitudes correspondientes a un renglón.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>listaPROGRAMADISTRIBUCION</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerSolicitudesPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer) As listaPROGRAMADISTRIBUCION
        Try
            Return mDb.ObtenerSolicitudesPorRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Actualiza las cantidades correspondientes a cada solicitud, de acuerdo a lo recomendado/adjudicado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <param name="TOTAL">Cantidad total recomendada/adjudicada al renglón.</param>
    ''' <param name="USUARIOMODIFICACION">Usuario que realiza la modificación.</param>
    ''' <param name="FECHAMODIFICACION">Fecha en que se realiza la modificación.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarCantidadAdjudicadaPorSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer, ByVal TOTAL As Decimal, ByVal USUARIOMODIFICACION As String, ByVal FECHAMODIFICACION As String) As Integer
        Try
            Dim lPD As listaPROGRAMADISTRIBUCION
            lPD = ObtenerSolicitudesPorRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)

            DistribuirCantidadTotalPorSolicitud(TOTAL, lPD)

            mDb.ActualizarCantidadAdjudicadaPorSolicitud(lPD, USUARIOMODIFICACION, FECHAMODIFICACION)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Distribuye la cantidad total recomendada/adjudicada a un renglón entre todas las solicitudes relacionadas.
    ''' </summary>
    ''' <param name="CantidadTotal">Cantidad total recomendada/adjudicada a distribuir.</param>
    ''' <param name="aLista">Lista de entidades PROGRAMADISTRIBUCION donde se indican los porcentajes correspondientes a cada solicitud.</param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function DistribuirCantidadTotalPorSolicitud(ByVal CantidadTotal As Decimal, ByRef aLista As listaPROGRAMADISTRIBUCION) As Integer

        Dim i, numeroEntregas As Integer
        Dim sumaDistribucion As Decimal

        Dim valor, valorAprox As Decimal

        numeroEntregas = aLista.Count

        For i = 0 To numeroEntregas - 1

            If (CantidadTotal - sumaDistribucion) > 0 Then
                If i = numeroEntregas - 1 Then
                    aLista(i).CANTIDADADJUDICADA = CantidadTotal - sumaDistribucion
                Else
                    valorAprox = Fix(CantidadTotal * aLista(i).PORCENTAJE)
                    valor = CantidadTotal * (aLista(i).PORCENTAJE)
                    If (valor - valorAprox) >= 0.5 Then
                        aLista(i).CANTIDADADJUDICADA = valorAprox + 1
                    Else
                        aLista(i).CANTIDADADJUDICADA = valorAprox
                    End If
                    sumaDistribucion += aLista(i).CANTIDADADJUDICADA
                End If
            End If
        Next

        Return 1

    End Function

    Public Function ObtenerCantidadAdjudicadaAlmacen(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.ObtenerCantidadAdjudicadaAlmacen(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param>
    ''' <param name="TIPOPRODUCTO"></param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function BuscarProgramaParaDespacho(ByVal IDESTABLECIMIENTO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal TIPOPRODUCTO As Integer) As DataSet
        Try
            Return mDb.BuscarProgramaParaDespacho(IDESTABLECIMIENTO, IDFUENTEFINANCIAMIENTO, TIPOPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function BuscarProgramaProceso(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.BuscarProgramaProceso(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function CuadroDistribucion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, Optional ByVal IDALMACEN As Integer = 0) As DataSet
        Try
            Return mDb.CuadroDistribucion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProcesosCompra(Optional ByVal IDESTABLECIMIENTO As Integer = 0, Optional ByVal IDALMACEN As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerProcesosCompra(IDESTABLECIMIENTO, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarCantidadEntregada(ByVal aEntidad As PROGRAMADISTRIBUCION) As Integer
        Try
            Return mDb.ActualizarCantidadEntregada(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerPROGRAMADISTRIBUCION2(ByRef aEntidad As PROGRAMADISTRIBUCION) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar2(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerAlmacenFosIsss(ByVal IDESTABLECIMIENTO As Integer, ByVal idprocesocompra As Integer) As Integer
        Try
            Return mDb.ObtenerAlmacenFosIsss(IDESTABLECIMIENTO, idprocesocompra)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function


    'OJO OJO
    Public Function ObtenerCantidadAdjudicadaAlmacenSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal RENGLON As Integer) As DataSet

        Try
            Return mDb.ObtenerCantidadAdjudicadaAlmacenSolicitud(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
