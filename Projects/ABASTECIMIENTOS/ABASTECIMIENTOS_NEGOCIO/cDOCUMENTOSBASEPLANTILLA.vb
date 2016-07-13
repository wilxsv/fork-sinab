''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cDOCUMENTOSBASEPLANTILLA
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla DOCUMENTOSBASEPLANTILLA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cDOCUMENTOSBASEPLANTILLA
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbDOCUMENTOSBASEPLANTILLA()
    Private mEntidad As New DOCUMENTOSBASEPLANTILLA
#End Region

    Public Function ObtenerLista(ByVal IDPLANTILLA As Int32, ByVal IDDOCUMENTOBASE As Int16) As listaDOCUMENTOSBASEPLANTILLA
        Try
            Return mDb.ObtenerListaPorID(IDPLANTILLA, IDDOCUMENTOBASE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDOCUMENTOSBASEPLANTILLA(ByRef aEntidad As DOCUMENTOSBASEPLANTILLA) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDOCUMENTOSBASEPLANTILLA(ByVal IDPLANTILLA As Int32, ByVal IDDOCUMENTOBASE As Int16) As DOCUMENTOSBASEPLANTILLA
        Try
            mEntidad.IDPLANTILLA = IDPLANTILLA
            mEntidad.IDDOCUMENTOBASE = IDDOCUMENTOBASE
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarDOCUMENTOSBASEPLANTILLA(ByVal IDPLANTILLA As Int32, ByVal IDDOCUMENTOBASE As Int16) As Integer
        Try
            mEntidad.IDPLANTILLA = IDPLANTILLA
            mEntidad.IDDOCUMENTOBASE = IDDOCUMENTOBASE
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarDOCUMENTOSBASEPLANTILLA(ByVal aEntidad As DOCUMENTOSBASEPLANTILLA) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarDOCUMENTOSBASEPLANTILLA(ByVal aEntidad As DOCUMENTOSBASEPLANTILLA) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDPLANTILLA As Int32, ByVal IDDOCUMENTOBASE As Int16) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDPLANTILLA, IDDOCUMENTOBASE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDPLANTILLA As Int32, ByVal IDDOCUMENTOBASE As Int16, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDPLANTILLA, IDDOCUMENTOBASE, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
