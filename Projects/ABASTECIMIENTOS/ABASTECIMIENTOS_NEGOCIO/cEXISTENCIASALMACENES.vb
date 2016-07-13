''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cEXISTENCIASALMACENES
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla EXISTENCIASALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cEXISTENCIASALMACENES
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbEXISTENCIASALMACENES()
    Private mEntidad As New EXISTENCIASALMACENES
#End Region

    Public Function ObtenerLista(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As listaEXISTENCIASALMACENES
        Try
            Return mDb.ObtenerListaPorID(IDALMACEN, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerEXISTENCIASALMACENES(ByRef aEntidad As EXISTENCIASALMACENES) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerEXISTENCIASALMACENES(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As EXISTENCIASALMACENES
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDPRODUCTO = IDPRODUCTO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarEXISTENCIASALMACENES(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDPRODUCTO = IDPRODUCTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarEXISTENCIASALMACENES(ByVal aEntidad As EXISTENCIASALMACENES) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarEXISTENCIASALMACENES(ByVal aEntidad As EXISTENCIASALMACENES) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDPRODUCTO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
