''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cMODALIDADESCOMPRA
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla MODALIDADESCOMPRA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cMODALIDADESCOMPRA
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbMODALIDADESCOMPRA()
    Private mEntidad As New MODALIDADESCOMPRA
#End Region

    Public Function ObtenerLista() As listaMODALIDADESCOMPRA
        Try
            Return mDb.ObtenerListaPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerMODALIDADESCOMPRA(ByRef aEntidad As MODALIDADESCOMPRA) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerMODALIDADESCOMPRA(ByVal IDMODALIDADCOMPRA As Byte) As MODALIDADESCOMPRA
        Try
            mEntidad.IDMODALIDADCOMPRA = IDMODALIDADCOMPRA
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarMODALIDADESCOMPRA(ByVal IDMODALIDADCOMPRA As Byte) As Integer
        Try
            mEntidad.IDMODALIDADCOMPRA = IDMODALIDADCOMPRA
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarMODALIDADESCOMPRA(ByVal aEntidad As MODALIDADESCOMPRA) As Integer
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
