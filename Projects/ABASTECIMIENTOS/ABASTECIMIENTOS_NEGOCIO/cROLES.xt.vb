Partial Public Class cROLES

#Region " Metodos Agregados "

    ''' <summary>
    ''' obtener lista ordenada por un campo especifico 
    ''' </summary>
    ''' <param name="Campo"></param> campo por el cual se hara ordenamiento
    ''' <returns>
    ''' lista ordenada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerListaOrdenada(ByVal Campo As String) As listaROLES
        Try
            Return mDb.ObtenerListaPorIDOrdenada(Campo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' obtener un dataset de usuarios por roles
    ''' </summary>
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerListaRolesUsuarios() As DataSet
        Try
            Return mDb.ObtenerListaRolesUsuarios()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Recuperar un listado de roles hablitados
    ''' </summary>
    ''' <returns>
    ''' listado de roles
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function RecuperarListaRolesHabilitados() As listaROLES
        Try
            Return mDb.RecuperarListaRolesHabilitados()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Se utiliza para obtener un data set con los roles y usuarios con el que esta relacionado
    ''' </summary>
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>sproc_ListadoRolesUsuarios</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Jürgen Kappler]      Creado
    ''' </history>
    Public Function ObtenerDsRolesUsuarios() As DataSet
        Try
            Return mDb.ObtenerDsRolesUsuarios()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
