''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cALTERNATIVASPRODUCTO
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla ALTERNATIVASPRODUCTO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cALTERNATIVASPRODUCTO
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbALTERNATIVASPRODUCTO()
    Private mEntidad As New ALTERNATIVASPRODUCTO
#End Region

    Public Function ObtenerLista(ByVal IDALTERNATIVA As Int64, ByVal IDPRODUCTO As Int64) As listaALTERNATIVASPRODUCTO
        Try
            Return mDb.ObtenerListaPorID(IDALTERNATIVA, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerALTERNATIVASPRODUCTO(ByRef aEntidad As ALTERNATIVASPRODUCTO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerALTERNATIVASPRODUCTO(ByVal IDALTERNATIVA As Int64, ByVal IDPRODUCTO As Int64) As ALTERNATIVASPRODUCTO
        Try
            mEntidad.IDALTERNATIVA = IDALTERNATIVA
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

    Public Function EliminarALTERNATIVASPRODUCTO(ByVal IDALTERNATIVA As Int64, ByVal IDPRODUCTO As Int64) As Integer
        Try
            mEntidad.IDALTERNATIVA = IDALTERNATIVA
            mEntidad.IDPRODUCTO = IDPRODUCTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarALTERNATIVASPRODUCTO(ByVal aEntidad As ALTERNATIVASPRODUCTO) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarALTERNATIVASPRODUCTO(ByVal aEntidad As ALTERNATIVASPRODUCTO) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALTERNATIVA As Int64, ByVal IDPRODUCTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDALTERNATIVA, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALTERNATIVA As Int64, ByVal IDPRODUCTO As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDALTERNATIVA, IDPRODUCTO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
