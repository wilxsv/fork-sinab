''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cOPCIONESSISTEMAROLES
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SEGOPCIONESSISTEMAROLES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cOPCIONESSISTEMAROLES
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbOPCIONESSISTEMAROLES()
    Private mEntidad As New OPCIONESSISTEMAROLES
#End Region

    Public Function ObtenerLista(ByVal IDROL As Int32, ByVal IDOPCIONSISTEMA As Int32) As listaOPCIONESSISTEMAROLES
        Try
            Return mDb.ObtenerListaPorID(IDROL, IDOPCIONSISTEMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerOPCIONESSISTEMAROLES(ByRef aEntidad As OPCIONESSISTEMAROLES) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerOPCIONESSISTEMAROLES(ByVal IDROL As Int32, ByVal IDOPCIONSISTEMA As Int32) As OPCIONESSISTEMAROLES
        Try
            mEntidad.IDROL = IDROL
            mEntidad.IDOPCIONSISTEMA = IDOPCIONSISTEMA
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarOPCIONESSISTEMAROLES(ByVal IDROL As Int32, ByVal IDOPCIONSISTEMA As Int32) As Integer
        Try
            mEntidad.IDROL = IDROL
            mEntidad.IDOPCIONSISTEMA = IDOPCIONSISTEMA
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarOPCIONESSISTEMAROLES(ByVal aEntidad As OPCIONESSISTEMAROLES) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarOPCIONESSISTEMAROLES(ByVal aEntidad As OPCIONESSISTEMAROLES) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDROL As Int32, ByVal IDOPCIONSISTEMA As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDROL, IDOPCIONSISTEMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDROL As Int32, ByVal IDOPCIONSISTEMA As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDROL, IDOPCIONSISTEMA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
