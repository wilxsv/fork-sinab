''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cPRODUCTOSCONTRATO
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla PRODUCTOSCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cPRODUCTOSCONTRATO
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbPRODUCTOSCONTRATO()
    Private mEntidad As New PRODUCTOSCONTRATO
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As listaPRODUCTOSCONTRATO
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerPRODUCTOSCONTRATO(ByRef aEntidad As PRODUCTOSCONTRATO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerPRODUCTOSCONTRATO(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64) As PRODUCTOSCONTRATO
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.RENGLON = RENGLON
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarPRODUCTOSCONTRATO(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.RENGLON = RENGLON
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarPRODUCTOSCONTRATO(ByVal aEntidad As PRODUCTOSCONTRATO) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
