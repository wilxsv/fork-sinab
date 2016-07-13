Public Class cGRUPOSFUENTEFINANCIAMIENTO
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbGRUPOSFUENTEFINANCIAMIENTO()
    Private mEntidad As New GRUPOSFUENTEFINANCIAMIENTO
#End Region

    Public Function ObtenerLista() As listaGRUPOSFUENTEFINANCIAMIENTO
        Try
            Return mDb.ObtenerListaPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerGRUPOSFUENTEFINANCIAMIENTO(ByRef aEntidad As GRUPOSFUENTEFINANCIAMIENTO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerGRUPOSFUENTEFINANCIAMIENTO(ByVal IDGRUPO As Int16) As GRUPOSFUENTEFINANCIAMIENTO
        Try
            mEntidad.IDGRUPO = IDGRUPO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarGRUPOSFUENTEFINANCIAMIENTO(ByVal IDGRUPO As Int16) As Integer
        Try
            mEntidad.IDGRUPO = IDGRUPO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarGRUPOSFUENTEFINANCIAMIENTO(ByVal aEntidad As GRUPOSFUENTEFINANCIAMIENTO) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId() As DataSet
        Try
            Return mDb.ObtenerDataSetPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
