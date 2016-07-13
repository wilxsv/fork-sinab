''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cFUENTEFINANCIAMIENTOSNECESIDADES
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla FUENTEFINANCIAMIENTOSNECESIDADES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cFUENTEFINANCIAMIENTOSNECESIDADES
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbFUENTEFINANCIAMIENTOSNECESIDADES()
    Private mEntidad As New FUENTEFINANCIAMIENTOSNECESIDADES
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32) As listaFUENTEFINANCIAMIENTOSNECESIDADES
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDNECESIDAD, IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerFUENTEFINANCIAMIENTOSNECESIDADES(ByRef aEntidad As FUENTEFINANCIAMIENTOSNECESIDADES) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerFUENTEFINANCIAMIENTOSNECESIDADES(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32) As FUENTEFINANCIAMIENTOSNECESIDADES
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDNECESIDAD = IDNECESIDAD
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

    Public Function EliminarFUENTEFINANCIAMIENTOSNECESIDADES(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDNECESIDAD = IDNECESIDAD
            mEntidad.IDFUENTEFINANCIAMIENTO = IDFUENTEFINANCIAMIENTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarFUENTEFINANCIAMIENTOSNECESIDADES(ByVal aEntidad As FUENTEFINANCIAMIENTOSNECESIDADES) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarFUENTEFINANCIAMIENTOSNECESIDADES(ByVal aEntidad As FUENTEFINANCIAMIENTOSNECESIDADES) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDNECESIDAD, IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDNECESIDAD, IDFUENTEFINANCIAMIENTO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
