Partial Public Class cFUENTEFINANCIAMIENTOS

    Public Function BuscarFuenteFinanciamientoEnFFNececidades(ByVal IDFUENTEFINANCIAMIENTO As Int32) As Boolean
        Try
            Return mDb.BuscarFuenteFinanciamientoEnFFNececidades(IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarFuenteFinanciamientoEnFFSolicitudes(ByVal IDFUENTEFINANCIAMIENTO As Int32) As Boolean
        Try
            Return mDb.BuscarFuenteFinanciamientoEnFFSolicitudes(IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarFuenteFinanciamientoEnFFContratos(ByVal IDFUENTEFINANCIAMIENTO As Int32) As Boolean
        Try
            Return mDb.BuscarFuenteFinanciamientoEnFFContratos(IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarFuenteFinanciamientoEnInventarios(ByVal IDFUENTEFINANCIAMIENTO As Int32) As Boolean
        Try
            Return mDb.BuscarFuenteFinanciamientoEnInventarios(IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarFuenteFinanciamientoEnLotes(ByVal IDFUENTEFINANCIAMIENTO As Int32) As Boolean
        Try
            Return mDb.BuscarFuenteFinanciamientoEnLotes(IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarOrdenada() As DataSet
        Try
            Return mDb.RecuperarOrdenada()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DevolverFFPC(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As String
        Try
            Return mDb.DevolverFFPC(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DevolverFFSo(ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDFUENTE As Integer) As String
        Try
            Return mDb.DevolverFFSo(IDSOLICITUD, IDESTABLECIMIENTO, IDFUENTE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve las fuentes de financiamiento de un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns>Cadena de texto con las fuentes de financiamiento.</returns>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  18/01/2007    Creado
    ''' </history> 
    Public Function DevolverFFContratos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As String
        Try
            Return mDb.DevolverFFContratos(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarPorGrupo(Optional ByVal IDGRUPO As Integer = 0) As DataSet
        Try
            Return mDb.RecuperarPorGrupo(IDGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ValidarNombreGrupo(ByVal NOMBRE As String, ByVal IDGRUPO As Int32, ByVal IDFUENTEFINANCIAMIENTO As Int32) As Int16
        Try
            Return mDb.ValidarNombreGrupo(NOMBRE, IDGRUPO, IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
