''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cTIPODOCUMENTOCONTRATO
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_CAT_TIPODOCUMENTOCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cTIPODOCUMENTOCONTRATO
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbTIPODOCUMENTOCONTRATO()
    Private mEntidad As New TIPODOCUMENTOCONTRATO
#End Region

    Public Function ObtenerLista() As listaTIPODOCUMENTOCONTRATO
        Try
            Return mDb.ObtenerListaPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerTIPODOCUMENTOCONTRATO(ByRef aEntidad As TIPODOCUMENTOCONTRATO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerTIPODOCUMENTOCONTRATO(ByVal IDTIPODOCUMENTO As Int16) As TIPODOCUMENTOCONTRATO
        Try
            mEntidad.IDTIPODOCUMENTO = IDTIPODOCUMENTO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarTIPODOCUMENTOCONTRATO(ByVal IDTIPODOCUMENTO As Int16) As Integer
        Try
            mEntidad.IDTIPODOCUMENTO = IDTIPODOCUMENTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarTIPODOCUMENTOCONTRATO(ByVal aEntidad As TIPODOCUMENTOCONTRATO) As Integer
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
