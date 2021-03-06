''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cMODIFICATIVASCONTRATOPRODUCTO
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cMODIFICATIVASCONTRATOPRODUCTO
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbMODIFICATIVASCONTRATOPRODUCTO()
    Private mEntidad As New MODIFICATIVASCONTRATOPRODUCTO
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64) As listaMODIFICATIVASCONTRATOPRODUCTO
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMODIFICATIVA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerMODIFICATIVASCONTRATOPRODUCTO(ByRef aEntidad As MODIFICATIVASCONTRATOPRODUCTO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerMODIFICATIVASCONTRATOPRODUCTO(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64) As MODIFICATIVASCONTRATOPRODUCTO
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.IDMODIFICATIVA = IDMODIFICATIVA
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

    Public Function EliminarMODIFICATIVASCONTRATOPRODUCTO(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.IDMODIFICATIVA = IDMODIFICATIVA
            mEntidad.RENGLON = RENGLON
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarMODIFICATIVASCONTRATOPRODUCTO(ByVal aEntidad As MODIFICATIVASCONTRATOPRODUCTO) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarMODIFICATIVASCONTRATOPRODUCTO(ByVal aEntidad As MODIFICATIVASCONTRATOPRODUCTO) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMODIFICATIVA, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMODIFICATIVA, RENGLON, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
