Partial Public Class cEMPLEADOS

#Region " Metodos adicionales "

    ''' <summary>
    ''' Obtiene un listado de empleados.
    ''' </summary>
    ''' <returns>listaEMPLEADOS</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history>
    Public Function ObtenerListaEmpleadosNA() As listaEMPLEADOS
        Try
            Return mDb.ObtenerListaEmpladosNA()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtiene un listado de empleados por establecimiento y dependencia.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la dependencia.</param>
    ''' <returns>listaEMPLEADOS</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history>
    Public Function ObtenerListaEmpleadosNA(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer) As listaEMPLEADOS
        Try
            Return mDb.ObtenerListaEmpladosNA(IDESTABLECIMIENTO, IDDEPENDENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtiene un listado de empleados por establecimiento y dependencia, omitiendo un empleado en particular.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la dependencia.</param>
    ''' <param name="IDEMPLEADO">Identificador del empleado que se desea excluir.</param>
    ''' <returns>listaEMPLEADOS</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function RecuperarEmpleadosPorDependenciaAnalistaJuridico(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer, Optional ByVal IDEMPLEADO As Integer = 0) As listaEMPLEADOS
        Try
            Return mDb.RecuperarEmpleadosPorDependenciaAnalistaJuridico(IDESTABLECIMIENTO, IDDEPENDENCIA, IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaEmpladosPorDependencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer, Optional ByVal IDEMPLEADO As Integer = 0) As listaEMPLEADOS
        Try
            Return mDb.ObtenerListaEmpladosPorDependencia(IDESTABLECIMIENTO, IDDEPENDENCIA, IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaEmpladosPorDependenciaInspector(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal IDDEPENDENCIA As Integer = 0, Optional ByVal IDEMPLEADO As Integer = 0) As listaEMPLEADOS
        Try
            Return mDb.ObtenerListaEmpladosPorDependenciaInspector(IDESTABLECIMIENTO, IDDEPENDENCIA, IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaEmpladosPorDependenciaCoordinador(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer, Optional ByVal IDEMPLEADO As Integer = 0) As listaEMPLEADOS
        Try
            Return mDb.ObtenerListaEmpladosPorDependenciaCoordinador(IDESTABLECIMIENTO, IDDEPENDENCIA, IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtiene un listado de empleados por establecimiento y dependencia, omitiendo un empleado en particular.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la dependencia.</param>
    ''' <returns>listaEMPLEADOS</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Jose Chavez]    Creado
    ''' </history>
    Public Function ObtenerEmpleadosPorDependencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer) As listaEMPLEADOS
        Try
            Return mDb.ObtenerEmpleadosPorDependencia(IDESTABLECIMIENTO, IDDEPENDENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetporEstablecimiento(ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetporEstablecimiento(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarEmpleado(ByVal Bfiltro As String) As listaEMPLEADOS
        Try
            Return mDb.BuscarEmpleado(Bfiltro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNombreCompleto() As DataSet
        Try
            Return mDb.ObtenerNombreCompleto()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNombreCompleto(ByVal TITULAR As Integer) As DataSet
        Try
            Return mDb.ObtenerNombreCompleto(TITULAR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNombreCompleto(ByVal IDESTABLECIMIENTO As Integer, ByVal TITULAR As Integer) As DataSet
        Try
            Return mDb.ObtenerNombreCompleto(IDESTABLECIMIENTO, TITULAR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerEmpleadoXEstablecimientoNombreCompleto(ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerEmpleadoXEstblecimientoNombreCompleto(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetporCargo(ByVal IDESTABLECIMIENTO As Int64, ByVal IDEMPLEADO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetporCargo(IDESTABLECIMIENTO, IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Validar si un nombre corto ya existe.
    ''' </summary>
    ''' <param name="Cfiltro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Eduardo Rodriguez]    15/12/06    Creado
    ''' </history>
    Public Function BuscarNombreCorto(ByVal NOMBRECORTO As String, ByVal IDEMPLEADO As Int64) As Int16
        Try
            Return mDb.BuscarNombreCorto(NOMBRECORTO, IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Validar si un EMPLEADO ya ASIGNADO UN USUARIO
    ''' </summary>
    ''' <param name="IDUSUARIO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Eduardo Rodriguez]    18/12/06    Creado
    ''' </history>
    Public Function EmpleadoUsuario(ByVal IDUSUARIO As Int32) As Boolean
        Try
            Return mDb.EmpleadoUsuario(IDUSUARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve los empleados sin usuario asignado.
    ''' </summary>
    ''' <param name="IDUSUARIO">Identificador de usuario.  Opcional.</param>
    ''' <returns>Dataset.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerNombreCompletoEmpleadosSinUsuario(Optional ByVal IDUSUARIO As Int32 = 0) As DataSet
        Try
            Return mDb.ObtenerNombreCompletoEmpleadosSinUsuario(IDUSUARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve un listado de empleados, incluyendo los nombres de establecimiento, dependencia y cargo.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerDataSetListaEmpleados() As DataSet
        Try
            Return mDb.ObtenerDataSetListaEmpleados()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetporEstablecimientoDependencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetporEstablecimientoDependencia(IDESTABLECIMIENTO, IDDEPENDENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve los empleados titulares del establecimiento y de la dependencia
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la dependencia.  Opcional.</param>
    ''' <remarks></remarks>
    ''' <returns>listaEMPLEADOS</returns>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerTitulares(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal IDDEPENDENCIA As Integer = 0) As listaEMPLEADOS
        Try
            Return mDb.ObtenerTitulares(IDESTABLECIMIENTO, IDDEPENDENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetCodigoEmpleado() As DataSet
        Try
            Return mDb.ObtenerDataSetCodigoEmpleado()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve la lista completa de empleados de un establecimiento.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento (Filtro)</param>
    ''' <returns>Dataset con la lista de empleados.</returns>
    ''' <remarks>Lista de tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>vv_EMPLEADOS</description></item>
    ''' </list>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  11/12/2006    Creado
    ''' </history>
    ''' </remarks>
    Public Function ObtenerEmpleadoXEstblecimientoCodigoNombre(ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerEmpleadoXEstblecimientoCodigoNombre(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerJefeUACI(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerJefeUACI(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNombreJefeUACI(ByVal IDESTABLECIMIENTO As Int32) As String
        Try
            Return mDb.ObtenerNombreJefeUACI(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function


    'Public Function RecuperarEmpleadosPorDependenciaAnalistaSuministros(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer, Optional ByVal IDEMPLEADO As Integer = 0) As listaEMPLEADOS
    '    Try
    '        Return mDb.RecuperarEmpleadosPorDependenciaAnalistaSuministros(IDESTABLECIMIENTO, IDDEPENDENCIA, IDEMPLEADO)
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return Nothing
    '    End Try
    'End Function




#End Region

End Class
