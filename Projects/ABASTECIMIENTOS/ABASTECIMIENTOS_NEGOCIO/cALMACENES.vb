''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cALMACENES
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla ALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cALMACENES
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbALMACENES()
    Private mEntidad As New ALMACENES
#End Region

    Public Function ObtenerLista() As listaALMACENES
        Try
            Return mDb.ObtenerListaPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerALMACENES(ByRef aEntidad As ALMACENES) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerALMACENES(ByVal IDALMACEN As Int32) As ALMACENES
        Try
            mEntidad.IDALMACEN = IDALMACEN
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Public Function EliminarALMACENES(ByVal IDALMACEN As Int32) As Integer
    '    'Try
    '    '    mEntidad.IDALMACEN = IDALMACEN
    '    '    Return mDb.Eliminar(mEntidad)
    '    'Catch ex as Exception
    '    '    ExceptionManager.Publish(ex)
    '    '    Return -1
    '    'End Try

    '    Try
    '        mEntidad.IDALMACEN = IDALMACEN
    '        Return mDb.Eliminar(mEntidad)
    '    Catch ex As System.Data.SqlClient.SqlException
    '        ExceptionManager.Publish(ex)
    '        Return ex.Number
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return -1
    '    End Try
    'End Function

    Public Function ActualizarALMACENES(ByVal aEntidad As ALMACENES) As Integer
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
