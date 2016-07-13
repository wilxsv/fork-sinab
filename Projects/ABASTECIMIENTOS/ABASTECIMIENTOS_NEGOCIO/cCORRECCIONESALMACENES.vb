''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cCORRECCIONESALMACENES
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_ALM_CORRECCIONESALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cCORRECCIONESALMACENES
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbCORRECCIONESALMACENES()
    Private mEntidad As New CORRECCIONESALMACENES
#End Region

    Public Function ObtenerLista(ByVal IDALMACEN As Int32) As listaCORRECCIONESALMACENES
        Try
            Return mDb.ObtenerListaPorID(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCORRECCIONESALMACENES(ByRef aEntidad As CORRECCIONESALMACENES) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerCORRECCIONESALMACENES(ByVal IDALMACEN As Int32, ByVal ANIO As Int16, ByVal IDCORRECCION As Int32) As CORRECCIONESALMACENES
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.ANIO = ANIO
            mEntidad.IDCORRECCION = IDCORRECCION
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarCORRECCIONESALMACENES(ByVal IDALMACEN As Int32, ByVal ANIO As Int16, ByVal IDCORRECCION As Int32) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.ANIO = ANIO
            mEntidad.IDCORRECCION = IDCORRECCION
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarCORRECCIONESALMACENES(ByVal aEntidad As CORRECCIONESALMACENES) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
