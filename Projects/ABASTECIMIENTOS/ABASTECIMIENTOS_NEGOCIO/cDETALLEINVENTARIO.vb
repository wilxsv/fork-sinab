''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cDETALLEINVENTARIO
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla DETALLEINVENTARIO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cDETALLEINVENTARIO
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbDETALLEINVENTARIO()
    Private mEntidad As New DETALLEINVENTARIO
#End Region

    Public Function ObtenerLista(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As listaDETALLEINVENTARIO
        Try
            Return mDb.ObtenerListaPorID(IDALMACEN, IDINVENTARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDETALLEINVENTARIO(ByRef aEntidad As DETALLEINVENTARIO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDETALLEINVENTARIO(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal IDDETALLE As Int32) As DETALLEINVENTARIO
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDINVENTARIO = IDINVENTARIO
            mEntidad.IDDETALLE = IDDETALLE
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarDETALLEINVENTARIO(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal IDDETALLE As Int32) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDINVENTARIO = IDINVENTARIO
            mEntidad.IDDETALLE = IDDETALLE
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarDETALLEINVENTARIO(ByVal aEntidad As DETALLEINVENTARIO) As Integer
        'Try
        Return mDb.Actualizar(aEntidad)
        'Catch ex as Exception
        'ExceptionManager.Publish(ex)
        'Return -1
        'End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDINVENTARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDINVENTARIO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
