''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cRESPONSABLEDISTRIBUCION
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla RESPONSABLEDISTRIBUCION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cRESPONSABLEDISTRIBUCION
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbRESPONSABLEDISTRIBUCION()
    Private mEntidad As New RESPONSABLEDISTRIBUCION
#End Region

    Public Function ObtenerLista() As listaRESPONSABLEDISTRIBUCION
        Try
            Return mDb.ObtenerListaPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerRESPONSABLEDISTRIBUCION(ByRef aEntidad As RESPONSABLEDISTRIBUCION) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerRESPONSABLEDISTRIBUCION(ByVal IDRESPONSABLEDISTRIBUCION As Int32) As RESPONSABLEDISTRIBUCION
        Try
            mEntidad.IDRESPONSABLEDISTRIBUCION = IDRESPONSABLEDISTRIBUCION
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarRESPONSABLEDISTRIBUCION(ByVal IDRESPONSABLEDISTRIBUCION As Int32) As Integer
        Try
            mEntidad.IDRESPONSABLEDISTRIBUCION = IDRESPONSABLEDISTRIBUCION
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarRESPONSABLEDISTRIBUCION(ByVal aEntidad As RESPONSABLEDISTRIBUCION) As Integer
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
