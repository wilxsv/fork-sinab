''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cSUBGRUPOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SUBGRUPOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cSUBGRUPOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbSUBGRUPOS()
    Private mEntidad As New SUBGRUPOS
#End Region

    Public Function ObtenerLista() As listaSUBGRUPOS
        'Try
            Return mDb.ObtenerListaPorID()
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerSUBGRUPOS(ByRef aEntidad As SUBGRUPOS) As Integer
        'Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerSUBGRUPOS(ByVal IDSUBGRUPO As Int32) As SUBGRUPOS
        'Try
            mEntidad.IDSUBGRUPO = IDSUBGRUPO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function EliminarSUBGRUPOS(ByVal IDSUBGRUPO As Int32) As Integer
        'Try
            mEntidad.IDSUBGRUPO = IDSUBGRUPO
            Return mDb.Eliminar(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ActualizarSUBGRUPOS(ByVal aEntidad As SUBGRUPOS) As Integer
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
