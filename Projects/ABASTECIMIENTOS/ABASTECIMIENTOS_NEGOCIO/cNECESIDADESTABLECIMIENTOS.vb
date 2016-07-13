''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cNECESIDADESTABLECIMIENTOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla NECESIDADESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cNECESIDADESTABLECIMIENTOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbNECESIDADESTABLECIMIENTOS()
    Private mEntidad As New NECESIDADESTABLECIMIENTOS
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32) As listaNECESIDADESTABLECIMIENTOS
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNECESIDADESTABLECIMIENTOS(ByRef aEntidad As NECESIDADESTABLECIMIENTOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerNECESIDADESTABLECIMIENTOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As NECESIDADESTABLECIMIENTOS
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDNECESIDAD = IDNECESIDAD
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarNECESIDADESTABLECIMIENTOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDNECESIDAD = IDNECESIDAD
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarNECESIDADESTABLECIMIENTOS(ByVal aEntidad As NECESIDADESTABLECIMIENTOS) As Integer
        'Try
        Return mDb.Actualizar(aEntidad)
        'Catch ex as Exception
        'ExceptionManager.Publish(ex)
        'Return -1
        'End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        'Try
        Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO)
        'Catch ex as Exception
        'ExceptionManager.Publish(ex)
        'Return Nothing
        'End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
