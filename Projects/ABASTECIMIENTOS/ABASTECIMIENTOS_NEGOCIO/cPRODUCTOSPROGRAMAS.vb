''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cPRODUCTOSPROGRAMAS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_CAT_PRODUCTOSPROGRAMAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	21/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cPRODUCTOSPROGRAMAS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbPRODUCTOSPROGRAMAS()
    Private mEntidad As New PRODUCTOSPROGRAMAS
#End Region

    Public Function ObtenerLista(ByVal IDPRODUCTO As Int64, ByVal IDPROGRAMA As Int16) As listaPRODUCTOSPROGRAMAS
        Try
            Return mDb.ObtenerListaPorID(IDPRODUCTO, IDPROGRAMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerPRODUCTOSPROGRAMAS(ByRef aEntidad As PRODUCTOSPROGRAMAS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerPRODUCTOSPROGRAMAS(ByVal IDPRODUCTO As Int64, ByVal IDPROGRAMA As Int16) As PRODUCTOSPROGRAMAS
        Try
            mEntidad.IDPRODUCTO = IDPRODUCTO
            mEntidad.IDPROGRAMA = IDPROGRAMA
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarPRODUCTOSPROGRAMAS(ByVal IDPRODUCTO As Int64, ByVal IDPROGRAMA As Int16) As Integer
        Try
            mEntidad.IDPRODUCTO = IDPRODUCTO
            mEntidad.IDPROGRAMA = IDPROGRAMA
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarPRODUCTOSPROGRAMAS(ByVal aEntidad As PRODUCTOSPROGRAMAS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarPRODUCTOSPROGRAMAS(ByVal aEntidad As PRODUCTOSPROGRAMAS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDPRODUCTO As Int64, ByVal IDPROGRAMA As Int16) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDPRODUCTO, IDPROGRAMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDPRODUCTO As Int64, ByVal IDPROGRAMA As Int16, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDPRODUCTO, IDPROGRAMA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
