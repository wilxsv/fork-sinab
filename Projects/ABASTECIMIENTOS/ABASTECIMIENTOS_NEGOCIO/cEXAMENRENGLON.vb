''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cEXAMENRENGLON
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla EXAMENRENGLON
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	29/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cEXAMENRENGLON
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbEXAMENRENGLON()
    Private mEntidad As New EXAMENRENGLON
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal IDDOCUMENTOBASE As Int16) As listaEXAMENRENGLON
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, IDDOCUMENTOBASE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerEXAMENRENGLON(ByRef aEntidad As EXAMENRENGLON) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerEXAMENRENGLON(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal IDDOCUMENTOBASE As Int16) As EXAMENRENGLON
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDDETALLE = IDDETALLE
            mEntidad.IDDOCUMENTOBASE = IDDOCUMENTOBASE
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarEXAMENRENGLON(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal IDDOCUMENTOBASE As Int16) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDDETALLE = IDDETALLE
            mEntidad.IDDOCUMENTOBASE = IDDOCUMENTOBASE
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarEXAMENRENGLON(ByVal aEntidad As EXAMENRENGLON) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarEXAMENRENGLON(ByVal aEntidad As EXAMENRENGLON) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal IDDOCUMENTOBASE As Int16) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, IDDOCUMENTOBASE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal IDDOCUMENTOBASE As Int16, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, IDDOCUMENTOBASE, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
