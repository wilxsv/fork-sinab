Public Class cLogin

    ''' <summary>
    ''' Se utiliza para VERIFICAR QUE EXISTA EL USUARIO Y LA CLAVE
    ''' </summary>
    ''' <param name="USUARIO"></param> nombre usuario
    ''' <param name="CLAVE"></param> clave de usuario
    ''' <returns>
    ''' verdadero si existe.
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarUsuario(ByVal USUARIO As String, ByVal CLAVE As String, ByRef EsComisionAltoNivel As Boolean) As Boolean
        Try
            Dim miDb As New dbUSUARIOS
            If Not miDb.ValidarUsuario(USUARIO, CLAVE) Then
                Dim miDb2 As New dbCOMISIONPROCESOCOMPRA
                If miDb2.ValidarUsuario(USUARIO, CLAVE) Then
                    EsComisionAltoNivel = True
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Se utiliza para devolver el id de usuario correspondiente al nombre usuario que ingreso al sistema
    ''' </summary>
    ''' <param name="USUARIO"></param> usuario nombre
    ''' <returns>
    ''' id del usuario correspondiente
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DatosUsuario(ByVal USUARIO As String) As String
        Try
            Dim miDb As New dbUSUARIOS
            Return miDb.DatosUsuario(USUARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    '''  Se utiliza para devolver el rol de usuario correspondiente al nombre usuario que ingreso al sistema
    ''' </summary>
    ''' <param name="asUser"></param> nombre de usuario
    ''' <returns>
    ''' el rol de un usuario
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function RolUsuario(ByVal asUser As String) As String
        Try
            Dim miDb As New dbROLESUSUARIOS
            Return miDb.RolUsuario(asUser)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Obtener establecimiento de un usuario de comision de alto nivel
    ''' </summary>
    ''' <param name="USUARIOCOMISION"></param> nombre del usuario de comision
    ''' <returns>
    ''' id del establecimiento
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    Public Function ObtenerEstablecimientoUsuarioComisionAltoNivel(ByVal USUARIOCOMISION As String) As Integer
        Try
            Dim miDb As New dbCOMISIONPROCESOCOMPRA
            Return miDb.ObtenerEstablecimientoUsuarioComisionAltoNivel(USUARIOCOMISION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function RegistrarAcceso() As Integer

        'Try
        '    Dim miDb As New dbCOMISIONPROCESOCOMPRA
        '    Return miDb.()
        'Catch ex As Exception
        '    ExceptionManager.Publish(ex)
        '    Return Nothing
        'End Try
    End Function

End Class
