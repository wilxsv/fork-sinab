''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cDETALLESOLICITUDES
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla DETALLESOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cDETALLESOLICITUDES
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbDETALLESOLICITUDES()
    Private mEntidad As New DETALLESOLICITUDES
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As listaDETALLESOLICITUDES
        'Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDSOLICITUD)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerDETALLESOLICITUDES(ByRef aEntidad As DETALLESOLICITUDES) As Integer
        'Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerDETALLESOLICITUDES(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal renglon As Int64) As DETALLESOLICITUDES
        'Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.RENGLON = renglon
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function EliminarDETALLESOLICITUDES(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal idproducto As Int64, ByVal idespecificacion As Integer) As Integer
        'Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.IDPRODUCTO = idproducto
            mEntidad.IDESPECIFICACION = idespecificacion
            Return mDb.Eliminar(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function AsignarRenglon(ByVal idSolicitud As Int64, ByVal IDEstablecimiento As Int64) As Integer
        'Try
            Return mDb.AsignarRenglon(idSolicitud, IDEstablecimiento)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ActualizarDETALLESOLICITUDES(ByVal aEntidad As DETALLESOLICITUDES) As Integer
        'Try
            Return mDb.Actualizar(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet
        'Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDSOLICITUD)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByRef ds As DataSet) As Integer
        'Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDSOLICITUD, ds)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function EliminarESPECIFICACIONESSOLICITUD(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal idproducto As Int64, ByVal IDESPECIFICACION As Integer) As Integer
        'Try
            Return mDb.EliminarEspecificacionessolicitud(IDESTABLECIMIENTO, IDSOLICITUD, idproducto, IDESPECIFICACION)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function ActualizaIDEspecificacionProductosSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal idproducto As Int64, ByVal IDESPECIFICACION As Integer, ByVal renglon As Integer) As Integer
        'Try
            Return mDb.ActualizaIDEspecificacionProductosSolicitud(IDSOLICITUD, IDESTABLECIMIENTO, idproducto, renglon, IDESPECIFICACION)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
#End Region

End Class
