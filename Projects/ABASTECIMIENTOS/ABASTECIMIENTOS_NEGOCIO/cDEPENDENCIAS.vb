''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cDEPENDENCIAS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_CAT_DEPENDENCIAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cDEPENDENCIAS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbDEPENDENCIAS()
    Private mEntidad As New DEPENDENCIAS
#End Region

    Public Function ObtenerLista(Optional ByVal ut As Integer = 0) As listaDEPENDENCIAS
        'Try
            Return mDb.ObtenerListaPorID(ut)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerDEPENDENCIAS(ByRef aEntidad As DEPENDENCIAS) As Integer
        'Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerDEPENDENCIAS(ByVal IDDEPENDENCIA As Int32) As DEPENDENCIAS
        'Try
            mEntidad.IDDEPENDENCIA = IDDEPENDENCIA
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function EliminarDEPENDENCIAS(ByVal IDDEPENDENCIA As Int32) As Integer
        'Try
            mEntidad.IDDEPENDENCIA = IDDEPENDENCIA
            Return mDb.Eliminar(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ActualizarDEPENDENCIAS(ByVal aEntidad As DEPENDENCIAS) As Integer
        'Try
            Return mDb.Actualizar(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerDataSetPorId() As DataSet
        'Try
            Return mDb.ObtenerDataSetPorID()
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerDataSetPorId(ByRef ds As DataSet) As Integer
        'Try
            Return mDb.ObtenerDataSetPorID(ds)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

#End Region

End Class
