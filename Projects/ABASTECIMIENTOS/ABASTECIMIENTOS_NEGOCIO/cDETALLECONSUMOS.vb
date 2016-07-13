''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cDETALLECONSUMOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla DETALLECONSUMOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cDETALLECONSUMOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbDETALLECONSUMOS()
    Private mEntidad As New DETALLECONSUMOS
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64) As listaDETALLECONSUMOS
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDCONSUMO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDETALLECONSUMOS(ByRef aEntidad As DETALLECONSUMOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDETALLECONSUMOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64, ByVal IDDETALLE As Int64) As DETALLECONSUMOS
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDCONSUMO = IDCONSUMO
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

    Public Function EliminarDETALLECONSUMOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64, ByVal IDDETALLE As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDCONSUMO = IDCONSUMO
            mEntidad.IDDETALLE = IDDETALLE
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarDETALLECONSUMOS(ByVal aEntidad As DETALLECONSUMOS) As Integer
        'Try
        Return mDb.Actualizar(aEntidad)
        'Catch ex as Exception
        'ExceptionManager.Publish(ex)
        ' Return -1
        ' End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64) As DataSet
        ' Try
        Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDCONSUMO)
        '  Catch ex as Exception
        'ExceptionManager.Publish(ex)
        '  Return Nothing
        ' End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONSUMO As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDCONSUMO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
