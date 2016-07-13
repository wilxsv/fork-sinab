''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cSUMINISTRODEPENDENCIAS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SUMINISTRODEPENDENCIAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cSUMINISTRODEPENDENCIAS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbSUMINISTRODEPENDENCIAS()
    Private mEntidad As New SUMINISTRODEPENDENCIAS
#End Region

    Public Function ObtenerLista(ByVal IDDEPENDENCIA As Int32, ByVal IDSUMINISTRO As Int32) As listaSUMINISTRODEPENDENCIAS
        Try
            Return mDb.ObtenerListaPorID(IDDEPENDENCIA, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerSUMINISTRODEPENDENCIAS(ByRef aEntidad As SUMINISTRODEPENDENCIAS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerSUMINISTRODEPENDENCIAS(ByVal IDDEPENDENCIA As Int32, ByVal IDSUMINISTRO As Int32) As SUMINISTRODEPENDENCIAS
        Try
            mEntidad.IDDEPENDENCIA = IDDEPENDENCIA
            mEntidad.IDSUMINISTRO = IDSUMINISTRO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarSUMINISTRODEPENDENCIAS(ByVal IDDEPENDENCIA As Int32, ByVal IDSUMINISTRO As Int32) As Integer
        Try
            mEntidad.IDDEPENDENCIA = IDDEPENDENCIA
            mEntidad.IDSUMINISTRO = IDSUMINISTRO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarSUMINISTRODEPENDENCIAS(ByVal aEntidad As SUMINISTRODEPENDENCIAS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarSUMINISTRODEPENDENCIAS(ByVal aEntidad As SUMINISTRODEPENDENCIAS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDDEPENDENCIA As Int32, ByVal IDSUMINISTRO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDDEPENDENCIA, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDDEPENDENCIA As Int32, ByVal IDSUMINISTRO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDDEPENDENCIA, IDSUMINISTRO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerIdSuministro(ByVal IDDEPENDENCIA As Int32) As Integer
        Try
            Return mDb.ObtenerIdSuministro(IDDEPENDENCIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
