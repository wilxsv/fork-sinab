''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cETIQUETASCLAUSULAS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_CAT_ETIQUETASCLAUSULAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cETIQUETASCLAUSULAS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbETIQUETASCLAUSULAS()
    Private mEntidad As New ETIQUETASCLAUSULAS
#End Region

    Public Function ObtenerLista() As listaETIQUETASCLAUSULAS
        Try
            Return mDb.ObtenerListaPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerETIQUETASCLAUSULAS(ByRef aEntidad As ETIQUETASCLAUSULAS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerETIQUETASCLAUSULAS(ByVal TABLA As String, ByVal CAMPO As String, ByVal ETIQUETA As String) As ETIQUETASCLAUSULAS
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

    Public Function EliminarETIQUETASCLAUSULAS(ByVal TABLA As String, ByVal CAMPO As String, ByVal ETIQUETA As String) As Integer
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

    Public Function ActualizarETIQUETASCLAUSULAS(ByVal aEntidad As ETIQUETASCLAUSULAS) As Integer
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
