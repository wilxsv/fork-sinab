Partial Public Class cEMPLEADOSALMACEN

#Region "  Metodos Agregados  "

    Public Function ObtenerALMACEN(ByRef aEntidad As EMPLEADOSALMACEN) As Integer
        Try
            Return mDb.RecuperarAlmacen(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDsIdAlmacen(ByVal IDEMPLEADO As Int32) As DataSet
        Try
            Return mDb.ObtenerDsIdAlmacen(IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetListaEmpleadosAlmacen() As DataSet
        Try
            Return mDb.ObtenerDataSetListaEmpleadosAlmacen()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarEmpleadosAlmacen(ByVal IDEMPLEADO As Int32, ByVal IDALMACEN As Int32) As Boolean
        Try
            Return mDb.BuscarEmpleadosAlmacen(IDEMPLEADO, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve el listado de guardalmacenes para un establecimiento.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del establecimiento al que pertenecen los empleados.</param>
    ''' <returns>Devuelve un dataset con el listado de guardaalmacenes.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_EMPLEADOSALMACEN</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]      Creado
    ''' </history>
    Public Function RecuperarGuardalmacen(ByVal IDALMACEN As Int32) As DataSet
        Try
            Return mDb.RecuperarGuardalmacen(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerGuardalmacen(ByVal IDALMACEN As Int32) As String
        Try
            Return mDb.ObtenerGuardalmacen(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDsDetalleAlmacenesEmpleados(ByVal IDEMPLEADO As Int32) As DataSet

        Try
            Return mDb.ObtenerDsDetalleAlmacenesEmpleados(IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function


#End Region

End Class
