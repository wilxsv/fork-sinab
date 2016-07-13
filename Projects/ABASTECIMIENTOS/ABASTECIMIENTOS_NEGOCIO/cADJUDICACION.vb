''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cADJUDICACION
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla ADJUDICACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cADJUDICACION
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbADJUDICACION()
    Private mEntidad As New ADJUDICACION
#End Region

    Public Function ObtenerLista(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As listaADJUDICACION
        Try
            Return mDb.ObtenerListaPorID(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerADJUDICACION(ByRef aEntidad As ADJUDICACION) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerADJUDICACION(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As ADJUDICACION
        Try
            mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDDETALLE = IDDETALLE
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarADJUDICACION(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As Integer
        Try
            mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDDETALLE = IDDETALLE
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarADJUDICACION(ByVal aEntidad As ADJUDICACION) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarADJUDICACION(ByVal aEntidad As ADJUDICACION) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR, IDDETALLE, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
