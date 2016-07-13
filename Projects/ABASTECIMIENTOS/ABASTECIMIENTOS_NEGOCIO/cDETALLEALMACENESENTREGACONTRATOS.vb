''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cDETALLEALMACENESENTREGACONTRATOS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_UACI_DETALLEALMACENESENTREGACONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cDETALLEALMACENESENTREGACONTRATOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbDETALLEALMACENESENTREGACONTRATOS()
    Private mEntidad As New DETALLEALMACENESENTREGACONTRATOS
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDDETALLEENTREGA As Int64, ByVal IDALMACENENTREGA As Int32) As listaDETALLEALMACENESENTREGACONTRATOS
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, IDDETALLEENTREGA, IDALMACENENTREGA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDETALLEALMACENESENTREGACONTRATOS(ByRef aEntidad As DETALLEALMACENESENTREGACONTRATOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDETALLEALMACENESENTREGACONTRATOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDDETALLEENTREGA As Int64, ByVal IDALMACENENTREGA As Int32, ByVal IDDETALLE As Int32) As DETALLEALMACENESENTREGACONTRATOS
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.RENGLON = RENGLON
            mEntidad.IDDETALLEENTREGA = IDDETALLEENTREGA
            mEntidad.IDALMACENENTREGA = IDALMACENENTREGA
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

    Public Function EliminarDETALLEALMACENESENTREGACONTRATOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDDETALLEENTREGA As Int64, ByVal IDALMACENENTREGA As Int32, ByVal IDDETALLE As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.RENGLON = RENGLON
            mEntidad.IDDETALLEENTREGA = IDDETALLEENTREGA
            mEntidad.IDALMACENENTREGA = IDALMACENENTREGA
            mEntidad.IDDETALLE = IDDETALLE
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarDETALLEALMACENESENTREGACONTRATOS(ByVal aEntidad As DETALLEALMACENESENTREGACONTRATOS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDDETALLEENTREGA As Int64, ByVal IDALMACENENTREGA As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, IDDETALLEENTREGA, IDALMACENENTREGA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDDETALLEENTREGA As Int64, ByVal IDALMACENENTREGA As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, IDDETALLEENTREGA, IDALMACENENTREGA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
