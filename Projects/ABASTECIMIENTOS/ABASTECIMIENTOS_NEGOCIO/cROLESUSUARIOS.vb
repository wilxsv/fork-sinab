''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cROLESUSUARIOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SEGROLESUSUARIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cROLESUSUARIOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbROLESUSUARIOS()
    Private mEntidad As New ROLESUSUARIOS
#End Region

    Public Function ObtenerLista(ByVal IDUSUARIO As Int32, ByVal IDROL As Int32) As listaROLESUSUARIOS
        Try
            Return mDb.ObtenerListaPorID(IDUSUARIO, IDROL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerROLESUSUARIOS(ByRef aEntidad As ROLESUSUARIOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerROLESUSUARIOS(ByVal IDUSUARIO As Int32, ByVal IDROL As Int32) As ROLESUSUARIOS
        Try
            mEntidad.IDUSUARIO = IDUSUARIO
            mEntidad.IDROL = IDROL
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarROLESUSUARIOS(ByVal IDUSUARIO As Int32, ByVal IDROL As Int32) As Integer
        Try
            mEntidad.IDUSUARIO = IDUSUARIO
            mEntidad.IDROL = IDROL
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarROLESUSUARIOS(ByVal aEntidad As ROLESUSUARIOS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarROLESUSUARIOS(ByVal aEntidad As ROLESUSUARIOS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDUSUARIO As Int32, ByVal IDROL As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDUSUARIO, IDROL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDUSUARIO As Int32, ByVal IDROL As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDUSUARIO, IDROL, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
