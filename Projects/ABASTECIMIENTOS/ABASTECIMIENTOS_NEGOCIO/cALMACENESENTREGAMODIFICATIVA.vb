''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cALMACENESENTREGAMODIFICATIVA
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_UACI_ALMACENESENTREGAMODIFICATIVA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cALMACENESENTREGAMODIFICATIVA
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbALMACENESENTREGAMODIFICATIVA()
    Private mEntidad As New ALMACENESENTREGAMODIFICATIVA
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64, ByVal IDENTREGA As Byte, ByVal IDALMACENENTREGA As Int32) As listaALMACENESENTREGAMODIFICATIVA
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMODIFICATIVA, RENGLON, IDENTREGA, IDALMACENENTREGA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerALMACENESENTREGAMODIFICATIVA(ByRef aEntidad As ALMACENESENTREGAMODIFICATIVA) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerALMACENESENTREGAMODIFICATIVA(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64, ByVal IDENTREGA As Byte, ByVal IDALMACENENTREGA As Int32) As ALMACENESENTREGAMODIFICATIVA
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.IDMODIFICATIVA = IDMODIFICATIVA
            mEntidad.RENGLON = RENGLON
            mEntidad.IDENTREGA = IDENTREGA
            mEntidad.IDALMACENENTREGA = IDALMACENENTREGA
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarALMACENESENTREGAMODIFICATIVA(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64, ByVal IDENTREGA As Byte, ByVal IDALMACENENTREGA As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.IDMODIFICATIVA = IDMODIFICATIVA
            mEntidad.RENGLON = RENGLON
            mEntidad.IDENTREGA = IDENTREGA
            mEntidad.IDALMACENENTREGA = IDALMACENENTREGA
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarALMACENESENTREGAMODIFICATIVA(ByVal aEntidad As ALMACENESENTREGAMODIFICATIVA) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarALMACENESENTREGAMODIFICATIVA(ByVal aEntidad As ALMACENESENTREGAMODIFICATIVA) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64, ByVal IDENTREGA As Byte, ByVal IDALMACENENTREGA As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMODIFICATIVA, RENGLON, IDENTREGA, IDALMACENENTREGA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64, ByVal IDENTREGA As Byte, ByVal IDALMACENENTREGA As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMODIFICATIVA, RENGLON, IDENTREGA, IDALMACENENTREGA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
