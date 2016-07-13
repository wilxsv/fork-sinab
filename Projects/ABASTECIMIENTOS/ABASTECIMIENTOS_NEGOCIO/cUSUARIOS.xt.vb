Partial Public Class cUSUARIOS

#Region " Metodos Agregados "

    ''' <summary>
    ''' Se utiliza para obtener listado de usuarios por rol.
    ''' </summary>
    ''' <param name="IDROL">Identificador de rol.</param>
    ''' <returns>Dataset de usuarios por rol.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history> 
    Public Function ObtenerListaPorRol(Optional ByVal IDROL As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerListaPorRol(IDROL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve un dataset de usuarios sin rol asignado.
    ''' </summary>
    ''' <returns>Dataset.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaUsuariosSinRol() As DataSet
        Try
            Return mDb.ObtenerListaUsuariosSinRol()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Eliminar la asiganción de un usuario a un rol dado.
    ''' </summary>
    ''' <param name="IDUSUARIO">Identificador de usuario.</param>
    ''' <param name="IDROL">Identificador de rol.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarUsuarioRol(ByVal IDUSUARIO As Integer, ByVal IDROL As Integer) As Integer
        Try
            Return mDb.EliminarUsuarioRol(IDUSUARIO, IDROL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Se utiliza para obtener un dataset con el listado de las opciones disponibles segun el rol que el usuario
    ''' </summary>
    ''' <param name="IDUSUARIO">Identificador de usuario.</param>
    ''' <returns>Dataset de opciones por usuario.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]      Creado
    ''' </history>
    Public Function ObtenerDsUsuariosOpciones(ByVal IDUSUARIO As Int32) As DataSet
        Try
            Return mDb.ObtenerDsUsuariosOpciones(IDUSUARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve un dataset con las opciones no habilitadas para el rol al que se encuentra asociado el usuario.
    ''' </summary>
    ''' <param name="IDUSUARIO">Identificador de usuario.</param>
    ''' <returns>Dataset.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Jürgen Kappler]    Creado
    ''' </history>
    Public Function ObtenerDsOpcionesNoHabilitadas(ByVal IDUSUARIO As Int32) As DataSet
        Try
            Return mDb.ObtenerDsOpcionesNoHabilitadas(IDUSUARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve una lista de usuarios, ordenada por el campo que se especifica.
    ''' </summary>
    ''' <param name="Campo">Nombre del campo por el cual se ordena.</param>
    ''' <returns>Lista listaUSUARIOS.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaOrdenada(ByVal Campo As String) As listaUSUARIOS
        Try
            Return mDb.ObtenerListaPorIDOrdenada(Campo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Permite actualizar todos los datos de un usuario excepto su clave.
    ''' </summary>
    ''' <param name="aEntidad">Entidad USUARIOS.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarUSUARIOSSinClave(ByVal aEntidad As USUARIOS) As Integer
        Try
            Return mDb.ActualizarSinClave(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Devuelve un dataset de los usuarios junto con los datos de los empleado relacionados.
    ''' </summary>
    ''' <param name="ESTAELIMINADO">0: sin eliminar 1: eliminado</param>
    ''' <returns>Dataset.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerDsUsuariosEmpleados(Optional ByVal ESTAELIMINADO As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerDsUsuariosEmpleados(ESTAELIMINADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve los datos del usuario junto con el nombre completo y el número del empleado relacionado.
    ''' </summary>
    ''' <param name="aEntidad">Entidad USUARIO</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item>sproc_ListadoUsuarios</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerUsuarioConNombreEmpleado(ByRef aEntidad As USUARIOS) As Integer
        Try
            Return mDb.RecuperarUsuarioConNombreEmpleado(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Se utiliza para obtener el siguiente ID de usuario.
    ''' </summary>
    ''' <param name="aEntidad">Entidad USUARIOS.</param>
    ''' <returns>String.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]    Creado
    ''' </history>
    Public Function ObtenerId(ByVal aEntidad As USUARIOS) As String
        Try
            Return mDb.ObtenerID(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Se utiliza para devolver el id de usuario correspondiente al nombre usuario que ingreso al sistema.
    ''' </summary>
    ''' <param name="aUser">Nombre del usuario.</param>
    ''' <returns>ID del usuario correspondiente.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]    Creado
    ''' </history> 
    Public Function DatosUsuarios(ByVal aUser As String) As String
        Try
            Return mDb.DatosUsuario(aUser)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Eliminación de usuarios con auditoría de usuario y fecha.
    ''' </summary>
    ''' <param name="IDUSUARIO">Identificador de usuario</param>
    ''' <param name="AUUSUARIOELIMINACION">Usuario que elimina.</param>
    ''' <param name="AUFECHAELIMINACION">Fecha de eliminación.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarUSUARIOS(ByVal IDUSUARIO As Int32, ByVal AUUSUARIOELIMINACION As String, ByVal AUFECHAELIMINACION As DateTime) As Integer
        Try
            Return mDb.EliminarUSUARIOS(IDUSUARIO, AUUSUARIOELIMINACION, AUFECHAELIMINACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarClave(ByVal idusuario As Integer, ByVal clave As String) As Integer
        Try
            Return mDb.ActualizarClave(idusuario, clave)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerEmpleadosUsuarios() As DataSet
        Try
            Return mDb.ObtenerEmpleadosUsuarios()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerTablasBD() As DataSet
        Try
            Return mDb.ObtenerTablasBD()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerRegistroUsuarios(ByVal fechai As Date, ByVal fechaf As Date, ByVal usuario As String) As DataSet
        Try
            Return mDb.ObtenerRegistroUsuarios(fechai, fechaf, usuario)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerBitacoraSABAS(ByVal fechai As Date, ByVal fechaf As Date, ByVal usuario As String, ByVal movimiento As Integer, ByVal tabla As String) As DataSet
        Try
            Return mDb.ObtenerBitacoraSABAS(fechai, fechaf, usuario, movimiento, tabla)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
