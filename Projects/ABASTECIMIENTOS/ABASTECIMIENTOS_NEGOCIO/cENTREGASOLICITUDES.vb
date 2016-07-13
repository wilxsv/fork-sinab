''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cENTREGASOLICITUDES
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla ENTREGASOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cENTREGASOLICITUDES
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbENTREGASOLICITUDES()
    Private mEntidad As New ENTREGASOLICITUDES
#End Region

    'Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As listaENTREGASOLICITUDES
    '    Try
    '        Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDSOLICITUD)
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return Nothing
    '    End Try
    'End Function

    'Public Function ObtenerENTREGASOLICITUDES(ByRef aEntidad As ENTREGASOLICITUDES) As Integer
    '    Try
    '        Dim liRet As Integer
    '        liRet = mDb.Recuperar(aEntidad)
    '        Return liRet
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return -1
    '    End Try
    'End Function

    'Public Function ObtenerENTREGASOLICITUDES(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDENTREGA As Byte) As ENTREGASOLICITUDES
    '    Try
    '        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
    '        mEntidad.IDSOLICITUD = IDSOLICITUD
    '        mEntidad.IDENTREGA = IDENTREGA
    '        Dim liRet As Integer
    '        liRet = mDb.Recuperar(mEntidad)
    '        If liRet = 1 Then Return mEntidad
    '        Return Nothing
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return Nothing
    '    End Try
    'End Function

    'Public Function EliminarENTREGASOLICITUDES(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDENTREGA As Byte) As Integer
    '    Try
    '        mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
    '        mEntidad.IDSOLICITUD = IDSOLICITUD
    '        mEntidad.IDENTREGA = IDENTREGA
    '        Return mDb.Eliminar(mEntidad)
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return -1
    '    End Try
    'End Function

    'Public Function ActualizarENTREGASOLICITUDES(ByVal aEntidad As ENTREGASOLICITUDES) As Integer
    '    Try
    '        Return mDb.Actualizar(aEntidad)
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return -1
    '    End Try
    'End Function

    'Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet
    '    Try
    '        Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDSOLICITUD)
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return Nothing
    '    End Try
    'End Function

    'Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByRef ds As DataSet) As Integer
    '    Try
    '        Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDSOLICITUD, ds)
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return -1
    '    End Try
    'End Function

#End Region

End Class
