Partial Public Class cOPCIONESSISTEMA

#Region "AGREGADOS"

    ''' <summary>
    ''' listador de opciones del sistema por roles
    ''' </summary>
    ''' <param name="IDROL"></param> identificador de rol
    ''' <returns>
    ''' listado de opciones
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaporRol(ByVal IDROL As Integer) As DataSet
        Try
            Return mDb.ObtenerListaPorRol(IDROL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerOpcionesPorRol(ByVal IDROL As Integer, Optional ByVal SOLOPAGINAS As Boolean = False) As DataSet
        Try
            Return mDb.ObtenerOpcionesPorRol(IDROL, SOLOPAGINAS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener el listado de usuarios sin rol
    ''' </summary>
    ''' <param name="IDROL"></param> identificador de rol
    ''' <returns>
    ''' listado de opciones 
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history> 
    Public Function ObtenerListaOpcionesSinRol(ByVal IDROL As Integer) As listaOPCIONESSISTEMA
        Try
            Return mDb.ObtenerListaUsuariosSinRol(IDROL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Eliminar una opcion del rol
    ''' </summary>
    ''' <param name="IDOPCIONSISTEMA"></param> identificador de la opcion del sistema
    ''' <param name="IDROL"></param> identificador del rol
    ''' <returns>
    ''' valor de uno si se elimino registro exitosamente
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history> 
    Public Function EliminarOpcionRol(ByVal IDOPCIONSISTEMA As Integer, ByVal IDROL As Integer) As Integer
        Try
            Return mDb.EliminarOpcionRol(IDOPCIONSISTEMA, IDROL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener el listado de opciones del sistema padres
    ''' </summary>
    ''' <returns>
    ''' listado de opciones
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history> 
    Public Function ObtenerListaPadres() As listaOPCIONESSISTEMA
        Try
            Return mDb.ObtenerListaPadres()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener listado de opciones por Rol
    ''' </summary>
    ''' <param name="IDROL">Identificador de rol.</param>
    ''' <returns>
    ''' listaOPCIONESSISTEMA con el listado de opciones.
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaOpcionesParaRol(ByVal IDROL As Int32) As DataSet
        Try
            Return mDb.ObtenerListaOpcionesParaRolPorID(IDROL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>Dataset de listado de opciones.</summary>
    ''' <returns>Dataset.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGOPCIONESSISTEMA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history> 
    Public Function ObtenerListaOpciones() As DataSet
        Try
            Return mDb.ObtenerListaOpciones()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener el listado de opciones de reporte
    ''' </summary>
    ''' <param name="campoOrdenar"></param> nombre de campo por que se ordenara
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGOPCIONESSISTEMA</description></item>
    ''' <item><description>ConsultaRoles</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Jürgen Kappler]    Creado
    ''' </history> 
    Public Function ObtenerListaOpcionesReporte(ByVal campoOrdenar As String) As DataSet
        Try
            Return mDb.ObtenerListaOpcionesReporte(campoOrdenar)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerOpcionesPorOrden() As DataSet
        Try
            Return mDb.ObtenerOpcionesPorOrden()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarOrden(ByVal aEntidad As OPCIONESSISTEMA) As Integer
        Try
            Return mDb.ActualizarOrden(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
