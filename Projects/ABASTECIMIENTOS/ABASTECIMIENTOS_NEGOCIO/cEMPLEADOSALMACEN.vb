''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cEMPLEADOSALMACEN
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla EMPLEADOSALMACEN
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cEMPLEADOSALMACEN
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbEMPLEADOSALMACEN()
    Private mEntidad As New EMPLEADOSALMACEN
#End Region

    Public Function ObtenerLista(ByVal IDALMACEN As Int32, ByVal IDEMPLEADO As Int32) As listaEMPLEADOSALMACEN
        Try
            Return mDb.ObtenerListaPorID(IDALMACEN, IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerEMPLEADOSALMACEN(ByRef aEntidad As EMPLEADOSALMACEN) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerEMPLEADOSALMACEN(ByVal IDALMACEN As Int32, ByVal IDEMPLEADO As Int32) As EMPLEADOSALMACEN
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDEMPLEADO = IDEMPLEADO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarEMPLEADOSALMACEN(ByVal IDALMACEN As Int32, ByVal IDEMPLEADO As Int32) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDEMPLEADO = IDEMPLEADO
            Return mDb.Eliminar(mEntidad)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarEMPLEADOSALMACEN(ByVal aEntidad As EMPLEADOSALMACEN) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarEMPLEADOSALMACEN(ByVal aEntidad As EMPLEADOSALMACEN) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByVal IDEMPLEADO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByVal IDEMPLEADO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDEMPLEADO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
