''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cUBICACIONESPRODUCTOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla UBICACIONESPRODUCTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cUBICACIONESPRODUCTOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbUBICACIONESPRODUCTOS()
    Private mEntidad As New UBICACIONESPRODUCTOS
#End Region

    Public Function ObtenerLista(ByVal IDALMACEN As Int32) As listaUBICACIONESPRODUCTOS
        Try
            Return mDb.ObtenerListaPorID(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerUBICACIONESPRODUCTOS(ByRef aEntidad As UBICACIONESPRODUCTOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerUBICACIONESPRODUCTOS(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDUBICACION As Int32) As UBICACIONESPRODUCTOS
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDPRODUCTO = IDPRODUCTO
            mEntidad.IDUBICACION = IDUBICACION
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarUBICACIONESPRODUCTOS(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDUBICACION As Int32) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDPRODUCTO = IDPRODUCTO
            mEntidad.IDUBICACION = IDUBICACION
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarUBICACIONESPRODUCTOS(ByVal aEntidad As UBICACIONESPRODUCTOS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerUbicacionesProductosAlmacen(ByVal IDALMACEN As Int32, ByVal idproducto As Integer) As DataSet
        Try
            Return mDb.ObtenerUbicacionesProductosAlmacen(IDALMACEN, idproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class
