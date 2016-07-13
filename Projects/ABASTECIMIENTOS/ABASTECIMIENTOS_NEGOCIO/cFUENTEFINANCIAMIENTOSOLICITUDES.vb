''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cFUENTEFINANCIAMIENTOSOLICITUDES
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cFUENTEFINANCIAMIENTOSOLICITUDES
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbFUENTEFINANCIAMIENTOSOLICITUDES()
    Private mEntidad As New FUENTEFINANCIAMIENTOSOLICITUDES
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32) As listaFUENTEFINANCIAMIENTOSOLICITUDES
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDSOLICITUD, IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerFUENTEFINANCIAMIENTOSOLICITUDES(ByRef aEntidad As FUENTEFINANCIAMIENTOSOLICITUDES) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerFUENTEFINANCIAMIENTOSOLICITUDES(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32) As FUENTEFINANCIAMIENTOSOLICITUDES
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDFUENTEFINANCIAMIENTO = IDFUENTEFINANCIAMIENTO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarFUENTEFINANCIAMIENTOSOLICITUDES(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDFUENTEFINANCIAMIENTO = IDFUENTEFINANCIAMIENTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarFUENTEFINANCIAMIENTOSOLICITUDES(ByVal aEntidad As FUENTEFINANCIAMIENTOSOLICITUDES) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarFUENTEFINANCIAMIENTOSOLICITUDES(ByVal aEntidad As FUENTEFINANCIAMIENTOSOLICITUDES) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDSOLICITUD, IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDSOLICITUD, IDFUENTEFINANCIAMIENTO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
