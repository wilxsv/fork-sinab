''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cOBSERVACIONPROCESOSCOMPRAS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla OBSERVACIONPROCESOSCOMPRAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cOBSERVACIONPROCESOSCOMPRAS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbOBSERVACIONPROCESOSCOMPRAS()
    Private mEntidad As New OBSERVACIONPROCESOSCOMPRAS
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int64, ByVal IDESTADO As Int32) As listaOBSERVACIONPROCESOSCOMPRAS
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROCESO, IDESTADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerOBSERVACIONPROCESOSCOMPRAS(ByRef aEntidad As OBSERVACIONPROCESOSCOMPRAS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerOBSERVACIONPROCESOSCOMPRAS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int64, ByVal IDESTADO As Int32) As OBSERVACIONPROCESOSCOMPRAS
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROCESO = IDPROCESO
            mEntidad.IDESTADO = IDESTADO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarOBSERVACIONPROCESOSCOMPRAS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int64, ByVal IDESTADO As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROCESO = IDPROCESO
            mEntidad.IDESTADO = IDESTADO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarOBSERVACIONPROCESOSCOMPRAS(ByVal aEntidad As OBSERVACIONPROCESOSCOMPRAS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarOBSERVACIONPROCESOSCOMPRAS(ByVal aEntidad As OBSERVACIONPROCESOSCOMPRAS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int64, ByVal IDESTADO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROCESO, IDESTADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int64, ByVal IDESTADO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROCESO, IDESTADO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
