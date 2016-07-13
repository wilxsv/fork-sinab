''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cSOLICITUDES
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cSOLICITUDES
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbSOLICITUDES()
    Private mEntidad As New SOLICITUDES
    Private cDb As New dbTIPOCOMPRAS
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32) As listaSOLICITUDES
        'Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerSOLICITUDES(ByRef aEntidad As SOLICITUDES) As Integer
        'Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerSOLICITUDES(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As SOLICITUDES
        'Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDSOLICITUD = IDSOLICITUD
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function EliminarSOLICITUDES(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As Integer
        'Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDSOLICITUD = IDSOLICITUD
            Return mDb.Eliminar(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ActualizarSOLICITUDES(ByVal aEntidad As SOLICITUDES) As Integer
        'Try
            Return mDb.Actualizar(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        'Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByRef ds As DataSet) As Integer
        'Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, ds)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

#End Region


    Public Function getMax() As String
        Return cDb.ObtenerMax
    End Function
End Class
