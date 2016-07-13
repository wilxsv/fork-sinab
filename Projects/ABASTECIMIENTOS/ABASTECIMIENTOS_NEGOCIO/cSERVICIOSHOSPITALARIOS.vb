''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cSERVICIOSHOSPITALARIOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SERVICIOSHOSPITALARIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cSERVICIOSHOSPITALARIOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbSERVICIOSHOSPITALARIOS()
    Private mEntidad As New SERVICIOSHOSPITALARIOS
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32) As listaSERVICIOSHOSPITALARIOS
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerSERVICIOSHOSPITALARIOS(ByRef aEntidad As SERVICIOSHOSPITALARIOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerSERVICIOSHOSPITALARIOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSERVICIOHOSPITALARIO As Int32) As SERVICIOSHOSPITALARIOS
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDSERVICIOHOSPITALARIO = IDSERVICIOHOSPITALARIO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarSERVICIOSHOSPITALARIOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSERVICIOHOSPITALARIO As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDSERVICIOHOSPITALARIO = IDSERVICIOHOSPITALARIO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarSERVICIOSHOSPITALARIOS(ByVal aEntidad As SERVICIOSHOSPITALARIOS) As Integer
        ' Try
        Return mDb.Actualizar(aEntidad)
        ' Catch ex as Exception
        ' ExceptionManager.Publish(ex)
        'Return -1
        ' End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerListaOrdenada(ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Try
            Return mDb.ObtenerListaPorIDOrdenada(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
