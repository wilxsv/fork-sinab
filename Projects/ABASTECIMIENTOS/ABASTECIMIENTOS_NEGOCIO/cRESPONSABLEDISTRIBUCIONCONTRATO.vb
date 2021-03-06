''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cRESPONSABLEDISTRIBUCIONCONTRATO
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla RESPONSABLEDISTRIBUCIONCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cRESPONSABLEDISTRIBUCIONCONTRATO
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbRESPONSABLEDISTRIBUCIONCONTRATO()
    Private mEntidad As New RESPONSABLEDISTRIBUCIONCONTRATO
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDRESPONSABLEDISTRIBUCION As Int32) As listaRESPONSABLEDISTRIBUCIONCONTRATO
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDRESPONSABLEDISTRIBUCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerRESPONSABLEDISTRIBUCIONCONTRATO(ByRef aEntidad As RESPONSABLEDISTRIBUCIONCONTRATO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerRESPONSABLEDISTRIBUCIONCONTRATO(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDRESPONSABLEDISTRIBUCION As Int32) As RESPONSABLEDISTRIBUCIONCONTRATO
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
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

    Public Function EliminarRESPONSABLEDISTRIBUCIONCONTRATO(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDRESPONSABLEDISTRIBUCION As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.IDRESPONSABLEDISTRIBUCION = IDRESPONSABLEDISTRIBUCION
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarRESPONSABLEDISTRIBUCIONCONTRATO(ByVal aEntidad As RESPONSABLEDISTRIBUCIONCONTRATO) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function ActualizarRESPONSABLEDISTRIBUCIONCONTRATO(ByVal aEntidad As RESPONSABLEDISTRIBUCIONCONTRATO) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDRESPONSABLEDISTRIBUCION As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDRESPONSABLEDISTRIBUCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDRESPONSABLEDISTRIBUCION As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDRESPONSABLEDISTRIBUCION, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
