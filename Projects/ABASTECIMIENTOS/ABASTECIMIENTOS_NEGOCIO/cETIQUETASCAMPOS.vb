''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cETIQUETASCAMPOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla ETIQUETASCAMPOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cETIQUETASCAMPOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbETIQUETASCAMPOS()
    Private mEntidad As New ETIQUETASCAMPOS
#End Region

    Public Function ObtenerLista() As listaETIQUETASCAMPOS
        Try
            Return mDb.ObtenerListaPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerETIQUETASCAMPOS(ByRef aEntidad As ETIQUETASCAMPOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerETIQUETASCAMPOS(ByVal TABLA As String, ByVal CAMPO As String, ByVal ETIQUETA As String) As ETIQUETASCAMPOS
        Try
            mEntidad.TABLA = TABLA
            mEntidad.CAMPO = CAMPO
            mEntidad.ETIQUETA = ETIQUETA
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarETIQUETASCAMPOS(ByVal TABLA As String, ByVal CAMPO As String, ByVal ETIQUETA As String) As Integer
        Try
            mEntidad.TABLA = TABLA
            mEntidad.CAMPO = CAMPO
            mEntidad.ETIQUETA = ETIQUETA
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarETIQUETASCAMPOS(ByVal aEntidad As ETIQUETASCAMPOS) As Integer
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
