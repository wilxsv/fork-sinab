''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cTIPOMOVIMIENTOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_CAT_TIPOMOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/06/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cTIPOMOVIMIENTOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbTIPOMOVIMIENTOS()
    Private mEntidad As New TIPOMOVIMIENTOS
#End Region

    Public Function ObtenerLista(ByVal IDTIPOTRANSACCION As Int32) As listaTIPOMOVIMIENTOS
        Try
            Return mDb.ObtenerListaPorID(IDTIPOTRANSACCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerTIPOMOVIMIENTOS(ByRef aEntidad As TIPOMOVIMIENTOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerTIPOMOVIMIENTOS(ByVal IDTIPOTRANSACCION As Int32, ByVal IDTIPOMOVIMIENTO As Int32) As TIPOMOVIMIENTOS
        Try
            mEntidad.IDTIPOTRANSACCION = IDTIPOTRANSACCION
            mEntidad.IDTIPOMOVIMIENTO = IDTIPOMOVIMIENTO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarTIPOMOVIMIENTOS(ByVal IDTIPOTRANSACCION As Int32, ByVal IDTIPOMOVIMIENTO As Int32) As Integer
        Try
            mEntidad.IDTIPOTRANSACCION = IDTIPOTRANSACCION
            mEntidad.IDTIPOMOVIMIENTO = IDTIPOMOVIMIENTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarTIPOMOVIMIENTOS(ByVal aEntidad As TIPOMOVIMIENTOS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDTIPOTRANSACCION As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDTIPOTRANSACCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDTIPOTRANSACCION As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDTIPOTRANSACCION, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
