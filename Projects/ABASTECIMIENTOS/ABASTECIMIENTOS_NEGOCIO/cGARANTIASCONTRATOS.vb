''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cGARANTIASCONTRATOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla GARANTIASCONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cGARANTIASCONTRATOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbGARANTIASCONTRATOS()
    Private mEntidad As New GARANTIASCONTRATOS
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16) As listaGARANTIASCONTRATOS
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDTIPOGARANTIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerGARANTIASCONTRATOS(ByRef aEntidad As GARANTIASCONTRATOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerGARANTIASCONTRATOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16) As GARANTIASCONTRATOS
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.IDTIPOGARANTIA = IDTIPOGARANTIA
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarGARANTIASCONTRATOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.IDTIPOGARANTIA = IDTIPOGARANTIA
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarGARANTIASCONTRATOS(ByVal aEntidad As GARANTIASCONTRATOS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarGARANTIASCONTRATOS(ByVal aEntidad As GARANTIASCONTRATOS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDTIPOGARANTIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDTIPOGARANTIA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
