Partial Public Class cCOMISIONPROCESOCOMPRA

#Region " Metodos Agregados "

    Public Function IngresarCOMISIONPROCESOCOMPRA(ByVal aEntidad As COMISIONPROCESOCOMPRA) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Actualizar la clave de la comision evaluadora de alto nivel.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador para realizar el filtro en la tabla</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador para realizar el filtro en la tabla</param>
    ''' <param name="IDCOMISION">Identificador para realizar el filtro en la tabla</param>
    ''' <param name="CLAVE">Clave encriptada</param>
    ''' <returns>Numero entero indicando si la actualizacion ha sido satisfactoria.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ActualizarClave(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCOMISION As Integer, ByVal CLAVE As String) As Integer
        Try
            Return mDb.ActualizarClave(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCOMISION, CLAVE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Verifica si un usuario dado se ha creado como usuario de comisión de alto nivel, si se encuentra habilitado y si la clave proporcionada es correcta.
    ''' </summary>
    ''' <param name="USUARIO">Usuario.</param>
    ''' <param name="CLAVE">Clave encriptada.  Opcional.  Por defecto es falso.</param>
    ''' <returns>Boolean.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ValidarUsuario(ByVal USUARIO As String, Optional ByVal CLAVE As String = "") As Boolean
        Try
            Return mDb.ValidarUsuario(USUARIO, CLAVE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el establecimiento al cual se encuentra asociado un usuario de comisión de alto nivel.
    ''' </summary>
    ''' <param name="USUARIOCOMISION">Usuario de comisión de alto nivel.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerEstablecimientoUsuarioComisionAltoNivel(ByVal USUARIOCOMISION As String) As Integer
        Try
            Return mDb.ObtenerEstablecimientoUsuarioComisionAltoNivel(USUARIOCOMISION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Inhabilita al usuario creado con la comisión de alto nivel, impidiendo su acceso al sistema una vez finalizada la adjudicación.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function InhabilitarUsuarioComisionAltoNivel(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer
        Try
            Return mDb.InhabilitarUsuarioComisionAltoNivel(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ExisteComisionEvaluacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Boolean
        Try
            Return mDb.ExisteComisionEvaluacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    Public Function ObtenerDsComision(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDsComision(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
