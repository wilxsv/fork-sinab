''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cSUMINISTROS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SUMINISTROS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cSUMINISTROS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbSUMINISTROS()
    Private mEntidad As New SUMINISTROS
#End Region

    Public Function ObtenerLista() As listaSUMINISTROS
        'Try
            Return mDb.ObtenerListaPorID()
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerSUMINISTROS(ByRef aEntidad As SUMINISTROS) As Integer
        'Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerSUMINISTROS(ByVal IDSUMINISTRO As Int32) As SUMINISTROS
        'Try
            mEntidad.IDSUMINISTRO = IDSUMINISTRO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function EliminarSUMINISTROS(ByVal IDSUMINISTRO As Int32) As Integer
        'Try
            mEntidad.IDSUMINISTRO = IDSUMINISTRO
            Return mDb.Eliminar(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ActualizarSUMINISTROS(ByVal aEntidad As SUMINISTROS) As Integer
        'Try
            Return mDb.Actualizar(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerDataSetPorId() As DataSet
        'Try
            Return mDb.ObtenerDataSetPorID()
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerDataSetPorId(ByRef ds As DataSet) As Integer
        'Try
            Return mDb.ObtenerDataSetPorID(ds)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function obtenerSuministroOrdenado(Optional ByVal campoOrden As String = "idSuministro") As DataSet
        'Try
            Return mDb.obtenerSuministroOrdenado(campoOrden)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

#End Region

End Class
