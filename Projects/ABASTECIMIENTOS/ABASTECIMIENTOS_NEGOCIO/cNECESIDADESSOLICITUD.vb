''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cNECESIDADESSOLICITUD
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla NECESIDADESSOLICITUD
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cNECESIDADESSOLICITUD
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbNECESIDADESSOLICITUD()
    Private mEntidad As New NECESIDADESSOLICITUD
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTOSOLICITUD As Int32, ByVal IDESTABLECIMIENTONECESIDAD As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSOLICITUD As Int64) As listaNECESIDADESSOLICITUD
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTOSOLICITUD, IDESTABLECIMIENTONECESIDAD, IDNECESIDAD, IDSOLICITUD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNECESIDADESSOLICITUD(ByRef aEntidad As NECESIDADESSOLICITUD) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerNECESIDADESSOLICITUD(ByVal IDESTABLECIMIENTOSOLICITUD As Int32, ByVal IDESTABLECIMIENTONECESIDAD As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSOLICITUD As Int64) As NECESIDADESSOLICITUD
        Try
            mEntidad.IDESTABLECIMIENTOSOLICITUD = IDESTABLECIMIENTOSOLICITUD
            mEntidad.IDESTABLECIMIENTONECESIDAD = IDESTABLECIMIENTONECESIDAD
            mEntidad.IDNECESIDAD = IDNECESIDAD
            mEntidad.IDSOLICITUD = IDSOLICITUD
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarNECESIDADESSOLICITUD(ByVal IDESTABLECIMIENTOSOLICITUD As Int32, ByVal IDESTABLECIMIENTONECESIDAD As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSOLICITUD As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTOSOLICITUD = IDESTABLECIMIENTOSOLICITUD
            mEntidad.IDESTABLECIMIENTONECESIDAD = IDESTABLECIMIENTONECESIDAD
            mEntidad.IDNECESIDAD = IDNECESIDAD
            mEntidad.IDSOLICITUD = IDSOLICITUD
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarNECESIDADESSOLICITUD(ByVal aEntidad As NECESIDADESSOLICITUD) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarNECESIDADESSOLICITUD(ByVal aEntidad As NECESIDADESSOLICITUD) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTOSOLICITUD As Int32, ByVal IDESTABLECIMIENTONECESIDAD As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSOLICITUD As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTOSOLICITUD, IDESTABLECIMIENTONECESIDAD, IDNECESIDAD, IDSOLICITUD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTOSOLICITUD As Int32, ByVal IDESTABLECIMIENTONECESIDAD As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSOLICITUD As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTOSOLICITUD, IDESTABLECIMIENTONECESIDAD, IDNECESIDAD, IDSOLICITUD, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
