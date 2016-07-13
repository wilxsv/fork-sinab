''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cCATALOGOPRODUCTOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla CATALOGOPRODUCTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cCATALOGOPRODUCTOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbCATALOGOPRODUCTOS()
    Private mEntidad As New CATALOGOPRODUCTOS
#End Region

    Public Function ObtenerLista() As listaCATALOGOPRODUCTOS
        'Try
            Return mDb.ObtenerListaPorID()
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerCATALOGOPRODUCTOS(ByRef aEntidad As CATALOGOPRODUCTOS) As Integer
        'Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerCATALOGOPRODUCTOS(ByVal IDPRODUCTO As Int64) As CATALOGOPRODUCTOS
        'Try
            mEntidad.IDPRODUCTO = IDPRODUCTO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function EliminarCATALOGOPRODUCTOS(ByVal IDPRODUCTO As Int64) As Integer
        'Try
            mEntidad.IDPRODUCTO = IDPRODUCTO
            Return mDb.Eliminar(mEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ActualizarCATALOGOPRODUCTOS(ByVal aEntidad As CATALOGOPRODUCTOS) As Integer
        'Try
            Return mDb.Actualizar(aEntidad)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function

    Public Function ObtenerDataSetPorId() As DataSet
        'Try
            Return mDb.ObtenerDataSetPorID()
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerDataSetPorId(ByRef ds As DataSet) As Integer
        'Try
            Return mDb.ObtenerDataSetPorID(ds)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
    Public Function ActualizarTipoProductoUACI(ByVal idproducto As Integer, ByVal idgrupo As Integer) As Integer
        'Try
            Return mDb.ActualizarTipoProductoUACI(idproducto, idgrupo)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return -1
        'End Try
    End Function
#End Region

End Class
