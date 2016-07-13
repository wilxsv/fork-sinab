Partial Class cSERVICIOSHOSPITALARIOS

    ''' <summary>
    ''' Eliminar servicios hospitalarios por establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificado establecimiento
    ''' <returns>
    ''' Numero de registros afectados por la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function EliminarSERVICIOSHOSPITALARIOSxEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO

            Return mDb.EliminarxEstablecimiento(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Verificar si existen servicios hospitalarios para el establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <returns>
    ''' verdadero si existen servicios hospitalarios para el establecimiento
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ExistenServiciosHospitalariosEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As Boolean

        Return mDb.ExistenServiciosHospitalariosEstablecimiento(IDESTABLECIMIENTO)
    End Function

    ''' <summary>
    ''' Busqueda de existencia de codigo de servicio
    ''' </summary>
    ''' <param name="IDestablecimiento"></param> identificador de establecimiento
    ''' <param name="CODIGOSERVICIO"></param> codigo de servicio
    ''' <returns>
    ''' verdadero si encontro que existe
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor:]      Creado
    ''' </history> 
    Public Function BuscarEstablecimientocodigo(ByVal IDestablecimiento As Int32, ByVal CODIGOSERVICIO As String) As Boolean
        Try
            Return mDb.BuscarEstablecimientocodigo(IDestablecimiento, CODIGOSERVICIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener lista de servicios hospitalarios
    ''' </summary>
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor:Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDataSetListaServiciosHospitalarios() As DataSet
        Try
            Return mDb.ObtenerDataSetListaServiciosHospitalarios()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
